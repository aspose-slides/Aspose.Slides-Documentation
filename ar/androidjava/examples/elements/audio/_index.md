---
title: الصوت
type: docs
weight: 70
url: /ar/androidjava/examples/elements/audio/
keywords:
- مثال على الكود
- صوت
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف أمثلة الصوت في Aspose.Slides for Android: إدراج، تشغيل، تقليم، واستخلاص الصوت في عروض PPT، PPTX، و ODP مع كود Java واضح."
---
تُظهر هذه المقالة كيفية تضمين إطارات الصوت والتحكم في تشغيلها باستخدام **Aspose.Slides for Android via Java**. تُظهر الأمثلة التالية عمليات الصوت الأساسية.

## **Add an Audio Frame**
إدراج إطار صوت فارغ يمكنه لاحقًا احتواء بيانات صوت مدمجة.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إنشاء إطار صوت فارغ (سيتم دمج الصوت لاحقًا).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Access an Audio Frame**
يقوم هذا الكود باسترجاع أول إطار صوت في الشريحة.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // الوصول إلى أول إطار صوت في الشريحة.
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

## **Remove an Audio Frame**
حذف إطار صوت تم إضافته مسبقًا.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // إزالة إطار الصوت.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Audio Playback**
تكوين إطار الصوت للتشغيل تلقائيًا عندما تظهر الشريحة.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // تشغيل تلقائيًا عندما تظهر الشريحة.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```