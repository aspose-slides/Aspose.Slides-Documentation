---
title: Přizpůsobení koláčových grafů v prezentacích na Androidu
linktitle: Koláčový graf
type: docs
url: /cs/androidjava/pie-chart/
keywords:
- koláčový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výseče
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte koláčové grafy na Androidu pomocí Aspose.Slides pro Android via Java. Nakonfigurujte sekundární grafy, zobrazte popisky dat a použijte automatické barvy výsečí v PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nakonfigurovat možnosti sekundárního grafu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů pro standardní koláčový graf.

Příklady se zaměřují na úpravy grafů, jako je přidání grafu na snímek, úprava nastavení sérií a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního grafu pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides pro Android via Java podporuje možnosti sekundárního grafu pro grafy Pie of Pie a Bar of Pie. Tyto možnosti řídí velikost sekundárního grafu a způsob, jakým jsou datové body rozděleny mezi oba grafy.

Následující příklad vytvoří graf Pie of Pie v nové prezentaci a zobrazí hodnoty datových bodů jako popisky. Metoda [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) nastaví velikost sekundárního grafu na 149 % hlavního grafu. [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) vybírá dělení založené na procentech a [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) nastavuje práh na 53 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Zobrazit hodnoty a nakonfigurovat sekundární graf.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Vyberte kategorie pro sekundární graf**

Použijte vlastní rozdělení, když chcete seskupit konkrétní kategorie v sekundárním grafu bez ohledu na jejich procentuální hodnoty. Například zpráva o prodeji může zobrazit Online a Události společně, aby čtenáři mohli porovnat tyto dva kanály, i když představují 35 % a 10 % celkových prodejů.

Zavolejte [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) s [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) a vyberte body pomocí [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Metoda [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) kolekce přijímá index založený na nule v sérii; použijte [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) k přidání objektu datového bodu. V tomto příkladu index 1 vybírá Online a bod na indexu 3 vybírá Události. Partners je také dočasně přidán, pak vyloučen pomocí [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Nahraďte výchozí data prodejem podle kanálu.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Vyberte Online podle jeho nulového indexu a Události podle objektu datového bodu.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Vyloučte Partners z výběru bez mazání jeho zdrojových dat.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) a Události (10) se v sekundárním grafu objevují jako samostatné výseče. V hlavním grafu jsou reprezentovány jednou sloučenou výsečí s hodnotou 45, vedle Retail (40) a Partners (15). Odebrání Partners z vlastního výběru jej ponechá v hlavním grafu; neodstraní kategorii ani její hodnotu ze zdrojových dat grafu.

Následující obrázek zobrazuje uloženou prezentaci v PowerPointu:

![Graf Pie of Pie s Online a Události v sekundárním grafu a jejich sloučenou hodnotou 45 v hlavním grafu](pie_of_pie_custom.png)

## **Nastavte automatické barvy segmentů koláčového grafu**

Aspose.Slides pro Android via Java může automaticky přiřadit různé barvy segmentům koláčového grafu. Následující příklad vytvoří koláčový graf se středovým názvem a nahradí výchozí data třemi čtvrtletními kategoriemi a jejich hodnotami. Metoda [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) zobrazuje hodnoty 20, 50 a 30 jako popisky, zatímco [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) povolí odlišnou barvu pro každou výseč.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Přidejte vycentrovaný název grafu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Nahraďte výchozí data pomocí prvního listu.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Zobrazte hodnoty a přiřaďte výsečím různé barvy.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jsou varianty Pie of Pie a Bar of Pie podporovány?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) sekundární graf pro koláčové grafy, včetně typů Pie of Pie a Bar of Pie.

**Mohu exportovat pouze graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (například PNG) bez exportu celé prezentace.