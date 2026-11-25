---
title: Personnaliser les graphiques 3D dans les présentations avec JavaScript
linktitle: Graphique 3D
type: docs
url: /fr/nodejs-java/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer des graphiques 3D dans les présentations PowerPoint avec Aspose.Slides pour Node.js via Java. Ajustez la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples JavaScript."
---
## **Aperçu**

Aspose.Slides for Node.js via Java vous permet de personnaliser la vue d’un graphique 3D à l’aide de la méthode [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l’espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d’un graphique 3D**

L’exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et utilise [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) pour ajouter un graphique à colonnes 3D empilées à la première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant chacune trois valeurs. L’index de la feuille de calcul `0` identifie la première feuille de données du graphique ; la ligne `0` contient les noms des séries, et la colonne `0` contient les libellés des catégories.

Les méthodes [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) et [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) définissent la rotation du graphique à 40 et 270 degrés, respectivement. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) fixe sa profondeur à 150 % de sa largeur, tandis que [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) active les axes à angle droit au lieu de la perspective. La présentation résultante contient le graphique renseigné avec ces paramètres de vue 3D.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Appliquer un remplissage d’image à la surface d’un graphique 3D**

Vous pouvez remplir indépendamment le [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), le [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) et le [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) d’un graphique 3D. Définissez le [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) de la surface sur `Picture` et attribuez une image. Réglez à la fois le [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) et le [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) de la surface sur `Stretch` pour ajuster une copie de l’image sur la surface.

Enregistrez [arrow.png](arrow.png) dans le répertoire de travail. L’exemple fait pivoter le graphique et augmente la valeur maximale de l’axe vertical afin que le plancher soit visible entre les colonnes. Il duplique ensuite la diapositive deux fois et applique la flèche à une surface différente sur chaque diapositive. Les trois graphiques conservent les mêmes données, le même angle de vue et le même arrière‑plan.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint montre les trois diapositives comme suit.

| Paroi latérale | Paroi arrière | Plancher |
| --- | --- | --- |
| ![Flèche pointant dans le graphique le long de la paroi latérale](side-wall.png) | ![Flèche pointant vers la droite à travers la paroi arrière](back-wall.png) | ![Flèche pointant vers la droite à travers le plancher entre les colonnes](floor.png) |

## **Ajuster les proportions de hauteur d’un graphique 3D**

Utilisez [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) pour définir la hauteur d’un graphique 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l’objet graphique sur la diapositive.

L’exemple suivant crée un graphique [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l’espacement des séries et le formatage sont identiques dans les trois fichiers ; seule la proportion de hauteur varie.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Les images suivantes illustrent les mêmes réglages de hauteur dans l’exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint. Un pourcentage plus petit produit une scène plus plate, tandis qu’un pourcentage plus grand produit une scène plus haute dans le même objet graphique. PowerPoint ajuste également les intervalles des graduations d’axe et le placement des libellés pour adapter la scène.

| Hauteur : 50 % | Hauteur : 100 % | Hauteur : 200 % |
| --- | --- | --- |
| ![Graphique à colonnes 3D avec une hauteur réglée à 50 % de sa largeur](height_percent_50.png) | ![Graphique à colonnes 3D avec une hauteur réglée à 100 % de sa largeur](height_percent_100.png) | ![Graphique à colonnes 3D avec une hauteur réglée à 200 % de sa largeur](height_percent_200.png) |

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Hauteur de l’objet graphique sur la diapositive, en points. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |

Le réglage de hauteur affecte les graphiques à colonnes et à barres 3D, y compris les variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne, surface, secteur et zone. La comparaison ci‑dessus utilise le type vérifié `Column3D`. Ce réglage ne modifie pas l’apparence d’un graphique 2D `ClusteredColumn` ou d’un graphique `BubbleWith3D` ; ces noms sont des membres de la classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Pour d’autres paramètres d’apparence de graphique, consultez [Chart Formatting](/slides/fr/nodejs-java/chart-formatting/).

## **Ajuster l’écart entre les séries**

Utilisez [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) pour contrôler la distance entre les séries de données le long de l’axe de profondeur d’un graphique 3D, exprimée en pourcentage de la largeur du marqueur. Utilisez des valeurs de **0 à 500**, incluses : `0` supprime l’écart, tandis que des valeurs plus élevées augmentent l’espacement. Avec une profondeur de graphique fixe, augmenter l’écart rend les marqueurs plus fins le long de l’axe de profondeur.

Accédez au groupe via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Le réglage s’applique à chaque série du groupe, pas seulement à celle utilisée pour y accéder. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) renvoie l’écart de profondeur et reflète le réglage du groupe parent.

Ce réglage affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne et en zone. L’apparence dépend de la façon dont les séries sont disposées en profondeur, groupées ou empilées. Pour une comparaison claire des écarts entre séries séparées, utilisez `ChartType.Column3D` de la classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Espacement entre les groupes de barres ou de colonnes adjacents, en pourcentage de la largeur de la barre ou de la colonne. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L’exemple suivant, autonome, utilise les données par défaut du graphique, qui contiennent trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d’écart et une profondeur de graphique identiques ; seule la profondeur d’écart varie.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Les images suivantes illustrent les mêmes réglages de profondeur d’écart dans l’exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint.

| Profondeur d’écart : 0 % | Profondeur d’écart : 500 % |
| --- | --- |
| ![Graphique à colonnes 3D sans aucun écart entre les séries le long de l’axe de profondeur](gap_depth_0.png) | ![Graphique à colonnes 3D avec un écart de 500 % entre les séries le long de l’axe de profondeur](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme des barres**

Dans un graphique à cylindres groupés, la première série commence avec une forme de barre cylindrique. L’exemple affiche les valeurs entières renvoyées par [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) et [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) avant et après chaque modification. Le tableau donne les noms de constantes correspondants.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Modification de la première série | Type de série | Forme de la barre |
| --- | --- | --- |
| Créez le graphique | `ClusteredCylinder` | `Cylinder` |
| Définissez le type de série sur `ClusteredCone` | `ClusteredCone` | `Cone` |
| Définissez la forme de la barre sur `Box` | `ClusteredColumn3D` | `Box` |

Définir la forme sur `Box` change également le type de série en `ClusteredColumn3D`. Si votre code effectue des branchements selon le type de série, appelez `series.getType()` après avoir changé la forme. Une valeur mise en cache avant l’affectation sélectionnerait encore la branche `ClusteredCone`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, cônes et colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés par la classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) dans la référence API de la version que vous avez installée.

**Puis-je obtenir une image raster d’un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique vers une image avec [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) ou [render the entire slide](/slides/fr/nodejs-java/convert-powerpoint-to-png/) vers des formats tels que PNG ou JPEG. Cela est utile lorsqu’il faut obtenir un aperçu raster ou intégrer le graphique dans des documents, tableaux de bord ou pages web sans exiger PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

La performance dépend du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les aires de tracé, réduisez le nombre de points de données par série lorsque cela est possible, et rendez à une résolution et des dimensions appropriées à l’affichage ou à l’impression cible.