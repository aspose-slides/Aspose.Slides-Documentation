---
title: تبدیل PPT به PPTX در Node.js
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/nodejs-java/convert-ppt-to-pptx/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به عنوان PPTX
- صادرات PPT به PPTX
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "فایل‌های PPT قدیمی را در Node.js با Aspose.Slides به PPTX تبدیل کنید. شامل مثال‌های JavaScript برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات مربوط به دقت است."
---
## **بررسی کلی**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML می‌باشد. Aspose.Slides برای Node.js از طریق Java می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint آن را به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید، سپس [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) را با آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) فراخوانی کنید. بلوک `finally` ارائه را آزاد کرده و منابع آن را رها می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// بارگذاری ارائه PPT قدیمی.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // ذخیره ارائه در فرمت PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) این کار را انجام می‌دهد. اگر نیاز به نگه‌داشتن فایل PPT اصلی دارید مسیرهای ورودی و خروجی را متفاوت انتخاب کنید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` موجود در یک پوشه را تبدیل می‌کند. هر فایل به صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق مانع ادامه پردازش بقیه نمی‌شود.

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

در بارهای کاری تولیدی، خطاهای کامل را لاگ کنید، تصمیم بگیرید آیا اجازه بازنویسی فایل خروجی موجود وجود دارد یا خیر، و نام فایل‌های ناموفق را به صف retry یا بررسی ارسال کنید. فایل‌های خراب، فایل‌های رمزگذاری‌شده بدون رمز صحیح، مسیرهای غیرقابل دسترس و محتوای پشتیبانی نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزنگاری‌شده به مقاله [Password‑Protected Presentations](/slides/fa/nodejs-java/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های میراثی**

تبدیل به‌طور معمول اسلایدها، ماس्टरها، چیدمان‌ها، متن، شکل‌ها، تصویرها، جداول و نمودارها را حفظ می‌کند. اما PPT و PPTX هر ویژگی را به‌صورت دقیق یکسان نمایش نمی‌دهند. ویژگی‌های قدیمی که معادل PPTX ندارند یا توسط کتابخانه پشتیبانی نمی‌شوند ممکن است نرمال‌سازی، حذف یا نمایش متفاوتی داشته باشند.

زمانی که فایل تبدیل‌شده شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE جاسازی‌شده یا لینک‌شده، کنترل‌های ActiveX، رسانه‌های جاسازی‌شده، فونت‌های غیر معمول یا ماکروهای VBA باشد، آن را بررسی کنید. فایل PPTX ساده فرمت ماکرو‑پذیر نیست، پس برای حفظ VBA از جریان کاری مناسب ماکرو‑پذیر استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های لازم و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولید شده را به‌صورت برنامه‌نویسی باز کنید و تعداد اسلایدهای کلیدی و محتوا را بررسی کنید، سپس ظاهر و رفتار نمایش اسلایدها را در نماینده هدف مقایسه کنید. یک فراخوانی موفق [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) به معنای این نیست که هر ویژگی میراثی معادل دقیق در PPTX داشته باشد.

## **چه وقت از PPTX استفاده کنیم**

هنگامی که ارائه قرار است در نسخه‌های جاری PowerPoint ویرایش شود، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند به‌اشتراک گذاشته شود یا در فرمت آسان‌تری برای بازرسی و بازیابی نسبت به باینری قدیمی PPT ذخیره شود، از PPTX استفاده کنید. تا زمانی که ارائه تبدیل‌شده آزمون‌های دقت شما را پاس نگذارد، نسخه اصلی PPT را به‌عنوان نسخه آرشیوی یا بازگشتی نگه دارید.

اگر به جای آن به PDF، HTML، تصویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی‌های خاص فرمت را در [Convert Presentations to Multiple Formats](/slides/fa/nodejs-java/convert-presentation/) ببینید و فرض نکنید که همه هدف‌ها ویژگی‌های قابل ویرایش PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسه سریع می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های مکرر، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API Node.js از طریق Java استفاده کنید.

## **مقالات مرتبط**

- [PPT در برابر PPTX](/slides/fa/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/slides/fa/nodejs-java/save-presentation/)
- [Supported File Formats](/slides/fa/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/slides/fa/nodejs-java/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را بدون نصب Microsoft PowerPoint به PPTX تبدیل کنم؟**

بله. Aspose.Slides برای Node.js از طریق Java می‌تواند فایل‌های ارائه را بارگذاری و ذخیره کند بدون نیاز به Microsoft PowerPoint.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌دقت حفظ می‌کند؟**

محتوای رایج ارائه حفظ می‌شود، اما دقت کامل برای هر ویژگی میراثی یا پشتیبانی‌نشده تضمین نمی‌شود. فایل تولید شده را زمانی که شامل ماکروها، اشیای OLE یا ActiveX، رسانه، انیمیشن‌های تخصصی یا فونت‌های غیر معمول باشد، بررسی کنید.

**آیا می‌توانم فایل PPT محافظت‌شده با رمزعبور را تبدیل کنم؟**

بله، در صورتی که هنگام بارگذاری فایل رمز صحیح را ارائه دهید. عدم وجود یا نادرستی رمز باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

تا زمانی که PPTX را در نمایندگان و جریان‌های کاری که برای شما مهم‌اند، تأیید نکرده‌اید، نسخه اصلی را نگه دارید. این کار یک نسخه بازگشتی در صورت متفاوت تبدیل ویژگی‌های میراثی فراهم می‌کند.