---
title: PowerPoint-Textabsätze auf Android verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/androidjava/manage-paragraph/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählung verwalten
- Absatzeinzug
- hängender Einzug
- Absatzaufzählung
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
- Android
- Java
- Aspose.Slides
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für Android – optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP-Präsentationen in Java."
---

Aspose.Slides stellt alle Schnittstellen und Klassen bereit, die Sie benötigen, um mit PowerPoint‑Texten, -Absätzen und -Portionen in Java zu arbeiten.

* Aspose.Slides stellt die Schnittstelle [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) zur Verfügung, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides stellt die Schnittstelle [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) bereit, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `IParagraph`‑Objekt kann eine oder mehrere Portionen enthalten (eine Sammlung von iPortions‑Objekten).
* Aspose.Slides stellt die Schnittstelle [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) bereit, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Textportionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textframe hinzufügen, der 3 Absätze enthält, und jeder Absatz enthält 3 Portionen:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie der Folie ein Rechteck‑[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Rufen Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) verknüpfte ITextFrame ab.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/)-Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/)-Objekte (zwei Portion‑Objekte für den Standardabsatz) und fügen Sie jedes `IPortion`‑Objekt der IPortion‑Sammlung jedes `IParagraph` hinzu.
7. Legen Sie für jede Portion einen Text fest.
8. Wenden Sie die gewünschten Formatierungsfunktionen auf jede Portion an, indem Sie die vom `IPortion`‑Objekt bereitgestellten Formatierungseigenschaften nutzen.
9. Speichern Sie die geänderte Präsentation.

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Rechteck hinzufügen
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


## **Absatzaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Aufgelistete Absätze sind immer leichter zu lesen und zu verstehen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie dem ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) des Autoshapes zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Setzen Sie den Aufzählungs‑`Type` des Absatzes auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
10. Legen Sie eine Farbe für die Aufzählung fest.
11. Stellen Sie die Höhe der Aufzählung ein.
12. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügt ein Autoshape hinzu und greift darauf zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame des Autoshapes zu
    ITextFrame txtFrm = aShp.getTextFrame();

    // Entfernt den Standardabsatz
    txtFrm.getParagraphs().removeAt(0);

    // Erstellt einen Absatz
    Paragraph para = new Paragraph();

    // Legt den Aufzählungsstil und das Symbol des Absatzes fest
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Setzt den Absatztext
    para.setText("Welcome to Aspose.Slides");

    // Legt den Aufzählungseinzug fest
    para.getParagraphFormat().setIndent(25);

    // Legt die Aufzählungsfarbe fest
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // setzt IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden

    // Legt die Aufzählungshöhe fest
    para.getParagraphFormat().getBullet().setHeight(100);

    // Fügt dem TextFrame einen Absatz hinzu
    txtFrm.getParagraphs().add(para);

    // Erstellt einen zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Legt den Aufzählungstyp und -stil des Absatzes fest
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Fügt den Absatztext hinzu
    para2.setText("This is numbered bullet");

    // Legt den Aufzählungseinzug fest
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // setzt IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden

    // Legt die Aufzählungshöhe fest
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Fügt dem TextFrame einen Absatz hinzu
    txtFrm.getParagraphs().add(para2);
    
    // Speichert die geänderte Präsentation
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **Bildaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) des Autoshapes zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungstyp auf [Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für die Aufzählung fest.
12. Stellen Sie die Höhe der Aufzählung ein.
13. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang anhand der vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

```java
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
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

    // Entfernt den Standardabsatz
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


## **Mehrstufige Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie der neuen Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) des Autoshapes zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mittels der Klasse [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz mittels der Klasse `Paragraph` und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz mittels der Klasse `Paragraph` und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz mittels der Klasse `Paragraph` und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

```java
    // Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
    Presentation pres = new Presentation();
    try {
        // Greift auf die erste Folie zu
        ISlide slide = pres.getSlides().get_Item(0);

        // Fügt ein Autoshape hinzu und greift darauf zu
        IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

        // Greift auf den Textframe des erstellten Autoshapes zu
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


## **Einen Absatz mit einer benutzerdefinierten nummerierten Liste verwalten**

Die Schnittstelle [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) stellt die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) und weitere bereit, die Ihnen ermöglichen, Absätze mit benutzerdefinierter Nummerierung oder Formatierung zu verwalten.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) des Autoshapes zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mittels der Klasse [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatzinstanz mittels der Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz mittels der Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

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


## **Absatzeinzug festlegen**

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
1. Fügen Sie der Folie ein rechteckiges [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem rechteckigen Autoshape ein [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Rechtecklinien aus.
1. Setzen Sie den Einzug für jeden [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) über dessen BulletOffset‑Eigenschaft.
1. Schreiben Sie die geänderte Präsentation als PPT-Datei.

```java
// Präsentationsklasse instanziieren
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Rechteckform hinzufügen
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // TextFrame zum Rechteck hinzufügen
    ITextFrame tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    
    // Text so einstellen, dass er in die Form passt
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Linien des Rechtecks ausblenden
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Ersten Absatz im TextFrame abrufen und dessen Einzug setzen
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Absatz-Aufzählungsstil und Symbol setzen
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Zweiten Absatz im TextFrame abrufen und dessen Einzug setzen
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Dritten Absatz im TextFrame abrufen und dessen Einzug setzen
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    //Präsentation auf Festplatte schreiben
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Hängenden Einzug für einen Absatz festlegen**

Dieser Java‑Code zeigt, wie Sie den hängenden Einzug für einen Absatz festlegen:

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


## **End‑Absatzlauf‑Eigenschaften verwalten**

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Holen Sie die Referenz der Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie der Folie ein rechteckiges [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) mit zwei Absätzen hinzu.
1. Setzen Sie die `FontHeight` und den Schriftschnitt für die Absätze.
1. Setzen Sie die End‑Eigenschaften für die Absätze.
1. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

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

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader ein.
7. Erstellen Sie die erste Absatzinstanz mittels der Klasse [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
8. Fügen Sie den HTML‑Dateiinhalt aus dem gelesenen TextReader zur [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

```java
// Leere Präsentationsinstanz erstellen
Presentation pres = new Presentation();
try {
    // Zugriff auf die standardmäßige erste Folie der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen des AutoShape, um den HTML-Inhalt aufzunehmen
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Textframe zum Shape hinzufügen
    ashape.addTextFrame("");

    // Alle Absätze im hinzugefügten Textframe löschen
    ashape.getTextFrame().getParagraphs().clear();

    // HTML-Datei mit StreamReader laden
    TextReader tr = new StreamReader("file.html");

    // Text aus dem HTML-StreamReader in den Textframe einfügen
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Präsentation speichern
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Absatztext nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (in Absätzen enthalten) nach HTML.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Greifen Sie auf das Shape zu, das den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) des Shapes zu.
5. Erzeugen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Startindex an den StreamWriter an und exportieren Sie die gewünschten Absätze.

```java
// Präsentationsdatei laden
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Gewünschter Index
    int index = 0;

    // Zugriff auf das hinzugefügte Shape
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Erstelle Ausgabedatei HTML
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extrahiere ersten Absatz als HTML
    // Schreibe Absatzdaten nach HTML, indem Startindex und Gesamtanzahl der zu kopierenden Absätze angegeben werden
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Einen Absatz als Bild speichern**

In diesem Abschnitt untersuchen wir zwei Beispiele, die zeigen, wie ein Textabschnitt, dargestellt durch die [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/)‑Schnittstelle, als Bild gespeichert werden kann. Beide Beispiele umfassen das Erhalten des Bildes eines Shapes, das den Absatz enthält, mittels der `getImage`‑Methoden der [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Schnittstelle, das Berechnen der Begrenzungen des Absatzes innerhalb des Shapes und das Exportieren als Bitmap‑Bild. Diese Vorgehensweisen ermöglichen das Extrahieren bestimmter Textabschnitte aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei das erste Shape ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild des Shapes aus der ersten Folie der Präsentation und berechnen anschließend die Begrenzungen des zweiten Absatzes im Textframe des Shapes. Der Absatz wird dann auf ein neues Bitmap‑Bild neu gezeichnet, das im PNG‑Format gespeichert wird. Diese Methode ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild speichern möchten, dabei jedoch die genauen Abmessungen und die Formatierung des Textes beibehalten wollen.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Form im Speicher als Bitmap speichern.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Shape-Bitmap aus dem Speicher erstellen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Grenzen des zweiten Absatzes berechnen.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße - 1x1 Pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Shape-Bitmap beschneiden, um ausschließlich das Absatz-Bitmap zu erhalten.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


Das Ergebnis:

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatzbild hinzufügen. Das Shape wird aus der Präsentation extrahiert und als Bild mit einem Skalierungsfaktor von `2` gespeichert. Dadurch entsteht ein Ausgabe‑Bild mit höherer Auflösung beim Export des Absatzes. Die Absatzbegrenzungen werden anschließend unter Berücksichtigung des Skalierungsfaktors berechnet. Skalierung ist besonders nützlich, wenn ein detaillierteres Bild benötigt wird, beispielsweise für die Verwendung in hochwertigen Druckmaterialien.

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

    // Shape-Bitmap aus dem Speicher erstellen.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Grenzen des zweiten Absatzes berechnen.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße – 1x1 Pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Shape-Bitmap zuschneiden, um ausschließlich das Absatz-Bitmap zu erhalten.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Kann ich den Zeilenumbruch innerhalb eines Textframes vollständig deaktivieren?**

Ja. Verwenden Sie die Zeilenumbruch‑Einstellung des Textframes ([setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)), um den Umbruch zu deaktivieren, sodass Zeilen nicht an den Rahmenrändern umgebrochen werden.

**Wie kann ich die genauen Grenzen eines bestimmten Absatzes auf der Folie erhalten?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar eines einzelnen Abschnitts) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatzausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) ist eine Absatz‑Ebene‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreibprüfungssprache nur für einen Teil eines Absatzes festlegen (z. B. ein Wort)?**

Ja. Die Sprache wird auf Portionsebene festgelegt ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes coexistieren können.