---
title: Bilderrahmen
type: docs
weight: 10
url: /net/picture-frame/
keywords: 
- Bilderrahmen hinzufügen
- Bilderrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- StretchOff-Eigenschaft
- Bilderrahmenformatierung
- Eigenschaften des Bilderrahmens
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Fügen Sie einen Bilderrahmen zu einer PowerPoint-Präsentation in C# oder .NET hinzu"
---

Ein Bilderrahmen ist eine Form, die ein Bild enthält—es ist wie ein Bild in einem Rahmen. 

Sie können ein Bild über einen Bilderrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bilderrahmen formatieren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es den Nutzern ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

## **Bilderrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse. 
2. Holen Sie sich einen Verweis auf die Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist, das verwendet wird, um die Form auszufüllen.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) basierend auf der Breite und Höhe des Bildes durch die `AddPictureFrame` Methode, die vom Formobjekt, das mit der verlinkten Folie verknüpft ist, bereitgestellt wird.
6. Fügen Sie einen Bilderrahmen (der das Bild enthält) zur Folie hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen Bilderrahmen erstellen:

```c#
// Instanziierung der Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = pres.Slides[0];

    // Lädt ein Bild und fügt es der Präsentationsbildsammlung hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bilderrahmen mit der gleichen Höhe und Breite hinzu
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Wendet einige Formatierungen auf den Bilderrahmen an
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Schreibt die Präsentation in eine PPTX-Datei
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Bilderrahmen ermöglichen es Ihnen, Präsentationsfolien schnell basierend auf Bildern zu erstellen. Wenn Sie den Bilderrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Eingabe-/Ausgabeoperationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Sie möchten möglicherweise diese Seiten sehen: Konvertieren Sie [Bild in JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); Konvertieren Sie [JPG in Bild](https://products.aspose.com/slides/net/conversion/jpg-to-image/); Konvertieren Sie [JPG in PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), konvertieren Sie [PNG in JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); konvertieren Sie [PNG in SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), konvertieren Sie [SVG in PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Bilderrahmen mit relativer Skalierung erstellen**

Durch die Änderung der relativen Skalierung eines Bildes können Sie einen komplexeren Bilderrahmen erstellen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index. 
3. Fügen Sie ein Bild zur Präsentationsbildsammlung hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist, das verwendet wird, um die Form auszufüllen.
5. Geben Sie die relative Breite und Höhe des Bildes im Bilderrahmen an.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen Bilderrahmen mit relativer Skalierung erstellen:

```c#
// Instanziierung der Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Lädt ein Bild und fügt es der Präsentationsbildsammlung hinzu
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

## **Bild aus dem Bilderrahmen extrahieren**

Sie können Bilder aus [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) Objekten extrahieren und sie in PNG, JPG und anderen Formaten speichern. Das folgende Codebeispiel zeigt, wie man ein Bild aus dem Dokument "sample.pptx" extrahiert und es im PNG-Format speichert.

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

## **Transparenz des Bildes erhalten**

Aspose.Slides ermöglicht es Ihnen, die Transparenz eines Bildes zu erhalten. Dieser C#-Code demonstriert die Operation:

```c#
using (var presentation = new Presentation(folderPath + "Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Bildtransparenz: " + transparencyValue);
        }
    }
}
```

## **Bilderrahmenformatierung**

Aspose.Slides bietet viele Formatierungsoptionen, die auf einen Bilderrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bilderrahmen ändern, um ihn an spezifische Anforderungen anzupassen.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist, das verwendet wird, um die Form auszufüllen.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen `PictureFrame` basierend auf der Breite und Höhe des Bildes durch die [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) Methode, die vom [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) Objekt bereitgestellt wird, das mit der verlinkten Folie verknüpft ist.
6. Fügen Sie den Bilderrahmen (der das Bild enthält) zur Folie hinzu.
7. Setzen Sie die Liniefarbe des Bilderrahmens.
8. Setzen Sie die Linienstärke des Bilderrahmens.
9. Rotieren Sie den Bilderrahmen, indem Sie ihm entweder einen positiven oder negativen Wert geben.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bilderrahmen (der das Bild enthält) zur Folie hinzu.
11. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code demonstriert den Formatierungsprozess des Bilderrahmens:

```c#
// Instanziierung der Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = presentation.Slides[0];

    // Lädt ein Bild und fügt es der Präsentationsbildsammlung hinzu
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

    // Schreibt die Präsentation in eine PPTX-Datei
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage-Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG-Bilder zusammenführen müssen, [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid), können Sie diesen Dienst nutzen. 

{{% /alert %}}

## **Bild als Link hinzufügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentationen einzufügen. Dieser C#-Code zeigt Ihnen, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:

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

Dieser C#-Code zeigt Ihnen, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:

```c#
using (Presentation presentation = new Presentation())
{
    // Erstellt ein neues Bildobjekt
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bilderrahmen zu einer Folie hinzu
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Schneidet das Bild (Prozentwerte)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Speichert das Ergebnis
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## Bereiche des Bildes löschen

Wenn Sie die zugeschnittenen Bereiche eines Bildes, das in einem Rahmen enthalten ist, löschen möchten, können Sie die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Ursprungsbild zurück, wenn das Zuschneiden nicht erforderlich ist.

Dieser C#-Code demonstriert die Operation:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt den Bilderrahmen von der ersten Folie
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Löscht die zugeschnittenen Bereiche des Bilderrahmenbildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="HINWEIS" color="warning" %}} 

Die Methode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) fügt das zugeschnittene Bild der Präsentationsbildsammlung hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) verwendet wird, kann diese Einrichtung die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF-Metadateien in ein raster PNG-Bild während der Zuschneideoperation. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis auch nach Änderung der Bilddimensionen beibehält, können Sie die [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) Eigenschaft verwenden, um die Einstellung *Seitenverhältnis sperren* festzulegen. 

Dieser C#-Code zeigt Ihnen, wie Sie das Seitenverhältnis einer Form sperren:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Setzt die Form, um das Seitenverhältnis beim Skalieren zu bewahren
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="HINWEIS" color="warning" %}} 

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form und nicht das Bild, das sie enthält.

{{% /alert %}}

## **StretchOff-Eigenschaft verwenden**

Durch die Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight,](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) und [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) aus dem [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) Interface und der [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) Klasse können Sie ein Füllrechteck angeben. 

Wenn das Strecken für ein Bild festgelegt ist, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jeder Rand des Füllrechtecks wird durch einen prozentualen Offset vom entsprechenden Rand des Begrenzungsrahmens der Form definiert. Ein positiver Prozentsatz gibt einen Innenabstand an, während ein negativer Prozentsatz einen Außenabstand angibt.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Fügen Sie eine Rechteck-`AutoShape` hinzu. 
4. Erstellen Sie ein Bild.
5. Legen Sie den Fülltyp der Form fest.
6. Legen Sie den Bildfüllenmodus der Form fest.
7. Fügen Sie ein festgelegtes Bild hinzu, um die Form auszufüllen.
8. Geben Sie die Bildoffsets von den entsprechenden Rändern des Begrenzungsrahmens der Form an.
9. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code demonstriert einen Prozess, in dem eine StretchOff-Eigenschaft verwendet wird:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Setzt das Bild, das von jeder Seite im Formkörper gestreckt wird
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```