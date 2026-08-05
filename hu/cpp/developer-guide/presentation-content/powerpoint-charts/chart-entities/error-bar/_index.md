---
title: Hibasávok testreszabása prezentáció diagramokban C++-ban
linktitle: Hibasáv
type: docs
url: /hu/cpp/error-bar/
keywords:
- hibasáv
- egyedi érték
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és testreszabhat hibasávokat diagramokban az Aspose.Slides for C++ segítségével — optimalizálja az adatmegjelenítéseket PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk hibasávokkal a prezentáció diagramokban az Aspose.Slides használatával. Megmutatja, hogyan adhatunk hibasávokat egy diagram sorozathoz, hogyan állíthatjuk be az X és Y hibasáv beállításokat, és hogyan alkalmazhatunk különböző értéktípusokat, például rögzített, százalékos és egyedi értékeket.

Hozzáad továbbá bemutatja, hogyan rendelhetünk egyedi hibasáv értékeket egy sorozat egyes adatpontjaihoz a megfelelő adatpontgyűjtemény használatával. Emellett a cikk rövid megjegyzéseket tartalmaz arról, hogyan viselkednek a hibasávok exportáláskor, kompatibilitásukról a jelölőkkel és adatcímkékkel, valamint hogy hol találhatók a kapcsolódó API referencia osztályok és felsorolások.

## **Hibasávok hozzáadása**
Aspose.Slides for C++ egyszerű API-t biztosít a hibasáv értékek kezelésére. A példakód akkor alkalmazható, amikor egyedi értéktípust használunk. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot egy adott adatpontnál a sorozat **DataPoints** gyűjteményében:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy buborék diagramot a kívánt diára.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv X formátumát.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv Y formátumát.
1. A sávok értékének és formátumának beállítása.
1. Írja a módosított prezentációt egy PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Egyéni hibasávok hozzáadása**
Aspose.Slides for C++ egyszerű API-t biztosít az egyedi hibasáv értékek kezelésére. A példakód akkor alkalmazható, amikor a **IErrorBarsFormat.ValueType** tulajdonság **Custom** értéken van. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot egy adott adatpontnál a sorozat **DataPoints** gyűjteményében:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy buborék diagramot a kívánt diára.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv X formátumát.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv Y formátumát.
1. Hozzáférés a diagram sorozat egyedi adatpontjaihoz, és egy adott sorozat adatpont hibasáv értékének beállítása.
1. A sávok értékének és formátumának beállítása.
1. Írja a módosított prezentációt egy PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **GYIK**

**Mi történik a hibasávokkal, amikor a prezentációt PDF-re vagy képekre exportáljuk?**  
A hibasávok a diagram részét képezik, és a konverzió során megmaradnak a diagram többi formázásával együtt, feltéve, hogy kompatibilis verzió vagy renderelő áll rendelkezésre.

**A hibasávok kombinálhatók jelölőkkel és adatcímkékkel?**  
Igen. A hibasávok különálló elemek, és kompatibilisek a jelölőkkel és adatcímkékkel; ha az elemek átfedik egymást, előfordulhat, hogy módosítani kell a formázást.

**Hol található a hibasávokkal kapcsolatos tulajdonságok és felsorolások listája az API-ban?**  
Az API referencia: az [ErrorBarsFormat] osztály és a kapcsolódó felsorolások [ErrorBarType] és [ErrorBarValueType].