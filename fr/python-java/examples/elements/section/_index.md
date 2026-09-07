---
title: Section
type: docs
weight: 90
url: /fr/python-java/examples/elements/section/
keywords:
- exemple de code
- section
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Gestion des sections de présentation dans Aspose.Slides for Python via Java: ajouter, accéder, supprimer et renommer les sections avec des exemples de code Python."
---
Exemples de gestion des sections de présentation—ajouter, accéder, supprimer et renommer programmaticalement en utilisant **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l’API après le démarrage de la JVM.

## **Ajouter une section**

Créez une section qui commence à une diapositive spécifique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Spécifiez la diapositive qui marque le début de la section.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Accéder à une section**

Lisez les informations de section d’une présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Accéder à une section par indice.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Supprimer une section**

Supprimez une section précédemment ajoutée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Supprimer la première section.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Renommer une section**

Modifiez le nom d’une section existante.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```