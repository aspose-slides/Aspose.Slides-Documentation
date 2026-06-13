---
title: Docker에서 Aspose.Slides 실행하는 방법
linktitle: Docker에서 Aspose.Slides
type: docs
weight: 140
url: /ko/net/how-to-run-aspose-slides-in-docker/
keywords:
- 지원되는 OS
- Docker에서 Aspose.Slides
- Docker 컨테이너
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- 이미지 저장소
- Windows Server Core
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Docker 컨테이너에서 Aspose.Slides를 실행합니다: 이미지, 종속성, 폰트 및 라이선스를 구성하여 PowerPoint와 OpenDocument를 처리하는 확장 가능한 서비스를 구축합니다."
---
## **지원되는 OS**
Aspose.Slides는 .NET Core 플랫폼을 사용하여 Docker 컨테이너 내부에서 실행될 수 있습니다. 일반적으로 Aspose.Slides는 .NET Core 플랫폼이 지원하는 모든 컨테이너 유형(OS)을 지원합니다. 그러나 GDI 또는 [libgdiplus ](https://github.com/mono/libgdiplus) 가 컨테이너에 존재하고 올바르게 설정되어 있어야 합니다.

Docker를 사용하려면 먼저 시스템에 Docker를 설치해야 합니다. Windows 또는 Mac에 Docker를 설치하는 방법을 배우려면 다음 링크를 사용하십시오:

- [Windows에 Docker 설치](https://docs.docker.com/docker-for-windows/install/)
- [Mac에 Docker 설치](https://docs.docker.com/docker-for-mac/install/)

다음 페이지의 지침을 따라 Linux 및 Windows Server에서도 Docker를 실행할 수 있습니다:

- [Linux에서 Docker 설치 및 구성 (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Linux에서 Docker 설치 및 구성 (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Windows Server Core에서 Docker 설치 및 구성](#install-and-configure-docker-on-windows-server-core)

Windows Server Nano에서 Docker의 설치 및 구성은 지원되지 않습니다. 안타깝게도 Windows Server Nano에는 그래픽 하위 시스템이 포함되어 있지 않습니다. System.Drawing.Common 라이브러리가 필요로 하는 gdiplus.dll가 없으며, 따라서 Aspose.Slides 라이브러리와 함께 사용할 수 없습니다.

Linux 컨테이너를 Windows에서 실행할 수는 하지만, Linux에서 네이티브로 실행하는 것을 권장합니다(심지어 VirtualBox를 사용해 VM에 수동으로 설치된 Linux에서도 마찬가지입니다).

## **Linux에 Docker 설치 및 구성 (apt-get libgdiplus)**
- 운영 체제: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

이 Dockerfile은 Ubuntu 공식 패키지 저장소에서 libgdiplus 패키지를 설치한 컨테이너 이미지를 빌드하기 위한 지침을 포함하고 있습니다.

다음은 Dockerfile 내용입니다:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus 설치

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# 마운트 포인트 생성

VOLUME /slides-src

\# 시작 시 Aspose.Slides 빌드 및 테스트

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Docker 파일의 각 코드 라인이 의미하는 바를 살펴보겠습니다:

1. 컨테이너 이미지가 microsoft/dotnet:2.1-sdk-bionic 이미지에 기반합니다(이 이미지는 Microsoft에서 이미 빌드되어 Docker의 [public hub](https://hub.docker.com/r/microsoft/dotnet/)에 게시되었습니다). 이 이미지에는 이미 설치된 dotnet 2.1 SDK가 포함되어 있습니다. Bionic 접미사는 Ubuntu 18.04(코드명 bionic)를 컨테이너의 OS로 사용한다는 의미입니다. 접미사를 변경하면 기본 OS를 바꿀 수 있습니다(예: stretch — Debian 9, alpine — Alpine Linux). 이 경우 Dockerfile 내용을 수정해야 합니다(예: 'apt-get'을 'yum'으로 변경).

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. 사용 가능한 패키지 데이터베이스를 업데이트하고 apt-utils 패키지를 설치합니다.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. 'System.Drawing.Common' 라이브러리에 필요한 'libgdiplus'와 'libc6-dev' 패키지를 설치합니다.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. /slides-src 폴더를 마운트 지점으로 선언합니다. 이를 통해 호스트 머신의 slide-net 소스 폴더에 접근할 수 있게 됩니다.

``` csharp

 VOLUME /slides-src

```

1. slides-src를 컨테이너 내부의 작업 디렉터리로 설정합니다.

``` csharp

 WORKDIR /slides-src

```

1. 명시적인 명령이 지정되지 않은 경우 컨테이너 시작 시 실행될 기본 명령을 선언합니다.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Dockerfile의 지침에 따라 생성된 컨테이너 이미지에는 Ubuntu 18.04 OS, dotnet-sdk, libgdiplus 및 libc6-dev 패키지가 이미 설치됩니다. 또한 이 이미지에는 미리 정의된 마운트 지점과 실행 시 미리 정의된 명령이 포함됩니다.

이 Dockerfile을 사용해 이미지를 빌드하려면 slides-netuil Docker 폴더로 이동한 뒤 다음을 실행하십시오:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- 사용할 Dockerfile을 지정합니다.  
*-t ubuntu18_04_apt_get_libgdiplus* -- 생성된 이미지의 태그(이름)를 지정합니다.  
*'.'* -- Docker 컨텍스트를 지정합니다. 여기서는 현재 폴더가 컨텍스트이며 비어 있습니다—slides-net 소스를 마운트 지점으로 제공하기 때문에 소스가 변경될 때마다 Docker 이미지를 다시 빌드할 필요가 없습니다.

The result of the execution should look like this:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

To ensure that the new image was added to the local images repository:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Once the image is ready, we can run it using this command:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- 명령을 대화형으로 실행하도록 지정합니다. 이를 통해 출력이 표시되고 입력을 받을 수 있습니다.  
*-v `pwd`/../../:/slides-src* -- 미리 정의된 마운트 지점을 위한 폴더를 지정합니다. 현재 작업 디렉터리가 slides-netuildocker이므로 컨테이너 내 slides-src 폴더는 호스트의 slides-net 폴더를 가리키게 됩니다. `pwd`는 상대 경로를 지정하는 데 사용됩니다.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- 컨테이너의 hosts 파일을 수정하여 dev.slides.external.tool.server URL을 해결합니다.  
*ubuntu1804aptgetlibgdiplus:latest* -- 실행할 컨테이너 이미지를 지정합니다.

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

결과에서 Func 및 Regr 테스트의 로그 파일이 /build-out/netstandard20/test-results/main/ 디렉터리에 배치된 것을 확인할 수 있습니다. 또한 전체 약 200개의 테스트가 실패했으며, 이는 모두 컨테이너에 필수 폰트가 없어서 발생한 렌더링 문제입니다.

To override the default command of the container on a run, we could use this command:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

따라서 netcore.linux.tests.sh 대신 /bin/bash가 실행되어 컨테이너 내부에서 활성 터미널 세션을 제공하고, 여기서 (./build/netcore.linux.tests.sh)와 같이 명령을 실행할 수 있습니다. 이 방법은 문제 해결 시 유용할 수 있습니다.

## **Linux에 Docker 설치 및 구성 (make install libgdiplus)**
- 운영 체제: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

현재 Ubuntu에는 libgdiplus 4.2 버전만 포함되어 있지만, 제품의 [official site](https://github.com/mono/libgdiplus/releases)에서는 5.6 버전이 이미 제공되고 있습니다. 최신 버전의 libgdiplus를 테스트하려면 소스에서 빌드한 libgdiplus 이미지가 필요합니다.

Let's review the docker file content:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 최신 안정 버전 libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# 마운트 포인트 생성

VOLUME /slides-src

\# 시작 시 Aspose.Slides 빌드 및 테스트

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

유일한 차이점은 *build latest stable libgdiplus* 섹션입니다. 이 섹션은 libgdiplus를 빌드하기 위한 모든 필요한 도구를 설치하고, 소스를 복제한 뒤 빌드하여 적절한 위치에 설치합니다. 나머지는 [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/ko/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/)와 동일합니다.

**Note**: Do not forget to use different image tags (name) for the resulting image on docker build and docker run commands:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Windows Server Core에 Docker 설치 및 구성**
- 운영 체제: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Note**: Windows 10 Pro 또는 Windows Server 2016이 필요합니다.

Unfortunately, Microsoft does not provide Windows Server Core image with the dotnet SDK installed, so we have to install it manually:

``` csharp

 # escape=
FROM microsoft/windowsservercore:1803 AS installer-env
#set powershell 기본 실행기
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# escape=
FROM microsoft/windowsservercore:1803 AS installer-env
#set powershell 기본 실행기
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# .NET Core SDK 가져오기
ENV DOTNET_SDK_VERSION 2.1.301
ENV DOTNET_PATH "c:/Program Files/dotnet"
RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 
    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 
    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 
        exit 1; 
    }; 
    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;
#cmd를 기본 실행기로 반환
SHELL ["cmd", "/S", "/C"]
\# 시스템 PATH를 설정하려면 ContainerAdministrator를 사용해야 합니다
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"
USER ContainerUser
\# 마운트 포인트 생성
VOLUME c:/slides-src
#시작 시 Aspose.Slides 빌드 및 테스트
WORKDIR c:/slides-src
CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

생성된 이미지는 Microsoft가 [docker hub](https://hub.docker.com/u/microsoft)에서 제공하는 microsoft/windowsservercore:1803 이미지를 기반으로 구축됩니다. 지정된 버전의 dotnet-sdk가 다운로드되어 압축이 풀리며, 시스템 PATH 변수에 dotnet 실행 파일 경로가 추가됩니다. 마지막 줄은 nant.exe를 기본 동작으로 사용하여 컨테이너에서 func 및 regr 테스트를 실행하는 명령을 정의합니다.

Command to build the image:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Command to run the image:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Note**: The command for Windows container uses 2 extra arguments:
*-cpu-count 3*
*-memory 8589934592*
이들은 컨테이너에 할당되는 코어 수와 메모리 양을 설정합니다. 기본적으로 Windows 컨테이너는 1개의 코어와 1GB RAM만 사용할 수 있습니다(Linux 컨테이너는 기본 제한이 없습니다).

Also, 1 argument is missed comparing to the same command we used to run the Linux container:
*-add-host dev.slides.external.tool.server:192.168.1.48*
Windows에서 실행되는 컨테이너는 external.tool.server가 필요하지 않기 때문에 이 인수가 누락되었습니다.

The result of the command above should look like this:

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