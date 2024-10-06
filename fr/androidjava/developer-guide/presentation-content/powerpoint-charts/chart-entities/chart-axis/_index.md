---
title: Axe de graphique
type: docs
url: /androidjava/chart-axis/
keywords: "Axe de graphique PowerPoint, Graphiques de présentation, Java, Manipuler l'axe de graphique, Données de graphique"
description: "Comment modifier l'axe de graphique PowerPoint en Java"
---


## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**
Aspose.Slides pour Android via Java vous permet d'obtenir les valeurs minimales et maximales sur un axe vertical. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Obtenez la valeur maximale réelle sur l'axe.
1. Obtenez la valeur minimale réelle sur l'axe.
1. Obtenez l'unité majeure réelle de l'axe.
1. Obtenez l'unité mineure réelle de l'axe.
1. Obtenez l'échelle de l'unité majeure réelle de l'axe.
1. Obtenez l'échelle de l'unité mineure réelle de l'axe.

Ce code d'exemple - une implémentation des étapes ci-dessus - vous montre comment obtenir les valeurs requises en Java :

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

    // Sauvegarde de la présentation
    pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Échanger les données entre les axes**
Aspose.Slides vous permet d'échanger rapidement les données entre les axes - les données représentées sur l'axe vertical (axe des y) passent à l'axe horizontal (axe des x) et vice versa.

Ce code Java vous montre comment effectuer la tâche d'échange de données entre les axes sur un graphique :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

    // Échange les lignes et les colonnes
    chart.getChartData().switchRowColumn();

    // Sauvegarde de la présentation
    pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Désactiver l'axe vertical pour les graphiques en ligne**

Ce code Java vous montre comment masquer l'axe vertical pour un graphique en ligne :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Désactiver l'axe horizontal pour les graphiques en ligne**

Ce code vous montre comment masquer l'axe horizontal pour un graphique en ligne :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Changer l'axe de catégorie**

En utilisant la propriété **CategoryAxisType**, vous pouvez spécifier votre type d'axe de catégorie préféré (**date** ou **text**). Ce code en Java démontre l'opération :

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Définir le format de date pour la valeur de l'axe de catégorie**
Aspose.Slides pour Android via Java vous permet de définir le format de date pour une valeur d'axe de catégorie. L'opération est démontrée dans ce code Java :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **Définir l'angle de rotation pour le titre de l'axe du graphique**
Aspose.Slides pour Android via Java vous permet de définir l'angle de rotation pour un titre d'axe de graphique. Ce code Java démontre l'opération :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir l'axe de position dans un axe de catégorie ou de valeur**
Aspose.Slides pour Android via Java vous permet de définir l'axe de position dans un axe de catégorie ou de valeur. Ce code Java montre comment réaliser la tâche :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Activer l'affichage de l'unité d'étiquette sur l'axe de valeur du graphique**
Aspose.Slides pour Android via Java vous permet de configurer un graphique pour afficher une étiquette d'unité sur son axe de valeur. Ce code Java démontre l'opération :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```