---
title: معالجة تحذيرات العرض التقديمي في PHP
type: docs
weight: 90
url: /ar/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- استدعاء التحذير
- سياسة التحذير
- فقدان البيانات
- فساد المصدر
- مشكلة التوافق
- استبدال الخط
- توقيع رقمي
- تحميل العرض التقديمي
- عرض العرض التقديمي
- تحويل العرض التقديمي
- حفظ العرض التقديمي
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "تعلم كيفية جمع وتصنيف واتخاذ إجراءات بشأن التحذيرات أثناء تحميل العرض التقديمي وعرضه وتحويله وحفظه باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides الإبلاغ عن المشكلات القابلة للاسترداد أثناء تحميله أو عرضه أو تحويله أو حفظه للعرض التقديمي. تشمل الأمثلة السجلات المصدرية التالفة، المحتوى الذي لا يمكن الحفاظ عليه، استبدال الخطوط، وقيود تنسيق الهدف. تسمح واجهة رد الاتصال للتحذير للتطبيق بتسجيل هذه الحالات وتحديد ما إذا كان يمكن للعملية الحالية المتابعة.

أنشئ فئة PHP تحتوي على طريقة عامة `warning` وقم بعرضها عبر PHP Java Bridge كواجهة Java [IWarningCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarningcallback/) باستخدام `java_closure`. افحص القيم التي تقدمها [getWarningType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--) عبر [IWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/). أعد [ReturnAction::Continue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/returnaction/#Continue) لقبول التحذير أو [ReturnAction::Abort](https://reference.aspose.com/slides/ar/php-java/aspose.slides/returnaction/#Abort) لإيقاف العملية.

استخدم [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setWarningCallback) للتحذيرات التي تُنشأ أثناء فتح عرض تقديمي. تورث فئات خيارات العرض والتصدير [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveoptions/#setWarningCallback)، التي تتلقى التحذيرات من عرض الشرائح، والتحويل، والحفظ. وبما أن التحذير نفسه لا يحدد عملية التطبيق، ربط كل مثال من رد الاتصال بمرحلة عملية عند بناء تقرير موحد.

## **التحذيرات والاستثناءات**

يتم كشف استثناءات Java إلى PHP عبر PHP Java Bridge؛ يتم التقاطها عند حد العملية، كما هو موضح في المثال أدناه. روابط واجهة Java في هذه المقالة تصف عقدة رد الاتصال المستخدمة بواسطة الجسر.

يصف التحذير حالة يمكن لـ Aspose.Slides الاسترداد منها إذا عادت رد الاتصال بـ `ReturnAction::Continue`. يعني الاستثناء أن العملية المطلوبة لا يمكن إكمالها بشكل طبيعي؛ لا يتم تحويل الاستثناءات إلى تحذيرات ولا يمكن التعامل معها بواسطة سياسة التحذير.

إرجاع `ReturnAction::Abort` يطلب من موزع التحذير إنهاء العملية الحالية عن طريق رفع استثناء. يعتمد نوع الاستثناء العام على العملية وتنسيق العرض التقديمي. على سبيل المثال، قد يظهر أثناء التحميل [PptxReadException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxreadexception/) أو [PptReadException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptreadexception/)، بينما قد يظهر أثناء الحفظ أو التصدير [PptxException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxexception/). عالج الاستثناء عند حد العملية واستخدم تقرير التحذير لتحديد ما إذا كانت سياسة التطبيق هي التي تسببت في الإنهاء بدلاً من الاعتماد على نوع فرعي واحد من الاستثناء أو رسالته. يسجل رد الاتصال التحذير قبل إرجاع `ReturnAction::Abort`، لضمان بقاء السبب متاحًا للتطبيق.

## **فئات التحذير**

توفر الفئة [WarningType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/warningtype/) ثوابت عددية للفئات التالية:

| نوع التحذير | المعنى | السياسة النموذجية |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ar/php-java/aspose.slides/warningtype/#SourceFileCorruption) | العرض التقديمي المصدر يحتوي على فساد قد يجعل المستند المحفوظ بالتنسيق الأصلي غير قابل للاستخدام. | إلغاء. |
| [DataLoss](https://reference.aspose.com/slides/ar/php-java/aspose.slides/warningtype/#DataLoss) | قد يكون النص أو المخططات أو الصور أو البيانات الأخرى غير موجودة بعد التحميل أو الحفظ. | إلغاء. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ar/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | قد يفقد العرض التقديمي تنسيقًا مهمًا. | إلغاء في وضع التحقق الصارم؛ وإلا سجل واستمر. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ar/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | قد يحدث اختلاف تنسيق محدود. | سجل للتشخيص واستمر. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/warningtype/#CompatibilityIssue) | قد لا يفتح النتيجة أو يتصرف بشكل صحيح في بعض التطبيقات أو الإصدارات القديمة. | سجل واستمر ما لم تكن التوافقية إلزامية. |
| [UnexpectedContent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/warningtype/#UnexpectedContent) | المصدر يحتوي على محتوى غير مدعوم أو غير معروف قد لا يكون تأثيره معروفًا بعد. | سجل واستمر، أو اعتبره خطأ في سياسة صارمة. |

يجب أن تقود الفئة قرار السياسة. خزن القيمة التي تعيدها [getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--) للتشخيص، لكنه لا تعتمد على صيغتها في منطق التطبيق لأن نص الرسالة قد يختلف بين سيناريوهات التحذير وإصدارات المنتج.

## **جمع وتصنيف التحذيرات**

يستخدم المثال التالي تقريرًا على مستوى التطبيق للخط الأنابيب الكامل للمعالجة. مثيل رد اتصال منفصل يضع علامات على التحذيرات من التحميل، والعرض، وتحويل PDF، وحفظ PPTX. السياسة توقف عند فساد المصدر أو فقدان البيانات، وتوقف اختياريًا عند فقدان تنسيق كبير، وتستمر بالنسبة لبقية التحذيرات. يقوم رد الاتصال بتحويل قيم التحذير إلى قيم PHP أصلية باستخدام `java_values` قبل التسجيل والمقارنة.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

مرّر `false` للقيمة `abortOnMajorFormattingLoss` عند إنشاء `WarningPolicy` إذا كانت اختلافات التنسيق الكبيرة مقبولة. ما زالت قضايا التوافق، وفقدان التنسيق الصغير، والمحتوى غير المتوقع محفوظة في التقرير حتى عندما تستمر العملية. وسّع `WarningPolicy::getAction` إذا كان على التطبيق رفض أي من هذه الفئات.

## **سيناريوهات التحذير الشائعة**

يمكن أن تظهر التحذيرات في مراحل مختلفة من سير العمل:

- **التوقيعات الرقمية:** قد ينتج عن عرض تقديمي موقع تحذير أثناء التحميل بأن توقيعه سيفقد أثناء المعالجة. تقوم Aspose.Slides بالإبلاغ عن حالة `DataLoss` هذه عبر [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationsignedwarninginfo/). يتيح رد اتصال مرحلة التحميل للتطبيق رفض الملف أو قبول الفقدان المبلغ عنه صراحةً.
- **استبدال الخط:** يمكن استبدال خط غير متوفر أثناء عرض أو تصدير الشريحة. تُبلغ تحذيرات استبدال الخط كـ `DataLoss`، لذا فإن السياسة الصارمة أعلاه تُوقف حتى إذا كان التطبيق سيعتبر الاستبدال مقبولًا بصريًا. لملاحظة هذا السلوك، استخدم عرض تقديمي يحتوي على نص بخط غير متوفر في بيئة التشغيل. يحدد وصف التحذير الاستبدال؛ قم بتكوين الخطوط المطلوبة أو [قواعد استبدال الخطوط](/slides/ar/php-java/font-substitution/) قبل إعادة المحاولة.
- **محتوى غير مدعوم أو غير متوقع:** قد يصادف المحمل سجلات عرض تقديمي أو ميزات لا يتعرف عليها. قد تستخدم مثل هذه التحذيرات `UnexpectedContent`، أو فئة أكثر شدة عندما يُعرف أن البيانات أو التنسيق متأثران.
- **توافق التنسيق:** يمكن أن يؤدي الحفظ إلى تنسيق عرض تقديمي آخر إلى حذف ميزات أو إنتاج نتيجة تتصرف بشكل مختلف في بعض التطبيقات. على سبيل المثال، حفظ عرض تقديمي يحتوي على أكثر من ثمانية إرشادات رسم أفقية أو عمودية إلى PPT legacy يُبلغ عن `CompatibilityIssue`. يمكن لرد اتصال مرحلة الحفظ تسجيل الفقدان والاستمرار، أو رفضه إذا كان الحفاظ على جميع الإرشادات مطلوبًا.
- **سلوك التحميل:** يمكن أيضًا أن تُنتج خيارات التحميل والسلوكيات القديمة تحذيرات. على سبيل المثال، يحدد [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) استخدام سلوك قفل عرض تقديمي قديم كـ `CompatibilityIssue`.

تعتمد التحذيرات على المستند المصدر، وتنسيق الهدف، والعملية، وإصدار Aspose.Slides. لا تفترض أن كل ملف يُنتج تحذيرًا أو أن كل سيناريو يطابق فئة واحدة دائمًا.

## **معالجة العمليات الموقفة بأمان**

عند إرجاع رد الاتصال `ReturnAction::Abort`، لا تستخدم كائنًا فشل في التحميل ولا تفترض أن مخرجات العرض أو الحفظ مكتملة. قد تنتهي العملية بعد إنشاء ملف الإخراج ولكن قبل إكماله.

احفظ النتائج المُتحقّق منها إلى مسار منفصل مثل `validated-output.pptx`. استبدل عرض تقديمي موجود فقط بعد أن تنتهي العملية بنجاح، وتلبي تقارير التحذير سياسة التطبيق، ويمكن فتح المخرج وفحصه. هذا يجنب الكتابة فوق ملف مصدر صالح بنتيجة جزئية أو مرفوضة.

تقرير تحذير فارغ ليس ضمانًا بأن كل ميزة مصدرية قد تم الحفاظ عليها. طبق أي فحوصات محتوى أو بصرية إضافية يطلبها التطبيق. راجع أيضًا [Open Presentations](/slides/ar/php-java/open-presentation/) و[Save Presentations](/slides/ar/php-java/save-presentation/).

## **الأسئلة المتكررة**

**هل يمكن لواجهة رد الاتصال للتحذير معالجة كل خطأ في Aspose.Slides؟**

لا. فهي تتعامل مع الحالات القابلة للاسترداد التي تُبلغ كتحذيرات. يجب على التطبيق معالجة الاستثناءات التي تحدث بشكل مستقل عن رد الاتصال حول استدعاءات التحميل أو العرض أو التحويل أو الحفظ.

**هل يضمن إرجاع `ReturnAction::Continue` ناتجًا مطابقًا؟**

لا. إنه يسمح فقط بمتابعة المعالجة. لا تزال الحالة المبلغ عنها قد تُسبب اختلافات في البيانات أو التنسيق أو التوافق، لذا راجع أنواع التحذير المجمعة ووصفاتها.

**كيف يمكن للتطبيق تحديد العملية التي أثارت التحذير؟**

أنشئ مثيلًا من رد الاتصال لكل عملية وخزن مرحلة معرفة من قبل التطبيق جنبًا إلى جنب مع القيم التي تعيدها [getWarningType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getWarningType--) و[getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--)، كما هو موضح في المثال.