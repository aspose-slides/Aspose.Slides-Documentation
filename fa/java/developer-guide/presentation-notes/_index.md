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

Aspose.Slides از حذف اسلایدهای یادداشت‌ها از یک ارائه پشتیبانی می‌کند. در این موضوع، این ویژگی را معرفی می‌کنیم، از جمله نحوه حذف یادداشت‌ها و اعمال یک سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما امکان حذف یادداشت‌ها از هر اسلاید و همچنین اعمال سبک به یادداشت‌های موجود را می‌دهد. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در ارائه.
- حذف یادداشت‌ها از همه اسلایدهای یک ارائه.

برای خواندن یا تغییر ابعاد صفحه یادداشت‌ها، تغییر جهت، و بررسی رفتار خروجی، به [Notes Page Size](/slides/fa/java/notes-size/) مراجعه کنید.

## **حذف یادداشت‌ها از یک اسلاید**
یادداشت‌های یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است، حذف شوند:

```java
import com.aspose.slides.*;

// ایجاد یک شیء Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های اسلاید اول
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // ذخیره‌سازی ارائه در دیسک
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف یادداشت‌ها از یک ارائه**
یادداشت‌های همه اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است، حذف شوند:

```java
import com.aspose.slides.*;

// ایجاد یک شیء Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های همه اسلایدها
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // ذخیره‌سازی ارائه در دیسک
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اضافه‌کردن سبک به یادداشت‌ها**
[getNotesStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) به اینترفیس [IMasterNotesSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMasterNotesSlide) و کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/MasterNotesSlide) اضافه شده است. این ویژگی سبک متن یادداشت‌ها را مشخص می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```java
import com.aspose.slides.*;

// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // دریافت سبک متن MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //تنظیم گلوله نماد برای پاراگراف‌های سطح اول
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات پرتکرار**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی می‌یابند: اسلاید دارای [NotesSlideManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notesslidemanager/) و یک [method](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر هیچ یادداشتی وجود نداشته باشد.

**آیا پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند تفاوتی دارد؟**

کتابخانه هدف‌گذاری شده برای طیف گسترده‌ای از فرمت‌های Microsoft PowerPoint (97 تا جدیدتر) و ODP است؛ یادداشت‌ها در این فرمت‌ها بدون وابستگی به نصب PowerPoint پشتیبانی می‌شوند.