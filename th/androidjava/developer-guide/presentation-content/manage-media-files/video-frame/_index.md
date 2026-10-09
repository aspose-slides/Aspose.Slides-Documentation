---
title: จัดการเฟรมวิดีโอในงานนำเสนอบน Android
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/androidjava/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- สกัดวิดีโอ
- ดึงวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java คู่มือแนวทางที่รวดเร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ Android ผ่าน Java ช่วยให้คุณเพิ่มเฟรมวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และสกัดข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อแสดงข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) และชนิดอื่นที่เกี่ยวข้อง

## **สร้างเฟรมวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ถูกจัดเก็บในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอได้

ตัวอย่างนี้ฝังวิดีโอในเครื่องลงบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมใช้หน่วยจุด สตรีมจะเปิดค้างไว้จนกว่าจะบันทึกเสร็จเนื่องจาก [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) ทำให้มันล็อกขณะงานนำเสนอใช้มัน

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

คุณยังสามารถส่งเส้นทางวิดีโอในเครื่องโดยตรงไปยัง [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). ตัวอย่างนี้ฝังวิดีโอลงบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องเข้าถึงได้จนกว่าจะบันทึกงานนำเสนอ

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

## **สร้างเฟรมวิดีโอที่มีวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และภาพย่อลงบนสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น วิธีการ [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) กำหนดให้เล่นอัตโนมัติ การดาวน์โหลดภาพย่อและการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต ตัวแสดงงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย

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

## **เล่นวิดีโอในโหมดเต็มหน้าจอ**

ในงานนำเสนอฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียด เรียกใช้ [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) พร้อมค่า `true` เพื่อเปิดพฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) แรกบนสไลด์แรก และเปิดการเล่นแบบเต็มหน้าจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

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

การเล่นแบบเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ อย่างแยกกัน [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) ควบคุมว่าจะเริ่มอัตโนมัติหรือด้วยการคลิก และ [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ควบคุมว่าจะวนซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งโหมดการเล่นเป็น [VideoPlayModePreset.Auto หรือ VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). ตัวอย่างจะคงการตั้งค่าเริ่มต้นและวนซ้ำเดิมไว้

## **ถอยวิดีโอกลับหลังการเล่น**

ในงานนำเสนอฝึกอบรม การคืนวิดีโอสาธิตกลับไปยังจุดเริ่มต้นทำให้พร้อมสำหรับผู้นำเสนอเล่นอีกครั้ง เรียกใช้ [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) ด้วยค่า `true` เพื่อคืนวิดีโอไปยังจุดเริ่มต้นหลังการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) แรกบนสไลด์แรก และเปิดการถอยกลับ มันปิดการวนซ้ำเพื่อให้การเล่นจบได้และตั้งให้เริ่มด้วยการคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

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

การถอยกลับจะคืนวิดีโอไปยังจุดเริ่มต้นโดยไม่เริ่มใหม่ ในทางตรงกันข้าม การเรียก [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ด้วยค่า `true` จะทำให้การเล่นวนซ้ำอัตโนมัติ ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอจบและพร้อมสำหรับการเล่นใหม่ [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) ควบคุมการเริ่มอัตโนมัติหรือด้วยการคลิกโดยอิสระ; ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) เพื่อให้ผู้นำเสนอควบคุมเวลาเริ่มต้นการเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การถอยกลับทำงานโดยอิสระจาก [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-)

## **ตัดเฟรมวิดีโอ**

ใช้ [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) และ [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) เพื่อตัดส่วนต้นหรือส่วนท้ายของวิดีโอในระหว่างการเล่น ค่าทั้งสองเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังไว้

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่สามารถเล่นได้

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**อ่านค่าการตัด**

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอ จะไม่มีการพิมพ์ ตัวอย่างก่อนหน้านี้ให้ค่า 2500 และ 1000

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

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกเก็บในรูปแบบ WebVTT และเปิดเผยผ่านวิธีการ [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)

**เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ที่มีชื่อภาษาอังกฤษ เวลาตำแหน่งของคำบรรยายต้องตรงกับวิดีโอ งานนำเสนอที่บันทึกจะรวมวิดีโอและคำบรรยายด้วย

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**สกัดคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกต่างหาก ตัวเลขต่อเนื่องทำให้ไฟล์ผลลัพธ์แตกต่างกัน คอนโซลรายงานจำนวนแทร็กที่สกัด งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

แต่ละอ็อบเจกต์ [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) เปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี, และข้อความคำบรรยายเป็นสตริง UTF-8

**ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่าสไลด์และรูปร่างมีอยู่และรูปร่างเป็นเฟรมวิดีโอ

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

หากคุณต้องการลบเฉพาะแทร็กคำบรรยายหนึ่งรายการ ให้ใช้วิธีการ [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) แทนการใช้ [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--)

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงสไลด์ Aspose.Slides ยังช่วยสกัดวิดีโอที่ฝังในงานนำเสนอได้

ตัวอย่างนี้สกัดวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบนารีที่แยกกันและมีหมายเลข วิดีโอที่ลิงก์จะถูกข้ามเพราะไม่มีข้อมูลฝัง คอนโซลพิมพ์ประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; ปรับเปลี่ยนตามประเภทสื่อที่รายงานเมื่อต้องการ

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

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
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
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

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับเฟรมวิดีโอ?**

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (อัตโนมัติหรือด้วยการคลิก) และ [การวนซ้ำ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). ตัวเลือกเหล่านี้พร้อมใช้งานผ่านเมธอดของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกใส่ในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มภาพย่อ งานนำจะแสดงลิงก์และรูปภาพพรีวิวแทนข้อมูลวิดีโอ ทำให้การเพิ่มขนาดมักจะน้อยกว่า

**ฉันสามารถเปลี่ยนวิดีโอในเฟรมวิดีโอที่มีอยู่ได้โดยไม่เปลี่ยนตำแหน่งและขนาดหรือไม่?**

ใช่ คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ภายในเฟรมโดยคงรูปทรงของรูปร่างไว้; นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลเยาติดตั้งที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ใช่ วิดีโอที่ฝังมี [ประเภทเนื้อหา](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) ที่คุณสามารถอ่านและใช้ได้ เช่น เมื่อบันทึกลงดิสก์