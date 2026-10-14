---
title: PowerPoint-Formen in .NET formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzeneffekt
- Formlinien skizzieren
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz-weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Abrundungseffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in C# mit Aspose.Slides formatieren - Füll-, Linien- und Effektstile für PPT- und PPTX-Dateien präzise und vollständig steuern."
---
## **Einführung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie ihre Innenbereiche gefüllt werden.

![Formformat-PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für .NET stellt Schnittstellen und Eigenschaften bereit, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) der Form.
1. Legen Sie die Linienstärke fest.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) der Linie.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende C#‑Code demonstriert, wie ein Rechteck‑`AutoShape` formatiert wird:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Legen Sie die Füllfarbe für die Rechteckform fest.
    shape.FillFormat.FillType = FillType.NoFill;

    // Wenden Sie die Formatierung auf die Linien des Rechtecks an.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Legen Sie die Farbe für die Linie des Rechtecks fest.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt eine Formlinie handgezeichnet wirken. Verwenden Sie [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/), um auf die Linieneinstellungen zuzugreifen, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/), um auf die Skizzeinstellungen zuzugreifen, und [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) auszuwählen.

Der folgende C#‑Code zeigt, wie der Effekt [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) angewendet, der explizit zugewiesene Wert ausgelesen und der Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) entfernt wird:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Greifen Sie auf das Linienformat der Form und dessen Skizzenformat zu.
var sketchFormat = shape.LineFormat.SketchFormat;

// Wenden Sie einen Skizzeneffekt an.
sketchFormat.SketchType = LineSketchType.Curved;

// Lesen Sie den direkt der Form zugewiesenen Skizzeneffekt.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Entfernen Sie den Skizzeneffekt.
sketchFormat.SketchType = LineSketchType.None;
```

Der von `ISketchFormat.SketchType` zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Design, einer Master‑Folien oder einer Layout‑Folien geerbt werden kann, verwenden Sie [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), greifen Sie auf [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) zu und lesen Sie [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Der effektive Wert spiegelt die Formatierung wider, die tatsächlich nach Auflösung der Vererbung angewendet wird:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Verbindungsstil formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint, wenn es zwei Linien an einem Winkel (z. B. an einer Formkante) verbindet, die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Gehrung**.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende C#‑Code demonstriert, wie drei Rechtecke (wie im obigen Bild gezeigt) mit den Verbindungstypen Gehrung, Fase und Rund erstellt wurden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie drei AutoShapes vom Typ Rechteck hinzu.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Legen Sie die Füllfarbe für jede Rechteckform fest.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Legen Sie die Linienstärke fest.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Legen Sie die Farbe für die Linie jedes Rechtecks fest.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Legen Sie den Verbindungsstil fest.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Fügen Sie jedem Rechteck Text hinzu.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Sie können z. B. zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden gewünschten Farben mit definierten Positionen über die `Add`‑Methoden der Gradient‑Stop‑Sammlung hinzu, die von der Schnittstelle [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende C#‑Code demonstriert, wie ein Farbverlauf auf eine Ellipse angewendet wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Legen Sie die Richtung des Verlaufs fest.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Fügen Sie zwei Verlaufsstopps hinzu.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

Wenn ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Sie können einen Renderstil auswählen, ohne die im Dokument gespeicherte Verlaufsfüllung zu ändern.

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einem Formobjekt ein zweifarbiges Design – wie Punkte, Streifen, Kreuzschraffuren oder Karos – zuweisen können. Sie können für Vorder‑ und Hintergrund des Musters eigene Farben wählen.

Aspose.Slides bietet über 45 vordefinierte Musterstile, die Sie auf Formen anwenden können, um das visuelle Erscheinungsbild Ihrer Präsentationen zu verbessern. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende C#‑Code demonstriert, wie eine Musterfüllung auf ein Rechteck angewendet wird:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Legen Sie den Fülltyp auf Muster fest.
    shape.FillFormat.FillType = FillType.Pattern;

    // Legen Sie den Musterstil fest.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Legen Sie die Hintergrund- und Vordergrundfarben des Musters fest.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einbetten – das Bild dient dabei als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllmodus auf `Tile` (oder einen anderen gewünschten Modus).
1. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)-Objekt aus dem Bild, das Sie verwenden möchten.
1. Weisen Sie dieses Bild der Eigenschaft `Picture.Image` des `PictureFillFormat` der Form zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Angenommen, wir haben die Datei „lotus.png“ mit dem folgenden Bild:

![Das Lotus‑Bild](lotus.png)

Der folgende C#‑Code demonstriert, wie eine Form mit dem Bild gefüllt wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Setzen Sie den FillType auf Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Setzen Sie den PictureFillMode.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Setzen Sie das Bild.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Eigenschaften des Interfaces [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) verwenden:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Legt den Bildfüllmodus fest – entweder `Tile` oder `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Bestimmt, ob die Kachel horizontal, vertikal oder beide Richtungen gespiegelt wird.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Der folgende Beispielcode zeigt, wie ein Rechteck mit gekachelter Bildfüllung hinzugefügt und die Kacheloptionen konfiguriert werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide firstSlide = presentation.Slides[0];

    // Fügen Sie eine Rechteck-AutoShape hinzu.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den FillType der Form auf Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Weisen Sie das Bild der Form zu.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurieren Sie den Bildfüllmodus und die Kachelageeigenschaften.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese einheitliche Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre gewünschte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende C#‑Code demonstriert, wie Sie eine einfarbige Füllung auf ein Rechteck in einer PowerPoint‑Folientabelle anwenden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den FillType auf Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Setzen Sie die Füllfarbe.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, Verlauf‑, Bild‑ oder Texturfüllung von Formen auch einen Transparenzwert festlegen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzwerts, indem Sie den Alphawert in der für die Füllung verwendeten Farbe anpassen. So gehen Sie vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color.FromArgb(alpha, baseColor)`, um eine Farbe mit Transparenz zu definieren (der `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende C#‑Code demonstriert, wie Sie einer Rechteckform eine transparente Füllfarbe zuweisen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie ein festes Rechteck-AutoShape hinzu.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fügen Sie ein transparentes Rechteck-AutoShape über der festen Form hinzu.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, um visuelle Elemente mit bestimmter Ausrichtung oder Designanforderungen zu positionieren.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Eigenschaft `Rotation` der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code demonstriert, wie Sie eine Form um 5 Grad drehen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Drehen Sie die Form um 5 Grad.
    shape.Rotation = 5;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Abrundungseffekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Abrundungseffekten zu Formen, indem Sie die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) konfigurieren.

So fügen Sie einer Form 3D‑Abrundungseffekte hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) der Form, um die Abrundungseinstellungen festzulegen.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code zeigt, wie Sie 3D‑Abrundungseffekte auf eine Form anwenden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellen Sie eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügen Sie der Folie eine Form hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Setzen Sie die ThreeDFormat-Eigenschaften der Form.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Speichern Sie die Präsentation als PPTX-Datei.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der 3D‑Abrundungseffekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Drehungseffekten zu Formen, indem Sie die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) konfigurieren.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie über den Index eine Referenz auf eine Folie ab.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) und den [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) der Form, um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code demonstriert, wie Sie 3D‑Drehungseffekte auf eine Form anwenden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellen Sie eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Speichern Sie die Präsentation als PPTX-Datei.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der 3D‑Drehungseffekt](3D-rotation-effect.png)

## **Schwarz‑weiß‑Darstellung für Formen steuern**

Die Eigenschaft [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) gibt an, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑weiß‑Anzeige nicht selbst und ändert die Füll‑, Linien‑ oder sonstige Formatierung im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die Renderanwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Grautöne, `BlackWhite` nutzt nur Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` bewahrt die normale Farbdarstellung, und `Hidden` lässt die Form im Schwarz‑weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein Form‑ebene Modus zugewiesen ist.

Der folgende C#‑Code erstellt eine farbige Form und lässt sie im Schwarz‑weiß‑Anzeige‑Modus grau erscheinen:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Behalten Sie die orange Füllung im Farbmodus bei, aber rendern Sie die Form mit grauer Färbung im Schwarz-weiß-Modus.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. In einem Schwarz‑weiß‑Anzeige‑Workflow wird es grau dargestellt, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine Voll‑Farb‑Folien‑Präsentation erhalten und gleichzeitig ein separates Aussehen für den Druck, die Vorschau oder andere Workflows definieren, die die Schwarz‑weiß‑Anzeige‑Einstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende C#‑Code zeigt, wie Sie die Formatierung einer Folie zurücksetzen und Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) auf deren Standardwerte zurücksetzen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Setzt jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien beanspruchen den größten Teil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, behandeln Sie die Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten gestylten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.