---
title: 如何在 Docker 中运行 Aspose.Slides
linktitle: Aspose.Slides 在 Docker 中
type: docs
weight: 140
url: /zh/net/how-to-run-aspose-slides-in-docker/
keywords:
- 支持的操作系统
- Docker 中的 Aspose.Slides
- Docker 容器
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- 镜像仓库
- Windows Server Core
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Docker 容器中运行 Aspose.Slides：配置镜像、依赖项、字体和许可，以构建可扩展的服务，处理 PowerPoint 和 OpenDocument。"
---

## **Supported OS**
Aspose.Slides 可以在 Docker 容器中基于 .NET Core 平台运行。一般来说，Aspose.Slides 支持 .NET Core 平台支持的所有容器（操作系统）类型。不过，容器中必须可用并正确配置 GDI 或 [libgdiplus](https://github.com/mono/libgdiplus)。

要使用 Docker，首先需要在系统上安装它。了解在 Windows 或 Mac 上安装 Docker 的方法，请使用以下链接：

- [在 Windows 上安装 Docker](https://docs.docker.com/docker-for-windows/install/)
- [在 Mac 上安装 Docker](https://docs.docker.com/docker-for-mac/install/)

您也可以按照以下页面的说明在 Linux 和 Windows Server 上运行 Docker：

- [在 Linux 上安装和配置 Docker（apt-get libgdiplus）](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [在 Linux 上安装和配置 Docker（make install libgdiplus）](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [在 Windows Server Core 上安装和配置 Docker](#install-and-configure-docker-on-windows-server-core)

  不支持在 Windows Server Nano 上安装和配置 Docker。遗憾的是，Windows Server Nano 不包含图形子系统，也没有 System.Drawing.Common 所需的 gdiplus.dll，无法与 Aspose.Slides 库一起使用。

虽然可以在 Windows 中运行 Linux 容器，但我们建议在 Linux 上本地运行（即使是在使用 VirtualBox 的虚拟机中手动安装的 Linux）。

## **Installing and Configuring Docker on Linux (apt-get libgdiplus)**
- OS：Ubuntu 18.04。
- Dockerfile：Dockerfile-Ubuntu18_04_apt_get_libgdiplus

此 Dockerfile 包含从 Ubuntu 官方软件仓库安装 libgdiplus 包的指令，用于构建容器镜像。

以下是 Dockerfile 内容：
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 安装 libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# 创建挂载点

VOLUME /slides-src

\# 启动时构建并测试 Aspose.Slides

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


让我们逐行解释 Dockerfile 中的代码含义：

1. 容器镜像基于 microsoft/dotnet:2.1-sdk-bionic 镜像（该镜像已由 Microsoft 构建并发布在 Docker 的[公共仓库](https://hub.docker.com/r/microsoft/dotnet/)）。此镜像已预装 dotnet 2.1 SDK。Bionic 后缀表示使用 Ubuntu 18.04（代号 bionic）作为容器的操作系统。通过更改后缀，可以切换底层 OS（例如：stretch → Debian 9，alpine → Alpine Linux）。此时需相应修改 Dockerfile 内容（例如，将 `apt-get` 改为 `yum`）。
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:
```


1. 更新可用软件包数据库并安装 apt-utils 包。
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. 安装 System.Drawing.Common 所需的 `libgdiplus` 和 `libc6-dev` 包。
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. 声明 `/slides-src` 文件夹为挂载点，以便提供对主机上 slides‑net 源代码文件夹的访问。
``` csharp

 VOLUME /slides-src

```


1. 将 `/slides-src` 设置为容器内的工作目录。
``` csharp

 WORKDIR /slides-src

```


1. 声明默认命令，在未指定显式命令时容器启动时将执行该命令。
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


按照 Dockerfile 中的指令，生成的容器镜像将包含 Ubuntu 18.04、dotnet‑sdk、libgdiplus 和 libc6‑dev 包，还预定义了挂载点和运行时默认命令。

要使用此 Dockerfile 构建镜像，请进入 `slides-netuil` Docker 文件夹并执行：
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*`-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus`* — 指定使用的 Dockerfile。  
*`-t ubuntu18_04_apt_get_libgdiplus`* — 为生成的镜像指定标签（名称）。  
*`.`* — 指定 Docker 的构建上下文，此处为当前文件夹（空目录），因为我们将 slides‑net 源代码作为挂载点提供，从而在每次修改源代码时无需重新构建镜像。

执行结果应如下所示：
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


验证新镜像已添加到本地镜像仓库：
``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


镜像构建完成后，可使用以下命令运行它：
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*`-it`* — 交互式运行容器，以便看到输出并接受输入。  
*`-v \`pwd\`/../../:/slides-src`* — 指定预定义挂载点的宿主机文件夹——当前工作目录是 `slides-netuildocker`，因此容器内的 `/slides-src` 将指向宿主机上的 `slides-net` 文件夹。`\`pwd\`` 用于获取相对路径。  
*`--add-host dev.slides.external.tool.server:192.168.1.48`* — 修改容器的 hosts 文件，以解析 `dev.slides.external.tool.server`。  
*`ubuntu1804aptgetlibgdiplus:latest`* — 指定要运行的镜像。

上述命令执行后，将看到 `netcore.linux.tests.sh` 的输出（因为它被设为容器的默认命令）：
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


从结果可知，Func 和 Regr 测试的日志已输出至 `/build-out/netstandard20/test-results/main/` 目录。此外，共约 200 条测试失败，均为由于容器缺少必需字体导致的渲染问题。

如果想在运行时覆盖容器的默认命令，可使用以下方式：
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


这样，将执行 `/bin/bash`，并提供容器的交互终端，您可以手动运行 `./build/netcore.linux.tests.sh` 等命令，便于排查问题。

## **Installing and Configuring Docker on Linux (make install libgdiplus)**
- OS：Ubuntu 18.04。
- Dockerfile：Dockerfile-Ubuntu18_04_make_libgdiplus

目前 Ubuntu 官方仅提供 4.2 版 libgdiplus，而 5.6 版已在产品的[官方站点](https://github.com/mono/libgdiplus/releases)上发布。要测试最新版 libgdiplus，需要构建一个从源码编译的镜像。

以下是 Dockerfile 内容：
``` csharp
 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 构建最新稳定版 libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# 创建挂载点

VOLUME /slides-src

\# 启动时构建并测试 Aspose.Slides

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh
```


唯一的区别在于 *build latest stable libgdiplus* 部分。该部分会安装构建 libgdiplus 所需的全部工具，克隆源码并编译安装。其余内容与[在 Linux 上安装和配置 Docker（apt-get libgdiplus）](/slides/zh/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/)完全相同。

**注意**：在 `docker build` 和 `docker run` 命令中，请使用不同的镜像标签（名称）：
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Install and configure Docker on Windows Server Core**
- OS：Ubuntu 18.04。
- Dockerfile：Dockerfile*WinServerCore*

**注意**：需要 Windows 10 Pro 或 Windows Server 2016 才能运行 Windows 容器。

遗憾的是，Microsoft 未提供已预装 dotnet SDK 的 Windows Server Core 镜像，需要手动安装：
``` csharp
 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor
#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor
#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Retrieve .NET Core SDK
# 检索 .NET Core SDK

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
# 将 cmd 设为默认执行器

SHELL ["cmd", "/S", "/C"]

\# In order to set system PATH, ContainerAdministrator must be used
# 为了设置系统 PATH，必须使用 ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# create mount points
# 创建挂载点

VOLUME c:/slides-src

#build and test Aspose.Slides on start
# 启动时构建并测试 Aspose.Slides

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


生成的镜像基于 Microsoft 在[docker hub](https://hub.docker.com/r/microsoft/windowsservercore/)上提供的 `microsoft/windowsservercore:1803` 镜像。指定版本的 dotnet‑sdk 将被下载并解压，系统的 PATH 变量会更新以包含 dotnet 可执行文件的路径。最后一行定义了容器启动时默认执行的命令，即使用 `nant.exe` 运行 func 和 regr 测试。

构建镜像的命令：
``` csharp
docker build -f Dockerfile_WinServerCore -t winservercore_slides .
```


运行镜像的命令：
``` csharp
 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest
```


**注意**：Windows 容器的运行命令额外使用了 2 个参数：

*`-cpu-count 3`*  
*`-memory 8589934592`*

它们分别设置容器可使用的 CPU 核心数和内存大小。默认情况下，Windows 容器仅提供 1 核心和 1 GB 内存（而 Linux 容器默认没有此类限制）。

与运行 Linux 容器的命令相比，缺少了以下参数：

*`-add-host dev.slides.external.tool.server:192.168.1.48`*

因为 Windows 容器不需要 `external.tool.server`。

上述命令的执行结果应类似于：
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
