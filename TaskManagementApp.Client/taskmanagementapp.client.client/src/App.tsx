import { useState } from 'react';
import './App.css';
import TaskList from "./components/TaskList";
import TaskForm from "./components/TaskForm";
import "bootstrap/dist/css/bootstrap.min.css";

const App = () => {
    const [refresh, setRefresh] = useState(false);

    return (
        <div>
            <TaskForm onTaskAdded={() => setRefresh(!refresh)} />
            <TaskList key={refresh ? 1 : 0} />
        </div>
    );
};

export default App;