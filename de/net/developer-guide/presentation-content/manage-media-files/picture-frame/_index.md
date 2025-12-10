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
- Beschnittbereich
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

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen. 

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="primary" %}} 
Aspose bietet kostenlose Konverter —[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 
{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Holen Sie sich über den Index die Referenz einer Folie. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird. 
4. Geben Sie die Breite und Höhe des Bildes an. 
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe), basierend auf der Breite und Höhe des Bildes, über die Methode `AddPictureFrame`, die vom Formobjekt bereitgestellt wird, das der referenzierten Folie zugeordnet ist. 
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu. 
7. Speichern Sie die geänderte Präsentation als PPTX-Datei. 

Dieser C#‑Code zeigt, wie ein Bildrahmen erstellt wird:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
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
Bildrahmen ermöglichen es, schnell Präsentationsfolien basierend auf Bildern zu erstellen. Wenn Sie Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Ein‑ und Ausgabevorgänge steuern, um Bilder von einem Format in ein anderes zu konvertieren. Weitere Informationen finden Sie auf diesen Seiten: konvertieren Sie [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); konvertieren Sie [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); konvertieren Sie [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), konvertieren Sie [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); konvertieren Sie [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), konvertieren Sie [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 
{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erstellen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Holen Sie sich über den Index die Referenz einer Folie. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu. 
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird. 
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an. 
6. Speichern Sie die geänderte Präsentation als PPTX-Datei. 

Das folgende C#‑Codebeispiel zeigt, wie ein Bildrahmen mit relativer Skalierung erstellt wird:
```c#
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Lädt ein Bild und fügt es der Bildsammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bildrahmen zur Folie hinzu
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Setzt die relative Skalierung für Breite und Höhe
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Speichert die Präsentation
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```


## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe)-Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Das untenstehende Codebeispiel zeigt, wie ein Bild aus dem Dokument "sample.pptx" extrahiert und im PNG‑Format gespeichert wird.
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

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für .NET das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung der Folie können Sie jedes [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrunde liegende [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) SVG‑Inhalt enthält, und das Bild anschließend im nativen SVG‑Format auf Festplatte oder in einen Stream speichern.

Das folgende Codebeispiel demonstriert, wie ein SVG‑Bild aus einem Bildrahmen extrahiert wird:
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

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Dieser C#‑Code demonstriert den Vorgang:
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

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen so anpassen, dass er bestimmte Anforderungen erfüllt.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)-Klasse. 
2. Holen Sie sich über den Index die Referenz einer Folie. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird. 
4. Geben Sie die Breite und Höhe des Bildes an. 
5. Erstellen Sie ein `PictureFrame` basierend auf der Breite und Höhe des Bildes über die Methode [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe), die vom [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection)-Objekt bereitgestellt wird, das der referenzierten Folie zugeordnet ist. 
6. Fügen Sie der Folie den Bildrahmen (der das Bild enthält) hinzu. 
7. Legen Sie die Linienfarbe des Bildrahmens fest. 
8. Legen Sie die Linienstärke des Bildrahmens fest. 
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen. 
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn. 
10. Fügen Sie der Folie den Bildrahmen (der das Bild enthält) erneut hinzu. 
11. Speichern Sie die geänderte Präsentation als PPTX-Datei. 

Dieser C#‑Code demonstriert den Bildrahmen‑Formatierungsprozess:
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

    // Fügt einen Bildrahmen mit derselben Höhe und Breite wie das Bild hinzu
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


{{% alert color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG‑Bilder zusammenführen, [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) müssen, können Sie diesen Dienst nutzen. 

{{% /alert %}}

## **Ein Bild als Link einfügen**

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


## **Bilder zuschneiden**

Dieser C#‑Code zeigt, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:
```c#
using (Presentation presentation = new Presentation())
{
    // Erstellt ein neues Bildobjekt
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einer Folie einen Bildrahmen hinzu
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


## **Beschnittene Bereiche eines Bildes löschen**

Wenn Sie die beschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes entfernen möchten, können Sie die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode gibt das beschnittene Bild oder das Originalbild zurück, falls kein Zuschnitt erforderlich ist.

Dieser C#‑Code demonstriert den Vorgang:
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt das PictureFrame von der ersten Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Löscht zugeschnittene Bereiche des PictureFrame-Bildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="NOTE" color="warning" %}} 

Die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) fügt das beschnittene Bild der Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) verwendet wird, kann diese Einstellung die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF‑Metadateien bei der Zuschneideoperation in ein Raster‑PNG‑Bild. 
{{% /alert %}}

## **Bilder komprimieren**

Sie können ein Bild in einer Präsentation mit der Methode [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/) komprimieren. Diese Methode komprimiert ein Bild, indem sie seine Größe basierend auf der Formgröße und der angegebenen Auflösung reduziert, mit der Option, beschnittene Bereiche zu löschen. 

Sie passt Größe und Auflösung des Bildes ähnlich der PowerPoint‑Funktion **Bildformat → Bilder komprimieren → Auflösung** an.

Die folgenden C#‑Beispiele zeigen, wie ein Bild in einer Präsentation komprimiert wird, indem eine Zielauflösung angegeben und optional beschnittene Bereiche entfernt werden:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt das PictureFrame von der Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimiert das Bild mit einer Zielauflösung von 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Prüft das Ergebnis der Kompression
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

    // Komprimiert das Bild auf 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 

Die Methode konvertiert das Bild bei der Komprimierung in eine niedrigere Auflösung basierend auf der Größe der Form und dem angegebenen DPI. Beschnittene Bereiche können ebenfalls gelöscht werden, um die Dateigröße zu optimieren. Wenn das Bild ein Metadateiformat (WMF/EMF) oder SVG ist, wird keine Komprimierung durchgeführt. Bei JPEG wird die Qualität je nach Auflösung beibehalten oder leicht reduziert, ähnlich wie PowerPoint bei hochauflösenden JPEGs. 
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

    // Setzt die Form so, dass das Seitenverhältnis beim Ändern der Größe erhalten bleibt
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="NOTE" color="warning" %}} 

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des enthaltenen Bildes. 
{{% /alert %}}

## **Die StretchOff‑Eigenschaft verwenden**

Durch die Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) und [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) des [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat)-Interfaces und der [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat)-Klasse können Sie ein Füllrechteck angeben. 

Wenn für ein Bild ein Stretchen angegeben wird, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz gibt einen Innenschnitt an, ein negativer Prozentsatz einen Außenschnitt.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‑Klasse. 
2. Holen Sie sich über den Index die Referenz einer Folie. 
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erstellen Sie ein Bild. 
5. Legen Sie den Fülltyp der Form fest. 
6. Legen Sie den Bildfüllmodus der Form fest. 
7. Fügen Sie ein Bild hinzu, um die Form zu füllen. 
8. Geben Sie Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an. 
9. Speichern Sie die geänderte Präsentation als PPTX-Datei. 

Dieser C#‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Setzt das Bild von jeder Seite im Formkörper gedehnt
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
Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) zugewiesen wird. Die unterstützten Formate überschneiden sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen vieler großer Bilder auf die PPTX‑Größe und die Leistung aus?**  
Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern reduziert die Präsentationsgröße, erfordert jedoch, dass die externen Dateien weiterhin zugänglich sind. Aspose.Slides ermöglicht das Hinzufügen von Bildern per Link, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**  
Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) für einen [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (z. B. Verschieben oder Größenändern deaktivieren). Der Sperrmechanismus wird in einem separaten [Schutz‑Artikel](/slides/de/net/applying-protection-to-presentation/) beschrieben und ist für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), verfügbar.

**Wird die Vektor‑Treue von SVG bei der Exportierung einer Präsentation zu PDF/Bildern erhalten?**  
Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) als Originalvektor. Beim [Exportieren zu PDF](/slides/de/net/convert-powerpoint-to-pdf/) oder zu [Rasterformaten](/slides/de/net/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; das Original‑SVG bleibt jedoch als Vektor erhalten, wie das Extraktionsverhalten zeigt.