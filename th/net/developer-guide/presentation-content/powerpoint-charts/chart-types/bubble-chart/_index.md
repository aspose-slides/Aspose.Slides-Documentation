---
title: ปรับแต่งแผนภูมิบับเบิลในการนำเสนอด้วย .NET
linktitle: แผนภูมิบับเบิล
type: docs
url: /th/net/bubble-chart/
keywords:
- แผนภูมิบับเบิล
- ขนาดบับเบิล
- การสเกลขนาด
- การแสดงผลขนาด
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิบับเบิลที่มีประสิทธิภาพใน PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อเพิ่มการแสดงผลข้อมูลของคุณได้ง่ายขึ้น"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิบับเบิลใน Aspose.Slides โดยครอบคลุมสองตัวเลือกการปรับแต่งเฉพาะ: การปรับสเกลขนาดบับเบิลผ่านคุณสมบัติ `BubbleSizeScale` และการควบคุมวิธีที่ค่า ขนาดบับเบิลถูกแสดงผ่านคุณสมบัติ `BubbleSizeRepresentation`  

ตัวอย่างจะแสดงวิธีสร้างแผนภูมิบับเบิล ปรับสเกลขนาดและสลับการแสดงผลขนาดบับเบิลให้ใช้ความกว้าง บทความยังมีส่วนคำถามที่พบบ่อยสั้น ๆ ที่ชี้แจงการสนับสนุนประเภทแผนภูมิ “Bubble with 3-D”, ระบุว่าขีดจำกัดของแผนภูมิขึ้นอยู่กับประสิทธิภาพและเวอร์ชัน PowerPoint เป้าหมาย, และอธิบายว่าการส่งออกจะคงลักษณะของแผนภูมิผ่านเอนจินการแสดงผลของ Aspose.Slides  

## **การปรับสเกลขนาดแผนภูมิบับเบิล**
Aspose.Slides for .NET ให้การสนับสนุนการปรับสเกลขนาดแผนภูมิบับเบิล ใน Aspose.Slides for .NET ได้เพิ่มคุณสมบัติ **IChartSeries.BubbleSizeScale** และ **IChartSeriesGroup.BubbleSizeScale** ตัวอย่างโค้ดด้านล่างนี้  

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **แสดงข้อมูลเป็นขนาดแผนภูมิบับเบิล**
คุณสมบัติ **BubbleSizeRepresentation** ถูกเพิ่มในอินเทอร์เฟซ IChartSeries, IChartSeriesGroup และคลาสที่เกี่ยวข้อง **BubbleSizeRepresentation** ระบุว่าค่า ขนาดบับเบิลจะแสดงในแผนภูมิบับเบิลอย่างไร ค่าที่เป็นไปได้คือ **BubbleSizeRepresentationType.Area** และ **BubbleSizeRepresentationType.Width** ตามนั้นได้เพิ่ม enum **BubbleSizeRepresentationType** เพื่อกำหนดวิธีที่เป็นไปได้ในการแสดงข้อมูลเป็นขนาดแผนภูมิบับเบิล ตัวอย่างโค้ดอยู่ด้านล่าง  

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**รองรับแผนภูมิบับเบิลที่มีเอฟเฟกต์ 3 มิติหรือไม่ และแตกต่างจากแผนภูมิปกติอย่างไร?**  
ใช่ มีประเภทแผนภูมิแยกต่างหากคือ “Bubble with 3-D.” ซึ่งจะใช้สไตล์ 3 มิติกับบับเบิลแต่ไม่เพิ่มแกนเพิ่มเติม; ข้อมูลยังคงเป็น X‑Y‑S (ขนาด) ประเภทนี้สามารถหาได้ใน enumeration ของ [chart type](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/)

**มีขีดจำกัดจำนวนซีรีส์และจุดในแผนภูมิบับเบิลหรือไม่?**  
ไม่มีขีดจำกัดที่แน่นอนในระดับ API; ข้อจำกัดจะถูกกำหนดโดยประสิทธิภาพและเวอร์ชัน PowerPoint เป้าหมาย แนะนำให้จำนวนจุดอยู่ในระดับที่เหมาะสมเพื่อความอ่านง่ายและความเร็วในการแสดงผล  

**การส่งออกจะมีผลต่อการแสดงผลของแผนภูมิบับเบิล (PDF, ภาพ) อย่างไร?**  
การส่งออกไปยังรูปแบบที่สนับสนุนจะคงรูปลักษณ์ของแผนภูมิไว้; การเรนเดอร์ทำโดยเอนจินของ Aspose.Slides สำหรับรูปแบบแรสเตอร์/เวกเตอร์ จะใช้กฎการเรนเดอร์กราฟิกของแผนภูมิโดยทั่วไป (ความละเอียด, การทำ anti‑aliasing) ดังนั้นควรเลือก DPI ที่เพียงพอสำหรับการพิมพ์