---
title: การติดตั้ง
type: docs
weight: 70
url: /th/python-net/installation/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- ใช้ Aspose.Slides
- การติดตั้ง Aspose.Slides
- Windows
- macOS
- Python
description: "เรียนรู้วิธีติดตั้ง Aspose.Slides for Python via .NET อย่างรวดเร็ว คู่มือแบบขั้นตอน ข้อกำหนดระบบ และตัวอย่างโค้ด — เริ่มทำงานกับงานนำเสนอ PowerPoint วันนี้!"
---
## **ภาพรวม**

แพ็คเกจ Aspose.Slides for Python via .NET มาพร้อมกับไลบรารี .NET ที่จำเป็นทั้งหมดรวมอยู่ในตัว ทำให้ไม่ต้องติดตั้ง .NET แยกต่างหาก สิ่งนี้ทำให้กระบวนการตั้งค่าง่ายขึ้นและช่วยให้ผู้พัฒนาเริ่มทำงานกับงานนำเสนอได้ทันที อย่างไรก็ตาม โปรดทราบว่า ขึ้นอยู่กับระบบปฏิบัติการหรือสภาพแวดล้อมของคุณ คุณอาจยังต้องติดตั้งการพึ่งพาเฉพาะแพลตฟอร์มที่จำเป็นสำหรับ .NET นอกจากนี้ ต้องปฏิบัติตามข้อกำหนดระบบบางประการเพื่อให้แน่ใจว่าแพ็คเกจทำงานได้อย่างสมบูรณ์และเข้ากันได้เต็มที่

## **Windows**

**ข้อกำหนดระบบ**

ตรวจสอบและยืนยันว่าข้อมูลสเปคของเครื่องของคุณตรงหรือเหนือกว่า[ข้อกำหนดระบบ](/slides/th/python-net/system-requirements/).

### **ติดตั้ง Aspose.Slides**

`pip` เป็นวิธีที่ง่ายที่สุดในการดาวน์โหลดและติดตั้ง[Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/)บน Windows.

เพื่อทำการติดตั้ง Aspose.Slides ให้เรียกใช้คำสั่งต่อไปนี้:

```sh
pip install aspose-slides
```

**ใช้ Aspose.Slides**

ทดสอบการติดตั้ง Aspose.Slides ของคุณโดยรันโค้ดต่อไปนี้เพื่อสร้างไฟล์ PowerPoint:

```python
# นำเข้าโมดูล Aspose.Slides for Python via .NET.
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**ข้อกำหนดระบบ**

ตรวจสอบและยืนยันว่าข้อมูลสเปคของเครื่องของคุณตรงหรือเหนือกว่า[ข้อกำหนดระบบ](/slides/th/python-net/system-requirements/).

### **ข้อกำหนดเบื้องต้น**

**Python พร้อมไลบรารีที่แชร์**

มีหลายวิธีที่จะติดตั้ง Python บน macOS แต่เราขอแนะนำให้ใช้[pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos)อย่างยิ่ง.

หลังจากติดตั้งและกำหนดค่า**pyenv**แล้ว ให้ติดตั้ง Python พร้อมไลบรารีที่แชร์โดยรันคำสั่งต่อไปนี้ในแอป Terminal:

1. ติดตั้ง Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. ตั้งเป็นเวอร์ชัน Python ระดับ global:

```sh
pyenv global 3.9.13
```

3. ตั้งเป็นเวอร์ชัน Python ระดับ shell:

```sh
pyenv shell 3.9.13
```

4. สร้าง symbolic link สำหรับไลบรารี libpython ในไดเรกทอรีระบบ:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

หมายเหตุ: จำเป็นต้องใช้ Python 3.5 ขึ้นไป รุ่น 3.9.13 ใช้เป็นตัวอย่างเท่านั้น.

**ติดตั้งไลบรารี libgdiplus**

ไลบรารี**libgdiplus**เป็นการทำงานของ Windows GDI+ สำหรับ macOS และ Linux ที่ .NET พึ่งพาเพื่อการทำงานกราฟิกบนแพลตฟอร์มนั้น.

เพื่อติดตั้งไลบรารีนี้บน macOS ให้รันคำสั่งต่อไปนี้:

```sh
brew install mono-libgdiplus
```

### **ติดตั้ง Aspose.Slides**

`pip` เป็นวิธีที่ง่ายที่สุดในการดาวน์โหลดและติดตั้ง[Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/)บน macOS.

เพื่อทำการติดตั้ง Aspose.Slides ให้เรียกใช้คำสั่งต่อไปนี้:

```sh
pip install aspose-slides
```

**ใช้ Aspose.Slides**

ทดสอบการติดตั้ง Aspose.Slides ของคุณโดยรันโค้ดต่อไปนี้เพื่อสร้างไฟล์ PowerPoint:

```python
# นำเข้าโมดูล Aspose.Slides for Python via .NET.
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถติดตั้ง Aspose.Slides ในสภาพแวดล้อมเสมือน (virtual environment) ได้หรือไม่?**

ได้ คุณสามารถติดตั้งในสภาพแวดล้อมเสมือนของ Python ใดก็ได้โดยใช้`pip` เพียงตรวจสอบให้แน่ใจว่าสภาพแวดล้อมนั้นเข้าถึงการพึ่งพาเนทีฟที่จำเป็นตามระบบปฏิบัติการของคุณ

**ฉันสามารถใช้ Aspose.Slides ในคอนเทนเนอร์ Docker ได้หรือไม่?**

ได้ แต่คุณต้องตรวจสอบให้แน่ใจว่าภาพ Docker ของคุณรวมไลบรารีเนทีฟที่จำเป็น(**libgdiplus**, แพ็คเกจฟอนต์ ฯลฯ)และเวอร์ชัน Python ที่ถูกต้อง

**มีเวอร์ชันฟรีหรือข้อจำกัดของรุ่นทดลองหรือไม่?**

ใช่ โดยค่าเริ่มต้น Aspose.Slides จะทำงานในโหมดประเมินผล ซึ่งจะใส่ลายน้ำและอาจมีข้อจำกัดอื่น ๆ เพื่อเอาข้อจำกัดออก คุณต้องใช้[license](/slides/th/python-net/licensing/)ที่ถูกต้อง.