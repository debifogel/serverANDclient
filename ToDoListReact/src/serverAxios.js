import axios from 'axios';

// Create an Axios instance
const apiClient = axios.create({
    baseURL: 'http://localhost:5163', 
    timeout: 4000, 
    headers: {
        'Content-Type': 'application/json'
    }
});

export default apiClient;