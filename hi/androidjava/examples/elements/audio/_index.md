---
title: ऑडियो
type: docs
weight: 70
url: /hi/androidjava/examples/elements/audio/
keywords:
- कोड उदाहरण
- ऑडियो
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के ऑडियो उदाहरणों की खोज करें: PPT, PPTX, और ODP प्रस्तुतियों में ध्वनि को सम्मिलित करें, चलाएँ, ट्रिम करें और निकालें, स्पष्ट Java कोड के साथ।"
---
यह लेख दिखाता है कि कैसे **Aspose.Slides for Android via Java** के साथ ऑडियो फ्रेम एम्बेड करें और प्लेबैक को नियंत्रित करें। निम्नलिखित उदाहरण बुनियादी ऑडियो संचालन दिखाते हैं।

## **ऑडियो फ्रेम जोड़ें**

एक खाली ऑडियो फ्रेम डालें जिसे बाद में एम्बेडेड ध्वनि डेटा रख सके।

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // एक खाली ऑडियो फ्रेम बनाएं (ऑडियो बाद में एम्बेड किया जाएगा)।
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **ऑडियो फ्रेम तक पहुंचें**

यह कोड स्लाइड पर पहला ऑडियो फ्रेम प्राप्त करता है।

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // स्लाइड पर पहला ऑडियो फ्रेम एक्सेस करें।
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ऑडियो फ्रेम हटाएँ**

पहले जोड़े गए ऑडियो फ्रेम को हटाएँ।

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // ऑडियो फ्रेम हटाएँ।
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **ऑडियो प्लेबैक सेट करें**

स्लाइड दिखने पर ऑडियो फ्रेम को स्वतः चलाने के लिए कॉन्फ़िगर करें।

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // स्लाइड के प्रकट होने पर स्वतः चलाएँ।
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```