---
title: تحويل عروض PowerPoint إلى فيديو على Android
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/androidjava/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى فيديو
- العرض التقديمي إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- العرض التقديمي إلى MP4
- PPT إلى MP4
- PPTX إلى MP4
- حفظ PPT كـ MP4
- حفظ PPTX كـ MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint إلى فيديو باستخدام Java. اكتشف مثالاً على الكود وتقنيات أتمتة لتبسيط سير العمل الخاص بك."
---
## **المقدمة**

عن طريق تحويل عرض PowerPoint التقديمي إلى فيديو، ستحصل على 

* **زيادة في إمكانية الوصول:** جميع الأجهزة (بغض النظر عن النظام الأساسي) مجهزة بمشغلات الفيديو بشكل افتراضي مقارنةً بتطبيقات فتح العروض التقديمية، لذا يجد المستخدمون سهولة أكبر في فتح أو تشغيل الفيديوهات.
* **وصول أكبر:** من خلال الفيديوهات، يمكنك الوصول إلى جمهور كبير وتوجيههم بمعلومات قد تبدو مملة في عرض تقديمي. تشير معظم الدراسات والإحصاءات إلى أن الناس يشاهدون ويستهلكون الفيديوهات أكثر من غيرها من أنواع المحتوى، وعادةً ما يفضلون هذا النوع من المحتوى.

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

يدعم Aspose.Slides تحويل العروض التقديمية إلى فيديو.

* استخدم **Aspose.Slides** لتوليد مجموعة من الإطارات (من شرائح العرض) التي تتوافق مع معدل FPS معين (إطارات في الثانية).
* استخدم أداة طرف ثالث مثل **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) لإنشاء فيديو بناءً على الإطارات. 

### **تحويل PowerPoint إلى فيديو**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. حمّل ffmpeg [هنا](https://ffmpeg.org/download.html).

3. شغّل كود Java لتحويل PowerPoint إلى فيديو.

يعرض لك هذا الكود Java كيفية تحويل عرض تقديمي (يحتوي على رسم وشركتي تأثيرات رسوم متحركة) إلى فيديو:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // يضيف شكل ابتسامة ثم يحركه
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // تكوين مجلد ملفات ffmpeg الثنائية. انظر هذه الصفحة: https://github.com/bramp/ffmpeg-cli-wrapper
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **تأثيرات الفيديو**

يمكنك تطبيق الرسوم المتحركة على العناصر في الشرائح واستخدام الانتقالات بين الشرائح. 

{{% alert color="info" %}} 

قد ترغب في مشاهدة هذه المقالات: [PowerPoint Animation](https://docs.aspose.com/slides/ar/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/ar/androidjava/shape-animation/), و[Shape Effect](https://docs.aspose.com/slides/ar/androidjava/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات عروض الشرائح أكثر جاذبية وإثارة—وتفعل الشيء نفسه للفيديوهات. دعنا نضيف شريحة أخرى وانتقالًا إلى الكود الخاص بالعرض السابق:
```java
import com.aspose.slides.*;
import java.awt.Color;

// العرض التقديمي مع شكل الابتسامة المتحرك الذي تم إنشاؤه أعلاه.
Presentation presentation = new Presentation();
try {
    // يضيف شريحة جديدة وانتقالًا متحركًا

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على العناصر، والتي ستظهر واحدة تلو الأخرى (مع تأخير مضبوط ثانية واحدة):
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // يضيف نصًا ورسومًا متحركة
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // تكوين مجلد ملفات ffmpeg الثنائية. انظر هذه الصفحة: https://github.com/bramp/ffmpeg-cli-wrapper
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **فئات تحويل الفيديو**

للسماح لك بأداء مهام تحويل PowerPoint إلى فيديو، يقدم Aspose.Slides فئتي [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationplayer/) .

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationanimationsgenerator/) يتيح لك ضبط حجم الإطار للفيديو (والذي سيُنشأ لاحقًا) عبر المُنشئ الخاص به. إذا مررت بمثيل من العرض التقديمي، سيتم استخدام `Presentation.SlideSize` وهو يولد الرسوم المتحركة التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationplayer/) .

عند إنشاء الرسوم المتحركة، يتم توليد حدث `NewAnimation` لكل حركة متتالية، والذي يحتوي على معامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationanimationplayer/). الأخير هو فئة تمثل مشغلًا لحركة منفصلة.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationanimationplayer/), يتم استخدام خاصية [Duration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (المدة الكاملة للرسوم المتحركة) والطريقة [SetTimePosition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) . يتم ضبط كل موقع للرسوم المتحركة ضمن النطاق *0 إلى المدة*، ثم ستعيد طريقة `getFrame` كائن [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) الذي يتطابق مع حالة الرسوم المتحركة في تلك اللحظة:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // يضيف شكل ابتسامة ويُحركه
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));

            animationPlayer.setTimePosition(0); // حالة الرسوم المتحركة الأولية
            // صورة bitmap لحالة الرسوم المتحركة الأولية
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // الحالة النهائية للرسوم المتحركة
            // الإطار الأخير للرسوم المتحركة
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // توليد الرسوم المتحركة. النداء العكسي أعلاه يُنفَّذ لكل واحدة منها.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

لجعل جميع الرسوم المتحركة في عرض تقديمي تُشغل في آنٍ واحد، تُستخدم فئة [PresentationPlayer](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationplayer/) . تأخذ هذه الفئة مثيلًا من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationanimationsgenerator/) ومعدل FPS للتأثيرات في مُنشئها ثم تستدعي حدث `FrameTick` لجميع الرسوم المتحركة لتشغيلها:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

بعد ذلك يمكن تجميع الإطارات المُولدة لإنتاج فيديو. راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/ar/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) .

## **الرسوم المتحركة والتأثيرات المدعومة**

**الدخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظهور** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **طيران داخلي** | ![supported](v.png) | ![supported](v.png) |
| **طفو داخلي** | ![supported](v.png) | ![supported](v.png) |
| **تقسيم** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![supported](v.png) | ![supported](v.png) |
| **عجلة** | ![supported](v.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **نمو وتدوير** | ![not supported](x.png) | ![supported](v.png) |
| **تقريب** | ![supported](v.png) | ![supported](v.png) |
| **دوران** | ![supported](v.png) | ![supported](v.png) |
| **ارتداد** | ![supported](v.png) | ![supported](v.png) |

**التأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **نَبض** | ![not supported](x.png) | ![supported](v.png) |
| **نَبض اللون** | ![not supported](x.png) | ![supported](v.png) |
| **اهتزاز** | ![supported](v.png) | ![supported](v.png) |
| **دوران** | ![supported](v.png) | ![supported](v.png) |
| **نمو/انكماش** | ![not supported](x.png) | ![supported](v.png) |
| **إزالة التشبع** | ![not supported](x.png) | ![supported](v.png) |
| **تغميق** | ![not supported](x.png) | ![supported](v.png) |
| **تفتيح** | ![not supported](x.png) | ![supported](v.png) |
| **شفافية** | ![not supported](x.png) | ![supported](v.png) |
| **لون الكائن** | ![not supported](x.png) | ![supported](v.png) |
| **لون مكمل** | ![not supported](x.png) | ![supported](v.png) |
| **لون الخط** | ![not supported](x.png) | ![supported](v.png) |
| **لون التعبئة** | ![not supported](x.png) | ![supported](v.png) |

**الخروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **طيران خارجي** | ![supported](v.png) | ![supported](v.png) |
| **طفو خارجي** | ![supported](v.png) | ![supported](v.png) |
| **تقسيم** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![supported](v.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **انكماش وتدوير** | ![not supported](x.png) | ![supported](v.png) |
| **تقريب** | ![supported](v.png) | ![supported](v.png) |
| **دوران** | ![supported](v.png) | ![supported](v/png) |
| **ارتداد** | ![supported](v.png) | ![supported](v.png) |

**مسارات الحركة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![supported](v.png) | ![supported](v.png) |
| **أقواس** | ![supported](v.png) | ![supported](v.png) |
| **تحولات** | ![supported](v.png) | ![supported](v.png) |
| **أشكال** | ![supported](v.png) | ![supported](v.png) |
| **حلقات** | ![supported](v.png) | ![supported](v.png) |
| **مسار مخصص** | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة المتكررة**

### هل من الممكن تحويل العروض التقديمية المحمية بكلمة مرور؟

نعم، يتيح Aspose.Slides العمل مع [العروض التقديمية المحمية بكلمة مرور](/slides/ar/androidjava/password-protected-presentation/). عند معالجة مثل هذه الملفات، يجب توفير كلمة المرور الصحيحة حتى يتمكن المكتبة من الوصول إلى محتوى العرض التقديمي.

### هل يدعم Aspose.Slides الاستخدام في حلول السحابة؟

نعم، يمكن دمج Aspose.Slides في تطبيقات وخدمات السحابة. تم تصميم المكتبة للعمل في بيئات الخادم، لضمان أداء عالي وقابلية توسع لمعالجة الملفات على دفعات.

### هل هناك أي قيود على حجم العروض التقديمية أثناء التحويل؟

يستطيع Aspose.Slides معالجة العروض التقديمية بأي حجم تقريبًا. ومع ذلك، عند التعامل مع ملفات كبيرة جدًا، قد تحتاج إلى موارد نظام إضافية، وفي بعض الأحيان يُنصح بتحسين العرض التقديمي لتحسين الأداء.