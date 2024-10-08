---
title: Légende du graphique
type: docs
url: /fr/java/chart-legend/
---

## **Positionnement de la légende**
Afin de définir les propriétés de la légende. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenez la référence de la diapositive.
- Ajouter un graphique sur la diapositive.
- Définir les propriétés de la légende.
- Écrire la présentation en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons défini la position et la taille de la légende du graphique.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Get reference of the slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add a clustered column chart on the slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Set Legend Properties
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Write presentation to disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la taille de police de la légende**
Aspose.Slides pour Java permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci-dessous : 

- Instancier la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Définir la taille de la police.
- Définir la valeur minimale de l'axe.
- Définir la valeur maximale de l'axe.
- Écrire la présentation sur le disque.

```java
// Create an instance of Presentation class
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

## **Définir la taille de police d'une légende individuelle**
Aspose.Slides pour Java permet aux développeurs de définir la taille de police des entrées individuelles de la légende. Veuillez suivre les étapes ci-dessous : 

- Instancier la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Accéder à l'entrée de la légende.
- Définir la taille de la police.
- Définir la valeur minimale de l'axe.
- Définir la valeur maximale de l'axe.
- Écrire la présentation sur le disque.

```java
// Create an instance of Presentation class
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