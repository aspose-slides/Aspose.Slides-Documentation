---
title: مدیریت BLOBهای ارائه در .NET برای استفاده مؤثر از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/net/manage-blob/
keywords:
- شیء بزرگ
- مورد بزرگ
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
- .NET
- C#
- Aspose.Slides
description: "داده‌های BLOB را در Aspose.Slides برای .NET مدیریت کنید تا عملیات فایل‌های PowerPoint و OpenDocument را برای پردازش مؤثر ارائه ساده‌سازی کنید."
---
## **مرور کلی**

Aspose.Slides پردازش مبتنی بر BLOB را برای داده‌های دودویی بزرگ در ارائه‌ها فراهم می‌کند تا با کار با تصاویر، صدا، ویدئو و فایل‌های ارائه بزرگ، مصرف حافظه را کاهش دهد.

این مقاله نشان می‌دهد چگونه از پردازش مبتنی بر BLOB برای افزودن رسانه‌های بزرگ به یک ارائه، استخراج رسانه‌های بزرگ از یک ارائه و بارگذاری مؤثرتر ارائه‌های بزرگ استفاده کنید. همچنین توضیح می‌دهد چگونه می‌توان در طول پردازش از فایل‌های موقت استفاده کرد و پوشه ذخیره‌سازی آن‌ها را تغییر داد.

## **درباره BLOB**

**BLOB** (**Binary Large Object**) معمولاً یک مورد بزرگ (عکس، ارائه، سند یا رسانه) است که در قالب‌های باینری ذخیره می‌شود.

Aspose.Slides for .NET به شما اجازه می‌دهد BLOBها را برای اشیا به کار ببرید به‌گونه‌ای که هنگام کار با فایل‌های بزرگ، مصرف حافظه کاهش یابد.

## **استفاده از BLOB برای کاهش مصرف حافظه**

### **افزودن یک فایل بزرگ از طریق BLOB به یک ارائه**

[Aspose.Slides](/slides/fa/net/) for .NET به شما اجازه می‌دهد فایل‌های بزرگ (در این مثال، یک فایل ویدیویی بزرگ) را از طریق فرآیندی که شامل BLOBها است، برای کاهش مصرف حافظه اضافه کنید.

این مثال C# نشان می‌دهد چگونه یک فایل ویدیویی بزرگ را از طریق فرآیند BLOB به یک ارائه اضافه کنید:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// یک ارائه جدید ایجاد می‌کند که ویدیو به آن اضافه می‌شود
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // بیایید ویدیو را به ارائه اضافه کنیم - رفتار KeepLocked را انتخاب کردیم چون ما
        //ن قصد دسترسی به فایل "veryLargeVideo.avi" را نداریم.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // ارائه را ذخیره می‌کند. در حالی که یک ارائه بزرگ خروجی می‌شود، مصرف حافظه
        // در طول دورهٔ حیات شی pres کم می‌ماند 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **صادرات یک فایل بزرگ از طریق BLOB از ارائه**

Aspose.Slides for .NET به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدیویی) را از طریق فرآیندی که شامل BLOBها است، از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید یک فایل رسانه‌ای بزرگ را از یک ارائه استخراج کنید اما نمی‌خواهید آن فایل در حافظه رایانه‌تان بارگذاری شود. با صادرات فایل از طریق فرآیند BLOB، مصرف حافظه را کم نگه می‌دارید.

این کد C# عملیات توصیف‌شده را نشان می‌دهد:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// منبع فایل را قفل می‌کند و آن را در حافظه بارگذاری نمی‌کند
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// یک نمونهٔ Presentation ایجاد می‌کند و فایل "hugePresentationWithAudiosAndVideos.pptx" را قفل می‌کند.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// بیایید هر ویدیو را در یک فایل ذخیره کنیم. برای جلوگیری از مصرف زیاد حافظه، به یک بافر نیاز داریم که استفاده شود
	// برای انتقال داده‌ها از جریان ویدئوی ارائه به یک جریان برای فایل ویدئوی جدید ایجاد شده.
	byte[] buffer = new byte[8 * 1024];

	// بر روی ویدیوها تکرار می‌کند
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// جریان ویدئوی ارائه را باز می‌کند. لطفاً توجه داشته باشید که ما عمداً از دسترسی به ویژگی‌ها خودداری کردیم
		// مانند video.BinaryData - زیرا این ویژگی یک آرایه بایت شامل کل ویدیو برمی‌گرداند که سپس
		// باعث می‌شود بایت‌ها در حافظه بارگذاری شوند. ما از video.GetStream استفاده می‌کنیم که یک Stream برمی‌گرداند - و
		//  نیازی به بارگذاری کل ویدیو در حافظه ندارد.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// مصرف حافظه صرف‌نظر از اندازه ویدیو یا ارائه کم خواهد ماند،
	}

	// در صورت نیاز، می‌توانید همان مراحل را برای فایل‌های صوتی اعمال کنید. 
}
```

### **افزودن تصویر به‌عنوان BLOB به یک ارائه**

با استفاده از متدهای موجود در رابط [**IImageCollection**](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) و کلاس [**ImageCollection**](https://reference.aspose.com/slides/fa/net/aspose.slides/imagecollection)، می‌توانید یک تصویر بزرگ را به‌عنوان جریان اضافه کنید تا به عنوان BLOB درنظر گرفته شود.

این کد C# نشان می‌دهد چگونه یک تصویر بزرگ را از طریق فرآیند BLOB اضافه کنید:

```c#
string pathToLargeImage = "large_image.jpg";

// یک ارائه جدید ایجاد می‌کند که تصویر به آن اضافه می‌شود.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// بیایید تصویر را به ارائه اضافه کنیم - رفتار KeepLocked را انتخاب می‌کنیم چون ما
		// قصد دسترسی به فایل "largeImage.png" را نداریم.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// ارائه را ذخیره می‌کند. در حالی که یک ارائه بزرگ خروجی می‌شود، مصرف حافظه 
		// در طول دورهٔ حیات شی pres کم می‌ماند
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **حافظه و ارائه‌های بزرگ**

به‌طور معمول، برای بارگذاری یک ارائه بزرگ، کامپیوترها به مقدار زیادی حافظه موقت نیاز دارند. تمام محتوای ارائه در حافظه بارگذاری می‌شود و فایل (که ارائه از آن بارگذاری شده) دیگر استفاده نمی‌شود.

یک ارائهٔ بزرگ PowerPoint (large.pptx) را در نظر بگیرید که شامل یک فایل ویدئویی ۱٫۵ گیگابایتی است. روش استاندارد برای بارگذاری این ارائه در کد C# زیر توضیح داده شده است:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

اما این روش حدود ۱٫۶ گیگابایت حافظه موقت مصرف می‌کند.

### **بارگذاری یک ارائه بزرگ به‌عنوان BLOB**

از طریق فرآیندی که شامل BLOB است، می‌توانید یک ارائه بزرگ را با مصرف حافظه کم بارگذاری کنید. این کد C# پیاده‌سازی‌ای را که در آن فرآیند BLOB برای بارگذاری یک فایل ارائه بزرگ (large.pptx) استفاده می‌شود، شرح می‌دهد:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **تغییر پوشهٔ فایل‌های موقت**

هنگامی که فرآیند BLOB استفاده می‌شود، رایانه شما فایل‌های موقت را در پوشهٔ پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه‌ای دیگر ذخیره شوند، می‌توانید تنظیمات ذخیره‌سازی را با استفاده از `TempFilesRootPath` تغییر دهید:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
هنگامی که از `TempFilesRootPath` استفاده می‌کنید، Aspose.Slides به‌طور خودکار پوشه‌ای برای ذخیره فایل‌های موقت ایجاد نمی‌کند. شما باید این پوشه را به‌صورت دستی ایجاد کنید.
{{% /alert %}}

### **آزادسازی اشیای Presentation برای آزادسازی حافظه**

هنگام پردازش ارائه‌های بزرگ، اطمینان حاصل کنید که نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) به‌درستی آزاد (disposed) شود تا حافظه‌ای که اشغال کرده است آزاد گردد. روش پیشنهادی استفاده از عبارت `using` یا اعلان آن به‌صورت نشان‌داده‌شده در مثال‌های بالا است؛ این کار به‌طور خودکار ارائه را آزاد می‌کند و منابع غیر مدیریت‌شده را هنگام خروج از بلوک آزاد می‌سازد.

اگر ارائه‌ای را بدون بلوک `using` ایجاد کنید، پس از اتمام استفاده صریحاً `Dispose()` را فراخوانی کنید.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...پردازش ارائه...
presentation.Save("large.pdf", SaveFormat.Pdf);

// به‌صورت صریح منابع را آزاد کنید.
presentation.Dispose();
```

## **پرسش‌های متداول**

**کدام داده‌ها در یک ارائه Aspose.Slides به عنوان BLOB درنظر گرفته شده و توسط گزینه‌های BLOB کنترل می‌شوند؟**

اشیاء دودویی بزرگ مانند تصاویر، صدا و ویدئو به عنوان BLOB درنظر گرفته می‌شوند. کل فایل ارائه نیز هنگام بارگذاری یا ذخیره‌سازی شامل پردازش BLOB است. این اشیا تحت سیاست‌های BLOB قرار دارند که به شما امکان مدیریت مصرف حافظه و انتقال به فایل‌های موقت را در صورت نیاز می‌دهند.

**در کجا می‌توانم قوانین پردازش BLOB را هنگام بارگذاری ارائه تنظیم کنم؟**

از [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/blobmanagementoptions/) استفاده کنید. در اینجا می‌توانید محدودیت حافظه درون‌خطی برای BLOB را تنظیم کنید، اجازه یا عدم اجازه فایل‌های موقت را بدهید، مسیر ریشه‌ای برای فایل‌های موقت انتخاب کنید و رفتار قفل‌گذاری منبع را تعیین کنید.

**آیا تنظیمات BLOB بر عملکرد تأثیر می‌گذارند و چگونه می‌توان سرعت را نسبت به حافظه تعادل داد؟**

بله. نگه‌داری BLOB در حافظه سرعت را حداکثر می‌کند اما مصرف RAM را افزایش می‌دهد؛ کاهش محدودیت حافظه کار بیشتری را به فایل‌های موقت می‌سپارد، در نتیجه RAM کاهش می‌یابد ولی I/O بیشتری نیاز است. آستانهٔ [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/fa/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) را تنظیم کنید تا تعادل مناسب برای بار کاری و محیط خود بدست آورید.

**آیا گزینه‌های BLOB هنگام باز کردن ارائه‌های بسیار بزرگ (مثلاً گیگابایت‌ها) کمک می‌کند؟**

بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/blobmanagementoptions/) برای اینگونه سناریوها طراحی شده‌اند: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند به‌شكل قابل‌توجهی مصرف حداکثری RAM را کاهش داده و پردازش مجموعه‌های بسیار بزرگ را پایدار جلوه دهد.

**آیا می‌توانم از سیاست‌های BLOB هنگام بارگذاری از جریان‌ها به جای فایل‌های دیسک استفاده کنم؟**

بله. همان قوانین برای جریان‌ها نیز اعمال می‌شود: نمونهٔ ارائه می‌تواند مالک و قفل ورودی جریان باشد (بسته به حالت قفل‌گذاری انتخاب‌شده) و فایل‌های موقت زمانی که مجاز باشند استفاده می‌شوند، به‌طوری که مصرف حافظه در طول پردازش پیش‌بینی‌پذیر بماند.