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
- barva výseče
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat koláčové grafy v Javě pomocí Aspose.Slides, exportovatelné do PowerPointu, a tak během několika sekund vylepšit vyprávění dat."
---
## **Přehled**

Článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nastavit možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů pro standardní koláčový graf.

Příklady se zaměřují na praktické kroky přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides for Java nyní podporuje možnosti sekundárního vykreslení pro grafy Pie of Pie nebo Bar of Pie. V tomto tématu vám ukážeme, jak pomocí Aspose.Slides tyto možnosti nastavit. Pro nastavení vlastností postupujte následovně:

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Přidejte graf na snímek.
3. Zadejte možnosti sekundárního vykreslení grafu.
4. Zapíšete prezentaci na disk.

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

## **Nastavení automatických barev výsečů koláčového grafu**

Aspose.Slides for Java poskytuje jednoduché API pro nastavení automatických barev výsečů koláčového grafu. Vzorový kód ukazuje nastavení výše uvedených vlastností.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Načtěte první snímek.
3. Přidejte graf s výchozími daty.
4. Nastavte název grafu.
5. Nastavte první řadu tak, aby zobrazovala hodnoty.
6. Nastavte index listu s daty grafu.
7. Získání listu s daty grafu.
8. Odstraňte výchozí vytvořené řady a kategorie.
9. Přidejte nové kategorie.
10. Přidejte novou řadu.

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

    // Nastavte první řadu, aby zobrazovala hodnoty
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Nastavení indexu listu s daty grafu
    int defaultWorksheetIndex = 0;

    // Získání listu s daty grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Odstraňte výchozí vytvořené řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Přidání nových kategorií
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Přidání nové řady
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

## **Často kladené otázky**

**Jsou podporovány varianty 'Pie of Pie' a 'Bar of Pie'?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/) sekundární vykreslení pro koláčové grafy, včetně typů 'Pie of Pie' a 'Bar of Pie'.

**Mohu exportovat pouze graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-) (například PNG) bez celé prezentace.