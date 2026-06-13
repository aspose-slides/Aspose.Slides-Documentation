---
title: مدیریت یادداشت‌های ارائه در JavaScript
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
description: "یادداشت‌های ارائه را در JavaScript با Aspose.Slides برای Node.js سفارشی‌سازی کنید. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت را از یک ارائه پشتیبانی می‌کند. در این مطلب، این ویژگی را معرفی می‌کنیم، از جمله چگونگی حذف یادداشت‌ها و نحوه اعمال سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلایدی حذف کنید و همچنین به یادداشت‌های موجود استایل بدهید. برنامه‌نویسان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از همه اسلایدهای یک ارائه.

## **حذف یادداشت‌ها از اسلاید**
یادداشت‌های یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```javascript
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
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

## **حذف یادداشت‌ها از ارائه**
یادداشت‌های تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```javascript
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
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
[getNotesStyle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) متد به کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterNotesSlide) و کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterNotesSlide) اضافه شده است. این خصوصیت سبک متن یادداشت را تعیین می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```javascript
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // دریافت سبک متن MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // تنظیم نماد بولت برای پاراگراف‌های سطح اول
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslidemanager/) و یک [method](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر یادداشتی موجود نباشد.

**آیا در پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند تفاوتی وجود دارد؟**

این کتابخانه بر روی گستره وسیعی از فرمت‌های Microsoft PowerPoint (97–تا نسخه‌های جدیدتر) و ODP هدف‌گذاری شده است؛ یادداشت‌ها در این فرمت‌ها بدون نیاز به نصب نسخه‌ای از PowerPoint پشتیبانی می‌شوند.