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
- ข้อมูลเมตาเอกสาร
- แก้ไขเมตาเดต้า
- ภาษา proofing
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides for C++ และทำให้การค้นหา, การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นไปอย่างราบรื่น."
---
## **บทนำ**

Aspose.Slides รองรับสองประเภทของคุณสมบัติเอกสาร: **Built-in** และ **Custom**. ทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้ง่ายโดยใช้ Aspose.Slides API.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติเอกสารการนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_document_properties) อินเทอร์เฟซนี้จะถูกคืนค่าด้วยเมธอด [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_documentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไขและจัดการคุณสมบัติเหล่านี้.

{{% alert color="primary" %}} 
โปรดทราบว่าคุณไม่สามารถตั้งค่าต่างๆ ให้กับฟิลด์ **Application** และ **Producer** ได้ เนื่องจาก Aspose Ltd. และ Aspose.Slides for C++ x.x.x จะถูกแสดงในฟิลด์เหล่านั้น.
{{% /alert %}} 

## **จัดการคุณสมบัติการนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์ในการเพิ่มคุณสมบัติบางอย่างลงในไฟล์การนำเสนอ คุณสมบัติเอกสารเหล่านี้ช่วยให้สามารถเก็บข้อมูลที่เป็นประโยชน์ไปพร้อมกับเอกสาร (ไฟล์การนำเสนอ) มีสองประเภทของคุณสมบัติเอกสารดังต่อไปนี้

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** มีข้อมูลทั่วไปเกี่ยวกับเอกสารเช่น ชื่อเอกสาร, ชื่อผู้เขียน, สถิติของเอกสาร ฯลฯ **Custom** คือคุณสมบัติที่ผู้ใช้กำหนดเป็นคู่ **Name/Value** โดยชื่อและค่าทั้งสองถูกกำหนดโดยผู้ใช้ การใช้ Aspose.Slides for C++ นักพัฒนาสามารถเข้าถึงและแก้ไขค่าของคุณสมบัติ built-in รวมถึง custom ได้ Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติเอกสารของไฟล์การนำเสนอ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 หลังจากเลือกเมนู **Advanced Properties** จะปรากฏหน้าต่างที่ให้คุณจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint ใน **Properties Dialog** คุณจะเห็นแท็บหลายหน้าเช่น **General, Summary, Statistics, Contents and Custom** แท็บเหล่านี้อนุญาตให้กำหนดค่าข้อมูลต่างๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint แท็บ **Custom** ใช้ในการจัดการคุณสมบัติ custom ของไฟล์ PowerPoint.

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยวัตถุ **IDocumentProperties** รวมถึง: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** และ **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **แก้ไขคุณสมบัติ Built-in**

การแก้ไขคุณสมบัติ built-in ของไฟล์การนำทำได้ง่ายเท่ากับการเข้าถึงคุณสมบัตินั้น คุณสามารถกำหนดค่าข้อความให้กับคุณสมบัติใดก็ได้ที่ต้องการและค่าของคุณสมบัติก็จะถูกแก้ไข ในตัวอย่างด้านล่าง เราได้สาธิตวิธีการแก้ไขคุณสมบัติเอกสาร built-in ของไฟล์การนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **เพิ่มคุณสมบัติการนำเสนอแบบ Custom**

Aspose.Slides for C++ ยังอนุญาตให้นักพัฒนาสามารถเพิ่มค่าที่กำหนดเองสำหรับคุณสมบัติเอกสารการนำเสนอ ตัวอย่างด้านล่างแสดงวิธีการตั้งค่าคุณสมบัติ custom สำหรับการนำเสนอ

``` cpp
// สร้างอินสแตนซ์ของคลาส Presentation
auto presentation = System::MakeObject<Presentation>();

// ดึงคุณสมบัติเอกสาร
auto documentProperties = presentation->get_DocumentProperties();

// เพิ่มคุณสมบัติ Custom
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// ดึงชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// ลบคุณสมบัติที่เลือก
documentProperties->RemoveCustomProperty(getPropertyName);

// บันทึกการนำเสนอ
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides for C++ ยังอนุญาตให้นักพัฒนาสามารถเข้าถึงค่าของคุณสมบัติ custom ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติ custom ทั้งหมดสำหรับการนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **ตั้งค่า Proofing Language**

Aspose.Slides มีคุณสมบัติ [LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_languageid/) (เปิดเผยโดยคลาส [PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/portionformat/)) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่จะตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด C++ นี้แสดงวิธีการตั้งค่าภาษา proofing สำหรับ PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **ตั้งค่าภาษาเริ่มต้น**

โค้ด C++ นี้แสดงวิธีการตั้งค่าภาษาเริ่มต้นสำหรับการนำเสนอ PowerPoint ทั้งหมด:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// ตรวจสอบภาษาของส่วนแรก
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **ตัวอย่างสด**

ลองแอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีการทำงานกับคุณสมบัติเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in ออกจากการนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนสำคัญของการนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่าเหล่านั้นหรือกำหนดเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**เกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าตัวใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนออย่างเต็มที่ได้หรือไม่?**

ใช่ คุณสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอทั้งหมดโดยใช้เมธอด `GetPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `ReadDocumentProperties` ที่ให้โดยอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ช่วยประหยัดหน่วยความจำและเพิ่มประสิทธิภาพ