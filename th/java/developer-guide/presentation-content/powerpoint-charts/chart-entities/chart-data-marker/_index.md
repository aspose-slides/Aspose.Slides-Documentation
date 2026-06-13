---
title: จัดการตัวบ่งชี้ข้อมูลแผนภูมิในงานนำเสนอโดยใช้ Java
linktitle: ตัวบ่งชี้ข้อมูล
type: docs
url: /th/java/chart-data-marker/
keywords:
- แผนภูมิ
- จุดข้อมูล
- ตัวบ่งชี้
- ตัวเลือกตัวบ่งชี้
- ขนาดตัวบ่งชี้
- ประเภทการเติม
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีปรับแต่งตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides สำหรับ Java เพื่อเพิ่มประสิทธิภาพของการนำเสนอในรูปแบบ PPT และ PPTX ด้วยตัวอย่างโค้ด Java ที่ชัดเจน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides แสดงวิธีสร้างแผนภูมิ, เข้าถึงซีรีส์และจุดข้อมูลของมัน, นำรูปภาพเติมใส่ลงในตัวบ่งชี้ระดับจุดข้อมูล, ปรับขนาดตัวบ่งชี้, และบันทึกการนำเสนอที่อัปเดต นอกจากนี้ยังบอกว่ารูปร่างตัวบ่งชี้มาตรฐานมีให้ใช้งานผ่านการนับจำนวน `MarkerStyleType` และลักษณะของตัวบ่งชี้จะถูกคงไว้เมื่อส่งออกแผนภูมิเป็นรูปแบบเรสเตอร์หรือ SVG.

## **ตั้งค่าตัวบ่งชี้แผนภูมิ**

ตัวบ่งชี้สามารถตั้งค่าได้บนจุดข้อมูลของแผนภูมิภายในซีรีส์ที่กำหนด เพื่อกำหนดตัวเลือกของตัวบ่งชี้แผนภูมิ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
- สร้างแผนภูมิเริ่มต้น.
- ตั้งค่าภาพ.
- ดึงซีรีส์แรกของแผนภูมิ.
- เพิ่มจุดข้อมูลใหม่.
- เขียนการนำเสนอลงดิสก์.

ในตัวอย่างที่ให้ไว้ด้านล่าง เราได้ตั้งค่าตัวบ่งชี้แผนภูมิที่ระดับจุดข้อมูลแล้ว.

```java
// สร้างงานนำเสนอเปล่า
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // สร้างแผนภูมิเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // ดึงดัชนีแผ่นงานข้อมูลแผนภูมิเริ่มต้น
    int defaultWorksheetIndex = 0;
    
    // ดึงแผ่นงานข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบซีรีส์เดโม
    chart.getChartData().getSeries().clear();
    
    // เพิ่มซีรีส์ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // โหลดรูปภาพ 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // โหลดรูปภาพ 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // ดึงซีรีส์แผนภูมิแรก
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // เพิ่มจุดใหม่ (1:3) ที่นี่.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // เปลี่ยนตัวบ่งชี้ซีรีส์แผนภูมิ
    series.getMarker().setSize(15);
    
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**รูปทรงตัวบ่งชี้ที่พร้อมใช้งานมีอะไรบ้าง?**

มีรูปทรงมาตรฐานให้ใช้งาน (วงกลม, สี่เหลี่ยม, เพชร, สามเหลี่ยม ฯลฯ) รายการนี้กำหนดโดยคลาส [MarkerStyleType](https://reference.aspose.com/slides/th/java/com.aspose.slides/markerstyletype/) หากต้องการรูปทรงที่ไม่เป็นมาตรฐาน ให้ใช้ตัวบ่งชี้พร้อมการเติมรูปภาพเพื่อจำลองภาพแบบกำหนดเอง.

**ตัวบ่งชี้จะถูกคงไว้เมื่อส่งออกแผนภูมิเป็นภาพหรือ SVG หรือไม่?**

ใช่ เมื่อเรนเดอร์แผนภูมิเป็น [raster formats](/slides/th/java/convert-powerpoint-to-png/) หรือบันทึก [shapes as SVG](/slides/th/java/render-a-slide-as-an-svg-image/) ตัวบ่งชี้จะคงลักษณะและการตั้งค่าของมันไว้รวมถึงขนาด การเติมสี และขอบ