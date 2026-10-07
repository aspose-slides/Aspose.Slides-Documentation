---
title: Aspose.Slides للـ PHP عبر Java
second_title: Aspose.Slides للـ PHP
type: docs
weight: 45
url: /ar/php-java/
keywords:
- توثيق
- معالجة العروض التقديمية
- تحويل العروض التقديمية
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "ابدأ هنا: ثبّت Aspose.Slides للـ PHP عبر Java، أنشئ عرضًا تقديميًا أولًا، واعثر على الأدلة للمهام الشائعة، ومرجع API والدعم."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java هي مكتبة فئات لإنشاء وقراءة وتعديل وتحويل عروض PowerPoint وOpenDocument في تطبيقات PHP، دون الحاجة إلى Microsoft PowerPoint أو Office Automation.

تقوم بتحميل وحفظ صيغ PPT وPPTX وPPS وPOT وODP، بما في ذلك المتغيرات المدعومة بالماكرو والقوالب، وتصدير إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/php-java/installation/">التثبيت</a></li>
<li><a href="/slides/ar/php-java/create-presentation/">إنشاء العرض التقديمي الأول لك</a></li>
<li><a href="/slides/ar/php-java/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/php-java/supported-file-formats/">صيغ الملفات المدعومة</a></li>
<li><a href="/slides/ar/php-java/evaluate-aspose-slides/">قيود التجربة</a></li>
<li><a href="/slides/ar/php-java/licensing/">الترخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>البناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/php-java/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/php-java/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/php-java/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/php-java/convert-slide/">عرض الشرائح كصور</a></li>
<li><a href="/slides/ar/php-java/manage-text/">تحرير النص والأشكال</a></li>
</ul>
<p>سير عمل الشرائح</p>
<ul>
<li><a href="/slides/ar/php-java/powerpoint-charts/">الرسوم البيانية</a></li>
<li><a href="/slides/ar/php-java/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/php-java/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/php-java/presentation-design/">تصميم الشريحة</a></li>
<li><a href="/slides/ar/php-java/merge-presentation/">دمج العروض التقديمية</a></li>
</ul>
<p>أمثلة</p>
<ul>
<li><a href="/slides/ar/php-java/examples/">أمثلة حسب عنصر الشريحة</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع والدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">ملاحظات الإصدارات</a></li>
<li><a href="/slides/ar/php-java/known-issues/">القضايا المعروفة</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">صفحة المنتج</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">تنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب مساعدة الدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **العرض التقديمي الأول الخاص بك**

Aspose.Slides for PHP via Java يعمل على Java داخل Apache Tomcat، وتصل إليه سكريبتات PHP عبر PHP/Java Bridge. [التثبيت](/slides/ar/php-java/installation/) يجهز PHP 8.3 أو أقدم، Java، Tomcat والجسر، ثم يثبت الحزمة من Packagist في مجلد المشروع:

```bash
composer require aspose/slides
```

ثم انسخ ملف JAR الخاص بالحزمة إلى الجسر وأعد تشغيل Tomcat، كما في الخطوة 4 من [التثبيت على لينكس](/slides/ar/php-java/installation/#install-on-linux) أو الخطوة 6 من [التثبيت على ويندوز](/slides/ar/php-java/installation/#install-on-windows). مع تشغيل Tomcat، احفظ هذا السكريبت باسم *hello.php* في مجلد المشروع وشغّـل `php hello.php`:

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

يحفظ السكريبت *hello.pptx* بجوار نفسه، مع شريحة واحدة تحتوي على مربع نص. بدون ترخيص، يحمل الملف المحفوظ علامة مائية تقييم — انظر [الترخيص](/slides/ar/php-java/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، راجع [إنشاء عروض تقديمية](/slides/ar/php-java/create-presentation/).