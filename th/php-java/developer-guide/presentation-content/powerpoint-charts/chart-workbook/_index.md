---
title: จัดการหนังสือทำงานของแผนภูมิในงานนำเสนอโดยใช้ PHP
linktitle: หนังสือทำงานแผนภูมิ
type: docs
weight: 70
url: /th/php-java/chart-workbook/
keywords:
- หนังสือทำงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์หนังสือทำงาน
- ป้ายกำกับข้อมูล
- เวิร์กชีท
- แหล่งข้อมูล
- หนังสือทำงานภายนอก
- ข้อมูลภายนอก
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ PHP ผ่าน Java: จัดการหนังสือทำงานของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อเพิ่มประสิทธิภาพข้อมูลในงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับหนังสือทำงานของแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิโดยผ่านสตรีมของหนังสือทำงาน ใช้เซลล์ของหนังสือทำงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของเวิร์กชีท และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับหนังสือทำงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนดหนังสือทำงานภายนอก ดึงเส้นทางของหนังสือทำงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อหนังสือทำงานสามารถเข้าถึงได้

## **อ่านและเขียนข้อมูลแผนภูมิจากหนังสือทำงาน**

Aspose.Slides มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ช่วยให้คุณอ่านและเขียนหนังสือทำงานของข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **กำหนดเซลล์ของ WorkBook เป็นป้ายกำกับข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
2. รับการอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
4. เข้าถึงชุดข้อมูลของแผนภูมิ
5. กำหนดเซลล์ของ workbook เป็นป้ายกำกับข้อมูล
6. บันทึกการนำเสนอ

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **จัดการ Worksheet**

โค้ด PHP นี้แสดงการทำงานที่ใช้เมธอด [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#getWorksheets) เพื่อเข้าถึงคอลเลกชันของ worksheet:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ระบุประเภทแหล่งข้อมูล**

โค้ด PHP นี้แสดงวิธีการระบุประเภทสำหรับแหล่งข้อมูล:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตรวจจับรูปแบบหนังสือทำงานที่ฝังไว้ที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบหนังสือทำงานแบบไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/php-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # หนังสือทำงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
      continue;
    }

    # อ่านหรือแก้ไขข้อมูลหนังสือทำงานของแผนภูมิที่นี่.
  }
} finally {
  $presentation->dispose();
}
```

## **หนังสือทำงานภายนอก**

Aspose.Slides รองรับหนังสือทำงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างหนังสือทำงานภายนอก**

ด้วยเมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างหนังสือทำงานภายนอกจากศูนย์หรือทำให้หนังสือทำงานภายในกลายเป็นภายนอกได้

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **กำหนดหนังสือทำงานภายนอก**

ด้วยเมธอด **`setExternalWorkbook`** คุณสามารถกำหนดหนังสือทำงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังหนังสือทำงานภายนอก (หากมีการย้ายตำแหน่ง)

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลในหนังสือทำงานที่เก็บไว้ในตำแหน่งหรือแหล่งทรัพยากรระยะไกลได้ แต่คุณยังสามารถใช้หนังสือทำงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางแบบสัมพันธ์สำหรับหนังสือทำงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดหรือไม่โหลดหนังสือทำงาน Excel

* เมื่อค่า `ChartData` ถูกตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของหนังสือทำงานเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากหนังสือทำงานเป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อหนังสือทำงานเป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้  
* เมื่อค่า `ChartData` ถูกตั้งเป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากหนังสือทำงานเป้าหมาย

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ดึงเส้นทางของหนังสือทำงานแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
2. รับการอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. สร้างอ็อบเจ็กต์สำหรับรูปร่างแผนภูมิ
4. สร้างอ็อบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่เป็นตัวแทนของแหล่งข้อมูลของแผนภูมิ
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่เหมือนกับประเภทแหล่งข้อมูลหนังสือทำงานภายนอก

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # บันทึกการนำเสนอ
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในหนังสือทำงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของหนังสือทำงานภายใน เมื่อไม่สามารถโหลดหนังสือทำงานภายนอกได้ จะมีการโยนข้อยกเว้น

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดได้หรือไม่ว่าแผนภูมิเฉพาะนั้นเชื่อมโยงกับหนังสือทำงานภายนอกหรือที่ฝังอยู่?**

ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getdatasourcetype/) และ [เส้นทางไปยังหนังสือทำงานภายนอก](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ; หากแหล่งข้อมูลเป็นหนังสือทำงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่ามีการใช้ไฟล์ภายนอก

**เส้นทางแบบสัมพันธ์ไปยังหนังสือทำงานภายนอกรับการสนับสนุนหรือไม่ และจัดเก็บอย่างไร?**

ใช่ หากคุณระบุเส้นทางแบบสัมพันธ์ จะถูกแปลงเป็นเส้นทางแบบเต็มโดยอัตโนมัติ สิ่งนี้สะดวกสำหรับการพกพาโครงการ; อย่างไรก็ตาม โปรดทราบว่าการนำเสนอจะเก็บเส้นทางแบบเต็มในไฟล์ PPTX

**ฉันสามารถใช้หนังสือทำงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ใช่ หนังสือทำงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขหนังสือทำงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides เขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

ไม่ การนำเสนอจะบันทึก [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/) และใช้เพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกการนำเสนอ

**ฉันควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ วิธีทั่วไปคือการลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/php-java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิเข้าถึงหนังสือทำงานภายนอกเดียวกันได้หรือไม่?**

ใช่ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในการโหลดข้อมูลครั้งต่อไป