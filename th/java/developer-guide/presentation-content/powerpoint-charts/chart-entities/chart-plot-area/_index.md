---
title: ปรับแต่งพื้นที่พล็อตของแผนภูมิการนำเสนอใน Java
linktitle: พื้นที่พล็อต
type: docs
url: /th/java/chart-plot-area/
keywords:
- แผนภูมิ
- พื้นที่พล็อต
- ความกว้างพื้นที่พล็อต
- ความสูงพื้นที่พล็อต
- ขนาดพื้นที่พล็อต
- โหมดการจัดวาง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีปรับแต่งพื้นที่พล็อตของแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java เพื่อปรับปรุงภาพสไลด์ของคุณอย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีทำงานกับพื้นที่พล็อตของแผนภูมิใน Aspose.Slides โดยอธิบายวิธีการรับตำแหน่งและขนาดจริงของพื้นที่พล็อตโดยการตรวจสอบเค้าโครงของแผนภูมิและจากนั้นอ่านค่าพิกัด X, Y, ความกว้างและความสูง

นอกจากนี้ยังแสดงวิธีกำหนดโหมดการจัดวางของพื้นที่พล็อตเมื่อจัดวางด้วยตนเอง โดยใช้ `LayoutTargetType` เพื่อกำหนดว่าพื้นที่พล็อตจะคำนวณจากบริเวณภายในหรือจากบริเวณภายนอกพร้อมกับแกนและป้ายแกน

## **รับความกว้างและความสูงของพื้นที่พล็อตในแผนภูมิ**
Aspose.Slides for Java มี API ที่เรียบง่ายสำหรับ .

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิด้วยข้อมูลค่าเริ่มต้น
4. เรียกเมธอด[IChart.validateChartLayout()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChart#validateChartLayout--) ก่อนเพื่อรับค่าจริง
5. รับตำแหน่ง X จริง (ซ้าย) ขององค์ประกอบแผนภูมิสัมพันธ์กับมุมซ้ายบนของแผนภูมิ
6. รับตำแหน่งด้านบนจริงขององค์ประกอบแผนภูมิสัมพันธ์กับมุมซ้ายบนของแผนภูมิ
7. รับความกว้างจริงขององค์ประกอบแผนภูมิ
8. รับความสูงจริงขององค์ประกอบแผนภูมิ

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **กำหนดโหมดการจัดวางของพื้นที่พล็อตในแผนภูมิ**
Aspose.Slides for Java มี API ที่เรียบง่ายสำหรับกำหนดโหมดการจัดวางของพื้นที่พล็อตในแผนภูมิ เมธอด[**setLayoutTargetType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-)และ[**getLayoutTargetType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--)ได้ถูกเพิ่มในคลาส[**ChartPlotArea**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartPlotArea)และอินเตอร์เฟส[**IChartPlotArea**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartPlotArea) หากการจัดวางพื้นที่พล็อตถูกกำหนดด้วยตนเอง คุณสมบัตินี้ระบุว่าจะจัดวางพื้นที่พล็อตโดยใช้ภายใน (ไม่รวมแกนและป้ายแกน) หรือโดยใช้ภายนอก (รวมแกนและป้ายแกน) มีค่าที่เป็นไปได้สองค่า ซึ่งกำหนดใน enum[**LayoutTargetType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/LayoutTargetType)

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/th/java/com.aspose.slides/LayoutTargetType#Inner) - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อตเองโดยไม่รวมเครื่องหมายติ๊กและป้ายแกน
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/th/java/com.aspose.slides/LayoutTargetType#Outer) - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อต, เครื่องหมายติ๊ก, และป้ายแกน

ตัวอย่างโค้ดด้านล่าง

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ค่าพิกัด x, y, ความกว้างและความสูงจริงถูกส่งกลับในหน่วยอะไร?**  
เป็นหน่วยพอยต์; 1 นิ้ว = 72 พอยต์ นี่คือหน่วยพิกัดของ Aspose.Slides

**พื้นที่พล็อตแตกต่างจากพื้นที่แผนภูมิในแง่ของเนื้อหาอย่างไร?**  
พื้นที่พล็อตคือบริเวณการวาดข้อมูล (ชุดข้อมูล, เส้นกริด, เส้นแนวโน้ม เป็นต้น) ส่วนพื้นที่แผนภูมรรวมถึงองค์ประกอบรอบข้าง (หัวข้อ, ตารางอธิบาย, เป็นต้น) ในแผนภูมิ 3 มิติ พื้นที่พล็อตยังรวมถึงผนัง/พื้นและแกนด้วย

**พิกัด x, y, ความกว้างและความสูงของพื้นที่พล็อตถูกตีความอย่างไรเมื่อการจัดวางเป็นแบบกำหนดเอง?**  
พวกมันเป็นส่วนเศษ (0–1) ของขนาดโดยรวมของแผนภูมิ; ในโหมดนี้ การตั้งตำแหน่งอัตโนมัติจะปิดและจะใช้ส่วนเศษที่คุณกำหนด

**ทำไมตำแหน่งของพื้นที่พล็อตจึงเปลี่ยนหลังจากเพิ่ม/ย้ายตารางอธิบาย?**  
ตารางอธิบายอยู่ในพื้นที่แผนภูมิอยู่นอกพื้นที่พล็อต แต่มีผลต่อการจัดวางและพื้นที่ที่ใช้ได้ ดังนั้นพื้นที่พล็อตอาจย้ายเมื่อการตั้งตำแหน่งอัตโนมัติมีผล (นี่เป็นพฤติกรรมมาตรฐานของแผนภูมิ PowerPoint)