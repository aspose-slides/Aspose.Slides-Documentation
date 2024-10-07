---
title: Bullet verwalten
type: docs
weight: 60
url: /java/manage-bullet/
keywords: "Aufzählungen, Aufzählungslisten, Zahlen, nummerierte Listen, Bildaufzählungen, mehrstufige Aufzählungen, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Erstellen Sie Aufzählungs- und nummerierte Listen in PowerPoint-Präsentationen in Java"
---

In **Microsoft PowerPoint** können Sie Aufzählungs- und nummerierte Listen auf dieselbe Weise erstellen, wie Sie es in Word und anderen Texteditoren tun. **Aspose.Slides für Java** ermöglicht es Ihnen ebenfalls, Aufzählungen und Zahlen in Folien Ihrer Präsentationen zu verwenden.

## Warum Aufzählungslisten verwenden?

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren.

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste diese drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, schnell nach wesentlichen Punkten zu suchen
- kommuniziert und liefert wichtige Details effizient.

## Warum nummerierte Listen verwenden?

Nummerierte Listen helfen ebenfalls bei der Organisation und Präsentation von Informationen. Idealerweise sollten Sie Zahlen (anstatt Aufzählungen) verwenden, wenn die Reihenfolge der Einträge (zum Beispiel, *Schritt 1, Schritt 2*, usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (zum Beispiel, *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im **Verfahren zum Erstellen von Aufzählungen** unten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation.

## Aufzählungen erstellen
Dieses Thema ist auch Teil der Themenreihe zur Verwaltung von Textabsätzen. Diese Seite veranschaulicht, wie wir Absatzaufzählungen verwalten können. Aufzählungen sind nützlicher, wenn etwas in Schritten beschrieben werden soll. Darüber hinaus sieht Text mit der Verwendung von Aufzählungen gut organisiert aus. Aufgezählte Absätze sind immer einfacher zu lesen und zu verstehen. Wir werden sehen, wie Entwickler diese kleine, aber leistungsstarke Funktion von Aspose.Slides für Java nutzen können. Bitte folgen Sie den untenstehenden Schritten, um die Absatzaufzählungen mit Aspose.Slides für Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Greifen Sie mit dem [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) Objekt auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) in der ausgewählten Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) der hinzugefügten Form zu.
1. Entfernen Sie den standardmäßigen Absatz im TextFrame.
1. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) Klasse.
1. Legen Sie den Aufzählungstyp des Absatzes fest.
1. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) und legen Sie das Aufzählungszeichen fest.
1. Legen Sie den Absatztext fest.
1. Legen Sie den Absatzabstand fest, um die Aufzählung zu setzen.
1. Legen Sie die Farbe der Aufzählung fest.
1. Legen Sie die Höhe der Aufzählungen fest.
1. Fügen Sie den erstellten Absatz in die TextFrame-Absatzsammlung ein.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess, der in den Schritten **7 bis 13** angegeben ist.
1. Speichern Sie die Präsentation.

Dieser Beispielcode in Java—eine Implementierung der obigen Schritte—zeigt Ihnen, wie Sie eine Aufzählungsliste in einer Folie erstellen:

```java
// Instanziieren Sie eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugreifen auf die Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf das Textframe der erstellten Autoshape
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().removeAt(0);
    
    // Erstellen eines Absatzes
    Paragraph para = new Paragraph();
    
    // Festlegen des Absatzaufzählungsstils und Symbols
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Festlegen des Absatztextes
    para.setText("Willkommen bei Aspose.Slides");
    
    // Festlegen des Aufzählungsabstands
    para.getParagraphFormat().setIndent(25);
    
    // Festlegen der Aufzählungsfarbe
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // set IsBulletHardColor auf true setzen, um die eigene Aufzählungsfarbe zu verwenden
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Hinzufügen des Absatzes zum Textframe
    txtFrm.getParagraphs().add(para);
    
    // Speichern der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Bildaufzählungen erstellen

Aspose.Slides für Java ermöglicht es Ihnen, die Aufzählungen in Aufzählungslisten zu ändern. Sie können die Aufzählungen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse hinzufügen oder noch mehr Aufmerksamkeit auf die Einträge einer Liste lenken möchten, können Sie Ihr eigenes Bild als Aufzählung verwenden.

{{% alert color="primary" %}}

Idealerweise sollten Sie, wenn Sie das reguläre Aufzählungssymbol durch ein Bild ersetzen möchten, ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder funktionieren am besten als benutzerdefinierte Aufzählungssymbole.

In jedem Fall wird das Bild, das Sie auswählen, auf eine sehr kleine Größe reduziert, sodass wir Ihnen dringend empfehlen, ein Bild auszuwählen, das gut aussieht (als Ersatz für das Aufzählungssymbol) in einer Liste.

{{% /alert %}}

Um eine Bildaufzählung zu erstellen, befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Greifen Sie mit dem [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) Objekt auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie eine Autoshape in der ausgewählten Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den standardmäßigen Absatz im [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse.
1. Laden Sie das Bild von der Festplatte in [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage).
1. Setzen Sie den Aufzählungstyp auf Picture und legen Sie das Bild fest.
1. Legen Sie den Absatztext fest.
1. Legen Sie den Absatzabstand fest, um die Aufzählung festzulegen.
1. Legen Sie die Farbe der Aufzählung fest.
1. Legen Sie die Höhe der Aufzählungen fest.
1. Fügen Sie den erstellten Absatz in das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) der Absatzsammlung ein.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess, der in den vorherigen Schritten angegeben ist.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine Bildaufzählung in einer Folie erstellen:

```java
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanziieren Sie das Bild für Aufzählungen
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Hinzufügen und Zugreifen auf die Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textframe der erstellten Autoshape
    ITextFrame txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().removeAt(0);

    // Erstellen eines neuen Absatzes
    Paragraph para = new Paragraph();
    para.setText("Willkommen bei Aspose.Slides");

    // Festlegen des Absatzaufzählungsstils und Bildes
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);

    // Hinzufügen des Absatzes zum Textframe
    txtFrm.getParagraphs().add(para);

    // Speichern der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Mehrstufige Aufzählungen erstellen

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält—zusätzliche Listen unter der Hauptaufzählungsliste—beherzigen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Greifen Sie mit dem [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) Objekt auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie eine Autoshape in der ausgewählten Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den standardmäßigen Absatz im [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 0.
1. Erstellen Sie die zweite Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 1.
1. Erstellen Sie die dritte Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 2.
1. Erstellen Sie die vierte Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 3.
1. Fügen Sie die erstellten Absätze in die [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) Absatzsammlung ein.
1. Speichern Sie die Präsentation.

Dieser Code, der eine Implementierung der obigen Schritte ist, zeigt Ihnen, wie Sie eine mehrstufige Aufzählungsliste in Java erstellen:

```java
// Instanziieren Sie eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugreifen auf die Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf das Textframe der erstellten Autoshape
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().clear();
    
    // Erstellen des ersten Absatzes
    Paragraph para1 = new Paragraph();
    // Festlegen des Absatzaufzählungsstils und Symbols
    para1.setText("Inhalt");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Erstellen des zweiten Absatzes
    Paragraph para2 = new Paragraph();
    // Festlegen des Absatzaufzählungsstils und Symbols
    para2.setText("Zweite Ebene");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Erstellen des dritten Absatzes
    Paragraph para3 = new Paragraph();
    // Festlegen des Absatzaufzählungsstils und Symbols
    para3.setText("Dritte Ebene");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Erstellen des vierten Absatzes
    Paragraph para4 = new Paragraph();
    // Festlegen des Absatzaufzählungsstils und Symbols
    para4.setText("Vierte Ebene");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Hinzufügen des Absatzes zum Textframe
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

## Benutzerdefinierte nummerierte Listen erstellen
Aspose.Slides für Java bietet eine einfache API zur Verwaltung von Absätzen mit benutzerdefinierter Zahlenformatierung. Um eine benutzerdefinierte Zahlenliste in einem Absatz hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Greifen Sie mit dem [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) Objekt auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie eine Autoshape in der ausgewählten Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den standardmäßigen Absatz im [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 2.
1. Erstellen Sie die zweite Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 3.
1. Erstellen Sie die dritte Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 7.
1. Fügen Sie die erstellten Absätze in die [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) Absatzsammlung ein.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine nummerierte Liste in einer Folie erstellen:

```java
// Instanziieren Sie eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen und Zugreifen auf die Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textframe der erstellten Autoshape
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().clear();

    // Erste Liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("Aufzählung 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("Aufzählung 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Zweite Liste
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("Aufzählung 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```