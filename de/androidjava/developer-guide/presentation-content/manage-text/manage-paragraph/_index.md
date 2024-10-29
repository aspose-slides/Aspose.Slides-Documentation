---
title: PowerPoint-Absätze in Java verwalten
type: docs
weight: 40
url: /de/androidjava/manage-paragraph/
keywords: "PowerPoint-Absatz hinzufügen, Absätze verwalten, Absatz-Einzug, Absatz-Eigenschaften, HTML-Text, Absatztext exportieren, PowerPoint-Präsentation, Java, Aspose.Slides für Android via Java"
description: "Erstellen und verwalten Sie Absätze, Text, Einzüge und Eigenschaften in PowerPoint-Präsentationen in Java"
---

Aspose.Slides bietet alle Schnittstellen und Klassen, die Sie benötigen, um mit PowerPoint-Texten, -Absätzen und -Teilen in Java zu arbeiten.

* Aspose.Slides bietet die [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) Schnittstelle, die es Ihnen ermöglicht, Objekte hinzuzufügen, die einen Absatz darstellen. Ein `ITextFrame`-Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides bietet die [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) Schnittstelle, die es Ihnen ermöglicht, Objekte hinzuzufügen, die Teile darstellen. Ein `IParagraph`-Objekt kann einen oder mehrere Teile enthalten (Sammlung von iPortion-Objekten).
* Aspose.Slides bietet die [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) Schnittstelle, um Objekte hinzuzufügen, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`-Objekt ist in der Lage, Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`-Objekte zu behandeln.

## **Fügen Sie mehrere Absätze mit mehreren Teilen hinzu**

Diese Schritte zeigen Ihnen, wie Sie ein Textfeld mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Teile enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf das relevante Folienreferenz zu.
3. Fügen Sie der Folie eine Rechtecks-[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Holen Sie sich das mit der [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) verbundene ITextFrame.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) Objekte und fügen Sie sie der `IParagraphs`-Sammlung des [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) hinzu.
6. Erstellen Sie drei [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) Objekte für jeden neuen `IParagraph` (zwei Portion-Objekte für den Standardabsatz) und fügen Sie jedes `IPortion`-Objekt der IPortion-Sammlung jedes `IParagraph` hinzu.
7. Legen Sie für jedes Teil einen Text fest.
8. Wenden Sie Ihre bevorzugten Formatierungsmerkmale für jedes Teil mithilfe der von dem `IPortion`-Objekt bereitgestellten Formatierungseigenschaften an.
9. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code ist eine Implementierung der Schritte zum Hinzufügen von Absätzen mit Teilen:

```java
// Erstellen Sie eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Zugriff auf das TextFrame der AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Erstellen Sie Absätze und Teile mit unterschiedlichen Textformaten
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

    // Schreiben Sie PPTX auf die Festplatte
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Verwalten von Absatz-Aufzählungszeichen**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf das relevante Folienreferenz zu.
3. Fügen Sie der ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) der Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) Klasse.
7. Setzen Sie den `Type` des Aufzählungszeichens für den Absatz auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Setzen Sie den `Text` des Absatzes.
9. Setzen Sie den `Indent` des Absatzes für das Aufzählungszeichen.
10. Setzen Sie eine Farbe für das Aufzählungszeichen.
11. Setzen Sie eine Höhe für das Aufzählungszeichen.
12. Fügen Sie den neuen Absatz der Absatzsammlung im `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang gemäß den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein Absatz-Aufzählungszeichen hinzufügen:

```java
// Erstellen Sie eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape hinzu und greifen Sie zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textframe der Autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Entfernen Sie den Standardabsatz
    txtFrm.getParagraphs().removeAt(0);

    // Erstellen Sie einen Absatz
    Paragraph para = new Paragraph();

    // Setzen Sie einen Absatz-Aufzählungszeichentyp und Symbol
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Setzen Sie einen Absatztext
    para.setText("Willkommen bei Aspose.Slides");

    // Setzen Sie den Aufzählungszeichen-Einzug
    para.getParagraphFormat().setIndent(25);

    // Setzen Sie die Farbe des Aufzählungszeichens
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor auf true setzen, um die eigene Aufzählungszeichenfarbe zu verwenden

    // Setzen Sie die Aufzählungszeichenhöhe
    para.getParagraphFormat().getBullet().setHeight(100);

    // Fügen Sie den Absatz zum Textframe hinzu
    txtFrm.getParagraphs().add(para);

    // Erstellen Sie den zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Setzen Sie den Absatz-Aufzählungszeichentyp und Stil
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Fügen Sie den Absatztext hinzu
    para2.setText("Dies ist eine nummerierte Aufzählung");

    // Setzen Sie den Aufzählungszeichen-Einzug
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor auf true setzen, um die eigene Aufzählungszeichenfarbe zu verwenden

    // Setzen Sie die Höhe des Aufzählungszeichens
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Fügen Sie den Absatz zum Textframe hinzu
    txtFrm.getParagraphs().add(para2);
    
    // Speichern Sie die modifizierte Präsentation
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Verwalten von Bild-Aufzählungszeichen**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf das relevante Folienreferenz zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) der Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungszeichentyp auf [Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatz `Text`.
10. Setzen Sie den Absatz `Indent` für das Aufzählungszeichen.
11. Setzen Sie eine Farbe für das Aufzählungszeichen.
12. Setzen Sie eine Höhe für das Aufzählungszeichen.
13. Fügen Sie den neuen Absatz der Absatzsammlung im `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang entsprechend den vorherigen Schritten.
15. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie Bild-Aufzählungszeichen hinzufügen und verwalten:

```java
// Erstellen Sie eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation presentation = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instanzieren Sie das Bild für Aufzählungszeichen
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Fügen Sie eine AutoShape hinzu und greifen Sie zu
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textframe der Autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Entfernen Sie den Standardabsatz
    textFrame.getParagraphs().removeAt(0);

    // Erstellen Sie einen neuen Absatz
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Willkommen bei Aspose.Slides");

    // Setzen Sie den Absatz-Aufzählungszeichentyp und Bild
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Setzen Sie die Höhe des Aufzählungszeichens
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Fügen Sie den Absatz zum Textframe hinzu
    textFrame.getParagraphs().add(paragraph);

    // Schreiben Sie die Präsentation als PPTX-Datei
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Schreiben Sie die Präsentation als PPT-Datei
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Verwalten von mehrstufigen Aufzählungszeichen**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungszeichen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf das relevante Folienreferenz zu.
3. Fügen Sie eine [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) in die neue Folie ein.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) der Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz über die `Paragraph` Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz über die `Paragraph` Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz über die `Paragraph` Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der Absatzsammlung im `TextFrame` hinzu.
11. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie mehrstufige Aufzählungszeichen hinzufügen und verwalten:

```java
// Erstellen Sie eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape hinzu und greifen Sie zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf den Textframe der erstellten Autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Löschen Sie den Standardabsatz
    text.getParagraphs().clear();

    // Fügen Sie den ersten Absatz hinzu
    IParagraph para1 = new Paragraph();
    para1.setText("Inhalt");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Legen Sie die Bullet-Ebene fest
    para1.getParagraphFormat().setDepth((short)0);

    // Fügen Sie den zweiten Absatz hinzu
    IParagraph para2 = new Paragraph();
    para2.setText("Zweite Ebene");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Legen Sie die Bullet-Ebene fest
    para2.getParagraphFormat().setDepth((short)1);

    // Fügen Sie den dritten Absatz hinzu
    IParagraph para3 = new Paragraph();
    para3.setText("Dritte Ebene");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Legen Sie die Bullet-Ebene fest
    para3.getParagraphFormat().setDepth((short)2);

    // Fügen Sie den vierten Absatz hinzu
    IParagraph para4 = new Paragraph();
    para4.setText("Vierte Ebene");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Legen Sie die Bullet-Ebene fest
    para4.getParagraphFormat().setDepth((short)3);

    // Fügen Sie Absätze zur Sammlung hinzu
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Schreiben Sie die Präsentation als PPTX-Datei
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Verwalten von Absätzen mit benutzerdefinierter nummerierter Liste**

Die [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) Schnittstelle bietet die [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) Eigenschaft und andere, die es Ihnen ermöglichen, Absätze mit benutzerdefinierter Nummerierung oder Formatierung zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das autoshape [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatzinstanz über die `Paragraph` Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz über die `Paragraph` Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der Absatzsammlung im `TextFrame` hinzu.
10. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf den Textframe der erstellten Autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // Entfernen Sie den vorhandenen Standardabsatz
    textFrame.getParagraphs().removeAt(0);

    // Erste Liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("Aufzählung 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("Aufzählung 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("Aufzählung 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Absatz-Einzug setzen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf das relevante Folienreferenz zu.
3. Fügen Sie der Folie eine Rechtecks-[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Fügen Sie ein [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) mit drei Absätzen zur Rechtecks-Autoshape hinzu.
5. Blenden Sie die Rechtecklinien aus.
6. Setzen Sie den Einzug für jeden [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) über deren BulletOffset-Eigenschaft.
7. Schreiben Sie die modifizierte Präsentation als PPT-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Absatz-Einzug festlegen:

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine Rechteck-Form hinzu
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ITextFrame tf = rect.addTextFrame("Dies ist die erste Zeile \rDies ist die zweite Zeile \rDies ist die dritte Zeile");
    
    // Stellen Sie den Text so ein, dass er in die Form passt
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Blenden Sie die Linien des Rechtecks aus
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Holen Sie sich den ersten Absatz im TextFrame und setzen Sie dessen Einzug
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Absatz-Aufzählungszeichentyp und Symbol festlegen
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Holen Sie sich den zweiten Absatz im TextFrame und setzen Sie dessen Einzug
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Holen Sie sich den dritten Absatz im TextFrame und setzen Sie dessen Einzug
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // Schreiben Sie die Präsentation auf die Festplatte
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hängenden Einzug für Absatz setzen**

Dieser Java-Code zeigt Ihnen, wie Sie den hängenden Einzug für einen Absatz festlegen:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Beispiel");

    Paragraph para2 = new Paragraph();
    para2.setText("Hängenden Einzug für Absatz setzen");

    Paragraph para3 = new Paragraph();
    para3.setText("Dieser C#-Code zeigt Ihnen, wie Sie den hängenden Einzug für einen Absatz festlegen:");

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

## **Eigenschaften des Endabsatzlaufs für Absatz verwalten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Referenz für die Folie, die den Absatz enthält, über ihre Position.
3. Fügen Sie ein Rechtecks-[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) zur Folie hinzu.
4. Fügen Sie ein [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) mit zwei Absätzen zur Rechtecks-Autoshape hinzu.
5. Setzen Sie die `FontHeight` und den Schriftgrad für die Absätze.
6. Setzen Sie die End-Eigenschaften für die Absätze.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die End-Eigenschaften für Absätze in PowerPoint festlegen: 

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Beispieltext"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Beispieltext 2"));

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


## **HTML-Text in Absätze importieren**

Aspose.Slides bietet verbesserte Unterstützung für das Importieren von HTML-Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf das relevante Folienreferenz zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Fügen Sie das `autoshape` [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quelldatei HTML in einen TextReader ein.
7. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) Klasse.
8. Fügen Sie den Inhalt der HTML-Datei, die im gelesenen TextReader vorhanden ist, der [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code ist eine Implementierung der Schritte zum Importieren von HTML-Text in Absätze:

```java
// Erstellen Sie eine leere Präsentationsinstanz
Presentation pres = new Presentation();
try {
    // Zugriff auf die standardmäßige erste Folie der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen der AutoShape zur Aufnahme des HTML-Inhalts
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Hinzufügen des Textframe zur Form
    ashape.addTextFrame("");

    // Alle Absätze im hinzugefügten Textframe löschen
    ashape.getTextFrame().getParagraphs().clear();

    // Laden der HTML-Datei mit dem Stream-Reader
    TextReader tr = new StreamReader("file.html");

    // Hinzufügen der Texte aus dem HTML-Stream-Reader in das Textframe
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Speichern der Präsentation
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Export von Absatztext nach HTML**

Aspose.Slides bietet verbesserte Unterstützung für das Exportieren von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über seinen Index auf das relevante Folienreferenz zu.
3. Greifen Sie auf die Form zu, die den Text enthält, der nach HTML exportiert werden soll.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML-Datei hinzu.
6. Geben Sie StreamWriter einen Startindex und exportieren Sie Ihre gewünschten Absätze.

Dieser Java-Code zeigt Ihnen, wie Sie den Text von PowerPoint-Absätzen nach HTML exportieren:

```java
// Laden Sie die Präsentationsdatei
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Zugriff auf die standardmäßige erste Folie der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Gewünschter Index
    int index = 0;

    // Zugriff auf die hinzugefügte Form
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Erstellen der Ausgabedatei HTML
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Extrahieren des ersten Absatzes als HTML
    // Schreiben von Absatzdaten in HTML, indem der Startabsatzindex und die Gesamtanzahl der zu kopierenden Absätze bereitgestellt werden
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```