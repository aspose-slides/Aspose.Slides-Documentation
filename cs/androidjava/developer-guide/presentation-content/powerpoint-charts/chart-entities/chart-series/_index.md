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

Graf ukládá svá vykreslená data do sešitu s daty grafu. [IChartSeries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/) představuje jednu sadu souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekty [IChartCategory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartcategory/) poskytují popisky nebo hodnoty seskupení sdílené sériemi. Název série, kategorie a hodnoty bodů jsou proto spojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/) místo toho, aby byly uloženy jen jako zobrazovaný text.

Pro typický kategoriální graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) jsou založeny na nule. Toto uspořádání je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. Pro načtenou prezentaci si před změnou hodnot v sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni série, např. [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getFormat--), poskytují výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, např. [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), přepisují vzhled série pro jeden bod.
- Nastavení skupiny se vztahují na kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/). Přistupujte ke skupině pomocí [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) , když potřebujete nastavit možnosti jako překrytí či šířku mezery.

Když není nastaven žádný explicitní výplň bodu nebo série, určuje automatický vzhled styl a motiv grafu. Když jsou přítomna jak formátování série, tak bodu, má přednost formátování bodu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí série grafu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getOverlap--) udává, jak moc se překrývají pruhy nebo sloupce v 2D grafu, v rozmezí od -100 do 100 procent. Jedná se o jen‑čtení projekci nastavení na rodičovskou skupinu sérií. Použijte [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) k aktualizaci všech kompatibilních sérií v této skupině. Tato možnost se vztahuje na typy grafů zobrazujících seskupené pruhy nebo sloupce; neovlivní nesouvisející skupiny sérií v kombinovaném grafu.

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

![The series overlap](series_overlap.png)

## **Změna barvy výplně série**

Použijte [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getFormat--) k nastavení výchozí výplně pro celou sérii. Pokud má bod již explicitní výplň, jeho nastavení [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) přepisuje výplň série pro tento bod.

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

![The color of the series](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu s daty grafu a běžně se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně ukazují:

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

![The series name](series_name.png)

## **Získání automatické barvy výplně série**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) vrací barvu vypočtenou z indexu série a stylu grafu jako celočíselnou hodnotu Android ARGB. Toto je barva použita, když výplň série nebyla explicitně definována. Volání metody načte vypočtenou barvu; nepřiřazuje novou výplň.

Následující příklad vypisuje automatické celočíselné hodnoty barvy pro každou výchozí sérii:

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

Přesné celočíselné hodnoty závisí na stylu grafu a motivu.

## **Nastavení invertované barvy výplně pro sérii grafu**

Pro pruhové, sloupcové a bublinové série může [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) zobrazit záporné hodnoty s jinou výplní. Nastavte běžnou výplň série na plnou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Záporná čísla zůstávají v sešitu beze změny; mění se pouze jejich barva při zobrazení.

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverzi můžete povolit pro jeden bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). V následujícím příkladu je inverze pro sérii zakázána a povolena pouze pro vybraný bod. Bod je také přiřazen zápornou hodnotou, aby byl efekt viditelný:

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

Aby byl jeden bod prázdný aniž by se odstranily ostatní body, nastavte jeho podkladovou buňku v sešitu na `null`. Pro sloupcový graf je vykreslená hodnota dostupná přes [IChartDataPoint.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Datový bod zůstává na stejné pozici kategorie, ale graf s ohledem na nastavení prázdných hodnot považuje jeho hodnotu za prázdnou.

Následující příklad vymaže jen druhý bod v první sérii:

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

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte pouze buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) pokud chcete zachovat ostatní body, protože tato metoda odstraní každý datový bod ze sbírky.

## **Nastavení šířky mezery série**

Šířka mezery je prostor mezi sousedními seskupeními pruhů nebo sloupců, vyjádřený jako procento šířky pruhu nebo sloupce. Stejně jako překrytí patří k rodičovské skupině sérií, nikoli k jedné sérii. Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi seskupeními; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží jen konečnou prezentaci:

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

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/) používají data grafu, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, rozptylové grafy používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu tvorby datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery se vztahují jen na kompatibilní pruhové nebo sloupcové skupiny.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení vykreslování úrovně skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažené přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení [IShapeCollection.addChart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) vytváří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak kolekce sérií, tak kategorií před přidáním zcela vlastního datového souboru. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu spojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou buňku s hodnotou na `null`, aby bod zůstal na pozici kategorie jako prázdný bod. Použijte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) jen tehdy, když chcete odstranit všechny body z této série. Pokud také odstraňujete kategorie, aktualizujte každou sérii, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak se zobrazují prázdné body?**

Výsledek závisí na typu grafu a hodnotě nastavené pomocí [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Podporované grafy mohou zobrazovat prázdná místa jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií zavolejte [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) a nastavte barvu vrácenou metodou [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Chování pro jednotlivý bod můžete přepsat pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když je formátována i série i bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát série nebo, pokud není formát série definován, automatický styl a motiv grafu. Nastavení skupiny, jako jsou překrytí a šířka mezery, řídí rozvržení a nejsou přepisem formátování na úrovni bodu.

**Existuje limit, kolik sérií může graf obsahovat?**

Aspose.Slides neukládá samostatný pevný limit počtu sérií. V praxi o praktickém limitu rozhodují omezení souboru prezentace, dostupná paměť, čas vykreslování a čitelnost grafu.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na odpovídající rodičovské skupině sérií. Zvyšte hodnotu pro rozšíření prostoru mezi seskupeními nebo ji snižte, aby se seskupení přiblížila.