---
title: Beheer diagramgegevensseries in presentaties met JavaScript
linktitle: Gegevensseries
type: docs
url: /nl/nodejs-java/chart-series/
keywords:
- diagramserie
- seriesoverlap
- serieskleur
- serienaam
- datapunt
- werkbladcel
- seriegap
- negatieve waarde
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u diagramseries, datapunten, werkbladcellen, opmaak, overlap, breedte van de ruimte en negatieve waarden in presentaties kunt beheren met JavaScript."
---
## **Overzicht**

Een diagram slaat zijn geplotte gegevens op in een chart‑data‑werkblad. Een [ChartSeries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/) vertegenwoordigt een set gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/) in de serie verwijst naar een of meer werkbladcellen. [ChartCategory](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartcategory/)-objecten leveren de labels of groeperingswaarden die door de series gedeeld worden. De serienaam, categorieën en puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/)-objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typisch categorie‑diagram gebruikt het standaard‑werkboek rij 0 voor serienamen, kolom 0 voor categorienamen en de overige cellen voor series‑waarden. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram het zo gebruikt. Voor een geladen presentatie dient u de cellen die door de series, categorieën en datapunten worden gerefereerd te inspecteren voordat u werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op serieniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getFormat), bepalen de standaarduiterlijk voor alle punten in één serie.
- Instellingen per datapunten, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getFormat), overschrijven de serie‑uiterlijk voor één punt.
- Groepsinstellingen gelden voor compatibele series die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseriesgroup/) behoren. Toegang tot de groep verkrijgt u via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer u opties moet instellen zoals overlap of breedte van de ruimte tussen series.

Wanneer er geen expliciete punt‑ of serie‑opvulling is ingesteld, bepalen de diagramstijl en het thema de automatische weergave. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![De overlap van de serie](series_overlap.png)

## **Stel de overlap van de diagramserie in**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getOverlap) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende series‑groep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele serie in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen weergeven; het beïnvloedt geen niet‑gerelateerde series‑groepen in een combinatie‑diagram.

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

Het resultaat:

![De overlap van de serie](series_overlap.png)

## **Wijzig de opvulkleur van de serie**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getFormat) om de standaardopvulling voor een volledige serie in te stellen. Als een punt al een expliciete opvulling heeft, overschrijft de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getFormat)-instelling de serie‑opvulling voor dat punt.

Het volgende voorbeeld past een effen blauwe opvulling toe op de eerste serie:

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

Het resultaat:

![De kleur van de serie](series_color.png)

## **Wijzig de serienaam**

Een serienaam wordt opgeslagen in het chart‑data‑werkboek en wordt normaal gesproken weergegeven in de legenda. In het standaard‑werkboek dat wordt aangemaakt voor een gegroepeerde kolomgrafiek, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [ChartSeries.getName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getName). Deze aanpak voorkomt dat u een specifieke rij en kolom in een bestaand diagram veronderstelt:

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

Het resultaat:

![De serienaam](series_name.png)

## **Haal de automatische opvulkleur van de serie op**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die berekend wordt op basis van de serie‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de serie‑opvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe opvulling toe.

Het volgende voorbeeld drukt de automatische kleur af van elke standaardserie:

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

Voorbeeldoutput voor de standaard diagramstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Stel omgekeerde opvulkleur in voor een diagramserie**

Voor balk‑, kolom‑ en bubble‑series kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere opvulling weergeven. Stel de gewone serie‑opvulling in op effen, schakel inversie in, en wijs de kleur voor negatieve waarden toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard chart‑data door één serie. Werkblad‑rij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

Het resultaat:

![De omgekeerde effen opvulkleur](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkbladcel in op `null`. Voor een kolomgrafiek is de geplotte waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getValue). Het datapunt blijft op dezelfde categorische positie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Scatter‑grafieken gebruiken aparte X‑ en Y‑cellen, en bubble‑grafieken gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer u de andere punten wilt behouden, omdat die methode elk datapunt uit de collectie verwijdert.

## **Beheer de weergave van lege cellen**

Verborgen cellen die waarden bevatten vormen een ander geval dan lege cellen. Om gegevens uit verborgen werkbladrijen en -kolommen wel of niet op te nemen, zie [Include Data from Hidden Rows and Columns](/slides/nl/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Roep [ChartDataCell.setValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setValue) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het hele diagram. Het wijzigt hoe lege waarden worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één serie, wist de waarde voor Dag 3, en slaat hetzelfde diagram op in elke modus. Er is geen invoerbestand nodig. De [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

Elk uitvoerbestand slaat de vóór het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijst u de gewenste modus toe en slaat u de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in het werkboek in elk geval leeg:

![Lijndiagrammen met identieke data: Gap onderbreekt de lijn op Dag 3, Zero laat de lijn op nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om over een ontbrekende categorie heen te verbinden, dus `Span` kan niet het verbindingssegment produceren dat hierboven wordt getoond; een ontbrekende kolom en een kolom met nul‑hoogte kunnen ook op elkaar lijken. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de output voor het type dat u gebruikt.

## **Stel de breedte van de ruimte tussen series in**

De breedte van de ruimte (gap width) is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende series‑groep en niet tot één serie. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) één keer voor de groep aan. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld verandert de breedte van de ruimte en slaat alleen de definitieve presentatie op:

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

Het resultaat:

![De breedte van de ruimte](gap_width.png)

## **Veelgestelde vragen**

**Welke diagramtypen ondersteunen gegevensseries?**

Alle diagramtypen die vertegenwoordigd worden door de [ChartType]-enumeratie gebruiken diagramgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categori­diagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bubblendiagrammen voegen bubbelgroottes toe. Gebruik de methode voor het maken van datapunten die overeenkomt met het serietype. Opties zoals overlap en breedte van de ruimte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagramserie‑groep?**

Een [ChartSeriesGroup] bevat compatibele series die groeps‑niveau plot‑instellingen delen. Een combinatie‑diagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, betekent niet per se dat elke serie in het diagram wordt aangepast.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart] voorbeeldseries, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de serie‑ als de categorieverzamelingen wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram zonder standaardgegevens creëren.

**Hoe zijn diagramobjecten verbonden met werkboekcellen?**

Serienamen, categorielabels en datapuntenwaarden refereren naar cellen in een [ChartDataWorkbook]. Het wijzigen van een gerefereerde cel werkt het corresponderende diagramonderdeel bij. Wanneer u aangepaste gegevens samenstelt, houdt u de categorierijen en de rijen met serie‑waarden uitgelijnd zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele serie?**

Stel de relevante waardecel in op `null` om de categorische positie van het punt te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear] alleen wanneer u alle punten van die serie wilt verwijderen. Als u tevens categorieën verwijdert, werk dan elke serie bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de via [Chart.setDisplayBlanksAs] geconfigureerde waarde. Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie. Zie [Beheer de weergave van lege cellen](#control-the-display-of-empty-cells) voor een compleet voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubble‑series roept u [ChartSeries.setInvertIfNegative] aan en stelt u de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor]. U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative]. Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet gedefinieerd is, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlap en breedte van de ruimte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan hoeveel series een diagram kan bevatten?**

Aspose.Slides legt geen apart vast aantal series op. In de praktijk bepalen de beperkingen van het presentatiebestand, beschikbaar geheugen, rendertijd en de leesbaarheid van het diagram een praktische limiet.

**Wat moet ik aanpassen als kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth] aan op de juiste bovenliggende series‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.