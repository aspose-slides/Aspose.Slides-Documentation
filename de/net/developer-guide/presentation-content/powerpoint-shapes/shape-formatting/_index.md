---
title: Formatausgestaltung von Formen
type: docs
weight: 20
url: /de/net/shape-formatting/
keywords:
- formatiere Form
- forme Linien
- forme Verbindungsstile
- Verlaufshintergrund
- Musterfüllung
- Bildfüllung
- einfarbige Füllung
- Formen rotieren
- 3D-Facetteneffekte
- 3D-Rotationseffekt
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Formate in der PowerPoint-Präsentation in C# oder .NET"
---

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie Formen formatieren, indem Sie ihre Bestandteile, die Linien, ändern oder bestimmte Effekte anwenden. Darüber hinaus können Sie Formen formatieren, indem Sie Einstellungen angeben, die bestimmen, wie sie (der Bereich in ihnen) gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides für .NET** bietet Schnittstellen und Eigenschaften, die es Ihnen ermöglichen, Formen basierend auf bekannten Optionen in PowerPoint zu formatieren.

## **Linien formatieren**

Mit Aspose.Slides können Sie Ihren bevorzugten Linienstil für eine Form angeben. Diese Schritte skizzieren ein solches Verfahren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
4. Setzen Sie eine Farbe für die Linien der Form.
5. Setzen Sie die Breite für die Linien der Form.
6. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/net/aspose.slides/linestyle) für die Linien der Form.
7. Setzen Sie den [Strichstil](http://aspose.com/api/net/slides/aspose.slides/linedashstyle) für die Linien der Form.
8. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C#-Code demonstriert eine Operation, bei der wir ein Rechteck `AutoShape` formatiert haben:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation())
{
    // Holt die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügt ein Rechteck-AutoShape hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Setzt die Füllfarbe für die Rechteckform
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.White;

    // Wendet einige Formatierungen auf die Linien des Rechtecks an
    shp.LineFormat.Style = LineStyle.ThickThin;
    shp.LineFormat.Width = 7;
    shp.LineFormat.DashStyle = LineDashStyle.Dash;

    // Setzt die Farbe für die Linie des Rechtecks
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("RectShpLn_out.pptx", SaveFormat.Pptx);
}
```

## **Verbindungsstile formatieren**
Dies sind die 3 Verbindungsstil-Optionen:

* Rund
* Schnitt
* Fase

Standardmäßig verwendet PowerPoint die Einstellung **Rund**, wenn es zwei Linien in einem Winkel (oder eine Form-Ecke) verbindet. Wenn Sie jedoch eine Form mit sehr scharfen Winkeln zeichnen möchten, sollten Sie **Schnitt** wählen.

![join-style-powerpoint](join-style-powerpoint.png)

Dieser C#-Code demonstriert eine Operation, bei der 3 Rechtecke (das Bild oben) mit den Verbindungsstil-Einstellungen Schnitt, Fase und Rund erstellt wurden:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation())
{
	// Holt die erste Folie
	ISlide sld = pres.Slides[0];

	// Fügt 3 Rechteck-Autoshapes hinzu
	IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
	IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
	IShape shp3 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

	// Setzt die Füllfarbe für die Rechteckform
	shp1.FillFormat.FillType = FillType.Solid;
	shp1.FillFormat.SolidFillColor.Color = Color.Black;
	shp2.FillFormat.FillType = FillType.Solid;
	shp2.FillFormat.SolidFillColor.Color = Color.Black;
	shp3.FillFormat.FillType = FillType.Solid;
	shp3.FillFormat.SolidFillColor.Color = Color.Black;

	// Setzt die Linienbreite
	shp1.LineFormat.Width = 15;
	shp2.LineFormat.Width = 15;
	shp3.LineFormat.Width = 15;

	// Setzt die Farbe für die Linie des Rechtecks
	shp1.LineFormat.FillFormat.FillType = FillType.Solid;
	shp1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp2.LineFormat.FillFormat.FillType = FillType.Solid;
	shp2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp3.LineFormat.FillFormat.FillType = FillType.Solid;
	shp3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	// Setzt den Verbindungsstil
	shp1.LineFormat.JoinStyle = LineJoinStyle.Miter;
	shp2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
	shp3.LineFormat.JoinStyle = LineJoinStyle.Round;

	// Fügt jedem Rechteck Text hinzu
	((IAutoShape)shp1).TextFrame.Text = "Miter-Verbindungsstil";
	((IAutoShape)shp2).TextFrame.Text = "Fasen-Verbindungsstil";
	((IAutoShape)shp3).TextFrame.Text = "Runder Verbindungsstil";

	// Schreibt die PPTX-Datei auf die Festplatte
	pres.Save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
}
```

## **Verlaufshintergrund**
In PowerPoint ist der Verlaufshintergrund eine Formatierungsoption, die es Ihnen ermöglicht, einen kontinuierlichen Farbübergang auf eine Form anzuwenden. Beispielsweise können Sie zwei oder mehr Farben in einer Anordnung anwenden, bei der eine Farbe allmählich in eine andere übergeht.

So verwenden Sie Aspose.Slides, um einer Form einen Verlaufshintergrund anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) der Form auf `Gradient`.
5. Fügen Sie Ihre 2 bevorzugten Farben mit definierten Positionen über die `Add`-Methoden hinzu, die von der `GradientStops`-Sammlung bereitgestellt werden, die mit der `GradientFormat`-Klasse verknüpft ist.
6. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C#-Code demonstriert eine Operation, bei der der Verlaufshintergrund auf eine Ellipse angewendet wurde:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation())
{
    // Holt die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügt ein Ellipsen-AutoShape hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Wendet die Verlaufformatierung auf die Ellipse an
    shp.FillFormat.FillType = FillType.Gradient;
    shp.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Setzt die Richtung des Verlaufs
    shp.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Fügt 2 Verlaufshaltestellen hinzu
    shp.FillFormat.GradientFormat.GradientStops.Add((float)1.0, PresetColor.Purple);
    shp.FillFormat.GradientFormat.GradientStops.Add((float)0, PresetColor.Red);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
}
```

## **Musterfüllung**
In PowerPoint ist die Musterfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein zweifarbigen Design, bestehend aus Punkten, Streifen, Kreuzschraffuren oder Karos, auf eine Form anzuwenden. Darüber hinaus können Sie Ihre bevorzugten Farben für den Vordergrund und den Hintergrund Ihres Musters auswählen.

Aspose.Slides bietet über 45 vordefinierte Stile, die zur Formatierung von Formen und zur Bereicherung von Präsentationen verwendet werden können. Selbst nachdem Sie ein vordefiniertes Muster ausgewählt haben, können Sie weiterhin die Farben angeben, die das Muster enthalten muss.

So verwenden Sie Aspose.Slides, um einer Form eine Musterfüllung anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) der Form auf `Pattern`.
5. Setzen Sie Ihren bevorzugten Musterstil für die Form.
6. Setzen Sie die [Hintergrundfarbe](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor) für das [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
7. Setzen Sie die [Vordergrundfarbe](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor) für das [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
8. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C#-Code demonstriert eine Operation, bei der eine Musterfüllung verwendet wurde, um ein Rechteck zu verschönern:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation())
{
    // Holt die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügt ein Rechteck-AutoShape hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Setzt den Fülltyp auf Muster
    shp.FillFormat.FillType = FillType.Pattern;

    // Setzt den Musterstil
    shp.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Setzt die Muster Hintergrund- und Vordergrundfarben
    shp.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shp.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("RectShpPatt_out.pptx", SaveFormat.Pptx);
}
```

## **Bildfüllung**
In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild in eine Form zu platzieren. Im Wesentlichen können Sie ein Bild als Hintergrund einer Form verwenden.

So verwenden Sie Aspose.Slides, um eine Form mit einem Bild zu füllen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) der Form auf `Picture`.
5. Setzen Sie den Modus für die Bildfüllung auf Kachel.
6. Erstellen Sie ein `IPPImage`-Objekt mit dem Bild, das verwendet werden soll, um die Form zu füllen.
7. Setzen Sie die `Picture.Image`-Eigenschaft des `PictureFillFormat`-Objekts auf das neu erstellte `IPPImage`.
8. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt, wie man eine Form mit einem Bild füllt:

```c#
// Erstellt die Präsentationsklasseninstanz, die eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = presentation.Slides[0];

    // Fügt ein Rechteck-AutoShape hinzu
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Setzt den Fülltyp auf Bild
    shape.FillFormat.FillType = FillType.Picture;

    // Setzt den Bildfüllmodus
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Lädt ein Bild und fügt es zu den Präsentationsressourcen hinzu
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Setzt das Bild
    shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Schreibt die PPTX-Datei auf die Festplatte
    presentation.Save("RectShpPic_out.pptx", SaveFormat.Pptx);
}
```

## **Einfarbige Füllung**
In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die es Ihnen ermöglicht, eine Form mit einer einzigen Farbe zu füllen. Die gewählte Farbe ist typischerweise eine einheitliche Farbe. Die Farbe wird auf den Hintergrund der Form aufgetragen, ohne spezielle Effekte oder Modifikationen.

So verwenden Sie Aspose.Slides, um einer Form eine einfarbige Füllung anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) der Form auf `Solid`.
5. Setzen Sie Ihre bevorzugte Farbe für die Form.
6. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt, wie man die einfarbige Füllung auf ein Feld in PowerPoint anwendet:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation())
{
    // Holt die erste Folie
    ISlide slide = presentation.Slides[0];

    // Fügt ein Rechteck-AutoShape hinzu
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Setzt den Fülltyp auf Einfarbig
    shape.FillFormat.FillType = FillType.Solid;

    // Setzt die Farbe für das Rechteck
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Schreibt die PPTX-Datei auf die Festplatte
    presentation.Save("RectShpSolid_out.pptx", SaveFormat.Pptx);
}
```

## **Transparenz einstellen**

In PowerPoint können Sie beim Füllen von Formen mit einfarbigen Farben, Verläufen, Bildern oder Texturen das Transparenzniveau festlegen, das die Opazität einer Füllung bestimmt. Zum Beispiel, wenn Sie ein niedriges Transparenzniveau festlegen, wird das Folienobjekt oder der Hintergrund hinter (der Form) sichtbar.

Aspose.Slides ermöglicht es Ihnen, das Transparenzniveau für eine Form auf folgende Weise festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
4. Verwenden Sie `Color.FromArgb` mit dem oberen Wert, der festgelegt ist.
5. Speichern Sie das Objekt als PowerPoint-Datei.

Dieser C#-Code demonstriert den Prozess:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügt eine solide Form hinzu
    IShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Fügt eine transparente Form über die solide Form hinzu
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 204, 102, 0);
    
    // Schreibt die PPTX-Datei auf die Festplatte
    presentation.Save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
}
```

## **Formen rotieren**
Aspose.Slides ermöglicht es Ihnen, eine Form, die zu einer Folie hinzugefügt wurde, auf folgende Weise zu rotieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
4. Rotieren Sie die Form um die benötigten Grad.
5. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt, wie man eine Form um 90 Grad rotiert:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation())
{
    // Holt die erste Folie
    ISlide sld = pres.Slides[0];

    // Fügt ein Rechteck-AutoShape hinzu
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Rotiert die Form um 90 Grad
    shp.Rotation = 90;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("RectShpRot_out.pptx", SaveFormat.Pptx);
}
```

## **3D-Facetteneffekte hinzufügen**
Aspose.Slides ermöglicht es Ihnen, 3D-Facetteneffekte zu einer Form hinzuzufügen, indem Sie die Eigenschaften von [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) wie folgt ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
3. Setzen Sie Ihre bevorzugten Parameter für die [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) Eigenschaften der Form.
4. Schreiben Sie die Präsentation auf die Festplatte.

Dieser C#-Code zeigt, wie man 3D-Facetteneffekte zu einer Form hinzufügt:

```c#
// Erstellt eine Instanz der Präsentationsklasse
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    
    // Fügt eine Form zur Folie hinzu
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    ILineFillFormat format = shape.LineFormat.FillFormat;
    format.FillType = FillType.Solid;
    format.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;
    
    // Setzt die 3DFormat Eigenschaften der Form
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    
    // Schreibt die Präsentation als PPTX-Datei
    pres.Save("Bavel_out.pptx", SaveFormat.Pptx);
}
```

## **3D-Rotationseffekt hinzufügen**
Aspose.Slides ermöglicht es Ihnen, 3D-Rotationseffekte auf eine Form anzuwenden, indem Sie die Eigenschaften von [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) wie folgt ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie eine Referenz auf die Folie durch ihren Index.
3. Fügen Sie eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) zur Folie hinzu.
3. Geben Sie Ihre bevorzugten Werte für [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/properties/cameratype) und [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/properties/lighttype) an.
4. Schreiben Sie die Präsentation auf die Festplatte.

Dieser C#-Code zeigt, wie man 3D-Rotationseffekte auf eine Form anwendet:

```c#
// Erstellt eine Instanz einer Präsentationsklasse
using (Presentation pres = new Presentation())
{
    IShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);
    
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(0, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    // Schreibt die Präsentation als PPTX-Datei
    pres.Save("Rotation_out.pptx", SaveFormat.Pptx);
}
```

## **Formatierung zurücksetzen**

Dieser C#-Code zeigt, wie Sie die Formatierung in einer Folie zurücksetzen und die Position, Größe und Formatierungen jeder Form, die einen Platzhalter auf [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) hat, auf ihre Standardeinstellungen zurücksetzen:

```c#
using (Presentation pres = new Presentation())
{
    foreach (ISlide slide in pres.Slides)
    {
        // Jede Form auf der Folie, die einen Platzhalter auf dem Layout hat, wird zurückgesetzt
        slide.Reset();
    }
}
```