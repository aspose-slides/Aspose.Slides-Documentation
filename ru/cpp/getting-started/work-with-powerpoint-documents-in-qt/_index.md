---
title: Работа с документами PowerPoint в Qt
type: docs
description: "Aspose.Slides для C++ можно интегрировать в Qt для создания и манипулирования документами PowerPoint в приложениях Qt."
keywords: "создание документа в Qt Creator, загрузка документа в Qt Creator, использование Aspose C++ с Qt Creator, загрузка документа Aspose C++, загрузка форматов, поддерживаемых Aspose.Slides C++"
weight: 60
url: /cpp/work-with-powerpoint-documents-in-qt/
---

Qt — это кроссплатформенный фреймворк для разработки приложений на C++, который широко используется для разработки различных настольных, мобильных и встроенных систем. Aspose.Slides для C++ можно интегрировать в Qt для создания и манипулирования документами PowerPoint в ваших приложениях Qt.

## Использование Aspose.Slides для C++ в Qt Creator

Для использования Aspose.Slides для C++ в вашем приложении Qt загрузите последнюю версию API из раздела [downloads](https://downloads.aspose.com/slides/cpp). После загрузки API вы можете интегрировать библиотеку C++ в Qt Creator или Visual Studio.

Чтобы интегрировать и использовать библиотеку Aspose.Slides для C++ в консольном приложении Qt, разработанном в Qt Creator, выполните следующие шаги:

- Откройте Qt Creator и создайте новое *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Выберите опцию QMake из выпадающего списка *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Выберите соответствующий набор и завершите мастер.
- Скопируйте папку aspose-slides-cpp-21.02 из извлеченного пакета Aspose.Slides для C++ в корень проекта.

![lib_files](aspose.slides-lib-files.png)

- Чтобы добавить пути к библиотекам и заголовкам, щелкните правой кнопкой мыши на проекте в левой панели и выберите *Add Library*.

![qt_add_library](qt_add_library.png)

- Выберите опцию External Library и поочередно выберите пути к папкам с библиотеками.

![todo:image_alt_text](qt-add-external-library.png)

- После завершения ваш .pro файл проекта будет содержать следующие записи:

![qt_pro_file.png](qt-pro-file.png)

- Постройте приложение, и интеграция завершена.  

{{% alert color="primary" %}}

Примечание: См. [полный демонстрационный проект](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) для получения дополнительной информации.

{{% /alert %}}

## Использование Aspose.Slides для C++ в приложениях Qt в Visual Studio

Чтобы разработать приложение Qt с использованием Visual Studio, вам необходимо установить [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). После установки загрузите последнюю версию API из раздела [downloads](https://downloads.aspose.com/slides/cpp) и выполните следующие шаги:

- Откройте Microsoft Visual Studio и создайте новое *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Выберите соответствующий набор и завершите мастер.
- Чтобы интегрировать и использовать библиотеку Aspose.Slides для C++, щелкните правой кнопкой мыши на проекте и выберите *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Найдите и установите необходимый пакет *Aspose.Slides.Cpp*.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Постройте проект, и интеграция завершена.  

{{% alert color="primary" %}}

Примечание: См. [полный демонстрационный проект](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) для получения дополнительной информации.

{{% /alert %}}