---
title: 在 Docker 中執行 Aspose.Slides 的方法
linktitle: Aspose.Slides 在 Docker 中
type: docs
weight: 140
url: /zh-hant/net/how-to-run-aspose-slides-in-docker/
keywords:
- 支援的作業系統
- Aspose.Slides 在 Docker 中
- Docker 容器
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- 映像倉庫
- Windows Server Core
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Docker 容器中執行 Aspose.Slides：配置映像、相依性、字型與授權，以建構可擴充的服務，處理 PowerPoint 與 OpenDocument。"
---
## **支援的作業系統**
Aspose.Slides 可以在使用 .NET Core 平台的 Docker 容器中執行。一般而言，Aspose.Slides 支援 .NET Core 平台所支援的所有容器類型（作業系統）。然而，必須在相關容器中提供 GDI 或 [libgdiplus](https://github.com/mono/libgdiplus) 並正確設定。

若要使用 Docker，必須先在您的系統上安裝它。若要了解如何在 Windows 或 Mac 上安裝 Docker，請使用以下連結：

- [在 Windows 上安裝 Docker](https://docs.docker.com/docker-for-windows/install/)
- [在 Mac 上安裝 Docker](https://docs.docker.com/docker-for-mac/install/)

您也可以依照以下頁面上的說明，在 Linux 和 Windows Server 上執行 Docker：

- [在 Linux 上安裝與設定 Docker (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [在 Linux 上安裝與設定 Docker (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [在 Windows Server Core 上安裝與設定 Docker](#install-and-configure-docker-on-windows-server-core)

不支援在 Windows Server Nano 上安裝與設定 Docker。遺憾的是，Windows Server Nano 未內建圖形子系統。它缺少 System.Drawing.Common 函式庫所需的 gdiplus.dll，因而無法與 Aspose.Slides 函式庫一起使用。

雖然可以在 Windows 上執行 Linux 容器，我們建議直接在 Linux 上原生執行（即使是在使用 VirtualBox 手動安裝於虛擬機器的 Linux 上）。

## **在 Linux 上安裝與設定 Docker (apt-get libgdiplus)**
- 作業系統：Ubuntu 18.04。
- Dockerfile：Dockerfile-Ubuntu18_04_apt_get_libgdiplus

此 Dockerfile 包含從 Ubuntu 官方套件倉儲安裝 libgdiplus 套件以建立容器映像的指令。

以下是 Dockerfile 內容：

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 安裝 libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# 建立掛載點

VOLUME /slides-src

\# 建置並測試 Aspose.Slides 于啟動時

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

讓我們檢視 Dockerfile 中每一行程式碼的意義：

1. 此容器映像是基於 microsoft/dotnet:2.1-sdk-bionic 映像（該映像已由 Microsoft 建置並發布於 Docker 的[公共中心](https://hub.docker.com/r/microsoft/dotnet/)）。此映像已預先安裝 dotnet 2.1 SDK。Bionic 後綴表示容器的作業系統將採用 Ubuntu 18.04（代號 bionic）。透過變更後綴，可切換底層作業系統（例如：stretch 代表 Debian 9，alpine 代表 Alpine Linux）。在此情況下，需要修改 Dockerfile 內容（例如將 'apt-get' 改為 'yum'）。

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. 更新可用套件的資料庫並安裝 apt-utils 套件。

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. 安裝 System.Drawing.Common 函式庫所需的 'libgdiplus' 與 'libc6-dev' 套件。

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. 宣告 /slides-src 資料夾為掛載點，我們將以此提供對主機上 slide-net 原始碼資料夾的存取。

``` csharp

 VOLUME /slides-src

```

1. 將 slides-src 設為容器內的工作目錄。

``` csharp

 WORKDIR /slides-src

```

1. 宣告預設指令；若未明確指定指令，容器啟動時將執行此指令。

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

依照 Dockerfile 中的指示，最終的容器映像將已安裝 Ubuntu 18.04 作業系統、dotnet-sdk、libgdiplus 以及 libc6-dev 套件。此映像亦具備預先定義的掛載點與執行時的預設指令。

若要使用此 Dockerfile 建立映像，請前往 slides-netuil Docker 資料夾並執行以下指令：

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- 指定要使用的 Dockerfile。  
*-t ubuntu18_04_apt_get_libgdiplus* -- 為產生的映像指定標籤（名稱）。  
*'.'* -- 指定 Docker 的上下文。在本例中，上下文為當前資料夾且為空，因為我們將 slides-net 原始碼作為掛載點（這樣即可避免在每次原始碼變更時重新建構 Docker 映像）。

執行結果應顯示如下：

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

為確保新映像已加入本機映像庫，請執行：

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

映像建立完成後，我們可以使用以下指令執行它：

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- 指定以互動模式執行指令，讓我們能看到輸出並可輸入。  
*-v `pwd`/../../:/slides-src* -- 指定預先定義掛載點的資料夾；因為目前工作目錄是 slides-netuildocker，容器內的 slides-src 會指向主機上的 slides-net 資料夾。`pwd` 用於指定相對路徑。  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- 修改容器的 hosts 檔案，以解析 dev.slides.external.tool.server URL。  
*ubuntu1804aptgetlibgdiplus:latest* -- 指定要執行的映像。

上述指令的執行結果將會是 netcore.linux.tests.sh 的輸出（因為它被設定為容器的預設指令）：

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

從結果可見，Func 與 Regr 測試的日誌檔案已放置於 /build-out/netstandard20/test-results/main/ 目錄。此外，總計約有 200 個測試失敗，全部皆因容器缺乏必要字型而導致渲染問題。

若要在執行時覆寫容器的預設指令，可使用以下指令：

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

因此，會執行 /bin/bash 取代 netcore.linux.tests.sh，並提供容器的互動終端，從中可執行 (./build/netcore.linux.tests.sh)。此方式在疑難排解時相當有用。

## **在 Linux 上安裝與設定 Docker (make install libgdiplus)**
- 作業系統：Ubuntu 18.04。
- Dockerfile：Dockerfile-Ubuntu18_04_make_libgdiplus

目前 Ubuntu 只提供 libgdiplus 4.2 版，而 5.6 版已在產品的[官方網站](https://github.com/mono/libgdiplus/releases)上釋出。若要測試最新版本的 libgdiplus，我們需建立一個從原始碼自行編譯 libgdiplus 的映像。

讓我們檢視 Dockerfile 內容：

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 建置最新穩定版 libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# 建立掛載點

VOLUME /slides-src

\# 在啟動時建置並測試 Aspose.Slides

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

唯一的差異在於 *建置最新穩定版 libgdiplus* 部分。該段落會安裝建置 libgdiplus 所需的所有工具、克隆原始碼，並編譯後安裝至正確位置。其他皆與[在 Linux 上安裝與設定 Docker (apt-get libgdiplus)](/slides/zh-hant/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/)相同。

**注意**：別忘了在 docker build 與 docker run 指令中為產生的映像使用不同的標籤（名稱）：

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **在 Windows Server Core 上安裝與設定 Docker**
- 作業系統：Ubuntu 18.04。
- Dockerfile：Dockerfile*WinServerCore*

**注意**：執行 Windows 容器需要 Windows 10 Pro 或 Windows Server 2016。

遺憾的是，Microsoft 未提供已安裝 dotnet SDK 的 Windows Server Core 映像，故必須手動安裝：

``` csharp
 # escape=
FROM microsoft/windowsservercore:1803 AS installer-env
#設定 PowerShell 預設執行器
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# escape=
FROM microsoft/windowsservercore:1803 AS installer-env
#設定 PowerShell 預設執行器
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# 取得 .NET Core SDK
ENV DOTNET_SDK_VERSION 2.1.301
ENV DOTNET_PATH "c:/Program Files/dotnet"
RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 
    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 
    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 
        exit 1; 
    }; 
    
    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;
#將 cmd 設為預設執行器
SHELL ["cmd", "/S", "/C"]
\# 為了設定系統 PATH，必須使用 ContainerAdministrator
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"
USER ContainerUser
\# 建立掛載點
VOLUME c:/slides-src
#啟動時建置並測試 Aspose.Slides
WORKDIR c:/slides-src
CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```

最終映像將以 Microsoft 在[Docker Hub](https://hub.docker.com/u/microsoft)提供的 microsoft/windowsservercore:1803 為基礎建置。指定版本的 dotnet-sdk 會被下載並解壓，系統的 PATH 變數將更新以包含 dotnet 可執行檔的路徑。最後一行定義在容器執行時使用 nant.exe 執行 func 與 regr 測試的指令。

建置映像的指令：

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

執行映像的指令：

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**注意**：Windows 容器的指令多了兩個參數：

*-cpu-count 3* -- 設定容器使用的 CPU 核心數為 3。  
*-memory 8589934592* -- 設定容器可使用的記憶體大小（單位為位元組），此值約為 8 GB。

它們分別設定容器可使用的核心數與記憶體容量。預設情況下，Windows 容器僅能使用 1 核心與 1 GB 記憶體（而 Linux 容器則預設沒有此類限制）。

此外，與執行 Linux 容器的指令相比，少了一個參數：

*-add-host dev.slides.external.tool.server:192.168.1.48* -- 此參數在 Windows 上不需要，因為容器不需要 external.tool.server。

上述指令的執行結果應如下所示：

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