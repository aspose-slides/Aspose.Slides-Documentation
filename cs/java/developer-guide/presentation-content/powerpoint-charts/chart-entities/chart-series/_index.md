---
title: Správa datových sérií grafu v prezentacích v Javě
linktitle: Datové série
type: docs
url: /cs/java/chart-series/
keywords:
- série grafu
- překrytí sérií
- barva sérií
- název série
- datový bod
- buňka sešitu
- mezera mezi sériemi
- záporná hodnota
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích v Javě."
---
## **Přehled**

Graf může ukládat své vykreslené hodnoty do buněk sešitu nebo přímo jako číselné literály. [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) představuje jednu sadu souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) představuje bod v této sérii. Objekt [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) poskytuje popisky nebo skupinové hodnoty sdílené sériemi. V grafech vytvořených s výchozími daty se názvy sérií, kategorie a hodnoty bodů používají objekty [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) ze sešitu grafu.

Pro typický kategoriální graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) jsou nulové (zero‑based). Toto uspořádání je užitečné při vytváření grafu s výchozími daty, ale nepředpokládejte, že jej používá každý existující graf. U načtené prezentace si před změnou hodnot sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různá rozsahy:

- Nastavení na úrovni série, např. [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, např. [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), přepíše vzhled série pro jeden konkrétní bod.
- Skupinová nastavení se vztahují na kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/). Přístup ke skupině získáte pomocí [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) v případě, že potřebujete nastavit například překrytí nebo šířku mezery.

Když není explicitně nastaveno vyplnění bodu nebo série, určuje automatický vzhled styl a motiv grafu. Pokud jsou přítomna jak nastavení série, tak nastavení bodu, má přednost formátování bodu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení hodnot série pomocí číselných literálů**

Používejte číselné literály, když hodnoty série pocházejí z aplikačních dat nebo výpočtů a nepotřebují odkazy na buňky listu. Zavolejte [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) s [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) před přiřazením výsledku [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) každého bodu pomocí [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

Nastavení kolekce řídí typ zdroje všech hodnot bodů v dané sérii. Metoda [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) každé hodnoty bodu vrací vybraný typ; změňte jej přes nastavení kolekce. S `Worksheet` použijte [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) pro přístup k odkazované buňce. S `DoubleLiterals` použijte [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) nebo `setAsLiteralDouble` pro přímé čtení nebo zápis čísla.

Následující příklad vytvoří sloupcový graf s výchozími sériemi a kategoriemi a poté přiřadí vypočítané hodnoty 10, 20 atd. k existujícím bodům první série. Uloží prezentaci, znovu ji otevře a vytiskne uložené hodnoty.

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

Typ zdroje hodnoty bodu je oddělený od [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), který určuje interní nebo externí konfiguraci sešitu grafu. Použití číselných literálů samo o sobě neodstraní vložený sešit. V tomto příkladu zůstává sešit dostupný pro popisky kategorií, názvy sérií a ostatní série. Viz [Chart Workbook](/slides/cs/java/chart-workbook/) pro správu sešitu.

Pro rozptylové a bublinové grafy použijte [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) k výběru zdrojů pro [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) a [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--). Bublinové grafy také používají [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) pro [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Nastavte každý příslušný zdroj na `DoubleLiterals` před přiřazením čísel metodou `setAsLiteralDouble` dané hodnoty.

## **Nastavení překrytí sérií grafu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) vrací, jak moc se překrývají pruhy nebo sloupce v 2D grafu, v rozmezí od -100 do 100 procent. Jedná se o jen‑čtení projekci nastavení v nadřazené skupině sérií. Pro aktualizaci všech kompatibilních sérií ve skupině použijte [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-). Tato možnost platí pro typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první sérii:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Nový graf obsahuje ukázkové série, kategorie a hodnoty.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy výplně série**

Použijte [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) pro nastavení výchozí výplně celé série. Pokud má bod již explicitní výplň, jeho nastavení [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) přepíše výplň série pro tento bod.

Následující příklad aplikuje jednotnou modrou výplň na první sérii:

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

Výsledek:

![The color of the series](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu dat grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 na řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně uvádějí:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

Výsledek:

![The series name](series_name.png)

### **Vytvoření série s názvem z více buněk**

Složený název série je užitečný, když je název produktu a období reportování uloženy v samostatných buňkách sešitu. Například můžete zkombinovat `Product A` v B1 a `2026` v C1 do jediného názvu série a přitom nechat obě části propojené se svými zdrojovými buňkami.

Použijte [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) k načtení rozsahu názvu a pak tuto kolekci předáte metodě [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Argument `skipHiddenCells` určuje, zda jsou skryté buňky zahrnuty: `true` je vyloučí, `false` zahrne. Tento příklad používá `false`, aby zahrnul každou buňku v rozsahu názvu.

Následující příklad vytvoří prezentaci s jednou sérií a dvěma datovými body. Buňky B1:C1 poskytují pouze název série; A2:A3 poskytují popisky kategorií a B2:B3 číselné hodnoty.

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

    // Tyto dvě buňky dodávají název série.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Samostatné buňky dodávají kategorie a číselné datové body.
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

Výsledný název série je `Product A 2026` s mezerou mezi hodnotami dvou buněk. Legenda jej zobrazuje jako jediný záznam pro oba sloupce. Obrázek níže ilustruje výsledek:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Získání automatické barvy výplně série**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) vrací barvu vypočítanou z indexu série a stylu grafu. Jedná se o barvu použitou, když výplň série nebyla explicitně definována. Volání metody přečte vypočítanou barvu; nepřiřadí novou výplň.

Následující příklad vytiskne automatickou barvu každé výchozí série:

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

Výstupní příklad pro výchozí styl grafu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Přesné barvy závisí na stylu a motivu grafu.

## **Nastavení invertované barvy výplně pro sérii grafu**

Pro pruhové, sloupcové a bublinové série může [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na jednotnou, povolte inverzi a přiřaďte barvu pro záporné hodnoty pomocí [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Záporná čísla zůstávají ve sešitu beze změny; mění se pouze jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 názvy kategorií a sloupec 1 hodnoty:

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

Výsledek:

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverzi můžete povolit pro jeden bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). V následujícím příkladu je inverze vypnuta pro sérii a zapnuta jen pro vybraný bod. Bod také dostane zápornou hodnotu, aby byl efekt viditelný:

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

## **Vymazání konkrétní hodnoty datového bodu**

Chcete‑li učinit jeden bod prázdným, aniž byste odstranili ostatní body, nastavte jeho podkladovou buňku sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Datový bod zůstane na stejné pozici kategorie, ale graf bude jeho hodnotu považovat za prázdnou podle nastavení prázdných hodnot grafu.

Následující příklad vymaže pouze druhý bod v první sérii:

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

Rozptylové grafy používají samostatné X a Y buňky a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Skryté buňky obsahující hodnoty jsou odlišné od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) s `null`, aby buňka byla prázdná. Numerická nula zůstane nulou bez ohledu na nastavení prázdných buněk.

Použijte [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) pro výběr, jak má graf zobrazovat prázdné buňky. Toto nastavení se vztahuje na celý graf. Mění způsob, jakým jsou mezery vykreslovány, aniž by prázdná buňka byla vyplněna nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží graf ve třech režimech. Žádný vstupní soubor není vyžadován. [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

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

    // Nechte den 3. den skutečně prázdný, přičemž zachováte jeho kategorii a datový bod.
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

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze nastavte požadovaný režim a prezentaci uložte jednou místo opakování přes všechny režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je ve všech případech prázdný v sešitu:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadno porovnat všechny tři režimy. Pruhové a sloupcové grafy nemají linii, která by spojovala chybějící kategorii, takže `Span` nemůže vytvořit spojovací úsek zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně u rozptylového grafu s jen značkami není žádná spojovací čára. Neočekávejte tři odlišné výsledky u každého typu grafu; ověřte výstup u typu, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními klastrami pruhů nebo sloupců, vyjádřený jako procento šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi klastery; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží pouze finální prezentaci:

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

Výsledek:

![The gap width](gap_width.png)

## **Často kladené otázky**

**Které typy grafů podporují datové série?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) používají data grafu, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, rozptylové grafy X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Použijte metodu pro vytváření datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní skupiny pruhových nebo sloupcových grafů.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení na úrovni skupiny. Kombinovaný graf může mít více než jednu skupinu, takže změna skupiny získané přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) vytvoří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak série, tak kolekce kategorií před přidáním zcela vlastních dat. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při tvorbě vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou buňku s hodnotou na `null`, aby bod zůstal na své pozici kategorie jako prázdný bod. Používejte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) jen pokud chcete odstranit všechny body ze série. Pokud také odstraňujete kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a na nastavení konfigurovaném pomocí [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Podporované grafy mohou zobrazovat prázdno jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií zavolejte [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) a nastavte barvu vrácenou metodou [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Chování můžete přepsat pro jednotlivý bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když je formátována i série i bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát série nebo, pokud formát série není definován, automatický styl a motiv grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozvržení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu sérií v grafu?**

Aspose.Slides neukládá samostatný pevný limit počtu sérií. V praxi určují omezení souboru prezentace, dostupná paměť, čas renderování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na příslušné nadřazené skupině sérií. Zvyšte hodnotu pro rozšíření prostoru mezi klastery nebo ji snižte pro jejich zmenšení.