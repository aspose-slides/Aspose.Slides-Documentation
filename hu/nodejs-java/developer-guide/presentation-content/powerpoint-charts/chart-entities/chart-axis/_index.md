---
title: Diagramtengelyek testreszabása prezentációkban JavaScript használatával
linktitle: Diagram tengely
type: docs
url: /hu/nodejs-java/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengely vonal
- dátumformátum
- tengely cím
- tengely pozíció
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja a JavaScript-et az Aspose.Slides for Node.js via Java‑val a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentésekhez és vizualizációkhoz."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides-ban. Bemutatja, hogyan lehet lekérni a tényleges tengelyértékeket, adatokat cserélni a tengelyek között, elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramok esetén, módosítani a kategória tengely típusát, beállítani a dátumformátumot a kategória tengely értékeihez, elforgatni a tengely címét, beállítani a tengely helyzetét, és megjeleníteni egységcímkét az érték tengelyen.

## **A függőleges tengely maximális értékeinek lekérése diagramokon**

Aspose.Slides for Node.js via Java lehetővé teszi a minimális és maximális értékek lekérését egy függőleges tengelyen. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Férjen hozzá az első diára.
1. Adjon hozzá egy diagramot az alapértelmezett adatokkal.
1. Szerezze meg a tényleges maximális értéket a tengelyen.
1. Szerezze meg a tényleges minimális értéket a tengelyen.
1. Szerezze meg a tényleges fő egységet a tengelyen.
1. Szerezze meg a tényleges másodlagos egységet a tengelyen.
1. Szerezze meg a tényleges fő egységskálát a tengelyen.
1. Szerezze meg a tényleges másodlagos egységskálát a tengelyen.

Ez a példakód – a fenti lépések megvalósítása – megmutatja, hogyan lehet lekérni a szükséges értékeket JavaScript-ben:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Mentse a prezentációt
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adatok cseréje a tengelyek között**

Aspose.Slides lehetővé teszi, hogy gyorsan cserélje az adatokat a tengelyek között – a függőleges tengelyen (y-tengely) szereplő adatok a vízszintes tengelyre (x-tengely) kerülnek, és fordítva.

Ez a JavaScript kód megmutatja, hogyan hajtsa végre az adatcserét a tengelyek között egy diagramon:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Átcseréli a sorokat és oszlopokat
    chart.getChartData().switchRowColumn();
    // Mentse a prezentációt
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **A függőleges tengely letiltása vonaldiagramokhoz**

Ez a JavaScript kód megmutatja, hogyan lehet elrejteni a függőleges tengelyt egy vonaldiagramon:

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

## **A vízszintes tengely letiltása vonaldiagramokhoz**

Ez a kód megmutatja, hogyan lehet elrejteni a vízszintes tengelyt egy vonaldiagramon:

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

## **Kategória tengely módosítása**

A **CategoryAxisType** tulajdonság használatával megadhatja a kívánt kategória tengely típusát (**date** vagy **text**). Ez a JavaScript kód bemutatja a műveletet:

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

## **Dátumformátum beállítása a kategória tengely értékéhez**

Aspose.Slides for Node.js via Java lehetővé teszi a dátumformátum beállítását egy kategória tengely értékéhez. A műveletet ez a JavaScript kód mutatja be:

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

## **Forgatási szög beállítása a diagram tengely címéhez**

Aspose.Slides for Node.js via Java lehetővé teszi a forgatási szög beállítását egy diagram tengely címéhez. Ez a JavaScript kód mutatja be a műveletet:

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

## **Tengely pozíció beállítása kategória vagy érték tengelyen**

Aspose.Slides for Node.js via Java lehetővé teszi a tengely pozíció beállítását kategória vagy érték tengelyen. Ez a JavaScript kód megmutatja, hogyan hajtható végre a feladat:

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

## **Egységcímke megjelenítésének engedélyezése a diagram érték tengelyen**

Aspose.Slides for Node.js via Java lehetővé teszi, hogy egy diagramot úgy konfiguráljon, hogy egységcímkét jelenítsen meg a diagram érték tengelyén. Ez a JavaScript kód mutatja be a műveletet:

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

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol az egyik tengely áthalad a másikon (tengelykereszt)?**

A tengelyek egy [keresztbeállítást](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/axis/setcrosstype/) biztosítanak: beállíthatja, hogy a keresztezés nullánál, a maximális kategóriánál/értéknél vagy egy meghatározott numerikus értéknél történjen. Ez hasznos az X-tengely fel vagy le mozgatásához, illetve egy alapvonal kiemeléséhez.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva (mellett, kívül, belül)?**

Állítsa be a [címke pozíciót](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/axis/setmajortickmark/) „cross”, „outside” vagy „inside” értékre. Ez befolyásolja az olvashatóságot, és segít helyet spórolni, különösen kis diagramok esetén.