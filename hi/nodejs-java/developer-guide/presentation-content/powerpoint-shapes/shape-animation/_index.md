---
title: प्रेज़ेंटेशन में जावास्क्रिप्ट का उपयोग करके शेप एनीमेशन लागू करें
linktitle: शेप एनीमेशन
type: docs
weight: 60
url: /hi/nodejs-java/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनिमेटेड आकार
- एनिमेटेड पाठ
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव ध्वनि
- एनीमेशन लागू करें
- PowerPoint
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ आकार एनीमेशन, टाइमिंग, आवाज़, एनीमेशन‑के‑बाद व्यवहार, और एनिमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **अवलोकन**

एक प्रभाव के भीतर व्यक्तिगत व्यवहारों के साथ काम करने या मोशन‑पाथ खंडों को संपादित करने के लिए, देखें [कस्टम एनीमेशन](/slides/hi/nodejs-java/custom-animation/)।

Aspose.Slides for Node.js via Java स्लाइड एनीमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट के रूप में दर्शाता है। एक इफ़ेक्ट का लक्ष्य आकार, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, तथा वैकल्पिक गुण जैसे साउंड या एनीमेशन‑के‑बाद व्यवहार होते हैं।

टाइमलाइन दो प्रकार की क्रम श्रृंखलाएँ रखती है:

- **मुख्य क्रम** स्लाइड आगे बढ़ने पर चलता है।  
- **इंटरैक्टिव क्रम** तब शुरू होता है जब उसका ट्रिगर आकार क्लिक किया जाता है।

चूँकि टेक्स्ट बॉक्स, चित्र, चार्ट, तालिका और अन्य स्लाइड वस्तुएँ [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) वस्तुएँ हैं, आप अधिकांश स्लाइड सामग्री के लिए वही [Sequence.addEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#addEffect) मेथड उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effecttype/) एनेमरेशन में सूचीबद्ध हैं।

## **Shape एनीमेशन जोड़ें**

एनीमेशन जोड़ने के लिए, स्लाइड की मुख्य क्रम प्राप्त करें और लक्ष्य आकार, इफ़ेक्ट प्रकार, उपप्रकार और ट्रिगर के साथ [Sequence.addEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#addEffect) को कॉल करें। किसी अन्य आकार पर क्लिक करने से शुरू होने वाले इफ़ेक्ट के लिए, उस अन्य आकार को ट्रिगर बनाते हुए एक इंटरैक्टिव क्रम बनाएँ।

निम्न उदाहरण दोनों प्रकार के एनीमेशन बनाता है और परिणाम `shape-animations.pptx` में सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ट्रिगर निर्धारित करता है कि इफ़ेक्ट कब शुरू होता है:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effecttriggertype/#OnClick) मुख्य क्रम में क्लिक या इंटरैक्टिव क्रम में ट्रिगर आकार पर क्लिक की प्रतीक्षा करता है।  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) पूर्व इफ़ेक्ट के साथ शुरू होता है।  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) जब पूर्व इफ़ेक्ट समाप्त होता है तब शुरू होता है।

चित्र, चार्ट या किसी अन्य आकार को एनीमेट करने के लिए, `targetShape` के बजाय उस वस्तु को [Sequence.addEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#addEffect) में पास करें। चार्ट‑विशिष्ट समूह विकल्पों के लिए, देखें [एनिमेटेड चार्ट्स](/slides/hi/nodejs-java/animated-charts/)।

## **Shape एनीमेशन पढ़ें**

जब आपको लक्ष्य आकार पता हो, तब [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#getEffectsByShape) का उपयोग करें। सभी इफ़ेक्ट्स की जाँच करने के लिए, मुख्य क्रम और प्रत्येक इंटरैक्टिव क्रम को क्रमबद्ध रूप से परिक्रमा करें। क्रमबद्ध परिक्रमा यह मानने से बचती है कि किसी क्रम में सूचकांक `0` पर इफ़ेक्ट मौजूद है।

निम्न उदाहरण एक आकार बनाता है जिसमें मुख्य‑क्रम और इंटरैक्टिव इफ़ेक्ट्स होते हैं, फिर आकार को लक्षित करने वाले इफ़ेक्ट्स प्राप्त करता है और अंत में स्लाइड की सभी क्रमों को परिक्रमा करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक आकार के इफ़ेक्ट चाहिए, तो पहले आकार को नाम, प्लेसहोल्डर प्रकार या किसी अन्य स्थिर गुण से पहचानें; फिर [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#getEffectsByShape) को कॉल करें। यह न मानें कि [ShapeCollection.get_Item](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#get_Item) सूचकांक `0` पर हमेशा इच्छित वस्तु है।

## **निर्धारित प्लेसहोल्डर इफ़ेक्ट्स के साथ काम करें**

सामान्य स्लाइड पर एक प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर स्थित समान प्लेसहोल्डर से एनीमेशन व्यवहार विरासत में ले सकता है। [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getBasePlaceholder) वह पैरेंट प्लेसहोल्डर लौटाता है, या जब कोई पैरेंट न हो तो `null`।

निम्न उदाहरण प्रस्तुति में, फुटर पर सामान्य स्लाइड में **Random Bars**, लेआउट स्लाइड में **Split**, और मास्टर स्लाइड में **Fly In** होते हैं।

![सामान्य स्लाइड पर फुटर एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](master-shape-animation.png)

अगला उदाहरण एक नई प्रस्तुति की प्लेसहोल्डर पदानुक्रम का उपयोग करता है। यह एक मास्टर प्लेसहोल्डर, एक लेआउट प्लेसहोल्डर और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में इफ़ेक्ट्स जोड़ता है। प्रत्येक बार [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getBasePlaceholder) को कॉल करने के बाद ही लौटाए गए आकार का उपयोग किया जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एनीमेशन टाइमिंग बदलें**

PowerPoint **Timing** संवाद [Timing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/) की गुणधर्मों से मेल खाता है।

![एक एनीमेशन इफ़ेक्ट के लिए PowerPoint टाइमिंग संवाद](shape-animation.png)

- **Start** को [Timing.getTriggerType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getTriggerType) से मैप किया जाता है।  
- **Duration** को [Timing.getDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getDuration) से मैप किया जाता है, सेकंड में।  
- **Delay** को [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) से मैप किया जाता है, सेकंड में।  
- **Repeat** को [Timing.getRepeatCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) या [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) से मैप किया जाता है।  
- **Rewind when done playing** को [Timing.getRewind](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getRewind) से मैप किया जाता है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, उसे [Sequence.addEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#addEffect) द्वारा लौटाए गए वस्तु के माध्यम से टाइमिंग बदलता है, और परिणाम सहेजता है। लौटाए गए [Effect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/) संदर्भ को रखने से अनावश्यक कलेक्शन सूचकांक से बचा जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक बार में केवल एक रीपीट मोड का इरादा से उपयोग करें। रीपीट काउंट को “until” फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित करने वाले परिणाम उत्पन्न हो सकते हैं। रीपीट मोड बदलते समय, पहले [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) और [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) सेट करें, फिर [Timing.setRepeatCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#setRepeatCount) को कॉल करें, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय रीपीट मोड बदल जाता है।

## **एनीमेशन साउंड जोड़ें और निकालें**

एक एनीमेशन इफ़ेक्ट एम्बेडेड ऑडियो का संदर्भ [Effect.getSound](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getSound) द्वारा रख सकता है। [Effect.setStopPreviousSound](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setStopPreviousSound) एक इफ़ेक्ट को पहले वाले इफ़ेक्ट द्वारा शुरू किए गए ऑडियो को रोकने के लिए कहता है।

### **इफ़ेक्ट में साउंड जोड़ें**

निम्न उदाहरण स्थानीय ऑडियो फाइल `animation-sound.wav` की उम्मीद करता है। यह दो इफ़ेक्ट बनाता है, पहली इफ़ेक्ट के लिए उस फाइल को साउंड के रूप में एम्बेड करता है, और दूसरी इफ़ेक्ट को साउंड को रोकने के लिए कॉन्फ़िगर करता है। यह [Sequence.addEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#addEffect) द्वारा लौटाए गए वस्तुओं का उपयोग करता है, इसलिए कोई क्रम सूचकांक आवश्यक नहीं है।

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **एम्बेडेड इफ़ेक्ट साउंड निकालें**

निम्न उदाहरण स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की उम्मीद करता है। यह मुख्य और इंटरैक्टिव दोनों क्रमों को स्कैन करता है और प्रत्येक एम्बेडेड इफ़ेक्ट साउंड को `extracted-animation-sounds` निर्देशिका में लिखता है। एक्सटेंशन ऑडियो MIME प्रकार से निकाला जाता है जो [Audio.getContentType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audio/#getContentType) द्वारा उपलब्ध कराया जाता है।

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

बड़ी ऑडियो वस्तुओं के लिए, [Audio.getStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audio/#getStream) का उपयोग करके स्ट्रीम को फ़ाइल में कॉपी करें, बजाय पूरी वस्तु को बाइट ऐरे में लोड करने के।

## **After-Animation व्यवहार सेट करें**

**After animation** विकल्प निर्धारित करता है कि इफ़ेक्ट समाप्त होने के बाद आकार के साथ क्या होता है।

![PowerPoint इफ़ेक्ट विकल्प संवाद जिसमें After animation सेटिंग दिखती है](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/afteranimationtype/) एनेमरेशन आकार को अपरिवर्तित रहने, उसका रंग बदलने, एनीमेशन के बाद छिपाने या अगले क्लिक पर छिपाने का समर्थन करता है। जब प्रकार [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/afteranimationtype/#Color) हो, तो साथ ही [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) सेट करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, लौटाए गए इफ़ेक्ट ऑब्जेक्ट के माध्यम से उसके After‑Animation व्यवहार को सेट करता है, और परिणाम सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/afteranimationtype/#Color) से प्रकार बदलने पर After‑Animation रंग सेटिंग साफ़ हो जाती है।

## **पाठ को एनीमेट करें**

पाठ एनीमेशन दो संबंधित नियंत्रणों से बना है:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textanimation/#getBuildType) निर्धारित करता है कि अनुच्छेद एक साथ दिखें या अनुच्छेद‑स्तर पर।  
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getAnimateTextType) निर्धारित करता है कि पाठ एक साथ, शब्द‑दर‑शब्द या अक्षर‑दर‑अक्षर दिखे। [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) शब्द या अक्षर के बीच देरी सेट करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत है; नकारात्मक मान सेकंड में देरी है।

निम्न स्वतंत्र उदाहरण एक टेक्स्ट बॉक्स में शब्दों को एनीमेट करता है। [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/buildtype/#AsOneObject) पैराग्राफ‑दर‑पैराग्राफ निर्माण को निष्क्रिय करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पैराग्राफ‑दर‑पैराग्राफ टेक्स्ट बॉक्स बनाने के लिए, [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (या कोई अन्य पैराग्राफ स्तर) सेट करें। एकल पैराग्राफ को उसके स्वयं के इफ़ेक्ट से लक्षित करने के लिए, वह [Sequence.addEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#addEffect) ओवरलोड उपयोग करें जो [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) को स्वीकार करता है। पैराग्राफ‑स्तर उदाहरणों के लिये देखें [Animated Text](/slides/hi/nodejs-java/animated-text/)।

## **निर्यात और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल संरक्षित रहता है, परन्तु अंतिम प्लेबैक प्रस्तुति दर्शक द्वारा नियंत्रित होता है।  
- PDF और स्थिर छवियाँ एनीमेशन नहीं चलातीं। जब गति दिखानी आवश्यक हो तो [HTML5 निर्यात](/slides/hi/nodejs-java/export-to-html5/), एनीमेटेड GIF, या [वीडियो रूपांतरण](/slides/hi/nodejs-java/convert-powerpoint-to-video/) का उपयोग करें।  
- HTML5 के लिये, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/#setAnimateShapes) को सक्षम करें और आवश्यकतानुसार [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) को सक्रिय करें।  
- वीडियो रेंडरिंग कई सामान्य प्रवेश, ज़ोर, निकास और मोशन‑पाथ इफ़ेक्ट्स को समर्थन देता है, परन्तु हर PowerPoint इफ़ेक्ट समर्थित नहीं है। वर्तमान [समर्थित एनीमेशन और इफ़ेक्ट्स](/slides/hi/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और अपने लक्ष्य Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।  
- उन्नत कस्टम इफ़ेक्ट्स और अन्य प्रस्तुति स्वरूपों से आयातित इफ़ेक्ट्स फ़ाइल में संरक्षित हो सकते हैं, परन्तु PowerPoint, HTML5 या वीडियो में अलग तरह से रेंडर हो सकते हैं। निर्यात परिणाम को मान्य करें, केवल इफ़ेक्ट नाम पर भरोसा न करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में एनीमेशन दिखता है लेकिन PDF में नहीं दिखता, क्यों?**

PDF एक स्थिर स्वरूप है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन चलाए नहीं जाते। जब गति चाहिए तो HTML5, एनीमेटेड GIF या वीडियो में निर्यात करें।

**वीडियो में इफ़ेक्ट अलग तरह से चलती है, क्यों?**

वीडियो निर्यात एनीमेशन को रेंडर करता है, मूल PowerPoint व्यवहार को नहीं रखता। कुछ उन्नत इफ़ेक्ट्स असमर्थित या अनुमानित होते हैं। समर्थित‑इफ़ेक्ट्स तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या आकार को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। आकार का z‑order ओवरलैप को नियंत्रित करता है, जबकि क्रम और ट्रिगर एनीमेशन प्लेबैक को नियंत्रित करते हैं। यदि अलग प्लेबैक क्रम चाहिए तो टाइमलाइन को बदलें।