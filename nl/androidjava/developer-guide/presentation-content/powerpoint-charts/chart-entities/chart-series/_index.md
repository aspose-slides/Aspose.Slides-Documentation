---
title: Beheer diagramgegevensreeksen in presentaties op Android
linktitle: Gegevensreeksen
type: docs
url: /nl/androidjava/chart-series/
keywords:
- diagramreeks
- reeks overlapping
- reeks kleur
- reeksnaam
- datapunt
- werkboekcel
- reeks gat
- negatieve waarde
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunt, werkboekcellen, opmaak, overlapping, gatbreedte en negatieve waarden in presentaties op Android beheert."
---
## **Overzicht**

Een diagram slaat zijn ingevoerde gegevens op in een werkboek voor diagramgegevens. Een [IChartSeries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/) in de reeks verwijst naar één of meer cellen in het werkboek. [IChartCategory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartcategory/) objecten leveren de labels of groeperingswaarden die door de reeksen worden gedeeld. De reeksnaam, categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/) objecten en niet alleen opgeslagen als weergavetekst.

Voor een typische categoriediagram gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen, en de resterende cellen voor reekswerte. Werkblad‑, rij‑ en kolom‑indexen die worden doorgegeven aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar neem niet aan dat elk bestaand diagram deze indeling gebruikt. Voor een geladen presentatie moet u de cellen die door de reeksen, categorieën en gegevenspunten worden gerefereerd inspecteren voordat u werkboekwaarden wijzigt.

Instellingen voor diagrammen hebben drie verschillende scopes:

- Instellingen op reeksen‑niveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getFormat--), bieden de standaardweergave voor alle punten in één reeks.
- Instellingen voor gegevenspunten, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven de reeksweergave voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele reeksen die behoren tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/). Toegang tot de groep krijgt u via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer u opties zoals overlapping of gatbreedte moet instellen.

Wanneer geen expliciete punt‑ of reeksvulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑formattering aanwezig zijn, heeft de punt‑formattering voorrang voor dat punt.

![grafiek-reeks-powerpoint](chart-series-powerpoint.png)

## **De Reeks‑overlapping Instellen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getOverlap--) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen onge‑gerelateerde reeksgroepen in een combinatie‑diagram.

Het volgende voorbeeld stelt de overlapping in voor de groep die de eerste reeks bevat:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Het nieuwe diagram bevat voorbeeldreeksen, categorieën en waardes.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De reeksoverlapping](series_overlap.png)

## **De Vulkleur van de Reeks Wijzigen**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getFormat--) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) instelling de reeksvulling voor dat punt.

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

![De kleur van de reeks](series_color.png)

## **De Reeksnaam Wijzigen**

Een reeksnaam wordt opgeslagen in het diagram‑datwerkboek en wordt normaal weergegeven in de legenda. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerd kolom‑diagram, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

![De reeksnaam](series_name.png)

## **De Automatische Reeks‑kleur Opvragen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die wordt berekend op basis van de reeksindex en de diagramstijl als een Android ARGB‑kleurinteger. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleurinteger af van elke standaardreeks:

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

De exacte integerwaarden hangen af van de diagramstijl en het thema.

## **Inverteerbare Vulkleur voor een Diagramreeks Instellen**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden weergeven met een andere vulling. Stel de reguliere reeksvulling in op effen, schakel inversie in, en wijs de negatieve‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramgegevens door één reeks. Werkblad‑rij 0 bevat de reeksnaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De geïnverteerde effen vullingkleur](inverted_solid_fill_color.png)

U kunt inversie inschakelen voor één punt via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Een Specifieke Gegevenspuntwaarde Leegmaken**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolom‑diagram is de ingevoerde waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Het gegevenspunt blijft op dezelfde categorienieuw positioneren, maar het diagram behandelt de waarde als leeg volgens de instelling voor lege waarden van het diagram.

Het volgende voorbeeld maakt alleen het tweede punt in de eerste reeks leeg:

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

Punt‑diagrammen gebruiken aparte X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een groottecel. Maak alleen de cel leeg die de waarde vertegenwoordigt die u wilt verwijderen. Roep niet [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk gegevenspunt uit de verzameling.

## **De Weergave van Lege Cellen Beheersen**

Een lege werkboekcel vertegenwoordigt ontbrekende gegevens; een cel met `0` vertegenwoordigt een bekende numerieke waarde. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling is van toepassing op het gehele diagram. Hij verandert hoe lege waarden worden getekend, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één reeks, maakt de waarde voor Dag 3 leeg, en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand nodig. De [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de reeksnaam. De uiteindelijke data is `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Laat Dag 3 echt leeg, terwijl de categorie en het datapunt behouden blijven.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Elk uitvoerbestand slaat de modus op die is toegewezen vóór het opslaan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijst u de gewenste modus toe en slaat u de presentatie één keer op in plaats van te itereren over de modi.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Lijndiagrammen met identieke data: Gap verbreekt de lijn op Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi eenvoudig te vergelijken. Balk‑ en kolomdiagrammen hebben geen lijn om een ontbrekende categorie te verbinden, dus `Span` kan het verbindingssegment niet produceren; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsdiagram met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de output voor het type dat u gebruikt.

## **De Gatbreedte van de Reeks Instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolom‑clusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlapping behoort het tot de bovenliggende reeksgroep en niet tot één reeks. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) een keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de uiteindelijke presentatie op:

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

![De gatbreedte](gap_width.png)

## **FAQ**

**Welke diagramtypes ondersteunen gegevensreeksen?**

Alle diagramtypes die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/) enumeratie gebruiken diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriediagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de methode voor het maken van gegevenspunten die overeenkomt met het type reeks. Opties zoals overlapping en gatbreedte zijn alleen van toepassing op compatibele balk‑ of kolom‑groepen.

**Wat is een diagramreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plot‑instellingen delen. Een combinatie‑diagram kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één reeks wordt bereikt niet per se elke reeks in het diagram wijzigt.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldreeksen, categorieën en waarden aan. U kunt die cellen bewerken of zowel de reeks‑ als categorieverzamelingen wissen voordat u een volledig aangepast gegevensset toevoegt. Een overload kan ook een diagram zonder standaardgegevens maken.

**Hoe zijn diagramobjecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en gegevenspunt‑waarden refereren aan cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste gegevens bouwt, houdt u categorie‑rijen en reeks‑waarde‑rijen uitgelijnd zodat elk punt onder de beoogde categorie wordt getekend.

**Hoe maak ik één punt leeg in plaats van de hele reeks?**

Stel de betreffende waardecel in op `null` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde die is geconfigureerd via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende gegevens in uw presentatie. Zie [De Weergave van Lege Cellen Beheersen](#control-the-display-of-empty-cells) voor een compleet voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roept u [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stelt u de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt worden opgemaakt?**

Expliciete gegevenspunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeksopmaak gebruiken of, wanneer de reeksopmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlapping en gatbreedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke harde limiet op voor het aantal reeksen. In de praktijk bepalen bestandsgrootte, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram de bruikbare limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.