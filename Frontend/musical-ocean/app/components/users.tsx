import { Card } from "antd";

interface Props {
    users: User[]
}

export const Users = ({users}: Props) => {
    return (
        <div className="cards">
            {users.map((user : User) => (
                <Card></Card>
            ))}
        </div>
    );
}
