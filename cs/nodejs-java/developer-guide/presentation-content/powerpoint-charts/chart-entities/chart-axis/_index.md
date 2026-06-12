---
title: Přizpůsobení os grafu v prezentacích pomocí JavaScriptu
linktitle: Osa grafu
type: docs
url: /cs/nodejs-java/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobit osu
- manipulovat osou
- spravovat osu
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte, jak pomocí JavaScriptu s Aspose.Slides pro Node.js přes Java přizpůsobit osy grafů v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu v Aspose.Slides. Ukazuje, jak získat skutečné hodnoty os, vyměnit data mezi osami, skrýt svislou nebo vodorovnou osu pro čárové grafy, změnit typ osy kategorií, nastavit formát data pro hodnoty osy kategorií, otočit název osy, nastavit polohu osy a zobrazit jednotkový popisek na ose hodnot.

## **Získání maximálních hodnot na svislé ose v grafech**

Aspose.Slides pro Node.js přes Java vám umožňuje získat minimální a maximální hodnoty na svislé ose. Projděte následující kroky:

1. Vytvořte instanci třídy[Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Přistupte k prvnímu snímku.
3. Přidejte graf s výchozími daty.
4. Získejte skutečnou maximální hodnotu na ose.
5. Získejte skutečnou minimální hodnotu na ose.
6. Získejte skutečnou hlavní jednotku osy.
7. Získejte skutečnou vedlejší jednotku osy.
8. Získejte skutečné měřítko hlavní jednotky osy.
9. Získejte skutečné měřítko vedlejší jednotky osy.

Tento ukázkový kód — implementace výše uvedených kroků — ukazuje, jak získat požadované hodnoty v JavaScriptu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Uloží prezentaci
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Prohození dat mezi osami**

Aspose.Slides vám umožňuje rychle prohodit data mezi osami — data zobrazená na svislé ose (y-osa) se přesunou na vodorovnou osu (x-osa) a naopak.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Přepne řádky a sloupce
    chart.getChartData().switchRowColumn();
    // Uloží prezentaci
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zakázání svislé osy pro čárové grafy**

Tento JavaScriptový kód ukazuje, jak skrýt svislou osu pro čárový graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zakázání vodorovné osy pro čárové grafy**

Tento kód ukazuje, jak skrýt vodorovnou osu pro čárový graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Změna osy kategorií**

Pomocí vlastnosti **CategoryAxisType** můžete určit preferovaný typ osy kategorií (**date** nebo **text**). Tento kód v JavaScriptu demonstruje operaci: 

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Nastavení formátu data pro hodnotu osy kategorií**

Aspose.Slides pro Node.js přes Java vám umožňuje nastavit formát data pro hodnotu osy kategorií. Operace je demonstrována v tomto JavaScriptovém kódu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **Nastavení úhlu otáčení názvu osy grafu**

Aspose.Slides pro Node.js přes Java vám umožňuje nastavit úhel otáčení názvu osy grafu. Tento JavaScriptový kód demonstruje operaci:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení polohy osy v ose kategorií nebo hodnot**

Aspose.Slides pro Node.js přes Java vám umožňuje nastavit polohu osy v ose kategorií nebo hodnot. Tento JavaScriptový kód ukazuje, jak úkol provést:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Povolení zobrazování jednotkového popisku na ose hodnot grafu**

Aspose.Slides pro Node.js přes Java vám umožňuje nakonfigurovat graf tak, aby zobrazoval jednotkový popisek na své ose hodnot. Tento JavaScriptový kód demonstruje operaci:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**

Osové poskytují [nastavení průsečíku](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/axis/setcrosstype/): můžete zvolit průsečík v nule, na maximální hodnotě kategorie/hodnoty nebo na konkrétní číselné hodnotě. To je užitečné pro posunutí osy X nahoru nebo dolů nebo pro zdůraznění základní linie.

**Jak mohu umístit popisky značek relativně k ose (vedle, vně, uvnitř)?**

Nastavte [polohu popisků](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/axis/setmajortickmark/) na "cross", "outside" nebo "inside". To ovlivňuje čitelnost a pomáhá šetřit místo, zejména u malých grafů.