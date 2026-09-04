---
title: ActiveX
type: docs
weight: 200
url: /de/python-java/examples/elements/activex/
keywords:
- Codebeispiel
- ActiveX
- ActiveX-Steuerelement
- ActiveX-Eigenschaften
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python via Java, um ActiveX-Steuerelemente in PowerPoint-Präsentationen hinzuzufügen, darauf zuzugreifen, sie zu entfernen und zu konfigurieren, mit praktischen Codebeispielen."
---
Dieser Artikel demonstriert, wie man ActiveX-Steuerelemente in einer Präsentation hinzufügt, darauf zugreift, sie entfernt und konfiguriert, wobei **Aspose.Slides for Python via Java** verwendet wird.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jede Beispiel importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API, nachdem die JVM läuft. Die Zugriffs- und Entfernungsbeispiele verwenden `add_activex.pptm`, das vom ersten Beispiel erstellt wurde.

## **ActiveX-Steuerelement hinzufügen**

Fügen Sie ein Windows Media Player-Steuerelement auf der ersten Folie ein und speichern Sie die Präsentation als PPTM-Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player-Steuerelement hinzufügen.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Zugriff auf ein ActiveX-Steuerelement**

Lesen Sie den Namen und die Einstellung für die automatische Wiedergabe des ersten ActiveX-Steuerelements auf der Folie.

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
            # Auf das erste ActiveX-Steuerelement zugreifen.
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

## **ActiveX-Steuerelement entfernen**

Löschen Sie das erste ActiveX-Steuerelement von der Folie und speichern Sie die geänderte Präsentation.

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
            # Das erste ActiveX-Steuerelement entfernen.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX-Eigenschaften festlegen**

Fügen Sie ein Windows Media Player-Steuerelement hinzu, deaktivieren Sie die automatische Wiedergabe und verbergen Sie dessen Wiedergabesteuerungen. Verwenden Sie [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/de/python-java/aspose.slides/controlpropertiescollection/#set_Item), um Eigenschaftswerte als Zeichenketten zuzuweisen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player-Steuerelement hinzufügen und seine Eigenschaften konfigurieren.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```