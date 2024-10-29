---
title: Bullet verwalten
type: docs
weight: 60
url: /de/androidjava/manage-bullet/
keywords: "Aufzählungszeichen, Aufzählungslisten, Zahlen, nummerierte Listen, Bildaufzählungszeichen, mehrstufige Aufzählungen, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Erstellen Sie Aufzählungs- und nummerierte Listen in PowerPoint-Präsentationen in Java"
---

In **Microsoft PowerPoint** können Sie Aufzählungs- und nummerierte Listen genauso erstellen wie in Word und anderen Texteditoren. **Aspose.Slides für Android über Java** ermöglicht es Ihnen ebenfalls, Aufzählungszeichen und Zahlen in Folien Ihrer Präsentationen zu verwenden.

## Warum Aufzählungslisten verwenden?

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren.

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste diese drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, leicht nach Schlüsselpunkten zu suchen
- kommuniziert und liefert wichtige Informationen effizient.

## Warum nummerierte Listen verwenden?

Nummerierte Listen helfen ebenfalls bei der Organisation und Präsentation von Informationen. Idealerweise sollten Sie Zahlen (anstelle von Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (zum Beispiel, *Schritt 1, Schritt 2*, usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (zum Beispiel, *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im Verfahren **Erstellen von Aufzählungszeichen** unten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation.

## Erstellen von Aufzählungszeichen
Dieses Thema ist auch Teil der Themenreihe zur Verwaltung von Textabsätzen. Diese Seite veranschaulicht, wie wir Absatzaufzählungszeichen verwalten können. Aufzählungszeichen sind nützlicher, wenn etwas in Schritten beschrieben werden soll. Darüber hinaus sieht Text mit der Verwendung von Aufzählungszeichen gut organisiert aus. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen. Wir werden sehen, wie Entwickler dieses kleine, aber leistungsstarke Feature von Aspose.Slides für Android über Java verwenden können. Bitte folgen Sie den untenstehenden Schritten, um die Absatzaufzählungszeichen mit Aspose.Slides für Android über Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Greifen Sie auf die gewünschte Folie in der Foliensammlung mit dem [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) Objekt zu.
1. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) in der ausgewählten Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im TextFrame.
1. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) Klasse.
1. Setzen Sie den Aufzählungstyp des Absatzes.
1. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) und setzen Sie das Aufzählungszeichen.
1. Setzen Sie den Absatztext.
1. Setzen Sie den Absatzrand, um das Aufzählungszeichen festzulegen.
1. Setzen Sie die Farbe des Aufzählungszeichens.
1. Setzen Sie die Höhe der Aufzählungszeichen.
1. Fügen Sie den erstellten Absatz der Absatzsammlung im TextFrame hinzu.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess in den Schritten **7 bis 13**.
1. Speichern Sie die Präsentation.

Dieser Beispielcode in Java—eine Implementierung der obigen Schritte—zeigt Ihnen, wie man eine Aufzählungsliste in einer Folie erstellt:

```java
// Instanziieren Sie eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf das Textfeld der erstellten AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().removeAt(0);
    
    // Erstellen eines Absatzes
    Paragraph para = new Paragraph();
    
    // Einstellen des Absatzaufzählungsstils und Symbols
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Einstellen des Absatztextes
    para.setText("Willkommen bei Aspose.Slides");
    
    // Einstellen des Aufzählungsrands
    para.getParagraphFormat().setIndent(25);
    
    // Einstellen der Aufzählungsfarbe
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // setze IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Einstellen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Hinzufügen des Absatzes zum Textfeld
    txtFrm.getParagraphs().add(para);
    
    // Speichern der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Erstellen von Bildaufzählungszeichen

Aspose.Slides für Android über Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse hinzufügen oder noch mehr Aufmerksamkeit auf die Einträge einer Liste lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise sollten Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder funktionieren am besten als benutzerdefinierte Aufzählungszeichen. 

In jedem Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe reduziert, daher empfehlen wir Ihnen dringend, ein Bild auszuwählen, das gut aussieht (als Ersatz für das Aufzählungszeichen) in einer Liste. 

{{% /alert %}} 

Um ein Bildaufzählungszeichen zu erstellen, befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Greifen Sie auf die gewünschte Folie in der Foliensammlung mit dem [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) Objekt zu.
1. Fügen Sie eine AutoShape in der ausgewählten Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse.
1. Laden Sie das Bild von der Festplatte im [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage).
1. Setzen Sie den Aufzählungstyp auf Bild und das Bild setzen.
1. Setzen Sie den Absatztext.
1. Setzen Sie den Absatzrand, um das Aufzählungszeichen festzulegen.
1. Setzen Sie die Farbe des Aufzählungszeichens.
1. Setzen Sie die Höhe der Aufzählungszeichen.
1. Fügen Sie den erstellten Absatz in die [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) Absatzsammlung ein.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess in den vorherigen Schritten.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein Bildaufzählungszeichen in einer Folie erstellen:

```java
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanziieren Sie das Bild für die Aufzählungszeichen
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textfeld der erstellten AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().removeAt(0);

    // Erstellen eines neuen Absatzes
    Paragraph para = new Paragraph();
    para.setText("Willkommen bei Aspose.Slides");

    // Einstellen des Absatzaufzählungsstils und Bildes
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Einstellen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);

    // Hinzufügen des Absatzes zum Textfeld
    txtFrm.getParagraphs().add(para);

    // Schreiben der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Erstellen von mehrstufigen Aufzählungen

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält—zusätzliche Listen unter der Hauptaufzählungsliste—begehen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Greifen Sie auf die gewünschte Folie in der Foliensammlung mit dem [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) Objekt zu.
1. Fügen Sie eine AutoShape in der ausgewählten Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 0.
1. Erstellen Sie die zweite Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 1.
1. Erstellen Sie die dritte Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 2.
1. Erstellen Sie die vierte Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 3.
1. Fügen Sie die erstellten Absätze in die Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) ein.
1. Speichern Sie die Präsentation.

Dieser Code, der eine Implementierung der obigen Schritte ist, zeigt Ihnen, wie man eine mehrstufige Aufzählungsliste in Java erstellt:

```java
// Instanziieren Sie eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf das Textfeld der erstellten AutoShape
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().clear();
    
    // Erstellen des ersten Absatzes
    Paragraph para1 = new Paragraph();
    // Einstellen des Absatzaufzählungsstils und Symbols
    para1.setText("Inhalt");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte) FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Einstellen der Aufzählungsebene
    para1.getParagraphFormat().setDepth((short) 0);
    
    // Erstellen des zweiten Absatzes
    Paragraph para2 = new Paragraph();
    // Einstellen des Absatzaufzählungsstils und Symbols
    para2.setText("Zweite Ebene");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte) FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Einstellen der Aufzählungsebene
    para2.getParagraphFormat().setDepth((short) 1);
    
    // Erstellen des dritten Absatzes
    Paragraph para3 = new Paragraph();
    // Einstellen des Absatzaufzählungsstils und Symbols
    para3.setText("Dritte Ebene");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte) FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Einstellen der Aufzählungsebene
    para3.getParagraphFormat().setDepth((short) 2);
    
    // Erstellen des vierten Absatzes
    Paragraph para4 = new Paragraph();
    // Einstellen des Absatzaufzählungsstils und Symbols
    para4.setText("Vierte Ebene");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte) FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Einstellen der Aufzählungsebene
    para4.getParagraphFormat().setDepth((short) 3);
    
    // Hinzufügen des Absatzes zum Textfeld
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // Speichern der Präsentation als PPTX-Datei
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Erstellen einer benutzerdefinierten nummerierten Liste
Aspose.Slides für Android über Java bietet eine einfache API zur Verwaltung von Absätzen mit benutzerdefinierten Zahlenformaten. Um eine benutzerdefinierte Nummernliste in einem Absatz hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Greifen Sie auf die gewünschte Folie in der Foliensammlung mit dem [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) Objekt zu.
1. Fügen Sie eine AutoShape in der ausgewählten Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 2.
1. Erstellen Sie die zweite Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 3.
1. Erstellen Sie die dritte Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 7.
1. Fügen Sie die erstellten Absätze in die [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) Absatzsammlung ein.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine nummerierte Liste in einer Folie erstellen:

```java
// Instanziieren Sie eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textfeld der erstellten AutoShape
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().clear();

    // Erste Liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("Aufzählung 2");
    paragraph1.getParagraphFormat().setDepth((short) 4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("Aufzählung 3");
    paragraph2.getParagraphFormat().setDepth((short) 4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Zweite Liste
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("Aufzählung 5");
    paragraph5.getParagraphFormat().setDepth((short) 4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```