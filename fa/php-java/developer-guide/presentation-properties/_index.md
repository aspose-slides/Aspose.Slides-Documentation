---
title: مدیریت خصوصیات ارائه در PHP
linktitle: خصوصیات ارائه
type: docs
weight: 70
url: /fa/php-java/presentation-properties/
keywords:
- خصوصیات PowerPoint
- خصوصیات ارائه
- خصوصیات سند
- خصوصیات درون‌ساز
- خصوصیات سفارشی
- خصوصیات پیشرفته
- مدیریت خصوصیات
- تغییر خصوصیات
- فراداده سند
- ویرایش فراداده
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "در Aspose.Slides برای PHP از طریق Java، خصوصیات ارائه را به‌صورت جامع مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه سازید."
---
## **مقدمه**

Aspose.Slides for PHP via Java از ویژگی‌های **درون‌ساز** و **سفارشی** برای خصوصیات سند پشتیبانی می‌کند. از این خصوصیات برای خواندن و به‌روزرسانی فراداده ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان کار با خصوصیات سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این خصوصیات را خوانده، تغییر داده و مدیریت کنید. این مثال‌ها فرض می‌کنند که PHP/Java Bridge و پوشش Aspose.Slides برای PHP مقداردهی اولیه شده‌اند.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیره ارائه‌ها، متادیتای برنامه و سازنده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را ایجاد کرده شناسایی می‌کند.
{{% /alert %}}

## **مدیریت خصوصیات ارائه**

خصوصیات سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آن‌ها به دو دسته تقسیم می‌شوند:

- **خصوصیات درون‌ساز** شامل فراداده‌های استاندارد مانند عنوان، نویسنده و آمارهای سند هستند.
- **خصوصیات سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for PHP via Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، برای بررسی متادیتای سند، **File → Info → Properties → Advanced Properties** را انتخاب کنید. دیالوگ اطلاعات را در زبانه‌هایی مانند **Summary**, **Statistics**, **Contents** و **Custom** گروه‌بندی می‌کند. از زبانه **Custom** برای مدیریت خصوصیات تعریف‌شده توسط کاربر استفاده کنید.

## **خواندن خصوصیات عمومی از یک ارائه رمزگذاری‌شده**

یک رمز عبور باز کردن معمولاً هم محتوای ارائه و هم خصوصیات سند را محافظت می‌کند. وقتی ارائه‌ای پس از فراخوانی [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) با مقدار `false` رمزگذاری شود، خصوصیات سند آن عمومی می‌مانند. سپس برنامه می‌تواند [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) را با مقدار `true` فراخوانی کند و متادیتای عمومی را بدون ارائه رمز عبور باز کردن بخواند.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مشخص می‌کند Aspose.Slides چه چیزی را بارگذاری می‌کند؛ این کار هیچ چیز را رمزگشایی نمی‌کند. اگر خصوصیات در فرآیند رمزگذاری گنجانده شوند، بارگذاری آن‌ها بدون رمز عبور موفق نمی‌شود. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

مثال نیاز به ارائه‌ای رمزگذاری‌شده دارد که خصوصیات سند آن عمومی باقی مانده باشد. حالت بارگذاری از طریق [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) بررسی می‌شود و سپس خصوصیات درون‌ساز با استفاده از [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) خوانده می‌شوند:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

در این حالت محتویات اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، طرح‌بندی‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که به مدل کامل شیء ارائه نیاز دارد، [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
متادیتای عمومی ممکن است نام نویسندگان، عنوان‌ها، موضوع‌ها، کلیدواژه‌ها، اطلاعات شرکت، توضیحات و مقادیر سفارشی را آشکار کند. خصوصیات حساس را همراه با ارائه رمزگذاری کنید. تنها زمانی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت اسناد نیاز خاصی به دسترسی بدون رمز عبور داشته باشند، آنها را عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی خصوصیات یک ارائه رمزگذاری‌شده**

برای فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) با مقدار `true` بارگذاری می‌شود، صرفاً برای خواندن متادیتای عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند خصوصیات تغییر یافته را از آن شیء فقط‑متادیتا ذخیره کند، زیرا خصوصیات عمومی باید با داده‌های مربوطه در داخل ارائه رمزگذاری‌شده هماهنگ بمانند. به‌روزرسانی آنها بنابراین نیاز به رمز عبور باز کردن صحیح و بارگذاری کامل دارد.

این مثال نیاز به ارائهٔ PPTX رمزگذاری‌شده‌ای دارد که خصوصیات سند عمومی دارد و رمز عبور باز کردن آن شناخته شده است. ابتدا ارائهٔ کامل را با استفاده از [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) باز می‌کند، خصوصیات درون‌ساز عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) صحت حفظ رمزگذاری را بررسی می‌کند و متادیتای عمومی را بدون رمز عبور دوباره باز می‌کند تا مقادیر جدید را تأیید نماید:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

اگر برنامه مجاز به رمزگشایی یا بارگذاری محتوای ارائه نباشد، باید خصوصیات عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی درنظر بگیرد.

## **دسترسی به خصوصیات درون‌ساز**

کلاس [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) متادیتای درون‌ساز را از طریق متدهای دریافت‌کننده (getter) در دسترس می‌گذارد، از جمله [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor)، [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) و [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime). این مثال یک ارائهٔ موجود را باز می‌کند و متادیتای ذخیره‌شده آن را در کنسول چاپ می‌کند. مقادیر بسته به ارائهٔ ورودی متفاوت هستند؛ برخی فیلدها ممکن است خالی باشند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

### **گزارش شماره بازبینی و زمان ویرایش**

برای گزارش شماره بازبینی و زمان کلی ویرایش هر فایل PPTX در پوشهٔ `presentations`، از [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) برای خواندن [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) بدون بارگذاری اسلایدها برای ویرایش استفاده کنید. API PHP via Java زمان ویرایش را بر حسب میلی‌ثانیه برمی‌گرداند. مثال آن را به ساعت، دقیقه و ثانیه تبدیل می‌کند و برای مدت‌های بیش از ۲۴ ساعت، تعداد روزها را نیز اضافه می‌نماید.

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

برای ارائه‌ای با شماره بازبینی ۱۷ و زمان ویرایش ثبت‌شدهٔ ۱ روز، ۲ ساعت و ۵ دقیقه، گزارش خروجی زیر را نشان می‌دهد.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) مقداری را می‌خواند که برنامه‌ها می‌توانند با [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber) تغییر دهند. فقط داشتن شماره بازبینی نمی‌تواند تعیین کند ارائه چند بار ذخیره شده یا تاریخچهٔ نسخهٔ آن را بازسازی کند.

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) زمان کلی ویرایش ثبت‌شده در فایل را می‌خواند. یک ارائه می‌تواند مدت زمان ذخیره‌شدهٔ صفر (`00:00:00`) داشته باشد حتی اگر کسی آن را ویرایش کرده باشد.

## **تغییر خصوصیات درون‌ساز**

برای به‌روزرسانی متادیتای درون‌ساز، از متدهای setter روی شیء بازگشتی از [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) استفاده کنید. این مثال یک ارائهٔ موجود را باز می‌کند، متدهای [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor)، [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle)، [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject)، [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) و [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager) را صدا می‌زند و سپس ارائهٔ به‌روزرسانی‌شده را با [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) ذخیره می‌کند. فایل PPTX ذخیره‌شده شامل متادیتای جدید خواهد بود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **مدیریت پایهٔ هایپرلینک**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) پایهٔ سطح سند برای هایپرلینک‌های نسبی را باز می‌گرداند. برای تغییر یا پاک کردن آن از [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) استفاده کنید. این ویژگی هنگام جابه‌جا کردن یک ارائه و فایل‌های پیوست آن به مکان دیگری مفید است. این پایه مستقل از [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) یک هایپرلینک منفرد است: تغییر پایه آدرس‌های ذخیره‌شدهٔ لینک را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

این مثال نیاز به ارائه‌ای دارد که شامل هر دو لینک نسبی (مانند `target.html`) و لینک مطلق (مانند `https://example.org/absolute.html`) باشد. ابتدا پایهٔ فعلی را می‌خواند، پایهٔ جدیدی اختصاص می‌دهد و پس از ذخیره و بازکردن دوبارهٔ ارائه مقدار جدید را بررسی می‌کند. سپس پایه را با رشتهٔ خالی پاک می‌کند و مقدار خالی را در فایلی جداگانه تأیید می‌نماید. آدرس پایهٔ مثال را با مکان فایل‌های پیوست خود جایگزین کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

دو پیام تأیید باید مقدار `true` را چاپ کنند. پاک کردن پایه آدرس‌های هایپرلینک‌های منفرد را دست نخورده می‌گذارد.

یک لینک نسبی به `target.pptx` هنگامیکه پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازکردن مجدد ارائه، همان لینک `new/target.pptx` را باز می‌کند. یک لینک مطلق همان فایل را باز نگه می‌دارد. قبل و بعد از جابه‌جایی ارائه یا تغییر پایه، لینک‌های نسبی خود را در PowerPoint تست کنید.

## **افزودن خصوصیات سفارشی به ارائه**

خصوصیات سفارشی متادیتایی را ذخیره می‌کنند که فیلد درون‌ساز متناظری ندارند. متد [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) به شما امکان می‌دهد مقدار را بر اساس نام خصوصیت اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و ارائه را با [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) ذخیره می‌نماید. اختصاص مقدار به نام موجود، مقدار همان خصوصیت را بازنویسی می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دسترسی و تغییر خصوصیات سفارشی**

این مثال یک ارائه حاوی خصوصیات سفارشی را باز می‌کند و از [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) برای پیمایش آنها استفاده می‌کند. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) با دریافت یک اندیس صفر‑پایه، نامی را که توسط [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) استفاده شده است، برمی‌گرداند. مثال نام و مقدار اصلی هر خصوصیت را چاپ می‌کند، هر مقدار را با یک رشته عددی جایگزین می‌کند صرف‌نظر از نوع اصلی آن و تغییرات را ذخیره می‌کند. اگر هیچ خصوصیت سفارشی وجود نداشته باشد، حلقه هیچ تغییری ایجاد نمی‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **مثال زنده**

اپلیکیشن آنلاین [**مشاهده و ویرایش متادیتای PowerPoint**](https://products.aspose.app/slides/metadata) را امتحان کنید تا ببینید چگونه می‌توان با استفاده از API Aspose.Slides با خصوصیات سند کار کرد:

[![مشاهده و ویرایش متادیتای PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توان یک خصوصیت درون‌ساز را از یک ارائه حذف کرد؟**

خصوصیات درون‌ساز بخش جدایی‑نایابی از ارائه هستند و به‌طور کامل نمی‌توانند حذف شوند. با این حال می‌توانید مقادیر آنها را تغییر دهید یا در صورت امکان، به مقدار خالی تنظیم کنید.

**اگر یک خصوصیت سفارشی که قبلاً وجود دارد را اضافه کنم، چه می‌شود؟**

اگر یک خصوصیت سفارشی که پیش از این وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی خصوصیت ندارید، زیرا Aspose.Slides به‌طوری خودکار مقدار خصوصیت را به‌روز می‌کند.

**آیا می‌توان به خصوصیات ارائه بدون بارگذاری کامل ارائه دسترسی داشت؟**

بله. می‌توانید از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) و سپس [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) برای خواندن متادیتای ذخیره‌شدهٔ سند بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) استفاده کنید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به بخش [ساخت موجودی ارائهٔ سبک‑وزن](/slides/fa/php-java/examine-presentation/) مراجعه کنید.

**آیا می‌توان خصوصیات عمومی یک ارائهٔ رمزگذاری‌شده را بدون رمز عبور باز کردن آن خواند؟**

بله. ارائه باید پس از فراخوانی [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) با مقدار `false` رمزگذاری شده باشد و سپس با فراخوانی [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) با مقدار `true` بارگذاری شود.

**آیا می‌توان یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑خصوصیات‑سند به‌روزرسانی کرد؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید هماهنگ بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیازمند بارگذاری کامل ارائه با رمز عبور باز کردن صحیح است.