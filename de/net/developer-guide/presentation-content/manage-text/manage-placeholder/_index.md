---
title: Platzhalter verwalten
type: docs
weight: 10
url: /net/manage-placeholder/
keywords: "Platzhalter, Platzhaltertext, Eingabetext, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Ändern Sie Platzhaltertext und Eingabetext in PowerPoint-Präsentationen in C# oder .NET"
---

## **Text im Platzhalter ändern**
Mit [Aspose.Slides für .NET](/slides/net/) können Sie Platzhalter auf Folien in Präsentationen finden und bearbeiten. Aspose.Slides ermöglicht es Ihnen, Änderungen am Text in einem Platzhalter vorzunehmen.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Sie können eine solche Präsentation in der Standardanwendung Microsoft PowerPoint erstellen.

So verwenden Sie Aspose.Slides, um den Text im Platzhalter in dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und übergeben Sie die Präsentation als Argument.
2. Erhalten Sie eine Folienreferenz über ihren Index.
3. Durchlaufen Sie die Formen, um den Platzhalter zu finden.
4. Typecasten Sie die Platzhalterform zu einer [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) und ändern Sie den Text mithilfe des [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/), das mit der [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) verknüpft ist.
5. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt, wie Sie den Text in einem Platzhalter ändern:

```c#
// Instanziiert eine Presentation-Klasse
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Durchläuft die Formen, um den Platzhalter zu finden
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Ändert den Text in jedem Platzhalter
            ((IAutoShape)shp).TextFrame.Text = "Das ist ein Platzhalter";
        }

    // Speichert die Präsentation auf der Festplatte
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Eingabetext im Platzhalter festlegen**
Standard- und vorgefertigte Layouts enthalten Platzhalter-Eingabetexte wie ***Klicken Sie, um einen Titel hinzuzufügen*** oder ***Klicken Sie, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Eingabetexte in Platzhalter-Layout einfügen.

Dieser C#-Code zeigt Ihnen, wie Sie den Eingabetext in einem Platzhalter festlegen:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Durchläuft die Folie
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint zeigt "Klicken Sie, um einen Titel hinzuzufügen" an
            {
                text = "Titel hinzufügen";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Fügt Untertitel hinzu
            {
                text = "Untertitel hinzufügen";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Platzhalter mit Text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Transparenz des Platzhalterbildes festlegen**

Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbildes in einem Textplatzhalter festzulegen. Durch Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (abhängig von den Farben des Textes und des Bildes).

Dieser C#-Code zeigt Ihnen, wie Sie die Transparenz für einen Bildhintergrund (innerhalb einer Form) festlegen:

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```