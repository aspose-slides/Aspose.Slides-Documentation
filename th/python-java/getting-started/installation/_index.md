---
title: การติดตั้ง
type: docs
weight: 70
url: /th/python-java/installation/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- การติดตั้ง Aspose.Slides
- Windows
- macOS
- Linux
- Python
description: "ติดตั้ง Aspose.Slides สำหรับ Python ผ่าน Java บน Windows, Linux หรือ macOS"
---
Aspose.Slides for Python via Java เป็น API ที่ไม่ขึ้นกับแพลตฟอร์มและสามารถใช้ได้บนแพลตฟอร์มใดก็ได้ (Windows, Linux และ MacOS) ที่ติดตั้ง `Python`, `Java` และ `jpype1` bridge

## **ข้อกำหนดสำหรับโปรแกรมและเวอร์ชัน**

เพื่อให้ Aspose.Slides for Python via Java ทำงานได้อย่างถูกต้อง โปรแกรมและแพ็คเกจต่อไปนี้ต้องถูกติดตั้ง:

- JRE version >=8 (JPype1 ได้รับการทดสอบบน Java เวอร์ชันตั้งแต่ 1.8 ถึง 11).
- Python version >=3.7,<=3.12.
- JPype1 package version: >=1.5.0.

## **ติดตั้งจาก pip**

คุณสามารถติดตั้ง Aspose.Slides for Python via Java จาก[pip](https://pypi.org/) ได้อย่างง่ายดาย ตราบใดที่คุณได้ติดตั้งโปรแกรมที่จำเป็นทั้งหมด (Java, Python) แล้ว

สร้างโฟลเดอร์โครงการใหม่.

[Install JPype1](https://jpype.readthedocs.io/en/latest/install.html)โดยใช้คำสั่งต่อไปนี้:
```
$ pip install JPype1
```

ติดตั้ง Aspose.Slides for Python via Java โดยใช้คำสั่งต่อไปนี้:
```
$ pip install aspose-slides-java
```

## **ติดตั้งจากไฟล์ ZIP**

หากต้องการติดตั้งและใช้งาน Aspose.Slides for Python via Java จากไฟล์ ZIP ให้ทำตามคำแนะนำต่อไปนี้แทน:

### **Windows**

1. ติดตั้ง JDK8 และกำหนดค่าตัวแปรสภาพแวดล้อม `JAVA_HOME`.
2. [Install Python](https://www.python.org/downloads/) เวอร์ชัน >=3.7 และเพิ่ม python.exe ไปยัง `PATH`.
3. [Install Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) คุณสามารถรันคำสั่งต่อไปนี้ในเทอร์มินัล python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/th/python-java/) และแตกไฟล์ไปยัง `aspose-slides-java`.
6. สร้างไฟล์ชื่อ `example.py` ในโฟลเดอร์ `aspose-slides-java` โดยใช้ตัวอย่างโค้ดต่อไปนี้:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. เรียกใช้ `py example.py` ที่ command prompt เพื่อรันไฟล์นี้.

### **Linux**

1. ติดตั้ง JDK8 สำหรับ Linux และกำหนดค่าตัวแปรสภาพแวดล้อม `JAVA_HOME`.
2. [Install Python](https://www.python.org/downloads/) เวอร์ชัน >=3.7
3. ติดตั้ง ``g++`` และ ``python-dev``. 

- สำหรับ Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- สำหรับ RedHat-based:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) คุณสามารถรันคำสั่งต่อไปนี้ในเทอร์มินัล python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/th/python-java/) และแตกไฟล์ไปยัง `aspose-slides-java`.
6. สร้างไฟล์ทดสอบชื่อ `example.py` โดยใช้ตัวอย่างโค้ดนี้ในโฟลเดอร์ `aspose-slides-java`:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. เรียกใช้ `py example.py` ที่ command prompt เพื่อรันไฟล์นี้.

### **Mac**

1. ติดตั้ง JDK8 สำหรับ Mac และกำหนดค่าตัวแปรสภาพแวดล้อม `JAVA_HOME`.
2. แก้ไขส่วน JVMCapabilities ใน`/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist`ด้วยสิทธิ์ root. `jdk1.8.x_xxx.jdk` ขึ้นอยู่กับเวอร์ชัน jdk ของคุณ ให้ทำให้ดูเหมือนตัวอย่างนี้:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
3. [Install Python](https://www.python.org/downloads/) เวอร์ชัน >=3.7.
4. ติดตั้งคอมไพเลอร์ GCC หรือ Clang ขึ้นกับเวอร์ชันของ Python และแพลตฟอร์ม.
5. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) คุณสามารถรันคำสั่งต่อไปนี้ในเทอร์มินัล python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/th/python-java/) และแตกไฟล์ลงใน `aspose-slides-java`.
7. สร้างไฟล์ทดสอบชื่อ `example.py` โดยใช้ตัวอย่างโค้ดนี้ในโฟลเดอร์ `aspose-slides-java`:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. เรียกใช้ `python example.py` ที่ command prompt เพื่อรันไฟล์นี้.