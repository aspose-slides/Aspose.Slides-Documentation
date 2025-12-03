---
title: PowerPoint-Text in Java formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/java/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schriftart-Eigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textrahmen
- Zeilenabstand
- Autofit-Eigenschaft
- Textrahmen-Anker
- Texttabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java. Passen Sie Schriftarten, Farben, Ausrichtung und mehr an."
---

## **Text hervorheben**
Methode [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) wurde zur Schnittstelle [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe anhand eines Textbeispiels, ähnlich dem Werkzeug **Textmarkerfarbe** in PowerPoint 2019.

Das folgende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // Alle Wörter 'important' hervorheben
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions); // Alle einzelnen Vorkommen von 'the' hervorheben
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

Aspose bietet einen einfachen, [kostenlosen Online‑PowerPoint‑Editor](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Text mit regulärem Ausdruck hervorheben**

Methode [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) wurde zur Schnittstelle [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe anhand eines regulären Ausdrucks, ähnlich dem Werkzeug **Textmarkerfarbe** in PowerPoint 2019.

Das folgende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // Alle Wörter mit 10 Symbolen oder länger hervorheben
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Hintergrundfarbe für Text festlegen**

Aspose.Slides ermöglicht das Festlegen einer gewünschten Hintergrundfarbe für Text.

Der folgende Java‑Code zeigt, wie die Hintergrundfarbe für den gesamten Text festgelegt wird:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);

    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);

    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    StreamSupport.stream(autoShape.getTextFrame().getParagraphs().spliterator(), false)
            .map(p -> p.getPortions())
            .forEach(c -> c.forEach(ic -> ic.getPortionFormat().getHighlightColor().setColor(Color.BLUE)));

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


Der folgende Java‑Code zeigt, wie die Hintergrundfarbe nur für einen Teil des Textes festgelegt wird:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);
    
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    
    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    Optional<IPortion> redPortion = StreamSupport.stream(autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false)
            .filter(p -> p.getText().contains("Red"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Textabsätze ausrichten**

Textformatierung ist ein Schlüssel‑Element beim Erstellen von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für Java das Hinzufügen von Text zu Folien unterstützt. In diesem Thema zeigen wir, wie die Ausrichtung von Textabsätzen in einer Folie gesteuert werden kann. Bitte folgen Sie den nachstehenden Schritten, um Textabsätze mit Aspose.Slides für Java auszurichten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Greifen Sie auf die Platzhalter‑Shapes der Folie zu und casten Sie sie zu einem [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. Erhalten Sie den Paragraph (der ausgerichtet werden soll) aus dem [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) des [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Richten Sie den Paragraph aus. Ein Paragraph kann rechts, links, zentriert oder Blocksatz ausgerichtet werden.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der genannten Schritte finden Sie unten.
```java
// Eine Presentation-Objektinstanz erzeugen, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Text in beiden Platzhaltern ändern
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Den ersten Absatz der Platzhalter abrufen
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Den Textabsatz zentrieren
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Präsentation als PPTX-Datei schreiben
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Transparenz für Text festlegen**
Dieser Artikel demonstriert, wie die Eigenschaft **Transparency** für beliebige Text‑Shapes mithilfe von Aspose.Slides für Java gesetzt wird. Befolgen Sie dazu bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der genannten Schritte finden Sie unten.
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // Transparenz auf 0 Prozent setzen
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zeichenabstand für Text festlegen**

Aspose.Slides ermöglicht das Festlegen des Abstands zwischen Zeichen in einem Textfeld. So können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen vergrößern oder verkleinern.

Der folgende Java‑Code zeigt, wie der Abstand für eine Zeile vergrößert und für eine andere verkleinert wird:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // erweitern
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // verdichten

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **Schriftart‑Eigenschaften eines Paragraphen verwalten**

Präsentationen enthalten meist Text und Bilder. Der Text kann auf verschiedene Weise formatiert werden, etwa um bestimmte Abschnitte hervorzuheben oder um Unternehmensrichtlinien zu entsprechen. Die Textformatierung hilft Benutzern, das Aussehen des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Sie mit Aspose.Slides für Java die Schriftart‑Eigenschaften von Paragraphen auf Folien konfigurieren können. Vorgehensweise:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Holen Sie sich die Referenz einer Folie über deren Index.
1. Greifen Sie auf die Platzhalter‑Shapes der Folie zu und casten Sie sie zu [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Erhalten Sie den [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) aus dem [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame), das von [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) bereitgestellt wird.
1. Richten Sie den Paragraph im Blocksatz aus.
1. Greifen Sie auf den Text‑Portion eines Paragraphen zu.
1. Definieren Sie die Schriftart über **FontData** und setzen Sie die Schriftart der Portion entsprechend.
   1. Setzen Sie die Schriftart auf **fett**.
   1. Setzen Sie die Schriftart auf **kursiv**.
1. Setzen Sie die Schriftfarbe über die Methode **getFillFormat** des [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion)-Objekts.
1. Schreiben Sie die geänderte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/)-Datei.

Die Implementierung der genannten Schritte finden Sie unten. Sie verwendet eine unformatierte Präsentation und formatiert die Schriftarten einer Folie.
```java
// Instanziieren eines Presentation-Objekts, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Zugriff auf eine Folie mittels ihrer Position
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Zugriff auf den ersten Absatz
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Zugriff auf die erste Portion
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Neue Schriftarten definieren
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Neue Schriftarten der Portion zuweisen
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Schriftart auf fett setzen
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Schriftart auf kursiv setzen
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Schriftfarbe festlegen
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    //Schreibe die PPTX auf die Festplatte
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftfamilie des Textes verwalten**
Eine Portion wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Paragraphen zu halten. Dieser Artikel zeigt, wie Sie mit Aspose.Slides für Java ein Textfeld erstellen, Text hinzufügen und eine bestimmte Schriftart sowie weitere Eigenschaften der Schriftfamilie festlegen. Vorgehensweise:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) hinzu.
4. Entfernen Sie den Füllstil des [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. Greifen Sie auf das TextFrame des AutoShape zu.
6. Fügen Sie dem TextFrame Text hinzu.
7. Greifen Sie auf das Portion‑Objekt des [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) zu.
8. Definieren Sie die Schriftart für die [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. Setzen Sie weitere Schrift‑Eigenschaften wie **fett**, **kursiv**, **unterstrichen**, **Farbe** und **Größe** über die entsprechenden Eigenschaften des Portion‑Objekts.
10. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der genannten Schritte finden Sie unten.
```java
// Präsentationinstanz erzeugen
Presentation pres = new Presentation();
try {

    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Alle Füllstile des AutoShape entfernen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Auf das mit dem AutoShape verknüpfte TextFrame zugreifen
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Auf die mit dem TextFrame verknüpfte Portion zugreifen
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Schriftart für die Portion festlegen
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Fettdruck-Eigenschaft der Schrift festlegen
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Kursiv-Eigenschaft der Schrift festlegen
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Unterstreichungs-Eigenschaft der Schrift festlegen
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Schriftgröße festlegen
    port.getPortionFormat().setFontHeight(25);

    // Farbe der Schrift festlegen
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX auf Festplatte schreiben 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftgröße für Text festlegen**

Aspose.Slides ermöglicht es, die gewünschte Schriftgröße für vorhandenen Text in einem Paragraphen sowie für künftig hinzuzufügenden Text festzulegen.

Der folgende Java‑Code zeigt, wie die Schriftgröße für Texte in einem Paragraphen gesetzt wird:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Holt das erste Shape, zum Beispiel.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Holt den ersten Absatz, zum Beispiel.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Setzt die Standard‑Schriftgröße auf 20 pt für alle Textportionen im Absatz.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Setzt die Schriftgröße auf 20 pt für die aktuellen Textportionen im Absatz.
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Textrotation festlegen**

Aspose.Slides für Java ermöglicht es Entwicklern, Text zu drehen. Text kann als [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) oder [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) dargestellt werden. Vorgehensweise:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) zu.
5. [Drehen Sie den Text](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Speichern Sie die Datei auf dem Datenträger.

```java
// Eine Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    // Erhalte die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Füge eine AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Füge dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Erstelle das Paragraph-Objekt für das TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Erstelle ein Portion-Objekt für den Paragraphen
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Präsentation speichern
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Benutzerdefinierten Rotationswinkel für TextFrame festlegen**
Aspose.Slides für Java unterstützt jetzt das Setzen eines benutzerdefinierten Rotationswinkels für TextFrames. In diesem Thema wird anhand eines Beispiels gezeigt, wie die Eigenschaft **RotationAngle** in Aspose.Slides gesetzt wird. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) und [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) wurden zu den Schnittstellen [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) und [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) hinzugefügt und ermöglichen das Setzen eines benutzerdefinierten Rotationswinkels für TextFrames. Vorgehensweise:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Fügen Sie der Folie ein Diagramm hinzu.
3. [Setzen Sie die Eigenschaft RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel wird die Eigenschaft **RotationAngle** gesetzt.
```java
// Eine Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);

    // Füge eine AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Füge dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Erstelle das Paragraph-Objekt für das TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Erstelle ein Portion-Objekt für den Paragraphen
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Präsentation speichern
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zeilenabstand von Paragraphen**
Aspose.Slides stellt Eigenschaften unter [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat) – `SpaceAfter`, `SpaceBefore` und `SpaceWithin` – bereit, mit denen der Zeilenabstand eines Paragraphen verwaltet werden kann. Die drei Eigenschaften werden folgendermaßen verwendet:

* Um den Zeilenabstand in Prozent anzugeben, einen positiven Wert verwenden.  
* Um den Zeilenabstand in Punkten anzugeben, einen negativen Wert verwenden.

Beispiel: Einen Zeilenabstand von 16 pt für einen Paragraphen erhalten Sie, indem Sie die Eigenschaft `SpaceBefore` auf ‑16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Paragraphen an:

1. Laden Sie eine Präsentation, die ein AutoShape mit Text enthält.
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Paragraphen zu.
5. Setzen Sie die Paragraph‑Eigenschaften.
6. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie der Zeilenabstand für einen Paragraphen festgelegt wird:
```java
// Eine Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Eine Folienreferenz anhand ihres Index erhalten
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Auf das TextFrame zugreifen
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Auf den Paragraphen zugreifen
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Eigenschaften des Paragraphen festlegen
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Präsentation speichern
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **AutofitType‑Eigenschaft für TextFrame festlegen**
In diesem Thema werden verschiedene Formatierungseigenschaften von TextFrames behandelt. Der Artikel beschreibt, wie die **AutofitType**‑Eigenschaft, die Ankerposition des Textes und die Rotation von Text in einer Präsentation gesetzt werden. Aspose.Slides für Java ermöglicht das Setzen der **AutofitType**‑Eigenschaft für jedes TextFrame. **AutofitType** kann auf [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) oder [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape) gesetzt werden. Bei **Normal** bleibt die Form unverändert, während der Text angepasst wird; bei **Shape** wird die Form so geändert, dass nur der notwendige Text enthalten ist. Vorgehensweise:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) zu.
5. [Setzen Sie die AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) des TextFrames.
6. Speichern Sie die Datei auf dem Datenträger.

```java
// Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Paragraph-Objekt für das TextFrame erstellen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Portion-Objekt für den Paragraphen erstellen
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Präsentation speichern
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ankerposition für TextFrame festlegen**
Aspose.Slides für Java ermöglicht das Setzen der Ankerposition eines beliebigen TextFrames. **TextAnchorType** gibt an, wo der Text innerhalb der Form platziert wird. Mögliche Werte: [Top](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) oder [Distributed](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). Vorgehensweise:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Setzen Sie TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) des TextFrames.
6. Speichern Sie die Datei auf dem Datenträger.

```java
// Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Paragraph-Objekt für das TextFrame erstellen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Portion-Objekt für den Paragraphen erstellen
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Präsentation speichern
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Tabs und EffectiveTabs in einer Präsentation**
Alle Texttabulatoren werden in Pixel angegeben.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Abbildung: 2 explizite Tabs und 2 Standard‑Tabs**|
- `EffectiveTabs.ExplicitTabCount` (2 in unserem Beispiel) entspricht `Tabs.Count`.
- Die `EffectiveTabs`‑Sammlung enthält alle Tabs (aus der `Tabs`‑Sammlung und Standard‑Tabs).
- `EffectiveTabs.DefaultTabSize` (294) gibt den Abstand zwischen Standard‑Tabs (3 und 4 im Beispiel) an.
- `EffectiveTabs.GetTabByIndex(index)` mit `index = 0` liefert den ersten expliziten Tab (Position = 731), `index = 1` den zweiten (Position = 1241). Ein Aufruf mit `index = 2` liefert den ersten Standard‑Tab (Position = 1470) usw.
- `EffectiveTabs.GetTabAfterPosition(pos)` ermittelt den nächsten Tab nach einem Text. Beispiel: Text „Hello World!“. Um den Text zu rendern, muss zunächst die Breite von „Hello“ in Pixeln berechnet und `GetTabAfterPosition` mit diesem Wert aufgerufen werden. Das Ergebnis ist die Position des nächsten Tabs für „World!“.

## **Standard‑Textstil festlegen**

Wenn Sie denselben Standard‑Textformatierungsstil auf alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die Methode `getDefaultTextStyle` des [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/)‑Interfaces verwenden und das gewünschte Format festlegen. Das folgende Code‑Beispiel zeigt, wie die Standardschriftart **fett** (14 pt) für den Text aller Folien in einer neuen Präsentation gesetzt wird.
```java
Presentation presentation = new Presentation();
try {
    // Holt das Absatzformat der obersten Ebene.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("DefaultTextStyle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt der Schriftart‑Effekt **All Caps**, dass Text in Großbuchstaben angezeigt wird, auch wenn er ursprünglich klein geschrieben wurde. Beim Abrufen einer solchen Textportion mit Aspose.Slides liefert die Bibliothek den exakt eingegebenen Text. Um dies zu berücksichtigen, prüfen Sie `TextCapType` – wenn er `All` anzeigt, konvertieren Sie die zurückgegebene Zeichenkette einfach in Großbuchstaben, damit Ihre Ausgabe dem entspricht, was der Benutzer auf der Folie sieht.

Angenommen, wir haben die folgende Textbox auf der ersten Folie der Datei **sample2.pptx**.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das folgende Code‑Beispiel zeigt, wie der Text mit dem **All Caps**‑Effekt extrahiert wird:
```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    IPortion textPortion = paragraph.getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

Um Text in einer Tabelle zu ändern, verwenden Sie das Interface [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Durchlaufen Sie alle Zellen der Tabelle und ändern Sie den Text jeder Zelle, indem Sie auf deren `TextFrame`‑ und `ParagraphFormat`‑Eigenschaften zugreifen.

**Wie kann einem Text in einer PowerPoint‑Folie ein Farbverlauf zugewiesen werden?**

Verwenden Sie die Methode `getFillFormat` des [BasePortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/). Setzen Sie `FillFormat` auf `Gradient` und definieren Sie die Start‑ und Endfarben sowie weitere Eigenschaften wie Richtung und Transparenz, um den Farbverlauf auf den Text anzuwenden.