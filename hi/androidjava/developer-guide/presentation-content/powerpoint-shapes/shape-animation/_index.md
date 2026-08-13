---
title: Android पर प्रस्तुतियों में आकार एनिमेशन लागू करें
linktitle: आकार एनिमेशन
type: docs
weight: 60
url: /hi/androidjava/shape-animation/
keywords:
- आकार
- एनिमेशन
- प्रभाव
- एनिमेटेड आकार
- एनिमेटेड पाठ
- एनिमेशन जोड़ें
- एनिमेशन प्राप्त करें
- एनिमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव ध्वनि
- एनिमेशन लागू करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "जाने कैसे Aspose.Slides for Android via Java के साथ PowerPoint प्रस्तुतियों में आकार एनिमेशन बनाएं और अनुकूलित करें। अलग दिखें!"
---
## **परिचय**

एनिमेशन दृश्य प्रभाव हैं जिन्हें पाठ, छवियों, आकारों, या [चार्ट](https://docs.aspose.com/slides/hi/androidjava/animated-charts/) पर लागू किया जा सकता है। ये प्रस्तुतियों या उनके घटकों को जीवन देते हैं।

## **प्रस्तुतियों में एनिमेशन का उपयोग क्यों करें?**

एनिमेशन का उपयोग करके आप  

* सूचना के प्रवाह को नियंत्रित करें  
* महत्वपूर्ण बिंदुओं पर जोर दें  
* अपने दर्शकों में रुचि या भागीदारी बढ़ाएँ  
* सामग्री को पढ़ना, समझना या प्रोसेस करना आसान बनाएं  
* अपने पाठकों या दर्शकों का ध्यान प्रस्तुति में महत्वपूर्ण भागों की ओर आकर्षित करें  

PowerPoint एनिमेशन और एनिमेशन प्रभावों के लिए कई विकल्प और उपकरण प्रदान करता है, जो **प्रवेश**, **निकास**, **जोर**, और **गति पथ** श्रेणियों में विभाजित हैं।  

## **Aspose.Slides में एनिमेशन**

* Aspose.Slides `Aspose.Slides.Animation` नेमस्पेस के तहत एनिमेशन के साथ काम करने के लिए आवश्यक क्लास और प्रकार प्रदान करता है,  
* Aspose.Slides **150 से अधिक एनिमेशन प्रभाव** [EffectType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttype) एनोमरेशन के तहत प्रदान करता है। ये प्रभाव मूल रूप से वही (या समतुल्य) प्रभाव हैं जो PowerPoint में उपयोग होते हैं।  

## **टेक्स्टबॉक्स पर एनिमेशन लागू करें**

Aspose.Slides for Android via Java आपको आकार में पाठ पर एनिमेशन लागू करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।  
2. उसके इंडेक्स के माध्यम से एक स्लाइड रेफ़रेंस प्राप्त करें।  
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape) जोड़ें।  
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) में टेक्स्ट जोड़ें।  
5. प्रभावों की मुख्य अनुक्रम प्राप्त करें।  
6. [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape) में एक एनिमेशन प्रभाव जोड़ें।  
7. `TextAnimation.BuildType` प्रॉपर्टी को `BuildType` एनोमरेशन के मान पर सेट करें।  
8. प्रेज़ेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दिखाता है कि कैसे `Fade` प्रभाव को AutoShape पर लागू करें और टेक्स्ट एनिमेशन को *By 1st Level Paragraphs* मान पर सेट करें:

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // नया AutoShape टेक्स्ट के साथ जोड़ता है
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    ISequence sequence = sld.getTimeline().getMainSequence();

    // आकार पर Fade एनिमेशन प्रभाव जोड़ता है
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // आकार के टेक्स्ट को 1st level पैराग्राफ़ के द्वारा एनीमेट करता है
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

टेक्स्ट पर एनिमेशन लागू करने के अलावा, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph) पर भी एनिमेशन लागू कर सकते हैं। देखें [**Animated Text**](/slides/hi/androidjava/animated-text/).

{{% /alert %}} 

## **PictureFrame पर एनिमेशन लागू करें**

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।  
2. उसके इंडेक्स के माध्यम से एक स्लाइड रेफ़रेंस प्राप्त करें।  
3. स्लाइड पर एक [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe) जोड़ें या प्राप्त करें।  
4. प्रभावों की मुख्य अनुक्रम प्राप्त करें।  
5. [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe) में एक एनिमेशन प्रभाव जोड़ें।  
6. प्रेज़ेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दिखाता है कि कैसे `Fly` प्रभाव को picture frame पर लागू करें:

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation();
try {
    // प्रस्तुति इमेज संग्रह में जोड़े जाने वाली छवि लोड करें
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड में चित्र फ्रेम जोड़ता है
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // चित्र फ्रेम पर बाएँ से फ्लाई एनिमेशन प्रभाव जोड़ता है
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape पर एनिमेशन लागू करें**

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।  
2. उसके इंडेक्स के माध्यम से एक स्लाइड रेफ़रेंस प्राप्त करें।  
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape) जोड़ें।  
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape) जोड़ें (जब इस ऑब्जेक्ट पर क्लिक किया जाता है, तो एनिमेशन चलता है)।  
5. Bevel आकार पर प्रभावों की एक अनुक्रम बनाएं।  
6. एक कस्टम `UserPath` बनाएं।  
7. `UserPath` पर जाने के लिए कमांड जोड़ें।  
8. प्रेज़ेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह Java कोड दिखाता है कि कैसे `PathFootball` (path football) प्रभाव को shape पर लागू करें:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // मौजूदा आकार के लिए प्रारंभ से PathFootball प्रभाव बनाता है।
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall एनीमेशन प्रभाव जोड़ता है
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // कुछ प्रकार का "button" बनाता है।
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // इस बटन के लिए प्रभावों की श्रृंखला बनाता है।
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // कस्टम यूज़र पाथ बनाता है। हमारे ऑब्जेक्ट को केवल बटन क्लिक होने के बाद ही ले जाया जाएगा।
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // चलाने के लिए कमांड जोड़ता है क्योंकि बनाया गया पाथ खाली है।
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

## **एक आकार पर लागू किए गए एनिमेशन प्रभाव प्राप्त करें**

निम्नलिखित उदाहरण दिखाते हैं कि कैसे आप [ISequence](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/) इंटरफ़ेस की `getEffectsByShape` मेथड का उपयोग करके किसी आकार पर लागू सभी एनिमेशन प्रभाव प्राप्त कर सकते हैं।

**उदाहरण 1: सामान्य स्लाइड पर किसी आकार पर लागू एनिमेशन प्रभाव प्राप्त करें**

पहले, आपने PowerPoint प्रस्तुतियों में आकारों पर एनिमेशन प्रभाव जोड़ना सीख लिया था। निम्नलिखित सैंपल कोड दिखाता है कि कैसे `AnimExample_out.pptx` प्रस्तुति की पहली सामान्य स्लाइड में पहले आकार पर लागू प्रभाव प्राप्त करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // स्लाइड की मुख्य एनिमेशन अनुक्रम प्राप्त करता है।
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // पहली स्लाइड पर पहला आकार प्राप्त करता है।
    IShape shape = firstSlide.getShapes().get_Item(0);

    // आकार पर लागू एनिमेशन प्रभाव प्राप्त करता है।
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**उदाहरण 2: सभी एनिमेशन प्रभाव प्राप्त करें, जिसमें प्लेसहोल्डर से विरासत में मिले प्रभाव भी शामिल हैं**

यदि सामान्य स्लाइड पर कोई आकार लेआउट स्लाइड और/या मास्टर स्लाइड पर मौजूद प्लेसहोल्डर रखता है, और इन प्लेसहोल्डरों में एनिमेशन प्रभाव जोड़े गए हैं, तो स्लाइड शो के दौरान आकार के सभी प्रभाव चलाए जाएंगे, जिसमें प्लेसहोल्डर से विरासत में मिले प्रभाव भी शामिल हैं।

मान लीजिए हमारे पास एक PowerPoint प्रस्तुति फ़ाइल `sample.pptx` है जिसमें एक ही स्लाइड है, जिसमें केवल फुटर आकार है जिसमें टेक्स्ट "Made with Aspose.Slides" है और **Random Bars** प्रभाव उस आकार पर लागू है।

![स्लाइड आकार एनिमेशन प्रभाव](slide-shape-animation.png)

मान लीजिए **Split** प्रभाव लेआउट स्लाइड पर फुटर प्लेसहोल्डर पर लागू है।

![लेआउट आकार एनिमेशन प्रभाव](layout-shape-animation.png)

और अंत में, **Fly In** प्रभाव मास्टर स्लाइड पर फुटर प्लेसहोल्डर पर लागू है।

![मास्टर आकार एनिमेशन प्रभाव](master-shape-animation.png)

निम्नलिखित सैंपल कोड दिखाता है कि कैसे [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस की `getBasePlaceholder` मेथड का उपयोग करके आकार प्लेसहोल्डर्स तक पहुंचें और फुटर आकार पर लागू एनिमेशन प्रभाव प्राप्त करें, जिसमें लेआउट और मास्टर स्लाइड पर स्थित प्लेसहोल्डर्स से विरासत में मिले प्रभाव भी शामिल हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// सामान्य स्लाइड पर आकार के एनीमेशन प्रभाव प्राप्त करें।
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// लेआउट स्लाइड पर प्लेसहोल्डर के एनीमेशन प्रभाव प्राप्त करें।
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// मास्टर स्लाइड पर प्लेसहोल्डर के एनीमेशन प्रभाव प्राप्त करें।
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

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **एनिमेशन प्रभाव टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for Android via Java आपको एक एनिमेशन प्रभाव की टाइमिंग प्रॉपर्टीज़ बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पैन है:

![उदाहरण1_छवि](shape-animation.png)

ये PowerPoint टाइमिंग और [Effect.Timing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IEffect#getTiming--) प्रॉपर्टीज़ के बीच के समानताएँ हैं:

- PowerPoint टाइमिंग **Start** ड्रॉप-डाउन सूची [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITiming#getTriggerType--) प्रॉपर्टी से मेल खाती है।  
- PowerPoint टाइमिंग **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITiming#getDuration--) प्रॉपर्टी से मेल खाती है। एनिमेशन की अवधि (सेकंड में) वह कुल समय है जो एनिमेशन को एक चक्र पूर्ण करने में लेता है।  
- PowerPoint टाइमिंग **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) प्रॉपर्टी से मेल खाती है।  

यहां बताया गया है कि आप Effect Timing प्रॉपर्टीज़ कैसे बदल सकते हैं:

1. [Apply](#apply-animation-to-shape) या एनिमेशन प्रभाव प्राप्त करें।  
2. आवश्यक [Effect.Timing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IEffect#getTiming--) प्रॉपर्टीज़ के लिए नए मान सेट करें।  
3. संशोधित PPTX फ़ाइल को सहेजें।  

यह Java कोड ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // मुख्य अनुक्रम का पहला प्रभाव प्राप्त करता है।
    IEffect effect = sequence.get_Item(0);

    // प्रभाव का TriggerType बदलकर क्लिक पर शुरू होने के लिए सेट करता है
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // प्रभाव की अवधि बदलता है
    effect.getTiming().setDuration(3f);

    // प्रभाव का TriggerDelayTime बदलता है
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एनिमेशन प्रभाव ध्वनि**

Aspose.Slides इन प्रॉपर्टीज़ को प्रदान करता है जिससे आप एनिमेशन प्रभावों में ध्वनि के साथ काम कर सकते हैं: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **एनिमेशन प्रभाव ध्वनि जोड़ें**

यह Java कोड दिखाता है कि कैसे एनिमेशन प्रभाव ध्वनि जोड़ें और अगले प्रभाव के शुरू होने पर उसे रोकें:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // प्रस्तुति ऑडियो संग्रह में ऑडियो जोड़ता है
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // मुख्य अनुक्रम का पहला प्रभाव प्राप्त करता है
    IEffect firstEffect = sequence.get_Item(0);

    // प्रभाव के लिए "No Sound" जांचता है
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // पहले प्रभाव के लिए ध्वनि जोड़ता है
        firstEffect.setSound(effectSound);
    }

    // स्लाइड का पहला इंटरैक्टिव अनुक्रम प्राप्त करता है।
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // प्रभाव का "Stop previous sound" फ़्लैग सेट करता है
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **एनिमेशन प्रभाव ध्वनि निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रभावों की मुख्य अनुक्रम प्राप्त करें।  
4. प्रत्येक एनिमेशन प्रभाव में एंबेडेड [setSound(IAudio value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) निकालें।  

यह Java कोड दिखाता है कि कैसे एनिमेशन प्रभाव में एंबेडेड ध्वनि को निकाला जाए:

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // प्रभाव ध्वनि को बाइट एरे में निकालता है
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एनीमेशन के बाद**

Aspose.Slides for Android via Java आपको एनिमेशन प्रभाव की After animation प्रॉपर्टी बदलने की अनुमति देता है।

यह Microsoft PowerPoint में Animation Effect पैन और विस्तारित मेनू है:

![उदाहरण1_छवि](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप-डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) प्रॉपर्टी जो After animation प्रकार को वर्णित करती है:
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#Color) प्रकार से मेल खाता है;  
  * PowerPoint **Don't Dim** आइटम [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) प्रकार से मेल खाता है (डिफ़ॉल्ट after animation प्रकार);  
  * PowerPoint **Hide After Animation** आइटम [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) प्रकार से मेल खाता है;  
  * PowerPoint **Hide on Next Mouse Click** आइटम [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) प्रकार से मेल खाता है;  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) प्रॉपर्टी जो after animation रंग फ़ॉर्मेट को परिभाषित करती है। यह प्रॉपर्टी [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#Color) प्रकार के साथ मिलकर काम करती है। यदि आप प्रकार को बदलते हैं, तो after animation रंग साफ़ हो जाएगा।  

यह Java कोड दिखाता है कि कैसे after animation प्रभाव बदलें:

```java
import com.aspose.slides.*;
import java.awt.Color;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // मुख्य अनुक्रम का पहला प्रभाव प्राप्त करता है
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

## **टेक्स्ट को एनीमेट करें**

Aspose.Slides ये प्रॉपर्टीज़ प्रदान करता है जिससे आप एक एनिमेशन प्रभाव के *Animate text* ब्लॉक के साथ काम कर सकते हैं:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) जो प्रभाव के animate text प्रकार को वर्णित करता है। आकार का टेक्स्ट एनीमेट किया जा सकता है:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) प्रकार)  
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/animatetexttype/#ByWord) प्रकार)  
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/animatetexttype/#ByLetter) प्रकार)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) एनीमेटेड टेक्स्ट भागों (शब्दों या अक्षरों) के बीच देरी सेट करता है। सकारात्मक मान प्रभाव अवधि का प्रतिशत दर्शाता है। नकारात्मक मान सेकंड में देरी दर्शाता है।  

यहां बताया गया है कि आप Effect Animate text प्रॉपर्टीज़ कैसे बदल सकते हैं:

1. [Apply](#apply-animation-to-shape) या एनिमेशन प्रभाव प्राप्त करें।  
2. [setBuildType(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) प्रॉपर्टी को [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/buildtype/#AsOneObject) मान पर सेट करें ताकि *By Paragraphs* एनीमेशन मोड बंद हो जाए।  
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) और [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) प्रॉपर्टीज़ के नए मान सेट करें।  
4. संशोधित PPTX फ़ाइल को सहेजें।  

यह Java कोड ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // मुख्य अनुक्रम का पहला प्रभाव प्राप्त करता है
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // प्रभाव के टेक्स्ट एनीमेशन प्रकार को "As One Object" में बदलता है
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // प्रभाव के Animate text प्रकार को "By word" में बदलता है
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // शब्दों के बीच देरी को प्रभाव अवधि के 20% पर सेट करता है
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### मैं कैसे सुनिश्चित करूं कि प्रस्तुति को वेब पर प्रकाशित करने पर एनिमेशन सुरक्षित रहें?

[Export to HTML5](/slides/hi/androidjava/export-to-html5/) और वह [options](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/) सक्षम करें जो [shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [transition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) एनिमेशन के जिम्मेदार हैं। साधारण HTML स्लाइड एनिमेशन नहीं चलाता, जबकि HTML5 करता है।

### आकारों के z-ऑर्डर (लेयर ऑर्डर) को बदलने से एनिमेशन पर क्या प्रभाव पड़ता है?

एनिमेशन और ड्राइंग क्रम स्वतंत्र होते हैं: एक प्रभाव प्रकट/गायब होने की टाइमिंग और प्रकार को नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getZOrderPosition--) यह निर्धारित करता है कि क्या क्या को कवर करता है। दृश्य परिणाम उनके संयोजन से निर्धारित होता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides के प्रभाव-और-आकार मॉडल भी यही तर्क अपनाता है।)

### क्या कुछ प्रभावों के लिए एनिमेशन को वीडियो में बदलते समय सीमाएँ हैं?

सामान्यतः, [एनिमेशन समर्थित हैं](/slides/hi/androidjava/convert-powerpoint-to-video/), लेकिन दुर्लभ मामलों या विशिष्ट प्रभावों को अलग तरीके से रेंडर किया जा सकता है। यह सलाह दी जाती है कि आप अपने उपयोग किए गए प्रभावों और लाइब्रेरी संस्करण के साथ परीक्षण करें।