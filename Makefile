start:
	systemctl start kestrel-dotnetlive-forums.service

stop:
	systemctl stop kestrel-dotnetlive-forums.service

delete_current_build:
	rm -rf /var/dotnetlive/pubsite/dotnetlive.forums/

publish:
	git clean -df
	git pull
	dotnet restore src/DotNetLive.ForumsWeb.sln 
	cd src/DotNetLive.ForumsWeb && npm install && bower install --allow-root && gulp default
	dotnet publish src/DotNetLive.ForumsWeb/DotNetLive.ForumsWeb.csproj -c "Release" -o /var/dotnetlive/pubsite/dotnetlive.forums/ 

deploy: stop publish start
