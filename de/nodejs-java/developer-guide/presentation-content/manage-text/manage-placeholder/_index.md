---
title: Platzhalter verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-placeholder/
description: Text in einem Platzhalter in PowerPoint-Folien mit JavaScript ändern. Eingabeaufforderungstext in einem Platzhalter in PowerPoint-Folien mit JavaScript festlegen.
---

## **Text im Platzhalter ändern**

Mit [Aspose.Slides for Node.js via Java](/slides/de/nodejs-java/) können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es Ihnen, den Text in einem Platzhalter zu ändern.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Eine solche Präsentation können Sie in der üblichen Microsoft PowerPoint‑Anwendung erstellen.

So verwenden Sie Aspose.Slides, um den Text in dem Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie eine Folienreferenz über deren Index.
3. Iterieren Sie über die Formen, um den Platzhalter zu finden.
4. Casten Sie die Platzhalterform zu einer [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) und ändern Sie den Text mithilfe des [`TextFrame`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame), das mit der [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) verbunden ist.
5. Speichern Sie die geänderte Präsentation.

Dieser JavaScript‑Code zeigt, wie Sie den Text in einem Platzhalter ändern:
```javascript
// Instanziiert eine Presentation-Klasse
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Durchläuft die Formen, um den Platzhalter zu finden
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Ändert den Text in jedem Platzhalter
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Speichert die Präsentation auf dem Datenträger
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eingabeaufforderungstext im Platzhalter festlegen**

Standard‑ und vordefinierte Layouts enthalten Platzhalter‑Eingabeaufforderungstexte wie ***Klicken, um einen Titel hinzuzufügen*** oder ***Klicken, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Eingabeaufforderungstexte in Platzhalter‑Layouts einfügen.

Dieser JavaScript‑Code zeigt Ihnen, wie Sie den Eingabeaufforderungstext in einem Platzhalter festlegen:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Durchläuft die Folie
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint zeigt "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Fügt Untertitel hinzu
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Transparenz des Platzhalter‑Bildes festlegen**

Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbildes in einem Text‑Platzhalter festzulegen. Durch Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (abhängig von den Farben von Text und Bild).

Dieser JavaScript‑Code zeigt Ihnen, wie Sie die Transparenz für einen Bild‑Hintergrund (innerhalb einer Form) festlegen:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **FAQ**

**Was ist ein Basis‑Platzhalter und wie unterscheidet er sich von einer lokalen Form auf einer Folie?**

Ein Basis‑Platzhalter ist die ursprüngliche Form in einem Layout oder Master, von der die Folienform erbt – Typ, Position und einige Formatierungen stammen daraus. Eine lokale Form ist unabhängig; gibt es keinen Basis‑Platzhalter, findet keine Vererbung statt.

**Wie kann ich alle Titel oder Beschriftungen in einer Präsentation aktualisieren, ohne jede Folie zu durchlaufen?**

Bearbeiten Sie den entsprechenden Platzhalter im Layout oder im Master. Folien, die auf diesen Layouts bzw. diesem Master basieren, erben die Änderung automatisch.

**Wie kann ich die Standard‑Kopf‑/Fußzeilen‑Platzhalter – Datum & Uhrzeit, Foliennummer und Fußzeilentext – steuern?**

Verwenden Sie die HeaderFooter‑Manager im jeweiligen Geltungsbereich (normale Folien, Layouts, Master, Notizen/Handouts), um diese Platzhalter ein- oder auszuschalten und deren Inhalt festzulegen.