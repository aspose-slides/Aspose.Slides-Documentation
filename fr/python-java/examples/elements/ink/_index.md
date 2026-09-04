---
title: Encre
type: docs
weight: 180
url: /fr/python-java/examples/elements/ink/
keywords:
- exemple de code
- encre
- accéder à l'encre
- supprimer l'encre
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Accédez aux formes d'encre et supprimez l'encre dans les présentations Aspose.Slides pour Python via Java, y compris les fichiers PPT, PPTX et ODP."
---
Cet article fournit des exemples d'accès aux formes d'encre existantes et de leur suppression à l'aide d'**Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois la JVM en cours d'exécution.

{{% alert color="info" title="Note" %}}
Les formes d'encre représentent les entrées utilisateur provenant de dispositifs spécialisés. Aspose.Slides ne peut pas créer de nouveaux traits d'encre de manière programmatique, mais vous pouvez lire et modifier l'encre existante.
{{% /alert %}}

## **Accéder à l'encre**

Lisez les balises de la première forme d'encre sur une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Utilisez tag_name selon les besoins.
finally:
    presentation.dispose()
```

## **Supprimer l'encre**

Supprimez une forme d'encre de la diapositive si elle existe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```