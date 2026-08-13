---
title: การรักษาความปลอดภัยของงานนำเสนอด้วยรหัสผ่านใน C++
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/cpp/password-protected-presentation/
keywords:
- ล็อก PowerPoint
- ล็อกงานนำเสนอ
- ปลดล็อก PowerPoint
- ปลดล็อกงานนำเสนอ
- ป้องกัน PowerPoint
- ป้องกันงานนำเสนอ
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสงานนำเสนอ
- ถอดรหัส PowerPoint
- ถอดรหัสงานนำเสนอ
- การป้องกันการเขียน
- ความปลอดภัยของ PowerPoint
- ความปลอดภัยของงานนำเสนอ
- ลบรหัสผ่าน
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดการใช้งานรหัสผ่าน
- ปิดการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกงานนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++. ปกป้องงานนำเสนอของคุณ"
---
## **บทนำ**

เมื่อคุณตั้งรหัสผ่านป้องกันงานนำเสนอ หมายความว่าคุณกำหนดรหัสผ่านที่บังคับใช้ข้อจำกัดบางอย่างกับงานนำเสนอ การลบข้อจำกัดนั้นต้องป้อนรหัสผ่าน งานนำเสนอที่ป้องกันด้วยรหัสผ่านถือเป็นงานนำเสนอที่ถูกล็อก

โดยทั่วไปคุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนงานนำเสนอได้ดังนี้:

- **การแก้ไข**

  หากคุณต้องการให้เฉพาะผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขงานนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้ป้องกันไม่ให้ผู้คนแก้ไข, เปลี่ยนแปลง หรือคัดลอกรายการในงานนำเสนอของคุณ (เว้นแต่พวกเขาจะให้รหัสผ่าน)

  อย่างไรก็ตามในกรณีนี้ แม้ไม่ใส่รหัสผ่าน ผู้ใช้ก็ยังสามารถเข้าถึงเอกสารของคุณและเปิดได้ ในโหมดอ่านอย่างเดียวนี้ ผู้ใช้สามารถดูเนื้อหา หรือองค์ประกอบต่างๆ—เช่น ลิงก์, แอนิเมชัน, เอฟเฟกต์ ฯลฯ—ภายในงานนำเสนอของคุณได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกงานนำเสนอได้

- **การเปิด**

  หากคุณต้องการให้เฉพาะผู้ใช้บางคนเท่านั้นที่สามารถเปิดงานนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้ทำให้ผู้คนไม่สามารถดูเนื้อหาของงานนำเสนอของคุณได้เลย (เว้นแต่พวกเขาจะให้รหัสผ่าน)

  โดยเทคนิคแล้ว ข้อจำกัดการเปิดยังป้องกันไม่ให้ผู้ใช้แก้ไขงานนำเสนอของคุณด้วย: เมื่อผู้คนไม่สามารถเปิดงานนำเสนอได้ พวกเขาจึงไม่สามารถทำการแก้ไขหรือเปลี่ยนแปลงใดๆ ได้  

**หมายเหตุ**ว่าเมื่อคุณตั้งรหัสผ่านป้องกันงานนำเสนอเพื่อป้องกันการเปิดไฟล์ ไฟล์งานนำเสนอจะถูกเข้ารหัส

## **วิธีป้องกันงานนำเสนอด้วยรหัสผ่านออนไลน์**

1. ไปที่หน้า [**Aspose.Slides Lock**](https://products.aspose.app/slides/th/lock) ของเรา. 

   ![todo:image_alt_text](slides-lock.png)

2. คลิก **Drop or upload your files**.

3. เลือกไฟล์ที่คุณต้องการตั้งรหัสผ่านป้องกันบนคอมพิวเตอร์ของคุณ. 

4. ใส่รหัสผ่านที่คุณต้องการสำหรับการป้องกันการแก้ไข; ใส่รหัสผ่านที่คุณต้องการสำหรับการป้องกันการดู. 

5. หากคุณต้องการให้ผู้ใช้เห็นงานนำเสนอของคุณเป็นสำเนาสุดท้าย ให้เลือกช่องทำเครื่องหมาย **Mark as final**.

6. คลิก **PROTECT NOW.** 

7. คลิก **DOWNLOAD NOW.**

## **การป้องกันด้วยรหัสผ่านสำหรับงานนำเสนอใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน, การเข้ารหัส, และการดำเนินการที่คล้ายกันสำหรับงานนำเสนอในรูปแบบต่อไปนี้: 

- PPTX and PPT - งานนำเสนอ Microsoft PowerPoint
- ODP - งานนำเสนอ OpenDocument
- OTP - แม่แบบงานนำเสนอ OpenDocument 

**การดำเนินการที่รองรับ**

Aspose.Slides อนุญาตให้คุณใช้การป้องกันด้วยรหัสผ่านบนงานนำเสนอเพื่อป้องกันการแก้ไขโดยวิธีต่อไปนี้:

- การเข้ารหัสงานนำเสนอ
- การตั้งการป้องกันการเขียนบนงานนำเสนอ

**การดำเนินการอื่นๆ**

Aspose.Slides อนุญาตให้คุณทำงานอื่นๆ ที่เกี่ยวกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสได้ดังนี้:

- การถอดรหัสงานนำเสนอ; การเปิดงานนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; การปิดใช้งานการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากงานนำเสนอ
- การรับคุณสมบัติของงานนำเสนอที่เข้ารหัส
- การตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่

## **เข้ารหัสงานนำเสนอ**

คุณสามารถเข้ารหัสงานนำเสนอโดยตั้งรหัสผ่านได้ จากนั้นเพื่อแก้ไขงานนำเสนอที่ถูกล็อก ผู้ใช้จะต้องให้รหัสผ่าน

เพื่อเข้ารหัสหรือป้องกันงานนำเสนอด้วยรหัสผ่าน คุณต้องใช้เมธอด encrypt (จาก [ProtectionManager](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager)) เพื่อกำหนดรหัสผ่านให้กับงานนำเสนอ คุณส่งรหัสผ่านไปยังเมธอด encrypt และใช้เมธอด save เพื่อบันทึกงานนำเสนอที่ถูกเข้ารหัสแล้ว

ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสงานนำเสนอ:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **ตั้งการป้องกันการเขียนบนงานนำเสนอ** 

คุณสามารถเพิ่มเครื่องหมายว่า “Do not modify” (ห้ามแก้ไข) ลงในงานนำเสนอได้ วิธีนี้ช่วยบอกผู้ใช้ว่าคุณไม่ต้องการให้พวกเขาแก้ไขงานนำเสนอที่นี่  

**หมายเหตุ** ว่ากระบวนการป้องกันการเขียนไม่ได้ทำการเข้ารหัสงานนำเสนอ ดังนั้นผู้ใช้—หากต้องการ—สามารถแก้ไขงานนำเสนอได้ แต่หากต้องการบันทึกการเปลี่ยนแปลง พวกเขาต้องสร้างงานนำเสนอใหม่ด้วยชื่อที่ต่างออกไป 

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด setWriteProtection ตัวอย่างโค้ดนี้แสดงวิธีการตั้งการป้องกันการเขียนบนงานนำเสนอ:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **โหลดงานนำเสนอที่เข้ารหัส**

Aspose.Slides อนุญาตให้คุณโหลดไฟล์ที่ถูกเข้ารหัสโดยส่งรหัสผ่านของมันไป เพื่อถอดรหัสงานนำเสนอ คุณต้องเรียกเมธอด [RemoveEncryption](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) โดยไม่มีพารามิเตอร์ จากนั้นคุณจะต้องใส่รหัสผ่านที่ถูกต้องเพื่อโหลดงานนำเสนอ

ตัวอย่างโค้ดนี้แสดงวิธีการถอดรหัสงานนำเสนอ: 

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว
```

## **ลบการเข้ารหัสจากงานนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านจากงานนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขงานนำเสนอโดยไม่มีข้อจำกัด

เพื่อทำการลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน คุณต้องเรียกเมธอด [RemoveEncryption](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) ตัวอย่างโค้ดนี้แสดงการลบการเข้ารหัสจากงานนำเสนอ:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **ลบการป้องกันการเขียนจากงานนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้กับไฟล์งานนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขได้ตามต้องการ—และจะไม่มีการเตือนเมื่อทำเช่นนั้น

คุณสามารถลบการป้องกันการเขียนจากงานนำเสนอโดยใช้เมธอด [RemoveWriteProtection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) ตัวอย่างโค้ดนี้แสดงวิธีลบการป้องกันการเขียนจากงานนำเสนอ:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **รับคุณสมบัติของงานนำเสนอที่เข้ารหัส**

โดยทั่วไปผู้ใช้มักประสบปัญหาในการดึงคุณสมบัติของเอกสารจากงานนำเสนอที่เข้ารหัสหรือถูกป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ทำให้คุณสามารถตั้งรหัสผ่านป้องกันงานนำเสนอพร้อมยังคงเข้าถึงคุณสมบัติของเอกสารได้

**หมายเหตุ:** โดยค่าเริ่มต้นเมื่อ Aspose.Slides เข้ารหัสงานนำเสนอ คุณสมบัติของเอกสารของงานนำเสนอจะถูกป้องกันด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติของเอกสารยังคงเข้าถึงได้แม้หลังจากการเข้ารหัส Aspose.Slides ให้คุณทำได้เช่นนั้น

หากคุณต้องการให้ผู้ใช้ยังคงสามารถเข้าถึงคุณสมบัติของงานนำเสนอที่เข้ารหัสได้ ให้ส่งค่า `false` ไปยังเมธอด `set_EncryptDocumentProperties` ของ [IProtectionManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/) ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสงานนำเสนอพร้อมยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสารได้:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **โหลดเฉพาะคุณสมบัติของเอกสารจากงานนำเสนอที่เข้ารหัส**

เพื่อสอบถามเมตาดาต้าของงานนำเสนอที่เข้ารหัสโดยไม่ต้องโหลดสไลด์หรือเนื้อหาอื่นๆ ให้สร้างอ็อบเจกต์ [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) แล้วตั้งค่า [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) เป็น `true` ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติของเอกสารที่เปิดเผยต่อสาธารณะ

ตัวอย่างโค้ดต่อไปนี้อ่านคุณสมบัติของเอกสารที่กำหนดไว้ล่วงหน้าและที่กำหนดเองผ่าน [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

กระบวนการทำงานนี้ใช้ได้เฉพาะเมื่อคุณสมบัติของเอกสารไม่ได้ถูกเข้ารหัส (เป็นสาธารณะ) ขณะงานนำเสนอถูกเข้ารหัส หากคุณสมบัติของเอกสารถูกเข้ารหัส การตั้งค่า `LoadOptions::set_OnlyLoadDocumentProperties` เป็น `true` จะทำให้เกิดข้อยกเว้นเพราะรหัสผ่านถูกละเว้นในโหมดนี้ เพื่อเข้าถึงคุณสมบัติของเอกสารที่เข้ารหัสหรือโหลดงานนำเสนอทั้งหมดรวมถึงสไลด์และเนื้อหาอื่น ให้ระบุรหัสผ่านที่ถูกต้องด้วย `LoadOptions::set_Password` ใน [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/)

## **ตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดงานนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่างานนำเสนอไม่ได้รับการป้องกันด้วยรหัสผ่าน วิธีนี้จะช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่นๆ ที่อาจเกิดขึ้นเมื่อโหลดงานนำเสนอที่ป้องกันด้วยรหัสผ่านโดยไม่ใส่รหัสผ่าน

โค้ด C++ ตัวนี้แสดงวิธีตรวจสอบงานนำเสนอว่าถูกป้องกันด้วยรหัสผ่านหรือไม่ (โดยไม่โหลดงานนำเสนอเอง):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **ตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้เมธอด [get_IsEncrypted()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) ซึ่งจะคืนค่า `true` หากงานนำเสนอถูกเข้ารหัสหรือ `false` หากไม่ได้ถูกเข้ารหัส

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้เมธอด [get_IsWriteProtected()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) ซึ่งจะคืนค่า `true` หากงานนำเสนอถูกป้องกันการเขียนหรือ `false` หากไม่ได้ถูกป้องกัน

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **ตรวจสอบการใช้รหัสผ่านของงานนำเสนอ**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อป้องกันเอกสารงานนำเสนอหรือไม่ Aspose.Slides มีวิธีให้คุณตรวจสอบความถูกต้องของรหัสผ่าน

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบความถูกต้องของรหัสผ่าน:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// ตรวจสอบว่า "pass" ตรงกับ
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

มันจะคืนค่า `true` หากงานนำเสนอถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า `false`.

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**อะไรคือวิธีการเข้ารหัสที่ Aspose.Slides รองรับ?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่ รวมถึงอัลกอริทึมที่ใช้ AES ซึ่งทำให้มั่นใจว่าข้อมูลงานนำเสนอของคุณมีความปลอดภัยระดับสูง

**จะเกิดอะไรขึ้นหากใส่รหัสผ่านไม่ถูกต้องขณะพยายามเปิดงานนำเสนอ?**

ระบบจะขว้างข้อยกเว้นถ้ารหัสผ่านไม่ถูกต้อง แจ้งให้คุณทราบว่าการเข้าถึงงานนำเสนอถูกปฏิเสธ สิ่งนี้ช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและรักษาเนื้อหาของงานนำเสนอ

**มีผลต่อประสิทธิภาพหรือไม่เมื่อทำงานกับงานนำเสนอที่ป้องกันด้วยรหัสผ่าน?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้เกิดภาระเพิ่มขึ้นเล็กน้อยในการเปิดและบันทึกงาน ในหลายกรณี ผลกระทบต่อประสิทธิภาพนี้เป็นเพียงเล็กน้อยและไม่ส่งผลต่อเวลาในการประมวลผลงานนำเสนอโดยรวมอย่างมีนัยสำคัญ