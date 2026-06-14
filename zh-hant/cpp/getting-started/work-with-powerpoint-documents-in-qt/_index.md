---
title: 在 Qt 中操作 PowerPoint 文件
type: docs
weight: 60
url: /zh-hant/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt Creator
- Qt 應用程式
- 跨平台
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 搭配 Qt Creator 與 Visual Studio，在跨平台應用程式中建立、載入與編輯 PowerPoint 與 OpenDocument 簡報。"
---
## **簡介**

Qt 是一個基於 C++ 的跨平台應用程式開發框架，被廣泛用於開發各類桌面、行動與嵌入式系統應用程式。Aspose.Slides for C++ 可整合於 Qt 中，以在您的 Qt 應用程式內建立與操作 PowerPoint 文件。

## **在 Qt Creator 中使用 Aspose.Slides for C++**

若要在 Qt 應用程式中使用 Aspose.Slides for C++，請從[下載](https://downloads.aspose.com/slides/zh-hant/cpp)頁面取得最新版本的 API。下載完成後，即可將 C++ 函式庫整合至 Qt Creator 或 Visual Studio。

若要在 Qt Creator 中建立的 Qt Console Application 中整合與使用 Aspose.Slides for C++ 函式庫，請依照以下步驟操作：

- 開啟 Qt Creator 並建立一個新的 *Qt Console Application*。

![qt_console_application](qt-console-application.png)

- 從 *Build System* 下拉選單中選擇 **QMake**。

![qt_console_application_qmake](qt-console-application-qmake.png)

- 選取適當的 kit，完成精靈設定。
- 將 Aspose.Slides for C++ 之解壓縮套件中的 **aspose-slides-cpp-21.02** 資料夾複製到專案根目錄。

![lib_files](aspose.slides-lib-files.png)

- 為了加入 lib 與 include 資料夾的路徑，於左側面板的專案上點右鍵，選取 *Add Library*。

![qt_add_library](qt_add_library.png)

- 選擇 **External Library**，逐一瀏覽並加入 lib 與 include 資料夾的路徑。

![todo:image_alt_text](qt-add-external-library.png)

- 完成後，您的 *.pro* 專案檔將包含以下條目：

![qt_pro_file.png](qt-pro-file.png)

- 編譯應用程式，即完成整合。  

{{% alert color="primary" %}}

※ 注意：請參考[完整示範專案](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake)以取得更多資訊。

{{% /alert %}}

## **在 Visual Studio 中的 Qt 應用程式中使用 Aspose.Slides for C++**

若要使用 Visual Studio 開發 Qt 應用程式，需先安裝[Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123)。安裝完成後，從[下載](https://downloads.aspose.com/slides/zh-hant/cpp)頁面取得最新版本的 API，並依照以下步驟操作：

- 開啟 Microsoft Visual Studio，建立一個新的 *Qt Console Application*。

![VS_Console_Application.png](vs-console-application.png)

- 選取適當的 kit，完成精靈設定。
- 為了整合與使用 Aspose.Slides for C++ 函式庫，於專案上點右鍵，選取 *Manage NuGet Packages...*。

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- 搜尋並安裝必要的 *Aspose.Slides.Cpp* 套件。

![VS_Find_Nuget.png](vs-find-nuget.png)

- 編譯專案，即完成整合。  

{{% alert color="primary" %}}

※ 注意：請參考[完整示範專案](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS)以取得更多資訊。

{{% /alert %}}