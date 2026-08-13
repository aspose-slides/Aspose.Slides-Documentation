---
title: การให้สิทธิ์แบบมีมิเตอร์
type: docs
weight: 100
url: /th/java/metered-licensing/
keywords:
- ใบอนุญาต
- ใบอนุญาตแบบมีมิเตอร์
- คีย์การให้สิทธิ์
- คีย์สาธารณะ
- คีย์ส่วนตัว
- ปริมาณการใช้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides สำหรับ Java ที่ใช้การให้สิทธิ์แบบมีมิเตอร์ช่วยให้คุณประมวลผลไฟล์ PowerPoint และ OpenDocument อย่างยืดหยุ่น โดยจ่ายเฉพาะสิ่งที่คุณใช้"
---
## **บทนำ**

การให้สิทธิ์แบบมีมิเตอร์เป็นกลไกการให้สิทธิ์ที่สามารถใช้ร่วมกับวิธีการให้สิทธิ์ที่มีอยู่ได้ หากคุณต้องการให้คิดค่าใช้จ่ายตามการใช้คุณลักษณะของ Aspose.Slides API คุณเลือกการให้สิทธิ์แบบมีมิเตอร์

## **ใช้คีย์แบบมีมิเตอร์**

{{% alert color="info" %}} 

การให้สิทธิ์แบบมีมิเตอร์เป็นกลไกการให้สิทธิ์ใหม่ที่สามารถใช้ร่วมกับวิธีการให้สิทธิ์ที่มีอยู่ได้ หากคุณต้องการให้คิดค่าใช้จ่ายตามการใช้คุณลักษณะของ Aspose.Slides API คุณเลือกการให้สิทธิ์แบบมีมิเตอร์

เมื่อคุณซื้อใบอนุญาตแบบมีมิเตอร์ คุณจะได้รับคีย์ (และไม่ใช่ไฟล์ใบอนุญาต) คีย์แบบมีมิเตอร์นี้สามารถนำไปใช้ได้โดยใช้คลาส [Metered](https://reference.aspose.com/slides/th/java/com.aspose.slides/metered/) ที่ Aspose จัดให้สำหรับการทำงานแบบมีมิเตอร์ สำหรับรายละเอียดเพิ่มเติม ดูที่ [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. สร้างอินสแตนซ์ของคลาส [Metered](https://reference.aspose.com/slides/th/java/com.aspose.slides/metered/)

1. ส่งคีย์สาธารณะและคีย์ส่วนตัวของคุณไปยังเมธอด [setMeteredKey](https://reference.aspose.com/slides/th/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-)

1. ทำการประมวลผลบางอย่าง (ดำเนินการงาน)

1. เรียกเมธอด [getConsumptionQuantity](https://reference.aspose.com/slides/th/java/com.aspose.slides/metered/#getConsumptionQuantity--) ของคลาส `Metered`

คุณควรเห็นจำนวน/ปริมาณของคำขอ API ที่คุณได้ใช้ไปจนถึงตอนนี้

โค้ดตัวอย่างนี้แสดงวิธีการใช้การให้สิทธิ์แบบมีมิเตอร์:

```java
// สร้างอินสแตนซ์ของคลาส Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // ส่งคีย์สาธารณะและคีย์ส่วนตัวไปยังอ็อบเจ็กต์ Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // รับค่าปริมาณการใช้งานก่อนการเรียก API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // ทำบางอย่างด้วย Aspose.Slides API ที่นี่
    // ...

    // รับค่าปริมาณการใช้งานหลังจากการเรียก API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

เพื่อใช้การให้สิทธิ์แบบมีมิเตอร์ คุณต้องมีการเชื่อมต่ออินเทอร์เน็ตที่เสถียร เนื่องจากกลไกการให้สิทธิ์ใช้อินเทอร์เน็ตในการโต้ตอบกับบริการของเราอย่างต่อเนื่องและทำการคำนวณ

{{% /alert %}} 

## **คำถามที่พบบ่อย**

### ฉันสามารถใช้ใบอนุญาตแบบมีมิเตอร์พร้อมกับใบอนุญาตปกติ (ถาวรหรือชั่วคราว) ในแอปพลิเคชันเดียวกันได้หรือไม่?

ใช่ การให้สิทธิ์แบบมีมิเตอร์เป็นกลไกการให้สิทธิ์เพิ่มเติมที่สามารถใช้ร่วมกับ [วิธีการให้สิทธิ์](/slides/th/java/licensing/) ที่มีอยู่ได้ คุณเลือกกลไกที่จะใช้เมื่อแอปพลิเคชันเริ่มทำงาน

### สิ่งใดที่นับเป็นการใช้ตามใบอนุญาตแบบมีมิเตอร์: การดำเนินการหรือไฟล์?

การใช้ API จะถูกนับหมายถึงจำนวนคำขอหรือการดำเนินการ คุณสามารถรับการใช้ปัจจุบันผ่าน [consumption-tracking methods](https://reference.aspose.com/slides/th/java/com.aspose.slides/metered/)

### การให้สิทธิ์แบบมีมิเตอร์เหมาะกับไมโครเซอร์วิสและสภาพแวดล้อมแบบ serverless ที่อินสแตนซ์รีสตาร์ทบ่อยหรือไม่?

ใช่ เนื่องจากการบัญชีทำในระดับการเรียก API สถานการณ์ที่มีการเริ่มต้นใหม่บ่อยจึงเข้ากันได้ โดยต้องมีการเข้าถึงเครือข่ายที่เสถียรสำหรับการคำนวณแบบมีมิเตอร์

### ฟังก์ชันของไลบรารีแตกต่างกันเมื่อใช้ใบอนุญาตแบบมีมิเตอร์เทียบกับใบอนุญาตถาวรหรือไม่?

ไม่ นี่เป็นเพียงเรื่องของกลไกการให้สิทธิ์และการคิดค่าใช้จ่าย; ความสามารถของผลิตภัณฑ์ถือเหมือนเดิม

### การให้สิทธิ์แบบมีมิเตอร์สัมพันธ์กับรุ่นทดลองและใบอนุญาตชั่วคราวอย่างไร?

รุ่นทดลองมีข้อจำกัดและลายน้ำ, [ใบอนุญาตชั่วคราว](https://purchase.aspose.com/temporary-license/) จะลบข้อจำกัดเป็นเวลา 30 วัน, และการให้สิทธิ์แบบมีมิเตอร์จะลบข้อจำกัดและเรียกเก็บตามการใช้งานจริง

### ฉันสามารถควบคุมงบประมาณโดยตอบสนองอัตโนมัติเมื่อเกินเกณฑ์การใช้หรือไม่?

ใช่ การปฏิบัติทั่วไปคืออ่านการใช้ปัจจุบันเป็นระยะ ๆ ผ่าน [tracking methods](https://reference.aspose.com/slides/th/java/com.aspose.slides/metered/) แล้วกำหนดขีดจำกัดหรือการแจ้งเตือนของคุณเองในระดับแอปพลิเคชันหรือการตรวจสอบ