import { useEffect, useState } from "react";
import { getTasks, deleteTask, updateTask } from "../services/taskService";

interface Task {
    id: number;
    title: string;
    description: string;
    status: string;
    deadline: string;
}

const TaskList = () => {
    const [tasks, setTasks] = useState<Task[]>([]);
    const [editingTask, setEditingTask] = useState<Task | null>(null);

    useEffect(() => {
        getTasks().then(setTasks);
    }, []);

    const handleDelete = async (id: number) => {
        await deleteTask(id);
        setTasks(tasks.filter(task => task.id !== id));
    };

    const handleEdit = (task: Task) => {
        setEditingTask(task);
    };

    const handleUpdate = async () => {
        if (!editingTask) return;
        await updateTask(editingTask.id, editingTask);
        setEditingTask(null);
        setTasks(await getTasks());
    };

    return (
        <div className="container mt-4">
            <h2 className="text-center">Task List</h2>
            <div className="row">
                {tasks.map((task) => (
                    <div key={task.id} className="col-md-6">
                        <div className="card p-3 mb-3 shadow-sm">
                            <h5>{task.title}</h5>
                            <p>{task.description}</p>
                            <p><strong>Status:</strong> {task.status}</p>
                            <p><strong>Deadline:</strong> {new Date(task.deadline).toLocaleString()}</p>
                            <div className="d-flex justify-content-between">
                                <button className="btn btn-warning btn-sm" onClick={() => handleEdit(task)}>Edit</button>
                                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(task.id)}>Delete</button>
                            </div>
                        </div>
                    </div>
                ))}
            </div>

            {editingTask && (
                <div className="card p-4 mt-4 shadow-sm">
                    <h3 className="mb-3">Editing Task</h3>
                    <input type="text" className="form-control mb-2" value={editingTask.title} onChange={(e) => setEditingTask({ ...editingTask, title: e.target.value })} />
                    <textarea className="form-control mb-2" value={editingTask.description} onChange={(e) => setEditingTask({ ...editingTask, description: e.target.value })} />
                    <select className="form-select mb-2" value={editingTask.status} onChange={(e) => setEditingTask({ ...editingTask, status: e.target.value })}>
                        <option value="Pending">Pending</option>
                        <option value="In Progress">In Progress</option>
                        <option value="Completed">Completed</option>
                    </select>
                    <input type="datetime-local" className="form-control mb-2" value={editingTask.deadline} onChange={(e) => setEditingTask({ ...editingTask, deadline: e.target.value })} />
                    <button className="btn btn-success w-100" onClick={handleUpdate}>Update Task</button>
                </div>
            )}
        </div>
    );
};

export default TaskList;
