---
title: จัดการคุณสมบัติการนำเสนอใน C++
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/cpp/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติ built-in
- คุณสมบัติ custom
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ C++ และทำให้การค้นหา การสร้างแบรนด์และเวิร์กโฟลว์ในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่าย"
---
## **คำนำ**

Aspose.Slides รองรับสองประเภทของคุณสมบัติเอกสาร: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารการนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_document_properties) อินสตานซ์ของอินเทอร์เฟซนี้จะถูกส่งคืนโดยเมธอด [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_documentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
โปรดทราบว่าคุณไม่สามารถกำหนดค่าตรงที่ฟิลด์ **Application** และ **Producer** ได้ เนื่องจากจะมีการแสดง Aspose Ltd. และ Aspose.Slides for C++ x.x.x ในฟิลด์เหล่านั้น.
{{% /alert %}} 

## **จัดการคุณสมบัติการนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์ในการเพิ่มคุณสมบัติบางอย่างลงในไฟล์การนำเสนอ คุณสมบัติเอกสารเหล่านี้ช่วยให้สามารถเก็บข้อมูลที่เป็นประโยชน์พร้อมกับเอกสาร (ไฟล์การนำเสนอ) มีสองประเภทของคุณสมบัติเอกสารดังต่อไปนี้

- คุณสมบัติกำหนดโดยระบบ (Built-in)
- คุณสมบัติกำหนดโดยผู้ใช้ (Custom)

**Built-in** คุณสมบัติมีข้อมูลทั่วไปเกี่ยวกับเอกสารเช่น ชื่อเอกสาร, ชื่อผู้เขียน, สถิติเอกสาร เป็นต้น **Custom** คุณสมบัติคือสิ่งที่ผู้ใช้กำหนดเป็นคู่ **Name/Value** โดยทั้งชื่อและค่าเป็นที่กำหนดโดยผู้ใช้ โดยใช้ Aspose.Slides for C++ นักพัฒนาสามารถเข้าถึงและแก้ไขค่าของคุณสมบัติ built‑in รวมถึงคุณสมบัติ custom ได้ Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติเอกสารของไฟล์การนำเสนอ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 หลังจากเลือกเมนู **Advanced Properties** จะปรากฏหน้าต่างให้คุณจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint ใน **Properties Dialog** คุณจะเห็นแท็บหลายหน้าเช่น **General, Summary, Statistics, Contents and Custom** แท็บเหล่านี้ช่วยกำหนดค่าข้อมูลประเภทต่าง ๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint แท็บ **Custom** ใช้สำหรับจัดการคุณสมบัติ custom ของไฟล์ PowerPoint

## **Access Built-in Properties**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอ็อบเจ็กต์ **IDocumentProperties** ประกอบด้วย: **Creator(Author)**, **Description**, **KeyWords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ครั้งล่าสุด), **LastModifiedBy**, **Keywords**, **SharedDoc** (แชร์ระหว่างผู้ผลิตต่างๆ?), **PresentationFormat**, **Subject** และ **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modify Built-in Properties**

การแก้ไขคุณสมบัติ built‑in ของไฟล์การนำเสนอทำได้ง่ายเท่ากับการเข้าถึงคุณสมบัตินั้น ๆ คุณสามารถกำหนดค่าข้อความให้กับคุณสมบัติใด ๆ ที่ต้องการและค่าจะถูกเปลี่ยนแปลง ในตัวอย่างด้านล่าง เราได้แสดงวิธีการแก้ไขคุณสมบัติเอกสาร built‑in ของไฟล์การนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Add Custom Presentation Properties**

Aspose.Slides for C++ ยังอนุญาตให้นักพัฒนาเพิ่มค่าที่กำหนดเองสำหรับคุณสมบัติเอกสารการนำเสนอ ตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าคุณสมบัติ custom สำหรับการนำเสนอ

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation
auto presentation = System::MakeObject<Presentation>();

// ดึงคุณสมบัติเอกสาร
auto documentProperties = presentation->get_DocumentProperties();

// เพิ่มคุณสมบัติ Custom
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// ดึงชื่อคุณสมบัติที่ตำแหน่งดัชนีเฉพาะ
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// ลบคุณสมบัติที่เลือก
documentProperties->RemoveCustomProperty(getPropertyName);

// บันทึกการนำเสนอ
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Access and Modify Custom Properties**

Aspose.Slides for C++ ยังอนุญาตให้นักพัฒนาเข้าถึงค่าของคุณสมบัติ custom ตัวอย่างต่อไปนี้แสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติ custom ทั้งหมดสำหรับการนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Set Proofing Language**

Aspose.Slides มีคุณสมบัติ [LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_languageid/) (เปิดเผยโดยคลาส [PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/portionformat/)) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่จะตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// ตั้งค่า Id ของภาษาตรวจสอบ

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Set Default Language**

โค้ด C++ นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับการนำเสนอ PowerPoint ทั้งหมด:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// ตรวจสอบภาษาของส่วนแรก
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live Example**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารผ่าน Aspose.Slides API:

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติ built-in ออกจากการนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนสำคัญของการนำเสนอและไม่สามารถลบออกได้อย่างสมบูรณ์ อย่างไรก็ตาม คุณสามารถเปลี่ยนค่าได้หรือกำหนดให้เป็นค่าว่างหากคุณสมบัตินั้นอนุญาตให้ทำได้

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอได้โดยไม่ต้องโหลดการนำเสนอทั้งหมดหรือไม่?**

ได้ ใช้ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) แล้วตามด้วย [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสารที่จัดเก็บโดยไม่ต้องสร้างอินสตานซ์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ดู [Build a Lightweight Presentation Inventory](/slides/th/cpp/examine-presentation/) เพื่อดูตัวอย่างการรายงานที่สมบูรณ์และข้อจำกัดของรูปแบบเฉพาะ.