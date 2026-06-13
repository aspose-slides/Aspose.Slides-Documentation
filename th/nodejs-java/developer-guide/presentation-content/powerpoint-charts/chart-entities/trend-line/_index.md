---
title: เพิ่มเส้นแนวโน้มไปยังแผนภูมินำเสนอใน JavaScript
linktitle: เส้นแนวโน้ม
type: docs
url: /th/nodejs-java/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มเอ็กซ์โพเนนเชียล
- เส้นแนวโน้มเส้นตรง
- เส้นแนวโน้มลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มพหุนาม
- เส้นแนวโน้มพาวเวอร์
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java — คู่มือเชิงปฏิบัติที่จะช่วยดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่มเส้นแนวโน้มลงในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการสร้างแผนภูมิ, เพิ่มเส้นแนวโน้มให้กับซีรีส์ของแผนภูมิ, และทำงานกับประเภทของเส้นแนวโน้มหลายแบบ รวมถึงเอ็กซ์โพเนนเชียล, เส้นตรง, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, พหุนาม, และพาวเวอร์

นอกจากนี้ยังอธิบายวิธีการเพิ่มเส้นกำหนดเองในแผนภูมิโดยการแทรกรูปร่างเส้น, และมีคำถามที่พบบ่อยสั้นๆ เกี่ยวกับค่าการฉายเส้นแนวโน้มไปข้างหน้าและย้อนกลับ รวมถึงว่าการส่งออกเป็น PDF หรือ SVG หรือการแสดงแผนภูมิเป็นภาพจะรักษาเส้นแนวโน้มไว้หรือไม่

## **เพิ่มเส้นแนวโน้ม**

Aspose.Slides for Node.js via Java มี API ง่ายสำหรับจัดการเส้นแนวโน้มของแผนภูมิต่าง ๆ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ตัวอย่างนี้ใช้ ChartType.ClusteredColumn)
1. เพิ่มเส้นแนวโน้มเอ็กซ์โพเนนเชียลให้กับซีรีส์แผนภูมิที่ 1
1. เพิ่มเส้นแนวโน้มเส้นตรงให้กับซีรีส์แผนภูมิที่ 1
1. เพิ่มเส้นแนวโน้มลอการิทึมให้กับซีรีส์แผนภูมิที่ 2
1. เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่ให้กับซีรีส์แผนภูมิที่ 2
1. เพิ่มเส้นแนวโน้มพหุนามให้กับซีรีส์แผนภูมิที่ 3
1. เพิ่มเส้นแนวโน้มพาวเวอร์ให้กับซีรีส์แผนภูมิที่ 3
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ดต่อไปนี้ใช้เพื่อสร้างแผนภูมิพร้อมเส้นแนวโน้ม

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // สร้างแผนภูมิคอลัมน์แบบกลุ่ม
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // เพิ่มเส้นแนวโน้มเอ็กซ์โพเนนเชียลให้กับซีรีส์แผนภูมิที่ 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // เพิ่มเส้นแนวโน้มเส้นตรงให้กับซีรีส์แผนภูมิที่ 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // เพิ่มเส้นแนวโน้มลอการิทึมให้กับซีรีส์แผนภูมิที่ 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่ให้กับซีรีส์แผนภูมิที่ 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // เพิ่มเส้นแนวโน้มพหุนามให้กับซีรีส์แผนภูมิที่ 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // เพิ่มเส้นแนวโน้มพาวเวอร์ให้กับซีรีส์แผนภูมิที่ 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // บันทึกการนำเสนอ
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่มเส้นแบบกำหนดเอง**

Aspose.Slides for Node.js via Java มี API ง่ายเพื่อเพิ่มเส้นแบบกำหนดเองในแผนภูมิ เพื่อเพิ่มเส้นธรรมดาแบบเรียบง่ายในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- สร้างแผนภูมิใหม่โดยใช้เมธอด AddChart ที่เปิดให้ใช้งานจากอ็อบเจกต์ Shapes
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานจากอ็อบเจกต์ Shapes
- ตั้งค่า Color ของเส้นรูปร่าง
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ดต่อไปนี้ใช้เพื่อสร้างแผนภูมิพร้อมเส้นแบบกำหนดเอง

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**'forward' และ 'backward' มีความหมายอย่างไรสำหรับเส้นแนวโน้ม?**

พวกมันคือตวามยาวของเส้นแนวโน้มที่ฉายไปข้างหน้า/ย้อนกลับ: สำหรับแผนภูมิกระจาย (XY) — หน่วยตามแกน; สำหรับแผนภูมิที่ไม่ใช่กระจาย — จำนวนของหมวดหมู่ เท่านั้นที่ค่าติดลบไม่ได้รับอนุญาต

**เส้นแนวโน้มจะถูกเก็บไว้เมื่อส่งออกการนำเสนอเป็น PDF หรือ SVG หรือเมื่อแสดงสไลด์เป็นภาพหรือไม่?**

ใช่ Aspose.Slides จะแปลงการนำเสนอเป็น [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/th/nodejs-java/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นแนวโน้มในฐานะส่วนหนึ่งของแผนภูมิจะถูกรักษาไว้ในกระบวนการเหล่านี้ มีเมธอดพร้อมใช้งานเพื่อ [export an image of the chart](/slides/th/nodejs-java/create-shape-thumbnails/) ด้วยเช่นกัน