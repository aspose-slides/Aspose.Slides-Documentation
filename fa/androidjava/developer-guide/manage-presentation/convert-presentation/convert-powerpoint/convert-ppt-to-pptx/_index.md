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
- صدور PPT به PPTX
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در Android با Aspose.Slides. شامل مثال‌های Java برای تبدیل تک‌فایلی و دسته‌ای، مدیریت خطا، و نکات دقت."
---
## **نمای کلی**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML می‌باشد. Aspose.Slides برای Android از طریق Java می‌تواند یک فایل PPT را بارگذاری کند و بدون نیاز به Microsoft PowerPoint آن را به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و توضیح می‌دهد پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید، سپس متد [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) را با آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/#Pptx) فراخوانی کنید. بلوک `finally` ارائه را حذف (dispose) می‌کند و منابع آن را آزاد می‌سازد.

```java
// بارگذاری ارائه PPT قدیمی.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // ذخیرهٔ ارائه در قالب PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/#Pptx) این کار را انجام می‌دهد. اگر نیاز به حفظ فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به‌ طور مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق مانع تبدیل بقیه نمی‌شود.

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

برای بارهای کاری تولیدی، استثنای کامل را لاگ کنید، تصمیم بگیرید آیا می‌توان فایل خروجی موجود را بازنویسی کرد، و نام فایل‌های ناموفق را به صف retry یا review بنویسید. فایل‌های خراب، فایل‌های حفاظت‌شده با گذرواژه که بدون گذرواژه صحیح باز می‌شوند، مسیرهای غیرقابل دسترس و محتوای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، بخش [Password-Protected Presentations](/androidjava/password-protected-presentation/) را ببینید.

## **دقت و ویژگی‌های قدیمی**

معمولاً تبدیل اسلایدها، مسترها، طرح‌بندی‌ها، متن، اشکال، تصاویر، جداول و نمودارها را حفظ می‌کند. با این حال، PPT و PPTX هر ویژگی را به‌ دقیقاً یک شکل نشان نمی‌دهند. ویژگی‌های قدیمی که معادل PPTX ندارند یا توسط کتابخانه پشتیبانی نمی‌شوند ممکن است نرمال‌سازی، حذف یا به‌ شکل متفاوتی نمایش داده شوند.

فایل تبدیل‌شده را زمانی بررسی کنید که شامل انیمیشن‌ها، انتقال‌ها، اشیاء OLE توکار یا لینک‌دار، کنترل‌های ActiveX, رسانه‌های توکار, قلم‌های نادر یا ماکروهای VBA باشد. یک فایل PPTX ساده فرمت ماکرو‑پذیر نیست، بنابراین هنگامی که VBA باید در دسترس بماند، از یک گردش کار مناسب ماکرو‑پذیر استفاده کنید. همچنین تأیید کنید که قلم‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولید شده را به‌ صورت برنامه‌نویسی باز کنید و تعداد اسلایدها و محتوای کلیدی را بررسی کنید، سپس ظاهر و رفتار اسلایدشو را در نمایشگر مورد نظر مقایسه کنید. یک فراخوانی موفق به [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) را به‌ عنوان اثبات اینکه هر ویژگی قدیمی نمایشی دقیق در PPTX دارد، در نظر نگیرید.

## **کی باید از PPTX استفاده کرد**

از PPTX زمانی استفاده کنید که ارائه در نسخه‌های جاری PowerPoint ویرایش می‌شود، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند مبادله شود، یا در قالبی ذخیره شود که نسبت به باینری قدیمی PPT بررسی و بازیابی آن آسان‌تر باشد. تا زمانی که ارائه تبدیل‌شده پس از بررسی‌های دقت شما پاس نگذرد، PPT اصلی را به‌ عنوان نسخه بایگانی یا بازگشتی نگه دارید.

اگر به‌ جای آن به PDF، HTML، تصویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی‌های مخصوص فرمت را در [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) دنبال کنید و فرض نکنید که همهٔ مقصدها ویژگی‌های ویرایش‌پذیر PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‑گاه یا مقایسهٔ سریع، می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های مکرر، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API Android از طریق Java استفاده کنید.

## **مقالات مرتبط**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/androidjava/save-presentation/)
- [Supported File Formats](/androidjava/supported-file-formats/)
- [Open Presentations on Android](/androidjava/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را بدون نصب Microsoft PowerPoint به PPTX تبدیل کنم؟**

بله. Aspose.Slides برای Android از طریق Java فایل‌های ارائه را بدون نیاز به Microsoft PowerPoint بارگذاری و ذخیره می‌کند.

**آیا تبدیل PPT به PPTX همه محتوا را به‌ طور دقیق حفظ می‌کند؟**

محتوای رایج ارائه را حفظ می‌کند، اما دقت دقیق برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. هنگام وجود ماکروها، اشیاء OLE یا ActiveX، رسانه‌ها، انیمیشن‌های تخصصی یا قلم‌های نادر، فایل تولید شده را بازبینی کنید.

**آیا می‌توانم فایل PPT محافظت‌شده با گذرواژه را تبدیل کنم؟**

بله، در صورت ارائه گذرواژهٔ صحیح هنگام بارگذاری فایل. عدم وجود یا نادرست بودن گذرواژه باعث نشدن عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

تا زمانی که PPTX را در نمایشگرها و گردش کارهای مهم برای شما تأیید کرده‌اید، نسخهٔ اصلی را نگه دارید. این کار یک نسخهٔ بازگشتی در صورت تبدیل متفاوت ویژگی‌های قدیمی فراهم می‌کند.