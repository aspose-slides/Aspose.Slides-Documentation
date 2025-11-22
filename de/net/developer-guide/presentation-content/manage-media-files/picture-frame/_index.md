---
title: Bildrahmen
type: docs
weight: 10
url: /de/net/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Bild zuschneiden
- StretchOff-Eigenschaft
- Bildrahmen-Formatierung
- Bildrahmen-Eigenschaften
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Fügen Sie einen Bildrahmen zu einer PowerPoint-Präsentation in C# oder .NET hinzu"
---

Ein Bildrahmen ist eine Form, die ein Bild enthält — es ist wie ein Bild in einem Rahmen.  

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="primary" %}} 

Aspose bietet kostenlose Konverter —[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

## **Picture Frame erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie über ihren Index.  
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) basierend auf Breite und Höhe des Bildes über die `AddPictureFrame`‑Methode, die vom Form‑Objekt der referenzierten Folie bereitgestellt wird.  
6. Fügen Sie den Bildrahmen (mit dem Bild) der Folie hinzu.  
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Bildrahmen erstellen:
```c#
    // Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
    using (Presentation pres = new Presentation())
    {
        // Holt die erste Folie
        ISlide slide = pres.Slides[0];

        // Lädt ein Bild und fügt es der Bildersammlung der Präsentation hinzu
        IImage image = Images.FromFile("aspose-logo.jpg");
        IPPImage ppImage = pres.Images.AddImage(image);
        image.Dispose();

        // Fügt einen Bildrahmen mit gleicher Höhe und Breite hinzu
        IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

        // Wendet einige Formatierungen auf den Bildrahmen an
        pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
        pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
        pictureFrame.LineFormat.Width = 20;
        pictureFrame.Rotation = 45;

        // Schreibt die Präsentation in eine PPTX-Datei
        pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
    }
```


{{% alert color="warning" %}} 

Bildrahmen ermöglichen das schnelle Erstellen von Präsentationsfolien basierend auf Bildern. Kombiniert man Bildrahmen mit den Speicheroptionen von Aspose.Slides, kann man Ein‑ und Ausgabevorgänge manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Weitere Seiten: konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); konvertieren Sie [JPG zu Bild](https://products.aspose.com/slides/net/conversion/jpg-to-image/); konvertieren Sie [JPG zu PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), konvertieren Sie [PNG zu JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); konvertieren Sie [PNG zu SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), konvertieren Sie [SVG zu PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erzeugen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie über ihren Index.  
3. Fügen Sie der Bildersammlung der Präsentation ein Bild hinzu.  
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.  
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:
```c#
 // Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
 using (Presentation presentation = new Presentation())
 {
     // Lädt ein Bild und fügt es der Bildersammlung der Präsentation hinzu
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();

     // Fügt einen Bildrahmen zur Folie hinzu
     IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

     // Setzt die relative Skalierungsbreite und -höhe
     pictureFrame.RelativeScaleHeight = 0.8f;
     pictureFrame.RelativeScaleWidth = 1.35f;

     // Speichert die Präsentation
     presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
 }
```


## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe)‑Objekten extrahieren und in PNG, JPG und anderen Formaten speichern. Das folgende Codebeispiel demonstriert, wie ein Bild aus der Datei „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.
```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```


## **SVG‑Bilder aus Bildrahmen extrahieren**

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)‑Formen platziert sind, ermöglicht Aspose.Slides für .NET das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung der Folie können Sie jede [PictureFrame]‑Instanz identifizieren, prüfen, ob das zugrunde liegende [IPPImage]‑Objekt SVG‑Inhalt enthält, und das Bild dann im nativen SVG‑Format auf Datenträger oder in einen Stream speichern.

Der folgende Code demonstriert das Extrahieren eines SVG‑Bildes aus einem Bildrahmen:
```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```


## **Transparenz eines Bildes ermitteln**

Aspose.Slides ermöglicht das Ermitteln des auf ein Bild angewendeten Transparenzeffekts. Dieser C#‑Code demonstriert den Vorgang:
```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```


{{% alert color="primary" %}} 
Alle auf Bilder angewendeten Effekte finden Sie in [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/). 
{{% /alert %}}

## **Bildrahmen formatieren**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen so anpassen, dass er bestimmten Anforderungen entspricht.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‑Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie über ihren Index.  
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erstellen Sie ein `PictureFrame` basierend auf Breite und Höhe des Bildes über die [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe)‑Methode, die vom [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection)‑Objekt der referenzierten Folie bereitgestellt wird.  
6. Fügen Sie den Bildrahmen (mit dem Bild) der Folie hinzu.  
7. Setzen Sie die Linienfarbe des Bildrahmens.  
8. Setzen Sie die Linienbreite des Bildrahmens.  
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.  
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.  
10. Fügen Sie den Bildrahmen (mit dem Bild) erneut der Folie hinzu.  
11. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert den Formatierungsprozess für Bildrahmen:
```c#
// Instanziert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
using (Presentation presentation = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = presentation.Slides[0];

    // Lädt ein Bild und fügt es der Bildersammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bildrahmen mit derselben Höhe und Breite des Bildes hinzu
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Wendet einige Formatierungen auf den Bildrahmen an
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Schreibt die Präsentation in eine PPTX-Datei
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie JPG/JPEG‑ oder PNG‑Bilder zusammenführen oder Raster aus Fotos zu Gittern erstellen möchten, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Bild als Link hinzufügen**

Um die Dateigröße von Präsentationen zu reduzieren, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Dieser C#‑Code zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:
```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Bild zuschneiden**

Dieser C#‑Code zeigt, wie ein vorhandenes Bild auf einer Folie zugeschnitten wird:
```c#
using (Presentation presentation = new Presentation())
{
    // Erstellt ein neues Bildobjekt
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bildrahmen zu einer Folie hinzu
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Zuschneiden des Bildes (Prozentwerte)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Speichert das Ergebnis
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```


## **Zugespitzte Bildbereiche eines Bildrahmens löschen**

Wenn Sie die zugeschnittenen Bereiche eines Bildes in einem Rahmen entfernen möchten, können Sie die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Originalbild zurück, wenn kein Zuschneiden erforderlich ist.

Dieser C#‑Code demonstriert den Vorgang:
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt den Bildrahmen von der ersten Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Löscht zugeschnittene Bereiche des Bildrahmen-Bildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="NOTE" color="warning" %}} 

Die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) fügt das zugeschnittene Bild der Bildersammlung der Präsentation hinzu. Wird das Bild ausschließlich im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) verwendet, kann diese Einstellung die Dateigröße der Präsentation verringern. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Die Methode konvertiert WMF/EMF‑Metadateien während des Zuschneidens in ein Raster‑PNG‑Bild. 

{{% /alert %}}

## **Bild komprimieren**

Sie können ein Bild in einer Präsentation mit der Methode [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/) komprimieren.  
Diese Methode reduziert die Bildgröße anhand der Formgröße und der angegebenen Auflösung, optional mit dem Löschen zugeschnittener Bereiche.  

Sie passt Größe und Auflösung des Bildes ähnlich der PowerPoint‑Funktion **Bild formatieren → Bilder komprimieren → Auflösung** an.

Die folgenden C#‑Beispiele zeigen, wie Sie ein Bild in einer Präsentation komprimieren, indem Sie eine Zielauflösung angeben und optional zugeschnittene Bereiche entfernen:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt den Bildrahmen von der Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimiert das Bild mit Zielauflösung von 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Prüft das Ergebnis der Komprimierung
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }
}
```


Oder indem Sie direkt einen benutzerdefinierten DPI‑Wert verwenden:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Bild auf 150 DPI komprimieren (Web-Auflösung), zugeschnittene Bereiche entfernen
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 

Die Methode konvertiert das Bild in eine niedrigere Auflösung, basierend auf der Formgröße und dem angegebenen DPI. Geschnittene Bereiche können ebenfalls gelöscht werden, um die Dateigröße zu optimieren.  
Bei Metadateien (WMF/EMF) oder SVG wird keine Komprimierung angewendet. Außerdem wird die JPEG‑Qualität je nach Auflösung erhalten bzw. leicht reduziert, analog zu PowerPoint. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Eigenschaft [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) verwenden, um die Einstellung *Seitenverhältnis sperren* zu setzen. 

Dieser C#‑Code zeigt, wie Sie das Seitenverhältnis einer Form sperren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Setzt die Form, um das Seitenverhältnis beim Ändern der Größe beizubehalten
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="NOTE" color="warning" %}} 

Die Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des darin enthaltenen Bildes. 

{{% /alert %}}

## **StretchOff‑Eigenschaft verwenden**

Mit den Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) und [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) aus dem Interface [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) können Sie ein Füllrechteck angeben. 

Wird für ein Bild ein Stretch‑Modus festgelegt, wird ein Quellrechteck skaliert, um in das definierte Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Offset zur entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz steht für eine Einziehung, ein negativer Prozentsatz für eine Ausdehnung.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‑Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie über ihren Index.  
3. Fügen Sie ein Rechteck `AutoShape` hinzu.  
4. Erstellen Sie ein Bild.  
5. Setzen Sie den Fülltyp der Form.  
6. Setzen Sie den Bildfüllmodus der Form.  
7. Fügen Sie das Bild hinzu, um die Form zu füllen.  
8. Geben Sie Bild‑Offsets relativ zu den entsprechenden Kanten der Begrenzungsbox der Form an.  
9. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.  

Dieser C#‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Setzt das Bild von jeder Seite im Shape‑Körper gestreckt
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) zugewiesen wird. Die Liste unterstützter Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen vieler großer Bilder auf die PPTX‑Größe und Performance aus?**

Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien zugänglich bleiben. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) für einen [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (z. B. Verschieben oder Größenändern deaktivieren). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/net/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), unterstützt.

**Wird die Vektorrepräsentation von SVG beim Export einer Präsentation zu PDF/Bildern beibehalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Export zu PDF](/slides/de/net/convert-powerpoint-to-pdf/) oder zu [Rasterformaten](/slides/de/net/convert-powerpoint-to-png/) kann das Ergebnis abhängig von den Exporteinstellungen gerastert werden; das Original‑SVG bleibt jedoch als Vektor erhalten, was durch das Extraktionsverhalten bestätigt wird.