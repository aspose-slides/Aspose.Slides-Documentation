---
title: Diagramtengelyek testreszabása prezentációkban JavaScript segítségével
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
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja a JavaScriptet az Aspose.Slides for Node.js via Java segítségével a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentésekhez és vizualizációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testreszabhatók a diagram tengelyei az Aspose.Slides for Node.js via Java segítségével. Kitér a számított tengelyértékekre, a diagram sorok és oszlopok felcserélésére, a tengelyek láthatóságára, a kategória címke- és jelölő‑intervallumokra, a dátumkategóriákra és formázásukra, a cím forgatására, a tengely elhelyezésére és a megjelenítési egységekre.

## **A maximális értékek lekérése a függőleges tengelyen diagramoknál**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) objektumot, és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) metódust a számított tengelyértékek lekérése előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) és a [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) értékeket a tengelyhatárokhoz, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) és a [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) értékeket a jelölő‑intervallumokhoz. A [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) időegység‑skálákat ad vissza, amelyek a dátumtengelyek esetén relevánsak. A példa ezeket az értékeket helyi változókba menti, majd a diagramot elmenti.

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

## **Adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez az adatcsoportosítást módosítja; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) metódussal köti az alapértelmezett adatokat a `Sheet1!A1:D5` tartományra, beleértve a fejlécsort és a kategóriakolumnát, a sorok és oszlopok felcserélése előtt. Egy négy sorozatú és három kategóriás diagramot ment el.

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

## **Függőleges tengely letiltása vonaldiagramok esetén**

Hívja meg a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a függőleges tengelyen, hogy elrejtse azt. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a függőleges tengely letiltásával menti el.

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

## **Vízszintes tengely letiltása vonaldiagramok esetén**

Hívja meg a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a vízszintes tengelyen, hogy elrejtse azt. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a vízszintes tengely letiltásával menti el.

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

## **Kategóriatengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metódust, hogy dátum- vagy szöveges kategóriatengelyt válasszon. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelyben a diagram az első dia első alakja, a kategóriacellák pedig numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengelyre változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) `false`, a [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) `1`, valamint a [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) `TimeUnitType.Months` beállításával a fő jelölők egyhónapos intervallumokra kerülnek.

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

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) metódust `false` értékkel, majd adja meg a kívánt kategória‑intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) metódussal. Szöveges kategóriák esetén a normál sorrendben a számlálás az első kategóriától kezdődik:

| Intervallum | Példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

A `3`‑as intervallum minden harmadik címkét jeleníti meg, a megjelenő címkék között két címke rejtve marad. Ez nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jelenik meg minden címke.

A jelölő‑vonalaknak külön vezérlése van. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) metódust az intervallum beállításához. Például a `1` minden kategória‑intervallumnál megtart egy jelölő‑vonalat, míg a címkék csak minden harmadik kategóriánál jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) metódust látható stílusú jelölővel, hogy lássa az eredményt. Bármelyik automatikus beállítót `true`‑ra állítva a diagram újra kiválasztja azt az intervallumot.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment el a `CategoryAxisIntervals.pptx` fájlban: automatikus távolság, kézi címke‑távolság független jelölőkkel, és visszaállított automatikus távolság. A két másolat az eredeti diagramadatokat tartalmazza. Bemutató prezentáció nem szükséges. A vízszintes címkeszöveg könnyen láthatóvá teszi a sűrültségkülönbséget.

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

    // Dia 2: mutasson minden harmadik címkét, de minden kategóriához tartson egy jelölővonalat.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: hagyja, hogy a diagram újra kiválassza mindkét intervallumot.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategóriacímke látható, és két sorra törik. Az automatikus eredmény a diagram méretétől, betűtípusától és a renderertől függően változhat.

![Automatikus kategória címke távolság, az összes 24 oszlop látható](category-axis-automatic.png)

**Kézi távolság (2. dia):** Minden harmadik címke egy sorban jelenik meg, míg a jelölő‑vonalak minden kategória‑intervallumnál megmaradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Kézi kategória címke intervallum három, az összes 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória‑szám intervallumot szöveges kategóriatengely esetén, például egy oszlop-, vonal-, terület- vagy sávdiagram kategóriatengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategóriatengely függőleges, ezért ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) által visszaadott tengelyre alkalmazza. A jelölő‑távolság sorozattengelyre is vonatkozik azon diagramoknál, amelyek rendelkeznek ilyen tengellyel.

Ne használja a kategóriacímke‑távolságot a numerikus értéktengely skálájának beállításához. Egy értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) értéke a különbséget jelöli: például a `10` fő egység 0, 10, 20 stb. értékeknél jelölőket hoz létre, ha a tengely nullánál kezdődik. A `3`‑as kategória címke intervallum a kategória pozíciókat számolja, függetlenül a tényleges adatértékektől. Szórt‑ és buborékdiagramok értéktengelyeket használnak, nem szöveges kategóriatengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat a [Kategóriatengely módosítása](#kategóriatengely-módosítása) szakaszban leírtak szerint.

## **Dátumformátum beállítása a kategóriatengely értékeire**

A példa négy éves értékkel helyettesíti az alapértelmezett diagramadatokat. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`), ami 1899. december 30. óta eltelt napok számát jelenti. A JavaScript számítás UTC időbélyegeket használ, és a különbséget 86 400 000 miliszekundummal osztja el napra. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metódust `CategoryAxisType.Date` értékkel, hívja meg a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) metódust `false`‑val, és adja át a `yyyy`‑t a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) metódusnak, hogy a kategóriacímkék négy számjegyű évként jelenjenek meg a cellaformázástól függetlenül.

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

## **Forgásszög beállítása diagramtengely címéhez**

Hívja meg a [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) metódust `true` értékkel a függőleges tengelyen, adja meg a címszöveget, és használja a [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) metódust a cím forgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek az értéktengely címe 90 fokkal van elforgatva.

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

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) metódust annak meghatározására, hogy az értéktengely a kategóriatengely között vagy a kategória‑jelölőknél metszi-e. Ez a beállítás csak kategóriatengelyekre vonatkozik. A példa a `true` értéket állítja be a column diagram vízszintes kategóriatengelyén, és elmenti az eredményt.

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

Használja a [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) metódust a értéktengely felirataiban lévő skálázásra az adatok módosítása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` beállításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyre a milliók megjelenítési egységét alkalmazza.

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

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely kereszteződik a másikkal (tengelykereszt)?**

Használja a [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) metódust a keresztezési viselkedés kiválasztásához. Numerikus keresztérték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) metódust. Ezek a beállítások lehetővé teszik, hogy a tengelykeresztet egy megfelelő alapvonalra helyezze.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest?**

Hívja meg a [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) egyik értékével: `Low`, `High`, `NextTo` vagy `None`. A jelölővonalak vezérléséhez használja a [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) vagy a [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) metódusokat; ezek külön állnak a címkepozícionálástól.