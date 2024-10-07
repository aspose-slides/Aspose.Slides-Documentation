---
title: WordArt
type: docs
weight: 110
url: /net/wordart/
keywords: "WordArt, Word Art, Erstelle WordArt, WordArt-Vorlage, WordArt-Effekte, Schatteneffekte, Anzeigeeffekte, Leuchteffekte, WordArt-Transformationen, 3D-Effekte, äußere Schatteneffekte, innere Schatteneffekte, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie WordArt und Effekte in PowerPoint-Präsentationen in C# oder Aspose.Slides für .NET hinzu, bearbeiten Sie sie und verwalten Sie sie."
---

## **Was ist WordArt?**
WordArt oder Word Art ist eine Funktion, die es Ihnen ermöglicht, Texteffekte anzuwenden, um sie hervorzuheben. Mit WordArt können Sie beispielsweise einen Text umreißen oder mit einer Farbe (oder einem Farbverlauf) füllen, ihm 3D-Effekte hinzufügen usw. Sie können auch die Form eines Textes verzerren, biegen und dehnen.

{{% alert color="primary" %}} 

WordArt ermöglicht es Ihnen, einen Text wie ein grafisches Objekt zu behandeln. WordArt besteht aus Effekten oder speziellen Modifikationen, die an Texten vorgenommen werden, um sie attraktiver oder auffälliger zu machen.

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

Um WordArt in Microsoft PowerPoint zu verwenden, müssen Sie eine der vordefinierten WordArt-Vorlagen auswählen. Eine WordArt-Vorlage ist eine Menge von Effekten, die auf einen Text oder dessen Form angewendet werden.

**WordArt in Aspose.Slides**

In Aspose.Slides für .NET 20.10 haben wir die Unterstützung für WordArt implementiert und die Funktion in den nachfolgenden Versionen von Aspose.Slides für .NET verbessert.

Mit Aspose.Slides für .NET können Sie ganz einfach Ihre eigene WordArt-Vorlage (einen Effekt oder eine Kombination von Effekten) in C# erstellen und auf Texte anwenden.

## Erstellen einer einfachen WordArt-Vorlage und Anwenden auf einen Text

**Verwendung von Aspose.Slides** 

Zuerst erstellen wir einen einfachen Text mit diesem C#-Code: 

``` csharp 
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    Portion portion = (Portion)textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```
Jetzt setzen wir die Schriftgröße des Textes auf einen größeren Wert, um den Effekt durch diesen Code auffälliger zu machen:

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

**Verwendung von Microsoft PowerPoint**

Gehen Sie zum WordArt-Effekte-Menü in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Im Menü auf der rechten Seite können Sie einen vordefinierten WordArt-Effekt auswählen. Im Menü auf der linken Seite können Sie die Einstellungen für eine neue WordArt festlegen. 

Dies sind einige der verfügbaren Parameter oder Optionen:

![todo:image_alt_text](image-20200930114015-3.png)

**Verwendung von Aspose.Slides**

Hier wenden wir die SmallGrid-Musterfarbe auf den Text an und fügen mit diesem Code einen schwarzen Textumriss mit einer Breite von 1 hinzu:

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Der resultierende Text:

![todo:image_alt_text](image-20200930114108-4.png)

## Anwenden anderer WordArt-Effekte

**Verwendung von Microsoft PowerPoint**

Aus der Benutzeroberfläche des Programms können Sie diese Effekte auf einen Text, Textblock, Form oder ähnliches Element anwenden:

![todo:image_alt_text](image-20200930114129-5.png)

Beispielsweise können Schatteneffekte, Reflexionen und Leuchteffekte auf einen Text angewendet werden; 3D-Format- und 3D-Rotations-Effekte können auf einen Textblock angewendet werden; die Eigenschaft "Weiche Kanten" kann auf ein Formobjekt angewendet werden (es hat immer noch einen Effekt, wenn keine 3D-Format-Eigenschaft festgelegt ist). 

### Anwenden von Schatteneffekten

Hier beabsichtigen wir, die Eigenschaften zu setzen, die sich nur auf einen Text beziehen. Wir wenden den Schatteneffekt auf einen Text an, indem wir diesen Code in C# verwenden:

``` csharp 
portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 65;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4.73;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 2;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Die Aspose.Slides-API unterstützt drei Arten von Schatten: OuterShadow, InnerShadow und PresetShadow.

Mit PresetShadow können Sie einen Schatten für einen Text anwenden (unter Verwendung von vordefinierten Werten).

**Verwendung von Microsoft PowerPoint**

In PowerPoint können Sie einen Typ von Schatten verwenden. Hier ist ein Beispiel:

![todo:image_alt_text](image-20200930114225-6.png)

**Verwendung von Aspose.Slides**

Aspose.Slides ermöglicht es Ihnen tatsächlich, zwei Arten von Schatten gleichzeitig anzuwenden: InnerShadow und PresetShadow.

**Hinweise:**

- Wenn OuterShadow und PresetShadow zusammen verwendet werden, wird nur der OuterShadow-Effekt angewendet.
- Wenn OuterShadow und InnerShadow gleichzeitig verwendet werden, hängt der resultierende oder angewendete Effekt von der PowerPoint-Version ab. Zum Beispiel wird in PowerPoint 2013 der Effekt verdoppelt. Aber in PowerPoint 2007 wird der OuterShadow-Effekt angewendet. 

### Anwenden von Anzeige auf Texte

Wir fügen Anzeige auf den Text durch dieses C#-Codebeispiel hinzu:

``` csharp 
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

### Anwenden des Leuchteffekts auf Texte

Wir wenden den Leuchteffekt auf den Text an, um ihn zum Leuchten oder Hervorheben zu bringen, indem wir diesen Code verwenden:

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Sie können die Parameter für Schatten, Anzeige und Glühen ändern. Die Eigenschaften der Effekte werden für jeden Textabschnitt separat festgelegt.

{{% /alert %}} 

### Verwendung von Transformationen in WordArt

Wir verwenden die Transform-Eigenschaft (inherent im gesamten Textblock) durch diesen Code:
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Das Ergebnis:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sowohl Microsoft PowerPoint als auch Aspose.Slides für .NET bieten eine bestimmte Anzahl von vordefinierten Transformationstypen. 

{{% /alert %}} 

**Verwendung von PowerPoint**

Um auf vordefinierte Transformationstypen zuzugreifen, gehen Sie zu: **Format** -> **TextEffect** -> **Transform**

**Verwendung von Aspose.Slides**

Um einen Transformationstyp auszuwählen, verwenden Sie das TextShapeType-Enum.

### Anwenden von 3D-Effekten auf Texte und Formen

Wir setzen einen 3D-Effekt auf eine Textform mit diesem Beispielcode:

``` csharp 
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

Der resultierende Text und seine Form:

![todo:image_alt_text](image-20200930114816-9.png)

Wir wenden einen 3D-Effekt auf den Text mit diesem C#-Code an:

``` csharp 
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

Das Ergebnis der Operation:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Die Anwendung von 3D-Effekten auf Texte oder ihre Formen und die Interaktionen zwischen Effekten basieren auf bestimmten Regeln. 

Betrachten Sie eine Szene für einen Text und die Form, die diesen Text enthält. Der 3D-Effekt enthält die 3D-Darstellung des Objekts und die Szene, auf der das Objekt platziert wurde. 

- Wenn die Szene sowohl für die Figur als auch für den Text festgelegt ist, hat die Figur-Szene die höhere Priorität—die Textszene wird ignoriert. 
- Wenn die Figur keine eigene Szene hat, aber eine 3D-Darstellung hat, wird die Textszene verwendet. 
- Andernfalls—wenn die Form ursprünglich keinen 3D-Effekt hat—ist die Form flach und der 3D-Effekt wird nur auf den Text angewendet. 

Die Beschreibungen beziehen sich auf die [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/lightrig) und [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/camera) Eigenschaften.

{{% /alert %}} 

## **Anwenden von äußeren Schatteneffekten auf Texte**
Aspose.Slides für .NET bietet die [**IOuterShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow) und [**IInnerShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/iinnershadow) Klassen, die es Ihnen ermöglichen, Schatteneffekte auf einen Text, der durch TextFrame getragen wird, anzuwenden. Gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz eines Slides anhand ihres Index.
3. Fügen Sie einen AutoShape vom Rechtecktyp zum Slide hinzu.
4. Greifen Sie auf den mit dem AutoShape verknüpften TextFrame zu.
5. Setzen Sie den FillType des AutoShape auf NoFill.
6. Instanziieren Sie die Klasse OuterShadow.
7. Setzen Sie den BlurRadius des Schattens.
8. Setzen Sie die Richtung des Schattens.
9. Setzen Sie die Entfernung des Schattens.
10. Setzen Sie den RectangleAlign auf TopLeft.
11. Setzen Sie die PresetColor des Schattens auf Schwarz.
12. Schreiben Sie die Präsentation als PPTX-Datei.

Dieser Beispielcode in C#—eine Implementierung der obigen Schritte—zeigt Ihnen, wie Sie den äußeren Schatteneffekt auf einen Text anwenden:

```c#
using (Presentation pres = new Presentation())
{

    // Holen Sie sich die Referenz des Slides
    ISlide sld = pres.Slides[0];

    // Fügen Sie einen AutoShape vom Rechtecktyp hinzu
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Fügen Sie dem Rechteck einen TextFrame hinzu
    ashp.AddTextFrame("Aspose TextBox");

    // Deaktivieren Sie die Füllung der Form, falls wir den Schatten des Textes erhalten möchten
    ashp.FillFormat.FillType = FillType.NoFill;

    // Fügen Sie den äußeren Schatten hinzu und setzen Sie alle erforderlichen Parameter
    ashp.EffectFormat.EnableOuterShadowEffect();
    IOuterShadow shadow = ashp.EffectFormat.OuterShadowEffect;
    shadow.BlurRadius = 4.0;
    shadow.Direction = 45;
    shadow.Distance = 3;
    shadow.RectangleAlign = RectangleAlignment.TopLeft;
    shadow.ShadowColor.PresetColor = PresetColor.Black;

    // Schreiben Sie die Präsentation auf die Festplatte
    pres.Save("pres_out.pptx", SaveFormat.Pptx);
}
```


## **Anwenden des inneren Schattens auf Formen**
Gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich eine Referenz des Slides.
3. Fügen Sie einen AutoShape vom Rechtecktyp hinzu.
4. Aktivieren Sie den InnerShadowEffect.
5. Setzen Sie alle erforderlichen Parameter.
6. Setzen Sie den ColorType auf Scheme.
7. Setzen Sie die Scheme-Farbe.
8. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Dieser Beispielcode (basierend auf den obigen Schritten) zeigt Ihnen, wie Sie einen Verbindung zwischen zwei Formen in C# hinzufügen:

```c#
using(Presentation presentation = new Presentation())
{
    // Holen Sie sich die Referenz eines Slides
    ISlide slide = presentation.Slides[0];

    // Fügen Sie einen AutoShape vom Rechtecktyp hinzu
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.FillFormat.FillType = FillType.NoFill;

    // Fügen Sie dem Rechteck einen TextFrame hinzu
    ashp.AddTextFrame("Aspose TextBox");
    IPortion port = ashp.TextFrame.Paragraphs[0].Portions[0];
    IPortionFormat pf = port.PortionFormat;
    pf.FontHeight = 50;

    // Aktivieren Sie den InnerShadowEffect    
    IEffectFormat ef = pf.EffectFormat;
    ef.EnableInnerShadowEffect();

    // Setzen Sie alle erforderlichen Parameter
    ef.InnerShadowEffect.BlurRadius = 8.0;
    ef.InnerShadowEffect.Direction = 90.0F;
    ef.InnerShadowEffect.Distance = 6.0;
    ef.InnerShadowEffect.ShadowColor.B = 189;

    // Setzen Sie den ColorType auf Schema
    ef.InnerShadowEffect.ShadowColor.ColorType = ColorType.Scheme;

    // Setzen Sie die Schema-Farbe
    ef.InnerShadowEffect.ShadowColor.SchemeColor = SchemeColor.Accent1;

    // Präsentation speichern
    presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
}
```