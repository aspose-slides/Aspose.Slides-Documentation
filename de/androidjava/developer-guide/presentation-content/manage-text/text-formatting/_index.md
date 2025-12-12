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
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schriftarteigenschaften
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
- Android
- Java
- Aspose.Slides
description: "Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java formatieren und stilisieren. Schriften, Farben, Ausrichtung und mehr anpassen."
---

## **Text hervorheben**
Methode [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) wurde zur Schnittstelle [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht es, einen Textabschnitt mit Hintergrundfarbe anhand eines Textbeispiels hervorzuheben, ähnlich dem Tool „Text-Hervorhebungsfarbe“ in PowerPoint 2019.

Das nachstehende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // Hervorhebung aller Wörter 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// Hervorhebung aller einzelnen 'the' Vorkommen
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Aspose bietet einen einfachen, [kostenlosen Online‑PowerPoint‑Bearbeitungsservice](https://products.aspose.app/slides/editor) an
{{% /alert %}} 

## **Text hervorheben mithilfe eines regulären Ausdrucks**
Methode [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) wurde zur Schnittstelle [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht es, einen Textabschnitt mit Hintergrundfarbe anhand eines regulären Ausdrucks hervorzuheben, ähnlich dem Tool „Text-Hervorhebungsfarbe“ in PowerPoint 2019.

Das nachstehende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // Hervorhebung aller Wörter mit 10 Symbolen oder länger
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Hintergrundfarbe für Text festlegen**
Aspose.Slides ermöglicht es, die bevorzugte Farbe für den Hintergrund eines Textes festzulegen.

Dieser Java‑Code zeigt, wie die Hintergrundfarbe für einen gesamten Text festgelegt wird:
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


Dieser Java‑Code zeigt, wie die Hintergrundfarbe nur für einen Teil eines Textes festgelegt wird:
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
Textformatierung ist ein Schlüsselelement beim Erstellen von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für Android via Java das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema sehen wir, wie die Ausrichtung von Textabsätzen auf einer Folie gesteuert werden kann. Bitte folgen Sie den untenstehenden Schritten, um Textabsätze mit Aspose.Slides für Android via Java auszurichten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Greifen Sie auf die Platzhalter‑Shapes der Folie zu und casten Sie sie zu einem [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. Holen Sie den Paragraph (der ausgerichtet werden soll) aus dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) des [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Richten Sie den Paragraphen aus. Ein Paragraph kann rechts, links, zentriert oder Blocksatz ausgerichtet werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt.
```java
// Instanziiere ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Den Text in beiden Platzhaltern ändern
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Abrufen des ersten Absatzes der Platzhalter
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Den Textabsatz zentrieren
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Die Präsentation als PPTX-Datei schreiben
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Transparenz für Text festlegen**
Dieser Artikel zeigt, wie die Transparenzeigenschaft für jede Textform mit Aspose.Slides für Android via Java festgelegt wird. Um die Transparenz für Text festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt.
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
Aspose.Slides ermöglicht es, den Abstand zwischen Buchstaben in einem Textfeld festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen vergrößern oder verkleinern.

Dieser Java‑Code zeigt, wie der Abstand für eine Textzeile vergrößert und für eine andere verkleinert wird:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // erweitern
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // verdichten

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **Schriftarteigenschaften von Paragraphen verwalten**
Präsentationen enthalten in der Regel sowohl Text als auch Bilder. Der Text kann auf verschiedene Arten formatiert werden, um bestimmte Abschnitte und Wörter hervorzuheben oder um Unternehmensrichtlinien zu entsprechen. Textformatierung hilft Benutzern, das Erscheinungsbild des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Aspose.Slides für Android via Java verwendet wird, um die Schrifteigenschaften von Textparagraphen auf Folien zu konfigurieren. So verwalten Sie die Schrifteigenschaften eines Paragraphen mit Aspose.Slides für Android via Java:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Holen Sie die Referenz einer Folie über ihren Index.
1. Greifen Sie auf die Platzhalter‑Shapes in der Folie zu und casten Sie sie zu [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. Holen Sie den [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) aus dem [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) der von [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. Setzen Sie den Paragraphen auf Blocksatz.
1. Greifen Sie auf den Text‑Portion eines Paragraphen zu.
1. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart der Text‑Portion entsprechend.
   1. Setzen Sie die Schriftart fett.
   1. Setzen Sie die Schriftart kursiv.
1. Setzen Sie die Schriftfarbe mittels [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--).
1. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt. Sie nimmt eine unveränderte Präsentation und formatiert die Schriftarten auf einer der Folien.
```java
// Instanziiere ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Zugriff auf eine Folie über ihre Position
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

    //PPTX auf die Festplatte schreiben
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftfamilie von Text verwalten**
Ein Portion wird verwendet, um Text mit ähnlichem Formatstil in einem Paragraphen zu halten. Dieser Artikel zeigt, wie Aspose.Slides für Android via Java ein Textfeld mit Text erstellt und anschließend eine bestimmte Schrift sowie weitere Eigenschaften der Schriftfamilie definiert. So erstellen Sie ein Textfeld und setzen die Schriftarteigenschaften des darin enthaltenen Textes:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) hinzu.
4. Entfernen Sie den Füllstil des [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. Greifen Sie auf das TextFrame des AutoShape zu.
6. Fügen Sie dem TextFrame Text hinzu.
7. Greifen Sie auf das Portion‑Objekt zu, das mit dem [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) verknüpft ist.
8. Definieren Sie die für die [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) zu verwendende Schrift.
9. Setzen Sie weitere Schrifteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mithilfe der entsprechenden Eigenschaften des Portion‑Objekts.
10. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt.
```java
// Präsentation instanziieren
Presentation pres = new Presentation();
try {

    // Erste Folie erhalten
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Alle Füllstile des AutoShape entfernen
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Auf das mit dem AutoShape verbundene TextFrame zugreifen
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Auf die mit dem TextFrame verbundene Portion zugreifen
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Schriftart für die Portion festlegen
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Fett-Eigenschaft der Schrift festlegen
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Kursiv-Eigenschaft der Schrift festlegen
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Unterstreichen-Eigenschaft der Schrift festlegen
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

Dieser Java‑Code zeigt, wie die Schriftgröße für in einem Paragraphen enthaltene Texte festgelegt wird:
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
Aspose.Slides für Android via Java ermöglicht Entwicklern, Text zu drehen. Der Text kann als [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) oder [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) angezeigt werden. Um den Text eines beliebigen TextFrames zu drehen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) zu.
5. [Text rotieren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Speichern Sie die Datei auf dem Datenträger.
```java
// Erstelle eine Instanz der Klasse Presentation
Presentation pres = new Presentation();
try {
    // Hole die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Füge eine AutoShape vom Typ Rectangle hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Füge dem Rectangle ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Erstelle das Paragraph-Objekt für das TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Erstelle ein Portion-Objekt für den Absatz
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


## **Benutzerdefinierten Rotationswinkel für einen TextFrame festlegen**
Aspose.Slides für Android via Java unterstützt jetzt das Festlegen eines benutzerdefinierten Rotationswinkels für TextFrames. In diesem Thema sehen wir anhand eines Beispiels, wie die Eigenschaft RotationAngle in Aspose.Slides gesetzt wird. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) und [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) wurden zu den Schnittstellen [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) und [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) hinzugefügt und ermöglichen das Festlegen eines benutzerdefinierten Rotationswinkels für TextFrames. Um den RotationAngle zu setzen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Fügen Sie der Folie ein Diagramm hinzu.
3. [RotationAngle‑Eigenschaft festlegen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel setzen wir die RotationAngle‑Eigenschaft.
```java
// Erstelle eine Instanz der Klasse Presentation
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Füge eine AutoShape vom Typ Rectangle hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Füge dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Erstelle das Paragraph-Objekt für das TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Erstelle ein Portion-Objekt für den Absatz
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
Aspose.Slides stellt Eigenschaften im [`ParagraphFormat`]‑Objekt bereit—`SpaceAfter`, `SpaceBefore` und `SpaceWithin`—die es ermöglichen, den Zeilenabstand für einen Paragraphen zu verwalten. Die drei Eigenschaften werden folgendermaßen verwendet:

* Um den Zeilenabstand für einen Paragraphen in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Paragraphen in Punkten anzugeben, verwenden Sie einen negativen Wert.

Beispielsweise können Sie einen Zeilenabstand von 16 pt für einen Paragraphen anwenden, indem Sie die Eigenschaft `SpaceBefore` auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Paragraphen an:

1. Laden Sie eine Präsentation, die ein AutoShape mit Text enthält.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Paragraphen zu.
5. Setzen Sie die Paragraph‑Eigenschaften.
6. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie der Zeilenabstand für einen Paragraphen festgelegt wird:
```java
// Erstelle eine Instanz der Klasse Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Erhalte die Referenz einer Folie anhand ihres Index
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Zugriff auf das TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Zugriff auf den Paragraph
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Setzt Eigenschaften des Paragraph
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Präsentation speichern
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **AutofitType‑Eigenschaft für einen TextFrame festlegen**
In diesem Thema untersuchen wir die verschiedenen Formatierungseigenschaften von TextFrames. Dieser Artikel behandelt das Festlegen der AutofitType‑Eigenschaft von TextFrames, das Ankerverhalten von Text und das Drehen von Text in einer Präsentation. Aspose.Slides für Android via Java ermöglicht es Entwicklern, die AutofitType‑Eigenschaft eines beliebigen TextFrames festzulegen. AutofitType kann auf [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) oder [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) gesetzt werden. Wenn auf [Normal] gesetzt, bleibt die Form unverändert, während der Text angepasst wird, ohne die Form zu verändern; wird AutofitType auf [Shape] gesetzt, wird die Form so modifiziert, dass nur der erforderliche Text darin enthalten ist. So setzen Sie die AutofitType‑Eigenschaft eines TextFrames, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) zu.
5. [AutofitType festlegen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-).
6. Speichern Sie die Datei auf dem Datenträger.
```java
// Eine Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rectangle hinzufügen
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // TextFrame zum Rectangle hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Paragraph-Objekt für das TextFrame erstellen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Portion-Objekt für den Paragraph erstellen
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
Aspose.Slides für Android via Java ermöglicht Entwicklern, den Anker eines beliebigen TextFrames zu setzen. TextAnchorType gibt an, wo der Text in der Form platziert wird. AnchorType kann auf [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) oder [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed) gesetzt werden. So setzen Sie den Anker eines beliebigen TextFrames, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) zu.
5. [TextAnchorType festlegen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-).
6. Speichern Sie die Datei auf dem Datenträger.
```java
// Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    // Erste Folie holen 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShape vom Typ Rectangle hinzufügen
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Paragraph-Objekt für das TextFrame erstellen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Portion-Objekt für den Paragraph erstellen
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

- EffectiveTabs.ExplicitTabCount (2 in unserem Beispiel) ist gleich Tabs.Count.
- Die EffectiveTabs‑Kollektion enthält alle Tabs (aus der Tabs‑Kollektion und den Standard‑Tabs).
- EffectiveTabs.ExplicitTabCount (2 in unserem Beispiel) ist gleich Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) gibt den Abstand zwischen den Standard‑Tabs (3 und 4 in unserem Beispiel) an.
- EffectiveTabs.GetTabByIndex(index) mit index = 0 liefert den ersten expliziten Tab (Position = 731), index = 1 den zweiten Tab (Position = 1241). Wenn Sie den nächsten Tab mit index = 2 anfordern, wird der erste Standard‑Tab (Position = 1470) usw. zurückgegeben.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um die nächste Tabulation nach etwas Text zu erhalten. Beispiel: Sie haben den Text „Hello World!“. Um diesen Text zu rendern, müssen Sie wissen, wo Sie das Wort „world!“ beginnen zu zeichnen. Zuerst berechnen Sie die Länge von „Hello“ in Pixel und rufen GetTabAfterPosition mit diesem Wert auf. Sie erhalten die nächste Tab‑Position, um „world!“ zu zeichnen.

## **Standard-Textstil festlegen**
Wenn Sie dieselbe Standard‑Textformatierung gleichzeitig auf alle Textelemente einer Präsentation anwenden müssen, können Sie die Methode `getDefaultTextStyle` aus dem [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/)‑Interface verwenden und die bevorzugte Formatierung festlegen. Das nachstehende Code‑Beispiel zeigt, wie der Standard‑Fettschrift‑Font (14 pt) für den Text auf allen Folien einer neuen Präsentation festgelegt wird.
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
In PowerPoint lässt das Anwenden des **All Caps**‑Schrifteffekts Text in Großbuchstaben auf der Folie erscheinen, selbst wenn er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides abrufen, liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um dies zu handhaben, prüfen Sie [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) — wenn er `All` angibt, konvertieren Sie den zurückgegebenen String einfach in Großbuchstaben, damit Ihre Ausgabe dem entspricht, was Benutzer auf der Folie sehen.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei sample2.pptx.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der nachstehende Code‑Beispiel zeigt, wie der Text mit dem **All Caps**‑Effekt extrahiert wird:
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


```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, müssen Sie das [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)‑Interface verwenden. Sie können durch alle Zellen der Tabelle iterieren und den Text in jeder Zelle ändern, indem Sie auf deren `TextFrame`‑ und `ParagraphFormat`‑Eigenschaften zugreifen.

**Wie kann man Verlauffarbe auf Text in einer PowerPoint‑Folien anwenden?**

Um Verlauffarbe auf Text anzuwenden, verwenden Sie die `getFillFormat`‑Methode in [BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/). Setzen Sie das `FilFormat` auf `Gradient`, wobei Sie die Start‑ und Endfarben des Farbverlaufs sowie weitere Eigenschaften wie Richtung und Transparenz definieren, um den Verlaufseffekt auf den Text zu erzeugen.