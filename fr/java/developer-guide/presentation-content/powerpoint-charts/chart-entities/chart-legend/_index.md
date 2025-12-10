---
title: Personnaliser les légendes de graphiques dans les présentations avec Java
linktitle: Légende de graphique
type: docs
url: /fr/java/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides for Java pour optimiser les présentations PowerPoint avec un formatage de légende adapté."
---

## **Position de la légende**
Afin de définir les propriétés de la légende, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenir la référence de la diapositive.
- Ajouter un graphique sur la diapositive.
- Définir les propriétés de la légende.
- Enregistrer la présentation sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons défini la position et la taille de la légende du graphique.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la référence de la diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter un diagramme à colonnes groupées sur la diapositive
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Définir les propriétés de la légende
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Enregistrer la présentation sur le disque
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la taille de police d’une légende**
Aspose.Slides for Java permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci‑dessus :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Définir la taille de police.
- Définir la valeur minimale de l'axe.
- Définir la valeur maximale de l'axe.
- Enregistrer la présentation sur le disque.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la taille de police d’une entrée de légende individuelle**
Aspose.Slides for Java permet aux développeurs de définir la taille de police des entrées individuelles de la légende. Veuillez suivre les étapes ci‑dessus :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Accéder à l'entrée de la légende.
- Définir la taille de police.
- Définir la valeur minimale de l'axe.
- Définir la valeur maximale de l'axe.
- Enregistrer la présentation sur le disque.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Oui. Utilisez le mode non superposé ([setOverlay(false)](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)); dans ce cas, la zone de tracé sera réduite pour accueillir la légende.

**Can I make multi-line legend labels?**

Oui. Les libellés longs se renvoient automatiquement quand l'espace est insuffisant; les sauts de ligne forcés sont pris en charge via les caractères de nouvelle ligne dans le nom de la série.

**How do I make the legend follow the presentation theme’s color scheme?**

Ne définissez pas de couleurs, remplissages ou polices explicites pour la légende ou son texte. Ils hériteront alors du thème et seront mis à jour correctement lorsque le design changera.