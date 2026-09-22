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
- عرض إلى ملف
- عرض إلى تدفق
- نوع عرض مسبق التعريف
- صيغة Office Open XML الصارمة
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- PHP
- Aspose.Slides
description: "احفظ عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات في PHP باستخدام Aspose.Slides، وقم بتكوين إخراج PPTX وتقرير التقدم."
---
## **نظرة عامة**

بعد إنشاء عرض تقديمي أو [فتح عرض موجود](/slides/ar/php-java/open-presentation/)، استخدم طريقة [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) لكتابة النتيجة. يمكن لـ Aspose.Slides للـ PHP عبر Java حفظ عرض تقديمي إلى ملف أو تدفق بصيغ PowerPoint و OpenDocument و PDF وغيرها. تغطي الأقسام التالية عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، مرِّر مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/) إلى طريقة [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save). تحدد قيمة التنسيق نوع الملف الذي تُنشئه Aspose.Slides.

المثال التالي ينشئ عرضاً تقديمياً ويحفظه كملف PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // أضف أو عدّل محتوى العرض التقديمي هنا.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية بالتنسيق الأصلي**

لأمثلة الكشف عن الملفات والتدفقات، وسلوك العروض التي تم إنشاؤها حديثاً، والتمييز بين تنسيقات المصدر والإخراج، راجع [تحديد تنسيق العرض الأصلي](/slides/ar/php-java/detect-presentation-source-format/).

في تطبيق معالجة دفعات، قد لا يكون تنسيق الإدخال معروفاً مسبقاً. بعد تحميل ملف، اقرأ تنسيقه الأصلي من طريقة [Presentation::getSourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSourceFormat). مرِّر القيمة الناتجة من [SourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sourceformat/) إلى [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideutil/#toSaveFormat) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/) المقابلة، ثم استخدم [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) لكتابة العرض المعدل.

المثال الكامل التالي يعالج كل ملف في دليل الإدخال، يحدث عنوانه، ويحفظه في دليل الإخراج بنفس التنسيق الذي تم تحميله منه:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideutil/#toSaveFormat) يطابق صيغ PPT و PPTX و ODP و PPTM و PPSX و PPSM و POTX و POTM و PPS و POT و OTP و FODP و PowerPoint XML مع صيغ حفظ العروض المقابلة. يطابق صيغ المصدر للعرض فقط؛ ولا يُقصد به اختيار صيغ التصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sourceformat/) غير مدعومة أو غير صالحة يؤدي إلى حدوث [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

تستخدم ملفات PPT و PPS و POT القديمة نفس الحاوية الثنائية. عندما يُحمَّل عرض من تدفق دون امتداد ملف، قد يتم التعرف على ملف PPS أو POT على أنه PPT. إذا كان من الضروري الحفاظ على هذه الأنواع الفرعية القديمة، احتفظ باسم الملف الأصلي أو بيانات التعريف الخاصة بالتنسيق بشكل منفصل واستخدمها عند اختيار اسم الملف وإخراجه.

## **حفظ العروض التقديمية إلى تدفقات**

لكتابة عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرِّر تدفقًا قابلاً للكتابة وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/) إلى طريقة [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save). هذا النهج مفيد عندما يجب إرجاع الإخراج من خدمة ويب، أو تخزينه في قاعدة بيانات، أو معالجته في الذاكرة.

المثال التالي يحفظ عرضًا تقديميًا جديدًا إلى تدفق ملف:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يمكنك تحديد الطريقة التي يفتح بها PowerPoint العرض المحفوظ عند بدء التشغيل. استخدم طريقة [ViewProperties::setLastView](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/#setLastView) مع قيمة [ViewType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يكوّن عرض Slide Master كالعرض الأولي:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية بصيغة Office Open XML الصارمة**

لإنشاء ملف PPTX يتوافق مع ملف التعريف الصارم لـ Office Open XML، أنشئ كائنًا من نوع [PptxOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/) واستخدم طريقة [PptxOptions::setConformance](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/#setConformance) مع [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). ثم مرِّر الخيارات إلى طريقة [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية بصيغة Office Open XML في وضع Zip64**

يحد الأرشيف ZIP القياسي من الحجم المضغوط وغير المضغوط لكل مدخل، وملف الأرشيف الكلي، وعدد المدخلات. لأن ملف PPTX هو أرشيف ZIP، قد يتجاوز عرض كبير جدًا هذه الحدود. امتدادات ZIP64 ترفع حدود الحجم وعدد المدخلات.

استخدم طريقة [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/#setZip64Mode) للتحكم فيما إذا كانت Aspose.Slides تكتب امتدادات ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zip64mode/#IfNecessary) يستخدم ZIP64 فقط عندما يتجاوز العرض حدود ZIP القياسية. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zip64mode/#Never) يعطل امتدادات ZIP64.
- [Always](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zip64mode/#Always) يكتب دائمًا امتدادات ZIP64.

المثال التالي يفعّل دائمًا امتدادات ZIP64 للعرض الناتج:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
إذا تم استخدام [Zip64Mode::Never](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zip64mode/#Never) ولا يمكن للعرض أن يندرج ضمن حدود ZIP القياسية، فإن عملية الحفظ تُثير استثناءً من نوع [PptxException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بصيغة Office Open XML مع مستويات الضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ مقابل حجم الملف باستخدام طريقة [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/#setCompressionLevel). توفر فئة [CompressionLevel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/) هذه القيم:

- [None](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#None) يخزن البيانات دون ضغط.
- [Level1](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level1) يوفر أسرع ضغط وأكبر حجم مضغوط للخرج.
- [Level2](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level2) حتى [Level5](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level5) يفضّلان تدريجيًا حجم خرج أصغر على سرعة الحفظ.
- [Level6](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level6) يوازن بين سرعة الحفظ وحجم الملف. هذا هو المستوى الافتراضي.
- [Level7](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level7) و[Level8](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level8) يفضّلان حجم خرج أصغر على سرعة الحفظ.
- [Level9](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compressionlevel/#Level9) يوفر أقوى ضغط ويتطلب أطول وقت معالجة.

المثال التالي يحفظ عرضًا تقديميًا دون ضغط:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

المثال التالي يستخدم أقصى مستوى ضغط:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

عند حفظ عرض كـ PPTX، تتحكم طريقة [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) في صورة المستند المصغرة:

- `true` يعيد توليد الصورة المصغرة أثناء عملية الحفظ. هذه هي القيمة الافتراضية.
- `false` يحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لا تُنشئ Aspose.Slides صورة جديدة.

المثال التالي يحفظ عرضًا تقديميًا دون تحديث صورته المصغرة:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
تعطيل تحديث الصورة المصغرة يمكن أن يقلل من الوقت المطلوب لحفظ ملف PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

لمراقبة عملية الحفظ، قدم وكيل Java يطبق الواجهة [IProgressCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/) ومرّر الوكيل إلى طريقة [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveoptions/#setProgressCallback). ستستدعي Aspose.Slides بعد ذلك طريقة [IProgressCallback::reporting](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/#reporting-double-) مع قيم التقدم أثناء التصدير.

المثال التالي يبلّغ تقدم تصدير PDF إلى وحدة التحكم:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
توفر Aspose أداة مجانية تُدعى [PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter) مبنية على API الخاص بـ Aspose.Slides. تقوم بحفظ الشرائح المختارة من عرض كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides الحفظ المتدرج أو “الحفظ السريع”?**

لا. كل عملية حفظ تكتب ملف إخراج كامل بدلاً من تحديث الأجزاء التي تغيرت فقط.

**هل يمكن لعدة خيوط (threads) حفظ نفس كائن Presentation؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) غير آمن للاستخدام المتعدد الخيوط. يجب الوصول إلى كل كائن وحفظه من خيط واحد فقط في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند حفظ عرض تقديمي؟**

تظل [Hyperlinks](/slides/ar/php-java/manage-hyperlinks/) موجودة في العرض. لا تقوم Aspose.Slides بنسخ الملفات المرتبطة خارجيًا، لذا يجب أن يكون للعرض المحفوظ القدرة على الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف، العنوان، الشركة، وتاريخ الإنشاء؟**

نعم. اضبط [document properties](/slides/ar/php-java/presentation-properties/) المناسبة قبل الحفظ، وستقوم Aspose.Slides بكتابة هذه الخصائص إلى ملف الإخراج.