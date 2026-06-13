---
title: Android पर प्रस्तुतियों में आकार एनीमेशन लागू करें
linktitle: आकार एनीमेशन
type: docs
weight: 60
url: /hi/androidjava/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनिमेटेड आकार
- एनिमेटेड टेक्स्ट
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव ध्वनि
- एनीमेशन लागू करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint प्रस्तुतियों में आकार एनीमेशन बनाना और कस्टमाइज़ करना जानें। अलग दिखें!"
---
## **परिचय**

एनिमेशन दृश्य प्रभाव हैं जिन्हें पाठ, चित्र, आकार, या [चार्ट्स](https://docs.aspose.com/slides/hi/androidjava/animated-charts/) पर लागू किया जा सकता है। ये प्रस्तुतियों या उनके घटकों को जीवन प्रदान करते हैं।

## **प्रस्तुतियों में एनिमेशन क्यों उपयोग करें?**

* सूचना प्रवाह को नियंत्रित करें
* महत्वपूर्ण बिंदुओं पर ज़ोर दें
* अपने दर्शकों में रुचि या भागीदारी बढ़ाएँ
* सामग्री को पढ़ने, आत्मसात करने या प्रक्रिया करने में आसान बनाएँ
* अपने पाठकों या दर्शकों का ध्यान प्रस्तुति के महत्वपूर्ण भागों की ओर आकर्षित करें

PowerPoint एनिमेशन और एनीमेशन इफ़ेक्ट्स के लिए कई विकल्प और टूल प्रदान करता है, जो **प्रवेश**, **निकास**, **जোর**, और **गति पथ** श्रेणियों में विभाजित हैं।

## **Aspose.Slides में एनिमेशन**

* Aspose.Slides वह क्लासेस और प्रकार प्रदान करता है जो आपको `Aspose.Slides.Animation` नेमस्पेस के तहत एनिमेशन के साथ काम करने के लिए चाहिए,
* Aspose.Slides **150 से अधिक एनिमेशन इफ़ेक्ट्स** [EffectType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttype) एनोमरेशन के तहत प्रदान करता है। ये इफ़ेक्ट्स मूलतः वही (या समकक्ष) इफ़ेक्ट्स हैं जो PowerPoint में उपयोग होते हैं।

## **टेक्स्टबॉक्स पर एनिमेशन लागू करें**

Aspose.Slides for Android via Java आपको आकार के पाठ पर एनिमेशन लागू करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक `rectangle` प्रकार का [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape) जोड़ें।
4. टेक्स्ट को [IAutoShape.TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) में जोड़ें।
5. इफ़ेक्ट्स की मुख्य क्रम (सीक्वेंस) प्राप्त करें।
6. एक एनिमेशन इफ़ेक्ट को [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape) पर जोड़ें।
7. `TextAnimation.BuildType` प्रॉपर्टी को `BuildType` एनोमरेशन के मान पर सेट करें।
8. प्रेज़ेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दिखाता है कि कैसे `Fade` इफ़ेक्ट को AutoShape पर लागू करें और टेक्स्ट एनीमेशन को *By 1st Level Paragraphs* मान पर सेट करें:

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का निर्माण करता है।
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // पाठ के साथ नया AutoShape जोड़ता है।
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // स्लाइड की मुख्य क्रम (sequence) प्राप्त करता है।
    ISequence sequence = sld.getTimeline().getMainSequence();

    // आकार पर Fade एनीमेशन इफ़ेक्ट जोड़ता है।
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // आकार के पाठ को प्रथम स्तर पैराग्राफ द्वारा एनीमेट करता है।
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

भले ही आप टेक्स्ट पर एनिमेशन लागू कर रहे हों, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph) पर भी एनिमेशन लागू कर सकते हैं। देखें [**एनिमेटेड टेक्स्ट**](/slides/hi/androidjava/animated-text/)।

{{% /alert %}} 

## **PictureFrame पर एनिमेशन लागू करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड पर एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe) को जोड़ें या प्राप्त करें।
4. इफ़ेक्ट्स की मुख्य क्रम (सीक्वेंस) प्राप्त करें।
5. [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe) पर एक एनिमेशन इफ़ेक्ट जोड़ें।
6. प्रेज़ेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का निर्माण करता है।
Presentation pres = new Presentation();
try {
    // प्रस्तुति इमेज संग्रह में जोड़ी जाने वाली छवि लोड करें
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड में चित्र फ्रेम जोड़ता है
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // स्लाइड की मुख्य क्रम (sequence) प्राप्त करता है।
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // चित्र फ्रेम पर बाएँ से फ़्लाई एनीमेशन इफ़ेक्ट जोड़ता है
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape पर एनिमेशन लागू करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक `rectangle` प्रकार का [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape) जोड़ें।
4. `Bevel` प्रकार का एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape) जोड़ें (जब इस ऑब्जेक्ट पर क्लिक किया जाता है, एनीमेशन चलाया जाता है)।
5. Bevel आकार पर इफ़ेक्ट्स की एक क्रम बनाएं।
6. एक कस्टम `UserPath` बनाएं।
7. `UserPath` पर ले जाने के लिए कमांड जोड़ें।
8. प्रेज़ेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // मौजूदा आकार के लिए शुरू से PathFootball इफ़ेक्ट बनाता है।
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // किसी प्रकार का "बटन" बनाता है।
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // इस बटन के लिए इफ़ेक्ट्स की एक क्रम (sequence) बनाता है।
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // एक कस्टम यूज़र पाथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक होने के बाद ही हिलेगा।
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // किए गए पाथ खाली होने के कारण मूविंग के कमांड जोड़ता है।
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX फ़ाइल को डिस्क पर लिखता है।
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape पर लागू किए गए एनिमेशन इफ़ेक्ट्स प्राप्त करें**

निम्न उदाहरण दिखाते हैं कि कैसे आप [ISequence](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/) इंटरफ़ेस की `getEffectsByShape` विधि का उपयोग करके किसी आकार पर लागू सभी एनिमेशन इफ़ेक्ट्स प्राप्त कर सकते हैं।

**उदाहरण 1: सामान्य स्लाइड पर किसी आकार पर लागू किए गए एनिमेशन इफ़ेक्ट्स प्राप्त करें**

पहले, आपने PowerPoint प्रस्तुतियों में आकारों पर एनीमेशन इफ़ेक्ट्स जोड़ना सीखा था। निम्न नमूना कोड दिखाता है कि प्रस्तुति `AnimExample_out.pptx` में पहली सामान्य स्लाइड के पहले आकार पर लागू इफ़ेक्ट्स को कैसे प्राप्त किया जाए।

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // स्लाइड के मुख्य एनीमेशन सीक्वेंस को प्राप्त करता है।
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // पहली स्लाइड पर पहला आकार प्राप्त करता है।
    IShape shape = firstSlide.getShapes().get_Item(0);

    // आकार पर लागू एनीमेशन इफ़ेक्ट्स को प्राप्त करता है।
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**उदाहरण 2: सभी एनिमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं**

यदि सामान्य स्लाइड पर कोई आकार ऐसे प्लेसहोल्डर रखता है जो लेआउट स्लाइड और/या मास्टर स्लाइड पर हैं, और इन प्लेसहोल्डर पर एनिमेशन इफ़ेक्ट्स जोड़े गए हैं, तो स्लाइड शो के दौरान आकार के सभी इफ़ेक्ट्स चलेंगे, जिसमें प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

मान लीजिए हमारे पास एक PowerPoint प्रस्तुति फ़ाइल `sample.pptx` है जिसमें एक ही स्लाइड पर केवल एक फुटर आकार है, जिसमें टेक्स्ट "Made with Aspose.Slides" है और उस आकार पर **Random Bars** इफ़ेक्ट लागू किया गया है।

![स्लाइड आकार एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

मान लीजिए कि **Split** इफ़ेक्ट लेआउट स्लाइड पर फुटर प्लेसहोल्डर पर भी लागू किया गया है।

![लेआउट आकार एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

आखिरकार, **Fly In** इफ़ेक्ट मास्टर स्लाइड पर फुटर प्लेसहोल्डर पर लागू किया गया है।

![मास्टर आकार एनीमेशन इफ़ेक्ट](master-shape-animation.png)

निम्न नमूना कोड दिखाता है कि कैसे आप [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस की `getBasePlaceholder` विधि का उपयोग करके आकार प्लेसहोल्डर तक पहुँचें और फुटर आकार पर लागू एनीमेशन इफ़ेक्ट्स को प्राप्त करें, जिसमें लेआउट और मास्टर स्लाइड पर स्थित प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **एनिमेशन इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for Android via Java आपको एक एनिमेशन इफ़ेक्ट की टाइमिंग प्रॉपर्टीज़ बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पैन है:

![उदाहरण 1 छवि](shape-animation.png)

ये PowerPoint Timing और [Effect.Timing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IEffect#getTiming--) प्रॉपर्टीज़ के बीच के अनुरूप हैं:

- PowerPoint Timing **Start** ड्रॉप-डाउन सूची [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITiming#getTriggerType--) प्रॉपर्टी से मेल खाती है।
- PowerPoint Timing **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITiming#getDuration--) प्रॉपर्टी से मेल खाती है। एनीमेशन की अवधि (सेकंड में) वह कुल समय है जो एनीमेशन को एक चक्र पूरा करने में लगता है।
- PowerPoint Timing **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) प्रॉपर्टी से मेल खाती है।

Effect Timing प्रॉपर्टीज़ को बदलने का तरीका इस प्रकार है:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।
2. जिन्हें आपको चाहिए, उन [Effect.Timing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IEffect#getTiming--) प्रॉपर्टीज़ के नए मान सेट करें।
3. संशोधित PPTX फ़ाइल सहेजें।

यह Java कोड ऑपरेशन को दर्शाता है:

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टैंसिएट करता है।
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // स्लाइड की मुख्य क्रम (sequence) प्राप्त करता है।
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है।
    IEffect effect = sequence.get_Item(0);

    // इफ़ेक्ट का TriggerType बदलकर क्लिक पर शुरू होने के लिए करता है।
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // इफ़ेक्ट की अवधि बदलता है।
    effect.getTiming().setDuration(3f);

    // इफ़ेक्ट का TriggerDelayTime बदलता है।
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX फ़ाइल को डिस्क पर सहेजता है।
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एनीमेशन इफ़ेक्ट साउंड**

Aspose.Slides एनीमेशन इफ़ेक्ट्स में ध्वनियों के साथ काम करने के लिए निम्न प्रॉपर्टीज़ प्रदान करता है:

- [setSound(IAudio value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) - एनीमेशन इफ़ेक्ट में ध्वनि सेट करने के लिए।
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-) - पिछली ध्वनि को रोकने के लिए।

### **एक एनीमेशन इफ़ेक्ट साउंड जोड़ें**

यह Java कोड दिखाता है कि कैसे एक एनीमेशन इफ़ेक्ट साउंड जोड़ें और अगला इफ़ेक्ट शुरू होने पर उसे रोकें:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // प्रस्तुति ऑडियो संग्रह में ऑडियो जोड़ता है
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // स्लाइड की मुख्य क्रम (sequence) प्राप्त करता है।
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = sequence.get_Item(0);

    // इफ़ेक्ट को "No Sound" के लिए जांचता है
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // पहले इफ़ेक्ट के लिए ध्वनि जोड़ता है
        firstEffect.setSound(effectSound);
    }

    // स्लाइड की पहली इंटरैक्टिव क्रम (sequence) प्राप्त करता है।
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // इफ़ेक्ट का "Stop previous sound" फ्लैग सेट करता है
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **एक एनीमेशन इफ़ेक्ट साउंड निकालें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. इफ़ेक्ट्स की मुख्य क्रम (सीक्वेंस) प्राप्त करें। 
4. हर एनीमेशन इफ़ेक्ट में एम्बेडेड [setSound(IAudio value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) को निकालें।

यह Java कोड दिखाता है कि एनीमेशन इफ़ेक्ट में एम्बेडेड ध्वनि को कैसे निकाला जाए:

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टैंसिएट करता है।
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // स्लाइड की मुख्य क्रम (sequence) प्राप्त करता है।
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // प्रभाव ध्वनि को बाइट ऐरे में निकालता है
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एनिमेशन के बाद**

Aspose.Slides for Android via Java आपको एनीमेशन इफ़ेक्ट की After animation प्रॉपर्टी बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन इफ़ेक्ट पैन और विस्तारित मेनू है:

![उदाहरण 1 छवि](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप-डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) प्रॉपर्टी जो After animation प्रकार को दर्शाती है :
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#Color) प्रकार से मेल खाती है;
  * PowerPoint **Don't Dim** आइटम [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) प्रकार से मेल खाती है (डिफ़ॉल्ट After animation प्रकार);
  * PowerPoint **Hide After Animation** आइटम [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) प्रकार से मेल खाती है;
  * PowerPoint **Hide on Next Mouse Click** आइटम [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) प्रकार से मेल खाती है;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) प्रॉपर्टी जो After animation रंग स्वरूप को परिभाषित करती है। यह प्रॉपर्टी [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#Color) प्रकार के साथ मिलकर काम करती है। यदि आप प्रकार को अन्य में बदलते हैं, तो After animation रंग साफ़ हो जाएगा।

यह Java कोड दिखाता है कि After animation इफ़ेक्ट को कैसे बदला जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टैंसिएट करता है
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // after animation प्रकार को Color में बदलता है
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // after animation डिम रंग सेट करता है
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट एनीमेट करें**

Aspose.Slides एनीमेशन इफ़ेक्ट के *Animate text* ब्लॉक के साथ काम करने के लिए निम्न प्रॉपर्टीज़ प्रदान करता है:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) जो इफ़ेक्ट के एनीमेट टेक्स्ट प्रकार को दर्शाता है। Shape का टेक्स्ट एनीमेट किया जा सकता है:
  - सभी एक साथ ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) प्रकार)
  - शब्द द्वारा ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/animatetexttype/#ByWord) प्रकार)
  - अक्षर द्वारा ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/animatetexttype/#ByLetter) प्रकार)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) एनीमेटेड टेक्स्ट भागों (शब्द या अक्षर) के बीच देरी सेट करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत निर्दिष्ट करता है। नकारात्मक मान सेकंड में देरी निर्दिष्ट करता है।

Effect Animate text प्रॉपर्टीज़ को बदलने का तरीका इस प्रकार है:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।
2. [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/buildtype/#AsOneObject) मान पर [setBuildType(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) प्रॉपर्टी सेट करके *By Paragraphs* एनीमेशन मोड को बंद करें।
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) और [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) प्रॉपर्टीज़ के नए मान सेट करें।
4. संशोधित PPTX फ़ाइल सहेजें।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टैंसिएट करता है।
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // इफ़ेक्ट की टेक्स्ट एनीमेशन प्रकार को "As One Object" में बदलता है
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // इफ़ेक्ट के एनीमेट टेक्स्ट प्रकार को "By word" में बदलता है
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // शब्दों के बीच देरी को इफ़ेक्ट अवधि के 20% पर सेट करता है
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे सुनिश्चित करूँ कि वेब पर प्रस्तुति प्रकाशित करने पर एनीमेशन संरक्षित रहें?**

[Export to HTML5](/slides/hi/androidjava/export-to-html5/) और उन [options](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/) को सक्षम करें जो [shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [transition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) एनीमेशन के लिए जिम्मेदार हैं। साधारण HTML स्लाइड एनीमेशन नहीं चलाता, जबकि HTML5 करता है।

**आकारों के z-order (लेयर क्रम) को बदलने से एनीमेशन पर क्या प्रभाव पड़ता है?**

एनिमेशन और ड्राइंग क्रम स्वतंत्र होते हैं: एक इफ़ेक्ट प्रकट/गायब होने का टाइमिंग और प्रकार नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getZOrderPosition--) निर्धारित करता है कि क्या क्या को ढँकेगा। दृश्य परिणाम उनका संयोजन निर्धारित करता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides के effects-and-shapes मॉडल भी इसी तर्क का पालन करता है।)

**क्या कुछ प्रभावों के लिए एनीमेशन को वीडियो में बदलते समय सीमाएँ हैं?**

आम तौर पर, [animations are supported](/slides/hi/androidjava/convert-powerpoint-to-video/), लेकिन दुर्लभ मामलों या विशिष्ट प्रभावों को अलग तरह से रेंडर किया जा सकता है। यह अनुशंसा की जाती है कि आप उपयोग किए जाने वाले प्रभावों और लाइब्रेरी संस्करण के साथ परीक्षण करें।