---
title: แปลงงานนำเสนอ PowerPoint เป็น XML ด้วย C++
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/cpp/convert-powerpoint-to-xml/
keywords:
- แปลง PowerPoint เป็น XML
- แปลงงานนำเสนอเป็น XML
- PPT เป็น XML
- PPTX เป็น XML
- ODP เป็น XML
- การนำเสนอ PowerPoint XML
- SaveFormat::Xml
- บันทึกงานนำเสนอเป็น XML
- ส่งออกงานนำเสนอเป็น XML
- สตรีม XML
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีม PowerPoint XML ด้วย C++ และ Aspose.Slides for C++."
---
## **ภาพรวม**

Aspose.Slides for C++ สามารถแปลงงานนำเสนอ PowerPoint ไปเป็นรูปแบบ PowerPoint XML Presentation ได้ ผลลัพธ์ในรูปแบบ XML มีประโยชน์เมื่อคุณต้องการตัวแทนแบบข้อความสำหรับการตรวจสอบโครงสร้างงานนำเสนอ การแก้ไขปัญหาเอกสารที่สร้างขึ้น การเปรียบเทียบผลลัพธ์ในทดสอบอัตโนมัติ หรือการรวมกับกระบวนการทำงานที่ใช้ XML แทนแพ็คเกจงานนำเสนอ

ใช้เมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) กับค่า `Xml` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) คุณสามารถเขียนผลลัพธ์โดยตรงไปยังไฟล์หรือสตรีมได้

{{% alert color="info" title="Note" %}}

`SaveFormat::Xml` สร้าง PowerPoint XML Presentation ไม่ได้ดึงส่วน Office Open XML แต่ละส่วนที่เก็บอยู่ในแพ็คเกจ PPTX หากคุณต้องการส่วนที่อยู่ในแพ็คเกจ PPTX อย่างเช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพ็คเกจ PPTX เอง

{{% /alert %}}

## **แปลงงานนำเสนอเป็นไฟล์ XML**

โหลดงานนำเสนอแหล่งต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) แล้วส่งพาธผลลัพธ์และ `SaveFormat::Xml` ให้กับเมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) แหล่งต้นทางสามารถเป็นรูปแบบงานนำเสนอใดก็ได้ที่สนับสนุนการโหลด เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้แปลงงานนำเสนอ PPTX ไปเป็นไฟล์ XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **เขียนผลลัพธ์ XML ไปยังสตรีม**

ใช้การ overload ของสตรีมในเมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เมื่อ XML ต้องคงอยู่ในหน่วยความจำหรือส่งต่อไปยังส่วนประกอบอื่น เช่น เว็บเซอร์วิส ผู้ให้บริการจัดเก็บข้อมูล หรือไพป์ไลน์ประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง [MemoryStream](https://reference.aspose.com/slides/th/cpp/system.io/memorystream/) แล้วรีเซ็ตตำแหน่งเพื่อการอ่านต่อไป:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// ส่ง xmlStream ไปยังส่วนประกอบต่อไปในกระบวนการทำงาน.
```

## **เปรียบเทียบ XML กับรูปแบบการนำเสนอและการส่งออก**

เลือกรูปแบบผลลัพธ์ตามวิธีการที่ผลลัพธ์จะถูกใช้:

| รูปแบบ | ผลลัพธ์ | การใช้งานทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | การนำเสนอ PowerPoint XML | ตรวจสอบโครงสร้าง, แก้ไขปัญหา, เปรียบเทียบผลลัพธ์ที่สร้าง, การรวมแบบ XML |
| PPT (`.ppt`) | ไฟล์งานนำเสนอไบนารีแบบเก่า | ความเข้ากันได้กับกระบวนการทำงาน PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็คเกจ Office Open XML ที่มีหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนงานนำเสนอ |
| PDF หรือ TIFF | หน้าแบบจัดวางคงที่หรือภาพหลายหน้า | การดู, การพิมพ์, และการเก็บถาวร |
| PNG, JPEG หรือ SVG | ตัวแทนที่เรนเดอร์ของสไลด์บุคคลหนึ่ง | รูปย่อ, ตัวอย่าง, และทรัพยากรภาพ |
| HTML หรือ HTML5 | ผลลัพธ์งานนำเสนอแบบเว็บ | การดูในเบราว์เซอร์และการเผยแพร่เว็บ |

ต่างจาก PPT และ PPTX, ผลลัพธ์ XML ถูกออกแบบมาสำหรับการตรวจสอบและกระบวนการทำงานเชิงข้อมูลเป็นหลัก ต่างจาก PDF, TIFF, HTML และรูปแบบภาพสไลด์ มันเป็นตัวแทนข้อมูลงานนำเสนอ ไม่ใช่การเรนเดอร์สไลด์เป็นหน้า หรือทรัพยากรภาพ ตาราง [supported file formats](/slides/th/cpp/supported-file-formats/) ระบุ PowerPoint XML Presentation เป็นรูปแบบที่บันทึกได้เท่านั้น ดังนั้นอย่าใช้เมื่อต้องการโหลดไฟล์ที่ส่งออกกลับเข้าสู่ Aspose.Slides เพื่อแก้ไขต่อ

## **คำถามที่พบบ่อย**

**`SaveFormat::Xml` กับการบันทึกไฟล์ PPTX เป็นเรื่องเดียวกันหรือไม่?**

ไม่ใช่ PPTX เป็นแพ็คเกจที่ประกอบด้วยหลายส่วน Office Open XML ส่วน `SaveFormat::Xml` จะสร้างไฟล์ PowerPoint XML Presentation

**ฉันสามารถบันทึกผลลัพธ์ XML โดยไม่สร้างไฟล์บนดิสก์ได้หรือไม่?**

ได้ ส่งสตรีมที่เขียนได้ให้กับเมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) ตัวอย่างเช่น ใช้ [MemoryStream](https://reference.aspose.com/slides/th/cpp/system.io/memorystream/) สำหรับการประมวลผลในหน่วยความจำ

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกได้อีกครั้งหรือไม่?**

ไม่ การนำเสนอ PowerPoint XML ปัจจุบันรองรับการบันทึกเท่านั้น ไม่รองรับการโหลด ใช้ PPTX หรือรูปแบบงานนำเสนอที่รองรับอื่นเมื่อจำเป็นต้องทำการแก้ไขแบบรอบลูป

**การแปลงเป็น XML จะเรนเดอร์สไลด์แต่ละสไลด์เป็นหน้า หรือภาพหรือไม่?**

ไม่ การแปลงเป็น XML จะเขียนข้อมูลงานนำเสนอที่มีโครงสร้าง ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้า หรือ PNG, JPEG, และ SVG สำหรับภาพสไลด์แต่ละสไลด์