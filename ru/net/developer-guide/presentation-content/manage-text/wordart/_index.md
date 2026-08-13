---
title: Создать и применить эффекты WordArt в .NET
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
- преобразование WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- .NET
- C#
- Aspose.Slides
description: "Создайте и настройте эффекты WordArt в Aspose.Slides for .NET. Этот пошаговый гид поможет разработчикам улучшить презентации профессиональным текстом на C#."
---
## **Обзор**

Эффекты WordArt позволяют добавлять визуально привлекательный стилизованный текст в презентации PowerPoint. С помощью Aspose.Slides for .NET разработчики могут программно создавать, настраивать и управлять WordArt так же, как в Microsoft PowerPoint — без необходимости установки Office. Эта статья предоставляет обзор работы с WordArt в .NET, включая применение текстовых преобразований, стилей заполнения, контуров, теней и других параметров форматирования, чтобы сделать содержимое вашей презентации более выразительным и увлекательным. WordArt позволяет рассматривать текст как графический объект. Он состоит из эффектов или специальных модификаций, применяемых к тексту, чтобы сделать его более привлекательным или заметным.

## **Создать простой шаблон WordArt и применить его к тексту**

В этом разделе мы рассмотрим, как создать простой шаблон WordArt и применить его к тексту с помощью Aspose.Slides for .NET. WordArt предоставляет простой способ улучшить внешний вид текста с помощью ярких визуальных эффектов и стилей. Освоив базовые шаги создания и использования WordArt, вы сможете легко адаптировать эти приёмы к любому проекту, делая презентации более живыми и запоминающимися.

Сначала мы создаём простой текст, используя следующий код C#:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Теперь мы задаём высоту шрифта текста большим значением, чтобы эффект был более заметным, используя следующий код:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

Здесь мы применяем заполнение шаблоном SmallGrid к тексту и добавляем чёрный контур текста шириной 1, используя следующий код:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

Получившийся текст:

![Простой шаблон WordArt](WordArt_template.png)

## **Применить другие эффекты WordArt**

Помимо базовых преобразований, Aspose.Slides for .NET позволяет применять разнообразные продвинутые эффекты WordArt для улучшения внешнего вида вашего текста. Это включает контуры, заливки, тени, отражения и свечения. Комбинируя эти возможности, вы можете создавать привлекающие внимание стили текста, которые выделяются в ваших презентациях. В этом разделе показано, как программно применять эти эффекты с помощью простых и чистых примеров кода.

### **Применить эффекты внешней тени**

Эффекты внешней тени помогают тексту выделяться, добавляя тень за его контуром, создавая ощущение глубины и отделения от фона. Aspose.Slides for .NET позволяет легко применять и настраивать внешние тени у текста WordArt. В этом разделе вы узнаете, как задать цвет тени, направление, расстояние, радиус размытия и другие параметры для достижения желаемого визуального воздействия.

Следующий фрагмент кода C# применяет эффект тени к тексту, созданному выше.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

Получившийся текст:

![Эффект внешней тени](outer_shadow_effect.png)

{{% alert color="info" %}} 
- При одновременном использовании OuterShadow и PresetShadow применяется только эффект OuterShadow.
- Если одновременно использовать OuterShadow и InnerShadow, получаемый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только эффект OuterShadow.
{{% /alert %}}

### **Применить эффекты отражения**

В этом разделе мы рассмотрим, как применять эффекты отражения в слайдах с помощью Aspose.Slides for .NET. Эффекты отражения могут эффективно придать вашему тексту или фигурам стильный и современный вид, помогая ключевым элементам выделяться и добавляя глубину вашей презентации. Понимая процесс применения и настройки этих эффектов, вы сможете легко адаптировать их под свои дизайнерские нужды и требования бренда.

Добавьте эффект отражения к тексту, используя следующий пример кода C#:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

Получившийся текст:

![Эффект отражения](reflection_effect.png)

### **Применить эффекты свечения**

В этом разделе мы рассмотрим, как применить эффект свечения к тексту с помощью Aspose.Slides for .NET. Эффект свечения может сделать ваш текст более заметным за счёт светящегося контура, улучшая визуальную привлекательность слайдов. Регулируя такие параметры, как цвет и интенсивность, вы сможете легко настроить свечение под дизайн и требования бренда, гарантируя, что ключевые пункты вашей презентации привлекут внимание аудитории.

Примените эффект свечения к тексту, чтобы он сиял или выделялся, используя следующий код:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

Получившийся текст:

![Эффект свечения](glow_effect.png)

### **Применить трансформации WordArt**

В этом разделе мы рассмотрим, как использовать преобразования в WordArt с помощью Aspose.Slides for .NET. Преобразования позволяют изгибать, растягивать или искажать текст, создавая уникальные и визуально впечатляющие эффекты. Овладев этими приёмами, вы сможете легко адаптировать формы и стили текста под ваш бренд или креативное видение, обеспечивая убедительную и полированную презентацию.

Используйте свойство `Transform` (которое применяется ко всему блоку текста) с помощью следующего кода:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

Получившийся текст:

![Трансформация WordArt](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET предоставляет набор предопределённых [типы преобразования](https://reference.aspose.com/slides/ru/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **Применить 3D-эффекты к фигурам и тексту**

Создание реалистичных, привлекающих внимание визуальных элементов может значительно повысить воздействие ваших презентаций. В этом разделе мы изучим, как применять трёхмерные (3D) эффекты к фигурам с помощью Aspose.Slides for .NET. Путём манипулирования параметрами глубины, угла и освещения вы сможете создавать впечатляющие 3D‑преобразования, которые мгновенно привлекут внимание аудитории. Будь то тонкие подсветки или драматические иллюзии, эти функции предлагают гибкие способы улучшить ваш дизайн и передать идеи более захватывающим образом.

Используйте следующий пример кода, чтобы задать 3D‑эффект фигуре:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
}
```

Получившаяся фигура:

![3D-эффект фигуры](shape_3D_effect.png)

Используйте следующий пример кода, чтобы задать 3D‑эффект тексту:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
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
}
```

Получившийся текст:

![3D-эффект текста](text_3D_effect.png)

{{% alert color="info" %}} 
Применение 3D‑эффектов к тексту или их фигурам — и взаимодействие между этими эффектами — регулируется определёнными правилами. Рассмотрим сцену, включающую как текст, так и фигуру, содержащую этот текст. 3D‑эффект включает 3D‑представление объекта и сцену, на которой он размещён.

- Если сцена задана как для фигуры, так и для текста, приоритет получает сцена фигуры, а сцена текста игнорируется.
- Если у фигуры нет своей сцены, но есть 3D‑представление, используется сцена текста.
- Если у фигуры нет 3D‑эффекта вообще, она рассматривается как плоская, и 3D‑эффект применяется только к тексту.

Эти поведения относятся к [ThreeDFormat.LightRig](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/lightrig/) и [ThreeDFormat.Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/camera/) свойствам.
{{% /alert %}} 

## **Часто задаваемые вопросы**

### Можно ли использовать эффекты WordArt с разными шрифтами или системами письма (например, арабским, китайским)?

Да, Aspose.Slides for .NET поддерживает Unicode и работает со всеми основными шрифтами и системами письма. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя доступность шрифтов и их рендеринг могут зависеть от системных шрифтов.

### Можно ли применять эффекты WordArt к элементам шаблона слайдов?

Да, вы можете применять эффекты WordArt к фигурам на мастер‑слайдах, включая заполнители заголовков, колонтитулы или фоновой текст. Изменения, внесённые в макет мастера, отразятся на всех связанных слайдах.

### Влияют ли эффекты WordArt на размер файла презентации?

Слегка. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла из‑за добавления метаданных форматирования, но разница обычно незначительна.

### Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?

Да, вы можете отрисовать слайды с WordArt в изображения (например, PNG, JPEG), используя метод `GetImage` из интерфейсов [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/) или [ISlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/). Это позволяет предварительно просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.