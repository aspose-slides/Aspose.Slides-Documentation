---
title: ส่งออกแผนภูมิการนำเสนอใน Python ผ่าน Java
linktitle: ส่งออกแผนภูมิ
type: docs
weight: 90
url: /th/python-java/export-chart/
keywords:
- แผนภูมิ
- แผนภูมิเพื่อเป็นภาพ
- แผนภูมิเป็นภาพ
- สกัดภาพแผนภูมิ
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีส่งออกแผนภูมิการนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java รองรับรูปแบบ PPT และ PPTX และทำให้การรายงานเป็นกระบวนการทำงานที่ไหลราบรื่นในทุก workflow."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณส่งออกแผนภูมิจากงานนำเสนอเป็นภาพ บทความนี้แสดงวิธีดึงภาพจากแผนภูมิและบันทึก ซึ่งมีประโยชน์เมื่อคุณต้องการใช้ภาพแผนภูมิซ้ำนอกงานนำเสนอ PowerPoint  

นอกเหนือจากกระบวนการส่งออกภาพพื้นฐานแล้ว บทความนี้ยังตอบคำถามที่พบบ่อยเกี่ยวกับการส่งออก รวมถึงการบันทึกเนื้อหาแผนภูมิเป็น SVG การควบคุมขนาดผลลัพธ์ด้วยตัวเลือกการเรนเดอร์ การโหลดฟอนต์เพื่อรักษาลักษณะของป้ายและคำอธิบาย และการรักษาการจัดรูปแบบต้นฉบับของงานนำเสนอ เช่น ธีม สไตล์ การเติมสี และเอฟเฟกต์ระหว่างการเรนเดอร์  

## **รับภาพแผนภูมิ**
Aspose.Slides for Python via Java รองรับการสกัดภาพของแผนภูมิที่กำหนด ตัวอย่างต่อไปนี้แสดงวิธีทำ  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถส่งออกแผนภูมิเป็นเวกเตอร์ (SVG) แทนภาพเรสเตอร์ได้หรือไม่?**  
ใช่ แผนภูมิเป็นรูปแบบหนึ่งและเนื้อหาของมันสามารถบันทึกเป็น SVG ได้โดยใช้ [วิธีการบันทึก shape-to-SVG](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**ฉันจะตั้งขนาดที่แน่นอนของแผนภูมิที่ส่งออกในหน่วยพิกเซลได้อย่างไร?**  
ใช้การเรียกซ้อนของ image-rendering ที่ให้คุณระบุขนาดหรือสเกล — ไลบรารีรองรับการเรนเดอร์ออบเจกต์ด้วยมิติหรือสเกลที่กำหนด

**ควรทำอย่างไรหากฟอนต์ในป้ายและคำอธิบายแสดงผลไม่ถูกต้องหลังการส่งออก?**  
[โหลดฟอนต์ที่จำเป็น](/slides/th/python-java/custom-font/) ผ่าน [FontsLoader](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/) เพื่อให้การเรนเดอร์แผนภูมิรักษาเมตริกและลักษณะข้อความ

**การส่งออกเคารพธีม สไตล์ และเอฟเฟกต์ของ PowerPoint หรือไม่?**  
ใช่ ตัวเรนเดอร์ของ Aspose.Slides ปฏิบัติตามการจัดรูปแบบของงานนำเสนอ (ธีม, สไตล์, การเติมสี, เอฟเฟกต์) ดังนั้นลักษณะของแผนภูมิจึงถูกเก็บไว้

**ฉันสามารถค้นหาความสามารถการเรนเดอร์/ส่งออกที่มีเพิ่มเติมนอกเหนือจากภาพแผนภูมิได้จากที่ไหน?**  
ดูที่ [API](https://reference.aspose.com/slides/th/python-java/aspose.slides/)/[เอกสาร](/slides/th/python-java/convert-powerpoint/) สำหรับเป้าหมายผลลัพธ์ ([PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/th/python-java/convert-powerpoint-to-xps/), [HTML](/slides/th/python-java/convert-powerpoint-to-html/), เป็นต้น) และตัวเลือกการเรนเดอร์ที่เกี่ยวข้อง