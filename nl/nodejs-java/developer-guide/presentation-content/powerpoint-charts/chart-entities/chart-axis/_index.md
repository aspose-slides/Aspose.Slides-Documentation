---
title: Grafiekassen aanpassen in presentaties met JavaScript
linktitle: Grafiekas
type: docs
url: /nl/nodejs-java/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe u JavaScript met Aspose.Slides voor Node.js via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint‑presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe je de assen van een grafiek kunt aanpassen in Aspose.Slides. Het laat zien hoe je de werkelijke aswaarden kunt ophalen, gegevens tussen assen kunt verwisselen, de verticale of horizontale as kunt verbergen voor lijndiagrammen, het type categorie‑as kunt wijzigen, de datumnotatie voor categorie‑aswaarden kunt instellen, een as‑titel kunt roteren, de aspositie kunt instellen en een eenheidslabel op de waardenas kunt weergeven.

## **De maximale waarden op de verticale as van grafieken ophalen**

Aspose.Slides voor Node.js via Java stelt je in staat om de minimum- en maximumwaarden op een verticale as te verkrijgen. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
1. Open de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Haal de werkelijke maximale waarde van de as op.
1. Haal de werkelijke minimumwaarde van de as op.
1. Haal de werkelijke hoofd eenheid van de as op.
1. Haal de werkelijke subeenheid van de as op.
1. Haal de werkelijke schaal van de hoofd eenheid van de as op.
1. Haal de werkelijke schaal van de subeenheid van de as op.

Deze voorbeeldcode — een implementatie van de bovenstaande stappen — laat zien hoe je de benodigde waarden in JavaScript kunt verkrijgen:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Slaat de presentatie op
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gegevens tussen assen verwisselen**

Aspose.Slides maakt het mogelijk om snel de gegevens tussen assen te verwisselen — de gegevens die op de verticale as (y-as) staan, worden verplaatst naar de horizontale as (x-as) en omgekeerd. 

Deze JavaScript‑code laat zien hoe je de gegevens‑verwisseling tussen assen op een grafiek kunt uitvoeren:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Wisselt rijen en kolommen
    chart.getChartData().switchRowColumn();
    // Slaat presentatie op
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **De verticale as uitschakelen voor lijndiagrammen**

Deze JavaScript‑code laat zien hoe je de verticale as voor een lijndiagram kunt verbergen:

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

## **De horizontale as uitschakelen voor lijndiagrammen**

Deze code laat zien hoe je de horizontale as voor een lijndiagram kunt verbergen:

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

## **Categorie‑as wijzigen**

Met de eigenschap **CategoryAxisType** kun je het gewenste type van de categorie‑as aangeven (**date** of **text**). Deze JavaScript‑code demonstreert de bewerking: 

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

## **Datumnotatie instellen voor categorie‑aswaarde**

Aspose.Slides voor Node.js via Java stelt je in staat om de datumnotatie voor een categorie‑aswaarde in te stellen. De bewerking wordt aangetoond in deze JavaScript‑code:

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

## **Rotatiehoek instellen voor grafiek‑as‑titel**

Aspose.Slides voor Node.js via Java maakt het mogelijk om de rotatiehoek voor een grafiek‑as‑titel in te stellen. Deze JavaScript‑code demonstreert de bewerking:

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

## **As‑positie instellen in een categorie‑ of waardenas**

Aspose.Slides voor Node.js via Java maakt het mogelijk om de as‑positie in een categorie‑ of waardenas in te stellen. Deze JavaScript‑code laat zien hoe je de taak kunt uitvoeren:

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

## **Het eenheidslabel weergeven op de waardenas van een grafiek inschakelen**

Aspose.Slides voor Node.js via Java maakt het mogelijk om een grafiek zo te configureren dat een eenheidslabel op de waardenas wordt weergegeven. Deze JavaScript‑code demonstreert de bewerking:

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

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Assen bieden een [kruising‑instelling](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/axis/setcrosstype/): je kunt kiezen om te kruisen bij nul, bij de maximale categorie/waarde, of bij een specifieke numerieke waarde. Dit is handig om de X-as omhoog of omlaag te verplaatsen of om een basislijn te benadrukken.

**Hoe kan ik tick‑labels ten opzichte van de as positioneren (naast, buiten, binnen)?**

Stel de [label‑positie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/axis/setmajortickmark/) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en helpt ruimte te besparen, vooral bij kleine grafieken.