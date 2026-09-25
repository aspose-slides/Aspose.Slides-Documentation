---
title: "WordArt‑Effekte in .NET erstellen und anwenden"
linktitle: "WordArt"
type: docs
weight: 110
url: /de/net/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt‑Vorlage
- WordArt‑Effekt
- Schatten‑Effekt
- Spiegelungs‑Effekt
- Leucht‑Effekt
- WordArt‑Transformation
- 3D‑Effekt
- Außenschatten‑Effekt
- Innenschatten‑Effekt
- .NET
- C#
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt‑Effekten in Aspose.Slides für .NET. Diese schrittweise Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in C# zu verbessern."
---
## **Übersicht**

WordArt‑Effekte ermöglichen es Ihnen, Text mit Füllungen, Konturen, Schatten, Spiegelungen, Leuchten, Transformationen und 3D‑Formatierungen zu gestalten. Dieser Artikel erklärt, wie Sie diese Effekte in PowerPoint‑Präsentationen mit Aspose.Slides für .NET erstellen und anpassen, ohne dass Microsoft Office installiert ist.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwenden auf Text**

Die folgenden Beispiele erstellen einen einfachen WordArt‑Stil, indem sie Text, Schriftart, Musterfüllung und Kontur festlegen.

Jedes Beispiel erstellt eine neue Präsentation und fügt ihrer ersten Folie ein Rechteck hinzu; eine Eingabedatei ist nicht erforderlich. Das erste Beispiel setzt den Text auf "Aspose.Slides". Position und Abmessungen der Form werden in Punkten angegeben:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Setzen Sie die Schriftart auf Arial Black mit 36 Punkten, um die Formatierung deutlicher zu machen:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Wenden Sie ein [SmallGrid](https://reference.aspose.com/slides/de/net/aspose.slides/patternstyle/) Muster mit einem dunkelorangefarbenen Vordergrund und einem weißen Hintergrund an und fügen Sie anschließend eine schwarze Textkontur mit einer Breite von 1 Punkt hinzu:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Der resultierende Text:

![Einfaches WordArt‑Template](WordArt_template.png)

## **Weitere WordArt‑Effekte anwenden**

Die folgenden Beispiele zeigen, wie man Schatten, Spiegelungen, Leuchten, Transformationen und 3D‑Effekte auf Text anwendet.

### **Außenschatten‑Effekte anwenden**

Ein Außenschatten erzeugt Tiefe, indem er einen Schatten hinter den Text legt. Sie können Farbe, Richtung, Abstand, Unschärferadius, Skalierung und Schrägstellung anpassen.

Dieses Beispiel ruft [EnableOuterShadowEffect](https://reference.aspose.com/slides/de/net/aspose.slides/effectformat/enableoutershadoweffect/) auf und legt einen schwarzen Schatten mit einem Unschärferadius von 4 Punkten, einer Richtung von 230 Grad und einem Abstand von 30 Punkten fest. Skalierungswerte von 100 erhalten die Schattengröße, während die horizontale Schrägstellung ihn um 20 Grad neigt. Die Alpha‑Transformation setzt die Deckkraft auf 32 %:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Der resultierende Text:

![Außenschatten‑Effekt](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wenn äußere und voreingestellte Schatten zusammen verwendet werden, wird nur der äußere Schatten angewendet.
- Wenn äußere und innere Schatten gleichzeitig verwendet werden, hängt der resultierende Effekt von der PowerPoint‑Version ab. Beispielsweise wird der Effekt in PowerPoint 2013 verdoppelt, während in PowerPoint 2007 nur der äußere Schatten angewendet wird.
{{% /alert %}}

### **Spiegelungs‑Effekte anwenden**

Eine Spiegelung erzeugt eine gespiegelte Kopie des Textes. Passen Sie Position, Skalierung, Unschärfe und Deckkraft an, um das Aussehen zu steuern.

Dieses Beispiel ruft [EnableReflectionEffect](https://reference.aspose.com/slides/de/net/aspose.slides/effectformat/enablereflectioneffect/) auf und kippt die Spiegelung vertikal mit einer Skalierung von -100 %. Es verwendet einen Unschärferadius von 0,5 Punkten und einen Abstand von 4,72 Punkten. Die Deckkraft verringert sich von 60 % auf 0,9 % zwischen den Positionen 0 % und 60 % entlang der Spiegelung:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

Der resultierende Text:

![Spiegelungs‑Effekt](reflection_effect.png)

### **Leucht‑Effekte anwenden**

Ein Leuchten fügt dem Text eine weiche farbige Kontur hinzu. Passen Sie Farbe, Deckkraft und Radius an, um den Effekt zu steuern.

Dieses Beispiel ruft [EnableGlowEffect](https://reference.aspose.com/slides/de/net/aspose.slides/effectformat/enablegloweffect/) auf und wendet ein rotes Leuchten mit 54 % Deckkraft und einem Radius von 7 Punkten an:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Der resultierende Text:

![Leucht‑Effekt](glow_effect.png)

### **WordArt‑Transformationen anwenden**

WordArt‑Transformationen biegen, strecken oder verzerren einen Textblock.

Setzen Sie [Transform](https://reference.aspose.com/slides/de/net/aspose.slides/textframeformat/transform/) auf [ArchUpPour](https://reference.aspose.com/slides/de/net/aspose.slides/textshapetype/), um den gesamten Textrahmen nach oben zu krümmen:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Der resultierende Text:

![WordArt‑Transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides für .NET bietet eine Reihe vordefinierter [Transformationstypen](https://reference.aspose.com/slides/de/net/aspose.slides/textshapetype/).
{{% /alert %}}

### **3D‑Effekte auf Formen und Text anwenden**

Sie können 3D‑Effekte auf eine Form oder ihren Text anwenden. Abschrägungen, Extrusion, Beleuchtung und Kameraeinstellungen bestimmen das Ergebnis.

Das folgende Beispiel verwendet [ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/), um dem Rechteck kreisförmige Abschrägungen, orangefarbene Extrusion und eine dunkelrote Kontur hinzuzufügen. Abschrägungsmaße, Extrusionshöhe, Konturbreite und -tiefe werden in Punkten angegeben. Ein Plastikmaterial, ausgewogene Beleuchtung, um 40 Grad um die Z‑Achse gedreht, und eine Perspektivkamera bestimmen das Aussehen:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Die resultierende Form:

![Form‑3D‑Effekt](shape_3D_effect.png)

Dieses Beispiel wendet eine ähnliche 3D‑Formatierung auf den Text über [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/textframeformat/threedformat/) an. Kleinere Abschrägungen formen die Buchstabenränder, während Extrusion und Beleuchtung dem Text Tiefe verleihen:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Der resultierende Text:

![Text‑3D‑Effekt](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Die Anwendung von 3D‑Effekten auf Text oder deren Formen – und die Interaktion zwischen diesen Effekten – wird durch spezifische Regeln bestimmt. Betrachten Sie eine Szene, die sowohl Text als auch die enthaltende Form umfasst. Ein 3D‑Effekt beinhaltet die 3D‑Darstellung des Objekts und die Szene, in der es platziert ist.

- Wenn für sowohl die Form als auch den Text eine Szene festgelegt ist, hat die Szene der Form Vorrang und die Szene des Textes wird ignoriert.
- Fehlt der Form eine eigene Szene, aber sie besitzt eine 3D‑Darstellung, wird die Szene des Textes verwendet.
- Hat die Form überhaupt keinen 3D‑Effekt, wird sie als flach behandelt und der 3D‑Effekt wird nur auf den Text angewendet.

Diese Verhaltensweisen beziehen sich auf die Eigenschaften [ThreeDFormat.LightRig](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/lightrig/) und [ThreeDFormat.Camera](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Um Text flach und lesbar zu halten, während die 3D‑Formatierung der Form erhalten bleibt, siehe [Text flach halten auf einer 3D‑Form](/slides/de/net/3d-presentation/) für einen Vergleich beider Einstellungen und ein vollständiges C#‑Beispiel.

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriftarten oder Schriften (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides für .NET unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Schriftsystemen. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriftarten von den Systemschriftarten abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Masterfolien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden in allen zugehörigen Folien übernommen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. WordArt‑Effekte wie Schatten, Leuchten und Farbverlauf‑Füllungen können die Dateigröße durch zusätzliche Formatierungs‑Metadaten geringfügig erhöhen, aber der Unterschied ist in der Regel vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten sehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern mittels [ISlide.GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/), oder einzelne Formen mittels [IShape.GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/getimage/) rendern. Damit können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die vollständige Präsentation speichern oder exportieren.