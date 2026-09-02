---
title: ป้องกันพรีเซนเทชันด้วยรหัสผ่านใน C++
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/cpp/password-protected-presentation/
keywords:
- ล็อค PowerPoint
- ล็อคพรีเซนเทชัน
- ปลดล็อค PowerPoint
- ปลดล็อคพรีเซนเทชัน
- ป้องกัน PowerPoint
- ป้องกันพรีเซนเทชัน
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสพรีเซนเทชัน
- ถอดรหัส PowerPoint
- ถอดรหัสพรีเซนเทชัน
- การป้องกันการเขียน
- ความปลอดภัย PowerPoint
- ความปลอดภัยพรีเซนเทชัน
- ลบรหัสผ่าน
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดใช้งานรหัสผ่าน
- ปิดการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกพรีเซนเทชัน PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++. ปกป้องพรีเซนเทชันของคุณ."
---
## **บทนำ**

เมื่อคุณป้องกันพรีเซนเทชันด้วยรหัสผ่าน หมายความว่าคุณกำหนดรหัสผ่านเพื่อบังคับใช้ข้อจำกัดบางอย่างบนพรีเซนเทชัน เพื่อลบข้อจำกัดเหล่านั้น จำเป็นต้องป้อนรหัสผ่าน พรีเซนเทชันที่ป้องกันด้วยรหัสผ่านจะถือว่าเป็นพรีเซนเทชันที่ถูกล็อก

โดยทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนพรีเซนเทชันได้:

- **การแก้ไข**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขพรีเซนเทชันของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแก้ไข เปลี่ยนแปลง หรือคัดลอกข้อมูลในพรีเซนเทชันของคุณ (หากไม่ได้ใส่รหัสผ่าน)  

  อย่างไรก็ตาม ในกรณีนี้ ผู้ใช้ยังสามารถเข้าถึงเอกสารของคุณและเปิดมันได้ ในโหมดอ่านอย่างเดียว ผู้ใช้สามารถดูเนื้อหา เช่น ลิงก์ ไฮเปอร์ลิงก์ แอนิเมชั่น เอฟเฟกต์ ฯลฯ ภายในพรีเซนเทชันได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกพรีเซนเทชันได้

- **การเปิด**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถเปิดพรีเซนเทชันของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นมองเห็นเนื้อหาของพรีเซนเทชัน (หากไม่ได้ใส่รหัสผ่าน)

  โดยเทคนิค ข้อจำกัดการเปิดยังป้องกันการแก้ไขพรีเซนเทชันด้วย: เมื่อคนไม่สามารถเปิดพรีเซนเทชันได้ พวกเขาก็ไม่สามารถทำการแก้ไขหรือเปลี่ยนแปลงได้  

  **หมายเหตุ** ว่าเมื่อคุณป้องกันพรีเซนเทชันด้วยรหัสผ่านเพื่อป้องกันการเปิดไฟล์ ไฟล์พรีเซนเทชันจะถูกเข้ารหัส

## **วิธีป้องกันพรีเซนเทชันด้วยรหัสผ่านออนไลน์**

1. ไปที่หน้า [**Aspose.Slides Lock**](https://products.aspose.app/slides/th/lock) ของเรา  

   ![todo:image_alt_text](slides-lock.png)

2. คลิก **ลากหรืออัปโหลดไฟล์ของคุณ**  

3. เลือกไฟล์ที่คุณต้องการป้องกันด้วยรหัสผ่านบนคอมพิวเตอร์ของคุณ  

4. ป้อนรหัสผ่านที่คุณต้องการสำหรับการป้องกันการแก้ไข; ป้อนรหัสผ่านที่คุณต้องการสำหรับการป้องกันการดู  

5. หากคุณต้องการให้ผู้ใช้ดูพรีเซนเทชันของคุณในรูปแบบสำเนาสุดท้าย ให้ทำเครื่องหมายที่ช่องทำเครื่องหมาย **Mark as final**  

6. คลิก **PROTECT NOW.**  

7. คลิก **DOWNLOAD NOW.**

## **การป้องกันรหัสผ่านสำหรับพรีเซนเทชันใน Aspose.Slides**
**รูปแบบที่สนับสนุน**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการทำงานคล้ายกันสำหรับพรีเซนเทชันในรูปแบบต่อไปนี้:

- PPTX และ PPT - การนำเสนอ Microsoft PowerPoint
- ODP - การนำเสนอ OpenDocument
- OTP - แม่แบบการนำเสนอ OpenDocument  

**การดำเนินการที่สนับสนุน**

Aspose.Slides อนุญาตให้คุณใช้การป้องกันด้วยรหัสผ่านบนพรีเซนเทชันเพื่อป้องกันการแก้ไขในวิธีต่อไปนี้:

- การเข้ารหัสพรีเซนเทชัน
- การตั้งการป้องกันการเขียนให้กับพรีเซนเทชัน  

**การดำเนินการอื่น ๆ**

Aspose.Slides อนุญาตให้คุณทำงานอื่น ๆ ที่เกี่ยวกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสในวิธีต่อไปนี้:

- การถอดรหัสพรีเซนเทชัน; การเปิดพรีเซนเทชันที่เข้ารหัส
- การลบการเข้ารหัส; การปิดการป้องกันรหัสผ่าน
- การลบการป้องกันการเขียนจากพรีเซนเทชัน
- การดึงคุณสมบัติของพรีเซนเทชันที่เข้ารหัส
- การตรวจสอบว่าพรีเซนเทชันถูกเข้ารหัสหรือไม่
- การตรวจสอบว่าพรีเซนเทชันถูกป้องกันด้วยรหัสผ่านหรือไม่  

## **การเข้ารหัสพรีเซนเทชัน**

คุณสามารถเข้ารหัสพรีเซนเทชันโดยการตั้งรหัสผ่าน แล้วเพื่อแก้ไขพรีเซนเทชันที่ถูกล็อก ผู้ใช้ต้องให้รหัสผ่าน

เพื่อเข้ารหัสหรือป้องกันพรีเซนเทชันด้วยรหัสผ่าน คุณต้องใช้เมธอด encrypt (จาก [ProtectionManager](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager)) เพื่อกำหนดรหัสผ่านให้กับพรีเซนเทชัน คุณจะส่งรหัสผ่านไปยังเมธอด encrypt และใช้เมธอด save เพื่อบันทึกพรีเซนเทชันที่เพิ่งเข้ารหัส

ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสพรีเซนเทชัน:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **ตั้งการป้องกันการเขียนให้กับพรีเซนเทชัน**

คุณสามารถเพิ่มเครื่องหมาย “Do not modify” ลงในพรีเซนเทชันได้ วิธีนี้ทำให้คุณบอกผู้ใช้ว่าคุณไม่ต้องการให้พวกเขาแก้ไขพรีเซนเทชัน  

**หมายเหตุ** ว่ากระบวนการป้องกันการเขียนไม่ได้ทำให้พรีเซนเทชันเข้ารหัส ดังนั้นผู้ใช้—หากต้องการ—สามารถแก้ไขพรีเซนเทชันได้ แต่เมื่อต้องการบันทึกการเปลี่ยนแปลง พวกเขาต้องบันทึกเป็นไฟล์ใหม่ที่มีชื่อแตกต่าง  

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด setWriteProtection ตัวอย่างโค้ดนี้แสดงวิธีการตั้งการป้องกันการเขียนให้กับพรีเซนเทชัน:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **โหลดพรีเซนเทชันที่เข้ารหัส**

Aspose.Slides อนุญาตให้คุณโหลดไฟล์ที่เข้ารหัสโดยผ่านรหัสผ่านของไฟล์นั้น เพื่อลบการเข้ารหัสพรีเซนเทชัน คุณต้องเรียกเมธอด [RemoveEncryption](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) โดยไม่มีพารามิเตอร์ จากนั้นคุณจะต้องป้อนรหัสผ่านที่ถูกต้องเพื่อโหลดพรีเซนเทชัน  

ตัวอย่างโค้ดนี้แสดงวิธีการถอดรหัสพรีเซนเทชัน:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// ทำงานกับพรีเซนเทชันที่ถอดรหัสแล้ว
```

## **ลบการเข้ารหัสจากพรีเซนเทชัน**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านบนพรีเซนเทชันได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขพรีเซนเทชันโดยไม่มีข้อจำกัด  

เพื่อทำเช่นนั้น ให้เรียกเมธอด [RemoveEncryption](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) ตัวอย่างโค้ดนี้แสดงวิธีการลบการเข้ารหัสจากพรีเซนเทชัน:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **ลบการป้องกันการเขียนจากพรีเซนเทชัน**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้บนไฟล์พรีเซนเทชัน วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขได้ตามต้องการโดยไม่มีคำเตือนใด ๆ  

คุณสามารถลบการป้องกันการเขียนจากพรีเซนเทชันโดยใช้เมธอด [RemoveWriteProtection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) ตัวอย่างโค้ดนี้แสดงวิธีการลบการป้องกันการเขียนจากพรีเซนเทชัน:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **ดึงคุณสมบัติของพรีเซนเทชันที่เข้ารหัส**

โดยทั่วไป ผู้ใช้มักเจอปัญหาในการดึงคุณสมบัติของเอกสารจากพรีเซนเทชันที่เข้ารหัสหรือป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ทำให้คุณสามารถป้องกันพรีเซนเทชันด้วยรหัสผ่านพร้อมให้เข้าถึงคุณสมบัติของเอกสารได้  

**หมายเหตุ:** โดยค่าเริ่มต้น เมื่อ Aspose.Slides เข้ารหัสพรีเซนเทชัน คุณสมบัติของเอกสารก็จะถูกป้องกันด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติของเอกสารเข้าถึงได้แม้หลังจากการเข้ารหัส Aspose.Slides อนุญาตให้ทำเช่นนั้นได้  

หากคุณต้องการให้ผู้ใช้ยังคงเข้าถึงคุณสมบัติของพรีเซนเทชันที่เข้ารหัส ให้ส่งค่า `false` ไปยังเมธอด `set_EncryptDocumentProperties` ของ [IProtectionManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/) ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสพรีเซนเทชันพร้อมให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสาร:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **โหลดเฉพาะคุณสมบัติเอกสารจากพรีเซนเทชันที่เข้ารหัส**

เพื่อสำรวจเมตาดาต้าของพรีเซนเทชันที่เข้ารหัสโดยไม่โหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) และตั้งค่า [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) เป็น `true` ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติเอกสารที่เปิดเผยต่อสาธารณะ

ตัวอย่างโค้ดต่อไปนี้อ่านคุณสมบัติเชิงสร้างและกำหนดเองผ่าน [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_documentproperties/):

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

ขั้นตอนนี้ทำงานได้เฉพาะเมื่อคุณสมบัติเอกสารถูกตั้งค่าเป็นเปิด (ไม่เข้ารหัส) ขณะพรีเซนเทชันถูกเข้ารหัส หากคุณสมบัติเอกสารถูกเข้ารหัส การตั้งค่า `LoadOptions::set_OnlyLoadDocumentProperties` เป็น `true` จะทำให้เกิดข้อยกเว้น เนื่องจากรหัสผ่านถูกละเว้นในโหมดนี้ เพื่อเข้าถึงคุณสมบัติเอกสารที่เข้ารหัสหรือโหลดพรีเซนเทชันเต็มรูปแบบรวมสไลด์และเนื้อหาอื่น ๆ ให้ระบุรหัสผ่านที่ถูกต้องด้วย `LoadOptions::set_Password` ใน [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/)

## **ตรวจสอบว่าพรีเซนเทชันถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดพรีเซนเทชัน คุณอาจต้องการตรวจสอบและยืนยันว่าพรีเซนเทชันไม่ได้ถูกป้องกันด้วยรหัสผ่าน วิธีนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อพรีเซนเทชันที่ป้องกันด้วยรหัสผ่านถูกโหลดโดยไม่มีรหัสผ่าน  

โค้ด C++ นี้แสดงวิธีการตรวจสอบพรีเซนเทชันเพื่อดูว่าเป็นพรีเซนเทชันที่ป้องกันด้วยรหัสผ่านหรือไม่ (โดยไม่โหลดพรีเซนเทชันเอง):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **ตรวจสอบว่าพรีเซนเทชันถูกเข้ารหัสหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่าพรีเซนเทชันถูกเข้ารหัสหรือไม่ คุณสามารถใช้เมธอด [get_IsEncrypted()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) ซึ่งจะคืนค่า `true` หากพรีเซนเทชันถูกเข้ารหัส หรือ `false` หากไม่ได้เข้ารหัส  

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบว่าพรีเซนเทชันถูกเข้ารหัสหรือไม่:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **ตรวจสอบว่าพรีเซนเทชันถูกป้องกันการเขียนหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่าพรีเซนเทชันถูกป้องกันการเขียนหรือไม่ คุณสามารถใช้เมธอด [get_IsWriteProtected()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) ซึ่งจะคืนค่า `true` หากพรีเซนเทชันถูกป้องกันการเขียน หรือ `false` หากไม่ได้ป้องกัน  

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบว่าพรีเซนเทชันถูกป้องกันการเขียนหรือไม่:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **ยืนยันการใช้รหัสผ่านของพรีเซนเทชัน**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะใดในการป้องกันเอกสารพรีเซนเทชัน Aspose.Slides มีวิธีให้คุณตรวจสอบรหัสผ่าน  

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบความถูกต้องของรหัสผ่าน:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// ตรวจสอบว่า "pass" ตรงกับ
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

มันจะส่งคืน `true` หากพรีเซนเทชันถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะส่งคืน `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/th/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับวิธีการเข้ารหัสใดบ้าง?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่รวมถึงอัลกอริทึมแบบ AES เพื่อให้การรักษาความปลอดภัยของข้อมูลพรีเซนเทชันของคุณอยู่ในระดับสูง

**จะเกิดอะไรขึ้นหากใส่รหัสผ่านที่ไม่ถูกต้องเมื่อพยายามเปิดพรีเซนเทชัน?**

ระบบจะขว้างข้อยกเว้นเมื่อรหัสผ่านไม่ถูกต้อง แจ้งว่าไม่สามารถเข้าถึงพรีเซนเทชันได้ ซึ่งช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาพรีเซนเทชัน

**มีผลกระทบต่อประสิทธิภาพหรือไม่เมื่อทำงานกับพรีเซนเทชันที่ป้องกันด้วยรหัสผ่าน?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้เกิดภาระบางส่วนในระหว่างการเปิดและการบันทึก ในส่วนใหญ่ผลกระทบต่อประสิทธิภาพนั้นเล็กน้อยและไม่ส่งผลอย่างมีนัยสำคัญต่อเวลาการประมวลผลโดยรวมของงานพรีเซนเทชันของคุณ