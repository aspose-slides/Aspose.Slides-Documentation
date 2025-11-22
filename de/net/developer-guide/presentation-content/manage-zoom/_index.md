---
title: Zoom verwalten
type: docs
weight: 60
url: /de/net/manage-zoom/
keywords:
- Zoom
- Zoom-Frame
- Zoom hinzufügen
- Zoom-Frame formatieren
- Zusammenfassungs-Zoom
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Zoom oder Zoom-Frames zu PowerPoint-Präsentationen in C# oder .NET hinzufügen"
---

## **Übersicht**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Bereichen einer Präsentation zu springen und zurückzukehren. Beim Präsentieren kann diese Möglichkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#Section-Zoom).

## **Folien‑Zoom**
Ein Folien‑Zoom kann Ihre Präsentation dynamischer machen, da er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Ablauf zu unterbrechen. Folien‑Zooms eignen sich hervorragend für kurze Präsentationen ohne viele Abschnitte, können aber auch in anderen Szenarien eingesetzt werden.

Folien‑Zooms helfen Ihnen, mehrere Informationsstücke zu vertiefen, während Sie das Gefühl behalten, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folien‑Zoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), das Interface [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereit.

### **Erstellen von Zoom‑Frames**

Sie können einem Folien‑Zoom‑Frame wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifizierungstext und einen Hintergrund hinzu.
4. Fügen Sie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
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
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Erstellen von Zoom‑Frames mit benutzerdefinierten Bildern**
Mit Aspose.Slides für .NET können Sie einen Zoom‑Frame mit einem anderen Folienvorschau‑Bild wie folgt erstellen: 
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie der Folie einen Identifizierungstext und einen Hintergrund hinzu.
4. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Images‑Katalog des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts ein Bild hinzufügen, das den Frame füllen soll.
5. Fügen Sie Zoom‑Frames (die den Verweis auf die erstellte Folie enthalten) zur ersten Folie hinzu.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //Erstellt einen Hintergrund für die zweite Folie
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //Erstellt ein Textfeld für die dritte Folie
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //Erstellt ein neues Bild für das Zoom-Objekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Fügt das ZoomFrame-Objekt hinzu
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    //Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formatieren von Zoom‑Frames**
In den vorherigen Abschnitten haben wir gezeigt, wie man einfache Zoom‑Frames erstellt. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifizierungstext und einen Hintergrund hinzu.
4. Fügen Sie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Images‑Katalog des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts ein Bild hinzufügen, das den Frame füllen soll.
6. Legen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt fest.
7. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8. Entfernen Sie den Hintergrund aus dem Bild des zweiten Zoom‑Frame‑Objekts.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie die Formatierung eines Zoom‑Frames auf einer Folie ändern: 
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

    // Setzt ein Zoom-Frame-Format für das zoomFrame2-Objekt
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Einstellung zum Ausblenden des Hintergrunds für das zoomFrame2-Objekt
    zoomFrame2.ShowBackground = false;

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Abschnitts‑Zoom**

Ein Abschnitts‑Zoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnitts‑Zooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders betonen möchten. Oder Sie nutzen sie, um hervorzuheben, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnitts‑Zoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereit.

### **Erstellen von Abschnitts‑Zoom‑Frames**

Sie können einen Abschnitts‑Zoom‑Frame zu einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie der erstellten Folie einen Identifizierungs‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
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

Mit Aspose.Slides für .NET können Sie einen Abschnitts‑Zoom‑Frame mit einem anderen Folienvorschau‑Bild wie folgt erstellen: 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifizierungs‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Images‑Katalog des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts ein Bild hinzufügen, das den Frame füllen soll.
5. Fügen Sie einen Abschnitts‑Zoom‑Frame (der einen Verweis auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt neue Folie zur Präsentation hinzu
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

Um komplexere Abschnitts‑Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitts‑Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnitts‑Zoom‑Frames auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifizierungs‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Ändern Sie Größe und Position des erstellten Abschnitts‑Zoom‑Objekts.
7. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Images‑Katalog des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts ein Bild hinzufügen, das den Frame füllen soll.
8. Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt fest.
9. Aktivieren Sie die *Rückkehr zur Ausgangs‑Folientextur aus dem verknüpften Abschnitt*-Funktion.
10. Entfernen Sie den Hintergrund aus dem Bild des Abschnitts‑Zoom‑Frame‑Objekts.
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie die Formatierung eines Abschnitts‑Zoom‑Frames ändern:
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

    // Fügt SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formatierung für SectionZoomFrame
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

Ein Zusammenfassungs‑Zoom ist wie eine Startseite, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Präsentieren können Sie den Zoom nutzen, um von einem beliebigen Punkt Ihrer Präsentation zu einem anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorwärts springen oder Teile Ihrer Präsentation erneut besuchen, ohne den Ablauf zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungs‑Zoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) sowie einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereit.

### **Erstellen von Zusammenfassungs‑Zoom**

Sie können einen Zusammenfassungs‑Zoom‑Frame zu einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie neue Folien mit Identifizierungs‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie den Zusammenfassungs‑Zoom‑Frame zur ersten Folie hinzu.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zusammenfassungs‑Zoom‑Frame auf einer Folie erstellen:
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

Alle Abschnitte in einem Zusammenfassungs‑Zoom‑Frame werden durch [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)-Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)-Objekt gespeichert sind. Sie können einen Zusammenfassungs‑Zoom‑Abschnitt über das [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)-Interface wie folgt hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie neue Folien mit Identifizierungs‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungs‑Zoom‑Frame in die erste Folie ein.
4. Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5. Fügen Sie den erstellten Abschnitt dem Zusammenfassungs‑Zoom‑Frame hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungs‑Zoom‑Frame.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie Abschnitte in einem Zusammenfassungs‑Zoom‑Frame hinzufügen und entfernen:
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

Um komplexere Zusammenfassungs‑Zoom‑Abschnitts‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt anwenden können. 

Sie können die Formatierung eines Zusammenfassungs‑Zoom‑Abschnitts‑Objekts in einem Zusammenfassungs‑Zoom‑Frame wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erstellen Sie neue Folien mit Identifizierungs‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungs‑Zoom‑Frame zur ersten Folie hinzu.
4. Holen Sie sich ein Zusammenfassungs‑Zoom‑Abschnitts‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Images‑Katalog des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts ein Bild hinzufügen, das den Frame füllen soll.
8. Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt fest.
9. Aktivieren Sie die *Rückkehr zur Ausgangs‑Folientextur aus dem verknüpften Abschnitt*-Funktion. 
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie die Formatierung eines Zusammenfassungs‑Zoom‑Abschnitts‑Objekts ändern:
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

**Kann ich die Rückkehr zur übergeordneten Folie nach dem Anzeigen des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) bzw. das [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) verfügt über das Verhalten `ReturnToParent`, das, wenn aktiviert, den Betrachter nach dem Besuch des Zielinhalts zurück zur Ausgangs‑Folientextur führt.

**Kann ich die „Geschwindigkeit“ oder Dauer des Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Setzen einer `TransitionDuration`, sodass Sie die Dauer der Sprunganimation steuern können.

**Gibt es Beschränkungen, wie viele Zoom‑Objekte eine Präsentation enthalten darf?**

Es gibt keine fest dokumentierte API‑Grenze. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.