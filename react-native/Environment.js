const ENV = {
  dev: {
    apiUrl: 'http://localhost:44360',
    oAuthConfig: {
      issuer: 'http://localhost:44360',
      clientId: 'Abp_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access Abp',
    },
    localization: {
      defaultResourceName: 'Abp',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44360',
    oAuthConfig: {
      issuer: 'http://localhost:44360',
      clientId: 'Abp_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access Abp',
    },
    localization: {
      defaultResourceName: 'Abp',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
