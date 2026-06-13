---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में आकार एनीमेशन लागू करें
linktitle: आकार एनीमेशन
type: docs
weight: 60
url: /hi/nodejs-java/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनीमेटेड आकार
- एनीमेटेड टेक्स्ट
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव ध्वनि
- एनीमेशन लागू करें
- पावरपॉइंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js via Java के साथ पावरपॉइंट प्रस्तुतियों में आकार एनीमेशन बनाना और अनुकूलित करना सीखें। अलग दिखें!"
---
## **परिचय**

एनिमेशन दृश्य प्रभाव हैं जिन्हें टेक्स्ट, छवियों, आकारों, या [चार्ट्स](/slides/hi/nodejs-java/animated-charts/) पर लागू किया जा सकता है। वे प्रस्तुतियों या उसकी सामग्री को जीवंत बनाते हैं।

## **प्रेजेंटेशन में एनिमेशन का उपयोग क्यों करें?**

* जानकारी के प्रवाह को नियंत्रित करें
* महत्वपूर्ण बिंदुओं पर ज़ोर दें
* दर्शकों की रुचि या भागीदारी बढ़ाएँ
* सामग्री को पढ़ना, समझना या प्रोसेस करना आसान बनाएँ
* अपने पाठकों या दर्शकों का ध्यान प्रस्तुति के महत्वपूर्ण हिस्सों की ओर आकर्षित करें

PowerPoint एनिमेशन और एनिमेशन इफ़ेक्ट्स के लिए **एंट्रेंस**, **एक्ज़िट**, **इम्फ़ेसिस**, और **मोशन पाथ्स** श्रेणियों में कई विकल्प और टूल्स प्रदान करता है।

## **Aspose.Slides में एनिमेशन**

* Aspose.Slides आपके लिए आवश्यक क्लासेस और टाइप्स प्रदान करता है जो `Aspose.Slides.Animation` नेमस्पेस के तहत एनिमेशन के साथ काम करने के लिए आवश्यक हैं,
* Aspose.Slides [EffectType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effecttype) enumeration के तहत **150 से अधिक एनिमेशन इफ़ेक्ट्स** प्रदान करता है। ये इफ़ेक्ट्स मूलतः वही (या समतुल्य) इफ़ेक्ट्स हैं जो PowerPoint में उपयोग होते हैं।

## **टेक्स्टबॉक्स पर एनिमेशन लागू करें**

Aspose.Slides for Node.js via Java आपको आकार में टेक्स्ट पर एनिमेशन लागू करने की सुविधा देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएँ।
2. उसके इंडेक्स के माध्यम से एक स्लाइड रेफ़रेंस प्राप्त करें।
3. एक `rectangle` [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape) जोड़ें।
4. [AutoShape.addTextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) का उपयोग करके टेक्स्ट जोड़ें।
5. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें।
6. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape) में एक एनिमेशन इफ़ेक्ट जोड़ें।
7. `BuildType` enumeration से मान के साथ `TextAnimation.setBuildType` मेथड को कॉल करें।
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

यह JavaScript कोड दर्शाता है कि कैसे `Fade` इफ़ेक्ट को AutoShape पर लागू किया जाए और टेक्स्ट एनिमेशन को *By 1st Level Paragraphs* मान पर सेट किया जाए:

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का निर्माण करता है।
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // नया AutoShape टेक्स्ट के साथ जोड़ता है
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    var sequence = sld.getTimeline().getMainSequence();
    // shape में Fade एनीमेशन इफ़ेक्ट जोड़ता है
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // shape टेक्स्ट को पहले स्तर के पैराग्राफ़ द्वारा एनीमेेट करता है
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

टेक्स्ट पर एनिमेशन लागू करने के अलावा, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph) पर भी एनिमेशन लागू कर सकते हैं। देखें [**Animated Text**](/slides/hi/nodejs-java/animated-text/).

{{% /alert %}} 

## **PictureFrame पर एनीमेशन लागू करें**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएँ।
2. स्लाइड का रेफ़रेंस उसके इंडेक्स से प्राप्त करें।
3. स्लाइड पर एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe) जोड़ें या प्राप्त करें।
4. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें।
5. [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe) में एक एनिमेशन इफ़ेक्ट जोड़ें।
6. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है।
var pres = new aspose.slides.Presentation();
try {
    // प्रस्तुति इमेज संग्रह में जोड़ने के लिए इमेज लोड करें
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // स्लाइड में पिक्चर फ्रेम जोड़ता है
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // पिक्चर फ्रेम पर बाएं से फ्लाइ एनीमेशन इफ़ेक्ट जोड़ता है
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Shape पर एनीमेशन लागू करें**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएँ।
2. स्लाइड का रेफ़रेंस उसके इंडेक्स से प्राप्त करें।
3. एक `rectangle` [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape) जोड़ें।
4. एक `Bevel` [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape) जोड़ें (जब इस ऑब्जेक्ट पर क्लिक किया जाएगा, तो एनिमेशन चलाया जाएगा)।
5. बीवल आकार पर इफ़ेक्ट्स की एक श्रृंखला बनाएँ।
6. एक कस्टम `UserPath` बनाएँ।
7. `UserPath` पर मूव करने के लिए कमांड जोड़ें।
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है।
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // मौजूदा shape के लिए स्क्रैच से PathFootball इफ़ेक्ट बनाता है।
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // कुछ प्रकार का "button" बनाता है।
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // इस बटन के लिए इफ़ेक्ट्स की अनुक्रम बनाता है।
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // एक कस्टम यूज़र पाथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक होने के बाद ही मूव होगा।
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // चूंकि बनाया गया पाथ खाली है, इसलिए मूव करने के कमांड जोड़ता है।
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Shape पर लागू किए गए एनीमेशन इफ़ेक्ट्स प्राप्त करें**

निम्नलिखित उदाहरण दर्शाते हैं कि कैसे आप [Sequence](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/) क्लास की `getEffectsByShape` मेथड का उपयोग करके किसी shape पर लागू सभी एनीमेशन इफ़ेक्ट्स प्राप्त कर सकते हैं।

**उदाहरण 1: सामान्य स्लाइड पर एक shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

पहले, आपने PowerPoint प्रस्तुतियों में shapes पर एनीमेशन इफ़ेक्ट्स जोड़ना सीखा था। निम्नलिखित सैंपल कोड दर्शाता है कि कैसे प्रस्तुति `AnimExample_out.pptx` की पहली सामान्य स्लाइड के पहले shape पर लागू इफ़ेक्ट्स प्राप्त किए जा सकते हैं।

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // स्लाइड की मुख्य एनीमेशन अनुक्रम प्राप्त करता है।
    var sequence = firstSlide.getTimeline().getMainSequence();

    // पहली स्लाइड पर पहला shape प्राप्त करता है।
    var shape = firstSlide.getShapes().get_Item(0);

    // shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करता है।
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**उदाहरण 2: सभी एनीमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स भी शामिल हों**

यदि किसी सामान्य स्लाइड पर कोई shape ऐसा है जिसका प्लेसहोल्डर लेआउट स्लाइड या मास्टर स्लाइड पर स्थित है, और इन प्लेसहोल्डरों पर एनीमेशन इफ़ेक्ट्स जोड़े गए हैं, तो स्लाइड शो के दौरान shape के सभी इफ़ेक्ट्स चलाए जाएंगे, जिसमें प्लेसहोल्डरों से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

मान लीजिए हमारे पास `sample.pptx` नामक एक PowerPoint प्रस्तुति फ़ाइल है जिसमें केवल एक स्लाइड है, जिसमें फुटर shape में टेक्स्ट "Made with Aspose.Slides" है और shape पर **Random Bars** इफ़ेक्ट लागू किया गया है।

![स्लाइड shape एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

मान लीजिए फुटर प्लेसहोल्डर पर **layout** स्लाइड में **Split** इफ़ेक्ट लागू किया गया है।

![लेआउट shape एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

और अंत में **master** स्लाइड में फुटर प्लेसहोल्डर पर **Fly In** इफ़ेक्ट लागू किया गया है।

![मास्टर shape एनीमेशन इफ़ेक्ट](master-shape-animation.png)

निम्नलिखित सैंपल कोड दर्शाता है कि कैसे आप [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) क्लास की `getBasePlaceholder` मेथड का उपयोग करके shape प्लेसहोल्डरों तक पहुंच सकते हैं और फुटर shape पर लागू एनीमेशन इफ़ेक्ट्स, साथ ही लेआउट और मास्टर स्लाइड पर स्थित प्लेसहोल्डरों से विरासत में मिले इफ़ेक्ट्स को प्राप्त कर सकते हैं।

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // फ़्लाइ, नीचे
Type: 134, subtype: 45            // स्प्लिट, वर्टिकलइन
Type: 126, subtype: 22            // रैंडमबार्स, क्षैतिज
```

## **एनीमेशन इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for Node.js via Java आपको एनीमेशन इफ़ेक्ट की टाइमिंग प्रॉपर्टीज़ बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पेन है:

![एनीमेशन टाइमिंग पेन](shape-animation.png)

- PowerPoint टाइमिंग **Start** ड्रॉप-डाउन सूची [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Timing#getTriggerType--) प्रॉपर्टी से मेल खाती है।
- PowerPoint टाइमिंग **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Timing#getDuration--) प्रॉपर्टी से मेल खाती है। एनीमेशन की अवधि (सेकंड में) वह कुल समय है जिसमें एनीमेशन एक चक्र पूरा करता है।
- PowerPoint टाइमिंग **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) प्रॉपर्टी से मेल खाती है।

यहाँ बताया गया है कि आप Effect Timing प्रॉपर्टीज़ कैसे बदल सकते हैं:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।
2. आवश्यक [Effect.Timing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Effect#getTiming--) प्रॉपर्टीज़ के नए मान सेट करें।
3. संशोधित PPTX फ़ाइल को सहेजें।

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है।
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है।
    var effect = sequence.get_Item(0);
    // इफ़ेक्ट के TriggerType को क्लिक पर शुरू होने के लिए बदलता है
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // इफ़ेक्ट की अवधि बदलता है
    effect.getTiming().setDuration(3.0);
    // इफ़ेक्ट के TriggerDelayTime को बदलता है
    effect.getTiming().setTriggerDelayTime(0.5);
    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **एनीमेशन इफ़ेक्ट साउंड**

Aspose.Slides एनीमेशन इफ़ेक्ट्स में साउंड के साथ काम करने के लिए ये प्रॉपर्टीज़ प्रदान करता है:

- [setSound(IAudio value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) – एनीमेशन इफ़ेक्ट में साउंड सेट करने के लिए।
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-) – पिछले साउंड को रोकने के लिए।

### **एनीमेशन इफ़ेक्ट साउंड जोड़ें**

यह JavaScript कोड दर्शाता है कि कैसे एनीमेशन इफ़ेक्ट साउंड जोड़ा जाए और अगला इफ़ेक्ट शुरू होने पर उसे रोका जाए:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // प्रस्तुति ऑडियो संग्रह में ऑडियो जोड़ता है
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    var sequence = firstSlide.getTimeline().getMainSequence();
    // मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
    var firstEffect = sequence.get_Item(0);
    // इफ़ेक्ट को "नो साउंड" के लिए जाँचता है
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // पहले इफ़ेक्ट के लिए साउंड जोड़ता है
        firstEffect.setSound(effectSound);
    }
    // स्लाइड की पहली इंटरैक्टिव अनुक्रम प्राप्त करता है।
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // इफ़ेक्ट "Stop previous sound" फ़्लैग सेट करता है
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **एनीमेशन इफ़ेक्ट साउंड निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टांस बनाएँ।
2. स्लाइड का रेफ़रेंस उसके इंडेक्स से प्राप्त करें। 
3. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें। 
4. प्रत्येक एनीमेशन इफ़ेक्ट में एम्बेडेड [setSound(IAudio value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) को निकालें।

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है।
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // इफ़ेक्ट साउंड को बाइट एरे में निकालता है
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **एनीमेशन के बाद**

Aspose.Slides for Node.js via Java आपको एनीमेशन इफ़ेक्ट की After animation प्रॉपर्टी बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन इफ़ेक्ट पैन और विस्तारित मेनू है:

![एनीमेशन के बाद पैनल](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप-डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) मेथड जो एनीमेशन के बाद के प्रकार को वर्णित करता है;
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/afteranimationtype/#Color) प्रकार से मेल खाता है;
  * PowerPoint **Don't Dim** सूची आइटम [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) प्रकार से मेल खाता है (डिफ़ॉल्ट एनीमेशन के बाद प्रकार);
  * PowerPoint **Hide After Animation** आइटम [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) प्रकार से मेल खाता है;
  * PowerPoint **Hide on Next Mouse Click** आइटम [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) प्रकार से मेल खाता है;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) मेथड जो एनीमेशन के बाद के रंग फ़ॉर्मेट को परिभाषित करता है। यह मेथड [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/afteranimationtype/#Color) प्रकार के साथ काम करता है। यदि आप प्रकार को किसी अन्य में बदलते हैं, तो एनीमेशन के बाद का रंग साफ़ हो जाएगा।

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // एनीमेशन के बाद के प्रकार को Color में बदलता है
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // एनीमेशन के बाद की डिम रंग सेट करता है
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेक्स्ट एनीमेट करें**

Aspose.Slides एनीमेशन इफ़ेक्ट के *Animate text* ब्लॉक के साथ काम करने के लिए ये प्रॉपर्टीज़ प्रदान करता है:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) जो इफ़ेक्ट के *Animate text* प्रकार को वर्णित करता है। आकार का टेक्स्ट एनीमेट किया जा सकता है:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) प्रकार)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/animatetexttype/#ByWord) प्रकार)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/animatetexttype/#ByLetter) प्रकार)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) एनीमेटेड टेक्स्ट भागों (शब्द या अक्षर) के बीच देरी सेट करता है। सकारात्मक मान इफ़ेक्ट की अवधि का प्रतिशत दर्शाता है। नकारात्मक मान सेकंड में देरी दर्शाता है।

यहाँ बताया गया है कि आप Effect Animate text प्रॉपर्टीज़ कैसे बदल सकते हैं:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।
2. [setBuildType(int value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) मेथड को [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/buildtype/#AsOneObject) मान पर सेट करें ताकि *By Paragraphs* एनीमेशन मोड बंद हो जाए।
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) और [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) प्रॉपर्टीज़ के नए मान सेट करें।
4. संशोधित PPTX फ़ाइल को सहेजें।

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है।
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // इफ़ेक्ट के Text animation प्रकार को "As One Object" में बदलता है
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // इफ़ेक्ट के Animate text प्रकार को "By word" में बदलता है
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // शब्दों के बीच की देरी को इफ़ेक्ट अवधि के 20% पर सेट करता है
    firstEffect.setDelayBetweenTextParts(20.0);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**मैं कैसे सुनिश्चित करूँ कि वेब पर प्रस्तुति प्रकाशित करने पर एनीमेशन संरक्षित रहें?**

[Export to HTML5](/slides/hi/nodejs-java/export-to-html5/) और उन [options](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/) को सक्षम करें जो [shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/setanimateshapes/) और [transition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/setanimatetransitions/) एनीमेशन के लिए जिम्मेदार हैं। साधारण HTML स्लाइड एनीमेशन नहीं चलाता, जबकि HTML5 करता है।

**आकारों के z-order (लेयर ऑर्डर) को बदलने से एनीमेशन पर क्या प्रभाव पड़ता है?**

एनीमेशन और ड्राइंग क्रम स्वतंत्र होते हैं: एक इफ़ेक्ट दिखने/गायब होने के समय और प्रकार को नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getzorderposition/) निर्धारित करता है कि क्या क्या को ढकता है। दृश्य परिणाम उनका संयोजन निर्धारित करता है। (यह PowerPoint के सामान्य व्यवहार के समान है; Aspose.Slides का इफ़ेक्ट‑और‑शेप मॉडल भी यही तर्क अपनाता है।)

**क्या कुछ इफ़ेक्ट्स को वीडियो में बदलते समय कोई सीमाएँ हैं?**

आम तौर पर, [एनीमेशन समर्थित हैं](/slides/hi/nodejs-java/convert-powerpoint-to-video/), लेकिन दुर्लभ मामलों या विशेष इफ़ेक्ट्स में अलग रेंडरिंग हो सकती है। उपयोग किए गए इफ़ेक्ट्स और लाइब्रेरी संस्करण के साथ परीक्षण करने की सलाह दी जाती है।