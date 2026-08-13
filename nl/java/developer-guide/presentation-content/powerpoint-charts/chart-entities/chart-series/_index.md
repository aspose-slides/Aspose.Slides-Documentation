---
title: Beheer diagramreeksgegevens in presentaties met Java
linktitle: Gegevensreeks
type: docs
url: /nl/java/chart-series/
keywords:
- diagramreeks
- reeks overlapping
- reeks kleur
- reeksnaam
- datapunt
- werkbladcel
- reeksafstand
- negatieve waarde
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunten, werkbladcellen, opmaak, overlapping, tussenruimte en negatieve waarden in presentaties kunt beheren met Java."
---
## **Overzicht**

Een diagram slaat zijn getekende gegevens op in een diagram‑gegevenswerkmap. Een [IChartSeries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/) vertegenwoordigt één set verwante waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/) in de reeks verwijst naar één of meer werkbladcellen. [IChartCategory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartcategory/)‑objecten leveren de etiketten of groepeer­waarden die door de reeksen worden gedeeld. De reeksnaam, categorieën en puntwaarden zijn daardoor gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typisch categorie‑diagram gebruikt de standaardwerkmap rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswerte. Werkblad‑, rij‑ en kolom‑indexen die aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) worden doorgegeven, zijn nulgebaseerd. Deze opzet is handig wanneer je een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram deze structuur hanteert. Voor een geladen presentatie moet je de cellen inspecteren die door de reeksen, categorieën en datapunten worden gerefereerd voordat je werkmapwaarden wijzigt.

Diagram­instellingen hebben drie verschillende reikwijdtes:

- Instellingen op reeksniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getFormat--), bieden de standaard­opmaak voor alle punten in één reeks.
- Instellingen per datapunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven de reeksopmaak voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/) behoren. Benader de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer je opties moet instellen zoals overlapping of breedte van de tussenruimte.

Wanneer geen expliciete punt‑ of reeks‑vulling is ingesteld, bepalen diagramstijl en thema de automatische opmaak. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **De overlapping van diagramreeksen instellen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getOverlap--) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van –100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen weergeven; hij heeft geen invloed op niet‑gerelateerde reeksgroepen in een combinatiediagram.

Het volgende voorbeeld stelt de overlapping in voor de groep die de eerste reeks bevat:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Het nieuwe diagram bevat voorbeeldreeksen, categorieën en waarden.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The series overlap](series_overlap.png)

## **De vulkleur van de reeks wijzigen**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getFormat--) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getFormat--)‑instelling de reeksvulling voor dat punt.

Het volgende voorbeeld past een egale blauwe vulling toe op de eerste reeks:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The color of the series](series_color.png)

## **De reeksnaam wijzigen**

Een reeksnaam wordt opgeslagen in de diagram‑gegevenswerkmap en wordt normaal weergegeven in de legenda. In de standaardwerkmap die wordt aangemaakt voor een gegroepeerd kolomdiagram, staat cel B1 in rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Je kunt ook de cel bijwerken die al door [IChartSeries.getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getName--) wordt gerefereerd. Deze aanpak vermijdt veronderstellingen over een bepaalde rij en kolom in een bestaand diagram:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The series name](series_name.png)

## **De automatische vulkleur van de reeks opvragen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die wordt berekend op basis van de reeks‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet gedefinieerd is. Het aanroepen van de methode leest de berekende kleur; het kent geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur van elke standaardreeks af:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Uitvoervoorbeeld voor de standaard diagramstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Inverted‑vulkleur voor een diagramreeks instellen**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden met een andere vulling weergeven. Stel de gewone reeksvulling in op egaal, schakel inversie in en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven onveranderd in de werkmap; alleen de weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramgegevens door één reeks. Werkbladrij 0 bevat de reeksnaam, kolom 0 bevat categorienamen en kolom 1 bevat de waarden:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The inverted solid fill color](inverted_solid_fill_color.png)

Je kunt inversie voor één punt inschakelen via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde toegewezen zodat het effect zichtbaar is:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een specifieke datapuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkbladcel in op `null`. Voor een kolomdiagram is de getekende waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getValue--). Het datapunt blijft op dezelfde categorielocatie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

Het volgende voorbeeld wist alleen het tweede punt in de eerste reeks:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Spreidingsdiagrammen gebruiken gescheiden X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken tevens een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapointcollection/#clear--) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **De tussenruimte van de reeks instellen**

De tussenruimte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlapping behoort hij toe aan de bovenliggende reeksgroep in plaats van aan één reeks. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer aan voor de groep. Een hogere waarde creëert meer ruimte tussen de clusters; een lagere waarde maakt ze dichter op elkaar.

Het volgende voorbeeld wijzigt de tussenruimte en slaat alleen de uiteindelijke presentatie op:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The gap width](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen gegevensreeksen?**

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/)‑enumeratie maken gebruik van diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de methode voor het aanmaken van datapunten die overeenkomt met het type reeks. Opties zoals overlapping en tussenruimte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plot‑instellingen delen. Een combinatiediagram kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één reeks wordt bereikt, niet per se alle reeksen in het diagram aanpast.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldreeksen, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de reeks‑ als categorieverzamelingen leegmaken voordat je een volledig aangepast gegevens‑set toevoegt. Een overload kan ook een diagram zonder standaardgegevens creëren.

**Hoe zijn diagramobjecten gekoppeld aan werkbladcellen?**

Reeksnamen, categorielabels en waarden van datapunten verwijzen naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer je aangepaste gegevens maakt, houd je de categorierijen en reekswertrijen op één lijn zodat elk punt onder de bedoelde categorie wordt getekend.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de betreffende waardecel in op `null` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer je alle punten uit die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk je elke reeks bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde die via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) is geconfigureerd. Ondersteunde diagrammen kunnen leegtes tonen als gaten, als nulwaarden, of door aangrenzende punten met elkaar te verbinden. Kies de instelling die past bij de betekenis van ontbrekende data in je presentatie.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roep je [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stel je de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Je kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer die niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlapping en tussenruimte bepalen de layout en vormen geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal reeksen. In de praktijk bepalen bestandsbeperkingen van de presentatie, beschikbaar geheugen, render‑tijd en leesbaarheid van het diagram een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver van elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen de clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.