---
title: Správa sérií dat grafu v prezentacích v Javě
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
- mezera mezi sériemi
- záporná hodnota
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat série grafů, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí Javy."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu dat grafu. [IChartSeries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/) představuje jednu sadu souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekt [IChartCategory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartcategory/) poskytuje štítky nebo seskupovací hodnoty sdílené sériemi. Název série, kategorie a hodnoty bodů jsou tedy propojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/), nikoli pouze uloženy jako zobrazovaný text.

U typického kategoriálního grafu výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) jsou nulové‑založené. Toto rozvržení je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že ho každá existující graf používá. U načtené prezentace si před změnou hodnot v sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různá rozsahy:

- Nastavení na úrovni série, jako je [IChartSeries.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getFormat--), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, jako je [IChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getFormat--), přepisuje vzhled série pro jeden bod.
- Skupinová nastavení platí pro kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/). Přístup ke skupině získáte přes [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) když potřebujete nastavit možnosti jako překrytí nebo šířka mezery.

Když není nastaven explicitní výplň bodu ani série, určuje automatický vzhled styl a motiv grafu. Když jsou přítomny jak formátování série, tak bodu, má přednost formátování bodu pro daný bod.

![graf‑seri‑powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getOverlap--) udává, jak moc se sloupce nebo pruhy překrývají v 2D grafu, v rozmezí od –100 % do 100 %. Jedná se o jen‑pro‑čtení projekci nastavení v nadřazené skupině sérií. K aktualizaci všech kompatibilních sérií v této skupině použijte [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-). Tato možnost se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

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

Následující příklad použije jednolitou modrou výplň na první sérii:

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

Název série je uložen v sešitu dat grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně uvádějí:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries.getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getName--). Tento přístup zabraňuje předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) vrací barvu vypočítanou z indexu série a stylu grafu. Jedná se o barvu použité, když výplň série není explicitně definována. Volání metody pouze načte vypočítanou barvu; nepřiřazuje novou výplň.

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

## **Nastavení obrácené výplně pro sérii grafu**

Pro pruhové, sloupcové a bublinové série lze pomocí [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na jednolitou, povolte inverzi a přiřaďte barvu záporné hodnoty přes [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Záporná čísla zůstávají v sešitu beze změny; mění se jen jejich zobrazovaná barva.

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

![Obrácená jednolitá výplň](inverted_solid_fill_color.png)

Inverzi můžete povolit pro jeden bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). V následujícím příkladu je inverze zakázána pro sérii a povolena jen pro vybraný bod. Bod také dostane zápornou hodnotu, aby byl efekt viditelný:

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

Aby byl jeden bod prázdný, aniž byste odstraňovali ostatní body, nastavte jeho podpůrnou buňku sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [IChartDataPoint.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getValue--). Datový bod zůstane na stejném místě kategorie, ale graf bude jeho hodnotu považovat za prázdnou podle nastavení grafu pro prázdné hodnoty.

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

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními klustery pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Pro skupinu zavolejte jednou [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-). Větší hodnota vytvoří více prostoru mezi klustery; menší hodnota je učiní hustšími.

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

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/) používají grafická data, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, bodové grafy používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu pro vytvoření datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní skupiny pruhových nebo sloupcových grafů.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažené přes jednu sérii nutně nemění všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení [IShapeCollection.addChart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) vytváří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak sbírky sérií, tak kategorií před přidáním zcela vlastního datového souboru. Přetížená verze může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, štítky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou hodnotovou buňku na `null`, aby bod zachoval svou pozici kategorie jako prázdný. Používejte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapointcollection/#clear--) pouze když chcete odstranit všechny body ze série, protože tato metoda odstraňuje všechny body ze sbírky.

**Jak jsou zobrazeny prázdné body?**

Výsledek závisí na typu grafu a na hodnotě nastavené přes [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Podporované grafy mohou prázdná místa zobrazovat jako mezery, jako nuly nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií zavolejte [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) a nastavte barvu vrácenou metodou [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Chování můžete přepsat pro jednotlivý bod pomocí [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Tyto metody ovlivňují formátování, ne uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body nadále používají explicitní formát série nebo, pokud formát série není definován, automatický styl a motiv grafu. Skupinová nastavení, jako je překrytí a šířka mezery, řídí rozvržení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neuvádí samostatný pevný limit počtu sérií. V praxi určují omezení souboru prezentace, dostupná paměť, čas renderování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na příslušné nadřazené skupině sérií. Zvýšením hodnoty rozšíříte prostor mezi klustery, snížením jej přiblížíte.