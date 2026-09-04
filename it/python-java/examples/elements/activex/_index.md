---
title: ActiveX
type: docs
weight: 200
url: /it/python-java/examples/elements/activex/
keywords:
- esempio di codice
- ActiveX
- controllo ActiveX
- proprietà ActiveX
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Utilizza Aspose.Slides per Python tramite Java per aggiungere, accedere, rimuovere e configurare i controlli ActiveX nelle presentazioni PowerPoint con esempi pratici di codice."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e configurare i controlli ActiveX in una presentazione utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, poi importa l'API dopo che la JVM è in esecuzione. Gli esempi di accesso e rimozione utilizzano `add_activex.pptm`, creato dal primo esempio.

## **Aggiungere un controllo ActiveX**

Inserisci un controllo Windows Media Player nella prima diapositiva e salva la presentazione come file PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un controllo Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Accedere a un controllo ActiveX**

Leggi il nome e l'impostazione di riproduzione automatica del primo controllo ActiveX nella diapositiva.

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
            # Accedi al primo controllo ActiveX.
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

## **Rimuovere un controllo ActiveX**

Elimina il primo controllo ActiveX dalla diapositiva e salva la presentazione modificata.

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
            # Rimuovi il primo controllo ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Impostare le proprietà ActiveX**

Aggiungi un controllo Windows Media Player, disabilita la riproduzione automatica e nascondi i controlli di riproduzione. Usa [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/it/python-java/aspose.slides/controlpropertiescollection/#set_Item) per assegnare i valori delle proprietà come stringhe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpace.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un controllo Windows Media Player e configura le sue proprietà.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```