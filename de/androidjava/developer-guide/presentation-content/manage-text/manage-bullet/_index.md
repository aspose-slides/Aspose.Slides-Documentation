---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen auf Android
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/androidjava/manage-bullet/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbolaufzählungszeichen
- Bildaufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs- und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java verwalten. Schritt-für-Schritt-Anleitung."
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und nummerierte Listen auf dieselbe Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for Android via Java** ermöglicht es Ihnen ebenfalls, Aufzählungszeichen und Nummern in Folien Ihrer Präsentationen zu verwenden.

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, Schlüsselpunkte leicht zu überfliegen
- kommuniziert und liefert wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls bei der Organisation und Präsentation von Informationen. Idealerweise sollten Sie Zahlen (statt Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (z. B. *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im nachstehenden Verfahren **Erstellen von Aufzählungen**:

1. Erstellen Sie eine Instanz der Präsentationsklasse. 
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation. 

## **Aufzählungen erstellen**
Dieses Thema ist ebenfalls Teil der Themenreihe zur Verwaltung von Textabsätzen. Diese Seite zeigt, wie wir Aufzählungszeichen für Absätze verwalten können. Aufzählungen sind besonders nützlich, wenn etwas in Schritten beschrieben werden soll. Darüber hinaus wirkt der Text dank Aufzählungen gut organisiert. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen. Wir zeigen, wie Entwickler diese kleine, aber leistungsstarke Funktion von Aspose.Slides for Android via Java nutzen können. Bitte folgen Sie den nachstehenden Schritten, um Absatz‑Aufzählungszeichen mit Aspose.Slides for Android via Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Greifen Sie über das Objekt [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie in der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) hinzu.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im TextFrame.
1. Erstellen Sie die erste Absatzinstanz mithilfe der Klasse [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).
1. Legen Sie den Aufzählungstyp des Absatzes fest.
1. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) und legen Sie das Aufzählungszeichen fest.
1. Setzen Sie den Absatztext.
1. Stellen Sie den Absatz‑Einzug ein, um die Aufzählung zu setzen.
1. Legen Sie die Farbe der Aufzählung fest.
1. Stellen Sie die Höhe der Aufzählungszeichen ein.
1. Fügen Sie den erstellten Absatz zur Absatz‑Collection des TextFrames hinzu.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten **7 bis 13**.
1. Speichern Sie die Präsentation.

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShape hinzufügen und darauf zugreifen
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // TextFrame der erstellten AutoShape abrufen
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Entfernen des standardmäßigen vorhandenen Paragraphen
    txtFrm.getParagraphs().removeAt(0);
    
    // Einen Paragraph erstellen
    Paragraph para = new Paragraph();
    
    // Bullet‑Stil und Symbol des Paragraphen festlegen
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Paragraph‑Text festlegen
    para.setText("Welcome to Aspose.Slides");
    
    // Einzug des Bullets festlegen
    para.getParagraphFormat().setIndent(25);
    
    // Bullet‑Farbe festlegen
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // IsBulletHardColor auf true setzen, um eine eigene Bullet‑Farbe zu verwenden
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Bullet‑Höhe festlegen
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Paragraph zum TextFrame hinzufügen
    txtFrm.getParagraphs().add(para);
    
    // Präsentation als PPTX‑Datei speichern
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Bildaufzählungen erstellen**

Aspose.Slides for Android via Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder die Aufmerksamkeit auf Listeneinträge noch stärker lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise sollten Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen. 

In jedem Fall wird das ausgewählte Bild auf eine sehr kleine Größe reduziert, daher empfehlen wir dringend, ein Bild zu wählen, das (als Ersatz für das Aufzählungszeichen) in einer Liste gut aussieht. 

{{% /alert %}} 

Um ein Bild‑Aufzählungszeichen zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Greifen Sie über das Objekt [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie in der ausgewählten Folie eine AutoShape hinzu.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mithilfe der Klasse Paragraph.
1. Laden Sie ein Bild von der Festplatte in [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage) laden.
1. Setzen Sie den Aufzählungstyp auf Bild und legen Sie das Bild fest.
1. Setzen Sie den Absatztext.
1. Stellen Sie den Absatz‑Einzug ein, um die Aufzählung zu setzen.
1. Legen Sie die Farbe der Aufzählung fest.
1. Stellen Sie die Höhe der Aufzählungszeichen ein.
1. Fügen Sie den erstellten Absatz zur Absatz‑Collection des [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) hinzu.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den vorherigen Schritten.
1. Speichern Sie die Präsentation.

```java
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);

    // Bild für Aufzählungszeichen instanziieren
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // AutoShape hinzufügen und darauf zugreifen
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // TextFrame der erstellten AutoShape abrufen
    ITextFrame txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);

    // Neuen Absatz erstellen
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // Aufzählungsstil und Bild des Absatzes festlegen
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Aufzählungs-Höhe festlegen
    para.getParagraphFormat().getBullet().setHeight(100);

    // Absatz zum TextFrame hinzufügen
    txtFrm.getParagraphs().add(para);

    // Präsentation als PPTX-Datei schreiben
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mehrstufige Aufzählungen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält – zusätzliche Listen unter der Hauptauflistung – gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Greifen Sie über das Objekt [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie in der ausgewählten Folie eine AutoShape hinzu.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mithilfe der Klasse Paragraph und setzen Sie die Tiefe auf 0.
1. Erstellen Sie die zweite Absatzinstanz mithilfe der Klasse Paragraph und setzen Sie die Tiefe auf 1.
1. Erstellen Sie die dritte Absatzinstanz mithilfe der Klasse Paragraph und setzen Sie die Tiefe auf 2.
1. Erstellen Sie die vierte Absatzinstanz mithilfe der Klasse Paragraph und setzen Sie die Tiefe auf 3.
1. Fügen Sie die erstellten Absätze zur Absatz‑Collection des [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) hinzu.
1. Speichern Sie die Präsentation.

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf den TextFrame der erstellten AutoShape
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().clear();
    
    // Erstellen des ersten Absatzes
    Paragraph para1 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Festlegen der Aufzählungsebene
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Erstellen des zweiten Absatzes
    Paragraph para2 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Festlegen der Aufzählungsebene
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Erstellen des dritten Absatzes
    Paragraph para3 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Festlegen der Aufzählungsebene
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Erstellen des vierten Absatzes
    Paragraph para4 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Festlegen der Aufzählungsebene
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Hinzufügen des Absatzes zum TextFrame
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


## **Benutzerdefinierte nummerierte Listen erstellen**

Aspose.Slides for Android via Java bietet eine einfache API zur Verwaltung von Absätzen mit benutzerdefinierten Nummerierungsformaten. Um einer Absatzliste eine benutzerdefinierte Nummerierung hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Greifen Sie über das Objekt [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie in der ausgewählten Folie eine AutoShape hinzu.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mithilfe der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 2.
1. Erstellen Sie die zweite Absatzinstanz mithilfe der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 3.
1. Erstellen Sie die dritte Absatzinstanz mithilfe der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 7.
1. Fügen Sie die erstellten Absätze zur Absatz‑Collection des [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) hinzu.
1. Speichern Sie die Präsentation.

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf den TextFrame der erstellten AutoShape
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().clear();

    // Erste Liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Zweite Liste
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann man mit Aspose.Slides erstellte Aufzählungs‑ und nummerierte Listen in andere Formate wie PDF oder Bilder exportieren?**

Ja, Aspose.Slides bewahrt die Formatierung und Struktur von Aufzählungs‑ und nummerierten Listen vollständig, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt so für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs‑ oder nummerierte Listen aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs‑ oder nummerierten Listen aus bestehenden Präsentationen, wobei deren ursprüngliche Formatierung und Darstellung erhalten bleibt.

**Unterstützt Aspose.Slides Aufzählungs‑ und nummerierte Listen in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und nummerierten Listen in jeder Sprache, einschließlich der Verwendung spezieller oder nicht‑lateinischer Zeichen.