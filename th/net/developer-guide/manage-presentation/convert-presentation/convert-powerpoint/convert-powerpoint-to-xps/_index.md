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
description: "แปลง PowerPoint PPT/PPTX เป็น XPS คุณภาพสูง ไม่ขึ้นกับแพลตฟอร์มใน .NET ด้วย Aspose.Slides รับคำแนะนำทีละขั้นตอนและตัวอย่างโค้ด C#"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็น XPS ได้โดยบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อใดที่รูปแบบ XPS จะเป็นประโยชน์และแสดงวิธีการทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่า [XpsOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions/) แบบกำหนดเอง

## **เกี่ยวกับ XPS**
Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกสำหรับ [PDF](https://docs.fileformat.com/pdf/)  มันช่วยให้คุณพิมพ์เนื้อหาโดยส่งออกไฟล์ที่คล้ายกับ PDF รูปแบบ XPS มีพื้นฐานจาก XML โครงสร้างของไฟล์ XPS จะคงที่บนระบบปฏิบัติการและเครื่องพิมพ์ทั้งหมด

## **เมื่อใดควรใช้รูปแบบ Microsoft XPS**

{{% alert color="primary" %}} 

เพื่อดูวิธีที่ Aspose.Slides แปลงงานนำเสนอ PPT หรือ PPTX เป็นรูปแบบ XPS คุณสามารถลองใช้ [this free online converter app](https://products.aspose.app/slides/th/conversion) 

{{% /alert %}} 

หากคุณต้องการลดค่าใช้จ่ายในการจัดเก็บ คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint ของคุณเป็นรูปแบบ XPS ด้วย วิธีนี้จะทำให้การบันทึก แบ่งปัน และพิมพ์เอกสารของคุณง่ายขึ้น

Microsoft ยังให้การสนับสนุน XPS อย่างแข็งขันใน Windows (รวมถึง Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์เป็นรูปแบบนี้ หากคุณกำลังใช้งาน Windows 8.1, Windows 8, Windows 7 และ Windows Vista XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับบางการทำงาน

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันมาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 มีการสนับสนุนไฟล์ XPS ดีกว่าไฟล์ PDF
  - **XPS:** มีตัวดู/อ่าน XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS
  - **PDF:** มีตัวอ่าน PDF แต่ไม่มีฟีเจอร์การพิมพ์เป็น PDF

- **Windows 7 และ Windows Vista** ใช้รูปแบบ XPS ดั้งเดิม ระบบปฏิบัติการเหล่านี้ยังให้การสนับสนุนไฟล์ XPS ดีกว่า PDF
  - **XPS:** มีตัวดู XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS
  - **PDF:** ไม่มีตัวอ่าน PDF และไม่มีฟีเจอร์การพิมพ์เป็น PDF

|<p>**อินพุต PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**เอาต์พุต XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ในที่สุดได้เพิ่มการสนับสนุนการดำเนินการพิมพ์ใน PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านี้ผู้ใช้ต้องพิมพ์เอกสารผ่านรูปแบบ XPS

## **การแปลง XPS ด้วย Aspose.Slides**

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/net/) สำหรับ .NET คุณสามารถใช้เมธอด [**Save**](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/save/index) ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร XPS

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้การตั้งค่าใดการตั้งหน้าดังต่อไปนี้:

- การตั้งค่าเริ่มต้น (โดยไม่ใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions))
- การตั้งค่าแบบกำหนดเอง (โดยใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions))

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

โค้ดตัวอย่างใน C# นี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ามาตรฐาน:

```c#
// สร้างวัตถุ Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // บันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าแบบกำหนดเอง**
โค้ดตัวอย่างนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่าแบบกำหนดเองใน C#:

```c#
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // สร้างอินสแตนซ์ของคลาส TiffOptions
    XpsOptions options = new XpsOptions();

    // บันทึก MetaFiles เป็น PNG
    options.SaveMetafilesAsPng = true;

    // บันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกเป็น XPS ลงในสตรีมแทนไฟล์ได้หรือไม่?**

ได้—Aspose.Slides ให้คุณส่งออกโดยตรงเป็นสตรีม ซึ่งเหมาะกับ Web API, รายการทำงานฝั่งเซิร์ฟเวอร์ หรือสถานการณ์ใด ๆ ที่ต้องการส่ง XPS โดยไม่ต้องสัมผัสระบบไฟล์

**สไลด์ที่ซ่อนอยู่จะถูกแปลงเป็น XPS หรือไม่ และฉันสามารถละเว้นได้หรือไม่?**

โดยค่าเริ่มต้นจะเรนเดอร์เฉพาะสไลด์ที่ปรากฏเท่านั้น คุณสามารถ [รวมหรือยกเว้นสไลด์ที่ซ่อนอยู่](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions/showhiddenslides/) ผ่าน [การตั้งค่า export](https://reference.aspose.com/slides/th/net/aspose.slides.export/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีเพียงหน้าที่คุณต้องการเท่านั้น