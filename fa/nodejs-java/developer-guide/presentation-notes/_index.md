---
title: مدیریت یادداشت‌های ارائه در جاوااسکریپت
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/nodejs-java/presentation-notes/
keywords:
- یادداشت‌ها
- اسلاید یادداشت
- افزودن یادداشت
- حذف یادداشت
- سبک یادداشت
- یادداشت‌های اصلی
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یادداشت‌های ارائه را در جاوااسکریپت با Aspose.Slides برای Node.js سفارشی کنید. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

Aspose.Slides از حذف اسلایدهای یادداشت از یک ارائه پشتیبانی می‌کند. در این موضوع، این ویژگی را معرفی می‌کنیم، از جمله نحوه حذف یادداشت‌ها و نحوه اعمال یک سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما امکان می‌دهد یادداشت‌ها را از هر اسلاید حذف کنید و همچنین استایل‌دهی به یادداشت‌های موجود انجام دهید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

برای خواندن یا تغییر ابعاد صفحه یادداشت‌ها، تغییر جهت، و بررسی رفتار خروجی، به [Notes Page Size](/slides/fa/nodejs-java/notes-size/) مراجعه کنید.

## **حذف یادداشت‌ها از یک اسلاید**
یادداشت‌ها از یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های اسلاید اول
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // ذخیره ارائه بر روی دیسک
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف یادداشت‌ها از یک ارائه**
یادداشت‌ها از تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های تمام اسلایدها
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // ذخیره ارائه بر روی دیسک
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن NotesStyle**
متد [getNotesStyle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) به کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterNotesSlide) اضافه شده است. این ویژگی سبک متن یادداشت را تعیین می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // دریافت سبک متن MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // تنظیم علامت نقطه برای پاراگراف‌های سطح اول
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslidemanager/) و یک [method](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر یادداشتی وجود نداشته باشد.

**آیا در پشتیبانی از یادداشت‌ها تفاوت‌هایی بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند وجود دارد؟**

این کتابخانه هدفدار انواع گسترده‌ای از فرمت‌های Microsoft PowerPoint (97 تا جدیدتر) و ODP است؛ یادداشت‌ها در این فرمت‌ها بدون نیاز به نسخه نصب شده PowerPoint پشتیبانی می‌شوند.