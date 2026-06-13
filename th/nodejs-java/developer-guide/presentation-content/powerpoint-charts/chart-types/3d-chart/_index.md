---
title: ปรับแต่งแผนภูมิ 3D ในการนำเสนอด้วย JavaScript
linktitle: แผนภูมิ 3D
type: docs
url: /th/nodejs-java/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิ 3D ใน Aspose.Slides สำหรับ Node.js ผ่าน Java พร้อมการรองรับไฟล์ PPT และ PPTX—เพิ่มพลังการนำเสนอของคุณวันนี้."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแผนภูมิ 3D ใน Aspose.Slides โดยกำหนดค่าการตั้งค่า `Rotation3D` เช่น `RotationX`, `RotationY`, `DepthPercents` และ `RightAngleAxes`. มันพาผู้อ่านผ่านการสร้างงานนำเสนอ, การเพิ่มแผนภูมิ 3D ด้วยข้อมูลเริ่มต้น, การใช้การตั้งค่าการมองเห็น 3D ที่จำเป็น, และการบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

## **ตั้งค่าคุณสมบัติ RotationX, RotationY และ DepthPercents ของแผนภูมิ 3D**

Aspose.Slides for Node.js via Java มี API ที่ง่ายสำหรับการตั้งค่าคุณสมบัติเหล่านี้. บทความต่อไปนี้จะช่วยคุณในการตั้งค่าต่าง ๆ เช่น **การหมุน X,Y, DepthPercents** เป็นต้น. ตัวอย่างโค้ดจะใช้การตั้งค่าที่กล่าวถึงข้างต้น.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก.
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น.
4. ตั้งค่าคุณสมบัติ Rotation3D.
5. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    var defaultWorksheetIndex = 0;
    // ดึงแผ่นงานข้อมูลแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // เพิ่มซีรีส์
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // เพิ่มประเภท
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // ตั้งค่าคุณสมบัติ Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // ดึงซีรีส์แผนภูมิที่สอง
    var series = chart.getChartData().getSeries().get_Item(1);
    // กำลังเติมข้อมูลซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // ตั้งค่าค่า OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // บันทึกการนำเสนอลงดิสก์
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดสนับสนุนโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์ รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดให้ใช้ผ่าน enumeration [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/). สำหรับรายการที่อัปเดตล่าสุด โปรดตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/) ในอ้างอิง API ของรุ่นที่คุณติดตั้ง.

**ฉันสามารถรับภาพแรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ใช่ คุณสามารถส่งออกแผนภูมิเป็นภาพผ่าน [chart API](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage) หรือ [render the entire slide](/slides/th/nodejs-java/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG. นี้เป็นประโยชน์เมื่อคุณต้องการพรีวิวที่พิกเซลสมบูรณ์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint.

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ. เพื่อให้ได้ผลลัพธ์ที่ดีที่สุด ควรลดเอฟเฟกต์ 3D ให้เหลือน้อยที่สุด, หลีกเลี่ยงเท็กซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นเอาต์พุตขนาดที่เหมาะสม (ความละเอียดและขนาด) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ.