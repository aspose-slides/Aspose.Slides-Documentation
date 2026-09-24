---
title: Správa datových sérií grafu v prezentacích v jazyce Java
linktitle: Datové série
type: docs
url: /cs/java/chart-series/
keywords:
- série grafu
- překrytí série
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
description: "Naučte se, jak v prezentacích pomocí jazyka Java spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu dat grafu. Rozhraní [IChartSeries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/) představuje jednu sadu souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekty [IChartCategory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartcategory/) poskytují štítky nebo seskupovací hodnoty sdílené sérií. Název série, kategorie a hodnoty bodů jsou proto propojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/), místo aby byly uloženy pouze jako zobrazovaný text.

Pro typický kategoriální graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbylé buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) jsou nulové‑základní. Toto rozvržení je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. Pro načtenou prezentaci si před změnou hodnot v sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různé rozsahy:

- Nastavení na úrovni série, například [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getFormat--), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, například [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getFormat--), přepisuje vzhled série pro jeden bod.
- Nastavení skupiny se vztahuje na kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/). Přístup ke skupině získáte pomocí [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) , pokud potřebujete nastavit například překrytí nebo šířku mezery.

Když není nastaven explicitní výplň bodu ani série, určuje automatický vzhled styl a motiv grafu. Když jsou přítomny jak formátování série, tak bodu, formátování bodu má přednost pro daný bod.

![graf-série-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getOverlap--) udává, jak moc se lištu nebo sloupce překrývají v 2 D grafu, v rozmezí –100 až 100 procent. Jedná se o jen‑pro‑čtení projekci nastavení na nadřazenou skupinu sérií. K aktualizaci všech kompatibilních sérií ve skupině použijte [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-). Tato volba se vztahuje na typy grafů, které zobrazují seskupené lišty nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

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

![Překrytí série](series_overlap.png)

## **Změna barvy výplně série**

Pro nastavení výchozí výplně celé série použijte [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getFormat--). Pokud má bod již explicitní výplň, jeho nastavení [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getFormat--) přepisuje výplň série pro tento bod.

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

![Barva série](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu dat grafu a obvykle je zobrazen v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 na řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu činí explicitní:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) vrací barvu vypočtenou z indexu série a stylu grafu. Jedná se o barvu použitou, když výplň série není explicitně definována. Volání metody pouze čte vypočtenou barvu; nepřiřazuje novou výplň.

Následující příklad vypíše automatickou barvu každé výchozí série:

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

## **Nastavení obrácené barvy výplně pro sérii grafu**

U lištových, sloupcových a bublinových sérií může [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) zobrazit záporné hodnoty s odlišnou výplní. Nastavte běžnou výplň série na plnou, povolte inverzi a přiřaďte barvu záporné hodnoty pomocí [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Záporná čísla zůstávají v sešitu beze změny; mění se jen jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 hodnoty:

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

![Obrácená plná barva výplně](inverted_solid_fill_color.png)

Inverzi můžete povolit jen pro jeden bod přes [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). V následujícím příkladu je inverze deaktivována pro sérii a povolena pouze pro vybraný bod. Bod je také nastaven na zápornou hodnotu, aby byl efekt viditelný:

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

Chcete‑li učinit jeden bod prázdným, aniž byste odstranili ostatní, nastavte jeho podkladovou buňku na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [IChartDataPoint.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getValue--). Datový bod zůstává na stejné pozici kategorie, ale graf jej podle nastavení prázdných hodnot považuje za prázdný.

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

Bodové grafy používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapointcollection/#clear--) pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny body ze sbírky.

## **Ovládání zobrazení prázdných buněk**

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [IChartDataCell.setValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) s `null`, aby se buňka vyprázdnila. Číselná nula zůstává nulou bez ohledu na nastavení prázdných buněk.

Pomocí [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) zvolte, jak má graf zobrazovat prázdné buňky. Toto nastavení platí pro celý graf. Mění způsob, jakým jsou prázdná místa vykreslována, aniž by prázdná buňka byla vyplněna nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf ve všech třech režimech. Vstupní soubor není potřeba. [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/) používá list 0, sloupec 0 pro štítky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Výsledná data jsou `10, 20, empty, 30, 40`.

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

    // Nechte den 3 skutečně prázdný, přičemž zachovejte jeho kategorii a datový bod.
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

Každý výstupní soubor uloží režim nastavený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze nastavte požadovaný režim a prezentaci uložte jednou místo iterace přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Čárové grafy se stejnými daty: Mezera přeruší čáru v den 3, Nula snižuje čáru na nulu a Rozsah spojuje den 2 s dnem 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadno porovnat všechny tři režimy. Lištové a sloupcové grafy nemají čáru, která by spojovala chybějící kategorii, takže `Span` nemůže vytvořit spojovací segment zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně scatter graf jen s markery nemá spojovací čáru. Neočekávejte tři odlišné výsledky u každého typu grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery sérií**

Šířka mezery je prostor mezi sousedními shluky lišt nebo sloupců, vyjádřený v procentech šířky lišty nebo sloupce. Stejně jako překrytí patří této hodnotě nadřazená skupina sérií, nikoli jedné sérii. Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je učiní hustšími.

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

## **Často kladené otázky**

**Které typy grafů podporují datové série?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/) používají data grafu, ale jejich série nemají vždy stejnou strukturu hodnot ani nastavení. Například kategoriální grafy používají kategorie a hodnoty, scatter grafy používají X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Použijte metodu pro vytvoření datových bodů, která odpovídá typu série. Volby jako překrytí a šířka mezery se vztahují jen na kompatibilní skupiny lišt nebo sloupců.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažená přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [IShapeCollection.addChart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) vytvoří vzorové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak série, tak kolekce kategorií před přidáním zcela vlastního datového souboru. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, štítky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/). Změna buňky, na kterou se odkazuje, aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou buňku hodnoty na `null`, aby bod zůstal na své pozici kategorie jako prázdný bod. Použijte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapointcollection/#clear--) pouze když chcete odstranit všechny body ze série. Pokud také odstraňujete kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou zobrazeny prázdné body?**

Výsledek závisí na typu grafu a hodnotě nastavené pomocí [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Podporované grafy mohou prázdná místa zobrazovat jako mezery, jako nulové hodnoty nebo propojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz část **Ovládání zobrazení prázdných buněk** pro kompletní příklad a vizuální porovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných lištových, sloupcových a bublinových sérií zavolejte [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) a nastavte barvu vrácenou metodou [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Chování můžete přepsat pro jednotlivý bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když je formátována jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body pokračují v používání explicitního formátu série nebo, pokud není definován, automatického stylu a motivu grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozvržení a nejsou přepisována na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neudává samostatný pevný limit počtu sérií. V praxi omezují souborové limity prezentace, dostupná paměť, čas renderování a čitelnost grafu.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na příslušné nadřazené skupině sérií. Zvýšením hodnoty rozšíříte prostor mezi shluky, snížením jej přiblížíte.