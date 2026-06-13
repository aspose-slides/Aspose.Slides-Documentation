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
description: "به سرعت اسلایدهای PowerPoint را با Aspose.Slides برای C++ تکثیر کنید. مثال‌های کد واضح ما را برای خودکارسازی ایجاد PPT در ثانیه‌ها دنبال کنید و کارهای دستی را حذف کنید."
---
## **مقدمه**

کلون کردن فرآیندی است برای ایجاد یک نسخه دقیق یا تکرار از چیزی. Aspose.Slides for C++ همچنین امکان ایجاد یک کپی یا کلون از هر اسلایدی را فراهم می‌کند و سپس آن اسلاید کلون‌شده را به ارائه فعلی یا هر ارائه دیگری که باز است، وارد می‌کند. فرآیند کلون‌سازی اسلاید یک اسلاید جدید ایجاد می‌کند که می‌تواند توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی، اصلاح شود. چندین روش ممکن برای کلون کردن یک اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری درون ارائه.
- کلون در انتهای یک ارائه دیگر.
- کلون در موقعیت دیگری در یک ارائه دیگر.
- کلون در موقعیت خاصی در یک ارائه دیگر.

در Aspose.Slides for C++، (مجموعه‌ای از [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) objects) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) نمایش داده می‌شود، متدهای [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) و [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/insertclone/) را برای انجام انواع کلون‌سازی اسلایدهای فوق فراهم می‌کند

## **کلون یک اسلاید در انتهای یک ارائه**

اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، با توجه به مراحل زیر از متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) نمایش داده می‌شود، فراخوانی کنید و اسلایدی که باید کلون شود را به‌عنوان پارامتر به متد [AddClone] پاس دهید.
1. فایل ارائه اصلاح شده را بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **کلون یک اسلاید به موقعیت دیگری درون یک ارائه**

اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه اما در موقعیتی متفاوت استفاده کنید، از متد [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/insertclone/) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. کلاس را با ارجاع به مجموعه **Slides** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/insertclone/) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) نمایش داده می‌شود، فراخوانی کنید و اسلایدی که باید کلون شود را همراه با اندیس موقعیت جدید به‌عنوان پارامتر به متد [InsertClone] پاس دهید.
1. فایل ارائه اصلاح شده را به صورت PPTX بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **کلون یک اسلاید در انتهای یک ارائه دیگر**

اگر نیاز دارید یک اسلاید را از یک ارائه کلون کرده و در انتهای اسلایدهای موجود یک ارائه دیگر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) که شامل ارائه‌ای است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) که شامل ارائه مقصدی است که اسلاید به آن اضافه خواهد شد، ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با ارجاع به مجموعه **Slides** که توسط شیء Presentation ارائه مقصد نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) نمایش داده می‌شود، فراخوانی کنید و اسلاید از ارائه منبع را به‌عنوان پارامتر به متد [AddClone] پاس دهید.
1. فایل ارائه مقصد اصلاح شده را بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **کلون یک اسلاید به موقعیت دیگری در یک ارائه دیگر**

اگر نیاز دارید یک اسلاید را از یک ارائه کلون کرده و در موقعیت خاصی از یک ارائه دیگر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) که شامل ارائه منبع است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) که شامل ارائه‌ای است که اسلاید به آن اضافه خواهد شد، ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با ارجاع به مجموعه Slides که توسط شیء Presentation ارائه مقصد نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/insertclone/) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) نمایش داده می‌شود، فراخوانی کنید و اسلاید از ارائه منبع را همراه با موقعیت موردنظر به‌عنوان پارامتر به متد [InsertClone] پاس دهید.
1. فایل ارائه مقصد اصلاح شده را بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **کلون یک اسلاید در موقعیت خاصی در یک ارائه دیگر**

اگر نیاز دارید یک اسلاید همراه با اسلاید اصلی (master) را از یک ارائه کلون کرده و در ارائه دیگری استفاده کنید، ابتدا باید اسلاید اصلی موردنظر را از ارائه منبع به ارائه مقصد کلون کنید. سپس برای کلون کردن اسلاید با اسلاید اصلی، باید از آن اسلاید اصلی استفاده کنید. متد **AddClone(ISlide, IMasterSlide)** انتظار دارد اسلاید اصلی از ارائه مقصد باشد نه از منبع. برای کلون کردن اسلاید با اسلاید اصلی، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) که شامل ارائه منبع است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) که شامل ارائه مقصد است که اسلاید به آن کلون می‌شود، ایجاد کنید.
1. به اسلایدی که باید کلون شود به‌همراه اسلاید اصلی دسترسی پیدا کنید.
1. کلاس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ارائه مقصد نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) را که توسط شیء [IMasterSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/) نمایش داده می‌شود، فراخوانی کنید و اسلاید اصلی از PPTX منبع را به‌عنوان پارامتر به متد [AddClone] پاس دهید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با تنظیم ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ارائه مقصد نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) نمایش داده می‌شود، فراخوانی کنید و اسلاید از ارائه منبع را به‌عنوان پارامتر همراه با اسلاید اصلی به متد [AddClone] پاس دهید.
1. فایل ارائه مقصد اصلاح شده را بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **کلون یک اسلاید در انتهای یک بخش مشخص**

اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه اما در یک بخش متفاوت استفاده کنید، متد [**AddClone()**](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) را که توسط اینترفیس [**ISlideCollection**](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) ارائه می‌شود، استفاده کنید. Aspose.Slides for C++ امکان کلون کردن اسلاید از بخش اول و سپس وارد کردن آن اسلاید کلون‌شده به بخش دوم همان ارائه را فراهم می‌کند.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **سوالات متداول**

**آیا یادداشت‌های گوینده و نظرات مرورگر کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، پس از درج [remove them](/slides/fa/cpp/presentation-notes/) کنید.

**نمودارها و منابع داده‌ای آنها چگونه مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های توکار کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار OLE توکار) لینک شده باشد، آن لینک به عنوان یک شیء [OLE](/slides/fa/cpp/manage-ole/) حفظ می‌شود. پس از جابجایی بین فایل‌ها، موجودیت داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌ها را برای کلون کنترل کنم؟**

بله. می‌توانید کلون را در یک اندیس اسلاید خاص وارد کنید و آن را به یک [section](/slides/fa/cpp/slide-section/) انتخابی منتقل کنید. اگر بخش هدف موجود نباشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.