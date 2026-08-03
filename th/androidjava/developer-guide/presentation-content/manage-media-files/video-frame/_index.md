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
- ดึงวิดีโอ
- ดึงคืนวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้การเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างโปรแกรมโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. คู่มือวิธีทำแบบเร็ว"
---
## **คำนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ  

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอจากเครื่อง (จัดเก็บบนเครื่องของคุณ)  
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บ เช่น YouTube).  

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วิดีโออ็อบเจ็กต์) ลงในงานนำเสนอ, Aspose.Slides ให้ส่วนต่อประสาน [IVideo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ  

## **สร้างเฟรมวิดีโอแบบฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์จัดเก็บไว้ในเครื่อง, คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideo/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอ  
4. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีการเพิ่มวิดีโอที่จัดเก็บในเครื่องลงในงานนำเสนอ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // โหลดวิดีโอ
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // ดึงสไลด์แรกและเพิ่มเฟรมวิดีโอ
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

หรือคุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

เวอร์ชันใหม่ของ Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีอยู่บนเว็บ (เช่น YouTube) คุณสามารถเพิ่มมันลงในงานนำเสนอผ่านลิงก์เว็บได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideo/) และส่งลิงก์ไปยังวิดีโอ  
4. ตั้งค่า thumbnail สำหรับเฟรมวิดีโอ  
5. บันทึกงานนำเสนอ  

โค้ด Java นี้แสดงวิธีการเพิ่มวิดีโอจากเว็บลงในสไลด์ของงานนำเสนอ PowerPoint:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
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

    // โหลด thumbnail
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

## **ตัดเฟรมวิดีโอ**

Aspose.Slides อนุญาตให้คุณควบคุมส่วนของวิดีโอที่จะแสดงโดยตั้งค่าการตัดจากต้นและจากท้ายผ่าน [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) และ [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) ค่าทั้งสองระบุเป็นมิลลิวินาทีและกำหนดเวลาที่จะข้ามจากจุดเริ่มต้นและจุดสิ้นสุดของวิดีโอตามลำดับ การตั้งค่าเหล่านี้เปลี่ยนการเล่นวิดีโอในงานนำเสนอ; พวกมันไม่ได้ตัดหรือแก้ไขข้อมูลไบนารีของวิดีโอที่ฝังอยู่  

**ตั้งค่าการตัด**

เพื่อสร้างเฟรมวิดีโอและตั้งค่าการตัด:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideo/) ลงในงานนำเสนอ  
3. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) ลงในสไลด์  
4. ตั้งค่า trim-from-start และ trim-from-end ผ่าน [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) และ [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-)  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดตัวอย่างต่อไปนี้จะข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายของวิดีโอที่ฝังอยู่ระหว่างการเล่น:

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

เพื่อดูค่าการตัดที่มีอยู่ โหลดงานนำเสนอ, ค้นหาอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) ที่อยู่ในรูปร่างบนสไลด์แรก, แล้วอ่านค่าผ่าน [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) และ [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--)  

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

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกจัดเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)  

**เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เพิ่มวิดีโอลงในงานนำเสนอ  
3. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) ลงในสไลด์  
4. ใช้ [ICaptionsCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/) ที่ได้จาก [getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดต่อไปนี้แสดงวิธีการเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

ส่วนต่อประสาน [ICaptionsCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้อีกด้วย  

**ดึงคำบรรยายจากเฟรมวิดีโอ**

1. โหลดงานนำเสนอที่มีวิดีโออยู่  
2. ค้นหาอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) เป้าหมาย  
3. วนรอบผ่านแทร็กคำบรรยายที่ได้จาก [getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)  
4. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`  

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

แต่ละอ็อบเจ็กต์ [ICaptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptions/) จะเปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี และข้อมูลคำบรรยายในรูปแบบสตริง UTF-8  

**ลบคำบรรยายจากเฟรมวิดีโอ**

1. โหลดงานนำเสนอที่มีวิดีโออยู่  
2. รับอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) เป้าหมาย  
3. ลบแทร็กคำบรรยายจากคอลเลกชันที่ได้จาก [getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)  
4. บันทึกงานนำเสนอที่แก้ไขแล้ว  

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // ลบคำบรรยายทั้งหมดออกจากเฟรมวิดีโอ.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบเฉพาะแทร็กคำบรรยายหนึ่งเดียว ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) แทนการใช้ [clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#clear--)  

## **ดึงวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงในสไลด์, Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอออกมาได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) เพื่อโหลดงานนำเสนอที่มีวิดีโอ  
2. วนรอบผ่านอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) ทั้งหมด  
3. วนรอบผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/)  
4. บันทึกวิดีโอลงดิสก์  

```java
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ 
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

                // รับส่วนขยายของไฟล์
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

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (อัตโนมัติหรือคลิก) และ [looping](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ได้ ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติเวเจ็ตของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/)  

**การเพิ่มวิดีโอมีกระทบต่อขนาดไฟล์ PPTX หรือไม่?**  

ใช่ เมื่อคุณฝังวิดีโอจากเครื่อง ไฟล์ไบนารีของวิดีโอจะถูกรวมอยู่ในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ของวิดีโอ เมื่อคุณเพิ่มวิดีโอออนไลน์ เพียงแค่ฝังลิงก์และ thumbnail ทำให้การเพิ่มขนาดน้อยกว่า  

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**  

ได้ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ภายในเฟรมได้โดยคงรูปทรงของเฟรมไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่  

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังอยู่ได้หรือไม่?**  

ได้ วิดีโอที่ฝังอยู่มี [content type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/video/#getContentType--) ที่คุณสามารถอ่านและนำไปใช้ได้ เช่น เมื่อต้องการบันทึกลงดิสก์