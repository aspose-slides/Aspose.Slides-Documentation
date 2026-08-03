---
title: Erstellen von Miniaturansichten von Präsentationsformen in .NET
linktitle: Formen-Miniaturbilder
type: docs
weight: 70
url: /de/net/create-shape-thumbnails/
keywords:
- Form Miniaturbild
- Form Bild
- Form rendern
- Formrendering
- visuelle Begrenzungen
- Formbegrenzungen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erzeugen Sie hochwertige Miniaturbilder von Formen aus PowerPoint‑Folien mit Aspose.Slides für .NET – erstellen und exportieren Sie Präsentationsminiaturansichten einfach."
---
## **Einführung**

Aspose.Slides for .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Manchmal müssen Entwickler jedoch die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides for .NET Ihnen, Miniaturbilder der Folienformen zu erzeugen. Die Verwendung dieses Features wird in diesem Artikel beschrieben.  
Dieser Artikel erklärt, wie Folienminiaturbilder auf verschiedene Weise erzeugt werden können:

- Erzeugen eines Formen‑Miniaturbildes innerhalb einer Folie.  
- Erzeugen eines Formen‑Miniaturbildes für eine Folienform mit benutzerdefinierten Abmessungen.  
- Erzeugen eines Formen‑Miniaturbildes innerhalb der Begrenzungen des Erscheinungsbildes einer Form.

## **Ein Miniaturbild einer Form aus einer Folie erzeugen**
Um mit Aspose.Slides for .NET ein Miniaturbild einer Form aus einer beliebigen Folie zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)-Klasse.  
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.  
1. erhalten Sie das Miniaturbild der Form der referenzierten Folie in Standard‑Skalierung.  
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel erzeugt ein Formen‑Miniaturbild.

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

## **Ein Miniaturbild mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um das Miniaturbild einer beliebigen Folienform mit einem benutzerdefinierten Skalierungsfaktor zu erzeugen:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.  
1. erhalten Sie das Miniaturbild der referenzierten Folie mit Form‑Begrenzungen.  
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel erzeugt ein Miniaturbild mit einem benutzerdefinierten Skalierungsfaktor.

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

## **Ein Miniaturbild einer Form basierend auf Begrenzungen des Erscheinungsbildes erstellen**
Diese Methode ermöglicht es Entwicklern, ein Miniaturbild innerhalb der Begrenzungen des Erscheinungsbildes einer Form zu erzeugen. Alle Form‑Effekte werden berücksichtigt. Das erzeugte Miniaturbild ist durch die Folienbegrenzungen eingeschränkt. Um ein Miniaturbild einer beliebigen Folienform in den Begrenzungen ihres Erscheinungsbildes zu erzeugen, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.  
1. erhalten Sie das Miniaturbild der referenzierten Folie mit Form‑Begrenzungen als Erscheinungsbild.  
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das folgende Beispiel erzeugt ein Miniaturbild basierend auf den Begrenzungen des Erscheinungsbildes.

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

## **Die tatsächlichen visuellen Begrenzungen einer Form ermitteln**

Die Rahmen­eigenschaften von [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) – seine `X`, `Y`, `Width` und `Height`‑Eigenschaften – beschreiben das im Präsentationsmodell gespeicherte Rechteck. Der tatsächlich gerenderte Inhalt kann über diesen Rahmen hinausgehen oder ein anders ausgerichtetes Rechteck einnehmen. Drehung, Konturen, Pfeilspitzen, Textlayout und -überlauf, erzeugte SmartArt‑Geometrie und andere Rendering‑Effekte können den belegten Bereich verändern.

Verwenden Sie [GetVisualBounds](https://reference.aspose.com/slides/de/net/aspose.slides/shape/getvisualbounds/), um diesen belegten Bereich zu berechnen, ohne ein Bild zu erzeugen. Die Methode gibt ein [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) in Folienkoordinaten zurück. Das zurückgegebene Rechteck wird nicht auf die Folie zugeschnitten, sodass seine Koordinaten negativ sein können, wenn der Inhalt über den Folienursprung hinausreicht.

[GetVisualBounds](https://reference.aspose.com/slides/de/net/aspose.slides/shape/getvisualbounds/) ist derzeit nicht im [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/)-Interface deklariert. Behalten Sie daher die aus der Folien‑Form‑Sammlung erhaltene Form als Interface‑Wert und casten Sie sie nur beim Aufruf der Methode.

Das folgende Beispiel holt und vergleicht die Rahmen‑ und visuellen Begrenzungen:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Das gleiche [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) kann verwendet werden, um benachbarte Formen an deren `Left`, `Right`, `Top` oder `Bottom`‑Kante auszurichten; ausreichend Platz in einem erzeugten Layout zu reservieren; oder Inhalte außerhalb eines erlaubten Bereichs zu erkennen. Visuelle Begrenzungen sind besonders nützlich für SmartArt, Textfelder, Pfeile, Bilder, gedrehte Formen und Gruppierungen, bei denen der gespeicherte Rahmen nicht das vollständige gerenderte Ergebnis repräsentiert.

Verwenden Sie [GetVisualBounds](https://reference.aspose.com/slides/de/net/aspose.slides/shape/getvisualbounds/), wenn Sie Koordinaten für Layout oder Validierung benötigen und kein Bitmap benötigen. Verwenden Sie [IShape.GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/getimage/), wenn Sie die Form rendern müssen. Mit [ShapeThumbnailBounds](https://reference.aspose.com/slides/de/net/aspose.slides/shapethumbnailbounds/) bestimmt `ShapeThumbnailBounds.Shape` die Bildgröße anhand der Form‑Begrenzungen, einschließlich Kontureinstellungen, während `ShapeThumbnailBounds.Appearance` die Größe anhand des Erscheinungsbildes der Form bestimmt und das Ergebnis auf die Folienbegrenzungen beschränkt. Im Gegensatz dazu gibt [GetVisualBounds](https://reference.aspose.com/slides/de/net/aspose.slides/shape/getvisualbounds/) nur das berechnete Rechteck zurück und schneidet es nicht an die Folie zu.

## **FAQ**

**Welche Bildformate können beim Speichern von Formen‑Miniaturbildern verwendet werden?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/de/net/aspose.slides/imageformat/), und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/de/net/aspose.slides/shape/writeassvg/), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Grenzen beim Rendern eines Miniaturbildes?**  
`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visual effects](/slides/de/net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als verborgen markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**  
Eine verborgene Form bleibt Teil des Modells und kann gerendert werden; das Hidden‑Flag beeinflusst die Anzeige der Diashow, verhindert jedoch nicht das Erzeugen des Bildes der Form.

**Werden Gruppierungen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**  
Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/de/net/aspose.slides/shape/) (einschließlich [GroupShape](https://reference.aspose.com/slides/de/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/), und [SmartArt](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/smartart/)) dargestellt wird, kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systeminstallierte Schriftarten die Qualität von Miniaturbildern für Textformen?**  
Ja. Sie sollten [die erforderlichen Schriftarten bereitstellen](/slides/de/net/custom-font/) (oder [Schriftarten‑Ersetzungen konfigurieren](/slides/de/net/font-substitution/)), um ungewollte Rückfälle und Textumfluss zu vermeiden.