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
description: "Aspose.Slides for Android via Java के साथ आकार एनीमेशन, टाइमिंग, ध्वनियों, आफ्टर‑एनीमेशन व्यवहार और एनिमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **अवलोकन**

एक प्रभाव के भीतर व्यक्तिगत व्यवहारों के साथ काम करने या मोशन‑पाथ सेगमेंट को संपादित करने के लिए, देखें [कस्टम एनिमेशन फॉर जावा](/slides/hi/java/custom-animation/)।

Aspose.Slides for Android via Java स्लाइड एनीमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट्स के रूप में दर्शाता है। एक इफ़ेक्ट में लक्ष्य आकार, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, और वैकल्पिक गुण जैसे साउंड या आफ्टर‑एनीमेशन व्यवहार होते हैं।

टाइमलाइन में दो प्रकार के अनुक्रम होते हैं:

- **मुख्य अनुक्रम** स्लाइड आगे बढ़ने पर चलता है।
- एक **इंटरैक्टिव अनुक्रम** तब शुरू होता है जब उसका ट्रिगर आकार क्लिक किया जाता है।

क्योंकि टेक्स्ट बॉक्स, चित्र, चार्ट, टेबल और अन्य स्लाइड ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) को लागू करते हैं, आप अधिकांश स्लाइड सामग्री के लिए वही [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) मेथड उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttype/) क्लास में सूचीबद्ध हैं।

## **आकार एनिमेशन जोड़ें**

एनिमेशन जोड़ने के लिए, स्लाइड के मुख्य अनुक्रम को प्राप्त करें और [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) को लक्ष्य आकार, इफ़ेक्ट प्रकार, उपप्रकार और ट्रिगर के साथ कॉल करें। किसी अन्य आकार के क्लिक होने पर शुरू होने वाले इफ़ेक्ट के लिए, एक इंटरैक्टिव अनुक्रम बनाएँ जिसका ट्रिगर वह अन्य आकार हो।

निम्नलिखित उदाहरण दोनों प्रकार का एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

ट्रिगर यह नियंत्रित करता है कि इफ़ेक्ट कब शुरू होता है:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttriggertype/#OnClick) मुख्य अनुक्रम में क्लिक या इंटरैक्टिव अनुक्रम में ट्रिगर आकार पर क्लिक की प्रतीक्षा करता है।
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) पिछले इफ़ेक्ट के साथ शुरू होता है।
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) जब पिछला इफ़ेक्ट समाप्त हो जाता है तब शुरू होता है।

चित्र, चार्ट या किसी अन्य आकार प्रकार को एनीमेट करने के लिए, `targetShape` के बजाय उस ऑब्जेक्ट को [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) में पास करें। चार्ट‑विशिष्ट समूह विकल्पों के लिए देखें [Animated Charts](/slides/hi/androidjava/animated-charts/)।

## **आकार एनिमेशन पढ़ें**

जब आप लक्ष्य आकार जानते हैं तो [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) का उपयोग करें। हर इफ़ेक्ट का निरीक्षण करने के लिए, मुख्य अनुक्रम और सभी इंटरैक्टिव अनुक्रमों को क्रमांकित करें। क्रमांकन यह मानने से बचाता है कि अनुक्रम में इंडेक्स `0` पर कोई इफ़ेक्ट मौजूद है।

निम्नलिखित उदाहरण मुख्य‑अनुक्रम और इंटरैक्टिव इफ़ेक्ट्स वाले एक आकार को बनाता है, आकार को लक्षित करने वाले इफ़ेक्ट्स प्राप्त करता है, और फिर स्लाइड पर हर अनुक्रम को क्रमांकित करता है।

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

यदि आपको केवल एक आकार के इफ़ेक्ट्स की आवश्यकता है, तो पहले आकार को नाम, प्लेसहोल्डर प्रकार या किसी अन्य स्थिर गुण से पहचानें; फिर [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) को कॉल करें। यह मानें नहीं कि इंडेक्स `0` पर [IShapeCollection.get_Item](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) हमेशा इच्छित ऑब्जेक्ट है।

## **विरासत में मिले प्लेसहोल्डर इफ़ेक्ट्स के साथ काम करें**

सामान्य स्लाइड पर एक प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर समान प्लेसहोल्डर से एनीमेशन व्यवहार विरासत में प्राप्त कर सकता है। [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) वह पेरेंट प्लेसहोल्डर लौटाता है, या जब कोई पेरेंट मौजूद न हो तो `null`।

निम्नलिखित उदाहरण प्रस्तुति में, फुटर के पास सामान्य स्लाइड पर **Random Bars**, लेआउट स्लाइड पर **Split**, और मास्टर स्लाइड पर **Fly In** है।

![सामान्य स्लाइड पर फुटर एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](master-shape-animation.png)

अगला उदाहरण एक नई प्रस्तुति से प्लेसहोल्डर पदानुक्रम का उपयोग करता है। यह एक मास्टर प्लेसहोल्डर, एक लेआउट प्लेसहोल्डर, और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में इफ़ेक्ट्स जोड़ता है। प्रत्येक कॉल के पहले [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) की जाँच की जाती है।

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **एनीमेशन टाइमिंग बदलें**

PowerPoint **Timing** डायलॉग [ITiming](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/) की प्रॉपर्टीज़ से मैप होता है।

![एनीमेशन इफ़ेक्ट के लिए पॉवरपॉइंट टाइमिंग डायलॉग](shape-animation.png)

- **Start** [ITiming.getTriggerType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getTriggerType--) से मैप होता है।
- **Duration** [ITiming.getDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getDuration--) से मैप होता है, सेकंड में।
- **Delay** [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) से मैप होता है, सेकंड में।
- **Repeat** [ITiming.getRepeatCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatCount--) , [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) या [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) से मैप होता है।
- **Rewind when done playing** [ITiming.getRewind](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRewind--) से मैप होता है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, टाइमिंग को [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से बदलता है, और परिणाम को सहेजता है। लौटाए गए [IEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/) रेफ़रेंस को रखते हुए अनावश्यक कॉलlektion इंडेक्स से बचा जाता है।

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

एक ही रिपीट मोड को इरादे से उपयोग करें। रिपीट काउंट को "until" फ़्लैग के साथ संयोजन करने से विभिन्न व्यूअर में भ्रमित करने वाले नतीजे मिल सकते हैं। रिपीट मोड बदलते समय, पहले [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) और [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) सेट करें, फिर [ITiming.setRepeatCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) सेट करें, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय रिपीट मोड भी बदल जाता है।

## **एनिमेशन साउंड जोड़ें और निकालें**

एक एनीमेशन इफ़ेक्ट एम्बेडेड ऑडियो को [IEffect.getSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getSound--) के माध्यम से संदर्भित कर सकता है। [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) इफ़ेक्ट को बताता है कि वह पहले के इफ़ेक्ट द्वारा शुरू किए गए ऑडियो को रोक दे।

### **इफ़ेक्ट में साउंड जोड़ें**

निम्नलिखित उदाहरण एक स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो इफ़ेक्ट बनाता है, पहली इफ़ेक्ट के साउंड के रूप में फ़ाइल को एम्बेड करता है, और दूसरे इफ़ेक्ट को साउंड को रोकने के लिए कॉन्फ़िगर करता है। यह [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) द्वारा लौटाए गए ऑब्जेक्ट्स का उपयोग करता है, इसलिए अनुक्रम इंडेक्स आवश्यक नहीं है।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **एम्बेडेड इफ़ेक्ट साउंड निकालें**

निम्नलिखित उदाहरण एक स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरैक्टिव दोनों अनुक्रमों को स्कैन करता है और प्रत्येक एम्बेडेड इफ़ेक्ट साउंड को `extracted-animation-sounds` डायरेक्टरी में लिखता है। एक्सटेंशन ऑडियो MIME प्रकार से चुना जाता है जो [IAudio.getContentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudio/#getContentType--) द्वारा उजागर किया जाता है।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

बड़ी ऑडियो वस्तुओं के लिए, [IAudio.getStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudio/#getStream--) का उपयोग करें और स्ट्रीम को फ़ाइल में कॉपी करें बजाय पूरी वस्तु को बाइट एरे में लोड करने के।

## **आफ़्टर-एनीमेशन व्यवहार सेट करें**

**After animation** विकल्प नियंत्रित करता है कि इफ़ेक्ट समाप्त होने के बाद आकार में क्या हो।

![आफ़्टर एनीमेशन सेटिंग्स दिखाने वाला पॉवरपॉइंट इफ़ेक्ट विकल्प डायलॉग](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/) क्लास आकार को अपरिवर्तित रखने, उसका रंग बदलने, एनीमेशन के बाद उसे छिपाने, या अगले क्लिक पर उसे छिपाने का समर्थन करता है। जब प्रकार [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#Color) हो, तो साथ ही [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) सेट करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, वापस मिले इफ़ेक्ट ऑब्जेक्ट के माध्यम से उसका आफ्टर‑एनीमेशन व्यवहार सेट करता है, और परिणाम को सहेजता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#Color) से प्रकार बदलने पर आफ्टर‑एनीमेशन रंग सेटिंग साफ़ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन में दो संबंधित नियंत्रण होते हैं:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextanimation/#getBuildType--) नियंत्रित करता है कि पैराग्राफ एक साथ दिखें या पैराग्राफ स्तर पर।
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) नियंत्रित करता है कि टेक्स्ट एक बार में, शब्द दर शब्द, या अक्षर दर अक्षर दिखाई दे। [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) शब्दों या अक्षरों के बीच देरी निर्धारित करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत होता है; नकारात्मक मान सेकंड में देरी होता है।

निम्नलिखित स्वतंत्र उदाहरण टेक्स्ट बॉक्स में शब्दों को एनीमेट करता है। [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/buildtype/#AsOneObject) पैराग्राफ‑दर‑पैराग्राफ निर्माण को निष्क्रिय करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

पैराग्राफ‑दर‑पैराग्राफ बॉक्स बनाने के लिए, [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (या कोई अन्य पैराग्राफ स्तर) सेट करें। किसी एकल पैराग्राफ को अपना प्रभाव देने के लिए, उस [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) ओवरलोड का उपयोग करें जो एक [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) को स्वीकार करता है। पैराग्राफ‑स्तर के उदाहरणों के लिए देखें [Animated Text](/slides/hi/androidjava/animated-text/)।

## **निर्यात और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल संरक्षित रहता है, लेकिन अंतिम चलाना प्रस्तुति व्यूअर द्वारा नियंत्रित होता है।
- PDF और स्थिर छवियों में एनीमेशन नहीं चलता। जब गति दिखाना आवश्यक हो तो [HTML5 export](/slides/hi/androidjava/export-to-html5/), एनीमेटेड GIF, या [video conversion](/slides/hi/androidjava/convert-powerpoint-to-video/) उपयोग करें।
- HTML5 के लिए, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) सक्षम करें और आवश्यकता पड़ने पर [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) सक्षम करें।
- वीडियो रेंडरिंग कई सामान्य प्रवेश, ज़ोर, निकास और मोशन‑पाथ इफ़ेक्ट्स को सपोर्ट करता है, लेकिन सभी PowerPoint इफ़ेक्ट्स समर्थित नहीं हैं। वर्तमान [supported animations and effects](/slides/hi/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और अपने लक्ष्य Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।
- उन्नत कस्टम इफ़ेक्ट्स और अन्य प्रस्तुति स्वरूपों से आयातित इफ़ेक्ट्स फ़ाइल में संरक्षित रह सकते हैं, लेकिन PowerPoint, HTML5, या वीडियो में अलग तरह से रेंडर हो सकते हैं। केवल इफ़ेक्ट नाम पर भरोसा करने के बजाय निर्यात परिणाम की पुष्टि करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में एनीमेशन दिखाई देती है लेकिन PDF में नहीं क्यों दिखती?**

PDF एक स्थिर स्वरूप है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलती। जब गति को बरकरार रखना हो तो HTML5, एनीमेटेड GIF या वीडियो में निर्यात करें।

**वीडियो में इफ़ेक्ट अलग तरह से क्यों चलता है?**

वीडियो निर्यात एनीमेशन को रेंडर करता है, मूल PowerPoint व्यवहार को नहीं संग्रहीत करता। कुछ उन्नत इफ़ेक्ट्स असमर्थित या अनुमानित होते हैं। समर्थित इफ़ेक्ट्स तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या आकार को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। आकार का z‑order ओवरलैप नियंत्रित करता है, जबकि अनुक्रम क्रम और ट्रिगर एनीमेशन प्लेबैक नियंत्रित करते हैं। अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलें।