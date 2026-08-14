---
title: اعمال انیمیشن اشکال در ارائه‌های Android
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه انیمیشن‌های شکل را اضافه، بررسی و سفارشی‌سازی کنید، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن‌های متحرک را با Aspose.Slides برای Android از طریق Java."
---
## **نمای کلی**

Aspose.Slides for Android via Java انیمیشن‌های اسلاید را به‌عنوان افکت‌ها در جدول زمانی اسلاید نشان می‌دهد. یک افکت دارای شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و خصوصیات اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول زمانی دو نوع دنباله دارد:

- **دنباله اصلی** هنگام پیشرفت اسلاید اجرا می‌شود.
- **دنباله تعاملی** هنگامی که شکل محرک آن کلیک شود آغاز می‌شود.

چون جعبه‌های متن، تصاویر، نمودارها، جدول‌ها و سایر اشیای اسلاید رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) را پیاده‌سازی می‌کنند، برای اکثر محتوای اسلاید از همان متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) استفاده می‌کنید. افکت‌های موجود در کلاس [EffectType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن اشکال**

برای افزودن انیمیشن، دنباله اصلی اسلاید را به‌دست آورده و متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) را با شکل هدف، نوع افکت، زیرنوع و محرک فراخوانی کنید. برای افکتی که هنگام کلیک روی شکل دیگر آغاز می‌شود، یک دنباله تعاملی بسازید که محرکش همان شکل دیگر باشد.

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

محرک تعیین می‌کند افکت چه زمانی شروع شود:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttriggertype/#OnClick) برای کلیک در دنباله اصلی یا کلیک روی شکل محرک در دنباله تعاملی صبر می‌کند.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) همراه با افکت قبلی آغاز می‌شود.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) پس از اتمام افکت قبلی شروع می‌شود.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگری، به جای `targetShape` آن شیء را به متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) پاس دهید. برای گزینه‌های گروه‌بندی مخصوص نمودارها، به [Animated Charts](/slides/fa/androidjava/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های اشکال**

زمانی که شکل هدف را می‌دانید از [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) استفاده کنید. برای بررسی هر افکت، دنباله اصلی و تمام دنباله‌های تعاملی را پیمایش کنید. این پیمایش از فرض وجود افکت در اندیس `0` جلوگیری می‌کند.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را با نام، نوع جایگزین یا ویژگی ثابت دیگری شناسایی کنید؛ سپس [ISequence.getEffectsByShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) را فراخوانی کنید. فرض نکنید که [IShapeCollection.get_Item](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) در اندیس `0` همیشه شیء موردنظر است.

## **کار با افکت‌های جایگزین ارث‌برده**

یک جایگزین در اسلاید عادی می‌تواند رفتار انیمیشن را از جایگزین متناظر در اسلاید طرح‌بندی یا اسلاید اصلی به ارث ببرد. متد [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) آن جایگزین والد را برمی‌گرداند یا وقتی والد وجود نداشته باشد `null`.

در ارائه مثال زیر، پابرگ در اسلاید عادی دارای **Random Bars**، در اسلاید طرح‌بندی دارای **Split** و در اسلاید اصلی دارای **Fly In** است.

![انیمیشن پابرگ در اسلاید عادی](slide-shape-animation.png)

![انیمیشن پابرگ در اسلاید طرح‌بندی](layout-shape-animation.png)

![انیمیشن پابرگ در اسلاید اصلی](master-shape-animation.png)

مثال بعدی از سلسله‌مراتبی جایگزین در یک ارائه جدید استفاده می‌کند. افکت‌ها را به جایگزین اصلی، جایگزین طرح‌بندی و جایگزین متناظر در اسلاید عادی اضافه می‌کند. هر بار قبل از استفاده از شکل برگشتی، فراخوانی [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) بررسی می‌شود.

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

کادر گفتگوی **Timing** در PowerPoint به ویژگی‌های [ITiming](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/) مرتبط است.

![کادر گفتگوی Timing در PowerPoint برای یک افکت انیمیشن](shape-animation.png)

- **Start** به [ITiming.getTriggerType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getTriggerType--) مرتبط است.
- **Duration** به [ITiming.getDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getDuration--) مرتبط است و بر حسب ثانیه است.
- **Delay** به [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) مرتبط است و بر حسب ثانیه است.
- **Repeat** به [ITiming.getRepeatCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), یا [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) مرتبط است.
- **Rewind when done playing** به [ITiming.getRewind](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRewind--) مرتبط است.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگشتی توسط [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه داشتن مرجع [IEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/) بازگشتی از بروز شاخص غیرضروری در مجموعه جلوگیری می‌کند.

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

به‌صورت عمدی از یک حالت تکرار استفاده کنید. ترکیب شمارش تکرار با پرچم «until» می‌تواند در نمایش‌دهندگان مختلف نتایج گیج‌کننده‌ای ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) و [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) را تنظیم کنید و سپس [ITiming.setRepeatCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) را صدا بزنید، زیرا تنظیم هر یک از پرچم‌ها حالت تکرار فعال را تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند صداهای جاسازی‌شده را از طریق [IEffect.getSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getSound--) ارجاع دهد. متد [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) به افکت می‌گوید صداهای شروع‌شده توسط افکت قبلی را متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار دارد فایلی صوتی محلی به نام `animation-sound.wav` موجود باشد. دو افکت ایجاد می‌کند، آن فایل را به‌عنوان صدا برای اولین افکت جاسازی می‌کند و افکت دوم را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیای بازگشتی توسط [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) استفاده می‌کند، بنابراین نیازی به اندیس دنباله نیست.

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

### **استخراج صداهای جاسازی‌شده افکت**

مثال زیر انتظار دارد یک ارائه محلی به نام `presentation-with-animation-sounds.pptx` موجود باشد. هر دو دنباله اصلی و تعاملی را اسکن می‌کند و تمام صداهای جاسازی‌شده افکت‌ها را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند بر اساس نوع MIME صوتی که توسط [IAudio.getContentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudio/#getContentType--) ارائه می‌شود انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [IAudio.getStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudio/#getStream--) استفاده کنید و جریان را به یک فایل کپی کنید به جای اینکه کل شیء را در یک آرایه بایت بارگذاری کنید.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از اتمام افکت، چه اتفاقی برای شکل می‌افتد.

![کادر گفتگوی گزینه‌های افکت در PowerPoint که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

کلاس [AfterAnimationType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/) امکان نگه داشتن شکل بدون تغییر، تغییر رنگ آن، مخفی کردن پس از انیمیشن یا مخفی کردن در کلیک بعدی را فراهم می‌کند. وقتی نوع برابر با [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#Color) باشد، باید [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) نیز تنظیم شود.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس از انیمیشن آن را از طریق شیء افکت بازگشتی تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextanimation/#getBuildType--) تعیین می‌کند پاراگراف‌ها به‌صورت یکجا یا به‌صورت سطح پاراگراف ظاهر شوند.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) تعیین می‌کند متن به‌یکباره، به‌صورت کلمه یا به‌صورت حرف ظاهر شود. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت افکت است؛ مقدار منفی تاخیر بر حسب ثانیه است.

مثال مستقل زیر کلمات موجود در یک جعبه متن را انیمیشن می‌کند. [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/buildtype/#AsOneObject) ساخت پاراگراف به پاراگراف را غیرفعال می‌کند تا تنظیم کلمه برای تمام قاب متن اعمال شود.

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

برای ساخت جعبه متن به‌صورت پاراگراف، [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (یا سطح پاراگراف دیگر) را تنظیم کنید. برای هدف‌گذاری یک پاراگراف واحد با افکت مخصوص به آن، از نسخهٔ overload متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) که یک [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) می‌پذیرد استفاده کنید. برای مثال‌های سطح پاراگراف به [Animated Text](/slides/fa/androidjava/animated-text/) مراجعه کنید.

## **نکات صادر کردن و سازگاری**

- ذخیره به فرمت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نرم‌افزار نمایش ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را اجرا نمی‌کنند. وقتی خروجی باید حرکت را نشان دهد، از [HTML5 export](/slides/fa/androidjava/export-to-html5/)، GIF متحرک یا [video conversion](/slides/fa/androidjava/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) را فعال کنید و در صورت نیاز [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) را تنظیم کنید.
- رندر ویدئو بسیاری از افکت‌های ورودی، تأکید، خروج و مسیر حرکتی رایج را پشتیبانی می‌کند، اما همه افکت‌های PowerPoint پشتیبانی نمی‌شوند. [supported animations and effects](/slides/fa/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) فعلی را بررسی کنید و ارائه‌های مهم را با نسخه هدف Aspose.Slides خود تست کنید.
- افکت‌های سفارشی پیشرفته و افکتی که از سایر فرمت‌های ارائه وارد شده‌اند ممکن است در فایل حفظ شوند اما در PowerPoint، HTML5 یا ویدئو به‌صورت متفاوت رندر شوند. نتیجهٔ صادرشده را اعتبارسنجی کنید نه صرفاً به نام افکت اطمینان داشته باشید.

## **سوالات متداول**

**چرا یک انیمیشن در PowerPoint ظاهر می‌شود اما در PDF نیست؟**

PDF یک فرمت ایستا است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. برای حفظ حرکت، به HTML5، GIF متحرک یا ویدئو خروجی بدهید.

**چرا یک افکت در ویدئو به‌طرز متفاوتی اجرا می‌شود؟**

خروجی ویدئو انیمیشن‌ها را رندر می‌کند و رفتار اصلی PowerPoint را ذخیره نمی‌کند. برخی افکت‌های پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تخمینی اجرا می‌شوند. جدول افکت‌های پشتیبانی‌شده را مرور کنید و پیش از استفادهٔ تولیدی، ارائهٔ واقعی را تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب لایه (z-order) فقط بر هم‌پوشانی کنترل می‌کند، در حالی که ترتیب دنباله و محرک‌ها بر پخش انیمیشن تأثیر دارند. اگر به ترتیب پخش متفاوت نیاز دارید، جدول زمانی را تغییر دهید.