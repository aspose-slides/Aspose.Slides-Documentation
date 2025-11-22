---
title: Erstellen und Anwenden von WordArt-Effekten in C#
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
- Außenschatten-Effekt
- Innenschatten-Effekt
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie WordArt-Effekte in Aspose.Slides für .NET erstellen und anpassen. Diese Schritt-für-Schritt-Anleitung hilft Entwicklern, Präsentationen mit stilvollem, professionellem Text in C# zu verbessern."
---

## **Übersicht**

WordArt‑Effekte ermöglichen es Ihnen, visuell ansprechenden, stilisierten Text zu Ihren PowerPoint‑Präsentationen hinzuzufügen. Mit Aspose.Slides für .NET können Entwickler WordArt programmatisch erstellen, anpassen und verwalten – genau wie in Microsoft PowerPoint – ohne dass Office installiert sein muss. Dieser Artikel bietet einen Überblick über die Arbeit mit WordArt in .NET, einschließlich der Anwendung von Texttransformationen, Füllstilen, Konturen, Schatten und anderen Formatierungsoptionen, um Ihre Präsentationsinhalte ausdrucksstärker und fesselnder zu gestalten. WordArt erlaubt es, Text als grafisches Objekt zu behandeln. Es besteht aus Effekten oder speziellen Änderungen, die auf den Text angewendet werden, um ihn attraktiver oder auffälliger zu machen.

## **Ein einfaches WordArt‑Template erstellen und auf Text anwenden**

In diesem Abschnitt untersuchen wir, wie ein einfaches WordArt‑Template erstellt und auf Text mithilfe von Aspose.Slides für .NET angewendet wird. WordArt bietet eine einfache Möglichkeit, das Aussehen von Text mit auffälligen visuellen Effekten und Stilen zu verbessern. Indem Sie die grundlegenden Schritte zum Erstellen und Verwenden von WordArt erlernen, können Sie diese Techniken problemlos an jedes Projekt anpassen und Ihre Präsentationen lebendiger und einprägsamer gestalten.

Zuerst erstellen wir einfachen Text mit dem folgenden C#‑Code:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```


Nun setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt deutlicher zu machen, mithilfe des folgenden Codes:
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


Hier wenden wir die SmallGrid‑Musterfüllung auf den Text an und fügen eine schwarze Textkontur mit einer Breite von 1 mit dem folgenden Code hinzu:
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


Der resultierende Text:

![The simple WordArt template](WordArt_template.png)

## **Weitere WordArt‑Effekte anwenden**

Zusätzlich zu grundlegenden Transformationen ermöglicht Aspose.Slides für .NET das Anwenden einer Vielzahl fortgeschrittener WordArt‑Effekte, um das Erscheinungsbild Ihres Textes zu verbessern. Dazu gehören Konturen, Füllungen, Schatten, Spiegelungen und Leuchteffekte. Durch die Kombination dieser Funktionen können Sie auffällige Textstile erstellen, die in Ihren Präsentationen hervorstechen. Dieser Abschnitt demonstriert, wie Sie diese Effekte programmgesteuert mit einfachen, klaren Codebeispielen anwenden.

### **Außenschatten‑Effekte anwenden**

Außenschatten‑Effekte helfen, Text hervorzuheben, indem sie einen Schatten hinter seiner Kontur hinzufügen, wodurch Tiefe und Trennung vom Hintergrund entstehen. Aspose.Slides für .NET ermöglicht das einfache Anwenden und Anpassen von Außenschatten auf WordArt‑Text. In diesem Abschnitt lernen Sie, wie Sie Schattenfarbe, Richtung, Abstand, Unschärferadius und mehr einstellen, um die gewünschte visuelle Wirkung zu erzielen.

Das folgende C#‑Code‑Snippet wendet einen Schatteneffekt auf den zuvor erstellten Text an.
```cs
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

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet.
- Bei gleichzeitiger Verwendung von OuterShadow und InnerShadow hängt der resultierende Effekt von der PowerPoint‑Version ab. Beispiel: In PowerPoint 2013 wird der Effekt verdoppelt, in PowerPoint 2007 wird nur der OuterShadow‑Effekt angewendet.
{{% /alert %}}

### **Spiegelungs‑Effekte anwenden**

In diesem Abschnitt untersuchen wir, wie Spiegelungs‑Effekte in Ihren Folien mithilfe von Aspose.Slides für .NET angewendet werden. Spiegelungs‑Effekte können eine effektive Möglichkeit sein, Ihrem Text oder Ihren Formen ein stilvolles und modernes Aussehen zu verleihen, wichtige Elemente hervorzuheben und Ihrer Präsentation Tiefe zu geben. Durch das Verständnis des Prozesses zum Anwenden und Anpassen dieser Effekte können Sie sie leicht an Ihre Design‑ und Markenanforderungen anpassen.

Fügen Sie dem Text mit folgendem C#‑Beispiel einen Spiegelungs‑Effekt hinzu:
```cs
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

![The Reflection effect](reflection_effect.png)

### **Leuchte‑Effekte anwenden**

In diesem Abschnitt untersuchen wir, wie ein Leuchte‑Effekt auf Text mit Aspose.Slides für .NET angewendet wird. Der Leuchte‑Effekt kann Ihren Text mit einer leuchtenden Kontur hervorheben und die visuelle Attraktivität Ihrer Folien steigern. Durch Anpassen von Einstellungen wie Farbe und Intensität können Sie das Leuchten einfach an Ihr Design und Ihre Markenbedürfnisse anpassen, sodass wichtige Punkte in Ihrer Präsentation die Aufmerksamkeit des Publikums auf sich ziehen.

Wenden Sie mit dem folgenden Code einen Leuchte‑Effekt auf den Text an, damit er strahlt oder hervorsticht:
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


Der resultierende Text:

![The Glow effect](glow_effect.png)

### **WordArt‑Transformationen anwenden**

In diesem Abschnitt untersuchen wir, wie Transformationen in WordArt mit Aspose.Slides für .NET verwendet werden. Transformationen ermöglichen es Ihnen, Text zu biegen, zu strecken oder zu verformen und so einzigartige, visuell auffällige Effekte zu erzeugen. Durch das Beherrschen dieser Techniken können Sie Textformen und -stile mühelos an Ihre Markenidentität oder kreative Vision anpassen und so eine überzeugende, professionelle Präsentation sicherstellen.

Verwenden Sie die `Transform`‑Eigenschaft (die für den gesamten Textblock gilt) mit dem folgenden Code:
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


Der resultierende Text:

![The WordArt transformation](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides für .NET stellt einen Satz vordefinierter [Transformationstypen](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/) bereit.
{{% /alert %}} 

### **3D‑Effekte auf Formen und Text anwenden**

Realistische, auffällige Visualisierungen können die Wirkung Ihrer Präsentationen erheblich steigern. In diesem Abschnitt erkunden wir, wie dreidimensionale (3D)‑Effekte auf Formen mithilfe von Aspose.Slides für .NET angewendet werden. Durch das Manipulieren von Parametern wie Tiefe, Winkel und Beleuchtung können Sie beeindruckende 3D‑Transformationen erzeugen, die sofort die Aufmerksamkeit Ihres Publikums fesseln. Ob Sie subtile Hervorhebungen oder dramatische Illusionen anstreben, diese Funktionen bieten flexible Möglichkeiten, Ihr Design zu verbessern und Ideen ansprechender zu vermitteln.

Verwenden Sie das folgende Beispiel, um einer Form einen 3D‑Effekt zuzuweisen:
```cs
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

![The shape 3D effect](shape_3D_effect.png)

Verwenden Sie das folgende Beispiel, um einem Text einen 3D‑Effekt zuzuweisen:
```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```


Der resultierende Text:

![The text 3D effect](text_3D_effect.png)

{{% alert color="primary" %}} 
Die Anwendung von 3D‑Effekten auf Text oder deren Formen – sowie die Wechselwirkung zwischen diesen Effekten – wird durch spezifische Regeln gesteuert. Betrachten Sie eine Szene, die sowohl einen Text als auch die Form, die diesen Text enthält, umfasst. Ein 3D‑Effekt beinhaltet die 3D‑Darstellung des Objekts und die Szene, in der er platziert ist.

- Wenn für sowohl die Form als auch den Text eine Szene festgelegt ist, hat die Szene der Form Vorrang und die Szene des Textes wird ignoriert.
- Wenn die Form keine eigene Szene hat, aber eine 3D‑Darstellung besitzt, wird die Szene des Textes verwendet.
- Wenn die Form überhaupt keinen 3D‑Effekt hat, wird sie als flach behandelt und der 3D‑Effekt nur auf den Text angewendet.

Diese Verhaltensweisen beziehen sich auf die Eigenschaften [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) und [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Schriftsystemen (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides für .NET unterstützt Unicode und arbeitet mit allen gängigen Schriften und Schriftsystemen. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriften vom System abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente der Folienmaster anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen in Master‑Folien anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout wirken sich auf alle zugehörigen Folien aus.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Ein wenig. WordArt‑Effekte wie Schatten, Leuchten und Farbverläufe können die Dateigröße geringfügig erhöhen, da zusätzliche Formatierungs‑Metadaten hinzugefügt werden, der Unterschied ist jedoch meist vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten ansehen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien mit WordArt in Bilder (z. B. PNG, JPEG) rendern, indem Sie die `GetImage`‑Methode der [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑ oder [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)‑Schnittstelle verwenden. So können Sie das Ergebnis im Speicher oder direkt auf dem Bildschirm prüfen, bevor Sie die vollständige Präsentation speichern oder exportieren.