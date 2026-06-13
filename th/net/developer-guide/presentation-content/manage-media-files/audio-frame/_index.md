---
title: จัดการเฟรมเสียงในงานนำเสนอใน .NET
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/net/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- รูปย่อ
- เพิ่มเสียง
- คุณสมบัติของเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- .NET
- C#
- Aspose.Slides
description: "สร้างและควบคุมเฟรมเสียงใน Aspose.Slides สำหรับ .NET—ตัวอย่าง C# สำหรับฝัง, ตัด, วนลูป, และกำหนดการเล่นในงานนำเสนอประเภท PPT, PPTX, และ ODP"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเฟรมเสียงใน Aspose.Slides โดยแสดงวิธีเพิ่มเสียงฝังในสไลด์ ปรับรูปย่อของเฟรมเสียง ตั้งค่าตัวเลือกการเล่นเช่น ปริมาณเสียง การวนซ้ำ การซ่อน การตัดและระยะเวลาเฟด และดึงเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ออกมา

## **สร้างเฟรมเสียง**

Aspose.Slides for .NET อนุญาตให้คุณเพิ่มไฟล์เสียงลงในสไลด์ ไฟล์เสียงจะถูกฝังในสไลด์เป็นเฟรมเสียง

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน
3. โหลดสตรีมไฟล์เสียงที่คุณต้องการฝังลงในสไลด์
4. เพิ่มเฟรมเสียงที่ฝัง (ซึ่งบรรจุไฟล์เสียง) ลงในสไลด์
5. ตั้งค่า[PlayMode](https://reference.aspose.com/slides/th/net/aspose.slides/audioplaymodepreset)และ`Volume`ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์[IAudioFrame](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe)
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C# นี้แสดงวิธีเพิ่มเฟรมเสียงที่ฝังลงในสไลด์:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
using (Presentation pres = new Presentation())
{
    // ดึงสไลด์แรก
    ISlide sld = pres.Slides[0];
    
    // โหลดไฟล์เสียง wav ไปยังสตรีม
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // เพิ่ม Audio Frame
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // ตั้งค่า Play Mode และ Volume ของ Audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // เขียนไฟล์ PowerPoint ไปยังดิสก์
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **เปลี่ยนรูปย่อของเฟรมเสียง**

เมื่อคุณเพิ่มไฟล์เสียงลงในงานนำเสนอ เสียงจะแสดงเป็นเฟรมที่มีรูปภาพค่าเริ่มต้นมาตรฐาน (ดูภาพในส่วนต่อไปนี้) คุณสามารถเปลี่ยนรูปย่อของเฟรมเสียง (ตั้งค่าภาพที่คุณต้องการ) ได้

โค้ด C# นี้แสดงวิธีเปลี่ยนรูปย่อหรือรูปภาพตัวอย่างของเฟรมเสียง:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // เพิ่มเฟรมเสียงลงในสไลด์ด้วยตำแหน่งและขนาดที่กำหนด
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // เพิ่มภาพลงในทรัพยากรของงานนำเสนอ
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // ตั้งค่าภาพสำหรับเฟรมเสียง
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
	
	//บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **เปลี่ยนตัวเลือกการเล่นเสียง**

Aspose.Slides for .NET อนุญาตให้คุณปรับตัวเลือกที่ควบคุมการเล่นหรือคุณสมบัติของเสียง ตัวอย่างเช่น คุณสามารถปรับระดับเสียงของเสียง ตั้งค่าให้เสียงเล่นวนซ้ำ หรือแม้แต่ซ่อนไอคอนเสียง

แผง **Audio Options** ใน Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

ตัวเลือก **Audio Options** ของ PowerPoint ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides[AudioFrame](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe) มีดังนี้

- **Start** เมนูแบบดรอปดาวน์ตรงกับคุณสมบัติ[AudioFrame.PlayMode](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/properties/playmode)
- **Volume** ตรงกับคุณสมบัติ[AudioFrame.Volume](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/properties/volume)
- **Play Across Slides** ตรงกับคุณสมบัติ[AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/properties/playacrossslides)
- **Loop until Stopped** ตรงกับคุณสมบัติ[AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/properties/playloopmode)
- **Hide During Show** ตรงกับคุณสมบัติ[AudioFrame.HideAtShowing](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/properties/hideatshowing)
- **Rewind after Playing** ตรงกับคุณสมบัติ[AudioFrame.RewindAudio](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/properties/rewindaudio)

ตัวเลือก **Editing** ของ PowerPoint ที่สอดคล้องกับคุณสมบัติของ Aspose.Slides[AudioFrame](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe) มีดังนี้

- **Fade In** ตรงกับคุณสมบัติ[AudioFrame.FadeInDuration](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/fadeinduration/) 
- **Fade Out** ตรงกับคุณสมบัติ[AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/fadeoutduration/) 
- **Trim Audio Start Time** ตรงกับคุณสมบัติ[AudioFrame.TrimFromStart](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/trimfromstart/) 
- **Trim Audio End Time** มีค่าเท่ากับระยะเวลาของเสียงลบด้วยค่าของคุณสมบัติ[AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/trimfromend/) 

ตัวควบคุม **Volume** บนแถบควบคุมเสียงของ PowerPoint สอดคล้องกับคุณสมบัติ[AudioFrame.VolumeValue](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/volumevalue/) ซึ่งช่วยให้คุณเปลี่ยนระดับเสียงเป็นเปอร์เซ็นต์

วิธีปรับตัวเลือกการเล่นเสียงมีดังนี้

1. [Create](#create-audio-frame) หรือดึงเอา Audio Frame มา
2. ตั้งค่าคุณสมบัติของ Audio Frame ที่ต้องการปรับเป็นค่ใหม่
3. บันทึกไฟล์ PowerPoint ที่แก้ไขแล้ว

โค้ด C# นี้สาธิตการปรับตัวเลือกของเสียง:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // ดึงรูปร่าง AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // ตั้งค่า Play mode ให้เล่นเมื่อคลิก
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // ตั้งค่าปริมาณเสียงเป็น Low
    audioFrame.Volume = AudioVolumeMode.Low;

    // ตั้งค่าให้เสียงเล่นต่อเนื่องข้ามสไลด์
    audioFrame.PlayAcrossSlides = true;

    // ปิดการวนลูปสำหรับเสียง
    audioFrame.PlayLoopMode = false;

    // ซ่อน AudioFrame ระหว่างการนำเสนอ
    audioFrame.HideAtShowing = true;

    // ทำการรีวินด์เสียงกลับไปเริ่มต้นหลังการเล่น
    audioFrame.RewindAudio = true;

    // บันทึกไฟล์ PowerPoint ลงดิสก์
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

ตัวอย่าง C# นี้แสดงวิธีเพิ่มเฟรมเสียงใหม่ที่ฝังเสียง ตัดสั้น และตั้งค่าระยะเวลาเฟด:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // ตั้งค่าออฟเซ็ตการตัดเริ่มต้นเป็น 1.5 วินาที
    audioFrame.TrimFromStart = 1500f;
    // ตั้งค่าออฟเซ็ตการตัดสิ้นสุดเป็น 2 วินาที
    audioFrame.TrimFromEnd = 2000f;

    // ตั้งค่าเวลาการเฟดอินเป็น 200 มิลลิวินาที
    audioFrame.FadeInDuration = 200f;
    // ตั้งค่าเวลาการเฟดเอาท์เป็น 500 มิลลิวินาที
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึง Audio Frame ที่ฝังเสียงและตั้งค่าปริมาณเสียงเป็น 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // ดึงรูปร่าง Audio Frame
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // ตั้งค่าปริมาณเสียงเป็น 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **จัดการคำบรรยายเสียง**

Aspose.Slides อนุญาตให้คุณเพิ่มคำบรรยายปิด (closed captions) ให้กับ Audio Frame ผ่านคุณสมบัติ[CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/iaudioframe/captiontracks/) ซึ่งจะคืนค่าเป็น[ICaptionsCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icaptionscollection/) ให้คุณเพิ่มแทร็กคำบรรยาย WebVTT, วนลูปผ่านแทร็กที่มีอยู่, และลบออกเมื่อจำเป็น

**เพิ่มคำบรรยายเสียง**

ใช้คุณสมบัติ[CaptionTracks](https://reference.aspose.com/slides/th/net/aspose.slides/iaudioframe/captiontracks/) เพื่อแนบแทร็กคำบรรยายหนึ่งหรือหลายแทร็กเข้ากับ Audio Frame ตัวอย่างต่อไปนี้แสดงการเพิ่มไฟล์เสียงลงสไลด์แล้วโหลดแทร็กคำบรรยายใหม่จากไฟล์`.vtt`

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**สกัดคำบรรยายเสียง**

คุณสามารถวนลูปผ่านแทร็กคำบรรยายที่เชื่อมโยงกับ Audio Frame และบันทึกเป็นไฟล์`.vtt` ทุกแทร็กคำบรรยายจะเผยข้อมูลไบนารีและตัวระบุที่ไม่ซ้ำกัน ซึ่งสามารถใช้เมื่อทำการส่งออกคำบรรยาย

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // บันทึกแทร็กคำบรรยายเป็นไฟล์ .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**ลบคำบรรยายเสียง**

เพื่อลบคำบรรยายออกจาก Audio Frame ให้ใช้เมธอดของ[ICaptionsCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icaptionscollection/) เช่น[Clear](https://reference.aspose.com/slides/th/net/aspose.slides/icaptionscollection/clear/),[Remove](https://reference.aspose.com/slides/th/net/aspose.slides/icaptionscollection/remove/),หรือ[RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/icaptionscollection/removeat/) ตัวอย่างต่อไปนี้ลบแทร็กคำบรรยายทั้งหมดจาก Audio Frame

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // ลบแทร็กคำบรรยายทั้งหมดจากเฟรมเสียง.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **สกัดเสียง**

Aspose.Slides for .NET อนุญาตให้คุณสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ ตัวอย่างเช่น คุณสามารถสกัดเสียงที่ใช้ในสไลด์เฉพาะได้

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)และโหลดงานนำเสนอที่มีเสียง
2. ดึงอ้างอิงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เข้าถึงการเปลี่ยนสไลด์โชว์ของสไลด์นั้น
4. สกัดเสียงเป็นข้อมูลไบต์

โค้ด C# นี้แสดงวิธีสกัดเสียงที่ใช้ในสไลด์:

```c#
string presName = "AudioSlide.pptx";

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
Presentation pres = new Presentation(presName);

// เข้าถึงสไลด์
ISlide slide = pres.Slides[0];

// ดึงเอฟเฟกต์การเปลี่ยนสไลด์โชว์สำหรับสไลด์
ISlideShowTransition transition = slide.SlideShowTransition;

//สกัดเสียงเป็นอาร์เรย์ไบต์
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**ฉันสามารถใช้ไฟล์เสียงเดียวกันหลายสไลด์โดยไม่ทำให้ขนาดไฟล์เพิ่มขึ้นได้หรือไม่?**

ได้ เพียงเพิ่มเสียงครั้งเดียวใน[audio collection](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/audios/)ที่ใช้ร่วมกันของงานนำเสนอ แล้วสร้าง Audio Frame เพิ่มเติมที่อ้างอิงไปยังแอสเซทนั้น ซึ่งจะช่วยหลีกเลี่ยงการทำสำเนาข้อมูลสื่อและทำให้ขนาดงานนำเสนอคงที่

**ฉันสามารถเปลี่ยนเสียงใน Audio Frame ที่มีอยู่ได้โดยไม่ต้องสร้างรูปร่างใหม่หรือไม่?**

ได้ สำหรับเสียงที่ลิงก์อยู่ ให้อัปเดต[link path](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/linkpathlong/)ให้ชี้ไปยังไฟล์ใหม่ สำหรับเสียงที่ฝังอยู่ ให้สลับอ็อบเจ็กต์[embedded audio](https://reference.aspose.com/slides/th/net/aspose.slides/audioframe/embeddedaudio/)ด้วยอ็อบเจ็กต์อื่นจาก[audio collection](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/audios/)ของงานนำเสนอ รูปแบบของเฟรมและการตั้งค่าการเล่นส่วนใหญ่จะคงเดิม

**การตัดสั้น (trim) จะทำให้ข้อมูลเสียงพื้นฐานที่เก็บในงานนำเปลี่ยนแปลงหรือไม่?**

ไม่ การตัดสั้นจะปรับเพียงขอบเขตการเล่นเท่านั้น ไบต์เสียงต้นฉบับจะไม่ถูกแก้ไขและยังคงเข้าถึงได้ผ่านเสียงที่ฝังหรือผ่าน[audio collection](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/audios/)ของงานนำเสนอ