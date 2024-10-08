---
title: 如何在 Docker 中运行 Aspose.Slides for C++
type: docs
weight: 140
url: /cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords: "在 Docker 容器中运行 Aspose.Slides for C++, Aspose Docker, 在 Docker 中运行 Aspose.Slides for C++"
description: "在 Linux 的 Docker 容器中运行 Aspose.Slides for C++。"
---

Aspose.Slides for C++ 可以在 Docker 容器中运行。要在 Linux 环境中运行 Aspose.Slides for C++，可以使用一个 Docker 文件。

## Dockerfile 描述

例如，你可以使用这个 Docker 文件来运行带有 Ubuntu 16.04 的 Aspose.Slides for C++：

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

该文件包含三个主要部分（过程）：

1. 安装运行 Aspose.Slides for C++ 所需的工具：

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

2. 安装 msttcorefonts 软件包（默认情况下，不接受 msttcorefonts 软件包的 EULA）：

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. 声明 /slides-cpp 文件夹为挂载点，以提供对主机上 slides-cpp 源文件夹的访问；构建和运行示例：

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## 构建和运行镜像

1. [在主机系统上安装 Docker](https://docs.docker.com/engine/install/)。

2. 构建镜像。 

   一个工作目录中应该包含上面的 Dockerfile 文件。

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. 下载并解压 [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cpp)。
4. 与 Aspose.Slides for C++ 共享文件夹，以便 Docker 使用它：
   - 在 Windows 中，右键单击任务栏上的 Docker 图标。选择设置。
   - 进入资源 > 文件共享。
5. 通过以下任一方法运行镜像作为容器：

* 方法 A：创建并执行命名容器：

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

对于第二次及后续启动，您必须使用：

```
docker start slides-cpp-ubuntu -i
```

* 方法 B：创建并执行一个未命名的临时容器：

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

您将看到示例项目的构建和执行：

```
-- CXX 编译器识别为 Clang 3.9.1
-- 检查工作 CXX 编译器：/usr/bin/clang++
-- 检查工作 CXX 编译器：/usr/bin/clang++ -- 工作正常
-- 检测 CXX 编译器 ABI 信息
-- 检测 CXX 编译器 ABI 信息 - 完成
-- 检测 CXX 编译特性
-- 检测 CXX 编译特性 - 完成
-- 配置完成
-- 生成完成
-- 构建文件已写入：/slides-cpp/sample/build
扫描目标 Aspose.Slides.Cpp.Examples 的依赖
[ 14%] 正在编译 CXX 对象 CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] 正在编译 CXX 对象 CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] 正在编译 CXX 对象 CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] 正在编译 CXX 对象 CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] 正在编译 CXX 对象 CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] 正在编译 CXX 对象 CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] 正在链接 CXX 可执行文件 Aspose.Slides.Cpp.Examples
[100%] 已构建目标 Aspose.Slides.Cpp.Examples

正在运行示例...

正在运行 Chart::SampleChart...
正在运行 Thumbnail::SampleThumbnail...
正在运行 Text::SampleAddText...
正在运行 SmartArt::SampleCreation...
正在运行 SmartArt::SampleCloning...
正在运行 SmartArt::SampleNodesTextEditing...
正在运行 SmartArt::SampleNodeAdd...
正在运行 SmartArt::SampleColorStyleEditing...
正在运行 SmartArt::SampleQuickStyleEditing...
正在运行 SmartArt::SampleNodeRemove...
正在运行 SmartArt::SampleRemoveSmartArt...
正在运行 PresentationExport::Export...
将演示文稿保存为 PDF...OK
将演示文稿保存为 XPS...OK
将演示文稿保存为 SWF...OK
将演示文稿保存为 HTML...OK
将演示文稿保存为 PDF...OK
将演示文稿保存为 XPS...OK
将演示文稿保存为 SWF...OK
将演示文稿保存为 HTML...OK
```