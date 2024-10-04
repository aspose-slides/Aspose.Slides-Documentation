---
title: Trabajar con Documentos de PowerPoint en Qt
type: docs
description: "Aspose.Slides para C++ se puede integrar dentro de Qt para crear y manipular documentos de PowerPoint en aplicaciones Qt."
keywords: "crear un documento Qt Creator, cargar un documento Qt Creator, usar Aspose C++ con Qt creator, cargar un documento Aspose C++, cargar formatos soportados por Aspose.Slides C++"
weight: 60
url: /cpp/work-with-powerpoint-documents-in-qt/
---

Qt es un marco de desarrollo de aplicaciones multiplataforma basado en C++ que se utiliza ampliamente para desarrollar una variedad de aplicaciones de escritorio, móviles y de sistemas embebidos. Aspose.Slides para C++ se puede integrar dentro de Qt para crear y manipular documentos de PowerPoint en sus aplicaciones Qt.

## Usando Aspose.Slides para C++ dentro de Qt Creator

Para usar Aspose.Slides para C++ en su aplicación Qt, descargue la última versión de la API de la sección de [descargas](https://downloads.aspose.com/slides/cpp). Una vez que se haya descargado la API, puede integrar la biblioteca C++ dentro de Qt Creator o Visual Studio.

Para integrar y usar la biblioteca Aspose.Slides para C++ dentro de una Aplicación de Consola Qt desarrollada en Qt Creator, siga los pasos que se indican a continuación:

- Abra Qt Creator y cree una nueva *Aplicación de Consola Qt*.

![qt_console_application](qt-console-application.png)

- Seleccione la opción QMake del menú desplegable *Sistema de Construcción*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Seleccione el kit apropiado y termine el asistente.
- Copie la carpeta aspose-slides-cpp-21.02 del paquete extraído de Aspose.Slides para C++ en la raíz del proyecto.

![lib_files](aspose.slides-lib-files.png)

- Para agregar rutas a las carpetas lib e include, haga clic derecho en el proyecto en el panel izquierdo y seleccione *Agregar Biblioteca*.

![qt_add_library](qt_add_library.png)

- Seleccione la opción Biblioteca Externa y navegue por las rutas para incluir las carpetas lib una por una.

![todo:image_alt_text](qt-add-external-library.png)

- Una vez hecho esto, su archivo de proyecto .pro contendrá las siguientes entradas:

![qt_pro_file.png](qt-pro-file.png)

- Compile la aplicación y habrá terminado con la integración.  

{{% alert color="primary" %}}

Nota: Consulte el [proyecto de demostración completo](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) para más información.

{{% /alert %}}

## Usando Aspose.Slides para C++ en Aplicaciones Qt dentro de Visual Studio

Para desarrollar una aplicación Qt usando Visual Studio, necesita instalar [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Una vez que tenga la instalación, descargue la última versión de la API de la sección de [descargas](https://downloads.aspose.com/slides/cpp) y siga los pasos que se indican a continuación:

- Abra Microsoft Visual Studio y cree una nueva *Aplicación de Consola Qt*.

![VS_Console_Application.png](vs-console-application.png)

- Seleccione el kit apropiado y termine el asistente.
- Para integrar y usar la biblioteca Aspose.Slides para C++, haga clic derecho en el proyecto y seleccione *Administrar Paquetes NuGet...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Encuentre e instale el paquete requerido *Aspose.Slides.Cpp*.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Compile el proyecto y habrá terminado con la integración.  

{{% alert color="primary" %}}

Nota: Consulte el [proyecto de demostración completo](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) para más información.

{{% /alert %}}