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
description: "Naučte se, jak vytvářet a přizpůsobovat koláčové grafy v Javě pomocí Aspose.Slides pro Android, exportovatelné do PowerPointu, a během několika sekund posílit vyprávění vašich dat."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nastavit možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů pro standardní koláčový graf.

Příklady se zaměřují na praktické kroky přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie**
Aspose.Slides pro Android přes Java nyní podporuje možnosti sekundárního vykreslení pro grafy Pie of Pie nebo Bar of Pie. V tomto tématu vám ukážeme, jak tyto možnosti nastavit pomocí Aspose.Slides. Pro nastavení vlastností postupujte takto:

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Přidejte graf na snímek.
3. Zadejte možnosti sekundárního vykreslení grafu.
4. Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili různé vlastnosti grafu Pie of Pie.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Přidejte graf na snímek
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Nastavte různé vlastnosti
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Uložte prezentaci na disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit automatické barvy výsečů koláčového grafu**
Aspose.Slides pro Android přes Java poskytuje jednoduché API pro nastavení automatických barev výsečů koláčového grafu. Vzorový kód uplatňuje nastavení výše uvedených vlastností.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte první snímek.
3. Přidejte graf s výchozími daty.
4. Nastavte název grafu.
5. Nastavte první řadu na Zobrazit hodnoty.
6. Nastavte index listu s daty grafu.
7. Získání listu s daty grafu.
8. Odstraňte výchozí vygenerované řady a kategorie.
9. Přidejte nové kategorie.
10. Přidejte nové řady.

Uložte upravenou prezentaci do souboru PPTX.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Přidejte graf s výchozími daty
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Nastavení názvu grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Nastavte první řadu na Zobrazit hodnoty
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Nastavení indexu listu s daty grafu
    int defaultWorksheetIndex = 0;

    // Získání listu s daty grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Odstraňte výchozí vygenerované řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Přidávání nových kategorií
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Přidávání nových řad
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Nyní naplňujeme data řady
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jsou podporovány varianty 'Pie of Pie' a 'Bar of Pie'?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/) sekundární vykreslení pro koláčové grafy, včetně typů 'Pie of Pie' a 'Bar of Pie'.

**Mohu exportovat jen graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (například PNG) bez celé prezentace.