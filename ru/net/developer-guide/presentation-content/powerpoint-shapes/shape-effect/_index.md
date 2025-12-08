---
title: Применение эффектов фигур в PowerPoint с помощью C#
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/net/shape-effect
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- эффект фаски
- 3-D формат
- 3-D вращение
- PowerPoint
- презентация
- C#
- .NET
- Aspose.Slides
description: "Улучшите свои презентации PowerPoint с помощью потрясающих эффектов фигур, таких как тени, отражения и свечения, используя Aspose.Slides для .NET. Автоматизируйте визуальные улучшения с помощью простого в использовании кода и создавайте профессиональные слайды без усилий."
---

## **Обзор**

Хотя эффекты в PowerPoint могут использоваться для выделения фигуры, они отличаются от [заливок](/slides/ru/net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать реалистичные отражения на фигуре, распространять светящийся ореол фигуры и т.д.

<img src="shape-effect.png" alt="эффект-формы" style="zoom:50%;" />

PowerPoint предоставляет шесть эффектов, которые можно применять к фигурам. Вы можете применить один или несколько эффектов к фигуре.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры под **Preset**. Параметры Preset представляют собой проверенную комбинацию двух и более эффектов. Таким образом, выбрав предустановку, вам не придется тратить время на тестирование или комбинирование разных эффектов в поисках хорошего сочетания.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), позволяющие применять те же эффекты к фигурам в презентациях PowerPoint.

## **Применение эффекта тени**

Чтобы применить эффект тени к фигуре в Aspose.Slides for .NET, вы можете легко настроить такие параметры, как цвет, радиус размытия и направление. Это придаст вашим фигурам более динамичный и профессиональный вид, добавив глубину и фокус. С помощью простых фрагментов кода вы можете применять эти эффекты к нескольким фигурам, улучшая общий визуальный стиль ваших презентаций.

Этот C#‑код показывает, как применить [внешний эффект тени](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) к прямоугольнику:
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

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides for .NET, вы можете добавить зеркальное отражение к фигурам, настроив такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетику ваших презентаций, придавая фигурам более полированный и утончённый вид. Его легко реализовать с помощью простого кода, что позволяет быстро применять его к нескольким элементам для согласованного дизайна.

Этот C#‑код показывает, как применить [эффект отражения](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) к фигуре:
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

## **Применение эффекта свечения**

Чтобы применить эффект свечения к фигуре в Aspose.Slides for .NET, вы можете добавить мягкое светящееся сияние вокруг фигур, настроив свойства, такие как цвет и размер. Этот эффект помогает выделить фигуры и добавляет привлекательный визуальный элемент в вашу презентацию. Его легко реализовать с минимальным объёмом кода, улучшая общий внешний вид слайдов.

Этот C#‑код показывает, как применить [эффект свечения](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) к фигуре:
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

## **Применение эффекта мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for .NET, вы можете создать плавный, размытый переход вокруг краёв фигуры. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, требующих нежного, мягкого внешнего вида. Вы можете легко настроить такие параметры, как радиус, чтобы достичь желаемого эффекта для различных фигур в презентации.

Этот C#‑код показывает, как применить [мягкие края](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) к фигуре:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![Эффект мягких краёв](soft_edges_effect.png)

## **Вопросы и ответы**

**Можно ли применить несколько эффектов к одной и той же фигуре?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, для одной фигуры, создавая более динамичный вид.

**К каким типам фигур можно применять эффекты?**

Эффекты можно применять к различным типам фигур, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным фигурам?**

Да, эффекты можно применять к сгруппированным фигурам. Эффект будет применён ко всей группе.