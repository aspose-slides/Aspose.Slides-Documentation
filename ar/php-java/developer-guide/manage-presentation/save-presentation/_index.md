---
title: حفظ العروض التقديمية في PHP
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/php-java/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تدفق
- نوع العرض المسبق التعريف
- تنسيق Office Open XML الصارم
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- PHP
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية باستخدام Aspose.Slides للـ PHP عبر Java — التصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات، الخطوط والتأثيرات."
---

## **نظرة عامة**

[فتح العروض التقديمية في PHP](/slides/ar/php-java/open-presentation/) يصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) لفتح عرض تقديمي. توضح هذه المقالة كيفية إنشاء العروض التقديمية وحفظها. فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) تحتوي على محتويات العرض التقديمي. سواء كنت تقوم بإنشاء عرض تقديمي من الصفر أو تعديل عرض موجود، سترغب في حفظه عند الانتهاء. مع Aspose.Slides للـ PHP، يمكنك الحفظ إلى **ملف** أو **دفق**. توضح هذه المقالة الطرق المختلفة لحفظ العرض التقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عبر استدعاء طريقة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) `save`. مرر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.
```php
// إنشاء كائن الفئة Presentation الذي يمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // قم ببعض العمل هنا...

    // حفظ العرض التقديمي إلى ملف.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **حفظ العروض التقديمية إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تدفق بتمرير تدفق إخراج إلى طريقة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) `save`. يمكن كتابة العرض إلى العديد من أنواع التدفقات. في المثال أدناه، ننشئ عرضًا تقديميًا جديدًا ونحفظه إلى تدفق ملف.
```php
// إنشاء كائن الفئة Presentation الذي يمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // حفظ العرض التقديمي إلى التدفق.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```


## **حفظ العروض التقديمية بنوع عرض مسبق التعريف**

تتيح لك Aspose.Slides تعيين طريقة العرض الأولية التي يستخدمها PowerPoint عند فتح العرض المولّد عبر فئة [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/). استخدم طريقة [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/#setLastView) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/).
```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **حفظ العروض التقديمية بصيغة Office Open XML الصارمة**

تتيح لك Aspose.Slides حفظ عرض تقديمي بصيغة Office Open XML الصارمة. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/) واضبط خاصية التوافق عند الحفظ. إذا قمت بتعيين [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/php-java/aspose.slides/conformance/#Iso29500_2008_Strict)، سيتم حفظ ملف الإخراج بصيغة Office Open XML الصارمة.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بصيغة Office Open XML الصارمة.
```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// إنشاء كائن الفئة Presentation الذي يمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // حفظ العرض التقديمي بتنسيق Office Open XML الصارم.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```


## **حفظ العروض التقديمية بصيغة Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا قدرها 4 GB (2^32 بايت) على الحجم غير المضغوط لأي ملف، الحجم المضغوط لأي ملف، وإجمالي حجم الأرشيف، كما يحد عدد الملفات إلى 65 535 (2^16‑1) ملفًا. تمددات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setZip64Mode) تتيح لك اختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأنماط التالية:

- [IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) يستخدم امتدادات ZIP64 فقط إذا تجاوز العرض التقديمي الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) لا يستخدم أبداً امتدادات ZIP64.
- [Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) دائمًا يستخدم امتدادات ZIP64.

يعرض الشيفرة التالية كيفية حفظ عرض تقديمي بصيغة PPTX مع تمكين امتدادات تنسيق ZIP64:
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="NOTE" color="warning" %}}
عند الحفظ باستخدام Zip64Mode.Never، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/) إذا تعذر حفظ العرض بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) تتحكم في إنشاء الصورة المصغرة عند حفظ عرض تقديمي إلى PPTX:

- إذا تم تعيينه إلى `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم تعيينه إلى `false`، يتم الحفاظ على الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لن يتم إنشاء أي صورة.

في الشيفرة أدناه، يتم حفظ العرض إلى PPTX دون تحديث صورته المصغرة.
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
يساعد هذا الخيار على تقليل الوقت اللازم لحفظ العرض بصيغة PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم بنسب مئوية**

يتم تكوين تقارير حفظ التقدم عبر طريقة [setProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setProgressCallback) على فئة [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) وفئاتها الفرعية. قدم وكيل Java ينفّذ واجهة [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/); خلال التصدير، يتلقى النداء التحديثات النسبية الدورية.

توضح مقتطفات الشيفرة التالية كيفية استخدام `IProgressCallback`.
```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // استخدم قيمة نسبة التقدم هنا.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
قامت Aspose بتطوير تطبيق مجاني لتقسيم PowerPoint باستخدام واجهتها البرمجية الخاصة. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم "الحفظ السريع" (الحفظ المتزايد) بحيث تُكتب التغييرات فقط؟**

لا. كل مرة يتم فيها الحفظ يُنشأ الملف الهدف بالكامل؛ الحفظ السريع (المُتزايد) غير مدعوم.

**هل يمكن حفظ نفس كائن Presentation من عدة خيوط بصورة آمنة؟**

لا. كائن Presentation غير آمن للاستخدام المتعدد الخيوط؛ احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

يتم الحفاظ على الروابط التشعبية. الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسَخ تلقائيًا—تأكد من بقاء المسارات المشار إليها متاحة.

**هل يمكنني ضبط/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. خصائص المستند القياسية مدعومة وستُكتب إلى الملف عند الحفظ.