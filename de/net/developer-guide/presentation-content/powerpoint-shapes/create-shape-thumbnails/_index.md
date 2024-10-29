---
title: Erstellen von Formminiaturen
type: docs
weight: 70
url: /de/net/create-shape-thumbnails/
keywords: 
- Formminiatur
- Bild der Form
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Extrahieren von Formminiaturen aus PowerPoint-Präsentationen in C# oder .NET"
---

Aspose.Slides für .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite ein Folienblatt ist. Diese Folien können durch Öffnen der Präsentationsdateien mit Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides für .NET, Miniaturbilder der Folienformen zu generieren. Wie man diese Funktion nutzt, wird in diesem Artikel beschrieben. Dieser Artikel erklärt, wie man Folienminiaturen auf verschiedene Weise generiert:

- Generierung einer Formminiatur innerhalb einer Folie.
- Generierung einer Formminiatur für eine Folienform mit benutzerdefinierten Abmessungen.
- Generierung einer Formminiatur im Rahmen des Erscheinungsbilds einer Form.
- Generierung einer Miniaturansicht eines SmartArt-Kindknotens.


## **Generieren Sie eine Formminiatur aus einer Folie**
Um eine Formminiatur aus einer beliebigen Folie mithilfe von Aspose.Slides für .NET zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich das Bild der Formminiatur der referenzierten Folie im Standardmaßstab.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel generiert eine Formminiatur.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **Generieren Sie eine Miniatur mit benutzerdefiniertem Skalierungsfaktor**
Um die Formminiatur einer beliebigen Folienform mithilfe von Aspose.Slides für .NET zu generieren:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich das Miniaturbild der referenzierten Folie mit Formgrenzen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel generiert eine Miniatur mit einem benutzerdefinierten Skalierungsfaktor.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Skalierung entlang der X- und Y-Achsen.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **Erstellen Sie eine Miniatur des Erscheinungsbilds der Form**
Diese Methode zur Erstellung von Miniaturen von Formen ermöglicht es Entwicklern, eine Miniatur im Rahmen des Erscheinungsbilds der Form zu erzeugen. Sie berücksichtigt alle Formeffekte. Die erzeugte Formminiatur wird durch die Foliengrenzen eingeschränkt. Um eine Miniaturansicht einer beliebigen Folienform im Rahmen ihres Erscheinungsbilds zu generieren, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich das Miniaturbild der referenzierten Folie mit Formgrenzen als Erscheinungsbild.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel erstellt eine Miniatur mit einer Miniaturansicht mit benutzerdefiniertem Skalierungsfaktor.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Skalierung entlang der X- und Y-Achsen.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```