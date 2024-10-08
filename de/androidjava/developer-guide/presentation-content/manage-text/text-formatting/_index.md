---
title: Textformatierung
type: docs
weight: 50
url: /de/androidjava/text-formatting/
keywords:
- Text hervorheben
- Regulärer Ausdruck
- Textabsätze ausrichten
- Texttransparenz
- Absatzschriftarten
- Schriftfamilie
- Textrotation
- Benutzerdefinierte Winkelrotation
- Textrahmen
- Zeilenabstand
- Autofit-Eigenschaft
- Textrahmenanker
- Texttabulator
- Standardtextstil
- Java
- Aspose.Slides für Android über Java
description: "Verwalten und Bearbeiten von Text- und Textrahmeneinstellungen in Java"
---

## **Text Hervorheben**
Die Methode [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) wurde zur Schnittstelle [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht es, einen Teil des Textes mit einer Hintergrundfarbe hervorzuheben, ähnlich dem Werkzeug „Text hervorheben“ in PowerPoint 2019.

Der untenstehende Codeausschnitt zeigt, wie man diese Funktion verwendet:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // hebt alle Wörter 'wichtig' hervor
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// hebt alle separaten 'the' Vorkommen hervor
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Aspose bietet einen einfachen, [kostenlosen Online-PowerPoint-Bearbeitungsservice](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Text Hervorheben mit Regulärem Ausdruck**

Die Methode [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) wurde zur Schnittstelle [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) hinzugefügt.

Sie ermöglicht es, einen Teil des Textes mit einer Hintergrundfarbe unter Verwendung von Regex hervorzuheben, ähnlich dem Werkzeug „Text hervorheben“ in PowerPoint 2019.

Der untenstehende Codeausschnitt zeigt, wie man diese Funktion verwendet:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // hebt alle Wörter mit 10 Symbolen oder mehr hervor
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hintergrundfarbe für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Farbe für den Hintergrund eines Textes anzugeben.

Dieser Java-Code zeigt Ihnen, wie man die Hintergrundfarbe für einen gesamten Text festlegt:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Schwarz");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Rot ");

    Portion portion3 = new Portion("Schwarz");
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

Dieser Java-Code zeigt Ihnen, wie man die Hintergrundfarbe nur für einen Teil eines Textes festlegt:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Schwarz");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Rot ");

    Portion portion3 = new Portion("Schwarz");
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
            .filter(p -> p.getText().contains("Rot"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Textabsätze Ausrichten**

Die Textformatierung ist eines der Schlüsselelemente bei der Erstellung jeglicher Art von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für Android über Java das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema werden wir sehen, wie wir die Ausrichtung der Textabsätze in einer Folie steuern können. Bitte folgen Sie den folgenden Schritten, um Textabsätze mit Aspose.Slides für Android über Java auszurichten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und typisieren Sie sie als [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. Holen Sie sich den Absatz (der ausgerichtet werden soll) aus dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) von [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Richten Sie den Absatz aus. Ein Absatz kann nach rechts, links, zentriert oder im Blocksatz ausgerichtet werden.
6. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typcasting zu AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Ändern Sie den Text in beiden Platzhaltern
    tf1.setText("Zentrieren von Aspose");
    tf2.setText("Zentrieren von Aspose");

    // Erhalten des ersten Absatzes der Platzhalter
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Ausrichten des Textabsatzes zur Mitte
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Schreiben der Präsentation als PPTX-Datei
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Transparenz für Text Festlegen**
Dieser Artikel demonstriert, wie Sie die Transparenzeigenschaft für jede Textform mit Aspose.Slides für Android über Java festlegen. Um die Transparenz für den Text einzustellen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie.
3. Stellen Sie die Schattenfarbe ein.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - Transparenz ist: "+ (shadowColor.getAlpha() / 255f) * 100);

    // Transparenz auf null Prozent setzen
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zeichenabstand für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, den Abstand zwischen den Buchstaben in einem Textfeld festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen erweitern oder verringern.

Dieser Java-Code zeigt Ihnen, wie Sie den Abstand für eine Textzeile erweitern und den Abstand für eine andere Zeile verringern:

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // erweitern
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // verringern

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **Schriftarteneigenschaften des Absatzes Verwalten**

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um entweder bestimmte Abschnitte und Wörter hervorzuheben oder sich an Unternehmensstile anzupassen. Die Textformatierung hilft den Benutzern, das Aussehen und die Haptik der Präsentationsinhalte zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für Android über Java verwendet, um die Schriftarten von Textabsätzen auf Folien zu konfigurieren. Um die Schriftarten eines Absatzes mit Aspose.Slides für Android über Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erhalten Sie eine Referenz zur Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und typisieren Sie sie in [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
4. Holen Sie sich den [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) aus dem [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame), das von [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) bereitgestellt wird.
5. Rechtfertigen Sie den Absatz.
6. Greifen Sie auf die Textportion eines Absatzes zu.
7. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart der Textportion entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   2. Setzen Sie die Schriftart auf kursiv.
8. Setzen Sie die Schriftfarbe mit der [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) Methode des [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) Objekts.
9. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Die Implementierung der oben genannten Schritte wird unten angegeben. Sie nimmt eine schmucklose Präsentation und formatiert die Schriftarten auf einer der Folien.

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Zugriff auf eine Folie über ihre Folienposition
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typcasting zu AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Zugriff auf den ersten Absatz
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Zugriff auf die erste Portion
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Definieren neuer Schriftarten
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Weisen Sie neue Schriftarten der Portion zu
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Setzen Sie die Schriftart auf Fett
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Setzen Sie die Schriftart auf Kursiv
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Schriftfarbe festlegen
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Schreiben Sie die PPTX auf die Festplatte
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Familie der Schriftart für Text Verwalten**
Eine Portion wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides für Android über Java verwendet, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart und verschiedene andere Eigenschaften der Schriftfamilie festzulegen. Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) des Typs [Rechteck](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) zur Folie hinzu.
4. Entfernen Sie den Füllstil, der mit der [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) verknüpft ist.
5. Greifen Sie auf das TextFrame der AutoShape zu.
6. Fügen Sie etwas Text zum TextFrame hinzu.
7. Greifen Sie auf das Portion-Objekt zu, das mit dem [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) verknüpft ist.
8. Definieren Sie die Schriftart, die für die [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) verwendet werden soll.
9. Setzen Sie andere Schriftarteigenschaften wie dick, kursiv, unterstrichen, Farbe und Höhe über die relevanten Eigenschaften, die vom Portion-Objekt bereitgestellt werden.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```java
// Instanziieren Sie die Präsentation
Presentation pres = new Presentation();
try {

    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rechteck hinzu
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Entfernen Sie den mit der AutoShape verbundenen Füllstil
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Greifen Sie auf das TextFrame zu, das mit der AutoShape verknüpft ist
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Greifen Sie auf die Portion zu, die mit dem TextFrame verknüpft ist
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Setzen Sie die Schriftart für die Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Setzen Sie die Fettschrift-Eigenschaft der Schriftart
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Setzen Sie die Kursivschrift-Eigenschaft der Schriftart
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Setzen Sie die Unterstreichungseigenschaft der Schriftart
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Setzen Sie die Höhe der Schriftart
    port.getPortionFormat().setFontHeight(25);

    // Legen Sie die Farbe der Schriftart fest
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Schreiben Sie die PPTX auf die Festplatte 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Schriftgröße für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, die von Ihnen bevorzugte Schriftgröße für vorhandenen Text in einem Absatz und für andere Texte, die später zum Absatz hinzugefügt werden, auszuwählen.

Dieser Java-Code zeigt Ihnen, wie man die Schriftgröße für Texte in einem Absatz festlegt:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Zuerst die erste Form abrufen, zum Beispiel.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Erhält den ersten Absatz, zum Beispiel.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Setzt die Standard-Schriftgröße auf 20 pt für alle Textportionen im Absatz. 
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

## **Textrotation Festlegen**

Aspose.Slides für Android über Java ermöglicht es Entwicklern, den Text zu rotieren. Der Text kann auf [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal), [Vertikal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical), [Vertikal270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertikal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical), [OstasianischVertikal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolischVertikal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) oder [WordArtVertikalVonRechtsNachLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) eingestellt werden. Um den Text eines TextFrames zu rotieren, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Rotieren Sie den Text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Speichern Sie die Datei auf der Festplatte.

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape des Typs Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Zugriff auf das Textfeld
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Erstellen des Absatzobjekts für das Textfeld
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Erstellen Sie das Portion-Objekt für den Absatz
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Präsentation speichern
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Benutzerdefinierte Rotationswinkel für TextFrame Festlegen**
Aspose.Slides für Android über Java unterstützt jetzt das Festlegen des benutzerdefinierten Rotationswinkels für das Textfeld. In diesem Thema werden wir mit einem Beispiel sehen, wie die Eigenschaft RotationAngle in Aspose.Slides festgelegt werden kann. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) und [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) wurden zu den Schnittstellen [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) und [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) hinzugefügt, um den benutzerdefinierten Rotationswinkel für das Textfeld festzulegen. Um den RotationAngle festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Fügen Sie ein Diagramm zur Folie hinzu.
3. [Setzen Sie die RotationAngle-Eigenschaft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel setzen wir die RotationAngle-Eigenschaft.

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das Textfeld
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Erstellen des Absatzobjekts für das Textfeld
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Erstellen Sie das Portion-Objekt für den Absatz
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Textrotationsbeispiel.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Präsentation speichern
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zeilenabstand des Absatzes**
Aspose.Slides bietet Eigenschaften unter [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` und `SpaceWithin`—die es Ihnen ermöglichen, den Zeilenabstand für einen Absatz zu verwalten. Die drei Eigenschaften werden wie folgt verwendet:

* Um den Zeilenabstand für einen Absatz in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Absatz in Punkten anzugeben, verwenden Sie einen negativen Wert.

Zum Beispiel können Sie einen Zeilenabstand von 16 Punkten für einen Absatz anwenden, indem Sie die Eigenschaft `SpaceBefore` auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation mit einer AutoShape, die Text enthält.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Absatz zu.
5. Setzen Sie die Eigenschaften des Absatzes.
6. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie den Zeilenabstand für einen Absatz angeben:

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Erhalten Sie eine Referenz zur Folie über ihren Index
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Zugriff auf das TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Zugriff auf den Absatz
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Setzen der Eigenschaften des Absatzes
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Präsentation speichern
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Die AutofitType-Eigenschaft für TextFrame Festlegen**
In diesem Thema werden wir die verschiedenen Formatierungseigenschaften von Textrahmen erkunden. Dieser Artikel behandelt, wie man die AutofitType-Eigenschaft des Textrahmens, den Anker des Textes und das Rotieren des Textes in der Präsentation festlegt. Aspose.Slides für Android über Java ermöglicht es Entwicklern, die AutofitType-Eigenschaft eines Textrahmens festzulegen. AutofitType kann auf [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) oder [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) gesetzt werden. Wenn das AutofitType auf [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) gesetzt ist, bleibt die Form gleich, während der Text angepasst wird, ohne die Form selbst zu verändern. Wenn das AutofitType auf [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) gesetzt wird, wird die Form so modifiziert, dass nur der erforderliche Text darin enthalten ist. Um die AutofitType-Eigenschaft eines Textrahmens festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine Form zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Setzen Sie das AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das Textfeld
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Erstellen des Absatzobjekts für das Textfeld
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Erstellen Sie das Portion-Objekt für den Absatz
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Präsentation speichern
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Anker des TextFrame Festlegen**
Aspose.Slides für Android über Java ermöglicht es Entwicklern, den Anker jedes TextFrames festzulegen. TextAnchorType gibt an, wo der Text in der Form platziert ist. Der AnchorType kann auf [Oben](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top), [Zentrum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center), [Unten](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom), [Begründet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) oder [Verteilt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed) gesetzt werden. Um den Anker eines TextFrames festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine Form zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Setzen Sie den TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape des Typs Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Zugriff auf das Textfeld
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Erstellen des Absatzobjekts für das Textfeld
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Erstellen Sie das Portion-Objekt für den Absatz
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Präsentation speichern
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabs und Effektive Tabs in Präsentationen**
Alle Texttabulatoren werden in Pixel angegeben.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Abbildung: 2 explizite Tabs und 2 Standard-Tabs**|
- Die Eigenschaft EffectiveTabs.ExplicitTabCount (in unserem Fall 2) ist gleich der Tabs.Count.
- Die EffectiveTabs-Sammlung umfasst alle Tabs (aus der Tabs-Sammlung und den Standard-Tabs).
- Die EffectiveTabs.ExplicitTabCount (in unserem Fall 2) ist gleich Tabs.Count.
- Die Eigenschaft EffectiveTabs.DefaultTabSize (294) zeigt den Abstand zwischen den Standard-Tabs (3 und 4 in unserem Beispiel).
- EffectiveTabs.GetTabByIndex(index) mit index = 0 gibt den ersten expliziten Tab zurück (Position = 731), index = 1 - den zweiten Tab (Position = 1241). Wenn Sie versuchen, den nächsten Tab mit index = 2 zu erhalten, gibt es den ersten Standard-Tab zurück (Position = 1470) und usw.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um den nächsten Tabulator nach einem bestimmten Text zu erhalten. Zum Beispiel haben Sie den Text: "Hallo Welt!". Um diesen Text darzustellen, sollten Sie wissen, wo Sie mit dem Zeichnen von "Welt!" beginnen sollen. Zuerst sollten Sie die Länge von "Hallo" in Pixeln berechnen und GetTabAfterPosition mit diesem Wert aufrufen. Sie erhalten die nächste Tabulatorposition, um "Welt!" darzustellen.

## **Standardtextstil Festlegen**

Wenn Sie die gleiche Standardtextformatierung auf alle Textelemente einer Präsentation auf einmal anwenden möchten, können Sie die Methode `getDefaultTextStyle` aus der [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) Schnittstelle verwenden und die bevorzugte Formatierung festlegen. Das folgende Codebeispiel zeigt, wie man die Standardfett-Schriftart (14 pt) für den Text auf allen Folien in einer neuen Präsentation festlegt.

```java
Presentation presentation = new Presentation();
try {
    // Erhalten Sie das oberste Absatzformat.
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