---
title: Verwalten von PowerPoint-Absätzen in Java
type: docs
weight: 40
url: /de/java/manage-paragraph/
keywords: "PowerPoint-Absatz hinzufügen, Absätze verwalten, Absatz-Formatierung, Absatz-Eigenschaften, HTML-Text, Absatztext exportieren, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Erstellen und verwalten Sie Absätze, Text, Einzüge und Eigenschaften in PowerPoint-Präsentationen in Java"
---

Aspose.Slides bietet alle Schnittstellen und Klassen, die Sie benötigen, um mit PowerPoint-Texten, Absätzen und Abschnitten in Java zu arbeiten.

* Aspose.Slides bietet die [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die einen Absatz darstellen. Ein `ITextFrame`-Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides bietet die [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die Abschnitte darstellen. Ein `IParagraph`-Objekt kann einen oder mehrere Abschnitte (Sammlung von iPortion-Objekten) enthalten.
* Aspose.Slides bietet die [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`-Objekt ist in der Lage, Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`-Objekte zu handhaben.

## **Fügen Sie mehrere Absätze mit mehreren Abschnitten hinzu**

Diese Schritte zeigen Ihnen, wie Sie ein Textfeld hinzufügen, das 3 Absätze enthält, wobei jeder Absatz 3 Abschnitte enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie eine Rechteck-[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Holen Sie sich das mit der [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) verbundene ITextFrame.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) Objekte und fügen Sie sie der `IParagraphs`-Sammlung des [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) hinzu.
6. Erstellen Sie drei [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) Objekte für jeden neuen `IParagraph` (zwei Portionsobjekte für den Standardabsatz) und fügen Sie jedes `IPortion`-Objekt der IPortion-Sammlung jedes `IParagraph` hinzu.
7. Setzen Sie für jeden Abschnitt einen Text.
8. Wenden Sie Ihre bevorzugten Formatierungsmerkmale für jeden Abschnitt mithilfe der von dem `IPortion`-Objekt bereitgestellten Formatierungseigenschaften an.
9. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code ist eine Implementierung der Schritte zum Hinzufügen von Absätzen mit Abschnitten:

```java
// Erstellen Sie eine Instanz der Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen einer AutoForm vom Typ Rechteck
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Zugriff auf das Textfeld der AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Erstellen Sie Absätze und Abschnitte mit unterschiedlichen Textformaten
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

    //Speichern Sie die PPTX auf der Festplatte
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Absatzpunkte verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Aufzählungsabsätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) der AutoShape zu. 
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse.
7. Setzen Sie den Aufzählungs `Typ` für den Absatz auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Setzen Sie den Absatz `Text`.
9. Setzen Sie den Absatz `Einzug` für die Aufzählung.
10. Setzen Sie eine Farbe für die Aufzählung.
11. Setzen Sie eine Höhe für die Aufzählung.
12. Fügen Sie den neuen Absatz der Absatzsammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess gemäß den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie einen Absatzpunkt hinzufügen:

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügt eine und greift auf AutoShape zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textfeld der AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Entfernen Sie den Standardabsatz
    txtFrm.getParagraphs().removeAt(0);

    // Erstellen Sie einen Absatz
    Paragraph para = new Paragraph();

    // Setzt einen Absatzaufzählungsstil und Symbol
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Setzt einen Absatztext
    para.setText("Willkommen bei Aspose.Slides");

    // Setzt den Aufzählungseinzug
    para.getParagraphFormat().setIndent(25);

    // Setzt die Aufzählungsfarbe
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // set IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden

    // Setzt die Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz zum Textfeld hinzu
    txtFrm.getParagraphs().add(para);

    // Erstellt den zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Setzt den Absatzaufzählungstyp und Stil
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Fügt Absatztext hinzu
    para2.setText("Dies ist eine nummerierte Aufzählung");

    // Setzt den Aufzählungseinzug
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // set IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden

    // Setzt die Aufzählungshöhe
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz zum Textfeld hinzu
    txtFrm.getParagraphs().add(para2);
    
    // Speichert die modifizierte Präsentation
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Verwalten von Bildaufzählungen**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) der AutoShape zu. 
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungstyp auf [Bild](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) und setzen Sie das Bild.
9. Setzen Sie den Absatz `Text`.
10. Setzen Sie den Absatz `Einzug` für die Aufzählung.
11. Setzen Sie eine Farbe für die Aufzählung.
12. Setzen Sie eine Höhe für die Aufzählung.
13. Fügen Sie den neuen Absatz der Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess gemäß den vorherigen Schritten.
15. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie Bildaufzählungen hinzufügen und verwalten:

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation presentation = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instanziiert das Bild für Aufzählungen
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Fügt hinzu und greift auf AutoShape zu
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textfeld der AutoShape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Entfernen Sie den Standardabsatz
    textFrame.getParagraphs().removeAt(0);

    // Erstellen Sie einen neuen Absatz
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Willkommen bei Aspose.Slides");

    // Setzt Absatzaufzählungsstil und Bild
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Setzt die Aufzählungshöhe
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Fügt den Absatz zum Textfeld hinzu
    textFrame.getParagraphs().add(paragraph);

    // Schreibt die Präsentation als PPTX-Datei
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.PptX);

    // Schreibt die Präsentation als PPT-Datei
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Verwalten mehrstufiger Aufzählungen**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie in der neuen Folie eine [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) der AutoShape zu. 
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz mit der `Paragraph`-Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz mit der `Paragraph`-Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz mit der `Paragraph`-Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie mehrstufige Aufzählungen hinzufügen und verwalten:

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügt hinzu und greift auf AutoShape zu
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textfeld der erstellten AutoShape
    ITextFrame text = aShp.addTextFrame("");

    // Löschen des Standardabsatzes
    text.getParagraphs().clear();

    // Fügt den ersten Absatz hinzu
    IParagraph para1 = new Paragraph();
    para1.setText("Inhalt");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Setzt die Aufzählungsebene
    para1.getParagraphFormat().setDepth((short)0);

    // Fügt den zweiten Absatz hinzu
    IParagraph para2 = new Paragraph();
    para2.setText("Zweite Ebene");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Setzt die Aufzählungsebene
    para2.getParagraphFormat().setDepth((short)1);

    // Fügt den dritten Absatz hinzu
    IParagraph para3 = new Paragraph();
    para3.setText("Dritte Ebene");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Setzt die Aufzählungsebene
    para3.getParagraphFormat().setDepth((short)2);

    // Fügt den vierten Absatz hinzu
    IParagraph para4 = new Paragraph();
    para4.setText("Vierte Ebene");
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

    // Schreibt die Präsentation als PPTX-Datei
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Verwalten von Absätzen mit benutzerdefinierten nummerierten Listen**

Die [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) Schnittstelle bietet die [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) Eigenschaft und andere, die es Ihnen ermöglichen, Absätze mit benutzerdefinierten Nummerierungen oder Formatierungen zu verwalten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatzinstanz mit der `Paragraph`-Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz mit der `Paragraph`-Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie Absätze mit benutzerdefinierten Nummerierungen oder Formatierungen hinzufügen und verwalten:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf das Textfeld der AutoShape
    ITextFrame textFrame = shape.getTextFrame();

    // Entfernen des vorhandenen Standardabsatzes
    textFrame.getParagraphs().removeAt(0);

    // Erster Listeneintrag
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


## **Setzen des Absatz-Einzugs**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
1. Greifen Sie über den Index auf die entsprechende Folie zu.
1. Fügen Sie der Folie eine Rechteck-[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck-AutoShape ein [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Rechtecklinien aus.
1. Setzen Sie den Einzug für jeden [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) über die BulletOffset-Eigenschaft.
1. Schreiben Sie die modifizierte Präsentation als PPT-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Absatz-Einzug setzen:

```java
// Instanziiert eine Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Erhalten Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine rechteckige Form hinzu
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Fügen Sie dem Rechteck ein TextFrame hinzu
    ITextFrame tf = rect.addTextFrame("Dies ist die erste Zeile \rDies ist die zweite Zeile \rDies ist die dritte Zeile");
    
    // Setzen Sie den Text so, dass er in die Form passt
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Blenden Sie die Linien des Rechtecks aus
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Erhalten Sie den ersten Absatz im TextFrame und setzen Sie seinen Einzug
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Setzen des Absatzaufzählungsstils und Symbols
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Erhalten Sie den zweiten Absatz im TextFrame und setzen Sie seinen Einzug
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Erhalten Sie den dritten Absatz im TextFrame und setzen Sie seinen Einzug
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

## **Setzen des hängenden Einzugs für Absätze**

Dieser Java-Code zeigt Ihnen, wie Sie den hängenden Einzug für einen Absatz setzen:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Beispiel");

    Paragraph para2 = new Paragraph();
    para2.setText("Hängenden Einzug für Absatz setzen");

    Paragraph para3 = new Paragraph();
    para3.setText("Dieser C#-Code zeigt Ihnen, wie Sie den hängenden Einzug für einen Absatz setzen: ");

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

## **Verwalten der Endabsatzlauf-Eigenschaften für Absätze**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz für die Folie, die den Absatz enthält, über ihre Position.
1. Fügen Sie der Folie eine Rechteck-[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
1. Fügen Sie ein [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) mit zwei Absätzen zum Rechteck hinzu.
1. Setzen Sie die `FontHeight` und Typ für die Absätze.
1. Setzen Sie die End-Eigenschaften für die Absätze.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die End-Eigenschaften für Absätze in PowerPoint setzen: 

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

Aspose.Slides bietet erweiterte Unterstützung für den Import von HTML-Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) hinzu.
4. Fügen Sie das `AutoShape` [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die HTML-Quelldatei in einen TextReader.
7. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) Klasse.
8. Fügen Sie den Inhalt der HTML-Datei, die im gelesenen TextReader enthalten ist, der Absatzsammlung des Textfelds (ParagraphCollection) hinzu.
9. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code ist eine Implementierung der Schritte zum Importieren von HTML-Text in Absätze:

```java
// Erstellen Sie eine leere Präsentationsinstanz
Presentation pres = new Presentation();
try {
    // Zugriff auf die standardmäßige erste Folie der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen der AutoShape, um den HTML-Inhalt zu unterbringen
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Hinzufügen eines Textfelds zur Form
    ashape.addTextFrame("");

    // Löschen aller Absätze im hinzugefügten Textfeld
    ashape.getTextFrame().getParagraphs().clear();

    // Laden Sie die HTML-Datei mit einem Stream-Reader
    TextReader tr = new StreamReader("file.html");

    // Hinzufügen von Text aus dem HTML-Stream-Reader zum Textfeld
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Speichern der Präsentation
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exportieren von Absatztext in HTML**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Zugriff auf die Form, die den Text enthält, der in HTML exportiert werden soll.
4. Zugriff auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) der Form.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML-Datei hinzu.
6. Geben Sie einen Startindex für den StreamWriter an und exportieren Sie Ihre bevorzugten Absätze.

Dieser Java-Code zeigt Ihnen, wie Sie den Text aus PowerPoint-Absätzen nach HTML exportieren:

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

    // Erstellen einer Ausgabedatei im HTML-Format
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Extrahieren des ersten Absatzes als HTML
    // Schreiben der Absätze in HTML, indem der Startindex des Absatzes, die Anzahl der zu kopierenden Absätze angegeben wird
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```