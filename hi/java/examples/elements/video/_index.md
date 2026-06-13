---
title: वीडियो
type: docs
weight: 80
url: /hi/java/examples/elements/video/
keywords:
- कोड उदाहरण
- वीडियो
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ वीडियो जोड़ें और नियंत्रित करें: सम्मिलित करें, चलाएँ, ट्रिम करें, पोस्टर फ्रेम सेट करें, और PPT, PPTX, तथा ODP प्रस्तुतियों के लिए Java उदाहरणों के साथ निर्यात करें।"
---
यह लेख **Aspose.Slides for Java** का उपयोग करके वीडियो फ़्रेम एम्बेड करने और प्लेबैक विकल्प सेट करने का प्रदर्शन करता है।

## **वीडियो फ़्रेम जोड़ें**

स्लाइड पर एक खाली वीडियो फ़्रेम डालें।

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // एक वीडियो जोड़ें।
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **वीडियो फ़्रेम तक पहुँचें**

स्लाइड में जोड़ा गया पहला वीडियो फ़्रेम प्राप्त करें।

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // स्लाइड पर पहला वीडियो फ्रेम एक्सेस करें।
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **वीडियो फ़्रेम हटाएँ**

स्लाइड से एक वीडियो फ़्रेम हटाएँ।

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // वीडियो फ्रेम हटाएँ।
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **वीडियो प्लेबैक सेट करें**

स्लाइड प्रदर्शित होने पर वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```