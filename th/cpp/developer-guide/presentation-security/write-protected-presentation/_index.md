---
title: การป้องกันการเขียนพรีเซนเทชันใน C++
linktitle: การป้องกันการเขียน
type: docs
weight: 25
url: /th/cpp/write-protected-presentation/
keywords:
- การป้องกันการเขียน
- การป้องกันการเขียน PowerPoint
- รหัสผ่านเพื่อแก้ไข
- จำกัดการแก้ไขพรีเซนเทชัน
- ลบการป้องกันการเขียน
- ตรวจสอบความถูกต้องของรหัสผ่านการแก้ไข
- PowerPoint
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "ตั้งค่า, ตรวจจับ, ตรวจสอบความถูกต้อง และลบรหัสผ่านการป้องกันการเขียนในพรีเซนเทชัน PowerPoint PPT และ PPTX โดยใช้ Aspose.Slides สำหรับ C++."
---
## **Introduction**

รหัสผ่านการป้องกันการเขียนจำกัดการแก้ไขพรีเซนเทชัน แต่ไม่ได้เข้ารหัสเนื้อหา ผู้ใช้สามารถโหลดและดูพรีเซนเทชันที่ป้องกันการเขียนได้โดยไม่ต้องใช้รหัสผ่าน ขึ้นอยู่กับแอปพลิเคชัน พวกเขาอาจสามารถแก้ไขเนื้อหาและบันทึกเป็นชื่ออื่นได้ ดังนั้นการป้องกันการเขียนจึงไม่ควรถือเป็นกลไกความลับ

รหัสผ่านการเปิดใช้งานทำหน้าที่ต่างออกไป: มันเข้ารหัสพรีเซนเทชันและจำเป็นต่อการโหลดเนื้อหา หากต้องการเข้ารหัสพรีเซนเทชันหรือยืนยันรหัสผ่านการเปิดใช้งาน ดูที่ [Password-Protect Presentations](/slides/th/cpp/password-protected-presentation/).

ขั้นตอนการทำงานในบทความนี้ใช้ได้กับพรีเซนเทชันทั้งแบบ PPT และ PPTX ตัวอย่างใช้ไฟล์ PPTX; เมื่อบันทึกเป็น PPT ให้ใช้ส่วนขยาย `.ppt` และรูปแบบการบันทึก PPT ที่สอดคล้องกัน

## **กำหนดการป้องกันการเขียนบนพรีเซนเทชัน**

ใช้ [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) เพื่อกำหนดรหัสผ่านสำหรับแก้ไขพรีเซนเทชัน การบันทึกพรีเซนเทชันจะทำให้การตั้งค่าการป้องกันคงอยู่

ตัวอย่างต่อไปนี้กำหนดการป้องกันการเขียนบนพรีเซนเทชัน PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **โหลดพรีเซนเทชันที่ป้องกันการเขียน**

เนื่องจากการป้องกันการเขียนไม่ได้เข้ารหัสเนื้อหาพรีเซนเทชัน ไม่จำเป็นต้องใช้รหัสผ่านเพื่อโหลดพรีเซนเทชัน รหัสผ่านมีความสำคัญเฉพาะเมื่อทำการตรวจสอบสิทธิ์การแก้ไขพรีเซนเทชันที่ถูกป้องกัน

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

อย่าส่งรหัสผ่านการป้องกันการเขียนไปที่ [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/). คุณสมบัตินี้รับรหัสผ่านการเปิดใช้งานสำหรับเนื้อหาที่เข้ารหัส หากพรีเซนเทชันมีประเภทการป้องกันทั้งสอง ให้กำหนดรหัสผ่านการเปิดใช้งานเพื่อโหลดและจัดการรหัสผ่านการป้องกันการเขียนแยกต่างหาก

## **ลบการป้องกันการเขียนจากพรีเซนเทชัน**

ใช้ [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) เพื่อลบการจำกัดการแก้ไข จากนั้นบันทึกพรีเซนเทชัน

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **ตรวจสอบว่าพรีเซนเทชันถูกป้องกันการเขียนหรือไม่**

เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) แบบเต็ม ให้เรียก [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) และตรวจสอบ [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). คุณสมบัตินี้ใช้ [NullableBool](https://reference.aspose.com/slides/th/cpp/aspose.slides/nullablebool/) และคืนค่า `NullableBool::True` เมื่อพบการป้องกันการเขียน

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

การ overload แบบสตรีมของ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ให้ข้อมูลเดียวกันสำหรับพรีเซนเทชันที่ส่งเป็นสตรีม

## **ตรวจสอบรหัสผ่านการป้องกันการเขียน**

ใช้ [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) เพื่อตรวจสอบรหัสผ่านการแก้ไขโดยไม่ต้องโหลดพรีเซนเทชันเต็ม ตรวจสอบ [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) ก่อนเพื่อให้แอปพลิเคชันร้องขอหรือยืนยันรหัสผ่านก็ต่อเมื่อมีการป้องกันการเขียน

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) ตรวจสอบเฉพาะรหัสผ่านการป้องกันการเขียนเท่านั้น ไม่ตรวจสอบรหัสผ่านการเปิดใช้งานหรือพิจารณาว่าเนื้อหาที่เข้ารหัสสามารถโหลดได้หรือไม่ ในทางกลับกัน [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/checkpassword/) ตรวจสอบเฉพาะรหัสผ่านการเปิดใช้งาน หากพรีเซนเทชันเต็มถูกโหลดแล้ว [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) จะให้การตรวจสอบการป้องกันการเขียนที่เทียบเท่าผ่านผู้จัดการการป้องกัน

ในแอปพลิเคชันที่ใช้งานจริง อย่าบันทึกรหัสผ่านในบันทึกหรือใส่ไว้ในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำซ้อนโดยไม่จำเป็น และเก็บรหัสผ่านในหน่วยความจำเฉพาะช่วงที่ต้องใช้เท่านั้น

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [การป้องกันด้วยรหัสผ่านของพรีเซนเทชัน](/slides/th/cpp/password-protected-presentation/)
- [พรีเซนเทชันแบบอ่านอย่างเดียว](/slides/th/cpp/read-only-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การป้องกันการเขียนเข้ารหัสพรีเซนเทชันหรือไม่?**

ไม่. มันจำกัดการแก้ไขแต่ยังทำให้เนื้อหาพรีเซนเทชันสามารถโหลดและดูได้

**จำเป็นต้องใช้รหัสผ่านการป้องกันการเขียนเพื่อเปิดพรีเซนเทชันหรือไม่?**

ไม่. จำเป็นต้องใช้รหัสผ่านการเปิดใช้งานเท่านั้นเพื่อโหลดเนื้อหาพรีเซนเทชันที่เข้ารหัส

**พรีเซนเทชันสามารถมีรหัสผ่านการเปิดใช้งานและรหัสผ่านการป้องกันการเขียนพร้อมกันได้หรือไม่?**

ได้. ให้กำหนดรหัสผ่านการเปิดใช้งานผ่านตัวเลือกการโหลดเพื่อเปิดพรีเซนเทชันที่เข้ารหัส และตรวจสอบรหัสผ่านการป้องกันการเขียนแยกต่างหากเมื่อจำเป็นต้องได้รับสิทธิ์การแก้ไข