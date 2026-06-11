---
title: Anpassa diagramaxlar i presentationer med JavaScript
linktitle: Diagramaxel
type: docs
url: /sv/nodejs-java/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axeltitel
- axelposition
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur du använder JavaScript med Aspose.Slides för Node.js via Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur du anpassar diagramaxlar i Aspose.Slides. Den visar hur du hämtar faktiska axelvärden, byter data mellan axlar, döljer den vertikala eller horisontella axeln för linjediagram, ändrar kategori‑axeltyp, anger datumformat för kategori‑axelvärden, roterar en axeltitel, ställer in axelposition och visar en enhetsetikett på värdeaxeln.

## **Hämta maxvärden på den vertikala axeln i diagram**

Aspose.Slides för Node.js via Java låter dig erhålla minimi- och maximivärden på en vertikal axel. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Få åtkomst till den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta det faktiska maxvärdet på axeln.
1. Hämta det faktiska minvärdet på axeln.
1. Hämta den faktiska huvudenheten för axeln.
1. Hämta den faktiska delenheten för axeln.
1. Hämta den faktiska skalan för huvudenheten på axeln.
1. Hämta den faktiska skalan för delenheten på axeln.

Exempelkoden – en implementering av stegen ovan – visar hur du får de nödvändiga värdena i JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Sparar presentationen
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Byta data mellan axlarna**

Aspose.Slides låter dig snabbt byta data mellan axlarna – data som visas på den vertikala axeln (y‑axeln) flyttas till den horisontella axeln (x‑axeln) och vice versa.

Denna JavaScript‑kod visar hur du utför datautbytet mellan axlarna i ett diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Byter rader och kolumner
    chart.getChartData().switchRowColumn();
    // Sparar presentationen
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Inaktivera den vertikala axeln för linjediagram**

Denna JavaScript‑kod visar hur du döljer den vertikala axeln för ett linjediagram:

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

## **Inaktivera den horisontella axeln för linjediagram**

Denna kod visar hur du döljer den horisontella axeln för ett linjediagram:

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

## **Ändra kategori‑axel**

Genom att använda egenskapen **CategoryAxisType** kan du ange önskad kategori‑axeltyp (**date** eller **text**). Denna JavaScript‑kod demonstrerar operationen:

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

## **Ställa in datumformat för kategori‑axelvärde**

Aspose.Slides för Node.js via Java låter dig ange datumformat för ett kategori‑axelvärde. Operationen demonstreras i denna JavaScript‑kod:

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

## **Ställa in rotationsvinkeln för diagramaxelns titel**

Aspose.Slides för Node.js via Java låter dig ange rotationsvinkeln för en diagramaxeltitel. Denna JavaScript‑kod demonstrerar operationen:

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

## **Ställa in positionsaxeln i en kategori‑ eller värdeaxel**

Aspose.Slides för Node.js via Java låter dig ange positionsaxeln i en kategori‑ eller värdeaxel. Denna JavaScript‑kod visar hur du utför uppgiften:

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

## **Aktivera visning av enheten på diagrammets värdeaxel**

Aspose.Slides för Node.js via Java låter dig konfigurera ett diagram så att en enhetsetikett visas på dess värdeaxel. Denna JavaScript‑kod demonstrerar operationen:

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

## **Vanliga frågor**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Axlarna har en [korsningsinställning](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/axis/setcrosstype/): du kan välja att korsas vid noll, vid den maximala kategori‑/värdet, eller vid ett specifikt numeriskt värde. Detta är användbart för att flytta X‑axeln upp eller ner eller för att betona en baslinje.

**Hur kan jag placera tick‑etiketterna i förhållande till axeln (bredvid, ute, inne)?**

Ställ in [etikettens position](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/axis/setmajortickmark/) till "cross", "outside" eller "inside". Detta påverkar läsbarheten och hjälper till att spara utrymme, särskilt i små diagram.