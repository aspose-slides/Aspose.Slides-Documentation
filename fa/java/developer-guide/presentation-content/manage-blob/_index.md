---
title: مدیریت BLOBهای ارائه در Java برای استفاده بهینه از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/java/manage-blob/
keywords:
- شیء بزرگ
- آیتم بزرگ
- فایل بزرگ
- افزودن BLOB
- صادرات BLOB
- افزودن تصویر به‌عنوان BLOB
- کاهش حافظه
- مصرف حافظه
- ارائه بزرگ
- فایل موقت
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مدیریت داده‌های BLOB در Aspose.Slides برای Java به‌منظور ساده‌سازی عملیات فایل‌های PowerPoint و OpenDocument برای مدیریت کارآمد ارائه."
---
## **مروری کلی**

Aspose.Slides مدیریت مبتنی بر BLOB را برای داده‌های دودویی بزرگ در ارائه‌ها فراهم می‌کند تا مصرف حافظه را هنگام کار با تصاویر، صدا، ویدیو و فایل‌های ارائه بزرگ کاهش دهد.

این مقاله نشان می‌دهد که چگونه از پردازش مبتنی بر BLOB برای افزودن رسانه‌های بزرگ به یک ارائه، استخراج رسانه‌های بزرگ از یک ارائه و بارگذاری ارائه‌های بزرگ به صورت کارآمدتر استفاده کنید. همچنین توضیح می‌دهد که چگونه می‌توان از فایل‌های موقت در حین پردازش استفاده کرد و پوشه ذخیره‌سازی آن‌ها را تغییر داد.

## **درباره BLOB**

**BLOB** (**Binary Large Object**) معمولاً یک مورد بزرگ (عکس، ارائه، سند یا رسانه) است که در قالب‌های دودویی ذخیره می‌شود.

Aspose.Slides برای Java به شما اجازه می‌دهد تا از BLOBها برای اشیاء به گونه‌ای استفاده کنید که مصرف حافظه را هنگام کار با فایل‌های بزرگ کاهش دهد.

{{% alert title="Info" color="info" %}}
برای دور زدن برخی محدودیت‌ها هنگام تعامل با جریان‌ها، Aspose.Slides ممکن است محتوای جریان را کپی کند. بارگذاری یک ارائه بزرگ از طریق جریان آن منجر به کپی شدن محتویات ارائه می‌شود و باعث بارگذاری کند می‌گردد. بنابراین، زمانی که می‌خواهید یک ارائه بزرگ را بارگذاری کنید، به شدت توصیه می‌کنیم از مسیر فایل ارائه استفاده کنید و نه از جریان آن.
{{% /alert %}}

## **استفاده از BLOB برای کاهش مصرف حافظه**

### **افزودن یک فایل بزرگ از طریق BLOB به یک ارائه**

Aspose.Slides برای Java به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل ویدئویی بزرگ) را از طریق فرآیندی که شامل BLOBها است اضافه کنید تا مصرف حافظه کاهش یابد.

این مثال جاوا نشان می‌دهد که چگونه یک فایل ویدئوی بزرگ را از طریق فرآیند BLOB به یک ارائه اضافه کنید:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// یک ارائه جدید ایجاد می‌کند که ویدئو به آن افزوده می‌شود
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // بیایید ویدئو را به ارائه اضافه کنیم - رفتار KeepLocked را انتخاب کردیم زیرا ما
        //قصد دسترسی به فایل "veryLargeVideo.avi" را نداریم.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // ارائه را ذخیره می‌کند. در حالی که یک ارائه بزرگ خروجی می‌شود، مصرف حافظه
        //در طول چرخه حیات شی pres پایین می‌ماند 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **صادرات یک فایل بزرگ از طریق BLOB از ارائه**

Aspose.Slides برای Java به شما اجازه می‌دهد فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدئویی) را از طریق فرآیندی که شامل BLOBها است از ارائه‌ها استخراج کنید. به‌عنوان مثال، ممکن است نیاز داشته باشید یک فایل رسانه‌ای بزرگ را از یک ارائه استخراج کنید ولی نمی‌خواهید فایل در حافظهٔ کامپیوتر شما بارگذاری شود. با صادرات فایل از طریق فرآیند BLOB، مصرف حافظه را کم نگه می‌دارید.

این کد در جاوا عملیات توصیف‌شده را نشان می‌دهد:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// فایل منبع را قفل می‌کند و آن را در حافظه بارگذاری نمی‌کند
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// نمونه Presentation را ایجاد می‌کند و فایل "hugePresentationWithAudiosAndVideos.pptx" را قفل می‌کند.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // بیایید هر ویدئو را در یک فایل ذخیره کنیم. برای جلوگیری از مصرف زیاد حافظه، به یک بافر نیاز داریم که مورد استفاده قرار گیرد
    // برای انتقال داده‌ها از جریان ویدئوی ارائه به یک جریان برای فایل ویدئوی تازه ایجاد شده.
    byte[] buffer = new byte[8 * 1024];

    // بر روی ویدئوها تکرار می‌شود
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // جریان ویدئوی ارائه را باز می‌کند. لطفاً توجه داشته باشید که عمداً از دسترسی به ویژگی‌ها پرهیز کردیم
        // مانند video.BinaryData - زیرا این ویژگی آرایه بایتی حاوی تمام ویدئو را برمی‌گرداند، که سپس
        // باعث بارگذاری بایت‌ها در حافظه می‌شود. ما از video.GetStream استفاده می‌کنیم، که یک Stream برمی‌گرداند - و
        //  نیاز به بارگذاری تمام ویدئو در حافظه ندارد.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // مصرف حافظه به‌صرفه خواهد بود، صرف‌نظر از اندازه ویدئو یا ارائه.
    }
    // در صورت لزوم می‌توانید همان مراحل را برای فایل‌های صوتی اعمال کنید. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **افزودن یک تصویر به عنوان BLOB به یک ارائه**

با استفاده از متدهای رابط [**IImageCollection**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImageCollection) و کلاس [**ImageCollection**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ImageCollection)، می‌توانید یک تصویر بزرگ را به‌صورت جریان اضافه کنید تا به‌عنوان BLOB درنظر گرفته شود.

این کد جاوا نشان می‌دهد که چگونه یک تصویر بزرگ را از طریق فرآیند BLOB اضافه کنید:

```java
String pathToLargeImage = "large_image.jpg";

//	یک ارائه جدید ایجاد می‌کند که تصویر به آن افزوده می‌شود.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		//	بیایید تصویر را به ارائه اضافه کنیم - رفتار KeepLocked را انتخاب می‌کنیم زیرا ما
		//	قصد دسترسی به فایل "largeImage.png" را نداریم.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		//	ارائه را ذخیره می‌کند. در حالی که یک ارائه بزرگ خروجی می‌شود، مصرف حافظه
		//	در طول چرخه حیات شی pres پایین می‌ماند
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **حافظه و ارائه‌های بزرگ**

معمولاً برای بارگذاری یک ارائه بزرگ، رایانه‌ها به مقدار زیادی حافظهٔ موقت نیاز دارند. تمام محتوای ارائه در حافظه بارگذاری می‌شود و فایل (که از آن ارائه بارگذاری شده بود) دیگر استفاده نمی‌شود.

یک ارائه بزرگ PowerPoint (large.pptx) را در نظر بگیرید که حاوی یک فایل ویدئویی ۱.۵ گیگابایتی است. روش استاندارد برای بارگذاری این ارائه در کد جاوای زیر توصیف شده است:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

اما این روش حدود ۱.۶ گیگابایت حافظهٔ موقت مصرف می‌کند.

### **بارگذاری یک ارائه بزرگ به‌صورت BLOB**

از طریق فرآیند شامل BLOB می‌توانید یک ارائه بزرگ را با استفاده از مقدار کمی حافظه بارگذاری کنید. این کد جاوا پیاده‌سازی‌ای را توصیف می‌کند که در آن از فرآیند BLOB برای بارگذاری یک فایل ارائه بزرگ (large.pptx) استفاده شده است:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تغییر پوشه برای فایل‌های موقت**

هنگامی که فرآیند BLOB استفاده می‌شود، رایانهٔ شما فایل‌های موقت را در پوشهٔ پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه‌ای متفاوت نگهداری شوند، می‌توانید تنظیمات ذخیره‌سازی را با استفاده از `TempFilesRootPath` تغییر دهید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
هنگامی که از `TempFilesRootPath` استفاده می‌کنید، Aspose.Slides به‌صورت خودکار پوشه‌ای برای ذخیرهٔ فایل‌های موقت ایجاد نمی‌کند. شما باید پوشه را به‌صورت دستی ایجاد کنید.
{{% /alert %}}

### **آزادسازی اشیای Presentation برای رهاسازی حافظه**

هنگام پردازش ارائه‌های بزرگ، اطمینان حاصل کنید که نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) به‌درستی آزاد شود تا حافظه‌ای که اشغال کرده بود آزاد شود. پس از پایان استفاده از ارائه، برای آزادسازی منابع غیرقابل مدیریت، `dispose()` را فراخوانی کنید.

```java
Presentation presentation = new Presentation("large.pptx");

// ...پردازش ارائه...
presentation.save("large.pdf", SaveFormat.Pdf);

// به‌صورت صریح منابع را آزاد کنید.
presentation.dispose();
```

## **سؤالات متداول**

**کدام داده‌ها در یک ارائه Aspose.Slides به‌عنوان BLOB درنظر گرفته شده و توسط گزینه‌های BLOB کنترل می‌شوند؟**

اشیای دودویی بزرگ مانند تصاویر، صدا و ویدئو به‌عنوان BLOB درنظر گرفته می‌شوند. کل فایل ارائه نیز هنگام بارگذاری یا ذخیره‌سازی شامل مدیریت BLOB است. این اشیا تحت سیاست‌های BLOB قرار دارند که به شما امکان می‌دهد استفاده از حافظه را مدیریت کنید و در صورت نیاز به فایل‌های موقت منتقل شوند.

**کجا می‌توانم قوانین مدیریت BLOB را هنگام بارگذاری ارائه تنظیم کنم؟**

از [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/blobmanagementoptions/) استفاده کنید. در آنجا می‌توانید حد حافظهٔ داخلی برای BLOB را تنظیم کنید، اجازه یا عدم اجازه به فایل‌های موقت را تعیین کنید، مسیر ریشهٔ فایل‌های موقت را انتخاب کنید و رفتار قفل‌گذاری منبع را مشخص نمایید.

**آیا تنظیمات BLOB بر عملکرد تأثیر می‌گذارد و چگونه می‌توان سرعت و حافظه را متعادل کرد؟**

بله. نگه داشتن BLOB در حافظه سرعت را حداکثر می‌کند اما مصرف RAM را افزایش می‌دهد؛ کاهش حد حافظه، کار بیشتر را به فایل‌های موقت منتقل می‌کند و RAM را کاهش می‌دهد، هرچند با هزینهٔ ورودی/خروجی بیشتر. برای رسیدن به تعادل مناسب برای بار کاری و محیط خود از متد [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) استفاده کنید.

**آیا گزینه‌های BLOB هنگام باز کردن ارائه‌های بسیار بزرگ (مثلاً چند گیگابایت) مفید هستند؟**

بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/blobmanagementoptions/) برای اینگونه سناریوها طراحی شده‌اند: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند به‌طور چشمگیری استفادهٔ حداکثری RAM را کاهش داده و پردازش مجموعه‌های بسیار بزرگ را پایدار کند.

**آیا می‌توانم سیاست‌های BLOB را هنگام بارگذاری از جریان‌ها به‌جای فایل‌های دیسک استفاده کنم؟**

بله. همان قوانین بر روی جریان‌ها نیز اعمال می‌شود: نمونهٔ ارائه می‌تواند مالک و قفل‌کنندهٔ جریان ورودی باشد (بسته به حالت قفل‌گذاری انتخاب شده) و فایل‌های موقت زمانی که اجازه داده شوند استفاده می‌شوند، به‌طوری که مصرف حافظه در حین پردازش قابل پیش‌بینی باشد.