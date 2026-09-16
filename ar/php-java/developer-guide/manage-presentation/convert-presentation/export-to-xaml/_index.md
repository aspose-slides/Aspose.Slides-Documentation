---
title: تصدير العروض التقديمية إلى XAML في PHP
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/php-java/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- PHP
- Aspose.Slides
description: "تحويل شرائح PowerPoint وOpenDocument إلى XAML باستخدام Aspose.Slides للـ PHP عبر Java — حل سريع وخالٍ من Office يحافظ على تخطيطك دون تغيير."
---
## **نظرة عامة**

هذه المقالة تشرح كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides. تتضمن مقدمة مختصرة عن XAML، وتظهر كيفية حفظ عرض تقديمي إلى XAML بالإعدادات الافتراضية، وتوضح كيفية تخصيص التصدير عبر [XamlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. كما تجيب المقالة عن بعض الأسئلة الشائعة المتعلقة بخطوط الاحتياطي، توافق XAML مع المكدسات المختلفة، وسلوك تصدير الشرائح المخفية.

## **حول XAML**

XAML هي لغة ترميز قائمة على XML تُستخدم لوصف واجهات المستخدم في أطر عمل مثل WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform)، وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم بصري أو كتابة وتعديل الترميزات مباشرة.

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يوضح المثال التالي بلغة PHP كيفية تصدير عرض تقديمي إلى XAML بالإعدادات الافتراضية. ابدأ بتهيئة PHP Java Bridge وحمل `aspose.slides.php` قبل تشغيل الأمثلة في هذه المقالة. ضع `pres.pptx` في دليل عمل خادم Java Bridge، أو زود مسارًا مطلقًا يمكن الوصول إليه من ذلك الخادم.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

افتراضيًا، تُحفظ الشرائح المُصدَّرة في مجلد فرعي يسمى `pres` داخل دليل العمل الحالي لخادم Java Bridge. يتم إنشاء المجلد تلقائيًا، وتُحفظ أي صور مطلوبة هناك أيضًا.

يُستمد اسم مجلد الإخراج من اسم ملف المصدر بدون الامتداد. بالنسبة إلى `pres.pptx`، تُسمَّى ملفات الإخراج `pres/Slide_1.xaml` و`pres/Slide_2.xaml` وما إلى ذلك. حتى إذا مررت مسارًا مطلقًا للعرض التقديمي المدخل، يُنشأ مجلد الإخراج نسبةً إلى دليل عمل خادم Java Bridge الحالي، وليس بجانب ملف الإدخال.

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات المخصصة**

استخدم واجهة [IXamlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloptions/) للتحكم في طريقة تصدير Aspose.Slides للعرض التقديمي إلى XAML.

لحفظ الناتج في موقع مخصص، قدم وكيل Java يطبق [IXamlOutputSaver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/) ومرر مثالًا من تطبيقك إلى طريقة [setOutputSaver](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/#setOutputSaver) في [XamlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/).

لضم الشرائح المخفية إلى ناتج XAML، استدعِ [setExportHiddenSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) مع القيمة `true` كما هو موضح في المثال التالي بلغة PHP:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **القبض على جميع المخرجات المُولَّدة لـ XAML**

يمكن لتصدير XAML أن ينتج مستند XAML لكل شريحة مُصدَّرة إضافة إلى صور وموارد داعمة منفصلة. عيّن [IXamlOutputSaver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/) مخصصًا إلى [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/#setOutputSaver) لتستقبل هذه المخرجات بدلاً من استخدام الحافظ الافتراضي لنظام الملفات. ابدأ التصدير عبر التحميل المتعدد للـ XAML باستخدام دالة [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) التي تقبل خيارات XAML.

توفر دالة `java_closure` في PHP Java Bridge كائن PHP كواجهة Java. احتفظ بكل من الحافظ في PHP ووكيله حيًا حتى ينتهي التصدير. روابط الواجهة تشير إلى API Java المنفّذ بواسطة الوكيل.

### **فهم دورة حياة الاستدعاء العكسي**

يقوم المُصدِّر باستدعاء [IXamlOutputSaver::save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) بشكل منفصل لكل مخرج مُولَّد:

- `path` يحدد المخرج وقد يحتوي على دلائل نسبية. احتفظ بهذه المعلومة لأن XAML قد يشير إلى موارد باستخدام مسارات نسبية.
- `data` يحتوي على بايتات المخرج. يجب عدم فك تشفير الصور والموارد الثنائية كنص.
- الحافظ مسؤول عن الاحتفاظ أو تخزين البيانات قبل الإرجاع. الأمثلة تحوِّل كل مصفوفة بايتات Java إلى سلسلة ثنائية في PHP يملكها التطبيق.
- اعتبر التصدير ناجحًا فقط عندما تعود عملية حفظ العرض التقديمي وتكتمل جميع الاستدعاءات العكسيّة بنجاح. لا تتجاهل أخطاء التخزين ولا تبدأ عمليات كتابة خلفية غير مراقبة. إذا حدث التخزين لاحقًا، أبلغ عن النجاح العام فقط بعد أن تنجح هذه الخطوة أيضًا.

يطبق [XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) أيضًا على الحافظ المخصص. الإعداد الافتراضي، `false`، يستثني مستندات XAML للشرائح المخفية. تمرير القيمة `true` يضمّنها وكل الموارد المطلوبة لتصديرها. عدد الموارد يعتمد على العرض التقديمي؛ لا تفترض وجود استدعاء واحد لكل شريحة أو ترتيب ثابت للاستدعاءات.

### **التصدير إلى الذاكرة وفحص المخرجات**

هذا المثال الكامل يحمل `pres.pptx`، يجمع كل مخرج في مصفوفة تجميعية للـ PHP من سلاسل ثنائية، ويطبع اسمه، نوعه، وعدد البايتات. يحافظ على الأسماء المقدمة تمامًا. الأسماء المكررة تجعل التجميع غير صالح بدلاً من الكتابة فوق المخرج صامتًا. يتحقق المثال من ذلك قبل استخدام النتائج.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // يُعامل فقط XAML كنص UTF-8 للفحص الاختياري.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

فحص الامتدادات مفيد للتدقيق؛ احتفظ بجميع المخرجات، بما فيها أنواع الموارد غير المألوفة. اترك البايتات دون تعديل عند التخزين أو النقل. يمكن لسلاسل PHP الاحتفاظ بالبيانات الثنائية، بما فيها بايتات الصفر. عالج السلسلة كنص UTF-8 فقط عند فحص XAML؛ لا تقم بتحويل بايتات الصورة أو المورد.

### **تعبئة المخرجات المجمّعة في أرشيف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من صحة أسمائه، ويكتب البايتات الأصلية في أرشيف ZIP. دليل وظائف منفصل يتم إنشاؤه لتفريق وظائف التصدير المتزامنة. يتطلب هذا المثال امتداد PHP Phar مع دعم ZIP. تستخدم مداخل ZIP الشرط المائل للأمام وتحتفظ بالدلائل النسبية. تُرفض الأسماء غير الآمنة أو التي تتصادم بعد التطبيع قبل كتابة الحزمة بالكامل.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

يستخدم المثال [PharData](https://www.php.net/manual/en/class.phardata.php) لكتابة أرشيف ZIP محلي واحد في دليل عمل عملية PHP؛ لا يكتب المُصدِّر ملفات XAML أو صور منفصلة. للتخزين عن بُعد، استبدل مرحلة كتابة الأرشيف بتحميل السلاسل الثنائية المجمّعة. استخدم معرف مهمة التصدير بالإضافة إلى الاسم النسبي الكامل للمخرج كمفتاح Blob، أو خزن معرف المهمة والاسم النسبي والبيانات الثنائية في صف قاعدة بيانات. انشر المهمة فقط بعد إكمال جميع التحميلات أو بعد تأكيد معاملة قاعدة البيانات. نظّف المخرجات الجزئية إذا فشل التخزين.

للعروض الكبيرة، يمكن للحافظ المخصص تخزين كل مخرج مباشرةً في تخزين التطبيق لتفادي الاحتفاظ بنسخة إضافية من كامل التصدير في ذاكرة التطبيق. حافظ على تزامن كل استدعاء عكسي من منظور المصدّر: أرجع فقط بعد أن القبول الوجهة للبايتات، واسمح للأخطاء بالوصول إلى المستدعي.

### **الحفاظ على أسماء الموارد والتحقق من الإشارات**

- طوّق فواصل المسارات عندما يتطلب الوجهة ذلك، لكن احتفظ بالدلائل النسبية. لا تستخدم [basename](https://www.php.net/manual/en/function.basename.php) فقط ما لم تكن كل الأسماء المولَّدة معروفة بأنها فريدة وتظل إشارات الموارد صالحة.
- طبّق تحققًا من صحة الاسم وفقًا للوجهة. عند كتابة ملفات منفصلة، ارفض المسارات المتجذرة ومقاطع التنقل، وحل الوجهة إلى مسار مطلق، وتحقق من بقاءه تحت دليل التصدير المقصود، بما في ذلك فاصل الدليل في فحص الاحتواء. استخدم دليلًا يتحكم به التطبيق دون روابط رمزية قد تعيد توجيه الكتابة.
- استخدم حافظًا ومجال تخزين منفصل لكل مهمة تصدير. اكتشف التصادمات بعد تطبيع الفواصل ووفقًا لقواعد حساسية الحالة للوجهة.
- قبل النشر، حلل كل مستند XAML كـ XML وتفحص إشارات الموارد المستندة إلى الملفات، مثل خصائص `Source` أو `ImageSource` للصور. احل كل URI نسبيًا مقابل دليل المخرج XAML المحتوي، وطوّق اسم التخزين الناتج، وتأكد من وجود المفتاح المقابل في الخريطة أو مدخل ZIP أو الكائن المخزن. عالج URI الخارجية وتعبيرات XAML markup بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `pres/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `pres/images/image1.png`. الاحتفاظ فقط بـ `image1.png` سيكسر العلاقة. بالنسبة لتخزين الكائنات، حافظ على نفس الهيكل تحت بادئة المهمة واجعل عناوين URL لهذه الموارد متاحة للمستهلك XAML. أعد فتح ZIP المكتمل للتحقق من أسماء المدخلات وبايتات الموارد، وحمّل شرائح تمثيلية في بيئة XAML الهدف لتأكيد أن الصور تُحلّ بنجاح.

## **الأسئلة الشائعة**

**كيف يمكنني التأكد من خطوط ثابتة إذا كان الخط الأصلي غير متوفر على الجهاز؟**

استدعِ [setDefaultRegularFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/) — يُستخدم كخط احتياطي أثناء التصدير عندما يكون الأصلي مفقودًا. وهذا لا يضمن أن XAML المُولَّد سيشير إلى الخط الاحتياطي أو أن الخط متوفر على الجهاز الهدف. تأكد من توفر الخطوط المشار إليها في XAML في البيئة التي يُعرض فيها.

**هل XAML المُصدّر مخصص فقط لـ WPF أم يمكن استخدامه في مجموعات XAML أخرى أيضًا؟**

تصدّر Aspose.Slides XAML الخاص بـ WPF عبر API العامة الخاصة بها. لا يتم الضمان بتوافقه مع مجموعات XAML أخرى مثل UWP وXamarin.Forms. اختبر الترميز المُولَّد في البيئة المستهدفة الخاصة بك.

**هل تم دعم الشرائح المخفية، وكيف يمكن منع تصديرها افتراضيًا؟**

بشكل افتراضي، لا تُدرج الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) في [XamlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/xamloptions/) — أبقه معطَّلًا إذا لم تحتاج لتصديرها.