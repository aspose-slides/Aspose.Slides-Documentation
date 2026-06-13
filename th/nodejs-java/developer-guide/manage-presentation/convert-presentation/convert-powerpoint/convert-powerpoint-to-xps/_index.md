---
title: แปลงงานนำเสนอ PowerPoint เป็น XPS ใน JavaScript
linktitle: PowerPoint เป็น XPS
type: docs
weight: 70
url: /th/nodejs-java/convert-powerpoint-to-xps/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น XPS คุณภาพสูงที่ทำงานบนหลายแพลตฟอร์มใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js รับคู่มือแบบขั้นตอนและโค้ดตัวอย่าง"
---
## **ภาพรวม**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint เป็น XPS โดยบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อใดที่รูปแบบ XPS มีประโยชน์และแสดงวิธีทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่า [XpsOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xpsoptions/) แบบกำหนดเอง

## **เกี่ยวกับ XPS**

Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกของ [PDF](https://docs.fileformat.com/pdf/)   มันช่วยให้คุณพิมพ์เนื้อหาโดยสร้างไฟล์ที่คล้ายกับ PDF มาก รูปแบบ XPS ถูกสร้างบน XML โครงสร้างหรือการจัดวางของไฟล์ XPS จะคงที่บนทุกระบบปฏิบัติการและเครื่องพิมพ์

## **เมื่อใดควรใช้รูปแบบ XPS ของ Microsoft**

{{% alert color="primary" %}} 

เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PPT หรือ PPTX เป็นรูปแบบ XPS อย่างไร คุณสามารถลองใช้ [this free online converter app](https://products.aspose.app/slides/th/conversion)  

{{% /alert %}} 

หากคุณต้องการลดค่าใช้จ่ายในการจัดเก็บข้อมูล คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint เป็นรูปแบบ XPS ได้ วิธีนี้ทำให้คุณบันทึก แบ่งปัน และพิมพ์เอกสารได้ง่ายขึ้น

Microsoft ยังคงให้การสนับสนุนอย่างแข็งแกร่งสำหรับ XPS ใน Windows (แม้ใน Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์เป็นรูปแบบนี้ หากคุณกำลังทำงานกับ Windows 8.1, Windows 8, Windows 7 และ Windows Vista แล้ว XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับบางการทำงาน

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันมาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 ให้การสนับสนุนไฟล์ XPS ดีกว่าไฟล์ PDF 
  - **XPS:** มีเครื่องมือดู/อ่าน XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS 
  - **PDF:** มีเครื่องมืออ่าน PDF แต่ไม่มีฟีเจอร์การพิมพ์เป็น PDF 

- **Windows 7 และ Windows Vista** ใช้รูปแบบ XPS ดั้งเดิม ระบบปฏิบัติการเหล่านี้ให้การสนับสนุนไฟล์ XPS ดีกว่า PDF 
  - **XPS:** มีเครื่องมือดู XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS 
  - **PDF:** ไม่มีเครื่องมืออ่าน PDF และไม่มีฟีเจอร์การพิมพ์เป็น PDF 

|<p>**อินพุต PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**ผลลัพธ์ XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ในที่สุดได้เพิ่มการสนับสนุนการพิมพ์เป็น PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านี้ผู้ใช้คาดว่าจะพิมพ์เอกสารผ่านรูปแบบ XPS

## **การแปลง XPS ด้วย Aspose.Slides**

ใน [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/th/nodejs-java/) คุณสามารถใช้เมธอด [**save**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร XPS

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้หนึ่งในการตั้งค่าดังต่อไปนี้:

- การตั้งค่าเริ่มต้น (โดยไม่มี [**XPSOptions**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xpsoptions))
- การตั้งค่าแบบกำหนดเอง (โดยใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xpsoptions))

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

ตัวอย่างโค้ดใน JavaScript นี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ามาตรฐาน:

```javascript
// สร้างออบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // บันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าแบบกำหนดเอง**
ตัวอย่างโค้ดนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่าที่กำหนดเองใน JavaScript:

```javascript
// สร้างออบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // สร้างออบเจ็กต์คลาส TiffOptions
    var options = new aspose.slides.XpsOptions();
    // บันทึก MetaFiles เป็น PNG
    options.setSaveMetafilesAsPng(true);
    // บันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกเป็น XPS ลงสตรีมแทนไฟล์ได้หรือไม่?**

ได้ – Aspose.Slides ให้คุณส่งออกโดยตรงเป็นสตรีม ซึ่งเหมาะสำหรับ Web API, พายป์ไลน์ด้านเซิร์ฟเวอร์ หรือสถานการณ์ใด ๆ ที่ต้องการส่ง XPS โดยไม่ต้องเข้าถึงระบบไฟล์

**สไลด์ที่ซ่อนจะถูกแปลงเป็น XPS หรือไม่ และฉันสามารถละเว้นสไลด์เหล่านั้นได้หรือไม่?**

โดยค่าเริ่มต้นจะเรนเดอร์เฉพาะสไลด์ที่มองเห็นได้ คุณสามารถ [include or exclude hidden slides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) ผ่าน [export settings](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีเพียงหน้าที่คุณต้องการเท่านั้น