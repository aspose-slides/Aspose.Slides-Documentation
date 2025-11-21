---
title: Применение эффектов фигур в презентациях на .NET
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/net/shape-effect
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для .NET — создавайте впечатляющие, профессиональные слайды за секунды."
---

## **Обзор**

Хотя эффекты в PowerPoint можно использовать, чтобы выделить объект, они отличаются от [fills](/slides/ru/net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать убедительные отражения объекта, распространять его сияние и т. д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint предоставляет шесть эффектов, которые можно применить к объектам. Вы можете применить один или несколько эффектов к объекту.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры под **Preset**. Параметры Preset представляют собой проверенные комбинации двух и более эффектов, выглядящие хорошо. Таким образом, выбрав предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), которые позволяют применять те же эффекты к объектам в презентациях PowerPoint.

## **Применить эффект тени**

Чтобы применить эффект тени к объекту в Aspose.Slides для .NET, вы можете легко настроить такие параметры, как цвет, радиус размытия и направление. Это придаёт вашим объектам более динамичный и профессиональный вид, добавляя глубину и фокус. С помощью простых фрагментов кода вы можете применить эти эффекты к нескольким объектам, улучшив общую визуальную привлекательность ваших презентаций.

Этот C# код показывает, как применить [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) к прямоугольнику:
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

Чтобы применить эффект отражения в Aspose.Slides для .NET, вы можете добавить зеркальное отражение к объектам, настроив такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетику ваших презентаций, придавая объектам более полированный и изысканный вид. Реализовать его просто с помощью небольшого кода, позволяющего быстро применять его к нескольким элементам для согласованного дизайна.

Этот C# код показывает, как применить [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) к объекту:
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

Чтобы применить эффект свечения к объекту в Aspose.Slides для .NET, вы можете добавить мягкую светящуюся ауру вокруг объектов, настроив такие свойства, как цвет и размер. Этот эффект помогает объектам выделяться и добавляет привлекательный визуальный элемент в вашу презентацию. Реализовать его легко с минимальным кодом, улучшая общий внешний вид слайдов.

Этот C# код показывает, как применить [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) к объекту:
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

Чтобы применить эффект мягких краёв в Aspose.Slides для .NET, вы можете создать плавный размытой переход по краям объекта. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого оформления. Вы можете легко настроить такие параметры, как радиус, чтобы достичь желаемого результата на различных объектах в вашей презентации.

Этот C# код показывает, как применить [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) к объекту:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![Эффект мягких краёв](soft_edges_effect.png)

## **FAQ**

**Могу ли я применить несколько эффектов к одному объекту?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одном объекте, чтобы создать более динамичный вид.

**К каким объектам можно применять эффекты?**

Эффекты можно применять к различным объектам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Могу ли я применять эффекты к сгруппированным объектам?**

Да, вы можете применять эффекты к сгруппированным объектам. Эффект будет применён ко всей группе.