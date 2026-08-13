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
- zugeschnittener Bereich
- StretchOff‑Eigenschaft
- Bildrahmenformatierung
- Bildrahmen‑Eigenschaften
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
description: "Fügen Sie PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für .NET Bildrahmen hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design Ihrer Folien."
---
## **Einleitung**

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen.

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="info" %}} 

Aspose bietet kostenlose Konverter — [JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt) — die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 

{{% /alert %}} 

## **Erstellen eines Bildrahmens**

1. Erzeugen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)class. 
2. Holen Sie sich einen Folienverweis über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erzeugen Sie einen [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe) basierend auf der Bildbreite und -höhe über die `AddPictureFrame`‑Methode, die vom Shape‑Objekt der referenzierten Folie bereitgestellt wird.
6. Fügen Sie der Folie einen Bildrahmen (mit dem Bild) hinzu.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie ein Bildrahmen erstellt wird:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Holt die erste Folie
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

Bildrahmen ermöglichen das schnelle Erstellen von Präsentationsfolien basierend auf Bildern. Kombiniert man Bildrahmen mit den Speicheroptionen von Aspose.Slides, kann man Ein‑ und Ausgabe‑Operationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Weitere nützliche Seiten sind: Konvertieren von [Bild zu JPG](https://products.aspose.com/slides/de/net/conversion/image-to-jpg/); von [JPG zu Bild](https://products.aspose.com/slides/de/net/conversion/jpg-to-image/); von [JPG zu PNG](https://products.aspose.com/slides/de/net/conversion/jpg-to-png/), von [PNG zu JPG](https://products.aspose.com/slides/de/net/conversion/png-to-jpg/); von [PNG zu SVG](https://products.aspose.com/slides/de/net/conversion/png-to-svg/), von [SVG zu PNG](https://products.aspose.com/slides/de/net/conversion/svg-to-png/).

{{% /alert %}}

## **Erstellen eines Bildrahmens mit relativer Skalierung**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erzeugen. 

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)class. 
2. Holen Sie sich einen Folienverweis über ihren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu. 
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie ein Bildrahmen mit relativer Skalierung erstellt wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Lädt ein Bild und fügt es der Bildsammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bildrahmen zur Folie hinzu
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Setzt die relative Skalierung von Breite und Höhe
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Speichert die Präsentation
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extrahieren von Rasterbildern aus Bildrahmen**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe)-Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Das folgende Codebeispiel demonstriert, wie ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Extrahieren von SVG‑Bildern aus Bildrahmen**

Enthält eine Präsentation SVG‑Grafiken, die in [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für .NET das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Shape‑Sammlung der Folie können Sie jede [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/)-Form identifizieren, prüfen, ob das zugrunde liegende [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) SVG‑Inhalt enthält, und das Bild dann im nativen SVG‑Format auf Datenträger oder in einen Stream speichern.

Das folgende Codebeispiel demonstriert das Extrahieren eines SVG‑Bildes aus einem Bildrahmen:

```cs
using Aspose.Slides;

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

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Dieser C#‑Code demonstriert den Vorgang:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

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

## **Helligkeit und Kontrast eines Bildes ermitteln**

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Helligkeits‑ und Kontrasteffekts. Das [ILuminance](https://reference.aspose.com/slides/de/net/aspose.slides.effects/iluminance/)-Interface repräsentiert diesen Bild‑Transformations‑Effekt.

Dieser C#‑Code demonstriert, wie die Helligkeits‑ und Kontrasteinstellungen eines Bildrahmens ermittelt werden:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

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

{{% alert color="info" %}} 
Alle auf Bilder angewendeten Effekte finden Sie in [Aspose.Slides.Effects](https://reference.aspose.com/slides/de/net/aspose.slides.effects/).
{{% /alert %}}

## **Bildrahmen‑Formatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen so anpassen, dass er spezifischen Anforderungen entspricht.

1. Erzeugen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/de/aspose.slides/)class. 
2. Holen Sie sich einen Folienverweis über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erzeugen Sie ein `PictureFrame` basierend auf der Bildbreite und -höhe über die [AddPictureFrame](http://www.aspose.com/api/net/slides/de/aspose.slides/ishapecollection/methods/addpictureframe)-Methode, die vom [IShapes](http://www.aspose.com/api/net/slides/de/aspose.slides/ishapecollection)-Objekt der referenzierten Folie bereitgestellt wird.
6. Fügen Sie den Bildrahmen (mit dem Bild) zur Folie hinzu.
7. Setzen Sie die Linienfarbe des Bildrahmens.
8. Setzen Sie die Linienbreite des Bildrahmens.
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.  
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.  
10. Fügen Sie den Bildrahmen (mit dem Bild) zur Folie hinzu.  
11. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert den Bildrahmen‑Formatierungsprozess:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = presentation.Slides[0];

    // Lädt ein Bild und fügt es der Bildsammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bildrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Wendet einige Formatierungen auf den Bildrahmen an
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Speichert die Präsentation in einer PPTX-Datei
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/de/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/de/collage/jpg) oder PNG‑Bilder zusammenführen, [Raster aus Fotos erstellen](https://products.aspose.app/slides/de/collage/photo-grid) möchten, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Ein Bild als Link hinzufügen**

Um große Präsentationsdateien zu vermeiden, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Dieser C#‑Code zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Erstellt ein neues Bildobjekt
    IImage image = Images.FromFile("aspose-logo.jpg");
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

## **Zugeschnittene Bereiche eines Bildes löschen**

Möchten Sie die zugeschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes entfernen, können Sie die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Originalbild zurück, falls kein Zuschnitt nötig ist.

Dieser C#‑Code demonstriert den Vorgang:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt den Bildrahmen von der ersten Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Löscht die zugeschnittenen Bereiche des Bildrahmen-Bildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) fügt das zugeschnittene Bild der Präsentations‑Bildsammlung hinzu. Wird das Bild ausschließlich im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) verwendet, kann diese Vorgehensweise die Dateigröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Die Methode konvertiert WMF/EMF‑Metadateien während des Zuschnitts in ein Raster‑PNG‑Bild. 

{{% /alert %}}

## **Bilder komprimieren**

Sie können ein Bild in einer Präsentation mithilfe der Methode [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/compressimage/) komprimieren. Diese Methode reduziert die Bildgröße anhand der Formgröße und der angegebenen Auflösung und bietet die Option, zugeschnittene Bereiche zu löschen. 

Sie passt Größe und Auflösung des Bildes ähnlich der PowerPoint‑Funktion **Bildformat → Bilder komprimieren → Auflösung** an.

Die folgenden C#‑Beispiele zeigen, wie ein Bild in einer Präsentation komprimiert wird, indem eine Zielauflösung angegeben und optional zugeschnittene Bereiche entfernt werden:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimiert das Bild mit einer Zielauflösung von 150 DPI (Webauflösung) und entfernt zugeschnittene Bereiche.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Überprüft das Ergebnis der Kompression.
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

Oder indem ein benutzerdefinierter DPI‑Wert direkt verwendet wird:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimiert das Bild auf 150 DPI (Webauflösung), entfernt zugeschnittene Bereiche.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Die Methode konvertiert das Bild basierend auf der Formgröße und dem angegebenen DPI in eine niedrigere Auflösung. Zugeschnittene Bereiche können ebenfalls gelöscht werden, um die Dateigröße zu optimieren.  
Handelt es sich bei dem Bild um eine Metadatei (WMF/EMF) oder SVG, wird keine Kompression angewendet. Ebenso bleibt die JPEG‑Qualität erhalten oder wird leicht reduziert, je nach Auflösung, analog zu PowerPoint‑Verhalten bei hochauflösenden JPEGs.

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Eigenschaft [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframelock/aspectratiolocked/) verwenden, um die Einstellung *Seitenverhältnis sperren* zu setzen. 

Dieser C#‑Code zeigt, wie das Seitenverhältnis einer Form gesperrt wird:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Setzt die Form, damit das Seitenverhältnis beim Skalieren beibehalten wird
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Die Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des enthaltenen Bildes.

{{% /alert %}}

## **Verwendung der StretchOff‑Eigenschaft**

Durch die Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/properties/stretchoffsetright) und [StretchOffsetBottom](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) aus dem Interface [IPictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat) können Sie ein Füllrechteck festlegen. 

Wird für ein Bild ein Strecken angegeben, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz gibt einen Innenversatz an, ein negativer Prozentsatz einen Außenversatz.

1. Erzeugen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/de/aspose.slides/)class. 
2. Holen Sie sich einen Folienverweis über ihren Index. 
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erzeugen Sie ein Bild. 
5. Setzen Sie den Fülltyp der Form. 
6. Setzen Sie den Bildfüllmodus der Form. 
7. Fügen Sie ein Bild zum Füllen der Form hinzu. 
8. Geben Sie Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an. 
9. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Setzt das Bild, das von jeder Seite im Shape-Körper gestreckt wird
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

### Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und -Leistung aus?

Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße gering, erfordert jedoch, dass die externen Dateien weiterhin zugänglich sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

### Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?

Verwenden Sie [Shape‑Locks](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/pictureframelock/) für ein [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) (z. B. Deaktivieren von Verschieben oder Größenändern). Der Sperrmechanismus wird in einem separaten [Schutz‑Artikel](/slides/de/net/applying-protection-to-presentation/) für Formen beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/), unterstützt.

### Wird die Vektortreue von SVG beim Export einer Präsentation nach PDF/Bildern beibehalten?

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Export nach PDF](/slides/de/net/convert-powerpoint-to-pdf/) oder in [Rasterformate](/slides/de/net/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.