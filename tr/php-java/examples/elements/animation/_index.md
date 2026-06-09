---
title: Animasyon
type: docs
weight: 100
url: /tr/php-java/examples/elements/animation/
keywords:
- animasyon
- animasyon ekle
- animasyona eriş
- animasyon kaldır
- animasyon sırası
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de ana slayt animasyonlarını yönetin: etkileri, zamanlamaları ve tetikleyicileri ekleyin, düzenleyin ve kaldırın; PPT, PPTX ve ODP formatlarında dinamik sunumlar oluşturun."
---
Basit animasyonlar oluşturmayı ve sırasını yönetmeyi **Aspose.Slides for PHP via Java** kullanarak gösterir.

## **Animasyon Ekle**

Bir dikdörtgen şekil oluşturun ve tıklandığında tetiklenen bir solma (fade-in) efekti uygulayın.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Açılma efekti.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animasyona Eriş**

Slayt zaman çizelgesinden ilk animasyon etkisini alın.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // İlk animasyon etkisine eriş.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animasyonu Kaldır**

Bir animasyon etkisini diziden kaldırın.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Etkiyi kaldır.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animasyonları Sırala**

Birden fazla efekt ekleyin ve animasyonların gerçekleşme sırasını gösterin.

```php
function sequenceAnimations() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

        $sequence = $slide->getTimeline()->getMainSequence();
        $sequence->addEffect($shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
        $sequence->addEffect($shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

        $presentation->save("animation_sequence.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```