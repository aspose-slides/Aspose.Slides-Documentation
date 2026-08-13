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
description: "Použijte Aspose.Slides pro C++ s Qt Creator a Visual Studio k vytváření, načítání a úpravě prezentací PowerPoint a OpenDocument v multiplatformních aplikacích."
---
## **Úvod**

Qt je multiplatformní vývojový rámec založený na C++, který se široce používá pro vývoj různých desktopových, mobilních a vestavěných aplikací. Aspose.Slides pro C++ lze integrovat do Qt za účelem vytváření a manipulace s dokumenty PowerPoint ve vašich Qt aplikacích.

## **Používání Aspose.Slides pro C++ v Qt Creatoru**

Chcete‑li použít Aspose.Slides pro C++ ve své Qt aplikaci, stáhněte si nejnovější verzi API ze sekce [downloads](https://downloads.aspose.com/slides/cs/cpp). Po stažení API můžete knihovnu C++ integrovat do Qt Creatoru nebo Visual Studia.

Pro integraci a použití knihovny Aspose.Slides pro C++ v Qt Console Application vyvinuté v Qt Creatoru postupujte podle níže uvedených kroků:

- Otevřete Qt Creator a vytvořte novou *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Vyberte možnost QMake v rozbalovacím seznamu *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Vyberte vhodný kit a dokončete průvodce.
- Zkopírujte složku aspose‑slides‑cpp‑21.02 z rozbaleného balíčku Aspose.Slides pro C++ do kořenové složky projektu.

![lib_files](aspose.slides-lib-files.png)

- Pro přidání cest k lib a include složkám klikněte pravým tlačítkem na projekt v levém panelu a zvolte *Add Library*.

![qt_add_library](qt_add_library.png)

- Vyberte možnost External Library a postupně procházejte cesty k include a lib složkám.

![todo:image_alt_text](qt-add-external-library.png)

- Po dokončení bude váš soubor .pro obsahovat následující položky:

![qt_pro_file.png](qt-pro-file.png)

- Sestavte aplikaci a integrace je hotová.  

{{% alert color="info" %}}

Poznámka: Viz [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) pro více informací.

{{% /alert %}}

## **Používání Aspose.Slides pro C++ v Qt aplikacích ve Visual Studiu**

Chcete‑li vyvíjet Qt aplikaci pomocí Visual Studia, musíte nainstalovat [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Po instalaci stáhněte nejnovější verzi API ze sekce [downloads](https://downloads.aspose.com/slides/cs/cpp) a postupujte podle níže uvedených kroků:

- Otevřete Microsoft Visual Studio a vytvořte novou *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Vyberte vhodný kit a dokončete průvodce.
- Pro integraci a použití knihovny Aspose.Slides pro C++ klikněte pravým tlačítkem na projekt a zvolte *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Vyhledejte a nainstalujte požadovaný balíček *Aspose.Slides.Cpp*.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Sestavte projekt a integrace je hotová.  

{{% alert color="info" %}}

Poznámka: Viz [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) pro více informací.

{{% /alert %}}