---
title: Graphique
type: docs
weight: 60
url: /fr/nodejs-java/examples/elements/chart/
keywords:
- exemple de code
- graphique
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Maîtrisez les graphiques avec Aspose.Slides pour Node.js via Java : créez, formatez, liez des données et exportez des graphiques au format PPT, PPTX et ODP avec des exemples JavaScript."
---
Exemples d'ajout, d'accès, de suppression et de mise à jour de différents types de graphiques avec **Aspose.Slides for Node.js via Java**. Les extraits ci-dessous démontrent les opérations de base sur les graphiques.

## **Ajouter un graphique**

Cette méthode ajoute un graphique en aires simple à la première diapositive.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Ajouter un graphique en aires simple à la première diapositive.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un graphique**

Après avoir créé un graphique, vous pouvez le récupérer via la collection de formes.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accéder au premier graphique sur la diapositive.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un graphique**

Le code suivant supprime le graphique de la diapositive.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supprimer le graphique.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Mettre à jour les données du graphique**

Vous pouvez modifier les propriétés du graphique, comme le titre.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Modifier le titre du graphique.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```