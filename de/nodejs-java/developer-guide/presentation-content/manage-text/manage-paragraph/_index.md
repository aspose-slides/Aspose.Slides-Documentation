---
title: PowerPoint-Textabsätze in JavaScript verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
  - Text hinzufügen
  - Absatz hinzufügen
  - Text verwalten
  - Absatz verwalten
  - Aufzählung verwalten
  - Absatzeinzug
  - hängender Einzug
  - Absatz‑Aufzählung
  - nummerierte Liste
  - Aufzählungsliste
  - Absatzeigenschaften
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
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für Node.js über Java — optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX‑ und ODP‑Präsentationen in JavaScript."
---
## **Einleitung**

Aspose.Slides stellt alle Klassen zur Verfügung, die Sie benötigen, um in Java mit PowerPoint‑Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die Klasse [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) bereit, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `TextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Wagenrücklauf erstellt).
* Aspose.Slides stellt die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) bereit, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `Paragraph`‑Objekt kann eine oder mehrere Portionen enthalten (Sammlung von Textportion‑Objekten).
* Aspose.Slides stellt die Klasse [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/) bereit, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften repräsentieren.

Ein `Paragraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `Portion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen TextFrame mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Holen Sie das mit dem [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) verknüpfte `ITextFrame`.
5. Erstellen Sie zwei [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/)‑Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu.
6. Erstellen Sie für jedes neue `Paragraph` drei [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/)‑Objekte (zwei Portion‑Objekte für den Standard‑Paragraph) und fügen Sie jedes `Portion`‑Objekt der IPortion‑Sammlung des jeweiligen `Paragraph` hinzu.
7. Setzen Sie für jede Portion etwas Text.
8. Wenden Sie Ihre bevorzugten Formatierungsfunktionen auf jede Portion an, indem Sie die vom `Portion`‑Objekt bereitgestellten Formatierungseigenschaften nutzen.
9. Speichern Sie die geänderte Präsentation.

```javascript
// Instanziieren Sie eine Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Zugriff auf das TextFrame des AutoShape
    var tf = ashp.getTextFrame();
    // Erstellen Sie Paragraphen und Portionen mit verschiedenen Textformaten
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
    // PPTX auf Disk schreiben
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Absatz‑Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Paragraph im `TextFrame`.
6. Erstellen Sie die erste Paragraph‑Instanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/).
7. Setzen Sie den Aufzählungs‑`Type` des Paragraphs auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Setzen Sie den Paragraph‑`Text`.
9. Setzen Sie den Paragraph‑`Indent` für die Aufzählung.
10. Legen Sie eine Farbe für das Aufzählungszeichen fest.
11. Legen Sie eine Höhe für das Aufzählungszeichen fest.
12. Fügen Sie den neuen Paragraph zur Paragraph‑Sammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Paragraph hinzu und wiederholen Sie die Schritte 7‑12.
14. Speichern Sie die Präsentation.

```javascript
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Fügt ein AutoShape hinzu und greift darauf zu
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf das TextFrame des AutoShape zu
    var txtFrm = aShp.getTextFrame();
    // Entfernt den Standard‑Paragraph
    txtFrm.getParagraphs().removeAt(0);
    // Erstellt einen Paragraphen
    var para = new aspose.slides.Paragraph();
    // Legt den Aufzählungsstil und das Symbol für den Paragraphen fest
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Setzt den Text des Paragraphen
    para.setText("Welcome to Aspose.Slides");
    // Legt den Aufzählungs‑Einzug fest
    para.getParagraphFormat().setIndent(25);
    // Legt die Aufzählungsfarbe fest
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // Setze IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden
    // Legt die Aufzählungshöhe fest
    para.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Paragraphen dem TextFrame hinzu
    txtFrm.getParagraphs().add(para);
    // Erstellt einen zweiten Paragraphen
    var para2 = new aspose.slides.Paragraph();
    // Legt den Aufzählungstyp und -stil des Paragraphen fest
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Fügt den Paragraphentext hinzu
    para2.setText("This is numbered bullet");
    // Legt den Aufzählungs‑Einzug fest
    para2.getParagraphFormat().setIndent(25);
    // Legt die Aufzählungsfarbe fest
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // Setze IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden
    // Legt die Aufzählungshöhe fest
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Paragraphen dem TextFrame hinzu
    txtFrm.getParagraphs().add(para2);
    // Speichert die geänderte Präsentation
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bild‑Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bild‑Absätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Paragraph im `TextFrame`.
6. Erstellen Sie die erste Paragraph‑Instanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/).
7. Laden Sie das Bild in [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/).
8. Setzen Sie den Aufzählungs‑Typ auf [Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) und legen Sie das Bild fest.
9. Setzen Sie den Paragraph‑`Text`.
10. Setzen Sie den Paragraph‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für das Aufzählungszeichen fest.
12. Legen Sie eine Höhe für das Aufzählungszeichen fest.
13. Fügen Sie den neuen Paragraph zur Paragraph‑Sammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Paragraph hinzu und wiederholen Sie die vorherigen Schritte.
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
    // Fügt ein AutoShape hinzu und greift darauf zu
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf das Textframe des AutoShape zu
    var textFrame = autoShape.getTextFrame();
    // Entfernt den Standard‑Paragraph
    textFrame.getParagraphs().removeAt(0);
    // Erstellt einen neuen Paragraphen
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Legt den Aufzählungsstil und das Bild des Paragraphen fest
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Legt die Aufzählungshöhe fest
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Paragraphen dem Textframe hinzu
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

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie in der neuen Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Paragraph im `TextFrame`.
6. Erstellen Sie die erste Paragraph‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Paragraph‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Paragraph‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Paragraph‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Paragraphen zur Paragraph‑Sammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

```javascript
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Fügt ein AutoShape hinzu und greift darauf zu
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf das Textframe des erstellten AutoShape zu
    var text = aShp.addTextFrame("");
    // Löscht den Standard‑Paragraph
    text.getParagraphs().clear();
    // Fügt den ersten Paragraphen hinzu
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Legt die Aufzählungsebene fest
    para1.getParagraphFormat().setDepth(0);
    // Fügt den zweiten Paragraphen hinzu
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Legt die Aufzählungsebene fest
    para2.getParagraphFormat().setDepth(1);
    // Fügt den dritten Paragraphen hinzu
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Legt die Aufzählungsebene fest
    para3.getParagraphFormat().setDepth(2);
    // Fügt den vierten Paragraphen hinzu
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Legt die Aufzählungsebene fest
    para4.getParagraphFormat().setDepth(3);
    // Fügt die Paragraphen zur Sammlung hinzu
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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Folie zu, die den Paragraph enthält.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Paragraph im `TextFrame`.
6. Erstellen Sie die erste Paragraph‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Paragraph‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Paragraph‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Paragraphen zur Paragraph‑Sammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf das Textframe des erstellten AutoShape zu
    var textFrame = shape.getTextFrame();
    // Entfernt den standardmäßig vorhandenen Paragraphen
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

## **Erste‑Zeilen‑Einzug für einen Paragraph festlegen**

Verwenden Sie die Methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/), um den Erstzeileneinzug eines Paragraphs zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Paragraphs. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Paragraphenkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/), wenn Sie den gesamten Paragraphen verschieben wollen. Verwenden Sie [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/), wenn Sie nur die erste Zeile verschieben möchten.

Das nachstehende Beispiel erstellt mehrere Paragraphen und wendet unterschiedliche Einzugswerte an, um zu demonstrieren, wie der Erstzeileneinzug das Layout beeinflusst.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Paragraph.
5. Erstellen Sie mehrere Paragraphen und setzen Sie unterschiedliche [Indent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/)‑Werte für sie.
6. Fügen Sie die Paragraphen zum TextFrame hinzu.
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

Das Ergebnis:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Hängenden Einzug für einen Paragraph festlegen**

Ein hängender Einzug ist ein Paragraphenlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Methode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/). Setzen Sie den Einzug auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) die linke Position des Paragraphenkörpers, und [ParagraphFormat.setIndent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/) definiert die Position der ersten Zeile relativ zu diesem Rand. Für einen hängenden Einzug setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Diese Formatierung ist nützlich für Bibliographien, Quellenangaben, Glossareinträge und andere Paragraphen, bei denen umgebrochene Zeilen unter dem Paragraphenkörper ausgerichtet sein müssen und nicht unter dem ersten Zeichen der ersten Zeile.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Paragraph.
5. Erstellen Sie Paragraphen und setzen Sie für jeden Paragraphen einen positiven [MarginLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)‑Wert.
6. Setzen Sie einen negativen [Indent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setindent/)‑Wert, um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Paragraphen zum TextFrame hinzu.
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

Das Ergebnis:

![The hanging indent of the paragraphs](hanging_indent.png)

## **End‑Paragraph‑Lauf‑Eigenschaften für Paragraph verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
1. Holen Sie die Referenz für die Folie, die den Paragraph enthält, über ihre Position.
1. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) mit zwei Paragraphen hinzu.
1. Setzen Sie `FontHeight` und die Schriftart für die Paragraphen.
1. Setzen Sie die End‑Eigenschaften für die Paragraphen.
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

## **HTML‑Text in Paragraphen importieren**

Aspose.Slides bietet erweiterte Unterstützung für das Importieren von HTML‑Text in Paragraphen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem `AutoShape` ein [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standard‑Paragraph im `TextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader ein.
7. Erstellen Sie die erste Paragraph‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/).
8. Fügen Sie den Inhalt der HTML‑Datei aus dem gelesenen TextReader zur [ParagraphCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

```javascript
// Leere Präsentationsinstanz erstellen
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die standardmäßige erste Folie der Präsentation
    var slide = pres.getSlides().get_Item(0);
    // AutoShape hinzufügen, um den HTML-Inhalt aufzunehmen
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Textframe zum Shape hinzufügen
    ashape.addTextFrame("");
    // Alle Paragraphen im hinzugefügten Textframe leeren
    ashape.getTextFrame().getParagraphs().clear();
    // HTML-Datei mit StreamReader laden
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Text aus dem HTML-StreamReader in das Textframe einfügen
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Präsentation speichern
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Paragraph‑Texte nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (enthalten in Paragraphen) nach HTML.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Greifen Sie auf das Shape zu, das den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) des Shapes zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Start‑Index an den StreamWriter weiter und exportieren Sie die gewünschten Paragraphen.

```javascript
// Lade die Präsentationsdatei
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    var slide = pres.getSlides().get_Item(0);
    // Gewünschter Index
    var index = 0;
    // Zugriff auf das hinzugefügte Shape
    var ashape = slide.getShapes().get_Item(index);
    // Ausgabe‑HTML‑Datei erstellen
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extrahiere den ersten Paragraphen als HTML
    // Schreibe Paragraphendaten nach HTML, indem der Start‑Index des Paragraphen und die Gesamtzahl zu kopierenden Paragraphen angegeben werden
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Paragraph als Bild speichern**

In diesem Abschnitt untersuchen wir zwei Beispiele, die zeigen, wie ein Text‑Paragraph, repräsentiert durch die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/), als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes eines Shapes, das den Paragraph enthält, mittels der `getImage`‑Methoden der Klasse [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/), die Berechnung der Begrenzungen des Paragraphs innerhalb des Shapes und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren bestimmter Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens **sample.pptx** mit einer Folie, bei der das erste Shape ein Textfeld mit drei Paragraphen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Paragraphen als Bild. Dazu extrahieren wir das Bild des Shapes von der ersten Folie der Präsentation und berechnen anschließend die Begrenzungen des zweiten Paragraphen im TextFrame des Shapes. Der Paragraph wird dann auf ein neues Bitmap‑Bild gezeichnet und im PNG‑Format gespeichert. Dieses Verfahren ist besonders nützlich, wenn ein bestimmter Paragraph als separates Bild gespeichert werden soll, wobei die genauen Abmessungen und die Formatierung des Textes erhalten bleiben.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Speichere das Shape im Speicher als Bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Erstelle ein Shape-Bitmap aus dem Speicher.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Berechne die Grenzen des zweiten Paragraphen.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Berechne die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Schneide das Shape-Bitmap zu, um nur das Paragraphen-Bitmap zu erhalten.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Das Ergebnis:

![The paragraph image](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Paragraph‑Bild hinzufügen. Das Shape wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein hochauflösendes Ergebnis beim Export des Paragraphen. Die Paragraph‑Begrenzungen werden anschließend unter Berücksichtigung des Maßstabs berechnet. Skalierung ist besonders nützlich, wenn ein detaillierteres Bild benötigt wird, zum Beispiel für den Einsatz in hochwertigen Drucksachen.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Speichere das Shape im Speicher als Bitmap mit Skalierung.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Erstelle ein Shape‑Bitmap aus dem Speicher.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Berechne die Grenzen des zweiten Paragraphen.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Berechne die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Beschneide das Shape‑Bitmap, um nur das Paragraphen‑Bitmap zu erhalten.
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

**Kann ich das Zeilenumbruch‑Verhalten innerhalb eines TextFrames vollständig deaktivieren?**

Ja. Verwenden Sie die Einstellung zum Umbruch des TextFrames ([setWrapText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/setwraptext/)), um den Umbruch auszuschalten, sodass Zeilen nicht an den Rändern des Frames umgebrochen werden.

**Wie kann ich die genauen Folien‑Begrenzungen eines bestimmten Paragraphen ermitteln?**

Sie können das Begrenzungsrechteck des Paragraphen (und sogar einer einzelnen Portion) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[setAlignment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setalignment/) ist eine Methode für die Absatz‑Ebene in [ParagraphFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/); sie gilt für den gesamten Paragraphen, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreibprüfungssprache nur für einen Teil eines Paragraphen festlegen (z. B. ein Wort)?**

Ja. Die Sprache wird auf Portion‑Ebene festgelegt ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), sodass mehrere Sprachen innerhalb eines einzelnen Paragraphen coexistieren können.