---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen mit Java
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/java/manage-bullet/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol-Aufzählungszeichen
- Bildaufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: Erfahren Sie, wie Sie Aufzählungs- und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java verwalten. Schritt-für-Schritt-Anleitung.
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und nummerierte Listen auf dieselbe Weise erstellen, wie Sie es in Word und anderen Texteditoren tun. **Aspose.Slides for Java** ermöglicht es Ihnen ebenfalls, Aufzählungszeichen und Zahlen in Folien Ihrer Präsentationen zu verwenden. 

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste diese drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Betrachter auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Betrachtern, Schlüssel­punkte leicht zu überfliegen
- kommuniziert und liefert wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls bei der Organisation und Darstellung von Informationen. Idealerweise sollten Sie Zahlen (anstelle von Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (z. B. *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im nachstehenden Verfahren **Creating Bullets**:

1. Erstellen Sie eine Instanz der Presentation‑Klasse. 
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14). 
3. Speichern Sie die Präsentation. 

## **Aufzählungen erstellen**

Dieses Thema ist ebenfalls Teil der Themenreihe zur Verwaltung von Textabsätzen. Diese Seite illustriert, wie wir Absatz‑Aufzählungszeichen verwalten können. Aufzählungszeichen sind besonders nützlich, wenn etwas in Schritten beschrieben werden soll. Zudem wirkt der Text durch die Verwendung von Aufzählungszeichen gut strukturiert. Aufzählungsabsätze sind stets leichter zu lesen und zu verstehen. Wir zeigen, wie Entwickler dieses kleine, aber leistungsfähige Feature von Aspose.Slides for Java nutzen können. Bitte folgen Sie den nachstehenden Schritten, um die Absatz‑Aufzählungszeichen mit Aspose.Slides for Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. Greifen Sie mit dem Objekt [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) auf die gewünschte Folie in der Folien‑Sammlung zu. 
3. Fügen Sie in der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) hinzu. 
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) der hinzugefügten Form zu. 
5. Entfernen Sie den Standard‑Absatz im TextFrame. 
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph). 
7. Setzen Sie den Aufzählungstyp des Absatzes. 
8. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) und legen Sie das Aufzählungszeichen fest. 
9. Setzen Sie den Absatztext. 
10. Setzen Sie den Absatz‑Einzug, um das Aufzählungszeichen zu setzen. 
11. Setzen Sie die Farbe des Aufzählungszeichens. 
12. Setzen Sie die Höhe der Aufzählungszeichen. 
13. Fügen Sie den erstellten Absatz zur Absatzsammlung des TextFrames hinzu. 
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten **7 bis 13**. 
15. Speichern Sie die Präsentation. 

```java
// Instanziieren Sie eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf den TextFrame des erstellten AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().removeAt(0);
    
    // Erstellen eines Absatzes
    Paragraph para = new Paragraph();
    
    // Festlegen des Aufzählungsstils und Symbols für den Absatz
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Festlegen des Absatztexts
    para.setText("Welcome to Aspose.Slides");
    
    // Festlegen des Aufzählungs‑Einzugs
    para.getParagraphFormat().setIndent(25);
    
    // Festlegen der Aufzählungsfarbe
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // Setzen Sie IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Festlegen der Aufzählungs‑Höhe
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para);
    
    // Speichern der Präsentation als PPTX‑Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Bildaufzählungen erstellen**

Aspose.Slides for Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder die Aufmerksamkeit der Einträge noch stärker hervorheben möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden. 

{{% alert color="primary" %}} 

Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, sollten Sie ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen. 

In jedem Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe reduziert, weshalb wir dringend empfehlen, ein Bild auszuwählen, das (als Ersatz für das Aufzählungszeichen) in einer Liste gut aussieht. 

{{% /alert %}} 

Um ein Bild‑Aufzählungszeichen zu erstellen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. Greifen Sie mit dem Objekt [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) auf die gewünschte Folie in der Folien‑Sammlung zu. 
3. Fügen Sie in der ausgewählten Folie ein AutoShape hinzu. 
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standard‑Absatz im [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph. 
7. Laden Sie ein Bild von der Festplatte in [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage). 
8. Setzen Sie den Aufzählungstyp auf Bild und legen Sie das Bild fest. 
9. Setzen Sie den Absatztext. 
10. Setzen Sie den Absatz‑Einzug, um das Aufzählungszeichen zu setzen. 
11. Setzen Sie die Farbe des Aufzählungszeichens. 
12. Setzen Sie die Höhe der Aufzählungszeichen. 
13. Fügen Sie den erstellten Absatz zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) hinzu. 
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den vorherigen Schritten. 
15. Speichern Sie die Präsentation. 

```java
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanziieren des Bildes für Aufzählungszeichen
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf den TextFrame des erstellten AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen bestehenden Absatzes
    txtFrm.getParagraphs().removeAt(0);

    // Erstellen eines neuen Absatzes
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // Festlegen des Absatz‑Aufzählungsstils und Bildes
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);

    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para);

    // Schreiben der Präsentation als PPTX‑Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mehrstufige Aufzählungen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf unterschiedlichen Ebenen enthält – zusätzliche Listen unterhalb der Hauptaufzählung – führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. Greifen Sie mit dem Objekt [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) auf die gewünschte Folie in der Folien‑Sammlung zu. 
3. Fügen Sie in der ausgewählten Folie ein AutoShape hinzu. 
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standard‑Absatz im [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 0. 
7. Erstellen Sie die zweite Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 1. 
8. Erstellen Sie die dritte Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 2. 
9. Erstellen Sie die vierte Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 3. 
10. Fügen Sie die erstellten Absätze zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) hinzu. 
11. Speichern Sie die Präsentation. 

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf den TextFrame des erstellten AutoShape
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().clear();
    
    // Erstellen des ersten Absatzes
    Paragraph para1 = new Paragraph();
    // Festlegen des Absatz‑Aufzählungsstils und Symbols
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Festlegen der Aufzählungs‑Ebene
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Erstellen des zweiten Absatzes
    Paragraph para2 = new Paragraph();
    // Festlegen des Absatz‑Aufzählungsstils und Symbols
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Festlegen der Aufzählungs‑Ebene
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Erstellen des dritten Absatzes
    Paragraph para3 = new Paragraph();
    // Festlegen des Absatz‑Aufzählungsstils und Symbols
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Festlegen der Aufzählungs‑Ebene
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Erstellen des vierten Absatzes
    Paragraph para4 = new Paragraph();
    // Festlegen des Absatz‑Aufzählungsstils und Symbols
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Festlegen der Aufzählungs‑Ebene
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

Aspose.Slides for Java bietet eine einfache API zur Verwaltung von Absätzen mit benutzerdefinierter Zahlenformatierung. Um einer Absatz einen benutzerdefinierten Zahlen‑Liste hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. Greifen Sie mit dem Objekt [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) auf die gewünschte Folie in der Folien‑Sammlung zu. 
3. Fügen Sie in der ausgewählten Folie ein AutoShape hinzu. 
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standard‑Absatz im [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph und setzen **NumberedBulletStartWith** auf 2. 
7. Erstellen Sie die zweite Absatzinstanz mit der Klasse Paragraph und setzen **NumberedBulletStartWith** auf 3. 
8. Erstellen Sie die dritte Absatzinstanz mit der Klasse Paragraph und setzen **NumberedBulletStartWith** auf 7. 
9. Fügen Sie die erstellten Absätze zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) hinzu. 
10. Speichern Sie die Präsentation. 

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf den TextFrame des erstellten AutoShape
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

**Können mit Aspose.Slides erstellte Aufzählungs‑ und nummerierte Listen in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt das Layout und die Struktur von Aufzählungs‑ und nummerierten Listen vollständig, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, sodass konsistente Ergebnisse entstehen.

**Ist es möglich, Aufzählungs‑ oder nummerierte Listen aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs‑ oder nummerierten Listen aus bestehenden Präsentationen, wobei deren ursprüngliches Layout und Aussehen erhalten bleiben.

**Unterstützt Aspose.Slides Aufzählungs‑ und nummerierte Listen in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und nummerierten Listen in jeder Sprache, einschließlich spezieller oder nicht‑lateinischer Zeichen.