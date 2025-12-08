---
title: Marqueur de données de graphique
type: docs
url: /fr/nodejs-java/chart-data-marker/
---

## **Définir les options des marqueurs de graphique**

Les marqueurs peuvent être définis sur les points de données du graphique dans des séries spécifiques. Pour définir les options des marqueurs de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série du graphique.
- Ajouter un nouveau point de données.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini les options des marqueurs de graphique au niveau des points de données.
```javascript
// Création d'une présentation vide
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Création du graphique par défaut
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Obtention de l'index de la feuille de calcul de données du graphique par défaut
    var defaultWorksheetIndex = 0;
    // Obtention de la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Supprimer la série de démonstration
    chart.getChartData().getSeries().clear();
    // Ajouter une nouvelle série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Charger l'image 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Charger l'image 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Prendre la première série du graphique
    var series = chart.getChartData().getSeries().get_Item(0);
    // Ajouter un nouveau point (1:3) ici.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Modification du marqueur de la série du graphique
    series.getMarker().setSize(15);
    // Enregistrer la présentation avec le graphique
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Quelles formes de marqueur sont disponibles nativement ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par l'énumération [MarkerStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markerstyletype/). Si vous avez besoin d'une forme non standard, utilisez un marqueur avec un remplissage d'image pour reproduire des visuels personnalisés.

**Les marqueurs sont‑ils conservés lors de l'exportation d'un graphique vers une image ou un SVG ?**

Oui. Lors du rendu des graphiques vers des [formats raster](/slides/fr/nodejs-java/convert-powerpoint-to-png/) ou lors de l'enregistrement des [formes au format SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/), les marqueurs conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.