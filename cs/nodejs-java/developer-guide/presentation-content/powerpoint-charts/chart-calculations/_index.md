---
title: Optimalizace výpočtů grafů pro prezentace v JavaScriptu
linktitle: Výpočty grafů
type: docs
weight: 50
url: /cs/nodejs-java/chart-calculations/
keywords:
- výpočty grafů
- prvky grafu
- pozice prvku
- skutečná pozice
- podřízený prvek
- nadřazený prvek
- hodnoty grafu
- skutečná hodnota
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Pochopte výpočty grafů, aktualizace dat a řízení přesnosti v Aspose.Slides pro Node.js pro formáty PPT a PPTX s praktickými příklady kódu v JavaScriptu."
---
## **Přehled**

Aspose.Slides poskytuje rozhraní API pro práci s výpočty grafů a údaji o rozložení v prezentacích. Tento článek ukazuje, jak získat skutečné hodnoty prvků grafu, včetně skutečné polohy a velikosti prvků a skutečných hodnot os grafu. Také vysvětluje, že tyto hodnoty jsou naplněny po ověření rozložení grafu.

Kromě toho článek ukazuje, jak získat skutečnou polohu nadřazených prvků grafu a jak skrýt komponenty grafu, jako jsou název, osy, legenda a mřížkové čáry. Tyto příklady vám společně pomáhají kontrolovat informace o rozložení grafu a řídit viditelnost prvků grafu v prezentacích PowerPoint programově.

## **Vypočítat skutečné hodnoty prvků grafu**

Aspose.Slides pro Node.js via Java poskytuje jednoduché rozhraní API pro získání těchto vlastností. Vlastnosti třídy [Axis](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Axis) poskytují informace o skutečné pozici osy grafu ([Axis.getActualMaxValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Je nutné předtím zavolat metodu [Chart.validateChartLayout()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Chart#validateChartLayout--) , aby byly vlastnosti naplněny skutečnými hodnotami.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vypočítat skutečnou pozici nadřazených prvků grafu**

Aspose.Slides pro Node.js via Java poskytuje jednoduché rozhraní API pro získání těchto vlastností. Vlastnosti třídy `ActualLayout` poskytují informace o skutečné pozici nadřazeného prvku grafu `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Je nutné předtím zavolat metodu [Chart.validateChartLayout()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Chart#validateChartLayout--) , aby byly vlastnosti naplněny skutečnými hodnotami.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Skrýt informace v grafu**

Toto téma vám pomůže pochopit, jak skrýt informace v grafu. Pomocí Aspose.Slides pro Node.js via Java můžete skrýt **Title, Vertical Axis, Horizontal Axis** a **Grid Lines** v grafu. Níže uvedený příklad kódu ukazuje, jak tyto vlastnosti použít.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Skrytí názvu grafu
    chart.setTitle(false);
    // /Skrytí osy hodnot
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Viditelnost osy kategorií
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Skrytí legendy
    chart.setLegend(false);
    // Skrytí hlavních mřížkových čar
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Nastavení barvy čáry řady
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Používají se externí sešity Excelu jako zdroj dat a jaký to má vliv na přepočet?**

Ano. Graf může odkazovat na externí sešit: když připojíte nebo obnovíte externí zdroj, vzorce a hodnoty jsou převzaty z tohoto sešitu a graf během operací otevření/úpravy odráží aktualizace. API vám umožňuje [specify the external workbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) cestu a spravovat propojená data.

**Mohu vypočítat a zobrazit čáry trendu, aniž bych implementoval regresi sám?**

Ano. [Trendlines](/slides/cs/nodejs-java/trend-line/) (lineární, exponenciální a další) jsou přidávány a aktualizovány Aspose.Slides; jejich parametry jsou automaticky přepočítány ze série dat, takže nemusíte implementovat vlastní výpočty.

**Pokud má prezentace více grafů s externími odkazy, mohu řídit, který sešit používá každý graf pro vypočtené hodnoty?**

Ano. Každý graf může odkazovat na svůj vlastní [external workbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), nebo můžete pro každý graf nezávisle vytvořit/nahradit externí sešit.