---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در جاوا
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/java/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- برگه توزیع
- یادداشت‌ها
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "از Aspose.Slides برای Java استفاده کنید تا سرصفحه‌ها و پاورقی‌ها را در ارائه‌های PowerPoint و OpenDocument اضافه و سفارشی‌سازی کنید و ظاهری حرفه‌ای به دست آورید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان مدیریت تنظیمات سرصفحه و پاورقی را در ارائه‌های PowerPoint می‌دهد. سرصفحه و پاورقی‌ها در سطح Master ارائه مدیریت می‌شوند و API روش‌هایی برای تنظیم متن پاورقی، تغییر نمایش‌پذیری پاورقی و به‌روزرسانی متن سرصفحه در اسلایدهای یادداشت Master فراهم می‌کند.

هم‌چنین می‌توانید سرصفحه و پاورقی‌ها را برای اسلایدهای Handout و Notes مدیریت کنید. این شامل تغییر نمایش‌پذیری و متن جای‌گیرهای سرصفحه، پاورقی، شماره اسلاید و تاریخ‑زمان برای Master یادداشت‌ها، تمام اسلایدهای فرزند یادداشت یا یک اسلاید یادداشت جداگانه می‌شود.

## **مدیریت سرصفحه و پاورقی در یک ارائه**
یادداشت‌های برخی اسلایدهای خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```java
// بارگذاری ارائه
Presentation pres = new Presentation("headerTest.pptx");
try {
    // تنظیم پاورقی
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // دسترسی و به‌روزرسانی سرصفحه
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // ذخیره ارائه
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// روش تنظیم متن سرصفحه/پاورقی
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **مدیریت سرصفحه و پاورقی در اسلایدهای Handout و Notes**
Aspose.Slides برای Java از سرصفحه و پاورقی در اسلایدهای Handout و Notes پشتیبانی می‌کند. لطفاً مراحل زیر را دنبال کنید:

- یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) حاوی ویدئو را بارگذاری کنید.
- تنظیمات سرصفحه و پاورقی را برای Master یادداشت‌ها و تمام اسلایدهای یادداشت تغییر دهید.
- جای‌گیرهای Footer همهٔ اسلایدهای فرزند را قابل مشاهده کنید.
- جای‌گیرهای Date and time همهٔ اسلایدهای فرزند را قابل مشاهده کنید.
- تنظیمات سرصفحه و پاورقی را فقط برای اولین اسلاید یادداشت تغییر دهید.
- جای‌گیر Header اسلاید یادداشت را قابل مشاهده کنید.
- متن را به جای‌گیر Header اسلاید یادداشت اختصاص دهید.
- متن را به جای‌گیر Date‑time اسلاید یادداشت اختصاص دهید.
- فایل ارائهٔ اصلاح‌شده را بنویسید.

کد نمونه در مثال زیر ارائه شده است.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // تغییر تنظیمات سرصفحه و پاورقی برای master یادداشت‌ها و تمام اسلایدهای یادداشت
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // master notes slide و تمام جای‌گیرهای Footer فرزند را قابل مشاهده کنید
        headerFooterManager.setFooterAndChildFootersVisibility(true); // master notes slide و تمام جای‌گیرهای Header فرزند را قابل مشاهده کنید
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // master notes slide و تمام جای‌گیرهای SlideNumber فرزند را قابل مشاهده کنید
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // master notes slide و تمام جای‌گیرهای Date and time فرزند را قابل مشاهده کنید

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // متن را برای master notes slide و تمام جای‌گیرهای Header فرزند تنظیم کنید
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // متن را برای master notes slide و تمام جای‌گیرهای Footer فرزند تنظیم کنید
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // متن را برای master notes slide و تمام جای‌گیرهای Date and time فرزند تنظیم کنید
    }

    // تغییر تنظیمات سرصفحه و پاورقی فقط برای اولین اسلاید یادداشت
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // جای‌گیر Header این اسلاید یادداشت را قابل مشاهده کنید

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // جای‌گیر Footer این اسلاید یادداشت را قابل مشاهده کنید

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // جای‌گیر SlideNumber این اسلاید یادداشت را قابل مشاهده کنید

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // جای‌گیر Date-time این اسلاید یادداشت را قابل مشاهده کنید

        headerFooterManager.setHeaderText("New header text"); // متن را برای جای‌گیر Header اسلاید یادداشت تنظیم کنید
        headerFooterManager.setFooterText("New footer text"); // متن را برای جای‌گیر Footer اسلاید یادداشت تنظیم کنید
        headerFooterManager.setDateTimeText("New date and time text"); // متن را برای جای‌گیر Date-time اسلاید یادداشت تنظیم کنید
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم «سرصفحه» را به اسلایدهای معمولی اضافه کنم؟**

در PowerPoint، «سرصفحه» فقط برای یادداشت‌ها و Handoutها وجود دارد؛ در اسلایدهای معمولی عناصر پشتیبانی‌شده شامل پاورقی، تاریخ/زمان و شماره اسلاید هستند. در Aspose.Slides این محدودیت‌ها همان‌ند: سرصفحه فقط برای Notes/Handout و در اسلایدها — Footer/DateTime/SlideNumber.

**اگر طرح شامل ناحیه‌ای برای پاورقی نباشد—آیا می‌توانم نمایش‌پذیری آن را «فعال» کنم؟**

بله. از طریق مدیر سرصفحه/پاورقی وضعیت نمایش‌پذیری را بررسی کنید و در صورت نیاز آن را فعال کنید. این شناسه‌ها و روش‌های API برای موقعیت‌هایی طراحی شده‌اند که جای‌گیر موجود نباشد یا مخفی باشد.

**چگونه می‌توان شماره اسلاید را از مقداری غیر از 1 شروع کرد؟**

عدد اولین اسلاید ارائه را با استفاده از [first slide number](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) تنظیم کنید؛ پس از آن تمام شماره‌گذاری‌ها مجدداً محاسبه می‌شوند. به‌عنوان مثال می‌توانید از 0 یا 10 شروع کنید و شماره را در اسلاید عنوان مخفی کنید.

**هنگام خروجی گرفتن به PDF/تصاویر/HTML، سرصفحه/پاورقی‌ها چه اتفاقی می‌افتند؟**

آن‌ها به‌عنوان عناصر متنی عادی ارائه رندر می‌شوند. به‌عبارت دیگر، اگر این عناصر در اسلایدها/صفحات یادداشت قابل مشاهده باشند، در قالب خروجی نیز به‌همراه بقیه محتوا ظاهر می‌شوند.