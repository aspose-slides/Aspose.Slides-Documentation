---
title: دریافت فراخوانی‌های هشدار برای جایگزینی فونت
type: docs
weight: 90
url: /fa/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- فراخوانی هشدار
- جایگزینی فونت
- فرآیند رندرینگ
- پاورپوینت
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه فراخوانی‌های هشدار برای جایگزینی فونت در Aspose.Slides for Java دریافت کنید و ارائه‌های PowerPoint و OpenDocument را به‌دقت نمایش دهید."
---
## **مقدمه**

Aspose.Slides for Java به شما امکان دریافت فراخوانی‌های هشدار برای جایگزینی فونت را می‌دهد وقتی فونت مورد نیاز در طول رندرینگ بر روی ماشین موجود نباشد. این فراخوانی‌ها به تشخیص مشکلات مربوط به فونت‌های گمشده یا غیرقابل دسترسی کمک می‌کنند.

## **فعال‌سازی فراخوانی‌های هشدار**

Aspose.Slides for Java APIهای ساده‌ای برای دریافت فراخوانی‌های هشدار هنگام رندر اسلایدهای ارائه فراهم می‌کند. برای پیکربندی فراخوانی‌های هشدار، مراحل زیر را دنبال کنید:

1. یک کلاس فراخوانی سفارشی ایجاد کنید که رابط [IWarningCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarningcallback/) را برای مدیریت هشدارها پیاده‌سازی کند.
1. با استفاده از کلاس‌های گزینه مانند [RenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) و سایر موارد، فراخوانی هشدار را تنظیم کنید.
1. یک ارائه را بارگذاری کنید که از فونتی استفاده می‌کند که بر روی ماشین هدف موجود نیست.
1. یک تصویر کوچک اسلاید تولید کنید یا ارائه را برای مشاهده اثر صادر کنید.

**کلاس سفارشی فراخوانی هشدار:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// نمونه خروجی:
//
// فونت از XYZ به {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}} جایگزین خواهد شد
```

**تولید تصویر کوچک اسلاید:**

```java
// یک فراخوانی هشدار برای مدیریت هشدارهای مربوط به فونت در هنگام رندر اسلاید تنظیم می‌کند.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// ارائه را از مسیر فایل مشخص شده بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // یک تصویر کوچک برای هر اسلاید در ارائه تولید کنید.
    for (ISlide slide : presentation.getSlides()) {
        // تصویر کوچک اسلاید را با استفاده از گزینه‌های رندرینگ مشخص شده دریافت کنید.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**صدور به قالب PDF:**

```java
// یک فراخوانی هشدار تنظیم می‌کند تا هشدارهای مرتبط با فونت را در هنگام صادرات PDF مدیریت کند.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// ارائه را از مسیر فایل مشخص شده بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ارائه را به عنوان PDF صادر کنید.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**صدور به قالب HTML:**

```java
// یک فراخوانی هشدار تنظیم می‌کند تا هشدارهای مرتبط با فونت را در هنگام صادرات HTML مدیریت کند.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// ارائه را از مسیر فایل مشخص شده بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ارائه را به فرمت HTML صادر کنید.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```