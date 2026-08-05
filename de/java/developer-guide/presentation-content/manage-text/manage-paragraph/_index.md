---
title: PowerPoint-Textabsätze in Java verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatz‑Einzug
- Hängender Einzug
- Absatz‑Aufzählungszeichen
- Nummerierte Liste
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
- Java
- Aspose.Slides
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für Java – optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP‑Präsentationen in Java."
---
## **Einleitung**

Aspose.Slides stellt alle Schnittstellen und Klassen bereit, die Sie benötigen, um in Java mit PowerPoint‑Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides bietet die [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/)‑Schnittstelle, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides bietet die [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/)‑Schnittstelle, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `IParagraph`‑Objekt kann eine oder mehrere Portionen enthalten (Sammlung von iPortions‑Objekten).
* Aspose.Slides bietet die [IPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/)‑Schnittstelle, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen. 

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrundeliegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textrahmen mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Holen Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) verknüpfte ITextFrame.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/)‑Objekte und fügen Sie sie zur `IParagraphs`‑Sammlung des [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/)‑Objekte (zwei Portion‑Objekte für den Standard‑Absatz) und fügen Sie jedes `IPortion`‑Objekt zur IPortion‑Sammlung des jeweiligen `IParagraph` hinzu.
7. Setzen Sie für jede Portion einen Text.
8. Wenden Sie die gewünschten Formatierungsfunktionen auf jede Portion mithilfe der vom `IPortion`‑Objekt bereitgestellten Formatierungseigenschaften an.
9. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code implementiert die Schritte zum Hinzufügen von Absätzen mit Portionen:

```java
// Instanziieren Sie eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Zugriff auf das TextFrame des AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Absätze und Portionen mit unterschiedlichen Textformaten erstellen
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // PPTX auf Festplatte schreiben
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Absatz‑Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufzählungs‑Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mithilfe der [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/)‑Klasse.
7. Setzen Sie den Aufzählungs‑`Type` des Absatzes auf `Symbol` und definieren Sie das Aufzählungszeichen.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie die Absatz‑`Indent` für das Aufzählungszeichen.
10. Definieren Sie eine Farbe für das Aufzählungszeichen.
11. Legen Sie eine Höhe für das Aufzählungszeichen fest.
12. Fügen Sie den neuen Absatz zur `TextFrame`‑Absatzsammlung hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie Sie ein Aufzählungszeichen zu einem Absatz hinzufügen:

```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügt ein Autoshape hinzu und greift darauf zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame des Autoshapes zu
    ITextFrame txtFrm = aShp.getTextFrame();

    // Entfernt den Standard‑Absatz
    txtFrm.getParagraphs().removeAt(0);

    // Erstellt einen Absatz
    Paragraph para = new Paragraph();

    // Setzt den Aufzählungsstil und das Symbol des Absatzes
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Setzt den Absatztext
    para.setText("Welcome to Aspose.Slides");

    // Setzt den Aufzählungseinzug
    para.getParagraphFormat().setIndent(25);

    // Setzt die Aufzählungsfarbe
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // Setzt IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden

    // Setzt die Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz dem Textframe hinzu
    txtFrm.getParagraphs().add(para);

    // Erstellt den zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Setzt den Aufzählungstyp und Stil des Absatzes
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Fügt den Absatztext hinzu
    para2.setText("This is numbered bullet");

    // Setzt den Aufzählungseinzug
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // Setzt IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden

    // Setzt die Aufzählungshöhe
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz dem Textframe hinzu
    txtFrm.getParagraphs().add(para2);
    
    // Speichert die geänderte Präsentation
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bild‑Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bild‑Absätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mithilfe der [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/)‑Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungstyp auf [Picture](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) und weisen Sie das Bild zu.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie die Absatz‑`Indent` für das Aufzählungszeichen.
11. Definieren Sie eine Farbe für das Aufzählungszeichen.
12. Legen Sie eine Höhe für das Aufzählungszeichen fest.
13. Fügen Sie den neuen Absatz zur `TextFrame`‑Absatzsammlung hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess gemäß den vorherigen Schritten.
15. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie Bild‑Aufzählungszeichen hinzufügen und verwalten:

```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation presentation = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instanziiert das Bild für Aufzählungszeichen
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Fügt ein Autoshape hinzu und greift darauf zu
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das Textframe des Autoshapes zu
    ITextFrame textFrame = autoShape.getTextFrame();

    // Entfernt den Standard‑Absatz
    textFrame.getParagraphs().removeAt(0);

    // Erstellt einen neuen Absatz
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Setzt den Aufzählungsstil und das Bild des Absatzes
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Setzt die Aufzählungshöhe
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz dem Textframe hinzu
    textFrame.getParagraphs().add(paragraph);

    // Speichert die Präsentation als PPTX-Datei
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Speichert die Präsentation als PPT-Datei
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Mehrstufige Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungszeichen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie in der neuen Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/)‑Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur `TextFrame`‑Absatzsammlung hinzu.
11. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie mehrstufige Aufzählungszeichen hinzufügen und verwalten:

```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt ein Autoshape hinzu und greift darauf zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das Textframe des erstellten Autoshapes zu
    ITextFrame text = aShp.addTextFrame("");

    // Löscht den Standard‑Absatz
    text.getParagraphs().clear();

    // Fügt den ersten Absatz hinzu
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Setzt die Aufzählungsebene
    para1.getParagraphFormat().setDepth((short)0);

    // Fügt den zweiten Absatz hinzu
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Setzt die Aufzählungsebene
    para2.getParagraphFormat().setDepth((short)1);

    // Fügt den dritten Absatz hinzu
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Setzt die Aufzählungsebene
    para3.getParagraphFormat().setDepth((short)2);

    // Fügt den vierten Absatz hinzu
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Setzt die Aufzählungsebene
    para4.getParagraphFormat().setDepth((short)3);

    // Fügt die Absätze zur Sammlung hinzu
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Speichert die Präsentation als PPTX-Datei
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Absatz mit benutzerdefinierter nummerierter Liste verwalten**

Die [IBulletFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/)‑Schnittstelle stellt die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) und weitere bereit, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) des Autoshapes zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/)‑Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur `TextFrame`‑Absatzsammlung hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das Textframe des erstellten Autoshapes zu
    ITextFrame textFrame = shape.getTextFrame();

    // Entfernt den standardmäßig vorhandenen Absatz
    textFrame.getParagraphs().removeAt(0);

    // Erste Liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Erste‑Zeilen‑Einzug für einen Absatz festlegen**

Verwenden Sie die Methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-), um den Erstzeileneinzug eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-), wenn Sie den gesamten Absatz verschieben möchten. Verwenden Sie [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-), wenn Sie nur die erste Zeile verschieben wollen.

Das folgende Beispiel erstellt mehrere Absätze und wendet unterschiedliche Einzugswerte an, um zu demonstrieren, wie sich der Erstzeileneinzug auf das Layout auswirkt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie mehrere Absätze und setzen Sie für jeden unterschiedliche [Indent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑Werte.
6. Fügen Sie die Absätze dem TextFrame hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie Sie einen Absatz‑Einzug festlegen:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Erstzeileneinzug der Absätze](first_line_indent.png)

## **Hängenden Einzug für einen Absatz festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Setzen Sie den Einzug auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) die linke Position des Absatzkörpers, und [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-) bestimmt die Position der ersten Zeile relativ zu diesem Rand. Für einen hängenden Einzug setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Diese Formatierung ist nützlich für Literaturverzeichnisse, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie Absätze und setzen Sie für jeden einen positiven [MarginLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)‑Wert.
6. Setzen Sie einen negativen [Indent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑Wert, um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem TextFrame hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie Sie einen hängenden Einzug für einen Absatz festlegen:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der hängende Einzug der Absätze](hanging_indent.png)

## **End‑Absatz‑Lauf‑Eigenschaften verwalten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie die Referenz zur Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie der Folie ein rechteckiges [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) mit zwei Absätzen hinzu.
1. Setzen Sie `FontHeight` und den Schrifttyp für die Absätze.
1. Setzen Sie die End‑Eigenschaften für die Absätze.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie die End‑Eigenschaften für Absätze in PowerPoint festlegen: 

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **HTML‑Text in Absätze importieren**

Aspose.Slides bietet erweiterte Unterstützung für das Importieren von HTML‑Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standard‑Absatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader ein.
7. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/)‑Klasse.
8. Fügen Sie den HTML‑Dateiinhalt aus dem gelesenen TextReader zur [ParagraphCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code implementiert die Schritte zum Importieren von HTML‑Texten in Absätze:

```java
// Leere Präsentationsinstanz erstellen
Presentation pres = new Presentation();
try {
    // Auf die standardmäßige erste Folie der Präsentation zugreifen
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape hinzufügen, um den HTML-Inhalt aufzunehmen
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Textframe zum Shape hinzufügen
    ashape.addTextFrame("");

    // Alle Absätze im hinzugefügten Textframe leeren
    ashape.getTextFrame().getParagraphs().clear();

    // HTML-Datei mit StreamReader laden
    TextReader tr = new StreamReader("file.html");

    // Text aus dem HTML-StreamReader in das Textframe hinzufügen
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Präsentation speichern
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Absatz‑Text nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (in Absätzen enthalten) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Greifen Sie auf das Shape zu, das den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) des Shapes zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und legen Sie die neue HTML‑Datei an.
6. Geben Sie einen Start‑Index an den StreamWriter weiter und exportieren Sie Ihre gewünschten Absätze.

Dieser Java‑Code zeigt, wie Sie PowerPoint‑Absatz‑Texte nach HTML exportieren:

```java
// Präsentationsdatei laden
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Auf die standardmäßige erste Folie der Präsentation zugreifen
    ISlide slide = pres.getSlides().get_Item(0);

    // Gewünschter Index
    int index = 0;

    // Auf das hinzugefügte Shape zugreifen
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Ausgabedatei HTML erstellen
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Ersten Absatz als HTML extrahieren
    // Schreiben von Absatzdaten nach HTML durch Angabe des Startindexes des Absatzes und der Anzahl zu kopierender Absätze
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Absatz als Bild speichern**

In diesem Abschnitt betrachten wir zwei Beispiele, die zeigen, wie ein Text‑Absatz, dargestellt durch die [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/)‑Schnittstelle, als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes eines Shapes, das den Absatz enthält, mithilfe der `getImage`‑Methoden der [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/)‑Schnittstelle, das Berechnen der Begrenzungs‑Rectangle des Absatzes innerhalb des Shapes und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren spezifischer Textteile aus PowerPoint‑Präsentationen und das Speichern als einzelne Bilder, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei das erste Shape ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild des Shapes aus der ersten Folie der Präsentation und berechnen anschließend die Begrenzungs‑Rectangle des zweiten Absatzes im TextFrame des Shapes. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet und im PNG‑Format gespeichert. Diese Methode ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild speichern möchten, während Sie die genauen Abmessungen und die Formatierung des Textes beibehalten.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Das Shape im Speicher als Bitmap speichern.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Ein Shape-Bitmap aus dem Speicher erstellen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Die Grenzen des zweiten Absatzes berechnen.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße - 1x1 Pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Das Shape-Bitmap zuschneiden, um nur das Absatz-Bitmap zu erhalten.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Das Ergebnis:

![Der Absatz‑Bild](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatz‑Bild hinzufügen. Das Shape wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein hochauflösendes Ergebnis beim Export des Absatzes. Anschließend werden die Absatz‑Begrenzungen unter Berücksichtigung des Skalierungsfaktors berechnet. Skalierung ist besonders nützlich, wenn ein detailreicheres Bild benötigt wird, etwa für hochwertige Druckmaterialien.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Das Shape im Speicher als Bitmap mit Skalierung speichern.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Ein Shape-Bitmap aus dem Speicher erstellen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Die Grenzen des zweiten Absatzes berechnen.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Die Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße - 1x1 Pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Das Shape-Bitmap zuschneiden, um nur das Absatz-Bitmap zu erhalten.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Kann ich das Zeilen‑Umbruchverhalten in einem TextFrame komplett deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Einstellung des TextFrames ([setWrapText](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframeformat/#setWrapText-byte-)), um das Umbruch‑Verhalten auszuschalten, sodass Zeilen nicht am Rand des Frames umgebrochen werden.

**Wie erhalte ich die genauen Positionen eines bestimmten Absatzes auf der Folie?**

Sie können das Begrenzungs‑Rechteck des Absatzes (oder sogar einer einzelnen Portion) abrufen, um seine exakte Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraphformat/#setAlignment-int-) ist eine Absatz‑Ebene‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von einzelnen Portion‑Formaten.

**Kann ich für nur einen Teil eines Absatzes (z. B. ein Wort) eine Rechtschreib‑Sprache festlegen?**

Ja. Die Sprache wird auf Portion‑Ebene gesetzt ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes coexistieren können.