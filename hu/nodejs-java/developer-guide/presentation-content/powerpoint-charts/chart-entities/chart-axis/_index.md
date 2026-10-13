---
title: Diagram tengelyek testreszabása prezentációkban JavaScript használatával
linktitle: Diagram tengely
type: docs
url: /hu/nodejs-java/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengely vonal
- dátum formátum
- tengely cím
- tengely pozíció
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja a JavaScriptet az Aspose.Slides for Node.js Java interfészén keresztül a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Node.js Java használatával. Tartalmazza a kiszámított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címkék és osztásjel intervallumait, a dátum kategóriákat és formázást, a cím forgatását, a tengely elhelyezését, a megjelenítési egységeket és a logaritmikus méretezést.

## **Maximális értékek lekérése a függőleges tengelyen a diagramokon**

Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) metódust a kiszámított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa ki a [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) és a [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) metódusokkal a tengelyhatárokat, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) és a [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) metódusokkal az osztásjegy intervallumokat. A [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) időegység skálákat biztosítanak, amelyek a dátumtengelyekhez relevánsak. A példa ezeknek az értékeknek a tárolását helyi változókban végzi, és elmenti a diagramot.

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

Használja a [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) metódust a diagram adatok sorozat- és kategória szerepeinek felcseréléséhez. Minden korábbi kategória sorozattá válik, és minden korábbi sorozat kategóriává. Ez megváltoztatja az adatok csoportosítását; nem cseréli ki a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) metódust használja az alapértelmezett adatok `Sheet1!A1:D5` tartományhoz kötéséhez, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt sorokat és oszlopokat cserélne. Egy négy sorozatot és három kategóriát tartalmazó diagramot ment.

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

## **A függőleges tengely letiltása vonaldiagramokhoz**

Hívja meg a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a függőleges tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a függőleges tengely rejtve.

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

## **A vízszintes tengely letiltása vonaldiagramokhoz**

Hívja meg a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a vízszintes tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a vízszintes tengely rejtve.

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

## **Kategória tengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metódust a dátum vagy szöveg kategória tengely kiválasztásához. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelyen az első dián az első alakzat egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé alakítja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) `false`, a [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) `TimeUnitType.Months` hívása egyhónapos intervallumokban helyezi el a fő osztásjeleket.

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

## **Kategória tengely címke intervallumok szabályozása**

Ha egy diagram sok kategóriát tartalmaz, csökkentse a látható tengelycímkék számát a kategóriák vagy adatpontok eltávolítása nélkül. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) metódust `false` értékkel, majd adja meg a kívánt kategória intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) metódusnak. Szöveges kategóriák normál sorrendjében a számlálás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, két címkét rejtve hagyva a megjelenítettek között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság az elérhető hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

Az osztásjeleknek külön vezérlői vannak. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) metódust az intervallum beállításához. Például a `1` minden kategória intervallumban megtart egy osztásjelet, míg a címkék csak minden harmadik kategóriában jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) metódust látható stílussal, hogy lássa az eredményt. Bármely automatikus-távolság beállító `true`-ra állítása ismét lehetővé teszi, hogy a diagram újra kiválassza azt az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke távolság független osztásjelekkel, és az automatikus távolság visszaállítása. A két másolat megőrzi az eredeti diagram adatokat. Bemeneti prezentáció nem szükséges. A vízszintes címkeszöveg megkönnyíti a sűrűség különbségének láthatóvá tételét.

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

    // Dia 2: mutassa minden harmadik címkét, de tartson meg egy osztásjelet minden kategória számára.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: engedje a diagramnak, hogy újra kiválassza mindkét intervallumot.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke jelenik meg, és két sorba törik. Az automatikus eredmény a diagram méretétől, a betűtípusoktól és a renderertől függően változhat.

![Automatikus kategória címke távolság az összes 24 látható oszloppal](category-axis-automatic.png)

**Kézi távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg az osztásjelek minden kategória intervallumban megmaradnak. Az összes 24 oszlop, beleértve a címkek nélküli oszlopokat is, látható marad ugyanazzal az értékkel. A 3. dia visszaállítja a fent bemutatott automatikus megjelenést.

![Kézi kategória címke intervallum hárommal, az összes 24 látható oszloppal](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória-számláló intervallumot szöveges kategória tengely esetén, például oszlop-, vonal-, terület- vagy sávdiagram kategória tengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategória tengely függőleges, ezért ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) által visszaadott tengelyre alkalmazza. Az osztásjel távolság a sorozat tengelyre is érvényes, ha a diagramnak van ilyen.

Ne használja a kategória címke távolságot az értéktengely numerikus skálájának beállításához. Az értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) meghatároz egy értékbeli különbséget: például a `10` fő egység 0, 10, 20 stb. jelöléseket eredményez, ha a tengely nulláról indul. A `3` kategória címke intervallum a kategória pozíciókat számolja, függetlenül az adatértékektől. Szórt és buborék diagramok értéktengelyeket használnak szöveges kategória tengely helyett. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogy a [Change a Category Axis](#change-a-category-axis) szakaszban le van írva.

## **A kategória tengely értékek dátumformátumának beállítása**

A példa a alapértelmezett diagram adatokat négy éves értékre cseréli. A dátumok OLE Automation sorozatszámokként tárolódnak az első munkalapon (index `0`), számítva a napok számát 1899. december 30. óta. A JavaScript számítás UTC időbélyegeket használ, és a különbséget 86 400 000 milliszekundummal osztja napra. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) `CategoryAxisType.Date` értékkel, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` értékkel, és adja át a `yyyy` értéket a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) metódusnak, hogy a kategória címkék a cella formázástól függetlenül négyjegyű éveket jelenítsenek meg.

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

## **Forgatás szög beállítása a diagram tengely címéhez**

Hívja meg a [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) metódust `true` értékkel a függőleges tengelyen, adja meg a cím szövegét, és használja a [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) metódust a cím forgatásához. A szög fokban van mérve; ez a példa egy oszlopdiagramot ment, amelynek értéktengely címe 90 fokkal van elforgatva.

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

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) metódust annak szabályozására, hogy az értéktengely a kategória tengelyt kategóriák között vagy a kategória osztásjeleken keresse át. Ez a beállítás a kategória tengelyekre vonatkozik. A példa `true` értékkel állítja be a vízszintes kategória tengelyt egy oszlopdiagramon, és elmenti az eredményt.

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

Használja a [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) metódust az értéktengely címkéinek méretezésére az alapadatok módosítása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` beállításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a milliós megjelenítési egységet alkalmazza a függőleges tengelyre.

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

## **Logaritmikus értéktengely beállítása**

A logaritmikus értéktengely akkor hasznos, ha a pozitív értékek több nagyságrendi szintet fednek le. Például egy szolgáltatás öt időszak alatt 10, 100, 1 000, 10 000 és 100 000 kérést kaphat. Lineáris skálán a kisebb értékek közel egymáshoz helyezkednek a nullához. A logaritmikus skála megkönnyíti a relatív növekedés összehasonlítását: az egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Hívja meg a [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) metódust `true` értékkel az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) metódust az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal a adatokban illesztett kapcsolatot reprezenti és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal vagy oszlop diagram esetén az értéktengely a [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) által visszaadott. Vízszintes sávdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) által. Szórt és buborék diagramok két értéktengellyel rendelkeznek, ezért válassza a vízszintes tengelyt az X értékekhez, a függőleges tengelyt a Y értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategória tengelyre.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén használjon `2`‑től `1000`‑ig terjedő alapot, a törtalapok, például `2.5` is támogatottak. `10` alap esetén a sorozatos hatványok, mint 10, 100, 1 000 és 10 000 egyenlő távolságra vannak.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az öt kérés számmal az első dián, majd lemásolja azt a diát, és a másodikon engedélyezi a 10‑es alapú logaritmikus értéktengelyt. Mindkét dia ugyanazt az adatot tartja.

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

    // Tartsa az első diát lineárisnak, és csak a másolat értéktengely skáláját változtassa meg.
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

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentnek a kérés számlában. A legnagyobb érték uralja a diagramot, megnehezítve a kisebb értékek megkülönböztetését.

![Vonaldiagram PowerPointban, amely öt kérés számlát mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak tízszer annyi kérést tartalmaz, mint az előző, ezért a pontok egy egyenes felfelé ívelő vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérés számokat mutatják.

![Ugyanaz az öt kérés száma PowerPointban, 10‑es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy a negatív értékek jelentősek, tartsa meg a lineáris skálát vagy jelenítse meg őket külön. Ha a kizárásuk megfelel az elemzésnek, magyarázza meg a kihagyást. Ne cserélje el hallgatólagosan őket kis pozitív számokra, mivel ez megváltoztatja az adatok jelentését. Bármely kézzel konfigurált minimum vagy maximum logaritmikus tengelyen is pozitívnak kell lennie.

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely áthalad a másikon (tengelymetszet)?**  
Használja a [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) metódust a metszet viselkedésének kiválasztásához. Numerikus metszetérték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) metódust. Ezek a beállítások lehetővé teszik a tengelymetszet áthelyezését egy megfelelő kiindulópontra.

**Hogyan helyezhetem el a jelcímkéket a tengelyhez viszonyítva?**  
Hívja meg a [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) használatával: `Low`, `High`, `NextTo` vagy `None`. Az osztásjelek önmaguk vezérléséhez használja a [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) vagy a [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) metódust; ezek különállóak a címke elhelyezéstől.