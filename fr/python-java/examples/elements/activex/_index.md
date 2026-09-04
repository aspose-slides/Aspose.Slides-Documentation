---
title: ActiveX
type: docs
weight: 200
url: /fr/python-java/examples/elements/activex/
keywords:
- exemple de code
- ActiveX
- contrôle ActiveX
- propriétés ActiveX
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Utilisez Aspose.Slides for Python via Java pour ajouter, accéder, supprimer et configurer des contrôles ActiveX dans des présentations PowerPoint avec des exemples de code pratiques."
---
Cet article montre comment ajouter, accéder, supprimer et configurer des contrôles ActiveX dans une présentation en utilisant **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois la JVM en cours d'exécution. Les exemples d'accès et de suppression utilisent `add_activex.pptm`, créé par le premier exemple.

## **Ajouter un contrôle ActiveX**

Insérez un contrôle Windows Media Player sur la première diapositive et enregistrez la présentation au format PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter un contrôle Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Accéder à un contrôle ActiveX**

Lisez le nom et le paramètre de lecture automatique du premier contrôle ActiveX sur la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Accéder au premier contrôle ActiveX.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **Supprimer un contrôle ActiveX**

Supprimez le premier contrôle ActiveX de la diapositive et enregistrez la présentation modifiée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Supprimer le premier contrôle ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Définir les propriétés ActiveX**

Ajoutez un contrôle Windows Media Player, désactivez la lecture automatique et masquez ses contrôles de lecture. Utilisez [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/fr/python-java/aspose.slides/controlpropertiescollection/#set_Item) pour attribuer des valeurs de propriétés sous forme de chaînes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter un contrôle Windows Media Player et configurer ses propriétés.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```