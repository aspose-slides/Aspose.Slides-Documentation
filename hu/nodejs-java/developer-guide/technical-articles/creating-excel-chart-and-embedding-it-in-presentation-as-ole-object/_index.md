---
title: Excel diagramok létrehozása és beágyazása prezentációkba OLE objektumként
type: docs
weight: 30
url: /hu/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Excel diagram létrehozása az Aspose.Cells for Node.js segítségével Java-n keresztül, és a munkafüzet beágyazása egy PowerPoint prezentációba az Aspose.Slides használatával, diagram előnézettel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre Excel oszlopdiagramot az Aspose.Cells for Node.js Java-n keresztül, és ágyazzuk be a munkafüzetet egy PowerPoint bemutatóba az Aspose.Slides for Node.js Java-n keresztül. A beágyazott munkafüzet tartalmazza a forrásadatokat és a diagramot is. Egy külön PNG előnézet jeleníti meg a diagramot a dián, mielőtt az OLE objektum aktiválódna.

Az eredmény egy beágyazott Excel objektum, nem egy natív PowerPoint diagram. A munkafüzet OLE-on keresztüli szerkesztéséhez egy asztali alkalmazásra van szükség, amely támogatja az OLE aktiválást, valamint kompatibilis Excel telepítésre.

## **Előfeltételek**

Telepítse a `aspose.cells`, `aspose.slides.via.java` és `java` Node.js csomagokat. Futtassa a példákat két CommonJS szkriptként külön Node.js folyamatokban: először a `create-chart.js`, majd az `embed-chart.js`, ugyanabban a munkakönyvtárban. Mindkét Aspose csomag a betöltés során inicializálja a Java hidat, ezért ezeket a példákat külön folyamatokban tartja. A Microsoft Office nem szükséges a bemutató előállításához ezekkel a könyvtárakkal.

Nem szükséges meglévő munkafüzet vagy kép. Az első szkript létrehozza a `ChartWorkbook.xlsx` és a `ChartPreview.png` fájlokat; a második beolvassa ezeket a fájlokat, és a `OutputChart.pptx` fájlt a jelenlegi munkakönyvtárba írja. Mindkét termékhez licencet kell alkalmazni, ha az értékelő módon kívül futtatja.

## **A beágyazás működése**

1. Hozzon létre egy munkafüzetet egy adat munkalappal és egy diagram munkalappal.  
1. Tegye a diagram munkalapot aktívvá, hogy a munkafüzet a diagramra nyíljon.  
1. Állítsa be a munkafüzet OLE megjelenítési tartományát, és renderelje a diagramot PNG‑re.  
1. Mentse a munkafüzetet XLSX‑ként, és ágyazza be a bájtjait egy diára egy külön Node.js folyamatban.  
1. A PNG‑t állítsa be az OLE objektum előnézeteként, és mentse a bemutatót PPTX‑ként.

A munkafüzet megjelenítési tartománya és a dia kerete külön szerepet tölt be. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) null‑alapú kezdő/ befejező sor‑ és oszlop‑indexeket vesz. A [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) ehelyett a felső sort, bal oszlopot, alsó sort és jobb oszlopot veszi. A példa a 55‑ös sorindexet és a 25‑ös oszlopindexet használja alsó‑jobb határként; ezek az értékek elrendezési döntések, nem a sor‑ vagy oszlopszám.

A dia kerete pontokat használ. A példa úgy illeszti a diába, hogy középre helyezze, miközben megőrzi a PNG képarányát, ahelyett, hogy nyújtaná az előnézetet a teljes dia kitöltéséhez.

## **Diagram létrehozása és beágyazása**

Mentse az első példát `create-chart.js` néven. A `DataSheet` négy sor és öt oszlop értékkel töltődik fel. Minden sor egy diagram sorozattá válik. A `ChartSheet` kerül kiválasztásra aktív lapon, mielőtt a munkafüzet mentésre kerül.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderelje a diagram előnézetét, és külön sorosítsa a szerkeszthető munkafüzetet.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Minden szinkron munka befejeződött; állítsa le a Java hid folyamatát.
process.exit(0);
```


Mentse az alábbi példát `embed-chart.js` néven. Futtassa azt, miután a `create-chart.js` létrehozta a bemeneti fájlokat. A OLE keretet középre helyezi, és megőrzi az előnézeti kép képarányát.

A második szkript beágyazza a mentett munkafüzetet, és a PNG‑t használja előnézetként. A munkafüzet kifeexplicit módon XLSX‑ként van mentve, amely megfelel a `xlsx` kiterjesztésnek, amely a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) -nek került átadásra. A PNG közvetlenül a bájtjaiból töltődik be, köztes bitmap átalakítás nélkül. A Java híd kifeexplicit Java bájt tömböket igényel a kép és a munkafüzet adataihoz, valamint Java float értékeket a dia keret koordinátáihoz. A [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) használatával történő hozzárendelés felülírja az alapértelmezett OLE helyőrzőt.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Illessze az előnézetet a diára anélkül, hogy megváltoztatná annak képarányát.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Minden szinkron munka befejeződött; állítsa le a Java híd folyamatát.
process.exit(0);
```

## **Várt eredmény**

`OutputChart.pptx` egy diát tartalmaz beágyazott Excel munkafüzettel és egy diagram előnézettel. A munkafüzet az eredeti adatokat és egy négy sorozatú oszlopdiagramot tartalmaz. Az előnézet a dián középre van helyezve, és megtartja arányait.

![Excel oszlopdiagram megjelenítve a beágyazott munkafüzet előnézeteként](excel-chart-ole-preview.png)

Egy kompatibilis asztali PowerPoint környezetben, ahol elérhető az Excel, duplán kattintson az objektumra a beágyazott munkafüzet aktiválásához és szerkesztéséhez. Az aktiválás és a szerkesztés a gazdaalkalmazás OLE‑támogatásától és biztonsági beállításaitól függ.

## **GYIK**

**Miért szükséges előnézeti kép?**

A beágyazott munkafüzet és a dia előnézete külön tartalom. Biztosítson egy diagram képet, hogy a dia a diagramot jelenítse meg az alapértelmezett „EMBEDDED OLE OBJECT” helyőrző helyett. Lásd [Objektum előnézeti probléma OleObjectFrame hozzáadásakor](/slides/hu/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Frissül automatikusan az előnézet, ha a kódban módosítom a munkafüzetet?**

Kezelje az előnézetet pillanatképként. Ha programozottan frissíti a munkafüzet adatait, generálja újra a diagram képet, és cserélje ki az előnézetet, valamint a beágyazott munkafüzet adatot.

**Használhatok XLS‑et XLSX helyett?**

Igen. Mentse a munkafüzetet XLS formátumban, és használja a `xls` kiterjesztést beágyazott adatként. A kiterjesztésnek meg kell egyeznie a tényleges munkafüzet formátummal; a kiterjesztés önmagában nem konvertálja az adatot.

**Miért változhat az objektum mérete az aktiválás után?**

A gazdaalkalmazás frissítheti az OLE objektum megjelenését, amikor aktiválja a munkafüzetet. A munkafüzet OLE megjelenítési tartománya és a dia keret méretei egyaránt számítanak. Lásd [Működő megoldás a diagram átméretezésére PPTX‑ben](/slides/hu/java/working-solution-for-chart-resizing-in-pptx/).

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezésére PPTX‑ben](/slides/hu/java/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézeti probléma OleObjectFrame hozzáadásakor](/slides/hu/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)