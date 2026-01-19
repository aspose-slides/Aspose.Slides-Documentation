---
title: Docker で Aspose.Slides を実行する方法
linktitle: Docker の Aspose.Slides
type: docs
weight: 140
url: /ja/net/how-to-run-aspose-slides-in-docker/
keywords:
- サポートされている OS
- Docker の Aspose.Slides
- Docker コンテナ
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- イメージ リポジトリ
- Windows Server Core
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Docker コンテナで Aspose.Slides を実行する方法: イメージ、依存関係、フォント、ライセンスを構成し、PowerPoint と OpenDocument を処理するスケーラブルなサービスを構築します。"
---

## **サポートされている OS**
Aspose.Slides は .NET Core プラットフォームを使用して Docker コンテナ内で実行できます。一般に、Aspose.Slides は .NET Core プラットフォームがサポートするすべてのコンテナタイプ（OS）をサポートします。ただし、GDI または[libgdiplus](https://github.com/mono/libgdiplus) がコンテナ上で利用可能で、正しく設定されている必要があります。

Docker を使用するには、まずシステムにインストールする必要があります。Windows または Mac に Docker をインストールする方法については、以下のリンクをご覧ください：

- [Install Docker on Windows](https://docs.docker.com/docker-for-windows/install/)
- [Install Docker on Mac](https://docs.docker.com/docker-for-mac/install/)

Linux および Windows Server でも、以下のページの手順に従って Docker を実行できます：

- [Linux 上で Docker をインストールおよび構成する (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Linux 上で Docker をインストールおよび構成する (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Windows Server Core 上で Docker をインストールおよび構成する](#install-and-configure-docker-on-windows-server-core)

Windows Server Nano 用の Docker のインストールおよび構成はサポートされていません。残念ながら、Windows Server Nano にはグラフィックサブシステムが搭載されておらず、System.Drawing.Common ライブラリが必要とする gdiplus.dll が含まれていないため、Aspose.Slides ライブラリと共に使用することはできません。

Windows 上で Linux コンテナを実行することは可能ですが、Linux（VirtualBox を使用した VM に手動でインストールした Linux でも可）でネイティブに実行することを推奨します。

## **Linux 上で Docker をインストールおよび構成する (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

この Dockerfile には、Ubuntu の公式パッケージリポジトリから libgdiplus パッケージをインストールしたコンテナイメージを作成する手順が含まれています。

以下は Dockerfile の内容です:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus をインストール

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# マウントポイントを作成

VOLUME /slides-src

\# 起動時に Aspose.Slides をビルドおよびテスト

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


docker ファイルの各行が何を意味するかを確認しましょう：

1. コンテナイメージは microsoft/dotnet:2.1-sdk-bionic イメージを基にしています（このイメージは Microsoft が作成し、Docker の[public hub](https://hub.docker.com/r/microsoft/dotnet/)で公開されています）。このイメージにはすでに dotnet 2.1 SDK がインストールされています。Bionic サフィックスは Ubuntu 18.04（コードネーム bionic）がコンテナの OS として使用されることを意味します。サフィックスを変更することで、基盤となる OS を変更できます（例: stretch は Debian 9、alpine は Alpine Linux）。この場合、Dockerfile の内容を変更する必要があります（例: 'apt-get' を 'yum' に変更）。  
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:
```


1. 利用可能なパッケージデータベースを更新し、apt-utils パッケージをインストールします。  
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. System.Drawing.Common ライブラリに必要な 'libgdiplus' と 'libc6-dev' パッケージをインストールします。  
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. /slides-src フォルダーをマウントポイントとして宣言し、ホストマシン上の slide-net ソースフォルダーへのアクセスを提供します。  
``` csharp

 VOLUME /slides-src

```


1. コンテナ内の作業ディレクトリとして slides-src を設定します。  
``` csharp

 WORKDIR /slides-src

```


1. 明示的なコマンドが指定されていない場合に、コンテナ起動時に実行されるデフォルトコマンドを宣言します。  
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Dockerfile の指示に従うと、作成されるコンテナイメージは Ubuntu 18.04 OS、dotnet-sdk、libgdiplus、libc6-dev パッケージが既にインストールされた状態になります。また、このイメージには事前定義されたマウントポイントと実行時のコマンドが設定されています。

この Dockerfile を使用してイメージをビルドするには、slides-netuil の Dockerフォルダーに移動して以下を実行します：
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -- オプションは使用する Dockerfile を指定します。  
-t ubuntu18_04_apt_get_libgdiplus -- 結果イメージのタグ（名前）を指定します。  
'.' -- Docker のコンテキストを指定します。ここではコンテキストは現在のフォルダーで、空です。これは slides-net のソースをマウントポイントとして提供するためで、ソースが変更されるたびに Docker イメージを再ビルドする必要がなくなります。

実行結果は以下のようになります：
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


新しいイメージがローカルイメージリポジトリに追加されたことを確認するには：
``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


イメージが準備できたら、以下のコマンドで実行できます：
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


-it -- コマンドを対話的に実行し、出力を確認し入力を受け取れるようにします。  
-v `pwd`/../../:/slides-src -- 事前定義されたマウントポイント用のフォルダーを指定します。現在の作業ディレクトリが slides-netuildocker であるため、コンテナ内の slides-src フォルダーはホストの slides-net フォルダーを指します。`pwd` は相対パスを指定するために使用します。  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- コンテナの hosts ファイルを変更し、dev.slides.external.tool.server の URL を解決できるようにします。  
*ubuntu1804aptgetlibgdiplus:latest* -- 実行するコンテナのイメージを指定します。

上記コマンドの結果は netcore.linux.tests.sh の出力になります（コンテナのデフォルトコマンドとして定義されているため）：
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


結果から、Func と Regr テストのログファイルが /build-out/netstandard20/test-results/main/ ディレクトリに配置されたことが分かります。また、合計約 200 件のテストが失敗しており、すべてはコンテナに必要なフォントが無いためのレンダリング問題です。

実行時にコンテナのデフォルトコマンドを上書きするには、以下のコマンドを使用できます：
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


このように、netcore.linux.tests.sh の代わりに /bin/bash が実行され、コンテナ内でアクティブなターミナルセッションが提供され、そこから（./build/netcore.linux.tests.sh）を実行できます。この方法はトラブルシューティング時に有用です。

## **Linux 上で Docker をインストールおよび構成する (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

現在、Ubuntu には libgdiplus のバージョン 4.2 しか含まれていませんが、バージョン 5.6 は製品の[公式サイト](https://github.com/mono/libgdiplus/releases)で既に利用可能です。最新バージョンの libgdiplus をテストするために、ソースからビルドした libgdiplus を含むイメージを作成する必要があります。

Dockerfile の内容を確認しましょう：
``` csharp
 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# 最新の安定版 libgdiplus をビルド

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

\# 起動時に Aspose.Slides をビルドおよびテスト

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh
```


唯一の違いは *build latest stable libgdiplus* セクションです。このセクションでは libgdiplus のビルドに必要なツールをすべてインストールし、ソースをクローンしてビルドし、適切な場所にインストールします。その他は[Install and configure Docker on Linux (apt-get libgdiplus)](/slides/ja/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/) と同じです。

**注**: docker build と docker run コマンドで生成されるイメージに対して、異なるイメージタグ（名前）を使用することを忘れないでください：
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Windows Server Core 上で Docker をインストールおよび構成する**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**注**: Windows コンテナを実行するには Windows 10 Pro または Windows Server 2016 が必要です。

残念ながら、Microsoft は dotnet SDK がインストールされた Windows Server Core イメージを提供していないため、手動でインストールする必要があります：
``` csharp
 # エスケープ=
FROM microsoft/windowsservercore:1803 AS installer-env

# PowerShell のデフォルト実行者を設定

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# エスケープ=

FROM microsoft/windowsservercore:1803 AS installer-env

# PowerShell のデフォルト実行者を設定

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# .NET Core SDK を取得

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 
    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 
    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 
        exit 1; 
    }; 
    
    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

# cmd をデフォルト実行者として返す
SHELL ["cmd", "/S", "/C"]

\# システム PATH を設定するには、ContainerAdministrator を使用する必要があります
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"
USER ContainerUser

\# マウントポイントを作成
VOLUME c:/slides-src

# 起動時に Aspose.Slides をビルドおよびテスト
WORKDIR c:/slides-src
CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


生成されるイメージは Microsoft が [docker hub](https://hub.docker.com/u/microsoft) で提供している microsoft/windowsservercore:1803 イメージを元に作成されます。指定されたバージョンの dotnet-sdk がダウンロード・展開され、システムの PATH 変数が dotnet 実行ファイルのパスを含むように更新されます。最後の行は、コンテナ実行時にデフォルトアクションとして nant.exe を使用して func および regr テストを実行するコマンドを定義しています。

イメージをビルドするコマンド：
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


イメージを実行するコマンド：
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**注**: Windows コンテナ用のコマンドは 2 つの追加引数を使用します：
-cpu-count 3 -- コア数を 3 に設定します。  
-memory 8589934592 -- メモリを 8589934592 バイト（約 8 GB）に設定します。

これらはコンテナに割り当てるコア数とメモリ量を設定します。デフォルトでは、Windows コンテナは 1 コアと 1 GB の RAM しか利用できません（Linux コンテナはデフォルトで制限がありません）。

また、Linux コンテナを実行する際に使用したコマンドと比較して、1 つの引数が欠けています：
-add-host dev.slides.external.tool.server:192.168.1.48 -- この引数は、Windows 上のコンテナでは外部ツールサーバーが不要なため省略されています。

Windows 上で実行されるコンテナは external.tool.server を必要としないためです。

上記コマンドの結果は以下のようになります：
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
