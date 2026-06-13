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
- یادداشت‌های مستر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای C++ سفارشی کنید. به طور یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **مرور کلی**

Aspose.Slides از حذف اسلایدهای یادداشت از ارائه پشتیبانی می‌کند. در این موضوع، این ویژگی را معرفی می‌کنیم، از جمله نحوه حذف یادداشت‌ها و نحوه اعمال یک سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما امکان می‌دهد یادداشت‌ها را از هر اسلاید حذف کنید و همچنین سبک دهی به یادداشت‌های موجود اعمال کنید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

## **حذف یادداشت‌ها از یک اسلاید خاص**
یادداشت‌های یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است، حذف شوند:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **حذف یادداشت‌ها از تمام اسلایدها**
یادداشت‌های تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است، حذف شوند:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **افزودن سبک یادداشت‌ها**
ویژگی NotesStyle به رابط IMasterNotesSlide و کلاس MasterNotesSlide اضافه شده است. این ویژگی سبک متن یادداشت‌ها را مشخص می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **سوالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی می‌یابند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/notesslidemanager/) و یک [method](https://reference.aspose.com/slides/fa/cpp/aspose.slides/notesslidemanager/get_notesslide/) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر هیچ یادداشتی وجود نداشته باشد.

**آیا تفاوت‌هایی در پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند وجود دارد؟**

کتابخانه برای طیف گسترده‌ای از فرمت‌های Microsoft PowerPoint (97 تا جدیدتر) و ODP هدف‌گیری شده است؛ یادداشت‌ها در این فرمت‌ها بدون وابستگی به نصب نسخه‌ای از PowerPoint پشتیبانی می‌شوند.