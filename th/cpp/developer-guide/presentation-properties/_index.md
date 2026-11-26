---
title: จัดการคุณสมบัติงานนำเสนอใน C++
linktitle: คุณสมบัติงานนำเสนอ
type: docs
weight: 70
url: /th/cpp/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการพิสูจน์อักษร
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides สำหรับ C++ และปรับกระบวนการค้นหา การสร้างแบรนด์ และการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณให้เป็นระเบียบ."
---
## **บทนำ**

Aspose.Slides for C++ รองรับ **built-in** และ **custom** คุณสมบัติเอกสาร ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาดาต้างานนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าแบบกำหนดโดยผู้ใช้

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติเอกสารงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) อินสแตนซ์ของอินเทอร์เฟซนี้จะถูกคืนโดย [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมตาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกรายการนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลเชิงบรรยายควบคู่กับเนื้อหางานนำเสนอ พวกมันแบ่งออกเป็นสองประเภท:

- **Built-in properties** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่กำหนดโดยผู้ใช้

Aspose.Slides for C++ ให้การเข้าถึงทั้งสองประเภท ใน PowerPoint ให้ไปที่ **File → Info → Properties → Advanced Properties** เพื่อดูเมตาดาต้าเอกสาร ไดอะล็อกจะจัดข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติกำหนดโดยผู้ใช้

## **อ่านคุณสมบัตสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านการเปิดปกติจะปกป้องทั้งเนื้อหาและคุณสมบัติเอกสาร เมื่อทำการเข้ารหัสงานนำเสนอโดยส่ง `false` ไปยัง [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถส่ง `true` ไปยัง [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) เพื่ออ่านเมตาดาต้าสาธารณะโดยไม่ต้องระบุรหัสผ่านการเปิด

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ถอดรหัสอะไรเลย หากคุณสมบัติล้วนถูกเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้เข้ารหัส ตัวเลือกจะถูกละเลยและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างนี้ต้องการงานนำเสนอที่เข้ารหัสโดยคุณสมบัติเอกสารยังคงเป็นสาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) แล้วอ่านคุณสมบัติตามแบบ built-in ผ่าน [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และวัตถุอื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) ก่อนทำการดำเนินการที่ต้องการโมเดลวัตถุของงานนำเสนอทั้งหมด

{{% alert color="warning" title="Security" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, เรื่อง, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง ให้เข้ารหัสคุณสมบัติที่ละเอียดอ่อนพร้อมกับงานนำเสนอ ปล่อยให้เป็นสาธารณะเฉพาะเมื่อระบบการจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบการจัดการเอกสารต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดโดยส่ง `true` ไปยัง [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากวัตถุที่มีเมตาดาต้า‑เฉพาะได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านการเปิดที่ถูกต้องและการโหลดเต็มรูปแบบ

ตัวอย่างนี้ต้องการงานนำเสนอ PPTX ที่เข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสผ่านการเปิดที่ทราบ มันเปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), อัปเดตคุณสมบัติ built‑in สาธารณะ, แล้วบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะอีกครั้งโดยไม่ใช้รหัสผ่านเพื่อยืนยันค่าที่ใหม่:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหางานนำเสนอ ต้องถือว่าคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑เท่านั้น

## **เข้าถึงคุณสมบัติ Built‑in**

อินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) เปิดเผยเมตาดาต้า built‑in ผ่าน getter แบบพิมพ์, รวมถึง [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/), และ [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่บันทึกไว้ไปที่คอนโซล ค่าต่าง ๆ ขึ้นอยู่กับงานนำเข้าบางฟิลด์อาจว่างเปล่า

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

### **รายงานหมายเลขการแก้ไขและเวลาแก้ไข**

ใช้ [GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) และ [ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่าน [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) ของแต่ละไฟล์โดยไม่ต้องโหลดสไลด์เพื่อแก้ไข ตัวอย่างนี้พิมพ์หนึ่งแถวต่อไฟล์ PPTX ในโฟลเดอร์ `presentations` รูปแบบ `c` มาตรฐานจะรวมจำนวนวันเมื่อเวลาแก้ไขที่บันทึกได้ถึง 24 ชั่วโมง

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

สำหรับงานนำเสนอที่บันทึกเวลาการแก้ไขไว้ 1 วัน 2 ชั่วโมง 5 นาที รายงานจะมีลักษณะดังนี้:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) อ่านค่ามีเทาที่แอปพลิเคชันสามารถเปลี่ยนแปลงด้วย [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/). ค่านี้เพียงอย่างเดียวไม่สามารถระบุจำนวนครั้งที่งานนำเสนอถูกบันทึกหรือสังเคราะห์ประวัติรุ่นได้

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) คืนค่าระยะเวลาการแก้ไขที่บันทึกในไฟล์ ค่า `00:00:00` หมายถึงระยะเวลาที่เก็บเป็นศูนย์ งานนำเสนออาจยังถูกแก้ไขอยู่

## **แก้ไขคุณสมบัติ Built‑in**

เพื่ออัปเดตเมตาดาต้า built‑in ให้ใช้ setter บนวัตถุที่คืนจาก [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่, เรียกใช้ [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), และ [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). PPTX ที่บันทึกจะมีเมตาดาต้าใหม่

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **จัดการ Hyperlink Base**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) อ่านค่าฐานระดับเอกสารสำหรับไฮเปอร์ลิงก์สัมพัทธ์ สิ่งนี้มีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่ลิงก์ไปยังตำแหน่งอื่น มันแยกจาก [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่เก็บไว้หรือเปลี่ยนปลายทางแบบสัมบูรณ์

ตัวอย่างนี้ต้องการงานนำเสนอที่มีลิงก์สัมพัทธ์ เช่น `target.html`, และลิงก์สัมบูรณ์ เช่น `https://example.org/absolute.html`. มันอ่านฐานที่มีอยู่, กำหนดฐานใหม่ด้วย [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อเช็คค่า จากนั้นล้างฐานด้วย `u""` และตรวจสอบค่าว่างในไฟล์ที่บันทึกแยกต่างหาก แทนที่ฐานตัวอย่างด้วยตำแหน่งไฟล์ที่ลิงก์ของคุณตั้งอยู่

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

ข้อความตรวจสอบสองข้อความควรพิมพ์ `True`. การล้างฐานจะไม่กระทบที่อยู่ไฮเปอร์ลิงก์แต่ละรายการ

ลิงก์สัมพัทธ์ `target.pptx` เปิด `old/target.pptx` เมื่ ฐานชี้ไปที่โฟลเดอร์ `old`. หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new`, 保存และเปิดงานนำเสนออีกครั้ง ลิงก์เดียวกันจะเปิด `new/target.pptx`. ลิงก์สัมบูรณ์จะยังคงเปิดไฟล์เดิม ทดสอบลิงก์สัมพัทธ์ของคุณใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **เพิ่มคุณสมบัติงานนำเสนอแบบ Custom**

คุณสมบัติ Custom เก็บเมตาดาต้าที่ไม่มีฟิลด์ built‑in ที่สอดคล้องกัน [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) ให้คุณกำหนดค่าโดยชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มค่า‑ข้อความสองค่าและค่าเวอร์ชันเลขจำนวนเต็ม, แล้วบันทึกงานนำเสนอด้วย [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). การกำหนดค่าซ้ำให้กับชื่อที่มีอยู่จะแทนที่ค่าของคุณสมบัตินั้น

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติ Custom และใช้ [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) เพื่อวนลูปผ่านมัน [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) รับดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้โดย [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) และ [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับของแต่ละรายการ, แทนที่ค่าทั้งหมดด้วยสตริงลำดับเลขโดยไม่คำนึงถึงชนิดเดิม, แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติ Custom ลูปจะไม่ทำการเปลี่ยนแปลงใด ๆ

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Live Example**

ลองแอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติ built‑in ออกจากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built‑in เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**ถ้าฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว จะเกิดอะไรขึ้น?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่าใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัตโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอทั้งหมดได้หรือไม่?**

ได้ ใช้ [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) แล้วตามด้วย [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสารที่จัดเก็บโดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ดูตัวอย่างการรายงานแบบครบถ้วนและข้อจำกัดเฉพาะรูปแบบได้ใน [Build a Lightweight Presentation Inventory](/slides/th/cpp/examine-presentation/)

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ได้ใช้รหัสผ่านการเปิดได้หรือไม่?**

ได้ งานนำเสนอจะต้องถูกเข้ารหัสโดยส่ง `false` ไปยัง [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) และต้องถูกโหลดโดยส่ง `true` ไปยัง [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/)

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมดเอกสาร‑คุณสมบัติเพียงอย่างเดียวได้หรือไม่?**

ไม่ได้ คุณสมบัติสาธารณะและคุณสมบัติที่เข้ารหัสต้องคงความสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านการเปิดที่ถูกต้อง