---
title: Marqueur de données du graphique
type: docs
url: /androidjava/chart-data-marker/
---

## **Définir les options de marqueur de graphique**
Les marqueurs peuvent être définis sur les points de données du graphique à l'intérieur de séries particulières. Pour définir les options du marqueur de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série de graphique.
- Ajouter un nouveau point de données.
- Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini les options de marqueur de graphique au niveau des points de données.

```java
// Création d'une présentation vide
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Création du graphique par défaut
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Obtention de l'index de la feuille de calcul par défaut des données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtention de la feuille de calcul des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Supprimer la série de démonstration
    chart.getChartData().getSeries().clear();
    
    // Ajouter une nouvelle série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Série 1"), chart.getType());

    // Charger l'image 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Charger l'image 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Prendre la première série de graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Ajouter un nouveau point (1:3) ici.
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
    
    // Changer le marqueur de la série de graphique
    series.getMarker().setSize(15);
    
    // Enregistrer la présentation avec le graphique
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```