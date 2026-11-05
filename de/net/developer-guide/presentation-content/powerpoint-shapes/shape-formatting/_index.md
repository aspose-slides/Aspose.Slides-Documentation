---
title: PowerPoint-Formen in .NET formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/net/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen-Effekt
- Skizzenformenlinie
- Verbindungsstil formatieren
- Verlauf-Füllung
- Muster-Füllung
- Bild-Füllung
- Textur-Füllung
- Einfarbige Füllung
- Form-Transparenz
- Schwarz-Weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D‑Fase‑Effekt
- 3D‑Dreh‑Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Formen in C# mit Aspose.Slides formatieren—Füll‑, Linien‑ und Effekt‑Stile für PPT‑ und PPTX‑Dateien präzise und vollständig steuern."
---
## **Einleitung**

Formatiere Formen in PowerPoint, indem du ihre Konturen, Füllungen und Effekte anpasst. Aspose.Slides für .NET ermöglicht die programmgesteuerte Steuerung dieser Einstellungen, einschließlich Transparenz, Drehung und 3D‑Formatierung.

![Formformatierungsoptionen in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für .NET stellt Schnittstellen und Eigenschaften bereit, mit denen du Formen mit denselben Optionen formatieren kannst, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Verwende [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) um die Kontur einer Form zu steuern. Dieses Beispiel erstellt ein nicht gefülltes Rechteck mit einer blauen, gestrichelten Kontur. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) wählt eine dick‑dünn‑Verbindungslinie, während [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) die Breite auf 7 Punkte setzt und [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) das Strichmuster auswählt.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

### **Benutzerdefinierte Strichmuster für Linien festlegen**

Verwende [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) wenn vordefinierte Linienstile nicht die gewünschten Strichlängen und Lücken bieten, zum Beispiel für Marken‑Konturen oder technische Diagramme. Das Zuweisen eines Musters setzt automatisch [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) auf [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Array‑Einträge wechseln zwischen Strich‑ und Lückenlänge, beginnend mit einem Strich. Jeder Wert ist ein Vielfaches der Linienbreite: `{ 4, 2 }` bei einer Breite von 3 Punkten erzeugt einen 12‑Punkte‑Strich gefolgt von einer 6‑Punkte‑Lücke. Verwende Paare aus endlichen, nicht‑negativen Werten, um komplette Strich‑und‑Lücken‑Segmente zu definieren. Das Beispiel verwendet positive Werte, damit jeder Strich und jede Lücke sichtbar bleibt.

Dieses Beispiel erstellt fünf blaue Linien mit gleicher Länge und flachen Enden. Die ersten drei vergleichen Muster bei einer Breite von 3 Punkten. Die vierte wiederholt das erste Muster bei doppelter Breite und verdoppelt damit sowohl die Strich‑ als auch die Lückenlängen. Die fünfte wechselt von einem benutzerdefinierten Muster zu einer durchgezogenen Linie.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Return the last line to a solid style.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Um stattdessen zu einem vordefinierten gestrichelten Stil zurückzukehren, weise [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) zu. Der ausgewählte Stil bestimmt das Aussehen der Linie.

Das Ergebnis in PowerPoint, von oben nach unten: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; und **Solid, 3 pt**.

![Drei benutzerdefinierte Strichmuster, eine breitere Linie, die das erste Muster verwendet, und eine durchgezogene Linie in PowerPoint](custom-dash-patterns.png)

### **Linienenden festlegen**

Verwende [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) um die Enden einer offenen Linie festzulegen. Die Aufzählung [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) bietet drei explizite Endstil‑Optionen:

- `Flat`: Der Strich endet am Endpunkt.
- `Round`: Eine halbkreisförmige Endung reicht halb so breit wie die Linienbreite über den Endpunkt hinaus.
- `Square`: Eine quadratische Endung reicht halb so breit wie die Linienbreite über den Endpunkt hinaus.

Die Aufzählung beinhaltet außerdem `NotDefined`, was bedeutet, dass kein Endstil explizit zugewiesen ist.

Enden unterscheiden sich von Pfeilspitzen, die Symbole zu Linienenden hinzufügen, und von Verbindungen, die Ecken zwischen Liniensegmenten steuern. Dieses Beispiel deaktiviert Pfeilspitzen über [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) und [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/), sodass nur die Endformen verglichen werden.

Das folgende Beispiel erstellt drei ansonsten identische horizontale Linien mit einer Breite von 20 Punkten. Von oben nach unten verwenden sie flache, runde und quadratische Enden. Ihre Endpunkte haben dieselben horizontalen Koordinaten; die runden und quadratischen Enden erstrecken sich 10 Punkte über jeden Endpunkt hinaus.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Das Ergebnis in PowerPoint, von oben nach unten: **Flat**, **Round**, und **Square**.

![Flache, runde und quadratische Enden an identischen dicken Linien in PowerPoint](line-caps.png)

## **Skizzen‑Effekte auf Formlinien anwenden**

Ein Skizzen‑Effekt lässt eine Formlinie handgezeichnet wirken. Verwende [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) um die Linieneinstellungen zu erhalten, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) um die Skizzeneinstellungen zu erhalten, und [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) auszuwählen.

Der folgende C#‑Code zeigt, wie man einen [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)‑Effekt anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) entfernt:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Der von [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) zurückgegebene Wert stellt die der Form direkt zugewiesene Einstellung dar. Falls die Linienformatierung von einem Theme, einer Master‑Folien oder einer Layout‑Folien geerbt werden kann, verwende [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), greife auf [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) zu und lese [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/) aus. Der effektive Wert spiegelt die Formatierung wider, die tatsächlich nach Auflösung der Vererbung angewendet wird. Dieses Beispiel erfordert eine vorhandene Präsentation mit mindestens einer Form auf der ersten Folie und gibt beide Werte aus:

```csharp
using System;
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

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Rund
* Gehrung
* Fase

Der Verbindungsstil bestimmt, wie zwei Kontursegmente an einer Ecke zusammentreffen. Verwende **Round** für abgerundete Ecken, **Miter** für spitze Ecken oder **Bevel** für abgeflachte Ecken.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Dieses Beispiel erstellt drei schwarze Rechtecke mit blauen Konturen von 15 Punkten Breite. Es setzt [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) auf die miter-, bevel- und round‑Werte von [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), um zu vergleichen, wie die Ecken gezeichnet werden.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Miter‑Verbindungen an spitzen Ecken begrenzen**

Verwende [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) zusammen mit [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/), das auf [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) gesetzt ist, um zu begrenzen, wie weit eine spitze Ecke ausgedehnt werden kann.

Der Grenzwert ist das Verhältnis des Abstands zwischen den inneren und äußeren Ecken der Verbindung zur Linienbreite. Zum Beispiel erlaubt ein Wert von `8` eine Miter‑Länge von bis zu achtmal der Linienbreite; er ist keine Messung in Punkten. Überschreitet die Ecke den Grenzwert, verwendet PowerPoint an dieser Stelle eine abgeflachte Verbindung. Ein größerer Grenzwert ermöglicht spitzere Punkte. Die Einstellung wirkt nur auf Miter‑Verbindungen und eine Änderung hat keinen sichtbaren Effekt, wenn die Ecke innerhalb beider Grenzwerte bleibt.

Dieses Beispiel erstellt zwei identische, nicht gefüllte Dreiecke mit Konturen von 20 Punkten Breite. Das linke Dreieck verwendet einen Grenzwert von `2`, das rechte `8`. Jedes Dreieck ist 80 Punkte breit und 160 Punkte hoch, wodurch das Verhältnis der Miter‑Länge zur Linienbreite an der oberen Ecke etwa `4.12` beträgt. Folglich fasst PowerPoint die linke Spitze ab und lässt die rechte Spitze erhalten.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Das Ergebnis in PowerPoint: **Miter limit 2** links und **miter limit 8** rechts.

![Ein abgeflachter Spitzenwinkel mit Miter‑Grenzwert 2 und ein spitzer Spitzenwinkel mit Miter‑Grenzwert 8 in PowerPoint](miter-limits.png)

## **Verlauf‑Füllung**

Eine Verlauf‑Füllung mischt Farben über eine Form hinweg. Dieses Beispiel füllt eine Ellipse mit einem linearen Verlauf von 45 Grad von Rot zu Lila unter Verwendung von [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Die Methode [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) platziert die Farbstopps bei 0 und 1, dem Anfang und Ende des Verlaufs. Das Löschen der vorhandenen Stopps stellt sicher, dass nur diese beiden Farben verwendet werden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Ellipse mit Verlauf‑Füllung](gradient-fill.png)

Falls ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kannst einen Renderstil auswählen, ohne die in der Präsentation gespeicherte Verlauf‑Füllung zu ändern.

### **Den Winkel des linearen Verlaufs festlegen**

Verwende [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) um die Ausrichtung einer [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/)‑Füllung zu steuern. Der Winkel wird in Grad gemessen und nimmt im Uhrzeigersinn zu: `0` verläuft von links nach rechts, `90` von oben nach unten, `180` von rechts nach links und `270` von unten nach oben. Bruchteilswinkel werden unterstützt. Endliche Winkel außerhalb von `[0, 360)` werden auf eine Umdrehung normiert; zum Beispiel wird `-45` zu `315` und `360` zu `0`.

Dieses Beispiel erstellt sechs Rechtecke mit identischen roten, grünen und blauen Stopps an den Positionen `0`, `0.5` und `1`. Skalierung ist deaktiviert, damit der Winkel unabhängig von den Proportionen der Rechtecke verglichen werden kann. Die Winkel, von links nach rechts, sind `0`, `45` und `90` in der ersten Reihe und `135`, `180` und `270` in der zweiten Reihe.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Das Ergebnis in PowerPoint:

![Lineare Verläufe bei 0°, 45° und 90° in der oberen Zeile sowie 135°, 180° und 270° in der unteren Zeile](linear-gradient-angles.png)

### **Einen linearen Verlauf mit der Form skalieren**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) akzeptiert einen [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)‑Wert. Setze ihn explizit auf `False`, um den geometrischen Verlaufswinkel beizubehalten, wenn sich die Proportionen der Form ändern, oder auf `True`, um den Verlauf mit Breite und Höhe der Form zu skalieren. Bei aktivierter Skalierung kann der sichtbare Winkel von dem zugewiesenen Winkel bei einer nicht‑quadratischen Form abweichen.

Das folgende Beispiel verwendet einen Winkel von `45` Grad und dieselben Farbstopps wie beim Winkelvergleich. Die linke Spalte verwendet `False`; die rechte Spalte verwendet `True`. Jede Spalte enthält ein breites Rechteck über einem hohen Rechteck. Beide beginnen mit denselben breiten Abmessungen; das Ändern von Breite und Höhe des zweiten Rechtecks zeigt, wie die Füllung auf Größenänderungen reagiert, ohne die Verlaufeinstellungen zu ändern.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Das Ergebnis in PowerPoint, mit deaktivierter Skalierung links und aktivierter rechts:

![Breite und hohe Rechtecke mit einem 45‑Grad‑Verlauf, Vergleich von LinearGradientScaled False links und True rechts](linear-gradient-scaling.png)

Bei deaktivierter Skalierung behalten die diagonalen Farbstreifen in beiden Rechtecken dieselbe Orientierung bei. Bei aktivierter Skalierung dehnen sich die Streifen mit den Proportionen der Form. Dies hilft, den Verlauf einer Vorlage beim Anpassen einer Form an eine andere Größe zu reproduzieren. Bei einem Quadrat ändert das Aktivieren der Skalierung das Aussehen dieses `45`‑Grad‑Verlaufs nicht.

Sowohl Winkel‑ als auch Skalierungseinstellungen gelten für lineare Verläufe. Sie steuern nicht die Füllungen [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Winkel mit Verlauf‑Richtung kombinieren**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) wählt einen Verlaufsstil aus der Aufzählung [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/) aus; sie ist kein Ersatz für einen numerischen Winkel. Bei einem linearen Verlauf können die Eckstile den Bereich, über den die Farben verteilt werden, ändern, ohne [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) zu ändern. Halte die Richtung unverändert, wenn du Winkel oder Skalierung vergleichst.

Das folgende Beispiel wendet dieselben Einstellungen in umgekehrter Reihenfolge an. Die beiden Rechtecke sehen identisch aus: Das Zuweisen der Richtung vor oder nach dem Winkel ändert das Ergebnis nicht.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Muster‑Füllung**

Eine Muster‑Füllung wendet ein zweifarbiges Design wie Punkte, Streifen oder Karos an. Dieses Beispiel verwendet [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) um ein Gitter‑Muster auszuwählen. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) liefert den hellgrauen Hintergrund, und [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) liefert die gelbe Musterfarbe.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Rechteck mit Muster‑Füllung](pattern-fill.png)

## **Bild‑Füllung**

Eine Bild‑Füllung verwendet ein Bild innerhalb einer Form. Dieses Beispiel benötigt ein lokales Bild und nutzt [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) um es in die Bildsammlung der Präsentation zu laden. Das Setzen von [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) auf den Kachel‑Modus wiederholt das Bild im Rechteck. Das hier verwendete Quellbild wird unten angezeigt:

![Das Lotus‑Bild](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Form mit Bild‑Füllung](picture-fill.png)

### **Bild als Textur kacheln**

Wenn du ein gekacheltes Bild als Textur festlegen und das Kachel‑Verhalten anpassen möchtest, kannst du die folgenden Eigenschaften der Schnittstelle [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) verwenden:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Legt den Bild‑Füllmodus fest – entweder `Tile` oder `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Dieses Beispiel benötigt ein lokales Bild und konfiguriert [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) um es mit 50 % seiner Originalgröße zu wiederholen. Versätze von −32 Punkten verschieben die Kacheln horizontal und vertikal; die Ausrichtung unten‑rechts und das Spiegeln in beide Richtungen bestimmen, wie die wiederholte Textur angeordnet wird.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Kachel‑Optionen](tile-options.png)

## **Einfarbige Füllung**

Eine einfarbige Füllung gibt einer Form eine einzelne, einheitliche Farbe. Dieses Beispiel setzt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) auf den einfarbigen Füllmodus und weist Gelb über [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) zu, dann speichert es das Rechteck in einer Präsentation.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

### **Farben kopieren und dabei Theme‑Verweise beibehalten**

Verwende [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) um eine Fardefinition zu kopieren, einschließlich ihres Farbtyps, Theme‑Verweises und Transformationen. Das ist nützlich, wenn eine Füllfarbe zwischen Formen übertragen wird, die weiterhin dem Präsentations‑Theme folgen sollen. Die Methode kopiert nur die Farbe: Sie kopiert nicht den Fülltyp, die Kontur oder andere Formformatierungen. Setze den [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) des Ziels explizit.

Dieses Beispiel erstellt drei Rechtecke von links nach rechts: die Quelle, eine Theme‑bewusste Kopie und eine feste RGB‑Kopie. Die Quelle verwendet [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) um die erste Akzentfarbe zu referenzieren und fügt über [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/) eine Tönung hinzu. Die RGB‑Kopie verwendet die effektive Füllfarbe der Quelle, sodass alle drei zunächst identisch aussehen. Das Zuweisen von [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) setzt einen festen RGB‑Wert und löscht vorhandene Farbtransformationen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Vor dem Theme‑Wechsel stimmen alle drei Füllungen überein:

![Quelle, CopyFrom‑Ziel und feste RGB‑Ziel mit identischen blauen Füllungen](color-copy-before.png)

Nach dem Theme‑Wechsel folgen die Quelle und die Theme‑bewusste Kopie der neuen Akzentfarbe und behalten ihre Tönung bei. Die feste RGB‑Kopie bleibt blau:

![Quelle und CopyFrom‑Ziel mit orangefarbenen Füllungen, während das feste RGB‑Ziel blau bleibt](color-copy-after.png)

Die kopierte Definition ist unabhängig von der Quelle. Ändert man anschließend den Theme‑Verweis der Quelle, weist eine andere Farbe zu oder fügt ihre Transformationen hinzu bzw. entfernt sie, ändert sich das Ziel nicht. Ein Theme‑Wechsel wirkt sich weiterhin auf beide Formen aus, weil jede separat auf dieselbe Theme‑Farbe verweist.

Das Speichern und erneute Öffnen der PPTX bewahrt den [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), Theme‑Verweis und die [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/)‑Sammlung der kopierten Farbe; sie wird nicht zu RGB flachgedrückt.

Beim Kopieren zwischen unterschiedlichen Theme‑Kontexten, wie Präsentationen mit verschiedenen Akzentpaletten, wird der kopierte Verweis gegen das Theme des Ziels aufgelöst. Derselbe Verweis und dieselben Transformationen können daher eine andere sichtbare Farbe erzeugen. Siehe [Presentation Theme](/slides/de/net/presentation-theme/) für weitere Informationen zur Konfiguration von Theme‑Farben.

## **Folienhintergrund als Form‑Füllung verwenden**

Verwende [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) wenn eine Form dem Folienhintergrund entsprechen soll, zum Beispiel in einer Präsentations‑Vorlage. Setze zuerst [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) auf [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) um eine explizite Füllung zu entfernen. Mit dieser Kombination verwendet die Form den Folienhintergrund anstelle ihrer Stil‑Füllung. Das reine Aktivieren des Flags entfernt keine bereits vorhandene explizite Füllung.

Dies unterscheidet sich von [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): Hintergrund‑Füllung deckt Objekte hinter der Form mit dem entsprechenden Bereich des Folienhintergrunds ab, während NoFill diese Objekte sichtbar lässt. Ein Verlauf bleibt an der Folie ausgerichtet, anstatt in jeder Form neu zu starten.

Das folgende Beispiel erstellt einen Master‑Hintergrund, der von der Folie geerbt wird, und platziert einen magentafarbenen Streifen hinter drei Rechtecken. Das linke Rechteck verwendet den Hintergrund, das mittlere Rechteck hat keine Füllung, und das rechte Rechteck wechselt von Hintergrund‑Füllung zu einer expliziten orangefarbenen Füllung.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Vererbt den Verlauf vom Master.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Füge dieses Objekt zuerst hinzu, damit es hinter den Rechtecken erscheint.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Deaktiviere die Hintergrundfüllung, bevor eine explizite Füllung angewendet wird.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Das Ergebnis, von links nach rechts: **background fill**, **no fill** und **explicit fill**. Der magentafarbene Streifen wird von den linken und rechten Rechtecken verdeckt, bleibt aber durch das mittlere Rechteck sichtbar.

![Hintergrund‑Füllung, keine Füllung und explizite orange Füllung über einem magentafarbenen Streifen](background-fill.png)

Das gleiche Verhalten gilt für einen direkt auf der Folie definierten oder von einem Layout geerbten Hintergrund. Die Form verwendet den aufgelösten Folien‑Hintergrund; das Beispiel lässt sowohl den Folien‑ als auch den Layout‑Hintergrund undefiniert, sodass der Master ihn bereitstellt.

## **Transparenz festlegen**

Bei einer einfarbigen Füllung steuert die Alpha‑Komponente der Farbe die Undurchsichtigkeit: 0 ist vollständig transparent und 255 vollständig undurchsichtig. Dieses Beispiel verwendet einen Alpha‑Wert von 128 für ein gelbes Rechteck, wodurch es etwa zu 50 % transparent wird, sodass das darunterliegende Rechteck sichtbar bleibt. Die Farbe wird über [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) zugewiesen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Verwende [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) um eine Form in der Folienebene zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel dreht ein Rechteck um 5 Grad im Uhrzeigersinn und speichert die Präsentation.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Form‑Drehung](shape-rotation.png)

## **3D‑Fase‑Effekte hinzufügen**

Verwende [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) um einer Form Tiefe und abgeflachte Kanten zu geben. Dieses Beispiel erstellt eine grüne Ellipse mit einer orangefarbenen Kontur, setzt [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) auf 4 Punkte und wendet über [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/) eine kreisförmige obere Fase mit Breite und Höhe von 6 Punkten an. Eine frontale orthografische Kamera und Dreipunkt‑Beleuchtung machen die Fase sichtbar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der 3D‑Fase‑Effekt](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Die 3D‑Ansicht einer Form wird durch ihre Kameraeinstellungen gesteuert. Dieses Beispiel verwendet [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) mit Breiten‑, Längen‑ und Revolutions‑Winkeln von 40, 35 bzw. 20 Grad. Es wählt eine isometrische Kamera über [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) und ausgewogene Beleuchtung über [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), dann speichert es das formatierte Rechteck.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der 3D‑Dreh‑Effekt](3D-rotation-effect.png)

## **Schwarz‑Weiß‑Rendern von Formen steuern**

Die Eigenschaft [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert nicht automatisch die Schwarz‑Weiß‑Anzeige und ändert nicht die Füllung, Kontur oder andere Formatierungen der Form im normalen Farbmodus.

Verwende einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) um das gewünschte Verhalten auszuwählen. Zum Beispiel lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden graue Färbung, `BlackWhite` nutzt nur Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` bewahrt die normale Farbgebung, und `Hidden` lässt die Form im Schwarz‑Weiß‑Modus weg. `NotDefined` bedeutet, dass kein Form‑Level‑Modus zugewiesen ist.

Dieses Beispiel erstellt ein orangefarbenes Rechteck und setzt [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) auf gray. Die gespeicherte Form behält ihre orangefarbene Füllung für die normale Farbanzeige bei und fordert graue Färbung von Anwendungen an, die Schwarz‑Weiß‑Anzeigeeinstellungen berücksichtigen:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Im normalen Farbmodus behält das Rechteck seine orangefarbene Füllung bei. In einem Schwarz‑Weiß‑Anzeige‑Workflow verwendet es graue Färbung, weil sein Modus auf `Gray` gesetzt ist. So kannst du eine vollfarbige Folie beibehalten und gleichzeitig ein unterschiedliches Erscheinungsbild für Druck, Vorschau oder andere Workflows definieren, die die Schwarz‑Weiß‑Anzeigeeinstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Verwende [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) um Position, Größe und Formatierung von Folien‑Platzhaltern aus den entsprechenden Layout‑Platzhaltern wiederherzustellen. Dieses Beispiel benötigt eine vorhandene Präsentation mit layout‑verknüpften Platzhaltern und setzt vor dem Speichern jede Folie zurück. Formen ohne entsprechende Layout‑Platzhalter werden nicht zurückgesetzt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Farben, Linienstile und Effekt‑Einstellungen fügen im Vergleich zu eingebetteten Bildern und Medien in der Regel nur wenige Daten hinzu. Bild‑Füllungen können die Dateigröße erhöhen, weil ihre Bilder in der Präsentation gespeichert werden.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, um sie zu gruppieren?**

Vergleiche die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, betrachte deren Stile als identisch und gruppiere die Formen logisch, wodurch die spätere Stilverwaltung vereinfacht wird.

**Kann ich einen Satz benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um ihn in anderen Präsentationen wiederzuverwenden?**

Ja. Speichere Beispiel­formen mit den gewünschten Stilen in einer Vorlagen‑Folien‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffne die Vorlage, klone die benötigten formatierten Formen und wende deren Formatierung dort an, wo sie benötigt wird.