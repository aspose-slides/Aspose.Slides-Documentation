---
title: एनीमेशन
type: docs
weight: 100
url: /hi/nodejs-java/examples/elements/animation/
keywords:
- कोड उदाहरण
- एनीमेशन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js एनीमेशन उदाहरणों का अन्वेषण करें: जोड़ें, क्रमबद्ध करें, और JavaScript के साथ PPT, PPTX, और ODP प्रस्तुतियों के लिए प्रभाव और ट्रांज़िशन को अनुकूलित करें।"
---
यह लेख सरल एनीमेशन बनाने और उनकी क्रमबद्धता को प्रबंधित करने का प्रदर्शन करता है **Aspose.Slides for Node.js via Java** का उपयोग करके।

## **एनीमेशन जोड़ें**

एक आयताकार आकार बनाएं और क्लिक पर ट्रिगर होने वाले फ़ेड इफ़ेक्ट को लागू करें।

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // फ़ेड इफ़ेक्ट।
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **एनीमेशन तक पहुंचें**

स्लाइड टाइमलाइन से पहला एनीमेशन इफ़ेक्ट प्राप्त करें।

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // पहले एनीमेशन इफ़ेक्ट तक पहुंचें।
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **एनीमेशन हटाएँ**

क्रम से एक एनीमेशन इफ़ेक्ट हटाएँ।

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // पहला प्रभाव हटाएँ।
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **एनीमेशन क्रमबद्ध करें**

एकाधिक इफ़ेक्ट जोड़ें और दिखाएँ कि एनीमेशन किस क्रम में होते हैं।

```js
function sequenceAnimations() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 200, 50, 100, 100);

        let sequence = slide.getTimeline().getMainSequence();
        sequence.addEffect(
            shape1, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
        sequence.addEffect(
            shape2, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation_sequence.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```