---
title: سفارشی‌سازی legendهای نمودار در ارائه‌ها با استفاده از C++
linktitle: legend نمودار
type: docs
url: /fa/cpp/chart-legend/
keywords:
- legend نمودار
- موقعیت legend
- اندازه قلم
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "legendهای نمودار را با Aspose.Slides برای C++ سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی legend متناسب بهینه کنید."
---
## **بررسی اجمالی**

Aspose.Slides گزینه‌هایی برای سفارشی‌سازی legend نمودار در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه موقعیت و اندازه یک legend را تنظیم کنید، اندازه قلم کل legend را تنظیم کنید، و قالب‌بندی را برای یک ورودی legend منفرد اعمال کنید.

همچنین چند رفتار مرتبط در بخش FAQ را پوشش می‌دهد، از جمله استفاده از حالت non‑overlay به طوری که ناحیه رسم فضایی برای legend داشته باشد، اجازه دادن به برچسب‌های بلند legend که به‌صورت خودکار به خط‌های بعدی بروند یا از شکست خط استفاده کنند، و اجازه دادن به وراثت قالب legend از تم ارائه زمانی که تنظیمات صریح متن و پر کردن اعمال نشده باشد.

## **موقعیت‌یابی legend**
برای تنظیم ویژگی‌های legend، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- یک chart به اسلاید اضافه کنید.
- ویژگی‌های legend را تنظیم کنید.
- ارائه را به‌عنوان فایل PPTX ذخیره کنید.

در مثال زیر، موقعیت و اندازه legend نمودار را تنظیم کرده‌ایم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **تنظیم اندازه قلم legend**
Aspose.Slides برای C++ به توسعه‌دهندگان امکان تنظیم اندازه قلم legend را می‌دهد. لطفاً مراحل زیر را دنبال کنید:

- کلاس Presentation را نمونه‌سازی کنید.
- chart پیش‌فرض را ایجاد کنید.
- اندازه قلم را تنظیم کنید.
- مقدار حداقل محور را تنظیم کنید.
- مقدار حداکثر محور را تنظیم کنید.
- ارائه را بر روی دیسک ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **تنظیم اندازه قلم یک legend منفرد**
Aspose.Slides برای C++ به توسعه‌دهندگان امکان تنظیم اندازه قلم ورودی‌های منفرد legend را می‌دهد. لطفاً مراحل زیر را دنبال کنید:

- کلاس Presentation را نمونه‌سازی کنید.
- chart پیش‌فرض را ایجاد کنید.
- به ورودی legend دسترسی پیدا کنید.
- اندازه قلم را تنظیم کنید.
- مقدار حداقل محور را تنظیم کنید.
- مقدار حداکثر محور را تنظیم کنید.
- ارائه را بر روی دیسک ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **سوالات متداول**

**آیا می‌توانم legend را فعال کنم به‌طوری که chart به‌صورت خودکار فضای لازم را برای آن اختصاص دهد و نه به‌صورت پوششی؟**

بله. از حالت non‑overlay استفاده کنید ([set_Overlay(false)](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/legend/set_overlay/)); در این حالت، ناحیه رسم (plot area) برای جا دادن legend کوچک می‌شود.

**آیا می‌توانم برچسب‌های legend را در چند خط داشته باشم؟**

بله. برچسب‌های طولانی به‌صورت خودکار وقتی فضای کافی وجود ندارد به خط بعدی می‌روند؛ شکستن خط به‌صورت اجباری نیز از طریق کاراکترهای newline در نام سری پشتیبانی می‌شود.

**چگونه می‌توانم legend را طوری تنظیم کنم که از تم رنگی ارائه پیروی کند؟**

از تنظیم رنگ‌ها/پرکننده‌ها/قلم‌های صریح برای legend یا متن آن خودداری کنید. در این صورت، آن‌ها از تم ارث می‌برند و هنگام تغییر طراحی به‌درستی به‌روز می‌شوند.