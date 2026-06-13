---
title: مدیریت BLOBهای ارائه در PHP برای استفاده بهینه از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/php-java/manage-blob/
keywords:
- شیء بزرگ
- آیتم بزرگ
- فایل بزرگ
- افزودن BLOB
- صادر کردن BLOB
- افزودن تصویر به عنوان BLOB
- کاهش حافظه
- مصرف حافظه
- ارائه بزرگ
- فایل موقت
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت داده‌های BLOB در Aspose.Slides برای PHP از طریق Java جهت ساده‌سازی عملیات فایل‌های PowerPoint و OpenDocument برای مدیریت کارآمد ارائه‌ها."
---
## **مرور کلی**

Aspose.Slides مدیریت مبتنی بر BLOB را برای داده‌های باینری بزرگ در ارائه‌ها فراهم می‌کند تا با کار با تصاویر، صوت، ویدئو و فایل‌های ارائه بزرگ، مصرف حافظه را کاهش دهد.

این مقاله نشان می‌دهد چگونه از پردازش مبتنی بر BLOB برای افزودن رسانه بزرگ به یک ارائه، استخراج رسانه بزرگ از یک ارائه و بارگذاری ارائه‌های بزرگ به طور کارآمدتر استفاده کنید. همچنین توضیح می‌دهد چگونه می‌توان از فایل‌های موقت در حین پردازش استفاده کرد و چگونه پوشه‌ای را که برای ذخیره آن‌ها استفاده می‌شود تغییر داد.

## **درباره BLOB**

**BLOB** (**Binary Large Object**) معمولاً یک مورد بزرگ (عکس، ارائه، سند یا رسانه) است که در قالب باینری ذخیره می‌شود.  

Aspose.Slides برای PHP از طریق Java به شما اجازه می‌دهد تا BLOB‌ها را برای اشیاء به گونه‌ای استفاده کنید که مصرف حافظه هنگام کار با فایل‌های بزرگ کاهش یابد.

{{% alert title="Info" color="info" %}}
برای دور زدن برخی محدودیت‌ها هنگام تعامل با جریان‌ها، Aspose.Slides ممکن است محتوای جریان را کپی کند. بارگذاری یک ارائه بزرگ از طریق جریان آن منجر به کپی‌کردن محتویات ارائه می‌شود و بارگذاری را کند می‌سازد. بنابراین، وقتی قصد بارگذاری یک ارائه بزرگ را دارید، به شدت توصیه می‌کنیم مسیر فایل ارائه را استفاده کنید نه جریان آن.
{{% /alert %}}

## **استفاده از BLOB برای کاهش مصرف حافظه**

### **افزودن یک فایل بزرگ از طریق BLOB به یک ارائه**

[Aspose.Slides](/slides/fa/php-java/) برای Java به شما اجازه می‌دهد تا فایل‌های بزرگ (در این مثال، یک فایل ویدئوی بزرگ) را از طریق فرآیند شامل BLOBها برای کاهش مصرف حافظه اضافه کنید.

این Java به شما نشان می‌دهد چگونه یک فایل ویدئوی بزرگ را از طریق فرآیند BLOB به یک ارائه اضافه کنید:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # یک ارائه جدید ایجاد می‌کند که ویدیو به آن اضافه خواهد شد
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # بیایید ویدیو را به ارائه اضافه کنیم - ما رفتار KeepLocked را انتخاب کردیم زیرا
      # قصد دسترسی به فایل "veryLargeVideo.avi" را نداریم.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # ارائه را ذخیره می‌کند. هنگامی که یک ارائه بزرگ خروجی می‌شود، مصرف حافظه
      # در طول دوره حیات شیء pres کم می‌ماند
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **صادر کردن یک فایل بزرگ از طریق BLOB از یک ارائه**

Aspose.Slides برای PHP از طریق Java به شما اجازه می‌دهد تا فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدئویی) را از طریق فرآیند شامل BLOBها از ارائه‌ها صادر کنید. به‌عنوان مثال، ممکن است نیاز داشته باشید یک فایل رسانه‌ای بزرگ را از یک ارائه استخراج کنید اما نمی‌خواهید فایل در حافظه کامپیوتر شما بارگذاری شود. با صادر کردن فایل از طریق فرآیند BLOB، می‌توانید مصرف حافظه را کم نگه دارید.

این کد عملیات توصیف‌شده را نشان می‌دهد:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # فایل منبع را قفل می‌کند و آن را در حافظه بارگذاری نمی‌کند
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # یک نمونه Presentation ایجاد می‌کند و فایل "hugePresentationWithAudiosAndVideos.pptx" را قفل می‌کند.
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # بیایید هر ویدیو را در یک فایل ذخیره کنیم. برای جلوگیری از استفاده زیاد حافظه، به بافری نیاز داریم که استفاده شود
    # برای انتقال داده‌ها از جریان ویدیو ارائه به یک جریان برای فایل ویدیوی تازه ایجاد شده.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # از ویدیوها عبور می‌کند
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # جریان ویدیو ارائه را باز می‌کند. لطفاً توجه داشته باشید که عمداً از دسترسی به ویژگی‌ها جلوگیری کردیم
      # مانند video.BinaryData - زیرا این ویژگی آرایه بایتی شامل تمام ویدیو را برمی‌گرداند که سپس
      # باعث می‌شود بایت‌ها در حافظه بارگذاری شوند. ما از video.GetStream استفاده می‌کنیم که Stream برمی‌گرداند - و نیازی به
      # بارگذاری کل ویدیو در حافظه نداریم.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # مصرف حافظه صرف‌نظر از حجم ویدیو یا ارائه، کم باقی می‌ماند.
    }
    # در صورت نیاز، می‌توانید همان مراحل را برای فایل‌های صوتی اعمال کنید.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **افزودن یک تصویر به عنوان BLOB به یک ارائه**

با استفاده از متدهای کلاس [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) می‌توانید یک تصویر بزرگ را به عنوان جریان اضافه کنید تا به عنوان BLOB در نظر گرفته شود.

این کد PHP به شما نشان می‌دهد چگونه یک تصویر بزرگ را از طریق فرآیند BLOB به یک ارائه اضافه کنید:
```php
  $pathToLargeImage = "large_image.jpg";
  # یک ارائه جدید ایجاد می‌کند که تصویر به آن اضافه خواهد شد.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # بیایید تصویر را به ارائه اضافه کنیم - ما رفتار KeepLocked را انتخاب می‌کنیم چون ما
      # قصد دسترسی به فایل "largeImage.png" را نداریم.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # ارائه را ذخیره می‌کند. هنگام خروج یک ارائه بزرگ، مصرف حافظه
      # در طول دوره حیات شیء pres کم می‌ماند.
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حافظه و ارائه‌های بزرگ**

معمولاً برای بارگذاری یک ارائه بزرگ، کامپیوترها به مقدار زیادی حافظه موقت نیاز دارند. تمام محتویات ارائه در حافظه بارگذاری می‌شود و فایلی که ارائه از آن بارگذاری شده است دیگر استفاده نمی‌شود.

مثال: یک ارائه PowerPoint بزرگ (large.pptx) که شامل یک فایل ویدئویی 1.5 گیگابایتی است. روش استاندارد برای بارگذاری ارائه در این کد PHP توصیف شده است:
```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

اما این روش حدود 1.6 گیگابایت حافظه موقت مصرف می‌کند.

### **بارگذاری یک ارائه بزرگ به عنوان BLOB**

از طریق فرآیند شامل BLOB می‌توانید یک ارائه بزرگ را با استفاده از حافظه کم بارگذاری کنید. این کد PHP پیاده‌سازی‌ای را توصیف می‌کند که در آن فرآیند BLOB برای بارگذاری یک فایل ارائه بزرگ (large.pptx) استفاده می‌شود:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تغییر پوشه فایل‌های موقت**

زمانی که فرآیند BLOB استفاده می‌شود، کامپیوتر شما فایل‌های موقت را در پوشه پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه‌ای متفاوت نگهداری شوند، می‌توانید تنظیمات ذخیره‌سازی را با استفاده از `setTempFilesRootPath` تغییر دهید:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
هنگامی که از `setTempFilesRootPath` استفاده می‌کنید، Aspose.Slides به‌صورت خودکار پوشه‌ای برای ذخیره فایل‌های موقت ایجاد نمی‌کند. شما باید این پوشه را به‌صورت دستی ایجاد کنید.
{{% /alert %}}

### **از بین بردن اشیای Presentation برای آزادسازی حافظه**

هنگام پردازش ارائه‌های بزرگ، اطمینان حاصل کنید که نمونه [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) به‌درستی از بین رفته باشد تا حافظه‌ای که اشغال کرده بود آزاد شود. پس از اتمام کار با ارائه، `dispose()` را فراخوانی کنید تا منابع مدیریت‌نشده آزاد شوند.
```php
$presentation = new Presentation("large.pptx");

# ...ارائه را پردازش کنید...
$presentation->save("large.pdf", SaveFormat::Pdf);

# به صراحت منابع را آزاد کنید.
$presentation->dispose();
```

## **سؤالات متداول**

**کدام داده‌ها در یک ارائه Aspose.Slides به‌عنوان BLOB در نظر گرفته می‌شوند و توسط گزینه‌های BLOB کنترل می‌شوند؟**

اشیاء باینری بزرگ مانند تصاویر، صدا و ویدئو به‌عنوان BLOB در نظر گرفته می‌شوند. کل فایل ارائه نیز هنگام بارگذاری یا ذخیره‌سازی شامل پردازش BLOB می‌شود. این اشیاء تحت سیاست‌های BLOB قرار دارند که به شما امکان مدیریت مصرف حافظه و استفاده از فایل‌های موقت را می‌دهند.

**کجا می‌توانم قوانین پردازش BLOB را در هنگام بارگذاری ارائه پیکربندی کنم؟**

از [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/blobmanagementoptions/) استفاده کنید. در اینجا می‌توانید محدودیت حافظه درون‌حافظه‌ای برای BLOB را تنظیم کنید، اجازه یا عدم اجازه فایل‌های موقت، مسیر ریشه برای فایل‌های موقت و رفتار قفل‌گذاری منبع را مشخص کنید.

**آیا تنظیمات BLOB بر عملکرد تاثیر می‌گذارند و چگونه می‌توان سرعت را در برابر حافظه متعادل کرد؟**

بله. نگه داشتن BLOB در حافظه سرعت را به حداکثر می‌رساند اما مصرف RAM را افزایش می‌دهد؛ کاهش حد حافظه کار را بیشتر به فایل‌های موقت می‌سپارد، که RAM را کاهش می‌دهد ولی I/O بیشتری ایجاد می‌کند. از متد [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) برای یافتن تعادل مناسب برای بار کاری و محیط خود استفاده کنید.

**آیا گزینه‌های BLOB در هنگام باز کردن ارائه‌های بسیار بزرگ (مثلاً گیگابایتی) مفید هستند؟**

بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/blobmanagementoptions/) برای این سناریوها طراحی شده‌اند: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند به‌طور چشمگیری مصرف حداکثری RAM را کاهش داده و پردازش ارائه‌های بسیار بزرگ را پایدارتر کند.

**آیا می‌توانم از سیاست‌های BLOB هنگام بارگذاری از جریان‌ها به جای فایل‌های دیسک استفاده کنم؟**

بله. همان قوانین بر روی جریان‌ها نیز اعمال می‌شود: نمونه ارائه می‌تواند مالک و قفل‌کننده جریان ورودی باشد (بسته به حالت قفل‌گذاری انتخاب‌شده) و فایل‌های موقت زمانی که اجازه داده شوند، مورد استفاده قرار می‌گیرند تا مصرف حافظه در طول پردازش قابل پیش‌بینی بماند.