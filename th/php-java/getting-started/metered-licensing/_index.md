---
title: การให้สิทธิ์แบบ Metered
type: docs
weight: 100
url: /th/php-java/metered-licensing/
keywords:
- ใบอนุญาต
- ใบอนุญาตแบบ Metered
- คีย์ใบอนุญาต
- คีย์สาธารณะ
- คีย์ส่วนตัว
- ปริมาณการใช้งาน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides สำหรับ PHP ผ่าน Java ด้วยการให้สิทธิ์แบบ Metered ช่วยให้คุณประมวลผลไฟล์ PowerPoint และ OpenDocument อย่างยืดหยุ่น โดยจ่ายเฉพาะในสิ่งที่คุณใช้."
---
## **บทนำ**

การให้สิทธิ์แบบ Metered เป็นกลไกการให้สิทธิ์ที่สามารถใช้ร่วมกับวิธีการให้สิทธิ์ที่มีอยู่ได้ หากคุณต้องการเรียกเก็บเงินตามการใช้งานคุณสมบัติของ Aspose.Slides API คุณเลือกใช้การให้สิทธิ์แบบ Metered

## **ใช้คีย์แบบจ่ายตามการใช้งาน**

เมื่อคุณซื้อใบอนุญาตแบบ Metered คุณจะได้รับคีย์ (ไม่ใช่ไฟล์ใบอนุญาต) คีย์แบบ Metered นี้สามารถนำไปใช้ได้โดยใช้คลาส [Metered](https://reference.aspose.com/slides/th/php-java/aspose.slides/metered/) ที่ Aspose จัดเตรียมไว้สำหรับการดำเนินการแบบ Metered รายละเอียดเพิ่มเติมดูที่ [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)

1. สร้างอินสแตนซ์ของคลาส [Metered](https://reference.aspose.com/slides/th/php-java/aspose.slides/metered/)

1. ส่งคีย์สาธารณะและคีย์ส่วนตัวของคุณไปยังเมธอด [setMeteredKey](https://reference.aspose.com/slides/th/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 

1. ทำการประมวลผลบางอย่าง (ดำเนินการงาน)

1. เรียกเมธอด [getConsumptionQuantity](https://reference.aspose.com/slides/th/php-java/aspose.slides/metered/#getConsumptionQuantity--) ของคลาส `Metered`

คุณควรจะเห็นจำนวน/ปริมาณคำขอ API ที่คุณใช้ไปจนถึงตอนนี้

ตัวอย่างโค้ดนี้แสดงวิธีใช้การให้สิทธิ์แบบ Metered:

```php
// สร้างอินสแตนซ์ของคลาส Metered
$metered = new Metered();

try {
    // ส่งคีย์สาธารณะและคีย์ส่วนตัวไปยังอ็อบเจ็กต์ Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // รับค่าปริมาณการใช้งานก่อนการเรียก API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // ทำบางอย่างกับ Aspose.Slides API ที่นี่
    // ...

    // รับค่าปริมาณการใช้งานหลังการเรียก API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

เพื่อใช้การให้สิทธิ์แบบ Metered คุณต้องมีการเชื่อมต่ออินเทอร์เน็ตที่เสถียร เพราะกลไกการให้สิทธิ์ใช้อินเทอร์เน็ตเพื่อติดต่อกับบริการของเราตลอดเวลาและทำการคำนวณ

{{% /alert %}} 

## **FAQ**

**ฉันสามารถใช้ใบอนุญาตแบบ Metered ร่วมกับใบอนุญาตทั่วไป (แบบถาวรหรือชั่วคราว) ในแอปพลิเคชันเดียวกันได้หรือไม่?**

ได้ การให้สิทธิ์แบบ Metered เป็นกลไกเพิ่มเติมที่สามารถใช้ควบคู่กับ [วิธีการให้สิทธิ์](/slides/th/php-java/licensing/) ที่มีอยู่ คุณเลือกใช้กลไกใดเมื่อเริ่มแอปพลิเคชัน

**อะไรเป็นตัวนับการใช้งานภายใต้ใบอนุญาตแบบ Metered: การดำเนินการหรือไฟล์?**

การใช้งาน API จะถูกนับหมายถึงจำนวนคำขอหรือการดำเนินการ คุณสามารถรับค่าการใช้งานปัจจุบันได้ผ่าน [เมธอดติดตามการใช้งาน](https://reference.aspose.com/slides/th/php-java/aspose.slides/metered/)

**การให้สิทธิ์แบบ Metered เหมาะกับสภาพแวดล้อมไมโครเซอร์วิสและเซิร์ฟเวอร์เลสที่อินสแตนซ์รีสตาร์ทบ่อยหรือไม่?**

ได้ เนื่องจากการคำนวณทำที่ระดับการเรียก API สถานการณ์ที่มีการเริ่มต้นใหม่บ่อย ๆ ยังเข้ากันได้ ตราบใดที่มีการเข้าถึงเครือข่ายที่เสถียรสำหรับการคำนวณแบบ Metered

**ฟังก์ชันของไลบรารีต่างกันอย่างไรเมื่อใช้ใบอนุญาตแบบ Metered เทียบกับใบอนุญาตแบบถาวร?**

ไม่มี ความแตกต่างจะอยู่ที่กลไกการให้สิทธิ์และการเรียกเก็บเงินเท่านั้น ความสามารถของผลิตภัณฑ์ยังคงเหมือนเดิม

**การให้สิทธิ์แบบ Metered เกี่ยวข้องกับเวอร์ชันทดลองและใบอนุญาตชั่วคราวอย่างไร?**

เวอร์ชันทดลองมีข้อจำกัดและลายน้ำ [ใบอนุญาตชั่วคราว](https://purchase.aspose.com/temporary-license/) ยกเลิกข้อจำกัดเป็นเวลา 30 วัน ส่วน Metered ยกเลิกข้อจำกัดและคิดค่าใช้จ่ายตามการใช้งานจริง

**ฉันสามารถควบคุมงบประมาณโดยตอบสนองอัตโนมัติเมื่อเกินเกณฑ์การใช้งานได้หรือไม่?**

ได้ การปฏิบัติทั่วไปคืออ่านค่าการใช้งานปัจจุบันเป็นระยะ ๆ ผ่าน [เมธอดติดตาม](https://reference.aspose.com/slides/th/php-java/aspose.slides/metered/) แล้วกำหนดขีดจำกัดหรือการแจ้งเตือนของคุณเองในระดับแอปพลิเคชันหรือการมอนิเตอร์