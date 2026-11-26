---
title: ActiveX‑Steuerelemente in Präsentationen mit Python verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/python-net/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Media-Player
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Bearbeiten Sie ActiveX‑Textfelder und -Schaltflächen, aktualisieren Sie Steuerelement‑Vorschauen und verwenden Sie ein Windows‑Media‑Player‑Steuerelement erneut in PowerPoint‑Präsentationen mit Aspose.Slides für Python via .NET."
---
## **Einleitung**

ActiveX‑Steuerelemente geben einer PowerPoint‑Folie interaktive Elemente wie Textfelder, Befehls­schaltflächen und Mediaplayer. Aspose.Slides for Python via .NET stellt die Steuerelemente einer Folie über [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/) bereit. Verwenden Sie diese Sammlung, um ein Steuerelement zu bearbeiten, es auf der Folie zu verschieben oder zu entfernen.

## **Auflisten von ActiveX‑Steuerelementen und deren gespeicherten Eigenschaften**

Um eine unbekannte Vorlage zu untersuchen, öffnen Sie sie zum Lesen und iterieren über die Steuerelemente jeder Folie. Das Beispiel gibt die Foliennummer, den Steuerelementnamen, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), und jedes Schlüssel‑Wert‑Paar in [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) aus. Es liest die Präsentation, ohne die Steuerelemente zu aktivieren, Ereignisse oder Makros auszulösen, Werte zu ändern oder die Datei zu speichern.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

Die ausgewählte Ausgabe von `ActiveX.pptm` zeigt ein Textfeld und eine Befehls­schaltfläche.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Eine leere Eigenschaften‑Sammlung erscheint als `[]`. Für Steuerelemente, die binäre Speicherung verwenden, kann `properties` `None` zurückgeben, angezeigt als `Properties unavailable`. Wenn Sie nur die Namen benötigen, verwenden Sie [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) nach einer Prüfung auf `None`. Der Bericht listet die aus der Präsentation verfügbaren Eigenschaften auf. Ein Steuerelement kann zur Laufzeit zusätzliche Eigenschaften unterstützen.

## **ActiveX‑Steuerelemente ändern**

Das Beispiel erwartet eine makrofähige Präsentation mit einem Textfeld namens `TextBox1` und einer Befehls­schaltfläche namens `CommandButton1` auf der ersten Folie. Es verwendet die [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/), um den Wert des Textfelds und die Beschriftung der Schaltfläche zu ändern. Jedes Steuerelement hat außerdem eine statische Vorschau, die PowerPoint vor der Aktivierung anzeigen kann. Stellen Sie für jedes Steuerelement ein PNG bereit, das den aktualisierten Text und das Erscheinungsbild zeigt. Das Beispiel weist diese Bilder über [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/) zu.

Das Beispiel verschiebt jedes Steuerelement auf der ersten Folie um 100 Punkte nach unten, indem es dessen [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/) ändert. Es speichert die bearbeitete Präsentation im PPTM‑Format und verwendet anschließend [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/), um eine zweite Kopie zu speichern, in der alle ActiveX‑Steuerelemente von dieser Folie entfernt wurden.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Ein ActiveX‑Media‑Player‑Steuerelement hinzufügen**

Um ein konfiguriertes Windows‑Media‑Player‑Steuerelement wiederzuverwenden, beginnen Sie mit einer Vorlage, deren erste Folie einen Player namens `WindowsMediaPlayer1` enthält. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) kopiert die gesamte Folie in eine neue Präsentation. Das Beispiel setzt die `URL` des Players in seiner [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) und speichert die geklonte Folie als einzige Folie in der Ausgabe. Das Video bleibt extern, wählen Sie also einen Pfad, auf den der Player während der Wiedergabe zugreifen kann.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann Aspose.Slides ActiveX‑Steuerelemente erhalten, ohne sie auszuführen?**

Ja. Aspose.Slides kann Steuerelemente lesen und speichern, einschließlich ihrer Eigenschaften und Positionen, ohne sie zu aktivieren.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten?**

ActiveX‑Steuerelemente ermöglichen es Benutzern, mit einer Folie zu interagieren, zum Beispiel indem Text eingegeben oder eine Schaltfläche geklickt wird. Ein [OLE object](/slides/de/python-net/manage-ole/) erlaubt einer Folie, Inhalte zu enthalten oder zu verlinken, die von einer anderen Anwendung verwaltet werden, beispielsweise ein Excel‑Arbeitsblatt.

**Werden ActiveX‑Ereignisse weiterhin VBA‑Makros auslösen, nachdem ich eine Präsentation mit Aspose.Slides gespeichert habe?**

Speichern Sie die Präsentation in einem makrofähigen Format wie PPTM, um ihr VBA‑Projekt zu erhalten. PowerPoint für Windows kann die vorhandenen Ereignis‑Handler ausführen, wenn die Sicherheitseinstellungen sowohl ActiveX‑Steuerelemente als auch Makros zulassen.