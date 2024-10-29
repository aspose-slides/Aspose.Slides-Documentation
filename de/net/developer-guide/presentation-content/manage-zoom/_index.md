---
title: Zoom verwalten
type: docs
weight: 60
url: /de/net/manage-zoom/
keywords: 
- zoom
- zoom rahmen
- zoom hinzufügen
- zoom rahmen formatieren
- zusammenfassungszoom
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Fügen Sie Zoom oder Zoomrahmen in PowerPoint-Präsentationen mit C# oder .NET hinzu"
---

## **Übersicht**
Zoomen in PowerPoint ermöglicht es Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen. Wenn Sie präsentieren, kann diese Fähigkeit, schnell durch den Inhalt zu navigieren, sehr nützlich sein.

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungszoom](#Zusammenfassungszoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folienspringen](#Folienspringen).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Abschnittszoom](#Abschnittszoom).

## **Folienspringen**
Ein Folienspringen kann Ihre Präsentation dynamischer gestalten, indem Sie zwischen Folien in beliebiger Reihenfolge navigieren können, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienspringen sind großartig für kurze Präsentationen ohne viele Abschnitte, aber Sie können sie auch in verschiedenen Präsentationsszenarien verwenden.

Folienspringen helfen Ihnen, in mehrere Informationsstücke einzutauchen, während Sie sich wie auf einer einzelnen Leinwand fühlen.

![overview_image](slidezoomsel.png)

Für Folienspringobjekte stellt Aspose.Slides die [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype) Aufzählung, die [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) Schnittstelle und einige Methoden in der [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) Schnittstelle zur Verfügung.

### **Zoomrahmen erstellen**

Sie können einen Zoomrahmen auf einer Folie auf folgende Weise hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoomrahmen verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie die Zoomrahmen (mit Verweisen auf die erstellten Folien) zur ersten Folie hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen Zoomrahmen auf einer Folie erstellen:

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
    autoshape.TextFrame.Text = "Zweite Folie";

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Dritte Folie";

    //Fügt ZoomFrame-Objekte hinzu
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Zoomrahmen mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides für .NET können Sie einen Zoomrahmen mit einem anderen Folienvorschau-Bild auf folgende Weise erstellen: 
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie eine neue Folie, zu der Sie den Zoomrahmen verlinken möchten. 
3. Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild in die mit der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt verbundene Bilderkollektion hinzufügen, das zum Füllen des Rahmens verwendet wird.
5. Fügen Sie die Zoomrahmen (mit dem Verweis auf die erstellte Folie) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen Zoomrahmen mit einem anderen Bild erstellen:

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
    autoshape.TextFrame.Text = "Zweite Folie";

    // Erstellt ein neues Bild für das Zoomobjekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Fügt das ZoomFrame-Objekt hinzu
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Zoomrahmen formatieren**
In den vorherigen Abschnitten zeigten wir Ihnen, wie man einfache Zoomrahmen erstellt. Um kompliziertere Zoomrahmen zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es stehen mehrere Formatierungsoptionen zur Verfügung, die Sie auf einen Zoomrahmen anwenden können. 

Sie können die Formatierung eines Zoomrahmens auf einer Folie auf folgende Weise steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie neue Folien, zu denen Sie den Zoomrahmen verlinken möchten. 
3. Fügen Sie den erstellten Folien einige Identifikationstexte und Hintergründe hinzu.
4. Fügen Sie die Zoomrahmen (mit Verweisen auf die erstellten Folien) zur ersten Folie hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild in die mit der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt verbundene Bilderkollektion hinzufügen, das zum Füllen des Rahmens verwendet wird.
6. Setzen Sie ein benutzerdefiniertes Bild für das erste Zoomrahmenobjekt.
7. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
8. Entfernen Sie den Hintergrund von einem Bild des zweiten Zoomrahmenobjekts.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie die Formatierung eines Zoomrahmens auf einer Folie ändern: 

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
    autoshape.TextFrame.Text = "Zweite Folie";

    // Erstellt einen Hintergrund für die dritte Folie
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Erstellt ein Textfeld für die dritte Folie
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Dritte Folie";

    //Fügt ZoomFrame-Objekte hinzu
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Erstellt ein neues Bild für das Zoomobjekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
    zoomFrame1.ZoomImage = ppImage;

    // Setzt eine Zoomrahmenformatierung für das zoomFrame2-Objekt
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Einstellung für den Hintergrund nicht anzeigen für das zoomFrame2-Objekt
    zoomFrame2.ShowBackground = false;

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnittszoooms verwenden, um zu den Abschnitten zurückzukehren, die Sie wirklich betonen möchten. Oder Sie können sie verwenden, um hervorzuheben, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![overview_image](seczoomsel.png)

Für Abschnittszoomobjekte stellt Aspose.Slides die [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) Schnittstelle und einige Methoden in der [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) Schnittstelle bereit.

### **Abschnittszoomrahmen erstellen**

Sie können einen Abschnittszoomrahmen auf einer Folie auf folgende Weise hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie dem erstellten Folien einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten. 
5. Fügen Sie einen Abschnittszoomrahmen (mit Verweisen auf den erstellten Abschnitt) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen Zoomrahmen auf einer Folie erstellen:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 1", slide);

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Abschnittszoomrahmen mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für .NET können Sie einen Abschnittszoomrahmen mit einem anderen Folienvorschau-Bild auf folgende Weise erstellen: 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie dem erstellten Folien einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten. 
5.  Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild in die Bilderkollektion einfügen, die mit dem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt verbunden ist, das zum Füllen des Rahmens verwendet wird.
5.  Fügen Sie einen Abschnittszoomrahmen (mit einem Verweis auf den erstellten Abschnitt) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen Zoomrahmen mit einem anderen Bild erstellen:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 1", slide);

    // Erstellt ein neues Bild für das Zoomobjekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Fügt ein SectionZoomFrame-Objekt hinzu
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Abschnittszoomrahmen formatieren**

Um kompliziertere Abschnittszoomrahmen zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es stehen mehrere Formatierungsoptionen zur Verfügung, die Sie auf einen Abschnittszoomrahmen anwenden können. 

Sie können die Formatierung eines Abschnittszoomrahmens auf einer Folie auf folgende Weise steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie dem erstellten Folien eine Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten. 
5. Fügen Sie einen Abschnittszoomrahmen (mit Verweisen auf den erstellten Abschnitt) zur ersten Folie hinzu.
6. Ändern Sie die Größe und Position des erstellten Abschnittszoomobjekts.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild in die mit dem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt verbundene Bilderkollektion hinzufügen, das zum Füllen des Rahmens verwendet wird.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoomrahmenobjekt.
9. Aktivieren Sie die Fähigkeit, *zur ursprünglichen Folie vom verlinkten Abschnitt zurückzukehren*. 
10. Entfernen Sie den Hintergrund von einem Bild des Abschnittszoomrahmenobjekts.
11. Ändern Sie die Linienformatierung des zweiten Zoomrahmenobjekts.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie die Formatierung eines Abschnittszoomrahmens ändern:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 1", slide);

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

Ein Zusammenfassungszoom ist wie eine Landingpage, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Wenn Sie präsentieren, können Sie den Zoom verwenden, um von einem Ort in Ihrer Präsentation zu einem anderen in beliebiger Reihenfolge zu gelangen. Sie können kreativ werden, überspringen oder Teile Ihrer Diashow wieder besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungszoomobjekte stellt Aspose.Slides die [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) Schnittstellen sowie einige Methoden in der [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) Schnittstelle zur Verfügung.

### **Zusammenfassungszoom erstellen**

Sie können einen Zusammenfassungszoomrahmen auf eine Folie auf folgende Weise hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie den Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen Zusammenfassungszoomrahmen auf einer Folie erstellen:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 2", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 3", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 4", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Zusammenfassungszoomabschnitt hinzufügen und entfernen**

Alle Abschnitte in einem Zusammenfassungszoomrahmen werden durch [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) Objekte dargestellt, die in dem [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) Objekt gespeichert sind. Sie können ein Zusammenfassungszoomabschnittobjekt über die [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) Schnittstelle auf folgende Weise hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungszoomrahmen in die erste Folie ein.
4. Fügen Sie eine neue Folie und einen Abschnitt zur Präsentation hinzu.
5. Fügen Sie den erstellten Abschnitt zum Zusammenfassungszoomrahmen hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungszoomrahmen.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie Abschnitte in einem Zusammenfassungszoomrahmen hinzufügen und entfernen:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    ISection section3 = pres.Sections.AddSection("Abschnitt 3", slide);

    // Fügt einen Abschnitt zum Zusammenfassungszoom hinzu
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Entfernt einen Abschnitt aus dem Zusammenfassungszoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Speichert die Präsentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Zusammenfassungszoomabschnitte formatieren**

Um kompliziertere Zusammenfassungszoomabschnittobjekte zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es stehen mehrere Formatierungsoptionen zur Verfügung, die Sie auf ein Zusammenfassungszoomabschnittobjekt anwenden können. 

Sie können die Formatierung für ein Zusammenfassungszoomabschnittobjekt in einem Zusammenfassungszoomrahmen auf folgende Weise steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4. Holen Sie sich ein Zusammenfassungszoomabschnittobjekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild in die Bilderkollektion einfügen, die mit dem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt verbunden ist, das zum Füllen des Rahmens verwendet wird.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoomrahmenobjekt.
9. Aktivieren Sie die Fähigkeit, *zur ursprünglichen Folie vom verlinkten Abschnitt zurückzukehren*. 
11. Ändern Sie die Linienformatierung des zweiten Zoomrahmenobjekts.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie die Formatierung für ein Zusammenfassungszoomabschnittobjekt ändern:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Fügt eine neue Folie zur Präsentation hinzu
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 1", slide);

    //Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.Sections.AddSection("Abschnitt 2", slide);

    // Fügt ein SummaryZoomFrame-Objekt hinzu
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Holt sich das erste SummaryZoomSection-Objekt
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formatierung für das SummaryZoomSection-Objekt
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