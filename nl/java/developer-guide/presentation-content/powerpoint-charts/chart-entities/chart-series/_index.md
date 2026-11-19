---
title: Beheer grafiekreeksen in presentaties in Java
linktitle: Gegevensreeksen
type: docs
url: /nl/java/chart-series/
keywords:
- grafiekreeksen
- reeks overlapping
- reeks kleur
- reeksnaam
- datapunten
- werkboekcellen
- reeks tussenruimte
- negatieve waarde
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkboekcellen, opmaak, overlapping, tussenbreedte en negatieve waarden in presentaties kunt beheren met Java."
---
## **Overzicht**

Een diagram kan zijn uitgeplotte waarden opslaan in werkbladcellen of rechtstreeks als numerieke letterlijke waarden. Een [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) vertegenwoordigt één set verwante waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) vertegenwoordigt een punt in die reeks. [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/)‑objecten leveren de labels of groeperingswaarden die door de reeksen gedeeld worden. In diagrammen die met standaarddata zijn aangemaakt, gebruiken reeksnamen, categorieën en puntwaarden [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/)‑objecten uit het diagramwerkboek.

Voor een typische categorie‑diagram gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de resterende cellen voor reekswaarden. Werkblad‑, rij‑ en kolomindexen die worden doorgegeven aan [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaarddata maakt, maar ga er niet vanuit dat elk bestaand diagram het zo gebruikt. Voor een geladen presentatie, inspecteer de cellen waarnaar de reeksen, categorieën en datapoints verwijzen voordat u werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), geven de standaardopmaak voor alle punten in één reeks.
- Instellingen per datapunt, zoals [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), overschrijven de reeksopmaak voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) behoren. Benader de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) wanneer u opties wilt instellen zoals overlap of tussenruimte.

Wanneer er geen expliciete punt‑ of reeksvulling is ingesteld, bepalen de diagramstijl en het thema de automatische weergave. Wanneer zowel reeks‑ als puntopmaak aanwezig zijn, heeft de puntopmaak voorrang voor dat punt.

![grafiek-reeks-powerpoint](chart-series-powerpoint.png)

Voor een gegroepeerde cilinderschijf‑diagram, zie hoe [het wijzigen van het 3D‑reeks‑type of de staafvorm](/slides/nl/java/3d-chart/#change-the-3d-series-type-and-bar-shape) de eerste reeks beïnvloedt.

## **Reekswaarden Instellen Met Numerieke Letterlijke Waarden**

Gebruik numerieke letterlijke waarden wanneer reekswaarden afkomstig zijn van toepassingsdata of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Roep [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) aan met [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) voordat u het resultaat van elk punt‑[getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) toewijst via [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

De collectiesetting bepaalt het brontype van alle puntwaarden in die reeks. De [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--)‑methode van elk punt meldt het gekozen type; wijzig het via de collectiesetting. Met `Worksheet` gebruikt u [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) om de verwijzende cel te benaderen. Met `DoubleLiterals` gebruikt u [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) of `setAsLiteralDouble` om het getal direct te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomdiagram met standaardreeksen en -categorieën, en kent vervolgens berekende waarden 10, 20, enz. toe aan de bestaande punten van de eerste reeks. Het slaat de presentatie op, opent deze opnieuw en drukt de opgeslagen waarden af.

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

Het bron‑type van de puntwaarde staat los van [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), dat de interne of externe werkboekconfiguratie van het diagram identificeert. Het gebruik van numerieke letterlijke waarden verwijdert niet automatisch het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, reeksnamen en de andere reeksen. Zie [Chart Workbook](/slides/nl/java/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbel‑diagrammen gebruikt u [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) en [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) om de bronnen voor [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) en [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) te kiezen. Bubbel‑diagrammen gebruiken ook [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) voor [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Stel elke toepasselijke bron in op `DoubleLiterals` voordat u getallen toewijst via de `setAsLiteralDouble`‑methode van die waarde.

## **Overlap van de Diagramreeksen Instellen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) geeft aan hoeveel staven of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeks‑groepsobject. Gebruik [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde staven of kolommen weergeven; hij beïnvloedt geen niet‑gerelateerde reeksgroepen in een combinatiediagram.

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

![De overlap van de reeks](series_overlap.png)

## **Kleur van de Reeksvulling Wijzigen**

Gebruik [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‑instelling de reeksvulling voor dat punt.

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

![De kleur van de reeks](series_color.png)

## **Naam van de Reeks Wijzigen**

Een reeksnamen wordt opgeslagen in het diagram‑werkboek en doorgaans weergegeven in de legende. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerde kolomdiagram, staat cel B1 op rij 0, kolom 1 en bevat deze de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--). Deze aanpak voorkomt dat u een bepaalde rij‑ en kolompositie moet veronderstellen in een bestaand diagram:

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

![De naam van de reeks](series_name.png)

### **Een Reeks Maken met een Naam uit Meerdere Cellen**

Een samengestelde reeksnamen is nuttig wanneer een productnaam en een rapportage‑periode in afzonderlijke werkbladcellen worden opgeslagen. U kunt bijvoorbeeld `Product A` in B1 combineren met `2026` in C1 tot één reeksnamen, terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) om het naam‑bereik op te halen, en geef die collectie vervolgens door aan [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één reeks en twee datapoints. Cellen B1:C1 leveren alleen de reeksnamen; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

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

    // Deze twee cellen leveren de naam van de reeks.
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

De resulterende reeksnamen is `Product A 2026`, met een spatie tussen de twee celwaarden. De legende toont dit als één invoer voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Kolomdiagram met Noord‑ en Zuid‑waarden en de samengestelde reeksnamen Product A 2026 in de legende](composite_series_name.png)

## **Automatische Reekskleur Ophalen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) retourneert de kleur die wordt berekend op basis van de reeks‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijzigt geen vulling.

Het volgende voorbeeld drukt de automatische kleur af van elke standaardreeks:

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

## **Omgekeerde Vulkleur Instellen voor een Diagramreeks**

Voor staaf‑, kolom‑ en bubbelreeksen kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatieve waarden met een andere vulling weergeven. Stel de reguliere reeksvulling in op een effen kleur, schakel inversie in, en wijs de negatieve‑kleur toe via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negatieve getallen blijven onveranderd in het werkboek; alleen de weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramdata door één reeks. Werkbladrij 0 bevat de reeksnamen, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De omgekeerde solide vulkleur](inverted_solid_fill_color.png)

U kunt inversie inschakelen voor één punt via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In het volgende voorbeeld wordt inversie uitgeschakeld voor de reeks en alleen voor het geselecteerde punt ingeschakeld. Het punt krijgt tevens een negatieve waarde zodat het effect zichtbaar is:

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

## **Een Specifieke Datapuntwaarde Wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolomdiagram is de uitgeplotte waarde beschikbaar via [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Het datapunt blijft op dezelfde categorietoestand, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Spreidingsdiagrammen gebruiken afzonderlijke X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert alle datapoints uit de collectie.

## **Weergave van Lege Cellen Besturen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Om gegevens uit verborgen werkbladrijen en -kolommen wel of niet op te nemen, zie [Gegevens Uit Verborgen Rijen en Kolommen Opnemen](/slides/nl/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel stelt ontbrekende gegevens voor; een cel met `0` stelt een bekende numerieke waarde voor. Roep [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling is van toepassing op het gehele diagram. Hij verandert de manier waarop leegtes worden uitgebeeld, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één reeks, wist de waarde voor Dag 3, en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand vereist. De [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de reeksnamen. De uiteindelijke data is `10, 20, leeg, 30, 40`.

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

    // Laat dag 3 echt leeg, terwijl de categorie en het datapunt behouden blijven.
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

Elk uitvoerbestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie één keer op in plaats van over alle modi te itereren.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Lijndiagrammen met identieke data: Gap verbreekt de lijn op Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk te vergelijken. Staaf‑ en kolomdiagrammen hebben geen lijn om een ontbrekende categorie te verbinden, dus `Span` kan de verbindingssegment niet produceren; een missende kolom en een nul‑hoogte kolom kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsdiagram met alleen markers geen verbindingslijn. Verwacht geen drie verschillende resultaten voor elk diagramtype; controleer de uitvoer voor het type dat u gebruikt.

## **Tussenruimte van de Reeks Instellen**

De tussenruimte is de ruimte tussen aangrenzende staaf‑ of kolomclusters, uitgedrukt als een percentage van de staaf‑ of kolombreedte. Net als overlap behoort deze instelling tot de bovenliggende reeks‑groep in plaats van tot één enkele reeks. Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) eenmaal voor de groep aan. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld verandert de tussenruimte en slaat alleen de uiteindelijke presentatie op:

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

![De tussenruimte](gap_width.png)

## **Reeks‑Lijnen Tonen of Verbergen**

Reeks‑lijnen verbinden visueel gerelateerde delen van een diagram. Gebruik [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) om ze weer te geven of te verbergen in ondersteunde gestapelde staaf‑ en OfPie‑diagrammen. In tweedimensionale gestapelde staaf‑ en kolomdiagrammen verbinden ze overeenkomstige stapelgrenzen over categorieën. In Pie of Pie‑ en Bar of Pie‑diagrammen verbinden ze de hoofdplot met de secundaire plot. Deze instelling is geen algemene connector voor andere diagramtypen.

Benader de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). De instelling geldt voor elke reeks in die groep. [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#hasSeriesLines--) is alleen‑lezen en weerspiegelt de instelling van de bovenliggende groep; roep de setter van de groep aan om deze bij te werken.

Het volgende voorbeeld maakt één [PieOfPie](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#PieOfPie) diagram met standaarddata. Het slaat hetzelfde diagram op met reeks‑lijnen ingeschakeld en vervolgens uitgeschakeld, waardoor twee presentaties voor vergelijking ontstaan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Reekslijnen ingeschakeld | Reekslijnen uitgeschakeld |
| --- | --- |
| ![Pie‑of‑Pie‑diagram met reekslijnen ingeschakeld](series_lines_enabled.png) | ![Pie‑of‑Pie‑diagram met reekslijnen uitgeschakeld](series_lines_disabled.png) |
| De twee lijnen verbinden de hoofd‑pie met de secundaire pie. | Beide pies blijven zichtbaar, maar de verbindingslijnen zijn verborgen. |

Reeks‑lijnen verschillen van leader‑lijnen van gegevenslabels, die labels met hun datapoints verbinden; van rasterlijnen, die intervallen langs de assen markeren; en van de lijnen in een lijndiagram, die gegevenswaarden weergeven. Deze instelling regelt die elementen niet.

## **FAQ**

**Welke diagramtypen ondersteunen gegevensreeksen?**

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑enumeratie gebruiken diagramdata, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de datapunt‑creatiemethode die overeenkomt met het type reeks. Opties zoals overlap en tussenruimte gelden alleen voor compatibele staaf‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de via één reeks bereikbare groep verandert niet per‑se elke reeks in het diagram.

**Bevat een nieuw aangemaakt diagram standaarddata?**

Ja. Standaard maakt [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) voorbeeldreeksen, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de reeksen‑ als categorie‑collecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram zonder standaarddata aanmaken.

**Hoe zijn diagramobjecten gekoppeld aan werkbladcellen?**

Reeksnamen, categorielabels en datapuntwaarden refereren naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste data opbouwt, houd de rijen voor categorieën en de rijen voor reekswerte op één lijn zodat elk punt onder de gewenste categorie wordt uitgezet.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de betreffende waarde‑cel in op `null` om de puntpositie te behouden als een leeg punt. Gebruik [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) alleen wanneer u alle punten uit die reeks wilt verwijderen, want die methode verwijdert elke datapunt uit de collectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) geconfigureerde waarde. Ondersteunde diagrammen kunnen leegtes weergeven als gaten, als nul‑waarden, of door aangrenzende punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende data in uw presentatie. Zie [Weergave van Lege Cellen Besturen](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde staaf‑, kolom‑ en bubbelreeksen roept u [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) aan en stelt u de kleur in die wordt geretourneerd door [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt worden opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer die niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlap en tussenruimte regelen de lay‑out en zijn geen punt‑niveau opmaakoverschrijvingen.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen apart vaste limiet op voor het aantal reeksen. In de praktijk bepalen bestandsbeperkingen, beschikbaar geheugen, render‑tijd en leesbaarheid van het diagram een bruikbare grens.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) aan op de betreffende bovenliggende reeks‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag de waarde om de clusters dichter bij elkaar te brengen.