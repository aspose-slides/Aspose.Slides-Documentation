---
title: การให้สิทธิ์แบบ Metered
type: docs
weight: 90
url: /th/python-net/metered-licensing/
keywords:
  - ใบอนุญาต
  - ใบอนุญาตแบบ Metered
  - คีย์ใบอนุญาต
  - คีย์สาธารณะ
  - คีย์ส่วนตัว
  - ปริมาณการใช้
  - Python
  - Aspose.Slides
description: "เรียนรู้วิธีที่ Aspose.Slides สำหรับ Python ผ่าน .NET แบบ Metered Licensing ช่วยให้คุณประมวลผลไฟล์ PowerPoint และ OpenDocument อย่างยืดหยุ่นโดยจ่ายเฉพาะสิ่งที่ใช้."
---
## **บทนำ**

การให้สิทธิ์แบบ Metered เป็นกลไกการให้สิทธิ์ที่สามารถใช้ร่วมกับวิธีการให้สิทธิ์ที่มีอยู่ได้ หากคุณต้องการเรียกเก็บเงินตามการใช้คุณสมบัติของ Aspose.Slides API คุณควรเลือกการให้สิทธิ์แบบ Metered.

## **ใช้คีย์แบบ Metered**

{{% alert color="primary" %}} 

การให้สิทธิ์แบบ Metered เป็นกลไกการให้สิทธิ์ใหม่ที่สามารถใช้ร่วมกับวิธีการให้สิทธิ์ที่มีอยู่ได้ หากคุณต้องการเรียกเก็บเงินตามการใช้คุณสมบัติของ Aspose.Slides API คุณควรเลือกการให้สิทธิ์แบบ Metered.

เมื่อคุณซื้อใบอนุญาตแบบ Metered คุณจะได้คีย์ (ไม่ใช่ไฟล์ใบอนุญาต) คีย์ Metered นี้สามารถนำไปใช้ได้ด้วยคลาส [Metered](https://reference.aspose.com/slides/th/python-net/aspose.slides/metered/) ที่ Aspose จัดให้สำหรับการทำงานแบบมิตรีเมเตอร์ รายละเอียดเพิ่มเติมดูที่ [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. สร้างอินสแตนซ์ของคลาส [Metered](https://reference.aspose.com/slides/th/python-net/aspose.slides/metered/).
1. ส่งคีย์สาธารณะและคีย์ส่วนตัวของคุณไปยังเมธอด [set_metered_key](https://reference.aspose.com/slides/th/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. ทำการประมวลผลบางอย่าง (ดำเนินการงาน).
1. เรียกเมธอด [get_consumption_quantity](https://reference.aspose.com/slides/th/python-net/aspose.slides/metered/get_consumption_quantity/#) ของคลาส `Metered`.

คุณควรจะเห็นจำนวน/ปริมาณของคำขอ API ที่คุณได้ใช้ไปจนถึงตอนนี้.

โค้ดตัวอย่างนี้จะแสดงวิธีการใช้การให้สิทธิ์แบบ Metered:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Metered
metered = slides.Metered()

# ส่งคีย์สาธารณะและคีย์ส่วนตัวไปยังอ็อบเจ็กต์ Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# ดึงค่าปริมาณการใช้ก่อนทำการเรียก API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# ทำบางอย่างกับ Aspose.Slides API ที่นี่
# ...

# ดึงค่าปริมาณการใช้หลังทำการเรียก API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

เพื่อใช้การให้สิทธิ์แบบ Metered คุณต้องมีการเชื่อมต่ออินเทอร์เน็ตที่เสถียร เนื่องจากกลไกการให้สิทธิ์จะใช้อินเทอร์เน็ตในการโต้ตอบกับบริการของเราตลอดเวลาและทำการคำนวณ.

{{% /alert %}} 

## **FAQ**

**ฉันสามารถใช้ใบอนุญาตแบบ Metered ร่วมกับใบอนุญาตปกติ (แบบถาวรหรือชั่วคราว) ในแอปพลิเคชันเดียวกันได้หรือไม่?**

ได้. Metered เป็นกลไกการให้สิทธิ์เพิ่มเติมที่สามารถใช้ร่วมกับ [วิธีการให้สิทธิ์](/slides/th/python-net/licensing/) ที่มีอยู่ได้ คุณเลือกกลไกที่จะใช้เมื่อแอปพลิเคชันเริ่มทำงาน.

**สิ่งใดที่นับเป็นการใช้สิทธิ์ภายใต้ใบอนุญาตแบบ Metered อย่างแท้จริง: การดำเนินการหรือไฟล์?**

การใช้งาน API จะถูกนับ ซึ่งหมายถึงจำนวนคำขอหรือการดำเนินการ คุณสามารถรับข้อมูลการใช้ปัจจุบันได้ผ่าน [วิธีการติดตามการใช้](https://reference.aspose.com/slides/th/python-net/aspose.slides/metered/).

**การให้สิทธิ์แบบ Metered เหมาะกับสภาพแวดล้อม microservices และ serverless ที่อินสแตนซ์รีสตาร์ทบ่อยหรือไม่?**

ได้. เนื่องจากการคำนวณทำที่ระดับการเรียก API จึงเข้ากันได้กับสถานการณ์ที่มีการเริ่มต้นใหม่บ่อยครั้ง โดยต้องมีการเชื่อมต่อเครือข่ายที่เสถียรสำหรับการคำนวณแบบ Metered.

**ฟังก์ชันของไลบรารีแตกต่างกันเมื่อใช้ใบอนุญาตแบบ Metered กับใบอนุญาตถาวรหรือไม่?**

ไม่. นี่เป็นเพียงเรื่องของกลไกการให้สิทธิ์และการเรียกเก็บเงินเท่านั้น ความสามารถของผลิตภัณฑ์ยังคงเหมือนเดิม.

**การให้สิทธิ์แบบ Metered มีความสัมพันธ์อย่างไรกับเวอร์ชันทดลองและใบอนุญาตชั่วคราว?**

เวอร์ชันทดลองมีข้อจำกัดและลายน้ำ, [ใบอนุญาตชั่วคราว](https://purchase.aspose.com/temporary-license/) จะลบข้อจำกัดเป็นเวลา 30 วัน, ส่วน Metered จะลบข้อจำกัดและเรียกเก็บเงินตามการใช้งานจริง.

**ฉันสามารถควบคุมงบประมาณได้โดยการตอบสนองอัตโนมัติเมื่อเกินขีดจำกัดการใช้หรือไม่?**

ได้. วิธีปฏิบัติทั่วไปคืออ่านการใช้ปัจจุบันเป็นระยะเวลาผ่าน [วิธีการติดตาม]((https://reference.aspose.com/slides/th/python-net/aspose.slides/metered/)) แล้วกำหนดขีดจำกัดหรือแจ้งเตือนของคุณเองในระดับแอปพลิเคชันหรือการตรวจสอบ.