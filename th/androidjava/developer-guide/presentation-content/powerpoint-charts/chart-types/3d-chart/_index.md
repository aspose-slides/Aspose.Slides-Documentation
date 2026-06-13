---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอบน Android
linktitle: แผนภูมิ 3D
type: docs
url: /th/androidjava/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิ 3D ใน Aspose.Slides สำหรับ Android ผ่าน Java พร้อมการสนับสนุนไฟล์ PPT และ PPTX — เพิ่มประสิทธิภาพงานนำเสนอของคุณวันนี้."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแผนภูมิ 3D ใน Aspose.Slides โดยกำหนดค่าการตั้งค่า `Rotation3D` เช่น `RotationX`, `RotationY`, `DepthPercents` และ `RightAngleAxes` โดยจะนำเสนอขั้นตอนการสร้างงานนำเสนอ, เพิ่มแผนภูมิ 3D พร้อมข้อมูลเริ่มต้น, ใช้การตั้งค่ามุมมอง 3D ที่จำเป็น, และบันทึกงานนำเสนอที่ปรับปรุงแล้วเป็นไฟล์ PPTX

## **ตั้งค่า RotationX, RotationY และ DepthPercents ของแผนภูมิ 3D**

Aspose.Slides for Android via Java มี API ที่ง่ายสำหรับการตั้งค่าเหล่านี้ บทความต่อไปนี้จะช่วยคุณในการตั้งค่าต่างๆ เช่น **X,Y Rotation, DepthPercents** เป็นต้น โค้ดตัวอย่างใช้การตั้งค่าที่กล่าวถึงข้างต้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/).
2. เข้าถึงสไลด์แรก.
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น.
4. ตั้งค่าคุณสมบัติ Rotation3D.
5. เขียนงานนำเสนอที่ปรับปรุงแล้วเป็นไฟล์ PPTX.

```java
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // ดึงชีตข้อมูลของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // เพิ่มซีรีส์
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // เพิ่มประเภท
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // ตั้งค่าคุณสมบัติ Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // รับซีรีส์แผนภูมิที่สอง
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // กำลังเติมข้อมูลให้ซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ตั้งค่าค่า OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมประเภท 3D ที่เกี่ยวข้องที่เปิดเผยผ่านคลาส [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) สำหรับรายการที่แม่นยำและเป็นปัจจุบัน ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ใช่ คุณสามารถส่งออกแผนภูมิเป็นภาพผ่าน [chart API](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) หรือ [render the entire slide](/slides/th/androidjava/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG การทำเช่นนี้มีประโยชน์เมื่อคุณต้องการตัวอย่างภาพที่พิกเซลสมบูรณ์หรือต้องการฝังแผนภูมิลงในเอกสาร, แดชบอร์ด หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของการแสดงผล เพื่อให้ได้ผลลัพธ์ที่ดีที่สุด ควรจำกัดเอฟเฟกต์ 3D ให้เหลือน้อยที่สุด, หลีกเลี่ยงเทกเจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นผลลัพธ์ที่มีขนาดเหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับหน้าจอหรือความต้องการพิมพ์เป้าหมาย