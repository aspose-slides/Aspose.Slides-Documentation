---
title: แปลง PPT เป็น PPTX ด้วย C++
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/cpp/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT ไปเป็น PPTX
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลงไฟล์ PPT แบบเก่าเป็น PPTX ด้วย C++ และ Aspose.Slides. รวมตัวอย่าง C++ สำหรับการแปลงไฟล์เดียวและแบบชุด, การจัดการข้อผิดพลาด, และบันทึกเกี่ยวกับความแม่นยำ."
---
## **ภาพรวม**

PPT คือรูปแบบไบนารีเก่า ของ PowerPoint, ส่วน PPTX คือรูปแบบ Open XML ใหม่. Aspose.Slides for C++ สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint. บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง.

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) แล้วเรียก [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) พร้อมด้วย [SaveFormat::Pptx](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/). ปล่อยวัตถุ Presentation เมื่อไม่ต้องการใช้แล้วเพื่อคืนทรัพยากร.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

นามสกุลไฟล์ไม่ได้กำหนดรูปแบบเอาต์พุตโดยอัตโนมัติ; เพียงแค่พารามิเตอร์ [SaveFormat::Pptx](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) เท่านั้นที่ทำหน้าที่นั้น. ให้เก็บเส้นทางอินพุตและเอาต์พุตแยกกันหากต้องการรักษาไฟล์ PPT ต้นฉบับไว้.

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง. แต่ละไฟล์จะถูกประมวลผลแยกกัน, ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้ชุดการประมวลผลทั้งหมดหยุด.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

สำหรับงานในสภาพการผลิต, ควรบันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าจะเขียนทับไฟล์เอาต์พุตที่มีอยู่หรือไม่, และเขียนชื่อไฟล์ที่ล้มเหลวลงในคิวรีเทรหรือคิวตรวจสอบ. ไฟล์เสีย, ไฟล์ที่ป้องกันด้วยรหัสผ่านแต่เปิดโดยไม่มีรหัสที่ต้องการ, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับทั้งหมดสามารถทำให้การแปลงล้มเหลวได้. ดู [งานนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/cpp/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส.

## **ความแม่นยำและคุณลักษณะเก่า**

การแปลงโดยทั่วไปจะคงสไลด์, มาสเตอร์, เลย์เอาต์, ข้อความ, รูปร่าง, รูปภาพ, ตาราง, และแผนภูมิ. อย่างไรก็ตาม PPT และ PPTX ไม่ได้แสดงคุณลักษณะทั้งหมดในรูปแบบที่เหมือนกันอย่างเต็มที่. คุณลักษณะเก่าที่ไม่มีเทียบเท่าใน PPTX หรือไม่รองรับโดยไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ลบออก, หรือแสดงในรูปแบบที่แตกต่าง.

ตรวจสอบไฟล์ที่แปลงแล้วเมื่อมีแอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, ควบคุม ActiveX, สื่อที่ฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือแมโคร VBA. ไฟล์ PPTX ธรรมดาไม่ใช่รูปแบบที่สนับสนุนแมโคร, ดังนั้นใช้กระบวนการทำงานที่รองรับแมโครเมื่อจำเป็นต้องให้ VBA ทำงานได้. นอกจากนี้ให้ตรวจสอบว่าฟอนต์ที่จำเป็นและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่ไฟล์นำเสนอที่แปลงแล้วจะถูกเปิดหรือเรนเดอร์.

สำหรับเอกสารที่สำคัญ, ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่โดยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาหลัก, จากนั้นเปรียบเทียบรูปลักษณ์และพฤติกรรมการแสดงสไลด์ในโปรแกรมชมที่ต้องการ. อย่าถือว่าการเรียก [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) ที่สำเร็จเป็นหลักฐานว่าคุณลักษณะเก่าทุกรายการมีการแสดงผลเป็น PPTX อย่างแม่นยำ.

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพ็คเกจ Open XML, หรือจัดเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารีเก่า PPT. เก็บไฟล์ PPT ต้นฉบับเป็นสำเนาการเก็บถาวรหรือสำเนาสำรองจนกว่าการนำเสนอที่แปลงแล้วผ่านการตรวจสอบความแม่นยำของคุณ.

หากคุณต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบเอาต์พุตอื่น, ให้ใช้คำแนะนำตามรูปแบบใน [แปลงงานนำเสนอเป็นหลายรูปแบบ](/slides/th/cpp/convert-presentation/) แทนที่จะสันนิษฐานว่าทุกเป้าหมายรักษาคุณลักษณะ PowerPoint ที่แก้ไขได้.

## **ตัวแปลงออนไลน์**

สำหรับไฟล์บางครั้งหรือการเปรียบเทียบอย่างรวดเร็ว, คุณสามารถใช้ [ตัวแปลงออนไลน์ PPT เป็น PPTX](https://products.aspose.app/slides/th/conversion/ppt-to-pptx). สำหรับการแปลงที่ทำซ้ำ, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน, ใช้ C++ API.

## **บทความที่เกี่ยวข้อง**

- [บันทึกงานนำเสนอด้วย C++](/slides/th/cpp/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/slides/th/cpp/supported-file-formats/)
- [เปิดงานนำเสนอด้วย C++](/slides/th/cpp/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ได้. Aspose.Slides for C++ โหลดและบันทึกไฟล์งานนำเสนอโดยไม่ต้องใช้ Microsoft PowerPoint.

**การแปลงจาก PPT เป็น PPTX จะคงเนื้อหาทั้งหมดอย่างแม่นยำหรือไม่?**

มันจะคงเนื้อหาการนำเสนอทั่วไปไว้, แต่ความแม่นยำแบบเต็มรูปแบบไม่รับประกันสำหรับทุกคุณลักษณะเก่าหรือที่ไม่รองรับ. ตรวจสอบไฟล์ที่สร้างเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป.

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้, หากคุณใส่รหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์. การไม่มีหรือรหัสผ่านไม่ถูกต้องจะทำให้การโหลดล้มเหลว.

**ฉันควรลบไฟล์ PPT หลังจากการแปลงหรือไม่?**

ให้เก็บไฟล์ต้นฉบับไว้จนกว่าจะตรวจสอบ PPTX ในโปรแกรมชมและกระบวนการทำงานที่สำคัญต่อคุณ. นี้จะเป็นสำเนาสำรองหากคุณลักษณะเก่าแปลงแตกต่าง.