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
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for Android Java-val a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Android Java segítségével. Kitér a kiszámított tengelyértékekre, a diagram sorok és oszlopok felcserélésére, a tengely láthatóságára, a kategória címke és a jelölőpontok intervallumaira, a dátumkategóriákra és formázásukra, a cím elforgatására, a tengely pozícionálásra, a megjelenítési egységekre és a logaritmikus skálázásra.

## **A függőleges tengely maximális értékeinek lekérése diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) elemet, és adjon hozzá egy alapértelmezett adatokkal rendelkező területdiagramot. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) metódust a kiszámított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa ki a tengely határait a [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) és a [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) metódusokkal, valamint a jelölőpont intervallumokat a [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) és a [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) segítségével. A [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) időegység-skalákat biztosítanak, amelyek a dátumtengelyeknél relevánsak. A példa ezeket az értékeket helyi változókba tárolja, és elmenti a diagramot.

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

Használja a [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) metódust a sorozatok és kategóriák szerepének felcserélésére a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatcsoportosítást; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) metódust használja, hogy az alapértelmezett adatokat a `Sheet1!A1:D5` tartományra kötse, beleértve a fejléc sort és a kategóriakolumnát, a sorok és oszlopok felcserélése előtt. Egy négy sorozatú és három kategóriájú diagramot ment.

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

## **Tengely ábrázolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) metódust egy kategória vagy értéktengely megfordításához. Például egy vízszintes sávdiagram meg tudja jeleníteni a projekt fázisait felülről lefelé ugyanabban a sorrendben, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. Egy tengely megfordítása megváltoztatja az ábrázolás irányát; nem sorba rendezi vagy átrendezi a munkafüzet adatait. Összehasonlításként a [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) felcseréli a sorozatok és kategóriák szerepét.

A következő példa egy három fázisú és egy sorozatú vízszintes sávdiagramot hoz létre. Egy három diát tartalmazó bemutatót ment: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

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

    // 2. dia: jelenítsük meg az első kategóriát a tetején.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Tartsa a vízszintes értéktengelyt alul.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 3. dia: csak a vízszintes numerikus skálát fordítsa meg.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A tengely megfordítása az ábrázolás ortogonal tengelyét is az ellenoldalra helyezheti. A [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) szabályozza, hogy a másik tengely hol keresztezi a beállított tengelyt. A 2. dián a `CrossesType.Maximum` értékkel hívva a megfordított kategóriatengelyen a vízszintes értéktengely alul marad. Egy konkrét keresztponthoz használja a [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) metódust. Ellenőrizze a keresztbeállításokat irányváltáskor, különösen ha a diagram már rendelkezik egy egyéni keresztponttal. Hívja a `setPlotOrderReversed`-t `false` értékkel a normál ábrázolási irány visszaállításához; a keresztbeállítások különállóak.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra növekednek. | A Tervezés, Fejlesztés és Tesztelés felülről lefelé halad. Az értékek és a munkafüzet sor sorrendje változatlan. | A kategóriák megtartják normál sorrendjüket; az értékek jobbról balra növekednek. A kategóriatengely a jobb oldalon nullán keresztül halad. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja meg a [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a függőleges tengelyen a rejtéséhez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a függőleges tengely letiltott állapotban.

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

Hívja meg a [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a vízszintes tengelyen a rejtéséhez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a vízszintes tengely letiltott állapotban.

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

## **Diagram rácsvonalak megjelenítése vagy elrejtése**

Hívja meg a [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) és a [getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) metódusokat, hogy ellenőrizze, mely rácsvonalakat jeleníti meg egy tengely. Ezek a metódusok a aktuális láthatóságot jelentik. A kisebb rácsvonalak megjelenítéséhez használja a [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) metódust, és állítsa be a vonalkitöltést szilárd, látható színre. Elrejtéshez állítsa a kitöltést a [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill) értékre. A fő rácsvonalak vonalkitöltésének módosításához hasonlóan használja a [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) metódust. A kitöltés módosítása megőrzi a tengely láthatóságát és a jelölőpontokat.

A csoportosított oszlopdiagram függőleges tengelye kezdetben csak a fő rácsvonalakat jeleníti meg. A példa a kisebb rácsvonalakat sötét narancssárgára állítja, majd a mentés előtt újra elrejti őket. A lépéseknél a rácsvonal láthatóságát kiírja.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kisebb rácsvonalak engedélyezve | Kisebb rácsvonalak rejtve |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **Kategória tengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust, hogy dátum- vagy szöveges kategória tengelyt válasszon. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelynek első diáján az első alakzat egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátum tengelyre állítja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) `false`, a [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) `TimeUnitType.Months` beállítás egyhónapos intervallumokra helyezi a fő jelölőket.

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

### **A kategória tengely típusának meghatározása adatok alapján**

Hívja meg a [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) metódust a kategóriák feltöltése után, majd olvassa ki a [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) értékét a választás ellenőrzéséhez. Ez akkor hasznos, amikor ugyanaz a diagram szöveges címkéket vagy numerikus dátumértékeket kap. A metódus a híváskor határozza meg a típust; nem aktivál tartós módot, amely későbbi adatváltozásokat újraértékelne. Hívja újra a kategóriák cseréje után.

Az alábbi példa szöveges kategóriákkal rendelkező diagramot hoz létre, és `true` értéket ír ki, amikor a kiválasztott típus `CategoryAxisType.Text`. Ezután a kategória cellaértékeket dátumokra cseréli, újra meghívja a metódust, és `true` értéket ír ki, amikor a kiválasztott típus `CategoryAxisType.Date`. A dátumok numerikus OLE Automation értékekként vannak tárolva, amelyeket úgy számolnak, mint a 1899. december 30. óta eltelt napok számát, nem dátumkarakterláncokként. Mindkét naptár UTC-t használ, és a dátumok beállítása előtt törlik őket, hogy a nyári időszámítás és a napszak ne befolyásolja a számítást. A [setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) szabályozza, hogyan jelennek meg ezek az értékek; nem konvertál szöveget numerikus dátummá. További információért lásd a [Diagram munkafüzet](/slides/hu/androidjava/chart-workbook/) oldalt.

Használja az automatikus meghatározást, ha tudja, hogy a bemenet szöveges kategóriákat vagy numerikus dátumokat tartalmaz, ahogy ebben a példában is. Általános numerikus címkék, vegyes kategóriák vagy üres adatok esetén hívja kifejezetten a [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) metódust, hogy a kívánt jelentésnek megfelelően állítsa be. Numerikus értékek önmagukban nem bizonyítják, hogy a kategóriák dátumok.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // igaz

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // igaz

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategória tengely címke intervallumának szabályozása**

Amikor egy diagram sok kategóriát tartalmaz, csökkentse a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) metódust `false` értékkel, majd adja meg a kívánt kategória intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metódussal. Szöveges kategóriák normál sorrendjében a számolás az első kategóriától indul:

| Intervallum | Példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, … Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, … Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, … Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a megjelenített címkék között két címke marad rejtve. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jelenít meg minden címkét.

A jelölőpontoknak külön vezérlése van. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) metódust `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) metódust az intervallum beállításához. Például az `1` minden kategória intervallumnál egy jelölőpontot hagy, míg a címkék csak minden harmadik kategóriánál jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) metódust látható stílussal, hogy lássa az eredményt. Bármelyik automatikus‑távolság beállítót `true`‑ra állítva a diagram újra kiválasztja azt az intervallumot.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke‑távolság független jelölőpontokkal, és visszaállított automatikus távolság. A két másolat az eredeti diagram adatokat őrzi. Bemeneti bemutató nem szükséges. A vízszintes címke‑szöveg könnyen láthatóvá teszi a sűrűségbeli különbséget.

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

    // Dia 2: minden harmadik címkét jelenítsünk meg, de minden kategóriához tartsunk egy jelölőpontot.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: engedjük, hogy a diagram újra kiválassza mindkét intervallumot.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke látható, és két sorba törik. Az automatikus eredmény a diagram méretétől, a betűtípusoktól és a megjelenítőtől függően változhat.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Kézi távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg a jelölőpontok minden kategória intervallumnál megmaradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazokkal az értékekkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória‑szám intervallumot szöveges kategória tengelyen, például egy oszlop-, vonal-, terület- vagy sávdiagram kategória tengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagramnál a kategória tengely függőleges, ezért ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott tengelyen alkalmazza. A jelölőpont‑távolság sorozat‑tengelyekre is vonatkozik olyan diagramokban, ahol van ilyen.

Ne használja a kategória címke‑távolságot az érték tengely numerikus skálájának beállítására. Érték tengelyen a [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) egy értékbeli különbséget határoz meg: például a `10` fő egység 0, 10, 20, … jelölőpontokat hoz létre, ha a tengely nulláról indul. A `3` kategória címke‑intervallum a kategória pozíciókat számlálja, függetlenül azok adatértékétől. Szórt és buborék diagramok érték tengelyeket használnak, nem szöveges kategória tengelyt. Dátum tengely esetén használjon időalapú fő egységeket és skálákat, ahogyan a [Kategória tengely módosítása](#change-a-category-axis) szakaszban leírták.

## **A kategória tengely értékeinek dátumformátum beállítása**

A példa a alapértelmezett diagram adatokat négy éves értékre cseréli. A dátumok OLE Automation sorozatszámokként vannak tárolva az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként. Mindkét naptár UTC-t használ, és a dátumok beállítása előtt törlik őket, hogy a nyári időszámítás és a napszak ne befolyásolja a számítást. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust `CategoryAxisType.Date` értékkel, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metódust `false`‑val, és adja át a `yyyy`‑et a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metódusnak, hogy a kategória címkék négyjegyű évet mutassanak a cella formázásától függetlenül.

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

## **Forgatás szög beállítása a diagram tengely címéhez**

Hívja meg a [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) metódust `true` értékkel a függőleges tengelyen, adja meg a cím szövegét, és használja a [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metódust a cím elforgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment, amelynek az érték‑tengely címe 90 fokban van elforgatva.

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

## **A tengely pozíciójának beállítása kategória vagy érték tengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metódust, hogy szabályozza, az érték tengely a kategória tengelyet a kategóriák között vagy a kategória jelölőpontoknál keresztezi‑e. Ez a beállítás a kategória tengelyekre vonatkozik. A példa `true`‑ra állítja a vízszintes kategória tengelyen egy oszlopdiagramon, és elmenti az eredményt.

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

## **Megjelenítési egység beállítása diagram érték tengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) metódust, hogy a címkéket egy érték tengelyen skálázza anélkül, hogy az alaptadatok változnának. A [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) `Millions` beállításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a millió megjelenítési egységet alkalmazza.

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

## **Logaritmikus érték tengely konfigurálása**

A logaritmikus érték tengely hasznos, ha a pozitív értékek több nagyságrendet feszítenek át. Például egy szolgáltatás öt időszakban 10, 100, 1 000, 10 000 és 100 000 kérést kaphat. Lineáris skálán a kisebb értékek nagyon közel jelennek meg a nullához. A logaritmikus skála könnyebbé teszi a relatív növekedés összehasonlítását: az egyenlő távolságok egyenlő arányt jelentenek, nem egyenlő különbséget.

Hívja a [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) metódust `true`‑val az érték tengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) metódust az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy külön funkció, amely a data‑fit‑kapcsolatot jeleníti meg.

### **Az érték tengely és az alap kiválasztása**

Vonal- vagy oszlopdiagramnél az érték tengely a [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott. Vízszintes sávdiagramnél a [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) adja. Szórt és buborék diagramok két érték tengellyel rendelkeznek, ezért az X‑értékekhez a vízszintes, a Y‑értékekhez a függőleges tengelyt válassza, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategória tengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramoknál használjon `2`‑től `1000`‑ig terjedő alapot, a törtrészes alapok, például `2.5` is támogatottak. A `10` alap esetén a 10, 100, 1 000, 10 000 egymás után egyenlő távolságra kerülnek.

### **Lineáris és logaritmikus skálázás összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre az öt kérés számával az első dián, majd klónozza azt, és a második dián `10`‑es alapú logaritmikus érték tengelyt engedélyez. Mindkét dia ugyanazt az adatot tartalmazza.

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

    // Az első diát lineárisan hagyja, és csak a másolat értéktengelyének skáláját változtatja.
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

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbséget jelentenek a kérés számában. A legnagyobb érték uralja a diagramot, ami nehezíti a kisebb értékek megkülönböztetését.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányt jelentenek. Minden időszak tízszer annyi kérést tartalmaz, mint az előző, így a pontok egyenes, felfelé emelkedő vonalat alkotnak a `10`‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérés számokat mutatják.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. A bekapcsolás előtt ellenőrizze az adatokat. Ha a nulla vagy negatív értékek értelmesek, használjon lineáris skálát vagy jelenítse meg őket külön. Ha az adatok kizárása indokolt az elemzéshez, magyarázza el az elhagyást. Ne helyettesítse őket automatikusan kis pozitív számokkal, mert ez megváltoztatja az adatok jelentését. Bármely manuálisan beállított minimum vagy maximum egy logaritmikus tengelyen szintén pozitív kell legyen.

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely keresztezi a másikat (tengelykereszteződés)?**

Használja a [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) metódust a keresztelési viselkedés kiválasztásához. Számértékű keresztpont megadásához használja a [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) metódust. Ezek a beállítások lehetővé teszik a tengelykereszteződés elhelyezését egy megfelelő alapvonalra.

**Hogyan helyezhetem el a jelölő címkéket a tengelyhez viszonyítva?**

Hívja a [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) értékekkel: `Low`, `High`, `NextTo` vagy `None`. A jelölőpontok maguk szabályozásához használja a [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) vagy a [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) metódusokat; ezek különállóak a címke‑pozicionálástól.