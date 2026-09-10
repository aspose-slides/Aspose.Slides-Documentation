---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย Python
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ Treemap
- แผนภูมิ Sunburst
- แผนภูมิเชิงลำดับชั้น
- จุดข้อมูล
- ป้ายข้อมูล
- สีสาขา
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างข้อมูลเชิงลำดับชั้นและปรับแต่งระดับ ป้ายและสีในแผนภูมิ Treemap และ Sunburst ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Treemap และ Sunburst แสดงข้อมูลเชิงลำดับชั้นในรูปแบบเดียวกัน แต่ใช้การจัดวางที่แตกต่างกัน Treemap วาดโครงสร้างเป็นสี่เหลี่ยมซ้อนกันโดยพื้นที่ของแต่ละสี่เหลี่ยมแทนค่าของใบข้อมูล Sunburst วาดเป็นวงวงศ์ศูนย์: กลุ่มระดับบนจะอยู่ใกล้ศูนย์กลาง และหมวดหมู่ใบจะอยู่บนวงนอก

ใน Aspose.Slides for Python via Java ค่าตัวเลขแต่ละค่าจะเป็น [ChartDataPoint](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/). วิธีการ [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) ให้เข้าถึงใบข้อมูลและกลุ่มพ่อแม่ของมัน บทความนี้อธิบายการแมปเหล่านั้นและแสดงวิธีสร้างและจัดรูปแบบแผนภูมิทั้งสองประเภทจากข้อมูลตัวอย่างเดียวกัน

![แผนภูมิ Treemap ที่มีสาขา Consumer และ Business](treemap-hierarchy.png)

![แผนภูมิ Sunburst ที่มีโครงสร้างลำดับชั้น Consumer และ Business เดียวกัน](sunburst-hierarchy.png)

## **ทำความเข้าใจหมวดหมู่, จุดข้อมูล, และระดับ**

ตัวอย่างที่ใช้ด้านล่างมีระดับหมวดหมู่สามระดับและชุดตัวเลขหนึ่งชุด:

| สาขา | ส่วน | ใบ | รายได้ |
| --- | --- | --- | ---: |
| ผู้บริโภค | คอมพิวเตอร์ | แล็ปท็อป | 12 |
| ผู้บริโภค | คอมพิวเตอร์ | เดสก์ท็อป | 8 |
| ผู้บริโภค | มือถือ | โทรศัพท์ | 15 |
| ผู้บริโภค | มือถือ | แท็บเล็ต | 6 |
| ธุรกิจ | บริการ | ให้คำปรึกษา | 10 |
| ธุรกิจ | บริการ | สนับสนุน | 7 |
| ธุรกิจ | ซอฟต์แวร์ | ใบอนุญาต | 11 |
| ธุรกิจ | ซอฟต์แวร์ | การสมัครสมาชิก | 14 |

แต่ละแถวสร้างหมวดหมู่ใบหนึ่งและจุดข้อมูลหนึ่ง ระดับการจัดกลุ่มหมวดหมู่อธิบายเส้นทางจากใบนั้นไปยังพ่อแม่ของมัน สำหรับแถวแรก เส้นทางคือ `Consumer > Computers > Laptops`.

ดัชนีที่ส่งกลับโดย [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) เริ่มจากใบขึ้นไปบน:

| `getDataPointLevels()` index | ระดับตรรกะ | การแสดงผล Treemap | การแสดงผล Sunburst |
| ---: | --- | --- | --- |
| `0` | ใบ | สี่เหลี่ยมค่าที่แทน | ส่วนของวงแหวนด้านนอก |
| `1` | ส่วน | สี่เหลี่ยมพ่อแม่หรือหัวเรื่อง | ส่วนของวงแหวนกลาง |
| `2` | สาขา | สี่เหลี่ยมระดับบนหรือหัวเรื่อง | ส่วนของวงแหวนใน |

ลำดับนี้เหมือนกันสำหรับทั้งสองประเภทแผนภูมิแม้การจัดวางภาพจะแตกต่างกัน ส่วนพ่อแม่จะถูกใช้ร่วมกันโดยหลายใบ เพื่อจัดรูปแบบให้ใช้ระดับที่สอดคล้องของจุดข้อมูลแรกในกลุ่มนั้น ตัวอย่างเช่น สาขา `Consumer` เริ่มจากจุด `Laptops` ในขณะที่ส่วน `Software` เริ่มจากจุด `Licenses` การเก็บอ้างอิงถึงจุดเหล่านั้นทำให้ชัดเจนและปลอดภัยกว่าการใช้คำสั่งที่ไม่อธิบายเช่น `data_points.get_Item(0)` หรือ `data_points.get_Item(6)`.

## **สร้างและปรับแต่งแผนภูมิทั้งสองประเภท**

ตัวอย่างเต็มต่อไปนี้สร้าง Treemap บนสไลด์แรกและ Sunburst บนสไลด์ที่สอง มันสร้างโครงสร้างลำดับชั้น แสดงค่าของ `Tablets` ใช้สีคงที่กับระดับที่เลือก จัดรูปแบบป้ายสาขาและบันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # เพิ่มหมวดหมู่ใบ. รายการจัดกลุ่มจะตั้งค่าเฉพาะเมื่อกลุ่มใหม่เริ่มต้น;
        # หมวดหมู่ต่อไปนี้จะอยู่ในกลุ่มนั้นจนกว่ารายการอื่นจะถูกตั้งค่า.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # แสดงหมวดหมู่และค่าในใบ Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # จัดรูปแบบสาขา Consumer ผ่านใบแรกในสาขานั้น.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # จัดรูปแบบส่วน Software ผ่านใบแรกในส่วนนั้น.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout มีผลต่อป้ายพ่อแม่ของ Treemap; Sunburst ใช้ส่วนของวง.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เซลล์หมวดหมู่และเซลล์ค่าจะใช้แถว Worksheet เดียวกัน ทำให้ตำแหน่งของคอลเลกชันยังคงตรงกัน เมื่อทำงานกับแผนภูมิที่มีอยู่แทนการสร้างใหม่ ให้ตรวจสอบแถวหมวดหมู่ก่อนและเก็บอ้างอิงที่ตั้งชื่อไว้กับจุดข้อมูลและระดับที่ต้องการจัดรูปแบบ

## **พฤติกรรมและข้อพิจารณาปฏิบัติ**

### **ความแตกต่างระหว่าง Treemap และ Sunburst**

- Treemap ใช้พื้นที่เพื่อสื่อค่าและสี่เหลี่ยมซ้อนกันเพื่อสื่อลำดับชั้น วิธีการ [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#setParentLabelLayout) ควบคุมลักษณะการแสดงป้ายพ่อแม่ในประเภทแผนภูนินี้.
- Sunburst ใช้มุมเพื่อสื่อค่าและความลึกของวงเพื่อสื่อลำดับชั้น [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#setParentLabelLayout) ไม่ควบคุมป้ายของวงนี้.
- แผนภูมิทั้งสองประเภทใช้ระดับการจัดกลุ่มหมวดหมู่เดียวกันและลำดับใบไปพ่อแม่เดียวกันที่ส่งกลับโดย [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) ดังนั้นโค้ดการสร้างข้อมูลและการจัดรูปแบบระดับสามารถใช้ร่วมกันได้.
- ค่าของพ่อแม่คำนวณจากใบข้อมูลที่สืบทอด อย่าเพิ่มจุดตัวเลขแยกสำหรับสาขาหรือส่วน

### **การจัดเรียงและลำดับส่วน**

เครื่องมือจัดวางแผนภูมิจะกำหนดตำแหน่งสุดท้ายของสี่เหลี่ยมและส่วนของวง จัดเรียงแถวหมวดหมู่ที่เกี่ยวข้องเข้าด้วยกันก่อนเพิ่มลงไป แต่ไม่ควรพึ่งพาตำแหน่งสี่เหลี่ยมหรือมุมเริ่มต้นที่เจาะจง หากลำดับมีความหมาย ให้รวมไว้ในป้ายหรือใช้ประเภทแผนภูมิที่มีแกนหมวดหมู่ชัดเจน

### **ธีมและสีคงที่**

ระดับแผนภูมิที่ไม่ได้จัดรูปแบบจะรับสีจากธีมของงานนำเสนอ ตัวอย่างใช้การเติมสี RGB อย่างชัดเจนเพื่อให้ผลลัพธ์คาดการณ์ได้ หากต้องการให้แผนภูมิปฏิบัติตามการเปลี่ยนแปลงธีม ให้ใช้สีแบบ scheme แทนค่ารหัส RGB คงที่และหลีกเลี่ยงการเขียนทับทุกระดับ อีกทั้งตรวจสอบความคมชัดของป้ายหลังจากเปลี่ยนสีของสาขาหรือส่วน

### **ป้ายและพื้นที่ที่ใช้ได้**

PowerPoint อาจซ่อนหรือตัดป้ายเมื่อส่วนเล็กเกินไป การเพิ่มขนาดแผนภูมิ, ย่อชื่อหมวดหมู่, หรือแสดงฟิลด์ป้ายให้น้อยลงมักให้ผลลัพธ์ที่ชัดเจนขึ้น ป้ายสามารถรวมชื่อหมวดหมู่, ชื่อชุดข้อมูล, และค่าได้ผ่าน [DataLabelFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/) แต่การเปิดใช้ทุกฟิลด์มักทำให้แผนภูมิเชิงลำดับชั้นอ่านยาก

### **การส่งออกและการเรนเดอร์**

การบันทึกเป็น PPTX ทำให้แผนภูมิแก้ไขได้ เมื่อ Aspose.Slides เรนเดอร์งานนำเสนอเป็น PDF หรือภาพ การเติมสีและการตั้งค่าป้ายที่รองรับจะถูกเรนเดอร์พร้อมแผนภูมิ การแทนที่ฟอนต์และความแตกต่างเล็กน้อยในพื้นที่จัดวางที่ใช้ได้อาจทำให้การตัดบรรทัดหรือการมองเห็นป้ายเปลี่ยนไป จึงควรติดตั้งฟอนต์ที่จำเป็นและตรวจสอบเป้าหมายการส่งออกที่สำคัญ

## **คำถามที่พบบ่อย**

**ทำไมการเปลี่ยนระดับพ่อแม่จึงส่งผลต่อหลายใบ?**

สาขาหรือส่วนเป็นส่วนภาพที่ใช้ร่วมกัน สามารถเข้าถึง [ChartDataPointLevel](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapointlevel/) ผ่านใบข้อมูลที่สืบทอดได้ แต่การจัดรูปแบบเป็นของส่วนพ่อแม่ที่ใช้ร่วมกัน ไม่ได้เป็นของใบข้อมูลนั้นเท่านั้น.

**ทำไมป้ายข้อมูลหายไป?**

ขั้นแรกเปิดใช้ฟิลด์ที่ต้องการบนอ็อบเจ็กต์ [DataLabelFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/) ของป้าย แล้วตรวจสอบว่าส่วนมีพื้นที่พอหรือไม่ การจัดเลย์เอาต์ป้ายพ่อแม่ของ Treemap, ขนาดแผนภูมิ, ความยาวป้าย, ขนาดฟอนต์, และจำนวนฟิลด์ที่เปิดใช้ทั้งหมดมีผลต่อการแสดงป้ายหรือไม่.

**ฉันสามารถกำหนดลำดับหรือพิกัดที่แน่นอนของส่วนได้หรือไม่?**

คุณสามารถควบคุมลำดับของแถวแหล่งข้อมูลและทำให้แต่ละกลุ่มต่อเนื่องกันได้ แต่ไม่สามารถกำหนดสี่เหลี่ยม Treemap หรือมุม Sunburst อย่างแม่นยำได้ เครื่องมือจัดวางแผนภูมิคำนวณจากโครงสร้างลำดับชั้น, ค่า, และพื้นที่ที่มีอยู่.

**ทำไมสีจึงเปลี่ยนหลังจากธีมของงานนำเสนอเปลี่ยน?**

การเติมสีตามธีมออกแบบมาให้สอดคล้องกับจานสีของงานนำเสนอ ให้ใช้สี RGB อย่างชัดเจนกับระดับที่ต้องคงที่ หรือใช้สีแบบ scheme เมื่อการปรับให้เข้ากับธีมใหม่เป็นที่ต้องการ.

**การจัดรูปแบบที่กำหนดเองจะคงไว้ในการส่งออกเป็น PDF และภาพหรือไม่?**

ใช่ การเติมสีแผนภูมิและการตั้งค่าป้ายที่รองรับจะรวมอยู่ในการเรนเดอร์ เพื่อผลลัพธ์ที่สอดคล้องในทุกระบบ ให้เตรียมฟอนต์ที่จำเป็นและทดสอบขนาดการส่งออกขั้นสุดท้าย เนื่องจากการจัดวางป้ายขึ้นกับเลย์เอาต์.

## **ดูเพิ่มเติม**

- [สร้างแผนภูมิ Treemap](/slides/th/python-java/create-chart/#create-tree-map-charts)
- [สร้างแผนภูมิ Sunburst](/slides/th/python-java/create-chart/#create-sunburst-charts)
- [ส่งออกแผนภูมิในงานนำเสนอ](/slides/th/python-java/export-chart/)
- [จัดการธีมของงานนำเสนอ](/slides/th/python-java/presentation-theme/)