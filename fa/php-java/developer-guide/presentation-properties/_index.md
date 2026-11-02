---
title: مدیریت خصوصیات ارائه در PHP
linktitle: خصوصیات ارائه
type: docs
weight: 70
url: /fa/php-java/presentation-properties/
keywords:
- خصوصیات پاورپوینت
- خصوصیات ارائه
- خصوصیات سند
- خصوصیات درون‌ساختی
- خصوصیات سفارشی
- خصوصیات پیشرفته
- مدیریت خصوصیات
- اصلاح خصوصیات
- فرادادهٔ سند
- ویرایش فراداده
- زبان اصلاحیه
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت کامل خصوصیات ارائه در Aspose.Slides برای PHP از طریق Java و بهینه‌سازی جستجو، برندسازی و گردش کار در فایل‌های PowerPoint و OpenDocument شما."
---
## **مقدمه**

Aspose.Slides for PHP via Java از ویژگی‌های **درون‌ساختی** و **سفارشی** برای خصوصیات سند پشتیبانی می‌کند. از این خصوصیات برای خواندن و به‌روزرسانی فرادادهٔ ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان کار با خصوصیات سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این خصوصیات را بخوانید، اصلاح کنید و مدیریت نمایید. این مثال‌ها فرض می‌شوند که PHP/Java Bridge و wrapper PHP Aspose.Slides مقداردهی اولیه شده‌اند.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیره‌سازی ارائه‌ها، فرادادهٔ برنامه و تولید‌کننده را مدیریت می‌کند؛ این فیلدها نرم‌افزار ایجادکنندهٔ خروجی را شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت خصوصیات ارائه**

خصوصیات سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آن‌ها به دو دسته تقسیم می‌شوند:

- **خصوصیات درون‌ساختی** شامل فرادادهٔ استانداردی مانند عنوان، نویسنده و آمار سند هستند.
- **خصوصیات سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for PHP via Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، برای بررسی فرادادهٔ سند، **File → Info → Properties → Advanced Properties** را انتخاب کنید. این گفت‌وگو اطلاعات را در برگه‌هایی مانند **Summary**، **Statistics**، **Contents** و **Custom** گروه‌بندی می‌کند. برای مدیریت خصوصیات تعریف‌شده توسط کاربر، از برگهٔ **Custom** استفاده کنید.

## **خواندن خصوصیات عمومی از یک ارائهٔ رمزگذاری‌شده**

معمولاً یک رمز عبور بازکردن هم محتوا و هم خصوصیات سند ارائه را محافظت می‌کند. وقتی یک ارائه پس از فراخوانی [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) با مقدار `false` رمزگذاری می‌شود، خصوصیات سند آن به‌صورت عمومی باقی می‌مانند. سپس یک برنامه می‌تواند با فراخوانی [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) با مقدار `true`، فرادادهٔ عمومی را بدون ارائهٔ رمز عبور بازکردن بخواند.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) تعیین می‌کند Aspose.Slides چه چیزی را بارگذاری کند؛ این متد هیچ چیزی را رمزگشایی نمی‌کند. اگر خصوصیات در رمزگذاری گنجانده شده باشند، بارگذاری آن‌ها بدون رمز عبور ناموفق است. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و ارائهٔ کامل بارگذاری می‌شود.

این مثال به یک ارائهٔ رمزگذاری‌شده نیاز دارد که خصوصیات سند آن به‌صورت عمومی باقی مانده باشد. حالت بارگذاری را از طریق [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) تأیید می‌کند و سپس خصوصیات درون‌ساختی را با استفاده از [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) می‌خواند:

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

در این حالت، محتوای اسلایدها بارگذاری نمی‌شود. اسلایدها، مسترها، طرح‌بندی‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که به مدل کامل شیء ارائه نیاز دارد، [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
Metadata عمومی ممکن است نام‌های نویسنده، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. خصوصیات حساس را همراه با ارائه رمزگذاری کنید. تنها در صورتی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت اسناد نیاز خاصی به دسترسی بدون رمز عبور داشته باشند، آن‌ها را به‌صورت عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی خصوصیات یک ارائهٔ رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) با مقدار `true` بارگذاری می‌شود، برای خواندن فرادادهٔ عمومی منظور دارد. Aspose.Slides نمی‌تواند خصوصیات تغییر یافته را از این شیء صرفاً شامل فراداده ذخیره کند زیرا خصوصیات عمومی باید با داده‌های مربوطه در داخل ارائهٔ رمزگذاری‌شده هم‌خوانی داشته باشند. بنابراین به‌روزرسانی آن‌ها نیاز به رمز عبور صحیح بازکردن و بارگذاری کامل دارد.

این مثال به یک ارائهٔ PPTX رمزگذاری‌شده با خصوصیات سند عمومی و رمز عبور بازکردن شناخته‌شده نیاز دارد. ابتدا ارائهٔ کامل را با استفاده از [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/) باز می‌کند، خصوصیات درون‌ساختی عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) تأیید می‌کند که رمزگذاری حفظ شده و متادادهٔ عمومی را بدون رمز عبور مجدداً باز می‌کند تا مقادیر جدید را بررسی کند:

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

اگر یک برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید خصوصیات عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی درنظر بگیرد.

## **دسترسی به خصوصیات درون‌ساختی**

کلاس [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) متاداده‌های درون‌ساختی را از طریق متدهای getter مانند [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/)، [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/)، و [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/) در دسترس قرار می‌دهد. این مثال یک ارائهٔ موجود را باز کرده و متاداده‌های ذخیره‌شده آن را به کنسول چاپ می‌کند. مقادیر به ارائهٔ ورودی بستگی دارد؛ برخی فیلدها ممکن است خالی باشند.

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

## **تغییر خصوصیات درون‌ساختی**

برای به‌روزرسانی متاداده‌های درون‌ساختی، از متدهای setter روی شیء برگردانده‌شده توسط [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) استفاده کنید. این مثال یک ارائهٔ موجود را باز می‌کند، [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/)، [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/)، [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/)، [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/)، و [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/) را فراخوانی می‌کند، سپس ارائهٔ به‌روزرسانی‌شده را با [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ذخیره می‌نماید. فایل PPTX ذخیره‌شده حاوی متاداده‌های جدید است.

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

## **مدیریت پایهٔ پیوندهای ابرمتنی**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) پایهٔ سطح سند را برای پیوندهای نسبی بازمی‌گرداند. برای تغییر یا پاک کردن آن از [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) استفاده کنید. این کار هنگام جابجایی یک ارائه و فایل‌های پیوندی آن به مکان دیگری مفید است. این مورد جدا از [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) یک پیوند ابرمتنی فردی است: تغییر پایه آدرس‌های ذخیره‌شده را بازنویسی نمی‌کند و مقاصد مطلق را تغییر نمی‌دهد.

این مثال به یک ارائه نیاز دارد که هم یک پیوند نسبی مثل `target.html` و هم یک پیوند مطلق مثل `https://example.org/absolute.html` داشته باشد. ابتدا پایهٔ موجود را می‌خواند، یک آدرس پایهٔ جدید اختصاص می‌دهد و سپس ارائه را ذخیره و باز می‌کند تا مقدار را بررسی کند. سپس پایه را با یک رشتهٔ خالی پاک می‌کند و مقدار خالی را در یک فایل ذخیره‌شدهٔ جداگانه تأیید می‌کند. آدرس پایهٔ مثال را با مکان فایل‌های پیوندی خود جایگزین کنید.

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

دو پیام تأیید باید مقدار `true` را چاپ کنند. پاک کردن پایه، آدرس‌های پیوندهای ابرمتنی فردی را دست‌نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` وقتی پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازگشایی ارائه، همان پیوند `new/target.pptx` را باز کرد. یک پیوند مطلق همچنان همان فایل را باز می‌کرد. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابجایی ارائه یا تغییر پایه آن آزمایش کنید.

## **افزودن خصوصیات سفارشی به ارائه**

خصوصیات سفارشی متاداده‌ای را ذخیره می‌کنند که فیلد درون‌ساختی متناظری ندارند. متد [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) به شما امکان می‌دهد مقدار را براساس نام خصوصیت اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و ارائه را با [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ذخیره می‌کند. اختصاص مقدار به نامی موجود، مقدار آن خصوصیت را جایگزین می‌کند.

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

این مثال یک ارائه حاوی خصوصیات سفارشی را باز می‌کند و از [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) برای تکرار روی آن‌ها استفاده می‌کند. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) یک اندیس صفر‑محور می‌پذیرد و نامی که توسط [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) استفاده شده است، برمی‌گرداند. مثال نام و مقدار اصلی هر خصوصیت را چاپ می‌کند، هر مقدار را با یک رشتهٔ عددی جایگزین می‌کند بدون در نظر گرفتن نوع اصلی آن، و تغییرات را ذخیره می‌نماید. اگر خصوصیات سفارشی وجود نداشته باشند، حلقه هیچ تغییری اعمال نمی‌کند.

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

اپلیکیشن آنلاین [**مشاهده و ویرایش فرادادهٔ پاورپوینت**](https://products.aspose.app/slides/metadata) را امتحان کنید تا ببینید چگونه می‌توانید با استفاده از API Aspose.Slides با خصوصیات سند کار کنید:

[![مشاهده و ویرایش فرادادهٔ پاورپوینت](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک خصوصیت درون‌ساختی را از یک ارائه حذف کنم؟**

خصوصیات درون‌ساختی بخش جدایی‌ناپذیر ارائه هستند و نمی‌توان آنها را به‌طور کامل حذف کرد. با این حال، می‌توانید مقدار آنها را تغییر دهید یا در صورت اجازهٔ خصوصیت خاص، خالی تنظیم کنید.

**چه می‌شود اگر یک خصوصیت سفارشی که قبلاً وجود دارد را اضافه کنم؟**

اگر یک خصوصیت سفارشی که از پیش وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی خصوصیت ندارید؛ Aspose.Slides به‌طور خودکار مقدار خصوصیت را به‌روز می‌کند.

**آیا می‌توانم خصوصیات ارائه را بدون بارگذاری کامل آن دسترسی داشته باشم؟**

بله. از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) و سپس [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) استفاده کنید تا متادادهٔ ذخیره‌شدهٔ سند را بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های فرمتی، به [ساخت فهرست سبک ارائه](/slides/fa/php-java/examine-presentation/) مراجعه کنید.

**آیا می‌توانم خصوصیات عمومی یک ارائهٔ رمزگذاری‌شده را بدون رمز عبور بازکردن آن بخوانم؟**

بله. ارائه باید پس از فراخوانی [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) با مقدار `false` رمزگذاری شده باشد و پس از فراخوانی [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) با مقدار `true` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑خصوصیات‑سند به‌روز کنم؟**

خیر. داده‌های عمومی و رمزگذاری‌شدهٔ خصوصیات باید سازگار بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیاز به بارگذاری کامل ارائه با رمز عبور صحیح بازکردن دارد.