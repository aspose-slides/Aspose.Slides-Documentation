---
title: Diagram adatcímkék kezelése bemutatókban Java használatával
linktitle: Adatcímke
type: docs
url: /hu/java/chart-data-label/
keywords:
- diagram
- adatcímke
- adat pontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint bemutatókban az Aspose.Slides for Java segítségével, hogy érdekfeszítőbb diák jöjjenek létre."
---
## **Bevezetés**

Az adatcímkék a diagram sorozataival és egyes adatpontokkal kapcsolatos információkat jelenítik meg, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk elmagyarázza, hogyan formázhatók az értékek, hogyan jeleníthetők meg a százalékok, hogyan olvasható a címke szövege, hogyan vezérelhetők a címkék a tengely maximumán túl, hogyan állítható be a kategóriatengely címkék távolsága, és hogyan helyezhetők el a kördiagram címkék.

## **Adatcímkék pontosságának beállítása a diagram adatcímkéiben**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) metódust a sorozat értékek formázásához. Ez a példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozat számára. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná az alapértékeket.

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

## **Százalék megjelenítése címkeként**

Halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagram adatokat használja, és a százalékokat két tizedes jeggyel, 8 pontos betűmérettel jeleníti meg. A nulla összegű kategóriákat kihagyja, hogy elkerülje a nullával való osztást. Ha a diagram adatai megváltoznak, számolja újra az egyéni címkeszöveget.

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

## **Százalékjel beállítása a diagram adatcímkékkel**

Ha az értékek törtként vannak tárolva, használja a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) metódust a százalékok megjelenítéséhez. Adjon meg `false` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) metódusnak, hogy a címkeformátumot a forráscelláktól függetlenül alkalmazza.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum a 0,30-at 30,0%-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color[] seriesColors = { Color.RED, Color.BLUE };
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

## **Az adatcímkék tényleges szövegének lekérdezése**

Használja a [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) metódust az adatcímke beállításai által előállított szöveg lekéréséhez. Ez hasznos jelentésekhez címkék kinyerésekor, a bemutató tartalmának keresésekor vagy a generált diagramok ellenőrzésekor. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) egyesíti minden kategórianév, sorozatnév és érték. Egy pont értékét százalékként formázza, míg egy másik egyéni szöveget használ a [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) metódustól.

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

Az adatpontban tárolt szám továbbra is `0.75`, még akkor is, ha a címke `75%`-ot jelenít meg a kategória- és sorozatnevekkel együtt. Az egyéni szöveg felülírja a generált címkeszöveget. A [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) mindkét esetben visszaadja a kapott címkestringet. A [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) metódust külön ellenőrizze, ahogyan fent is látható, ha csak a látható címkéket szeretné kinyerni.

## **Adatcímkék kezelése a tengely maximumán túl**

Ha kézzel korlátozza a tengely tartományt, egyes adatpontok meghaladhatják a maximumot. Használja a [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) metódust annak szabályozására, hogy a címkék megjelenjenek-e. Ez a beállítás a címkék láthatóságát módosítja; nem változtatja meg a tengely tartományát vagy az alapadatok értékeit.

Az alábbi példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. `false` értéket ad a [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) metódusnak, és a függőleges tengelyen a [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) metódussal 100-ra állítja a maximumot. Az első dia megengedi a címkék megjelenését a maximumon túl; egy másolat letiltja ezeket. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlban van mentve.

Az értékcímkéket a [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) metódussal engedélyezheti. A diagram szintű beállítás önmagában nem teszi láthatóvá az értékek megjelenítését, és nem írja felül egy adott címke letiltott értékmegjelenítését. Ez a példa a teljes sorozatra engedélyezi az értékeket, és a [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) metódussal a címkéket az egyes oszlopok külső végére helyezi.

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

Az alábbi képek a Microsoft PowerPoint által renderelt mentett diákat mutatják. `true` esetén a **120** címke látható a felső határnál; `false` esetén rejtve marad. A **60** címke továbbra is látható, a tengely maximuma **100** marad, és a második adatpont **120** marad mindkét esetben.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Diagram típusa" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az értéktengellyel nem rendelkező diagramok, például a kör- és a gyűrűdiagramok, nem rendelkeznek tengelymaximumszéggel, amelyet így korlátozni lehetne.
{{% /alert %}}

## **Címke távolság beállítása a tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) metódust a kategóriatengely címkéi és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéket érinti, nem pedig az egyes adatpontokhoz csatolt címkéket.

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

## **Címke helyének igazítása**

Kördiagramon állítsa be az adatcímkék pozícióját a távolság javítása és a vezetővonalak számára hely biztosítása érdekében.

Ez a példa az első adatpont értékét jeleníti meg, a címkéjét a szelet kívülre helyezi, és a [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) és [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) metódusokkal állítja be a vízszintes és függőleges eltolást. Ezek az eltolások a diagram szélességéhez és magasságához viszonyulnak.

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

![Kördiagram a módosított adatcímke pozícióval](pie-chart-adjusted-label.png)

## **Több sor adatcímke hozzáadása az oszlopdiagram fölé**

Ez a példa egy oszlopdiagramot hoz létre, amely a plot terület felett két sor adatcímkét tartalmaz. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok további címkéket biztosítanak. Az ő oszlopaikat a kitöltés és a körvonal eltávolításával rejtik el. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) metódus az összes három sorozatot azonos kategória középponttal igazítja.

A [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) beállítások helyet biztosítanak a címkesoroknak. A [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) meghatározza az alapértelmezett pozíciókat, majd a [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) megőrzi a vízszintes igazítást és függőleges eltolásokat alkalmaz a címkék két sorba rendezéséhez. A számok továbbra is sorozatértékekhez kapcsolt adatcímkék maradnak; csak a sorfejlécek külön szövegtárgyak.

```java
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
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // Rejtse el a B és C oszlopokat, de tartsa meg az adatelőjelcímkéket.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // Igazítsa a három sorozatot ugyanazon kategóriaközéppontokkal.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // Használjon kevesebb rácsvonalat ebben a kompakt példában.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Tartson helyet a plot felett két sor adatcímkének.
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
            // Tartsa meg az alapértelmezett vízszintes pozíciót. Y egy eltolás a
            // az alapértelmezett címkepozíciótól, diagrammagasság hányadékaként kifejezve.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Csak a sorfejléc egy külön szövegtárgy.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hogyan akadályozhatom meg az adatcímkék átfedését sűrű diagramoknál?**

Kombináljon automatikus címkeelhelyezést, vezetővonalakat és csökkentett betűméretet; szükség esetén rejtse el egyes mezőket (például a kategóriát), vagy csak a szélsőséges értékek vagy kulcspontok esetén jelenítse meg a címkéket.

**Hogyan tilthatom le a címkéket csak a nulla, negatív vagy üres értékeknél?**

Szűrje le az adatpontokat a címkék engedélyezése előtt, és a meghatározott szabály szerint tiltsa le a 0, negatív vagy hiányzó értékek megjelenítését.

**Hogyan biztosíthatom a címkestílus következetességét PDF/képek exportálásakor?**

Állítsa be kifeexplicit a betűcsaládot és a méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelési környezetben, hogy elkerülje a helyettesítést.