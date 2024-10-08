---
title: 形状效果
type: docs
weight: 30
url: /net/shape-effect
keywords: "形状效果，PowerPoint 演示文稿 C#，Csharp，Aspose.Slides for .NET"
description: "在 C# 或 .NET 中对 PowerPoint 形状应用效果"
---

虽然 PowerPoint 中的效果可以使形状突出，但它们与 [填充](/slides/net/shape-formatting/#gradient-fill) 或轮廓不同。使用 PowerPoint 效果，您可以在形状上创建令人信服的反射、扩散形状的光晕等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供了六种可以应用于形状的效果。您可以将一种或多种效果应用于形状。

* 一些效果组合看起来比其他组合更好。因此，PowerPoint 在 **预设** 下提供选项。预设选项主要是两个或更多效果的已知好看组合。通过选择预设，您就不必浪费时间测试或组合不同的效果以找到不错的组合。

Aspose.Slides 提供了 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 类下的属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

以下 C# 代码演示了如何对矩形应用外部阴影效果 ([OuterShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/))：

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

## **应用反射效果**

以下 C# 代码演示了如何对形状应用反射效果：

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

## **应用光晕效果**

以下 C# 代码演示了如何对形状应用光晕效果：

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

## **应用柔和边缘效果**

以下 C# 代码演示了如何给形状应用柔和边缘效果：

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableSoftEdgeEffect();
    shape.EffectFormat.SoftEdgeEffect.Radius = 15;

    pres.Save("softEdges.pptx", SaveFormat.Pptx);
}
```