---
title: Verwalten von Bildrahmen in Präsentationen in .NET
linktitle: Bildrahmen
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
- Rasterbild
- Vektorbild
- Bild zuschneiden
- Zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmenformatierung
- Bildrahmen-Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Fügen Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET Bildrahmen hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design der Folien."
---

Ein Bildrahmen ist eine Form, die ein Bild enthält – es ist wie ein Bild im Rahmen. 

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert title="Tipp" color="primary" %}} 

Aspose stellt kostenlose Konverter bereit—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—mit denen Sie schnell Präsentationen aus Bildern erstellen können. 

{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) basierend auf der Breite und Höhe des Bildes über die Methode `AddPictureFrame`, die vom Formobjekt bereitgestellt wird, das mit der referenzierten Folie verbunden ist.
6. Fügen Sie einen Bildrahmen (der das Bild enthält) zur Folie hinzu.
7. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Dieser C#‑Code zeigt, wie ein Bildrahmen erstellt wird:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Gibt die erste Folie zurück
    ISlide slide = pres.Slides[0];

    // Lädt ein Bild und fügt es der Bildsammlung der Präsentation hinzu
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

Bildrahmen ermöglichen es Ihnen, schnell Präsentationsfolien basierend auf Bildern zu erstellen. Wenn Sie Bildrahmen mit den Speichereinstellungen von Aspose.Slides kombinieren, können Sie Ein‑ und Ausgabevorgänge steuern, um Bilder von einem Format in ein anderes zu konvertieren. Vielleicht möchten Sie diese Seiten ansehen: konvertieren [Bild zu JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/net/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/); konvertieren [PNG zu JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/); konvertieren [SVG zu PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 

{{% /alert %}} 

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erstellen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu. 
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#‑Code zeigt, wie ein Bildrahmen mit relativer Skalierung erstellt wird:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Lädt ein Bild und fügt es der Bildsammlung der Präsentation hinzu
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

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe)-Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Das folgende Codebeispiel zeigt, wie ein Bild aus dem Dokument "sample.pptx" extrahiert und im PNG-Format gespeichert wird.
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


## **SVG-Bilder aus Bildrahmen extrahieren**

Wenn eine Präsentation SVG-Grafiken enthält, die in [PictureFrame]‑Formen platziert sind, ermöglicht Aspose.Slides für .NET das Abrufen der originalen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung der Folie können Sie jedes [PictureFrame]‑Objekt identifizieren, prüfen, ob das zugrunde liegende [IPPImage] SVG-Inhalt enthält, und das Bild dann auf Festplatte oder in einem Stream im nativen SVG-Format speichern.

Der folgende Code demonstriert, wie ein SVG-Bild aus einem Bildrahmen extrahiert wird:
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


## **Transparenz des Bildes ermitteln**

Aspose.Slides ermöglicht es, den auf ein Bild angewendeten Transparenzeffekt zu ermitteln. Dieser C#‑Code demonstriert den Vorgang:
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

## **Bildrahmenformatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen anpassen, um spezifische Anforderungen zu erfüllen.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)-Klasse. 
2. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein `PictureFrame` basierend auf der Breite und Höhe des Bildes über die Methode [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe), die im [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection)-Objekt der referenzierten Folie bereitgestellt wird.
6. Fügen Sie den Bildrahmen (der das Bild enthält) zur Folie hinzu.
7. Setzen Sie die Linienfarbe des Bildrahmens.
8. Setzen Sie die Linienbreite des Bildrahmens.
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert rotiert das Bild im Uhrzeigersinn.  
   * Ein negativer Wert rotiert das Bild gegen den Uhrzeigersinn.  
10. Fügen Sie den Bildrahmen (der das Bild enthält) zur Folie hinzu.  
11. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#‑Code demonstriert den Bildrahmenformatierungsprozess:
```c#
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = presentation.Slides[0];

    // Lädt ein Bild und fügt es der Bildsammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bildrahmen mit der gleichen Höhe und Breite des Bildes hinzu
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

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG‑Bilder zusammenführen oder [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) müssen, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Bild als Link hinzufügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentation einzubetten. Dieser C#‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:
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

Dieser C#‑Code zeigt, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:
```c#
using (Presentation presentation = new Presentation())
{
    // Erzeugt ein neues Bildobjekt
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einer Folie einen Bildrahmen hinzu
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Beschneidet das Bild (Prozentwerte)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Speichert das Ergebnis
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```


## **Zugeschnittene Bereiche des Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes entfernen möchten, können Sie die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode liefert das zugeschnittene Bild zurück oder das Originalbild, wenn ein Zuschneiden nicht nötig ist.

Dieser C#‑Code demonstriert den Vorgang:
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt den Bildrahmen von der ersten Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Löscht zugeschnittene Bereiche des Bildes im Bildrahmen und gibt das beschnittene Bild zurück
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="HINWEIS" color="warning" %}} 

Die Methode [IPictureFillFormat.DeletePictureCroppedAreas] fügt das zugeschnittene Bild der Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame] verwendet wird, kann diese Vorgehensweise die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF-Metadateien im Zuschneidevorgang in ein Raster‑PNG‑Bild. 

{{% /alert %}}

## **Bild komprimieren**

Sie können ein Bild in einer Präsentation mit der Methode [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/) komprimieren. Diese Methode reduziert die Bildgröße basierend auf der Formgröße und der angegebenen Auflösung, wobei die Option besteht, zugeschnittene Bereiche zu löschen.

Sie passt die Bildgröße und Auflösung ähnlich der PowerPoint‑Funktion **Bildformat → Bilder komprimieren → Auflösung** an.

Die folgenden C#‑Beispiele zeigen, wie ein Bild in einer Präsentation komprimiert wird, indem eine Zielauflösung angegeben und optional zugeschnittene Bereiche entfernt werden:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt den Bildrahmen von der Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimiert das Bild mit einer Zielauflösung von 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche
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


Oder mit einem benutzerdefinierten DPI-Wert:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimiert das Bild auf 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="HINWEIS" color="warning" %}} 

Die Methode konvertiert das Bild basierend auf der Formgröße und dem angegebenen DPI in eine niedrigere Auflösung. Zuschnittbereiche können ebenfalls gelöscht werden, um die Dateigröße zu optimieren. Handelt es sich bei dem Bild um eine Metadatei (WMF/EMF) oder SVG, wird keine Kompression durchgeführt. Außerdem bleibt die JPEG‑Qualität erhalten oder wird je nach Auflösung leicht reduziert, ähnlich wie PowerPoint bei hochauflösenden JPEGs. 

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


{{% alert title="HINWEIS" color="warning" %}} 

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des darin enthaltenen Bildes. 

{{% /alert %}}

## **StretchOff-Eigenschaft verwenden**

Durch Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) und [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) des [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat)-Interfaces und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) können Sie ein Füllrechteck angeben.

Wenn für ein Bild ein Strecken angegeben wird, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz gibt einen Einzug an, ein negativer Prozentsatz einen Protrusion.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)-Klasse. 
2. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erstellen Sie ein Bild. 
5. Legen Sie den Fülltyp der Form fest. 
6. Legen Sie den Bildfüllmodus der Form fest. 
7. Fügen Sie ein Bild hinzu, um die Form zu füllen. 
8. Geben Sie Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an. 
9. Schreiben Sie die modifizierte Präsentation als PPTX-Datei. 

Dieser C#‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Setzt das Bild, das an allen Seiten des Formkörpers gestreckt wird
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

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) zugewiesen ist. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen dutzender großer Bilder auf die PPTX‑Größe und Leistung aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hilft, die Präsentationsgröße gering zu halten, erfordert jedoch, dass die externen Dateien weiterhin zugänglich bleiben. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern sperren?**

Verwenden Sie [Formensperren](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) für einen [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (z. B. das Deaktivieren von Verschieben oder Größenändern). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/net/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen unterstützt, einschließlich [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/).

**Wird die Vektortreue von SVG beim Export einer Präsentation nach PDF/Bildern erhalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame] als das originale Vektorbild. Beim [Export nach PDF](/slides/de/net/convert-powerpoint-to-pdf/) oder zu [Rasterformaten](/slides/de/net/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen rasterisiert werden; die Tatsache, dass das originale SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.