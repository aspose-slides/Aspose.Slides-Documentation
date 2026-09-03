---
title: مدیریت هشدارهای ارائه در Node.js
type: docs
weight: 90
url: /fa/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- فراخوانی هشدار
- سیاست هشدار
- از دست رفتن داده
- فساد منبع
- مشکل سازگاری
- جایگزینی قلم
- امضای دیجیتال
- بارگذاری ارائه
- رندر ارائه
- تبدیل ارائه
- ذخیره ارائه
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "یاد بگیرید چگونه هشدارها را هنگام بارگذاری، رندر، تبدیل و ذخیره ارائه‌ها با Aspose.Slides برای Node.js از طریق Java جمع‌آوری، طبقه‌بندی و اقدام کنید."
---
## **مروری کلی**

Aspose.Slides می‌تواند مشکلات قابل‌بازیابی را هنگام بارگذاری، رندر، تبدیل یا ذخیره یک ارائه گزارش کند. نمونه‌ها شامل رکوردهای خراب منبع، محتواهایی که نمی‌توان حفظ کرد، جایگزینی قلم و محدودیت‌های قالب هدف است. یک callback هشدار به برنامه اجازه می‌دهد این شرایط را ثبت کند و تصمیم بگیرد آیا عملیات جاری می‌تواند ادامه یابد یا نه.

از `java.newProxy` برای پیاده‌سازی اینترفیس Java [IWarningCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarningcallback/) در JavaScript استفاده کنید و مقادیر [getWarningType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) ارائه‌شده توسط [IWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/) را بررسی کنید. برای پذیرش هشدار، [ReturnAction.Continue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/returnaction/#Continue) را برگردانید یا برای متوقف کردن عملیات، [ReturnAction.Abort](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/returnaction/#Abort) را برگردانید.

از [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) برای هشدارهایی که هنگام باز کردن یک ارائه رخ می‌دهد، استفاده کنید. کلاس‌های گزینه رندر و خروجی، [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) را به ارث می‌برند؛ این متد هشدارهای ناشی از رندر اسلاید، تبدیل و ذخیره‌سازی را دریافت می‌کند. از آنجا که خود هشدار عملیات برنامه را مشخص نمی‌کند، هنگام ساخت یک گزارش ترکیبی، هر نمونه callback را با مرحله عملیات مربوطه مرتبط کنید.

## **هشدارها و استثنائات**

هشدار توصیف‌گر شرایطی است که Aspose.Slides می‌تواند از آن بازیابی شود، به شرطی که callback `ReturnAction.Continue` برگرداند. استثنا به این معناست که عملیات درخواست‌شده نمی‌تواند به‌صورت عادی تکمیل شود؛ استثناها به هشدار تبدیل نمی‌شوند و نمی‌توانند توسط یک سیاست هشدار مدیریت شوند.

برگرداندن `ReturnAction.Abort` باعث می‌شود dispatcher هشدار، عملیات جاری را با پرتاب یک استثنا خاتمه دهد. نوع استثنای عمومی وابسته به عملیات و قالب ارائه است. به عنوان مثال، بارگذاری ممکن است یک [PptxReadException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxreadexception/) یا [PptReadException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptreadexception/) ایجاد کند، در حالی که ذخیره یا خروجی ممکن است یک [PptxException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxexception/) ایجاد کند. خطا را از پل Java در مرز عملیات دریافت کنید و از گزارش هشدار برای تعیین این‌که آیا سیاست برنامه باعث خاتمه شد یا نه، استفاده کنید، نه فقط بر یک زیرنوع یا پیام استثنا تکیه کنید. callback قبل از برگرداندن `ReturnAction.Abort` هشدار را ثبت می‌کند تا دلیل آن برای برنامه در دسترس بماند.

## **دسته‌بندی‌های هشدار**

کلاس [WarningType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/warningtype/) ثابت‌های عددی زیر را برای دسته‌های زیر فراهم می‌کند:

| نوع هشدار | معنی | سیاست معمول |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | ارائه منبع شامل فساد است که می‌تواند سند ذخیره‌شده در قالب اصلی را غیرقابل استفاده کند. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/warningtype/#DataLoss) | پس از بارگذاری یا ذخیره‌سازی، متن، نمودارها، تصاویر یا سایر داده‌ها ممکن است غائب شوند. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | ارائه ممکن است قالب‌بندی مهمی را از دست بدهد. | Abort در حالت اعتبارسنجی سخت؛ در غیر اینصورت ثبت و ادامه. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | اختلاف قالب‌بندی محدود ممکن است رخ دهد. | ثبت برای تشخیص و ادامه. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | ممکن است نتیجه در برخی برنامه‌ها یا نسخه‌های قدیمی به درستی باز نشود یا رفتار متفاوتی داشته باشد. | ثبت و ادامه مگر اینکه سازگاری اجباری باشد. |
| [UnexpectedContent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | منبع شامل محتوای پشتیبانی‌نشده یا شناخته‌نشده است که اثر آن ممکن است هنوز شناخته‌شده نباشد. | ثبت و ادامه، یا در سیاست سخت به عنوان خطا در نظر گرفتن. |

دسته‌بندی باید تصمیم‌گیری سیاستی را هدایت کند. مقدار بازگشتی توسط [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) را برای تشخیص‌های عیب‌یابی ذخیره کنید، اما برای منطق برنامه به متن آن تکیه نکنید زیرا متن پیام می‌تواند بین سناریوهای هشدار و نسخه‌های محصول متفاوت باشد.

## **جمع‌آوری و دسته‌بندی هشدارها**

مثال JavaScript زیر از یک گزارش سطح برنامه برای کل خط لوله پردازش استفاده می‌کند. یک نمونه callback جداگانه هشدارهای ناشی از بارگذاری، رندر، تبدیل به PDF و ذخیره‌سازی PPTX را برچسب‌گذاری می‌کند. سیاست در صورت فساد منبع یا از دست رفتن داده‌ها متوقف می‌شود، به‌صورت اختیاری در صورت از دست رفتن قالب‌بندی بزرگ متوقف می‌شود و برای سایر هشدارها ادامه می‌دهد.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

در هنگام ساخت `WarningPolicy`، اگر اختلافات بزرگ قالب‌بندی قابل‌قبول باشند، `false` را برای `abortOnMajorFormattingLoss` پاس دهید. مسائل سازگاری، از دست رفتن قالب‌بندی جزئی و محتوای غیرمنتظره همچنان در گزارش باقی می‌مانند حتی وقتی عملیات ادامه می‌یابد. اگر برنامه باید هر یک از این دسته‌ها را رد کند، `WarningPolicy.getAction` را گسترش دهید.

## **سناریوهای رایج هشدار**

هشدارها می‌توانند در مراحل مختلف یک جریان کار ظاهر شوند:

- **امضای دیجیتال:** یک ارائه امضا‌شده ممکن است در هنگام بارگذاری هشداری ایجاد کند که امضای آن در طول پردازش از دست خواهد رفت. Aspose.Slides این وضعیت `DataLoss` را از طریق [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationsignedwarninginfo/) گزارش می‌کند. یک callback در مرحله بارگذاری به برنامه اجازه می‌دهد فایل را رد کند یا به‌صراحت فقدان گزارش‌شده را بپذیرد.
- **جایگزینی قلم:** یک قلم نا‌در دسترس می‌تواند در هنگام رندر یا خروجی‌گیری یک اسلاید جایگزین شود. هشدارهای جایگزینی قلم به عنوان `DataLoss` گزارش می‌شوند؛ بنابراین سیاست سخت بالا حتی اگر برنامه جایگزینی خاصی را از نظر بصری قابل‌قبول ببیند، متوقف می‌شود. برای مشاهده این رفتار، از یک ارائه ورودی حاوی متن با قلم غیردسترس برای زمان اجرا استفاده کنید. توضیح هشدار جایگزینی را شناسایی می‌کند؛ قلم‌های مورد نیاز یا [قوانین جایگزینی قلم](/slides/fa/nodejs-java/font-substitution/) را قبل از تلاش مجدد پیکربندی کنید.
- **محتوای پشتیبانی‌نشده یا غیرمنتظره:** یک بارگذار ممکن است با رکوردها یا ویژگی‌های ارائه‌ای مواجه شود که شناخته نمی‌شوند. چنین هشدارهایی ممکن است از `UnexpectedContent` استفاده کنند یا در صورت تأثیر داده یا قالب‌بندی، دسته‌ای شدیدتر داشته باشند.
- **سازگاری قالب:** ذخیره به قالب دیگری ممکن است ویژگی‌هایی را حذف کند یا نتیجه‌ای تولید کند که در برخی برنامه‌ها به‌طرز متفاوتی رفتار کند. به‌عنوان مثال، ذخیره یک ارائه با بیش از هشت راهنمای افقی یا عمودی به PPT قدیمی، `CompatibilityIssue` گزارش می‌کند. callback در مرحله ذخیره می‌تواند این فقدان را ثبت کرده و ادامه دهد یا در صورت نیاز به حفظ همه راهنماها، آن را رد کند.
- **رفتار بارگذاری:** گزینه‌های بارگذاری و رفتارهای قدیمی نیز می‌توانند هشدار ایجاد کنند. به‌عنوان مثال، [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) استفاده از رفتار قفل‌گذاری ارائه منسوخ را به‌عنوان `CompatibilityIssue` شناسایی می‌کند.

هشدارها به سند منبع، قالب هدف، عملیات و نسخه Aspose.Slides وابسته‌اند. فرض نکنید هر فایلی هشدار تولید می‌کند یا یک سناریو همیشه به یک دسته محدود می‌شود.

## **مدیریت ایمن عملیات متوقف‌شده**

زمانی که یک callback `ReturnAction.Abort` برگرداند، از شیئی که بارگذاری نشده استفاده نکنید و فرض نکنید خروجی رندر یا ذخیره‌سازی کامل است. عملیات ممکن است پس از ایجاد یک فایل خروجی اما پیش از اتمام آن خاتمه یابد.

نتایج معتبر را در مسیر جداگانه‌ای مانند `validated-output.pptx` ذخیره کنید. پس از اتمام موفقیت‌آمیز عملیات، رضایت گزارش هشدار با سیاست برنامه و توانایی بازکردن و بررسی خروجی، ارائه اصلی را جایگزین کنید. این کار از نوشتن روی یک فایل منبع معتبر با نتیجه جزئی یا ردشده جلوگیری می‌کند.

یک گزارش هشدار خالی تضمین نمی‌کند که هر ویژگی منبع حفظ شده است. هر بررسی محتوایی و بصری اضافی که برنامه نیاز دارد را اعمال کنید. همچنین به [Open Presentations](/slides/fa/nodejs-java/open-presentation/) و [Save Presentations](/slides/fa/nodejs-java/save-presentation/) مراجعه کنید.

## **سوالات متداول**

**آیا یک callback هشدار می‌تواند هر خطای Aspose.Slides را مدیریت کند؟**

خیر. این فقط شرایط قابل‌بازیابی گزارش‌شده به‌صورت هشدار را مدیریت می‌کند. استثناهایی که مستقل از callback رخ می‌دهند باید توسط برنامه در اطراف فراخوانی بارگذاری، رندر، تبدیل یا ذخیره‌سازی مدیریت شوند.

**آیا برگرداندن `ReturnAction.Continue` خروجی یکسانی را تضمین می‌کند؟**

خیر. این فقط اجازه ادامه پردازش را می‌دهد. وضعیت گزارش‌شده همچنان می‌تواند باعث اختلاف داده، قالب‌بندی یا سازگاری شود؛ بنابراین نوع‌های هشدار جمع‌آوری‌شده و توضیحات را مرور کنید.

**چگونه یک برنامه می‌تواند عملیات تولیدکننده هشدار را شناسایی کند؟**

برای هر عملیات یک نمونه callback ایجاد کنید و مرحله تعریف‌شده توسط برنامه را همراه با مقادیر بازگردانده توسط [getWarningType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) ذخیره کنید، همان‌طور که در مثال نشان داده شده است.