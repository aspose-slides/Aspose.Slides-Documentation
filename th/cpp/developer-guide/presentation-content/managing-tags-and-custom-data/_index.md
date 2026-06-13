---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย C++
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/cpp/managing-tags-and-custom-data/
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, อ่าน, ปรับปรุงและลบแท็กและข้อมูลกำหนดเองใน Aspose.Slides สำหรับ C++ พร้อมตัวอย่างสำหรับการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร โดยสรุปสั้น ๆ ว่าข้อมูลถูกจัดเก็บในไฟล์ PPTX อย่างไร, ระบุว่าข้อมูลที่เฉพาะเจาะจงต่อการนำเสนอสามารถอยู่ในรูปแบบแท็กและส่วน XML กำหนดเอง, และอธิบายว่าแท็กเป็นคู่ค่าคีย์‑ค่าในรูปแบบสตริง  

นอกจากนี้ยังแสดงวิธีอ่านค่าของแท็กและวิธีเพิ่มแท็กในงานนำเสนอ, สไลด์เดียว, หรือรูปร่าง นอกจากนี้บทความยังครอบคลุมงานจัดการแท็กทั่วไปเช่น การลบแท็กทั้งหมด, การลบแท็กตามชื่อ, และการดึงรายการชื่อแท็ก

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX—ไฟล์ที่มีส่วนขยาย .pptx—จะถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML รูปแบบ Office Open XML กำหนดโครงสร้างของข้อมูลที่อยู่ในงานนำเสนอ  

โดยที่ *slide* เป็นหนึ่งในองค์ประกอบของงานนำเสนอ, *slide part* จะบรรจุเนื้อหาของสไลด์เดียว *slide part* อาจมีความสัมพันธ์อย่างชัดเจนกับหลายส่วน—เช่น User Defined Tags—ตามที่กำหนดโดย ISO/IEC 29500  

ข้อมูลกำหนดเอง (เฉพาะงานนำเสนอ) หรือข้อมูลของผู้ใช้สามารถอยู่ในรูปแบบแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/itagcollection/)) และ CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/))  

{{% alert color="primary" %}}  
แท็กโดยพื้นฐานแล้วคือค่าคู่คีย์‑สตริง  
{{% /alert %}}  

## **รับค่าแท็ก**

ใน Slides แท็กสอดคล้องกับคุณสมบัติ IDocumentProperties.Keywords ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับค่าของแท็กด้วย Aspose.Slides for C++ สำหรับ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **เพิ่มแท็กในงานนำเสนอ**

Aspose.Slides ให้คุณเพิ่มแท็กในงานนำเสนอได้ แท็กทั่วไปประกอบด้วยสองรายการ  

- ชื่อของคุณสมบัติกำหนดเอง - `MyTag`  
- ค่าของคุณสมบัติกำหนดเอง - `My Tag Value`  

หากคุณต้องการจัดประเภทงานนำเสนอบางส่วนตามกฎหรือคุณสมบัติเฉพาะ คุณอาจได้รับประโยชน์จากการเพิ่มแท็กในงานนำเสนนั้น ๆ ตัวอย่างเช่น หากต้องการจัดกลุ่มหรือรวบรวมงานนำเสนอทั้งหมดจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็กอเมริกาเหนือและกำหนดค่าต่าง ๆ (สหรัฐอเมริกา, เม็กซิโก และแคนาดา) เป็นค่า  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มแท็กลงใน [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) โดยใช้ Aspose.Slides for C++ :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

แท็กยังสามารถตั้งค่าสำหรับ [Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/) :

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/) ใด ๆ :

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชันแท็กข้อมูลกำหนดเองโดยใช้ `get_CustomData()->get_Tags()` จะถูกเก็บไว้เพียงในไฟล์ PowerPoint เท่านั้น พวกมัน **ไม่** ถูกโอนย้ายไปยังโครงสร้างแท็ก PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้น ตัวระบุที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้  

**Workaround**: คุณสามารถเก็บตัวระบุกำหนดเองไว้ใน **Alt Text** ของวัตถุ (เช่น `shape->set_AlternativeText(u"MyId")`) หลังจากส่งออกเป็น PDF, Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF  

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์, หรือรูปร่างได้ในการดำเนินการหนึ่งครั้งหรือไม่?**  

ใช่. [tag collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/) รองรับการดำเนินการ [clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/clear/) ที่ลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน  

**ฉันจะลบแท็กเดียวตามชื่อโดยไม่ต้องวนลูปผ่านคอลเลกชันทั้งหมดได้อย่างไร?**  

ใช้การดำเนินการ [Remove(name)](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/remove/) บน [TagCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/) เพื่อลบแท็กตามคีย์ของมัน  

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือกรองได้อย่างไร?**  

ใช้ [GetNamesOfTags](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/getnamesoftags/) บน [tag collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/) ; มันจะคืนอาเรย์ของชื่อแท็กทั้งหมด