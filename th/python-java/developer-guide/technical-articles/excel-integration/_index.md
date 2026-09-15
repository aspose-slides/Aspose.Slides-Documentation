---
title: รวมข้อมูล Excel เข้ากับการนำเสนอ PowerPoint
linktitle: การบูรณาการ Excel
type: docs
weight: 330
url: /th/python-java/excel-integration/
keywords:
- Excel
- สมุดงาน
- อ่าน Excel
- รวม Excel
- แหล่งข้อมูล
- เมลเมิร์จ
- นำเข้าตาราง
- Excel ไปยัง PowerPoint
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "อ่านข้อมูลจากสมุดงาน Excel ใน Aspose.Slides สำหรับ Python ผ่าน Java โดยใช้ API ExcelDataWorkbook โหลดแผ่นงานและเซลล์และใช้ค่าเพื่อสร้างการนำเสนอ PowerPoint ที่ขับเคลื่อนด้วยข้อมูล."
---
## **บทนำ**

การนำเสนอ PowerPoint เป็นวิธีที่ทรงพลังในการแสดงและสื่อสารข้อมูล มักใช้ร่วมกับ workbook ของ Excel ที่ Excel ทำหน้าที่เป็นแหล่งข้อมูลโครงสร้างที่ยอดเยี่ยม และ PowerPoint จะทำหน้าที่แสดงภาพข้อมูลนั้นให้ผู้ชมเห็น

มีหลายสถานการณ์ที่การรวม Excel กับ PowerPoint เป็นสิ่งจำเป็น: การทำเมลเมิร์จ, การเติมข้อมูลในตาราง, การสร้างสไลด์หนึ่งต่อหนึ่งระเบียนข้อมูล (การสร้างสไลด์แบบชุด), การสร้างเอกสารฝึกอบรม, และการรวมรายงาน Excel หลายฉบับเป็นงานนำเสนอเดียว เป็นต้น

จนถึงตอนนี้ การใช้คุณลักษณะเหล่านี้กับ Aspose.Slides API ต้องอาศัยโซลูชันของบุคคลที่สามอย่าง Aspose.Cells แม้เครื่องมือเหล่านี้จะแข็งแรง แต่ก็อาจซับซ้อนและมีค่าใช้จ่ายสูงสำหรับผู้ใช้ที่ต้องการเพียงการบูรณาการข้อมูลพื้นฐานเท่านั้น

## **วิธีการทำงาน**

เพื่อทำให้การทำงานกับข้อมูล Excel ง่ายและราบรื่นยิ่งขึ้น Aspose.Slides ได้แนะนำคลาสใหม่สำหรับการอ่านข้อมูลจาก workbook ของ Excel และนำเข้าข้อมูลเข้าสู่การนำเสนอ ความสามารถนี้เปิดโอกาสใหม่ที่ทรงพลังสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลภายในเวิร์กฟลว์การนำเสนอของตน

ฟังก์ชันใหม่ออกแบบมาสำหรับการเข้าถึงข้อมูลทั่วไปและไม่ได้รวมไว้ใน Presentation Document Object Model (DOM) ซึ่งหมายความว่า *มันไม่สามารถแก้ไขหรือบันทึกไฟล์ Excel* — วัตถุประสงค์เดียวของมันคือการเปิด workbook และนำทางผ่านเนื้อหาเพื่อดึงข้อมูลเซลล์ออกมา

แกนหลักของฟีเจอร์นี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/exceldataworkbook/) คลาสนี้ให้คุณโหลด workbook ของ Excel จากไฟล์ในเครื่องหรือจากสตรีม เมื่อโหลดเสร็จแล้วจะมีเมธอด overload หลายรูปแบบของ [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/exceldataworkbook/#getCell) ให้คุณดึงเซลล์เฉพาะตามตำแหน่ง (เช่น ดัชนีแถวและคอลัมน์ หรือช่วงที่ตั้งชื่อ)

แต่ละครั้งที่เรียก [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/exceldataworkbook/#getCell) จะคืนค่าเป็นวัตถุ [ExcelDataCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/exceldatacell/) วัตถุนี้แทนเซลล์เดียวใน workbook ของ Excel และทำให้คุณเข้าถึงค่าของเซลล์ได้อย่างง่ายดายและเป็นธรรมชาติ

#### **นำเข้าแผนภูมิ Excel**

ขั้นตอนต่อไปเพื่อขยายความสามารถคือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/python-java/aspose.slides/excelworkbookimporter/) คลาสยูทิลิตี้นี้ให้ฟังก์ชันการนำเข้าข้อมูลจาก workbook ของ Excel เข้าสู่การนำเสนอ มี overload หลายรูปแบบของเมธอด [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) ที่ช่วยให้คุณดึงแผนภูมิที่เลือกจาก workbook ของ Excel ที่ระบุและเพิ่มลงใน collection ของ shape ที่กำหนด ณ พิกัดที่ระบุ

#### **นำเข้าตาราง Excel**

คลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/python-java/aspose.slides/excelworkbookimporter/) ยังมี overload หลายรูปแบบของเมธอด [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) ซึ่งอนุญาตให้คุณนำเข้าช่วงเซลล์ที่ระบุจาก worksheet ที่ระบุและเพิ่มเป็นตารางลงใน collection ของ shape ที่กำหนด ณ พิกัดที่ระบุ

สรุปคือเป็น API ที่เบาและตรงไปตรงมาสำหรับการอ่านข้อมูล Excel — สิ่งที่นักพัฒนาหลายคนต้องการโดยไม่ต้องเพิ่มภาระของไลบรารีการประมวลผลสเปรดชีตเต็มรูปแบบ

## **มาเขียนโค้ดกัน**

### **ตัวอย่างสถานการณ์เมลเมิร์จ**

ในตัวอย่างต่อไปนี้ เราจะทำการจำลองสถานการณ์เมลเมิร์จอย่างง่ายโดยสร้างการนำเสนอหลายชุดตามข้อมูลที่จัดเก็บใน workbook ของ Excel

เพื่อเริ่มต้น เราต้องการสองสิ่ง:

1. workbook ของ Excel ที่มีข้อมูล

![ตัวอย่างข้อมูล Excel](example1_image0.png)

2. เทมเพลตการนำเสนอ PowerPoint

![ตัวอย่างเทมเพลต PowerPoint](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# โหลด workbook ของ Excel ที่มีข้อมูลพนักงาน.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# โหลดเทมเพลตการนำเสนอ.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # วนลูปผ่านแถวของ Excel (ยกเว้นหัวข้อที่แถว 0).
    for row_index in range(1, 5):

        # สร้างการนำเสนอสำหรับแต่ละระเบียนพนักงาน.
        employee_presentation = Presentation()

        try:
            # ลบสไลด์เปล่าดีฟอลต์.
            employee_presentation.getSlides().removeAt(0)

            # คัดลอกสไลด์เทมเพลตเข้าสู่การนำเสนอ.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # ดึงย่อหน้าจาก shape เป้าหมาย (สมมติว่าใช้ shape ที่ดัชนี 1).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # แทนที่ตำแหน่งตัวแปรด้วยข้อมูลจาก Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # บันทึกการนำเสนอแบบเฉพาะบุคคลลงไฟล์แยก.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![ผลลัพธ์](example1_image2.png)

### **ตัวอย่างตาราง Excel**

ในตัวอย่างที่สอง เราจะคัดลอกข้อมูลจากตาราง Excel แล้วแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูสวยงามยิ่งขึ้น

ในตัวอย่างนี้ เราใช้ workbook ของ Excel เดียวกันจากตัวอย่างแรก ซึ่งมีตารางพนักงานอย่างง่าย

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# โหลด workbook ของ Excel ที่มีข้อมูลพนักงาน.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# สร้างการนำเสนอ PowerPoint.
presentation = Presentation()

try:
    # เพิ่ม shape ตารางลงในสไลด์แรก.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # เติมตาราง PowerPoint ด้วยข้อมูลจาก workbook ของ Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # บันทึกการนำเสนอที่ได้ลงไฟล์.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![ผลลัพธ์](example2_image0.png)

### **ตัวอย่างการนำเข้าแผนภูมิ Excel**

ในตัวอย่างนี้ เราจะนำเข้าแผนภูมิจาก worksheet แรกของ workbook Excel ที่ใช้ในตัวอย่างก่อนหน้า แผนภูมิจะถูกลิงก์ไปยัง workbook ภายนอกในงานนำเสนอที่ได้

ก่อนอื่น เราเพิ่มแผนภูมิพายลงใน workbook ของ Excel ตามตารางพนักงาน

![ตัวอย่างแผนภูมิ Excel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# สร้างการนำเสนอ PowerPoint.
presentation = Presentation()
try:
    # ดึงคอลเลกชัน shapes ของสไลด์แรก.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # นำเข้าชาร์ตชื่อ "Chart 1" จากแผ่นแรกของ workbook และเพิ่มลงในคอลเลกชัน shapes.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # บันทึกการนำเสนอที่ได้ลงไฟล์.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![ผลลัพธ์](example3_image1.png)

### **ตัวอย่างการนำเข้าแผนภูมิ Excel ทั้งหมด**

ลองจินตนาการว่าคุณมี workbook ของ Excel ที่เต็มไปด้วยแผนภูมิและต้องการนำเข้าทั้งหมดเข้าสู่การนำเสนอ แต่ละแผนภูมิควรวางบนสไลด์ใหม่

โค้ดต่อไปนี้จะวนลูปผ่านทุก worksheet ในไฟล์ Excel ต้นฉบับ ดึงแผนภูมิจากแต่ละ worksheet และเพิ่มแต่ละแผนภูมิลงในสไลด์แยกโดยใช้เลเอาต์สไลด์เปล่า ในงานนำเสนอที่ได้ จะฝังเฉพาะข้อมูลแผนภูมิ ไม่ได้ฝัง workbook ทั้งหมด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# โหลด workbook ของ Excel ที่มีข้อมูลพนักงาน.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# สร้างการนำเสนอ PowerPoint.
presentation = Presentation()
try:
    # ดึงเลเอาต์สไลด์เปล่า.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # ลบสไลด์ดีฟอลต์เพื่อให้ผลลัพธ์มีสไลด์หนึ่งต่อหนึ่งแผนภูมิ.
    presentation.getSlides().removeAt(0)

    # ดึงชื่อของทุก worksheet ที่อยู่ใน workbook ของ Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # ดึงแผนที่ที่แมพดัชนีแผนภูมิไปยังชื่อแผนภูมิสำหรับ worksheet นั้น.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # เพิ่มสไลด์โดยใช้เลเอาต์เปล่า.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # นำเข้าชาร์ตที่ระบุจาก workbook ของ Excel เข้าสู่คอลเลกชัน shapes ของสไลด์.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # บันทึกการนำเสนอที่ได้ลงไฟล์.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ตัวอย่างการนำเข้าตาราง Excel**

ในตัวอย่างนี้ เรานำเข้าตารางที่จัดรูปแบบจาก worksheet ของ Excel โดยตรงเข้าสู่การนำเสนอ PowerPoint

worksheet ของ Excel ต้นฉบับมีตารางที่จัดรูปแบบพร้อมข้อมูลพนักงาน:

![ตัวอย่างตาราง Excel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# สร้างการนำเสนอ PowerPoint.
presentation = Presentation()
try:
    # ดึงสไลด์แรกและคอลเลกชัน shapes ของมัน.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # นำเข้าตารางจากแผ่นแรกของ workbook และเพิ่มลงในคอลเลกชัน shapes.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # บันทึกการนำเสนอที่ได้ลงไฟล์.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![ผลลัพธ์](example4_image1.png)

## **สรุป**

กลไกนี้ซึ่งมีให้โดยตรงใน Aspose.Slides เชื่อมการทำงานกับข้อมูล Excel และการนำเสนอไว้ในที่เดียว มันช่วยให้คุณสร้างสไลด์ที่มีแผนภูมิดูเป็นภาพและข้อมูลที่แสดงเป็นตาราง Excel — โดยไม่ต้องใช้ไลบรารีเพิ่มเติมหรือการผสานรวมที่ซับซ้อน