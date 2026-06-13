---
title: वीडियो
type: docs
weight: 80
url: /hi/net/examples/elements/video/
keywords:
- वीडियो
- वीडियो फ्रेम
- वीडियो जोड़ें
- वीडियो तक पहुँचें
- वीडियो हटाएँ
- वीडियो प्लेबैक
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ वीडियो जोड़ें और नियंत्रित करें: सम्मिलित करें, चलाएँ, ट्रिम करें, पोस्टर फ़्रेम सेट करें, और PPT, PPTX, तथा ODP प्रस्तुतियों के लिए C# उदाहरणों के साथ निर्यात करें।"
---
यह लेख दिखाता है कि **Aspose.Slides for .NET** का उपयोग करके वीडियो फ़्रेम कैसे एम्बेड करें और प्लेबैक विकल्प सेट करें।

## **वीडियो फ़्रेम जोड़ें**

एक स्लाइड पर एक खाली वीडियो फ़्रेम डालें।

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // एक वीडियो जोड़ें।
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **वीडियो फ़्रेम तक पहुँचें**

स्लाइड में जोड़ा गया पहला वीडियो फ़्रेम प्राप्त करें।

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // स्लाइड पर पहला वीडियो फ्रेम एक्सेस करें।
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **वीडियो फ़्रेम हटाएँ**

स्लाइड से एक वीडियो फ़्रेम हटाएँ।

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // वीडियो फ्रेम हटाएँ।
    slide.Shapes.Remove(videoFrame);
}
```

## **वीडियो प्लेबैक सेट करें**

स्लाइड प्रदर्शित होने पर वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```