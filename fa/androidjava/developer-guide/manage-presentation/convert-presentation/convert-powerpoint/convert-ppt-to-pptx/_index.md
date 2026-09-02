---
title: تبدیل PPT به PPTX در Android
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/androidjava/convert-ppt-to-pptx/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به عنوان PPTX
- استخراج PPT به PPTX
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در Android با Aspose.Slides. شامل مثال‌های Java برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات دقت."
---
## **مرور کلی**

PPT یک فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML است. Aspose.Slides برای Android از طریق Java می‌تواند یک فایل PPT را بارگیری کرده و بدون نیاز به Microsoft PowerPoint به صورت PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنیم و پس از تبدیل چه مواردی را باید بررسی کرد.

## **تبدیل فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید، سپس با [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/#Pptx) فراخوانی کنید. بلوک `finally` ارائه را آزاد کرده و منابع آن را رها می‌کند.

```java
// بارگذاری ارائه PPT قدیمی.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // ذخیره ارائه در فرمت PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/#Pptx) این کار را انجام می‌دهد. اگر نیاز به نگه‌داراندن فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به‌صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق مانع ادامه‌ی بقیه‌ی دسته نمی‌شود.

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

برای بارهای کاری تولیدی، استثنای کامل را لاگ کنید، تصمیم بگیرید آیا فایل خروجی موجود می‌تواند بازنویسی شود یا نه، و نام فایل‌های ناموفق را به صف retry یا review بنویسید. فایل‌های خراب، فایل‌های حفاظت‌شده با رمز عبور که بدون رمز مورد نیاز باز شده‌اند، مسیرهای غیرقابل دسترس و محتوای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، به [Password-Protected Presentations](/androidjava/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های قدیمی**

تبدیل به‌طور معمول اسلایدها، مسترها، چیدمان‌ها، متن، شکل‌ها، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. با این حال، PPT و PPTX هر ویژگی را به‌دقت یکسان نشان نمی‌دهند. ویژگی قدیمی که معادل PPTX ندارد یا توسط کتابخانه پشتیبانی نمی‌شود، ممکن است نرمال‌سازی، حذف یا به‌طرز متفاوتی نمایش داده شود.

هنگامی که فایل تبدیل‌شده شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE توکار یا پیوندی، کنترل‌های ActiveX، رسانه‌های توکار، فونت‌های غیرمعمول یا ماکروهای VBA باشد، آن را بررسی کنید. یک فایل PPTX ساده فرمت فعال‌ساز ماکرو نیست، بنابراین وقتی VBA باید در دسترس باشد، از جریان کاری مناسب که ماکروها را فعال می‌کند استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولیدشده را به‌صورت برنامه‌نویسی مجدداً باز کنید و تعداد اسلایدهای کلیدی و محتوا را بررسی کنید، سپس ظاهر و رفتار نمایش اسلاید آن را در نمایشگر مورد نظر مقایسه کنید. یک فراخوانی موفق [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) را به‌عنوان اثبات این که هر ویژگی قدیمی دقیقاً به‌صورت PPTX نمایش داده می‌شود، در نظر نگیرید.

## **کی باید از PPTX استفاده کرد**

از PPTX وقتی استفاده کنید که ارائه در نسخه‌های فعلی PowerPoint ویرایش می‌شود، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند تبادل می‌شود، یا در فرمت‌تری ذخیره شود که بررسی و بازیابی آن نسبت به PPT باینری قدیمی آسان‌تر باشد. نسخه اصلی PPT را به‌عنوان نسخه بایگانی یا بازگشت نگه دارید تا زمانی که ارائه تبدیل‌شده آزمون‌های دقت شما را پاس کند.

اگر به‌جای آن به PDF، HTML، تصاویر، XPS یا نوع خروجی دیگری نیاز دارید، به راهنمایی‌های مربوط به قالب در [Convert Presentations to Multiple Formats](/slides/fa/androidjava/convert-presentation/) مراجعه کنید نه اینکه فرض کنید همه هدف‌ها ویژگی‌های ویرایش‌پذیر PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسه سریع می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های قابل تکرار، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API Android از طریق Java استفاده کنید.

## **مقالات مرتبط**

- [PPT vs PPTX](/slides/fa/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/slides/fa/androidjava/save-presentation/)
- [Supported File Formats](/slides/fa/androidjava/supported-file-formats/)
- [Open Presentations on Android](/slides/fa/androidjava/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون اینکه Microsoft PowerPoint نصب باشد؟**

بله. Aspose.Slides برای Android از طریق Java فایل‌های ارائه را بارگیری و ذخیره می‌کند بدون نیاز به Microsoft PowerPoint.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌دقت حفظ می‌کند؟**

این تبدیل محتویات رایج ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. وقتی فایل تولیدشده شامل ماکروها، اشیای OLE یا ActiveX، رسانه، انیمیشن‌های تخصصی یا فونت‌های غیرمعمول باشد، آن را بررسی کنید.

**آیا می‌توانم فایل PPT حفاظت‌شده با رمز عبور را تبدیل کنم؟**

بله، اگر هنگام بارگذاری فایل رمز عبور صحیح را عرضه کنید. عدم وجود یا نادرست بودن رمز عبور باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

تا زمانی که PPTX را در نمایشگرها و جریان‌های کاری مورد نظر خود تأیید نکرده‌اید، نسخه اصلی را نگه دارید. این کار یک نسخه بازگشت‌پذیر فراهم می‌کند اگر ویژگی قدیمی به‌صورت متفاوتی تبدیل شود.