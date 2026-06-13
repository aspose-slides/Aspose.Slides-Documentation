---
title: บันทึกงานนำเสนอใน C++
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/cpp/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชรูปย่อ
- บันทึกความคืบหน้า
- C++
- Aspose.Slides
description: "ค้นพบวิธีบันทึกงานนำเสนอใน C++ ด้วย Aspose.Slides—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงเลย์เอาต์ ฟอนต์ และเอฟเฟกต์"
---
## **ภาพรวม**

[Open Presentations in C++](/slides/th/cpp/open-presentation/) อธิบายวิธีใช้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำเสนอจากศูนย์หรือแก้ไขงานที่มีอยู่ คุณจะต้องบันทึกเมื่อทำเสร็จ ด้วย Aspose.Slides สำหรับ C++ คุณสามารถบันทึกลง **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ.

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอลงไฟล์โดยเรียกเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกให้เมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides.

```cpp
// สร้างอินสแทนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ทำงานบางอย่างที่นี่...
// บันทึกงานนำเสนอลงไฟล์.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมโดยส่งสตรีมผลลัพธ์ไปยังเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) งานนำเสนอสามารถเขียนลงสตรีมได้หลายประเภท ในตัวอย่างด้านล่าง เราจะสร้างงานนำเสนอใหม่และบันทึกลงสตรีมไฟล์.

```cpp
// สร้างอินสแทนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// บันทึกงานนำเสนอไปยังสตรีม.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **บันทึกงานนำเสนอพร้อมประเภทมุมมองที่กำหนดไว้ล่วงหน้า**

Aspose.Slides ให้คุณกำหนดมุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/) ใช้วิธี [set_LastView](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/set_lastview/) พร้อมค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewtype/).

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/) และตั้งค่าคุณสมบัติ conformance ขณะบันทึก หากคุณตั้งค่า `Conformance.Iso29500_2008_Strict` ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML  
ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// สร้างอินสแทนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่จำกัดขนาดไม่บีบอัดของไฟล์ใด ๆ ไม่เกิน 4 GB (2^32 ไบต์) ขนาดที่บีบอัดของไฟล์ใด ๆ ไม่เกิน 4 GB และขนาดรวมของไฟล์อับรวมไม่เกิน 4 GB รวมทั้งจำกัดจำนวนไฟล์ในอาร์ไคฟ์ไม่เกิน 65,535 (2^16‑1) ไฟล์ ส่วนขยายรูปแบบ ZIP64 จะเพิ่มข้อจำกัดเหล่านี้เป็น 2^64  
เมธอด [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 หรือไม่ขณะบันทึกไฟล์ Office Open XML  
เมธอดนี้สามารถใช้กับโหมดต่อไปนี้:

- `IfNecessary` ใช้ส่วนขยายรูปแบบ ZIP64 เฉพาะเมื่อรายการนำเสนอเกินขีดจำกัดดังกล่าว นี่คือโหมดเริ่มต้น.
- `Never` จะไม่ใช้ส่วนขยายรูปแบบ ZIP64.
- `Always` จะใช้ส่วนขยายรูปแบบ ZIP64 เสมอ.

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็น PPTX โดยเปิดใช้ส่วนขยายรูปแบบ ZIP64:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
เมื่อคุณบันทึกด้วย `Zip64Mode.Never` จะเกิด [PptxException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxexception/) หากไม่สามารถบันทึกงานนำเสนอในรูปแบบ ZIP32
{{% /alert %}}

## **บันทึกงานนำเสนอโดยไม่ทำการรีเฟรชรูปย่อ**

เมธอด [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) ควบคุมการสร้างรูปย่อเมื่อบันทึกงานนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` รูปย่อจะถูกรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น.
- หากตั้งค่าเป็น `false` รูปย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีรูปย่อ จะไม่สร้างรูปย่อใด

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชรูปย่อ.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
ตัวเลือกนี้ช่วยลดเวลาในการบันทึกงานนำเสนอในรูปแบบ PPTX
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprogresscallback/) ถูกใช้ผ่านเมธอด `set_ProgressCallback` ที่เปิดให้ใช้โดยอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isaveoptions/) และคลาสเชิงนามธรรม [SaveOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/) กำหนดการใช้งานของ [IProgressCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprogresscallback/) ด้วย `set_ProgressCallback` เพื่อรับการอัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์  
โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // ใช้ค่าร้อยละของความคืบหน้าในที่นี้.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอป [PowerPoint Splitter ฟรี](https://products.aspose.app/slides/th/splitter) โดยใช้ API ของตนเอง แอปนี้ช่วยคุณแยกงานนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับ "fast save" (การบันทึกแบบเพิ่มส่วน) เพื่อให้เขียนเฉพาะการเปลี่ยนแปลงหรือไม่?**  
ไม่มี การบันทึกจะสร้างไฟล์เต็มทุกครั้ง; การบันทึกแบบเพิ่มส่วน "fast save" ไม่ได้รับการสนับสนุน

**การบันทึกอินสแตนซ์ Presentation เดียวกันจากหลายเธรดปลอดภัยหรือไม่?**  
ไม่มี อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) [ไม่ปลอดภัยต่อการทำงานหลายเธรด](/slides/th/cpp/multithreading/); ให้บันทึกจากเธรดเดียว

**เกิดอะไรขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่ลิงก์จากภายนอกเมื่อบันทึก?**  
[ไฮเปอร์ลิงก์](/slides/th/cpp/manage-hyperlinks/) จะถูกรักษาไว้ ไฟล์ที่ลิงก์จากภายนอก (เช่น วิดีโอที่อ้างอิงแบบ relative path) จะไม่ถูกคัดลอกโดยอัตโนมัติ—ให้ตรวจสอบว่าหนทางที่อ้างอิงยังเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึกเมทาดาต้าเอกสาร (Author, Title, Company, Date) ได้หรือไม่?**  
ได้ มีการสนับสนุน [คุณสมบัติเอกสารมาตรฐาน](/slides/th/cpp/presentation-properties/) และจะถูกเขียนลงไฟล์เมื่อบันทึก