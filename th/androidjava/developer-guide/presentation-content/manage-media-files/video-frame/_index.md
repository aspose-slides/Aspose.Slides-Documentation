---
title: จัดการ Video Frames ในงานนำเสนอบน Android
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
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java อย่างรวดเร็ว คู่มือวิธีทำ"
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (จัดเก็บบนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณเพิ่มวิดีโอ (วัตถุวิดีโอ) ลงในงานนำเสนอ, Aspose.Slides มีอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideo/) อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้าง Video Frame ฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์จัดเก็บในเครื่อง, คุณสามารถสร้าง video frame เพื่อฝังวิดีโอลงในงานนำเสนอของคุณได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน.
3. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideo/) และส่งพาธของไฟล์วิดีโอเพื่อฝังวิดีโอเข้ากับงานนำเสนอ.
4. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Java นี้แสดงวิธีเพิ่มวิดีโอที่จัดเก็บในเครื่องลงในงานนำเสนอ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // โหลดวิดีโอ
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // ดึงสไลด์แรกและเพิ่ม video frame
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

หรืออีกทางหนึ่ง, คุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **สร้าง Video Frame จากวิดีโอบนเว็บ**

Microsoft [PowerPoint 2013 และใหม่กว่า](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในการนำเสนอ หากวิดีโอที่คุณต้องการใช้มีออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน.
3. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideo/) และส่งลิงก์ของวิดีโอ.
4. ตั้งค่า thumbnail สำหรับ video frame.
5. บันทึกงานนำเสนอ.

โค้ด Java นี้แสดงวิธีเพิ่มวิดีโอจากเว็บลงในสไลด์ของการนำเสนอ PowerPoint:

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

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ให้คุณจัดการ closed captions สำหรับ video frames ใน PowerPoint presentations. คำบรรยายถูกเก็บในรูปแบบ WebVTT และเข้าถึงผ่านเมธอด [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 

**เพิ่มคำบรรยายลงใน Video Frame**

เพื่อเพิ่มคำบรรยายลงใน video frame:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เพิ่มวิดีโอลงในงานนำเสนอ.
3. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) ไปยังสไลด์.
4. ใช้ [ICaptionsCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/) ที่ส่งคืนโดย [getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) เพื่อเพิ่ม WebVTT caption track.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ดต่อไปนี้แสดงวิธีเพิ่มคำบรรยายลงใน video frame:

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

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**สกัดคำบรรยายจาก Video Frame**

เพื่อสกัดคำบรรยายจาก video frame:

1. โหลดงานนำเสนอที่มีวิดีโออยู่.
2. ค้นหาอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) ที่ต้องการ.
3. วนลูปผ่าน caption tracks ที่ส่งคืนโดย [getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
4. บันทึกแต่ละ caption track เป็นไฟล์ `.vtt`.

โค้ดต่อไปนี้แสดงวิธีสกัดคำบรรยายจาก video frame:

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

แต่ละอ็อบเจ็กต์ [ICaptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptions/) เปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี, และข้อมูลคำบรรยายเป็นสตริง UTF-8

**ลบคำบรรยายจาก Video Frame**

เพื่อเปลียนคำบรรยายจาก video frame:

1. โหลดงานนำเสนอที่มีวิดีโออยู่.
2. รับอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) ที่ต้องการ.
3. ลบ caption tracks ออกจากคอลเลกชันที่ส่งคืนโดย [getCaptionTracks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
4. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจาก video frame:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบเพียงหนึ่ง caption track ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) แทนการใช้ [clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icaptionscollection/#clear--)

## **สกัดวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอในสไลด์แล้ว Aspose.Slides ยังให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) เพื่อโหลดงานนำเสนอที่มีวิดีโอ.
2. วนลูปผ่านอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) ทั้งหมด.
3. วนลูปผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/).
4. บันทึกวิดีโอลงดิสก์.

โค้ด Java นี้แสดงวิธีสกัดวิดีโอจากสไลด์ของงานนำเสนอ:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ 
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

                //รับส่วนขยายของไฟล์
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

**พารามิเตอร์การเล่นวิดีโอที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame มีอะไรบ้าง?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/)

**การเพิ่มวิดีโอส่งผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่. เมื่อฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมไว้ในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ เมื่อเพิ่มวิดีโอออนไลน์ ลิงก์และ thumbnail จะถูกฝังไว้ทำให้การเพิ่มขนาดน้อยกว่า

**ฉันสามารถเปลี่ยนวิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่. คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ภายในเฟรมโดยคงรูปทรงไว้ ซึ่งเป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลเอาต์ที่มีอยู่

**สามารถตรวจสอบประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ใช่. วิดีโอที่ฝังไว้มี [content type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/video/#getContentType--) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อต้องบันทึกลงดิสก์