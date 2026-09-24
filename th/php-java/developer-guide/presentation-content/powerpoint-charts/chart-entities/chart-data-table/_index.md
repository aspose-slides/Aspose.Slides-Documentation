---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอด้วย PHP
linktitle: ตารางข้อมูล
type: docs
url: /th/php-java/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติของฟอนต์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ปรับแต่งฟอนต์, เส้นขอบ และคีย์คำอธิบายของตารางข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ช่วยให้คุณแสดงตารางข้อมูลของแผนภูมิและปรับแต่งการจัดรูปแบบข้อความ, เส้นขอบ, และคีย์คำอธิบาย. บทความนี้อธิบายวิธีเปิดใช้งานตาราง, จัดรูปแบบข้อความ, ควบคุมแต่ละประเภทของเส้นขอบ, และแสดงหรือซ่อนคีย์คำอธิบาย. ตัวอย่างจะบันทึกแผนภูมิที่กำหนดค่าไว้ในไฟล์ PPTX.

## **ตั้งค่าคุณสมบัติของฟอนต์**

เพื่อแสดงตารางข้อมูลของแผนภูมิ, ส่งค่า `true` ไปยัง [setDataTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/setdatatable/). ใช้ [getChartDataTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/getchartdatatable/) เพื่อเข้าถึงตารางและกำหนดการจัดรูปแบบข้อความ.

1. โหลดงานพรีเซนเทชั่นโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มลงในสไลด์แรก.
1. เปิดใช้งานตารางข้อมูลของแผนภูมิ.
1. เปิดใช้งานข้อความหนาด้วย [setFontBold](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontBold) และส่งค่า `20` ไปยัง [setFontHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อใช้ข้อความขนาด 20 จุด.
1. บันทึกงานพรีเซนเทชั่นที่แก้ไขแล้ว.

ตัวอย่างต่อไปนี้ต้องการไฟล์ `test.pptx` ในไดเรกทอรีทำงานที่มีอย่างน้อยหนึ่งสไลด์. มันเพิ่มแผนภูมิด้วยข้อมูลค่าเริ่มต้นที่ตำแหน่ง (50, 50) โดยมีความกว้าง 600 จุดและความสูง 400 จุด. ไฟล์ `output.pptx` ที่บันทึกไว้จะมีแผนภูมิพร้อมตารางข้อมูลที่เปิดใช้งานและการตั้งค่าแบบอักษรที่ระบุ.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ปรับแต่งเส้นขอบของตารางข้อมูล**

เปิดใช้งานตารางด้วย [Chart::setDataTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/setdatatable/) และเข้าถึงมันผ่าน [Chart::getChartDataTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/getchartdatatable/). คุณสามารถควบคุมสามประเภทของเส้นขอบได้อย่างอิสระ:

- [setBorderHorizontal](https://reference.aspose.com/slides/th/php-java/aspose.slides/datatable/setborderhorizontal/) ควบคุมเส้นขอบแนวนอนของเซลล์.
- [setBorderVertical](https://reference.aspose.com/slides/th/php-java/aspose.slides/datatable/setbordervertical/) ควบคุมเส้นขอบแนวตั้งของเซลล์.
- [setBorderOutline](https://reference.aspose.com/slides/th/php-java/aspose.slides/datatable/setborderoutline/) ควบคุมเส้นขอบภายนอกของตาราง.

ส่งค่า `true` ไปยังแต่ละเมธอดเพื่อแสดงเส้นขอบหรือ `false` เพื่อซ่อนเส้นขอบ. ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลค่าเริ่มต้น, แสดงเส้นขอบแนวนอนและเส้นขอบภายนอก, และซ่อนเส้นขอบแนวตั้ง. ไม่ต้องใช้ไฟล์เข้าขา. ตำแหน่งและขนาดของแผนภูมิระบุเป็นจุด.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การเปรียบเทียบด้านล่างใช้ข้อมูลแผนภูมิและการตั้งค่าคีย์คำอธิบายเดียวกันในสี่กรณี. เริ่มจากเปิดใช้งานเส้นขอบทั้งหมด, แต่ละตัวแปรที่เหลือจะปิดการตั้งค่าเส้นขอบเพียงประเภทเดียว. ตัวแปรมุมซ้ายล่างตรงกับการตั้งค่าเส้นขอบในตัวอย่าง.

![ตารางข้อมูลแผนภูมิที่มีเส้นขอบทั้งหมดเปิดใช้งาน, ไม่มีเส้นขอบแนวนอน, ไม่มีเส้นขอบแนวตั้ง, และไม่มีเส้นขอบภายนอก](data-table-borders.png)

## **แสดงหรือซ่อนคีย์คำอธิบาย**

คีย์คำอธิบายคือสัญลักษณ์สีเล็ก ๆ ข้างชื่อซีรีส์ในตารางข้อมูล. พวกมันช่วยให้ผู้อ่านจับคู่แต่ละแถวของตารางกับซีรีส์ของแผนภูมิ. ส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/php-java/aspose.slides/datatable/setshowlegendkey/) เพื่อแสดงสัญลักษณ์เหล่านี้หรือ `false` เพื่อซ่อน.

คำอธิบายแยกของแผนภูมิควบคุมโดย [Chart::setLegend](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/setlegend/). การตั้งค่าเหล่านี้ทำงานแยกจากกัน: การซ่อนคำอธิบายแยกจะไม่ทำให้คีย์ในตารางข้อมูลหายไป, และการซ่อนคีย์ในตารางจะไม่ทำให้คำอธิบายแยกหายไป.

ตัวอย่างต่อไปนี้สร้างแผนภูมิกับข้อมูลค่าเริ่มต้น, เปิดใช้งานตารางข้อมูล, และแสดงคีย์คำอธิบายภายในตารางขณะซ่อนคำอธิบายแยก. เส้นขอบตารางทั้งหมดเปิดใช้งานอย่างชัดเจน. ไม่ต้องใช้งานพรีเซนเทชั่นเข้าขา. เพื่อซ่อนคีย์ของตารางเท่านั้น, ส่งค่า `false` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การเปรียบเทียบด้านล่างแสดงตารางเดียวกันที่เปิดและปิดคีย์คำอธิบาย. เส้นขอบทั้งหมดยังคงเปิดอยู่, และคำอธิบายแผนภูมิเสริมถูกซ่อนในทั้งสองกรณี.

![ตารางข้อมูลแผนภูมิโดยคีย์คำอธิบายแสดงที่ซ้ายและซ่อนที่ขวา](data-table-legend-keys.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่. ส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/php-java/aspose.slides/datatable/setshowlegendkey/) เพื่อแสดงคีย์คำอธิบายหรือ `false` เพื่อซ่อน.

**ตารางข้อมูลจะถูกเก็บไว้เมื่อนำเสนอออกเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ใช่. Aspose.Slides จะเรนเดอร์แผนภูมิและตารางข้อมูลที่แสดงเป็นส่วนหนึ่งของสไลด์เมื่อส่งออกเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/th/php-java/convert-powerpoint-to-html/), หรือ [images](/slides/th/php-java/convert-powerpoint-to-png/).

**ฉันสามารถทำงานกับตารางข้อมูลในแผนภูมิที่โหลดจากเทมเพลตได้หรือไม่?**

ใช่. สำหรับแผนภูมิที่โหลดจากงานพรีเซนเทชั่นหรือเทมเพลตที่มีอยู่, ใช้ [hasDataTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/hasdatatable/) และ [setDataTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/setdatatable/) เพื่อตรวจสอบหรือเปลี่ยนแปลงว่าตารางข้อมูลของมันแสดงหรือไม่.

**ฉันจะค้นหาแผนภูมิที่เปิดใช้งานตารางข้อมูลได้อย่างไร?**

วนผ่านรูปร่างบนแต่ละสไลด์, ระบุแผนภูมิ, และเรียกเมธอด [hasDataTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/hasdatatable/) ของพวกมัน. ค่า `true` บ่งบอกว่าตารางข้อมูลได้รับการเปิดใช้งาน.