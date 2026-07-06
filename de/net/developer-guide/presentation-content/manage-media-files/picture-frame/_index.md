---
title: Verwalten von Bilderrahmen in Präsentationen in .NET
linktitle: Bilderrahmen
type: docs
weight: 10
url: /de/net/picture-frame/
keywords:
- Bilderrahmen
- Bilderrahmen hinzufügen
- Bilderrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Rasterbild
- Vektorbild
- Bild zuschneiden
- Zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bilderrahmen-Formatierung
- Bilderrahmen-Eigenschaften
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
description: "Fügen Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET Bilderrahmen hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design der Folien."
---
## **Einleitung**

Ein Bilderrahmen ist eine Form, die ein Bild enthält – es ist wie ein Bild in einem Rahmen. 

Sie können einem Dia ein Bild über einen Bilderrahmen hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bilderrahmen formatieren.

{{% alert  title="Tip" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—die es ermöglichen, schnell aus Bildern Präsentationen zu erstellen. 

{{% /alert %}} 

## **Erstellen eines Bilderrahmens**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse. 
2. Holen Sie die Referenz einer Folie über deren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe) basierend auf der Breite und Höhe des Bildes über die Methode `AddPictureFrame`, die vom Formobjekt der referenzierten Folie bereitgestellt wird.
6. Fügen Sie der Folie einen Bilderrahmen (der das Bild enthält) hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#‑Code zeigt, wie ein Bilderrahmen erstellt wird:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
using (Presentation pres = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = pres.Slides[0];

    // Lädt ein Bild und fügt es zur Bildersammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bilderrahmen mit gleicher Höhe und Breite hinzu
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Wendet einige Formatierungen auf den Bildernrahmen an
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Speichert die Präsentation in einer PPTX-Datei
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Bilderrahmen ermöglichen es Ihnen, schnell Präsentationsfolien auf Basis von Bildern zu erstellen. Wenn Sie einen Bilderrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Ein‑ und Ausgabe‑Operationen steuern, um Bilder von einem Format in ein anderes zu konvertieren. Sie können diese Seiten ansehen: konvertieren [Bild zu JPG](https://products.aspose.com/slides/de/net/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/de/net/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/de/net/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/de/net/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/de/net/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/de/net/conversion/svg-to-png/).

{{% /alert %}}

## **Erstellen eines Bilderrahmens mit relativer Skalierung**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bilderrahmen erstellen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse.
2. Holen Sie die Referenz einer Folie über deren Index. 
3. Fügen Sie ein Bild zur Bildersammlung der Präsentation hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bilderrahmen an.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#‑Code zeigt, wie ein Bilderrahmen mit relativer Skalierung erstellt wird:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
using (Presentation presentation = new Presentation())
{
    // Lädt ein Bild und fügt es zur Bildersammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bilderrahmen zur Folie hinzu
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Setzt die relative Skalierungsbreite und -höhe
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Speichert die Präsentation
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Rasterbilder aus Bilderrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe)‑Objekten extrahieren und sie im PNG‑, JPG‑ oder anderen Formaten speichern. Das untenstehende Codebeispiel demonstriert, wie ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.

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

## **SVG‑Bilder aus Bilderrahmen extrahieren**

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/)‑Formen platziert sind, ermöglicht Aspose.Slides für .NET das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung der Folie können Sie jedes [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrunde liegende [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) SVG‑Inhalt enthält, und das Bild anschließend im nativen SVG‑Format auf Datenträger oder in einen Stream speichern.

Der folgende Code demonstriert, wie ein SVG‑Bild aus einem Bilderrahmen extrahiert wird:

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

## **Transparenz eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen des Transparenzeffekts, der auf ein Bild angewendet wurde. Dieser C#‑Code demonstriert die Vorgehensweise:

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

## **Helligkeit und Kontrast eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen von Helligkeit‑ und Kontrasteffekten, die auf ein Bild angewendet wurden. Das Interface [ILuminance](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iluminance/) repräsentiert diesen Bildtransformations‑Effekt.

Dieser C#‑Code zeigt, wie die Helligkeits‑ und Kontrasteinstellungen aus einem Bilderrahmen gelesen werden:

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="primary" %}} 
Alle auf Bilder angewendeten Effekte finden Sie in [Aspose.Slides.Effects](https://reference.aspose.com/slides/de/net/aspose.slides.effects/).
{{% /alert %}}

## **Formatierung von Bilderrahmen**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bilderrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bilderrahmen so anpassen, dass er spezifischen Anforderungen entspricht.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/de/aspose.slides/) Klasse.
2. Holen Sie die Referenz einer Folie über deren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen `PictureFrame` basierend auf der Breite und Höhe des Bildes über die [AddPictureFrame](http://www.aspose.com/api/net/slides/de/aspose.slides/ishapecollection/methods/addpictureframe)‑Methode, die vom [IShapes](http://www.aspose.com/api/net/slides/de/aspose.slides/ishapecollection)‑Objekt der referenzierten Folie bereitgestellt wird.
6. Fügen Sie der Folie den Bilderrahmen (der das Bild enthält) hinzu.
7. Legen Sie die Linienfarbe des Bilderrahmens fest.
8. Legen Sie die Linienbreite des Bilderrahmens fest.
9. Drehen Sie den Bilderrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bilderrahmen (der das Bild enthält) erneut zur Folie hinzu.
11. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert den Formatierungsprozess eines Bilderrahmens:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
using (Presentation presentation = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = presentation.Slides[0];

    // Lädt ein Bild und fügt es zur Bildersammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bilderrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Wendet einige Formatierungen auf den Bilderrahmen an
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Speichert die Präsentation in einer PPTX-Datei
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/de/collage) entwickelt. Wenn Sie jemals JPG/JPEG‑ oder PNG‑Bilder zusammenführen oder aus Fotos Raster‑Layouts erstellen möchten, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Ein Bild als Link hinzufügen**

Um große Präsentationsdateien zu vermeiden, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation einzubetten. Dieser C#‑Code zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:

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

## **Bilder zuschneiden**

Dieser C#‑Code zeigt, wie ein vorhandenes Bild auf einer Folie zugeschnitten wird:

```c#
using (Presentation presentation = new Presentation())
{
    // Erstellt ein neues Bildobjekt
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einer Folie einen Bilderrahmen hinzu
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Schneidet das Bild zu (Prozentwerte)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Speichert das Ergebnis
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Zugeschnittene Bereiche eines Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines Bildes, das in einem Rahmen enthalten ist, löschen möchten, können Sie die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode gibt das zugeschnittene Bild oder das ursprüngliche Bild zurück, wenn kein Zuschnitt erforderlich ist.

Dieser C#‑Code demonstriert die Vorgehensweise:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt den PictureFrame von der ersten Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Löscht zugeschnittene Bereiche des PictureFrame-Bildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) fügt das zugeschnittene Bild der Bildersammlung der Präsentation hinzu. Wird das Bild ausschließlich im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) verwendet, kann diese Vorgehensweise die Dateigröße der Präsentation reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Die Methode wandelt WMF/EMF‑Metadateien im Zuschneidevorgang in Raster‑PNG‑Bilder um. 

{{% /alert %}}

## **Bilder komprimieren**

Sie können ein Bild in einer Präsentation mithilfe der Methode [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/compressimage/) komprimieren. Diese Methode reduziert die Bildgröße anhand der Formgröße und der angegebenen Auflösung und kann dabei zugeschnittene Bereiche entfernen. 

Sie passt die Bildgröße und Auflösung ähnlich der PowerPoint‑Funktion **Bildformat → Bilder komprimieren → Auflösung** an.

Die folgenden C#‑Beispiele zeigen, wie ein Bild in einer Präsentation durch Angabe einer Zielauflösung und optionalem Entfernen zugeschnittener Bereiche komprimiert wird:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimiert das Bild mit einer Zielauflösung von 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Überprüft das Ergebnis der Komprimierung.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Oder direkt mit einem benutzerdefinierten DPI‑Wert:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimiert das Bild auf 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Die Methode wandelt das Bild basierend auf der Formgröße und dem angegebenen DPI in eine niedrigere Auflösung um. Zugeschnittene Regionen können ebenfalls gelöscht werden, um die Dateigröße zu optimieren.  
Handelt es sich bei dem Bild um eine Metadatei (WMF/EMF) oder SVG, wird keine Kompression angewendet. Außerdem wird die JPEG‑Qualität je nach Auflösung erhalten bzw. leicht reduziert, analog zu PowerPoints Behandlung hochauflösender JPEG‑Bilder.

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis auch nach einer Größenänderung des Bildes beibehält, können Sie die Eigenschaft [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframelock/aspectratiolocked/) verwenden, um die Einstellung *Seitenverhältnis sperren* zu setzen. 

Dieser C#‑Code zeigt, wie das Seitenverhältnis einer Form gesperrt wird:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Setzt die Form so, dass das Seitenverhältnis beim Skalieren beibehalten wird
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Diese *Seitenverhältnis‑sperren*‑Einstellung bewahrt ausschließlich das Seitenverhältnis der Form, nicht jedoch das des darin enthaltenen Bildes.

{{% /alert %}}

## **Verwenden der StretchOff‑Eigenschaft**

Durch die Nutzung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/properties/stretchoffsetright) und [StretchOffsetBottom](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) aus dem Interface [IPictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat) können Sie ein Füllrechteck festlegen. 

Wenn für ein Bild ein Stretch angegeben wird, wird ein Quellrechteck so skaliert, dass es in das angegebene Füllrechteck passt. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz bedeutet ein Einschieben, ein negativer Prozentsatz ein Herausziehen.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/de/aspose.slides/) Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erstellen Sie ein Bild.
5. Legen Sie den Fülltyp der Form fest.
6. Legen Sie den Bildfüllmodus der Form fest.
7. Fügen Sie ein Bild zum Füllen der Form hinzu.
8. Geben Sie Bildversätze von der jeweiligen Kante der Begrenzungsbox der Form an.
9. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Streckt das Bild von jeder Seite im Formkörper
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

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (zum Beispiel SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen dutzender großer Bilder auf die PPTX‑Größe und Performance aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien weiterhin verfügbar sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt davor schützen, versehentlich verschoben oder skaliert zu werden?**

Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/pictureframelock/) für einen [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) (zum Beispiel zum Deaktivieren von Verschieben oder Skalieren). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/net/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen unterstützt, einschließlich [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/).

**Wird die Vektor‑Treue von SVG beim Export einer Präsentation zu PDF/Bildern erhalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Export zu PDF](/slides/de/net/convert-powerpoint-to-pdf/) oder zu [Rasterformaten](/slides/de/net/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; das originale SVG bleibt als Vektor erhalten, wie das Extraktionsverhalten bestätigt.