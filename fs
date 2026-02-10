[33mcommit bc3e5e732edc80767392d7e02f46d68a97e47a2a[m[33m ([m[1;36mHEAD[m[33m -> [m[1;32mmain[m[33m, [m[1;31morigin/main[m[33m)[m
Author: Rafly Erdani <dicodingrafly@gmail.com>
Date:   Tue Feb 10 21:49:51 2026 +0700

    first commit

[1mdiff --git a/.github/workflows/ci.yml b/.github/workflows/ci.yml[m
[1mnew file mode 100644[m
[1mindex 0000000..1d50fdd[m
[1m--- /dev/null[m
[1m+++ b/.github/workflows/ci.yml[m
[36m@@ -0,0 +1,21 @@[m
[32m+[m[32mname: Continuous Integration[m
[32m+[m
[32m+[m[32mon:[m
[32m+[m[32m  pull_request:[m
[32m+[m[32m    branches:[m
[32m+[m[32m      - main[m
[32m+[m
[32m+[m[32mjobs:[m
[32m+[m[32m  automation-test-job:[m
[32m+[m[32m    runs-on: ubuntu-latest[m
[32m+[m
[32m+[m[32m    steps:[m
[32m+[m[32m      - uses: actions/checkout@v2[m
[32m+[m[32m      - name: Use Node.js ${{ matrix.node-version }}[m
[32m+[m[32m        uses: actions/setup-node@v2[m
[32m+[m[32m        with:[m
[32m+[m[32m          node-version: ${{ matrix.node-version }}[m
[32m+[m[32m      - name: npm install and test[m
[32m+[m[32m        run: |[m
[32m+[m[32m          npm install[m
[32m+[m[32m          npm run ci:test[m
[1mdiff --git a/.gitignore b/.gitignore[m
[1mnew file mode 100644[m
[1mindex 0000000..f52343a[m
[1m--- /dev/null[m
[1m+++ b/.gitignore[m
[36m@@ -0,0 +1,27 @@[m
[32m+[m[32m# Logs[m
[32m+[m[32mlogs[m
[32m+[m[32m*.log[m
[32m+[m[32mnpm-debug.log*[m
[32m+[m[32myarn-debug.log*[m
[32m+[m[32myarn-error.log*[m
[32m+[m[32mpnpm-debug.log*[m
[32m+[m[32mlerna-debug.log*[m
[32m+[m
[32m+[m[32mnode_modules[m
[32m+[m[32mdist[m
[32m+[m[32mdist-ssr[m
[32m+[m[32m*.local[m
[32m+[m
[32m+[m[32m# Editor directories and files[m
[32m+[m[32m.vscode/*[m
[32m+[m[32m!.vscode/extensions.json[m
[32m+[m[32m.idea[m
[32m+[m[32m.DS_Store[m
[32m+[m[32m*.suo[m
[32m+[m[32m*.ntvs*[m
[32m+[m[32m*.njsproj[m
[32m+[m[32m*.sln[m
[32m+[m[32m*.sw?[m
[32m+[m
[32m+[m[32m*storybook.log[m
[32m+[m[32mstorybook-static[m
[1mdiff --git a/.storybook/main.js b/.storybook/main.js[m
[1mnew file mode 100644[m
[1mindex 0000000..03fa135[m
[1m--- /dev/null[m
[1m+++ b/.storybook/main.js[m
[36m@@ -0,0 +1,18 @@[m
[32m+[m
[32m+[m
[32m+[m[32m/** @type { import('@storybook/react-vite').StorybookConfig } */[m
[32m+[m[32mconst config = {[m
[32m+[m[32m  "stories": [[m
[32m+[m[32m    "../src/**/*.mdx",[m
[32m+[m[32m    "../src/**/*.stories.@(js|jsx|mjs|ts|tsx)"[m
[32m+[m[32m  ],[m
[32m+[m[32m  "addons": [[m
[32m+[m[32m    "@chromatic-com/storybook",[m
[32m+[m[32m    "@storybook/addon-vitest",[m
[32m+[m[32m    "@storybook/addon-a11y",[m
[32m+[m[32m    "@storybook/addon-docs",[m
[32m+[m[32m    "@storybook/addon-onboarding"[m
[32m+[m[32m  ],[m
[32m+[m[32m  "framework": "@storybook/react-vite"[m
[32m+[m[32m};[m
[32m+[m[32mexport default config;[m
\ No newline at end of file[m
[1mdiff --git a/.storybook/preview.js b/.storybook/preview.js[m
[1mnew file mode 100644[m
[1mindex 0000000..d43e27e[m
[1m--- /dev/null[m
[1m+++ b/.storybook/preview.js[m
[36m@@ -0,0 +1,20 @@[m
[32m+[m[32m/** @type { import('@storybook/react-vite').Preview } */[m
[32m+[m[32mconst preview = {[m
[32m+[m[32m  parameters: {[m
[32m+[m[32m    controls: {[m
[32m+[m[32m      matchers: {[m
[32m+[m[32m       color: /(background|color)$/i,[m
[32m+[m[32m       date: /Date$/i,[m
[32m+[m[32m      },[m
[32m+[m[32m    },[m
[32m+[m
[32m+[m[32m    a11y: {[m
[32m+[m[32m      // 'todo' - show a11y violations in the test UI only[m
[32m+[m[32m      // 'error' - fail CI on a11y violations[m
[32m+[m[32m      // 'off' - skip a11y checks entirely[m
[32m+[m[32m      test: "todo"[m
[32m+[m[32m    }[m
[32m+[m[32m  },[m
[32m+[m[32m};[m
[32m+[m
[32m+[m[32mexport default preview;[m
\ No newline at end of file[m
[1mdiff --git a/.storybook/vitest.setup.js b/.storybook/vitest.setup.js[m
[1mnew file mode 100644[m
[1mindex 0000000..44922d5[m
[1m--- /dev/null[m
[1m+++ b/.storybook/vitest.setup.js[m
[36m@@ -0,0 +1,7 @@[m
[32m+[m[32mimport * as a11yAddonAnnotations from "@storybook/addon-a11y/preview";[m
[32m+[m[32mimport { setProjectAnnotations } from '@storybook/react-vite';[m
[32m+[m[32mimport * as projectAnnotations from './preview';[m
[32m+[m
[32m+[m[32m// This is an important step to apply the right configuration when testing your stories.[m
[32m+[m[32m// More info at: https://storybook.js.org/docs/api/portable-stories/portable-stories-vitest#setprojectannotations[m
[32m+[m[32msetProjectAnnotations([a11yAddonAnnotations, projectAnnotations]);[m
\ No newline at end of file[m
[1mdiff --git a/README.md b/README.md[m
[1mnew file mode 100644[m
[1mindex 0000000..18bc70e[m
[1m--- /dev/null[m
[1m+++ b/README.md[m
[36m@@ -0,0 +1,16 @@[m
[32m+[m[32m# React + Vite[m
[32m+[m
[32m+[m[32mThis template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.[m
[32m+[m
[32m+[m[32mCurrently, two official plugins are available:[m
[32m+[m
[32m+[m[32m- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Babel](https://babeljs.io/) (or [oxc](https://oxc.rs) when used in [rolldown-vite](https://vite.dev/guide/rolldown)) for Fast Refresh[m
[32m+[m[32m- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh[m
[32m+[m
[32m+[m[32m## React Compiler[m
[32m+[m
[32m+[m[32mThe React Compiler is not enabled on this template because of its impact on dev & build performances. To add it, see [this documentation](https://react.dev/learn/react-compiler/installation).[m
[32m+[m
[32m+[m[32m## Expanding the ESLint configuration[m
[32m+[m
[32m+[m[32mIf you are developing a production application, we recommend using TypeScript with type-aware lint rules enabled. Check out the [TS template](https://github.com/vitejs/vite/tree/main/packages/create-vite/template-react-ts) for information on how to integrate TypeScript and [`typescript-eslint`](https://typescript-eslint.io) in your project.[m
[1mdiff --git a/cypress.config.js b/cypress.config.js[m
[1mnew file mode 100644[m
[1mindex 0000000..013077b[m
[1m--- /dev/null[m
[1m+++ b/cypress.config.js[m
[36m@@ -0,0 +1,11 @@[m
[32m+[m[32mimport { defineConfig } from 'cypress';[m
[32m+[m
[32m+[m[32mexport default defineConfig({[m
[32m+[m[32m  allowCypressEnv: false,[m
[32m+[m
[32m+[m[32m  e2e: {[m
[32m+[m[32m    setupNodeEvents(on, config) {[m
[32m+[m[32m      // implement node event listeners here[m
[32m+[m[32m    },[m
[32m+[m[32m  },[m
[32m+[m[32m});[m
[1mdiff --git a/cypress/e2e/login.cy.js b/cypress/e2e/login.cy.js[m
[1mnew file mode 100644[m
[1mindex 0000000..e69e094[m
[1m--- /dev/null[m
[1m+++ b/cypress/e2e/login.cy.js[m
[36m@@ -0,0 +1,22 @@[m
[32m+[m[32mdescribe('Login Flow (CI Safe)', () => {[m
[32m+[m[32m  it('should login successfully', () => {[m
[32m+[m[32m    cy.intercept('POST', '**/login', {[m
[32m+[m[32m      statusCode: 200,[m
[32m+[m[32m      body: {[m
[32m+[m[32m        token: 'fake-token',[m
[32m+[m[32m        user: { email: 'qazqaz@qazqaz.com' },[m
[32m+[m[32m      },[m
[32m+[m[32m    }).as('login');[m
[32m+[m
[32m+[m[32m    cy.visit('http://localhost:5173/login');[m
[32m+[m
[32m+[m[32m    cy.get('input[placeholder="EMAIL"]').type('qazqaz@qazqaz.com');[m
[32m+[m[32m    cy.get('input[placeholder="KATA SANDI"]').type('qazqazqaz');[m
[32m+[m
[32m+[m[32m    cy.contains('Login').click();[m
[32m+[m
[32m+[m[32m    cy.wait('@login');[m
[32m+[m[32m    //fff[m
[32m+[m[32m    cy.location('pathname', { timeout: 10000 }).should('eq', '/');[m
[32m+[m[32m  });[m
[32m+[m[32m});[m
[1mdiff --git a/cypress/support/e2e.js b/cypress/support/e2e.js[m
[1mnew file mode 100644