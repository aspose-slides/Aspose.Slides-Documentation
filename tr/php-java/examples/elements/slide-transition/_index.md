---
title: Slayt Geçişi
type: docs
weight: 110
url: /tr/php-java/examples/elements/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişine eriş
- slayt geçişini kaldır
- geçiş süresi
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de slayt geçişlerini kontrol edin: türleri, hızı, sesi ve zamanlamayı seçerek PPT, PPTX ve ODP sunumlarını mükemmelleştirin."
---
**Aspose.Slides for PHP via Java** kullanarak slayt geçiş efektleri ve zamanlamalarının uygulanmasını gösterir.

## **Slayt Geçişi Ekle**

İlk slayta bir solma geçiş efekti uygula.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Bir solma geçişi uygula.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Slayt Geçişine Eriş**

Bir slayta atanmış geçiş tipini oku.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Geçiş tipine eriş.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Slayt Geçişini Kaldır**

Geçiş tipini `None` olarak ayarlayarak herhangi bir geçiş efektini temizle.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Geçişi none ayarlayarak kaldır.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Geçiş Süresini Ayarla**

Slaytın otomatik olarak ilerlemeden önce ne kadar süre gösterileceğini belirt.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // milisaniye cinsinden.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```