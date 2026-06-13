---
title: حذف اسلایدها از ارائه‌ها در C++
linktitle: حذف اسلاید
type: docs
weight: 30
url: /fa/cpp/remove-slide-from-presentation/
keywords:
- حذف اسلاید
- پاک‌کردن اسلاید
- حذف اسلاید استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "به راحتی اسلایدها را از ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ حذف کنید. مثال‌های کد واضح دریافت کنید و گردش کار خود را تقویت کنید."
---
## **مقدمه**

اگر یک اسلاید (یا محتویات آن) تکراری شد، می‌توانید آن را حذف کنید. Aspose.Slides کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را فراهم می‌کند که [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را دربر می‌گیرد، که مخزنی برای تمام اسلایدهای یک ارائه است. با استفاده از اشاره‌گرها (مرجع یا اندیس) برای یک شیء [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) شناخته‌شده، می‌توانید اسلایدی را که می‌خواهید حذف کنید، مشخص کنید. 

## **حذف اسلاید با مرجع**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلایدی که می‌خواهید حذف کنید را از طریق شناسه یا اندیس آن دریافت کنید.
1. اسلاید مرجع‌شده را از ارائه حذف کنید.
1. ارائه تغییر یافته را ذخیره کنید. 

این کد C++ نشان می‌دهد که چگونه یک اسلاید را از طریق مرجع آن حذف کنید: 

```c++
	// مسیر به پوشه اسناد
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// یک اسلاید را از طریق اندیس آن در مجموعه اسلایدها دسترسی می‌یابد
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// یک اسلاید را از طریق مرجع آن حذف می‌کند
	pres->get_Slides()->Remove(slide);

	// ارائه‌ی تغییر یافته را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **حذف اسلاید با اندیس**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. اسلاید را از ارائه از طریق موقعیت اندیس آن حذف کنید.
1. ارائه تغییر یافته را ذخیره کنید. 

این کد C++ نشان می‌دهد که چگونه یک اسلاید را از طریق اندیس آن حذف کنید: 

```c++
	// مسیر به پوشه اسناد
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// یک اسلاید را از طریق اندیس اسلاید آن حذف می‌کند
	pres->get_Slides()->RemoveAt(0);

	// ارائه‌ی تغییر یافته را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

Aspose.Slides متد [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (از کلاس [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/)) را برای حذف اسلایدهای طرح‌بندی ناخواسته و استفاده‌نشده فراهم می‌کند. این کد C++ نشان می‌دهد که چگونه یک اسلاید طرح‌بندی را از یک ارائه PowerPoint حذف کنید:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **حذف اسلایدهای مستر استفاده‌نشده**

Aspose.Slides متد [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (از کلاس [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/)) را برای حذف اسلایدهای مستر ناخواسته و استفاده‌نشده فراهم می‌کند. این کد C++ نشان می‌دهد که چگونه یک اسلاید مستر را از یک ارائه PowerPoint حذف کنید:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **سؤالات متداول**

**پس از حذف یک اسلاید، اندیس‌های اسلایدها چه اتفاقی می‌افتد؟**

بعد از حذف، [collection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidecollection/) دوباره ایندکس می‌شود: هر اسلاید بعدی یک موقعیت به سمت چپ جابجا می‌شود، بنابراین شماره‌های قبلی اندیس منسوخ می‌شوند. اگر به مرجعی پایدار نیاز دارید، به‌جای اندیس، از شناسه دائمی هر اسلاید استفاده کنید.

**آیا شناسه اسلاید با اندیس آن متفاوت است و آیا هنگام حذف اسلایدهای همجوار تغییر می‌کند؟**

بله. اندیس موقعیت اسلاید است و هنگام افزودن یا حذف اسلایدها تغییر می‌کند. شناسه اسلاید یک شناسه پایدار است و هنگام حذف اسلایدهای دیگر تغییر نمی‌کند.

**حذف یک اسلاید چگونه بر بخش‌های اسلاید اثر می‌گذارد؟**

اگر اسلاید متعلق به بخشی باشد، آن بخش فقط یک اسلاید کمتر خواهد داشت. ساختار بخش باقی می‌ماند؛ اگر بخشی خالی شد، می‌توانید [حذف یا بازسازی بخش‌ها](/slides/fa/cpp/slide-section/) را انجام دهید.

**چه اتفاقی برای یادداشت‌ها و نظراتی که به یک اسلاید پیوست شده‌اند وقتی اسلاید حذف می‌شود می‌افتد؟**

[Notes](/slides/fa/cpp/presentation-notes/) و [comments](/slides/fa/cpp/presentation-comments/) به همان اسلاید خاص مرتبط‌اند و همراه با آن حذف می‌شوند. محتویات اسلایدهای دیگر تحت تأثیر قرار نمی‌گیرد.

**حذف اسلایدها چگونه با پاک‌سازی طرح‌بندی‌ها/مسترهای استفاده‌نشده متفاوت است؟**

حذف اسلایدهای معمولی خاصی را از ارائه حذف می‌کند. پاک‌سازی طرح‌بندی‌ها/مسترهای استفاده‌نشده اسلایدهای طرح‌بندی یا مستری را که هیچ‌کسی به آن‌ها ارجاع نمی‌دهد حذف می‌کند، حجم فایل را کاهش می‌دهد بدون آنکه محتوای اسلایدهای باقی‌مانده تغییر کند. این دو عمل مکمل‌اند: معمولاً ابتدا حذف می‌کنید، سپس پاک‌سازی انجام می‌شود.