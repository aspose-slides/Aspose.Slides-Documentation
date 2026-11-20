---
title: จัดการเฟรมเสียงในงานนำเสนอโดยใช้ C++
linktitle: เฟรมเสียง
type: docs
weight: 10
url: /th/cpp/audio-frame/
keywords:
- เสียง
- เฟรมเสียง
- ภาพย่อ
- เพิ่มเสียง
- คุณสมบัติเสียง
- ตัวเลือกเสียง
- สกัดเสียง
- C++
- Aspose.Slides
description: "ฝังเสียงในสไลด์, เปลี่ยนไอคอนเสียง, ตั้งค่าการเล่น, จัดการคำบรรยาย WebVTT, และสกัดเสียงการเปลี่ยนสไลด์โดยใช้ Aspose.Slides for C++."
---
## **ภาพรวม**

เฟรมเสียงทำให้คุณสามารถเล่นเสียงบนสไลด์ได้ ด้วย Aspose.Slides for C++ คุณสามารถฝังคลิปเสียง เลือกรูปภาพที่เป็นตัวแทนของมัน ปรับการเล่น และแนบคำบรรยาย คุณยังสามารถดึงเสียงที่กำหนดให้กับการเปลี่ยนสไลด์ได้

## **สร้างเฟรมเสียง**

ใช้ [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) เพื่อฝังคลิปเสียงในเครื่องบนสไลด์แรก พิกัดสองค่าที่แรกกำหนดตำแหน่งของเฟรมบนสไลด์และค่าถัดไปอีกสองค่ากำหนดความกว้างและความสูง ทั้งหมดเป็นจุด ตัวอย่างนี้เรียก [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) เพื่อให้คลิปเริ่มเล่นโดยอัตโนมัติและเรียก [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) เพื่อเลือกค่าความดังแบบ preset สูง

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนรูปภาพย่อของเฟรมเสียง**

โดยค่าเริ่มต้นเฟรมเสียงจะแสดงไอคอนลำโพง เพื่อแสดงรูปภาพย่อแบบกำหนดเอง ให้เพิ่มรูปภาพลงในงานนำเสนอด้วย [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) และตั้งเป็นรูปภาพของเฟรมด้วย [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/). ตัวอย่างใช้ไฟล์ JPEG เป็นรูปภาพย่อสำหรับคลิปเสียงที่ฝัง

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนตัวเลือกการเล่นเสียง**

การควบคุม **Audio Options** ของ PowerPoint กำหนดว่าเมื่อไหร่คลิปจะเริ่ม, ความดังของเสียง, และพฤติกรรมของมันระหว่างการแสดงสไลด์

![การควบคุม Audio Options ของ PowerPoint สำหรับเฟรมเสียง](audio_frame_0.png)

| การควบคุม PowerPoint | Aspose.Slides for C++ method |
| --- | --- |
| เริ่ม | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| ค่าล่วงหน้าความดัง | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| เล่นต่อหลายสไลด์ | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| วนซ้ำจนหยุด | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| ซ่อนระหว่างการแสดง | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| ย้อนกลับหลังการเล่น | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| จางเข้า | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| จางออก | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| ตัดเวลาเริ่มต้นของเสียง | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| ตัดเวลาสิ้นสุดของเสียง | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| แถบเลื่อนความดัง | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

ตัวอย่างค้นหาเฟรมเสียงแรกบนสไลด์แรก เรียก [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) เพื่อเริ่มการเล่นเมื่อคลิกและเลือกค่าล่วงหน้าความดังต่ำ คลิปจะเล่นต่อผ่านสไลด์โดยไม่มีการวนซ้ำ ไอคอนจะถูกซ่อนระหว่างการแสดงและคลิปจะย้อนกลับหลังการเล่น

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

สำหรับคลิปที่ยาวกว่า 3.5 วินาที ตัวอย่างนี้จะข้าม 1.5 วินาทีแรกและ 2 วินาทีสุดท้าย อากิวเมนต์ของ [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) ระบุระยะเวลาที่จะตัดออกจากส่วนท้ายของคลิป เพื่อรับเวลาสิ้นสุดที่แสดงใน PowerPoint ให้ลบค่าชดเชยนี้จากระยะเวลาทั้งหมดของคลิป คลิปที่ตัดจะจางเข้าในเวลา 200 มิลลิวินาทีและจางออกในเวลา 500 มิลลิวินาที ตัวตั้งค่าทั้งสี่รับค่าเป็นมิลลิวินาที

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

หากต้องการตั้งค่าความดังของการเล่นเป็นเปอร์เซ็นต์เฉพาะ ให้ใช้ [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/). ตัวอย่างนี้ตั้งค่าความดังของเฟรมเสียงแรกบนสไลด์แรกเป็น 85%

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **จัดการคำบรรยายเสียง**

แต่ละเฟรมเสียงเปิดเผยคอลเลกชันคำบรรยายผ่าน [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/). ใช้เพื่อแนบคำบรรยาย WebVTT ให้กับคลิป ส่งออกแทร็กที่มีอยู่ หรือเอาออก

### **เพิ่มคำบรรยายเสียง**

ตัวอย่างฝังคลิปเสียงบนสไลด์แรกและใช้ [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) เพื่อแนบแทร็ก WebVTT แบบโลคัล อาร์กิวเมนต์แรกให้ป้ายชื่อแทร็ก และอาร์กิวเมนต์ที่สองระบุไฟล์ที่มีคำบรรยายที่กำหนดเวลา

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **ส่งออกคำบรรยายเสียง**

ตัวอย่างนี้ส่งออกแทร็กคำบรรยายแต่ละแทร็กที่แนบกับเฟรมเสียงบนสไลด์แรก เขียนไบต์ที่ได้จาก [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) ไปยังไฟล์ WebVTT และใช้ค่าที่ได้จาก [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) เป็นชื่อไฟล์ เพื่อให้แต่ละแทร็กมีผลลัพธ์แยกกัน

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **ลบคำบรรยายเสียง**

ใช้ [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) เพื่อลบแทร็กเดี่ยว ตัวอย่างนี้ใช้ [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) เพื่อลบคำบรรยายทั้งหมดจากเฟรมเสียงแรกบนสไลด์แรกโดยคงคลิปไว้

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **ค้นบรรทัดในคำบรรยายเสียง**

เพื่อค้นหาบรรทัดในคำบรรยายเสียงบนสไลด์แรก ให้เรียก [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) บนแต่ละแทร็กเพื่ออ่านข้อความ WebVTT ในหน่วยความจำ ในคิว WebVTT แบบข้อความธรรมดา บรรทัดเวลาเป็น `-->`, บรรทัดคำบรรยายตามหลัง และบรรทัดว่างจะสิ้นสุดคิว ตัวอย่างนี้พิมพ์ป้ายชื่อแทร็กและแต่ละบรรทัดคำบรรยายที่มีคำว่า “café”

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **สกัดเสียง**

การเปลี่ยนสไลด์สามารถมีเสียงของตัวเองได้ เพื่อดึงออกให้เรียก [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) บนการเปลี่ยน หากตัวอย่างนี้ดึงไบต์เสียงด้วย [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) และพิมพ์จำนวนไบต์ หากสไลด์แรกไม่มีเสียงการเปลี่ยน จะพิมพ์ข้อความแทน

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้คลิปเสียงเดียวกันบนหลายสไลด์โดยไม่ต้องทำซ้ำได้หรือไม่?**

ใช่. เพิ่มคลิปเพียงครั้งเดียวใน [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) ของงานนำเสนอและส่งออบเจ็กต์เสียงเดียวกันไปยัง [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) สำหรับแต่ละสไลด์

**ฉันสามารถเปลี่ยนเสียงในเฟรมเสียงที่มีอยู่ได้หรือไม่?**

ใช่. สำหรับเสียงที่เชื่อมโยง ให้เรียก [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) พร้อมพาธไปยังไฟล์ที่ต้องการแทนที่. สำหรับเสียงที่ฝัง, ส่งคลิปอื่นจาก audio collection ของงานนำเสนอไปยัง [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/). ทั้งสองวิธีจะคงเฟรมเดิมไว้

**การตัดทำให้ข้อมูลเสียงที่เก็บในงานนำเสนอเปลี่ยนหรือไม่?**

ไม่. [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) และ [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) กำหนดขอบเขตการเล่น คุณยังสามารถดึงคลิปเต็มจาก [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/) ได้