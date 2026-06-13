---
title: จัดการเฟรมวิดีโอในงานนำเสนอด้วย .NET
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเชิงโปรแกรมโดยใช้ Aspose.Slides สำหรับ .NET คู่มือวิธีทำอย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ.

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (เก็บไว้บนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วิดีโออ็อบเจกต์) ลงในงานนำเสนอได้ Aspose.Slides มีการให้บริการอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/th/net/aspose.slides/ivideo/) , อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ.

## **สร้างเฟรมวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มไปยังสไลด์ของคุณถูกเก็บไว้ในเครื่องคุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class.
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.
1. เพิ่มอ็อบเจกต์ [IVideo](https://reference.aspose.com/slides/th/net/aspose.slides/ivideo/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอเข้ากับงานนำเสนอ.
1. เพิ่มอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ.  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด C# นี้แสดงวิธีการเพิ่มวิดีโอที่เก็บไว้ในเครื่องลงในงานนำเสนอ:

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // โหลดวิดีโอ
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // รับสไลด์แรกและเพิ่มเฟรมวิดีโอ
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // บันทึกงานนำเสนอลงดิสก์
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
หรือคุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์ของมันโดยตรงไปยังเมธอด [AddVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีให้บริการออนไลน์ (เช่นบน YouTube) คุณสามารถเพิ่มมันลงในงานนำเสนอของคุณผ่านลิงก์เว็บของมันได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
1. เพิ่มอ็อบเจกต์ [IVideo](https://reference.aspose.com/slides/th/net/aspose.slides/ivideo/) และส่งลิงก์ไปยังวิดีโอ.
1. ตั้งค่า thumbnail สำหรับเฟรมวิดีโอ. 
1. บันทึกงานนำเสนอ.

โค้ด C# นี้แสดงวิธีการเพิ่มวิดีโอจากเว็บไปยังสไลด์ในงานนำเสนอ PowerPoint:

```c#
public static void Run()
{
    // สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // เพิ่ม VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // โหลดภาพย่อ
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกเก็บในรูปแบบ WebVTT และเข้าถึงได้ผ่านคุณสมบัติ [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/captiontracks/).

**เพิ่มคำบรรยายให้กับเฟรมวิดีโอ**

เพื่อเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) .
1. เพิ่มวิดีโอลงในงานนำเสนอ.
1. เพิ่มอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) ไปยังสไลด์.
1. ใช้คอลเลกชัน [CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/captiontracks/) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT.
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ดต่อไปนี้แสดงวิธีการเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icaptionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้.

**ดึงคำบรรยายจากเฟรมวิดีโอ**

เพื่อดึงคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ.
1. ค้นหาอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) ที่ต้องการ.
1. ทำการวนรอบผ่านคอลเลกชัน [CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/captiontracks/).
1. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`.

โค้ดต่อไปนี้แสดงวิธีการดึงคำบรรยายจากเฟรมวิดีโอ:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

แต่ละอ็อบเจกต์ [ICaptions](https://reference.aspose.com/slides/th/net/aspose.slides/icaptions/) จะเผยให้เห็นตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8.

**ลบคำบรรยายจากเฟรมวิดีโอ**

เพื่อเอาคำบรรยายออกจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ.
1. รับอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) ที่ต้องการ.
1. ลบแทร็กคำบรรยายจากคอลเลกชัน [CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/captiontracks/).
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ดต่อไปนี้แสดงวิธีการลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

หากคุณต้องการลบเพียงแทร็กคำบรรยายเดียว ให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/th/net/aspose.slides/captionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/captionscollection/removeat/) แทนการใช้ [Clear](https://reference.aspose.com/slides/th/net/aspose.slides/captionscollection/clear/).

## **ดึงวิดีโอจากสไลด์**
นอกจากการเพิ่มวิดีโอลงในสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอออกมาได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อโหลดงานนำเสนอที่มีวิดีโอ. 
2. ทำการวนรอบผ่านอ็อบเจกต์ทั้งหมดของ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide).
3. ทำการวนรอบผ่านอ็อบเจกต์ทั้งหมดของ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape) เพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe). 
4. บันทึกวิดีโอลงดิสก์.

โค้ด C# นี้แสดงวิธีการดึงวิดีโอจากสไลด์ในงานนำเสนอ:

```c#
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ 
Presentation presentation = new Presentation("Video.pptx");

// วนซ้ำผ่านสไลด์
foreach (ISlide slide in presentation.Slides)
{
    // วนซ้ำผ่านรูปร่าง
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // บันทึกวิดีโอลงดิสก์เมื่อพบ VideoFrame ที่มีวิดีโอ
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe/playmode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe/playloopmode/). ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe/).

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่. เมื่อคุณฝังวิดีโอในเครื่องข้อมูลไบนารีจะถูกรวมไว้ในเอกสาร ทำให้ขนาดงานนำเพิ่มขึ้นตามขนาดไฟล์ของวิดีโอ เมื่อคุณเพิ่มวิดีโอออนไลน์เพียงลิงก์และ thumbnail จะถูกฝังไว้ ดังนั้นการเพิ่มขนาดจึงน้อยกว่า.

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่. คุณสามารถสลับ [video content](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe/embeddedvideo/) ภายในเฟรมโดยคงรูปทรงของ shape ไว้ได้ ซึ่งเป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่.

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังอยู่ได้หรือไม่?**

ได้. วิดีโอที่ฝังอยู่มี [content type](https://reference.aspose.com/slides/th/net/aspose.slides/video/contenttype/) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อบันทึกลงดิสก์.