---
title: Создание и применение эффектов WordArt в C#
linktitle: WordArt
type: docs
weight: 110
url: /ru/net/wordart/
keywords:
- WordArt
- создание WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отображения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Узнайте, как создавать и настраивать эффекты WordArt в Aspose.Slides для .NET. Это пошаговое руководство помогает разработчикам улучшать презентации стильным, профессиональным текстом на C#."
---

## **Обзор**

Эффекты WordArt позволяют добавлять визуально привлекательный стилизованный текст в презентации PowerPoint. С помощью Aspose.Slides для .NET разработчики могут программно создавать, настраивать и управлять WordArt так же, как в Microsoft PowerPoint — без необходимости установки Office. Эта статья даёт обзор работы с WordArt в .NET, включая применение текстовых трансформаций, стилей заливки, контуров, теней и других параметров форматирования, чтобы сделать содержание презентации более выразительным и захватывающим. WordArt позволяет рассматривать текст как графический объект. Он состоит из эффектов или специальных модификаций, применяемых к тексту, чтобы сделать его более привлекательным или заметным.

## **Создать простой шаблон WordArt и применить его к тексту**

В этом разделе мы рассмотрим, как создать простой шаблон WordArt и применить его к тексту с помощью Aspose.Slides для .NET. WordArt предоставляет простой способ улучшить внешний вид текста с помощью выразительных визуальных эффектов и стилей. Освоив базовые шаги создания и использования WordArt, вы сможете легко адаптировать эти методы к любому проекту, делая свои презентации более яркими и запоминающимися.

Сначала мы создаём простой текст, используя следующий код C#:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```


Затем мы задаём высоту шрифта текста большим значением, чтобы эффект был более заметным, используя следующий код:
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


Здесь мы применяем заливку шаблоном SmallGrid к тексту и добавляем чёрный контур текста шириной 1, используя следующий код:
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


Получившийся текст:

![Простой шаблон WordArt](WordArt_template.png)

## **Применить другие эффекты WordArt**

В дополнение к базовым трансформациям Aspose.Slides для .NET позволяет применять разнообразные расширенные эффекты WordArt, чтобы улучшить внешний вид вашего текста. К ним относятся контуры, заливки, тени, отражения и свечения. Комбинируя эти возможности, вы можете создавать привлекающие внимание стили текста, которые выделяются в ваших презентациях. В этом разделе демонстрируется, как программно применять эти эффекты с помощью простых и чистых примеров кода.

### **Применить внешние теневые эффекты**

Эффекты внешней тени помогают тексту выделяться, добавляя тень за его контуром, создавая ощущение глубины и отделения от фона. Aspose.Slides для .NET позволяет легко применять и настраивать внешние тени для текста WordArt. В этом разделе вы узнаете, как задавать цвет тени, направление, расстояние, радиус размытия и другие параметры для достижения желаемого визуального эффекта.

Следующий фрагмент кода C# применяет эффект тени к ранее созданному тексту.
```cs
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


Получившийся текст:

![Эффект внешней тени](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- Если одновременно используются OuterShadow и PresetShadow, применяется только эффект OuterShadow.
- Если одновременно используются OuterShadow и InnerShadow, результирующий эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только эффект OuterShadow.
{{% /alert %}}

### **Применить эффекты отражения**

В этом разделе мы рассмотрим, как применять эффекты отражения в слайдах с помощью Aspose.Slides для .NET. Эффекты отражения могут стать эффективным способом придать вашему тексту или фигурам стильный и современный вид, помогая ключевым элементам выделяться и добавляя глубину презентации. Понимая процесс применения и настройки этих эффектов, вы сможете легко адаптировать их под потребности дизайна и требования брендинга.

Добавьте эффект отражения к тексту, используя следующий пример кода C#:
```cs
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


Получившийся текст:

![Эффект отражения](reflection_effect.png)

### **Применить эффекты свечения**

В этом разделе мы рассмотрим, как применить эффект свечения к тексту с помощью Aspose.Slides для .NET. Эффект свечения может сделать ваш текст более заметным благодаря светящемуся контуру, улучшая визуальную привлекательность слайдов. Настраивая такие параметры, как цвет и интенсивность, вы сможете легко адаптировать свечение под дизайн и требования бренда, гарантируя, что ключевые моменты вашей презентации привлекут внимание аудитории.

Примените эффект свечения к тексту, чтобы он светился или выделялся, используя следующий код:
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


Получившийся текст:

![Эффект свечения](glow_effect.png)

### **Применить трансформации WordArt**

В этом разделе мы рассмотрим, как использовать трансформации в WordArt с помощью Aspose.Slides для .NET. Трансформации позволяют изгибать, растягивать или искажать текст, создавая уникальные и визуально впечатляющие эффекты. Овладев этими техниками, вы сможете легко адаптировать формы и стили текста под ваш бренд или креативное видение, обеспечивая убедительную и отполированную презентацию.

Используйте свойство `Transform` (которое применяется ко всему блоку текста), используя следующий код:
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


Получившийся текст:

![Трансформация WordArt](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides для .NET предоставляет набор предопределённых [типов трансформаций](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **Применить 3D-эффекты к фигурам и тексту**

Создание реалистичных, притягательных визуальных элементов может значительно усилить воздействие ваших презентаций. В этом разделе мы рассмотрим, как применять трёхмерные (3D) эффекты к фигурам с помощью Aspose.Slides для .NET. Манипулируя параметрами, такими как глубина, угол и освещение, вы можете создавать впечатляющие 3D‑трансформации, которые сразу же привлекут внимание аудитории. Независимо от того, стремитесь ли вы к тонким акцентам или драматическим иллюзиям, эти возможности предоставляют гибкие способы улучшить дизайн и передать идеи более увлекательно.

Используйте следующий пример кода, чтобы задать 3D‑эффект фигуре:
```cs
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


Получившаяся фигура:

![3D‑эффект фигуры](shape_3D_effect.png)

Используйте следующий пример кода, чтобы задать 3D‑эффект тексту:
```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```


Получившийся текст:

![3D‑эффект текста](text_3D_effect.png)

{{% alert color="primary" %}} 
Применение 3D‑эффектов к тексту или их фигурам — а также взаимодействие между этими эффектами — регулируется определёнными правилами. Рассмотрим сцену, включающую как текст, так и фигуру, содержащую этот текст. 3D‑эффект включает 3D‑представление объекта и сцену, на которой он размещён.

- Если сцена задана одновременно для фигуры и текста, приоритет имеет сцена фигуры, а сцена текста игнорируется.
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.
- Если у фигуры вообще нет 3D‑эффекта, она считается плоской, и 3D‑эффект применяется только к тексту.

Эти поведения относятся к свойствам [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) и [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **FAQ**

**Могу ли я использовать эффекты WordArt с различными шрифтами или сценариями (например, арабский, китайский)?**

Да, Aspose.Slides для .NET поддерживает Unicode и работает со всеми основными шрифтами и сценариями. Эффекты WordArt, такие как тень, заливка и контур, можно применять независимо от языка, хотя доступность шрифтов и их отображение могут зависеть от системных шрифтов.

**Могу ли я применять эффекты WordArt к элементам шаблона слайда?**

Да, вы можете применять эффекты WordArt к объектам на шаблонах слайдов, включая заполнители заголовков, нижние колонтитулы или фоновой текст. Изменения, внесённые в макет шаблона, отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Слегка. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла из‑за добавленных метаданных форматирования, но разница обычно незначительна.

**Могу ли я предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете отрисовывать слайды с WordArt в изображения (например, PNG, JPEG), используя метод `GetImage` из интерфейсов [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) или [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/). Это позволяет предварительно просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.