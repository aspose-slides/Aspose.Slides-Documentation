---
title: ปรับแต่งแผนภูมิบับเบิลในงานนำเสนอด้วย Java
linktitle: แผนภูมิบับเบิล
type: docs
url: /th/java/bubble-chart/
keywords:
- แผนภูมิบับเบิล
- ขนาดบับเบิล
- การปรับสเกลขนาด
- การแสดงผลขนาด
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิบับเบิลที่มีประสิทธิภาพใน PowerPoint ด้วย Aspose.Slides สำหรับ Java เพื่อเพิ่มประสิทธิภาพการแสดงข้อมูลของคุณได้อย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิบับเบิลใน Aspose.Slides โดยครอบคลุมสองตัวเลือกการปรับแต่งเฉพาะ: การปรับขนาดบับเบิลผ่านเมธอด `setBubbleSizeScale` และการควบคุมวิธีการแสดงค่า​ขนาดบับเบิลผ่านเมธอด `setBubbleSizeRepresentation` ตัวอย่างแสดงวิธีการสร้างแผนภูมิบับเบิล ปรับสเกลขนาด และสลับการแสดงขนาดบับเบิลให้ใช้ความกว้าง บทความยังรวมส่วนคำถามที่พบบ่อยสั้น ๆ เพื่อชี้แจงการสนับสนุนประเภทแผนภูมิ “Bubble with 3‑D” การจำกัดแผนภูมิในเชิงปฏิบัติมาจากประสิทธิภาพและเวอร์ชัน PowerPoint เป้าหมาย และอธิบายว่าการส่งออกจะคงลักษณะของแผนภูมิผ่านเอนจินการเรนเดอร์ของ Aspose.Slides

## **การปรับขนาดแผนภูมิบับเบิล**
Aspose.Slides for Java ให้การสนับสนุนการปรับขนาดแผนภูมิบับเบิล ใน Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--) [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) และ [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) เมธอดเหล่านี้ได้เพิ่มเข้ามา ตัวอย่างโค้ดด้านล่างนี้

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **แสดงข้อมูลเป็นขนาดแผนภูมิบับเบิล**
เมธอด [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) และ [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) ได้เพิ่มเข้าไปในอินเทอร์เฟซ [IChartSeries](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeries) และ [IChartSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartSeriesGroup) รวมถึงคลาสที่เกี่ยวข้อง **BubbleSizeRepresentation** ระบุวิธีการแสดงค่าขนาดบับเบิลในแผนภูมิบับเบิล ค่าที่เป็นไปได้คือ [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/th/java/com.aspose.slides/BubbleSizeRepresentationType#Area) และ [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/th/java/com.aspose.slides/BubbleSizeRepresentationType#Width) ตามนั้น [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/BubbleSizeRepresentationType) enum ได้เพิ่มเข้ามาเพื่อระบุวิธีการต่าง ๆ ที่จะนำข้อมูลไปแสดงเป็นขนาดบับเบิล ตัวอย่างโค้ดด้านล่างนี้

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**“แผนภูมิบับเบิลพร้อมเอฟเฟกต์ 3‑D” ได้รับการสนับสนุนหรือไม่ และแตกต่างจากแผนภูมิปกติอย่างไร?**

ใช่ มีประเภทแผนภูมิเฉพาะ “Bubble with 3‑D” ซึ่งนำสไตล์ 3‑D ไปใช้กับบับเบิลโดยไม่เพิ่มแกนเพิ่มเติม; ข้อมูลยังคงเป็น X‑Y‑S (ขนาด) ประเภทนี้สามารถเลือกได้ในคลาส [chart type](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/)

**มีขีดจำกัดจำนวน Series และ Point ในแผนภูมิบับเบิลหรือไม่?**

ไม่มีขีดจำกัดคงที่ในระดับ API; ข้อจำกัดขึ้นกับประสิทธิภาพและเวอร์ชัน PowerPoint เป้าหมาย ควรรักษาจำนวน Point ให้เหมาะสมเพื่อความอ่านง่ายและความเร็วในการเรนเดอร์

**การส่งออกจะมีผลต่อการแสดงผลของแผนภูมิบับเบิล (PDF, รูปภาพ) อย่างไร?**

การส่งออกไปยังรูปแบบที่รองรับจะคงลักษณะของแผนภูมิ; การเรนเดอร์ดำเนินการโดยเอนจินของ Aspose.Slides สำหรับรูปแบบเรสเตอร์/เวกเตอร์ กฎการเรนเดอร์กราฟิกของแผนภูมิทั่วไปจะนำไปใช้ (ความละเอียด, การตัดขอบราบ) ดังนั้นควรเลือก DPI ที่เพียงพอสำหรับการพิมพ์