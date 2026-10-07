---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
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
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for PHP via Java, สร้างการนำเสนอแรก, และค้นหาไกด์สำหรับงานทั่วไป, เอกสารอ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java เป็นไลบรารีคลาสสำหรับสร้าง, อ่าน, แก้ไข และแปลงงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน PHP โดยไม่ต้องใช้ Microsoft PowerPoint หรือ Office Automation.

ไลบรารีสามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีแมคโครและเทมเพลต และสามารถส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพได้.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นการใช้งาน</p>
<ul>
<li><a href="/slides/th/php-java/installation/">การติดตั้ง</a></li>
<li><a href="/slides/th/php-java/create-presentation/">สร้างงานนำเสนอแรกของคุณ</a></li>
<li><a href="/slides/th/php-java/getting-started/">คู่มือเริ่มต้นการใช้งาน</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/php-java/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/php-java/evaluate-aspose-slides/">ข้อจำกัดของรุ่นทดลอง</a></li>
<li><a href="/slides/th/php-java/licensing/">การให้ลิขสิทธิ์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/php-java/open-presentation/">เปิดงานนำเสนอ</a></li>
<li><a href="/slides/th/php-java/save-presentation/">บันทึกงานนำเสนอ</a></li>
<li><a href="/slides/th/php-java/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/php-java/convert-slide/">แปลงสไลด์เป็นภาพ</a></li>
<li><a href="/slides/th/php-java/manage-text/">แก้ไขข้อความและรูปทรง</a></li>
</ul>
<p>ขั้นตอนงาน Slides</p>
<ul>
<li><a href="/slides/th/php-java/powerpoint-charts/">แผนภูมิ</a></li>
<li><a href="/slides/th/php-java/powerpoint-animation/">แอนิเมชัน</a></li>
<li><a href="/slides/th/php-java/manage-media-files/">เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/php-java/presentation-design/">การออกแบบสไลด์</a></li>
<li><a href="/slides/th/php-java/merge-presentation/">รวมงานนำเสนอ</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/php-java/examples/">ตัวอย่างตามองค์ประกอบสไลด์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและการสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">อ้างอิง API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">บันทึกเวอร์ชัน</a></li>
<li><a href="/slides/th/php-java/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">หน้าผลิตภัณฑ์</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">ดาวน์โหลด</a></li>
</ul>
<p>การสนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **งานนำเสนอแรกของคุณ**

Aspose.Slides for PHP via Java ทำงานบน Java ภายใน Apache Tomcat และสคริปต์ PHP ของคุณจะเชื่อมต่อผ่าน PHP/Java Bridge. [การติดตั้ง](/slides/th/php-java/installation/) ตั้งค่า PHP 8.3 หรือรุ่นก่อนหน้า, Java, Tomcat และบริดจ์, และจากนั้นติดตั้งแพคเกจจาก Packagist ในโฟลเดอร์โปรเจกต์:

```bash
composer require aspose/slides
```

จากนั้นคัดลอกไฟล์ JAR ของแพคเกจไปยังบริดจ์และรีสตาร์ท Tomcat ตามขั้นตอนที่ 4 ของ [การติดตั้งบน Linux](/slides/th/php-java/installation/#install-on-linux) หรือขั้นตอนที่ 6 ของ [การติดตั้งบน Windows](/slides/th/php-java/installation/#install-on-windows). เมื่อ Tomcat ทำงานอยู่, บันทึกสคริปต์นี้เป็น *hello.php* ในโฟลเดอร์โปรเจกต์และรัน `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

สคริปต์บันทึกไฟล์ *hello.pptx* ข้างไฟล์เดียวกัน, มีสไลด์หนึ่งสไลด์ที่มีกล่องข้อความ. หากไม่มีลิขสิทธิ์, ไฟล์ที่บันทึกจะมีลายน้ำการประเมิน — ดูที่ [การให้ลิขสิทธิ์](/slides/th/php-java/licensing/). สำหรับวิธีอื่น ๆ ในการสร้างและเติมข้อมูลงานนำเสนอ, ดูที่ [สร้างงานนำเสนอ](/slides/th/php-java/create-presentation/).