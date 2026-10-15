---
title: Diagram tengelyek testreszabása prezentációkban Java használatával
linktitle: Diagram tengely
type: docs
url: /hu/java/chart-axis/
keywords:
- diagram tengely
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
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Java könyvtárat a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testreszabhatóak a diagram tengelyek az Aspose.Slides for Java segítségével. Tárgyalja a kiszámított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címkék és jelzővonalközök intervallumait, a dátumkategóriákat és formázást, a cím forgatását, a tengely pozicionálását, a megjelenítési egységeket és a logaritmikus skálázást.

## **A legnagyobb értékek lekérése a függőleges tengelyen a diagramokban**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) és adjon hozzá egy területdiagramot az alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) metódust a kiszámított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) és a [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) metódusokat a tengelykorlátokért, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) és a [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) metódusokat a jelölőközökért. A [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) időegység skálákat adnak, amelyek a dátumtengelyekhez relevánsak. A példában ezek az értékek helyi változókba kerülnek, és a diagram mentésre kerül.

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

Használja a [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) metódust a diagram adatok sorozatok és kategóriák szerepének felcseréléséhez. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatok csoportosításának módját; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) metódust használja az alapértelmezett adatok `Sheet1!A1:D5` tartományra kötéséhez, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt a sorokat és oszlopokat felcserélné. Egy négy sorozatos és három kategóriás diagramot ment.

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

## **A tengely rajzolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) metódust egy kategória vagy értéktengely megfordításához. Például egy vízszintes oszlopdiagram ugyanabban a sorrendben jelenítheti meg a projekt szakaszait fentől lefelé, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. A tengely megfordítása a rajzolási irányt változtatja; nem rendezi át vagy módosítja a munkafüzet adatait. Összehasonlításként a [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) felcseréli a sorozatok és kategóriák szerepét.

A következő példa egy vízszintes oszlopdiagramot hoz létre három szakasz és egy sorozat segítségével. Egy három diát tartalmazó prezentációt ment: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

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

    // Dia 2: az első kategóriát felülre jelenítse meg.
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

A tengely megfordítása a merőleges tengelyt is áthelyezheti a diagram ellentétes oldalára. A [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) szabályozza, hogy a konfigurálandó tengelyt hol metszik a másik. A 2. dián a `CrossesType.Maximum` használata a megfordított kategória tengelyen a vízszintes értéktengelyt alul tartja. Egy konkrét metszéspont megadásához használja a [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) metódust. Irányváltáskor ellenőrizze a metszésbeállításokat, különösen ha a diagram már rendelkezik egyedi metszésponttal. Hívja a `setPlotOrderReversed` metódust `false` értékkel a normál rajzolási irány visszaállításához; a metszési beállítások különállóak.

| Normal order (slide 1) | Reversed categories (slide 2) | Reversed values (slide 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra növekednek. | Tervezés, Fejlesztés és Tesztelés felülről lefelé halad. Az értékek és a munkafüzet sor sorrendje változatlan. | A kategóriák megtartják a normál sorrendet; az értékek jobbról balra növekednek. A kategóriatengely a jobb oldalon nullánál metszi. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja a [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a függőleges tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a függőleges tengely rejtve menti.

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

Hívja a [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a vízszintes tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a vízszintes tengely rejtve menti.

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

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust egy dátum vagy szöveg kategória tengely kiválasztásához. Ez a példa az `ExistingChart.pptx` fájlt igényli, ahol a diagram az első dián az első alakzat, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) `false`, a [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) `TimeUnitType.Months` beállításával a fő jelölők egyhónapos intervallumokra kerülnek.

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

Amikor egy diagram sok kategóriát tartalmaz, csökkentse a látható tengelycímkék számát a kategóriák vagy adatszámok eltávolítása nélkül. Hívja a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) metódust `false` értékkel, majd adja át a kívánt kategória intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metódusnak. Szöveges kategóriák normál sorrendjében a számozás az első kategóriától indul:

| Intervallum | Példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, és két címkét rejt a megjelenített címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus térköz a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölővonalak külön vezérelhetők. Hívja a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) metódust `false` értékkel, majd a [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) segítségével állítsa be az intervallumukat. Például a `1` minden kategória intervallumban megtart egy jelölővonalat, míg a címkék csak minden harmadik kategórián jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) metódust látható stílussal, hogy lássa az eredményt. Ha a két automatikus beállítót újra `true`‑ra állítja, a diagram újra kiválasztja azt az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus térköz, kézi címke-térköz független jelölővonalakkal, valamint a visszaállított automatikus térköz. A két másolat az eredeti diagramadatokat megtartja. Nem szükséges bemeneti prezentáció. A vízszintes címke szöveg könnyen láthatóvá teszi a sűrűségbeli különbséget.

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

    // Dia 2: minden harmadik címkét jelenítsen meg, de minden kategóriához tartson egy jelölővonalat.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: hagyja, hogy a diagram újra kiválassza mindkét intervallumot.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus térköz (slide 1):** Ebben a megjelenítésben minden második kategóriacímke látható és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusoktól és a megjelenítőtől függően változhat.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Kézi térköz (slide 2):** Minden harmadik címke jelenik meg egy sorban, míg a jelölővonalak minden kategória intervallumban megmaradnak. Az összes 24 oszlop, beleértve a címké nélküliket is, ugyanazokkal az értékekkel látható. A 3. dia visszaállítja a fentebb látható automatikus megjelenést.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória-szám intervallumot szöveges kategória tengelyhez, például oszlop-, vonal-, terület- vagy oszlopdiagram kategória tengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízes oszlopdiagramnél a kategória tengely függőleges, ezért ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott tengelyre alkalmazza. A jelölővonalak térköze azokra a sorozat tengelyekre is vonatkozik, amelyekkel rendelkező diagramok rendelkeznek.

Ne használja a kategória címke térközét az értéktengely numerikus skálájának beállítására. Egy értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) egy értékkülönbséget határoz meg: például a `10` fő egység 0, 10, 20 stb. értékeken jelöl. A `3` kategória címke intervallum a kategória pozíciókat számolja, függetlenül azok adatértékétől. Szórt és buborék diagramok értéktengelyeket használnak szöveges kategória tengely helyett. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogyan a [Kategória tengely módosítása](#change-a-category-axis) részben le van írva.

## **Dátumformátum beállítása a kategória tengely értékekhez**

A példa az alapértelmezett diagramadatokat négy éves értékkel helyettesíti. A dátumok az első munkalapon (index `0`) OLE Automation sorozatszámként tárolódnak, a 1899. december 30. óta eltelt napok számaként számítva. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust `CategoryAxisType.Date` értékkel, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metódust `false` értékkel, és adja át a `yyyy` formátumot a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metódusnak, hogy a kategória címkék négy számjegyű évként jelenjenek meg a cellaformázástól függetlenül.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
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

## **Forgatási szög beállítása a diagram tengelycíméhez**

Hívja a [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) metódust `true` értékkel a függőleges tengelyen, adja meg a címszöveget, és használja a [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metódust a cím elforgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment, amelynek az értéktengely címe 90 fokban van elforgatva.

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

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metódust annak szabályozására, hogy az értéktengely a kategóriatengelyt a kategóriák között vagy a kategória jelölővonalaknál metszze. Ez a beállítás a kategória tengelyekre vonatkozik. A példa a `true` értéket állítja a oszlopdiagram vízszintes kategória tengelyén, és elmenti az eredményt.

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

## **Megjelenítési egység beállítása a diagram értéktengelyén**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) metódust az értéktengely feliratainak méretezéséhez az adatok módosítása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) `Millions` értékre állításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a milliók megjelenítési egységét alkalmazza.

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

A logaritmikus értéktengely hasznos, ha a pozitív értékek több nagyságrendet fednek le. Például egy szolgáltatás öt időszakon keresztül 10, 100, 1 000, 10 000 és 100 000 kérést vehet be. Lineáris skálán a kisebb értékek közel helyezkednek el a nulla körül. A logaritmikus skála megkönnyíti a relatív növekedés összehasonlítását: az egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Hívja a [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) metódust `true` értékkel az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) metódust az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatokat, illetve nem ad hozzá logaritmikus trendvonalat. A trendvonal az adatok illesztett kapcsolatát reprezentálja, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén a [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) adja vissza az értéktengelyt. Vízes oszlopdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) adja vissza. Szórt és buborék diagramok két értéktengellyel rendelkeznek, ezért válassza a vízszintes tengelyt az X‑értékekhez, a függőleges tengelyt az Y‑értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategória tengelyen.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramok esetén az `2`‑tól `1000`‑ig terjedő (beleértve) alapot használhat, a tört értékek, például `2.5` is támogatottak. A `10` alap esetén a 10, 100, 1 000 és 10 000 sorozatos hatványai egyenlő távolságra esnek.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az első dián az öt kérés számával, majd lemásolja azt, és a második dián 10‑es alapú logaritmikus értéktengelyt engedélyez. Mindkét dia ugyanazt az adatot tartja.

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

    // Az első diát lineárisan hagyja, és csak a másolat értéktengelyének skáláját változtassa meg.
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

**Lineáris skála (slide 1):** Az egyenlő függőleges távolságok egyenlő különbségeket képviselnek a kérés számában. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen elkülöníthetők.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmikus skála (slide 2):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden periódus tízszer nagyobb kérésszámot tartalmaz, mint az előző, így a pontok egy egyenes emelkedő vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérés számokat mutatják.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat a bekapcsolás előtt. Ha a nulla vagy negatív értékek jelentősek, tartsa a lineáris skálát vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő a elemzéshez, magyarázza meg az elhagyást. Ne cserélje őket néma módon kis pozitív számokra, mert ez megváltoztatja az adatok jelentését. Bármely kézzel beállított minimum vagy maximum a logaritmikus tengelyen is pozitívnak kell legyen.

## **GYIK**

**Hogyan állítható be az a pont, ahol egy tengely keresztezi a másikat (tengelykereszt)?**

Használja a [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) metódust a keresztezési viselkedés kiválasztásához. Egy numerikus keresztezési érték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) metódust. Ezek a beállítások lehetővé teszik, hogy a tengelykeresztet a megfelelő alapszintre helyezze.

**Hogyan helyezhetők el a jelölőcímkék a tengelyhez viszonyítva?**

Hívja a [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) használatával: `Low`, `High`, `NextTo` vagy `None`. A jelölővonalak önmaguk szabályozásához használja a [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) vagy a [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) metódusokat; ezek különállóak a címkepozicionálástól.