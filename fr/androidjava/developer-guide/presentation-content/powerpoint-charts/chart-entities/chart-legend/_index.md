---
title: Légende du graphique
type: docs
url: /androidjava/chart-legend/
---

## **Positionnement de la légende**
Afin de définir les propriétés de la légende. Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenez la référence de la diapositive.
- Ajoutez un graphique sur la diapositive.
- Définissez les propriétés de la légende.
- Écrivez la présentation en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons défini la position et la taille de la légende du graphique.

```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenez la référence de la diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoutez un graphique à colonnes groupées sur la diapositive
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Définir les propriétés de la légende
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Écrire la présentation sur le disque
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la taille de la police de la légende**
Aspose.Slides pour Android via Java permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci-dessous :

- Instanciez la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Créez le graphique par défaut.
- Définissez la taille de la police.
- Définissez la valeur minimale de l'axe.
- Définissez la valeur maximale de l'axe.
- Écrivez la présentation sur le disque.

```java
// Créez une instance de la classe Presentation
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

## **Définir la taille de la police d'une légende individuelle**
Aspose.Slides pour Android via Java permet aux développeurs de définir la taille de police des entrées individuelles de la légende. Veuillez suivre les étapes ci-dessous :

- Instanciez la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Créez le graphique par défaut.
- Accédez à l'entrée de la légende.
- Définissez la taille de la police.
- Définissez la valeur minimale de l'axe.
- Définissez la valeur maximale de l'axe.
- Écrivez la présentation sur le disque.

```java
// Créez une instance de la classe Presentation
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