---
title: แปลงงานนำเสนอ PowerPoint เป็นวิดีโอใน Java
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นวิดีโอใน Java ค้นพบโค้ดตัวอย่างและเทคนิคการทำอัตโนมัติเพื่อทำให้กระบวนการทำงานของคุณเป็นระบบมากขึ้น"
---
## **บทนำ**

โดยการแปลงงานนำเสนอ PowerPoint หรือ OpenDocument ของคุณเป็นวิดีโอ คุณจะได้:

**การเข้าถึงที่เพิ่มขึ้น:** ทุกอุปกรณ์ ไม่ว่าระบบปฏิบัติการใด，都配備了預設的影片播放器，使使用者比起傳統簡報應用程式更容易開啟或播放影片。

**การเข้าถึงที่กว้างขึ้น:** วิดีโอทำให้คุณเข้าถึงผู้ชมได้มากขึ้นและนำเสนอข้อมูลในรูปแบบที่น่าสนใจมากขึ้น การสำรวจและสถิติชี้ว่าวิดีโอเป็นสื่อที่ผู้คนชอบดูและบริโภคมากกว่าสื่อรูปแบบอื่น ทำให้ข้อความของคุณมีผลกระทบมากกว่า。

{{% alert color="info" %}} 

คุณอาจต้องการตรวจสอบ [**เครื่องมือแปลง PowerPoint เป็นวิดีโอออนไลน์**](https://products.aspose.app/slides/th/video) เพราะเป็นการทำงานแบบเรียลไทม์และมีประสิทธิภาพของกระบวนการที่อธิบายไว้ที่นี่

{{% /alert %}} 

## **การแปลง PowerPoint เป็นวิดีโอใน Aspose.Slides**

ใน [Aspose.Slides 22.11](https://docs.aspose.com/slides/th/java/aspose-slides-for-java-22-11-release-notes/) เราได้เพิ่มการรองรับการแปลงงานนำเสนอเป็นวิดีโอ

* ใช้ **Aspose.Slides** เพื่อสร้างชุดเฟรม (จากสไลด์งานนำเสนอ) ที่สอดคล้องกับ FPS (เฟรมต่อวินาที) ที่กำหนด
* ใช้เครื่องมือของบุคคลที่สามอย่าง **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) เพื่อสร้างวิดีโอตามเฟรมที่สร้างขึ้น

### **แปลง PowerPoint เป็นวิดีโอ**

1. เพิ่มโค้ดต่อไปนี้ในไฟล์ POM ของคุณ:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ดาวน์โหลด ffmpeg [ที่นี่](https://ffmpeg.org/download.html)

4. เรียกใช้โค้ด Java แปลง PowerPoint เป็นวิดีโอ

โค้ด Java นี้จะแสดงวิธีการแปลงงานนำเสนอ (ที่มีรูปภาพและเอฟเฟกต์การเคลื่อนไหวสองแบบ) เป็นวิดีโอ:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // เพิ่มรูปร่างรอยยิ้มและจากนั้นทำให้เคลื่อนไหว
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

    // กำหนดค่าโฟลเดอร์ไบนารีของ ffmpeg ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
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

คุณสามารถใช้การเคลื่อนไหวกับออบเจ็กต์บนสไลด์และใช้การเปลี่ยนสไลด์ระหว่างสไลด์ได้

{{% alert color="info" %}} 

คุณอาจต้องการดูบทความเหล่านี้: [การเคลื่อนไหว PowerPoint](https://docs.aspose.com/slides/th/java/powerpoint-animation/), [การเคลื่อนไหว Shape](https://docs.aspose.com/slides/th/java/shape-animation/), และ [เอฟเฟกต์ Shape](https://docs.aspose.com/slides/th/java/shape-effect/)

{{% /alert %}} 

การเคลื่อนไหวและการเปลี่ยนสไลด์ทำให้การนำเสนอมีความน่าสนใจและดึงดูด—และทำให้วิดีโอเช่นกัน ให้เพิ่มสไลด์และการเปลี่ยนสไลด์อีกหนึ่งรายการลงในโค้ดของการนำเสนอก่อนหน้า:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // เพิ่มรูปร่างรอยยิ้มและทำให้เคลื่อนไหว

    // ...

    // เพิ่มสไลด์ใหม่และการเปลี่ยนสไลด์แบบเคลื่อนไหว

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides ยังรองรับการเคลื่อนไหวสำหรับข้อความด้วย เราจึงเคลื่อนไหวย่อหน้าบนวัตถุ ซึ่งจะปรากฏต่อกันทีละบรรทัด (โดยตั้งค่าหน่วงเวลาเป็นหนึ่งวินาที):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // เพิ่มข้อความและการเคลื่อนไหว
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

    // กำหนดค่าโฟลเดอร์ไบนารีของ ffmpeg ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **คลาสสำหรับการแปลงวิดีโอ**

เพื่อให้คุณสามารถทำงานแปลง PowerPoint เป็นวิดีโอได้ Aspose.Slides มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationanimationsgenerator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationplayer/)

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationanimationsgenerator/) ช่วยให้คุณกำหนดขนาดเฟรมสำหรับวิดีโอ (ที่สร้างในภายหลัง) ผ่านคอนสตรัคเตอร์ของมัน หากคุณส่งอ็อบเจกต์ Presentationinstance, `Presentation.SlideSize` จะถูกใช้และมันจะสร้างการเคลื่อนไหวที่ [PresentationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationplayer/) ใช้

เมื่อการเคลื่อนไหวถูกสร้าง จะมีเหตุการณ์ `NewAnimation` ถูกสร้างสำหรับการเคลื่อนไหวแต่ละรายการ ซึ่งมีพารามิเตอร์ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationanimationplayer/) ตัวหลังเป็นคลาสที่แทนผู้เล่นสำหรับการเคลื่อนไหวแยกต่างหาก

ในการทำงานกับ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationanimationplayer/) จะใช้คุณสมบัติ [Duration](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (ระยะเวลาการเคลื่อนไหวทั้งหมด) และเมธอด [SetTimePosition](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) แต่ละตำแหน่งการเคลื่อนไหวนั้นจะตั้งค่าในช่วง *0 ถึง duration* แล้วเมธอด `getFrame` จะคืนค่า [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) ที่สอดคล้องกับสถานะของการเคลื่อนไหวในขณะนั้น:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // เพิ่มรูปร่างรอยยิ้มและทำให้เคลื่อนไหว
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

            animationPlayer.setTimePosition(0); // สถานะการเคลื่อนไหวเริ่มต้น
            // บิทแมพของสถานะการเคลื่อนไหวเริ่มต้น
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // สถานะสุดท้ายของการเคลื่อนไหว
            // เฟรมสุดท้ายของการเคลื่อนไหว
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // สร้างการเคลื่อนไหว - นี่คือสิ่งที่กระตุ้นเหตุการณ์ที่จัดการข้างต้น
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

เพื่อให้การเคลื่อนไหวทั้งหมดในงานนำเสนอเล่นพร้อมกัน จะใช้คลาส [PresentationPlayer](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationplayer/) คลาสนี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationanimationsgenerator/) และ FPS สำหรับเอฟเฟกต์ในคอนสตรัคเตอร์และจากนั้นเรียกเหตุการณ์ `FrameTick` สำหรับการเคลื่อนไหวทั้งหมดเพื่อให้เล่น:

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

จากนั้นเฟรมที่สร้างขึ้นสามารถคอมไพล์เพื่อผลิตวิดีโอได้ ดูส่วน [แปลง PowerPoint เป็นวิดีโอ](https://docs.aspose.com/slides/th/java/convert-powerpoint-to-video/#convert-powerpoint-to-video)

## **การสนับสนุนการเคลื่อนไหวและเอฟเฟกต์**

**การเข้า**

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **ปรากฏ** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **จางหาย** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **บินเข้า** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **ลอยเข้ามา** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **แยก** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **ปัด** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **รูปร่าง** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **ล้อ** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **แถบสุ่ม** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **เติบโตและหมุน** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **ซูม** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **หมุน** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **กระเด้ง** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |

**การเน้น**

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **พัลส์** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **พัลส์สี** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **สั่น** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **หมุน** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **ขยาย/หด** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **ลดความอิ่มสี** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **ทำให้มืดลง** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **ทำให้สว่างขึ้น** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **ความโปร่งใส** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **สีวัตถุ** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **สีตรงข้าม** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **สีเส้น** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **สีเติม** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |

**การออก**

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **หายไป** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **จางหาย** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **บินออก** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **ลอยออก** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **แยก** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **ปัด** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **รูปร่าง** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **แถบสุ่ม** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **หดและหมุน** | ![ไม่สนับสนุน](x.png) | ![สนับสนุน](v.png) |
| **ซูม** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **หมุน** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **กระเด้ง** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |

**เส้นทางการเคลื่อนไหว**

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **เส้น** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **โค้ง** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **การเปลี่ยนทิศ** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **รูปร่าง** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **ลูป** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |
| **เส้นทางกำหนดเอง** | ![สนับสนุน](v.png) | ![สนับสนุน](v.png) |

## **คำถามที่พบบ่อย**

### สามารถแปลงงานนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?

ใช่, Aspose.Slides รองรับการทำงานกับ [การนำเสนอที่มีการป้องกันด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/) เมื่อประมวลผลไฟล์ดังกล่าว คุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของงานนำเสนอได้

### Aspose.Slides รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?

ใช่, Aspose.Slides สามารถรวมเข้ากับแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีออกแบบมาเพื่อทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ ให้ประสิทธิภาพสูงและสามารถขยายตัวสำหรับการประมวลผลไฟล์เป็นชุดได้

### มีข้อจำกัดขนาดของงานนำเสนอเมื่อทำการแปลงหรือไม่?

Aspose.Slides สามารถจัดการกับงานนำเสนอที่มีขนาดใด ๆ ก็ตาม อย่างไรก็ตาม เมื่อทำงานกับไฟล์ขนาดใหญ่มาก อาจต้องใช้ทรัพยากรระบบเพิ่มเติม และบางครั้งอาจแนะนำให้ปรับขนาดหรือลดความซับซ้อนของงานนำเสนอเพื่อเพิ่มประสิทธิภาพการทำงาน