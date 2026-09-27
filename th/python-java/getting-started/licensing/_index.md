---
title: การให้ใบอนุญาต
type: docs
weight: 80
url: /th/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- ไฟล์ใบอนุญาต
- ใบอนุญาตชั่วคราว
- การให้ใบอนุญาตแบบมีมิเตอร์
- ข้อจำกัดของการประเมิน
description: "ใช้ใบอนุญาตแบบไฟล์, แบบไบต์, หรือแบบมีมิเตอร์ใน Aspose.Slides สำหรับ Python ผ่าน Java และกำจัดข้อจำกัดการประเมินจากแอปพลิเคชันของคุณ."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถทำงานในโหมดการประเมินหรือด้วยใบอนุญาตได้ ในโหมดการประเมิน มันจะเพิ่มกล่องข้อความลายน้ำการประเมินลงในสไลด์ทุกแผ่นของแต่ละงานนำเสนอที่บันทึกและตัดข้อความที่โค้ดของคุณอ่านจากงานนำเสนอ บทความนี้อธิบายวิธีการใช้ใบอนุญาตจากไฟล์หรือไบต์และวิธีการกำหนดค่าการให้ใบอนุญาตแบบมีมิเตอร์

สำหรับตัวเลือกการซื้อ ดูที่ [ข้อมูลการกำหนดราคา](https://purchase.aspose.com/pricing/slides/th/family) สำหรับคำถามทั่วไปเกี่ยวกับการให้ใบอนุญาตและการซื้อ ดูที่ [นโยบายการซื้อและคำถามที่พบบ่อย](https://purchase.aspose.com/policies)

สำหรับข้อจำกัดของการประเมินและวิธีขอใบอนุญาตชั่วคราว ดูที่ [ประเมิน Aspose.Slides](/slides/th/python-java/evaluate-aspose-slides/) ใช้ใบอนุญาตชั่วคราวในลักษณะเดียวกับไฟล์ใบอนุญาตที่ซื้อไว้

## **เกี่ยวกับใบอนุญาต**

ไฟล์ใบอนุญาตประกอบด้วยข้อมูลเช่น ชื่อผลิตภัณฑ์ จำนวนผู้พัฒนาที่ได้รับอนุญาต และวันหมดอายุการสมัครใช้งาน ไฟล์นี้เป็น XML ที่เซ็นดิจิทัล

{{% alert color="warning" title="Warning" %}}
ห้ามแก้ไขไฟล์ใบอนุญาต แม้แต่การเพิ่มบรรทัดว่างเพิ่มเติมก็อาจทำให้ลายเซ็นดิจิทัลไม่ถือความถูกต้อง
{{% /alert %}}

ให้ใช้ใบอนุญาตหนึ่งครั้งต่อแอปพลิเคชันหรือกระบวนการ ก่อนสร้างงานนำเสนอหรือทำการดำเนินการ Aspose.Slides อื่น ๆ สำหรับไฟล์ใบอนุญาต ให้ใช้คลาส [License](https://reference.aspose.com/slides/th/python-java/aspose.slides/license/) การให้ใบอนุญาตแบบมีมิเตอร์ใช้คู่คีย์สาธารณะและส่วนตัวแทนไฟล์ใบอนุญาต

## **การใช้ใบอนุญาต**

ตัวอย่างต่อไปนี้สมมติว่า Aspose.Slides for Python via Java และข้อกำหนดเบื้องต้นได้ถูกติดตั้งแล้ว แต่ละตัวอย่างเป็นสคริปต์อิสระที่เริ่ม JVM นำเข้า API และใช้ใบอนุญาต ในแอปพลิเคชันของคุณ ให้ทำการดำเนินการกับงานนำเสนอหลังจากใช้ใบอนุญาตและปิด JVM เฉพาะเมื่อการทำงานของ Aspose.Slides เสร็จสมบูรณ์

### **ใช้ใบอนุญาตจากไฟล์**

ส่งพาธไฟล์ใบอนุญาตไปที่ [License.setLicense](https://reference.aspose.com/slides/th/python-java/aspose.slides/license/#setLicense) แทนที่ `Aspose.Slides.lic` ด้วยพาธไปยังไฟล์ใบอนุญาตของคุณ

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # ดำเนินการกับงานนำเสนอที่นี่ ก่อนปิด JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

ใช้ชื่อไฟล์ที่ตรงกันพอดี รวมทั้งส่วนขยายของมัน ตัวอย่างเช่น หากไฟล์ชื่อ `Aspose.Slides.lic.xml` ให้รวม `.xml` เข้าในพาธ พาธแบบเต็มช่วยหลีกเลี่ยงความกำกวมเกี่ยวกับไดเรกทอรีทำงานของแอปพลิเคชัน

ตัวอย่างนี้ใช้ [License.isLicensed](https://reference.aspose.com/slides/th/python-java/aspose.slides/license/#isLicensed) เพื่อตรวจสอบว่ามีการใช้ใบอนุญาตหรือไม่

### **ใช้ใบอนุญาตจากไบต์**

ใช้ [License.setLicenseFromBytes](https://reference.aspose.com/slides/th/python-java/aspose.slides/license/#setLicenseFromBytes) เมื่อใบอนุญาตอยู่ในรูปแบบไบต์ของ Python ตัวอย่างต่อไปนี้อ่านไฟล์ในโหมดไบนารีและปิดไฟล์ก่อนใช้ใบอนุญาต

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # ดำเนินการกับงานนำเสนอที่นี่ ก่อนปิด JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

คงไบต์ต้นฉบับไว้โดยไม่เปลี่ยนแปลง อย่าถอดรหัส ปรับรูปแบบ หรือแก้ไขเนื้อหาใบอนุญาตก่อนนำไปใช้

## **ใช้ใบอนุญาตแบบมีมิเตอร์**

การให้ใบอนุญาตแบบมีมิเตอร์เรียกเก็บเงินตามการใช้ API หลังจากได้ใบอนุญาตแบบมีมิเตอร์แล้ว ให้ใช้คีย์สาธารณะและส่วนตัวกับ [Metered.setMeteredKey](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/#setMeteredKey) เริ่มต้นอ็อบเจ็กต์ [Metered](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/) และใส่คีย์ครั้งเดียวเมื่อแอปพลิเคชันเริ่มทำงาน

ตัวอย่างต่อไปนี้อ่านคีย์จากตัวแปรสภาพแวดล้อม `ASPOSE_METERED_PUBLIC_KEY` และ `ASPOSE_METERED_PRIVATE_KEY` ตั้งค่าตัวแปรทั้งสองก่อนรันสคริปต์

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # ดำเนินการกับงานนำเสนอที่นี่ ก่อนปิด JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
การให้ใบอนุญาตแบบมีมิเตอร์ต้องการการเชื่อมต่ออินเทอร์เน็ตเพื่อยืนยันคีย์และรายงานการใช้งาน เก็บคีย์ส่วนตัวให้อยู่ไกลจากซอร์สโค้ดและบันทึก ดูที่ [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) สำหรับรายละเอียดการเชื่อมต่อและการเรียกเก็บเงิน
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ต้องติดตั้งแพคเกจอื่นหลังจากซื้อใบอนุญาตหรือไม่?**

ไม่ ต้องใช้ใบอนุญาตกับแพคเกจเดียวกันที่คุณใช้สำหรับการประเมิน

**ฉันควรใช้ใบอนุญาตกับทุกงานนำเสนอหรือไม่?**

ไม่ ใช้ใบอนุญาตเพียงครั้งเดียวเมื่อแอปพลิเคชันเริ่มทำงาน ก่อนสร้างหรือโหลดงานนำเสนอ

**ฉันสามารถเปลี่ยนชื่อไฟล์ใบอนุญาตได้หรือไม่?**

ได้ ใช้ชื่อไฟล์ใหม่ที่ตรงกันในโค้ดของคุณและคงเนื้อหาไฟล์ไว้โดยไม่เปลี่ยนแปลง

**ฉันสามารถใช้ใบอนุญาตชั่วคราวกับตัวอย่างที่ใช้ไบต์ได้หรือไม่?**

ได้ อ่านไฟล์ใบอนุญาตชั่วคราวเป็นไบต์และใช้มันในลักษณะเดียวกับใบอนุญาตที่ซื้อไว้