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
- Java
- Aspose.Slides
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für Java – optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP-Präsentationen in Java."
---

Aspose.Slides bietet alle Schnittstellen und Klassen, die Sie benötigen, um in Java mit PowerPoint‑Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erzeugt).
* Aspose.Slides stellt die [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `IParagraph`‑Objekt kann eine oder mehrere Portionen enthalten (Sammlung von iPortions‑Objekten).
* Aspose.Slides stellt die [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen. 

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über die zugrunde liegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textrahmen mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein Rechteck‑[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Holen Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) verbundene `ITextFrame`.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) Objekte (zwei Portionen für den Standardabsatz) und fügen Sie jedes `IPortion`‑Objekt der IPortion‑Sammlung des jeweiligen `IParagraph` hinzu.
7. Setzen Sie für jede Portion einen Text.
8. Wenden Sie die gewünschten Formatierungsoptionen auf jede Portion über die vom `IPortion`‑Objekt bereitgestellten Eigenschaften an.
9. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code implementiert die Schritte zum Hinzufügen von Absätzen mit Portionen:
```java
// Instanziieren Sie eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // TextFrame des AutoShape abrufen
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

    // PPTX auf Festplatte speichern
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Absatz‑Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu strukturieren und zu präsentieren. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) des Autoforms zu. 
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mithilfe der [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse.
7. Setzen Sie den Aufzählungs‑`Type` des Absatzes auf `Symbol` und definieren Sie das Aufzählungszeichen.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie den Absatz‑`Indent` für das Aufzählungszeichen.
10. Legen Sie eine Farbe für das Aufzählungszeichen fest.
11. Bestimmen Sie die Höhe des Aufzählungszeichens.
12. Fügen Sie den neuen Absatz der `TextFrame`‑Absatz‑Sammlung hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie Sie ein Absatz‑Aufzählungszeichen hinzufügen:
```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügt ein Autoshape hinzu und greift darauf zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf den Textframe des Autoshapes zu
    ITextFrame txtFrm = aShp.getTextFrame();

    // Entfernt den Standardabsatz
    txtFrm.getParagraphs().removeAt(0);

    // Erstellt einen Absatz
    Paragraph para = new Paragraph();

    // Setzt den Aufzählungsstil und das Symbol für den Absatz
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Setzt den Text des Absatzes
    para.setText("Welcome to Aspose.Slides");

    // Setzt den Einzug des Aufzählungszeichens
    para.getParagraphFormat().setIndent(25);

    // Setzt die Farbe des Aufzählungszeichens
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // setzt IsBulletHardColor auf true, um eigene Aufzählungsfarbe zu verwenden

    // Setzt die Höhe des Aufzählungszeichens
    para.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz dem Textframe hinzu
    txtFrm.getParagraphs().add(para);

    // Erstellt einen zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Setzt den Aufzählungstyp und -stil des Absatzes
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Fügt dem Absatz Text hinzu
    para2.setText("This is numbered bullet");

    // Setzt den Einzug des Aufzählungszeichens
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // setzt IsBulletHardColor auf true, um eigene Aufzählungsfarbe zu verwenden

    // Setzt die Höhe des Aufzählungszeichens
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz dem Textframe hinzu
    txtFrm.getParagraphs().add(para2);
    
    // Speichert die modifizierte Präsentation
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Bild‑Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu strukturieren und zu präsentieren. Bild‑Absätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) des Autoforms zu. 
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mithilfe der [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungs‑Typ auf [Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) und definieren Sie das Bild.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für das Aufzählungszeichen.
11. Legen Sie eine Farbe für das Aufzählungszeichen fest.
12. Bestimmen Sie die Höhe des Aufzählungszeichens.
13. Fügen Sie den neuen Absatz der `TextFrame`‑Absatz‑Sammlung hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie Bild‑Aufzählungszeichen hinzufügen und verwalten:
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
    // Fügt ein Autoshape hinzu und greift darauf zu
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf den Textframe des Autoshapes zu
    ITextFrame textFrame = autoShape.getTextFrame();

    // Entfernt den Standardabsatz
    textFrame.getParagraphs().removeAt(0);

    // Erstellt einen neuen Absatz
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Setzt den Aufzählungsstil und das Bild für den Absatz
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Setzt die Höhe des Aufzählungszeichens
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


## **Mehrstufige Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu strukturieren und zu präsentieren. Mehrstufige Aufzählungszeichen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie in der neuen Folie ein [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) des Autoforms zu. 
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der `TextFrame`‑Absatz‑Sammlung hinzu.
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

    // Greift auf den Textrahmen des erstellten Autoshapes zu
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

    // Fügt Absätze der Sammlung hinzu
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

Die [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) Schnittstelle bietet die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) und weitere, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) des Autoforms zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der `TextFrame`‑Absatz‑Sammlung hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten:
```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf den Textframe des erstellten Autoshapes zu
    ITextFrame textFrame = shape.getTextFrame();

    // Entfernt den vorhandenen Standardabsatz
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


## **Absatz‑Einrückung festlegen**

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
1. Greifen Sie über den Index auf die entsprechende Folie zu.
1. Fügen Sie der Folie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck‑autoshape ein [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) mit drei Absätzen hinzu.
1. Verstecken Sie die Rechteck‑Linien.
1. Setzen Sie die Einrückung für jeden [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) über dessen `BulletOffset`‑Eigenschaft.
1. Schreiben Sie die geänderte Präsentation als PPT‑Datei.

Dieser Java‑Code zeigt, wie Sie eine Absatz‑Einrückung festlegen:
```java
// Instanziiert die Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügt ein Rechteck-Shape hinzu
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Fügt dem Rechteck ein TextFrame hinzu
    ITextFrame tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    
    // Setzt den Text, damit er in das Shape passt
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Versteckt die Linien des Rechtecks
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Holt den ersten Absatz im TextFrame und setzt dessen Einzug
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Setzt den Aufzählungsstil und das Symbol des Absatzes
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Holt den zweiten Absatz im TextFrame und setzt dessen Einzug
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Holt den dritten Absatz im TextFrame und setzt dessen Einzug
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // Schreibt die Präsentation auf die Festplatte
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Hängende Einrückung für Absatz festlegen**

Dieser Java‑Code zeigt, wie Sie die hängende Einrückung für einen Absatz festlegen:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Example");

    Paragraph para2 = new Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");

    Paragraph para3 = new Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");

    para2.getParagraphFormat().setMarginLeft(10f);
    para3.getParagraphFormat().setMarginLeft(20f);

    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **End‑Absatz‑Lauf‑Eigenschaften für Absatz verwalten**

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
1. Holen Sie die Referenz der Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie der Folie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) mit zwei Absätzen hinzu.
1. Setzen Sie `FontHeight` und den Schriftsatz für die Absätze.
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem `TextReader`.
7. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse.
8. Fügen Sie den Inhalt der HTML‑Datei, der im gelesenen `TextReader` steht, zur [ParagraphCollection](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code implementiert die Schritte zum Importieren von HTML‑Texten in Absätze:
```java
// Leere Präsentationsinstanz erstellen
Presentation pres = new Presentation();
try {
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt das AutoShape hinzu, um den HTML-Inhalt aufzunehmen
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Textframe zur Form hinzufügen
    ashape.addTextFrame("");

    // Löscht alle Absätze im hinzugefügten Textframe
    ashape.getTextFrame().getParagraphs().clear();

    // Laden der HTML-Datei mit StreamReader
    TextReader tr = new StreamReader("file.html");

    // Text aus dem HTML-StreamReader im Textframe hinzufügen
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Präsentation speichern
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Absatz‑Text nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (in Absätzen enthalten) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Greifen Sie auf die Form zu, die den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Start‑Index für `StreamWriter` an und exportieren Sie die gewünschten Absätze.

Dieser Java‑Code zeigt, wie Sie PowerPoint‑Absatz‑Texte nach HTML exportieren:
```java
// Lade die Präsentationsdatei
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Gewünschter Index
    int index = 0;

    // Greift auf die hinzugefügte Form zu
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Erstelle die Ausgabedatei HTML
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extrahiere ersten Absatz als HTML
    // Schreibe Absatzdaten nach HTML, indem der Startindex des Absatzes und die Gesamtzahl der zu kopierenden Absätze angegeben werden
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Absatz als Bild speichern**

In diesem Abschnitt betrachten wir zwei Beispiele, die zeigen, wie ein Textabsatz, dargestellt durch die [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) Schnittstelle, als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes einer Form, die den Absatz enthält, über die `getImage`‑Methoden der [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) Schnittstelle, das Berechnen der Grenzen des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren bestimmter Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens **sample.pptx** mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild der Form aus der ersten Folie der Präsentation und berechnen anschließend die Grenzen des zweiten Absatzes im TextFrame der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet und im PNG‑Format gespeichert. Dieses Verfahren ist besonders nützlich, wenn ein bestimmter Absatz als separates Bild gespeichert werden soll, wobei die genauen Abmessungen und das Format erhalten bleiben.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Speichert die Form im Speicher als Bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Erstellt ein Form-Bitmap aus dem Speicher.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Berechnet die Grenzen des zweiten Absatzes.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Berechnet die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Schneidet das Form-Bitmap zu, um nur das Absatz-Bitmap zu erhalten.
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

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatz‑Bild hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein Bild mit höherer Auflösung. Die Absatz‑Grenzen werden anschließend unter Berücksichtigung des Skalierungsfaktors berechnet. Skalierung ist besonders hilfreich, wenn ein detaillierteres Bild für beispielsweise hochwertige Druckmaterialien benötigt wird.
```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Speichert die Form im Speicher als Bitmap mit Skalierung.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Erstellt ein Form-Bitmap aus dem Speicher.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Berechnet die Grenzen des zweiten Absatzes.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Berechnet die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Schneidet das Form-Bitmap zu, um nur das Absatz-Bitmap zu erhalten.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Kann ich das Zeilenumbruch‑Verhalten innerhalb eines Textframes vollständig deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Einstellung des Textframes ([setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-)), um den Umbruch abzuschalten, sodass Zeilen nicht an den Rändern des Frames umbrechen.

**Wie erhalte ich die exakten Folien‑Grenzen eines bestimmten Absatzes?**

Sie können das Begrenzungs‑Rechteck des Absatzes (und sogar eines einzelnen Portions) abrufen, um dessen genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setAlignment-int-) ist eine Absatz‑Ebene‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/); sie wird auf den gesamten Absatz angewendet, unabhängig von der Formatierung einzelner Portionen.

**Kann ich für einen Teil eines Absatzes (z. B. ein Wort) eine Rechtschreib‑Sprache festlegen?**

Ja. Die Sprache wird auf Portion‑Ebene festgelegt ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes coexistieren können.