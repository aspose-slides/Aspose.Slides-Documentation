---
title: จัดการ Audio ในการนำเสนอด้วย C++
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/cpp/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- ภาพย่อ
- เพิ่มเสียง
- คุณสมบัติของเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- C++
- Aspose.Slides
description: "สร้างและควบคุมเฟรมเสียงใน Aspose.Slides สำหรับ C++—ตัวอย่างโค้ดสำหรับฝัง, ตัดต่อ, วนลูป, และกำหนดการเล่นในรูปแบบการนำเสนอ PPT, PPTX, และ ODP"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับ Audio Frames ใน Aspose.Slides รวมถึงการเพิ่ม Audio ฝังในสไลด์ การปรับแต่ง Thumbnail ของ Audio Frame การกำหนดค่าการเล่นเช่น ระดับเสียง การวนลูป การซ่อน การตัดต่อ และระยะเวลา Fade รวมถึงการสกัด Audio ที่ใช้ในการเปลี่ยนสไลด์โชว์

## **สร้าง Audio Frames**

Aspose.Slides for C++ ให้คุณเพิ่มไฟล์เสียงลงในสไลด์ ไฟล์เสียงจะถูกฝังในสไลด์เป็น Audio Frames

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) class
2. รับอ้างอิงของสไลด์ผ่านดัชนี
3. โหลดสตรีมไฟล์เสียงที่ต้องการฝังลงในสไลด์
4. เพิ่ม Audio Frame ที่ฝังไฟล์เสียงลงในสไลด์
5. ตั้งค่า [PlayMode](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) และ `Volume` ที่เปิดเผยโดยอ็อบเจกต์ [IAudioFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_audio_frame)
6. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด C++ ตัวอย่างนี้แสดงวิธีการเพิ่ม Audio Frame ฝังในสไลด์:

``` cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์การนำเสนอ
auto pres = System::MakeObject<Presentation>();

// ดึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// โหลดไฟล์เสียง wav ไปเป็นสตรีม
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// เพิ่ม Audio Frame
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// ตั้งค่าโหมดการเล่นและระดับเสียงของ Audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// เขียนไฟล์ PowerPoint ลงดิสก์
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนภาพย่อของ Audio Frame**

เมื่อคุณเพิ่มไฟล์เสียงลงในการนำเสนอ เสียงจะปรากฏเป็นเฟรมพร้อมภาพเริ่มต้นมาตรฐาน (ดูรูปด้านล่าง) คุณสามารถเปลี่ยนภาพย่อของ Audio Frame (ตั้งค่าภาพที่คุณต้องการ)

โค้ด C++ ตัวอย่างนี้แสดงวิธีการเปลี่ยนภาพย่อหรือภาพพรีวิวของ Audio Frame:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// เพิ่ม Audio Frame ลงในสไลด์ด้วยตำแหน่งและขนาดที่กำหนด.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// เพิ่มรูปภาพลงในทรัพยากรของการนำเสนอ.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// ตั้งค่ารูปภาพสำหรับ Audio Frame. // <-----
        
// บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **เปลี่ยนตัวเลือกการเล่นเสียง**

Aspose.Slides for C++ ให้คุณเปลี่ยนตัวเลือกที่ควบคุมการเล่นหรือคุณสมบัติของเสียง เช่น ปรับระดับเสียง ตั้งค่าให้เสียงเล่นแบบวนลูป หรือซ่อนไอคอนเสียง

แผง **ตัวเลือกเสียง** ใน Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **ตัวเลือกเสียง** ที่สอดคล้องกับเมธอดของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/) :

- **เริ่มต้น** ตรงกับเมธอด [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_playmode/)
- **ระดับเสียง** ตรงกับเมธอด [AudioFrame::set_Volume](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_volume/)
- **เล่นข้ามสไลด์** ตรงกับเมธอด [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_playacrossslides/)
- **วนซ้ำจนกว่าจะหยุด** ตรงกับเมธอด [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_playloopmode/)
- **ซ่อนระหว่างการแสดง** ตรงกับเมธอด [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_hideatshowing/)
- **ย้อนกลับหลังจากเล่น** ตรงกับเมธอด [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_rewindaudio/)

ตัวเลือก **การแก้ไข** ของ PowerPoint ที่สอดคล้องกับคุณลักษณะของ Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/) :

- **ค่อย ๆ เพิ่ม** ตรงกับเมธอด [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_fadeinduration/)
- **ค่อย ๆ ลด** ตรงกับเมธอด [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_fadeoutduration/)
- **ตัดเวลาเริ่มต้นของเสียง** ตรงกับเมธอด [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_trimfromstart/)
- **ตัดเวลาสิ้นสุดของเสียง** ค่าเท่ากับความยาวเสียงลบด้วยค่าที่ตั้งไว้ในเมธอด [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_trimfromend/)

ตัวควบคุม **ระดับเสียง** ของ PowerPoint บนแผงควบคุมเสียงสอดคล้องกับเมธอด [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/audioframe/set_volumevalue/) ซึ่งให้คุณปรับระดับเสียงเป็นเปอร์เซ็นต์

นี่คือตัวอย่างการเปลี่ยนตัวเลือกการเล่นเสียง:

1. [สร้าง](#creating-audio-frame) หรือรับ Audio Frame
2. ตั้งค่าค่าใหม่สำหรับคุณสมบัติของ Audio Frame ที่ต้องการปรับ
3. บันทึกไฟล์ PowerPoint ที่แก้ไขแล้ว

โค้ด C++ ตัวอย่างนี้แสดงการปรับตัวเลือกของ Audio:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// รับรูปทรง
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// แปลงรูปทรงเป็นรูปทรง AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// ตั้งค่าโหมดการเล่นให้เล่นเมื่อคลิก
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// ตั้งค่าระดับเสียงเป็น Low
audioFrame->set_Volume(AudioVolumeMode::Low);

// ตั้งค่าให้เสียงเล่นข้ามสไลด์
audioFrame->set_PlayAcrossSlides(true);

// ปิดการวนลูปสำหรับเสียง
audioFrame->set_PlayLoopMode(false);

// ซ่อน AudioFrame ระหว่างการแสดงสไลด์
audioFrame->set_HideAtShowing(true);

// รีวินด์เสียงให้เริ่มต้นใหม่หลังการเล่น
audioFrame->set_RewindAudio(true);

// บันทึกไฟล์ PowerPoint ลงดิสก์
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

ตัวอย่าง C++ นี้แสดงวิธีเพิ่ม Audio Frame ใหม่พร้อม Audio ฝัง ตัดต่อ และตั้งค่าระยะเวลา Fade:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีดึง Audio Frame ที่ฝัง Audio และตั้งค่าระดับเสียงเป็น 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// ดึงรูปทรง Audio Frame
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// ตั้งค่าระดับเสียงของ Audio เป็น 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **จัดการคำบรรยายเสียง**

Aspose.Slides ให้คุณเพิ่ม Closed Captions ให้กับ Audio Frame ผ่านเมธอด [get_CaptionTracks] วิธีนี้จะคืนค่า [ICaptionsCollection] ซึ่งช่วยให้คุณเพิ่ม WebVTT Caption Tracks, วนลูปผ่านแทร็กที่มีอยู่, และลบออกเมื่อจำเป็น

**เพิ่มคำบรรยายเสียง**

ใช้เมธอด [get_CaptionTracks] เพื่อผนวกแทร็กคำบรรยายหนึ่งหรือหลายแทร็กเข้ากับ Audio Frame ในตัวอย่างต่อไปนี้ไฟล์เสียงจะถูกเพิ่มลงในสไลด์ จากนั้นโหลดแทร็กคำบรรยายใหม่จากไฟล์ `.vtt`

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**ดึงคำบรรยายเสียง**

คุณสามารถวนลูปผ่านแทร็กคำบรรยายที่เชื่อมโยงกับ Audio Frame และบันทึกเป็นไฟล์ `.vtt` แต่ละแทร็กจะแสดงข้อมูลไบนารีและตัวระบุที่ไม่ซ้ำกัน ซึ่งสามารถนำไปใช้เมื่อส่งออกคำบรรยาย

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ .vtt
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**ลบคำบรรยายเสียง**

เพื่อที่จะลบคำบรรยายจาก Audio Frame ให้ใช้เมธอดที่มาจาก [ICaptionsCollection] เช่น [Clear], [Remove] หรือ [RemoveAt] ตัวอย่างต่อไปนี้ลบแทร็กคำบรรยายทั้งหมดจาก Audio Frame

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// ลบแทร็กคำบรรยายทั้งหมดจาก Audio Frame.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ดึงเสียง**

Aspose.Slides ให้คุณสกัดเสียงที่ใช้ในการเปลี่ยนสไลด์โชว์ ตัวอย่างเช่น คุณสามารถสกัดเสียงที่ใช้ในสไลด์เฉพาะได้

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) แล้วโหลดการนำเสนอที่มี Audio
2. รับอ้างอิงของสไลด์ที่ต้องการผ่านดัชนี
3. เข้าถึงการเปลี่ยนสไลด์สำหรับสไลด์นั้น
4. สกัดเสียงเป็นข้อมูลไบต์

โค้ด C++ ตัวอย่างนี้แสดงวิธีสกัด Audio ที่ใช้ในสไลด์:

``` cpp
String presName = u"AudioSlide.pptx";

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์การนำเสนอ
auto pres = System::MakeObject<Presentation>(presName);

// Accesses the desired slide
auto slide = pres->get_Slides()->idx_get(0);

// Gets the slideshow transition effects for the slide
auto transition = slide->get_SlideShowTransition();

// Extracts the sound in byte array
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ไฟล์ Audio เดียวกันในหลายสไลด์โดยไม่ทำให้ขนาดไฟล์เพิ่มขึ้นได้หรือไม่?**

ได้ครับ เพิ่ม Audio ครั้งเดียวใน [audio collection] ร่วมของการนำเสนอ แล้วสร้าง Audio Frame เพิ่มเติมที่อ้างอิงถึง Asset นั้น วิธีนี้ช่วยหลีกเลี่ยงการซ้ำซ้อนของข้อมูลมีเดียและทำให้ขนาดไฟล์อยู่ในระดับที่ควบคุมได้

**ฉันสามารถเปลี่ยนเสียงใน Audio Frame ที่มีอยู่โดยไม่ต้องสร้าง Shape ใหม่ได้หรือไม่?**

ได้ครับ สำหรับเสียงที่เป็นลิงก์ ให้อัปเดต [link path] ให้ชี้ไปยังไฟล์ใหม่ สำหรับเสียงที่ฝัง ให้สลับอ็อบเจกต์ [embedded audio] ด้วยออบเจกต์อื่นจาก [audio collection] ของการนำเสนอ การจัดรูปแบบของเฟรมและการตั้งค่าการเล่นส่วนใหญ่จะคงเดิม

**การตัดต่อจะทำให้ข้อมูล Audio ดิบที่เก็บในการนำเสนอเปลี่ยนแปลงหรือไม่?**

ไม่ครับ การตัดแค่ปรับขอบเขตการเล่นเท่านั้น ไบต์ของ Audio ดั้งเดิมยังคงอยู่และสามารถเข้าถึงได้ผ่าน Audio ฝังหรือ [audio collection] ของการนำเสนอ