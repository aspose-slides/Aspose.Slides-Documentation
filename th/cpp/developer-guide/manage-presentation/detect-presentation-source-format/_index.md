---
title: กำหนดรูปแบบต้นฉบับของงานนำเสนอใน C++
linktitle: รูปแบบแหล่งที่มา
type: docs
weight: 35
url: /th/cpp/detect-presentation-source-format/
keywords:
- รูปแบบต้นฉบับ
- ตรวจจับรูปแบบงานนำเสนอ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PPT
- PPTX
- C++
- Aspose.Slides
description: "อ่านรูปแบบต้นฉบับของงานนำเสนอที่โหลดใน C++ ด้วย Aspose.Slides for C++ เปรียบเทียบ API การตรวจจับ และจัดการไฟล์ สตรีม และรูปแบบเก่า"
---
## **ภาพรวม**

หลังจากโหลดงานนำเสนอแล้ว ให้เรียกใช้ [Presentation::get_SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_sourceformat/) เพื่อกำหนดรูปแบบต้นฉบับของมัน วิธีนี้ยังสามารถใช้ได้ผ่าน [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_sourceformat/) ใช้เมื่อการประมวลผลต่อไปขึ้นอยู่กับรูปแบบที่อินสแตนซ์ปัจจุบันถูกโหลดมา

รูปแบบต้นฉบับแตกต่างจาก [SaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) ที่เลือกสำหรับไฟล์ผลลัพธ์ การบันทึกเป็นรูปแบบอื่นไม่ได้เปลี่ยนรูปแบบต้นฉบับของอินสแตนซ์ที่มีอยู่

## **อ่านรูปแบบต้นฉบับของไฟล์**

ตัวอย่างนี้ต้องการไฟล์ `sample.pptx` ที่มีอยู่แล้ว จะโหลดไฟล์และเลือกนโยบายการประมวลผลของแอปพลิเคชันโดยใช้ [Presentation::get_SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_sourceformat/) แทนชื่อไฟล์ เปลี่ยนเส้นทางเข้าเพื่อทดลองรูปแบบอื่น ตัวอย่างจะแสดงนโยบายที่เลือก; แทนที่ข้อความเหล่านี้ด้วยตรรกะของแอปพลิเคชันของคุณ

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **จำแนกค่าที่รองรับ**

การอธิบายค่า [SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/sourceformat/) แยกแยะรูปแบบงานนำเสนอต่อไปนี้ ส่วนขยายด้านล่างเป็นส่วนขยายโดยทั่วไป ไม่ได้เป็นการสังเคราะห์ชื่อไฟล์ต้นฉบับใหม่

| ค่า SourceFormat | ส่วนขยาย | รูปแบบ |
| --- | --- | --- |
| `Ppt` | `.ppt` | งานนำเสนอ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | งานนำเสนอ Office Open XML |
| `Pptm` | `.pptm` | งานนำเสนอ Office Open XML พร้อมมาโคร |
| `Pps` | `.pps` | สไลด์โชว์ PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | สไลด์โชว์ Office Open XML |
| `Ppsm` | `.ppsm` | สไลด์โชว์ Office Open XML พร้อมมาโคร |
| `Pot` | `.pot` | เทมเพลต PowerPoint 97–2003 |
| `Potx` | `.potx` | เทมเพลต Office Open XML |
| `Potm` | `.potm` | เทมเพลต Office Open XML พร้อมมาโคร |
| `Odp` | `.odp` | งานนำเสนอ OpenDocument |
| `Otp` | `.otp` | เทมเพลตงานนำเสนอ OpenDocument |
| `Fodp` | `.fodp` | งานนำเสนอ Flat XML ODF |
| `Xml` | `.xml` | งานนำเสนอ PowerPoint XML |

## **อ่านรูปแบบต้นฉบับของสตรีม**

ตัวอย่างนี้ต้องการไฟล์ `sample.pps` ที่มีอยู่แล้ว การอ่านไบต์ของไฟล์ไปยังสตรีมหน่วยความจำจำลองการป้อนข้อมูลที่ไม่มีชื่อไฟล์ เช่น ค่าจากฐานข้อมูลหรืออาเรย์ไบต์ที่อัปโหลด ตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) จะรับสตรีมเท่านั้น

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS และ POT ใช้รูปแบบไบนารีเดียวกัน เมื่อโหลดโดยเส้นทางไฟล์ ส่วนขยายสามารถช่วยแยกสไลด์โชว์หรือเทมเพลตได้ หากไม่มีชื่อไฟล์ เนื้อหา PPS และ POT แบบเก่าอาจรายงานเป็น `SourceFormat::Ppt`; ตัวอย่าง PPS ด้านบนรายงาน `Ppt`

หากแอปพลิเคชันของคุณต้องการรักษาความแตกต่างนี้ ให้เก็บชื่อไฟล์ต้นฉบับหรือเมตาดาต้าย่อยแยกต่างหาก ส่วนขยายเป็นคำใบ้ที่มีประโยชน์สำหรับย่อยแบบเก่าเหล่านี้ แต่ไม่ควรเป็นพื้นฐานเดียวสำหรับการระบุตัวเนื้อหางานนำเสนอใด ๆ

## **เปรียบเทียบการตรวจจับก่อนและหลังการโหลด**

ใช้ [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationfactory/getpresentationinfo/) และ [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/get_loadformat/) เมื่อคุณต้องตรวจสอบไฟล์ก่อนที่จะโหลดโมเดลวัตถุของงานนำเสนอเต็มรูปแบบ ใช้ [Presentation::get_SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_sourceformat/) เมื่ออินสแตนซ์มีอยู่แล้ว

ตัวอย่างนี้ต้องการ `sample.pptx` และพิมพ์ `Pptx` สำหรับการตรวจสอบทั้งสองครั้ง ในการผลิต ให้เลือก API ที่เหมาะสมกับขั้นตอนการประมวลผลของคุณ; งานนำเสนอที่โหลดแล้วไม่จำเป็นต้องตรวจสอบครั้งที่สองเพียงเพื่อรับรูปแบบต้นฉบับ

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

ผลลัพธ์มีประเภทการอธิบายค่าแตกต่างกัน: [LoadFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadformat/) และ [SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/sourceformat/) อย่าเปรียบเทียบโดยการแคสค่าตัวเลขของพวกมัน หรือสมมติว่าทุกรูปแบบมีผลการตรวจจับเท่ากัน PowerPoint XML อาจรายงานเป็น `LoadFormat::Unknown` ก่อนโหลดและ `SourceFormat::Xml` หลังโหลด

## **แยกรูปแบบต้นฉบับและผลลัพธ์ออกจากกัน**

ตัวอย่างนี้ต้องการ `sample.pptx` และเขียน `converted.odp` มันพิมพ์ `Pptx` ทั้งก่อนและหลังการบันทึกอินสแตนซ์เดิม อินสแตนซ์ใหม่ที่โหลดจากไฟล์ ODP ผลลัพธ์จะรายงาน `Odp`

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

งานนำเสนอที่สร้างจากศูนย์ด้วย `MakeObject<Presentation>()` รายงาน `SourceFormat::Pptx` เนื่องจากไม่มีไฟล์อินพุต: นี่เป็นค่าเริ่มต้นสำหรับอินสแตนซ์ที่สร้างใหม่ ไม่ได้หมายความว่าไฟล์ PPTX ถูกโหลด ตรวจสอบว่าระบบของคุณสร้างหรือโหลดอินสแตนซ์แยกต่างหากหากความแตกต่างนี้สำคัญ

## **แมปรูปแบบต้นฉบับเป็นส่วนขยาย**

ตัวอย่างต่อไปนี้ต้องการ `sample.pptx` มันแมปค่า [SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/sourceformat/) ที่สนับสนุนในปัจจุบันทุกค่าเป็นส่วนขยายตามธรรมชาติ โดยไม่ต้องพาร์สชื่อไฟล์อินพุต การสำรองนี้หลีกเลี่ยงการกำหนดส่วนขยายอย่างเงียบ ๆ ให้กับค่าที่ไม่รู้จัก

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

การแมปนี้ไม่ได้แปลงไฟล์หรือกู้คืนย่อย PPS/POT แบบเก่าที่สูญหายระหว่างการโหลดสตรีม สำหรับการบันทึกจริง ให้เลือก [SaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) อย่างชัดเจน หรือใช้วิธีแปลงที่แสดงใน [Save Presentations in Their Original Format](/slides/th/cpp/save-presentation/#save-presentations-in-their-original-format)

## **ตรวจสอบรูปแบบโดยการบันทึกและเปิดใหม่**

ตัวอย่างนี้เป็นอิสระต่อกัน สร้างงานนำเสนอและเขียนไฟล์สามไฟล์ในไดเรกทอรีทำงาน โดยเขียนทับไฟล์ที่มีชื่อเดียวกัน จากนั้นเปิดไฟล์ผลลัพธ์แต่ละไฟล์ใหม่ทั้งโดยเส้นทางและผ่านสตรีมหน่วยความจำ สำหรับ PPTX และ ODP ทั้งสองวิธีจะรายงานรูปแบบที่บันทึกไว้ สำหรับ PPS การโหลดโดยเส้นทางรายงาน `Pps` ขณะที่การโหลดไบต์เดียวกันโดยไม่มีชื่อไฟล์รายงาน `Ppt`

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

ตารางต่อไปสรุปการระบุรูปแบบต้นฉบับสำหรับงานนำเสนอที่มีส่วนขยายตรงกัน:

| รูปแบบที่บันทึก | SourceFormat จากเส้นทางไฟล์ | SourceFormat จากสตรีมไม่มีชื่อ |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` ตามลำดับ | เช่นเดียวกับเส้นทางไฟล์ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` ตามลำดับ | เช่นเดียวกับเส้นทางไฟล์ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` ตามลำดับ | เช่นเดียวกับเส้นทางไฟล์ |
| ODP, OTP | `Odp`, `Otp` ตามลำดับ | เช่นเดียวกับเส้นทางไฟล์ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

เนื้อหา PPS/POT แบบเก่าจะถูกทำให้เป็นมาตรฐานเป็น `Ppt` สำหรับสตรีมที่ไม่มีชื่อ ตารางนี้อธิบายการระบุรูปแบบ ไม่ได้หมายถึงการรักษาฟีเจอร์ทุกอย่างของงานนำเสนอระหว่างการแปลง

## **FAQ**

**การบันทึกเป็น ODP ทำให้รูปแบบต้นฉบับของงานนำเสนอที่โหลดจาก PPTX เปลี่ยนหรือไม่?**

ไม่ การอินสแตนซ์ที่มีอยู่ยังคงรายงาน `Pptx` อินสแตนซ์ที่โหลดจากไฟล์ ODP ที่บันทึกไว้จะรายงาน `Odp`

**สตรีมสามารถแยกแยะงานนำเสนอแบบเก่า สไลด์โชว์ และเทมเพลตได้เสมอหรือไม่?**

ไม่ PPT, PPS และ POT ใช้รูปแบบไบนารีเดียวกัน เก็บชื่อไฟล์หรือเมตาดาต้าย่อยแยกต่างหากเมื่อจำเป็นต้องแยกความแตกต่างเหล่านี้

**ควรใช้ API ใดหากงานนำเสนอโหลดแล้ว?**

อ่าน [Presentation::get_SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_sourceformat/) ใช้ [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อการตรวจสอบก่อนการโหลด