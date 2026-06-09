---
title: Slayt Geçişi
type: docs
weight: 110
url: /tr/java/examples/elements/slide-transition/
keywords:
- kod örneği
- slayt geçişi
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da slayt geçişlerini yönetin: PPT, PPTX ve ODP sunumları için Java örnekleriyle efektleri ve süreleri ekleyin, özelleştirin ve sıralayın."
---
Bu makale, **Aspose.Slides for Java** ile slayt geçiş efektlerini ve zamanlamalarını uygulamayı göstermektedir.

## **Slayt Geçişi Ekle**

İlk slayta bir solma geçiş efekti uygulayın.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Bir solma geçişi uygula.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Slayt Geçişine Erişim**

Bir slayta şu anda atanmış geçiş tipini okuyun.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Geçiş tipine eriş.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Slayt Geçişini Kaldır**

`None` tipine ayarlayarak tüm geçiş efektini temizleyin.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Geçişi kaldırmak için none ayarlayın.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Geçiş Süresini Ayarla**

Slaytın otomatik olarak ilerlemeden önce ne kadar süre gösterileceğini belirtin.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // milisaniye cinsinden.
    } finally {
        presentation.dispose();
    }
}
```