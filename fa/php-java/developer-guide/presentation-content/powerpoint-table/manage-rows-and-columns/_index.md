---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint با استفاده از PHP
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/php-java/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- اولین ردیف
- سرصفحه جدول
- کلون ردیف
- کلون ستون
- کپی ردیف
- کپی ستون
- حذف ردیف
- حذف ستون
- قالب‌بندی متن ردیف
- قالب‌بندی متن ستون
- سبک جدول
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با Aspose.Slides برای PHP از طریق Java و سرعت بخشیدن به ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **مقدمه**

Aspose.Slides for PHP via Java به شما امکان مدیریت ساختار جدول و قالب‌بندی در ارائه‌های PowerPoint از طریق کلاس [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) را می‌دهد. می‌توانید یک ردیف سرصفحه تعیین کنید، ردیف‌ها و ستون‌ها را کلون یا حذف کنید، و قالب‌بندی متن را بر روی یک ردیف یا ستون کامل اعمال کنید.

این مقاله این عملیات را همراه با مثال‌های PHP توضیح می‌دهد. همچنین نشان می‌دهد چگونه پیش‌تنظیم سبک جدول را بازیابی کنید تا بتوانید دوباره از آن استفاده کنید. ایندکس‌های ردیف و ستون جدول صفر‑مبنایی هستند.

## **کنترل ارتفاع ردیف**

از [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) برای تنظیم حداقل ارتفاع یک ردیف بر حسب پوینت استفاده کنید. این یک حد پایین است، نه ارتفاع ثابت. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) ارتفاع واقعی را برمی‌گرداند. با استفاده از [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/) به ردیف دسترسی پیدا کنید.

مثال [row‑height‑input.pptx](row-height-input.pptx) را بارگذاری می‌کند که دارای یک جدول به عنوان اولین شکل در اولین اسلاید است. اولین ردیف آن از ۷۰ پوینت شروع می‌شود. سلول‌ها از متن Arial با اندازه ۱۸ پوینت، بسته شدن متن و حاشیه‌های بالا و پایین ۶ پوینت استفاده می‌کنند؛ متن طولانی‌تر در ستون دوم به چند خط بسته می‌شود. مثال حداقل را به ۱۰۰ پوینت افزایش می‌دهد، سپس به ۲۰ پوینت کاهش می‌دهد، ارتفاع واقعی را پس از هر تغییر چاپ می‌کند و هر دو نتیجه را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

با ارائهٔ فراهم‌شده، افزایش حداقل فضایی به ردیف اضافه می‌کند. کاهش آن آن فضای اضافه را حذف می‌کند، اما ارتفاع واقعی بیش از ۲۰ پوینت باقی می‌ماند زیرا متن و حاشیه‌های سلول به فضای بیشتری نیاز دارند. فقط کاهش حداقل نمی‌تواند ردیف را زیر فضای مورد نیاز محتوای آن فشار دهد.

چند عامل بر ارتفاع واقعی تأثیر می‌گذارند:

- **متن و اندازهٔ قلم:** متن طولانی‌تر، شکست خط صریح، یا قلم بزرگ‌تر می‌تواند فضای عمودی بیشتری نیاز داشته باشد.
- **بسته شدن متن و عرض ستون:** با فعال بودن بسته شدن، کاهش عرض ستون با [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) می‌تواند خطوط بیشتری تولید کند. ستون وسیع‌تر می‌تواند فضای عمودی مورد نیاز را کاهش دهد.
- **حاشیه‌های سلول:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) و [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) فضای عمودی اضافه می‌کنند. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) و [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) عرض موجود برای متن را کاهش می‌دهند و می‌توانند بسته شدن اضافی ایجاد کنند.

برای این جدول بدون سلول‌های ادغام‌شده، سلولی که بیشترین فضای عمودی را نیاز دارد، حد پایین مبتنی بر محتوا برای کل ردیف را تعیین می‌کند. برای کوتاه کردن ردیف، ممکن است نیاز باشد متن را کوتاه کنید، اندازهٔ قلم یا حاشیه‌ها را کاهش دهید، یا ستون را عریض‌تر کنید.

تصاویر زیر همان جدول را با همان مقیاس نشان می‌دهند. در نتایج نشان‑داده‌شده، ارتفاع‌های واقعی ۷۰، ۱۰۰ و ۵۵٫۲ پوینت بودند: ردیف نهایی بلندتر از حداقل ۲۰ پوینت باقی ماند. اندازه‌گیری‌های دقیق متن می‌توانند با فونت‌های موجود در محیط شما متفاوت باشند. نتایج ذخیره‌شده را بارگیری کنید: [increased minimum](row-height-increased.pptx) و [decreased minimum](row-height-decreased.pptx).

| اصل: حداقل ۷۰ پوینت، واقعی ۷۰ پوینت | افزایش یافته: حداقل ۱۰۰ پوینت، واقعی ۱۰۰ پوینت | کاهش یافته: حداقل ۲۰ پوینت، واقعی ۵۵٫۲ پوینت |
| --- | --- | --- |
| ![جدول اصلی با اولین ردیف ۷۰ پوینتی.](row-height-before.png) | ![جدول پس از افزایش حداقل اولین ردیف به ۱۰۰ پوینت.](row-height-increased.png) | ![جدول پس از کاهش حداقل اولین ردیف به ۲۰ پوینت؛ متن بسته شده باعث بلندتر ماندن ردیف نسبت به حداقل می‌شود.](row-height-decreased.png) |

## **تعیین ردیف اول به عنوان سرصفحه**

از متد [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) برای علامت‌گذاری اولین ردیف برای قالب‌بندی سرصفحه استفاده کنید. ظاهر آن به سبک جدول اعمال‌شده به جدول بستگی دارد.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. جدول را که به عنوان اولین شکل در اسلاید ذخیره شده است، دسترسی پیدا کنید.
4. قالب‌بندی سرصفحه را برای اولین ردیف آن فعال کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به `table.pptx` نیاز دارد که جدول را به عنوان اولین شکل در اولین اسلاید دارد. قالب‌بندی سرصفحه را برای اولین ردیف فعال می‌کند و `First_row_header.pptx` را ذخیره می‌نماید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **کلون کردن ردیف یا ستون جدول**

ردیف‌ها یا ستون‌ها را کلون کنید تا محتوای آن‌ها و قالب‌بندی را مجدداً استفاده کنید. می‌توانید یک نسخه را به انتهای جدول اضافه کنید یا در موقعیت خاصی وارد کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. یک جدول را با متد [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) اضافه کنید.
5. ردیف‌های مورد نیاز را کلون کنید.
6. ستون‌های مورد نیاز را کلون کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به `Test.pptx` نیاز دارد که حداقل یک اسلاید داشته باشد. یک جدول با سه ستون و پنج ردیف ایجاد می‌کند که ابعاد آن‌ها بر حسب پوینت مشخص شده‌اند. نسخه‌های اولین ردیف و ستون را اضافه می‌کند، سپس نسخه‌های ردیف و ستون دوم را در ایندکس ۳ (موقعیت چهارم) وارد می‌کند. جدول حاصل هفت ردیف و پنج ستون دارد. آرگومان `false` از کلون کردن به ردیف‌ها یا ستون‌های ادغام‌شدهٔ مجاور جلوگیری می‌کند؛ این جدول سلول‌های ادغام‌شده‌ای ندارد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **حذف ردیف یا ستون از جدول**

ردیف‌ها یا ستون‌هایی که دیگر نیازی به آن‌ها در جدول نیست حذف کنید. حذف یک مورد ایندکس‌های ردیف‌ها یا ستون‌های بعدی را جابجا می‌کند.

1. یک ارائه با کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. یک جدول را با متد [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) اضافه کنید.
5. ردیف دوم و ستون دوم را حذف کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال یک جدول سه‑در‑سه ایجاد می‌کند و ردیف و ستون در ایندکس ۱ را حذف می‌کند و یک جدول دو‑در‑دو در `TestTable_out.pptx` می‌گذارد. ابعاد بر حسب پوینت است. آرگومان `false` حذف ردیف‌ها یا ستون‌های ادغام‌شدهٔ مجاور را غیرفعال می‌کند؛ این جدول سلول‌های ادغام‌شده‌ای ندارد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح ردیف جدول**

قالب‌بندی متن را بر روی یک ردیف کامل اعمال کنید تا سلول‌های آن سازگار باشند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی جداگانه هر سلول تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. جدول را در اولین اسلاید دسترسی پیدا کنید.
3. از [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) برای اولین ردیف استفاده کنید.
4. از [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) برای اولین ردیف استفاده کنید.
5. از [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) برای ردیف دوم استفاده کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به `table.pptx` نیاز دارد که جدول را به عنوان اولین شکل در اولین اسلاید داشته باشد و حداقل دو ردیف داشته باشد. متن ۲۵ پوینتی، تراز راست و حاشیهٔ پاراگراف راست ۲۰ پوینتی را به اولین ردیف اعمال می‌کند، سپس متن عمودی را در ردیف دوم تنظیم می‌نماید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

قالب‌بندی متن را بر روی یک ستون کامل اعمال کنید تا سلول‌های آن سازگار باشند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی جداگانه هر سلول تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. جدول را در اولین اسلاید دسترسی پیدا کنید.
3. از [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) برای اولین ستون استفاده کنید.
4. از [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) برای اولین ستون استفاده کنید.
5. از [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) برای ستون دوم استفاده کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

مثال به `table.pptx` نیاز دارد که جدول را به عنوان اولین شکل در اولین اسلاید داشته باشد و حداقل دو ستون داشته باشد. متن ۲۵ پوینتی، تراز راست و حاشیهٔ پاراگراف راست ۲۰ پوینتی را به اولین ستون اعمال می‌کند، سپس متن عمودی را در ستون دوم تنظیم می‌نماید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دریافت ویژگی‌های سبک جدول**

از متد [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) برای بازیابی پیش‌تنظیم اعمال‌شده به یک جدول و استفاده مجدد از آن در جدول دیگر استفاده کنید. این پیش‌تنظیم را شناسایی می‌کند نه بازنویسی‌های قالب‌بندی سلول‌های جداگانه.

مثال یک جدول ایجاد می‌کند، [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) را اعمال می‌نماید و پیش‌تنظیم را باز می‌خواند. مقدار صحیح مربوط به `DarkStyle1` را چاپ می‌کند و جدول را در `table.pptx` ذخیره می‌نماید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**آیا می‌توانم تم‌ها/سبک‌های PowerPoint را به جدول ایجاد‌شده اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/استاد را به ارث می‌برد و همچنان می‌توانید پرکننده‌ها، حاشیه‌ها و رنگ‌های متن را بر روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**

خیر، جداول Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را به ترتیب جدید پر کنید.

**آیا می‌توانم ستون‌های نواردار (خط‌دار) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص نگه دارم؟**

بله. ستون‌های نواردار را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول نسبت به سبک جدول اولویت دارد.