---
title: जावा का उपयोग करके प्रस्तुतियों में आकार एनीमेशन लागू करें
linktitle: आकार एनीमेशन
type: docs
weight: 60
url: /hi/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में आकार एनीमेशन बनाना और अनुकूलित करना खोजें। अलग दिखें!"
---
## **परिचय**

एनिमेशन दृश्य प्रभाव हैं जिन्हें पाठ, चित्र, आकार, या [चार्ट](https://docs.aspose.com/slides/hi/java/animated-charts/) पर लागू किया जा सकता है। वे प्रस्तुतियों या उनके घटकों में जीवन डालते हैं।

## **प्रस्तुतियों में एनीमेशन का उपयोग क्यों करें?**

एनीमेशन का उपयोग करके आप  

* सूचना प्रवाह को नियंत्रित करें  
* महत्वपूर्ण बिंदुओं पर ज़ोर दें  
* अपने दर्शकों की रुचि या भागीदारी बढ़ाएँ  
* सामग्री को पढ़ने, समझने या प्रक्रिया करने में आसान बनाएं  
* अपने पाठकों या दर्शकों का ध्यान प्रस्तुति में महत्वपूर्ण भागों की ओर आकर्षित करें  

PowerPoint एनीमेशन और एनीमेशन इफ़ेक्ट्स के लिए **प्रवेश**, **निकास**, **जोर**, और **गति पथ** श्रेणियों में कई विकल्प और उपकरण प्रदान करता है।

## **Aspose.Slides में एनीमेशन**

* Aspose.Slides आपके लिए `Aspose.Slides.Animation` नेमस्पेस के अंतर्गत एनीमेशन के साथ काम करने के लिए आवश्यक क्लासेज़ और प्रकार प्रदान करता है,  
* Aspose.Slides [EffectType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effecttype) एन्ह्यूमरेशन के तहत **150 से अधिक एनीमेशन इफ़ेक्ट्स** प्रदान करता है। ये इफ़ेक्ट्स मूल रूप से वही (या समकक्ष) इफ़ेक्ट्स हैं जो PowerPoint में उपयोग होते हैं।

## **टेक्स्टबॉक्स पर एनीमेशन लागू करें**

Aspose.Slides for Java आपको आकार में टेक्स्ट पर एनीमेशन लागू करने की सुविधा देता है।  

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape) जोड़ें।  
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) में टेक्स्ट जोड़ें।  
5. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें।  
6. [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape) में एनीमेशन इफ़ेक्ट जोड़ें।  
7. `TextAnimation.BuildType` प्रॉपर्टी को `BuildType` एन्ह्यूमरेशन के मान पर सेट करें।  
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड आपको दिखाता है कि कैसे `Fade` इफ़ेक्ट को AutoShape पर लागू किया जाए और टेक्स्ट एनीमेशन को *By 1st Level Paragraphs* मान पर सेट किया जाए:

```java
// एक प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली प्रेज़ेंटेशन क्लास का इंस्टेंस बनाता है।
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // टे क्स्ट के साथ नया AutoShape जोड़ता है
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // स्लाइड की मुख्य अनुक्रम (सीक्वेंस) प्राप्त करता है।
    ISequence sequence = sld.getTimeline().getMainSequence();

    // shape में Fade एनीमेशन इफ़ेक्ट जोड़ता है
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // shape के टेक्स्ट को प्रथम स्तर के पैराग्राफ़ों द्वारा एनीमेट करता है
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

टेक्स्ट पर एनीमेशन लागू करने के अलावा, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph) पर भी एनीमेशन लागू कर सकते हैं। देखें [**Animated Text**](/slides/hi/java/animated-text/).

{{% /alert %}} 

## **PictureFrame पर एनीमेशन लागू करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
3. स्लाइड पर एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe) जोड़ें या प्राप्त करें।  
4. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें।  
5. [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe) में एनीमेशन इफ़ेक्ट जोड़ें।  
6. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दिखाता है कि कैसे `Fly` इफ़ेक्ट को एक picture frame पर लागू किया जाए:

```java
// एक प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली प्रेज़ेंटेशन क्लास का इंस्टेंस बनाता है।
Presentation pres = new Presentation();
try {
    // प्रेज़ेंटेशन इमेज कलेक्शन में जोड़ने के लिए इमेज लोड करता है
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड में पिक्चर फ्रेम जोड़ता है
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // स्लाइड की मुख्य अनुक्रम (सीक्वेंस) प्राप्त करता है।
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // पिक्चर फ्रेम में बाएँ से फ़्लाई एनीमेशन इफ़ेक्ट जोड़ता है
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape पर एनीमेशन लागू करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape) जोड़ें।  
4. एक `Bevel` [IAutoShape] जोड़ें (जब इस ऑब्जेक्ट पर क्लिक किया जाता है, तो एनीमेशन चलाया जाता है)।  
5. Bevel shape पर इफ़ेक्ट्स की श्रृंखला बनाएं।  
6. एक कस्टम `UserPath` बनाएं।  
7. `UserPath` पर जाने के लिए कमांड जोड़ें।  
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दिखाता है कि कैसे `PathFootball` (path football) इफ़ेक्ट को एक shape पर लागू किया जाए:

```java
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है।
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // मौजूदा shape के लिए शुरुआत से PathFootball इफ़ेक्ट बनाता है।
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // किसी प्रकार का "बटन" बनाता है।
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // इस बटन के लिए इफ़ेक्ट्स की एक श्रृंखला बनाता है।
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // एक कस्टम यूज़र पाथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक होने के बाद ही मूव होगा।
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // मूव करने के लिए कमांड जोड़ता है क्योंकि निर्मित पाथ खाली है।
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एक Shape पर लागू किए गए एनीमेशन इफ़ेक्ट्स प्राप्त करें**

निम्न उदाहरण दिखाते हैं कि कैसे आप [ISequence](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/) इंटरफ़ेस की `getEffectsByShape` मेथड का उपयोग करके किसी shape पर लागू सभी एनीमेशन इफ़ेक्ट्स प्राप्त कर सकते हैं।

**उदाहरण 1: सामान्य स्लाइड पर एक shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

पहले, आपने PowerPoint प्रस्तुतियों में shapes पर एनीमेशन इफ़ेक्ट्स जोड़ना सीखा था। निम्न नमूना कोड दिखाता है कि कैसे प्रस्तुति `AnimExample_out.pptx` की पहली सामान्य स्लाइड में पहले shape पर लागू इफ़ेक्ट्स प्राप्त किए जाएं।

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // स्लाइड की मुख्य एनीमेशन अनुक्रम प्राप्त करता है।
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // पहले स्लाइड पर पहला shape प्राप्त करता है।
    IShape shape = firstSlide.getShapes().get_Item(0);

    // shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करता है।
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**उदाहरण 2: सभी एनीमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें placeholders से विरासत में मिली इफ़ेक्ट्स भी शामिल हों**

यदि किसी सामान्य स्लाइड पर कोई shape ऐसे placeholders रखता है जो लेआउट स्लाइड या मास्टर स्लाइड पर हैं और उन placeholders पर एनीमेशन इफ़ेक्ट्स जोड़े गए हैं, तो स्लाइड शो के दौरान shape के सभी इफ़ेक्ट्स चलेंगे, जिनमें इन placeholders से विरासत में मिली इफ़ेक्ट्स भी शामिल होते हैं।

मान लीजिए हमारे पास एक PowerPoint प्रस्तुति फ़ाइल `sample.pptx` है जिसमें एक ही स्लाइड है जिसमें केवल एक फुटर shape है जिसका टेक्स्ट "Made with Aspose.Slides" है और **Random Bars** इफ़ेक्ट उस shape पर लागू है।

![स्लाइड shape एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

मान लीजिए कि **Layout** स्लाइड पर फुटर placeholder पर **Split** इफ़ेक्ट लागू है।

![लेआउट shape एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

और अंत में, **Master** स्लाइड पर फुटर placeholder पर **Fly In** इफ़ेक्ट लागू है।

![मास्टर shape एनीमेशन इफ़ेक्ट](master-shape-animation.png)

निम्न नमूना कोड दिखाता है कि कैसे आप [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) इंटरफ़ेस की `getBasePlaceholder` मेथड का उपयोग करके shape placeholders तक पहुँचें और फुटर shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें लेआउट और मास्टर स्लाइड पर स्थित placeholders से विरासत में मिली इफ़ेक्ट्स भी शामिल हैं।

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

## **एनीमेशन इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for Java आपको एनीमेशन इफ़ेक्ट की टाइमिंग प्रॉपर्टी बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पैन है:

![example1_image](shape-animation.png)

PowerPoint Timing और [Effect.Timing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IEffect#getTiming--) प्रॉपर्टीज़ के बीच ये मेल हैं:

- PowerPoint Timing **Start** ड्रॉप‑डाउन सूची [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITiming#getTriggerType--) प्रॉपर्टी से मेल खाती है।  
- PowerPoint Timing **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITiming#getDuration--) प्रॉपर्टी से मेल खाती है। एनीमेशन की अवधि (सेकंड में) वह कुल समय है जो इफ़ेक्ट को एक चक्र पूरा करने में लेता है।  
- PowerPoint Timing **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITiming#getTriggerDelayTime--) प्रॉपर्टी से मेल खाती है।  

यहाँ आप Effect Timing प्रॉपर्टीज़ कैसे बदलते हैं:

1. एनीमेशन इफ़ेक्ट लागू करें या प्राप्त करें।  
2. आवश्यक [Effect.Timing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IEffect#getTiming--) प्रॉपर्टीज़ के नए मान सेट करें।  
3. संशोधित PPTX फ़ाइल को सहेजें।  

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
// एक प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली प्रेज़ेंटेशन क्लास को इंस्टैंसिएट करता है।
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // स्लाइड की मुख्य अनुक्रम (सीक्वेंस) प्राप्त करता है।
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // मुख्य अनुक्रम के पहले इफ़ेक्ट को प्राप्त करता है।
    IEffect effect = sequence.get_Item(0);

    // इफ़ेक्ट का TriggerType बदलकर क्लिक पर शुरू करता है
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // इफ़ेक्ट की अवधि बदलता है
    effect.getTiming().setDuration(3f);

    // इफ़ेक्ट का TriggerDelayTime बदलता है
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एनीमेशन इफ़ेक्ट साउंड**

Aspose.Slides इन प्रॉपर्टीज़ को प्रदान करता है ताकि आप एनीमेशन इफ़ेक्ट्स में ध्वनियों के साथ काम कर सकें:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **एक एनीमेशन इफ़ेक्ट साउंड जोड़ें**

यह Java कोड दिखाता है कि कैसे एनीमेशन इफ़ेक्ट साउंड जोड़ें और अगले इफ़ेक्ट के शुरू होने पर उसे रोकें:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // प्रेज़ेंटेशन की ऑडियो कलेक्शन में ऑडियो जोड़ता है
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = sequence.get_Item(0);

    // इफ़ेक्ट को "No Sound" के लिए जांचता है
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // पहले इफ़ेक्ट के लिए साउंड जोड़ता है
        firstEffect.setSound(effectSound);
    }

    // स्लाइड की पहली इंटरैक्टिव अनुक्रम प्राप्त करता है।
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // इफ़ेक्ट "Stop previous sound" फ़्लैग सेट करता है
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **एक एनीमेशन इफ़ेक्ट साउंड निकालें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
3. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें।  
4. प्रत्येक एनीमेशन इफ़ेक्ट में एम्बेडेड [setSound(IAudio value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) को निकालें।  

यह Java कोड दिखाता है कि कैसे एनीमेशन इफ़ेक्ट में एम्बेडेड साउंड निकाला जाए:

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टैंसिएट करता है।
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // इफ़ेक्ट साउंड को बाइट एरे में निकालता है
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एनीमेशन के बाद**

Aspose.Slides for Java आपको एनीमेशन इफ़ेक्ट की After animation प्रॉपर्टी बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन इफ़ेक्ट पैन और विस्तारित मेनू है:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप‑डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) प्रॉपर्टी जो After animation प्रकार को वर्णित करती है :
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#Color) प्रकार से मेल खाती है;  
  * PowerPoint **Don't Dim** आइटम [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#DoNotDim) प्रकार से मेल खाता है (डिफ़ॉल्ट after animation प्रकार);  
  * PowerPoint **Hide After Animation** आइटम [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) प्रकार से मेल खाता है;  
  * PowerPoint **Hide on Next Mouse Click** आइटम [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) प्रकार से मेल खाता है;  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) प्रॉपर्टी जो after animation रंग प्रारूप को परिभाषित करती है। यह प्रॉपर्टी [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#Color) प्रकार के साथ मिलकर काम करती है। यदि आप प्रकार को किसी अन्य में बदलते हैं, तो after animation रंग साफ़ हो जाएगा।

यह Java कोड दिखाता है कि कैसे after animation इफ़ेक्ट बदला जाए:

```java
// एक प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली प्रेज़ेंटेशन क्लास को इंस्टैंसिएट करता है
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // मुख्य अनुक्रम के पहले इफ़ेक्ट को प्राप्त करता है
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // एनीमेशन के बाद प्रकार को Color में बदलता है
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // एनीमेशन के बाद डिम रंग को सेट करता है
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट एनीमेट करें**

Aspose.Slides इन प्रॉपर्टीज़ को प्रदान करता है ताकि आप एनीमेशन इफ़ेक्ट के *Animate text* ब्लॉक के साथ काम कर सकें:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) जो इफ़ेक्ट के एनीमेट टेक्स्ट प्रकार को वर्णित करता है। shape का टेक्स्ट एनीमेट किया जा सकता है :
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hi/java/com.aspose.slides/animatetexttype/#AllAtOnce) प्रकार)  
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hi/java/com.aspose.slides/animatetexttype/#ByWord) प्रकार)  
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/animatetexttype/#ByLetter) प्रकार)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) एनीमेटेड टेक्स्ट भागों (शब्द या अक्षर) के बीच देरी सेट करता है। सकारात्मक मान प्रभाव अवधि का प्रतिशत दर्शाता है। नकारात्मक मान सेकंड में देरी दर्शाता है।  

यहाँ आप Effect Animate text प्रॉपर्टीज़ कैसे बदल सकते हैं:

1. एनीमेशन इफ़ेक्ट लागू करें या प्राप्त करें।  
2. `setBuildType(int value)` प्रॉपर्टी को [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/buildtype/#AsOneObject) मान पर सेट करें ताकि *By Paragraphs* एनीमेशन मोड बंद हो जाए।  
3. नए मानों को [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) और [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) प्रॉपर्टीज़ में सेट करें।  
4. संशोधित PPTX फ़ाइल को सहेजें।  

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
// एक प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली प्रेज़ेंटेशन क्लास को इंस्टैंसिएट करता है।
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // इफ़ेक्ट के टेक्स्ट एनीमेशन प्रकार को "As One Object" में बदलता है
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // इफ़ेक्ट के Animate text प्रकार को "By word" में बदलता है
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

**मैं कैसे सुनिश्चित कर सकता हूँ कि वेब पर प्रस्तुति प्रकाशित करने पर एनीमेशन संरक्षित रहें?**

[Export to HTML5](/slides/hi/java/export-to-html5/) का उपयोग करें और उन [options](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/) को सक्षम करें जो shape और transition एनीमेशन के लिए जिम्मेदार हैं। साधारण HTML स्लाइड एनीमेशन नहीं चलाता, जबकि HTML5 करता है।

**shapes के z‑order (लेयर क्रम) को बदलने से एनीमेशन पर क्या प्रभाव पड़ता है?**

एनीमेशन और ड्रॉइंग क्रम स्वतंत्र होते हैं: एक इफ़ेक्ट प्रकट/गायब होने की टाइमिंग और प्रकार नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getZOrderPosition--) निर्धारित करता है कि क्या क्या को覆 (कवर) करता है। दृश्य परिणाम उनका संयोजन निर्धारित करता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides के effects‑and‑shapes मॉडल में भी वही लॉजिक लागू होता है।)

**क्या कुछ इफ़ेक्ट्स को वीडियो में बदलते समय सीमाएं हैं?**

सामान्यतः, [animations are supported](/slides/hi/java/convert-powerpoint-to-video/), लेकिन दुर्लभ मामलों या विशिष्ट इफ़ेक्ट्स को अलग तरह से रेंडर किया जा सकता है। यह अनुशंसा की जाती है कि आप उन इफ़ेक्ट्स के साथ परीक्षण करें जिन्हें आप उपयोग करते हैं और लाइब्रेरी के संस्करण के साथ।