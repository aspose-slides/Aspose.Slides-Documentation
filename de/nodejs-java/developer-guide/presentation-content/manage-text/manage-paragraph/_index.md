---
title: PowerPoint-Absätze in JavaScript verwalten
type: docs
weight: 40
url: /de/nodejs-java/manage-paragraph/
keywords:
- Text hinzufügen
- Absätze hinzufügen
- Text verwalten
- Absätze verwalten
- Absatzeinzug
- Absatz-Aufzählungszeichen
- Nummerierte Liste
- Absatzeigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absätze zu Bildern
- Absätze exportieren
- PowerPoint-Präsentation
- JavaScript
- Aspose.Slides für Node.js über Java
description: "Erstellen Sie Absätze und verwalten Sie Absatzeigenschaften in PowerPoint-Präsentationen in JavaScript"
---

Aspose.Slides stellt alle Klassen bereit, die Sie benötigen, um in Java mit PowerPoint-Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die Klasse [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) bereit, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides stellt die Klasse [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) bereit, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `IParagraph`‑Objekt kann einen oder mehrere Portionen (Sammlung von iPortions‑Objekten) enthalten.
* Aspose.Slides stellt die Klasse [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) bereit, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textrahmen mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein Rechteck‑[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Rufen Sie das mit dem [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) verbundene `ITextFrame` ab.
5. Erstellen Sie zwei [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)-Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)-Objekte (zwei Portion‑Objekte für einen Standard‑Paragraph) und fügen Sie jedes `IPortion`‑Objekt der IPortion‑Sammlung jedes `IParagraph` hinzu.
7. Setzen Sie für jede Portion einen Text.
8. Wenden Sie Ihre bevorzugten Formatierungsoptionen auf jede Portion an, indem Sie die vom `IPortion`‑Objekt bereitgestellten Formatierungseigenschaften nutzen.
9. Speichern Sie die geänderte Präsentation.

```javascript
// Instanziieren einer Presentation‑Klasse, die eine PPTX‑Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rechteck hinzufügen
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // TextFrame des AutoShape abrufen
    var tf = ashp.getTextFrame();
    // Absätze und Portionen mit verschiedenen Textformaten erstellen
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
    // PPTX auf Festplatte schreiben
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Absatzaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufgezählte Absätze sind stets leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) des Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. Setzen Sie den Aufzählungs‑`Type` für den Absatz auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
10. Legen Sie eine Farbe für die Aufzählung fest.
11. Legen Sie eine Höhe für die Aufzählung fest.
12. Fügen Sie den neuen Absatz der Absatz‑Sammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

```javascript
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Fügt eine AutoShape hinzu und greift darauf zu
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf den Textrahmen der AutoShape zu
    var txtFrm = aShp.getTextFrame();
    // Entfernt den Standardabsatz
    txtFrm.getParagraphs().removeAt(0);
    // Erstellt einen Absatz
    var para = new aspose.slides.Paragraph();
    // Legt den Aufzählungsstil und das Symbol für den Absatz fest
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Setzt den Text des Absatzes
    para.setText("Welcome to Aspose.Slides");
    // Legt den Einzug des Aufzählungszeichens fest
    para.getParagraphFormat().setIndent(25);
    // Legt die Farbe des Aufzählungszeichens fest
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // IsBulletHardColor auf true setzen, um eine eigene Aufzählungsfarbe zu verwenden
    // Legt die Höhe des Aufzählungszeichens fest
    para.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Absatz dem Textrahmen hinzu
    txtFrm.getParagraphs().add(para);
    // Erstellt einen zweiten Absatz
    var para2 = new aspose.slides.Paragraph();
    // Legt den Aufzählungstyp und -stil des Absatzes fest
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Fügt den Absatztext hinzu
    para2.setText("This is numbered bullet");
    // Legt den Einzug des Aufzählungszeichens fest
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // IsBulletHardColor auf true setzen, um eine eigene Aufzählungsfarbe zu verwenden
    // Legt die Höhe des Aufzählungszeichens fest
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Absatz dem Textrahmen hinzu
    txtFrm.getParagraphs().add(para2);
    // Speichert die geänderte Präsentation
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```



## **Bildaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) des Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. Laden Sie das Bild in [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
8. Setzen Sie den Aufzählungstyp auf [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für die Aufzählung fest.
12. Legen Sie eine Höhe für die Aufzählung fest.
13. Fügen Sie den neuen Absatz der Absatz‑Sammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang basierend auf den vorherigen Schritten.
15. Speichern Sie die geänderte Präsentation.

```javascript
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
var presentation = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = presentation.getSlides().get_Item(0);
    // Instanziert das Bild für Aufzählungszeichen
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Fügt eine AutoShape hinzu und greift darauf zu
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf das TextFrame der AutoShape zu
    var textFrame = autoShape.getTextFrame();
    // Entfernt den Standard‑Absatz
    textFrame.getParagraphs().removeAt(0);
    // Erstellt einen neuen Absatz
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Legt den Aufzählungsstil und das Bild des Absatzes fest
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Legt die Höhe des Aufzählungszeichens fest
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Fügt den Absatz dem TextFrame hinzu
    textFrame.getParagraphs().add(paragraph);
    // Schreibt die Präsentation als PPTX‑Datei
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Schreibt die Präsentation als PPT‑Datei
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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie in der neuen Folie ein [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) des Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der Absatz‑Sammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

```javascript
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Fügt eine AutoShape hinzu und greift darauf zu
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf den Textrahmen der erstellten AutoShape zu
    var text = aShp.addTextFrame("");
    // Entfernt den Standardabsatz
    text.getParagraphs().clear();
    // Fügt den ersten Absatz hinzu
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Legt die Aufzählungsebene fest
    para1.getParagraphFormat().setDepth(0);
    // Fügt den zweiten Absatz hinzu
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Legt die Aufzählungsebene fest
    para2.getParagraphFormat().setDepth(1);
    // Fügt den dritten Absatz hinzu
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Legt die Aufzählungsebene fest
    para3.getParagraphFormat().setDepth(2);
    // Fügt den vierten Absatz hinzu
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Legt die Aufzählungsebene fest
    para4.getParagraphFormat().setDepth(3);
    // Fügt Absätze zur Sammlung hinzu
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

Die Klasse [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) stellt die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) und weitere bereit, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) des Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith] auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der Absatz‑Sammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Greift auf den Textrahmen der erstellten AutoShape zu
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


## **Absatzeinzug festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
1. Fügen Sie der Folie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Fügen Sie dem Rechteck‑autoshape ein [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Rechtecklinien aus.
1. Setzen Sie den Einzug für jeden [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) über dessen BulletOffset‑Eigenschaft.
1. Schreiben Sie die geänderte Präsentation als PPT‑Datei.

```javascript
// Instanziert die Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Fügt ein Rechteck-Shape hinzu
    var rect = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 150);
    // Fügt dem Rechteck ein TextFrame hinzu
    var tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    // Setzt den Text, damit er in die Form passt
    tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Versteckt die Linien des Rechtecks
    rect.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    // Holt den ersten Absatz im TextFrame und setzt dessen Einzug
    var para1 = tf.getParagraphs().get_Item(0);
    // Setzt den Aufzählungsstil und das Symbol des Absatzes
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para1.getParagraphFormat().setDepth(2);
    para1.getParagraphFormat().setIndent(30);
    // Holt den zweiten Absatz im TextFrame und setzt dessen Einzug
    var para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar(8226);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para2.getParagraphFormat().setDepth(2);
    para2.getParagraphFormat().setIndent(40);
    // Holt den dritten Absatz im TextFrame und setzt dessen Einzug
    var para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para3.getParagraphFormat().setDepth(2);
    para3.getParagraphFormat().setIndent(50);
    // Speichert die Präsentation auf die Festplatte
    pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Hängenden Einzug für Absatz festlegen**

Dieser Javascript‑Code zeigt, wie Sie den hängenden Einzug für einen Absatz festlegen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 550, 150);
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Example");
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");
    var para3 = new aspose.slides.Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");
    para2.getParagraphFormat().setMarginLeft(10.0);
    para3.getParagraphFormat().setMarginLeft(20.0);
    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **End‑Paragraph‑Run‑Eigenschaften für Absatz verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Rufen Sie die Referenz der Folie, die den Absatz enthält, über deren Position ab.
1. Fügen Sie der Folie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) mit zwei Absätzen hinzu.
1. Setzen Sie `FontHeight` und die Schriftart für die Absätze.
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

Aspose.Slides bietet erweiterte Unterstützung für das Importieren von HTML‑Text in Absätze.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader.
7. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
8. Fügen Sie den im gelesenen TextReader enthaltenen HTML‑Dateiinhalt zur [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/) des TextFrame hinzu.
9. Speichern Sie die geänderte Präsentation.

```javascript
// Erstelle leere Präsentationsinstanz
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    var slide = pres.getSlides().get_Item(0);
    // Fügt die AutoShape hinzu, um den HTML-Inhalt aufzunehmen
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Fügt dem Shape einen TextFrame hinzu
    ashape.addTextFrame("");
    // Löscht alle Absätze im hinzugefügten TextFrame
    ashape.getTextFrame().getParagraphs().clear();
    // Lädt die HTML-Datei mit einem StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Fügt Text aus dem HTML-StreamReader zum TextFrame hinzu
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Speichert die Präsentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Absatztexte nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (in Absätzen enthalten) nach HTML.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Greifen Sie auf die Form zu, die den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Startindex an den StreamWriter weiter und exportieren Sie die gewünschten Absätze.

```javascript
// Lade die Präsentationsdatei
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    var slide = pres.getSlides().get_Item(0);
    // Gewünschter Index
    var index = 0;
    // Zugriff auf die hinzugefügte Form
    var ashape = slide.getShapes().get_Item(index);
    // Erstelle die Ausgabedatei HTML
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extrahiere ersten Absatz als HTML
    // Schreibe Absatzdaten nach HTML, indem der Startindex des Absatzes und die Gesamtzahl der zu kopierenden Absätze angegeben werden
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

In diesem Abschnitt untersuchen wir zwei Beispiele, die zeigen, wie ein Textabsatz, dargestellt durch die Schnittstelle [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/), als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes einer Form, die den Absatz enthält, mithilfe der `getImage`‑Methoden der Schnittstelle [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), die Berechnung der Begrenzungsrechtecke des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren spezifischer Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild der Form aus der ersten Folie der Präsentation und berechnen anschließend die Begrenzungsrechtecke des zweiten Absatzes im Textrahmen der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet, das im PNG‑Format gespeichert wird. Diese Methode ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild speichern möchten, wobei die genauen Abmessungen und die Formatierung des Textes erhalten bleiben.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Speichere die Form im Speicher als Bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Erstelle eine Shape-Bitmap aus dem Speicher.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Berechne die Grenzen des zweiten Absatzes.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Berechne die Koordinaten und Größe für das Ausgabebild (Mindestgröße – 1x1 Pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Beschneide die Shape-Bitmap, um ausschließlich die Absatz-Bitmap zu erhalten.
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

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir dem Absatzbild Skalierungsfaktoren hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch wird beim Export des Absatzes eine höhere Auflösung erzielt. Die Begrenzungsrechtecke des Absatzes werden anschließend unter Berücksichtigung des Skalierungsfaktors berechnet. Skalierung kann besonders nützlich sein, wenn ein detaillierteres Bild benötigt wird, beispielsweise für die Verwendung in hochwertigen Druckmaterialien.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Speichere die Form im Speicher als Bitmap mit Skalierung.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Erstelle ein Shape-Bitmap aus dem Speicher.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Berechne die Grenzen des zweiten Absatzes.
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

    // Beschneide das Shape-Bitmap, um nur die Absatz-Bitmap zu erhalten.
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

**Kann ich das Zeilenumbruch‑Verhalten in einem Textrahmen vollständig deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Einstellung des Textrahmens ([setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)), um den Umbruch auszuschalten, sodass Zeilen nicht an den Rändern des Rahmens umgebrochen werden.

**Wie kann ich die genauen Positionen eines bestimmten Absatzes auf der Folie erhalten?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar eines einzelnen Abschnitts) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatzausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) ist eine Methode für eine Absatz‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/); sie wird auf den gesamten Absatz angewendet, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreibprüfungssprache nur für einen Teil eines Absatzes festlegen (z. B. für ein Wort)?**

Ja. Die Sprache wird auf Portionsebene festgelegt ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes koexistieren können.