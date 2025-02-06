import renderApi from '@api/render-api';

renderApi.auth('rnd_inwbYa4TRKXbbyBJKMYG2BFH2ylY');
renderApi.listServices({includePreviews: 'true', limit: '20'})
  .then(({ data }) => console.log(data))
  .catch(err => console.error(err));
  