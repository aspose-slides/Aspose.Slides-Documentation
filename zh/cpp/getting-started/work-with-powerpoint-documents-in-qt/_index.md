---
title: 在 Qt 中处理 PowerPoint 文档
type: docs
weight: 60
url: /zh/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt Creator
- Qt 应用程序
- 跨平台
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 与 Qt Creator 和 Visual Studio 在跨平台应用中创建、加载和编辑 PowerPoint 与 OpenDocument 演示文稿。"
---

Qt 是一个基于 C++ 的跨平台应用程序开发框架，广泛用于开发各种桌面、移动和嵌入式系统应用程序。Aspose.Slides for C++ 可以集成到 Qt 中，以在 Qt 应用程序中创建和操作 PowerPoint 文档。

## **在 Qt Creator 中使用 Aspose.Slides for C++**

要在 Qt 应用程序中使用 Aspose.Slides for C++，请从 [downloads](https://downloads.aspose.com/slides/cpp) 部分下载最新版本的 API。下载后，即可在 Qt Creator 或 Visual Studio 中集成该 C++ 库。

要在 Qt Creator 中开发的 Qt 控制台应用程序中集成并使用 Aspose.Slides for C++ 库，请按照以下步骤操作：

- 打开 Qt Creator 并创建一个新的 *Qt Console Application*。

![qt_console_application](qt-console-application.png)

- 从 *Build System* 下拉列表中选择 QMake 选项。

![qt_console_application_qmake](qt-console-application-qmake.png)

- 选择合适的工具包并完成向导。
- 将 Aspose.Slides for C++ 解压包中的 aspose-slides-cpp-21.02 文件夹复制到项目根目录。

![lib_files](aspose.slides-lib-files.png)

- 为了添加 lib 和 include 文件夹的路径，右键单击左侧面板中的项目并选择 *Add Library*。

![qt_add_library](qt_add_library.png)

- 选择 External Library 选项，逐一浏览并添加 lib 和 include 文件夹的路径。

![todo:image_alt_text](qt-add-external-library.png)

- 完成后，您的 .pro 项目文件将包含以下条目：

![qt_pro_file.png](qt-pro-file.png)

- 构建应用程序，即完成集成。  

{{% alert color="primary" %}}

注意：请参阅 [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) 获取更多信息。

{{% /alert %}}

## **在 Visual Studio 中的 Qt 应用程序中使用 Aspose.Slides for C++**

要使用 Visual Studio 开发 Qt 应用程序，需要安装 [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123)。安装完成后，从 [downloads](https://downloads.aspose.com/slides/cpp) 部分下载最新版本的 API，并按照以下步骤操作：

- 打开 Microsoft Visual Studio 并创建一个新的 *Qt Console Application*。

![VS_Console_Application.png](vs-console-application.png)

- 选择合适的工具包并完成向导。
- 为了集成并使用 Aspose.Slides for C++ 库，右键单击项目并选择 *Manage NuGet Packages...*。

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- 查找并安装所需的 *Aspose.Slides.Cpp* 包。

![VS_Find_Nuget.png](vs-find-nuget.png)

- 构建项目，即完成集成。  

{{% alert color="primary" %}}

注意：请参阅 [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) 获取更多信息。

{{% /alert %}}