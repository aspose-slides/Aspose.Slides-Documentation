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
description: "ติดตั้ง Aspose.Slides สำหรับ Python ผ่าน Java บน Windows, Linux หรือ macOS, ตั้งค่า Java และ JPype, และตรวจสอบการตั้งค่าด้วยตัวอย่างที่ใช้งานได้."
---
Aspose.Slides สำหรับ Python ผ่าน Java ทำงานบน Windows, Linux และ macOS ใช้ JPype เพื่อเข้าถึงไลบรารี Java จาก Python ไม่จำเป็นต้องใช้ Microsoft PowerPoint.

## **Prerequisites**

ก่อนติดตั้งแพ็กเกจ Python ให้ติดตั้ง Python และ JDK ที่ตรงกับ [ข้อกำหนดของระบบ](/slides/th/python-java/system-requirements/) หน้าเพจนี้มีรายการเวอร์ชันที่รองรับ, ความต้องการสถาปัตยกรรม, และการพึ่งพาต่าง ๆ ที่จำเป็นสำหรับการคอมไพล์ JPype จากซอร์ส

ตั้งค่า `JAVA_HOME` ให้ชี้ไปที่ไดเรกทอรีการติดตั้ง JDK (ไม่ใช่โฟลเดอร์ `bin` ย่อย) และเพิ่มโฟลเดอร์ `bin` ของ JDK ไปยัง `PATH` เปิดเทอร์มินัลใหม่หลังจากแก้ไขตัวแปรสภาพแวดล้อม

## **Install from PyPI**

รันคำสั่งต่อไปนี้ในเทอร์มินัล ไม่ใช่ในพรอมต์โต้ตอบของ Python สร้างโฟลเดอร์โครงการและสภาพแวดล้อมเสมือนเพื่อแยกแพ็กเกจออกจากโปรเจกต์อื่น

### **Windows**

เมื่อใช้ Python interpreter ของคุณพร้อมใช้งานเป็น `python` บน `PATH` ให้รันคำสั่งต่อไปนี้ใน Command Prompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux and macOS**

เมื่อใช้ Python เวอร์ชันที่ต้องการพร้อมใช้งานเป็น `python3` ให้รันคำสั่งต่อไปนี้ใน Bash หรือ zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

บน Debian หรือ Ubuntu หากการสร้างสภาพแวดล้อมล้มเหลวเพราะ `ensurepip` ไม่พร้อมใช้งาน ให้ติดตั้งแพ็กเกจ `python3-venv` ด้วย `sudo apt-get install python3-venv` แล้วลองรันคำสั่งสร้างสภาพแวดล้อมอีกครั้ง เวอร์ชัน Python ที่ติดตั้งแยกต่างหากอาจต้องการแพ็กเกจ `venv` ที่ตรงกับเวอร์ชันนั้น

### **Install the Packages**

เมื่อสภาพแวดล้อมเสมือนเปิดอยู่ ให้ติดตั้ง JPype และ Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

การใช้ `python -m pip` รับประกันว่าแพ็กเกจจะถูกติดตั้งสำหรับ interpreter ที่ใช้รันแอปพลิเคชันของคุณ

หากต้องการอัปเดตการติดตั้ง Aspose.Slides ที่มีอยู่ ให้รัน `python -m pip install --upgrade aspose-slides-java` ในสภาพแวดล้อมเดียวกัน

## **Install from a ZIP Archive**

คุณสามารถใช้ไลบรารีจาก [หน้าดาวน์โหลด Aspose.Slides](https://releases.aspose.com/slides/th/python-java/) ได้เช่นกัน:

1. ติดตั้ง Python และ Java ตามที่อธิบายใน [ข้อกำหนดของระบบ](#prerequisites)  
2. สร้างและเปิดใช้งานสภาพแวดล้อมเสมือนตามขั้นตอนด้านบน  
3. ติดตั้ง JPype ด้วย `python -m pip install JPype1`  
4. ดาวน์โหลดและแตกไฟล์ ZIP ของ Aspose.Slides for Python via Java  
5. ค้นหาไดเรกทอรีแพ็กเกจ `asposeslides` ที่ถูกแตกออกมา เก็บเนื้อหาไว้รวมถึงโฟลเดอร์ `lib` และไฟล์ JAR ไว้ด้วยกัน  
6. วางไฟล์ `example.py` จากส่วนต่อไปข้างล่างนี้ไว้ข้างเคียงไดเรกทอรี `asposeslides` เพื่อให้ Python สามารถนำเข้าแพ็กเกจได้ ไฟล์ ZIP มี `example.py` อยู่แล้วข้าง `asposeslides` ให้แทนที่ด้วยไฟล์ด้านล่างนี้

## **Verify the Installation**

บันทึกรหัสต่อไปนี้เป็นไฟล์ `example.py` มันจะสร้างงานนำเสนอพร้อมกล่องข้อความและบันทึกเป็น `out.pptx` ในไดเรกทอรีทำงานปัจจุบัน

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

เมื่อสภาพแวดล้อมเสมือนเปิดอยู่ ให้รันตัวอย่างจากไดเรกทอรีที่มี `example.py`:

```sh
python example.py
```

การนำเข้า `asposeslides` จะลงทะเบียนไลบรารี Java ที่รวมอยู่ก่อน JVM เริ่มทำงาน นำเข้า `asposeslides.api` หลังจากเปิด JVM และปล่อยทรัพยากรการนำเสนอก่อนปิด JVM

{{% alert color="info" title="Note" %}}
หากไม่มีไลเซนส์ ผลลัพธ์จะมีลายน้ำการประเมิน ดูรายละเอียดเกี่ยวกับข้อจำกัดของการประเมินและข้อมูลไลเซนส์ชั่วคราวได้ที่ [ประเมิน Aspose.Slides](/slides/th/python-java/evaluate-aspose-slides/)
{{% /alert %}}

## **FAQ**

**ทำไม Python จึงแจ้งว่าไม่พบหรือไม่สามารถโหลด JVM ได้?**

ตรวจสอบว่า `JAVA_HOME` ชี้ไปยัง JDK ที่เข้ากันได้กับ Python และการติดตั้ง JPype ของคุณ ตามที่อธิบายใน [ข้อกำหนดของระบบ](/slides/th/python-java/system-requirements/) ดู [คู่มือแก้ปัญหาการติดตั้ง JPype](https://jpype.readthedocs.io/en/latest/install.html) เพื่อทำการตรวจสอบเพิ่มเติม

**ทำไม Python ถึงรายงานว่า `asposeslides` หายหลังการติดตั้ง?**

แพ็กเกจอาจถูกติดตั้งกับ interpreter ของ Python ตัวอื่น เปิดสภาพแวดล้อมเสมือนที่ใช้สำหรับการติดตั้งและรัน `python -m pip show aspose-slides-java` สำหรับการติดตั้งจาก ZIP ให้แน่ใจว่าไดเรกทอรี `asposeslides` อยู่ข้างเคียงสคริปต์ของคุณหรือสามารถเข้าถึงได้ในเส้นทางค้นหาโมดูลของ Python

**ฉันสามารถเรียกใช้ตัวอย่างนี้ซ้ำ ๆ ในโน๊ตบุ๊คได้ไหม?**

ตัวอย่างนี้ออกแบบมาสำหรับกระบวนการ Python แบบสแตนด์อโลน ก่อนนำไปใช้ซ้ำในโน๊ตบุ๊คให้ดู [ข้อจำกัดและความแตกต่างของ API](/slides/th/python-java/limitations-and-api-differences/#import-the-library) สำหรับวงจรชีวิตของ JVM และคำแนะนำการใช้ในโน๊ตบุ๊ค

**ทำไม pip ถึงล้มเหลวด้วย `CERTIFICATE_VERIFY_FAILED`?**

หากเครือข่ายของคุณใช้พร็อกซีตรวจสอบ HTTPS pip ต้องเชื่อถือใบรับรองของพร็อกซี กำหนดค่า CA bundle ที่เชื่อถือได้โดยใช้ตัวเลือก `--cert` ของ pip หรือใช้ตัวแปรสภาพแวดล้อม `PIP_CERT` ตาม [คำแนะนำเกี่ยวกับใบรับรอง HTTPS ของ pip](https://pip.pypa.io/en/stable/topics/https-certificates/) การตั้งค่าที่จำเป็นขึ้นอยู่กับเครือข่ายและเวอร์ชันของ pip