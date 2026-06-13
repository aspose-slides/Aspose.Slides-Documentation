---
title: ปรับแต่งแผนภูมิบับเบิลในการนำเสนอบน Android
linktitle: แผนภูมิบับเบิล
type: docs
url: /th/androidjava/bubble-chart/
keywords:
- แผนภูมิบับเบิล
- ขนาดบับเบิล
- การสเกลขนาด
- การแสดงผลขนาด
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิบับเบิลที่ทรงพลังใน PowerPoint ด้วย Aspose.Slides for Android via Java เพื่อเพิ่มประสิทธิภาพการแสดงผลข้อมูลของคุณอย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีทำงานกับแผนภูมิบับเบิลใน Aspose.Slides. มันครอบคลุมสองตัวเลือกการปรับแต่งเฉพาะ: การปรับขนาดบับเบิลผ่านเมธอด `setBubbleSizeScale` และการควบคุมว่าค่าขนาดบับเบิลแสดงผลอย่างไรผ่านเมธอด `setBubbleSizeRepresentation`.

ตัวอย่างแสดงวิธีสร้างแผนภูมิบับเบิล ปรับการสเกลขนาด และสลับการแสดงผลขนาดบับเบิลให้ใช้ความกว้าง บทความยังรวมส่วน **FAQ** สั้น ๆ ที่อธิบายการสนับสนุนประเภทแผนภูมิ “Bubble with 3-D”, ระบุว่าขีดจำกัดของแผนภูมิในทางปฏิบัติกับประสิทธิภาพและเวอร์ชัน PowerPoint ที่เป้าหมาย, และอธิบายว่าการส่งออกจะรักษาลักษณะของแผนภูมิผ่านเอนจินการเรนเดอร์ของ Aspose.Slides.

## **การสเกลขนาดแผนภูมิบับเบิล**

Aspose.Slides for Android via Java ให้การสนับสนุนการสเกลขนาดแผนภูมิบับเบิล ใน Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) และเมธอด [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) ถูกเพิ่มเข้ามา ตัวอย่างโค้ดด้านล่างแสดงให้เห็น.

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

เมธอด [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) และ [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) ได้ถูกเพิ่มไปยังอินเทอร์เฟซ [IChartSeries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartSeriesGroup) และคลาสที่เกี่ยวข้อง **BubbleSizeRepresentation** กำหนดว่าค่าขนาดบับเบิลจะแสดงผลอย่างไรในแผนภูมิบับเบิล ค่าที่เป็นไปได้คือ: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) และ [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width) ตามนั้น enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/BubbleSizeRepresentationType) ถูกเพิ่มเพื่อระบุวิธีที่เป็นไปได้ในการแสดงข้อมูลเป็นขนาดแผนภูมิบับเบิล ตัวอย่างโค้ดแสดงด้านล่าง.

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

**รองรับ “แผนภูมิบับเบิลพร้อมเอฟเฟ็กต์ 3 มิติ” หรือไม่ และต่างจากแผนภูมิปกติอย่างไร?**

ใช่ มีประเภทแผนภูมิเฉพาะ “Bubble with 3-D” ซึ่งใช้สไตล์ 3 มิติบนบับเบิลแต่ไม่เพิ่มแกนเพิ่มเติม; ข้อมูลยังคงเป็น X‑Y‑S (ขนาด) ประเภทนี้มีให้ในคลาส [chart type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/).

**มีข้อจำกัดจำนวนซีรีส์และจุดในแผนภูมิบับเบิลหรือไม่?**

ไม่มีขีดจำกัดที่ชัดเจนในระดับ API; ข้อจำกัดจะขึ้นอยู่กับประสิทธิภาพและเวอร์ชัน PowerPoint เป้าหมาย แนะนำให้จำนวนจุดอยู่ในระดับสมเหตุสมผลเพื่อความอ่านง่ายและความเร็วในการเรนเดอร์.

**การส่งออกจะส่งผลต่อลักษณะของแผนภูมิบับเบิล (PDF, รูปภาพ) อย่างไร?**

การส่งออกไปยังรูปแบบที่รองรับจะรักษาลักษณะของแผนภูมิไว้; การเรนเดอร์ทำโดยเอนจินของ Aspose.Slides สำหรับรูปแบบเรสเตอร์/เวกเตอร์ จะใช้กฎการเรนเดอร์กราฟิกของแผนภูมิทั่วไป (ความละเอียด, การทำ anti‑aliasing) ดังนั้นควรเลือก DPI ที่เพียงพอสำหรับการพิมพ์.