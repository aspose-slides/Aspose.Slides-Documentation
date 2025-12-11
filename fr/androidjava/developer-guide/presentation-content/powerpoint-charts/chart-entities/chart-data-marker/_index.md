---
title: Gérer les marqueurs de données de graphique dans les présentations sur Android
linktitle: Marqueur de données
type: docs
url: /fr/androidjava/chart-data-marker/
keywords:
- graphique
- point de données
- marqueur
- options de marqueur
- taille du marqueur
- type de remplissage
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Personnalisez les marqueurs de données de graphique dans Aspose.Slides pour Android, augmentant l’impact des présentations aux formats PPT et PPTX avec des exemples de code Java clairs."
---

## **Définir les options des marqueurs de graphique**
Les marqueurs peuvent être définis sur les points de données du graphique à l'intérieur de séries particulières. Pour définir les options des marqueurs de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Définir l’image.
- Prendre la première série du graphique.
- Ajouter un nouveau point de données.
- Écrire la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini les options des marqueurs de graphique au niveau des points de données.
```java
// Création d'une présentation vide
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Création du graphique par défaut
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Obtention de l'index de la feuille de calcul de données du graphique par défaut
    int defaultWorksheetIndex = 0;
    
    // Obtention de la feuille de calcul de données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Supprimer la série de démonstration
    chart.getChartData().getSeries().clear();
    
    // Ajouter une nouvelle série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Charger l'image 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Charger l'image 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Prendre la première série du graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Ajouter un nouveau point (1:3) à cet endroit.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Modification du marqueur de la série du graphique
    series.getMarker().setSize(15);
    
    // Enregistrer la présentation avec le graphique
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Quelles formes de marqueurs sont disponibles dès le départ ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par la classe [MarkerStyleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markerstyletype/). Si vous avez besoin d’une forme non standard, utilisez un marqueur avec un remplissage d’image pour émuler des visuels personnalisés.

**Les marqueurs sont‑ils conservés lors de l’exportation d’un graphique vers une image ou un SVG ?**

Oui. Lors du rendu de graphiques vers des [formats raster](/slides/fr/androidjava/convert-powerpoint-to-png/) ou de l’enregistrement de [formes au format SVG](/slides/fr/androidjava/render-a-slide-as-an-svg-image/), les marqueurs conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.