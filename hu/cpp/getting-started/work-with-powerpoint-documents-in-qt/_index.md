---
title: PowerPoint dokumentumok kezelése Qt-ben
type: docs
weight: 60
url: /hu/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Qt alkalmazás
- többplatformos
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Használja az Aspose.Slides for C++-t a Qt Creatorral és a Visual Studio-val, hogy többplatformos alkalmazásokban PowerPoint és OpenDocument prezentációkat hozzon létre, töltsön be és szerkesszen."
---
## **Bevezetés**

Qt egy C++ alapú, többplatformos alkalmazásfejlesztő keretrendszer, amelyet széles körben használnak különféle asztali, mobil és beágyazott rendszerek alkalmazásainak fejlesztésére. Az Aspose.Slides for C++ integrálható a Qt-be, hogy PowerPoint dokumentumokat hozzon létre és manipuláljon Qt alkalmazásaiban.

## **Az Aspose.Slides for C++ használata a Qt Creatorban**

Az Aspose.Slides for C++ Qt alkalmazásban való használatához töltse le a legújabb API-verziót a [downloads](https://downloads.aspose.com/slides/hu/cpp) szakaszból. Miután az API letöltésre került, integrálhatja a C++ könyvtárat a Qt Creatorba vagy a Visual Studio-ba.

Az Aspose.Slides for C++ könyvtár Qt Console Application-ba történő integrálásához és használatához, amelyet a Qt Creatorban fejlesztett, kövesse az alábbi lépéseket:

- Nyissa meg a Qt Creatort, és hozzon létre egy új *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Válassza ki a QMake lehetőséget a *Build System* legördülő listából.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Válassza ki a megfelelő kitet, és fejezze be a varázslót.
- Másolja az aspose-slides-cpp-21.02 mappát a kicsomagolt Aspose.Slides for C++ csomagból a projekt gyökerébe.

![lib_files](aspose.slides-lib-files.png)

- A lib és include mappák elérési útjainak hozzáadásához kattintson jobb gombbal a projektre a bal oldali panelen, és válassza a *Add Library* lehetőséget.

![qt_add_library](qt_add_library.png)

- Válassza az External Library opciót, és egyesével böngéssze az lib mappák elérési útjait.

![todo:image_alt_text](qt-add-external-library.png)

- Miután elkészült, a .pro projektfájl a következő bejegyzéseket fogja tartalmazni:

![qt_pro_file.png](qt-pro-file.png)

- Építse fel az alkalmazást, és a integráció befejeződött.  

{{% alert color="info" %}}

Megjegyzés: Tekintse meg a [teljes demó projekt](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) a további információkért.

{{% /alert %}}

## **Az Aspose.Slides for C++ használata Qt alkalmazásokban Visual Studio-ban**

Ahhoz, hogy Visual Studio használatával Qt alkalmazást fejlesszen, telepítenie kell a [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123)-t. Miután a telepítés megtörtént, töltse le a legújabb API-verziót a [downloads](https://downloads.aspose.com/slides/hu/cpp) szakaszból, és kövesse az alábbi lépéseket:

- Nyissa meg a Microsoft Visual Studio-t, és hozzon létre egy új *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Válassza ki a megfelelő kitet, és fejezze be a varázslót.
- Az Aspose.Slides for C++ könyvtár integrálásához és használatához kattintson jobb gombbal a projektre, és válassza a *Manage NuGet Packages...* lehetőséget.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Keresse meg, és telepítse a szükséges *Aspose.Slides.Cpp* csomagot.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Építse a projektet, és az integráció befejeződött.  

{{% alert color="info" %}}

Megjegyzés: Tekintse meg a [teljes demó projekt](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) a további információkért.

{{% /alert %}}