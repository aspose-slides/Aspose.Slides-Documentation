---
title: แปลงงานนำเสนอ OpenDocument ใน Python
linktitle: แปลง OpenDocument
type: docs
weight: 10
url: /th/python-java/convert-openoffice-odp/
keywords:
- แปลง ODP
- ODP เป็น PDF
- ODP เป็น HTML
- ODP เป็น TIFF
- ODP เป็น PPT
- ODP เป็น PPTX
- ODP เป็น XPS
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ OpenDocument (ODP) เป็น PDF, HTML และรูปแบบอื่น ๆ ด้วย Aspose.Slides for Python ผ่าน Java โดยไม่ต้องติดตั้ง OpenOffice หรือ LibreOffice."
---
## **บทนำ**

Aspose.Slides for Python via Java ช่วยให้คุณแปลงงานนำเสนอ OpenDocument (ODP) ไปเป็นรูปแบบต่าง ๆ เช่น PDF, HTML, TIFF, XPS, PPT และ PPTX การแปลง ODP ใช้ API เดียวกับการแปลง PowerPoint: โหลดไฟล์ต้นฉบับด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และเลือกรูปแบบผลลัพธ์ด้วย [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/)  

## **แปลง ODP เป็น PDF**

ทำตาม [คำแนะนำการติดตั้ง](/slides/th/python-java/installation/) ก่อนเรียกใช้ตัวอย่าง วางงานนำเสนอ ODP ชื่อ `pres.odp` ไว้ในไดเรกทอรีทำงาน โค้ดต่อไปนี้จะเริ่ม JVM หากจำเป็น โหลดงานนำเสนอและบันทึกเป็น `pres.pdf`  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **งานนำเสนอ OpenDocument ในแอปพลิเคชันต่าง ๆ**

งานนำเสนอ ODP อาจแสดงผลต่างกันใน PowerPoint และ LibreOffice/OpenOffice Impress เนื่องจากแอปพลิเคชันเหล่านี้สนับสนุนคุณลักษณะและพฤติกรรมการเรนเดอร์ที่แตกต่างกัน ควรตรวจสอบงานนำเสนอที่แปลงแล้วเมื่อเค้าโครงของมันพึ่งพาการจัดรูปแบบที่ซับซ้อน  

ความแตกต่างด้านความเข้ากันได้อาจส่งผลต่อ:

- ตาราง รวมถึงลำดับการซ้อนกันของตารางเมื่อเทียบกับรูปร่างอื่น ๆ และการรองรับการเติมภาพ
- การหมุนและการจัดแนวข้อความ
- การเติมรูปภาพ, การไล่สีระดับสี, และลวดลายที่ใช้กับข้อความ
- รายการแบบมีลำดับและรายการแบบหัวข้อย่อย  

รูปภาพด้านล่างแสดงรายการที่สร้างใน LibreOffice Impress:

![ตัวอย่างรายการ ODP ใน LibreOffice Impress](odp-list-example.png)

Aspose.Slides จะบันทึกรายการ ODP เพื่อความเข้ากันได้กับ LibreOffice/OpenOffice Impress  

สำหรับรายละเอียดเกี่ยวกับความเข้ากันได้ของคุณลักษณะดู [คู่มือของ Microsoft เกี่ยวกับรูปแบบ OpenDocument Presentation](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)  

## **คำถามที่พบบ่อย**

**หากการจัดรูปแบบของไฟล์ ODP ของฉันเปลี่ยนแปลงหลังจากการแปลงจะเกิดอะไรขึ้น?**  
ODP และ PowerPoint ใช้โมเดลงานนำเสนอที่แตกต่างกัน ตาราง, แบบอักษรและสไตล์การเติมอาจแสดงผลต่างกัน ตรวจสอบว่าแบบอักษรที่จำเป็นมีอยู่ ตรวจสอบผลลัพธ์ และปรับเค้าโครงหรือการจัดรูปแบบหากจำเป็น  

**ฉันต้องติดตั้ง OpenOffice หรือ LibreOffice เพื่อแปลงไฟล์ ODP หรือไม่?**  
ไม่จำเป็น Aspose.Slides for Python via Java ประมวลผลงานนำเสนอโดยไม่ต้องใช้แอปพลิเคชันเหล่านั้น ต้องมี Java runtime ที่เข้ากันได้และแพคเกจ Python  

**ฉันสามารถปรับแต่งการออก PDF เมื่อแปลงงานนำเสนอ ODP ได้หรือไม่?**  
ได้ ใช้ [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อกำหนดค่าการส่งออก PDF เช่น คุณภาพภาพและการบีบอัด  

**ฉันสามารถแปลงงานนำเสนอ ODP บนเซิร์ฟเวอร์หรือในคอนเทนเนอร์ได้หรือไม่?**  
ได้ ติดตั้งแพคเกจ Python, Java runtime ที่เข้ากันได้ และแบบอักษรที่งานนำเสนอของคุณต้องการในสภาพแวดล้อมเป้าหมาย ไม่จำเป็นต้องมีแอปพลิเคชันสำนักงาน  