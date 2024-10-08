---
title: Formeffekt
type: docs
weight: 30
url: /de/net/shape-effect
keywords: "Formeffekt, PowerPoint-Präsentation C#, Csharp, Aspose.Slides für .NET"
description: "Effekt auf PowerPoint-Form in C# oder .NET anwenden"
---

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/net/shape-formatting/#gradient-fill) oder Konturen. Mit PowerPoint-Effekten können Sie überzeugende Spiegelungen auf einer Form erstellen, den Glanz einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können eine oder mehrere Effekte auf eine Form anwenden.

* Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund gibt es in PowerPoint Optionen unter **Vorgabe**. Die Vorgabeoptionen sind im Wesentlichen eine bekannte, gut aussehende Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie durch die Auswahl einer Vorgabe keine Zeit mit dem Testen oder Kombinieren verschiedener Effekte verschwenden, um eine schöne Kombination zu finden.

Aspose.Slides bietet Eigenschaften und Methoden in der [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) Klasse, die es Ihnen ermöglichen, die gleichen Effekte auf Formen in PowerPoint-Präsentationen anzuwenden.

## **Schatteneffekt anwenden**

Dieser C#-Code zeigt, wie man den äußeren Schatteneffekt ([OuterShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)) auf ein Rechteck anwendet:

```c#
using (var pres = new Presentation())
{
    var shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableOuterShadowEffect();
    shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
    shape.EffectFormat.OuterShadowEffect.Distance = 10;
    shape.EffectFormat.OuterShadowEffect.Direction = 45;

    pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Spiegelungseffekt anwenden**

Dieser C#-Code zeigt, wie man den Spiegelungseffekt auf eine Form anwendet:

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableReflectionEffect();
    shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
    shape.EffectFormat.ReflectionEffect.Direction = 90;
    shape.EffectFormat.ReflectionEffect.Distance = 55;
    shape.EffectFormat.ReflectionEffect.BlurRadius = 4;

    pres.Save("reflection.pptx", SaveFormat.Pptx);
}
```

## **Leuchteffekt anwenden**

Dieser C#-Code zeigt, wie man den Leuchteffekt auf eine Form anwendet:

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableGlowEffect();
    shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
    shape.EffectFormat.GlowEffect.Radius = 15;

    pres.Save("glow.pptx", SaveFormat.Pptx);
}
```

## **Weiche Kanten anwenden**

Dieser C#-Code zeigt, wie man weiche Kanten auf eine Form anwendet:

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableSoftEdgeEffect();
    shape.EffectFormat.SoftEdgeEffect.Radius = 15;

    pres.Save("softEdges.pptx", SaveFormat.Pptx);
}
```