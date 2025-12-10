---
title: Verwalten von Präsentationsplatzhaltern in .NET
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/net/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Hinweistext
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Müheloses Verwalten von Platzhaltern in Aspose.Slides für .NET: Text ersetzen, Hinweistexte anpassen und Bildtransparenz in PowerPoint und OpenDocument festlegen."
---

## **Text in einem Platzhalter ändern**
Mit [Aspose.Slides for .NET](/slides/de/net/) können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es, den Text in einem Platzhalter zu ändern.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Eine solche Präsentation können Sie in der Standard‑Microsoft‑PowerPoint‑App erstellen.

So verwenden Sie Aspose.Slides, um den Text im Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Durchlaufen Sie die Formen, um den Platzhalter zu finden.
4. Typkonvertieren Sie die Platzhalterform zu einer [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) und ändern Sie den Text mithilfe des [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/), das mit der [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) verknüpft ist. 
5. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie man den Text in einem Platzhalter ändert:
```c#
 // Instanziert eine Presentation‑Klasse
 using (Presentation pres = new Presentation("ReplacingText.pptx"))
 {
 
     // Greift auf die erste Folie zu
     ISlide sld = pres.Slides[0];
 
     // Durchläuft die Formen, um den Platzhalter zu finden
     foreach (IShape shp in sld.Shapes)
         if (shp.Placeholder != null)
         {
             // Ändert den Text in jedem Platzhalter
             ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
         }
 
     // Speichert die Präsentation auf dem Datenträger
     pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```



## **Prompt‑Text in einem Platzhalter festlegen**
Standard‑ und vordefinierte Layouts enthalten Platzhalter‑Prompt‑Texte wie ***Klicken Sie, um einen Titel hinzuzufügen*** oder ***Klicken Sie, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Prompt‑Texte in Platzhalter‑Layouts einfügen.

Dieser C#‑Code zeigt, wie Sie den Prompt‑Text in einem Platzhalter festlegen:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Durchläuft die Folie
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint zeigt "Klicken Sie, um einen Titel hinzuzufügen"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Fügt Untertitel hinzu
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```


## **Transparenz für Platzhalter‑Bild festlegen**

Aspose.Slides ermöglicht es, die Transparenz des Hintergrundbilds in einem Textplatzhalter festzulegen. Durch Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (abhängig von den Farben von Text und Bild).

Dieser C#‑Code zeigt, wie Sie die Transparenz für einen Bildhintergrund (innerhalb einer Form) festlegen:
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


## **FAQ**

**Was ist ein Basis‑Platzhalter und wie unterscheidet er sich von einer lokalen Form auf einer Folie?**

Ein Basis‑Platzhalter ist die ursprüngliche Form in einem Layout oder Master, von der die Folien‑Form erbt – Typ, Position und einige Formatierungen stammen daraus. Eine lokale Form ist unabhängig; gibt es keinen Basis‑Platzhalter, findet keine Vererbung statt.

**Wie kann ich alle Titel oder Beschriftungen einer Präsentation aktualisieren, ohne jede Folie zu durchlaufen?**

Bearbeiten Sie den entsprechenden Platzhalter im Layout oder im Master. Folien, die auf diesen Layouts bzw. diesem Master basieren, übernehmen die Änderung automatisch.

**Wie steuere ich die Standard‑Header/Footer‑Platzhalter – Datum & Uhrzeit, Foliennummer und Fußzeilentext?**

Verwenden Sie die HeaderFooter‑Manager im jeweiligen Gültigkeitsbereich (normale Folien, Layouts, Master, Notizen/Handzettel), um diese Platzhalter ein‑ oder auszuschalten und deren Inhalt festzulegen.