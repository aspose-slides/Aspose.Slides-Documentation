---
title: แปลงงานนำเสนอ PowerPoint เป็น XPS ด้วย C++
linktitle: PowerPoint เป็น XPS
type: docs
weight: 70
url: /th/cpp/convert-powerpoint-to-xps
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น XPS
- งานนำเสนอเป็น XPS
- สไลด์เป็น XPS
- PPT เป็น XPS
- PPTX เป็น XPS
- บันทึก PPT เป็น XPS
- บันทึก PPTX เป็น XPS
- ส่งออก PPT เป็น XPS
- ส่งออก PPTX เป็น XPS
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น XPS คุณภาพสูง ไม่ขึ้นกับแพลตฟอร์ม ด้วย C++ และ Aspose.Slides. รับคู่มือขั้นตอนต่อขั้นตอนและโค้ดตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint เป็น XPS โดยการบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อใดที่รูปแบบ XPS มีประโยชน์และแสดงวิธีการทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่าแบบกำหนดเองของ [XpsOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/xpsoptions/)  

## **เกี่ยวกับ XPS**
Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกของ [PDF](https://docs.fileformat.com/pdf/)  ซึ่งทำให้คุณพิมพ์เนื้อหาโดยการสร้างไฟล์ที่คล้ายกับ PDF รูปแบบ XPS อิงตาม XML โครงสร้างของไฟล์ XPS จะคงที่บนระบบปฏิบัติการและเครื่องพิมพ์ทั้งหมด  

## **เมื่อควรใช้รูปแบบ Microsoft XPS**

{{% alert color="info" %}} 

เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PPT หรือ PPTX ไปเป็นรูปแบบ XPS อย่างไร คุณสามารถลองใช้ [แอปแปลงออนไลน์ฟรีนี้](https://products.aspose.app/slides/th/conversion)  

{{% /alert %}} 

หากคุณต้องการลดค่าใช้จ่ายในการจัดเก็บข้อมูล คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint ของคุณเป็นรูปแบบ XPS ได้ วิธีนี้จะทำให้คุณบันทึก แชร์ และพิมพ์เอกสารได้ง่ายขึ้น  

Microsoft ยังคงสนับสนุน XPS อย่างเต็มรูปแบบใน Windows (รวมถึง Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์เป็นรูปแบบนี้ หากคุณใช้งาน Windows 8.1, Windows 8, Windows 7 หรือ Windows Vista XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับบางการทำงาน  

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันมาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 ให้การสนับสนุนไฟล์ XPS ดีกว่าไฟล์ PDF  
  - **XPS:** มีตัวอ่าน/ดู XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS  
  - **PDF:** มีตัวอ่าน PDF แต่ไม่มีฟีเจอร์การพิมพ์เป็น PDF  

- **Windows 7 และ Windows Vista** ใช้รูปแบบ XPS ดั้งเดิม ระบบปฏิบัติการเหล่านี้ยังให้การสนับสนุนไฟล์ XPS ดีกว่า PDF ด้วย  
  - **XPS:** มีตัวอ่าน XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS  
  - **PDF:** ไม่มีตัวอ่าน PDF ไม่มีกิจกรรมการพิมพ์เป็น PDF  

|<p>**อินพุต PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**เอาต์พุต XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ในที่สุดได้เพิ่มการสนับสนุนการพิมพ์เป็น PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านี้ผู้ใช้ต้องพิมพ์เอกสารผ่านรูปแบบ XPS  

## **การแปลง XPS ด้วย Aspose.Slides**

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/cpp/) สำหรับ C++ คุณสามารถใช้เมธอด [**Save**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) ที่เปิดให้ใช้งานจากคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร XPS  

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้การตั้งค่าใดการตั้งหน้าที่ต่อไปนี้  

- การตั้งค่าเริ่มต้น (โดยไม่ใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.xps_options))  
- การตั้งค่าที่กำหนดเอง (โดยใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.xps_options))  

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

ตัวอย่างโค้ด C++ นี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่าเริ่มต้น  

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// บันทึกงานนำเสนอเป็นเอกสาร XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่ากำหนดเอง**
ตัวอย่างโค้ดนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ากำหนดเองใน C++  

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// สร้างอ็อบเจกต์ XpsOptions
auto options = System::MakeObject<XpsOptions>();

// บันทึก MetaFiles เป็น PNG
options->set_SaveMetafilesAsPng(true);

// บันทึกงานนำเสนอเป็นเอกสาร XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **คำถามที่พบบ่อย**

### ฉันสามารถบันทึกเป็น XPS ไปยังสตรีมแทนไฟล์ได้หรือไม่?

ได้—Aspose.Slides ให้คุณส่งออกโดยตรงไปยังสตรีม ซึ่งเหมาะสำหรับ Web API, พายไลน์ฝั่งเซิร์ฟเวอร์ หรือกรณีใดๆ ที่ต้องการส่ง XPS โดยไม่ต้องเขียนไฟล์ลงระบบ  

### สไลด์ที่ซ่อนอยู่จะถูกนำไปยัง XPS หรือไม่ และฉันสามารถละเว้นได้หรือไม่?

ตามค่าเริ่มต้นจะเรนเดอร์เฉพาะสไลด์ที่มองเห็นได้เท่านั้น คุณสามารถ [รวมหรือละเว้นสไลด์ที่ซ่อนอยู่](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) ผ่าน [การตั้งค่าการส่งออก](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีเพียงหน้าที่คุณต้องการเท่านั้น