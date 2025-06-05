import { useState } from "react";
import { createTask } from "../services/taskService";

const TaskForm = ({ onTaskAdded }: { onTaskAdded: () => void }) => {
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [status, setStatus] = useState("Pending");
    const [deadline, setDeadline] = useState("");

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await createTask({ title, description, status, deadline });
        setTitle("");
        setDescription("");
        setStatus("Pending");
        setDeadline("");
        onTaskAdded();
    };

    return (
        <div className="container mt-4">
            <div className="card p-4 shadow-sm">
                <h3 className="mb-3 text-center">Create New Task</h3>
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label className="form-label">Title</label>
                        <input type="text" className="form-control" placeholder="Enter title" value={title} onChange={(e) => setTitle(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="form-label">Description</label>
                        <textarea className="form-control" placeholder="Enter description" value={description} onChange={(e) => setDescription(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="form-label">Status</label>
                        <select className="form-select" value={status} onChange={(e) => setStatus(e.target.value)}>
                            <option value="Pending">Pending</option>
                            <option value="In Progress">In Progress</option>
                            <option value="Completed">Completed</option>
                        </select>
                    </div>

                    <div className="mb-3">
                        <label className="form-label">Deadline</label>
                        <input type="datetime-local" className="form-control" value={deadline} onChange={(e) => setDeadline(e.target.value)} />
                    </div>

                    <button type="submit" className="btn btn-primary w-100">Add Task</button>
                </form>
            </div>
        </div>
    );
};

export default TaskForm;
