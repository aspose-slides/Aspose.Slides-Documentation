---
title: SmartArt
type: docs
weight: 140
url: /fr/python-java/examples/elements/smart-art/
keywords:
- exemple de code
- SmartArt
- ajouter SmartArt
- accéder à SmartArt
- supprimer SmartArt
- disposition SmartArt
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Travaillez avec SmartArt dans Aspose.Slides pour Python via Java : ajoutez, accédez, supprimez et modifiez les dispositions des diagrammes dans les présentations PowerPoint et OpenDocument."
---
Cet article montre comment ajouter des graphiques SmartArt, y accéder, les supprimer et modifier les dispositions en utilisant **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API après le démarrage de la JVM.

## **Ajouter SmartArt**

Insérez un graphique SmartArt en utilisant l'une des dispositions intégrées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Accéder à SmartArt**

Récupérez le premier objet SmartArt d'une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Supprimer SmartArt**

Supprimez une forme SmartArt de la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Modifier la disposition SmartArt**

Mettez à jour le type de disposition d'un graphique SmartArt existant.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```