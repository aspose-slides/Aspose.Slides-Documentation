---
title: مدیریت اشیای جوهر ارائه در PHP
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/php-java/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردیاب جوهر
- مدیریت جوهر
- رسم جوهر
- رسم
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت اشیای جوهر PowerPoint — ایجاد، ویرایش و استایل‌دادن به جوهر دیجیتال با Aspose.Slides برای PHP از طریق Java. دریافت نمونه کد برای ردیاب‌ها، رنگ و اندازه Brush."
---
## **معرفی**

PowerPoint عملکرد جوهر را فراهم می‌کند تا بتوانید اشکال غیر استاندارد رسم کنید؛ این اشکال می‌توانند برای برجسته‌سازی اشیاء دیگر، نشان دادن اتصالات و فرایندها و جلب توجه به موارد خاص در یک اسلاید استفاده شوند.

Aspose.Slides تمام انواع جوهر (به عنوان مثال کلاس [Ink](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ink/)) را که برای ایجاد و مدیریت اشیای جوهر نیاز دارید، ارائه می‌دهد.

## **تفاوت‌های بین اشیای معمولی و اشیای جوهر**

اشیای موجود در یک اسلاید PowerPoint معمولاً توسط اشیای شکل (shape) نمایان می‌شوند. یک شیء شکل، در ساده‌ترین شکل خود، یک ظرف است که ناحیه خود شی (قاب) را به همراه ویژگی‌هایش تعریف می‌کند. ویژگی‌ها شامل اندازه ناحیه ظرف، شکل ظرف، پس‌زمینه ظرف و غیره می‌شوند. برای اطلاعات بیشتر، به بخش [Shape Layout Format](https://docs.aspose.com/slides/fa/php-java/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

اما زمانی که PowerPoint با یک شیء جوهر سروکار دارد، تمام ویژگی‌های قاب شیء (ظرف) به جز اندازه‌ آن را نادیده می‌گیرد. اندازه ناحیه ظرف توسط مقادیر استاندارد `width` و `height` تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیابی‌های Inkshape**

ردیابی (Trace) یک عنصر پایه یا استاندارد برای ضبط مسیر قلم هنگام نوشتن جوهر دیجیتال توسط کاربر است. ردیابی‌ها ضبط‌های توصیف‌کننده توالی نقاط متصل هستند.

ساده‌ترین شکل رمزگذاری، مختصات X و Y هر نقطه نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر می‌شوند، تصویری مشابه این به دست می‌آید:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های Brush برای رسم**

می‌توانید از Brush برای رسم خطوطی که نقاط عناصر ردیابی را به هم متصل می‌کند، استفاده کنید. Brush رنگ و اندازه خاص خود را دارد که مطابق با ویژگی‌های `Brush.Color` و `Brush.Size` است.

### **تنظیم رنگ Brush جوهر**

این کد PHP نشان می‌دهد چگونه رنگ یک Brush را تنظیم کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تنظیم اندازه Brush جوهر**

این کد PHP نشان می‌دهد چگونه اندازه یک Brush را تنظیم کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

به طور کلی، عرض و ارتفاع یک Brush مطابقت ندارند، بنابراین PowerPoint اندازه Brush را نمایش نمی‌دهد (بخش داده‌ها خاکستری می‌شود). اما وقتی عرض و ارتفاع Brush با هم مطابقت دارند، PowerPoint اندازه آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را مرور می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

ظرف (قاب) اندازه Brush‌ها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر آخر مراجعه کنید).

بنابراین، برای تعیین ناحیه قابل مشاهده کل شیء جوهر، باید اندازه Brush‌های اشیای ردیابی را در نظر بگیریم. در اینجا، شیء هدف (شیء ردیابی متن دست‌نویس) به اندازه ظرف (قاب) مقیاس‌بندی شده است. هنگامی که اندازه ظرف (قاب) تغییر می‌کند، اندازه Brush ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint همین رفتار را هنگام کار با متن‌ها نیز نشان می‌دهد:

![ink_powerpoint6](ink_powerpoint6.png)

**مطالعه بیشتر**

* برای آشنایی کلی با اشکال، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/php-java/powerpoint-shapes/) را ببینید.
* برای اطلاعات بیشتر درباره مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/php-java/shape-effective-properties/#getting-effective-font-height-value) مراجعه کنید.