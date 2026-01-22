---
title: Verwalten von Aufzählungs‑ und nummerierten Listen in Präsentationen mit JavaScript
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/nodejs-java/manage-bullet/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- benutzerdefiniertes Aufzählungszeichen
- mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs‑ und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit JavaScript mithilfe von Aspose.Slides für Node.js verwalten. Schritt‑für‑Schritt‑Anleitung."
---

In **Microsoft PowerPoint** können Sie Aufzählungs- und nummerierte Listen auf dieselbe Weise erstellen, wie Sie es in Word und anderen Texteditoren tun. **Aspose.Slides for Node.js via Java** ermöglicht es Ihnen ebenfalls, Aufzählungszeichen und Nummern in Folien Ihrer Präsentationen zu verwenden.

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für Aufzählungslisten**

In den meisten Fällen erfüllt eine Aufzählungslisten diese drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Betrachter auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Betrachtern, Schlüssel­punkte leicht zu erfassen
- kommuniziert und liefert wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls beim Organisieren und Präsentieren von Informationen. Idealerweise sollten Sie Zahlen (anstelle von Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (zum Beispiel *Schritt 1, Schritt 2*, usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (zum Beispiel *siehe Schritt 3*).

**Beispiel für nummerierte Listen**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im nachstehenden Verfahren **Creating Bullets**:

1. Erstellen Sie eine Instanz der Präsentationsklasse. 
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14). 
3. Speichern Sie die Präsentation. 

## **Aufzählungen erstellen**

Dieses Thema ist ebenfalls Teil der Themenreihe zur Verwaltung von Textabsätzen. Diese Seite zeigt, wie wir Aufzählungszeichen in Absätzen verwalten können. Aufzählungszeichen sind besonders nützlich, wenn etwas in Schritten beschrieben werden soll. Außerdem wirkt der Text durch die Verwendung von Aufzählungszeichen gut strukturiert. Aufgezählte Absätze sind stets leichter zu lesen und zu verstehen. Wir werden sehen, wie Entwickler diese kleine, aber leistungsfähige Funktion von Aspose.Slides for Node.js via Java nutzen können. Bitte folgen Sie den untenstehenden Schritten, um Aufzählungszeichen in Absätzen mit Aspose.Slides for Node.js via Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Greifen Sie mit dem Objekt [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) auf die gewünschte Folie in der Folienkollektion zu.
3. Fügen Sie der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im TextFrame.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph).
7. Legen Sie den Aufzählungstyp des Absatzes fest.
8. Stellen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) ein und legen Sie das Aufzählungszeichen fest.
9. Setzen Sie den Absatztext.
10. Legen Sie den Absatz‑Einzug fest, um das Aufzählungszeichen zu setzen.
11. Setzen Sie die Farbe des Aufzählungszeichens.
12. Stellen Sie die Höhe der Aufzählungszeichen ein.
13. Fügen Sie den erstellten Absatz zur Absatzsammlung des TextFrames hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten **7 bis 13**.
15. Speichern Sie die Präsentation.

Dieser Beispielcode in Java – eine Umsetzung der obigen Schritte – zeigt, wie Sie eine Aufzählungsliste in einer Folie erstellen:
```javascript
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen und Zugriff auf AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Zugriff auf den TextFrame des erstellten AutoShape
    var txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);
    // Erstellen eines Absatzes
    var para = new aspose.slides.Paragraph();
    // Festlegen des Aufzählungsstils und Symbols für den Absatz
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Festlegen des Absatztexts
    para.setText("Welcome to Aspose.Slides");
    // Festlegen des Aufzählungseinzugs
    para.getParagraphFormat().setIndent(25);
    // Festlegen der Aufzählungsfarbe
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // IsBulletHardColor auf true setzen, um eine eigene Aufzählungsfarbe zu verwenden
    para.getParagraphFormat().getBullet().isBulletHardColor();
    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);
    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para);
    // Speichern der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Bildbasierte Aufzählungszeichen erstellen**

Aspose.Slides for Node.js via Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse hinzufügen oder die Aufmerksamkeit noch stärker auf Listeneinträge lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise sollten Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen. 

In jedem Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe reduziert, daher empfehlen wir dringend, ein Bild auszuwählen, das in einer Liste (als Ersatz für das Aufzählungszeichen) gut aussieht. 

{{% /alert %}} 

Um ein bildbasiertes Aufzählungszeichen zu erstellen, gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Greifen Sie mit dem Objekt [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) auf die gewünschte Folie in der Folienkollektion zu.
3. Fügen Sie der ausgewählten Folie ein Autoshape hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph.
7. Laden Sie das Bild von der Festplatte in [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
8. Stellen Sie den Aufzählungstyp auf Bild ein und setzen Sie das Bild.
9. Setzen Sie den Absatztext.
10. Legen Sie den Absatz‑Einzug fest, um das Aufzählungszeichen zu setzen.
11. Setzen Sie die Farbe des Aufzählungszeichens.
12. Stellen Sie die Höhe der Aufzählungszeichen ein.
13. Fügen Sie den erstellten Absatz zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den vorherigen Schritten.
15. Speichern Sie die Präsentation.

Dieser JavaScript‑Code zeigt, wie Sie ein bildbasiertes Aufzählungszeichen in einer Folie erstellen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Bild für Aufzählungszeichen instanziieren
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Hinzufügen und Zugriff auf AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Zugriff auf den TextFrame des erstellten AutoShape
    var txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);
    // Erstellen eines neuen Absatzes
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // Festlegen des Absatz-Auftzählungsstils und Bildes
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);
    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para);
    // Schreiben der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Mehrstufige Aufzählungszeichen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält – zusätzliche Listen unter der Hauptauflistung – gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Greifen Sie mit dem Objekt [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) auf die gewünschte Folie in der Folienkollektion zu.
3. Fügen Sie der ausgewählten Folie ein Autoshape hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 3.
10. Fügen Sie die erstellten Absätze zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) hinzu.
11. Speichern Sie die Präsentation.

Dieser Code, der eine Umsetzung der obigen Schritte darstellt, zeigt, wie Sie eine mehrstufige Aufzählungsliste in JavaScript erstellen:
```javascript
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen und Zugriff auf AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Zugriff auf den TextFrame des erstellten AutoShape
    var txtFrm = aShp.addTextFrame("");
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().clear();
    // Erstellen des ersten Absatzes
    var para1 = new aspose.slides.Paragraph();
    // Festlegen des Absatz-Auftzählungsstils und Symbols
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Festlegen der Aufzählungsebene
    para1.getParagraphFormat().setDepth(0);
    // Erstellen des zweiten Absatzes
    var para2 = new aspose.slides.Paragraph();
    // Festlegen des Absatz-Auftzählungsstils und Symbols
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Festlegen der Aufzählungsebene
    para2.getParagraphFormat().setDepth(1);
    // Erstellen des dritten Absatzes
    var para3 = new aspose.slides.Paragraph();
    // Festlegen des Absatz-Auftzählungsstils und Symbols
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Festlegen der Aufzählungsebene
    para3.getParagraphFormat().setDepth(2);
    // Erstellen des vierten Absatzes
    var para4 = new aspose.slides.Paragraph();
    // Festlegen des Absatz-Auftzählungsstils und Symbols
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Festlegen der Aufzählungsebene
    para4.getParagraphFormat().setDepth(3);
    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    // Speichern der Präsentation als PPTX-Datei
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Benutzerdefinierte nummerierte Liste erstellen**

Aspose.Slides for Node.js via Java bietet eine einfache API zur Verwaltung von Absätzen mit benutzerdefinierter Zahlenformatierung. Um einer Absatzliste eine benutzerdefinierte Nummerierung hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Greifen Sie mit dem Objekt [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) auf die gewünschte Folie in der Folienkollektion zu.
3. Fügen Sie der ausgewählten Folie ein Autoshape hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 2.
7. Erstellen Sie die zweite Absatzinstanz mit der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 3.
8. Erstellen Sie die dritte Absatzinstanz mit der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 7.
9. Fügen Sie die erstellten Absätze zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) hinzu.
10. Speichern Sie die Präsentation.

Dieser JavaScript‑Code zeigt, wie Sie eine nummerierte Liste in einer Folie erstellen:
```javascript
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen und Zugriff auf AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Zugriff auf den TextFrame des erstellten AutoShape
    var txtFrm = aShp.addTextFrame("");
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().clear();
    // Erste Liste
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);
    // Zweite Liste
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(5);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);
    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Können mit Aspose.Slides erstellte Aufzählungs‑ und nummerierte Listen in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt die Formatierung und Struktur von Aufzählungs‑ und nummerierten Listen vollständig, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt so für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs‑ oder nummerierte Listen aus vorhandenen Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs‑ oder nummerierten Listen aus bestehenden Präsentationen, wobei deren ursprüngliche Formatierung und Erscheinungsbild erhalten bleiben.

**Unterstützt Aspose.Slides Aufzählungs‑ und nummerierte Listen in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und nummerierten Listen in jeder Sprache, einschließlich der Verwendung von Sonder- oder Nicht‑Latein‑Zeichen.