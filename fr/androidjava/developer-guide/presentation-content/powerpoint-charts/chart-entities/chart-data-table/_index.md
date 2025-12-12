---
title: Personnaliser les tables de données de graphiques dans les présentations sur Android
linktitle: Table de données
type: docs
url: /fr/androidjava/chart-data-table/
keywords:
- données de graphique
- table de données
- propriétés de police
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Personnalisez les tables de données de graphiques en Java pour PPT et PPTX avec Aspose.Slides pour Android afin d'améliorer l'efficacité et l'attrait des présentations."
---

## **Définir les propriétés de police pour le tableau de données d'un graphique**
Aspose.Slides for Android via Java offre une prise en charge de la modification de la couleur des catégories dans la couleur d'une série.

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

Un exemple de code est présenté ci-dessous.
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


## **FAQ**

**Puis-je afficher de petites clés de légende à côté des valeurs dans le tableau de données du graphique ?**

Oui. Le tableau de données prend en charge les [clés de légende](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation au format PDF, HTML ou image ?**

Oui. Aspose.Slides rend le graphique comme partie de la diapositive, ainsi le [PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/androidjava/convert-powerpoint-to-html/)/[image](/slides/fr/androidjava/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont-ils pris en charge pour les graphiques provenant d'un fichier de modèle ?**

Oui. Pour tout graphique chargé à partir d’une présentation ou d’un modèle existant, vous pouvez vérifier et modifier si le tableau de données [est affiché](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) en utilisant les propriétés du graphique.

**Comment puis-je rapidement identifier quels graphiques d'un fichier ont le tableau de données activé ?**

Inspectez la propriété de chaque graphique indiquant si le tableau de données [est affiché](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) et parcourez les diapositives pour identifier les graphiques où il est activé.