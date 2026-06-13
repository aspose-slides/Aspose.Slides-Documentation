---
title: مدیریت ویژگی‌های ارائه در PHP
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/php-java/presentation-properties/
keywords:
- ویژگی‌های پاورپوینت
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان بررسی املایی
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای PHP via Java به‌طور کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های پاورپوینت و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط متد [Presentation::getDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDocumentProperties) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند که چگونه می‌توان این ویژگی‌ها را خواند، تغییر داد و مدیریت کرد.

{{% alert color="primary" %}} 

لطفاً توجه داشته باشید که فیلدهای **Application** و **Producer** قابل تغییر نیستند، چراکه این فیلدها همیشه مقدار «Aspose Ltd.» و «Aspose.Slides for PHP via Java x.x.x» را نمایش می‌دهند.

{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی افزودن برخی ویژگی‌ها به فایل‌های ارائه را فراهم می‌کند. این ویژگی‌های سند امکان ذخیره اطلاعات مفید همراه با اسناد (فایل‌های ارائه) را می‌دهند. دو نوع ویژگی سند وجود دارد:

- ویژگی‌های تعریف‌شده توسط سیستم (Built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (Custom)

**Built-in** ویژگی‌ها شامل اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره هستند. **Custom** ویژگی‌ها آن‌هایی هستند که توسط کاربران به صورت جفت **Name/Value** تعریف می‌شوند، که هر دو نام و مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for PHP via Java، توسعه‌دهندگان می‌توانند به مقادیر ویژگی‌های Built-in و همچنین ویژگی‌های سفارشی دسترسی پیدا کرده و آنها را تغییر دهند.

## **ویژگی‌های سند در پاورپوینت**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را می‌دهد. فقط کافی است روی نماد Office کلیک کنید و سپس گزینه **Prepare | Properties | Advanced Properties** را در منوی Microsoft PowerPoint 2007 انتخاب کنید همان‌طور که در زیر نشان داده شده است:

|**انتخاب گزینه Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
پس از انتخاب گزینه **Advanced Properties**، دیالوگی ظاهر می‌شود که به شما امکان مدیریت ویژگی‌های سند فایل PowerPoint را می‌دهد همان‌طور که در تصویر زیر مشاهده می‌شود:

|**پنجرهٔ ویژگی‌ها**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
در **پنجرهٔ ویژگی‌ها** بالا می‌توانید تب‌های متعددی مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom** را ببینید. تمام این تب‌ها امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint به کار می‌رود.

کار با ویژگی‌های سند با استفاده از Aspose.Slides for PHP via Java

همان‌طور که پیشتر توضیح دادیم Aspose.Slides for PHP via Java دو نوع ویژگی سند را پشتیبانی می‌کند: ویژگی‌های **Built-in** و **Custom**. بنابراین، توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides for PHP via Java به هر دو نوع ویژگی دسترسی پیدا کنند. Aspose.Slides for PHP via Java کلاسی به نام [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نمایان می‌کند.

توسعه‌دهندگان می‌توانند از ویژگی **DocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) افشا می‌شود، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در زیر شرح داده شده است، استفاده کنند:

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties) نمایان می‌شوند شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title**.

```php
  # نماد سازی کلاس Presentation که نمایانگر ارائه است
  $pres = new Presentation("Presentation.pptx");
  try {
    # ایجاد مرجع به شیء IDocumentProperties مرتبط با Presentation
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

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های Built-in فایل‌های ارائه به همان اندازه ساده است که دسترسی به آن‌ها. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان داده‌ایم که چگونه می‌توان ویژگی‌های سند Built-in یک فایل ارائه را با استفاده از Aspose.Slides for PHP via Java تغییر داد.

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
    # ارائه خود را در یک فایل ذخیره کنید
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این مثال ویژگی‌های Built-in ارائه را که پس از تغییر به شکل زیر نمایش داده می‌شوند، نشان می‌دهد:

|**ویژگی‌های سند Built-in پس از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سفارشی سند**

Aspose.Slides for PHP via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه را اضافه کنند. یک مثال در زیر آورده شده که نشان می‌دهد چگونه می‌توان ویژگی‌های سفارشی یک ارائه را تنظیم کرد.

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

|**ویژگی‌های سفارشی سند افزوده‌شده**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for PHP via Java همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی پیدا کنند. یک مثال در زیر نشان می‌دهد که چگونه می‌توانید تمام این ویژگی‌های سفارشی را برای یک ارائه دسترسی و تغییر دهید.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # یک مرجع به شیء DocumentProperties مرتبط با Presentation ایجاد کنید
    $dp = $pres->getDocumentProperties();
    # دسترسی و تغییر ویژگی‌های سفارشی
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # تغییر مقادیر ویژگی‌های سفارشی
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # ارائه خود را در یک فایل ذخیره کنید
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این مثال ویژگی‌های سفارشی ارائه‌ی [PPTX ](https://docs.fileformat.com/presentation/pptx/) را تغییر می‌دهد. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از تغییر نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی پس از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های پیشرفته سند**

{{% alert color="primary" %}} 

روش‌های جدید [readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)، [updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) و [writeBindedPresentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo) اضافه شده‌اند، منطق setter برای ویژگی [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#setLastSavedTime) تغییر یافته است.

{{% /alert %}} 

دو روش جدید [readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) و [updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo) اضافه شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و امکان تغییر و به‌روزرسانی ویژگی‌ها بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمولی بارگذاری ویژگی‌ها، تغییر مقداری و به‌روزرسانی سند می‌تواند به شکل زیر اجرا شود:

```php
  # اطلاعات ارائه را بخوانید
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # ویژگی‌های فعلی را به‌دست آورید
  $props = $info->readDocumentProperties();
  # مقادیر جدید فیلدهای Author و Title را تنظیم کنید
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # ارائه را با مقادیر جدید به‌روزرسانی کنید
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

راه دیگری برای استفاده از ویژگی‌های یک ارائه به عنوان قالب برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر وجود دارد:

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

قالب جدید می‌تواند از ابتدا ساخته شود و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

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

## **تنظیم زبان بررسی املایی**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat افشا می‌شود) را فراهم می‌کند تا به شما اجازه دهد زبان بررسی املایی برای یک سند PowerPoint را تنظیم کنید. زبان بررسی املایی زبانی است که املا و دستور زبان در PowerPoint برای آن بررسی می‌شود.

این کد PHP نشان می‌دهد چطور زبان بررسی املایی برای یک PowerPoint تنظیم شود: xxx چرا LanguageId در کلاس Java PortionFormat وجود ندارد؟

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// شناسه زبان بررسی املایی را تنظیم کنید

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم زبان پیش‌فرض**

این کد PHP نشان می‌دهد چطور زبان پیش‌فرض برای یک ارائه کامل PowerPoint تنظیم شود:

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

سعی کنید برنامهٔ آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توان با ویژگی‌های سند از طریق API Aspose.Slides کار کرد:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **پرسش‌های متداول**

**چگونه می‌توان یک ویژگی Built-in را از یک ارائه حذف کرد؟**

ویژگی‌های Built-in جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را به طور کامل حذف کرد. با این حال می‌توانید مقدار آنها را تغییر دهید یا اگر ویژگی اجازه دهد، آن را خالی کنید.

**اگر ویژگی سفارشی که از قبل وجود دارد اضافه کنم چه اتفاقی می‌افتد؟**

اگر ویژگی سفارشی که از قبل وجود دارد اضافه کنید، مقدار قبلی آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی پیش از افزودن نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توان بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی پیدا کرد؟**

بله، می‌توانید بدون بارگذاری کامل ارائه، با استفاده از متد `getPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/) به ویژگی‌های ارائه دسترسی پیدا کنید. سپس با استفاده از متد `readDocumentProperties` ارائه‌شده توسط کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/) ویژگی‌ها را به‌صورت کارآمد بخوانید و حافظه و عملکرد را بهبود بخشید.