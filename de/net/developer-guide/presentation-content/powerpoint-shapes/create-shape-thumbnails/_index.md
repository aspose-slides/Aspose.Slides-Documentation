---
title: Miniaturansichten von Präsentationsformen in .NET erstellen
linktitle: Form-Miniaturansichten
type: docs
weight: 70
url: /de/net/create-shape-thumbnails/
keywords:
- Form-Miniaturansicht
- Formbild
- Form rendern
- Form-Rendering
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erzeugen Sie hochqualitative Form‑Miniaturansichten aus PowerPoint‑Folien mit Aspose.Slides für .NET – erstellen und exportieren Sie Präsentations‑Miniaturansichten ganz einfach."
---

Aspose.Slides für .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Manchmal müssen Entwickler jedoch die Bilder der Formen separat in einem Bildbetrachter anzeigen. In solchen Fällen hilft Aspose.Slides für .NET beim Erzeugen von Miniaturbildern der Folienformen. Wie diese Funktion verwendet wird, wird in diesem Artikel beschrieben.

Dieser Artikel erklärt, wie man Folien‑Miniaturbilder auf verschiedene Arten erzeugt:

- Erzeugen einer Form‑Miniaturansicht innerhalb einer Folie.
- Erzeugen einer Form‑Miniaturansicht für eine Folienform mit benutzerdefinierten Abmessungen.
- Erzeugen einer Form‑Miniaturansicht innerhalb der Grenzen des Erscheinungsbilds einer Form.
- Erzeugen einer Miniaturansicht eines SmartArt‑Kindknotens.

## **Form‑Miniaturansicht aus Folie erzeugen**
Um mit Aspose.Slides für .NET aus einer beliebigen Folie eine Form‑Miniaturansicht zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index ab.
1. Holen Sie das Form‑Miniaturbild der referenzierten Folie mit Standardmaßstab.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel erzeugt eine Form‑Miniaturansicht.
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


## **Miniaturansicht mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um die Form‑Miniaturansicht einer beliebigen Folienform mit Aspose.Slides für .NET zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse `Presentation`.
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index ab.
1. Holen Sie das Miniaturbild der referenzierten Folie mit Formgrenzen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel erzeugt ein Miniaturbild mit einem benutzerdefinierten Skalierungsfaktor.
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


## **Miniaturansicht des Erscheinungsbilds einer Form in Grenzen erstellen**
Diese Methode zum Erstellen von Miniaturansichten von Formen ermöglicht es Entwicklern, eine Miniaturansicht innerhalb der Grenzen des Erscheinungsbilds einer Form zu erzeugen. Sie berücksichtigt alle Formeffekte. Die erzeugte Form‑Miniaturansicht ist durch die Foliengrenzen eingeschränkt. Um eine Miniaturansicht einer beliebigen Folienform innerhalb ihrer Darstellung zu erzeugen, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der Klasse `Presentation`.
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index ab.
1. Holen Sie das Miniaturbild der referenzierten Folie mit Formgrenzen als Erscheinungsbild.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel erstellt ein Miniaturbild mit einem benutzerdefinierten Skalierungsfaktor.
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

**Welche Bildformate können beim Speichern von Form‑Miniaturansichten verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), und andere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Grenzen beim Rendern einer Miniaturansicht?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als verborgen markiert ist? Wird sie dennoch als Miniaturansicht gerendert?**

Eine verborgene Form bleibt Teil des Modells und kann gerendert werden; das Verborgenen‑Flag beeinflusst die Anzeige der Präsentation, verhindert jedoch nicht die Erstellung des Bildes der Form.

**Werden Gruppenformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), und [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)), kann als Miniaturansicht oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriften die Qualität von Miniaturansichten für Textformen?**

Ja. Sie sollten die erforderlichen Schriften [bereitstellen](/slides/de/net/custom-font/) (oder [Schriftart‑Ersatz konfigurieren](/slides/de/net/font-substitution/)), um unerwünschte Fallbacks und Textumlauf zu vermeiden.