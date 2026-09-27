---
title: إنشاء عروض تقديمية في PHP
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/php-java/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء عروض تقديمية باستخدام Aspose.Slides للـ PHP عبر Java — إنتاج ملفات PPT و PPTX و ODP وحفظها برمجيًا للحصول على نتائج موثوقة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء عرض تقديمي في Aspose.Slides، وإضافة صندوق نص إلى الشريحة الأولى، وحفظ النتيجة كملف. كما تُظهر كيفية إنشاء عرض تقديمي فارغ وحفظه، وكيفية فتح عرض تقديمي موجود بتنسيق مدعوم وحفظه بتنسيق آخر. يغطي قسم الأسئلة المتكررة القصير في النهاية الأسئلة الشائعة حول التنسيقات والقوالب وحجم الشرائح والوحدات واستخدام الذاكرة والخيوط والترخيص والتوقيعات الرقمية ودعم VBA.

قبل البدء، قم بتثبيت Aspose.Slides for PHP عبر Java باستخدام Composer وابدأ جسر PHP/Java في Apache Tomcat. راجع [Installation](/slides/ar/php-java/installation/) للإعداد الكامل. تتوقع الأمثلة أدناه أن يكون Tomcat يعمل على `localhost:8080` ومجلد Composer `vendor` بجوار السكريبت.

## **إنشاء عرض تقديمي PowerPoint**

لإنشاء عرض تقديمي ووضع صندوق نص على شريحته الأولى، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) . يحتوي العرض التقديمي الجديد بالفعل على شريحة فارغة واحدة.
2. احصل على تلك الشريحة من المجموعة التي تُرجعها [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/)، باستخدام فهرسها 0.
3. أضف مستطيلًا باستخدام الطريقة [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/)، واضبط نصه باستخدام [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/).
4. احفظ العرض التقديمي كملف PPTX باستخدام الطريقة [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) .

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

السطران `require_once` يقومان بتحميل عميل PHP/Java Bridge من Tomcat وفئات Aspose.Slides من حزمة Composer. زاوية المستطيل العلوية اليسرى تقع على بُعد 50 نقطة من الحافة اليسرى و50 نقطة من الحافة العليا للشريحة، وعرض المستطيل 400 نقطة وارتفاعه 100 نقطة. يحتوي الملف المحفوظ على شريحة واحدة تحتوي على ذلك المستطيل ونصه. بدون ترخيص، يضيف Aspose.Slides أيضًا علامة مائية للتقييم إلى كل شريحة يتم حفظها؛ راجع [Licensing](/slides/ar/php-java/licensing/).

{{% alert color="info" title="Note" %}}
يقوم Aspose.Slides بقراءة وكتابة الملفات داخل Tomcat، وليس في عملية PHP الخاصة بك، لذا يتم حل المسار النسبي مثل `"hello.pptx"` بالنسبة لمجلد العمل في Tomcat. تُنشئ الأمثلة في هذه الصفحة مسارات مطلقة باستخدام `__DIR__`، لذلك تُقرأ الملفات وتُحفظ بجوار السكريبت.
{{% /alert %}}

## **إنشاء وحفظ عرض تقديمي**

لإنشاء عرض تقديمي فارغ وحفظه، أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ، واحفظه بأي تنسيق من تعداد [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) . النتيجة هي عرض تقديمي يحتوي على شريحة فارغة واحدة.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ar/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **فتح وحفظ عرض تقديمي**

لتحويل عرض تقديمي من تنسيق إلى آخر، افتحه بتمرير مساره إلى مكتّب [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ، ثم احفظه بالتنسيق الهدف. يكتشف Aspose.Slides تنسيق الإدخال، مثل PPT أو PPTX أو ODP، من الملف نفسه.

يتوقع المثال أدناه وجود عرض تقديمي OpenDocument باسم *Sample.odp* بجوار السكريبت ويحفظه كـ PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ar/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

### ما هي التنسيقات التي يمكنني حفظ عرض تقديمي جديد إليها؟

يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/php-java/save-presentation/)، وتصدير إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/php-java/convert-powerpoint-to-xps/), [HTML](/slides/ar/php-java/convert-powerpoint-to-html/), [SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/), و[الصور](/slides/ar/php-java/convert-powerpoint-to-png/), وغيرها.

### هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟

نعم. قم بتحميل القالب واحفظه بالتنسيق المطلوب؛ تنسيقات POTX/POTM/PPTM وما شابهها [مدعومة](/slides/ar/php-java/supported-file-formats/).

### كيف يمكنني التحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟

قم بتعيين [حجم الشريحة](/slides/ar/php-java/slide-size/) (بما في ذلك القوالب المسبقة مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر طريقة تكبير المحتوى.

### بأي وحدات يتم قياس الأحجام والإحداثيات؟

بالنقاط: 1 إنش يساوي 72 وحدة.

### كيف يمكنني التعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟

استخدم [استراتيجيات إدارة BLOB](/slides/ar/php-java/manage-blob/)، قيّد التخزين في الذاكرة باستخدام ملفات مؤقتة، وفضّل سير عمل قائم على الملفات بدلاً من التدفقات داخل الذاكرة فقط.

### هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازٍ؟

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/php-java/multithreading/). شغّل مث-instances منفصلة ومعزولة لكل خيط أو عملية.

### كيف يمكنني إزالة علامة التجربة المائية والقيود؟

[قم بتطبيق ترخيص](/slides/ar/php-java/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف ترخيص XML دون تعديل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

### هل يمكنني توقيع PPTX الذي أنشأه رقمياً؟

نعم. [التوقيع الرقمي](/slides/ar/php-java/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعوم للعرض التقديمي.

### هل تدعم العروض المقدمة الماكرو (VBA)؟

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/php-java/presentation-via-vba/) وحفظ ملفات مفعلة للماكرو مثل PPTM/PPSM.