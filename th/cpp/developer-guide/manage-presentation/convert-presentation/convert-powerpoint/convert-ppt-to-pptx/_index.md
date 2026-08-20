---
title: แปลง PPT เป็น PPTX ใน C++
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/cpp/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT เป็น PPTX
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX ด้วย C++ และ Aspose.Slides. มีตัวอย่าง C++ สำหรับการแปลงไฟล์เดียวและแบบชุด, การจัดการข้อผิดพลาด, และบันทึกความแม่นยำ."
---
## **ภาพรวม**

PPT คือรูปแบบไบนารีเก่าของ PowerPoint ในขณะที่ PPTX คือรูปแบบ Open XML ใหม่กว่า Aspose.Slides สำหรับ C++ สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) จากนั้นเรียกใช้ [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) พร้อมด้วย [SaveFormat::Pptx](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) ทำลายออบเจ็กต์ presentation เมื่อไม่ต้องการใช้งานแล้วเพื่อปล่อยทรัพยากร

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

ส่วนต่อท้ายของไฟล์ไม่ได้เลือกรูปแบบผลลัพธ์ด้วยตัวเอง; อาร์กิวเมนต์ [SaveFormat::Pptx](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) ทำหน้าที่นั้น. รักษาเส้นทางอินพุตและเอาต์พุตให้แตกต่างกันหากต้องการเก็บไฟล์ PPT ดั้งเดิมไว้

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้แปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง แต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้กระบวนการทั้งหมดหยุด

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

สำหรับงานในสภาพการผลิต ให้บันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าจะแทนที่ไฟล์ผลลัพธ์ที่มีอยู่หรือไม่, และเขียนชื่อไฟล์ที่ล้มเหลวไปยังคิวลองใหม่หรือคิวตรวจสอบ ไฟล์เสีย, ไฟล์ที่ป้องกันด้วยรหัสผ่านที่เปิดโดยไม่มีรหัสที่ถูกต้อง, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับอาจทำให้การแปลงล้มเหลวทั้งหมด ดู [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/cpp/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส

## **ความถูกต้องและคุณลักษณะเก่า**

การแปลงโดยทั่วไปจะคงสไลด์, มาสเตอร์, เลย์เอาต์, ข้อความ, รูปร่าง, รูปภาพ, ตาราง, และแผนภูมิไว้ แต่ PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในลักษณะเดียวกันเต็มที่ คุณลักษณะเก่าที่ไม่มีสมมาตรใน PPTX หรือไม่รองรับโดยไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ลบออก, หรือแสดงในรูปแบบที่แตกต่างกัน

ตรวจสอบไฟล์ที่แปลงเมื่อมีการรวมแอนิเมชัน, การเปลี่ยนภาพ, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, ควบคุม ActiveX, สื่อที่ฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือมาโคร VBA. ไฟล์ PPTX ธรรมดาไม่ใช่รูปแบบที่รองรับมาโคร ดังนั้นให้ใช้เวิร์กโฟลว์ที่รองรับมาโครเมื่อจำเป็นต้องให้ VBA ยังใช้งานได้. นอกจากนี้ให้ตรวจสอบว่าฟอนต์ที่ต้องการและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่นำเสนอที่แปลงแล้วจะถูกเปิดหรือแสดงผล

สำหรับเอกสารสำคัญ ให้เปิด PPTX ที่สร้างขึ้นใหม่ด้วยโปรแกรมและตรวจสอบจำนวนสไลด์สำคัญและเนื้อหา จากนั้นเปรียบเทียบลักษณะการแสดงและพฤติกรรมสไลด์โชว์ในตัวดูที่ต้องการ อย่าพิจารณาการเรียก [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) ที่สำเร็จเป็นหลักฐานว่าทุกคุณลักษณะเก่ามีการแสดงผลใน PPTX อย่างตรงกัน

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในรุ่น PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพคเกจ Open XML, หรือจัดเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารี PPT เก่า. เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาเพื่อการเก็บถาวรหรือคืนสถานะจนกว่าการนำเสนอที่แปลงแล้วจะผ่านการตรวจสอบความถูกต้องของคุณ

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบผลลัพธ์อื่นแทน ให้ใช้คำแนะนำเฉพาะรูปแบบใน [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) แทนการสมมติว่าทุกเป้าหมายจะคงคุณลักษณะ PowerPoint ที่แก้ไขได้

## **ตัวแปลงออนไลน์**

สำหรับไฟล์ที่ต้องการเป็นครั้งคราวหรือเปรียบเทียบอย่างรวดเร็ว คุณสามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx). สำหรับการแปลงที่ทำซ้ำ, การประมวลผลแบบแบ็ช, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ C++ API

## **บทความที่เกี่ยวข้อง**

- [บันทึกการนำเสนอใน C++](/cpp/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/cpp/supported-file-formats/)
- [เปิดการนำเสนอใน C++](/cpp/open-presentation/)

## **FAQ**

**Can I convert PPT to PPTX without Microsoft PowerPoint installed?**

ใช่. Aspose.Slides สำหรับ C++ สามารถโหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องอาศัย Microsoft PowerPoint

**Will PPT-to-PPTX conversion preserve all content exactly?**

การแปลงจะคงเนื้อหาการนำเสนอที่ทั่วไปไว้, แต่ความแม่นยำแบบเต็มที่ไม่รับประกันสำหรับคุณลักษณะเก่าหรือที่ไม่รองรับทั้งหมด ตรวจสอบไฟล์ที่สร้างเมื่อมีมาโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป

**Can I convert a password-protected PPT file?**

ใช่, หากคุณระบุรหัสผ่านที่ถูกต้องขณะโหลดไฟล์ รหัสผ่านที่หายไปหรือไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**Should I delete the PPT file after conversion?**

เก็บไฟล์ต้นฉบับไว้จนกว่าจะตรวจสอบ PPTX ในตัวดูและเวิร์กโฟลว์ที่สำคัญแล้ว ซึ่งจะเป็นสำเนาสำหรับการกู้คืนหากคุณลักษณะเก่าถูกแปลงอย่างแตกต่าง