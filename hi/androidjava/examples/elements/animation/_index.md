---
title: एनिमेशन
type: docs
weight: 100
url: /hi/androidjava/examples/elements/animation/
keywords:
- कोड उदाहरण
- एनिमेशन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android एनिमेशन उदाहरणों को देखें: जोड़ें, क्रमबद्ध करें, और Java के साथ PPT, PPTX और ODP प्रस्तुतियों के लिए प्रभाव और ट्रांज़िशन को अनुकूलित करें।"
---
यह लेख सरल एनिमेशन बनाने और उनके क्रम को प्रबंधित करने का प्रदर्शन करता है, **Aspose.Slides for Android via Java** का उपयोग करके।

## **एनिमेशन जोड़ें**

एक आयताकार आकृति बनाएं और क्लिक पर ट्रिगर होने वाले फ़ेड इफ़ेक्ट को लागू करें।

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

## **एनिमेशन तक पहुंचें**

स्लाइड टाइमलाइन से पहला एनिमेशन इफ़ेक्ट प्राप्त करें।

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // पहले एनिमेशन प्रभाव तक पहुँचें।
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **एनिमेशन हटाएँ**

क्रम से एक एनिमेशन इफ़ेक्ट को हटाएँ।

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // प्रभाव हटाएँ।
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **एनिमेशन क्रमबद्ध करें**

एकाधिक इफ़ेक्ट जोड़ें और यह दिखाएँ कि एनिमेशन किस क्रम में होते हैं।

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