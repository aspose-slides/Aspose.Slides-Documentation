---
title: Excel-diagramok létrehozása és beágyazása OLE-objektumként VSTO és Aspose.Slides for Java segítségével
linktitle: Excel-diagramok létrehozása és beágyazása OLE-objektumként
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
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for Java-ra, és ágyazzon be Excel-diagramokat OLE-objektumként a PowerPoint (PPT, PPTX) diákba Java-ban."
---
{{% alert color="info" %}} 
A diagramok a adataid vizuális ábrázolásai, és széles körben használják őket a prezentációs diákon. Ez a cikk bemutatja a kódot, amellyel programozottan létrehozhat és beágyazhat egy Excel-diagramot OLE‑objektumként a PowerPoint-diára a [VSTO](/slides/hu/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) és a [Aspose.Slides for Java](/slides/hu/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) használatával.
{{% /alert %}} 
## **Excel-diagram létrehozása és beágyazása**
Az alábbi két kódrészlet hosszú és részletes, mivel a feladat, amit leírnak, összetett. Létrehoz egy Microsoft Excel munkafüzetet, létrehoz egy diagramot, majd létrehozza a Microsoft PowerPoint prezentációt, amelybe a diagramot beágyazza. Az OLE‑objektumok hivatkozásokat tartalmaznak az eredeti dokumentumra, így a beágyazott fájlt duplán kattintó felhasználó elindítja a fájlt és annak alkalmazását.
### **VSTO példa**
Using VSTO, the following steps are performed:

1. Hozzon létre egy példányt a Microsoft Excel ApplicationClass objektumból.
1. Hozzon létre egy új munkafüzetet egy munkalappal.
1. Adjon hozzá diagramot a munkalaphoz.
1. Mentse a munkafüzetet.
1. Nyissa meg azt az Excel munkafüzetet, amelyik a diagramadatokat tartalmazó munkalapot tartalmazza.
1. Szerezze be a ChartObjects gyűjteményt a munkalaphoz.
1. Szerezze be a másolandó diagramot.
1. Hozzon létre egy Microsoft PowerPoint prezentációt.
1. Adjon egy üres diát a prezentációhoz.
1. Másolja a diagramot az Excel munkalapról a vágólapra.
1. Illessze be a diagramot a PowerPoint prezentációba.
1. Helyezze el a diagramot a dián.
1. Mentse a prezentációt.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java példa**
Using Aspose.Slides for .NET, the following steps are performed:

1. Hozzon létre egy munkafüzetet az Aspose.Cells for Java használatával.
1. Hozzon létre egy Microsoft Excel diagramot.
1. Állítsa be az Excel-diagram OLE méretét.
1. Szerezze be a diagram képét.
1. Ágyazza be az Excel-diagramot OLE‑objektumként a PPTX prezentációba az Aspose.Slides for Java használatával.
1. Cserélje le az objektum módosított képét a 3. lépésben előállított képre, hogy kezelje az objektum módosítási problémát.
1. Írja a kimeneti prezentációt lemezre PPTX formátumban.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}