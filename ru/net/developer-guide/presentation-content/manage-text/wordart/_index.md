---
title: Создание и применение эффектов WordArt в .NET
linktitle: WordArt
type: docs
weight: 110
url: /ru/net/wordart/
keywords:
- WordArt
- создать WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отражения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- .NET
- C#
- Aspose.Slides
description: "Создавайте и настраивайте эффекты WordArt в Aspose.Slides для .NET. Это пошаговое руководство помогает разработчикам улучшать презентации профессиональным текстом на C#."
---
## **Обзор**

Эффекты WordArt позволяют оформлять текст с помощью заливок, контуров, теней, отражений, свечения, трансформаций и 3D‑форматирования. В этой статье объясняется, как создавать и настраивать эти эффекты в презентациях PowerPoint с использованием Aspose.Slides for .NET без установки Microsoft Office.

## **Создать простой шаблон WordArt и применить его к тексту**

Следующие примеры создают простой стиль WordArt, задавая текст, шрифт, заливку узором и контур.

Каждый пример создает новую презентацию и добавляет прямоугольник на первый слайд; входной файл не требуется. Первый пример задаёт текст «Aspose.Slides». Позиция и размеры фигуры измеряются в пунктах:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Задайте шрифт Arial Black размером 36 пунктов, чтобы форматирование было более заметным:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Примените узор [SmallGrid](https://reference.aspose.com/slides/ru/net/aspose.slides/patternstyle/) с тёмно‑оранжевым передним планом и белым фоном, затем добавьте чёрный контур текста шириной 1 пункт:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Полученный текст:

![Простой шаблон WordArt](WordArt_template.png)

## **Применить другие эффекты WordArt**

Следующие примеры демонстрируют, как применять тени, отражения, свечение, трансформации и 3D‑эффекты к тексту.

### **Применить внешние теневые эффекты**

Внешняя тень добавляет глубину, размещая тень за текстом. Вы можете настроить её цвет, направление, расстояние, радиус размытия, масштаб и наклон.

Этот пример вызывает [EnableOuterShadowEffect](https://reference.aspose.com/slides/ru/net/aspose.slides/effectformat/enableoutershadoweffect/) и задаёт чёрную тень с радиусом размытия 4 пункта, направлением 230 градусов и расстоянием 30 пунктов. Значения масштаба 100 сохраняют размер тени, а горизонтальный наклон наклоняет её на 20 градусов. Альфа‑преобразование задаёт непрозрачность 32%:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Полученный текст:

![Эффект внешней тени](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- При одновременном использовании внешних и предустановленных теней применяется только внешняя тень.  
- Если одновременно использовать внешние и внутренние тени, результирующий эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только внешняя тень.  
{{% /alert %}}

### **Применить эффекты отражения**

Отражение создаёт зеркальную копию текста. Регулируйте позицию, масштаб, размытие и непрозрачность, чтобы управлять его видом.

Этот пример вызывает [EnableReflectionEffect](https://reference.aspose.com/slides/ru/net/aspose.slides/effectformat/enablereflectioneffect/) и переворачивает отражение вертикально с масштабом –100 %. Он использует радиус размытия 0,5 пункта и расстояние 4,72 пункта. Непрозрачность уменьшается с 60 % до 0,9 % между позициями 0 % и 60 % вдоль отражения:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

Полученный текст:

![Эффект отражения](reflection_effect.png)

### **Применить эффекты свечения**

Свечение добавляет мягкий цветной контур вокруг текста. Регулируйте цвет, непрозрачность и радиус, чтобы управлять эффектом.

Этот пример вызывает [EnableGlowEffect](https://reference.aspose.com/slides/ru/net/aspose.slides/effectformat/enablegloweffect/) и применяет красное свечение с непрозрачностью 54 % и радиусом 7 пунктов:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Полученный текст:

![Эффект свечения](glow_effect.png)

### **Применить трансформации WordArt**

Трансформации WordArt изгибают, растягивают или искажают блок текста.

Установите [Transform](https://reference.aspose.com/slides/ru/net/aspose.slides/textframeformat/transform/) в значение [ArchUpPour](https://reference.aspose.com/slides/ru/net/aspose.slides/textshapetype/), чтобы выгнуть весь текстовый фрейм вверх:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Полученный текст:

![Трансформация WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET предоставляет набор предопределённых [видов трансформаций](https://reference.aspose.com/slides/ru/net/aspose.slides/textshapetype/).  
{{% /alert %}}

### **Применить 3D‑эффекты к фигурам и тексту**

Вы можете применять 3D‑эффекты к фигуре или к её тексту. Скосы, экструдирование, освещение и настройки камеры управляют конечным видом.

Следующий пример использует [ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/) для добавления круглых скосов, оранжевого экструдирования и тёмно‑красного контура к прямоугольнику. Размеры скосов, высота экструдирования, ширина контура и глубина измеряются в пунктах. Пластиковый материал, сбалансированное освещение, повёрнутое на 40° вокруг оси Z, и перспективная камера определяют его внешний вид:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Полученная фигура:

![3D‑эффект фигуры](shape_3D_effect.png)

Этот пример применяет аналогичное 3D‑форматирование к тексту через [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/textframeformat/threedformat/). Меньшие скосы формируют края букв, а экструдирование и освещение придают тексту глубину:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Полученный текст:

![3D‑эффект текста](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Применение 3D‑эффектов к тексту или к их фигурам — и взаимодействие между этими эффектами — регулируются определёнными правилами. Рассмотрим сцену, включающую как текст, так и содержащую его фигуру. 3D‑эффект включает 3D‑представление объекта и сцену, в которой он размещён.

- Если сцена задана как для фигуры, так и для текста, приоритет отдаётся сцене фигуры, а сцена текста игнорируется.  
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.  
- Если у фигуры полностью отсутствует 3D‑эффект, она рассматривается как плоская, и 3D‑эффект применяется только к тексту.  

Эти поведения связаны со свойствами [ThreeDFormat.LightRig](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/lightrig/) и [ThreeDFormat.Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/camera/).  
{{% /alert %}}

Чтобы сохранить текст плоским и читаемым, одновременно сохраняя 3D‑форматирование его фигуры, см. [Keep Text Flat on a 3D Shape](/slides/ru/net/3d-presentation/) для сравнения обоих настроек и полного примера на C#.

## **Вопросы и ответы**

**Можно ли использовать эффекты WordArt с различными шрифтами или сценариями (например, арабским, китайским)?**

Да, Aspose.Slides for .NET поддерживает Unicode и работает со всеми основными шрифтами и сценариями. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя доступность шрифтов и их рендеринг могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**

Да, эффекты WordArt можно применять к фигурам на мастер‑слайдах, включая заполнители заголовков, колонтитулы или фоновый текст. Изменения, внесённые в макет мастера, отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла из‑за добавленных метаданных форматирования, но разница обычно несущественная.

**Можно ли просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете отрисовать слайды с WordArt в изображения (например, PNG, JPEG), используя [ISlide.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/getimage/), или отрисовать отдельные фигуры через [IShape.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/getimage/). Это позволяет предварительно увидеть результат в памяти или на экране до сохранения или экспорта полной презентации.