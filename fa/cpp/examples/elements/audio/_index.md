---
title: صدا
type: docs
weight: 70
url: /fa/cpp/examples/elements/audio/
keywords:
- مثال کد
- صدا
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "مثال‌های صوتی Aspose.Slides برای C++ را کشف کنید: درج، پخش، برش و استخراج صدا در ارائه‌های PPT، PPTX و ODP با کد واضح C++."
---
این مقاله نشان می‌دهد چگونه قاب‌های صوتی را جاسازی کنید و پخش را با **Aspose.Slides for C++** کنترل کنید. مثال‌های زیر عملیات‌های پایه‌ای صوتی را نشان می‌دهند.

## **افزودن یک قاب صوتی**

یک قاب صوتی خالی وارد کنید که بعداً می‌تواند داده‌های صوتی جاسازی‌شده را در خود نگه دارد.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک قاب صوتی خالی ایجاد کنید (صدا بعداً جاسازی خواهد شد).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **دسترسی به یک قاب صوتی**

این کد اولین قاب صوتی موجود در یک اسلاید را بازیابی می‌کند.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // دسترسی به اولین قاب صوتی در اسلاید.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **حذف یک قاب صوتی**

قاب صوتی اضافه شده پیشین را حذف کنید.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // حذف قاب صوتی.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **تنظیم پخش صوتی**

قاب صوتی را تنظیم کنید تا هنگام نمایش اسلاید به‌صورت خودکار پخش شود.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // به صورت خودکار هنگام نمایش اسلاید پخش شود.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```