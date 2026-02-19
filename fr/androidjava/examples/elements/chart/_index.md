---
title: Graphique
type: docs
weight: 60
url: /fr/androidjava/examples/elements/chart/
keywords:
- exemple de code
- graphique
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Maîtrisez les graphiques avec Aspose.Slides pour Android: créez, formatez, liez les données et exportez les graphiques en PPT, PPTX et ODP avec des exemples Java."
---
Exemples d'ajout, d'accès, de suppression et de mise à jour de différents types de graphiques avec **Aspose.Slides for Android via Java**. Les extraits ci-dessous démontrent les opérations de base sur les graphiques.

## **Ajouter un graphique**

Cette méthode ajoute un graphique en aires simple à la première diapositive.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Ajoutez un graphique en aires simple à la première diapositive.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un graphique**

Après avoir créé un graphique, vous pouvez le récupérer via la collection de formes.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Accédez au premier graphique sur la diapositive.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un graphique**

Le code suivant supprime un graphique d'une diapositive.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Supprimez le graphique.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Mettre à jour les données du graphique**

Vous pouvez modifier les propriétés du graphique, comme le titre.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Modifiez le titre du graphique.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```