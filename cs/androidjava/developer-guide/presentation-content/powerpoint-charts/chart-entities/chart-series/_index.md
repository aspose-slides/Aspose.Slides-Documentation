---
title: Správa datových sérií grafu v prezentacích na Androidu
linktitle: Datové série
type: docs
url: /cs/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích na Androidu."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu dat grafu. [IChartSeries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/) představuje jeden soubor souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekty [IChartCategory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartcategory/) poskytují popisky nebo hodnoty seskupení sdílené sériemi. Název série, kategorie a hodnoty bodů jsou proto propojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/) místo toho, aby byly uloženy jen jako zobrazovaný text.

U typického kategoriálního grafu výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) jsou nulové. Toto rozvržení je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. U načtené prezentace si před změnou hodnot v sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu má tři různé úrovně:

- Nastavení na úrovni série, například [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getFormat--), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, například [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), přepíše vzhled série pro jeden bod.
- Nastavení skupiny se vztahuje na kompatibilní série, které patří do stejného [IChartSeriesGroup](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/). Přístup ke skupině získáte přes [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) pokud potřebujete nastavit možnosti jako překrytí nebo šířka mezery.

Když není nastaven žádný explicitní výplň bodu nebo série, styl a motiv grafu určují automatický vzhled. Když jsou přítomny jak formátování série, tak bodu, formátování bodu má přednost pro daný bod.

![graf-serie-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getOverlap--) udává, jak moc se překrývají pruhy nebo sloupce ve 2D grafu, v rozmezí od ‑100 do 100 procent. Jedná se o pouze pro čtení projekci nastavení v nadřazené skupině sérií. Použijte [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) pro aktualizaci všech kompatibilních sérií v této skupině. Tato možnost se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

Následující příklad nastavuje překrytí pro skupinu, která obsahuje první sérii:

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

Použijte [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getFormat--) pro nastavení výchozí výplně celé série. Pokud má bod již explicitně nastavenou výplň, jeho nastavení [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) přepíše výplň série pro tento bod.

Následující příklad aplikuje plnou modrou výplň na první sérii:

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

Výsledek:

![Barva série](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu dat grafu a normálně se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 na řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně vyjadřují:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries.getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getName--). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) vrací barvu vypočítanou z indexu série a stylu grafu jako celočíselnou hodnotu Android ARGB. Jedná se o barvu použitou, když výplň série není explicitně definována. Volání metody pouze načte vypočítanou barvu; novou výplň nepřidělí.

Následující příklad vypíše automatickou celočíselnou barvu každé výchozí série:

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

Přesné celočíselné hodnoty závisí na stylu a motivu grafu.

## **Nastavení obrácené barvy výplně pro sérii grafu**

U pruhových, sloupcových a bublinových sérií může [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) zobrazit záporné hodnoty s jinou výplní. Nastavte běžnou výplň série na plnou, povolte inverzi a přiřaďte barvu záporné hodnoty pomocí [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Záporná čísla zůstávají v sešitu beze změny; mění se pouze jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

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

Výsledek:

![Obrácená plná výplň](inverted_solid_fill_color.png)

Můžete povolit inverzi pro jeden bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). V následujícím příkladu je inverze vypnuta pro sérii a povolena pouze pro vybraný bod. Bod je také přiřazen zápornou hodnotou, aby byl efekt viditelný:

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

## **Vymazání konkrétní hodnoty datového bodu**

Chcete‑li učinit jeden bod prázdným, aniž byste odstraňovali ostatní body, nastavte jeho buňku v sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [IChartDataPoint.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Datový bod zůstane na stejné pozici kategorie, ale graf bude jeho hodnotu považovat za prázdnou podle nastavení prázdných hodnot grafu.

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

Grafy rozptylu používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte pouze buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) pokud chcete zachovat ostatní body, protože tato metoda odstraňuje všechny datové body ze sbírky.

## **Řízení zobrazování prázdných buněk**

Prázdná buňka v sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [IChartDataCell.setValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) s `null`, aby buňka byla prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdných buněk.

Použijte [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) k výběru, jak graf zobrazí prázdné buňky. Toto nastavení platí pro celý graf. Mění, jak jsou prázdná místa vykreslena, aniž by se prázdná buňka vyplnila nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří spojnicový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf ve všech režimech. Vstupní soubor není potřeba. [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

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

    // Nechte den 3 skutečně prázdný, přičemž zachováte jeho kategorii a datový bod.
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

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení pouze jedné verze nastavte požadovaný režim a prezentaci uložte jednou místo iterování přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Spojnicové grafy se stejnými daty: Gap přeruší čáru v den 3, Zero sníží čáru na nulu a Span spojí den 2 s dnem 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Spojnicový graf usnadňuje porovnání všech tří režimů. U pruhových a sloupcových grafů není žádná čára, která by mohla propojit chybějící kategorii, takže `Span` nemůže vytvořit spojovací úsek zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou také vypadat podobně. Podobně u grafu rozptylu s jen značkami není žádná spojovací čára. Neočekávejte tři odlišné výsledky pro každý typ grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery sérií**

Šířka mezery je prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) jednou pro skupinu. Větší hodnota vytvoří větší prostor mezi shluky; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží jen finální prezentaci:

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

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/) používají datový sešit, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, grafy rozptylu používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu tvorby datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery se vztahují jen na kompatibilní skupiny pruhových nebo sloupcových grafů.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/) obsahuje kompatibilní série, které sdílí nastavení úrovně skupiny při vykreslování. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažená přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [IShapeCollection.addChart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) vytvoří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak kolekce sérií, tak kolekce kategorií před přidáním zcela vlastního datového souboru. Přetížení může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu napojeny na buňky sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/). Změna odkázané buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymažu jeden bod místo celé série?**

Nastavte příslušnou buňku s hodnotou na `null`, aby bod zůstal na své pozici kategorie jako prázdný bod. Použijte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) jen v případě, že chcete odstranit všechny body z dané série. Pokud odstraňujete také kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a na hodnotě nastavené pomocí [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Podporované grafy mohou prázdná místa zobrazovat jako mezery, jako nulové hodnoty nebo propojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz **Řízení zobrazování prázdných buněk** pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií zavolejte [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) a nastavte barvu vrácenou metodou [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Chování můžete přepsat pro jednotlivý bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body pokračují v používání explicitního formátu série nebo, pokud formát série není definován, automatického stylu a motivu grafu. Nastavení skupiny, jako je překrytí a šířka mezery, řídí rozvržení a nejsou přepsáním formátování na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neukládá samostatný pevný limit počtu sérií. V praxi určují omezení souboru prezentace, dostupná paměť, doba vykreslování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na příslušné nadřazené skupině sérií. Zvýšením hodnoty rozšíříte prostor mezi shluky, snížením ho přiblížíte.