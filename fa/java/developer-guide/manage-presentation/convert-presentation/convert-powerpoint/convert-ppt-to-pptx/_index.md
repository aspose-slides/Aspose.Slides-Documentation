---
title: تبدیل PPT به PPTX در جاوا
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/java/convert-ppt-to-pptx/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به صورت PPTX
- استخراج PPT به PPTX
- PowerPoint
- ارائه
- جاوا
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در جاوا با Aspose.Slides. شامل مثال‌های جاوا برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات دقت."
---
## **بررسی کلی**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML است. Aspose.Slides برای Java می‌تواند فایل PPT را بارگذاری و بدون نیاز به Microsoft PowerPoint آن را به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا مجموعه‌ای از فایل‌ها را تبدیل کنید و پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید، سپس متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) را با آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/#Pptx) فراخوانی کنید. بلوک `finally` ارائه را آزاد کرده و منابع آن را رها می‌کند.

```java
// بارگذاری ارائه PPT قدیمی.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // ذخیره ارائه به فرمت PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/#Pptx) این کار را انجام می‌دهد. اگر نیاز دارید فایل PPT اصلی را نگه دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر تمام فایل‌های `.ppt` موجود در یک پوشه را تبدیل می‌کند. هر فایل به صورت جداگانه پردازش می‌شود، بنابراین یک تبدیل ناموفق کل دسته را متوقف نمی‌کند.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

در محیط‌های تولیدی، استثنای کامل را ثبت کنید، تصمیم بگیرید آیا فایل خروجی موجود می‌تواند بازنویسی شود و نام فایل‌های ناموفق را به صف بازنگری یا تلاش دوباره بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز صحیح باز می‌شوند، مسیرهای غیرقابل دسترسی و محتواهای پشتیبانی‌نشده می‌توانند منجر به شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده به [Password-Protected Presentations](/java/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های ارثی**

تبدیل به‌طور معمول اسلایدها، مسترها، چیدمان‌ها، متن، شکل‌ها، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. اما PPT و PPTX هر ویژگی را به‌صورت دقیق یکسان نشان نمی‌دهند. ویژگی‌های ارثی که معادلی در PPTX ندارند یا توسط کتابخانه پشتیبانی نمی‌شوند، ممکن است نرمال‌سازی، حذف یا به‌طرز متفاوتی نمایش داده شوند.

وقتی فایل تبدیل‌شده شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE جاسازی شده یا لینک شده، کنترل‌های ActiveX، رسانه‌های جاسازی‌شده، فونت‌های نامعمول یا ماکروهای VBA باشد، آن را بررسی کنید. یک فایل PPTX ساده فرمت فعال‌سازی ماکرو نیست، بنابراین هنگامی که VBA باید در دسترس بماند، از جریان کاری مناسب که ماکرو را پشتیبانی می‌کند استفاده کنید. همچنین اطمینان حاصل کنید فونت‌ها و منابع خارجی مورد نیاز در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشد.

برای اسناد مهم، PPTX تولید‌شده را به‌صورت برنامه‌نویسی دوباره باز کنید و تعداد اسلایدها و محتواهای کلیدی را بررسی کنید، سپس ظاهر و رفتار اسلایدشو آن را در نمایشگر موردنظر مقایسه کنید. یک فراخوانی موفقیت‌آمیز متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) را به‌عنوان اثبات این‌که هر ویژگی ارثی مطلقاً به‌صورت PPTX نمایان می‌شود درنظر نگیرید.

## **چه زمانی از PPTX استفاده کنیم**

از PPTX زمانی استفاده کنید که ارائه در نسخه‌های جاری PowerPoint ویرایش خواهد شد، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند مبادله شود یا در قالبی ذخیره شود که نسبت به باینری قدیمی PPT بررسی و بازیابی آسان‌تری داشته باشد. نسخه اصلی PPT را به‌عنوان نسخه بایگانی یا بازگشت نگه دارید تا زمانی که ارائه تبدیل‌شده آزمون‌های دقت شما را گذرانده باشد.

اگر به‌جای آن به PDF، HTML، تصاویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی مخصوص قالب را در [Convert Presentations to Multiple Formats](/java/convert-presentation/) دنبال کنید به‌جای این‌که فرض کنید همه مقصدها ویژگی‌های قابل ویرایش PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسه سریع می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های تکراری، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه از API جاوا استفاده کنید.

## **مقالات مرتبط**

- [PPT در مقابل PPTX](/java/ppt-vs-pptx/)
- [ذخیره ارائه‌ها در جاوا](/java/save-presentation/)
- [فرمت‌های فایل پشتیبانی‌شده](/java/supported-file-formats/)
- [باز کردن ارائه‌ها در جاوا](/java/open-presentation/)

## **سؤالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides برای Java فایل‌های ارائه را بارگذاری و ذخیره می‌کند بدون اینکه به Microsoft PowerPoint نیاز داشته باشد.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌طور دقیق حفظ می‌کند؟**

این کار محتویات عمومی ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی ارثی یا پشتیبانی‌نشده تضمین نمی‌شود. فایل تولیدشده را زمانی که شامل ماکروها، اشیای OLE یا ActiveX، رسانه، انیمیشن‌های تخصصی یا فونت‌های نامعمول باشد، بررسی کنید.

**آیا می‌توانم یک فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، اگر در هنگام بارگذاری فایل رمز عبور صحیح را ارائه دهید. عدم وجود یا نادرست بودن رمز عبور باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

نسخه اصلی را تا زمانی که PPTX را در نماگرها و جریان‌های کاری موردنظر خود بررسی کرده‌اید، نگه دارید. این کار یک نسخه بازگشت در صورت تبدیل متفاوت ویژگی‌های ارثی فراهم می‌کند.