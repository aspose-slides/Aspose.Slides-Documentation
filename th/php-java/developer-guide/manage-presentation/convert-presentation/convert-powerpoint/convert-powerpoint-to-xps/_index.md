---
title: แปลงงานนำเสนอ PowerPoint เป็น XPS ใน PHP
linktitle: PowerPoint เป็น XPS
type: docs
weight: 70
url: /th/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น XPS คุณภาพสูงและไม่ขึ้นกับแพลตฟอร์มโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java รับคำแนะนำขั้นตอนต่อขั้นตอนและตัวอย่างโค้ด"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็น XPS โดยการบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อไหร่รูปแบบ XPS จะมีประโยชน์และแสดงวิธีการทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่า [XpsOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xpsoptions/) แบบกำหนดเอง

## **เกี่ยวกับ XPS**
Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกแทน [PDF](https://docs.fileformat.com/pdf/)  มันทำให้คุณพิมพ์เนื้อหาโดยสร้างไฟล์ที่คล้ายน PDF มาก รูปแบบ XPS ใช้ XML เป็นฐาน โครงสร้างหรือรูปแบบของไฟล์ XPS จะคงที่บนระบบปฏิบัติการและเครื่องพิมพ์ทั้งหมด

## **เมื่อใดควรใช้รูปแบบ XPS ของ Microsoft**

{{% alert color="primary" %}} 

เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PPT หรือ PPTX ไปเป็นรูปแบบ XPS อย่างไร คุณสามารถลองใช้ [แอปแปลงออนไลน์ฟรีนี้](https://products.aspose.app/slides/th/conversion)  

{{% /alert %}} 

หากคุณต้องการลดค่าใช้จ่ายในการจัดเก็บข้อมูล คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint ของคุณเป็นรูปแบบ XPS ซึ่งจะทำให้การบันทึก แบ่งปัน และพิมพ์เอกสารเป็นเรื่องง่ายขึ้น

Microsoft ยังคงให้การสนับสนุน XPS อย่างแข็งแกร่งใน Windows (รวมถึง Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์ในรูปแบบนี้ หากคุณกำลังใช้งาน Windows 8.1, Windows 8, Windows 7 และ Windows Vista XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับการดำเนินการบางอย่าง

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันมาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 ให้การสนับสนุนไฟล์ XPS ดีกว่าไฟล์ PDF  
  - **XPS:** มีโปรแกรมดู/อ่าน XPS ในตัวและฟีเจอร์พิมพ์เป็น XPS พร้อมใช้งาน  
  - **PDF:** มีโปรแกรมอ่าน PDF แต่ไม่มีฟีเจอร์พิมพ์เป็น PDF  

- **Windows 7 และ Windows Vista** ใช้รูปแบบ XPS ดั้งเดิม ระบบปฏิบัติการเหล่านี้ยังให้การสนับสนุนไฟล์ XPS ดีกว่า PDF ด้วย  
  - **XPS:** มีโปรแกรมดู XPS ในตัวและฟีเจอร์พิมพ์เป็น XPS พร้อมใช้งาน  
  - **PDF:** ไม่มีโปรแกรมอ่าน PDF และไม่มีฟีเจอร์พิมพ์เป็น PDF  

|<p>**ไฟล์ PPT(X) เข้า:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**ไฟล์ XPS ออก:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft สุดท้ายได้เพิ่มการสนับสนุนการพิมพ์ในรูปแบบ PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านี้ผู้ใช้คาดว่าจะพิมพ์เอกสารผ่านรูปแบบ XPS

## **การแปลง XPS ด้วย Aspose.Slides**

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/php-java/) สำหรับ Java คุณสามารถใช้เมธอด [**Save**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร XPS

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้การตั้งค่าหนึ่งในสองแบบนี้:

- การตั้งค่าเริ่มต้น (โดยไม่ใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/php-java/aspose.slides/xpsoptions))
- การตั้งค่าแบบกำหนดเอง (โดยใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/php-java/aspose.slides/xpsoptions))

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

ตัวอย่างโค้ดนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ามาตรฐาน:

```php
  # สร้างออบเจกต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # กำลังบันทึกงานนำเสนอเป็นเอกสาร XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าแบบกำหนดเอง**
ตัวอย่างโค้ดนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่าแบบกำหนดเอง :

```php
  # สร้างออบเจกต์ Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # สร้างออบเจกต์ของคลาส TiffOptions
    $options = new XpsOptions();
    # บันทึก MetaFiles เป็น PNG
    $options->setSaveMetafilesAsPng(true);
    # บันทึกงานนำเสนอเป็นเอกสาร XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกเป็น XPS ลงในสตรีมแทนไฟล์ได้ไหม?**

ได้—Aspose.Slides ให้คุณส่งออกโดยตรงไปยังสตรีม ซึ่งเหมาะกับ API เว็บ, กระบวนการฝั่งเซิร์ฟเวอร์ หรือสถานการณ์ใด ๆ ที่ต้องการส่ง XPS โดยไม่ต้องติดต่อระบบไฟล์

**สไลด์ที่ซ่อนอยู่จะถูกคัดลอกไปยัง XPS หรือไม่ และฉันสามารถเอาออกได้หรือไม่?**

โดยค่าเริ่มต้น จะเรนเดอร์เฉพาะสไลด์ที่แสดง (มองเห็น) เท่านั้น คุณสามารถ [รวมหรือตัดสไลด์ที่ซ่อนอยู่](https://reference.aspose.com/slides/th/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) ผ่าน [การตั้งค่า export](https://reference.aspose.com/slides/th/php-java/aspose.slides/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีเพียงหน้าที่คุณต้องการเท่านั้น