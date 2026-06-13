---
title: مدیریت قلم‌ها در ارائه‌ها با استفاده از PHP
linktitle: مدیریت قلم‌ها
type: docs
weight: 10
url: /fa/php-java/manage-fonts/
keywords:
- مدیریت قلم‌ها
- ویژگی‌های قلم
- پاراگراف
- قالب‌بندی متن
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "کنترل قلم‌ها در PHP با Aspose.Slides: افزودن، جایگزینی و بارگذاری قلم‌های سفارشی برای حفظ وضوح، امنیت برند و سازگاری ارائه‌های PPT، PPTX و ODP."
---
## **مدیریت ویژگی‌های مرتبط با قلم**
{{% alert color="primary" %}} 

ارائه‌ها معمولاً شامل متن و تصاویر هستند. متن می‌تواند به روش‌های مختلفی قالب‌بندی شود، چه برای برجسته‌کردن بخش‌ها و کلمات خاص و چه برای سازگار شدن با سبک‌های شرکتی. قالب‌بندی متن به کاربران کمک می‌کند تا ظاهر و حس محتوای ارائه را تغییر دهند. این مقاله نشان می‌دهد که چگونه از Aspose.Slides برای PHP از طریق Java برای پیکربندی ویژگی‌های قلم پاراگراف‌های متنی در اسلایدها استفاده کنید.

{{% /alert %}} 

برای مدیریت ویژگی‌های قلم یک پاراگراف با استفاده از Aspose.Slides برای PHP از طریق Java:

1. یک نمونه از کلاس [Presentation] ایجاد کنید.
1. با استفاده از اندیس اسلاید، مرجع آن را به دست آورید.
1. اشکال [Placeholder] موجود در اسلاید را دسترسی پیدا کنید و آنها را به نوع [AutoShape] تبدیل کنید.
1. از [AutoShape]، [Paragraph] را از [TextFrame] دریافت کنید.
1. پاراگراف را تراز کنید.
1. متن [Portion] یک [Paragraph] را دسترسی پیدا کنید.
1. فونت را با استفاده از [FontData] تعریف کنید و سپس **Font** متن [Portion] را به‌طور متناسب تنظیم کنید.
   1. فونت را به حالت بولد (پررنگ) تنظیم کنید.
   1. فونت را به حالت ایتالیک (کج) تنظیم کنید.
1. رنگ فونت را با استفاده از [FillFormat] موجود در شیء [Portion] تنظیم کنید.
1. ارائه‌ی اصلاح شده را به‌صورت فایل PPTX ذخیره کنید.

اجرای مراحل فوق در کد زیر نشان داده شده است. این کد یک ارائهٔ ساده را می‌گیرد و قلم‌های اسلایدی را قالب‌بندی می‌کند. تصویرهای زیر فایل ورودی و نحوهٔ تغییر آن توسط کد را نشان می‌دهند. کد قلم، رنگ و سبک قلم را تغییر می‌دهد.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**شکل: متن در فایل ورودی**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**شکل: همان متن با قالب‌بندی به‌روز شده**|

```php
  # یک شیء Presentation ایجاد کنید که نمایانگر فایل PPTX است
  $pres = new Presentation("FontProperties.pptx");
  try {
    # دسترسی به اسلاید با استفاده از موقعیت اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # دسترسی به اولین و دومین placeholder در اسلاید و تبدیل آنها به AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # دسترسی به پاراگراف اول
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # تراز پاراگراف
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # دسترسی به اولین portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # تعریف قلم‌های جدید
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # اختصاص قلم‌های جدید به portion
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # تنظیم قلم به حالت پررنگ
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # تنظیم قلم به حالت کج
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # تنظیم رنگ قلم
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # ذخیره PPTX در دیسک
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم ویژگی‌های قلم متن**
{{% alert color="primary" %}} 

همان‌طور که در **مدیریت ویژگی‌های مرتبط با قلم** اشاره شد، یک [Portion] برای نگه‌داشتن متنی با سبک قالب‌بندی مشابه در یک پاراگراف استفاده می‌شود. این مقاله نشان می‌دهد که چگونه از Aspose.Slides برای PHP از طریق Java برای ایجاد یک جعبه متن حاوی متنی استفاده کنید و سپس یک فونت خاص و ویژگی‌های دیگر مربوط به دسته‌بند فونت را تعریف کنید.

{{% /alert %}} 

برای ایجاد یک جعبه متن و تنظیم ویژگی‌های قلم متن در آن:

1. یک نمونه از کلاس [Presentation] ایجاد کنید.
1. با استفاده از اندیس، مرجع یک اسلاید را به دست آورید.
1. یک [AutoShape] از نوع **Rectangle** به اسلاید اضافه کنید.
1. سبک پر (fill) مرتبط با [AutoShape] را حذف کنید.
1. به [TextFrame] مربوط به [AutoShape] دسترسی پیدا کنید.
1. متنی به [TextFrame] اضافه کنید.
1. به شیء [Portion] مرتبط با [TextFrame] دسترسی پیدا کنید.
1. فونت مورد استفاده برای [Portion] را تعریف کنید.
1. ویژگی‌های دیگر فونت مانند بولد، ایتالیک، زیرخط، رنگ و ارتفاع را با استفاده از خواص مرتبط که توسط شیء [Portion] در دسترس هستند، تنظیم کنید.
1. ارائه‌ی اصلاح شده را به‌صورت فایل PPTX بنویسید.

اجرای مراحل فوق در کد زیر نشان داده شده است.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**شکل: متن با برخی ویژگی‌های قلم که توسط Aspose.Slides برای PHP از طریق Java تنظیم شده است**|

```php
  # یک شیء Presentation ایجاد کنید که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن یک AutoShape از نوع Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # حذف هر سبک پر (fill) مرتبط با AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # دسترسی به TextFrame مرتبط با AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # دسترسی به Portion مرتبط با TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # تنظیم قلم برای Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # تنظیم ویژگی Bold قلم
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # تنظیم ویژگی Italic قلم
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # تنظیم ویژگی Underline قلم
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # تنظیم ارتفاع قلم
    $port->getPortionFormat()->setFontHeight(25);
    # تنظیم رنگ قلم
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # ذخیره ارائه در دیسک
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```