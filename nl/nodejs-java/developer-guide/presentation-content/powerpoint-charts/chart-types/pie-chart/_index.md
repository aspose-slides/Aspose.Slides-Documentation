---
title: Aangepaste taartdiagrammen in presentaties met JavaScript
linktitle: Taartdiagram
type: docs
url: /nl/nodejs-java/pie-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas taartdiagrammen aan in JavaScript met Aspose.Slides voor Node.js via Java. Configureer secundaire plots, toon gegevenslabels en pas automatische segmentkleuren toe in PowerPoint."
---
## **Overzicht**

Dit artikel legt uit hoe u werkt met taartdiagrammen in Aspose.Slides. Het laat zien hoe u secundaire plotopties kunt configureren voor Pie of Pie- en Bar of Pie-diagrammen, en hoe u automatische kleuring van segmenten kunt inschakelen voor een standaard taartdiagram.

De voorbeelden richten zich op taken voor het aanpassen van diagrammen, zoals het toevoegen van een diagram aan een dia, het aanpassen van series‑ en labelinstellingen, het vervangen van standaarddiagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Opties voor secundaire plot voor Pie of Pie- en Bar of Pie-diagrammen**

Aspose.Slides for Node.js via Java ondersteunt secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen. Deze opties bepalen de grootte van de secundaire plot en hoe gegevenspunten worden verdeeld tussen de twee plots.

Het volgende voorbeeld maakt een Pie of Pie-diagram in een nieuwe presentatie en toont de waarden van gegevenspunten als labels. De [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize)‑methode stelt de grootte van de secundaire plot in op 149 % van de hoofdplot. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) selecteert percentage‑gebaseerde splitsing, en [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) stelt de drempel in op 53 %.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Waarden weergeven en de secundaire plot configureren.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Selecteer categorieën voor de secundaire plot**

Gebruik aangepaste splitsing wanneer u specifieke categorieën in de secundaire plot wilt groeperen, ongeacht hun percentagewaarden. Bijvoorbeeld, een verkooprapport kan Online en Events samen tonen zodat lezers deze twee kanalen kunnen vergelijken, hoewel ze respectievelijk 35 % en 10 % van de totale omzet uitmaken.

Roep [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) aan met [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) en selecteer de punten via [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). De [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add)‑methode van de verzameling accepteert een nul‑gebaseerde index in de serie; gebruik [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) om een gegevenspuntobject toe te voegen. In dit voorbeeld selecteert index 1 Online en selecteert het punt op index 3 Events. Partners wordt ook tijdelijk toegevoegd, vervolgens verwijderd met [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Vervang de standaardgegevens door verkoop per kanaal.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Selecteer Online op basis van zijn nulgebaseerde index en Events op basis van zijn gegevenspuntobject.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Sluit Partners uit de selectie zonder de brongegevens te verwijderen.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) en Events (10) verschijnen als afzonderlijke segmenten in de secundaire plot. In de primaire plot worden ze weergegeven als één gecombineerd segment met een waarde van 45, naast Retail (40) en Partners (15). Het verwijderen van Partners uit de aangepaste selectie houdt het segment in de primaire plot; het verwijdert de categorie of diens waarde niet uit de brongegevens van het diagram.

De volgende afbeelding toont de opgeslagen presentatie in PowerPoint:

![Pie of Pie-diagram met Online en Events in de secundaire plot en hun gecombineerde waarde van 45 in de primaire plot](pie_of_pie_custom.png)

## **Stel automatische kleuren voor taartdiagramsegmenten in**

Aspose.Slides for Node.js via Java kan automatisch verschillende kleuren toewijzen aan segmenten van een taartdiagram. Het volgende voorbeeld maakt een taartdiagram met een gecentreerde titel en vervangt de standaardgegevens door drie kwartaalcategorieën en hun waarden. De [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue)‑methode toont de waarden 20, 50 en 30 als labels, terwijl [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) een aparte kleur voor elk segment inschakelt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Voeg een gecentreerde diagramtitel toe.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Vervang de standaardgegevens met het eerste werkblad.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Toon waarden en wijs verschillende kleuren toe aan de segmenten.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wordt de Pie of Pie- en Bar of Pie-variant ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) een secundaire plot voor taartdiagrammen, inclusief de Pie of Pie- en Bar of Pie-typen.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt [exporteer het diagram zelf als afbeelding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (bijvoorbeeld PNG) zonder de volledige presentatie te exporteren.