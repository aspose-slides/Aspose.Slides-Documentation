---
title: एनिमेशन
type: docs
weight: 100
url: /hi/php-java/examples/elements/animation/
keywords:
- एनिमेशन
- एनीमेशन जोड़ें
- एनीमेशन तक पहुंचें
- एनीमेशन हटाएँ
- एनीमेशन अनुक्रम
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में स्लाइड एनीमेशन को नियंत्रित करें: प्रभाव, समय और ट्रिगर को जोड़ें, संपादित करें और हटाएँ ताकि PPT, PPTX और ODP में गतिशील प्रस्तुतियाँ बनाई जा सके।"
---
सरल एनीमेशन बनाने और उनकी क्रमबद्धता को प्रबंधित करने के तरीके को **Aspose.Slides for PHP via Java** का उपयोग करके दिखाता है।

## **एक एनीमेशन जोड़ें**

एक आयताकार आकार बनाएं और क्लिक पर ट्रिगर होने वाला फ़ेड-इन प्रभाव लागू करें।

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // फ़ेड इन प्रभाव।
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **एक एनीमेशन तक पहुंचें**

स्लाइड टाइमलाइन से पहला एनीमेशन प्रभाव प्राप्त करें।

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // पहले एनीमेशन प्रभाव तक पहुंचें।
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **एक एनीमेशन हटाएँ**

क्रम से एक एनीमेशन प्रभाव हटाएँ।

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // प्रभाव हटाएँ।
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **एनीमेशन को क्रमबद्ध करें**

कई प्रभाव जोड़ें और दिखाएँ कि एनीमेशन किस क्रम में होते हैं।

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