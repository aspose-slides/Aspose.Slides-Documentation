---
title: Axe du graphique
type: docs
url: /fr/nodejs-java/chart-axis/
keywords: "Axe de graphique PowerPoint, Graphiques de présentation, Java, Manipuler l'axe du graphique, Données du graphique"
description: "Comment modifier l'axe du graphique PowerPoint en JavaScript"
---

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**

Aspose.Slides for Node.js via Java vous permet d'obtenir les valeurs minimale et maximale sur un axe vertical. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Obtenez la valeur maximale réelle sur l'axe.
1. Obtenez la valeur minimale réelle sur l'axe.
1. Obtenez l'unité principale réelle de l'axe.
1. Obtenez l'unité secondaire réelle de l'axe.
1. Obtenez l'échelle de l'unité principale réelle de l'axe.
1. Obtenez l'échelle de l'unité secondaire réelle de l'axe.

Ce code d'exemple—une implémentation des étapes ci‑above—vous montre comment obtenir les valeurs requises en JavaScript :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Enregistre la présentation
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Échanger les données entre les axes**

Aspose.Slides vous permet d'échanger rapidement les données entre les axes—les données représentées sur l'axe vertical (axe y) se déplacent vers l'axe horizontal (axe x) et vice‑versa. 

Ce code JavaScript vous montre comment réaliser l'échange de données entre les axes d'un graphique :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Inverse les lignes et les colonnes
    chart.getChartData().switchRowColumn();
    // Enregistre la présentation
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Désactiver l'axe vertical pour les graphiques en courbes**

Ce code JavaScript vous montre comment masquer l'axe vertical d'un graphique en courbes :
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


## **Désactiver l'axe horizontal pour les graphiques en courbes**

Ce code vous montre comment masquer l'axe horizontal d'un graphique en courbes :
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


## **Modifier l'axe des catégories**

En utilisant la propriété **CategoryAxisType**, vous pouvez spécifier le type d'axe des catégories souhaité (**date** ou **text**). Ce code en JavaScript montre l'opération : 
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


## **Définir le format de date pour la valeur de l'axe des catégories**

Aspose.Slides for Node.js via Java vous permet de définir le format de date pour une valeur d'axe des catégories. L'opération est démontrée dans ce code JavaScript :
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


## **Définir l'angle de rotation du titre de l'axe du graphique**

Aspose.Slides for Node.js via Java vous permet de définir l'angle de rotation du titre d'un axe de graphique. Ce code JavaScript montre l'opération :
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


## **Définir la position de l'axe dans un axe de catégorie ou de valeur**

Aspose.Slides for Node.js via Java vous permet de définir la position de l'axe dans un axe de catégorie ou de valeur. Ce code JavaScript montre comment effectuer la tâche :
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


## **Activer l'étiquette d'unité d'affichage sur l'axe des valeurs du graphique**

Aspose.Slides for Node.js via Java vous permet de configurer un graphique pour afficher une étiquette d'unité sur son axe des valeurs. Ce code JavaScript montre l'opération :
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

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axes) ?**

Les axes offrent un [paramètre de croisement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) : vous pouvez choisir de croiser à zéro, au maximum de la catégorie/valeur, ou à une valeur numérique spécifique. Cela est utile pour déplacer l'axe X vers le haut ou le bas ou pour mettre en évidence une ligne de base.

**Comment positionner les libellés des graduations par rapport à l'axe (à côté, à l'extérieur, à l'intérieur) ?**

Définissez la [position du libellé](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) sur "cross", "outside" ou "inside". Cela affecte la lisibilité et aide à économiser de l'espace, surtout sur les petits graphiques.