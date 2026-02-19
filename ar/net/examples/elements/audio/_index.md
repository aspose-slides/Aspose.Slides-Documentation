---
title: الصوت
type: docs
weight: 70
url: /ar/net/examples/elements/audio/
keywords:
- صوت
- إطار صوت
- إضافة صوت
- الوصول إلى الصوت
- إزالة صوت
- تشغيل الصوت
- مثال على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف أمثلة الصوت في Aspose.Slides for .NET: إدراج، تشغيل، قص، واستخراج الصوت في عروض PPT و PPTX و ODP مع شفرة C# واضحة."
---
تُظهر هذه المقالة كيفية تضمين إطارات الصوت والتحكم في تشغيلها باستخدام **Aspose.Slides for .NET**. تُظهر الأمثلة التالية عمليات الصوت الأساسية.

## **إضافة إطار صوت**

أدرج إطار صوت فارغ يمكن لاحقًا أن يحمل بيانات صوتية مدمجة.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // إنشاء إطار صوت فارغ (سيتم تضمين الصوت لاحقًا).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **الوصول إلى إطار صوت**

يقوم هذا الكود باسترجاع أول إطار صوت على الشريحة.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // الوصول إلى أول إطار صوت على الشريحة.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **إزالة إطار صوت**

احذف إطار الصوت الذي تم إضافته مسبقًا.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // إزالة إطار الصوت.
    slide.Shapes.Remove(audioFrame);
}
```

## **ضبط تشغيل الصوت**

قم بتهيئة إطار الصوت ليُشغَل تلقائيًا عند ظهور الشريحة.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // تشغيل تلقائي عند ظهور الشريحة.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```