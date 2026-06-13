---
title: ऑडियो
type: docs
weight: 70
url: /hi/java/examples/elements/audio/
keywords:
- कोड उदाहरण
- ऑडियो
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के ऑडियो उदाहरण खोजें: PPT, PPTX और ODP प्रस्तुतियों में ध्वनि को सम्मिलित, चलाएं, ट्रिम करें और निकालें, स्पष्ट Java कोड के साथ।"
---
यह लेख दिखाता है कि **Aspose.Slides for Java** के साथ ऑडियो फ्रेम को एम्बेड करें और प्लेबैक को नियंत्रित करें। निम्नलिखित उदाहरण बुनियादी ऑडियो संचालन दर्शाते हैं।

## **ऑडियो फ्रेम जोड़ें**

बाद में एम्बेडेड साउंड डेटा रखने के लिए एक खाली ऑडियो फ्रेम सम्मिलित करें।

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

## **ऑडियो फ्रेम तक पहुँचें**

यह कोड स्लाइड पर पहला ऑडियो फ्रेम प्राप्त करता है।

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // स्लाइड पर पहला ऑडियो फ्रेम प्राप्त करें।
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

        // ऑडियो फ्रेम हटाएं।
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **ऑडियो प्लेबैक सेट करें**

स्लाइड के प्रदर्शित होने पर ऑडियो फ्रेम को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // स्लाइड के प्रदर्शित होने पर स्वचालित रूप से चलें।
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```