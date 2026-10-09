---
title: จัดการเฟรมวิดีโอในงานนำเสนอด้วย C++
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/cpp/video-frame/
keywords:
- เพิ่มวิดีโอ
- สร้างวิดีโอ
- ฝังวิดีโอ
- ดึงวิดีโอ
- ดึงข้อมูลวิดีโอ
- เฟรมวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและดึงเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมด้วย Aspose.Slides สำหรับ C++ คู่มือวิธีเร็ว."
---
## **คำนำ**

วิดีโอสามารถช่วยอธิบายแนวคิดและดึงดูดผู้ชมได้ Aspose.Slides สำหรับ C++ ให้คุณเพิ่มเฟรมวิดีโอลงในสไลด์ ปรับการตั้งค่าการเล่น จัดการคำบรรยาย และดึงข้อมูลวิดีโอที่ฝังไว้

PowerPoint รองรับวิดีโอในเครื่องและลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอบน YouTube

เพื่อเป็นตัวแทนข้อมูลวิดีโอและเฟรมวิดีโอ Aspose.Slides มีส่วนต่อประสาน [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) และประเภทที่เกี่ยวข้องอื่น ๆ

## **สร้างเฟรมวิดีโอที่ฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มในสไลด์ถูกเก็บไว้ในเครื่อง คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอนั้นในงานนำเสนอของคุณได้

ตัวอย่างนี้ฝังวิดีโอในเครื่องบนสไลด์แรกของงานนำเสนอที่มีอยู่และบันทึกผลลัพธ์ พิกัดและขนาดของเฟรมใช้หน่วยเป็นพ้อยต์ สตรีมจะเปิดอยู่จนกว่าการบันทึกจะเสร็จเนื่องจาก [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) ทำให้มันถูกล็อกในขณะที่งานนำใช้

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

คุณสามารถส่งเส้นทางวิดีโอในเครื่องโดยตรงไปยัง [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) ตัวอย่างนี้ฝังวิดีโอบนสไลด์แรกของงานนำเสนอใหม่ วิดีุต้องสามารถเข้าถึงได้จนกว่างานนำจะถูกบันทึก

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

## **สร้างเฟรมวิดีโอจากแหล่งบนเว็บ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ คุณสามารถสร้างเฟรมวิดีโอที่ลิงก์ไปยังวิดีโอออนไลน์ เช่น วิดีโอบน YouTube

ตัวอย่างนี้เพิ่มลิงก์วิดีโอ YouTube และรูปย่อยไปยังสไลด์แรก แก้ไขตัวระบุวิดีโอเพื่อใช้วิดีโออื่น วิธีการ [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) ขอให้เล่นอัตโนมัติ การดาวน์โหลดรูปย่อยและการเล่นวิดีโอต้องใช้การเชื่อมต่ออินเทอร์เน็ต ตัวชมงานนำเสนอจำเป็นต้องสนับสนุนการเล่นวิดีโอออนไลน์ด้วย

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

ในงานนำเสนอการฝึกอบรม คุณสามารถเล่นการสาธิตซอฟต์แวร์ในโหมดเต็มหน้าจอเพื่อให้ผู้ชมเห็นรายละเอียดได้ [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) รับค่า `true` เพื่อเปิดใช้งานพฤติกรรมนี้ขณะเล่น

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) แรกบนสไลด์แรก และเปิดการเล่นเต็มหน้าจอ งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

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

การเล่นเต็มหน้าจอควบคุมวิธีการแสดงวิดีโอ แยกจากนั้น [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) ควบคุมว่าจะเริ่มอัตโนมัติหรือเมื่อคลิก และ [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) ควบคุมว่าจะแสดงซ้ำหรือไม่ เพื่อเลือกพฤติกรรมการเริ่ม ให้ตั้งโหมดการเล่นเป็น [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) ตัวอย่างนี้คงค่าการเริ่มและการวนซ้ำเดิม

## **ถอยวิดีโอย้อนหลังการเล่น**

ในงานนำเสนอการฝึกอบรม การคืนวิดีโอสาธิตกลับไปที่จุดเริ่มทำให้พร้อมสำหรับผู้บรรยายที่จะเล่นอีกครั้ง ให้เรียก [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) ด้วยค่า `true` เพื่อคืนวิดีโอกลับไปที่จุดเริ่มหลังจากการเล่นเสร็จ

ตัวอย่างนี้เปิดงานนำเสนอ ค้นหา [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) แรกบนสไลด์แรก และเปิดการย้อนกลับ โดยปิดการวนซ้ำเพื่อให้การเล่นจบและตั้งให้เริ่มเมื่อคลิก งานนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์ที่มีเฟรมวิดีโออยู่บนสไลด์แรก

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

การถอยคืนทำให้วิดีโอกลับไปที่จุดเริ่มโดยไม่เริ่มใหม่ ในทางกลับกัน การเปิดใช้งาน [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) จะทำให้การเล่นวนซ้ำอัตโนมัติ ปิดการวนซ้ำเมื่อคุณต้องการให้วิดีโอจบและพร้อมที่จะเล่นใหม่ [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) ควบคุมการเริ่มอัตโนมัติหรือเมื่อคลิกอย่างอิสระ; ตัวอย่างนี้ใช้ [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) เพื่อให้ผู้บรรยายกำหนดเวลาการเริ่มเล่น ตั้งโหมดการเล่นหลังจากตั้งค่าการวนซ้ำตามที่แสดงในตัวอย่าง การถอยคืนทำงานแยกจาก [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/)

## **ตัดเฟรมวิดีโอ**

ใช้ [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) และ [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) เพื่อตัดส่วนเริ่มหรือส่วนท้ายของวิดีโอขณะเล่น ทั้งสองค่าเป็นมิลลิวินาที การตัดเปลี่ยนการตั้งค่าการเล่นโดยไม่แก้ไขข้อมูลวิดีโอที่ฝังไว้

**ตั้งค่าการตัด**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายขณะเล่น ใช้วิดีโอที่ยาวกว่า 3.5 วินาทีเพื่อให้เหลือส่วนที่สามารถเล่นได้

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

ตัวอย่างนี้พิมพ์ค่าการตัดของเฟรมวิดีโอแรกบนสไลด์แรกเป็นมิลลิวินาที งานนำเสนอต้องมีอย่างน้อยหนึ่งสไลด์ หากสไลด์นั้นไม่มีเฟรมวิดีโอ จะไม่มีการพิมพ์ ค่าในตัวอย่างก่อนหน้านี้คือ 2500 และ 1000

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

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และเปิดให้เข้าถึงผ่านเมธอด [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/)

**เพิ่มคำบรรยายลงในเฟรมวิดีโอ**

ตัวอย่างนี้ฝังวิดีโอในเครื่องและเพิ่มแทร็กคำบรรยาย WebVTT ที่มีป้ายเป็น English เวลาตราประทับของคำบรรยายต้องตรงกับวิดีโอ งานนำเสนอที่บันทึกจะมีทั้งวิดีโอและคำบรรยายรวมอยู่

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

ส่วนต่อประสาน [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) ยังมี overload ที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**ดึงคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้บันทึกแทร็กคำบรรยายทั้งหมดจากเฟรมวิดีโอบนสไลด์แรกเป็นไฟล์ WebVTT แยกไฟล์ โดยใช้หมายเลขต่อเนื่องเพื่อแยกไฟล์ผลลัพธ์ คอนโซลจะแสดงจำนวนแทร็กที่ดึงออก งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

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

แต่ละวัตถุ [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) เปิดเผยตัวระบุของคำบรรยาย ป้าย ชุดข้อมูลไบนารี และข้อความคำบรรยายในรูปแบบสตริง UTF-8

**ลบคำบรรยายจากเฟรมวิดีโอ**

ตัวอย่างนี้ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอตำแหน่งรูปทรงแรกบนสไลด์แรกและบันทึกผลลัพธ์ สมมติว่าสไลด์และรูปทรงมีอยู่และรูปทรงเป็นเฟรมวิดีโอ

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

หากต้องการลบแทร็กคำบรรยายเพียงหนึ่งแทร็ก ให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) แทนการใช้ [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/)

## **ดึงวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณดึงวิดีโอที่ฝังอยู่ในงานนำเสนอ

ตัวอย่างนี้ดึงวิดีโอที่ฝังจากทุกสไลด์เป็นไฟล์ไบนารีแยกตามหมายเลข วิดีโอที่ลิงก์จะถูกข้ามเนื่องจากไม่มีข้อมูลฝัง คอนโซลพิมพ์ประเภท MIME ของวิดีโอแต่ละไฟล์และจำนวนรวม ผลลัพธ์ใช้ส่วนขยาย `.bin` ทั่วไป; สามารถเปลี่ยนเป็นส่วนขยายที่ตรงกับประเภทสื่อที่รายงานได้เมื่อจำเป็น

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

**พารามิเตอร์การเล่นวิดีโอใดสามารถเปลี่ยนแปลงได้สำหรับเฟรมวิดีโอ?**

คุณสามารถควบคุม [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (อัตโนมัติหรือเมื่อคลิก) และ [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) ตัวเลือกเหล่านี้มีให้ผ่านเมธอดของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**

ใช่ เมื่อคุณฝังวิดีโอในเครื่อง ข้อมูลไบนารีจะถูกรวมในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ หากคุณลิงก์วิดีโอออนไลน์และเพิ่มรูปย่อย งานนำเสนอจะเก็บลิงก์และภาพตัวอย่างแทนข้อมูลวิดีโอ ดังนั้นขนาดที่เพิ่มมักจะน้อยกว่า

**ฉันสามารถเปลี่ยนวิดีโอในเฟรมวิดีโอที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ใช่ คุณสามารถสลับ [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) ภายในเฟรมโดยคงรูปทรงและขนาดไว้ นี่เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเค้าโครงที่มีอยู่

**สามารถระบุประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**

ได้ วิดีโอที่ฝังไว้มี [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) ที่คุณสามารถอ่านและใช้ได้ ตัวอย่างเช่นเมื่อต้องบันทึกลงดิสก์