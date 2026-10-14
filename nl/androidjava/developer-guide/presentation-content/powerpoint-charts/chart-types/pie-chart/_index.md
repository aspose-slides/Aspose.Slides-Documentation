---
title: "Pas taartdiagrammen aan in presentaties op Android"
linktitle: "Taartdiagram"
type: docs
url: /nl/androidjava/pie-chart/
keywords:
- taartdiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en pas taartdiagrammen aan op Android met Aspose.Slides for Android via Java. Configureer secundaire plots, geef gegevenslabels weer en pas automatische segmentkleuren toe in PowerPoint."
---
## **Overzicht**

Dit artikel legt uit hoe u werkt met taartdiagrammen in Aspose.Slides. Het laat zien hoe u secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen kunt configureren en hoe u automatische kleuring van taartpunten voor een standaard taartdiagram kunt inschakelen.

De voorbeelden richten zich op taken voor het aanpassen van diagrammen, zoals een diagram aan een dia toevoegen, series‑ en labelinstellingen aanpassen, standaard diagramgegevens vervangen door aangepaste categorieën en waarden, en de bijgewerkte presentatie opslaan.

## **Secundaire plotopties voor Pie of Pie‑ en Bar of Pie‑diagrammen**

Aspose.Slides for Android via Java ondersteunt secundaire plotopties voor Pie of Pie‑ en Bar of Pie‑diagrammen. Deze opties bepalen de grootte van de secundaire plot en hoe gegevenspunten tussen de twee plots worden verdeeld.

Het volgende voorbeeld maakt een Pie of Pie‑diagram in een nieuwe presentatie en toont gegevenspuntwaarden als labels. De [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) methode stelt de grootte van de secundaire plot in op 149 % van de hoofdplot. [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) selecteert procentgebaseerde splitsing, en [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) stelt de drempel in op 53 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Waarden weergeven en de secundaire plot configureren.
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

Gebruik aangepaste splitsing wanneer u specifieke categorieën in de secundaire plot wilt groeperen, ongeacht hun procentwaarden. Een verkooprapport zou bijvoorbeeld Online en Events samen kunnen tonen zodat lezers deze twee kanalen kunnen vergelijken, ook al vertegenwoordigen ze 35 % en 10 % van de totale omzet.

Roep [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) aan met [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) en selecteer de punten via [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). De [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-)‑methode van de collectie accepteert een nul‑gebaseerde index in de serie; gebruik [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) om een gegevenspuntobject toe te voegen. In dit voorbeeld selecteert index 1 Online, en index 3 selecteert Events. Partners wordt ook tijdelijk toegevoegd en daarna uitgesloten met [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

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

    // Selecteer Online op basis van zijn nul-gebaseerde index en Events via zijn gegevenspuntobject.
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

Online (35) en Events (10) verschijnen als afzonderlijke delen in de secundaire plot. In de primaire plot worden ze weergegeven als één gecombineerd deel met een waarde van 45, naast Retail (40) en Partners (15). Het verwijderen van Partners uit de aangepaste selectie houdt het in de primaire plot; het verwijdert de categorie of de waarde niet uit de brongegevens van het diagram.

De volgende afbeelding toont de opgeslagen presentatie in PowerPoint:

![Pie of Pie-diagram met Online en Events in de secundaire plot en hun gecombineerde waarde van 45 in de primaire plot](pie_of_pie_custom.png)

## **Stel automatische kleuren voor taartdiagrampunten in**

Aspose.Slides for Android via Java kan automatisch verschillende kleuren toewijzen aan taartdiagrampunten. Het volgende voorbeeld maakt een taartdiagram met een gecentreerde titel en vervangt de standaardgegevens door drie kwartaalcategoriën en hun waarden. De [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) methode toont de waarden 20, 50 en 30 als labels, terwijl [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) een aparte kleur voor elk punt mogelijk maakt.

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

    // Vervang de standaardgegevens met gebruik van het eerste werkblad.
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

**Worden de varianten Pie of Pie en Bar of Pie ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) een secundaire plot voor taartdiagrammen, inclusief de typen Pie of Pie en Bar of Pie.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt [het diagram zelf exporteren als een afbeelding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (bijvoorbeeld PNG) zonder de volledige presentatie te exporteren.