# Redis Samples

<br />
Here you can find two .Net Core applications for testing some Redis features.
<br />
<br />
<strong>RedisSession</strong>:
<br />
It uses Redis as a session state manager, replacing the regular .Net In-Memory sessions (all session keys will be stored in Redis as hashes).
<br />
<br />
<strong>RedisApplication</strong>:
<br />
Insert some keys in Redis using 4 Redis different data types: string, hash, list and set.
<br />
These keys are visible to all sessions/users, being available in the entire application.
<br />
<br />
<br />

<hr>
<strong>Downloading Redis</strong>
<hr>
You can download Redis for Windows here:
<br />
<a href="https://github.com/MicrosoftArchive/redis/releases">MicrosoftArchive</a>
<br />
<br />
Just unzip the file and use:
<br />
<br />
<strong>redis-server</strong> to start the server.
<br />
<strong>redis-cli</strong> to establish the connection.
<br />
<br />

To connect using a graphical user interface, there's a tool named <strong>Redis Desktop Manager</strong>.
<br />
At the minute this is a paid tool, but you can find it for free in the <strong>'Tools'</strong> folder of this repo.
<br />
Note: Redis isn't officially supported on Windows.
<br />
To get always the latest version of Redis, use Docker instead.
<br />
<br />
For further documentation please visit the <a href="https://redis.io/">Redis Official website</a>



