---
title: Diagramok létrehozása VSTO és Aspose.Slides for Java használatával
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
description: "Ismerje meg, hogyan automatizálhatja a PowerPoint diagramok létrehozását Java-ban. Ez a lépésről-lépésre útmutató bemutatja, miért gyorsabb és erősebb alternatíva a Aspose.Slides for Java a Microsoft.Office.Interop-hoz képest."
---
{{% alert color="primary" %}} 
A diagramok a adatok vizuális ábrázolásai, amelyeket széles körben használnak prezentációkban. Ez a cikk bemutatja a kódot egy diagram programozott létrehozásához a Microsoft PowerPointban a [VSTO](/slides/hu/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) és a [Aspose.Slides for Java](/slides/hu/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) használatával.
{{% /alert %}} 
## **Diagram létrehozása**
Az alábbi kódrészletek leírják egy egyszerű 3D klaszter oszlopdiagram VSTO-val történő hozzáadásának folyamatát. Létrehoz egy prezentáció példányt, hozzáad egy alapértelmezett diagramot. Ezután a Microsoft Excel munkafüzetet használja a diagram adatok eléréséhez és módosításához, valamint a diagram tulajdonságainak beállításához. Végül elmenti a prezentációt.
### **VSTO példa**
A VSTO használatával a következő lépések hajtódnak végre:

1. Hozzon létre egy Microsoft PowerPoint prezentáció példányt.
1. Adjon hozzá egy üres diát a prezentációhoz.
1. Adjon hozzá egy **3D clustered column** diagramot, és férjen hozzá.
1. Hozzon létre egy új Microsoft Excel Workbook példányt, és töltse be a diagram adatokat.
1. A diagram adat munkalaphoz a Microsoft Excel Workbook instancefromworkbook használatával férjen hozzá.
1. Állítsa be a diagram tartományt a munkalapon, és távolítsa el a 2. és 3. sorozatot a diagramról.
1. Módosítsa a diagram kategóriaadatait a diagram adat munkalapon.
1. Módosítsa a diagram 1. sorozatának adatait a diagram adat munkalapon.
1. Most férjen hozzá a diagram címéhez, és állítsa be a betűtípusra vonatkozó tulajdonságokat.
1. Férjen hozzá a diagram értéktengelyéhez, és állítsa be a fő egységet, a mellék egységeket, a maximális és minimális értékeket.
1. Férjen hozzá a diagram mélység vagy sorozat tengelyéhez, és távolítsa el azt, mivel ebben a példában csak egy sorozatot használnak.
1. Most állítsa be a diagram forgatási szögeit X és Y irányban.
1. Mentse a prezentációt.
1. Zárja be a Microsoft Excel és PowerPoint példányait.

**A VSTO-val létrehozott kimeneti prezentáció** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java példa**
Az Aspose.Slides for Java használatával a következő lépések hajtódnak végre:

1. Hozzon létre egy Microsoft PowerPoint prezentáció példányt.
1. Adjon hozzá egy üres diát a prezentációhoz.
1. Adjon hozzá egy **3D clustered column** diagramot, és férjen hozzá.
1. A diagram adat munkalaphoz a Microsoft Excel Workbook instancefromworkbook használatával férjen hozzá.
1. Távolítsa el a nem használt 2. és 3. sorozatot.
1. Férjen hozzá a diagram kategóriáihoz, és módosítsa a címkéket.
1. Férjen hozzá az 1. sorozathoz, és módosítsa a sorozat értékeit.
1. Most férjen hozzá a diagram címéhez, és állítsa be a betűtípus tulajdonságait.
1. Férjen hozzá a diagram értéktengelyéhez, és állítsa be a fő egységet, a mellék egységeket, a maximális és minimális értékeket.
1. Most állítsa be a diagram forgatási szögeit X és Y irányban.
1. Mentse a prezentációt PPTX formátumban.

**A Aspose.Slides-szal létrehozott kimeneti prezentáció** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **GYIK**

**Létrehozhatok más típusú diagramokat, például kör-, vonal- vagy oszlopdiagramokat az Aspose.Slides használatával?**

Igen. Az Aspose.Slides számos [diagramtípust](/slides/hu/java/create-chart/) támogat, beleértve a kördiagramokat, vonaldiagramokat, oszlopdiagramokat, szórásdiagramokat, buborékdiagramokat és még sok más típust. A kívánt diagramtípust a diagram hozzáadásakor a [ChartType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) osztály használatával adhatja meg.

**Alkalmazhatok egyéni stílusokat vagy témákat a diagramra?**

Igen. Teljesen testreszabhatja a diagram megjelenését, beleértve a színeket, betűtípusokat, kitöltéseket, körvonalakat, rácsvonalakat és elrendezést. Azonban az Office témák pontos, PowerPointban látható módon történő alkalmazása egyéni stílusok kézi beállítását igényli.

**Exportálhatom a diagramot képként külön a diától?**

Igen, az Aspose.Slides lehetővé teszi bármely alakzat, beleértve a diagramokat, külön képként (például PNG, JPEG) való exportálását a diagram [shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/) `getImage` metódusának használatával.