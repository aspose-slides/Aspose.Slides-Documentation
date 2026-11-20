---
title: จัดการ Audio Frames ในงานนำเสนอด้วย .NET
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/net/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- รูปย่อ
- เพิ่มเสียง
- คุณสมบัติเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- .NET
- C#
- Aspose.Slides
description: "ฝังเสียงในสไลด์, เปลี่ยนไอคอนเสียง, กำหนดการเล่น, จัดการคำบรรยาย WebVTT, และสกัดเสียงการเปลี่ยนสไลด์ด้วย Aspose.Slides for .NET."
---
## **ภาพรวม**

Audio frame ช่วยให้คุณเล่นเสียงบนสไลด์ได้ ด้วย Aspose.Slides for .NET คุณสามารถฝังคลิปเสียง เลือกรูปภาพที่แสดงถึงคลิป ปรับการเล่น และแนบคำบรรยายได้ คุณยังสามารถดึงเสียงที่กำหนดให้กับการเปลี่ยนสไลด์ได้ด้วย

## **สร้าง Audio Frames**

ใช้ [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) เพื่อฝังคลิปเสียงในเครื่องบนสไลด์แรก พิกัดสองค่าแรกกำหนดตำแหน่งของเฟรมบนสไลด์และสองค่าถัดไปกำหนดความกว้างและความสูงทั้งหมดเป็นหน่วยจุด ตัวอย่างนี้กำหนด [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) ให้เริ่มคลิปโดยอัตโนมัติและ [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) ให้เป็นค่าที่ดัง

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **เปลี่ยน Thumbnail ของ Audio Frame**

โดยค่าเริ่มต้น Audio Frame จะแสดงไอคอนลำโพง เพื่อแสดง Thumbnail ที่กำหนดเอง ให้เพิ่มภาพลงในงานนำเสนอด้วย [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) และกำหนดให้กับ property [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) ของเฟรม ตัวอย่างใช้ไฟล์ JPEG เป็น Thumbnail สำหรับคลิปเสียงที่ฝังไว้

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **เปลี่ยนตัวเลือกการเล่น Audio**

ตัวควบคุม **Audio Options** ของ PowerPoint กำหนดว่าเมื่อใดคลิปจะเริ่ม, ความดังของเสียง, และพฤติกรรมระหว่างการแสดงสไลด์
![ตัวควบคุม Audio Options ของ PowerPoint สำหรับ Audio Frame](audio_frame_0.png)

| การควบคุม PowerPoint | Aspose.Slides property |
| --- | --- |
| เริ่ม | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| ค่าความดังตั้งล่วงหน้า | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| เล่นต่อในหลายสไลด์ | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| วนลูปจนกว่าจะหยุด | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| ซ่อนระหว่างการแสดง | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| รีวินด์หลังเล่น | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| จางเข้า | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| จางออก | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| ตัดเวลาเริ่มต้นของ Audio | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| ตัดเวลา สิ้นสุดของ Audio | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| แถบเลื่อนความดัง | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

ตัวอย่างค้นหา Audio Frame แรกบนสไลด์แรก ตั้งค่า [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) ให้เริ่มการเล่นเมื่อคลิกและเลือกค่าความดังต่ำ คลิปจะดำเนินต่อบนหลายสไลด์โดยปิดการวนลูป ไอคอนจะถูกซ่อนระหว่างการแสดงและคลิปจะรีวินด์หลังการเล่น

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

สำหรับคลิปที่ยาวกว่า 3.5 วินาที ตัวอย่างนี้จะข้าม 1.5 วินาทีแรกและ 2 วินาทีสุดท้าย [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) วัดระยะเวลาที่ต้องตัดออกจากส่วนท้ายของคลิป เพื่อให้ได้เวลาสิ้นสุดที่แสดงใน PowerPoint ให้ลบส่วนชดเชยนั้นจากความยาวเต็มของคลิป คลิปที่ตัดแล้วจะจางเข้าในเวลา 200 มิลลิวินาทีและจางออกในเวลา 500 มิลลิวินาที ทุกคุณสมบัติจำนวนสี่รับค่าหน่วยเป็นมิลลิวินาที

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

เพื่อกำหนดความดังของการเล่นเป็นเปอร์เซ็นต์เฉพาะ ให้ใช้ [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). ตัวอย่างนี้กำหนด Audio Frame แรกบนสไลด์แรกเป็น 85%

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **จัดการคำบรรยาย Audio**

แต่ละ Audio Frame มีคอลเลกชัน [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) ใช้เพื่อแนบคำบรรยาย WebVTT ไปยังคลิป, ส่งออกแทร็กที่มีอยู่, หรือเอาออก

### **เพิ่มคำบรรยาย Audio**

ตัวอย่างฝังคลิปเสียงบนสไลด์แรกและใช้ [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) เพื่อแนบแทร็ก WebVTT ในเครื่อง อาร์กิวเมนต์แรกให้ป้ายชื่อแทร็กและอาร์กิวเมนต์ที่สองระบุไฟล์ที่มีคำบรรยายตามเวลา

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **ดึงคำบรรยาย Audio**

ตัวอย่างนี้ส่งออกแต่ละแทร็กคำบรรยายที่แนบกับ Audio Frame บนสไลด์แรก เขียน [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) ของแทร็กลงในไฟล์ WebVTT และใช้ [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) เป็นชื่อไฟล์เพื่อให้แต่ละแทร็กมีผลผลิตแยกกัน

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **ลบคำบรรยาย Audio**

ใช้ [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) เพื่อลบแทร็กเดี่ยว ตัวอย่างใช้ [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) เพื่อลบคำบรรยายทั้งหมดจาก Audio Frame แรกบนสไลด์แรกโดยคงคลิปไว้

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **ค้นบรรทัดในคำบรรยาย Audio**

เพื่อค้นหาบรรทัดในคำบรรยายเสียงบนสไลด์แรก ให้อ่าน [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) ของแต่ละแทร็กในหน่วยความจำ ใน cue ของ WebVTT แบบข้อความธรรมดา บรรทัดเวลาเก็บ `-->` บรรทัดคำบรรยายตามหลังและบรรทัดว่างจบ cue ตัวอย่างนี้พิมพ์ป้ายแทร็กและแต่ละบรรทัดคำบรรยายที่มีคำว่า “café”

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **ดึง Audio**

การเปลี่ยนสไลด์อาจมีเสียงของตนเอง เพื่อดึงออกมาให้อ่าน property [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) ของการเปลี่ยนสไลด์ ตัวอย่างเข้าถึง [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) ของเสียงและพิมพ์ขนาดเป็นไบต์ หากสไลด์แรกไม่มีเสียงการเปลี่ยน จะพิมพ์ข้อความแทน

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้คลิปเสียงเดียวกันในหลายสไลด์โดยไม่ต้องทำซ้ำได้หรือไม่?**

ทำได้. เพิ่มคลิปเพียงครั้งเดียวใน [คอลเลกชัน audio](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) ของงานนำเสนอและส่งออบเจ็กต์เสียงเดียวกันไปยัง [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) สำหรับแต่ละสไลด์

**ฉันสามารถแทนที่เสียงใน Audio Frame ที่มีอยู่ได้หรือไม่?**

ทำได้. สำหรับเสียงที่เชื่อมโยง ให้อัปเดต [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) ให้ชี้ไปยังไฟล์ทดแทน สำหรับเสียงที่ฝังไว้ ให้กำหนดคลิปอื่นจากคอลเลกชัน audio ของงานนำเสนอไปยัง [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). ทั้งสองวิธีจะรักษาเฟรมเดิมไว้

**การตัดช่วงทำให้ข้อมูลเสียงที่เก็บในงานนำเสนอเปลี่ยนหรือไม่?**

ไม่. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) และ [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) กำหนดขอบเขตการเล่น คุณยังสามารถดึงคลิปเต็มจาก [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) ได้