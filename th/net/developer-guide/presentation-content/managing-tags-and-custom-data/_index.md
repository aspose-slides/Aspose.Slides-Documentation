---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย .NET
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/net/managing-tags-and-custom-data/
keywords:
- คุณสมบัติเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, อ่าน, อัปเดตและลบแท็กและข้อมูลกำหนดเองใน Aspose.Slides สำหรับ .NET พร้อมตัวอย่างสำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร โดยสรุปสั้น ๆ ว่าข้อมูลถูกจัดเก็บในไฟล์ PPTX อย่างไร พร้อมระบุว่าข้อมูลที่เฉพาะเจาะจงต่อการนำเสนออาจมีอยู่ในรูปแบบแท็กและส่วน Custom XML และอธิบายว่าแท็กเป็นคู่คีย์‑ค่าแบบสตริง

บทความยังแสดงวิธีการอ่านค่าของแท็กและวิธีการเพิ่มแท็กให้กับงานนำเสนอ สไลด์หนึ่งสไลด์ หรือรูปร่างหนึ่ง นอกจากนี้ยังครอบคลุมงานจัดการแท็กทั่วไป เช่น การลบแท็กทั้งหมด การลบแท็กตามชื่อ และการดึงรายการชื่อแท็ก

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีนามสกุล .pptx — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML สเปค Office Open XML นิยามโครงสร้างของข้อมูลที่อยู่ในงานนำเสนอ

โดยที่ *สไลด์* เป็นหนึ่งในองค์ประกอบของงานนำเสนอ *slide part* จะบรรจุเนื้อหาของสไลด์เดียว slide part สามารถมีความสัมพันธ์โดยตรงกับหลายส่วน — เช่น User Defined Tags — ตามที่ ISO/IEC 29500 กำหนด

ข้อมูลกำหนดเอง (เฉพาะต่อการนำเสนอ) หรือของผู้ใช้สามารถมีอยู่ในรูปแบบแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/net/aspose.slides/itagcollection)) และ CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection))

{{% alert color="primary" %}} 
แท็กเป็นค่าคู่คีย์‑สตริงโดยพื้นฐาน 
{{% /alert %}} 

## **รับค่าแท็ก**

ใน Slides แท็กสอดคล้องกับคุณสมบัติ IDocumentProperties.Keywords ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for .NET สำหรับ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **เพิ่มแท็กให้กับงานนำเสนอ**

Aspose.Slides ให้คุณเพิ่มแท็กให้กับงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองส่วน:

- ชื่อของคุณสมบัติกำหนดเอง - `MyTag`
- ค่าของคุณสมบัติกำหนดเอง - `My Tag Value`

หากคุณต้องการจัดประเภทงานนำเสนอบางรายการตามกฎหรือคุณสมบัติใด ๆ คุณอาจได้รับประโยชน์จากการเพิ่มแท็กให้กับงานเหล่านั้น ตัวอย่างเช่น หากต้องการจัดกลุ่มงานนำเสนอจากประเทศในอเมริกาเหนือทั้งหมด คุณสามารถสร้างแท็ก “North American” แล้วกำหนดค่าเป็นประเทศที่เกี่ยวข้อง (สหรัฐอเมริกา, เม็กซิโก, แคนาดา)

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กให้กับ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ด้วย Aspose.Slides for .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

แท็กยังสามารถกำหนดให้กับ [Slide](https://reference.aspose.com/slides/th/net/aspose.slides/slide) ได้ด้วย:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

หรือกำหนดให้กับ [Shape](https://reference.aspose.com/slides/th/net/aspose.slides/shape) ใด ๆ ก็ได้:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `CustomData.Tags` จะถูกเก็บไว้เฉพาะในไฟล์ PowerPoint เท่านั้น พวกมัน **ไม่** ถูกถ่ายโอนไปยังโครงสร้างแท็กของ PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้น ตัวระบุกำหนดเองที่บันทึกเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองไว้ใน **Alt Text** ของอ็อบเจกต์ (เช่น `shape.AlternativeText = "MyId"`). หลังจากส่งออกเป็น PDF ข้อความ Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปร่างในครั้งเดียวได้หรือไม่?**  
ใช่ คอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/) รองรับการดำเนินการ [clear](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/clear/) ที่ลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดียวตามชื่อตามที่ต้องการโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**  
ใช้การดำเนินการ [Remove(name)](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/remove/) บน [TagCollection](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/) เพื่อลบแท็กตามคีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดเพื่อทำการวิเคราะห์หรือกรองข้อมูลได้อย่างไร?**  
ใช้ [GetNamesOfTags](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/getnamesoftags/) บนคอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/) จะได้อาเรย์ของชื่อแท็กทั้งหมด