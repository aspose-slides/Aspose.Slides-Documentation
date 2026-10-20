---
title: วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 60
url: /th/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- อ็อบเจกต์ OLE
- ฝังแผนภูมิ
- PowerPoint
- งานนำเสนอ
- Python ผ่าน .NET
- Python
- Aspose.Slides
description: "แก้ไขการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้ OLE objects ของ Excel ที่ฝังอยู่กับ Aspose.Slides สำหรับ Python ผ่าน .NET ตั้งค่าขนาดแผนภูมิคงที่เพื่อให้ขนาดแผนภูมิและกรอบ OLE สอดคล้องกัน"
---
## **ภาพรวม**

Excel charts embedded as OLE objects in PowerPoint presentations using Aspose components can change size after their first activation. This can cause a noticeable difference in the chart's appearance before and after activation. This article explains why resizing occurs and shows how to prevent it by matching fixed chart dimensions to the OLE frame.

In [สร้างแผนภูมิ Excel และฝังเป็น OLE Objects ในงานนำเสนอ](/slides/th/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Python via .NET and embed it in a PowerPoint presentation using Aspose.Slides for Python via .NET. To address the [ปัญหาการแสดงตัวอย่างของอ็อบเจ็กต์](/slides/th/python-net/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **สาเหตุของการปรับขนาด**

เวิร์กบุ๊ก Excel ที่ฝังอยู่มีขนาดหน้าต่างของตนเอง ซึ่ง Excel พยายามรักษาไว้เมื่ออ็อบเจ็กต์ถูกเปิดใช้งานครั้งแรก กรอบ OLE บนสไลด์มีการกำหนดขนาดอย่างอิสระ เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดของอ็อบเจ็กต์เพื่อรักษาสัดส่วนของมันเป็นส่วนหนึ่งของกระบวนการฝัง ความแตกต่างระหว่างหน้าต่างของเวิร์กบุ๊กและกรอบ OLE จึงอาจทำให้เกิดการปรับขนาดของอ็อบเจ็กต์ได้

## **วิธีแก้ที่ใช้งานได้**

ให้ขนาดแผนภูมิตรงกับกรอบ OLE บนสไลด์และทำให้ขนาดของแผนภูมิเป็นอิสระจากหน้าต่างของเวิร์กบุ๊ก วิธีแก้นี้ใช้ได้กับงานนำเสนอใหม่หรือเทมเพลตที่มีอยู่

ตัวอย่างนี้ต้องใช้ Aspose.Cells สำหรับ Python ผ่าน .NET และ Aspose.Slides สำหรับ Python ผ่าน .NET มันสร้างแผนภูมิคอลัมน์แบบง่ายบนชีตแผนภูมิที่เปิดใช้งานและฝังเวิร์กบุ๊กในรูปแบบ XLS ไม่มีการกำหนดภาพแสดงตัวอย่างของแผนภูมิ; แผนภูมิจะปรากฏเมื่ออ็อบเจ็กต์ OLE ถูกเปิดใช้งานใน PowerPoint

ตัวอย่างสร้างงานนำเสนอใหม่ที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว โดยกำหนดตำแหน่งที่ 0.5 นิ้วจากขอบซ้ายและ 1 นิ้วจากด้านบน พิกัดและขนาดของสไลด์ใช้หน่วยเป็นจุด (72 จุดต่อหนึ่งนิ้ว) สำหรับงานนำเสนอที่มีอยู่ ดูที่ [ใช้เทมเพลต](#use-a-template)

## **กำหนดขนาดแผนภูมิคงที่**

ตั้งค่า [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) เป็น false เพื่อให้ขนาดของแผนภูมิเป็นอิสระจากหน้าต่างของเวิร์กบุ๊ก ตั้งค่า dimensions ของ [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) ผ่าน [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) และ [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/) โดยแปลงหน่วยจากจุดเป็นพิกเซลโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว: กรอบที่มีขนาด 684 × 288 จุดจะสอดคล้องกับแผนภูมิที่มีขนาด 912 × 384 พิกเซล ตั้งค่า [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) เป็นค่าคัสตอมของ [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). ตัวอย่างฝังเวิร์กบุ๊กด้วย [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) และบันทึกงานนำเสนอที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # พิกัดและขนาดของสไลด์ใช้หน่วยเป็นจุด (72 จุดต่อหนึ่งนิ้ว).
    width = 684.0  # 9.5 นิ้ว.
    height = 288.0  # 4 นิ้ว.

    chart.size_with_window = False
    # แปลงหน่วยจากจุดเป็นพิกเซลของแผนภูมิโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้เทมเพลต**

ตรรกะการกำหนดขนาดเหมือนกันสำหรับงานนำเสนอที่มีอยู่ เพื่อปรับตัวอย่าง:

1. โหลดงานนำเสนอเทมเพลตแทนการสร้างงานนำเสนอเปล่า
1. ตรวจสอบให้สไลด์แรกมีรูปร่างอย่างน้อยสามรูป แล้วใช้รูปร่างที่ตำแหน่ง index 2 เป็นตัวเติมที่ว่าง
1. ดึงความกว้างและความสูงของกรอบจากรูปร่างนั้นแทนการใช้ค่าคงที่ 684 และ 288 คงการคำนวณขนาดไว้เหมือนเดิม
1. เพิ่มกรอบ OLE ที่ตำแหน่งของตัวเติมที่ว่างแทนพิกัดคงที่ 36 และ 72
1. ลบตัวเติมที่ว่างก่อนบันทึกงานนำเสนอ

## **คำถามที่พบบ่อย**

**ทำไมแผนภูมิ Excel ที่ฝังอยู่ของฉันถึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**

เหตุการณ์นี้เกิดขึ้นเพราะ Excel พยายามคืนขนาดหน้าต่างเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาสัดส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

**ฉันจะทำให้ขนาดของแผนภูมิและกรอบ OLE สอดคล้องกันได้อย่างไร?**

ตั้งค่าขนาดแผนภูมิคงที่ให้ตรงกับกรอบ OLE และใช้ขนาดการพิมพ์แผนภูมิแบบกำหนดเองก่อนฝังเวิร์กบุ๊ก ตัวอย่างด้านบนแสดงการตั้งค่าที่จำเป็นและการแปลงหน่วย

**การจับขนาดหน้าต่างของเวิร์กบุ๊กให้ตรงกันพอหรือไม่?**

การจับขนาดหน้าต่างของเวิร์กบุ๊กให้ตรงกันอย่างเดียวไม่สามารถป้องกันกรอบ OLE จากการเปลี่ยนขนาดหลังจากเปิดใช้งานได้อย่างเชื่อถือ ใช้ขนาดแผนภูมิคงที่ตามที่แสดงในตัวอย่าง

**วิธีแก้นี้ทำงานได้กับงานนำเสนอแบบใช้เทมเพลตและงานนำเสนอใหม่หรือไม่?**

ใช่ สำหรับเทมเพลต ให้ใช้ขนาดและตำแหน่งของตัวเติมที่ว่าง สำหรับงานนำเสนอใหม่ ให้ระบุขนาดและตำแหน่งของกรอบโดยตรง

**ฉันสามารถใช้ตัวอย่างนี้กับแผนภูมิที่สร้างด้วยโปรแกรมสเปรดชีตอื่นได้หรือไม่?**

ตัวอย่างใช้เวิร์กบุ๊ก Excel ที่สร้างด้วย Aspose.Cells ไม่ได้แสดงพฤติกรรมการเปิดใช้งานสำหรับโปรแกรมสเปรดชีตอื่น

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel และฝังเป็น OLE Objects ในงานนำเสนอ](/slides/th/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [อัปเดต OLE Objects อัตโนมัติโดยใช้ PowerPoint Add-In](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)