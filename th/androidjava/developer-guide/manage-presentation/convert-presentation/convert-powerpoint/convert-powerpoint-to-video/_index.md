---
title: แปลงการนำเสนอ PowerPoint เป็นวิดีโอบน Android
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint เป็นวิดีโอด้วย Java ค้นพบตัวอย่างโค้ดและเทคนิคการทำงานอัตโนมัติเพื่อปรับปรุงกระบวนการของคุณให้เป็นระบบมากขึ้น"
---
## **บทนำ**

โดยการแปลงการนำเสนอ PowerPoint ของคุณเป็นวิดีโอ คุณจะได้รับ 

* **เพิ่มความเข้าถึง:** ทุกอุปกรณ์ (ไม่ว่าจะเป็นแพลตฟอร์มใด) ถูกติดตั้งตัวเล่นวิดีโอโดยค่าเริ่มต้นเมื่อเทียบกับแอปพลิเคชันเปิดการนำเสนอ ทำให้ผู้ใช้พบว่าการเปิดหรือเล่นวิดีโอง่ายขึ้น
* **การเข้าถึงที่มากขึ้น:** ด้วยวิดีโอ คุณสามารถเข้าถึงผู้ชมจำนวนมากและให้ข้อมูลแก่พวกเขาที่อาจดูน่าเบื่อหากเป็นการนำเสนอ การสำรวจและสถิติส่วนใหญ่แสดงว่าผู้คนดูและบริโภควิดีโอมากกว่าประเภทเนื้อหาอื่น ๆ และโดยทั่วไปพวกเขาชอบเนื้อหาแบบนี้

## **การแปลง PowerPoint เป็นวิดีโอใน Aspose.Slides**

Aspose.Slides รองรับการแปลงการนำเสนอเป็นวิดีโอ

* ใช้ **Aspose.Slides** เพื่อสร้างชุดกรอบภาพ (จากสไลด์การนำเสนอ) ที่สอดคล้องกับ FPS (เฟรมต่อวินาที) ที่กำหนด
* ใช้ยูทิลิตี้ของบุคคลที่สามอย่าง **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) เพื่อสร้างวิดีโอตามกรอบภาพ  

### **แปลง PowerPoint เป็นวิดีโอ**

1. เพิ่มส่วนนี้ในไฟล์ POM ของคุณ:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ดาวน์โหลด ffmpeg [here](https://ffmpeg.org/download.html).

3. เรียกใช้โค้ด Java สำหรับการแปลง PowerPoint เป็นวิดีโอ

โค้ด Java นี้แสดงวิธีการแปลงการนำเสนอ (ซึ่งมีรูปภาพและเอฟเฟกต์แอนิเมชันสองอย่าง) เป็นวิดีโอ:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // เพิ่มรูปหัวเราะและทำแอนิเมชันให้
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

    // ตั้งค่าโฟลเดอร์ไบนารีของ ffmpeg ดูหน้านี้: https://github.com/bramp/ffmpeg-cli-wrapper
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

คุณสามารถใช้แอนิเมชันกับวัตถุบนสไลด์และใช้การเปลี่ยนภาพระหว่างสไลด์ได้

{{% alert color="info" %}} 

คุณอาจต้องการดูบทความเหล่านี้: [PowerPoint Animation](https://docs.aspose.com/slides/th/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/th/androidjava/shape-animation/), และ [Shape Effect](https://docs.aspose.com/slides/th/androidjava/shape-effect/).

{{% /alert %}} 

แอนิเมชันและการเปลี่ยนภาพทำให้การพรีเซนเทชันน่าสนใจและดึงดูดมากขึ้น—เช่นเดียวกับวิดีโอ มาลองเพิ่มสไลด์และการเปลี่ยนภาพอีกหนึ่งสไลด์ในโค้ดของการนำเสนอก่อนหน้า:

```java
import com.aspose.slides.*;
import java.awt.Color;

// การนำเสนอพร้อมรูปหัวเราะที่ทำแอนิเมชันจากด้านบน.
Presentation presentation = new Presentation();
try {
    // เพิ่มสไลด์ใหม่และการเปลี่ยนภาพแบบแอนิเมชัน

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides ยังรองรับแอนิเมชันสำหรับข้อความ ดังนั้นเราจึงทำให้ย่อหน้าบนวัตถุแอนิเมชันขึ้นตามลำดับ (ด้วยการหน่วงเวลาเป็นหนึ่งวินาที):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // ตั้งค่าโฟลเดอร์ไบนารีของ ffmpeg ดูหน้านี้: https://github.com/bramp/ffmpeg-cli-wrapper
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

เพื่อให้คุณสามารถทำงานแปลง PowerPoint เป็นวิดีโอ Aspose.Slides จัดให้มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationanimationsgenerator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationplayer/)  

[PresentationAnimationsGenerator] ให้คุณตั้งค่าขนาดเฟรมสำหรับวิดีโอ (ที่จะสร้างในภายหลัง) ผ่านคอนสตรัคเตอร์ของมัน หากคุณส่งอินสแตนซ์ของการนำเสนอ `Presentation.SlideSize` จะถูกใช้และมันสร้างแอนิเมชันที่ [PresentationPlayer] ใช้  

เมื่อแอนิเมชันถูกสร้าง จะมีการส่งเหตุการณ์ `NewAnimation` สำหรับแอนิเมชันแต่ละอันต่อเนื่อง ซึ่งมีพารามิเตอร์ [IPresentationAnimationPlayer] ตัวหลังเป็นคลาสที่เป็นผู้เล่นสำหรับแอนิเมชันแยกต่างหาก  

เพื่อทำงานกับ [IPresentationAnimationPlayer] จะใช้คุณสมบัติ [Duration] (ระยะเวลาทั้งหมดของแอนิเมชัน) และเมธอด [SetTimePosition] แต่ละตำแหน่งของแอนิเมชันจะตั้งค่าอยู่ในช่วง *0 to duration* แล้วเมธอด `getFrame` จะคืนค่า [IImage] ที่สอดคล้องกับสถานะของแอนิเมชันในขณะนั้น:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // เพิ่มรูปหัวเราะและทำแอนิเมชันให้
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
            // บิตแมพของสถานะเริ่มต้นของแอนิเมชัน
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // สถานะสุดท้ายของแอนิเมชัน
            // เฟรมสุดท้ายของแอนิเมชัน
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // สร้างแอนิเมชัน กำหนดการเรียกกลับด้านบนจะทำงานสำหรับแต่ละแอนิเมชัน
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

เพื่อให้แอนิเมชันทั้งหมดในการนำเสนอเล่นพร้อมกัน จะใช้คลาส [PresentationPlayer] คลาสนี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator] และ FPS สำหรับเอฟเฟกต์ในคอนสตรัคเตอร์ของมัน จากนั้นเรียกเหตุการณ์ `FrameTick` สำหรับแอนิเมชันทั้งหมดเพื่อให้เล่น:

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

จากนั้นกรอบภาพที่สร้างขึ้นสามารถนำมาประกอบเป็นวิดีโอได้ ดูส่วน [Convert PowerPoint to Video](https://docs.aspose.com/slides/th/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video)  

## **แอนิเมชันและเอฟเฟกต์ที่รองรับ**

**การเข้าสู่**:

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

**การเน้น**:

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

**การออก**:

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

**เส้นทางการเคลื่อนที่**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **คำถามที่พบบ่อย**

### เป็นไปได้หรือไม่ที่จะเปลี่ยนการนำเสนอที่ป้องกันด้วยรหัสผ่าน?

ใช่, Aspose.Slides รองรับการทำงานกับ [password-protected presentations](/slides/th/androidjava/password-protected-presentation/). เมื่อต้องประมวลผลไฟล์เหล่านี้ คุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของการนำเสนอได้

### Aspose.Slides รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?

ใช่, Aspose.Slides สามารถรวมเข้ากับแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีถูกออกแบบมาให้ทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ โดยให้ประสิทธิภาพและความสามารถในการขยายตัวสูงสำหรับการประมวลผลไฟล์เป็นกลุ่ม

### มีข้อจำกัดด้านขนาดของการนำเสนอระหว่างการแปลงหรือไม่?

Aspose.Slides สามารถจัดการกับการนำเสนอที่มีขนาดใกล้เคียงกับทุกขนาด อย่างไรก็ตามเมื่อทำงานกับไฟล์ขนาดใหญ่มาก อาจต้องการทรัพยากรระบบเพิ่มเติม และบางครั้งอาจแนะนำให้ทำการปรับแต่งการนำเสนอเพื่อเพิ่มประสิทธิภาพการทำงาน