---
title: Connecteur
type: docs
weight: 190
url: /fr/python-java/examples/elements/connector/
keywords:
- exemple de code
- connecteur
- ajouter un connecteur
- accéder au connecteur
- supprimer le connecteur
- reconnecter les formes
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez comment ajouter, accéder, supprimer et reconnecter des formes avec des connecteurs en utilisant Aspose.Slides pour Python via Java dans les présentations PPT, PPTX et ODP."
---
Cet article montre comment connecter des formes avec des connecteurs et modifier leurs cibles en utilisant **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois la JVM en cours d'exécution.

## **Ajouter un connecteur**

Insérez une forme de connecteur entre deux points de la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **Accéder à un connecteur**

Récupérez la première forme de connecteur ajoutée à une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # Accéder au premier connecteur sur la diapositive.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Supprimer un connecteur**

Supprimez un connecteur de la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **Reconnecter les formes**

Attachez un connecteur à deux formes en assignant les cibles de départ et d'arrivée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```