---
title: Verwalten von Präsentations-Zoom in .NET
linktitle: Zoom verwalten
type: docs
weight: 60
url: /de/net/manage-zoom/
keywords:
- Zoom
- Zoom-Frame
- Folien-Zoom
- Abschnitts-Zoom
- Zusammenfassungs-Zoom
- Zoom hinzufügen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und Anpassen von Zoom mit Aspose.Slides für .NET — zwischen Abschnitten springen, Miniaturansichten und Transitionen in PPT-, PPTX- und ODP-Präsentationen hinzufügen."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Bereichen einer Präsentation zu springen und von dort zurück. Wenn Sie präsentieren, kann diese Möglichkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungs‑Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folien‑Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Abschnitts‑Zoom](#Section-Zoom).

## **Folien‑Zoom**
Ein Folien‑Zoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei in beliebiger Reihenfolge zwischen Folien zu navigieren, ohne den Ablauf Ihrer Präsentation zu unterbrechen. Folien‑Zooms eignen sich hervorragend für kurze Präsentationen ohne viele Abschnitte, können aber auch in anderen Präsentationsszenarien verwendet werden. 

Folien‑Zooms helfen Ihnen, in mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folien‑Zoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype) bereit, das Interface [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Erstellen von Zoom‑Frames**
Sie können einen Zoom‑Frame auf einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifikationstext und Hintergrund hinzu.
4. Fügen Sie dem ersten Folie Zoom‑Frames (die Referenzen zu den erstellten Folien enthalten) hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    // Fügt neue Folien zur Präsentation hinzu
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Erstellt einen Hintergrund für die zweite Folie
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Erstellt ein Textfeld für die zweite Folie
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    // Fügt ZoomFrame-Objekte hinzu
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Erstellen von Zoom‑Frames mit benutzerdefinierten Bildern**
Mit Aspose.Slides für .NET können Sie einen Zoom‑Frame mit einem anderen Folien‑Vorschaubild folgendermaßen erstellen: 
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie der Folie einen Identifikationstext und Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
5. Fügen Sie dem ersten Folie Zoom‑Frames (die Referenz zur erstellten Folie enthalten) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Erstellt einen Hintergrund für die zweite Folie
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Erstellt ein Textfeld für die dritte Folie
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Erstellt ein neues Bild für das Zoom-Objekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Fügt das ZoomFrame-Objekt hinzu
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formatieren von Zoom‑Frames**
In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoom‑Frames erstellen. Um komplexere Zoom‑Frames zu erstellen, müssen Sie das Format eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können das Format eines Zoom‑Frames auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie den erstellten Folien etwas Identifikationstext und Hintergrund hinzu.
4. Fügen Sie dem ersten Folie Zoom‑Frames (die Referenzen zu den erstellten Folien enthalten) hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
6. Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt.
7. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8. Entfernen Sie den Hintergrund eines Bildes des zweiten Zoom‑Frame‑Objekts.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt neue Folien zur Präsentation hinzu
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Erstellt einen Hintergrund für die zweite Folie
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Erstellt ein Textfeld für die zweite Folie
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Fügt ZoomFrame-Objekte hinzu
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Erstellt ein neues Bild für das Zoom-Objekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
    zoomFrame1.ZoomImage = ppImage;

    // Setzt ein Zoomframe-Format für das zoomFrame2-Objekt
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Einstellung: Hintergrund für zoomFrame2-Objekt nicht anzeigen
    zoomFrame2.ShowBackground = false;

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Abschnitts‑Zoom**
Ein Abschnitts‑Zoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnitts‑Zooms verwenden, um zurück zu Abschnitten zu springen, die Sie besonders betonen möchten. Oder Sie können sie nutzen, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnitts‑Zoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereit.

### **Erstellen von Abschnitts‑Zoom‑Frames**
Sie können einen Abschnitts‑Zoom‑Frame auf einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Erstellen von Abschnitts‑Zoom‑Frames mit benutzerdefinierten Bildern**
Mit Aspose.Slides für .NET können Sie einen Abschnitts‑Zoom‑Frame mit einem anderen Folien‑Vorschaubild folgendermaßen erstellen: 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
5. Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der Referenz zum erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 1", slide);

    // Erstellt ein neues Bild für das Zoom-Objekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Fügt SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formatieren von Abschnitts‑Zoom‑Frames**
Um komplexere Abschnitts‑Zoom‑Frames zu erstellen, müssen Sie das Format eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitts‑Zoom‑Frame anwenden können. 

Sie können das Format eines Abschnitts‑Zoom‑Frames auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie dem ersten Folie einen Abschnitts‑Zoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6. Ändern Sie Größe und Position des erstellten Abschnitts‑Zoom‑Objekts.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.
9. Setzen Sie die *Zurückkehren‑zur‑ursprünglichen‑Folie‑vom‑verlinkten‑Abschnitt*-Fähigkeit. 
10. Entfernen Sie den Hintergrund eines Bildes des Abschnitts‑Zoom‑Frame‑Objekts.
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 1", slide);

    // Add SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formatting for SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Zusammenfassungs‑Zoom**
Ein Zusammenfassungs‑Zoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Wenn Sie präsentieren, können Sie den Zoom nutzen, um von einer Stelle Ihrer Präsentation zu einer anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorausblättern oder Teile Ihrer Slideshow erneut ansehen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungs‑Zoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) sowie einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereit.

### **Erstellen von Zusammenfassungs‑Zoom**
Sie können einen Zusammenfassungs‑Zoom‑Frame auf einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Folie den Zusammenfassungs‑Zoom‑Frame hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 2", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 3", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 4", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Hinzufügen und Entfernen von Zusammenfassungs‑Zoom‑Abschnitten**
Alle Abschnitte in einem Zusammenfassungs‑Zoom‑Frame werden durch [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)-Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)-Objekt gespeichert sind. Sie können ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt über das [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)-Interface folgendermaßen hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Folie einen Zusammenfassungs‑Zoom‑Frame hinzu.
4. Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5. Fügen Sie den erstellten Abschnitt dem Zusammenfassungs‑Zoom‑Frame hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungs‑Zoom‑Frame.
7. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 2", slide);

    // Fügt SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Fügt einen Abschnitt zum Summary Zoom hinzu
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Entfernt Abschnitt aus dem Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Formatieren von Zusammenfassungs‑Zoom‑Abschnitten**
Um komplexere Zusammenfassungs‑Zoom‑Abschnitts‑Objekte zu erstellen, müssen Sie das Format eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt anwenden können. 

Sie können das Format eines Zusammenfassungs‑Zoom‑Abschnitts‑Objekts in einem Zusammenfassungs‑Zoom‑Frame folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Folie einen Zusammenfassungs‑Zoom‑Frame hinzu.
4. Holen Sie sich ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur images‑Collection des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.
9. Setzen Sie die *Zurückkehren‑zur‑ursprünglichen‑Folie‑vom‑verlinkten‑Abschnitt*-Fähigkeit. 
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Section 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Holt das erste SummaryZoomSection-Objekt
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formatierung für SummaryZoomSection-Objekt
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich die Rückkehr zur übergeordneten Folie nach Anzeige des Ziels steuern?**

Ja. Der [Zoom‑frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) bzw. das [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) verfügt über ein `ReturnToParent`‑Verhalten, das bei Aktivierung die Betrachter nach dem Besuch des Zielinhalts zur Ausgangsfolie zurückführt.

**Kann ich die 'Geschwindigkeit' oder Dauer der Zoom‑Transition anpassen?**

Ja. Zoom unterstützt das Setzen einer `TransitionDuration`, sodass Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Begrenzungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt keine dokumentierte harte API‑Grenze. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.