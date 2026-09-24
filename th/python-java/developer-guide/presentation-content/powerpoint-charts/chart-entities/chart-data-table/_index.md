---
title: ปรับแต่งตารางข้อมูลแผนภูมิในการนำเสนอโดยใช้ Python
linktitle: ตารางข้อมูล
type: docs
url: /th/python-java/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติตัวอักษร
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ปรับแต่งแบบอักษรของตารางข้อมูลแผนภูมิ, เส้นขอบ, และคีย์คำอธิบายในการนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ช่วยให้คุณสามารถแสดงตารางข้อมูลของแผนภูมิและปรับแต่งการจัดรูปแบบข้อความ, เส้นขอบ, และคีย์คำอธิบายของตาราง. บทความนี้อธิบายวิธีเปิดใช้งานตาราง, จัดรูปแบบข้อความ, ควบคุมแต่ละประเภทของเส้นขอบ, และแสดงหรือซ่อนคีย์คำอธิบาย. ตัวอย่างจะบันทึกแผนภูมิที่กำหนดค่าไว้เป็นไฟล์ PPTX.

## **ตั้งค่าคุณสมบัติตัวอักษร**

เพื่อแสดงตารางข้อมูลของแผนภูมิ, ให้ส่งค่า `True` ไปยัง [setDataTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setDataTable). ใช้ [getChartDataTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#getChartDataTable) เพื่อเข้าถึงตารางและกำหนดการจัดรูปแบบข้อความ.

1. โหลดการนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มไปยังสไลด์แรก.  
1. เปิดใช้งานตารางข้อมูลของแผนภูมิ.  
1. เปิดใช้งานข้อความตัวหนาด้วย [setFontBold](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setFontBold) และส่งค่า `20` ไปยัง [setFontHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อใช้ข้อความขนาด 20 จุด.  
1. บันทึกการนำเสนอที่แก้ไขแล้ว.

ตัวอย่างต่อไปนี้ต้องมีไฟล์ `test.pptx` อยู่ในไดเรกทอรีทำงานพร้อมสไลด์อย่างน้อยหนึ่งสไลด์. มันจะเพิ่มแผนภูมิที่มีข้อมูลเริ่มต้นที่ตำแหน่ง (50, 50) โดยมีความกว้าง 600 จุดและความสูง 400 จุด. ไฟล์ `output.pptx` ที่บันทึกไว้จะมีแผนภูมิพร้อมตารางข้อมูลที่เปิดใช้งานและการตั้งค่าตัวอักษรที่ระบุ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนดเส้นขอบของตารางข้อมูล**

เปิดใช้งานตารางด้วย [Chart.setDataTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setDataTable) และเข้าถึงมันผ่าน [Chart.getChartDataTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#getChartDataTable). คุณสามารถควบคุมเส้นขอบสามประเภทได้แยกกัน:

- [setBorderHorizontal](https://reference.aspose.com/slides/th/python-java/aspose.slides/datatable/#setBorderHorizontal) ควบคุมเส้นขอบแนวนอนของเซลล์.  
- [setBorderVertical](https://reference.aspose.com/slides/th/python-java/aspose.slides/datatable/#setBorderVertical) ควบคุมเส้นขอบแนวตั้งของเซลล์.  
- [setBorderOutline](https://reference.aspose.com/slides/th/python-java/aspose.slides/datatable/#setBorderOutline) ควบคุมเส้นขอบภายนอกของตาราง.

ส่งค่า `True` ไปยังแต่ละเมธอดเพื่อแสดงเส้นขอบหรือ `False` เพื่อซ่อน. ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้น, แสดงเส้นขอบแนวนอนและเส้นขอบภายนอก, และซ่อนเส้นขอบแนวตั้ง. ไม่ต้องใช้ไฟล์อินพุตใด ๆ. ตำแหน่งและขนาดของแผนภูมิระบุเป็นจุด.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเปรียบเทียบด้านล่างใช้ข้อมูลแผนภูมิเดียวกันและการตั้งค่าคีย์คำอธิบายในทุกกรณีสี่กรณี. เริ่มจากเปิดใช้งานเส้นขอบทั้งหมด, แต่ละรูปแบบที่เหลือจะปิดการตั้งค่าเส้นขอบเพียงหนึ่งอย่าง. รูปแบบด้านล่างซ้ายตรงกับการตั้งค่าเส้นขอบในตัวอย่าง.

![ตารางข้อมูลแผนภูมิที่เปิดใช้งานเส้นขอบทั้งหมด, ไม่มีเส้นขอบแนวนอน, ไม่มีเส้นขอบแนวตั้ง, และไม่มีเส้นขอบภายนอก](data-table-borders.png)

## **แสดงหรือซ่อนคีย์คำอธิบาย**

คีย์คำอธิบายคือเครื่องหมายสีเล็ก ๆ ที่อยู่ข้างชื่อซีรีส์ในตารางข้อมูล. พวกมันช่วยให้ผู้อ่านจับคู่แถวของตารางกับซีรีส์ของแผนภูมิ. ส่งค่า `True` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/python-java/aspose.slides/datatable/#setShowLegendKey) เพื่อแสดงเครื่องหมายเหล่านี้หรือ `False` เพื่อซ่อน.

คำอธิบายแยกของแผนภูมิก็ถูกควบคุมโดย [Chart.setLegend](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setLegend). การตั้งค่าเหล่านี้เป็นอิสระต่อกัน: การซ่อนคำอธิบายแยกจะไม่ทำให้คีย์ภายในตารางข้อมูลหายไป, และการซ่อนคีย์ของตารางจะไม่ทำให้คำอธิบายแยกหายไป.

ตัวอย่างต่อไปนี้สร้างแผนภูมิด้วยข้อมูลเริ่มต้น, เปิดใช้งานตารางข้อมูลของมัน, และแสดงคีย์คำอธิบายภายในขณะที่ซ่อนคำอธิบายแยก. เส้นขอบของตารางทั้งหมดถูกเปิดใช้งานอย่างชัดเจน. ไม่ต้องใช้การนำเสนอเป็นอินพุต. เพื่อซ่อนคีย์ของตารางเท่านั้น, ส่งค่า `False` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเปรียบเทียบด้านล่างแสดงตารางเดียวกันที่เปิดและปิดคีย์คำอธิบาย. เส้นขอบทั้งหมดยังคงเปิดใช้งาน, และคำอธิบายแยกของแผนภูมิถูกซ่อนในทั้งสองกรณี.

![ตารางข้อมูลแผนภูมิที่แสดงคีย์คำอธิบายทางซ้ายและซ่อนทางขวา](data-table-legend-keys.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ได้. ส่งค่า `True` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/python-java/aspose.slides/datatable/#setShowLegendKey) เพื่อแสดงคีย์คำอธิบายหรือ `False` เพื่อซ่อน.

**ตารางข้อมูลจะถูกเก็บไว้เมื่อส่งออกการนำเสนอเป็น PDF, HTML หรือภาพหรือไม่?**

ได้. Aspose.Slides จะทำการเรนเดอร์แผนภูมิและตารางข้อมูลที่แสดงเป็นส่วนหนึ่งของสไลด์เมื่อส่งออกเป็น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/th/python-java/convert-powerpoint-to-html/), หรือ [images](/slides/th/python-java/convert-powerpoint-to-png/).

**ฉันสามารถทำงานกับตารางข้อมูลในแผนภูมิที่โหลดจากเทมเพลตได้หรือไม่?**

ได้. สำหรับแผนภูมิที่โหลดจากการนำเสนอหรือเทมเพลตที่มีอยู่, ใช้ [hasDataTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#hasDataTable) และ [setDataTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setDataTable) เพื่อตรวจสอบหรือเปลี่ยนแปลงว่าตารางข้อมูลของมันถูกแสดงหรือไม่.

**ฉันจะค้นหาแผนภูมิที่เปิดใช้งานตารางข้อมูลได้อย่างไร?**

วนลูปผ่านรูปทรงทั้งหมดบนแต่ละสไลด์, ระบุแผนภูมิ, แล้วเรียกเมธอด [hasDataTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#hasDataTable) ของพวกมัน. ค่าที่เป็น `True` หมายถึงตารางข้อมูลถูกเปิดใช้งาน.