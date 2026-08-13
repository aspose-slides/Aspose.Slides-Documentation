---
title: แปลงงานนำเสนอ PowerPoint เป็น XPS บน Android
linktitle: PowerPoint เป็น XPS
type: docs
weight: 70
url: /th/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็นไฟล์ XPS คุณภาพสูงและไม่ขึ้นกับแพลตฟอร์มใน Java ด้วย Aspose.Slides สำหรับ Android. รับคู่มือขั้นตอนต่อขั้นตอนและตัวอย่างโค้ด."
---
## **ภาพรวม**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint เป็น XPS โดยการบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อใดที่รูปแบบ XPS อาจมีประโยชน์และแสดงวิธีการทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่าแบบกำหนดเองของ [XpsOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions/)  

## **เกี่ยวกับ XPS**
Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกของ [PDF](https://docs.fileformat.com/pdf/)  มันช่วยให้คุณพิมพ์เนื้อหาโดยส่งออกไฟล์ที่คล้ายกับ PDF มาก XPS มีพื้นฐานบน XML โครงสร้างหรือรูปแบบของไฟล์ XPS จะคงเดิมบนทุกระบบปฏิบัติการและเครื่องพิมพ์  

## **เมื่อใดควรใช้รูปแบบ Microsoft XPS**

{{% alert color="info" %}} 

เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PPT หรือ PPTX เป็นรูปแบบ XPS อย่างไร คุณสามารถตรวจสอบได้ที่ [แอปแปลงออนไลน์ฟรีนี้](https://products.aspose.app/slides/th/conversion). 

{{% /alert %}} 

หากคุณต้องการลดค่าใช้จ่ายในการจัดเก็บ คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint ของคุณเป็นรูปแบบ XPS ได้ วิธีนี้ทำให้คุณบันทึก แชร์ และพิมพ์เอกสารได้ง่ายขึ้น  

Microsoft ยังคงให้การสนับสนุน XPS อย่างแข็งแกร่งใน Windows (รวมถึง Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์เป็นรูปแบบนี้ หากคุณใช้ Windows 8.1, Windows 8, Windows 7 หรือ Windows Vista XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับบางการทำงาน  

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันมาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 ให้การสนับสนุนไฟล์ XPS ดีกว่าไฟล์ PDF  
  - **XPS:** มีตัวดู/อ่าน XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS พร้อมใช้งาน  
  - **PDF:** มีตัวอ่าน PDF แต่ไม่มีฟีเจอร์การพิมพ์เป็น PDF  

- **Windows 7** และ **Windows Vista** ใช้รูปแบบ XPS ดั้งเดิม ระบบปฏิบัติการเหล่านี้ให้การสนับสนุนไฟล์ XPS ดีกว่า PDF ด้วย  
  - **XPS:** มีตัวดู XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS พร้อมใช้งาน  
  - **PDF:** ไม่มีตัวอ่าน PDF ไม่มีฟีเจอร์การพิมพ์เป็น PDF  

|<p>**อินพุต PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**ผลลัพธ์ XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft สุดท้ายได้เพิ่มการสนับสนุนการพิมพ์ใน PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านั้นผู้ใช้คาดว่าจะพิมพ์เอกสารผ่านรูปแบบ XPS  

## **การแปลง XPS ด้วย Aspose.Slides**

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/androidjava/) สำหรับ Java คุณสามารถใช้เมธอด [**Save**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร XPS  

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้หนึ่งในการตั้งค่าต่อไปนี้:  

- ตั้งค่าเริ่มต้น (โดยไม่ได้ใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions))  
- การตั้งค่าแบบกำหนดเอง (โดยใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions))  

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

โค้ดตัวอย่างนี้ใน Java แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ามาตรฐาน:

```java
import com.aspose.slides.*;

// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // กำลังบันทึกงานนำเสนอเป็นเอกสาร XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าแบบกำหนดเอง**
โค้ดตัวอย่างนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่าแบบกำหนดเองใน Java:

```java
import com.aspose.slides.*;

// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // สร้างอ็อบเจ็กต์ XpsOptions
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

### สามารถบันทึกเป็น XPS ลงในสตรีมแทนไฟล์ได้หรือไม่?

ได้—Aspose.Slides ให้คุณส่งออกโดยตรงไปยังสตรีม ซึ่งเหมาะกับ API เว็บ, พายไลน์ฝั่งเซิร์ฟเวอร์ หรือกรณีใด ๆ ที่ต้องการส่ง XPS โดยไม่ต้อง Touch ระบบไฟล์  

### สไลด์ที่ซ่อนอยู่จะถูกแปลงเป็น XPS หรือไม่และฉันสามารถยกเว้นได้หรือไม่?

โดยค่าเริ่มต้นจะเรนเดอร์เฉพาะสไลด์ที่มองเห็นได้ คุณสามารถ [รวมหรือยกเว้นสไลด์ที่ซ่อนอยู่](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) ผ่าน [ตั้งค่า export](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีเพียงหน้าที่คุณต้องการเท่านั้น.