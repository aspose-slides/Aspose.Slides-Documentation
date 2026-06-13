---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در جاوااسکریپت
linktitle: سرصفحه & پاورقی
type: docs
weight: 140
url: /fa/nodejs-java/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- جزوه
- یادداشت‌ها
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "از JavaScript و Aspose.Slides برای Node.js برای افزودن و سفارشی‌سازی سرصفحه‌ها و پاورقی‌ها در ارائه‌های PowerPoint و OpenDocument جهت داشتن ظاهر حرفه‌ای استفاده کنید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان مدیریت تنظیمات سرصفحه و پاورقی را در ارائه‌های PowerPoint می‌دهد. سرصفحه‌ها و پاورقی‌ها در سطح مستر ارائه کنترل می‌شوند و API روش‌هایی برای تنظیم متن پاورقی، تغییر قابلیت مشاهده پاورقی و به‌روزرسانی متن سرصفحه در اسلایدهای یادداشت مستر فراهم می‌کند.

همچنین می‌توانید سرصفحه و پاورقی‌های اسلایدهای جزوه و یادداشت را مدیریت کنید. این شامل تغییر قابلیت مشاهده و متن جای‌دارهای سرصفحه، پاورقی، شماره اسلاید و تاریخ‑زمان برای مستر یادداشت‌ها، تمام اسلایدهای فرزند یادداشت یا یک اسلاید یادداشت منفرد می‌شود.

## **مدیریت سرصفحه و پاورقی در ارائه**

یادداشت‌های برخی اسلایدهای خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```javascript
// بارگذاری ارائه
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // تنظیم پاورقی
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // دسترسی و به‌روزرسانی سرصفحه
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // ذخیره ارائه
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **مدیریت سرصفحه و پاورقی در اسلایدهای جزوه و یادداشت**

Aspose.Slides برای Node.js از طریق Java از سرصفحه و پاورقی در اسلایدهای جزوه و یادداشت پشتیبانی می‌کند. لطفاً مراحل زیر را دنبال کنید:

- یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) حاوی ویدیو را بارگذاری کنید.
- تنظیمات سرصفحه و پاورقی را برای مستر یادداشت‌ها و تمام اسلایدهای یادداشت تغییر دهید.
- نمایش جای‌دارهای پاورقی برای اسلاید مستر یادداشت و تمام اسلایدهای فرزند را فعال کنید.
- نمایش جای‌دارهای تاریخ و زمان برای اسلاید مستر یادداشت و تمام اسلایدهای فرزند را فعال کنید.
- تنظیمات سرصفحه و پاورقی را فقط برای اولین اسلاید یادداشت تغییر دهید.
- نمایش جای‌دار سرصفحه برای اسلاید یادداشت را فعال کنید.
- متن را به جای‌دار سرصفحه اسلاید یادداشت تنظیم کنید.
- متن را به جای‌دار تاریخ‑زمان اسلاید یادداشت تنظیم کنید.
- فایل ارائه تغییر یافته را بنویسید.

کد نمونه در مثال زیر ارائه شده است.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // تنظیمات سرصفحه و پاورقی را برای مستر یادداشت‌ها و تمام اسلایدهای یادداشت تغییر دهید
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// اسلاید مستر یادداشت و تمام جای‌دارهای Footer فرزند را قابل مشاهده کنید
        headerFooterManager.setFooterAndChildFootersVisibility(true);// اسلاید مستر یادداشت و تمام جای‌دارهای Header فرزند را قابل مشاهده کنید
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// اسلاید مستر یادداشت و تمام جای‌دارهای SlideNumber فرزند را قابل مشاهده کنید
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// اسلاید مستر یادداشت و تمام جای‌دارهای Date and time فرزند را قابل مشاهده کنید
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// متن را برای اسلاید مستر یادداشت و تمام جای‌دارهای Header فرزند تنظیم کنید
        headerFooterManager.setFooterAndChildFootersText("Footer text");// متن را برای اسلاید مستر یادداشت و تمام جای‌دارهای Footer فرزند تنظیم کنید
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// متن را برای اسلاید مستر یادداشت و تمام جای‌دارهای Date and time فرزند تنظیم کنید
    }
    // تنظیمات سرصفحه و پاورقی را فقط برای اولین اسلاید یادداشت تغییر دهید
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// این جای‌دار Header اسلاید یادداشت را قابل مشاهده کنید
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// این جای‌دار Footer اسلاید یادداشت را قابل مشاهده کنید
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// این جای‌دار SlideNumber اسلاید یادداشت را قابل مشاهده کنید
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// این جای‌دار Date-time اسلاید یادداشت را قابل مشاهده کنید
        headerFooterManager.setHeaderText("New header text");// متن را برای جای‌دار Header اسلاید یادداشت تنظیم کنید
        headerFooterManager.setFooterText("New footer text");// متن را برای جای‌دار Footer اسلاید یادداشت تنظیم کنید
        headerFooterManager.setDateTimeText("New date and time text");// متن را برای جای‌دار Date-time اسلاید یادداشت تنظیم کنید
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم "سرصفحه" را به اسلایدهای عادی اضافه کنم؟**

در PowerPoint، "سرصفحه" فقط برای یادداشت‌ها و جزوه‌ها وجود دارد؛ در اسلایدهای عادی، عناصر پشتیبانی‌شده شامل پاورقی، تاریخ/زمان و شماره اسلاید هستند. در Aspose.Slides نیز همین محدودیت‌ها اعمال می‌شود: سرصفحه تنها برای یادداشت‌ها/جزوه‌ها، و در اسلایدها—پاورقی/تاریخ‑زمان/شماره‌اسلاید.

**اگر طرح‌بندی شامل ناحیهٔ پاورقی نباشد—آیا می‌توانم قابلیت مشاهده آن را "فعال" کنم؟**

بله. قابلیت مشاهده را از طریق مدیر سرصفحه/پاورقی بررسی کنید و در صورت نیاز آن را فعال کنید. این شاخص‌ها و روش‌های API برای مواردی طراحی شده‌اند که جای‌دار موجود نیست یا پنهان شده است.

**چگونه شماره اسلاید را از مقدار دیگری به جز 1 شروع کنم؟**

عدد [first slide number](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) ارائه را تنظیم کنید؛ پس از آن، تمام شماره‌گذاری‌ها دوباره محاسبه می‌شوند. به عنوان مثال می‌توانید از 0 یا 10 شروع کنید و شماره را در اسلاید عنوان پنهان کنید.

**وقتی به PDF/تصاویر/HTML صادر می‌کنم، سرصفحه/پاورقی‌ها چه اتفاقی می‌افتند؟**

آنها به‌عنوان عناصر متنی معمولی در ارائه رندر می‌شوند. به این معنی که اگر این عناصر در اسلایدها/صفحات یادداشت قابل مشاهده باشند، در قالب خروجی نیز همراه با بقیه محتوا نمایش داده می‌شوند.