---
title: Применение эффектов фигур в презентациях на .NET
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/net/shape-effect/
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
description: "Преобразуйте свои файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для .NET — создавайте впечатляющие, профессиональные слайды за секунды."
---
## **Введение**

В то время как эффекты в PowerPoint могут использоваться для выделения фигуры, они отличаются от [заливок](/slides/ru/net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать правдоподобные отражения на фигуре, распространять свечение фигуры и т.д.

![Эффект фигуры](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к фигурам. Вы можете применить один или несколько эффектов к фигуре.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры в разделе **Preset**. Параметры Preset представляют собой проверенные эстетически приятные комбинации двух и более эффектов. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование различных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), позволяющие применять те же эффекты к фигурам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides for .NET поддерживает внешние и внутренние тени для фигур. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы сделать карточку или панель более заметной на фоне слайда. Тень выходит за пределы краёв фигуры, создавая ощущение, что фигура поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот код C# показывает, как применить [внешний эффект тени](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) к прямоугольнику:

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

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное отображение. Внешняя тень выходит за пределы фигуры и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутренние края.

Вызовите [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), затем настройте [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Большие значения дают более мягкие края.

Этот пример C# создаёт светло‑голубую карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX:

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

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) у формата эффектов фигуры.

### **Применение, изменение и удаление предустановленной тени**

Вызовите [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) и установите [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) в именованный [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/). Чтобы переключить стили, измените предустановку той же фигуры. Вызовите [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) для удаления тени при сохранении заливки и контура.

В этом примере на каждом этапе сохраняется копия прямоугольника. Обе тени смещены на 10 пунктов. Направление 225° размещает первую тень выше и слева от прямоугольника, а 45° — вторую ниже и справа.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| Оригинал | Первая предустановка | Вторая предустановка | После удаления |
| :---: | :---: | :---: | :---: |
| ![Нет тени](preset_shadow_original.png) | ![Тень сверху‑слева](preset_shadow_top_left.png) | ![Тень снизу‑справа](preset_shadow_bottom_right.png) | ![Нет тени после удаления](preset_shadow_removed.png) |

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides for .NET, вы можете добавить зеркальное отражение к фигурам, регулируя параметры, такие как расстояние, прозрачность и размер. Этот эффект улучшает эстетическое восприятие ваших презентаций, придавая фигурам более изысканный и отполированный вид. Его легко реализовать с помощью простого кода, позволяющего быстро применять эффект к нескольким элементам для согласованного дизайна.

Этот код C# показывает, как применить [эффект отражения](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) к фигуре:

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

Чтобы применить эффект свечения к фигуре в Aspose.Slides for .NET, вы можете добавить мягкое светящееся свечение вокруг фигур, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить фигуры и добавляет привлекательный, бросающийся в глаза визуальный элемент в вашу презентацию. Его легко реализовать с минимальным объёмом кода, улучшая общий вид ваших слайдов.

Этот код C# показывает, как применить [эффект свечения](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) к фигуре:

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

Чтобы применить эффект мягких краёв в Aspose.Slides for .NET, вы можете создать плавный размытый переход по краям фигуры. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого отображения. Вы можете легко регулировать параметры, такие как радиус, чтобы достичь требуемого эффекта на разных фигурах в презентации.

Этот код C# показывает, как применить [мягкие края](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) к фигуре:

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

## **Применение эффекта размытия**

Используйте размытие фигуры, чтобы смягчить её заливку и контур, сохраняя возможность редактирования фигуры. Вызовите [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) у формата эффектов фигуры. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, более крупные значения дают более сильное размытие. Радиус, равный нулю, не меняет внешний вид.

Параметр [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) управляет видимыми границами эффекта. При `false` размытие обрезается по исходным границам рисунка, включая контур. При `true` размытие может выходить за эти границы. Ни один из параметров не меняет положение или размеры фигуры.

Сравнение ниже использует одинаковую заливку, контур и размеры фигуры. В верхней строке `grow = false`; в нижней строке `grow = true`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов, при отключённом и включённом Grow](shape_blur_comparison.png)

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

Этот пример C# создаёт оранжевый прямоугольник с тёмно‑синим контуром, применяет размытие радиусом 5 пунктов, а затем обновляет его до размытия 15 пунктов, снова вызывая [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Он сохраняет оба размазанных состояния, затем вызывает [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) и сохраняет фигуру без размытия.

Размытие фигуры влияет одновременно на заливку и контур. Эффект мягких краёв сглаживает края фигуры, тогда как размытие тени смягчает только тень. Эффекты преобразования изображений работают с содержимым изображения; в этом примере размытие применяется напрямую к формату эффектов фигуры без преобразования её в изображение.

## **Вопросы и ответы**

**Можно ли применить несколько эффектов к одной и той же фигуре?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечение, на одной фигуре, чтобы создать более динамичный вид.

**К каким фигурам можно применять эффекты?**

Вы можете применять эффекты к различным фигурам, включая авт-фигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным фигурам?**

Да, вы можете применить эффекты к сгруппированным фигурам. Эффект будет применён ко всей группе.