---
title: Gérer les repères de données de graphique dans les présentations avec Python
linktitle: Marqueur de données
type: docs
url: /fr/python-net/chart-data-marker/
keywords:
- graphique
- point de données
- marqueur
- options de marqueur
- taille du marqueur
- type de remplissage
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à personnaliser les marqueurs de données de graphique dans Aspose.Slides, améliorant l'impact des présentations aux formats PPT, PPTX et ODP grâce à des exemples de code clairs."
---

## **Définir les options des marqueurs de graphique**
Les marqueurs peuvent être définis sur les points de données du graphique au sein de séries spécifiques. Pour définir les options des marqueurs de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série du graphique.
- Ajouter un nouveau point de données.
- Enregistrer la présentation sur le disque.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Créer le graphique par défaut
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Obtenir l'index de la feuille de calcul des données du graphique par défaut
    defaultWorksheetIndex = 0

    # Obtenir la feuille de calcul des données du graphique
    fact = chart.chart_data.chart_data_workbook

    # Supprimer la série de démonstration
    chart.chart_data.series.clear()

    # Ajouter une nouvelle série
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Définir l'image
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Définir l'image
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Prendre la première série du graphique
    series = chart.chart_data.series[0]

    # Ajouter un nouveau point (1:3) ici.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Modifier le marqueur de la série du graphique
    series.marker.size = 15

    # Enregistrer la présentation sur le disque
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quelles formes de marqueur sont disponibles immédiatement ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par l'énumération [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/). Si vous avez besoin d'une forme non standard, utilisez un marqueur avec un remplissage d'image pour reproduire des visuels personnalisés.

**Les marqueurs sont-ils conservés lors de l'exportation d'un graphique vers une image ou un SVG ?**

Oui. Lors du rendu des graphiques vers des [formats raster](/slides/fr/python-net/convert-powerpoint-to-png/) ou lors de l'enregistrement des [formes au format SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/), les marqueurs conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.