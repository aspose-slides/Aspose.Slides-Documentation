---
title: PowerPoint‑documenten gebruiken in Qt
type: docs
weight: 60
url: /nl/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Qt‑applicatie
- platformonafhankelijk
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Gebruik Aspose.Slides voor C++ met Qt Creator en Visual Studio om PowerPoint‑ en OpenDocument‑presentaties te maken, te laden en te bewerken in platformonafhankelijke apps."
---
## **Introductie**

Qt is een C++‑gebaseerd, platformonafhankelijk toepassingsontwikkelframework dat veelvuldig wordt gebruikt om verschillende desktop‑, mobiele‑ en embedded‑systeemapplicaties te ontwikkelen. Aspose.Slides voor C++ kan worden geïntegreerd in Qt om PowerPoint‑documenten te maken en te bewerken in uw Qt‑applicaties.

## **Aspose.Slides voor C++ gebruiken binnen Qt Creator**

Om Aspose.Slides voor C++ in uw Qt‑applicatie te gebruiken, downloadt u de nieuwste versie van de API vanuit de [downloads](https://downloads.aspose.com/slides/nl/cpp) sectie. Zodra de API is gedownload, kunt u de C++‑bibliotheek integreren in Qt Creator of Visual Studio.

Om de Aspose.Slides voor C++‑bibliotheek te integreren en te gebruiken binnen een Qt Console Application die in Qt Creator is ontwikkeld, volgt u de onderstaande stappen:

- Open Qt Creator en maak een nieuwe *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Selecteer de QMake‑optie in de vervolgkeuzelijst *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Selecteer de juiste kit en voltooi de wizard.
- Kopieer de map aspose-slides-cpp-21.02 uit het uitgepakte pakket van Aspose.Slides voor C++ naar de hoofdmap van het project.

![lib_files](aspose.slides-lib-files.png)

- Om paden naar lib‑ en include‑mappen toe te voegen, klikt u met de rechtermuisknop op het project in het linkerpaneel en selecteert u *Add Library*.

![qt_add_library](qt_add_library.png)

- Selecteer de optie External Library en blader naar de lib‑mappen één voor één.

![todo:image_alt_text](qt-add-external-library.png)

- Na afloop zal uw .pro‑projectbestand de volgende vermeldingen bevatten:

![qt_pro_file.png](qt-pro-file.png)

- Bouw de applicatie en de integratie is voltooid.  

{{% alert color="primary" %}}

Opmerking: zie het [volledige demoproject](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) voor meer informatie.

{{% /alert %}}

## **Aspose.Slides voor C++ gebruiken in Qt‑applicaties binnen Visual Studio**

Om een Qt‑applicatie te ontwikkelen met Visual Studio, moet u [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) installeren. Nadat de installatie is voltooid, downloadt u de nieuwste versie van de API vanuit de [downloads](https://downloads.aspose.com/slides/nl/cpp) sectie en volgt u de onderstaande stappen:

- Open Microsoft Visual Studio en maak een nieuwe *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Selecteer de juiste kit en voltooi de wizard.
- Om de Aspose.Slides voor C++‑bibliotheek te integreren en te gebruiken, klikt u met de rechtermuisknop op het project en selecteert u *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Zoek en installeer het benodigde *Aspose.Slides.Cpp*‑pakket.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Bouw het project en de integratie is voltooid.  

{{% alert color="primary" %}}

Opmerking: zie het [volledige demoproject](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) voor meer informatie.

{{% /alert %}}