---
title: Tableau de données du graphique
type: docs
url: /fr/java/chart-data-table/
---

## **Définir les propriétés de la police pour le tableau de données du graphique**
Aspose.Slides pour Java prend en charge le changement de couleur des catégories dans une série de couleurs. 

1. Instancier un objet de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

Un exemple de code est donné ci-dessous. 

```java
// Création d'une présentation vide
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```