---
title: Beheer diagramgegevensreeksen in presentaties in Java
linktitle: Gegevensreeksen
type: docs
url: /nl/java/chart-series/
keywords:
- diagramreeks
- reeks overlapping
- reeks kleur
- reeksnaam
- datumpunt
- werkbladcel
- reeks kloof
- negatieve waarde
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe je diagramreeksen, datapunten, werkbladcellen, opmaak, overlapping, kloofbreedte en negatieve waarden in presentaties met Java kunt beheren."
---
## **Overzicht**

Een diagram slaat zijn weergegeven gegevens op in een diagramgegevens-werkmap. Een [IChartSeries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/) vertegenwoordigt één set verwante waarden, en elke [IChartDataPoint](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/) in de reeks verwijst naar één of meer werkbladcellen. [IChartCategory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartcategory/)‑objecten leveren de labels of groepeerwaarden die door de reeksen worden gedeeld. De reeksnaam, categorieën en puntwaarden zijn dus gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categoriediagram gebruikt de standaard‑werkmap rij 0 voor reeksnamen, kolom 0 voor categorienamen en de resterende cellen voor reekswaarden. Werkblad‑, rij‑ en kolom‑indexen die worden doorgegeven aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) zijn nul‑gebaseerd. Deze indeling is handig wanneer je een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram het zo gebruikt. Voor een geladen presentatie controleer je de cellen waarnaar de reeksen, categorieën en datapunten verwijzen voordat je werkmapwaarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getFormat--), bieden de standaardweergave voor alle punten in één reeks.
- Instellingen per datumpunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven de reeksweergave voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/) behoren. Open de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer je opties wilt instellen zoals overlapping of kloofbreedte.

Wanneer er geen expliciete punt‑ of reeksvulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als puntformattering aanwezig zijn, heeft de puntformattering voor dat punt voorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlapping van de diagramreeks**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getOverlap--) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van –100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen weergeven; hij heeft geen effect op niet‑gerelateerde reeksgroepen in een combinatiediagram.

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

## **De vullingkleur van de reeks wijzigen**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getFormat--) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de instelling van [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getFormat--) de reeksvulling voor dat punt.

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

## **De naam van de reeks wijzigen**

Een reeksnamen wordt opgeslagen in de diagramgegevens‑werkmap en wordt normaal weergegeven in de legend. In de standaard‑werkmap die wordt aangemaakt voor een gegroepeerde kolomdiagram, staat cel B1 op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel bijwerken die al wordt aangeduid door [IChartSeries.getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getName--). Deze aanpak voorkomt dat je een specifieke rij en kolom in een bestaand diagram moet aannemen:

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

## **De automatische vullingskleur van de reeks ophalen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) geeft de kleur terug die wordt berekend op basis van de reeks‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

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

Voorbeeldoutput voor de standaard diagramstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Omgekeerde vulkleur voor een diagramreeks instellen**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden met een andere vulling weergeven. Stel de reguliere reeksvulling in op egaal, schakel inversie in en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in de werkmap; alleen hun weergave‑kleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramgegevens door één reeks. Werkbladrij 0 bevat de reeksnamen, kolom 0 bevat categorienamen en kolom 1 bevat de waarden:

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

Je kunt inversie inschakelen voor één punt via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde toegekend zodat het effect zichtbaar is:

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

## **Een specifieke datumpuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkmapcel in op `null`. Voor een kolomdiagram is de geplotte waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getValue--). Het datumpunt blijft op dezelfde categorielocatie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Scatter‑diagrammen gebruiken aparte X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapointcollection/#clear--) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk datumpunt uit de collectie.

## **Weergave van lege cellen beheren**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Zie [Include Data from Hidden Rows and Columns](/slides/nl/java/chart-workbook/#include-data-from-hidden-rows-and-columns) voor informatie over het opnemen of uitsluiten van gegevens uit verborgen werkbladrijen en -kolommen.

Een lege werkmapcel stelt ontbrekende gegevens voor; een cel die `0` bevat staat voor een bekende numerieke waarde. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het hele diagram. Hij verandert de manier waarop lege waarden worden geplot, zonder de lege werkmapcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één reeks, wist de waarde voor Dag 3 en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand vereist. De [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksnamen. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

    // Laat Dag 3 echt leeg, terwijl de categorie en het datumpunt behouden blijven.
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

Elk uitvoerbestand slaat de modus op die voorafgaand aan het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs je de gewenste modus toe en sla je de presentatie één keer op in plaats van te itereren over de modi.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elke werkmap leeg:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomdiagrammen hebben geen lijn om te verbinden over een ontbrekende categorie, dus `Span` kan niet het verbindingssegment produceren dat hierboven wordt getoond; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook gelijk uitzien. Evenzo heeft een scatter‑diagram met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de uitvoer voor het type dat je gebruikt.

## **De kloofbreedte van de reeks instellen**

Kloofbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de breedte van de balk of kolom. Net als overlapping behoort hij tot de bovenliggende reeksgroep en niet tot één enkele reeks. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer voor de groep aan. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de kloofbreedte en slaat alleen de uiteindelijke presentatie op:

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

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/)‑enumeratie gebruiken diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriendiagrammen gebruiken categorieën en waarden, scatter‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelformaten toe. Gebruik de methode voor het maken van datapunten die overeenkomt met het type reeks. Opties zoals overlapping en kloofbreedte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, wijzigt niet noodzakelijk elke reeks in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldreeksen, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de reeks‑ als categorieverzamelingen wissen voordat je een volledig aangepaste gegevensset toevoegt. Een overload kan ook een diagram zonder standaardgegevens maken.

**Hoe zijn diagramobjecten gekoppeld aan werkbladcellen?**

Reeksnamen, categorielabels en waardes van datapunten verwijzen naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een verwezen cel werkt het overeenkomstige diagramonderdeel bij. Wanneer je aangepaste gegevens maakt, houd je de rijen voor categorieën en de rijen voor reeks‑waarden uitgelijnd, zodat elk punt onder de bedoelde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de desbetreffende waarde­cel in op `null` om de positie van de categorie van het punt te behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer je al die punten uit die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk je elke reeks bij zodat hun waarden blijven aansluiten op de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde die is geconfigureerd via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Ondersteunde diagrammen kunnen lege waarden weergeven als hiaten, als nuls of door naburige punten met elkaar te verbinden. Kies de instelling die het beste past bij de betekenis van ontbrekende gegevens in je presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roep je [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stel je de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Je kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete punt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlapping en kloofbreedte regelen de lay‑out en vormen geen overschrijving van punt‑niveau opmaak.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen apart vaste limiet op voor het aantal reeksen. In de praktijk bepalen bestands­beperkingen van de presentatie, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de betreffende bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichterbij elkaar te brengen.