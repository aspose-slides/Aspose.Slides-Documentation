---
title: تحويل عروض PowerPoint إلى Markdown في PHP
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/php-java/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى MD
- العرض التقديمي إلى MD
- الشريحة إلى MD
- PPT إلى MD
- PPTX إلى MD
- حفظ PowerPoint كـ Markdown
- حفظ العرض التقديمي كـ Markdown
- حفظ الشريحة كـ Markdown
- حفظ PPT كـ MD
- حفظ PPTX كـ MD
- تصدير PPT إلى MD
- تصدير PPTX إلى MD
- تصدير صور Markdown
- روابط صور CDN
- PowerPoint
- العرض التقديمي
- Markdown
- PHP
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى Markdown في PHP والتحكم في مكان حفظ الصور النقطية وملفات الميتا وSVG والمرجع إليها."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides لـ PHP عبر Java تحويل عروض PPT و PPTX إلى Markdown للتوثيق، المواقع الثابتة، ترحيل المحتوى، وتدفقات العمل الخاصة بالتحكم في الإصدارات. يمكنك اختيار نمط Markdown، التحكم في طريقة تقديم محتوى الشريحة، وتحديد مكان حفظ الصور المصدرة وكيفية إشارة Markdown التي تم إنشاؤها إليها.

بشكل افتراضي، يستخدم تصدير Markdown مخرجات نصية فقط. لتصدير المحتوى المرئي، اضبط نوع التصدير باستخدام طريقة [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) إلى القيمة `Sequential` أو `Visual` من تعداد [MarkdownExportType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownexporttype/). تقوم `Sequential` برسم عناصر الشريحة بشكل منفصل ومرتب، بينما تحتفظ `Visual` بالعناصر المجمعة معًا للحفاظ على علاقاتها البصرية. قيمة `TextOnly` لا تُصدر موارد الصور، لذا لا يتم استدعاء ردود نداء حفظ الصورة في ذلك الوضع.

## **تحويل عرض تقديمي إلى Markdown**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) ثم استدعِ طريقة [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) مع القيمة `Md` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **اختر نمط Markdown**

تتحكم طريقة [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) في مواصفة Markdown المستخدمة للإخراج. يتضمن تعداد [Flavor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/flavor/) القيم CommonMark و GitHub Flavored Markdown وغيرها من المتغيرات المدعومة.

المثال التالي يصدر عرضًا تقديميًا كـ CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **تصدير الصور باستخدام سلوك الحفظ المحلي الافتراضي**

توفر الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) طريقتين لتكوين الصور المحفوظة محليًا:

- [setBasePath](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) يحدّد الدليل الأساسي لمستند Markdown وموارده.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) يحدّد دليل الصور الفرعي. القيمة الافتراضية هي `Images`.

المثال التالي يرسم المحتوى المرئي، يكتب الصور إلى `output/assets`، وينشئ مراجع صور نسبية في مستند Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

هذا السلوك يعمل كخطة احتياطية عندما يُعيد معالج حفظ الصورة المخصص القيمة `false`.

## **تخصيص حفظ الصور وروابط Markdown**

استخدم طريقة [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) لتسجيل رد نداء للموارد النقطية وملفات الميتافايل غير SVG التي تُصدر أثناء تصدير Markdown. يتلقى رد النداء `MarkdownImageSavingHandler` كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/)، وقيمة [ImageFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imageformat/)، والرابط Markdown المُنشأ كمصفوفة Java ذات عنصر واحد. احفظ أو حمّل الصورة بالتنسيق المزوّد، واستبدل `$link[0]` بالمرجع الذي يجب أن يظهر في مخرجات Markdown.

تُعالج الموارد المُصدرة بصيغة SVG بشكل منفصل. سجّل رد نداء باستخدام طريقة [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/). يتلقى رد النداء `MarkdownSvgImageSavingHandler` كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/isvgimage/) ومصفوفة Java ذات العنصر `$link`. لا تحتوي SVG على وسيط `ImageFormat`؛ اكتب أو حمّل بيانات XML الخاصة بها من طريقة [ISvgImage::getSvgData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/isvgimage/) بدلاً من ذلك. بناءً على وضع التصدير وتجمّع المحتوى البصري، قد يتم تحويل SVG في عرض المصدر إلى نقطية أو دمجه مع محتوى آخر؛ ثم يُمرّر المورد غير SVG الناتج إلى رد نداء حفظ الصورة. سجّل كل من ردّي النداء عندما يتطلّب كل مورد بصري مُصدَّر معالجة مخصصة.

في PHP عبر Java، نفّذ كل رد نداء في فئة PHP واستخدم `java_closure` لتصدير هذا الكائن كواجهة Java المقابلة.

{{% alert color="info" title="Note" %}}
قم بتهيئة جسر PHP/Java مع تمكين `JAVA_PREFER_VALUES` قبل تحميل `Java.inc`. تُعيد طريقة [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) القيمة `void`، ولا يمكن للوضع الافتراضي للتدفق في الجسر استدعاء رد نداء PHP أثناء ذلك الاستدعاء المؤجل. المثال الكامل أدناه يتضمن التهيئة المطلوبة.
{{% /alert %}}

قيمة إرجاع المعالج تحدد من يعالج الصورة:

- أرجِع `true` بعد أن يحفظ المعالج الصورة أو يحمّلها أو يحوِّلها أو يعالجها بأي طريقة أخرى ويعيّن قيمة صالحة إلى `$link[0]`. تقوم Aspose.Slides بكتابة تلك القيمة إلى مستند Markdown ولا تُجري الحفظ المحلي الافتراضي.
- أرجِع `false` لتسمح لـ Aspose.Slides بحفظ الصورة محليًا وإنشاء رابطها وفق القيم التي تم ضبطها بواسطة [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) و[MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
المعالج الذي يُرجِع `true` يتحمل مسؤولية الصورة. إذا أرجع `true` دون تعيين رابط صالح غير فارغ، سيفشل التصدير مع استثناء `InvalidOperationException`.
{{% /alert %}}

### **حفظ الصور إلى دليل أصل CDN واستخدام عناوين URL خارجية**

المثال التالي يعتبر `cdn-origin/presentations/quarterly-report` دليل أصل CDN مركّب أو متزامن. يستخرج كل معالج اسم الملف المُنشأ، يحفظ الصورة في ذلك الدليل المخصص، ويستبدل المرجع المحلي المُنشأ بعنوان URL عام لـ CDN. لا يقوم العينة نفسها بعملية رفع عبر الشبكة: يصبح عنوان URL صالحًا فقط بعد تركيب الدليل كأصل CDN أو نشر ملفاته إلى CDN. للتخزين الكائني، استبدل كتابة نظام الملفات بعملية رفع عبر SDK التخزيني وعيّن `$link[0]` فقط بعد نجاح الرفع.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

المعالج النقطي يُرجِع عمدًا `false` للصور أصغر من 128 × 128 بكسل، لذا تقوم Aspose.Slides بحفظ تلك الصور إلى `output/fallback-images` باستخدام السلوك الافتراضي. تُعالج الموارد النقطية وملفات الميتافايل الأكبر، بالإضافة إلى موارد SVG، عبر الشيفرة المخصصة. على سبيل المثال، يتحول مرجع محلي مُنشأ مثل `fallback-images/image1.png` إلى `https://cdn.example.com/presentations/quarterly-report/image1.png`. يستخدم المعالجون مسارات نظام التشغيل فقط عند كتابة الملفات؛ وتستخدم الروابط المكتوبة في Markdown الشرطات المائلة للأمام وأسماء الملفات المشفّرة وفق URL. طبّق القاعدة نفسها عند بناء الروابط النسبية: استخدم `/`، وليس الفاصل الخاص بنظام الملفات.

## **الأسئلة الشائعة**

**هل يمكن لمعالج واحد معالجة كل من الصور النقطية و SVG؟**  
لا. استخدم [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) للموارد النقطية وملفات الميتافايل التي تُصدر كصورة، واستخدم [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) للموارد التي تُصدر بصيغة SVG. الأول يوفر كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) وقيمة [ImageFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imageformat/)، والثاني يوفر كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/isvgimage/) يمكن قراءة بيانات SVG الخاصة به عبر [ISvgImage::getSvgData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/isvgimage/). يُعالج SVG المصدر الذي يتحوّل إلى نقطية أثناء التصدير بواسطة رد نداء حفظ الصورة بدلاً من ذلك.

**ماذا يحدث عندما يُرجِع معالج حفظ الصورة القيمة `false`؟**  
تستخدم Aspose.Slides سلوك الحفظ المحلي الافتراضي. يتم التحكم في موقع الصورة والمرجع المُنشأ بواسطة القيم التي تم ضبطها عبر [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/) و[MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/markdownsaveoptions/).

**هل يمكن للمعالج توفير عنوان URL دون حفظ الصورة محليًا؟**  
نعم. يمكن للمعالج رفع الصورة إلى تخزين كائني أو تمريرها إلى خدمة أخرى، وتعيين عنوان URL الناتج إلى `$link[0]`، ثم إرجاع `true`. يجب أن يكمل المعالج المعالجة بنفسه؛ إرجاع `true` يمنع الحفظ المحلي الافتراضي.

**لماذا يُطلق تصدير Markdown استثناء `InvalidOperationException` من معالج؟**  
يحدث هذا الاستثناء عندما يُرجِع المعالج `true` دون توفير رابط صالح. عيّن المسار النسبي أو عنوان URL الخارجي الذي يجب كتابته إلى Markdown قبل إرجاع `true`.

**أي فاصل مسار يجب أن تستخدمه روابط الصور؟**  
استخدم الشرطات المائلة للأمام في روابط Markdown وعناوين URL. استخدم `DIRECTORY_SEPARATOR` فقط لمسارات نظام الملفات، ثم كون أو عدّل مرجع Markdown بصورة منفصلة.

**هل يتم حفظ الروابط التشعبية أثناء تصدير Markdown؟**  
نعم. تُحفظ الروابط النصية [hyperlinks](/slides/ar/php-java/manage-hyperlinks/) كروابط Markdown قياسية. ولا يتم تحويل انتقالات الشرائح [transitions](/slides/ar/php-java/slide-transition/) والرسوم المتحركة [animations](/slides/ar/php-java/powerpoint-animation/).

**هل يمكن تحويل العروض إلى Markdown بالتوازي؟**  
يمكنك معالجة ملفات عروض مختلفة بالتوازي، ولكن لا تشارك نفس كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) بين الخيوط. اتبع إرشادات [multithreading guidelines](/slides/ar/php-java/multithreading/) واستخدم كائنًا منفصلًا لكل ملف.