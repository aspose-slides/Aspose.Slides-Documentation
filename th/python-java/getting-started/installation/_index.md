---
title: การติดตั้ง
type: docs
weight: 70
url: /th/python-java/installation/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- การติดตั้ง Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "ติดตั้ง Aspose.Slides สำหรับ Python ผ่าน Java บน Windows, Linux หรือ macOS, ตั้งค่า Java และ JPype, และยืนยันการตั้งค่าด้วยตัวอย่างที่ทำงานได้."
---
Aspose.Slides for Python via Java ทำงานบน Windows, Linux และ macOS ใช้ JPype เพื่อเข้าถึงไลบรารี Java จาก Python ไม่จำเป็นต้องใช้ Microsoft PowerPoint

## **ข้อกำหนดเบื้องต้น**

ก่อนติดตั้งแพคเกจ Python ให้ติดตั้ง Python และ JDK ที่ตรงตาม [ข้อกำหนดระบบ](/slides/th/python-java/system-requirements/) หน้านั้นมีรายการเวอร์ชันที่เข้ากันได้ ข้อกำหนดสถาปัตยกรรม และการพึ่งพาใด ๆ ที่จำเป็นสำหรับการสร้าง JPype จากซอร์ส

ตั้งค่า `JAVA_HOME` ให้ชี้ไปที่ไดเรกทอรีการติดตั้ง JDK not its `bin` subdirectory และเพิ่มไดเรกทอรี `bin` ของ JDK เข้าไปใน `PATH` เปิดเทอร์มินัลใหม่หลังจากเปลี่ยนตัวแปรสภาพแวดล้อม

## **การติดตั้งจาก PyPI**

เรียกใช้คำสั่งต่อไปนี้ในเทอร์มินัล ไม่ใช่ในพรอมต์โต้ตอบของ Python สร้างไดเรกทอรีโครงการและสภาพแวดล้อมเสมือนเพื่อแยกแพคเกจจากโครงการอื่น ๆ

### **Windows**

เมื่ออินเทอร์พรีเตอร์ Python ที่เลือกสามารถใช้ได้เป็น `python` บน `PATH` ให้เรียกใช้คำสั่งต่อไปนี้ใน Command Prompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux และ macOS**

เมื่อเวอร์ชัน Python ที่เลือกสามารถใช้ได้เป็น `python3` ให้เรียกใช้คำสั่งต่อไปนี้ใน Bash หรือ zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

บน Debian หรือ Ubuntu หากการสร้างสภาพแวดล้อมล้มเหลวเพราะ `ensurepip` ใช้ไม่ได้ ให้ติดตั้งแพคเกจ `python3-venv` ด้วย `sudo apt-get install python3-venv` แล้วทำซ้ำคำสั่งสร้างสภาพแวดล้อม เวอร์ชัน Python ที่ติดตั้งแยกต่างหากอาจต้องการแพคเกจ `venv` ที่ตรงกับเวอร์ชันนั้น

### **ติดตั้งแพคเกจ**

เมื่อสภาพแวดล้อมเสมือนได้เปิดใช้งาน ให้ติดตั้ง JPype และ Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

การใช้ `python -m pip` รับประกันว่าแพคเกจจะถูกติดตั้งสำหรับอินเทอร์พรีเตอร์ที่ใช้รันแอปพลิเคชันของคุณ

หากต้องการอัปเดตการติดตั้ง Aspose.Slides ที่มีอยู่ ให้เรียก `python -m pip install --upgrade aspose-slides-java` ในสภาพแวดล้อมเดียวกัน

## **การติดตั้งจากไฟล์ ZIP**

คุณสามารถใช้ไลบรารีจาก [หน้าดาวน์โหลด Aspose.Slides]https://releases.aspose.com/slides/th/python-java/ ได้เช่นกัน:

1. ติดตั้ง Python และ Java ตามที่อธิบายใน **ข้อกำหนดเบื้องต้น**.
2. สร้างและเปิดใช้งานสภาพแวดล้อมเสมือนตามคำแนะนำข้างต้น.
3. ติดตั้ง JPype ด้วย `python -m pip install JPype1`.
4. ดาวน์โหลดและแตกไฟล์ ZIP ของ Aspose.Slides for Python via Java.
5. ค้นหาไดเรกทอรีแพคเกจ `asposeslides` ที่แตกออกมา เก็บเนื้อหาทั้งหมดรวมถึงไดเรกทอรี `lib` และไฟล์ JAR ไว้ด้วยกัน.
6. วางไฟล์ `example.py` จากส่วนถัดไปไว้ข้างๆ ไดเรกทอรี `asposeslides` เพื่อให้ Python สามารถนำเข้าแพคเกจได้.

## **ตรวจสอบการติดตั้ง**

บันทึกโค้ดต่อไปนี้เป็นไฟล์ `example.py` โค้ดนี้จะสร้างงานนำเสนอพร้อมกล่องข้อความและบันทึกเป็น `out.pptx` ในไดเรกทอรีทำงานปัจจุบัน

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

เมื่อสภาพแวดล้อมเสมือนได้เปิดใช้งาน ให้เรียกตัวอย่างจากไดเรกทอรีที่มี `example.py` :

```sh
python example.py
```

การนำเข้า `asposeslides` จะทำการลงทะเบียนไลบรารี Java ที่บรรจุไว้ก่อนที่ JVM จะเริ่มทำงาน นำเข้า `asposeslides.api` หลังจากเริ่ม JVM แล้วและปล่อยทรัพยากรของงานนำเสนอก่อนปิด JVM

{{% alert color="info" title="หมายเหตุ" %}}

หากไม่มีลิขสิทธิ์ ผลลัพธ์จะมีลายน้ำการประเมิน ดูที่ [ประเมิน Aspose.Slides](/slides/th/python-java/evaluate-aspose-slides/) สำหรับข้อจำกัดการประเมินและข้อมูลลิขสิทธิ์ชั่วคราว

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไม Python จัดว่าไม่พบหรือไม่สามารถโหลด JVM ได้?**

ตรวจสอบให้ `JAVA_HOME` ชี้ไปที่ JDK ที่เข้ากันได้กับ Python และการติดตั้ง JPype ของคุณ ตามที่อธิบายใน [ข้อกำหนดระบบ](/slides/th/python-java/system-requirements/) ดูคู่มือการแก้ไขปัญหาการติดตั้ง JPype ที่ <https://jpype.readthedocs.io/en/latest/install.html> สำหรับการตรวจสอบเพิ่มเติม

**ทำไม Python จัดว่า `asposeslides` ขาดหายหลังการติดตั้ง?**

อาจเป็นเพราะแพคเกจถูกติดตั้งสำหรับอินเทอร์พรีเตอร์ Python ตัวอื่น ให้เปิดใช้งานสภาพแวดล้อมเสมือนที่ใช้ในการติดตั้งและรัน `python -m pip show aspose-slides-java` สำหรับการติดตั้งแบบ ZIP ให้แน่ใจว่าไดเรกทอรี `asposeslides` อยู่ข้างๆ สคริปต์ของคุณหรือสามารถเข้าถึงได้บนเส้นทางค้นหาโมดูลของ Python

**ฉันสามารถรันตัวอย่างนี้หลายครั้งในโน้ตบุ๊กได้หรือไม่?**

ตัวอย่างออกแบบมาสำหรับกระบวนการ Python แยกเดี่ยว ก่อนปรับให้ทำงานซ้ำในโน้ตบุ๊ก ให้ดูที่ [ข้อจำกัดและความแตกต่างของ API](/slides/th/python-java/limitations-and-api-differences/#import-the-library) สำหรับวงจรชีวิต JVM และแนวทางโน้ตบุ๊ก

**ทำไม pip ล้มเหลวพร้อมข้อความ `CERTIFICATE_VERIFY_FAILED`?**

หากเครือข่ายของคุณใช้พร็อกซีตรวจสอบ HTTPS pip จำเป็นต้องเชื่อถือใบรับรองของพร็อกซี ตั้งค่า bundle ใบรับรอง CA ที่เชื่อถือได้โดยใช้ตัวเลือก `--cert` ของ pip หรือค่าตัวแปรสภาพแวดล้อม `PIP_CERT` ตามคำแนะนำเกี่ยวกับใบรับรอง HTTPS ของ pip ที่ <https://pip.pypa.io/en/stable/topics/https-certificates/> การกำหนดค่านี้ขึ้นอยู่กับเครือข่ายและเวอร์ชันของ pip ของคุณ