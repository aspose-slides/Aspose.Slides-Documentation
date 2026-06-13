---
title: เพิ่มเส้นแนวโน้มลงในแผนภูมิการนำเสนอใน Java
linktitle: เส้นแนวโน้ม
type: docs
url: /th/java/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มเอ็กซ์โปเนนเชียล
- เส้นแนวโน้มลิเนียร์
- เส้นแนวโน้มลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มโพลีโนเมียล
- เส้นแนวโน้มพาวเวอร์
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for Java — คำแนะนำเชิงปฏิบัติเพื่อดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่มเส้นแนวโน้มลงในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides แสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ, และทำงานกับประเภทเส้นแนวโน้มหลายประเภท ได้แก่ เอ็กซ์โปเนนเชียล, ลิเนียร์, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, โพลีโนเมียล, และ พาวเวอร์

นอกจากนี้ยังอธิบายวิธีการเพิ่มเส้นกำหนดเองลงในแผนภูมิโดยแทรกรูปทรงเส้น และรวมคำถามที่พบบ่อยสั้น ๆ เกี่ยวกับค่าการฉายแนวโน้มไปข้างหน้าและย้อนกลับ และว่าเส้นแนวโน้มจะถูกเก็บไว้หรือไม่เมื่อส่งออกเป็น PDF หรือ SVG และเมื่อลากแผนภูมิเป็นภาพ

## **เพิ่มเส้นแนวโน้ม**
Aspose.Slides for Java ให้ API ที่ง่ายสำหรับการจัดการ Trend Lines ของแผนภูมิต่าง ๆ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ตัวอย่างนี้ใช้ ChartType.ClusteredColumn)
4. เพิ่มเส้นแนวโน้มเอ็กซ์โปเนนเชียลสำหรับซีรีส์แผนภูมิที่ 1
5. เพิ่มเส้นแนวโน้มลิเนียร์สำหรับซีรีส์แผนภูมิที่ 1
6. เพิ่มเส้นแนวโน้มลอการิทึมสำหรับซีรีส์แผนภูมิที่ 2
7. เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่สำหรับซีรีส์แผนภูมิที่ 2
8. เพิ่มเส้นแนวโน้มโพลีโนเมียลสำหรับซีรีส์แผนภูมิที่ 3
9. เพิ่มเส้นแนวโน้มพาวเวอร์สำหรับซีรีส์แผนภูมิที่ 3
10. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สร้างแผนภูมิจัดกลุ่มคอลัมน์
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // เพิ่มเส้นแนวโน้มเอ็กซ์โปเนนเชียลสำหรับซีรีส์แผนภูมิที่ 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // เพิ่มเส้นแนวโน้มลิเนียร์สำหรับซีรีส์แผนภูมิที่ 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // เพิ่มเส้นแนวโน้มลอการิทึมสำหรับซีรีส์แผนภูมิที่ 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่สำหรับซีรีส์แผนภูมิที่ 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // เพิ่มเส้นแนวโน้มโพลีโนเมียลสำหรับซีรีส์แผนภูมิที่ 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // เพิ่มเส้นแนวโน้มพาวเวอร์สำหรับซีรีส์แผนภูมิที่ 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // บันทึกการนำเสนอ
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มเส้นกำหนดเอง**
Aspose.Slides for Java ให้ API ที่ง่ายสำหรับการเพิ่มเส้นกำหนดเองในแผนภูมิ เพื่อเพิ่มเส้นธรรมดาอย่างง่ายในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- สร้างแผนภูมิใหม่โดยใช้เมธอด AddChart ที่เปิดให้ใช้งานโดยออบเจ็กต์ Shapes
- เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานโดยออบเจ็กต์ Shapes
- ตั้งค่าสีของเส้นรูปทรง
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**'forward' และ 'backward' มีความหมายอย่างไรสำหรับเส้นแนวโน้ม?**

พวกมันคือความยาวของเส้นแนวโน้มที่ฉายไปข้างหน้า/ย้อนกลับ: สำหรับแผนภูมิแบบกระจาย (XY) — เป็นหน่วยของแกน; สำหรับแผนภูมิที่ไม่ใช่แบบกระจาย — เป็นจำนวนของหมวดหมู่. ค่าที่อนุญาตต้องเป็นค่าที่ไม่เป็นลบเท่านั้น.

**เส้นแนวโน้มจะถูกเก็บไว้เมื่อส่งออกการนำเสนอเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์สไลด์เป็นภาพหรือไม่?**

ใช่. Aspose.Slides แปลงการนำเสนอเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/)/[SVG](/slides/th/java/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นแนวโน้มในฐานะส่วนหนึ่งของแผนภูมิจะถูกเก็บไว้ในระหว่างการดำเนินการเหล่านี้ นอกจากนี้ยังมีเมธอดที่ให้ [ส่งออกภาพของแผนภูมิ](/slides/th/java/create-shape-thumbnails/) ด้วย