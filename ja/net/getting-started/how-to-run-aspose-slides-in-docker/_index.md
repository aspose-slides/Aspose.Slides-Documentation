---
title: Aspose.SlidesをDockerで実行する方法
type: docs
weight: 140
url: /ja/net/how-to-run-aspose-slides-in-docker/
keywords: "DockerコンテナでAspose.Slidesを実行, Aspose Docker, Docker内のAspose.Slides"
description: "Linux、Windows Server、および任意のOSのDockerコンテナでAspose.Slidesを実行します。"
---

## **サポートされているOS**
Aspose.Slidesは.NET Coreプラットフォームを使用してDockerコンテナ内で実行できます。一般的に、Aspose.Slidesは.NET Coreプラットフォームがサポートするすべてのコンテナタイプ（OS）をサポートしています。ただし、GDIまたは[libgdiplus](https://github.com/mono/libgdiplus)が利用可能で、関与するコンテナに正しく設定されている必要があります。

Dockerを使用するには、最初にシステムにインストールする必要があります。WindowsまたはMacにDockerをインストールする方法については、以下のリンクを参照してください：

- [WindowsにDockerをインストール](https://docs.docker.com/docker-for-windows/install/)
- [MacにDockerをインストール](https://docs.docker.com/docker-for-mac/install/)

LinuxやWindows Server上でもDockerを実行できます。次のページの指示に従ってください：

- [LinuxにDockerをインストールおよび構成（apt-get libgdiplus）](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [LinuxにDockerをインストールおよび構成（make install libgdiplus）](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [Windows Server CoreにDockerをインストールおよび構成](#install-and-configure-docker-on-windows-server-core)

Windows Server NanoにDockerをインストールおよび構成することはサポートされていません。残念ながら、Windows Server Nanoにはグラフィックサブシステムが搭載されていません。System.Drawing.Commonライブラリが必要とするgdiplus.dllを含まず、Aspose.Slidesライブラリで使用することはできません。

Windows上でLinuxコンテナを実行することは可能ですが、ネイティブにLinux上（たとえば、VirtualBoxを使用して手動でインストールされたLinux）で実行することをお勧めします。

## **LinuxにDockerをインストールおよび構成する（apt-get libgdiplus）**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

このDockerファイルには、Ubuntuの公式パッケージリポジトリからインストールされたlibgdiplusパッケージでコンテナ画像をビルドするための指示が含まれています。

以下はDockerファイルの内容です：

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplusをインストール

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# マウントポイントを作成

VOLUME /slides-src

\# Aspose.Slidesのビルドとテストを開始

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Dockerファイルの各行が何を意味するのか見てみましょう：

1. コンテナのイメージはmicrosoft/dotnet:2.1-sdk-bionicイメージをベースにしています（このイメージはMicrosoftによって既にビルドされ、Dockerの[パブリックハブ](https://hub.docker.com/r/microsoft/dotnet/)に公開されています）。このイメージには、すでにインストールされたdotnet 2.1 SDKが含まれています。Bionicサフィックスは、Ubuntu 18.04（コードネームbionic）がコンテナのOSとして採用されることを意味します。サフィックスを変更すると、基盤となるOSを変更することができます（例えば: stretch -- Debian 9, alpine -- Alpine Linux）。その場合、Dockerファイルの内容を変更する必要があります（例えば、「apt-get」を「yum」に変更するなど）。

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. 利用可能なパッケージのデータベースを更新し、apt-utilsパッケージをインストールします。

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. System.Drawing.Commonライブラリによって必要な「libgdiplus」と「libc6-dev」パッケージをインストールします。

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. /slides-srcフォルダーをマウントポイントとして宣言し、ホストマシン上のslide-netソースフォルダーへのアクセスを提供します。

``` csharp

 VOLUME /slides-src

```

1. slides-srcをコンテナ内の作業ディレクトリとして設定します。

``` csharp

 WORKDIR /slides-src

```

1. 明示的なコマンドが指定されていない場合に、コンテナの開始時に実行されるデフォルトコマンドを宣言します。

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Dockerファイルの指示に従うと、結果として得られるコンテナのイメージには、Ubuntu 18.04 OS、dotnet-sdk、libgdiplus、及びlibc6-devパッケージがすでにインストールされます。また、このイメージには、事前定義されたマウントポイントと実行時に事前定義されたコマンドが含まれます。

このDockerファイルを使用してイメージをビルドするには、slides-netuil Dockerフォルダーに移動し、次のコマンドを実行します：

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- 使用するDockerファイルを指定するオプションです。

*-t ubuntu18_04_apt_get_libgdiplus* -- 結果として得られるイメージのタグ（名前）を指定します。

*'.'* -- Dockerのコンテキストを指定します。今回は、コンテキストは現在のフォルダーで、スライドネットソースをマウントポイントとして提供するために空です（これにより、ソースの変更ごとにDockerイメージを再ビルドする必要がなくなります）。

実行の結果は次のようになります：

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

新しいイメージがローカルのイメージリポジトリに追加されたことを確認するには：

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

イメージの準備が整ったら、次のコマンドを使用して実行できます：

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- コマンドを対話的に実行するよう指定し、出力を表示し、入力をキャプチャできるようにします。

*-v `pwd`/../../:/slides-src* -- 事前定義されたマウントポイント用のフォルダーを指定します。現在の作業ディレクトリがslides-netuildockerのため、コンテナ内のslides-srcフォルダーはホスト上のslides-netフォルダーを指します。`pwd`は相対パスを指定するために使用されます。

*--add-host dev.slides.external.tool.server:192.168.1.48* -- コンテナのhostsファイルを修正してdev.slides.external.tool.server URLを解決します。

*ubuntu1804aptgetlibgdiplus:latest* -- コンテナを実行するイメージを指定します。

上記のコマンドの結果は、netcore.linux.tests.shの出力になります（それがデフォルトコマンドとして定義されているため）：

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

結果から、FuncおよびRegrテストのログファイルが/build-out/netstandard20/test-results/main/ディレクトリに置かれたことが明らかです。また、合計で約200のテストが失敗しましたが、これらはすべて、コンテナ上のフォントが必要とされていないことに関連するレンダリングの問題です。

コンテナのデフォルトコマンドを実行時に上書きするには、次のコマンドを使用できます：

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

このようにして、netcore.linux.tests.shの代わりに/bin/bashが実行され、そこからコンテナのアクティブなターミナルセッションを提供し（./build/netcore.linux.tests.shを実行することができます）。このアプローチは、トラブルシューティングのシナリオで役立つ場合があります。
## **LinuxにDockerをインストールおよび構成する（make install libgdiplus）**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

現在、Ubuntuにはlibgdiplusのバージョン4.2しか含まれていませんが、バージョン5.6はすでに製品の[公式サイト](https://github.com/mono/libgdiplus/releases)にあります。libgdiplusの最新バージョンをテストするには、ソースからビルドされたlibgdiplusを含むイメージを準備する必要があります。

以下はDockerファイルの内容です：

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 最新の安定版libgdiplusをビルド

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# マウントポイントを作成

VOLUME /slides-src

\# Aspose.Slidesのビルドとテストを開始

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

唯一の違いは、*最新の安定版libgdiplusをビルド*セクションです。このセクションでは、libgdiplusをビルドするために必要なツールをすべてインストールし、ソースをクローンしてから、それらをビルドして適切な場所にインストールします。それ以外は、[LinuxにDockerをインストールおよび構成する（apt-get libgdiplus）](/slides/ja/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/)と同じです。

**注意**: DockerビルドおよびDocker実行コマンドで、結果として得られるイメージに異なるイメージタグ（名前）を使用することを忘れないでください：

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Windows Server CoreにDockerをインストールおよび構成する**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**注意**: Windowsコンテナを実行するには、Windows 10 ProまたはWindows Server 2016が必要です。

残念ながら、Microsoftはdotnet SDKがインストールされたWindows Server Coreイメージを提供していないため、手動でインストールする必要があります：

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# .NET Core SDKを取得

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'チェックサム検証失敗！'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#cmdをデフォルトの実行者に戻す

SHELL ["cmd", "/S", "/C"]

\# システムPATHを設定するために、ContainerAdministratorを使用する必要があります

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# マウントポイントを作成

VOLUME c:/slides-src

#Aspose.Slidesのビルドとテストを開始

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

結果として得られるイメージは、Microsoftが提供するmicrosoft/windowsservercore:1803イメージの上に構築されます[Docker Hub](https://hub.docker.com/r/microsoft/windowsservercore/)にあります。指定されたバージョンのdotnet-sdkがダウンロードされ、解凍され、システムのPATH変数がdotnet実行可能ファイルへのパスを含むように更新されます。最後の行は、nant.exeを使用してコンテナ上でfuncおよびregrテストを実行するコマンドを定義します。

イメージをビルドするためのコマンド：

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

イメージを実行するためのコマンド：

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**注意**: Windowsコンテナのコマンドには、2つの追加引数が使用されます：

*-cpu-count 3*

*-memory 8589934592*

これにより、コンテナに利用可能なコアの数とメモリの量が設定されます。デフォルトでは、Windowsコンテナには1つのコアと1GBのRAMしかありません（Linuxコンテナにはデフォルトで制限はありません）。

また、Linuxコンテナを実行するために使用したのと同じコマンドを比較すると、1つの引数が欠けています：

*-add-host dev.slides.external.tool.server:192.168.1.48*

コンテナがWindowsで実行されているため、external.tool.serverは必要ありません。

上記のコマンドの結果は次のようになります：

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] ディレクトリ'c:\slides-src\build-out\netcore20\test-results\'を削除しています。

   [mkdir] ディレクトリ'c:\slides-src\build-out\netcore20\test-results\'を作成しています。

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] Total tests: 2338. Passed: 2115. Failed: 19. Skipped: 204.

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] Total tests: 2728. Passed: 2147. Failed: 110. Skipped: 471.

```