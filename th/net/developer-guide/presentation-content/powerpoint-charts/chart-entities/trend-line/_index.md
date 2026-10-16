---
title: เพิ่มเส้นแนวโน้มให้กับแผนภูมิพรีเซนเทชันใน .NET
linktitle: เส้นแนวโน้ม
type: docs
url: /th/net/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มเอ็กซ์พอเนนเชียล
- เส้นแนวโน้มเชิงเส้น
- เส้นแนวโน้มลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มโพลิโนเมียล
- เส้นแนวโน้มพาวเวอร์
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ .NET — คู่มือเชิงปฏิบัติในการดึงดูดผู้ฟังของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีเพิ่มเส้นแนวโน้มให้กับแผนภูมิพรีเซนเทชันโดยใช้ Aspose.Slides รวมถึงการสร้างแผนภูมิ การเพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ และการทำงานกับประเภทเส้นแนวโน้มหลายประเภท เช่น เอ็กซ์พอเนนเชียล, เชิงเส้น, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, โพลิโนเมียลและพาวเวอร์

ยังอธิบายวิธีเพิ่มเส้นกำหนดเองลงในแผนภูมิโดยการแทรกรูปทรงเส้น และให้คำถามที่พบบ่อยสั้น ๆ เกี่ยวกับค่าการฉายเส้นแนวโน้มไปข้างหน้าและถอยหลัง รวมถึงว่าการส่งออกเป็น PDF หรือ SVG หรือการแปลงแผนภูมิเป็นรูปภาพจะคงเส้นแนวโน้มไว้หรือไม่

## **เพิ่มเส้นแนวโน้ม**

ใช้ [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) เพื่อเพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ โดยเลือกประเภทด้วย [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) ตัวอย่างสร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลค่าเริ่มต้นและเพิ่มเส้นแนวโน้มสองเส้นให้กับแต่ละหนึ่งในสามชุดข้อมูลของมัน

เส้นแนวโน้มเอ็กซ์พอเนนเชียลซ่อนสมการและค่า R‑squared ผ่าน [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) และ [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) ส่วนเส้นแนวโน้มเชิงเส้นมีสีแดง เส้นแนวโน้มลอการิทึมใช้ [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) เพื่อกำหนดป้ายกำกับแบบกำหนดเอง ค่าเฉลี่ยเคลื่อนที่ใช้ [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) เป็นสามจุดข้อมูลและกำหนด [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) แบบกำหนดเอง

เส้นแนวโน้มโพลิโนเมียลมี [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) เป็นสามและขยายหนึ่งหมวดหมู่ไปข้างหน้าผ่าน [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/) เส้นแนวโน้มพาวเวอร์ขยายหนึ่งหมวดหมู่ไปข้างหลังผ่าน [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/)

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **กำหนดจุดตัดของเส้นแนวโน้ม**

ใช้ [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) เพื่อกำหนดค่ามิติ Y ของเส้นแนวโน้มที่ X = 0 การตั้งค่านี้รองรับสำหรับเส้นแนวโน้มเชิงเส้น, เอ็กซ์พอเนนเชียลและโพลิโนเมียล

ตัวอย่างเช่น โมเดลต้นทุนการผลิตอาจต้องเริ่มจากต้นทุนคงที่ที่ทราบเป็น 100 แม้ว่าการวัดที่ปริมาณการผลิตที่ไม่เป็นศูนย์จะบ่งชี้ฐานค่าเริ่มต้นที่แตกต่าง สำหรับเส้นแนวโน้มเชิงเส้น การกำหนดจุดตัดทำให้สมการ `y = ax + b` มี `b = 100`; ความชันจะถูกฟิตให้เข้ากับข้อมูลภายใต้เงื่อนไขนั้น ไม่ได้ย้ายเส้นที่ฟิตแล้วแล้วเส้น การตั้งค่าการตัดแกนควบคุมจุดที่แกนของแผนภูมิตัดกัน ไม่ได้แก้ไขค่าสัมประสิทธิ์ของเส้นแนวโน้มที่ฟิตแล้ว

ตัวอย่างต่อไปนี้สร้างแผนภูมิกระจาย (XY) ที่มีปริมาณการผลิตตั้งแต่ 1 ถึง 4 และต้นทุน 170, 200, 230, 260 บันทึกแผนภูมิด้วยจุดตัดอัตโนมัติค่าเริ่มต้น แล้วตั้งค่าจุดตัดเป็น 100 และบันทึก PPTX ครั้งที่สอง ทั้งสองไฟล์แตกต่างกันเพียงการตั้งค่าจุดตัดเท่านั้น เส้นแนวโน้มแสดงสมการและขยายกลับไปที่ X = 0

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

เมื่อคำนวณอัตโนมัติ ข้อมูลเหล่านี้ให้ `y = 30x + 140` การตั้งค่าจุดตัดเป็น 100 แทนจะให้ค่าโดยประมาณ `y = 43.33x + 100`: ค่าที่ฟิตที่ศูนย์ตรงกับฐานที่ทราบ ส่วนเส้นจะไม่ผ่านทุกจุดข้อมูลอีกต่อไป

| จุดตัดอัตโนมัติ | จุดตัดคงที่ 100 |
| --- | --- |
| ![เส้นแนวโน้มเชิงเส้นที่คำนวณจุดตัดอัตโนมัติ 140](intercept-automatic.png) | ![เส้นแนวโน้มเชิงเส้นที่มีจุดตัดคงที่ 100](intercept-fixed.png) |

ทั้งสองภาพใช้ข้อมูลและสเกลแกนเดียวกัน เส้นแนวโน้มถูกขยายกลับไปที่ X = 0 เพื่อแสดงจุดตัดของมัน

โดยค่าเริ่มต้นคุณสมบัตินี้มีค่า `double.NaN` ซึ่งหมายถึงจุดตัดที่ไม่ได้ระบุ ไม่ใช่ศูนย์ แล้วจุดตัดจะถูกคำนวณอัตโนมัติจากข้อมูล

## **เพิ่มเส้นกำหนดเอง**

เส้นกำหนดเองคือรูปทรงที่วาดเหนือแผนภูมิแทนที่จะเป็นเส้นแนวโน้มที่คำนวณจากข้อมูลชุดข้อมูล ตัวอย่างนี้ใช้ [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) เพื่อเพิ่มเส้นแนวนอนลงบนสไลด์เหนือแผนภูมิ ตำแหน่งของเส้นระบุด้วยพิกัดสไลด์หน่วยจุด ดังนั้นเส้นเริ่มที่ขอบซ้ายของแผนภูมิและอยู่กึ่งกลางความสูงของแผนภูมิ ความกว้างตรงกับความกว้างของแผนภูมิ [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) ทำให้เส้นเป็นสีแดงทึบ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ค่า ‘forward’ และ ‘backward’ มีความหมายอย่างไรสำหรับเส้นแนวโน้ม?**

เป็นความยาวของเส้นแนวโน้มที่ฉายไปข้างหน้า/ข้างหลัง: สำหรับแผนภูมิกระจาย (XY) – หน่วยตามแกน; สำหรับแผนภูมิที่ไม่ใช่กระจาย – จำนวนหมวดหมู่ Only ค่าที่ไม่เป็นลบเท่านั้นที่อนุญาต

**เส้นแนวโน้มจะถูกรักษาไว้เมื่อส่งออกพรีเซนเทชันเป็น PDF หรือ SVG หรือเมื่อตีกราฟเป็นรูปภาพหรือไม่?**

ใช่ Aspose.Slides แปลงพรีเซนเทชันเป็น [PDF](/slides/th/net/convert-powerpoint-to-pdf/) หรือ [SVG](/slides/th/net/render-a-slide-as-an-svg-image/) และแปลงแผนภูมิเป็นรูปภาพ; เส้นแนวโน้มในฐานะแผนภูมิจะถูกคงไว้ในกระบวนการเหล่านี้ มีเมธอดเพิ่มเติมเพื่อ [export an image of the chart](/slides/th/net/create-shape-thumbnails/) โดยตรงด้วย