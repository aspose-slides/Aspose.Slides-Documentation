---
title: จัดรูปแบบแผนภูมิการนำเสนอใน PHP
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/php-java/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- เอนทิตีของแผนภูมิ
- คุณสมบัติของแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติฟอนต์
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ PHP ผ่าน Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยสไตล์ระดับมืออาชีพที่ดึงดูดสายตา."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides โดยแสดงวิธีการปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นตาราง, ชื่อเรื่อง, เลเจนด์, พื้นที่พล็อต, และการเติมสีผนัง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

บทความยังสาธิตวิธีการตั้งค่าคุณสมบัติฟอนต์สำหรับข้อความในแผนภูมิ, การใช้รูปแบบตัวเลขที่กำหนดไว้ล่วงหน้าและแบบกำหนดเองกับข้อมูลแผนภูมิ, และการเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ พร้อมกันนี้ ตัวอย่างเหล่านี้แสดงวิธีการควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบเอนทิตีของแผนภูมิ**
Aspose.Slides for PHP via Java ให้ผู้พัฒนาสามารถเพิ่มแผนภูมิเวอร์ชันที่กำหนดเองเข้าไปในสไลด์ตั้งแต่ต้น บทความนี้อธิบายวิธีการจัดรูปแบบเอนทิตีแผนภูมิที่แตกต่างกันรวมถึงแกนประเภทและค่า

Aspose.Slides for PHP via Java มี API ที่เรียบง่ายสำหรับการจัดการเอนทิตีแผนภูมิและการจัดรูปแบบโดยใช้ค่าที่กำหนดเอง:

1. สร้างอินสแตนซ์ของคลาส [**Presentation**](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
1. รับอ้างอิงสไลด์ตามตำแหน่งดัชนี.
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ในตัวอย่างนี้ใช้ ChartType::LineWithMarkers).
1. เข้าถึง Value Axis ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับ Value Axis เส้นกริดหลัก
   1. ตั้งค่า **Line format** สำหรับ Value Axis เส้นกริดรอง
   1. ตั้งค่า **Number Format** สำหรับ Value Axis
   1. ตั้งค่า **Min, Max, Major and Minor units** สำหรับ Value Axis
   1. ตั้งค่า **Text Properties** สำหรับข้อมูลของ Value Axis
   1. ตั้งค่า **Title** สำหรับ Value Axis
   1. ตั้งค่า **Line Format** สำหรับ Value Axis
1. เข้าถึง Category Axis ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับ Category Axis เส้นกริดหลัก
   1. ตั้งค่า **Line format** สำหรับ Category Axis เส้นกริดรอง
   1. ตั้งค่า **Text Properties** สำหรับข้อมูลของ Category Axis
   1. ตั้งค่า **Title** สำหรับ Category Axis
   1. ตั้งค่า **Label Positioning** สำหรับ Category Axis
   1. ตั้งค่า **Rotation Angle** สำหรับป้ายกำกับ Category Axis
1. เข้าถึง Legend ของแผนภูมิและตั้งค่า **Text Properties** สำหรับ Legend
1. ตั้งค่าให้แสดง Legend ของแผนภูมิโดยไม่ซ้อนทับแผนภูมิ
1. เข้าถึง **Secondary Value Axis** ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. เปิดใช้งาน Secondary **Value Axis**
   1. ตั้งค่า **Line Format** สำหรับ Secondary Value Axis
   1. ตั้งค่า **Number Format** สำหรับ Secondary Value Axis
   1. ตั้งค่า **Min, Max, Major and Minor units** สำหรับ Secondary Value Axis
1. ตอนนี้พล็อตชุดข้อมูลแรกบน Secondary Value Axis
1. ตั้งค่าสีเติมผนังหลังของแผนภูมิ
1. ตั้งค่าสีเติมพื้นที่พล็อตของแผนภูมิ
1. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมิตัวอย่าง
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # ตั้งค่าชื่อเรื่องของแผนภูมิ
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนค่า
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนค่า
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # ตั้งค่ารูปแบบตัวเลขของแกนค่า
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # ตั้งค่าสูงสุดและต่ำสุดของแผนภูมิ
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # ตั้งค่าคุณสมบัติตัวอักษรของแกนค่า
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # ตั้งค่าชื่อเรื่องของแกนค่า
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนประเภท
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนประเภท
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # ตั้งค่าคุณสมบัติตัวอักษรของแกนประเภท
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # ตั้งค่าชื่อเรื่องของประเภท
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # ตั้งค่าตำแหน่งป้ายกำกับของแกนประเภท
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # ตั้งค่ามุมหมุนของป้ายกำกับแกนประเภท
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # ตั้งค่าคุณสมบัติตัวอักษรของเลเจนด์
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # ตั้งค่าให้แสดงเลเจนด์ของแผนภูมิโดยไม่ทับซ้อนกับแผนภูมิ
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # ตั้งค่าแกนค่ารอง
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # ตั้งค่ารูปแบบตัวเลขของแกนค่ารอง
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # ตั้งค่าสูงสุดและต่ำสุดของแผนภูมิ
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # ตั้งค่าสีผนังด้านหลังของแผนภูมิ
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # ตั้งค่าสีพื้นที่พล็อต
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # บันทึกงานนำเสนอ
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับแผนภูมิ**
Aspose.Slides for PHP via Java ให้การสนับสนุนการตั้งค่าคุณสมบัติเกี่ยวกับฟอนต์สำหรับแผนภูมิ โปรดทำตามขั้นตอนต่อไปนี้เพื่อตั้งค่าฟอนต์ของแผนภูมิ

- สร้างอ็อบเจ็กต์คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
- เพิ่มแผนภูมาบนสไลด์.
- ตั้งค่าสูงของฟอนต์.
- บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างโค้ดด้านล่างแสดงวิธีการ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่ารูปแบบตัวเลข**
Aspose.Slides for PHP via Java มี API ที่เรียบง่ายสำหรับการจัดการรูปแบบข้อมูลของแผนภูมิ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) .
1. รับอ้างอิงสไลด์ตามตำแหน่งดัชนี.
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ตัวอย่างนี้ใช้ **ChartType::ClusteredColumn**).
1. ตั้งค่ารูปแบบตัวเลขที่กำหนดไว้ล่วงหน้าจากค่าที่เป็นไปได้.
1. วนผ่านเซลล์ข้อมูลของแผนภูมิในแต่ละชุดข้อมูลและตั้งค่ารูปแบบตัวเลขของข้อมูลแผนภูมิ.
1. บันทึกงานนำเสนอ.
1. ตั้งค่ารูปแบบตัวเลขแบบกำหนดเอง.
1. วนผ่านเซลล์ข้อมูลของแผนภูมิในทุกชุดข้อมูลและตั้งค่ารูปแบบตัวเลขที่แตกต่างกัน.
1. บันทึกงานนำเสนอ.

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์การนำเสนอแรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมิกลัสเตอร์คอลัมน์เริ่มต้น
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # เข้าถึงคอลเลกชันซีรีส์ของแผนภูมิ
    $series = $chart->getChartData()->getSeries();
    # วนผ่านซีรีส์ของแผนภูมิแต่ละชุด
    foreach($series as $ser) {
      # วนผ่านเซลล์ข้อมูลในซีรีส์แต่ละชุด
      foreach($ser->getDataPoints() as $cell) {
        # ตั้งค่ารูปแบบตัวเลข
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # บันทึกการนำเสนอ
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ค่ารูปแบบตัวเลขที่กำหนดล่วงหน้าที่สามารถใช้ได้พร้อมดัชนีของแต่ละรูปแบบมีดังต่อไปนี้:

|**0**|ทั่วไป|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **ตั้งค่าขอบโค้งของพื้นที่แผนภูมิ**
Aspose.Slides for PHP via Java ให้การสนับสนุนการตั้งค่าพื้นที่แผนภูมิ เมธอด [**hasRoundedCorners**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/hasroundedcorners/) และ [**setRoundedCorners**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/setroundedcorners/) ถูกเพิ่มเข้าไปในคลาส [Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/Chart) 

1. สร้างอ็อบเจ็กต์คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) .
1. เพิ่มแผนภูมบนสไลด์.
1. ตั้งค่าชนิดการเติมและสีเติมของแผนภูมิ
1. ตั้งค่าคุณสมบัติมุมโค้งเป็น True.
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างโค้ดด้านล่างแสดงวิธีการ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**

ได้. ความโปร่งใสของการเติมและเส้นขอบสามารถกำหนดแยกกันได้ ซึ่งเป็นประโยชน์ในการทำให้กริดและข้อมูลอ่านง่ายขึ้นในภาพที่มีข้อมูลหนาแน่น

**How can I deal with data labels when they overlap?**

ลดขนาดฟอนต์, ปิดใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น หมวดหมู่), ตั้งค่าการชิด/ตำแหน่งของป้าย, แสดงป้ายเฉพาะจุดที่เลือกหากจำเป็น, หรือเปลี่ยนรูปแบบเป็น “ค่า + เลเจนด์”

**Can I apply gradient or pattern fills to series?**

ได้ ทั้งการเติมแบบสีเดียวและแบบไล่สี/ลวดลายมักจะพร้อมใช้งาน ในการปฏิบัติ ควรใช้ไล่สีอย่างระมัดระวังและหลีกเลี่ยงการผสมผสานที่ทำให้คอนทราสต์กับกริดและข้อความลดลง.