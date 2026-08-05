---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอโดยใช้ PHP
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/php-java/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ PHP ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลการนำเสนอของคุณเป็นระบบระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

โค้ด PHP นี้แสดงตัวอย่างการดำเนินการ:

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

## **ตั้งค่าเซลล์ WorkBook เป็นป้ายกำกับข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/php-java/aspose.slides/presentation)
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
1. เข้าถึงซีรีส์ของแผนภูมิ
1. ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล
1. บันทึกการพรีเซนเทชัน

โค้ด PHP นี้แสดงวิธีตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
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

## **จัดการแผ่นงาน**

โค้ด PHP นี้แสดงการดำเนินการที่ใช้เมธอด [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#getWorksheets) เพื่อเข้าถึงคอลเลกชันแผ่นงาน:

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

โค้ด PHP นี้แสดงวิธีระบุประเภทสำหรับแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนอรี (.xlsb) ที่อาจฝังอยู่ในแผนภูมิบางประเภท คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/) พร้อมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/php-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้นๆ

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
      # สมุดงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ
      continue;
    }

    # อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่นี่
  }
} finally {
  $presentation->dispose();
}
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับสมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกตั้งแต่ต้นหรือทำให้สมุดงานภายในกลายเป็นภายนอกได้

โค้ด PHP นี้แสดงกระบวนการสร้างสมุดงานภายนอก:

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

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางไปยังสมุดงานภายนอก (หากสมุดงานนั้นถูกย้ายไปแล้ว)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บอยู่ในตำแหน่งหรือทรัพยากรระยะไกลได้ แต่คุณยังสามารถใช้สมุดงานดังกล่าวเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด PHP นี้แสดงวิธีกำหนดสมุดงานภายนอก:

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

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดสมุดงาน Excel หรือไม่

* เมื่อค่า `ChartData` ตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดงานเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีหรือไม่พร้อมใช้งาน
* เมื่อค่า `ChartData` ตั้งเป็น `true` ข้อมูลแผนภูมิจะได้รับการอัปเดตจากสมุดงานเป้าหมาย

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

### **ดึงเส้นทางสมุดงานแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/php-java/aspose.slides/presentation)
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. สร้างอ็อบเจกต์สำหรับรูปทรงแผนภูมิ
1. สร้างอ็อบเจกต์สำหรับประเภทแหล่ง (`ChartDataSourceType`) ที่เป็นตัวแทนของแหล่งข้อมูลแผนภูมิ
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงประเภทแหล่งที่เป็นเช่นเดียวกับประเภทแหล่งข้อมูลสมุดงานภายนอก

โค้ด PHP นี้แสดงการดำเนินการ:

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
    # บันทึกพรีเซนเทชัน
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในสมุดงานภายใน เมื่อสมุดงานภายนอกไม่สามารถโหลดได้ จะมีการโยนข้อยกเว้น

โค้ด PHP นี้เป็นการนำกระบวนการที่อธิบายมาดำเนินการ:

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

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิใหม่จากข้อมูลที่เก็บไว้ในแคชของพรีเซนเทชันได้ ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/), ตั้งค่าด้วย [SpreadsheetOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/spreadsheetoptions/), และเรียก [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) ด้วยค่า `true` ก่อนเปิดพรีเซนเทชัน

ตัวอย่าง PHP ต่อไปนี้เปิดพรีเซนเทชันที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart::getChartData](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/#getChartData) และ [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
} finally {
    $presentation->dispose();
}
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่เก็บในแคชเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากพรีเซนเทชันอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานฝัง?**  
ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกถูกใช้

**รองรับเส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่ และเก็บอย่างไร?**  
ใช่ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะทำการแปลงเป็นเส้นทางแน่นอนโดยอัตโนมัติ ซึ่งสะดวกสำหรับการย้ายโครงการ อย่างไรก็ตามควรทราบว่าพรีเซนเทชันจะเก็บเส้นทางแน่นอนในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**  
ใช่ สมุดงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides เขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**  
ไม่ พรีเซนเทชันเก็บ [link to the external file](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/) และใช้เพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกเปลี่ยนแปลงเมื่อบันทึกพรีเซนเทชัน

**ควรทำอย่างไรหากไฟล์ภายนอกรหัสผ่าน?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีที่พบบ่อยคือการลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น โดยใช้ [Aspose.Cells](/cells/php-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**  
ใช่ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล