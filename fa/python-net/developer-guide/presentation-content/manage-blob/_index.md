---
title: مدیریت BLOBها در ارائه‌ها با پایتون برای استفاده مؤثر از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/python-net/manage-blob/
keywords:
- شیء بزرگ
- آیتم بزرگ
- فایل بزرگ
- افزودن BLOB
- استخراج BLOB
- افزودن تصویر به‌عنوان BLOB
- کاهش حافظه
- مصرف حافظه
- ارائه بزرگ
- فایل موقت
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت داده‌های BLOB در Aspose.Slides برای پایتون از طریق .NET برای ساده‌سازی عملیات فایل‌های PowerPoint و OpenDocument جهت پردازش مؤثر ارائه‌ها."
---
## **بررسی کلی**

Aspose.Slides قابلیت پردازش مبتنی بر BLOB را برای داده‌های باینری بزرگ در پرزنتیشن‌ها ارائه می‌دهد تا با کار با تصاویر، صدا، ویدئو و فایل‌های پرزنتیشن بزرگ، مصرف حافظه را کاهش دهد.

این مقاله نشان می‌دهد چگونه از پردازش مبتنی بر BLOB برای افزودن رسانه‌های بزرگ به یک پرزنتیشن، صادر کردن رسانه‌های بزرگ از یک پرزنتیشن و بارگذاری پرزنتیشن‌های بزرگ به‌صورت کارآمدتر استفاده کنید. همچنین توضیح می‌دهد چگونه می‌توان از فایل‌های موقت در طول پردازش استفاده کرد و چگونه پوشه‌ای که برای ذخیره‌سازی آن‌ها استفاده می‌شود را تغییر داد.

## **درباره BLOB**

**BLOB** (**Binary Large Object**) معمولاً یک آیتم بزرگ (عکس، پرزنتیشن، سند یا رسانه) است که در قالب‌های باینری ذخیره می‌شود.

Aspose.Slides for Python via .NET به شما امکان می‌دهد از BLOBها برای اشیا استفاده کنید به‑طوری که هنگام کار با فایل‌های بزرگ، مصرف حافظه کاهش یابد.

## **استفاده از BLOB برای کاهش مصرف حافظه**

### **افزودن فایل بزرگ به‌صورت BLOB به یک پرزنتیشن**

[Aspose.Slides](/slides/fa/python-net/) برای .NET به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل ویدئویی بزرگ) را از طریق فرایند مبتنی بر BLOB اضافه کنید تا مصرف حافظه کاهش یابد.

این کد پایتون نشان می‌دهد چگونه یک فایل ویدئویی بزرگ را از طریق فرایند BLOB به یک پرزنتیشن اضافه کنید:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# یک ارائه جدید ایجاد می‌کند که ویدئو به آن اضافه می‌شود
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # بیایید ویدئو را به ارائه اضافه کنیم - ما رفتار KeepLocked را انتخاب کردیم چون ما
        # قصد دسترسی به فایل "veryLargeVideo.avi" را نداریم.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # ارائه را ذخیره می‌کند. در حالی که یک ارائه بزرگ خروجی داده می‌شود، مصرف حافظه
        # در طول دورهٔ حیات شی pres کم می‌ماند 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **صادر کردن فایل بزرگ از پرزنتیشن از طریق BLOB**
Aspose.Slides for Python via .NET به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدئویی) را از طریق فرایند مبتنی بر BLOB از پرزنتیشن‌ها صادر کنید. به عنوان مثال، ممکن است نیاز داشته باشید یک فایل رسانه‌ای بزرگ را از یک پرزنتیشن استخراج کنید اما نمی‌خواهید فایل در حافظه کامپیوتر شما بارگذاری شود. با صادر کردن فایل از طریق فرایند BLOB، مصرف حافظه کم می‌ماند.

این کد پایتون عملیات توصیف‌شده را نشان می‌دهد:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# بیایید هر ویدئو را در یک فایل ذخیره کنیم. برای جلوگیری از مصرف زیاد حافظه، به یک بافر نیاز داریم که استفاده شود
	# برای انتقال داده‌ها از جریان ویدئوی ارائه به یک جریان برای فایل ویدئویی تازه ساخته شده.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# مرور ویدئوها
    index = 0
    # در صورت لزوم، می‌توانید همان مراحل را برای فایل‌های صوتی اعمال کنید. 
    for video in pres.videos:
		# جریان ویدئوی ارائه را باز می‌کند. لطفاً توجه داشته باشید که ما عمداً از دسترسی به ویژگی‌ها اجتناب کردیم
		# مانند video.BinaryData - زیرا این ویژگی یک آرایه بایت حاوی ویدئوی کامل برمی‌گرداند، که سپس
		# باعث می‌شود بایت‌ها به حافظه بارگذاری شوند. ما از video.GetStream استفاده می‌کنیم که یک Stream برمی‌گرداند - و این کار نیازی به بارگذاری کل ویدئو در حافظه ندارد
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **افزودن تصویر به‌عنوان BLOB در پرزنتیشن**
با استفاده از متدهای کلاس [**ImageCollection**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) می‌توانید یک تصویر بزرگ را به‌صورت جریان (stream) اضافه کنید تا به عنوان BLOB در نظر گرفته شود.

این کد پایتون نشان می‌دهد چگونه یک تصویر بزرگ را از طریق فرایند BLOB اضافه کنید:

```py
import aspose.slides as slides

# یک ارائه جدید ایجاد می‌کند که تصویر به آن اضافه خواهد شد.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **حافظه و پرزنتیشن‌های بزرگ**

به‌طور معمول، برای بارگذاری یک پرزنتیشن بزرگ، کامپیوترها به مقدار زیادی حافظه موقت نیاز دارند. تمام محتوای پرزنتیشن در حافظه بارگذاری می‌شود و فایل منبع (که پرزنتیشن از آن بارگذاری شده) دیگر استفاده نمی‌شود.

به‌عنوان مثال یک پرزنتیشن PowerPoint بزرگ (large.pptx) که حاوی یک فایل ویدئویی 1.5 گیگابایتی است. روش استاندارد بارگذاری پرزنتیشن در کد پایتون زیر توضیح داده شده است:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

اما این روش حدود 1.6 گیگابایت حافظه موقت مصرف می‌کند.

### **بارگذاری یک پرزنتیشن بزرگ به‌عنوان BLOB**

از طریق فرایند مبتنی بر BLOB می‌توانید یک پرزنتیشن بزرگ را با استفاده از مقدار کمی حافظه بارگذاری کنید. این کد پایتون پیاده‌سازی را که در آن از فرایند BLOB برای بارگذاری یک فایل پرزنتیشن بزرگ (large.pptx) استفاده می‌شود، توضیح می‌دهد:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **تغییر پوشه فایل‌های موقت**

زمانی که فرایند BLOB استفاده می‌شود، کامپیوتر شما فایل‌های موقت را در پوشه پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه دیگری ذخیره شوند، می‌توانید با استفاده از `temp_files_root_path` تنظیمات ذخیره‌سازی را تغییر دهید:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
زمانی که از `temp_files_root_path` استفاده می‌کنید، Aspose.Slides به‌صورت خودکار پوشه‌ای برای ذخیره فایل‌های موقت ایجاد نمی‌کند. شما باید این پوشه را به‌صورت دستی ایجاد کنید.
{{% /alert %}}

### **از بین بردن اشیاء Presentation برای آزادسازی حافظه**

در هنگام پردازش پرزنتیشن‌های بزرگ، اطمینان حاصل کنید که نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) به‌درستی تخریب (dispose) می‌شود تا حافظه اشغال‌شده آزاد شود. روش توصیه‌شده استفاده از مدیر زمینه (`with slides.Presentation(...) as presentation:`) همان‌طور که در مثال‌های بالا نشان داده شد، است؛ این کار به‌صورت خودکار پرزنتیشن را می‌بندد و منابع غیر‌مدیریتی را هنگام خروج از بلاک آزاد می‌کند.

اگر پرزنتیشنی را بدون بلاک `with` ایجاد کنید، پس از اتمام کار صریحاً `presentation.dispose()` را فراخوانی کنید و هرگونه ارجاع باقی‌مانده را حذف کنید تا جمع‌آوری‌کننده زباله پایتون بتواند حافظه را بازیابی کند.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...پردازش ارائه...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# به‌صورت صریح منابع را آزاد کنید.
presentation.dispose()
```

## **سوالات متداول**

**کدام داده‌ها در یک پرزنتیشن Aspose.Slides به‌عنوان BLOB در نظر گرفته می‌شوند و توسط گزینه‌های BLOB کنترل می‌شوند؟**

اشیا باینری بزرگ مانند تصاویر، صدا و ویدئو به‌عنوان BLOB در نظر گرفته می‌شوند. کل فایل پرزنتیشن نیز هنگام بارگذاری یا ذخیره‌سازی شامل پردازش BLOB می‌شود. این اشیا تحت سیاست‌های BLOB قرار دارند که به شما امکان مدیریت مصرف حافظه و استفاده از فایل‌های موقت را در صورت نیاز می‌دهد.

**کجا می‌توانم قوانین پردازش BLOB را در طول بارگذاری پرزنتیشن پیکربندی کنم؟**

از [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/blobmanagementoptions/) استفاده کنید. در اینجا می‌توانید محدودیت حافظه درون‌حافظه‌ای برای BLOB را تنظیم کنید، اجازه یا عدم اجازه به فایل‌های موقت، مسیر ریشه برای فایل‌های موقت و رفتار قفل‌گذاری منبع را انتخاب کنید.

**آیا تنظیمات BLOB بر عملکرد تاثیر می‌گذارند و چگونه می‌توان سرعت را در برابر حافظه تعادل داد؟**

بله. نگه‌داشتن BLOB در حافظه سرعت را حداکثر می‌کند ولی مصرف RAM را افزایش می‌دهد؛ کاهش حد حافظه باعث می‌شود کار بیشتر به فایل‌های موقت منتقل شود، که RAM را کاهش می‌دهد اما هزینه I/O بیشتری دارد. با تنظیم آستانه [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/fa/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) می‌توانید تعادل مناسب برای بار کاری و محیط خود پیدا کنید.

**آیا گزینه‌های BLOB در هنگام باز کردن پرزنتیشن‌های بسیار بزرگ (مثلاً گیگابایتی) مفید هستند؟**

بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/blobmanagementoptions/) برای این سناریوها طراحی شده‌اند: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند به‌طور قابل‌توجهی استفاده حداکثری RAM را کاهش داده و پردازش پرزنتیشن‌های بسیار بزرگ را پایدارتر کند.

**آیا می‌توانم سیاست‌های BLOB را هنگام بارگذاری از استریم‌ها به‌جای فایل‌های دیسک استفاده کنم؟**

بله. همان قوانین برای استریم‌ها اعمال می‌شود: نمونه پرزنتیشن می‌تواند مالک و قفل‌کننده استریم ورودی باشد (بسته به حالت قفل‌گذاری انتخاب‌شده) و فایل‌های موقت زمانی که اجازه داده شوند، استفاده می‌شوند تا مصرف حافظه در طول پردازش پیش‌بینی‌پذیر باشد.