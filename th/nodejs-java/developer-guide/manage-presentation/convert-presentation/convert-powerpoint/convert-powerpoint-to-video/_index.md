---
title: แปลงงานนำเสนอ PowerPoint เป็นวิดีโอด้วย JavaScript
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นวิดีโอด้วย JavaScript ค้นพบตัวอย่างโค้ดและเทคนิคการทำงานอัตโนมัติเพื่อปรับปรุงกระบวนการทำงานของคุณให้มีประสิทธิภาพ"
---
## **Introduction**

โดยการแปลงงานนำเสนอ PowerPoint ของคุณเป็นวิดีโอ คุณจะได้รับ 

* **เพิ่มการเข้าถึง:** อุปกรณ์ทั้งหมด (ไม่ว่าจะเป็นแพลตฟอร์มใด) มีเครื่องเล่นวิดีโอเป็นค่าเริ่มต้นเมื่อเทียบกับแอปพลิเคชันเปิดงานนำเสนอ ทำให้ผู้ใช้เปิดหรือเล่นวิดีโอง่ายขึ้น
* **เพิ่มการเข้าถึงกลุ่มเป้าหมาย:** ผ่านวิดีโอ คุณสามารถเข้าถึงผู้ชมจำนวนมากและให้ข้อมูลที่อาจดูน่าเบื่อในงานนำเสนอ คนส่วนใหญ่จากการสำรวจและสถิติแสดงว่าผู้คนมักดูและบริโภควิดีโอมากกว่ารูปแบบเนื้อหาอื่น ๆ และพวกเขามักชอบเนื้อหานี้

{{% alert color="primary" %}} 

คุณอาจต้องการตรวจสอบ [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/th/conversion/ppt-to-word) ของเรา เพราะเป็นการใช้งานจริงและมีประสิทธิภาพของกระบวนการที่อธิบายไว้ที่นี่.

{{% /alert %}} 

## **PowerPoint to Video Conversion in Aspose.Slides**

Aspose.Slides รองรับการแปลงงานนำเสนอเป็นวิดีโอ

* ใช้ **Aspose.Slides** เพื่อสร้างชุดเฟรม (จากสไลด์งานนำเสนอ) ที่สอดคล้องกับ FPS (เฟรมต่อวินาที) ที่กำหนด
* ใช้ยูทิลิตี้ของบุคคลที่สามเช่น **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) เพื่อสร้างวิดีโอตามเฟรม. 

### **Convert PowerPoint to Video**

1. ดาวน์โหลด ffmpeg [ที่นี่](https://ffmpeg.org/download.html).

2. เรียกใช้โค้ด JavaScript สำหรับแปลง PowerPoint เป็นวิดีโอ.

โค้ด JavaScript นี้จะแสดงวิธีแปลงงานนำเสนอ (ที่มีรูปภาพและเอฟเฟกต์การเคลื่อนไหวสองรายการ) เป็นวิดีโอ:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // เพิ่มรูปร่างรอยยิ้มแล้วทำให้เคลื่อนไหว
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
    // กำหนดโฟลเดอร์ไบนารีของ ffmpeg ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Video Effects**

คุณสามารถใส่การเคลื่อนไหวให้กับวัตถุบนสไลด์และใช้การเปลี่ยนฉากระหว่างสไลด์ได้.

{{% alert color="primary" %}} 

คุณอาจต้องการดูบทความเหล่านี้: [PowerPoint Animation](https://docs.aspose.com/slides/th/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/th/nodejs-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/th/nodejs-java/shape-effect/).

{{% /alert %}} 

การเคลื่อนไหวและการเปลี่ยนฉากทำให้การนำเสนอมีความน่าสนใจและดึงดูดมากขึ้น — และทำเช่นเดียวกันกับวิดีโอ เรามาเพิ่มสไลด์และการเปลี่ยนฉากอีกหนึ่งสไลด์ในโค้ดของงานนำเสนอก่อนหน้า:

```javascript
// เพิ่มรูปร่างรอยยิ้มและทำให้เคลื่อนไหว
// ...
// เพิ่มสไลด์ใหม่และการเปลี่ยนฉากแบบเคลื่อนไหว
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides ยังรองรับการเคลื่อนไหวสำหรับข้อความ เราจึงทำการเคลื่อนไหวย่อหน้าบนวัตถุ ซึ่งจะปรากฎต่อเนื่องกัน (โดยตั้งค่าหน่วงเวลาเป็นหนึ่งวินาที):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // เพิ่มข้อความและการเคลื่อนไหว
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
    // กำหนดโฟลเดอร์ไบนารีของ ffmpeg ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Video Conversion Classes**

เพื่อให้คุณทำงานแปลง PowerPoint เป็นวิดีโอ Aspose.Slides มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationanimationsgenerator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationplayer/) 

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationanimationsgenerator/) ทำให้คุณตั้งค่าขนาดเฟรมสำหรับวิดีโอ (ที่จะสร้างในภายหลัง) ผ่านคอนสตรัคเตอร์ของมัน หากคุณส่งอินสแตนซ์ของงานนำเสนอ `Presentation.getSlideSize` จะถูกใช้และมันสร้างการเคลื่อนไหวที่ [PresentationPlayer](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationplayer/) ใช้

เมื่อสร้างการเคลื่อนไหว จะสร้างเหตุการณ์ `NewAnimation` สำหรับแต่ละการเคลื่อนไหวต่อเนื่อง ซึ่งมีพารามิเตอร์ตัวเล่นการเคลื่อนไหวของงานนำเสนอ ตัวหลังเป็นคลาสที่แสดงถึงผู้เล่นสำหรับการเคลื่อนไหวแยกแต่ละรายการ

เพื่อทำงานกับผู้เล่นการเคลื่อนไหวของงานนำเสนอ จะใช้เมธอด `getDuration` (ระยะเวลาทั้งหมดของการเคลื่อนไหว) และเมธอด `setTimePosition` แต่ละตำแหน่งการเคลื่อนไหวจะถูกตั้งค่าในช่วง *0 ถึง duration* แล้วเมธอด `getFrame` จะคืนค่า BufferedImage ที่สอดคล้องกับสถานะการเคลื่อนไหวในขณะนั้น:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // เพิ่มรูปร่างรอยยิ้มและทำให้เคลื่อนไหว
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
            animationPlayer.setTimePosition(0);// สภาพเริ่มต้นของการเคลื่อนไหว
            try {
                // สภาพบิตแมปเริ่มต้นของการเคลื่อนไหว
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// สภาพสุดท้ายของการเคลื่อนไหว
            try {
                // เฟรมสุดท้ายของการเคลื่อนไหว
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

เพื่อให้การเคลื่อนไหวทั้งหมดในงานนำเสนอเล่นพร้อมกัน จะใช้คลาส [PresentationPlayer](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationplayer/). คลาสนี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationanimationsgenerator/) และ FPS สำหรับเอฟเฟกต์ในคอนสตรัคเตอร์แล้วเรียกเหตุการณ์ `FrameTick` สำหรับการเคลื่อนไหวทั้งหมดเพื่อให้เล่น:

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

จากนั้นเฟรมที่สร้างสามารถรวมกันเพื่อผลิตวิดีโอได้ ดูส่วน [Convert PowerPoint to Video](https://docs.aspose.com/slides/th/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Supported Animations and Effects**

**Entrance**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
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

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
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

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
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

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**สามารถแปลงงานนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่, Aspose.Slides รองรับการทำงานกับงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน เมื่อต้องประมวลผลไฟล์ดังกล่าวคุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของงานนำเสนอได้

**Aspose.Slides รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?**

ใช่, Aspose.Slides สามารถบูรณาการเข้ากับแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีถูกออกแบบให้ทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ เพื่อให้มั่นใจในประสิทธิภาพสูงและการขยายตัวสำหรับการประมวลผลไฟล์เป็นชุด

**มีข้อจำกัดขนาดของงานนำเสนอระหว่างการแปลงหรือไม่?**

Aspose.Slides สามารถจัดการกับงานนำเสนอที่มีขนาดเกือบไม่จำกัดได้ อย่างไรก็ตาม เมื่อต้องทำงานกับไฟล์ขนาดใหญ่มากอาจต้องใช้ทรัพยากรระบบเพิ่มเติม และบางครั้งแนะนำให้ทำการปรับแต่งงานนำเสนอเพื่อเพิ่มประสิทธิภาพ