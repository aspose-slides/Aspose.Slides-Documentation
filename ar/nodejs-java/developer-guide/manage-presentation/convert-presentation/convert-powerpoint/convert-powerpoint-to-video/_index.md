---
title: تحويل عروض PowerPoint إلى فيديو باستخدام JavaScript
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/nodejs-java/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى فيديو
- عرض تقديمي إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- عرض تقديمي إلى MP4
- PPT إلى MP4
- PPTX إلى MP4
- حفظ PPT كـ MP4
- حفظ PPTX كـ MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint إلى فيديو باستخدام JavaScript. اكتشف الشيفرة النموذجية وتقنيات الأتمتة لتبسيط سير العمل الخاص بك."
---

عن طريق تحويل عرض PowerPoint إلى فيديو، ستحصل على 

* **زيادة في إمكانية الوصول:** جميع الأجهزة (بغض النظر عن المنصة) مزودة بأدوات تشغيل الفيديو بشكل افتراضي مقارنةً بتطبيقات فتح العروض، لذلك يجد المستخدمون أنه من الأسهل فتح أو تشغيل الفيديوهات.
* **وصول أوسع:** من خلال الفيديوهات، يمكنك الوصول إلى جمهور كبير واستهدافه بمعلومات قد تبدو مملة في عرض تقديمي. معظم الاستطلاعات والإحصاءات تشير إلى أن الأشخاص يشاهدون الفيديوهات ويستهلكونها أكثر من غيرها من أشكال المحتوى، وعادةً ما يفضلون هذا النوع من المحتوى.

{{% alert color="primary" %}} 
قد ترغب في تجربة [**أداة تحويل PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لأنها تنفيذ حي وفعّال للعملية الموصوفة هنا.
{{% /alert %}} 

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

يدعم Aspose.Slides تحويل العروض إلى فيديو.

* استخدم **Aspose.Slides** لتوليد مجموعة من الإطارات (من شرائح العرض) التي تتطابق مع معدل إطارات معين (FPS)
* استخدم أداة طرف ثالث مثل **ffmpeg** ([للجافا](https://github.com/bramp/ffmpeg-cli-wrapper)) لإنشاء فيديو بناءً على هذه الإطارات. 

### **تحويل PowerPoint إلى فيديو**

1. نزّل ffmpeg [هنا](https://ffmpeg.org/download.html).
2. نفّذ شفرة JavaScript الخاصة بتحويل PowerPoint إلى فيديو.

تُظهر لك هذه الشفرة كيفية تحويل عرض (يحتوي على شكل وتأثيرين حركيين) إلى فيديو:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // يضيف شكل ابتسامة ثم يحركه
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // تهيئة مجلد ملفات ffmpeg التنفيذية. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **تأثيرات الفيديو**

يمكنك تطبيق الحركات على العناصر داخل الشرائح واستخدام الانتقالات بين الشرائح. 

{{% alert color="primary" %}} 
قد ترغب في الاطلاع على هذه المقالات: [PowerPoint Animation](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/)، [Shape Animation](https://docs.aspose.com/slides/nodejs-java/shape-animation/)، و[Shape Effect](https://docs.aspose.com/slides/nodejs-java/shape-effect/).
{{% /alert %}} 

الحركات والانتقالات تجعل عروض الشرائح أكثر جذبًا وإثارة — وتؤدي نفس الغرض للفيديوهات. لنضيف شريحة وانتقال إضافي إلى الشفرة الخاصة بالعرض السابق:
```javascript
// يضيف شكل ابتسامة ويحركه
// ...
// يضيف شريحة جديدة وانتقال متحرك
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```


يدعم Aspose.Slides أيضًا الحركات للنصوص. لذا نقوم بتحريك الفقرات على الكائنات لتظهر واحدةً تلو الأخرى (مع تأخير ثانية واحدة):
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // يضيف النص والحركات
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // تكوين مجلد ملفات ffmpeg التنفيذية. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **فئات تحويل الفيديو**

لتسهيل مهام تحويل PowerPoint إلى فيديو، يوفر Aspose.Slides الفئتين [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/).

يتيح لك [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) ضبط حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) من خلال مُنشئه. إذا مررت كائن العرض، سيُستخدم `Presentation.getSlideSize` ويولد حركات يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/).

عند توليد الحركات، يُنشأ حدث `NewAnimation` لكل حركة لاحقة، ويتضمن معلمة مشغل حركات العرض. هذا الأخير هو فئة تمثل المشغل لحركة منفصلة.

للعمل مع مشغل حركات العرض، تُستخدم طريقة `getDuration` (المدة الكلية للحركة) وطريقة `setTimePosition`. يتم ضبط كل موقع حركة ضمن النطاق *0 إلى المدة*، ثم تُرجع طريقة `getFrame` صورة BufferedImage تمثل حالة الحركة في تلك اللحظة:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // يضيف شكل ابتسامة ويحركه
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// الحالة الأولية للرسوم المتحركة
            try {
                // صورة الحالة الأولية للرسوم المتحركة
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// الحالة النهائية للرسوم المتحركة
            try {
                // الإطار الأخير للرسوم المتحركة
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


لجعل جميع الحركات في عرض ما تُشغل مرة واحدة، تُست‑خدم فئة [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/). هذه الفئة تأخذ مثيلًا من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) ومعدل FPS للEffects في مُنشئها ثم تُستدعي حدث `FrameTick` لكل الحركات لتشغيلها:
```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


بعد ذلك يمكن تجميع الإطارات المُولدة لإنتاج فيديو. راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الحركات والEffects المدعومة**

**الدخول**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fade** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Fly In** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Float In** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Split** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Wipe** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shape** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Wheel** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Random Bars** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Grow & Turn** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Zoom** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Swivel** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Bounce** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**التأكيد**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Color Pulse** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Teeter** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Spin** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Grow/Shrink** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Desaturate** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Darken** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Lighten** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Transparency** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Object Color** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Complementary Color** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Line Color** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fill Color** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**الخروج**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fade** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Fly Out** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Float Out** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Split** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Wipe** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shape** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Random Bars** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shrink & Turn** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Zoom** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Swivel** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Bounce** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مسارات الحركة**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Arcs** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Turns** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shapes** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Loops** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Custom Path** | ![مدعوم](v.png) | ![مدعوم](v.png) |

## **الأسئلة المتكررة**

**هل يمكن تحويل العروض المحمية بكلمة مرور؟**

نعم، يتيح Aspose.Slides العمل مع العروض المحمية بكلمة مرور. عند معالجة هذه الملفات، تحتاج إلى تقديم كلمة المرور الصحيحة حتى يتمكن المكتبة من الوصول إلى محتوى العرض.

**هل يدعم Aspose.Slides الاستخدام في الحلول السحابية؟**

نعم، يمكن دمج Aspose.Slides في التطبيقات والخدمات السحابية. تم تصميم المكتبة للعمل في بيئات الخوادم، مما يضمن أداءً عاليًا وقابلية توسع لمعالجة دفعات الملفات.

**هل هناك قيود على حجم العروض أثناء التحويل؟**

يستطيع Aspose.Slides التعامل مع عروض بحجم شبه غير محدود. ومع ذلك، عند العمل مع ملفات كبيرة جدًا قد تحتاج إلى موارد نظام إضافية، ومن المستحسن أحيانًا تحسين العرض لتحسين الأداء.