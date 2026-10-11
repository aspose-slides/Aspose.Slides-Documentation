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
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای اندروید از طریق جاوا سفارشی کنید. به‌طور یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت را از یک ارائه فراهم می‌کند. در این موضوع، ویژگی مذکور را معرفی می‌کنیم، از جمله نحوه حذف یادداشت‌ها و نحوه اعمال یک سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلاید حذف کنید و همچنین به یادداشت‌های موجود استایل اعمال کنید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

برای خواندن یا تغییر ابعاد صفحه یادداشت، تغییر جهت و بررسی رفتار صادرات، ببینید [اندازه صفحه یادداشت](/slides/fa/androidjava/notes-size/).

## **حذف یادداشت‌ها از اسلاید**
یادداشت‌های یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```java
import com.aspose.slides.*;

// یک شی Presentation که نمایانگر فایل ارائه است را نمونه‌سازی کنید
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های اسلاید اول
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // ذخیره ارائه بر روی دیسک
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف یادداشت‌ها از ارائه**
یادداشت‌های تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```java
import com.aspose.slides.*;

// یک شی Presentation که نمایانگر فایل ارائه است را نمونه‌سازی کنید
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // حذف یادداشت‌های تمام اسلایدها
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // ذخیره ارائه بر روی دیسک
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن سبک یادداشت**
[getNotesStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) متد به واسط [IMasterNotesSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMasterNotesSlide) و کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/MasterNotesSlide) به ترتیب اضافه شده است. این ویژگی سبک متن یادداشت را مشخص می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```java
import com.aspose.slides.*;

// یک شی Presentation که نمایانگر فایل ارائه است را نمونه‌سازی کنید
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // دریافت سبک متن MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // تنظیم نماد گلوله برای پاراگراف‌های سطح اول
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notesslidemanager/) و یک [method](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر یادداشتی وجود نداشته باشد.

**آیا تفاوتی در پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند وجود دارد؟**

این کتابخانه بر روی طیف وسیعی از فرمت‌های Microsoft PowerPoint (97 تا جدیدتر) و ODP هدف‌گذاری می‌شود؛ یادداشت‌ها در این فرمت‌ها بدون نیاز به نصب نسخه‌ای از PowerPoint پشتیبانی می‌شوند.