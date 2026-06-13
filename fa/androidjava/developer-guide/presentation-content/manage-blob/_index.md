---
title: مدیریت BLOBهای ارائه در اندروید برای استفاده بهینه از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/androidjava/manage-blob/
keywords:
- شی بزرگ
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
- Android
- Java
- Aspose.Slides
description: "مدیریت داده‌های BLOB در Aspose.Slides برای اندروید از طریق Java برای بهینه‌سازی عملیات فایل‌های PowerPoint و OpenDocument و کارآمدسازی پردازش ارائه‌ها."
---
## **بررسی کلی**

Aspose.Slides برای پردازش داده‌های باینری بزرگ در ارائه‌ها از روش مبتنی بر BLOB استفاده می‌کند تا مصرف حافظه را هنگام کار با تصاویر بزرگ، صدا، ویدئو و فایل‌های ارائه کاهش دهد.

این مقاله نشان می‌دهد چگونه از پردازش مبتنی بر BLOB برای افزودن رسانه‌های بزرگ به یک ارائه، صادرات رسانه‌های بزرگ از یک ارائه و بارگذاری مؤثرتر ارائه‌های بزرگ استفاده کنید. همچنین توضیح می‌دهد چگونه می‌توان از فایل‌های موقت در طول پردازش استفاده کرد و چگونگی تغییر پوشه‌ای که برای ذخیره آنها استفاده می‌شود را بیان می‌کند.

## **درباره BLOB**

**BLOB** (**Binary Large Object**) معمولاً یک آیتم بزرگ (عکس، ارائه، سند یا رسانه) است که در قالب‌های باینری ذخیره می‌شود.  

Aspose.Slides for Android via Java به شما اجازه می‌دهد تا از BLOBها برای اشیاء به گونه‌ای استفاده کنید که مصرف حافظه را هنگام کار با فایل‌های بزرگ کاهش دهد.

{{% alert title="Info" color="info" %}}
برای دور زدن برخی محدودیت‌ها هنگام تعامل با استریم‌ها، Aspose.Slides ممکن است محتوای استریم را کپی کند. بارگذاری یک ارائه بزرگ از طریق استریم آن منجر به کپی شدن محتوای ارائه می‌شود و باعث بارگذاری کند می‌گردد. بنابراین، زمانی که قصد بارگذاری یک ارائه بزرگ را دارید، به شدت توصیه می‌کنیم از مسیر فایل ارائه استفاده کنید نه استریم آن.
{{% /alert %}}

## **استفاده از BLOB برای کاهش مصرف حافظه**

### **افزودن فایل بزرگ از طریق BLOB به یک ارائه**

[Aspose.Slides](/slides/fa/androidjava/) for Java به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل ویدئویی بزرگ) را از طریق فرآیند شامل BLOBها اضافه کنید تا مصرف حافظه کاهش یابد.

این مثال جاوا نشان می‌دهد چگونه یک فایل ویدئوی بزرگ را از طریق فرایند BLOB به یک ارائه اضافه کنید:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// یک ارائه جدید ایجاد می‌کند که ویدئو به آن اضافه خواهد شد
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // بیایید ویدئو را به ارائه اضافه کنیم - رفتار KeepLocked را انتخاب کردیم زیرا قصد
        // دسترسی به فایل "veryLargeVideo.avi" را نداریم.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // ارائه را ذخیره می‌کند. در حالی که یک ارائه بزرگ خروجی می‌شود، مصرف حافظه
        // در طول دورهٔ حیات شی pres کم می‌ماند 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **صادرات یک فایل بزرگ از طریق BLOB از یک ارائه**
Aspose.Slides for Android via Java به شما اجازه می‌دهد فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدئویی) را از طریق فرآیند شامل BLOBها از ارائه‌ها صادر کنید. به عنوان مثال، ممکن است نیاز داشته باشید یک فایل رسانه بزرگ را از یک ارائه استخراج کنید اما نمی‌خواهید فایل در حافظهٔ کامپیوتر شما بارگذاری شود. با صادرات فایل از طریق فرآیند BLOB، می‌توانید مصرف حافظه را پایین نگه دارید.

این کد جاوا عملیات توضیح داده شده را نشان می‌دهد:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// فایل منبع را قفل می‌کند و آن را در حافظه بارگذاری نمی‌کند
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// نمونه Presentation را ایجاد می‌کند و فایل "hugePresentationWithAudiosAndVideos.pptx" را قفل می‌کند.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // بیایید هر ویدیو را در یک فایل ذخیره کنیم. برای جلوگیری از استفاده زیاد از حافظه، به یک بافر نیاز داریم که
    // داده‌ها را از استریم ویدیوی ارائه به استریمی برای یک فایل ویدیویی جدید منتقل کند.
    byte[] buffer = new byte[8 * 1024];

    // از ویدیوها عبور می‌کند
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // استریم ویدیوی ارائه را باز می‌کند. لطفاً توجه داشته باشید که عمداً از دسترسی به ویژگی‌ها خودداری کردیم
        // مانند video.BinaryData - زیرا این ویژگی یک آرایه بایت شامل کل ویدیو برمی‌گرداند که سپس
        // باعث می‌شود بایت‌ها در حافظه بارگذاری شوند. ما از video.GetStream استفاده می‌کنیم که یک Stream برمی‌گرداند - و
        //  نیازمند بارگذاری کل ویدیو در حافظه نیست.
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
        // مصرف حافظه صرف‌نظر از اندازهٔ ویدیو یا ارائه کم خواهد ماند.
    }
    // در صورت لزوم، می‌توانید همان مراحل را برای فایل‌های صوتی اعمال کنید. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **اضافه کردن تصویر به عنوان BLOB در یک ارائه**
با استفاده از متدهای رابط [**IImageCollection**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IImageCollection) و کلاس [**ImageCollection**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ImageCollection)، می‌توانید یک تصویر بزرگ را به صورت استریم اضافه کنید تا به عنوان BLOB در نظر گرفته شود.

این کد جاوا نشان می‌دهد چگونه یک تصویر بزرگ را از طریق فرآیند BLOB اضافه کنید:

```java
String pathToLargeImage = "large_image.jpg";

// یک ارائه جدید ایجاد می‌کند که تصویر به آن اضافه خواهد شد.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// بیایید تصویر را به ارائه اضافه کنیم - رفتار KeepLocked را انتخاب می‌کنیم زیرا ما
		// قصد دسترسی به فایل "largeImage.png" را نداریم.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// ارائه را ذخیره می‌کند. در حالی که یک ارائه بزرگ خروجی می‌شود، مصرف حافظه
		// در طول دورهٔ حیات شی pres کم می‌ماند
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

به‌طور معمول، برای بارگذاری یک ارائه بزرگ، کامپیوترها به حافظهٔ موقت زیادی نیاز دارند. تمام محتوای ارائه در حافظه بارگذاری می‌شود و فایل (که از آن ارائه بارگذاری شده) دیگر استفاده نمی‌شود.

به‌عنوان مثال، یک ارائهٔ PowerPoint بزرگ (large.pptx) که شامل یک فایل ویدئویی ۱.۵ GB است. روش استاندارد برای بارگذاری ارائه در کد جاوا زیر توصیف شده است:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

اما این روش حدود ۱.۶ GB حافظه موقت مصرف می‌کند.

### **بارگذاری یک ارائه بزرگ به عنوان BLOB**

از طریق فرآیند شامل BLOB می‌توانید یک ارائه بزرگ را بارگذاری کنید در حالی که حافظهٔ کمی استفاده می‌کنید. این کد جاوا پیاده‌سازی‌ای را نشان می‌دهد که در آن فرآیند BLOB برای بارگذاری یک فایل ارائه بزرگ (large.pptx) استفاده می‌شود:

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

هنگامی که از فرآیند BLOB استفاده می‌شود، کامپیوتر شما فایل‌های موقت را در پوشهٔ پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه‌ای متفاوت نگه داشته شوند، می‌توانید تنظیمات ذخیره‌سازی را با استفاده از `TempFilesRootPath` تغییر دهید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
وقتی از `TempFilesRootPath` استفاده می‌کنید، Aspose.Slides به‌صورت خودکار پوشه‌ای برای ذخیرهٔ فایل‌های موقت ایجاد نمی‌کند. شما باید این پوشه را به‌صورت دستی ایجاد کنید.
{{% /alert %}}

### **تخلیهٔ اشیای Presentation برای آزاد کردن حافظه**

هنگام پردازش ارائه‌های بزرگ، اطمینان حاصل کنید که نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) به‌درستی تخلیه شود تا حافظه‌ای که اشغال کرده بود آزاد شود. پس از پایان کار با ارائه، `dispose()` را فراخوانی کنید تا منابع unmanaged آزاد شوند.

```java
Presentation presentation = new Presentation("large.pptx");

// ...ارائه را پردازش کنید...
presentation.save("large.pdf", SaveFormat.Pdf);

// به‌صورت صریح منابع را آزاد کنید.
presentation.dispose();
```

## **سؤالات متداول**

**داده‌های چه نوعی در یک ارائهٔ Aspose.Slides به عنوان BLOB در نظر گرفته می‌شوند و توسط گزینه‌های BLOB کنترل می‌شوند؟**  
اشیاء باینری بزرگ مانند تصاویر، صدا و ویدئو به عنوان BLOB در نظر گرفته می‌شوند. همچنین کل فایل ارائه هنگام بارگذاری یا ذخیره‌سازی شامل پردازش BLOB می‌شود. این اشیاء تحت سیاست‌های BLOB قرار دارند که به شما امکان مدیریت مصرف حافظه و انتقال به فایل‌های موقت در صورت نیاز را می‌دهند.

**کجا می‌توانم قوانین پردازش BLOB را هنگام بارگذاری ارائه تنظیم کنم؟**  
از [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/blobmanagementoptions/) استفاده کنید. در اینجا می‌توانید حد حافظهٔ درون‌حافظه‌ای برای BLOB را تنظیم کنید، اجازه یا عدم اجازه استفاده از فایل‌های موقت را مشخص کنید، مسیر ریشهٔ فایل‌های موقت را انتخاب کنید و رفتار قفل‌گذاری منبع را تعیین نمایید.

**آیا تنظیمات BLOB بر عملکرد تأثیر می‌گذارند و چگونه تعادل بین سرعت و حافظه را برقرار کنم؟**  
بله. نگه داشتن BLOB در حافظه سرعت را حداکثر می‌کند اما مصرف RAM را افزایش می‌دهد؛ کاهش حد حافظه کار را بیشتر به فایل‌های موقت منتقل می‌کند و RAM را کاهش می‌دهد اما هزینهٔ I/O بیشتری دارد. از متد [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) برای یافتن تعادل مناسب برای بار کاری و محیط خود استفاده کنید.

**آیا گزینه‌های BLOB هنگام باز کردن ارائه‌های بسیار بزرگ (مثلاً گیگابایتی) کمک می‌کنند؟**  
بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/blobmanagementoptions/) برای این گونه سناریوها طراحی شده‌اند: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند به طور چشمگیری استفادهٔ حداکثری RAM را کاهش داده و پردازش ارائه‌های بسیار بزرگ را پایدارتر نماید.

**آیا می‌توانم از سیاست‌های BLOB هنگام بارگذاری از استریم‌ها به جای فایل‌های دیسک استفاده کنم؟**  
بله. همان قوانین بر روی استریم‌ها اعمال می‌شوند: نمونهٔ ارائه می‌تواند مالک و قفل استریم ورودی باشد (بسته به حالت قفل‌گذاری انتخاب‌شده) و فایل‌های موقت زمانی که اجازه داده شوند استفاده می‌شوند، به‌طوری‌که مصرف حافظه در طول پردازش پیش‌بینی‌پذیر باقی بماند.