---
title: صادرات ارائه‌ها به XAML در JavaScript
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/nodejs-java/export-to-xaml/
keywords:
- صادرات PowerPoint
- صادرات OpenDocument
- صادرات ارائه
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- PowerPoint به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به صورت XAML
- ذخیره PPTX به صورت XAML
- ذخیره ODP به صورت XAML
- صادرات PPT به XAML
- صادرات PPTX به XAML
- صادرات ODP به XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML در JavaScript با استفاده از Aspose.Slides—راه‌حل سریع، بدون نیاز به Office که طرح‌بندی شما را به‌صورت یکپارچه حفظ می‌کند."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کنید. شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید و نحوه سفارشی‌سازی صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) نشان می‌دهد، از جمله صادرات اسلایدهای مخفی. همچنین به چند سؤال رایج در مورد فونت‌های پیش‌فرض، سازگاری پشته XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان نشانه‌گذاری مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با یک طراح بصری با فایل‌های XAML کار کنید یا نشانه‌گذاری را به‌صورت مستقیم بنویسید و ویرایش کنید.

## **صادر کردن ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال JavaScript زیر نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

به‌صورت پیش‌فرض، اسلایدهای صادر شده در یک زیرپوشهٔ `input` از پوشهٔ کاری فعلی فرآیند ذخیره می‌شوند. این پوشه به‌صورت خودکار ساخته می‌شود و هر تصویر مورد نیاز نیز در همانجا ذخیره می‌شود.

نام پوشه خروجی از نام فایل منبع بدون پسوند آن گرفته می‌شود. در Aspose.Slides برای Node.js via Java 26.8، صادرات `input.pptx` مسیر تو در تویی مانند `input/input/Slide_1.xaml` تولید می‌کند. هنگام کار با خروجی تمام مسیرهای تولید شده را حفظ کنید. خروجی پیش‌فرض نسبت به پوشهٔ کاری فعلی نسبی است، نه لزوماً در کنار فایل ورودی.

## **صادر کردن ارائه‌ها به XAML با گزینه‌های سفارشی**

از رابط [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) برای کنترل نحوهٔ صادرات یک ارائه به XAML توسط Aspose.Slides استفاده کنید.

برای ذخیرهٔ خروجی در مکان سفارشی، کلاس [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) را پیاده‌سازی کنید و یک نمونه از پیاده‌سازی خود را به متد [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) از [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) بدهید.

برای شامل کردن اسلایدهای مخفی در خروجی XAML، متد [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) را با مقدار `true` صدا بزنید، همان‌طور که در مثال JavaScript زیر نشان داده شده است:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **دریافت همهٔ مصنوعات تولید شدهٔ XAML**

یک صادرات XAML می‌تواند برای هر اسلاید صادر شده یک سند XAML به‌ علاوهٔ تصاویر و منابع پشتیبان جداگانه تولید کند. یک [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) سفارشی را به [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) اختصاص دهید تا به‌جای استفاده از ذخیره‌کنندهٔ پیش‌فرض فایل‑سیستم، این مصنوعات را دریافت کنید. صادرات را با بارگذاری‌خاص [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) که گزینه‌های XAML را می‌پذیرد، آغاز کنید.

در Node.js، رابط جاوا را با `java.newProxy` از بستهٔ `java` که توسط Aspose.Slides استفاده می‌شود پیاده‌سازی کنید. پراکسی را تا پایان صادرات در دسترس نگه دارید.

### **درک چرخهٔ زندگی بازگشت فراخوانی**

صادرکننده به‌طور جداگانه برای هر مصنوع تولید شده متد [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) را فراخوانی می‌کند:

- `path` شناسایی‌کنندهٔ مصنوع است و ممکن است شامل مسیرهای نسبی باشد. این اطلاعات را حفظ کنید زیرا XAML می‌تواند به منابع با مسیرهای نسبی ارجاع دهد.
- `data` بایت‌های مصنوع را شامل می‌شود. تصاویر و سایر منابع باینری نباید به‌عنوان متن رمزگشایی شوند.
- ذخیره‌کننده مسئول حفظ یا نگهداری داده‌ها قبل از بازگشت است. مثال‌ها آرایهٔ بایت جاوا را به یک بافر Node.js متعلق به برنامه کپی می‌کنند.
- صادرات را تنها زمانی موفق بنامید که عملیات ذخیرهٔ ارائه بازگردد و تمام بازگشت‌ها با موفقیت تکمیل شوند. خطاهای ذخیره‌سازی را نادیده نگیرید و نوشتن پس‌زمینهٔ بدون نظارت را آغاز نکنید. اگر پایداری پس از آن اتفاق بیفتد، موفقیت کلی را تنها پس از موفقیت آن مرحله گزارش کنید.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) برای ذخیره‌کنندهٔ سفارشی نیز اعمال می‌شود. تنظیم پیش‌فرض `false` اسناد XAML اسلایدهای مخفی را حذف می‌کند. مقدار `true` آن‌ها و هر منبع مورد نیاز برای صادراتشان را شامل می‌شود. شمارش منابع به ارائه بستگی دارد؛ فرض نکنید یک بازگشت برای هر اسلاید یا ترتیب ثابت بازگشت‌ها وجود دارد.

### **صادرات به حافظه و بررسی مصنوعات**

این مثال کامل `input.pptx` را بارگذاری می‌کند، هر مصنوع را در یک نقشهٔ JavaScript از نام به بافر جمع‌آوری می‌کند و نام، نوع و تعداد بایت را چاپ می‌کند. نام‌های ارائه شده دقیقاً همان‌گونه که هستند حفظ می‌شوند. نام‌های تکراری مجموعه را نامعتبر می‌سازند به جای اینکه به‌صورت سایلنتی بر روی یک مصنوع بازنویسی شوند. مثال قبل از استفاده از نتایج این وضعیت را بررسی می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // فقط XAML را رمزگشایی کنید و فقط زمانی که نیاز به بررسی متنی باشد.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

بررسی پسوندها برای بازرسی مفید است؛ تمام مصنوعات، از جمله انواع منابع نا‌آشنا را حفظ کنید. هنگام ذخیره یا انتقال بایت‌ها، آن‌ها را دست نخورده نگه دارید. فقط برای XAML که نیاز به پردازش متنی دارد از رمزگشایی UTF‑8 استفاده کنید.

### **بسته‌بندی مصنوعات جمع‌آوری شده در یک آرشیو ZIP**

این مثال مستقل صادرات را جمع‌آوری، نام‌های آن را اعتبارسنجی و بایت‌های اصلی را در یک آرشیو ZIP با استفاده از پل جاوا می‌نویسد. ZIP در حافظه ساخته می‌شود سپس روی دیسک ذخیره می‌شود. نام آرشیو یکتا، کارهای صادراتی همزمان را جدا می‌کند. ورودی‌های ZIP از اسلش جلو استفاده می‌کنند و مسیرهای نسبی را حفظ می‌کنند. نام‌های ناامن یا نام‌هایی که پس از نرمال‌سازی تداخل می‌شوند، تمام بسته را پیش از نوشتن رد می‌کنند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // بستن، فهرست ZIP را پیش از ذخیرهٔ آرشیو تکمیل می‌کند.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

مثال از [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) برای نوشتن یک آرشیو محلی استفاده می‌کند؛ صادرکننده خود فایل‌های XAML یا تصویر را به‌صورت مستقل نمی‌نویسد. برای ذخیره‌سازی راه‌دور، مرحله نوشتن آرشیو را با بارگذاری آرایه‌های بایتی جمع‌آوری‌شده جایگزین کنید. از یک شناسهٔ کار صادرات به‌همراه نام نسبی کامل مصنوع به‌عنوان کلید blob استفاده کنید، یا شناسهٔ کار، نام نسبی و دادهٔ باینری را در یک ردیف پایگاه‌داده ذخیره کنید. پس از تکمیل تمام بارگذاری‌ها یا تأیید تراکنش پایگاه‌داده، کار را منتشر کنید. در صورت شکست پایداری، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، یک ذخیره‌کنندهٔ سفارشی می‌تواند هر مصنوع را مستقیماً در ذخیره‌سازی برنامه‌نویسی حفظ کند تا از نگه‌داشتن یک نسخهٔ اضافی از تمام صادرات در حافظه برنامه جلوگیری شود. هر بازگشت را از دید صادرکننده به‌صورت هم‌زمان نگه دارید: فقط پس از پذیرش بایت‌ها توسط مقصد بازگردید و اجازه دهید خطاها به فراخواننده برسند.

### **حفظ نام‌های منابع و تأیید ارجاعات**

- جداکننده‌های مسیر را وقتی مقصد نیاز دارد نرمال‌سازی کنید، اما مسیرهای نسبی را حفظ کنید. مگر این‌که هر نام تولید شده به‌صورت یکتا شناخته شود و ارجاعات منابع معتبر بمانند، فقط از پایهٔ نام استفاده نکنید.
- اعتبارسنجی نام مخصوص مقصد را اعمال کنید. هنگام نوشتن فایل‌های مستقل، مسیرهای ریشه‌ای و قطعات عبور مسیر را رد کنید، مقصد را به مسیر مطلق تبدیل کنید و اطمینان حاصل کنید که زیر مسیر مورد نظر برای صادرات می‌ماند؛ شامل جداکنندهٔ مسیر در بررسی نگهداری باشد. از یک پوشهٔ تحت‑کنترل برنامه بدون لینک‌های نمادین استفاده کنید که ممکن است نوشتارها را بازنویسی کنند.
- برای هر کار صادراتی یک ذخیره‌کننده و فضای نام جداگانه استفاده کنید. پس از نرمال‌سازی جداکننده‌ها و بر اساس قوانین حساسیت به حروف مقصد، تداخل‌ها را شناسایی کنید.
- قبل از انتشار، هر سند XAML را به‌عنوان XML تجزیه کنید و ارجاعات منابع مبتنی بر فایل آن را بررسی کنید، مانند ویژگی‌های `Source` یا `ImageSource` تصویر. هر URI نسبی را نسبت به پوشهٔ مصنوع XAML حامل حل کنید، نام ذخیرهٔ حاصل را نرمال‌سازی کنید و تأیید کنید که کلید نقشهٔ متناظر، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URIهای خارجی و عبارات علامت‌گذاری XAML را از نام‌های فایل نسبی جداگانه پردازش کنید.

به عنوان مثال، اگر `input/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به صورت `input/images/image1.png` در دسترس باشد. فقط نگه داشتن `image1.png` این رابطه را می‌شکند. برای ذخیره‌سازی شیء، همان ساختار زیر پیشوند کار را حفظ کنید و این URLهای منبع را برای مصرف‌کنندهٔ XAML در دسترس قرار دهید. ZIP تکمیل‌شده را باز کنید تا نام‌های ورودی و بایت‌های منبع را تأیید کنید و اسلایدهای نمایشی را در محیط XAML هدف بارگذاری کنید تا اطمینان حاصل شود تصاویر به‌درستی حل می‌شوند.

## **سؤالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که فونت‌ها پیش‌بینی‌پذیر هستند اگر فونت اصلی روی ماشین موجود نباشد؟**

در [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) متد [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) را فراخوانی کنید — این فونت به‌عنوان فونت پیش‌فرض هنگام صادرات استفاده می‌شود وقتی فونت اصلی موجود نباشد. این تضمین نمی‌کند XAML تولید شده به‌طور خودکار به فونت پیش‌فرض ارجاع دهد یا اینکه فونت بر روی ماشین هدف موجود باشد. اطمینان حاصل کنید فونت‌های ارجاع‌شده توسط XAML در محیطی که نمایش داده می‌شود موجود باشند.

**آیا XAML صادرشده فقط برای WPF منظور شده است یا می‌تواند در سایر پشته‌های XAML نیز استفاده شود؟**

Aspose.Slides XAML مخصوص WPF را از طریق API عمومی خود صادر می‌کند. سازگاری با سایر پشته‌های XAML مانند UWP و Xamarin.Forms تضمین نشده است. markup تولید شده را در محیط هدف خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آن‌ها جلوگیری کنم؟**

به‌صورت پیش‌فرض، اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را از طریق [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) در [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) کنترل کنید — اگر نیازی به صادرات آن‌ها ندارید این گزینه را غیرفعال نگه دارید.