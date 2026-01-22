---
title: Erweiterte Textextraktion aus Präsentationen in JavaScript
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/nodejs-java/extract-text-from-presentation/
keywords:
- Text extrahieren
- Text aus Folie extrahieren
- Text aus Präsentation extrahieren
- Text aus PowerPoint extrahieren
- Text aus OpenDocument extrahieren
- Text aus PPT extrahieren
- Text aus PPTX extrahieren
- Text aus ODP extrahieren
- Text abrufen
- Text aus Folie abrufen
- Text aus Präsentation abrufen
- Text aus PowerPoint abrufen
- Text aus OpenDocument abrufen
- Text aus PPT abrufen
- Text aus PPTX abrufen
- Text aus ODP abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js. Folgen Sie unserer einfachen, schrittweisen Anleitung, um Zeit zu sparen."
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie Sie Text aus Microsoft PowerPoint PPTX-Präsentationen mit Aspose.Slides extrahieren. 

{{% /alert %}} 

## **Text aus Folie extrahieren**

Aspose.Slides for Node.js via Java stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) bereit. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Texts aus einer Präsentation oder Folie. Um den Text aus einer Folie in einer PPTX-Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) der Klasse [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Diese Methode akzeptiert das Slide-Objekt als Parameter.
Bei der Ausführung scannt die Slide-Methode den gesamten Text der als Parameter übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)-Objekten zurück. Das bedeutet, dass alle mit dem Text verknüpften Textformatierungen verfügbar sind. Der folgende Codeabschnitt extrahiert den gesamten Text der ersten Folie der Präsentation:
```javascript
// Instanzieren der Presentation‑Klasse, die eine PPTX‑Datei repräsentiert
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // Ein Array von ITextFrame‑Objekten aus allen Folien in der PPTX erhalten
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // Durch das Array von TextFrames iterieren
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // Durch die Absätze im aktuellen ITextFrame iterieren
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // Durch die Teile im aktuellen IParagraph iterieren
                for (let k = 0; k < para.getPortions().getCount(); k++) {
                    let port = para.getPortions().get_Item(k);
                    // Text im aktuellen Teil anzeigen
                    console.log(port.getText());
                    // Schriftgröße des Textes anzeigen
                    console.log(port.getPortionFormat().getFontHeight());
                    // Schriftart des Textes anzeigen
                    if (port.getPortionFormat().getLatinFont() != null) {
                        console.log(port.getPortionFormat().getLatinFont().getFontName());
                    }
                });
            }
        }
    });
} finally {
    pres.dispose();
}
```


## **Text aus Präsentation extrahieren**

Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) der Klasse SlideUtil. Sie akzeptiert zwei Parameter:

1. Erstens ein [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged)-Objekt, das die Präsentation darstellt, aus der der Text extrahiert wird.
2. Zweitens ein boolescher Wert, der bestimmt, ob die Master-Folie beim Scannen des Textes aus der Präsentation einbezogen werden soll.  
Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)-Objekten zurück, inklusive Textformatierungsinformationen. Der folgende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Master-Folien.
```javascript
// Instanzieren der Presentation-Klasse, die eine PPTX-Datei repräsentiert
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Ein Array von ITextFrame-Objekten aus allen Folien in der PPTX erhalten
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // Durch das Array von TextFrames iterieren
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // Durch die Absätze im aktuellen ITextFrame iterieren
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // Durch die Teile im aktuellen IParagraph iterieren
            for (let k = 0; k < para.getPortions().getCount(); k++) {
                let port = para.getPortions().get_Item(k);
                // Text im aktuellen Teil anzeigen
                console.log(port.getText());
                // Schriftgröße des Textes anzeigen
                console.log(port.getPortionFormat().getFontHeight());
                // Schriftart des Textes anzeigen
                if (port.getPortionFormat().getLatinFont() != null) {
                    console.log(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Kategorisierte und schnelle Textextraktion**

Die neue statische Methode getPresentationText wurde der Klasse Presentation hinzugefügt. Es gibt drei Überladungen für diese Methode:
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of `SlideText` objects. Every object represent the text on the corresponding slide. `SlideText` object have the following methods:

- `SlideText.getText` - The text on the slide's shapes
- `SlideText.getMasterText` - The text on the master page's shapes for this slide
- `SlideText.getLayoutText` - The text on the layout page's shapes for this slide
- `SlideText.getNotesText` - The text on the notes page's shapes for this slide

There is also a `SlideText` class which implements the `SlideText` class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet selbst große Präsentationen effizient, wodurch es sich für Echtzeit‑ oder Stapelverarbeitungs‑Szenarien eignet.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen vollständig, sodass Sie problemlos auf alle textuellen Inhalte zugreifen und diese analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, allerdings hat diese bestimmte Einschränkungen, z. B. die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Kauf einer Voll‑Lizenz empfohlen.