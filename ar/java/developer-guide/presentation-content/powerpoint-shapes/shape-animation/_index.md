---
title: تطبيق رسوم متحركة للأشكال في العروض التقديمية باستخدام Java
linktitle: رسوم متحركة للأشكال
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
description: "تعلم كيفية إضافة، فحص، وتخصيص رسوم متحركة للأشكال، التوقيت، الأصوات، سلوك ما بعد الرسوم المتحركة، والنص المتحرك باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

تمثل Aspose.Slides for Java الرسوم المتحركة للشرائح كـ تأثيرات في مخطط زمني للشرائح. يحتوي التأثير على الشكل الهدف، ونوع الرسوم المتحركة والفرعي، ومُشغّل، وإعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

المخطط الزمني يحتوي على نوعين من التسلسلات:

- **التسلسل الرئيسي** يُعرض مع تقدم الشريحة.
- **التسلسل التفاعلي** يبدأ عندما يتم النقر على الشكل المُشغّل.

نظرًا لأن مربعات النصوص، الصور، المخططات، الجداول، وغيرها من كائنات الشريحة تُنفّذ [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/)، يمكنك استخدام نفس طريقة [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) لمعظم محتوى الشريحة. يتم سرد التأثيرات المتاحة في الفئة [EffectType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttype/) .

## **إضافة رسوم متحركة للأشكال**

لإضافة رسم متحرك، احصل على التسلسل الرئيسي للشريحة واستدعِ [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) مع الشكل الهدف، نوع التأثير، الفرعي، والمُشغّل. لتأثير يبدأ عندما يتم النقر على شكل آخر، أنشئ تسلسلاً تفاعليًا يصبح المشغل هو ذلك الشكل الآخر.

المثال التالي ينشئ كلا النوعين من الرسوم المتحركة ويحفظ النتيجة إلى `shape-animations.pptx`.

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

المُشغّل يتحكم متى يبدأ التأثير:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttriggertype/#OnClick) ينتظر نقرة في التسلسل الرئيسي، أو نقرة على الشكل المُشغّل في التسلسل التفاعلي.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttriggertype/#WithPrevious) يبدأ مع التأثير السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttriggertype/#AfterPrevious) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو مخطط أو أي نوع آخر من الأشكال، مرّر ذلك الكائن إلى [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) بدلاً من `targetShape`. لخيارات تجميع خاصة بالمخططات، راجع [المخططات المتحركة](/slides/ar/java/animated-charts/).

## **قراءة الرسوم المتحركة للأشكال**

استخدم [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) عندما تعرف الشكل الهدف. لتفقد كل تأثير، عدّ التسلسل الرئيسي وكل تسلسل تفاعلي. العدّ يجنّب الافتراض بأن التسلسل يحتوي على تأثير في الفهرس `0`.

المثال التالي ينشئ شكلاً له تأثيرات في التسلسل الرئيسي وتفاعلي، يحصل على التأثيرات التي تستهدف الشكل، ثم يُعيد عدّ كل تسلسل على الشريحة.

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

إذا كنت تحتاج فقط إلى التأثيرات لشكل واحد، حدّد الشكل بالاسم أو نوع العنصر النائب أو أي خاصية ثابتة أخرى؛ ثم استدعِ [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). لا تفترض أن [IShapeCollection.get_Item](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#get_Item-int-) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العناصر النائبة الموروثة**

يمكن لعنصر نائب على شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل على شريحة التخطيط والشريحة الرئيسة. تُعيد [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getBasePlaceholder--) ذلك العنصر النائب الأب، أو `null` عندما لا وجود لعنصر أب.

في عرض الشرائح التالي، يحتوي التذييل على **Random Bars** على الشريحة العادية، **Split** على شريحة التخطيط، و**Fly In** على الشريحة الرئيسة.

![تأثير حركة التذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على الشريحة الرئيسة](master-shape-animation.png)

المثال التالي يستخدم هيكلية عناصر نائبة من عرض تقديمي جديد. يضيف تأثيرات إلى عنصر نائب رئيسي، عنصر نائب تخطيط، والعنصر النائب المقابل على شريحة عادية. كل استدعاء لـ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getBasePlaceholder--) يتم التحقق منه قبل استخدام الشكل المعاد.

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

حوار **Timing** في PowerPoint يطابق خصائص [ITiming](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/).

![حوار توقيت PowerPoint لتأثير الرسوم المتحركة](shape-animation.png)

- **Start** يطابق [ITiming.getTriggerType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** يطابق [ITiming.getDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getDuration--)، بالثواني.
- **Delay** يطابق [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getTriggerDelayTime--)، بالثواني.
- **Repeat** يطابق [ITiming.getRepeatCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatCount--)، أو [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--)، أو [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** يطابق [ITiming.getRewind](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRewind--).

هذا المثال المستقل يضيف تأثيرًا، يعدّل توقيته عبر الكائن المعاد من [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)، ويحفظ النتيجة. حفظ مرجع [IEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/) المعاد يُجنب الحاجة إلى فهرس مجموعة غير ضروري.

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

استخدم وضع تكرار واحد فقط. دمج عدد تكرار مع علم "حتى" قد ينتج عنه نتائج مربكة في مشغلات مختلفة. عند تغيير أوضاع التكرار، استدعِ [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) و[ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) قبل استدعاء [ITiming.setRepeatCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#setRepeatCount-float-)، لأن ضبط أي علم يغيّر وضع التكرار النشط.

## **إضافة واستخراج أصوات الرسوم المتحركة**

يمكن لتأثير الرسوم المتحركة أن يشير إلى صوت مضمّن عبر [IEffect.getSound](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getSound--). يحدّد [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) أن يتوقف التأثير عن تشغيل الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوتي محلي اسمه `animation-sound.wav`. ينشئ تأثيرين، يضمّن ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المعادة من [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)، لذا لا يلزم فهرس التسلسل.

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

### **استخراج أصوات التأثيرات المضمنة**

المثال التالي يتوقع عرض تقديمي محلي اسمه `presentation-with-animation-sounds.pptx`. يفحص كل من التسلسلات الرئيسية والتفاعلية ويكتب كل صوت تأثير مضمّن إلى مجلد `extracted-animation-sounds`. يتم اختيار الامتداد بناءً على نوع MIME الصوتي الذي تُعطيه [IAudio.getContentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudio/#getContentType--).

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

للكائنات الصوتية الكبيرة، استخدم [IAudio.getStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudio/#getStream--) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **تعيين سلوك ما بعد الرسوم المتحركة**

خيار **After animation** يتحكم بما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات التأثير في PowerPoint يظهر إعدادات ما بعد الرسوم المتحركة](shape-after-animation.png)

فئة [AfterAnimationType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/) تدعم إبقاء الشكل دون تغيير، تغيير لونه، إخفائه بعد الرسوم المتحركة، أو إخفائه عند النقرة التالية. عندما يكون النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/#Color)، عيّن أيضًا [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

هذا المثال المستقل ينشئ تأثيرًا، يحدد سلوك ما بعد الرسوم المتحركة عبر الكائن المعاد، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/#Color) يمحو إعداد اللون بعد الرسوم المتحركة.

## **تحريك النص**

لتحريك النص هناك تحكمان مرتبطان:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextanimation/#getBuildType--) يحدد ما إذا كانت الفقرات تظهر معًا أو على مستوى الفقرة.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getAnimateTextType--) يحدد ما إذا كان النص يظهر مرة واحدة، كلمة بكلمة، أو حرف بحرف. يحدد [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) التأخير بين الكلمات أو الحروف. القيمة الموجبة هي نسبة مئوية من مدة التأثير؛ القيمة السلبية هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل مربع نص. يعرّض [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/buildtype/#AsOneObject) بناءً على الفقرة الواحدة بحيث ينطبق إعداد الكلمة على الإطار النصي كاملًا.

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

لبناء مربع نص وفقًا للفقرات، عيّن [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ar/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثيرها الخاص، استخدم التحميل الزائد لـ [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) الذي يقبل [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/). راجع [النص المتحرك](/slides/ar/java/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- حفظ إلى PPT أو PPTX يحتفظ بنموذج الرسوم المتحركة، ولكن تشغيل العرض النهائي يتحكم به عارض العروض.
- PDF والصور الثابتة لا تشغل الرسوم المتحركة. استخدم [تصدير HTML5](/slides/ar/java/export-to-html5/)، GIF متحرك، أو [تحويل إلى فيديو](/slides/ar/java/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- في حالة HTML5، فعّل [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) وعند الحاجة [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- تصيير الفيديو يدعم العديد من تأثيرات الدخول، التأكيد، الخروج، ومسار الحركة الشائعة، لكن ليس كل تأثير في PowerPoint مدعومًا. تحقق من [القائمة الحالية للتأثيرات والرسوم المتحركة المدعومة](/slides/ar/java/convert-powerpoint-to-video/#supported-animations-and-effects) واختبر العروض الحرجة مع نسخة Aspose.Slides التي تستخدمها.
- قد تُحفظ التأثيرات المخصصة المتقدمة أو تلك المستوردة من صيغ عروض تقديمية أخرى في الملف لكن تُعرض بصورة مختلفة في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة الشائعة**

**لماذا يظهر تأثير الرسوم المتحركة في PowerPoint لكن ليس في PDF؟**

PDF هو تنسيق ثابت، لذا لا تُشغل الرسوم المتحركة ولا انتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يلزم الحفاظ على الحركة.

**لماذا يتم تشغيل تأثير بشكل مختلف في الفيديو؟**

تصدير الفيديو يُعيد إنشاء الرسوم المتحركة بدلاً من حفظ سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو تُقرب. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل تغيير موضع الشكل إلى الأمام أو الخلف يغيّر ترتيب الرسوم المتحركة؟**

لا. يتحكم ترتيب الـ z للShapes في التداخل، بينما يتحكم ترتيب التسلسل والمُشغّلات في تشغيل الرسوم المتحركة. غيّر المخطط الزمني إذا احتجت ترتيب تشغيل مختلف.