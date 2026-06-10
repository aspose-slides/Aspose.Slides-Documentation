---
title: Téglalapok hozzáadása prezentációkhoz C++
linktitle: Téglalap
type: docs
weight: 80
url: /hu/cpp/rectangle/
keywords:
- téglalap hozzáadása
- téglalap létrehozása
- téglalap alakzat
- egyszerű téglalap
- formázott téglalap
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Növelje a PowerPoint prezentációk hatékonyságát téglalapok hozzáadásával az Aspose.Slides for C++ segítségével – alakzatokat könnyedén tervezhet és módosíthat programozottan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet téglalap alakzatokat hozzáadni a PowerPoint diákhoz az Aspose.Slides használatával. Kiterjed egy egyszerű téglalap létrehozására, egy formázott téglalap létrehozására, valamint a módosított bemutató PPTX fájlként való mentésére.

## **Egyszerű téglalap létrehozása**
Az előző témákhoz hasonlóan ez is egy alakzat hozzáadásáról szól, és most a Rectangle alakzatról lesz szó. Ebben a témában leírtuk, hogyan adhatnak a fejlesztők egyszerű vagy formázott téglalapokat a diáikhoz az Aspose.Slides for C++ segítségével. Egy egyszerű téglalap hozzáadásához a bemutató egy kiválasztott diájához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation osztály](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg egy dia hivatkozását az Index használatával.
1. Adjon hozzá egy Rectangle típusú IAutoShape‑t az IShapes objektum által biztosított AddAutoShape metódussal.
1. Írja ki a módosított bemutatót PPTX fájlként.

Az alább bemutatott példában egy egyszerű téglalapot adtunk hozzá a bemutató első diájához.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Formázott téglalap létrehozása**
Egy formázott téglalap diához való hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation osztály](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg egy dia hivatkozását az Index használatával.
1. Adjon hozzá egy Rectangle típusú IAutoShape‑t az IShapes objektum által biztosított AddAutoShape metódussal.
1. Állítsa be a téglalap kitöltés típusát Solid értékre.
1. Állítsa be a téglalap színét a FillFormat objektumhoz tartozó IShape objektum SolidFillColor.Color tulajdonságával.
1. Állítsa be a téglalap vonalainak színét.
1. Állítsa be a téglalap vonalainak szélességét.
1. Írja ki a módosított bemutatót PPTX fájlként.
   A fenti lépéseket az alább bemutatott példában valósítottuk meg.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **GYIK**

**Hogyan adhatok hozzá egy lekerekített sarkú téglalapot?**  
Használja a rounded-corner [shape type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapetype/) típusú alakzatot, és állítsa be a sarok sugárát az alakzat tulajdonságaiban; a lekerekítést egyes sarkokra is alkalmazhatja geometriai beállításokkal.

**Hogyan tölthetem ki a téglalapot egy képpel (textúrával)?**  
Válassza ki a kép [fill type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) típusát, adja meg a képfájlt, és állítsa be a [stretching/tiling modes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/picturefillmode/) módot.

**Lehet egy téglalapon árnyék és ragyogás?**  
Igen. A [Külső/belső árnyék, ragyogás és lágy szélek](/slides/hu/cpp/shape-effect/) elérhető állítható paraméterekkel.

**Átalakíthatom a téglalapot gombbal és hiperlinkkel?**  
Igen. [Hiperlink hozzárendelése](/slides/hu/cpp/manage-hyperlinks/) – adjon hiperlinket az alakzat kattintásához (ugrás diára, fájlra, webcímre vagy e‑mailre).

**Hogyan védhetem meg a téglalapot a mozgatástól és a módosításoktól?**  
[shape lockok használata](/slides/hu/cpp/applying-protection-to-presentation/): megakadályozhatja a mozgatást, átméretezést, kijelölést vagy a szövegszerkesztést a elrendezés megőrzése érdekében.

**Átalakíthatom a téglalapot raszteres képpé vagy SVG‑vé?**  
Igen. A [Alakzat renderelése](http://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) segítségével képet hozhat létre a megadott mérettel/méretezéssel, vagy [Exportálás SVG‑ként](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/writeassvg/) formátumba vektoros felhasználáshoz.

**Hogyan szerezhetem meg gyorsan a téglalap tényleges (hatékony) tulajdonságait a téma és öröklődés figyelembevételével?**  
[Használja az alakzat hatékony tulajdonságait](/slides/hu/cpp/shape-effective-properties/): az API visszaadja a számított értékeket, amelyek figyelembe veszik a téma stílusokat, a layoutot és a helyi beállításokat, ezzel egyszerűsítve a formázás elemzését.