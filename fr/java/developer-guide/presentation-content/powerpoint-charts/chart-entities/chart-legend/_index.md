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
description: "Personnalisez les légendes de graphiques avec Aspose.Slides for Java pour optimiser les présentations PowerPoint grâce à un formatage de légende adapté."
---
## **Vue d'ensemble**

Aspose.Slides for Java offre des options pour personnaliser les légendes de graphiques dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de la police pour l'ensemble de la légende, formater une entrée de légende individuelle et masquer ou restaurer des entrées sélectionnées.

La FAQ couvre les comportements associés, y compris la réservation d'espace pour la légende, l'affichage d'étiquettes multilignes et l'héritage du formatage à partir du thème de la présentation.

## **Positionnement de la légende**

Utilisez les méthodes [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), et [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) de la légende pour spécifier sa position et sa taille en fractions des dimensions du graphique.

Cet exemple crée une présentation et ajoute un graphique à colonnes groupées avec des données par défaut à la première diapositive. Diviser les décalages et dimensions souhaités de la légende par la largeur et la hauteur du graphique les convertit en valeurs relatives : la légende est décalée de 50 points du coin supérieur gauche du graphique et dimensionnée à 100 × 100 points.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Exprimez la position et la taille de la légende par rapport au graphique.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la taille de police d'une légende**

Utilisez la méthode [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) de la légende pour accéder à son formatage de texte et utilisez [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour définir la taille de la police en points.

Cet exemple crée un graphique avec des données par défaut et définit le texte de la légende à 20 points. Il désactive également les limites automatiques pour l'axe vertical et fixe sa plage de -5 à 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la taille de police d'une entrée de légende individuelle**

Utilisez la collection retournée par la méthode [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) de la légende pour accéder au formatage d'une entrée spécifique. Les indices des entrées sont basés à zéro, donc l'indice `1` correspond à la deuxième entrée.

Cet exemple crée un graphique à colonnes groupées dont les données par défaut incluent au moins deux séries. Il formate la deuxième entrée de légende avec du texte en gras, italique et bleu de 20 points.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Masquer des entrées de légende individuelles**

Pour exclure une série auxiliaire de la légende tout en conservant ses données visibles, appelez [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) avec `true` via [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Cela masque uniquement l'entrée de légende sélectionnée ; cela ne supprime pas la série ni ses points de données. En revanche, appeler [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) avec `false` masque la légende entière.

L'exemple ci-dessous crée un graphique à colonnes groupées avec plusieurs séries en utilisant les données par défaut. Il masque l'entrée de légende de la deuxième série (indice `1`) et enregistre la présentation. Il restaure ensuite l'entrée en appelant [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) avec `false` et enregistre une seconde copie. Les colonnes restent visibles dans les deux fichiers.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Restaurer la même entrée sans modifier les données du graphique.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparaison ci-dessous montre le même graphique avec toutes les entrées visibles et avec la deuxième entrée masquée. Les colonnes de la deuxième série restent inchangées.

![Comparaison d'un graphique avec toutes les entrées de légende visibles et avec la Série 2 masquée de la légende ; toutes les colonnes restent visibles.](hide-legend-entry.png)

Dans les graphiques à colonnes, à barres et linéaires, les entrées de légende identifient les séries. Pour les graphiques circulaires, elles identifient des points de données individuels (tranches), utilisez donc [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) sur la tranche sélectionnée à la place. L'API documente cette méthode point-de-données pour les types de graphiques `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` et `BarOfPie`. Ne supposez pas qu'elle s'applique aux graphiques en anneau, qui ne figurent pas dans cette liste.

## **FAQ**

**Puis-je faire en sorte que le graphique réserve de l'espace pour la légende au lieu de la superposer ?**  
Oui. Appelez [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) avec `false` pour réserver de l'espace pour la légende au lieu de permettre qu'elle se superpose à la zone du graphique.

**Puis-je créer des étiquettes de légende multilignes ?**  
Oui. Les étiquettes longues peuvent se renvoyer à la ligne lorsque la largeur disponible est insuffisante. Vous pouvez également utiliser des caractères de saut de ligne dans les noms de séries pour demander des ruptures de ligne.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**  
Laissez les couleurs, remplissages et polices de la légende non définis afin qu'elle puisse hériter du formatage du thème. Un formatage explicite remplace les paramètres correspondants du thème.