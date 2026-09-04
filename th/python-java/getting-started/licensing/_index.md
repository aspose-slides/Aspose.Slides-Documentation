---
title: การให้สิทธิ์ใช้งาน
type: docs
weight: 80
url: /th/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- ไฟล์ใบอนุญาต
- ใบอนุญาตชั่วคราว
- การให้สิทธิ์แบบมิเตอร์
- ข้อจำกัดในการประเมิน
description: "ใช้ใบอนุญาตแบบไฟล์, แบบไบต์, หรือแบบมิเตอร์ใน Aspose.Slides for Python via Java และลบข้อจำกัดในการประเมินออกจากแอปพลิเคชันของคุณ."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถทำงานในโหมดประเมินหรือด้วยใบอนุญาตได้ บทความนี้อธิบายวิธีการใช้ใบอนุญาตจากไฟล์หรือไบต์และวิธีการกำหนดค่าเมตเทรดลิขสิทธิ์

สำหรับตัวเลือกการซื้อ ดูที่ [ข้อมูลราคา](https://purchase.aspose.com/pricing/slides/th/family). สำหรับคำถามทั่วไปเกี่ยวกับใบอนุญาตและการซื้อ ดูที่ [นโยบายการซื้อและคำถามที่พบบ่อย](https://purchase.aspose.com/policies).

สำหรับข้อจำกัดในการประเมินและวิธีขอใบอนุญาตชั่วคราว ดูที่ [ประเมิน Aspose.Slides](/slides/th/python-java/evaluate-aspose-slides/). ใช้ใบอนุญาตชั่วคราวในลักษณะเดียวกับไฟล์ใบอนุญาตที่ซื้อ

## **เกี่ยวกับใบอนุญาต**

ไฟล์ใบอนุญาตจะบรรจุข้อมูลเช่น ชื่อผลิตภัณฑ์ จำนวนผู้พัฒนาที่ได้รับอนุญาต และวันหมดอายุของการสมัครสมาชิก ไฟล์นี้เป็น XML ที่เซ็นดิจิทัลแล้ว

{{% alert color="warning" title="Warning" %}}
ห้ามแก้ไขไฟล์ใบอนุญาต แม้แต่การขึ้นบรรทัดใหม่พิเศษก็อาจทำให้ลายเซ็นดิจิทัลใช้ไม่ได้
{{% /alert %}}

ใช้ใบอนุญาตหนึ่งครั้งต่อแอปพลิเคชันหรือกระบวนการ ก่อนสร้างงานนำเสนอหรือทำงาน Aspose.Slides อื่น ๆ สำหรับไฟล์ใบอนุญาต ให้ใช้คลาส [License](https://reference.aspose.com/slides/th/python-java/aspose.slides/license/). การให้ใบอนุญาตแบบมิเตอร์ใช้คู่คีย์สาธารณะและส่วนตัวแทนไฟล์ใบอนุญาต

## **ใช้ใบอนุญาต**

ตัวอย่างต่อไปนี้ถือว่ามีการติดตั้ง Aspose.Slides for Python via Java และข้อกำหนดเบื้องต้นแล้ว ตัวอย่างแต่ละรายการเป็นสคริปต์อิสระที่เริ่ม JVM นำเข้า API และใช้ใบอนุญาต ในแอปพลิเคชันของคุณ ให้ทำการดำเนินการงานนำเสนอหลังจากใช้ใบอนุญาตและปิด JVM เฉพาะหลังจากงาน Aspose.Slides ทั้งหมดเสร็จสิ้น

### **ใช้ใบอนุญาตจากไฟล์**

ส่งเส้นทางไฟล์ใบอนุญาตไปยัง [License.setLicense](https://reference.aspose.com/slides/th/python-java/aspose.slides/license/#setLicense). แทนที่ `Aspose.Slides.lic` ด้วยเส้นทางของไฟล์ใบอนุญาตของคุณ

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
        # ทำการดำเนินการนำเสนอที่นี่ ก่อนปิด JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

ใช้ชื่อไฟล์ตรงตามนั้นรวมถึงนามสกุลด้วย ตัวอย่างเช่น หากไฟล์ชื่อ `Aspose.Slides.lic.xml` ให้ใส่ `.xml` ในเส้นทาง การใช้เส้นทางเต็มจะหลีกเลี่ยงความกำกวมเกี่ยวกับไดเรกทอรีทำงานของแอปพลิเคชัน

ตัวอย่างใช้ [License.isLicensed](https://reference.aspose.com/slides/th/python-java/aspose.slides/license/#isLicensed) เพื่อตรวจสอบว่ามีการใช้ใบอนุญาตหรือไม่

### **ใช้ใบอนุญาตจากไบต์**

ใช้ [License.setLicenseFromBytes](https://reference.aspose.com/slides/th/python-java/aspose.slides/license/#setLicenseFromBytes) เมื่อใบอนุญาตอยู่ในรูปไบต์ของ Python ตัวอย่างต่อไปนี้อ่านไฟล์ในโหมดไบนารีและปิดไฟล์ก่อนใช้ใบอนุญาต

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
        # ทำการดำเนินการนำเสนอที่นี่ ก่อนปิด JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

เก็บไบต์ต้นฉบับไว้โดยไม่ได้เปลี่ยนแปลง อย่าแปลงรหัส ปรับรูปแบบ หรือแก้ไขเนื้อหาใบอนุญาตก่อนนำไปใช้

## **ใช้ใบอนุญาตแบบมิเตอร์**

ใบอนุญาตแบบมิเตอร์จะเรียกเก็บค่าบริการตามการใช้ API หลังจากได้ใบอนุญาตแบบมิเตอร์แล้ว ให้ใช้คีย์สาธารณะและส่วนตัวของมันกับ [Metered.setMeteredKey](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/#setMeteredKey). เริ่มต้นวัตถุ [Metered](https://reference.aspose.com/slides/th/python-java/aspose.slides/metered/) และใช้คีย์เหล่านั้นหนึ่งครั้งที่การเริ่มต้นแอปพลิเคชัน

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
        # ทำการดำเนินการนำเสนอที่นี่ ก่อนปิด JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
การให้ใบอนุญาตแบบมิเตอร์ต้องการการเชื่อมต่ออินเทอร์เน็ตเพื่อตรวจสอบคีย์และรายงานการใช้งาน เก็บคีย์ส่วนตัวให้อยู่นอกซอร์สโค้ดและบันทึก ดูที่ [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) สำหรับรายละเอียดการเชื่อมต่อและการเรียกเก็บเงิน
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องติดตั้งแพคเกจอื่นหลังจากซื้อใบอนุญาตหรือไม่?**  
ไม่ จำเป็นต้องใช้ใบอนุญาตกับแพคเกจเดียวกับที่ใช้ในการประเมิน

**ฉันควรใช้ใบอนุญาตสำหรับงานนำเสนอแต่ละอันหรือไม่?**  
ไม่ ใช้ใบอนุญาตหนึ่งครั้งในระหว่างการเริ่มต้นแอปพลิเคชัน ก่อนสร้างหรือโหลดงานนำเสนอ

**ฉันสามารถเปลี่ยนชื่อไฟล์ใบอนุญาตได้หรือไม่?**  
ได้ ใช้ชื่อไฟล์ใหม่ที่แน่นอนในโค้ดของคุณและเก็บเนื้อหาไฟล์ไม่เปลี่ยนแปลง

**ฉันสามารถใช้ใบอนุญาตชั่วคราวกับตัวอย่างแบบไบต์ได้หรือไม่?**  
ได้ อ่านไฟล์ใบอนุญาตชั่วคราวเป็นไบต์และใช้ในลักษณะเดียวกับใบอนุญาตที่ซื้อ