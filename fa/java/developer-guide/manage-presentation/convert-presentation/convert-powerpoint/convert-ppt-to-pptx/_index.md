---
title: تبدیل PPT به PPTX در Java
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
- صادرات PPT به PPTX
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در Java با Aspose.Slides. شامل مثال‌های Java برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات مربوط به دقت."
---
## **بررسی کلی**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML است. Aspose.Slides for Java می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و توضیح می‌دهد پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید، سپس با [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) و آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/#Pptx) فراخوانی کنید. بلوک `finally` ارائه را آزاد کرده و منابع آن را رها می‌کند.

```java
// بارگذاری ارائه PPT قدیمی.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // ذخیرهٔ ارائه به فرمت PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پسوند فایل به تنهایی فرمت خروجی را انتخاب نمی‌کند؛ آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/#Pptx) این کار را انجام می‌دهد. اگر نیاز به نگه‌داری فایل PPT اصلی دارید مسیرهای ورودی و خروجی را متفاوت نگه‌دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق بقیهٔ دسته را متوقف نمی‌کند.

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

برای بارهای کاری تولیدی، استثنا را به‌صورت کامل ثبت کنید، تصمیم بگیرید آیا امکان نوشتن روی فایل خروجی موجود وجود دارد یا خیر، و نام فایل‌های ناموفق را به صف بازنگری یا تلاش مجدد بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز صحیح باز می‌شوند، مسیرهای غیرقابل دسترسی و محتواهای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده به [Password-Protected Presentations](/slides/fa/java/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های قدیمی**

معمولاً تبدیل اسلایدها، مسترها، لایه‌ها، متن، اشکال، تصویرها، جدول‌ها و نمودارها را حفظ می‌کند. اما PPT و PPTX هر ویژگی را به‌صورت دقیق یکسان نشان نمی‌دهند. ویژگی‌های قدیمی که معادل PPTX ندارند یا توسط کتابخانه پشتیبانی نمی‌شوند ممکن است نرمال‌سازی، حذف یا به‌شیوه‌ای متفاوت نمایش داده شوند.

فایل تبدیل‌شده را زمانی بررسی کنید که شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE جاسازی‌شده یا پیوند‌خورده، کنترل‌های ActiveX، رسانهٔ جاسازی‌شده، فونت‌های غیرمعمول یا ماکروهای VBA باشد. یک فایل PPTX ساده فرمت فعال‌سازی ماکرو نیست، بنابراین وقتی VBA باید در دسترس باشد، از جریان کاری مناسب ماکرو‑پذیر استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولیدشده را به‌صورت برنامه‌ای دوباره باز کنید و تعداد اسلایدهای کلیدی و محتوا را بررسی کنید، سپس ظاهر و رفتار اسلایدشو را در نمایندهٔ موردنظر مقایسه کنید. یک فراخوانی موفق [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) را به‌عنوان اثبات این‌که هر ویژگی قدیمی معادل دقیق در PPTX دارد، در نظر نگیرید.

## **چه زمانی از PPTX استفاده کنیم**

هنگامی که ارائه قرار است در نسخه‌های جاری PowerPoint ویرایش شود، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند تبادل شود، یا در فرمتی ذخیره شود که نسبت به باینری قدیمی PPT بررسی و بازیابی آسان‌تری داشته باشد، از PPTX استفاده کنید. تا زمانی که بررسی‌های دقت شما بر روی ارائه تبدیل‌شده تکمیل شد، نسخهٔ اصلی PPT را به‌عنوان نسخهٔ بایگانی یا بازگشت نگه‌دارید.

اگر به PDF، HTML، تصویر، XPS یا نوع خروجی دیگری نیاز دارید، به راهنمایی‌های خاص فرمت در [Convert Presentations to Multiple Formats](/slides/fa/java/convert-presentation/) مراجعه کنید تا فرض نکنید همهٔ اهداف ویژگی‌های ویرایش‌پذیر PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل مختصر یا مقایسهٔ سریع می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های تکراری، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه از API جاوا استفاده کنید.

## **مقالات مرتبط**

- [PPT در مقابل PPTX](/slides/fa/java/ppt-vs-pptx/)
- [ذخیره ارائه‌ها در Java](/slides/fa/java/save-presentation/)
- [فرمت‌های فایل پشتیبانی شده](/slides/fa/java/supported-file-formats/)
- [باز کردن ارائه‌ها در Java](/slides/fa/java/open-presentation/)

## **سؤال‌های متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides for Java می‌تواند فایل‌های ارائه را بدون نیاز به Microsoft PowerPoint بارگذاری و ذخیره کند.

**آیا تبدیل PPT به PPTX تمام محتوا را دقیقا حفظ می‌کند؟**

محتوای عمومی ارائه را حفظ می‌کند، اما تضمین دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده وجود ندارد. فایل تولیدشده را وقتی شامل ماکروها، اشیای OLE یا ActiveX، رسانه، انیمیشن‌های تخصصی یا فونت‌های غیرمعمول است، بررسی کنید.

**آیا می‌توانم یک فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، اگر هنگام بارگذاری فایل رمز عبور صحیح را ارائه دهید. عدم ارائه یا ارائه رمز نادرست باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

فایل اصلی را تا زمانی که PPTX را در نماگرها و جریان‌های کاری مهم خود تأیید کرده باشید، نگه‌دارید. این کار یک نسخهٔ بازگشت در صورت متفاوت تبدیل ویژگی‌های قدیمی فراهم می‌کند.