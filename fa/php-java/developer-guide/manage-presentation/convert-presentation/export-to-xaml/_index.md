---
title: صادرات ارائه‌ها به XAML در PHP
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/php-java/export-to-xaml/
keywords:
- صدور PowerPoint
- صدور OpenDocument
- صدور ارائه
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- PowerPoint به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به عنوان XAML
- ذخیره PPTX به عنوان XAML
- ذخیره ODP به عنوان XAML
- صدور PPT به XAML
- صدور PPTX به XAML
- صدور ODP به XAML
- PHP
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML با استفاده از Aspose.Slides برای PHP از طریق Java — راه‌حل سریع و بدون نیاز به Office که طرح‌بندی شما را دست‌نخورده نگه می‌دارد."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را به XAML با استفاده از Aspose.Slides صادر کنید. شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید و نحوه سفارشی‌سازی صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/) به‌ویژه صادرات اسلایدهای مخفی، نشان می‌دهد. مقاله همچنین به برخی سؤالات رایج درباره فونت‌های جایگزین، سازگاری استک XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان نشانه‌گذاری مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با یک طراح بصری با فایل‌های XAML کار کنید یا نشانه‌گذاری را به‌صورت مستقیم بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال PHP زیر نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید. قبل از اجرای مثال‌ها در این مقاله، PHP Java Bridge را مقداردهی اولیه کنید و `aspose.slides.php` را بارگیری کنید. فایل `pres.pptx` را در پوشه کاری سرور Java Bridge قرار دهید یا مسیر مطلق دسترسی‌پذیری به آن سرور را فراهم کنید.

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

به‌طور پیش‌فرض، اسلایدهای صادر شده در یک زیرپوشه `pres` از پوشه کاری جاری سرور Java Bridge ذخیره می‌شوند. این پوشه به‌صورت خودکار ایجاد می‌شود و هر تصویر مورد نیاز نیز در همانجا ذخیره می‌شود.

نام پوشه خروجی از نام فایل منبع بدون پسوند آن گرفته می‌شود. برای `pres.pptx`، فایل‌های خروجی به‌صورت `pres/Slide_1.xaml`، `pres/Slide_2.xaml` و غیره نام‌گذاری می‌شوند. حتی اگر مسیر مطلقی به ارائه ورودی بدهید، پوشه خروجی نسبت به پوشه کاری جاری سرور Java Bridge ایجاد می‌شود، نه در کنار فایل ورودی.

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

از اینترفیس [IXamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloptions/) برای کنترل نحوه صادرات یک ارائه به XAML توسط Aspose.Slides استفاده کنید.

برای ذخیره خروجی در مکان سفارشی، یک پروکسی Java که اینترفیس [IXamlOutputSaver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloutputsaver/) را پیاده‌سازی می‌کند، فراهم کنید و یک نمونه از پیاده‌سازی خود را به متد [setOutputSaver](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/#setOutputSaver) از [XamlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/) پاس دهید.

برای گنجاندن اسلایدهای مخفی در خروجی XAML، با `true` متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) را صدا بزنید، همان‌طور که در مثال PHP زیر نشان داده شده است:

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

## **جمع‌آوری تمام آثار تولید شده XAML**

یک صادرات XAML می‌تواند یک سند XAML برای هر اسلاید صادر شده به‌همراه تصویرها و منابع پشتیبانی کنندهٔ جداگانه تولید کند. برای دریافت این آثار به‌جای استفاده از ذخیره‌کنندهٔ پیش‌فرض سیستم‌فایل، یک [IXamlOutputSaver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloutputsaver/) سفارشی به [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/#setOutputSaver) اختصاص دهید. صادرات را با فراخوانی overload مخصوص XAML از [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) که گزینه‌های XAML را می‌پذیرد، آغاز کنید.

تابع `java_closure` در PHP Java Bridge یک شیء PHP را به عنوان اینترفیس Java در دسترس قرار می‌دهد. هر دو ذخیره‌کنندهٔ PHP و پروکسی آن را تا پایان صادرات زنده نگه دارید. پیوندهای اینترفیس به API Java که توسط پروکسی پیاده‌سازی می‌شود، اشاره می‌کنند.

### **درک طول‌عمر Callback**

صادرکننده به صورت جداگانه برای هر اثر تولید شده متد [IXamlOutputSaver::save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) را فراخوانی می‌کند:

- `path` هویت اثر را شناسایی می‌کند و می‌تواند شامل مسیرهای نسبی باشد. این اطلاعات را حفظ کنید چون XAML ممکن است منابع را با مسیرهای نسبی ارجاع دهد.
- `data` بایت‌های اثر را شامل می‌شود. تصویرها و سایر منابع باینری نباید به‌عنوان متن رمزگشایی شوند.
- ذخیره‌کننده مسئول نگهداری یا پایدارسازی داده‌ها پیش از بازگشت است. مثال‌ها هر آرایهٔ بایت Java را به یک رشتهٔ باینری PHP تبدیل می‌کنند که توسط برنامه مدیریت می‌شود.
- صادرات را فقط زمانی موفق بدانید که عملیات ذخیرهٔ ارائه بازگردد و تمام callback‌ها با موفقیت کامل شوند. خطاهای ذخیره‌سازی را نادیده نگیرید یا نوشتن پس‌زمینهٔ بدون نظارت را آغاز نکنید. اگر پایدارسازی پس از آن انجام شود، موفقیت کلی را تنها پس از موفقیت آن مرحله گزارش کنید.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) همچنین برای ذخیره‌کنندهٔ سفارشی اعمال می‌شود. تنظیم پیش‌فرض `false` اسناد XAML اسلایدهای مخفی را حذف می‌کند. ارسال `true` آن‌ها و هر منبع موردنیاز برای صادراتشان را شامل می‌شود. تعداد منابع به ارائه بستگی دارد؛ فرض نکنید یک callback برای هر اسلاید یا ترتیب ثابت callback‌ها وجود دارد.

### **صادرات به حافظه و بررسی آثار**

این مثال کامل `pres.pptx` را بارگذاری می‌کند، هر اثر را در یک آرایهٔ انجمنی PHP از رشته‌های باینری جمع‌آوری می‌کند و نام، نوع و تعداد بایت آن را چاپ می‌کند. نام‌های ارائه‌شده را دقیقا همان‌طور حفظ می‌کند. نام‌های تکراری مجموعه را نامعتبر می‌سازند به‌جای بازنویسی بی‌صدا. مثال قبل از استفاده از نتایج این‌را بررسی می‌کند.

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

    // فقط XAML به‌عنوان متن UTF-8 برای بازرسی اختیاری در نظر گرفته می‌شود.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

بررسی پسوندها برای بازرسی مفید است؛ تمام آثار، شامل انواع منابع ناشناخته، حفظ شوند. هنگام ذخیره یا انتقال بایت‌ها را دست نخورده نگه دارید. رشته‌های PHP می‌توانند دادهٔ باینری را شامل بایت‌های صفر نگه دارند. یک رشته را فقط زمانی که XAML را بررسی می‌کنید به‌عنوان متن UTF‑8 درنظر بگیرید؛ بایت‌های تصویر یا منبع را تبدیل به متن نکنید.

### **بسته‌بندی آثار جمع‌آوری‌شده در آرشیو ZIP**

این مثال مستقل صادرات را جمع‌آوری، نام‌ها را اعتبارسنجی و بایت‌های اصلی را در یک آرشیو ZIP می‌نویسد. یک پوشهٔ کار مخصوص فقط برای این کار ایجاد می‌شود تا کارهای صادرات هم‌زمان جدا شوند. این مثال به افزونهٔ PHP Phar با پشتیبانی ZIP نیاز دارد. ورودی‌های ZIP از اسلش‌های جلو استفاده می‌کنند و مسیرهای نسبی را حفظ می‌کنند. نام‌های ناامن یا نام‌هایی که پس از نرمال‌سازی با هم تداخل پیدا می‌کنند، تمام بسته را قبل از نوشتن رد می‌کنند.

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

این مثال از [PharData](https://www.php.net/manual/en/class.phardata.php) برای نوشتن یک آرشیو ZIP محلی در پوشهٔ کاری فرایند PHP استفاده می‌کند؛ صادرکننده خود فایل‌های XAML یا تصویر را به‌صورت پخش‑پذیر نمی‌نویسد. برای ذخیره‌سازی از راه دور، مرحلهٔ نوشتن آرشیو را با بارگذاری رشته‌های باینری جمع‌آوری‌شده جایگزین کنید. از شناسهٔ کار صادرات به‌همراه نام نسبی کامل اثر به عنوان کلید blob استفاده کنید یا شناسهٔ کار، نام نسبی و دادهٔ باینری را در یک ردیف دیتابیس ذخیره کنید. کار را فقط پس از تکمیل تمام بارگذاری‌ها یا Commit تراکنش دیتابیس منتشر کنید. در صورت شکست پایدارسازی، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، یک ذخیره‌کنندهٔ سفارشی می‌تواند هر اثر را مستقیماً در ذخیره‌سازی برنامه ذخیره کند تا از نگهداری یک نسخهٔ اضافی از تمام صادرات در حافظهٔ برنامه جلوگیری شود. هر callback را از دید صادرکننده به‌صورت synchronous نگه دارید: فقط پس از اینکه مقصد بایت‌ها را پذیرفت بازگردید و اجازه دهید خطاها به فراخواننده برسند.

### **حفظ نام منابع و تأیید مراجع**

- هنگام نیاز مقصد جداکننده‌های مسیر را نرمال کنید، اما مسیرهای نسبی را حفظ کنید. مگر اینکه مطمئن باشید هر نام تولیدشده منحصربه‌فرد است و مراجع منابع معتبر می‌مانند، از [basename](https://www.php.net/manual/en/function.basename.php) به‌تنهایی استفاده نکنید.
- اعتبارسنجی نام خاص مقصد را اعمال کنید. هنگام نوشتن فایل‌های پخش‑پذیر، مسیرهای ریشه‌ای و بخش‌های Traversal را رد کنید، مسیر مقصد را به مسیری مطلق تبدیل کنید و اطمینان حاصل کنید که زیر مسیر موردنظر باقی می‌ماند، شامل جداکنندهٔ مسیر در بررسی containment. از یک پوشهٔ تحت کنترل برنامه بدون لینک‌های سمبلیک که ممکن است نوشتن را به‌سمت دیگر هدایت کنند، استفاده کنید.
- برای هر کار صادرات، یک ذخیره‌کننده و فضای نام ذخیره‌سازی جداگانه داشته باشید. پس از نرمال‌سازی جداکننده‌ها و بر حسب قواعد حساسیت به حروف مقصد، تداخل‌ها را شناسایی کنید.
- پیش از انتشار، هر سند XAML را به‌عنوان XML تجزیه کنید و مراجع منابع مبتنی بر فایل، مانند ویژگی‌های `Source` یا `ImageSource` تصویر را بررسی کنید. هر URI نسبی را نسبت به پوشهٔ اثر XAML حاوی آن حل کنید، نام ذخیره‌سازی نتیجه را نرمال کنید و تأیید کنید که کلید نقشهٔ مربوطه، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URIهای خارجی و عبارات XAML markup را از نام‌های فایل نسبی جداگانه بررسی کنید.

به عنوان مثال، اگر `pres/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به صورت `pres/images/image1.png` قابل دسترس باشد. فقط نگه‌ داشتن `image1.png` این رابطه را می‌شکند. برای ذخیره‌سازی شیء، همان ساختار زیر پیش‌وند کار را حفظ کنید و URLهای منابع را به‌گونه‌ای در دسترس مصرف‌کننده XAML قرار دهید. پس از تکمیل ZIP را مجدداً باز کنید تا نام ورودی‌ها و بایت‌های منبع را تأیید کنید و اسلایدهای نمونه را در محیط هدف XAML بارگذاری کنید تا اطمینان حاصل شود تصویرها به‌درستی حل می‌شوند.

## **سوالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که فونت‌ها پیش‌بینی‌پذیر هستند اگر فونت اصلی روی دستگاه موجود نباشد؟**

در [XamlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/) متد [setDefaultRegularFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) را صدا بزنید — این فونت به‌عنوان فونت جایگزین در هنگام صادرات استفاده می‌شود وقتی فونت اصلی موجود نباشد. این تضمین نمی‌کند که XAML تولیدشده به فونت جایگزین ارجاع دهد یا اینکه فونت بر روی دستگاه هدف موجود باشد. اطمینان حاصل کنید فونت‌های ارجاع‌شده توسط XAML در محیطی که نمایش داده می‌شود موجود باشند.

**آیا XAML صادرشده فقط برای WPF است یا می‌تواند در سایر استک‌های XAML نیز استفاده شود؟**

Aspose.Slides XAML مخصوص WPF را از طریق API عمومی خود صادر می‌کند. سازگاری با سایر استک‌های XAML مانند UWP و Xamarin.Forms تضمین نشده است. markup تولیدشده را در محیط هدف خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آن‌ها جلوگیری کنم؟**

به‌صورت پیش‌فرض، اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را از طریق [setExportHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) در [XamlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/) کنترل کنید — اگر نیازی به صادرات آن‌ها ندارید، این گزینه را غیرفعال نگه دارید.