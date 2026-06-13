---
title: वीडियो
type: docs
weight: 80
url: /hi/cpp/examples/elements/video/
keywords:
- कोड उदाहरण
- वीडियो
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ वीडियो जोड़ें और नियंत्रित करें: सम्मिलित करें, चलाएँ, ट्रिम करें, पोस्टर फ़्रेम सेट करें, और PPT, PPTX, तथा ODP प्रस्तुतियों के लिए C++ उदाहरणों के साथ निर्यात करें।"
---
यह लेख **Aspose.Slides for C++** का उपयोग करके वीडियो फ्रेम एम्बेड करने और प्लेबैक विकल्प सेट करने का प्रदर्शन करता है।

## **वीडियो फ्रेम जोड़ें**

स्लाइड पर एक खाली वीडियो फ्रेम डालें।

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // वीडियो जोड़ें।
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **वीडियो फ्रेम तक पहुँचें**

स्लाइड में जोड़ा गया पहला वीडियो फ्रेम प्राप्त करें।

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // स्लाइड पर पहला वीडियो फ्रेम प्राप्त करें।
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

## **वीडियो फ्रेम हटाएँ**

स्लाइड से एक वीडियो फ्रेम हटाएँ।

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // वीडियो फ्रेम हटाएँ।
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **वीडियो प्लेबैक सेट करें**

स्लाइड प्रदर्शित होने पर वीडियो को स्वचालित रूप से चलाने के लिये कॉन्फ़िगर करें।

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```