---
title: Präsentationszoom in .NET verwalten
linktitle: Zoom verwalten
type: docs
weight: 60
url: /de/net/manage-zoom/
keywords:
- Zoom
- Zoom-Frame
- Folienzoom
- Abschnittszoom
- Zusammenfassungszoom
- Zoom hinzufügen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und Anpassen von Zoom mit Aspose.Slides für .NET - zwischen Abschnitten springen, Miniaturbilder und Übergänge in PPT-, PPTX- und ODP-Präsentationen hinzufügen."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen und zurückzukehren. Während Sie präsentieren, kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](overview.png)

* Um die gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungszoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folienzoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Abschnittszoom](#Section-Zoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Ablauf Ihrer Präsentation zu unterbrechen. Folienzooms eignen sich hervorragend für kurze Präsentationen ohne viele Abschnitte, können aber auch in verschiedenen Präsentationsszenarien eingesetzt werden.

Folienzooms helfen Ihnen, mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folienzoom-Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), das Interface [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereit.

### **Zoom‑Frames erstellen**

Sie können einem Folien‑Zoom‑Frame wie folgt hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verknüpfen möchten. 
3.	Fügen Sie den erstellten Folien einen Identifizierungstext und einen Hintergrund hinzu.
4.	Fügen Sie dem ersten Folien‑Slide Zoom‑Frames (die die Referenzen zu den erstellten Folien enthalten) hinzu.
5.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

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

### **Zoom‑Frames mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides für .NET können Sie einen Zoom‑Frame mit einem anderen Folien‑Vorschaubild wie folgt erstellen: 
1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verknüpfen möchten. 
3.	Fügen Sie der Folie einen Identifizierungstext und einen Hintergrund hinzu.
4.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Image‑Sammlung der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Instanz ein Bild hinzufügen, das zum Füllen des Frames verwendet wird.
5.	Fügen Sie dem ersten Folien‑Slide Zoom‑Frames (die die Referenz zur erstellten Folie enthalten) hinzu.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt der Präsentation eine neue Folie hinzu
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

### **Zoom‑Frames formatieren**
In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoom‑Frames erstellen. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames anpassen. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie wie folgt steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verknüpfen möchten. 
3.	Fügen Sie den erstellten Folien einen Identifizierungstext und einen Hintergrund hinzu.
4.	Fügen Sie dem ersten Folien‑Slide Zoom‑Frames (die die Referenzen zu den erstellten Folien enthalten) hinzu.
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Image‑Sammlung der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Instanz ein Bild hinzufügen, das zum Füllen des Frames verwendet wird.
6.	Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt.
7.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8.	Entfernen Sie den Hintergrund von einem Bild des zweiten Zoom‑Frame‑Objekts.
5.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

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

    // Einstellung: Hintergrund für zoomFrame2-Objekt nicht anzeigen
    zoomFrame2.ShowBackground = false;

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders hervorheben möchten. Oder Sie nutzen sie, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnittszoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereit.

### **Abschnitts‑Zoom‑Frames erstellen**

Sie können einen Abschnitts‑Zoom‑Frame zu einer Folie wie folgt hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie eine neue Folie. 
3.	Fügen Sie der erstellten Folie einen Identifizierungshintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verknüpfen möchten. 
5.	Fügen Sie dem ersten Folien‑Slide einen Abschnitts‑Zoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Abschnitts‑Zoom‑Frames mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für .NET können Sie einen Abschnitts‑Zoom‑Frame mit einem anderen Folien‑Vorschaubild wie folgt erstellen: 

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie der erstellten Folie einen Identifizierungshintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verknüpfen möchten. 
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Image‑Sammlung der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Instanz ein Bild hinzufügen, das zum Füllen des Frames verwendet wird.
5.	Fügen Sie dem ersten Folien‑Slide einen Abschnitts‑Zoom‑Frame (der eine Referenz zum erstellten Abschnitt enthält) hinzu.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
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

### **Abschnitts‑Zoom‑Frames formatieren**

Um komplexere Abschnitts‑Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames anpassen. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitts‑Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnitts‑Zoom‑Frames auf einer Folie wie folgt steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie der erstellten Folie einen Identifizierungshintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verknüpfen möchten. 
5.	Fügen Sie dem ersten Folien‑Slide einen Abschnitts‑Zoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6.	Ändern Sie Größe und Position des erstellten Abschnitts‑Zoom‑Objekts.
7.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Image‑Sammlung der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Instanz ein Bild hinzufügen, das zum Füllen des Frames verwendet wird.
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.
9.	Aktivieren Sie die *Rückkehr zur ursprünglichen Folie aus dem verknüpften Abschnitt*‑Funktion.
10.	Entfernen Sie den Hintergrund von einem Bild des Abschnitts‑Zoom‑Frame‑Objekts.
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie die Formatierung eines Abschnitts‑Zoom‑Frames ändern:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
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



## **Zusammenfassungszoom**

Ein Zusammenfassungszoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Präsentieren können Sie den Zoom nutzen, um von einer Stelle der Präsentation zu einer anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorspringen oder Teile Ihrer Vorführung erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungszoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) sowie einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereit.

### **Ein Zusammenfassungszoom erstellen**

Sie können einen Zusammenfassungszoom‑Frame zu einer Folie wie folgt hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie den Zusammenfassungszoom‑Frame der ersten Folie hinzu.
4.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Zusammenfassungszoom‑Frame auf einer Folie erstellen:
``` csharp 
using (Presentation pres = new Presentation())
{
    // Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 1", slide);

    // Fügt der Präsentation eine neue Folie hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 2", slide);

    // Fügt der Präsentation eine neue Folie hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 3", slide);

    // Fügt der Präsentation eine neue Folie hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 4", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Eine Zusammenfassungszoom‑Sektion hinzufügen und entfernen**

Alle Sektionen in einem Zusammenfassungszoom‑Frame werden durch [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)-Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)-Objekt gespeichert sind. Sie können über das Interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) Sektionen hinzufügen oder entfernen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie einen Zusammenfassungszoom‑Frame in die erste Folie ein.
4.	Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5.	Fügen Sie den erstellten Abschnitt dem Zusammenfassungszoom‑Frame hinzu.
6.	Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungszoom‑Frame.
7.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie Sektionen in einem Zusammenfassungszoom‑Frame hinzufügen und entfernen:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 1", slide);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 2", slide);

    // Fügt SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Fügt einen Abschnitt zum Summary Zoom hinzu
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Entfernt einen Abschnitt aus dem Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Zusammenfassungszoom‑Sektionen formatieren**

Um komplexere Zusammenfassungszoom‑Sektionen zu erstellen, müssen Sie die Formatierung eines einfachen Frames anpassen. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungszoom‑Sektion‑Objekt anwenden können. 

Sie können die Formatierung eines Zusammenfassungszoom‑Sektion‑Objekts in einem Zusammenfassungszoom‑Frame wie folgt steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Erstellen Sie neue Folien mit Identifizierungshintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie einen Zusammenfassungszoom‑Frame zur ersten Folie hinzu.
4.	Holen Sie sich ein Zusammenfassungszoom‑Sektion‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie dem Bildsammlung der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Instanz ein Bild hinzufügen, das zum Füllen des Frames verwendet wird.
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.
9.	Aktivieren Sie die *Rückkehr zur ursprünglichen Folie aus dem verknüpften Abschnitt*‑Funktion. 
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie die Formatierung eines Zusammenfassungszoom‑Sektion‑Objekts ändern:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt der Präsentation eine neue Folie hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.Sections.AddSection("Section 1", slide);

    //Fügt der Präsentation eine neue Folie hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt der Präsentation einen neuen Abschnitt hinzu
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

**Kann ich das Zurückkehren zur „Eltern‑“Folie nach Anzeige des Ziels steuern?**

Ja. Der [Zoom‑frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) oder das [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) verfügt über das `ReturnToParent`‑Verhalten, das, wenn aktiviert, die Betrachter nach dem Besuch des Zielinhalts zurück zur Ausgangs‑Folie führt.

**Kann ich die „Geschwindigkeit“ bzw. die Dauer der Zoom‑Übergangsanimation anpassen?**

Ja. Zoom unterstützt das Setzen einer `TransitionDuration`, mit der Sie die Länge der Sprunganimation steuern können.

**Gibt es Begrenzungen, wie viele Zoom‑Objekte eine Präsentation enthalten darf?**

Es gibt keine fest dokumentierte API‑Obergrenze. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistungsfähigkeit des Betrachters ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.