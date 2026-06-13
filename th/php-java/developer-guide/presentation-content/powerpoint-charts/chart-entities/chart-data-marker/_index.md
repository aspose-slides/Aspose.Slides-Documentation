---
title: จัดการตัวทำเครื่องหมายข้อมูลแผนภูมิในงานนำเสนอโดยใช้ PHP
linktitle: ตัวทำเครื่องหมายข้อมูล
type: docs
url: /th/php-java/chart-data-marker/
keywords:
- แผนภูมิ
- จุดข้อมูล
- ตัวทำเครื่องหมาย
- ตัวเลือกตัวทำเครื่องหมาย
- ขนาดตัวทำเครื่องหมาย
- ประเภทการเติม
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการปรับแต่งตัวทำเครื่องหมายข้อมูลแผนภูมิใน Aspose.Slides สำหรับ PHP เพื่อเพิ่มประสิทธิภาพการนำเสนอในรูปแบบ PPT และ PPTX ด้วยตัวอย่างโค้ดที่ชัดเจน"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตัวทำเครื่องหมายข้อมูลแผนภูมิใน Aspose.Slides โดยจะแสดงวิธีสร้างแผนภูมิ, เข้าถึงซีรีส์และจุดข้อมูลของมัน, ใช้การเติมภาพบนตัวทำเครื่องหมายในระดับจุดข้อมูล, ปรับขนาดตัวทำเครื่องหมาย, และบันทึกการนำเสนอที่อัปเดต นอกจากนี้ยังระบุว่ารูปร่างมาตรฐานของตัวทำเครื่องหมายสามารถใช้ได้ผ่าน enumerations `MarkerStyleType` และลักษณะที่ปรากฏของตัวทำเครื่องหมายจะถูกเก็บรักษาเมื่อส่งออกแผนภูมิเป็นรูปแบบเรสเตอร์หรือ SVG.

## **ตั้งค่าตัวทำเครื่องหมายแผนภูมิ**
ตัวทำเครื่องหมายสามารถตั้งค่าได้บนจุดข้อมูลของแผนภูมิในซีรีส์ที่ระบุ เพื่อกำหนดตัวเลือกของตัวทำเครื่องหมายแผนภูมิ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation).
- สร้างแผนภูมิปริยาย.
- ตั้งค่าภาพ.
- เลือกซีรีส์แผนภูมิแรก.
- เพิ่มจุดข้อมูลใหม่.
- บันทึกการนำเสนอลงดิสก์.

ในตัวอย่างด้านล่างนี้ เราได้ตั้งค่าตัวทำเครื่องหมายแผนภูมิในระดับจุดข้อมูล.

```php
  # สร้างงานนำเสนอเปล่า
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # สร้างแผนภูมิปริยาย
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # รับดัชนี WorkSheet ของข้อมูลแผนภูมิปริยาย
    $defaultWorksheetIndex = 0;
    # รับ WorkSheet ของข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์ตัวอย่าง
    $chart->getChartData()->getSeries()->clear();
    # เพิ่มซีรีส์ใหม่
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # โหลดรูปภาพ 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # โหลดรูปภาพ 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # ดึงซีรีส์แผนภูมิลำดับแรก
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # เพิ่มจุดใหม่ (1:3) ที่นั่น.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # เปลี่ยนตัวทำเครื่องหมายของซีรีส์แผนภูมิ
    $series->getMarker()->setSize(15);
    # บันทึกงานนำเสนอพร้อมแผนภูมิ
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**รูปร่างของตัวทำเครื่องหมายที่มีให้โดยตรงมีอะไรบ้าง?**

มีรูปแบบมาตรฐานให้ใช้งาน (วงกลม, สี่เหลี่ยม, เพชร, สามเหลี่ยม ฯลฯ) รายการนี้กำหนดโดยคลาส [MarkerStyleType](https://reference.aspose.com/slides/th/php-java/aspose.slides/markerstyletype/) หากคุณต้องการรูปแบบที่ไม่เป็นมาตรฐาน ให้ใช้ตัวทำเครื่องหมายที่เติมด้วยภาพเพื่อจำลองภาพแบบกำหนดเอง.

**ตัวทำเครื่องหมายจะถูกเก็บรักษาไว้เมื่อส่งออกแผนภูมิเป็นภาพหรือ SVG หรือไม่?**

ใช่ เมื่อเรนเดอร์แผนภูมิเป็น [raster formats](/slides/th/php-java/convert-powerpoint-to-png/) หรือบันทึก [shapes as SVG](/slides/th/php-java/render-a-slide-as-an-svg-image/) ตัวทำเครื่องหมายจะคงลักษณะและการตั้งค่าต่าง ๆ เช่น ขนาด, การเติม, และโครงร่างไว้.