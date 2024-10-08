---
title: 在 Qt 中处理 PowerPoint 文档
type: docs
description: "Aspose.Slides for C++ 可以集成到 Qt 中，以在 Qt 应用程序中创建和处理 PowerPoint 文档。"
keywords: "在 Qt Creator 中创建文档, 在 Qt Creator 中加载文档, 在 Qt Creator 中使用 Aspose C++, 加载 Aspose C++ 文档, 加载 Aspose.Slides C++ 支持的格式"
weight: 60
url: /cpp/work-with-powerpoint-documents-in-qt/
---

Qt 是一个基于 C++ 的跨平台应用程序开发框架，广泛用于开发各种桌面、移动和嵌入式系统应用程序。Aspose.Slides for C++ 可以集成到 Qt 中，以便在您的 Qt 应用程序中创建和处理 PowerPoint 文档。

## 在 Qt Creator 中使用 Aspose.Slides for C++

为了在您的 Qt 应用程序中使用 Aspose.Slides for C++，请从 [downloads](https://downloads.aspose.com/slides/cpp) 部分下载 API 的最新版本。下载 API 后，您可以将 C++ 库集成到 Qt Creator 或 Visual Studio 中。

要在 Qt Creator 中开发的 Qt 控制台应用程序中集成并使用 Aspose.Slides for C++ 库，请按照以下步骤操作：

- 打开 Qt Creator 并创建一个新的 *Qt 控制台应用程序*。

![qt_console_application](qt-console-application.png)

- 从 *构建系统* 下拉列表中选择 QMake 选项。

![qt_console_application_qmake](qt-console-application-qmake.png)

- 选择适当的工具包并完成向导。
- 将 aspose-slides-cpp-21.02 文件夹从 Aspose.Slides for C++ 的解压包复制到项目根目录。

![lib_files](aspose.slides-lib-files.png)

- 为了添加 lib 和 include 文件夹的路径，右键单击左侧面板中的项目并选择 *添加库*。

![qt_add_library](qt_add_library.png)

- 选择外部库选项，并逐个浏览路径以包含 lib 文件夹。

![todo:image_alt_text](qt-add-external-library.png)

- 完成后，您的 .pro 项目文件将包含以下条目：

![qt_pro_file.png](qt-pro-file.png)

- 构建应用程序，您就完成了集成。

{{% alert color="primary" %}}

注意：有关更多信息，请参见 [完整演示项目](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake)。

{{% /alert %}}

## 在 Visual Studio 中的 Qt 应用程序中使用 Aspose.Slides for C++

要使用 Visual Studio 开发 Qt 应用程序，您需要安装 [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123)。安装完成后，从 [downloads](https://downloads.aspose.com/slides/cpp) 部分下载 API 的最新版本，并按照以下步骤操作：

- 打开 Microsoft Visual Studio，创建一个新的 *Qt 控制台应用程序*。

![VS_Console_Application.png](vs-console-application.png)

- 选择适当的工具包并完成向导。
- 为了集成和使用 Aspose.Slides for C++ 库，右键单击项目并选择 *管理 NuGet 包...*。

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- 查找并安装所需的 *Aspose.Slides.Cpp* 包。

![VS_Find_Nuget.png](vs-find-nuget.png)

- 构建项目，您就完成了集成。

{{% alert color="primary" %}}

注意：有关更多信息，请参见 [完整演示项目](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS)。

{{% /alert %}}