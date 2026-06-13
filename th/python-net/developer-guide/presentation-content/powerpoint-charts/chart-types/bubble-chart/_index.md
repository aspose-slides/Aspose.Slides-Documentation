---
title: ปรับแต่งแผนภูมิบับเบิลในงานนำเสนอด้วย Python
linktitle: แผนภูมิบับเบิล
type: docs
url: /th/python-net/bubble-chart/
keywords:
- แผนภูมิบับเบิล
- ขนาดบับเบิล
- การสเกลขนาด
- การแสดงขนาด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิบับเบิลที่มีประสิทธิภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อเพิ่มการแสดงข้อมูลของคุณได้อย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิบับเบิลใน Aspose.Slides โดยอธิบายตัวเลือกการปรับแต่งสองอย่างเฉพาะคือ การปรับขนาดบับเบิลโดยใช้คุณสมบัติ `bubble_size_scale` และการควบคุมวิธีการแสดงค่าขนาดบับเบิลโดยใช้คุณสมบัติ `bubble_size_representation`  

ตัวอย่างแสดงวิธีสร้างแผนภูมิบับเบิล ปรับการสเกลขนาด และสลับการแสดงขนาดบับเบิลให้ใช้ความกว้าง บทความยังมีส่วนคำถามที่พบบ่อยสั้น ๆ ที่อธิบายการรองรับประเภทแผนภูมิ “Bubble with 3-D” ระบุว่าขีดจำกัดของแผนภูมิขึ้นอยู่กับประสิทธิภาพและเวอร์ชัน PowerPoint เป้าหมาย และอธิบายว่าการส่งออกจะคงรูปลักษณ์ของแผนภูมิผ่านเครื่องยนต์การเรนเดอร์ของ Aspose.Slides  

## **การสเกลขนาดแผนภูมิบับเบิล**
Aspose.Slides for Python ผ่าน .NET มีการรองรับการสเคลขนาดของแผนภูมิบับเบิล ใน Aspose.Slides for Python ผ่าน .NET ได้เพิ่มคุณสมบัติ **ChartSeries.bubble_size_scale** และ **ChartSeriesGroup.bubble_size_scale** ตัวอย่างด้านล่างได้แสดงให้เห็น  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **แสดงข้อมูลเป็นขนาดแผนภูมิบับเบิล**
คุณสมบัติ **bubble_size_representation** ได้ถูกเพิ่มไปยังคลาส ChartSeries และ ChartSeriesGroup โดย **bubble_size_representation** ระบุว่าค่าขนาดบับเบิลจะแสดงอย่างไรในแผนภูมิบับเบิล ค่าที่เป็นไปได้คือ **BubbleSizeRepresentationType.AREA** และ **BubbleSizeRepresentationType.WIDTH** ดังนั้น enum **BubbleSizeRepresentationType** จึงถูกเพิ่มเพื่อระบุวิธีการที่เป็นไปได้ในการแสดงข้อมูลเป็นขนาดแผนภูมิบับเบิล ตัวอย่างโค้ดแสดงด้านล่าง  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**รองรับ “แผนภูมิบับเบิลพร้อมเอฟเฟกต์ 3-D” หรือไม่ และมีความแตกต่างจากแบบปกติอย่างไร?**  
ใช่ มีประเภทแผนภูมิแยกออกมาชื่อ “Bubble with 3-D” ซึ่งใส่สไตล์ 3‑D ให้กับบับเบิลแต่ไม่ได้เพิ่มแกนเพิ่มเติม; ข้อมูลยังคงเป็น X‑Y‑S (ขนาด) ประเภทนี้มีใน enumeration ของ [ประเภทแผนภูมิ](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/)

**มีขีดจำกัดจำนวนซีรีส์และจุดในแผนภูมิบับเบิลหรือไม่?**  
ไม่มีขีดจำกัดที่เข้มงวดในระดับ API; ข้อจำกัดขึ้นอยู่กับประสิทธิภาพและเวอร์ชัน PowerPoint เป้าหมาย แนะนำให้จำนวนจุดอยู่ในระดับที่เหมาะสมเพื่อความอ่านง่ายและความเร็วในการเรนเดอร์  

**การส่งออกจะมีผลต่อรูปลักษณ์ของแผนภูมิบับเบิล (PDF, รูปภาพ) อย่างไร?**  
การส่งออกเป็นรูปแบบที่รองรับจะคงรูปลักษณ์ของแผนภูมิไว้; การเรนเดอร์ดำเนินการโดยเอ็นจิ้นของ Aspose.Slides สำหรับรูปแบบ raster หรือ vector จะใช้กฎการเรนเดอร์กราฟิกของแผนภูมิทั่วไป (ความละเอียด, การลดหยัก) ดังนั้นควรเลือก DPI ที่เพียงพอสำหรับการพิมพ์