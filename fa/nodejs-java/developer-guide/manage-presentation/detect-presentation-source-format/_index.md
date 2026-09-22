---
title: تعیین فرمت اصلی ارائه در Node.js
linktitle: فرمت منبع
type: docs
weight: 35
url: /fa/nodejs-java/detect-presentation-source-format/
keywords:
- فرمت منبع
- تشخیص فرمت ارائه
- پاورپوینت
- OpenDocument
- ارائه
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "فرمت اصلی یک ارائه بارگذاری‌شده را در Node.js با Aspose.Slides برای Node.js از طریق Java بخوانید، API‌های تشخیص را مقایسه کنید و فایل‌ها، جریان‌ها و فرمت‌های قدیمی را مدیریت کنید."
---
## **بررسی کلی**

پس از بارگذاری یک ارائه، متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSourceFormat) را فراخوانی کنید تا فرمت اصلی آن را تعیین کنید. زمانی که پردازش‌های بعدی به فرمت منبعی که نمونه جاری از آن بارگذاری شده وابسته است، از این متد استفاده کنید.

فرمت منبع با [SaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) که برای یک فایل خروجی انتخاب می‌شود، متفاوت است. ذخیره به فرمت دیگر فرمت منبع نمونه موجود را تغییر نمی‌دهد.

## **خواندن فرمت منبع یک فایل**

این مثال به فایلی موجود به نام `sample.pptx` نیاز دارد. فایل را بارگذاری می‌کند و به جای نام فایل، از متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSourceFormat) برای انتخاب سیاست پردازش برنامه استفاده می‌کند. مسیر ورودی را تغییر دهید تا فرمت‌های دیگر را آزمایش کنید. مثال مقدار سیاست انتخاب‌شده را چاپ می‌کند؛ پیام‌ها را با منطق برنامه خود جایگزین کنید.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **تشخیص مقادیر پشتیبانی‌شده**

کلاس [SourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sourceformat/) ثابت‌های عددی را تعریف می‌کند که فرمت‌های ارائه زیر را از هم متمایز می‌کند. پسوندهای زیر پسوندهای مرسوم هستند و بازسازی نام اصلی فایل نیستند.

| مقدار SourceFormat | پسوند | فرمت |
| --- | --- | --- |
| `Ppt` | `.ppt` | ارائه PowerPoint 97–2003 |
| `Pptx` | `.pptx` | ارائه Office Open XML |
| `Pptm` | `.pptm` | ارائه Office Open XML با ماکرو |
| `Pps` | `.pps` | نمایش اسلاید PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | نمایش اسلاید Office Open XML |
| `Ppsm` | `.ppsm` | نمایش اسلاید Office Open XML با ماکرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML با ماکرو |
| `Odp` | `.odp` | ارائه OpenDocument |
| `Otp` | `.otp` | قالب ارائه OpenDocument |
| `Fodp` | `.fodp` | ارائه Flat XML ODF |
| `Xml` | `.xml` | ارائه PowerPoint XML |

## **خواندن فرمت منبع یک جریان**

این مثال به فایلی موجود به نام `sample.pps` نیاز دارد. خواندن بایت‌های آن در یک جریان حافظه، ورودی بدون نام فایل (مانند مقدار پایگاه داده یا آرایه بایت‌آپلود شده) را شبیه‌سازی می‌کند. سازنده [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) فقط جریان را دریافت می‌کند.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT، PPS و POT از فرمت دودویی یکسان استفاده می‌کنند. هنگام بارگذاری بر حسب مسیر فایل، پسوند می‌تواند به تشخیص نمایش اسلاید یا قالب کمک کند. بدون نام فایل، محتویات قدیمی PPS و POT ممکن است به عنوان `SourceFormat.Ppt` گزارش شوند؛ مثال PPS بالا مقدار عددی `SourceFormat.Ppt` را چاپ می‌کند.

اگر برنامه شما باید این تمایز را حفظ کند، نام فایل اصلی یا متادیتای زیرنوع را به‌صورت جداگانه نگه دارید. پسوند یک نکته مفید برای این زیرنوع‌های قدیمی است، اما نباید تنها معیار شناسایی محتویات ارائه دلخواه باشد.

## **مقایسه تشخیص قبل و بعد از بارگذاری**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) هنگامی که نیاز به بازرسی فایل قبل از بارگذاری کامل مدل شیء ارائه دارید، استفاده کنید. هنگامی که نمونه قبلاً وجود دارد، از [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSourceFormat) استفاده کنید.

این مثال به `sample.pptx` نیاز دارد و مقادیر عددی `LoadFormat.Pptx` و `SourceFormat.Pptx` را به ترتیب چاپ می‌کند. در محیط تولید، API مناسب مرحله پردازش خود را انتخاب کنید؛ یک ارائه‌ی بارگذاری‌شده نیازی به بازرسی دوم صرفاً برای دریافت فرمت منبع ندارد.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

نتایج از ثابت‌های کلاس‌های مختلف استفاده می‌کنند: [LoadFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sourceformat/). مقادیر عددی آن‌ها را مقایسه نکنید و فرض نکنید که هر فرمت نتایج تشخیص یکسانی دارد. PowerPoint XML می‌تواند قبل از بارگذاری به عنوان `LoadFormat.Unknown` گزارش شود و بعد از بارگذاری به عنوان `SourceFormat.Xml`.

## **نگهداری جداگانه فرمت منبع و خروجی**

این مثال به `sample.pptx` نیاز دارد و `converted.odp` را می‌نویسد. مقدار عددی `SourceFormat.Pptx` را هم قبل و هم بعد از ذخیره‌سازی نمونه اصلی چاپ می‌کند. تنها نمونه جدید بارگذاری‌شده از خروجی ODP، `Odp` را گزارش می‌دهد.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

یک ارائه‌ی ایجاد شده از صفر با `new Presentation()`، `SourceFormat.Pptx` را گزارش می‌کند. این ارائه ورودی فایل ندارد: این مقدار پیش‌فرض برای یک نمونه تازه ایجادشده است، نه مدرکی بر اینکه فایلی PPTX بارگذاری شده است. اگر این تمایز برای برنامه شما مهم است، به‌صورت جداگانه پیگیری کنید که نمونه ایجاد شده یا بارگذاری شده است.

## **نقشه‌برداری فرمت منبع به پسوند**

مثال زیر به `sample.pptx` نیاز دارد. هر مقدار فعلی پشتیبانی‌شده از [SourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sourceformat/) را به یک پسوند مرسوم نگاشت می‌کند، بدون این که نام فایل ورودی را تجزیه کند. پیش‌فرض از اختصاص بی‌صدا پسوند به مقدار نامشخص جلوگیری می‌کند.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

این نگاشت فایلی را تبدیل یا زیرنوع قدیمی PPS/POT که در طول بارگذاری جریان از دست رفته است، باز نمی‌گرداند. برای ذخیره واقعی، یک [SaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) را به‌طور صریح انتخاب کنید یا از تبدیل نشان داده شده در [Save Presentations in Their Original Format](/slides/fa/nodejs-java/save-presentation/#save-presentations-in-their-original-format) استفاده کنید.

## **تأیید فرمت‌ها با ذخیره و بازگشایی**

این مثال خودکفا یک ارائه ایجاد می‌کند و سه فایل در پوشه کاری می‌نویسد، فایل‌های هم‌نام را بازنویسی می‌کند. هر خروجی را هم از مسیر و هم از یک جریان حافظه باز می‌کند. برای PPTX و ODP، هر دو مسیر فرمت ذخیره‌شده را گزارش می‌دهند. برای PPS، بارگذاری از مسیر `Pps` را گزارش می‌کند، در حالی که بارگذاری همان بایت‌ها بدون نام فایل `Ppt` را گزارش می‌دهد.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| فرمت ذخیره‌شده | SourceFormat از مسیر فایل | SourceFormat از جریان بدون نام |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | به ترتیب `Pptx`، `Pptm` | همانند مسیر فایل |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | به ترتیب `Ppsx`، `Ppsm` | همانند مسیر فایل |
| POT | `Pot` | `Ppt` |
| POTX, POTM | به ترتیب `Potx`، `Potm` | همانند مسیر فایل |
| ODP, OTP | به ترتیب `Odp`، `Otp` | همانند مسیر فایل |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتویات PPS/POT برای جریان‌های بدون نام به عنوان `Ppt` شناسایی می‌شوند. جدول شناسایی فرمت را توصیف می‌کند، نه حفظ تمام ویژگی‌های ارائه در طول تبدیل.

## **سؤالات متداول**

**آیا ذخیره به ODP فرمت منبع یک ارائه که از PPTX بارگذاری شده را تغییر می‌دهد؟**

خیر. نمونه موجود همچنان `Pptx` را گزارش می‌دهد. نمونه‌ای که از فایل ODP ذخیره‌شده بارگذاری می‌شود، `Odp` را گزارش می‌کند.

**آیا یک جریان همیشه می‌تواند یک ارائهٔ قدیمی، نمایش اسلاید یا قالب را متمایز کند؟**

خیر. PPT، PPS و POT فرمت دودویی یکسانی دارند. هنگام نیاز به این تمایز، نام فایل یا متادیتای زیرنوع را به‌صورت جداگانه نگه دارید.

**کدام API را باید استفاده کنم اگر ارائه قبلاً بارگذاری شده باشد؟**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSourceFormat) را بخوانید. برای بازرسی قبل از بارگذاری، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) استفاده کنید.