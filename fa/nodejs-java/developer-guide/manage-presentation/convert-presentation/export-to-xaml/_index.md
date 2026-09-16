---
title: صادرات ارائه‌ها به XAML در جاوااسکریپت
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
- ذخیره PPT به‌صورت XAML
- ذخیره PPTX به‌صورت XAML
- ذخیره ODP به‌صورت XAML
- صادرات PPT به XAML
- صادرات PPTX به XAML
- صادرات ODP به XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML در جاوااسکریپت با استفاده از Aspose.Slides — راه‌حل سریع و بدون نیاز به Office که چیدمان شما را حفظ می‌کند."
---
## **نمای کلی**

این مقاله نحوهٔ صادرات ارائه‌های PowerPoint به XAML را با استفاده از Aspose.Slides توضیح می‌دهد. شامل معرفی مختصری از XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنیم و نحوهٔ سفارشی‌سازی صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/) شامل صادرات اسلایدهای مخفی نشان می‌دهد. همچنین به چند سؤال رایج در مورد فونت‌های جایگزین، سازگاری پشته XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان نشانه‌گذاری مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با یک طراح بصری با فایل‌های XAML کار کنید یا نشانه‌گذاری را به‌صورت مستقیم بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال زیر به زبان JavaScript نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

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

به‌صورت پیش‌فرض، اسلایدهای صادر شده در زیرپوشهٔ `input` از دایرکتوری کاری فعلی فرایند ذخیره می‌شوند. این پوشه به‌طور خودکار ساخته می‌شود و هر تصویری که نیاز باشد نیز در همانجا ذخیره می‌شود.

نام پوشهٔ خروجی از نام فایل منبع بدون پسوند آن گرفته می‌شود. در Aspose.Slides for Node.js via Java 26.8، صادرات `input.pptx` مسیری تو در تو مانند `input/input/Slide_1.xaml` تولید می‌کند. هنگام مدیریت خروجی، مسیرهای کامل تولید شده را حفظ کنید. خروجی پیش‌فرض نسبت به دایرکتوری کاری فعلی است، نه لزوماً در کنار فایل ورودی.

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

از رابط [IXamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloptions/) برای کنترل نحوهٔ صادرات یک ارائه به XAML توسط Aspose.Slides استفاده کنید.

برای ذخیرهٔ خروجی در مکان سفارشی، پیاده‌سازی [IXamlOutputSaver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloutputsaver/) را انجام داده و یک نمونه از پیاده‌سازی خود را به متد [setOutputSaver](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) از [XamlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/) پاس دهید.

برای شامل کردن اسلایدهای مخفی در خروجی XAML، متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) را با مقدار `true` فراخوانی کنید، همان‌طور که در مثال زیر JavaScript نشان داده شده است:

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

## **جمع‌آوری تمام artefact‑های XAML تولید شده**

یک صادرات XAML می‌تواند یک سند XAML برای هر اسلاید صادر شده به‌همراه تصاویر جداگانه و منابع پشتیبان تولید کند. برای دریافت این artefact‑ها به‌جای استفاده از ذخیره‌ساز پیش‌فرض فایل‌سیستم، یک [IXamlOutputSaver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloutputsaver/) سفارشی به [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) اختصاص دهید. صادرات را با متد overload مخصوص XAML از [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) که گزینه‌های XAML را می‌پذیرد، آغاز کنید.

در Node.js، این رابط Java را با `java.newProxy` از بستهٔ `java` که توسط Aspose.Slides استفاده می‌شود پیاده‌سازی کنید. پروکسی را تا پایان صادرات در دسترس نگه دارید.

### **درک دورهٔ حیات Callback**

صادرکننده برای هر artefact تولید شده، متد [IXamlOutputSaver.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) را به‌صورت جداگانه فراخوانی می‌کند:

- `path` شناسایی artefact را انجام می‌دهد و ممکن است شامل مسیرهای نسبی باشد. این اطلاعات را نگه دارید زیرا XAML ممکن است منابع را با مسیرهای نسبی ارجاع دهد.
- `data` حاوی بایت‌های artefact است. تصاویر و سایر منابع باینری نباید به‌عنوان متن رمزگشایی شوند.
- ذخیره‌ساز مسئول نگهداری یا پایدارسازی داده قبل از بازگشت است. مثال‌ها هر آرایهٔ بایت Java را به یک Buffer متعلق به برنامه در Node.js کپی می‌کنند.
- صادرات را تنها زمانی موفق بدانید که عملیات ذخیرهٔ ارائه بازگردد و تمام callbackها با موفقیت کامل شده باشند. خطاهای ذخیره‌سازی را نادیده نگیرید و نوشتن‌های پس‌زمینهٔ بدون نظارت را آغاز نکنید. اگر پایداری پس از آن انجام شد، موفقیت کلی را فقط پس از موفقیت این مرحله گزارش کنید.

متد [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) نیز برای ذخیره‌ساز سفارشی اعمال می‌شود. مقدار پیش‌فرض `false` اسناد XAML اسلایدهای مخفی را حذف می‌کند. مقدار `true` آن‌ها و هر منبع مورد نیاز برای صادرات را شامل می‌شود. تعداد منابع وابسته به ارائه است؛ فرض نکنید یک callback برای هر اسلاید یا ترتیب ثابت callbackها وجود دارد.

### **صادرات به حافظه و بررسی artefact‑ها**

این مثال کامل `input.pptx` را بارگذاری می‌کند، هر artefact را در یک Map JavaScript از نام به Buffer جمع‌آوری می‌کند و نام، نوع و تعداد بایت آن را چاپ می‌کند. نام‌های ارائه‌شده دقیقاً حفظ می‌شوند. نام‌های تکراری مجموعه را نامعتبر می‌سازند به‌جای این‌که به‌صورت ساکت یک artefact را بازنویسی کنند. مثال قبل از استفاده از نتایج این مورد را بررسی می‌کند.

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

        // فقط XAML را رمزگشایی کنید و فقط زمانی که بررسی متنی لازم است.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

بررسی پسوندها برای بازرسی مفید است؛ تمام artefact‑ها، از جمله انواع منابع نام‌آشنا را نگه دارید. هنگام ذخیره یا انتقال بایت‌ها را دست‌نخورده بگذارید. فقط برای XAML که نیاز به پردازش متنی دارد از رمزگشایی UTF‑8 استفاده کنید.

### **بسته‌بندی artefact‑های جمع‌آوری‌شده در یک آرشیو ZIP**

این مثال مستقل صادرات را جمع‌آوری، نام‌ها را اعتبارسنجی و بایت‌های اصلی را با استفاده از پل Java در یک آرشیو ZIP می‌نویسد. ZIP در حافظه ساخته می‌شود قبل از اینکه روی دیسک ذخیره شود. نام آرشیو منحصربه‌فرد، کارهای صادرات همزمان را جدا می‌کند. ورودی‌های ZIP از پیش‌تک‌ها استفاده می‌کنند و مسیرهای نسبی را حفظ می‌کنند. نام‌های ناامن یا نام‌هایی که پس از نرمال‌سازی تداخل داشته باشند، تمام بسته را قبل از نوشتن رد می‌کند.

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
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // بستن نهایی، فهرست ZIP را قبل از ذخیره‌سازی آرشیو نهایی می‌کند.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

مثال از [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) برای نوشتن یک آرشیو محلی استفاده می‌کند؛ خود صادرکننده فایل‌های XAML یا تصویر را به‌صورت جداگانه نمی‌نویسد. برای ذخیره‌سازی از راه دور، مرحله نوشتن آرشیو را با بارگذاری آرایه‌های بایتی جمع‌آوری‌شده جایگزین کنید. از یک شناسهٔ کار صادرات به‌همراه نام کامل نسبی artefact به‌عنوان کلید blob استفاده کنید، یا شناسهٔ کار، نام نسبی و دادهٔ باینری را در یک ردیف پایگاه‌داده ذخیره کنید. کار را فقط پس از تکمیل تمام بارگذاری‌ها یا commit تراکنش پایگاه‌داده منتشر کنید. اگر پایداری شکست خورد، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، یک ذخیره‌ساز سفارشی می‌تواند هر artefact را مستقیماً در ذخیره‌سازی برنامه بگذارد تا نیاز به نگهداری یک کپی دیگر از کل صادرات در حافظه برنامه نباشد. هر callback را از دید صادرکننده همزمان نگه دارید: فقط پس از این‌که مقصد بایت‌ها را پذیرفت برگردید و اجازه دهید خطاها به فراخوان‌دهنده برسند.

### **حفظ نام‌های منبع و تأیید ارجاعات**

- جداکنندگان مسیر را هنگام نیاز مقصد نرمال‌سازی کنید، اما مسیرهای نسبی را حفظ کنید. مگر این‌که هر نام تولید شده منحصربه‌فرد باشد و ارجاعات منابع معتبر بمانند، فقط نام پایه را استفاده نکنید.
- اعتبارسنجی نام مخصوص مقصد را اعمال کنید. هنگام نوشتن فایل‌های منفرد، مسیرهای ریشه‌ای و بخش‌های traversal را رد کنید، مقصد را به مسیر مطلق تبدیل کنید و اطمینان حاصل کنید که زیر مسیر مقصد export قرار دارد، شامل جداکنندهٔ مسیر در بررسی containment. از یک دایرکتوری کنترل‌شده توسط برنامه بدون لینک‌های نمادین که می‌توانند نوشتار را دوباره‌مسیر کنند، استفاده کنید.
- برای هر کار صادرات یک ذخیره‌ساز و فضای نام ذخیره‌سازی جداگانه استفاده کنید. پس از نرمال‌سازی جداکننده و بر اساس قوانین حساسیت به حروف مقصد، تداخل‌ها را شناسایی کنید.
- قبل از انتشار، هر سند XAML را به‌عنوان XML تجزیه کنید و ارجاعات منبع مبتنی بر فایل آن را بررسی کنید؛ مانند ویژگی‌های `Source` یا `ImageSource` تصویر. هر URI نسبی را نسبت به دایرکتوری artefact XAML حاوی‌کننده حل کنید، نام ذخیره‌سازی حاصل را نرمال‌سازی کنید و تأیید کنید که کلید map مربوطه، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URIهای خارجی و عبارات markup XAML را جدا از نام‌های فایل نسبی مدیریت کنید.

به‌عنوان مثال، اگر `input/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به‌عنوان `input/images/image1.png` در دسترس باشد. نگه‌داشتن فقط `image1.png` رابطهٔ فوق را می‌شکند. برای ذخیره‌سازی شیء، همان طرح‌بندی زیر پیشوند کار را حفظ کنید و این URLهای منبع را برای مصرف‌کننده XAML قابل دسترس کنید. ZIP کامل را دوباره باز کنید تا نام ورودی‌ها و بایت‌های منبع را تأیید کنید و اسلایدهای نمایشی را در محیط XAML هدف بارگذاری کنید تا اطمینان حاصل شود تصاویر به‌درستی حل می‌شوند.

## **پرسش‌های متداول**

**چگونه می‌توانم فونت‌های پیش‌بینی‌پذیر داشته باشم اگر فونت اصلی در ماشین موجود نباشد؟**

در [XamlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/) متد [setDefaultRegularFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) را فراخوانی کنید — این فونت به‌عنوان فونت جایگزین هنگام صادرات استفاده می‌شود اگر فونت اصلی موجود نباشد. این تضمین نمی‌کند که XAML تولید‌شده به فونت جایگزین ارجاع دهد یا اینکه این فونت در ماشین هدف موجود باشد. اطمینان حاصل کنید فونت‌های ارجاع‌شده توسط XAML در محیطی که نمایش داده می‌شود، موجود باشند.

**آیا XAML صادرشده فقط برای WPF است یا می‌تواند در دیگر پشته‌های XAML نیز استفاده شود؟**

Aspose.Slides XAML مخصوص WPF را از طریق API عمومی خود صادر می‌کند. سازگاری با سایر پشته‌های XAML مانند UWP و Xamarin.Forms تضمین نشده است. مارکاپ تولیدشده را در محیط هدف خود تست کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آن‌ها جلوگیری کنم؟**

به‌صورت پیش‌فرض اسلایدهای مخفی شامل نمی‌شوند. می‌توانید این رفتار را از طریق [setExportHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) در [XamlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/) کنترل کنید — اگر نیازی به صادرات آن‌ها ندارید، این گزینه را غیرفعال نگه دارید.