---
title: Beheer grafiekgegevensreeksen in presentaties op Android
linktitle: Gegevensreeksen
type: docs
url: /nl/androidjava/chart-series/
keywords:
- grafiekreeks
- reeks overlap
- reeks kleur
- reeks naam
- datapunt
- werkbladcel
- reeks gat
- negatieve waarde
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkbladcellen, opmaak, overlap, gatbreedte en negatieve waarden kunt beheren in presentaties op Android."
---
## **Overzicht**

Een grafiek slaat zijn getekende gegevens op in een grafiek‑datacontactwerkboek. Een [IChartSeries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/) vertegenwoordigt één reeks verwante waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/) in de reeks verwijst naar één of meer cellen in het werkblad. [IChartCategory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartcategory/)‑objecten leveren de labels of groepeervelden die door de reeksen worden gedeeld. De naam van de reeks, categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typische categoriegrafiek gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswerwaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is nuttig wanneer u een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek deze indeling gebruikt. Bij een geladen presentatie inspecteert u de cellen die door de reeksen, categorieën en datapoints worden gerefereerd voordat u werkboekwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende reikwijdtes:

- Instellingen op reeksniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getFormat--), bieden het standaard uiterlijk voor alle punten in één reeks.
- Instellingen per datapunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven het reeks‑uiterlijk voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die behoren tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/). Toegang tot de groep krijg je via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer u opties zoals overlap of gatbreedte moet instellen.

Wanneer er geen expliciete punt‑ of reeks‑opvulling is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als puntopmaak aanwezig zijn, heeft de puntopmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Stel de overlap van de grafiekreeks in**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getOverlap--) meldt hoeveel staven of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op grafiektype die gegroepeerde staven of kolommen tonen; het beïnvloedt geen niet‑gerelateerde reeksgroepen in een combinatiegrafiek.

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

Resultaat:

![The series overlap](series_overlap.png)

## **Wijzig de opvulkleur van de reeks**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getFormat--) om de standaardopvulling voor een volledige reeks in te stellen. Als een punt al een expliciete opvulling heeft, overschrijft de [IChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)‑instelling de reeksenopvulling voor dat punt.

Het volgende voorbeeld past een effen blauwe opvulling toe op de eerste reeks:

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

Resultaat:

![The color of the series](series_color.png)

## **Wijzig de naam van de reeks**

Een reekstenaam wordt opgeslagen in het grafiekdatacontactwerkboek en normaal weergegeven in de legenda. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerde kolomgrafiek bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [IChartSeries.getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getName--). Deze aanpak voorkomt dat u een specifieke rij en kolom in een bestaande grafiek moet aannemen:

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

Resultaat:

![The series name](series_name.png)

## **Haalt de automatische reekskleur op**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die wordt berekend op basis van de reeksenindex en de grafiekstijl als een Android ARGB‑kleur‑integer. Dit is de kleur die wordt gebruikt wanneer de reeksenopvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe opvulling toe.

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

## **Stel omgekeerde opvulkleur in voor een grafiekreeks**

Voor staaf‑, kolom‑ en bubbelreeksen kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden weergeven met een andere opvulling. Stel de gewone reeksenopvulling in op effen, schakel inversie in, en ken de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in het werkblad; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één reeks. Werkbladrij 0 bevat de reekstenaam, kolom 0 de categorienamen en kolom 1 de waarden:

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

Resultaat:

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie inschakelen voor één punt via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde toegewezen zodat het effect zichtbaar is:

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

Om één punt leeg te maken zonder de overige punten te verwijderen, stelt u de onderliggende werkbladcel in op `null`. Voor een kolomgrafiek is de getekende waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Het datapunt blijft op dezelfde categorielocatie, maar de grafiek behandelt zijn waarde als leeg volgens de instelling voor lege waarden van de grafiek.

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

Scatter‑grafieken gebruiken afzonderlijke X‑ en Y‑cellen, en bubbelgrafieken gebruiken ook een groottecel. Wis alleen de cel die de waarde die u wilt verwijderen representeert. Roep [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Beheer de weergave van lege cellen**

Verborgen cellen met waarden vormen een apart geval ten opzichte van lege cellen. Om gegevens van verborgen werkblad‑rijen en -kolommen op te nemen of uit te sluiten, zie [Gegevens opnemen uit verborgen rijen en kolommen](/slides/nl/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkbladcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de gehele grafiek. Het wijzigt hoe lege waarden worden geplot, zonder de lege werkbladcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één reeks, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand vereist. De [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reekstenaam. De uiteindelijke gegevens zijn `10, 20, leeg, 30, 40`.

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

Elke uitvoer­bestand slaat de vóór het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijst u de gewenste modus toe en slaat u de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkblad:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt het vergelijken van alle drie de modi eenvoudig. Staaf‑ en kolomgrafieken hebben geen lijn om een ontbrekende categorie te verbinden, dus `Span` kan het boven afgebeelde verbindingssegment niet produceren; een ontbrekende kolom en een kolom met nul‑hoogte kunnen er ook gelijk uitzien. Evenzo heeft een scatter‑grafiek met alleen markeringen geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk grafiektype; controleer de uitvoer voor het type dat u gebruikt.

## **Stel de gatbreedte van de reeks in**

Gatbreedte is de ruimte tussen aangrenzende staaf‑ of kolomclusters, uitgedrukt als een percentage van de staaf‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende reeksgroep en niet tot één reeks. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer voor de groep aan. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

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

Resultaat:

![The gap width](gap_width.png)

## **FAQ**

**Welke grafiektype ondersteunen datareeksen?**

Alle grafiektype die worden weergegeven door de [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/)‑enumeratie gebruiken grafiekgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriegrafieken gebruiken categorieën en waarden, scatter‑grafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelaantallen toe. Gebruik de datapunt‑creatiemethode die overeenkomt met het reekstype. Opties zoals overlap en gatbreedte gelden alleen voor compatibele staaf‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, hoeft niet per se elke reeks in de grafiek te wijzigen.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldreeksen, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de reeks‑ als de categorie‑collecties leegmaken voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens aanmaken.

**Hoe zijn grafiekobjecten gekoppeld aan werkbladcellen?**

Reeksnamen, categorielabels en datapunt‑waarden refereren naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste gegevens opstelt, houd dan de categorierijen en reeksen‑waardrijen uitgelijnd zodat elk punt onder de bedoelde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waardecel in op `null` om de categorielocatie van het punt als leeg punt te behouden. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden uitgelijnd blijven met de categorie‑collectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) geconfigureerde waarde. Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie. Zie [Beheer de weergave van lege cellen](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde staaf‑, kolom‑ en bubbelreeksen, roep [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stel de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeksenopmaak gebruiken of, wanneer de reeksenopmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte beheersen de lay‑out en zijn geen overrides op punt‑niveau.

**Is er een limiet aan het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op aan het aantal reeksen. In de praktijk bepalen bestandslimieten van de presentatie, beschikbare geheugen, render‑tijd en leesbaarheid van de grafiek een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.