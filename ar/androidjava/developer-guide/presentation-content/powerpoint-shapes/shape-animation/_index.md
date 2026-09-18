---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية على Android
linktitle: حركة الشكل
type: docs
weight: 60
url: /ar/androidjava/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة حركة
- الحصول على حركة
- استخراج حركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت تأثير
- تطبيق حركة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة، فحص، وتخصيص الرسوم المتحركة للأشكال، والتوقيت، والأصوات، وسلوك ما بعد الحركة، والنص المتحرك باستخدام Aspose.Slides لـ Android عبر Java."
---
## **نظرة عامة**

للعمل مع السلوكيات الفردية داخل تأثير أو تحرير مقاطع مسار الحركة، راجع [الرسوم المتحركة المخصصة لـ Java](/slides/ar/java/custom-animation/).

Aspose.Slides for Android via Java تمثل الرسوم المتحركة للشرائح كـ effects في مخطط زمني للشرائح. يحتوي effect على شكل هدف، نوع الرسوم المتحركة والنوع الفرعي، مشغل، إعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

المخطط الزمني يحتوي على نوعين من التسلسلات:

- **السلسلة الرئيسية** تُشغل عندما تتقدم الشريحة.
- **السلسلة التفاعلية** تبدأ عندما يُنقر على الشكل المشغل.

نظرًا لأن صناديق النصوص، الصور، المخططات، الجداول، وغيرها من كائنات الشريحة تُنفّذ [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/)، يمكنك استخدام نفس طريقة [ISequence.addEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) لمعظم محتوى الشريحة. تُدرج التأثيرات المتاحة في الفئة [EffectType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effecttype/).

## **إضافة رسوم متحركة للأشكال**

لإضافة رسوم متحركة، احصل على السلسلة الرئيسية للشرحة واستدعِ [ISequence.addEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) مع شكل الهدف، نوع effect، النوع الفرعي، والمشغل. لتأثير يبدأ عندما يُنقر على شكل آخر، أنشئ سلسلة تفاعلية يكون مشغلها ذلك الشكل الآخر.

المثال التالي يخلق كلا نوعي الرسوم المتحركة ويحفظ النتيجة إلى `shape-animations.pptx`.

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

المشغل يتحكم بموعد بدء effect:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effecttriggertype/#OnClick) ينتظر نقرة في السلسلة الرئيسية، أو نقرة على الشكل المشغل في سلسلة تفاعلية.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) يبدأ مع الـ effect السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) يبدأ عندما ينتهي الـ effect السابق.

لتحريك صورة أو مخطط أو نوع شكل آخر، مرّر ذلك الكائن إلى [ISequence.addEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) بدلاً من `targetShape`. لخيارات تجميع خاصة بالمخططات، طالع [Animated Charts](/slides/ar/androidjava/animated-charts/).

## **قراءة رسوم متحركة للأشكال**

استخدم [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) عندما تعرف شكل الهدف. لتفقد كل effect، استعرض السلسلة الرئيسية وكل سلسلة تفاعلية. الاستعراض يُجنّب الافتراض بأن السلسلة تحتوي على effect في الفهرس `0`.

المثال التالي يُنشئ شكلًا يحتوي على تأثيرات في السلسلة الرئيسية وتفاعلية، يحصل على الـ effects التي تستهدف الشكل، ثم يستعرض كل سلسلة على الشريحة.

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

إذا كنت تحتاج فقط إلى الـ effects لشكل واحد، حدّد الشكل أولاً بالاسم أو نوع العنصر النائب أو خاصية ثابتة أخرى؛ ثم استدعِ [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). لا تفترض أن [IShapeCollection.get_Item](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العناصر النائبة الموروثة**

يمكن للعنصر النائب على شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل على شريحة التخطيط والشريحة الرئيسية. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) يُرجع ذلك العنصر النائب الأب، أو `null` عندما لا يكون هناك أب.

في عرض الشرائح التالي، يحتوي التذييل على **Random Bars** على الشريحة العادية، **Split** على شريحة التخطيط، و**Fly In** على الشريحة الرئيسية.

![تأثير حركة تذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير حركة عنصر نائب للتذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير حركة عنصر نائب للتذييل على الشريحة الرئيسية](master-shape-animation.png)

المثال التالي يستخدم تسلسلًا هرميًا لعناصر نائب من عرض تقديم جديد. يضيف تأثيرات إلى عنصر نائب رئيسي، عنصر نائب تخطيط، والعنصر النائب المقابل على شريحة عادية. كل استدعاء لـ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) يُفحص قبل استخدام الشكل المُرجع.

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

## **تغيير توقيت الحركة**

حوار PowerPoint **Timing** يتطابق مع خصائص [ITiming](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/).

![حوار توقيت PowerPoint لتأثير حركة](shape-animation.png)

- **Start** يتطابق مع [ITiming.getTriggerType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** يتطابق مع [ITiming.getDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getDuration--)، بالثواني.
- **Delay** يتطابق مع [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)، بالثواني.
- **Repeat** يتطابق مع [ITiming.getRepeatCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getRepeatCount--)، [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--)، أو [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** يتطابق مع [ITiming.getRewind](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getRewind--).

هذا المثال المستقل يضيف effect، يغير توقيته عبر الكائن المُرجع من [ISequence.addEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)، ويحفظ النتيجة. الحفاظ على مرجع [IEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/) المُرجع يجنب الحاجة إلى فهرس تجميع غير ضروري.

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

استخدم وضعية تكرار واحدة فقط. الجمع بين عدد التكرارات وعلم “until” قد ينتج عنه نتائج مربكة في مشغّلات مختلفة. عند تغيير أوضاع التكرار، عيّن [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) و[ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) قبل [ITiming.setRepeatCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-)، لأن ضبط أي علم يغيّر وضعية التكرار النشطة.

## **إضافة واستخراج أصوات الحركة**

يمكن لتأثير حركة أن يشير إلى صوت مضمّن عبر [IEffect.getSound](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) يُخبر الـ effect بإيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوت محلي اسمه `animation-sound.wav`. يخلق تأثيرين، يضمّن ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات التي تُرجعها [ISequence.addEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)، لذلك لا يُطلب فهرس سلسلة.

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

### **استخراج أصوات التأثير المضمنة**

المثال التالي يتوقع عرض تقديم محلي اسمه `presentation-with-animation-sounds.pptx`. يُمسح كل من السلسلتين الرئيسيتين والتفاعليتين ويكتب كل صوت تأثير مضمّن إلى دليل `extracted-animation-sounds`. الامتداد يُحدَّد من نوع MIME الصوتي الذي تُعيده [IAudio.getContentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudio/#getContentType--).

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

للكائنات الصوتية الكبيرة، استخدم [IAudio.getStream](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudio/#getStream--) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل في مصفوفة بايت.

## **تعيين سلوك ما بعد الحركة**

خيار **After animation** يتحكم بما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات تأثير PowerPoint يظهر إعدادات ما بعد الحركة](shape-after-animation.png)

تدعم الفئة [AfterAnimationType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/afteranimationtype/) ترك الشكل دون تغيير، تغيير لونه، إخفائه بعد الحركة، أو إخفائه عند النقرة التالية. عندما يكون النوع هو [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/afteranimationtype/#Color)، اضبط أيضًا [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

هذا المثال المستقل يخلق effect، يضبط سلوك ما بعد الحركة عبر كائن الـ effect المُرجع، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/afteranimationtype/#Color) يمسح إعداد لون ما بعد الحركة.

## **تحريك النص**

لتحريك النص هناك تحكمان مرتبطان:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextanimation/#getBuildType--) يتحكم فيما إذا كانت الفقرات تظهر معًا أو على مستوى الفقرة.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) يتحكم فيما إذا كان النص يظهر دفعة واحدة، كلمةً كلمةً، أو حرفًا بحرف. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) يحدد التأخير بين الكلمات أو الأحرف. القيمة الموجبة هي نسبة مئوية من مدة الـ effect؛ القيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل صندوق نص. [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/buildtype/#AsOneObject) يُعطّل بناء الفقرة-بالفقرة بحيث يُطبق إعداد الكلمة على كامل إطار النص.

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

لبناء صندوق نص وفقًا للفقرة، اضبط [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثير خاص بها، استخدم نسخة [ISequence.addEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) التي تقبل [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/). راجع [Animated Text](/slides/ar/androidjava/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- الحفظ إلى PPT أو PPTX يحافظ على نموذج الرسوم المتحركة، لكن التشغيل النهائي يتحكم فيه عارض العرض.
- PDF والصور الثابتة لا تشغل الرسوم المتحركة. استخدم [HTML5 export](/slides/ar/androidjava/export-to-html5/)، GIF متحرك، أو [تحويل الفيديو](/slides/ar/androidjava/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- بالنسبة إلى HTML5، فعّل [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) وعند الحاجة [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- تحويل الفيديو يدعم العديد من تأثيرات الدخول، التركيز، الخروج، ومسار الحركة الشائعة، لكن ليس كل تأثير PowerPoint مدعوم. راجع جدول [supported animations and effects](/slides/ar/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) الحالي واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحافظ التأثيرات المخصصة المتقدمة أو المستوردة من صيغ عرض أخرى في الملف لكنها تُعرض بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة المتكررة**

**لماذا يظهر تأثير في PowerPoint ولا يظهر في PDF؟**

PDF تنسيق ثابت، لذا لا تُشغل الرسوم المتحركة وانتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب حفظ الحركة.

**لماذا يُشغَّل تأثير بصورة مختلفة في الفيديو؟**

تصدير الفيديو يُعيد رسم الرسوم المتحركة بدلًا من حفظ سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو تُقرب. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام في الإنتاج.

**هل تغيير موضع الشكل إلى الأمام أو الخلف يغيّر ترتيب الرسوم المتحركة؟**

لا. ترتيب الـ z لل shape يتحكم في التراكب، بينما ترتيب السلسلة والمشغلات يتحكم في تشغيل الرسوم المتحركة. غيّر المخطط الزمني إذا احتجت ترتيب تشغيل مختلف.