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
- эффект отображения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- .NET
- C#
- Aspose.Slides
description: "Создайте и настройте эффекты WordArt в Aspose.Slides для .NET. Это пошаговое руководство поможет разработчикам улучшить презентации профессиональным текстом на C#."
---

## **Обзор**

Эффекты WordArt позволяют добавлять визуально привлекательный, стилизованный текст в ваши презентации PowerPoint. С помощью Aspose.Slides for .NET разработчики могут программно создавать, настраивать и управлять WordArt так же, как в Microsoft PowerPoint — без необходимости установки Office. Эта статья предоставляет обзор работы с WordArt в .NET, включая применение трансформаций текста, стилей заливки, контуров, теней и других параметров форматирования, чтобы сделать содержание презентации более выразительным и увлекательным. WordArt позволяет рассматривать текст как графический объект. Он состоит из эффектов или специальных модификаций, применяемых к тексту, чтобы сделать его более привлекательным или заметным.

## **Создание простого шаблона WordArt и применение его к тексту**

В этом разделе мы рассмотрим, как создать простой шаблон WordArt и применить его к тексту с помощью Aspose.Slides for .NET. WordArt предлагает простой способ улучшить внешний вид текста с помощью ярких визуальных эффектов и стилей. Изучив основные шаги создания и использования WordArt, вы сможете быстро адаптировать эти техники к любому проекту, делая презентации более живыми и запоминающимися.

First, we create simple text using the following C# code:
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


Now, we set the text’s font height to a larger value to make the effect more noticeable using the following code:
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


Here, we apply the SmallGrid pattern fill to the text and add a black text border with a width of 1 using the following code:
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


Полученный текст:

![Простой шаблон WordArt](WordArt_template.png)

## **Применение других эффектов WordArt**

Помимо базовых трансформаций, Aspose.Slides for .NET позволяет применять разнообразные продвинутые эффекты WordArt для улучшения внешнего вида вашего текста. Это включает контуры, заливки, тени, отражения и свечения. Комбинируя эти возможности, вы можете создавать привлекающие внимание стили текста, которые выделяются в ваших презентациях. В этом разделе демонстрируется программное применение этих эффектов с помощью простых, лаконичных примеров кода.

### **Применение внешних теней**

Эффекты внешних теней помогают тексту выделяться, добавляя тень за контуром, создавая ощущение глубины и отделения от фона. Aspose.Slides for .NET позволяет легко применять и настраивать внешние тени на тексте WordArt. В этом разделе вы узнаете, как задать цвет тени, направление, расстояние, радиус размытия и другие параметры для достижения желаемого визуального эффекта.

The following C# code snippet applies a shadow effect to the text created above.
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


Полученный текст:

![Эффект внешней тени](outer_shadow_effect.png)

{{% alert color="primary" %}} 

- Когда одновременно используются OuterShadow и PresetShadow, применяется только эффект OuterShadow.
- Если одновременно используются OuterShadow и InnerShadow, итоговый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только эффект OuterShadow.

{{% /alert %}}

### **Применение эффектов отражения**

В этом разделе мы рассмотрим, как применять эффекты отражения в ваших слайдах с помощью Aspose.Slides for .NET. Эффекты отражения могут эффективно придать вашему тексту или фигурам стильный и современный вид, помогая ключевым элементам выделяться и добавляя глубину презентации. Понимая процесс применения и настройки этих эффектов, вы сможете легко адаптировать их под дизайн и требования бренда.

Add a reflection effect to the text using this C# code example:
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


Полученный текст:

![Эффект отражения](reflection_effect.png)

### **Применение эффектов свечения**

В этом разделе мы рассмотрим, как применить эффект свечения к тексту с помощью Aspose.Slides for .NET. Эффект свечения может сделать ваш текст более заметным за счёт светящегося контура, повышая визуальную привлекательность слайдов. Регулируя такие параметры, как цвет и интенсивность, вы сможете легко настроить свечение под дизайн и требования бренда, обеспечивая привлечение внимания к ключевым моментам вашей презентации.

Apply a glow effect to the text to make it shine or stand out using the following code:
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


Полученный текст:

![Эффект свечения](glow_effect.png)

### **Применение трансформаций WordArt**

В этом разделе мы рассмотрим, как использовать трансформации в WordArt с помощью Aspose.Slides for .NET. Трансформации позволяют изгибать, растягивать или искажать текст, создавая уникальные и визуально впечатляющие эффекты. Овладев этими техниками, вы сможете легко адаптировать формы и стили текста под ваш бренд или креативное видение, обеспечивая убедительную и профессиональную презентацию.

Use the `Transform` property (which applies to the entire block of text) using the following code:
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


Полученный текст:

![Трансформация WordArt](transform_effect.png)

{{% alert color="primary" %}} 

Aspose.Slides for .NET provides a set of predefined [типы трансформаций](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/).

{{% /alert %}} 

### **Применение 3D‑эффектов к фигурам и тексту**

Создание реалистичных, привлекающих внимание визуальных эффектов может существенно повысить влияние ваших презентаций. В этом разделе мы исследуем, как применять трёхмерные (3D) эффекты к фигурам с помощью Aspose.Slides for .NET. Манипулируя параметрами, такими как глубина, угол и освещение, вы можете создавать впечатляющие 3D‑трансформации, которые сразу же привлекают внимание аудитории. Независимо от того, стремитесь ли вы к тонким акцентам или драматическим иллюзиям, эти возможности предлагают гибкие способы улучшить дизайн и передать идеи более захватывающим образом.

Use the following sample code to set a 3D effect to the shape:
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


Полученная фигура:

![3D‑эффект фигуры](shape_3D_effect.png)

Use the following sample code to set a 3D effect to the text:
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


Полученный текст:

![3D‑эффект текста](text_3D_effect.png)

{{% alert color="primary" %}} 

Применение 3D‑эффектов к тексту или их фигурам — а также взаимодействие между этими эффектами — регулируется определёнными правилами. Рассмотрим сцену, включающую и текст, и форму, содержащую этот текст. 3D‑эффект включает 3D‑представление объекта и сцену, на которой он размещён.

- Если сцена задаётся как для формы, так и для текста, приоритет имеет сцена формы, а сцена текста игнорируется.
- Если у формы нет собственной сцены, но есть 3D‑представление, используется сцена текста.
- Если у формы полностью отсутствует 3D‑эффект, она рассматривается как плоская, и 3D‑эффект применяется только к тексту.

Эти поведения относятся к свойствам [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) и [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/).

{{% /alert %}} 

## **Часто задаваемые вопросы**

**Могу ли я использовать эффекты WordArt с различными шрифтами или скриптами (например, арабским, китайским)?**

Да, Aspose.Slides for .NET поддерживает Unicode и работает со всеми основными шрифтами и сценариями. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя доступность шрифтов и их отображение могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайда?**

Да, вы можете применять эффекты WordArt к объектам на мастер‑слайдах, включая заполнитель заголовка, нижний колонтитул или фоновый текст. Изменения, внесённые в мастер‑разметку, будут отражены во всех соответствующих слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут слегка увеличить размер файла из‑за добавления метаданных форматирования, но разница обычно незначительна.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете визуализировать слайды с WordArt в изображения (например, PNG, JPEG) с помощью метода `GetImage` из интерфейсов [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) или [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/). Это позволяет предварительно просмотреть результат в памяти или на экране перед сохранением или экспортом полной презентации.