---
title: "حفظ العروض التقديمية في PHP"
linktitle: "حفظ العرض التقديمي"
type: docs
weight: 80
url: /ar/php-java/save-presentation/
keywords:
- "حفظ PowerPoint"
- "حفظ OpenDocument"
- "حفظ العرض التقديمي"
- "حفظ الشريحة"
- "حفظ PPT"
- "حفظ PPTX"
- "حفظ ODP"
- "العرض التقديمي إلى ملف"
- "العرض التقديمي إلى تيار"
- "نوع عرض محدد مسبقًا"
- "تنسيق Strict Office Open XML"
- "وضع Zip64"
- "تحديث الصورة المصغرة"
- "حفظ التقدم"
- "PHP"
- "Aspose.Slides"
description: "اكتشف كيفية حفظ العروض التقديمية باستخدام Aspose.Slides لـ PHP عبر Java — التصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---
## **نظرة عامة**

[Open Presentations in PHP](/slides/ar/php-java/open-presentation/) تم وصفه كيف يتم استخدام فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) لفتح عرض تقديمي. تشرح هذه المقالة كيفية إنشاء العروض التقديمية وحفظها. فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) تحتوي على محتويات العرض التقديمي. سواء كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل أحد العروض الموجودة، فستحتاج إلى حفظه عندما تنتهي. باستخدام Aspose.Slides لـ PHP، يمكنك الحفظ إلى **ملف** أو **تيار**. تشرح هذه المقالة الطرق المختلفة لحفظ عرض تقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). مرر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // قم ببعض الأعمال هنا...

    // احفظ العرض التقديمي إلى ملف.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية إلى تيارات**

يمكنك حفظ عرض تقديمي إلى تيار بتمرير تيار إخراج إلى طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). يمكن كتابة العرض التقديمي إلى أنواع متعددة من التيارات. في المثال أدناه، ننشئ عرضًا تقديميًا جديدًا ونحفظه إلى تيار ملف.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // احفظ العرض التقديمي إلى التيار.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يسمح لك Aspose.Slides بتعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض التقديمي الذي تم إنشاؤه عبر فئة [ViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/). استخدم طريقة [setLastView](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/#setLastView) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية بتنسيق Strict Office Open XML**

يسمح لك Aspose.Slides بحفظ عرض تقديمي بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/) وحدد خاصية التوافق عند الحفظ. إذا قمت بتعيين [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/php-java/aspose.slides/conformance/#Iso29500_2008_Strict)، سيتم حفظ ملف الإخراج بتنسيق Strict Office Open XML.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بتنسيق Strict Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation();
try {
    // حفظ العرض التقديمي بتنسيق Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا قدرها 4 GB (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم أي ملف مضغوط، وإجمالي حجم الأرشيف، ويقيد الأرشيف بـ 65 535 (2^16‑1) ملفًا. تمتد تنسيقات ZIP64 لرفع هذه الحدود إلى 2^64.

تتيح طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/#setZip64Mode) لك اختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأوضاع التالية:

- [IfNecessary](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zip64mode/#IfNecessary) يستخدم امتدادات تنسيق ZIP64 فقط إذا تجاوز العرض التقديمي القيود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zip64mode/#Never) لا يستخدم امتدادات تنسيق ZIP64 أبداً.
- [Always](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zip64mode/#Always) يستخدم امتدادات تنسيق ZIP64 دائماً.

الكود التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات تنسيق ZIP64:

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
عند الحفظ باستخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zip64mode/#Never)، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

عند التعامل مع عروض تقديمية كبيرة، يمكنك ضبط مستوى الضغط لتحقيق التوازن بين حجم الملف ووقت المعالجة. حسب متطلباتك، قد تفضّل معالجة أسرع أو ملفات أصغر.

توفر Aspose.Slides طريقة [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/#setCompressionLevel) التي تسمح لك بتحديد مستوى الضغط المستخدم عند حفظ عرض تقديمي بتنسيق Office Open XML.

المستويات المتاحة للضغط هي:

- [**None**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#None): لا يتم تطبيق أي ضغط. تُحفظ الملفات كما هي.
- [**Level1**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level1): أسرع ضغط بأقل نسبة ضغط.
- [**Level2**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level2): ضغط أسرع مع نسبة ضغط أفضل قليلاً من **Level1**.
- [**Level3**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level3): يوفر ضغطًا أفضل من **Level2** مع تأثير متوسط على وقت المعالجة.
- [**Level4**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level4): يوفر ضغطًا أفضل من **Level3**.
- [**Level5**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level5): يحسن الضغط مقارنةً بـ **Level4** مع وقت معالجة إضافي.
- [**Level6**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level6): ضغط قياسي يوفّر توازنًا جيدًا بين سرعة المعالجة وحجم الملف. هذا هو *مستوى الضغط الافتراضي*.
- [**Level7**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level7): يوفر ضغطًا أفضل من **Level6** مع معالجة أبطأ.
- [**Level8**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level8): يوفر ضغطًا أفضل من **Level7**.
- [**Level9**](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level9): أقصى ضغط. ينتج أصغر حجم ملف على حساب أطول وقت معالجة.

المثال التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX *بدون ضغط*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

هذا المثال يوضح كيفية حفظ عرض تقديمي كملف PPTX مع *أقصى ضغط*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

تتحكم طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) في توليد الصورة المصغرة عند حفظ العرض التقديمي إلى PPTX:

- إذا تم ضبطه على `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم ضبطه على `false`، تُحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض التقديمي صورة مصغرة، لن يتم إنشاء واحدة.

في الكود أدناه، يتم حفظ العرض التقديمي إلى PPTX دون تحديث صورته المصغرة.

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
هذا الخيار يساعد في تقليل الوقت المطلوب لحفظ عرض تقديمي بتنسيق PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

يتم تكوين تقارير حفظ التقدم عبر طريقة [setProgressCallback](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveoptions/#setProgressCallback) في فئة [SaveOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveoptions/) وفئاتها الفرعية. قدّم وكيل Java يُطبق واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/)؛ أثناء التصدير، يتلقى الوكيل تحديثات دورية بالنسب المئوية.

المقاطع البرمجية التالية توضح كيفية استخدام `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // استخدم قيمة النسبة المئوية للتقدم هنا.
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
قامت Aspose بتطوير [تطبيق مجاني لتقسيم PowerPoint](https://products.aspose.app/slides/ar/splitter) باستخدام واجهة برمجة التطبيقات الخاصة بها. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم "الحفظ السريع" (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ الملف الهدف بالكامل؛ لا يُدعم الحفظ التزايدي "السريع".

**هل يمكن حفظ نفس كائن Presentation من عدة خيوط بصورة آمنة؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) ليس آمنًا للقراءة المتعددة؛ احفظه من خيط واحد فقط.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

[الروابط التشعبية](/slides/ar/php-java/manage-hyperlinks/) تُحافظ عليها. الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا – تأكد من أن المسارات المرجعية لا تزال قابلة للوصول.

**هل يمكن تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. يتم دعم خصائص المستند القياسية [document properties](/slides/ar/php-java/presentation-properties/) وستُكتب إلى الملف عند الحفظ.