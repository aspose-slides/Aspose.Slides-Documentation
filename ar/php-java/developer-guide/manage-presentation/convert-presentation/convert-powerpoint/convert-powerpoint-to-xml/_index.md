---
title: تحويل عروض PowerPoint التقديمية إلى XML في PHP
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/php-java/convert-powerpoint-to-xml/
keywords:
- تحويل PowerPoint إلى XML
- تحويل العرض التقديمي إلى XML
- PPT إلى XML
- PPTX إلى XML
- ODP إلى XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- حفظ العرض التقديمي كـ XML
- تصدير العرض التقديمي إلى XML
- دفق XML
- PHP
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint وعروض OpenDocument التقديمية إلى ملفات أو تدفقات PowerPoint XML في PHP باستخدام Aspose.Slides for PHP عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for PHP via Java تحويل عروض PowerPoint التقديمية إلى صيغة PowerPoint XML Presentation. يعتبر إخراج XML مفيدًا عندما تحتاج إلى تمثيل نصي لتفحص بنية العرض، أو استكشاف المشكلات في المستندات المولدة، أو مقارنة الإخراج في الاختبارات الآلية، أو دمجه مع سير عمل يستهلك XML بدلاً من حزمة العرض.

استخدم الطريقة [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) مع القيمة `Xml` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/). يمكنك كتابة النتيجة مباشرةً إلى ملف أو إلى تدفق.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` ينشئ PowerPoint XML Presentation. لا يقوم باستخراج أجزاء Office Open XML الفردية المخزنة داخل حزمة PPTX. إذا كنت بحاجة إلى أجزاء حزمة PPTX الدقيقة، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص حزمة PPTX نفسها.
{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

حمِّل عرضًا تقديميًا مصدرًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، ثم مرّر مسار الإخراج والقيمة `SaveFormat::Xml` إلى [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). يمكن أن يكون المصدر بأي صيغة عرض مدعومة للتحميل، مثل PPT أو PPTX أو ODP.

المثال التالي يحول عرض PPTX إلى ملف XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **كتابة إخراج XML إلى تدفق**

استخدم النسخة التي تستقبل تدفقًا من [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) عندما يجب أن يبقى XML في الذاكرة أو يُمرَّر إلى مكوّن آخر، مثل خدمة ويب أو موفر تخزين أو خط أنابيب معالجة XML. المثال التالي يكتب النتيجة إلى [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) ويحصل على XML المُولد كمصفوفة بايت:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // تمرير $xmlBytes إلى المكوّن التالي في سير العمل.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

يقوم `ByteArrayOutputStream` بتخزين جميع البيانات المست生成ة في الذاكرة، لذلك لا يلزم إعادة تعيين الموضع قبل استدعاء `toByteArray`.

## **مقارنة XML مع صيغ العرض والصيغ المُصدَّرة**

اختر صيغة الإخراج وفقًا لكيفية استخدام النتيجة:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | فحص البنية، استكشاف المشكلات، مقارنة الإخراج المُولد، والتكامل القائم على XML |
| PPT (`.ppt`) | ملف عرض ثنائي قديم | التوافق مع سير عمل PowerPoint القديم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على عدة أجزاء | تحرير PowerPoint العادي وتبادل العروض التقديمية |
| PDF or TIFF | صفحات ثابتة التخطيط أو صورة متعددة الصفحات | العرض، الطباعة، والأرشفة |
| PNG, JPEG, or SVG | تمثيل مُرسوم لشرائح فردية | مصغرات، معاينات، وأصول الصور |
| HTML or HTML5 | إخراج عرض موجه للويب | عرض المتصفح والنشر على الويب |

على عكس PPT و PPTX، يُقصد من إخراج XML أساسًا للفحص وتدفقات العمل المعتمدة على البيانات. وعلى عكس PDF و TIFF و HTML وصيغ صور الشرائح، فهو يمثل بيانات العرض بدلاً من رسم الشرائح كصفحات أو أصول بصرية. تُظهر جدول [supported file formats](/slides/ar/php-java/supported-file-formats/) أن PowerPoint XML Presentation هو صيغة حفظ فقط، لذا لا تستخدمه عندما يتطلب سير العمل تحميل الملف المُصدَّر مرة أخرى إلى Aspose.Slides للتحرير المستمر.

## **الأسئلة الشائعة**

**هل `SaveFormat::Xml` هو نفسه حفظ ملف PPTX؟**  
لا. PPTX هي حزمة تحتوي على عدة أجزاء Office Open XML، بينما `SaveFormat::Xml` ينشئ ملف PowerPoint XML Presentation.

**هل يمكنني حفظ إخراج XML دون إنشاء ملف على القرص؟**  
نعم. مرّر تدفقًا قابلًا للكتابة إلى [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). على سبيل المثال، استخدم [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المُصدَّر مرة أخرى؟**  
لا. PowerPoint XML Presentation مدعومة حاليًا للحفظ فقط وليس للتحميل. استخدم PPTX أو أي صيغة عرض مدعومة أخرى عندما تكون الحاجة إلى تحرير ذهابًا وإيابًا.

**هل يتحول XML كل شريحة إلى صفحة أو صورة؟**  
لا. تحويل XML يكتب بيانات عرض هيكلية. استخدم PDF أو TIFF لإخراج موجه للصفحات، أو PNG أو JPEG أو SVG لصور الشرائح الفردية.