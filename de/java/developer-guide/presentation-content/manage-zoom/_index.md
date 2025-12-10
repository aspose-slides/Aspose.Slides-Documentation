---
title: Verwalten des Präsentations-Zooms in Java
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
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen und wieder zurückzukehren. Beim Vorführen kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um die gesamte Präsentation auf einer einzelnen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#Section-Zoom).

## **Folien‑Zoom**

Ein Folien‑Zoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folien‑Zooms sind ideal für kurze Präsentationen ohne viele Abschnitte, können aber auch in verschiedenen Präsentationsszenarien eingesetzt werden. Folien‑Zooms helfen Ihnen, in mehrere Informationsstücke hinein zu zoomen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folien‑Zoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType) bereit, das Interface [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Zoom‑Frames erstellen**

Sie können einen Zoom‑Frame auf einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie dem ersten Folie Zoom‑Frames (die Referenzen zu den erstellten Folien enthalten) hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
``` java
Presentation pres = new Presentation();
try {
    //Fügt neue Folien zur Präsentation hinzu
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //Erstellt einen Hintergrund für die zweite Folie
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //Erstellt ein Textfeld für die zweite Folie
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Fügt ZoomFrame-Objekte hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Zoom‑Frames mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für Java können Sie einen Zoom‑Frame mit einem anderen Folien‑Vorschaubild folgendermaßen erstellen: 
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
5. Fügen Sie dem ersten Folie Zoom‑Frames (die Referenz zur erstellten Folie enthalten) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
``` java
Presentation pres = new Presentation();
try {
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //Erstellt einen Hintergrund für die zweite Folie
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //Erstellt ein Textfeld für die dritte Folie
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //Erstellt ein neues Bild für das Zoom-Objekt
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


### **Zoom‑Frames formatieren**

In den vorherigen Abschnitten haben wir gezeigt, wie Sie einfache Zoom‑Frames erstellen. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie den erstellten Folien einige Identifikationstexte und Hintergründe hinzu.
4. Fügen Sie dem ersten Folie Zoom‑Frames (die Referenzen zu den erstellten Folien enthalten) hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
6. Legen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt fest.
7. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8. Entfernen Sie den Hintergrund aus dem Bild des zweiten Zoom‑Frame‑Objekts.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie das Format eines Zoom‑Frames auf einer Folie ändern: 
``` java
Presentation pres = new Presentation();
try {
    //Fügt neue Folien zur Präsentation hinzu
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //Erstellt einen Hintergrund für die zweite Folie
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //Erstellt ein Textfeld für die zweite Folie
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Fügt ZoomFrame-Objekte hinzu
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //Erstellt ein neues Bild für das Zoom-Objekt
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
    zoomFrame1.setImage(picture);

    //Setzt ein Zoom-Frame-Format für das zoomFrame2-Objekt
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    //Einstellung zum Nicht-Anzeigen des Hintergrunds für das zoomFrame2-Objekt
    zoomFrame2.setShowBackground(false);

    //Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Abschnitts‑Zoom**

Ein Abschnitts‑Zoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnitts‑Zooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders betonen möchten. Oder Sie können sie nutzen, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnitts‑Zoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereit.

### **Abschnitts‑Zoom‑Frames erstellen**

Sie können einen Abschnitts‑Zoom‑Frame zu einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie der erstellten Folie einen Identifikation‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

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


### **Abschnitts‑Zoom‑Frames mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für Java können Sie einen Abschnitts‑Zoom‑Frame mit einem anderen Folien‑Vorschaubild folgendermaßen erstellen: 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikation‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
5. Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der eine Referenz zum erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

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


### **Abschnitts‑Zoom‑Frames formatieren**

Um komplexere Abschnitts‑Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitts‑Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnitts‑Zoom‑Frames auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikation‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6. Ändern Sie Größe und Position des erstellten Abschnitts‑Zoom‑Objekts.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
8. Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt fest.
9. Setzen Sie die *zurück zur ursprünglichen Folie aus dem verlinkten Abschnitt*‑Funktion.
10. Entfernen Sie den Hintergrund aus dem Bild des Abschnitts‑Zoom‑Frame‑Objekts.
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie das Format eines Abschnitts‑Zoom‑Frames ändern:
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

Ein Zusammenfassungs‑Zoom ist wie eine Startseite, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Vorführen können Sie den Zoom nutzen, um von einem Ort Ihrer Präsentation zu einem anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorrücken oder Teile Ihrer Diashow erneut ansehen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Summary‑Zoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) sowie einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereit.

### **Ein Summary‑Zoom erstellen**

Sie können einen Summary‑Zoom‑Frame zu einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien mit Identifikation‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie den Summary‑Zoom‑Frame zur ersten Folie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Summary‑Zoom‑Frame auf einer Folie erstellen:
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


### **Ein Summary‑Zoom‑Abschnitt hinzufügen und entfernen**

Alle Abschnitte in einem Summary‑Zoom‑Frame werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection)-Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection)-Objekt gespeichert sind. Sie können über das Interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) einen Summary‑Zoom‑Abschnitt hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien mit Identifikation‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Summary‑Zoom‑Frame in die erste Folie ein.
4. Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5. Fügen Sie den erstellten Abschnitt zum Summary‑Zoom‑Frame hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Summary‑Zoom‑Frame.
7. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie Abschnitte in einem Summary‑Zoom‑Frame hinzufügen und entfernen:
``` java
Presentation pres = new Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);

    // Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Fügt einen Abschnitt zum Summary Zoom hinzu
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Entfernt den Abschnitt aus dem Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Summary‑Zoom‑Abschnitte formatieren**

Um komplexere Summary‑Zoom‑Abschnitts‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Summary‑Zoom‑Abschnitts‑Objekt anwenden können. 

Sie können die Formatierung eines Summary‑Zoom‑Abschnitts‑Objekts in einem Summary‑Zoom‑Frame folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien mit Identifikation‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Summary‑Zoom‑Frame zur ersten Folie hinzu.
4. Holen Sie sich ein Summary‑Zoom‑Abschnitt‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
8. Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt fest.
9. Setzen Sie die *zurück zur ursprünglichen Folie aus dem verlinkten Abschnitt*‑Funktion. 
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie die Formatierung eines Summary‑Zoom‑Abschnitts‑Objekts ändern:
``` java
Presentation pres = new Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);

    // Fügt eine neue Folie zur Präsentation hinzu
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

**Kann ich die Rückkehr zur „Eltern‑“Folie nach dem Anzeigen des Ziels steuern?**

Ja. Der [Zoom‑frame](https://reference.aspose.com/slides/java/com.aspose.slides/zoomframe/) oder das [section](https://reference.aspose.com/slides/java/com.aspose.slides/sectionzoomframe/) hat ein `ReturnToParent`‑Verhalten, das, wenn aktiviert, die Zuschauer nach dem Besuch des Zielinhalts zur ursprünglichen Folie zurückführt.

**Kann ich die „Geschwindigkeit“ bzw. die Dauer des Zoom‑Übergangs anpassen?**

Ja. Beim Zoom kann die `TransitionDuration` gesetzt werden, sodass Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Beschränkungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt kein fest definiertes API‑Limit. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistungsfähigkeit des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.