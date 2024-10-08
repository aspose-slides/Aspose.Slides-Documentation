---
title: Zoom verwalten
type: docs
weight: 60
url: /de/androidjava/manage-zoom/
keywords: "Zoom, Zoom-Frame, Zoom hinzufügen, Zoom-Frame formatieren, Zusammenfassungs-Zoom, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Fügen Sie Zoom oder Zoom-Frames zu PowerPoint-Präsentationen in Java hinzu"
---

## **Überblick**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Teilbereichen einer Präsentation zu springen. Während Sie präsentieren, kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein.

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungs-Zoom](#Zusammenfassungs-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folien-Zoom](#Folien-Zoom).
* Um nur einen einzigen Abschnitt anzuzeigen, verwenden Sie einen [Abschnitts-Zoom](#Abschnitts-Zoom).

## **Folien-Zoom**
Ein Folien-Zoom kann Ihre Präsentation dynamischer gestalten, indem er es Ihnen ermöglicht, frei zwischen den Folien in der von Ihnen gewählten Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folien-Zooms sind großartig für kurze Präsentationen ohne viele Abschnitte, können aber auch in verschiedenen Präsentationsszenarien verwendet werden.

Folien-Zooms helfen Ihnen, mehrere Informationen zu erkunden, während Sie sich wie auf einer einzigen Leinwand fühlen. 

![overview_image](slidezoomsel.png)

Für Folien-Zoom-Objekte bietet Aspose.Slides die [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType) Aufzählung, das [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) Interface und einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Interface an.

### **Zoom-Frames erstellen**

Sie können einen Zoom-Frame auf einer Folie auf folgende Weise hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoom-Frames verknüpfen möchten.
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie dem ersten Slide Zoom-Frames (die Referenzen zu den erstellten Folien enthalten) hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zoom-Frame auf einer Folie erstellen:

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

    // Erstellt eine Textbox für die zweite Folie
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Zweite Folie");

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Erstellt eine Textbox für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Dritte Folie");

    //Fügt ZoomFrame-Objekte hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zoom-Frames mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides für Android über Java können Sie einen Zoom-Frame mit einem anderen Folienvorschau-Bild auf folgende Weise erstellen:
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom-Frame verknüpfen möchten.
3. Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Objekt verknüpft ist, das verwendet wird, um den Frame zu füllen.
5. Fügen Sie dem ersten Slide Zoom-Frames (die die Referenz zur erstellten Folie enthalten) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zoom-Frame mit einem anderen Bild erstellen:

``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Erstellt einen Hintergrund für die zweite Folie
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Erstellt eine Textbox für die dritte Folie
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Zweite Folie");

    // Erstellt ein neues Bild für das Zoom-Objekt
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Fügt das ZoomFrame-Objekt hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    //Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zoom-Frames formatieren**
In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoom-Frames erstellen. Um kompliziertere Zoom-Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom-Frame anwenden können. 

Sie können die Formatierung eines Zoom-Frames auf einer Folie auf folgende Weise steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoom-Frame verknüpfen möchten.
3. Fügen Sie den erstellten Folien einige Identifikationstexte und Hintergründe hinzu.
4. Fügen Sie dem ersten Slide Zoom-Frames (die die Referenzen zu den erstellten Folien enthalten) hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zu der Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Objekt verwandt ist, das verwendet wird, um den Frame zu füllen.
6. Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom-Frame-Objekt.
7. Ändern Sie die Linienformatierung für das zweite Zoom-Frame-Objekt.
8. Entfernen Sie den Hintergrund von einem Bild des zweiten Zoom-Frame-Objekts.
9. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die Formatierung eines Zoom-Frames auf einer Folie ändern: 

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

    // Erstellt eine Textbox für die zweite Folie
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Zweite Folie");

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Erstellt eine Textbox für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Dritte Folie");

    //Fügt ZoomFrame-Objekte hinzu
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Erstellt ein neues Bild für das Zoom-Objekt
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Setzt das benutzerdefinierte Bild für das zoomFrame1-Objekt
    zoomFrame1.setImage(picture);

    // Setzt die Zoom-Frame-Formatierung für das zoomFrame2-Objekt
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Einstellung, um den Hintergrund für das zoomFrame2-Objekt nicht anzuzeigen
    zoomFrame2.setShowBackground(false);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Abschnitts-Zoom**

Ein Abschnitts-Zoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnitts-Zooms verwenden, um zu den Abschnitten zurückzukehren, die Sie wirklich betonen möchten. Oder Sie können sie verwenden, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind.

![overview_image](seczoomsel.png)

Für Abschnitts-Zoom-Objekte bietet Aspose.Slides das [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) Interface und einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Interface.

### **Abschnitts-Zoom-Frames erstellen**

Sie können einen Abschnitts-Zoom-Frame auf einer Folie auf folgende Weise hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom-Frame verknüpfen möchten.
5. Fügen Sie dem ersten Slide einen Abschnitts-Zoom-Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zoom-Frame auf einer Folie erstellen:

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
### **Abschnitts-Zoom-Frames mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für Android über Java können Sie einen Abschnitts-Zoom-Frame mit einem anderen Folienvorschau-Bild auf folgende Weise erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom-Frame verknüpfen möchten. 
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Objekt verknüpft ist, das verwendet wird, um den Frame zu füllen.
5. Fügen Sie dem ersten Slide einen Abschnitts-Zoom-Frame (der eine Referenz zum erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zoom-Frame mit einem anderen Bild erstellen:

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

    // Erstellt ein neues Bild für das Zoom-Objekt
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
### **Abschnitts-Zoom-Frames formatieren**

Um kompliziertere Abschnitts-Zoom-Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitts-Zoom-Frame anwenden können. 

Sie können die Formatierung eines Abschnitts-Zoom-Frames auf einer Folie auf folgende Weise steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom-Frame verknüpfen möchten.
5. Fügen Sie dem ersten Slide einen Abschnitts-Zoom-Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6. Ändern Sie die Größe und Position für das erstellte Abschnitts-Zoom-Objekt.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zu der Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Objekt verwandt ist, das verwendet wird, um den Frame zu füllen.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts-Zoom-Frame-Objekt.
9. Setzen Sie die Fähigkeit *zum ursprünglichen Slide vom verknüpften Abschnitt zurückzukehren*. 
10. Entfernen Sie den Hintergrund von einem Bild des Abschnitts-Zoom-Frame-Objekts.
11. Ändern Sie die Linienformatierung für das zweite Zoom-Frame-Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die Formatierung eines Abschnitts-Zoom-Frames ändern:

``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Abschnitt 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatierung für SectionZoomFrame
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

## **Zusammenfassungs-Zoom**

Ein Zusammenfassungs-Zoom ist wie eine Landing-Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Wenn Sie präsentieren, können Sie den Zoom verwenden, um von einem Ort in Ihrer Präsentation an einen anderen zu gelangen, in welcher Reihenfolge Sie möchten. Sie können kreativ werden, vorspringen oder Teile Ihrer Diashow erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungs-Zoom-Objekte bietet Aspose.Slides die [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) Interfaces und einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Interface.

### **Zusammenfassungs-Zoom erstellen**

Sie können einen Zusammenfassungs-Zoom-Frame auf folgender Weise zu einer Folie hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie den Zusammenfassungs-Zoom-Frame zur ersten Folie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Zusammenfassungs-Zoom-Frame auf einer Folie erstellen:

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

### **Zusammenfassungs-Zoom-Abschnitt hinzufügen und entfernen**

Alle Abschnitte in einem Zusammenfassungs-Zoom-Frame werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) Objekte dargestellt, die in dem [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) Objekt gespeichert sind. Sie können ein Zusammenfassungs-Zoom-Abschnitt-Objekt über das [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) Interface auf folgende Weise hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungs-Zoom-Frame zur ersten Folie hinzu.
4. Fügen Sie eine neue Folie und einen Abschnitt zur Präsentation hinzu.
5. Fügen Sie den erstellten Abschnitt zum Zusammenfassungs-Zoom-Frame hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungs-Zoom-Frame.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie Abschnitte in einem Zusammenfassungs-Zoom-Frame hinzufügen und entfernen:

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

    // Fügt einen Abschnitt zum Zusammenfassungs-Zoom hinzu
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Entfernt den Abschnitt aus dem Zusammenfassungs-Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Zusammenfassungs-Zoom-Abschnitte formatieren**

Um kompliziertere Zusammenfassungs-Zoom-Abschnitts-Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungs-Zoom-Abschnitts-Objekt anwenden können. 

Sie können die Formatierung eines Zusammenfassungs-Zoom-Abschnitts-Objekts in einem Zusammenfassungs-Zoom-Frame auf folgende Weise steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungs-Zoom-Frame zur ersten Folie hinzu.
4. Holen Sie sich ein Zusammenfassungs-Zoom-Abschnitts-Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Objekt verknüpft ist, das verwendet wird, um den Frame zu füllen.
6. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts-Zoom-Frame-Objekt.
7. Setzen Sie die Fähigkeit *zum ursprünglichen Slide vom verknüpften Abschnitt zurückzukehren*. 
8. Ändern Sie die Linienformatierung für das zweite Zoom-Frame-Objekt.
9. Ändern Sie die Übergangsdauer.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die Formatierung für ein Zusammenfassungs-Zoom-Abschnitts-Objekt ändern:

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