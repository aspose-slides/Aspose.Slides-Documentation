---
title: Personnaliser les légendes de graphiques dans les présentations sur Android
linktitle: Légende du graphique
type: docs
url: /fr/androidjava/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides pour Android via Java afin d'optimiser les présentations PowerPoint avec un formatage de légende adapté."
---

## **Positionnement de la légende**
Pour définir les propriétés de la légende, suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence de la diapositive.
- Ajouter un graphique sur la diapositive.
- Définir les propriétés de la légende.
- Enregistrer la présentation au format PPTX.

Dans l'exemple ci‑dessous, nous avons défini la position et la taille de la légende du graphique.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la référence de la diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter un graphique à colonnes groupées sur la diapositive
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


## **Définir la taille de police d'une légende**
Le Aspose.Slides pour Android via Java permet aux développeurs de définir la taille de police de la légende. Suivez les étapes ci‑dessus :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Définir la taille de police.
- Définir la valeur minimale de l’axe.
- Définir la valeur maximale de l’axe.
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


## **Définir la taille de police d'une légende individuelle**
Le Aspose.Slides pour Android via Java permet aux développeurs de définir la taille de police des entrées de légende individuelles. Suivez les étapes ci‑dessus :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Accéder à l’entrée de légende.
- Définir la taille de police.
- Définir la valeur minimale de l’axe.
- Définir la valeur maximale de l’axe.
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

**Puis-je activer la légende afin que le graphique alloue automatiquement de l’espace pour celle‑ci au lieu de la superposer ?**  
Oui. Utilisez le mode sans superposition ([setOverlay(false)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)) ; dans ce cas, la zone du tracé se réduira pour faire place à la légende.

**Puis-je créer des libellés de légende sur plusieurs lignes ?**  
Oui. Les libellés longs se renouvellent automatiquement lorsqu’il n’y a pas assez d’espace ; les sauts de ligne forcés sont pris en charge via des caractères de nouvelle ligne dans le nom de la série.

**Comment faire en sorte que la légende suive le schéma de couleurs du thème de la présentation ?**  
Ne définissez pas de couleurs, remplissages ou polices explicites pour la légende ou son texte. Ils hériteront alors du thème et se mettront à jour correctement lorsque le design changera.