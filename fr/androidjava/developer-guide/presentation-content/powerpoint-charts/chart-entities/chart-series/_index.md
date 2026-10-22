---
title: Gérer les séries de données de diagramme dans les présentations sur Android
linktitle: Séries de données
type: docs
url: /fr/androidjava/chart-series/
keywords:
- séries de diagramme
- chevauchement des séries
- couleur de la série
- nom de la série
- point de données
- cellule de classeur
- écart de série
- valeur négative
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment gérer les séries de diagramme, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur d'écart et les valeurs négatives dans les présentations sur Android."
---
## **Vue d'ensemble**

Un diagramme peut stocker ses valeurs tracées dans les cellules du classeur ou directement sous forme de littéraux numériques. Un [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) représente un ensemble de valeurs liées, et chaque [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) représente un point de cette série. Les objets [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) fournissent les libellés ou les valeurs de regroupement partagés par les séries. Dans les diagrammes créés avec des données par défaut, les noms de séries, les catégories et les valeurs des points utilisent des objets [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) du classeur du diagramme.

Pour un diagramme à barres de catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégorie, et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) sont basés à zéro. Cette disposition est pratique lorsque vous créez un diagramme avec des données par défaut, mais ne supposez pas qu’elle soit utilisée par chaque diagramme existant. Pour une présentation chargée, inspectez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du diagramme ont trois portées différentes :

- Paramètres au niveau de la série, tels que [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--), fournissent l’apparence par défaut pour tous les points d’une même série.
- Paramètres au niveau du point de données, tels que [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), remplacent l’apparence de la série pour un point donné.
- Les paramètres de groupe s’appliquent aux séries compatibles appartenant au même [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/). Accédez au groupe via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) lorsque vous devez définir des options telles que le chevauchement ou la largeur d’écart.

Lorsqu’aucun remplissage de point ou de série n’est explicitement défini, le style et le thème du diagramme déterminent l’apparence automatique. Lorsque le formatage de la série et celui du point sont présents, le formatage du point l’emporte pour ce point.

![diagramme-series-powerpoint](chart-series-powerpoint.png)

## **Définir les valeurs de série à l’aide de littéraux numériques**

Utilisez des littéraux numériques lorsque les valeurs de la série proviennent de données d’application ou de calculs et n’ont pas besoin de références à des cellules de feuille. Appelez [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) avec [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) avant d’attribuer le résultat de [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) de chaque point via [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

Le paramètre de collection contrôle le type de source de toutes les valeurs de points de cette série. La méthode [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) de chaque valeur de point indique le type sélectionné ; modifiez‑le via le paramètre de collection. Avec `Worksheet`, utilisez [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) pour accéder à la cellule référencée. Avec `DoubleLiterals`, utilisez [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) ou `setAsLiteralDouble` pour lire ou écrire le nombre directement.

L’exemple suivant crée un diagramme en colonnes avec des séries et catégories par défaut, puis affecte les valeurs calculées 10, 20, etc. aux points existants de sa première série. Il enregistre la présentation, la rouvre et imprime les valeurs stockées.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Le type de source de la valeur du point est distinct de [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--), qui identifie la configuration du classeur interne ou externe du diagramme. L’utilisation de littéraux numériques ne supprime pas, en elle‑même, le classeur incorporé. Dans cet exemple, le classeur reste disponible pour les libellés de catégorie, les noms de séries et les autres séries. Consultez [Chart Workbook](/slides/fr/androidjava/chart-workbook/) pour la gestion du classeur.

Pour les diagrammes en nuage de points et à bulles, utilisez [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) et [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) afin de choisir les sources pour [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) et [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--). Les diagrammes à bulles utilisent également [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) pour [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Définissez chaque source applicable sur `DoubleLiterals` avant d’attribuer les nombres via la méthode `setAsLiteralDouble` de cette valeur.

## **Définir le chevauchement des séries du diagramme**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) indique le degré de chevauchement des barres ou colonnes dans un diagramme 2D, de –100 à 100 %. C’est une projection en lecture‑seule du paramètre du groupe de séries parent. Utilisez [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) pour mettre à jour toutes les séries compatibles de ce groupe. Cette option s’applique aux types de diagrammes qui affichent des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un diagramme combiné.

L’exemple suivant définit le chevauchement pour le groupe contenant la première série :

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Le nouveau diagramme contient des séries d'exemple, des catégories et des valeurs.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le chevauchement des séries](series_overlap.png)

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

![La couleur de la série](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du diagramme et apparaît normalement dans la légende. Dans le classeur par défaut créé pour un diagramme à colonnes groupées, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les constantes nommées de l’exemple suivant rendent cette structure explicite :

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

Vous pouvez également mettre à jour la cellule déjà référencée par [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--). Cette approche évite de supposer une ligne ou une colonne particulière dans un diagramme existant :

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

![Le nom de la série](series_name.png)

### **Créer une série avec un nom provenant de plusieurs cellules**

Un nom de série composite est utile lorsqu’un nom de produit et une période de rapport sont stockés dans des cellules de classeur distinctes. Par exemple, vous pouvez combiner `Product A` en B1 et `2026` en C1 en un seul nom de série tout en conservant les deux parties liées à leurs cellules sources.

Utilisez [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) pour récupérer la plage de noms, puis transmettez cette collection à [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). L’argument `skipHiddenCells` contrôle l’inclusion des cellules cachées : `true` les exclut, `false` les inclut. Cet exemple utilise `false` pour inclure chaque cellule de la plage de noms.

L’exemple suivant crée une présentation avec une série et deux points de données. Les cellules B1:C1 ne fournissent que le nom de la série ; A2:A3 fournissent les libellés de catégorie, et B2:B3 les valeurs numériques.

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

Le nom de série résultant est `Product A 2026`, avec un espace entre les deux valeurs de cellules. La légende l’affiche comme une seule entrée pour les deux colonnes. L’image ci‑dessous illustre le résultat :

![Diagramme en colonnes avec valeurs Nord et Sud et le nom de série composite Product A 2026 dans la légende](composite_series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) renvoie la couleur calculée à partir de l’index de la série et du style du diagramme sous forme d’entier ARGB Android. C’est la couleur utilisée lorsque le remplissage de la série n’est pas explicitement défini. L’appel de la méthode lit la couleur calculée ; il n’attribue pas de nouveau remplissage.

L’exemple suivant imprime l’entier de couleur automatique de chaque série par défaut :

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

Pour les séries à barres, en colonnes et à bulles, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage régulier de la série sur solide, activez l’inversion et attribuez la couleur des valeurs négatives via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Les nombres négatifs restent inchangés dans le classeur ; seul leur couleur d’affichage varie.

L’exemple suivant remplace les données du diagramme par défaut par une série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 les noms de catégorie, et la colonne 1 les valeurs :

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

![La couleur de remplissage solide inversée](inverted_solid_fill_color.png)

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

Pour rendre un point vide sans supprimer les autres points, attribuez `null` à sa cellule de classeur sous‑jacent. Dans un diagramme en colonnes, la valeur tracée est accessible via [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Le point de données reste à la même position de catégorie, mais le diagramme considère sa valeur comme vide selon les paramètres de gestion des valeurs vides du diagramme.

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

Les diagrammes en nuage de points utilisent des cellules X et Y distinctes, et les diagrammes à bulles utilisent également une cellule de taille. Effacez uniquement la cellule représentant la valeur que vous souhaitez supprimer. N’appeler pas [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) si vous voulez conserver les autres points, car cette méthode supprime tous les points de la collection.

## **Contrôler l’affichage des cellules vides**

Les cellules cachées contenant des valeurs constituent un cas distinct des cellules vides. Pour inclure ou exclure des données provenant de lignes et colonnes de feuille masquées, consultez [Include Data from Hidden Rows and Columns](/slides/fr/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Une cellule de classeur vide représente une donnée manquante ; une cellule contenant `0` représente une valeur numérique connue. Appelez [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) avec `null` pour rendre une cellule vide. Un zéro numérique reste zéro quel que soit le réglage des cellules vides.

Utilisez [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) pour choisir comment le diagramme affiche les cellules vides. Ce paramètre s’applique à l’ensemble du diagramme. Il modifie la façon dont les vides sont tracés, sans remplir la cellule de classeur vide avec zéro ou une valeur interpolée.

L’exemple autonome suivant crée un diagramme en ligne avec une série, vide la valeur du jour 3, et enregistre le même diagramme avec chaque mode. Aucun fichier d’entrée n’est requis. Le [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie, et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40`.

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

Chaque fichier de sortie stocke le mode assigné avant l’enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour n’enregistrer qu’une version, affectez le mode souhaité et enregistrez la présentation une seule fois au lieu d’itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le jour 3 est vide dans le classeur dans chaque cas :

![Diagrammes en ligne avec données identiques : Gap interrompt la ligne au jour 3, Zero abaisse la ligne à zéro, et Span relie le jour 2 au jour 4.](display_blanks_as.png)

L’effet visible dépend du type de diagramme. Un diagramme en ligne rend les trois modes faciles à comparer. Les diagrammes à barres et à colonnes n’ont pas de ligne à connecter à travers une catégorie manquante, si bien que `Span` ne peut pas produire le segment de connexion affiché ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent également se ressembler. De même, un diagramme en nuage de points avec uniquement des marqueurs n’a pas de ligne de connexion. N’attendez pas trois résultats distincts pour chaque type de diagramme ; vérifiez la sortie pour le type que vous utilisez.

## **Définir la largeur d’écart des séries**

La largeur d’écart est l’espace entre les groupes de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe de séries parent plutôt qu’à une seule série. Appelez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) une fois pour le groupe. Une valeur plus grande crée plus d’espace entre les groupes ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur d’écart et enregistre uniquement la présentation finale :

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

![La largeur d’écart](gap_width.png)

## **FAQ**

**Quels types de diagrammes prennent en charge les séries de données ?**

Toutes les formes de diagrammes représentées par l’énumération [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) utilisent des données de diagramme, mais leurs séries n’ont pas toutes la même structure de valeur ou les mêmes paramètres. Par exemple, les diagrammes de catégorie utilisent des catégories et des valeurs, les diagrammes en nuage de points utilisent des valeurs X et Y, et les diagrammes à bulles ajoutent des tailles de bulles. Utilisez la méthode de création de point de données qui correspond au type de série. Les options telles que le chevauchement et la largeur d’écart s’appliquent uniquement aux groupes de barres ou colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de diagramme ?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) regroupe des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un diagramme combiné peut contenir plusieurs groupes, de sorte que la modification du groupe atteint via une série ne modifie pas nécessairement toutes les séries du diagramme.

**Un diagramme nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crée des séries, des catégories et des valeurs d’exemple. Vous pouvez modifier ces cellules ou vider les collections de séries et de catégories avant d’ajouter un jeu de données entièrement personnalisé. Une surcharge peut également créer un diagramme sans données par défaut.

**Comment les objets du diagramme sont‑ils reliés aux cellules du classeur ?**

Les noms de série, les libellés de catégorie et les valeurs des points de données font référence à des cellules d’un [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/). Modifier une cellule référencée met à jour l’élément de diagramme correspondant. Lorsque vous construisez des données personnalisées, maintenez les lignes de catégorie et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point sans supprimer toute la série ?**

Attribuez `null` à la cellule de valeur concernée pour conserver la position de catégorie du point comme point vide. Utilisez [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) uniquement lorsque vous souhaitez supprimer tous les points d’une série. Si vous supprimez aussi les catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de diagramme et du paramètre configuré via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Les diagrammes pris en charge peuvent afficher les vides sous forme d’intervalles, de valeurs zéro ou en reliant les points voisins. Choisissez le réglage qui correspond à la signification des données manquantes dans votre présentation. Consultez [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries à barres, colonnes et bulles prises en charge, appelez [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) et définissez la couleur renvoyée par [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Vous pouvez remplacer le comportement pour un point individuel avec [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel formatage l’emporte lorsque la série et le point sont tous deux formatés ?**

Le formatage explicite d’un point de données l’emporte pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, lorsqu’il n’est pas défini, le style et le thème automatiques du diagramme. Les paramètres de groupe tels que le chevauchement et la largeur d’écart contrôlent la mise en page et ne sont pas des remplacements de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un diagramme peut contenir ?**

Aspose.Slides n’impose pas de limite fixe distincte du nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du diagramme déterminent une limite raisonnable.

**Que faut‑il modifier lorsque les colonnes sont trop rapprochées ou trop éloignées ?**

Appelez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les groupes, ou diminuez‑la pour rapprocher les groupes.