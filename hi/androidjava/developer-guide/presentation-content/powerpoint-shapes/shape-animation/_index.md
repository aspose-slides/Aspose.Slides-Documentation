---
title: Android पर प्रस्तुतियों में शैप एनीमेशन लागू करें
linktitle: शैप एनीमेशन
type: docs
weight: 60
url: /hi/androidjava/shape-animation/
keywords:
- शैप
- एनीमेशन
- प्रभाव
- एनिमेटेड शैप
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
description: "Aspose.Slides for Android via Java के साथ शैप एनीमेशन, टाइमिंग, ध्वनियों, एनीमेशन‑के‑बाद व्यवहार, और एनिमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Android via Java स्लाइड एनीमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट्स के रूप में दर्शाता है। एक इफ़ेक्ट में लक्ष्य शैप, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, और वैकल्पिक गुण जैसे ध्वनि या एनीमेशन-के-बाद व्यवहार शामिल होते हैं।

टाइमलाइन में दो प्रकार के अनुक्रम होते हैं:

- **मुख्य अनुक्रम** स्लाइड आगे बढ़ने पर चलता है।
- **इंटरैक्टिव अनुक्रम** तब शुरू होता है जब उसका ट्रिगर शैप क्लिक किया जाता है।

क्योंकि टेक्स्ट बॉक्स, चित्र, चार्ट, टेबल और अन्य स्लाइड ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) को लागू करते हैं, आप अधिकांश स्लाइड सामग्री के लिए वही [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) मेथड का उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttype/) क्लास में सूचीबद्ध हैं।

## **शेप एनीमेशन जोड़ें**

एनीमेशन जोड़ने के लिए, स्लाइड के मुख्य अनुक्रम को प्राप्त करें और लक्ष्य शैप, इफ़ेक्ट प्रकार, उपप्रकार, और ट्रिगर के साथ [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) कॉल करें। किसी इफ़ेक्ट के लिए जो दूसरे शैप पर क्लिक करने पर शुरू होता है, एक इंटरैक्टिव अनुक्रम बनाएं जिसका ट्रिगर वही दूसरा शैप हो।

निम्न उदाहरण दोनों प्रकार के एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

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

ट्रिगर नियंत्रित करता है कि इफ़ेक्ट कब शुरू होता है:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttriggertype/#OnClick) मुख्य अनुक्रम में क्लिक की प्रतीक्षा करता है, या इंटरैक्टिव अनुक्रम में ट्रिगर शैप पर क्लिक की।
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) पहले इफ़ेक्ट के साथ शुरू होता है।
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) पहले इफ़ेक्ट समाप्त होने पर शुरू होता है।

एक चित्र, चार्ट, या अन्य शैप प्रकार को एनीमेट करने के लिए, उस ऑब्जेक्ट को [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) में `targetShape` के स्थान पर पास करें। चार्ट-विशिष्ट समूह विकल्पों के लिए, देखें [एनिमेटेड चार्ट्स](/slides/hi/androidjava/animated-charts/)।

## **शेप एनीमेशन पढ़ें**

जब आप लक्ष्य शैप जानते हैं तो [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) का उपयोग करें। प्रत्येक इफ़ेक्ट का निरीक्षण करने के लिए, मुख्य अनुक्रम और सभी इंटरैक्टिव अनुक्रमों को क्रमबद्ध करें। क्रमबद्ध करने से यह मानने से बचा जाता है कि अनुक्रम में इंडेक्स `0` पर हमेशा कोई इफ़ेक्ट है।

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

यदि आपको केवल एक शैप के लिए इफ़ेक्ट चाहिए, तो पहले शैप को नाम, प्लेसहोल्डर प्रकार या किसी स्थिर गुण द्वारा पहचानें; फिर [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) कॉल करें। यह न मानें कि [IShapeCollection.get_Item](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) इंडेक्स `0` पर हमेशा इच्छित ऑब्जेक्ट है।

## **विरासत प्राप्त प्लेसहोल्डर प्रभावों के साथ काम करें**

एक सामान्य स्लाइड पर प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर संबंधित प्लेसहोल्डर से एनीमेशन व्यवहार विरासत में ले सकता है। [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) वह पेरेंट प्लेसहोल्डर लौटाता है, या यदि कोई पेरेंट नहीं है तो `null`।

निम्न उदाहरण प्रस्तुति में, फुटर में सामान्य स्लाइड पर **Random Bars**, लेआउट स्लाइड पर **Split**, और मास्टर स्लाइड पर **Fly In** हैं।

![सामान्य स्लाइड पर फुटर एनीमेशन प्रभाव](slide-shape-animation.png)
![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन प्रभाव](layout-shape-animation.png)
![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन प्रभाव](master-shape-animation.png)

अगला उदाहरण नई प्रस्तुति से प्लेसहोल्डर पदानुक्रम का उपयोग करता है। यह मास्टर प्लेसहोल्डर, लेआउट प्लेसहोल्डर, और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में इफ़ेक्ट जोड़ता है। प्रत्येक बार [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) का उपयोग करने से पहले जाँच किया जाता है कि लौटाया गया शैप प्रयोग किया जा सकता है।

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

PowerPoint **Timing** संवाद [ITiming](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/) की प्रॉपर्टीज़ से मैप होता है।

![एक एनीमेशन प्रभाव के लिए PowerPoint टाइमिंग संवाद](shape-animation.png)

- **Start** को [ITiming.getTriggerType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getTriggerType--) से मैप किया जाता है।
- **Duration** को [ITiming.getDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getDuration--) से मैप किया जाता है, सेकंड में।
- **Delay** को [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) से मैप किया जाता है, सेकंड में।
- **Repeat** को [ITiming.getRepeatCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), या [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) से मैप किया जाता है।
- **Rewind when done playing** को [ITiming.getRewind](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRewind--) से मैप किया जाता है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, उसके टाइमिंग को [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से बदलता है, और परिणाम को सहेजता है। लौटाए गए [IEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/) संदर्भ को रखकर अनावश्यक कलेक्शन इंडेक्स से बचा जा सकता है।

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

एक ही रिपीट मोड का इरादतन उपयोग करें। रिपीट काउंट को “until” फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित परिणाम मिल सकते हैं। रिपीट मोड बदलते समय, पहले [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) और [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) सेट करें, फिर [ITiming.setRepeatCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) सेट करें, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय रिपीट मोड भी बदल जाता है।

## **एनिमेशन ध्वनि जोड़ें और निकालें**

एक एनीमेशन इफ़ेक्ट एम्बेडेड ऑडियो को [IEffect.getSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getSound--) के माध्यम से संदर्भित कर सकता है। [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) एक इफ़ेक्ट को पहले के इफ़ेक्ट द्वारा शुरू हुई ध्वनि को रोकने के लिए कहता है।

### **प्रभाव में ध्वनि जोड़ें**

निम्न उदाहरण एक स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की उम्मीद करता है। यह दो इफ़ेक्ट बनाता है, पहली इफ़ेक्ट के लिए उस फ़ाइल को ध्वनि के रूप में एम्बेड करता है, और दूसरे इफ़ेक्ट को ध्वनि रोकने के लिए कॉन्फ़िगर करता है। यह [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) द्वारा लौटाए गए ऑब्जेक्ट्स का उपयोग करता है, इसलिए अनुक्रम इंडेक्स आवश्यक नहीं।

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

### **एम्बेडेड प्रभाव ध्वनियों को निकालें**

निम्न उदाहरण एक स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरैक्टिव दोनों अनुक्रमों को स्कैन करता है और प्रत्येक एम्बेडेड इफ़ेक्ट ध्वनि को `extracted-animation-sounds` निर्देशिका में लिखता है। एक्सटेंशन ऑडियो MIME टाइप से प्राप्त किया जाता है जो [IAudio.getContentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudio/#getContentType--) द्वारा उजागर किया जाता है।

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

बड़ी ऑडियो ऑब्जेक्ट्स के लिए, [IAudio.getStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudio/#getStream--) का उपयोग करें और स्ट्रीम को फ़ाइल में कॉपी करें बजाय पूरे ऑब्जेक्ट को बाइट एरे में लोड करने के।

## **After-Animation व्यवहार सेट करें**

**After animation** विकल्प नियंत्रित करता है कि इफ़ेक्ट समाप्त होने के बाद शैप के साथ क्या होता है।

![After animation सेटिंग्स दिखाते हुए PowerPoint प्रभाव विकल्प संवाद](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/) क्लास शैप को अपरिवर्तित छोड़ने, उसका रंग बदलने, एनीमेशन के बाद छुपाने, या अगले क्लिक पर छुपाने का समर्थन करता है। जब प्रकार [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#Color) हो, तो [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) भी सेट करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, उसके after-animation व्यवहार को लौटाए गए इफ़ेक्ट ऑब्जेक्ट के माध्यम से सेट करता है, और परिणाम सहेजता है।

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

यदि प्रकार को [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/afteranimationtype/#Color) से बदलते हैं तो after-animation रंग सेटिंग साफ़ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन में दो संबंधित नियंत्रण होते हैं:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextanimation/#getBuildType--) नियंत्रित करता है कि पैराग्राफ एक साथ दिखें या पैराग्राफ स्तर पर।
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) नियंत्रित करता है कि टेक्स्ट एक साथ, शब्द द्वारा, या अक्षर द्वारा दिखे। [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) शब्दों या अक्षरों के बीच विलंब सेट करता है। एक सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत होता है; एक नकारात्मक मान सेकंड में विलंब होता है।

निम्न स्वतंत्र उदाहरण टेक्स्ट बॉक्स के शब्दों को एनीमेट करता है। [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/buildtype/#AsOneObject) पैराग्राफ‑बार‑बार निर्माण को निष्क्रिय करता है ताकि शब्द सेटिंग सम्पूर्ण टेक्स्ट फ्रेम पर लागू हो।

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

टेक्स्ट बॉक्स को पैराग्राफ द्वारा बनाने के लिए, [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (या अन्य पैराग्राफ स्तर) सेट करें। एकल पैराग्राफ को उसके खुद के इफ़ेक्ट के साथ लक्षित करने के लिए, उस [ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) ओवरलोड का उपयोग करें जो [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) को स्वीकार करता है। पैराग्राफ‑स्तर के उदाहरणों के लिए देखें [Animated Text](/slides/hi/androidjava/animated-text/)।

## **निर्यात और संगति नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल संरक्षित रहता है, लेकिन अंतिम प्लेबैक प्रस्तुति व्यूअर द्वारा नियंत्रित होता है।
- PDF और स्थैतिक छवियां एनीमेशन नहीं चलातीं। जब आउटपुट को गति दिखानी हो तो [HTML5 export](/slides/hi/androidjava/export-to-html5/), एनिमेटेड GIF, या [video conversion](/slides/hi/androidjava/convert-powerpoint-to-video/) का उपयोग करें।
- HTML5 के लिए, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) सक्षम करें और आवश्यकतानुसार [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) भी।
- वीडियो रेंडरिंग कई सामान्य प्रवेश, जोर, निकास, और मोशन‑पाथ इफ़ेक्ट्स का समर्थन करता है, लेकिन हर PowerPoint इफ़ेक्ट समर्थित नहीं है। वर्तमान [supported animations and effects](/slides/hi/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और लक्षित Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।
- उन्नत कस्टम इफ़ेक्ट और अन्य फ़ॉर्मेट से आयातित इफ़ेक्ट फ़ाइल में सुरक्षित रह सकते हैं लेकिन PowerPoint, HTML5, या वीडियो में अलग तरीके से रेंडर हो सकते हैं। केवल इफ़ेक्ट नाम पर भरोसा न करके निर्यात परिणाम को सत्यापित करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में एनीमेशन दिखता है लेकिन PDF में नहीं क्यों दिखता?**  
PDF एक स्थैतिक स्वरूप है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलतीं। गति को संरक्षित करने के लिए HTML5, एनिमेटेड GIF, या वीडियो में निर्यात करें।

**वीडियो में इफ़ेक्ट अलग क्यों चलता है?**  
वीडियो निर्यात एनीमेशन को रेंडर करता है न कि मूल PowerPoint व्यवहार को संग्रहीत करता है। कुछ उन्नत इफ़ेक्ट असमर्थित या अनुमानित होते हैं। सपोर्टेड‑इफ़ेक्ट टेबल देखें और उत्पादन से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या शैप को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**  
नहीं। शैप का Z‑order ओवरलैप को नियंत्रित करता है, जबकि अनुक्रम क्रम और ट्रिगर एनीमेशन प्लेबैक को नियंत्रित करते हैं। यदि अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलें।