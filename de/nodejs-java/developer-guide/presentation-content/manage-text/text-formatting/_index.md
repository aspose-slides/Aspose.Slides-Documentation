---
title: PowerPoint-Text in JavaScript formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/nodejs-java/text-formatting/
keywords:
- Text hervorheben
- Regulärer Ausdruck
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeld-Anker
- Texttabulator
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js via Java formatieren und gestalten. Passen Sie Schriftarten, Farben, Ausrichtungen und mehr mit leistungsstarken JavaScript-Codebeispielen an."
---

## **Text hervorheben**

Die Methode [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) wurde zur Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe anhand eines Textbeispiels, ähnlich dem Tool „Textmarkerfarbe“ in PowerPoint 2019.

Der nachstehende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// Alle Wörter 'important' hervorheben
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// Alle einzelnen Vorkommen von 'the' hervorheben
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Aspose bietet einen einfachen, [kostenlosen Online‑PowerPoint‑Editor](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Text mit regulärem Ausdruck hervorheben**

Die Methode [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) wurde zur Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe anhand eines regulären Ausdrucks, ähnlich dem Tool „Textmarkerfarbe“ in PowerPoint 2019.

Der nachstehende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// Alle Wörter mit 10 oder mehr Zeichen hervorheben
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Hintergrundfarbe für Text festlegen**

Aspose.Slides erlaubt es, die gewünschte Farbe für den Hintergrund eines Textes anzugeben.

Dieser JavaScript‑Code zeigt, wie die Hintergrundfarbe für einen gesamten Text festgelegt wird:
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


Dieser JavaScript‑Code zeigt, wie die Hintergrundfarbe nur für einen Teil eines Textes festgelegt wird:
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

Die Textformatierung ist ein Schlüsselelement beim Erstellen von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für Node.js via Java das Hinzufügen von Text zu Folien unterstützt. In diesem Abschnitt sehen wir, wie die Ausrichtung von Textabsätzen in einer Folie gesteuert werden kann. Bitte folgen Sie den nachstehenden Schritten, um Textabsätze mit Aspose.Slides für Node.js via Java auszurichten:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Greifen Sie auf die Platzhalter‑Shapes in der Folie zu und casten Sie sie zu einer [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Lesen Sie den Absatz (der ausgerichtet werden soll) aus dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) der [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) aus.
5. Richten Sie den Absatz aus. Ein Absatz kann rechts, links, zentriert oder block‑justiert ausgerichtet werden.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die Umsetzung der obigen Schritte ist nachfolgend dargestellt.
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung in AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Ändern Sie den Text in beiden Platzhaltern
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // Abrufen des ersten Absatzes der Platzhalter
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Ausrichten des Textabsatzes zentriert
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // Schreiben der Präsentation als PPTX-Datei
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Transparenz für Text festlegen**

Dieser Artikel zeigt, wie die Transparenzeigenschaft für beliebige Text‑Shapes mit Aspose.Slides für Node.js via Java gesetzt wird. Gehen Sie dazu wie folgt vor:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie.
3. Legen Sie die Schattenfarbe fest.
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Die Umsetzung der obigen Schritte ist nachfolgend dargestellt.
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

Aspose.Slides ermöglicht das Festlegen des Abstands zwischen Zeichen in einem Textfeld. So können Sie die optische Dichte einer Zeile oder eines Textblocks durch Vergrößern oder Verkleinern des Zeichenabstands anpassen.

Der folgende JavaScript‑Code zeigt, wie der Abstand für eine Zeile vergrößert und für eine andere verkleinert wird:
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// erweitern
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// verdichten
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Schrifteigenschaften von Absätzen verwalten**

Präsentationen enthalten meist Text und Bilder. Der Text kann auf verschiedene Weise formatiert werden, etwa um bestimmte Abschnitte hervorzuheben oder um Unternehmensrichtlinien zu entsprechen. Die Textformatierung unterstützt Benutzer dabei, das Erscheinungsbild des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Aspose.Slides für Node.js via Java verwendet wird, um die Schrifteigenschaften von Absätzen auf Folien zu konfigurieren. Vorgehensweise:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Greifen Sie auf die Platzhalter‑Shapes in der Folie zu und casten Sie sie zu einer [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Lesen Sie den [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) aus dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) der [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) aus.
5. Justieren Sie den Absatz.
6. Greifen Sie auf den Text‑Portion eines Absatzes zu.
7. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart des Portion‑Texts entsprechend.
   - Setzen Sie die Schrift auf fett.
   - Setzen Sie die Schrift auf kursiv.
8. Setzen Sie die Schriftfarbe über die Methode [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) des [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)-Objekts.
9. Schreiben Sie die geänderte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Die Umsetzung der obigen Schritte ist nachfolgend dargestellt. Sie verwendet eine unformatierte Präsentation und formatiert die Schriften einer Folie.
```javascript
// Instanziieren Sie ein Presentation‑Objekt, das eine PPTX‑Datei darstellt
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Zugriff auf eine Folie anhand ihrer Position
    var slide = pres.getSlides().get_Item(0);
    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Zugriff auf den ersten Absatz
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Zugriff auf die erste Portion
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Neue Schriftarten definieren
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Neue Schriftarten der Portion zuweisen
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Schrift auf fett setzen
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Schrift auf kursiv setzen
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Schriftfarbe setzen
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // PPTX auf Festplatte schreiben
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Schriftfamilie von Text verwalten**

Eine Portion enthält Text mit einheitlicher Formatierung innerhalb eines Absatzes. Dieser Artikel zeigt, wie Aspose.Slides für Node.js via Java verwendet wird, um ein Textfeld zu erzeugen, Text hinzuzufügen und eine bestimmte Schriftart sowie weitere Eigenschaften der Schriftfamilie festzulegen. Vorgehensweise:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) hinzu.
4. Entfernen Sie den Füllstil der [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Greifen Sie auf das TextFrame der AutoShape zu.
6. Fügen Sie dem TextFrame Text hinzu.
7. Greifen Sie auf das Portion‑Objekt des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) zu.
8. Definieren Sie die für die [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) zu verwendende Schriftart.
9. Setzen Sie weitere Schrifteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe über die entsprechenden Eigenschaften des Portion‑Objekts.
10. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die Umsetzung der obigen Schritte ist nachfolgend dargestellt.
```javascript
// Instanziieren Sie ein Presentation-Objekt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // Ein AutoShape vom Typ Rechteck hinzufügen
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Entfernen Sie den mit dem AutoShape verknüpften Füllstil
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Zugriff auf das TextFrame des AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Zugriff auf die Portion des TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Schriftart für die Portion festlegen
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Fetteigenschaft der Schrift setzen
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Kursiv-Eigenschaft der Schrift setzen
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Unterstreichung der Schrift festlegen
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Schrifthöhe festlegen
    port.getPortionFormat().setFontHeight(25);
    // Farbe der Schrift festlegen
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // PPTX auf Festplatte schreiben
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Schriftgröße für Text festlegen**

Aspose.Slides ermöglicht die Auswahl einer gewünschten Schriftgröße für vorhandenen Text in einem Absatz sowie für später hinzugefügten Text.

Der nachstehende JavaScript‑Code zeigt, wie die Schriftgröße für Texte in einem Absatz festgelegt wird:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Ermittelt das erste Shape, zum Beispiel.
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // Ermittelt den ersten Absatz, zum Beispiel.
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // Setzt die Standardschriftgröße auf 20 pt für alle Textportionen im Absatz.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // Setzt die Schriftgröße auf 20 pt für die aktuellen Textportionen im Absatz.
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


## **Text rotieren**

Aspose.Slides für Node.js via Java ermöglicht es Entwicklern, Text zu rotieren. Der Text kann als [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) oder [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) dargestellt werden. Um den Text eines beliebigen TextFrames zu rotieren, folgen Sie diesen Schritten:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Shape hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) zu.
5. [Rotieren Sie den Text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. Speichern Sie die Datei auf dem Datenträger.
```javascript
// Instanz der Klasse Presentation erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rectangle hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Zugriff auf das TextFrame
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

Aspose.Slides für Node.js via Java unterstützt jetzt das Festlegen eines benutzerdefinierten Rotationswinkels für TextFrames. In diesem Abschnitt wird anhand eines Beispiels gezeigt, wie die Eigenschaft RotationAngle in Aspose.Slides gesetzt wird. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) und [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) wurden zur Klasse [ChartTextBlockFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartTextBlockFormat) und zur Klasse [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) hinzugefügt und ermöglichen das Setzen eines benutzerdefinierten Rotationswinkels für TextFrames. Vorgehensweise:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Fügen Sie der Folie ein Diagramm hinzu.
3. [Setzen Sie die Eigenschaft RotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel wird die Eigenschaft RotationAngle gesetzt.
```javascript
// Instanz der Klasse Presentation erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rectangle hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Zugriff auf das TextFrame
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


## **Zeilenabstand von Absätzen**

Aspose.Slides stellt unter [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat) die Eigenschaften `SpaceAfter`, `SpaceBefore` und `SpaceWithin` bereit, mit denen der Zeilenabstand eines Absatzes verwaltet werden kann. Die drei Eigenschaften werden folgendermaßen verwendet:

* Um den Zeilenabstand prozentual anzugeben, verwenden Sie einen positiven Wert.  
* Um den Zeilenabstand in Punkten anzugeben, verwenden Sie einen negativen Wert.

Beispiel: Ein Zeilenabstand von 16 pt wird erreicht, indem `SpaceBefore` auf ‑16 gesetzt wird.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die eine AutoShape mit Text enthält.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Paragraph zu.
5. Setzen Sie die Paragraph‑Eigenschaften.
6. Speichern Sie die Präsentation.

Der folgende JavaScript‑Code zeigt, wie der Zeilenabstand für einen Absatz festgelegt wird:
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

In diesem Abschnitt werden die verschiedenen Formatierungseigenschaften von TextFrames erläutert. Der Artikel beschreibt, wie die AutofitType‑Eigenschaft, die Anker‑Position von Text und die Drehung von Text in einer Präsentation gesetzt werden können. Aspose.Slides für Node.js via Java ermöglicht das Setzen der AutofitType‑Eigenschaft jedes TextFrames. AutofitType kann auf [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) oder [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape) gesetzt werden. Bei **Normal** bleibt die Form unverändert, während der Text angepasst wird; bei **Shape** wird die Form so modifiziert, dass nur der erforderliche Text darin enthalten ist. Vorgehensweise:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Shape hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) zu.
5. [Setzen Sie das AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) des TextFrames.
6. Speichern Sie die Datei auf dem Datenträger.
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
    // Zugriff auf das TextFrame
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

Aspose.Slides für Node.js via Java ermöglicht das Setzen des Ankers eines beliebigen TextFrames. TextAnchorType legt fest, wo der Text innerhalb der Form platziert wird. Der Anker‑Typ kann auf [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) oder [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed) gesetzt werden. Vorgehensweise:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Shape hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) zu.
5. [Setzen Sie TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) des TextFrames.
6. Speichern Sie die Datei auf dem Datenträger.
```javascript
// Instanz der Klasse Presentation erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rectangle hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Zugriff auf das TextFrame
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


## **Tabs und EffectiveTabs in einer Präsentation**

Alle Texttabulatoren werden in Pixeln angegeben.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Abbildung: 2 explizite Tabs und 2 Standard‑Tabs**|

- EffectiveTabs.ExplicitTabCount (in unserem Beispiel 2) entspricht Tabs.Count.  
- Die EffectiveTabs‑Kollektion enthält alle Tabs (aus der Tabs‑Kollektion und die Standard‑Tabs).  
- EffectiveTabs.ExplicitTabCount (in unserem Beispiel 2) entspricht Tabs.Count.  
- EffectiveTabs.DefaultTabSize (294) gibt den Abstand zwischen den Standard‑Tabs an (Tabs 3 und 4 in unserem Beispiel).  
- EffectiveTabs.GetTabByIndex(index) liefert bei index = 0 den ersten expliziten Tab (Position = 731), bei index = 1 den zweiten Tab (Position = 1241). Bei index = 2 erhalten Sie den ersten Standard‑Tab (Position = 1470) usw.  
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um den nächsten Tab nach einem Textabschnitt zu ermitteln. Beispiel: Sie haben den Text „Hello World!“. Um diesen Text korrekt zu rendern, müssen Sie zuerst die Länge von „Hello“ in Pixeln berechnen und GetTabAfterPosition mit diesem Wert aufrufen. Das Ergebnis ist die Position des nächsten Tabs, an der „world!“ gezeichnet wird.

## **Standard‑Textstil festlegen**

Wenn Sie dieselbe Standard‑Textformatierung für alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die Methode `getDefaultTextStyle` der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) verwenden und die gewünschte Formatierung festlegen. Das folgende Code‑Beispiel zeigt, wie die Standardschriftart **fett** (14 pt) für den Text aller Folien einer neuen Präsentation gesetzt wird.
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

In PowerPoint bewirkt die Anwendung des **All Caps**‑Schrifteffekts, dass der Text auf der Folie großgeschrieben angezeigt wird, selbst wenn er ursprünglich kleingeschrieben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides auslesen, gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um dies zu berücksichtigen, prüfen Sie [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) – wenn er `All` anzeigt, konvertieren Sie den zurückgegebenen String einfach in Großbuchstaben, damit Ihre Ausgabe mit dem, was Benutzer auf der Folie sehen, übereinstimmt.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei **sample2.pptx**.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der nachstehende Code‑Abschnitt zeigt, wie der Text mit dem **All Caps**‑Effekt extrahiert wird:
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

**Wie kann Text in einer Tabelle auf einer Folie geändert werden?**

Um Text in einer Tabelle zu ändern, verwenden Sie das Objekt [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Sie können durch alle Zellen der Tabelle iterieren und den Text jeder Zelle ändern, indem Sie deren `TextFrame`‑ und `ParagraphFormat`‑Eigenschaften ansprechen.

**Wie kann ein Farbverlauf auf Text in einer PowerPoint‑Folien angewendet werden?**

Verwenden Sie dazu die Eigenschaft Fill Format im [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). Setzen Sie das Fill Format auf `Gradient` und definieren Sie Start‑ und Endfarbe sowie weitere Eigenschaften wie Richtung und Transparenz, um den Verlaufseffekt auf den Text anzuwenden.