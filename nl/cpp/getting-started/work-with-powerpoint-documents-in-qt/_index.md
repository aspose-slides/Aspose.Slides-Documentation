---
title: Werk met PowerPoint-documenten in Qt
type: docs
weight: 60
url: /nl/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Qt-toepassing
- cross-platform
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Gebruik Aspose.Slides for C++ met Qt Creator en Visual Studio om PowerPoint- en OpenDocument-presentaties te maken, te laden en te bewerken in cross-platform-apps."
---
## **Inleiding**

Qt is een op C++ gebaseerd, cross‑platform framework voor applicatie‑ontwikkeling dat veel wordt gebruikt om een breed scala aan desktop‑, mobiele en embedded systeemapplicaties te ontwikkelen. Aspose.Slides for C++ kan in Qt worden geïntegreerd om PowerPoint‑documenten te maken en te bewerken in uw Qt‑applicaties.

## **Gebruik van Aspose.Slides for C++ binnen Qt Creator**

Om Aspose.Slides for C++ in uw Qt‑applicatie te gebruiken, downloadt u de nieuwste versie van de API via de [downloads](https://downloads.aspose.com/slides/nl/cpp) sectie. Nadat de API is gedownload, kunt u de C++‑bibliotheek integreren in Qt Creator of Visual Studio.

Om de Aspose.Slides for C++‑bibliotheek te integreren en te gebruiken binnen een Qt Console Application die in Qt Creator is ontwikkeld, volgt u de onderstaande stappen:

- Open Qt Creator en maak een nieuwe *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Selecteer de QMake‑optie in de *Build System* vervolgkeuzelijst.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Kies de juiste kit en rond de wizard af.
- Kopieer de map `aspose-slides-cpp-21.02` uit het uitgepakte pakket van Aspose.Slides for C++ naar de root van het project.

![lib_files](aspose.slides-lib-files.png)

- Om paden naar de lib‑ en include‑mappen toe te voegen, klik met de rechtermuisknop op het project in het linkerpaneel en selecteer *Add Library*.

![qt_add_library](qt_add_library.png)

- Kies de optie **External Library** en blader één voor één naar de include‑ en lib‑mappen.

![todo:image_alt_text](qt-add-external-library.png)

- Na afloop bevat uw `.pro`‑projectbestand de volgende items:

![qt_pro_file.png](qt-pro-file.png)

- Bouw de applicatie en de integratie is voltooid.  

{{% alert color="info" %}}

Opmerking: zie het [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) voor meer informatie.

{{% /alert %}}

## **Gebruik van Aspose.Slides for C++ in Qt‑applicaties binnen Visual Studio**

Om een Qt‑applicatie te ontwikkelen met Visual Studio, moet u [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) installeren. Nadat de installatie is voltooid, downloadt u de nieuwste versie van de API via de [downloads](https://downloads.aspose.com/slides/nl/cpp) sectie en volgt u de onderstaande stappen:

- Open Microsoft Visual Studio en maak een nieuwe *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Kies de juiste kit en rond de wizard af.
- Om de Aspose.Slides for C++‑bibliotheek te integreren en te gebruiken, klik met de rechtermuisknop op het project en selecteer *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Zoek en installeer het benodigde *Aspose.Slides.Cpp*‑pakket.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Bouw het project en de integratie is voltooid.  

{{% alert color="info" %}}

Opmerking: zie het [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) voor meer informatie.

{{% /alert %}}