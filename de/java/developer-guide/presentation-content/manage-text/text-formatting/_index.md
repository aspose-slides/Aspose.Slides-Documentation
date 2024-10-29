---
title: Textformatierung
type: docs
weight: 50
url: /de/java/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Textabsätze ausrichten
- Texttransparenz
- Absatzschrifteigenschaften
- Schriftfamilie
- Textrotation
- benutzerdefinierte Winkelrotation
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeldanker
- Texttabulierung
- Standardtextstil
- Java
- Aspose.Slides für Java
description: "Verwalten und Manipulieren von Text und Eigenschaften von Textfeldern in Java"
---

## **Text Hervorheben**
Die Methode [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) wurde zum Interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) hinzugefügt.

Es ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe unter Verwendung eines Textbeispiels, ähnlich wie das Text-Hervorheben-Tool in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie man diese Funktion verwendet:

```java
Presentation pres = new Presentation("Präsentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("Titel", Color.BLUE); // hebt alle Wörter 'wichtig' hervor
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("zu", Color.MAGENTA, textHighlightingOptions);// hebt alle separaten 'die' Vorkommen hervor
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Aspose bietet einen einfachen, [kostenlosen Online-PowerPoint-Bearbeitungsdienst](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Text Hervorheben mit Regulärem Ausdruck**

Die Methode [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) wurde zum Interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) hinzugefügt.

Es ermöglicht, einen Textteil mit Hintergrundfarbe unter Verwendung von Regex hervorzuheben, ähnlich wie das Text-Hervorheben-Tool in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie man diese Funktion verwendet:

```java
Presentation pres = new Presentation("Präsentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // hebt alle Wörter mit 10 oder mehr Zeichen hervor
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hintergrundfarbe für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Farbe für den Hintergrund eines Textes festzulegen.

Dieser Java-Code zeigt Ihnen, wie Sie die Hintergrundfarbe für einen gesamten Text festlegen:

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

    presentation.save("text-rot.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Dieser Java-Code zeigt Ihnen, wie Sie die Hintergrundfarbe nur für einen Teil eines Textes festlegen:

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

    presentation.save("text-rot.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Textabsätze Ausrichten**

Die Textformatierung ist eines der Schlüsseldetails beim Erstellen jeglicher Art von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für Java das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema werden wir sehen, wie wir die Ausrichtung der Textabsätze in einer Folie steuern können. Bitte befolgen Sie die folgenden Schritte, um Textabsätze mit Aspose.Slides für Java auszurichten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und typisieren Sie sie als [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. Holen Sie sich den Absatz (der ausgerichtet werden muss) aus dem von [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) bereitgestellten [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getTextFrame--).
5. Richten Sie den Absatz aus. Ein Absatz kann nach rechts, links, zentriert und im Blocksatz ausgerichtet werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist unten aufgeführt.

```java
// Erstellen Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung als AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Ändern Sie den Text in beiden Platzhaltern
    tf1.setText("Zentrierte Ausrichtung von Aspose");
    tf2.setText("Zentrierte Ausrichtung von Aspose");

    // Erhalten des ersten Absatzes der Platzhalter
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Ausrichten des Textabsatzes in der Mitte
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Schreiben der Präsentation als PPTX-Datei
    pres.save("Zentrierausgerichtet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Transparenz für Text Festlegen**
Dieser Artikel demonstriert, wie Sie die Transparenzeigenschaft für jede Textform unter Verwendung von Aspose.Slides für Java festlegen können. Um die Transparenz für den Text festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie.
3. Legen Sie die Schattenfarbe fest.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist unten aufgeführt.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - Transparenz ist: "+ (shadowColor.getAlpha() / 255f) * 100);

    // Legen Sie die Transparenz auf null Prozent fest
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zeichenabstand für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, den Abstand zwischen Buchstaben in einem Textfeld festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen erweitern oder verringern.

Dieser Java-Code zeigt Ihnen, wie Sie den Abstand für eine Textzeile erweitern und den Abstand für eine andere Zeile verringern:

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // erweitern
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // verringern

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **Schrifteigenschaften des Absatzes Verwalten**

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um entweder bestimmte Abschnitte und Wörter hervorzuheben oder um sich an die Unternehmensstile anzupassen. Die Textformatierung hilft Benutzern, das Aussehen und das Gefühl des Inhalts der Präsentation zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für Java verwendet, um die Schrifteigenschaften von Textabsätzen auf Folien zu konfigurieren. Um die Schrifteigenschaften eines Absatzes mit Aspose.Slides für Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die Platzhalterformen in der Folie zu und typisieren Sie sie in [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Holen Sie sich den [Absatz](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) aus dem von [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) bereitgestellten [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Rechtfertigen Sie den Absatz.
1. Greifen Sie auf den Textanteil eines Absatzes zu.
1. Definieren Sie die Schriftart mit FontData und legen Sie die Schriftart des Textanteils entsprechend fest.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Legen Sie die Schriftfarbe mit der [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) fest, die vom [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion) Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Die Implementierung der obigen Schritte ist unten aufgeführt. Sie nimmt eine ungeschmückte Präsentation und formatiert die Schriften auf einer der Folien.

```java
// Erstellen Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Zugriff auf eine Folie anhand ihrer Folienposition
    ISlide slide = pres.getSlides().get_Item(0);

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung als AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Zugriff auf den ersten Absatz
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Zugriff auf den ersten Teil
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Neue Schriften definieren
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Neue Schriften dem Teil zuweisen
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Schrift auf fett setzen
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Schrift auf kursiv setzen
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

## **Familie der Schriftarten für Text Verwalten**
Ein Abschnitt wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie Sie Aspose.Slides für Java verwenden, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart und verschiedene andere Eigenschaften der Schriftfamilie festzulegen. Um ein Textfeld zu erstellen und die Schrifteigenschaften des Textes darin festzulegen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) vom Typ [Rechteck](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) zur Folie hinzu.
4. Entfernen Sie den mit der [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) verbundenen Füllstil.
5. Greifen Sie auf das TextFrame der AutoShape zu.
6. Fügen Sie dem TextFrame etwas Text hinzu.
7. Greifen Sie auf das zugehörige Portion-Objekt des [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. Definieren Sie die Schriftart, die für den [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion) verwendet werden soll.
9. Legen Sie andere Schrifteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mit den entsprechenden Eigenschaften fest, die vom Portion-Objekt bereitgestellt werden.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist unten aufgeführt.

```java
// Erstellen Sie eine Präsentation
Presentation pres = new Presentation();
try {

    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Entfernen Sie alle Füllstile, die mit der AutoShape verbunden sind
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Greifen Sie auf das mit der AutoShape verbundene TextFrame zu
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Greifen Sie auf die Portion zu, die mit dem TextFrame verbunden ist
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Legen Sie die Schriftart für die Portion fest
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Legen Sie die fette Eigenschaft der Schrift fest
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Legen Sie die kursiv-Eigenschaft der Schrift fest
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Legen Sie die unterstrichene Eigenschaft der Schrift fest
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Legen Sie die Höhe der Schrift fest
    port.getPortionFormat().setFontHeight(25);

    // Legen Sie die Farbe der Schrift fest
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Schreiben Sie die PPTX auf die Festplatte
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Schriftgröße für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Schriftgröße für vorhandenen Text in einem Absatz und andere Texte, die später möglicherweise zu dem Absatz hinzugefügt werden, auszuwählen.

Dieser Java-Code zeigt Ihnen, wie Sie die Schriftgröße für Texte im Absatz festlegen:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Holt die erste Form, zum Beispiel.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Holt den ersten Absatz, zum Beispiel.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Setzt die Standard-Schriftgröße auf 20 pt für alle Textabschnitte im Absatz. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Setzt die Schriftgröße auf 20 pt für die aktuellen Textabschnitte im Absatz. 
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

Aspose.Slides für Java ermöglicht es Entwicklern, den Text zu drehen. Der Text kann als [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertikal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertikal270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertikal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [OstasienVertikal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolischVertikal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) oder [WordArtVertikalRechtsNachLinks](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) angezeigt werden. Um den Text eines TextFrames zu drehen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Zugriff auf die erste Folie.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Drehen Sie den Text](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Speichern Sie die Datei auf der Festplatte.

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Zugriff auf das Textfeld
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Erstellen Sie das Absatzobjekt für das Textfeld
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
Aspose.Slides für Java unterstützt jetzt das Festlegen eines benutzerdefinierten Rotationswinkels für Textframes. In diesem Thema werden wir anhand eines Beispiels sehen, wie wir die RotationAngle-Eigenschaft in Aspose.Slides festlegen. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) und [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) wurden zu den Schnittstellen [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) und [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) hinzugefügt, und ermöglichen es, den benutzerdefinierten Rotationswinkel für Textframes festzulegen. Um die RotationAngle festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Fügen Sie ein Diagramm zur Folie hinzu.
3. [Legen Sie die RotationAngle-Eigenschaft fest](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel setzen wir die RotationAngle-Eigenschaft.

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das Textfeld
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Erstellen Sie das Absatzobjekt für das Textfeld
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
Aspose.Slides bietet Eigenschaften unter [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` und `SpaceWithin`—die es Ihnen ermöglichen, den Zeilenabstand für einen Absatz zu verwalten. Die drei Eigenschaften werden wie folgt verwendet:

* Um den Zeilenabstand für einen Absatz in Prozent anzugeben, verwenden Sie einen positiven Wert.
* Um den Zeilenabstand für einen Absatz in Punkten anzugeben, verwenden Sie einen negativen Wert.

Zum Beispiel können Sie einen Zeilenabstand von 16pt für einen Absatz festlegen, indem Sie die Eigenschaft `SpaceBefore` auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die eine AutoShape mit etwas Text enthält.
2. Holen Sie sich die Referenz einer Folie anhand ihres Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Absatz zu.
5. Legen Sie die Absatz Eigenschaften fest.
6. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie den Zeilenabstand für einen Absatz angeben:

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Erhalten Sie die Referenz einer Folie durch ihren Index
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Greifen Sie auf das TextFrame zu
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Greifen Sie auf den Absatz zu
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Legen Sie die Eigenschaften des Absatzes fest
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Präsentation speichern
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Die AutofitType-Eigenschaft für das TextFrame Festlegen**
In diesem Thema werden wir die verschiedenen Formatierungseigenschaften des Textfeldes untersuchen. Dieser Artikel behandelt das Festlegen der AutofitType-Eigenschaft des Textfeldes, des Ankers des Textes und der Drehung des Textes in der Präsentation. Aspose.Slides für Java ermöglicht es Entwicklern, die AutofitType-Eigenschaft eines beliebigen Textfeldes festzulegen. AutofitType könnte auf [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) oder [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape) gesetzt werden. Wenn es auf [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) gesetzt ist, bleibt die Form gleich, während der Text angepasst wird, ohne dass sich die Form selbst ändert. Wenn AutofitType auf [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape) gesetzt ist, wird die Form so geändert, dass nur der erforderliche Text darin enthalten ist. Um die AutofitType-Eigenschaft eines Textfeldes festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Legen Sie den AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) des TextFrames fest.
6. Speichern Sie die Datei auf der Festplatte.

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Greifen Sie auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Zugriff auf das Textfeld
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Erstellen Sie das Absatzobjekt für das Textfeld
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

## **Anker des TextFrames Festlegen**
Aspose.Slides für Java ermöglicht Entwicklern, den Anker eines beliebigen TextFrames festzulegen. Der TextAnchorType gibt an, wo der Text in der Form platziert ist. Der AnchorType kann auf [Oben](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Mitte](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Unten](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justifiziert](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) oder [Verteilt](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed) gesetzt werden. Um den Anker eines beliebigen TextFrames festzulegen, bitte befolgen Sie die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Zugriff auf die erste Folie.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Zugriff auf das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Setzen Sie den TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```java
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Zugriff auf das Textfeld
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Erstellen Sie das Absatzobjekt für das Textfeld
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

## **Tabs und EffectiveTabs in Präsentationen**
Alle Texttabulatoren sind in Pixel angegeben.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Abbildung: 2 explizite Tabs und 2 Standard-Tabs**|
- Die Eigenschaft EffectiveTabs.ExplicitTabCount (in unserem Fall 2) entspricht der Tabs.Count.
- Die EffectiveTabs-Sammlung umfasst alle Tabs (aus der Tabs-Sammlung und den Standard-Tabs).
- Die Eigenschaft EffectiveTabs.ExplicitTabCount (in unserem Fall 2) entspricht der Tabs.Count.
- Die Eigenschaft EffectiveTabs.DefaultTabSize (294) zeigt den Abstand zwischen den Standard-Tabs (3 und 4 in unserem Beispiel).
- EffectiveTabs.GetTabByIndex(index) mit index = 0 gibt den ersten expliziten Tab zurück (Position = 731), index = 1 - den zweiten Tab (Position = 1241). Wenn Sie versuchen, den nächsten Tab mit index = 2 zu erhalten, wird der erste Standardtab (Position = 1470) und so weiter zurückgegeben.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um die nächste Tabulatorstelle nach einem bestimmten Text zu erhalten. Zum Beispiel haben Sie den Text: "Hallo Welt!". Um diesen Text darzustellen, müssen Sie wissen, wo Sie mit dem Zeichnen von "Welt!" beginnen sollen. Zuerst sollten Sie die Länge von "Hallo" in Pixeln berechnen und GetTabAfterPosition mit diesem Wert aufrufen. Sie erhalten die nächste Tabulatorposition, um "Welt!" zu zeichnen.

## **Standardtextstil Festlegen**

Wenn Sie die gleiche Standardtextformatierung für alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die Methode `getDefaultTextStyle` aus dem [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) Interface verwenden und die bevorzugte Formatierung festlegen. Das folgende Codebeispiel zeigt, wie man für alle Folien in einer neuen Präsentation die Standardschriftart (14 pt) auf fett festlegt.

```java
Presentation presentation = new Presentation();
try {
    // Holen Sie sich das übergeordnete Absatzformat.
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