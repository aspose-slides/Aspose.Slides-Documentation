---
title: تبدیل PPT به PPTX در Node.js
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/nodejs-java/convert-ppt-to-pptx/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به عنوان PPTX
- صادرات PPT به PPTX
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "فایل‌های PPT قدیمی را در Node.js به PPTX تبدیل کنید با استفاده از Aspose.Slides. شامل مثال‌های جاوااسکریپت برای تبدیل تک‌فایلی و دسته‌ای، مدیریت خطا و نکات مربوط به دقت."
---
## **بررسی کلی**

PPT یک فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML است. Aspose.Slides برای Node.js از طریق Java می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید، سپس با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) و پاس دادن [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) ذخیره کنید. بلوک `finally` ارائه را آزاد کرده و منابع آن را رها می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// بارگذاری ارائه PPT قدیمی.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // ذخیره ارائه در قالب PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) این کار را انجام می‌دهد. اگر نیاز به حفظ فایل PPT اصلی دارید مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به صورت مستقل پردازش می‌شود، بنابراین یک تبدیل شکست خورده مانع ادامهٔ دسته نمی‌شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

برای بارهای کاری تولیدی، خطای کامل را ثبت کنید، تصمیم بگیرید آیا می‌توان فایل خروجی موجود را بازنویسی کرد و نام فایل‌های ناموفق را به صفی برای دوباره‌تلاش یا بررسی بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز صحیح باز می‌شوند، مسیرهای غیرقابل دسترس و محتوای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، مراجعه کنید به [ارائه‌های محافظت‌شده با رمز عبور](/nodejs-java/password-protected-presentation/).

## **دقت و ویژگی‌های قدیمی**

تبدیل به‌طور معمول اسلایدها، مسترها، چینش‌ها، متن، اشکال، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. با این حال، PPT و PPTX هر ویژگی را به‌طور دقیق یکسان نمایش نمی‌دهند. یک ویژگی قدیمی که معادل PPTX ندارد یا توسط کتابخانه پشتیبانی نمی‌شود، ممکن است نرمال‌سازی، حذف یا به‌صورت متفاوتی نمایش داده شود.

فایل تبدیل‌شده را زمانی که شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE توکار یا پیوندی، کنترل‌های ActiveX، رسانه‌های توکار، فونت‌های غیرمتداول یا ماکروهای VBA است، بررسی کنید. یک فایل PPTX ساده قالب ماکروپذیری نیست، بنابراین هنگام نیاز به VBA از یک جریان کاری مناسب ماکروپذیر استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های ضروری و منابع خارجی در محیطی که ارائهٔ تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولید‌شده را به‌صورت برنامه‌ای باز کنید و تعداد اسلایدها و محتوای کلیدی را بررسی کنید، سپس ظاهر و رفتار اسلایدشو را در نمایشگر موردنظر مقایسه کنید. یک فراخوانی موفقیت‌آمیز [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) را به‌عنوان اثبات این که هر ویژگی قدیمی به‌دقت در PPTX نمایان شده است، در نظر نگیرید.

## **چه زمانی از PPTX استفاده کنیم**

از PPTX استفاده کنید زمانی که ارائه در نسخه‌های فعلی PowerPoint ویرایش می‌شود، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند مبادله می‌شود یا در قالبی ذخیره می‌شود که نسبت به PPT باینری قدیمی آسان‌تر قابل بررسی و بازیابی باشد. تا زمانی که ارائهٔ تبدیل‌شده آزمون‌های دقت شما را پشت‌سر بگذارد، نسخهٔ اصلی PPT را به‌عنوان نسخهٔ بایگانی یا بازگشتی نگه دارید.

اگر به‌جای آن به PDF، HTML، تصویر، XPS یا نوع خروجی دیگری نیاز دارید، به راهنمایی‌های مرتبط با قالب در [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) مراجعه کنید و فرض نکنید تمام مقاصد ویژگی‌های قابل ویرایش PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسهٔ سریع، می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های تکراری، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API Node.js از طریق Java استفاده کنید.

## **مقالات مرتبط**

- [PPT در برابر PPTX](/nodejs-java/ppt-vs-pptx/)
- [ذخیرهٔ ارائه‌ها در Node.js](/nodejs-java/save-presentation/)
- [قالب‌های فایل پشتیبانی‌شده](/nodejs-java/supported-file-formats/)
- [باز کردن ارائه‌ها در Node.js](/nodejs-java/open-presentation/)

## **سؤالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides برای Node.js از طریق Java فایل‌های ارائه را بدون نیاز به Microsoft PowerPoint بارگذاری و ذخیره می‌کند.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌دقت حفظ می‌کند؟**

این تبدیل محتوای عمومی ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. فایل تولید‌شده را هنگام داشتن ماکروها، اشیاء OLE یا ActiveX، رسانه، انیمیشن‌های خاص یا فونت‌های غیرمتداول بررسی کنید.

**آیا می‌توانم یک فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، اگر هنگام بارگذاری فایل رمز عبور صحیح را ارائه کنید. عدم وجود یا اشتباه بودن رمز عبور باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

نسخهٔ اصلی را تا زمانی که PPTX را در نمایشگرها و جریان‌های کاری مهم برای شما تأیید کردید، نگه دارید. این کار یک نسخهٔ بازگشتی فراهم می‌کند اگر ویژگی قدیمی به‌صورت متفاوتی تبدیل شود.