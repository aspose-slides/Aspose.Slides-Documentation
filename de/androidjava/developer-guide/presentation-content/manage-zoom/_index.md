---
title: Präsentations-Zoom auf Android verwalten
linktitle: Zoom verwalten
type: docs
weight: 60
url: /de/androidjava/manage-zoom/
keywords:
- Zoom
- Zoom-Frame
- Folienzoom
- Abschnittszoom
- Zusammenfassungszoom
- Zoom hinzufügen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen und anpassen von Zoom mit Aspose.Slides für Android via Java — springen Sie zwischen Abschnitten, fügen Sie Miniaturansichten und Übergänge in PPT-, PPTX- und ODP-Präsentationen hinzu."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Bereichen einer Präsentation zu springen und von dort zurückzukehren. Beim Präsentieren kann diese Fähigkeit, schnell durch den Inhalt zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#Section-Zoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer machen, indem er Ihnen ermöglicht, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms eignen sich hervorragend für kurze Präsentationen ohne viele Abschnitte, können aber dennoch in verschiedenen Präsentationsszenarien verwendet werden.

Folienzooms helfen Ihnen, in mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folienzoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType), das Interface [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereit.

### **Zoom‑Frames erstellen**

Sie können einem Folienzoom‑Frame wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifizierungstext und einen Hintergrund hinzu.
4. Fügen Sie dem ersten Folie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

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

### **Zoom‑Frames mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides für Android via Java können Sie einen Zoom‑Frame mit einem anderen Folien‑Vorschaubild wie folgt erstellen:
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie der Folie einen Identifizierungstext und einen Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Objekts hinzufügen, das den Frame füllen soll.
5. Fügen Sie dem ersten Folie Zoom‑Frames (die den Verweis auf die erstellte Folie enthalten) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` java
Presentation pres = new Presentation();
try {
    //Fügt der Präsentation eine neue Folie hinzu
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
    // Fügt das ZoomFrame-Objekt hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Zoom‑Frames formatieren**
In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie einfache Zoom‑Frames erstellt werden. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie den erstellten Folien etwas Identifizierungstext und einen Hintergrund hinzu.
4. Fügen Sie dem ersten Folie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Objekts hinzufügen, das den Frame füllen soll.
6. Legen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt fest.
7. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8. Entfernen Sie den Hintergrund von einem Bild des zweiten Zoom‑Frame‑Objekts.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

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

    // Einstellung zum Ausblenden des Hintergrunds für das zoomFrame2-Objekt
    zoomFrame2.setShowBackground(false);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders hervorheben möchten. Oder Sie können sie nutzen, um zu zeigen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnittszoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereit.

### **Abschnittszoom‑Frames erstellen**

Sie können einem Abschnittszoom‑Frame auf einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie dem erstellten Folie einen Identifizierungshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie dem ersten Folie einen Abschnittszoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` java
Presentation pres = new Presentation();
try {
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.getSections().addSection("Section 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Abschnittszoom‑Frames mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für Android via Java können Sie einen Abschnittszoom‑Frame mit einem anderen Folien‑Vorschaubild wie folgt erstellen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie eine neue Folie.
3. Fügen Sie dem erstellten Folie einen Identifizierungshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Objekts hinzufügen, das den Frame füllen soll.
5. Fügen Sie dem ersten Folie einen Abschnittszoom‑Frame (der einen Verweis auf den erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` java 
Presentation pres = new Presentation();
try {
    // Fügt neue Folie zur Präsentation hinzu
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

### **Abschnittszoom‑Frames formatieren**

Um komplexere Abschnittszoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnittszoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnittszoom‑Frames auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie eine neue Folie.
3. Fügen Sie dem erstellten Folie einen Identifizierungshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie dem ersten Folie einen Abschnittszoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6. Ändern Sie Größe und Position des erstellten Abschnittszoom‑Objekts.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Objekts hinzufügen, das den Frame füllen soll.
8. Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoom‑Frame‑Objekt fest.
9. Aktivieren Sie die *Rückkehr zur ursprünglichen Folie aus dem verlinkten Abschnitt*‑Funktion.
10. Entfernen Sie den Hintergrund von einem Bild des Abschnittszoom‑Frame‑Objekts.
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` java
Presentation pres = new Presentation();
try {
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
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



## **Zusammenfassungszoom**

Ein Zusammenfassungszoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Präsentieren können Sie den Zoom verwenden, um von einer Stelle Ihrer Präsentation zu einer anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorspringen oder Teile Ihrer Diashow erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungszoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) sowie einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereit.

### **Zusammenfassungszoom erstellen**

Sie können einen Zusammenfassungszoom‑Frame auf einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Folie den Zusammenfassungszoom‑Frame hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` java 
Presentation pres = new Presentation();
try {
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.getSections().addSection("Section 1", slide);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.getSections().addSection("Section 2", slide);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.getSections().addSection("Section 3", slide);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.getSections().addSection("Section 4", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Zusammenfassungszoom‑Abschnitt hinzufügen und entfernen**

Alle Abschnitte in einem Zusammenfassungszoom‑Frame werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)-Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)-Objekt gespeichert sind. Sie können einen Zusammenfassungszoom‑Abschnitt über das Interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) wie folgt hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Folie einen Zusammenfassungszoom‑Frame hinzu.
4. Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5. Fügen Sie den erstellten Abschnitt zum Zusammenfassungszoom‑Frame hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungszoom‑Frame.
7. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` java
Presentation pres = new Presentation();
try {
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.getSections().addSection("Section 1", slide);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.getSections().addSection("Section 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Fügt einen Abschnitt zum Summary Zoom hinzu
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Entfernt Abschnitt aus dem Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Speichert die Präsentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Zusammenfassungszoom‑Abschnitte formatieren**

Um komplexere Zusammenfassungszoom‑Abschnittsobjekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungszoom‑Abschnittsobjekt anwenden können. 

Sie können die Formatierung eines Zusammenfassungszoom‑Abschnittsobjekts in einem Zusammenfassungszoom‑Frame wie folgt steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Folie einen Zusammenfassungszoom‑Frame hinzu.
4. Holen Sie ein Zusammenfassungszoom‑Abschnittsobjekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Objekts hinzufügen, das den Frame füllen soll.
8. Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoom‑Frame‑Objekt fest.
9. Aktivieren Sie die *Rückkehr zur ursprünglichen Folie aus dem verlinkten Abschnitt*‑Funktion. 
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` java
Presentation pres = new Presentation();
try {
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.getSections().addSection("Section 1", slide);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Fügt der Präsentation einen neuen Abschnitt hinzu
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

**Kann ich die Rückkehr zur übergeordneten Folie nach dem Anzeigen des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zoomframe/) oder das [section](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sectionzoomframe/) hat ein Rückkehr‑zum‑Parent‑Verhalten, das, wenn es aktiviert ist, die Betrachter nach dem Besuch des Zielinhalts zurück zur Ausgangsfolie führt.

**Kann ich die „Geschwindigkeit“ oder Dauer des Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Festlegen einer Übergangsdauer, sodass Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Begrenzungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt keine fest dokumentierte harte API‑Grenze. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.