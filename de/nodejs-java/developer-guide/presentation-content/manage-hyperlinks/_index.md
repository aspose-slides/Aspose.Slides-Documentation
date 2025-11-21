---
title: Hyperlinks verwalten
type: docs
weight: 20
url: /de/nodejs-java/manage-hyperlinks/
keywords: "PowerPoint-Hyperlink, Text-Hyperlink, Folien-Hyperlink, Formen-Hyperlink, Bild-Hyperlink, Video-Hyperlink, Java"
description: "Wie man in JavaScript einen Hyperlink zu einer PowerPoint-Präsentation hinzufügt"
---

Ein Hyperlink ist eine Referenz zu einem Objekt, Daten oder einem Ort in etwas. Dies sind gängige Hyperlinks in PowerPoint‑Präsentationen:

* Links zu Websites in Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, viele Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen auszuführen.

{{% alert color="primary" %}} 
Vielleicht möchten Sie sich Aspose Simple, [kostenlosen Online‑PowerPoint‑Editor.](https://products.aspose.app/slides/editor) ansehen.
{{% /alert %}} 

## **Hinzufügen von URL‑Hyperlinks**

### **Hinzufügen von URL‑Hyperlinks zu Texten**

Dieser JavaScript‑Code zeigt, wie Sie einem Text einen Website‑Hyperlink hinzufügen:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **Hinzufügen von URL‑Hyperlinks zu Formen oder Rahmen**

Dieser Beispielcode in JavaScript zeigt, wie Sie einer Form einen Website‑Hyperlink hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Hinzufügen von URL‑Hyperlinks zu Medien**

Aspose.Slides ermöglicht das Hinzufügen von Hyperlinks zu Bild‑, Audio‑ und Videodateien. 

Dieser Beispielcode zeigt, wie Sie einem **Bild** einen Hyperlink hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt ein Bild zur Präsentation hinzu
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Erstellt einen Bildrahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Dieser Beispielcode zeigt, wie Sie einer **Audiodatei** einen Hyperlink hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Dieser Beispielcode zeigt, wie Sie einem **Video** einen Hyperlink hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert  title="Tip"  color="primary"  %}} 
Vielleicht möchten Sie *[OLE verwalten](/slides/de/nodejs-java/manage-ole/)* sehen.
{{% /alert %}}

## **Verwendung von Hyperlinks zum Erstellen eines Inhaltsverzeichnisses**

Da Hyperlinks es ermöglichen, Referenzen zu Objekten oder Orten hinzuzufügen, können Sie sie zum Erstellen eines Inhaltsverzeichnisses verwenden.

Dieser Beispielcode zeigt, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Formatieren von Hyperlinks**

### **Farbe**

Mit der Methode [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) in der Klasse [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) können Sie die Farbe für Hyperlinks festlegen und auch die Farbinformation von Hyperlinks abrufen. Die Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen an der Eigenschaft nicht für ältere PowerPoint‑Versionen gelten.

Dieser Beispielcode demonstriert einen Vorgang, bei dem Hyperlinks mit unterschiedlichen Farben zur selben Folie hinzugefügt wurden:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Entfernen von Hyperlinks in Präsentationen**

### **Entfernen von Hyperlinks aus Texten**

Dieser JavaScript‑Code zeigt, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Überprüft, ob das Shape einen Textrahmen unterstützt (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Iteriert über Absätze im Textrahmen
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Iteriert über jeden Abschnitt im Absatz
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Ändert Text
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Ändert Formatierung
                    }
                }
            }
        }
    }
    // Speichert die geänderte Präsentation
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Entfernen von Hyperlinks aus Formen oder Rahmen**

Dieser JavaScript‑Code zeigt, wie Sie den Hyperlink aus einer Form in einer Präsentationsfolie entfernen:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Veränderbarer Hyperlink**

Die Klasse [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) ist veränderbar. Mit dieser Klasse können Sie die Werte für die folgenden Eigenschaften ändern:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Das Code‑Snippet zeigt, wie Sie einer Folie einen Hyperlink hinzufügen und dessen Tooltip später bearbeiten:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) aus einer Präsentation, Folie oder einem Text, für den der Hyperlink definiert ist, abrufen.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

Die Klasse [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) unterstützt diese Methoden und Eigenschaften:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Wie kann ich eine interne Navigation nicht nur zu einer Folie, sondern zu einem „Abschnitt“ oder zur ersten Folie eines Abschnitts erstellen?**

Abschnitte in PowerPoint sind Gruppierungen von Folien; die Navigation zielt technisch auf eine bestimmte Folie. Um „zu einem Abschnitt zu navigieren“, verlinken Sie in der Regel zu dessen erster Folie.

**Kann ich einen Hyperlink an Elementen der Masterfolie anhängen, sodass er auf allen Folien funktioniert?**

Ja. Master‑Folien‑ und Layout‑Elemente unterstützen Hyperlinks. Diese Links erscheinen auf den Unterfolien und sind während der Bildschirmpräsentation anklickbar.

**Werden Hyperlinks beim Exportieren zu PDF, HTML, Bildern oder Video erhalten bleiben?**

In [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/) und [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/) ja – Links werden im Allgemeinen beibehalten. Beim Exportieren zu [Bildern](/slides/de/nodejs-java/convert-powerpoint-to-png/) und [Video](/slides/de/nodejs-java/convert-powerpoint-to-video/) bleibt die Anklickbarkeit nicht erhalten, da diese Formate (Raster‑Frames/Video) keine Hyperlinks unterstützen.