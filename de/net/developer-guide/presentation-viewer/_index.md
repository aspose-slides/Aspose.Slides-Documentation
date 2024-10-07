---
title: Präsentation Viewer
type: docs
weight: 50
url: /net/presentation-viewer/
keywords: 
- PowerPoint-Präsentation anzeigen
- ppt anzeigen
- PPTX anzeigen
- C#
- Csharp
- Aspose.Slides für .NET
description: "PowerPoint-Präsentation in C# oder .NET anzeigen"
---



Aspose.Slides für .NET wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können durch das Öffnen von Präsentationen in Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch auch Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder ihren eigenen Präsentationsbetrachter erstellen. In solchen Fällen ermöglicht es Aspose.Slides für .NET, eine einzelne Folie in ein Bild zu exportieren. Dieser Artikel beschreibt, wie Sie dies tun können. 
## **Live-Beispiel**
Sie können die [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) kostenlose App ausprobieren, um zu sehen, was Sie mit der Aspose.Slides API implementieren können:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **SVG-Bild aus Folie generieren**
Um ein SVG-Bild aus einer gewünschten Folie mit Aspose.Slides.PPTX für .NET zu generieren, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz der gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
- Holen Sie das SVG-Bild in einem Speicherstream.
- Speichern Sie den Speicherstream in einer Datei.

```c#
// Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt

using (Presentation pres = new Presentation("CreateSlidesSVGImage.pptx"))
{

    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Erstellen Sie ein Speicherstream-Objekt
    MemoryStream SvgStream = new MemoryStream();

    // Generieren Sie das SVG-Bild der Folie und speichern Sie es im Speicherstream
    sld.WriteAsSvg(SvgStream);
    SvgStream.Position = 0;

    // Speichern Sie den Speicherstream in einer Datei
    using (Stream fileStream = System.IO.File.OpenWrite("Aspose_out.svg"))
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            fileStream.Write(buffer, 0, len);
        }

    }
    SvgStream.Close();
}
```


## **SVG mit benutzerdefinierten Form-IDs generieren**
Aspose.Slides für .NET kann verwendet werden, um [SVG ](https://docs.fileformat.com/page-description-language/svg/)aus einer Folie mit benutzerdefinierter Form-ID zu generieren. Dazu verwenden Sie die ID Eigenschaft von [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape), die die benutzerdefinierte ID von Formen im generierten SVG darstellt. Der CustomSvgShapeFormattingController kann verwendet werden, um die Form-ID festzulegen.

```c#
using (Presentation pres = new Presentation("pptxFileName.pptx"))
{
    using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate))
    {
        SVGOptions svgOptions = new SVGOptions
        {
            ShapeFormattingController = new CustomSvgShapeFormattingController()
        };

        pres.Slides[0].WriteAsSvg(stream, svgOptions);
    }
}
```



```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
	private int m_shapeIndex;
	
	public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
	{
		m_shapeIndex = shapeStartIndex;
	}

	public void FormatShape(ISvgShape svgShape, IShape shape)
	{
		svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
	}
}
```


## **Thumbnails von Folien erstellen**
Aspose.Slides für .NET hilft Ihnen, Thumbnail-Bilder der Folien zu generieren. Um das Thumbnail einer gewünschten Folie mit Aspose.Slides für .NET zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

```c#
// Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
using (Presentation pres = new Presentation("ThumbnailFromSlide.pptx"))
{
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Erstellen Sie ein Bild in voller Größe
    using (IImage image = sld.GetImage(1f, 1f))
    {
        // Speichern Sie das Bild auf der Festplatte im JPEG-Format
        image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **Thumbnail mit benutzerdefinierten Abmessungen erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

```c#
// Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
using (Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx"))
{

    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Benutzerdefinierte Dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Berechnung der skalieren Werte von X und Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;


    // Erstellen Sie ein Bild in voller Größe
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // Speichern Sie das Bild auf der Festplatte im JPEG-Format
        image.Save("Thumbnail2_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **Thumbnail aus Folie in der Notizenansicht erstellen**
Um das Thumbnail einer gewünschten Folie in der Notizenansicht mit Aspose.Slides für .NET zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab in der Notizenansicht.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

Der folgende Code erzeugt ein Thumbnail der ersten Folie einer Präsentation in der Notizenansicht.

```c#
// Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
using (Presentation pres = new Presentation("ThumbnailFromSlideInNotes.pptx"))
{
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Benutzerdefinierte Dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Berechnung der skalieren Werte von X und Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // Erstellen Sie ein Bild in voller Größe                
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // Speichern Sie das Bild auf der Festplatte im JPEG-Format
        image.Save("Notes_tnail_out.jpg", ImageFormat.Jpeg);
    }
}
```