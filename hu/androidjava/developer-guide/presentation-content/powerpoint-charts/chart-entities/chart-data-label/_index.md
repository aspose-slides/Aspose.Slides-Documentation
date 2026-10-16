---
title: Diagram adatcímkék kezelése Android prezentációkban
linktitle: Adatcímke
type: docs
url: /hu/androidjava/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpontosság
- százalék
- címke távolság
- címke elhelyezés
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá és formázzon diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for Android segítségével Java nyelven, hogy lebilincselőbb diák készüljenek."
---
## **Bevezetés**

Az adatcímkék információt jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatók az értékek, hogyan jeleníthetők meg a százalékok, hogyan olvasható a címke szövege, hogyan irányíthatók a címkék a tengely maximumán túl, hogyan állítható be a kategória tengely címkéinek távolsága, és hogyan helyezhetők el a kördiagram címkék.

## **Adatpontok pontosságának beállítása a diagramcímkékben**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) metódust a sorozat értékeinek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozat számára. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a tényleges értékeket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Százalékok megjelenítése címkeként**

Halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagramadatokat használja, és két tizedesjegy pontosságú százalékokat jelenít meg 8 pontos betűmérettel. A nulla összegű kategóriákat kihagyja, hogy elkerülje a nullával való osztást. Ha a diagram adatai változnak, számolja újra az egyéni címkeszöveget.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Százalékjel beállítása diagramcímkékkel**

Ha az értékek törtként vannak tárolva, használja a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) metódust a százalékok megjelenítéséhez. Adja át a `false` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) metódusnak, hogy a címke formátuma független legyen a forráscelláktól.

Ez a példa egy 100 % halmozott oszlopdiagramot hoz létre piros és kék sorozattal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum a 0.30 értéket 30.0 %-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    int[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az adatcímkék tényleges szövegének olvasása**

Használja a [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) metódust a címke beállításai által előállított szöveg lekérdezéséhez. Ez hasznos jelentésekhez címkék kinyerésekor, a bemutató tartalmának keresésekor vagy a generált diagramok ellenőrzésekor. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/) egyesíti minden kategórianév, sorozatnév és érték megjelenítését. Az egyik pont értékét százalékformátumban jeleníti meg, a másik a [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) által visszaadott egyéni szöveget használja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

A adatpontban tárolt szám továbbra is `0.75`, még akkor is, ha a címke `75 %`-ként jelenik meg a kategória- és sorozatnevekkel együtt. Az egyéni szöveg felülírja a generált címkeszöveget. A [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) mindkét esetben a kapott címkesztringet adja vissza. Nézze meg külön a [isVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#isVisible--) értékét, ahogy fent is látható, ha csak a látható címkéket szeretné kinyerni.

## **Adatcímkék vezérlése a tengely maximumán túl**

Ha manuálisan korlátozza egy tengely tartományát, egyes adatpontok meghaladhatják a maximumot. Használja a [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) metódust annak szabályozására, hogy megjelenjenek-e ezek a címkék. Ez a beállítás csak a címke láthatóságát változtatja; nem módosítja a tengely tartományát vagy a mögöttes adatértékeket.

Az alábbi példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. A `false` értéket adja a [setAutomaticMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) metódusnak, és a függőleges tengelyen a [setMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) metódussal 100-ra állítja a maximumot. Az első dián a címkék a maximumon túl is megjelennek; egy másolat ezt letiltja. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlba kerül mentésre.

Engedélyezze az értékcímkéket a [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) metódussal. A diagram szintű beállítás önmagában nem jelenít meg értékeket, és nem ír felül egyedi címkénél letiltott értékmegjelenítést. Ez a példa az egész sorozatra engedélyezi az értékek megjelenítését, és a [setPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) segítségével a címkéket minden oszlop külső végére helyezi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi képek a Microsoft PowerPoint által renderelt mentett diákat mutatják. `true` esetén a **120** címke látható a felső határon; `false` esetén rejtve marad. A **60** címke továbbra is látható, a tengely maximuma **100** marad, és a második adatpont mindkét esetben **120** marad.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Azok a diagramok, amelyeknek nincs értéktengelye, például a kör- és fánkdiagramok, nem rendelkeznek olyan tengelymaximumszal, amelyet így korlátozhatna.
{{% /alert %}}

## **Címke távolságának beállítása a tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) metódust a kategória tengely címkéi és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategória tengely címkéire hat, nem pedig az egyedi adatpontokhoz kapcsolódó címkékre.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Címke helyének beállítása**

Kördiagramon a adatcímkék helyének módosításával javítható a térköz, és helyet biztosíthat a vezető vonalak számára.

Ez a példa az első adatpont értékét jeleníti meg, a címkét a szelet kívülre helyezi, majd a [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) és a [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) segítségével állítja be a vízszintes és függőleges eltolásokat. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva arányosak.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kördiagram módosított adatcímke helyzetével](pie-chart-adjusted-label.png)

## **Vezető vonalak formázása**

Amikor a kördiagram címkék a szeletek kívül helyezkednek el, a vezető vonalak segítik az olvasót, hogy az egyes értékeket a megfelelő szelethez kössék. Egy kontrasztos szín és egy kicsit vastagabb vonal megkönnyítheti ezeket a kapcsolódásokat, míg az átlátszóság és a szaggatott stílus kevésbé zavaróvá teszi a vonalakat.

Használja a [getLeaderLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) metódust a vezető vonalak formázásához a sorozat adatcímke-gyűjtemény szintjén. A `series.getLabels().getLeaderLinesFormat().getLine()` beállítások a gyűjteményre, nem egyedi címkére vonatkoznak.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, a szeletek kívül jeleníti meg az értékeket, és engedélyezi a [setShowLeaderLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-) metódust. Két címkét távolabb helyez a szeletektől a [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) és a [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) eltolásokkal, amelyek a diagram szélességének és magasságának tört részei. Bemeneti prezentáció nem szükséges.

A vonal [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) egy szilárd kék színt állít be 255-ből 191 alfa értékkel, ami körülbelül 25 % átlátszóságot eredményez. A [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) 2 pont vastagságra állítja, a [setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) pedig szaggatott vonallá alakítja.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // Két címkét távolabb helyez a szeleteiktől.
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(Color.argb(191, 30, 90, 160));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A vezető vonalak engedélyezése nem garantálja, hogy minden címkéhez vonal jelenik meg. A láthatóság a címke elhelyezésétől és a diagram elrendezési viselkedésétől függ. Ebben a példában a két eltolódott címkének látható vezető vonala van; a szeletekhez közel maradt címkéknek nincs szükségük rájuk.

Az alábbi kép a `FormattedLeaderLines.pptx` mentett fájlt mutatja, amelyet az Aspose.Slides renderelt:

![Kördiagram kék, félig átlátszó, szaggatott vezető vonalakkal, amelyek a két kívülre helyezett címkét a szeletekhez csatlakoztatják](formatted-leader-lines.png)

## **Több sor adatcímke hozzáadása egy oszlopdiagram felett**

Ez a példa egy oszlopdiagramot hoz létre, amelynek két sor adatcímkéje van a diagramterület felett. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Oszlopaikat a kitöltés és a körvonal eltávolításával rejtik. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartseriesgroup/#setOverlap-byte-) metódus mindhárom sorozatot ugyanazzal a kategóriaközépponttal igazítja.

A [ChartPlotArea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartplotarea/) beállításai helyet foglalnak a címkesoroknak. A [Chart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) az alapértelmezett pozíciókat kiszámítva, a [DataLabel.setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setX-float-) és a [DataLabel.setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setY-float-) megőrzi a vízszintes igazítást, és függőleges eltolásokat alkalmaz a címkék két sorba rendezéséhez. A számok továbbra is a sorozatértékekhez kapcsolódó adatcímkék maradnak; csak a sorfejlécek külön szövegalakzatok.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // Rejtse el a B és C oszlopait, de tartsa meg az adatcímkéket.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.InsideBase);
        }
    }

    // Igazítsa az összes három sorozatot ugyanarra a kategóriaközéppontra.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap((byte) 100);

    // Használjon kevesebb rácsvonalat ebben a kompakt példában.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Tartson fenn helyet a diagram felett két sor adatcímkének.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Tartsa meg az alapértelmezett vízszintes pozíciót. Az Y egy eltolás a
            // alapértelmezett címkehelyzettől, a diagrammagasság tört részében kifejezve.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Csak a sorfejléc egy külön szövegalakzat.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Oszlopdiagram két sor adatcímkével a diagramterület felett](multiple-rows-of-labels.png)

## **FAQ**

**Hogyan akadályozhatom meg, hogy az adatcímkék átfedjék egymást sűrű diagramokon?**

Használjon automatikus címkeelhelyezést, vezető vonalakat és csökkentett betűméretet; szükség esetén rejtsen el néhány mezőt (például a kategóriát), vagy csak szélső értékek vagy kulcspontok esetén jelenítse meg a címkéket.

**Hogyan tilthatom le a címkéket csak a nulla, negatív vagy üres értékeknél?**

Szűrje először az adatpontokat, mielőtt engedélyezné a címkéket, és kapcsolja ki a megjelenítést a 0‑nál, negatív vagy hiányzó értékeknél egy meghatározott szabály szerint.

**Hogyan biztosíthatom a címkestílus egységességét PDF‑/képfájlokba exportáláskor?**

Határozza meg explicit módon a betűcsaládot és a méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelési környezetben, hogy elkerülje a helyettesítést.