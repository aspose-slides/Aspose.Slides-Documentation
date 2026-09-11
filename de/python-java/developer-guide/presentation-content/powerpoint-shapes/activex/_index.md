---
title: ActiveX-Steuerelemente in Präsentationen mit Python verwalten
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
- Media-Player
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python via Java ActiveX verwendet, um PowerPoint-Präsentationen zu automatisieren und zu verbessern, und Entwicklern umfassende Kontrolle über Folien bietet."
---
## **Einführung**

ActiveX‑Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für Python via Java ermöglicht das Hinzufügen und Verwalten von ActiveX‑Steuerelementen, ist jedoch im Vergleich zu normalen Präsentationsformen etwas komplizierter. Aspose.Slides unterstützt das Hinzufügen von Media‑Player‑ActiveX‑Steuerelementen. Beachten Sie, dass ActiveX‑Steuerelemente keine Formen sind; sie gehören nicht zur [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/). Sie gehören stattdessen zur separaten [ControlCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/controlcollection/). In diesem Thema zeigen wir Ihnen, wie Sie mit ihnen arbeiten.

## **Hinzufügen eines Media‑Player‑ActiveX‑Steuerelements zu einer Folie**

Um ein ActiveX‑Media‑Player‑Steuerelement hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und erzeugen Sie eine leere Präsentation.
2. Greifen Sie auf die Zielfolie in [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) zu.
3. Fügen Sie das Media‑Player‑ActiveX‑Steuerelement mit der Methode [addControl](https://reference.aspose.com/slides/de/python-java/aspose.slides/controlcollection/#addControl) hinzu, die von [ControlCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/controlcollection/) bereitgestellt wird.
4. Greifen Sie auf das Media‑Player‑ActiveX‑Steuerelement zu und setzen Sie den Videopfad über dessen Eigenschaften.
5. Speichern Sie die Präsentation als PPTX‑Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie ein Media‑Player‑ActiveX‑Steuerelement zu einer Folie hinzugefügt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Erstelle eine leere Präsentation.
presentation = Presentation()
try:
    # Füge das Media Player ActiveX-Steuerelement hinzu.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Setze den Videopfad.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Speichere die Präsentation.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ändern eines ActiveX‑Steuerelements**

{{% alert color="info" title="Hinweis" %}}

Aspose.Slides für Python via Java stellt Komponenten zum Verwalten von ActiveX‑Steuerelementen bereit. Sie können das bereits hinzugefügte ActiveX‑Steuerelement in Ihrer Präsentation abrufen und über dessen Eigenschaften ändern oder löschen.

{{% /alert %}}

Um ein einfaches ActiveX‑Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation mit ActiveX‑Steuerelementen.
2. Holen Sie sich eine Folienreferenz anhand ihres Index.
3. Greifen Sie auf die ActiveX‑Steuerelemente in der Folie zu, indem Sie die [ControlCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/controlcollection/) verwenden.
4. Greifen Sie mit dem [Control](https://reference.aspose.com/slides/de/python-java/aspose.slides/control/)‑Objekt auf das ActiveX‑Steuerelement TextBox1 zu.
5. Ändern Sie die Eigenschaften des ActiveX‑Steuerelements TextBox1, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.
6. Greifen Sie auf das zweite ActiveX‑Steuerelement namens CommandButton1 zu.
7. Ändern Sie die Beschriftung, Schriftart und Position der Schaltfläche.
8. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.
9. Schreiben Sie die geänderte Präsentation in eine PPTM‑Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie ein einfaches ActiveX‑Steuerelement verwaltet wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Laden Sie die Präsentation mit ActiveX-Steuerelementen.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Greifen Sie auf die erste Folie zu.
        slide = presentation.getSlides().get_Item(0)

        # Ändern Sie den Text des Textfelds.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Ändern Sie das Ersatzbild. PowerPoint ersetzt es während der ActiveX-Aktivierung,
            # sodass es manchmal unverändert bleiben kann.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Ändern Sie die Beschriftung der Schaltfläche.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Ändern Sie das Ersatzbild.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Verschieben Sie die Steuerelemente um 100 Punkte nach unten.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Entfernen Sie die Steuerelemente.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **FAQ**

**Behält Aspose.Slides ActiveX‑Steuerelemente bei, wenn sie beim Lesen und erneuten Speichern nicht in der Python‑Laufzeit ausgeführt werden können?**

Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann deren Eigenschaften und Rahmen lesen/ändern; die Ausführung der Steuerelemente selbst ist zum Erhalt nicht erforderlich.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten in einer Präsentation?**

ActiveX‑Steuerelemente sind interaktive verwaltete Steuerelemente (Schaltflächen, Textfelder, Media‑Player), während [OLE](/slides/de/python-java/manage-ole/) sich auf eingebettete Anwendungsobjekte (z. B. ein Excel‑Arbeitsblatt) bezieht. Sie werden anders gespeichert und behandelt und besitzen unterschiedliche Eigenschaftsmodelle.

**Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?**

Aspose.Slides bewahrt das vorhandene Markup und die Metadaten; Ereignisse und Makros werden jedoch nur in PowerPoint unter Windows ausgeführt, wenn die Sicherheit dies zulässt. Die Bibliothek führt kein VBA aus.