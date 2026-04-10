---
title: PowerPoint-Textabsätze in Java verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/java/manage-paragraph/
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
- Absatz‑Eigenschaften
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
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für Java — optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP‑Präsentationen in Java."
---
Aspose.Slides stellt alle Schnittstellen und Klassen bereit, die Sie benötigen, um in Java mit PowerPoint-Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `ITextFame`-Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erzeugt).
* Aspose.Slides stellt die [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `IParagraph`-Objekt kann eine oder mehrere Portionen (eine Sammlung von iPortions-Objekten) enthalten.
* Aspose.Slides stellt die [IPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen. 

Ein `IParagraph`-Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`-Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textrahmen mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Rufen Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) verbundene ITextFrame ab.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/) Objekte und fügen Sie sie der `IParagraphs`-Sammlung des [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/) Objekte (zwei Portion-Objekte für den Standard‑Absatz) und fügen Sie jedes `IPortion`-Objekt der IPortion‑Sammlung jedes `IParagraph` hinzu.
7. Legen Sie für jede Portion einen Text fest.
8. Wenden Sie mit den vom `IPortion`‑Objekt bereitgestellten Formatierungseigenschaften Ihre gewünschten Formatierungsoptionen auf jede Portion an.
9. Speichern Sie die geänderte Präsentation.

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen einer AutoShape vom Typ Rechteck
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Zugriff auf das TextFrame der AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Erstellen von Absätzen und Portionen mit unterschiedlichen Textformaten
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

## **Absatz‑Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/) Klasse.
7. Setzen Sie den Aufzählungs‑`Type` des Absatzes auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie den Absatz‑`Indent` für das Aufzählungszeichen.
10. Legen Sie eine Farbe für das Aufzählungszeichen fest.
11. Legen Sie eine Höhe für das Aufzählungszeichen fest.
12. Fügen Sie den neuen Absatz zur `TextFrame`‑Absatzsammlung hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7‑12.
14. Speichern Sie die Präsentation.

```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügt eine AutoShape hinzu und greift darauf zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame der AutoShape zu
    ITextFrame txtFrm = aShp.getTextFrame();

    // Entfernt den Standardabsatz
    txtFrm.getParagraphs().removeAt(0);

    // Erstellt einen Absatz
    Paragraph para = new Paragraph();

    // Legt den Aufzählungsstil und das Symbol für den Absatz fest
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Setzt den Text des Absatzes
    para.setText("Welcome to Aspose.Slides");

    // Legt den Aufzählungs‑Einzug fest
    para.getParagraphFormat().setIndent(25);

    // Legt die Aufzählungsfarbe fest
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor auf true setzen, um eigene Aufzählungsfarbe zu verwenden

    // Legt die Aufzählungshöhe fest
    para.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz dem TextFrame hinzu
    txtFrm.getParagraphs().add(para);

    // Erstellt einen zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Legt den Aufzählungstyp und -stil des Absatzes fest
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Fügt den Absatztext hinzu
    para2.setText("This is numbered bullet");

    // Legt den Aufzählungs‑Einzug fest
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor auf true setzen, um eigene Aufzählungsfarbe zu verwenden

    // Legt die Aufzählungshöhe fest
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz dem TextFrame hinzu
    txtFrm.getParagraphs().add(para2);
    
    // Speichert die geänderte Präsentation
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bild‑Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Bild‑Absätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/) Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungs‑Typ auf [Picture](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für das Aufzählungszeichen.
11. Legen Sie eine Farbe für das Aufzählungszeichen fest.
12. Legen Sie eine Höhe für das Aufzählungszeichen fest.
13. Fügen Sie den neuen Absatz zur `TextFrame`‑Absatzsammlung hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation presentation = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instanziert das Bild für Aufzählungszeichen
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Fügt eine AutoShape hinzu und greift darauf zu
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das Textframe der AutoShape zu
    ITextFrame textFrame = autoShape.getTextFrame();

    // Entfernt den Standardabsatz
    textFrame.getParagraphs().removeAt(0);

    // Erstellt einen neuen Absatz
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Legt den Aufzählungsstil und das Bild des Absatzes fest
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Legt die Aufzählungshöhe fest
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz dem Textframe hinzu
    textFrame.getParagraphs().add(paragraph);

    // Schreibt die Präsentation als PPTX-Datei
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Schreibt die Präsentation als PPT-Datei
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Mehrstufige Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie in der neuen Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/) Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur `TextFrame`‑Absatzsammlung hinzu.
11. Speichern Sie die geänderte Präsentation.

```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt eine AutoShape hinzu und greift darauf zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das Textframe der erstellten AutoShape zu
    ITextFrame text = aShp.addTextFrame("");

    // Löscht den Standardabsatz
    text.getParagraphs().clear();

    // Fügt den ersten Absatz hinzu
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Legt die Aufzählungsebene fest
    para1.getParagraphFormat().setDepth((short)0);

    // Fügt den zweiten Absatz hinzu
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Legt die Aufzählungsebene fest
    para2.getParagraphFormat().setDepth((short)1);

    // Fügt den dritten Absatz hinzu
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Legt die Aufzählungsebene fest
    para3.getParagraphFormat().setDepth((short)2);

    // Fügt den vierten Absatz hinzu
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Legt die Aufzählungsebene fest
    para4.getParagraphFormat().setDepth((short)3);

    // Fügt die Absätze zur Sammlung hinzu
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Schreibt die Präsentation als PPTX-Datei
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Absatz mit benutzerdefinierter nummerierter Liste verwalten**

Die [IBulletFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/) Schnittstelle bietet die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) und weitere, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) des Autoshapes zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/) Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur `TextFrame`‑Absatzsammlung hinzu.
10. Speichern Sie die geänderte Präsentation.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das Textframe der erstellten AutoShape zu
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

Verwenden Sie die Methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-), um den ersten Zeileneinzug eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-), wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-), wenn Sie nur die erste Zeile verschieben wollen.

Das nachstehende Beispiel erstellt mehrere Absätze und wendet unterschiedliche Einzugswerte an, um zu demonstrieren, wie sich der erste Zeileneinzug auf das Layout auswirkt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Zieldolie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie mehrere Absätze und setzen Sie unterschiedliche [Indent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-) Werte für sie.
6. Fügen Sie die Absätze zum Textrahmen hinzu.
7. Speichern Sie die geänderte Präsentation.

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

![The first-line indent of the paragraphs](first_line_indent.png)

## **Hängenden Einzug für einen Absatz festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Setzen Sie den Einzug auf einen negativen Wert, um die erste Zeile relativ zum Absatzkörper nach links zu verschieben.

In der Praxis definiert [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) die linke Position des Absatzkörpers, und [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-) definiert die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, setzen Sie einen positiven `MarginLeft`-Wert und einen negativen `Indent`-Wert.

Diese Formatierung ist nützlich für Bibliografien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Zieldolie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie Absätze und setzen Sie für jeden Absatz einen positiven [MarginLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) Wert.
6. Setzen Sie einen negativen [Indent](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setIndent-float-) Wert, um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze zum Textrahmen hinzu.
8. Speichern Sie die geänderte Präsentation.

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

![The hanging indent of the paragraphs](hanging_indent.png)

## **End‑Absatz‑Run‑Eigenschaften verwalten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Holen Sie die Referenz für die Folie, die den Absatz enthält, über deren Position.
3. Fügen Sie der Folie ein rechteckiges [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) mit zwei Absätzen hinzu.
5. Setzen Sie die `FontHeight` und den Schrifttyp für die Absätze.
6. Setzen Sie die End‑Eigenschaften für die Absätze.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standard‑Absatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader.
7. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/) Klasse.
8. Fügen Sie den HTML‑Dateiinhalte aus dem gelesenen TextReader zur [ParagraphCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

```java
    // Leere Präsentationsinstanz erstellen
    Presentation pres = new Presentation();
    try {
        // Auf die standardmäßige erste Folie der Präsentation zugreifen
        ISlide slide = pres.getSlides().get_Item(0);

        // AutoShape hinzufügen, um den HTML-Inhalt unterzubringen
        IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
                (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

        ashape.getFillFormat().setFillType(FillType.NoFill);

        // Textframe zum Shape hinzufügen
        ashape.addTextFrame("");

        // Alle Absätze im hinzugefügten Textframe löschen
        ashape.getTextFrame().getParagraphs().clear();

        // HTML-Datei mit StreamReader laden
        TextReader tr = new StreamReader("file.html");

        // Text aus dem HTML-StreamReader in den Textframe hinzufügen
        ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

        // Präsentation speichern
        pres.save("output_out.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **Absatz‑Text nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (in Absätzen enthalten) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Greifen Sie auf das Shape zu, das den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) des Shapes zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Startindex an den StreamWriter weiter und exportieren Sie Ihre gewünschten Absätze.

```java
// Laden der Präsentationsdatei
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Auf die standardmäßige erste Folie der Präsentation zugreifen
    ISlide slide = pres.getSlides().get_Item(0);

    // Gewünschter Index
    int index = 0;

    // Zugriff auf das hinzugefügte Shape
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Ausgabedatei HTML erstellen
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Erster Absatz als HTML extrahieren
    // Schreiben von Absatzdaten in HTML, indem Startindex des Absatzes und Gesamtzahl der zu kopierenden Absätze angegeben werden
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Absatz als Bild speichern**

In diesem Abschnitt untersuchen wir zwei Beispiele, die zeigen, wie ein Textabsatz, dargestellt durch die [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/) Schnittstelle, als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes eines Shapes, das den Absatz enthält, über die `getImage`‑Methoden der [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/) Schnittstelle, das Berechnen der Grenzen des Absatzes innerhalb des Shapes und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren spezifischer Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Nehmen wir an, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei das erste Shape ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild des Shapes von der ersten Folie der Präsentation und berechnen anschließend die Grenzen des zweiten Absatzes im TextFrame des Shapes. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet und im PNG‑Format gespeichert. Diese Methode ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild sichern möchten, während die genauen Abmessungen und die Formatierung des Textes erhalten bleiben.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Form in Speicher als Bitmap speichern.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Bitmap des Shapes aus dem Speicher erstellen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Grenzen des zweiten Absatzes berechnen.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße – 1x1 Pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Das Shape‑Bitmap zuschneiden, um nur das Absatz‑Bitmap zu erhalten.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Das Ergebnis:

![The paragraph image](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatz‑Bild hinzufügen. Das Shape wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein Bild mit höherer Auflösung beim Export des Absatzes. Die Absatzgrenzen werden anschließend unter Berücksichtigung des Maßstabs berechnet. Skalierung ist besonders hilfreich, wenn ein detaillierteres Bild benötigt wird, z. B. für den Einsatz in hochwertigem Druckmaterial.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Shape im Speicher als Bitmap mit Skalierung speichern.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Bitmap des Shapes aus dem Speicher erstellen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Grenzen des zweiten Absatzes berechnen.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße – 1x1 Pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Das Shape‑Bitmap zuschneiden, um nur das Absatz‑Bitmap zu erhalten.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Kann ich das Zeilenumbruch‑Verhalten in einem TextFrame vollständig deaktivieren?**

Ja. Verwenden Sie die Einstellung für das Zeilenumbruch‑Verhalten des TextFrames ([setWrapText](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframeformat/#setWrapText-byte-)), um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des Frames umbrochen werden.

**Wie erhalte ich die genauen Folien‑Grenzen eines bestimmten Absatzes?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar eines einzelnen Abschnitts) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraphformat/#setAlignment-int-) ist eine Einstellung auf Absatzebene in [ParagraphFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der einzelnen Portion‑Formatierung.

**Kann ich eine Rechtschreib‑Sprache nur für einen Teil eines Absatzes (z. B. ein Wort) festlegen?**

Ja. Die Sprache wird auf Portionsebene festgelegt ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes coexistieren können.