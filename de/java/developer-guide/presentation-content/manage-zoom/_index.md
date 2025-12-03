---
title: Verwalten von Präsentations-Zoom in Java
linktitle: Zoom verwalten
type: docs
weight: 60
url: /de/java/manage-zoom/
keywords:
- Zoom
- Zoom-Frame
- Folien-Zoom
- Abschnitts-Zoom
- Zusammenfassungs-Zoom
- Zoom hinzufügen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen und anpassen von Zoom mit Aspose.Slides für Java — zwischen Abschnitten springen, Miniaturansichten und Übergänge in PPT-, PPTX- und ODP-Präsentationen hinzufügen."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Bereichen einer Präsentation zu springen und von dort zurückzukehren. Beim Vortragen kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#Section-Zoom).

## **Folien‑Zoom**
Ein Folien‑Zoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folien‑Zooms eignen sich gut für kurze Präsentationen ohne viele Abschnitte, können aber auch in anderen Präsentationsszenarien verwendet werden.

Folien‑Zooms helfen Ihnen, mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folien‑Zoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType), das Interface [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) und einige Methoden unter dem Interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereit.

### **Erstellen von Zoom‑Frames**

Sie können einen Zoom‑Frame auf einer Folie wie folgt hinzufügen:

1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken wollen. 
3.	Fügen Sie den erstellten Folien einen Identifizierungstext und einen Hintergrund hinzu.
4.	Fügen Sie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
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
    autoshape.getTextFrame().setText("Second Slide");

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Fügt ZoomFrame-Objekte hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Zoom‑Frames mit benutzerdefinierten Bildern**
Mit Aspose.Slides für Java können Sie einen Zoom‑Frame mit einem anderen Folien‑Vorschaubild wie folgt erstellen: 
1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken wollen. 
3.	Fügen Sie der Folie einen Identifizierungstext und einen Hintergrund hinzu.
4.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
5.	Fügen Sie Zoom‑Frames (die den Verweis auf die erstellte Folie enthalten) zur ersten Folie hinzu.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
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
    autoshape.getTextFrame().setText("Second Slide");

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

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatieren von Zoom‑Frames**
In den vorherigen Abschnitten haben wir gezeigt, wie einfache Zoom‑Frames erstellt werden. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie wie folgt steuern:

1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken wollen. 
3.	Fügen Sie den erstellten Folien etwas Identifizierungstext und Hintergrund hinzu.
4.	Fügen Sie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
6.	Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt.
7.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8.	Entfernen Sie den Hintergrund eines Bildes des zweiten Zoom‑Frame‑Objekts.
5.	Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie die Formatierung eines Zoom‑Frames auf einer Folie ändern: 
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
    autoshape.getTextFrame().setText("Second Slide");

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

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
    // Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
    zoomFrame1.setImage(picture);

    // Setzt ein Zoom-Frame-Format für das zoomFrame2-Objekt
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Einstellung: Hintergrund für zoomFrame2-Objekt nicht anzeigen
    zoomFrame2.setShowBackground(false);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Abschnitts‑Zoom**

Ein Abschnitts‑Zoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnitts‑Zooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders hervorheben möchten. Oder Sie nutzen sie, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnitts‑Zoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) und einige Methoden unter dem Interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereit.

### **Erstellen von Abschnitts‑Zoom‑Frames**

Sie können einen Abschnitts‑Zoom‑Frame zu einer Folie wie folgt hinzufügen:

1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie eine neue Folie. 
3.	Fügen Sie der erstellten Folie einen Identifizierungshintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken wollen. 
5.	Fügen Sie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6.	Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Abschnitts‑Zoom‑Frames mit benutzerdefinierten Bildern**

Mit Aspose.Slides für Java können Sie einen Abschnitts‑Zoom‑Frame mit einem anderen Folien‑Vorschaubild wie folgt erstellen: 

1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie der erstellten Folie einen Identifizierungshintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken wollen. 
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
5.	Fügen Sie einen Abschnitts‑Zoom‑Frame (der einen Verweis auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6.	Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
``` java 
Presentation pres = new Presentation();
try {
    //Fügt neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);

    // Erstellt ein neues Bild für das Zoom-Objekt
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatieren von Abschnitts‑Zoom‑Frames**

Um komplexere Abschnitts‑Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitts‑Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnitts‑Zoom‑Frames auf einer Folie wie folgt steuern:

1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie der erstellten Folie einen Identifizierungshintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken wollen. 
5.	Fügen Sie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6.	Ändern Sie Größe und Position des erstellten Abschnitts‑Zoom‑Objekts.
7.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.
9.	Setzen Sie die *Rückkehr zur ursprünglichen Folie aus dem verlinkten Abschnitt*‑Funktion.
10.	Entfernen Sie den Hintergrund eines Bildes des Abschnitts‑Zoom‑Frame‑Objekts.
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie die Formatierung eines Abschnitts‑Zoom‑Frames ändern:
``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);

    // Fügt SectionZoomFrame-Objekt hinzu
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



## **Zusammenfassungs‑Zoom**

Ein Zusammenfassungs‑Zoom ist wie eine Zielseite, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Vortragen können Sie den Zoom nutzen, um von einem Abschnitt Ihrer Präsentation zu einem anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorspringen oder Teile Ihrer Vorführung erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungs‑Zoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) sowie einige Methoden unter dem Interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereit.

### **Erstellen von Zusammenfassungs‑Zoom**

Sie können einen Zusammenfassungs‑Zoom‑Frame zu einer Folie wie folgt hinzufügen:

1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie den Zusammenfassungs‑Zoom‑Frame zur ersten Folie hinzu.
4.	Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Zusammenfassungs‑Zoom‑Frame auf einer Folie erstellen:
``` java 
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 2", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 3", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 4", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Hinzufügen und Entfernen von Zusammenfassungs‑Zoom‑Abschnitten**

Alle Abschnitte in einem Zusammenfassungs‑Zoom‑Frame werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) Objekt gespeichert sind. Sie können über das Interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) Objekte hinzufügen oder entfernen:

1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie einen Zusammenfassungs‑Zoom‑Frame in die erste Folie ein.
4.	Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5.	Fügen Sie den erstellten Abschnitt dem Zusammenfassungs‑Zoom‑Frame hinzu.
6.	Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungs‑Zoom‑Frame.
7.	Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie Abschnitte in einem Zusammenfassungs‑Zoom‑Frame hinzufügen und entfernen:
``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Fügt einen Abschnitt zum Summary Zoom hinzu
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Entfernt einen Abschnitt aus dem Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Formatieren von Zusammenfassungs‑Zoom‑Abschnitten**

Um komplexere Zusammenfassungs‑Zoom‑Abschnitts‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt anwenden können. 

Sie können die Formatierung eines Zusammenfassungs‑Zoom‑Abschnitts‑Objekts in einem Zusammenfassungs‑Zoom‑Frame wie folgt steuern:

1.	Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2.	Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie einen Zusammenfassungs‑Zoom‑Frame zur ersten Folie hinzu.
4.	Holen Sie ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.
9.	Setzen Sie die *Rückkehr zur ursprünglichen Folie aus dem verlinkten Abschnitt*‑Funktion.
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie die Formatierung eines Zusammenfassungs‑Zoom‑Abschnitts‑Objekts ändern:
``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Holt das erste SummaryZoomSection-Objekt
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatierung für SummaryZoomSection-Objekt
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


## **FAQ**

**Kann ich die Rückkehr zur übergeordneten Folie nach Anzeige des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/java/com.aspose.slides/zoomframe/) oder [section](https://reference.aspose.com/slides/java/com.aspose.slides/sectionzoomframe/) verfügt über ein `ReturnToParent`‑Verhalten, das bei Aktivierung die Betrachter nach dem Besuch des Zielinhalts zur Ausgangsfolie zurückführt.

**Kann ich die 'Geschwindigkeit' oder Dauer der Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Festlegen einer `TransitionDuration`, sodass Sie die Dauer der Sprunganimation steuern können.

**Gibt es Beschränkungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt keine harte API‑Grenze, die dokumentiert wäre. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistungsfähigkeit des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.