---
title: การป้องกันการนำเสนอด้วยรหัสผ่านใน C++
linktitle: การป้องกันรหัสผ่าน
type: docs
weight: 20
url: /th/cpp/password-protected-presentation/
keywords:
- การนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านการเปิด
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบรหัสผ่านการนำเสนอ
- ตรวจรหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- C++
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิดและถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน C++ ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านการเปิดใช้เพื่อเข้ารหัสการนำเสนอ รหัสผ่านที่ถูกต้องจำเป็นต้องใช้ในการโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับ

รหัสผ่านการเปิดแตกต่างจากรหัสผ่านการป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหาหรือป้องกันการโหลดการนำเสนอ เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ดูที่ [Write-Protect Presentations](/slides/th/cpp/write-protected-presentation/).

ขั้นตอนการทำงานด้านล่างนี้ใช้ได้กับการนำเสนอทั้งในรูปแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมตามไฟล์และสตรีมมีความสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านการเปิด**

ใช้ [IProtectionManager::Encrypt](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/encrypt/) เพื่อกำหนดรหัสผ่านการเปิด จากนั้นใช้ [IPresentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/save/) เพื่อบันทึกการนำเสนอที่เข้ารหัส

ตัวอย่างต่อไปนี้ทำการเข้ารหัสการนำเสนอ PPTX:

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

## **โหลดการนำเสนอที่เข้ารหัส**

ตั้งค่า [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) ให้เป็นรหัสผ่านการเปิดและส่งตัวเลือกไปยัง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เมื่อโหลดไฟล์ การโหลดจะล้มเหลือเมื่อต้องการรหัสผ่านการเปิดแต่รหัสผ่านที่ให้มาขาดหายหรือไม่ถูกต้อง

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

โหลดการนำเสนอพร้อมรหัสผ่านการเปิดของมัน เรียก [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/removeencryption/) แล้วบันทึกผลลัพธ์ การนำเสนอที่บันทึกไว้จึงสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

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

## **ตรวจสอบรหัสผ่านการเปิดก่อนการโหลด**

ใช้ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) เพื่อรับ [IPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ ตรวจสอบ [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) ก่อนทำการขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกันอยู่ ให้ตรวจสอบค่าที่ให้มาด้วย [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/checkpassword/)

### **กระบวนการทำงานแบบไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านการเปิดสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) แล้วโหลดการนำเสนอเต็มรูปแบบ:

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

### **กระบวนการทำงานแบบสตรีม**

อัลโหลดแบบสตรีมของ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ให้กระบวนการทำงานเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถเลื่อนได้ก่อนโหลดการนำเสนอเต็มรูปแบบจากสตรีมนั้น

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

### **ค่าที่ส่งกลับของ CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/checkpassword/) คืนค่า `true` เฉพาะเมื่อการนำเสนอมีรหัสผ่านการเปิดและรหัสผ่านที่ให้ถูกต้อง จะคืนค่า `false` ในแต่ละกรณีต่อไปนี้:

- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านการเปิด.
- รหัสผ่านที่ให้เป็นค่า null หรือว่างเปล่า.

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอ PPT และ PPTX

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) เพื่อยืนยันว่าการนำเสนอแหล่งที่มาถูกเข้ารหัส เพื่อค้นพบการป้องกันรหัสผ่านการเปิดก่อนการโหลด ให้ใช้ `IPresentationInfo::get_IsPasswordProtected` ตามที่แสดงข้างต้น

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
ห้ามบันทึกรหัสผ่านการเปิดในบันทึกหรือรวมไว้ในข้อความวินิจฉัย หลีกเลี่ยงการพยายามตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเพียงเท่าที่จำเป็น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อต้องโหลดการนำเสนอทันที
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
2. เลือกหรืออัปโหลดการนำเสนอ
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู
4. หากต้องการให้ป้อนรหัสผ่านแยกสำหรับการป้องกันการแก้ไข
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/th/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**What is the difference between an opening password and a write-protection password?**

รหัสผ่านการเปิดเข้ารหัสการนำเสนอและจำเป็นต้องใช้ในการโหลดเนื้อหา ส่วนรหัสผ่านการป้องกันการเขียนจำกัดการแก้ไขโดยไม่ต้องเข้ารหัสเนื้อหา

**Can I validate an opening password without loading all slides?**

ได้ สามารถรับข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันรหัสผ่านการเปิดหรือไม่ และยืนยันรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ

**Do the password-checking workflows support both PPT and PPTX?**

ใช่ กระบวนการตรวจสอบและตรวจสอบรหัสผ่านทั้งแบบไฟล์พาธและแบบสตรีมทำงานเช่นเดียวกันสำหรับการนำเสนอ PPT และ PPTX