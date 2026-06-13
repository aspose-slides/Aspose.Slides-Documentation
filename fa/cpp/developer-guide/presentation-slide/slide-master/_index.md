---
title: "مدیریت اسلاید مسترهای ارائه در C++"
linktitle: "اسلاید مستر"
type: docs
weight: 80
url: /fa/cpp/slide-master/
keywords:
- "اسلاید مستر"
- "مستر اسلاید"
- "اسلاید مستر PPT"
- "چندین اسلاید مستر"
- "مقایسه اسلایدهای مستر"
- "پس‌زمینه"
- "محل‌دار"
- "کلون اسلاید مستر"
- "کپی اسلاید مستر"
- "تکثیر اسلاید مستر"
- "اسلاید مستر استفاده‌نشده"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "مدیریت اسلاید مسترها در Aspose.Slides برای C++: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

یک **slide master** تنظیمات طراحی مشترک برای گروهی از اسلایدها را تعریف می‌کند. می‌تواند شامل اشکال مشترک، لوگوها، پس‌زمینه‌ها، سبک‌های متنی، تنظیمات طرح و تنظیمات پاورقی باشد. در PowerPoint، ویرایش یک slide master راه معمول برای حفظ یکپارچگی ارائه بدون تکرار همان قالب‌بندی در هر اسلاید است.

Aspose.Slides for C++ از همان مدل پشتیبانی می‌کند. یک ارائه می‌تواند حاوی یک یا چند master slide باشد و هر master slide می‌تواند چند layout slide داشته باشد. اسلایدهای معمولاً به‌طور مستقیم به یک master slide ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک layout slide استفاده می‌کند و آن layout slide متعلق به یک master slide است.

سلسله مراتب به صورت زیر است:

1. **Slide master** – تنظیمات طراحی و طرح مشترک را تعریف می‌کند.
1. **Layout slide** – آرایش خاصی از placeholders و قالب‌بندی سطح layout را تعریف می‌کند.
1. **Normal slide** – محتوای واقعی ارائه را شامل می‌شود و از یک layout slide استفاده می‌کند.

![سلسله مراتب master slideها، layout slideها و normal slideها](slide-master_2.jpg)

در Aspose.Slides، یک slide master توسط اینترفیس [IMasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/) نمایان می‌شود. تمام master slideهای یک ارائه از طریق مجموعه [Presentation::get_Masters](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_masters/) قابل دسترسی هستند که پیاده‌سازی [IMasterSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/) را دارد.

{{% alert color="info" title="Inheritance" %}}
هنگامی که یک ویژگی در بیش از یک سطح تعریف شود، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک master slide و یک layout slide هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن layout از پس‌زمینه layout استفاده می‌کنند. برای اطلاعات بیشتر درباره layout slideها، به [Apply or Change Slide Layouts](/slides/fa/cpp/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به Slide Masterها**

در PowerPoint می‌توانید نمای Slide Master را از **View** > **Slide Master** باز کنید.

![دکمه Slide Master در برگه View در PowerPoint](slide-master_3.jpg)

در Aspose.Slides، از مجموعه `get_Masters()` برای دسترسی به master slideها استفاده کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

همچنین می‌توانید master slide استفاده شده توسط یک اسلاید معمولی را از طریق layout آن به‌دست آورید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **محتویات یک Slide Master**

یک master slide شیء‌ای شبیه اسلاید است. این شیء [IBaseSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/) را پیاده‌سازی می‌کند، بنابراین بسیاری از ویژگی‌های اسلاید که توسط اسلایدهای معمولی و layout استفاده می‌شود، در دسترس است. اعضای مخصوص master در صفحه API [IMasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/) فهرست شده‌اند.

عضوهای معمولاً استفاده‌شده master slide عبارتند از:

| Member | Purpose |
| --- | --- |
| `get_Background()` | پس‌زمینهٔ سطح master را تنظیم می‌کند. |
| `get_Shapes()` | اشکالی که روی master قرار گرفته‌اند (مانند لوگوها، فریم‌های تصویر و متن‌های مشترک) را نگه می‌دارد. |
| `get_LayoutSlides()` | layout slideهایی که به این master تعلق دارند را ذخیره می‌کند. |
| `get_ThemeManager()` | دسترسی به APIهای تم master را فراهم می‌کند. |
| `get_HeaderFooterManager()` | سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلایدها را برای master و layoutهای فرزندش کنترل می‌کند. |
| `GetDependingSlides()` | اسلایدهای معمولی که از طریق layoutهای خود به این master وابسته هستند را برمی‌گرداند. |

## **افزودن تصویر به یک Slide Master**

زمانی که تصویری را به یک master slide اضافه می‌کنید، در اسلایدهای استفاده‌کننده از layoutهای آن master ظاهر می‌شود. این ویژگی برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین master slide اضافه می‌کند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای اطلاعات بیشتر درباره فریم‌های تصویر، به [Picture Frame](/slides/fa/cpp/picture-frame/) مراجعه کنید.

## **کار با Placeholders**

Placeholders معمولاً در layout slideها تعریف می‌شوند. master slide سبک و تم مشترکی را ارائه می‌دهد که این layoutها ارث می‌برند، در حالی که هر layout تصمیم می‌گیرد کدام placeholders در دسترس هستند و در کجا قرار می‌گیرند.

در PowerPoint، دستورات placeholder در نمای Slide Master موجود است.

![دستور Insert Placeholder در نمای Slide Master PowerPoint](slide-master_5.png)

برای افزودن placeholders جدید با Aspose.Slides، با layout slideی که به master تعلق دارد کار کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

همچنین می‌توانید اشکال placeholderهایی که قبلاً در یک master slide وجود دارند را قالب‌بندی کنید. مثال زیر placeholder عنوان را یافته و پر رنگی گرادیان خطی اعمال می‌کند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Placeholder عنوان قالب‌بندی‌شده که توسط اسلایدهای معمولی ارث‌بری می‌شود](slide-master_8.png)

برای گزینه‌های بیشتر قالب‌بندی placeholder و متن، به [Set Prompt Text in Placeholder](/slides/fa/cpp/manage-placeholder/) و [Text Formatting](/slides/fa/cpp/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینهٔ Slide Master**

یک پس‌زمینهٔ master توسط layoutها و اسلایدهایی که آن را بازنویسی نمی‌کنند، ارث‌بری می‌شود. مثال زیر رنگ پس‌زمینهٔ ثابت را برای اولین master slide تنظیم می‌کند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای موضوعات مرتبط، به [Presentation Background](/slides/fa/cpp/presentation-background/) و [Presentation Theme](/slides/fa/cpp/presentation-theme/) نگاه کنید.

## **کپی کردن یک Slide Master به ارائهٔ دیگر**

از [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/addclone/) برای کپی یک master slide به ارائهٔ دیگری استفاده کنید. master کپی‌شده می‌تواند توسط layoutها و اسلایدهای مقصد استفاده شود.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

اگر نیاز دارید اسلایدهای معمولی را به همراه master آنها کلون کنید، به [Clone Slides](/slides/fa/cpp/clone-slides/) مراجعه کنید.

## **افزودن چندین Slide Master**

یک ارائه می‌تواند حاوی چندین master slide باشد. این ویژگی زمانی مفید است که بخش‌های مختلف نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی داشته باشند.

![دستورات PowerPoint برای درج و مدیریت master slideها](slide-master_9.jpg)

مثال زیر master پیش‌فرض را کلون می‌کند، پس‌زمینهٔ متفاوتی به کلون می‌دهد، یک layout تحت آن master کلون شده ایجاد می‌کند و اسلاید جدیدی بر پایهٔ آن layout اضافه می‌کند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **مقایسه Slide Masterها**

Slide Masterها می‌توانند با متد `Equals` که از [IBaseSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/) ارث‌بری شده است، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های منحصر به فرد مانند slide IDها یا مقادیر پویا در placeholders (مانند تاریخ فعلی) در مقایسه در نظر گرفته نمی‌شوند.

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

برای اطلاعات بیشتر، به [Compare Presentation Slides](/slides/fa/cpp/compare-slides/) مراجعه کنید.

## **تنظیم نمای Slide Master به‌عنوان نمای پیش‌فرض**

از متد `set_LastView` در [ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای تنظیمات بیشتر نمای، به [Save Presentation](/slides/fa/cpp/save-presentation/) نگاهی بیندازید.

## **حذف Master Slideهای استفاده‌نشده**

گاهی ارائه‌ها شامل master slideهایی می‌شوند که دیگر توسط هیچ اسلایدی استفاده نمی‌شوند. حذف masterهای استفاده‌نشده می‌تواند اندازهٔ فایل را کاهش داده و نگهداری قالب را ساده‌تر کند.

از [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/fa/cpp/aspose.slides/masterslidecollection/removeunused/) برای حذف masterهای استفاده‌نشده از مجموعه `get_Masters()` استفاده کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

همچنین می‌توانید از متد کم‌کد [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) استفاده کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

**تفاوت بین یک slide master و یک layout slide چیست؟**

یک slide master تنظیمات طراحی مشترک مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متن را تعریف می‌کند. یک layout slide متعلق به یک master slide است و آرایش خاصی از placeholders را تعریف می‌کند. یک اسلاید معمولی از یک layout slide استفاده می‌کند، بنابراین هم از layout و هم از master ارث می‌برد.

**آیا یک ارائه می‌تواند چندین slide master داشته باشد؟**

بله. یک ارائه می‌تواند چندین slide master داشته باشد. زمانی که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوتی دارند، از چندین master استفاده کنید.

**آیا باید placeholders را به یک master slide یا یک layout slide اضافه کنم؟**

در بیشتر موارد، placeholders را به layout slideها اضافه کنید. عناصر بصری مشترک و قالب‌بندی مشترک را روی master slide قرار دهید و placeholders محتوا را روی layoutهایی که اسلایدهای معمولی استفاده می‌کنند، بگذارید.

**آیا می‌توانم یک master slide که هنوز استفاده می‌شود را حذف کنم؟**

نه. یک master slide که اسلایدهای وابسته دارد را نمی‌توان به‌صورت مستقیم حذف کرد. ابتدا آن اسلایدها را به layoutهای تحت master دیگری منتقل کنید یا از روش پاک‌سازی masterهای استفاده‌نشده استفاده کنید که فقط masterهای بدون استفاده را حذف می‌کند.