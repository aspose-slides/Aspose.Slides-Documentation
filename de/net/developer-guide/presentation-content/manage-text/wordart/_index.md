---
title: WordArt-Effekte in .NET erstellen und anwenden
linktitle: WordArt
type: docs
weight: 110
url: /de/net/wordart/
keywords:
- WordArt
- WordArt erstellen
- WordArt-Vorlage
- WordArt-Effekt
- Schatteneffekt
- Anzeigeeffekt
- Leuchteffekt
- WordArt-Transformation
- 3D-Effekt
- Außen-Schatten-Effekt
- Innen-Schatten-Effekt
- .NET
- C#
- Aspose.Slides
description: "Erstellen und Anpassen von WordArt-Effekten in Aspose.Slides für .NET. Diese Schritt-für-Schritt-Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in C# zu verbessern."
---
## **Übersicht**

WordArt‑Effekte ermöglichen es Ihnen, Ihren PowerPoint‑Präsentationen visuell ansprechenden, stilisierten Text hinzuzufügen. Mit Aspose.Slides für .NET können Entwickler WordArt programmgesteuert erstellen, anpassen und verwalten – genau wie in Microsoft PowerPoint, jedoch ohne dass Office installiert sein muss. Dieser Artikel gibt einen Überblick über die Arbeit mit WordArt in .NET, einschließlich der Anwendung von Texttransformationen, Füllstilen, Konturen, Schatten und anderen Formatierungsoptionen, um Ihre Präsentationsinhalte ausdrucksstärker und ansprechender zu gestalten. WordArt erlaubt es, Text als grafisches Objekt zu behandeln. Es besteht aus Effekten oder speziellen Modifikationen, die auf Text angewendet werden, um ihn attraktiver oder auffälliger zu machen.

## **Einfaches WordArt‑Template erstellen und auf Text anwenden**

In diesem Abschnitt erkunden wir, wie man ein einfaches WordArt‑Template erstellt und es mithilfe von Aspose.Slides für .NET auf Text anwendet. WordArt bietet eine einfache Möglichkeit, das Aussehen von Text mit auffälligen visuellen Effekten und Stilen zu verbessern. Indem Sie die grundlegenden Schritte zum Erstellen und Verwenden von WordArt erlernen, können Sie diese Techniken problemlos an jedes Projekt anpassen und Ihre Präsentationen lebendiger und einprägsamer gestalten.

Zuerst erstellen wir einfachen Text mit dem folgenden C#‑Code:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Nun setzen wir die Schriftgröße des Textes auf einen höheren Wert, um den Effekt besser sichtbar zu machen, mit dem folgenden Code:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

Hier wenden wir die SmallGrid‑Musterfüllung auf den Text an und fügen einen schwarzen Textrahmen mit einer Breite von 1 Pixel hinzu, mit dem folgenden Code:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

Der resultierende Text:

![Das einfache WordArt‑Template](WordArt_template.png)

## **Weitere WordArt‑Effekte anwenden**

Zusätzlich zu grundlegenden Transformationen ermöglicht Aspose.Slides für .NET das Anwenden einer Vielzahl fortgeschrittener WordArt‑Effekte, um das Erscheinungsbild Ihres Textes zu verbessern. Dazu gehören Konturen, Füllungen, Schatten, Reflexionen und Leuchteffekte. Durch die Kombination dieser Funktionen können Sie auffällige Textstile erstellen, die in Ihren Präsentationen hervorstechen. Dieser Abschnitt zeigt, wie Sie diese Effekte programmatisch mit einfachen, klaren Code‑Beispielen anwenden.

### **Außen‑Schatten‑Effekte anwenden**

Außen‑Schatten‑Effekte lassen Text hervorstechen, indem sie einen Schatten hinter seiner Kontur hinzufügen, was Tiefe und Trennung vom Hintergrund erzeugt. Aspose.Slides für .NET ermöglicht das einfache Anwenden und Anpassen von Außen‑Schatten auf WordArt‑Text. In diesem Abschnitt lernen Sie, wie Sie Schattenfarbe, Richtung, Abstand, Unschärferadius und mehr festlegen, um die gewünschte visuelle Wirkung zu erzielen.

Der folgende C#‑Code‑Abschnitt wendet einen Schatteneffekt auf den oben erstellten Text an.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

Der resultierende Text:

![Der Außen‑Schatten‑Effekt](outer_shadow_effect.png)

{{% alert color="info" %}} 
- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet.
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende Effekt von der PowerPoint‑Version ab. Zum Beispiel wird in PowerPoint 2013 der Effekt verdoppelt, während in PowerPoint 2007 nur der OuterShadow‑Effekt angewendet wird.
{{% /alert %}}

### **Reflexions‑Effekte anwenden**

In diesem Abschnitt erkunden wir, wie Sie Reflexions‑Effekte in Ihren Folien mithilfe von Aspose.Slides für .NET anwenden können. Reflexions‑Effekte können Ihrem Text oder Ihren Formen ein stilvolles und modernes Aussehen verleihen, wichtige Elemente hervorheben und Ihrer Präsentation Tiefe verleihen. Durch das Verständnis des Anwendens und Anpassen dieser Effekte können Sie sie leicht an Ihre Design‑ und Markenanforderungen anpassen.

Fügen Sie dem Text mit dem folgenden C#‑Beispiel einen Reflexions‑Effekt hinzu:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

Der resultierende Text:

![Der Reflexions‑Effekt](reflection_effect.png)

### **Glow‑Effekte anwenden**

In diesem Abschnitt erkunden wir, wie Sie mit Aspose.Slides für .NET einen Glow‑Effekt auf Text anwenden können. Der Glow‑Effekt lässt Ihren Text mit einer leuchtenden Kontur hervorstechen und erhöht die visuelle Attraktivität Ihrer Folien. Durch das Anpassen von Einstellungen wie Farbe und Intensität können Sie den Glow exakt an Ihr Design und Ihre Markenbedürfnisse anpassen, sodass wichtige Punkte in Ihrer Präsentation die Aufmerksamkeit des Publikums auf sich ziehen.

Wenden Sie einen Glow‑Effekt auf den Text an, um ihn zum Leuchten zu bringen oder hervorzuheben, mit dem folgenden Code:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

Der resultierende Text:

![Der Glow‑Effekt](glow_effect.png)

### **WordArt‑Transformationen anwenden**

In diesem Abschnitt erkunden wir, wie Sie Transformationen in WordArt mit Aspose.Slides für .NET nutzen können. Transformationen ermöglichen es, Text zu biegen, zu strecken oder zu verzerren und dabei einzigartige, visuell auffällige Effekte zu erzeugen. Durch das Beherrschen dieser Techniken können Sie Textformen und -stile leicht an Ihre Markenidentität oder kreative Vision anpassen und so eine überzeugende, professionelle Präsentation sicherstellen.

Verwenden Sie die `Transform`‑Eigenschaft (die auf den gesamten Textblock angewendet wird) mit dem folgenden Code:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

Der resultierende Text:

![Die WordArt‑Transformation](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides für .NET bietet eine Reihe vordefinierter [Transformationstypen](https://reference.aspose.com/slides/de/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **3D‑Effekte auf Formen und Text anwenden**

Realistische, aufmerksamkeitsstarke Visualisierungen können die Wirkung Ihrer Präsentationen deutlich steigern. In diesem Abschnitt untersuchen wir, wie Sie dreidimensionale (3D)‑Effekte auf Formen mithilfe von Aspose.Slides für .NET anwenden. Durch das Manipulieren von Parametern wie Tiefe, Winkel und Beleuchtung können Sie beeindruckende 3D‑Transformationen erzeugen, die sofort die Aufmerksamkeit Ihres Publikums fesseln. Ob Sie subtile Highlights oder dramatische Illusionen anstreben, diese Funktionen bieten flexible Möglichkeiten, Ihr Design zu erhöhen und Ideen ansprechender zu vermitteln.

Verwenden Sie den folgenden Beispielcode, um einer Form einen 3D‑Effekt zuzuweisen:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
}
```

Die resultierende Form:

![Der 3D‑Effekt der Form](shape_3D_effect.png)

Verwenden Sie den folgenden Beispielcode, um einem Text einen 3D‑Effekt zuzuweisen:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
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
}
```

Der resultierende Text:

![Der 3D‑Effekt des Textes](text_3D_effect.png)

{{% alert color="info" %}} 
Die Anwendung von 3D‑Effekten auf Text oder deren Formen – und die Wechselwirkung zwischen diesen Effekten – unterliegt spezifischen Regeln. Betrachten Sie ein Szenario, in dem sowohl ein Text als auch die Form, die diesen Text enthält, beteiligt sind. Ein 3D‑Effekt umfasst die 3D‑Darstellung des Objekts und die Szene, in der es platziert ist.

- Wenn für sowohl die Form als auch den Text eine Szene festgelegt ist, hat die Szene der Form Vorrang und die Szene des Textes wird ignoriert.
- Wenn die Form keine eigene Szene hat, aber eine 3D‑Darstellung besitzt, wird die Szene des Textes verwendet.
- Wenn die Form überhaupt keinen 3D‑Effekt hat, wird sie als flach behandelt und der 3D‑Effekt wird nur auf den Text angewendet.

Diese Verhaltensweisen beziehen sich auf die Eigenschaften [ThreeDFormat.LightRig](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/lightrig/) und [ThreeDFormat.Camera](https://reference.aspose.com/slides/de/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **FAQ**

### Kann ich WordArt‑Effekte mit unterschiedlichen Schriftarten oder Schriftsystemen (z. B. Arabisch, Chinesisch) verwenden?

Ja, Aspose.Slides für .NET unterstützt Unicode und funktioniert mit allen gängigen Schriftarten und Schriftsystemen. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriftarten vom System abhängen können.

### Kann ich WordArt‑Effekte auf Folienmaster‑Elemente anwenden?

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrund‑Texten. Änderungen am Master‑Layout werden in allen zugehörigen Folien übernommen.

### Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?

Leicht. WordArt‑Effekte wie Schatten, Glühen und Verlauf‑Füllungen können die Dateigröße minimal erhöhen, da zusätzliche Formatierungs‑Metadaten hinzugefügt werden, aber der Unterschied ist in der Regel vernachlässigbar.

### Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?

Ja, Sie können Folien, die WordArt enthalten, in Bilder (z. B. PNG, JPEG) rendern, indem Sie die `GetImage`‑Methode der [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/)‑ oder [ISlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/)-Schnittstelle verwenden. Damit können Sie das Ergebnis im Speicher oder auf dem Bildschirm vor dem Speichern bzw. Exportieren der gesamten Präsentation prüfen.