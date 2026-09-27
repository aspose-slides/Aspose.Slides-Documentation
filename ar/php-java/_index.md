---
title: Aspose.Slides لـ PHP عبر Java
second_title: Aspose.Slides لـ PHP
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
description: "ابدأ هنا: قم بتثبيت Aspose.Slides لـ PHP عبر Java، أنشئ أول عرض تقديمي، واعثر على الأدلة للمهام الشائعة، ومرجع API، والدعم."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP عبر Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP عبر Java هي مكتبة فئات لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument في تطبيقات PHP، دون الحاجة إلى Microsoft PowerPoint أو أتمتة Office.

تدعم تحميل وحفظ صيغ PPT وPPTX وPPS وPOT وODP، بما في ذلك المتغيرات المدعومة بالماكرو والقوالب، وتصدير إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/php-java/installation/">التثبيت</a></li>
<li><a href="/slides/ar/php-java/create-presentation/">إنشاء عرضك التقديمي الأول</a></li>
<li><a href="/slides/ar/php-java/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/php-java/supported-file-formats/">الصيغ المدعومة</a></li>
<li><a href="/slides/ar/php-java/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/php-java/licensing/">الترخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>إنشاء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/php-java/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/php-java/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/php-java/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/php-java/convert-slide/">تحويل الشرائح إلى صور</a></li>
<li><a href="/slides/ar/php-java/manage-text/">تحرير النص والأشكال</a></li>
</ul>
<p>سير عمل Slides</p>
<ul>
<li><a href="/slides/ar/php-java/powerpoint-charts/">المخططات</a></li>
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
<li><a href="https://reference.aspose.com/slides/ar/php-java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/ar/php-java/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/php-java/known-issues/">المشكلات المعروفة</a></li>
<li><a href="https://releases.aspose.com/slides/ar/php-java/">تحميل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ar/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب المساعدة للدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **العرض التقديمي الأول لك**

Aspose.Slides for PHP عبر Java تعمل على Java داخل Apache Tomcat، وتصل إليها سكريبتات PHP عبر PHP/Java Bridge. [التثبيت](/slides/ar/php-java/installation/) تقوم بإعداد PHP 8.3 أو أقدم، وJava، وTomcat والجسر، ثم تثبت الحزمة من Packagist في مجلد المشروع:

```bash
composer require aspose/slides
```

بعد ذلك انسخ ملف JAR الخاص بالحزمة إلى الجسر وأعد تشغيل Tomcat، كما هو موضح في الخطوة 4 من [التثبيت على لينكس](/slides/ar/php-java/installation/#install-on-linux) أو الخطوة 6 من [التثبيت على ويندوز](/slides/ar/php-java/installation/#install-on-windows). مع تشغيل Tomcat، احفظ هذا السكريبت باسم *hello.php* في مجلد المشروع وشغّله باستخدام `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ar/lib/aspose.slides.php");

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

يقوم السكريبت بحفظ *hello.pptx* بجواره، مع شريحة واحدة تحتوي على مربع نص. بدون ترخيص، يحتوي الملف المحفوظ على علامة مائية للتقييم — راجع [الترخيص](/slides/ar/php-java/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، انظر [إنشاء عروض تقديمية](/slides/ar/php-java/create-presentation/).