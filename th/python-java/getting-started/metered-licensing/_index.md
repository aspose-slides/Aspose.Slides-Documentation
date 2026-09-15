---
title: การให้สิทธิ์แบบ Metered
type: docs
weight: 100
url: /th/python-java/metered-licensing/
keywords:
- ใบอนุญาต
- ใบอนุญาตแบบ Metered
- คีย์ใบอนุญาต
- คีย์สาธารณะ
- คีย์ส่วนตัว
- ปริมาณการใช้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides for Python via Java ด้วยการให้สิทธิ์แบบ Metered ช่วยให้คุณประมวลผลไฟล์ PowerPoint และ OpenDocument อย่างยืดหยุ่น พร้อมจ่ายเฉพาะตามการใช้งานจริงเท่านั้น."
---
## **บทนำ**

การให้สิทธิ์แบบ Metered คือกลไกการให้สิทธิ์ซึ่งสามารถใช้ร่วมกับวิธีการให้สิทธิ์ที่มีอยู่ได้ หากคุณต้องการให้เรียกเก็บค่าบริการตามการใช้คุณสมบัติของ Aspose.Slides API ให้เลือกการให้สิทธิ์แบบ Metered

## **Apply Metered Keys**

{{% alert color="info" title="Note" %}}
การให้สิทธิ์แบบ Metered เป็นกลไกใหม่ที่สามารถใช้ร่วมกับวิธีการให้สิทธิ์ที่มีอยู่ได้ หากคุณต้องการให้เรียกเก็บค่าบริการตามการใช้คุณสมบัติของ Aspose.Slides API ให้เลือกการให้สิทธิ์แบบ Metered

เมื่อคุณซื้อใบอนุญาตแบบ Metered คุณจะได้รับคีย์ (ไม่ใช่ไฟล์ใบอนุญาต) คีย์ Metered นี้สามารถนำไปใช้ได้โดยใช้คลาส [Metered](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/) ที่ Aspose จัดให้สำหรับการดำเนินการ Metered สำหรับรายละเอียดเพิ่มเติม ดู [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}

1. สร้างอินสแตนซ์ของคลาส [Metered](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/)

2. ส่งคีย์สาธารณะและคีย์ส่วนตัวของคุณไปยังเมธอด [setMeteredKey](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/#setMeteredKey)

3. ทำการประมวลผลบางอย่าง (ดำเนินการงาน)

4. เรียกเมธอด [getConsumptionQuantity](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/#getConsumptionQuantity) ของคลาส [Metered](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/)

คุณจะเห็นจำนวน/ปริมาณการเรียก API ที่คุณได้ใช้ไปจนถึงขณะนี้

ตัวอย่างโค้ดด้านล่างนี้แสดงวิธีการใช้การให้สิทธิ์แบบ Metered:

```python
import jpype
import asposeslides

if not jpyle.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# สร้างอินสแตนซ์ของคลาส Metered.
metered = Metered()

try:
    # ส่งคีย์สาธารณะและคีย์ส่วนตัวไปยังอ็อบเจกต์ Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # รับปริมาณการใช้ก่อนการเรียก API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # ทำสิ่งใดสิ่งหนึ่งกับ Aspose.Slides API ที่นี่.
    # ...

    # รับปริมาณการใช้หลังการเรียก API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Warning"  %}}
หากต้องการใช้การให้สิทธิ์แบบ Metered คุณจำเป็นต้องมีการเชื่อมต่ออินเทอร์เน็ตที่เสถียร เพราะกลไกการให้สิทธิ์นี้ใช้อินเทอร์เน็ตเพื่อโต้ตอบกับบริการของเราอย่างต่อเนื่องและทำการคำนวณ
{{% /alert %}}

## **FAQ**

**ฉันสามารถใช้ใบอนุญาตแบบ Metered ร่วมกับใบอนุญาตปกติ (แบบถาวรหรือชั่วคราว) ในแอปพลิเคชันเดียวกันได้หรือไม่?**

ใช่ การให้สิทธิ์แบบ Metered เป็นกลไกเพิ่มเติมที่สามารถใช้ร่วมกับ [licensing methods](/slides/th/python-java/licensing/) ที่มีอยู่ คุณสามารถเลือกใช้กลไกใดเมื่อแอปพลิเคชันเริ่มทำงาน

**อะไรที่นับเป็นการใช้ภายใต้ใบอนุญาตแบบ Metered: การดำเนินการหรือไฟล์?**

การใช้งาน API จะถูกนับรวม ทั้งจำนวนคำขอหรือการดำเนินการ คุณสามารถดูการใช้ปัจจุบันได้ผ่าน [consumption‑tracking methods](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/)

**การให้สิทธิ์แบบ Metered เหมาะกับสภาพแวดล้อม microservices และ serverless ที่อินสแตนซ์รีสตาร์ทบ่อยหรือไม่?**

ใช่ เนื่องจากการคำนวณทำที่ระดับการเรียก API ทำให้สถานการณ์ที่มีการเริ่มต้นใหม่บ่อย ๆ สามารถใช้งานได้ หากมีการเชื่อมต่อเครือข่ายที่เสถียรสำหรับการคำนวณ Metered

**ฟังก์ชันของไลบรารีแตกต่างกันอย่างไรเมื่อใช้ใบอนุญาตแบบ Metered เทียบกับใบอนุญาตถาวร?**

ไม่มี ความแตกต่างนี้มีเพียงเรื่องของกลไกการให้สิทธิ์และการเรียกเก็บค่าใช้จ่าย; ความสามารถของผลิตภัณฑ์ยังคงเหมือนเดิม

**Metered เกี่ยวข้องอย่างไรกับรุ่นทดลองและใบอนุญาตชั่วคราว?**

รุ่นทดลองมีข้อจำกัดและลายน้ำ, [temporary license](https://purchase.aspose.com/temporary-license/) จะยกเลิกข้อจำกัดเป็นเวลา 30 วัน, และ Metered จะยกเลิกข้อจำกัดและเรียกเก็บตามการใช้งานจริง

**ฉันสามารถควบคุมงบประมาณโดยอัตโนมัติเมื่อตัวชี้วัดการใช้เกินเกณฑ์ได้หรือไม่?**

ใช่ การปฏิบัติบ่อย ๆ คือการอ่านการใช้ปัจจุบันผ่าน [tracking methods](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/) และกำหนดขีดจำกัดหรือแจ้งเตือนของคุณเองในระดับแอปพลิเคชันหรือระบบมอนิเตอร์