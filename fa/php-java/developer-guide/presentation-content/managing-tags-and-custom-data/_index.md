---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از PHP
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/php-java/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- افزودن برچسب
- جفت مقادیر
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های سفارشی را در Aspose.Slides برای PHP از طریق Java اضافه، خوانده، به‌روز‌رسانی و حذف کنید، همراه با مثال‌هایی برای ارائه‌های PowerPoint و OpenDocument."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. به‌طور خلاصه نحوه ذخیره‌سازی داده‌ها در فایل‌های PPTX را بیان می‌کند، اشاره می‌کند که داده‌های مخصوص ارائه می‌توانند به‌صورت برچسب‌ها و بخش‌های XML سفارشی وجود داشته باشند، و برچسب‌ها را به‌عنوان جفت‌های کلید‑مقدار رشته‌ای توصیف می‌کند.

همچنین نشان می‌دهد چگونه مقادیر برچسب‌ها را بخوانید و برچسب‌ها را به یک ارائه، یک اسلاید جداگانه یا یک شکل اضافه کنید. علاوه بر این، مقاله به وظایف رایج مدیریت برچسب مانند پاک‌سازی تمام برچسب‌ها، حذف یک برچسب بر اساس نام، و بازیابی فهرست نام‌های برچسب می‌پردازد.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX—مواردی با پسوند .pptx—در فرمت PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. فرمت Office Open XML ساختار داده‌های موجود در ارائه‌ها را تعریف می‌کند.

با در نظر گرفتن *اسلاید* به‌عنوان یکی از عناصر ارائه‌ها، یک *قسمت اسلاید* شامل محتوای یک اسلاید واحد است. یک قسمت اسلاید می‌تواند روابط صریحی با بخش‌های متعدد داشته باشد—مانند برچسب‌های تعریف‌شده توسط کاربر—که توسط ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی (خاص یک ارائه) یا کاربر می‌توانند به‌صورت برچسب‌ها ([TagCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/)) و بخش‌های XML سفارشی ([CustomXmlPartCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpartcollection/)) وجود داشته باشند.

{{% alert color="primary" %}} 
برچسب‌ها در واقع مقادیر جفت کلید‑رشته‌ای هستند. 
{{% /alert %}} 

## **به‌دست‌آوردن مقادیر برچسب‌ها**

در اسلایدها، یک برچسب معادل روش‌های [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getKeywords) و [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#setKeywords) است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای PHP از طریق Java برای [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) دریافت کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **افزودن برچسب به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام ویژگی سفارشی - `MyTag`
- مقدار ویژگی سفارشی - `My Tag Value`

اگر نیاز داشته باشید برخی از ارائه‌ها را بر اساس قانون یا ویژگی خاصی طبقه‌بندی کنید، می‌توانید از افزودن برچسب به آن ارائه‌ها بهره‌مند شوید. برای مثال، اگر بخواهید تمام ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کرده و کشورهای مربوطه (ایالات متحده، مکزیک و کانادا) را به‌عنوان مقادیر اختصاص دهید.

این کد نمونه نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) با استفاده از Aspose.Slides برای PHP از طریق Java اضافه کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

برچسب‌ها همچنین می‌توانند برای [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) تنظیم شوند:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

یا برای هر [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) جداگانه:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **محدودیت‌ها**

برچسب‌هایی که از طریق مجموعه برچسب‌های داده سفارشی با `getCustomData()->getTags()` افزوده می‌شوند، فقط درون فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب‌های PDF هنگام صادر کردن ارائه به PDF منتقل نمی‌شوند. بنابراین، شناسه سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه‌حل**: می‌توانید شناسه سفارشی را در **متن Alt** شیء (مثلاً `$shape->setAlternativeText("MyId")`) ذخیره کنید. پس از صادر کردن به PDF، متن Alt ممکن است در ساختار برچسب‌های PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌بار حذف می‌نماید.

**چگونه می‌توانم یک برچسب واحد را بر اساس نام آن بدون پیمایش کل مجموعه حذف کنم؟**

از عملیات [remove(name)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/remove/) بر روی [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلید خود حذف کنید.

**چگونه می‌توانم فهرست کامل نام‌های برچسب را برای تجزیه و تحلیل یا فیلتر کردن دریافت کنم؟**

از [getNamesOfTags](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/getnamesoftags/) بر روی [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای شامل تمام نام‌های برچسب را باز می‌گرداند.