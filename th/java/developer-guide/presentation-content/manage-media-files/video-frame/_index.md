---
title: จัดการกรอบวิดีโอในงานนำเสนอโดยใช้ Java
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
- เอกสารเปิด
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การเพิ่มและสกัดกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมโดยใช้ Aspose.Slides สำหรับ Java. คู่มือสั้นเร็ว."
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ.

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (เก็บไว้บนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วัตถุวิดีโอ) ลงในงานนำเสนอได้ Aspose.Slides มีอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideo/) อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ.

## **สร้างกรอบวิดีโอฝังตัว**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ของคุณถูกเก็บไว้ในเครื่องคุณสามารถสร้างกรอบวิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอของคุณได้.

1. สร้างอินสแทนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)class.
1. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
1. เพิ่มวัตถุ [IVideo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideo/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอ. 
1. เพิ่มวัตถุ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) เพื่อสร้างกรอบสำหรับวิดีโอ.  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // โหลดวิดีโอ
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // รับสไลด์แรกและเพิ่ม videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

อีกทางเลือกหนึ่ง คุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **สร้างกรอบวิดีโอกับวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint 2013 และใหม่กว่า](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมันได้.

1. สร้างอินสแทนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)class
1. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
1. เพิ่มวัตถุ [IVideo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideo/) และส่งลิงก์ไปยังวิดีโอ.
1. ตั้งค่าภาพย่อสำหรับกรอบวิดีโอ. 
1. บันทึกงานนำเสนอ. 

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // เพิ่ม videoFrame
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // โหลดภาพย่อ
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **ตัดกรอบวิดีโอ**

Aspose.Slides ให้คุณควบคุมส่วนของวิดีโอที่เล่นโดยกำหนดค่า trim‑from‑start และ trim‑from‑end ผ่าน [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) และ [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). ค่าทั้งสองกำหนดเป็นมิลลิวินาทีและบ่งบอกระยะเวลาที่ข้ามจากจุดเริ่มต้นและจุดสิ้นสุดของวิดีโอตามลำดับ การตั้งค่าเหล่านี้เปลี่ยนการเล่นวิดีโอในงานนำเสนอ; ไม่ได้ตัดหรือแก้ไขข้อมูลไบต์ของวิดีโอที่ฝังไว้.

**ตั้งค่าการตัด**

เพื่อสร้างกรอบวิดีโอและตั้งค่าการตัดของมัน:

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. เพิ่มวัตถุ [IVideo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideo/) ลงในงานนำเสนอ.
1. เพิ่มวัตถุ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) ลงบนสไลด์.
1. ตั้งค่า trim‑from‑start และ trim‑from‑end ผ่าน [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) และ [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**อ่านการตั้งค่าการตัด**

เพื่อดูการตั้งค่าการตัดที่มีอยู่ โหลดงานนำเสนอ ค้นหาอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) บนสไลด์แรกและอ่านค่าผ่าน [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) และ [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับกรอบวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**เพิ่มคำบรรยายลงในกรอบวิดีโอ**

เพื่อเพิ่มคำบรรยายลงในกรอบวิดีโอ:

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. เพิ่มวิดีโอลงในงานนำเสนอ.
1. เพิ่มวัตถุ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) ลงบนสไลด์.
1. ใช้ [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/) ที่ได้จากการเรียก [getCaptionTracks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT.
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้.

**สกัดคำบรรยายจากกรอบวิดีโอ**

เพื่อสกัดคำบรรยายจากกรอบวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ.
1. ค้นหาอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) เป้าหมาย.
1. วนลูปผ่านแทร็กคำบรรยายใน [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/).
1. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

แต่ละอ็อบเจกต์ [ICaptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptions/) จะเปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบต์และข้อความคำบรรยายเป็นสตริง UTF‑8.

**ลบคำบรรยายจากกรอบวิดีโอ**

เพื่อทำการลบคำบรรยายจากกรอบวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ.
1. รับอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) เป้าหมาย.
1. ลบแทร็กคำบรรยายจาก [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/).
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // ลบคำบรรยายทั้งหมดออกจากกรอบวิดีโอ.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบเพียงแทร็กคำบรรยายเดียว ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#removeAt-int-) แทนการใช้ [clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#clear--).

## **สกัดวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงในสไลด์แล้ว Aspose.Slides ยังสามารถสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอได้.

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) เพื่อโหลดงานนำเสนอที่มีวิดีโอ. 
2. วนลูปผ่านอ็อบเจกต์ทั้งหมดของ [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/). 
3. วนลูปผ่านอ็อบเจกต์ทั้งหมดของ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) เพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/). 
4. บันทึกวิดีโอลงดิสก์.

```java
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Gets the File Extension
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/#setPlayMode-int-) (อัตโนมัติหรือเมื่อคลิก) และ [การวนลูป](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ตัวเลือกเหล่านี้ใช้ได้ผ่านคุณสมบัติของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/).

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่. เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบต์จะถูกใส่ในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์นั้น เมื่อคุณเพิ่มวิดีโอออนไลน์ จะฝังเพียงลิงก์และภาพย่อ ทำให้การเพิ่มขนาดเล็กกว่า.

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่ต้องเปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่. คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ภายในกรอบโดยยังคงรูปทรงของรูปแบบเดิมไว้; นี้เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลเอาต์ที่มีอยู่.

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ใช่. วิดีโอที่ฝังไว้มี [ประเภทเนื้อหา](https://reference.aspose.com/slides/th/java/com.aspose.slides/video/#getContentType--) ที่คุณสามารถอ่านและใช้ได้, ตัวอย่างเช่นเมื่อต้องบันทึกลงดิสก์.