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
- ऐनिमेटेड आकार
- ऐनिमेटेड टेक्स्ट
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
description: "Aspose.Slides for Java के साथ आकार एनीमेशन, टाइमिंग, ध्वनियों, एनीमेशन-के-बाद व्यवहार, और ऐनिमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Java स्लाइड एनीमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट्स के रूप में दर्शाता है। एक इफ़ेक्ट में लक्ष्य आकृति, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, तथा वैकल्पिक गुण जैसे ध्वनि या एनीमेशन‑के‑बाद का व्यवहार शामिल होता है।

टाइमलाइन दो प्रकार के अनुक्रम शामिल करता है:

- **मुख्य अनुक्रम** स्लाइड के आगे बढ़ने पर चलता है।
- **इंटरैक्टिव अनुक्रम** तब शुरू होता है जब उसका ट्रिगर आकार क्लिक किया जाता है।

चूँकि टेक्स्ट बॉक्स, चित्र, चार्ट, तालिकाएँ और अन्य स्लाइड ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) को लागू करते हैं, आप अधिकांश स्लाइड सामग्री के लिए वही [ISequence.addEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) मेथड उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effecttype/) क्लास में सूचीबद्ध हैं।

## **आकार एनीमेशन जोड़ें**

एनीमेशन जोड़ने के लिए स्लाइड के मुख्य अनुक्रम को प्राप्त करें और लक्ष्य आकृति, इफ़ेक्ट प्रकार, उपप्रकार, तथा ट्रिगर के साथ [ISequence.addEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) को कॉल करें। किसी इफ़ेक्ट को जब दूसरे आकार पर क्लिक करने पर शुरू करना हो, तो ऐसा इंटरैक्टिव अनुक्रम बनाएं जिसका ट्रिगर वह दूसरा आकार हो।

नीचे दिया गया उदाहरण दोनों प्रकार के एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effecttriggertype/#OnClick) मुख्य अनुक्रम में क्लिक या इंटरैक्टिव अनुक्रम में ट्रिगर आकार पर क्लिक की प्रतीक्षा करता है।
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effecttriggertype/#WithPrevious) पहले वाले इफ़ेक्ट के साथ शुरू होता है।
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effecttriggertype/#AfterPrevious) पहले वाले इफ़ेक्ट के समाप्त होने पर शुरू होता है।

चित्र, चार्ट या किसी अन्य आकार को एनीमेट करने के लिए `targetShape` के बजाय उस ऑब्जेक्ट को [ISequence.addEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) को पास करें। चार्ट‑विशिष्ट ग्रुपिंग विकल्पों के लिए देखें [Animated Charts](/slides/hi/java/animated-charts/)।

## **आकार एनीमेशन पढ़ें**

जब आप लक्ष्य आकार जानते हों तो [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) का उपयोग करें। सभी इफ़ेक्ट्स का निरीक्षण करने के लिए मुख्य अनुक्रम और प्रत्येक इंटरैक्टिव अनुक्रम को क्रमबद्ध करें। क्रमबद्ध करने से यह मानने से बचा जाता है कि अनुक्रम के इंडेक्स `0` पर हमेशा कोई इफ़ेक्ट मौजूद है।

नीचे दिया गया उदाहरण मुख्य‑अनुक्रम और इंटरैक्टिव इफ़ेक्ट्स वाले एक आकार को बनाता है, आकार को लक्षित करने वाले इफ़ेक्ट्स प्राप्त करता है, और फिर स्लाइड पर प्रत्येक अनुक्रम को क्रमबद्ध करता है।

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

यदि आपको केवल एक ही आकार के लिए इफ़ेक्ट्स चाहिए, तो पहले आकार को नाम, प्लेसहोल्डर प्रकार या किसी अन्य स्थिर प्रॉपर्टी से पहचानें; फिर [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) को कॉल करें। यह मान कर न चलें कि [IShapeCollection.get_Item](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#get_Item-int-) का इंडेक्स `0` हमेशा इच्छित ऑब्जेक्ट होता है।

## **विरासत में मिले प्लेसहोल्डर इफ़ेक्ट्स के साथ काम करें**

सामान्य स्लाइड पर एक प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर स्थित समान प्लेसहोल्डर से एनीमेशन व्यवहार को विरासत में ले सकता है। [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getBasePlaceholder--) वह पैरेंट प्लेसहोल्डर लौटाता है, या जब कोई पैरेंट न हो तो `null`।

निम्न उदाहरण प्रस्तुति में फ़ूटर में सामान्य स्लाइड पर **Random Bars**, लेआउट स्लाइड पर **Split**, और मास्टर स्लाइड पर **Fly In** हैं।

![सामान्य स्लाइड पर फ़ूटर एनीमेशन प्रभाव](slide-shape-animation.png)

![लेआउट स्लाइड पर फ़ूटर प्लेसहोल्डर एनीमेशन प्रभाव](layout-shape-animation.png)

![मास्टर स्लाइड पर फ़ूटर प्लेसहोल्डर एनीमेशन प्रभाव](master-shape-animation.png)

अगला उदाहरण नई प्रस्तुति से एक प्लेसहोल्डर पदानुक्रम का उपयोग करता है। यह मास्टर प्लेसहोल्डर, लेआउट प्लेसहोल्डर और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में इफ़ेक्ट्स जोड़ता है। प्रत्येक बार [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getBasePlaceholder--) को कॉल करने से पहले जाँच की जाती है।

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

PowerPoint **Timing** संवाद [ITiming](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/) की प्रॉपर्टीज़ से मेल खाता है।

![एनीमेशन इफ़ेक्ट के लिए PowerPoint Timing संवाद](shape-animation.png)

- **Start** को [ITiming.getTriggerType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getTriggerType--) से मैप किया जाता है।
- **Duration** को [ITiming.getDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getDuration--) से मैप किया जाता है, सेकंड में।
- **Delay** को [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getTriggerDelayTime--) से मैप किया जाता है, सेकंड में।
- **Repeat** को [ITiming.getRepeatCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getRepeatCount--) , [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) या [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) से मैप किया जाता है।
- **Rewind when done playing** को [ITiming.getRewind](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getRewind--) से मैप किया जाता है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, उसे [ISequence.addEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से उसका टाइमिंग बदलता है, और परिणाम को सहेजता है। लौटाए गए [IEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/) संदर्भ को रखना अनावश्यक कलेक्शन इंडेक्स से बचाता है।

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

एक ही रिपीट मोड का जानबूझकर उपयोग करें। एक रिपीट काउंट को “until” फ्लैग के साथ मिलाने से विभिन्न दर्शकों में भ्रमित करने वाले परिणाम मिल सकते हैं। रिपीट मोड बदलते समय पहले [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) और [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) सेट करें, फिर [ITiming.setRepeatCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#setRepeatCount-float-) को सेट करें, क्योंकि किसी भी फ्लैग को सेट करने से सक्रिय रिपीट मोड बदल जाता है।

## **एनीमेशन ध्वनियों को जोड़ें और निकालें**

एक एनीमेशन इफ़ेक्ट अंतर्निहित ऑडियो को [IEffect.getSound](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getSound--) के माध्यम से संदर्भित कर सकता है। [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) किसी इफ़ेक्ट को बताता है कि वह पहले के इफ़ेक्ट द्वारा शुरू की गई ध्वनि को रोक दे।

### **इफ़ेक्ट में ध्वनि जोड़ें**

नीचे दिया गया उदाहरण स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो इफ़ेक्ट बनाता है, पहली इफ़ेक्ट के लिए उस फ़ाइल को ध्वनि के रूप में एम्बेड करता है, और दूसरी इफ़ेक्ट को ध्वनि रोकने के लिए कॉन्फ़िगर करता है। यह [ISequence.addEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) द्वारा लौटाए गए ऑब्जेक्ट का उपयोग करता है, इसलिए अनुक्रम इंडेक्स की आवश्यकता नहीं होती।

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

### **एम्बेडेड इफ़ेक्ट ध्वनियों को निकालें**

नीचे दिया गया उदाहरण स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरैक्टिव दोनों अनुक्रमों को स्कैन करता है और प्रत्येक एम्बेडेड इफ़ेक्ट ध्वनि को `extracted-animation-sounds` निर्देशिका में लिखता है। एक्सटेंशन ऑडियो MIME टाइप से प्राप्त किया जाता है, जिसे [IAudio.getContentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudio/#getContentType--) के माध्यम से उपलब्ध कराया जाता है।

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

बड़ी ऑडियो ऑब्जेक्ट्स के लिए, पूरी ऑब्जेक्ट को बाइट एरे में लोड करने के बजाय [IAudio.getStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudio/#getStream--) का उपयोग करें और स्ट्रीम को फ़ाइल में कॉपी करें।

## **एनीमेशन‑के‑बाद व्यवहार सेट करें**

**After animation** विकल्प नियंत्रित करता है कि इफ़ेक्ट समाप्त होने के बाद आकार के साथ क्या होता है।

![After animation सेटिंग्स दिखाते हुए PowerPoint Effect Options संवाद](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/) क्लास आकार को अपरिवर्तित छोड़ने, उसका रंग बदलने, एनीमेशन के बाद छिपाने, या अगले क्लिक पर छिपाने का समर्थन करता है। जब प्रकार [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#Color) हो, तो साथ में [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) सेट करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, लौटाए गए इफ़ेक्ट ऑब्जेक्ट के माध्यम से उसके एनीमेशन‑के‑बाद व्यवहार को सेट करता है, और परिणाम को सहेजता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/afteranimationtype/#Color) से प्रकार बदलने पर एनीमेशन‑के‑बाद रंग सेटिंग साफ़ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन में दो संबंधित नियंत्रण हैं:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextanimation/#getBuildType--) यह निर्धारित करता है कि अनुच्छेद एक साथ दिखें या अनुच्छेद‑स्तर में।
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getAnimateTextType--) यह निर्धारित करता है कि टेक्स्ट एक बार में, शब्द‑दर‑शब्द या अक्षर‑दर‑अक्षर दिखे। [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) शब्दों या अक्षरों के बीच देरी सेट करता है। सकारात्मक मान प्रभाव अवधि का प्रतिशत होता है; नकारात्मक मान सेकंड में देरी का प्रतिनिधित्व करता है।

निम्न स्वतंत्र उदाहरण एक टेक्स्ट बॉक्स के शब्दों को एनीमेट करता है। [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/buildtype/#AsOneObject) पैराग्राफ‑दर‑पैराग्राफ निर्माण को निष्क्रिय करता है, जिससे शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू होती है।

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

पैराग्राफ‑दर‑पैराग्राफ बॉक्स बनाने के लिए, [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hi/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (या कोई अन्य पैराग्राफ‑स्तर) सेट करें। किसी एकल पैराग्राफ को उसका अपना इफ़ेक्ट देने के लिए, [ISequence.addEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) ओवरलोड का उपयोग करें जो [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) को स्वीकार करता है। पैराग्राफ‑स्तर के उदाहरणों के लिए देखें [Animated Text](/slides/hi/java/animated-text/)।

## **निर्यात और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल बना रहता है, लेकिन अंतिम प्लेबैक प्रस्तुति दर्शक द्वारा नियंत्रित होता है।
- PDF और स्थिर छवियों में एनीमेशन नहीं चलता। जब आउटपुट को गति दिखानी हो, तो [HTML5 export](/slides/hi/java/export-to-html5/), एनिमेटेड GIF, या [video conversion](/slides/hi/java/convert-powerpoint-to-video/) का उपयोग करें।
- HTML5 के लिए, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) सक्षम करें और आवश्यकता पड़ने पर [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को सेट करें।
- वीडियो रेंडरिंग कई सामान्य प्रवेश, ज़ोर, निकास, और मोशन‑पाथ इफ़ेक्ट्स को सपोर्ट करता है, लेकिन हर PowerPoint इफ़ेक्ट समर्थित नहीं है। वर्तमान [supported animations and effects](/slides/hi/java/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और अपने लक्ष्य Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।
- उन्नत कस्टम इफ़ेक्ट्स और अन्य प्रस्तुति स्वरूपों से आयात किए गए इफ़ेक्ट्स फ़ाइल में संरक्षित हो सकते हैं, लेकिन PowerPoint, HTML5, या वीडियो में अलग तरह से रेंडर हो सकते हैं। प्रभाव नाम पर केवल भरोसा न करके निर्यात परिणाम को वैधता जांचें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्यों एक एनीमेशन PowerPoint में दिखता है लेकिन PDF में नहीं?**

PDF एक स्थिर स्वरूप है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलते। जब गति को संरक्षित करना हो तो HTML5, एनिमेटेड GIF, या वीडियो में निर्यात करें।

**क्यों एक इफ़ेक्ट वीडियो में अलग तरह से चलता है?**

वीडियो निर्यात एनीमेशन को रेंडर करता है, मूल PowerPoint व्यवहार को नहीं। कुछ उन्नत इफ़ेक्ट्स असमर्थित या अनुमानित होते हैं। समर्थित‑इफ़ेक्ट्स तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या आकार को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। आकार का z‑order ओवरलैप नियंत्रित करता है, जबकि अनुक्रम क्रम और ट्रिगर एनीमेशन प्लेबैक नियंत्रित करते हैं। यदि अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलेँ।