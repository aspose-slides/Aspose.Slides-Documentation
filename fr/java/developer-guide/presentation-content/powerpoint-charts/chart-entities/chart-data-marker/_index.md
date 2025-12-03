---
title: Gérer les repères de données de graphique dans les présentations avec Java
linktitle: Repère de données
type: docs
url: /fr/java/chart-data-marker/
keywords:
- graphique
- point de données
- repère
- options de repère
- taille du repère
- type de remplissage
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à personnaliser les repères de données de graphique dans Aspose.Slides pour Java, renforçant l'impact des présentations au format PPT et PPTX grâce à des exemples de code Java clairs."
---

## **Définir les options de repère du graphique**
Les repères peuvent être définis sur les points de données du graphique à l'intérieur de séries particulières. Pour définir les options de repère du graphique, veuillez suivre les étapes ci‑dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série du graphique.
- Ajouter un nouveau point de données.
- Écrire la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini les options de repère du graphique au niveau des points de données.
```java
// Créer une présentation vide
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Créer le graphique par défaut
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Obtenir l'index de la feuille de calcul de données du graphique par défaut
    int defaultWorksheetIndex = 0;
    
    // Obtenir la feuille de calcul de données du graphique
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
    
    // Ajouter un nouveau point (1:3) là.
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
    
    // Modifier le marqueur de la série du graphique
    series.getMarker().setSize(15);
    
    // Enregistrer la présentation avec le graphique
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Quelles formes de repère sont disponibles prêtes à l'emploi ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par la classe [MarkerStyleType](https://reference.aspose.com/slides/java/com.aspose.slides/markerstyletype/). Si vous avez besoin d'une forme non standard, utilisez un repère avec un remplissage d'image pour émuler des visuels personnalisés.

**Les repères sont-ils conservés lors de l'exportation d'un graphique vers une image ou un SVG ?**

Oui. Lors du rendu des graphiques vers des [formats raster](/slides/fr/java/convert-powerpoint-to-png/) ou de l'enregistrement des [formes au format SVG](/slides/fr/java/render-a-slide-as-an-svg-image/), les repères conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.