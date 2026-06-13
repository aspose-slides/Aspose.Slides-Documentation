---
title: دسترسی به اسلایدهای ارائه در C++
linktitle: دسترسی به اسلاید
type: docs
weight: 20
url: /fa/cpp/access-slide-in-presentation/
keywords:
- دسترسی به اسلاید
- شاخص اسلاید
- شناسه اسلاید
- موقعیت اسلاید
- تغییر موقعیت
- ویژگی‌های اسلاید
- شماره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اسلایدها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ دسترسی و مدیریت کنید. با مثال‌های کد، بهره‌وری را افزایش دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه اسلایدها را در یک ارائه با استفاده از Aspose.Slides دسترسی و مدیریت کنید. نشان می‌دهد چگونه اسلایدها را بر اساس شاخص صفرپایه از مجموعه اسلایدها بازیابی کنید و چگونه با استفاده از متد `GetSlideById` یک اسلاید را بر اساس شناسه منحصر به فرد آن دسترسی پیدا کنید.

همچنین یاد خواهید گرفت چگونه موقعیت یک اسلاید را با استفاده از متد `set_SlideNumber` تغییر دهید و چگونه شماره اسلاید آغازین یک ارائه را با استفاده از متد `set_FirstSlideNumber` تعریف کنید. مثال‌ها بارگذاری یک ارائه، دریافت مراجع اسلاید، به‌روزرسانی ترتیب یا شماره‌گذاری اسلایدها و ذخیره ارائه اصلاح‌شده را نشان می‌دهند.

## **دسترسی به اسلاید بر اساس شاخص**

تمام اسلایدهای یک ارائه به صورت عددی بر اساس موقعیت اسلاید، از صفر شروع می‌شوند. اسلاید اول از طریق شاخص 0 قابل دسترسی است؛ اسلاید دوم از طریق شاخص 1؛ و غیره.

کلاس Presentation که نمایانگر یک فایل ارائه است، تمام اسلایدها را به عنوان یک مجموعه [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) (مجموعه‌ای از اشیاء [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) ) در دسترس قرار می‌دهد. این کد C++ نشان می‌دهد چگونه از طریق شاخص به یک اسلاید دسترسی پیدا کنید:

```c++
	// مسیر به دایرکتوری اسناد.
	// یک نمونه از کلاس Presentation را ایجاد می‌کند
	// دریافت مرجع اسلاید از طریق شاخص آن
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **دسترسی به اسلاید بر اساس شناسه**

هر اسلاید در یک ارائه دارای یک شناسه منحصر به فرد است. می‌توانید با استفاده از متد [GetSlideById()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/getslidebyid/) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ارائه می‌شود) به آن شناسه هدف برسید. این کد C++ نشان می‌دهد چگونه یک شناسه معتبر ارائه دهید و از طریق متد [GetSlideById()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/getslidebyid/) به اسلاید دسترسی پیدا کنید:

```c++
	// مسیر به دایرکتوری اسناد.
	const String templatePath = u"../templates/AddSlides.pptx";

	// یک نمونه از کلاس Presentation را ایجاد می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// دریافت شناسه اسلاید
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// دسترسی به اسلاید از طریق شناسه‌اش
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **تغییر موقعیت اسلاید**

Aspose.Slides به شما امکان تغییر موقعیت یک اسلاید را می‌دهد. برای مثال می‌توانید تعیین کنید اسلاید اول به اسلاید دوم تبدیل شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلایدی که می‌خواهید موقعیت آن را تغییر دهید از طریق شاخص آن دریافت کنید.
1. موقعیت جدید را برای اسلاید از طریق ویژگی [set_SlideNumber()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/set_slidenumber/) تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

این کد C++ عملی را نشان می‌دهد که در آن اسلاید در موقعیت 1 به موقعیت 2 منتقل می‌شود:

```c++
	// مسیر به دایرکتوری اسناد.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// یک نمونه از کلاس Presentation را ایجاد می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// دریافت اسلایدی که موقعیت آن تغییر خواهد کرد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// تنظیم موقعیت جدید برای اسلاید
	slide->set_SlideNumber(2);

	// ذخیره ارائه‌ی اصلاح‌شده
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

اسلاید اول به اسلاید دوم تبدیل شد؛ اسلاید دوم به اسلاید اول. وقتی موقعیت یک اسلاید را تغییر می‌دهید، سایر اسلایدها به‌صورت خودکار تنظیم می‌شوند.

## **تنظیم شماره اسلاید**

با استفاده از ویژگی [set_FirstSlideNumber()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/set_firstslidenumber/) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ارائه می‌شود) می‌توانید شماره جدیدی برای اسلاید اول در یک ارائه تعیین کنید. این عمل باعث می‌شود شماره‌های سایر اسلایدها دوباره محاسبه شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. شماره اسلاید را دریافت کنید.
1. شماره اسلاید را تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

این کد C++ عملی را نشان می‌دهد که در آن شماره اسلاید اول به 10 تنظیم می‌شود:

```c++
	// مسیر به دایرکتوری اسناد.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//یک نمونه از کلاس Presentation را ایجاد می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// دریافت شماره اسلاید
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// تنظیم شماره اسلاید
	pres->set_FirstSlideNumber(2);
	
	// ذخیره ارائه‌ی اصلاح‌شده
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

اگر مایل باشید اسلاید اول را نادیده بگیرید، می‌توانید شماره‌گذاری را از اسلاید دوم آغاز کنید (و برای اسلاید اول شماره‌گذاری را مخفی کنید) به این شکل:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **سؤال‌های متداول**

**آیا شماره اسلایدی که کاربر می‌بیند با شاخص صفرپایهٔ مجموعه مطابقت دارد؟**

عدد نمایش داده شده بر روی اسلاید می‌تواند از مقدار دلخواهی (مثلاً 10) شروع شود و لزوماً با شاخص مطابقت ندارد؛ این رابطه توسط تنظیم «شماره اسلاید اول» ارائه کنترل می‌شود.

**آیا اسلایدهای مخفی بر شاخص‌بندی تأثیر می‌گذارند؟**

بله. یک اسلاید مخفی در مجموعه باقی می‌ماند و در شاخص‌بندی شمرده می‌شود؛ «مخفی» فقط به نمایش اشاره دارد، نه به موقعیت آن در مجموعه.

**آیا شاخص یک اسلاید وقتی اسلایدهای دیگر اضافه یا حذف می‌شوند تغییر می‌کند؟**

بله. شاخص‌ها همیشه وضعیت جاری ترتیب اسلایدها را نشان می‌دهند و پس از عملیات درج، حذف یا جابه‌جایی دوباره محاسبه می‌شوند.