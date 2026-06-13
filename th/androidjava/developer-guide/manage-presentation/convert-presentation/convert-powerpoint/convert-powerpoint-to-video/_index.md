---
title: แปลงงานนำเสนอ PowerPoint เป็นวิดีโอบน Android
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/androidjava/convert-powerpoint-to-video/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็นวิดีโอ
- งานนำเสนอเป็นวิดีโอ
- PPT เป็นวิดีโอ
- PPTX เป็นวิดีโอ
- PowerPoint เป็น MP4
- งานนำเสนอเป็น MP4
- PPT เป็น MP4
- PPTX เป็น MP4
- บันทึก PPT เป็น MP4
- บันทึก PPTX เป็น MP4
- ส่งออก PPT เป็น MP4
- ส่งออก PPTX เป็น MP4
- การแปลงวิดีโอ
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นวิดีโอใน Java ค้นพบตัวอย่างโค้ดและเทคนิคการอัตโนมัติเพื่อทำให้กระบวนการทำงานของคุณเป็นระเบียบง่ายขึ้น."
---
## **บทนำ**

โดยการแปลงงานนำเสนอ PowerPoint ของคุณเป็นวิดีโอ คุณจะได้รับ 

* **เพิ่มการเข้าถึง:** ทุกอุปกรณ์ (ไม่ว่าจะเป็นแพลตฟอร์มใด) มีเครื่องเล่นวิดีโอเป็นค่าเริ่มต้นเมื่อเทียบกับแอปพลิเคชันเปิดงานนำเสนอ ดังนั้นผู้ใช้จึงพบว่าการเปิดหรือเล่นวิดีโอทำได้ง่ายขึ้น.
* **เข้าถึงมากขึ้น:** ด้วยวิดีโอ คุณสามารถเข้าถึงผู้ชมจำนวนมากและนำเสนอข้อมูลที่อาจดูน่าเบื่อถ้าใช้ในงานนำเสนอ สถานะสำรวจและสถิติมากมายแสดงว่าผู้คนดูและบริโภควิดีโอมากกว่าชนิดเนื้อหาอื่น ๆ และโดยทั่วไปพวกเขาชอบเนื้อหาแบบนี้.

{{% alert color="primary" %}} 

คุณอาจต้องการตรวจสอบ [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/th/conversion/ppt-to-word) ของเรา เนื่องจากเป็นการดำเนินการแบบสดและมีประสิทธิภาพของกระบวนการที่อธิบายไว้ที่นี่.

{{% /alert %}} 

## **การแปลง PowerPoint เป็นวิดีโอใน Aspose.Slides**

Aspose.Slides รองรับการแปลงงานนำเสนอเป็นวิดีโอ.

* ใช้ **Aspose.Slides** เพื่อสร้างชุดเฟรม (จากสไลด์ของงานนำเสนอ) ที่สอดคล้องกับ FPS (เฟรมต่อวินาที) ที่กำหนด
* ใช้ยูทิลิตี้ของบุคคลที่สามเช่น **ffmpeg** ([สำหรับ java](https://github.com/bramp/ffmpeg-cli-wrapper)) เพื่อสร้างวิดีโอจากเฟรมเหล่านั้น. 

### **แปลง PowerPoint เป็นวิดีโอ**

1. เพิ่มนี้ลงในไฟล์ POM ของคุณ:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ดาวน์โหลด ffmpeg [ที่นี่](https://ffmpeg.org/download.html).

4. รันโค้ด Java สำหรับการแปลง PowerPoint เป็นวิดีโอ.

โค้ด Java นี้จะแสดงวิธีการแปลงงานนำเสนอ (ที่มีรูปภาพและเอฟเฟกต์แอนิเมชันสองรายการ) เป็นวิดีโอ:
```java
Presentation presentation = new Presentation();
try {
    // เพิ่มรูปยิ้มและจากนั้นทำแอนิเมชันให้
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

    // กำหนดโฟลเดอร์ไบนารีของ ffmpeg. ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **เอฟเฟกต์วิดีโอ**

คุณสามารถใส่แอนิเมชันให้กับวัตถุในสไลด์และใช้การเปลี่ยนสไลด์ระหว่างสไลด์ได้.

{{% alert color="primary" %}} 

คุณอาจต้องการดูบทความเหล่านี้: [PowerPoint Animation](https://docs.aspose.com/slides/th/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/th/androidjava/shape-animation/), และ [Shape Effect](https://docs.aspose.com/slides/th/androidjava/shape-effect/).

{{% /alert %}} 

แอนิเมชันและการเปลี่ยนสไลด์ทำให้การสไลด์โชว์มีความน่าสนใจและดึงดูดมากขึ้น — และทำเช่นเดียวกันสำหรับวิดีโอ ให้เพิ่มสไลด์และการเปลี่ยนสไลด์อีกหนึ่งสไลด์ในโค้ดของงานนำเสนอก่อนหน้า:
```java
// เพิ่มรูปยิ้มและทำแอนิเมชันให้

// ...

// เพิ่มสไลด์ใหม่และการเปลี่ยนสไลด์แบบแอนิเมชัน
ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides ยังรองรับการแอนิเมชันสำหรับข้อความ ดังนั้นเราจึงทำแอนิเมชันให้กับย่อหน้าบนวัตถุ ซึ่งจะปรากฏทีละหนึ่ง (โดยตั้งค่าหน่วงเวลาเป็นหนึ่งวินาที):
```java
Presentation presentation = new Presentation();
try {
    // เพิ่มข้อความและแอนิเมชัน
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

    // กำหนดโฟลเดอร์ไบนารีของ ffmpeg. ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **คลาสการแปลงวิดีโอ**

เพื่อให้คุณสามารถทำงานแปลง PowerPoint เป็นวิดีโอได้ Aspose.Slides มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationanimationsgenerator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationplayer/)

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationanimationsgenerator/) ให้คุณตั้งค่าขนาดเฟรมสำหรับวิดีโอ (ที่จะสร้างในภายหลัง) ผ่านคอนสตรัคเตอร์ของมัน หากคุณส่งอินสแตนซ์ของงานนำเสนอ `Presentation.SlideSize` จะถูกใช้และจะสร้างแอนิเมชันที่ [PresentationPlayer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationplayer/) ใช้.

เมื่อสร้างแอนิเมชันแล้ว จะมีเหตุการณ์ `NewAnimation` สร้างขึ้นสำหรับแต่ละแอนิเมชันต่อเนื่อง ซึ่งมีพารามิเตอร์เป็น [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationanimationplayer/) ตัวหลังเป็นคลาสที่แสดงผู้เล่นสำหรับแอนิเมชันแยกต่างหาก.

เพื่อทำงานกับ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationanimationplayer/), ใช้คุณสมบัติ [Duration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (ระยะเวลาทั้งหมดของแอนิเมชัน) และเมธอด [SetTimePosition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) . ตำแหน่งของแต่ละแอนิเมชันจะตั้งค่าในช่วง *0 ถึง duration* จากนั้นเมธอด `GetFrame` จะคืนค่า BufferedImage ที่สอดคล้องกับสถานะของแอนิเมชันในขณะนั้น:
```java
Presentation presentation = new Presentation();
try {
    // เพิ่มรูปยิ้มและทำแอนิเมชันให้
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
            animationPlayer.setTimePosition(0); // สถานะเริ่มต้นของแอนิเมชัน
            try {
                // บิตแมพของสถานะเริ่มต้นแอนิเมชัน
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // สถานะสุดท้ายของแอนิเมชัน
            try {
                // เฟรมสุดท้ายของแอนิเมชัน
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

เพื่อให้แอนิเมชันทั้งหมดในงานนำเสนอเล่นพร้อมกัน ใช้คลาส [PresentationPlayer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationplayer/) นี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationanimationsgenerator/) และ FPS สำหรับเอฟเฟกต์ในคอนสตรัคเตอร์ จากนั้นเรียกเหตุการณ์ `FrameTick` สำหรับแอนิเมชันทั้งหมดเพื่อให้มันเล่น:
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

จากนั้นเฟรมที่สร้างขึ้นสามารถรวมเป็นวิดีโอได้ ดูส่วน [Convert PowerPoint to Video](https://docs.aspose.com/slides/th/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **แอนิเมชันและเอฟเฟกต์ที่รองรับ**

**การเข้าสู่**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
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

**การเน้น**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
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

**การออก**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
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

**เส้นทางการเคลื่อนที่:**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **คำถามที่พบบ่อย**

**สามารถแปลงงานนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่, Aspose.Slides รองรับการทำงานกับ [งานนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/androidjava/password-protected-presentation/). เมื่อประมวลผลไฟล์ดังกล่าว คุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีสามารถเข้าถึงเนื้อหาของงานนำเสนอได้.

**Aspose.Slides รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?**

ใช่, Aspose.Slides สามารถรวมเข้ากับแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีถูกออกแบบให้ทำงานในสภาพแวดล้อมเซิร์ฟเวอร์, รับประกันประสิทธิภาพสูงและการขยายขนาดสำหรับการประมวลผลไฟล์เป็นชุด.

**มีข้อจำกัดขนาดสำหรับงานนำเสนอระหว่างการแปลงหรือไม่?**

Aspose.Slides สามารถจัดการงานนำเสนอที่มีขนาดใกล้เคียงกับไม่จำกัด อย่างไรก็ตามเมื่อทำงานกับไฟล์ขนาดใหญ่มาก อาจต้องการทรัพยากรระบบเพิ่มเติม และบางครั้งแนะนำให้ทำการปรับขนาดงานนำเสนอเพื่อเพิ่มประสิทธิภาพ.