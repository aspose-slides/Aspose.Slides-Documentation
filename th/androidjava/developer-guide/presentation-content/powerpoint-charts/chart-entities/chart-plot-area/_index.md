---
title: ปรับแต่งพื้นที่พล็อตของแผนภูมิการนำเสนอบน Android
linktitle: พื้นที่พล็อต
type: docs
url: /th/androidjava/chart-plot-area/
keywords:
- แผนภูมิ
- พื้นที่พล็อต
- ความกว้างของพื้นที่พล็อต
- ความสูงของพื้นที่พล็อต
- ขนาดของพื้นที่พล็อต
- โหมดการจัดวาง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีปรับแต่งพื้นที่พล็อตของแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ปรับปรุงภาพสไลด์ของคุณได้อย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับพื้นที่พล็อตของแผนภูมิใน Aspose.Slides โดยอธิบายวิธีการรับตำแหน่งและขนาดจริงของพื้นที่พล็อตโดยการตรวจสอบการจัดวางของแผนภูมิและจากนั้นอ่านค่า X, Y, ความกว้าง และความสูงของมัน.

นอกจากนี้ยังสาธิตวิธีการกำหนดโหมดการจัดวางของพื้นที่พล็อตเมื่อการจัดวางถูกตั้งค่าแบบกำหนดเอง โดยใช้ `LayoutTargetType` เพื่อกำหนดว่าพื้นที่พล็อตจะคำนวณจากพื้นที่ภายในหรือจากพื้นที่ภายนอกพร้อมกับแกนและป้ายแกน.

## **รับความกว้างและความสูงของพื้นที่พล็อตของแผนภูมิ**
Aspose.Slides สำหรับ Android ผ่าน Java มี API ที่เรียบง่ายสำหรับ . 

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
4. เรียกเมธอด[IChart.validateChartLayout()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChart#validateChartLayout--) ก่อนเพื่อรับค่าจริง
5. รับตำแหน่ง X จริง (ซ้าย) ขององค์ประกอบแผนภูมิเพื่อเทียบกับมุมซ้ายบนของแผนภูมิ
6. รับตำแหน่งบนจริงขององค์ประกอบแผนภูมิเพื่อเทียบกับมุมซ้ายบนของแผนภูมิ
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

## **ตั้งค่าโหมดการจัดวางของพื้นที่พล็อตแผนภูมิ**
Aspose.Slides สำหรับ Android ผ่าน Java มี API ที่เรียบง่ายเพื่อกำหนดโหมดการจัดวางของพื้นที่พล็อตแผนภูมิ เมธอด[**setLayoutTargetType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-)และ[**getLayoutTargetType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--)ได้ถูกเพิ่มลงในคลาส[**ChartPlotArea**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartPlotArea)และอินเทอร์เฟซ[**IChartPlotArea**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartPlotArea) หากการจัดวางของพื้นที่พล็อตถูกกำหนดด้วยตนเอง คุณสมบัตินี้จะระบุว่าจัดวางพื้นที่พล็อตโดยส่วนภายใน (ไม่รวมแกนและป้ายแกน) หรือส่วนภายนอก (รวมแกนและป้ายแกน) มีสองค่าเป็นไปได้ที่ถูกกำหนดใน enum[**LayoutTargetType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LayoutTargetType#Inner) - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อตโดยไม่รวมเครื่องหมายทิกและป้ายแกน
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LayoutTargetType#Outer) - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อต รวมถึงเครื่องหมายทิกและป้ายแกน

ตัวอย่างโค้ดมีดังต่อไปนี้.

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

**หน่วยที่ใช้สำหรับค่าจริงของ x, y, ความกว้างและความสูงที่คืนค่าคืออะไร?**

เป็นหน่วยพอยต์; 1 นิ้ว = 72 พอยต์ ซึ่งเป็นหน่วยพิกัดของ Aspose.Slides.

**พื้นที่พล็อตต่างจากพื้นที่แผนภูมิอย่างไรในแง่ของเนื้อหา?**

พื้นที่พล็อตเป็นบริเวณการวาดข้อมูล (ชุดข้อมูล, เส้นกริด, เส้นแนวโน้ม ฯลฯ) ส่วนพื้นที่แผนภูมิมีองค์ประกอบรอบข้าง (หัวเรื่อง, ลิเบรนด์ ฯลฯ) ในแผนภูมิ 3 มิติ พื้นที่พล็อตยังรวมถึงผนัง/พื้นและแกนด้วย.

**ค่าของ x, y, ความกว้างและความสูงของพื้นที่พล็อตถูกตีความอย่างไรเมื่อการจัดวางเป็นแบบกำหนดเอง?**

ค่าดังกล่าวเป็นส่วนเศษ (0–1) ของขนาดโดยรวมของแผนภูมิ; ในโหมดนี้ การจัดตำแหน่งอัตโนมัติจะถูกปิดและใช้ส่วนเศษที่คุณกำหนด.

**ทำไมตำแหน่งของพื้นที่พล็อตถึงเปลี่ยนหลังจากเพิ่ม/ย้ายลิเบรนด์?**

ลิเบรนด์อยู่ในพื้นที่แผนภูมิที่อยู่นอกพื้นที่พล็อตแต่มีผลต่อการจัดวางและพื้นที่ที่ใช้ได้ ดังนั้นพื้นที่พล็อตอาจย้ายตำแหน่งเมื่อมีการจัดตำแหน่งอัตโนมัติ (นี่เป็นพฤติกรรมมาตรฐานของแผนภูมิ PowerPoint).