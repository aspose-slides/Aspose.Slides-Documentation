---
title: Form-Miniaturbilder erstellen
type: docs
weight: 70
url: /de/net/create-shape-thumbnails/
keywords:
- Form-Miniaturbild
- Formbild
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Extrahieren Sie Form-Miniaturbilder aus PowerPoint-Präsentationen in C# oder .NET"
---

Aspose.Slides für .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Manchmal müssen Entwickler jedoch die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides für .NET Ihnen, Miniaturbilder der Folienformen zu erzeugen. Wie Sie diese Funktion nutzen, wird in diesem Artikel beschrieben.

Dieser Artikel erklärt, wie Miniaturbilder von Folien auf verschiedene Arten erzeugt werden:

- Erzeugen eines Shape‑Miniaturbilds innerhalb einer Folie.  
- Erzeugen eines Shape‑Miniaturbilds für eine Folienform mit benutzerdefinierten Abmessungen.  
- Erzeugen eines Shape‑Miniaturbilds im Begrenzungsrahmen des Aussehens einer Form.  
- Erzeugen eines Miniaturbilds eines SmartArt‑Kindknotens.

## **Shape‑Miniaturbild aus Folie generieren**
Um ein Shape‑Miniaturbild aus einer beliebigen Folie mit Aspose.Slides für .NET zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.  
1. Rufen Sie die Referenz einer beliebigen Folie über deren ID oder Index ab.  
1. Holen Sie das Shape‑Miniaturbild der referenzierten Folie in der Standardskala.  
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das untenstehende Beispiel erzeugt ein Shape‑Miniaturbild.  
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


## **Benutzerdefiniertes Skalierungsfaktor‑Miniaturbild generieren**
Um das Shape‑Miniaturbild einer beliebigen Folienform mit Aspose.Slides für .NET zu erzeugen:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.  
1. Rufen Sie die Referenz einer beliebigen Folie über deren ID oder Index ab.  
1. Holen Sie das Miniaturbild der referenzierten Folie mit Formbegrenzungen.  
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das untenstehende Beispiel erzeugt ein Miniaturbild mit benutzerdefiniertem Skalierungsfaktor.  
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


## **Miniaturbild des Erscheinungsbildes einer Form im Begrenzungsrahmen erstellen**
Diese Methode zum Erstellen von Miniaturbildern von Formen ermöglicht es Entwicklern, ein Miniaturbild im Begrenzungsrahmen des Erscheinungsbildes der Form zu erzeugen. Sie berücksichtigt alle Formeffekte. Das erzeugte Shape‑Miniaturbild ist durch die Folienbegrenzungen eingeschränkt. Um ein Miniaturbild einer beliebigen Folienform im Begrenzungsrahmen ihres Erscheinungsbildes zu erzeugen, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.  
1. Rufen Sie die Referenz einer beliebigen Folie über deren ID oder Index ab.  
1. Holen Sie das Miniaturbild der referenzierten Folie mit Formbegrenzungen als Erscheinungsbild.  
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das untenstehende Beispiel erstellt ein Miniaturbild mit benutzerdefiniertem Skalierungsfaktor.  
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


## **FAQ**

**Welche Bildformate können beim Speichern von Shape‑Thumbnails verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), und andere. Shapes können auch als Vektor‑SVG [exportiert werden]((https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Begrenzungen beim Rendern eines Thumbnails?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als verborgen markiert ist? Wird sie trotzdem als Thumbnail gerendert?**

Eine verborgene Form bleibt Teil des Modells und kann gerendert werden; das Verborgense‑Flag beeinflusst die Anzeige in der Diashow, verhindert jedoch nicht das Erzeugen des Bildes der Form.

**Werden Gruppenformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](/slides/de/net/shape/) dargestellt wird (einschließlich [GroupShape](/slides/de/net/groupshape/), [Chart](/slides/de/net/charts/chart/), und [SmartArt](/slides/de/net/smartart/smartart/)), kann als Thumbnail oder als SVG gespeichert werden.

**Wirken sich systeminstallierte Schriftarten auf die Qualität von Thumbnails für Textformen aus?**

Ja. Sie sollten die erforderlichen Schriftarten [bereitstellen](/slides/de/net/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/net/font-substitution/)), um unerwünschte Fallbacks und Textumfluss zu vermeiden.