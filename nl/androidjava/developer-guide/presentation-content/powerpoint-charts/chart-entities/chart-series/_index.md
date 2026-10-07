---
title: Beheer diagramreeksen in presentaties op Android
linktitle: Gegevensreeksen
type: docs
url: /nl/androidjava/chart-series/
keywords:
- grafiekreeks
- reeks overlapping
- reeks kleur
- reeksnaam
- datapunt
- werkbladcel
- reeks gat
- negatieve waarde
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunten, werkbladcellen, opmaak, overlapping, gatbreedte en negatieve waarden in presentaties op Android kunt beheren."
---
## **Overzicht**

Een diagram slaat zijn getekende gegevens op in een werkmap voor diagramgegevens. Een [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) in de serie verwijst naar één of meer cellen in de werkmap. [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) objecten leveren de labels of groepeerwaarden die door de serie worden gedeeld. De serienaam, categorieën en puntwaarden zijn daarom verbonden met [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typisch categorie‑diagram gebruikt de standaardwerkmap rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor seriewaarden. Werkblad‑, rij‑ en kolom‑indexen die worden doorgegeven aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) zijn nul‑gebaseerd. Deze indeling is handig wanneer je een diagram maakt met standaardgegevens, maar ga er niet van uit dat elk bestaand diagram deze indeling gebruikt. Voor een geladen presentatie, inspecteer de cellen die door de serie, categorieën en gegevenspunten worden gerefereerd voordat je werkmap‑waarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op serieniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--), bieden de standaarduiterlijk voor alle punten in één serie.
- Instellingen per gegevenspunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven het serieweergave voor één punt.
- Groepsinstellingen gelden voor compatibele series die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) behoren. Toegang tot de groep krijg je via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer je opties wilt instellen zoals overlapping of gatbreedte.

Wanneer er geen expliciete punt‑ of serie‑vulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Stel de overlapping van de diagramserie in**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) rapporteert hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezende projectie van de instelling op de bovenliggende seriegroep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen niet‑gerelateerde seriegroepen in een combinatie‑diagram.

Het volgende voorbeeld stelt de overlapping in voor de groep die de eerste serie bevat:

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

![De overlapping van de series](series_overlap.png)

## **Wijzig de vulkleur van de serie**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) om de standaardvulling voor een hele serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) instelling de serievulling voor dat punt.

Het volgende voorbeeld past een doorzichtige blauwe vulling toe op de eerste serie:

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

![De kleur van de serie](series_color.png)

## **Wijzig de serienaam**

Een serienaam wordt opgeslagen in de diagramgegevens‑werkmap en normaal weergegeven in de legenda. In de standaardwerkmap die wordt aangemaakt voor een gegroepeerd kolomdiagram, staat cel B1 op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel bijwerken die al wordt gerefereerd door [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--). Deze aanpak voorkomt dat je een bepaalde rij en kolom in een bestaand diagram moet aannemen:

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

![De serienaam](series_name.png)

### **Maak een serie met een naam uit meerdere cellen**

Een samengestelde serienaam is handig wanneer een productnaam en een rapportageperiode in afzonderlijke werkmapcellen staan. Je kunt bijvoorbeeld `Product A` in B1 en `2026` in C1 combineren tot één serienaam, terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) om het naam‑bereik op te halen, en geef die collectie door aan [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één serie en twee gegevenspunten. Cellen B1:C1 leveren alleen de serienaam; A2:A3 leveren de categorielabels, en B2:B3 de numerieke waarden.

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

De resulterende serienaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één vermelding voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Kolomdiagram met noord‑ en zuidwaarden en de samengestelde serienaam Product A 2026 in de legenda](composite_series_name.png)

## **Haal de automatische vulkleur van de serie op**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die is berekend op basis van de seriereeks en de diagramstijl als een Android ARGB‑kleur‑integer. Dit is de kleur die wordt gebruikt wanneer de serievulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt het automatische kleur‑integer van elke standaardserie af:

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

De exacte gehele getallen hangen af van de diagramstijl en het thema.

## **Stel omgekeerde vulkleur in voor een diagramserie**

Voor balk‑, kolom‑ en bubbel‑series kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden weergeven met een andere vulling. Stel de reguliere serievulling in op doorzichtig, schakel inversie in en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in de werkmap; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramgegevens door één serie. Werkblad‑rij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De omgekeerde doorzichtige vulkleur](inverted_solid_fill_color.png)

Je kunt inversie voor één punt inschakelen via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Wis een specifieke gegevenspuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkmapcel in op `null`. Voor een kolomdiagram is de weergegeven waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Het gegevenspunt blijft op dezelfde categoriep­ositie staan, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Scatter‑diagrammen gebruiken afzonderlijke X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk gegevenspunt uit de collectie.

## **Beheer de weergave van lege cellen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Om gegevens uit verborgen rijen en kolommen van een werkblad op te nemen of uit te sluiten, zie [Include Data from Hidden Rows and Columns](/slides/nl/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkmapcel staat voor ontbrekende gegevens; een cel die `0` bevat, staat voor een bekende numerieke waarde. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling is van toepassing op het gehele diagram. Hij verandert hoe lege waarden worden getekend, zonder de lege werkmapcel met nul of een geïnterpoleerde waarde te vullen.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één serie, wist de waarde voor Dag 3, en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand nodig. De [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

    // Laat Dag 3 echt leeg, maar behoud de categorie en het gegevenspunt.
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

Elk uitvoerbestand slaat de voor het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs je de gewenste modus toe en sla je de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in de werkmap in elk geval leeg:

![Lijndiagrammen met identieke gegevens: Gap verbreekt de lijn bij Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk te vergelijken. Balk‑ en kolomdiagrammen hebben geen lijn om over een ontbrekende categorie te verbinden, zodat `Span` niet het verbindingssegment kan produceren dat hierboven wordt getoond; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook gelijk uitzien. Evenzo heeft een scatter‑diagram met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de uitvoer voor het type dat je gebruikt.

## **Stel de gatbreedte van de serie in**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolom‑clusters, uitgedrukt als een percentage van de breedte van de balk of kolom. Net als overlapping behoort het tot de bovenliggende seriegroep in plaats van tot één serie. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichterbij.

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

## **Veelgestelde vragen**

**Welke diagramtypen ondersteunen gegevensseries?**

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) enumeratie gebruiken diagramgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidings‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de gegevenspunt‑creatiemethode die past bij het serietype. Opties zoals overlapping en gatbreedte gelden alleen voor compatibele balk‑ of kolom‑groepen.

**Wat is een diagramseriegroep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatie‑diagram kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één serie wordt bereikt niet noodzakelijk elke serie in het diagram wijzigt.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldseries, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de serie‑ als categoricollecties wissen voordat je een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram maken zonder standaardgegevens.

**Hoe zijn diagramobjecten gekoppeld aan werkmapcellen?**

Serienamen, categorielabels en gegevenspuntwaarden verwijzen naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer je aangepaste gegevens bouwt, houd je de rijen voor categorieën en de rijen voor seriewaarden op één lijn zodat elk punt onder de beoogde categorie wordt getekend.

**Hoe kan ik één punt wissen in plaats van de hele serie?**

Stel de relevante waardecel in op `null` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer je alle punten uit die serie wilt verwijderen. Als je ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden in lijn blijven met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde die is geconfigureerd via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Ondersteunde diagrammen kunnen leegtes weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende gegevens in je presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series roep je [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stel je de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Je kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete gegevenspunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet gedefinieerd is, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlapping en gatbreedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet voor het aantal series dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal series. In de praktijk bepalen bestandslimieten van de presentatie, beschikbare geheugen, render‑tijd en de leesbaarheid van het diagram een praktische bovengrens.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende seriegroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.