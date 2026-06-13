---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در C++
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/cpp/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- نمادهای طرح کلی
- قفل‌کردن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای C++ را کشف کنید تا فرمت‌های اسلایدهای PPT، PPTX و ODP را سفارشی‌سازی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم کنید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود، ناحیه محتوا کناری، و ناحیه محتوا پایین. خصوصیت‌هایی که به موقعیت نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد تا وضعیت نمای خود را در فایل ذخیره کند، به‌طوری‌که هنگام بازگشایی، نما در همان وضعیتی باشد که هنگام آخرین ذخیره‌سازی ارائه بود.

متد [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) اضافه شده است تا دسترسی به خصوصیات نمای عادی ارائه را فراهم کند.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inormalviewproperties/)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inormalviewrestoredproperties/) و فرزندهای آن، و شمارشگر [SplitterBarStateType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/splitterbarstatetype/) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش‌دهندهٔ خصوصیات نمای عادی است.

ویژگی **ShowOutlineIcons** مشخص می‌کند که آیا برنامه باید نمادها را هنگام نمایش محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای عادی نشان دهد یا نه.

ویژگی **SnapVerticalSplitter** تعیین می‌کند که آیا تقسیم‌کنندهٔ عمودی باید هنگام کوچک بودن کافی ناحیهٔ کناری به حالت حداقل برگردد یا نه.

ویژگی **PreferSingleView** مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیهٔ محتوای تک‌پنجرهٔ تمام‑صفحه را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. اگر فعال باشد، برنامه ممکن است یک ناحیه محتوا را در تمام پنجره نمایش دهد.

ویژگی‌های **VerticalBarState** و **HorizontalBarState** حالت نمایش نوار تقسیم‌کنندهٔ افقی یا عمودی را تعیین می‌کنند. نوار تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوا زیر اسلاید جدا می‌کند، نوار تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوای کناری جدا می‌کند. مقادیر ممکن عبارتند از: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

ویژگی‌های **RestoredLeft** و **RestoredTop** اندازهٔ ناحیهٔ اسلاید بالایی یا کناری را در نمای عادی مشخص می‌کنند، زمانی که مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌طور متقابل اعمال شده باشد.

## **درباره بازگرداندن INormalViewProperties**

اندازهٔ ناحیهٔ اسلاید (عرض وقتی فرزند RestoredTop باشد، ارتفاع وقتی فرزند RestoredLeft باشد) را در نمای عادی هنگام داشتن اندازهٔ متغیر بازیابی‌شده (نه حداقل و نه حداکثر) مشخص می‌کند.

ویژگی **DimensionSize** اندازهٔ ناحیهٔ اسلاید (عرض وقتی فرزند restoredTop باشد، ارتفاع وقتی فرزند restoredLeft باشد) را مشخص می‌کند.

ویژگی **AutoAdjust** مشخص می‌کند که آیا اندازهٔ ناحیهٔ محتوای کناری باید برای اندازهٔ جدید جبران کند هنگام تغییر اندازهٔ پنجرهٔ حاوی نما در برنامه.

در مثال زیر نشان داده می‌شود که چگونه می‌توانید به ویژگی‌های **ViewProperties.NormalViewProperties** برای یک ارائه دسترسی پیدا کنید.

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// بازگرداندن ویژگی‌های نمای ارائه
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **تنظیم مقدار بزرگنمایی پیش‌فرض**

Aspose.Slides برای C++ هم‌اکنون از تنظیم مقدار بزرگنمایی پیش‌فرض برای ارائه پشتیبانی می‌کند به‌طوری‌که هنگام باز کردن ارائه، بزرگنمایی از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) یک ارائه انجام شود. ویژگی‌های نمای اسلاید و همچنین [get_NotesViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_notesviewproperties/) می‌توانند به‌صورت برنامه‌ای تنظیم شوند. در این موضوع، با یک مثال می‌بینیم چگونه ویژگی‌های نمای یک ارائه را در Aspose.Slides تنظیم کنیم.

برای تنظیم ویژگی‌های نمای، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید
1. ویژگی‌های [ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) ارائه را تنظیم کنید
1. ارائه را به عنوان فایل PPTX ذخیره کنید

در مثال زیر، مقدار بزرگنمایی برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// تنظیم ویژگی‌های نمای ارائه
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // مقدار بزرگنمایی به درصد برای نمای اسلاید
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // مقدار بزرگنمایی به درصد برای نمای یادداشت‌ها 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعیین کنم؟**

[View settings](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_slideviewproperties/))، نه برای هر بخش. بنابراین یک مجموعهٔ پارامتر برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم وضعیت‌های نمای متفاوتی را برای کاربران مختلف از پیش تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک گذاشته می‌شوند. برنامه‌های نمایش ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمای پیش‌تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. از آنجایی که [view properties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در قالبی تعبیه کنید و اسناد جدید را از آن با همان پیکربندی اولیهٔ نمای ایجاد کنید.