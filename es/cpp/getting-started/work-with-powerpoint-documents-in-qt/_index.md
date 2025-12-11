---
title: Trabajar con documentos PowerPoint en Qt
type: docs
weight: 60
url: /es/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Creador de Qt
- Aplicación Qt
- multiplataforma
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Utilice Aspose.Slides para C++ con Qt Creator y Visual Studio para crear, cargar y editar presentaciones PowerPoint y OpenDocument en aplicaciones multiplataforma."
---

Qt es un framework de desarrollo de aplicaciones multiplataforma basado en C++ que se utiliza ampliamente para crear una variedad de aplicaciones de escritorio, móviles y de sistemas embebidos. Aspose.Slides for C++ se puede integrar con Qt para crear y manipular documentos PowerPoint en sus aplicaciones Qt.

## **Uso de Aspose.Slides for C++ dentro de Qt Creator**

Para usar Aspose.Slides for C++ en su aplicación Qt, descargue la última versión de la API desde la sección [downloads](https://downloads.aspose.com/slides/cpp). Una vez descargada la API, puede integrar la biblioteca C++ dentro de Qt Creator o Visual Studio.

Para integrar y usar la biblioteca Aspose.Slides for C++ dentro de una Aplicación de Consola Qt desarrollada en Qt Creator, siga los pasos a continuación:

- Abra Qt Creator y cree una nueva *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Seleccione la opción QMake en la lista desplegable *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Seleccione el kit apropiado y termine el asistente.
- Copie la carpeta aspose-slides-cpp-21.02 del paquete extraído de Aspose.Slides for C++ al directorio raíz del proyecto.

![lib_files](aspose.slides-lib-files.png)

- Para agregar rutas a las carpetas lib e include, haga clic con el botón derecho en el proyecto en el panel izquierdo y seleccione *Add Library*.

![qt_add_library](qt_add_library.png)

- Seleccione la opción External Library y busque las rutas a las carpetas lib una por una.

![todo:image_alt_text](qt-add-external-library.png)

- Una vez hecho, su archivo de proyecto .pro contendrá las siguientes entradas:

![qt_pro_file.png](qt-pro-file.png)

- Compile la aplicación y habrá terminado la integración.  

{{% alert color="primary" %}}

Nota: Consulte el [proyecto de demostración completo](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) para obtener más información.

{{% /alert %}}

## **Uso de Aspose.Slides for C++ en aplicaciones Qt dentro de Visual Studio**

Para desarrollar una aplicación Qt usando Visual Studio, necesita instalar [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Una vez instalada, descargue la última versión de la API desde la sección [downloads](https://downloads.aspose.com/slides/cpp) y siga los pasos a continuación:

- Abra Microsoft Visual Studio y cree una nueva *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Seleccione el kit apropiado y termine el asistente.
- Para integrar y usar la biblioteca Aspose.Slides for C++, haga clic con el botón derecho en el proyecto y seleccione *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Busque e instale el paquete *Aspose.Slides.Cpp* requerido.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Compile el proyecto y habrá terminado la integración.  

{{% alert color="primary" %}}

Nota: Consulte el [proyecto de demostración completo](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) para obtener más información.

{{% /alert %}}