---
title: ปรับแต่งพื้นที่พล็อตของแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: พื้นที่พล็อต
type: docs
url: /th/nodejs-java/chart-plot-area/
keywords:
- แผนภูมิ
- พื้นที่พล็อต
- ความกว้างพื้นที่พล็อต
- ความสูงพื้นที่พล็อต
- ขนาดพื้นที่พล็อต
- โหมดการจัดวาง
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบวิธีการปรับแต่งพื้นที่พล็อตของแผนภูมิในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ปรับปรุงภาพสไลด์ของคุณได้อย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีทำงานกับพื้นที่พล็อตของแผนภูมิใน Aspose.Slides โดยอธิบายวิธีรับตำแหน่งและขนาดจริงของพื้นที่พล็อตโดยการตรวจสอบการจัดวางแผนภูมิและจากนั้นอ่านค่า X, Y, ความกว้าง และความสูงของมัน

นอกจากนี้ยังสาธิตวิธีกำหนดโหมดการจัดวางของพื้นที่พล็อตเมื่อการจัดวางถูกตั้งค่าแบบแมนนวล โดยใช้ `LayoutTargetType` เพื่อระบุว่าพื้นที่พล็อตจะคำนวณจากบริเวณภายในหรือจากบริเวณภายนอกรวมกับแกนและป้ายแกน

## **รับความกว้าง, ความสูงของพื้นที่พล็อตแผนภูมิ**

Aspose.Slides for Node.js via Java มี API ที่ง่ายสำหรับ . 

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
4. เรียกเมธอด[Chart.validateChartLayout()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Chart#validateChartLayout--)ก่อนเพื่อรับค่าจริง
5. รับตำแหน่ง X จริง (ซ้าย) ขององค์ประกอบแผนภูมิกับมุมซ้ายบนของแผนภูมิ
6. รับตำแหน่งบนจริงขององค์ประกอบแผนภูมิกับมุมซ้ายบนของแผนภูมิ
7. รับความกว้างจริงขององค์ประกอบแผนภูมิ
8. รับความสูงจริงขององค์ประกอบแผนภูมิ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **กำหนดโหมดการจัดวางของพื้นที่พล็อตแผนภูมิ**

Aspose.Slides for Node.js via Java มี API ที่ง่ายสำหรับกำหนดโหมดการจัดวางของพื้นที่พล็อตแผนภูมิ เมธอด[**setLayoutTargetType**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-)และ[**getLayoutTargetType**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--)ได้ถูกเพิ่มในคลาส[**ChartPlotArea**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartPlotArea) หากการจัดวางของพื้นที่พล็อตถูกกำหนดแบบแมนนวล คุณสมบัตินี้ระบุว่าจะจัดวางพื้นที่พล็อตโดยส่วนภายใน (ไม่รวมแกนและป้ายแกน) หรือส่วนภายนอก (รวมแกนและป้ายแกน) มีค่าที่เป็นไปได้สองค่า ซึ่งกำหนดใน enum[**LayoutTargetType**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LayoutTargetType)

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LayoutTargetType#Inner) - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อตโดยไม่รวมเครื่องหมายติ๊กและป้ายแกน
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LayoutTargetType#Outer) - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อตรวมกับเครื่องหมายติ๊กและป้ายแกน

โค้ดตัวอย่างได้แสดงไว้ด้านล่าง

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**หน่วยที่ค่าจริงของ X, Y, ความกว้างและความสูงถูกส่งกลับเป็นอะไร?**

เป็นพอยต์; 1 นิ้ว = 72 พอยต์ ซึ่งเป็นหน่วยพิกัดของ Aspose.Slides

**พื้นที่พล็อตแตกต่างจากพื้นที่แผนภูมิในแง่ของเนื้อหาอย่างไร?**

พื้นที่พล็อตเป็นบริเวณการวาดข้อมูล (ซีรีส์, เส้นกริด, เส้นแนวโน้ม ฯลฯ) ส่วนพื้นที่แผนภูมิมีองค์ประกอบรอบ ๆ (หัวเรื่อง, คำอธิบาย, ฯลฯ) ในแผนภูมิ 3D พื้นที่พล็อตยังรวมถึงผนัง/พื้นและแกนด้วย

**ค่า X, Y, ความกว้างและความสูงของพื้นที่พล็อตถูกตีความอย่างไรเมื่อการจัดวางเป็นแบบแมนนวล?**

ค่าจะเป็นส่วนของ (0–1) ของขนาดโดยรวมของแผนภูมิ; ในโหมดนี้การจัดตำแหน่งอัตโนมัติจะถูกปิดและใช้ส่วนที่คุณตั้งค่า

**ทำไมตำแหน่งของพื้นที่พล็อตจึงเปลี่ยนหลังจากเพิ่ม/ย้ายคำอธิบาย?**

คำอธิบายอยู่ในพื้นที่แผนภูมิด้านนอกของพื้นที่พล็อตแต่มีผลต่อการจัดวางและพื้นที่ว่างที่ใช้ได้ จึงทำให้พื้นที่พล็อตอาจย้ายเมื่อมีการจัดตำแหน่งอัตโนมัติ (นี่เป็นพฤติกรรมมาตรฐานของแผนภูมิ PowerPoint)