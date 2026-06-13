---
title: ปรับแต่งแผนภูมิก๊อบในงานนำเสนอด้วย JavaScript
linktitle: แผนภูมิก๊อบ
type: docs
url: /th/nodejs-java/bubble-chart/
keywords:
- แผนภูมิก๊อบ
- ขนาดก๊อบ
- การสเกลขนาด
- การแสดงขนาด
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิก๊อบที่ทรงพลังใน PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อเพิ่มประสิทธิภาพการแสดงผลข้อมูลของคุณได้อย่างง่ายดาย."
---
## **Overview**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิกลับใน Aspose.Slides ครอบคลุมสองตัวเลือกการปรับแต่งเฉพาะ: การปรับสเกลขนาดของก๊อบผ่านเมธอด `setBubbleSizeScale` และการควบคุมวิธีการแสดงค่าขนาดของก๊อบผ่านเมธอด `setBubbleSizeRepresentation`

ตัวอย่างจะแสดงวิธีสร้างแผนภูมิกลับ ปรับสเกลขนาด และสลับการแสดงขนาดของก๊อบให้ใช้ความกว้าง บทความยังรวมส่วน FAQ สั้น ๆ ที่อธิบายการสนับสนุนประเภทแผนภูมิ “Bubble with 3‑D” แจ้งว่าขีดจำกัดของแผนภูมิจริง ๆ ขึ้นอยู่กับประสิทธิภาพและเวอร์ชัน PowerPoint ที่เป้าหมาย และอธิบายว่าการส่งออกจะคงลักษณะของแผนภูมิผ่านเครื่องยนต์การเรนเดอร์ของ Aspose.Slides

## **Bubble Chart Size Scaling**
Aspose.Slides for Node.js via Java มีการสนับสนุนการสเกลขนาดของแผนภูมิกลับ ใน Aspose.Slides for Node.js via Java ได้เพิ่มเมธอด [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) และ [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) ตัวอย่างโค้ดตัวอย่างด้านล่าง

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Represent Data as Bubble Chart Sizes**
เมธอด [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) และ [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) ได้ถูกเพิ่มเข้ากับคลาส [ChartSeries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartSeriesGroup) และคลาสที่เกี่ยวข้อง **BubbleSizeRepresentation** ระบุวิธีการที่ค่าขนาดของก๊อบจะแสดงในแผนภูมิกลับ ค่าที่เป็นไปได้คือ: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) และ [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width) ตามนั้น enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BubbleSizeRepresentationType) ถูกเพิ่มเพื่อระบุวิธีการที่เป็นไปได้ในการแสดงข้อมูลเป็นขนาดของแผนภูมิกลับ ตัวอย่างโค้ดแสดงด้านล่าง

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

ใช่ มีประเภทแผนภูมิแยกต่างหากคือ "Bubble with 3-D" ซึ่งใช้สไตล์ 3‑D กับก๊อบแต่ไม่ได้เพิ่มแกนเพิ่มเติม; ข้อมูลยังคงเป็น X‑Y‑S (ขนาด) ประเภทนี้มีอยู่ใน enumeration ของ [chart type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/)

**Is there a limit on the number of series and points in a bubble chart?**

ไม่มีขีดจำกัดที่เข้มงวดในระดับ API; ข้อจำกัดถูกกำหนดโดยประสิทธิภาพและเวอร์ชัน PowerPoint ที่เป้าหมาย แนะนำให้จำนวนจุดอยู่ในระดับที่สมเหตุสมผลเพื่อการอ่านและความเร็วการเรนเดอร์

**How will export affect the appearance of a bubble chart (PDF, images)?**

การส่งออกเป็นฟอร์แมตที่สนับสนุนจะคงลักษณะของแผนภูมิ; การเรนเดอร์ทำโดยเครื่องยนต์ Aspose.Slides สำหรับฟอร์แมตราสเตอร์/เวกเตอร์ จะใช้กฎการเรนเดอร์กราฟิกของแผนภูมิทั่วไป (ความละเอียด, การทำ anti‑aliasing) ดังนั้นควรเลือก DPI ที่เพียงพอสำหรับการพิมพ์