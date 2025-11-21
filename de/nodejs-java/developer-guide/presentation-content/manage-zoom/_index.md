---
title: Zoom verwalten
type: docs
weight: 60
url: /de/nodejs-java/manage-zoom/
keywords: "Zoom, Zoom-Frame, Zoom hinzufügen, Zoom-Frame formatieren, Zusammenfassungszoom, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Zooms oder Zoom-Frames zu PowerPoint-Präsentationen in JavaScript hinzufügen"
---

## **Übersicht**

Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen und von dort zurückzukehren. Beim Vortragen kann diese Möglichkeit, schnell durch den Inhalt zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#Section-Zoom).

## **Folienzoom**

Ein Folien‑Zoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Ablauf Ihrer Präsentation zu unterbrechen. Folien‑Zooms eignen sich hervorragend für kurze Präsentationen ohne viele Abschnitte, können jedoch auch in verschiedenen Präsentationsszenarien verwendet werden.

Folien‑Zooms helfen Ihnen, in mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folien‑Zoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomImageType) die Klasse [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomFrame) und einige Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereit.

### **Erstellen von Zoom‑Frames**

Sie können einen Zoom‑Frame auf einer Folie auf folgende Weise hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4.	Fügen Sie dem ersten Folie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) hinzu.
5.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt neue Folien zur Präsentation hinzu
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Erstellt einen Hintergrund für die zweite Folie
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Erstellt ein Textfeld für die zweite Folie
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Fügt ZoomFrame-Objekte hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Erstellen von Zoom‑Frames mit benutzerdefinierten Bildern**

Mit Aspose.Slides für Node.js über Java können Sie einen Zoom‑Frame mit einem anderen Folien‑Vorschaubild auf folgende Weise erstellen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3.	Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4.	Erstellen Sie ein [PPImage]-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation]-Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
5.	Fügen Sie dem ersten Folie Zoom‑Frames (die den Verweis auf die erstellte Folie enthalten) hinzu.
6.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Erstellt einen Hintergrund für die zweite Folie
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Erstellt ein Textfeld für die dritte Folie
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Erstellt ein neues Bild für das Zoom-Objekt
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Fügt das ZoomFrame-Objekt hinzu
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formatieren von Zoom‑Frames**

In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoom‑Frames erstellen. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames anpassen. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie auf folgende Weise steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verlinken möchten. 
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4.	Fügen Sie dem ersten Folie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) hinzu.
5.	Erstellen Sie ein [PPImage]-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation]-Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
6.	Legen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt fest.
7.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8.	Entfernen Sie den Hintergrund von einem Bild des zweiten Zoom‑Frame‑Objekts.
9.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt neue Folien zur Präsentation hinzu
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Erstellt einen Hintergrund für die zweite Folie
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Erstellt ein Textfeld für die zweite Folie
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Erstellt einen Hintergrund für die dritte Folie
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Fügt ZoomFrame-Objekte hinzu
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Erstellt ein neues Bild für das Zoom-Objekt
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
    zoomFrame1.setImage(picture);
    // Setzt ein Zoom-Frame-Format für das zoomFrame2-Objekt
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Einstellung: Hintergrund für das zoomFrame2-Objekt nicht anzeigen
    zoomFrame2.setShowBackground(false);
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Abschnitts‑Zoom**

Ein Abschnitts‑Zoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnitts‑Zooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders hervorheben möchten. Oder Sie können sie einsetzen, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnitts‑Zoom‑Objekte stellt Aspose.Slides die Klasse [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionZoomFrame) und einige Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereit.

### **Erstellen von Abschnitts‑Zoom‑Frames**

Sie können einen Abschnitts‑Zoom‑Frame auf einer Folie auf folgende Weise hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie eine neue Folie. 
3.	Fügen Sie dem erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);
    // Fügt ein SectionZoomFrame-Objekt hinzu
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Erstellen von Abschnitts‑Zoom‑Frames mit benutzerdefinierten Bildern**

Mit Aspose.Slides für Node.js über Java können Sie einen Abschnitts‑Zoom‑Frame mit einem anderen Folien‑Vorschaubild auf folgende Weise erstellen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie dem erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Erstellen Sie ein [PPImage]-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation]-Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
6.	Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der einen Verweis auf den erstellten Abschnitt enthält) hinzu.
7.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);
    // Erstellt ein neues Bild für das Zoom-Objekt
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Fügt SectionZoomFrame-Objekt hinzu
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formatieren von Abschnitts‑Zoom‑Frames**

Um komplexere Abschnitts‑Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames anpassen. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitts‑Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnitts‑Zoom‑Frames auf einer Folie auf folgende Weise steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie dem erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6.	Ändern Sie die Größe und Position des erstellten Abschnitts‑Zoom‑Objekts.
7.	Erstellen Sie ein [PPImage]-Objekt, indem Sie ein Bild zur Images‑Sammlung des zugehörigen [Presentation]-Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
8.	Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt fest.
9.	Aktivieren Sie die *Rückkehr zur Originalfolie aus dem verknüpften Abschnitt*-Funktion.
10.	Entfernen Sie den Hintergrund von einem Bild des Abschnitts‑Zoom‑Frame‑Objekts.
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);
    // Fügt SectionZoomFrame-Objekt hinzu
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Formatierung für SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zusammenfassungs‑Zoom**

Ein Zusammenfassungs‑Zoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation auf einmal angezeigt werden. Beim Vortragen können Sie den Zoom verwenden, um von einem Ort Ihrer Präsentation zu einem anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorspringen oder Teile Ihrer Bildsprache erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungs‑Zoom‑Objekte stellt Aspose.Slides die Klassen [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection) und [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) sowie einige Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereit.

### **Erstellen eines Zusammenfassungs‑Zooms**

Sie können einen Zusammenfassungs‑Zoom‑Frame auf einer Folie auf folgende Weise hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie dem ersten Folie den Zusammenfassungs‑Zoom‑Frame hinzu.
4.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);
    // Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 2", slide);
    // Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 3", slide);
    // Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 4", slide);
    // Fügt ein SummaryZoomFrame-Objekt hinzu
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Hinzufügen und Entfernen von Zusammenfassungs‑Zoom‑Abschnitten**

Alle Abschnitte in einem Zusammenfassungs‑Zoom‑Frame werden durch [SummaryZoomSection]-Objekte repräsentiert, die im [SummaryZoomSectionCollection]-Objekt gespeichert sind. Sie können über die Klasse [SummaryZoomSectionCollection] ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt hinzufügen oder entfernen, indem Sie folgendes tun:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie dem ersten Folie einen Zusammenfassungs‑Zoom‑Frame ein.
4.	Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5.	Fügen Sie den erstellten Abschnitt dem Zusammenfassungs‑Zoom‑Frame hinzu.
6.	Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungs‑Zoom‑Frame.
7.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);
    // Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 2", slide);
    // Fügt ein SummaryZoomFrame-Objekt hinzu
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Fügt einen Abschnitt zum Summary Zoom hinzu
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Entfernt Abschnitt aus dem Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formatieren von Zusammenfassungs‑Zoom‑Abschnitten**

Um komplexere Zusammenfassungs‑Zoom‑Abschnitts‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames anpassen. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zusammenfassungs‑Zoom‑Abschnitt anwenden können. 

Sie können die Formatierung eines Zusammenfassungs‑Zoom‑Abschnitts‑Objekts in einem Zusammenfassungs‑Zoom‑Frame auf folgende Weise steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie dem ersten Folie einen Zusammenfassungs‑Zoom‑Frame hinzu.
4.	Rufen Sie ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection` ab.
5.	Erstellen Sie ein [PPImage]-Objekt, indem Sie ein Bild zur images‑collection des zugehörigen [Presentation]-Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
6.	Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt fest.
7.	Aktivieren Sie die *Rückkehr zur Originalfolie aus dem verknüpften Abschnitt*-Funktion.
8.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
9.	Ändern Sie die Übergangsdauer.
10.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt eine neue Folie zur Präsentation hinzu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 1", slide);
    // Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.getSections().addSection("Section 2", slide);
    // Fügt ein SummaryZoomFrame-Objekt hinzu
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Ruft das erste SummaryZoomSection-Objekt ab
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Formatierung für SummaryZoomSection-Objekt
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Speichert die Präsentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich die Rückkehr zur übergeordneten Folie nach Anzeige des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) bzw. das [section](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) verfügt über die Methode `setReturnToParent`, die bei Aktivierung die Betrachter nach dem Aufrufen des Zielinhalts zur Ausgangsfolie zurückführt.

**Kann ich die 'Geschwindigkeit' oder Dauer des Zoom‑Übergangs anpassen?**

Ja. Zoom stellt eine Methode `setTransitionDuration` bereit, mit der Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Begrenzungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt kein fest dokumentiertes API‑Limit. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistungsfähigkeit des Betrachters ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.