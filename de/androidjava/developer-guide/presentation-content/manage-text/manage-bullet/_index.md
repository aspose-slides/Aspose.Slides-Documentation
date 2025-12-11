---
title: Verwalten von Aufzählungs‑ und nummerierten Listen in Präsentationen auf Android
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/androidjava/manage-bullet/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs‑ und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Android via Java verwalten. Schritt‑für‑Schritt‑Anleitung."
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und nummerierte Listen auf dieselbe Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for Android via Java** ermöglicht es Ihnen ebenfalls, Aufzählungszeichen und Nummern in Folien Ihrer Präsentationen zu verwenden.

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren.

**Beispiel für Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Betrachter auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Betrachtern, Schlüssel­punkte leicht zu überfliegen
- kommuniziert und liefert wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls beim Organisieren und Präsentieren von Informationen. Idealerweise sollten Sie Zahlen (statt Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (z. B. *siehe Schritt 3*).

**Beispiel für nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im nachfolgenden Verfahren **Creating Bullets**:

1. Erstellen Sie eine Instanz der Präsentationsklasse.  
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).  
3. Speichern Sie die Präsentation.  

## **Aufzählungen erstellen**

Dieses Thema ist Teil der Serie zum Verwalten von Textabsätzen. Diese Seite illustriert, wie wir Absatz‑Aufzählungszeichen verwalten können. Aufzählungszeichen sind besonders nützlich, wenn etwas in Schritten beschrieben wird. Außerdem wirkt der Text mit Aufzählungszeichen übersichtlich. Aufzählungs‑Absätze sind immer leichter zu lesen und zu verstehen. Wir zeigen, wie Entwickler dieses kleine, aber leistungsstarke Feature von Aspose.Slides for Android via Java nutzen können. Bitte folgen Sie den untenstehenden Schritten, um Absatz‑Aufzählungszeichen mit Aspose.Slides for Android via Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Greifen Sie mit dem Objekt [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) auf die gewünschte Folie in der Folien‑Sammlung zu.  
3. Fügen Sie im ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) hinzu.  
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) der hinzugefügten Form zu.  
5. Entfernen Sie den Standardabsatz im TextFrame.  
6. Erstellen Sie die erste Absatz‑Instanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).  
7. Legen Sie den Aufzählungstyp des Absatzes fest.  
8. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) und definieren Sie das Aufzählungszeichen.  
9. Legen Sie den Absatztext fest.  
10. Stellen Sie den Absatz‑Einzug ein, um das Aufzählungszeichen zu setzen.  
11. Legen Sie die Farbe des Aufzählungszeichens fest.  
12. Stellen Sie die Höhe der Aufzählungszeichen ein.  
13. Fügen Sie den erstellten Absatz in die Absatz‑Sammlung des TextFrames ein.  
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten **7 bis 13**.  
15. Speichern Sie die Präsentation.  

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugriff auf eine AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf den TextFrame der erstellten AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);
    
    // Erstellen eines Absatzes
    Paragraph para = new Paragraph();
    
    // Festlegen des Aufzählungsstils und -symbols für den Absatz
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Festlegen des Absatztexts
    para.setText("Welcome to Aspose.Slides");
    
    // Festlegen des Aufzählungseinzugs
    para.getParagraphFormat().setIndent(25);
    
    // Festlegen der Aufzählungsfarbe
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().setColor(Color.BLACK);
    
    // IsBulletHardColor auf true setzen, um eine eigene Aufzählungsfarbe zu verwenden
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para);
    
    // Speichern der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Bild‑Aufzählungszeichen erstellen**

Aspose.Slides for Android via Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse hinzufügen oder die Aufmerksamkeit auf Listeneinträge noch stärker lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise sollten Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, ein einfaches Grafik‑Bild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen.  

In jedem Fall wird das ausgewählte Bild stark verkleinert, daher empfehlen wir dringend, ein Bild zu wählen, das auch in kleiner Größe gut aussieht (als Ersatz für das Aufzählungszeichen) in einer Liste.  

{{% /alert %}} 

Um ein Bild‑Aufzählungszeichen zu erstellen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Greifen Sie mit dem Objekt [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) auf die gewünschte Folie in der Folien‑Sammlung zu.  
3. Fügen Sie im ausgewählten Folie eine AutoShape hinzu.  
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.  
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
6. Erstellen Sie die erste Absatz‑Instanz mit der Klasse Paragraph.  
7. Laden Sie das Bild von der Festplatte in [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage).  
8. Setzen Sie den Aufzählungstyp auf Picture und legen Sie das Bild fest.  
9. Legen Sie den Absatztext fest.  
10. Stellen Sie den Absatz‑Einzug ein, um das Aufzählungszeichen zu setzen.  
11. Legen Sie die Farbe des Aufzählungszeichens fest.  
12. Stellen Sie die Höhe der Aufzählungszeichen ein.  
13. Fügen Sie den erstellten Absatz in die [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) Absatz‑Sammlung ein.  
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den vorherigen Schritten.  
15. Speichern Sie die Präsentation.  

```java
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanziieren des Bildes für Aufzählungszeichen
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf den TextFrame der erstellten AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().removeAt(0);

    // Erstellen eines neuen Absatzes
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // Festlegen des Absatz-Aufzählungsstils und Bildes
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Festlegen der Aufzählungshöhe
    para.getParagraphFormat().getBullet().setHeight(100);

    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para);

    // Schreiben der Präsentation als PPTX-Datei
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mehrstufige Aufzählungszeichen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält – zusätzliche Listen unter der Haupt‑Aufzählungsliste – gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Greifen Sie mit dem Objekt [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) auf die gewünschte Folie in der Folien‑Sammlung zu.  
3. Fügen Sie im ausgewählten Folie eine AutoShape hinzu.  
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.  
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
6. Erstellen Sie die erste Absatz‑Instanz mit der Klasse Paragraph und Depth = 0.  
7. Erstellen Sie die zweite Absatz‑Instanz mit der Klasse Paragraph und Depth = 1.  
8. Erstellen Sie die dritte Absatz‑Instanz mit der Klasse Paragraph und Depth = 2.  
9. Erstellen Sie die vierte Absatz‑Instanz mit der Klasse Paragraph und Depth = 3.  
10. Fügen Sie die erstellten Absätze in die [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) Absatz‑Sammlung ein.  
11. Speichern Sie die Präsentation.  

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Zugriff auf den TextFrame der erstellten AutoShape
    ITextFrame txtFrm = aShp.addTextFrame("");
    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().clear();
    
    // Erstellen des ersten Absatzes
    Paragraph para1 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und -symbols
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Erstellen des zweiten Absatzes
    Paragraph para2 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und -symbols
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Erstellen des dritten Absatzes
    Paragraph para3 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und -symbols
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Erstellen des vierten Absatzes
    Paragraph para4 = new Paragraph();
    // Festlegen des Absatz-Aufzählungsstils und -symbols
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Festlegen der Aufzählungsebene
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Hinzufügen des Absatzes zum TextFrame
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // Speichern der Präsentation als PPTX-Datei
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Benutzerdefinierte nummerierte Listen erstellen**

Aspose.Slides for Android via Java stellt eine einfache API zum Verwalten von Absätzen mit benutzerdefinierter Zahlenformatierung bereit. Um eine benutzerdefinierte nummerierte Liste in einem Absatz hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Greifen Sie mit dem Objekt [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) auf die gewünschte Folie in der Folien‑Sammlung zu.  
3. Fügen Sie im ausgewählten Folie eine AutoShape hinzu.  
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) der hinzugefügten Form zu.  
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
6. Erstellen Sie die erste Absatz‑Instanz mit der Klasse Paragraph und setzen **NumberedBulletStartWith** auf 2.  
7. Erstellen Sie die zweite Absatz‑Instanz mit der Klasse Paragraph und setzen **NumberedBulletStartWith** auf 3.  
8. Erstellen Sie die dritte Absatz‑Instanz mit der Klasse Paragraph und setzen **NumberedBulletStartWith** auf 7.  
9. Fügen Sie die erstellten Absätze in die [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) Absatz‑Sammlung ein.  
10. Speichern Sie die Präsentation.  

```java
// Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen und Zugriff auf AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Zugriff auf den TextFrame der erstellten AutoShape
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Entfernen des standardmäßigen vorhandenen Absatzes
    txtFrm.getParagraphs().clear();

    // Erste Liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Zweite Liste
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Können mit Aspose.Slides erstellte Aufzählungs- und nummerierte Listen in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides behält die Formatierung und Struktur von Aufzählungs‑ und nummerierten Listen vollständig bei, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt so für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs- oder nummerierte Listen aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs‑ oder nummerierten Listen aus bestehenden Präsentationen, wobei deren ursprüngliche Formatierung und Erscheinungsbild erhalten bleiben.

**Unterstützt Aspose.Slides Aufzählungs- und nummerierte Listen in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und nummerierten Listen in jeder Sprache, einschließlich spezieller oder nicht‑lateinischer Zeichen.