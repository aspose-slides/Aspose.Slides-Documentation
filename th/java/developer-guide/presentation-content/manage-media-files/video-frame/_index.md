---
title: จัดการกรอบวิดีโอในงานนำเสนอด้วย Java
linktitle: กรอบวิดีโอ
type: docs
weight: 10
url: /th/java/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- สกัดวิดีโอ
- ดึงวิดีโอ
- กรอบวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างอัตโนมัติโดยใช้ Aspose.Slides สำหรับ Java คู่มือวิธีทำอย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ฟังได้ Aspose.Slides for Java ช่วยให้คุณเพิ่มกรอบวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และสกัดข้อมูลวิดีโอที่ฝังอยู่

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อเป็นตัวแทนข้อมูลวิดีโอและกรอบวิดีโอ Aspose.Slides ให้บริการอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) และชนิดที่เกี่ยวข้องอื่น ๆ

## **สร้างกรอบวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงสไลด์อยู่ในเครื่องคุณสามารถสร้างกรอบวิดีโอเพื่อฝังวิดีโอนั้นในงานนำเสนอของคุณได้

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของกรอบใช้หน่วยจุด สตรีมจะเปิดอยู่จนกว่าการบันทึกจะเสร็จสิ้น เนื่องจาก [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) จะล็อกสตรีมไว้ขณะงานนำเสนอใช้งานมัน

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คุณยังสามารถส่งเส้นทางวิดีโอในเครื่องโดยตรงไปยังเมธอด [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องยังคงเข้าถึงได้จนกว่าจะบันทึกงานนำเสนอเสร็จ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สร้างกรอบวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างกรอบวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์และภาพย่อยของวิดีโอ YouTube ไปยังสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น ๆ เมธอด [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) ขอให้วิดีโอเล่นอัตโนมัติ การดาวน์โหลดภาพย่อยและการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต ตัวดูงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เล่นวิดีโอแบบเต็มจอ**

ในงานนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์แบบเต็มจอเพื่อให้ผู้ฟังเห็นรายละเอียดได้ เรียกเมธอด [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) พร้อมค่า `true` เพื่อเปิดใช้งานพฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) ตัวแรกบนสไลด์แรก และเปิดการเล่นแบบเต็มจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเล่นแบบเต็มจอกำหนดวิธีการแสดงวิดีโอ อย่างอิสระ เมธอด [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) ควบคุมว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และเมธอด [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ควบคุมว่าซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งโหมดการเล่นเป็น [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) ตัวอย่างจะรักษาการตั้งค่าเริ่มต้นและการวนซ้ำที่มีอยู่

## **ย้อนกลับวิดีโอหลังการเล่น**

ในงานนำเสนอการฝึกอบรม การคืนวิดีโอสาธิตไปยังจุดเริ่มต้นทำให้พร้อมสำหรับผู้บรรยายเล่นอีกครั้ง เรียกเมธอด [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) พร้อมค่า `true` เพื่อให้วิดีโอกลับไปยังจุดเริ่มต้นหลังจากการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) ตัวแรกบนสไลด์แรกและเปิดการย้อนกลับ มันจะปิดการวนซ้ำเพื่อให้การเล่นจบลงและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การย้อนกลับทำให้วิดีโอกลับไปยังจุดเริ่มต้นโดยไม่เริ่มใหม่ ในขณะที่การเรียกเมธอด [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) พร้อมค่า `true` จะทำให้การเล่นวนซ้ำโดยอัตโนมัติ ให้ปิดการวนซ้ำเมื่อต้องการให้วิดีโอจบและพร้อมเล่นใหม่ เมธอด [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิก ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมการเริ่มเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การย้อนกลับทำงานแยกจากเมธอด [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-)

## **ตัดต่อกรอบวิดีโอ**

ใช้เมธอด [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) และ [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) เพื่อข้ามส่วนเริ่มต้นหรือส่วนสิ้นสุดของวิดีโอระหว่างการเล่น ค่าเป็นมิลลิวินาที การตัดต่อเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้มีส่วนที่สามารถเล่นได้เหลืออยู่

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**อ่านค่าการตัด**

ตัวอย่างนี้พิมพ์ค่าการตัดของกรอบวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีกรอบวิดีโอ จะไม่มีการพิมพ์ ค่าในตัวอย่างก่อนหน้าคือ 2500 และ 1000

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับกรอบวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกจัดเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 

**เพิ่มคำบรรยายให้กับกรอบวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ที่มีป้ายกำกับ English ค่ามาร์คอัพของคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกแล้วจะรวมทั้งวิดีโอและคำบรรยาย

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**สกัดคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากกรอบวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกกัน ตัวเลขต่อเนื่องทำให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน คอนโซลจะแจ้งจำนวนแทร็กที่สกัด งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

แต่ละอ็อบเจ็กต์ [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) จะเผยให้เห็นตัวระบุคำบรรยาย ป้ายกำกับ ข้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8

**ลบคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากกรอบวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างนั้นเป็นกรอบวิดีโอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบเฉพาะแทร็กคำบรรยายเดียวให้ใช้เมธอด [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) แทนการใช้ [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--)

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงสไลด์ Aspose.Slides ยังช่วยให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอได้

ตัวอย่างนี้สกัดวิดีโอที่ฝังอยู่จากทุกสไลด์เป็นไฟล์ไบนารีที่มีหมายเลขแยกกัน วิดีโอที่ลิงก์จะถูกข้ามเพราะไม่มีข้อมูลฝัง คอนโซลจะแสดงประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยายไฟล์ทั่วไป `.bin` คุณสามารถเปลี่ยนเป็นส่วนขยายที่ตรงกับชนิดสื่อที่รายงานได้ตามต้องการ

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับกรอบวิดีโอ?**

คุณสามารถควบคุม[โหมดการเล่น](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (อัตโนมัติหรือเมื่อคลิก) และ[การวนซ้ำ](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ตัวเลือกเหล่านี้มีให้ผ่านเมธอดของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อฝังวิดีโอในเครื่องข้อมูลไบนารีจะถูกใส่ในเอกสารทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ เมื่อเชื่อมลิงก์ไปยังวิดีโอออนไลน์และเพิ่มภาพย่อย งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ทำให้การเพิ่มขนาดมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในกรอบวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้ คุณสามารถสลับ[เนื้อหาวิดีโอ](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ภายในกรอบโดยคงรูปทรงเดิมไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ได้ วิดีโอที่ฝังไว้มี[ประเภทเนื้อหา](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อต้องการบันทึกลงดิสก์