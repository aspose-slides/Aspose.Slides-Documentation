---
title: Tableau de Données du Graphique
type: docs
url: /fr/androidjava/chart-data-table/
---

## **Définir les Propriétés de Police pour le Tableau de Données du Graphique**
Aspose.Slides pour Android via Java permet de changer la couleur des catégories dans une série de couleurs.

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de police.
1. Enregistrer la présentation modifiée.

Un exemple de code ci-dessous est donné.

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