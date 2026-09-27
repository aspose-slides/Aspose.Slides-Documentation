---
title: 安装
type: docs
weight: 70
url: /zh/cpp/installation/
keywords:
- 安装 Aspose.Slides
- 下载 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Windows 上通过 Visual Studio 从 NuGet 安装 Aspose.Slides for C++，或在 Linux 上使用带 CMake 的 ZIP 包进行安装，并通过第一个程序检查安装是否成功。"
---
## **概述**

Aspose.Slides for C++ 以两种形式分发：

| 形式 | 用途 | 获取位置 |
|---|---|---|
| NuGet 包： [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/)（64 位）和 [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/)（32 位） | Windows 上的 Visual Studio C++ 项目 | NuGet |
| Windows、Linux 和 macOS 的 ZIP 包 | 不使用 NuGet 的构建，例如 CMake 项目 | [下载页面](https://releases.aspose.com/slides/cpp/) |

本文介绍如何在 Windows 上的 Visual Studio 中安装 NuGet 包，以及如何在 Linux 上使用 CMake 使用 ZIP 包。两种方式的最终步骤相同：构建并运行 [Create Presentations](/slides/zh/cpp/create-presentation/) 中的第一个示例。

## **Windows**

在 Windows 上，将 NuGet 包添加到 Visual Studio C++ 项目中。该包还会安装其依赖项 CodePorting.Translator.Cs2Cpp.Framework，并将程序所需的 DLL 复制到生成输出文件夹。

根据要构建的平台选择包：x64 使用 **Aspose.Slides.Cpp**，Win32 (x86) 使用 **Aspose.Slides.Cpp.x86**。Aspose.Slides.Cpp 包不适用于 Win32 构建，因此编译器在该环境中找不到其头文件。

Windows ZIP 包也可在[下载页面](https://releases.aspose.com/slides/cpp/)获取。

### **方法 1：通过 NuGet 包管理器安装或更新 Aspose.Slides**

1. 打开 Microsoft Visual Studio。  
2. 创建一个 C++ **Console App** 项目，或打开现有项目。  
3. 在 **Solution Explorer** 中，右键单击项目并选择 **Manage NuGet Packages**（或转到 **Project** > **Manage NuGet Packages**）。  
4. 在 **Browse** 下，搜索 *Aspose.Slides.Cpp*。  
![在 NuGet 包管理器中搜索 Aspose.Slides.Cpp](installation_1.png)  
5. 点击 **Aspose.Slides.Cpp**（或针对 32 位构建的 **Aspose.Slides.Cpp.x86**），然后点击 **Install**。  
   * 如果您已经安装了 Aspose.Slides 并想更新它，请改为点击 **Update**。  

该包已下载并在项目中引用。

### **方法 2：通过包管理器控制台安装或更新 Aspose.Slides**

1. 打开 Microsoft Visual Studio。  
2. 创建一个 C++ **Console App** 项目，或打开现有项目。  
3. 前往 **Tools** > **NuGet Package Manager** > **Package Manager Console**。  
![打开包管理器控制台](installation_2.png)  
4. 运行以下命令：

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   对于 32 位 (Win32) 构建，请改为安装 x86 包：

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![运行 Install-Package 命令](installation_3.png)

当安装完成后，会出现确认消息。该包遵循 [Aspose EULA](https://about.aspose.com/legal/eula) 分发。  
![安装确认消息](installation_4.png)

要更新包，请在包管理器控制台中运行 `Update-Package Aspose.Slides.Cpp`（或 `Update-Package Aspose.Slides.Cpp.x86`）。

### **检查安装**

1. 用 [Create Presentations](/slides/zh/cpp/create-presentation/) 中的第一个示例替换项目的主 *.cpp* 文件（包含 `main` 的文件）的内容。  
2. 在工具栏中选择 **x64** 平台，若已安装 Aspose.Slides.Cpp.x86，则选择 **x86**。  
3. 按 **Ctrl+F5** 构建并运行程序。  

程序会在项目文件夹中保存 *hello.pptx*，这是 Visual Studio 运行程序时的默认工作目录。

## **Linux**

在 Linux 上，使用带有 CMake 的 Linux ZIP 包。该包包含 Aspose.Slides 库、其依赖项 CodePorting.Translator.Cs2Cpp.Framework，以及每个库的 CMake 配置文件。这些库针对 glibc 2.23 或更高版本的 x86_64 Linux 构建。

1. 安装 C++ 编译器、make、CMake、unzip 以及 Aspose.Slides 库依赖的 fontconfig 库。在 Debian 和 Ubuntu 上：

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. 创建项目文件夹并进入该文件夹：

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. 从[下载页面](https://releases.aspose.com/slides/cpp/)下载 Linux ZIP（**Aspose.Slides for C++ Linux**），保存到项目文件夹，并将其解压到 *aspose-slides-cpp* 子文件夹中：

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. 在项目文件夹中创建名为 *CMakeLists.txt* 的文件，内容如下：

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   这两个 `find_package` 调用从解压的包加载 CMake 配置文件。首先找到框架，因为 Aspose.Slides 依赖它。链接 `Aspose.Slides.Cpp` 目标会将包含文件夹和两个库添加到构建中。

5. 将 [Create Presentations](/slides/zh/cpp/create-presentation/) 中的第一个示例保存为项目文件夹中的 *main.cpp*。  
6. 构建并运行程序：

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

程序会在当前文件夹中保存 *hello.pptx*。CMake 在程序中记录库的位置，因此只要 *aspose-slides-cpp* 文件夹保持在原位，就无需设置 `LD_LIBRARY_PATH`。

为了在将幻灯片转换为 PDF 或图像时正确呈现文本，必须在系统上安装演示文稿使用的字体或合适的替代字体。

## **常见问题**

**是否有免费版本或试用限制？**  
是的。未授权时，Aspose.Slides 以评估模式运行：会在保存的每张幻灯片上添加评估水印，并截断从演示文稿读取的文本。要消除这些限制，请使用有效的 [license](/slides/zh/cpp/licensing/)。

**为什么编译器报告无法打开 *DOM/Presentation.h*？**  
已安装的包与您构建的平台不匹配。Aspose.Slides.Cpp 仅适用于 x64 构建，Aspose.Slides.Cpp.x86 仅适用于 Win32 构建。请在 Visual Studio 中选择相匹配的平台，或安装另一个包。