---
title: Diagram tengelyek testreszabása prezentációkban JavaScript használatával
linktitle: Diagramtengely
type: docs
url: /hu/nodejs-java/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságai
- maximális érték
- minimális érték
- tengely vonal
- dátumformátum
- tengely cím
- tengely pozíció
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan használhat JavaScriptet az Aspose.Slides for Node.js Java-n keresztül a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk céljából."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Node.js Java segítségével. Bemutatja a kiszámolt tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címkék és a jelölőjel intervallumait, a dátum kategóriákat és formázást, a cím forgását, a tengely pozicionálását, a megjelenítési egységeket, valamint a logaritmikus skálázást.

## **A maximális értékek lekérése a függőleges tengelyen a diagramokban**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) elemet, és adjon hozzá egy területdiagramot az alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) metódust a kiszámolt tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa a [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) és a [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) metódusokat a tengely határokhoz, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) és a [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) metódusokat a jelölőjelek intervallumához. A [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) időegység-skálákat biztosít, amelyek a dátumtengelyek esetén relevánsak. A példa ezeket az értékeket helyi változókba menti, és elmenti a diagramot.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcserélésére a diagram adatainál. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatcsoportosítást; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) metódust használja az alapértelmezett adatok `Sheet1!A1:D5` tartományra kötéséhez, beleértve a fejlécsort és a kategóriaoszlopot, a sorok és oszlopok cseréje előtt. Egy négy sorozatú és három kategóriás diagramot ment.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egy tengely ábrázolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) metódust egy kategória vagy értéktengely megfordításához. Például egy vízszintes oszlopdiagram a projekt szakaszait felülről lefelé jelenítheti meg ugyanabban a sorrendben, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. Egy tengely megfordítása megváltoztatja az ábrázolási irányt; nem rendezi újra vagy átrendezi a munkafüzet adatait. Ezzel szemben a [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) felcseréli a sorozatok és kategóriák szerepét.

A következő példa egy három szakaszos és egy sorozatú vízszintes oszlopdiagramot hoz létre. Egy három diával rendelkező prezentációt ment: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Dia 2: jelenítse meg az első kategóriát a tetején.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // A vízszintes értéktengelyt alul tartsa.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Dia 3: csak a vízszintes numerikus skálát fordítsa meg.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy tengely megfordítása áthelyezheti a merőleges tengelyt a diagram másik oldalára is. A [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) szabályozza, hogy a másik tengely hol metszze a konfigurált tengelyt. A 2. dián a `aspose.slides.CrossesType.Maximum` értékkel való hívás a megfordított kategóriatengelyen a vízszintes értéktengelyt alul tartja. Egy konkrét metszéspont meghatározásához használja a [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) metódust. Ellenőrizze a metszési beállításokat az irány módosításakor, különösen ha a diagram már rendelkezik egy egyéni metszésponttal. A `setPlotOrderReversed` metódus `false` értékkel való hívása visszaállítja a normál ábrázolási irányt; a metszési beállítások különállóak.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Vízszintes oszlopdiagram normál kategória- és értéktengely sorrenddel](axis-order-normal.png) | ![Vízszintes oszlopdiagram, ahol a kategóriák felülről lefelé jelennek meg](axis-order-categories-reversed.png) | ![Vízszintes oszlopdiagram megfordított értéktengellyel és a nulla a jobb oldalon](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé futnak; az értékek balról jobbra növekednek. | A Tervezés, Fejlesztés és Tesztelés felülről lefelé halad. Az értékek és a munkafüzet sor sorrendje változatlan. | A kategóriák megtartják a normál sorrendjüket; az értékek jobbról balra növekednek. A kategóriatengely a jobb oldali nullánál metszi. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja meg a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a függőleges tengelyen a rejtéséhez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a függőleges tengely elrejtésével.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A vízszintes tengely letiltása vonaldiagramoknál**

Hívja meg a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a vízszintes tengelyen a rejtéséhez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a vízszintes tengely elrejtésével.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diagramrácsvonalak megjelenítése vagy elrejtése**

Hívja meg a [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) és a [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) metódusokat, hogy ellenőrizze, mely rácsvonalakat jeleníti meg egy tengely. A kisebb rácsvonalak megjelenítéséhez használja a [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) metódust, és állítsa be a vonalfeltöltést egy szilárd, látható színre. Elrejtésükhöz állítsa a kitöltést a [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) értékre. A [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) metódust használja a fő rácsvonalak vonalfeltöltésének ugyanígy történő módosításához. A kitöltés módosítása megőrzi a tengely láthatóságát és a jelölőket.

Ennek a csoportosított oszlopdiagramnak a függőleges tengelye kezdetben csak a fő rácsvonalakat mutatja. A példa a kisebb rácsvonalakat sötét narancssárgában jeleníti meg, majd a mentés előtt újra elrejti őket. Minden lépésnél kiírja a rácsvonalak láthatóságát.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kisebb rácsvonalak engedélyezve | Kisebb rácsvonalak elrejtve |
| --- | --- |
| ![Narancssárga kisebb rácsvonalak a fő rácsvonalak között a függőleges tengelyen](minor-gridlines-enabled.png) | ![Ugyanaz a oszlopdiagram, csak a fő rácsvonalak láthatók](minor-gridlines-hidden.png) |

## **Kategóriatengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metódust dátum vagy szöveges kategóriatengely kiválasztásához. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelynek az első diáján az első alakzat egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) `false`, a [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) `TimeUnitType.Months` használatával a fő jelölőket egyhónapos intervallumra állítja.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **A kategóriatengely típusának meghatározása adat alapján**

Olvassa a [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) metódust a kategóriák feltöltése után, majd a [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) segítségével ellenőrizze a kiválasztást. Ez hasznos, ha ugyanaz a diagram szöveges címkéket vagy numerikus dátumértékeket kap. A metódus a meghíváskor határozza meg a típust; nem engedélyez állandó módot, amely később újraértékeli az adatváltozásokat. Hívja meg újra a kategóriák cseréje után.

Az alábbi példa egy szöveges kategóriákkal rendelkező diagramot hoz létre, és `true` értéket ír ki, ha a kiválasztott típus `CategoryAxisType.Text`. Ezután a kategória cellaértékeket dátumokká cseréli, és újból meghívja a metódust, `true`-t írva ki, ha a kiválasztott típus `CategoryAxisType.Date`. A dátumok numerikus OLE Automation értékekként vannak tárolva, ezeket a dátumokat a 1899. december 30. óta eltelt napok számaként számítják, nem dátum karakterláncként. A JavaScript számítás UTC időbélyegeket használ és az eltérést 86 400 000 milliszekundummal osztja per nap; a hónap indexek nullától indulnak. A `java.newDouble` segítségével minden dátumértéket double típusúként ad át a Java-nak. A [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) szabályozza, hogy ezek az értékek hogyan jelennek meg; nem alakítja át a szöveget numerikus dátummá. További információk a kategória cellákról a [Chart Workbook](/slides/hu/nodejs-java/chart-workbook/) oldalon.

Használja az automatikus meghatározást, ha a bemenet szöveges kategóriákat vagy numerikus dátumokat tartalmaz, mint ebben a példában. Általános numerikus címkék, vegyes kategóriák vagy üres adatok esetén hívja explicit módon a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metódust, hogy a kívánt jelentést tükrözze. Csak numerikus értékek önmagukban nem bizonyítják, hogy a kategóriák dátumot jelentenek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // igaz

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // igaz

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A kategóriatengely címkeintervallumok szabályozása**

A diagram sok kategóriával rendelkezik esetén csökkentse a látható tengelycímkék számát a kategóriák vagy adatpontok eltávolítása nélkül. Hívja a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) metódust `false` értékkel, majd adja meg a kívánt kategória intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) segítségével. Szöveges kategóriák esetén a normál sorrendben a számlálás az első kategóriától kezdődik:

| Intervallum | Példában megjelenített címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, két címkét rejtve hagyva a megjelenített címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőjeleknek külön vezérlése van. Hívja a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) metódust `false`-tal, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) metódust az intervallum beállításához. Például a `1` minden kategória intervallumban egy jelölőjelet tart, míg a címkék csak minden harmadik kategórián jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) metódust látható stílusra, hogy látható legyen az eredmény. Bármelyik automatikus beállítót `true`-ra állítva a diagram újra kiválasztja az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment `CategoryAxisIntervals.pptx` néven: automatikus távolság, manuális címkeintervallum független jelölőkkel, és visszaállított automatikus távolság. A két másolat az eredeti diagramadatokat tartja. Bemutató bemenet nem szükséges. A vízszintes címkeszöveg teszi könnyen láthatóvá a sűrűségkülönbséget.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Dia 2: mutassa minden harmadik címkét, de minden kategóriához tartson egy jelölőjelet.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: engedje a diagramnak, hogy újra kiválassza a két intervallumot.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategóriacímke látható és két sorra törik. Az automatikus eredmény változhat a diagram méretétől, betűtípusaitól és a renderertől.

![Automatikus kategória címke távolság, minden 24 oszlop látható](category-axis-automatic.png)

**Manuális távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, miközben a jelölőjelek minden kategória intervallumban maradnak. Az összes 24 oszlop, köztük a címke nélküli oszlopok is, láthatók ugyanazzal az értékkel. A 3. dia visszaállítja a fent bemutatott automatikus megjelenést.

![Manuális háromas kategória címke intervallum, minden 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória-számlálás intervallumot szöveges kategóriatengely esetén, például oszlop-, vonal-, terület- vagy oszlopdiagram kategóriatengelyénél. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes oszlopdiagram esetén a kategóriatengely függőleges, így ezeket a beállításokat alkalmazza a [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) által visszaadott tengelyre. A jelölőjelek távolsága sorozattengelyre is vonatkozik, ha a diagram rendelkezik ilyennel.

Ne használja a kategória címke távolságot az értéktengely numerikus skálájának beállítására. Értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) határozza meg az értékek közti különbséget: például egy `10` fő egység 0, 10, 20, … pontokat hoz létre, ha a tengely nullánál kezdődik. A `3` kategória címke intervallum a kategória pozíciókat számolja, függetlenül azok adatértékétől. Szórt- és buborékdiagramok értéktengelyeket használnak, nem szöveges kategóriatengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogy azt a [Change a Category Axis](#change-a-category-axis) szakaszban leírják.

## **Kategóriatengely értékek dátumformátumának beállítása**

A példa a alapértelmezett diagramadatokat négy éves értékkel helyettesíti. A dátumok az első munkalapon (index `0`) OLE Automation sorozatszámként vannak tárolva, ami a 1899. december 30. óta eltelt napok számát jelenti. A JavaScript számítás UTC időbélyeget használ, és a különbséget 86 400 000 milliszekundummal osztja napra. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metódust `CategoryAxisType.Date` értékkel, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false`-tal, és adja meg a `yyyy` értéket a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) metódusnak, hogy a kategória címkék négyjegyű évet jelenítsenek meg a cellaformázástól függetlenül.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diagramtengely címének forgatási szögének beállítása**

Hívja meg a [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) metódust `true` értékkel a függőleges tengelyen, adja meg a cím szövegét, és használja a [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) metódust a cím forgatásához. A szög fokban van mérve; ez a példa egy oszlopdiagramot ment, amelynek az értéktengely címe 90 fokra van elfordítva.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A tengely pozíciójának beállítása kategória vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) metódust annak szabályozására, hogy az értéktengely a kategóriák között vagy a kategória jelölőpontoknál metszze a kategóriatengelyt. Ez a beállítás a kategóriatengelyekre vonatkozik. A példa a `true` értéket állítja be a oszlopdiagram vízszintes kategóriatengelyén, és elmenti az eredményt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Megjelenítési egység beállítása diagram értéktengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) metódust az értéktengely címkéinek skálázásához az alapadatok módosítása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` értékre állításakor a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen alkalmazza a milliók megjelenítési egységét.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Logaritmikus értéktengely konfigurálása**

Egy logaritmikus értéktengely akkor hasznos, ha a pozitív értékek több nagyságrendi rendet fednek le. Például egy szolgáltatás öt időszakban 10, 100, 1 000, 10 000 és 100 000 kérést kap. Lineáris skálán a kisebb értékek közel egymáshoz jelennek meg a nullához közel. A logaritmikus skála könnyebbé teszi a relatív növekedés összehasonlítását: az egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Hívja a [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) metódust `true` értékkel az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) metódust az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy illesztett kapcsolatot képvisel az adatokban, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Egy vonal- vagy oszlopdiagram esetén az értéktengely a [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) metódus által visszaadott. Vízszintes oszlopdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) metódus adja vissza. Szórt- és buborékdiagramok két értéktengellyel rendelkeznek, így az X értékekhez a vízszintes tengelyt, az Y értékekhez a függőleges tengelyt vagy mindkettőt válassza. Ne alkalmazzon logaritmikus skálázást kategóriatengelyen.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramoknál válasszon `2` és `1000` közötti (beszámítva) alapot; a törtalapú értékek, például `2.5` is támogatottak. A `10` alappal a sorozatos hatványok, mint 10, 100, 1 000 és 10 000 egyenlő távolságra vannak.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az öt kérés számával az első dián, majd lemásolja azt a slide-ot, és a másodikon 10-es alapú logaritmikus értéktengelyt engedélyez. Mindkét dia ugyanazt az adatot tartja.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Az első diát lineárisnak hagyja, és csak a másolat értéktengelyének skáláját módosítsa.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lineáris skála (1. dia):** Azonos függőleges távolságok azonos kérés számú különbséget jelentik. A legnagyobb érték uralja a diagramot, a kisebb értékeket nehéz megkülönböztetni.

![Vonaldiagram PowerPointban, amely öt kérés számát mutatja lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Azonos függőleges távolságok azonos arányt jelentenek. Minden periódus tízszer több kérést tartalmaz, mint az előző, ezért a pontok egy egyenes emelkedő vonalat alkotnak a 10-es alapú skálán. A tengelycímkék továbbra is az eredeti kérés számot mutatják.

![Ugyanaz az öt kérés száma PowerPointban, 10-es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

Egy logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat a bekapcsolás előtt. Ha a nulla vagy negatív értékek jelentősek, tartsa meg a lineáris skálát vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő az elemzéshez, magyarázza el a kihagyást. Ne cserélje őket hallgatólagosan kis pozitív számokra, mivel ez megváltoztatja az adatok jelentését. Bármely manuálisan beállított minimum vagy maximum egy logaritmikus tengelyen szintén pozitívnak kell legyen.

## **GYIK**

**Hogyan állítható be az a érték, ahol az egyik tengely a másikra metszi (tengelykereszteződés)?**

Használja a [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) metódust a metszési viselkedés kiválasztásához. Numerikus metszési érték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) metódust. Ezek a beállítások lehetővé teszik a tengelykereszteződés elhelyezését egy megfelelő alapvonalra.

**Hogyan helyezhetők el a jelölőcímkék a tengelyhez viszonylag?**

Hívja a [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) egyike: `Low`, `High`, `NextTo` vagy `None` használatával. A jelölőjelek saját beállításához használja a [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) vagy a [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) metódusokat; ezek különállóak a címkepozicionálástól.