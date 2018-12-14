# NodeJs_Redis
Redis Samples
<br />
<br />
Here you can find two .Net Core applications for testing some Redis features.
<br />
<strong>RedisSession</strong>:
<br />
It uses Redis as a session state manager, replacing the regular .Net In-Memory sessions (all session keys will be stored in Redis as hashes).
<br />
<br />
<br />
<strong>RedisApplication</strong>:
<br />
Insert some keys in Redis using 4 Redis different data types: string, hash, list and set.
<br />
These keys are visible to all sessions/users, being available in the entire application.
<br />
<br />

<hr>
<strong>Downloading Redis</strong>
<hr>
You can download Redis for Windows here:
<a href="https://github.com/MicrosoftArchive/redis/releases"></a>
<br />
Just unzip the file and use:
<br />
<strong>redis-server</strong> to start the server.
<br />
<strong>redis-cli</strong> to establish the connection.
<br />
<br />

To connect using a graphical user interface, there's a tool named Redis Desktop Manager.
<br />
At the minute this s a paid tool, but you can find it for free in the 'Tools' folder of this repo.
<br />
Note: Redis isn't officially supported on Windows.
<br />
To get always the last version of Redis, use Docker instead.
<br />


