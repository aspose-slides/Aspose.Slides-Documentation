---
title: จัดการกรอบวิดีโอในงานนำเสนอด้วย .NET
linktitle: กรอบวิดีโอ
type: docs
weight: 10
url: /th/net/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- ดึงวิดีโอ
- เรียกคืนวิดีโอ
- กรอบวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและดึงกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET อย่างรวดเร็ว"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายความคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ .NET ช่วยให้คุณเพิ่มกรอบวิดีโอบนสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

เพื่อแสดงข้อมูลวิดีโอและกรอบวิดีโอ Aspose.Slides มีอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างกรอบวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มในสไลด์เก็บไว้ในเครื่องคุณสามารถสร้างกรอบวิดีโอเพื่อฝังวิดีโอนั้นในงานนำเสนอของคุณ

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของกรอบเป็นจุด สตรีมจะค้างเปิดจนกว่าการบันทึกจะเสร็จ เพราะ [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) ทำให้ล็อกขณะงานนำเสนอใช้มัน

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

คุณยังสามารถส่งพาธวิดีโอในเครื่องโดยตรงไปยัง [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอต้องสามารถเข้าถึงได้จนกว่างานนำเสนอจะถูกบันทึก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าปริมาณเสียงวิดีโออย่างแม่นยำ**

ใน Aspose.Slides สำหรับ .NET 26.11 หรือรุ่นใหม่กว่า [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) ตั้งค่าร้อยละแบบจำนวนทศนิยมจาก 0 ถึง 100 ใช้เมื่อค่ากำหนด [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) มีความหยาบเกินไป ตัวอย่างเช่น `75.5f` หมายถึงระดับเสียง 75.5%

ตัวอย่างนี้ต้องการ [Aspose.Slides for .NET](/slides/th/net/installation/) รุ่น 26.11 หรือใหม่กว่าและไฟล์ `video.mp4` ในเครื่อง มันฝังวิดีโอ เริ่มต้นการเล่นอย่างชัดเจน บันทึกงานนำเสนอ และอ่านค่าร้อยละที่บันทึกไว้กลับมา

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

ตรวจสอบค่าที่ป้อนด้วยตนเอง; อย่าเชื่อว่าเซตเตอร์จะปฏิเสธค่าที่อยู่นอกช่วงที่ระบุ ค่ากำหนด Low, Medium และ Loud ตรงกับ 20, 50 และ 80 ในรุ่น 26.11 การตั้งค่ากำหนดล่วงหน้าสามารถแทนค่าร้อยละเดิมได้ ดังนั้นให้กำหนดค่าร้อยละเป็นขั้นตอนสุดท้ายเมื่อคุณต้องการค่าที่แน่นอน ใช้ [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) เพื่อปิดเสียงอย่างชัดเจน; ศูนย์เชิงตัวเลขและค่า enum ของกำหนดล่วงหน้าไม่สามารถสลับกันได้

ตั้งค่า [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) อย่างชัดเจนเมื่อกำหนดค่าวิดีโอลิงก์ด้วยและให้ไฟล์สื่อของมันพร้อมสำหรับผู้ชม การบันทึกและเปิดใหม่จะยืนยันการตั้งค่าที่บันทึกไว้; การเล่นและระดับเสียงจริงขึ้นกับผู้เล่นงานนำเสนอและการตั้งค่าเสียงของมัน

## **สร้างกรอบวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างกรอบวิดีโอที่เชื่อมโยงไปยังวิดีโอออนไลน์ เช่น วิดีโอ YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปย่อไปยังสไลด์แรก เปลี่ยนตัวระบุวิดีโอเพื่อใช้วิดีโออื่น การตั้งค่า [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) ขอให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อและการเล่นวิดีโอต้องใช้การเชื่อมต่ออินเทอร์เน็ต ผู้ชมงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย

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

ในการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมมองเห็นรายละเอียด ตั้งค่า [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) เป็น `true` เพื่อเปิดพฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) แรกบนสไลด์แรก และเปิดใช้งานการเล่นแบบเต็มหน้าจอ งานนำเข้าต้องมีสไลด์อย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโอยังอยู่บนสไลด์แรก

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

การเล่นแบบเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ อย่างอิสระ [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) ควบคุมว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และ [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ควบคุมว่าจะทำซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งค่าโหมดการเล่นเป็น [VideoPlayModePreset.Auto หรือ VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). ตัวอย่างนี้รักษาการตั้งค่าเริ่มต้นและการวนรอบเดิมไว้

## **ย้อนวิดีโอกลับหลังการเล่น**

ในการฝึกอบรม การพาวน์วิดีโอสาธิตกลับไปยังจุดเริ่มทำให้พร้อมให้ผู้บรรยายเล่นอีกครั้ง ตั้งค่า [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) เป็น `true` เพื่อให้วิดีโอลบกลับไปยังจุดเริ่มหลังการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) แรกบนสไลด์แรก และเปิดใช้งานการย้อนกลับ ปิดการวนรอบเพื่อให้การเล่นเสร็จสิ้นและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีสไลด์อย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโอยังอยู่บนสไลด์แรก

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

การย้อนกลับจะพาวน์วิดีโอกลับไปยังจุดเริ่มโดยไม่เริ่มใหม่ ในทางตรงข้าม การเปิด [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) จะทำให้การเล่นซ้ำอัตโนมัติ ปิดการวนรอบเมื่อคุณต้องการให้วิดีโอจบและพร้อมเล่นอีกครั้ง [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิกอย่างอิสระ; ตัวอย่างนี้ใช้ [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมเวลาที่เริ่มเล่น ตั้งค่าโหมดการเล่นหลังจากตั้งค่าการวนรอบตามที่แสดงในตัวอย่าง การย้อนกลับทำงานแยกจาก [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/)

## **ตัดกรอบวิดีโอ**

ใช้ [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) และ [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) เพื่อตัดส่วนเริ่มต้นหรือจบของวิดีโอขณะเล่น ค่าทั้งสองเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังอยู่

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายขณะเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้ยังคงมีส่วนที่เล่นได้เหลืออยู่

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

ตัวอย่างนี้พิมพ์ค่าการตัดของกรอบวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีสไลด์อย่างน้อยหนึ่งสไลด์ ถ้าสไลด์นั้นไม่มีกรอบวิดีโอจะไม่พิมพ์ค่า ตัวอย่างก่อนหน้านี้ให้ค่า 2500 และ 1000

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

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับกรอบวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และเปิดให้เข้าถึงผ่านคุณสมบัติ [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/)

### **เพิ่มคำบรรยายให้กรอบวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็คคำบรรยาย WebVTT ชื่อ English เวลาตราประทับของคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกจะมีทั้งวิดีโอและคำบรรยาย

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

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีม

### **ดึงคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้บันทึกแทร็คคำบรรยายทั้งหมดจากกรอบวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกกัน ตัวเลขต่อเนื่องทำให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน คอนโซลรายงานจำนวนแทร็คที่ดึงออก งานนำเสนอจะต้องมีสไลด์อย่างน้อยหนึ่งสไลด์

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

แต่ละอ็อบเจ็กต์ [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) เปิดเผยตัวระบุคำบรรยาย, ป้าย, ข้อมูลไบนารี, และข้อความคำบรรยายในรูปแบบสตริง UTF-8

### **ลบคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากกรอบวิดีโอตำแหน่งรูปทรงแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปทรงอยู่และรูปทรงเป็นกรอบวิดีโอ

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

หากต้องการลบแทร็คคำบรรยายเพียงหนึ่งให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) แทนการใช้ [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/)

### **ค้นหาคำบรรยายวิดีโอ**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) คืนค่าแทร็ค WebVTT ฉบับเต็ม รวมถึงส่วนหัว, บรรทัดเวลา, และข้อความคำบรรยาย เพื่อค้นหาวลีที่พูดและเวลาตรงนั้น ให้อ่านคิวในหน่วยความจำ ตัวอย่างเช่น แทร็ค English บนสไลด์ 2 อาจมีข้อความต่อไปนี้:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

ตัวอย่างนี้เยี่ยมชมแต่ละสไลด์และอ่านแทร็คของกรอบวิดีโอยระดับบนผ่าน [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). ในคิวข้อความธรรมดาบรรทัดเวลาจะมี `-->` และบรรทัดว่างจะสิ้นสุดคิว เมื่อข้อความคำบรรยายมี “café” ตัวอย่างจะพิมพ์หมายเลขสไลด์, ป้ายแทร็ค, บรรทัดเวลาต้นฉบับ, และคำบรรยายเต็ม

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

การค้นหา “café” ให้ผลลัพธ์หนึ่งรายการสำหรับแทร็คตัวอย่าง ส่วนหัวและการตั้งค่าเวลาอยู่นอกข้อความคิว

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอบนสไลด์ Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้ดึงวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบนารีแยกตามลำดับเลข แอลลิงก์วิดีโอจะข้ามเพราะไม่มีข้อมูลฝังอยู่ คอนโซลพิมพ์ชนิด MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; ปรับเปลี่ยนให้ตรงกับประเภทสื่อที่รายงานเมื่อจำเป็น

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

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับกรอบวิดีโอ?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). ตัวเลือกเหล่านี้สามารถใช้ได้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/)

**การเพิ่มวิดีโอตามขนาดไฟล์ PPTX เพิ่มขึ้นหรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มรูปย่อ งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นขนาดที่เพิ่มมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในกรอบวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) ภายในกรอบขณะรักษารูปร่างของ shape ไว้ นี่เป็นกรณีทั่วไปในการอัปเดตสื่อในเค้าโครงที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ใช่ วิดีโอที่ฝังมี [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) ที่คุณสามารถอ่านและใช้ได้ เช่นเมื่อต้องการบันทึกลงดิสก์