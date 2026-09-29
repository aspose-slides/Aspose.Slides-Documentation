---
title: Diagrammunkafüzetek kezelése prezentációkban JavaScript használatával
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/nodejs-java/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Node.js-t Java segítségével: egyszerűen kezelheti a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy optimalizálja a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet diagram‑munkafüzetekkel dolgozni az Aspose.Slides használatával. Megmutatja, hogyan lehet a diagramadatokat munkafüzet‑stream‑eken keresztül olvasni és írni, a munkafüzet‑cellákat diagramadat‑címkeként használni, a munkalap‑gyűjteményekhez hozzáférni, valamint megadni az adatforrás‑típust a diagramértékekhez. 

Továbbá a külső munkafüzetek diagramadat‑forrásként való használatát is tárgyalja. A példák bemutatják, hogyan lehet külső munkafüzetet létrehozni és hozzárendelni, hogyan lehet lekérni egy diagramhoz kapcsolt külső munkafüzet útvonalát, illetve hogyan lehet a diagram adatokat szerkeszteni, ha a munkafüzet elérhető. 

Az üres cellákat vagy a nulla értékeket érintő különbség, valamint a vonaldiagram összehasonlítása a rendelkezésre álló megjelenítési módok között megtalálható a [Az üres cellák megjelenítésének vezérlése](/slides/hu/nodejs-java/chart-series/) cikkben.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) metódust annak vezérlésére, hogy a diagram rejtett munkalap‑sorokból és -oszlopokból származó adatokat ábrázoljon‑e. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt bele akarja foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait. 

Töltse le a [hidden-source-data.pptx](hidden-source-data.pptx) fájlt, és helyezze a munkakönyvtárba. Az első dia egy oszlopdiagramot tartalmaz első alakzatként. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3‑as sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket. 

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forrás‑cellákhoz a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével férhet hozzá, és a [ChartDataCell.isHidden](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#isHidden) metódussal ellenőrizheti a rejtett állapotukat. Ez a metódus a rejtett állapotot jelenti anélkül, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példában sorban `false`, `true`, és `true` értékek jelennek meg. 

Ehhez a példához a diagramadatok frissítése a ábrázolási beállítás módosítása után szükséges: a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) segítségével tartsa meg, majd a [writeWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream)‑nel töltse be újra. Minden cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#setRange)‑t is a teljes tartomány, köztük a rejtett februári kategória visszaállításához. Az egyszerű jelző‑váltás nem elegendő a mintában tárolt diagramadatok és kategóriacímkék frissítéséhez. A példa a visszakapott Node.js buffer‑t Java bájt‑tömbbé alakítja, mielőtt átadná az író metódusnak. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Frissítse a diagram adatait a beágyazott munkafüzetből.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Állítsa vissza a teljes forrás tartományt, beleértve a rejtett kategóriákat.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

A példa a `hidden_cells_true.pptx` fájlt csak a látható Kiskereskedelem értékekkel (10 és 20) menti, míg a `hidden_cells_false.pptx` minden hat értékkel. Az alábbi képek a két ábrázolási módot szemléltetik. A 3‑as sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad. 

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett, értékkel rendelkező cella különbözik az üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) szabályozza, hogyan jelennek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Az üres cellák megjelenítésének vezérlése](/slides/hu/nodejs-java/chart-series/#control-the-display-of-empty-cells) példát. 

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Node.js via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (Aspose.Cells‑szel szerkesztett diagramadatok) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell szerveződnie, vagy hasonló struktúrával kell rendelkezniük, mint a forrás. 

Ez a példa megnyitja a `chart.pptx` fájlt, amelynek az első diáján első alakzatként diagramnak kell lennie. A beágyazott munkafüzetet bájt‑tömbbé olvassa, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változások memóriában maradnak; a példa nem menti a prezentációt. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Diagram elrendezésének ellenőrzése munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet egy módosítottal helyettesít, a diagram megtartja az eredeti sorozat‑ és kategóriagyűjteményeit. Ez az eltérés a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/#validateChartLayout) hibához vezethet, index‑kívül‑tartomány hibával. Törölje a meglévő sorozatokat és kategóriákat, mielőtt az új munkafüzetet visszaírná a diagramba. Ez a példa a `chart.pptx` fájlt igényli, amelynek az első diáján első alakzatként diagramnak kell lennie. A megjegyzés azt jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet és memóriában ellenőrzi az elrendezést. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Módosítsa itt a munkafüzet bájtjait, például az Aspose.Cells használatával.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

A gyűjtemények törlése eltávolítja a kérdéses adat‑referenciákat, mielőtt a munkafüzet visszaírásra kerül. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használná. 

## **Munkafüzet‑cellát beállítása diagramadat‑címkeként**

A munkafüzet‑cellák szövegét használhatja diagramadat‑címkeként. Az alábbi lépések mutatják, hogyan lehet a buborékdiagram címkéit a munkafüzet‑cellákhoz kapcsolni. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.  
2. A nulláról indexelt első diát érje el.  
3. Adjon hozzá egy buborékdiagramot alapértelmezett adatokkal.  
4. Érje el a diagram sorozatát.  
5. Állítsa be a munkafüzet‑cellát adatcímkeként.  
6. Mentse a prezentációt.  

Ez a példa megnyitja a `chart2.pptx` fájlt, amelynek legalább egy diája kell legyen, és hozzáad egy buborékdiagramot alapértelmezett adatokkal. A 0‑s munkalapon az A10:A12 cellákat használja az első sorozat első három címkéjének, engedélyezi a cellákból származó címkéket, és a `resultchart.pptx` fájlba menti az eredményt. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Munkalapok kezelése**

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) metódus hozzáférést biztosít a diagram‑munkafüzet munkalapjaihoz. Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és minden munkalap nevét a konzolra írja. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Adatforrás‑típus megadása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál, a második a 0‑s munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. Az eredményt a `pres.pptx` fájlba menti. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nem támogatott beágyazott munkafüzet‑formátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely egyes diagramokba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/) osztályon, a [WorkbookType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felismeréséhez és az ilyen diagramok kihagyásához. Ez a példa az `sample.pptx` első diáján lévő alakzatokat vizsgálja, kihagyja a nem diagram alakzatokat, és minden, .xlsb‑t beágyazott munkafüzettel rendelkező diagramhoz diagnosztikai üzenetet ír. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Olvassa vagy módosítsa a támogatott diagram munkafüzet adatait itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát. 

### **Külső munkafüzet létrehozása**

A [readWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) segítségével exportálhat egy beágyazott diagram‑munkafüzetet fájlba, majd a diagramot ehhez a külső munkafüzethez kapcsolja. 

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, a munkafüzetét az `externalWorkbook1.xlsx` fájlba írja, és a fájl‑írás befejezése után rendeli hozzá a diagram adatforrásaként. A kapcsolt prezentációt az `externalWorkbook.pptx` fájlba menti. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Külső munkafüzet beállítása**

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) metódussal egy külső munkafüzetet rendelhet diagramhoz adatforrásként. Ezzel a módszerrel frissíthető a külső munkafüzet elérési útja is (ha az áthelyezésre került). 

Bár távoli helyen vagy erőforrásokban tárolt munkafüzetek adatait közvetlenül nem szerkesztheti, továbbra is használhatja őket külső adatforrásként. Relatív út esetén az automatikusan teljes útvonalra konvertálódik. 

Ez a példa a munkakönyvtárban lévő `externalWorkbook.xlsx` fájlt igényli. A `Sheet1` munkalapon a B1‑ben sorozat‑nevet, az A2:A4‑ben kategória‑neveket, a B2:B4‑ben pedig numerikus értékeket kell tartalmaznia. A példa egy kördiagramot hoz létre, a munkafüzetet kapcsolja, és a [setRange](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#setRange)‑tel az A1:B4 tartományt egy sorozathoz és három kategóriához rendeli. Az eredményt a `Presentation_with_externalWorkbook.pptx` fájlba menti. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődjön‑e. 

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be vagy frissülnek a cél‑munkafüzetről, így a munkafüzet hiányozhat.  
* Ha `updateChartData` **true**, a diagramadatok frissülnek a cél‑munkafüzetről.  

Az alábbi példa egy helyettesítő URL‑t ad meg `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy a nem elérhető munkafüzetet betöltené. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **A diagram külső adatforrás‑munkafüzet útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához először ellenőrizze, hogy a diagram külső adatforrást használ‑e. Ha igen, a következő lépések szerint kérheti le az útvonalat. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.  
2. A nulláról indexelt első diát érje el.  
3. Ellenőrizze, hogy az első alakzat egy diagram.  
4. Olvassa ki a diagram adatforrás‑típusát.  
5. Ha a forrás egy külső munkafüzet, olvassa ki annak útvonalát.  

Ez a példa megnyitja a korábban létrehozott `externalWorkbook.pptx` fájlt, és az első diáján lévő első alakzatot vizsgálja. Ha az egy külső munkafüzethez kapcsolt diagram, a [getExternalWorkbookPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) értékét a konzolra írja. Ezután egy másolatot ment a prezentációból `Result.pptx` néven. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Diagramadatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik. 

Ez a példa a `presentation.pptx` fájlt igényli, amelynek az első diáján első alakzatként diagramnak kell lennie, valamint egy elérhető külső munkafüzetnek. Az első sorozat első adatpontjának értékét 100‑ra állítja, és a `presentation_out.pptx` fájlba menti. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet érintő módosításokat meg kell őrizni. 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides a diagram‑gyorsítótárban tárolt adatokból helyreállíthatja a munkafüzetet. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions)‑t, és állítsa a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)‑t **true**‑ra a prezentáció megnyitása előtt. 

Az alábbi JavaScript példa megnyitja a `presentation.pptx` fájlt, amelynek az első diáján első alakzatként egy, nem elérhető külső munkafüzetre hivatkozó diagramnak kell lennie, majd a [Chart.getChartData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével eléri a helyreállított adatokat: 

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótár‑adatok használata elfogadható tartalék, mert a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta végzett módosításokat. 

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van‑e összekapcsolva?**  
Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getDataSourceType) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) attribútummal; ha a forrás egy külső munkafüzet, akkor leolvasható a teljes útvonal, hogy biztosan külső fájlt használ.  

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Relatív út megadása esetén az automatikusan abszolút útvonalra konvertálódik. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.  

**Használhatók a hálózati erőforrásokon/megosztásokon lévő munkafüzetek?**  
Igen, ezek a munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként alkalmazhatók.  

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**  
A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX‑et is. Ha az eredetit változatlanul kell hagyni, használjon másolatot.  

**Mi a teendő, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad el jelszót a kapcsolódáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy visszafejtett másolat (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével) elkészítése, majd annak a másolatnak a használata.  

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramot érint a következő adatbetöltéskor.