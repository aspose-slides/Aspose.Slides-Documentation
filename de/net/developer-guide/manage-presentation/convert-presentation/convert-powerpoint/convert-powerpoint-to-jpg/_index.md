---
title: PowerPoint in JPG umwandeln in C#
linktitle: PowerPoint PPT in JPG umwandeln
type: docs
weight: 60
url: /de/net/convert-powerpoint-to-jpg/
keywords: 
- PowerPoint-Präsentation umwandeln
- JPG
- JPEG
- PowerPoint in JPG
- PowerPoint in JPEG
- PPT in JPG
- PPTX in JPG
- PPT in JPEG
- PPTX in JPEG
- C#
- Csharp
- .NET
- Aspose.Slides
description: "PowerPoint in JPG umwandeln in C# oder .NET. Folie als JPG-Bild speichern"
---

## **Überblick**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im JPG-Format mithilfe von C# umwandelt. Er behandelt die folgenden Themen:

- [C# PowerPoint in JPG umwandeln](#convert-powerpoint-pptpptx-to-jpg)
- [C# PPT in JPG umwandeln](#convert-powerpoint-pptpptx-to-jpg)
- [C# PPTX in JPG umwandeln](#convert-powerpoint-pptpptx-to-jpg)
- [C# ODP in JPG umwandeln](#convert-powerpoint-pptpptx-to-jpg)
- [C# PowerPoint-Folie in Bild umwandeln](#convert-powerpoint-pptpptx-to-jpg)

## **C# PowerPoint in JPG**

Für Beispielcode in C#, um PowerPoint in JPG umzuwandeln, siehe den Abschnitt unten, d.h. [PowerPoint in JPG umwandeln](#convert-powerpoint-pptpptx-to-jpg). Der Code kann mehrere Formate wie PPT, PPTX und ODP im Präsentationsobjekt laden und dann das Miniaturbild der Folien im JPG-Format speichern. Die anderen PowerPoint zu Bild-Konversionen, die ähnlich wie PNG, BMP, TIFF und SVG sind, werden in diesen Artikeln behandelt.

- [C# PowerPoint in PNG umwandeln](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)
- [C# PowerPoint in BMP umwandeln](#convert-powerpoint-pptpptx-to-jpg)
- [C# PowerPoint in TIFF umwandeln](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint in SVG umwandeln](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **Über die Umwandlung von PowerPoint in JPG**
Mit der [**Aspose.Slides .NET API**](https://products.aspose.com/slides/net/) können Sie eine PowerPoint PPT oder PPTX-Präsentation in ein JPG-Bild konvertieren. Es ist auch möglich, PPT/PPTX in BMP, PNG oder SVG umzuwandeln. Mit diesen Funktionen ist es einfach, Ihren eigenen Präsentationsbetrachter zu implementieren und das Miniaturbild für jede Folie zu erstellen. Dies kann nützlich sein, wenn Sie Präsentationsfolien vor dem Urheberrecht schützen oder die Präsentation im Nur-Lese-Modus demonstrieren möchten. Aspose.Slides ermöglicht es, die gesamte Präsentation oder eine bestimmte Folie in Bildformate umzuwandeln. 

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG-Bilder umwandelt, möchten Sie vielleicht diese kostenlosen Online-Konverter ausprobieren: PowerPoint [PPTX in JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT in JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX in JPG umwandeln**
Hier sind die Schritte, um PPT/PPTX in JPG umzuwandeln:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) aus der [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) Sammlung.
3. Erstellen Sie das Miniaturbild jeder Folie und wandeln Sie es dann in JPG um. Die Methode [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) wird verwendet, um ein Miniaturbild einer Folie zu erhalten, sie gibt ein [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8) Objekt als Ergebnis zurück. Die [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) Methode muss von der benötigten Folie vom Typ [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) aufgerufen werden, die Skalen des resultierenden Miniaturbildes werden in die Methode übergeben.
4. Nachdem Sie das Miniaturbild der Folie erhalten haben, rufen Sie die Methode [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) vom Miniaturbildobjekt auf. Übergeben Sie den resultierenden Dateinamen und das Bildformat.

{{% alert color="primary" %}} 
**Hinweis**: Die Umwandlung von PPT/PPTX in JPG unterscheidet sich von der Umwandlung in andere Typen in der Aspose.Slides .NET API. Für andere Typen verwenden Sie normalerweise die Methode [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5), aber hier benötigen Sie die Methode [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8).
{{% /alert %}} 

```c#
const int imageScale = 1;

using (Presentation pres = new Presentation("PowerPoint-Presentation.ppt"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Erstellt ein Bild in voller Größe
        using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
        {
            // Speichert das Bild auf der Festplatte im JPEG-Format
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **PowerPoint PPT/PPTX in JPG mit benutzerdefinierten Abmessungen umwandeln**
Um die Abmessungen des resultierenden Miniaturbilds und JPEG-Bilds zu ändern, können Sie die Werte *ScaleX* und *ScaleY* festlegen, indem Sie sie in die [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) Methode übergeben:

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.pptx"))
{
    // Definiert Abmessungen
    int desiredX = 1200;
    int desiredY = 800;

    // Holt die skalierenden Werte von X und Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    foreach (ISlide slide in pres.Slides)
    {
        // Erstellt ein Bild in voller Größe
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Speichert das Bild auf der Festplatte im JPEG-Format
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Kommentare rendern beim Speichern der Präsentation als Bild**
Aspose.Slides für .NET bietet eine Funktion, die es Ihnen ermöglicht, Kommentare in den Folien einer Präsentation zu rendern, wenn Sie diese Folien in Bilder umwandeln. Dieser C#-Code demonstriert den Vorgang:

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,
            CommentsAreaColor = Color.Red,
            CommentsAreaWidth = 200,
            CommentsPosition = CommentsPositions.Right
        }
    };

    using (IImage image = presentation.Slides[0].GetImage(options))
    {
        image.Save("OutPresBitmap.png", ImageFormat.Png);
    }

    System.Diagnostics.Process.Start("OutPresBitmap.png");
}
```

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Webanwendung](https://products.aspose.app/slides/collage). Mit diesem Online-Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG-Bildern zusammenführen, [Fotokollagen](https://products.aspose.app/slides/collage/photo-grid) erstellen und so weiter. 

Unter Verwendung derselben Prinzipien, die in diesem Artikel beschrieben sind, können Sie Bilder von einem Format in ein anderes konvertieren. Für weitere Informationen siehe diese Seiten: [Bild in JPG umwandeln](https://products.aspose.com/slides/net/conversion/image-to-jpg/); [JPG in Bild umwandeln](https://products.aspose.com/slides/net/conversion/jpg-to-image/); [JPG in PNG umwandeln](https://products.aspose.com/slides/net/conversion/jpg-to-png/), [PNG in JPG umwandeln](https://products.aspose.com/slides/net/conversion/png-to-jpg/); [PNG in SVG umwandeln](https://products.aspose.com/slides/net/conversion/png-to-svg/), [SVG in PNG umwandeln](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Siehe auch**

Siehe andere Optionen, um PPT/PPTX in Bilder umzuwandeln wie:

- [PPT/PPTX in SVG-Umwandlung](/slides/de/net/render-a-slide-as-an-svg-image/).