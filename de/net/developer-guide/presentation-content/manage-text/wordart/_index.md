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
- Außenschatteneffekt
- Innenschatteneffekt
- .NET
- C#
- Aspose.Slides
description: "WordArt-Effekte in Aspose.Slides für .NET erstellen und anpassen. Diese Schritt-für-Schritt-Anleitung hilft Entwicklern, Präsentationen mit professionellem Text in C# zu verbessern."
---

## **Übersicht**

WordArt‑Effekte ermöglichen es Ihnen, Ihren PowerPoint‑Präsentationen visuell ansprechenden, stilisierten Text hinzuzufügen. Mit Aspose.Slides für .NET können Entwickler programmatisch WordArt erstellen, anpassen und verwalten – genau wie in Microsoft PowerPoint – ohne dass Office installiert sein muss. Dieser Artikel bietet einen Überblick über die Arbeit mit WordArt in .NET, einschließlich der Anwendung von Texttransformationen, Füllstilen, Konturen, Schatten und anderen Formatierungsoptionen, um Ihren Präsentationsinhalt ausdrucksvoller und ansprechender zu gestalten. WordArt erlaubt es, Text als grafisches Objekt zu behandeln. Es besteht aus Effekten oder speziellen Modifikationen, die auf Text angewendet werden, um ihn attraktiver oder auffälliger zu machen.

## **Erstellen einer einfachen WordArt‑Vorlage und Anwendung auf Text**

In diesem Abschnitt untersuchen wir, wie Sie eine einfache WordArt‑Vorlage erstellen und mit Aspose.Slides für .NET auf Text anwenden. WordArt bietet eine einfache Möglichkeit, das Erscheinungsbild von Text mit auffälligen visuellen Effekten und Stilen zu verbessern. Durch das Erlernen der grundlegenden Schritte zum Erstellen und Verwenden von WordArt können Sie diese Techniken problemlos an jedes Projekt anpassen und Ihre Präsentationen lebendiger und einprägsamer gestalten.

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


Nun setzen wir die Schriftgröße des Textes auf einen höheren Wert, um den Effekt deutlicher zu machen, mit folgendem Code:
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


Hier wenden wir die SmallGrid‑Musterfüllung auf den Text an und fügen einen schwarzen Textrahmen mit einer Breite von 1 mit folgendem Code hinzu:
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


Der resultierende Text:

![Das einfache WordArt‑Template](WordArt_template.png)

## **Weitere WordArt‑Effekte anwenden**

Zusätzlich zu Grundtransformationen ermöglicht Aspose.Slides für .NET die Anwendung einer Vielzahl fortgeschrittener WordArt‑Effekte, um das Erscheinungsbild Ihres Textes zu verbessern. Dazu gehören Konturen, Füllungen, Schatten, Spiegelungen und Leuchteffekte. Durch die Kombination dieser Funktionen können Sie auffällige Textstile erstellen, die in Ihren Präsentationen herausstechen. Dieser Abschnitt zeigt, wie Sie diese Effekte programmatisch mit einfachen, klaren Codebeispielen anwenden.

### **Außenschatten‑Effekte anwenden**

Außenschatten‑Effekte lassen Text hervortreten, indem sie hinter seiner Kontur einen Schatten hinzufügen, wodurch Tiefe und Abstand zum Hintergrund erzeugt werden. Aspose.Slides für .NET ermöglicht es, Außenschatten auf WordArt‑Text einfach anzuwenden und anzupassen. In diesem Abschnitt lernen Sie, wie Sie Schattenfarbe, Richtung, Abstand, Weichzeichnungsradius und mehr einstellen, um die gewünschte visuelle Wirkung zu erzielen.

Der folgende C#‑Codeausschnitt wendet einen Schatteneffekt auf den oben erstellten Text an.
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

![Der Außenschatten‑Effekt](outer_shadow_effect.png)

{{% alert color="primary" %}} 

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow‑Effekt angewendet.
- Bei gleichzeitiger Verwendung von OuterShadow und InnerShadow hängt der resultierende Effekt von der PowerPoint‑Version ab. Beispielsweise wird der Effekt in PowerPoint 2013 verdoppelt, während in PowerPoint 2007 nur der OuterShadow‑Effekt angewendet wird.

{{% /alert %}}

### **Spiegelungs‑Effekte anwenden**

In diesem Abschnitt werden wir untersuchen, wie Sie Spiegelungs‑Effekte in Ihren Folien mit Aspose.Slides für .NET anwenden. Spiegelungs‑Effekte können Ihrem Text oder Ihren Formen ein stilvolles und modernes Aussehen verleihen, wichtige Elemente hervorheben und Ihrer Präsentation Tiefe verleihen. Durch das Verständnis des Prozesses zur Anwendung und Anpassung dieser Effekte können Sie sie leicht an Ihre Design‑ und Markenanforderungen anpassen.

Fügen Sie einem Text mit diesem C#‑Beispiel einen Spiegelungs‑Effekt hinzu:
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

![Der Spiegelungs‑Effekt](reflection_effect.png)

### **Leuchte‑Effekte anwenden**

In diesem Abschnitt erfahren Sie, wie Sie mit Aspose.Slides für .NET einen Leuchte‑Effekt auf Text anwenden. Der Leuchte‑Effekt kann Ihren Text mit einer leuchtenden Kontur hervorheben und die visuelle Attraktivität Ihrer Folien steigern. Durch Anpassung von Farbe und Intensität können Sie das Leuchten leicht an Ihr Design und Ihre Markenidentität anpassen, sodass wichtige Punkte Ihrer Präsentation die Aufmerksamkeit des Publikums auf sich ziehen.

Wenden Sie mit folgendem Code einen Leuchte‑Effekt auf den Text an, um ihn zum Strahlen zu bringen:
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


Der resultierende Text:

![Der Leuchte‑Effekt](glow_effect.png)

### **WordArt‑Transformationen anwenden**

In diesem Abschnitt untersuchen wir, wie Sie mit Aspose.Slides für .NET Transformationen in WordArt verwenden. Transformationen ermöglichen es Ihnen, Text zu biegen, zu strecken oder zu verzerren und so einzigartige, visuell eindrucksvolle Effekte zu erzeugen. Durch das Beherrschen dieser Techniken können Sie Textformen und -stile leicht an Ihre Marken‑ oder Kreativvision anpassen und so eine überzeugende, professionelle Präsentation sicherstellen.

Verwenden Sie die `Transform`‑Eigenschaft (die auf den gesamten Textblock angewendet wird) mit folgendem Code:
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


Der resultierende Text:

![Die WordArt‑Transformation](transform_effect.png)

{{% alert color="primary" %}} 

Aspose.Slides für .NET stellt eine Reihe vordefinierter [Transformationstypen](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/) bereit.

{{% /alert %}} 

### **3D‑Effekte auf Formen und Text anwenden**

Realistische, auffällige Visualisierungen können die Wirkung Ihrer Präsentationen erheblich steigern. In diesem Abschnitt erkunden wir, wie Sie dreidimensionale (3D)‑Effekte auf Formen mit Aspose.Slides für .NET anwenden. Durch die Manipulation von Parametern wie Tiefe, Winkel und Beleuchtung können Sie beeindruckende 3D‑Transformationen erzeugen, die sofort die Aufmerksamkeit Ihres Publikums fesseln. Ob Sie subtile Highlights oder dramatische Illusionen anstreben, diese Funktionen bieten flexible Möglichkeiten, Ihr Design zu erhöhen und Ideen ansprechender zu vermitteln.

Verwenden Sie den folgenden Beispielcode, um einer Form einen 3D‑Effekt zuzuweisen:
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

![Der 3D‑Effekt der Form](shape_3D_effect.png)

Verwenden Sie den folgenden Beispielcode, um einem Text einen 3D‑Effekt zuzuweisen:
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

![Der 3D‑Effekt des Textes](text_3D_effect.png)

{{% alert color="primary" %}} 

Die Anwendung von 3D‑Effekten auf Text oder deren Formen – und die Interaktion zwischen diesen Effekten – wird durch spezifische Regeln gesteuert. Betrachten Sie eine Szene, die sowohl einen Text als auch die Form, die diesen Text enthält, umfasst. Ein 3D‑Effekt beinhaltet die 3D‑Darstellung des Objekts und die Szene, in der es platziert ist.

- Wird für sowohl die Form als auch den Text eine Szene festgelegt, hat die Szene der Form Vorrang und die Szene des Textes wird ignoriert.
- Fehlt der Form eine eigene Szene, aber sie hat eine 3D‑Darstellung, wird die Szene des Textes verwendet.
- Hat die Form überhaupt keinen 3D‑Effekt, wird sie als flach behandelt und der 3D‑Effekt ausschließlich auf den Text angewendet.

Diese Verhaltensweisen beziehen sich auf die Eigenschaften [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) und [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/).

{{% /alert %}} 

## **FAQ**

**Kann ich WordArt‑Effekte mit verschiedenen Schriften oder Skripten (z. B. Arabisch, Chinesisch) verwenden?**

Ja, Aspose.Slides für .NET unterstützt Unicode und funktioniert mit allen gängigen Schriften und Skripten. WordArt‑Effekte wie Schatten, Füllung und Kontur können unabhängig von der Sprache angewendet werden, wobei die Verfügbarkeit und Darstellung von Schriften vom System abhängen kann.

**Kann ich WordArt‑Effekte auf Elemente des Folienmasters anwenden?**

Ja, Sie können WordArt‑Effekte auf Formen im Master‑Slide anwenden, einschließlich Titel‑Platzhaltern, Fußzeilen oder Hintergrundtext. Änderungen am Master‑Layout werden auf alle zugehörigen Folien übertragen.

**Beeinflussen WordArt‑Effekte die Dateigröße der Präsentation?**

Leicht. Effekte wie Schatten, Leuchten und Verlauf‑Füllungen können die Dateigröße aufgrund zusätzlicher Formatierungs‑Metadaten geringfügig erhöhen, doch ist der Unterschied normalerweise vernachlässigbar.

**Kann ich das Ergebnis von WordArt‑Effekten anzeigen, ohne die Präsentation zu speichern?**

Ja, Sie können Folien, die WordArt enthalten, mit der `GetImage`‑Methode aus den Schnittstellen [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) oder [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) in Bilder (z. B. PNG, JPEG) rendern. So können Sie das Ergebnis im Speicher oder auf dem Bildschirm prüfen, bevor Sie die komplette Präsentation speichern oder exportieren.