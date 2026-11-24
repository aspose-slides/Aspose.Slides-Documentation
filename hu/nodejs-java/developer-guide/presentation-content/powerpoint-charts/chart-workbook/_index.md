---
title: Diagrammunkafüzetek kezelése bemutatókban JavaScript segítségével
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
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js via Java-t: egyszerűen kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a bemutató adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozzunk diagramm‑munkafüzetekkel az Aspose.Slides-ben. Bemutatja, hogyan olvassunk és írjunk diagrammadatokat munkafüzet‑folyamokon keresztül, hogyan használjunk munkafüzet‑cellákat diagrammadatok címkéiként, hogyan érjünk el munkalap‑gyűjteményeket, és hogyan adhatjuk meg az adatforrás típusát a diagram értékekhez.

Azon felül leírja, hogyan használhatók külső munkafüzetek diagram adatforrásként. A példák bemutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan szerezzük meg egy diagramhoz kapcsolt külső munkafüzet elérési útját, és hogyan szerkesszük a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet‑cellák esetén lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/nodejs-java/chart-series/) a üres cella és a nulla közti különbségről, valamint a vonaldiagram a rendelkezésre álló megjelenítési módok összehasonlításáról.

## **Rejtett sorok és oszlopok adatinak bevonása**

Használd a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) metódust annak szabályozására, hogy a diagram a rejtett munkalap‑sorokból és -oszlopokból származó adatokat ábrázoljon‑e. Állítsd `true`‑ra, hogy csak a látható cellákat ábrázolja, vagy `false`‑ra, hogy mind a látható, mind a rejtett cellákat vegye figyelembe. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [sample presentation](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz első alakzatként az első dián. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik még mindig értékeket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellákat a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével érheted el, és a [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) segítségével ellenőrizheted a rejtett állapotukat. Ez a metódus a rejtett állapotot anélkül jelenti ki, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa ennek megfelelően `false`, `true`, és `true` értékeket ír ki.

Ehhez a példához a diagram adatainak frissítése a ábrázolási beállítás módosítása után történik: a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) segítségével tartod meg, majd a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/)‑vel töltöd vissza. Az összes cella bevonásakor használd a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/)‑t is, hogy visszaállítsd a teljes tartományt, beleértve a rejtett februári kategóriát is. Csak a jelző módosítása nem elegendő a mintában gyorsítótárazott diagramadatok és kategóriacímkék frissítéséhez. A példa a visszakapott Node.js puffert Java‑byte‑tömbbé alakítja, mielőtt a írási metódusnak átadná.

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

            // Frissítse a diagramadatokat a beágyazott munkafüzettel.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Állítsa vissza a teljes forrástartományt, beleértve a rejtett kategóriákat.
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

A példa a bemutató két változatát menti: egyet csak a látható kiskereskedelmi értékekkel (10 és 20), a másikat pedig mind a hat értékkel. Az alábbi képek a két ábrázolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) meghatározza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja ki vagy adja hozzá a rejtett forrásadatot. Lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/nodejs-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérdezése**

Mielőtt frissítenéd a munkafüzet adatait egy meglévő bemutatóban, vizsgáld meg a forrás‑tartományokat, hogy megtudd, mely munkalap‑cellákat használja az egyes diagramok. A [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) metódus a jelenlegi adat‑tartományt adja vissza munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlop‑hivatkozásra utalnak.

A metódus a jelenlegi tartományt anélkül olvassa ki, hogy módosítaná a diagramot vagy a munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információkért lásd a [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)‑t.

Ez a példa megnyit egy bemutatót, és minden dián közvetlenül ellenőrzi a diagramokat. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, és a következő diagramra lép tovább.

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

## **Diagram adatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Node.js via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) és a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) metódusokat, amelyekkel diagramadat‑munkafüzeteket (Aspose.Cells‑sel szerkesztett diagramadatokat tartalmazó) olvashatsz és írhatsz. **Note** hogy a diagramadatnak ugyanúgy fel kell épülnie, vagy hasonló szerkezettel kell rendelkeznie, mint a forrásnak.

Ez a példa egy olyan bemutatót használ, amelynek első alakzata az első dián egy diagram. Beolvassa a beágyazott munkafüzetet bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változtatások csak a memóriában maradnak; a példa nem menti a bemutatót.

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

Ha egy beágyazott munkafüzetet egy módosítottal helyettesítesz, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az inkonzisztencia a [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) hibához vezethet, amely index‑kívül‑tartomány hibát dob. Töröld a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírnád a diagramra. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet‑szerkesztés; a futtatható példa visszaírja az eredeti munkafüzetet és a memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése eltávolítja a régi adat‑hivatkozásokat, mielőtt a munkafüzet visszaírásra kerülne. Újraépíts minden szükséges sorozat‑ és kategória‑leképezést a frissített munkafüzethez, mielőtt a diagramot használnád.

## **Válassza ki a kategória címkék tárolásának módját**

A [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorycollection/setusecells/)‑t hívd meg az üres kategória‑gyűjteményen, mielőtt címkéket adnál hozzá. Használj munkalap‑cellákat azokhoz a címkékhez, amelyek munkafüzet‑adatokra hivatkoznak vagy hierarchiát alkotnak, például év szerint csoportosított negyedéveket. Használj karakter‑literálokat egyszerű szintű címkékhez, amelyeknek nincs szükségük cellahivatkozásokra. Ez a beállítás csak a kategóriákra vonatkozik. A példában mindkét diagram a numerikus sorozatértékekhez munkalap‑cellákat használ.

A példa két oszlopdiagramot hoz létre, és kiírja a tárolási módot, majd a `Q1 Q2 Q3 Q4` sorozatot minden diagramra. Munkalap‑alapú címkék esetén a [ChartCategory.getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getascell/) visszaadja az alatta lévő cellát, a [ChartDataCell.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getvalue/) pedig a címkét. Literál címkék esetén közvetlenül a [ChartCategory.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getvalue/)‑vel olvasd ki a szöveget. A példa mindkét diagramot `category-labels.pptx`‑ben menti.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    for (const useCells of [true, false]) {
        const x = useCells ? 20 : 360;
        const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, x, 20, 320, 250);
        const data = chart.getChartData();
        data.getSeries().clear();
        const categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        const workbook = data.getChartDataWorkbook();
        const seriesName = workbook.getCell(0, 0, 1, "Sales");
        const series = data.getSeries().add(seriesName, chart.getType());
        for (let row = 1; row <= 4; row++) {
            const label = "Q" + row;
            if (useCells) {
                const labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            const valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        const storedInCells = categories.getUseCells();
        const labels = [];
        for (let i = 0; i < categories.size(); i++) {
            const category = categories.get_Item(i);
            labels.push(storedInCells ? category.getAsCell().getValue() : category.getValue());
        }
        console.log("UseCells = " + storedInCells + ": " + labels.join(" "));
    }

    presentation.save("category-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyéni számformátumok beállítása munkafüzet cellákhoz**

Használd a [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/)‑t annak szabályozására, hogy a numerikus értékek hogyan jelenjenek meg a diagram beágyazott munkafüzeteben. Például egy jelentéshez lehet, hogy a konverziós arányt százalékos formában, négy tizedesjeggyel, a koeficienset pedig öt tizedesjeggyel kell megjeleníteni. Mindkét értéket numerikus formában tartsd, hogy számításokhoz és diagramábrázoláshoz továbbra is elérhetőek legyenek.

A számformátum a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum `0.125`‑öt `12.5000%`‑ként jelenít meg; nem cseréli le a tárolt számot `12.5`‑re. Hasonlóan, a `0.00000` `0.1234567`‑et `0.12346`‑ként jelenít meg anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) által visszaadott formátum lesz használva.

Az alábbi példa egy oszlopdiagramot hoz létre, és a [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/)‑on keresztül éri el a cellákat. A 0‑s munkalapon a B2 a konverziós arányt, a C2 a koeficienst tartalmazza. Mindkét cella diagramértékeket szolgáltat. A példa továbbá engedélyezi a forrásformátumokhoz kapcsolt értékcímkéket.

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

A munkafüzet cellaformátumok elkülönülnek a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a saját forráscellájának értékét jeleníti meg, mert a [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) `true`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) is `true`. A bemutató mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy alább is látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) pedig `false`.

Egy adatcímke független formázásához állítsd a forrás‑hivatkozási jelzőt `false`‑ra, és rendelj hozzá egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/)‑lel. Ez nem változtatja meg a munkafüzet cellaformátumát. Például egy független `0.00` címkeformátum az első értéket `0.13`‑ként jeleníti meg, miközben a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Chart Data Labels](/slides/hu/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) szekciót a közvetlen címkeformázáshoz.

![Oszlopdiagram forrásra hivatkozó címkékkel, amelyek 12.5000% és 0.12346 értékeket jelenítenek, valamint önállóan formázott numerikus tengely.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkének**

Szöveget használhatsz a munkafüzet celláiból diagram adatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő bemutató első diájához. A 0‑s munkalap A10:A12 celláit használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és elmenti a módosított bemutatót.

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

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) metódus hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és minden munkalap nevét kiírja a konzolra.

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

A sorozatpont értékek közvetlenül numerikus literálokként is tárolhatók. Lásd a [Set Series Values Using Numeric Literals](/slides/hu/nodejs-java/chart-series/#set-series-values-using-numeric-literals) teljes példát, amely elmenti és beolvassa ezeket. A pontértékek forrás‑típusa elkülönül a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első név egy karakter‑literál, a második a 0‑s munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) felsorolás választja ki minden név forrását. A példa a módosított sorozatnevekkel menti a bemutatót.

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

## **Nem támogatott beágyazott munkafüzet formátumok felderítése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A `getEmbeddedWorkbookType` metódust a [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)‑n és a [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) felsoroláson keresztül használhatod a nem támogatott formátumok felderítésére és az ilyen diagramok kihagyására. Ez a példa a meglévő bemutató első diájának alakzatait ellenőrzi, a nem diagram alakzatokat kihagyja, és minden beágyazott .xlsb munkafüzettel rendelkező diagramra diagnosztikai üzenetet ír ki.

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

        // Olvasd vagy módosítsd a támogatott diagrammunkafüzet adatokat itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használd a [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) és a [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) metódusokat egy beágyazott diagrammunkafüzet exportálásához fájlba, majd a diagramhoz való kapcsoláshoz.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és exportálja a munkafüzetét. A fájlírás befejezése után rendeli hozzá a külső munkafüzetet diagram adatforrásként, majd menti a kapcsolt bemutatót.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) metódus segítségével egy külső munkafüzetet rendelhetsz egy diagramhoz adatforrásként. Ezzel a módszerrel a külső munkafüzet elérési útját is frissítheted (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatainak szerkesztése nem támogatott, ilyen munkafüzetek továbbra is használhatók külső adatforrásként. Ha relatív út van megadva egy külső munkafüzethez, az automatikusan teljes úttá konvertálódik.

Ez a példa egy `Sheet1` nevű munkalappal rendelkező külső munkafüzetet használ, amely B1‑ben sorozatnevet, A2:A4‑ben kategórianévket és B2:B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/)‑t használja az A1:B4 tartomány egy sorozatra és három kategóriára való leképezéséhez. A diagrammal összekapcsolt bemutatót menti.

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

Az `updateChartData` paraméter a [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) metódusban szabályozza, hogy a munkafüzet be legyen‑töltve.

* Amikor `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adatot nem töltik be vagy frissítik a cél‑munkafüzettel, ezért a munkafüzet lehet elérhetetlen.
* Amikor `updateChartData` **true**, a diagram adat frissül a cél‑munkafüzettel.

Az alábbi példa egy helyőrző URL‑t ad meg, ahol az `updateChartData` **false**‑ra van állítva. A kördiagram alapértelmezett adatait megtartja, és a bemutatót a nem betöltött munkafüzet nélkül menti.

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

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizd, hogy a diagram külső adatforrást használ‑e, és kérd le annak munkafüzet‑útvonalát.

Ez a példa a bemutató első diájának első alakzatát ellenőrzi, amely külső munkafüzettel van összekapcsolva. Ha egy diagram külső munkafüzettel van összekapcsolva, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)‑t írja a konzolra. Ezután a bemutató egy másolatát elmenti.

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

A külső munkafüzetek adatait ugyanúgy szerkesztheted, ahogy a belső munkafüzetek tartalmát módosítanád. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat, és hozzáférhető külső munkafüzettel van összekapcsolva. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, és menti a módosított bemutatót. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használj másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram egy hiányzó vagy elérhetetlen külső munkafüzetet használ, az Aspose.Slides újraépítheti a diagram munkafüzetét a bemutatóban gyorsítótárazott adatokból. Hozd létre a [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), hívd meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/), és a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)‑t állítsd **true**‑ra, mielőtt megnyitnád a bemutatót.

Az alábbi JavaScript példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy elérhetetlen külső munkafüzetre hivatkozik. A helyreállított adatokat a [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével éri el:

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

        // Olvasd vagy módosítsd a helyreállított munkafüzet adatait itt.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet elérhetetlen és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezd a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a bemutató legutóbbi frissítése óta történt változtatásokat.

## **FAQ**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e kapcsolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) tulajdonsággal; ha a forrás egy külső munkafüzet, kiolvashatod a teljes útvonalat, hogy megbizonyosodj arról, egy külső fájl van‑e használatban.

**Támogatottak a relatív utak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív utat adsz meg, az automatikusan átalakul abszolút úttá. A bemutató az abszolút utat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezése esetén a hivatkozás frissítése szükséges lehet.

**Használhatók hálózati erőforrásokon/megosztott helyeken lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ben nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a bemutató mentésekor?**

A bemutató egy [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Használj másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mi a teendő, ha a külső fájl jelszó‑védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd a másolatra való hivatkozás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját linkjét tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.