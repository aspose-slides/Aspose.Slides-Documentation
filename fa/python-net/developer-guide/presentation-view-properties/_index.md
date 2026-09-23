---
title: "دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در پایتون"
linktitle: "ویژگی‌های نمای"
type: docs
weight: 80
url: /fa/python-net/presentation-view-properties/
keywords:
- "ویژگی‌های نمای"
- "نمای عادی"
- "محتوای طرح‌کلی"
- "آیکون‌های طرح‌کلی"
- "قفل کردن تقسیم‌کننده عمودی"
- "نمای تک"
- "وضعیت نوار"
- "اندازهٔ بُعد"
- "تنظیم خودکار"
- "بزرگ‌نمایی پیش‌فرض"
- "پاورپوینت"
- "ارائه"
- "پایتون"
- "Aspose.Slides"
description: "ویژگی‌های نمای Aspose.Slides برای پایتون از طریق .NET را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح بزرگ‌نمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **معرفی**

نمای عادی شامل سه ناحیه محتوا است: خود اسلاید، یک ناحیه محتوا در سمت و یک ناحیه محتوا در پایین. ویژگی‌هایی که به موقعیت‌یابی نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد وضعیت نما را در فایل ذخیره کند تا هنگام بازگشایی، نما در همان وضعیتی باشد که آخرین بار ذخیره شده بود.

ویژگی [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/normal_view_properties/) برای دسترسی به ویژگی‌های نمای عادی ارائه شده است.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/normalviewproperties/)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/normalviewrestoredproperties/) و مشتق‌های آنها، و enum [SplitterBarStateType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/splitterbarstatetype/) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش ویژگی‌های نمای عادی.

ویژگی **ShowOutlineIcons** مشخص می‌کند که برنامه هنگام نمایش محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای عادی، آیا باید آیکون‌ها را نشان دهد یا نه.

ویژگی **SnapVerticalSplitter** مشخص می‌کند که تقسیم‌کنندهٔ عمودی هنگام کوچک شدن کافی ناحیهٔ جانبی، به حالت حداقل برگردد یا خیر.

ویژگی **PreferSingleView** تعیین می‌کند که کاربر ترجیح می‌دهد یک ناحیهٔ تک‑محتوای تمام‑صفحه را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال بودن، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نشان دهد.

ویژگی‌های **VerticalBarState** و **HorizontalBarState** وضعیت نمایش نوار تقسیم‌کنندهٔ عمودی یا افقی را تعیین می‌کنند. نوار تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوای زیر اسلاید جدا می‌کند و نوار تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوای جانبی جدا می‌کند. مقادیر ممکن: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

ویژگی‌های **RestoredLeft** و **RestoredTop** اندازهٔ ناحیهٔ اسلاید روی بالا یا سمت را هنگام استفاده از مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌طور متناسب مشخص می‌کنند.

## **درباره بازگرداندن INormalViewProperties**

اندازهٔ ناحیهٔ اسلاید (عرض هنگام فرزند RestoredTop، ارتفاع هنگام فرزند RestoredLeft) در نمای عادی را وقتی که ناحیه دارای اندازهٔ بازیابی متغیر (نه حداقل و نه حداکثر) باشد، مشخص می‌کند.

ویژگی **DimensionSize** اندازهٔ ناحیهٔ اسلاید (عرض هنگام فرزند restoredTop، ارتفاع هنگام فرزند restoredLeft) را تعیین می‌کند.

ویژگی **AutoAdjust** مشخص می‌کند که آیا اندازهٔ ناحیهٔ محتوای جانبی باید برای سازگاری با اندازهٔ جدید هنگام تغییر اندازهٔ پنجرهٔ حاوی نما جبران شود یا نه.

مثالی که در ادامه آمده است نشان می‌دهد چگونه می‌توانید به ویژگی‌های **ViewProperties.NormalViewProperties** یک ارائه دسترسی پیدا کنید.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # بازیابی ویژگی‌های نمای ارائه
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم مقدار بزرگ‌نمایی پیش‌فرض**

Aspose.Slides for Python via .NET اکنون از تنظیم مقدار بزرگ‌نمایی پیش‌فرض برای ارائه پشتیبانی می‌کند به‌طوری که هنگام باز کردن ارائه، بزرگ‌نمایی از پیش تعیین شده باشد. این کار می‌تواند با تنظیم [view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) یک ارائه انجام شود. ویژگی‌های نمای اسلاید و همچنین [notes_view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/notes_view_properties/) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این بخش با مثال می‌بینیم چگونه ویژگی‌های مشاهدهٔ یک ارائه را در Aspose.Slides تنظیم کنیم.

برای تنظیم ویژگی‌های مشاهده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید
1. [view properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/) ارائه را تنظیم کنید
1. ارائه را به‌صورت فایل PPTX ذخیره کنید

در مثال زیر مقدار بزرگ‌نمایی برای نمای اسلاید و نمای یادداشت‌ها تنظیم شده است.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # تنظیم ویژگی‌های نمای ارائه
    presentation.view_properties.slide_view_properties.scale = 100 # مقدار بزرگ‌نمایی به درصد برای نمای اسلاید
    presentation.view_properties.notes_view_properties.scale = 100 # مقدار بزرگ‌نمایی به درصد برای نمای یادداشت‌ها 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم فاصله‌بندی شبکه (Grid Spacing)**

از [Presentation.view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) برای دسترسی به تنظیمات مشاهدهٔ سراسری ارائه استفاده کنید. ویژگی [ViewProperties.grid_spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/grid_spacing/) فاصلهٔ شبکهٔ ویرایش زیرین را می‌خواند یا تغییر می‌دهد. این تنظیم برای کل ارائه اعمال می‌شود، نه برای یک اسلاید جداگانه. فاصلهٔ شبکه بر حسب نقطه است؛ ۷۲ نقطه یک اینچ می‌شود. همان‌گونه که مستندات API می‌گوید، از مقدار مثبت استفاده کنید.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ فعلی شبکه را چاپ می‌کند، فاصلهٔ یک‌چهارم اینچ را تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

شبکه با [drawing guides](/slides/fa/python-net/drawing-guides/) متفاوت است. فاصلهٔ شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمای‌های رسم خطوط افقی یا عمودی موقعیت‌گذاری شدهٔ جداگانه‌ای هستند. افزودن، جابه‌جایی یا پاک کردن راهنمای‌های رسم، فاصلهٔ شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنمای‌های رسم، ابزارهای کمک‌کنندهٔ ویرایش هستند. آنها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیرهٔ فاصلهٔ شبکه تضمین نمی‌کند که ویرایشگر آن را نشان دهد؛ نمایش آن هم به تنظیمات نماینده یا ویرایشگر بستگی دارد.

## **نمایش یا مخفی‌کردن نظرات هنگام باز کردن ارائه**

از [Presentation.view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) برای دسترسی به تنظیمات مشاهدهٔ سراسری ارائه استفاده کنید. با خواندن یا تغییر [ViewProperties.show_comments](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/show_comments/) می‌توانید ترجیح ذخیره شدهٔ نمایش نظرات هنگام باز شدن ارائه در PowerPoint یا هر ویرایشگر سازگار دیگری را ذخیره کنید.

این تنظیم فقط ترجیح ذخیره شدهٔ نمایش را کنترل می‌کند. نظرات را اضافه، حذف، ویرایش یا حل نمی‌کند. مخفی‌کردن نظرات محتوای آنها، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌ها را حفظ می‌کند. برای عملیات‌های تغییر دهندهٔ نظرات، به [Presentation Comments](/slides/fa/python-net/presentation-comments/) مراجعه کنید.

مثال زیر نیاز به فایل `comments.pptx` دارد که حاوی نظرات باشد. تنظیمات فعلی نمایش را چاپ می‌کند، درخواست مخفی‌کردن نظرات را می‌فرستد و یک فایل PPTX جدید بدون حذف نظرات ذخیره می‌کند. همچنین [ViewProperties.last_view](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/last_view/) را به [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewtype/) تنظیم می‌کند تا نمای اولیهٔ ویرایش همراه با وضعیت نمایش نظرات پیکربندی شود.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

این تنظیم تعیین نمی‌کند که نظرات در خروجی‌های PDF، HTML، تصویر، یادداشت یا جزوه گنجانده شوند یا خیر. گزینه‌های مرتبط با هر نوع خروجی را جداگانه پیکربندی کنید.

## **سوالات متداول**

**چرا پس از باز کردن مجدد ارائه، شبکه نمایش داده نمی‌شود؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر تصمیم می‌گیرد که آیا شبکه نمایش داده شود یا نه. تنظیمات visibility شبکه در ویرایشگر را بررسی کنید.

**آیا پاک کردن راهنمای‌های رسم باعث تغییر فاصلهٔ شبکه می‌شود؟**

خیر. راهنمای‌های رسم و فاصلهٔ شبکه تنظیمات مستقلی هستند. پاک کردن راهنماها فاصلهٔ ذخیره شدهٔ شبکه را تحت تأثیر قرار نمی‌دهد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعیین کنم؟**

[View settings](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/slide_view_properties/)) و نه برای هر بخش؛ بنابراین یک مجموعهٔ پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم وضعیت‌های نمای مختلفی را برای کاربران مختلف پیش‌تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و برای همه به‌صورت مشترک هستند. برنامه‌های مشاهده ممکن است ترجیحات کاربری را در نظر بگیرند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف شده تهیه کنم تا ارائه‌های جدید همان‌طور باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در یک قالب بگذاری و اسناد جدید را از آن بسازید تا پیکربندی نمای اولیهٔ یکسان داشته باشند.