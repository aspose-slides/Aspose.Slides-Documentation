---
title: کلون اسلایدهای ارائه در C++
linktitle: کلون اسلایدها
type: docs
weight: 40
url: /fa/cpp/clone-slides/
keywords:
- کلون اسلاید
- کپی اسلاید
- ذخیره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "به سرعت اسلایدهای PowerPoint را با Aspose.Slides برای C++ تکرار کنید. مثال‌های کد واضح ما را دنبال کنید تا ایجاد PPT را در ثانیه‌ها خودکار کنید و کارهای دستی را حذف کنید."
---
## **مقدمه**

کلونینگ فرآیندی است برای ساخت یک کپی یا نسخهٔ دقیق از چیزی. Aspose.Slides for C++ همچنین امکان ایجاد یک کپی یا کلون از هر اسلایدی را فراهم می‌کند و سپس آن اسلاید کلون‌شده را به ارائهٔ فعلی یا هر ارائهٔ دیگری که باز است، وارد می‌نماید. فرآیند کلونینگ اسلاید یک اسلاید جدید ایجاد می‌کند که توسعه‌دهندگان می‌توانند بدون تغییر اسلاید اصلی، آن را ویرایش کنند. چند روش برای کلونینگ اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری درون همان ارائه.
- کلون در انتهای ارائه‌ای دیگر.
- کلون در موقعیت دیگری در ارائه‌ای دیگر.
- کلون در موقعیت خاصی در ارائه‌ای دیگر.

در Aspose.Slides for C++، (یک مجموعهٔ [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) objects) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) افشا می‌شود، متدهای [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) و [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/insertclone/) را برای انجام انواع کلونینگ اسلاید ارائه می‌دهند.

## **کلون یک اسلاید در انتهای یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، از متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) طبق مراحل زیر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با ارجاع به مجموعهٔ Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) افشا می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) افشا می‌شود را فراخوانی کنید و اسلایدی که قرار است کلون شود را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائهٔ تغییر یافته را بنویسید.

در مثال زیر، اسلایدی که در اولین موقعیت (شاخص صفر) ارائه قرار دارد را به انتهای ارائه کلون کردیم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **کلون یک اسلاید در موقعیت دیگری درون یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه اما در موقعیت متفاوتی استفاده کنید، از متد [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/insertclone/) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. کلاس را با ارجاع به مجموعهٔ **Slides** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) افشا می‌شود، نمونه‌سازی کنید.
1. متد [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/insertclone/) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) افشا می‌شود را فراخوانی کنید و اسلایدی که باید کلون شود همراه با اندیس موقعیت جدید را به عنوان پارامتر به این متد پاس دهید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.

در مثال زیر، اسلایدی که در اندیس صفر (موقعیت 1) ارائه قرار داشت را به اندیس 1 (موقعیت 2) ارائه منتقل کردیم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **کلون یک اسلاید در انتهای ارائه‌ای دیگر**
اگر نیاز دارید اسلایدی را از یک ارائه کلون کنید و در فایل ارائهٔ دیگری، در انتهای اسلایدهای موجود، استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که شامل ارائه‌ای است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ مقصدی است که اسلاید به آن اضافه خواهد شد.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با ارجاع به مجموعهٔ **Slides** که توسط شیء Presentation ارائهٔ مقصد افشا می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) افشا می‌شود را فراخوانی کنید و اسلاید منبع را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائهٔ مقصد تغییر یافته را بنویسید.

در مثال زیر، اسلایدی که در اولین اندیس ارائه منبع قرار داشت را به انتهای ارائهٔ مقصد کلون کردیم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **کلون یک اسلاید در موقعیت دیگری در ارائه‌ای دیگر**
اگر نیاز دارید اسلایدی را از یک ارائه کلون کنید و در فایل ارائهٔ دیگری، در موقعیت خاصی استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ منبع است.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ مقصد است.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با ارجاع به مجموعهٔ Slides ارائهٔ مقصد نمونه‌سازی کنید.
1. متد [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/insertclone/) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) افشا می‌شود را فراخوانی کنید و اسلاید منبع را به همراه موقعیت دلخواه به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائهٔ مقصد تغییر یافته را بنویسید.

در مثال زیر، اسلایدی که در اندیس صفر ارائه منبع بود را به اندیس 1 (موقعیت 2) ارائهٔ مقصد کلون کردیم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **کلون یک اسلاید در موقعیت خاصی در ارائه‌ای دیگر**
اگر نیاز دارید اسلایدی همراه با اسلاید مستر آن را از یک ارائه به ارائهٔ دیگری منتقل کنید، ابتدا باید اسلاید مستر موردنظر را از ارائهٔ منبع به ارائهٔ مقصد کلون کنید. سپس برای کلون کردن اسلاید با مستر، متد **AddClone(ISlide, IMasterSlide)** انتظار دارد مستر اسلاید از ارائهٔ مقصد باشد نه از منبع. برای کلون کردن اسلاید همراه با مستر، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ منبع است.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ مقصد است.
1. به اسلایدی که قرار است کلون شود همراه با اسلاید مستر آن دسترسی پیدا کنید.
1. کلاس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/) را با ارجاع به مجموعهٔ Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) در ارائهٔ مقصد افشا می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) که توسط شیء [IMasterSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/) افشا می‌شود را فراخوانی کنید و مستر اسلاید منبع را به عنوان پارامتر پاس دهید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با تنظیم مرجع به مجموعهٔ Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) در ارائهٔ مقصد افشا می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) افشا می‌شود را فراخوانی کنید و اسلاید منبع به همراه مستر اسلاید را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائهٔ مقصد تغییر یافته را بنویسید.

در مثال زیر، اسلایدی همراه با مستر (در اندیس صفر ارائهٔ منبع) را به انتهای ارائهٔ مقصد با استفاده از مستر منبع کلون کردیم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **کلون یک اسلاید در انتهای یک بخش مشخص**
اگر می‌خواهید اسلایدی را کلون کنید و سپس در همان فایل ارائه اما در بخش متفاوتی استفاده کنید، از متد [**AddClone()**](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) که توسط رابط [**ISlideCollection**](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) افشا می‌شود استفاده کنید. Aspose.Slides for C++ امکان کلون یک اسلاید از بخش اول و سپس وارد کردن آن اسلاید کلون‌شده به بخش دوم همان ارائه را فراهم می‌کند.

کد زیر نشان می‌دهد چگونه اسلایدی را کلون کنید و اسلاید کلون‌شده را در یک بخش مشخص وارد نمایید.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **اطمینان از هم‌ترازی اندازهٔ اسلاید**

هنگام کلون کردن اسلایدها به ارائه‌ای دیگر، اطمینان حاصل کنید که اندازهٔ اسلاید ارائهٔ مقصد با منبع یکسان باشد. اگر اندازه‌ها متفاوت باشند، Aspose.Slides به‌صورت خودکار شکل‌های کلون‌شده را مقیاس‌بندی نمی‌کند؛ مختصات و ابعاد اصلی آن‌ها حفظ می‌شود که ممکن است محتوا درون اسلاید نامرتب یا بیرون از مرزهای اسلاید دیده شود.

می‌توانید قبل از کلون کردن مستر و اسلاید، اندازهٔ اسلاید ارائهٔ مقصد را با منبع منطبق کنید:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

این کار را قبل از کلون کردن مستر و اسلاید انجام دهید.

## **سؤال‌های متداول**

**آیا یادداشت‌های سخنران و نظرات مرورگر کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، پس از وارد کردن، [آنها را حذف کنید](/slides/fa/cpp/presentation-notes/) .

**چگونه نمودارها و منابع دادهٔ آن‌ها مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های تعبیه‌شده کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار OLE‑embedded) لینک شده باشد، این لینک به‌عنوان یک [شیء OLE](/slides/fa/cpp/manage-ole/) حفظ می‌شود. پس از انتقال بین فایل‌ها، موجودیت داده‌ها و رفتار به‌روزرسانی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در یک اندیس خاص اسلاید وارد کنید و آن را به یک [بخش](/slides/fa/cpp/slide-section/) انتخابی منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن جاگذاری کنید.