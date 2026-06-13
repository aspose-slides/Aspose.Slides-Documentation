---
title: แปลงการนำเสนอ PowerPoint เป็นวิดีโอใน Java
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/java/convert-powerpoint-to-video/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็นวิดีโอ
- การนำเสนอเป็นวิดีโอ
- PPT เป็นวิดีโอ
- PPTX เป็นวิดีโอ
- PowerPoint เป็น MP4
- การนำเสนอเป็น MP4
- PPT เป็น MP4
- PPTX เป็น MP4
- บันทึก PPT เป็น MP4
- บันทึก PPTX เป็น MP4
- ส่งออก PPT เป็น MP4
- ส่งออก PPTX เป็น MP4
- การแปลงวิดีโอ
- PowerPoint
- Java
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint เป็นวิดีโอใน Java. ค้นหาโค้ดตัวอย่างและเทคนิคการอัตโนมัติเพื่อทำให้กระบวนการทำงานของคุณเป็นระบบง่ายขึ้น."
---
## **คำนำ**

โดยการแปลง PowerPoint หรือการนำเสนอ OpenDocument ของคุณเป็นวิดีโอ คุณจะได้:

**การเข้าถึงที่เพิ่มขึ้น:** อุปกรณ์ทั้งหมด ไม่ว่าจะเป็นแพลตฟอร์มใด，都มีโปรแกรมเล่นวิดีโอเป็นค่าเริ่มต้น ทำให้ผู้ใช้เปิดหรือเล่นวิดีโอได้ง่ายกว่าการใช้แอปพลิเคชันการนำเสนอแบบดั้งเดิม

**การเข้าถึงที่กว้างขึ้น:** วิดีโอช่วยให้คุณเข้าถึงผู้ชมจำนวนมากขึ้นและนำเสนอข้อมูลในรูปแบบที่น่าสนใจ สถิติและแบบสำรวจแสดงว่าผู้คนชอบดูและบริโภคเนื้อหาวิดีโอมากกว่าชนิดอื่น ทำให้ข้อความของคุณมีผลกระทบมากยิ่งขึ้น

{{% alert color="primary" %}} 

คุณอาจต้องการตรวจสอบ [**ตัวแปลง PowerPoint เป็นวิดีโอออนไลน์**](https://products.aspose.app/slides/th/conversion/ppt-to-word) เพราะนี่เป็นการใช้งานจริงและมีประสิทธิภาพของกระบวนการที่อธิบายไว้ที่นี่

{{% /alert %}} 

## **การแปลง PowerPoint เป็นวิดีโอใน Aspose.Slides**

ใน [Aspose.Slides 22.11](https://docs.aspose.com/slides/th/java/aspose-slides-for-java-22-11-release-notes/) เราได้เพิ่มการสนับสนุนการแปลงการนำเสนอเป็นวิดีโอ  

* ใช้ **Aspose.Slides** เพื่อสร้างชุดเฟรม (จากสไลด์การนำเสนอ) ที่สอดคล้องกับ FPS ที่กำหนด  
* ใช้ยูทิลิตี้ของบุคคลที่สามอย่าง **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) เพื่อสร้างวิดีโอตามเฟรมเหล่านั้น  

### **แปลง PowerPoint เป็นวิดีโอ**

1. เพิ่มส่วนนี้ลงในไฟล์ POM ของคุณ:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ดาวน์โหลด ffmpeg [ที่นี่](https://ffmpeg.org/download.html)

4. รันโค้ด Java สำหรับแปลง PowerPoint เป็นวิดีโอ

โค้ด Java นี้แสดงวิธีแปลงการนำเสนอ (ที่มีรูปภาพและเอฟเฟกต์แอนิเมชันสองแบบ) เป็นวิดีโอ:

```java
Presentation presentation = new Presentation();
try {
    // เพิ่มรูปร่าง Smiley แล้วทำแอนิเมชันให้
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

    // กำหนดโฟลเดอร์ไบนารีของ ffmpeg ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
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

คุณสามารถใส่แอนิเมชันให้กับวัตถุบนสไลด์และใช้การเปลี่ยนระหว่างสไลด์ได้

{{% alert color="primary" %}} 

คุณอาจต้องการดูบทความเหล่านี้: [PowerPoint Animation](https://docs.aspose.com/slides/th/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/th/java/shape-animation/), และ [Shape Effect](https://docs.aspose.com/slides/th/java/shape-effect/)

{{% /alert %}} 

แอนิเมชันและการเปลี่ยนทำให้การจัดแสดงสไลด์ดึงดูดและน่าสนใจ—และทำให้วิดีโอเช่นกัน มาเพิ่มสไลด์และการเปลี่ยนอีกหนึ่งสไลด์ในโค้ดสำหรับการนำเสนอก่อนหน้า:

```java
// เพิ่มรูปร่าง Smiley แล้วทำแอนิเมชันให้

// ...

// เพิ่มสไลด์ใหม่และการเปลี่ยนที่มีแอนิเมชัน

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides ยังรองรับแอนิเมชันสำหรับข้อความด้วย เราจึงทำให้ย่อหน้าบนวัตถุแอนิเมชันโดยจะแสดงทีละหนึ่ง (โดยตั้งค่าการหน่วงเวลาเป็นหนึ่งวินาที):

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

    // กำหนดโฟลเดอร์ไบนารีของ ffmpeg ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **คลาสสำหรับแปลงวิดีโอ**

เพื่อให้คุณสามารถทำงานแปลง PowerPoint เป็นวิดีโอได้ Aspose.Slides มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationanimationsgenerator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationplayer/)  

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationanimationsgenerator/) ให้คุณตั้งขนาดเฟรมสำหรับวิดีโอ (ที่จะสร้างต่อไป) ผ่านคอนสตรัคเตอร์ หากคุณส่งอินสแตนซ์ของการนำเสนอ `Presentation.SlideSize` จะถูกใช้และคลาสนี้จะสร้างแอนิเมชันที่ [PresentationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationplayer/) ใช้  

เมื่อแอนิเมชันถูกสร้าง จะเกิดเหตุการณ์ `NewAnimation` สำหรับแต่ละแอนิเมชันต่อเนื่อง ซึ่งรับพารามิเตอร์ประเภท [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationanimationplayer/) คลาสนี้เป็นตัวแทนของผู้เล่นสำหรับแอนิเมชันแยกต่างหาก  

ในการทำงานกับ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationanimationplayer/) จะใช้คุณสมบัติ [Duration](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (ระยะเวลาครบของแอนิเมชัน) และเมธอด [SetTimePosition](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) แต่ละตำแหน่งของแอนิเมชันจะถูกกำหนดในช่วง *0 ถึง duration* จากนั้นเมธอด `GetFrame` จะคืนค่า BufferedImage ที่สอดคล้องกับสถานะของแอนิเมชันในขณะนั้น:

```java
Presentation presentation = new Presentation();
try {
    // เพิ่มรูปร่าง Smiley แล้วทำแอนิเมชันให้
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
                // บิตแมพของสถานะเริ่มต้นของแอนิเมชัน
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

เพื่อให้แอนิเมชันทั้งหมดในการนำเสนอเล่นพร้อมกัน ใช้คลาส [PresentationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationplayer/) คลาสนี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationanimationsgenerator/) และ FPS สำหรับเอฟเฟกต์ในคอนสตรัคเตอร์ แล้วเรียกเหตุการณ์ `FrameTick` สำหรับทุกแอนิเมชันเพื่อให้เล่น:

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

จากนั้นเฟรมที่สร้างขึ้นสามารถคอมไพล์เป็นวิดีโอได้ ดูส่วน [Convert PowerPoint to Video](https://docs.aspose.com/slides/th/java/convert-powerpoint-to-video/#convert-powerpoint-to-video)

## **การสนับสนุนแอนิเมชันและเอฟเฟกต์**

**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Emphasis**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Exit**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Motion Paths**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **คำถามที่พบบ่อย**

**สามารถแปลงการนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้, Aspose.Slides รองรับการทำงานกับ [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/) เมื่อประมวลผลไฟล์ดังกล่าว คุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของการนำเสนอได้

**Aspose.Slides รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?**

ได้, Aspose.Slides สามารถบูรณาการเข้ากับแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีออกแบบมาให้ทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ เพื่อให้ได้ประสิทธิภาพสูงและสามารถขยายตัวสำหรับการประมวลผลไฟล์เป็นแบตช์

**มีข้อจำกัดด้านขนาดของการนำเสนอเมื่อทำการแปลงหรือไม่?**

Aspose.Slides สามารถจัดการกับการนำเสนอที่มีขนาดเกือบทุกขนาดได้ อย่างไรก็ตาม เมื่อทำงานกับไฟล์ขนาดใหญ่มาก อาจต้องใช้ทรัพยากรระบบเพิ่มเติม และบางครั้งอาจแนะนำให้ทำการปรับขนาดหรือเพิ่มประสิทธิภาพของการนำเสนอเพื่อให้การทำงานเร็วขึ้น