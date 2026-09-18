---
title: اعمال انیمیشن شکل‌ها در ارائه‌ها بر روی Android
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/androidjava/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل متحرک
- متن انیمیشنی
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "بیاموزید چگونه انیمیشن‌های شکل را اضافه، بازرسی و سفارشی‌سازی کنید، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن انیمیشنی را با Aspose.Slides برای Android از طریق Java."
---
## **مرور کلی**

برای کار با رفتارهای فردی داخل یک اثر یا ویرایش بخش‌های مسیر حرکت، به [Custom Animation for Java](/slides/fa/java/custom-animation/) مراجعه کنید.

Aspose.Slides برای Android از طریق Java انیمیشن‌های اسلاید را به‌عنوان اثرها در یک جدول زمانی اسلاید نمایش می‌دهد. یک اثر شامل شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول زمانی دو نوع توالی را شامل می‌شود:

- توالی **اصلی** هنگام پیشروی اسلاید اجرا می‌شود.
- توالی **تعاملی** زمانی شروع می‌شود که شکل محرک آن کلیک شود.

از آنجا که جعبه‌های متن، تصاویر، نمودارها، جدول‌ها و سایر اشیای اسلاید [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) را پیاده‌سازی می‌کنند، برای بیشتر محتوای اسلاید از همان متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) استفاده می‌کنید. اثرهای موجود در کلاس [EffectType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن به اشکال**

برای افزودن یک انیمیشن، توالی اصلی اسلاید را دریافت کنید و متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) را با شکل هدف، نوع اثر، زیرنوع و محرک صدا بزنید. برای یک اثر که هنگام کلیک روی شکل دیگری شروع می‌شود، یک توالی تعاملی ایجاد کنید که محرکش همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در `shape-animations.pptx` ذخیره می‌گردد.

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

محرک تعیین می‌کند که یک اثر چه زمانی شروع شود:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttriggertype/#OnClick) منتظر کلیک در توالی اصلی یا کلیک روی شکل محرک در توالی تعاملی می‌ماند.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) همزمان با اثر قبلی شروع می‌شود.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) زمانی که اثر قبلی تمام می‌شود، شروع می‌شود.

برای انیمیشن یک تصویر، نمودار یا نوع دیگری از شکل، به جای `targetShape` آن شیء را به [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) پاس می‌دهید. برای گزینه‌های گروه‌بندی خاص نمودارها، به [Animated Charts](/slides/fa/androidjava/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

از [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) زمانی که شکل هدف را می‌دانید استفاده کنید. برای بررسی هر اثر، توالی اصلی و تمام توالی‌های تعاملی را مرور کنید. مرور (enumeration) از فرض داشتن یک اثر در ایندکس `0` جلوگیری می‌کند.

مثال زیر یک شکل با اثرهای توالی اصلی و تعاملی ایجاد می‌کند، اثرهایی که هدف آن شکل هستند را دریافت می‌کند و سپس تمام توالی‌های موجود در اسلاید را مرور می‌کند.

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

اگر فقط به اثرهای یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع placeholder یا ویژگی پایدار دیگری شناسایی کنید؛ سپس [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) را فراخوانی کنید. فرض نکنید که [IShapeCollection.get_Item](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) در ایندکس `0` همیشه شیء مورد نظر است.

## **کار با اثرهای Placeholder ارث‌بری شده**

یک placeholder روی یک اسلاید عادی می‌تواند رفتار انیمیشن را از placeholder متناظر روی اسلاید طرح‌بندی و اسلاید اصلی به ارث ببرد. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) آن placeholder والد را برمی‌گرداند یا وقتی والد وجود نداشته باشد `null`.

در ارائه مثال زیر، پابرگ دارای **Random Bars** روی اسلاید عادی، **Split** روی اسلاید طرح‌بندی، و **Fly In** روی اسلاید اصلی است.

![اثر انیمیشن پابرگ در اسلاید عادی](slide-shape-animation.png)

![اثر انیمیشن placeholder پابرگ در اسلاید طرح‌بندی](layout-shape-animation.png)

![اثر انیمیشن placeholder پابرگ در اسلاید اصلی](master-shape-animation.png)

مثال بعدی از یک سلسله‌مراتبی placeholder در یک ارائه جدید استفاده می‌کند. اثرهایی به یک placeholder اصلی، یک placeholder طرح‌بندی و placeholder متناظر در اسلاید عادی اضافه می‌کند. هر فراخوانی به [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) پیش از استفاده از شکل برگردانده شده بررسی می‌شود.

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

پنجره **Timing** در PowerPoint به ویژگی‌های [ITiming](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/) نگاشت می‌شود.

![پنجره Timing در PowerPoint برای یک اثر انیمیشن](shape-animation.png)

- **شروع** به [ITiming.getTriggerType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getTriggerType--) نگاشت می‌شود.
- **مدت** به [ITiming.getDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getDuration--) ، بر حسب ثانیه، نگاشت می‌شود.
- **تاخیر** به [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) ، بر حسب ثانیه، نگاشت می‌شود.
- **تکرار** به [ITiming.getRepeatCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatCount--)، [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) یا [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) نگاشت می‌شود.
- **پس از پایان پخش به عقب برگرداندن** به [ITiming.getRewind](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRewind--) نگاشت می‌شود.

این مثال مستقل یک اثر اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگشتی توسط [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه داشتن مرجع بازگشتی [IEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/) از یک ایندکس‌گذاری غیرضروری جمع‌آوری جلوگیری می‌کند.

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

به‌صورت عمدی فقط از یک حالت تکرار استفاده کنید. ترکیب یک شمارش تکرار با پرچم «until» می‌تواند نتایج گیج‌کننده‌ای در نمایشگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، قبل از [ITiming.setRepeatCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) ابتدا [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) و [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) را تنظیم کنید، زیرا تنظیم هر یک از پرچم‌ها حالت فعال تکرار را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک اثر انیمیشن می‌تواند از طریق [IEffect.getSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getSound--) به صداهای توکار ارجاع دهد. [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) به یک اثر می‌گوید صداهای شروع‌شده توسط اثر قبلی را متوقف کند.

### **افزودن صدا به یک اثر**

مثال زیر انتظار دارد یک فایل صوتی محلی به نام `animation-sound.wav` وجود داشته باشد. دو اثر ایجاد می‌کند، آن فایل را به‌عنوان صدا برای اولین اثر توکار می‌کند و اثر دوم را تنظیم می‌کند تا صدا را متوقف کند. از اشیای بازگشتی توسط [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) استفاده می‌کند، بنابراین نیازی به ایندکس توالی نیست.

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

### **استخراج صداهای توکار اثر**

مثال زیر انتظار دارد یک ارائه محلی به نام `presentation-with-animation-sounds.pptx` وجود داشته باشد. هر دو توالی اصلی و تعاملی را اسکن می‌کند و تمام صداهای توکار اثرها را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند از نوع MIME صوتی که توسط [IAudio.getContentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudio/#getContentType--) ارائه شده انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [IAudio.getStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudio/#getStream--) استفاده کنید و به‌جای بارگذاری کل شیء در یک آرایه بایت، جریان را به یک فایل کپی کنید.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از پایان اثر، چه اتفاقی برای شکل می‌افتد.

![پنجره تنظیمات گزینه‌های اثر PowerPoint که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

کلاس [AfterAnimationType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/) پشتیبانی می‌کند از عدم تغییر شکل، تغییر رنگ آن، مخفی کردن آن پس از انیمیشن، یا مخفی کردن آن در کلیک بعدی. هنگامی که نوع برابر با [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#Color) باشد، همچنین [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) را تنظیم کنید.

این مثال مستقل یک اثر ایجاد می‌کند، رفتار پس از انیمیشن آن را از طریق شیء اثر بازگشتی تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#Color) تنظیم رنگ پس از انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextanimation/#getBuildType--) تعیین می‌کند که پاراگراف‌ها به‌صورت همزمان یا به‌سطح پاراگراف ظاهر شوند.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) تعیین می‌کند که متن به‌صورت یک‌باره، به‌واحد کلمه یا به‌واحد حرف ظاهر شود. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت اثر است؛ مقدار منفی تاخیر برحسب ثانیه.

مثال مستقل زیر کلمات داخل یک جعبه متن را انیمیشن می‌کند. [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/buildtype/#AsOneObject) ساختن به‌صورت پاراگراف به پاراگراف را غیرفعال می‌کند تا تنظیم کلمه برای تمام قاب متن اعمال شود.

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

برای ساختن یک جعبه متن به‌صورت پاراگراف، [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف‌گیری یک پاراگراف واحد با اثر خاص خود، از overload متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) که یک [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) می‌پذیرد استفاده کنید. برای مثال‌های سطح پاراگراف به [Animated Text](/slides/fa/androidjava/animated-text/) مراجعه کنید.

## **نکات خروجی و سازگاری**

- ذخیره به‌صورت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نرم‌افزار نمایش‌دهنده ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن‌ها را پخش نمی‌کنند. هنگامی که خروجی باید حرکت را نشان دهد، از [HTML5 export](/slides/fa/androidjava/export-to-html5/)، GIF متحرک یا [video conversion](/slides/fa/androidjava/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) را فعال کنید و در صورت نیاز [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) را نیز فعال کنید.
- رندر ویدئو از بسیاری از اثرهای ورودی، تأکیدی، خروجی و مسیر حرکت معمول پشتیبانی می‌کند، اما همه اثرهای PowerPoint پشتیبانی نمی‌شوند. [supported animations and effects](/slides/fa/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) فعلی را بررسی کنید و ارائه‌های حیاتی را با نسخه هدف Aspose.Slides خود تست کنید.
- اثرهای سفارشی پیشرفته و اثرهایی که از قالب‌های ارائه دیگر وارد شده‌اند ممکن است در فایل حفظ شوند اما در PowerPoint، HTML5 یا ویدئو به‌صورت متفاوتی رندر شوند. به‌جای تکیه صرف بر نام اثر، نتیجه خروجی را اعتبارسنجی کنید.

## **FAQ**

**چرا یک انیمیشن در PowerPoint ظاهر می‌شود اما در PDF نیست؟**

PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. هنگامی که نیاز به حفظ حرکت دارید، به HTML5، GIF متحرک یا ویدئو صادر کنید.

**چرا یک اثر در ویدئو به‌طوری متفاوت اجرا می‌شود؟**

صادرکردن به‌صورت ویدئو، انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی PowerPoint را ذخیره کند. برخی اثرهای پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تخمینی اعمال می‌شوند. جدول اثرهای پشتیبانی‌شده را بررسی کنید و ارائه واقعی را پیش از استفاده در تولید تست نمایید.

**آیا جابجایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب z-order شکل فقط نحوه هم‌پوشانی را کنترل می‌کند، در حالی که ترتیب توالی و محرک‌ها پخش انیمیشن را تعیین می‌کنند. اگر نیاز به ترتیب پخش متفاوت دارید، جدول زمانی را تغییر دهید.