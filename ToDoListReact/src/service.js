import apiClient from './serverAxios';

const taskService = {
  getTasks: () => {
    return apiClient.get('/item')
      .then(response => response.data)
      .catch(error => {
        console.error('Error fetching tasks:', error);
        return [];
      });
  },

  addTask: (name) => {
    return apiClient.post('/item', name )
      .then(response => {
        if (response.status === 200) {
          console.log('Task added successfully');
          return response.data;
        }
      })
      .catch(error => {
        console.error('Error adding task:', error);
        return null; // Return null or appropriate value on error
      });
  },

  setCompleted: (id, isComplete) => {
    return apiClient.put(`/item/${id}`, isComplete )
      .then(response => {
        console.log('Task completion status updated:', { id, isComplete });
        return response.data;
      })
      .catch(error => {
        console.error('Error updating task status:', error);
        return null; // Return null or appropriate value on error
      });
  },

  deleteTask: (id) => {
    return apiClient.delete(`/item/${id}`)
      .then(() => {
        console.log('Task deleted successfully');
      })
      .catch(error => {
        console.error('Error deleting task:', error);
      });
  },
};

export default taskService;