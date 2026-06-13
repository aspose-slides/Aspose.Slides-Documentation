---
title: เพิ่มเส้นแนวโน้มในแผนภูมินำเสนอบน Android
linktitle: เส้นแนวโน้ม
type: docs
url: /th/androidjava/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มเชิงเอ็กซ์โปเนนเชียล
- เส้นแนวโน้มเชิงเส้น
- เส้นแนวโน้มลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มพหุนาม
- เส้นแนวโน้มกำลัง
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Android ผ่าน Java — คู่มือเชิงปฏิบัติในการดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีเพิ่มเส้นแนวโน้มลงในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides มันแสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นแนวโน้มให้กับซีรีส์ของแผนภูมิ, และทำงานกับหลายประเภทของเส้นแนวโน้ม รวมถึงเชิงเอ็กซ์โปเนนเชียล, เชิงเส้น, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, พหุนาม, และกำลัง

นอกจากนี้ยังอธิบายวิธีเพิ่มเส้นกำหนดเองลงในแผนภูมิโดยการแทรกรูปร่างเส้น, และรวมคำถามที่พบบ่อยสั้น ๆ เกี่ยวกับค่าการฉายเส้นแนวโน้มไปข้างหน้าและถอยหลังและว่าเส้นแนวโน้มจะถูกเก็บไว้หรือไม่เมื่อส่งออกเป็น PDF หรือ SVG และเมื่อเรนเดอร์แผนภูมิเป็นภาพ

## **เพิ่มเส้นแนวโน้ม**
Aspose.Slides for Android via Java มี API อย่างง่ายสำหรับจัดการเส้นแนวโน้มของแผนภูมิประเภทต่าง ๆ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ตัวอย่างนี้ใช้ ChartType.ClusteredColumn).
4. เพิ่มเส้นแนวโน้มเชิงเอ็กซ์โปเนนเชียลให้กับซีรีส์แผนภูมิที่ 1.
5. เพิ่มเส้นแนวโน้มเชิงเส้นให้กับซีรีส์แผนภูมิที่ 1.
6. เพิ่มเส้นแนวโน้มลอการิทึมให้กับซีรีส์แผนภูมิที่ 2.
7. เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่ให้กับซีรีส์แผนภูมิที่ 2.
8. เพิ่มเส้นแนวโน้มพหุนามให้กับซีรีส์แผนภูมิที่ 3.
9. เพิ่มเส้นแนวโน้มกำลังให้กับซีรีส์แผนภูมิที่ 3.
10. เขียนการนำเสนอที่แก้ไขแล้วลงในไฟล์ PPTX.

โค้ดต่อไปนี้ใช้ในการสร้างแผนภูมิพร้อมเส้นแนวโน้ม.

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สร้างแผนภูมิคอลัมน์แบบจัดกลุ่ม
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // เพิ่มเส้นแนวโน้มเชิงเอ็กซ์โปเนนเชียลให้กับซีรีส์แผนภูมิที่ 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // เพิ่มเส้นแนวโน้มเชิงเส้นให้กับซีรีส์แผนภูมิที่ 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // เพิ่มเส้นแนวโน้มลอการิทึมให้กับซีรีส์แผนภูมิที่ 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่ให้กับซีรีส์แผนภูมิที่ 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // เพิ่มเส้นแนวโน้มพหุนามให้กับซีรีส์แผนภูมิที่ 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // เพิ่มเส้นแนวโน้มกำลังให้กับซีรีส์แผนภูมิที่ 3
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
Aspose.Slides for Android via Java มี API อย่างง่ายเพื่อเพิ่มเส้นกำหนดเองในแผนภูมิ สำหรับการเพิ่มเส้นธรรมดาแบบเรียบง่ายในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- สร้างแผนภูมิใหม่โดยใช้เมธอด AddChart ที่เปิดให้ใช้งานจากอ็อบเจ็กต์ Shapes
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานจากอ็อบเจ็กต์ Shapes
- กำหนดสีของเส้นรูปร่าง
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ดต่อไปนี้ใช้ในการสร้างแผนภูมิพร้อมเส้นกำหนดเอง.

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

## **คำถามที่พบบ่อย**

**'forward' และ 'backward' หมายถึงอะไรสำหรับเส้นแนวโน้ม?**

พวกมันคือความยาวของเส้นแนวโน้มที่ถูกฉายไปข้างหน้า/ถอยหลัง: สำหรับแผนภูมิกระจาย (XY) — ตามหน่วยของแกน; สำหรับแผนภูมิที่ไม่ใช่กระจาย — ตามจำนวนหมวดหมู่ ค่าที่เป็นลบไม่ได้รับอนุญาต.

**เส้นแนวโน้มจะถูกเก็บไว้เมื่อส่งออกการนำเสนอเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์สไลด์เป็นภาพหรือไม่?**

ใช่. Aspose.Slides แปลงการนำเสนอเป็น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/th/androidjava/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นแนวโน้มในฐานะส่วนของแผนภูมิจึงถูกเก็บไว้ในกระบวนการเหล่านี้ อีกทั้งยังมีเมธอดสำหรับ [export an image of the chart](/slides/th/androidjava/create-shape-thumbnails/) ด้วย.