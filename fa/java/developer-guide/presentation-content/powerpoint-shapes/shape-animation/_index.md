---
title: افزودن انیمیشن‌های شکل در ارائه‌ها با استفاده از جاوا
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
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه انیمیشن‌های شکل را اضافه، بررسی و سفارشی‌سازی کنید، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن‌های متحرک را با Aspose.Slides برای جاوا."
---
## **نمای کلی**

برای کار با رفتارهای فردی داخل یک افکت یا ویرایش بخش‌های مسیر‑حرکتی، به [Custom Animation](/slides/fa/java/custom-animation/) مراجعه کنید.

Aspose.Slides for Java انیمیشن‌های اسلاید را به عنوان اثرها در یک خط زمان اسلاید نمایش می‌دهد. یک اثر دارای شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

خط زمان دو نوع دنباله دارد:

- **دنباله اصلی** در حین پیشروی اسلاید اجرا می‌شود.
- **دنباله تعاملی** زمانی که شکل محرک آن کلیک شود، شروع می‌شود.

چون جعبه‌های متن، تصاویر، نمودارها، جداول و سایر اشیاء اسلاید [IShape] را پیاده‌سازی می‌کنند، برای اکثر محتوای اسلاید از همان روش [ISequence.addEffect] استفاده می‌کنید. اثرهای موجود در کلاس [EffectType] فهرست شده‌اند.

## **افزودن انیمیشن‌ شکل‌ها**

برای افزودن انیمیشن، دنباله اصلی اسلاید را دریافت کنید و [ISequence.addEffect] را با شکل هدف، نوع اثر، زیرنوع و محرک صدا بزنید. برای اثری که با کلیک یک شکل دیگر شروع می‌شود، یک دنباله تعاملی بسازید که محرک آن همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در `shape-animations.pptx` ذخیره می‌نماید.

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

محرک تعیین می‌کند اثر چه‌وقت شروع شود:

- [EffectTriggerType.OnClick] صبر می‌کند تا کلیکی در دنباله اصلی یا روی شکل محرک در دنباله تعاملی رخ دهد.
- [EffectTriggerType.WithPrevious] با اثر قبلی شروع می‌شود.
- [EffectTriggerType.AfterPrevious] وقتی اثر قبلی تمام می‌شود، شروع می‌شود.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگری، به‌جای `targetShape` آن شیء را به [ISequence.addEffect] بدهید. برای گزینه‌های گروه‌بندی مخصوص نمودارها، به [Animated Charts](/slides/fa/java/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌ شکل‌ها**

هنگامی که شکل هدف را می‌دانید، از [ISequence.getEffectsByShape] استفاده کنید. برای بررسی هر اثر، تمام دنباله‌های اصلی و تعاملی را مرور کنید. این مرور از فرض وجود اثر در ایندکس 0 جلوگیری می‌کند.

مثال زیر یک شکل با اثرهای دنباله اصلی و تعاملی می‌سازد، اثرهای هدف‌دار به آن شکل را دریافت می‌کند و سپس تمام دنباله‌های اسلاید را مرور می‌کند.

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

اگر فقط به اثرهای یک شکل نیاز دارید، ابتدا شکل را با نام، نوع جای‌دار یا ویژگی ثابت دیگری شناسایی کنید؛ سپس [ISequence.getEffectsByShape] را صدا بزنید. فرض نکنید [IShapeCollection.get_Item] در ایندکس 0 همیشه شیء موردنظر است.

## **کار با اثرهای جای‌دار ارث‌برده**

یک جای‌دار در اسلاید معمولی می‌تواند رفتار انیمیشن را از جای‌دار متناظر در اسلاید طرح و اسلاید مادر ارث‌بگیرد. [IShape.getBasePlaceholder] والد آن را برمی‌گرداند یا زمانی که والد وجود نداشته باشد null بر می‌گرداند.

در ارائهٔ زیر، پابرگ دارای **Random Bars** در اسلاید معمولی، **Split** در اسلاید طرح و **Fly In** در اسلاید مادر است.

![اثر انیمیشن پابرگ در اسلاید معمولی](slide-shape-animation.png)

![اثر انیمیشن جای‌دار پابرگ در اسلاید طرح](layout-shape-animation.png)

![اثر انیمیشن جای‌دار پابرگ در اسلاید مادر](master-shape-animation.png)

مثال بعدی یک سلسله مراتب جای‌دار را از یک ارائهٔ جدید استفاده می‌کند. اثرهایی به یک جای‌دار مادر، یک جای‌دار طرح و جای‌دار متناظر در اسلاید معمولی اضافه می‌شود. هر بار قبل از استفاده از شکل بازگشتی، [IShape.getBasePlaceholder] بررسی می‌شود.

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

دیالوگ **Timing** در PowerPoint به ویژگی‌های [ITiming] نقشه می‌شود.

![دیالوگ زمان‌بندی PowerPoint برای یک اثر انیمیشن](shape-animation.png)

- **Start** به [ITiming.getTriggerType] نقشه می‌شود.
- **Duration** به [ITiming.getDuration] نقشه می‌شود، بر حسب ثانیه.
- **Delay** به [ITiming.getTriggerDelayTime] نقشه می‌شود، بر حسب ثانیه.
- **Repeat** به [ITiming.getRepeatCount] ، [ITiming.getRepeatUntilNextClick]  یا [ITiming.getRepeatUntilEndSlide] نقشه می‌شود.
- **Rewind when done playing** به [ITiming.getRewind] نقشه می‌شود.

این مثال مستقل یک اثر را اضافه کرده، زمان‌بندی آن را از طریق شیء بازگشتی [ISequence.addEffect] تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگهداری مرجع [IEffect] از ایجاد ایندکس‌گذاری غیرضروری جلوگیری می‌کند.

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

یک حالت تکرار را عاقلاً انتخاب کنید. ترکیب شمارش تکرار با پرچم «تا» می‌تواند نتایج گمراه‌کننده‌ای در نمایشگرهای مختلف بدهد. هنگام تغییر حالت‌های تکرار، ابتدا [ITiming.setRepeatUntilNextClick] و [ITiming.setRepeatUntilEndSlide] را تنظیم کنید و سپس [ITiming.setRepeatCount] را صدا بزنید، زیرا تنظیم هر کدام از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک اثر انیمیشن می‌تواند از طریق [IEffect.getSound] به صوتی داخلی ارجاع دهد. [IEffect.setStopPreviousSound] به اثر می‌گوید صدای شروع‌شده توسط اثر قبلی را متوقف کند.

### **افزودن صدا به یک اثر**

مثال زیر انتظار دارد فایلی صوتی محلی به نام `animation-sound.wav` وجود داشته باشد. دو اثر ایجاد می‌کند، فایل را به‌عنوان صدا برای اولین اثر می‌گیرد و تنظیم می‌کند تا اثر دوم صدا را متوقف کند. از اشیائی که توسط [ISequence.addEffect] بازگردانده می‌شوند استفاده می‌شود، بنابراین نیازی به ایندکس دنباله نیست.

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

### **استخراج صداهای اثرهای توکار**

مثال زیر یک ارائهٔ محلی به نام `presentation-with-animation-sounds.pptx` را می‌گیرد. هر دو دنبالهٔ اصلی و تعاملی را اسکن می‌کند و تمام صداهای توکار اثرها را در پوشهٔ `extracted-animation-sounds` می‌نوشت. پسوند بر اساس MIME type صوتی که توسط [IAudio.getContentType] قابل دسترس است، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [IAudio.getStream] استفاده کنید و جریان را مستقیماً به‌فایل کپی کنید، به جای بارگذاری کل شیء در یک آرایه بایت.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از پایان اثر چه اتفاقی برای شکل می‌افتد.

![دیالوگ گزینه‌های اثر PowerPoint نمایش تنظیمات After animation](shape-after-animation.png)

کلاس [AfterAnimationType] از باقی ماندن شکل بدون تغییر، تغییر رنگ، مخفی کردن پس از انیمیشن یا مخفی کردن در کلیک بعدی پشتیبانی می‌کند. وقتی نوع [AfterAnimationType.Color] است، [IEffect.getAfterAnimationColor] را نیز تنظیم کنید.

این مثال مستقل یک اثر را می‌سازد، رفتار پس‌از‑انیمیشن آن را از طریق شیء اثر بازگشتی تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType.Color] به مقدار دیگری، تنظیم رنگ پس‌از‑انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [ITextAnimation.getBuildType] تعیین می‌کند پاراگراف‌ها به‌صورت یک‌جا یا به‌سطح پاراگراف ظاهر شوند.
- [IEffect.getAnimateTextType] تعیین می‌کند متن به‌صورت یک‌جا، به‌صورت کلمه یا به‌صورت حرف ظاهر شود. [IEffect.getDelayBetweenTextParts] تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت اثر است؛ مقدار منفی تأخیر بر حسب ثانیه.

مثال مستقل زیر کلمات داخل یک جعبهٔ متن را انیمیشن می‌دهد. [BuildType.AsOneObject] ساخت پاراگراف به‌پاراگراف را غیرفعال می‌کند تا تنظیم کلمه برای تمام قاب متن اعمال شود.

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

برای ساخت جعبهٔ متن به‌صورت پاراگراف، [BuildType.ByLevelParagraphs1] (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف‌گیری یک پاراگراف منفرد با اثر خاص خود، از overload [ISequence.addEffect] که یک [IParagraph] می‌پذیرد استفاده کنید. برای مثال‌های سطح پاراگراف به [Animated Text](/slides/fa/java/animated-text/) نگاهی بیندازید.

## **نکات خروجی و سازگاری**

- ذخیره به PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط برنامهٔ نمایش ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را پخش نمی‌کنند. هنگام نیاز به حرکت، از [HTML5 export](/slides/fa/java/export-to-html5/)، GIF انیمیشن یا [video conversion](/slides/fa/java/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.setAnimateShapes] را فعال کنید و در صورت نیاز [Html5Options.setAnimateTransitions] را نیز تنظیم کنید.
- رندر ویدیو بسیاری از اثرهای ورودی، تأکید و خروجی و مسیر‑حرکتی رایج را پشتیبانی می‌کند، اما همهٔ اثرهای PowerPoint پشتیبانی نمی‌شوند. جدول [supported animations and effects](/slides/fa/java/convert-powerpoint-to-video/#supported-animations-and-effects) را بررسی کنید و ارائه‌های حیاتی را با نسخهٔ هدف Aspose.Slides آزمون کنید.
- اثرهای سفارشی پیشرفته و اثرهایی که از فرمت‌های دیگر وارد شده‌اند ممکن است در فایل حفظ شوند ولی در PowerPoint، HTML5 یا ویدیو به‌صورت متفاوتی رندر شوند. نتیجهٔ خروجی را اعتبارسنجی کنید نه فقط بر اساس نام اثر.

## **سوالات متداول**

**چرا یک انیمیشن در PowerPoint ظاهر می‌شود اما در PDF نیست؟**

PDF فرمت استاتیک است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. برای حفظ حرکت، به HTML5، GIF انیمیشن یا ویدیو خروجی دهید.

**چرا یک اثر در ویدیو متفاوت اجرا می‌شود؟**

خروجی ویدیو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی PowerPoint را ذخیره کند. برخی اثرهای پیشرفته پشتیبانی یا به‌صورت تقریبی پیاده‌سازی می‌شوند. جدول اثرهای پشتیبانی‌شده را مرور کنید و پیش از استفادهٔ تولیدی ارائه را تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

نه. ترتیب z‑order فقط برهم‌پوشانی شکل‌ها را کنترل می‌کند، در حالی که ترتیب دنباله و محرک‌ها بر پخش انیمیشن اثر دارند. اگر نیاز به ترتیب پخش متفاوت دارید، خط زمان را تغییر دهید.