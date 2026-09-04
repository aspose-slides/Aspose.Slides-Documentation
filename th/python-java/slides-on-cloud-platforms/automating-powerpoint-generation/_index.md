---
title: "การทำงานอัตโนมัติการสร้าง PowerPoint ด้วย Python: สร้างการนำเสนอแบบไดนามิกได้อย่างง่ายดาย"
linktitle: การทำงานอัตโนมัติการสร้าง PowerPoint
type: docs
weight: 20
url: /th/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- แพลตฟอร์มคลาวด์
- การผสานรวมคลาวด์
- อัตโนมัติการสร้าง PowerPoint
- สร้างการนำเสนอโดยโปรแกรม
- การทำงานอัตโนมัติของ PowerPoint
- การสร้างสไลด์แบบไดนามิก
- รายงานธุรกิจอัตโนมัติ
- การทำงานอัตโนมัติของ PPT
- การนำเสนอ Python
- Python
- Aspose.Slides
description: "ทำงานอัตโนมัติการสร้าง PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java: สร้างการนำเสนอธุรกิจด้วยแผนภูมิ ตาราง และหัวข้อย่อยในแอปพลิเคชันคลาวด์."
---
## **บทนำ**

การสร้างงานนำเสนอด้วยตนเองกลายเป็นเรื่องซ้ำซากเมื่อเนื้อหามีการเปลี่ยนแปลงบ่อย รายงานประจำสัปดาห์, เอกสารฝึกอบรม, และการนำเสนอต่อลูกค้ามักมีโครงสร้างร่วมกัน แต่ต้องการข้อมูลใหม่สำหรับแต่ละการส่ง

Aspose.Slides for Python via Java ให้คุณสร้างงานนำเสนอเหล่านี้จากแอปพลิเคชัน Python คุณสามารถบูรณาการการสร้างสไลด์เข้าไปในพอร์ทัลเว็บ, งานที่กำหนดเวลา, และ worker บนคลาวด์โดยใช้ข้อมูลจากฐานข้อมูล, API หรือไฟล์ที่อัปโหลด

## **กรณีการใช้งานทั่วไปสำหรับการทำงานอัตโนมัติของ PowerPoint ด้วย Python**

- **รายงานธุรกิจและแดชบอร์ด:** แปลงตัวเลขการขายและตัวชี้วัดประสิทธิภาพเป็นแผนภูมิและตาราง.
- **การนำเสนอการขายแบบปรับให้เป็นส่วนบุคคล:** เติมข้อมูลสไลด์ด้วยข้อมูลเฉพาะลูกค้าในขณะที่รักษาการออกแบบที่สม่ำเสมอ.
- **เนื้อหาการศึกษา:** รวบรวมบทเรียน, แบบทดสอบ, และสรุปหลักสูตรจากวัสดุที่มีโครงสร้าง.
- **ข้อมูลเชิงลึกจาก Data และ AI:** ใช้ผลลัพธ์จากการวิเคราะห์หรือบริการประมวลผลภาษาที่เป็นเนื้อหาในการนำเสนอ.
- **สไลด์ที่ใช้สื่อ:** ผสานรูปภาพหรือภาพหน้าจอที่อัปโหลดกับข้อความอธิบาย.
- **กระบวนการทำงานเอกสาร:** แปลงเนื้อหาที่สกัดจากเครื่องมืออื่นเป็นเลย์เอาต์ของงานนำเสนอ.
- **เครื่องมือสำหรับนักพัฒนา:** สร้างสรุปการปล่อย, ภาพรวมทางเทคนิค, หรือการสาธิตจากข้อมูลโครงการ.

## **ข้อกำหนดเบื้องต้น**

ทำตาม [Installation](/slides/th/python-java/installation/) เพื่อติดตั้ง Python, Java, JPype, และ Aspose.Slides สำหรับการปรับใช้บนคลาวด์ ให้ตรวจสอบเพิ่มเติมที่ [Slides on Cloud Platforms](/slides/th/python-java/slides-on-cloud-platforms/).

ตัวอย่างนี้ใช้ข้อมูลธุรกิจแบบคงที่เพื่อให้สามารถทำงานได้โดยไม่มีฐานข้อมูลหรือบริการภายนอก ให้เปลี่ยนค่าต่าง ๆ ด้วยข้อมูลจากแอปพลิเคชันของคุณเมื่อบูรณาการเข้าสู่กระบวนการทำรายงาน

{{% alert color="info" title="Note" %}}
คุณสามารถลองตัวอย่างโดยไม่ใช้ลิขสิทธิ์ได้ แต่ผลลัพธ์การประเมินจะมีลายน้ำและอยู่ภายใต้ข้อจำกัดการประเมิน ดูรายละเอียดและข้อมูลลิขสิทธิ์ชั่วคราวได้ที่ [Evaluate Aspose.Slides](/slides/th/python-java/evaluate-aspose-slides/).
{{% /alert %}}

## **สร้างงานนำเสนอ**

สคริปต์เต็มด้านล่างนี้จะสร้างงานนำเสนอหนึ่งไฟล์ที่มีสี่สไลด์ แต่ละขั้นตอนใช้การนำเสนอเดียวกันและขั้นตอนสุดท้ายบันทึกเป็น `presentation.pptx`.

### **สร้างสไลด์หัวเรื่อง**

ใช้สไลด์แรกของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใหม่และใช้เค้าโครงหัวเรื่อง เติมตัวจับจองหัวเรื่องและหัวเรื่องย่อยด้วยหัวข้อรายงานและผู้ฟัง.

![สไลด์หัวเรื่อง](slide_0.png)

### **เพิ่มสไลด์พร้อมแผนภูมิคอลัมน์**

เพิ่มสไลด์เปล่าและสร้างแผนภูมิด้วย [ShapeCollection.addChart](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addChart). เติมเวิร์กบุ๊กที่ฝังไว้ด้วยห้าเขตและชุดข้อมูลการขายหนึ่งชุด ค่าต่าง ๆ จะยังคงแก้ไขได้ใน PowerPoint.

![สไลด์พร้อมแผนภูมิ](slide_1.png)

### **เพิ่มสไลด์พร้อมตาราง**

สร้างตารางด้วย [ShapeCollection.addTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addTable) และเติมสองคอลัมน์ด้วยชื่อเมตริกและค่า ตัวอย่างนี้ส่งอาร์เรย์ Java ของ double สำหรับความกว้างของคอลัมน์และความสูงของแถวผ่าน JPype อย่างชัดเจน.

![สไลด์พร้อมตาราง](slide_2.png)

### **เพิ่มสไลด์สรุปพร้อมหัวข้อย่อย**

สร้างรูปทรงข้อความและเพิ่ม [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) สำหรับแต่ละรายการการกระทำ ใช้สัญลักษณ์หัวข้อย่อยและข้อความสีดำสำหรับแต่ละย่อหน้าและลบการเติมสีและเค้าโครงของรูปทรง.

![สไลด์สรุป](slide_3.png)

### **บันทึกงานนำเสนอ**

ใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อเขียนไฟล์ PowerPoint ปล่อยการนำเสนอด้วย [Presentation.dispose](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#dispose) ในบล็อก `finally`.

### **ตัวอย่าง Python ฉบับเต็ม**

บันทึกสคริปต์นี้ในไดเรกทอรีที่เขียนได้และรันด้วยสภาพแวดล้อม Python ที่กำหนดไว้ข้างต้น มันจะเริ่ม JVM เฉพาะเมื่อจำเป็นและคงให้ใช้งานจนกระทั่งกระบวนการสิ้นสุด สำหรับการใช้ในโน๊ตบุ๊กและบริการ ดูที่ [JVM lifecycle guidance](/slides/th/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # สร้างสไลด์หัวเรื่อง.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # เพิ่มสไลด์แผนภูมิ.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # เพิ่มสไลด์ตาราง.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # เพิ่มสไลด์สรุป.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ภาพประกอบแสดงสไลด์ที่สอดคล้องจากตัวอย่าง Java รูปลักษณ์อาจแตกต่างกันขึ้นกับฟอนต์ที่ติดตั้งและโหมดการประเมิน.

## **ใช้ตัวอย่างในแอปพลิเคชันคลาวด์**

ดึงข้อมูลรายงานก่อนสร้างงานนำเสนอแล้วส่งต่อให้ขั้นตอนการสร้างแผนภูมิ ตาราง และข้อความ ใช้เส้นทางออกแยกสำหรับแต่ละงาน หลังจากบันทึก แอปพลิเคชันของคุณสามารถอัปโหลดไฟล์ไปยังที่เก็บวัตถุหรือส่งกลับเป็นการดาวน์โหลด

คง JVM ทำงานต่อเนื่องระหว่างงานภายในโพรเซส worker เดียวกันและปล่อยงานนำเสนอแต่ละอันเมื่องานเสร็จ ปิดแพ็กฟอนต์ที่รายงานของคุณต้องการพร้อมกับการปรับใช้เพื่อลดความแตกต่างระหว่างสภาพแวดล้อม.

## **สรุป**

ตัวอย่างนี้สร้างงานนำเสนอธุรกิจเต็มรูปแบบจาก Python โดยใช้แผนภูมิ, ตาราง, และข้อความที่สามารถแก้ไขได้ การเปลี่ยนข้อมูลตัวอย่างเป็นข้อมูลจากแอปพลิเคชันทำให้วิธีเดียวกันนี้มีประโยชน์สำหรับรายงานประจำ, การนำเสนอลูกค้า, และวัสดุการศึกษา.

## **คำถามที่พบบ่อย**

**สคริปต์ต้องการ Microsoft PowerPoint หรือ Excel หรือไม่?**

ไม่ Aspose.Slides สร้างสไลด์และเวิร์กบุ๊กที่ฝังในแผนภูมิโดยไม่ต้องใช้แอปพลิเคชันเหล่านั้น

**ทำไมตัวอย่างตารางถึงใช้ Java arrays?**

เมธอดพื้นฐานรับอาร์เรย์ของ Java doubles อาร์เรย์ที่ระบุอย่างชัดเจนทำให้ประเภทตัวเลขที่ส่งผ่าน JPype ชัดเจน

**สามารถบันทึกงานนำเสนอเดียวกันเป็น PDF หรือ ODP ได้หรือไม่?**

ได้ ก่อนทำการ dispose ให้บันทึกเป็นชื่อไฟล์ผลลัพธ์อื่นโดยใช้ค่า [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/) ที่สอดคล้อง ดู [Supported File Formats](/slides/th/python-java/supported-file-formats/) เพื่อดูความสามารถตามฟอร์แมต

**สามารถใช้เทมเพลตที่มีแบรนด์ได้หรือไม่?**

ได้ โหลดเทมเพลตของคุณแทนการสร้างงานนำเสนอเปล่าแล้วปรับเลย์เอาต์และการเลือก placeholder ให้ตรงกับเทมเพลต ตัวอย่างสมมติว่าเลย์เอาต์และลำดับของ placeholder เป็นของงานนำเสนอเริ่มต้นแบบเริ่มต้น.