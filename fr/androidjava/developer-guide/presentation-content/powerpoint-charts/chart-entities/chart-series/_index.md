---
title: Gérer les séries de données de diagramme dans les présentations sur Android
linktitle: Séries de données
type: docs
url: /fr/androidjava/chart-series/
keywords:
- séries de diagramme
- chevauchement des séries
- couleur des séries
- nom de la série
- point de donnée
- cellule du classeur
- écart des séries
- valeur négative
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à gérer les séries de diagramme, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur de l'écart et les valeurs négatives dans les présentations sur Android."
---
## **Vue d'ensemble**

Un diagramme stocke ses données tracées dans un classeur de données de diagramme. Un [IChartSeries](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/) représente un ensemble de valeurs liées, et chaque [IChartDataPoint](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/) de la série fait référence à une ou plusieurs cellules du classeur. Les objets [IChartCategory](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartcategory/) fournissent les libellés ou les valeurs de regroupement partagés par les séries. Le nom de la série, les catégories et les valeurs des points sont donc liés aux objets [IChartDataCell](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatacell/) plutôt que stockés uniquement sous forme de texte affiché.

Pour un diagramme de catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégorie et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) sont basés sur zéro. Cette disposition est utile lorsque vous créez un diagramme avec des données par défaut, mais ne supposez pas que chaque diagramme existant l’utilise. Pour une présentation chargée, inspectez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du diagramme ont trois portées différentes :

- Paramètres au niveau de la série, tels que [IChartSeries.getFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getFormat--), qui fournissent l’apparence par défaut pour tous les points d’une série.
- Paramètres du point de donnée, tels que [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), qui remplacent l’apparence de la série pour un point.
- Paramètres de groupe s’appliquent aux séries compatibles qui appartiennent au même [IChartSeriesGroup](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/). Accédez au groupe via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) lorsque vous devez définir des options telles que le chevauchement ou la largeur de l’écart.

Lorsqu’aucun remplissage explicite de point ou de série n’est défini, le style et le thème du diagramme déterminent l’apparence automatique. Lorsque les formats de série et de point sont présents, le format du point prend le pas sur celui de la série pour ce point.

![série de diagramme PowerPoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries du diagramme**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getOverlap--) indique le pourcentage de chevauchement des barres ou des colonnes dans un diagramme 2D, de -100 à 100 %. Il s’agit d’une projection en lecture seule du paramètre du groupe de séries parent. Utilisez [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) pour mettre à jour toutes les séries compatibles de ce groupe. Cette option s’applique aux types de diagrammes affichant des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un diagramme combiné.

L’exemple suivant définit le chevauchement pour le groupe contenant la première série :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Le nouveau diagramme contient des séries, catégories et valeurs d'exemple.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Chevauchement des séries](series_overlap.png)

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

![Couleur de la série](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du diagramme et est généralement affiché dans la légende. Dans le classeur par défaut créé pour un diagramme à colonnes groupées, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les constantes nommées de l’exemple suivant rendent cette structure explicite :

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

Vous pouvez également mettre à jour la cellule déjà référencée par [IChartSeries.getName](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getName--). Cette approche évite de supposer une ligne ou une colonne particulière dans un diagramme existant :

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

![Nom de la série](series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) renvoie la couleur calculée à partir de l’indice de la série et du style du diagramme sous forme d’entier ARGB Android. C’est la couleur utilisée lorsque le remplissage de la série n’a pas été explicitement défini. L’appel de la méthode lit la couleur calculée ; il ne crée pas de nouveau remplissage.

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

Les valeurs entières exactes dépendent du style et du thème du diagramme.

## **Définir un remplissage inversé pour une série du diagramme**

Pour les séries à barres, colonnes et bulles, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage régulier de la série sur solide, activez l’inversion et attribuez la couleur des valeurs négatives via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage change.

L’exemple suivant remplace les données de diagramme par défaut par une seule série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 contient les noms de catégorie et la colonne 1 les valeurs :

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

![Couleur de remplissage solide inversé](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un point via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :

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

## **Effacer la valeur d’un point de donnée spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez sa cellule de classeur sous‑jacent sur `null`. Dans un diagramme à colonnes, la valeur tracée est accessible via [IChartDataPoint.getValue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Le point de donnée reste à la même position de catégorie, mais le diagramme le considère comme vide selon les paramètres de traitement des valeurs vides du diagramme.

L’exemple suivant efface uniquement le deuxième point de la première série :

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

Les diagrammes en nuage utilisent des cellules X et Y distinctes, et les diagrammes à bulles utilisent également une cellule de taille. Effacez uniquement la cellule représentant la valeur que vous souhaitez retirer. N’appellez pas [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) lorsque vous voulez conserver les autres points, car cette méthode supprime tous les points de la collection.

## **Contrôler l’affichage des cellules vides**

Une cellule de classeur vide représente des données manquantes ; une cellule contenant `0` représente une valeur numérique connue. Appelez [IChartDataCell.setValue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) avec `null` pour rendre une cellule vide. Un zéro numérique demeure zéro, quel que soit le paramètre des cellules vides.

Utilisez [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) pour choisir comment le diagramme affiche les cellules vides. Ce paramètre s’applique à l’ensemble du diagramme. Il modifie la façon dont les blancs sont tracés, sans remplir la cellule du classeur vide avec zéro ou une valeur interpolée.

L’exemple autonome suivant crée un diagramme en ligne avec une série, efface la valeur du jour 3 et enregistre le même diagramme avec chaque mode. Aucun fichier d’entrée n’est requis. Le [IChartDataWorkbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Laisser le jour 3 vraiment vide, tout en conservant sa catégorie et son point de données.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Chaque fichier de sortie stocke le mode attribué avant l’enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour enregistrer une seule version, attribuez le mode souhaité et enregistrez la présentation une fois au lieu d’itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le jour 3 est vide dans le classeur dans chaque cas :

![Diagrammes en ligne avec données identiques : Gap interrompt la ligne au jour 3, Zero descend la ligne à zéro, et Span relie le jour 2 au jour 4.](display_blanks_as.png)

L’effet visible dépend du type de diagramme. Un diagramme en ligne rend les trois modes faciles à comparer. Les diagrammes à barres et colonnes n’ont aucune ligne à connecter à travers une catégorie manquante, de sorte que `Span` ne peut pas produire le segment de connexion montré ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent également se ressembler. De même, un diagramme en nuage avec uniquement des marqueurs n’a aucune ligne de connexion. N’attendez pas trois résultats distincts pour chaque type de diagramme ; vérifiez la sortie pour le type que vous utilisez.

## **Définir la largeur de l’écart entre les séries**

La largeur de l’écart est l’espace entre les groupes adjacents de barres ou de colonnes, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, il appartient au groupe de séries parent plutôt qu’à une série individuelle. Appelez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) une fois pour le groupe. Une valeur plus grande crée plus d’espace entre les groupes ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur de l’écart et n’enregistre que la présentation finale :

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

![Largeur de l’écart](gap_width.png)

## **FAQ**

**Quels types de diagrammes prennent en charge les séries de données ?**

Tous les types de diagrammes représentés par l’énumération [ChartType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/charttype/) utilisent des données de diagramme, mais leurs séries n’ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les diagrammes de catégorie utilisent des catégories et des valeurs, les diagrammes en nuage utilisent les valeurs X et Y, et les diagrammes à bulles ajoutent les tailles des bulles. Utilisez la méthode de création de points de données qui correspond au type de série. Les options telles que le chevauchement et la largeur de l’écart ne s’appliquent qu’aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de diagramme ?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/) contient des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un diagramme combiné peut contenir plusieurs groupes, de sorte que la modification du groupe atteinte via une série ne modifie pas nécessairement toutes les séries du diagramme.

**Un diagramme nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [IShapeCollection.addChart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crée des séries, catégories et valeurs d’exemple. Vous pouvez modifier ces cellules ou effacer les collections de séries et de catégories avant d’ajouter un jeu de données entièrement personnalisé. Une surcharge peut également créer un diagramme sans données par défaut.

**Comment les objets du diagramme sont‑ils liés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données référencent des cellules d’un [IChartDataWorkbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdataworkbook/). Modifier une cellule référencée met à jour l’élément correspondant du diagramme. Lorsque vous créez des données personnalisées, gardez les lignes de catégorie et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un seul point plutôt que toute la série ?**

Définissez la cellule de valeur concernée sur `null` pour conserver la position de catégorie du point en tant que point vide. Utilisez [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) uniquement lorsque vous souhaitez supprimer tous les points de cette série. Si vous supprimez également des catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de diagramme et de la valeur configurée via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Les diagrammes pris en charge peuvent afficher les blancs comme des écarts, comme des valeurs zéro, ou en reliant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation. Voir **Contrôler l’affichage des cellules vides** pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries à barres, colonnes et bulles prises en charge, appelez [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) et définissez la couleur renvoyée par [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Vous pouvez remplacer le comportement pour un point individuel avec [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel formatage l’emporte lorsqu’une série et un point sont tous deux formatés ?**

Le formatage explicite du point de donnée prend le pas pour ce point. Les autres points continuent d’utiliser le format explicite de la série ou, lorsque le format de la série n’est pas défini, le style et le thème automatiques du diagramme. Les paramètres de groupe tels que le chevauchement et la largeur de l’écart contrôlent la disposition et ne sont pas des dépassements de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un diagramme peut contenir ?**

Aspose.Slides n’impose pas de limite fixe distincte au nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du diagramme déterminent une limite utile.

**Que faut‑il ajuster lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les groupes, ou diminuez‑la pour rapprocher les groupes.