---
title: Excel-diagramok létrehozása és beágyazása OLE objektumokként VSTO és Aspose.Slides for Java használatával
linktitle: Excel-diagramok létrehozása és beágyazása OLE objektumokként
type: docs
weight: 60
url: /hu/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- diagram létrehozása
- Excel-diagram beágyazása
- OLE objektum
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for Java-ra, és ágyazza be az Excel-diagramokat OLE objektumokként a PowerPoint (PPT, PPTX) diáira Java-ban."
---
{{% alert color="primary" %}} 
A diagramok vizuális ábrázolásai az adataidnak, és széles körben használják őket prezentációs diákon. Ez a cikk bemutatja a kódot, amely programozott módon létrehozza és beágyazza az Excel-diagramot OLE objektumként a PowerPoint-diára a [VSTO](/slides/hu/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) és a [Aspose.Slides for Java](/slides/hu/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) használatával.
{{% /alert %}} 
## **Excel-diagram létrehozása és beágyazása**
Az alábbi két kódpélda hosszú és részletes, mivel a leírt feladat összetett. Létrehoz egy Microsoft Excel munkafüzetet, készít egy diagramot, majd létrehozza a Microsoft PowerPoint prezentációt, amelybe beágyazza a diagramot. Az OLE objektumok hivatkozásokat tartalmaznak az eredeti dokumentumra, így a beágyazott fájlt duplán kattintva a felhasználó elindíthatja a fájlt és annak alkalmazását.
### **VSTO példa**
A VSTO használatával a következő lépések hajtódnak végre:
1. Hozzon létre egy példányt a Microsoft Excel ApplicationClass objektumból.
1. Hozzon létre egy új munkafüzetet egy munkalappal.
1. Adjon hozzá diagramot a munkalaphoz.
1. Mentse a munkafüzetet.
1. Nyissa meg azt az Excel-munkafüzetet, amely a diagram adatait tartalmazó munkalapot tartalmazza.
1. Szerezze be a ChartObjects gyűjteményt a munkalaphoz.
1. Szerezze be a másolandó diagramot.
1. Hozzon létre egy Microsoft PowerPoint prezentációt.
1. Adjon hozzá egy üres diát a prezentációhoz.
1. Másolja a diagramot az Excel munkalapról a vágólapra.
1. Illessze be a diagramot a PowerPoint prezentációba.
1. Pozícionálja a diagramot a dián.
1. Mentse a prezentációt.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java példa**
Az Aspose.Slides for .NET használatával a következő lépések kerülnek végrehajtásra:
1. Hozzon létre egy munkafüzetet az Aspose.Cells for Java segítségével.
1. Hozzon létre egy Microsoft Excel diagramot.
1. Állítsa be az Excel-diagram OLE méretét.
1. Szerezzen képet a diagramról.
1. Ágyazza be az Excel-diagramot OLE objektumként a PPTX prezentációba az Aspose.Slides for Java használatával.
1. Cserélje le az objektum változott képét a 3. lépésben kapott képre az objektum változási problémájának kezelése érdekében.
1. Írja ki a kimeneti prezentációt a lemezre PPTX formátumban.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}