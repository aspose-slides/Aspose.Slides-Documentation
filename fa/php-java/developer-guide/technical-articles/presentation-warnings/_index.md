---
title: Handle Presentation Warnings in PHP
type: docs
weight: 90
url: /fa/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- فراخوانی هشدار
- سیاست هشدار
- از دست رفتن داده
- فساد منبع
- مشکل سازگاری
- جایگزینی فونت
- امضای دیجیتال
- بارگذاری ارائه
- رندر ارائه
- تبدیل ارائه
- ذخیره‌سازی ارائه
- پاورپوینت
- سند باز
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه هشدارها را هنگام بارگذاری، رندر، تبدیل و ذخیره ارائه‌ها با Aspose.Slides برای PHP از طریق Java جمع‌آوری، طبقه‌بندی و اقدام کنید."
---
## **نمای کلی**

Aspose.Slides می‌تواند مشکلات قابل بازیابی را هنگام بارگذاری، رندر، تبدیل یا ذخیره یک ارائه گزارش کند. مثال‌ها شامل رکوردهای منبع آسیب‌دیده، محتوایی که نمی‌توان حفظ کرد، جایگزینی فونت و محدودیت‌های قالب مقصد است. یک callback هشدار به برنامه امکان می‌دهد این شرایط را ثبت و تصمیم بگیرد که آیا عملیات جاری می‌تواند ادامه یابد یا نه.

یک کلاس PHP با متد عمومی `warning` ایجاد کنید و آن را از طریق PHP Java Bridge به عنوان اینترفیس Java [IWarningCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarningcallback/) با استفاده از `java_closure` منتشر کنید. مقادیر [getWarningType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) ارائه‌شده توسط [IWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/) را بررسی کنید. برای پذیرش هشدار [ReturnAction::Continue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/returnaction/#Continue) را برگردانید یا برای توقف عملیات [ReturnAction::Abort](https://reference.aspose.com/slides/fa/php-java/aspose.slides/returnaction/#Abort) را برگردانید.

از [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setWarningCallback) برای هشدارهایی که هنگام باز کردن یک ارائه ایجاد می‌شوند استفاده کنید. کلاس‌های گزینه‌های رندر و خروجی از [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setWarningCallback) ارث می‌برند که هشدارها را از رندر اسلاید، تبدیل و ذخیره دریافت می‌کند. از آنجا که خود هشدار عملیات برنامه را شناسایی نمی‌کند، هر نمونه callback را با مرحله عملیات مرتبط کنید تا گزارش ترکیبی بسازید.

## **هشدارها و استثناها**

استثناهای Java از طریق PHP Java Bridge در PHP قابل دسترسی هستند؛ آن‌ها را در مرز عملیات همان‌طور که در مثال زیر نشان داده شده، بگیرید. لینک‌های اینترفیس Java در این مقاله قرارداد callback مورد استفاده توسط bridge را توصیف می‌کند.

هشدار شرطی را توصیف می‌کند که Aspose.Slides می‌تواند در صورت بازگرداندن `ReturnAction::Continue` از سوی callback از آن بازیابی کند. استثنا به این معناست که عملیات درخواستی نمی‌تواند به‌صورت عادی تکمیل شود؛ استثناها به هشدار تبدیل نمی‌شوند و نمی‌توان آن‌ها را با سیاست هشدار مدیریت کرد.

بازگرداندن `ReturnAction::Abort` از dispatcher هشدار می‌خواهد عملیات جاری را با ایجاد یک استثنا خاتمه دهد. استثناهای عمومی بسته به عملیات و قالب ارائه متفاوت هستند. به عنوان مثال، هنگام بارگذاری می‌تواند یک [PptxReadException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxreadexception/) یا [PptReadException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptreadexception/) ظاهر شود، در حالی که هنگام ذخیره یا خروجی می‌تواند یک [PptxException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxexception/) ظاهر شود. استثنا را در مرز عملیات بگیرید و از گزارش هشدار برای تعیین اینکه آیا سیاست برنامه باعث خاتمه شده است استفاده کنید، نه فقط اتکای بر یک زیرنوع استثنا یا پیام. callback هشدار را قبل از بازگرداندن `ReturnAction::Abort` ثبت می‌کند تا دلیل برای برنامه در دسترس بماند.

## **دسته‌بندی‌های هشدار**

کلاس [WarningType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/warningtype/) ثابت‌های عددی زیر را برای دسته‌های زیر فراهم می‌کند:

| نوع هشدار | معنی | سیاست معمولی |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fa/php-java/aspose.slides/warningtype/#SourceFileCorruption) | ارائه منبع حاوی فساد است که می‌تواند سند ذخیره‌شده در قالب اصلی را غیرقابل استفاده کند. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/fa/php-java/aspose.slides/warningtype/#DataLoss) | متن، نمودارها، تصاویر یا داده‌های دیگر ممکن است پس از بارگذاری یا ذخیره غایب باشند. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fa/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | ارائه ممکن است قالب‌بندی مهمی را از دست بدهد. | Abort در حالت اعتبارسنجی سخت؛ در غیر این صورت ثبت و ادامه. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fa/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | ممکن است تفاوت قالب‌بندی محدودی رخ دهد. | ثبت برای عیب‌یابی و ادامه. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/warningtype/#CompatibilityIssue) | نتیجه ممکن است در برخی برنامه‌ها یا نسخه‌های قدیمی درست باز نشود یا رفتار نادرستی داشته باشد. | ثبت و ادامه مگر اینکه سازگاری اجباری باشد. |
| [UnexpectedContent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/warningtype/#UnexpectedContent) | منبع شامل محتوای پشتیبانی‌نشده یا شناسایی‌نشده‌ای است که اثر آن هنوز شناخته نشده است. | ثبت و ادامه، یا در سیاست سخت به عنوان خطا در نظر گرفتن. |

دسته‌بندی باید تصمیم‌گیری سیاستی را هدایت کند. مقدار بازگردانده شده توسط [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) را برای عیب‌یابی ذخیره کنید، اما برای منطق برنامه به عبارات آن اتکا نکنید زیرا متن پیام می‌تواند بین سناریوهای هشدار و نسخه‌های محصول متفاوت باشد.

## **جمع‌آوری و طبقه‌بندی هشدارها**

مثال زیر از یک گزارش سطح برنامه برای کل خط لوله پردازش استفاده می‌کند. یک نمونه callback جداگانه هشدارهای بارگذاری، رندر، تبدیل PDF و ذخیره PPTX را برچسب می‌زند. سیاست در صورت فساد منبع یا از دست رفتن داده‌ها abort می‌کند، به‌صورت اختیاری در صورت از دست رفتن قالب‌بندی عمده abort می‌کند و برای سایر هشدارها ادامه می‌دهد. callback قبل از ثبت مقادیر هشدار را با `java_values` به مقادیر بومی PHP تبدیل می‌کند.

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

در زمان ساخت `WarningPolicy` اگر اختلافات قالب‌بندی عمده قابل قبول باشند، `false` را برای `abortOnMajorFormattingLoss` پاس کنید. مشکلات سازگاری، از دست رفتن قالب‌بندی جزئی و محتوای غیرمنتظره حتی زمانی که عملیات ادامه می‌یابد در گزارش حفظ می‌شوند. اگر برنامه باید هر یک از این دسته‌ها را رد کند، `WarningPolicy::getAction` را گسترش دهید.

## **سناریوهای رایج هشدار**

هشدارها می‌توانند در مراحل مختلف یک جریان کار ظاهر شوند:

- **امضای دیجیتال:** یک ارائه امضا‌شده ممکن است در حین بارگذاری هشدار دهد که امضای آن در پردازش از دست خواهد رفت. Aspose.Slides این وضعیت `DataLoss` را از طریق [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationsignedwarninginfo/) گزارش می‌کند. یک callback در مرحله بارگذاری به برنامه اجازه می‌دهد فایل را رد کند یا صراحتاً از از دست رفتن گزارش‌شده پذیرش کند.
- **جایگزینی فونت:** یک فونت که در دسترس نیست می‌تواند هنگام رندر یا خروجی اسلاید جایگزین شود. هشدارهای جایگزینی فونت به عنوان `DataLoss` گزارش می‌شوند، بنابراین سیاست سخت بالا حتی اگر برنامه جایگزینی خاصی را از نظر بصری قابل قبول بداند abort می‌کند. برای مشاهده این رفتار، از یک ارائه ورودی شامل متنی با فونت غیرقابل دسترس برای زمان اجرا استفاده کنید. توضیح هشدار جایگزینی را شناسایی می‌کند؛ فونت‌های مورد نیاز یا [قوانین جایگزینی فونت](/slides/fa/php-java/font-substitution/) را پیش از تلاش مجدد تنظیم کنید.
- **محتوای پشتیبانی‌نشده یا غیرمنتظره:** یک بارگذار ممکن است رکوردها یا ویژگی‌های ارائه‌ای را که شناسایی نمی‌کند، ببیند. چنین هشدارهایی ممکن است `UnexpectedContent` یا دسته‌ای جدی‌تر اگر داده یا قالب‌بندی تحت تأثیر باشد، استفاده کنند.
- **سازگاری قالب:** ذخیره به قالب دیگر می‌تواند ویژگی‌ها را حذف کرده یا نتیجه‌ای تولید کند که در برخی برنامه‌ها رفتار متفاوتی دارد. به عنوان مثال، ذخیره یک ارائه با بیش از هشت راهنمای افقی یا عمودی به PPT قدیمی یک `CompatibilityIssue` گزارش می‌دهد. callback در مرحله ذخیره می‌تواند این از دست رفتن را ثبت کرده و ادامه دهد یا در صورت نیاز به حفظ تمام راهنماها آن را رد کند.
- **رفتار بارگذاری:** گزینه‌های بارگذاری و رفتارهای قدیمی نیز می‌توانند هشدار تولید کنند. به عنوان مثال، [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) استفاده از رفتار قفل‌گذاری ارائه منسوخ را به عنوان `CompatibilityIssue` شناسایی می‌کند.

هشدارها به سند منبع، قالب مقصد، عملیات و نسخه Aspose.Slides وابسته‌اند. فرض نکنید هر فایل هشدار تولید می‌کند یا هر سناریو همیشه به یک دسته محدود می‌شود.

## **مدیریت ایمن عملیات‌های متوقف‌شده**

هنگامی که یک callback `ReturnAction::Abort` باز می‌گرداند، از شیء که بارگذاری نشد استفاده نکنید و فرض نکنید خروجی رندر یا ذخیره کامل است. عملیات ممکن است پس از ایجاد فایل خروجی اما پیش از تکمیل آن خاتمه یابد.

نتایج اعتبارسنجی شده را در مسیری جداگانه مانند `validated-output.pptx` ذخیره کنید. فقط پس از اتمام موفقیت‌آمیز عملیات، زمانی که گزارش هشدار سیاست برنامه را برآورده می‌کند و خروجی قابل باز کردن و بررسی است، ارائه موجود را جایگزین کنید. این کار از بازنویسی فایل منبع معتبر با نتیجه جزئی یا ردشده جلوگیری می‌کند.

یک گزارش هشدار خالی تضمین نمی‌کند که هر ویژگی منبع حفظ شده است. هر بررسی محتوا و بصری اضافی مورد نیاز برنامه را اعمال کنید. همچنین به [Open Presentations](/slides/fa/php-java/open-presentation/) و [Save Presentations](/slides/fa/php-java/save-presentation/) مراجعه کنید.

## **سوالات متداول**

**آیا یک callback هشدار می‌تواند هر خطای Aspose.Slides را مدیریت کند؟**

خیر. تنها شرایط قابل بازیابی که به‌صورت هشدار گزارش می‌شوند را مدیریت می‌کند. استثناهایی که مستقل از callback رخ می‌دهند باید توسط برنامه در اطراف فراخوانی بارگذاری، رندر، تبدیل یا ذخیره مدیریت شوند.

**آیا بازگرداندن `ReturnAction::Continue` خروجی یکسانی را تضمین می‌کند؟**

خیر. فقط اجازه ادامه پردازش را می‌دهد. وضعیت گزارش‌شده هنوز می‌تواند باعث اختلافات داده، قالب‌بندی یا سازگاری شود، بنابراین انواع و توضیحات هشدارهای جمع‌آوری‌شده را مرور کنید.

**یک برنامه چگونه می‌تواند عملیات تولید کننده هشدار را شناسایی کند؟**

برای هر عملیات یک نمونه callback ایجاد کنید و مرحله تعریف‌شده توسط برنامه را همراه با مقادیر بازگردانده‌شده توسط [getWarningType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) ذخیره کنید، همان‌طور که در مثال نشان داده شده است.