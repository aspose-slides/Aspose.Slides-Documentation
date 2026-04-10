---
title: PowerPoint-Textabsätze in JavaScript verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/nodejs-java/manage-paragraph/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatz-Einzug
- Hängender Einzug
- Absatz-Aufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatz-Eigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für Node.js via Java—optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP-Präsentationen in JavaScript."
---
Aspose.Slides bietet alle Klassen, die Sie benötigen, um in Java mit PowerPoint-Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die Klasse [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) zur Verfügung, um Objekte hinzuzufügen, die einen Absatz darstellen. Ein `TextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erzeugt).
* Aspose.Slides stellt die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) zur Verfügung, um Objekte hinzuzufügen, die Abschnitte (Portionen) darstellen. Ein `Paragraph`‑Objekt kann eine oder mehrere Portionen enthalten (eine Sammlung von Textportion‑Objekten).
* Aspose.Slides stellt die Klasse [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/) zur Verfügung, um Objekte hinzuzufügen, die Texte und deren Formatierungseigenschaften darstellen.

Ein `Paragraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `Portion`‑Objekte verarbeiten.

## **Mehrere Absätze hinzufügen, die mehrere Portionen enthalten**

Diese Schritte zeigen, wie Sie ein TextFrame hinzufügen, das 3 Absätze enthält und jeder Absatz 3 Portionen enthält:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Rufen Sie das mit dem [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) verbundene ITextFrame ab.
5. Erstellen Sie zwei [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/)-Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu.
6. Erstellen Sie für jedes neue `Paragraph` drei [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/)-Objekte (zwei Portion‑Objekte für den Standard‑Paragraph) und fügen Sie jedes `Portion`‑Objekt der IPortion‑Sammlung des jeweiligen `Paragraph` hinzu.
7. Legen Sie für jede Portion einen Text fest.
8. Wenden Sie die gewünschten Formatierungsoptionen auf jede Portion an, indem Sie die vom `Portion`‑Objekt bereitgestellten Formatierungseigenschaften verwenden.
9. Speichern Sie die geänderte Präsentation.

```javascript
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie zugreifen
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rechteck hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // TextFrame des AutoShape zugreifen
    var tf = ashp.getTextFrame();
    // Absätze und Portionen mit unterschiedlichen Textformaten erstellen
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // PPTX auf die Festplatte schreiben
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Absatz-Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Aufgelistete Absätze sind immer leichter zu lesen und zu verstehen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mithilfe der Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/).
7. Setzen Sie den Aufzählungstyp `Type` des Absatzes auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
10. Legen Sie eine Farbe für das Aufzählungszeichen fest.
11. Legen Sie die Höhe des Aufzählungszeichens fest.
12. Fügen Sie den neuen Absatz der Absatz‑Sammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

```javascript
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Fügt ein Autoshape hinzu und greift darauf zu
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf das Textfeld des Autoshapes zu
    var txtFrm = aShp.getTextFrame();
    // Entfernt den Standardabsatz
    txtFrm.getParagraphs().removeAt(0);
    // Erstellt einen Absatz
    var para = new aspose.slides.Paragraph();
    // Legt den Aufzählungsstil und das Symbol für den Absatz fest
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Setzt den Absatztext
    para.setText("Welcome to Aspose.Slides");
    // Setzt den Aufzählungseinzug
    para.getParagraphFormat().setIndent(25);
    // Setzt die Aufzählungsfarbe
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// IsBulletHardColor auf true setzen, um eigene Aufzählungsfarbe zu verwenden
    // Setzt die Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Absatz dem Textfeld hinzu
    txtFrm.getParagraphs().add(para);
    // Erstellt einen zweiten Absatz
    var para2 = new aspose.slides.Paragraph();
    // Legt den Aufzählungstyp und -stil für den Absatz fest
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Fügt den Absatztext hinzu
    para2.setText("This is numbered bullet");
    // Setzt den Aufzählungseinzug
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// IsBulletHardColor auf true setzen, um eigene Aufzählungsfarbe zu verwenden
    // Setzt die Aufzählungshöhe
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Absatz dem Textfeld hinzu
    txtFrm.getParagraphs().add(para2);
    // Speichert die modifizierte Präsentation
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bildaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Bild‑Absätze sind leicht zu lesen und zu verstehen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mithilfe der Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/).
7. Laden Sie das Bild mit [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/).
8. Setzen Sie den Aufzählungstyp auf [Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für das Aufzählungszeichen fest.
12. Legen Sie die Höhe des Aufzählungszeichens fest.
13. Fügen Sie den neuen Absatz der Absatz‑Sammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang anhand der vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

```javascript
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
var presentation = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = presentation.getSlides().get_Item(0);
    // Instanziiert das Bild für Aufzählungszeichen
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Fügt ein Autoshape hinzu und greift darauf zu
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf das Textframe des Autoshapes zu
    var textFrame = autoShape.getTextFrame();
    // Entfernt den Standardabsatz
    textFrame.getParagraphs().removeAt(0);
    // Erstellt einen neuen Absatz
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Setzt den Aufzählungsstil und das Bild für den Absatz
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Setzt die Aufzählungshöhe
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Absatz dem Textframe hinzu
    textFrame.getParagraphs().add(paragraph);
    // Schreibt die Präsentation als PPTX-Datei
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Schreibt die Präsentation als PPT-Datei
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Mehrstufige Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der neuen Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der Absatz‑Sammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

```javascript
    // Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
    var pres = new aspose.slides.Presentation();
    try {
        // Greift auf die erste Folie zu
        var slide = pres.getSlides().get_Item(0);
        // Fügt ein Autoshape hinzu und greift darauf zu
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // Greift auf das Textfeld des erstellten Autoshapes zu
        var text = aShp.addTextFrame("");
        // Löscht den Standardabsatz
        text.getParagraphs().clear();
        // Fügt den ersten Absatz hinzu
        var para1 = new aspose.slides.Paragraph();
        para1.setText("Content");
        para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para1.getParagraphFormat().getBullet().setChar(8226);
        para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Setzt die Aufzählungsebene
        para1.getParagraphFormat().setDepth(0);
        // Fügt den zweiten Absatz hinzu
        var para2 = new aspose.slides.Paragraph();
        para2.setText("Second Level");
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para2.getParagraphFormat().getBullet().setChar('-');
        para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Setzt die Aufzählungsebene
        para2.getParagraphFormat().setDepth(1);
        // Fügt den dritten Absatz hinzu
        var para3 = new aspose.slides.Paragraph();
        para3.setText("Third Level");
        para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para3.getParagraphFormat().getBullet().setChar(8226);
        para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Setzt die Aufzählungsebene
        para3.getParagraphFormat().setDepth(2);
        // Fügt den vierten Absatz hinzu
        var para4 = new aspose.slides.Paragraph();
        para4.setText("Fourth Level");
        para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para4.getParagraphFormat().getBullet().setChar('-');
        para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Setzt die Aufzählungsebene
        para4.getParagraphFormat().setDepth(3);
        // Fügt die Absätze zur Sammlung hinzu
        text.getParagraphs().add(para1);
        text.getParagraphs().add(para2);
        text.getParagraphs().add(para3);
        text.getParagraphs().add(para4);
        // Schreibt die Präsentation als PPTX-Datei
        pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Absatz mit benutzerdefinierter nummerierter Liste verwalten**

Die Klasse [BulletFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/) stellt die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) und weitere bereit, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der Absatz‑Sammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf das Textfeld des erstellten Autoshape zu
    var textFrame = shape.getTextFrame();
    // Entfernt den standardmäßig vorhandenen Absatz
    textFrame.getParagraphs().removeAt(0);
    // Erste Liste
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Erste-Zeilen‑Einzug für einen Absatz festlegen**

Verwenden Sie die Methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/) um den Erste‑Zeilen‑Einzug eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/) wenn Sie nur die erste Zeile verschieben möchten.

Das nachstehende Beispiel erstellt mehrere Absätze und wendet unterschiedliche Einzugswerte an, um zu zeigen, wie der Erste‑Zeilen‑Einzug das Layout des Absatzes beeinflusst.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folien zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie der Form ein leeres [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie mehrere Absätze und setzen Sie für sie unterschiedliche [Indent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/)‑Werte.
6. Fügen Sie die Absätze dem TextFrame hinzu.
7. Speichern Sie die geänderte Präsentation.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![Der Erste‑Zeilen‑Einzug der Absätze](first_line_indent.png)

## **Hängenden Einzug für einen Absatz festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/). Setzen Sie den Einzug auf einen negativen Wert, um die erste Zeile relativ zum Absatzkörper nach links zu verschieben.

In der Praxis definiert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/), die linke Position des Absatzkörpers, und [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/), die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Diese Formatierung ist nützlich für Bibliographien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet werden müssen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folien zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie der Form ein leeres [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie Absätze und setzen Sie für jeden Absatz einen positiven [MarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)‑Wert.
6. Setzen Sie einen negativen [Indent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/)‑Wert, um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem TextFrame hinzu.
8. Speichern Sie die geänderte Präsentation.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![Der hängende Einzug der Absätze](hanging_indent.png)

## **Endlauf‑Eigenschaften für Absatz verwalten**

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
1. Holen Sie die Referenz der Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) mit zwei Absätzen hinzu.
1. Setzen Sie die `FontHeight` und den Schriftarttyp für die Absätze.
1. Setzen Sie die End‑Eigenschaften für die Absätze.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **HTML‑Text in Absätze importieren**

Aspose.Slides bietet erweiterte Unterstützung zum Importieren von HTML‑Text in Absätze.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem AutoShape ein [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader.
7. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/).
8. Fügen Sie den Inhalt der HTML‑Datei, der im gelesenen TextReader vorliegt, zur [ParagraphCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphcollection/) des TextFrame hinzu.
9. Speichern Sie die geänderte Präsentation.

```javascript
// Leere Präsentationsinstanz erstellen
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    var slide = pres.getSlides().get_Item(0);
    // Fügt das AutoShape hinzu, um den HTML-Inhalt aufzunehmen
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Textfeld zur Form hinzufügen
    ashape.addTextFrame("");
    // Alle Absätze im hinzugefügten Textfeld löschen
    ashape.getTextFrame().getParagraphs().clear();
    // Lädt die HTML-Datei mit StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Fügt Text aus dem HTML-StreamReader in das Textfeld ein
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Präsentation speichern
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Absatz‑Text nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung zum Exportieren von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Greifen Sie auf die Form zu, die den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Start‑Index an den StreamWriter weiter und exportieren Sie Ihre bevorzugten Absätze.

```javascript
// Lädt die Präsentationsdatei
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    var slide = pres.getSlides().get_Item(0);
    // Gewünschter Index
    var index = 0;
    // Greift auf die hinzugefügte Form zu
    var ashape = slide.getShapes().get_Item(index);
    // Erstellt die Ausgabedatei HTML
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extrahiert den ersten Absatz als HTML
    // Schreibt Absatzdaten nach HTML, indem der Startindex des Absatzes und die Gesamtzahl der zu kopierenden Absätze angegeben werden
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Einen Absatz als Bild speichern**

In diesem Abschnitt untersuchen wir zwei Beispiele, die zeigen, wie ein Textabsatz, dargestellt durch die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/), als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes einer Form, die den Absatz enthält, über die `getImage`‑Methoden der Klasse [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/), die Berechnung der Begrenzungen des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Vorgehensweise ermöglicht das Extrahieren spezifischer Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Nehmen wir an, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![Die Textbox mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild der Form von der ersten Folie der Präsentation und berechnen anschließend die Begrenzungen des zweiten Absatzes im TextFrame der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild neu gezeichnet und im PNG‑Format gespeichert. Dieses Verfahren ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild speichern wollen, dabei aber die genauen Abmessungen und die Formatierung des Textes beibehalten möchten.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Speichert die Form im Speicher als Bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Erstellt ein Form-Bitmap aus dem Speicher.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Berechnet die Grenzen des zweiten Absatzes.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Berechnet die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Beschneidet das Form-Bitmap, um nur das Absatz-Bitmap zu erhalten.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

![Das Absatzbild](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatzbild hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein Bild mit höherer Auflösung. Die Absatz‑Begrenzungen werden unter Berücksichtigung der Skalierung berechnet. Skalierung ist besonders nützlich, wenn ein detaillierteres Bild benötigt wird, etwa für den Einsatz in hochwertig gedruckten Materialien.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Speichert die Form im Speicher als Bitmap mit Skalierung.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Erstellt ein Form-Bitmap aus dem Speicher.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Berechnet die Grenzen des zweiten Absatzes.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Berechnet die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Beschneidet das Form-Bitmap, um nur das Absatz-Bitmap zu erhalten.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Kann ich das Zeilenumbruchverhalten in einem TextFrame vollständig deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Einstellung des TextFrames ([setWrapText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/setwraptext/)), um den Umbruch zu deaktivieren, sodass Zeilen nicht am Rand des Frames umgebrochen werden.

**Wie kann ich die genauen Positionen eines bestimmten Absatzes auf der Folie erhalten?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar einer einzelnen Portion) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatzausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[setAlignment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setalignment/) ist eine Methode für eine Absatz‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreibprüfungssprache nur für einen Teil eines Absatzes festlegen (z. B. ein Wort)?**

Ja. Die Sprache wird auf Portion‑Ebene festgelegt ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes koexistieren können.