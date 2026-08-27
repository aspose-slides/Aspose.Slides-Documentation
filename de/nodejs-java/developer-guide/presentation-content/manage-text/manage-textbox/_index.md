---
title: Textfelder in Präsentationen mit JavaScript verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/nodejs-java/manage-textbox/
keywords:
- Textfeld
- Textrahmen
- Text hinzufügen
- Text aktualisieren
- Textfeld erstellen
- Textfeld prüfen
- Textspalte hinzufügen
- Hyperlink hinzufügen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides für Node.js ermöglicht das einfache Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert die Automatisierung Ihrer Präsentationen."
---
## **Einführung**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher muss man, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann etwas Text in das Textfeld einfügen. Aspose.Slides für Node.js via Java stellt die [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/AutoShape) Klasse bereit, die das Hinzufügen einer Form ermöglicht, die Text enthält.

{{% alert title="Info" color="info" %}}
Aspose.Slides stellt außerdem die [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Shape) Klasse bereit, die das Hinzufügen von Formen zu Folien ermöglicht. Allerdings können nicht alle über die `Shape`‑Klasse hinzugefügten Formen Text enthalten. Formen, die über die [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/AutoShape) Klasse hinzugefügt werden, können jedoch Text enthalten.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Daher sollten Sie, wenn Sie mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über die `AutoShape`‑Klasse gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/TextFrame) arbeiten, das eine Eigenschaft von `AutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/de/nodejs-java/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Textfeld auf Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation) Klasse.  
2. Holen Sie sich eine Referenz zur ersten Folie in der neu erstellten Präsentation.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/AutoShape) Objekt mit [ShapeType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz des neu hinzugefügten `AutoShape` Objekts.  
4. Fügen Sie dem `AutoShape` Objekt die Eigenschaft `TextFrame` hinzu, die einen Text enthalten wird. Im Beispiel unten haben wir diesen Text hinzugefügt: *Aspose TextBox*  
5. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt.  

Dieser JavaScript‑Code – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie Text zu einer Folie hinzufügen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziiert Präsentation
var pres = new aspose.slides.Presentation();
try {
    // Ruft die erste Folie in der Präsentation ab
    var sld = pres.getSlides().get_Item(0);
    // Fügt eine AutoShape mit dem Typ Rectangle hinzu
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Fügt dem Rectangle ein TextFrame hinzu
    ashp.addTextFrame(" ");
    // Greift auf das TextFrame zu
    var txtFrame = ashp.getTextFrame();
    // Erstellt das Paragraph-Objekt für das TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Erstellt ein Portion-Objekt für den Paragraph
    var portion = para.getPortions().get_Item(0);
    // Setzt den Text
    portion.setText("Aspose TextBox");
    // Speichert die Präsentation auf der Festplatte
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Überprüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die [isTextBox](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/#isTextBox) Methode aus der [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) Klasse bereit, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Text box and shape](istextbox.png)

Dieser JavaScript‑Code zeigt, wie Sie prüfen, ob eine Form als Textfeld erstellt wurde:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Beachten Sie, dass die `isTextBox`‑Methode eines über die `addAutoShape`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/) Klasse hinzugefügten AutoShape `false` zurückgibt. Nachdem Sie jedoch Text mit `addTextFrame` oder `setText` hinzugefügt haben, gibt die `isTextBox`‑Eigenschaft `true` zurück.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Finden Sie die Form, die einen TextFrame besitzt**

In generischem Textverarbeitungs‑Code erhalten Sie möglicherweise ein [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) ohne zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die [TextFrame.getParentShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentShape--) Methode, um zum zugehörigen [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) zurückzukehren.

Für ein TextFrame, das zu einer [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) oder einer anderen text‑haltenden Form gehört, gibt [TextFrame.getParentShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentShape--) den Besitzer zurück und [TextFrame.getParentCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentCell--) gibt `null` zurück. Beide Methoden bieten nur Lese‑Navigation, sodass ihr Aufruf die Besitzverhältnisse nicht ändert. Prüfen Sie stets, ob der zurückgegebene Wert `null` ist, bevor Sie auf die Form zugreifen.

Ein vollständiges Beispiel, das Form‑ und Tabellenzellen‑Besitzer einschließlich zu SmartArt‑Knoten zugehöriger Formen identifiziert, finden Sie unter [Search and Replace Text](/slides/de/nodejs-java/search-and-replace-text/).

## **Spalten in Textfeld hinzufügen**

Aspose.Slides bietet die [setColumnCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) und [setColumnSpacing](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) Methoden der [TextFrameFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/TextFrameFormat) Klasse, mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten in einem Textfeld festlegen und den Abstand in Punkten zwischen den Spalten bestimmen.

Dieser JavaScript‑Code demonstriert die beschriebene Operation:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Ruft die erste Folie in der Präsentation ab
    var slide = pres.getSlides().get_Item(0);
    // Fügt eine AutoShape mit dem Typ Rectangle hinzu
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Fügt dem Rectangle ein TextFrame hinzu
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Ruft das Textformat des TextFrames ab
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Legt die Anzahl der Spalten im TextFrame fest
    format.setColumnCount(3);
    // Legt den Abstand zwischen den Spalten fest
    format.setColumnSpacing(10);
    // Speichert die Präsentation
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Spalten im TextFrame hinzufügen**

Aspose.Slides für Node.js via Java stellt die [setColumnCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) Methode der [TextFrameFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/TextFrameFormat) Klasse bereit, mit der Sie Spalten in TextFrames hinzufügen können. Über diese Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem TextFrame festlegen.

Dieser JavaScript‑Code zeigt, wie Sie eine Spalte innerhalb eines TextFrames hinzufügen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Der Spaltenabstand wurde nie gesetzt, daher wird er als NaN gemeldet.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
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

Aspose.Slides ermöglicht es Ihnen, den Text in einem Textfeld oder den gesamten Text einer Präsentation zu ändern oder zu aktualisieren.

Dieser JavaScript‑Code demonstriert einen Vorgang, bei dem alle Texte in einer Präsentation aktualisiert bzw. geändert werden:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Überprüft, ob die Form ein Text-Frame unterstützt (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Durchläuft die Absätze im Text-Frame
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

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, wird der Link geöffnet.

Um ein Textfeld mit einem Link hinzuzufügen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.  
2. Holen Sie sich eine Referenz zur ersten Folie in der neu erstellten Präsentation.  
3. Fügen Sie ein `AutoShape` Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz des neu hinzugefügten AutoShape Objekts.  
4. Fügen Sie dem `AutoShape` Objekt ein `TextFrame` hinzu und setzen Sie den Text seines ersten Bereichs. Im Beispiel unten haben wir diesen Text verwendet: *Aspose.Slides*  
5. Rufen Sie über das `PortionFormat` den `HyperlinkManager` dieses Bereichs ab.  
6. Rufen Sie `setExternalHyperlinkClick` am `HyperlinkManager` auf, um den Link dem Bereich zuzuordnen.  
7. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt.  

Dieser JavaScript‑Code – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie ein Textfeld mit einem Hyperlink zu einer Folie hinzufügen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziert eine Presentation‑Klasse, die ein PPTX repräsentiert
var pres = new aspose.slides.Presentation();
try {
    // Ruft die erste Folie in der Präsentation ab
    var slide = pres.getSlides().get_Item(0);
    // Fügt ein AutoShape‑Objekt mit dem Typ Rectangle hinzu
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Castet die Form zu AutoShape
    var pptxAutoShape = shape;
    // Greift auf die ITextFrame‑Eigenschaft zu, die mit dem AutoShape verknüpft ist
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Fügt dem Frame etwas Text hinzu
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Setzt den Hyperlink für den Portion‑Text
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Speichert die PPTX‑Präsentation
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [placeholder](/slides/de/nodejs-java/manage-placeholder/) erbt Stil/Position vom [master](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) und kann auf [layouts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/) überschrieben werden, während ein normales Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn Sie das Layout wechseln.

**Wie kann ich einen massiven Text‑Ersetzungsvorgang über die gesamte Präsentation durchführen, ohne Texte in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie die Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([charts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.