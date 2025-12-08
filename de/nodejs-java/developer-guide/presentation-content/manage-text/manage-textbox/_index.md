---
title: Textfeld verwalten
type: docs
weight: 20
url: /de/nodejs-java/manage-textbox/
keywords:
- Textfeld
- Textrahmen
- Text hinzufügen
- Text aktualisieren
- Textfeld mit Hyperlink
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Verwalten Sie ein Textfeld oder einen Textrahmen in PowerPoint-Präsentationen mit JavaScript"
---

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld einfügen und dann Text in das Textfeld eintragen. Aspose.Slides for Node.js via Java bietet die [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)-Klasse, mit der Sie eine Form mit Text hinzufügen können.

{{% alert title="Info" color="info" %}}
Aspose.Slides stellt außerdem die [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape)-Klasse bereit, mit der Sie Formen zu Folien hinzufügen können. Nicht alle über die `Shape`‑Klasse hinzugefügten Formen können jedoch Text enthalten. Formen, die über die [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)-Klasse hinzugefügt wurden, können Text enthalten.
{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}} 
Daher sollten Sie, wenn Sie einer Form Text hinzufügen möchten, prüfen und bestätigen, dass sie über die `AutoShape`‑Klasse erstellt wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) arbeiten, das eine Eigenschaft von `AutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/nodejs-java/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Textfeld auf Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich eine Referenz auf die erste Folie der neu erstellten Präsentation.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)-Objekt mit `ShapeType` = `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz auf das neu hinzugefügte `AutoShape`‑Objekt.  
4. Fügen Sie dem `AutoShape`‑Objekt eine `TextFrame`‑Eigenschaft hinzu, die Text enthält. Im folgenden Beispiel haben wir den Text *Aspose TextBox* eingefügt.  
5. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt.  

Der folgende JavaScript‑Code – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie Text zu einer Folie hinzufügen:
```javascript
// Instanziiert Presentation
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie in der Präsentation
    var sld = pres.getSlides().get_Item(0);
    // Fügt eine AutoShape mit Typ Rectangle hinzu
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Fügt dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame(" ");
    // Greift auf das TextFrame zu
    var txtFrame = ashp.getTextFrame();
    // Erstellt das Paragraph-Objekt für das TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Erstellt ein Portion-Objekt für den Paragraphen
    var portion = para.getPortions().get_Item(0);
    // Setzt Text
    portion.setText("Aspose TextBox");
    // Speichert die Präsentation auf dem Datenträger
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Überprüfen, ob es sich um ein Textfeld handelt**

Aspose.Slides bietet die Methode [isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox) der [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)-Klasse, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Textfeld und Form](istextbox.png)

Dieser JavaScript‑Code zeigt, wie Sie prüfen, ob eine Form als Textfeld erstellt wurde:
```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


Beachten Sie, dass die Methode `isTextBox` bei einer über die `addAutoShape`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) hinzugefügten AutoShape `false` zurückgibt. Nachdem Sie jedoch Text über die `addTextFrame`‑Methode oder die `setText`‑Methode hinzugefügt haben, liefert die Eigenschaft `isTextBox` `true`.
```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() gibt false zurück
shape1.addTextFrame("shape 1");
// shape1.isTextBox() gibt true zurück

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() gibt false zurück
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() gibt true zurück

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() gibt false zurück
shape3.addTextFrame("");
// shape3.isTextBox() gibt false zurück

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() gibt false zurück
shape4.getTextFrame().setText("");
// shape4.isTextBox() gibt false zurück
```


## **Spalten in Textfeld hinzufügen**

Aspose.Slides stellt die Methoden [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) und [setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) der [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)-Klasse bereit, mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten sowie den Abstand in Punkt zwischen den Spalten festlegen.

Dieser JavaScript‑Code demonstriert die beschriebene Vorgehensweise:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie in der Präsentation
    var slide = pres.getSlides().get_Item(0);
    // Fügt eine AutoShape mit Typ Rectangle hinzu
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Fügt dem Rechteck ein TextFrame hinzu
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Holt das Textformat des TextFrames
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Gibt die Anzahl der Spalten im TextFrame an
    format.setColumnCount(3);
    // Gibt den Abstand zwischen den Spalten an
    format.setColumnSpacing(10);
    // Speichert die Präsentation
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Spalten im Textrahmen hinzufügen**

Aspose.Slides for Node.js via Java bietet die Methode [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) der [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)-Klasse, mit der Sie Spalten in Textrahmen einfügen können. Über diese Eigenschaft können Sie die gewünschte Spaltenanzahl in einem Textrahmen festlegen.

Der folgende JavaScript‑Code zeigt, wie Sie einer TextFrame‑Spalte hinzufügen:
```javascript
var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Text aktualisieren**

Aspose.Slides ermöglicht es Ihnen, den Text in einem Textfeld oder sämtliche Texte einer Präsentation zu ändern bzw. zu aktualisieren.

Dieser JavaScript‑Code demonstriert einen Vorgang, bei dem alle Texte einer Präsentation aktualisiert werden:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Prüft, ob die Form Textframe unterstützt (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Durchläuft Absätze im Textframe
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Durchläuft jede Portion im Absatz
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Ändert den Text
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Ändert die Formatierung
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


## **Textfeld mit Hyperlink hinzufügen** 

Sie können einen Link in ein Textfeld einfügen. Beim Anklicken des Textfeldes wird der Link geöffnet.

So fügen Sie ein Textfeld mit einem Link hinzu:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie sich eine Referenz auf die erste Folie der neu erstellten Präsentation.  
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` = `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz auf das neu hinzugefügte AutoShape‑Objekt.  
4. Fügen Sie dem `AutoShape`‑Objekt einen `TextFrame` hinzu, der *Aspose TextBox* als Standardtext enthält.  
5. Instanziieren Sie die `HyperlinkManager`‑Klasse.  
6. Weisen Sie das `HyperlinkManager`‑Objekt der [HyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick--)‑Eigenschaft des gewünschten Textabschnitts im `TextFrame` zu.  
7. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt.  

Der folgende JavaScript‑Code – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:
```javascript
// Instanziiert eine Presentation-Klasse, die ein PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie in der Präsentation
    var slide = pres.getSlides().get_Item(0);
    // Fügt ein AutoShape-Objekt mit dem Typ Rectangle hinzu
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Castet die Form zu AutoShape
    var pptxAutoShape = shape;
    // Greift auf die ITextFrame-Eigenschaft der AutoShape zu
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Fügt dem Frame etwas Text hinzu
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Setzt den Hyperlink für den Portion-Text
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Speichert die PPTX-Präsentation
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [Platzhalter](/slides/de/nodejs-java/manage-placeholder/) erbt Stil/Position vom [Master](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) und kann in [Layouts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) überschrieben werden, während ein gewöhnliches Textfeld ein eigenständiges Objekt auf einer bestimmten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen massiven Text‑Ersetzungsvorgang in der gesamten Präsentation durchführen, ohne Texte in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie die Iteration auf Auto‑Shapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([Charts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/), [Tables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.