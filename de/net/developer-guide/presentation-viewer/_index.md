---
title: Erstellen eines Präsentations-Viewers in C#
linktitle: Präsentations-Viewer
type: docs
weight: 50
url: /de/net/presentation-viewer/
keywords:
- Präsentation anzeigen
- Präsentations-Viewer
- Präsentations-Viewer erstellen
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- C#
- Csharp
- Aspose.Slides für .NET
description: "Erfahren Sie, wie Sie mit Aspose.Slides einen benutzerdefinierten Präsentations-Viewer in .NET erstellen. Zeigen Sie PowerPoint (PPTX, PPT) und OpenDocument (ODP)-Dateien einfach an, ohne Microsoft PowerPoint oder andere Office-Software."
---

## **Übersicht**

Aspose.Slides for .NET wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Entwickler müssen jedoch gelegentlich Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder sie in einem benutzerdefinierten Präsentationsbetrachter verwenden. In solchen Fällen ermöglicht Aspose.Slides den Export einzelner Folien als Bilder. Dieser Artikel erklärt, wie das funktioniert.

## **Ein SVG‑Bild aus einer Folie erzeugen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie eine Referenz auf die Folie über ihren Index.
1. Öffnen Sie einen Dateistream.
1. Speichern Sie die Folie als SVG‑Bild in den Dateistream.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```


## **Ein SVG mit einer benutzerdefinierten Shape‑ID erzeugen**

Aspose.Slides kann verwendet werden, um ein [SVG](https://docs.fileformat.com/page-description-language/svg/) aus einer Folie mit einer benutzerdefinierten Shape‑`ID` zu erzeugen. Dazu verwenden Sie die Id‑Eigenschaft des [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape)-Interfaces. Die Klasse `CustomSvgShapeFormattingController` kann verwendet werden, um die Shape‑ID festzulegen.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
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


## **Ein Folien‑Miniaturbild erstellen**

Aspose.Slides hilft Ihnen, Miniaturbilder von Folien zu erzeugen. Um mit Aspose.Slides eine Miniaturansicht einer Folie zu erstellen, befolgen Sie die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie eine Referenz auf die Folie über ihren Index.
1. Erstellen Sie ein Miniaturbild der referenzierten Folie im gewünschten Maßstab.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.
```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **Ein Folien‑Miniaturbild mit benutzerdefinierten Abmessungen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie eine Referenz auf die Folie über ihren Index.
1. Erzeugen Sie ein Miniaturbild der referenzierten Folie mit den angegebenen Abmessungen.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.
```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **Ein Folien‑Miniaturbild mit Sprecher‑Notizen erstellen**

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/)-Klasse.
1. Verwenden Sie die Eigenschaft `RenderingOptions.SlidesLayoutOptions`, um die Position der Sprecher‑Notizen festzulegen.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie eine Referenz auf die Folie über ihren Index.
1. Erzeugen Sie ein Miniaturbild der referenzierten Folie unter Verwendung der Rendering‑Optionen.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.
```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```


## **Live‑Beispiel**

Probieren Sie die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) aus, um zu sehen, was Sie mit der Aspose.Slides‑API implementieren können:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Kann ich einen Präsentationsbetrachter in einer ASP.NET‑Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als Bilder oder HTML zu rendern und im Browser anzuzeigen. Navigations‑ und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Was ist der beste Weg, Folien in einem benutzerdefinierten .NET‑Viewer anzuzeigen?**

Der empfohlene Ansatz ist, jede Folie als Bild (z. B. PNG oder SVG) zu rendern oder sie mit Aspose.Slides in HTML zu konvertieren und die Ausgabe dann in einer Bildbox (für Desktop) oder einem HTML‑Container (für Web) darzustellen.

**Wie gehe ich mit großen Präsentationen mit vielen Folien um?**

Bei großen Decks sollten Sie Lazy‑Loading oder das Rendern von Folien bei Bedarf in Betracht ziehen. Das bedeutet, den Inhalt einer Folie nur zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicher‑ und Ladezeit reduziert werden.