---
title: "จัดการคุณสมบัติงานนำเสนอใน C++"
linktitle: "คุณสมบัติงานนำเสนอ"
type: docs
weight: 70
url: /th/cpp/presentation-properties/
keywords:
- "คุณสมบัติ PowerPoint"
- "คุณสมบัติงานนำเสนอ"
- "คุณสมบัติเอกสาร"
- "คุณสมบัติมาตรฐาน"
- "คุณสมบัติกำหนดเอง"
- "คุณสมบัติเพิ่มเติม"
- "จัดการคุณสมบัติ"
- "แก้ไขคุณสมบัติ"
- "เมตาดาทาเอกสาร"
- "แก้ไขเมตาดาทา"
- "ภาษาการตรวจสอบ"
- "ภาษาดีฟอลต์"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "C++"
- "Aspose.Slides"
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides สำหรับ C++ และทำให้การค้นหา, การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระเบียบและรวดเร็วขึ้น."
---
## **บทนำ**

Aspose.Slides สำหรับ C++ รองรับคุณสมบัติเอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาดาทาของงานนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่กำหนดโดยผู้ใช้.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) . ตัวอย่างของอินเทอร์เฟซนี้จะถูกส่งคืนโดย [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). ตัวอย่างต่อไปนี้แสดงวิธีอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมตาดาทาแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์.
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลอธิบายพร้อมกับเนื้อหาของงานนำเสนอ พวกมันแบ่งออกเป็นสองประเภท:

- **Built-in properties** ประกอบด้วยเมตาดาทามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติเอกสาร.
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง.

Aspose.Slides สำหรับ C++ ให้เข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อตรวจสอบเมตาดาทาเอกสาร กล่องโต้ตอบจะจัดข้อมูลเป็นแท็บต่างๆ เช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้ใช้กำหนด.

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่ถูกเข้ารหัส**

รหัสผ่านการเปิดปกติจะปกป้องทั้งเนื้อหางานนำเสนอและคุณสมบัติเอกสาร เมื่องานนำเสนอถูกเข้ารหัสโดยส่งค่า `false` ไปยัง [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), คุณสมบัติเอกสารของมันจะคงอยู่ในสาธารณะ แอปพลิเคชันจึงสามารถส่งค่า `true` ให้กับ [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) และอ่านเมตาดาทาสาธารณะได้โดยไม่ต้องใส่รหัสผ่านการเปิด.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ทำการถอดรหัสใดๆ หากคุณสมบัตุถูกรวมไว้ในการเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้ถูกเข้ารหัส ตัวเลือกจะถูกละเลยและงานนำเสนอทั้งหมดจะถูกโหลด.

ตัวอย่างนี้ต้องการงานนำเสนอที่ถูกเข้ารหัสซึ่งคุณสมบัติเอกสารถูกทิ้งไว้เป็นสาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/), แล้วอ่านคุณสมบัติ built-in ผ่าน [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

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

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และวัตถุอื่นๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) เสมอก่อนทำการดำเนินการที่ต้องการโมเดลวัตถุของงานนำเสนอทั้งหมด.

{{% alert color="warning" title="Security" %}}
เมตาดาทาสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, เรื่อง, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง เข้ารหัสคุณสมบัติที่สำคัญพร้อมกับงานนำเสนอ ควรทิ้งเป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบจัดการเอกสารต้องการเข้าถึงโดยไม่ใช้รหัสผ่าน.
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่ถูกเข้ารหัส**

สำหรับไฟล์ PPTX ที่ถูกเข้ารหัส งานนำเสนอที่โหลดโดยส่งค่า `true` ให้กับ [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) มีจุดประสงค์เพื่ออ่านเมตาดาทาสาธารณะ Aspose.Slides ไม่สามารถบันทึกคุณสมบัติที่เปลี่ยนแปลงจากอ็อบเจ็กต์ที่มีเมตาดาทาอย่างเดียวได้เพราะคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่สอดคล้องภายในงานนำเสนอที่ถูกเข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านการเปิดที่ถูกต้องและการโหลดเต็มรูปแบบ.

ตัวอย่างนี้ต้องการงานนำเสนอ PPTX ที่ถูกเข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสผ่านการเปิดที่ทราบ มันเปิดงานนำเสนอทั้งหมดด้วย [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), อัปเดตคุณสมบัติ built-in สาธารณะ, แล้วบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาทาสาธารณะอีกครั้งโดยไม่ใช้รหัสผ่านเพื่อตรวจสอบค่าที่ใหม่:

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหางานนำเสนอ มันต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่ถูกเข้ารหัสว่าเป็นแบบอ่านอย่างเดียว.

## **เข้าถึงคุณสมบัติ Built-in**

อินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) เปิดเผยเมตาดาทา built-in ผ่าน getter ที่กำหนดประเภท รวมถึง [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/), และ [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาทาที่จัดเก็บไว้บนคอนโซล ค่าเหล่านี้ขึ้นอยู่กับงานนำเข้าสำหรับแต่ละกรณี; บางฟิลด์อาจว่างเปล่า.

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

## **แก้ไขคุณสมบัติ Built-in**

เพื่ออัปเดตเมตาดาทา built-in ใช้ setter บนวัตถุที่ส่งคืนโดย [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่, เรียก [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), และ [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), จากนั้นบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). PPTX ที่บันทึกไว้จะมีเมตาดาทาใหม่.

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

## **จัดการฐานลิงก์ไฮเปอร์ลิงค์**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) อ่านฐานระดับเอกสารสำหรับลิงก์ไฮเปอร์ลิงค์แบบ relative ซึ่งเป็นประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่เชื่อมโยงไปยังตำแหน่งอื่น มันแยกจาก [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) ของลิงก์แต่ละรายการ: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่เก็บหรือเปลี่ยนปลายทางแบบ absolute.

ตัวอย่างนี้ต้องการงานนำเสนอที่มีลิงก์แบบ relative เช่น `target.html` และลิงก์แบบ absolute เช่น `https://example.org/absolute.html`. มันอ่านฐานที่มีอยู่, กำหนดฐานใหม่ด้วย [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า จากนั้นทำการลบฐานด้วย `u""` และตรวจสอบค่าที่ว่างในไฟล์ที่บันทึกแยกต่างหาก แทนที่ที่อยู่ฐานในตัวอย่างด้วยตำแหน่งไฟล์ที่เชื่อมโยงของคุณ.

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

ข้อความยืนยันสองข้อความควรพิมพ์ `True`. การลบฐานจะทำให้ที่อยู่ลิงก์แต่ละรายการยังคงอยู่.

ลิงก์ relative ไปยัง `target.pptx` เปิด `old/target.pptx` เมื่อฐานชี้ไปยังโฟลเดอร์ `old`. หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new`, บันทึกและเปิดงานนำเสนอใหม่, ลิงก์เดียวกันเปิด `new/target.pptx`. ลิงก์ absolute ยังคงเปิดไฟล์เดียวกัน ทดสอบลิงก์ relative ของคุณใน PowerPoint ก่อนและหลังการย้ายงานนำเสนอหรือเปลี่ยนฐาน.

## **เพิ่มคุณสมบัติกำหนดเองของงานนำเสนอ**

คุณสมบัติ custom เก็บเมตาดาทาที่ไม่มีฟิลด์ built-in ที่สอดคล้องกัน [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มค่าข้อความสองค่าและค่ารุ่นแบบ integer, แล้วบันทึกงานนำเสนอด้วย [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). การกำหนดค่าลงในชื่อที่มีอยู่แล้วจะทับค่าของคุณสมบัตินั้น.

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

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติ custom และใช้ [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) เพื่อวนซ้ำผ่านพวกมัน [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) รับดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้โดย [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) และ [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทั้งหมดด้วยสตริงลำดับเลขโดยไม่คำนึงถึงประเภทเดิม, แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติ custom ลูปจะไม่ทำการเปลี่ยนแปลงใดๆ.

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

## **ตัวอย่างสด**

ลองแอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides API:

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in จากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่าเหล่านั้นหรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต.

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ.

**ฉันสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?**

ได้. ใช้ [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) แล้วตามด้วย [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาทาเอกสารที่จัดเก็บโดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). ดู [สร้างรายการตรวจสอบงานนำเสนอแบบเบา](/slides/th/cpp/examine-presentation/) สำหรับตัวอย่างการรายงานอย่างสมบูรณ์และข้อจำกัดตามรูปแบบ.

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ได้ใช้รหัสผ่านการเปิดได้หรือไม่?**

ได้. งานนำเสนอจะต้องถูกเข้ารหัสโดยส่งค่า `false` ไปยัง [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), และต้องโหลดโดยส่งค่า `true` ให้กับ [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document-properties-only ได้หรือไม่?**

ไม่ได้. ข้อมูลคุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสจึงต้องโหลดงานนำเสนอทั้งหมดพร้อมรหัสผ่านการเปิดที่ถูกต้อง.