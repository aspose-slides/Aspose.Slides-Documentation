---
title: تأثير الشكل
type: docs
weight: 30
url: /ar/net/shape-effect
keywords: "تأثير الشكل, عرض بوربوينت C#, Csharp, Aspose.Slides for .NET"
description: "تطبيق تأثير على شكل في PowerPoint باستخدام C# أو .NET"
---

بينما يمكن استخدام المؤثرات في PowerPoint لجعل الشكل بارزًا، إلا أنها تختلف عن [التعبئات](/slides/ar/net/shape-formatting/#gradient-fill) أو الحدود. باستخدام مؤثرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، إلخ.

<img src="shape-effect.png" alt="تأثير الشكل" style="zoom:50%;" />

* يوفر PowerPoint ستة مؤثرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على شكل ما. 

* تبدو بعض تركيبات المؤثرات أفضل من غيرها. لهذا السبب، تتوفر خيارات PowerPoint تحت **Preset**. خيارات Preset هي في الأساس مجموعة معروفة بمظهر جيد من اثنين أو أكثر من المؤثرات. بهذه الطريقة، من خلال اختيار ألمخصص، لن تضطر إلى إضاعة الوقت في اختبار أو دمج مؤثرات مختلفة للعثور على مجموعة جيدة.

توفر Aspose.Slides خصائص وطرق تحت فئة [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس المؤثرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

هذا الكود C# يوضح لك كيفية تطبيق تأثير الظل الخارجي ([OuterShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)) على مستطيل:

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

## **تطبيق تأثير الانعكاس**

هذا الكود C# يوضح لك كيفية تطبيق تأثير الانعكاس على شكل: 

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

## **تطبيق تأثير التوهج**

هذا الكود C# يوضح لك كيفية تطبيق تأثير التوهج على شكل: 

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

## **تطبيق تأثير الحواف الناعمة**

هذا الكود C# يوضح لك كيفية تطبيق الحواف الناعمة على شكل: 

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableSoftEdgeEffect();
    shape.EffectFormat.SoftEdgeEffect.Radius = 15;

    pres.Save("softEdges.pptx", SaveFormat.Pptx);
}
```