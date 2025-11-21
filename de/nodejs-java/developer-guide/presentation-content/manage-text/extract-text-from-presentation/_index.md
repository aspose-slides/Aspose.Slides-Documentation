---
title: Text aus Präsentation extrahieren
type: docs
weight: 90
url: /de/nodejs-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX‑Präsentationen mit Aspose.Slides extrahiert. 

{{% /alert %}} 

## **Text aus Folie extrahieren**

Aspose.Slides für Node.js via Java stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) bereit. Diese Klasse stellt eine Reihe überladener statischer Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie bereit. Um den Text aus einer Folie in einer PPTX‑Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) der Klasse [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Diese Methode akzeptiert das Slide Objekt als Parameter.  
Bei der Ausführung scannt die Slide Methode den gesamten Text der als Parameter übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) Objekten zurück. Das bedeutet, dass alle mit dem Text verbundenen Formatierungen verfügbar sind. Der folgende Code extrahiert den gesamten Text der ersten Folie der Präsentation:
```javascript
// Instanziiere die Presentation‑Klasse, die eine PPTX‑Datei darstellt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // Erhalte ein Array von ITextFrame‑Objekten aus allen Folien der PPTX
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // Durchlaufe das Array von TextFrames
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // Durchlaufe Absätze im aktuellen ITextFrame
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // Durchlaufe Abschnitte im aktuellen IParagraph
                for (let k = 0; k < para.getPortions().getCount(); k++) {
                    let port = para.getPortions().get_Item(k);
                    // Anzeige des Textes im aktuellen Abschnitt
                    console.log(port.getText());
                    // Anzeige der Schriftgröße des Textes
                    console.log(port.getPortionFormat().getFontHeight());
                    // Anzeige des Schriftartnamens des Textes
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

Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) der Klasse SlideUtil. Sie nimmt zwei Parameter:

1. Erstens ein [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) Objekt, das die Präsentation repräsentiert, aus der der Text extrahiert wird.
2. Zweitens ein boolescher Wert, der bestimmt, ob die Master‑Folien beim Scannen des Textes aus der Präsentation einbezogen werden sollen.  
Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) Objekten zurück, inklusive Textformatierungsinformationen. Der nachstehende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Master‑Folien.
```javascript
// Instanziiere die Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Erhalte ein Array von ITextFrame-Objekten aus allen Folien der PPTX
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // Durchlaufe das Array von TextFrames
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // Durchlaufe Absätze im aktuellen ITextFrame
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // Durchlaufe Abschnitte im aktuellen IParagraph
            for (let k = 0; k < para.getPortions().getCount(); k++) {
                let port = para.getPortions().get_Item(k);
                // Gib den Text im aktuellen Abschnitt aus
                console.log(port.getText());
                // Gib die Schriftgröße des Textes aus
                console.log(port.getPortionFormat().getFontHeight());
                // Gib den Schriftartnamen des Textes aus
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


## **Kategorisierte und schnelle Texteextraktion**

Die neue statische Methode getPresentationText wurde zur Klasse Presentation hinzugefügt. Es gibt drei Überladungen für diese Methode:
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Texteextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet selbst große Präsentationen effizient, wodurch es sich für Echtzeit‑ oder Massenvorgänge eignet.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen vollständig, sodass Sie sämtlichen Textinhalt leicht zugreifen und analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, allerdings hat diese bestimmte Einschränkungen, z. B. die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkten Einsatz und zur Verarbeitung größerer Präsentationen wird der Erwerb einer Volllizenz empfohlen.