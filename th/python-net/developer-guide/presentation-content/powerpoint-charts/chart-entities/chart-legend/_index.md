---
title: ปรับแต่งคำอธิบายแผนภูมิในงานนำเสนอด้วย Python
linktitle: คำอธิบายแผนภูมิ
type: docs
url: /th/python-net/chart-legend/
keywords:
- คำอธิบายแผนภูมิ
- ตำแหน่งคำอธิบาย
- ขนาดฟอนต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ปรับแต่งคำอธิบายแผนภูมิด้วย Aspose.Slides for Python ผ่าน .NET เพื่อเพิ่มประสิทธิภาพการนำเสนอ PowerPoint และ OpenDocument ด้วยรูปแบบคำอธิบายที่ปรับให้เหมาะสม"
---
## **ภาพรวม**

Aspose.Slides for Python ให้การควบคุมเต็มรูปแบบเหนือคำอธิบายของแผนภูมิ เพื่อให้คุณสามารถทำให้ป้ายข้อมูลชัดเจนและพร้อมนำเสนอได้ คุณสามารถแสดงหรือซ่อนคำอธิบาย เลือกตำแหน่งบนสไลด์ และปรับการจัดวางเพื่อป้องกันการทับกับพื้นที่พล็อต API ช่วยให้คุณจัดสไตล์ข้อความและเครื่องหมาย ปรับระยะห่างและพื้นหลังอย่างละเอียด และจัดรูปแบบเส้นขอบและการเติมสีให้ตรงกับธีมของคุณ นักพัฒนายังสามารถเข้าถึงรายการคำอธิบายแต่ละรายการเพื่อเปลี่ยนชื่อหรือกรองได้ เพื่อให้แสดงเฉพาะชุดข้อมูลที่สำคัญที่สุด ด้วยความสามารถเหล่านี้ แผนภูมิของคุณจะอ่านง่าย สม่ำเสมอ และสอดคล้องกับมาตรฐานการออกแบบของการนำเสนอ

## **การวางตำแหน่งคำอธิบาย**

ด้วย Aspose.Slides คุณสามารถควบคุมได้อย่างรวดเร็วว่าคำอธิบายของแผนภูมิจะปรากฏที่ใดและเข้ากับการจัดวางสไลด์ของคุณอย่างไร เรียนรู้วิธีวางตำแหน่งคำอธิบายอย่างแม่นยำ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์
3. เพิ่มแผนภูมิไปยังสไลด์
4. ตั้งค่าคุณสมบัติของคำอธิบาย
5. บันทึกการนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราตั้งค่าตำแหน่งและขนาดของคำอธิบายแผนภูมิ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # รับอ้างอิงไปยังสไลด์.
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มไปยังสไลด์.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # ตั้งค่าคุณสมบัติของคำอธิบาย.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # บันทึกการนำเสนอไปยังดิสก์.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าขนาดฟอนต์ของคำอธิบาย**

ขนาดฟอนต์ของคำอธิบายแผนภูมิควรอ่านได้ง่ายเท่ากับข้อมูลที่อธิบาย ส่วนนี้แสดงวิธีปรับขนาดฟอนต์ของคำอธิบายเพื่อให้สอดคล้องกับการออกแบบการนำเสนอและเพิ่มความสามารถในการเข้าถึง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. สร้างแผนภูมิ
3. ตั้งค่าขนาดฟอนต์
4. บันทึกการนำเสนอลงดิสก์

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าขนาดฟอนต์สำหรับรายการคำอธิบาย**

Aspose.Slides ให้คุณปรับรูปลักษณ์ของคำอธิบายแผนภูมิด้วยการฟอร์แมตรายการแต่ละรายการ ตัวอย่างด้านล่างแสดงวิธีเลือกรายการคำอธิบายเฉพาะและตั้งค่าคุณสมบัติของมันโดยไม่กระทบต่อส่วนอื่นของคำอธิบาย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. สร้างแผนภูมิ
3. เข้าถึงรายการคำอธิบาย
4. ตั้งค่าคุณสมบัติของรายการ
5. บันทึกการนำเสนอลงดิสก์

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้งานคำอธิบายเพื่อให้แผนภูมิจัดสรรพื้นที่ให้โดยอัตโนมัติแทนการซ้อนทับได้หรือไม่?**

ใช่ ใช้โหมดไม่ซ้อนทับ ([overlay](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/legend/overlay/) = `false`); ในกรณีนี้ พื้นที่พล็อตจะหดลงเพื่อให้พื้นที่กับคำอธิบาย

**ฉันสามารถทำป้ายคำอธิบายหลายบรรทัดได้หรือไม่?**

ใช่ ป้ายที่ยาวจะตัดบรรทัดอัตโนมัติเมื่อพื้นที่ไม่เพียงพอ; การบังคับขึ้นบรรทัดใหม่รองรับโดยการใช้ตัวอักษร newline ในชื่อซีรีส์

**ฉันจะทำให้คำอธิบายตรงตามโทนสีของธีมการนำเสนอได้อย่างไร?**

อย่าใส่สี/การเติม/ฟอนต์เฉพาะสำหรับคำอธิบายหรือข้อความของมัน ค่าต่าง ๆ จะสืบทอดจากธีมและอัปเดตอย่างถูกต้องเมื่อการออกแบบเปลี่ยนแปลง