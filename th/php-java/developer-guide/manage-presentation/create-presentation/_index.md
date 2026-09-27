---
title: สร้างงานนำเสนอใน PHP
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/php-java/create-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างงานนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java — สร้างไฟล์ PPT, PPTX และ ODP และบันทึกโดยอัตโนมัติเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานพรีเซนเทชันใน Aspose.Slides, เพิ่มกล่องข้อความในสไลด์แรกของมัน, และบันทึกผลลัพธ์เป็นไฟล์ นอกจากนี้ยังแสดงวิธีสร้างและบันทึกงานพรีเซนเทชันเปล่า, และวิธีเปิดงานพรีเซนเทชันที่มีอยู่ในรูปแบบที่รองรับและบันทึกเป็นรูปแบบอื่น ส่วนคำถามที่พบบ่อยสั้นๆ ที่ส่วนท้ายครอบคลุมคำถามทั่วไปเกี่ยวกับรูปแบบ, เทมเพลต, ขนาดสไลด์, หน่วยวัด, การใช้หน่วยความจำ, การทำงานหลายเธรด, ลิขสิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA.

ก่อนเริ่ม, ให้ติดตั้ง Aspose.Slides for PHP ผ่าน Java ด้วย Composer และเริ่ม PHP/Java Bridge ใน Apache Tomcat ดูที่ [การติดตั้ง](/slides/th/php-java/installation/) สำหรับการตั้งค่าที่สมบูรณ์ ตัวอย่างด้านล่างคาดว่า Tomcat จะทำงานที่ `localhost:8080` และโฟลเดอร์ `vendor` ของ Composer อยู่ข้างสคริปต์

## **สร้างงานนำเสนอ PowerPoint**

เพื่อสร้างงานพรีเซนเทชันและใส่กล่องข้อความในสไลด์แรก, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) งานพรีเซนเทชันใหม่จะมีสไลด์เปล่า 1 แท่งอยู่แล้ว
2. ดึงสไลด์นั้นจากคอลเลกชันที่คืนโดย [Presentation::getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getslides/), โดยใช้ดัชนี 0
3. เพิ่มสี่เหลี่ยมโดยใช้เมธอด [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addautoshape/) และกำหนดข้อความของมันด้วย [TextFrame::setText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/settext/)
4. บันทึกงานพรีเซนเทชันเป็นไฟล์ PPTX ด้วยเมธอด [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/save/)

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/th/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สองบรรทัด `require_once` โหลดไคลเอนต์ PHP/Java Bridge จาก Tomcat และคลาสต่างๆ ของ Aspose.Slides จากแพคเกจ Composer จุดมุมซ้ายบนของสี่เหลี่ยมอยู่ห่างจากขอบซ้าย 50 พอยท์และจากขอบบน 50 พอยท์, ความกว้างของสี่เหลี่ยมคือ 400 พอยท์และความสูง 100 พอยท์ ไฟล์ที่บันทึกจะมีสไลด์หนึ่งที่มีสี่เหลี่ยมและข้อความของมัน หากไม่มีใบอนุญาต, Aspose.Slides จะเพิ่มลายน้ำการประเมินผลบนทุกสไลด์ที่บันทึก; ดูที่ [ใบอนุญาต](/slides/th/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides อ่านและเขียนไฟล์ภายใน Tomcat ไม่ได้ในกระบวนการ PHP ของคุณ ดังนั้นเส้นทางเชิงสัมพันธ์เช่น `"hello.pptx"` จะถูกแก้ไขโดยอ้างอิงโฟลเดอร์ทำงานของ Tomcat ตัวอย่างในหน้านี้สร้างเส้นทางเต็มด้วย `__DIR__` ดังนั้นไฟล์จะถูกอ่านและบันทึกอยู่ข้างสคริปต์
{{% /alert %}}

## **สร้างและบันทึกงานพรีเซนเทชัน**

เพื่อสร้างงานพรีเซนเทชันเปล่าและบันทึก, สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วบันทึกในรูปแบบใดก็ได้ของ enumeration [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) ผลลัพธ์จะเป็นงานพรีเซนเทชันที่มีสไลด์เปล่า 1 แท่ง

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/th/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เปิดและบันทึกงานพรีเซนเทชัน**

เพื่อแปลงงานพรีเซนเทชันจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง, เปิดมันโดยส่งพาธของไฟล์ไปยังคอนสตรักเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) จากนั้นบันทึกในรูปแบบเป้าหมาย Aspose.Slides จะตรวจจับรูปแบบอินพุต เช่น PPT, PPTX หรือ ODP จากไฟล์โดยตรง

ตัวอย่างด้านล่างคาดว่าไฟล์งานพรีเซนเทชัน OpenDocument ชื่อ *Sample.odp* อยู่ข้างสคริปต์และบันทึกเป็น PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/th/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

### ฉันสามารถบันทึกงานพรีเซนเทชันใหม่เป็นรูปแบบใดได้บ้าง?

คุณสามารถบันทึกเป็น [PPTX, PPT, และ ODP](/slides/th/php-java/save-presentation/), และส่งออกเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/php-java/convert-powerpoint-to-xps/), [HTML](/slides/th/php-java/convert-powerpoint-to-html/), [SVG](/slides/th/php-java/render-a-slide-as-an-svg-image/), และ [รูปภาพ](/slides/th/php-java/convert-powerpoint-to-png/), เป็นต้น.

### ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?

ได้. โหลดเทมเพลตและบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบ POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [ได้รับการสนับสนุน](/slides/th/php-java/supported-file-formats/).

### ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานพรีเซนเทชันอย่างไร?

ตั้งค่า [ขนาดสไลด์](/slides/th/php-java/slide-size/) (รวมถึงพรีเซ็ตเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีที่เนื้อหาควรสเกล.

### ขนาดและพิกัดวัดเป็นหน่วยอะไร?

เป็นพอยท์: 1 นิ้วเท่ากับ 72 หน่วย.

### ฉันจะจัดการงานพรีเซนเทชันขนาดใหญ่มาก (ที่มีไฟล์สื่อหลายไฟล์) เพื่อลดการใช้หน่วยความจำอย่างไร?

ใช้ [กลยุทธ์การจัดการ BLOB](/slides/th/php-java/manage-blob/), จำกัดการเก็บข้อมูลในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และควรใช้กระบวนการทำงานแบบไฟล์เป็นหลักแทนสตรีมที่อยู่ในหน่วยความจำเต็ม.

### ฉันสามารถสร้าง/บันทึกงานพรีเซนเทชันพร้อมกันได้หรือไม่?

คุณไม่สามารถทำงานกับอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เดียวจาก [หลายเธรด](/slides/th/php-java/multithreading/) ได้. ให้รันอินสแตนซ์แยกต่างหากสำหรับแต่ละเธรดหรือกระบวนการ.

### ฉันจะลบลายน้ำและข้อจำกัดของเวอร์ชันทดลองอย่างไร?

[ใช้ใบอนุญาต](/slides/th/php-java/licensing/) เพียงครั้งเดียวต่อกระบวนการ. ไฟล์ XML ของใบอนุญาตต้องไม่ถูกแก้ไข, และการตั้งค่าใบอนุญาตควรทำให้สอดคล้องกันหากมีหลายเธรด.

### ฉันสามารถใส่ลายเซ็นดิจิทัลใน PPTX ที่สร้างได้ไหม?

ได้. [ลายเซ็นดิจิทัล](/slides/th/php-java/digital-signature-in-powerpoint/) (การเพิ่มและตรวจสอบ) ได้รับการสนับสนุนสำหรับงานพรีเซนเทชัน.

### งานพรีเซนเทชันที่สร้างขึ้นรองรับมาโคร (VBA) หรือไม่?

ได้. คุณสามารถ [สร้าง/แก้ไขโปรเจกต์ VBA](/slides/th/php-java/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานมาโครเช่น PPTM/PPSM.