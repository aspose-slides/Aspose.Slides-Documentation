---
title: Aspose.Slides for C++ を Docker で実行する方法
type: docs
weight: 140
url: /cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords: "Docker コンテナでの Aspose.Slides for C++ の実行, Aspose Docker, Docker での Aspose.Slides for C++"
description: "Linux の Docker コンテナで Aspose.Slides for C++ を実行します。"
---

Aspose.Slides for C++ は Docker コンテナ内で実行できます。Linux 環境で Aspose.Slides for C++ を実行するには、Docker ファイルを使用できます。

## Dockerfile の説明

例えば、Ubuntu 16.04 用の Aspose.Slides for C++ の Docker ファイルは次のようになります：

```
FROM ubuntu:16.04

RUN apt-get update && apt-get install software-properties-common -y \
 && add-apt-repository ppa:ubuntu-toolchain-r/test \
 && apt-get update && apt-get upgrade libstdc++6 -y --no-install-recommends\
 && apt-get install -y --no-install-recommends  \
    unzip \
    cmake \
    make \
    clang-3.9 \
    gcc-6 \
    g++-6 \
    fontconfig \
    libglu1-mesa \ 
 && update-alternatives --install /usr/bin/clang   clang   /usr/bin/clang-3.9 30 \
 && update-alternatives --install /usr/bin/clang++ clang++ /usr/bin/clang++-3.9 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/clang-3.9 40 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/clang++-3.9 40 \
 && update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/g++ g++ /usr/bin/g++-6 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/g++-6 30

ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v

VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

このファイルは、主に3つの部分（手順）で構成されています：

1. Aspose.Slides for C++ を実行するために必要なツールのインストール：

```
FROM ubuntu:16.04

RUN apt-get update && apt-get install software-properties-common -y \
 && add-apt-repository ppa:ubuntu-toolchain-r/test \
 && apt-get update && apt-get upgrade libstdc++6 -y --no-install-recommends\
 && apt-get install -y --no-install-recommends  \
    unzip \
    cmake \
    make \
    clang-3.9 \
    gcc-6 \
    g++-6 \
    fontconfig \
    libglu1-mesa \ 
 && update-alternatives --install /usr/bin/clang   clang   /usr/bin/clang-3.9 30 \
 && update-alternatives --install /usr/bin/clang++ clang++ /usr/bin/clang++-3.9 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/clang-3.9 40 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/clang++-3.9 40 \
 && update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/g++ g++ /usr/bin/g++-6 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/g++-6 30
```

2. msttcorefonts パッケージのインストール（デフォルトでは、msttcorefonts パッケージの EULA は受け入れられません）：

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. /slides-cpp フォルダをマウントポイントとして宣言し、ホストマシンの slides-cpp ソースフォルダにアクセスできるようにします。例をビルドして実行します：

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## イメージのビルドと実行

1. [Docker](https://docs.docker.com/engine/install/) をホストシステムにインストールします。

2. イメージをビルドします。

   ターミナルの作業ディレクトリには、上記の内容を含む Dockerfile が必要です。

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cpp) をダウンロードして解凍します。
4. Docker が使用できるように、Aspose.Slides for C++ を含むフォルダを共有します：
   - Windows では、タスクバーの Docker アイコンを右クリックします。[設定] を選択します。
   - リソース > ファイル共有を進みます。
5. 次のいずれかの方法で、イメージをコンテナとして実行します：

* 方法 A：名前付きコンテナを作成して実行します：

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

2回目以降の起動には、次を使用します：

```
docker start slides-cpp-ubuntu -i
```

* 方法 B：無名の一時コンテナを作成して実行します：

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

次のように、サンプルプロジェクトのビルドと実行が表示されます：

```
-- CXX コンパイラの識別は Clang 3.9.1 です
-- 動作中の CXX コンパイラを確認しています: /usr/bin/clang++
-- 動作中の CXX コンパイラを確認しています: /usr/bin/clang++ -- 動作します
-- CXX コンパイラ ABI 情報を検出しています
-- CXX コンパイラ ABI 情報を検出しています - 完了
-- CXX コンパイル機能を検出しています
-- CXX コンパイル機能を検出しています - 完了
-- 構成が完了しました
-- 生成が完了しました
-- ビルドファイルが次に書き込まれました: /slides-cpp/sample/build
依存関係をスキャン中: ターゲット Aspose.Slides.Cpp.Examples
[ 14%] CXX オブジェクト CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o をビルド中
[ 42%] CXX オブジェクト CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o をビルド中
[ 42%] CXX オブジェクト CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o をビルド中
[ 57%] CXX オブジェクト CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o をビルド中
[ 71%] CXX オブジェクト CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o をビルド中
[ 85%] CXX オブジェクト CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o をビルド中
[100%] CXX 実行ファイル Aspose.Slides.Cpp.Examples をリンク中
[100%] ターゲット Aspose.Slides.Cpp.Examples をビルドしました

例を実行中...

Chart::SampleChart を実行中...
Thumbnail::SampleThumbnail を実行中...
Text::SampleAddText を実行中...
SmartArt::SampleCreation を実行中...
SmartArt::SampleCloning を実行中...
SmartArt::SampleNodesTextEditing を実行中...
SmartArt::SampleNodeAdd を実行中...
SmartArt::SampleColorStyleEditing を実行中...
SmartArt::SampleQuickStyleEditing を実行中...
SmartArt::SampleNodeRemove を実行中...
SmartArt::SampleRemoveSmartArt を実行中...
PresentationExport::Export を実行中...
プレゼンテーションを PDF として保存しています...OK
プレゼンテーションを XPS として保存しています...OK
プレゼンテーションを SWF として保存しています...OK
プレゼンテーションを HTML として保存しています...OK
プレゼンテーションを PDF として保存しています...OK
プレゼンテーションを XPS として保存しています...OK
プレゼンテーションを SWF として保存しています...OK
プレゼンテーションを HTML として保存しています...OK
```