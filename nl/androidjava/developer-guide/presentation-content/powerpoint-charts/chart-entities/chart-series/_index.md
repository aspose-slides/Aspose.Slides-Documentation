---
title: Beheer diagramseries in presentaties op Android
linktitle: Dataseries
type: docs
url: /nl/androidjava/chart-series/
keywords:
- grafiekserie
- series‑overlap
- serieskleur
- seriesnaam
- datapunt
- werkboekcel
- series‑gap
- negatieve waarde
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u diagramseries, datapunten, werkboekcellen, opmaak, overlap, gapbreedte en negatieve waarden beheert in presentaties op Android."
---
## **Overzicht**

Een diagram kan zijn afgebeelde waarden opslaan in werkboekcellen of rechtstreeks als numerieke literals. Een [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elke [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) vertegenwoordigt een punt in die serie. [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/)‑objecten leveren de labels of groepeervelden die door de series gedeeld worden. In diagrammen die met standaardgegevens zijn aangemaakt, gebruiken serie‑namen, categorieën en puntwaardes [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/)-objecten uit het diagram‑werkboek.

Voor een typische categorie‑diagram gebruikt het standaard‑werkboek rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor series‑waarden. Werkblad‑, rij‑ en kolom‑indexen die worden doorgegeven aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) zijn nul‑gebaseerd. Deze indeling is handig wanneer je een diagram met standaarddata maakt, maar ga er niet van uit dat elk bestaand diagram dit gebruikt. Voor een geladen presentatie inspecteer je de cellen die door de series, categorieën en datapunten worden gerefereerd voordat je werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende reikwijdtes:

- Instellingen op serieniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--), bepalen het standaard uiterlijk voor alle punten in één serie.  
- Instellingen per datapunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven het serie‑uiterlijk voor één punt.  
- Groepsinstellingen gelden voor compatibele series die behoren tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/). Toegang tot de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer je opties zoals overlap of tussenruimte‑breedte moet instellen.

Wanneer er geen expliciete punt‑ of series‑vulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voor dat punt de voorkeur.

![grafiek-serie-powerpoint](chart-series-powerpoint.png)

## **Seriewaarden instellen met numerieke literals**

Gebruik numerieke literals wanneer serieswaarden afkomstig zijn van toepassingsdata of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Roep [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) aan met [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) vóór je elke punt‑[getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) resultaat toewijst via [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

De collectiesetting bepaalt het brontype van alle puntwaarden in die serie. De methode [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) van elke puntwaarde geeft het geselecteerde type terug; wijzig dit via de collectiesetting. Met `Worksheet` gebruik je [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) om toegang te krijgen tot de gerefereerde cel. Met `DoubleLiterals` gebruik je [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) of `setAsLiteralDouble` om het getal direct te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomdiagram met standaard series en categorieën, en kent vervolgens berekende waarden 10, 20, enzovoort toe aan de bestaande punten van de eerste serie. Het slaat de presentatie op, opent deze opnieuw en print de opgeslagen waarden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Het punt‑waarde‑brontype staat los van [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--), dat de interne of externe werkboekconfiguratie van het diagram identificeert. Het gebruik van numerieke literals verwijdert niet automatisch het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, serienamen en de overige series. Zie [Chart Workbook](/slides/nl/androidjava/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbel‑diagrammen gebruik je [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) en [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) om de bronnen voor [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) en [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) te kiezen. Bubbel‑diagrammen gebruiken bovendien [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) voor [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Stel elke toepasselijke bron in op `DoubleLiterals` voordat je nummers toewijst via de `setAsLiteralDouble`‑methode van die waarde.

## **Overlap van diagramseries instellen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 percent. Het is een alleen‑lezen weergave van de instelling op de bovenliggende series‑groep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele serie in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen tonen; hij heeft geen effect op niet‑gerelateerde series‑groepen in een combinatiediagram.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste serie bevat:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Het nieuwe diagram bevat voorbeeldseries, categorieën en waarden.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De serie‑overlap](series_overlap.png)

## **Kleur van de serienvulling wijzigen**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) om de standaard vulling voor een volledige serie in te stellen. Als een punt al een expliciete vulling heeft, heeft de [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)‑instelling voor dat punt voorrang op de serie‑vulling.

Het volgende voorbeeld past een egale blauwe vulling toe op de eerste serie:

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

![De kleur van de serie](series_color.png)

## **Naam van de serie wijzigen**

Een serienaam wordt opgeslagen in het diagram‑werkboek en normaal weergegeven in de legenda. In het standaard‑werkboek dat voor een gegroepeerd kolomdiagram wordt aangemaakt, staat cel B1 (rij 0, kolom 1) met de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel updaten die al wordt gerefereerd door [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--). Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaand diagram:

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

![De serienaam](series_name.png)

### **Maak een serie met een naam uit meerdere cellen**

Een samengestelde serienaam is nuttig wanneer een productnaam en een rapportage‑periode in afzonderlijke werkboekcellen zijn opgeslagen. Bijvoorbeeld, je kunt `Product A` in B1 en `2026` in C1 combineren tot één serienaam terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) om het naam‑bereik op te halen, en geef die collectie vervolgens door aan [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. In dit voorbeeld wordt `false` gebruikt om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één serie en twee datapunten. Cellen B1:C1 leveren alleen de serienaam; A2:A3 leveren de categorie‑labels, en B2:B3 leveren de numerieke waarden.

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

    // Aparte cellen leveren de categorieën en numerieke datapunten.
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

![Kolomdiagram met Noord‑ en Zuid‑waarden en de samengestelde serienaam Product A 2026 in de legenda](composite_series_name.png)

## **Automatische seriekleur ophalen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die berekend wordt op basis van de serie‑index en de diagramstijl, als een Android ARGB‑kleur‑integer. Dit is de kleur die gebruikt wordt wanneer de serievulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijzigt geen vulling.

Het volgende voorbeeld print de automatische kleuring van elke standaardserie:

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

## **Omgekeerde vulkleur voor een diagramserie instellen**

Voor balk‑, kolom‑ en bubbel‑series kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden weergeven met een andere vulling. Stel de reguliere serievulling in op een effen kleur, activeer inversie, en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramdata door één serie. Werkbladrij 0 bevat de serienaam, kolom 0 de categorienamen, en kolom 1 de waarden:

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

![De omgekeerde effen vulkleur](inverted_solid_fill_color.png)

Je kunt inversie voor één punt inschakelen via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

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

## **Waarde van een specifiek datapunt wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkboekcel in op `null`. Voor een kolomdiagram is de afgebeelde waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Het datapunt blijft op dezelfde categorielocatie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden.

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

Spreidings‑diagrammen gebruiken afzonderlijke X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken bovendien een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep niet [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Weergave van lege cellen beheren**

Verborgen cellen die waarden bevatten vormen een ander geval dan lege cellen. Om data uit verborgen rijen en kolommen van een werkblad op te nemen of uit te sluiten, zie [Include Data from Hidden Rows and Columns](/slides/nl/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel staat voor ontbrekende data; een cel met `0` staat voor een bekende numerieke waarde. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het gehele diagram. Hij wijzigt hoe lege waarden worden uitgezet, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één serie, wist de waarde voor Dag 3 en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand vereist. De [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke data zijn `10, 20, empty, 30, 40`.

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

    // Laat Dag 3 echt leeg, terwijl je de categorie en datapunt behoudt.
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

Elk uitvoerbestand slaat de modus op die is ingesteld vóór het opslaan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stel je de gewenste modus in en sla je de presentatie eenmaal op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Lijndiagrammen met identieke data: Gap verbreekt de lijn op Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi makkelijk vergelijkbaar. Balk‑ en kolomdiagrammen hebben geen lijn om over een ontbrekende categorie te verbinden, zodat `Span` niet het verbindingssegment kan produceren dat hierboven wordt getoond; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook gelijk uitzien. Evenzo heeft een spreidings‑diagram met alleen markers geen verbindingslijn. Verwacht daarom niet drie verschillende resultaten voor elk diagramtype; controleer de uitvoer voor het type dat je gebruikt.

## **Tussenruimte‑breedte van de serie instellen**

De tussenruimte‑breedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort deze instelling tot de bovenliggende series‑groep in plaats van tot één serie. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de tussenruimte‑breedte en slaat alleen de uiteindelijke presentatie op:

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

![De tussenruimte‑breedte](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen dataseries?**

Alle diagramtypen die door de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/)‑enumeratie worden vertegenwoordigd gebruiken diagramdata, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidings‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de datapunten‑creatiemethode die past bij het type serie. Opties zoals overlap en tussenruimte‑breedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagram‑series‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, hoeft niet per se elke serie in het diagram te wijzigen.

**Bevat een nieuw aangemaakt diagram standaarddata?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldseries, categorieën en waarden aan. Je kunt die cellen bewerken of zowel de series‑ als de categorieverzamelingen wissen voordat je een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram maken zonder standaarddata.

**Hoe worden diagramobjecten gekoppeld aan werkboekcellen?**

Serienamen, categorielabels en datapuntwaarden refereren cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer je aangepaste data bouwt, houd de rijen voor categorieën en de rijen voor serie‑waarden op elkaar afgestemd zodat elk punt onder de beoogde categorie wordt uitgezet.

**Hoe kan ik één punt wissen in plaats van de hele serie?**

Stel de betreffende waarde‑cel in op `null` om de positie van de categorielabel van het punt te behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer je alle punten uit die serie wilt verwijderen. Als je ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden blijven overeenkomen met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) geconfigureerde instelling. Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende data in je presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series roep je [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stel je de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Je kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlap en tussenruimte‑breedte regelen de lay‑out en zijn geen opmaak‑overschrijvingen op puntniveau.

**Is er een limiet aan het aantal series dat een diagram kan bevatten?**

Aspose.Slides legt geen apart vast limiet op voor het aantal series. In de praktijk bepalen de beperkingen van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij of te ver van elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende series‑groep. Verhoog de waarde om de ruimte tussen de clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.