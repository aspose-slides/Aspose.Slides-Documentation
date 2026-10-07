---
title: Beheer grafiekgegevensseries in presentaties in Java
linktitle: Gegevensseries
type: docs
url: /nl/java/chart-series/
keywords:
- grafiekserie
- serieoverlap
- seriekleur
- serienaam
- gegevenspunt
- werkbladcel
- serietussenruimte
- negatieve waarde
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u grafiekseries, gegevenspunten, werkbladcellen, opmaak, overlap, tussenruimte en negatieve waarden in presentaties met Java kunt beheren."
---
## **Overzicht**

Een grafiek slaat de geplotte gegevens op in een grafiek‑gegevenswerkmap. Een [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) in de serie verwijst naar één of meer werkmapcellen. [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/)‑objecten leveren de labels of groeperingswaarden die door de serie gedeeld worden. De serienaam, categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typische categoriegrafiek gebruikt de standaardwerkmap rij 0 voor serienamen, kolom 0 voor categorienamen en de overige cellen voor seriewaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek deze indeling hanteert. Voor een geladen presentatie inspecteert u de cellen die door de series, categorieën en gegevenspunten worden verwezen voordat u werkmapwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende toepassingsniveaus:

- Instellingen op serieniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), bieden de standaardweergave voor alle punten in één serie.
- Instellingen voor gegevenspunten, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven de serie‑weergave voor één punt.
- Groepsinstellingen passen op compatibele series die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) behoren. Benader de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer u opties wilt instellen zoals overlap of tussenruimte.

Wanneer er geen expliciete vulling voor een punt of serie is opgegeven, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel serie‑ als punt­formattering aanwezig zijn, heeft de punt­formattering voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlap van de grafiekreeks**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 percent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende series‑groep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op grafiektype die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen niet‑gerelateerde series‑groepen in een samengestelde grafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste serie bevat:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // De nieuwe grafiek bevat voorbeeldseries, categorieën en waarden.
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

## **Wijzigen van de vulkleur van de serie**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) om de standaardvulling voor een volledige serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‑instelling de serievulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste serie:

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

## **Wijzigen van de serienaam**

Een serienaam wordt opgeslagen in de grafiek‑gegevenswerkmap en wordt normaal weergegeven in de legenda. In de standaardwerkmap die voor een gegroepeerde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al door [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) wordt verwezen. Deze aanpak vermijdt het aannemen van een specifieke rij en kolom in een bestaande grafiek:

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

### **Een serie maken met een naam uit meerdere cellen**

Een samengestelde serienaam is handig wanneer een productnaam en een rapportageperiode in afzonderlijke werkmapcellen zijn opgeslagen. U kunt bijvoorbeeld `Product A` in B1 en `2026` in C1 combineren tot één serienaam, waarbij beide delen gekoppeld blijven aan hun broncellen.

Gebruik [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) om het naam‑bereik op te halen, en geef die collectie door aan [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één serie en twee gegevenspunten. Cellen B1:C1 leveren alleen de serienaam; A2:A3 leveren de categorie‑labels, en B2:B3 leveren de numerieke waarden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Deze twee cellen leveren de serienaam.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Aparte cellen leveren de categorieën en numerieke gegevenspunten.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De resulterende serienaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één invoer voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Automatische vulkleur van de serie ophalen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die is berekend op basis van de series‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de serievulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur van elke standaardserie af:

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

## **Omgekeerde vulkleur voor een grafiekreeks instellen**

Voor balk‑, kolom‑ en bubbel‑series kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden met een andere vulling weergeven. Stel de reguliere serievulling in op effen, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in de werkmap; alleen de weergavekleur wijzigt.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één serie. Werkbladrij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

U kunt inversie voor één punt inschakelen via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Waarde van een specifiek gegevenspunt wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkmapcel in op `null`. Voor een kolomgrafiek is de geplotte waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Het gegevenspunt blijft op dezelfde categorische positie staan, maar de grafiek behandelt de waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt in de eerste serie:

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

Scatter‑grafieken gebruiken afzonderlijke X‑ en Y‑cellen, en bubbel‑grafieken gebruiken tevens een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) niet aan wanneer u de andere punten wilt behouden, omdat die methode alle gegevenspunten uit de collectie verwijdert.

## **Weergave van lege cellen beheren**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Zie [Include Data from Hidden Rows and Columns](/slides/nl/java/chart-workbook/#include-data-from-hidden-rows-and-columns) om gegevens van verborgen rijen en kolommen op te nemen of uit te sluiten.

Een lege werkmapcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de gehele grafiek. Hij wijzigt hoe lege waarden worden geplot, zonder de lege werkmapcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één serie, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand nodig. De [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

    // Laat dag 3 echt leeg, maar behoud de categorie en het gegevenspunt.
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

Elk uitvoerbestand slaat de vóór het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, kent u de gewenste modus toe en slaat u de presentatie één keer op in plaats van de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in de werkmap in elk geval leeg:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om over een ontbrekende categorie heen te verbinden, dus `Span` kan niet het verbindende segment produceren dat hierboven te zien is; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk grafiektype; controleer de output voor het type dat u gebruikt.

## **Tussenruimte van de serie instellen**

Tussenruimte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort dit tot de bovenliggende series‑groep en niet tot één serie. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

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

**Welke grafiektype ondersteunen gegevensseries?**

Alle grafiektype die door de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑enumeratie worden vertegenwoordigd, gebruiken grafiekgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Categori­grafieken gebruiken bijvoorbeeld categorieën en waarden, spreidingsgrafieken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de methode voor het maken van gegevenspunten die overeenkomt met het serietype. Opties zoals overlap en tussenruimte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiek‑series‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, verandert niet noodzakelijk elke serie in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeld‑series, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de series‑ als de categorie‑collecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens maken.

**Hoe zijn grafiekobjecten gekoppeld aan werkmapcellen?**

Serienamen, categorielabels en gegevenspuntwaarden verwijzen naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een verwijzende cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste gegevens bouwt, houdt u de categorierijen en series‑waardereeksen op één lijn zodat elk punt onder de bedoelde categorie wordt geplot.

**Hoe kan ik één punt wissen in plaats van de hele serie?**

Stel de relevante waardecel in op `null` om de positie van het punt in de categorie behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer u alle punten uit die serie wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de waarde die is geconfigureerd via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nulwaarden, of door aangrenzende punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series roept u [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stelt u de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete opmaak van een gegevenspunt heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en tussenruimte regelen de lay‑out en zijn geen puntspecifieke opmaak‑overschrijfacties.

**Is er een limiet aan het aantal series dat een grafiek kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal series. In de praktijk bepalen de beperkingen van het presentatiebestand, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende series‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag de waarde om de clusters dichter bij elkaar te brengen.