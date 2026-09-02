---
title: "จัดการเฟรมวิดีโอในงานนำเสนอด้วย .NET"
linktitle: "เฟรมวิดีโอ"
type: docs
weight: 10
url: /th/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างโปรแกรมเมติกด้วย Aspose.Slides สำหรับ .NET. คำแนะนำแบบเร็ว"
---
## **คำนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ  

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอในเครื่อง (เก็บไว้บนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วิดีโออ็อบเจ็กต์) ลงในงานนำเสนอได้ Aspose.Slides มีอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/th/net/aspose.slides/ivideo/) อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) และประเภทที่เกี่ยวข้องอื่นๆ  

## **สร้างเฟรมวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ถูกเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณ  

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/net/aspose.slides/ivideo/)และส่งเส้นทางไฟล์วิดีโอเพื่อฝังวิดีโอในงานนำเสนอ  
1. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/)เพื่อสร้างเฟรมสำหรับวิดีโอ  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation
 using (Presentation pres = new Presentation("pres.pptx"))
 {
     // โหลดวิดีโอ
     using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
     {
         IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
         
         // ดึงสไลด์แรกและเพิ่มเฟรมวิดีโอ
         pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
         
         // บันทึกงานนำเสนอลงดิสก์
         pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
     }
 }
```
หรือคุณสามารถเพิ่มวิดีโอโดยส่งเส้นทางไฟล์โดยตรงไปยังเมธอด [AddVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

เวอร์ชันใหม่ของ Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีอยู่บนอินเทอร์เน็ต (เช่นบน YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมัน  

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/net/aspose.slides/ivideo/)และส่งลิงก์ไปยังวิดีโอ  
1. ตั้งค่า thumbnail สำหรับเฟรมวิดีโอ  
1. บันทึกงานนำเสนอ  

```c#
public static void Run()
{
    // สร้างออบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ 
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

## **ตัดเฟรมวิดีโอ**

Aspose.Slides อนุญาตให้คุณควบคุมว่าเป็นส่วนใดของวิดีโอที่จะเล่นโดยกำหนดค่า trim‑from‑start และ trim‑from‑end ผ่าน [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/trimfromstart/) และ [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/trimfromend/) ค่าทั้งสองระบุเป็นมิลลิวินาทีและบ่งบอกระยะเวลาที่ถูกข้ามจากจุดเริ่มต้นและจุดสิ้นสุดของวิดีโอ การตั้งค่านี้เปลี่ยนการเล่นวิดีโอในงานนำเสนอ; ไม่ได้ตัดหรือแก้ไขข้อมูลไบนารีของวิดีโอที่ฝังอยู่  

**ตั้งค่าการตัด**

เพื่อสร้างเฟรมวิดีโอและตั้งค่าการตัด:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
1. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/net/aspose.slides/ivideo/)ลงในงานนำเสนอ  
1. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/)ลงในสไลด์  
1. ตั้งค่า trim‑from‑start และ trim‑from‑end ผ่าน [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/trimfromstart/) และ [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/trimfromend/)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**อ่านการตั้งค่าการตัด**

เพื่อดูการตั้งค่าการตัดที่มีอยู่ ให้โหลดงานนำเสนอ ค้นหาอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) ในรูปทรงของสไลด์แรก และอ่านค่าผ่าน [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/trimfromstart/) และ [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/trimfromend/)  

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายแบบปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกเก็บในรูปแบบ WebVTT และเปิดเผยผ่านคุณสมบัติ [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/captiontracks/)  

**เพิ่มคำบรรยายไปยังเฟรมวิดีโอ**

เพื่อเพิ่มคำบรรยายไปยังเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
1. เพิ่มวิดีโอลงในงานนำเสนอ  
1. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/)ลงในสไลด์  
1. ใช้คอลเลกชัน [CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/captiontracks/) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

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

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้  

**สกัดคำบรรยายจากเฟรมวิดีโอ**

เพื่อสกัดคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโออยู่  
1. ค้นหาอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/)เป้าหมาย  
1. วนลูปผ่านคอลเลกชัน [CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/captiontracks/)  
1. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`  

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
                // บันทึกแทร็กคำบรรยายลงไฟล์ WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

แต่ละอ็อบเจ็กต์ [ICaptions](https://reference.aspose.com/slides/th/net/aspose.slides/icaptions/) เปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF‑8  

**ลบคำบรรยายจากเฟรมวิดีโอ**

เพื่อถอดคำบรรยายออกจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโออยู่  
1. รับอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/)เป้าหมาย  
1. ลบแทร็กคำบรรยายจากคอลเลกชัน [CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/captiontracks/)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

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

หากต้องการลบเพียงแทร็กคำบรรยายเดียว ให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/th/net/aspose.slides/captionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/captionscollection/removeat/) แทนการใช้ [Clear](https://reference.aspose.com/slides/th/net/aspose.slides/captionscollection/clear/)  

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงสไลด์แล้ว Aspose.Slides ยังสามารถสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อโหลดงานนำเสนอที่มีวิดีโอ  
2. วนลูปผ่านอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide) ทั้งหมด  
3. วนลูปผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe)  
4. บันทึกวิดีโอลงดิสก์  

```c#
 // สร้างออบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ 
 Presentation presentation = new Presentation("Video.pptx");

// วนลูปผ่านสไลด์
 foreach (ISlide slide in presentation.Slides)
 {
     // วนลูปผ่านรูปร่าง
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

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**  

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe/playmode/) (อัตโนมัติหรือเมื่อคลิก) และ [การวนลูป](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe/playloopmode/) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe/)  

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**  

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมอยู่ในเอกสารทำให้ขนาดงานนำเพิ่มตามขนาดไฟล์วิดีโอ ส่วนการเพิ่มวิดีโอออนไลน์จะฝังลิงก์และภาพย่อเท่านั้น ทำให้การเพิ่มขนาดเล็กกว่า  

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**  

ได้ คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/th/net/aspose.slides/videoframe/embeddedvideo/) ภายในเฟรมโดยยังคงรูปทรงของสไลด์ไว้ ซึ่งเป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่  

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**  

ได้ วิดีโอที่ฝังไว้มี [ประเภทเนื้อหา](https://reference.aspose.com/slides/th/net/aspose.slides/video/contenttype/) ซึ่งคุณสามารถอ่านและนำไปใช้ได้ ตัวอย่างเช่นเมื่อต้องการบันทึกลงดิสก์  