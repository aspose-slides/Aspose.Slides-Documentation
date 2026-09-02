---
title: PowerPoint‑Formen formatieren in .NET
linktitle: Formformatierung
type: docs
weight: 20
url: /de/net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen‑Effekt
- Skizzen‑Linie der Form
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Form‑Transparenz
- Form drehen
- 3D‑Abrundungseffekt
- 3D‑Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Formen in C# mit Aspose.Slides formatieren – füllen, Linien‑ und Effekteinstellungen für PPT‑ und PPTX‑Dateien präzise und vollständig steuern."
---
## **Einführung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenbereiche gefüllt werden.

![Form in PowerPoint formatieren](format-shape-powerpoint.png)

Aspose.Slides für .NET stellt Schnittstellen und Eigenschaften bereit, mit denen Sie Formen mit denselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Der Vorgang wird in den folgenden Schritten beschrieben:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Legen Sie den [Linienstil](https://reference.aspose.com/slides/de/net/aspose.slides/linestyle/) der Form fest.
1. Legen Sie die Linienbreite fest.
1. Legen Sie den [Strichstil](https://reference.aspose.com/slides/de/net/aspose.slides/linedashstyle/) der Linie fest.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende C#‑Code zeigt, wie man ein Rechteck‑`AutoShape` formatiert:

```c#
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

## **Skizze‑Effekte auf Formlinien anwenden**

Ein Skizze‑Effekt lässt die Linie einer Form handgezeichnet wirken. Verwenden Sie [IShape.LineFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/lineformat/), um auf die Linieneinstellungen zuzugreifen, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ilineformat/sketchformat/), um auf die Skizzen‑Einstellungen zuzugreifen, und [ISketchFormat.SketchType](https://reference.aspose.com/slides/de/net/aspose.slides/isketchformat/sketchtype/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/net/aspose.slides/linesketchtype/) auszuwählen.

Der folgende C#‑Code zeigt, wie man einen [LineSketchType.Curved](https://reference.aspose.com/slides/de/net/aspose.slides/linesketchtype/)-Effekt anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/de/net/aspose.slides/linesketchtype/) entfernt:

```csharp
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

Der von `ISketchFormat.SketchType` zurückgegebene Wert repräsentiert die direkt der Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Design, einer Master‑Folie oder einer Layout‑Folie geerbt werden kann, verwenden Sie [ILineFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/ilineformat/geteffective/), greifen Sie auf [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ilineformateffectivedata/sketchformat/) zu und lesen Sie [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/de/net/aspose.slides/isketchformateffectivedata/sketchtype/). Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

```csharp
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

Hier sind die drei Optionen für den Verbindungs­typ:

* Rund
* Gehrung
* Abschrägung

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (wie an einer Form­ecke) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Gehrung**.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende C#‑Code zeigt, wie drei Rechtecke (wie im obigen Bild) mit den Verbindungs­typ‑Einstellungen Gehrung, Abschrägung und Rund erstellt wurden:

```c#
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

    // Legen Sie die Linienbreite fest.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Legen Sie die Farbe für jede Rechtecklinie fest.
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

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbverlauf zuweisen können. Sie können zum Beispiel zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden gewünschten Farben mit definierten Positionen mithilfe der `Add`‑Methoden der Gradient‑Stop‑Sammlung hinzu, die vom Interface [IGradientFormat](https://reference.aspose.com/slides/de/net/aspose.slides/igradientformat/) bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```c#
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

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form ein zweifarbiges Design – wie Punkte, Streifen, Kreuzschraffuren oder Karos – zuweisen können. Sie können benutzerdefinierte Farben für den Vorder‑ und Hintergrund des Musters auswählen.

Aspose.Slides bietet über 45 vordefinierte Musterstile, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu erhöhen. Selbst nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Legen Sie die [Background Color](https://reference.aspose.com/slides/de/net/aspose.slides/ipatternformat/backcolor/) des Musters fest.
1. Legen Sie die [Foreground Color](https://reference.aspose.com/slides/de/net/aspose.slides/ipatternformat/forecolor/) des Musters fest.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Muster.
    shape.FillFormat.FillType = FillType.Pattern;

    // Legen Sie den Musterstil fest.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einfügen können – das Bild dient dabei effektiv als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) der Form auf `Picture`.
1. Legen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen bevorzugten Modus) fest.
1. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Weisen Sie dieses Bild der Eigenschaft `Picture.Image` des `PictureFillFormat` der Form zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Angenommen, wir haben eine Datei „lotus.png“ mit folgendem Bild:

![Das Lotus‑Bild](lotus.png)

```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Setzen Sie den FillType auf Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Setzen Sie den Bildfüllungsmodus.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Bild festlegen.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein Bild als Textur kacheln und das Kachel‑Verhalten anpassen möchten, können Sie die folgenden Eigenschaften des [IPictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/)‑Interfaces und der [PictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/)‑Klasse verwenden:

- [PictureFillMode](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/picturefillmode/): Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [TileFlip](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tileflip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [TileOffsetX](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tileoffsetx/): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [TileOffsetY](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tileoffsety/): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [TileScaleX](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tilescalex/): Definiert die horizontale Skalierung der Kachel in Prozent.
- [TileScaleY](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/tilescaley/): Definiert die vertikale Skalierung der Kachel in Prozent.

Der folgende Codebeispiel zeigt, wie man ein Rechteck mit einer gekachelten Bildfüllung hinzufügt und Kachel‑Optionen konfiguriert:

```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide firstSlide = presentation.Slides[0];

    // Fügen Sie eine Rechteck-AutoShape hinzu.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Bild der Form zuweisen.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurieren Sie den Bildfüllungsmodus und die Kacheleigenschaften.
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

![Die Kachel‑Optionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese einfache Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

Um eine einfarbige Füllung auf eine Form mit Aspose.Slides anzuwenden, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```c#
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

In PowerPoint können Sie beim Anwenden einer einfarbigen, Verlauf‑, Bild‑ oder Texturfüllung auf Formen zudem einen Transparenzwert festlegen, der die Deckkraft der Füllung steuert. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzwerts, indem der Alpha‑Wert der für die Füllung verwendeten Farbe angepasst wird. So geht's:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color.FromArgb(alpha, baseColor)`, um eine Farbe mit Transparenz zu definieren (der `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

```c#
const int alpha = 128;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine feste rechteckige AutoShape hinzu.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente rechteckige AutoShape über der festen Form hinzu.
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

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Das kann nützlich sein, wenn visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen positioniert werden sollen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Eigenschaft `Rotation` der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

```c#
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

Aspose.Slides ermöglicht es, 3D‑Abrundungseffekte auf Formen anzuwenden, indem deren [ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/)‑Eigenschaften konfiguriert werden.

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/) der Form, um die Abrundungseinstellungen festzulegen.
1. Speichern Sie die Präsentation.

```c#
// Instanz der Presentation-Klasse erstellen.
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

    // Setzen Sie die ThreeDFormat‑Eigenschaften der Form.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Speichern Sie die Präsentation als PPTX‑Datei.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der 3D‑Abrundungseffekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht es, 3D‑Drehungseffekte auf Formen anzuwenden, indem deren [ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/)‑Eigenschaften konfiguriert werden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die [CameraType](https://reference.aspose.com/slides/de/net/aspose.slides/icamera/cameratype/)‑ und [LightType](https://reference.aspose.com/slides/de/net/aspose.slides/ilightrig/lighttype/)‑Eigenschaften der Form, um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

```c#
// Instanz der Presentation-Klasse erstellen.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Speichern Sie die Präsentation als PPTX-Datei.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der 3D‑Drehungseffekt](3D-rotation-effect.png)

## **Formatierung zurücksetzen**

Der folgende C#‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/layoutslide/) auf ihre Standardwerte zurückgesetzt wird:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Jede Form auf der Folie zurücksetzen, die einen Platzhalter im Layout hat.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Beeinflusst die Form­formatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien beanspruchen den Großteil des Dateiraums, während Form‑Parameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung aufweisen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füll‑, Linien‑ und Effekt­einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einer Vorlage‑Folien‑Deck oder einer .POTX‑Vorlagendatei. Öffnen Sie beim Erstellen einer neuen Präsentation die Vorlage, klonen Sie die benötigten stilisierten Formen und wenden Sie deren Formatierung dort an, wo sie gebraucht wird.