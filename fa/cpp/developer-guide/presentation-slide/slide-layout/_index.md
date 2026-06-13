---
title: اعمال یا تغییر طرح اسلاید در C++
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/cpp/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- محفظه
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- قابلیت نمایش پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با کپشن
- عکس با کپشن
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "مدیریت و سفارشی‌سازی طرح‌های اسلاید در Aspose.Slides برای C++. انواع طرح‌ها، کنترل محفظه‌ها و قابلیت نمایش پاورقی را از طریق مثال‌های کد C++ بررسی کنید."
---
## **معرفی**

یک طرح اسلاید چیدمان جعبه‌های محفظه و قالب‌بندی محتوا را در یک اسلاید تعریف می‌کند. این طرح تعیین می‌کند که چه محفظه‌هایی در دسترس هستند و کجا ظاهر می‌شوند. طرح‌های اسلاید به شما کمک می‌کنند تا ارائه‌ها را به‌سرعت و به‌صورت یکنواخت طراحی کنید—چه در حال ساخت یک ارائه ساده باشید و چه پیچیده. برخی از رایج‌ترین طرح‌های اسلاید در PowerPoint عبارتند از:

**Title Slide layout** – شامل دو محفظه متنی است: یکی برای عنوان و دیگری برای زیرعنوان.

**Title and Content layout** – یک محفظه عنوان کوچک‌تر در بالا دارد و یک محفظه بزرگ‌تر در زیر برای محتوای اصلی (مانند متن، نکات گلوله‌ای، نمودارها، تصاویر و غیره).

**Blank layout** – هیچ محفظه‌ای ندارد و به شما کنترل کامل برای طراحی اسلاید از ابتدا می‌دهد.

طرح‌های اسلاید بخشی از یک اسلاید مستر هستند که اسلاید سطح بالایی است و سبک‌های طرح را برای ارائه تعریف می‌کند. می‌توانید اسلایدهای طرح را از طریق اسلاید مستر دسترسی داشته و اصلاح کنید—چه با نوع، نام یا شناسهٔ یکتا. به‌علاوه می‌توانید یک اسلاید طرح خاص را مستقیماً داخل ارائه ویرایش کنید.

برای کار با طرح‌های اسلاید در Aspose.Slides for Android می‌توانید از:

- متدهایی مانند [get_LayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_layoutslides/) و [get_Masters](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_masters/) زیر کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/)
- انواعی مانند [ILayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/)، [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterlayoutslidecollection/)، [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/)، و [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
برای یادگیری بیشتر دربارهٔ کار با اسلایدهای مستر، مقالهٔ [Slide Master](/slides/fa/cpp/slide-master/) را بررسی کنید.
{{% /alert %}}

## **افزودن طرح اسلایدها به ارائه‌ها**

برای سفارشی‌سازی ظاهر و ساختار اسلایدهای خود ممکن است نیاز داشته باشید طرح اسلاید جدیدی به ارائه اضافه کنید. Aspose.Slides for Android به شما اجازه می‌دهد بررسی کنید آیا یک طرح خاص از پیش وجود دارد یا نه، در صورت نیاز اضافه کنید و از آن برای درج اسلاید بر پایهٔ همان طرح استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. به [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterlayoutslidecollection/) دسترسی پیدا کنید.
1. بررسی کنید آیا اسلاید طرح موردنظر در مجموعه وجود دارد یا خیر. در صورت عدم وجود، اسلاید طرح مورد نیاز را اضافه کنید.
1. یک اسلاید خالی بر پایهٔ اسلاید طرح جدید اضافه کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نحوه افزودن یک طرح اسلاید به یک ارائه PowerPoint را نشان می‌دهد:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint است.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // وضعیتی که در آن ارائه تمام انواع طرح‌ها را شامل نمی‌شود.
    // فایل ارائه فقط شامل انواع طرح Blank و Custom است.
    // اما اسلایدهای طرح با انواع سفارشی ممکن است نام‌های قابل تشخیص داشته باشند،
    // مانند "Title"، "Title and Content" و غیره که می‌توانند برای انتخاب اسلاید طرح استفاده شوند.
    // همچنین می‌توانید به مجموعه‌ای از انواع شکل‌های محفظه تکیه کنید.
    // برای مثال، یک اسلاید Title باید فقط نوع محفظه Title را داشته باشد و به همین ترتیب.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// افزودن اسلاید خالی با استفاده از اسلاید طرح اضافه‌شده.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// ذخیرهٔ ارائه در دیسک.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **حذف طرح‌های اسلاید استفاده‌نشده**

Aspose.Slides متد [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) را از کلاس [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) ارائه می‌دهد تا بتوانید طرح‌های اسلاید ناخواسته و استفاده‌نشده را حذف کنید.

کد C++ زیر نشان می‌دهد چگونه یک طرح اسلاید را از یک ارائه PowerPoint حذف کنید:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **افزودن محفظه‌ها به طرح اسلایدها**

Aspose.Slides متد [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) را فراهم می‌کند که امکان افزودن محفظه‌های جدید به یک اسلاید طرح را می‌دهد.

این مدیر شامل متدهایی برای انواع محفظه‌های زیر است:

| محفظه PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/) متد |
| ---------------- | ------------------------------------------------------------ |
| ![محتوا](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![محتوا (عمودی)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![متن](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![متن (عمودی)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![عکس](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![نمودار](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![جدول](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![رسانه](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![تصویر آنلاین](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

کد C++ زیر نحوه افزودن اشکال محفظهٔ جدید به اسلاید طرح Blank را نشان می‌دهد:

```cpp
auto presentation = MakeObject<Presentation>();

// دریافت اسلاید طرح Blank.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// دریافت مدیر محفظهٔ اسلاید طرح.
auto placeholderManager = layout->get_PlaceholderManager();

// افزودن محفظه‌های مختلف به اسلاید طرح Blank.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// افزودن اسلاید جدید با طرح Blank.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![محفظه‌های موجود بر روی اسلاید طرح](add_placeholders.png)

## **تنظیم نمایش پاورقی برای یک اسلاید طرح**

در ارائه‌های PowerPoint، عناصر پاورقی مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند بسته به طرح اسلاید نمایش داده یا مخفی شوند. Aspose.Slides for Android به شما اجازه می‌دهد نمایش این محفظه‌های پاورقی را کنترل کنید. این ویژگی زمانی مفید است که بخواهید برخی طرح‌ها اطلاعات پاورقی را نشان دهند در حالی که دیگران تمیز و ساده بمانند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید طرح را بر اساس اندیس آن دریافت کنید.
1. محفظهٔ پاورقی اسلاید را به حالت قابل مشاهده تنظیم کنید.
1. محفظهٔ شماره اسلاید را به حالت قابل مشاهده تنظیم کنید.
1. محفظهٔ تاریخ‑زمان را به حالت قابل مشاهده تنظیم کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه نمایش پاورقی اسلاید را تنظیم کنید و کارهای مرتبط را انجام دهید:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم نمایش پاورقی فرزند برای یک اسلاید**

در ارائه‌های PowerPoint، عناصر پاورقی مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند در سطح اسلاید مستر کنترل شوند تا اطمینان حاصل شود تمام اسلایدهای طرح به‌صورت یکسان این اطلاعات را دارند. Aspose.Slides for Android این امکان را می‌دهد که نمایش و محتوی این محفظه‌های پاورقی را در اسلاید مستر تنظیم کنید و این تنظیمات به همهٔ اسلایدهای طرح فرزند منتقل شود. این رویکرد اطلاعات پاورقی یکنواختی در سراسر ارائه شما فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید مستر را بر اساس اندیس آن دریافت کنید.
1. تمام محفظه‌های پاورقی مستر و فرزندان را به حالت قابل مشاهده تنظیم کنید.
1. تمام محفظه‌های شماره اسلاید مستر و فرزندان را به حالت قابل مشاهده تنظیم کنید.
1. تمام محفظه‌های تاریخ‑زمان مستر و فرزندان را به حالت قابل مشاهده تنظیم کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر این عملیات را نشان می‌دهد:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پرسش‌های متداول**

**تفاوت بین اسلاید مستر و اسلاید طرح چیست؟**

اسلاید مستر تم کلی و قالب‌بندی پیش‌فرض را تعریف می‌کند، در حالی که اسلایدهای طرح چیدمان‌های خاصی از محفظه‌ها را برای انواع مختلف محتوا تعیین می‌کنند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله، می‌توانید یک اسلاید طرح را از مجموعهٔ اسلایدهای طرح یک ارائه با استفاده از متد [get_LayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_layoutslides/) کلون کنید و با استفاده از متد `AddClone` آن را در ارائهٔ دیگر وارد کنید.

**اگر یک اسلاید طرح که هنوز توسط اسلایدی استفاده می‌شود را حذف کنم چه اتفاقی می‌افتد؟**

اگر سعی کنید یک اسلاید طرح را حذف کنید که توسط حداقل یک اسلاید در ارائه هنوز ارجاع داده شده است، Aspose.Slides استثنای [PptxEditException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxeditexception/) را پرتاب می‌کند. برای جلوگیری از این مشکل، از متد [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) استفاده کنید که به‌صورت ایمن فقط طرح‌های اسلایدی که استفاده نمی‌شوند را حذف می‌کند.