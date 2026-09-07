---
title: แปลงงานนำเสนอ PowerPoint เป็น XPS ด้วย Python
linktitle: PowerPoint ไปยัง XPS
type: docs
weight: 70
url: /th/python-java/convert-powerpoint-to-xps/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปยัง XPS
- งานนำเสนอไปยัง XPS
- PPT ไปยัง XPS
- PPTX ไปยัง XPS
- บันทึก PPT เป็น XPS
- บันทึก PPTX เป็น XPS
- ส่งออก PPT เป็น XPS
- ส่งออก PPTX เป็น XPS
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint PPT และ PPTX เป็น XPS ด้วย Python โดยใช้ Aspose.Slides for Python via Java พร้อมการตั้งค่าเริ่มต้นหรือการตั้งค่าส่งออกแบบกำหนดเอง."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ให้คุณแปลงงานนำเสนอ PowerPoint เป็น XPS โดยบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อใดที่ XPS จะเป็นประโยชน์และแสดงวิธีการส่งออกงานนำเสนอโดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่าแบบกำหนดเองของ [XpsOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xpsoptions/)  

## **เกี่ยวกับ XPS**

XPS (XML Paper Specification) เป็นรูปแบบเอกสารที่ใช้ XML ซึ่งพัฒนาโดย Microsoft มันอธิบายหน้าที่คงที่โดยรักษาการจัดวางของข้อความและกราฟิกสำหรับการดูและการพิมพ์ด้วยซอฟต์แวร์ที่รองรับ  

## **เมื่อใดที่ควรใช้รูปแบบ XPS ของ Microsoft**

ใช้ XPS เมื่อกระบวนการทำงานของเอกสารต้องการไฟล์ที่มีการจัดวางคงที่สำหรับการแชร์หรือพิมพ์ผ่านเครื่องมือที่รองรับ XPS ผู้รับต้องมีซอฟต์แวร์ที่สนับสนุน XPS หากกระบวนการทำงานของคุณต้องการ PDF แทน ให้ดูที่ [Convert PowerPoint to PDF](/slides/th/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

เพื่อทดลองแปลงงานนำเสนอ PPT หรือ PPTX เป็น XPS ให้ใช้ [ตัวแปลงออนไลน์ฟรี](https://products.aspose.app/slides/th/conversion).

{{% /alert %}}

| งานนำเสนอ PowerPoint อินพุต | เอกสาร XPS เอาต์พุต |
| --- | --- |
| ![งานนำเสนอ PowerPoint ดั้งเดิม](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![งานนำเสนอที่แปลงเป็น XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **การแปลง XPS ด้วย Aspose.Slides**

ใช้เมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) กับ [SaveFormat.Xps](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Xps) เพื่อส่งออกงานนำเสนอ คุณสามารถใช้การตั้งค่าการส่งออกเริ่มต้นหรือระบุ [XpsOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xpsoptions/) เพื่อปรับแต่งผลลัพธ์  

แต่ละตัวอย่างด้านล่างจะเริ่มเครื่องเสมือน Java หากจำเป็นและปล่อยงานนำหลังการใช้งาน เปลี่ยนชื่อไฟล์อินพุตเป็นพาธไปยังไฟล์ PPT หรือ PPTX ของคุณ  

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

โค้ด Python ต่อไปนี้จะทำการแปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # บันทึกงานนำเสนอเป็นเอกสาร XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าแบบกำหนดเอง**

ตัวอย่างต่อไปนี้ใช้ [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/th/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) เพื่อบันทึกเมตาไฟล์เป็นภาพ PNG ในเอกสาร XPS ที่สร้างขึ้น:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # บันทึกงานนำเสนอด้วยการตั้งค่า XPS แบบกำหนดเอง.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึก XPS ลงในสตรีมแทนไฟล์ได้หรือไม่?**

ได้. เมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) มี overload ที่รับสตรีมออกของ Java. ด้วย Python ผ่าน Java ให้ใช้สตรีม Java ที่เข้ากันได้ผ่าน JPype เช่น Java byte-array output stream เพื่อเก็บข้อมูลที่ส่งออกในหน่วยความจำ  

**สไลด์ที่ซ่อนไว้จะถูกรวมในผลลัพธ์ XPS หรือไม่?**

สไลด์ที่ซ่อนไว้จะถูกตัดออกโดยค่าเริ่มต้น เพื่อรวมสไลด์เหล่านั้น ให้ตั้งค่า [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) เป็น `True` ก่อนบันทึก  

**การเคลื่อนไหวและการเปลี่ยนสไลด์จะถูกเก็บไว้ใน XPS หรือไม่?**

ไม่. XPS มีหน้าคงที่ ดังนั้นสไลด์ที่ส่งออกจะไม่เล่นการเคลื่อนไหหรือเอฟเฟกต์การเปลี่ยน  