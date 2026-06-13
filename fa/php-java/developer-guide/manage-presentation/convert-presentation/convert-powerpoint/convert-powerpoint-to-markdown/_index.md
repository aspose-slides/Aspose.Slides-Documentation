---
title: "تبدیل ارائه‌های PowerPoint به Markdown در PHP"
linktitle: "PowerPoint به Markdown"
type: docs
weight: 140
url: /fa/php-java/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره PowerPoint به عنوان Markdown
- ذخیره ارائه به عنوان Markdown
- ذخیره اسلاید به عنوان Markdown
- ذخیره PPT به عنوان MD
- ذخیره PPTX به عنوان MD
- صادرات PPT به MD
- exportPPTX به MD
- PowerPoint
- ارائه
- Markdown
- PHP
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint — PPT، PPTX — به Markdown تمیز با Aspose.Slides برای PHP از طریق Java، خودکاری مستندات و حفظ قالب‌بندی."
---
## **معرفی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به Markdown تبدیل کنید؛ امری که می‌تواند برای جریان‌های کاری مستندات، تولید سایت‌های ایستا، مهاجرت محتوا و انتشار متنی تحت کنترل نسخه مفید باشد. این API از خروجی مستقیم ارائه‌های PPT و PPTX به فایل‌های MD پشتیبانی می‌کند و گزینه‌های اضافی برای کنترل نحوه نمایش محتوای اسلایدها در سند Markdown تولید شده فراهم می‌سازد.

شما می‌توانید ارائه‌ها را به صورت Markdown ساده استخراج کنید، از بین چندین نوع Markdown مانند CommonMark و GitHub Flavored Markdown انتخاب کنید و نحوه مدیریت تصاویر را در هنگام خروجی تنظیم کنید. برای ارائه‌هایی که دارای محتوای بصری هستند، Aspose.Slides همچنین به شما اجازه می‌دهد تصاویر را در پوشه‌ای جداگانه ذخیره کنید و از فایل Markdown تولید شده به آن‌ها ارجاع دهید.

{{% alert color="warning" %}}

خروجی PowerPoint‑to‑Markdown به‌طور پیش‌فرض **بدون تصویر** است. اگر می‌خواهید سند PowerPoint حاوی تصویر را صادر کنید، باید `ExportType = MarkdownExportType::Visual` تنظیم کنید و `BasePath` را مشخص نمایید؛ مسیر ذخیره‌سازی تصاویر ارجاع‌شده در سند Markdown در این مسیر ذخیره می‌شود.

{{% /alert %}}

## **تبدیل یک ارائه به Markdown**

این بخش توضیح می‌دهد که Aspose.Slides چگونه ارائه‌های PowerPoint و OpenDocument (PPT، PPTX، ODP) را به Markdown تمیز تبدیل می‌کند، در حالی که ساختار سلسله‌مراتبی اسلایدها، متن و قالب‌بندی اصلی را حفظ می‌کند تا بتوانید محتوا را در مستندات یا جریان‌های کاری تحت کنترل نسخه بدون تلاش دستی اضافی باز استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید تا نمایانگر ارائه باشد.  
1. از متد [save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) برای خروجی به‌صورت فایل Markdown استفاده کنید.

این کد PHP نشان می‌دهد چگونه یک ارائه PowerPoint را به Markdown تبدیل کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **تبدیل یک ارائه به نوع خاصی از Markdown**

Aspose.Slides به شما اجازه می‌دهد ارائه‌های PowerPoint را به Markdown با سینتکس پایه، و همچنین به CommonMark، GitHub‑flavored Markdown، Trello، XWiki، GitLab و هفده نوع دیگر Markdown تبدیل کنید.

کد PHP زیر نحوه تبدیل یک ارائه PowerPoint به CommonMark را نشان می‌دهد:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

۲۳ نوع Markdown پشتیبانی‌شده در [Enumeration Flavor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/flavor/) فهرست شده‌اند.

## **تبدیل یک ارائه حاوی تصاویر به Markdown**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) ویژگی‌ها و enumerationهایی را در اختیار می‌گذارد که به شما امکان پیکربندی فایل Markdown نهایی را می‌دهد. به‌عنوان مثال، enumeration [MarkdownExportType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownexporttype/) تعیین می‌کند تصاویر چگونه مدیریت شوند: `Sequential`، `TextOnly` یا `Visual`.

{{% alert color="warning" %}}

به‌طور پیش‌فرض، خروجی PowerPoint‑to‑Markdown **تصاویر را شامل نمی‌شود**. برای تعبیه تصاویر، فراخوانی کنید `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` و `BasePath` را تنظیم کنید تا مسیر ذخیره‌سازی تصاویر در فایل Markdown مشخص شود.

{{% /alert %}}

### **تبدیل تصاویر به‌صورت ترتیبی**

اگر می‌خواهید تصاویر به‌صورت جداگانه، یکی‌ پس از دیگری، در Markdown نهایی ظاهر شوند، باید گزینه `Sequential` را انتخاب کنید. کد PHP زیر نحوه تبدیل یک ارائه حاوی تصاویر به Markdown را نشان می‌دهد:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **تبدیل تصاویر به‌صورت بصری**

اگر می‌خواهید تصاویر به‌صورت گروهی در Markdown نهایی ظاهر شوند، باید گزینه `Visual` را انتخاب کنید. در این حالت، تصاویر در پوشه فعلی برنامه ذخیره می‌شوند (و مسیر نسبی برای آن‌ها در سند Markdown تولید می‌شود) یا می‌توانید پوشه و مسیر دلخواه خود را تعیین کنید.

کد PHP زیر این عملیات را نمایش می‌دهد:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا پیوندهای‌های متنی در خروجی به Markdown حفظ می‌شوند؟**

بله. متن‌های [hyperlinks](/slides/fa/php-java/manage-hyperlinks/) به‌صورت لینک‌های استاندارد Markdown حفظ می‌شوند. انتقال‌های اسلاید [transitions](/slides/fa/php-java/slide-transition/) و [animations](/slides/fa/php-java/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توانم با اجرای همزمان در چندین رشته سرعت تبدیل را افزایش دهم؟**

می‌توانید پردازش را بین فایل‌ها موازی کنید، اما [Presentation]‌(https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) یکسان را در رشته‌های مختلف به اشتراک نگذارید. برای جلوگیری از تداخل، برای هر فایل یک نمونه/فرآیند جداگانه استفاده کنید.

**تصاویر به کجا ذخیره می‌شوند و آیا مسیرها نسبی هستند؟**

[Images](/slides/fa/php-java/image/) به پوشه‌ای اختصاصی صادر می‌شوند و فایل Markdown به‌طور پیش‌فرض با مسیرهای نسبی به آن‌ها ارجاع می‌دهد. می‌توانید مسیر خروجی پایه و نام پوشه دارایی‌ها را تنظیم کنید تا ساختار مخزن پیش‌بینی‌پذیر بماند.