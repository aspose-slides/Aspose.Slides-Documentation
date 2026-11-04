---
title: Применение эффектов фигур в презентациях на .NET
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
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для .NET — создавайте эффектные, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint можно использовать, чтобы выделить объект, однако они отличаются от [fills](/slides/ru/net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать убедительные отражения на объекте, распространять свечение объекта и т. д.

![Shape effect](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к объектам. Вы можете применить один или несколько эффектов к объекту.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры в разделе **Preset**. Параметры Preset представляют собой известные эстетически хорошие комбинации двух и более эффектов. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках подходящей комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), которые позволяют применять те же эффекты к объектам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for .NET поддерживает внешние и внутренние тени для объектов. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали оформлению вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за границы объекта, создавая ощущение, что объект поднят над слайдом. Настройте её цвет, направление, расстояние и радиус размытия в соответствии со светом и стилем вашего шаблона.

Этот код на C# показывает, как применить [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) к прямоугольнику:

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

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели врезной вид. Внешняя тень выходит за пределы объекта и делает его выглядящим приподнятым, тогда как внутренняя тень затемняет внутренние стороны его границ.

Вызовите [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), затем настройте [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Большие значения дают более мягкие края.

Этот пример на C# создаёт светло-голубую карточку с темно-серой внутренней тенью и сохраняет её как файл PPTX:

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

Чтобы удалить внутреннюю тень, вызовите [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) у формата эффекта объекта.

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for .NET, вы можете добавить зеркальное отражение к объектам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетическое восприятие ваших презентаций, придавая объектам более отполированный и изысканный вид. Его легко реализовать с помощью простой кода, позволяя быстро применять его к нескольким элементам для единообразного дизайна.

Этот код на C# показывает, как применить [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) к объекту:

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

## **Применить эффект свечения**

Чтобы применить эффект свечения к объекту в Aspose.Slides for .NET, вы можете добавить мягкое светящееся сияние вокруг объектов, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить объекты и добавляет привлекательный, привлекающий внимание визуальный элемент в вашу презентацию. Его легко реализовать с минимальным кодом, улучшая общий вид ваших слайдов.

Этот код на C# показывает, как применить [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) к объекту:

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

## **Применить эффект мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for .NET, вы можете создать плавный, размытый переход по краям объекта. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого внешнего вида. Вы можете легко регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных объектов в презентации.

Этот код на C# показывает, как применить [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) к объекту:

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

## **Применить эффект размытия**

Используйте размытие объекта, чтобы смягчить заливку и контур объекта, сохраняя его редактируемым. Вызовите [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) у формата эффекта объекта. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, не меняет внешний вид.

Параметр [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) управляет видимыми границами эффекта. При `false` размытие обрезается до исходных нарисованных границ, включая контур. При `true` размытие может выходить за эти границы. Ни один из параметров не изменяет положение или размеры объекта.

Ниже представлено сравнение, использующее одинаковую заливку, контур и размеры объекта. В верхней строке `grow = false`; в нижней строке `grow = true`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов, при отключённом и включённом параметре grow](shape_blur_comparison.png)

Этот пример на C# создаёт оранжевый прямоугольник с тёмно-синим контуром, применяет размытие с радиусом 5 пунктов, а затем изменяет его до радиуса 15 пунктов, вновь вызывая [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Он сохраняет оба состояния с размытием, затем вызывает [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) и сохраняет объект без размытия.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Размытие объекта влияет как на заливку, так и на контур одновременно. Эффект мягких краёв делает края объекта более плавными, тогда как размытие тени смягчает только тень. Эффекты трансформации изображения работают с содержимым изображения; в этом примере размытие применяется напрямую к формату эффекта объекта без преобразования его в изображение.

## **Часто задаваемые вопросы**

**Могу ли я применить несколько эффектов к одному объекту?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одном объекте, чтобы создать более динамичный вид.

**К каким объектам я могу применять эффекты?**

Вы можете применять эффекты к различным объектам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и другие.

**Могу ли я применять эффекты к сгруппированным объектам?**

Да, вы можете применять эффекты к сгруппированным объектам. Эффект будет применён ко всей группе.