---
title: Применение эффектов форм в презентациях на .NET
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/net/shape-effect/
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
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов форм, используя Aspose.Slides для .NET — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint могут использоваться, чтобы выделить объект, но они отличаются от [заливок](/slides/ru/net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на объекте, распространять световое свечение объекта и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к объектам. Вы можете применить один или несколько эффектов к объекту.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметр **Preset**. Опции Preset представляют собой проверенную привлекательную комбинацию из двух или более эффектов. Таким образом, выбирая предустановку, вам не придется тратить время на тестирование или комбинирование разных эффектов, чтобы найти хорошую комбинацию.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), которые позволяют применять те же эффекты к объектам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides для .NET поддерживает внешние и внутренние тени для объектов. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы границ объекта, создавая ощущение, что объект поднят над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещённости и стилю вашего шаблона.

Этот код C# демонстрирует, как применить [внешний эффект тени](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) к прямоугольнику:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **Применение внутренней тени**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное появление. Внешняя тень выходит за пределы объекта и делает его выглядящим поднятым, тогда как внутренняя тень затемняет внутреннюю часть его краёв.

Вызовите [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), затем настройте [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Более большие значения создают более мягкие края.

Этот пример C# создаёт светло-голубую карточку с темно-серой внутренней тенью и сохраняет её в файл PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Светло-голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) в формате эффекта объекта.

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides для .NET, вы можете добавить зеркальное отражение к объектам, регулируя параметры, такие как расстояние, прозрачность и размер. Этот эффект улучшает визуальную привлекательность ваших презентаций, придавая объектам более изысканный и утончённый вид. Его легко реализовать с помощью простого кода, обеспечивая быструю вставку на множестве элементов для единого дизайна.

Этот код C# демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) к объекту:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Чтобы применить эффект свечения к объекту в Aspose.Slides для .NET, вы можете добавить мягкую светящую ауру вокруг объектов, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить объекты и добавляет привлекательный, броский визуальный элемент в вашу презентацию. Его легко реализовать с минимальным кодом, улучшая общий вид ваших слайдов.

Этот код C# демонстрирует, как применить [эффект свечения](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) к объекту:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Чтобы применить эффект мягких краёв в Aspose.Slides для .NET, вы можете создать плавный, размытой переход по краям объекта. Этот эффект придаёт более нежный и изысканный вид, идеально подходящий для дизайнов, которым требуется мягкое, спокойное оформление. Вы легко можете регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных объектов в вашей презентации.

Этот код C# демонстрирует, как применить [мягкие края](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) к объекту:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Эффект мягких краёв](soft_edges_effect.png)

## **FAQ**

**Можно ли применить несколько эффектов к одному объекту?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одном объекте, чтобы создать более динамичный вид.

**Каким объектам можно применять эффекты?**

Эффекты можно применять к различным объектам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным объектам?**

Да, эффекты можно применять к сгруппированным объектам. Эффект будет применён ко всей группе.