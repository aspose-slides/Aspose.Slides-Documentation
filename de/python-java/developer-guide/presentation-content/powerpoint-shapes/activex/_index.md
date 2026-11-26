---
title: Verwalten von ActiveX-Steuerelementen in Präsentationen mit Python
linktitle: ActiveX
type: docs
weight: 80
url: /de/python-java/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Mediaplayer
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Bearbeiten Sie ActiveX-Textfelder und -Schaltflächen, aktualisieren Sie Steuerelement‑Vorschauen und verwenden Sie ein Windows Media Player‑Steuerelement erneut in PowerPoint‑Präsentationen mit Aspose.Slides für Python via Java."
---
## **Einleitung**

ActiveX-Steuerelemente geben einer PowerPoint-Folie interaktive Elemente wie Textfelder, Befehls‑Schaltflächen und Mediaplayer. Aspose.Slides für Python via Java stellt die Steuerelemente einer Folie über [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) bereit. Verwenden Sie diese Sammlung, um ein Steuerelement zu bearbeiten, es auf der Folie zu verschieben oder zu entfernen.

## **Auflisten von ActiveX-Steuerelementen und deren gespeicherten Eigenschaften**

Um eine unbekannte Vorlage zu untersuchen, öffnen Sie sie zum Lesen und iterieren über die Steuerelemente jeder Folie. Das Beispiel gibt die Folien‑Nummer, den Steuerelementnamen, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) und jedes Schlüssel‑Wert‑Paar in [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) aus. Es liest die Präsentation, ohne Steuerelemente zu aktivieren, Ereignisse oder Makros auszulösen, Werte zu ändern oder die Datei zu speichern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

Die ausgewählte Ausgabe von `ActiveX.pptm` zeigt ein Textfeld und eine Befehls‑Schaltfläche.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Eine leere Eigenschaftssammlung erscheint als `[]`. Für Steuerelemente, die binäre Speicherung verwenden, kann [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) `None` zurückgeben, angezeigt als `Properties unavailable`. Wenn Sie nur die Namen benötigen, verwenden Sie [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties), nachdem Sie überprüft haben, dass die Sammlung verfügbar ist. Der Bericht listet die aus der Präsentation verfügbaren Eigenschaften auf. Ein Steuerelement kann zur Laufzeit zusätzliche Eigenschaften unterstützen.

## **ActiveX-Steuerelemente ändern**

Das Beispiel erwartet eine makrofähige Präsentation mit einem Textfeld namens `TextBox1` und einer Befehls‑Schaltfläche namens `CommandButton1` auf der ersten Folie. Es verwendet die [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/), um den Textfeldwert und die Beschriftung der Schaltfläche zu ändern. Jedes Steuerelement hat außerdem eine statische Vorschau, die PowerPoint vor der Aktivierung anzeigen kann. Stellen Sie für jedes Steuerelement ein PNG bereit, das den aktualisierten Text und das Aussehen zeigt. Das Beispiel weist diese Bilder über [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) zu.

Das Beispiel verschiebt jedes Steuerelement auf der ersten Folie um 100 Punkte nach unten, indem es dessen Rahmen mit [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame) setzt. Es speichert die bearbeitete Präsentation im PPTM‑Format und verwendet dann [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear), um eine zweite Kopie zu speichern, bei der alle ActiveX-Steuerelemente von dieser Folie entfernt wurden.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Ein ActiveX-Mediaplayer-Steuerelement hinzufügen**

Um ein konfiguriertes Windows Media Player‑Steuerelement wiederzuverwenden, beginnen Sie mit einer Vorlage, deren erste Folie einen Player namens `WindowsMediaPlayer1` enthält. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) kopiert die gesamte Folie in eine neue Präsentation. Das Beispiel setzt die `URL` des Players in seiner [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) und speichert die geklonte Folie als einzige Folie in der Ausgabe. Das Video bleibt extern, wählen Sie also einen Pfad, auf den der Player während der Wiedergabe zugreifen kann.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Kann Aspose.Slides ActiveX-Steuerelemente erhalten, ohne sie auszuführen?**

Ja. Aspose.Slides kann Steuerelemente lesen und speichern, einschließlich ihrer Eigenschaften und Positionen, ohne sie zu aktivieren.

**Wie unterscheiden sich ActiveX-Steuerelemente von OLE-Objekten?**

ActiveX-Steuerelemente ermöglichen es Benutzern, mit einer Folie zu interagieren, zum Beispiel Text einzugeben oder eine Schaltfläche zu klicken. Ein [OLE-Objekt](/slides/de/python-java/manage-ole/) lässt eine Folie Inhalt enthalten oder darauf verlinken, der von einer anderen Anwendung verwaltet wird, etwa ein Excel‑Arbeitsblatt.

**Wird ActiveX-Ereignisse weiterhin VBA-Makros auslösen, nachdem ich eine Präsentation mit Aspose.Slides gespeichert habe?**

Speichern Sie die Präsentation in einem makrofähigen Format wie PPTM, um ihr VBA‑Projekt beizubehalten. PowerPoint für Windows kann die vorhandenen Ereignis‑Handler ausführen, wenn die Sicherheitseinstellungen sowohl ActiveX‑Steuerelemente als auch Makros zulassen.