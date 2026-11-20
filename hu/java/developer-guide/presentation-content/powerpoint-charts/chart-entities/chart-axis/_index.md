---
title: Diagramtengelyek testreszabása prezentációkban Java használatával
linktitle: Diagramtengely
type: docs
url: /hu/java/chart-axis/
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
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for Java-t a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Java segítségével. Kitér a számított tengelyértékekre, a diagram sorok és oszlopok cseréjére, a tengely láthatóságára, a kategória címke- és jelölő-intervallumokra, a dátumkategóriákra és formázásukra, a cím forgatására, a tengely elhelyezésére, a megjelenítési egységekre és a logaritmikus skálázásra.

## **A függőleges tengely maximális értékeinek lekérése diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) objektumot, és adjon hozzá egy alapértelmezett adatokkal rendelkező területdiagramot. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) metódust a számított tengelyértékek leolvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa a [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) és a [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) metódusokkal a tengely határait, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) és a [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) metódusokkal a jelölőintervallumokat. A [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) időegység-skálákat ad vissza, amelyek dátumtengelyek esetén relevánsak. A példa ezeket az értékeket helyi változókba menti, és elmenti a diagramot.

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

## **Adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) metódust a sorozatok és a kategóriák szerepének megcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) metódust használja, hogy az alapértelmezett adatokat a `Sheet1!A1:D5` tartományhoz kötötte, beleértve a fejléc sort és a kategória oszlopot, mielőtt sorokat és oszlopokat cserélt volna. Négy sorozattal és három kategóriával ment egy diagramot.

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

## **Egy tengely ábrázolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) metódust egy kategória vagy értéktengely megfordításához. Például egy vízszintes oszlopdiagram megjelenítheti a projekt szakaszait felülről lefelé ugyanabban a sorrendben, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. Egy tengely megfordítása megváltoztatja az ábrázolás irányát; nem rendezi vagy átrendezi a munkafüzet adatait. Ezzel szemben a [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) megcseréli a sorozatok és a kategóriák szerepét.

A következő példa egy három szakaszú és egy sorozatú vízszintes oszlopdiagramot hoz létre. Három diát ment el: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

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

    // Dia 2: az első kategória megjelenítése a tetején.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // A vízszintes értéktengely alul marad.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Dia 3: csak a vízszintes numerikus skála megfordítása.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy tengely megfordítása a merőleges tengelyt is áthelyezheti a diagram másik oldalára. A [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) szabályozza, hogy a másik tengely hol keresztezi a konfigurált tengelyt. A 2. dián a `CrossesType.Maximum` érték használata a megfordított kategóriatengelyen a vízszintes értéktengelyt alul tartja. Egy konkrét keresztpont meghatározásához használja a [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) metódust. Ellenőrizze a keresztbeállításokat irányváltáskor, különösen ha a diagram már rendelkezik egy egyéni keresztponttal. Hívja meg a `setPlotOrderReversed` metódust `false` értékkel a normál ábrázolási irány visszaállításához; a keresztbeállítások külön kezelendők.

| Normál sorrend (dia 1) | Megfordított kategóriák (dia 2) | Megfordított értékek (dia 3) |
| --- | --- | --- |
| ![Normál kategória- és értéktengely sorrendű vízszintes oszlopdiagram](axis-order-normal.png) | ![Vízszintes oszlopdiagram, ahol a kategóriák felülről lefelé jelennek meg](axis-order-categories-reversed.png) | ![Vízszintes oszlopdiagram, megfordított értéktengellyel és a nulla jobb oldalon](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra nőnek. | Tervezés, Fejlesztés, Tesztelés felülről lefelé. Az értékek és a munkafüzet sor sorrendje változatlan. | A kategóriák megtartják a normál sorrendet; az értékek jobbról balra nőnek. A kategóriatengely a nulla pontnál, jobbra keresztezi a tengelyt. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja meg a [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a függőleges tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a függőleges tengely elrejtésével menti el.

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

Hívja meg a [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a vízszintes tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a vízszintes tengely elrejtésével menti el.

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

## **Diagram rácsvonalainak megjelenítése vagy elrejtése**

Hívja meg a [getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--) és a [getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--) metódusokat, hogy megállapítsa, mely rácsvonalakat jeleníti meg egy tengely. Ezek a metódusok a jelenlegi láthatóságot jelentik. A kisebb rácsvonalak megjelenítéséhez használja a [getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) metódust, és állítsa be a vonal kitöltését egy szilárd, látható színre. Az elrejtéshez állítsa a kitöltést a [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill) értékre. A fő rácsvonalak színének módosításához használja a [getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) metódust ugyanúgy. A kitöltés módosítása megőrzi a tengely láthatóságát és a jelölőket.

Ennek a csoportosított oszlopdiagramnak a függőleges tengelye eleinte csak a fő rácsvonalakat mutatja. A példa sötét narancssárgával jeleníti meg a kisebb rácsvonalakat, majd újra elrejti őket, mielőtt elmentené a prezentációt. A kód minden lépésnél kiírja a rácsvonalak láthatóságát.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
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
| ![Narancssárga kisebb rácsvonalak a fő rácsvonalak között a függőleges tengelyen](minor-gridlines-enabled.png) | ![Ugyanaz az oszlopdiagram, csak a fő rácsvonalak láthatók](minor-gridlines-hidden.png) |

## **Kategóriatengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust egy dátum vagy szöveg kategóriatengely kiválasztásához. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelynek az első diáján az első alakzat egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengelyre változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) `false`, a [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) `TimeUnitType.Months` beállítás egyhónapos fő jelölőket helyez el.

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

### **A kategóriatengely típusának meghatározása adatok alapján**

A kategóriák feltöltése után hívja meg a [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) metódust, majd olvassa le a [getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--) értékét a kiválasztás ellenőrzéséhez. Hasznos, ha ugyanaz a diagram szöveges címkéket vagy numerikus dátumértékeket kap. A metódus a meghíváskor határozza meg a típust; nem aktivál tartós módot, ami későbbi adatváltozásokra újra kiértékelődne. Hívja meg újra a kategóriák cseréje után.

A következő példa egy szöveges kategóriákkal rendelkező diagramot hoz létre, és `true` értékkel jelzi, ha a kiválasztott típus `CategoryAxisType.Text`. Ezután a kategória cellaértékeket dátumokra cseréli, újra meghívja a metódust, és `true` értékkel jelzi, ha a kiválasztott típus `CategoryAxisType.Date`. A dátumok numerikus OLE Automation értékekként vannak tárolva, a 1899. december 30. óta eltelt napok számaként, nem dátum karakterláncként. A [setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) szabályozza, hogyan jelennek meg ezek az értékek; nem konvertál szöveget numerikus dátumokká. További információk a kategória cellákról: [Chart Workbook](/slides/hu/java/chart-workbook/).

Használja az automatikus meghatározást, ha a bemenet szöveges kategóriákat vagy numerikus dátumokat tartalmaz, mint ebben a példában. Szokásos numerikus címkék, vegyes kategóriák vagy üres adatok esetén hívja meg kifejezetten a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-) metódust a kívánt jelentésnek megfelelően. Egyedül a numerikus értékek nem bizonyítják, hogy a kategóriák dátumok.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

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
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // true

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategóriatengely címkeintervallumok szabályozása**

Ha egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) metódust `false` értékkel, majd adja meg a kívánt kategóriaintervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metódussal. Szöveges kategóriák esetén a normál sorrendben a számlálás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, két címke rejtve marad a megjelenített címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőknek külön vezérlése van. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) metódust `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) metódust az intervallum beállításához. Például az `1` minden kategóriaintervallumban hagy egy jelölőt, miközben a címkék csak minden harmadik kategórián jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) metódust látható stílussal, hogy lássa az eredményt. Az automatikus beállítást `true` értékre állítva a diagram újra kiválasztja az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment el a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, manuális címkeintervallum független jelölőkkel, és a visszaállított automatikus távolság. A két másolat megtartja az eredeti diagram adatokat. Bemutató bemenetre nincs szükség. A vízszintes címketekst megkönnyíti a sűrűség különbségének megfigyelését.

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

    // Dia 2: minden harmadik címke megjelenítése, de minden kategóriához megtart egy jelölőt.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: a diagram válassza újra mindkét intervallumot.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus távolság (dia 1):** Ebben a megjelenítésben minden második kategóriacímke látható és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusaiktól és a renderelőtől függően változhat.

![Automatikus kategóriacímke‑távolság, minden 24 oszlop látható](category-axis-automatic.png)

**Manuális távolság (dia 2):** Minden harmadik címke egy sorban jelenik meg, míg a jelölők minden kategóriaintervallumban megmaradnak. Az összes 24 oszlop, beleértve a címkék nélküli oszlopokat is, látható ugyanazzal az értékkel. A 3. dia visszaállítja a fent látható automatikus megjelenést.

![Manuális kategóriacímke‑intervallum háromra, minden 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategóriaszám‑intervallumot egy szöveges kategóriatengelyhez, például egy oszlop-, vonal-, terület- vagy oszlopdiagram kategóriatengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízu­szintes oszlopdiagram esetén a kategóriatengely függőleges, ezért alkalmazza a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott tengelyre. A jelölő‑távolság sorozattengelyre is vonatkozik azokban a diagramokban, ahol van ilyen.

Ne használja a kategóriacímke‑intervallumot a numerikus értéktengely skálájának beállítására. Egy értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) érték a különböző értékek közti különbséget határozza meg: például a `10` nagy egység 0, 10, 20, … jelölőket eredményez, ha a tengely nulláról indul. A `3` kategóriacímke‑intervallum ezzel szemben a kategória‑pozíciókat számolja, függetlenül a tényleges adatértékektől. Szórt- és buborékdiagramok értéktengelyt használnak, nem szöveges kategóriatengelyt. Dátumtengely esetén használjon időalapú nagy egységeket és skálákat, ahogy a [Kategóriatengely módosítása](#change-a-category-axis) szakaszban le van írva.

## **A kategóriatengely értékek dátumformátumának beállítása**

A példa az alapértelmezett diagramadatokat négy éves értékre cseréli. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaiként. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust `CategoryAxisType.Date` értékkel, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) `false` értékkel, és adja át a `yyyy` formátumot a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metódusnak, hogy a kategóriacímkék négy számjegyű éveket jelenítsenek meg a cellaformázástól függetlenül.

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

## **A diagramtengely címének forgatási szögének beállítása**

Hívja meg a [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) metódust `true` értékkel a függőleges tengelyen, adja meg a címszöveget, és használja a [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metódust a cím forgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek az értéktengely címe 90 fokkal van elforgatva.

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

## **Az tengely pozíciójának beállítása kategória- vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metódust annak szabályozására, hogy az értéktengely a kategóriatengelyet a kategóriák között vagy a kategória‑jelölőknél keresztezi-e. Ez a beállítás a kategóriatengelyekre vonatkozik. A példa a `true` értéket állítja be a oszlopdiagram vízszintes kategóriatengelyén, és elmenti az eredményt.

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

Használja a [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) metódust, hogy a értéktengely címkéit skálázza anélkül, hogy a mögöttes adatokat módosítaná. A [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) `Millions` értékével a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a milliók megjelenítési egységét alkalmazza.

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

A logaritmikus értéktengely akkor hasznos, ha a pozitív értékek több nagyságrendet fednek le. Például egy szolgáltatás öt időszak alatt 10, 100, 1 000, 10 000 és 100 000 kérésre számíthat. Lineáris skálán a kisebb értékek szorosan a nulla közelében helyezkednek el. A logaritmikus skála egyenlő távolságokkal egyenlő arányokat jelenít meg, nem egyenlő különbségeket.

Hívja meg a [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) metódust `true` értékkel az értéktengelyen, és a [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) metódussal válassza ki az alapot. Ez csak a meglévő értékek megjelenítését változtatja; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy külön funkció, amely a adatokhoz illesztett kapcsolatot ábrázolja.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az értéktengely a [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) metódussal érhető el. Vízszintes oszlopdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) metódus adja vissza. Szórt- és buborékdiagramok két értéktengellyel rendelkeznek, ezért az X‑értékekhez a vízszintes tengelyt, az Y‑értékekhez a függőleges tengelyt vagy mindkettőt válassza. Ne alkalmazzon logaritmikus skálát kategóriatengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén használjon `2`‑tól `1000`‑ig terjedő (beleértve) alapot; töredékes alapok, például `2.5`, szintén támogatottak. A `10`‑es alappal a sorozatos hatványok – 10, 100, 1 000, 10 000 – egyenlő távolságúak.

### **Lineáris és logaritmikus skálák összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az első dián az öt kérés számmal, majd klónozza azt, és a második dián a `10`‑es alapú logaritmikus értéktengelyt aktiválja. Mindkét dia ugyanazt az adatot tartja meg.

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

**Lineáris skála (dia 1):** Az egyenlő függőleges távolságok egyenlő kérésszám‑különbségeket jelentenek. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen különböztethetők meg.

![Vonaldiagram PowerPoint‑ban, öt kérés számmal lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (dia 2):** Az egyenlő függőleges távolságok egyenlő arányokat jelentnek. Minden periódus tízszer annyi kérést tartalmaz, mint az előző, ezért a pontok egyenes, felfelé ívelő vonalat alkotnak a `10`‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérésszámokat mutatják.

![Ugyanaz az öt kérés szám PowerPoint‑ban logaritmikus értéktengelyen, alap `10`](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

Logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt aktiválná. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát, vagy jelenítse meg őket külön. Ha a kizárás megfelelő az elemzéshez, magyarázza el az eltávolítást. Ne cserélje őket automatikusan kis pozitív számokra, mert ez megváltoztatja az adatok jelentését. Bármely manuálisan konfigurált minimum vagy maximum logaritmikus tengelyen is pozitívnak kell lennie.

## **GYIK**

**Hogyan állítható be, hogy egy tengely hol keresztezze a másikat (tengelykeresztezés)?**

Használja a [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) metódust a keresztelési viselkedés kiválasztásához. Numerikus keresztpont megadásához használja a [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) metódust. Ezek a beállítások lehetővé teszik a tengelykeresztezés mozgatását egy megfelelő alapvonalra.

**Hogyan helyezhetők el a jelölőcímkék a tengelyhez képest?**

Hívja meg a [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) értékeivel: `Low`, `High`, `NextTo` vagy `None`. A jelölőket magukat a [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) vagy a [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) metódusokkal szabályozhatja; ezek különállóak a címkehelyezéstől.