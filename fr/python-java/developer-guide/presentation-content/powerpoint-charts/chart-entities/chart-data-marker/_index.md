---
title: Gérer les repères de données de graphique dans les présentations avec Python
linktitle: Repère de données
type: docs
url: /fr/python-java/chart-data-marker/
keywords:
- graphique
- point de donnée
- repère
- options de repère
- taille du repère
- type de remplissage
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à personnaliser les repères de données des graphiques dans Aspose.Slides pour Python via Java, renforçant l'impact des présentations aux formats PPT et PPTX avec des exemples de code Python clairs."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les repères de données de graphiques dans Aspose.Slides. Il montre comment créer un graphique, accéder à une série et à ses points de données, appliquer des remplissages d'image aux repères au niveau du point de données, ajuster la taille des repères et enregistrer la présentation mise à jour. Il indique également que les formes de repères standard sont disponibles via l'énumération [MarkerStyleType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markerstyletype/) et que l'apparence des repères est conservée lors de l'exportation des graphiques vers des formats raster ou SVG.

## **Définir les options de repère de graphique**
Les repères peuvent être définis sur les points de données d'un graphique au sein d'une série particulière. Pour définir les options de repère du graphique, suivez les étapes suivantes :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Créer le graphique par défaut.
- Définir les images.
- Accéder à la première série du graphique.
- Ajouter de nouveaux points de données.
- Écrire la présentation sur le disque.

L'exemple suivant définit les options de repère du graphique au niveau du point de données.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Créer une présentation vide.
presentation = Presentation()
try:
    # Accéder à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Créer le graphique par défaut
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Obtenir l'index de la feuille de calcul de données du graphique par défaut.
    default_worksheet_index = 0

    # Obtenir le classeur de données du graphique.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Supprimer la série de démonstration
    chart.getChartData().getSeries().clear()

    # Ajouter une nouvelle série
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Charger la première image.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Charger la deuxième image.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Accéder à la première série du graphique.
    series = chart.getChartData().getSeries().get_Item(0)

    # Ajouter des points de données.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Modifier la taille du repère de la série du graphique.
    series.getMarker().setSize(15)

    # Enregistrer la présentation avec le graphique
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quelles formes de repère sont disponibles prêtes à l'emploi ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par la classe [MarkerStyleType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markerstyletype/). Si vous avez besoin d’une forme non standard, utilisez un repère avec un remplissage d’image pour reproduire des visuels personnalisés.

**Les repères sont-ils conservés lors de l'exportation d'un graphique vers une image ou un SVG ?**

Oui. Lors du rendu des graphiques vers des [formats raster](/slides/fr/python-java/convert-powerpoint-to-png/) ou de l'enregistrement des [formes en SVG](/slides/fr/python-java/render-a-slide-as-an-svg-image/), les repères conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.