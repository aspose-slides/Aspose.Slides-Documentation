---
title: Diagramok létrehozása VSTO-val és Aspose.Slides for Java segítségével
linktitle: Diagram létrehozása
type: docs
weight: 70
url: /hu/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- diagram létrehozása
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan automatizálhatja a PowerPoint diagramok létrehozását Java-ban. Ez a lépésről-lépésre útmutató bemutatja, miért a Aspose.Slides for Java gyorsabb és erőteljesebb alternatíva a Microsoft.Office.Interop-hez képest."
---
{{% alert color="info" %}} 

A diagramok a adatok vizuális ábrázolásai, amelyeket széles körben használnak prezentációkban. Ebben a cikkben a Microsoft PowerPoint programozott diagramlétrehozásának kódját mutatjuk be a [VSTO](/slides/hu/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) és a [Aspose.Slides for Java](/slides/hu/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) segítségével.

{{% /alert %}} 
## **Creating a Chart**
Az alábbi kódpéldák leírják egy egyszerű 3D csoportosított oszlopdiagram hozzáadásának folyamatát VSTO segítségével. Létrehoz egy prezentációpéldányt, hozzáad egy alapértelmezett diagramot, majd a Microsoft Excel munkafüzetet használja a diagramadatok eléréséhez és módosításához, valamint a diagram tulajdonságainak beállításához. Végül elmenti a prezentációt.
### **VSTO Example**
VSTO használatával a következő lépések hajtódnak végre:

1. Létrehoz egy Microsoft PowerPoint prezentáció példányt.
2. Hozzáad egy üres diát a prezentációhoz.
3. Hozzáad egy **3D csoportosított oszlop** diagramot és eléri azt.
4. Létrehoz egy új Microsoft Excel Workbook példányt és betölti a diagram adatokat.
5. A Microsoft Excel Workbook példány segítségével eléri a diagram adatlapot.
6. Beállítja a diagram tartományt a munkalapon, és eltávolítja a 2-es és 3-as sorozatot a diagramról.
7. Módosítja a diagram kategóriaadatait a diagram adatlapján.
8. Módosítja az 1-es sorozat adatait a diagram adatlapján.
9. Ezután eléri a diagram címet és beállítja a betűtípusra vonatkozó tulajdonságokat.
10. Eléri a diagram érték tengelyét és beállítja a fő egységet, a kisegységeket, a maximális és minimális értékeket.
11. Eléri a diagram mélység‑ vagy sorozattengelyét, és eltávolítja azt, mivel ebben a példában csak egy sorozatot használunk.
12. Beállítja a diagram forgatási szögeit X és Y irányban.
13. Elmenti a prezentációt.
14. Bezárja a Microsoft Excel és PowerPoint példányokat.

**A VSTO‑val készült kimeneti prezentáció** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java Example**
Aspose.Slides for Java használatával a következő lépések hajtódnak végre:

1. Létrehoz egy Microsoft PowerPoint prezentáció példányt.
2. Hozzáad egy üres diát a prezentációhoz.
3. Hozzáad egy **3D csoportosított oszlop** diagramot és eléri azt.
4. A Microsoft Excel Workbook példány segítségével eléri a diagram adatlapját.
5. Eltávolítja a használaton kívüli 2‑es és 3‑as sorozatokat.
6. Eléri a diagram kategóriáit és módosítja a címkéket.
7. Eléri az 1‑es sorozatot és módosítja a sorozat értékeit.
8. Ezután eléri a diagram címet és beállítja a betűtípus tulajdonságait.
9. Eléri a diagram érték tengelyét és beállítja a fő egységet, a kisegységeket, a maximális és minimális értékeket.
10. Beállítja a diagram forgatási szögeit X és Y irányban.
11. Elmenti a prezentációt PPTX formátumban.

**Az Aspose.Slides‑sel készült kimeneti prezentáció** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Készíthetek más típusú diagramokat, például kör, vonal vagy oszlop diagramot az Aspose.Slides‑szel?

Igen. Az Aspose.Slides számos [diagramtípust](/slides/hu/java/create-chart/) támogat, többek között kördiagramot, vonaldiagramot, oszlopdiagramot, szórási diagramot, buborékdiagramot és még sok mást. A kívánt diagramtípust a [ChartType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) osztály használatával adhatja meg diagram hozzáadásakor.

### Alkalmazhatok egyedi stílusokat vagy témákat a diagramra?

Igen. Teljesen testre szabhatja a diagram megjelenését, beleértve a színeket, betűtípusokat, kitöltéseket, körvonalakat, rácsvonalakat és az elrendezést. Azonban az Office témák pontos, PowerPoint‑ban látható formában történő alkalmazása manuális stílusbeállításokat igényel.

### Exportálhatom a diagramot képként külön a diától?

Igen, az Aspose.Slides lehetővé teszi, hogy bármely alakzatot – beleértve a diagramokat is – külön képként (például PNG, JPEG) exportálja a diagram [shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/) `getImage` metódusával.