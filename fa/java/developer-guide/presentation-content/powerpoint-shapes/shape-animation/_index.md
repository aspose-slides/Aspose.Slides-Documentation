---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از جاوا
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/java/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن‌های انیمیشنی را با Aspose.Slides برای جاوا اضافه، بررسی و سفارشی کنید."
---
## **بررسی کلی**

Aspose.Slides for Java انیمیشن‌های اسلاید را به‌صورت اثرها در یک خط‌زمانی اسلاید نمایش می‌دهد. یک اثر شامل شکل هدف، نوع و زیرنوع انیمیشن، ماشه، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

خط‌زمانی دو نوع دنباله دارد:

- **دنبالهٔ اصلی** هنگام پیش‌برد اسلاید اجرا می‌شود.
- **دنبالهٔ تعاملی** زمانی شروع می‌شود که شکل ماشه‌اش کلیک شود.

چون جعبه‌های متنی، تصاویر، نمودارها، جدول‌ها و سایر اشیای اسلاید پیاده‌سازی می‌شوند [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/)، برای بیش‌تر محتوای اسلاید از همان متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) استفاده می‌کنید. اثرهای موجود در کلاس [EffectType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن به شکل‌ها**

برای افزودن یک انیمیشن، دنبالهٔ اصلی اسلاید را دریافت کنید و متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) را با شکل هدف، نوع اثر، زیرنوع و ماشه فراخوانی کنید. برای اثری که هنگام کلیک یک شکل دیگر شروع می‌شود، یک دنبالهٔ تعاملی ایجاد کنید که ماشه‌اش همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در `shape-animations.pptx` ذخیره می‌کند.

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

ماشه مشخص می‌کند اثر چه زمانی شروع شود:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttriggertype/#OnClick) برای کلیک در دنبالهٔ اصلی یا کلیک روی شکل ماشه در یک دنبالهٔ تعاملی صبر می‌کند.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttriggertype/#WithPrevious) همزمان با اثر قبلی شروع می‌شود.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttriggertype/#AfterPrevious) پس از پایان اثر قبلی آغاز می‌شود.

برای انیمیشن یک تصویر، نمودار یا هر نوع شکل دیگری، به‌جای `targetShape` همان شی را به متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) پاس بدهید. برای گزینه‌های گروه‌بندی مخصوص نمودار، به [Animated Charts](/slides/fa/java/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

زمانی که شکل هدف را می‌دانید، از [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) استفاده کنید. برای بررسی تمام اثرها، هر دنبالهٔ اصلی و هر دنبالهٔ تعاملی را پیمایش کنید. پیمایش از این‌گونه فرض جلوگیری می‌کند که در ایندکس `0` حتماً یک اثر وجود داشته باشد.

مثال زیر یک شکل با اثرهای دنبالهٔ اصلی و تعاملی ایجاد می‌کند، اثرهای هدف‌شکل را دریافت می‌کند و سپس تمام دنباله‌ها را در اسلاید پیمایش می‌کند.

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

اگر فقط به اثرهای یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع جای‌نگهدار یا ویژگی ثابت دیگری شناسایی کنید؛ سپس متد [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) را فراخوانی کنید. فرض نکنید که [IShapeCollection.get_Item](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#get_Item-int-) در ایندکس `0` همیشه شی مورد نظر است.

## **کار با اثرهای جای‌نگهدار وراثتی**

یک جای‌نگهدار در اسلاید عادی می‌تواند رفتار انیمیشنی خود را از جای‌نگهدار متناظر در اسلاید لایه‌بندی و اسلاید اصلی به ارث ببرد. متد [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getBasePlaceholder--) همان جای‌نگهدار والد را برمی‌گرداند یا `null` وقتی والد وجود نداشته باشد.

در ارائهٔ مثال زیر، پاورقی در اسلاید عادی دارای **Random Bars**، در اسلاید لایه‌بندی **Split** و در اسلاید اصلی **Fly In** دارد.

![انیمیشن اثر پاورقی در اسلاید عادی](slide-shape-animation.png)

![انیمیشن اثر جای‌نگهدار پاورقی در اسلاید لایه‌بندی](layout-shape-animation.png)

![انیمیشن اثر جای‌نگهدار پاورقی در اسلاید اصلی](master-shape-animation.png)

مثال بعدی از سلسله مراتب جای‌نگهدارها در یک ارائهٔ جدید استفاده می‌کند. اثرهایی به یک جای‌نگهدار اصلی، یک جای‌نگهدار لایه‌بندی و جای‌نگهدار متناظر در اسلاید عادی اضافه می‌شود. هر بار قبل از استفاده از شکل بازگشتی، متد [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getBasePlaceholder--) بررسی می‌شود.

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

## **تغییر زمان‌بندی انیمیشن**

دیالوگ **Timing** در پاورپوینت به ویژگی‌های [ITiming](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/) نگاشت می‌شود.

![دیالوگ Timing در پاورپوینت برای یک اثر انیمیشن](shape-animation.png)

- **Start** به [ITiming.getTriggerType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getTriggerType--) نگاشت می‌شود.
- **Duration** به [ITiming.getDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getDuration--) (بر حسب ثانیه) نگاشت می‌شود.
- **Delay** به [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getTriggerDelayTime--) (بر حسب ثانیه) نگاشت می‌شود.
- **Repeat** به [ITiming.getRepeatCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getRepeatCount--)، [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) یا [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) نگاشت می‌شود.
- **Rewind when done playing** به [ITiming.getRewind](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getRewind--) نگاشت می‌شود.

این مثال مستقل یک اثر اضافه می‌کند، زمان‌بندی آن را از طریق شی بازگشتی [ISequence.addEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگهداری مرجع بازگشتی [IEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/) از ایجاد ایندکس مجموعه غیرضروری جلوگیری می‌کند.

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

یک حالت تکرار را به‌صورت هدفمند استفاده کنید. ترکیب شمارش تکرار با پرچم «until» می‌تواند نتایج گیجی در نماگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) و [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) را تنظیم کنید و سپس [ITiming.setRepeatCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#setRepeatCount-float-) را صدا بزنید، زیرا تنظیم هر یک از پرچم‌ها حالت تکرار فعال را تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک اثر انیمیشن می‌تواند صداهای جاسازی‌شده را از طریق [IEffect.getSound](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getSound--) ارجاع دهد. متد [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) به اثر می‌گوید صداهای شروع‌شده توسط اثر قبلی را متوقف کند.

### **افزودن صدا به یک اثر**

مثال زیر انتظار دارد فایلی صوتی محلی به نام `animation-sound.wav` موجود باشد. دو اثر ایجاد می‌کند، آن فایل را به‌عنوان صدا برای اولین اثر جاسازی می‌کند و اثر دوم را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیای بازگشتی [ISequence.addEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) استفاده می‌شود، بنابراین نیازی به ایندکس دنباله نیست.

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

### **استخراج صداهای جاسازی‌شدهٔ اثر**

مثال زیر یک ارائهٔ محلی به نام `presentation-with-animation-sounds.pptx` را انتظار دارد. هر دو دنبالهٔ اصلی و تعاملی را اسکن می‌کند و همهٔ صداهای جاسازی‌شدهٔ اثر را در پوشهٔ `extracted-animation-sounds` می‌نویسد. پسوند بر پایهٔ نوع MIME صوتی که توسط [IAudio.getContentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaudio/#getContentType--) ارائه می‌شود، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [IAudio.getStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaudio/#getStream--) استفاده کنید و جریان را به فایل کپی کنید به‌جای بارگذاری کل شی در یک آرایه بایت.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از اتمام اثر چه اتفاقی برای شکل می‌افتد.

![دیالوگ گزینه‌های اثر پاورپوینت که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

کلاس [AfterAnimationType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/) امکان نگه‌داری شکل بدون تغییر، تغییر رنگ، مخفی کردن آن پس از انیمیشن یا مخفی کردن آن با کلیک بعدی را فراهم می‌کند. زمانی که نوع برابر با [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#Color) باشد، باید [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) نیز تنظیم شود.

این مثال مستقل یک اثر ایجاد می‌کند، رفتار پس از انیمیشن را از طریق شی اثر بازگشتی تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#Color) تنظیم رنگ پس از انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextanimation/#getBuildType--) تعیین می‌کند پاراگراف‌ها به‌طور همزمان یا به‌صورت پاراگرافی ظاهر شوند.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getAnimateTextType--) تعیین می‌کند متن به‌صورت یکجا، به‌صورت کلمه یا به‌صورت حرف ظاهر شود. متد [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت اثر است؛ مقدار منفی تاخیر برحسب ثانیه است.

مثال مستقل زیر کلمات موجود در یک جعبهٔ متن را انیمیشن می‌کند. [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/buildtype/#AsOneObject) ساختن به‌صورت یک شیء را غیرفعال می‌کند تا تنظیم کلمه برای تمام قاب متن اعمال شود.

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

برای ساختن جعبهٔ متن به صورت پاراگراف، [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fa/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف‌گیری یک پاراگراف منفرد با اثر خاص، از نمونهٔ overload متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) که یک [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) می‌پذیرد استفاده کنید. برای مثال‌های سطح پاراگراف به [Animated Text](/slides/fa/java/animated-text/) مراجعه کنید.

## **صادرات و نکات سازگاری**

- ذخیره‌سازی به PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط برنامهٔ نمایش ارائه کنترل می‌شود.
- PDF و تصاویر ایستا انیمیشن را پخش نمی‌کنند. هنگام نیاز به نمایش حرکت، از [صادر کردن به HTML5](/slides/fa/java/export-to-html5/)، GIF متحرک یا [تبدیل به ویدیو](/slides/fa/java/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، `Html5Options.setAnimateShapes` را فعال کنید و در صورت نیاز `Html5Options.setAnimateTransitions` را نیز تنظیم کنید.
- رندرینگ ویدیو بسیاری از اثرهای ورود، تأکید، خروج و مسیر حرکتی رایج را پشتیبانی می‌کند، اما همهٔ اثرهای پاورپوینت پشتیبانی نمی‌شوند. جدول «انیمیشن‌ها و اثرهای پشتیبانی‌شده» را بررسی کنید و ارائه‌های حیاتی را با نسخهٔ هدف Aspose.Slides خود تست کنید.
- اثرهای سفارشی پیشرفته و اثرهای وارد شده از فرمت‌های دیگر ممکن است در فایل حفظ شوند اما در پاورپوینت، HTML5 یا ویدیو به‑صورت متفاوتی رندر شوند. نتیجهٔ صادرات را اعتبارسنجی کنید نه فقط بر اساس نام اثر.

## **سوالات متداول**

**چرا یک انیمیشن در پاورپوینت ظاهر می‌شود اما در PDF نیست؟**

PDF یک فرمت ایستا است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید پخش نمی‌شوند. هنگام نیاز به حفظ حرکت، به HTML5، GIF متحرک یا ویدیو صادر کنید.

**چرا یک اثر در ویدیو به‑صورت متفاوتی اجرا می‌شود؟**

صادر به ویدیو انیمیشن‌ها را رندر می‌کند، نه رفتار اصلی پاورپوینت را ذخیره می‌نماید. برخی اثرهای پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تخمینی انجام می‌شوند. جدول اثرهای پشتیبانی‌شده را مرور کنید و پیش‌از تولید ارائهٔ واقعی را تست کنید.

**آیا جابجایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب Z‑order فقط بر هم‌پوشانی شکل‌ها تأثیر می‌گذارد، در حالی که ترتیب دنباله و ماشه‌ها بر پخش انیمیشن‌ها کنترل دارند. اگر نیاز به ترتیب پخش متفاوت دارید، خط‌زمانی را تغییر دهید.