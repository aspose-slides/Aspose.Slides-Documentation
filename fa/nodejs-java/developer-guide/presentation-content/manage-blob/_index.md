---
title: مدیریت BLOBهای ارائه در JavaScript برای استفاده مؤثر از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/nodejs-java/manage-blob/
keywords:
- شیء بزرگ
- آیتم بزرگ
- فایل بزرگ
- افزودن BLOB
- صادرات BLOB
- افزودن تصویر به عنوان BLOB
- کاهش حافظه
- مصرف حافظه
- ارائه بزرگ
- فایل موقت
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "در JavaScript با Aspose.Slides برای Node.js، داده‌های BLOB را مدیریت کنید تا عملیات فایل‌های PowerPoint و OpenDocument را ساده‌سازی کرده و برای مدیریت مؤثر ارائه‌ها به کار ببرید."
---
## **نمای کلی**

Aspose.Slides پردازش مبتنی بر BLOB را برای داده‌های باینری بزرگ در ارائه‌ها فراهم می‌کند تا مصرف حافظه هنگام کار با تصاویر، صدا، ویدئو و فایل‌های ارائه بزرگ کاهش یابد.

این مقاله نشان می‌دهد چگونه از پردازش مبتنی بر BLOB برای افزودن رسانه بزرگ به یک ارائه، استخراج رسانه بزرگ از یک ارائه، و بارگذاری ارائه‌های بزرگ به صورت کارآمدتر استفاده شود. همچنین توضیح می‌دهد چگونه می‌توان از فایل‌های موقت در حین پردازش استفاده کرد و چگونه پوشه‌ای که برای ذخیره‌سازی آن‌ها به کار می‌رود را تغییر داد.

## **درباره BLOB**

**BLOB** (**Binary Large Object**) معمولاً یک مورد بزرگ (عکس، ارائه، سند یا رسانه) است که به صورت باینری ذخیره می‌شود.

Aspose.Slides for Node.js via Java به شما امکان می‌دهد BLOB‌ها را برای اشیاء به گونه‌ای استفاده کنید که مصرف حافظه هنگام کار با فایل‌های بزرگ کاهش یابد.

{{% alert title="Info" color="info" %}}
برای دور زدن برخی محدودیت‌ها هنگام تعامل با جریان‌ها، Aspose.Slides ممکن است محتوای جریان را کپی کند. بارگذاری یک ارائه بزرگ از طریق جریان آن منجر به کپی شدن محتویات ارائه می‌شود و باعث بارگذاری آهسته می‌گردد. بنابراین، زمانی که قصد بارگذاری یک ارائه بزرگ را دارید، به شدت توصیه می‌کنیم از مسیر فایل ارائه استفاده کنید و نه از جریان آن.
{{% /alert %}}

## **استفاده از BLOB برای کاهش مصرف حافظه**

### **افزودن فایل بزرگ از طریق BLOB به یک ارائه**

[Aspose.Slides](/slides/fa/nodejs-java/) for Node.js via Java به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل ویدئوی بزرگ) را از طریق فرآیند BLOB اضافه کنید تا مصرف حافظه کاهش یابد.

این JavaScript نشان می‌دهد چگونه یک فایل ویدئوی بزرگ را از طریق فرآیند BLOB به یک ارائه اضافه کنید:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// یک ارائه جدید ایجاد می‌کند که ویدئو به آن اضافه می‌شود
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // بیایید ویدئو را به ارائه اضافه کنیم - ما رفتار KeepLocked را انتخاب کردیم زیرا ما
        // قصد دسترسی به فایل "veryLargeVideo.avi" را نداریم.
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // ارائه را ذخیره می‌کند. در حالی که یک ارائه بزرگ خروجی می‌شود، مصرف حافظه
        // در طول دورهٔ حیات شیء pres در سطح کمی می‌ماند
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **استخراج فایل بزرگ از طریق BLOB از ارائه**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدئویی) را از طریق فرآیند BLOB از ارائه‌ها استخراج کنید. به‌عنوان مثال، ممکن است نیاز داشته باشید یک فایل رسانه بزرگ را از ارائه استخراج کنید اما نمی‌خواهید فایل در حافظه کامپیوتر شما بارگذاری شود. با استخراج فایل از طریق فرآیند BLOB، مصرف حافظه کم می‌ماند.

این کد JavaScript عملیات توصیف‌شده را نشان می‌دهد:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// قفل کردن فایل منبع و عدم بارگذاری آن در حافظه
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// ایجاد نمونهٔ Presentation، قفل کردن فایل "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // بیایید هر ویدیو را در یک فایل ذخیره کنیم. برای جلوگیری از مصرف زیاد حافظه، به یک بافر نیاز داریم که
    // برای انتقال داده‌ها از جریان ویدئوی ارائه به یک جریان برای فایل ویدئوی جدید ایجاد شده استفاده شود.
    var buffer = new byte[8 * 1024];
    // Iterates through the videos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // جریان ویدئوی ارائه را باز می‌کند. لطفاً توجه داشته باشید که عمداً از دسترسی به ویژگی‌ها
        // مانند video.BinaryData اجتناب کردیم - زیرا این ویژگی یک آرایه بایت شامل ویدئوی کامل را بر می‌گرداند که
        // باعث بارگذاری بایت‌ها در حافظه می‌شود. ما از video.GetStream استفاده می‌کنیم که یک Stream برمی‌گرداند - و
        // نیازی به بارگذاری کل ویدئو در حافظه ندارد.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // مصرف حافظه حتی با بزرگ بودن ویدئو یا ارائه کم می‌ماند.
    }
    // در صورت نیاز، می‌توانید همان مراحل را برای فایل‌های صوتی اعمال کنید.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **افزودن تصویر به عنوان BLOB در ارائه**

با استفاده از روش‌های کلاس [**ImageCollection**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ImageCollection) می‌توانید یک تصویر بزرگ را به‌صورت جریان اضافه کنید تا به‌عنوان BLOB رفتار کند.

این کد JavaScript نشان می‌دهد چگونه یک تصویر بزرگ را از طریق فرآیند BLOB اضافه کنید:

```javascript
var pathToLargeImage = "large_image.jpg";
    // یک ارائهٔ جدید ایجاد می‌کند که تصویر به آن اضافه خواهد شد.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // بیایید تصویر را به ارائه اضافه کنیم - ما رفتار KeepLocked را انتخاب می‌کنیم زیرا
        // قصد دسترسی به فایل "largeImage.png" را نداریم.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // ارائه را ذخیره می‌کند. در حالی که یک ارائهٔ بزرگ خروجی می‌شود، مصرف حافظه
        // در طول دورهٔ حیات شیء pres کم می‌ماند.
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حافظه و ارائه‌های بزرگ**

به‌طور معمول، برای بارگذاری یک ارائه بزرگ کامپیوترها به مقدار زیادی حافظه موقت نیاز دارند. تمام محتویات ارائه در حافظه بارگذاری می‌شود و فایل منبع (فایلی که ارائه از آن بارگذاری شده) دیگر استفاده نمی‌شود.

در نظر بگیرید یک ارائه PowerPoint بزرگ (large.pptx) که شامل یک فایل ویدئویی 1.5 گیگابایتی باشد. روش استاندارد برای بارگذاری ارائه در این کد JavaScript توضیح داده شده است:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

اما این روش حدود 1.6 گیگابایت حافظه موقت مصرف می‌کند.

### **بارگذاری یک ارائه بزرگ به‌صورت BLOB**

از طریق فرآیند BLOB می‌توانید یک ارائه بزرگ را با استفاده از حجم کمی حافظه بارگذاری کنید. این کد JavaScript پیاده‌سازی را نشان می‌دهد که در آن فرآیند BLOB برای بارگذاری فایل ارائه بزرگ (large.pptx) به‌کار رفته است:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **تغییر پوشه فایل‌های موقت**

زمانی که فرآیند BLOB استفاده می‌شود، کامپیوتر شما فایل‌های موقت را در پوشه پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه دیگری نگهداری شوند، می‌توانید تنظیمات ذخیره‌سازی را با استفاده از `setTempFilesRootPath` تغییر دهید:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
هنگامی که از `setTempFilesRootPath` استفاده می‌کنید، Aspose.Slides به‌صورت خودکار پوشه‌ای برای ذخیره‌سازی فایل‌های موقت ایجاد نمی‌کند. شما باید این پوشه را به‌صورت دستی ایجاد کنید.
{{% /alert %}}

### **از اشیاء Presentation برای آزادسازی حافظه استفاده کنید**

هنگام پردازش ارائه‌های بزرگ، اطمینان حاصل کنید که نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) به‌درستی تخریب شود تا حافظه‌ای که اشغال کرده بود آزاد گردد. پس از اتمام کار با ارائه، متد `dispose()` را فراخوانی کنید تا منابع غیرقابل مدیریت آزاد شوند.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **سوالات متداول**

**کدام داده‌ها در یک ارائه Aspose.Slides به‌عنوان BLOB در نظر گرفته شده و توسط گزینه‌های BLOB کنترل می‌شوند؟**

اشیای باینری بزرگ مانند تصاویر، صدا و ویدئو به‌عنوان BLOB در نظر گرفته می‌شود. تمام فایل ارائه نیز هنگام بارگذاری یا ذخیره‌سازی شامل پردازش BLOB می‌شود. این اشیا تحت سیاست‌های BLOB قرار دارند که به شما امکان مدیریت استفاده از حافظه و انتقال به فایل‌های موقت را می‌دهند.

**کجا می‌توانم قوانین پردازش BLOB را هنگام بارگذاری ارائه تنظیم کنم؟**

از [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/blobmanagementoptions/) استفاده کنید. در اینجا می‌توانید حد حافظه درون‌حافظه‌ای برای BLOB را تنظیم کنید، اجازه یا عدم اجازه فایل‌های موقت را بدهید، مسیر ریشه برای فایل‌های موقت را انتخاب کنید و رفتار قفل‌گذاری منبع را تعیین کنید.

**آیا تنظیمات BLOB بر عملکرد تأثیر می‌گذارند و چگونه می‌توان سرعت را در مقابل حافظه تعادل داد؟**

بله. نگه داشتن BLOB در حافظه سرعت را حداکثری می‌کند اما مصرف RAM را افزایش می‌دهد؛ کاهش حد حافظه باعث می‌شود بیشتر کار به فایل‌های موقت منتقل شود، در نتیجه RAM کاهش می‌یابد اما I/O بیشتری رخ می‌دهد. از متد [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) استفاده کنید تا تعادل مناسب برای بار کاری و محیط خود پیدا کنید.

**آیا گزینه‌های BLOB در باز کردن ارائه‌های بسیار بزرگ (مثلاً گیگابایتی) کمک می‌کنند؟**

بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/blobmanagementoptions/) برای چنین سناریوهایی طراحی شده‌اند: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند به‌طور قابل‌توجهی استفاده حداکثری RAM را کاهش داده و پردازش ارائه‌های بسیار بزرگ را پایدارتر کند.

**آیا می‌توانم از سیاست‌های BLOB هنگام بارگذاری از جریان‌ها به‌جای فایل‌های دیسک استفاده کنم؟**

بله. همان قوانین بر روی جریان‌ها نیز اعمال می‌شود: نمونهٔ ارائه می‌تواند مالک و قفل‌کنندهٔ جریان ورودی باشد (بسته به حالت قفل‌گذاری انتخابی) و فایل‌های موقت زمانی که مجاز باشند استفاده می‌شوند، به‌طوری که مصرف حافظه در طول پردازش پیش‌بینی‌پذیر باقی بماند.