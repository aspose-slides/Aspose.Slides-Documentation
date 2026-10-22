---
title: Beheer grafiekseries in presentaties met JavaScript
linktitle: Dataseries
type: docs
url: /nl/nodejs-java/chart-series/
keywords:
- grafiekseries
- seriesoverlap
- serieskleur
- serienaam
- datapunt
- werkboekcel
- seriesgat
- negatieve waarde
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u grafiekseries, datapunten, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met JavaScript."
---
## **Overzicht**

Een grafiek kan zijn weergegeven waarden opslaan in werkboekcellen of rechtstreeks als numerieke literalwaarden. Een [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elke [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) vertegenwoordigt een punt in die serie. [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/)‑objecten leveren de labels of groepeerwaarden die door de series worden gedeeld. In grafieken die met standaardgegevens zijn gemaakt, gebruiken serie‑namen, categorieën en puntwaarden [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/)‑objecten uit het grafiekwerkboek.

Voor een typische categoriegrafiek gebruikt het standaardwerkboek rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor seriewaarden. Werkblad‑, rij‑ en kolomindexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is nuttig wanneer u een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek dit gebruikt. Voor een geladen presentatie inspecteert u de cellen die door de series, categorieën en datapunten worden gerefereerd voordat u werkboekwaarden wijzigt.

Grafiek‑instellingen hebben drie verschillende reikwijdtes:

- Instellingen op serieniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), bieden de standaardweergave voor alle punten in één serie.
- Instellingen voor datapunten, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), overschrijven de serie‑weergave voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele series die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) behoren. Toegang tot de groep via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) wanneer u opties zoals overlap of gatbreedte moet instellen.

Wanneer geen expliciete punt‑ of serie‑vulling is ingesteld, bepalen het grafiek‑stijl en thema de automatische weergave. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Stel serie‑waarden in met numerieke literalwaarden**

Gebruik numerieke literalwaarden wanneer seriewaarden afkomstig zijn van applicatie‑gegevens of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Roep [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) aan met [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) voordat u het resultaat van elke punt‑[getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) toewijst via [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Collectie‑instelling bepaalt het brontype van alle puntwaarden in die serie. Elke puntwaarde‑[getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) methode rapporteert het geselecteerde type; wijzig het via de collectie‑instelling. Met `Worksheet` gebruikt u [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) om de gerefereerde cel te benaderen. Met `DoubleLiterals` gebruikt u [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) of `setAsLiteralDouble` om het getal direct te lezen of te schrijven.

Het volgende voorbeeld maakt een staafgrafiek met standaard series en categorieën, en kent vervolgens berekende waarden van 10, 20, enzovoort toe aan de bestaande punten van de eerste serie. Het slaat de presentatie op, opent deze opnieuw, en drukt de opgeslagen waarden af.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Het puntwaarde‑brontype staat los van [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), dat de interne of externe werkboekconfiguratie van de grafiek identificeert. Het gebruik van numerieke literalwaarden verwijdert op zich niet het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, serienamen en de andere series. Zie [Grafiekwerkboek](/slides/nl/nodejs-java/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbelgrafieken gebruikt u [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) en [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) om de bronnen voor [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) en [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/) te kiezen. Bubbelgrafieken gebruiken ook [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) voor [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). Stel elke toepasselijke bron in op `DoubleLiterals` voordat u getallen toewijst via de `setAsLiteralDouble`‑methode van die waarde.

## **Stel de overlap van de grafiekserie in**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) rapporteert hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende serie‑groep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op grafiektype­n die gegroepeerde balken of kolommen tonen; hij heeft geen invloed op niet‑gerelateerde serie‑groepen in een combinatiegrafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste serie bevat:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // De nieuwe grafiek bevat voorbeeldseries, categorieën en waarden.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The series overlap](series_overlap.png)

## **Wijzig de vulkleur van de serie**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) om de standaardvulling voor een volledige serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/)‑instelling de serie‑vulling voor dat punt.

Het volgende voorbeeld past een egale blauwe vulling toe op de eerste serie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The color of the series](series_color.png)

## **Wijzig de serienaam**

Een serienaam wordt opgeslagen in het grafiek‑werkboek en normaal weergegeven in de legenda. In het standaardwerkboek dat voor een gegroepeerde staafgrafiek wordt aangemaakt, bevindt zich cel B1 op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

U kunt ook de cel bijwerken die al wordt gerefereerd door [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/). Deze aanpak voorkomt aannames over een specifieke rij en kolom in een bestaande grafiek:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The series name](series_name.png)

### **Maak een serie met een naam uit meerdere cellen**

Een samengestelde serienaam is nuttig wanneer een productnaam en een rapportageperiode in afzonderlijke werkboekcellen zijn opgeslagen. U kunt bijvoorbeeld `Product A` in B1 en `2026` in C1 combineren tot één serienaam terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) om het naam‑bereik op te halen, en geef dat bereik vervolgens door aan [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één serie en twee datapunten. Cell­len B1:C1 leveren alleen de serienaam; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Deze twee cellen leveren de serienaam.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Aparte cellen leveren de categorieën en numerieke datapunten.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De resulterende serienaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één invoer voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Haal de automatische vulkleur van de serie op**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) retourneert de kleur die is berekend op basis van de serie‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de serie‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur van elke standaardserie af:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Stel omgekeerde vulkleur in voor een grafiekserie**

Voor balk‑, kolom‑ en bubbel‑series kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) negatieve waarden weergeven met een andere vulling. Stel de reguliere serie‑vulling in op een egale kleur, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één serie. Werkblad rij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde toegewezen zodat het effect zichtbaar is:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wis een specifieke datapuntenwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een staafgrafiek is de weergegeven waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). Het datumpunt blijft op dezelfde categoriepositie, maar de grafiek behandelt zijn waarde als leeg volgens de instelling voor lege waarden van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt in de eerste serie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Spreidingsgrafieken gebruiken afzonderlijke X‑ en Y‑cellen, en bubbelgrafieken gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep niet [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datumpunt uit de collectie.

## **Beheer de weergave van lege cellen**

Verborgen cellen die waarden bevatten vormen een afzonderlijk geval ten opzichte van lege cellen. Zie [Gegevens van verborgen rijen en kolommen opnemen](/slides/nl/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) voor het opnemen of uitsluiten van gegevens uit verborgen werkbladrijen en -kolommen.

Een lege werkboekcel staat voor ontbrekende data; een cel met `0` staat voor een bekende numerieke waarde. Roep [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) aan met `null` om een cel leeg te maken. Een numeriek nul blijft nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Hij verandert hoe leegtes worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelf‑containende voorbeeld maakt een lijngrafiek met één serie, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand vereist. De [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke data is `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Laat Dag 3 echt leeg, terwijl de categorie en het datapunt behouden blijven.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Elke uitvoer‑bestand slaat de vóór het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs de gewenste modus toe en sla de presentatie eenmalig op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi eenvoudig te vergelijken. Balk‑ en kolomgrafieken hebben geen lijn om een ontbrekende categorie te verbinden, dus `Span` kan het verbindingssegment niet produceren; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook vergelijkbaar uitzien. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet drie afzonderlijke resultaten voor elk grafiektype; controleer de uitvoer voor het type dat u gebruikt.

## **Stel de gatbreedte van de serie in**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende serie‑groep in plaats van tot één serie. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) eenmalig voor de groep aan. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de uiteindelijke presentatie op:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![The gap width](gap_width.png)

## **FAQ**

**Welke grafiektype ondersteunen dataseries?**

Alle grafiektype‑n die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑enumeratie gebruiken grafiek‑data, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriegrafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de datapunten‑creatiemethode die past bij het serietype. Opties zoals overlap en gatbreedte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een grafiekserie‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, verandert niet noodzakelijkerwijs elke serie in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) voorbeeld‑series, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de serie‑ als de categoricollecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens aanmaken.

**Hoe zijn grafiekobjecten verbonden met werkboekcellen?**

Serienamen, categorielabels en datapunten‑waarden refereren naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste data bouwt, houdt u categorie‑rijen en seriewaarde‑rijen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe kan ik één punt wissen in plaats van de hele serie?**

Stel de relevante waarde‑cel in op `null` om de punt‑categoriepositie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) alleen wanneer u alle punten uit die serie wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden uitgelijnd blijven met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de waarde die is geconfigureerd via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). Ondersteunde grafieken kunnen leegtes weergeven als gaten, als nul‑waarden, of door aangrenzende punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende data in uw presentatie. Zie [Beheer de weergave van lege cellen](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series roept u [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) aan en stelt u de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Deze methoden beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datumpunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal series dat een grafiek kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal series. In de praktijk bepalen bestands‑beperkingen van de presentatie, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) aan op de juiste bovenliggende serie‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.