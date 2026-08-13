---
title: Gérer les séries de données de graphiques dans les présentations sur Android
linktitle: Séries de données
type: docs
url: /fr/androidjava/chart-series/
keywords:
- séries de graphiques
- chevauchement des séries
- couleur des séries
- nom de la série
- point de données
- cellule de classeur
- écart des séries
- valeur négative
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur d’écart et les valeurs négatives dans les présentations sur Android."
---
## **Présentation**

Un graphique stocke ses données tracées dans un classeur de données de graphique. Un [IChartSeries](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/) représente un ensemble de valeurs liées, et chaque [IChartDataPoint](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/) de la série fait référence à une ou plusieurs cellules du classeur. Les objets [IChartCategory](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartcategory/) fournissent les étiquettes ou les valeurs de regroupement partagées par les séries. Le nom de la série, les catégories et les valeurs des points sont donc reliés aux objets [IChartDataCell](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatacell/) plutôt que stockés uniquement sous forme de texte affiché.

Pour un graphique de catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégories et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) sont basés à zéro. Cette disposition est utile lorsque vous créez un graphique avec des données par défaut, mais ne supposez pas que chaque graphique existant l’utilise. Pour une présentation chargée, inspectez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du graphique ont trois portées différentes :

- Paramètres au niveau de la série, tels que [IChartSeries.getFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getFormat--), fournissent l’apparence par défaut pour tous les points d’une même série.
- Paramètres au niveau du point de données, tels que [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), remplacent l’apparence de la série pour un point.
- Les paramètres de groupe s’appliquent aux séries compatibles appartenant au même [IChartSeriesGroup](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/). Accédez au groupe via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) lorsque vous devez définir des options telles que le chevauchement ou la largeur de l’écart.

Lorsqu’aucun remplissage explicite de point ou de série n’est défini, le style et le thème du graphique déterminent l’apparence automatique. Lorsque les formats de série et de point sont présents, le format du point a la priorité pour ce point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries du graphique**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getOverlap--) indique dans quelle mesure les barres ou colonnes se chevauchent dans un graphique 2D, de -100 à 100 pour cent. Il s’agit d’une projection en lecture seule du paramètre du groupe de séries parent. Utilisez [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) pour mettre à jour chaque série compatible de ce groupe. Cette option s’applique aux types de graphiques qui affichent des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un graphique combiné.

L’exemple suivant définit le chevauchement pour le groupe contenant la première série :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Le nouveau graphique contient des séries d'exemple, des catégories et des valeurs.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The series overlap](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [IChartSeries.getFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getFormat--) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) remplace le remplissage de la série pour ce point.

L’exemple suivant applique un remplissage bleu uni à la première série :

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The color of the series](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du graphique et est généralement affiché dans la légende. Dans le classeur par défaut créé pour un graphique à colonnes groupées, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les constantes nommées de l’exemple suivant rendent cette structure explicite :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vous pouvez également mettre à jour la cellule déjà référencée par [IChartSeries.getName](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getName--). Cette approche évite de supposer une ligne et une colonne particulières dans un graphique existant :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The series name](series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) renvoie la couleur calculée à partir de l’index de la série et du style du graphique sous forme d’entier ARGB Android. Il s’agit de la couleur utilisée lorsque le remplissage de la série n’a pas été défini explicitement. L’appel de la méthode lit la couleur calculée ; il ne définit pas de nouveau remplissage.

L’exemple suivant affiche l’entier de couleur automatique de chaque série par défaut :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Les valeurs entières exactes dépendent du style et du thème du graphique.

## **Définir la couleur de remplissage inversée pour une série du graphique**

Pour les séries en barres, colonnes et bulles, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage de série normal sur solide, activez l’inversion et assignez la couleur des valeurs négatives via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage change.

L’exemple suivant remplace les données de graphique par défaut par une série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 contient les noms de catégories et la colonne 1 contient les valeurs :

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The inverted solid fill color](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un seul point via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Effacer la valeur d’un point de données spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez sa cellule de classeur sous‑jacent sur `null`. Pour un graphique à colonnes, la valeur tracée est accessible via [IChartDataPoint.getValue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Le point de données reste à la même position de catégorie, mais le graphique traite sa valeur comme vide selon les paramètres de valeurs vides du graphique.

L’exemple suivant ne vide que le deuxième point de la première série :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les graphiques en nuage de points utilisent des cellules X et Y séparées, et les graphiques à bulles utilisent également une cellule de taille. Effacez uniquement la cellule qui représente la valeur que vous voulez supprimer. N’appellez pas [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) lorsque vous souhaitez conserver les autres points, car cette méthode supprime tous les points de la collection.

## **Définir la largeur de l’écart des séries**

La largeur de l’écart est l’espace entre des clusters de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe de séries parent plutôt qu’à une série individuelle. Appelez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) une fois pour le groupe. Une valeur plus grande crée plus d’espace entre les clusters ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur de l’écart et enregistre seulement la présentation finale :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The gap width](gap_width.png)

## **FAQ**

**Quels types de graphiques prennent en charge les séries de données ?**

Tous les types de graphiques représentés par l’énumération [ChartType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/charttype/) utilisent des données de graphique, mais leurs séries n’ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les graphiques de catégorie utilisent des catégories et des valeurs, les graphiques en nuage de points utilisent des valeurs X et Y, et les graphiques à bulles ajoutent des tailles de bulle. Utilisez la méthode de création de point de données qui correspond au type de série. Les options telles que le chevauchement et la largeur de l’écart ne s’appliquent qu’aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de graphique ?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/) contient des séries compatibles qui partagent des paramètres de traçage au niveau du groupe. Un graphique combiné peut contenir plusieurs groupes, de sorte que la modification du groupe obtenue via une série ne modifie pas nécessairement toutes les séries du graphique.

**Un graphique nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [IShapeCollection.addChart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crée des séries, des catégories et des valeurs d’exemple. Vous pouvez modifier ces cellules ou vider les collections de séries et de catégories avant d’ajouter un jeu de données complètement personnalisé. Une surcharge permet également de créer un graphique sans données par défaut.

**Comment les objets du graphique sont‑ils liés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données font référence à des cellules d’un [IChartDataWorkbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdataworkbook/). Modifier une cellule référencée met à jour l’élément correspondant du graphique. Lorsque vous construisez des données personnalisées, maintenez les lignes de catégories et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point sans supprimer toute la série ?**

Définissez la cellule de valeur concernée sur `null` pour conserver la position de catégorie du point comme point vide. Utilisez [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) uniquement lorsque vous avez l’intention de supprimer tous les points de cette série. Si vous supprimez également des catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de graphique et de la valeur configurée via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Les graphiques pris en charge peuvent afficher les vides comme des écarts, comme des valeurs zéro, ou en reliant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries en barres, colonnes et bulles prises en charge, appelez [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) et définissez la couleur renvoyée par [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Vous pouvez remplacer le comportement pour un point individuel avec [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel formatage l’emporte lorsque la série et le point sont tous deux formatés ?**

Le formatage explicite du point de données a la priorité pour ce point. Les autres points continuent d’utiliser le format explicite de la série ou, lorsque le format de la série n’est pas défini, le style et le thème automatiques du graphique. Les paramètres de groupe tels que le chevauchement et la largeur de l’écart contrôlent la disposition et ne constituent pas des remplacements de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un graphique peut contenir ?**

Aspose.Slides n’impose pas de limite fixe séparée du nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du graphique déterminent une limite utile.

**Que dois‑je modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les clusters, ou diminuez‑la pour rapprocher les clusters.