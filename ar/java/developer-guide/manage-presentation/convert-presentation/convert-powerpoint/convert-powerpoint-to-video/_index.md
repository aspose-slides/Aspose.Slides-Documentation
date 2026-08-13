---
title: تحويل عروض PowerPoint إلى فيديو في Java
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/java/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى فيديو
- العرض إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- العرض إلى MP4
- PPT إلى MP4
- PPTX إلى MP4
- حفظ PPT كـ MP4
- حفظ PPTX كـ MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- Java
- Aspose.Slides
description: "تعرف على كيفية تحويل عروض PowerPoint إلى فيديو باستخدام Java. اكتشف عينات الشيفرة وتقنيات الأتمتة لتبسيط سير العمل الخاص بك."
---
## **المقدمة**

بإجراء تحويل عرض PowerPoint أو OpenDocument إلى فيديو، ستحصل على:

**زيادة القدرة على الوصول:** جميع الأجهزة، بغض النظر عن النظام الأساسي، مزودة بمشغلات الفيديو بشكل افتراضي، مما يسهل على المستخدمين فتح الفيديوهات أو تشغيلها مقارنةً بتطبيقات العروض التقديمية التقليدية.

**نطاق أوسع:** تمكّنك الفيديوهات من الوصول إلى جمهور أكبر وتقديم المعلومات بصيغة أكثر جاذبية. تشير الاستطلاعات والإحصاءات إلى أن الناس يفضّلون مشاهدة واستهلاك محتوى الفيديو على الأشكال الأخرى، مما يجعل رسالتك أكثر تأثيرًا.

{{% alert color="info" %}} 

قد ترغب في تجربة [**محوّل PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/ar/video) لأنه تنفيذ حي وفعال للعملية الموصوفة هنا.

{{% /alert %}} 

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/ar/java/aspose-slides-for-java-22-11-release-notes/)، نفّذنا دعم تحويل العرض إلى فيديو. 

* استخدم **Aspose.Slides** لإنشاء مجموعة من الإطارات (من شرائح العرض) التي تتطابق مع عدد محدد من الإطارات في الثانية (FPS)
* استخدم أداة طرف ثالث مثل **ffmpeg** ([لـ java](https://github.com/bramp/ffmpeg-cli-wrapper)) لإنشاء فيديو استنادًا إلى الإطارات. 

### **تحويل PowerPoint إلى فيديو**

1. أضف هذا إلى ملف POM الخاص بك:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. حمّل ffmpeg [هنا](https://ffmpeg.org/download.html).

4. شغّل كود Java لتحويل PowerPoint إلى فيديو.

يظهر لك كود Java هذا كيفية تحويل عرض (يتضمن شكل وتأثيري تحريك) إلى فيديو:

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

    // تكوين مجلد ملفات ffmpeg الثنائية. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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

يمكنك تطبيق التحريكات على العناصر في الشرائح واستخدام الانتقالات بين الشرائح. 

{{% alert color="info" %}} 

قد ترغب في الاطلاع على هذه المقالات: [PowerPoint Animation](https://docs.aspose.com/slides/ar/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/ar/java/shape-animation/), و[Shape Effect](https://docs.aspose.com/slides/ar/java/shape-effect/).

{{% /alert %}} 

تجعل التحريكات والانتقالات عروض الشرائح أكثر جاذبية وإثارة — وتقوم بنفس الشيء للفيديوهات. دعنا نضيف شريحة أخرى وانتقالًا إلى الكود للعرض السابق:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // يضيف شكل ابتسامة ويحركه

    // ...

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

يدعم Aspose.Slides أيضًا التحريك للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، التي ستظهر واحدة تلو الأخرى (مع تأخير ثانية واحدة):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // يضيف نصًا وتحريكات
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
    paragraphCollection.add(new Paragraph());

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

## **فئات تحويل الفيديو**

للسموح لك بأداء مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides الفئات [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationanimationsgenerator/) يتيح لك تعيين حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) عبر المُنشئ الخاص به. إذا مررت كائنًا من العرض، سيُستخدم `Presentation.SlideSize` وتُنشئ التحريكات التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationplayer/).

عند إنشاء التحريكات، يتم إنشاء حدث `NewAnimation` لكل تحريك لاحق، والذي يحتوي على معامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationanimationplayer/). الأخير هو فئة تمثل مشغلاً لتحريك منفصل.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationanimationplayer/)، تُستخدم خاصية [Duration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (المدة الكاملة للتحريك) وطريقة [SetTimePosition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). يتم تعيين موضع كل تحريك ضمن النطاق *0 إلى المدة*، ثم تُرجع طريقة `getFrame` كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) الذي يتطابق مع حالة التحريك في تلك اللحظة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // يضيف شكلاً على هيئة ابتسامة ويحركه
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

            animationPlayer.setTimePosition(0); // حالة التحريك الأولية
            // صورة bitmap لحالة التحريك الأولية
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // الحالة النهائية للتحريك
            // الإطار الأخير للتحريك
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // توليد التحريكات - هذا هو ما يطلق الأحداث التي تم التعامل معها أعلاه
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

لجعل جميع التحريكات في عرض ما تُلعب مرة واحدة، يتم استخدام فئة [PresentationPlayer]. تأخذ هذه الفئة كائنًا من [PresentationAnimationsGenerator] وعدد FPS للتأثيرات في مُنشئها ثم تستدعي حدث `FrameTick` لجميع التحريكات لتشغيلها:

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

ثم يمكن تجميع الإطارات المُولَّدة لإنتاج فيديو. راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/ar/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **التحريكات والتأثيرات المدعومة**

**الدخول**:

| نوع التحريك | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**التأكيد**:

| نوع التحريك | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**الخروج**:

| نوع التحريك | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**مسارات الحركة**:

| نوع التحريك | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة الشائعة**

### هل من الممكن تحويل العروض المحمية بكلمة مرور؟

نعم، يسمح Aspose.Slides بالعمل مع [العروض المحمية بكلمة مرور](/slides/ar/java/password-protected-presentation/). عند معالجة مثل هذه الملفات، تحتاج إلى تقديم كلمة المرور الصحيحة حتى تتمكن المكتبة من الوصول إلى محتوى العرض.

### هل يدعم Aspose.Slides الاستخدام في حلول السحابة؟

نعم، يمكن دمج Aspose.Slides في تطبيقات وخدمات السحابة. صُممت المكتبة للعمل في بيئات الخوادم، مما يضمن أداءً عاليًا وقابلية توسع لمعالجة الملفات على دفعات.

### هل هناك أي قيود على حجم العروض أثناء التحويل؟

يمكن لـ Aspose.Slides معالجة عروض بأي حجم تقريبًا. ومع ذلك، عند العمل مع ملفات كبيرة جدًا، قد تحتاج إلى موارد نظام إضافية، ويوصى أحيانًا بتحسين العرض لتحسين الأداء.