---
title: How to Run Aspose.Slides in Docker
type: docs
weight: 140
url: /net/how-to-run-aspose-slides-in-docker/
keywords: "Running Aspose.Slides in Docker container, Aspose Docker, Aspose.Slides in a Docker"
description: "Run Aspose.Slides in a Docker container for Linux, Windows Server and any OS. "
---

## **Supported OS**
Aspose.Slides can run inside docker containers using .NET Core platform. In general, all container types (OS types) which are supported by .NET Core platform, are also supported by Aspose.Slides. However, the gdi or [libgdiplus ](https://github.com/mono/libgdiplus)should be available and correctly setup inside the container.

To use Docker, you must first install it into your system. Find how to install Docker on Windows or Mac by the following links:

- [Install Docker on Windows](https://docs.docker.com/docker-for-windows/install/)
- [Install Docker on Mac](https://docs.docker.com/docker-for-mac/install/)

It's also possible to run Docker on Linux and Windows Server by the following instructions:  

- [Install and configure Docker on Linux (apt-get libgdiplus) ](/slides/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/)
- [Install and configure Docker on Linux (make install libgdiplus)   ](/slides/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-make-install-libgdiplus/) 
- [Install and configure Docker on Windows Server Core ](/slides/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-windows-server-core/)  
- Install and configure Docker on Windows Server Nano is not Supported. Unfortunately, Windows Server Nano doesn't contain the graphic sub-system on board. It does not contain gdiplus.dll required by System.Drawing.Common library and can't be used with Aspose.Slides library.

Although it is possible to run Linux containers on Windows, it is preferable to run them natively on Linux (even a Linux installed manually on a VM using VirtualBox).

## **Install and configure Docker on Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

The following docker file contains instructions for building a container image with libgdiplus package installed from Ubuntu's official package repositories.

Content of a docker file is the following:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# install libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# create mount points

VOLUME /slides-src

\# build and test Aspose.Slides on start

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

``` 

Let's take a look what means each line of the docker file code:

1. Container's image is based on microsoft/dotnet:2.1-sdk-bionic image (the image already built by Microsoft and published on docker's [public hub](https://hub.docker.com/r/microsoft/dotnet/). This image will contain dotnet 2.1 SDK already installed. Bionic suffix tells that Ubuntu 18.04 (codename bionic) will be taken as a container's OS. By changing the suffix it is possible to change the underlying OS (for example: stretch -- Debian 9, alpine -- Alpine Linux). In that case, the docker file content modification can be required (for example change of 'apt-get' to 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

``` 

1. Updates database of available packages and install apt-utils package.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

``` 

1. Installs 'libgdiplus' and 'libc6-dev' packages required by System.Drawing.Common library.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

``` 

1. Declares /slides-src folder as a mounting point which we will be uses to provide access to slide-net sources folder on the host machine.

``` csharp

 VOLUME /slides-src

``` 

1. Sets slides-src as a working directory inside the container.

``` csharp

 WORKDIR /slides-src

``` 

1. Declares a default command which will be run on the container start in case if the explicit command is not specified.

``` csharp

 CMD ./build/netcore.linux.tests.sh

``` 

According to instructions in the docker file, the resulting container's image will have Ubuntu 18.04 OS, dotnet-sdk, libgdiplus and libc6-dev packages already installed. Also, this image will have a predefined mount point and predefined command on run.



To build an image using this docker file it is required to go to slides-netuil docker folder and execute:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

``` 

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- option specifies which docker file to use.

*-t ubuntu18_04_apt_get_libgdiplus* -- specifies tag (name) for the resulting image.

*'.'* -- specifies the context for docker. In our case the context is a current folder and it is empty, since we choose to provide slides-net sources as mounting point (this allows us not to rebuild docker image on each change in sources)



The result of the execution should be like:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

``` 



To ensure that the new image was added to local images repository:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

``` 



Once the image is ready we can run it using the command:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

``` 

*-it* -- species that command should be run interactively, allowing to see the output and capture the input.

*-v `pwd`/../../:/slides-src* -- specified the folder for the predefined mounting point. (since current working dir is slides-netuildockerthen slides-src folder in container will point to slides-net folder on the host. `pwd` is used to specify relative path).

*--add-host dev.slides.external.tool.server:192.168.1.48* -- modifies container's hosts file to resolve dev.slides.external.tool.server url.

*ubuntu1804aptgetlibgdiplus:latest* -- specifies the image to run container.



The result of the command above will be an output of netcore.linux.tests.sh (since it was defined as a default command for the container):

``` csharp

 Restoring packages for /slides-src/targets/.NETCore/tests/Aspose.Slides.FuncTests.NetCore/Aspose.Slides.FuncTests.NetCore.csproj...

Restoring packages for /slides-src/targets/.NETStandard/main/Aspose.Slides.DOM.NetStandard/Aspose.Slides.DOM.NetStandard.csproj...

Restoring packages for /slides-src/targets/.NETStandard/main/Aspose.Slides.CompoundFile.NetStandard/Aspose.Slides.CompoundFile.NetStandard.csproj...

Installing System.Text.Encoding.CodePages 4.4.0.

Installing System.Drawing.Common 4.5.0.

...

Results File: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.FuncTests.NetCore.trx

Total tests: Unknown. Passed: 2110. Failed: 108. Skipped: 210.

...

Results File: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.RegrTests.NetCore.trx

Total tests: 2124. Passed: 1550. Failed: 103. Skipped: 471.

``` 



From the result, it is clear that log files from Func and Regr tests were placed to /build-out/netstandard20/test-results/main/ directory. Also, there are total about 200 tests failed, all these are rendering issues related to required fonts absence on the container.

To override the default command of the container on a run, we could use the following command:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

``` 

So instead of netcore.linux.tests.sh the /bin/bash will be executed and will provide an active terminal session of a container from which it can be run (./build/netcore.linux.tests.sh). This approach can be useful for troubleshooting scenarios.
## **Install and configure Docker on Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

At the moment, Ubuntu contains only 4.2 version of libgdiplus while 5.6 version is already available on the [official site](https://github.com/mono/libgdiplus/releases). To test the latest version of libgdiplus, we need to prepare image with libgdiplus built from the sources.

Let's review the docker file content:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# build latest stable libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# create mount points

VOLUME /slides-src

\# build and test Aspose.Slides on start

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

``` 



The only difference is the *build latest stable libgdiplus* section. This section installs all necessary tools to build libgdiplus, clones sources and then builds them and installs it to the correct place. All the other is the same as in [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Note**: do not forget to use different image tag (name) for the resulting image on docker build and docker run commands:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

``` 


## **Install and configure Docker on Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Note**: Windows 10 Pro or Windows Server 2016 is required to run Windows containers.



Unfortunately, Microsoft does not provide Windows Server Core image with dotnet SDK installed, so we must install it manually:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Retrieve .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#return cmd as default executor

SHELL ["cmd", "/S", "/C"]

\# In order to set system PATH, ContainerAdministrator must be used

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# create mount points

VOLUME c:/slides-src

#build and test Aspose.Slides on start

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

``` 



The resulting image will be built over microsoft/windowsservercore:1803 image provided by the Microsoft on [docker hub](https://hub.docker.com/r/microsoft/windowsservercore/). Then dotnet-sdk of the specified version will be downloaded and unpacked, after that system's PATH variable will be updated to contain the path to dotnet executable. The last line defines the command which executes func & regr tests on the container using nant.exe as a default action on container run.

Command to build the image:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

``` 



Command to run the image:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

``` 

**Note**: the version of this command for Windows container uses 2 extra arguments:

*-cpu-count 3*

*-memory 8589934592*

They set the number of cores and amount of memory available for the container. By default, only 1 core and 1GB of RAM are available for the Windows container (Linux container's don't have any limitations by default).

Also, 1 argument is missed comparing to the same command we used to run Linux container:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Because container running on Windows just doesn't require external.tool.server.



The result of the command above will be like the following:

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] Deleting directory 'c:\slides-src\build-out\netcore20\test-results\'.

   [mkdir] Creating directory 'c:\slides-src\build-out\netcore20\test-results\'.

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] Total tests: 2338. Passed: 2115. Failed: 19. Skipped: 204.

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] Total tests: 2728. Passed: 2147. Failed: 110. Skipped: 471.

``` 
