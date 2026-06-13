---
title: บูรณาการข้อมูล Excel ไปยังการนำเสนอ PowerPoint
linktitle: การบูรณาการ Excel
type: docs
weight: 330
url: /th/python-net/excel-integration/
keywords:
- Excel
- สมุดงาน
- อ่าน Excel
- บูรณาการ Excel
- แหล่งข้อมูล
- เมลเมิร์จ
- นำเข้าตาราง
- Excel ไปยัง PowerPoint
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "อ่านข้อมูลจากสมุดงาน Excel ใน Aspose.Slides โดยใช้ API ExcelDataWorkbook โหลดแผ่นงานและเซลล์และใช้ค่าต่าง ๆ เพื่อสร้างการนำเสนอ PowerPoint ที่ขับเคลื่อนด้วยข้อมูล"
---
## **บทนำ**

การนำเสนอ PowerPoint เป็นวิธีที่ทรงพลังในการแสดงและสื่อสารข้อมูล พวกมันมักใช้ร่วมกับสมุดงาน Excel ซึ่ง Excel ทำหน้าที่เป็นแหล่งข้อมูลโครงสร้างที่ยอดเยี่ยมและ PowerPoint มีความเก่งในการสร้างภาพข้อมูลนั้นสำหรับผู้ชม

มีหลายสถานการณ์การใช้งานที่การรวม Excel กับ PowerPoint เป็นสิ่งจำเป็น: การทำเมลเมิร์จ, การเติมข้อมูลในตาราง, การสร้างสไลด์หนึ่งต่อหนึ่งบันทึกข้อมูล (การสร้างสไลด์เป็นชุด), การสร้างสื่อการฝึกอบรม, และการรวมรายงาน Excel หลายฉบับเป็นงานนำเสนอเดียว, เป็นต้น

จนถึงตอนนี้ การดำเนินคุณลักษณะเหล่านี้ด้วย Aspose.Slides API จำเป็นต้องพึ่งพาโซลูชันของบุคคลที่สามเช่น Aspose.Cells แม้ว่าเครื่องมือเหล่านี้จะแข็งแรง แต่ก็อาจซับซ้อนเกินไปและมีค่าใช้จ่ายสูงสำหรับผู้ใช้ที่ต้องการเพียงฟังก์ชันการรวมข้อมูลพื้นฐานเท่านั้น

## **วิธีทำงาน**

เพื่อทำให้การทำงานกับข้อมูล Excel ง่ายขึ้นและเป็นกระบวนการที่ราบรื่นยิ่งขึ้น Aspose.Slides ได้แนะนำคลาสใหม่สำหรับการอ่านข้อมูลจากสมุดงาน Excel และการนำเข้าข้อมูลลงในงานนำเสนอ คุณสมบัตินี้เปิดโอกาสใหม่ที่ทรงพลังสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลในเวิร์กโฟลว์การนำเสนอของตน

ฟังก์ชันใหม่ได้รับการออกแบบเพื่อการเข้าถึงข้อมูลทั่วไปและไม่ได้ถูกรวมเข้ากับ Presentation Document Object Model (DOM) นั่นหมายความว่า *มันไม่อนุญาตให้แก้ไขหรือบันทึกไฟล์ Excel* — จุดประสงค์เพียงอย่างเดียวคือการเปิดสมุดงานและนำทางผ่านเนื้อหาของมันเพื่อดึงข้อมูลเซลล์

ที่แกนกลางของคุณสมบัตินี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.excel/exceldataworkbook/) คลาสนี้ทำให้คุณโหลดสมุดงาน Excel จากไฟล์ในเครื่องหรือสตรีม เมื่อโหลดแล้วจะให้เมธอด [get_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) ที่มีหลายรูปแบบให้เลือกใช้เพื่อดึงเซลล์เฉพาะตามตำแหน่ง (เช่น ดัชนีแถวและคอลัมน์หรือช่วงที่ตั้งชื่อ)

การเรียกใช้แต่ละครั้งของ [get_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) จะคืนค่าเป็นอินสแตนซ์ของคลาส [ExcelDataCell](https://reference.aspose.com/slides/th/python-net/aspose.slides.excel/exceldatacell/) วัตถุนี้แทนเซลล์เดียวในสมุดงาน Excel และให้คุณเข้าถึงค่าของมันในรูปแบบที่ง่ายและเป็นธรรมชาติมากขึ้น

#### **นำเข้ากราฟจาก Excel**

ขั้นตอนต่อไปเพื่อขยายฟังก์ชันคือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/python-net/aspose.slides.importing/excelworkbookimporter/) คลาสยูทิลิตี้นี้ให้ฟังก์ชันสำหรับการนำเข้าข้อมูลจากสมุดงาน Excel ลงในงานนำเสนอ มันมีเมธอด [add_chart_from_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) หลายรูปแบบที่ช่วยให้คุณดึงกราฟที่เลือกจากสมุดงาน Excel ที่ระบุและเพิ่มลงในตำแหน่งสุดท้ายของคอลเลกชันรูปร่างที่กำหนดตามพิกัดที่ระบุ

สรุปแล้ว มันเป็น API ที่เบาและตรงไปตรงมาสำหรับการอ่านข้อมูล Excel — สิ่งที่นักพัฒนาหลายคนต้องการโดยไม่ต้องพึ่งพาห้องสมุดการประมวลผลสเปรดชีตแบบเต็มรูปแบบ

## **มาเขียนโค้ดกัน**

### **ตัวอย่างสถานการณ์เมลเมิร์จ**

ในตัวอย่างต่อไปนี้ เราจะทำตามสถานการณ์เมลเมิร์จแบบง่ายโดยสร้างงานนำเสนอหลายไฟล์จากข้อมูลที่เก็บในสมุดงาน Excel

เพื่อเริ่มต้น เราต้องการสองสิ่ง:
1. สมุดงาน Excel ที่มีข้อมูล

![ตัวอย่างข้อมูล Excel](example1_image0.png)

2. เทมเพลตงานนำเสนอ PowerPoint

![ตัวอย่างเทมเพลต PowerPoint](example1_image1.png)

```py
import aspose.slides as slides

# โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# โหลดเทมเพลตการนำเสนอ.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # วนลูปผ่านแถวของ Excel (ยกเว้นหัวข้อที่แถวที่ 0).
    for row_index in range(1, 5):

        # สร้างการนำเสนอใหม่สำหรับแต่ละบันทึกพนักงาน.
        with slides.Presentation() as employee_presentation:

            # ลบสไลด์เปล่าเริ่มต้นออก.
            employee_presentation.slides.remove_at(0)

            # คัดลอกสไลด์เทมเพลตไปยังการนำเสนอใหม่.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # ดึงย่อหน้าจากรูปร่างเป้าหมาย (สมมติว่าใช้รูปดัชนี 1).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # แทนที่ตำแหน่งตัวแปรด้วยข้อมูลจาก Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # บันทึกการนำเสนอที่ปรับแต่งแล้วเป็นไฟล์แยก.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![ผลลัพธ์](example1_image2.png)

### **ตัวอย่างตาราง Excel**

ในตัวอย่างที่สอง เราเพียงคัดลอกข้อมูลจากตาราง Excel และแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูสวยงามยิ่งขึ้น

ในตัวอย่างนี้ เราใช้สมุดงาน Excel เดียวกันจากตัวอย่างแรก ซึ่งมีตารางพนักงานแบบง่าย

```py
# โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# สร้างการนำเสนอ PowerPoint ใหม่.
with slides.Presentation() as presentation:

    # เพิ่มรูปร่างตารางไปยังสไลด์แรก.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # เติมตาราง PowerPoint ด้วยข้อมูลจากสมุดงาน Excel.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # บันทึกการนำเสนอที่ได้เป็นไฟล์.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![ผลลัพธ์](example2_image0.png)

### **ตัวอย่างการนำเข้ากราฟจาก Excel**

ในตัวอย่างนี้ เรานำเข้ากราฟจากแผ่นงานแรกของสมุดงาน Excel ที่ใช้ในตัวอย่างก่อนหน้า กราฟจะลิงก์ไปยังสมุดงานภายนอกในงานนำเสนอที่ได้ผลลัพธ์

แรกเราจะเพิ่มกราฟวงกลมลงในสมุดงาน Excel โดยอิงจากตารางพนักงาน

![ตัวอย่างกราฟ Excel](example3_image0.png)

```py
# สร้างการนำเสนอ PowerPoint ใหม่.
with slides.Presentation() as presentation:
    # ดึงคอลเลกชันรูปร่างของสไลด์แรก.
    shapes = presentation.slides[0].shapes

    # นำเข้ากราฟที่มีชื่อ "Chart 1" จากแผ่นแรกของสมุดงานและเพิ่มไปยังคอลเลกชันรูปร่าง.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # บันทึกการนำเสนอที่ได้เป็นไฟล์.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![ผลลัพธ์](example3_image1.png)

### **ตัวอย่างการนำเข้ากราฟ Excel ทั้งหมด**

ลองนึกว่าคุณมีสมุดงาน Excel เต็มไปด้วยกราฟและต้องการนำเข้าทั้งหมดเข้าสู่งานนำเสนอ แต่ละกราฟควรวางบนสไลด์ใหม่

โค้ดต่อไปนี้จะวนลูปผ่านแผ่นงานทั้งหมดในไฟล์ Excel ต้นทาง ดึงกราฟจากแต่ละแผ่นงาน และเพิ่มกราฟแต่ละอันลงบนสไลด์แยกกันโดยใช้เคาน์เท้นท์สไลด์เปล่า ในงานนำเสนอที่ได้ผลลัพธ์ จะฝังเฉพาะข้อมูลกราฟ ไม่ได้ฝังสมุดงานทั้งหมด

```py
# โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# สร้างการนำเสนอ PowerPoint ใหม่.
with slides.Presentation() as presentation:
    # ดึงรูปแบบสไลด์เปล่า.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # รับชื่อของแผ่นงานทั้งหมดที่อยู่ในสมุดงาน Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # ดึงพจนานุกรมที่แมปดัชนีกราฟกับชื่อกราฟสำหรับแผ่นงาน.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # เพิ่มสไลด์ใหม่โดยใช้รูปแบบสไลด์เปล่า.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # นำเข้ากราฟที่ระบุจากสมุดงาน Excel ไปยังคอลเลกชันรูปร่างของสไลด์.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # บันทึกการนำเสนอที่ได้เป็นไฟล์.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **สรุป**

กลไกนี้ ซึ่งมีให้ใช้โดยตรงใน Aspose.Slides ผสานการทำงานกับข้อมูล Excel และงานนำเสนอไว้ในที่เดียว มันช่วยให้คุณสร้างสไลด์ที่มีกราฟภาพและข้อมูลที่แสดงเป็นตาราง Excel ได้ — โดยไม่ต้องใช้ไลบรารีเพิ่มเติมหรือการผสานที่ซับซ้อน