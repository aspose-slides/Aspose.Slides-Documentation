---
title: JavaScript segítségével diagram munkafüzeteinek kezelése prezentációkban
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/nodejs-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
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
description: "Fedezze fel az Aspose.Slides for Node.js via Java-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram munkafüzeteivel az Aspose.Slides-ban. Megmutatja, hogyan lehet a diagram adatait munkafüzet adatfolyamokkal olvasni és írni, a munkafüzet cellákat diagram adatcímkékként használni, a munkalap-gyűjteményekhez hozzáférni, és megadni az adatforrás típusát a diagram értékekhez.

A cikk kitér a külső munkafüzetekkel való munkavégzésre diagram adatforrásként. A példák azt mutatják be, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet elérési útját, és hogyan szerkeszthetjük a diagram adatait, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzetcellák esetén tekintse meg az [Az üres cellák megjelenítésének vezérlése](/slides/hu/nodejs-java/chart-series/) oldalt, amely bemutatja a különbséget az üres cella és a nulla között, valamint egy vonaldiagram-összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) metódust annak szabályozására, hogy egy diagram a rejtett munkalap sorokból és oszlopokból származó adatokat ábrázolja-e. Állítsa `true`‑ra, ha csak a látható cellákat kívánja ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt bele akarja foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt el vagy jelenít meg munkalap sorokat vagy oszlopokat.

A [minta bemutató](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz, amely az első diájának első alakzata. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forráscellákhoz a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével férhet hozzá, és a [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden) olvasásával ellenőrizheti a rejtett állapotukat. Ez a metódus a rejtett állapotot jelentése nélkül módosítja. Ebben a fájlban a B2 látható, a B3 a rejtett sorba tartozik, és a C2 a rejtett oszlopba; a példa `false`, `true` és `true` értékeket ír ki.

Ehhez a példához frissítse a diagram adatokat a megjelenítési beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) segítségével, majd töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) segítségével. Az összes cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Egyszerűen csak a jelző megváltoztatása nem elegendő a példa gyorsítótárazott diagram adatainak és kategória címkéinek frissítéséhez. A példa a visszaadott Node.js puffert Java byte‑tömbbé alakítja, mielőtt átadná a írási metódusnak.

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

            // Frissítse a diagram adatokat a beágyazott munkafüzetből.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Állítsa vissza a teljes forrás-tartományt, beleértve a rejtett kategóriákat.
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

A példa a prezentáció két változatát menti: egyet csak a látható kiskereskedelmi értékekkel (10 és 20), a másikat az összes hat értékkel. Az alábbi képek a két ábrázolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben továbbra is rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella eltér egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) szabályozza, hogyan jelennek meg a hiányzó értékek; ez nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd az [Az üres cellák megjelenítésének vezérlése](/slides/hu/nodejs-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérdezése**

Mielőtt meglévő prezentációban módosítaná a munkafüzet adatokat, ellenőrizze a forrás‑tartományokat, hogy meghatározza, mely munkalap‑cellákat használja az egyes diagramok. A [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) metódus a jelenlegi adat‑tartományt adja vissza munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlop‑referenciát jelölnek.

A metódus a jelenlegi tartományt a diagram vagy munkafüzet módosítása nélkül olvassa. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információkért lásd a [ChartData API referencia](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi a formákat diagramokra. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, és folytatja a következő diagrammal.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Diagram adatok olvasása és írása munkafüzetről**

Aspose.Slides for Node.js via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyek lehetővé teszik a diagram adatmunkafüzeteinek (Aspose.Cells‑ben szerkesztett diagramadatok) olvasását és írását. **Megjegyzés:** a diagram adatokat ugyanúgy kell szervezni, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzettet byte‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzettet. A módosítások csak memóriában maradnak; a példa nem menti a prezentációt.

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

Ha egy beágyazott munkafüzettet módosított változattal cserél ki, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeket. Ez a nem egyezés a [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) metódus hibájához vezethet, amely index‑túl‑range hibát dob. Törölje a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített munkafüzettet a diagramba. Ez a példa egy diagramot használ, amely az első diájának első alakzata. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

        // Itt módosítsa a munkafüzet bájtjait, például az Aspose.Cells használatával.

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

A gyűjtemények törlése megszünteti a régi adat‑referenciákat, mielőtt a munkafüzet vissza lenne írva. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzettel, mielőtt használja a diagramot.

## **Munkafüzet cella beállítása diagram adatcímkének**

A munkafüzet cellák szövegét használhatja diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal a meglévő prezentáció első diájához. Az első soron (0‑ás index) az A10:A12 tartományt használja az első három címkének az első sorozatban, engedélyezi a cellákból származó címkéket, és elmenti a frissített prezentációt.

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

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) metódus hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy alapértelmezett adatokkal ellátott kördiagramot hoz létre, és minden munkalap nevét a konzolra írja.

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

## **Adatforrás típusának meghatározása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál; a második a 0‑ás indexű munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) felsorolás határozza meg az egyes nevek forrását. A példa a frissített sorozatnevekkel menti a prezentációt.

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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) osztályon a [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) felsorolással együtt használva észlelheti a nem támogatott formátumokat, és átlépheti ezeket a diagramokat. Ez a példa az első diáján lévő alakzatokat ellenőrzi, kihagyja a diagramtól eltérő alakzatokat, és minden .xlsb‑t tartalmazó diagramhoz diagnosztikai üzenetet ír ki.

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

        // Olvassa vagy módosítsa itt a támogatott diagram munkafüzeti adatokat.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzeteket adatforrásként a diagramokhoz.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) metódusokat egy beágyazott diagram munkafüzete fájlba exportálásához, és a diagram külső munkafüzethez való csatolásához.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és exportálja annak munkafüzettét. A fájlírás befejezése után a külső munkafüzettet a diagram adatforrásaként rendeli hozzá, majd elmenti a kapcsolt prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) metódussal egy külső munkafüzettet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissítheti a külső munkafüzet elérési útját is (amennyiben az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetteket nem szerkesztheti, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg a külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a példa egy külső munkafüzettel dolgozik, amelynek `Sheet1` munkalapja B1‑ben egy sorozatnevet, A2:A4‑ben kategória neveket és B2:B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzettet, és a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) használatával az A1:B4 tartományt egy sorozatra és három kategóriára térképezi. A kapcsolt diagrammal menti a prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődjön‑e.

* Amikor `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adat nem töltődik be vagy frissül a célmunkafüzettel, ezért a munkafüzet lehet, hogy nem elérhető.
* Amikor `updateChartData` **true**, a diagram adatai a célmunkafüzettel frissülnek.

A következő példa egy helyőrző URL‑t ad meg `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy a nem elérhető munkafüzetet betöltené.

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

### **Diagram külső adatforrás munkafüzetének elérési útjának lekérdezése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le annak munkafüzet‑útvonalát.

Ez a példa az első diájának első alakzatát vizsgálja egy olyan prezentációban, amely külső munkafüzettel van kapcsolva. Ha egy diagram külső munkafüzettel van összekapcsolva, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)‑t írja a konzolra. Ezután a prezentáció egy másolatát menti.

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

### **Diagram adatainak szerkesztése**

A külső munkafüzetben lévő adatokat ugyanúgy szerkesztheti, mint a belső munkafüzettek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első diájának első alakzata, és egy elérhető külső munkafüzettel van összekapcsolva. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd elmenti a frissített prezentációt. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides visszaállíthatja a diagram munkafüzettét a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions)‑t, és állítsa a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)‑t **true**‑ra a prezentáció megnyitása előtt.

Az alábbi JavaScript példa helyreállítja a munkafüzetadatokat egy olyan diagramhoz, amely az első diájának első alakzata, és egy nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatokat a [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el:

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

        // Olvassa vagy módosítsa itt a helyreállított munkafüzet adatokat.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárban lévő diagramadatok használata elfogadható megoldás, mivel a gyorsítótár esetleg nem tartalmazza a külső munkafüzetben a prezentáció utolsó frissítése óta végzett változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van‑e összekapcsolva?**

Igen. A diagram rendelkezik egy [adatforrás típusa](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) és egy [útvonal egy külső munkafüzethez](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); ha a forrás egy külső munkafüzet, kiolvashatja a teljes elérési utat, hogy megbizonyosodjon arról, hogy egy külső fájlt használnak.

**Támogatottak‑e a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonallá alakul. A prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban, ezért a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatók‑e hálózati erőforrásokon vagy megosztott meghajtókon lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzettek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [hivatkozást a külső fájlra](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) tárol. A cella‑alapú diagramadatok szerkesztése szintén frissítheti a kapcsolt helyi XLSX‑fájlt. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mi a teendő, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a hivatkozás során. Egy gyakori megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd a másolatra való hivatkozás.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.