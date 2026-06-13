---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับงานนำเสนอใน .NET
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/net/chart-calculations/
keywords:
- การคำนวณแผนภูมิ
- องค์ประกอบแผนภูมิ
- ตำแหน่งองค์ประกอบ
- ตำแหน่งจริง
- องค์ประกอบลูก
- องค์ประกอบพาเรนต์
- ค่าของแผนภูมิ
- ค่าจริง
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำความเข้าใจการคำนวณแผนภูมิ, การอัปเดตข้อมูล, และการควบคุมความแม่นยำใน Aspose.Slides for .NET สำหรับ PPT และ PPTX พร้อมตัวอย่างโค้ด C# ที่เป็นประโยชน์."
---
## **ภาพรวม**

Aspose.Slides ให้ API สำหรับทำงานกับการคำนวณแผนภูมิและข้อมูลการจัดวางในงานนำเสนอ บทความนี้แสดงวิธีดึงค่าแท้จริงขององค์ประกอบแผนภูมิ รวมถึงตำแหน่งและขนาดจริงขององค์ประกอบที่ใช้ `IActualLayout` และค่าจริงของแกนแผนภูมิ นอกจากนี้ยังอธิบายว่าค่าเหล่านี้จะถูกเติมหลังจากการตรวจสอบการจัดวางแผนภูมิ

นอกจากนี้บทความยังสาธิตวิธีรับตำแหน่งจริงขององค์ประกอบแผนภูมิเพื่อพาเรนต์และวิธีซ่อนส่วนประกอบของแผนภูมิ เช่น ชื่อ, แกน, คำอธิบาย, และเส้นตาราง ตัวอย่างเหล่านี้ช่วยให้คุณตรวจสอบข้อมูลการจัดวางแผนภูมิและควบคุมการมองเห็นขององค์ประกอบแผนภูมิในงานนำเสนอ PowerPoint อย่างโปรแกรมเมติก

## **คำนวณค่าแท้จริงขององค์ประกอบแผนภูมิ**
Aspose.Slides for .NET มี API ที่ง่ายสำหรับการดึงคุณสมบัติเหล่านี้ ซึ่งจะช่วยให้คุณคำนวณค่าแท้จริงขององค์ประกอบแผนภูมิ ค่าแท้จริงประกอบด้วยตำแหน่งขององค์ประกอบที่ใช้ interface IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) และค่าจริงของแกน (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// กำลังบันทึกงานนำเสนอ
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **คำนวณตำแหน่งจริงขององค์ประกอบแผนภูมิเพื่อพาเรนต์**
Aspose.Slides for .NET มี API ที่ง่ายสำหรับการดึงคุณสมบัติเหล่านี้ คุณสมบัติของ IActualLayout ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแผนภูมิพาเรนต์ จำเป็นต้องเรียกเมธอด IChart.ValidateChartLayout() ก่อนเพื่อเติมคุณสมบัติด้วยค่าจริง

```c#
// สร้างงานนำเสนอเปล่า
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **ซ่อนองค์ประกอบแผนภูมิ**
หัวข้อนี้ช่วยให้คุณเข้าใจวิธีซ่อนข้อมูลจากแผนภูมิ โดยใช้ Aspose.Slides for .NET คุณสามารถซ่อน **Title, Vertical Axis, Horizontal Axis** และ **Grid Lines** จากแผนภูมิ ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้คุณสมบัติเหล่านี้

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // ซ่อนชื่อแผนภูมิ
    chart.HasTitle = false;

    /// ซ่อนแกนค่า
    chart.Axes.VerticalAxis.IsVisible = false;

    // การมองเห็นแกนประเภท
    chart.Axes.HorizontalAxis.IsVisible = false;

    // ซ่อนคำอธิบาย
    chart.HasLegend = false;

    // ซ่อนเส้นกริดหลัก
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    // ตั้งค่าสีเส้นซีรีส์
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ไฟล์ Excel ภายนอกสามารถทำงานเป็นแหล่งข้อมูลได้หรือไม่ และส่งผลต่อการคำนวณใหม่อย่างไร?**

ใช่ แผนภูมิสามารถอ้างอิงไฟล์ workbook ภายนอกได้: เมื่อคุณเชื่อมต่อหรือรีเฟรชแหล่งข้อมูลภายนอก สูตรและค่าจะถูกดึงจากไฟล์นั้น และแผนภูมิจะแสดงการอัปเดตขณะเปิดหรือแก้ไข API ให้คุณ [กำหนดไฟล์ workbook ภายนอก](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/setexternalworkbook/) path และจัดการข้อมูลที่เชื่อมโยง

**ฉันสามารถคำนวณและแสดงเส้นแนวโน้มโดยไม่ต้องเขียนการถดถอยด้วยตนเองได้หรือไม่?**

ใช่ [Trendlines](/slides/th/net/trend-line/) (เชิงเส้น, เอ็กซ์โพเนนเชียล และอื่น ๆ) จะถูกเพิ่มและอัปเดตโดย Aspose.Slides; พารามิเตอร์ของพวกมันจะถูกคำนวณใหม่จากข้อมูลชุดโดยอัตโนมัติ ดังนั้นคุณไม่จำเป็นต้องเขียนการคำนวณของคุณเอง

**หากงานนำเสนอมีแผนภูมิกี่หลายแผนพร้อมลิงก์ภายนอก ฉันสามารถควบคุมว่าแผนภูมิแต่ละอันใช้ workbook ภายนอกใดสำหรับค่าที่คำนวณได้หรือไม่?**

ใช่ แต่ละแผนภูมิสามารถชี้ไปยัง [external workbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/setexternalworkbook/) ของตนเองได้ หรือคุณสามารถสร้าง/แทนที่ไฟล์ workbook ภายนอกสำหรับแต่ละแผนภูมิโดยแยกจากกัน