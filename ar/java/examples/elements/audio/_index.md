---
title: الصوت
type: docs
weight: 70
url: /ar/java/examples/elements/audio/
keywords:
- مثال على الشيفرة
- صوت
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف أمثلة الصوت في Aspose.Slides لـ Java: إدراج، تشغيل، قص، واستخراج الصوت في عروض PPT و PPTX و ODP مع كود Java واضح."
---
توضح هذه المقالة كيفية تضمين إطارات الصوت والتحكم في تشغيلها باستخدام **Aspose.Slides for Java**. تعرض الأمثلة التالية عمليات الصوت الأساسية.

## **إضافة إطار صوت**

إدراج إطار صوت فارغ يمكن لاحقًا احتواء بيانات الصوت المضمنة.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إنشاء إطار صوت فارغ (سيتم تضمين الصوت لاحقًا).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى إطار صوت**

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

## **إزالة إطار صوت**

احذف إطار الصوت الذي تم إضافته مسبقًا.

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

## **تعيين تشغيل الصوت**

قم بتكوين إطار الصوت للتشغيل تلقائيًا عندما تظهر الشريحة.

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