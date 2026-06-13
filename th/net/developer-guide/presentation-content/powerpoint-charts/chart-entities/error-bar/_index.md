---
title: ปรับแต่งแถบความคลาดเคลื่อนในแผนภูมิการนำเสนอด้วย .NET
linktitle: แถบความคลาดเคลื่อน
type: docs
url: /th/net/error-bar/
keywords:
- แถบความคลาดเคลื่อน
- ค่ากำหนดเอง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและปรับแต่งแถบความคลาดเคลื่อนในแผนภูมิด้วย Aspose.Slides สำหรับ .NET—เพิ่มประสิทธิภาพการแสดงข้อมูลในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแถบความคลาดเคลื่อนในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีการเพิ่มแถบความคลาดเคลื่อนให้กับชุดข้อมูลของแผนภูมิ ตั้งค่าการแสดงแถบ X และ Y และใช้ประเภทค่าต่าง ๆ เช่น ค่าคงที่ เปอร์เซ็นต์ และค่าที่กำหนดเอง

บทความยังสาธิตวิธีการกำหนดค่าที่กำหนดเองสำหรับแถบความคลาดเคลื่อนของแต่ละจุดข้อมูลในชุดข้อมูลโดยใช้คอลเลกชันของจุดข้อมูลที่สอดคล้องกัน นอกจากนี้ยังมีหมายเหตุสั้น ๆ เกี่ยวกับพฤติกรรมของแถบความคลาดเคลื่อนระหว่างการส่งออก ความเข้ากันได้กับเครื่องหมายและป้ายข้อมูล และตำแหน่งที่สามารถค้นหาคลาสและ enum ของเอกสารอ้างอิง API ที่เกี่ยวข้อง

## **เพิ่มแถบความคลาดเคลื่อน**
Aspose.Slides for .NET มี API อย่างง่ายสำหรับจัดการค่าของแถบความคลาดเคลื่อน ตัวอย่างโค้ดใช้ได้เมื่อใช้ประเภทค่าที่กำหนดเอง เพื่อระบุค่า ให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลที่เฉพาะเจาะจงในคอลเลกชัน **DataPoints** ของชุดข้อมูล:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
1. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ
1. เข้าถึงชุดข้อมูลแผนภูมิแรกและตั้งค่ารูปแบบแถบความคลาดเคลื่อน X
1. เข้าถึงชุดข้อมูลแผนภูมิแรกและตั้งค่ารูปแบบแถบความคลาดเคลื่อน Y
1. ตั้งค่าค่าและรูปแบบของแถบ
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```c#
// สร้างงานนำเสนอเปล่า
using (Presentation presentation = new Presentation())
{
    // สร้างแผนภูมิบับเบิล
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // เพิ่มแถบความคลาดเคลื่อนและตั้งค่ารูปแบบ
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // บันทึกงานนำเสนอ
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มค่าที่กำหนดเองสำหรับแถบความคลาดเคลื่อน**
Aspose.Slides for .NET มี API อย่างง่ายสำหรับจัดการค่าที่กำหนดเองของแถบความคลาดเคลื่อน ตัวอย่างโค้ดใช้ได้เมื่อคุณสมบัติ **IErrorBarsFormat.ValueType** มีค่าเท่ากับ **Custom** เพื่อระบุค่า ให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลที่เฉพาะเจาะจงในคอลเลกชัน **DataPoints** ของชุดข้อมูล:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
1. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ
1. เข้าถึงชุดข้อมูลแผนภูมิแรกและตั้งค่ารูปแบบแถบความคลาดเคลื่อน X
1. เข้าถึงชุดข้อมูลแผนภูมิแรกและตั้งค่ารูปแบบแถบความคลาดเคลื่อน Y
1. เข้าถึงจุดข้อมูลแต่ละจุดของชุดข้อมูลแผนภูมิและตั้งค่าค่าแถบความคลาดเคลื่อนสำหรับจุดข้อมูลแต่ละจุดของชุดข้อมูล
1. ตั้งค่าค่าและรูปแบบของแถบ
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```c#
// สร้างงานนำเสนอเปล่า
using (Presentation presentation = new Presentation())
{
    // สร้างแผนภูมิบับเบิล
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // เพิ่มแถบความคลาดเคลื่อนแบบกำหนดเองและตั้งค่ารูปแบบ
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // เข้าถึงจุดข้อมูลของชุดแผนภูมิและกำหนดค่าแถบความคลาดเคลื่อนสำหรับแต่ละจุด
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // ตั้งค่าแถบความคลาดเคลื่อนสำหรับจุดในชุดแผนภูมิ
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // บันทึกงานนำเสนอ
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**อะไรเกิดขึ้นกับแถบความคลาดเคลื่อนเมื่อส่งออกรายงานนำเสนอเป็น PDF หรือรูปภาพ?**

พวกมันจะถูกเรนเดอร์เป็นส่วนหนึ่งของแผนภูมิและคงอยู่ระหว่างการแปลงพร้อมกับการจัดรูปแบบของแผนภูมิทั้งหมด โดยสมมติว่ามีเวอร์ชันหรือเรนเดอร์เดอร์ที่เข้ากันได้

**สามารถรวมแถบความคลาดเคลื่อนกับเครื่องหมายและป้ายข้อมูลได้หรือไม่?**

ได้. แถบความคลาดเคลื่อนเป็นองค์ประกอบแยกต่างหากและเข้ากันได้กับเครื่องหมายและป้ายข้อมูล; หากองค์ประกอบทับกันคุณอาจต้องปรับการจัดรูปแบบ

**จะหาข้อมูลรายการของคุณสมบัติและ enum สำหรับการทำงานกับแถบความคลาดเคลื่อนใน API ได้จากที่ไหน?**

ในเอกสารอ้างอิง API: คลาส [ErrorBarsFormat](https://reference.aspose.com/slides/th/net/aspose.slides.charts/errorbarsformat/) และ enum ที่เกี่ยวข้อง [ErrorBarType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/errorbartype/) และ [ErrorBarValueType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/errorbarvaluetype/).