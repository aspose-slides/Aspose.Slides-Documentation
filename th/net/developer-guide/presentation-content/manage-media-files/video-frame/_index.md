---
title: จัดการกรอบวิดีโอในการนำเสนอด้วย .NET
linktitle: กรอบวิดีโอ
type: docs
weight: 10
url: /th/net/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- สกัดวิดีโอ
- ดึงวิดีโอ
- กรอบวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างโปรแกรมมิงด้วย Aspose.Slides for .NET. คู่มือวิธีทำอย่างรวดเร็ว."
---
## **คำนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้. Aspose.Slides for .NET ให้คุณเพิ่มกรอบวิดีโอลงสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังอยู่ออกมา.  
PowerPoint รองรับวิดีโอที่อยู่ในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube.  
เพื่อแสดงข้อมูลวิดีโอและกรอบวิดีโอ Aspose.Slides มีส่วนต่อประสาน [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) อินเทอร์เฟซ, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) อินเทอร์เฟซ, และประเภทที่เกี่ยวข้องอื่น ๆ.

## **สร้างกรอบวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ถูกจัดเก็บไว้ในเครื่อง คุณสามารถสร้างกรอบวิดีโอเพื่อฝังวิดีโอลงในการนำเสนอได้.  
ตัวอย่างนี้ฝังวิดีโอในเครื่องลงในสไลด์แรกของการนำเสนอที่มีอยู่และบันทึกผลลัพธ์. พิกัดและขนาดของกรอบใช้หน่วยจุด. สตรีมจะเปิดค้างไว้จนกว่าการบันทึกเสร็จสิ้นเนื่องจาก [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) ทำให้ถูกล็อกในขณะที่การนำเสนอใช้งาน.

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

คุณสามารถส่งเส้นทางไฟล์วิดีโอในเครื่องโดยตรงไปยัง [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) ได้ด้วยเช่นกัน. ตัวอย่างนี้ฝังวิดีโอลงในสไลด์แรกของการนำเสนอใหม่. วิดีโอต้องสามารถเข้าถึงได้จนกว่าการนำเสนอจะถูกบันทึก.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **ตั้งระดับเสียงวิดีโออย่างแม่นยำ**

ใน Aspose.Slides for .NET 26.11 หรือใหม่กว่า, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) ตั้งค่าร้อยละแบบทศนิยมจาก 0 ถึง 100. ใช้เมื่อตัวตั้งค่า [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) มีความหยาบเกินไป. ตัวอย่างเช่น `75.5f` หมายถึงระดับเสียง 75.5%.

ตัวอย่างนี้ต้องการ [Aspose.Slides for .NET](/slides/th/net/installation/) 26.11 หรือใหม่กว่าและไฟล์ `video.mp4` ในเครื่อง. ตัวอย่างฝังวิดีโอ, เริ่มต้นการเล่นอย่างชัดเจน, บันทึกการนำเสนอ, และอ่านร้อยละที่บันทึกไว้กลับมา.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

ตรวจสอบค่าที่ใส่ด้วยตนเอง; อย่าพึ่งพา setter เพื่อตรวจสอบค่าที่อยู่นอกช่วงที่ระบุ. ค่าตั้งล่วงหน้า Low, Medium และ Loud ตรงกับ 20, 50 และ 80 ในเวอร์ชัน 26.11. การตั้งค่าล่วงหน้าจะเขียนทับเปอร์เซ็นต์ที่ตั้งไว้ก่อนหน้า ดังนั้นให้กำหนดเปอร์เซ็นต์เป็นขั้นตอนสุดท้ายเมื่อจำเป็นต้องการค่าที่แม่นยำ. ใช้ [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) สำหรับการปิดเสียงอย่างชัดเจน; ศูนย์เชิงตัวเลขและค่าล่วงหน้า enum ไม่สามารถใช้แทนกันได้.  
กำหนดค่า [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) อย่างชัดเจนเมื่อกำหนดค่าวิดีโอแบบเชื่อมโยงด้วย, และให้ไฟล์สื่อพร้อมใช้งานสำหรับผู้ดู. การบันทึกและเปิดใหม่ตรวจสอบค่าที่บันทึก; การเล่นจริงและระดับเสียงขึ้นอยู่กับโปรแกรมแสดงผลการนำเสนอและการตั้งค่าเสียงของมัน.

## **สร้างกรอบวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ. คุณสามารถสร้างกรอบวิดีโอที่เชื่อมโยงไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube.  
ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และภาพย thumbnail ลงในสไลด์แรก. แก้ไขตัวระบุวิดีโอเพื่อใช้วิดีโออื่น. การตั้งค่า [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) ขอให้เล่นอัตโนมัติ. การดาวน์โหลด thumbnail และการเล่นวิดีโอต้องการการเชื่อมต่ออินเทอร์เน็ต. ตัวดูการนำเสนอจะต้องรองรับการเล่นวิดีโอออนไลน์ด้วย.

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

## **เล่นวิดีโอในโหมดเต็มหน้าจอ**

ในงานนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียด. ตั้งค่า [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) เป็น `true` เพื่อเปิดพฤติกรรมนี้ระหว่างการเล่น.  
ตัวอย่างนี้เปิดการนำเสนอ, ค้นหา [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) ตัวแรกบนสไลด์แรก, และเปิดการเล่นเต็มหน้าจอ. การนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก.

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

การเล่นเต็มหน้าจอกำหนดว่าวิดีโอจะแสดงอย่างไร. แยกจากนั้น, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) ควบคุมว่าจะเริ่มอัตโนมัติหรือคลิก, และ [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ควบคุมการทำซ้ำ. เพื่อกำหนดพฤติกรรมการเริ่ม, ตั้งค่าโหมดเล่นเป็น [VideoPlayModePreset.Auto หรือ VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). ตัวอย่างนี้คงค่าการเริ่มและการวนซ้ำเดิมไว้.

## **หวนกลับวิดีหลังการเล่น**

ในงานนำเสนอการฝึกอบรม การนำวิดีโอสาธิตกลับไปที่จุดเริ่มต้นทำให้พร้อมให้ผู้นำเสนอเล่นใหม่. ตั้งค่า [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) เป็น `true` เพื่อให้วิดีโอกลับไปที่จุดเริ่มต้นหลังการเล่นเสร็จ.  
ตัวอย่างนี้เปิดการนำเสนอ, ค้นหา [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) ตัวแรกบนสไลด์แรก, และเปิดการหวนกลับ. ตัวอย่างปิดการวนซ้ำเพื่อให้การเล่นเสร็จและตั้งค่าให้เริ่มด้วยคลิก. การนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก.

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

การหวนกลับทำให้วิดีโอกลับไปที่จุดเริ่มต้นโดยไม่เริ่มใหม่. ตรงข้ามกับการเปิดใช้งาน [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ที่ทำให้การเล่นวนซ้ำอัตโนมัติ. ให้ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอเล่นจนจบและพร้อมเล่นใหม่. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) ควบคุมการเริ่มอัตโนมัติหรือคลิก; ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้นำเสนอควบคุมเวลาเริ่ม. ตั้งค่าโหมดเล่นหลังจากตั้งค่าการวนซ้ำ, ตามที่แสดงในตัวอย่าง. การหวนกลับทำงานแยกจาก [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **ตัดวิดีโอกรอบ**

ใช้ [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) และ [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) เพื่อตัดส่วนเริ่มหรือส่วนท้ายของวิดีโอระหว่างการเล่น. ทั้งสองค่ามีหน่วยเป็นมิลลิวินาที. การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่.

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและตัดส่วนแรก 2.5 วินาทีและส่วนสุดท้าย 1 วินาทีระหว่างการเล่น. ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่เล่นได้.

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

ตัวอย่างนี้พิมพ์ค่าการตัดของกรอบวิดีโอตัวแรกบนสไลด์แรกเป็นมิลลิวินาที. การนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์. หากสไลด์ไม่มีกรอบวิดีโอ จะไม่พิมพ์อะไร. ตัวอย่างก่อนหน้านี้ให้ค่า 2500 และ 1000.

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

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับกรอบวิดีโอในงานนำเสนอ PowerPoint. คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และเข้าถึงได้ผ่านคุณสมบัติ [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**เพิ่มคำบรรยายให้กรอบวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ชื่อ English. เวลาในคำบรรยายต้องตรงกับวิดีโอ. การนำเสนอที่บันทึกจะมีทั้งวิดีโอและคำบรรยายรวมกัน.

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

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้.

**สกัดคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากกรอบวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกต่างหาก. ตัวเลขลำดับช่วยให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน. คอนโซลรายงานจำนวนแทร็กที่สกัดออก. การนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์.

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

แต่ละอ็อบเจกต์ [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) เปิดเผยตัวระบุคำบรรยาย, ป้ายกำกับ, ข้อมูลไบต์, และข้อความคำบรรยายในรูปแบบสตริง UTF-8.

**ลบคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากกรอบวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์. สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นกรอบวิดีโอ.

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

หากต้องการลบเฉพาะแทร็กคำบรรยายหนึ่งแทร็ก ให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) แทน [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **สกัดวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงสไลด์แล้ว Aspose.Slides ยังให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอได้.  
ตัวอย่างนี้สกัดวิดีโอที่ฝังอยู่จากทุกสไลด์เป็นไฟล์ไบนารีที่มีหมายเลขลำดับแยกกัน. วิดีโอที่เชื่อมโยงจะถูกข้ามเพราะไม่มีข้อมูลฝัง. คอนโซลพิมพ์ชนิด MIME ของแต่ละวิดีโอและจำนวนรวม. ผลลัพธ์ใช้ส่วนขยาย `.bin`; คุณสามารถเปลี่ยนให้ตรงกับชนิดสื่อที่รายงานได้เมื่อจำเป็น.

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

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงได้สำหรับกรอบวิดีโอ?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (อัตโนมัติหรือคลิก) และ [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). ตัวเลือกเหล่านี้เผยให้เห็นผ่านคุณสมบัติของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**การเพิ่มวิดีโอทำให้ไฟล์ PPTX มีขนาดใหญ่ขึ้นหรือไม่?**

ใช่. เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบต์จะถูกรวมอยู่ในเอกสาร ดังนั้นขนาดการนำเสนอจะเพิ่มตามขนาดไฟล์. เมื่อเชื่อมโยงวิดีโอออนไลน์และเพิ่มภาพย thumbnail การนำเสนอจะเก็บลิงก์และรูปภาพพรีวิวแทนข้อมูลวิดีโอ ดังนั้นขนาดที่เพิ่มมักจะน้อยกว่า.

**ฉันสามารถเปลี่ยนวิดีโอในกรอบวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้. คุณสามารถสลับ [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) ภายในกรอบโดยคงรูปร่างเดิมไว้; นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่.

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังอยู่ได้หรือไม่?**

ได้. วิดีโอที่ฝังอยู่มี [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) ที่คุณสามารถอ่านและใช้, ตัวอย่างเช่นเมื่อบันทึกลงดิสก์.