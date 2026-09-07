---
title: Diapositive
type: docs
weight: 10
url: /fr/python-java/examples/elements/slide/
keywords:
- exemple de code
- diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Gérez les diapositives dans Aspose.Slides for Python via Java : ajoutez, accédez, clonez, réorganisez et supprimez des diapositives avec des exemples de code Python pour les présentations PowerPoint et OpenDocument."
---
Cet article fournit des exemples qui démontrent comment ajouter, accéder, cloner, réorganiser et supprimer des diapositives à l'aide de **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois la JVM en cours d'exécution.

## **Ajouter une diapositive**

Pour ajouter une nouvelle diapositive, sélectionnez d'abord une disposition. Cet exemple utilise une disposition vierge pour ajouter une diapositive vide à la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Chaque disposition de diapositive est dérivée d'une diapositive maîtresse, qui définit la conception globale et la structure des espaces réservés. L'image ci-dessous illustre comment les diapositives maîtresses et leurs dispositions associées sont organisées dans PowerPoint.
{{% /alert %}}

![Relation maître et disposition](master-layout-slide.png)

## **Accéder aux diapositives par indice**

Accédez aux diapositives en utilisant leur indice basé sur zéro, ou trouvez l'indice d'une diapositive à partir d'une référence. Cela est utile pour parcourir ou modifier des diapositives spécifiques.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Ajouter une autre diapositive vide.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Accéder aux diapositives par indice.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Obtenir l'indice d'une diapositive à partir d'une référence, puis y accéder par indice.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Cloner une diapositive**

Clonez une diapositive existante. La diapositive clonée est automatiquement ajoutée à la fin de la collection de diapositives.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Réorganiser les diapositives**

Modifiez l'ordre des diapositives en en déplaçant une vers un nouvel indice. Cet exemple déplace une diapositive clonée vers la première position.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Supprimer une diapositive**

Supprimez une diapositive en transmettant sa référence à la collection de diapositives. Cet exemple ajoute une deuxième diapositive puis supprime l'originale, ne laissant que la nouvelle.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```