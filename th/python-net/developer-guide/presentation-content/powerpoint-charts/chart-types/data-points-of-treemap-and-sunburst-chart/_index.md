---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ใน Python
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- แผนภูมิเชิงลำดับชั้น
- จุดข้อมูล
- ป้ายข้อมูล
- สีสาขา
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างข้อมูลเชิงลำดับชั้นและปรับแต่งระดับ, ป้ายและสีในแผนภูมิ Treemap และ Sunburst ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Treemap และ Sunburst charts แสดงข้อมูลเชิงลำดับชั้นชนิดเดียวกัน แต่ใช้การจัดวางที่แตกต่างกัน Treemap วาดลำดับชั้นเป็นสี่เหลี่ยมซ้อนกันโดยขนาดแสดงค่าของใบ (leaf) ส่วน Sunburst วาดเป็นวงเส้นศูนย์กลาง: กลุ่มระดับบนอยู่ใกล้ศูนย์กลาง และหมวดหมู่ใบอยู่ที่วงนอกสุด

ใน Aspose.Slides for Python via .NET ค่าตัวเลขแต่ละค่าคือ [ChartDataPoint](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/). คอลเลกชัน [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) ให้เข้าถึงใบและกลุ่มพาเรนท์ของมัน บทความนี้อธิบายการแมปดังกล่าวและแสดงวิธีสร้างและฟอร์แมตทั้งสองประเภทแผนภูมิจากข้อมูลตัวอย่างเดียวกัน

![แผนภูมิ Treemap ที่มีสาขา Consumer และ Business](treemap-hierarchy.png)

![แผนภูมิ Sunburst ที่มีโครงสร้างเชิงลำดับ Consumer และ Business เดียวกัน](sunburst-hierarchy.png)

## **ทำความเข้าใจหมวดหมู่, จุดข้อมูล, และระดับ**

ตัวอย่างที่ใช้ด้านล่างมีระดับหมวดหมู่สามระดับและซีรีส์ตัวเลขหนึ่งชุด:

| สาขา | ส่วนหลัก | ใบ | รายได้ |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

แต่ละบรรทัดสร้างหมวดหมู่ใบหนึ่งและจุดข้อมูลหนึ่ง ระดับการจัดกลุ่มหมวดหมู่บรรยายเส้นทางจากใบนั้นไปยังพาเรนท์ของมัน สำหรับบรรทัดแรก เส้นทางคือ `Consumer > Computers > Laptops`

ดัชนีใน [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) นับจากใบขึ้นไป:

| `data_point_levels` index | ระดับตรรกะ | การแสดงผล Treemap | การแสดงผล Sunburst |
| ---: | --- | --- | --- |
| `0` | ใบ | สี่เหลี่ยมค่ | เซกเมนต์วงรอบนอก |
| `1` | ส่วนหลัก | สี่เหลี่ยมแม่หรือหัวเรื่อง | เซกเมนต์วงรอบกลาง |
| `2` | สาขา | สี่เหลี่ยมระดับบนหรือหัวเรื่อง | เซกเมนต์วงรอบใน |

ลำดับนี้เหมือนกันในทั้งสองประเภทแผนภูมิ แม้การจัดวางภาพจะต่างกัน เซกเมนต์พาเรนท์จะใช้ร่วมกันโดยหลายใบ เพื่อฟอร์แมตให้ใช้ระดับของจุดข้อมูลแรกในกลุ่มนั้น ตัวอย่างเช่น สาขา `Consumer` เริ่มด้วยจุด `Laptops` ส่วนส่วนหลัก `Software` เริ่มด้วยจุด `Licenses` การเก็บอ้างอิงจุดเหล่านี้ทำให้ชัดเจนและปลอดภัยกว่าการใช้การอ้างอิงที่อธิบายไม่ชัดเจนเช่น `data_points[0]` หรือ `data_points[6]`

## **สร้างและปรับแต่งประเภทแผนภูมิทั้งสอง**

ตัวอย่างเต็มต่อไปนี้สร้าง Treemap บนสไลด์แรกและ Sunburst บนสไลด์ที่สอง สร้างโครงสร้างลำดับชั้น แสดงค่าเพื่อ `Tablets` ใช้สีคงที่กับระดับที่เลือก ฟอร์แมตป้ายสาขา และบันทึกงานนำเสนอ

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # เพิ่มหมวดหมู่ใบ. รายการจัดกลุ่มจะตั้งค่าเฉพาะเมื่อเริ่มกลุ่มใหม่;
    # หมวดหมู่ต่อไปนี้จะคงอยู่ในกลุ่มนั้นจนกว่าจะตั้งค่ารายการใหม่.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # แสดงชื่อหมวดหมู่และค่าในใบ Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # ปรับรูปแบบสาขา Consumer ผ่านใบแรกในสาขานั้น.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # ปรับรูปแบบส่วนหลัก Software ผ่านใบแรกในส่วนหลักนั้น.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout มีผลต่อป้ายพาเรนท์ของ Treemap; Sunburst ใช้ส่วนของวง.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

เซลล์หมวดหมู่และเซลล์ค่าใช้แถวเวิร์กชีตเดียวกัน ดังนั้นตำแหน่งของคอลเลกชันจึงยังคงสอดคล้องกัน เมื่อทำงานกับแผนภูมิที่มีอยู่แล้วแทนการสร้างใหม่ ให้ตรวจสอบแถวหมวดหมู่ก่อนและเก็บอ้างอิงที่ตั้งชื่อไว้กับจุดข้อมูลและระดับที่ต้องการฟอร์แมต

## **พฤติกรรมและข้อพิจารณาเชิงปฏิบัติ**

### **ความแตกต่างระหว่าง Treemap และ Sunburst**

- Treemap ใช้พื้นที่เพื่อสื่อค่าและสี่เหลี่ยมซ้อนไปเพื่อสื่อลำดับชั้น คุณสมบัติ [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/parent_label_layout/) ควบคุมวิธีการแสดงป้ายพาเรนท์ในชนิดแผนภูมินี้
- Sunburst ใช้มุมเพื่อสื่อค่าและความลึกของวงเพื่อสื่อลำดับชั้น [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/parent_label_layout/) ไม่ควบคุมป้ายวงของมัน
- ทั้งสองประเภทแผนภูมิใช้ระดับการจัดกลุ่มหมวดหมู่เดียวกันและลำดับใบถึงพาเรนท์เดียวกันใน `data_point_levels` ดังนั้นโค้ดการสร้างข้อมูลและการฟอร์แมตระดับจึงสามารถใช้ร่วมกันได้
- ค่าพาเรนท์คำนวณจากใบที่เป็นทายาทของมัน อย่าเพิ่มจุดตัวเลขแยกสำหรับสาขาหรือส่วนหลัก

### **การเรียงลำดับและลำดับเซกเมนต์**

เครื่องยนต์จัดวางแผนภูมิกำหนดตำแหน่งสุดท้ายของสี่เหลี่ยมและเซกเมนต์วง จัดกลุ่มแถวหมวดหมู่ที่เกี่ยวข้องให้อยู่ด้วยกันก่อนเพิ่มเข้าไป แต่ไม่ควรพึ่งพาตำแหน่งสี่เหลี่ยมหรือมุมเริ่มต้นที่แน่นอน หากลำดับมีความหมาย ควรรวมไว้ในป้ายหรือใช้ประเภทแผนภูมิที่มีแกนหมวดหมู่ชัดเจน

### **ธีมและสีคงที่**

ระดับแผนภูมิที่ไม่ได้ฟอร์แมตจะรับสีจากธีมของงานนำเสนอ ตัวอย่างใช้การเติมสี RGB อย่างชัดเจนเพื่อให้ผลลัพธ์คาดการณ์ได้ หากต้องการให้แผนภูมิติดตามการเปลี่ยนแปลงธีม ควรใช้สีตามโทนสีของธีมแทนค่ากำหนด RGB และหลีกเลี่ยงการเขียนทับทุกระดับ ตรวจสอบความคมชัดของป้ายหลังจากเปลี่ยนสีสาขาหรือส่วนหลัก

### **ป้ายและพื้นที่ที่ใช้งานได้**

PowerPoint อาจซ่อนหรือตัดป้ายเมื่อเซกเมนต์มีขนาดเล็กเกินไป การเพิ่มขนาดแผนภูมิ สั้นชื่อหมวดหมู่ หรือแสดงฟิลด์ป้ายน้อยลงมักให้ผลลัพธ์ที่ชัดเจน ป้ายสามารถรวมชื่อหมวดหมู่ ชื่อซีรีส์ และค่าได้ผ่าน [DataLabelFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabelformat/) แต่เปิดใช้ทุกฟิลด์บ่อยครั้งทำให้แผนภูมิเชิงลำดับชั้นอ่านยาก

### **การส่งออกและการแสดงผล**

การบันทึกเป็น PPTX ทำให้แผนภูมิสามารถแก้ไขได้ เมื่อ Aspose.Slides แสดงผลงานนำเสนอเป็น PDF หรือภาพ การเติมสีและการตั้งค่าป้ายที่รองรับจะถูกรวมในการแสดงผล การแทนที่แบบอักษรและความแตกต่างเล็กน้อยในพื้นที่จัดวางที่มีอาจทำให้การตัดบรรทัดหรือการมองเห็นป้ายเปลี่ยนแปลง ดังนั้นควรติดตั้งแบบอักษรที่จำเป็นและตรวจสอบเป้าหมายการส่งออกสำคัญ

## **คำถามที่พบบ่อย**

**ทำไมการเปลี่ยนระดับของพาเรนท์จึงส่งผลต่อหลายใบ?**

สาขาหรือส่วนหลักเป็นเซกเมนต์ภาพที่ใช้ร่วมกัน สามารถเข้าถึง [ChartDataPointLevel](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointlevel/) ผ่านใบที่เป็นทายาทได้ แต่การฟอร์แมตจะเป็นของเซกเมนต์พาเรนท์ที่ใช้ร่วมกัน ไม่ใช่เฉพาะใบนั้นเท่านั้น

**ทำไมป้ายข้อมูลจึงหายไป?**

ต้องเปิดฟิลด์ที่ต้องการบนอ็อบเจกต์ [DataLabelFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabelformat/) ของป้ายก่อน แล้วตรวจสอบว่าเซกเมนต์มีพื้นที่เพียงพอหรือไม่ การจัดวางป้ายพาเรนท์ของ Treemap, ขนาดแผนภูมิ, ความยาวป้าย, ขนาดตัวอักษร, และจำนวนฟิลด์ที่เปิดใช้งานทั้งหมดมีผลต่อการแสดงผลของป้าย

**ฉันสามารถตั้งค่าลำดับหรือพิกัดที่แน่นอนของเซกเมนต์ได้หรือไม่?**

คุณสามารถควบคุมลำดับแถวต้นฉบับและให้แต่ละกลุ่มต่อเนื่องกันได้ แต่ไม่สามารถกำหนดสี่เหลี่ยม Treemap หรือมุม Sunburst อย่างแม่นยำได้ เครื่องยนต์จัดวางแผนภูมิคำนวณตำแหน่งเหล่านั้นจากโครงสร้างลำดับชั้น, ค่า, และพื้นที่ที่มี

**ทำไมสีจึงเปลี่ยนหลังจากธีมการนำเสนอเปลี่ยน?**

การเติมสีตามธีมออกแบบมาให้ตามพาเล็ตของงานนำเสนอ ใช้สี RGB อย่างชัดเจนกับระดับที่ต้องคงที่ หรือคงใช้สีตามโทนธีมเมื่อต้องการให้สอดคล้องกับธีมใหม่

**การฟอร์แมตแบบกำหนดเองจะคงไว้ในไฟล์ PDF และการส่งออกภาพหรือไม่?**

ใช้ได้ การเติมสีแผนภูมิและการตั้งค่าป้ายที่รองรับจะถูกรวมในระหว่างการแสดงผล สำหรับผลลัพธ์สม่ำเสมอระหว่างระบบต่าง ๆ ให้เตรียมแบบอักษรที่ต้องการและทดสอบขนาดการส่งออกสุดท้าย เนื่องจากการพอดีป้ายขึ้นอยู่กับการจัดวาง

## **ดูเพิ่มเติม**

- [สร้างแผนภูมิ Treemap](/slides/th/python-net/create-chart/#create-tree-map-charts)
- [สร้างแผนภูมิ Sunburst](/slides/th/python-net/create-chart/#create-sunburst-charts)
- [ส่งออกแผนภูมิการนำเสนอ](/slides/th/python-net/export-chart/)
- [จัดการธีมการนำเสนอ](/slides/th/python-net/presentation-theme/)