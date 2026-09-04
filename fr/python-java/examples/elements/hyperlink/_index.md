---
title: Hyperlien
type: docs
weight: 130
url: /fr/python-java/examples/elements/hyperlink/
keywords:
- exemple de code
- hyperlien
- ajouter un hyperlien
- accéder à un hyperlien
- supprimer un hyperlien
- mettre à jour un hyperlien
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Ajouter et gérer des hyperliens dans Aspose.Slides pour Python via Java : créer, accéder, supprimer et mettre à jour des liens dans les présentations PPT, PPTX et ODP."
---
Cet article montre comment ajouter, accéder, supprimer et mettre à jour des hyperliens sur des formes à l'aide de **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois que la JVM est en cours d'exécution.

## **Ajouter un hyperlien**

Créez une forme rectangulaire avec un hyperlien pointant vers un site web externe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Accéder à un hyperlien**

Lisez les informations d'hyperlien à partir d'une portion de texte d'une forme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Supprimer un hyperlien**

Supprimez l'hyperlien du texte d'une forme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Mettre à jour un hyperlien**

Modifiez la cible d'un hyperlien existant. Utilisez [HyperlinkManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkmanager/) pour modifier le texte contenant déjà un hyperlien, ce qui reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # Modifier un hyperlien dans du texte existant doit être fait via
    # HyperlinkManager plutôt que de définir directement la propriété.
    # Cela imite la façon dont PowerPoint met à jour les hyperliens en toute sécurité.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```