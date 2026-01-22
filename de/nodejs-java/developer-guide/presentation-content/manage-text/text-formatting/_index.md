---
title: PowerPoint-Text in JavaScript formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/nodejs-java/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textrahmen
- Zeilenabstand
- Autofit-Eigenschaft
- Textrahmen-Anker
- Texttabulator
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit JavaScript und Aspose.Slides für Node.js. Passen Sie Schriftarten, Farben, Ausrichtung und mehr an."
---

## **Text hervorheben**

Methode [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) wurde zur Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht, einen Textteil mit Hintergrundfarbe zu markieren, indem ein Textbeispiel verwendet wird, ähnlich dem Tool Text Highlight Color in PowerPoint 2019.

Das Code‑Snippet unten zeigt, wie man diese Funktion verwendet:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// Hervorheben aller Wörter 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// Hervorheben aller einzelnen 'the'-Vorkommen
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Aspose bietet einen einfachen, [kostenlosen Online‑PowerPoint‑Bearbeitungsservice](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Text mit regulärem Ausdruck hervorheben**

Methode [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) wurde zur Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht, einen Textteil mit Hintergrundfarbe zu markieren, indem ein regulärer Ausdruck verwendet wird, ähnlich dem Tool Text Highlight Color in PowerPoint 2019.

Das Code‑Snippet unten zeigt, wie man diese Funktion verwendet:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// Hervorheben aller Wörter mit 10 Zeichen oder länger
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Text‑Hintergrundfarbe festlegen**

Aspose.Slides ermöglicht es, die bevorzugte Farbe für den Hintergrund eines Textes anzugeben.

Dieser JavaScript‑Code zeigt, wie man die Hintergrundfarbe für einen gesamten Text festlegt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
const pres = new aspose.slides.Presentation("text.pptx");
try {
    const slide = pres.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    if (autoShape.getTextFrame() != null) {
        const paragraphs = autoShape.getTextFrame().getParagraphs();
        const paragraphCount = paragraphs.size();
        for (let i = 0; i < paragraphCount; i++) {
            const portions = paragraphs.get_Item(i).getPortions();
            const portionCount = portions.size();
            for (let j = 0; j < portionCount; j++) {
                const portion = portions.get_Item(j);
                portion.getPortionFormat().getHighlightColor().setColor(Color.BLUE);
            }
        }
    }
    pres.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Dieser JavaScript‑Code zeigt, wie man die Hintergrundfarbe nur für einen Teil eines Textes festlegt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
var presentation = new aspose.slides.Presentation("text.pptx");
try {
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var redPortion = java.callStaticMethodSync("StreamSupport", "stream", autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false).filter(p -> p.getText().contains("Red")).findFirst();
    if (redPortion.isPresent()) {
        redPortion.get().getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    presentation.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Textabsätze ausrichten**

Textformatierung ist ein Schlüsselelement beim Erstellen von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für Node.js via Java das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema zeigen wir, wie man die Ausrichtung von Textabsätzen in einer Folie steuern kann. Bitte folgen Sie den untenstehenden Schritten, um Textabsätze mit Aspose.Slides für Node.js via Java auszurichten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und casten Sie sie zu einem [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Erhalten Sie den Absatz (der ausgerichtet werden soll) aus dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) des [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Richten Sie den Absatz aus. Ein Absatz kann rechts, links, zentriert oder im Blocksatz ausgerichtet werden.
6. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten angegeben.
```javascript
// Instanziieren eines Presentation-Objekts, das eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Text in beiden Platzhaltern ändern
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // Den ersten Absatz der Platzhalter abrufen
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Textabsatz zentrieren
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // Die Präsentation als PPTX-Datei speichern
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Transparenz für Text festlegen**

Dieser Artikel demonstriert, wie man die Transparenzeigenschaft für jede Textform mit Aspose.Slides für Node.js via Java festlegt. Bitte folgen Sie den untenstehenden Schritten, um die Transparenz für Text einzustellen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten angegeben.
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // Transparenz auf null Prozent setzen
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zeichenabstand für Text festlegen**

Aspose.Slides ermöglicht es, den Abstand zwischen Zeichen in einem Textfeld festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks durch Vergrößern oder Verkleinern des Zeichenabstands anpassen.

Dieser JavaScript‑Code zeigt, wie man den Abstand für eine Zeile Text erweitert und für eine andere Zeile verkleinert:
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// erweitern
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// komprimieren
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Schrifteigenschaften von Absätzen verwalten**

Präsentationen enthalten in der Regel Text und Bilder. Der Text kann auf verschiedene Arten formatiert werden, um bestimmte Abschnitte und Wörter hervorzuheben oder um Unternehmensrichtlinien zu entsprechen. Textformatierung hilft Benutzern, das Aussehen von Präsentationsinhalten zu variieren. Dieser Artikel zeigt, wie man mit Aspose.Slides für Node.js via Java die Schrifteigenschaften von Absätzen auf Folien konfiguriert:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Greifen Sie auf die Platzhalterformen in der Folie zu und casten Sie sie zu einem [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Erhalten Sie den [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) aus dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) des [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Richten Sie den Absatz aus (Blocksatz).
1. Greifen Sie auf den Textanteil eines Absatzes zu.
1. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart des Textanteils entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Setzen Sie die Schriftfarbe mithilfe von [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) des [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)-Objekts.
1. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Die Implementierung der obigen Schritte ist unten angegeben. Sie nimmt eine unveränderte Präsentation und formatiert die Schriften auf einer der Folien.
```javascript
// Erstelle ein Presentation-Objekt, das eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Zugriff auf eine Folie mittels ihrer Position
    var slide = pres.getSlides().get_Item(0);
    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Zugriff auf den ersten Absatz
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Zugriff auf den ersten Textteil
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Neue Schriftarten definieren
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Neue Schriftarten dem Textteil zuweisen
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Schriftart fett setzen
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Schriftart kursiv setzen
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Schriftfarbe festlegen
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // PPTX auf die Festplatte schreiben
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Schriftfamilie von Text verwalten**

Ein Portion wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man mit Aspose.Slides für Node.js via Java ein Textfeld mit Text erstellt und anschließend eine bestimmte Schriftart sowie weitere Eigenschaften der Schriftfamilie definiert. So erstellen Sie ein Textfeld und setzen Schriftarteigenschaften des darin enthaltenen Textes:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) des Typs [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) zur Folie hinzu.
4. Entfernen Sie den Füllstil, der mit dem [AutoShape] verknüpft ist.
5. Greifen Sie auf das TextFrame des AutoShape zu.
6. Fügen Sie dem TextFrame etwas Text hinzu.
7. Greifen Sie auf das Portion-Objekt zu, das mit dem TextFrame verknüpft ist.
8. Definieren Sie die für die Portion zu verwendende Schriftart.
9. Setzen Sie weitere Schrifteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mittels der entsprechenden Eigenschaften des Portion-Objekts.
10. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten angegeben.
```javascript
// Präsentation instanziieren
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie holen
    var sld = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rectangle hinzufügen
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Alle Füllstile des AutoShape entfernen
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Auf das zum AutoShape gehörige TextFrame zugreifen
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Auf den zum TextFrame gehörigen Portion zugreifen
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Schriftart für den Portion festlegen
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Fettdruck-Eigenschaft der Schrift setzen
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Kursiv-Eigenschaft der Schrift setzen
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Unterstreichungs-Eigenschaft der Schrift setzen
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Schriftgröße festlegen
    port.getPortionFormat().setFontHeight(25);
    // Farbe der Schrift festlegen
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // PPTX auf die Festplatte schreiben
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Schriftgröße für Text festlegen**

Aspose.Slides ermöglicht es, die bevorzugte Schriftgröße für vorhandenen Text in einem Absatz und für später hinzuzufügenden Text festzulegen.

Dieser JavaScript‑Code zeigt, wie man die Schriftgröße für Texte in einem Absatz festlegt:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Holt das erste Shape, zum Beispiel.
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // Holt den ersten Absatz, zum Beispiel.
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // Setzt die Standard-Schriftgröße auf 20 pt für alle Textteile im Absatz.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // Setzt die Schriftgröße auf 20 pt für die aktuellen Textteile im Absatz.
        for (let i = 0; i < paragraph.getPortions().getCount(); i++) {
            let portion = paragraph.getPortions().get_Item(i);
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Textrotation festlegen**

Aspose.Slides für Node.js via Java ermöglicht Entwicklern, Text zu rotieren. Der Text kann als [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) oder [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) anzeigen lassen. Um den Text eines beliebigen TextFrames zu rotieren, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein beliebiges Shape zur Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) zu.
5. [Drehen Sie den Text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. Speichern Sie die Datei auf der Festplatte.
```javascript
// Instanz der Klasse Presentation erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie holen
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rectangle hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Auf das TextFrame zugreifen
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Paragraph-Objekt für das TextFrame erstellen
    var para = txtFrame.getParagraphs().get_Item(0);
    // Portion-Objekt für den Paragraphen erstellen
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Präsentation speichern
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Benutzerdefinierten Rotationswinkel für TextFrame festlegen**

Aspose.Slides für Node.js via Java unterstützt nun das Festlegen eines benutzerdefinierten Rotationswinkels für TextFrame. In diesem Thema zeigen wir anhand eines Beispiels, wie man die Eigenschaft RotationAngle in Aspose.Slides setzt. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) und [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) wurden zur Klasse [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) hinzugefügt und ermöglichen das Setzen eines benutzerdefinierten Rotationswinkels für TextFrame. Um den RotationAngle zu setzen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Fügen Sie ein Diagramm auf der Folie hinzu.
3. [Setzen Sie die Eigenschaft RotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel setzen wir die Eigenschaft RotationAngle.
```javascript
// Instanz der Klasse Presentation erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie holen
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rectangle hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Auf das TextFrame zugreifen
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // Paragraph-Objekt für das TextFrame erstellen
    var para = txtFrame.getParagraphs().get_Item(0);
    // Portion-Objekt für den Paragraphen erstellen
    var portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Präsentation speichern
    pres.save(resourcesOutputPath + "RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zeilenabstand eines Absatzes**

Aspose.Slides bietet Eigenschaften unter [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`, `SpaceBefore` und `SpaceWithin`—die es ermöglichen, den Zeilenabstand für einen Absatz zu verwalten. Die drei Eigenschaften werden wie folgt verwendet:

* Um den Zeilenabstand für einen Absatz in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Absatz in Punkten anzugeben, verwenden Sie einen negativen Wert.

Beispielsweise können Sie einen Zeilenabstand von 16 pt für einen Absatz anwenden, indem Sie die Eigenschaft `SpaceBefore` auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die ein AutoShape mit Text enthält.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Absatz zu.
5. Setzen Sie die Absatz‑Eigenschaften.
6. Speichern Sie die Präsentation.

Dieser JavaScript‑Code zeigt, wie man den Zeilenabstand für einen Absatz festlegt:
```javascript
// Instanz der Klasse Presentation erstellen
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Referenz einer Folie anhand ihres Index erhalten
    var sld = pres.getSlides().get_Item(0);
    // Zugriff auf das TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // Zugriff auf den Absatz
    var para = tf1.getParagraphs().get_Item(0);
    // Eigenschaften des Absatzes festlegen
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    // Präsentation speichern
    pres.save("LineSpacing_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **AutofitType‑Eigenschaft für TextFrame festlegen**

In diesem Thema untersuchen wir verschiedene Formatierungseigenschaften von TextFrames. Dieser Artikel behandelt, wie man die AutofitType‑Eigenschaft eines TextFrames, den Anker von Text und die Textrotation in einer Präsentation setzt. Aspose.Slides für Node.js via Java erlaubt Entwicklern, die AutofitType‑Eigenschaft jedes TextFrames zu setzen. AutofitType kann auf [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) oder [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape) gesetzt werden. Wenn sie auf [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) gesetzt ist, bleibt die Form unverändert, während der Text angepasst wird, ohne die Form zu verändern. Wird AutofitType auf [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape) gesetzt, wird die Form so angepasst, dass nur der erforderliche Text darin enthalten ist. Um die AutofitType‑Eigenschaft eines TextFrames zu setzen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein beliebiges Shape zur Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) zu.
5. [Setzen Sie die AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.
```javascript
// Instanz der Klasse Presentation erstellen
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rectangle hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Auf das TextFrame zugreifen
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Paragraph-Objekt für das TextFrame erstellen
    var para = txtFrame.getParagraphs().get_Item(0);
    // Portion-Objekt für den Paragraphen erstellen
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Präsentation speichern
    pres.save(resourcesOutputPath + "formatText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Anker von TextFrame festlegen**

Aspose.Slides für Node.js via Java erlaubt Entwicklern, den Anker eines beliebigen TextFrames zu setzen. TextAnchorType gibt an, wo der Text innerhalb der Form platziert wird. AnchorType kann auf [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) oder [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed) gesetzt werden. Um den Anker eines beliebigen TextFrames zu setzen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein beliebiges Shape zur Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) zu.
5. [Setzen Sie TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.
```javascript
// Instanz der Klasse Presentation erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie holen
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rectangle hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Auf das TextFrame zugreifen
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // Paragraph-Objekt für das TextFrame erstellen
    var para = txtFrame.getParagraphs().get_Item(0);
    // Portion-Objekt für den Paragraphen erstellen
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Präsentation speichern
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Tabs und EffectiveTabs in Präsentation**

Alle Texttabulatoren werden in Pixel angegeben.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Abbildung: 2 explizite Tabs und 2 Standard‑Tabs**|

- EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.
- Die EffectiveTabs‑Sammlung enthält alle Tabs (aus der Tabs‑Sammlung und den Standard‑Tabs).
- EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) gibt den Abstand zwischen Standard‑Tabs (3 und 4 in unserem Beispiel) an.
- EffectiveTabs.GetTabByIndex(index) mit index = 0 liefert den ersten expliziten Tab (Position = 731), index = 1 – zweiten Tab (Position = 1241). Bei index = 2 wird der erste Standard‑Tab (Position = 1470) zurückgegeben usw.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um nach einem Text die nächste Tabulation zu ermitteln. Beispiel: Sie haben den Text „Hello World!“. Um diesen Text zu rendern, müssen Sie wissen, wo Sie „world!“ beginnen lassen. Zuerst berechnen Sie die Länge von „Hello“ in Pixel und rufen GetTabAfterPosition mit diesem Wert auf. Sie erhalten die nächste Tab‑Position, um „world!“ zu zeichnen.

## **Standard‑Textstil festlegen**

Wenn Sie denselben Standard‑Textformatierungsstil auf alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die Methode `getDefaultTextStyle` der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse verwenden und das gewünschte Format festlegen. Das folgende Beispiel zeigt, wie man die Standard‑Fettschrift (14 pt) für den Text auf allen Folien einer neuen Präsentation festlegt.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Das Absatzformat der obersten Ebene abrufen.
    var paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);
    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    }
    presentation.save("DefaultTextStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt die Anwendung des **All Caps**‑Schrifteffekts, dass Text auf der Folie in Großbuchstaben angezeigt wird, auch wenn er ursprünglich klein geschrieben wurde. Wenn Sie einen solchen Textanteil mit Aspose.Slides abrufen, liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um dies zu handhaben, prüfen Sie [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) – wenn er `All` anzeigt, konvertieren Sie die zurückgegebene Zeichenfolge einfach in Großbuchstaben, sodass Ihre Ausgabe dem entspricht, was Benutzer auf der Folie sehen.

Nehmen wir an, wir haben das folgende Textfeld auf der ersten Folie der Datei sample2.pptx.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der folgende Code zeigt, wie man den Text mit dem **All Caps**‑Effekt extrahiert:
```js
var presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var autoShape = slide.getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    var textPortion = paragraph.getPortions().get_Item(0);

    console.log("Original text:", textPortion.getText());

    var textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == aspose.slides.TextCapType.All) {
        var text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect:", text);
    }
} finally {
    presentation.dispose();
}
```


Ausgabe:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, nutzen Sie das [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)‑Objekt. Sie können durch alle Zellen der Tabelle iterieren und den Text in jeder Zelle ändern, indem Sie auf deren `TextFrame`‑ und `ParagraphFormat`‑Eigenschaften innerhalb jeder Zelle zugreifen.

**Wie kann man Farbverlauf auf Text in einer PowerPoint‑Folien anwenden?**

Um Farbverlauf auf Text anzuwenden, verwenden Sie die Fill‑Format‑Eigenschaft in [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). Setzen Sie das Fill‑Format auf `Gradient`, wobei Sie die Start‑ und Endfarben des Verlaufs sowie weitere Eigenschaften wie Richtung und Transparenz definieren, um den Verlaufseffekt auf den Text zu erzeugen.