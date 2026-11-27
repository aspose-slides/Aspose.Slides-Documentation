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
description: "Преобразуйте свои файлы PPT и PPTX с помощью расширенных эффектов форм, используя Aspose.Slides for .NET — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint могут использоваться для выделения формы, но они отличаются от [заливок](/slides/ru/net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать реалистичные отражения на форме, расширять свечение формы и т. д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые могут применяться к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры под **Preset**. Параметры Preset представляют собой известную хорошо выглядящую комбинацию из двух и более эффектов. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поиске удачной комбинации.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides for .NET поддерживает внешние и внутренние тени для форм. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы краёв формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

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

#### **Управление направлением тени при повороте формы**

По умолчанию [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) имеет значение `true`, поэтому тень вращается вместе с формой. Чтобы формы с разными поворотами выглядели освещёнными из одного и того же направления, установите это свойство в `false` и задайте их теням одинаковое значение [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/).

В примере создаются две стрелки с серыми тенями, смещёнными вправо (`Direction = 0`). Затем слайд дублируется, и обе стрелки поворачиваются на 90° по часовой стрелке.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

На втором слайде левая стрелка отбрасывает тень вниз, тогда как правая стрелка всё ещё отбрасывает тень вправо. Настроенное направление остаётся 0° для обеих теней.

![Отображение PowerPoint до и после вращения на 90°. Обе тени изначально находятся справа. После вращения тень перемещается под левую стрелку и остаётся справа от правой стрелки.](arrow-shadow-rotation.png)

### **Применение внутренней тени**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленный вид. Внешняя тень выходит за пределы формы и делает её выглядящей поднятой, тогда как внутренняя тень затемняет внутренние стороны её краёв.

Вызовите [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), затем настройте [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Большие значения дают более мягкие края.

В этом примере C# создаётся светло‑голубая карточка с темно‑серой внутренней тенью и сохраняется как файл PPTX:

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

Для удаления внутренней тени вызовите [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) у формата эффектов формы.

### **Применение, изменение и удаление предустановленной тени**

Вызовите [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) и установите [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) в один из именованных [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/). Чтобы переключить стили, измените предустановку у той же формы. Вызовите [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) чтобы удалить тень, сохранив заливку и контур.

В этом примере сохраняется копия прямоугольника на каждом этапе. Обе тени смещены на 10 пунктов. Направление 225° размещает первую тень сверху и слева от прямоугольника, а 45° — вторую снизу и справа.

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
| ![Нет тени](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![Нет тени после удаления](preset_shadow_removed.png) |

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides for .NET, вы можете добавить зеркальное отражение к формам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более отточенный и изысканный вид. Его легко реализовать с помощью простого кода, позволяющего быстро применять эффект к множеству элементов для согласованного дизайна.

Этот код C# показывает, как применить [эффект отражения](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) к форме:

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

Чтобы применить эффект свечения к форме в Aspose.Slides for .NET, вы можете добавить мягкую светящуюся ауру вокруг формы, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный визуальный элемент в вашу презентацию. Его легко реализовать с минимальным кодом, улучшая общий вид ваших слайдов.

Этот код C# показывает, как применить [эффект свечения](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) к форме:

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

Чтобы применить эффект мягких краёв в Aspose.Slides for .NET, вы можете создать плавный, размытый переход вокруг краёв формы. Этот эффект добавляет более тонкий и изысканный вид, идеально подходящий для дизайнов, которым нужен нежный, мягкий вид. Вы можете легко регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных форм в вашей презентации.

Этот код C# показывает, как применить [мягкие края](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) к форме:

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

Используйте размытие формы, чтобы смягчить заливку и контур формы, сохраняя её редактируемой. Вызовите [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, оставляет внешний вид без изменений.

Параметр [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) управляет видимыми границами эффекта. При `false` размытие ограничивается исходными нарисованными границами, включая контур. При `true` размытие может выходить за эти границы. Ни один из параметров не меняет положение или размеры формы.

Сравнение ниже использует одинаковую заливку, контур и размеры формы на протяжении всего примера. В верхней строке `grow = false`; в нижней строке `grow = true`.

![Исходный прямоугольник, сравниваемый с радиусами размытия 5 и 15 пунктов, с отключённым и включённым параметром grow](shape_blur_comparison.png)

В этом примере C# создаётся оранжевый прямоугольник с тёмно‑синим контуром, применяется размытие радиусом 5 пунктов, затем оно обновляется до 15 пунктов с повторным вызовом [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) снова. Сохраняются обе размытые версии, после чего вызывается [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) и сохраняется форма без размытия.

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

Размытие формы воздействует одновременно на заливку и контур. Эффект мягких краёв постепенно стирает края формы, тогда как размытие тени смягчает только тень. Эффекты преобразования изображений работают с содержимым изображения; в этом примере размытие применяется непосредственно к формату эффектов формы без преобразования формы в изображение.

## **Вопросы и ответы**

**Можно ли применить несколько эффектов к одной форме?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автоформы, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применяться ко всей группе.