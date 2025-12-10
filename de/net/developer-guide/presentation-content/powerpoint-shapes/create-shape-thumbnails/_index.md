---
title: Erstellen von Miniaturansichten von Präsentationsformen in .NET
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/net/create-shape-thumbnails/
keywords:
- Form-Miniaturansicht
- Form-Bild
- Form rendern
- Form-Rendering
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen Sie hochwertige Miniaturansichten von Formen aus PowerPoint-Folien mit Aspose.Slides für .NET – einfach Präsentations-Miniaturansichten erzeugen und exportieren."
---

Aspose.Slides for .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können durch Öffnen der Präsentationsdateien mit Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides for .NET, Miniaturbilder der Folienformen zu erzeugen. Wie Sie diese Funktion nutzen, wird in diesem Artikel beschrieben.

Dieser Artikel erklärt, wie Sie Folienminiaturbilder auf verschiedene Weise erzeugen können:

- Miniaturbild einer Form innerhalb einer Folie erzeugen.
- Miniaturbild einer Form für eine Folie mit benutzerdefinierten Abmessungen erzeugen.
- Miniaturbild einer Form in den Begrenzungen des Formauftritts erzeugen.
- Miniaturbild eines SmartArt‑Kindknotens erzeugen.


## **Miniaturbild einer Form aus einer Folie erzeugen**
Um ein Miniaturbild einer Form aus einer beliebigen Folie mit Aspose.Slides for .NET zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. Rufen Sie das Miniaturbild der Form der referenzierten Folie in der Standardgröße ab.
4. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das untenstehende Beispiel erzeugt ein Miniaturbild einer Form.
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



## **Miniaturbild mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um das Miniaturbild einer beliebigen Folienform mit Aspose.Slides for .NET zu erzeugen:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. Rufen Sie das Miniaturbild der referenzierten Folie mit Formbegrenzungen ab.
4. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das untenstehende Beispiel erzeugt ein Miniaturbild mit benutzerdefiniertem Skalierungsfaktor.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Skalierung entlang X- und Y-Achsen.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```



## **Miniaturbild basierend auf den Begrenzungen des Formauftritts erzeugen**
Diese Methode zum Erstellen von Miniaturbildern von Formen ermöglicht Entwicklern, ein Miniaturbild innerhalb der Begrenzungen des Formauftritts zu erzeugen. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Miniaturbild einer Form ist durch die Folienbegrenzungen eingeschränkt. Um ein Miniaturbild einer beliebigen Folienform innerhalb ihrer Auftrittsbegrenzungen zu erzeugen, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. Rufen Sie das Miniaturbild der referenzierten Folie mit Formbegrenzungen als Auftritt ab.
4. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das untenstehende Beispiel erstellt ein Miniaturbild mit benutzerdefiniertem Skalierungsfaktor.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Skalierung entlang X- und Y-Achsen.

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

**Welche Bildformate können beim Speichern von Formminiaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), und weitere. Formen können zudem als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), indem der Forminhalt als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Bounds beim Rendern eines Miniaturbilds?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als verborgen markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine verborgene Form bleibt Teil des Modells und kann gerendert werden; das Verborgen‑Flag beeinflusst die Anzeige in der Diashow, verhindert jedoch nicht die Erzeugung des Bildes der Form.

**Werden Gruppierungsformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) repräsentiert wird (einschließlich [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), und [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)), kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systeminstallierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten [bereitstellen](/slides/de/net/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/net/font-substitution/)), um unerwünschte Rückfälle und Textumflüsse zu vermeiden.