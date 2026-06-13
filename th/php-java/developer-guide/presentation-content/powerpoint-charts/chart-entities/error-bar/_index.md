---
title: ปรับแต่งแถบข้อผิดพลาดในแผนภูมินำเสนอด้วย PHP
linktitle: แถบข้อผิดพลาด
type: docs
url: /th/php-java/error-bar/
keywords:
- แถบข้อผิดพลาด
- ค่าที่กำหนดเอง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและปรับแต่งแถบข้อผิดพลาดในแผนภูมิด้วย Aspose.Slides สำหรับ PHP ผ่าน Java — ปรับปรุงการแสดงผลข้อมูลในงานนำเสนอ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับแถบข้อผิดพลาดในแผนภูมิกำหนดการโดยใช้ Aspose.Slides มันแสดงวิธีเพิ่มแถบข้อผิดพลาดให้กับชุดข้อมูลของแผนภูมิ, ตั้งค่าการแสดงแถบข้อผิดพลาด X และ Y, และใช้ประเภทค่าต่าง ๆ เช่น ค่าคงที่, เปอร์เซ็นต์, และค่าที่กำหนดเอง

นอกจากนี้ยังสาธิตวิธีกำหนดค่ากำหนดเองให้กับแถบข้อผิดพลาดสำหรับจุดข้อมูลแต่ละจุดในชุดข้อมูลโดยใช้คอลเลกชันของจุดข้อมูลที่สอดคล้องกัน อีกทั้งบทความยังมีหมายเหตุสั้น ๆ เกี่ยวกับพฤติกรรมของแถบข้อผิดพลาดระหว่างการส่งออก, ความเข้ากันได้กับเครื่องหมายและป้ายกำกับข้อมูล, และตำแหน่งที่สามารถพบคลาสและ enum ของ API ที่เกี่ยวข้อง

## **เพิ่มแถบข้อผิดพลาด**
Aspose.Slides for PHP via Java ให้ API อย่างง่ายสำหรับการจัดการค่าของแถบข้อผิดพลาด ตัวอย่างโค้ดนี้ใช้เมื่อใช้ประเภทค่าที่กำหนดเอง เพื่อระบุค่าใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชันของ [**จุดข้อมูล**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriescollection/) ของชุดข้อมูล:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ  
3. เข้าถึงชุดข้อมูลแผนภูมแรกและตั้งค่าฟอร์แมตของแถบข้อผิดพลาด X  
4. เข้าถึงชุดข้อมูลแผนภูมแรกและตั้งค่าฟอร์แมตของแถบข้อผิดพลาด Y  
5. ตั้งค่าค่าและฟอร์แมตของแถบ  
6. เขียนพรีเซนเทชันที่แก้ไขแล้วลงไฟล์ PPTX  

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # สร้างแผนภูมิบับเบิล
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # เพิ่มแถบข้อผิดพลาดและตั้งค่ารูปแบบของมัน
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # บันทึกพรีเซนเทชัน
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มค่าแถบข้อผิดพลาดแบบกำหนดเอง**
Aspose.Slides for PHP via Java ให้ API อย่างง่ายสำหรับการจัดการค่าของแถบข้อผิดพลาดแบบกำหนดเอง ตัวอย่างโค้ดนี้ใช้เมื่อเมธอด [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/th/php-java/aspose.slides/errorbarsformat/#getValueType) ส่งคืน **Custom** เพื่อระบุค่าใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชันของ [**จุดข้อมูล**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriescollection/) ของชุดข้อมูล:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ  
3. เข้าถึงชุดข้อมูลแผนภูมแรกและตั้งค่าฟอร์แมตของแถบข้อผิดพลาด X  
4. เข้าถึงชุดข้อมูลแผนภูมแรกและตั้งค่าฟอร์แมตของแถบข้อผิดพลาด Y  
5. เข้าถึงจุดข้อมูลแต่ละจุดของชุดข้อมูลแผนภูมิและตั้งค่าแถบข้อผิดพลาดสำหรับจุดข้อมูลนั้น  
6. ตั้งค่าค่าและฟอร์แมตของแถบ  
7. เขียนพรีเซนเทชันที่แก้ไขแล้วลงไฟล์ PPTX  

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # สร้างแผนภูมิบับเบิล
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # เพิ่มแถบข้อผิดพลาดแบบกำหนดเองและตั้งค่ารูปแบบของมัน
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # เข้าถึงจุดข้อมูลของชุดแผนภูมิและตั้งค่าค่าแถบข้อผิดพลาดสำหรับ
    # จุดข้อมูลแต่ละจุด
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # ตั้งค่าแถบข้อผิดพลาดสำหรับจุดข้อมูลของชุดแผนภูมิ
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # บันทึกพรีเซนเทชัน
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**เกิดอะไรขึ้นกับแถบข้อผิดพลาดเมื่อส่งออกพรีเซนเทชันเป็น PDF หรือรูปภาพ?**

แถบข้อผิดพลาดจะถูกเรนเดอร์เป็นส่วนหนึ่งของแผนภูมิและจะคงอยู่ระหว่างการแปลงพร้อมกับการจัดรูปแบบแผนภูมิอื่น ๆ อย่างสมบูรณ์ หากใช้เวอร์ชันหรือเรนเดอร์ที่เข้ากันได้

**แถบข้อผิดพลาดสามารถใช้ร่วมกับเครื่องหมายและป้ายกำกับข้อมูลได้หรือไม่?**

ได้ แถบข้อผิดพลาดเป็นองค์ประกอบแยกต่างหากและเข้ากันได้กับเครื่องหมายและป้ายกำกับข้อมูล; หากองค์ประกอบทับกันอาจต้องปรับการจัดรูปแบบ

**ฉันจะหารายการคุณสมบัติและคลาสสำหรับทำงานกับแถบข้อผิดพลาดใน API ได้จากที่ไหน?**

ในเอกสารอ้างอิง API: คลาส [ErrorBarsFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/errorbarsformat/) และคลาสที่เกี่ยวข้อง [ErrorBarType](https://reference.aspose.com/slides/th/php-java/aspose.slides/errorbartype/) และ [ErrorBarValueType](https://reference.aspose.com/slides/th/php-java/aspose.slides/errorbarvaluetype/)