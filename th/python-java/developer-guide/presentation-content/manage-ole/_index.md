---
title: จัดการ OLE ในงานนำเสนอโดยใช้ Python
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
- หัวข้อ OLE
- สกัด OLE
- สกัดอ็อบเจ็กต์
- สกัดไฟล์
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการอ็อบเจ็กต์ OLE ใน PowerPoint และไฟล์ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java. ฝัง, อัปเดตและส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="info" title="หมายเหตุ" %}}

OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและอ็อบเจ็กต์ที่สร้างในแอปพลิเคชันหนึ่งถูกวางไว้ในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือฝังข้อมูล

{{% /alert %}}

ให้พิจารณากราฟที่สร้างใน MS Excel แล้วนำกราฟนั้นไปวางไว้ในสไลด์ PowerPoint กราฟ Excel นี้จะถือเป็นอ็อบเจ็กต์ OLE

- อ็อบเจ็กต์ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกไอคอนกราฟจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือจะมีการขอให้คุณเลือกแอปพลิเคชันสำหรับเปิดหรือแก้ไขอ็อบเจ็กต์
- อ็อบเจ็กต์ OLE อาจแสดงเนื้อหาจริง เช่น เนื้อหาของกราฟ ในกรณีนี้กราฟจะทำงานใน PowerPoint ส่วนตานของกราฟจะโหลดและคุณสามารถแก้ไขข้อมูลของกราฟได้ภายใน PowerPoint

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/th/python-java/) ช่วยให้คุณแทรกอ็อบเจ็กต์ OLE ลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE ([OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/))

## **เพิ่มกรอบอ็อบเจ็กต์ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างกราฟใน Microsoft Excel แล้วต้องการฝังกราฟนั้นในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE โดยใช้ Aspose.Slides for Python via Java คุณสามารถทำได้ดังนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) ลงในสไลด์โดยใส่อาร์เรย์ไบต์และข้อมูลอื่น ๆ ของอ็อบเจ็กต์ OLE
5. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มกราฟจากไฟล์ Excel ลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE โดยใช้ Aspose.Slides for Python via Java  
**หมายเหตุ** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleembeddeddatainfo/) รับส่วนขยายของอ็อบเจ็กต์ที่ฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ช่วยให้ PowerPoint แปลความหมายประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดอ็อบเจ็กต์ OLE นี้

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

Aspose.Slides for Python via Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) โดยไม่ฝังข้อมูล แต่เพียงเชื่อมโยงไปยังไฟล์เท่านั้น

โค้ด Python นี้แสดงวิธีเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) ที่เชื่อมโยงไฟล์ Excel ไปยังสไลด์:

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

## **การเข้าถึงกรอบอ็อบเจ็กต์ OLE**

หากอ็อบเจ็กต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถค้นหาและเข้าถึงได้ดังนี้

1. โหลดพรีเซนเทชันที่มีอ็อบเจ็กต์ OLE ฝังไว้โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/)   ตัวอย่างของเราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape เพียงหนึ่งรูปบนสไลด์แรก เราตรวจสอบว่า shape นั้นเป็น [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) ซึ่งเป็นกรอบอ็อบเจ็กต์ OLE ที่ต้องการเข้าถึง
4. เมื่อเข้าถึงกรอบอ็อบเจ็กต์ OLE ได้แล้ว คุณสามารถทำการใด ๆ กับมันได้

ในตัวอย่างด้านล่าง เราเข้าถึงกรอบอ็อบเจ็กต์ OLE (อ็อบเจ็กต์กราฟ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน

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

        # รับข้อมูลไฟล์ที่ฝังไว้.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # รับส่วนขยายของไฟล์ที่ฝังไว้.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **เข้าถึงคุณสมบัติกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides ช่วยให้คุณเข้าถึงคุณสมบัติกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยงได้

โค้ด Python นี้แสดงวิธีตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่และรับเส้นทางของไฟล์ที่เชื่อมโยง

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
            # พิมพ์เส้นทางเต็มของไฟล์ที่เชื่อมโยง.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # พิมพ์เส้นทางแบบ relative ของไฟล์ที่เชื่อมโยงหากมี.
            #เฉพาะงานนำเสนอ PPT เท่านั้นที่สามารถมีเส้นทางแบบ relative ได้.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **เปลี่ยนแปลงข้อมูลอ็อบเจ็กต์ OLE**

{{% alert color="info" title="หมายเหตุ" %}}

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/)

{{% /alert %}}

หากอ็อบเจ็กต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของอ็อบเจ็กต์นั้นได้ดังนี้

1. โหลดพรีเซนเทชันที่มีอ็อบเจ็กต์ OLE ฝังไว้โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เข้าถึง shape ของกรอบอ็อบเจ็กต์ OLE   ตัวอย่างของเราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape หนึ่งรูปบนสไลด์แรก เราตรวจสอบว่า shape นั้นเป็น [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) ซึ่งเป็นกรอบอ็อบเจ็กต์ OLE ที่ต้องการเข้าถึง
4. เมื่อเข้าถึงกรอบอ็อบเจ็กต์ OLE ได้แล้ว คุณสามารถทำการใด ๆ กับมันได้
5. สร้างอ็อบเจ็กต์ [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) และเข้าถึงข้อมูล OLE
6. เข้าถึง [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) ที่ต้องการและแก้ไขข้อมูล
7. บันทึก [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) ที่อัปเดตในสตรีม
8. เปลี่ยนแปลงข้อมูลอ็อบเจ็กต์ OLE จากสตรีม

ในตัวอย่างด้านล่าง เราเข้าถึงกรอบอ็อบเจ็กต์ OLE (อ็อบเจ็กต์กราฟ Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลกราฟ

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpase.startJVM()

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

        # แก้ไขข้อมูล workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # เปลี่ยนแปลงข้อมูลอ็อบเจ็กต์ OLE frame.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ฝังไฟล์ประเภทอื่นลงในสไลด์**

นอกจากกราฟ Excel แล้ว Aspose.Slides for Python via Java ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ เช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นอ็อบเจ็กต์ เมื่อผู้ใช้ดับเบิลคลิกอ็อบเจ็กต์ที่แทรกไว้ โปรแกรมที่เกี่ยวข้องจะเปิดอัตโนมัติ หรือระบบจะแจ้งให้ผู้ใช้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์นั้น

โค้ด Python นี้แสดงวิธีฝัง HTML และ ZIP ลงในสไลด์:

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

## **ตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝังไว้**

เมื่อทำงานกับพรีเซนเทชัน คุณอาจต้องการแทนที่อ็อบเจ็กต์ OLE เก่าโดยอ็อบเจ็กต์ใหม่หรือแทนที่อ็อบเจ็กต์ OLE ที่ไม่รองรับด้วยอ็อบเจ็กต์ที่รองรับ Aspose.Slides for Python via Java ให้คุณตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝังไว้ เพื่ออัปเดตข้อมูลกรอบ OLE หรือส่วนขยายของไฟล์

โค้ด Python นี้แสดงวิธีตั้งค่าประเภทไฟล์สำหรับอ็อบเจ็กต์ OLE ที่ฝังไว้เป็น `zip`

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

## **ตั้งค่าภาพไอคอนและหัวเรื่องสำหรับอ็อบเจ็กต์ที่ฝังไว้**

หลังจากฝังอ็อบเจ็กต์ OLE แล้ว ระบบจะเพิ่มภาพพรีวิวที่เป็นไอคอนโดยอัตโนมัติ พรีวิวนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดอ็อบเจ็กต์ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นองค์ประกอบในพรีวิว คุณสามารถตั้งค่าภาพไอคอนและหัวเรื่องได้โดยใช้ Aspose.Slides for Python via Java

โค้ด Python นี้แสดงวิธีตั้งค่าภาพไอคอนและหัวเรื่องสำหรับอ็อบเจ็กต์ที่ฝังไว้:

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

    # เพิ่มภาพไปยังทรัพยากรของงานนำเสนอ.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # ตั้งหัวเรื่องและภาพสำหรับพรีวิว OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ป้องกันไม่ให้กรอบอ็อบเจ็กต์ OLE ถูกปรับขนาดหรือขยับตำแหน่ง**

หลังจากคุณเพิ่มอ็อบเจ็กต์ OLE ที่เชื่อมโยงลงในสไลด์พรีเซนเทชัน เมื่อเปิดพรีเซนเทชันใน PowerPoint คุณอาจพบข้อความแจ้งให้คุณอัปเดตลิงก์ การคลิกปุ่ม "Update Links" อาจทำให้ขนาดและตำแหน่งของกรอบอ็อบเจ็กต์ OLE เปลี่ยนแปลงไป เนื่องจาก PowerPoint อัปเดตข้อมูลจากอ็อบเจ็กต์ OLE ที่เชื่อมโยงและรีเฟรชพรีวิวอ็อบเจ็กต์ เพื่อลดการแจ้งเตือนให้ PowerPoint อัปเดตข้อมูลของอ็อบเจ็กต์ ให้ตั้งค่าเมธอด [setUpdateAutomatic](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) ของคลาส [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) เป็น `False`:

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

## **สกัดไฟล์ที่ฝังไว้**

Aspose.Slides for Python via Java อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจ็กต์ OLE ได้ดังนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ที่มีอ็อบเจ็กต์ OLE ที่ต้องการสกัด
2. วนลูปผ่าน shape ทั้งหมดในพรีเซนเทชันและเข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/)
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบอ็อบเจ็กต์ OLE และเขียนลงดิสก์

โค้ด Python นี้แสดงวิธีสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจ็กต์ OLE:

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

## **คำถามที่พบบ่อย**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**

สิ่งที่มองเห็นบนสไลด์คือไอคอน/ภาพทดแทน (พรีวิว) ที่จะถูกเรนเดอร์ ส่วนเนื้อหา OLE แบบ “สด” จะไม่ถูกดำเนินการในขั้นตอนการเรนเดอร์ หากต้องการ ให้ตั้งค่าภาพพรีวิวของคุณเองเพื่อให้แน่ใจว่าดูเหมือนที่คาดหวังในไฟล์ PDF ที่ส่งออก

**ฉันจะล็อกอ็อบเจ็กต์ OLE บนสไลด์เพื่อไม่ให้ผู้ใช้ย้ายหรือแก้ไขใน PowerPoint ได้อย่างไร?**

ล็อก shape: Aspose.Slides มี [shape-level locks](/slides/th/python-java/applying-protection-to-presentation/) ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขและการย้ายโดยไม่ได้ตั้งใจ

**ทำไมอ็อบเจ็กต์ Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อตัวเปิดพรีเซนเทชัน?**

PowerPoint อาจรีเฟรชพรีวิวของ OLE ที่เชื่อมโยง เพื่อให้แสดงผลคงที่ ให้ทำตามแนวทางใน [Working Solution for Worksheet Resizing](/slides/th/python-java/working-solution-for-worksheet-resizing/) คือ ปรับขนาดเฟรมให้พอดีกับช่วงข้อมูล หรือสเกลช่วงข้อมูลให้พอดีกับเฟรมคงที่และตั้งค่าภาพทดแทนที่เหมาะสม

**เส้นทางแบบ relative สำหรับอ็อบเจ็กต์ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ไม่มีข้อมูล “relative path” – มีเฉพาะเส้นทางเต็มเท่านั้น เส้นทางแบบ relative พบได้ในรูปแบบ PPT เก่า สำหรับความพกพา ควรใช้เส้นทางเต็มที่เชื่อถือได้หรือ URI ที่เข้าถึงได้ หรือฝังไฟล์ไว้โดยตรง