---
title: 如何在Docker中运行Aspose.Slides
type: docs
weight: 140
url: /zh/net/how-to-run-aspose-slides-in-docker/
keywords: "在Docker容器中运行Aspose.Slides, Aspose Docker, 在Docker中使用Aspose.Slides"
description: "在Linux、Windows Server及任何操作系统的Docker容器中运行Aspose.Slides。"
---

## **支持的操作系统**
Aspose.Slides可以在使用.NET Core平台的docker容器中运行。一般而言，Aspose.Slides支持所有.NET Core平台支持的容器类型（操作系统）。但是，GDI或[libgdiplus](https://github.com/mono/libgdiplus)必须在相关容器中可用并正确设置。

要使用Docker，您必须先在系统上安装它。要了解如何在Windows或Mac上安装Docker，请使用以下链接：

- [在Windows上安装Docker](https://docs.docker.com/docker-for-windows/install/)
- [在Mac上安装Docker](https://docs.docker.com/docker-for-mac/install/)

您还可以按照以下页面上的说明在Linux和Windows Server上运行Docker：

- [在Linux上安装和配置Docker（apt-get libgdiplus）](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [在Linux上安装和配置Docker（make install libgdiplus）](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [在Windows Server Core上安装和配置Docker](#install-and-configure-docker-on-windows-server-core)

不支持在Windows Server Nano上安装和配置Docker。不幸的是，Windows Server Nano不包含图形子系统。它不包含System.Drawing.Common库所需的gdiplus.dll，因此无法与Aspose.Slides库一起使用。

虽然可以在Windows中运行Linux容器，但我们建议您在Linux上原生运行它们（即使是在使用VirtualBox手动安装的虚拟机上）。

## **在Linux上安装和配置Docker（apt-get libgdiplus）**
- 操作系统：Ubuntu 18.04。
- Dockerfile：Dockerfile-Ubuntu18_04_apt_get_libgdiplus

此docker文件包含从Ubuntu的官方软件包库安装libgdiplus包的生成容器映像的说明。

以下是docker文件内容：

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 安装libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# 创建挂载点

VOLUME /slides-src

\# 启动时构建和测试Aspose.Slides

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

让我们审查docker文件中每行代码的含义：

1. 容器的映像基于microsoft/dotnet:2.1-sdk-bionic映像（这是由Microsoft预先构建并发布在docker的[公共中心](https://hub.docker.com/r/microsoft/dotnet/)的映像）。此映像已安装dotnet 2.1 SDK。Bionic后缀意味着使用Ubuntu 18.04（代号bionic）作为容器的操作系统。通过更改后缀，可以更改基础操作系统（例如：stretch -- Debian 9，alpine -- Alpine Linux）。在这种情况下，将需要修改docker文件内容（例如，将'apt-get'更改为'yum'）。

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. 更新可用软件包数据库并安装apt-utils软件包。

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. 安装System.Drawing.Common库所需的'libgdiplus'和'libc6-dev'软件包。

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. 声明/slides-src文件夹作为挂载点，我们将用它来提供对主机上slide-net源文件夹的访问。

``` csharp

 VOLUME /slides-src

```

1. 将slides-src设置为容器内部的工作目录。

``` csharp

 WORKDIR /slides-src

```

1. 声明一个默认命令，在容器启动时运行，除非指定了显式命令。

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

根据docker文件中的说明，生成的容器映像将具有已安装的Ubuntu 18.04操作系统、dotnet-sdk、libgdiplus和libc6-dev软件包。此外，此映像将具有预定义挂载点和预定义的运行命令。

要使用此docker文件构建映像，您必须进入slides-netuil docker文件夹并执行：

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- 选项指定要使用哪个docker文件。

*-t ubuntu18_04_apt_get_libgdiplus* -- 为生成的映像指定标签（名称）。

*'.'* -- 指定docker的上下文。在我们的例子中，上下文是当前文件夹并且是空的——因为我们选择将slides-net源提供为挂载点（这使我们无需在每次源更改时重新构建docker映像）。

执行的结果应如下所示：

``` csharp

 成功构建 62dd34ddc142

成功标记 ubuntu18_04_apt_get_libgdiplus:latest

```

为了确保新映像已添加到本地映像库：

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

一旦映像准备好，我们可以使用以下命令运行它：

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- 指定命令应以交互方式运行，使我们可以看到输出并捕获输入。

*-v `pwd`/../../:/slides-src* -- 指定了预定义挂载点的文件夹——由于当前工作目录是slides-netuildocker，因此容器中的slides-src文件夹将指向主机上的slides-net文件夹。`pwd`用于指定相对路径。

*--add-host dev.slides.external.tool.server:192.168.1.48* -- 修改容器的hosts文件以解析dev.slides.external.tool.server网址。

*ubuntu1804aptgetlibgdiplus:latest* -- 指定要运行的容器的映像。

执行上述命令的结果将是netcore.linux.tests.sh的输出（由于它已定义为容器的默认命令）：

``` csharp

 正在还原/slides-src/targets/.NETCore/tests/Aspose.Slides.FuncTests.NetCore/Aspose.Slides.FuncTests.NetCore.csproj的包...

正在还原/slides-src/targets/.NETStandard/main/Aspose.Slides.DOM.NetStandard/Aspose.Slides.DOM.NetStandard.csproj的包...

正在还原/slides-src/targets/.NETStandard/main/Aspose.Slides.CompoundFile.NetStandard/Aspose.Slides.CompoundFile.NetStandard.csproj的包...

正在安装System.Text.Encoding.CodePages 4.4.0。

正在安装System.Drawing.Common 4.5.0。

...

结果文件：/slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.FuncTests.NetCore.trx

总测试：未知。通过：2110。失败：108。跳过：210。

...

结果文件：/slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.RegrTests.NetCore.trx

总测试：2124。通过：1550。失败：103。跳过：471。

```

从结果来看，Func和Regr测试的日志文件已放置到/build-out/netstandard20/test-results/main/目录中。此外，约200个测试总失败——这些都是与所需字体在容器中缺失有关的渲染问题。

要覆盖容器的默认命令并运行，我们可以使用此命令：

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

因此，/bin/bash将被执行，而不是netcore.linux.tests.sh，并将提供一个活动的容器终端会话，从中可以运行（./build/netcore.linux.tests.sh）。这种方法在故障排除场景中可能很有用。
## **在Linux上安装和配置Docker（make install libgdiplus）**
- 操作系统：Ubuntu 18.04。
- Dockerfile：Dockerfile-Ubuntu18_04_make_libgdiplus

目前，Ubuntu仅包含libgdiplus的版本4.2，而产品的[官方网站](https://github.com/mono/libgdiplus/releases)上已经提供了5.6版。要测试最新版本的libgdiplus，我们需要准备一个从源代码构建的libgdiplus映像。

让我们审查docker文件内容：

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 构建最新稳定版的libgdiplus

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

\# 启动时构建和测试Aspose.Slides

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

唯一的区别是*构建最新稳定版的libgdiplus*部分。此部分安装了构建libgdiplus所需的所有工具，克隆源代码，然后构建并安装到正确的位置。其他内容与[在Linux上安装和配置Docker（apt-get libgdiplus）](/slides/zh/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/)相同。

**注意**：请记得在docker build和docker run命令中为生成的映像使用不同的映像标签（名称）：

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **在Windows Server Core上安装和配置Docker**
- 操作系统：Ubuntu 18.04。
- Dockerfile：Dockerfile*WinServerCore*

**注意**：运行Windows容器需要Windows 10 Pro或Windows Server 2016。

不幸的是，Microsoft没有提供带有已安装dotnet SDK的Windows Server Core映像，因此我们必须手动安装：

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell默认执行器

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell默认执行器

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# 获取 .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host '校验和验证失败！'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#返回cmd作为默认执行器

SHELL ["cmd", "/S", "/C"]

\# 为了设置系统PATH，必须使用ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# 创建挂载点

VOLUME c:/slides-src

#在启动时构建和测试Aspose.Slides

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

生成的映像将建立在Microsoft提供的microsoft/windowsservercore:1803映像之上，位于[docker hub](https://hub.docker.com/r/microsoft/windowsservercore/)上。指定版本的dotnet-sdk将被下载并解压；系统的PATH变量将更新以包含dotnet可执行文件的路径。最后一行定义了在容器运行时使用nant.exe执行func和regr测试的命令。

构建映像的命令：

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

运行映像的命令：

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**注意**：Windows容器的命令使用了2个额外参数：

*-cpu-count 3*

*-memory 8589934592*

它们设置容器可用的核心数和内存量。默认情况下，Windows容器仅提供1个核心和1GB的RAM（Linux容器默认没有任何限制）。

此外，相比于我们用来运行Linux容器的相同命令，少了1个参数：

*-add-host dev.slides.external.tool.server:192.168.1.48*

因为运行在Windows上的容器不需要外部工具服务器。

上述命令的结果应如下所示：

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] 正在删除目录'c:\slides-src\build-out\netcore20\test-results\'。

   [mkdir] 正在创建目录'c:\slides-src\build-out\netcore20\test-results\'。

...

[exec] 结果文件：C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] 总测试：2338。通过：2115。失败：19。跳过：204。

...

[exec] 结果文件：C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] 总测试：2728。通过：2147。失败：110。跳过：471。

```