---
title: مدیریت ویژگی‌های ارائه در PHP
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/php-java/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- اصلاح ویژگی‌ها
- ابرداده سند
- ویرایش ابرداده
- زبان تصحیح
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides for PHP via Java به‌صورت کامل مدیریت کنید و جستجو، برندسازی و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides از دو نوع ویژگی سند پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها می‌توانند به‌راحتی با استفاده از API Aspose.Slides دسترسی یافته و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد با ویژگی‌های سند ارائه از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/) کار کنید. یک نمونه از این کلاس توسط متد [Presentation::getDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDocumentProperties) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، اصلاح کنید و مدیریت نمایید.

{{% alert color="info" title="نکته" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل تغییر نیستند. Aspose.Slides در هر ذخیره‌سازی آن‌ها را بازنویسی می‌کند، بنابراین یک ارائه ذخیره‌شده همیشه گزارش می‌دهد «Aspose.Slides for PHP via Java» و نسخه کتابخانه‌ای که آن را تولید کرده است. هر مقدار پاس‌داده‌شده به `setNameOfApplication` هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint قابلیت افزودن برخی ویژگی‌ها به فایل‌های ارائه را فراهم می‌کند. این ویژگی‌های سند امکان ذخیره‌سازی اطلاعات مفید همراه با اسناد (فایل‌های ارائه) را می‌دهد. دو نوع ویژگی سند به شرح زیر وجود دارد

- ویژگی‌های تعریف‌شده توسط سیستم (Built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (Custom)

ویژگی‌های **Built-in** حاوی اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره هستند. ویژگی‌های **Custom** آن‌هایی هستند که توسط کاربران به صورت جفت‌های **Name/Value** تعریف می‌شوند، که هم نام و هم مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for PHP via Java، توسعه‌دهندگان می‌توانند به مقادیر ویژگی‌های Built-in و همچنین ویژگی‌های Custom دسترسی داشته و آن‌ها را اصلاح کنند.

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. تنها کاری که باید انجام دهید کلیک روی نماد Office و سپس گزینه منوی **Prepare | Properties | Advanced Properties** در Microsoft PowerPoint 2007 همان‌طور که در زیر نشان داده شده است:

|**انتخاب گزینه Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

پس از انتخاب گزینه **Advanced Properties**، دیالوگی ظاهر می‌شود که به شما امکان مدیریت ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر نشان داده شده است، می‌دهد:

|**دیالوگ ویژگی‌ها**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

در **دیالوگ ویژگی‌ها** بالا می‌توانید ببینید که صفحه‌های تب متعددی مانند **General**, **Summary**, **Statistics**, **Contents** و **Custom** وجود دارد. همه این تب‌ها امکان پیکربندی انواع مختلف اطلاعات مربوط به فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **کار با ویژگی‌های سند با استفاده از Aspose.Slides for PHP via Java**

همان‌طور که قبلاً توضیح دادیم Aspose.Slides for PHP via Java از دو نوع ویژگی سند پشتیبانی می‌کند که **Built-in** و **Custom** هستند. بنابراین، توسعه‌دهندگان می‌توانند به هر دو نوع ویژگی با استفاده از API Aspose.Slides for PHP via Java دسترسی داشته باشند. Aspose.Slides for PHP via Java کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties) را ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نشان می‌دهد.

توسعه‌دهندگان می‌توانند از ویژگی **DocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) افشا شده است، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در ادامه توضیح داده شده استفاده کنند:

## **خواندن ویژگی‌های عمومی از یک ارائه رمزگذاری‌شده**

یک رمز عبور باز شدن معمولاً محتوای ارائه و ویژگی‌های سند را محافظت می‌کند. هنگامی که ارائه با عبور `false` به متد [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) رمزگذاری می‌شود، ویژگی‌های سند آن عمومی می‌مانند. سپس یک برنامه می‌تواند `true` را به متد [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) پاس بدهد و متادیتای عمومی را بدون ارائه رمز عبور باز کردن بخواند.

گزینه‌ی فقط‑بارگذاری‑ویژگی‌های‑سند تعیین می‌کند که Aspose.Slides چه چیزی را بارگذاری می‌کند؛ این گزینه هیچ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزنگاری گنجانده شده باشند، بارگذاری آن‌ها بدون رمز عبور ناموفق خواهد بود. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

مثال زیر حالت بارگذاری را از طریق [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) بررسی می‌کند و سپس ویژگی‌های Built‑in را از طریق [Presentation::getDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDocumentProperties) می‌خواند:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

در این حالت، محتوای اسلایدها بارگذاری نمی‌شود. اسلایدها، مسترها، طرح‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که نیاز به مدل شیء کامل ارائه دارد، [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) را بررسی کنند.

{{% alert color="warning" title="هشدار" %}}
متادیتای عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساس را به همراه ارائه رمزنگاری کنید. آنها را عمومی بگذارید فقط زمانی که سیستم‌های نمایه‌سازی، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی برای دسترسی بدون رمز عبور داشته باشند.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که در حالت فقط‑بارگذاری‑ویژگی‌های‑سند بارگذاری شده است برای خواندن متادیتای عمومی هدف‌گذاری می‌شود. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متادیتا ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های مربوطه درون ارائه رمزگذاری‌شده سازگار بمانند. بنابراین به‌روزرسانی آن‌ها نیاز به رمز عبور صحیح هنگام باز کردن و بارگذاری کامل دارد.

مثال زیر ارائه را با استفاده از [LoadOptions::setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) باز می‌کند، ویژگی‌های عمومی Built‑in را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌کند. سپس با استفاده از [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#isEncrypted) تأیید می‌کند که رمزگذاری حفظ شده و متادیتای عمومی را بدون رمز عبور دوباره باز می‌کند تا مقادیر جدید را تأیید نماید:

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

اگر یک برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties) آشکار می‌شوند شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ اصلاح)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولید‌کنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** می‌باشد.

```php
  # شیء Presentation را که نشان‌دهندهٔ ارائه است، نمونه‌سازی کنید
  $pres = new Presentation("Presentation.pptx");
  try {
    # یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
    $dp = $pres->getDocumentProperties();
    # نمایش ویژگی‌های داخلی
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اصلاح ویژگی‌های Built-in**

تغییر ویژگی‌های Built-in فایل‌های ارائه به سادگی دسترسی به آن‌ها است. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان دادیم چگونه می‌توان ویژگی‌های سند Built-in فایل ارائه را با استفاده از Aspose.Slides for PHP via Java اصلاح کرد.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
    $dp = $pres->getDocumentProperties();
    # تنظیم ویژگی‌های داخلی
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # ذخیرهٔ ارائه شما در یک فایل
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این مثال ویژگی‌های Built-in ارائه را اصلاح می‌کند که می‌توانید به‌صورت زیر مشاهده کنید:

|**ویژگی‌های سند Built-in پس از اصلاح**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سند سفارشی**

Aspose.Slides for PHP via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. یک مثال در زیر نشان می‌دهد چگونه ویژگی‌های سفارشی را برای یک ارائه تنظیم کنیم.

```php
  $pres = new Presentation();
  try {
    # دریافت ویژگی‌های سند
    $dProps = $pres->getDocumentProperties();
    # افزودن ویژگی‌های سفارشی
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # دریافت نام ویژگی در ایندکس خاص
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # حذف ویژگی انتخاب‌شده
    $dProps->removeCustomProperty($getPropertyName);
    # ذخیرهٔ ارائه
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**ویژگی‌های سند سفارشی افزوده‌شده**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و اصلاح ویژگی‌های سفارشی**

Aspose.Slides for PHP via Java همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی پیدا کنند. یک مثال در زیر نشان می‌دهد چگونه می‌توانید به تمام این ویژگی‌های سفارشی یک ارائه دسترسی داشته و آن‌ها را اصلاح کنید.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # یک مرجع به شیء DocumentProperties مرتبط با Presentation ایجاد کنید
    $dp = $pres->getDocumentProperties();
    # دسترسی و اصلاح ویژگی‌های سفارشی
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # اصلاح مقادیر ویژگی‌های سفارشی
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # ذخیرهٔ ارائه شما در یک فایل
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این مثال ویژگی‌های سفارشی ارائهٔ [PPTX](https://docs.fileformat.com/presentation/pptx/) را اصلاح می‌کند. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از اصلاح نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از اصلاح**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی پس از اصلاح**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های پیشرفته سند**

{{% alert color="info" title="نکته" %}}
متدهای جدید [readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)، [updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) و [writeBindedPresentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo) اضافه شده‌اند، منطق setter ویژگی [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#setLastSavedTime) تغییر یافته است.
{{% /alert %}} 

دو متد جدید [readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) و [updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo) اضافه شده‌اند. آنها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و امکان تغییر و به‌روزرسانی ویژگی‌ها بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمول بارگذاری ویژگی‌ها، تغییر مقدار برخی از آن‌ها و به‌روزرسانی سند می‌تواند به صورت زیر پیاده‌سازی شود:

```php
  # اطلاعات ارائه را بخوانید
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # ویژگی‌های فعلی را دریافت کنید
  $props = $info->readDocumentProperties();
  # مقادیر جدید فیلدهای Author و Title را تنظیم کنید
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # ارائه را با مقادیر جدید به‌روزرسانی کنید
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

راه دیگری نیز وجود دارد برای استفاده از ویژگی‌های یک ارائه خاص به عنوان قالب جهت به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

یک قالب جدید می‌تواند از ابتدا ایجاد شود و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **تنظیم زبان اصلاح**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat نمایش داده می‌شود) را فراهم می‌کند تا بتوانید زبان اصلاح برای یک سند PowerPoint را تنظیم کنید. زبان اصلاح زبانی است که املا و دستور زبان در PowerPoint برای آن بررسی می‌شود.

این کد PHP نشان می‌دهد چگونه زبان اصلاح برای یک PowerPoint تنظیم شود: xxx چرا LanguageId در کلاس Java PortionFormat موجود نیست؟

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN"); // تنظیم شناسهٔ زبان تصحیح

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم زبان پیش‌فرض**

این کد PHP نشان می‌دهد چگونه زبان پیش‌فرض برای کل یک ارائه PowerPoint تنظیم شود:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # یک شکل مستطیلی جدید با متن اضافه می‌کند
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # زبان اولین بخش را بررسی می‌کند
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **مثال زنده**

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توان با ویژگی‌های سند از طریق API Aspose.Slides کار کرد:

[![نمایش و ویرایش متادیتای PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **پرسش‌های متداول**

**چگونه می‌توان یک ویژگی Built-in را از یک ارائه حذف کرد؟**

ویژگی‌های Built-in بخشی یکپارچه از ارائه هستند و نمی‌توان به‌طور کامل آن‌ها را حذف کرد. اما می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورتی که ویژگی اجازه دهد، به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که از پیش وجود دارد را اضافه کنم چه می‌شود؟**

اگر یک ویژگی سفارشی که از پیش وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توان ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی داشت؟**

بله. می‌توانید با استفاده از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/) سپس [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties) متادیتای ذخیره‌شده سند را بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بخوانید. برای یک مثال کامل گزارش‌گیری و محدودیت‌های خاص قالب، به [Build a Lightweight Presentation Inventory](/slides/fa/php-java/examine-presentation/) مراجعه کنید.

**آیا می‌توان ویژگی‌های عمومی یک ارائه رمزگذاری‌شده را بدون رمز عبور باز کردن آن خواند؟**

بله. رمزگذاری ویژگی‌های سند باید قبل از رمزگذاری ارائه غیرفعال شده باشد و ارائه باید در حالت فقط‑بارگذاری‑ویژگی‌های‑سند بارگذاری شود.

**آیا می‌توان یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑بارگذاری‑ویژگی‌های‑سند به‌روزرسانی کرد؟**

خیر. داده‌های ویژگی عمومی و رمزگذاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیاز به بارگذاری کامل ارائه با رمز عبور صحیح دارد.