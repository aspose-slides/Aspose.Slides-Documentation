---
title: عملیات‌های ارائه کم‌کد در PHP
linktitle: API کم‌کد
type: docs
weight: 50
url: /fa/php-java/low-code-presentation-operations/
keywords:
- API ارائه کم‌کد
- تبدیل ارائه
- ادغام ارائه‌ها
- تکرار اسلایدها
- تکرار اشکال
- تکرار متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف مسترهای استفاده‌نشده
- حذف لایه‌های استفاده‌نشده
- فشرده‌سازی قلم‌های توکار
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در PHP برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش اندازه ارائه استفاده کنید."
---
## **بررسی اجمالی**

فضای نام [aspose.slides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/) کلاس‌های استاتیک کمکی برای عملیات‌های رایج ارائه‌ها را فراهم می‌کند. این کمکی‌ها جریان‌های کاری پرکاربرد شیء‑مدل را در متدهای متمرکز می‌پیچند، بنابراین می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای استفاده‑نشده را با کد کمتر حذف کنید.

کمکی‌های کم‑کد وقتی که عملیات بر کل فایل یا ارائه اعمال می‌شود و جریان کاری پیش‌فرض با نیازهای شما منطبق است، بیشترین کاربرد را دارند. زمانی که نیاز به کنترل دقیق بر اسلایدهای منفرد، مسترها، لایه‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه دارید، از [Aspose.Slides object model](https://reference.aspose.com/slides/fa/php-java/aspose.slides/) کامل استفاده کنید.

جدول زیر خلاصه‌ای از کمکی‌های موجود را نشان می‌دهد:

| کمک‌کننده | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/php-java/aspose.slides/convert/) | تبدیل یک ارائه به قالب دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/php-java/aspose.slides/merger/) | ترکیب کامل فایل‌های ارائه‌ای با همان قالب. |
| [ForEach_](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/) | اجرای یک callback برای هر اسلاید، شکل، پاراگراف یا بخش متن. |
| [Collect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/collect/) | بازیابی اشکال از کل ارائه برای پردازش یا تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) | حذف مسترها و لایه‌های استفاده‌نشده و کاهش داده‌های قلم‌های توکار. |

## **تبدیل یک ارائه**

زمانی که پسوند فایل خروجی برای انتخاب قالب خروجی کافی است، از [Convert::autoByExtension](https://reference.aspose.com/slides/fa/php-java/aspose.slides/convert/#autoByExtension) استفاده کنید. این متد ارائه منبع را باز می‌کند، قالب مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/php-java/aspose.slides/convert/) همچنین متدهای اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌کند. زمانی که نیاز به بررسی یا تغییر ارائه پیش از خروجی یا تنظیم گزینه‌ای دارید که توسط کمکی انتخاب‑شده در دسترس نیست، از مدل شیء کامل استفاده کنید. برای گردش‌کارها و گزینه‌های خاص قالب، به صفحه [تبدیل ارائه](/slides/fa/php-java/convert-presentation/) مراجعه کنید.

## **ترکیب ارائه‌ها**

برای ترکیب کامل فایل‌های ارائه‌ای با یک فراخوانی، از [Merger::process](https://reference.aspose.com/slides/fa/php-java/aspose.slides/merger/#process) استفاده کنید. ارائه‌های ورودی باید دارای همان قالب فایل باشند.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

این کمکی زمانی مناسب است که همه اسلایدها باید بدون انتخاب یا بازنقش‌گذاری جداگانه، به یک نتیجه افزوده شوند. زمانی که نیاز به ترکیب اسلایدهای انتخابی، اعمال یک مستر یا لایه مقصد، حفظ بخش‌ها به‌صورت صریح یا تطبیق اندازه‌های اسلاید متفاوت دارید، از مدل شیء کامل استفاده کنید. برای این حالات، به صفحه [ترکیب ارائه‌ها](/slides/fa/php-java/merge-presentation/) مراجعه کنید.

## **تکرار در عناصر ارائه**

کلاس [ForEach_](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/) برای هر نوع عنصر ارائه‌ای که درخواست می‌شود، یک callback فراخوانی می‌کند. این کار از حلقه‌های تو در توی جمع‌آوری جلوگیری می‌کند و برای بازرسی یا تغییرات فرمت‌گذاری در سطح کل ارائه مناسب است.

مثال زیر از متدهای [ForEach_::slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#slide)، [ForEach_::shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#shape)، [ForEach_::paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#paragraph) و [ForEach_::portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#portion) برای بازرسی عناصر مربوطه استفاده می‌کند:

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

به‌طور پیش‌فرض، پیمایش اشکال و متن در سطح کلی ارائه شامل اسلایدهای معمولی، مستر و لایه است. بارگذاری‌های overload شده با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. وقتی ترتیب پیمایش، خروج زودهنگام، فیلتر قبل از فراخوانی callback یا کنترل دقیق والد‑فرزند مهم است، بهتر است از حلقه‌های مستقیم جمع‌آوری استفاده کنید.

## **جمع‌آوری اشکال**

زمانی که به یک مجموعه از تمام اشکال موجود در یک ارائه نیاز دارید (به جای یک callback برای هر شکل)، از [Collect::shapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/collect/#shapes) استفاده کنید. این کار زمانی مفید است که همان مجموعه چندین بار فیلتر، شمارش یا پردازش شود.

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

اگر هر شکل می‌تواند بلافاصله درون یک callback پردازش شود و نیازی به حفظ نتیجه جمع‌آوری‌شده ندارید، به جای آن از [ForEach_::shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#shape) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف و داده‌های قلم‌های توکار را کاهش دهد:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) لایه‌های اسلایدی را که هیچ اسلاید معمولی به آن‌ها ارجاع نمی‌دهد حذف می‌کند.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#removeUnusedMasterSlides) مسترهای استفاده‌نشده را حذف می‌کند.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#compressEmbeddedFonts) کاراکترهای استفاده‌نشده را از قلم‌های توکار حذف می‌کند.

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

ابتدا لایه‌های استفاده‌نشده را حذف کنید و سپس مسترهای استفاده‌نشده را، به‌طوری که مستری که پس از پاک‌سازی لایه‌ها دیگر ارجاع داده نمی‌شود نیز حذف شود. اگر ممکن است بعداً به مسترها، لایه‌ها یا داده‌های کامل قلم‌های توکار اصلی نیاز داشته باشید، ارائه بهینه‌شده را در فایلی جدید ذخیره کنید. برای جزئیات بیشتر به صفحات [Slide Master](/slides/fa/php-java/slide-master/) و [Embedded Font](/slides/fa/php-java/embedded-font/) مراجعه کنید.

## **سؤالات متداول**

**چه زمانی باید به‌جای مدل شیء کامل از API کم‑کد استفاده کنم؟**  
وقتی یک عملیات استاندارد بر کل فایل یا ارائه اعمال می‌شود و نیازی به کنترل دقیق عناصر منفرد ندارد، از کمکی‌های کم‑کد استفاده کنید. زمانی که نیاز به انتخاب اسلایدهای خاص، کنترل روابط مستر و لایه، بازرسی وضعیت میانی یا تنظیم رفتارهایی دارید که کمکی دربرگیرند، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در قالب‌های فایل متفاوت ترکیب کند؟**  
نه. متد [Merger::process](https://reference.aspose.com/slides/fa/php-java/aspose.slides/merger/#process) برای ترکیب فقط ارائه‌های با همان قالب فایل است. ابتدا فایل‌های ورودی را با استفاده از [Convert::autoByExtension](https://reference.aspose.com/slides/fa/php-java/aspose.slides/convert/#autoByExtension) به یک قالب مشترک تبدیل کنید و سپس فایل‌های تبدیل‑شده را ترکیب کنید.

**آیا ForEach_ می‌تواند اسلایدهای مستر، لایه و یادداشت‌ها را پردازش کند؟**  
متد [ForEach_::slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#slide) فقط اسلایدهای معمولی ارائه را پیمایش می‌کند. عملیات‌های سطح‑کل مانند [ForEach_::shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#shape)، [ForEach_::paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#paragraph) و [ForEach_::portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#portion) به‌طور پیش‌فرض اسلایدهای معمولی، مستر و لایه را شامل می‌شوند. برای شامل کردن اسلایدهای یادداشت‌ها، از بارگذاری‌های overload شده با مقدار `includeNotes` برابر `true` استفاده کنید.

**تفاوت بین ForEach_::shape و Collect::shapes چیست؟**  
از [ForEach_::shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/#shape) برای پردازش فوری هر شکل در یک callback استفاده کنید. وقتی به یک نتیجه قابل پیمایش نیاز دارید که بتوانید آن را حفظ، فیلتر یا چندین بار شمارش کنید، از [Collect::shapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/collect/#shapes) بهره ببرید.

**آیا Compress همیشه اندازه فایل ارائه را کوچک می‌کند؟**  
لزومی ندارد. نتیجه به این بستگی دارد که آیا ارائه شامل لایه‌های استفاده‌نشده، مسترهای استفاده‌نشده یا قلم‌های توکار با کاراکترهای استفاده‌نشده باشد. اگر هیچ‌یک از این موارد وجود نداشته باشد، عملیات‌های مربوط به [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) ممکن است اندازه فایل را کاهش ندهند.

**آیا تغییرات انجام شده توسط ForEach_ یا Compress به‌طور خودکار ذخیره می‌شوند؟**  
نه. این کمکی‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری شده در حافظه عمل می‌کنند. پس از تغییر عناصر در یک callback از [ForEach_](https://reference.aspose.com/slides/fa/php-java/aspose.slides/foreach_/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/)، برای نوشتن نتیجه باید متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) را فراخوانی کنید.

## **مقالات مرتبط**

- [Convert Presentation](/slides/fa/php-java/convert-presentation/)
- [Merge Presentations](/slides/fa/php-java/merge-presentation/)
- [Slide Master](/slides/fa/php-java/slide-master/)
- [Manage Text Box](/slides/fa/php-java/manage-textbox/)
- [Embedded Font](/slides/fa/php-java/embedded-font/)