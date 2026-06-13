---
title: صوت
type: docs
weight: 70
url: /fa/java/examples/elements/audio/
keywords:
- مثال کد
- صوت
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مثال‌های صوتی Aspose.Slides برای Java را کشف کنید: درج، پخش، برش و استخراج صدا در ارائه‌های PPT، PPTX و ODP با کد واضح Java."
---
این مقاله نحوه جاسازی فریم‌های صوتی و کنترل پخش را با **Aspose.Slides for Java** نشان می‌دهد. مثال‌های زیر عملیات پایه‌ای صوتی را نمایش می‌دهند.

## **افزودن فریم صوتی**

یک فریم صوتی خالی را وارد کنید که بعداً می‌تواند داده‌های صوتی جاسازی‌شده را نگه دارد.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک فریم صوتی خالی ایجاد کنید (صدا بعداً جاسازی خواهد شد).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به فریم صوتی**

این کد اولین فریم صوتی روی یک اسلاید را بازیابی می‌کند.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // دسترسی به اولین فریم صوتی روی اسلاید.
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

## **حذف فریم صوتی**

فریم صوتی که قبلاً اضافه شده بود را حذف کنید.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // فریم صوتی را حذف کنید.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم پخش صوتی**

فریم صوتی را طوری تنظیم کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // به طور خودکار هنگام ظاهر شدن اسلاید پخش می‌شود.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```