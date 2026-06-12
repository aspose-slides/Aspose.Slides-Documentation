---
title: Práce s dokumenty PowerPoint v Qt
type: docs
weight: 60
url: /cs/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Qt aplikace
- multiplatformní
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Použijte Aspose.Slides for C++ s Qt Creatorem a Visual Studiem k vytváření, načítání a úpravě prezentací PowerPoint a OpenDocument v multiplatformních aplikacích."
---
## **Úvod**

Qt je na C++ založený multiplatformní rámec pro vývoj aplikací, který se široce používá k vývoji různých desktopových, mobilních a vestavěných systémových aplikací. Aspose.Slides for C++ lze integrovat do Qt za účelem vytváření a manipulace s dokumenty PowerPoint ve vašich Qt aplikacích.

## **Používání Aspose.Slides for C++ v Qt Creatoru**

Chcete-li používat Aspose.Slides for C++ ve své Qt aplikaci, stáhněte si nejnovější verzi API ze sekce [downloads](https://downloads.aspose.com/slides/cs/cpp). Po stažení API můžete knihovnu C++ integrovat do Qt Creatoru nebo Visual Studia.

Pro integraci a použití knihovny Aspose.Slides for C++ v Qt Console Application vyvinuté v Qt Creatoru následujte níže uvedené kroky:

- Otevřete Qt Creator a vytvořte novou *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Vyberte možnost QMake v rozbalovacím seznamu *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Vyberte vhodný kit a dokončete průvodce.
- Zkopírujte složku aspose-slides-cpp-21.02 z rozbaleného balíčku Aspose.Slides for C++ do kořenového adresáře projektu.

![lib_files](aspose.slides-lib-files.png)

- Pro přidání cest k složkám lib a include klikněte pravým tlačítkem na projekt v levém panelu a vyberte *Add Library*.

![qt_add_library](qt_add_library.png)

- Vyberte možnost External Library a procházejte cesty ke složkám lib jednotlivě.

![todo:image_alt_text](qt-add-external-library.png)

- Po dokončení bude váš .pro soubor projektu obsahovat následující položky:

![qt_pro_file.png](qt-pro-file.png)

- Postavte aplikaci a integrace je dokončena.  

{{% alert color="primary" %}}

Poznámka: Viz [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) pro více informací.

{{% /alert %}}

## **Používání Aspose.Slides for C++ v Qt aplikacích ve Visual Studiu**

Chcete-li vyvíjet Qt aplikaci pomocí Visual Studia, musíte nainstalovat [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Po instalaci stáhněte nejnovější verzi API ze sekce [downloads](https://downloads.aspose.com/slides/cs/cpp) a postupujte podle níže uvedených kroků:

- Otevřete Microsoft Visual Studio a vytvořte novou *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Vyberte vhodný kit a dokončete průvodce.
- Pro integraci a použití knihovny Aspose.Slides for C++ klikněte pravým tlačítkem na projekt a vyberte *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Najděte a nainstalujte požadovaný balíček *Aspose.Slides.Cpp*.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Postavte projekt a integrace je dokončena.  

{{% alert color="primary" %}}

Poznámka: Viz [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) pro více informací.

{{% /alert %}}