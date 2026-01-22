---
title: Verwalten von Aufzählungs‑ und Nummerierungslisten in Präsentationen auf Android
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/androidjava/manage-bullet/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
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
description: "Erfahren Sie, wie Sie Aufzählungs‑ und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Android via Java verwalten. Schritt‑für‑Schritt‑Anleitung."
---

In **Microsoft PowerPoint** können Sie Aufzählungs- und Nummerierungslisten auf die gleiche Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for Android via Java** ermöglicht ebenfalls die Verwendung von Aufzählungszeichen und Zahlen in Folien Ihrer Präsentationen.

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, Schlüssel‑Points leicht zu überfliegen
- kommuniziert und liefert wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen unterstützen ebenfalls die Organisation und Darstellung von Informationen. Ideal ist die Verwendung von Zahlen (anstelle von Aufzählungszeichen), wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (z. B. *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im **Creating Bullets**‑Verfahren unten:

1. Erstellen Sie eine Instanz der Präsentations‑Klasse. 
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation. 

## **Aufzählungszeichen erstellen**
Dieses Thema ist ebenfalls Teil der Themenreihe zur Verwaltung von Textabsätzen. Auf dieser Seite wird gezeigt, wie wir Absatz‑Aufzählungszeichen verwalten können. Aufzählungszeichen sind besonders nützlich, wenn etwas in Schritten beschrieben werden soll. Zudem wirkt der Text durch Aufzählungen gut strukturiert. Aufzählungs‑Absätze sind stets leichter zu lesen und zu verstehen. Wir sehen, wie Entwickler diese kleine, aber leistungsstarke Funktion von Aspose.Slides for Android via Java nutzen können. Folgen Sie den nachstehenden Schritten, um die Absatz‑Aufzählungszeichen mit Aspose.Slides for Android via Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse.
1. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)‑Objekt auf die gewünschte Folie in der Folien‑Sammlung zu.
1. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) der hinzugefügten Form zu.
1. Entfernen Sie den Standard‑Absatz im TextFrame.
1. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph)‑Klasse.
1. Setzen Sie den Aufzählungstyp des Absatzes.
1. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) und definieren Sie das Aufzählungszeichen.
1. Setzen Sie den Absatz‑Text.
1. Setzen Sie den Absatz‑Einzug, um das Aufzählungszeichen zu positionieren.
1. Setzen Sie die Farbe des Aufzählungszeichens.
1. Setzen Sie die Höhe der Aufzählungszeichen.
1. Fügen Sie den erstellten Absatz zur Absatz‑Sammlung des TextFrames hinzu.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte **7 bis 13**.
1. Speichern Sie die Präsentation.

Dieser Java‑Beispielcode – eine Umsetzung der obigen Schritte – zeigt, wie Sie eine Aufzählungsliste in einer Folie erstellen:
```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshape hinzufügen und darauf zugreifen
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf das TextFrame des erstellten Autoshape
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);
    
    // Erstellen eines Absatzes
    Paragraph para = new Paragraph();
    
    // Festlegen des Aufzählungsstils und Symbols für den Absatz
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Festlegen des Absatztextes
    para.setText("Welcome to Aspose.Slides");
    
    // Festlegen des Einzugs des Aufzählungszeichens
    para.getParagraphFormat().setIndent(25);
    
    // Festlegen der Farbe des Aufzählungszeichens
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // IsBulletHardColor auf true setzen, um eine eigene Aufzählungsfarbe zu verwenden
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Festlegen der Höhe des Aufzählungszeichens
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para);
    
    // Speichern der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Bild‑Aufzählungszeichen erstellen**

Aspose.Slides for Android via Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch eigene Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder die Aufmerksamkeit noch stärker auf Listeneinträge lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen wollen, sollten Sie ein einfaches Grafik‑Bild mit transparentem Hintergrund wählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen. 

In jedem Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe reduziert, daher empfehlen wir dringend, ein Bild zu wählen, das auch als Ersatz für das Aufzählungszeichen in einer Liste gut aussieht. 

{{% /alert %}} 

So erstellen Sie ein Bild‑Aufzählungszeichen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse
1. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)‑Objekt auf die gewünschte Folie in der Folien‑Sammlung zu
1. Fügen Sie der ausgewählten Folie ein Autoshape hinzu
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu
1. Entfernen Sie den Standard‑Absatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. Erstellen Sie die erste Absatz‑Instanz mit der Paragraph‑Klasse
1. Laden Sie das Bild von der Festplatte in [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)
1. Setzen Sie den Aufzählungstyp auf Picture und legen Sie das Bild fest
1. Setzen Sie den Absatz‑Text
1. Setzen Sie den Absatz‑Einzug, um das Aufzählungszeichen zu positionieren
1. Setzen Sie die Farbe des Aufzählungszeichens
1. Setzen Sie die Höhe der Aufzählungszeichen
1. Fügen Sie den erstellten Absatz zur [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)‑Absatz‑Sammlung hinzu
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die vorherigen Schritte
1. Speichern Sie die Präsentation

Dieser Java‑Code zeigt, wie Sie ein Bild‑Aufzählungszeichen in einer Folie erstellen:
```java
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Bild für Aufzählungszeichen instanziieren
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Autoshape hinzufügen und darauf zugreifen
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textfeld des erstellten Autoshape
    ITextFrame txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);

    // Neuer Absatz erstellen
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // Festlegen des Absatzaufzählungsstils und Bildes
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);

    // Absatz zum Textfeld hinzufügen
    txtFrm.getParagraphs().add(para);

    // Präsentation als PPTX-Datei schreiben
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mehrstufige Aufzählungszeichen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält – zusätzliche Listen unter der Haupt‑Aufzählungsliste – gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse.
1. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)‑Objekt auf die gewünschte Folie in der Folien‑Sammlung zu.
1. Fügen Sie der ausgewählten Folie ein Autoshape hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standard‑Absatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 0.
1. Erstellen Sie die zweite Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 1.
1. Erstellen Sie die dritte Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 2.
1. Erstellen Sie die vierte Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 3.
1. Fügen Sie die erstellten Absätze zur [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)‑Absatz‑Sammlung hinzu.
1. Speichern Sie die Präsentation.

Dieser Code, eine Umsetzung der obigen Schritte, zeigt, wie Sie in Java eine mehrstufige Aufzählungsliste erstellen:
```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugriff auf Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf das Textfeld des erstellten Autoshape
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
    //Festlegen der Aufzählungsebene
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Erstellen des zweiten Absatzes
    Paragraph para2 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Erstellen des dritten Absatzes
    Paragraph para3 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Erstellen des vierten Absatzes
    Paragraph para4 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para4.getParagraphFormat().setDepth ((short)3);
    
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


## **Benutzerdefinierte nummerierte Listen erstellen**
Aspose.Slides for Android via Java bietet eine einfache API zur Verwaltung von Absätzen mit benutzerdefinierten Zahlenformaten. Um einer Absatz‑Liste eine benutzerdefinierte Nummerierung hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Klasse.
1. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)‑Objekt auf die gewünschte Folie in der Folien‑Sammlung zu.
1. Fügen Sie der ausgewählten Folie ein Autoshape hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standard‑Absatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Erstellen Sie die erste Absatz‑Instanz mit der Paragraph‑Klasse und setzen **NumberedBulletStartWith** auf 2.
1. Erstellen Sie die zweite Absatz‑Instanz mit der Paragraph‑Klasse und setzen **NumberedBulletStartWith** auf 3.
1. Erstellen Sie die dritte Absatz‑Instanz mit der Paragraph‑Klasse und setzen **NumberedBulletStartWith** auf 7.
1. Fügen Sie die erstellten Absätze zur [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)‑Absatz‑Sammlung hinzu.
1. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie Sie in einer Folie eine nummerierte Liste erstellen:
```java
// Instanzieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen und Zugriff auf Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textfeld des erstellten Autoshape
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

**Können Aufzählungs‑ und nummerierte Listen, die mit Aspose.Slides erstellt wurden, in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt das Format und die Struktur von Aufzählungs‑ und nummerierten Listen vollständig bei, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt so für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs‑ oder nummerierte Listen aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs‑ oder nummerierten Listen aus bestehenden Präsentationen, wobei das ursprüngliche Format und Aussehen erhalten bleibt.

**Unterstützt Aspose.Slides Aufzählungs‑ und nummerierte Listen in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und nummerierten Listen in jeder Sprache, einschließlich spezieller oder nicht‑lateinischer Zeichen.