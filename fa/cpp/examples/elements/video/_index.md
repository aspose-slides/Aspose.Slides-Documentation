---
title: ویدئو
type: docs
weight: 80
url: /fa/cpp/examples/elements/video/
keywords:
- مثال کد
- ویدئو
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ویدئوها را با Aspose.Slides برای C++ اضافه و کنترل کنید: درج، پخش، برش، تعیین قاب‌های پوستر، و خروجی با مثال‌های C++ برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه قاب‌های ویدئویی را جاسازی کرده و گزینه‌های پخش را با استفاده از **Aspose.Slides for C++** تنظیم کنید.

## **افزودن یک قاب ویدئویی**
یک قاب ویدئویی خالی را روی یک اسلاید درج کنید.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک ویدئو اضافه کنید.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **دستیابی به یک قاب ویدئویی**
اولین قاب ویدئویی که به اسلاید اضافه شده را بازیابی کنید.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // دسترسی به اولین قاب ویدئویی در اسلاید.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **حذف یک قاب ویدئویی**
یک قاب ویدئویی را از اسلاید حذف کنید.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // قاب ویدئویی را حذف کنید.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **تنظیم پخش ویدئو**
ویدئو را به‌طوری پیکربندی کنید که هنگام نمایش اسلاید به‌صورت خودکار پخش شود.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // ویدئو را برای پخش خودکار پیکربندی کنید.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```