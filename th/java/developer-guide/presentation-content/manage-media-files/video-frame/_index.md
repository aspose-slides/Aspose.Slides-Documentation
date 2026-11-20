---
title: จัดการเฟรมวิดีโอในงานนำเสนอโดยใช้ Java
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/java/video-frame/
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
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมโดยใช้ Aspose.Slides for Java. คู่มือวิธีทำที่เร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides for Java ทำให้คุณสามารถเพิ่มเฟรมวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และสกัดข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอที่อยู่ในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อเป็นตัวแทนของข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) และชนิดอื่นที่เกี่ยวข้อง

## **สร้างเฟรมวิดีโอฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มในสไลด์ของคุณถูกจัดเก็บในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอนั้นในงานนำเสนอของคุณได้

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมใช้หน่วยจุด (points) สตรีมจะเปิดอยู่จนกว่าการบันทึกจะเสร็จสิ้น เพราะ [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) ทำให้ล็อกไว้ขณะงานนำเสนอใช้มัน

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

คุณยังสามารถส่งเส้นทางวิดีโอในเครื่องโดยตรงไปยัง [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องยังสามารถเข้าถึงได้จนกว่าจะบันทึกงานนำเสนอ

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

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปย่อบนสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น วิธีการ [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) ขอให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อและการเล่นวิดีโอต้องการการเข้าถึงอินเทอร์เน็ต ผู้ชมงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์เช่นกัน

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

ในการฝึกอบรมคุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมมองเห็นรายละเอียดได้ เรียกใช้ [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) พร้อมค่า `true` เพื่อเปิดการทำงานนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) ตัวแรกบนสไลด์แรกและเปิดการเล่นแบบเต็มหน้าจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่แล้วบนสไลด์แรก

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

การเล่นแบบเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ อย่างอิสระ [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) ควบคุมว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และ [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ควบคุมว่าจะทำซ้ำหรือไม่ เมื่อต้องการเลือกพฤติกรรมการเริ่มต้น ให้ตั้งโหมดการเล่นเป็น [VideoPlayModePreset.Auto หรือ VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). ตัวอย่างนี้คงค่าการเริ่มและการวนซ้ำที่มีอยู่

## **ถอยวิดีโอกลับหลังการเล่น**

ในการฝึกอบรม การนำวิดีโอสาธิตกลับไปที่จุดเริ่มต้นทำให้พร้อมสำหรับผู้พูดที่จะเล่นอีกครั้ง เรียก [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) ด้วยค่า `true` เพื่อให้วิดีอกลับไปที่จุดเริ่มต้นหลังการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเข้า ค้นหา [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) ตัวแรกบนสไลด์แรกและเปิดการถอยวิดีโอ มันปิดการวนซ้ำเพื่อให้การเล่นเสร็จสิ้นและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่แล้วบนสไลด์แรก

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

การถอยวิดีโอทำให้วิดีอกลับไปที่จุดเริ่มต้นโดยไม่เริ่มใหม่ ในทางกลับกัน การเรียก [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ด้วยค่า `true` จะทำให้การเล่นวนซ้ำโดยอัตโนมัติ ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอเล่นจนจบและพร้อมสำหรับการเล่นอีกครั้ง [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิกอย่างอิสระ ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) เพื่อให้ผู้พูดควบคุมเวลาการเริ่มเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การถอยทำงานอิสระจาก [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-)

## **ตัดเฟรมวิดีโอ**

ใช้ [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) และ [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) เพื่อตัดส่วนต้นหรือส่วนท้ายของวิดีโอระหว่างการเล่น ทั้งสองค่าเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและละเลย 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่เล่นได้

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

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอ จะไม่มีการพิมพ์ ตัวอย่างก่อนหน้านี้ให้ค่าที่ 2500 และ 1000

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

Aspose.Slides ให้คุณจัดการคำบรรยายแบบปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกจัดเก็บในรูปแบบ WebVTT และเปิดให้เข้าถึงผ่านเมธอด [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--)

### **เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ที่มีป้ายชื่อ English เวลาตราประทับของคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกจะรวมทั้งวิดีโอและคำบรรยาย

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

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีม

### **สกัดคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกกัน หมายเลขต่อเนื่องทำให้ไฟล์ผลลัพธ์แยกจากกัน คอนโซลจะแจ้งจำนวนแทร็กที่สกัด งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

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

แต่ละอ็อบเจกต์ [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) เปิดเผยตัวระบุคำบรรยาย ป้ายชื่อ ข้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8

### **ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างนั้นเป็นเฟรมวิดีโอ

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

หากต้องการลบเพียงแทร็กคำบรรยายเดียว ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) แทน [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--)

### **ค้นหาคำบรรยายวิดีโอ**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) คืนค่าแทร็ก WebVTT ทั้งหมดรวมถึงหัวเรื่อง บรรทัดเวลา และข้อความคำบรรยาย คุณสามารถค้นหาคิวในหน่วยความจำเพื่อหา ประโยคที่พูดและเวลาประทับของมัน ตัวอย่างเช่น แทร็ก English บนสไลด์ 2 อาจมีข้อความต่อไปนี้

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

ตัวอย่างนี้เปิดไฟล์ `captioned_media.pptx` และใช้ [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) เพื่ออ่านแทร็กของแต่ละเฟรมวิดีโอระดับบนบนทุกสไลด์ ในคิวข้อความธรรมดา บรรทัดเวลาจะมี `-->` และบรรทัดว่างจะสิ้นสุดคิว เมื่อคำบรรยายมีคำว่า “café” ในรูปแบบตัวอักษรใดก็ได้ ตัวอย่างจะพิมพ์หมายเลขสไลด์ ป้ายแทร็ก บรรทัดเวลาต้นฉบับ และคำบรรยายทั้งหมด

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

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
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
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

การค้นหา “café” ให้ผลลัพธ์ที่ตรงหนึ่งรายการสำหรับแทร็กตัวอย่าง การค้นหานี้จะยกเว้นหัวแทร็กและคงการตั้งค่าเวลาไว้ในผลลัพธ์

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงสไลด์ Aspose.Slides ยังอนุญาตให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้สกัดวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบนารีแยกตามลำดับ หมายเลข วิดีโอที่ลิงก์จะถูกข้ามเพราะไม่มีข้อมูลฝัง คอนโซลจะแสดงประเภท MIME ของแต่ละวิดีโอและจำนวนรวม ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; ปรับเปลี่ยนตามประเภทสื่อที่รายงานเมื่อจำเป็น

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

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงได้สำหรับเฟรมวิดีโอ?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านเมธอดของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกใส่ในเอกสารทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปย่อ งานนำชี้จะบันทึกลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นการเพิ่มขนาดมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในเฟรมวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ภายในเฟรมโดยคงรูปร่างไว้; นี่เป็นสถานการณ์ทั่วไปสำหรับอัปเดตสื่อในเลย์เอาต์ที่มีอยู่

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ใช่ วิดีโอที่ฝังมี [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) ที่คุณสามารถอ่านและใช้ได้ เช่น เมื่อบันทึกลงดิสก์