---
title: الصوت
type: docs
weight: 70
url: /ar/net/examples/elements/audio/
keywords:
- مثال صوت
- إطار صوت
- إضافة صوت
- الوصول إلى صوت
- إزالة صوت
- تشغيل صوت
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع الصوت في C# باستخدام Aspose.Slides: إضافة، استبدال، استخراج، وتقليم الأصوات، ضبط مستوى الصوت والتشغيل للشرائح والأشكال في PowerPoint وOpenDocument."
---

يوضح كيفية تضمين إطارات الصوت والتحكم في التشغيل باستخدام **Aspose.Slides for .NET**. تُظهر الأمثلة التالية عمليات الصوت الأساسية.

## إضافة إطار صوتي

إدراج إطار صوتي فارغ يمكنه لاحقًا احتواء بيانات الصوت المضمنة.
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // إنشاء إطار صوتي فارغ (سيتم تضمين الصوت لاحقًا)
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## الوصول إلى إطار صوتي

يقوم هذا الكود باسترجاع أول إطار صوتي في الشريحة.
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // الوصول إلى أول إطار صوت على الشريحة
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## إزالة إطار صوتي

حذف إطار صوتي تم إضافته مسبقًا.
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // إزالة إطار الصوت
    slide.Shapes.Remove(audioFrame);
}
```


## ضبط تشغيل الصوت

قم بتكوين إطار الصوت للتشغيل تلقائيًا عند ظهور الشريحة.
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // تشغيل تلقائي عند ظهور الشريحة
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
