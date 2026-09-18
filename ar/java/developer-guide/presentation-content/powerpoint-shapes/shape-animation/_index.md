---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية باستخدام Java
linktitle: تحريك الشكل
type: docs
weight: 60
url: /ar/java/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة رسوم متحركة
- الحصول على رسوم متحركة
- استخراج رسوم متحركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق رسوم متحركة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة، فحص، وتخصيص الرسوم المتحركة للأشكال، التوقيت، الأصوات، سلوك ما بعد الرسوم المتحركة، والنص المتحرك باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

للعمل مع السلوكيات الفردية داخل تأثير أو لتعديل مقاطع مسار الحركة، راجع [الرسوم المتحركة المخصصة](/slides/ar/java/custom-animation/).

تُمثل Aspose.Slides for Java الرسوم المتحركة للشرائح كـ تأثيرات في مخطط زمني للشرائح. يحتوي كل تأثير على الشكل المستهدف، ونوع الرسوم المتحركة والفرعي، والمشغّل، وإعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

يحتوي المخطط الزمني على نوعين من التسلسلات:
- **التسلسل الرئيسي** يُشغل مع تقدم الشريحة.
- **التسلسل التفاعلي** يبدأ عندما يُنقر على الشكل المشغّل.

نظرًا لأن مربعات النص، والصور، والمخططات، والجداول، وغيرها من كائنات الشريحة تنفّذ الواجهة [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/)، يمكنك استخدام نفس الطريقة [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) لمعظم محتوى الشريحة. تُدرج التأثيرات المتوفرة في الفئة [EffectType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttype/).

## **إضافة رسوم متحركة للأشكال**

لإضافة رسوم متحركة، احصل على التسلسل الرئيسي للشرحة واستدعِ الطريقة [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) مع الشكل المستهدف، ونوع التأثير، والفرعي، والمشغّل. للحصول على تأثير يبدأ عند النقر على شكل آخر، أنشئ تسلسلًا تفاعليًا يكون المشغّل فيه ذلك الشكل الآخر.

المثال التالي ينشئ كلا النوعين من الرسوم المتحركة ويحفظ النتيجة في `shape-animations.pptx`.

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

المشغّل يتحكم في وقت بدء التأثير:
- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttriggertype/#OnClick) ينتظر النقر في التسلسل الرئيسي، أو النقر على الشكل المشغّل في تسلسل تفاعلي.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttriggertype/#WithPrevious) يبدأ مع التأثير السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttriggertype/#AfterPrevious) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو مخطط أو أي نوع شكل آخر، مرّر ذلك الكائن إلى الطريقة [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) بدلاً من `targetShape`. للحصول على خيارات تجميع خاصة بالمخططات، راجع [المخططات المتحركة](/slides/ar/java/animated-charts/).

## **قراءة الرسوم المتحركة للأشكال**

استخدم [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) عندما تعرف الشكل المستهدف. لتفحص كل تأثير، قم بتعداد التسلسل الرئيسي وكل تسلسل تفاعلي. يُجنب التعداد الافتراض بأن التسلسل يحتوي على تأثير في الفهرس `0`.

المثال التالي ينشئ شكلاً يحتوي على تأثيرات في التسلسل الرئيسي وتفاعلية، يحصل على التأثيرات التي تستهدف الشكل، ثم يعدد كل تسلسل على الشريحة.

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

إذا كنت تحتاج فقط إلى التأثيرات لشكل واحد، حدد الشكل أولاً بالاسم أو نوع العنصر النائب أو أي خاصية ثابتة أخرى؛ ثم استدعِ [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). لا تفترض أن [IShapeCollection.get_Item](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#get_Item-int-) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العناصر النائبة الموروثة**

يمكن لعنصر نائب على شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل على شريحة التخطيط وشريحة القالب. تُعيد [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getBasePlaceholder--) ذلك العنصر النائب الأب، أو `null` إذا لم يكن هناك أب.

في عرض الشرائح المثال التالي، يحتوي التذييل على **Random Bars** في الشريحة العادية، و**Split** في شريحة التخطيط، و**Fly In** في شريحة القالب.

![تأثير الرسوم المتحركة للتذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير الرسوم المتحركة للعنصر النائب للتذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير الرسوم المتحركة للعنصر النائب للتذييل على شريحة القالب](master-shape-animation.png)

المثال التالي يستخدم هيكلية عناصر نائبة من عرض تقديمي جديد. يضيف تأثيرات إلى عنصر نائب رئيسي، وعنصر نائب في التخطيط، والعنصر النائب المقابل على شريحة عادية. يتم فحص كل استدعاء لـ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getBasePlaceholder--) قبل استخدام الشكل المرجع.

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

## **تغيير توقيت الرسوم المتحركة**

حوار **التوقيت** في PowerPoint يتطابق مع خصائص [ITiming](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/).

![حوار التوقيت في PowerPoint لتأثير الرسوم المتحركة](shape-animation.png)

- **Start** يتطابق مع [ITiming.getTriggerType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** يتطابق مع [ITiming.getDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getDuration--)، بالثواني.
- **Delay** يتطابق مع [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getTriggerDelayTime--)، بالثواني.
- **Repeat** يتطابق مع [ITiming.getRepeatCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatCount--)، [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--)، أو [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** يتطابق مع [ITiming.getRewind](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRewind--).

هذا المثال المستقل يضيف تأثيرًا، يغيّر توقيته عبر الكائن المُعاد من [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)، ويحفظ النتيجة. الاحتفاظ بالمرجع المُعاد من [IEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/) يجنّب الحاجة إلى فهرس مجموعة غير ضروري.

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

استخدم وضعية تكرار واحدة عن قصد. الجمع بين عدد التكرارات وعلمية "until" قد ينتج عنه نتائج مربكة في مشغّلات مختلفة. عند تغيير أوضاع التكرار، اضبط [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) و[ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) قبل [ITiming.setRepeatCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#setRepeatCount-float-)، لأن ضبط أي من العلامتين يغير وضعية التكرار النشطة.

## **إضافة واستخراج أصوات الرسوم المتحركة**

يمكن لتأثير الرسوم المتحركة الإشارة إلى صوت مضمّن عبر [IEffect.getSound](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getSound--). يحدد [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) أن يتوقف التأثير عن تشغيل الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوتي محلي اسمه `animation-sound.wav`. ينشئ تأثيرين، يضمّن ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المُعودة من [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)، لذا لا يلزم فهرس التسلسل.

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

### **استخراج أصوات التأثير المضمّنة**

المثال التالي يتوقع عرض تقديمي محلي اسمه `presentation-with-animation-sounds.pptx`. يقوم بمسح كل من التسلسل الرئيسي والتفاعلي ويكتب كل صوت مضمّن إلى الدليل `extracted-animation-sounds`. يتم اختيار الامتداد من نوع MIME الصوتي الذي تُقدّمه [IAudio.getContentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudio/#getContentType--).

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

بالنسبة لكائنات الصوت الكبيرة، استخدم [IAudio.getStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudio/#getStream--) وانسخ التيار إلى ملف بدلاً من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **ضبط سلوك ما بعد الرسوم المتحركة**

خيار **After animation** يحدد ما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات تأثير PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

تدعم الفئة [AfterAnimationType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/) ترك الشكل دون تغيير، أو تغيير لونه، أو إخفائه بعد الرسوم المتحركة، أو إخفائه عند النقر التالي. عندما يكون النوع هو [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/#Color)، يجب أيضًا تعيين [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) .

هذا المثال المستقل ينشئ تأثيرًا، يضبط سلوك ما بعد الرسوم المتحركة عبر كائن التأثير المرجعي المُعاد، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType.Color] يُزيل إعداد لون ما بعد الرسوم المتحركة.

## **تحريك النص**

لتحريك النص هناك تحكمان مرتبطان:
- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextanimation/#getBuildType--) يتحكم فيما إذا كانت الفقرات تظهر معًا أو على مستوى الفقرة.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getAnimateTextType--) يتحكم فيما إذا كان النص يظهر دفعة واحدة، أو كلمة بكلمة، أو حرف بحرف. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) يحدد التأخير بين الكلمات أو الأحرف. القيمة الموجبة هي نسبة مئوية من مدة التأثير؛ والقيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل صندوق نص. يُعطّل [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/buildtype/#AsOneObject) بناء الفقرة بفقرة بحيث ينطبق إعداد الكلمة على الإطار النصي بأكمله.

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

لبناء صندوق نص وفقًا للفقرة، اضبط [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ar/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثير خاص بها، استخدم التحميل الزائد لـ [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) الذي يقبل [IParagraph]. راجع [النص المتحرك](/slides/ar/java/animated-text/) للحصول على أمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- حفظ إلى PPT أو PPTX يحافظ على نموذج الرسوم المتحركة، لكن التشغيل النهائي يتحكم فيه عارض العرض.
- لا تقوم PDF والصور الثابتة بتشغيل الرسوم المتحركة. استخدم [تصدير HTML5](/slides/ar/java/export-to-html5/)، GIF متحرك، أو [تحويل الفيديو](/slides/ar/java/convert-powerpoint-to-video/) عندما يجب أن يُظهر الخرج الحركة.
- بالنسبة إلى HTML5، فعّل [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) وعند الحاجة، [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- يدعم تصيير الفيديو العديد من تأثيرات الدخول، والتأكيد، والخروج، ومسارات الحركة الشائعة، لكن ليس كل تأثير PowerPoint مدعوم. تحقق من [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/java/convert-powerpoint-to-video/#supported-animations-and-effects) الحالي واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحافظ التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض تقديمية أخرى في الملف لكن يظهرها بطرق مختلفة في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدّرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة الشائعة**

**لماذا يظهر تأثير في PowerPoint لكن ليس في PDF؟**

PDF هو تنسيق ثابت، لذا لا تُشغل الرسوم المتحركة وانتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب الحفاظ على الحركة.

**لماذا يُشغل تأثير بصورة مختلفة في الفيديو؟**

يُعيد تصدير الفيديو الرسوم المتحركة بدلاً من تخزين سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو مُقربة. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل يغيّر نقل الشكل للأمام أو للخلف ترتيبه في الرسوم المتحركة؟**

لا. يتحكم ترتيب z للشكل في التداخل، بينما يتحكم ترتيب التسلسل والمشغلات في تشغيل الرسوم المتحركة. غيّر المخطط الزمني إذا كنت تحتاج ترتيب تشغيل مختلف.