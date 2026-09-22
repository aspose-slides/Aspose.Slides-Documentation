---
title: بازیابی و به‌روزرسانی ویژگی‌های نمای ارائه در Python
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/python-net/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای معمولی
- محتوای طرح کلی
- آیکن‌های طرح کلی
- چسباندن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه‌گیری ابعاد
- تنظیم خودکار
- بزرگ‌نمایی پیش‌فرض
- پاورپوینت
- ارائه
- Python
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای Python via .NET را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح بزرگ‌نمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای معمولی شامل سه ناحیه محتوا است: اسلاید خود، ناحیه محتوی جانبی و ناحیه محتوای پایین. ویژگی‌هایی که به موقعیت‌گذاری نواحی مختلف محتوا مربوط می‌شود. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند تا هنگام بازگشت، نمای برنامه در همان وضعیتی باشد که هنگام آخرین ذخیره‌سازی ارائه بود.

ویژگی [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/normal_view_properties/) برای دسترسی به ویژگی‌های نمای معمولی ارائه افزوده شده است.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/normalviewproperties/)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/normalviewrestoredproperties/) و زیردسته‌های آنها و شمارشگر [SplitterBarStateType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/splitterbarstatetype/) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش‌دهندهٔ ویژگی‌های نمای معمولی است.

ویژگی **ShowOutlineIcons** مشخص می‌کند که آیا برنامه هنگام نمایش محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای معمولی باید آیکن‌ها را نشان دهد یا نه.

ویژگی **SnapVerticalSplitter** تعیین می‌کند که آیا تقسیم‌کننده عمودی باید هنگام کوچک شدن کافی ناحیهٔ جانبی به حالت کمینه برگردد یا نه.

ویژگی **PreferSingleView** مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیهٔ محتوا را در کل پنجره به‌جای نمای معمولی استاندارد با سه ناحیه محتوا ببیند. اگر فعال باشد، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نشان دهد.

ویژگی‌های **VerticalBarState** و **HorizontalBarState** وضعیت نمایش نوار تقسیم‌کنندهٔ عمودی یا افقی را تعیین می‌کنند. یک نوار تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوا زیر اسلاید جدا می‌کند، در حالی که نوار تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوا جانبی جدا می‌کند. مقادیر ممکن عبارتند از: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

ویژگی‌های **RestoredLeft** و **RestoredTop** اندازه‌گیری ناحیهٔ بالایی یا جانبی اسلاید در نمای معمولی را مشخص می‌کنند، زمانی که مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌طور متقابل اعمال شده باشد.

## **درباره بازگرداندن INormalViewProperties**

اندازه‌گیری ناحیهٔ اسلاید (عرض هنگامی که فرزند RestoredTop باشد، ارتفاع هنگامی که فرزند RestoredLeft باشد) در نمای معمولی را تعیین می‌کند، وقتی که ناحیه دارای اندازهٔ متغیر بازگردانده‌شده (نه کمینه و نه بیشینه) باشد.

ویژگی **DimensionSize** اندازهٔ ناحیهٔ اسلاید (عرض وقتی که فرزند restoredTop باشد، ارتفاع وقتی که فرزند restoredLeft باشد) را مشخص می‌کند.

ویژگی **AutoAdjust** تعیین می‌کند که آیا اندازهٔ ناحیهٔ محتوا جانبی باید برای اندازهٔ جدید هنگام تغییر اندازهٔ پنجره حاوی نما در برنامه جبران شود یا نه.

مثالی که در زیر ارائه شده است نشان می‌دهد چگونه می‌توانید به ویژگی‌های **ViewProperties.NormalViewProperties** برای یک ارائه دسترسی پیدا کنید.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # بازگرداندن ویژگی‌های نمای ارائه
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم مقدار بزرگ‌نمایی پیش‌فرض**

Aspose.Slides برای Python via .NET اکنون از تنظیم مقدار بزرگ‌نمایی پیش‌فرض برای ارائه پشتیبانی می‌کند تا وقتی ارائه باز می‌شود، بزرگ‌نمایی پیشاپیش تنظیم شده باشد. این می‌تواند با تنظیم [view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) یک ارائه انجام شود. ویژگی‌های نمای اسلاید و همچنین [notes_view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/notes_view_properties/) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این بخش، با مثال می‌بینیم چگونه ویژگی‌های نمای یک ارائه را در Aspose.Slides تنظیم کنیم.

برای تنظیم ویژگی‌های نمای، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید
1. [view properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/) ارائه را تنظیم کنید
1. ارائه را به‌صورت فایل PPTX بنویسید

در مثال زیر، مقدار بزرگ‌نمایی برای نمای اسلاید و نمای یادداشت‌ها تنظیم شده است.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # تنظیم ویژگی‌های نمای ارائه
    presentation.view_properties.slide_view_properties.scale = 100 # مقدار بزرگ‌نمایی به درصد برای نمای اسلاید
    presentation.view_properties.notes_view_properties.scale = 100 # مقدار بزرگ‌نمایی به درصد برای نمای یادداشت‌ها 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم فاصله‌بندی شبکه**

از [Presentation.view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. ویژگی [ViewProperties.grid_spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/grid_spacing/) فاصلهٔ شبکهٔ ویرایشی زیرین را می‌خواند یا تغییر می‌دهد. این تنظیم برای کل ارائه اعمال می‌شود، نه برای یک اسلاید منفرد. فاصله‌بندی شبکه بر حسب نقطه تعریف می‌شود به‌طوری که ۷۲ نقطه برابر یک اینچ است. از مقدار مثبت استفاده کنید، همان‌طور که مستندات API خواستار آن است.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ شبکهٔ فعلی را چاپ می‌کند، فاصلهٔ یک‌چهارم اینچ را تنظیم می‌کند و نتیجه را ذخیره می‌کند.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

شبکه متفاوت از [drawing guides](/slides/fa/python-net/drawing-guides/) است. فاصله‌بندی شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمای‌های کشیده‌شده خطوط افقی یا عمودی موقعیت‌یابی شده به‌صورت جداگانه هستند. افزودن، جابه‌جایی یا پاک‌کردن راهنمای‌های کشیده‌شده، فاصلهٔ شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنمای‌های کشیده‌شده، ابزارهای کمکی ویرایشی هستند. آنها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیرهٔ فاصلهٔ شبکه تضمین نمی‌کند که ویرایشگر آن را نشان دهد: نمایش آن همچنین به تنظیمات نمایشگر یا ویرایشگر بستگی دارد.

## **پرسش‌های متداول**

**چرا پس از باز کردن مجدد ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر تعیین می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا پاک‌کردن راهنمای‌های کشیده‌شده فاصلهٔ شبکه را تغییر می‌دهد؟**

نه. راهنمای‌های کشیده‌شده و فاصلهٔ شبکه تنظیمات مستقلی هستند. پاک‌کردن راهنماها فاصلهٔ ذخیره‌شدهٔ شبکه را دست نخورده می‌گذارد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف ارائه داشته باشم؟**

[View settings](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/slide_view_properties/))، نه برای هر بخش؛ بنابراین یک مجموعهٔ پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای متفاوتی را برای کاربران مختلف پیش‌تعریف کنم؟**

نه. این تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک‌گذاری می‌شوند. برنامه‌های مشاهده‌گر ممکن است ترجیحات کاربر را اعمال کنند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای را در خود دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمای پیش‌تعریف‌شده تهیه کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. از آنجا که [view properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در یک قالب جاسازی کنید و اسناد جدید را بر پایهٔ آن با همان پیکربندی نمای اولیه ایجاد کنید.