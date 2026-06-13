---
title: แปลงงานนำเสนอ PowerPoint ไปเป็น XPS บน Android
linktitle: PowerPoint เป็น XPS
type: docs
weight: 70
url: /th/androidjava/convert-powerpoint-to-xps/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น XPS
- การนำเสนอเป็น XPS
- สไลด์เป็น XPS
- PPT ไป XPS
- PPTX ไป XPS
- บันทึก PPT เป็น XPS
- บันทึก PPTX เป็น XPS
- ส่งออก PPT เป็น XPS
- ส่งออก PPTX เป็น XPS
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX ไปเป็น XPS คุณภาพสูง ไม่ขึ้นกับแพลตฟอร์มใน Java โดยใช้ Aspose.Slides สำหรับ Android. รับคำแนะนำแบบทีละขั้นตอนและตัวอย่างโค้ด."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint ไปเป็น XPS โดยบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อใดที่รูปแบบ XPS มีประโยชน์และแสดงวิธีการทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่าแบบกำหนดเอง [XpsOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions/) settings.

## **เกี่ยวกับ XPS**
Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกแทน [PDF](https://docs.fileformat.com/pdf/).  มันทำให้คุณพิมพ์เนื้อหาโดยสร้างไฟล์ที่คล้ายกับ PDF มาก รูปแบบ XPS ใช้พื้นฐานจาก XML โครงสร้างหรือการจัดวางของไฟล์ XPS จะเหมือนกันบนระบบปฏิบัติการและเครื่องพิมพ์ทั้งหมด. 

## **เมื่อใดที่ควรใช้รูปแบบ Microsoft XPS**

{{% alert color="primary" %}} 

เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PPT หรือ PPTX ไปเป็นรูปแบบ XPS อย่างไร คุณสามารถตรวจสอบได้ที่ [แอปแปลงออนไลน์ฟรีนี้](https://products.aspose.app/slides/th/conversion). 

{{% /alert %}} 

หากคุณต้องการลดค่าใช้จ่ายในการจัดเก็บข้อมูล คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint ของคุณเป็นรูปแบบ XPS วิธีนี้จะทำให้คุณบันทึก แบ่งปัน และพิมพ์เอกสารได้ง่ายขึ้น. 

Microsoft ยังคงให้การสนับสนุน XPS อย่างเต็มที่ใน Windows (แม้ใน Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์ในรูปแบบนี้ หากคุณทำงานกับ Windows 8.1, Windows 8, Windows 7 และ Windows Vista แล้ว XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับการดำเนินการบางอย่าง. 

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันที่มาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 ให้การสนับสนุนไฟล์ XPS ดีกว่าไฟล์ PDF. 
  - **XPS:** มีตัวดู/อ่าน XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS พร้อมใช้งาน. 
  - **PDF:** มีโปรแกรมอ่าน PDF แต่ไม่มีฟีเจอร์การพิมพ์เป็น PDF. 

-  **Windows 7 and Windows Vista** use the original XPS format. These operating systems also provide better support for XPS files than they do for PDFs. 
  - **XPS**: Built-in XPS viewer and printing to XPS feature available. 
  - **PDF**: No PDF reader. No printing to PDF feature. 

|<p>**อินพุต PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**เอาต์พุต XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft สุดท้ายได้เพิ่มการสนับสนุนการพิมพ์เป็น PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านี้ ผู้ใช้คาดว่าจะพิมพ์เอกสารผ่านรูปแบบ XPS. 

## **การแปลง XPS ด้วย Aspose.Slides**

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/androidjava/) สำหรับ Java คุณสามารถใช้เมธอด [**Save**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ที่เปิดโดยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) เพื่อแปลงงานนำเสนอทั้งหมดให้เป็นเอกสาร XPS.

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้การตั้งค่าใดการตั้งค่าหนึ่งต่อไปนี้:
- การตั้งค่าเริ่มต้น (โดยไม่มี [**XPSOptions**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions))
- การตั้งค่ากำหนดเอง (ด้วย [**XPSOptions**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions))

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

โค้ดตัวอย่างนี้ใน Java แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ามาตรฐาน:

```java
// สร้างวัตถุ Presentation ที่แสดงไฟล์งานนำเสนอ
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
// สร้างวัตถุ Presentation ที่แสดงไฟล์งานนำเสนอ
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส TiffOptions
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

**ฉันสามารถบันทึก XPS ไปยังสตรีมแทนไฟล์ได้หรือไม่?**

ใช่—Aspose.Slides ให้คุณส่งออกโดยตรงไปยังสตรีม ซึ่งเหมาะสำหรับ API เว็บ, กระบวนการบนเซิร์ฟเวอร์, หรือสถานการณ์ใด ๆ ที่คุณต้องการส่ง XPS โดยไม่ต้องสัมผัสระบบไฟล์.

**สไลด์ที่ซ่อนจะถูกส่งต่อไปยัง XPS หรือไม่ และฉันสามารถละเว้นมันได้หรือไม่?**

โดยค่าเริ่มต้น จะเรนเดอร์เฉพาะสไลด์ปกติ (ที่มองเห็นได้) เท่านั้น คุณสามารถ [รวมหรือยกเว้นสไลด์ที่ซ่อน](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) ผ่าน [การตั้งค่าส่งออก](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีเพียงหน้าที่คุณต้องการเท่านั้น.