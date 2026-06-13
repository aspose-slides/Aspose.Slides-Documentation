---
title: एनिमेशन
type: docs
weight: 100
url: /hi/java/examples/elements/animation/
keywords:
- कोड उदाहरण
- एनिमेशन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java एनीमेशन उदाहरणों का अन्वेषण करें: जोड़ें, क्रमबद्ध करें, और जावा के साथ PPT, PPTX, और ODP प्रस्तुतियों के लिए प्रभाव और संक्रमण को अनुकूलित करें।"
---
यह लेख दर्शाता है कि कैसे सरल एनीमेशन बनाएं और **Aspose.Slides for Java** का उपयोग करके उनकी क्रमबद्धता को प्रबंधित करें।

## **एनीमेशन जोड़ें**

एक आयताकार आकार बनाएं और क्लिक पर ट्रिगर होने वाला फ़ेड प्रभाव लागू करें।

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // फ़ेड प्रभाव।
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **एनीमेशन तक पहुँचें**

स्लाइड टाइमलाइन से पहली एनीमेशन इफ़ेक्ट प्राप्त करें।

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // पहले एनीमेशन इफ़ेक्ट तक पहुँचें।
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **एनीमेशन हटाएँ**

क्रम से एक एनीमेशन प्रभाव हटाएँ।

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // प्रभाव को हटाएँ।
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **एनीमेशन क्रमबद्ध करें**

कई प्रभाव जोड़ें और दिखाएँ कि एनीमेशन किस क्रम में होते हैं।

```java
static void sequenceAnimations() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

        ISequence sequence = slide.getTimeline().getMainSequence();
        sequence.addEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
        sequence.addEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    } finally {
        presentation.dispose();
    }
}
```