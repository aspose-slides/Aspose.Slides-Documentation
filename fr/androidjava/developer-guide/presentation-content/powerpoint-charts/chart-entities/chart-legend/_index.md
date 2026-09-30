---
title: Personnaliser les légendes de diagrammes dans les présentations sur Android
linktitle: Légende de diagramme
type: docs
url: /fr/androidjava/chart-legend/
keywords:
- légende de diagramme
- position de la légende
- taille de police
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Personnalisez les légendes de diagrammes avec Aspose.Slides for Android via Java pour optimiser les présentations PowerPoint avec un formatage de légende adapté."
---
## **Vue d'ensemble**

Aspose.Slides for Android via Java propose des options pour personnaliser les légendes de diagrammes dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de police pour l'ensemble de la légende, mettre en forme une entrée de légende individuelle et masquer ou restaurer des entrées sélectionnées.

La FAQ couvre les comportements associés, notamment la réservation d'espace pour la légende, l'affichage d'étiquettes sur plusieurs lignes et l'héritage du formatage à partir du thème de la présentation.

## **Positionnement de la légende**

Utilisez les méthodes [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), et [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) de la légende pour spécifier sa position et sa taille en tant que fractions des dimensions du diagramme.

Cet exemple crée une présentation et ajoute un diagramme à colonnes groupées avec des données par défaut à la première diapositive. Diviser les décalages et dimensions souhaités de la légende par la largeur et la hauteur du diagramme les convertit en valeurs relatives : la légende est décalée de 50 points du coin supérieur gauche du diagramme et dimensionnée à 100 × 100 points.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Exprimer la position et la taille de la légende par rapport au diagramme.
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

Utilisez la méthode [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) de la légende pour accéder à son formatage de texte et utilisez [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour définir la taille de la police en points.

Cet exemple crée un diagramme avec des données par défaut et définit le texte de la légende à 20 points. Il désactive également les limites automatiques pour l'axe vertical et fixe sa plage de -5 à 10.

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

Utilisez la collection renvoyée par la méthode [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) de la légende pour accéder au formatage d'une entrée spécifique. Les indices des entrées sont basés sur zéro, ainsi l'indice `1` correspond à la deuxième entrée.

Cet exemple crée un diagramme à colonnes groupées dont les données par défaut comprennent au moins deux séries. Il met en forme la deuxième entrée de légende avec du texte en gras, italique et bleu de 20 points.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Pour exclure une série auxiliaire de la légende tout en conservant ses données visibles, appelez [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) avec `true` via [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Cela masque uniquement l'entrée de légende sélectionnée ; cela ne supprime pas la série ni ses points de données. En revanche, appeler [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) avec `false` masque l'intégralité de la légende.

L'exemple ci‑dessous crée un diagramme à colonnes groupées avec plusieurs séries en utilisant les données par défaut. Il masque l'entrée de légende de la deuxième série (indice `1`) et enregistre la présentation. Il restaure ensuite l'entrée en appelant [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) avec `false` et enregistre une seconde copie. Les colonnes restent visibles dans les deux fichiers.

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

    // Restaurer la même entrée sans modifier les données du diagramme.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparaison ci‑dessous montre le même diagramme avec toutes les entrées visibles et avec la deuxième entrée masquée. Les colonnes de la deuxième série restent inchangées.

![Comparaison d'un diagramme avec toutes les entrées de légende visibles et avec la Série 2 masquée de la légende ; toutes les colonnes restent visibles.](hide-legend-entry.png)

Dans les diagrammes à colonnes, à barres et en lignes, les entrées de légende identifient les séries. Pour les diagrammes circulaires, elles identifient les points de données individuels (tranches), utilisez donc [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) sur la tranche sélectionnée. L'API documente cette méthode de point de données pour les types de diagrammes `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` et `BarOfPie`. Ne supposez pas qu'elle s'applique aux diagrammes en anneau, qui ne font pas partie de cette liste.

## **FAQ**

**Puis-je faire en sorte que le diagramme réserve de l'espace pour la légende au lieu de la superposer ?**  
Oui. Appelez [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) avec `false` pour réserver de l'espace pour la légende au lieu de permettre qu'elle chevauche la zone du graphique.

**Puis-je créer des étiquettes de légende sur plusieurs lignes ?**  
Oui. Les libellés longs peuvent se renvoyer à la ligne lorsque la largeur disponible est insuffisante. Vous pouvez également utiliser des caractères de saut de ligne dans les noms de séries pour demander des ruptures de ligne.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**  
Laissez les couleurs, remplissages et polices de la légende non définis afin qu'elle puisse hériter du formatage du thème. Un formatage explicite écrase les paramètres correspondants du thème.