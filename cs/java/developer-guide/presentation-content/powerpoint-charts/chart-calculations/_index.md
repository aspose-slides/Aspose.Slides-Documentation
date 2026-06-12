---
title: Optimalizace výpočtů grafů pro prezentace v Javě
linktitle: Výpočty grafů
type: docs
weight: 50
url: /cs/java/chart-calculations/
keywords:
- výpočty grafů
- prvky grafu
- pozice prvku
- skutečná pozice
- dětský prvek
- rodičovský prvek
- hodnoty grafu
- skutečná hodnota
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Pochopte výpočty grafů, aktualizace dat a řízení přesnosti v Aspose.Slides pro Javu pro PPT a PPTX, s praktickými příklady kódu v Javě."
---
## **Přehled**

Aspose.Slides poskytuje rozhraní API pro práci s výpočty grafů a údaji o uspořádání v prezentacích. Tento článek ukazuje, jak získat skutečné hodnoty prvků grafu, včetně skutečné polohy a velikosti prvků, které implementují `IActualLayout`, a skutečné hodnoty os grafu. Také vysvětluje, že tyto hodnoty jsou vyplněny po ověření uspořádání grafu.

## **Vypočítat skutečné hodnoty prvků grafu**
Aspose.Slides for Java poskytuje jednoduché API pro získání těchto vlastností. Vlastnosti rozhraní [IAxis](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAxis) poskytují informace o skutečné pozici prvku osy grafu ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Je nutné předtím zavolat metodu [IChart.validateChartLayout()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChart#validateChartLayout--), aby se vlastnosti naplnily skutečnými hodnotami.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vypočítat skutečnou polohu nadřazených prvků grafu**
Aspose.Slides for Java poskytuje jednoduché API pro získání těchto vlastností. Vlastnosti rozhraní [IActualLayout](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IActualLayout) poskytují informace o skutečné poloze nadřazeného prvku grafu ([IActualLayout.getActualX](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IActualLayout#getActualHeight--)). Je nutné předtím zavolat metodu [IChart.validateChartLayout()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChart#validateChartLayout--), aby se vlastnosti naplnily skutečnými hodnotami.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Skrýt prvky grafu**
Tento článek vám pomůže pochopit, jak skrýt informace v grafu. Pomocí Aspose.Slides for Java můžete skrýt **Název, Svislou osu, Vodorovnou osu** a **Mřížkové čáry** v grafu. Níže uvedený příklad kódu ukazuje, jak tyto vlastnosti použít.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Skrytí názvu grafu
    chart.setTitle(false);

    ///Skrytí osy hodnot
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Viditelnost osy kategorií
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Skrytí legendy
    chart.setLegend(false);

    //Skrytí hlavních mřížkových čar
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Nastavení barvy čáry řady
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Fungují externí sešity Excelu jako zdroj dat a jak to ovlivňuje přepočet?**

Ano. Graf může odkazovat na externí sešit: když připojíte nebo obnovíte externí zdroj, vzorce a hodnoty jsou převzaty z tohoto sešitu a graf odráží aktualizace během operací otevření/úpravy. API vám umožňuje [specifikovat cestu k externímu sešitu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) a spravovat propojená data.

**Mohu vypočítat a zobrazit čáry trendu bez implementace regrese sám?**

Ano. [Čáry trendu](/slides/cs/java/trend-line/) (lineární, exponenciální a další) jsou přidávány a aktualizovány pomocí Aspose.Slides; jejich parametry jsou automaticky přepočítány z dat série, takže nemusíte implementovat vlastní výpočty.

**Pokud má prezentace více grafů s externími odkazy, mohu řídit, který sešit každý graf používá pro vypočítané hodnoty?**

Ano. Každý graf může ukazovat na svůj vlastní [externí sešit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), nebo můžete pro každý graf nezávisle vytvořit/nahradit externí sešit.