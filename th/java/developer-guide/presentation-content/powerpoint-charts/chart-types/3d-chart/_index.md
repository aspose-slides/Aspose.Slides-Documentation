---
title: ปรับแต่งแผนภูมิ 3 มิติในงานนำเสนอโดยใช้ Java
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/java/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides สำหรับ Java ด้วยการสนับสนุนไฟล์ PPT และ PPTX — เพิ่มประสิทธิภาพงานนำเสนอของคุณวันนี้."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides โดยการกำหนดค่าการตั้งค่า `Rotation3D` เช่น `RotationX`, `RotationY`, `DepthPercents` และ `RightAngleAxes` รายละเอียดจะพาคุณผ่านขั้นตอนการสร้างงานนำเสนอ, เพิ่มแผนภูมิ 3 มิติด้วยข้อมูลเริ่มต้น, ใช้การตั้งค่า 3 มิติที่จำเป็น, และบันทึกงานนำเสนอที่ปรับแต่งแล้วเป็นไฟล์ PPTX

## **ตั้งค่า RotationX, RotationY และคุณสมบัติ DepthPercents ของแผนภูมิ 3 มิติ**
Aspose.Slides for Java มี API ที่เรียบง่ายสำหรับการตั้งค่าคุณสมบัติเหล่านี้ บทความต่อไปนี้จะช่วยคุณตั้งค่าต่าง ๆ เช่น **X,Y Rotation, DepthPercents** เป็นต้น ตัวอย่างโค้ดจะทำการตั้งค่าคุณสมบัติเฉพาะที่กล่าวถึงด้านบน

1. สร้างอินสแตนซ์ของคลาส [การนำเสนอ](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรก  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น  
4. ตั้งค่าคุณสมบัติ Rotation3D  
5. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

```java
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // ดึงชีตข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // เพิ่มซีรีส์
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // เพิ่มหมวดหมู่
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // ตั้งค่าคุณสมบัติ Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // ดึงซีรีส์แผนภูมิที่สอง
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // ตอนนี้กำลังเติมข้อมูลซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ตั้งค่าค่า OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // เขียนงานนำเสนอลงดิสก์
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**รูปแบบแผนภูมิใดบ้างที่สนับสนุนโหมด 3 มิติใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3 มิติของแผนภูมิคอลัมน์ ได้แก่ Column 3D, Clustered Column 3D, Stacked Column 3D และ 100% Stacked Column 3D รวมถึงประเภท 3 มิติที่เกี่ยวข้องซึ่งเปิดเผยผ่านคลาส [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) หากต้องการรายการที่แม่นยำและเป็นปัจจุบัน ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) ในเอกสารอ้างอิง API ของรุ่นที่คุณติดตั้ง

**ฉันสามารถรับภาพราสเตอร์ของแผนภูมิ 3 มิติสำหรับรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นภาพผ่าน [chart API](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage-int-float-float-) หรือ [แปลงสไลด์ทั้งหมด](/slides/th/java/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG นี่เป็นประโยชน์เมื่อคุณต้องการตัวอย่างที่แม่นยำพิกเซลหรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**การสร้างและเรนเดอร์แผนภูมิ 3 มิติขนาดใหญ่มีประสิทธิภาพเป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ หากต้องการผลลัพธ์ที่ดีที่สุด ควรลดเอฟเฟกต์ 3 มิติให้เหลือน้อยที่สุด, หลีกเลี่ยงการใช้พื้นผิวที่มี texture หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อทำได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ