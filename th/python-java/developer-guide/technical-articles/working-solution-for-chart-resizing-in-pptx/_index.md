---
title: วิธีแก้ปัญหาการปรับขนาดกราฟใน PPTX
type: docs
weight: 40
url: /th/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดกราฟ
- กราฟ Excel
- วัตถุ OLE
- ฝังกราฟ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แก้ไขการปรับขนาดกราฟที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ Excel OLE ที่ฝังไว้กับ Aspose.Slides for Python via Java เรียนรู้สองวิธีพร้อมโค้ดเพื่อคงขนาดให้สม่ำเสมอ"
---
## **พื้นหลัง**

พบว่ากราฟ Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนต์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านภาพที่เห็นได้ชัดในงานนำเสนอระหว่างสถานะก่อนและหลังการเปิดใช้งานของกราฟ ทีมงาน Aspose ได้ตรวจสอบปัญหาอย่างละเอียดและพบวิธีแก้ไข บทความนี้อธิบายสาเหตุของปัญหาและการแก้ไขที่สอดคล้องกัน

ใน[บทความก่อนหน้า](/slides/th/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), เราอธิบายวิธีการสร้างกราฟ Excel ด้วย Aspose.Cells for Python via Java และฝังลงในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for Python via Java เพื่อแก้ไข[ปัญหาการแสดงตัวอย่างวัตถุ](/slides/th/python-java/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดภาพกราฟให้กับกรอบวัตถุ OLE ของกราฟ ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบวัตถุ OLE ที่แสดงภาพกราฟ Excel จะถูกเปิดใช้งาน ผู้ใช้ขั้นสุดท้ายสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการในเวิร์กบุ๊ก Excel ที่อยู่เบื้องหลังและจากนั้นกลับไปยังสไลด์ที่เกี่ยวข้องโดยคลิกนอกเวิร์กบุ๊กที่เปิดใช้งาน ขนาดของกรอบวัตถุ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์และปัจจัยการปรับขนาดจะแตกต่างกันไปขึ้นอยู่กับขนาดเดิมของกรอบวัตถุ OLE และเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของมันเอง มันพยายามคงขนาดเดิมไว้ในครั้งแรกที่เปิดใช้งาน กรอบวัตถุ OLE แต่ละกรอบมีขนาดของมันเอง ตามข้อมูลของ Microsoft เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดและรักษาสัดส่วนที่เหมาะสมเป็นส่วนหนึ่งของกระบวนการฝัง ขึ้นอยู่กับความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดหรือสถานที่ของกรอบวัตถุ OLE การปรับขนาดจึงเกิดขึ้น

## **วิธีแก้ไขที่ใช้งานได้**

มีสองสถานการณ์ที่เป็นไปได้สำหรับการสร้างงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for Python via Java  

**Scenario 1:** สร้างงานนำเสนอจากเทมเพลตที่มีอยู่  

**Scenario 2:** สร้างงานนำเสนอจากศูนย์  

วิธีแก้ที่เรานำเสนอที่นี่ใช้ได้กับทั้งสองสถานการณ์ พื้นฐานของวิธีแก้ทั้งหมดคือเดียวกัน: **ขนาดหน้าต่างของวัตถุ OLE ที่ฝังควรตรงกับกรอบวัตถุ OLE ในสไลด์ PowerPoint** เราจะพูดถึงสองวิธีแก้นี้ต่อไป

## **วิธีการแรก**

ในวิธีนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดหน้าต่างของเวิร์กบุ๊ก Excel ที่ฝังให้ตรงกับขนาดของกรอบวัตถุ OLE ในสไลด์ PowerPoint

**Scenario 1**

สมมติว่าเราได้กำหนดเทมเพลตและต้องการสร้างงานนำเสนอจากเทมเพลตดังกล่าว สมมติว่ามีรูปทรงที่ตำแหน่งที่ 2 ในเทมเพลตที่เราต้องการวางกรอบ OLE ที่มีเวิร์กบุ๊ก Excel ฝังอยู่ ในสถานการณ์นี้ขนาดของกรอบวัตถุ OLE ถูกกำหนดไว้ล่วงหน้า — ตรงกับขนาดของรูปทรงที่ตำแหน่งที่ 2 ในเทมเพลต เพียงแค่ตั้งค่าขนาดหน้าต่างของเวิร์กบุ๊กให้เท่ากับขนาดของรูปทรงนั้นเท่านั้น โค้ดตัวอย่างต่อไปนี้ทำหน้าที่ดังกล่าว

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# โหลด workbook Excel ที่มีกราฟ
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # ตั้งขนาดหน้าต่าง workbook เป็นนิ้ว (PowerPoint ใช้ 72 จุดต่อหนึ่งนิ้ว)
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # บันทึก workbook ไปยังสตรีมหน่วยความจำ
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # สร้างกรอบวัตถุ OLE พร้อมข้อมูล Excel ที่ฝังอยู่
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

สมมติว่าเราต้องการสร้างงานนำเสนอจากศูนย์และเพิ่มกรอบวัตถุ OLE ขนาดใดก็ได้พร้อมเวิร์กบุ๊ก Excel ฝังไว้ ในโค้ดตัวอย่างต่อไปนี้ เราสร้างกรอบวัตถุ OLE สูง 4 นิ้วและกว้าง 9.5 นิ้ว ที่ตำแหน่ง x = 0.5 นิ้ว และ y = 1 นิ้วบนสไลด์ แล้วตั้งค่าหน้าต่างเวิร์กบุ๊ก Excel ให้มีขนาดเดียวกัน — สูง 4 นิ้วและกว้าง 9.5 นิ้ว

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# โหลด workbook Excel ที่มีกราฟ
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 นิ้ว (4 * 72).
    desired_width = 684  # 9.5 นิ้ว (9.5 * 72).

    # กำหนดขนาดกราฟด้วยหน้าต่าง
    chart.setSizeWithWindow(True)

    # ตั้งค่าขนาดหน้าต่าง workbook เป็นนิ้ว (PowerPoint ใช้ 72 จุดต่อหนึ่งนิ้ว)
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # บันทึก workbook ไปยังสตรีมหน่วยความจำ
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # สร้างกรอบวัตถุ OLE พร้อมข้อมูล Excel ที่ฝังอยู่
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **วิธีการที่สอง**

ในวิธีนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดของกราฟในเวิร์กบุ๊ก Excel ที่ฝังให้ตรงกับขนาดของกรอบวัตถุ OLE ในสไลด์ PowerPoint วิธีนี้เป็นประโยชน์เมื่อขนาดของกราฟทราบล่วงหน้าและจะไม่เปลี่ยนแปลง

**Scenario 1**

สมมติว่าเราได้กำหนดเทมเพลตและต้องการสร้างงานนำเสนอจากเทมเพลตดังกล่าว สมมติว่ามีรูปทรงที่ตำแหน่งที่ 2 ในเทมเพลตที่เราตั้งใจจะวางกรอบ OLE ที่มีเวิร์กบุ๊ก Excel ฝังอยู่ ในสถานการณ์นี้ขนาดของกรอบ OLE ถูกกำหนดไว้ล่วงหน้า — ตรงกับขนาดของรูปทรงที่ตำแหน่งที่ 2 ในเทมเพลต เพียงแค่ตั้งค่าขนาดของกราฟในเวิร์กบุ๊กให้เท่ากับขนาดของรูปทรงนั้น โค้ดตัวอย่างต่อไปนี้ทำหน้าที่ดังกล่าว

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# โหลด workbook Excel ที่มีกราฟ
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # กำหนดขนาดกราฟโดยไม่ใช้หน้าต่าง
    chart.setSizeWithWindow(False)

    # ตั้งค่าขนาดกราฟเป็นพิกเซล (Excel ใช้ 96 พิกเซลต่อหนึ่งนิ้ว)
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # กำหนดขนาดการพิมพ์ของกราฟ
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # บันทึก workbook ไปยังสตรีมหน่วยความจำ
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # สร้างกรอบวัตถุ OLE พร้อมข้อมูล Excel ที่ฝังอยู่
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

สมมติว่าเราต้องการสร้างงานนำเสนอจากศูนย์และเพิ่มกรอบวัตถุ OLE ขนาดใดก็ได้พร้อมเวิร์กบุ๊ก Excel ฝังไว้ ในโค้ดตัวอย่างต่อไปนี้ เราสร้างกรอบวัตถุ OLE สูง 4 นิ้วและกว้าง 9.5 นิ้ว ที่ตำแหน่ง x = 0.5 นิ้ว และ y = 1 นิ้วบนสไลด์ พร้อมตั้งค่าขนาดของกราฟที่สอดคล้องให้มีขนาดเดียวกัน — สูง 4 นิ้วและกว้าง 9.5 นิ้ว

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# โหลด workbook Excel ที่มีกราฟ.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 นิ้ว (4 * 72).
    desired_width = 684  # 9.5 นิ้ว (9.5 * 72).

    # กำหนดขนาดกราฟโดยไม่ใช้หน้าต่าง.
    chart.setSizeWithWindow(False)

    # ตั้งค่าขนาดกราฟเป็นพิกเซล (Excel ใช้ 96 พิกเซลต่อหนึ่งนิ้ว).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # บันทึก workbook ไปยังสตรีมหน่วยความจำ.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # สร้างกรอบวัตถุ OLE พร้อมข้อมูล Excel ที่ฝังอยู่.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **สรุป**

มีสองวิธีแก้ปัญหาการปรับขนาดของกราฟ ทั้งสองวิธีขึ้นกับความต้องการและกรณีการใช้งาน ตัวเลือกใดตัวเลือกหนึ่งทำงานได้เช่นเดียวกันไม่ว่าการสร้างงานนำเสนอจะมาจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบวัตถุ OLE ในวิธีแก้นี้

## **คำถามที่พบบ่อย**

**ทำไมกราฟ Excel ที่ฝังอยู่จึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**  
เนื่องจาก Excel พยายามคืนค่าขนาดหน้าต่างเดิมเมื่อเปิดใช้งานครั้งแรก ส่วนกรอบวัตถุ OLE ใน PowerPoint มีขนาดของมันเอง PowerPoint และ Excel จะแก้ไขขนาดเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้เกิดการปรับขนาดได้

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้โดยสมบูรณ์หรือไม่?**  
ได้ โดยการทำให้ขนาดหน้าต่างเวิร์กบุ๊ก Excel หรือขนาดกราฟตรงกับขนาดของกรอบวัตถุ OLE ก่อนทำการฝัง จะทำให้ขนาดกราฟคงที่

**ควรเลือกวิธีใด การตั้งค่าขนาดหน้าต่างเวิร์กบุ๊กหรือการตั้งค่าขนาดกราฟ?**  
ใช้ **วิธีที่ 1 (ขนาดหน้าต่าง)** หากต้องการรักษาอัตราส่วนของเวิร์กบุ๊กและอาจต้องการให้ผู้ใช้ปรับขนาดได้ในภายหลัง  
ใช้ **วิธีที่ 2 (ขนาดกราฟ)** หากขนาดของกราฟเป็นค่าคงที่และจะไม่เปลี่ยนแปลงหลังการฝัง

**วิธีเหล่านี้จะทำงานกับงานนำเสนอแบบเทมเพลตและงานนำเสนอใหม่หรือไม่?**  
ใช่ ทั้งสองวิธีทำงานเช่นเดียวกันสำหรับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของกรอบวัตถุ OLE หรือไม่?**  
ไม่มี คุณสามารถตั้งค่ากรอบ OLE ให้เป็นขนาดใดก็ได้ตราบใดที่สัดส่วนสอดคล้องกับขนาดของเวิร์กบุ๊กหรือกราฟ

**สามารถใช้วิธีเหล่านี้กับกราฟที่สร้างจากโปรแกรมสเปรดชีตอื่นได้หรือไม่?**  
ตัวอย่างออกแบบมาสำหรับกราฟ Excel ที่สร้างด้วย Aspose.Cells แต่หลักการเดียวกันสามารถนำไปใช้กับโปรแกรมสเปรดชีตอื่นที่รองรับ OLE และให้ตัวเลือกการกำหนดขนาดที่คล้ายกันได้

## **Related Sections**

- [สร้างกราฟ Excel และฝังเป็นวัตถุ OLE ในงานนำเสนอ](/slides/th/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)