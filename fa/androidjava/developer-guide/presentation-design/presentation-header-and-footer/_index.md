---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در اندروید
linktitle: سرصفحه & پاورقی
type: docs
weight: 140
url: /fa/androidjava/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- نسخه توزیع
- یادداشت‌ها
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- Java
- Aspose.Slides
description: "از Aspose.Slides برای Android از طریق Java استفاده کنید تا سرصفحه‌ها و پاورقی‌ها را در ارائه‌های PowerPoint و OpenDocument اضافه و سفارشی‌سازی کنید و ظاهری حرفه‌ای داشته باشید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تنظیمات سرصفحه و پاورقی را در ارائه‌های PowerPoint مدیریت کنید. سرصفحه‌ها و پاورقی‌ها در سطح مستر ارائه کنترل می‌شوند و API متدهایی برای تنظیم متن پاورقی، تغییر قابلیت نمایش پاورقی و به‌روزرسانی متن سرصفحه در اسلایدهای یادداشت مستر ارائه می‌دهد.

همچنین می‌توانید سرصفحه و پاورقی را برای اسلایدهای توزیع و یادداشت مدیریت کنید. این شامل تغییر قابلیت نمایش و متن مکان‌گیرهای سرصفحه، پاورقی، شماره اسلاید و تاریخ‑زمان برای مستر یادداشت، تمام اسلایدهای فرزند یادداشت یا یک اسلاید یادداشت به‌صورت جداگانه می‌شود.

## **مدیریت سرصفحه‌ها و پاورقی‌ها در یک ارائه**

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
// متد برای تنظیم متن سرصفحه/پاورقی
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

## **مدیریت سرصفحه‌ها و پاورقی‌ها در اسلایدهای توزیع و یادداشت**

Aspose.Slides برای Android از طریق Java از سرصفحه و پاورقی در اسلایدهای توزیع و یادداشت پشتیبانی می‌کند. لطفاً مراحل زیر را دنبال کنید:

- یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) شامل ویدیو بارگذاری کنید.
- تنظیمات سرصفحه و پاورقی را برای مستر یادداشت و تمام اسلایدهای یادداشت تغییر دهید.
- قابلیت نمایش مکان‌گیرهای پاورقی در اسلاید مستر یادداشت و تمام فرزندان آن را فعال کنید.
- قابلیت نمایش مکان‌گیرهای تاریخ و زمان در اسلاید مستر یادداشت و تمام فرزندان آن را فعال کنید.
- تنظیمات سرصفحه و پاورقی را فقط برای اولین اسلاید یادداشت تغییر دهید.
- قابلیت نمایش مکان‌گیر سرصفحه در اسلاید یادداشت را فعال کنید.
- متن را به مکان‌گیر سرصفحه اسلاید یادداشت اختصاص دهید.
- متن را به مکان‌گیر تاریخ‑زمان اسلاید یادداشت اختصاص دهید.
- فایل ارائهٔ اصلاح‌شده را بنویسید.

کد نمونه در مثال زیر ارائه شده است.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // تغییر تنظیمات سرصفحه و پاورقی برای مستر یادداشت‌ها و تمام اسلایدهای یادداشت
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // اسلاید مستر یادداشت و تمام مکان‌گیرهای پاورقی فرزند قابل مشاهده شوند
        headerFooterManager.setFooterAndChildFootersVisibility(true); // اسلاید مستر یادداشت و تمام مکان‌گیرهای سرصفحه فرزند قابل مشاهده شوند
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // اسلاید مستر یادداشت و تمام مکان‌گیرهای شماره اسلاید فرزند قابل مشاهده شوند
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // اسلاید مستر یادداشت و تمام مکان‌گیرهای تاریخ و زمان فرزند قابل مشاهده شوند

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // متن را برای اسلاید مستر یادداشت و تمام مکان‌گیرهای سرصفحه فرزند تنظیم کنید
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // متن را برای اسلاید مستر یادداشت و تمام مکان‌گیرهای پاورقی فرزند تنظیم کنید
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // متن را برای اسلاید مستر یادداشت و تمام مکان‌گیرهای تاریخ و زمان فرزند تنظیم کنید
    }

    // تغییر تنظیمات سرصفحه و پاورقی فقط برای اولین اسلاید یادداشت
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // این مکان‌گیر سرصفحه اسلاید یادداشت قابل مشاهده شود

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // این مکان‌گیر پاورقی اسلاید یادداشت قابل مشاهده شود

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // این مکان‌گیر شماره اسلاید اسلاید یادداشت قابل مشاهده شود

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // این مکان‌گیر تاریخ‑زمان اسلاید یادداشت قابل مشاهده شود

        headerFooterManager.setHeaderText("New header text"); // متن را برای مکان‌گیر سرصفحه اسلاید یادداشت تنظیم کنید
        headerFooterManager.setFooterText("New footer text"); // متن را برای مکان‌گیر پاورقی اسلاید یادداشت تنظیم کنید
        headerFooterManager.setDateTimeText("New date and time text"); // متن را برای مکان‌گیر تاریخ‑زمان اسلاید یادداشت تنظیم کنید
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم «سرصفحه» را به اسلایدهای عادی اضافه کنم؟**

در PowerPoint، «سرصفحه» فقط برای یادداشت‌ها و توزیع‌ها وجود دارد؛ در اسلایدهای عادی، عناصر پشتیبانی‌شده فقط پاورقی، تاریخ‑زمان و شماره اسلاید هستند. در Aspose.Slides این محدودیت‌ها همانند است: سرصفحه فقط برای یادداشت‌ها/توزیع‌ها و در اسلایدها—پاورقی/تاریخ‑زمان/شماره اسلاید.

**اگر چیدمان ناحیهٔ پاورقی نداشته باشد، آیا می‌توانم نمایش آن را «روشن» کنم؟**

بله. با استفاده از مدیر سرصفحه/پاورقی قابلیت نمایش را بررسی کنید و در صورت نیاز آن را فعال کنید. این شاخص‌ها و متدهای API برای مواقعی طراحی شده‌اند که مکان‌گیر وجود نداشته یا مخفی باشد.

**چگونه می‌توانم شماره اسلاید را از مقداری غیر از 1 شروع کنم؟**

عدد اولین اسلاید ارائه را با استفاده از [عدد اولین اسلاید](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) تنظیم کنید؛ پس از آن، تمام شماره‌گذاری‌ها بازمحاسبه می‌شوند. به‌عنوان مثال می‌توانید از 0 یا 10 شروع کنید و شماره را در اسلاید عنوان مخفی کنید.

**هنگام خروجی‌گیری به PDF/تصاویر/HTML چه می‌شود برای سرصفحه‌ها/پاورقی‌ها؟**

آن‌ها به‌عنوان عناصر متنی معمولی ارائه رندر می‌شوند. به این معنی که اگر این عناصر در اسلایدها/صفحات یادداشت قابل مشاهده باشند، در قالب خروجی نیز همراه با سایر محتوا ظاهر می‌شوند.