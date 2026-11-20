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
- ดึงคืนวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java อย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ฟังได้ Aspose.Slides for Android via Java ช่วยให้คุณเพิ่มเฟรมวิดีโอบนสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และสกัดข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อแสดงข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) และประเภทอื่น ๆ ที่เกี่ยวข้อง

## **สร้างเฟรมวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ถูกเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอของคุณ

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมเป็นหน่วยจุด สตรีมจะเปิดค้างไว้จนกว่าการบันทึกจะเสร็จ เนื่องจาก [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) ทำให้มันล็อกขณะงานนำเสนอใช้งาน

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

คุณสามารถส่งเส้นทางวิดีโอในเครื่องโดยตรงไปยัง [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) ได้ ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องเข้าถึงได้จนกว่าการบันทึกงานนำเสนอจะเสร็จ

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

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์และภาพย่อของวิดีโอ YouTube ไปยังสไลด์แรก เปลี่ยนตัวระบุวิดีโอเพื่อใช้วิดีโออื่น วิธี [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) ขอให้เล่นอัตโนมัติ การดาวน์โหลดภาพย่อและการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต ตัวดูงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย

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

## **เล่นวิดีโอในโหมดเต็มจอ**

ในงานนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มจอเพื่อให้ผู้ชมเห็นรายละเอียด เรียกใช้ [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) ด้วยค่า `true` เพื่อเปิดใช้งานพฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) ตัวแรกบนสไลด์แรกและเปิดใช้งานการเล่นแบบเต็มจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

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

การเล่นแบบเต็มจอควบคุมการแสดงผลของวิดีโอ อย่างอิสระ [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) ควบคุมว่ามันเริ่มอัตโนมัติหรือเมื่อคลิกและ [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ควบคุมการทำซ้ำ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งค่าโหมดการเล่นเป็น [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) ตัวอย่างนี้คงการตั้งค่าเริ่มต้นและการวนลูปเดิมไว้

## **รีวินด์วิดีโหลังการเล่น**

ในงานนำเสนอการฝึกอบรม การนำวิดีโอสาธิตกลับไปยังจุดเริ่มต้นทำให้พร้อมสำหรับผู้บรรยายที่จะเล่นอีกครั้งเรียกใช้ [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) ด้วยค่า `true` เพื่อคืนวิดีโอกลับไปที่จุดเริ่มหลังการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) ตัวแรกบนสไลด์แรกและเปิดใช้งานการรีวินด์ ปิดการวนลูปเพื่อให้การเล่นเสร็จสิ้นและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

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

การรีวินด์จะคืนวิดีโอไปที่จุดเริ่มต้นโดยไม่เริ่มเล่นใหม่ ในทางตรงข้าม การเรียก [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ด้วยค่า `true` จะทำให้การเล่นวนซ้ำโดยอัตโนมัติ ให้ปิดการวนลูปเมื่อต้องการให้วิดีโอเล่นจนจบและพร้อมสำหรับการเล่นใหม่ [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิกอย่างอิสระ ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมการเริ่มเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนลูปตามที่แสดงในตัวอย่าง การรีวินด์ทำงานแยกจาก [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-)

## **ตัดส่วนของเฟรมวิดีโอ**

ใช้ [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) และ [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) เพื่อตัดส่วนต้นหรือส่วนท้ายของวิดีโอระหว่างการเล่น ค่าเป็นมิลลิวินาที การตัดส่วนปรับการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังไว้

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้ยังมีส่วนที่เล่นได้เหลืออยู่

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

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอจะไม่มีการพิมพ์ ตัวอย่างก่อนหน้านี้ให้ค่า 2500 และ 1000

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

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 

### **เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ที่มีป้ายกำกับ English timestamps ของคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกจะรวมทั้งวิดีโอและคำบรรยาย

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

[ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) อินเทอร์เฟซยังมีการ overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีม

### **สกัดคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกต่างหาก ตัวเลขลำดับทำให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน คอนโซลรายงานจำนวนแทร็กที่สกัด งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

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

แต่ละวัตถุ [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) แสดงตัวระบุคำบรรยาย ป้ายกำกับ ข้อมูลไบนารี และข้อความคำบรรยายเป็นสตริง UTF-8

### **ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอที่ตำแหน่งรูปทรงแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปทรงอยู่และรูปทรงนั้นเป็นเฟรมวิดีโอ

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

หากต้องการลบเฉพาะแทร็กคำบรรยายหนึ่งแทร็ก ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) แทน [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--)

### **ค้นหาคำบรรยายวิดีโอ**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) คืนค่าแทร็ก WebVTT ทั้งหมดรวมถึงส่วนหัว บรรทัดเวลา และข้อความคำบรรยาย คุณสามารถค้นหา cue ในหน่วยความจำเพื่อหาวลีพูดและไทม์สแตมป์ ตัวอย่างเช่น แทร็ก English บนสไลด์ 2 อาจมีข้อความต่อไปนี้

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

ตัวอย่างนี้เปิดไฟล์ `captioned_media.pptx` และใช้ [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) เพื่ออ่านแทร็กของแต่ละเฟรมวิดีโอระดับบนบนทุกสไลด์ ใน cue แบบข้อความธรรมดา บรรทัดเวลาประกอบด้วย `-->` และบรรทัดว่างจะสิ้นสุด cue เมื่อคำบรรยายมีคำว่า “café” ในรูปแบบใดก็ได้ ตัวอย่างนี้พิมพ์หมายเลขสไลด์ ป้ายแทร็ก บรรทัดเวลาต้นฉบับ และคำบรรยายเต็ม

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

การค้นหา “café” ให้ผลลัพธ์หนึ่งรายการสำหรับแทร็กตัวอย่าง การค้นหาจะยกเว้นส่วนหัวของแทร็กและคงค่าเวลาที่ออกมา

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **สกัดวิดีโอกจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงสไลด์ Aspose.Slides ยังอนุญาตให้สกัดวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้สกัดวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบนารีแยกตามหมายเลข วิดีโอที่ลิงก์จะถูกข้ามเนื่องจากไม่มีข้อมูลฝัง คอนโซลพิมพ์ประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; สามารถเปลี่ยนตามประเภทสื่อที่รายงานเมื่อจำเป็น

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

**พารามิเตอร์การเล่นวิดีโอที่สามารถเปลี่ยนแปลงได้สำหรับเฟรมวิดีโอคืออะไร?**

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (อัตโนมัติหรือเมื่อคลิก) และ [การวนลูป](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ตัวเลือกเหล่านี้มีให้ผ่านเมธอดของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่องข้อมูลไบนารีจะถูกรวมไว้ในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มขึ้นตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มภาพย่อ งานนำเสนอจะเก็บเพียงลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นขนาดที่เพิ่มมักจะน้อยกว่า

**ฉันสามารถเปลี่ยนวิดีโอในเฟรมวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ภายในเฟรมได้โดยคงรูปทรงเดิมไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลเอาต์ที่มีอยู่

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ใช่ วิดีโอที่ฝังมี [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อต้องการบันทึกลงดิสก์