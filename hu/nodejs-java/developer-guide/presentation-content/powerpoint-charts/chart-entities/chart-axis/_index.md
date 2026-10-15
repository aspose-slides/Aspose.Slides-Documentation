---
title: "Diagram tengelyek testreszabása prezentációkban JavaScript használatával"
linktitle: "Diagram tengely"
type: docs
url: /hu/nodejs-java/chart-axis/
keywords:
- "diagram tengely"
- "függőleges tengely"
- "vízszintes tengely"
- "tengely testreszabása"
- "tengely manipulálása"
- "tengely kezelése"
- "tengely tulajdonságok"
- "maximális érték"
- "minimális érték"
- "tengelyvonal"
- "dátumformátum"
- "tengelycím"
- "tengelypozíció"
- "PowerPoint"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Fedezze fel, hogyan használhatja a JavaScriptet az Aspose.Slides for Node.js Java-on keresztül a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentésekhez és vizualizációkhoz."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet testreszabni a diagramtengelyeket az Aspose.Slides for Node.js Java segítségével. Tárgyalja a számított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címke- és jelölőintervallumokat, a dátumkategóriákat és formázást, a cím forgatását, a tengely elhelyezését, a megjelenítési egységeket és a logaritmikus skálázást.

## **A legnagyobb értékek lekérése a függőleges tengelyen a diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) függvényt a számított tengelyértékek kiolvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa a [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) és a [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) függvényeket a tengelyhatárokért, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) és a [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) függvényeket a jelölőintervallumokért. A [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) időegység-skálákat biztosítanak, amelyek a dátumtengelyekhez relevánsak. A példában ezek az értékek helyi változókba kerülnek, és a diagram mentésre kerül.

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
## **Adatok felcserélése a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) függvényt a diagramadatokban a sorozatok és kategóriák szerepének cseréjére. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává alakul. Ez megváltoztatja az adatok csoportosítását, de nem cseréli fel a vízszintes és függőleges tengelyeket. A példában a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) függvényt használják az alapértelmezett adatok `Sheet1!A1:D5` tartományhoz kötésére, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt felcserélnék a sorokat és oszlopokat. Egy olyan diagramot ment, amely négy sorozatot és három kategóriát tartalmaz.

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
## **Tengely ábrázolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) függvényt egy kategória- vagy értéktengely megfordításához. Például egy vízszintes oszlopdiagram ugyanabban a sorrendben mutathatja a projekt szakaszait felülről lefelé, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. A tengely megfordítása megváltoztatja az ábrázolás irányát; nem rendezi vagy átrendezi a munkafüzet adatokat. Összehasonlítva, a [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) cseréli a sorozatok és kategóriák szerepét.

Az alábbi példa egy három szakaszból és egy sorozatból álló vízszintes oszlopdiagramot hoz létre. Egy prezentációt ment három diával: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

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

    // 2. dia: az első kategória megjelenítése felül.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Tartsa a vízszintes értéktengelyt alul.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // 3. dia: csak a vízszintes numerikus skálát fordítsa meg.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
Az tengely megfordítása a merőleges tengelyt a diagram ellenkező oldalára is mozgathatja. A [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) szabályozza, hogy a másik tengely hol metszi a beállított tengelyt. A 2. dián a `aspose.slides.CrossesType.Maximum` értékkel a megfordított kategóriatengelyen hívva a vízszintes értéktengely alul marad. Egy konkrét keresztezési ponthoz használja a [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Ellenőrizze a keresztezési beállításokat irányváltáskor, különösen ha a diagram már rendelkezik egyedi keresztezési ponttal. Hívja a `setPlotOrderReversed`-t `false`-val a normál ábrázolási irány visszaállításához; a keresztezési beállítások különállóak.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé vannak; az értékek balról jobbra nőnek. | Tervezés, Fejlesztés és Tesztelés felülről lefelé vannak. Az értékek és a munkafüzet sor sorrendje változatlan. | A kategóriák megtartják a normál sorrendjüket; az értékek jobbról balra nőnek. A kategóriatengely a jobb oldalon, nullánál metsződik. |

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
## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) függvényt `false` értékkel a függőleges tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a függőleges tengely rejtve menti.

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
## **A vízszintes tengely letiltása vonaldiagramoknál**

Hívja a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) függvényt `false` értékkel a vízszintes tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a vízszintes tengely rejtve menti.

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
## **Kategóriatengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) függvényt, hogy dátum vagy szöveg kategóriatengelyt válasszon. Ez a példa a `ExistingChart.pptx` fájlt igényli, ahol az első dián az első alakzat egy diagram, és a kategóriacellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengelyre változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) `false`, a [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) `TimeUnitType.Months` beállításával a fő jelölők egyhónapos intervallumokban jelennek meg.

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
## **Kategóriatengely címkeintervallumok vezérlése**

Ha egy diagramnak sok kategóriája van, csökkentse a látható tengelycímkék számát a kategóriák vagy adatpontok eltávolítása nélkül. Hívja a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) `false` értékkel, majd adja meg a kívánt kategóriaintervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Szöveges kategóriák esetén a normál sorrendben a számozás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

Egy `3` intervallum minden harmadik címkét jelenít meg, két címkét hagyva rejtve a megjelenített címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

Az jelölőcsíkoknak külön vezérlése van. Hívja a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/)‑t az intervallum beállításához. Például a `1` minden kategóriaintervallumra egy jelölőcsíkot tart, míg a címkék csak minden harmadik kategórián jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) látható stílussal a végeredmény megtekintéséhez. Bármelyik automatikus beállítás `true`-ra történő visszaállítása újból engedi, hogy a diagram kiválassza az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, manuális címke‑távolság független jelölőcsíkokkal, és visszaállított automatikus távolság. A két másolat az eredeti diagramadatokat tartja meg. Bemutató bemenet nem szükséges. A vízszintes címke szöveg teszi a sűrűséget könnyen észrevehetővé.

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

    // 2. dia: minden harmadik címkét jelenítse meg, de tartsa a jelölőcsíkot minden kategóriához.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 3. dia: engedje, hogy a diagram újra kiválassza mindkét intervallumot.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategóriacímke látható, és két sorra törik. Az automatikus eredmény a diagram méretétől, betűtípusoktól és a renderertől függően változhat.

![Automatikus kategória címke távolság minden 24 oszlop láthatóval](category-axis-automatic.png)

**Manuális távolság (2. dia):** Minden harmadik címke egy sorban jelenik meg, míg a jelölőcsíkok minden kategóriaintervallumnál maradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható marad ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manuális három kategóriás címkeintervallum minden 24 oszloppal látható](category-axis-manual.png)

### **Válassza ki a megfelelő tengelyt és intervallumot**

Használja ezt a kategóriaszám‑intervallumot szöveges kategóriatengelyhez, például oszlop-, vonal-, terület- vagy sávdiagram kategóriatengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízeletsszintű sávdiagramnál a kategóriatengely függőleges, ezért alkalmazza ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) által visszaadott tengelyre. A jelölőcsík távolság az olyan diagramok sorozat tengelyén is alkalmazható, amelyek rendelkeznek ilyennel.

Ne használja a kategóriacímke‑távolságot értéktengely numerikus skálájának beállításához. Az értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) határozza meg az értékek közti különbséget: például egy `10` főegység 0, 10, 20, stb. értékeket ad, ha a tengely nulláról indul. A `3` kategóriacímke‑intervallum ezzel szemben a kategóriahelyek számát számolja, függetlenül az adatértékektől. Szórt és buborékképekkel értéktengelyek használatosak, nem szöveges kategóriatengely. Dátumtengely esetén használjon időalapú főegységeket és skálákat, ahogy a [Kategóriatengely módosítása](#kategóriatengely‑módosítása) részben leírt.

## **A kategóriatengely értékek dátumformátumának beállítása**

A példa négy éves értékkel cseréli le az alapértelmezett diagramadatokat. A dátumok OLE Automation sorozatszámokként vannak tárolva az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként. A JavaScript számítás UTC időbélyeget használ, és a különbséget 86 400 000 millisekundummal osztja napra. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) `CategoryAxisType.Date` értékkel, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false`‑val, és adja át a `yyyy` értéket a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/)‑nek, hogy a kategóriacímkék a négy számjegyű éveket mutassák a cellaformázástól függetlenül.

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
## **A diagramtengely címének forgatási szögének beállítása**

Hívja a [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) `true` értékkel a függőleges tengelyen, adja meg a címszöveget, és használja a [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) függvényt a cím forgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment, amelynek az értéktengely címe 90 fokkal van elforgatva.

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
## **A tengely pozíciójának beállítása kategória vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) függvényt annak szabályozására, hogy az értéktengely a kategóriatengelyt kategóriák között vagy a kategória jelölőpontokon keresztül metszze. Ez a beállítás a kategóriatengelyekre vonatkozik. A példa `true` értékkel állítja be a vízszintes kategóriatengelyen egy oszlopdiagram esetén, és elmenti az eredményt.

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
## **Megjelenítési egység beállítása diagram értéktengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) függvényt az értéktengely címkéinek skálázásához anélkül, hogy a mögöttes adatokat módosítaná. A [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` értékre állítva a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a milliók megjelenítési egységet alkalmazza a függőleges tengelyére.

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

    // Tartsd az első diát lineárisnak, és csak a másolat értéktengely skáláját változtasd meg.
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
## **Logaritmikus értéktengely konfigurálása**

Egy logaritmikus értéktengely akkor hasznos, ha a pozitív értékek több nagyságrendi egységet fednek le. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérést kaphat öt időszakban. Lineáris skálán a kisebb értékek közel a nullához csoportosulnak. A logaritmikus skála a relatív növekedést könnyebben összehasonlíthatóvá teszi: az egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Hívja a [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) `true` értékkel az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/)‑t az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal az adatokra illesztett kapcsolatot jelöli, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az értéktengely a [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) függvény által visszaadott. Vízeletsszintű sávdiagramnál a [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) adja vissza. Szórt és buborékképeknél két értéktengely van, így válassza a vízszintes tengelyt az X értékekhez, a függőleges tengelyt az Y értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategóriatengelyre.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramok esetén használjon `2` és `1000` közötti alapot, a határok beleértve; a törtközös alapok, például `2.5`, szintén támogatottak. `10` alap esetén a sorozatos hatványok, mint 10, 100, 1 000 és 10 000 egyenlő távolságra vannak.

### **Lineáris és logaritmikus skálázás összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre, amely az első dián az öt kérés számát tartalmazza, majd lemásolja azt a diát, és a második dián bekapcsol egy tízes alapú logaritmikus értéktengelyt. Mindkét dia ugyanazt az adatot tartja.

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentenek a kérés számában. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban, amely öt kérés számát mutatja lineáris értéktengellyel](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak a előzőhöz képest tízszer több kérést tartalmaz, így a pontok egy egyenes, emelkedő vonalat alkotnak a tízes alapú skálán. A tengelycímkék továbbra is az eredeti kérés számát mutatják.

![Ugyanaz az öt kérés szám PowerPointban tízes alapú logaritmikus értéktengellyel](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt bekapcsolná. Ha a nulla vagy negatív értékek jelentősek, tartsa a lineáris skálát vagy mutassa őket külön. Ha ezeknek az értékeknek a kizárása megfelelő a elemzéshez, magyarázza el a kihagyást. Ne cserélje ki őket hallgatólagosan kis pozitív számokra, mert ez megváltoztatja az adatok jelentését. Bármely manuálisan konfigurált minimum vagy maximum logaritmikus tengelyhez szintén pozitív kell legyen.

## **GYIK**

**Hogyan állíthatom be, hogy egy tengely hol metszze a másikat (tengelymetszés)?**  
Használja a [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) függvényt a metszési viselkedés kiválasztásához. Numerikus metszési érték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)‑t. Ezek a beállítások lehetővé teszik, hogy a tengelymetszést egy megfelelő alapvonalra helyezzék.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest?**  
Hívja a [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) függvényt a [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) értékével: `Low`, `High`, `NextTo` vagy `None`. A jelölőcsíkok magának a vezérléséhez használja a [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) vagy a [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) függvényt; ezek különállóak a címke pozícionálástól.