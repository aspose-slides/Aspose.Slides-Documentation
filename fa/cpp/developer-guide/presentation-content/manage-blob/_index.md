---
title: مدیریت BLOBهای ارائه در C++ برای استفاده بهینه از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "مدیریت داده‌های BLOB در Aspose.Slides برای C++ به‌منظور ساده‌سازی عملیات فایل‌های PowerPoint و OpenDocument برای پردازش موثر ارائه‌ها."
---
## **بررسی کلی**

Aspose.Slides مدیریت مبتنی بر BLOB را برای داده‌های باینری بزرگ در ارائه‌ها فراهم می‌کند تا مصرف حافظه هنگام کار با تصاویر، صدا، ویدیو و فایل‌های ارائه بزرگ کاهش یابد.

این مقاله نشان می‌دهد چگونه از پردازش مبتنی بر BLOB برای افزودن رسانه بزرگ به یک ارائه، استخراج رسانه بزرگ از یک ارائه و بارگذاری ارائه‌های بزرگ به صورت کارآمدتر استفاده کنید. همچنین توضیح می‌دهد چگونه می‌توان از فایل‌های موقت در طول پردازش استفاده کرده و پوشه ذخیره‌سازی آن‌ها را تغییر داد.

## **درباره BLOB**

**BLOB** (**Binary Large Object**) معمولاً یک آیتم بزرگ (عکس، ارائه، سند یا رسانه) است که در قالب باینری ذخیره می‌شود.

Aspose.Slides برای C++ به شما امکان استفاده از BLOBها را برای اشیاء به گونه‌ای می‌دهد که مصرف حافظه در هنگام کار با فایل‌های بزرگ کاهش یابد.

## **استفاده از BLOB برای کاهش مصرف حافظه**

### **افزودن یک فایل بزرگ از طریق BLOB به یک ارائه**

[Aspose.Slides](/slides/fa/cpp/) برای C++ به شما امکان افزودن فایل‌های بزرگ (در این مثال، یک فایل ویدئویی بزرگ) از طریق فرآیند شامل BLOBها را برای کاهش مصرف حافظه می‌دهد.

این کد C++ نشان می‌دهد چگونه یک فایل ویدئویی بزرگ را از طریق فرآیند BLOB به یک ارائه اضافه کنید:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// یک ارائه جدید ایجاد می‌کند که ویدئو به آن اضافه خواهد شد
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// اجازه بدهید ویدئو را به ارائه اضافه کنیم - ما رفتار KeepLocked را انتخاب کردیم زیرا ما قصد داریم
// نیت دسترسی به فایل "veryLargeVideo.avi" را نداریم.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// ارائه را ذخیره می‌کند. هنگام خروج یک ارائه بزرگ، مصرف حافظه
// در طول دوره حیات شی pres کم می‌ماند
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **استخراج یک فایل بزرگ از طریق BLOB از یک ارائه**
Aspose.Slides برای C++ به شما امکان استخراج فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدئویی) از ارائه‌ها از طریق فرآیند شامل BLOBها را می‌دهد. به عنوان مثال، ممکن است نیاز داشته باشید یک فایل رسانه بزرگ را از یک ارائه استخراج کنید اما نمی‌خواهید فایل در حافظه کامپیوتر شما بارگذاری شود. با استخراج فایل از طریق فرآیند BLOB، می‌توانید مصرف حافظه را کم نگه دارید.

این کد C++ عملیات توصیف‌شده را نشان می‌دهد:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// یک نمونه Presentation ایجاد می‌کند و فایل "hugePresentationWithAudiosAndVideos.pptx" را قفل می‌نماید.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// بیایید هر ویدیو را در یک فایل ذخیره کنیم. برای جلوگیری از مصرف زیاد حافظه، به بافری نیاز داریم که استفاده شود
// برای انتقال داده‌ها از جریان ویدئوی ارائه به یک جریان برای فایل ویدئوی تازه ایجاد شده.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// بر روی ویدیوها تکرار می‌شود
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// جریان ویدئوی ارائه را باز می‌کند. لطفاً توجه کنید که ما عمداً از دسترسی به متدها خودداری کردیم
	// یا video->get_BinaryData - زیرا این متد آرایه بایتی شامل یک ویدئوی کامل را بر می‌گرداند، که سپس
	// باعث می‌شود بایت‌ها به حافظه بارگذاری شوند. ما از video->GetStream استفاده می‌کنیم که یک Stream بر می‌گرداند - و نیازی به
	// بارگذاری کل ویدئو در حافظه نداریم.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// مصرف حافظه صرف‌نظر از اندازه ویدئو یا ارائه کم خواهد ماند،
}

// در صورت نیاز، می‌توانید مراحل مشابه را برای فایل‌های صوتی اعمال کنید.
```

### **افزودن یک تصویر به عنوان BLOB به یک ارائه**
با استفاده از متدهای اینترفیس [**IImageCollection**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) و کلاس [**ImageCollection**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.image_collection)، می‌توانید یک تصویر بزرگ را به صورت استریم اضافه کنید تا به عنوان BLOB رفتار کند.

این کد C++ نشان می‌دهد چگونه یک تصویر بزرگ را از طریق فرآیند BLOB اضافه کنید:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// یک ارائه جدید ایجاد می‌کند که تصویر به آن اضافه خواهد شد.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// بیایید تصویر را به ارائه اضافه کنیم - ما رفتار KeepLocked را انتخاب می‌کنیم زیرا ما
// قصد دسترسی به فایل "largeImage.png" را نداریم.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// ارائه را ذخیره می‌کند. در حین خروج یک ارائه بزرگ، مصرف حافظه
// در طول دوره حیات شی pres کم می‌ماند
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **حافظه و ارائه‌های بزرگ**

عموماً برای بارگذاری یک ارائه بزرگ، کامپیوترها به مقدار زیادی حافظه موقت نیاز دارند. تمام محتوای ارائه در حافظه بارگذاری می‌شود و فایل منبع (که از آن ارائه بارگذاری شده) دیگر استفاده نمی‌شود.

در نظر بگیرید یک ارائه PowerPoint بزرگ (large.pptx) که شامل یک فایل ویدئویی 1.5 گیگابایتی است. روش استاندارد برای بارگذاری ارائه در این کد C++ توضیح داده شده است:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

اما این روش حدود 1.6 گیگابایت حافظه موقت مصرف می‌کند.

### **بارگذاری یک ارائه بزرگ به صورت BLOB**

از طریق فرآیند شامل BLOB می‌توانید یک ارائه بزرگ را با مصرف کم حافظه بارگذاری کنید. این کد C++ پیاده‌سازی را نشان می‌دهد که در آن فرآیند BLOB برای بارگذاری یک فایل ارائه بزرگ (large.pptx) استفاده می‌شود:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **تغییر پوشه فایل‌های موقت**

زمانی که فرآیند BLOB استفاده می‌شود، کامپیوتر شما فایل‌های موقت را در پوشه پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه دیگری نگهداری شوند، می‌توانید تنظیمات ذخیره‌سازی را با استفاده از `TempFilesRootPath` تغییر دهید:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="اطلاعات" color="info" %}}
زمانی که از `TempFilesRootPath` استفاده می‌کنید، Aspose.Slides به‌طور خودکار پوشه‌ای برای ذخیره فایل‌های موقت ایجاد نمی‌کند. شما باید پوشه را به‌صورت دستی ایجاد کنید.
{{% /alert %}}

### **آزادسازی اشیای ارائه برای رهاسازی حافظه**

هنگام پردازش ارائه‌های بزرگ، اطمینان حاصل کنید که نمونه [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) به‌درستی آزاد (Dispose) شود تا حافظه‌ای که اشغال کرده بود آزاد گردد. پس از اتمام کار با ارائه، `Dispose()` را صدا بزنید تا منابع غیرمدیریتی آزاد شوند.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **سوالات متداول**

**کدام داده‌ها در یک ارائه Aspose.Slides به عنوان BLOB در نظر گرفته می‌شوند و توسط گزینه‌های BLOB کنترل می‌شوند؟**

آبجکت‌های باینری بزرگ مانند تصاویر، صدا و ویدیو به عنوان BLOB در نظر گرفته می‌شوند. کل فایل ارائه نیز هنگام بارگذاری یا ذخیره‌سازی شامل مدیریت BLOB می‌شود. این اشیاء تحت سیاست‌های BLOB قرار دارند که به شما امکان مدیریت استفاده از حافظه و رفتن به فایل‌های موقت را می‌دهند.

**در کجا می‌توان قوانین مدیریت BLOB را هنگام بارگذاری ارائه پیکربندی کرد؟**

از [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/blobmanagementoptions/) استفاده کنید. در اینجا می‌توانید محدودیت حافظه درون‌خطی برای BLOB را تنظیم کنید، اجازه یا عدم اجازه استفاده از فایل‌های موقت را بدهید، مسیر ریشه فایل‌های موقت را انتخاب کنید و رفتار قفل‌گذاری منبع را تعیین کنید.

**آیا تنظیمات BLOB بر عملکرد تأثیر می‌گذارند و چگونه سرعت را با حافظه متعادل می‌کنیم؟**

بله. نگه داشتن BLOB در حافظه سرعت را حداکثر می‌کند اما مصرف RAM را افزایش می‌دهد؛ کاهش محدودیت حافظه باعث می‌شود کار بیشتری به فایل‌های موقت منتقل شود، که RAM را کاهش می‌دهد اما هزینه I/O بیشتری دارد. از متد [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/fa/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) برای یافتن تعادل مناسب برای حجم کار و محیط خود استفاده کنید.

**آیا گزینه‌های BLOB هنگام باز کردن ارائه‌های بسیار بزرگ (مثلاً گیگابایتی) کمک می‌کنند؟**

بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/blobmanagementoptions/) برای چنین سناریوهایی طراحی شده‌اند: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند مصرف حداکثری RAM را به‌طور چشمگیری کاهش دهد و پردازش ارائه‌های بسیار بزرگ را پایدارتر کند.

**آیا می‌توانم از سیاست‌های BLOB هنگام بارگذاری از جریان‌ها (streams) به جای فایل‌های دیسک استفاده کنم؟**

بله. همان قوانین برای جریان‌ها نیز اعمال می‌شود: نمونه ارائه می‌تواند مالک و قفل‌کننده جریان ورودی باشد (بسته به حالت قفل‌گذاری انتخاب‌شده) و فایل‌های موقت هنگام اجازه‌پذیری استفاده می‌شوند، که باعث می‌شود مصرف حافظه در طول پردازش پیش‌بینی‌پذیر بماند.