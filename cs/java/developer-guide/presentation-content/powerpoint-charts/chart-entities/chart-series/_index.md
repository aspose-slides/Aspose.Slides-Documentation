---
title: Správa datových sérií grafu v prezentacích v Javě
linktitle: Datové série
type: docs
url: /cs/java/chart-series/
keywords:
- série grafu
- překrytí sérií
- barva série
- název série
- datový bod
- buňka sešitu
- mezera série
- záporná hodnota
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí Javy."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu s daty grafu. [IChartSeries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/) představuje jednu sadu souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. [IChartCategory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartcategory/) poskytuje popisky nebo hodnoty seskupení, které jsou sdílené sériemi. Název série, kategorie a hodnoty bodů jsou tedy propojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/) spíše než aby byly uloženy jen jako zobrazovaný text.

Pro typický graf kategorií výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) jsou nulové (základní). Toto uspořádání je užitečné, když vytvoříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. Pro načtenou prezentaci si před změnou hodnot sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni série, například [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getFormat--), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, například [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getFormat--), přepíše vzhled série pro jeden bod.
- Skupinová nastavení se vztahují na kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/). Skupinu získáte pomocí [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) v případě, že potřebujete nastavit volby jako překrytí nebo šířka mezery.

Když není nastaven explicitní výplň bodu ani série, určuje automatický vzhled styl a motiv grafu. Když jsou přítomna jak formátování série, tak bodu, má přednost formátování bodu.

![série grafu PowerPoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getOverlap--) uvádí, jak moc se překrývají pruhy nebo sloupce ve 2D grafu, v rozmezí od ‑100 do 100 procent. Jedná se o jen pro čtení projekci nastavení v nadřazené skupině sérií. Použijte [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) k aktualizaci všech kompatibilních sérií v této skupině. Tato volba se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

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

![Překrytí sérií](series_overlap.png)

## **Změna barvy výplně série**

Pomocí [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getFormat--) můžete nastavit výchozí výplň pro celou sérii. Pokud má bod již explicitní výplň, jeho nastavení [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getFormat--) přepíše výplň série pro tento bod.

Následující příklad použije plnou modrou výplň pro první sérii:

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

![Barva série](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu s daty grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro sloupcový graf s seskupením je buňka B1 na řádku 0, sloupci 1 a obsahuje název první série. V následujícím příkladu pojmenované konstanty tuto strukturu explicitně vyjadřují:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries.getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getName--). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

![Název série](series_name.png)

## **Získání automatické barvy výplně série**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) vrací barvu vypočítanou z indexu série a stylu grafu. Tato barva se používá, když výplň série není explicitně definována. Volání metody pouze načte vypočítanou barvu; nenastavuje novou výplň.

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

Ukázkový výstup pro výchozí styl grafu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Přesné barvy závisí na stylu a motivu grafu.

## **Nastavení invertované barvy výplně pro sérii grafu**

U sérií pruhů, sloupců a bublin může [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na plnou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Záporná čísla zůstávají v sešitu nezměněna; mění se jen jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou sérií. List řádek 0 obsahuje název série, sloupec 0 názvy kategorií a sloupec 1 hodnoty:

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

![Invertovaná plná výplň](inverted_solid_fill_color.png)

Můžete povolit inverzi pro jeden bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). V následujícím příkladu je inverze vypnuta pro sérii a zapnuta pouze pro vybraný bod. Bod je také nastaven na zápornou hodnotu, aby byl efekt viditelný:

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

Chcete‑li učinit jeden bod prázdným bez odstranění ostatních bodů, nastavte jeho odpovídající buňku sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [IChartDataPoint.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getValue--). Datový bod zůstane na stejné pozici kategorie, ale graf bude jeho hodnotu považovat za prázdnou podle nastavení prázdných hodnot grafu.

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

Bodové grafy používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nevolejte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapointcollection/#clear--) pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišný případ od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [IChartDataCell.setValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) s `null`, aby se buňka stala prázdnou. Číselná nula zůstane nulou bez ohledu na nastavení prázdných buněk.

Použijte [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) pro volbu, jak má graf zobrazovat prázdné buňky. Toto nastavení platí pro celý graf. Mění způsob, jak jsou prázdná místa vykreslena, aniž by vyplňovalo prázdnou buňku sešitu nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf ve všech třech režimech. Vstupní soubor není vyžadován. [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

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

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení pouze jedné verze přiřaďte požadovaný režim a prezentaci uložte jednou místo iterování přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu prázdný ve všech případech:

![Čárové grafy se stejnými daty: Mezera přeruší čáru v den 3, Nula snižuje čáru na nulu a Rozpětí spojuje den 2 s dnem 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadno porovnat všechny tři režimy. Sloupcové a pruhové grafy nemají čáru, která by propojila chybějící kategorii, takže `Span` nemůže vytvořit spojovací segment zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou také vypadat podobně. Podobně scatter graf jen s markery nemá spojovací čáru. Neočekávejte tři odlišné výsledky u každého typu grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je zmenší.

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

![Šířka mezery](gap_width.png)

## **Často kladené dotazy**

**Které typy grafů podporují datové série?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/) používají data grafu, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například grafy kategorií používají kategorie a hodnoty, scatter grafy používají hodnoty X a Y a bublinové grafy přidávají velikost bublin. Použijte metodu vytváření datových bodů, která odpovídá typu série. Volby jako překrytí a šířka mezery se vztahují jen na kompatibilní skupiny pruhových nebo sloupcových grafů.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení vykreslování na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažené přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [IShapeCollection.addChart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) vytváří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak kolekce sérií, tak kolekce kategorií před přidáním zcela vlastního datového souboru. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající element grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte relevantní buňku hodnoty na `null`, aby bod zůstal na své pozici kategorie jako prázdný bod. Použijte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapointcollection/#clear--) pouze tehdy, když chcete odstranit všechny body z dané série. Pokud také odstraňujete kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazeny?**

Výsledek závisí na typu grafu a na hodnotě nastavené pomocí [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Podporované grafy mohou zobrazovat prázdná místa jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Řízení zobrazení prázdných buněk](#control-the-display-of-empty-cells) pro úplný příklad a vizuální porovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií zavolejte [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) a nastavte barvu vrácenou metodou [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Pro individuální bod můžete přepsat chování pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když je série i bod formátován?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát série nebo, pokud není formát série definován, automatický styl a motiv grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozložení a nejsou přepsáním formátování na úrovni bodu.

**Je omezení počtu sérií v grafu?**

Aspose.Slides neuvádí samostatný pevný limit počtu sérií. V praxi limit určuje omezení souboru prezentace, dostupná paměť, čas vykreslování a čitelnost grafu.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na příslušné nadřazené skupině sérií. Zvyšte hodnotu pro rozšíření prostoru mezi shluky nebo ji snižte, aby se shluky přiblížily.