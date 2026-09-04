---
title: Note
type: docs
weight: 240
url: /fr/python-java/examples/elements/note/
keywords:
- exemple de code
- note
- note du présentateur
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Travaillez avec les notes de diapositive dans Aspose.Slides pour Python via Java : ajoutez, lisez, supprimez et mettez à jour les notes du présentateur dans les présentations PowerPoint et OpenDocument."
---
Cet article montre comment ajouter, lire, supprimer et mettre à jour les diapositives de notes en utilisant **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois que la JVM est en cours d'exécution.

## **Ajouter une diapositive de notes**

Créez une diapositive de notes et attribuez‑lui du texte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Accéder à une diapositive de notes**

Lisez le texte d'une diapositive de notes existante.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Supprimer une diapositive de notes**

Supprimez la diapositive de notes associée à une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Mettre à jour le texte des notes**

Modifiez le texte d'une diapositive de notes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```