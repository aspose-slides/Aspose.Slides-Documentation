---
title: Aspose.Slides สำหรับ PHP ผ่าน Java
second_title: Aspose.Slides สำหรับ PHP
type: docs
weight: 45
url: /th/php-java/
keywords:
- เอกสาร
- การประมวลผลการนำเสนอ
- การแปลงการนำเสนอ
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for PHP via Java, สร้างการนำเสนอแรก, และค้นหาคู่มือสำหรับงานทั่วไป, การอ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides สำหรับ PHP ผ่าน Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java เป็นไลบรารีคลาสสำหรับสร้าง, อ่าน, แก้ไขและแปลงการนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน PHP โดยไม่ต้องใช้ Microsoft PowerPoint หรือ Office Automation.

ไลบรารีนี้สามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีแมโครและแม่แบบ, และส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพ.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นใช้งาน</p>
<ul>
<li><a href="/slides/th/php-java/installation/">การติดตั้ง</a></li>
<li><a href="/slides/th/php-java/create-presentation/">สร้างการนำเสนอแรกของคุณ</a></li>
<li><a href="/slides/th/php-java/getting-started/">คู่มือเริ่มต้นใช้งาน</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/php-java/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/php-java/evaluate-aspose-slides/">ข้อจำกัดของรุ่นทดลอง</a></li>
<li><a href="/slides/th/php-java/licensing/">การออกใบอนุญาต</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/php-java/open-presentation/">เปิดการนำเสนอ</a></li>
<li><a href="/slides/th/php-java/save-presentation/">บันทึกการนำเสนอ</a></li>
<li><a href="/slides/th/php-java/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/php-java/convert-slide/">เรนเดอร์สไลด์เป็นรูปภาพ</a></li>
<li><a href="/slides/th/php-java/manage-text/">แก้ไขข้อความและรูปร่าง</a></li>
</ul>
<p>เวิร์กโฟลว์ของ Slides</p>
<ul>
<li><a href="/slides/th/php-java/powerpoint-charts/">แผนภูมิ</a></li>
<li><a href="/slides/th/php-java/powerpoint-animation/">การเคลื่อนไหว</a></li>
<li><a href="/slides/th/php-java/manage-media-files/">เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/php-java/presentation-design/">การออกแบบสไลด์</a></li>
<li><a href="/slides/th/php-java/merge-presentation/">รวมการนำเสนอ</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/php-java/examples/">ตัวอย่างตามองค์ประกอบสไลด์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิง &amp; สนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">อ้างอิง API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">บันทึกการเผยแพร่</a></li>
<li><a href="/slides/th/php-java/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">ดาวน์โหลด</a></li>
</ul>
<p>การสนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือสนับสนุนแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **การนำเสนอแรกของคุณ**

Aspose.Slides for PHP via Java ทำงานบน Java ภายใน Apache Tomcat และสคริปต์ PHP ของคุณเข้าถึงผ่าน PHP/Java Bridge. [การติดตั้ง](/slides/th/php-java/installation/) ตั้งค่า PHP 8.3 หรือรุ่นก่อนหน้า, Java, Tomcat และบริดจ์, จากนั้นติดตั้งแพ็กเกจจาก Packagist ในโฟลเดอร์โครงการ:

```bash
composer require aspose/slides
```

จากนั้นคัดลอกไฟล์ JAR ของแพ็กเกจเข้าสู่บริดจ์และรีสตาร์ท Tomcat, ตามขั้นตอนที่ 4 ของ [การติดตั้งบน Linux](/slides/th/php-java/installation/#install-on-linux) หรือขั้นตอนที่ 6 ของ [การติดตั้งบน Windows](/slides/th/php-java/installation/#install-on-windows). เมื่อ Tomcat กำลังทำงาน, บันทึกสคริปต์นี้เป็น *hello.php* ในโฟลเดอร์โครงการและเรียกใช้ `php hello.php`:

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

สคริปต์นี้บันทึก *hello.pptx* อยู่ใกล้ ๆ กับตัวมันเอง, พร้อมสไลด์หนึ่งที่มีกล่องข้อความ. หากไม่มีใบอนุญาต, ไฟล์ที่บันทึกจะมีลายน้ำประเมิน — ดู [การออกใบอนุญาต](/slides/th/php-java/licensing/). สำหรับวิธีเพิ่มเติมในการสร้างและเติมข้อมูลการนำเสนอ, ดู [สร้างการนำเสนอ](/slides/th/php-java/create-presentation/).