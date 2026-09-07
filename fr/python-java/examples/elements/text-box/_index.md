---
title: Zone de texte
type: docs
weight: 40
url: /fr/python-java/examples/elements/text-box/
keywords:
- exemple de code
- zone de texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Travailler avec les zones de texte dans Aspose.Slides pour Python via Java : ajouter, mettre en forme, rechercher et supprimer du texte dans les présentations PowerPoint et OpenDocument."
---
Dans **Aspose.Slides for Python via Java**, une zone de texte est une forme automatique qui contient du texte. Pratiquement n'importe quelle forme peut contenir du texte, mais une zone de texte typique n'a ni remplissage ni bordure et n'affiche que du texte.

Ce guide explique comment ajouter, accéder et supprimer des zones de texte programmatiquement.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API après le démarrage de la JVM.

## **Ajouter une zone de texte**

Créez un rectangle, supprimez son remplissage et sa bordure, puis affectez du texte formaté.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Créer une forme rectangulaire.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Supprimer le remplissage et la bordure pour n'afficher que le texte.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Définir le formatage de texte par défaut.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Accéder aux zones de texte par contenu**

Ajoutez une zone de texte d'exemple, puis trouvez les formes dont le texte contient le mot-clé "Slide".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Utiliser la zone de texte correspondante.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Supprimer les zones de texte par contenu**

Trouvez et supprimez les zones de texte sur la première diapositive qui contiennent un mot-clé spécifique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
Rassemblez les formes correspondantes dans une liste séparée avant de les supprimer afin d'éviter de modifier la collection de formes pendant l'itération.
{{% /alert %}}