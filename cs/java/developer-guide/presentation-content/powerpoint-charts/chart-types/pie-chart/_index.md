---
title: Přizpůsobení koláčových grafů v prezentacích pomocí Javy
linktitle: Koláčový graf
type: docs
url: /cs/java/pie-chart/
keywords:
- koláčový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výsečky
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte koláčové grafy v Javě pomocí Aspose.Slides. Nakonfigurujte sekundární výsečky, zobrazte popisky dat a použijte automatické barvy výseček v PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nakonfigurovat možnosti sekundárního výsečku pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečků u standardního koláčového grafu.

Příklady se zaměřují na úkoly přizpůsobení grafu, jako je přidání grafu do snímku, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního výsečku pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides for Java podporuje možnosti sekundárního výsečku pro grafy Pie of Pie a Bar of Pie. Tyto možnosti řídí velikost sekundárního výsečku a způsob, jakým jsou datové body rozděleny mezi oba výsečky.

Následující příklad vytvoří graf Pie of Pie v nové prezentaci a zobrazí hodnoty datových bodů jako popisky. Metoda [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) nastaví velikost sekundárního výsečku na 149% hlavního výsečku. [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) vybere rozdělení založené na procentech a [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) nastaví práh na 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Zobrazit hodnoty a nakonfigurovat sekundární výsečku.
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

### **Vyberte kategorie pro sekundární výseček**

Použijte vlastní rozdělení, když chcete seskupit konkrétní kategorie v sekundárním výsečku bez ohledu na jejich procentuální hodnoty. Například prodejní zpráva může zobrazovat Online a Events společně, aby čtenáři mohli porovnat tyto dva kanály, i když představují 35% a 10% z celkových prodejů.

Zavolejte [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) s [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) a vyberte body pomocí [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Metoda [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) kolekce přijímá nulový index v řadě; použijte [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) k přidání objektu datového bodu. V tomto příkladu index 1 vybírá Online a bod s indexem 3 vybírá Events. Partners je také dočasně přidán a poté vyloučen pomocí [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Nahradit výchozí data prodejem podle kanálů.
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

    // Vybrat Online pomocí jeho nulového indexu a Events pomocí objektu datového bodu.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Vyloučit Partners ze výběru bez mazání jeho zdrojových dat.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) a Events (10) se v sekundárním výsečku zobrazují jako samostatné výsečky. V primárním výsečku jsou reprezentovány jednou sloučenou výsečkou s hodnotou 45, spolu s Retail (40) a Partners (15). Odebrání Partners z vlastní volby jej ponechá v primárním výsečku; neodstraní kategorii ani její hodnotu ze zdrojových dat grafu.

Následující obrázek ukazuje uloženou prezentaci v PowerPointu:

![Graf Pie of Pie s Online a Events v sekundárním výsečku a jejich sloučenou hodnotou 45 v primárním výsečku](pie_of_pie_custom.png)

## **Nastavte automatické barvy výseček koláčového grafu**

Aspose.Slides for Java může automaticky přiřadit různé barvy výsečkám koláčového grafu. Následující příklad vytvoří koláčový graf se zarovnaným titulkem a nahradí výchozí data třemi čtvrtletními kategoriemi a jejich hodnotami. Metoda [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) zobrazí hodnoty 20, 50 a 30 jako popisky, zatímco [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) umožní odlišnou barvu pro každou výsečku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Přidat centrovaný název grafu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Nahradit výchozí data pomocí první sešitu.
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

    // Zobrazit hodnoty a přiřadit různé barvy výsečkám.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jsou varianty Pie of Pie a Bar of Pie podporovány?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) sekundární výseček pro koláčové grafy, včetně typů Pie of Pie a Bar of Pie.

**Mohu exportovat jen graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (například PNG) bez exportování celé prezentace.