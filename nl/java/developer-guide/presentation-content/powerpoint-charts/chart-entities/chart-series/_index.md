---
title: Beheer grafiekreeksen in presentaties in Java
linktitle: Gegevensreeksen
type: docs
url: /nl/java/chart-series/
keywords:
- grafiekreeksen
- reeksoverlap
- reekskleur
- reeksnaam
- gegevenspunt
- werkboekcel
- reeksafstand
- negatieve waarde
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, gegevenspunten, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met Java."
---
## **Overzicht**

Een grafiek slaat zijn uitgeplotte gegevens op in een grafiek‑gegevenswerkboek. Een [IChartSeries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/) vertegenwoordigt één reeks verwante waarden, en elke [IChartDataPoint](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/) in de reeks verwijst naar één of meer werkboekcellen. [IChartCategory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartcategory/)‑objecten leveren de labels of groepeerwaarden die door de reeksen gedeeld worden. De reeksnamen, categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typische categorie‑grafiek gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswerte. Werkblad‑, rij‑ en kolom‑indexen die aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer je een grafiek met standaardgegevens maakt, maar ga er niet vanuit dat elke bestaande grafiek deze indeling hanteert. Voor een geladen presentatie, inspecteer de cellen die door de reeksen, categorieën en gegevenspunten worden gerefereerd vóórdat je werkboekwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getFormat--), bieden de standaardopmaak voor alle punten in één reeks.
- Instellingen per gegevenspunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven de reeksopmaak voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/) behoren. Toegang tot de groep krijg je via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer je opties zoals overlap of gatbreedte wilt instellen.

Wanneer er geen expliciete punt‑ of reeksvulling is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑formattering aanwezig zijn, heeft de punt‑formattering voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlap van de grafiekreeks**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getOverlap--) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeks‑groep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor grafiektype­n die gegroepeerde balken of kolommen tonen; hij beïnvloedt geen niet‑gerelateerde reeksgroepen in een combinatiegrafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

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

## **De vulkleur van de reeks wijzigen**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getFormat--) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft zijn [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getFormat--) instelling de reeksvulling voor dat punt.

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

Een reeksnaam wordt opgeslagen in het grafiek‑gegevenswerkboek en wordt normaal weergegeven in de legenda. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerde kolomgrafiek, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel bijwerken die al wordt gerefereerd door [IChartSeries.getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getName--). Deze aanpak voorkomt dat je een bepaalde rij en kolom in een bestaande grafiek veronderstelt:

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

## **De automatische vulkleur van de reeks ophalen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die wordt berekend uit het reeksen‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij kenst geen nieuwe vulling toe.

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

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Inverteer de vulkleur voor een grafiekreeks**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden weergeven met een andere vulling. Stel de gewone reeksvulling in op egaal, schakel inversie in en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één reeks. Werkblad‑rij 0 bevat de reeksnaam, kolom 0 bevat categorienamen en kolom 1 bevat de waarden:

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

Je kunt inversie voor één punt inschakelen via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Een specifieke gegevenspuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkboekcel in op `null`. Voor een kolomgrafiek is de uitgeplotte waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#getValue--). Het gegevenspunt blijft op dezelfde categorpositie staan, maar de grafiek behandelt zijn waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

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

Spreidingsgrafieken gebruiken aparte X‑ en Y‑cellen, en bubbelgrafieken gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapointcollection/#clear--) niet aan als je de andere punten wilt behouden, want die methode verwijdert elk gegevenspunt uit de collectie.

## **Weergave van lege cellen regelen**

Een lege werkboekcel staat voor ontbrekende gegevens; een cel die `0` bevat, staat voor een bekende numerieke waarde. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de gehele grafiek. Hij verandert hoe leeglijnen worden geplot, zonder de lege werkboekcel met nul of een geïnterpoleerde waarde te vullen.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één reeks, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand vereist. De [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksnaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

    // Laat dag 3 echt leeg, terwijl de categorie en het gegevenspunt behouden blijven.
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

Elk uitvoerbestand slaat de modus op die voorafgaand aan het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs je de gewenste modus toe en sla je de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi makkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om te verbinden over een ontbrekende categorie, dus `Span` kan niet het verbindingssegment produceren dat hierboven wordt getoond; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht geen drie verschillende resultaten voor elk grafiektype; controleer de output voor het type dat je gebruikt.

## **De gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als percentage van de balk‑ of kolombreedte. Net als overlap behoort deze tot de bovenliggende reeks‑groep en niet tot één reeks. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer aan voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

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

![The gap width](gap_width.png)

## **FAQ**

**Welke grafiektypen ondersteunen gegevensreeksen?**

Alle grafiektypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/)‑enumeratie gebruiken grafiekgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑grafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de gegevenspunt‑creatiemethode die overeenkomt met het type reeks. Opties zoals overlap en gatbreedte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, wijzigt niet per se elke reeks in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldreeksen, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de reeksen‑ als de categorie‑collecties wissen voordat je een volledig aangepaste gegevensset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens maken.

**Hoe zijn grafiekobjecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en gegevenspuntwaarden verwijzen naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer je aangepaste gegevens samenstelt, houd je de categorierijen en reeksen‑waardrijen uitgelijnd zodat elk punt onder de beoogde categorie wordt uitgezet.

**Hoe kan ik één punt wissen in plaats van de hele reeks?**

Stel de betreffende waardecel in op `null` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer je alle punten uit die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk je elke reeks bij zodat hun waarden blijven overeenkomen met de categorie‑collectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) geconfigureerde waarde. Ondersteunde grafieken kunnen leemtes tonen als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in je presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roep je [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stel je de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Je kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete gegevenspunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet gedefinieerd is, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte regelen de lay‑out en vormen geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan hoeveel reeksen een grafiek kan bevatten?**

Aspose.Slides legt geen afzonderlijk vast limiet op voor het aantal reeksen. In de praktijk bepalen de beperkingen van het presentatiedocument, beschikbaar geheugen, render‑tijd en de leesbaarheid van de grafiek een bruikbare limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende reeks‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.