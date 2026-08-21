---
title: عملیات ارائه کدکم در PHP
linktitle: API کدکم
type: docs
weight: 50
url: /fa/php-java/low-code-presentation-operations/
keywords:
- API ارائه کدکم
- تبدیل ارائه
- ادغام ارائه‌ها
- تکرار اسلایدها
- تکرار اشکال
- تکرار متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف اسلایدهای مستر بدون استفاده
- حذف اسلایدهای لایه بدون استفاده
- فشرده‌سازی قلم‌های توکار
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در PHP برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش اندازه ارائه استفاده کنید."
---
## **بررسی کلی**

فضای‌نام [aspose.slides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/) کلاس‌های کمکی استاتیک برای عملیات‌های رایج ارائه را فراهم می‌کند. این کمکی‌ها جریان‌کارهای مدل شیء پرکاربرد را در متدهای متمرکز می‌پیچند، به‌طوری‌که می‌توانید فایل‌ها را تبدیل یا ادغام کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای بدون استفاده را با کد کمتر حذف کنید.

کمکی‌های کدکم وقتی مفیدترند که عملیات بر یک فایل یا ارائه کامل اعمال شود و جریان‌کار پیش‌فرض با نیازهای شما مطابقت داشته باشد. زمانی که به کنترل دقیق بر اسلایدهای منفرد، مسترها، لایه‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه نیاز دارید، از مدل شیء کامل [Aspose.Slides object model](https://reference.aspose.com/slides/fa/php-java/aspose.slides/) استفاده کنید.

جدول زیر دستیارهای موجود را خلاصه می‌کند:

| کمکی | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/php-java/aspose.slides/convert/) | تبدیل یک ارائه به فرمت دیگر با فراخوانی مستقیم فایل به فایل. |
| [Merger](https://reference.aspose.com/slides/fa/php-java/aspose.slides/merger/) | ترکیب کامل فایل‌های ارائه‌ای با همان فرمت. |
| [ForEach_](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/) | اجرای یک فراخوانی برای هر اسلاید، شکل، پاراگراف یا بخش متن. |
| [Collect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/collect/) | بازیابی اشکال از کل ارائه برای پردازش یا تجزیه و تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) | حذف مسترها و لایه‌های بدون استفاده و کاهش داده‌های قلم‌های توکار. |

## **تبدیل یک ارائه**

هنگامی که پسوند فایل خروجی برای انتخاب فرمت خروجی کافی است، از [Convert::autoByExtension](https://reference.aspose.com/slides/fa/php-java/aspose.slides/convert/#autoByExtension) استفاده کنید. این متد ارائه منبع را باز می‌کند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌نماید و نتیجه را می‌نویسد.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/php-java/aspose.slides/convert/) همچنین متدهای ویژه‌ای برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌کند. زمانی که لازم است پیش از خروجی‌گیری ارائه را بررسی یا تغییر دهید یا گزینه‌ای خروجی را تنظیم کنید که توسط کمکی انتخاب‌شده در دسترس نیست، از مدل شیء کامل استفاده کنید. برای گردش‌کارها و گزینه‌های مخصوص هر فرمت، به [Convert Presentation](/php-java/convert-presentation/) مراجعه کنید.

## **ادغام ارائه‌ها**

برای ترکیب کامل فایل‌های ارائه با یک فراخوانی، از [Merger::process](https://reference.aspose.com/slides/fa/php-java/aspose.slides/merger/#process) استفاده کنید. ارائه‌های ورودی باید دارای همان فرمت فایل باشند.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

این کمکی زمانی مناسب است که همه اسلایدها باید بدون انتخاب یا نگاشت مجدد به یک نتیجه اضافه شوند. وقتی نیاز به ادغام اسلایدهای منتخب، اعمال مستر یا لایه مقصد، حفظ بخش‌ها به‌صورت صریح یا سازگارسازی اندازه‌های متفاوت اسلاید دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها، به [Merge Presentations](/php-java/merge-presentation/) نگاه کنید.

## **تکرار در عناصر ارائه**

کلاس [ForEach_](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/) برای هر نوع عنصر ارائه‌ای که درخواست می‌شود، یک فراخوانی را اجرا می‌کند. این کار از حلقه‌های تو در توی جمع‌آوری جلوگیری می‌کند و برای بازرسی یا تغییر فرمت سراسری ارائه مناسب است.

مثال زیر از [ForEach_::slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#slide)، [ForEach_::shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#shape)، [ForEach_::paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#paragraph) و [ForEach_::portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#portion) برای بررسی عناصر مربوطه استفاده می‌کند:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

به‌صورت پیش‌فرض، پیمایش اشکال و متون در سرتاسر ارائه شامل اسلایدهای عادی، مستر و لایه می‌شود. بارگذاری‌های دارای پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. زمانی که ترتیب پیمایش، خروج زودهنگام، فیلتر کردن قبل از فراخوانی یا کنترل دقیق والد‑فرزند مهم باشد، از حلقه‌های مستقیم جمع‌آوری استفاده کنید.

## **جمع‌آوری اشکال**

زمانی که به مجموعه‌ای از تمام اشکال موجود در یک ارائه نیاز دارید نه یک فراخوانی برای هر شکل، از [Collect::shapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/collect/#shapes) استفاده کنید. این کار هنگامی مفید است که همان مجموعه بارها فیلتر، شمارش یا پردازش شود.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

به‌جای آن وقتی هر شکل می‌تواند بلافاصله در فراخوانی پردازش شود و نیازی به نگه‌داشتن نتیجهٔ جمع‌آوری‌شده ندارید، از [ForEach_::shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#shape) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) می‌تواند عناصر ساختاری بدون استفاده را حذف کرده و داده‌های قلم توکار را کاهش دهد:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) اسلایدهای لایه‌ای را که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد، حذف می‌کند.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#removeUnusedMasterSlides) مسترهای غیرقابل استفاده را حذف می‌کند.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#compressEmbeddedFonts) حروف استفاده‌نشده را از قلم‌های توکار حذف می‌کند.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لایه‌های بدون استفاده را پیش از مسترهای بدون استفاده حذف کنید تا مستری که پس از پاک‌سازی لایه‌ها دیگر ارجاع داده نمی‌شود، نیز حذف شود. اگر ممکن است بعداً به مسترها، لایه‌ها یا داده‌های کامل قلم توکار اصلی نیاز داشته باشید، ارائه بهینه‌شده را در فایل جدیدی ذخیره کنید. برای جزئیات بیشتر، به [Slide Master](/php-java/slide-master/) و [Embedded Font](/php-java/embedded-font/) مراجعه کنید.

## **سوالات متداول**

**چه زمان‌هایی باید از API کدکم به‌جای مدل شیء کامل استفاده کنم؟**  
هنگامی که یک عملیات استاندارد بر یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل دقیق بر عناصر منفرد ندارید، از کمک‌های کدکم استفاده کنید. وقتی نیاز به انتخاب اسلایدهای خاص، کنترل روابط مستر و لایه، بررسی وضعیت میانی یا پیکربندی رفتاری که کمکی آن را فراهم نمی‌کند دارید، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در فرمت‌های فایل متفاوت ترکیب کند؟**  
خیر. متد [Merger::process](https://reference.aspose.com/slides/fa/php-java/aspose.slides/merger/#process) نیاز دارد ارائه‌های ورودی هم‌فرمت باشند. ابتدا فایل‌های ورودی را به یک فرمت مشترک تبدیل کنید، برای مثال با [Convert::autoByExtension](https://reference.aspose.com/slides/fa/php-java/aspose.slides/convert/#autoByExtension)، سپس فایل‌های تبدیل‌شده را ادغام کنید.

**آیا ForEach_ مستر، لایه و اسلایدهای یادداشت را پردازش می‌کند؟**  
متد [ForEach_::slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#slide) فقط اسلایدهای عادی ارائه را مرور می‌کند. عملیات سراسری [ForEach_::shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#shape)، [ForEach_::paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#paragraph) و [ForEach_::portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#portion) به‌طور پیش‌فرض اسلایدهای عادی، مستر و لایه را شامل می‌شوند. برای شامل کردن اسلایدهای یادداشت، از بارگذاری‌هایشان با `includeNotes` برابر `true` استفاده کنید.

**تفاوت بین ForEach_::shape و Collect::shapes چیست؟**  
از [ForEach_::shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#shape) برای پردازش فوری هر شکل از طریق یک فراخوانی استفاده کنید. وقتی به یک نتیجه قابل تکرار نیاز دارید که بتوان آن را نگه‌داشت، فیلتر یا چندین بار پیمایش کرد، از [Collect::shapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/collect/#shapes) بهره ببرید.

**آیا Compress همیشه اندازه فایل ارائه را کوچک می‌کند؟**  
لزماً نیست. نتیجه به این بستگی دارد که آیا در ارائه لایه‌های بدون استفاده، مسترهای بدون استفاده یا قلم‌های توکار با کاراکترهای استفاده‌نشده وجود دارد یا خیر. اگر هیچ‌یک از این موارد موجود نباشد، عملیات‌های مربوط به [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) ممکن است اندازه فایل را کاهش ندهند.

**آیا تغییرات اعمال‌شده توسط ForEach_ یا Compress به‌صورت خودکار ذخیره می‌شوند؟**  
خیر. این کمک‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری‌شده در حافظه عمل می‌کنند. پس از تغییر عناصر در فراخوانی [ForEach_](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_) یا اجرای [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/)، برای نوشتن نتیجه باید از [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) استفاده کنید.

## **مقالات مرتبط**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)