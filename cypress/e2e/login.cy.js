describe('Login Flow (CI Safe)', () => {
  it('should login successfully', () => {
    cy.intercept('POST', '**/login', {
      statusCode: 200,
      body: {
        token: 'fake-token',
        user: { email: 'qazqaz@qazqaz.com' },
      },
    }).as('login');

    cy.visit('http://localhost:5173/login');

    cy.get('input[placeholder="EMAIL"]').type('qazqaz@qazqaz.com');
    cy.get('input[placeholder="KATA SANDI"]').type('qazqazqaz');

    cy.contains('Login').click();

    cy.wait('@login');

    cy.location('pathname', { timeout: 10000 }).should('eq', '/');
  });
});
