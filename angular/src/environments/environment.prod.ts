import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Abp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44360',
    redirectUri: baseUrl,
    clientId: 'Abp_App',
    responseType: 'code',
    scope: 'offline_access Abp',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44360',
      rootNamespace: 'Dna.Abp',
    },
  },
} as Environment;
