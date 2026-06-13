---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย Python
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- จุดข้อมูล
- สีป้าย
- สีสาขา
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการจุดข้อมูลในแผนภูมิ treemap และ sunburst ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ที่รองรับรูปแบบ PowerPoint และ OpenDocument"
---
## **คำนำ**

นอกจากประเภทแผนภูมิ PowerPoint อื่น ๆ แล้ว ยังมีแผนภูมิแบบลำดับชั้นสองแบบ คือ **Treemap** และ **Sunburst** (ยังเรียกว่า Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph หรือ Multi-Level Pie Chart) แผนภูมิเหล่านี้จะแสดงข้อมูลแบบลำดับชั้นที่จัดเป็นต้นไม้ ตั้งแต่ใบถึงยอดของสาขา ใบถูกกำหนดโดยจุดข้อมูลของ series และแต่ละระดับการจัดกลุ่มซ้อนกันต่อไปจะกำหนดโดยหมวดหมู่ที่สอดคล้องกัน Aspose.Slides for Python via .NET ให้คุณจัดรูปแบบจุดข้อมูลของแผนภูมิ Sunburst และ Treemap ด้วย Python.

นี่คือแผนภูมิ Sunburst ที่ข้อมูลในคอลัมน์ Series1 กำหนดโหนดใบ ในขณะที่คอลัมน์อื่นกำหนดจุดข้อมูลแบบลำดับชั้น:

![Sunburst chart example](sunburst_example.png)

เริ่มต้นด้วยการเพิ่มแผนภูมิ Sunburst ใหม่ลงในงานนำเสนอ:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}}
- [**สร้างแผนภูมิ Sunburst**](/slides/th/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

หากคุณต้องการจัดรูปแบบจุดข้อมูลของแผนภูมิ ให้ใช้ API ต่อไปนี้:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointlevel/), and the [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) property. พวกเขาให้การเข้าถึงการจัดรูปแบบจุดข้อมูลในแผนภูมิ Treemap และ Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) ใช้เพื่อเข้าถึงหมวดหมู่หลายระดับ; มันเป็นคอนเทนเนอร์ของวัตถุ [ChartDataPointLevel](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointlevel/). โดยพื้นฐานแล้วเป็น wrapper รอบ [ChartCategoryLevelsManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartcategorylevelsmanager/) พร้อมคุณสมบัติเพิ่มเติมที่เจาะจงสำหรับจุดข้อมูล. ประเภท [ChartDataPointLevel](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointlevel/) เปิดเผยสองคุณสมบัติ—[format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointlevel/format/) และ [label](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointlevel/label/)—ซึ่งให้การเข้าถึงการตั้งค่าที่สอดคล้องกัน.

## **แสดงค่าจุดข้อมูล**

ส่วนนี้จะแสดงวิธีการแสดงค่าของจุดข้อมูลแต่ละรายการในแผนภูมิ Treemap และ Sunburst คุณจะได้เห็นวิธีเปิดใช้งานป้ายค่าสำหรับจุดที่เลือก

แสดงค่าของจุดข้อมูล "Leaf 4":

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![ค่าจุดข้อมูล](data_point_value.png)

## **ตั้งค่าป้ายและสีสำหรับจุดข้อมูล**

ส่วนนี้จะแสดงวิธีตั้งค่าป้ายและสีที่กำหนดเองสำหรับจุดข้อมูลแต่ละรายการในแผนภูมิ Treemap และ Sunburst คุณจะได้เรียนรู้วิธีเข้าถึงจุดข้อมูลเฉพาะ กำหนดป้าย และใช้การเติมสีทึบเพื่อเน้นโหนดสำคัญ

ตั้งค่าป้ายข้อมูลของ "Branch 1" ให้แสดงชื่อ series ("Series1") แทนชื่อหมวดหมู่ แล้วตั้งค่าสีข้อความเป็นสีเหลือง:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![ป้ายและสีของจุดข้อมูล](data_point_color.png)

## **ตั้งค่าสีสาขาสำหรับจุดข้อมูล**

ใช้สีสาขาเพื่อควบคุมการจัดกลุ่มแบบภาพของโหนดพาเรนท์และลูกในแผนภูมิ Treemap และ Sunburst ส่วนนี้จะแสดงวิธีตั้งค่าสีสาขาที่กำหนดเองสำหรับจุดข้อมูลเฉพาะ เพื่อให้คุณสามารถเน้นต้นไม้ย่อยสำคัญและปรับปรุงความอ่านง่ายของแผนภูมิ

เปลี่ยนสีของสาขา "Stem 4":

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![สีสาขา](branch_color.png)

## **คำถามที่พบบ่อย**

**Can I change the order (sorting) of segments in Sunburst/Treemap?**  
ไม่ PowerPoint จะเรียงลำดับเซกเมนต์โดยอัตโนมัติ (โดยทั่วไปตามค่าลดลง ไปตามเข็มนาฬิกา) Aspose.Slides ทำเช่นเดียวกัน: คุณไม่สามารถเปลี่ยนลำดับโดยตรงได้; ต้องทำโดยการเตรียมข้อมูลล่วงหน้า

**How does the presentation theme affect the colors of segments and labels?**  
ธีมของงานนำเสนอส่งผลต่อสีของเซกเมนต์และป้ายอย่างไร?  
สีของแผนภูมิเชื่อมต่อจาก [theme/palette](/slides/th/python-net/presentation-theme/) ของงานนำเสนอ เว้นแต่คุณจะตั้งค่าการเติม/ฟอนต์อย่างชัดเจน เพื่อผลลัพธ์ที่สอดคล้องกัน ให้ล็อกการเติมสีทึบและการจัดรูปแบบข้อความในระดับที่ต้องการ

**Will export to PDF/PNG preserve custom branch colors and label settings?**  
การส่งออกเป็น PDF/PNG จะคงสีสาขาที่กำหนดเองและการตั้งค่าป้ายไว้หรือไม่?  
ใช่ เมื่อส่งออกงานนำเสนอ การตั้งค่าแผนภูมิ (การเติม, ป้าย) จะคงไว้ในรูปแบบผลลัพธ์ เนื่องจาก Aspose.Slides ทำการเรนเดอร์พร้อมกับการจัดรูปแบบของแผนภูมิ

**Can I compute the actual coordinates of a label/element for custom overlay placement on top of the chart?**  
ฉันสามารถคำนวณพิกัดจริงของป้าย/องค์ประกอบเพื่อวาง overlay แบบกำหนดเองบนแผนภูมิได้หรือไม่?  
ใช่ หลังจากตรวจสอบการจัดวางแผนภูมิแล้ว `actual_x`/`actual_y` จะพร้อมใช้สำหรับองค์ประกอบ (เช่น [DataLabel](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabel/)) ซึ่งช่วยในการกำหนดตำแหน่ง overlay อย่างแม่นยำ