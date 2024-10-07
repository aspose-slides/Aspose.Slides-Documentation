---
title: تحويل PowerPoint إلى فيديو
type: docs
weight: 130
url: /java/convert-powerpoint-to-video/
keywords: "تحويل PowerPoint، PPT، PPTX، عرض، فيديو، MP4، PPT إلى فيديو، PPT إلى MP4، Java، Aspose.Slides"
description: "تحويل PowerPoint إلى فيديو باستخدام Java"
---

باستخدام تحويل العرض التقديمي الخاص بك من PowerPoint إلى فيديو، ستحصل على

* **زيادة في إمكانية الوصول:** جميع الأجهزة (بغض النظر عن النظام) مزودة بمشغلات فيديو بشكل افتراضي مقارنة بتطبيقات فتح العروض التقديمية، لذا يجد المستخدمون أنه من الأسهل فتح أو تشغيل مقاطع الفيديو.
* **وصول أكبر:** من خلال مقاطع الفيديو، يمكنك الوصول إلى جمهور كبير واستهدافهم بمعلومات قد تبدو مملة بخلاف ذلك في عرض تقديمي. تشير معظم الاستطلاعات والإحصائيات إلى أن الناس يشاهدون ويستهلكون مقاطع الفيديو أكثر من أشكال المحتوى الأخرى، وعادة ما يفضلون هذا النوع من المحتوى.

{{% alert color="primary" %}} 

قد ترغب في التحقق من [**محول PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لأنه تنفيذ مباشر وفعال للعملية الموصوفة هنا.

{{% /alert %}} 

## **تحويل PowerPoint إلى فيديو باستخدام Aspose.Slides**

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-22-11-release-notes/)، قمنا بتنفيذ دعم تحويل العرض التقديمي إلى فيديو.

* استخدم **Aspose.Slides** لإنشاء مجموعة من الإطارات (من شرائح العرض التقديمي) التي تتوافق مع FPS معين (إطار في الثانية)
* استخدم أداة خارجية مثل **ffmpeg** ([لـ java](https://github.com/bramp/ffmpeg-cli-wrapper)) لإنشاء فيديو استنادًا إلى الإطارات. 

### **تحويل PowerPoint إلى فيديو**

1. أضف هذا إلى ملف POM الخاص بك:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. قم بتنزيل ffmpeg [هنا](https://ffmpeg.org/download.html).

4. قم بتشغيل كود Java لتحويل PowerPoint إلى فيديو.

يوضح لك هذا الكود كيفية تحويل عرض تقديمي (يحتوي على شكل وصفتين متحركتين) إلى فيديو:

```java
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

    // تكوين مجلد ثنائيات ffmpeg. انظر هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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

يمكنك تطبيق الرسوم المتحركة على الكائنات على الشرائح واستخدام الانتقالات بين الشرائح. 

{{% alert color="primary" %}} 

قد ترغب في مشاهدة هذه المقالات: [تحريك PowerPoint](https://docs.aspose.com/slides/java/powerpoint-animation/)، [تحريك الشكل](https://docs.aspose.com/slides/java/shape-animation/)، و[تأثير الشكل](https://docs.aspose.com/slides/java/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات عروض الشرائح أكثر جاذبية وإثارة للاهتمام - وتفعل نفس الشيء بالنسبة لمقاطع الفيديو. دعنا نضيف شريحة أخرى وانتقال إلى الكود الخاص بالعرض التقديمي السابق:

```java
// يضيف شكل ابتسامة ويحركه

// ...

// يضيف شريحة جديدة وانتقال متحرك

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، والتي ستظهر واحدة تلو الأخرى (مع التأخير المحدد لثانية واحدة):

```java
Presentation presentation = new Presentation();
try {
    // يضيف نصوصًا ورسومًا متحركة
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("تحويل عرض PowerPoint مع النص إلى فيديو"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("فقرة بعد فقرة"));
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

    // تكوين مجلد ثنائيات ffmpeg. انظر هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **فصول تحويل الفيديو**

لتمكينك من أداء مهام تحويل PowerPoint إلى فيديو، يوفر Aspose.Slides [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) و [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) الفصول.

يسمح لك [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) بتعيين حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) من خلال منشئه. إذا قمت بتمرير مثيل للعرض التقديمي، فسيتم استخدام `Presentation.SlideSize` ويولد رسومًا متحركة تستخدمها [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/).

عند إنشاء الرسوم المتحركة، يتم إنشاء حدث `NewAnimation` لكل رسوم متحركة تالية، والتي تحتوي على معلمة [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/). هذا هو فصل يمثل مشغلًا لرسوم متحركة منفصلة.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/)، يتم استخدام خاصية [Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (المدة الكاملة للرسوم المتحركة) وطريقة [SetTimePosition](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). يتم تعيين كل موضع لرسوم متحركة ضمن نطاق *0 إلى المدة*، ثم ستعيد طريقة `GetFrame` صورة BufferedImage تتوافق مع حالة الرسوم المتحركة في تلك اللحظة:

```java
Presentation presentation = new Presentation();
try {
    // يضيف شكل ابتسامة ويحركه
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
            animationPlayer.setTimePosition(0); // الحالة الأولية للرسوم المتحركة
            try {
                // حالة الرسوم المتحركة الأولية
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // الحالة النهائية للرسوم المتحركة
            try {
                // آخر إطار من الرسوم المتحركة
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

لجعل جميع الرسوم المتحركة في عرض تقديمي تعمل في نفس الوقت، يتم استخدام فصل [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/). يأخذ هذا الفصل مثيل [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) وFPS للتأثيرات في منشئته ثم يستدعي حدث `FrameTick` لجميع الرسوم المتحركة للحصول على تشغيلها:

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

ثم يمكن تجميع الإطارات الناتجة لإنتاج فيديو. راجع قسم [تحويل PowerPoint إلى فيديو](https://docs.aspose.com/slides/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة والتأثيرات المدعومة**

**الظهور**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **الظهور** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **المجيء** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التطفو** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التقسيم** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **المسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الشكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **العجلة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الأشرطة العشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو وتدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الدوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**التأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **النبضة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **نبضة اللون** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **الأرجوحة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الدوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **النمو / الانكماش** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **التشبع** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **التغميق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **الإضاءة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **الشفافية** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الكائن** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **اللون التكميلي** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الخط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون التعبئة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**المغادرة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **الاختفاء** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **المغادرة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الطفو للخارج** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التقسيم** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **المسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الشكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الأشرطة العشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انكماش وتدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الدوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مسارات الحركة:**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **اقواس** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تحولات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشكال** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **حلقات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسار مخصص** | ![مدعوم](v.png) | ![مدعوم](v.png) |