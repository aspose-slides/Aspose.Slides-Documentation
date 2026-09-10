---
title: ปรับแต่งแผนภูมิบับเบิ้ลในงานนำเสนอด้วย Python
linktitle: แผนภูมิบับเบิ้ล
type: docs
url: /th/python-java/bubble-chart/
keywords:
- แผนภูมิบับเบิ้ล
- ขนาดบับเบิ้ล
- การสเกลขนาด
- การแสดงขนาด
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิบับเบิ้ลที่มีประสิทธิภาพใน PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพื่อเสริมการแสดงผลข้อมูลของคุณอย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีทำงานกับแผนภูมิบับเบิ้ลใน Aspose.Slides ซึ่งครอบคลุมตัวเลือกการปรับแต่งสองอย่าง: การปรับขนาดบับเบิ้ลผ่านเมธอด [setBubbleSizeScale](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) และการควบคุมวิธีการแสดงค่าขนาดบับเบิ้ลผ่านเมธอด [setBubbleSizeRepresentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation)  

ตัวอย่างจะแสดงวิธีสร้างแผนภูมิบับเบิ้ล ปรับการสเกลขนาด และสลับการแสดงขนาดบับเบิ้ลให้ใช้ความกว้าง บทความยังรวมส่วนคำถามที่พบบ่อยสั้น ๆ ที่ชี้แจงการสนับสนุนประเภทแผนภูมิ “Bubble with 3‑D” , กล่าวถึงว่าขีดจำกัดของแผนภูมิในทางปฏิบัติขึ้นอยู่กับประสิทธิภาพและเวอร์ชัน PowerPoint ปลายทาง, และอธิบายว่าการส่งออกจะคงลักษณะของแผนภูมิผ่านเอนจินการเรนเดอร์ของ Aspose.Slides

## **การปรับขนาดแผนภูมิบับเบิ้ล**
Aspose.Slides for Python via Java รองรับการสเกลขนาดแผนภูมิบับเบิ้ลผ่านเมธอด [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) และ [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) ตัวอย่างต่อไปนี้แสดงวิธีสเกลขนาดบับเบิ้ล

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **แสดงข้อมูลเป็นขนาดแผนภูมิบับเบิ้ล**
เมธอด [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) และ [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) มีให้ในคลาส [ChartSeriesGroup](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/) การแสดงขนาดบับเบิ้ลกำหนดว่าค่าขนาดบับเบิ้ลจะแสดงอย่างไรในแผนภูมิบับเบิ้ล ค่าที่เป็นไปได้คือ [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/th/python-java/aspose.slides/bubblesizerepresentationtype/#Area) และ [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/th/python-java/aspose.slides/bubblesizerepresentationtype/#Width) โดย enumeration [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/th/python-java/aspose.slides/bubblesizerepresentationtype/) ระบุวิธีที่เป็นไปได้ในการแสดงข้อมูลเป็นขนาดแผนภูมิบับเบิ้ล ตัวอย่างต่อไปนี้แสดงวิธีแสดงขนาดบับเบิ้ลโดยใช้ความกว้าง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**“bubble chart with 3‑D effect” รองรับหรือไม่ และแตกต่างจากแบบปกติอย่างไร?**

ใช่ มีประเภทแผนภูมิแยกต่างหากคือ “Bubble with 3‑D.” ซึ่งจะใส่สไตล์ 3‑D ให้กับบับเบิ้ลแต่ไม่ได้เพิ่มแกนเพิ่มเติม; ข้อมูลยังคงเป็น X‑Y‑S (ขนาด) ประเภทนี้พร้อมใช้งานในคลาส [chart type](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/)

**มีขีดจำกัดจำนวนซีรีส์และจุดข้อมูลในแผนภูมิบับเบิ้ลหรือไม่?**

ไม่มีขีดจำกัดคงที่ในระดับ API; ข้อจำกัดกำหนดโดยประสิทธิภาพและเวอร์ชัน PowerPoint ปลายทาง แนะนำให้จำนวนจุดอยู่ในระดับที่อ่านง่ายและเรนเดอร์ได้เร็ว

**การส่งออกจะส่งผลต่อการแสดงผลของแผนภูมิบับเบิ้งอย่างไร (PDF, ภาพ)?**

การส่งออกเป็นรูปแบบที่รองรับจะคงลักษณะของแผนภูมิ; การเรนเดอร์ทำโดยเอนจิน Aspose.Slides สำหรับรูปแบบเรสเตอร์/เวคเตอร์จะตามกฎการเรนเดอร์กราฟิกทั่วไป (ความละเอียด, การป้องกันการหยัก) ดังนั้นควรเลือก DPI ที่เพียงพอสำหรับการพิมพ์