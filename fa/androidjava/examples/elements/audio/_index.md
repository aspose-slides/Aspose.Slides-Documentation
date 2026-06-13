---
title: صدا
type: docs
weight: 70
url: /fa/androidjava/examples/elements/audio/
keywords:
- مثال کد
- صوت
- پاورپوینت
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "نمونه‌های صوتی Aspose.Slides برای Android را کشف کنید: وارد کردن، پخش، برش و استخراج صدا در ارائه‌های PPT، PPTX و ODP با کد واضح Java."
---
این مقاله نشان می‌دهد که چگونه قاب‌های صوتی را جاسازی کنید و پخش را کنترل کنید با **Aspose.Slides for Android via Java**. مثال‌های زیر عملیات پایه صوتی را نشان می‌دهند.

## **Add an Audio Frame**
یک قاب صوتی خالی را وارد کنید که بعداً می‌تواند داده‌های صوتی جاسازی‌شده را در خود نگه دارد.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک قاب صوتی خالی ایجاد کنید (صدا بعداً جاسازی خواهد شد).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Access an Audio Frame**
این کد اولین قاب صوتی موجود در یک اسلاید را بازیابی می‌کند.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // دسترسی به اولین قاب صوتی در اسلاید.
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
قاب صوتی که قبلاً اضافه شده بود را حذف کنید.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // حذف قاب صوتی.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Audio Playback**
قاب صوتی را طوری تنظیم کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // به طور خودکار هنگام ظاهر شدن اسلاید پخش شود.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```