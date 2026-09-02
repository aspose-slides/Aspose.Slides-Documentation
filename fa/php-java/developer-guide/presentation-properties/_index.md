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
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان اثبات
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت کامل ویژگی‌های ارائه در Aspose.Slides برای PHP از طریق Java و بهینه‌سازی جستجو، برندینگ و جریان کار در فایل‌های PowerPoint و OpenDocument شما."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع ویژگی می‌توانند به راحتی با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط متد [Presentation::getDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDocumentProperties) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را خوانده، تغییر داده و مدیریت کنید.

{{% alert color="info" title="نکته" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل تغییر نیستند. Aspose.Slides آنها را در هر ذخیره‌سازی بازنویسی می‌کند، بنابراین یک ارائه ذخیره‌شده همیشه «Aspose.Slides for PHP via Java» و نسخه کتابخانه‌ای که آن را تولید کرده گزارش می‌دهد. هر مقداری که به `setNameOfApplication` پاس داده شود هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint قابلیت افزودن برخی ویژگی‌ها به فایل‌های ارائه را ارائه می‌دهد. این ویژگی‌های سند اجازه می‌دهند اطلاعات مفیدی همراه با اسناد (فایل‌های ارائه) ذخیره شود. دو نوع ویژگی سند به شرح زیر وجود دارد:

- ویژگی‌های تعریف‌شده توسط سیستم (**Built-in**)
- ویژگی‌های تعریف‌شده توسط کاربر (**Custom**)

ویژگی‌های **Built-in** شامل اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره هستند. ویژگی‌های **Custom** مواردی هستند که توسط کاربر به صورت جفت **نام/مقدار** تعریف می‌شوند، جایی که هم نام و هم مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for PHP via Java، توسعه‌دهندگان می‌توانند مقادیر ویژگی‌های پیش‌فرض و دلخواه را دسترسی و تغییر دهند.

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. تمام کاری که باید انجام دهید این است که روی نماد Office کلیک کنید و سپس گزینه **Prepare | Properties | Advanced Properties** را در منوی Microsoft PowerPoint 2007 انتخاب کنید همان‌طور که در زیر نشان داده شده است:

|**انتخاب گزینه Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

پس از انتخاب گزینه **Advanced Properties**، یک گفت‌و‌گوی پنجره باز می‌شود که به شما امکان مدیریت ویژگی‌های سند فایل PowerPoint را می‌دهد همان‌طور که در شکل زیر نشان داده شده است:

|**گفت‌وگوی ویژگی‌ها**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

در این **گفت‌وگوی ویژگی‌ها** می‌توانید ببینید که تب‌های متعددی مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom** موجود هستند. تمام این تب‌ها اجازه پیکربندی انواع مختلفی از اطلاعات مرتبط با فایل‌های PowerPoint را می‌دهند. تب **Custom** برای مدیریت ویژگی‌های دلخواه فایل‌های PowerPoint استفاده می‌شود.

### کار با ویژگی‌های سند با Aspose.Slides for PHP via Java

همان‌طور که قبلاً توضیح دادیم، Aspose.Slides for PHP via Java دو نوع ویژگی سند را پشتیبانی می‌کند: ویژگی‌های **Built-in** و **Custom**. بنابراین، توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides for PHP via Java به هر دو نوع ویژگی دسترسی پیدا کنند. Aspose.Slides for PHP via Java کلاسی به نام [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نشان می‌دهد.

توسعه‌دهندگان می‌توانند از ویژگی **DocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ارائه می‌شود برای دسترسی به ویژگی‌های سند فایل‌های ارائه استفاده کنند همان‌طور که در زیر توضیح داده شده است:

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties) ارائه می‌شوند شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ اصلاح)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** هستند.

```php
  # یک نمونه از کلاس Presentation که نمایانگر ارائه است را ایجاد کنید
  $pres = new Presentation("Presentation.pptx");
  try {
    # یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
    $dp = $pres->getDocumentProperties();
    # ویژگی‌های داخلی را نمایش دهید
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

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های پیش‌فرض فایل‌های ارائه به اندازه دسترسی به آنها ساده است. می‌توانید به سادگی مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نحوه تغییر ویژگی‌های سند پیش‌فرض فایل ارائه را با استفاده از Aspose.Slides for PHP via Java نشان می‌دهیم.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
    $dp = $pres->getDocumentProperties();
    # ویژگی‌های داخلی را تنظیم کنید
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # ارائه خود را در فایل ذخیره کنید
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این مثال ویژگی‌های پیش‌فرض ارائه را که می‌توانند به صورت زیر مشاهده شوند، تغییر می‌دهد:

|**ویژگی‌های سند پیش‌فرض پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سند دلخواه**

Aspose.Slides for PHP via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر دلخواه برای ویژگی‌های سند ارائه را اضافه کنند. مثال زیر نشان می‌دهد چگونه ویژگی‌های دلخواه برای یک ارائه تنظیم می‌شوند.

```php
  $pres = new Presentation();
  try {
    # دریافت ویژگی‌های سند
    $dProps = $pres->getDocumentProperties();
    # افزودن ویژگی‌های سفارشی
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # دریافت نام ویژگی در اندیس خاص
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # حذف ویژگی انتخاب‌شده
    $dProps->removeCustomProperty($getPropertyName);
    # ذخیره‌سازی ارائه
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**ویژگی‌های سند دلخواه افزوده‌شده**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و تغییر ویژگی‌های دلخواه**

Aspose.Slides for PHP via Java همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های دلخواه دسترسی داشته باشند. مثال زیر نشان می‌دهد چگونه می‌توانید تمام این ویژگی‌های دلخواه را برای یک ارائه دسترسی و تغییر دهید.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # ایجاد یک مرجع به شیء DocumentProperties مرتبط با Presentation
    $dp = $pres->getDocumentProperties();
    # دسترسی و تغییر ویژگی‌های سفارشی
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # تغییر مقادیر ویژگی‌های سفارشی
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # ذخیره‌سازی ارائه شما در یک فایل
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این مثال ویژگی‌های دلخواه ارائهٔ [PPTX ](https://docs.fileformat.com/presentation/pptx/) را تغییر می‌دهد. شکل‌های زیر ویژگی‌های دلخواه ارائه را قبل و بعد از تغییر نشان می‌دهند:

|**ویژگی‌های دلخواه قبل از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های دلخواه پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های سند پیشرفته**

{{% alert color="info" title="نکته" %}}
متدهای جدید [readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)، [updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) و [writeBindedPresentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo) افزوده شده‌اند؛ منطق setter ویژگی [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#setLastSavedTime) نیز تغییر یافته است.
{{% /alert %}} 

دو متد جدید [readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) و [updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo) اضافه شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و امکان تغییر و به‌روزرسانی ویژگی‌ها بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمول بارگذاری ویژگی‌ها، تغییر مقداری و به‌روزرسانی سند به شکل زیر می‌تواند پیاده‌سازی شود:

```php
  # اطلاعات ارائه را بخوانید
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # دریافت ویژگی‌های فعلی
  $props = $info->readDocumentProperties();
  # تنظیم مقادیر جدید فیلدهای نویسنده و عنوان
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # به‌روزرسانی ارائه با مقادیر جدید
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

روش دیگری برای استفاده از ویژگی‌های یک ارائه خاص به عنوان قالب برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر وجود دارد:

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

یک قالب جدید می‌تواند از ابتدا ایجاد شده و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

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

## **تنظیم زبان اثبات (Proofing Language)**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat ارائه می‌شود) را برای تنظیم زبان اثبات یک سند PowerPoint فراهم می‌کند. زبان اثبات زبانی است که املا و گرامر در PowerPoint بر اساس آن بررسی می‌شود.

این کد PHP نشان می‌دهد چگونه زبان اثبات برای PowerPoint تنظیم می‌شود: xxx چرا LanguageId در کلاس Java PortionFormat وجود ندارد؟

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
    $portionFormat->setLanguageId("zh-CN");// تنظیم شناسه یک زبان اثبات

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم زبان پیش‌فرض**

این کد PHP نشان می‌دهد چگونه زبان پیش‌فرض برای کل ارائه PowerPoint تنظیم می‌شود:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # یک شکل مستطیل جدید با متن اضافه می‌کند
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

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توان یک ویژگی پیش‌فرض را از یک ارائه حذف کرد؟**

ویژگی‌های پیش‌فرض جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را به طور کامل حذف کرد. با این حال می‌توانید مقدارشان را تغییر دهید یا در صورتی که توسط ویژگی خاص اجازه داده شود آن را خالی کنید.

**اگر یک ویژگی دلخواه که قبلاً وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی دلخواه که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی پیشین ویژگی نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توان ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کرد؟**

بله. از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/) استفاده کنید و سپس [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties) را برای خواندن متادیتای ذخیره‌شده سند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) فراخوانی کنید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به [Build a Lightweight Presentation Inventory](/slides/fa/php-java/examine-presentation/) مراجعه کنید.