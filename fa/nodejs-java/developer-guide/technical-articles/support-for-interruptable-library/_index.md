---
title: "لغو عملیات طولانی‌مدت ارائه در Node.js"
linktitle: "لغو عملیات ارائه"
type: docs
weight: 120
url: /fa/nodejs-java/support-for-interruptable-library/
keywords:
- "عملیات قابل لغو"
- "توکن قطع"
- "توکن لغو"
- "مهلت زمان تبدیل"
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "عملیات طولانی‌مدت ارائه را در Aspose.Slides برای Node.js از طریق Java لغو کنید، مهلت زمان تبدیل را تنظیم کنید و پیش از لغو، اسلایدهای صادر شده را پیگیری کنید."
---
## **نمای کلی**

Aspose.Slides برای Node.js از طریق Java از لغو عملیات هنگام بارگذاری، ذخیره یا رندر یک ارائه پشتیبانی می‌کند. همچنین می‌توانید همان توکن را در حلقه صادرات خود بررسی کنید تا قبل از اسلاید بعدی متوقف شوید و شماره اسلایدهای قبلاً ذخیره شده را برگردانید.

## **لغو عملیات ارائه**

یک [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/) ایجاد کنید، توکن آن را با [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) دریافت کنید و آن را به [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken) پاس دهید. از این گزینه‌ها هنگام ساختن یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) استفاده کنید. فراخوانی [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) روی منبع درخواست لغو عملیات جاری را می‌دهد. Aspose.Slides هنگامی که بار دیگر توکن را بررسی می‌کند، متوقف می‌شود.

### **تنظیم زمان‌سربرای تبدیل**

مثال زیر اجازه می‌دهد تا 20 ثانیه برای باز کردن `sample.pptx` و ذخیره آن به صورت `sample.pdf` صرف شود. هم سازنده و هم عملیات ذخیره به صورت ناهمزمان از طریق پل Java اجرا می‌شوند تا تایمر Node.js بتواند در هر یک از عملیات‌ها فعال شود. مثال پس از بارگذاری توکن را بررسی می‌کند و دوباره پس از ذخیره‌سازی، زیرا یک فراخوانی کتابخانه می‌تواند پس از درخواست لغو بازگردد. پس از پایان عملیات ارائه آزاد می‌شود و اگر تبدیل زودتر تمام شد، تایمر پاک می‌شود. اگر لغو در حین ذخیره رخ دهد، ممکن است فایل خروجی از قبل وجود داشته باشد و ناقص باشد.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

برای تبدیل به فرمت قدیمی PowerPoint با محدودیت 10 ثانیه، به عنوان سه آرگومان آخر، `"sample.ppt"`، `slides.SaveFormat.Ppt` و `10000` را پاس دهید.

## **متوقف شدن قبل از پردازش اسلاید بعدی**

قبل از هر صادرات، زمانی که فراخوان می‌تواند از نتیجه جزئی استفاده کند، از [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) استفاده کنید. overload [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) برای اسلایدهای انتخاب‌شده یک `int[]` جاوا از شماره اسلایدها که از 1 شروع می‌شود، می‌گیرد. هر شماره را فقط پس از ذخیره موفقیت‌آمیز PDF مربوطه ثبت کنید.

مثال را با یک ارائه به نام `sample.pptx` که حداقل دو اسلاید دارد اجرا کنید. برای نشان دادن لغو بین صادرات، مثال بلافاصله پس از ذخیره اسلاید اول درخواست لغو می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

مثال `slide-1.pdf` را می‌نویسد و `Starting slide 1` را چاپ می‌کند و سپس `Completed: [1]`. حلقه قبل از شروع اسلاید 2 لغو را مشاهده می‌کند. اگر خود ذخیره‌سازی قطع شود، فهرست بازگردانده‌شده فقط صادرات موفق قبلی را شامل می‌شود.

برای اینکه فراخوان لغو را به عنوان خطا مدیریت کند، بررسی و `break` آن در ابتدای حلقه را با [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) که به صورت `token.throwIfInterruptionRequested()` صدا می‌شود، جایگزین کنید. همان بررسی پرتاب‌شده را پس از ذخیره استفاده کنید و بلوک `try`/`catch` اطراف آن را حذف کنید. با همان ورودی، PDF اول همچنان نوشته می‌شود و تکرار دوم قبل از اینکه تابع بتواند فهرست را برگرداند، پرتاب می‌شود.

## **پرسش‌های متداول**

**چه زمانی باید درخواست لغو کنم؟**

در زمانی که مهلت پایان می‌یابد یا برنامه دیگر به نتیجه نیاز ندارد، درخواست لغو کنید. بارگذاری، ذخیره و رندر می‌توانند همگی از توکنی که هنگام ساخت ارائه پاس داده می‌شود، استفاده کنند.

**منبع و توکن چه تفاوتی دارند؟**

منبع به برنامه اجازه می‌دهد درخواست لغو را بدهد. توکن به Aspose.Slides و کد شما امکان بررسی این درخواست را می‌دهد.

**آیا تایمر Node.js می‌تواند ذخیره‌سازی هم‌زمان را قطع کند؟**

ذخیره‌سازی هم‌زمان JavaScript را در نخ فراخوان مسدود می‌کند. از تماس‌های ناهمزمان پل Java که در مثال زمان‌سربرایی نشان داده شده استفاده کنید تا تایمر بتواند در حین اجرای ذخیره‌سازی درخواست لغو را بدهد.

**آیا لغو بلافاصله اثر می‌گذارد؟**

لغو تعاونی است. یک عملیات در حال اجرا زمانی که درخواست را مشاهده کند متوقف می‌شود. عملیاتی که قبلاً تمام شده است، نتیجه خود را حفظ می‌کند.

**آیا چند عملیات می‌توانند یک منبع را به اشتراک بگذارند؟**

بله. فراخوانی `interrupt()` درخواست لغو را برای هر عملیاتی که از توکنی از آن منبع استفاده می‌کند، می‌دهد. برای هر عملیاتی که می‌خواهید به‌طور مستقل لغو شود، از منبع جداگانه‌ای استفاده کنید.