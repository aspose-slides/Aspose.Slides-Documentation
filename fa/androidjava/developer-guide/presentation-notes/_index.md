---
title: مدیریت یادداشت‌های ارائه در اندروید
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/androidjava/presentation-notes/
keywords:
- یادداشت‌ها
- اسلاید یادداشت
- افزودن یادداشت
- حذف یادداشت
- سبک یادداشت
- یادداشت‌های اصلی
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای اندروید از طریق جاوا سفارشی کنید. به‌صورت یکپارچه با یادداشت‌های پاورپوینت و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **نمای کلی**

Aspose.Slides از حذف اسلایدهای یادداشت از یک ارائه پشتیبانی می‌کند. در این بخش، این ویژگی را معرفی می‌کنیم، از جمله چگونگی حذف یادداشت‌ها و اعمال سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلاید حذف کنید و همچنین به یادداشت‌های موجود استایل بدهید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

## **حذف یادداشت‌ها از یک اسلاید**
یادداشت‌های یک اسلاید خاص می‌تواند همان‌طور که در مثال زیر نشان داده شده است، حذف شود:

```java
// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه باشد
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های اسلاید اول
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // ذخیرهٔ ارائه در دیسک
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف یادداشت‌ها از یک ارائه**
یادداشت‌های تمام اسلایدهای یک ارائه می‌تواند همان‌طور که در مثال زیر نشان داده شده است، حذف شود:

```java
// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه باشد
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های تمام اسلایدها
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // ذخیرهٔ ارائه در دیسک
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن سبک به یادداشت‌ها**
متد[getNotesStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) به اینترفیس[IMasterNotesSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMasterNotesSlide) و کلاس[MasterNotesSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/MasterNotesSlide) اضافه شده است. این ویژگی سبک متن یادداشت را تعیین می‌کند. پیاده‌سازی این مورد در مثال زیر نشان داده شده است.

```java
// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه باشد
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // دریافت سبک متن MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //نشانگل نماد برای پاراگراف‌های سطح اول تنظیم شود
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

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید قابل دسترسی هستند: هر اسلاید دارای یک[NotesSlideManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notesslidemanager/) و یک[method](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) است که شیء یادداشت را برمی‌گرداند، یا `null` اگر یادداشت‌ای وجود نداشته باشد.

**آیا پشتیبانی از یادداشت‌ها بین نسخه‌های مختلف PowerPoint که کتابخانه با آن‌ها کار می‌کند، تفاوتی دارد؟**

این کتابخانه هدف‌گیری طیف گسترده‌ای از فرمت‌های Microsoft PowerPoint (از 97 به بعد) و ODP را دارد؛ یادداشت‌ها در این فرمت‌ها بدون نیاز به نصب یک نسخه PowerPoint پشتیبانی می‌شوند.