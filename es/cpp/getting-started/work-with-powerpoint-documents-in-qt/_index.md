---
title: Trabajar con documentos PowerPoint en Qt
type: docs
weight: 60
url: /es/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt Creator
- Aplicación Qt
- multiplataforma
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Utilice Aspose.Slides para C++ con Qt Creator y Visual Studio para crear, cargar y editar presentaciones PowerPoint y OpenDocument en aplicaciones multiplataforma."
---
## **Introducción**

Qt es un framework de desarrollo de aplicaciones multiplataforma basado en C++ que se utiliza ampliamente para crear una variedad de aplicaciones de escritorio, móviles y sistemas empotrados. Aspose.Slides para C++ puede integrarse con Qt para crear y manipular documentos PowerPoint en sus aplicaciones Qt.

## **Usar Aspose.Slides para C++ dentro de Qt Creator**

Para usar Aspose.Slides para C++ en su aplicación Qt, descargue la última versión de la API desde la sección [downloads](https://downloads.aspose.com/slides/es/cpp). Una vez descargada la API, puede integrar la biblioteca C++ en Qt Creator o Visual Studio.

Para integrar y usar la biblioteca Aspose.Slides para C++ dentro de una aplicación de consola Qt desarrollada en Qt Creator, siga los pasos que se indican a continuación:

- Abra Qt Creator y cree una nueva *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Seleccione la opción QMake en la lista desplegable *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Seleccione el kit adecuado y complete el asistente.
- Copie la carpeta aspose-slides-cpp-21.02 del paquete extraído de Aspose.Slides para C++ en la raíz del proyecto.

![lib_files](aspose.slides-lib-files.png)

- Para añadir rutas a las carpetas lib y include, haga clic con el botón derecho en el proyecto en el panel LHS y seleccione *Add Library*.

![qt_add_library](qt_add_library.png)

- Seleccione la opción External Library y busque las rutas a las carpetas lib una a una.

![todo:image_alt_text](qt-add-external-library.png)

- Una vez hecho esto, su archivo de proyecto .pro contendrá las siguientes entradas:

![qt_pro_file.png](qt-pro-file.png)

- Compile la aplicación y ya habrá completado la integración.  

{{% alert color="info" %}}
Nota: Consulte el [proyecto de demostración completo](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) para obtener más información.
{{% /alert %}}

## **Usar Aspose.Slides para C++ en aplicaciones Qt con Visual Studio**

Para desarrollar una aplicación Qt utilizando Visual Studio, necesita instalar [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Una vez instalada, descargue la última versión de la API desde la sección [downloads](https://downloads.aspose.com/slides/es/cpp) y siga los pasos que se indican a continuación:

- Abra Microsoft Visual Studio y cree una nueva *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Seleccione el kit adecuado y complete el asistente.
- Para integrar y usar la biblioteca Aspose.Slides para C++, haga clic con el botón derecho en el proyecto y seleccione *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Busque e instale el paquete *Aspose.Slides.Cpp* requerido.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Compile el proyecto y ya habrá completado la integración.  

{{% alert color="info" %}}
Nota: Consulte el [proyecto de demostración completo](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) para obtener más información.
{{% /alert %}}