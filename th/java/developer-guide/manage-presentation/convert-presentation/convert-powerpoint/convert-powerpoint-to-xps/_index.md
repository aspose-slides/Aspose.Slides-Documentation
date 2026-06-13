---
title: แปลงงานนำเสนอ PowerPoint เป็น XPS ใน Java
linktitle: PowerPoint เป็น XPS
type: docs
weight: 70
url: /th/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น XPS คุณภาพสูง ไม่ขึ้นกับแพลตฟอร์ม ใน Java ด้วย Aspose.Slides รับคำแนะนำทีละขั้นตอนและโค้ดตัวอย่าง"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็น XPS ได้โดยการบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าต้องใช้รูปแบบ XPS เมื่อใดและแสดงวิธีทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่า [XpsOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/xpsoptions/) แบบกำหนดเอง

## **เกี่ยวกับ XPS**
Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกสำหรับ [PDF](https://docs.fileformat.com/pdf/). มันทำให้คุณพิมพ์เนื้อหาโดยสร้างไฟล์ที่คล้ายกับ PDF รูปแบบ XPS ใช้ XML เป็นฐาน โครงร่างหรือโครงสร้างของไฟล์ XPS จะคงเดิมบนทุกระบบปฏิบัติการและเครื่องพิมพ์  

## **เมื่อใดควรใช้รูปแบบ Microsoft XPS**

{{% alert color="primary" %}} 
เพื่อดูว่าผลลัพธ์การแปลงงานนำเสนอ PPT หรือ PPTX ไปเป็นรูปแบบ XPS ของ Aspose.Slides เป็นอย่างไร คุณสามารถลองใช้แอปแปลงออนไลน์ฟรีนี้
{{% /alert %}} 

หากคุณต้องการลดค่าใช้จ่ายในการจัดเก็บ คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint ของคุณเป็นรูปแบบ XPS ได้ วิธีนี้จะทำให้การบันทึก แบ่งปัน และพิมพ์เอกสารของคุณง่ายขึ้น  

Microsoft ยังคงให้การสนับสนุน XPS อย่างเต็มที่ใน Windows (รวมถึง Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์เป็นรูปแบบนี้ หากคุณทำงานกับ Windows 8.1, Windows 8, Windows 7, และ Windows Vista แล้ว XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับการดำเนินการบางอย่าง  

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันมาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 ให้การสนับสนุนไฟล์ XPS ดีกว่าการสนับสนุนไฟล์ PDF.  
  - **XPS:** ผู้ดู/อ่าน XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS พร้อมใช้งาน.  
  - **PDF:** มีโปรแกรมอ่าน PDF แต่ไม่มีฟีเจอร์การพิมพ์เป็น PDF.  

- **Windows 7** และ **Windows Vista** ใช้รูปแบบ XPS ดั้งเดิม ระบบปฏิบัติการเหล่านี้ให้การสนับสนุนไฟล์ XPS ดีกว่าการสนับสนุน PDF.  
  - **XPS:** ผู้ดู XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS พร้อมใช้งาน.  
  - **PDF:** ไม่มีโปรแกรมอ่าน PDF ไม่มีฟีเจอร์การพิมพ์เป็น PDF.  

|<p>**อินพุต PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**เอาต์พุต XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ในที่สุดก็เพิ่มการสนับสนุนการพิมพ์เป็น PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านี้ ผู้ใช้ต้องพิมพ์เอกสารผ่านรูปแบบ XPS  

## **การแปลง XPS ด้วย Aspose.Slides**

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/java/) สำหรับ Java คุณสามารถใช้เมธอด [**Save**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ที่เปิดให้ใช้งานโดยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร XPS  

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้การตั้งค่าใดการตั้งค่าหนึ่งต่อไปนี้:  

- การตั้งค่าเริ่มต้น (โดยไม่มี [**XPSOptions**](https://reference.aspose.com/slides/th/java/com.aspose.slides/xpsoptions))  
- การตั้งค่ากำหนดเอง (โดยใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/java/com.aspose.slides/xpsoptions))  

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

โค้ดตัวอย่างนี้ใน Java แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร XPS โดยใช้การตั้งค่ามาตรฐาน:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // บันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่ากำหนดเอง**

โค้ดตัวอย่างนี้แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ากำหนดเองใน Java:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // สร้างอ็อบเจ็กต์คลาส TiffOptions
    XpsOptions options = new XpsOptions();

    // บันทึก MetaFiles เป็น PNG
    options.setSaveMetafilesAsPng(true);

    // บันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกเป็น XPS ลงในสตรีมแทนไฟล์ได้ไหม?**

ได้—Aspose.Slides ให้คุณส่งออกโดยตรงเป็นสตรีม ซึ่งเหมาะกับ Web API, ระบบประมวลผลด้านเซิร์ฟเวอร์ หรือสถานการณ์ใด ๆ ที่คุณต้องการส่ง XPS โดยไม่ต้องสัมผัสระบบไฟล์  

**สไลด์ที่ซ่อนอยู่จะถูกแปลงเป็น XPS หรือไม่ และฉันสามารถยกเว้นได้หรือไม่?**

โดยค่าเริ่มต้น จะเรนเดอร์เฉพาะสไลด์ปกติ (ที่มองเห็น) เท่านั้น คุณสามารถ [รวมหรือยกเว้นสไลด์ที่ซ่อนอยู่](https://reference.aspose.com/slides/th/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) ผ่าน [การตั้งค่าการส่งออก](https://reference.aspose.com/slides/th/java/com.aspose.slides/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีเฉพาะหน้าที่คุณต้องการเท่านั้น