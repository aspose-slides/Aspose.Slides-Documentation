---
title: تبدیل ارائه‌های PowerPoint به XML در PHP
linktitle: PowerPoint به XML
type: docs
weight: 145
url: /fa/php-java/convert-powerpoint-to-xml/
keywords:
- تبدیل PowerPoint به XML
- تبدیل ارائه به XML
- PPT به XML
- PPTX به XML
- ODP به XML
- ارائه XML PowerPoint
- SaveFormat.Xml
- ذخیره ارائه به عنوان XML
- صادرات ارائه به XML
- جریان XML
- PHP
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های XML PowerPoint در PHP با Aspose.Slides for PHP via Java."
---
## **بررسی کلی**

Aspose.Slides for PHP via Java می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML زمانی مفید است که به نمایشی متنی برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار، یا یکپارچه‌سازی با گردش کاری که به‌جای بسته ارائه، XML مصرف می‌کند، نیاز دارید.

از متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) با مقدار `Xml` از شمارش [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیماً در یک فایل یا به یک جریان بنویسید.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` یک PowerPoint XML Presentation ایجاد می‌کند. این مقدار بخش‌های جداگانه Office Open XML ذخیره شده در بسته PPTX را استخراج نمی‌کند. اگر به بخش‌های دقیق بسته PPTX مانند `ppt/presentation.xml` یا فایل‌های XML اسلایدهای منفرد نیاز دارید، خود بسته PPTX را بررسی کنید.
{{% /alert %}}

## **تبدیل یک ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید و سپس مسیر خروجی و `SaveFormat::Xml` را به متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) پاس دهید. منبع می‌تواند هر فرمتی از ارائه باشد که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP.

مثال زیر یک ارائه PPTX را به یک فایل XML تبدیل می‌کند:

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

## **نوشتن خروجی XML به یک جریان**

از نسخه overload متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) برای جریان استفاده کنید وقتی که XML باید در حافظه بماند یا به مؤلفه دیگری مانند سرویس وب، ارائه‌دهنده ذخیره‌سازی یا خط لوله پردازش XML پاس داده شود. مثال زیر نتیجه را به یک [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) می‌نویسد و XML تولید شده را به صورت یک آرایه بایت دریافت می‌کند:

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

        // $xmlBytes را به مؤلفه بعدی در جریان کار پاس دهید.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

یک `ByteArrayOutputStream` تمام داده‌های تولید شده را در حافظه ذخیره می‌کند، بنابراین قبل از فراخوانی `toByteArray` نیاز به بازنشانی موقعیت نیست.

## **مقایسه XML با فرمت‌های ارائه و خروجی**

فرمت خروجی را بر اساس نحوه استفاده از نتیجه انتخاب کنید:

| فرمت | خروجی | کاربرد معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک ارائه PowerPoint XML | بررسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائه باینری قدیمی | سازگاری با گردش کارهای قدیمی PowerPoint |
| PPTX (`.pptx`) | یک بسته Office Open XML حاوی چندین بخش | ویرایش معمولی PowerPoint و تبادل ارائه |
| PDF یا TIFF | صفحات با چیدمان ثابت یا یک تصویر چندصفحه‌ای | مشاهده، چاپ و آرشیو |
| PNG، JPEG یا SVG | نمایش رندر شده‌ای از یک اسلاید منفرد | تصاویر بندانگشتی، پیش‌نمایش‌ها و منابع تصویری |
| HTML یا HTML5 | خروجی ارائه‌محور وب | مشاهده در مرورگر و انتشار وب |

برخلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و جریان‌های کاری مبتنی بر داده طراحی شده است. برخلاف PDF، TIFF، HTML و فرمت‌های تصویر اسلاید، این خروجی داده‌های ارائه را نشان می‌دهد نه رندر اسلایدها به صورت صفحه یا دارایی‌های تصویری. جدول [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/php-java/supported-file-formats/) PowerPoint XML Presentation را به عنوان یک فرمت صرفاً ذخیره‌سازی فهرست می‌کند، بنابراین وقتی یک جریان کاری نیاز دارد که فایل صادر شده را دوباره در Aspose.Slides بارگذاری کند برای ویرایش ادامه‌دار، از آن استفاده نکنید.

## **سؤالات متداول**

**آیا `SaveFormat::Xml` همانند ذخیره یک فایل PPTX است؟**

خیر. PPTX یک بسته است که شامل چندین بخش Office Open XML می‌شود، در حالی که `SaveFormat::Xml` یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توانم خروجی XML را بدون ایجاد فایل بر روی دیسک ذخیره کنم؟**

بله. یک جریان قابل نوشتن را به متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) پاس دهید. برای مثال، از یک [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) برای پردازش در حافظه استفاده کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادر شده را دوباره بارگذاری کند؟**

خیر. PowerPoint XML Presentation در حال حاضر فقط برای ذخیره پشتیبانی می‌شود و برای بارگذاری قابل استفاده نیست. هنگامی که نیاز به ویرایش دوری (round‑trip) دارید، از PPTX یا یک فرمت ارائه پشتیبانی‌شده دیگر استفاده کنید.

**آیا تبدیل XML هر اسلاید را به یک صفحه یا تصویر رندر می‌کند؟**

خیر. تبدیل XML داده‌های ساختاریافتهٔ ارائه را می‌نویسد. برای خروجی مبتنی بر صفحه از PDF یا TIFF استفاده کنید یا برای تصاویر اسلایدهای منفرد از PNG، JPEG و SVG بهره ببرید.