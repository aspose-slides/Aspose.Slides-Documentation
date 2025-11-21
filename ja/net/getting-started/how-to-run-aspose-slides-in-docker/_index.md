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
description: "Docker コンテナで Aspose.Slides を実行します。イメージ、依存関係、フォント、ライセンスを構成し、PowerPoint と OpenDocument を処理するスケーラブルなサービスを構築します。"
---

## **サポートされている OS**
Aspose.Slides は .NET Core プラットフォームを使用して Docker コンテナー内で実行できます。一般的に、Aspose.Slides は .NET Core プラットフォームがサポートするすべてのコンテナータイプ (OS) をサポートします。ただし、GDI または[libgdiplus](https://github.com/mono/libgdiplus) がコンテナー上で利用可能で正しく設定されている必要があります。

Docker を使用するには、まずシステムに Docker をインストールする必要があります。Windows または Mac への Docker のインストール方法は、以下のリンクをご参照ください。

- [Install Docker on Windows](https://docs.docker.com/docker-for-windows/install/)
- [Install Docker on Mac](https://docs.docker.com/docker-for-mac/install/)

Linux および Windows Server でも Docker を実行できます。以下のページの手順に従ってください。

- [Install and configure Docker on Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Install and configure Docker on Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Install and configure Docker on Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Windows Server Nano での Docker のインストールと構成はサポートされていません。残念ながら、Windows Server Nano にはグラフィックサブシステムが搭載されておらず、gdiplus.dll が存在しないため、System.Drawing.Common ライブラリが必要とするものがなく、Aspose.Slides ライブラリは使用できません。

Linux コンテナーを Windows 上で実行することは可能ですが、VM 上の Linux に手動でインストールした Linux 上でネイティブに実行することを推奨します (VirtualBox など)。

## **Installing and Configuring Docker on Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

この Docker ファイルには、Ubuntu 公式パッケージリポジトリから libgdiplus パッケージをインストールしたコンテナーイメージをビルドする手順が含まれています。

Dockerfile の内容は次のとおりです:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus をインストール

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# マウントポイントを作成

VOLUME /slides-src

\# 起動時に Aspose.Slides をビルドしてテスト

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


各行が何を意味するかを確認しましょう。

1. コンテナーのイメージは microsoft/dotnet:2.1-sdk-bionic イメージをベースにしています (Microsoft がビルドし Docker の[public hub](https://hub.docker.com/r/microsoft/dotnet/) に公開)。このイメージには dotnet 2.1 SDK がすでにインストールされています。Bionic サフィックスは Ubuntu 18.04 (コードネーム bionic) がコンテナーの OS として使用されることを意味します。サフィックスを変更すれば、基盤 OS を変更できます (例: stretch → Debian 9、alpine → Alpine Linux)。その場合は Dockerfile の内容も変更する必要があります (例: 'apt-get' を 'yum' に変更)。
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:
```


1. 利用可能なパッケージデータベースを更新し、apt-utils パッケージをインストールします。
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. System.Drawing.Common ライブラリが必要とする 'libgdiplus' と 'libc6-dev' パッケージをインストールします。
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. /slides-src フォルダーをマウントポイントとして宣言します。これにより、ホストマシン上の slide-net ソースフォルダーへアクセスできます。
``` csharp

 VOLUME /slides-src

```


1. slides-src をコンテナー内の作業ディレクトリとして設定します。
``` csharp

 WORKDIR /slides-src

```


1. 明示的なコマンドが指定されていない場合にコンテナー起動時に実行されるデフォルトコマンドを宣言します。
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Dockerfile の指示に従うと、結果のコンテナーイメージには Ubuntu 18.04 OS、dotnet-sdk、libgdiplus、libc6-dev パッケージがあらかじめインストールされています。また、マウントポイントとデフォルトコマンドが事前に設定されています。

この Dockerfile を使用してイメージをビルドするには、slides-netuil の Docker フォルダーに移動して次のコマンドを実行します:
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- 使用する Dockerfile を指定します。

*-t ubuntu18_04_apt_get_libgdiplus* -- 生成されるイメージのタグ (名前) を指定します。

*'.'* -- Docker のコンテキストを指定します。ここでは現在のフォルダーがコンテキストであり、スライドソースをマウントポイントとして提供するため空です。

実行結果は次のようになるはずです:
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


新しいイメージがローカルイメージリポジトリに追加されたことを確認するには:
``` csharp

 $ docker images

\----
REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


イメージが準備できたら、次のコマンドで実行できます:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* -- インタラクティブモードでコマンドを実行し、出力を確認し入力を受け取れるようにします。

*-v `pwd`/../../:/slides-src* -- 事前に定義したマウントポイントのフォルダーを指定します。現在の作業ディレクトリが slides-netuildocker であるため、コンテナー内の slides-src フォルダーはホスト上の slides-net フォルダーを指します。`pwd` は相対パスを指定するために使用します。

*--add-host dev.slides.external.tool.server:192.168.1.48* -- コンテナーの hosts ファイルを変更し、dev.slides.external.tool.server の URL を解決できるようにします。

*ubuntu1804aptgetlibgdiplus:latest* -- 実行するイメージを指定します。

上記コマンドの結果として、netcore.linux.tests.sh の出力が表示されます (コンテナーのデフォルトコマンドとして定義されているため):
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


結果から、Func と Regr のテストログが /build-out/netstandard20/test-results/main/ ディレクトリに配置されたことが分かります。また、合計で約 200 件のテストが失敗しており、すべてフォントが欠如していることに起因するレンダリング問題です。

コンテナー実行時にデフォルトコマンドを上書きしたい場合は、次のコマンドを使用できます:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


この場合、netcore.linux.tests.sh の代わりに /bin/bash が実行され、コンテナー内でアクティブなターミナルセッションが提供されます (./build/netcore.linux.tests.sh を実行可能)。トラブルシューティング時に便利です。

## **Installing and Configuring Docker on Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

現在、Ubuntu の公式リポジトリには libgdiplus のバージョン 4.2 しか含まれていませんが、バージョン 5.6 は製品の[公式サイト](https://github.com/mono/libgdiplus/releases)で入手可能です。最新バージョンをテストするには、ソースから libgdiplus をビルドしたイメージを作成する必要があります。

Dockerfile の内容は次のとおりです:
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

\# 起動時に Aspose.Slides をビルドしてテスト

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh
```


唯一の違いは *build latest stable libgdiplus* セクションです。このセクションは libgdiplus をビルドするために必要なツールをインストールし、ソースをクローンしてビルド・インストールします。その他は[Install and configure Docker on Linux (apt-get libgdiplus)](/slides/ja/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/) と同じです。

**Note**: Docker ビルドおよび Docker ランコマンドで使用するイメージタグ (名前) を必ず異なるものにしてください:
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Install and configure Docker on Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Note**: Windows コンテナーを実行するには Windows 10 Pro または Windows Server 2016 が必要です。

残念ながら Microsoft は dotnet SDK がインストールされた Windows Server Core イメージを提供していないため、手動でインストールする必要があります:
``` csharp

 # エスケープ=

FROM microsoft/windowsservercore:1803 AS installer-env

#powershell のデフォルト実行エクゼキュータを設定

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# エスケープ=

FROM microsoft/windowsservercore:1803 AS installer-env

#powershell のデフォルト実行エクゼキュータを設定

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

# cmd をデフォルト実行エンジンとして使用

SHELL ["cmd", "/S", "/C"]

\# システム PATH を設定するには ContainerAdministrator を使用する必要があります

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# マウントポイントを作成

VOLUME c:/slides-src

# 起動時に Aspose.Slides をビルドしてテスト

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


生成されるイメージは Microsoft が[Docker Hub](https://hub.docker.com/r/microsoft/windowsservercore/) で提供する microsoft/windowsservercore:1803 イメージを基に構築されます。指定されたバージョンの dotnet-sdk がダウンロードされ解凍され、システムの PATH 変数が dotnet 実行ファイルを含むように更新されます。最後の行は、コンテナー実行時に nant.exe をデフォルトアクションとして func と regr テストを実行するコマンドを定義しています。

イメージをビルドするコマンド:
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


イメージを実行するコマンド:
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**Note**: Windows コンテナー用コマンドには 2 つの追加引数があります:

*-cpu-count 3*

*-memory 8589934592*

これらはコンテナーに割り当てるコア数とメモリ容量を指定します。デフォルトでは Windows コンテナーは 1 コア・1 GB の RAM のみが利用可能です (Linux コンテナーにはデフォルトで制限がありません)。

Linux コンテナー用コマンドと比較して 1 つの引数が欠けています:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Windows 上のコンテナーは external.tool.server を必要としないためです。

上記コマンドの実行結果は次のようになります:
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
