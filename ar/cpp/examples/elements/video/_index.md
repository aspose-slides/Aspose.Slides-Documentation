---
title: فيديو
type: docs
weight: 80
url: /ar/cpp/examples/elements/video/
keywords:
- مثال شفرة
- فيديو
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- C++
- Aspose.Slides
description: "إضافة والتحكم في مقاطع الفيديو باستخدام Aspose.Slides for C++: إدراج، تشغيل، قص، تعيين إطارات الملصق، وتصدير مع أمثلة C++ لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية إدراج إطارات الفيديو وتعيين خيارات التشغيل باستخدام **Aspose.Slides for C++**.

## **إضافة إطار فيديو**

أدرج إطار فيديو فارغ على الشريحة.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // إضافة فيديو.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **الوصول إلى إطار فيديو**

استرجع أول إطار فيديو تم إضافته إلى الشريحة.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // الوصول إلى أول إطار فيديو في الشريحة.
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

## **إزالة إطار فيديو**

احذف إطار فيديو من الشريحة.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // إزالة إطار الفيديو.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **تعيين تشغيل الفيديو**

قم بتكوين الفيديو لتشغيله تلقائيًا عند عرض الشريحة.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // تكوين الفيديو لتشغيله تلقائيًا.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```