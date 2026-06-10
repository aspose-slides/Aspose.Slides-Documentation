---
title: Hibaoszlopok testreszabása bemutatódiagramokban C++ használatával
linktitle: Hibaoszlop
type: docs
url: /hu/cpp/error-bar/
keywords:
- hibaoszlop
- egyéni érték
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és testreszabhat hibaoszlopokat a diagramokban az Aspose.Slides for C++ segítségével — optimalizálja az adatok vizualizációját a PowerPoint bemutatókban."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk hibaoszlopokkal a bemutatódiagramokban az Aspose.Slides használatával. Bemutatja, hogyan adhatunk hibaoszlopokat egy diagram sorozathoz, konfigurálhatjuk az X és Y hibaoszlop beállításokat, valamint különböző értéktípusokat alkalmazhatunk, például rögzített, százalékos és egyéni értékeket.  

Az is bemutatásra kerül, hogyan rendelhetünk egyéni hibaoszlop értékeket egy sorozat egyes adatpontjaihoz a megfelelő adatpontgyűjtemény használatával. Ezenkívül a cikk rövid megjegyzéseket tartalmaz arról, hogyan viselkednek a hibaoszlopok exportálás során, kompatibilitásukról a jelölőkkel és adatcímkékkel, valamint hogy hol találhatók a kapcsolódó API referencia osztályok és felsorolások.

## **Hibaoszlopok hozzáadása**
Az Aspose.Slides for C++ egyszerű API-t biztosít a hibaoszlop értékek kezelésére. A mintakód akkor alkalmazandó, ha egy egyéni értéktípust használunk. Egy érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat **DataPoints** gyűjteményének egy adott adatpontján:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Érje el az első diagram sorozatot, és állítsa be a hibaoszlop X formátumát.
1. Érje el az első diagram sorozatot, és állítsa be a hibaoszlop Y formátumát.
1. Állítsa be az oszlopok értékeit és formátumát.
1. Írja a módosított bemutatót egy PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Egyéni hibaoszlopok hozzáadása**
Az Aspose.Slides for C++ egyszerű API-t biztosít az egyéni hibaoszlop értékek kezelésére. A mintakód akkor alkalmazandó, ha az **IErrorBarsFormat.ValueType** tulajdonság **Custom** értékre van állítva. Egy érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat **DataPoints** gyűjteményének egy adott adatpontján:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Érje el az első diagram sorozatot, és állítsa be a hibaoszlop X formátumát.
1. Érje el az első diagram sorozatot, és állítsa be a hibaoszlop Y formátumát.
1. Érje el a diagram sorozat egyéni adatpontjait, és állítsa be a hibaoszlop értékeit egy adott sorozat adatponthoz.
1. Állítsa be az oszlopok értékeit és formátumát.
1. Írja a módosított bemutatót egy PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **GYIK**

**Mi történik a hibaoszlopokkal, amikor egy bemutatót PDF-re vagy képekre exportálunk?**  
A hibaoszlopok a diagram részeként kerülnek megjelenítésre, és a konverzió során megmaradnak a diagram többi formázásával együtt, feltéve, hogy kompatibilis verzió vagy renderelő áll rendelkezésre.

**Egyesíthetők a hibaoszlopok a jelölőkkel és adatcímkékkel?**  
Igen. A hibaoszlopok különálló elemek, és kompatibilisek a jelölőkkel és adatcímkékkel; ha az elemek átfedik egymást, előfordulhat, hogy a formázást módosítani kell.

**Hol találom a hibaoszlopok kezeléséhez szükséges tulajdonságok és felsorolások listáját az API-ban?**  
Az API referenciában: az [ErrorBarsFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/errorbarsformat/) osztály és a kapcsolódó felsorolások [ErrorBarType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/errorbartype/) és [ErrorBarValueType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/errorbarvaluetype/).