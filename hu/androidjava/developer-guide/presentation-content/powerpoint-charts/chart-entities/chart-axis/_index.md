---
title: Diagram tengelyek testreszabása Android prezentációkban
linktitle: Diagram tengely
type: docs
url: /hu/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for Android Java segítségével a diagram tengelyek testreszabását PowerPoint prezentációkban jelentésekhez és vizualizációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testreszabható a diagram tengelye az Aspose.Slides for Android Java segítségével. Kitér a számított tengelyértékekre, a diagram sorok és oszlopok cseréjére, a tengely láthatóságára, a kategória címke- és jelölő-intervalumokra, a dátumkategóriákra és formázásra, a cím forgatására, a tengely helyzetére, a megjelenítési egységekre és a logaritmikus méretezésre.

## **A maximális értékek lekérése a függőleges tengelyen a diagramokon**

Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) a számított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) és a [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) a tengelykorlátokhoz, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) és a [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) a jelölő-intervallumokhoz. A [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) időegység-skálákat biztosítanak, amelyek a dátum tengelyekre vonatkoznak. A példa ezeket az értékeket helyi változókba menti, majd elmenti a diagramot.

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

## **Az adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) metódust a sorozatok és kategóriák szerepének cseréjéhez a diagram adataiban. Minden korábbi kategória sorozattá válik, és minden korábbi sorozat kategóriává. Ez a csoportosítás módját változtatja, nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-)‑t használja, hogy az alapértelmezett adatot a `Sheet1!A1:D5` tartományhoz kötse, beleértve a fejléc sort és a kategória oszlopot, mielőtt sorokat és oszlopokat cserélne. Egy négy sorozatos és három kategóriás diagramot ment.

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

## **A tengely ábrázolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) metódust egy kategória vagy értéktengely megfordításához. Például egy vízszintes sávdiagram a projekt szakaszait felülről lefelé jelenítheti meg ugyanabban a sorrendben, mint a munkalap: Tervezés, Fejlesztés, Tesztelés. Egy tengely megfordítása megváltoztatja a megjelenítési irányt; nem rendezi vagy módosítja a munkafüzet adatait. Összehasonlításként a [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) cseréli a sorozatok és kategóriák szerepét.

Az alább látható példa egy vízszintes sávdiagramot hoz létre három szakasz és egy sorozat felhasználásával. Három diát ment: normál sorrend, megfordított kategóriák, és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Dia 2: az első kategóriát a tetején jeleníti meg.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Tartsa a vízszintes értéktengelyt alul.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Dia 3: csak a vízszintes numerikus skálát fordítsa meg.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A tengely megfordítása a merőleges tengelyt is áthelyezheti a diagram ellenkező oldalára. A [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) szabályozza, hogy a másik tengely hol metszze a konfigurált tengelyt. A 2. diában a `CrossesType.Maximum` használata a megfordított kategória tengelyen a vízszintes értéktengelyt alul tartja. Egy konkrét metszéspont meghatározásához használja a [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Ellenőrizze a metszési beállításokat az irányváltáskor, különösen, ha a diagram már saját metszésponttal rendelkezik. Hívja a `setPlotOrderReversed`‑t `false`‑val a normál ábrázolási irány visszaállításához; a metszési beállítások különállóak.

| Normál sorrend (dia 1) | Megfordított kategóriák (dia 2) | Megfordított értékek (dia 3) |
| --- | --- | --- |
| ![Vízszintes sávdiagram normál kategória- és értéktengely sorrenddel](axis-order-normal.png) | ![Vízszintes sávdiagram a kategóriákkal felülről lefelé megjelenítve](axis-order-categories-reversed.png) | ![Vízszintes sávdiagram megfordított értéktengellyel, a nulla jobbra](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra növekednek. | A tervezés, fejlesztés és tesztelés felülről lefelé halad. Az értékek és a munkafüzet sorainak sorrendje változatlan. | A kategóriák megtartják normál sorrendjüket; az értékek jobbról balra növekednek. A kategóriatengely a jobb oldalon, a nullánál keresztezi. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja a [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-)‑t `false`‑val a függőleges tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a függőleges tengely elrejtett állapotban.

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

Hívja a [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-)‑t `false`‑val a vízszintes tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a vízszintes tengely elrejtett állapotban.

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

## **Kategória tengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-)‑t, hogy dátum vagy szöveges kategória tengelyt válasszon. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelynek első diájának első alakja egy diagram, a kategória cellák pedig numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátum tengelyre változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) `false`‑ra, a [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) `1`‑re és a [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) `TimeUnitType.Months`‑ra állítva a fő jelölőket egyhónapos intervallumokra helyezi.

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

## **Kategória tengely címke intervallumok szabályozása**

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Hívja a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)‑t `false`‑ra, majd adja meg a kívánt kategória intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)-nek. Szöveges kategóriák esetén a normál sorrendben a számlálás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

A `3` intervallum minden harmadik címkét jeleníti meg, a megjelenített címkék között két rejtett címke marad. Ez nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőjelek külön vezérelhetők. Hívja a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)‑t `false`‑ra, majd a [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)‑vel állítsa be az intervallumukat. Például a `1` minden kategória intervallumban egy jelölőjelet hagy, míg a címkék csak minden harmadik kategóriánál jelennek meg. A [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-)‑t látható stílussal használja, hogy lássa az eredményt. Az automatikus beállítások `true`‑ra visszakapcsolása ismét lehetővé teszi a diagram számára, hogy saját magától válassza ki az intervallumot.

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

    // Dia 2: minden harmadik címkét jelenítse meg, de minden kategóriához tartson egy jelölőjelet.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: engedje, hogy a diagram újból kiválassza mindkét intervallumot.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus távolság (dia 1):** Ebben a megjelenítésben minden második kategória címke jelenik meg, és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusaitól és a renderertől függően változhat.

![Automatikus kategória címke távolság 24 látható oszloppal](category-axis-automatic.png)

**Manuális távolság (dia 2):** Minden harmadik címke jelenik meg egy sorban, míg a jelölőjelek minden kategória intervallumban maradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható marad ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manuális háromas kategória címke intervallum 24 látható oszloppal](category-axis-manual.png)

### **Válassza ki a megfelelő tengelyt és intervallumot**

Használja ezt a kategória számláló intervallumot szöveges kategória tengelyhez, például egy oszlop, vonal, terület vagy sáv diagram kategória tengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízes sávdiagram esetén a kategória tengely függőleges, így ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott tengelyre alkalmazza. A jelölő jel távolsága egy sorozat tengelyre is vonatkozhat azokban a diagramokban, amelyek ilyenek.

Ne használja a kategória címke távolságát a számérték skála beállítására egy értéktengelyen. Egy értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) az értékek közti különbséget adja meg: például a `10` fő egység 0, 10, 20 stb. jelölőket hoz létre, ha a tengely nulláról indul. A `3` kategória címke intervallum ehelyett a kategóriahelyeket számolja, függetlenül azok adatértékeitől. Pont és buborékkördiagramok értéktengelyeket használnak, nem szöveges kategória tengelyt. Dátum tengely esetén használjon időalapú fő egységeket és skálákat, ahogyan a [Kategória tengely módosítása](#change-a-category-axis) szakaszban le van írva.

## **A kategória tengely értékek dátumformátumának beállítása**

A példa az alapértelmezett diagram adatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként. Mindkét naptár UTC időzónát használ, és a dátumok beállítása előtt törlésre kerülnek, hogy a nyári időszámítás vagy a nap aktuális időpontja ne befolyásolja a számítást. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-)‑t `CategoryAxisType.Date`‑el, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-)‑t `false`‑val, és adja meg a `yyyy`‑t a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)‑nek, hogy a kategória címkék a cella formázásától függetlenül négyjegyű évet mutassanak.

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

## **Forgatási szög beállítása a diagram tengely címéhez**

Hívja a [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-)‑t `true`‑val a függőleges tengelyen, adja meg a cím szövegét, majd a [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)‑val forgassa el a címet. A szög fokban van mérve; ez a példa egy oszlopdiagramot ment, amelynek értéktengely címke 90 fokban van elforgatva.

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

## **A tengely pozíciójának beállítása kategória vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-)‑t annak szabályozására, hogy az értéktengely a kategóriatengelyet a kategóriák között vagy a kategória jelölőpontokon keresztül keresse. Ez a beállítás a kategória tengelyekre vonatkozik. A példa a vízszintes kategória tengelyen egy oszlopdiagramnál `true`‑ra állítja, és elmenti az eredményt.

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

## **Megjelenítési egység beállítása diagram értéktengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-)‑t az értéktengely feliratainak méretezésére anélkül, hogy az alaptadatok változnának. A [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) `Millions` értékre állításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a millió megjelenítési egységet alkalmazza.

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

A logaritmikus értéktengely hasznos, ha a pozitív értékek több mérettartományt fednek le. Például egy szolgáltatás öt időszakban 10, 100, 1 000, 10 000 és 100 000 kérést fogad. Lineáris skálán a kisebb értékek közel a nullához csoportosulnak. A logaritmikus skála a relatív növekedést könnyebben összehasonlíthatóvá teszi: az egyenlő távolságok egyenlő arányt jelentenek, nem egyenlő különbséget.

Hívja a [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-)‑t `true`‑val a értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-)‑t az alap kiválasztásához. Ez csak a meglévő értékek megjelenítését változtatja; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy adatkapcsolaton alapuló illesztett vonal, külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal vagy oszlop diagram esetén az értéktengely a [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott. Vízes sávdiagramnál a [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) adja vissza. Pont‑ és buborékkördiagramoknak két értéktengelyük van, ezért X‑értékekhez a vízszintes, Y‑értékekhez a függőleges, vagy mindkettő használható. Logaritmikus skálát ne alkalmazzon kategória tengelyen.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramok esetén az alap `2`‑tól `1000`‑ig terjedhet, a törtalapok, például `2.5`, szintén támogatottak. A `10`‑es alappal a sorozatos hatványok, mint 10, 100, 1 000, 10 000 egyenlő távolságra vannak.

### **Lineáris és logaritmikus skálázás összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre az öt kérelem számmal az első dián, majd lemásolja azt, és a második diához 10‑es alapú logaritmikus értéktengelyt kapcsol be. Mindkét dia ugyanazt az adatot tartja.

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

    // Az első diát lineárisnak hagyja, és csak a másolat értéktengely skáláját változtassa meg.
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

**Lineáris skála (dia 1):** Az egyenlő függőleges távolságok egyenlő különbséget jelentnek a kérelem számokban. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban öt kérelem számával lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (dia 2):** Az egyenlő függőleges távolságok egyenlő arányt jelentenek. Minden időszak tízszer több kérést tartalmaz, mint az előző, ezért a pontok egy egyenesen emelkedő vonalat alkotnak a 10‑es alapon. A tengelycímkék továbbra is az eredeti kérelem számokat mutatják.

![Ugyanaz az öt kérelem szám a PowerPointban 10‑es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy negatív értékek jelentősek, tartsa meg a lineáris skálát, vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő az elemzéshez, magyarázza meg az elhagyás okát. Ne cserélje őket csendben kis pozitív számokra, mert ez megváltoztatja az adatok jelentését. Bármely, logaritmikus tengelyhez manuálisan beállított minimum vagy maximum értéknek szintén pozitívnak kell lennie.

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely keresztezi a másikat (tengelykeresztezés)?**

Használja a [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-)‑t a keresztelési viselkedés kiválasztásához. Egy numerikus keresztérték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)-t. Ezek a beállítások lehetővé teszik a tengely kereszteződésének áthelyezését egy megfelelő alapvonalra.

**Hogyan helyezhetem el a jelzések címkéit a tengelyhez képest?**

Hívja a [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-)‑t a [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` vagy `None` használatával. A jelölőjelek maguk szabályozásához használja a [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) vagy a [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-)-t; ezek különállóak a címke pozícionálástól.