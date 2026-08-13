---
title: แปลงงานนำเสนอ PowerPoint เป็น XPS ใน .NET
linktitle: PowerPoint เป็น XPS
type: docs
weight: 70
url: /th/net/convert-powerpoint-to-xps/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น XPS
- งานนำเสนอเป็น XPS
- สไลด์เป็น XPS
- PPT เป็น XPS
- PPTX เป็น XPS
- บันทึก PPT เป็น XPS
- บันทึก PPTX เป็น XPS
- ส่งออก PPT เป็น XPS
- ส่งออก PPTX เป็น XPS
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น XPS คุณภาพสูงและเป็นอิสระจากแพลตฟอร์มใน .NET ด้วย Aspose.Slides รับคู่มือขั้นตอนและตัวอย่างโค้ด C#"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็น XPS โดยการบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อใดที่รูปแบบ XPS จะเป็นประโยชน์และแสดงวิธีการทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่าแบบกำหนดเอง [XpsOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions/) 

## **เกี่ยวกับ XPS**
Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกของ [PDF](https://docs.fileformat.com/pdf/) มันช่วยให้คุณพิมพ์เนื้อหาโดยการสร้างไฟล์ที่คล้ายกับ PDF รูปแบบ XPS มีพื้นฐานมาจาก XML การจัดวางหรือโครงสร้างของไฟล์ XPS จะคงที่บนระบบปฏิบัติการและเครื่องพิมพ์ทุกประเภท  

## **เมื่อควรใช้รูปแบบ Microsoft XPS**

{{% alert color="info" %}} 

เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PPT หรือ PPTX เป็นรูปแบบ XPS อย่างไร คุณสามารถตรวจสอบ [แอปแปลงออนไลน์ฟรีนี้](https://products.aspose.app/slides/th/conversion) 

{{% /alert %}} 

หากคุณต้องการลดค่าใช้จ่ายในการจัดเก็บ คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint ของคุณเป็นรูปแบบ XPS วิธีนี้จะทำให้การบันทึก, แชร์ และพิมพ์เอกสารของคุณง่ายขึ้น  

Microsoft ยังคงให้การสนับสนุน XPS อย่างแข็งแกร่งใน Windows (แม้ใน Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์ในรูปแบบนี้ หากคุณใช้ Windows 8.1, Windows 8, Windows 7 และ Windows Vista แล้ว XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับบางการดำเนินการ  

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันมาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 ให้การสนับสนุนไฟล์ XPS ดีกว่าการสนับสนุนไฟล์ PDF.  
  - **XPS:** มีตัวดู/อ่าน XPS ในระบบและฟีเจอร์การพิมพ์เป็น XPS  
  - **PDF**: มีโปรแกรมอ่าน PDF แต่ไม่มีฟีเจอร์การพิมพ์เป็น PDF  

- **Windows 7 และ Windows Vista** ใช้รูปแบบ XPS ดั้งเดิม ระบบปฏิบัติการเหล่านี้ยังให้การสนับสนุนไฟล์ XPS ดีกว่าการสนับสนุน PDF.  
  - **XPS**: มีตัวดู XPS ในระบบและฟีเจอร์การพิมพ์เป็น XPS  
  - **PDF**: ไม่มีโปรแกรมอ่าน PDF ไม่มีฟีเจอร์การพิมพ์เป็น PDF  

|<p>**อินพุต PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**เอาต์พุต XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ในที่สุดก็ได้เพิ่มการสนับสนุนการพิมพ์ใน PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านี้ผู้ใช้คาดว่าจะพิมพ์เอกสารผ่านรูปแบบ XPS  

## **การแปลง XPS ด้วย Aspose.Slides**

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/net/) สำหรับ .NET คุณสามารถใช้เมธอด [**Save**](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/save/index) ที่เปิดโดยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร XPS  

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้การตั้งค่าใดการตั้งค่าหนึ่งต่อไปนี้:  

- การตั้งค่าเริ่มต้น (โดยไม่มี [**XPSOptions**](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions))  
- การตั้งค่ากำหนดเอง (โดยใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions))  

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

โค้ดตัวอย่างนี้ใน C# แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ามาตรฐาน:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // บันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่ากำหนดเอง**

โค้ดตัวอย่างนี้แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ากำหนดเองใน C#:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // สร้างอ็อบเจกต์คลาส TiffOptions
    XpsOptions options = new XpsOptions();

    // บันทึก MetaFiles เป็น PNG
    options.SaveMetafilesAsPng = true;

    // บันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **คำถามที่พบบ่อย**

### ฉันสามารถบันทึกเป็น XPS ลงในสตรีมแทนไฟล์ได้ไหม?

ใช่—Aspose.Slides ให้คุณส่งออกโดยตรงไปยังสตรีม ซึ่งเหมาะสำหรับเว็บ API, pipeline ฝั่งเซิร์ฟเวอร์ หรือสถานการณ์ใด ๆ ที่คุณต้องการส่ง XPS โดยไม่ต้องสัมผัสระบบไฟล์  

### สไลด์ที่ซ่อนอยู่จะถูกนำไปยัง XPS หรือไม่ และฉันสามารถยกเว้นได้หรือไม่?

โดยค่าเริ่มต้น จะเรนเดอร์เฉพาะสไลด์ปกติ (ที่มองเห็นได้) เท่านั้น คุณสามารถ [รวมหรือยกเว้นสไลด์ที่ซ่อนอยู่](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions/showhiddenslides/) ผ่าน [การตั้งค่าการส่งออก](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีเพียงหน้าที่คุณต้องการเท่านั้น