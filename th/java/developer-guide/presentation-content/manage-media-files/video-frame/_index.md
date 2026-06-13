---
title: "จัดการ Video Frame ในการนำเสนอโดยใช้ Java"
linktitle: "กรอบวิดีโอ"
type: docs
weight: 10
url: /th/java/video-frame/
keywords:
- "เพิ่มวิดีโอ"
- "สร้างวิดีโอ"
- "ฝังวิดีโอ"
- "ดึงวิดีโอ"
- "ดึงคืนวิดีโอ"
- "กรอบวิดีโอ"
- "แหล่งเว็บ"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "เรียนรู้การเพิ่มและดึงกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมด้วย Aspose.Slides สำหรับ Java. คู่มือวิธีทำที่รวดเร็ว."
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานพรีเซนเทชั่นสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ  

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของพรีเซนเทชั่นได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (จัดเก็บบนเครื่องของคุณ)  
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).  

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วัตถุวิดีโอ) ลงในพรีเซนเทชั่น, Aspose.Slides มีการให้บริการอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideo/) , อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) และชนิดที่เกี่ยวข้องอื่น ๆ  

## **สร้าง Video Frame ฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์จัดเก็บไว้ในเครื่อง, คุณสามารถสร้าง video frame เพื่อฝังวิดีโอในพรีเซนเทชั่นของคุณ  

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideo/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโเข้ากับพรีเซนเทชั่น  
4. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ  
5. บันทึกพรีเซนเทชั่นที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีการเพิ่มวิดีโอที่จัดเก็บไว้ในเครื่องลงในพรีเซนเทชั่น:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // โหลดวิดีโอ
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // รับสไลด์แรกและเพิ่ม VideoFrame
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // บันทึกพรีเซนเทชั่นลงดิสก์
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

อีกทางหนึ่ง, คุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **สร้าง Video Frame พร้อมวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint 2013 และรุ่นใหม่กว่า](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในพรีเซนเทชั่น หากวิดีโอที่คุณต้องการใช้มีออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มลงในพรีเซนเทชั่นผ่านลิงก์เว็บของมัน  

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideo/) และส่งลิงก์ไปยังวิดีโอ  
4. ตั้งค่า thumbnail สำหรับ video frame  
5. บันทึกพรีเซนเทชั่น  

```java
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น
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
    // เพิ่ม VideoFrame
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

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการ closed captions สำหรับ video frames ใน PowerPoint พรีเซนเทชั่น คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และเปิดเผยผ่านเมธอด [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#getCaptionTracks--)  

**เพิ่มคำบรรยายให้กับ Video Frame**

เพื่อเพิ่มคำบรรยายให้กับ video frame:  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
2. เพิ่มวิดีโอลงในพรีเซนเทชั่น  
3. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) ไปยังสไลด์  
4. ใช้ [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/) ที่ได้จาก [getCaptionTracks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) เพื่อเพิ่ม WebVTT caption track  
5. บันทึกพรีเซนเทชั่นที่แก้ไขแล้ว  

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

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีม  

**ดึงคำบรรยายจาก Video Frame**

เพื่อดึงคำบรรยายจาก video frame:  

1. โหลดพรีเซนเทชั่นที่มีวิดีโอ  
2. ค้นหาอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) ที่ต้องการ  
3. วนผ่าน caption tracks ใน [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/)  
4. บันทึกแต่ละ caption track ลงในไฟล์ `.vtt`  

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // บันทึกแทร็กคำบรรยายไปยังไฟล์ WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

แต่ละอ็อบเจ็กต์ [ICaptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptions/) แสดงตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี, และข้อความคำบรรยายในรูปแบบสตริง UTF-8  

**ลบคำบรรยายจาก Video Frame**

เพื่อขจัดคำบรรยายออกจาก video frame:  

1. โหลดพรีเซนเทชั่นที่มีวิดีโอ  
2. รับอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivideoframe/) ที่ต้องการ  
3. ลบ caption tracks จาก [ICaptionsCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/)  
4. บันทึกพรีเซนเทชั่นที่แก้ไขแล้ว  

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // ลบคำบรรยายทั้งหมดจากกรอบวิดีโอ
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณต้องการลบเฉพาะหนึ่ง caption track, ให้ใช้เมธอด [remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) หรือ [removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#removeAt-int-) แทนการใช้ [clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/icaptionscollection/#clear--)  

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงในสไลด์แล้ว, Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในพรีเซนเทชั่น  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) เพื่อโหลดพรีเซนเทชั่นที่มีวิดีโอ  
2. วนผ่านวัตถุ [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) ทั้งหมด  
3. วนผ่านวัตถุ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/)  
4. บันทึกวิดีโอลงดิสก์  

```java
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น 
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

                //ดึงส่วนขยายของไฟล์
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

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**  
คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/#setPlayMode-int-) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/)  

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**  
ใช่. เมื่อคุณฝังวิดีโอในเครื่อง, ข้อมูลไบนารีจะถูกเก็บในเอกสาร ทำให้ขนาดพรีเซนเทชั่นเพิ่มตามขนาดไฟล์ เมื่อคุณเพิ่มวิดีโอออนไลน์, จะฝังลิงก์และ thumbnail เท่านั้น ทำให้การเพิ่มขนาดน้อยลง  

**ฉันสามารถเปลี่ยนวิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**  
ได้. คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ภายในเฟรมโดยคงรูปทรงของ shape ไว้; นี่เป็นสถานการณ์ทั่วไปในการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่  

**สามารถตรวจสอบประเภทของเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**  
ได้. วิดีโอที่ฝังมี [content type](https://reference.aspose.com/slides/th/java/com.aspose.slides/video/#getContentType--) ที่คุณสามารถอ่านและใช้ได้ เช่น เมื่อบันทึกลงดิสก์