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
- สกัดวิดีโอ
- ดึงวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET คำแนะนำวิธีทำอย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides for .NET ทำให้คุณสามารถเพิ่มเฟรมวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังไว้ได้

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อแทนข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีส่วนต่อประสาน [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) และชนิดที่เกี่ยวข้องอื่นๆ

## **สร้างเฟรมวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ถูกเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอในงานนำเสนอของคุณ

ตัวอย่างนี้ฝังวิดีโอในเครื่องลงในสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมหน่วยเป็นจุด สตรีมจะเปิดค้างจนกว่าการบันทึกจะเสร็จสิ้น เพราะ [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) จะล็อกสตรีมขณะงานนำเสนอใช้งานอยู่

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

คุณสามารถส่งพาธวิดีโอในเครื่องโดยตรงไปยัง [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) ตัวอย่างนี้ฝังวิดีโอลงในสไลด์แรกของงานนำเสนอใหม่ วิดีโอจะต้องสามารถเข้าถึงได้จนกว่างานนำหน้าจะถูกบันทึก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **สร้างเฟรมวิดีโอด้วยวิดีโอจากแหล่งบนเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปภาพย่อลงในสไลด์แรก แทนที่ตัวระบุวิดีโอเพื่อใช้วิดีโออื่น การตั้งค่า [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) ขอการเล่นอัตโนมัติ การดาวน์โหลดรูปภาพย่อและการเล่นวิดีโอต้องเชื่อมต่ออินเทอร์เน็ต ตัวดูงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **เล่นวิดีโอในโหมดเต็มจอ**

ในการนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มจอบนหน้าจอเพื่อให้ผู้ชมมองเห็นรายละเอียดได้ ตั้งค่า [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) เป็น `true` เพื่อเปิดใช้พฤติกรรมนี้ขณะการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) แรกบนสไลด์แรก และเปิดใช้งานการเล่นเต็มจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

การเล่นเต็มจอควบคุมการแสดงผลของวิดีโอ อย่างอิสระ [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) ควบคุมว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และ [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ควบคุมว่าจะวนซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่มต้น ให้ตั้งค่าโหมดการเล่นเป็น [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) ตัวอย่างจะรักษาการตั้งค่าเริ่มต้นและลูปที่มีอยู่

## **ถอยกลับวิดีโหลังจากการเล่น**

ในการนำเสนอการฝึกอบรม การคืนวิดีโอสาธิตกลับไปที่จุดเริ่มต้นทำให้พร้อมสำหรับผู้บรรยายที่จะเล่นใหม่ตั้งค่า [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) เป็น `true` เพื่อคืนวิดีโอกลับไปที่จุดเริ่มต้นหลังจากการเล่นเสร็จสิ้น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) แรกบนสไลด์แรกและเปิดใช้งานการถอยกลับ มันปิดการวนลูปเพื่อให้การเล่นเสร็จสิ้นและตั้งค่าให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโอบนสไลด์แรก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

การถอยกลับจะคืนวิดีโอกลับไปที่จุดเริ่มต้นโดยไม่เริ่มใหม่ ในทางตรงกันข้าม การเปิดใช้งาน [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) จะทำให้การเล่นวนซ้ำโดยอัตโนมัติ ให้ปิดการวนลูปเมื่อคุณต้องการให้วิดีโอจบและพร้อมสำหรับการเล่นใหม่ [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) ควบคุมการเริ่มต้นอัตโนมัติหรือเมื่อคลิกอย่างอิสระ ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมเวลาเริ่มการเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าลูปตามที่แสดงในตัวอย่าง การถอยกลับทำงานอิสระจาก [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/)

## **ตัดส่วนของเฟรมวิดีโอ**

ใช้ [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) และ [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) เพื่อตัดส่วนเริ่มหรือส่วนท้ายของวิดีโอระหว่างการเล่น ทั้งสองค่าเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังไว้

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้ส่วนที่ทำการเล่นเหลืออยู่

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**อ่านค่าการตัด**

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอ จะไม่มีการพิมพ์ ตัวอย่างก่อนหน้าจะให้ค่า 2500 และ 1000

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และเปิดเผยผ่านคุณสมบัติ [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/)

**เพิ่มคำบรรยายลงในเฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ที่มีป้ายชื่อ English เวลาตำแหน่งคำบรรยายต้องตรงกับวิดีโอ งานนำเสนอที่บันทึกจะรวมทั้งวิดีโอและคำบรรยายไว้ด้วย

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**สกัดคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกต่างหาก ตัวเลขต่อเนื่องทำให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน คอนโซลจะแสดงจำนวนแทร็กที่สกัด งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

แต่ละวัตถุ [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) จะเปิดเผยตัวระบุคำบรรยาย ป้ายชื่อ ข้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8

**ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นเฟรมวิดีโอ

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

หากคุณต้องการลบแทร็กคำบรรยายเพียงหนึ่งรายการ ให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) แทน [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/)

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอลงในสไลด์แล้ว Aspose.Slides ยังให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้สกัดวิดีโอที่ฝังอยู่จากทุกสไลด์ไปเป็นไฟล์ไบนารีที่มีเลขลำดับแยกกัน วิดีโอที่เชื่อมโยงจะถูกข้ามเพราะไม่มีข้อมูลฝัง คอนโซลจะพิมพ์ประเภท MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; หากต้องการให้ตรงกับประเภทสื่อที่รายงานให้เปลี่ยนส่วนขยายตามความจำเป็น

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**พารามิเตอร์การเล่นวิดีโอที่สามารถเปลี่ยนแปลงได้สำหรับเฟรมวิดีโอคืออะไร?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ตัวเลือกเหล่านี้พร้อมให้ใช้ผ่านคุณสมบัติต่างๆ ของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/)

**การเพิ่มวิดีโอจะส่งผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ หากคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปภาพย่อ งานนำเสนอจะบันทึกแค่ลิงก์และภาพพรีวิวแทนข้อมูลวิดีโอ ทำให้การเพิ่มขนาดมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในเฟรมที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) ภายในเฟรมได้โดยคงรูปทรงเดิมไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเค้าโครงที่มีอยู่

**สามารถตรวจสอบชนิดเนื้อหา (MIME) ของวิดีโอที่ฝังอยู่ได้หรือไม่?**

ใช่ วิดีโอที่ฝังอยู่มี [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) ที่คุณสามารถอ่านและนำไปใช้ได้ ตัวอย่างเช่นเมื่อบันทึกลงดิสก์