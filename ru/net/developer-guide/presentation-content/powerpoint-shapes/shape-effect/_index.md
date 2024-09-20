---
title: Эффект формы
type: docs
weight: 30
url: /net/shape-effect
keywords: "Эффект формы, Презентация PowerPoint C#, Csharp, Aspose.Slides для .NET"
description: "Примените эффект к форме PowerPoint в C# или .NET"
---

Хотя эффекты в PowerPoint могут использоваться для того, чтобы выделить форму, они отличаются от [заливок](/slides/net/shape-formatting/#gradient-fill) или обводок. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на форме, размывать свечение формы и т. д.

<img src="shape-effect.png" alt="эффект формы" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применить к формам. Вы можете применить один или несколько эффектов к форме.

* Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры под названием **Предустановленные настройки**. Предустановленные параметры — это, по сути, известная привлекательная комбинация двух или более эффектов. Таким образом, выбрав предустановленный вариант, вам не придется тратить время на тестирование или комбинирование различных эффектов для поиска привлекательной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Этот код на C# показывает, как применить эффект внешней тени ([OuterShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)) к прямоугольнику:

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

## **Применить эффект отражения**

Этот код на C# показывает, как применить эффект отражения к форме:

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

## **Применить эффект свечения**

Этот код на C# показывает, как применить эффект свечения к форме:

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

## **Применить эффект мягких краев**

Этот код на C# показывает, как применить эффект мягких краев к форме:

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableSoftEdgeEffect();
    shape.EffectFormat.SoftEdgeEffect.Radius = 15;

    pres.Save("softEdges.pptx", SaveFormat.Pptx);
}
```