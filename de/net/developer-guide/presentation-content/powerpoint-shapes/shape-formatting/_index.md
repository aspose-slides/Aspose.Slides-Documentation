---
title: PowerPoint-Formen in C# formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Form drehen
- 3D-Wulsteffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Formen in C# mit Aspose.Slides formatieren – füllen, Linien‑ und Effektstile für PPT-, PPTX‑ und ODP‑Dateien präzise und vollumfänglich steuern."
---

## **Übersicht**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie deren Konturen modifizieren oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für .NET bietet Schnittstellen und Eigenschaften, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) der Form.
1. Legen Sie die Linienbreite fest.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) der Linie.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende C#‑Code demonstriert, wie man ein Rechteck‑`AutoShape` formatiert:
```c#
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Legen Sie die Füllfarbe für die Rechtecksform fest.
    shape.FillFormat.FillType = FillType.NoFill;

    // Wenden Sie die Formatierung auf die Linien des Rechtecks an.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Legen Sie die Farbe für die Linie des Rechtecks fest.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The formatted lines in the presentation](formatted-lines.png)

## **Join‑Stile formatieren**

Hier sind die drei Optionen für den Verbindungsstil:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint, wenn es zwei Linien in einem Winkel (z. B. an einer Formkante) verbindet, die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die **Gehrung**‑Option.

![The join style in the presentation](join-style-powerpoint.png)

Der folgende C#‑Code demonstriert, wie drei Rechtecke (wie im Bild oben gezeigt) mit den Join‑Typ‑Einstellungen Gehrung, Fase und Rund erstellt wurden:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie drei Autoformen vom Typ Rechteck hinzu.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Legen Sie die Füllfarbe für jede Rechtecksform fest.
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

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Beispielsweise können Sie zwei oder mehr Farben so anwenden, dass eine nach und nach in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen hinzu, indem Sie die `Add`‑Methoden der Gradient‑Stop‑Sammlung verwenden, die von der Schnittstelle [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```c#
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine Autoform vom Typ Ellipse hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Legen Sie die Richtung des Verlaufs fest.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Fügen Sie zwei Verlaufspunkte hinzu.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The ellipse with gradient fill](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Muster—wie Punkte, Streifen, Schraffuren oder Karos—auf eine Form anwenden können. Sie können benutzerdefinierte Farben für den Vorder‑ und Hintergrund des Musters wählen.

Aspose.Slides bietet über 45 vordefinierte Musterstile, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu erhöhen. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Muster.
    shape.FillFormat.FillType = FillType.Pattern;

    // Setzen Sie den Musterstil.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild in eine Form einzufügen – das Bild dient effektiv als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllmodus auf `Tile` (oder einen anderen gewünschten Modus).
1. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Weisen Sie dieses Bild der Eigenschaft `Picture.Image` des `PictureFillFormat` der Form zu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

![The lotus picture](lotus.png)

Der folgende C#‑Code demonstriert, wie man eine Form mit dem Bild füllt:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Setzen Sie den Fülltyp auf Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Setzen Sie den Bildfüllmodus.
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

![The shape with picture fill](picture-fill.png)

## **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Eigenschaften des Interfaces [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) verwenden:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Setzt den Bildfüllmodus – entweder `Tile` oder `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Das folgende Codebeispiel zeigt, wie man eine Rechteckform mit gekachelter Bildfüllung hinzufügt und die Kacheloptionen konfiguriert:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide firstSlide = presentation.Slides[0];

    // Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Weisen Sie das Bild der Form zu.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurieren Sie den Bildfüllmodus und die Kacheleigenschaften.
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

![The tile options](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Diese einfarbige Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre gewünschte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Setzen Sie die Füllfarbe.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The shape with solid color fill](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie, wenn Sie einer Form eine einfarbige, verlaufende, bild- oder texturfüllung zuweisen, zusätzlich einen Transparenzgrad festlegen, um die Deckkraft der Füllung zu steuern.

Aspose.Slides ermöglicht das Festlegen des Transparenzwertes, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen.

So gehen Sie vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color.FromArgb(alpha, baseColor)`, um eine Farbe mit Transparenz zu definieren (der `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

```c#
const int alpha = 128;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine feste Rechtecks‑Autoform hinzu.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente Rechtecks‑Autoform über der festen Form hinzu.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The transparent shape](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, um visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen zu positionieren.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Eigenschaft `Rotation` der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Holen Sie die erste Folie.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie eine Autoform vom Typ Rechteck hinzu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Drehen Sie die Form um 5 Grad.
    shape.Rotation = 5;

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The shape rotation](shape-rotation.png)

## **3D‑Wulsteffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Wulsteffekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/)‑Eigenschaften konfiguriert werden.

So fügen Sie einer Form 3D‑Wulsteffekte hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) der Form, um die Wulsteinstellungen festzulegen.
1. Speichern Sie die Präsentation.

```c#
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

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/)‑Eigenschaften konfiguriert werden.

So wenden Sie 3D‑Drehungseffekte auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) und den [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) der Form, um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse.
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

![The 3D rotation effect](3D-rotation-effect.png)

## **Formatierung zurücksetzen**

Der folgende C#‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) auf ihre Standardwerte zurückgesetzt werden:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Setzen Sie jede Form auf der Folie zurück, die einen Platzhalter im Layout enthält.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Dateiraums, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keine zusätzliche Größe hinzufügen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung aufweisen, sodass ich sie gruppieren kann?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie ihre Stile als identisch und gruppieren Sie diese Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten formatieren Formen und wenden deren Formatierung dort an, wo sie gebraucht wird.