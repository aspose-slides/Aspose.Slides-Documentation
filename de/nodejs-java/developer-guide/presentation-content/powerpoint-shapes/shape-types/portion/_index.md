---
title: Abschnitt
type: docs
weight: 70
url: /de/nodejs-java/portion/
---

## **Positionskoordinaten des Abschnitts abrufen**
[**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) Methode wurde zur Klasse [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) hinzugefügt, die das Abrufen der Koordinaten des Beginns des Abschnitts ermöglicht.
```javascript
// Instanziiere die Prseetation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Umformen des Kontextes der Präsentation
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich einem Hyperlink nur einen Teil des Textes in einem einzelnen Absatz zuweisen?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/nodejs-java/manage-hyperlinks/) zu einem einzelnen Abschnitt; nur dieser Teil ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Abschnitt und was wird vom Absatz/TextFrame übernommen?**

Eigenschaften auf Abschnittsebene haben die höchste Priorität. Wenn eine Eigenschaft nicht im [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) gesetzt ist, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/); ist sie dort ebenfalls nicht gesetzt, vom [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) oder vom [theme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/theme/)-Stil.

**Was passiert, wenn die für einen Abschnitt angegebene Schriftart auf dem Zielcomputer/Server fehlt?**

[Schriftartenersetzungsregeln](/slides/de/nodejs-java/font-selection-sequence/) werden angewendet. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für präzise Positionierung wichtig ist.

**Kann ich die Transparenz oder den Verlauf einer Textfüllung für einen Abschnitt spezifisch festlegen, unabhängig vom Rest des Absatzes?**

Ja, Textfarbe, Füllung und Transparenz auf [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)-Ebene können von benachbarten Fragmenten abweichen.