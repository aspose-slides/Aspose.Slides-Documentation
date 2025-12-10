---
title: Применение эффектов фигур в презентациях в .NET
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/net/shape-effect
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью расширенных эффектов фигур, используя Aspose.Slides для .NET — создавайте эффектные, профессиональные слайды за секунды."
---

## **Обзор**

В то время как эффекты в PowerPoint могут использоваться, чтобы выделить форму, они отличаются от [fills](/slides/ru/net/shape-formatting/#gradient-fill) или обводок. С помощью эффектов PowerPoint вы можете создавать правдоподобные отражения формы, распространять её сияние и т.д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры в разделе **Preset**. Параметры Preset по сути представляют собой известную эстетически приятную комбинацию двух или более эффектов. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), позволяющие применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Чтобы применить эффект тени к форме в Aspose.Slides для .NET, вы можете легко настроить такие параметры, как цвет, радиус размытия и направление. Это придаёт вашим формам более динамичный и профессиональный вид, добавляя глубину и акцент. Используя простые фрагменты кода, вы можете применять эти эффекты к нескольким формам, улучшая общий визуальный вид ваших презентаций.

Этот код C# показывает, как применить [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) к прямоугольнику:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```


![Эффект тени](shadow_effect.png)

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides для .NET, вы можете добавить зеркальное отражение к формам, настраивая параметры такие как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более полированный и изысканный вид. Легко реализуется с помощью простого кода, позволяя быстро применять его к нескольким элементам для согласованного дизайна.

Этот код C# показывает, как применить [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) к форме:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```


![Эффект отражения](reflection_effect.png)

## **Применить эффект свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides для .NET, вы можете добавить мягкое светящееся сияние вокруг формы, настраивая такие свойства, как цвет и размер. Этот эффект помогает выделить форму и добавляет привлекательный визуальный элемент вашей презентации. Его легко реализовать с минимальным объёмом кода, улучшая общий внешний вид слайдов.

Этот код C# показывает, как применить [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) к форме:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```


![Эффект свечения](glow_effect.png)

## **Применить эффект мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides для .NET, вы можете создать плавный размазанный переход вокруг краёв формы. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, которым требуется нежное, более мягкое оформление. Вы легко можете настраивать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных форм в вашей презентации.

Этот код C# показывает, как применить [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) к форме:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![Эффект мягких краёв](soft_edges_effect.png)

## **Часто задаваемые вопросы**

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**Каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, эффекты можно применять к сгруппированным формам. Эффект будет применён ко всей группе.