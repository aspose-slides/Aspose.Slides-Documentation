---
title: Beheer grafiekgegevensreeksen in presentaties met JavaScript
linktitle: Gegevensreeksen
type: docs
url: /nl/nodejs-java/chart-series/
keywords:
- grafiekreeksen
- reeks overlap
- reeks kleur
- reeks naam
- datapunt
- werkboekcel
- reeks gat
- negatieve waarde
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden kunt beheren in presentaties met JavaScript."
---
## **Overzicht**

Een grafiek slaat zijn getekende gegevens op in een grafiek‑gegevens‑werkboek. Een [ChartSeries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/) vertegenwoordigt één set verwante waarden, en elke [ChartDataPoint](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/) in de reeks verwijst naar één of meer werkboekcellen. [ChartCategory](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartcategory/)‑objecten bieden de labels of groepeerwaarden die door de reeksen worden gedeeld. De reeksnaam, categorieën en puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categoriestandaard gebruikt het standaard‑werkboek rij 0 voor reeksenamen, kolom 0 voor categorienamen en de resterende cellen voor reekswaarden. Werkblad‑, rij‑ en kolom‑indexen die naar [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek deze indeling gebruikt. Voor een geladen presentatie moet u de cellen inspecteren die door de reeksen, categorieën en datapunten worden gerefereerd voordat u werkboekwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende reikwijdtes:

- Instellingen op reekseniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getFormat), bieden de standaard‑uiterlijk voor alle punten in één reeks.
- Instellingen voor datapunten, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getFormat), overschrijven het reeksen‑uiterlijk voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseriesgroup/) behoren. Gebruik [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) om de groep te benaderen wanneer u opties moet instellen, zoals overlap of gatbreedte.

Wanneer geen expliciete punt‑ of reeks‑vulling is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **De Overlap van de Grafiekreeks Instellen**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getOverlap) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezende projectie van de instelling op de bovenliggende reeks‑groep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op grafiektypen die gegroepeerde balken of kolommen weergeven; hij heeft geen invloed op niet‑gerelateerde reeksgroepen in een combinatie‑grafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

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

    // De nieuwe grafiek bevat voorbeeldreeksen, categorieën en waarden.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The series overlap](series_overlap.png)

## **De Vulkleur van de Reeks Wijzigen**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getFormat) om de standaard‑vulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft zijn [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getFormat)‑instelling de reeksvulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste reeks:

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

![The color of the series](series_color.png)

## **De Naam van de Reeks Wijzigen**

Een reeksennaam wordt opgeslagen in het grafiek‑gegevens‑werkboek en wordt normaal weergegeven in de legenda. In het standaard‑werkboek dat voor een gegroepeerde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel die al wordt gerefereerd door [ChartSeries.getName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getName) bijwerken. Deze aanpak voorkomt dat u een specifieke rij en kolom in een bestaande grafiek moet aannemen:

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

![The series name](series_name.png)

## **De Automatische Vulkleur van de Reeks Ophalen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die wordt berekend op basis van de reeksen‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijzigt geen vulling.

Het volgende voorbeeld drukt de automatische kleur van elke standaardreeks af:

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

Voorbeelduitvoer voor de standaardgrafiekstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Inverteerbare Vulkleur voor een Grafiekreeks Instellen**

Voor balk‑, kolom‑ en bubbelreeksen kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de reguliere reeksvulling in op effen, schakel inversie in en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één reeks. Werkblad‑rij 0 bevat de reeksennaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Een Specifieke Datapuntwaarde Wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolomgrafiek is de getekende waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#getValue). Het datapunt blijft op dezelfde categorielocatie, maar de grafiek behandelt de waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt in de eerste reeks:

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

Spreidingsgrafieken gebruiken gescheiden X‑ en Y‑cellen, en bubbelgrafieken gebruiken bovendien een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **De Weergave van Lege Cellen Beheren**

Een lege werkboekcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Roep [ChartDataCell.setValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#setValue) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Ze verandert de manier waarop lege waarden worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één reeks, wist de waarde voor Dag 3 en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand vereist. De [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksennaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

Elk output‑bestand slaat de vóór het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs de gewenste modus toe en sla de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk te vergelijken. Balk‑ en kolomgrafieken hebben geen lijn om een ontbrekende categorie te verbinden, zodat `Span` geen verbindingssegment kan produceren zoals hierboven; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook op elkaar lijken. Evenzo heeft een spreidingsgrafiek met alleen markeringen geen verbindingslijn. Verwacht geen drie afzonderlijke resultaten voor elk grafiektype; controleer de output voor het type dat u gebruikt.

## **De Gatbreedte van de Reeks Instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de breedte van de balk of kolom. Net als overlap behoort dit tot de bovenliggende reeks‑groep en niet tot één enkele reeks. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) één keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

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

Het resultaat:

![The gap width](gap_width.png)

## **FAQ**

**Welke grafiektypen ondersteunen datarijken?**

Alle grafiektypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/)‑enumeratie gebruiken grafiekgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriestandaard gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelformaten toe. Gebruik de methode voor het maken van datapunten die overeenkomt met het type reeks. Opties zoals overlap en gatbreedte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatietype kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet noodzakelijkerwijs elke reeks in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard creëert [ShapeCollection.addChart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addChart) voorbeeldreeksen, -categorieën en -waarden. U kunt die cellen bewerken of zowel de reeksen‑ als categorieverzamelingen wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens maken.

**Hoe zijn grafiekobjecten gekoppeld aan werkboekcellen?**

Reeksen‑namen, categorie‑labels en waarden van datapunten refereren cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste gegevens bouwt, houdt u de categorie‑rijen en reeks‑waarderijen op één lijn zodat elk punt wordt geplot onder de beoogde categorie.

**Hoe kan ik één punt wissen in plaats van de hele reeks?**

Stel de relevante waarde‑cel in op `null` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden blijven overeenkomen met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de waarde die is geconfigureerd via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Ondersteunde grafieken kunnen leegtes weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie. Zie [De Weergave van Lege Cellen Beheren](#control-the-display-of-empty-cells) voor een compleet voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roept u [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stelt u de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte bepalen de lay‑out en zijn geen overschrijvingen op punt‑niveau.

**Is er een limiet aan het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet voor het aantal reeksen op. In de praktijk bepalen de beperkingen van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een bruikbare limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver van elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de juiste bovenliggende reeks‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.