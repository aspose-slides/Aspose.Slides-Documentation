---
title: ساخت تصویر بندانگشتی از اشکال ارائه در C++
linktitle: تصویر بندانگشتی اشکال
type: docs
weight: 70
url: /fa/cpp/shape-thumbnails/
keywords:
- تصویر بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- مرزهای بصری
- مرزهای شکل
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "ایجاد تصویر بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint با Aspose.Slides برای C++ – به‌راحتی تصویر بندانگشتی ارائه را ایجاد و صادر کنید."
---
## **معرفی**

Aspose.Slides برای ایجاد فایل‌های ارائه استفاده می‌شود که هر صفحه آن یک اسلاید است. این اسلایدها می‌توانند با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده شوند. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند تصاویر اشکال را به‌صورت جداگانه در یک نمایشگر تصویر ببینند. در چنین مواردی Aspose.Slides به شما کمک می‌کند تصاویر بندانگشتی اشکال اسلاید را تولید کنید. نحوه استفاده از این ویژگی در این مقاله توضیح داده شده است.  
این مقاله نحوه تولید بندانگشتی اسلایدها را به روش‌های مختلف شرح می‌دهد:

- تولید بندانگشتی یک شکل داخل اسلاید.  
- تولید بندانگشتی یک شکل برای یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.  
- تولید بندانگشتی یک شکل در مرزهای ظاهر شکل.

## **تولید یک بندانگشتی شکل از اسلاید**

برای تولید یک بندانگشتی شکل از هر اسلاید با استفاده از Aspose.Slides for C++:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندیس آن دریافت کنید.  
1. تصویر بندانگشتی شکل اسلاید مرجع را در مقیاس پیش‌فرض دریافت کنید.  
1. تصویر بندانگشتی را در هر قالب تصویری موردنظر ذخیره کنید.

مثال زیر یک بندانگشتی شکل تولید می‌کند.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **تولید یک بندانگشتی با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر**

برای تولید بندانگشتی شکل هر شکل اسلاید با استفاده از Aspose.Slides for C++:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندیس آن دریافت کنید.  
1. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل دریافت کنید.  
1. تصویر بندانگشتی را در هر قالب تصویری موردنظر ذخیره کنید.

مثال زیر یک بندانگشتی با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر تولید می‌کند.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // مقیاس‌گذاری در محورهاى X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **ایجاد یک بندانگشتی ظاهر شکل مبتنی بر مرزها**

این روش برای ایجاد بندانگشتی‌های اشکال به توسعه‌دهندگان اجازه می‌دهد بندانگشتی را در مرزهای ظاهر شکل تولید کنند. تمام اثرات شکل در نظر گرفته می‌شود. بندانگشتی شکل تولید شده به مرزهای اسلاید محدود می‌شود. برای تولید بندانگشتی هر شکل اسلاید در مرز ظاهر آن، از کد نمونه زیر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندیس آن دریافت کنید.  
1. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل به‌عنوان ظاهر دریافت کنید.  
1. تصویر بندانگشتی را در هر قالب تصویری موردنظر ذخیره کنید.

مثال زیر یک بندانگشتی با تنظیمات مرزهای ظاهر شکل تولید می‌کند.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // مقیاس‌گذاری در محورهاى X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **دریافت مرزهای بصری واقعی یک شکل**

خواص قاب [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) — `IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` و `IShape::get_Height()` — مستطیلی را در مدل ارائه توصیف می‌کنند. محتویات واقعی که رندر می‌شوند می‌توانند فراتر از آن قاب گسترش یابند یا مستطیل متفاوتی را اشغال کنند. چرخش، خطوط مرزی، سرهای پیکان، چیدمان متن و سرریز، هندسهٔ تولید شدهٔ SmartArt و سایر اثرات رندر می‌توانند ناحیهٔ اشغالی را تغییر دهند.

از [Shape::GetVisualBounds](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/getvisualbounds/) برای محاسبهٔ این ناحیهٔ اشغالی بدون ایجاد تصویر استفاده کنید. این روش یک شیء [RectangleF](https://reference.aspose.com/slides/fa/cpp/system.drawing/rectanglef/) در مختصات اسلاید برمی‌گرداند. مستطیل برگردانده‌شده به اسلاید کلیپ نمی‌شود، بنابراین مختصات آن می‌تواند منفی باشد وقتی محتوا فراتر از مبدأ اسلاید گسترش یابد.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/getvisualbounds/) در حال حاضر توسط رابط [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) اعلام نشده است. بنابراین، شکل به‌دست‌آمده از مجموعهٔ اشکال اسلاید را به‌عنوان یک مقدار رابط نگه داشته و فقط هنگام فراخوانی متد، آن را تبدیل کنید.

مثال زیر قاب و مرزهای بصری را دریافت و با هم مقایسه می‌کند:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

همین [RectangleF](https://reference.aspose.com/slides/fa/cpp/system.drawing/rectanglef/) می‌تواند برای تراز کردن اشکال نزدیک به لبهٔ `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` یا `RectangleF::get_Bottom()` آن استفاده شود؛ فضای کافی در یک چیدمان تولید شده محفوظ شود؛ یا محتوا خارج از ناحیهٔ مجاز شناسایی شود. مرزهای بصری به‌ویژه برای SmartArt، جعبه‌های متن، پیکان‌ها، تصاویر، اشکال چرخیده و گروه‌های شکل مفید هستند، جایی که قاب ذخیره‌شده ممکن است نتیجهٔ رندر کامل را نشان ندهد.

از [Shape::GetVisualBounds](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/getvisualbounds/) زمانی که به مختصات برای چیدمان یا اعتبارسنجی نیاز دارید و به بیت‌مپ نیازی ندارید استفاده کنید. از [IShape::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getimage/) زمانی که نیاز به رندر شکل دارید استفاده کنید. با [ShapeThumbnailBounds](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapethumbnailbounds/)، `ShapeThumbnailBounds::Shape` تصویر را از مرزهای شکل به‌همراه تنظیمات خط مرزی اندازه‌گیری می‌کند، در حالی که `ShapeThumbnailBounds::Appearance` آن را از ظاهر شکل اندازه‌گیری می‌کند و نتیجه را به مرزهای اسلاید محدود می‌سازد. در مقابل، [Shape::GetVisualBounds](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/getvisualbounds/) تنها مستطیل محاسبه‌شده را برمی‌گرداند و به اسلاید کلیپ نمی‌کند.

## **پرسش‌های متداول**

**چه فرمت‌های تصویری می‌توانند هنگام ذخیره‌سازی بندانگشتی‌های شکل استفاده شوند؟**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/)، و سایر فرمت‌ها. همچنین می‌توانید اشکال را به‌صورت [SVG برداری صادر کنید](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/writeassvg/) با ذخیرهٔ محتویات شکل به‌عنوان SVG.

**تفاوت مرزهای Shape و Appearance هنگام رندر بندانگشت چیست؟**  
`Shape` از هندسهٔ شکل استفاده می‌کند؛ `Appearance` اثرات بصری مانند سایه‌ها، درخشندگی و ... را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان hidden علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا هنوز به‌عنوان بندانگشتی رندر می‌شود؟**  
یک شکل مخفی همچنان بخشی از مدل باقی می‌ماند و می‌تواند رندر شود؛ پرچم مخفی فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد و از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**  
بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/) (از جمله [GroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/) و [SmartArt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartart/)) نمایان می‌شود می‌تواند به‌عنوان بندانگشتی یا SVG ذخیره شود.

**آیا قلم‌های نصب‌شده روی سیستم بر کیفیت بندانگشتی‌های متنی تأثیر می‌گذارند؟**  
بله. باید [قلم‌های موردنیاز را فراهم کنید](/slides/fa/cpp/custom-font/) (یا [جایگزینی قلم‌ها را تنظیم کنید](/slides/fa/cpp/font-substitution/)) تا از fallbackهای ناخواسته و بازچیدمان متن جلوگیری شود.