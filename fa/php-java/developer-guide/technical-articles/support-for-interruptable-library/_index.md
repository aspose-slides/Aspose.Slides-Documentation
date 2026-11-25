---
title: قطع عملیات‌های طولانی‌مدت ارائه در PHP
linktitle: قطع عملیات ارائه
type: docs
weight: 120
url: /fa/php-java/support-for-interruptable-library/
keywords:
- توکن قطع‌کار
- لغو
- زمان‌سنج تبدیل
- خروجی اسلاید
- پاورپوینت
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه تبدیل یک ارائه را با یک زمان‌سنج لغو کنید و اسلایدهای صادرشده پیش از لغو را با Aspose.Slides برای PHP از طریق Java برگردانید."
---
## **بررسی کلی**

Aspose.Slides برای PHP از طریق Java می‌تواند عملیات طولانی‌مدتی مانند بارگذاری، ذخیره‌سازی و رندر ارائه‌ها را قطع کند. در حلقه‌ای که به‌صورت تک‌تک اسلایدها را صادر می‌کند، همان توکن به برنامه شما اجازه می‌دهد پیش از اسلاید بعدی متوقف شود و فهرستی از صادرات کامل‌شده را برگرداند.

هر دو مثال PHP فرض می‌کنند که بوت‌استرپ شما قبل از بارگذاری `Java.inc` پل، فراخوانی `define("JAVA_PREFER_VALUES", 1);` را انجام دهد، سپس `aspose.slides.php` را لود می‌کند. این تنظیم به PHP امکان می‌دهد استثناهای Java را در طول فراخوانی دریافت کند. مثال‌ها علت استثنای بسته‌بندی‌شده را بررسی می‌کنند تا سایر خطاهای تبدیل به فراخواننده برسد.

## **قطع یک عملیات ارائه**

یک [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/) ایجاد کنید، توکن آن را با [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) دریافت کنید و آن را به [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken) پاس دهید. این گزینه‌ها را هنگام ساختن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) فراهم کنید. فراخوانی [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) درخواست لغو را صادر می‌کند. یک عملیات در حال اجرا هنگامی که درخواست را مشاهده کند متوقف می‌شود.

### **تنظیم زمان‌سنج تبدیل**

در حالی که PHP برای یک بارگذاری یا ذخیرهٔ همزمان از طریق PHP/Java Bridge منتظر می‌ماند، یک تایمر Java می‌تواند درخواست لغو را در یک نخ جداگانه صادر کند. کد کمکی زیر را به‌عنوان `ConversionTimeout.java` ذخیره کنید، با Aspose.Slides JAR روی classpath آن را کامپایل کنید و کلاس کامپایل‌شده را تحت نام بستهٔ `example.ConversionTimeout` در دسترس پل قرار دهید.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

با بارگذاری پل و wrapper PHP Aspose.Slides، مثال زیر را با `sample.pptx` که در مسیر کاری فرآیند Java قرار دارد اجرا کنید، یا از مسیرهای مطلقی که برای آن فرآیند قابل دسترس هستند استفاده کنید. محدودیت 20‑ثانیه‌ای شامل هر دو بارگذاری و خروجی PDF است. اگر تبدیل زودتر پایان یابد، PHP تایمر را لغو می‌کند. برای تبدیل به فرمت قدیمی PowerPoint با محدودیت 10‑ثانیه‌ای، از `sample.ppt`، `SaveFormat::Ppt` و `10000` میلی‌ثانیه استفاده کنید.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **توقف قبل از پردازش اسلاید بعدی**

قبل از هر خروجی، [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) را بررسی کنید. overload متد [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) برای اسلایدهای انتخابی شماره اسلایدها را از 1 شروع می‌کند. برای نوشتن یک PDF جداگانه برای هر اسلاید، آرایه‌ای با یک عنصر پاس دهید.

از یک `sample.pptx` که حداقل دو اسلاید دارد استفاده کنید. برای نشان دادن لغو بین خروجی‌ها، مثال بلافاصله پس از ثبت اولین اسلاید درخواست لغو را می‌دهد.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

مثال `slide-1.pdf` را می‌نویسد و `Completed: [1]` را چاپ می‌کند. در تکرار دوم، درخواست را قبل از شروع خروجی دیگر می‌بیند. اگر لغو در طول ذخیره رخ دهد، فهرست فقط شامل خروجی‌های تأییدشدهٔ پیشین خواهد بود. یک ذخیرهٔ مختل می‌تواند فایل ناقصی را بر روی دیسک باقی بگذارد.

برای انتقال لغو به فراخواننده، بررسی در ابتدای حلقه را با `$token->throwIfInterruptionRequested();` جایگزین کنید و `try`/`catch` داخلی را حذف کنید، در حالی که ذخیره و بررسی پس از آن را نگه می‌دارید. با همان ورودی، [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) قبل از اسلاید 2 یک استثنا پرتاب می‌کند و فراخواننده هیچ فهرستی دریافت نمی‌کند.

## **سوالات متداول**

**کی باید درخواست لغو را بدهم؟**  
در زمانی که مهلتی منقضی می‌شود یا فراخواننده دیگر به نتیجه نیاز ندارد، درخواست لغو دهید. درخواست‌ای که پس از پایان یک عملیات انجام شود، نتیجهٔ آن را دست‌نخورده می‌گذارد.

**منبع و توکن چه تفاوتی دارند؟**  
منبع به برنامه اجازه می‌دهد درخواست لغو بدهد. توکن به Aspose.Slides و کد برنامه امکان مشاهدهٔ آن درخواست را می‌دهد.

**آیا چند عملیات می‌توانند یک منبع را به‌اشتراک بگذارند؟**  
بله. یک درخواست برای تمام عملیات‌هایی که از توکن‌های آن منبع استفاده می‌کنند اعمال می‌شود. برای عملیات‌هایی که نیاز به لغو مستقل دارند، منابع جداگانه‌ای ایجاد کنید.