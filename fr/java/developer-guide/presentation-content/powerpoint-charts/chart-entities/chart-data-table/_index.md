---
title: Personnaliser les tables de données de graphiques dans les présentations avec Java
linktitle: Table de données
type: docs
url: /fr/java/chart-data-table/
keywords:
- données de graphique
- table de données
- propriétés de police
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Personnalisez les polices, les bordures et les clés de légende des tables de données de graphiques dans les présentations PowerPoint à l'aide d'Aspose.Slides for Java."
---
## **Vue d'ensemble**

Aspose.Slides for Java vous permet d'afficher le tableau de données d'un graphique et de personnaliser le formatage du texte, les bordures et les clés de légende. Cet article explique comment activer le tableau, formater son texte, contrôler chaque type de bordure et afficher ou masquer les clés de légende. Les exemples enregistrent les graphiques configurés dans des fichiers PPTX.

## **Définir les propriétés de police**

Pour afficher le tableau de données d’un graphique, passez `true` à [setDataTable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/#setDataTable-boolean-). Utilisez [getChartDataTable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/#getChartDataTable--) pour accéder au tableau et configurer le formatage du texte.

1. Chargez la présentation à l’aide de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Ajoutez un graphique à colonnes groupées à la première diapositive.
1. Activez le tableau de données du graphique.
1. Activez le texte en gras avec [setFontBold](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) et passez `20` à [setFontHeight](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour un texte de 20 points.
1. Enregistrez la présentation modifiée.

L’exemple suivant nécessite `test.pptx` dans le répertoire de travail avec au moins une diapositive. Il ajoute un graphique avec des données par défaut à la position (50, 50), avec une largeur de 600 points et une hauteur de 400 points. Le fichier `output.pptx` enregistré contient le graphique avec son tableau de données activé et les paramètres de police spécifiés appliqués.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Personnaliser les bordures du tableau de données**

Activez le tableau avec [IChart.setDataTable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichart/#setDataTable-boolean-) et accédez-y via [IChart.getChartDataTable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichart/#getChartDataTable--). Vous pouvez contrôler trois types de bordures indépendamment :

- [setBorderHorizontal](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) contrôle les bordures horizontales des cellules.
- [setBorderVertical](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) contrôle les bordures verticales des cellules.
- [setBorderOutline](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) contrôle la bordure extérieure du tableau.

Passez `true` à chaque méthode pour afficher ses bordures ou `false` pour les masquer. L’exemple suivant crée un graphique à colonnes groupées avec des données par défaut, affiche les bordures horizontales et la bordure extérieure, et masque les bordures verticales. Aucun fichier d’entrée n’est requis. La position et la taille du graphique sont spécifiées en points.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparaison ci‑dessous utilise les mêmes données de graphique et le même paramètre de clé de légende dans les quatre cas. En partant de toutes les bordures activées, chaque variante restante désactive uniquement un paramètre de bordure. La variante en bas à gauche correspond aux paramètres de bordure de l’exemple.

![Tableaux de données de graphique avec toutes les bordures activées, aucune bordure horizontale, aucune bordure verticale et aucune bordure extérieure](data-table-borders.png)

## **Afficher ou masquer les clés de légende**

Les clés de légende sont de petits marqueurs colorés à côté des noms de séries dans le tableau de données. Elles aident les lecteurs à associer chaque ligne du tableau à une série du graphique. Passez `true` à [setShowLegendKey](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) pour afficher ces marqueurs ou `false` pour les masquer.

La légende séparée du graphique est contrôlée par [IChart.setLegend](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichart/#setLegend-boolean-). Ces paramètres sont indépendants : masquer la légende séparée ne masque pas les clés du tableau de données, et masquer les clés du tableau ne masque pas la légende séparée.

L’exemple suivant crée un graphique avec des données par défaut, active son tableau de données et affiche les clés de légende à l’intérieur tout en masquant la légende séparée. Toutes les bordures du tableau sont explicitement activées. Aucun fichier de présentation en entrée n’est requis. Pour masquer uniquement les clés du tableau, passez `false` à [setShowLegendKey](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparaison ci‑dessous montre le même tableau avec les clés de légende affichées à gauche et masquées à droite. Toutes les bordures restent activées, et la légende séparée du graphique est masquée dans les deux cas.

![Tableaux de données de graphique avec clés de légende affichées à gauche et masquées à droite](data-table-legend-keys.png)

## **FAQ**

**Puis‑je afficher les clés de légende dans le tableau de données d’un graphique ?**

Oui. Passez `true` à [setShowLegendKey](https://reference.aspose.com/slides/fr/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) pour afficher les clés de légende ou `false` pour les masquer.

**Le tableau de données sera‑t‑il conservé lors de l’exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique et son tableau de données affiché comme partie de la diapositive lors de l’exportation vers [PDF](/slides/fr/java/convert-powerpoint-to-pdf/), [HTML](/slides/fr/java/convert-powerpoint-to-html/) ou [images](/slides/fr/java/convert-powerpoint-to-png/).

**Puis‑je travailler avec les tableaux de données dans des graphiques chargés à partir d’un modèle ?**

Oui. Pour un graphique chargé depuis une présentation ou un modèle existant, utilisez [hasDataTable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/#hasDataTable--) et [setDataTable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/#setDataTable-boolean-) pour vérifier ou modifier l’affichage du tableau de données.

**Comment puis‑je trouver les graphiques qui ont un tableau de données activé ?**

Parcourez les formes de chaque diapositive, identifiez les graphiques, puis appelez leur méthode [hasDataTable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/#hasDataTable--). Une valeur `true` indique que le tableau de données est activé.