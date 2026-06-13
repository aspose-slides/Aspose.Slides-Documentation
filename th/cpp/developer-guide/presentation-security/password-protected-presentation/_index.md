---
title: ปกป้องงานนำเสนอด้วยรหัสผ่านใน C++
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/cpp/password-protected-presentation/
keywords:
- ล็อก PowerPoint
- ล็อกงานนำเสนอ
- ปลดล็อก PowerPoint
- ปลดล็อกงานนำเสนอ
- ปกป้อง PowerPoint
- ปกป้องงานนำเสนอ
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสงานนำเสนอ
- ถอดรหัส PowerPoint
- ถอดรหัสงานนำเสนอ
- การป้องกันการเขียน
- ความปลอดภัย PowerPoint
- ความปลอดภัยของงานนำเสนอ
- ลบรหัสผ่าน
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดการทำงานของรหัสผ่าน
- ปิดการทำงานของการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกงานนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านอย่างง่ายดายด้วย Aspose.Slides สำหรับ C++. ปกป้องงานนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณใช้การป้องกันด้วยรหัสผ่านสำหรับงานนำเสนอ หมายความว่าคุณกำหนดรหัสผ่านซึ่งบังคับใช้ข้อจำกัดบางอย่างบนงานนำเสนอ เพื่อเอาข้อจำกัดออก จำเป็นต้องใส่รหัสผ่าน งานนำเสนอที่มีการป้องกันด้วยรหัสผ่านถือเป็นงานนำเสนอที่ถูกล็อก

ทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนงานนำเสนอได้:

- **การแก้ไข**

  หากคุณต้องการให้เฉพาะผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขงานนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนต่าง ๆ แก้ไข เปลี่ยนแปลง หรือคัดลอกสิ่งต่าง ๆ ในงานนำเสนอของคุณ (เว้นแต่พวกเขาจะให้รหัสผ่าน) 

  อย่างไรก็ตาม ในกรณีนี้ แม้ไม่มีรหัสผ่าน ผู้ใช้ก็ยังสามารถเข้าถึงเอกสารของคุณและเปิดได้ ในโหมดอ่านอย่างเดียว ผู้ใช้สามารถดูเนื้อหา หรือสิ่งต่าง ๆ — ลิงก์, การเคลื่อนไหว, เอฟเฟกต์ และอื่น ๆ — ภายในงานนำเสนอของคุณ แต่ไม่สามารถคัดลอกรายการหรือบันทึกงานนำเสนอได้ 

- **การเปิด**

  หากคุณต้องการให้เฉพาะผู้ใช้บางคนเท่านั้นที่สามารถเปิดงานนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนดูเนื้อหาของงานนำเสนอของคุณเลย (เว้นแต่พวกเขาจะให้รหัสผ่าน) 

  โดยเทคนิค ข้อจำกัดการเปิดยังป้องกันไม่ให้ผู้ใช้แก้ไขงานนำเสนอของคุณด้วย: เมื่อคนไม่สามารถเปิดงานนำเสนอได้ พวกเขาไม่สามารถทำการแก้ไขหรือเปลี่ยนแปลงได้  

  **หมายเหตุ**ว่เมื่อคุณป้องกันงานนำเสนอด้วยรหัสผ่านเพื่อป้องกันการเปิดไฟล์งานนำเสนอจะถูกเข้ารหัส

## **วิธีป้องกันงานนำเสนอด้วยรหัสผ่านออนไลน์**

1. ไปที่หน้า [**Aspose.Slides Lock**](https://products.aspose.app/slides/th/lock) ของเรา. 

   ![todo:image_alt_text](slides-lock.png)

2. คลิก **วางหรืออัปโหลดไฟล์ของคุณ**.

3. เลือกไฟล์ที่คุณต้องการป้องกันด้วยรหัสผ่านบนคอมพิวเตอร์ของคุณ. 

4. ใส่รหัสผ่านที่คุณต้องการสำหรับการป้องกันการแก้ไข; ใส่รหัสผ่านที่คุณต้องการสำหรับการป้องกันการดู. 

5. หากคุณต้องการให้ผู้ใช้เห็นงานนำเสนอของคุณเป็นสำเนาสุดท้าย ให้ทำเครื่องหมายที่ช่องเลือก **Mark as final**.

6. คลิก **PROTECT NOW.** 

7. คลิก **DOWNLOAD NOW.**

## **การป้องกันด้วยรหัสผ่านสำหรับงานนำเสนอใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการที่คล้ายกันสำหรับงานนำเสนอในรูปแบบต่อไปนี้: 

- PPTX และ PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**การดำเนินการที่รองรับ**

Aspose.Slides อนุญาตให้คุณใช้การป้องกันด้วยรหัสผ่านบนงานนำเสนอเพื่อป้องกันการแก้ไขในวิธีต่อไปนี้:

- การเข้ารหัสงานนำเสนอ
- การตั้งการป้องกันการเขียนให้กับงานนำเสนอ

**การดำเนินการอื่น ๆ**

Aspose.Slides อนุญาตให้คุณทำงานอื่น ๆ ที่เกี่ยวกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสในวิธีต่อไปนี้:

- การถอดรหัสงานนำเสนอ; เปิดงานนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; ปิดการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากงานนำเสนอ
- การรับคุณสมบัติของงานนำเสนอที่เข้ารหัส
- การตรวจสอบว่ามีการเข้ารหัสงานนำเสนอหรือไม่
- การตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่.

## **การเข้ารหัสงานนำเสนอ**

คุณสามารถเข้ารหัสงานนำเสนอโดยการตั้งรหัสผ่าน จากนั้นเพื่อแก้ไขงานนำเสนอที่ถูกล็อก ผู้ใช้ต้องให้รหัสผ่าน

เพื่อเข้ารหัสหรือป้องกันงานนำimientoด้วยรหัสผ่าน คุณต้องใช้เมธอด encrypt (จาก [ProtectionManager](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager)) เพื่อกำหนดรหัสผ่านให้กับงานนำเสนอ คุณจะส่งรหัสผ่านไปยังเมธอด encrypt แล้วใช้เมธอด save เพื่อบันทึกงานนำเสนอที่เพิ่งถูกเข้ารหัส

This sample code shows you how to encrypt a presentation:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **ตั้งการป้องกันการเขียนให้กับงานนำเสนอ** 

คุณสามารถเพิ่มเครื่องหมาย “Do not modify” ลงในงานนำเสนอได้ วิธีนี้ทำให้คุณบอกผู้ใช้ว่าคุณไม่ต้องการให้พวกเขาแก้ไขงานนำเสนอ  

**หมายเหตุ**ว่ากระบวนการป้องกันการเขียนไม่ได้เข้ารหัสงานนำเสนอ ดังนั้นผู้ใช้—หากต้องการจริง ๆ—สามารถแก้ไขงานนำเสนอได้ แต่เพื่อบันทึกการเปลี่ยนแปลง พวกเขาต้องสร้างงานนำเสนอด้วยชื่ออื่น 

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด setWriteProtection ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งการป้องกันการเขียนให้กับงานนำเสนอ:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **โหลดงานนำเสนอที่เข้ารหัส**

Aspose.Slides ให้คุณโหลดไฟล์ที่เข้ารหัสโดยส่งรหัสผ่านของไฟล์นั้น เพื่อถอดรหัสงานนำเสนอคุณต้องเรียกเมธอด [RemoveEncryption](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) โดยไม่มีพารามิเตอร์ จากนั้นคุณจะต้องใส่รหัสผ่านที่ถูกต้องเพื่อโหลดงานนำเสนอ 

This sample code shows you how to decrypt a presentation: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว
```

## **ลบการเข้ารหัสจากงานนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านบนงานนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขงานนำเสนอโดยไม่มีข้อจำกัด 

เพื่อลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน คุณต้องเรียกเมธอด [RemoveEncryption](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีลบการเข้ารหัสจากงานนำเสนอ:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **ลบการป้องกันการเขียนจากงานนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้บนไฟล์งานนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขตามต้องการ—และจะไม่มีการเตือนใด ๆ เมื่อทำเช่นนั้น  

คุณสามารถลบการป้องกันการเขียนจากงานนำเสนอโดยใช้เมธอด [RemoveWriteProtection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีลบการป้องกันการเขียนจากงานนำเสนอ:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **รับคุณสมบัติของงานนำเสนอที่เข้ารหัส**

โดยทั่วไปผู้ใช้มักประสบปัญหาในการรับคุณสมบัติของเอกสารจากงานนำเสนอที่เข้ารหัสหรือป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีเมคานิซัมที่อนุญาตให้คุณป้องกันงานนำเสนอด้วยรหัสผ่านพร้อมยังคงให้ผู้ใช้สามารถเข้าถึงคุณสมบัติของงานนำเสนอนั้นได้  

**หมายเหตุ**ว่าเมื่อ Aspose.Slides เข้ารหัสงานนำเสนอ คุณสมบัติของเอกสารงานนำเสนอก็จะถูกป้องกันด้วยรหัสผ่านโดยค่าเริ่มต้นด้วย แต่หากคุณต้องการทำให้คุณสมบัติของงานนำเสนอสามารถเข้าถึงได้ (แม้หลังจากงานนำเสนอถูกเข้ารหัส) Aspose.Slides อนุญาตให้ทำได้โดยตรง  

หากต้องการให้ผู้ใช้ยังคงสามารถเข้าถึงคุณสมบัติของงานนำเสนอที่คุณเข้ารหัสได้ คุณสามารถส่งค่า `true` ไปยังเมธอด [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเข้ารหัสงานนำเสนอพร้อมให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสาร:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดงานนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่างานนำเสนอไม่ได้ถูกป้องกันด้วยรหัสผ่าน วิธีนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อโหลดงานนำเสนอที่ถูกป้องกันด้วยรหัสผ่านโดยไม่มีรหัสผ่าน  

This C++ code shows you how to examine a presentation to see if it is password protected (without loading the presentation itself):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **ตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำงานนี้คุณสามารถใช้เมธอด [get_IsEncrypted()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) ซึ่งจะคืนค่า `true` หากงานนำเสนอถูกเข้ารหัส หรือ `false` หากไม่ถูกเข้ารหัส  

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำงานนี้คุณสามารถใช้เมธอด [get_IsWriteProtected()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) ซึ่งจะคืนค่า `true` หากงานนำเสนอถูกป้องกันการเขียน หรือ `false` หากไม่ได้ถูกป้องกัน  

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **ตรวจสอบการใช้รหัสผ่านของงานนำเสนอ**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อป้องกันเอกสารงานนำเสนอหรือไม่ Aspose.Slides ให้วิธีการตรวจสอบรหัสผ่าน  

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// ตรวจสอบว่า "pass" ตรงกับ
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

It returns `true` if the presentation has been encrypted with the specified password. Otherwise, it returns `false`. 

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [Digital Signature in PowerPoint](/slides/th/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีการเข้ารหัสที่ Aspose.Slides รองรับคืออะไร?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่รวมถึงอัลกอริธึมแบบ AES เพื่อให้มั่นใจว่าข้อมูลงานนำเสนอของคุณมีความปลอดภัยระดับสูง

**เกิดอะไรขึ้นหากใส่รหัสผ่านไม่ถูกต้องเมื่อพยายามเปิดงานนำเสนอ?**

จะเกิดข้อยกเว้นพร้อมแจ้งว่าการเข้าถึงงานนำเสนอถูกปฏิเสธ ซึ่งช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาของงานนำเสนอ

**มีผลกระทบต่อประสิทธิภาพหรือไม่เมื่อทำงานกับงานนำเสนอที่ป้องกันด้วยรหัสผ่าน?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้เกิดภาระเล็กน้อยในขณะเปิดและบันทึก อย่างไรก็ตามในหลายกรณีผลกระทบต่อประสิทธิภาพจะน้อยและไม่ส่งผลอย่างมีนัยสำคัญต่อระยะเวลาการประมวลผลงานนำเสนอของคุณ