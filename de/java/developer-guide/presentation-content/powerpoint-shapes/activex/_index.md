---
title: ActiveX-Steuerelemente in Präsentationen in Java verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/java/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Media-Player
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Bearbeiten Sie ActiveX-Textfelder und -Schaltflächen, aktualisieren Sie Steuerelement-Vorschauen und verwenden Sie ein Windows Media Player-Steuerelement erneut in PowerPoint-Präsentationen mit Aspose.Slides für Java."
---
## **Einleitung**

ActiveX-Steuerelemente geben einer PowerPoint-Folie interaktive Elemente wie Textfelder, Schaltflächen und Mediaplayer. Aspose.Slides for Java stellt die Steuerelemente einer Folie über [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--) bereit. Verwenden Sie diese Sammlung, um ein Steuerelement zu bearbeiten, es auf der Folie zu verschieben oder zu entfernen.

## **Auflisten von ActiveX-Steuerelementen und deren gespeicherten Eigenschaften**

Um ein unbekanntes Template zu untersuchen, öffnen Sie es zum Lesen und iterieren über die Steuerelemente jeder Folie. Das Beispiel gibt die Foliennummer, den Steuerelementnamen, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), und jedes Schlüssel‑Wert‑Paar in [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) aus. Es liest die Präsentation, ohne Steuerelemente zu aktivieren, Ereignisse oder Makros auszulösen, Werte zu ändern oder die Datei zu speichern.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Die ausgewählte Ausgabe aus `ActiveX.pptm` zeigt ein Textfeld und eine Schaltfläche.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Eine leere Eigenschaftensammlung erscheint als `[]`. Für Steuerelemente, die binäre Speicherung verwenden, kann [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) `null` zurückgeben, angezeigt als `Properties unavailable`. Wenn Sie nur die Namen benötigen, verwenden Sie nach der Null‑Prüfung [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--). Der Bericht listet die aus der Präsentation verfügbaren Eigenschaften auf. Ein Steuerelement kann zur Laufzeit zusätzliche Eigenschaften unterstützen.

## **ActiveX-Steuerelemente ändern**

Das Beispiel erwartet eine makrofähige Präsentation mit einem Textfeld namens `TextBox1` und einer Schaltfläche namens `CommandButton1` auf der ersten Folie. Es verwendet die [Steuereigenschaften‑Sammlung](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) um den Wert des Textfelds und die Beschriftung der Schaltfläche zu ändern. Jedes Steuerelement hat außerdem eine statische Vorschau, die PowerPoint vor der Aktivierung anzeigen kann. Stellen Sie für jedes Steuerelement ein PNG bereit, das den aktualisierten Text und das Aussehen zeigt. Das Beispiel weist diese Bilder über [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) zu.

Das Beispiel verschiebt jedes Steuerelement auf der ersten Folie um 100 Punkte nach unten, indem es dessen Rahmen mit [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) setzt. Es speichert die bearbeitete Präsentation im PPTM-Format und verwendet anschließend [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) um eine zweite Kopie zu speichern, in der alle ActiveX‑Steuerelemente von dieser Folie entfernt wurden.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Ein ActiveX-Mediaplayer-Steuerelement hinzufügen**

Um ein konfiguriertes Windows Media Player‑Steuerelement wiederzuverwenden, beginnen Sie mit einem Template, dessen erste Folie einen Player namens `WindowsMediaPlayer1` enthält. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) kopiert die gesamte Folie in eine neue Präsentation. Das Beispiel setzt die `URL` des Players in seiner [Eigenschaften‑Sammlung](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) und speichert die geklonte Folie als einzige Folie in der Ausgabe. Das Video bleibt extern, wählen Sie also einen Pfad, auf den der Player während der Wiedergabe zugreifen kann.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**Kann Aspose.Slides ActiveX-Steuerelemente erhalten, ohne sie auszuführen?**

Ja. Aspose.Slides kann Steuerelemente lesen und speichern, einschließlich ihrer Eigenschaften und Positionen, ohne sie zu aktivieren.

**Wie unterscheiden sich ActiveX-Steuerelemente von OLE-Objekten?**

ActiveX-Steuerelemente ermöglichen dem Benutzer die Interaktion mit einer Folie, zum Beispiel durch Eingabe von Text oder Klicken einer Schaltfläche. Ein [OLE‑Objekt](/slides/de/java/manage-ole/) lässt eine Folie Inhalte enthalten oder darauf verlinken, die von einer anderen Anwendung verwaltet werden, wie ein Excel‑Arbeitsblatt.

**Werden ActiveX‑Ereignisse weiterhin VBA‑Makros auslösen, nachdem ich eine Präsentation mit Aspose.Slides gespeichert habe?**

Speichern Sie die Präsentation in einem makrofähigen Format wie PPTM, um das VBA‑Projekt beizubehalten. PowerPoint für Windows kann die vorhandenen Ereignis‑Handler ausführen, wenn die Sicherheitseinstellungen sowohl ActiveX‑Steuerelemente als auch Makros zulassen.