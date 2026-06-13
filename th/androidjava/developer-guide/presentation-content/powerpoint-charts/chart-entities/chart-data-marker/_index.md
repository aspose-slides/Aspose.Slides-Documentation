---
title: จัดการมาร์คเกอร์ข้อมูลแผนภูมิในการนำเสนอบน Android
linktitle: มาร์คเกอร์ข้อมูล
type: docs
url: /th/androidjava/chart-data-marker/
keywords:
- แผนภูมิ
- จุดข้อมูล
- มาร์คเกอร์
- ตัวเลือกมาร์คเกอร์
- ขนาดมาร์คเกอร์
- ประเภทการเติม
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ปรับแต่งมาร์คเกอร์ข้อมูลแผนภูมิใน Aspose.Slides สำหรับ Android เพื่อเพิ่มประสิทธิภาพการนำเสนอในรูปแบบ PPT และ PPTX ด้วยตัวอย่างโค้ด Java ที่ชัดเจน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับมาร์คเกอร์ข้อมูลของแผนภูมิใน Aspose.Slides. มันแสดงวิธีสร้างแผนภูมิ, เข้าถึงซีรีส์และจุดข้อมูลของมัน, ใช้การเติมรูปภาพให้กับมาร์คเกอร์ในระดับจุดข้อมูล, ปรับขนาดมาร์คเกอร์, และบันทึกการนำเสนอที่อัปเดต. นอกจากนี้ยังระบุว่ารูปร่างมาร์คเกอร์มาตรฐานมีให้ใช้ผ่านการนับจำนวน `MarkerStyleType` และลักษณะของมาร์คเกอร์จะคงอยู่เมื่อนำออกแผนภูมิเป็นรูปแบบ raster หรือ SVG.

## **ตั้งค่าตัวเลือกมาร์คเกอร์ของแผนภูมิ**
มาร์คเกอร์สามารถตั้งค่าได้บนจุดข้อมูลของแผนภูมิในซีรีส์เฉพาะ. เพื่อกำหนดตัวเลือกมาร์คเกอร์ของแผนภูมิ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
- สร้างแผนภูมิดีฟอลต์
- ตั้งค่ารูปภาพ
- ดึงซีรีส์แผนภูมิแรก
- เพิ่มจุดข้อมูลใหม่
- เขียนการนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่างนี้ เราได้ตั้งค่าตัวเลือกมาร์คเกอร์ของแผนภูมิในระดับจุดข้อมูล

```java
// สร้างการนำเสนอเปล่า
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // สร้างแผนภูมิดีฟอลต์
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // ดึงดัชนี WorkSheet ของข้อมูลแผนภูมิดีฟอลต์
    int defaultWorksheetIndex = 0;
    
    // ดึง WorkSheet ของข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบซีรีส์ตัวอย่าง
    chart.getChartData().getSeries().clear();
    
    // เพิ่มซีรีส์ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // โหลดรูปภาพที่ 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // โหลดรูปภาพที่ 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // ดึงซีรีส์แผนภูมิเซแรก
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // เพิ่มจุดใหม่ (1:3) ที่นั่น.
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
    
    // เปลี่ยนมาร์คเกอร์ของซีรีส์แผนภูมิ
    series.getMarker().setSize(15);
    
    // บันทึกการนำเสนอพร้อมแผนภูมิ
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**รูปร่างมาร์คเกอร์ที่มีให้ใช้งานโดยค่าเริ่มต้นมีอะไรบ้าง?**

มีรูปร่างมาตรฐานให้ใช้งาน (วงกลม, สี่เหลี่ยม, เพชร, สามเหลี่ยม ฯลฯ) รายการนี้ถูกกำหนดโดยคลาส [MarkerStyleType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markerstyletype/) หากต้องการรูปร่างที่ไม่เป็นมาตรฐาน ให้ใช้มาร์คเกอร์ที่เติมด้วยรูปภาพเพื่อจำลองภาพที่กำหนดเอง

**มาร์คเกอร์จะคงอยู่เมื่อส่งออกแผนภูมิเป็นภาพหรือ SVG หรือไม่?**

ใช่. เมื่อเราดึงแผนภูมิเป็น [raster formats](/slides/th/androidjava/convert-powerpoint-to-png/) หรือบันทึก [shapes as SVG](/slides/th/androidjava/render-a-slide-as-an-svg-image/), มาร์คเกอร์จะคงลักษณะและการตั้งค่าของมันไว้ รวมถึงขนาด, การเติม, และเส้นขอบ