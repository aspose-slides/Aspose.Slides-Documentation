---
title: Beheer diagramdataplabels in presentaties met Java
linktitle: Dataplabel
type: docs
url: /nl/java/chart-data-label/
keywords:
- diagram
- dataplabel
- gegevensprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u diagramdataplabels toevoegt en formatteert in PowerPoint-presentaties met Aspose.Slides voor Java voor meer boeiende dia's."
---
## **Inleiding**

Gegevenslabels tonen informatie over diagramreeksen en individuele datapunten, waardoor lezers waarden kunnen identificeren en het diagram beter kunnen begrijpen. Dit artikel legt uit hoe u waarden formatteert, percentages weergeeft, labeltekst leest, labels buiten het asmaximum beheert, de afstand tussen categorie-as‑labels aanpast en labels in een taartdiagram positioneert.

## **Instellen van gegevensprecisie in diagram‑dataplabels**

Gebruik [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) om reeksenwaarden te formatteren. Dit voorbeeld maakt een lijndiagram met standaardgegevens, toont de gegevenstabel en activeert waardelabels voor de eerste reeks. Het formaat `#,##0.00` toont een duizendtallen‑scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

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

## **Percentage weergeven als labels**

Voor een gestapeld kolomdiagram berekent u elke waarde als percentage van het totaal van de categorie en kent u de tekst toe aan het tekstframe dat wordt geretourneerd door [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Dit voorbeeld gebruikt de standaard diagramgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst indien de diagramgegevens wijzigen.

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

## **Instellen van percentage‑teken met diagram‑dataplabels**

Wanneer waarden zijn opgeslagen als breuken, gebruikt u [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) om percentages weer te geven. Geef `false` door aan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) om het labelformaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapeld kolomdiagram met rode en blauwe reeksen over vier categorieën. Elk paar waarden telt op tot 1. Het labelformaat `0.0%` toont 0,30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte labeltekst van 10 punten.

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

## **Lees de feitelijke tekst van dataplabels**

Gebruik [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) om de tekst op te halen die door de instellingen van een dataplabel wordt gegenereerd. Dit is nuttig bij het extraheren van labels voor rapporten, het doorzoeken van presentaties, of het valideren van gegenereerde diagrammen. In het onderstaande voorbeeld combineert het standaard [data‑label‑formaat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) elke categorienaam, reeksennaam en waarde. Eén punt formatteert zijn waarde als percentage, en een ander gebruikt aangepaste tekst van [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

Het in een datapunt opgeslagen getal blijft `0.75`, zelfs wanneer het label `75 %` weergeeft samen met de categorie‑ en reeksenamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) retourneert de resulterende labelreeks in beide gevallen. Controleer [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) apart, zoals hierboven getoond, wanneer u uitsluitend zichtbare labels wilt extraheren.

## **Dataplabels buiten het asmaximum beheren**

Wanneer u handmatig een asbereik beperkt, kunnen sommige datapunten de maximale waarde overschrijden. Gebruik [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) om te bepalen of hun dataplabels worden getoond. Deze instelling wijzigt de zichtbaarheid van labels; ze verandert het asbereik of de onderliggende gegevenswaarden niet.

Het onderstaande voorbeeld maakt een 2D gegroepeerd kolomdiagram met waarden van 60 en 120. Het geeft `false` door aan [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) en stelt het maximum in op 100 met [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) op de verticale as. De eerste dia staat labels buiten het maximum toe; een kopie van die dia schakelt ze uit. Beide dia's worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waardelabels in met [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). De diagram‑instelling schakelt de weergave van waarden niet automatisch in, noch overschrijft zij een individueel label dat de weergave van waarden heeft uitgeschakeld. Dit voorbeeld activeert waarden voor de volledige reeks en gebruikt [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) om labels aan het buitenkant‑einde van elke kolom te plaatsen.

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

De volgende afbeeldingen tonen de opgeslagen dia's zoals gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar aan de bovenste grens; met `false` is het verborgen. Het label **60** blijft zichtbaar, het asmaximum blijft **100**, en het tweede datapunt blijft **120** in beide gevallen.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld gebruikt een 2D kolomdiagram met een waardenas. Diagrammen zonder waardenas, zoals taart‑ en donutdiagrammen, hebben geen asmaximum dat op deze manier kan worden beperkt.
{{% /alert %}}

## **Labelafstand van een as instellen**

Gebruik [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) om de afstand tussen categorie‑as‑labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerd kolomdiagram en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt de categorie‑as‑labels in plaats van labels die aan individuele datapunten zijn gekoppeld.

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

## **Labelpositie aanpassen**

In een taartdiagram past u de posities van dataplabels aan om de afstand te verbeteren en ruimte te maken voor verbindingslijnen.

Dit voorbeeld toont de waarde van het eerste datapunt, plaatst het label buiten het segment en past de horizontale en verticale offset aan met behulp van [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) en [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). Deze offsets zijn respectievelijk relatief ten opzichte van de diagram‑breedte en -hoogte.

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

![Taartdiagram met een aangepaste dataplabelpositie](pie-chart-adjusted-label.png)

## **Meerdere rijen dataplabels boven een kolomdiagram toevoegen**

Dit voorbeeld maakt een kolomdiagram met twee rijen dataplabels boven het plotgebied. Reeks A toont de zichtbare kolommen, terwijl Reeks B en Reeks C de extra labels leveren. Hun kolommen worden verborgen door de vulling en omtrek te verwijderen. De methode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) aligneert alle drie reeksen met dezelfde categoriebenen.

De instellingen van [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) reserveren ruimte voor de labelrijen. Na het berekenen van de standaardposities door [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) behouden [DataLabel.setX en DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) de horizontale uitlijning en passen ze verticale offsets toe om de labels in twee rijen te rangschikken. De cijfers blijven dataplabels gekoppeld aan de reeksenwaarden; alleen de rij‑koppen zijn afzonderlijke tekstvormen.

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
            // Verberg de kolommen van B en C, maar behoud hun dataplabels.
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

    // Lijn alle drie de reeksen uit op dezelfde categoriebenen.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // Gebruik minder rasterlijnen voor dit compacte voorbeeld.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Reserveer ruimte boven de plot voor twee rijen dataplabels.
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
            // Behoud de standaard horizontale positie. Y is een offset ten opzichte van
            // de standaard labelpositie, uitgedrukt als een fractie van de diagramhoogte.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Alleen de rij‑kop is een apart tekstobject.
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

**Hoe kan ik voorkomen dat dataplabels overlappen in dichte diagrammen?**

Combineer automatische labelplaatsing, verbindingslijnen en een verkleinde lettergrootte; indien nodig verberg enkele velden (bijvoorbeeld de categorie) of toon alleen labels voor extreme waarden of belangrijke punten.

**Hoe kan ik labels alleen uitschakelen voor nul-, negatieve of lege waarden?**

Filter datapunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl waarborgen bij exporteren naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer dat het lettertype beschikbaar is in de renderomgeving om fallback te voorkomen.