---
title: Работа с документами PowerPoint в Qt
type: docs
weight: 60
url: /ru/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt Creator
- Приложение Qt
- Кроссплатформенный
- PowerPoint
- OpenDocument
- Презентация
- C++
- Aspose.Slides
description: "Используйте Aspose.Slides for C++ с Qt Creator и Visual Studio для создания, загрузки и редактирования презентаций PowerPoint и OpenDocument в кроссплатформенных приложениях."
---
## **Введение**

Qt — это основанный на C++ кроссплатформенный фреймворк для разработки приложений, широко используемый для создания настольных, мобильных и встроенных систем. Aspose.Slides for C++ может быть интегрирован в Qt для создания и редактирования PowerPoint‑документов в ваших приложениях Qt.

## **Использование Aspose.Slides for C++ в Qt Creator**

Чтобы использовать Aspose.Slides for C++ в вашем приложении Qt, загрузите последнюю версию API из раздела [downloads](https://downloads.aspose.com/slides/ru/cpp). После загрузки API вы можете интегрировать библиотеку C++ в Qt Creator или Visual Studio.

Чтобы интегрировать и использовать библиотеку Aspose.Slides for C++ в консольном приложении Qt, разработанном в Qt Creator, выполните следующие шаги:

- Откройте Qt Creator и создайте новое *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Выберите параметр QMake в выпадающем списке *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Выберите подходящий комплект и завершите мастер.
- Скопируйте папку aspose-slides-cpp-21.02 из распакованного пакета Aspose.Slides for C++ в корень проекта.

![lib_files](aspose.slides-lib-files.png)

- Чтобы добавить пути к папкам lib и include, щелкните правой кнопкой мыши проект в левой панели и выберите *Add Library*.

![qt_add_library](qt_add_library.png)

- Выберите вариант External Library и поочередно укажите пути к папкам include и lib.

![todo:image_alt_text](qt-add-external-library.png)

- После завершения ваш файл проекта *.pro* будет содержать следующие записи:

![qt_pro_file.png](qt-pro-file.png)

- Соберите приложение — интеграция завершена.  

{{% alert color="info" %}}

Примечание: смотрите [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) для получения дополнительной информации.

{{% /alert %}}

## **Использование Aspose.Slides for C++ в приложениях Qt в Visual Studio**

Чтобы разрабатывать приложение Qt с помощью Visual Studio, установите [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). После установки загрузите последнюю версию API из раздела [downloads](https://downloads.aspose.com/slides/ru/cpp) и выполните перечисленные ниже шаги:

- Откройте Microsoft Visual Studio и создайте новое *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Выберите подходящий комплект и завершите мастер.
- Чтобы интегрировать и использовать библиотеку Aspose.Slides for C++, щелкните правой кнопкой мыши проект и выберите *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Найдите и установите требуемый пакет *Aspose.Slides.Cpp*.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Соберите проект — интеграция завершена.  

{{% alert color="info" %}}

Примечание: смотрите [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) для получения дополнительной информации.

{{% /alert %}}