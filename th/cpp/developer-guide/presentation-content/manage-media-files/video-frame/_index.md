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
- สกัดวิดีโอ
- ดึงวิดีโอ
- กรอบวิดีโอ
- แหล่งเว็บ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและสกัดกรอบวิดีโอในสไลด์ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมด้วย Aspose.Slides สำหรับ C++. คำแนะนำสั้น ๆ อย่างรวดเร็ว."
---
## **บทนำ**

วิดีโอที่วางไว้อย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมของผู้ชมได้  

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอท้องถิ่น (เก็บไว้บนเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วัตถุวิดีโอ) ลงในงานนำเสนอ Aspose.Slides มีให้บริการอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideo/) อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) และชนิดที่เกี่ยวข้องอื่น ๆ

## **สร้างกรอบวิดีโอแบบฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มในสไลด์ของคุณถูกเก็บไว้ในเครื่อง คุณสามารถสร้างกรอบวิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่มวัตถุ [IVideo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideo/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอกับงานนำเสนอ  
1. เพิ่มวัตถุ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) เพื่อสร้างกรอบสำหรับวิดีโอ  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ นี้แสดงวิธีเพิ่มวิดีโอที่เก็บไว้ในเครื่องลงในงานนำเสนอ:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

อีกทางหนึ่ง คุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [AddVideoFrame()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **สร้างกรอบวิดีโอด้วยวิดีโอจากแหล่งเว็บ**

เวอร์ชันใหม่ของ Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) รองรับวิดีโอออนไลน์ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้พร้อมใช้งานบนเว็บ (เช่น YouTube) คุณสามารถเพิ่มลงในงานนำเสนอผ่านลิงก์เว็บของมันได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่มวัตถุ [IVideo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideo/) และส่งลิงก์ไปยังวิดีโอ  
1. ตั้งค่า thumbnail สำหรับกรอบวิดีโอ  
1. บันทึกงานนำเสนอ  

โค้ด C++ นี้แสดงวิธีเพิ่มวิดีโอจากเว็บไปยังสไลด์ในงานนำเสนอ PowerPoint:

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// เพิ่มกรอบวิดีโอ 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// ตั้งค่าโหมดการเล่นและระดับเสียงของวิดีโอ
vf->set_PlayMode(VideoPlayModePreset::Auto);

//บันทึกงานนำเสนอลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ตัดกรอบวิดีโอ**

Aspose.Slides อนุญาตให้คุณควบคุมส่วนของวิดีโอที่เล่นโดยการตั้งค่า trim-from-start และ trim-from-end ผ่าน [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/set_trimfromstart/) และ [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/set_trimfromend/) ค่าทั้งสองระบุเป็นมิลลิวินาทีและกำหนดช่วงเวลาที่ข้ามจากจุดเริ่มต้นและจุดสิ้นสุดของวิดีโอตามลำดับ การตั้งค่าเหล่านี้เปลี่ยนการตั้งค่าการเล่นวิดีโอในงานนำเสนอ; พวกมันไม่ได้ตัดหรือแก้ไขข้อมูลไบนารีของวิดีโอที่ฝังไว้

**ตั้งค่าการตัด**

เพื่อสร้างกรอบวิดีโอและตั้งค่าการตัดของมัน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. เพิ่มวัตถุ [IVideo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideo/) ลงในงานนำเสนอ  
1. เพิ่มวัตถุ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) ลงในสไลด์  
1. ตั้งค่า trim-from-start และ trim-from-end ผ่าน [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/set_trimfromstart/) และ [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/set_trimfromend/)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างโค้ดต่อไปนี้จะข้าม 2.5 วินาทีแรกและ 1 วินาทีสุดท้ายของวิดีโอที่ฝังไว้ขณะเล่น:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**อ่านการตั้งค่าการตัด**

เพื่อดูการตั้งค่าการตัดที่มีอยู่ ให้โหลดงานนำเสนอ ค้นหาอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) ในรูปทรงบนสไลด์แรก และอ่านค่าผ่าน [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_trimfromstart/) และ [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_trimfromend/)  

ตัวอย่างโค้ดต่อไปนี้ค้นหากรอบวิดีโอแรกบนสไลด์แรกและรายงานการตั้งค่าการตัดของมันเป็นมิลลิวินาที:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides อนุญาตให้คุณจัดการคำบรรยายปิดสำหรับกรอบวิดีโอในงานนำเสนอ PowerPoint คำบรรยายถูกเก็บในรูปแบบ WebVTT และเข้าถึงได้ผ่านเมธอด [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_captiontracks/)

**เพิ่มคำบรรยายให้กับกรอบวิดีโอ**

เพื่อเพิ่มคำบรรยายให้กับกรอบวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. เพิ่มวิดีโอลงในงานนำเสนอ  
1. เพิ่มวัตถุ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) ลงในสไลด์  
1. ใช้ [ICaptionsCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/) ที่ได้จาก [get_CaptionTracks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_captiontracks/) เพื่อเพิ่ม WebVTT caption track  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดต่อไปนี้แสดงวิธีเพิ่มคำบรรยายให้กับกรอบวิดีโอ:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// เพิ่มแทร็กคำบรรยายใหม่จากไฟล์ WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/) ยังมีโอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้

**สกัดคำบรรยายจากกรอบวิดีโอ**

เพื่อสกัดคำบรรยายจากกรอบวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ  
1. ค้นหาอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) ที่ต้องการ  
1. วนลูปผ่าน caption tracks ที่คืนจาก [get_CaptionTracks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_captiontracks/)  
1. บันทึกแต่ละ caption track ลงไฟล์ `.vtt`  

โค้ดต่อไปนี้แสดงวิธีสกัดคำบรรยายจากกรอบวิดีโอ:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // บันทึกแทร็กคำบรรยายเป็นไฟล์ WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

แต่ละอ็อบเจกต์ [ICaptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptions/) จะเผยให้เห็นตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี, และข้อมูลคำบรรยายเป็นสตริง UTF-8  

**ลบคำบรรยายจากกรอบวิดีโอ**

เพื่อทำการลบคำบรรยายจากกรอบวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ  
1. รับอ็อบเจกต์ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) ที่ต้องการ  
1. ลบ caption tracks จากคอลเลกชันที่คืนจาก [get_CaptionTracks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_captiontracks/)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจากกรอบวิดีโอ:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// ลบคำบรรยายทั้งหมดจากกรอบวิดีโอ.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หากคุณต้องการลบเพียงหนึ่ง caption track ให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/removeat/) แทน [Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/clear/)  

## **สกัดวิดีโอจากสไลด์**

นอกเหนือจากการเพิ่มวิดีโอในสไลด์แล้ว Aspose.Slides ยังอนุญาตให้คุณสกัดวิดีโอที่ฝังอยู่ในงานนำเสนอ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เพื่อโหลดงานนำเสนอที่มีวิดีโอ  
2. วนลูปผ่านอ็อบเจกต์ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) ทั้งหมด  
3. วนลูปผ่านอ็อบเจกต์ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/)  
4. บันทึกวิดีโอลงดิสก์  

โค้ด C++ นี้แสดงวิธีสกัดวิดีโอจากสไลด์ของงานนำเสนอ:

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **คำถามที่พบบ่อย**

**พารามิเตอร์การเล่นวิดีโอใดบ้างที่สามารถเปลี่ยนแปลงได้สำหรับ VideoFrame?**  
คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/set_playmode/) (อัตโนมัติหรือคลิก) และ [การวนซ้ำ](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/set_playloopmode/) ตัวเลือกเหล่านี้สามารถเข้าถึงได้ผ่านคุณสมบัติของอ็อบเจกต์ [VideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/)  

**การเพิ่มวิดีโอมีผลต่อขนาดไฟล์ PPTX หรือไม่?**  
ใช่ เมื่อคุณฝังวิดีโอท้องถิ่น ข้อมูลไบนารีจะถูกรวมในเอกสาร ทำให้ขนาดงานนำเสนอเพิ่มตามขนาดไฟล์ เมื่อคุณเพิ่มวิดีโอออนไลน์ จะฝังลิงก์และ thumbnail เท่านั้น ทำให้การเพิ่มขนาดน้อยลง  

**ฉันสามารถแทนที่วิดีโอใน VideoFrame ที่มีอยู่โดยไม่เปลี่ยนตำแหน่งและขนาดได้หรือไม่?**  
ได้ คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/set_embeddedvideo/) ภายในกรอบโดยคงรูปทรงของ shape ไว้ นี่เป็นกรณีทั่วไปสำหรับการอัปเดตสื่อในเลเอาท์ที่มีอยู่  

**สามารถกำหนดประเภทเนื้อหา (MIME) ของวิดีโอที่ฝังไว้ได้หรือไม่?**  
ได้ วิดีโอที่ฝังไว้มี [content type](https://reference.aspose.com/slides/th/cpp/aspose.slides/video/get_contenttype/) ซึ่งคุณสามารถอ่านและใช้ได้ เช่น เมื่อบันทึกลงดิสก์