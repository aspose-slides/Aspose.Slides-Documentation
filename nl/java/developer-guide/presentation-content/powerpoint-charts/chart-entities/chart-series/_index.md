---
title: Beheer diagramdataseries in presentaties in Java
linktitle: Dataseries
type: docs
url: /nl/java/chart-series/
keywords:
- diagramreeks
- reeks overlap
- reeks kleur
- reeksnaam
- datumpunt
- werkboekcel
- reeks gat
- negatieve waarde
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunten, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden kunt beheren in presentaties met Java."
---
## **Overzicht**

Een diagram kan zijn getekende waarden opslaan in werkboekcellen of rechtstreeks als numerieke letterlijke waarden. Een [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) vertegenwoordigt een punt in die reeks. [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/)‑objecten leveren de labels of groeperingswaarden die door de reeksen worden gedeeld. In diagrammen die met standaardgegevens zijn aangemaakt, gebruiken serienaam‑, categorie‑ en puntwaarden [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/)‑objecten uit het werkboek van het diagram.

Voor een typisch categorie‑diagram gebruikt het standaardwerkboek rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor seriewaarden. Werkblad‑, rij‑ en kolom‑indexes die worden doorgegeven aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) zijn nul‑gebaseerd. Deze indeling is handig wanneer je een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram dit volgt. Voor een geladen presentatie, inspecteer de cellen waarnaar de reeksen, categorieën en datapunten verwijzen voordat je werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende toepassingsgebieden:

- Instellingen op serieniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), bieden de standaardweergave voor alle punten in één reeks.
- Instellingen per datumpunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven de serieweergave voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) behoren. Open de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer je opties moet instellen zoals overlap of gatbreedte.

Wanneer er geen expliciete punt‑ of serievulling is ingesteld, bepalen diagramstijl en thema het automatische uiterlijk. Wanneer zowel serie‑ als punt‑formattering aanwezig zijn, heeft de punt‑formattering voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Seriewaarden instellen met numerieke letterlijke waarden**

Gebruik numerieke letterlijke waarden wanneer seriewaarden afkomstig zijn van toepassingsdata of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Roep [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) aan met [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) voordat je voor elk punt de [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--)‑resultaat toewijst via [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

De collectiesetting bepaalt het brontype van alle puntwaarden in die reeks. De [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--)‑methode van elke puntwaarde geeft het geselecteerde type terug; wijzig het via de collectiesetting. Met `Worksheet` gebruik je [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) om de verwijzende cel te benaderen. Met `DoubleLiterals` gebruik je [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) of `setAsLiteralDouble` om het getal rechtstreeks te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomdiagram met standaardreeksen en -categorieën, en kent vervolgens berekende waarden 10, 20, enzovoort toe aan de bestaande punten van de eerste reeks. Het slaat de presentatie op, opent deze opnieuw en drukt de opgeslagen waarden af.

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

Het brontype van de puntwaarde staat los van [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), dat de interne of externe werkboekconfiguratie van het diagram identificeert. Het gebruik van numerieke letterlijke waarden verwijdert niet automatisch het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, serienamen en de overige reeksen. Zie [Chart Workbook](/slides/nl/java/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbel‑diagrammen gebruik je [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) en [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) om de bronnen voor [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) en [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) te kiezen. Bubbel‑diagrammen gebruiken ook [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) voor [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Stel elke toepasselijke bron in op `DoubleLiterals` voordat je getallen toewijst via de `setAsLiteralDouble`‑methode van die waarde.

## **De overlap van diagramreeksen instellen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van –100 tot 100 percent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende seriegroep. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen weergeven; hij heeft geen invloed op ongerelateerde seriegroepen in een combinatie‑diagram.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

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

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‑instelling de serievulling voor dat punt.

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

## **De serienaam wijzigen**

Een serienaam wordt opgeslagen in het diagram‑werkboek en normaal weergegeven in de legenda. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerd kolomdiagram bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel bijwerken die al wordt verwezen door [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--). Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaand diagram:

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

### **Een reeks maken met een naam uit meerdere cellen**

Een samengestelde serienaam is nuttig wanneer een productnaam en een rapportage‑periode in afzonderlijke werkboekcellen staan. Je kunt bijvoorbeeld `Product A` in B1 en `2026` in C1 combineren tot één serienaam terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) om het naam‑bereik op te halen, en geef die collectie door aan [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één reeks en twee datapunten. Cellen B1:C1 leveren alleen de serienaam; A2:A3 leveren de categorielabels, en B2:B3 de numerieke waarden.

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

De resulterende serienaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één entry voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **De automatische vulkleur van de reeks ophalen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die wordt berekend op basis van de reeks‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de serievulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijzigt geen vulling.

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

Voorbeeldoutput voor de standaarddiagramstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Inversie‑vulkleur voor een diagramreeks instellen**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden met een andere vulling weergeven. Stel de reguliere serievulling in op solide, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergevenkleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramdata door één reeks. Werkbladrij 0 bevat de serienaam, kolom 0 de categorienamen, en kolom 1 de waarden:

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

Je kunt inversie voor één punt inschakelen via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

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

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkboekcel in op `null`. Voor een kolomdiagram is de getekende waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Het datumpunt blijft op dezelfde categorische positie staan, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden.

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

Spreidings‑diagrammen gebruiken afzonderlijke X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een grootte‑cel. Wis alleen de cel die de te verwijderen waarde vertegenwoordigt. Roep niet [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk datumpunt uit de collectie.

## **De weergave van lege cellen beheren**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Om gegevens uit verborgen werkblad‑rijen en -kolommen op te nemen of uit te sluiten, zie [Include Data from Hidden Rows and Columns](/slides/nl/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel staat voor ontbrekende data; een cel met `0` staat voor een bekende numerieke waarde. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numeriek nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het gehele diagram. Het wijzigt hoe lege waarden worden getekend, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende autonome voorbeeld maakt een lijndiagram met één reeks, wist de waarde voor Dag 3, en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand nodig. De [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke data is `10, 20, empty, 30, 40`.

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

Elk uitvoerbestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stel je de gewenste modus in en sla je de presentatie één keer op in plaats van de modi te itereren.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk te vergelijken. Balk‑ en kolomdiagrammen hebben geen lijn die over een ontbrekende categorie kan worden doorgetrokken, dus `Span` kan de verbindingssegmenten niet produceren die hierboven worden getoond; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook vergelijkbaar uitzien. Evenzo heeft een spreidings‑diagram met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de output voor het type dat je gebruikt.

## **De gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolom‑clusters, uitgedrukt als een percentage van de balk‑ of kolom‑breedte. Net als overlap behoort dit tot de bovenliggende seriegroep en niet tot één enkele reeks. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) één keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter op elkaar.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de definitieve presentatie op:

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

**Welke diagramtypen ondersteunen dataseries?**

Alle diagramtypen die door de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑enumeratie worden vertegenwoordigd, gebruiken diagramdata, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidings‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de datumpunt‑creatiemethode die past bij het serietype. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) bevat compatibele reeksen die groeps‑level plot‑instellingen delen. Een combinatie‑diagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet per se elke reeks in het diagram.

**Bevat een nieuw aangemaakt diagram standaarddata?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldreeksen, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de reeksen‑ als de categoricollecties wissen voordat je een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram zonder standaarddata aanmaken.

**Hoe zijn diagramobjecten gekoppeld aan werkboekcellen?**

Serienamen, categorielabels en datumpuntwaarden verwijzen naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een verwezen cel werkt het overeenkomstige diagramonderdeel bij. Wanneer je aangepaste data opbouwt, houd dan de categorierijen en de rijen met serie‑waarden op één lijn zodat elk punt onder de beoogde categorie wordt getekend.

**Hoe kan ik één punt wissen in plaats van de hele reeks?**

Stel de betreffende waardecel in op `null` om de positie van de punt in de categorie te behouden als een lege punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer je alle punten uit die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden nog steeds op één lijn staan met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde die is geconfigureerd via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van missende data in jouw presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roep je [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stel je de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Je kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt worden opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet aan het aantal reeksen vast. In de praktijk bepalen bestands‑beperkingen, beschikbaar geheugen, render‑tijd en leesbaarheid van het diagram een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de juiste bovenliggende seriegroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.