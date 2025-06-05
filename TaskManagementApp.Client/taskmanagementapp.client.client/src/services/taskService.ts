import axios from "axios";

const API_BASE_URL = "https://localhost:7184/api/Tasks"; // Adjust URL based on your API

export const getTasks = async () => {
    const response = await axios.get(API_BASE_URL);
    return response.data;
};

export const createTask = async (task: { title: string; description: string, status: string, deadline:string }) => {
    const response = await axios.post(API_BASE_URL, task);
    return response.data;
};

export const updateTask = async (id: number, updatedTask: { title: string; description: string; status: string; deadline: string }) => {
    const response = await axios.put(`${API_BASE_URL}/${id}`, updatedTask);
    return response.data;
};

export const deleteTask = async (id: number) => {
    await axios.delete(`${API_BASE_URL}/${id}`);
};
