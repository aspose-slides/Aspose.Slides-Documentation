---
title: "Pas cirkeldiagrammen aan in presentaties met Java"
linktitle: "Cirkeldiagram"
type: docs
url: /nl/java/pie-chart/
keywords:
- "cirkeldiagram"
- "diagram beheren"
- "diagram aanpassen"
- "diagramopties"
- "diagraminstellingen"
- "plotopties"
- "segmentkleur"
- "PowerPoint"
- "presentatie"
- "Java"
- "Aspose.Slides"
description: "Maak en pas cirkeldiagrammen aan in Java met Aspose.Slides. Configureer secundaire plotten, toon gegevenslabels en pas automatische segmentkleuren toe in PowerPoint."
---
## **Overzicht**

Dit artikel legt uit hoe je met cirkeldiagrammen in Aspose.Slides werkt. Het laat zien hoe je secundaire plotopties configureert voor Pie of Pie- en Bar of Pie-diagrammen, en hoe je automatische kleuring van segmenten inschakelt voor een standaard cirkeldiagram.

## **Secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen**

Aspose.Slides for Java ondersteunt secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen. Deze opties bepalen de grootte van de secundaire plot en hoe datapunten tussen de twee plotten worden verdeeld.

Het volgende voorbeeld maakt een Pie of Pie-diagram in een nieuwe presentatie en geeft de waarden van datapunten weer als labels. De [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) methode stelt de grootte van de secundaire plot in op 149% van de hoofdplot. [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) kiest procentgebaseerde splitsing, en [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) stelt de drempel in op 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Geef waarden weer en configureer de secundaire plot.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Selecteer categorieën voor de secundaire plot**

Gebruik aangepaste splitsing wanneer je specifieke categorieën in de secundaire plot wilt groeperen, ongeacht hun percentages. Bijvoorbeeld, een verkooprapport kan Online en Evenementen samen tonen zodat lezers deze twee kanalen kunnen vergelijken, ook al vormen ze 35% en 10% van de totale verkoop.

Roep [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) aan met [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) en selecteer de punten via [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). De [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) methode van de collectie accepteert een nulgebaseerde index in de serie; gebruik [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) om een datapuntobject toe te voegen. In dit voorbeeld selecteert index 1 Online, en index 3 Evenementen. Partners wordt tijdelijk toegevoegd en daarna verwijderd met [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Vervang de standaardgegevens door verkoop per kanaal.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Selecteer Online via zijn nulgebaseerde index en Events via zijn datapuntenobject.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Sluit Partners uit de selectie zonder de brongegevens te verwijderen.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) en Evenementen (10) verschijnen als afzonderlijke segmenten in de secundaire plot. In de primaire plot worden ze weergegeven door één gecombineerd segment met een waarde van 45, samen met Retail (40) en Partners (15). Het verwijderen van Partners uit de aangepaste selectie houdt het in de primaire plot; het verwijdert de categorie of de waarde niet uit de brongegevens van het diagram.

De volgende afbeelding toont de opgeslagen presentatie in PowerPoint:

![Pie of Pie-diagram met Online en Evenementen in de secundaire plot en hun gecombineerde waarde van 45 in de primaire plot](pie_of_pie_custom.png)

## **Automatische kleuren voor cirkeldiagramsegmenten instellen**

Aspose.Slides for Java kan automatisch verschillende kleuren toewijzen aan cirkeldiagramsegmenten. Het volgende voorbeeld maakt een cirkeldiagram met een gecentreerde titel en vervangt de standaardgegevens door drie kwartaalcategorieën en hun waarden. De [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) methode toont de waarden 20, 50 en 30 als labels, terwijl [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) een onderscheiden kleur voor elk segment inschakelt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Voeg een gecentreerde diagramtitel toe.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Vervang de standaardgegevens met het eerste werkblad.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Toon waarden en wijs verschillende kleuren toe aan de segmenten.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Worden de Pie of Pie- en Bar of Pie-varianten ondersteund?**

Ja, de bibliotheek [supports](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de Pie of Pie- en Bar of Pie-types.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, je kunt [export the chart itself as an image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (bijvoorbeeld PNG) zonder de volledige presentatie te exporteren.