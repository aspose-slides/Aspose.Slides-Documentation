---
title: Správa datových řad grafu v prezentacích pro Android
linktitle: Datové řady
type: docs
url: /cs/androidjava/chart-series/
keywords:
- řady grafu
- překrytí řad
- barva řady
- název řady
- datový bod
- buňka sešitu
- mezera mezi řadami
- záporná hodnota
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat řady grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pro Android."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu s daty grafu. IChartSeries představuje jednu sadu souvisejících hodnot a každý IChartDataPoint v řadě odkazuje na jednu nebo více buněk sešitu. IChartCategory objekty poskytují popisky nebo skupinové hodnoty sdílené řadou. Název řady, kategorie a hodnoty bodů jsou tedy propojeny s objekty IChartDataCell, místo aby byly uloženy pouze jako zobrazovaný text.

Pro typický kategoriový graf výchozí sešit používá řádek 0 pro názvy řad, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty řad. Indexy listu, řádku a sloupce předávané metodě IChartDataWorkbook.getCell jsou založeny na nulovém základu. Toto uspořádání je užitečné při vytváření grafu s výchozími daty, ale neassumujte, že každá existující grafka ho používá. Pro načtenou prezentaci před změnou hodnot sešitu prověřte buňky odkazované řadami, kategoriemi a body dat.

Nastavení grafu má tři různé úrovně:

- Nastavení na úrovni řady, například IChartSeries.getFormat, poskytuje výchozí vzhled pro všechny body v jedné řadě.
- Nastavení bodu dat, například IChartDataPoint.getFormat, přepisuje vzhled řady pro konkrétní bod.
- Skupinová nastavení se vztahují na kompatibilní řady, které patří do stejné IChartSeriesGroup. Přístup ke skupině získáte pomocí IChartSeries.getParentSeriesGroup, když potřebujete nastavit volby jako překrytí nebo šířku mezery.

Když není explicitně nastaveno vyplnění bodu nebo řady, určuje automatický vzhled styl a motiv grafu. Když jsou současně přítomna formátování řady i bodu, formátování bodu má přednost pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady grafu**

IChartSeries.getOverlap udává, jak moc se překrývají pruhy nebo sloupce ve 2D grafu, v rozmezí od –100 % do 100 %. Jedná se o jen‑čtení projekce nastavení v nadřazené skupině řad. Použijte IChartSeriesGroup.setOverlap k aktualizaci všech kompatibilních řad v této skupině. Tato volba se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivní nesouvisející skupiny řad v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první řadu:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Nový graf obsahuje ukázkové řady, kategorie a hodnoty.
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

## **Změna barvy výplně řady**

Použijte IChartSeries.getFormat k nastavení výchozí výplně pro celou řadu. Pokud má bod již explicitní výplň, jeho nastavení IChartDataPoint.getFormat přepisuje výplň řady pro tento bod.

Následující příklad použije plnou modrou výplň na první řadu:

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

## **Změna názvu řady**

Název řady je uložen v sešitu s daty grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro sloupcový graf s seskupením je buňka B1 na řádku 0, sloupci 1 a obsahuje název první řady. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně vyjadřují:

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

Můžete také aktualizovat buňku, na kterou již odkazuje IChartSeries.getName. Tento přístup se vyhne předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

## **Získání automatické barvy výplně řady**

IChartSeries.getAutomaticSeriesColor vrací barvu vypočítanou z indexu řady a stylu grafu jako celočíselnou hodnotu Android ARGB. Jedná se o barvu použitou, když výplň řady není explicitně definována. Volání metody pouze načte vypočítanou barvu; nepřiřadí novou výplň.

Následující příklad vypíše automatický celočíselný kód barvy každé výchozí řady:

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

## **Nastavení invertované výplně pro řadu grafu**

Pro pruhové, sloupcové a bublinové řady může IChartSeries.setInvertIfNegative zobrazit záporné hodnoty s odlišnou výplní. Nastavte běžnou výplň řady na plnou, povolte inverzi a přiřaďte barvu záporné hodnoty pomocí IChartSeries.getInvertedSolidFillColor. Záporná čísla zůstávají v sešitu beze změny; mění se jen jejich barva při zobrazení.

Následující příklad nahradí výchozí data grafu jednou řadou. Řádek 0 listu obsahuje název řady, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

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

Můžete povolit inverzi pro jeden bod pomocí IChartDataPoint.setInvertIfNegative. V následujícím příkladu je inverze vypnuta pro řadu a zapnuta pouze pro vybraný bod. Bod má také přiřazenou zápornou hodnotu, aby byl efekt viditelný:

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

Chcete‑li učinit jeden bod prázdným, aniž byste odstraňovali ostatní body, nastavte jeho podkladovou buňku na `null`. Pro sloupcový graf je vykreslená hodnota dostupná přes IChartDataPoint.getValue. Datový bod zůstane na stejné pozici kategorie, ale graf ho bude považovat za prázdný podle nastavení prázdných hodnot grafu.

Následující příklad vymaže pouze druhý bod v první řadě:

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

Grafy rozptylu používají samostatné buňky X a Y a grafy bublin také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte IChartDataPointCollection.clear, pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazování prázdných buněk**

Skryté buňky, které obsahují hodnoty, představují jiný případ než prázdné buňky. Chcete‑li zahrnout nebo vyloučit data ze skrytých řádků a sloupců listu, viz [Include Data from Hidden Rows and Columns](/slides/cs/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte IChartDataCell.setValue s `null`, aby buňka byla prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdných buněk.

Použijte IChart.setDisplayBlanksAs k volbě, jak graf zobrazí prázdné buňky. Toto nastavení platí pro celý graf. Mění způsob, jakým se mezery vykreslují, aniž by se prázdná buňka naplnila nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří spojnicový graf s jednou řadou, vymaže hodnotu pro den 3 a uloží stejný graf ve všech režimech. Vstupní soubor není potřeba. IChartDataWorkbook používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název řady. Výsledná data jsou `10, 20, empty, 30, 40`.

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

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Chcete‑li uložit jen jednu verzi, nastavte požadovaný režim a uložte prezentaci jednou místo iterace přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu ve všech případech prázdný:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Spojnicový graf usnadňuje porovnání všech tří režimů. Pruhové a sloupcové grafy nemají čáru, která by propojila chybějící kategorii, takže `Span` nemůže vytvořit spojovací segment zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně graf rozptylu jen s body nemá spojovací čáru. Neočekávejte tři odlišné výsledky pro každý typ grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi řadami**

Šířka mezery je prostor mezi sousedními seskupeními pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině řad, nikoli k jedné řadě. Zavolejte IChartSeriesGroup.setGapWidth jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi seskupeními; menší hodnota je učiní kompaktnějšími.

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

**Které typy grafů podporují datové řady?**

Všechny typy grafů představované výčtem ChartType používají data grafu, ale jejich řady nemají stejnou strukturu hodnot nebo nastavení. Například kategoriové grafy používají kategorie a hodnoty, rozptylové grafy používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu vytváření datových bodů, která odpovídá typu řady. Volby jako překrytí a šířka mezery platí jen pro kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina řad grafu?**

IChartSeriesGroup obsahuje kompatibilní řady, které sdílejí nastavení na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažené přes jednu řadu nemusí nutně změnit všechny řady v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení IShapeCollection.addChart vytváří ukázkové řady, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak řady, tak sbírky kategorií před přidáním zcela vlastních dat. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy řad, popisky kategorií a hodnoty datových bodů odkazují na buňky v IChartDataWorkbook. Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot řad zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé řady?**

Nastavte příslušnou buňku hodnoty na `null`, aby bod zůstal na své pozici kategorie jako prázdný bod. Používejte IChartDataPointCollection.clear pouze tehdy, když chcete odstranit všechny body z dané řady. Pokud také odstraňujete kategorie, aktualizujte všechny řady, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a na hodnotě nastavené pomocí IChart.setDisplayBlanksAs. Podporované grafy mohou zobrazovat mezery jako prázdná místa, jako nuly nebo propojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální porovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových řad zavolejte IChartSeries.setInvertIfNegative a nastavte barvu vrácenou metodou IChartSeries.getInvertedSolidFillColor. Chování můžete přepsat pro jednotlivý bod pomocí IChartDataPoint.setInvertIfNegative. Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování vyhrává, když je formátována jak řada, tak bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát řady nebo, pokud formát řady není definován, automatický styl a motiv grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozložení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu řad, které může graf obsahovat?**

Aspose.Slides nekladí samostatný pevný limit na počet řad. V praxi určují omezení souboru prezentace, dostupná paměť, doba vykreslování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Zavolejte IChartSeriesGroup.setGapWidth na příslušnou nadřazenou skupinu řad. Zvýšte hodnotu pro rozšíření prostoru mezi seskupeními nebo ji snižte pro jejich přiblížení.