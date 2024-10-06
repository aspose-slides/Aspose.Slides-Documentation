---
title: Effet de forme
type: docs
weight: 30
url: /net/shape-effect
keywords: "Effet de forme, présentation PowerPoint C#, Csharp, Aspose.Slides pour .NET"
description: "Appliquer un effet à une forme PowerPoint en C# ou .NET"
---

Bien que les effets dans PowerPoint puissent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/net/shape-formatting/#gradient-fill) ou des contours. En utilisant des effets PowerPoint, vous pouvez créer des réflexions convaincantes sur une forme, étendre l’éclat d’une forme, etc.

<img src="shape-effect.png" alt="effet de forme" style="zoom:50%;" />

* PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme. 

* Certaines combinaisons d’effets ont un meilleur aspect que d’autres. Pour cette raison, les options PowerPoint sous **Style prédéfini**. Les options de Style prédéfini sont essentiellement une combinaison connue et esthétique de deux effets ou plus. De cette manière, en sélectionnant un style prédéfini, vous n'aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une belle combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) qui vous permettent d'appliquer les mêmes effets aux formes dans des présentations PowerPoint.

## **Appliquer l'effet d'ombre**

Ce code C# vous montre comment appliquer l'effet d'ombre extérieure ([OuterShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)) à un rectangle :

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

## **Appliquer l'effet de réflexion**

Ce code C# vous montre comment appliquer l'effet de réflexion à une forme : 

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

## **Appliquer l'effet de lueur**

Ce code C# vous montre comment appliquer l'effet de lueur à une forme : 

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

## **Appliquer l'effet de bords adoucis**

Ce code C# vous montre comment appliquer les bords adoucis à une forme : 

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableSoftEdgeEffect();
    shape.EffectFormat.SoftEdgeEffect.Radius = 15;

    pres.Save("softEdges.pptx", SaveFormat.Pptx);
}
```