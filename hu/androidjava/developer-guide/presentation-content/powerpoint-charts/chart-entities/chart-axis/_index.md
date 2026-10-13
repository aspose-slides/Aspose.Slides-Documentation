---
title: Diagramtengelyek testreszabása Android prezentációkban
linktitle: Diagramtengely
type: docs
url: /hu/androidjava/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan használható az Aspose.Slides for Android Java nyelven a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Android segítségével Java nyelven. Kiterjed a számított tengelyértékekre, a diagram sorainak és oszlopainak felcserélésére, a tengely láthatóságára, a kategória címke‑ és jelölő‑intervallumokra, a dátum kategóriákra és formázásra, a cím forgatására, a tengely pozicionálására, a megjelenítő egységekre és a logaritmikus méretezésre.

## **A legnagyobb értékek lekérése a függőleges tengelyen diagramokon**

Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) metódust a számított tengelyértékek beolvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) és a [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) értékeket a tengely határértékekhez, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) és a [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) értékeket a jelölő‑intervallumokhoz. A [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) időegység skálákat adnak, amelyek a dátumtengelyekhez relevánsak. A példa ezeket az értékeket helyi változókba menti, majd a diagramot elmenti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az adatok felcserélése a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez az adatcsoportosítást változtatja meg; a vízszintes és függőleges tengelyeket nem cseréli fel. A példa a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) metódussal köti az alapértelmezett adatokat a `Sheet1!A1:D5` tartományhoz, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt sorokat és oszlopokat cserélne. Így négy sorozattal és három kategóriával rendelkező diagramot hoz létre.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja meg a [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a függőleges tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a függőleges tengely rejtett állapotával.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A vízszintes tengely letiltása vonaldiagramoknál**

Hívja meg a [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a vízszintes tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a vízszintes tengely rejtett állapotával.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategóriatengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust egy dátum vagy szöveges kategóriatengely kiválasztásához. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelyben a diagram az első dia első formájában van, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) `false`, a [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) `TimeUnitType.Months` hívások egy hónapos főjelölőket helyeznek el.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A kategóriatengely címkeintervallumok vezérlése**

Ha egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát a kategóriák vagy adatpontok eltávolítása nélkül. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) metódust `false` értékkel, majd adja át a kívánt kategóriaintervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metódusnak. Szöveges kategóriák esetén a számozás az első kategóriától kezdődik:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a megjelenő címkék között két címke rejtve marad. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság az elérhető hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölő‑pontok külön vezérelhetők. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) metódust `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) metódust az intervallum beállításához. Például az `1` minden kategóriaintervallumban elhelyez egy jelölő‑pontot, miközben a címkék csak minden harmadik kategórián jelennek meg. A [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) `visible` stílusa láthatóvá teszi ezeket. Bármelyik automatikus távolság beállítót újra `true`‑ra állítva a diagram újra automatikusan választja az intervallumot.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment `CategoryAxisIntervals.pptx` néven: automatikus távolság, kézi címke‑távolság független jelölő‑pontokkal, és a visszaállított automatikus távolság. A két másolat az eredeti diagramadatokat megtartja. Bemutató prezentációra nincs szükség. A vízszintes címke‑szöveg könnyen láthatóvá teszi a sűrűségkülönbséget.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // 2. dia: minden harmadik címkét jelenítsen meg, de minden kategóriához tartson egy jelölőpontot.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 3. dia: engedje, hogy a diagram újból kiválassza mindkét intervallumot.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus elrendezés (1. dia):** Ebben a megjelenítésben minden második kategóriacímke látható, és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusától és a renderelőtől függően változhat.

![Automatikus kategóriacímke‑távolság az összes 24 oszlop láthatóvá tételekor](category-axis-automatic.png)

**Kézi elrendezés (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg a jelölő‑pontok minden kategóriaintervallumban maradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazzal a értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Kézi kategóriacímke‑intervallum háromra az összes 24 oszlop láthatóvá tételekor](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Ezt a kategória‑számláló intervallumot szöveges kategóriatengelyben használja, például oszlop-, vonal-, terület‑ vagy sávdiagramok kategóriatengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategóriatengely függőleges, ezért ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott tengelyre alkalmazza. Jelölő‑pont távolság vonatkozik egy sorozattengelyre is azon diagramokban, amelyek ilyen tengelyt tartalmaznak.

Ne használjon kategóriacímke‑intervallumot az értéktengely numerikus skálájának beállítására. Egy értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) az értékek közötti különbséget határozza meg: például a `10` főegység 0, 10, 20 stb. jelölőket hoz létre, ha a tengely nulláról indul. A `3` kategóriacímke‑intervallum csak a kategóriahelyeket számlálja, függetlenül azok adatértékétől. Szórt és buborék diagramok értéktengellyel dolgoznak, nem szöveges kategóriatengellyel. Dátumtengely esetén használjon időalapú főegységeket és skálákat a [Kategóriatengely módosítása](#change-a-category-axis) részben leírtak szerint.

## **A kategóriatengely értékek dátumformátumának beállítása**

A példa a alapértelmezett diagramadatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként. Mindkét naptár UTC‑t használ, és a dátumok beállítása előtt törlésre kerülnek, hogy a nyári időszámítás vagy a napszak ne befolyásolja a számítást. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust `CategoryAxisType.Date` értékkel, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metódust `false`‑ra, és adja meg a `yyyy` értéket a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metódusnak, hogy a kategóriacímkék a cellaformázástól függetlenül négyszámjegyű évet jelenítsenek meg.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Forgatási szög beállítása a diagramtengely címéhez**

Hívja meg a [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) metódust `true` értékkel a függőleges tengelyen, adja meg a cím szövegét, és használja a [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metódust a cím forgatásához. A szög fokokban mérhető; ez a példa egy oszlopdiagramot ment el, amelynek az értéktengely címét 90 fokkal elforgatta.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A tengely pozíciójának beállítása kategória‑ vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metódust annak szabályozására, hogy az értéktengely a kategóriatengelyen a kategóriák között vagy a kategória‑jelölőpontokon keresztül keresse a keresztezést. Ez a beállítás csak kategóriatengelyekre vonatkozik. A példa az oszlopdiagram vízszintes kategóriatengelyén `true`‑ra állítja, majd elmenti az eredményt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Megjelenítő egység beállítása diagram értéktengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) metódust a értéktengely feliratainak skálázásához az adatok tényleges módosítása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) `Millions` értékre állítása esetén a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen milliók egységét alkalmazza.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Logaritmikus értéktengely konfigurálása**

A logaritmikus értéktengely hasznos, ha a pozitív értékek több nagyságrendben is eltérnek. Például egy szolgáltatás öt periódus alatt 10, 100, 1 000, 10 000 és 100 000 kérést kap. Lineáris skálán a kisebb értékek közel nulla csoportba zsúfolódnak. A logaritmikus skála a relatív növekedést könnyebben összehasonlíthatóvá teszi: az egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Hívja meg a [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) metódust `true` értékkel az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) metódust az alap megadásához. Ez módosítja a meglévő értékek megjelenítését; nem változtatja meg az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal a megfelelően illesztett adatkapcsolatot jelenti, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az értéktengely a [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott tengely. Vízszintes sávdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) adja vissza. Szórt és buborék diagramok két értéktengellyel rendelkeznek, így az X‑értékekhez a vízszintes tengelyt, az Y‑értékekhez a függőleges tengelyt vagy mindkettőt választhatja. Logaritmikus skálázást ne alkalmazzon kategóriatengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramoknál a `2`‑tól `1000`‑ig terjedő (beleértve) bázist használhat, törtalapú értékek, például `2.5` is támogatottak. A `10` alap esetén a sorozatos hatványok – 10, 100, 1 000, 10 000 – egyenlő távolságra kerülnek.

### **Lineáris és logaritmikus skálák összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre az első dián az öt kérésszámmal, majd a diát lemásolja, és a második dián a 10‑es alapú logaritmikus értéktengelyt aktiválja. Mindkét dia ugyanazokat az adatokat tartja meg.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Tartsa az első diát lineárisnak, és csak a másolat értéktengely skáláját változtassa meg.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő kérésszám‑különbségeket jelentenek. A legnagyobb érték uralja a diagramot, a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPoint‑ban, amely öt kérésszámot mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden periódus tízszer annyi kérést tartalmaz, mint az előző, így a pontok egy egyenesen emelkedő vonalat alkotnak a 10‑es alapú skálán. A tengelyfeliratok továbbra is az eredeti kérésszámokat mutatják.

![Ugyanaz az öt kérésszám PowerPoint‑ban 10‑es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy negatív értékek értelmesek, tartsa meg a lineáris skálát, vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő az elemzéshez, magyarázza meg az elhagyást. Ne helyettesítse őket csendben kis pozitív számokkal, mert ez megváltoztatja az adatok jelentését. Bármely, kézzel konfigurált minimum vagy maximum a logaritmikus tengelyen szintén pozitív kell legyen.

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely keresztezi a másikat (tengelykeresztezés)?**

Használja a [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) metódust a keresztezési viselkedés kiválasztásához. Numerikus keresztezési érték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) metódust. Ezek a beállítások lehetővé teszik, hogy a tengelykeresztezést egy megfelelő alapvonalra mozgassa.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva?**

Hívja meg a [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) `Low`, `High`, `NextTo` vagy `None` értékekkel. A jelölőpontok vezérléséhez használja a [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) vagy a [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) metódusokat; ezek különállóak a címke‑pozicionálástól.