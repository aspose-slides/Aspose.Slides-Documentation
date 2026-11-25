---
title: Personnaliser les graphiques 3D dans les présentations sur Android
linktitle: Graphique 3D
type: docs
url: /fr/androidjava/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer des graphiques 3D dans des présentations PowerPoint avec Aspose.Slides pour Android via Java. Ajustez la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples Java."
---
## **Aperçu**

Aspose.Slides for Android via Java vous permet de personnaliser la vue d’un graphique 3D via la méthode [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l’espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d'un graphique 3D**

L'exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et utilise [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) pour ajouter un graphique à colonnes empilées 3D à sa première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant chacune trois valeurs. L’index de feuille de calcul `0` identifie la première feuille de données du graphique ; la ligne `0` contient les noms de séries et la colonne `0` contient les libellés de catégorie.

Les méthodes [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) et [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) définissent la rotation du graphique à 40 et 270 degrés respectivement. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) fixe sa profondeur à 150 % de sa largeur, tandis que [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) active des axes à angle droit au lieu d’une perspective. La présentation résultante contient le graphique renseigné avec ces réglages de vue 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Appliquer un remplissage d'image à la surface d'un graphique 3D**

Un graphique 3D possède trois surfaces que vous pouvez remplir indépendamment : le [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), le [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) et le [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) . Définissez le [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) de la surface sur `Picture` et assignez une image. Définissez à la fois le [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) et le [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) de la surface sur `Stretch` pour adapter une copie de l'image à toute la surface.

Enregistrez [arrow.png](arrow.png) dans le répertoire de travail. L'exemple fait pivoter le graphique et augmente la valeur maximale de l'axe vertical afin que le plancher soit visible entre les colonnes. Il clone ensuite la diapositive deux fois et applique la flèche à une surface différente sur chaque diapositive. Les trois graphiques conservent les mêmes données, le même angle de vue et le même arrière‑plan.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint affiche les trois diapositives comme suit.

| Paroi latérale | Paroi arrière | Plancher |
| --- | --- | --- |
| ![Flèche pointant dans le graphique le long de la paroi latérale](side-wall.png) | ![Flèche pointant vers la droite à travers la paroi arrière](back-wall.png) | ![Flèche pointant vers la droite à travers le plancher entre les colonnes](floor.png) |

## **Ajuster les proportions de hauteur d'un graphique 3D**

Utilisez [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) pour définir la hauteur d’un graphique 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l’objet graphique sur la diapositive.

L'exemple suivant crée un graphique [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l'espacement des séries et le formatage sont identiques dans les trois fichiers ; seule la proportion de hauteur varie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Les images suivantes illustrent les mêmes réglages de hauteur dans l’exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint. Un pourcentage plus petit produit une scène plus plate, tandis qu’un pourcentage plus grand produit une scène plus haute dans le même objet graphique. PowerPoint peut également ajuster les intervalles des graduations d’axe et le placement des libellés pour s’adapter à la scène.

| Hauteur : 50% | Hauteur : 100% | Hauteur : 200% |
| --- | --- | --- |
| ![Graphique à colonnes 3D avec une hauteur fixée à 50 % de sa largeur](height_percent_50.png) | ![Graphique à colonnes 3D avec une hauteur fixée à 100 % de sa largeur](height_percent_100.png) | ![Graphique à colonnes 3D avec une hauteur fixée à 200 % de sa largeur](height_percent_200.png) |

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Hauteur de l’objet graphique sur la diapositive, en points. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du repère. |

Le réglage de hauteur affecte les graphiques à colonnes et à barres 3D, y compris les variantes cylindre, cône et pyramide, ainsi que les graphiques linéaires, de surface, circulaires et de zone 3D. La comparaison ci‑dessus utilise le type vérifié `Column3D`. Ce réglage ne modifie pas l’apparence d’un graphique 2D `ClusteredColumn` ou d’un graphique `BubbleWith3D` ; ces noms sont des membres de la classe [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Pour d’autres réglages d’apparence de graphique, consultez [Chart Formatting](/slides/fr/androidjava/chart-formatting/).

## **Ajuster l'écart entre les séries**

Utilisez [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) pour contrôler la distance entre les séries de données le long de l’axe de profondeur d’un graphique 3D, exprimée en pourcentage de la largeur du repère. Utilisez des valeurs de **0 à 500**, incluses : `0` supprime l’écart, tandis que des valeurs plus élevées augmentent l’espacement. Avec une profondeur de graphique fixe, augmenter l’écart rend les repères plus fins le long de l’axe de profondeur.

Accédez au groupe via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Le réglage s’applique à chaque série du groupe, pas uniquement à celle utilisée pour y accéder. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) renvoie l’écart de profondeur et reflète le réglage du groupe parent.

Ce réglage affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques linéaires et de surface 3D. L’apparence dépend de la façon dont les séries sont disposées en profondeur, en grappes ou empilées. Pour une comparaison claire des écarts entre des séries distinctes, utilisez `ChartType.Column3D` de la classe [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du repère. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Espacement entre les groupes de barres ou de colonnes adjacents, en pourcentage de la largeur de la barre ou de la colonne. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L’exemple autonome suivant utilise les données de graphique par défaut, qui contiennent trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d’écart et une profondeur de graphique identiques ; seul l’écart de profondeur varie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Les images suivantes illustrent les mêmes réglages d’écart de profondeur dans l’exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint.

| Écart de profondeur : 0% | Écart de profondeur : 500% |
| --- | --- |
| ![Graphique à colonnes 3D sans écart entre les séries le long de l'axe de profondeur](gap_depth_0.png) | ![Graphique à colonnes 3D avec un écart de 500 % entre les séries le long de l'axe de profondeur](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme des barres**

Dans un graphique à cylindres groupés, la première série commence avec une forme de barre cylindrique. L’exemple affiche les valeurs entières renvoyées par [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) et [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) avant et après chaque modification. Le tableau donne les noms de constantes correspondants.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Modifier la première série | Type de série | Forme de barre |
| --- | --- | --- |
| Créer le graphique | `ClusteredCylinder` | `Cylinder` |
| Définir le type de série à `ClusteredCone` | `ClusteredCone` | `Cone` |
| Définir la forme de barre à `Box` | `ClusteredColumn3D` | `Box` |

Définir la forme sur `Box` modifie également le type de série en `ClusteredColumn3D`. Si votre code effectue des branches en fonction du type de série, appelez `series.getType()` après avoir changé la forme. Une valeur mise en cache avant l’affectation sélectionnerait toujours la branche `ClusteredCone`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, cônes et colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via la classe [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d'un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique sous forme d’image avec [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) ou [rendre la diapositive entière](/slides/fr/androidjava/convert-powerpoint-to-png/) vers des formats comme PNG ou JPEG. Cela est utile si vous avez besoin d’un aperçu raster ou si vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque possible, et rendez la sortie à une résolution et des dimensions appropriées à l’affichage ou à l’impression cible.