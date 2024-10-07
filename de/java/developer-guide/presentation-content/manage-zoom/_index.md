---
title: Zoom verwalten
type: docs
weight: 60
url: /java/manage-zoom/
keywords: "Zoom, Zoomrahmen, Zoom hinzufügen, Zoomrahmen formatieren, Zusammenfassungszoom, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Fügen Sie Zoom oder Zoomrahmen zu PowerPoint-Präsentationen in Java hinzu"
---

## **Überblick**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen. Wenn Sie präsentieren, kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie ein [Zusammenfassungszoom](#Zusammenfassungszoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie ein [Folienzoom](#Folienzoom).
* Um nur einen einzigen Abschnitt anzuzeigen, verwenden Sie ein [Abschnittszoom](#Abschnittszoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer machen, indem er es Ihnen ermöglicht, in beliebiger Reihenfolge frei zwischen Folien zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms sind ideal für kurze Präsentationen ohne viele Abschnitte, können jedoch auch in verschiedenen Präsentationsszenarien verwendet werden.

Folienzooms helfen Ihnen, in mehrere Informationsstücke einzutauchen, während Sie sich wie auf einer einzelnen Leinwand fühlen. 

![overview_image](slidezoomsel.png)

Für Folienzoom-Objekte stellt Aspose.Slides die [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType) Enumeration, das [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) Interface und einige Methoden unter dem [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) Interface zur Verfügung.

### **Erstellen von Zoomrahmen**

Sie können einen Zoomrahmen auf einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoomrahmen verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie Zoomrahmen (die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zoomrahmen auf einer Folie erstellen:

``` java
Presentation pres = new Presentation();
try {
    //Fügt neue Folien zur Präsentation hinzu
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Erstellt einen Hintergrund für die zweite Folie
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Erstellt ein Textfeld für die zweite Folie
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Zweite Folie");

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Dritte Folie");

    //Fügt ZoomFrame-Objekte hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Zoomrahmen mit benutzerdefinierten Bildern**
Mit Aspose.Slides für Java können Sie einen Zoomrahmen mit einem anderen Folienvorschau-Bild wie folgt erstellen: 
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie eine neue Folie, zu der Sie den Zoomrahmen verlinken möchten. 
3. Fügen Sie einen Identifikationstext und einen Hintergrund zur Folie hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Bildersammlung des damit verbundenen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekts hinzufügen, das zur Auffüllung des Rahmens verwendet wird.
5. Fügen Sie Zoomrahmen (die Verweise auf die erstellte Folie enthalten) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zoomrahmen mit einem anderen Bild erstellen:

``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Erstellt einen Hintergrund für die zweite Folie
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Erstellt ein Textfeld für die dritte Folie
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Zweite Folie");

    // Erstellt ein neues Bild für das Zoomobjekt
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Fügt das ZoomFrame-Objekt hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatierung von Zoomrahmen**
In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoomrahmen erstellen. Um kompliziertere Zoomrahmen zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoomrahmen anwenden können. 

Sie können die Formatierung eines Zoomrahmens auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien, zu denen Sie den Zoomrahmen verlinken möchten. 
3. Fügen Sie den erstellten Folien Identifikationstexte und Hintergründe hinzu.
4. Fügen Sie Zoomrahmen (die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Bildersammlung des damit verbundenen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekts hinzufügen, das zur Auffüllung des Rahmens verwendet wird.
6. Setzen Sie ein benutzerdefiniertes Bild für das erste Zoomrahmenobjekt.
7. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
8. Entfernen Sie den Hintergrund von einem Bild des zweiten Zoomrahmenobjekts.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die Formatierung eines Zoomrahmens auf einer Folie ändern: 

``` java 
Presentation pres = new Presentation();
try {
    //Fügt neue Folien zur Präsentation hinzu
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Erstellt einen Hintergrund für die zweite Folie
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Erstellt ein Textfeld für die zweite Folie
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Zweite Folie");

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Dritte Folie");

    //Fügt ZoomFrame-Objekte hinzu
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Erstellt ein neues Bild für das Zoomobjekt
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
    zoomFrame1.setImage(picture);

    // Setzt ein Zoomrahmenformat für das zoomFrame2-Objekt
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Einstellung für Hintergrund ausblenden für das zoomFrame2-Objekt
    zoomFrame2.setShowBackground(false);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie wirklich betonen möchten. Oder Sie können sie verwenden, um hervorzuheben, wie bestimmte Teile Ihrer Präsentation zusammenhängen. 

![overview_image](seczoomsel.png)

Für Abschnittszoom-Objekte stellt Aspose.Slides das [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) Interface und einige Methoden unter dem [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) Interface zur Verfügung.

### **Erstellen von Abschnittszoomrahmen**

Sie können einen Abschnittszoomrahmen zu einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten. 
5. Fügen Sie einen Abschnittszoomrahmen (der Referenzen auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zoomrahmen auf einer Folie erstellen:

``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Abschnittszoomrahmen mit benutzerdefinierten Bildern**

Mit Aspose.Slides für Java können Sie einen Abschnittszoomrahmen mit einem anderen Folienvorschau-Bild wie folgt erstellen: 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten. 
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Bildersammlung des damit verbundenen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekts hinzufügen, das zur Auffüllung des Rahmens verwendet wird.
5. Fügen Sie einen Abschnittszoomrahmen (der eine Referenz auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zoomrahmen mit einem anderen Bild erstellen:

``` java 
Presentation pres = new Presentation();
try {
    //Fügt neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 1", slide);

    // Erstellt ein neues Bild für das Zoomobjekt
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt das SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatierung von Abschnittszoomrahmen**

Um kompliziertere Abschnittszoomrahmen zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnittszoomrahmen anwenden können. 

Sie können die Formatierung eines Abschnittszoomrahmens auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten. 
5. Fügen Sie einen Abschnittszoomrahmen (der Referenzen auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Ändern Sie die Größe und Position des erstellten Abschnittszoomobjekts.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Bildersammlung des damit verbundenen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekts hinzufügen, das zur Auffüllung des Rahmens verwendet wird.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoomrahmenobjekt.
9. Setzen Sie die *Zurückkehrmöglichkeit zur ursprünglichen Folie vom verlinkten Abschnitt*. 
10. Entfernen Sie den Hintergrund von einem Bild des Abschnittszoomrahmenobjekts.
11. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
12. Ändern Sie die Übergangszeit.
13. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die Formatierung eines Abschnittszoomrahmenobjekts ändern:

``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatierung für das SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zusammenfassungszoom**

Ein Zusammenfassungszoom ist wie eine Landing-Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Wenn Sie präsentieren, können Sie mit dem Zoom von einem Ort in Ihrer Präsentation zu einem anderen in beliebiger Reihenfolge wechseln. Sie können kreativ werden, vorspringen oder Teile Ihrer Folienanzeige wieder besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungszoom-Objekte stellt Aspose.Slides die [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) Interfaces sowie einige Methoden unter dem [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) Interface zur Verfügung.

### **Erstellen eines Zusammenfassungszooms**

Sie können einen Zusammenfassungszoomrahmen zu einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergründen und neuen Abschnitten für die erstellten Folien.
3.  Fügen Sie den Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zusammenfassungszoomrahmen auf einer Folie erstellen:

``` java 
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 2", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 3", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 4", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Hinzufügen und Entfernen von Zusammenfassungszoomabschnitten**

Alle Abschnitte in einem Zusammenfassungszoomrahmen werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) Objekt gespeichert sind. Sie können ein Zusammenfassungszoomabschnittsobjekt über das [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) Interface wie folgt hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergründen und neuen Abschnitten für die erstellten Folien.
3.  Fügen Sie einen Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4.  Fügen Sie eine neue Folie und einen Abschnitt zur Präsentation hinzu.
5.  Fügen Sie den erstellten Abschnitt zum Zusammenfassungszoomrahmen hinzu.
6.  Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungszoomrahmen.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie Abschnitte in einem Zusammenfassungszoomrahmen hinzufügen und entfernen:

``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    ISection section3 = pres.getSections().addSection("Abschnitt 3", slide);

    // Fügt einen Abschnitt zum Zusammenfassungszoom hinzu
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Entfernt den Abschnitt aus dem Zusammenfassungszoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatierung von Zusammenfassungszoomabschnitten**

Um kompliziertere Zusammenfassungszoomabschnittsobjekte zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungszoomabschnittsobjekt anwenden können. 

Sie können die Formatierung für ein Zusammenfassungszoomabschnittsobjekt in einem Zusammenfassungszoomrahmen wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergründen und neuen Abschnitten für die erstellten Folien.
3.  Fügen Sie einen Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4.  Holen Sie sich das Zusammenfassungszoomabschnittsobjekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7.  Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Bildersammlung des damit verbundenen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekts hinzufügen, das zur Auffüllung des Rahmens verwendet wird.
8.  Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoomrahmenobjekt.
9.  Setzen Sie die *Zurückkehrmöglichkeit zur ursprünglichen Folie vom verlinkten Abschnitt*. 
11. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
12. Ändern Sie die Übergangszeit.
13. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die Formatierung für ein Zusammenfassungszoomabschnittsobjekt ändern:

``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Holt sich das erste SummaryZoomSection-Objekt
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatierung für das SummaryZoomSection-Objekt
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```