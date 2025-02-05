import axios from 'axios';

// Create an Axios instance
const apiClient = axios.create({
    baseURL: process.env.REACT_APP_URL, 
    timeout: 4000, 
    headers: {
        'Content-Type': 'application/json'
    }
});

export default apiClient;