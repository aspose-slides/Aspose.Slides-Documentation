---
title: ActiveX-Steuerelemente in Präsentationen mit JavaScript verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Mediaplayer
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "ActiveX-Textfelder und -Schaltflächen bearbeiten, Steuerelement-Vorschauen aktualisieren und ein Windows Media Player-Steuerelement in PowerPoint-Präsentationen mit Aspose.Slides für Node.js über Java wiederverwenden."
---
## **Einleitung**

ActiveX‑Steuerelemente verleihen einer PowerPoint‑Folie interaktive Elemente wie Textfelder, Befehls‑schaltflächen und Mediaplayer. Aspose.Slides für Node.js über Java stellt die Steuerelemente einer Folie über [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) bereit. Verwenden Sie diese Sammlung, um ein Steuerelement zu bearbeiten, es auf der Folie zu verschieben oder zu entfernen.

## **Auflisten von ActiveX-Steuerelementen und deren gespeicherten Eigenschaften**

Um eine unbekannte Vorlage zu untersuchen, öffnen Sie sie zum Lesen und iterieren über die Steuerelemente jeder Folie. Das Beispiel gibt die Folienzahl, den Namen des Steuerelements, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) und jedes Schlüssel‑Wert‑Paar in [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) aus. Es liest die Präsentation, ohne Steuerelemente zu aktivieren, Ereignisse oder Makros auszulösen, Werte zu ändern oder die Datei zu speichern.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Die ausgewählte Ausgabe von `ActiveX.pptm` zeigt ein Textfeld und eine Befehls‑schaltfläche.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Eine leere Eigenschaftssammlung erscheint als `[]`. Bei Steuerelementen, die binäre Speicherung verwenden, kann [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) `null` zurückgeben, dargestellt als `Properties unavailable`. Wenn Sie nur die Namen benötigen, verwenden Sie nach der Null‑Prüfung [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties). Der Bericht listet die aus der Präsentation verfügbaren Eigenschaften auf. Ein Steuerelement kann zur Laufzeit zusätzliche Eigenschaften unterstützen.

## **ActiveX-Steuerelemente ändern**

Das Beispiel erwartet eine makrofähige Präsentation mit einem Textfeld namens `TextBox1` und einer Befehls‑schaltfläche namens `CommandButton1` auf der ersten Folie. Es verwendet die [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) , um den Wert des Textfelds und die Beschriftung der Schaltfläche zu ändern. Jedes Steuerelement verfügt außerdem über eine statische Vorschau, die PowerPoint vor der Aktivierung anzeigen kann. Stellen Sie für jedes Steuerelement ein PNG bereit, das den aktualisierten Text und das Erscheinungsbild zeigt. Das Beispiel weist diese Bilder über [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) zu.

Das Beispiel verschiebt jedes Steuerelement auf der ersten Folie um 100 Punkte nach unten, indem es den Rahmen mit [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) setzt. Es speichert die bearbeitete Präsentation im PPTM‑Format und verwendet anschließend [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear), um eine zweite Kopie zu speichern, aus der alle ActiveX‑Steuerelemente von dieser Folie entfernt wurden.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```
## **Ein ActiveX-Media-Player-Steuerelement hinzufügen**

Um ein konfiguriertes Windows‑Media‑Player‑Steuerelement wiederzuverwenden, beginnen Sie mit einer Vorlage, deren erste Folie einen Player namens `WindowsMediaPlayer1` enthält. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) kopiert die gesamte Folie in eine neue Präsentation. Das Beispiel setzt die `URL` des Players in seiner [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) und speichert die geklonte Folie als einzige Folie in der Ausgabe. Das Video bleibt extern, wählen Sie daher einen Pfad, auf den der Player während der Wiedergabe zugreifen kann.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```
## **FAQ**

**Kann Aspose.Slides ActiveX‑Steuerelemente erhalten, ohne sie auszuführen?**

Ja. Aspose.Slides kann Steuerelemente lesen und speichern, einschließlich ihrer Eigenschaften und Positionen, ohne sie zu aktivieren.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten?**

ActiveX‑Steuerelemente ermöglichen es Benutzern, mit einer Folie zu interagieren, beispielsweise durch Eingabe von Text oder Klicken einer Schaltfläche. Ein [OLE object](/slides/de/nodejs-java/manage-ole/) ermöglicht, dass eine Folie Inhalte, die von einer anderen Anwendung verwaltet werden, wie ein Excel‑Arbeitsblatt, enthalten oder darauf verlinken kann.

**Werden ActiveX‑Ereignisse nach dem Speichern einer Präsentation mit Aspose.Slides weiterhin VBA‑Makros auslösen?**

Speichern Sie die Präsentation in einem makrofähigen Format wie PPTM, um ihr VBA‑Projekt zu erhalten. PowerPoint für Windows kann die vorhandenen Ereignis‑Handler ausführen, wenn die Sicherheitseinstellungen sowohl ActiveX‑Steuerelemente als auch Makros zulassen.