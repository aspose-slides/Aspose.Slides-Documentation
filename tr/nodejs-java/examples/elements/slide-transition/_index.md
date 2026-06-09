---
title: Slayt Geçişi
type: docs
weight: 110
url: /tr/nodejs-java/examples/elements/slide-transition/
keywords:
- kod örneği
- slayt geçişi
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te slayt geçişlerinde uzmanlaşın: PPT, PPTX ve ODP sunumları için örneklerle efektleri ve süreleri ekleyin, özelleştirin ve sıralayın."
---
Bu makale, **Aspose.Slides for Node.js via Java** ile slayt geçiş efektleri ve zamanlamalarının uygulanmasını gösterir.

## **Slayt Geçişi Ekle**

İlk slayta bir solma (fade) geçiş efekti uygulayın.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Bir solma geçişi uygula.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Slayt Geçişine Erişme**

Bir slayta şu anda atanmış geçiş türünü okuyun.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Geçiş türüne eriş.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Slayt Geçişini Kaldır**

Geçiş türünü `None` olarak ayarlayarak tüm geçiş efektlerini temizleyin.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Geçişi kaldırmak için none ayarlayın.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Geçiş Süresini Ayarla**

Slaytın otomatik olarak ilerlemeden önce ne kadar süre gösterileceğini belirtin.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // milisaniye cinsinden.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```