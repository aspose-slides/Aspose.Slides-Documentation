---
title: Beheer grafiekgegevensreeksen in presentaties op Android
linktitle: Gegevensreeksen
type: docs
url: /nl/androidjava/chart-series/
keywords:
- grafiekreeksen
- reeks overlapping
- reeks kleur
- reeksnaam
- datapunt
- werkboekcel
- reeksafstand
- negatieve waarde
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkboekcellen, opmaak, overlapping, tussenbreedte en negatieve waarden in presentaties op Android kunt beheren."
---
## **Overzicht**

Een diagram slaat zijn ingevoerde gegevens op in een chart‑data‑werkboek. Een [IChartSeries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elke [IChartDataPoint](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/) in de reeks refereert naar één of meer werkboekcellen. [IChartCategory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartcategory/)‑objecten leveren de labels of groeperingswaarden die door de reeksen worden gedeeld. De reeksnaam, categorieën en puntwaarden zijn daardoor gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/)-objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categorie‑diagram gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de resterende cellen voor reeksenwaarden. Werkblad‑, rij‑ en kolom‑indexen die worden doorgegeven aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram dit gebruikt. Voor een geladen presentatie inspecteert u de cellen die door de reeksen, categorieën en datapunten worden gerefereerd voordat u werkboekwaarden wijzigt.

Instellingen op reeksniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getFormat--), bepalen het standaard uiterlijk voor alle punten in één reeks.  
Instellingen per datapunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven het reeks‑uiterlijk voor één punt.  
Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/) behoren. Toegang tot de groep krijgt u via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer u opties wilt instellen zoals overlapping of gap‑breedte.

Wanneer er geen expliciete punt‑ of reeks‑vulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de reeks‑overlapping**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getOverlap--) rapporteert hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen weergeven; ze heeft geen invloed op niet‑gerelateerde reeksgroepen in een combinatiediagram.

Het volgende voorbeeld stelt de overlapping in voor de groep die de eerste reeks bevat:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // De nieuwe grafiek bevat voorbeeldreeksen, categorieën en waarden.
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

## **Wijzig de vullingkleur van de reeks**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getFormat--) om de standaard vulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft zijn [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)‑instelling de reeksvulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste reeks:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Wijzig de reeksnaam**

Een reeksnaam wordt opgeslagen in het diagram‑datwerkboek en wordt normaal weergegeven in de legenda. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerde kolomdiagram, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [IChartSeries.getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getName--). Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaand diagram:

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

## **Haal de automatische vullingkleur van de reeks op**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die is berekend op basis van de reeks‑index en de diagramstijl als een Android ARGB‑kleur‑integer. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld print de automatische kleur‑integer van elke standaardreeks:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

De exacte integer‑waarden hangen af van de diagramstijl en het thema.

## **Stel omgekeerde vullingkleur in voor een diagramreeks**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden weergeven met een andere vulling. Stel de reguliere reeksvulling in op effen, schakel inversie in en ken de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramgegevens door één reeks. Werkblad‑rij 0 bevat de reeksnaam, kolom 0 bevat categorienamen en kolom 1 bevat de waarden:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

U kunt inversie voor één punt inschakelen via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **Wis een specifieke datapuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolomdiagram is de geplotte waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Het datapunt blijft op dezelfde categorisch positie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Spreidingsdiagrammen gebruiken aparte X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) niet aan wanneer u de andere punten wilt behouden, omdat die methode elk datapunt uit de verzameling verwijdert.

## **Stel de tussenruimte van de reeks in**

Tussenruimtegerbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlapping behoort deze tot de bovenliggende reeksgroep in plaats van tot één reeks. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer aan voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de tussenruimtegerbreedte en slaat alleen de uiteindelijke presentatie op:

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

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/)‑enumeratie gebruiken diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidings‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de datapunt‑creatiemethode die overeenkomt met het type reeks. Opties zoals overlapping en tussenruimtegerbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plot‑instellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet per se elke reeks in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldreeksen, categorieën en waarden aan. U kunt die cellen bewerken of zowel de reeks‑ als de categorieverzamelingen wissen voordat u een volledig aangepaste gegevensset toevoegt. Een overload kan ook een diagram zonder standaardgegevens aanmaken.

**Hoe zijn diagramobjecten verbonden met werkboekcellen?**

Reeksnamen, categorielabels en datapunten‑waarden refereren naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het corresponderende diagramonderdeel bij. Wanneer u aangepaste gegevens bouwt, houdt u categorierijen en reeksen‑waardereeksen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de betreffende waardecel in op `null` om de categorisch positie van het punt te behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u tevens categorieën verwijdert, werk dan elke reeks bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde die is geconfigureerd via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Ondersteunde diagrammen kunnen leegtes weergeven als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roept u [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stelt u de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlapping en tussenruimtegerbreedte regelen de lay‑out en vormen geen overschrijvingen van punt‑niveau opmaak.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal reeksen. In de praktijk bepalen bestandsbeperkingen van de presentatie, beschikbare geheugen, render‑tijd en leesbaarheid van het diagram een praktische limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver van elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.