---
title: ข้อกำหนดระบบ
type: docs
weight: 60
url: /th/python-java/system-requirements/
keywords:
- ข้อกำหนดระบบ
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "ตรวจสอบระบบปฏิบัติการ, Python, Java, และความต้องการของ JPype สำหรับการรัน Aspose.Slides for Python via Java บน Windows, Linux และ macOS."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สร้าง แก้ไข แปลง และเรนเดอร์งานพรีเซ็นเทชันโดยไม่ต้องติดตั้ง Microsoft PowerPoint ใช้ JPype เพื่อเข้าถึงไลบรารี Java จาก Python ดังนั้นสภาพแวดล้อมต้องรองรับ Python, Java, และ JPype พร้อมกัน

## **ระบบปฏิบัติการที่รองรับ**

[แพคเกจ Aspose.Slides](https://pypi.org/project/aspose-slides-java/) รองรับกลุ่มระบบปฏิบัติการต่อไปนี้

- Windows
- Linux
- macOS

เลือกเวอร์ชันของระบบปฏิบัติการที่รองรับกับ Python, Java, และ JPype ที่คุณเลือกใช้ การมี Java อย่างเดียวไม่ได้หมายความว่าจะเข้ากันได้กับแพคเกจ Python และบริดจ์ของมัน

## **ความต้องการของ Python, Java, และ JPype**

| ส่วนประกอบ | ข้อกำหนด |
| --- | --- |
| Python | แพคเกจ Aspose.Slides ระบุว่ารองรับ Python 3.7 ถึง 3.14 รุ่น JPype ที่เลือกต้องสนับสนุนเวอร์ชัน Python เดียวกัน ตัวอย่างเช่น [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) ต้องการ Python 3.8 หรือใหม่กว่า |
| Java | ติดตั้ง Java runtime หรือ JDK ที่เข้ากันกับรุ่น JPype ที่เลือก ปัจจุบัน [ข้อกำหนดของ JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) ระบุว่า Java 11 หรือใหม่กว่า Java 8 ไม่สามารถรัน JPype1 1.7.1 |
| JPype | ติดตั้งแพคเกจ JPype1 สำหรับตัวตีความ Python, ระบบปฏิบัติการ, และสถาปัตยกรรม CPU ของคุณ |
| สถาปัตยกรรม CPU | Python และ Java Virtual Machine (JVM) ต้องใช้สถาปัตยกรรมเดียวกัน ตัวอย่างเช่น ตัวตีความ Python 64‑bit ต้องการ JVM 64‑bit ที่เข้ากันได้ |

บน Apple Silicon Python และ Java ต้องใช้ ARM64 ทั้งคู่หรือใช้ x64 ทั้งคู่ JVM ที่ทำงานแยกอาจยังล้มเหลวในการโหลดผ่าน JPype หากสถาปัตยกรรมต่างจากของ Python

สำหรับสภาพแวดล้อมใหม่ Python 3.12, JDK 17, และ JPype1 1.7.1 เป็นจุดเริ่มต้นที่เหมาะสม การผสมผสานนี้ได้รับการตรวจสอบกับ Aspose.Slides for Python via Java 26.6.0 บน Windows การผสมผสานอื่นต้องตอบสนองต่อความต้องการของทั้งสามส่วนประกอบ

สำหรับการตั้งค่าสภาพแวดล้อมและตัวอย่างการตรวจสอบการทำงาน ดูที่ [Installation](/slides/th/python-java/installation/)

## **การขึ้นกับเพิ่มเติม**

ล้อล่วงหน้าที่เข้ากันได้ของ JPype ไม่ต้องการคอมไพเลอร์ C++ หากต้องคอมไพล์ JPype จากซอร์ส ให้ติดตั้งคอมไพเลอร์ C++ ที่เข้ากันได้และไฟล์พัฒนา Python ที่จำเป็นสำหรับแพลตฟอร์มของคุณ ดูที่ [คำแนะนำการติดตั้ง JPype](https://jpype.readthedocs.io/en/latest/install.html) เพื่อทราบข้อกำหนดการสร้างและการแก้ปัญหา

## **FAQ**

**ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ไม่ Aspose.Slides ประมวลผลงานพรีเซ็นเทชันโดยอิสระจาก PowerPoint ยังคงต้องใช้ Python, Java, และ JPype

**สามารถใช้ Python 3.7 กับ JPype ใดก็ได้หรือไม่?**

ไม่ แม้ว่าแพคเกจ Aspose.Slides จะระบุการสนับสนุน Python 3.7 แต่ JPype1 1.7.1 ต้องการ Python 3.8 หรือใหม่กว่า เลือกเวอร์ชันที่ข้อกำหนดทับซ้อนกัน

**สามารถผสาน Python 32‑bit กับ Java 64‑bit ได้หรือไม่?**

ไม่ JPype โหลด JVM เข้าไปในขั้นตอนของ Python ดังนั้น Python และ Java ต้องมีสถาปัตยกรรมตรงกัน ข้อกำหนดเดียวกันใช้กับ ARM64 และ x64 บน macOS