---
title: Java का उपयोग करके प्रस्तुतियों में आकार एनीमेशन लागू करें
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
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में आकार एनीमेशन बनाने और अनुकूलित करने के तरीके जानें। अलग दिखें!"
---
## **परिचय**

एनीमेशन दृश्य प्रभाव होते हैं जिन्हें पाठ, चित्र, आकार, या [चार्ट](https://docs.aspose.com/slides/hi/java/animated-charts/) पर लागू किया जा सकता है। वे प्रस्तुतियों या उनके घटकों को जीवंत बनाते हैं। 

## **प्रस्तुति में एनीमेशन का उपयोग क्यों करें?**

एनीमेशन का उपयोग करके आप 

* सूचना प्रवाह को नियंत्रित करें
* महत्वपूर्ण बिंदुओं पर ज़ोर दें
* अपने दर्शकों में रुचि या भागीदारी बढ़ाएँ
* सामग्री को पढ़ने, समझने या प्रक्रिया करने में आसान बनाएँ
* पाठकों या दर्शकों का ध्यान प्रस्तुति के महत्वपूर्ण भागों की ओर आकर्षित करें

PowerPoint एनीमेशन और एनीमेशन इफ़ेक्ट्स के लिए कई विकल्प और टूल प्रदान करता है, जो **प्रवेश**, **निर्गमन**, **जोर**, और **गति पथ** श्रेणियों में होते हैं। 

## **Aspose.Slides में एनीमेशन**

* Aspose.Slides `Aspose.Slides.Animation` नेमस्पेस के तहत एनीमेशन के साथ काम करने के लिए आवश्यक क्लासेस और प्रकार प्रदान करता है,
* Aspose.Slides [EffectType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effecttype) एनोमरेशन में **150 से अधिक एनीमेशन इफ़ेक्ट्स** प्रदान करता है। ये इफ़ेक्ट्स मूलतः वही (या समकक्ष) इफ़ेक्ट्स हैं जो PowerPoint में उपयोग होते हैं।

## **टेक्स्टबॉक्स पर एनीमेशन लागू करें**

Aspose.Slides for Java आपको आकार में पाठ पर एनीमेशन लागू करने की अनुमति देता है। 

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. उसके सूचकांक के द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape) जोड़ें। 
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) में पाठ जोड़ें।
5. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें।
6. [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape) पर एक एनीमेशन इफ़ेक्ट जोड़ें। 
7. `TextAnimation.BuildType` प्रॉपर्टी को `BuildType` एनोमरेशन के मान पर सेट करें।
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दर्शाता है कि कैसे `Fade` इफ़ेक्ट को AutoShape पर लागू किया जाए और टेक्स्ट एनीमेशन को *By 1st Level Paragraphs* मान पर सेट किया जाए:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // पाठ के साथ नया AutoShape जोड़ता है
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = sld.getTimeline().getMainSequence();

    // shape पर Fade एनीमेशन इफ़ेक्ट जोड़ता है
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // shape के पाठ को 1st स्तर पैराग्राफ़ द्वारा एनीमेट करता है
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

पाठ पर एनीमेशन लागू करने के अलावा, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph) पर भी एनीमेशन लागू कर सकते हैं। देखें [**एनिमेटेड टेक्स्ट**](/slides/hi/java/animated-text/).

{{% /alert %}} 

## **PictureFrame पर एनीमेशन लागू करें**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. उसके सूचकांक द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड पर एक [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe) जोड़ें या प्राप्त करें। 
4. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें।
5. [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe) पर एनीमेशन इफ़ेक्ट जोड़ें।
6. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दर्शाता है कि कैसे `Fly` इफ़ेक्ट को एक picture frame पर लागू किया जाए:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation();
try {
    // प्रस्तुति की इमेज कलेक्शन में जोड़ने के लिये इमेज लोड करता है
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड में पिक्चर फ्रेम जोड़ता है
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // पिक्चर फ्रेम में बाएँ से Fly एनीमेशन इफ़ेक्ट जोड़ता है
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape पर एनीमेशन लागू करें**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. उसके सूचकांक द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape) जोड़ें। 
4. एक `Bevel` [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape) जोड़ें (जब इस वस्तु पर क्लिक किया जाता है, एनीमेशन चलाया जाता है)।
5. Bevel आकार पर इफ़ेक्ट्स की क्रम बनाएँ।
6. एक कस्टम `UserPath` बनाएँ।
7. `UserPath` पर जाने के लिए कमांड जोड़ें।
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

यह Java कोड दर्शाता है कि कैसे `PathFootball` (पाथ फुटबॉल) इफ़ेक्ट को एक shape पर लागू किया जाए:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // मौजूदा shape के लिए शून्य से PathFootball इफ़ेक्ट बनाता है।
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // किसी प्रकार का "बटन" बनाता है।
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // इस बटन के लिए इफ़ेक्ट्स का क्रम बनाता है।
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // एक कस्टम उपयोगकर्ता पथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक करने के बाद ही स्थानांतरित होगा।
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // बनाए गए पथ के खाली होने के कारण स्थानांतरण के लिए कमांड जोड़ता है।
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

निम्नलिखित उदाहरण दर्शाते हैं कि कैसे [ISequence](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/) इंटरफ़ेस की `getEffectsByShape` विधि का उपयोग करके एक shape पर लागू सभी एनीमेशन इफ़ेक्ट्स प्राप्त किए जा सकते हैं।

**उदाहरण 1: सामान्य स्लाइड पर shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

पहले, आपने PowerPoint प्रस्तुतियों में shapes पर एनीमेशन इफ़ेक्ट्स जोड़ना सीखा था। निम्नलिखित नमूना कोड दर्शाता है कि कैसे प्रस्तुति `AnimExample_out.pptx` की पहली सामान्य स्लाइड में पहली shape पर लागू इफ़ेक्ट्स प्राप्त किए जाएँ।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // स्लाइड की मुख्य एनीमेशन क्रम प्राप्त करता है।
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // पहली स्लाइड पर पहला shape प्राप्त करता है।
    IShape shape = firstSlide.getShapes().get_Item(0);

    // shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करता है।
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**उदाहरण 2: सभी एनीमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें प्लेसहोल्डर्स से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं**

यदि किसी सामान्य स्लाइड पर कोई shape ऐसे प्लेसहोल्डर्स रखता है जो लेआउट स्लाइड और/या मास्टर स्लाइड पर हों, और इन प्लेसहोल्डर्स पर एनीमेशन इफ़ेक्ट्स जोड़ दिए गए हों, तो स्लाइड शो के दौरान shape के सभी इफ़ेक्ट्स चलाए जाएंगे, जिसमें प्लेसहोल्डर्स से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

मान लें कि हमारे पास एक PowerPoint प्रस्तुति फ़ाइल `sample.pptx` है जिसमें एक स्लाइड है जिसमें केवल एक फुटर shape है, जिसमें पाठ "Made with Aspose.Slides" है और shape पर **Random Bars** इफ़ेक्ट लागू है।

![Slide shape animation effect](slide-shape-animation.png)

मान लें कि **Split** इफ़ेक्ट लेआउट स्लाइड के फुटर प्लेसहोल्डर पर लागू है।

![Layout shape animation effect](layout-shape-animation.png)

और अंत में, **Fly In** इफ़ेक्ट मास्टर स्लाइड के फुटर प्लेसहोल्डर पर लागू है।

![Master shape animation effect](master-shape-animation.png)

निम्नलिखित नमूना कोड दर्शाता है कि कैसे [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) इंटरफ़ेस की `getBasePlaceholder` विधि का उपयोग करके shape प्लेसहोल्डर्स तक पहुँच कर फुटर shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त किए जाएँ, जिसमें लेआउट और मास्टर स्लाइड्स पर स्थित प्लेसहोल्डर्स से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// सामान्य स्लाइड पर shape के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// लेआउट स्लाइड पर placeholder के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// मास्टर स्लाइड पर placeholder के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **एनीमेशन इफ़ेक्ट टाइमिंग गुण बदलें**

Aspose.Slides for Java आपको एनीमेशन इफ़ेक्ट की Timing गुण बदलने की अनुमति देता है।

यह Microsoft PowerPoint में Animation Timing पेन है:

![example1_image](shape-animation.png)

- PowerPoint Timing **Start** ड्रॉप-डाउन सूची [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITiming#getTriggerType--) प्रॉपर्टी से मिलती है। 
- PowerPoint Timing **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITiming#getDuration--) प्रॉपर्टी से मिलती है। एनीमेशन की अवधि (सेकंड में) वह कुल समय है जो एनीमेशन को एक चक्र पूरा करने में लेता है। 
- PowerPoint Timing **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITiming#getTriggerDelayTime--) प्रॉपर्टी से मिलती है। 

Effect Timing गुण बदलने का तरीका यह है:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।
2. जिस [Effect.Timing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IEffect#getTiming--) प्रॉपर्टी की आपको आवश्यकता है, उसके लिए नए मान सेट करें। 
3. संशोधित PPTX फ़ाइल को सहेजें।

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है।
    IEffect effect = sequence.get_Item(0);

    // इफ़ेक्ट का TriggerType बदलकर क्लिक पर शुरू होने के लिए सेट करता है
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // इफ़ेक्ट की Duration बदलता है
    effect.getTiming().setDuration(3f);

    // इफ़ेक्ट का TriggerDelayTime बदलता है
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एनीमेशन इफ़ेक्ट ध्वनि**

Aspose.Slides एनीमेशन इफ़ेक्ट्स में ध्वनि के साथ काम करने के लिए निम्न प्रॉपर्टीज़ प्रदान करता है: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **एनीमेशन इफ़ेक्ट ध्वनि जोड़ें**

यह Java कोड दर्शाता है कि कैसे एनीमेशन इफ़ेक्ट ध्वनि जोड़ी जाए और अगले इफ़ेक्ट के शुरू होने पर उसे बंद किया जाए:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // प्रस्तुति ऑडियो संग्रह में ऑडियो जोड़ता है
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = sequence.get_Item(0);

    // इफ़ेक्ट को "No Sound" के लिए जाँचता है
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // पहले इफ़ेक्ट के लिए ध्वनि जोड़ता है
        firstEffect.setSound(effectSound);
    }

    // स्लाइड की पहली इंटरैक्टिव क्रम प्राप्त करता है।
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // इफ़ेक्ट "Stop previous sound" फ़्लैग सेट करता है
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **एनीमेशन इफ़ेक्ट ध्वनि निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. उसके सूचकांक द्वारा स्लाइड का संदर्भ प्राप्त करें। 
3. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें। 
4. प्रत्येक एनीमेशन इफ़ेक्ट में एम्बेडेड [setSound(IAudio value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) निकालें। 

यह Java कोड दर्शाता है कि कैसे एनीमेशन इफ़ेक्ट में एम्बेडेड ध्वनि निकाली जाए:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // इफ़ेक्ट ध्वनि को बाइट एरे में निकालता है
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एनीमेशन के बाद**

Aspose.Slides for Java आपको एनीमेशन इफ़ेक्ट की After animation प्रॉपर्टी बदलने की अनुमति देता है।

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप-डौन सूची निम्न प्रॉपर्टीज़ से मिलती है: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) प्रॉपर्टी जो After animation प्रकार को वर्णित करती है :
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#Color) प्रकार से मेल खाता है;
  * PowerPoint **Don't Dim** सूची वस्तु [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#DoNotDim) प्रकार से मेल खाती है (डिफ़ॉल्ट after animation प्रकार);
  * PowerPoint **Hide After Animation** वस्तु [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) प्रकार से मेल खाती है;
  * PowerPoint **Hide on Next Mouse Click** वस्तु [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) प्रकार से मेल खाती है;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) प्रॉपर्टी जो after animation रंग प्रारूप निर्धारित करती है। यह प्रॉपर्टी [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#Color) प्रकार के साथ मिलकर काम करती है। यदि आप प्रकार को अन्य में बदलते हैं, तो after animation रंग साफ़ हो जाएगा।

```java
import com.aspose.slides.*;
import java.awt.Color;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
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

Aspose.Slides आपको एक एनीमेशन इफ़ेक्ट के *Animate text* ब्लॉक के साथ काम करने के लिए निम्न प्रॉपर्टीज़ प्रदान करता है:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) जो इफ़ेक्ट के animate text प्रकार को वर्णित करता है। shape का पाठ एनीमेट किया जा सकता है:
  - एक साथ ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hi/java/com.aspose.slides/animatetexttype/#AllAtOnce) प्रकार)
  - शब्द द्वारा ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hi/java/com.aspose.slides/animatetexttype/#ByWord) प्रकार)
  - अक्षर द्वारा ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/animatetexttype/#ByLetter) प्रकार)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) एनीमेटेड टेक्स्ट भागों (शब्द या अक्षर) के बीच विलंब सेट करता है। सकारात्मक मान प्रभाव अवधि का प्रतिशत दर्शाता है। नकारात्मक मान सेकंड में विलंब दर्शाता है।

Effect Animate text प्रॉपर्टीज़ बदलने का तरीका यह है:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।
2. [setBuildType(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextanimation/#setBuildType-int-) प्रॉपर्टी को [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/buildtype/#AsOneObject) मान पर सेट करें ताकि *By Paragraphs* एनीमेशन मोड बंद हो जाए।
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) और [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) प्रॉपर्टीज़ के लिए नए मान सेट करें।
4. संशोधित PPTX फ़ाइल को सहेजें।

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // इफ़ेक्ट के टेक्स्ट एनीमेशन प्रकार को "As One Object" में बदलता है
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // इफ़ेक्ट के Animate टेक्स्ट प्रकार को "By word" में बदलता है
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // शब्दों के बीच देरी को इफ़ेक्ट अवधि के 20% पर सेट करता है
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### जब प्रस्तुति को वेब पर प्रकाशित किया जाता है तो एनीमेशन को सुरक्षित कैसे रखें?

[Export to HTML5](/slides/hi/java/export-to-html5/) और उन [options](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/) को सक्षम करें जो [shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [transition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) एनीमेशन के लिए जिम्मेदार हैं। साधारण HTML स्लाइड एनीमेशन नहीं चलाता, जबकि HTML5 करता है।

### आकारों के z-order (परत क्रम) को बदलने से एनीमेशन पर क्या प्रभाव पड़ता है?

एनीमेशन और ड्राइंग क्रम स्वतंत्र होते हैं: एक इफ़ेक्ट प्रकट/गायब होने के टाइमिंग और प्रकार को नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getZOrderPosition--) निर्धारित करता है कि क्या क्या ढँकेगा। दृश्य परिणाम उनका संयोजन तय करता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides के effects-and-shapes मॉडल भी उसी तर्क का पालन करता है।)

### कुछ इफ़ेक्ट्स के लिए एनीमेशन को वीडियो में परिवर्तित करने में क्या सीमाएँ हैं?

आम तौर पर, [एनीमेशन समर्थित हैं](/slides/hi/java/convert-powerpoint-to-video/), लेकिन दुर्लभ मामलों में या विशिष्ट इफ़ेक्ट्स के लिए अलग तरह से रेंडर हो सकते हैं। यह सलाह दी जाती है कि आप अपने उपयोग किए गए इफ़ेक्ट्स और लाइब्रेरी संस्करण के साथ परीक्षण करें।