---
title: Add Ellipses to Presentations in C++
linktitle: Ellipse
type: docs
weight: 30
url: /hu/cpp/ellipse/
keywords:
- ellipszis
- alakzat
- ellipszis hozzáadása
- ellipszis létrehozása
- ellipszis rajzolása
- formázott ellipszis
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, formázhat és kezelhet ellipszis alakzatokat az Aspose.Slides for C++-ban PPT és PPTX prezentációkban – C++ kódrészletek is szerepelnek."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk ellipszis alakzatokat PowerPoint diákhoz az Aspose.Slides használatával. Lefedi egy egyszerű ellipszis létrehozását, egy formázott ellipszis létrehozását, és a módosított prezentáció PPTX fájlként való mentését. Emellett érinti a kapcsolódó kérdéseket, például az ellipszis pozíciójának és méretének kezelését, a rétegezési sorrend irányítását, valamint animációs hatások alkalmazását.

## **Ellipszis létrehozása**
Ebben a témában bemutatjuk a fejlesztőknek, hogyan adhatnak ellipszis alakzatokat a diáikhoz az Aspose.Slides for C++ használatával. Az Aspose.Slides for C++ könnyebb API-készletet biztosít különféle alakzatok rajzolásához csupán néhány sor kóddal. Egy egyszerű ellipszis hozzáadásához a prezentáció egy kiválasztott diájához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation osztály](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) segítségével
2. Szerezze meg egy dia hivatkozását az Index használatával
3. Adjon hozzá egy Ellipse típusú AutoShape‑t az IShapes objektum által biztosított AddAutoShape metódussal
4. Írja ki a módosított prezentációt PPTX fájlként

Az alábbi példában egy ellipszist adtunk hozzá az első diahoz.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Formázott ellipszis létrehozása**
Formázottabb ellipszis hozzáadásához a diára kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation osztály](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) segítségével.
2. Szerezze meg egy dia hivatkozását az Index használatával.
3. Adjon hozzá egy Ellipse típusú AutoShape‑t az IShapes objektum által biztosított AddAutoShape metódussal.
4. Állítsa be az ellipszis Kitöltés típusát Solid‑ra.
5. Állítsa be az ellipszis Színét a FillFormat objektum SolidFillColor.Color tulajdonságával, amely az IShape objektumhoz kapcsolódik.
6. Állítsa be az ellipszis vonalainak Színét.
7. Állítsa be az ellipszis vonalainak Szélességét.
8. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy formázott ellipszist adtunk hozzá a prezentáció első diájához.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **GYIK**

**Hogyan állíthatom be egy ellipszis pontos pozícióját és méretét a dia egységeihez képest?**  
A koordinátákat és méreteket általában **pontban** adjuk meg. A kiszámítható eredményekért a számításokat a dia mérete alapján végezze, és a szükséges millimétereket vagy hüvelyket konvertálja pontokra, mielőtt értékeket rendel.

**Hogyan helyezhetem az ellipszist más objektumok fölé vagy alá (rétegezési sorrend vezérlése)?**  
Módosítsa az objektum rajzolási sorrendjét úgy, hogy előre hozza vagy hátra küldi. Ez lehetővé teszi, hogy az ellipszis átfedje a többi objektumot, vagy felfedje az alatta lévőket.

**Hogyan animálhatom egy ellipszis megjelenését vagy hangsúlyozását?**  
[Alkalmaz](/slides/hu/cpp/shape-animation/) belépő, hangsúlyozó vagy kilépő hatásokat az alakzatra, és konfigurálja a trigger‑eket és az időzítést, hogy meghatározza, mikor és hogyan játssza le az animációt.