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
- คุณสมบัติกำหนดล่วงหน้า
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติเพิ่มเติม
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบ
- ภาษาดีฟอลท์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เชี่ยวชาญการจัดการคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ C++ และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่าย"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom** ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติของเอกสารนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_document_properties) ตัวอย่างของอินเทอร์เฟซนี้จะถูกส่งกลับโดยเมธอด [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_documentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" %}} 

โปรดทราบว่าคุณไม่สามารถตั้งค่าให้กับฟิลด์ **Application** และ **Producer** ได้ เนื่องจากจะแสดง Aspose Ltd. และ Aspose.Slides for C++ x.x.x ในฟิลด์เหล่านี้.

{{% /alert %}} 

## **จัดการคุณสมบัติของการนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์ให้เพิ่มคุณสมบัติบางอย่างลงในไฟล์การนำเสนอ คุณสมบัติเบื้องต้นเหล่านี้ช่วยให้ข้อมูลที่เป็นประโยชน์ถูกเก็บร่วมกับไฟล์เอกสาร (ไฟล์การนำเสนอ) มีสองประเภทของคุณสมบัติดังต่อไปนี้

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** properties มีข้อมูลทั่วไปเกี่ยวกับเอกสารเช่น ชื่อเรื่องของเอกสาร, ชื่อผู้เขียน, สถิติของเอกสาร เป็นต้น **Custom** properties คือคุณสมบัติโดยผู้ใช้กำหนดเป็นคู่ **Name/Value** โดยทั้งชื่อและค่าเป็นที่กำหนดโดยผู้ใช้ ด้วย Aspose.Slides for C++ นักพัฒนาสามารถเข้าถึงและแก้ไขค่าของคุณสมบัติที่สร้างมาแล้วรวมถึงคุณสมบัติที่กำหนดเองได้ Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติของเอกสารในไฟล์การนำเสนอ ขั้นตอนคือคลิกที่ไอคอนไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 หลังจากเลือกเมนู **Advanced Properties** จะปรากฏไดอะล็อกให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint ใน **Properties Dialog** คุณจะพบแท็บหลายหน้าเช่น **General, Summary, Statistics, Contents and Custom** ทุกแท็บนี้ใช้กำหนดข้อมูลต่าง ๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint **Custom** tab ใช้จัดการคุณสมบัติที่กำหนดเองของไฟล์ PowerPoint

## **เข้าถึง Built-in Properties**

คุณสมบัติเหล่านี้ที่เปิดให้เข้าถึงโดยวัตถุ **IDocumentProperties** มีดังนี้: **Creator(Author)**, **Description**, **KeyWords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ครั้งล่าสุด), **LastModifiedBy**, **Keywords**, **SharedDoc** (แชร์ระหว่างผู้ผลิตต่าง ๆ หรือไม่?), **PresentationFormat**, **Subject** และ **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **แก้ไข Built-in Properties**

การแก้ไขคุณสมบัติที่สร้างมาแล้วของไฟล์การนำเสนอทำได้ง่ายเท่ากับการเข้าถึง เพียงกำหนดค่าข้อความให้กับคุณสมบัติที่ต้องการและค่าจะถูกแก้ไข ในตัวอย่างด้านล่างได้แสดงวิธีการแก้ไขคุณสมบัติเอกสารที่สร้างมาแล้วของไฟล์การนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **เพิ่ม Custom Presentation Properties**

Aspose.Slides for C++ ยังอนุญาตให้นักพัฒนาตั้งค่าคุณสมบัติแบบกำหนดเองสำหรับเอกสารการนำเสนอ ตัวอย่างด้านล่างแสดงวิธีการตั้งค่าคุณสมบัติกำหนดเองสำหรับการนำเสนอ

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

// ดึงคุณสมบัติของเอกสาร
auto documentProperties = presentation->get_DocumentProperties();

// เพิ่มคุณสมบัติแบบกำหนดเอง
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

## **เข้าถึงและแก้ไข Custom Properties**

Aspose.Slides for C++ ยังอนุญาตให้นักพัฒนาดึงค่าของคุณสมบัติที่กำหนดเอง ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติกำหนดเองทั้งหมดของการนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **ตั้งค่า Proofing Language**

Aspose.Slides มีคุณสมบัติ [LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_languageid/) (เปิดให้โดยคลาส [PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/portionformat/)) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่ใช้ตรวจการสะกดและไวยากรณ์ใน PowerPoint

โค้ด C++ นี้แสดงวิธีการตั้งค่าภาษา proofing สำหรับ PowerPoint:

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

## **ตั้งค่า Default Language**

โค้ด C++ นี้แสดงวิธีการตั้งค่าภาษาเริ่มต้นสำหรับการนำเสนอ PowerPoint ทั้งหมด:

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

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***คำถามที่พบบ่อย**

### วิธีการลบคุณสมบัติ Built-in ออกจากการนำเสนอได้อย่างไร?

คุณสมบัติ Built-in เป็นส่วนที่ไม่สามารถแยกออกจากการนำเสนอได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัติกำหนดนั้นอนุญาต

### ถ้าฉันเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้วจะเกิดอะไรขึ้น?

ถ้าคุณเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

### ฉันสามารถเข้าถึงคุณสมบัติของการนำเสนอได้โดยไม่ต้องโหลดการนำเสนอทั้งหมดหรือไม่?

ได้ คุณสามารถเข้าถึงคุณสมบัติของการนำเสนอโดยไม่ต้องโหลดการนำเสนอทั้งหมดโดยใช้เมธอด `GetPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `ReadDocumentProperties` ของอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/) เพื่ออ่านคุณสมบัตอย่างมีประสิทธิภาพ ลดการใช้หน่วยความจำและเพิ่มประสิทธิภาพ.