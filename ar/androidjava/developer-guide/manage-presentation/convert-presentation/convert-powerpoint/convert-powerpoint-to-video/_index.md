---
title: تحويل PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/androidjava/convert-powerpoint-to-video/
keywords: "تحويل PowerPoint, PPT, PPTX, عرض تقديمي, فيديو, MP4, PPT إلى فيديو, PPT إلى MP4, Java, Aspose.Slides"
description: "تحويل PowerPoint إلى فيديو في Java"
---

من خلال تحويل عرض PowerPoint الخاص بك إلى فيديو، ستحصل على

* **زيادة في الوصول:** جميع الأجهزة (بغض النظر عن النظام الأساسي) مزودة بمشغلات فيديو بشكل افتراضي مقارنة بتطبيقات فتح العروض التقديمية، لذا فإن المستخدمين يجدون أنه من الأسهل فتح أو تشغيل الفيديوهات.
* **نطاق أوسع:** من خلال مقاطع الفيديو، يمكنك الوصول إلى جمهور كبير واستهدافهم بمعلومات قد تبدو مملة بخلاف ذلك في عرض تقديمي. تشير معظم الاستطلاعات والإحصائيات إلى أن الناس يشاهدون ويستهلكون مقاطع الفيديو أكثر من أشكال المحتوى الأخرى، وعادة ما يفضلون هذا المحتوى.

{{% alert color="primary" %}} 

قد ترغب في التحقق من [**محول PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لأنه تنفيذ مباشر وفعال للعملية الموصوفة هنا.

{{% /alert %}} 

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-22-11-release-notes/)، قمنا بتطبيق دعم تحويل العرض التقديمي إلى فيديو.

* استخدم **Aspose.Slides** لإنشاء مجموعة من الإطارات (من الشرائح التقديمية) التي تتوافق مع FPS معين (الإطارات في الثانية)
* استخدم أداة خارجية مثل **ffmpeg** ([للجافا](https://github.com/bramp/ffmpeg-cli-wrapper)) لإنشاء فيديو بناءً على الإطارات.

### **تحويل PowerPoint إلى فيديو**

1. أضف هذا إلى ملف POM الخاص بك:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. قم بتحميل ffmpeg [هنا](https://ffmpeg.org/download.html).

4. قم بتشغيل كود Java لتحويل PowerPoint إلى فيديو.

يظهر هذا الكود بك من Java كيفية تحويل عرض تقديمي (يحتوي على شكل وصفتين مؤثرات الحركة) إلى فيديو:

```java
Presentation presentation = new Presentation();
try {
    // تضيف شكل ابتسامة ثم تقوم بتحريكه
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

    // قم بتكوين مجلد ثنائيات ffmpeg. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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

يمكنك تطبيق الرسوم المتحركة على الأشياء في الشرائح واستخدام الانتقالات بين الشرائح.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على هذه المقالات: [رسوم متحركة PowerPoint](https://docs.aspose.com/slides/androidjava/powerpoint-animation/)، [رسوم متحركة الشكل](https://docs.aspose.com/slides/androidjava/shape-animation/)، و [تأثير الشكل](https://docs.aspose.com/slides/androidjava/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات العروض التقديمية أكثر جاذبية واهتمامًا - ويفعلون الشيء نفسه للفيديوهات. دعنا نضيف شريحة أخرى وانتقالًا إلى الكود الخاص بالعرض السابق:

```java
// تضيف شكل ابتسامة ثم تقوم بتحريكه

// ...

// تضيف شريحة جديدة وانتقالًا متحركًا

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على الأشياء، والتي ستظهر واحدة تلو الأخرى (مع تعيين التأخير إلى ثانية):

```java
Presentation presentation = new Presentation();
try {
    // تضيف نصًا وحركات
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("تحويل عرض PowerPoint النصي إلى فيديو"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("فقرة تلو الأخرى"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

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

    // قم بتكوين مجلد ثنائيات ffmpeg. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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

لتمكينك من أداء مهام تحويل PowerPoint إلى فيديو، يقدم Aspose.Slides [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) و [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) كلاس.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) يسمح لك بتعيين حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) من خلال بنائه. إذا قمت بتمرير نسخة من العرض التقديمي، سيتم استخدام `Presentation.SlideSize` ويولد الرسوم المتحركة التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/).

عندما يتم إنشاء الرسوم المتحركة، يتم إنشاء حدث `NewAnimation` لكل رسوم متحركة لاحقة، والذي لديه معلمة [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/). هذا الأخير هو فئة تمثل مشغلًا لرسوم متحركة منفصلة.

للتعامل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/)، يتم استخدام خاصية [Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (المدة الكاملة للرسوم المتحركة) وطريقة [SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). يتم تعيين كل موضع رسوم متحركة ضمن نطاق *0 إلى المدة*، ثم ستعيد طريقة `GetFrame` BufferedImage تتوافق مع حالة الرسوم المتحركة في تلك اللحظة:

```java
Presentation presentation = new Presentation();
try {
    // تضيف شكل ابتسامة ثم تقوم بتحريكه
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
            System.out.println(String.format("المدة الإجمالية للرسوم المتحركة: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // حالة الرسوم المتحركة الأولية
            try {
                // حالة الرسوم المتحركة الأولية bitmap
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // الحالة النهائية للرسوم المتحركة
            try {
                // آخر إطار للرسوم المتحركة
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

لجعل جميع الرسوم المتحركة في عرض تقديمي تلعب مرة واحدة، يتم استخدام فئة [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/). تأخذ هذه الفئة حالة [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) و FPS للتأثيرات في بنائها ثم تستدعي الحدث `FrameTick` لجميع الرسوم المتحركة للحصول على تشغيلها:

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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
} finally {
    if (presentation != null) presentation.dispose();
}
```

ثم يمكن تجميع الإطارات الناتجة لإنتاج فيديو. راجع قسم [تحويل PowerPoint إلى فيديو](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة والتأثيرات المدعومة**

**الدخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظهور** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الدخول محلقًا** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الدخول طافي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عجلة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شريط عشوائي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تكبير وتدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تدوير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**التأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **نبض** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **نبض اللون** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **توازن** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تكبير/تصغير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تخفيف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تظليل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **إضاءة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **شفافية** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الكائن** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون مكمّل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الخط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون التعبئة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**الخروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **خروج طائر** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **خروج طافي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شريط عشوائي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تصغير ودوران** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تدوير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مسارات الحركة:**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أقواس** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تقلبات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشكال** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دواليب** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسار مخصص** | ![مدعوم](v.png) | ![مدعوم](v.png) |