---
title: بازیابی و به روزرسانی ویژگی‌های نمای ارائه در پایتون
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/python-net/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قفل کردن جداکننده عمودی
- نمای تک
- وضعیت نوار
- اندازه ابعاد
- تنظیم خودکار
- بزرگنمایی پیش فرض
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای پایتون از طریق .NET را کشف کنید تا قالب‌های PPT، PPTX و ODP را سفارشی کنید - چیدمان‌ها، سطح بزرگنمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **معرفی**

نمای معمولی شامل سه ناحیه محتوا است: خود اسلاید، یک ناحیه محتوای جانبی و یک ناحیه محتوای پایین. ویژگی‌هایی که به موقعیت‌یابی نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد حالت نمای خود را در فایل ذخیره کند تا هنگام بازگشایی، نما در همان حالتی باشد که آخرین بار ارائه ذخیره شد.

ویژگی [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/normal_view_properties/) برای دسترسی به ویژگی‌های نمای معمولی ارائه اضافه شده است.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/normalviewproperties/)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/normalviewrestoredproperties/) و فرزندان آن، به‌همراه شمارش‌گر [SplitterBarStateType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/splitterbarstatetype/) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش ویژگی‌های نمای معمولی را نشان می‌دهد.

ویژگی **ShowOutlineIcons** تعیین می‌کند که آیا برنامه باید هنگام نمایش محتویات طرح کلی در هر یک از نواحی محتوا در حالت نمای معمولی، آیکون‌ها را نشان دهد یا خیر.

ویژگی **SnapVerticalSplitter** تعیین می‌کند که آیا جداکننده عمودی باید وقتی ناحیه جانبی به اندازه کافی کوچک شد، به حالت کمینه بپیچد یا نه.

ویژگی **PreferSingleView** مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوای تک‌پنجره‌ای تمام‑صفحه را به جای نمای معمولی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال بودن، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نمایش دهد.

ویژگی‌های **VerticalBarState** و **HorizontalBarState** حالت نشان‌دادن نوار جداکننده عمودی یا افقی را تعیین می‌کنند. یک نوار جداکننده افقی اسلاید را از ناحیه محتوای زیر اسلاید جدا می‌کند، در حالی که نوار جداکننده عمودی اسلاید را از ناحیه محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

ویژگی‌های **RestoredLeft** و **RestoredTop** اندازه‌گیری ناحیه اسلاید بالایی یا جانبی نمای معمولی را مشخص می‌کنند، زمانی که مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌صورت متقابل اعمال شده باشد.

## **درباره بازگرداندن INormalViewProperties**

اندازه‌گیری ناحیه اسلاید (عرض وقتی زیر **RestoredTop** باشد، ارتفاع وقتی زیر **RestoredLeft** باشد) نمای معمولی را زمانی که ناحیه به اندازه بازگردانی متغیر (نه کمینه و نه بیشینه) باشد، مشخص می‌کند.

ویژگی **DimensionSize** اندازه ناحیه اسلاید را (عرض وقتی زیر **restoredTop** باشد، ارتفاع وقتی زیر **restoredLeft** باشد) تعیین می‌کند.

ویژگی **AutoAdjust** مشخص می‌کند که آیا اندازه ناحیه محتوای جانبی باید برای اندازه جدید ج compensate  شود هنگام تغییر اندازه پنجره‌ای که نمای را در برنامه در بر دارد یا نه.

یک مثال در زیر نشان می‌دهد چگونه می‌توانید به ویژگی‌های **ViewProperties.NormalViewProperties** برای یک ارائه دسترسی پیدا کنید.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # بازگرداندن ویژگی‌های نمای ارائه
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم مقدار زوم پیش‌فرض**

Aspose.Slides برای Python via .NET اکنون از تنظیم مقدار زوم پیش‌فرض برای ارائه پشتیبانی می‌کند به‌طوری که وقتی ارائه باز می‌شود، زوم از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) یک ارائه انجام شود. ویژگی‌های نمای اسلاید و همچنین [notes_view_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/notes_view_properties/) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این بخش، با یک مثال می‌بینیم چگونه ویژگی‌های نمای یک ارائه را در Aspose.Slides تنظیم کنیم.

برای تنظیم ویژگی‌های نمای، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید
1. [view properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/) ارائه را تنظیم کنید
1. ارائه را به‌عنوان فایل PPTX بنویسید

در مثال زیر، مقدار زوم برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # تنظیم ویژگی‌های نمای ارائه
    presentation.view_properties.slide_view_properties.scale = 100 # مقدار زوم به درصد برای نمای اسلاید
    presentation.view_properties.notes_view_properties.scale = 100 # مقدار زوم به درصد برای نمای یادداشت‌ها

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا می‌توانم تنظیمات نمای مختلفی برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

[View settings](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/slide_view_properties/))، نه برای هر بخش؛ بنابراین یک مجموعه پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای مختلفی را برای کاربران مختلف از پیش تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و مشترک هستند. برنامه‌های مشاهده‌کننده ممکن است ترجیحات کاربر را اعمال کنند، اما خود فایل تنها یک مجموعه ویژگی نمای دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف‌شده داشته باشم تا ارائه‌های جدید به‌همین شکل باز شوند؟**

بله. زیرا [view properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/view_properties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب جاسازی کنید و اسناد جدید را از آن با همان پیکربندی نمای اولیه ایجاد کنید.