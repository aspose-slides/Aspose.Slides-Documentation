---
title: Beheer diagram-gegevenslabels in presentaties op Android
linktitle: Gegevenslabel
type: docs
url: /nl/androidjava/chart-data-label/
keywords:
- diagram
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u diagram-gegevenslabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor Android via Java voor meer boeiende dia's."
---
## **Introductie**

Gegevenslabels tonen informatie over diagramreeksen en individuele gegevenspunten, waardoor lezers waarden kunnen identificeren en het diagram beter begrijpen. Dit artikel legt uit hoe u waarden formatteert, percentages weergeeft, labeltekst leest, labels buiten de as‑maximum beheert, de spreiding van categorie‑as‑labels aanpast en taartdiagram‑labels positioneert.

## **Aantal zichtbare gegevenslabels**

Gebruik [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getCountOfVisibleDataLabels--) om te controleren hoeveel gegevenslabels zijn ingeschakeld voor weergave vóór het publiceren van een presentatie. In tegenstelling tot [getCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getCount--), dat het totale aantal labels in de collectie retourneert, houdt het rekening met de standaardinstellingen van de reeks en de individuele labelinstellingen.

Dit voorbeeld maakt een kolomdiagram met één reeks en drie gegevenspunten. Het benadert de labelcollectie van de reeks via [getLabels](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getLabels--) en drukt het zichtbare aantal af terwijl de instellingen veranderen: **0, 3, 2, 3**. Het totale aantal blijft **3**.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesCell = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

    for (int i = 0; i < 3; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IDataLabelCollection labels = series.getLabels();
    System.out.println("Total: " + labels.getCount() + "; visible: " + labels.getCountOfVisibleDataLabels()); // Totaal: 3; zichtbaar: 0

    labels.getDefaultDataLabelFormat().setShowValue(true);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // Zichtbaar: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(false);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // Zichtbaar: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(true);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // Zichtbaar: 3
} finally {
    presentation.dispose();
}
```

De reeks' [getDefaultDataLabelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getDefaultDataLabelFormat--) levert de standaardinstellingen. Het doorgeven van `true` aan [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) toont waarden voor alle drie de labels. Het doorgeven van `false` via de [getDataLabelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getDataLabelFormat--) van één label overschrijft die instelling voor het geselecteerde label. Het doorgeven van `true` aan [setShowLegendKey](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowLegendKey-boolean-) zorgt ervoor dat dat label weer als zichtbaar wordt geteld, zelfs al blijft de waarde verborgen.

Het zichtbare aantal weerspiegelt de zichtbaarheidinstellingen. Het meet niet of labels overlappen, worden afgesneden of leesbaar zijn in het gerenderde diagram.

## **Gegevensprecisie instellen in diagramgegevenslabels**

Gebruik [setNumberFormatOfValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) om de waarden van een reeks te formatteren. Dit voorbeeld maakt een lijndiagram met standaardgegevens, toont de gegevenstabel en schakelt waarde‑labels in voor de eerste reeks. Het formaat `#,##0.00` toont een duizendtal‑scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

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

Om de numerieke cellen in een ingebed werkboek van een diagram te formatteren, zie [Set Custom Number Formats for Workbook Cells](/slides/nl/androidjava/chart-workbook/#set-custom-number-formats-for-workbook-cells). Dat voorbeeld toont ook waarde‑labels die de opmaak van hun broncellen volgen, terwijl de opgeslagen numerieke waarden behouden blijven.

## **Percentages weergeven als labels**

Voor een gestapeld kolomdiagram berekent u elke waarde als een percentage van de totalsom van de categorie en kent u de tekst toe aan het tekstraam dat wordt geretourneerd door [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Dit voorbeeld gebruikt de standaard diagramgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaalsom van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de diagramgegevens wijzigen.

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

## **Het procentteken instellen met diagramgegevenslabels**

Wanneer waarden als breuken worden opgeslagen, gebruik [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) om percentages weer te geven. Geef `false` door aan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) om het labelformaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapeld kolomdiagram met rode en blauwe reeksen over vier categorieën. Elk waardepaar telt op tot 1. Het labelformaat `0.0%` toont 0,30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte, 10‑punts labeltekst.

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

## **De werkelijke tekst van gegevenslabels lezen**

Gebruik [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) om de tekst op te halen die door de instellingen van een gegevenslabel wordt geproduceerd. Dit is nuttig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie‑inhoud, of het valideren van gegenereerde diagrammen. In het onderstaande voorbeeld combineert het standaard [data label format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/) de naam van elke categorie, de reeksnamen en de waarde. Eén punt formatteert zijn waarde als percentage, en een andere gebruikt aangepaste tekst uit [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

Het in een gegevenspunt opgeslagen getal blijft `0.75`, zelfs wanneer het label `75 %` toont samen met de categorie‑ en reeksnamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) retourneert de resulterende labelreeks in beide gevallen. Controleer [isVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#isVisible--) apart, zoals hierboven getoond, wanneer u alleen zichtbare labels wilt extraheren.

## **Gegevenslabels beheren buiten de as‑maximum**

Wanneer u handmatig een asbereik beperkt, kunnen sommige gegevenspunten de maximumwaarde overschrijden. Gebruik [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) om te bepalen of hun gegevenslabels worden getoond. Deze instelling wijzigt de zichtbaarheid van het label; het verandert niet het asbereik of de onderliggende gegevenswaarden.

Het onderstaande voorbeeld maakt een 2D gegroepeerd kolomdiagram met waarden van 60 en 120. Het geeft `false` door aan [setAutomaticMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) en stelt het maximum in op 100 met [setMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) op de verticale as. De eerste dia staat labels toe die het maximum overschrijden; een kopie van die dia schakelt ze uit. Beide dia's worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waarde‑labels in met [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). De instelling op diagramniveau activeert de weergave van waarden niet op zichzelf of overschrijft niet de uitgeschakelde weergave van een individueel label. Dit voorbeeld schakelt waarden in voor de hele reeks en gebruikt [setPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) om de labels aan het buitenste einde van elke kolom te plaatsen.

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

De volgende afbeeldingen tonen de opgeslagen dia's, gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar bij de bovenste grens; met `false` is het verborgen. Het label **60** blijft zichtbaar, het as‑maximum blijft **100**, en het tweede gegevenspunt blijft **120** in beide gevallen.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint-diagram dat het waardelabel 120 toont met een as‑maximum van 100](data-labels-over-maximum-true.png) | ![PowerPoint-diagram dat het waardelabel 120 verbergt met een as‑maximum van 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Grafiektype" %}}
Dit voorbeeld gebruikt een 2D kolomdiagram met een waardenas. Diagrammen zonder waardenas, zoals taart‑ en donut‑diagrammen, hebben geen as‑maximum dat op deze manier kan worden beperkt.
{{% /alert %}}

## **Labelafstand van een as instellen**

Gebruik [setLabelOffset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) om de afstand tussen categorie‑as‑labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerd kolomdiagram en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt categorie‑as‑labels in plaats van labels die aan individuele gegevenspunten zijn gekoppeld.

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

Bij een taartdiagram past u de positie van gegevenslabels aan om de spatiëring te verbeteren en ruimte te maken voor verbindingslijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten de part, en past de horizontale en verticale offset aan met behulp van [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) en [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-). Deze offsets zijn respectievelijk relatief ten opzichte van de breedte en hoogte van het diagram.

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

![Taartdiagram met een aangepaste labelpositie](pie-chart-adjusted-label.png)

## **Leidlijnen opmaken**

Wanneer taartdiagram‑labels buiten hun partjes staan, helpen leidlijnen lezers elke waarde aan het juiste partje te koppelen. Een contrasterende kleur en een iets dikkere lijn kunnen deze verbindingen makkelijker leesbaar maken, terwijl transparantie en een gestippelde stijl de lijnen visueel onopvallend houden.

Gebruik [getLeaderLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) om leider‑lijnen op te maken op het niveau van de labelcollectie van de reeks. De instellingen in `series.getLabels().getLeaderLinesFormat().getLine()` gelden voor de collectie, niet voor een individueel label.

Dit voorbeeld maakt een taartdiagram met standaardgegevens, toont waarden buiten de partjes en schakelt [setShowLeaderLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-) in. Het verplaatst twee labels verder van hun partjes met behulp van [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) en [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) offsets, uitgedrukt als breuken van de diagrambreedte en -hoogte. Er is geen invoerpresentatie vereist.

De [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) van de lijn stelt een effen blauwe kleur in met een alfawaarde van 191 van 255, wat ongeveer 25 % transparantie geeft. [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) stelt de dikte in op 2 punten, en [setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) maakt de lijn gestippeld.

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

    // Verplaats twee labels verder weg van hun partjes.
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

Het inschakelen van leidlijnen garandeert niet dat er voor elk label een lijn verschijnt. De zichtbaarheid hangt af van de labelplaatsing en het layoutgedrag van het diagram. In dit voorbeeld hebben de twee verplaatste labels zichtbare leidlijnen; de labels die dicht bij hun partjes blijven, hebben ze niet nodig.

De volgende afbeelding toont het opgeslagen `FormattedLeaderLines.pptx` gerenderd met Aspose.Slides:

![Taartdiagram met blauwe, semitransparante gestippelde leidlijnen die twee buitenste labels met hun partjes verbinden](formatted-leader-lines.png)

## **Meerdere rijen gegevenslabels boven een kolomdiagram toevoegen**

Dit voorbeeld maakt een kolomdiagram met twee rijen gegevenslabels boven het plotgebied. Reeks A toont de zichtbare kolommen, terwijl reeksen B en C de extra labels leveren. Hun kolommen zijn verborgen door de vulling en omlijning te verwijderen. De methode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartseriesgroup/#setOverlap-byte-) stemt alle drie de reeksen af op dezelfde categorie‑centra.

De instellingen van [ChartPlotArea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartplotarea/) reserveren ruimte voor de labelrijen. Nadat [Chart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) de standaardposities heeft berekend, behouden [DataLabel.setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setX-float-) en [DataLabel.setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setY-float-) de horizontale uitlijning en passen ze verticale offsets toe om de labels in twee rijen te rangschikken. De cijfers blijven gegevenslabels die aan de reekswerwaarden gekoppeld zijn; alleen de rijnamen zijn aparte tekstvormen.

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
            // Verberg de kolommen van B en C, maar behoud hun gegevenslabels.
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

    // Lijn alle drie de reeksen uit op dezelfde categoriecentra.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap((byte) 100);

    // Gebruik minder rasterlijnen voor dit compacte voorbeeld.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Reserveer ruimte boven het plot voor twee rijen gegevenslabels.
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
            // Bewaar de standaard horizontale positie. Y is een offset ten opzichte van
            // de standaard labelpositie, uitgedrukt als een fractie van de diagramhoogte.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Alleen de rij‑kop is een apart tekstobject.
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

![Kolomdiagram met twee rijen gegevenslabels boven het plotgebied](multiple-rows-of-labels.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen in dichte diagrammen?**

Combineer automatische labelplaatsing, leidlijnen en een kleinere lettergrootte; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon labels alleen voor extreme waarden of belangrijke punten.

**Hoe kan ik labels alleen uitschakelen voor nul-, negatieve of lege waarden?**

Filter gegevenspunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl garanderen bij exporteren naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer of het lettertype beschikbaar is in de renderomgeving om terugval te voorkomen.