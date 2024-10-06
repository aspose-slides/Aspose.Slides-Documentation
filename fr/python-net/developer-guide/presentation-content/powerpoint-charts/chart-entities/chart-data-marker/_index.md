---
title: Marqueur de Données de Graphique
type: docs
url: /python-net/chart-data-marker/
keywords: "Options de marqueur de graphique, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Définir les options de marqueur de graphique dans des présentations PowerPoint en Python"
---

## **Définir les Options de Marqueur de Graphique**
Les marqueurs peuvent être définis sur les points de données de graphique à l'intérieur de séries particulières. Pour définir les options de marqueur de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série de graphique.
- Ajouter un nouveau point de données.
- Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini les options de marqueur de graphique au niveau des points de données.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Créer le graphique par défaut
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Obtenir l'index de la feuille de données de graphique par défaut
    defaultWorksheetIndex = 0

    # Obtenir la feuille de données de graphique
    fact = chart.chart_data.chart_data_workbook

    # Supprimer les séries de démonstration
    chart.chart_data.series.clear()

    # Ajouter de nouvelles séries
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Série 1"), chart.type)
            
    # Définir l'image
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Définir l'image
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Prendre la première série de graphique
    series = chart.chart_data.series[0]

    # Ajouter un nouveau point (1:3) là.
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

    # Changer le marqueur de la série de graphique
    series.marker.size = 15

    # Écrire la présentation sur le disque
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```