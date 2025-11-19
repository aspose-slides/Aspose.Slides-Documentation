---
title: Work with PowerPoint Documents in Qt
type: docs
weight: 60
url: /cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Qt application
- cross-platform
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Use Aspose.Slides for C++ with Qt Creator and Visual Studio to create, load, and edit PowerPoint and OpenDocument presentations in cross-platform apps."
---

Qt is a C++ based cross-platform application development framework which is widely used to develop a variety of desktop, mobile, and embedded system applications. Aspose.Slides for C++ can be integrated within Qt in order to create and manipulate PowerPoint documents in your Qt applications.

## Using Aspose.Slides for C++ within Qt Creator

In order to use Aspose.Slides for C++ in your Qt application download the latest version of the API from the [downloads](https://downloads.aspose.com/slides/cpp) section. Once the API is downloaded, you can integrate the C++ library within Qt Creator or Visual Studio.

In order to integrate and use Aspose.Slides for C++ library within a Qt Console Application developed in Qt Creator, please follow the steps given below:

- Open Qt Creator and create a new *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Select the QMake option from the *Build System* dropdown list.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Select the appropriate kit and finish the wizard.
- Copy aspose-slides-cpp-21.02 folder from the extracted package of Aspose.Slides for C++ into the root of the project.

![lib_files](aspose.slides-lib-files.png)

- In order to add paths to lib and include folders, right-click on the project in the LHS panel and select *Add Library*.

![qt_add_library](qt_add_library.png)

- Select the External Library option and browse paths to include lib folders one by one.

![todo:image_alt_text](qt-add-external-library.png)

- Once done, your .pro project file will contain the following entries:

![qt_pro_file.png](qt-pro-file.png)

- Build the application and you are done with the integration.  

{{% alert color="primary" %}}

Note: See the [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) for more information.

{{% /alert %}}

## Using Aspose.Slides for C++ in Qt Applications within Visual Studio

In order to develop a Qt application using Visual Studio, you need to install [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Once you have the installation, download the latest version of the API from the [downloads](https://downloads.aspose.com/slides/cpp) section and follow the steps given below:

- Open Microsoft Visual Studio and create a new *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Select the appropriate kit and finish the wizard.
- In order to integrate and use Aspose.Slides for C++ library, right-click on the project and select *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Find and install the required *Aspose.Slides.Cpp* package.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Build the project and you are done with the integration.  

{{% alert color="primary" %}}

Note: See the [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) for more information.

{{% /alert %}}
