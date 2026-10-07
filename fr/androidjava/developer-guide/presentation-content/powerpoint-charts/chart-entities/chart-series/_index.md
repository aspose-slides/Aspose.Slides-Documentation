---
title: Gérer les séries de données de diagramme dans les présentations sur Android
linktitle: Séries de données
type: docs
url: /fr/androidjava/chart-series/
keywords:
- série de diagramme
- chevauchement de série
- couleur de série
- nom de série
- point de données
- cellule de classeur
- écart de série
- valeur négative
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à gérer les séries de diagramme, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur d'écart et les valeurs négatives dans les présentations sur Android."
---
## **Aperçu**

Un diagramme stocke ses données tracées dans un classeur de données de diagramme. Un [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) représente un ensemble de valeurs liées, et chaque [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) de la série se réfère à une ou plusieurs cellules du classeur. Les objets [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) fournissent les libellés ou valeurs de groupement partagés par les séries. Le nom de la série, les catégories et les valeurs des points sont donc reliés aux objets [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) plutôt qu’enregistrés uniquement comme texte d’affichage.

Pour un diagramme à catégories typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégories, et les cellules restantes pour les valeurs des séries. Les index de feuille de calcul, de ligne et de colonne transmis à [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) sont basés sur zéro. Cette disposition est utile lorsque vous créez un diagramme avec des données par défaut, mais ne supposez pas que chaque diagramme existant l’utilise. Pour une présentation chargée, inspectez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du diagramme ont trois portées différentes :

- Paramètres au niveau de la série, tels que [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--), fournissent l’apparence par défaut pour tous les points d’une série.
- Paramètres de point de données, tels que [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), remplacent l’apparence de la série pour un point.
- Paramètres de groupe s’appliquent aux séries compatibles qui appartiennent au même [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/). Accédez au groupe via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) lorsque vous devez définir des options telles que le chevauchement ou la largeur d’écart.

Lorsque aucun remplissage explicite de point ou de série n’est défini, le style et le thème du diagramme déterminent l’apparence automatique. Lorsque les formats de série et de point sont tous deux présents, le format du point prend le dessus pour ce point.

![séries de diagramme PowerPoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries du diagramme**

Le [IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) indique le degré de chevauchement des barres ou colonnes dans un diagramme 2D, de -100 à 100 pour cent. C’est une projection en lecture seule du paramètre du groupe de séries parent. Utilisez [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) pour mettre à jour chaque série compatible de ce groupe. Cette option s’applique aux types de diagrammes qui affichent des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non concernés dans un diagramme combiné.

L’exemple suivant définit le chevauchement pour le groupe qui contient la première série :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Le nouveau diagramme contient des séries, des catégories et des valeurs d'exemple.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Chevauchement de la série](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) remplace le remplissage de la série pour ce point.

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

Le nom d’une série est stocké dans le classeur de données du diagramme et est généralement affiché dans la légende. Dans le classeur par défaut créé pour un diagramme à colonnes groupées, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les constantes nommées dans l’exemple suivant rendent cette structure explicite :

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

Vous pouvez également mettre à jour la cellule déjà référencée par [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--). Cette approche évite de supposer une ligne ou une colonne particulières dans un diagramme existant :

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

### **Créer une série avec un nom provenant de plusieurs cellules**

Un nom de série composite est utile lorsqu’un nom de produit et une période de rapport sont stockés dans des cellules distinctes du classeur. Par exemple, vous pouvez combiner `Product A` en B1 et `2026` en C1 en un seul nom de série tout en conservant les deux parties liées à leurs cellules sources.

Utilisez [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) pour récupérer la plage de noms, puis transmettez cette collection à [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). L’argument `skipHiddenCells` contrôle si les cellules masquées sont incluses : `true` les exclut, tandis que `false` les inclut. Cet exemple utilise `false` pour inclure chaque cellule de la plage de noms.

L’exemple suivant crée une présentation avec une série et deux points de données. Les cellules B1:C1 fournissent uniquement le nom de la série ; A2:A3 fournissent les libellés de catégorie, et B2:B3 fournissent les valeurs numériques.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Ces deux cellules fournissent le nom de la série.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Des cellules séparées fournissent les catégories et les points de données numériques.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le nom de série résultant est `Product A 2026`, avec un espace entre les deux valeurs de cellule. La légende l’affiche comme une seule entrée pour les deux colonnes. L’image ci‑dessous illustre le résultat :

![Diagramme à colonnes avec valeurs Nord et Sud et le nom de série composite Product A 2026 dans la légende](composite_series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) renvoie la couleur calculée à partir de l’index de la série et du style du diagramme sous forme d’entier couleur ARGB Android. C’est la couleur utilisée lorsque le remplissage de la série n’est pas défini explicitement. Appeler la méthode lit la couleur calculée ; elle n’attribue pas de nouveau remplissage.

L’exemple suivant affiche l’entier couleur automatique de chaque série par défaut :

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

## **Définir la couleur de remplissage inversée pour une série de diagramme**

Pour les séries à barres, colonnes et bulles, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage régulier de la série en solide, activez l’inversion et attribuez la couleur de valeur négative via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage change.

L’exemple suivant remplace les données de diagramme par défaut par une seule série. La ligne 0 de la feuille de calcul contient le nom de la série, la colonne 0 contient les noms de catégorie, et la colonne 1 contient les valeurs :

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

![Couleur de remplissage solide inversée](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un point via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :

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

Pour rendre un point vide sans supprimer les autres points, définissez sa cellule de classeur sous‑jacent sur `null`. Pour un diagramme à colonnes, la valeur tracée est disponible via [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Le point de données reste à la même position de catégorie, mais le diagramme considère sa valeur comme vide selon les paramètres de valeurs vides du diagramme.

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

Les diagrammes de dispersion utilisent des cellules X et Y distinctes, et les diagrammes à bulles utilisent également une cellule de taille. Effacez uniquement la cellule qui représente la valeur que vous souhaitez supprimer. N’appelez pas [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) lorsque vous voulez conserver les autres points, car cette méthode supprime chaque point de données de la collection.

## **Contrôler l’affichage des cellules vides**

Les cellules masquées contenant des valeurs constituent un cas distinct des cellules vides. Pour inclure ou exclure des données provenant de lignes et colonnes de feuille masquées, voir [Inclure des données à partir de lignes et colonnes masquées](/slides/fr/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Une cellule de classeur vide représente des données manquantes ; une cellule contenant `0` représente une valeur numérique connue. Appelez [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) avec `null` pour rendre une cellule vide. Un zéro numérique reste un zéro quel que soit le paramètre des cellules vides.

Utilisez [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) pour choisir comment le diagramme affiche les cellules vides. Ce paramètre s’applique à l’ensemble du diagramme. Il modifie la façon dont les vides sont tracés, sans remplir la cellule vide du classeur avec zéro ou une valeur interpolée.

L’exemple autonome suivant crée un diagramme en ligne avec une série, efface la valeur du jour 3, et enregistre le même diagramme avec chaque mode. Aucun fichier d’entrée n’est requis. Le [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40`.

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

    // Laisser le jour 3 réellement vide, tout en conservant sa catégorie et son point de données.
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

Chaque fichier de sortie stocke le mode attribué avant l’enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour n’enregistrer qu’une seule version, attribuez le mode souhaité et enregistrez la présentation une fois au lieu d’itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le jour 3 est vide dans le classeur dans chaque cas :

![Diagrammes en lignes avec données identiques : Gap coupe la ligne au jour 3, Zero abaisse la ligne à zéro, et Span relie le jour 2 au jour 4.](display_blanks_as.png)

L’effet visible dépend du type de diagramme. Un diagramme en ligne rend les trois modes faciles à comparer. Les diagrammes à barres et à colonnes n’ont pas de ligne à connecter à travers une catégorie manquante, ainsi `Span` ne peut pas produire le segment de connexion montré ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent également se ressembler. De même, un diagramme de dispersion avec seulement des marqueurs n’a pas de ligne de connexion. N’attendez pas trois résultats distincts pour chaque type de diagramme ; vérifiez la sortie pour le type que vous utilisez.

## **Définir la largeur d’écart de la série**

La largeur d’écart est l’espace entre les clusters de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe de séries parent plutôt qu’à une seule série. Appelez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) une fois pour le groupe. Une valeur plus grande crée davantage d’espace entre les clusters ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur d’écart et n’enregistre que la présentation finale :

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

![Largeur d’écart](gap_width.png)

## **FAQ**

**Quels types de diagrammes prennent en charge les séries de données ?**

Tous les types de diagrammes représentés par l’énumération [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) utilisent des données de diagramme, mais leurs séries n’ont pas toutes la même structure de valeurs ni les mêmes paramètres. Par exemple, les diagrammes à catégories utilisent des catégories et des valeurs, les diagrammes de dispersion utilisent des valeurs X et Y, et les diagrammes à bulles ajoutent des tailles de bulle. Utilisez la méthode de création de point de données correspondant au type de série. Les options telles que le chevauchement et la largeur d’écart ne s’appliquent qu’aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de diagramme ?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) contient des séries compatibles qui partagent des paramètres de traçage au niveau du groupe. Un diagramme combiné peut contenir plusieurs groupes, de sorte que modifier le groupe atteint via une série ne modifie pas nécessairement toutes les séries du diagramme.

**Un diagramme nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crée des séries, des catégories et des valeurs d’exemple. Vous pouvez modifier ces cellules ou effacer les collections de séries et de catégories avant d’ajouter un jeu de données entièrement personnalisé. Une surcharge peut également créer un diagramme sans données par défaut.

**Comment les objets du diagramme sont‑ils reliés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données font référence aux cellules d’un [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/). Modifier une cellule référencée met à jour l’élément de diagramme correspondant. Lorsque vous créez des données personnalisées, gardez les lignes de catégories et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point sans supprimer toute la série ?**

Définissez la cellule de valeur concernée sur `null` pour conserver la position de catégorie du point en tant que point vide. Utilisez [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) uniquement lorsque vous souhaitez supprimer tous les points de cette série. Si vous supprimez également les catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de diagramme et de la valeur configurée via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Les diagrammes pris en charge peuvent afficher les vides comme des écarts, comme des valeurs zéro, ou en reliant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation. Voir [Contrôler l’affichage des cellules vides](#control-the-display-of-empty-cells) pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries à barres, colonnes et bulles prises en charge, appelez [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) et définissez la couleur renvoyée par [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Vous pouvez remplacer le comportement pour un point individuel avec [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel format l’emporte lorsqu’une série et un point sont tous deux formatés ?**

Le formatage explicite d’un point de données prime pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, si le format de série n’est pas défini, le style et le thème automatiques du diagramme. Les paramètres de groupe tels que le chevauchement et la largeur d’écart contrôlent la disposition et ne sont pas des surcharges de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un diagramme peut contenir ?**

Aspose.Slides n’impose pas de limite fixe séparée au nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du diagramme déterminent une limite raisonnable.

**Que faut‑il modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les clusters, ou diminuez‑la pour rapprocher les clusters.