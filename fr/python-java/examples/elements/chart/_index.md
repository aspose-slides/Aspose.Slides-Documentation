---
title: Graphique
type: docs
weight: 60
url: /fr/python-java/examples/elements/chart/
keywords:
- graphique
- ajouter un graphique
- accéder à un graphique
- supprimer un graphique
- mettre à jour un graphique
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer, accéder, supprimer et mettre à jour des graphiques dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java."
---
Cet article montre comment ajouter, accéder, supprimer et mettre à jour des graphiques dans une présentation en utilisant **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API après le démarrage de la JVM. Exécutez d'abord l'exemple d'ajout pour créer `chart.pptx` pour les exemples suivants.

## **Ajouter un graphique**

Ajoutez un graphique en aires à la première diapositive et enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter un graphique en aires à la première diapositive.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accéder à un graphique**

Trouvez le premier graphique dans la collection de formes de la première diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Accéder au premier graphique sur la diapositive.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Supprimer un graphique**

Supprimez le premier graphique de la diapositive et enregistrez la présentation modifiée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Trouver et supprimer le premier graphique sur la diapositive.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mettre à jour les données du graphique**

Affichez le titre du graphique, modifiez son texte, et enregistrez la présentation mise à jour.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Trouver le premier graphique sur la diapositive.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Afficher le titre du graphique et modifier son texte.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```