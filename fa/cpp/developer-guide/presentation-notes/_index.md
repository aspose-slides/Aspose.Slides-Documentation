---
title: مدیریت یادداشت‌های ارائه در C++
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/cpp/presentation-notes/
keywords:
- یادداشت
- اسلاید یادداشت
- افزودن یادداشت
- حذف یادداشت
- سبک یادداشت
- یادداشت‌های اصلی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای C++ سفارشی کنید. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **نمای کلی**

Aspose.Slides از حذف اسلایدهای یادداشت از یک ارائه پشتیبانی می‌کند. در این بخش، این ویژگی را معرفی می‌کنیم، از جمله نحوه حذف یادداشت‌ها و اعمال یک سبک بر اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما امکان می‌دهد یادداشت‌ها را از هر اسلاید حذف کنید و همچنین استایل را به یادداشت‌های موجود اعمال کنید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

برای مطالعه یا تغییر ابعاد صفحه یادداشت، تغییر جهت و بررسی رفتار خروجی، به [Notes Page Size](/slides/fa/cpp/notes-size/) مراجعه کنید.

## **حذف یادداشت‌ها از اسلاید خاص**
یادداشت‌ها از یک اسلاید خاص می‌توانند همان‌گونه که در مثال زیر نشان داده شده است حذف شوند:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **حذف یادداشت‌ها از تمام اسلایدها**
یادداشت‌ها از تمام اسلایدهای یک ارائه می‌توانند همان‌گونه که در مثال زیر نشان داده شده است حذف شوند:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **افزودن یک سبک یادداشت**
ویژگی NotesStyle به اینترفیس IMasterNotesSlide و کلاس MasterNotesSlide اضافه شده است. این ویژگی استایل متن یادداشت‌ها را مشخص می‌کند. پیاده‌سازی آن در مثال زیر نشان داده شده است.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **سوالات متداول**

### کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟
یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/notesslidemanager/) و یک [method](https://reference.aspose.com/slides/fa/cpp/aspose.slides/notesslidemanager/get_notesslide/) است که شیء یادداشت را برمی‌گرداند، یا `null` در صورتی که یادداشتی موجود نباشد.

### آیا تفاوتی در پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند وجود دارد؟
کتابخانه برای طیف گسترده‌ای از فرمت‌های Microsoft PowerPoint (97 و جدیدتر) و ODP هدف‌گذاری شده است؛ یادداشت‌ها در این فرمت‌ها بدون نیاز به نصب نسخه‌ای از PowerPoint پشتیبانی می‌شوند.