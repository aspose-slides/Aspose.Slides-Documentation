---
title: จัดการตัวบ่งชี้ข้อมูลแผนภูมิในงานนำเสนอโดยใช้ JavaScript
linktitle: ตัวบ่งชี้ข้อมูล
type: docs
url: /th/nodejs-java/chart-data-marker/
keywords:
- แผนภูมิ
- จุดข้อมูล
- ตัวบ่งชี้
- ตัวเลือกตัวบ่งชี้
- ขนาดตัวบ่งชี้
- ประเภทการเติม
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีปรับแต่งตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides สำหรับ Node.js เพื่อเพิ่มประสิทธิภาพการนำเสนอในรูปแบบ PPT และ PPTX ด้วยตัวอย่างโค้ดที่ชัดเจน"
---
## **Overview**

บทความนี้อธิบายวิธีการทำงานกับตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides โดยแสดงวิธีสร้างแผนภูมิ, เข้าถึงซีรีส์และจุดข้อมูลของมัน, ใช้การเติมภาพกับตัวบ่งชี้ในระดับจุดข้อมูล, ปรับขนาดตัวบ่งชี้, และบันทึกการนำเสนอที่อัปเดต นอกจากนี้ยังระบุว่ารูปร่างตัวบ่งชี้มาตรฐานพร้อมใช้งานผ่านการระบุ `MarkerStyleType` และลักษณะของตัวบ่งชี้จะคงไว้เมื่อนำแผนภูมิออกเป็นรูปแบบเรสเตอร์หรือ SVG.

## **Set Chart Marker Options**

ตัวบ่งชี้สามารถตั้งค่าได้บนจุดข้อมูลของแผนภูมิในซีรีส์ที่กำหนด เพื่อกำหนดตัวเลือกของตัวบ่งชี้บนแผนภูมิ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).
- สร้างแผนภูมิเริ่มต้น.
- ตั้งค่าภาพ.
- เลือกซีรีส์แรกของแผนภูมิ.
- เพิ่มจุดข้อมูลใหม่.
- เขียนการนำเสนอลงดิสก์.

ในตัวอย่างที่ให้ด้านล่าง เราได้ตั้งค่าตัวบ่งชี้บนระดับจุดข้อมูลแล้ว.

```javascript
// สร้างการนำเสนอเปล่า
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // สร้างแผนภูมิเริ่มต้น
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // ดึงดัชนี WorkSheet ของข้อมูลแผนภูมิเริ่มต้น
    var defaultWorksheetIndex = 0;
    // ดึง WorkSheet ของข้อมูลแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // ลบซีรีส์ตัวอย่าง
    chart.getChartData().getSeries().clear();
    // เพิ่มซีรีส์ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // โหลดรูปภาพที่ 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // โหลดรูปภาพที่ 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // รับซีรีส์แผนภูมิแรก
    var series = chart.getChartData().getSeries().get_Item(0);
    // เพิ่มจุดข้อมูลใหม่ (1:3) ที่นี่.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // เปลี่ยนตัวบ่งชี้ของซีรีส์แผนภูมิ
    series.getMarker().setSize(15);
    // บันทึกการนำเสนอพร้อมแผนภูมิ
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**รูปร่างตัวบ่งชี้ที่มีให้ใช้โดยอัตโนมัติมีอะไรบ้าง?**

มีรูปร่างมาตรฐานให้ใช้ (วงกลม, สี่เหลี่ยม, เพชร, สามเหลี่ยม ฯลฯ) รายการนี้กำหนดโดยการระบุ [MarkerStyleType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markerstyletype/) หากต้องการรูปร่างที่ไม่เป็นมาตรฐาน ให้ใช้ตัวบ่งชี้ที่เติมด้วยภาพเพื่อจำลองภาพที่กำหนดเอง.

**ตัวบ่งชี้จะคงอยู่เมื่อนำแผนภูมิออกเป็นภาพหรือ SVG หรือไม่?**

ใช่ เมื่อเรนเดอร์แผนภูมิเป็น [raster formats](/slides/th/nodejs-java/convert-powerpoint-to-png/) หรือบันทึก [shapes as SVG](/slides/th/nodejs-java/render-a-slide-as-an-svg-image/) ตัวบ่งชี้จะคงลักษณะและการตั้งค่าของมันไว้ รวมถึงขนาด, การเติม, และเส้นขอบ.