---
title: Aufzählungen verwalten
type: docs
weight: 60
url: /de/nodejs-java/manage-bullet/
keywords: "Aufzählungszeichen, Aufzählungslisten, Zahlen, nummerierte Listen, Bildaufzählungen, mehrstufige Aufzählungen, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Erstellen Sie Aufzählungs- und nummerierte Listen in PowerPoint-Präsentationen in JavaScript"
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und nummerierte Listen auf dieselbe Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for Node.js via Java** ermöglicht es Ihnen ebenfalls, Aufzählungszeichen und Nummern in Folien Ihrer Präsentationen zu verwenden.

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste diese drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Betrachter auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Betrachtern, Schlüssel­punkte leicht zu überfliegen
- kommuniziert und liefert wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls beim Organisieren und Präsentieren von Informationen. Idealerweise sollten Sie Zahlen (anstelle von Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (zum Beispiel *Schritt 1, Schritt 2*, usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (zum Beispiel *siehe Schritt 3*).

**Beispiel für nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im unten stehenden Verfahren **Bullets erstellen**:

1. Erstellen Sie eine Instanz der Präsentationsklasse. 
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation. 

## **Bullets erstellen**

Dieses Thema ist ebenfalls Teil der Themenreihe zur Verwaltung von Textabsätzen. Diese Seite zeigt, wie wir Absatz‑Aufzählungszeichen verwalten können. Aufzählungszeichen sind besonders nützlich, wenn etwas in Schritten beschrieben werden soll. Außerdem wirkt der Text durch die Verwendung von Aufzählungszeichen gut strukturiert. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen. Wir werden sehen, wie Entwickler diese kleine, aber leistungsstarke Funktion von Aspose.Slides for Node.js via Java nutzen können. Bitte folgen Sie den nachstehenden Schritten, um die Absatz‑Aufzählungszeichen mit Aspose.Slides for Node.js via Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Greifen Sie mit dem Objekt [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie in der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) hinzu.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) der hinzugefügten Form zu.
1. Entfernen Sie den Standardsatz im TextFrame.
1. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph).
1. Legen Sie den Aufzählungstyp des Absatzes fest.
1. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) und definieren Sie das Aufzählungszeichen.
1. Legen Sie den Absatztext fest.
1. Stellen Sie den Absatz‑Einzug ein, um das Aufzählungszeichen zu setzen.
1. Setzen Sie die Farbe des Aufzählungszeichens.
1. Stellen Sie die Höhe der Aufzählungszeichen ein.
1. Fügen Sie den erstellten Absatz in die Absatz‑Kollektion des TextFrames ein.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten **7 bis 13**.
1. Speichern Sie die Präsentation.

Dieser Beispielcode in Java – eine Umsetzung der obigen Schritte – zeigt, wie Sie eine Aufzählungsliste in einer Folie erstellen:
```javascript
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen und Zugriff auf ein Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Zugriff auf den Textrahmen des erstellten Autoshapes
    var txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);
    // Erstellen eines Absatzes
    var para = new aspose.slides.Paragraph();
    // Festlegen des Aufzählungsstils und -symbols für den Absatz
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
    // Hinzufügen des Absatzes zum Textrahmen
    txtFrm.getParagraphs().add(para);
    // Speichern der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Bild‑Aufzählungszeichen erstellen**

Aspose.Slides for Node.js via Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder die Aufmerksamkeit noch stärker auf Einträge einer Liste lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, sollten Sie ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen.

In jedem Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe reduziert, daher empfehlen wir dringend, ein Bild auszuwählen, das in einer Liste gut aussieht (als Ersatz für das Aufzählungszeichen). 

{{% /alert %}} 

Um ein Bild‑Aufzählungszeichen zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Greifen Sie mit dem Objekt [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie in der ausgewählten Folie ein autoshape hinzu.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardsatz im [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph‑Klasse.
1. Laden Sie ein Bild von der Festplatte in [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/PPImage).
1. Setzen Sie den Aufzählungstyp auf Picture und legen Sie das Bild fest.
1. Legen Sie den Absatztext fest.
1. Stellen Sie den Absatz‑Einzug ein, um das Aufzählungszeichen zu setzen.
1. Setzen Sie die Farbe des Aufzählungszeichens.
1. Stellen Sie die Höhe der Aufzählungszeichen ein.
1. Fügen Sie den erstellten Absatz in die Absatz‑Kollektion des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) ein.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den vorherigen Schritten.
1. Speichern Sie die Präsentation.

Dieser JavaScript‑Code zeigt, wie Sie ein Bild‑Aufzählungszeichen in einer Folie erstellen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Bild für Aufzählungszeichen erstellen
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Hinzufügen und Zugriff auf ein Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Zugriff auf den Textrahmen des erstellten Autoshapes
    var txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);
    // Neuen Absatz erstellen
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // Festlegen des Absatz-Aufzählungsstils und Bildes
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);
    // Absatz zum Textrahmen hinzufügen
    txtFrm.getParagraphs().add(para);
    // Präsentation als PPTX-Datei schreiben
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Mehrstufige Aufzählungszeichen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält – zusätzliche Listen unter der Haupt‑Aufzählungsliste – gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Greifen Sie mit dem Objekt [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie in der ausgewählten Folie ein autoshape hinzu.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardsatz im [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 0.
1. Erstellen Sie die zweite Absatzinstanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 1.
1. Erstellen Sie die dritte Absatzinstanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 2.
1. Erstellen Sie die vierte Absatzinstanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 3.
1. Fügen Sie die erstellten Absätze in die Absatz‑Kollektion des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) ein.
1. Speichern Sie die Präsentation.

Dieser Code, der die obigen Schritte umsetzt, zeigt, wie Sie eine mehrstufige Aufzählungsliste in JavaScript erstellen:
```javascript
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen und Zugriff auf ein Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Zugriff auf den Textrahmen des erstellten Autoshapes
    var txtFrm = aShp.addTextFrame("");
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().clear();
    // Erstellen des ersten Absatzes
    var para1 = new aspose.slides.Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Festlegen der Aufzählungsebene
    para1.getParagraphFormat().setDepth(0);
    // Erstellen des zweiten Absatzes
    var para2 = new aspose.slides.Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Festlegen der Aufzählungsebene
    para2.getParagraphFormat().setDepth(1);
    // Erstellen des dritten Absatzes
    var para3 = new aspose.slides.Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Festlegen der Aufzählungsebene
    para3.getParagraphFormat().setDepth(2);
    // Erstellen des vierten Absatzes
    var para4 = new aspose.slides.Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und Symbols
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Festlegen der Aufzählungsebene
    para4.getParagraphFormat().setDepth(3);
    // Hinzufügen des Absatzes zum Textrahmen
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

Aspose.Slides for Node.js via Java bietet eine einfache API, um Absätze mit benutzerdefinierter Zahlenformatierung zu verwalten. Um einer Absatzliste eine benutzerdefinierte Nummerierung hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Greifen Sie mit dem Objekt [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) auf die gewünschte Folie in der Folienkollektion zu.
1. Fügen Sie in der ausgewählten Folie ein autoshape hinzu.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardsatz im [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph‑Klasse und setzen Sie **NumberedBulletStartWith** auf 2.
1. Erstellen Sie die zweite Absatzinstanz mit der Paragraph‑Klasse und setzen Sie **NumberedBulletStartWith** auf 3.
1. Erstellen Sie die dritte Absatzinstanz mit der Paragraph‑Klasse und setzen Sie **NumberedBulletStartWith** auf 7.
1. Fügen Sie die erstellten Absätze in die Absatz‑Kollektion des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) ein.
1. Speichern Sie die Präsentation.

Dieser JavaScript‑Code zeigt, wie Sie eine nummerierte Liste in einer Folie erstellen:
```javascript
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen und Zugriff auf ein Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Zugriff auf den Textrahmen des erstellten Autoshapes
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

**Können mit Aspose.Slides erstellte Aufzählungs‑ und Nummerierungslisten in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt die Formatierung und Struktur von Aufzählungs‑ und Nummerierungslisten vollständig, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt dabei für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs‑ oder Nummerierungslisten aus vorhandenen Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht es, Aufzählungs‑ oder Nummerierungslisten aus bestehenden Präsentationen zu importieren und zu bearbeiten, wobei deren ursprüngliche Formatierung und Darstellung erhalten bleiben.

**Unterstützt Aspose.Slides Aufzählungs‑ und Nummerierungslisten in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollumfänglich und ermöglicht das Erstellen von Aufzählungs‑ und Nummerierungslisten in jeder Sprache, einschließlich der Verwendung spezieller oder nicht‑lateinischer Zeichen.