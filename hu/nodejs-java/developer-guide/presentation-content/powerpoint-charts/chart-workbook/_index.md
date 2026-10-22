---
title: Diagram munkafüzetek kezelése prezentációkban JavaScript használatával
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
description: "Fedezze fel az Aspose.Slides for Node.js via Java megoldást: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy optimalizálja prezentációi adatait."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan dolgozhatunk diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan olvassuk és írjuk a diagram adatokat munkafüzet‑adatfolyamok segítségével, hogyan használjuk a munkafüzet cellákat diagram adatcímkékként, hogyan érjük el a munkalap‑gyűjteményeket, és hogyan adhatjuk meg az adatforrás típusát a diagram értékekhez.

Az is tárgyalt, hogyan használhatók külső munkafüzetek diagram adatforrásként. A példák bemutatják, hogyan hozhatunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatokat jelző munkafüzet‑cellákhoz lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/nodejs-java/chart-series/) oldalát, ahol megtalálható a különbség egy üres cella és a nulla között, valamint egy vonaldiagram‑összehasonlítás a rendelkezésre álló megjelenítési módokról.

## **Adatok belefoglalása rejtett sorokból és oszlopokból**

Használja a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) metódust, hogy szabályozza, a diagram csak a látható munkalap‑sorokból és -oszlopokból származó adatokat ábrázolja‑e. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt bele akarja foglalni. Ez a beállítás a diagram ábrázolását befolyásolja; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példa prezentáció](hidden-source-data.pptx) első diáján egy oszlopdiagramot tartalmazó alakzatot mutat. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik értékkel rendelkeznek.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forrás‑cellák elérése a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével történik, a rejtettség ellenőrzéséhez pedig a [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) metódust kell használni. Ez a módszer a rejtett állapotot jelenti vissza anélkül, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa **false**, **true** és **true** értékeket ír ki.

Ehhez a példához a diagram adatainak frissítése a megjelenítési beállítás módosítása után szükséges: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) segítségével, és töltsa be újra a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) segítségével. Az összes cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) metódust is, hogy helyreállítsa a teljes tartományt, beleértve a rejtett februári kategóriát. Csak a jelző módosítása nem elegendő a példa gyorsítótárazott diagram adatainak és kategória címkéinek frissítéséhez. A példa a visszaadott Node.js puffert Java bájt‑tömbbé alakítja, mielőtt a írási metódusnak átadná.

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

A példa két verziót ment a prezentációból: egyet, amelyben csak a látható kiskereskedelmi értékek (10 és 20) szerepelnek, és egy másikat, amelyben mind a hat érték megjelenik. Az alábbi képek a két ábrázolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 január és március hónapokra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és nagykereskedelmi értékek január, február és március hónapokra.](hidden_cells_False.png) |

Egy rejtett cella, amely értéket tartalmaz, különbözik egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) vezérli, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrás‑adatokat. Lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/nodejs-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat tartományának lekérdezése**

Mielőtt egy meglévő prezentáció munkafüzet‑adatait frissítené, ellenőrizze a forrás‑tartományokat, hogy megtudja, mely munkalap‑cellákat használja az egyes diagramok. A [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) metódus az aktuális adat‑tartományt adja vissza munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek az abszolút sor‑ és oszlophivatkozásokat jelzik.

A metódus a tartományt anélkül olvassa, hogy módosítaná a diagramot vagy a munkafüzetet. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információkért tekintse meg a [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi az alakzatokat diagramokért. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, majd továbblép a következő diagramra.

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

## **Diagram adatok olvasása és írása egy munkafüzetből**

Az Aspose.Slides for Node.js via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) és a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagram adat‑munkafüzetek (az Aspose.Cells‑el szerkesztett diagram adatokat tartalmazó) olvasását és írását. **Megjegyzés**, hogy a diagram adatainak ugyanolyan módon kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változtatások a memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet módosított változattal helyettesít, a diagram a korábbi sorozat‑ és kategória‑gyűjteményeket megtartja. Ez a nem egyezés a [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) hibához vezethet, amely „index‑out‑of‑range” kivételt dob. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramra. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése megszünteti a régi adat‑referenciákat, mielőtt a munkafüzet visszaírásra kerül. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Egyéni számformátumok beállítása munkafüzet cellákhoz**

Használja a [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) metódust, hogy szabályozza, numerikus értékek hogyan jelenjenek meg egy diagram beágyazott munkafüzetében. Például egy jelentésben a konverziós arányt százalékban, négy tizedesjeggyel, a koefficienst pedig öt tizedesjeggyel kell megjeleníteni. Mindkét értéket tartsuk numerikus formában, hogy számítások és diagram ábrázolás céljából elérhetőek maradjanak.

A számformátum a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; nem cseréli le a tárolt számot `12.5`‑re. Hasonlóképpen, a `0.00000` a `0.1234567` értéket `0.12346`‑ként jeleníti meg, anélkül hogy a tárolt értéket lekerekítené. Ha az egyedi formátum üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) által visszaadott formátum kerül felhasználásra.

A következő példa egy oszlopdiagramot hoz létre, és a cellákat a [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével érheti el. Az 0‑s munkalapon a B2 tartalmazza a konverziós arányt, a C2 pedig a koefficienst. Mindkét cella a diagram értékeit szolgáltatja. A példa aktiválja a forrás‑formátumokra hivatkozó értékcímkéket.

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

A munkafüzet cellaformátumok különállóak a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás‑cellája értékét jeleníti meg, mivel a [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) `true`‑ra van állítva, és a forrás számalakítást a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true` beállítással követi. A prezentáció mentése és újbóli megnyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy az alább is látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) pedig `false`‑ra.

Egy adatcímke önálló formázásához állítsa a forrás‑hivatkozás zászlót `false`‑ra, és adjon meg egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) segítségével. Ez nem változtatja meg a munkafüzet cellájának formátumát. Például egy önálló címkeformátum `0.00` esetén az első érték `0.13`‑ként jelenik meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagramadat‑címkék](/slides/hu/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) oldalt a közvetlen címkeformázáshoz.

Az alábbi kép a mentett prezentáció újbóli megnyitása után lett renderelve:

![Oszlopdiagram forrás‑hivatkozású címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, valamint egy önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkének**

Használhatja a munkafüzet cellák szövegét diagram adatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. A 0‑s munkalap A10:A12 tartományát használja az első három címkehez az első sorozatban, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) metódus hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és minden munkalap nevét a konzolra írja ki.

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

## **Az adatforrás típusának megadása**

A sorozat‑pont értékek tárolhatók közvetlenül numerikus literálokként is. Lásd a [Sorozatértékek beállítása numerikus literálokkal](/slides/hu/nodejs-java/chart-series/#set-series-values-using-numeric-literals) oldalt egy teljes példáért, amely elmenti és beolvassa ezeket. A pontértékek forrás‑típusa különálló a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál, a második a 0‑s munkalap C1 cellájára hivatkozik. A [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) felsorolás kiválasztja a forrást minden névhez. A példa menti a prezentációt a frissített sorozatnevekkel.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusát a [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok észlelésére, és átugorhatja ezeket a diagramokat. Ez a példa ellenőrzi az első dia alakzatait egy meglévő prezentációban, kihagyja a diagramok‑kívüli alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb‑t tartalmazó diagramhoz.

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

        // Olvassa vagy módosítsa a támogatott diagram munkafüzet adatokat itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) és a [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) metódusokat, hogy egy beágyazott diagram munkafüzetet exportáljon fájlba, és a diagramot ehhez a külső munkafüzethez csatolja.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és exportálja a munkafüzettét. A fájl írása befejeződik, mielőtt a külső munkafüzetet diagram adatforrásként hozzárendelné, majd menti a linkelt prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) metódussal egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezt a metódust arra is használhatja, hogy frissítse a külső munkafüzet útvonalát (ha a fájl áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a példa egy külső munkafüzetet használ, amelynek a `Sheet1` munkalapján a B1 cellában egy sorozat‑név, az A2:A4 tartományban kategória‑nevek, a B2:B4 tartományban numerikus értékek vannak. A példa kördiagramot hoz létre, csatolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára map‑olja. A prezentációt a linkelt diagrammal menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődjön‑e.

* Ha az `updateChartData` `false`, csak a munkafüzet útvonala frissül. A diagram adatai nem töltődnek be vagy frissülnek a cél munkafüzetről, így a munkafüzet elérhetetlen is lehet.
* Ha az `updateChartData` `true`, a diagram adatai frissülnek a cél munkafüzetről.

Az alábbi példa egy helyőrző URL‑t ad meg, az `updateChartData` pedig `false`‑ra van állítva. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy a nem elérhető munkafüzetet betöltené.

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

### **Diagram külső adatforrás‑munkafüzet útvonalának lekérdezése**

Annak meghatározásához, hogy melyik munkafüzet van csatolva egy diagramhoz, ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérdezze le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot vizsgálja egy olyan prezentációban, amelyhez külső munkafüzet van csatolva. Ha a diagram külső munkafüzettel van összekapcsolva, a példa kiírja a [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) értékét a konzolra, majd a prezentáció egy másolatát menti.

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

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetekét. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért ha az eredeti munkafüzetet meg kell őrizni, használjon másolatot.

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

### **Munkafüzet visszaállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides visszaépítheti a diagram munkafüzettét a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/)‑t, és állítsa a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)‑t `true`‑ra, mielőtt megnyitná a prezentációt.

Az alábbi JavaScript példa visszaállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatokat a [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével éri el:

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

Ha a külső munkafüzet nem elérhető, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. A helyreállítást csak akkor engedélyezze, ha a gyorsítótárazott diagram adatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta történt változásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e csatolva?**

Igen. A diagramnek van egy [adatforrás típusa](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) és egy [útvonala egy külső munkafüzethez](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); ha a forrás egy külső munkafüzet, a teljes útvonal kiolvasásával ellenőrizhető, hogy külső fájlt használ-e.

**Támogatottak-e a relatív útvonalak a külső munkafüzetelekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonalra konvertálódik. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezésekor a hivatkozást frissíteni kell.

**Használhatók-e a hálózati erőforrásokon/megosztásokon lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja-e a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Ha az eredeti munkafüzetet változatlanul kell hagyni, használjon másolatot.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Egy gyakori megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy feloldott másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), és arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramnál megjelenik, amikor legközelebb betöltik az adatokat.