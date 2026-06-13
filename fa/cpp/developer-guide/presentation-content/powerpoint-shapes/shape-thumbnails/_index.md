---
title: ایجاد تصاویر بندانگشتی از اشکال ارائه در C++
linktitle: تصاویر بندانگشتی شکل
type: docs
weight: 70
url: /fa/cpp/shape-thumbnails/
keywords:
- تصویر بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "تصاویر بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint با Aspose.Slides برای C++ تولید کنید – به‌راحتی تصاویر بندانگشتی ارائه را ایجاد و خروجی بگیرید."
---
## **مقدمه**

Aspose.Slides برای ایجاد فایل‌های ارائه استفاده می‌شود که هر صفحه‌ای یک اسلاید است. این اسلایدها می‌توانند با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده شوند. اما گاهی اوقات توسعه‌دهندگان نیاز دارند تصاویر اشکال را به‌صورت جداگانه در یک برنامه‌ی نمایش تصویر مشاهده کنند. در چنین مواردی Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی از اشکال اسلاید تولید کنید. نحوه استفاده از این ویژگی در این مقاله توضیح داده شده است.  
این مقاله چگونگی تولید تصویر بندانگشتی اسلاید را به روش‌های مختلف شرح می‌دهد:

- تولید تصویر بندانگشتی یک شکل داخل اسلاید.  
- تولید تصویر بندانگشتی یک شکل با ابعاد تعریف‌شده توسط کاربر.  
- تولید تصویر بندانگشتی یک شکل در محدوده ظاهر شکل.

## **تولید تصویر بندانگشتی یک شکل از اسلاید**
برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides for C++:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. با استفاده از شناسه یا ایندکس، مرجع هر اسلاید را دریافت کنید.  
1. تصویر بندانگشتی شکل مرجع را بر روی مقیاس پیش‌فرض دریافت کنید.  
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر یک تصویر بندانگشتی شکل را تولید می‌کند.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **تولید تصویر بندانگشتی با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر**
برای تولید تصویر بندانگشتی شکل هر اسلاید با استفاده از Aspose.Slides for C++:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. با استفاده از شناسه یا ایندکس، مرجع هر اسلاید را دریافت کنید.  
1. تصویر بندانگشتی اسلاید مرجع را با محدوده شکل دریافت کنید.  
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر تصویر بندانگشتی را با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر تولید می‌کند.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // مقیاس‌بندی در طول محورهای X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **ایجاد تصویر بندانگشتی ظاهر شکل بر مبنای محدوده**
این روش برای ایجاد تصاویر بندانگشتی از اشکال به توسعه‌دهندگان امکان می‌دهد تا تصویری در محدوده ظاهر شکل تولید کنند. تمام اثرات شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید شده توسط محدوده اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی هر شکل اسلاید در محدوده ظاهر آن، از کد نمونه زیر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. با استفاده از شناسه یا ایندکس، مرجع هر اسلاید را دریافت کنید.  
1. تصویر بندانگشتی اسلاید مرجع را با محدوده شکل به‌عنوان ظاهر دریافت کنید.  
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر تصویری بندانگشتی را با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر ایجاد می‌کند.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // مقیاس‌بندی در طول محورهای X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **سوالات متداول**

**کدام فرمت‌های تصویر می‌توانند هنگام ذخیره‌سازی تصویر بندانگشتی شکل استفاده شوند؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/)، و دیگران. اشکال همچنین می‌توانند به‌صورت [SVG برداری خروجی گرفته شوند](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/writeassvg/) با ذخیره محتوای شکل به‌صورت SVG.

**فرق بین محدوده Shape و Appearance هنگام رندرینگ تصویر بندانگشتی چیست؟**

`Shape` از هندسه شکل استفاده می‌کند؛ `Appearance` اثرات بصری مانند [visual effects](/slides/fa/cpp/shape-effect/) (سایه‌ها، روشنایی و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود، آیا هنوز به‌صورت تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان جزو مدل می‌ماند و می‌تواند رندر شود؛ پرچم مخفی فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد و مانع تولید تصویر شکل نمی‌شود.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیای پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/) نمایش داده می‌شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartart/)) می‌تواند به‌صورت تصویر بندانگشتی یا SVG ذخیره شود.

**آیا فونت‌های نصب‌شده در سیستم بر کیفیت تصاویر بندانگشتی برای اشکال متنی تأثیر می‌گذارند؟**

بله. برای جلوگیری از استفاده ناخواسته از فونت‌های جایگزین و بازچیدمان متن باید [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/cpp/custom-font/) (یا [جایگزینی فونت‌ها را پیکره‌بندی کنید](/slides/fa/cpp/font-substitution/)).