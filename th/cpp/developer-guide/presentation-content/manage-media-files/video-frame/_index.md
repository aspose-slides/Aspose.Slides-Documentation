---
title: จัดการ Video Frames ในงานนำเสนอโดยใช้ C++
linktitle: เฟรมวิดีโอ
type: docs
weight: 10
url: /th/cpp/video-frame/
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
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและสกัดเฟรมวิดีโอในสไลด์ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ C++ อย่างรวดเร็วและเป็นขั้นตอน"
---
## **บทนำ**

วิดีโอที่วางอย่างเหมาะสมในงานนำเสนอสามารถทำให้ข้อความของคุณน่าสนใจยิ่งขึ้นและเพิ่มระดับการมีส่วนร่วมกับผู้ชมของคุณ.

PowerPoint อนุญาตให้คุณเพิ่มวิดีโอลงในสไลด์ของงานนำเสนอได้สองวิธี:

* เพิ่มหรือฝังวิดีโอท้องถิ่น (เก็บไว้ในเครื่องของคุณ)
* เพิ่มวิดีโอออนไลน์ (จากแหล่งเว็บเช่น YouTube).

เพื่อให้คุณสามารถเพิ่มวิดีโอ (วิดีโอออบเจ็กต์) ลงในงานนำเสนอได้, Aspose.Slides ให้บริการอินเทอร์เฟซ [IVideo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideo/) , อินเทอร์เฟซ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) , และประเภทที่เกี่ยวข้องอื่นๆ.

## **สร้างเฟรมวิดีโอฝัง**

หากไฟล์วิดีโอที่คุณต้องการเพิ่มลงในสไลด์ของคุณถูกเก็บไว้ในเครื่อง, คุณสามารถสร้างเฟรมวิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอของคุณ.

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
1. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideo/) และส่งพาธไฟล์วิดีโอเพื่อฝังวิดีโอลงในงานนำเสนอ. 
1. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) เพื่อสร้างเฟรมสำหรับวิดีโอ.  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ด C++ นี้แสดงวิธีเพิ่มวิดีโอที่เก็บไว้ในเครื่องลงในงานนำเสนอ:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// โหลดวิดีโอ
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// ดึงสไลด์แรกและเพิ่มเฟรมวิดีโอ
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// บันทึกงานนำเสนอลงดิสก์
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

ทางเลือกอื่น, คุณสามารถเพิ่มวิดีโอโดยส่งพาธไฟล์โดยตรงไปยังเมธอด [AddVideoFrame()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **สร้าง Video Frame ด้วยวิดีโอจากแหล่งเว็บ**

Microsoft [PowerPoint 2013 และใหม่กว่า](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) รองรับวิดีโอ YouTube ในงานนำเสนอ หากวิดีโอที่คุณต้องการใช้มีอยู่บนออนไลน์ (เช่น บน YouTube) คุณสามารถเพิ่มมันลงในงานนำเสนอผ่านลิงก์เว็บของมัน.

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
1. เพิ่มอ็อบเจ็กต์ [IVideo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideo/) และส่งลิงก์ไปยังวิดีโอ. 
1. ตั้งค่าทัมบ์เนลสำหรับเฟรมวิดีโอ. 
1. บันทึกงานนำเสนอ. 

โค้ด C++ นี้แสดงวิธีเพิ่มวิดีโอจากเว็บลงในสไลด์ของงานนำเสนอ PowerPoint:

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// สร้างอ็อบเจ็กต์ Presentation ที่แสดงไฟล์งานนำเสนอ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// เพิ่ม Video Frame 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// ตั้งค่าโหมดการเล่นและระดับเสียงของวิดีโอ
vf->set_PlayMode(VideoPlayModePreset::Auto);

//บันทึกงานนำเสนอลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **จัดการคำบรรยายวิดีโอ**

Aspose.Slides ให้คุณจัดการคำบรรยายปิดสำหรับเฟรมวิดีโอในงานนำเสนอ PowerPoint คำบรรยายจะถูกเก็บในรูปแบบ WebVTT และสามารถเข้าถึงได้ผ่านเมธอด [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**เพิ่มคำบรรยายให้กับ Video Frame**

เพื่อเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/). 
2. เพิ่มวิดีโอลงในงานนำเสนอ. 
3. เพิ่มอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) ลงในสไลด์. 
4. ใช้ [ICaptionsCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/) ที่ได้จาก [get_CaptionTracks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_captiontracks/) เพื่อเพิ่มแทร็กคำบรรยาย WebVTT. 
5. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ดต่อไปนี้แสดงวิธีเพิ่มคำบรรยายให้กับเฟรมวิดีโอ:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

อินเทอร์เฟซ [ICaptionsCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/) ยังให้โอเวอร์โหลดที่ให้คุณเพิ่มคำบรรยายจากสตรีมได้.

**สกัดคำบรรยายจาก Video Frame**

เพื่อสกัดคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ. 
2. ค้นหาอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) เป้าหมาย. 
3. ทำการวนซ้ำผ่านแทร็กคำบรรยายที่ได้จาก [get_CaptionTracks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_captiontracks/). 
4. บันทึกแต่ละแทร็กคำบรรยายเป็นไฟล์ `.vtt`. 

โค้ดต่อไปนี้แสดงวิธีสกัดคำบรรยายจากเฟรมวิดีโอ:

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

แต่ละอ็อบเจ็กต์ [ICaptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptions/) จะเปิดเผยตัวระบุคำบรรยาย, ป้ายชื่อ, ข้อมูลไบนารี, และข้อมูลคำบรรยายในรูปแบบสตริง UTF-8.

**ลบคำบรรยายจาก Video Frame**

เพื่อทำการลบคำบรรยายจากเฟรมวิดีโอ:

1. โหลดงานนำเสนอที่มีวิดีโอ. 
2. รับอ็อบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) เป้าหมาย. 
3. ลบแทร็กคำบรรยายจากคอลเลกชันที่ได้จาก [get_CaptionTracks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/get_captiontracks/). 
4. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ดต่อไปนี้แสดงวิธีลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// ลบคำบรรยายทั้งหมดจากเฟรมวิดีโอ.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หากคุณต้องการลบเฉพาะแทร็กคำบรรยายหนึ่งแทร็ก, ให้ใช้เมธอด [Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/remove/) หรือ [RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/removeat/) แทน [Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/icaptionscollection/clear/).

## **สกัดวิดีโอจากสไลด์**

นอกจากการเพิ่มวิดีโอลงในสไลด์แล้ว, Aspose.Slides ยังให้คุณสกัดวิดีโอที่ฝังในงานนำเสนอได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เพื่อโหลดงานนำเสนอที่มีวิดีโอ. 
2. วนซ้ำผ่านอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) ทั้งหมด. 
3. วนซ้ำผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ทั้งหมดเพื่อค้นหา [VideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/). 
4. บันทึกวิดีโอลงดิสก์. 

โค้ด C++ นี้แสดงวิธีสกัดวิดีโอบนสไลด์ของงานนำเสนอ:

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

คุณสามารถควบคุม [โหมดการเล่น](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/set_playmode/) (อัตโนมัติหรือคลิก) และ [การวนซ้ำ](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/set_playloopmode/). ตัวเลือกเหล่านี้มีให้ผ่านคุณสมบัติของอ็อบเจ็กต์ [VideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/).

**การเพิ่มวิดีโอทำให้ไฟล์ PPTX มีขนาดเพิ่มขึ้นหรือไม่?**

ใช่. เมื่อคุณฝังวิดีโอท้องถิ่น, ข้อมูลไบนารีจะถูกใส่ในเอกสาร, ดังนั้นขนาดของงานนำเสนอจะเพิ่มขึ้นตามขนาดไฟล์. เมื่อคุณเพิ่มวิดีโอออนไลน์, ลิงก์และรูปภาพย่อจะถูกฝัง, ทำให้การเพิ่มขนาดน้อยลง.

**ฉันสามารถเปลี่ยนวิดีโอใน VideoFrame ที่มีอยู่โดยไม่ต้องเปลี่ยนตำแหน่งและขนาดได้หรือไม่?**

ได้. คุณสามารถสลับ [เนื้อหาวิดีโอ](https://reference.aspose.com/slides/th/cpp/aspose.slides/videoframe/set_embeddedvideo/) ภายในเฟรมโดยยังคงรักษาเรขาคณิตของรูปร่างไว้; นี้เป็นสถานการณ์ทั่วไปสำหรับการอัปเดตสื่อในเลย์เอาต์ที่มีอยู่.

**สามารถระบุชนิดของเนื้อหา (MIME) ของวิดีโอที่ฝังได้หรือไม่?**

ได้. วิดีโอที่ฝังมี [content type](https://reference.aspose.com/slides/th/cpp/aspose.slides/video/get_contenttype/) ที่คุณสามารถอ่านและใช้ได้, ตัวอย่างเช่นเมื่อบันทึกลงดิสก์.