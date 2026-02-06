---
title: Graphique
type: docs
weight: 60
url: /fr/python-net/examples/elements/chart/
keywords:
- graphique
- ajouter un graphique
- accéder à un graphique
- supprimer un graphique
- mettre à jour le graphique
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Créez et personnalisez des graphiques en Python avec Aspose.Slides : ajoutez des données, formattez les séries, les axes et les libellés, changez les types et exportez — fonctionne avec PPT, PPTX et ODP."
---
Exemples d'ajout, d'accès, de suppression et de mise à jour de différents types de graphiques avec **Aspose.Slides for Python via .NET**. Les extraits ci-dessous démontrent les opérations de base sur les graphiques.

## **Ajouter un graphique**

Cette méthode ajoute un graphique en aires simple à la première diapositive.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ajouter un graphique en colonnes simple à la première diapositive.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un graphique**

Le code suivant récupère un graphique de la collection de formes.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Accéder au premier graphique sur la diapositive.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Supprimer un graphique**

Le code suivant supprime un graphique d'une diapositive.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # En supposant que la première forme est un graphique.
        chart = slide.shapes[0]

        # Supprimer le graphique.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mettre à jour les données du graphique**

Vous pouvez modifier les propriétés du graphique, comme le titre.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # En supposant que la première forme est un graphique.
        chart = slide.shapes[0]

        # Modifier le titre du graphique.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```