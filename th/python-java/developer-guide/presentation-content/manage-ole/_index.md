---
title: จัดการ OLE ในการพรีเซนเทชันด้วย Python
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/python-java/manage-ole/
keywords:
- อ็อบเจ็กต์ OLE
- การเชื่อมโยงและฝังอ็อบเจ็กต์
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มอ็อบเจ็กต์
- ฝังอ็อบเจ็กต์
- เพิ่มไฟล์
- ฝังไฟล์
- อ็อบเจ็กต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อหัวข้อ OLE
- สกัด OLE
- สกัดอ็อบเจ็กต์
- สกัดไฟล์
- PowerPoint
- พรีเซนเทชัน
- Python
- Java
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการอ็อบเจ็กต์ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via Java ฝัง, ปรับปรุง, และส่งออกเนื้อหา OLE อย่างราบรื่น"
---
## **บทนำ**

{{% alert color="info" title="หมายเหตุ" %}}

OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและอ็อบเจ็กต์ที่สร้างในแอปพลิเคชันหนึ่งถูกวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝัง

{{% /alert %}}

พิจารณาแผนภูมิที่สร้างใน MS Excel แผนภูมินั้นจะถูกวางลงในสไลด์ PowerPoint แผนภูมิ Excel นี้ถือเป็นอ็อบเจ็กต์ OLE

- อ็อบเจ็กต์ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอน แผนภูมิจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือคุณจะถูกถามให้เลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขอ็อบเจ็กต์
- อ็อบเจ็กต์ OLE อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของแผนภูมิ ในกรณีนี้แผนภูมิจะถูกเปิดใช้งานใน PowerPoint ส่วนติดต่อของแผนภูมิจะโหลดและคุณสามารถแก้ไขข้อมูลของแผนภูมิภายใน PowerPoint

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) ช่วยให้คุณแทรกอ็อบเจ็กต์ OLE ลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/))

## **เพิ่มกรอบอ็อบเจ็กต์ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างแผนภูมิใน Microsoft Excel แล้วต้องการฝังมันลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE โดยใช้ Aspose.Slides for Python via Java คุณสามารถทำได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์
1. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) ไปยังสไลด์ที่มีอาร์เรย์ไบต์และข้อมูลอื่น ๆ เกี่ยวกับอ็อบเจ็กต์ OLE
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มแผนภูมิจากไฟล์ Excel ลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE โดยใช้ Aspose.Slides for Python via Java. **หมายเหตุ** คอนสตรัคเตอร์ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) รับส่วนต่อขยายของอ็อบเจ็กต์ที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง ส่วนต่อขยายนี้ทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดอ็อบเจ็กต์ OLE นี้.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # เตรียมข้อมูลสำหรับอ็อบเจ็กต์ OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # เพิ่มกรอบอ็อบเจ็กต์ OLE ลงในสไลด์.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **เพิ่มกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides for Python via Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) พร้อมลิงก์ไปยังไฟล์แทนข้อมูลที่ฝังไว้

โค้ด Python นี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) ที่เชื่อมโยงไฟล์ Excel ไปยังสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มกรอบอ็อบเจ็กต์ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เข้าถึงกรอบอ็อบเจ็กต์ OLE**

หากอ็อบเจ็กต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถค้นหา หรือเข้าถึงมันได้อย่างง่ายดายตามวิธีนี้:

1. โหลดพรีเซนเทชันที่มีอ็อบเจ็กต์ OLE ฝังอยู่โดยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์ตามดัชนีของมัน
3. เข้าถึงรูปร่าง [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) .
   ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างขึ้นก่อนหน้านี้ซึ่งมีรูปร่างเพียงหนึ่งรูปบนสไลด์แรก จากนั้นเราตรวจสอบว่าอ็อบเจ็กต์เป็น [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) นี่คือกรอบอ็อบเจ็กต์ OLE ที่ต้องการเข้าถึง
4. เมื่อเข้าถึงกรอบอ็อบเจ็กต์ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบอ็อบเจ็กต์ OLE (อ็อบเจ็กต์แผนภูมิ Excel ที่ฝังอยู่ในสไลด์) และข้อมูลไฟล์ของมัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # ดึงข้อมูลไฟล์ที่ฝังไว้.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # ดึงส่วนต่อขยายของไฟล์ที่ฝังไว้.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **เข้าถึงคุณสมบัติกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides อนุญาตให้คุณเข้าถึงคุณสมบัติกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง

โค้ด Python นี้แสดงวิธีการตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่และจากนั้นรับเส้นทางไปยังไฟล์ที่เชื่อมโยง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # ตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่.
        if ole_frame.isObjectLink():
            # พิมพ์พาธเต็มของไฟล์ที่เชื่อมโยง.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # พิมพ์พาธสัมพัทธ์ของไฟล์ที่เชื่อมโยงหากมี.
            # เฉพาะพรีเซนเทชัน PPT เท่านั้นที่สามารถมีพาธสัมพัทธ์ได้.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **เปลี่ยนข้อมูลอ็อบเจ็กต์ OLE**

{{% alert color="info" title="หมายเหตุ" %}}

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/)

{{% /alert %}}

หากอ็อบเจ็กต์ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงอ็อบเจ็กต์นั้นและแก้ไขข้อมูลของมันได้อย่างง่ายดายตามวิธีนี้:

1. โหลดพรีเซนเทชันที่มีอ็อบเจ็กต์ OLE ฝังอยู่โดยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์ตามดัชนีของมัน
3. เข้าถึงรูปร่างกรอบอ็อบเจ็กต์ OLE.
   ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างก่อนหน้านี้ซึ่งมีรูปร่างหนึ่งรูปบนสไลด์แรก จากนั้นเราตรวจสอบว่าอ็อบเจ็กต์เป็น [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) นี่คือกรอบอ็อบเจ็กต์ OLE ที่ต้องการเข้าถึง
4. เมื่อเข้าถึงกรอบอ็อบเจ็กต์ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้
5. สร้างอ็อบเจ็กต์ [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) แล้วเข้าถึงข้อมูล OLE
6. เข้าถึง [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) ที่ต้องการและแก้ไขข้อมูล
7. บันทึก [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) ที่อัปเดตลงในสตรีม
8. เปลี่ยนข้อมูลอ็อบเจ็กต์ OLE จากสตรีม

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบอ็อบเจ็กต์ OLE (อ็อบเจ็กต์แผนภูมิ Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลของแผนภูมิ

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # อ่านข้อมูลอ็อบเจ็กต์ OLE เป็นอ็อบเจ็กต์ Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # ปรับเปลี่ยนข้อมูล workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # เปลี่ยนข้อมูลอ็อบเจ็กต์ OLE frame.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ฝังประเภทไฟล์อื่นในสไลด์**

นอกจากแผนภูมิ Excel แล้ว Aspose.Slides for Python via Java ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นอ็อบเจ็กต์ เมื่อผู้ใช้ดับเบิลคลิกอ็อบเจ็กต์ที่แทรกไว้ จะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือผู้ใช้จะได้รับการแจ้งเพื่อเลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์นั้น

โค้ด Python นี้แสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝัง**

เมื่อทำงานกับพรีเซนเทชัน คุณอาจต้องการแทนที่อ็อบเจ็กต์ OLE เก่าเป็นออบเจ็กต์ใหม่ หรือแทนที่อ็อบเจ็กต์ OLE ที่ไม่รองรับด้วยอ็อบเจ็กต์ที่รองรับ Aspose.Slides for Python via Java อนุญาตให้คุณตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝัง เพื่อให้สามารถอัปเดตข้อมูลกรอบ OLE หรือส่วนต่อขยายของมันได้

โค้ด Python นี้แสดงวิธีการตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ OLE ที่ฝังเป็น `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # เปลี่ยนประเภทไฟล์เป็น ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าภาพไอคอนและหัวข้อสำหรับอ็อบเจ็กต์ที่ฝัง**

หลังจากอ็อบเจ็กต์ OLE ถูกฝัง จะมีการเพิ่มการแสดงตัวอย่างที่ประกอบด้วยภาพไอคอนโดยอัตโนมัติ การแสดงตัวอย่างนี้เป็นสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดอ็อบเจ็กต์ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นส่วนประกอบของการแสดงตัวอย่าง คุณสามารถตั้งค่าภาพไอคอนและหัวข้อโดยใช้ Aspose.Slides for Python via Java

โค้ด Python นี้แสดงวิธีการตั้งค่าภาพไอคอนและหัวข้อสำหรับอ็อบเจ็กต์ที่ฝัง:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # เพิ่มภาพลงในทรัพยากรของพรีเซนเทชัน.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # ตั้งชื่อและภาพสำหรับการแสดงตัวอย่าง OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ป้องกันไม่ให้กรอบอ็อบเจ็กต์ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากคุณเพิ่มอ็อบเจ็กต์ OLE ที่เชื่อมโยงลงในสไลด์พรีเซนเทชัน เมื่อเปิดพรีเซนเทชันใน PowerPoint คุณอาจเห็นข้อความขอให้อัปเดตลิงก์ การคลิกปุ่ม “Update Links” อาจทำให้ขนาดและตำแหน่งของกรอบอ็อบเจ็กต์ OLE เปลี่ยนไปเนื่องจาก PowerPoint อัปเดตข้อมูลจากอ็อบเจ็กต์ OLE ที่เชื่อมโยงและรีเฟรชการแสดงตัวอย่างของอ็อบเจ็กต์ เพื่อป้องกันไม่ให้ PowerPoint แสดงการแจ้งให้อต่อข้อมูลของอ็อบเจ็กต์ ให้เรียกเมธอด [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) ของคลาส [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) ด้วยค่า `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สกัดไฟล์ที่ฝัง**

Aspose.Slides for Python via Java อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจ็กต์ OLE ด้วยวิธีต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ที่มีอ็อบเจ็กต์ OLE ที่คุณต้องการสกัด
2. วนลูปผ่านรูปร่างทั้งหมดในพรีเซนเทชันและเข้าถึงรูปร่าง [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบอ็อบเจ็กต์ OLE แล้วบันทึกลงดิสก์

โค้ด Python นี้แสดงวิธีการสกัดไฟล์ที่ฝังในสไลด์เป็นอ็อบเจ็กต์ OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**

สิ่งที่มองเห็นบนสไลด์จะถูกเรนเดอร์—คือไอคอน/รูปภาพแทน (การแสดงตัวอย่าง) เนื้อหา OLE “สด” จะไม่ถูกประมวลผลระหว่างการเรนเดอร์ หากต้องการสามารถตั้งค่าภาพตัวอย่างของคุณเองเพื่อให้ได้ลักษณะที่คาดหวังใน PDF ที่ส่งออก

เพื่อให้คงไฟล์ที่ฝังไว้เป็นไฟล์แนบใน PDF ด้วย ให้เรียก [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) ด้วยค่า `True` ตัวเลือกนี้ปิดใช้งานโดยค่าเริ่มต้น สำหรับตัวอย่างและวิธีตรวจสอบไฟล์แนบ ดูที่ [Preserve Embedded OLE Files as PDF Attachments](/slides/th/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)

**ฉันจะล็อกอ็อบเจ็กต์ OLE บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขได้ใน PowerPoint ได้อย่างไร?**

ล็อกรูปร่าง: Aspose.Slides มีการให้บริการ [shape-level locks](/slides/th/python-java/applying-protection-to-presentation/) นี่ไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยบังเอิญอย่างมีประสิทธิภาพ

**ทำไมอ็อบเจ็กต์ Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อฉันเปิดพรีเซนเทชัน?**

PowerPoint อาจรีเฟรชการแสดงตัวอย่างของ OLE ที่เชื่อมโยง เพื่อให้ลักษณะคงที่ ให้ปฏิบัติตามแนวทางของ [Working Solution for Worksheet Resizing](/slides/th/python-java/working-solution-for-worksheet-resizing/) คือ ปรับกรอบให้พอดีกับช่วงข้อมูล หรือปรับสเกลช่วงให้เข้ากับกรอบคงที่แล้วตั้งค่าภาพแทนที่เหมาะสม

**เส้นทางสัมพัทธ์สำหรับอ็อบเจ็กต์ OLE ที่เชื่อมโยงจะถูกคงไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ไม่มีข้อมูล “เส้นทางสัมพัทธ์” — มีเฉพาะเส้นทางเต็มเท่านั้น เส้นทางสัมพัทธ์พบในรูปแบบ PPT เก่ากว่า สำหรับการพกพา แนะนำให้ใช้เส้นทางแบบเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือการฝังไฟล์.