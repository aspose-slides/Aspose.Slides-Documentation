---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG บน Android
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- บันทึก PPT เป็น SVG
- บันทึก PPTX เป็น SVG
- ส่งออก PPT เป็น SVG
- ส่งออก PPTX เป็น SVG
- เรนเดอร์สไลด์
- แปลงสไลด์
- ส่งออกสไลด์
- ภาพเวกเตอร์
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเรนเดอร์สไลด์ PowerPoint เป็นภาพ SVG ด้วย Aspose.Slides สำหรับ Android ภาพคุณภาพสูงพร้อมตัวอย่างโค้ด Java อย่างง่าย"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ด้วย Aspose.Slides มันอธิบายรูปแบบ SVG และข้อดีของมัน รวมถึงความสามารถในการขยายตัว ความเข้าถึงได้ และความเหมาะสมสำหรับการพัฒนาเว็บ

คุณจะได้เรียนรู้วิธีการโหลดไฟล์การนำเสนอ, วนผ่านสไลด์ทั้งหมด, และบันทึกแต่ละสไลด์เป็นไฟล์ SVG แยกต่างหาก บทความครอบคลุมรูปแบบการนำเสนอ PowerPoint และ OpenDocument ได้แก่ PPT, PPTX, ODP, และ PPS และแสดงวิธีการทำการแปลงโดยใช้โปรแกรมด้วยคลาส `Presentation` และเมธอด `writeAsSvg`

## **รูปแบบ SVG**

SVG—ย่อมาจาก Scalable Vector Graphics—เป็นประเภทหรือรูปแบบกราฟิกมาตรฐานที่ใช้ในการเรนเดอร์ภาพสองมิติ SVG จะเก็บภาพเป็นเวกเตอร์ใน XML พร้อมรายละเอียดที่กำหนดพฤติกรรมหรือรูปลักษณ์ของภาพ

SVG เป็นหนึ่งในจำนวนไม่กี่รูปแบบของภาพที่ตอบสนองมาตรฐานสูงในแง่ของความสามารถในการขยายตัว, การโต้ตอบ, ประสิทธิภาพ, การเข้าถึง, ความสามารถในการเขียนโปรแกรม, และอื่น ๆ ด้วยเหตุผลเหล่านี้จึงมักใช้ในการพัฒนาเว็บ

คุณอาจต้องการใช้ไฟล์ SVG เมื่อคุณต้องการ

- **พิมพ์การนำเสนอของคุณในรูปแบบ *ขนาดใหญ่มาก*.** SVG สามารถขยายได้ถึงความละเอียดหรือระดับใดก็ได้ คุณสามารถปรับขนาดภาพ SVG ซ้ำได้หลายครั้งโดยไม่เสียคุณภาพ
- **ใช้แผนภูมิและกราฟจากสไลด์ของคุณใน *สื่อหรือแพลตฟอร์มที่ต่างกัน*.* ผู้อ่านส่วนใหญ่สามารถตีความไฟล์ SVG ได้
- **ใช้ขนาด *ที่เล็กที่สุดเท่าที่เป็นไปได้* ของภาพ***. ไฟล์ SVG โดยทั่วไปมีขนาดเล็กกว่าค่าความละเอียดสูงในรูปแบบอื่น ๆ โดยเฉพาะรูปแบบที่อิงบิทแมพ (JPEG หรือ PNG)

## **เรนเดอร์สไลด์เป็นภาพ SVG**

Aspose.Slides for Android via Java ช่วยให้คุณสามารถส่งออกสไลด์ในงานนำเสนอของคุณเป็นภาพ SVG ทำตามขั้นตอนต่อไปนี้เพื่อสร้างภาพ SVG:

1. สร้างอินสแตนซ์ของคลาส `Presentation`.
2. วนผ่านสไลด์ทั้งหมดในงานนำเสนอ.
3. เขียนสไลด์แต่ละอันไปยังไฟล์ SVG ของมันเองโดยใช้ `FileOutputStream`.

{{% alert color="primary" %}} 
คุณอาจต้องการลองใช้[แอปพลิเคชันเว็บฟรีของเรา](https://products.aspose.app/slides/th/conversion/ppt-to-svg) ซึ่งเราได้ทำการนำฟังก์ชันการแปลง PPT เป็น SVG จาก Aspose.Slides for Android via Java ไปใช้
{{% /alert %}} 

โค้ดตัวอย่างนี้ใน Java แสดงวิธีการแปลง PPT เป็น SVG ด้วย Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ทำไม SVG ที่ได้อาจดูแตกต่างกันในแต่ละเบราว์เซอร์?**

การสนับสนุนคุณลักษณะเฉพาะของ SVG ถูกนำไปใช้แตกต่างกันโดยเอนจินของเบราว์เซอร์ [SVGOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/) พารามิเตอร์ช่วยลดความไม่เข้ากัน

**สามารถส่งออกไม่เพียงสไลด์เท่านั้น แต่รวมถึงรูปทรงเฉพาะเป็น SVG ได้หรือไม่?**

ได้. ทุก [shape สามารถบันทึกเป็น SVG แยกได้](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) ซึ่งสะดวกสำหรับไอคอน, พิกโทแกรม, และการนำภาพกลับมาใช้ใหม่

**สามารถรวมหลายสไลด์เป็น SVG เดียว (แถบ/เอกสาร) ได้หรือไม่?**

สถานการณ์มาตรฐานคือ สไลด์หนึ่ง → SVG หนึ่ง การรวมหลายสไลด์เป็นผ้าใบ SVG เดียวเป็นขั้นตอนการประมวลผลภายหลังที่ทำระดับแอปพลิเคชัน