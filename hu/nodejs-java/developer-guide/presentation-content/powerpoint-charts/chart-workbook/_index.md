---
title: Diagram munkafüzetek kezelése prezentációkban JavaScript használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/nodejs-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
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
description: "Fedezze fel az Aspose.Slides for Node.js via Java-t: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye prezentációs adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell dolgozni diagram munkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan kell beolvasni és írni a diagram adatokat munkafüzet adatfolyamokon keresztül, a munkafüzet cellákat diagram adatcímkeként használni, a munkalapgyűjteményekhez hozzáférni, és megadni az adatforrás típusát a diagram értékekhez.

Továbbá bemutatja a külső munkafüzetek diagramadat-forrásként való használatát. A példák demonstrálják, hogyan kell létrehozni és hozzárendelni egy külső munkafüzetet, lekérni egy diagramhoz kapcsolt külső munkafüzet útvonalát, és szerkeszteni a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet cellákhoz lásd az [Az üres cellák megjelenítésének szabályozása](/slides/hu/nodejs-java/chart-series/) cikket, amely bemutatja az üres cella és a nulla közti különbséget, valamint egy vonaldiagramot a rendelkezésre álló megjelenítési módokról.

## **Rejtett Sorok és Oszlopok Adatainak Felvétele**

A [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) használatával szabályozható, hogy a diagram rejtett munkalap sorok és oszlopok adatait ábrázolja-e. Állítsa `true` értékre, ha csak a látható cellákat szeretné ábrázolni, vagy `false` értékre, ha a látható és a rejtett cellákat egyaránt fel kívánja venni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példa bemutató](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz az első dia első alakzataként. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellákhoz a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével férhet hozzá, és a [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) segítségével ellenőrizheti a rejtett állapotukat. Ez a metódus anélkül jelzi a rejtett állapotot, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa ennek megfelelően `false`, `true` és `true` értékeket ír ki.

Ehhez a példához a diagram adatokat a beállítás módosítása után kell frissíteni: a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) segítségével tartja meg, és a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) segítségével tölti újra. Ha az összes cellát fel szeretné venni, használja a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) metódust a teljes tartomány, köztük a rejtett februári kategória visszaállításához. Az egyszerű flag‑változtatás nem elegendő a minta gyorsítótárba helyezett diagram adatainak és kategóriacímkéknek a frissítéséhez. A példa a visszaadott Node.js buffer‑t Java bájt tömbbé alakítja, mielőtt átadná az írási metódusnak.

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

            // Frissítse a diagram adatokat a beágyazott munkafüzetről.
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

A példa a prezentáció két változatát menti: egyet csak a látható Kiskereskedelem értékekkel (10 és 20), a másikat az összes hat értékkel. Az alábbi képek a két ábrázolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és Nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett cella, amely értéket tartalmaz, különbözik egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd [Az üres cellák megjelenítésének szabályozása](/slides/hu/nodejs-java/chart-series/#control-the-display-of-empty-cells) egy példáért.

## **Diagram Adattartományának Lekérdezése**

Mielőtt módosítaná a munkafüzet adatokat egy meglévő prezentációban, ellenőrizze a forrás tartományokat, hogy meghatározza, mely munkalap cellákat használja az egyes diagramok. A [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) metódus az aktuális adat tartományt adja vissza egy munkalapra hivatkozó képleteként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, és a `$A$1:$D$5` jelöli az A1‑től D5‑ig terjedő cellákat, beleértve a végső cellát is. A dollárjelek abszolút sor‑ és oszlopreferenciákat jelölnek.

A metódus a jelenlegi tartományt úgy olvassa, hogy nem változtatja meg a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException` kivételt dob. További információért lásd a [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi az alakzatokat diagramokért. Kiírja minden diagram nevét és forrás tartományát. Ha egy diagram nem használ munkafüzetet, egy üzenetet jelenít meg, majd a következő diagramra lép.

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

## **Diagram Adatainak Olvasása és Írása Munkafüzetből**

Az Aspose.Slides for Node.js via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) és a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagram adat munkafüzeteinek (Aspose.Cells‑sel szerkesztett diagramadatok) beolvasását és írását. **Megjegyzés**: a diagram adatának ugyanolyan módon kell felépülni, vagy hasonló szerkezettel kell rendelkeznie, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első diájának első alakzata egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A változások memóriában maradnak; a példa nem menti a prezentációt.

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

### **A Diagram Elrendezésének Ellenőrzése Munkafüzet Módosítása Után**

Ha egy beágyazott munkafüzetet egy módosított példányra cserél, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés a [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) hibához vezethet, amely index‑túl‑hatókör‑hibát dob. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat, a megjegyzés helye jelzi, ahol a munkafüzet szerkesztése történne; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

        // Módosítsa a munkafüzet bájtjait itt, például az Aspose.Cells használatával.

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

A gyűjtemények törlése megszünteti a régi adat hivatkozásait, mielőtt a munkafüzet visszaírásra kerül. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Egyéni Számformátumok Beállítása a Munkafüzet Celláira**

Használja a [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) metódust, hogy szabályozza, milyen módon jelenjenek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentéshez szükség lehet egy konverziós arány százalékos megjelenítésére négy tizedesjeggyel, illetve egy együttható öt tizedesjeggyel. Tartsa mindkét értéket numerikus formában, hogy továbbra is elérhetőek legyenek számítások és diagramrajzolás számára.

A számformátum csak a megjelenítést változtatja, a tárolt értéket nem. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; nem helyettesíti a tárolt számot `12.5`‑tel. Hasonlóképpen, a `0.00000` a `0.1234567`‑et `0.12346`‑ként mutatja anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) által visszaadott formátumot használja.

Az alábbi példa egy oszlopdiagramot hoz létre, és a celláit a [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével éri el. A 0‑ás munkalapon a B2 tartalmazza a konverziós arányt, a C2 pedig az együtthatót. Mindkét cella diagramértéket ad. A példa emellett engedélyezi az értékcímkéket, amelyek a forrás formátumhoz vannak linkelve.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A munkafüzet cellaformátumok különböznek a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellája értékét jeleníti meg, mert a [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) `true`‑ra van állítva, és a forrás számformátumot követi, mivel a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true`. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy alább látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) pedig `false`.

Ha egy adatcímkét önállóan szeretne formázni, állítsa a forrás‑link zászlót `false`‑ra, és adja meg a formátumot a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) segítségével. Ez nem módosítja a munkafüzet cella formátumát. Például egy `0.00` önálló címkeformátum az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagram Adatcímkék](/slides/hu/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) szekciót a címkék közvetlen formázásához.

Az alábbi kép a mentett prezentáció újranyitása után készült:

![Oszlopdiagram forrás‑linkelt címkékkel, amelyek `12.5000%` és `0.12346` értékeket mutatnak, valamint egy önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet Cellájának Beállítása Diagram Adatcímkének**

A munkafüzet celláiból származó szöveget felhasználhatja diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal a meglévő prezentáció első diájához. A 0‑ás munkalap A10‑A12 celláit használja az első sorozat első három címkéjének, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

## **Munkalapok Kezelése**

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) metódus hozzáférést biztosít a diagram munkafüzetben lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

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

## **Adatforrás Típusának Megadása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevet állít be különböző adatforrásokból. Az első név egy karakterlánc‑literál, a második a 0‑ás munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) felsorolás segítségével választható a forrás minden névhez. A példa a frissített sorozatnevekkel menti a prezentációt.

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

## **Nem Támogatott Beágyazott Munkafüzet Formátumok Felderítése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusát a [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) felsorolással együtt használva felderítheti a nem támogatott formátumokat, és kihagyhatja az érintett diagramokat. Ez a példa az első dián lévő alakzatokat ellenőrzi egy meglévő prezentációban, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden olyan diagramra, amely beágyazott .xlsb munkafüzetet tartalmaz.

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

        // Olvassa vagy módosítsa itt a támogatott diagram munkafüzet adatokat.
    }
} finally {
    presentation.dispose();
}
```

## **Külső Munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső Munkafüzet Létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) és a [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) metódusokat egy beágyazott diagram munkafüzet exportálásához egy fájlba, majd a diagram külső munkafüzethez való kapcsolásához.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja annak munkafüzetét. A fájlírás befejeződése után állítja be a külső munkafüzetet diagram adatforrásként, majd menti a hivatkozott prezentációt.

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

### **Külső Munkafüzet Beállítása**

A [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) metódus segítségével egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissítheti a külső munkafüzet útvonalát is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` munkalapja B1‑ben egy sorozat nevet, A2‑A4‑ben kategória neveket, B2‑B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, a munkafüzetet összekapcsolja, és a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára képezi le. Ezután menti a prezentációt a hivatkozott diagrammal.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődik‑e.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adat nem töltődik be vagy frissül a cél munkafüzetről, így a munkafüzet hiányzó is lehet.
* Ha `updateChartData` **true**, a diagram adat frissül a cél munkafüzetről.

Az alábbi példa egy helyettesítő URL‑t ad meg, `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy a nem elérhető munkafüzetet betöltené.

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

### **Diagram Külső Adatforrás Munkafüzet Útvonalának Lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és olvassa le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot ellenőrzi, amely egy külső munkafüzettel hivatkozott diagram. Ha a diagram külső munkafüzethez van csatolva, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) értékét írja a konzolra, majd ment egy másolatot a prezentációról.

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

### **Diagram Adatainak Szerkesztése**

A külső munkafüzettek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzettek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. Beállítja az első sorozat első adatpontjának cella‑alapú értékét 100‑ra, és menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a hivatkozott külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg akarja őrizni.

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

### **Munkafüzet Visszaállítása a Diagram Gyorsítótárból**

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides képes rekonstruálni a diagram munkafüzetét a prezentáció gyorsítótárban tárolt adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) metódust, és állítsa a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) értékét **true**‑ra, mielőtt megnyitná a prezentációt.

Az alábbi JavaScript példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem‑elérhető külső munkafüzettel hivatkozik. A helyreállított adatot a [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével éri el:

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

        // Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem elérhető és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótárban tárolt diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó frissítése után végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram egy külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) tulajdonsága; ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonallá alakítja. A prezentáció az abszolút útvonalat tárolja a PPTX‑ben, ezért a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatók hálózati erőforrásokon/megosztott meghajtókon lévő munkafüzetek?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzettek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [linket tárol a külső fájlra](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). A cella‑alapú diagramadatok szerkesztése szintén frissítheti a kapcsolt helyi XLSX fájlt. Ha az eredeti munkafüzetet változatlanul kell hagyni, használjon egy másolatot.

**Mit kell tenni, ha a külső fájl jelszó‑védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Egy gyakori megoldás, hogy a védelmet előzetesen eltávolítja, vagy egy visszafejtett másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével) készít, majd arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagram esetén megjelenik a következő adatbetöltéskor.