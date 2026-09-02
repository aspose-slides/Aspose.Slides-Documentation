---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอโดยใช้ PHP
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/php-java/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ PHP ผ่าน Java: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเวิร์กบุ๊กแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ก ใช้เซลล์ในเวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิกจากเวิร์กบุ๊ก**
Aspose.Slides มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องถูกจัดระเบียบในแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

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

### **ตรวจสอบการจัดวางแผนภูมิหลังการแก้ไขเวิร์กบุ๊ก**

เมื่อคุณแทนที่เวิร์กบุ๊กฝังด้วยเวิร์กบุ๊กที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดข้อมูลและคอลเลกชันประเภทเดิม การไม่ตรงกันนี้อาจทำให้ [Chart::validateChartLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ลบชุดข้อมูลและประเภทที่มีอยู่ก่อนเขียนเวิร์กบุ๊กที่อัปเดตกลับไปยังแผนภูมิ

```php
// หลังจากแก้ไขสตรีมเวิร์กบุ๊ก (เช่น ใช้ Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

การลบคอลเลกชันช่วยให้โครงสร้างข้อมูลแผนภูมิตรงกับเวิร์กบุ๊กใหม่ ทำให้ `validateChartLayout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
1. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
1. เพิ่มแผนภูมิบับเบิลพร้อมข้อมูลบางส่วน
1. เข้าถึงชุดข้อมูลของแผนภูมิ
1. ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูล
1. บันทึกการพรีเซนเทชั่น

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # สร้างอินสแตนซ์ของคลาสพรีเซนเทชั่นที่แสดงไฟล์พรีเซนเทชั่น
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

โค้ด PHP นี้แสดงการดำเนินการที่ใช้เมธอด [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#getWorksheets) เพื่อเข้าถึงคอลเลกชันของแผ่นงาน:

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กฝังที่ไม่ได้รับการสนับสนุน**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊กไบนารีของ Excel (.xlsb) ที่สามารถฝังในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/) ร่วมกับการอิมพอร์ท [WorkbookType](https://reference.aspose.com/slides/th/php-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่ได้รับการสนับสนุนและข้ามแผนภูมิเหล่านั้น

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
      # เวิร์กบุ๊กฝังอยู่ในรูปแบบ .xlsb ซึ่งไม่รองรับ.
      continue;
    }

    # อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กของแผนภูมิที่นี่.
  }
} finally {
  $presentation->dispose();
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างเวิร์กบุ๊กภายนอกจากศูนย์หรือทำให้เวิร์กบุ๊กภายในเป็นภายนอกได้

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

### **ตั้งค่าเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางของเวิร์กบุ๊กภายนอก (หากเวิร์กบุ๊กถูกย้าย)  

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่จัดเก็บในตำแหน่งหรือทรัพยากรระยะไกลได้ คุณก็ยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

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

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดเวิร์กบุ๊ก Excel หรือไม่  

* เมื่อค่า `ChartData` ถูกตั้งเป็น `false` จะอัพเดตเฉพาะเส้นทางของเวิร์กบุ๊กเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย คุณอาจใช้การตั้งค่านี้ในกรณีที่เวิร์กบุ๊กเป้าหมายไม่มีอยู่หรือไม่พร้อมใช้งาน  
* เมื่อค่า `ChartData` ถูกตั้งเป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากเวิร์กบุ๊กเป้าหมาย  

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

### **ดึงเส้นทางเวิร์กบุ๊กแหล่งข้อมูลภายนอกของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/php-java/aspose.slides/presentation)  
1. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ  
1. สร้างอ็อบเจกต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แสดงแหล่งข้อมูลของแผนภูมิ  
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่เหมือนกับประเภทแหล่งข้อมูลของเวิร์กบุ๊กภายนอก  

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
    # บันทึกพรีเซนเทชั่น
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของเวิร์กบุ๊กภายใน เมื่อเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ ระบบจะโยนข้อยกเว้น

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

### **กู้คืนเวิร์กบุ๊กจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กบุ๊กของแผนภูมิจากข้อมูลที่แคชไว้ในพรีเซนเทชั่นได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/) ตั้งค่าโดยใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/spreadsheetoptions/) และเรียก [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) ด้วยค่า `true` ก่อนเปิดพรีเซนเทชั่น  

ตัวอย่าง PHP ต่อไปนี้เปิดพรีเซนเทชั่นที่แผนภูมิเชื่อมโยงกับเวิร์กบุ๊กภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart::getChartData](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/#getChartData) และ [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนที่นี่.
} finally {
    $presentation->dispose();
}
```

หากเวิร์กบุ๊กภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยนข้อยกเว้น ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิจากแคชเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากพรีเซนเทชั่นอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กฝัง?**  
ได้ครับ/ค่ะ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/) หากแหล่งเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอก

**รองรับการใช้เส้นทางสัมพัทธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่ และเก็บอย่างไร?**  
ใช่ หากคุณระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางแบบเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการย้ายโครงการ อย่างไรก็ตาม โปรดทราบว่าไฟล์พรีเซนเทชั่นจะเก็บเส้นทางแบบเต็มในไฟล์ PPTX

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**  
ได้ เวิร์กบุ๊กเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ แต่การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — พวกมันสามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชั่นหรือไม่?**  
ไม่ พรีเซนเทชั่นจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/) และใช้เพื่ออ่านข้อมูล การบันทึกพรีเซนเทชั่นจะไม่แก้ไขไฟล์ภายนอก

**ฉันควรทำอย่างไรหากไฟล์ภายนอกถูกป้องหางด้วยรหัสผ่าน?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือการลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/php-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**  
ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในการโหลดข้อมูลครั้งถัดไป