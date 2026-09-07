---
title: Transition de diapositive
type: docs
weight: 110
url: /fr/python-java/examples/elements/slide-transition/
keywords:
- exemple de code
- transition de diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Appliquer et supprimer les transitions de diapositive et définir les temporisations d'avance automatique des diapositives avec des exemples de code Aspose.Slides pour Python via Java pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment appliquer des effets de transition de diapositive et des timings avec **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois que la JVM est en cours d'exécution.

## **Ajouter une transition de diapositive**

Appliquez un effet de transition de fondu à la première diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Appliquer une transition de fondu.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Accéder à une transition de diapositive**

Lisez le type de transition actuellement assigné à une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Accéder au type de transition.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Supprimer une transition de diapositive**

Supprimez tout effet de transition. JPype expose la constante Java nommée `None` sous le nom `None_` parce que `None` est un mot réservé en Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Supprimer l'effet de transition.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Définir la durée de la transition**

Spécifiez la durée d'affichage de la diapositive avant de passer automatiquement à la suivante. Cet exemple passe à la diapositive suivante après deux secondes et permet également de passer avec un clic de souris. Ce réglage contrôle le passage de la diapositive, pas la vitesse de l'effet de transition.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # En millisecondes.
finally:
    presentation.dispose()
```