---
title: مدیریت یادداشت‌های ارائه در جاوا
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای جاوا سفارشی کنید. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

Aspose.Slides از حذف اسلایدهای یادداشت‌ها از یک ارائه پشتیبانی می‌کند. در این موضوع، این ویژگی را معرفی می‌کنیم، از جمله نحوه حذف یادداشت‌ها و نحوه اعمال سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما امکان می‌دهد یادداشت‌ها را از هر اسلاید حذف کنید و همچنین به یادداشت‌های موجود استایل بدهید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

## **حذف یادداشت‌ها از یک اسلاید**
یادداشت‌های یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است، حذف شوند:

```java
// یک شیء Presentation را که نمایانگر یک فایل ارائه است، ایجاد کنید
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های اسلاید اول
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // ذخیره‌سازی ارائه بر روی دیسک
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف یادداشت‌ها از یک ارائه**
یادداشت‌های تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است، حذف شوند:

```java
// یک شیء Presentation را که نمایانگر یک فایل ارائه است، ایجاد کنید
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های تمام اسلایدها
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // ذخیره‌سازی ارائه بر روی دیسک
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن سبک به یادداشت‌ها**
متد[getNotesStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) به اینترفیس[IMasterNotesSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMasterNotesSlide) و کلاس[MasterNotesSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/MasterNotesSlide) اضافه شده است. این ویژگی سبک متن یادداشت‌ها را مشخص می‌کند. پیاده‌سازی در مثال زیر به نمایش در آمده است.

```java
// یک شیء Presentation را که نمایانگر یک فایل ارائه است، ایجاد کنید
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // دریافت سبک متن MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //تنظیم نماد بولت برای پاراگراف‌های سطح اول
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیریت‌کننده یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notesslidemanager/) و یک [method](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` در صورتی که هیچ یادداشتی وجود نداشته باشد.

**آیا پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند، متفاوت است؟**

کتابخانه برای طیف گسترده‌ای از قالب‌های Microsoft PowerPoint (97 تا جدیدتر) و ODP هدف‌گذاری شده است؛ یادداشت‌ها در این قالب‌ها بدون وابستگی به نسخه نصب شده PowerPoint پشتیبانی می‌شوند.