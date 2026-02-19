---
title: الصوت
type: docs
weight: 70
url: /ar/cpp/examples/elements/audio/
keywords:
- مثال على الكود
- صوت
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف أمثلة الصوت في Aspose.Slides for C++: إدراج، تشغيل، قص، واستخراج الصوت في عروض PPT و PPTX و ODP مع كود C++ واضح."
---
توضح هذه المقالة كيفية تضمين إطارات صوتية والتحكم في تشغيلها باستخدام **Aspose.Slides for C++**. توضح الأمثلة التالية عمليات الصوت الأساسية.

## **إضافة إطار صوتي**

أدرج إطار صوتي فارغ يمكنه لاحقًا احتواء بيانات صوت مدمجة.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // إنشاء إطار صوتي فارغ (سيتم تضمين الصوت لاحقًا).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **الوصول إلى إطار صوتي**

يقوم هذا الرمز باسترجاع أول إطار صوتي في الشريحة.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // الوصول إلى أول إطار صوتي في الشريحة.
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

## **إزالة إطار صوتي**

احذف إطار صوتي تم إضافته مسبقًا.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // إزالة إطار الصوت.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **ضبط تشغيل الصوت**

قم بتهيئة إطار الصوت ليتم تشغيله تلقائيًا عند ظهور الشريحة.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // تشغيل تلقائي عندما تظهر الشريحة.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```