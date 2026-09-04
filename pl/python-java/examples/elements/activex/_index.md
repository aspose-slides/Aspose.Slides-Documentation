---
title: ActiveX
type: docs
weight: 200
url: /pl/python-java/examples/elements/activex/
keywords:
- przykład kodu
- ActiveX
- kontrolka ActiveX
- właściwości ActiveX
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides for Python via Java, aby dodawać, uzyskiwać dostęp, usuwać i konfigurować kontrolki ActiveX w prezentacjach PowerPoint, korzystając z praktycznych przykładów kodu."
---
Ten artykuł pokazuje, jak dodawać, uzyskiwać dostęp, usuwać i konfigurować kontrolki ActiveX w prezentacji przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM. Przykłady dostępu i usuwania używają `add_activex.pptm`, utworzonego przez pierwszy przykład.

## **Dodaj kontrolkę ActiveX**

Wstaw kontrolkę Windows Media Player na pierwszym slajdzie i zapisz prezentację jako plik PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kontrolkę Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do kontrolki ActiveX**

Odczytaj nazwę oraz ustawienie automatycznego odtwarzania pierwszej kontrolki ActiveX na slajdzie.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Uzyskaj dostęp do pierwszej kontrolki ActiveX.
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

## **Usuń kontrolkę ActiveX**

Usuń pierwszą kontrolkę ActiveX ze slajdu i zapisz zmodyfikowaną prezentację.

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
            # Usuń pierwszą kontrolkę ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Ustaw właściwości ActiveX**

Dodaj kontrolkę Windows Media Player, wyłącz automatyczne odtwarzanie i ukryj jej elementy sterujące odtwarzaniem. Użyj [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/pl/python-java/aspose.slides/controlpropertiescollection/#set_Item), aby przypisać wartości właściwości jako ciągi znaków.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kontrolkę Windows Media Player i skonfiguruj jej właściwości.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```