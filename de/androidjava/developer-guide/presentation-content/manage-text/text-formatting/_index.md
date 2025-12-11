---
title: PowerPoint-Text auf Android formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/androidjava/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Absatz ausrichten
- Textstil
- Text-Hintergrund
- Texttransparenz
- Zeichenabstand
- Schriftart-Eigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textfeld
- Zeilenabstand
- AutoFit-Eigenschaft
- Textfeld-Anker
- Texttabulator
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java formatieren und gestalten. Schriftarten, Farben, Ausrichtung und vieles mehr anpassen."
---

## **Text hervorheben**
Methode [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) wurde zur Schnittstelle [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht es, einen Textabschnitt mit Hintergrundfarbe zu markieren, wobei ein Textbeispiel verwendet wird, ähnlich dem Tool **Text Highlight Color** in PowerPoint 2019.

Das nachstehende Code‑Snippet zeigt, wie man diese Funktion verwendet:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // Hervorhebung aller Wörter 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// Hervorhebung aller einzelnen 'the'-Vorkommen
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Aspose bietet einen einfachen, [kostenlosen Online‑PowerPoint‑Bearbeitungsservice](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Text hervorheben mit regulärem Ausdruck**
Methode [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) wurde zur Schnittstelle [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht es, einen Textabschnitt mit Hintergrundfarbe zu markieren, wobei ein regulärer Ausdruck verwendet wird, ähnlich dem Tool **Text Highlight Color** in PowerPoint 2019.

Das nachstehende Code‑Snippet zeigt, wie man diese Funktion verwendet:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // Hervorhebung aller Wörter mit 10 Zeichen oder länger
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Hintergrundfarbe für Text festlegen**
Aspose.Slides ermöglicht es, die bevorzugte Farbe für den Hintergrund eines Textes anzugeben.

Dieser Java‑Code zeigt, wie man die Hintergrundfarbe für einen gesamten Text festlegt:
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


Dieser Java‑Code zeigt, wie man die Hintergrundfarbe nur für einen Teil eines Textes festlegt:
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
Textformatierung ist ein Schlüsselelement bei der Erstellung von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für Android via Java das Hinzufügen von Text zu Folien unterstützt, aber in diesem Beitrag sehen wir, wie man die Ausrichtung von Textabsätzen in einer Folie steuern kann. Bitte folgen Sie den nachstehenden Schritten, um Textabsätze mit Aspose.Slides für Android via Java auszurichten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalter‑Shapes in der Folie zu und casten Sie sie zu einer [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. Holen Sie den Paragraphen (der ausgerichtet werden soll) aus dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) , das von [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) bereitgestellt wird.
5. Richten Sie den Paragraphen aus. Ein Paragraph kann rechts, links, zentriert oder im Blocksatz ausgerichtet werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt:
```java
// Instanziieren eines Presentation-Objekts, das eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung in AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Text in beiden Platzhaltern ändern
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Erster Absatz der Platzhalter abrufen
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Textabsatz zentrieren
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Präsentation als PPTX-Datei schreiben
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Transparenz für Text festlegen**
Dieser Artikel demonstriert, wie man die Transparenzeigenschaft für jede Textform mit Aspose.Slides für Android via Java festlegt. Bitte folgen Sie den nachstehenden Schritten, um die Transparenz für Text zu setzen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt:
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // Transparenz auf null Prozent setzen
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zeichenabstand für Text festlegen**
Aspose.Slides ermöglicht es, den Abstand zwischen Buchstaben in einem Textfeld zu setzen. So können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen vergrößern oder verkleinern.

Dieser Java‑Code zeigt, wie man den Abstand für eine Zeile erweitert und für eine andere Zeile verkleinert:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // erweitern
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // verdichten

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **Schriftart‑Eigenschaften von Absätzen verwalten**
Präsentationen enthalten häufig sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um bestimmte Abschnitte oder Wörter hervorzuheben oder um Unternehmensrichtlinien zu entsprechen. Textformatierung hilft Benutzern, das Aussehen des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie man mit Aspose.Slides für Android via Java die Schriftart‑Eigenschaften von Textabsätzen auf Folien konfiguriert. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Erhalten Sie die Referenz einer Folie über deren Index.
3. Greifen Sie auf die Platzhalter‑Shapes in der Folie zu und casten Sie sie zu [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
4. Holen Sie den [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) aus dem [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame), das von [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) bereitgestellt wird.
5. Richten Sie den Paragraphen im Blocksatz aus.
6. Greifen Sie auf den Text‑Portion eines Paragraphen zu.
7. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart des Text‑Portion entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   2. Setzen Sie die Schriftart auf kursiv.
8. Setzen Sie die Schriftfarbe über die [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) des [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion)‑Objekts.
9. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt. Sie nimmt eine unformatierte Präsentation und formatiert die Schriften auf einer Folie.
```java
// Instanziieren eines Presentation-Objekts, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Zugriff auf eine Folie mittels ihrer Position
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung in AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Zugriff auf den ersten Absatz
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Zugriff auf den ersten Portion
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Neue Schriftarten definieren
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Neue Schriftarten dem Portion zuweisen
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Schriftart auf Fett setzen
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Schriftart auf Kursiv setzen
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Schriftfarbe setzen
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // PPTX auf die Festplatte schreiben
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftfamilie von Text verwalten**
Ein Portion wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Paragraphen zu halten. Dieser Artikel zeigt, wie man mit Aspose.Slides für Android via Java ein Textfeld mit Text erstellt und anschließend eine bestimmte Schriftart sowie weitere Eigenschaften der Schriftfamilie definiert. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Erhalten Sie die Referenz einer Folie über deren Index.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) hinzu.
4. Entfernen Sie den Füllstil, der dem [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) zugeordnet ist.
5. Greifen Sie auf das TextFrame des AutoShape zu.
6. Fügen Sie dem TextFrame etwas Text hinzu.
7. Greifen Sie auf das Portion‑Objekt zu, das dem [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) zugeordnet ist.
8. Definieren Sie die für die [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) zu verwendende Schriftart.
9. Setzen Sie weitere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe über die entsprechenden Eigenschaften des Portion‑Objekts.
10. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt.
```java
// Presentation-Objekt instanziieren
Presentation pres = new Presentation();
try {

    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Entfernen aller Füllstile, die dem AutoShape zugeordnet sind
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Auf das mit dem AutoShape verbundene TextFrame zugreifen
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Auf die mit dem TextFrame verbundene Portion zugreifen
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

    // Schriftfarbe festlegen
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX auf die Festplatte schreiben 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftgröße für Text festlegen**
Aspose.Slides ermöglicht es, die bevorzugte Schriftgröße für vorhandenen Text in einem Paragraphen sowie für später hinzuzufügenden Text festzulegen.

Dieser Java‑Code zeigt, wie man die Schriftgröße für Texte in einem Paragraphen setzt:
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

        // Setzt die Standardschriftgröße auf 20 pt für alle Textportionen im Absatz.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Setzt die Schriftgröße auf 20 pt für aktuelle Textportionen im Absatz.
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
Aspose.Slides für Android via Java erlaubt Entwicklern, Text zu rotieren. Der Text kann als [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) oder [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) angezeigt werden. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) zu.
5. [Rotate the text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Speichern Sie die Datei auf dem Datenträger.

```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Hole die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Füge ein AutoShape vom Typ Rectangle hinzu
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


## **Benutzerdefinierten Rotationswinkel für ein TextFrame festlegen**
Aspose.Slides für Android via Java unterstützt nun das Festlegen eines benutzerdefinierten Rotationswinkels für TextFrames. In diesem Thema zeigen wir anhand eines Beispiels, wie man die Eigenschaft RotationAngle in Aspose.Slides setzt. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) und [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) wurden zu den Schnittstellen [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) und [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) hinzugefügt und ermöglichen das Setzen eines benutzerdefinierten Rotationswinkels für TextFrames. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Fügen Sie der Folie ein Diagramm hinzu.
3. [Set RotationAngle property](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Im Beispiel unten setzen wir die RotationAngle‑Eigenschaft.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rectangle hinzufügen
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Paragraph-Objekt für das TextFrame erstellen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Portion-Objekt für den Paragraphen erstellen
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


## **Zeilenabstand eines Paragraphen**
Aspose.Slides stellt Eigenschaften unter [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` und `SpaceWithin`—zur Verfügung, mit denen Sie den Zeilenabstand für einen Paragraphen verwalten können. Die drei Eigenschaften werden folgendermaßen verwendet:

* Um den Zeilenabstand für einen Paragraphen in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Paragraphen in Punkten anzugeben, verwenden Sie einen negativen Wert.

Beispiel: Sie können einen Zeilenabstand von 16 pt für einen Paragraphen anwenden, indem Sie die Eigenschaft `SpaceBefore` auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Paragraphen an:

1. Laden Sie eine Präsentation, die ein AutoShape mit Text enthält.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Paragraphen zu.
5. Setzen Sie die Paragraph‑Eigenschaften.
6. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie man den Zeilenabstand für einen Paragraphen festlegt:
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Referenz einer Folie über ihren Index erhalten
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Zugriff auf das TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Zugriff auf den Paragraphen
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Eigenschaften des Paragraphen setzen
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Präsentation speichern
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **AutofitType‑Eigenschaft für ein TextFrame festlegen**
In diesem Thema untersuchen wir verschiedene Formatierungseigenschaften von TextFrames. Dieser Artikel behandelt das Setzen der AutofitType‑Eigenschaft, des Ankers und das Rotieren von Text in einer Präsentation. Aspose.Slides für Android via Java erlaubt Entwicklern, die AutofitType‑Eigenschaft eines beliebigen TextFrames festzulegen. AutofitType kann auf [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) oder [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) gesetzt werden. Bei [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) bleibt die Form unverändert, während der Text angepasst wird, ohne die Form zu verändern. Bei [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) wird die Form so geändert, dass nur der erforderliche Text enthalten ist. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)class.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) zu.
5. [Set the AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) des TextFrames.
6. Speichern Sie die Datei auf dem Datenträger.

```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rectangle hinzufügen
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


## **Anker eines TextFrames festlegen**
Aspose.Slides für Android via Java erlaubt Entwicklern, den Anker eines beliebigen TextFrames zu setzen. TextAnchorType gibt an, wo der Text innerhalb der Form platziert wird. AnchorType kann auf [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) oder [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed) gesetzt werden. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) zu.
5. [Set TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) des TextFrames.
6. Speichern Sie die Datei auf dem Datenträger.

```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Die erste Folie holen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ein AutoShape vom Typ Rectangle hinzufügen
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
- EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.  
- EffectiveTabs‑Sammlung enthält alle Tabs (aus der Tabs‑Sammlung und Standard‑Tabs).  
- EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.  
- EffectiveTabs.DefaultTabSize (294) gibt den Abstand zwischen Standard‑Tabs (3 und 4 in unserem Beispiel) an.  
- EffectiveTabs.GetTabByIndex(index) mit index = 0 liefert den ersten expliziten Tab (Position = 731), index = 1 den zweiten Tab (Position = 1241). Ein Aufruf mit index = 2 gibt den ersten Standard‑Tab (Position = 1470) zurück usw.  
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um den nächsten Tab nach einem Text zu erhalten. Beispiel: Sie haben den Text „Hello World!“. Um diesen Text zu rendern, müssen Sie wissen, wo Sie das Wort „world!“ beginnen. Zuerst berechnen Sie die Länge von „Hello“ in Pixel und rufen GetTabAfterPosition mit diesem Wert auf. Sie erhalten die Position des nächsten Tabs, um „world!“ zu zeichnen.

## **Standard‑Textstil festlegen**
Wenn Sie denselben Standard‑Textformatierungsstil für alle Textelemente einer Präsentation auf einmal anwenden möchten, können Sie die Methode `getDefaultTextStyle` des [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/)‑Interfaces verwenden und die gewünschte Formatierung festlegen. Das nachstehende Code‑Beispiel zeigt, wie man die Standardschriftart **fett** (14 pt) für den Text auf allen Folien einer neuen Präsentation setzt.
```java
Presentation presentation = new Presentation();
try {
    // Das Absatzformat der obersten Ebene holen.
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


## **Text mit All-Caps‑Effekt extrahieren**
In PowerPoint bewirkt der **All Caps**‑Schrifteffekt, dass Text in Großbuchstaben angezeigt wird, obwohl er ursprünglich klein geschrieben wurde. Beim Abrufen eines solchen Textabschnitts mit Aspose.Slides gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um dies zu handhaben, prüfen Sie [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) – wenn er `All` angibt, konvertieren Sie den zurückgegebenen String einfach in Großbuchstaben, damit die Ausgabe dem entspricht, was Benutzer auf der Folie sehen.

Betrachten wir die folgende Textbox auf der ersten Folie der Datei sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Das nachstehende Code‑Beispiel zeigt, wie man den Text mit dem **All Caps**‑Effekt extrahiert:
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


Output:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, müssen Sie das [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)‑Interface verwenden. Sie können über alle Zellen der Tabelle iterieren und den Text in jeder Zelle ändern, indem Sie auf deren `TextFrame`‑ und `ParagraphFormat`‑Eigenschaften zugreifen.

**Wie wendet man Farbverlauf auf Text in einer PowerPoint‑Folien an?**

Um Farbverlauf auf Text anzuwenden, nutzen Sie die `getFillFormat`‑Methode in [BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/). Setzen Sie das `FilFormat` auf `Gradient` und definieren Sie die Start‑ und Endfarben des Verlaufs sowie weitere Eigenschaften wie Richtung und Transparenz, um den Verlaufseffekt auf den Text zu erzeugen.