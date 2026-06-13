---
title: ความเข้ากันได้กับ PyInstaller และ cx_Freeze
linktitle: ความเข้ากันได้กับ PyInstaller
type: docs
weight: 122
url: /th/python-net/compatibility-with-pyinstaller/
keywords:
- ความเข้ากันได้
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "แพคเกจ Aspose.Slides สำหรับ Python ผ่าน .NET ด้วย PyInstaller. ปฏิบัติตามคำแนะนำนี้เพื่อรวม, ตั้งค่า, และแก้ไขปัญหาแอปของคุณให้เป็นไฟล์ executable แบบสแตนด์อโลน."
---
## **บทนำ**

Aspose.Slides for Python via .NET extensions คือส่วนขยายของ Python C มาตรฐาน ดังนั้นจึงสามารถทำให้เป็น frozen เป็น dependency ของโปรแกรมด้วยเครื่องมืออย่าง PyInstaller และ cx_Freeze (หรือที่คล้ายกัน) ซึ่งช่วยให้คุณสร้างไฟล์ executable จากสคริปต์ Python ของคุณ เครื่องมือเหล่านี้เรียกว่า “freezers” เนื่องจากพวกมันรวมโค้ดและ dependency ของคุณไว้ในไฟล์เดียวที่สามารถแจกจ่ายและทำงานบนเครื่องอื่นโดยไม่ต้องติดตั้ง Python หรือไลบรารีเพิ่มเติม วิธีนี้ทำให้การแจกจ่ายแอปพลิเคชัน Python ของคุณง่ายขึ้น

การทำให้ Aspose.Slides for Python via .NET extension เป็น frozen เป็น dependency จะแสดงด้านล่างด้วยโปรแกรมง่าย ๆ ที่ใช้ Aspose.Slides

## **PyInstaller**

โดยทั่วไปไม่จำเป็นต้องทำอะไรพิเศษเมื่อแพคเกจโปรแกรมที่ขึ้นอยู่กับ Aspose.Slides for Python via .NET extension เมื่อโปรแกรมทำการ import ส่วนขยายในรูปแบบที่ PyInstaller มองเห็น ส่วนขยายจะถูกรวมอยู่ในโปรแกรม เนื่องจาก Aspose.Slides for Python via .NET มี PyInstaller hooks ไว้แล้ว dependency ของมันจะถูกตรวจจับและคัดลอกเข้าสู่ bundle โดยอัตโนมัติ

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

อย่างไรก็ตาม PyInstaller อาจพลาดการค้นหา hidden imports บางครั้ง—โมดูลที่ถูก import อย่างพลวัตหรือโดยอ้อมจากโค้ดของคุณ เพื่อรวม hidden import ให้ใช้ตัวเลือกของ PyInstaller dependencies ของส่วนขยายถูกระบุใน PyInstaller hooks ที่มาพร้อมกับ Aspose.Slides for Python via .NET

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

เพื่อทำให้โปรแกรมเป็น frozen ด้วย cx_Freeze ให้กำหนดค่าให้รวมแพ็กเกจรูทของ Aspose.Slides for Python via .NET extension ที่คุณใช้ ซึ่งจะทำให้ส่วนขยายและโมดูลที่ขึ้นอยู่ทั้งหมดถูกคัดลอกเข้าสู่การสร้างพร้อมกับแอปพลิเคชันของคุณ

### **ใช้สคริปต์ cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **ใช้สคริปต์ Setup**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**ฉันต้องการ Microsoft PowerPoint หรือ .NET ติดตั้งบนเครื่องของผู้ใช้หรือไม่?**

ไม่, ไม่จำเป็นต้องใช้ PowerPoint. Aspose.Slides เป็น engine ที่ทำงานอิสระ; แพ็กเกจ Python ส่งมาพร้อมทุกสิ่งที่ต้องการเป็นส่วนขยายสำหรับ CPython ผู้ใช้ไม่จำเป็นต้องติดตั้ง .NET แยกต่างหาก

**ฉันควรแนบใบอนุญาตให้กับแอปพลิเคชันที่ทำการ frozen อย่างไรให้ถูกต้อง?**

คุณสามารถเก็บไฟล์ XML ใบอนุญาตไว้ข้างไฟล์ executable หรือฝังเป็น resource แล้วโหลดจากเส้นทางที่เข้าถึงได้ก่อนเรียกใช้ API ครั้งแรก สำคัญ: อย่าแก้ไขเนื้อหา XML (รวมถึงการเปลี่ยนบรรทัด)

**ฉันควรทำอย่างไรหากฟอนต์แสดงผลต่างจากสภาพแวดล้อมการพัฒนาหลังจากการ build?**

ตรวจสอบให้แน่ใจว่าแบบอักษรที่คุณใช้มีในสภาพแวดล้อมเป้าหมาย (รวมใน bundle หรือติดตั้งในระบบ) และเส้นทางของมันถูกแก้ไขอย่างถูกต้องขณะรันไทม์; พฤติกรรมของฟอนต์มีความอ่อนไหวเป็นพิเศษบน Linux