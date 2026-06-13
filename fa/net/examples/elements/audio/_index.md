---
title: صدا
type: docs
weight: 70
url: /fa/net/examples/elements/audio/
keywords:
- صدا
- فریم صدا
- افزودن صدا
- دسترسی به صدا
- حذف صدا
- پخش صدا
- مثال کد
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مثال‌های صوتی Aspose.Slides برای .NET را کشف کنید: درج، پخش، برش و استخراج صدا در ارائه‌های PPT، PPTX و ODP با کد واضح C#."
---
این مقاله نشان می‌دهد چگونه فریم‌های صوتی را جاسازی کرده و پخش را با **Aspose.Slides for .NET** کنترل کنید. مثال‌های زیر عملیات پایه‌ای صدای را نشان می‌دهند.

## **افزودن یک فریم صوتی**

یک فریم صوتی خالی را وارد کنید که بعدها می‌تواند داده‌های صوتی جاسازی‌شده را نگه دارد.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // یک فریم صوتی خالی ایجاد کنید (صدا بعداً جاسازی خواهد شد).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **دسترسی به یک فریم صوتی**

این کد اولین فریم صوتی در یک اسلاید را بر می‌گرداند.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // دسترسی به اولین فریم صوتی در اسلاید.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **حذف یک فریم صوتی**

یک فریم صوتی که قبلاً اضافه شده بود را حذف کنید.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // فریم صوتی را حذف کنید.
    slide.Shapes.Remove(audioFrame);
}
```

## **تنظیم پخش صوتی**

فریم صوتی را طوری تنظیم کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // به طور خودکار هنگام نمایش اسلاید پخش شود.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```