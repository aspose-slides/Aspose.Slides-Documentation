---
title: En-tête et pied de page
type: docs
weight: 220
url: /fr/python-java/examples/elements/header-footer/
keywords:
- exemple de code
- en-tête
- pied de page
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Contrôlez les en-têtes et pieds de page des diapositives avec Aspose.Slides for Python via Java : ajoutez des dates, des numéros de diapositive et du texte personnalisé dans les présentations PPT, PPTX et ODP."
---
Cet article montre comment ajouter des pieds de page et mettre à jour les espaces réservés de date et d'heure à l'aide de **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois que la JVM est en cours d'exécution.

## **Ajouter un pied de page**

Ajoutez du texte à la zone de pied de page d'une diapositive et rendez-le visible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Mettre à jour la date et l'heure**

Modifiez l'espace réservé de date et d'heure sur une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```