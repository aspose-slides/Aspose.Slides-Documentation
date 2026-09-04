---
title: ป้องกันการนำเสนอด้วยรหัสผ่านใน C++
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/cpp/password-protected-presentation/
keywords:
  - การนำเสนอที่ป้องกันด้วยรหัสผ่าน
  - รหัสผ่านเปิดใช้งาน
  - เข้ารหัส PowerPoint
  - ถอดรหัส PowerPoint
  - ตรวจสอบรหัสผ่านการนำเสนอ
  - ตรวจสอบรหัสผ่านของการนำเสนอ
  - เปิดการนำเสนอที่เข้ารหัส
  - ลบการเข้ารหัส
  - PowerPoint
  - PPT
  - PPTX
  - การนำเสนอ
  - C++
  - Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิด และถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน C++ ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดใช้งานจะทำการเข้ารหัสการนำเสนอ จำเป็นต้องใช้รหัสผ่านที่ถูกต้องเพื่อโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับ.

รหัสผ่านเปิดใช้งานแตกต่างจากรหัสผ่านป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหาหรือป้องกันไม่ให้การนำเสนอถูกโหลด เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ดูที่ [Write-Protect Presentations](/slides/th/cpp/write-protected-presentation/).

ขั้นตอนการทำงานด้านล่างใช้กับการนำเสนอทั้งในรูปแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมแบบไฟล์และสตรีมมีความสำคัญ.

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิดใช้งาน**

ใช้ [IProtectionManager::Encrypt](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/encrypt/) เพื่อตั้งรหัสผ่านเปิดใช้งาน จากนั้นใช้ [IPresentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/save/) เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัส.

ตัวอย่างต่อไปนี้จะเข้ารหัสการนำเสนอ PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าคุณสมบัติเอกสารเป็นสาธารณะ**

โดยค่าเริ่มต้น Aspose.Slides จะรวมคุณสมบัติเอกสารในการเข้ารหัสการนำเสนอ [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) ควบคุมพฤติกรรมนี้แยกจากการเข้ารหัสเนื้อหาไสลด์ ส่งค่า `false` ไปยังเมธอดนี้ก่อนเรียก [IProtectionManager::Encrypt](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/encrypt/) เมื่อระบบจัดทำดัชนี การจัดประเภท การค้นหา หรือการจัดการเอกสารต้องอ่านข้อมูลเมตาโดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน

ตัวอย่างต่อไปนี้สร้างการนำเสนอ PPTX ที่ถูกเข้ารหัสโดยยังคงคุณสมบัติเอกสารในตัวเป็นสาธารณะ:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

การส่งค่า `false` ไปยัง `set_EncryptDocumentProperties` ไม่ได้ทำให้สไลด์ มาสเตอร์ เลเอาต์ รูปร่าง สื่อ หรือเนื้อหาการนำเสนออื่น ๆ เป็นสาธารณะ จะส่งผลเฉพาะคุณสมบัติเอกสารเท่านั้น หากต้องการอ่านคุณสมบัติเหล่านั้นโดยไม่โหลดเนื้อหาที่เข้ารหัส ดูที่ [Manage Presentation Properties](/slides/th/cpp/presentation-properties/).

## **โหลดการนำเสนอที่เข้ารหัส**

กำหนดค่า [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) ให้เป็นรหัสผ่านเปิดใช้งานและส่งตัวเลือกนั้นไปยัง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เมื่อโหลดไฟล์ การโหลดจะล้มเหลือเมื่อจำเป็นต้องใช้รหัสผ่านเปิดใช้งานแต่รหัสที่ให้มาหายไปหรือไม่ถูกต้อง.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
```

## **ลบการเข้ารหัสออกจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิดใช้งาน เรียกใช้ [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/removeencryption/) แล้วบันทึกผลลัพธ์ การนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **ตรวจสอบรหัสผ่านเปิดใช้งานก่อนโหลด**

ใช้ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) เพื่อรับ [IPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ ตรวจสอบ [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกัน ให้ตรวจสอบค่าที่ให้มาด้วย [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **ขั้นตอนการทำงานด้วยไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดใช้งานสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) แล้วโหลดการนำเสนอเต็มรูปแบบ:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **ขั้นตอนการทำงานด้วยสตรีม**

โอเวอร์โหลดสตรีมของ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ให้ขั้นตอนการทำงานเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถเลื่อนได้ก่อนโหลดการนำเสนอเต็มรูปแบบจากสตรีมนั้น.

ตัวอย่างต่อไปนี้ใช้ไฟล์ PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **ค่าที่คืนจาก CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/checkpassword/) จะคืนค่า `true` ก็ต่อเมื่อการนำเสนอมีรหัสผ่านเปิดใช้งานและรหัสที่ให้มาถูกต้อง จะคืนค่า `false` ในกรณีต่อไปนี้:
- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านเปิดใช้งาน.
- รหัสผ่านที่ให้มาเป็นค่า null หรือว่าง.

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอ PPT และ PPTX.

## **ตรวจสอบว่าการนำเข้าโหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) เพื่อยืนยันว่าการนำเสนอเดิมถูกเข้ารหัส เพื่อค้นหาการป้องกันด้วยรหัสผ่านเปิดใช้งานก่อนโหลด ให้ใช้ `IPresentationInfo::get_IsPasswordProtected` ตามที่แสดงข้างต้น.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **คำแนะนำด้านความปลอดภัย**

{{% alert color="warning" title="Security" %}}
ห้ามบันทึกรหัสผ่านเปิดใช้งานหรือนำไปใส่ในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเท่าที่ต้องการเท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อต้องโหลดการนำเสดด่วน.

คุณสมบัติเอกสารสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น และค่าที่กำหนดเองแม้ว่าข้อมูลการนำเสนอจะถูกเข้ารหัส กรณีต้องการรักษาความลับของเมตาดาต้าควรเข้ารหัสพร้อมกับการนำเสนอ การทำให้คุณสมบัติเป็นสาธารณะควรเป็นการตัดสินใจอย่างชัดเจนและทำเฉพาะเมื่อระบบต้องทำการจัดทำดัชนี, จัดประเภท, ค้นหา หรือจัดการไฟล์โดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน.
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock).
2. เลือกหรืออัปโหลดการนำเสนอ.
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู.
4. หากต้องการสามารถป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข.
5. ทำการป้องกันและดาวน์โหลดไฟล์ที่ได้.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/th/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**อะไรคือความแตกต่างระหว่างรหัสผ่านเปิดใช้งานและรหัสผ่านป้องกันการเขียน?**

รหัสผ่านเปิดใช้งานจะทำการเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา ส่วนรหัสผ่านป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่ทำการเข้ารหัสเนื้อหา.

**ฉันสามารถตรวจสอบรหัสผ่านเปิดใช้งานโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ จากนั้นดึงข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดใช้งานหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ.

**แอปพลิเคชันสามารถอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิดใช้งานได้หรือไม่?**

ได้ แต่เฉพาะเมื่อการนำเสนอถูกเข้ารหัสด้วย `set_EncryptDocumentProperties(false)` แอปพลิเคชันต้องใช้โหมดการโหลดเฉพาะคุณสมบัติเอกสารตามที่อธิบายใน [Manage Presentation Properties](/slides/th/cpp/presentation-properties/).

**ขั้นตอนการตรวจสอบรหัสผ่านสนับสนุนทั้ง PPT และ PPTX หรือไม่?**

ได้ การตรวจจับและตรวจสอบรหัสผ่านด้วยไฟล์พาธและสตรีมทำงานเช่นเดียวกันสำหรับการนำเสนอ PPT และ PPTX.