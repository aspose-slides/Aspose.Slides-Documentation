---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در C++
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/cpp/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- توزیع
- یادداشت
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "از Aspose.Slides برای C++ برای افزودن و تنظیم سفارشی سرصفحه‌ها و پاورقی‌ها در ارائه‌های PowerPoint و OpenDocument استفاده کنید تا ظاهر حرفه‌ای داشته باشید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان مدیریت تنظیمات سرصفحه و پاورقی را در ارائه‌های PowerPoint می‌دهد. سرصفحه‌ها و پاورقی‌ها در سطح مستر ارائه مدیریت می‌شوند و API متدهایی برای تنظیم متن پاورقی، تغییر قابلیت نمایش پاورقی و به‌روزرسانی متن سرصفحه در اسلایدهای مستر یادداشت فراهم می‌کند.

شما همچنین می‌توانید سرصفحه‌ها و پاورقی‌ها را برای اسلایدهای توزیع و یادداشت مدیریت کنید. این شامل تغییر قابلیت نمایش و متن جای‌دارهای سرصفحه، پاورقی، شماره اسلاید و تاریخ‑زمان برای مستر یادداشت، تمام اسلایدهای فرزند یادداشت یا یک اسلاید یادداشت خاص می‌شود.

## **مدیریت متن سرصفحه و پاورقی**

نکات برخی اسلایدهای خاص می‌توانند همانند مثال زیر به‌روزرسانی شوند:

``` cpp
// تابع برای تنظیم متن سرصفحه/پاورقی
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// بارگذاری ارائه
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// تنظیم پاورقی
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// دسترسی و به‌روزرسانی سرصفحه
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// ذخیره ارائه
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **مدیریت سرصفحه‌ها و پاورقی‌ها در اسلایدهای توزیع و یادداشت**
Aspose.Slides for C++ از سرصفحه و پاورقی در اسلایدهای توزیع و یادداشت پشتیبانی می‌کند. لطفاً مراحل زیر را دنبال کنید:

- یک [Presentation ](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) حاوی ویدیو را بارگذاری کنید.
- تنظیمات سرصفحه و پاورقی را برای مستر یادداشت و تمام اسلایدهای یادداشت تغییر دهید.
- قابلیت نمایش محل‌نگهدارنده‌های پاورقی را در اسلاید مستر یادداشت و تمام فرزندان آن فعال کنید.
- قابلیت نمایش محل‌نگهدارنده‌های تاریخ و زمان را در اسلاید مستر یادداشت و تمام فرزندان آن فعال کنید.
- تنظیمات سرصفحه و پاورقی را فقط برای اولین اسلاید یادداشت تغییر دهید.
- قابلیت نمایش محل‌نگهدارندهٔ سرصفحه در اسلاید یادداشت را فعال کنید.
- متن را برای محل‌نگهدارندهٔ سرصفحه اسلاید یادداشت تنظیم کنید.
- متن را برای محل‌نگهدارندهٔ تاریخ‑زمان اسلاید یادداشت تنظیم کنید.
- فایل ارائهٔ اصلاح‌شده را بنویسید.

کد نمونه در مثال زیر ارائه شده است.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// تغییر تنظیمات سرصفحه و پاورقی برای مستر یادداشت و تمام اسلایدهای یادداشت
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// قابل مشاهده کردن اسلاید یادداشت مستر و تمام جای‌دارهای پاورقی فرزند
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// قابل مشاهده کردن اسلاید یادداشت مستر و تمام جای‌دارهای سرصفحه فرزند
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// قابل مشاهده کردن اسلاید یادداشت مستر و تمام جای‌دارهای شماره اسلاید فرزند
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// قابل مشاهده کردن اسلاید یادداشت مستر و تمام جای‌دارهای تاریخ و زمان فرزند
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// تنظیم متن برای اسلاید یادداشت مستر و تمام جای‌دارهای سرصفحه فرزند
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// تنظیم متن برای اسلاید یادداشت مستر و تمام جای‌دارهای پاورقی فرزند
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// تنظیم متن برای اسلاید یادداشت مستر و تمام جای‌دارهای تاریخ و زمان فرزند
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// تغییر تنظیمات سرصفحه و پاورقی فقط برای اولین اسلاید یادداشت
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// قابل مشاهده کردن جای‌دار سرصفحه این اسلاید یادداشت
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// قابل مشاهده کردن جای‌دار پاورقی این اسلاید یادداشت
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// قابل مشاهده کردن جای‌دار شماره اسلاید این اسلاید یادداشت
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// قابل مشاهده کردن جای‌دار تاریخ‑زمان این اسلاید یادداشت
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// تنظیم متن برای جای‌دار سرصفحه اسلاید یادداشت
	headerFooterManager->SetHeaderText(u"New header text");
	// تنظیم متن برای جای‌دار پاورقی اسلاید یادداشت
	headerFooterManager->SetFooterText(u"New footer text");
	// تنظیم متن برای جای‌دار تاریخ‑زمان اسلاید یادداشت
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **پرسش‌های متداول**

**آیا می‌توانم "سرصفحه" را به اسلایدهای عادی اضافه کنم؟**

در PowerPoint، "سرصفحه" تنها برای یادداشت‌ها و توزیع‌ها وجود دارد؛ در اسلایدهای عادی، عناصر پشتیبانی‌شده پاورقی، تاریخ/زمان و شماره اسلاید هستند. در Aspose.Slides این محدودیت‌ها همان‌گونه است: سرصفحه فقط برای یادداشت/توزیع و در اسلایدها—پاورقی/DateTime/SlideNumber.

**اگر طرح‌بندی ناحیهٔ پاورقی نداشته باشد—آیا می‌توانم قابلیت نمایش آن را "فعال" کنم؟**

بله. از طریق مدیر سرصفحه/پاورقی قابلیت نمایش را بررسی کنید و در صورت نیاز آن را فعال کنید. این نشانگرها و متدهای API برای موقعیت‌هایی که جای‌دار موجود نیست یا مخفی است طراحی شده‌اند.

**چگونه می‌توانم شماره اسلاید را از مقداری غیر از 1 شروع کنم؟**

عدد اولین اسلاید ارائه را با استفاده از متد [first slide number](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/set_firstslidenumber/) تنظیم کنید؛ پس از آن تمام شماره‌گذاری‌ها بازمحاسبه می‌شوند. به‌عنوان مثال می‌توانید از 0 یا 10 شروع کنید و شماره را در اسلاید عنوان مخفی کنید.

**در هنگام خروجی گرفتن به PDF/تصاویر/HTML چه اتفاقی برای سرصفحه‌ها/پاورقی‌ها می‌افتد؟**

آنها به عنوان عناصر متنی معمولی در ارائه رندر می‌شوند. به این معنی که اگر این عناصر در اسلایدها/صفحات یادداشت قابل مشاهده باشند، در قالب خروجی نیز همراه با بقیه محتوا ظاهر می‌شوند.