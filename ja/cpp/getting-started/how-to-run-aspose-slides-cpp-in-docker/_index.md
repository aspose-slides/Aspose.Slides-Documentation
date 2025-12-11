---
title: DockerでAspose.Slides for C++を実行する方法
type: docs
weight: 140
url: /ja/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- Aspose.Slides のダウンロード
- Aspose.Slides のインストール
- Aspose.Slides のインストール方法
- Docker
- Windows
- macOS
- Linux
- クロスプラットフォーム互換性
- 依存関係の分離
- 簡素化されたデプロイ
- プロジェクトの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "DockerコンテナでAspose.Slidesを実行し、イメージ、依存関係、フォント、ライセンスを構成して、PowerPointやOpenDocumentを処理するスケーラブルなサービスを構築します。"
---

Aspose.Slides for C++ は Docker コンテナ内で実行できます。Linux 環境で Aspose.Slides for C++ を実行するには、Docker ファイルを使用できます。 

## **Dockerfile の説明**

たとえば、Ubuntu 16.04 用の Aspose.Slides for C++ の Docker ファイルを次のように使用できます： 
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


このファイルは、3 つの主要なパート（手順）で構成されています：

1. Aspose.Slides for C++ の実行に必要なツールをインストールする： 
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


2. msttcorefonts パッケージをインストールする（デフォルトでは、msttcorefonts パッケージの EULA は受諾されていません）： 
```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```


3. /slides-cpp フォルダーをマウントポイントとして宣言し、ホストマシン上の slides-cpp ソースフォルダーへのアクセスを提供する；例のビルドと実行： 
``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```


## **イメージのビルドと実行**

1. ホストシステム上で [Docker をインストール](https://docs.docker.com/engine/install/) します。

2. イメージをビルドします。  

   ターミナルの作業ディレクトリには、上記の内容が記載された Dockerfile が含まれている必要があります。 
```
docker build -t aspose-slides-ubuntu-16.04 .
```


3. [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cpp) をダウンロードして解凍します。

4. Docker が使用できるように、Aspose.Slides for C++ のフォルダーを共有します： 
   - Windows では、タスクバーの Docker アイコンを右クリックし、設定を選択します。
   - Resources > File Sharing を開きます。 

5. 次のいずれかの方法でイメージをコンテナとして実行します：

* 方法 A: 名前付きコンテナを作成して実行する： 
```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


2 回目以降の起動では、次を使用する必要があります： 
```
docker start slides-cpp-ubuntu -i
```


* 方法 B: 名前のない一時コンテナを作成して実行する： 
```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


サンプルプロジェクトのビルドと実行が表示されます： 
```
-- CXXコンパイラの識別はClang 3.9.1です
-- CXXコンパイラの動作確認: /usr/bin/clang++
-- CXXコンパイラの動作確認: /usr/bin/clang++ -- 正常に動作
-- CXXコンパイラのABI情報を検出中
-- CXXコンパイラのABI情報を検出 - 完了
-- CXXコンパイル機能を検出中
-- CXXコンパイル機能を検出 - 完了
-- 設定完了
-- 生成完了
-- ビルドファイルが次の場所に書き込まれました: /slides-cpp/sample/build
Scanning dependencies of target Aspose.Slides.Cpp.Examples
[ 14%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] Linking CXX executable Aspose.Slides.Cpp.Examples
[100%] Built target Aspose.Slides.Cpp.Examples

Running examples...

Running Chart::SampleChart...
Running Thumbnail::SampleThumbnail...
Running Text::SampleAddText...
Running SmartArt::SampleCreation...
Running SmartArt::SampleCloning...
Running SmartArt::SampleNodesTextEditing...
Running SmartArt::SampleNodeAdd...
Running SmartArt::SampleColorStyleEditing...
Running SmartArt::SampleQuickStyleEditing...
Running SmartArt::SampleNodeRemove...
Running SmartArt::SampleRemoveSmartArt...
Running PresentationExport::Export...
Saving presentation as PDF...OK
Saving presentation as XPS...OK
Saving presentation as SWF...OK
Saving presentation as HTML...OK
Saving presentation as PDF...OK
Saving presentation as XPS...OK
Saving presentation as SWF...OK
Saving presentation as HTML...OK
```
