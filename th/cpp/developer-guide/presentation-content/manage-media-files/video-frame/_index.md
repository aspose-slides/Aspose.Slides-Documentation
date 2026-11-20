---
title: จัดการกรอบวิดีโอในงานนำเสนอด้วย C++
linktitle: กรอบวิดีโอ
type: docs
weight: 10
url: /th/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและดึงกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างโปรแกรมโดยใช้ Aspose.Slides สำหรับ C++. คู่มือสั้นๆ เร็วๆ"
---
## **บทนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ C++ ให้คุณเพิ่มกรอบวิดีโอบนสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอจาก YouTube

เพื่อเป็นตัวแทนของข้อมูลวิดีโอและกรอบวิดีโอ Aspose.Slides มีอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) , อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างกรอบวิดีโอที่ฝังไว้**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์เก็บไว้ในเครื่อง คุณสามารถสร้างกรอบวิดีโอเพื่อฝังวิดีโอนั้นในงานนำเสนอของคุณได้

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของกรอบจะเป็นหน่วยจุด สตรีมจะเปิดค้างจนกว่าจะบันทึกเสร็จ เนื่องจาก [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) จะล็อกสตรีมไว้ขณะงานนำเสนอใช้มัน

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

คุณยังสามารถส่งพาธวิดีโอในเครื่องโดยตรงไปยัง [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีโอต้องสามารถเข้าถึงได้จนกว่างานนำจะถูกบันทึก

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **สร้างกรอบวิดีโอพร้อมวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างกรอบวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอจาก YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และภาพย่อไปยังสไลด์แรก เปลี่ยนตัวระบุวิดีโอเพื่อใช้วิดีโออื่น วิธี [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) ร้องขอให้เล่นอัตโนมัติ การดาวน์โหลดภาพย่อและการเล่นวิดีโอต้องใช้การเชื่อมต่ออินเทอร์เน็ต ตัวผู้อ่านงานนำเสนอจะต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เล่นวิดีโอในโหมดเต็มหน้าจอ**

ในการนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียดได้ [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) รับค่า `true` เพื่อเปิดใช้พฤติกรรมนี้ระหว่างการเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) แรกบนสไลด์แรกและเปิดใช้งานการเล่นเต็มหน้าจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การเล่นเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ อย่างอิสระ [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) ควบคุมว่าเริ่มอัตโนมัติหรือเมื่อคลิก และ [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) ควบคุมการวนซ้ำ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งค่าโหมดการเล่นเป็น [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) ตัวอย่างนี้คงค่าการเริ่มและการวนซ้ำเดิมไว้

## **ถอยหลังวิดีโอหลังการเล่น**

ในการนำเสนอการฝึกอบรม การนำวิดีโอสาธิตกลับไปที่จุดเริ่มทำให้พร้อมสำหรับผู้บรรยายเล่นใหม่ เรียก [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) ด้วยค่า `true` เพื่อให้วิดีอกลับไปที่จุดเริ่มหลังจากการเล่นจบ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) แรกบนสไลด์แรกและเปิดการถอยหลัง ปิดการวนซ้ำเพื่อให้การเล่นจบและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีกรอบวิดีโออยู่บนสไลด์แรก

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การถอยหลังจะพาวิดีโอกลับไปที่จุดเริ่มโดยไม่เริ่มใหม่ ตรงกันข้าม การเปิด [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) จะทำให้การเล่นวนซ้ำอัตโนมัติ อย่าปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอเล่นจนจบและพร้อมเล่นใหม่ [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) ควบคุมการเริ่มแบบอัตโนมัติหรือด้วยคลิกอย่างอิสระ ตัวอย่างนี้ใช้ [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายควบคุมเวลาเริ่มการเล่น ตั้งโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การถอยหลังทำงานแยกจาก [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/)

## **ตัดกรอบวิดีโอ**

ใช้ [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) และ [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) เพื่อตัดส่วนเริ่มต้นหรือส่วนท้ายของวิดีโอระหว่างการเล่น ทั้งสองค่ามีหน่วยเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังไว้

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายระหว่างการเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้ส่วนที่เล่นได้เหลืออยู่

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**อ่านค่าการตัด**

ตัวอย่างนี้พิมพ์ค่าการตัดของกรอบวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีกรอบวิดีโอจะไม่มีการพิมพ์ ตัวอย่างก่อนหน้าให้ค่าที่ 2500 และ 1000

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายแบบปิดสำหรับกรอบวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจัดเก็บในรูปแบบ WebVTT และเปิดให้เข้าถึงผ่านเมธอด [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/)

### **เพิ่มคำบรรยายให้กับกรอบวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทรกคำบรรยาย WebVTT ที่มีป้ายภาษาอังกฤษ ค่าตำแหน่งเวลาในคำบรรยายควรตรงกับวิดีโอ งานนำเสนอที่บันทึกแล้วจะมีทั้งวิดีโอและคำบรรยายรวมกัน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้ด้วย

### **ดึงคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้บันทึกแทรกคำบรรยายทั้งหมดจากกรอบวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกต่างหาก ตัวเลขต่อเนื่องทำให้ไฟล์ผลลัพธ์ไม่ซ้ำกัน คอนโซลรายงานจำนวนแทรกที่ดึงออก งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

แต่ละวัตถุ [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) เปิดเผยตัวระบุของคำบรรยาย ป้าย ระเบียนไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8

### **ลบคำบรรยายจากกรอบวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากกรอบวิดีโอที่ตำแหน่งรูปร่างแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่ามีสไลด์และรูปทรงนั้นอยู่และรูปทรงเป็นกรอบวิดีโอ

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หากคุณต้องการลบแทรกคำบรรยายเพียงหนึ่งรายการ ให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) แทนการใช้ [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/)

### **ค้นหาคำบรรยายวิดีโอ**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) คืนค่าแทรก WebVTT ทั้งหมดรวมถึงหัวเรื่อง บรรทัดเวลา และข้อความคำบรรยาย เพื่อค้นหาวลีที่พูดและตำแหน่งเวลา ให้อ่านคิวในหน่วยความจำ ตัวอย่างเช่น แทรกภาษาอังกฤษบนสไลด์ที่ 2 อาจมีข้อความดังนี้

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

ตัวอย่างเปิดไฟล์ `captioned_media.pptx` และอ่านแทรกคำบรรยายของกรอบวิดีโอระดับบนแต่ละอันบนทุกสไลด์โดยใช้ [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) ในคิวข้อความธรรมดาบรรทัดเวลาอาจมี `-->` และบรรทัดว่างจะเป็นการจบคิว เมื่อคำบรรยายมีคำว่า “café” ตัวอย่างจะพิมพ์หมายเลขสไลด์ ป้ายแทรก บรรทัดเวลาต้นฉบับ และคำบรรยายทั้งหมด การค้นหาจะไม่สนใจตัวพิมพ์ใหญ่‑เล็ก

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"captioned_media.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        auto videoFrame = AsCast<IVideoFrame>(shape);
        if (!videoFrame)
            continue;

        for (auto&& track : IterateOver(videoFrame->get_CaptionTracks()))
        {
            auto reader = MakeObject<StringReader>(track->get_DataAsString());
            for (auto timing = reader->ReadLine(); !timing.IsNull(); timing = reader->ReadLine())
            {
                if (!timing.Contains(u"-->"))
                    continue;

                String caption;
                for (auto line = reader->ReadLine(); !String::IsNullOrEmpty(line); line = reader->ReadLine())
                {
                    if (!String::IsNullOrEmpty(caption))
                        caption += u"\n";
                    caption += line;
                }

                if (caption.IndexOf(u"caf\u00E9", StringComparison::OrdinalIgnoreCase) >= 0)
                {
                    Console::WriteLine(String::Format(u"Slide {0} | {1} | {2}", slide->get_SlideNumber(), track->get_Label(), timing));
                    Console::WriteLine(caption);
                }
            }
        }
    }
}
presentation->Dispose();
```

การค้นหาคำว่า “café” ให้ผลลัพธ์หนึ่งรายการสำหรับแทรกตัวอย่าง การค้นจะแข skipping ส่วนหัวและคงการตั้งค่าการเวลาไว้ในผลลัพธ์

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **ดึงวิดีโอจากสไลด์**

นอกจากนี้ยังสามารถเพิ่มวิดีโอลงสไลด์ Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอได้

ตัวอย่างนี้ดึงวิดีโอที่ฝังอยู่จากทุกสไลด์ไปเป็นไฟล์ไบนารีที่แยกกันและมีการต่อเลขลำดับ วิดีโอที่ลิงก์จะถูกข้ามเนื่องจากไม่มีข้อมูลที่ฝังอยู่ คอนโซลพิมพ์ชนิด MIME ของแต่ละวิดีโอและจำนวนทั้งหมด ผลลัพธ์ใช้ส่วนขยายทั่วไป `.bin` ; หากต้องการให้ตรงกับประเภทสื่อที่รายงานให้เปลี่ยนส่วนขยายตามนั้น

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดที่สามารถเปลี่ยนแปลงได้สำหรับกรอบวิดีโอ?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านเมธอดของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)

**การเพิ่มวิดีโอส่งผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกบรรจุในเอกสาร ดังนั้นขนาดงานนำเสนอจะเพิ่มตามขนาดไฟล์ เมื่อคุณลิงก์ไปยังวิดีโอออนไลน์และเพิ่มภาพย่อ งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นขนาดที่เพิ่มมักจะน้อยกว่า

**ฉันสามารถแทนที่วิดีโอในกรอบวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) ภายในกรอบได้โดยคงรูปทรงและขนาดไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังอยู่ได้หรือไม่?**

ได้ วิดีโอที่ฝังอยู่มี [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อบันทึกลงดิสก์