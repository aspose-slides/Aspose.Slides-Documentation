---
title: تبدیل ارائه‌های پاورپوینت به مارک‌داون در جاوااسکریپت
linktitle: پاورپوینت به مارک‌داون
type: docs
weight: 140
url: /fa/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- پاورپوینت به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره پاورپوینت به عنوان Markdown
- ذخیره ارائه به عنوان Markdown
- ذخیره اسلاید به عنوان Markdown
- ذخیره PPT به عنوان MD
- ذخیره PPTX به عنوان MD
- صادر کردن PPT به MD
- صادر کردن PPTX به MD
- صادرات تصویر Markdown
- لینک‌های تصویر CDN
- پاورپوینت
- ارائه
- مارک‌داون
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "تبدیل ارائه‌های PPT و PPTX به مارک‌داون در جاوااسکریپت و کنترل مکان ذخیره‌سازی و ارجاع تصاویر bitmap، metafile و SVG صادر‌شده."
---
## **نمای کلی**

Aspose.Slides برای Node.js از طریق Java می‌تواند ارائه‌های PPT و PPTX را به Markdown برای مستندسازی، سایت ایستا، مهاجرت محتوا و جریان‌های کاری کنترل نسخه تبدیل کند. می‌توانید یک طعم Markdown را انتخاب کنید، نحوه رندر محتوای اسلاید را کنترل کنید، و تعیین کنید که تصاویر صادر شده در کجا ذخیره شوند و Markdown تولید شده آن‌ها را چگونه ارجاع دهد.

به طور پیش‌فرض، صادرات Markdown خروجی فقط متنی دارد. برای صادرات محتوای بصری، نوع صادرات را با روش [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) به مقدار `Sequential` یا `Visual` از enum [MarkdownExportType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownexporttype/) تنظیم کنید. `Sequential` موارد اسلاید را به صورت جداگانه و به ترتیب رندر می‌کند، در حالی که `Visual` موارد گروه‌بندی‌شده را حفظ می‌کند تا رابطه بصری آن‌ها را نگه دارد. مقدار `TextOnly` منابع تصویری تولید نمی‌کند، بنابراین فراخوانی‌های ذخیره‌سازی تصویر در آن حالت اجرا نمی‌شوند.

## **تبدیل یک ارائه به Markdown**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید، سپس متد [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را با مقدار `Md` از enum [SaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) صدا بزنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **انتخاب طعم Markdown**

متد [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) مشخص می‌کند که کدام مشخصات Markdown برای خروجی استفاده شود. enum [Flavor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/flavor/) شامل CommonMark، GitHub Flavored Markdown و سایر واریانت‌های پشتیبانی‌شده است.

مثال زیر یک ارائه را به صورت CommonMark صادر می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **صادرات تصاویر با رفتار ذخیره‌سازی محلی پیش‌فرض**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) دو متد برای پیکربندی ذخیره‌سازی محلی تصاویر ارائه می‌دهد:

- [setBasePath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) مسیر پایه برای سند Markdown و منابع آن را مشخص می‌کند.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) زیرپوشه تصویر را تعیین می‌کند. مقدار پیش‌فرض آن `Images` است.

مثال زیر محتوای بصری را رندر می‌کند، تصاویر را در `output/assets` می‌نویسد و ارجاع‌های تصویر نسبی را در سند Markdown ایجاد می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

این رفتار همچنین به‌عنوان پس‌زمینه برای زمانی که یک هندلر ذخیره‌سازی سفارشی `false` برگرداند، استفاده می‌شود.

## **سفارشی‌سازی ذخیره‌سازی تصویر و لینک‌های Markdown**

از متد [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) برای ثبت یک کال‌بک برای منابع bitmap و metafile غیر‑SVG که در طول صادرات Markdown تولید می‌شوند، استفاده کنید. کال‌بک `MarkdownImageSavingHandler` یک شیء [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/)، مقدار [ImageFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imageformat/) و آرایهٔ رشتهٔ تک‌عضوی حاوی لینک Markdown تولید شده را دریافت می‌کند. تصویر را با فرمت فراهم‌شده ذخیره یا بارگذاری کنید و `link[0]` را با ارجاعی که باید در خروجی Markdown ظاهر شود، جایگزین کنید.

منابع تولید شده به فرمت SVG به‌صورت جداگانه مدیریت می‌شوند. با متد [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) یک کال‌بک ثبت کنید. کال‌بک `MarkdownSvgImageSavingHandler` یک شیء `ISvgImage` و آرایهٔ تک‌عضوی `link` را دریافت می‌کند. برای SVG آرگومان `ImageFormat` وجود ندارد؛ به‌جای آن دادهٔ XML را از متد `ISvgImage.getSvgData` بنویسید یا بارگذاری کنید. بسته به حالت صادرات و گروه‌بندی بصری، یک SVG در ارائه منبع ممکن است رستر یا با محتوای دیگر ترکیب شود؛ منبع غیر‑SVG حاصل سپس به کال‌بک ذخیره‌سازی تصویر ارسال می‌شود. هر دو کال‌بک را وقتی که هر منبع بصری صادرشده نیاز به پردازش سفارشی دارد، ثبت کنید.

در Node.js، پیاده‌سازی این اینترفیس‌های کال‌بک را با `java.newProxy` ایجاد کنید.

مقدار بازگشت هندلر تعیین می‌کند که چه کسی تصویر را پردازش می‌کند:

- پس از ذخیره، بارگذاری، تبدیل یا پردازش تصویر و اختصاص مقدار معتبر به `link[0]`، `true` برگردانید. Aspose.Slides آن مقدار را به سند Markdown می‌نویسد و ذخیره‌سازی محلی پیش‌فرض را انجام نمی‌دهد.
- برای اجازه به Aspose.Slides جهت ذخیره محلی تصویر و تولید لینک بر اساس مقادیری که با [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) و [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) تنظیم شده‌اند، `false` برگردانید.

{{% alert color="warning" title="Important" %}}
یک هندلر که `true` برمی‌گرداند، مسئولیت تصویر را بر عهده می‌گیرد. اگر بدون اختصاص لینک معتبر و غیرخالی `true` برگرداند، صادرات با `InvalidOperationException` شکست می‌خورد.
{{% /alert %}}

### **ذخیره تصاویر در یک دایرکتوری منبع CDN و استفاده از URLهای خارجی**

مثال زیر `cdn-origin/presentations/quarterly-report` را به‌عنوان دایرکتوری منبع CDN سوار شده یا همگام‌شده در نظر می‌گیرد. هر هندلر نام فایل ایجادشده را استخراج می‌کند، تصویر را در آن دایرکتوری سفارشی ذخیره می‌کند و ارجاع محلی تولیدشده را با یک URL عمومی CDN جایگزین می‌کند. نمونه خود عملیات بارگذاری شبکه‌ای انجام نمی‌دهد: URL تنها پس از سوار شدن دایرکتوری به عنوان منبع CDN یا انتشار فایل‌ها در CDN معتبر می‌شود. برای ذخیره‌سازی شیء، نوشتن در سیستم فایل را با عملیات بارگذاری SDK ذخیره‌سازی جایگزین کنید و `link[0]` را تنها پس از موفقیت بارگذاری اختصاص دهید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

هندلر bitmap عمداً برای تصاویری که کوچک‌تر از 128 × 128 پیکسل هستند `false` برمی‌گرداند، بنابراین Aspose.Slides این تصاویر را به‌طور پیش‌فرض در `output/fallback-images` ذخیره می‌کند. منابع bitmap و metafile بزرگ‌تر، همراه با منابع SVG، توسط کد سفارشی پردازش می‌شوند. برای مثال، یک ارجاع محلی تولیدشده مانند `fallback-images/image1.png` به `https://cdn.example.com/presentations/quarterly-report/image1.png` تبدیل می‌شود. هندلرها فقط هنگام نوشتن فایل‌ها از مسیرهای سیستم‌عامل استفاده می‌کنند؛ لینک‌های نوشته‌شده در Markdown از خطوط مورب (`/`) و نام فایل‌های URL‑escaped استفاده می‌کنند. همین قاعده را هنگام ساخت لینک‌های نسبی اعمال کنید: از `/` استفاده کنید، نه جداکنندهٔ پلتفرم‑خاص.

## **FAQ**

**آیا یک هندلر می‌تواند هم تصاویر رستری و هم تصاویر SVG را پردازش کند؟**

خیر. برای منابع bitmap و metafile تولیدشده از [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) استفاده کنید و برای منابع تولیدشده به صورت SVG از [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) استفاده کنید. اولی یک شیء [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) و مقدار [ImageFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imageformat/) ارائه می‌دهد؛ دومی یک شیء `ISvgImage` ارائه می‌دهد که دادهٔ SVG آن را می‌توان با `ISvgImage.getSvgData` خواند. یک SVG منبع که در زمان صادرات رستر می‌شود، به‌جای آن توسط کال‌بک ذخیره‌سازی تصویر پردازش می‌شود.

**هنگلر ذخیره‌سازی تصویر `false` برگرداند، چه می‌شود؟**

Aspose.Slides از رفتار ذخیره‌سازی محلی پیش‌فرض خود استفاده می‌کند. مکان تصویر و ارجاع تولیدشده توسط مقادیری که با [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) و [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) تنظیم شده‌اند، کنترل می‌شود.

**آیا یک هندلر می‌تواند بدون ذخیرهٔ محلی تصویر، فقط یک URL ارائه دهد؟**

بله. هندلر می‌تواند تصویر را در ذخیره‌سازی شیء بارگذاری کند یا به سرویس دیگری منتقل کند، URL حاصل را به `link[0]` اختصاص دهد و `true` برگرداند. هندلر باید پردازش را به‌طور کامل خود انجام دهد؛ بازگشت `true` مانع ذخیره‌سازی محلی پیش‌فرض می‌شود.

**چرا صادرات Markdown یک `InvalidOperationException` از یک هندلر پرتاب می‌کند؟**

این استثنا زمانی رخ می‌دهد که هندلر `true` برگرداند اما لینک معتبری ارائه ندهد. مسیر نسبی یا URL خارجی‌ای که باید در Markdown نوشته شود را قبل از بازگشت `true` به `link[0]` اختصاص دهید.

**کدام جداکننده مسیر باید در لینک‌های تصویر استفاده شود؟**

در لینک‌های Markdown و URLها از خطوط مورب (`/`) استفاده کنید. برای مسیرهای سیستم‌فایل فقط از `path.join` استفاده کنید و سپس مرجع Markdown را جداگانه بسازید یا نرمال‌سازی کنید.

**آیا پیوندهای متنی در طول صادرات Markdown حفظ می‌شوند؟**

بله. پیوندهای متنی [hyperlinks](/slides/fa/nodejs-java/manage-hyperlinks/) به‌صورت لینک‌های استاندارد Markdown حفظ می‌شوند. انتقال‌های اسلاید [transitions](/slides/fa/nodejs-java/slide-transition/) و انیمیشن‌های اسلاید [animations](/slides/fa/nodejs-java/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توان ارائه‌ها را به صورت موازی به Markdown تبدیل کرد؟**

می‌توانید فایل‌های ارائه مختلف را به‌صورت موازی پردازش کنید، اما نباید همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک بگذارید. دستورالعمل‌های [multithreading guidelines](/slides/fa/nodejs-java/multithreading/) را دنبال کنید و برای هر فایل یک نمونهٔ جداگانه استفاده کنید.