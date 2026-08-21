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
- Skizzenformlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz-Weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Stufen-Effekt
- 3D-Dreh-Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in C# mit Aspose.Slides formatieren - füllen, Linien- und Effekt-Stile für PPT- und PPTX-Dateien präzise und vollständig steuern."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie deren Konturen formatieren, indem Sie die Linien modifizieren oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für .NET bietet Schnittstellen und Eigenschaften, mit denen Sie Formen mit denselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie einen benutzerdefinierten Linienstil für eine Form festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/de/net/aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/de/net/aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende C#‑Code zeigt, wie Sie ein Rechteck‑`AutoShape` formatieren:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie die Füllfarbe für die Rechteckform.
    shape.FillFormat.FillType = FillType.NoFill;

    // Wenden Sie Formatierungen auf die Linien des Rechtecks an.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Setzen Sie die Farbe für die Linie des Rechtecks.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizze‑Effekte auf Formlinien anwenden**

Ein Skizze‑Effekt lässt die Linien einer Form handgezeichnet wirken. Verwenden Sie [IShape.LineFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/lineformat/) , um auf die Linieneinstellungen zuzugreifen, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ilineformat/sketchformat/) , um auf die Skizzeeinstellungen zuzugreifen, und [ISketchFormat.SketchType](https://reference.aspose.com/slides/de/net/aspose.slides/isketchformat/sketchtype/) , um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/net/aspose.slides/linesketchtype/) auszuwählen.

Der folgende C#‑Code zeigt, wie Sie den Effekt [LineSketchType.Curved](https://reference.aspose.com/slides/de/net/aspose.slides/linesketchtype/) anwenden, den explizit zugewiesenen Wert auslesen und den Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/de/net/aspose.slides/linesketchtype/) entfernen:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

Der von `ISketchFormat.SketchType` zurückgegebene Wert repräsentiert die direkt an die Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Design, einer Master‑Folien‑ oder Layout‑Folie geerbt werden kann, verwenden Sie [ILineFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/ilineformat/geteffective/) , greifen Sie auf [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ilineformateffectivedata/sketchformat/) zu und lesen Sie [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/de/net/aspose.slides/isketchformateffectivedata/sketchtype/) aus. Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

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

## **Verbindungs‑Stile formatieren**

Hier sind die drei Optionen für den Verbindungs‑Typ:

* Round
* Miter
* Bevel

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien im Winkel (z. B. an einer Form‑Ecke) die Einstellung **Round**. Wenn Sie jedoch Formen mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Miter**.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende C#‑Code demonstriert, wie drei Rechtecke (wie im Bild oben) mit den Verbindungs‑Typ‑Einstellungen Miter, Bevel und Round erstellt wurden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie drei AutoShapes vom Typ Rechteck hinzu.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Setzen Sie die Füllfarbe für jede Rechteckform.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Setzen Sie die Linienbreite.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Setzen Sie die Farbe für die Linie jedes Rechtecks.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Setzen Sie den Verbindungsstil.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Fügen Sie jedem Rechteck Text hinzu.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, die es ermöglicht, einer Form einen kontinuierlichen Farbübergang zuzuweisen. Beispielsweise können Sie zwei oder mehr Farben so anwenden, dass eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen über die `Add`‑Methoden der Gradient‑Stop‑Sammlung hinzu, die über die [IGradientFormat](https://reference.aspose.com/slides/de/net/aspose.slides/igradientformat/)‑Schnittstelle bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende C#‑Code demonstriert, wie Sie einen Verlaufsfüll‑Effekt auf eine Ellipse anwenden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Farbverlaufsformatierung auf die Ellipse an.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Setzen Sie die Richtung des Farbverlaufs.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Fügen Sie zwei Farbverlaufsstopps hinzu.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form eine zweifarbige Gestaltung – wie Punkte, Streifen, Kreuzschraffuren oder Karos – zuweisen können. Sie können für den Vorder‑ und Hintergrund des Musters eigene Farben wählen.

Aspose.Slides stellt über 45 vordefinierte Musterstile zur Verfügung, die Sie auf Formen anwenden können, um das visuelle Erscheinungsbild Ihrer Präsentationen zu verbessern. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/de/net/aspose.slides/ipatternformat/backcolor/) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/de/net/aspose.slides/ipatternformat/forecolor/) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende C#‑Code zeigt, wie Sie eine Musterfüllung auf ein Rechteck anwenden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den FillType auf Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Setzen Sie den PatternStyle.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es ermöglicht, ein Bild in eine Form einzufügen – das Bild dient dabei effektiv als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüll‑Modus auf `Tile` (oder einen anderen bevorzugten Modus).
1. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Weisen Sie dieses Bild der Eigenschaft `Picture.Image` des `PictureFillFormat` der Form zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Angenommen, wir haben die Datei „lotus.png“ mit folgendem Bild:

![Das Lotus‑Bild](lotus.png)

Der folgende C#‑Code demonstriert, wie Sie eine Form mit dem Bild füllen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Setzen Sie den FillType auf Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Setzen Sie den Bildfüll‑Modus.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Laden Sie ein Bild und fügen Sie es zu den Ressourcen der Präsentation hinzu.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Setzen Sie das Bild.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kacheln‑Verhalten anpassen möchten, können Sie die folgenden Eigenschaften der Schnittstelle [IPictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/) verwenden:

- [PictureFillMode](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/picturefillmode/): Legt den Bildfüll‑Modus fest – entweder `Tile` oder `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [TileFlip](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tileflip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [TileOffsetX](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tileoffsetx/): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [TileOffsetY](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tileoffsety/): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [TileScaleX](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tilescalex/): Definiert den horizontalen Maßstab der Kachel als Prozentsatz.
- [TileScaleY](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tilescaley/): Definiert den vertikalen Maßstab der Kachel als Prozentsatz.

Der folgende Code‑Auszug zeigt, wie Sie eine Rechteck‑Form mit gekachelter Bildfüllung hinzufügen und die Kachel‑Optionen konfigurieren:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide firstSlide = presentation.Slides[0];

    // Fügen Sie eine Rechteck‑AutoShape hinzu.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den FillType der Form auf Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Laden Sie das Bild und fügen es zu den Ressourcen der Präsentation hinzu.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Weisen Sie das Bild der Form zu.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurieren Sie den Bildfüll‑Modus und die Kachel‑Eigenschaften.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Kachel‑Optionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzelnen, einheitlichen Farbe füllt. Dieser schlichte Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende C#‑Code demonstriert, wie Sie eine einfarbige Füllung auf ein Rechteck in einer PowerPoint‑Folien‑Präsentation anwenden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
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

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, Verlaufs‑, Bild‑ oder Textur‑Füllung für Formen auch einen Transparenz‑Wert festlegen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenz‑Wert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenz‑Werts, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color.FromArgb(alpha, baseColor)`, um eine Farbe mit Transparenz zu definieren (der `alpha`‑Parameter steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende C#‑Code demonstriert, wie Sie einer Rechteck‑Form eine transparente Füllfarbe zuweisen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine feste Rechteck‑AutoShape hinzu.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente Rechteck‑AutoShape über der festen Form hinzu.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn Sie visuelle Elemente mit bestimmten Ausrichtungs‑ oder Design‑Anforderungen positionieren möchten.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Eigenschaft `Rotation` der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code demonstriert, wie Sie eine Form um 5 Grad drehen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Drehen Sie die Form um 5 Grad.
    shape.Rotation = 5;

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Stufen‑Effekte hinzufügen**

Aspose.Slides erlaubt das Anwenden von 3D‑Stufen‑Effekten auf Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

So fügen Sie einer Form 3D‑Stufen‑Effekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/) der Form, um die Stufen‑Einstellungen festzulegen.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code zeigt, wie Sie 3D‑Stufen‑Effekte auf eine Form anwenden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse.
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

![Der 3D‑Stufen‑Effekt](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Aspose.Slides erlaubt das Anwenden von 3D‑Dreh‑Effekten auf Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [CameraType](https://reference.aspose.com/slides/de/net/aspose.slides/icamera/cameratype/) und [LightType](https://reference.aspose.com/slides/de/net/aspose.slides/ilightrig/lighttype/) der Form, um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code demonstriert, wie Sie 3D‑Dreh‑Effekte auf eine Form anwenden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Erzeugen Sie eine Instanz der Presentation‑Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Speichern Sie die Präsentation als PPTX‑Datei.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der 3D‑Dreh‑Effekt](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Darstellung für Formen steuern**

Die Eigenschaft [IShape.BlackWhiteMode](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/blackwhitemode/) gibt an, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert den Schwarz‑Weiß‑Modus nicht selbst und ändert die Füll‑, Linien‑ oder andere Formatierungen der Form im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/de/net/aspose.slides/blackwhitemode/) , um das gewünschte Verhalten auszuwählen. Zum Beispiel lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Graustufen, `BlackWhite` nutzt ausschließlich Schwarz und Weiß, `Black` und `White` erzwingen eine Einzelfarbe, `Color` behält die normale Farbgebung bei und `Hidden` lässt die Form im Schwarz‑Weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein Form‑bezogener Modus zugewiesen ist.

Der folgende C#‑Code erstellt eine farbige Form und lässt sie im Schwarz‑Weiß‑Anzeige‑Modus grau erscheinen:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. In einem Schwarz‑Weiß‑Anzeige‑Workflow wird es grau dargestellt, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine vollfarbige Folie beibehalten und gleichzeitig ein separates Erscheinungsbild für Druck, Vorschau oder andere Workflows definieren, die die Schwarz‑Weiß‑Anzeigeeinstellungen der Präsentation beachten.

## **Formatierung zurücksetzen**

Der folgende C#‑Code zeigt, wie Sie die Formatierung einer Folie zurücksetzen und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/layoutslide/) auf ihre Standard‑Einstellungen zurücksetzen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Setzen Sie jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Speicherplatzes, während Form‑Parameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen besitzen, um sie zu gruppieren?**

Vergleichen Sie die Schlüssel‑Formatierungseigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, behandeln Sie die Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich einen Satz benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten gestylten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.