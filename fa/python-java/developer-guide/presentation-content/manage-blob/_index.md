---
title: مدیریت BLOBهای ارائه در Python از طریق Java برای استفاده بهینه از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/python-java/manage-blob/
keywords:
- شیء بزرگ
- آیتم بزرگ
- فایل بزرگ
- اضافه کردن BLOB
- صدور BLOB
- اضافه کردن تصویر به‌عنوان BLOB
- کاهش حافظه
- مصرف حافظه
- ارائه بزرگ
- فایل موقت
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "داده‌های BLOB را در Aspose.Slides برای Python از طریق Java مدیریت کنید تا عملیات فایل‌های PowerPoint و OpenDocument را برای پردازش مؤثر ارائه‌ها بهینه کنید."
---
## **مرور کلی**

Aspose.Slides مدیریت مبتنی بر BLOB را برای داده‌های دودویی بزرگ در ارائه‌ها فراهم می‌کند تا مصرف حافظه هنگام کار با تصاویر، صدا، ویدیو و فایل‌های ارائه بزرگ کاهش یابد.

این مقاله نشان می‌دهد چطور از پردازش مبتنی بر BLOB برای افزودن رسانه‌های بزرگ به یک ارائه، خروجی گرفتن رسانه‌های بزرگ از یک ارائه، و بارگذاری ارائه‌های بزرگ به‌صورت کارآمد استفاده کنید. همچنین توضیح می‌دهد چطور می‌توان در حین پردازش از فایل‌های موقت استفاده کرد و پوشه ذخیره‌سازی آنها را تغییر داد.

## **درباره BLOB**

**BLOB** (**Binary Large Object**) معمولاً یک مورد بزرگ (عکس، ارائه، سند یا رسانه) است که به‌صورت دودویی ذخیره می‌شود.

Aspose.Slides for Python via Java به شما اجازه می‌دهد تا BLOBها را برای اشیاء به‌کار ببرید به‌طریقی که مصرف حافظه هنگام کار با فایل‌های بزرگ کاهش یابد.

{{% alert color="info" title="Note" %}}
برای دور زدن برخی محدودیت‌ها هنگام تعامل با جریان‌ها، Aspose.Slides ممکن است محتوای جریان را کپی کند. بارگذاری یک ارائه بزرگ از طریق جریان آن منجر به کپی شدن محتویات ارائه و بارگذاری آهسته می‌شود. بنابراین، هنگام تمایل به بارگذاری یک ارائه بزرگ، به‌شدت توصیه می‌کنیم از مسیر فایل ارائه استفاده کنید نه از جریان آن.
{{% /alert %}}

## **استفاده از BLOB برای کاهش مصرف حافظه**

### **افزودن فایل بزرگ از طریق BLOB به یک ارائه**

[Aspose.Slides](/slides/fa/python-java/) for Python via Java به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل ویدیویی بزرگ) را از طریق فرآیند BLOB به‌منظور کاهش مصرف حافظه به یک ارائه اضافه کنید.

این کد پایتون نشان می‌دهد چطور یک فایل ویدیویی بزرگ را از طریق فرآیند BLOB به یک ارائه اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# یک ارائه جدید ایجاد کنید که ویدیو به آن اضافه می‌شود.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # جریان را قفل نگه دارید زیرا قصد دسترسی به فایل ویدیو را نداریم.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # ارائه را ذخیره کنید در حالی که مصرف حافظه کم نگه داشته می‌شود.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **خروجی گرفتن فایل بزرگ از طریق BLOB از ارائه**
Aspose.Slides for Python via Java به شما اجازه می‌دهد فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدیویی) را از طریق فرآیند BLOB از ارائه‌ها استخراج کنید. برای مثال، ممکن است نیاز داشته باشید یک فایل رسانه‌ای بزرگ را از یک ارائه استخراج کنید اما نمی‌خواهید فایل در حافظه کامپیوتر شما بارگذاری شود. با خروجی گرفتن فایل از طریق فرآیند BLOB، مصرف حافظه کم می‌ماند.

این کد پایتون عملیات توصیف‌شده را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# قفل کردن فایل منبع به‌جای بارگذاری آن در حافظه.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # انتقال داده‌های ویدیو از طریق یک بافر برای حفظ مصرف کم حافظه.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # از جریان استفاده کنید به‌جای بارگذاری کل ویدیو به‌صورت آرایه بایت.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # در صورت لزوم، همان مراحل را روی فایل‌های صوتی اعمال کنید.
finally:
    presentation.dispose()
```

### **افزودن تصویر به‌عنوان BLOB به یک ارائه**
با استفاده از متدهای کلاس [ImageCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/)، می‌توانید یک تصویر بزرگ را به‌صورت جریان اضافه کنید تا به‌عنوان BLOB در نظر گرفته شود.

این کد پایتون نشان می‌دهد چطور یک تصویر بزرگ را از طریق فرآیند BLOB اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# یک ارائه جدید ایجاد کنید که تصویر به آن اضافه می‌شود.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # جریان را قفل نگه دارید زیرا قصد دسترسی به فایل تصویر را نداریم.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # ارائه را ذخیره کنید در حالی که مصرف حافظه کم نگه داشته می‌شود.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **حافظه و ارائه‌های بزرگ**

به‌طور معمول، برای بارگذاری یک ارائه بزرگ، کامپیوترها به مقدار زیادی حافظه موقت نیاز دارند. تمام محتوای ارائه در حافظه بارگذاری می‌شود و فایل (که ارائه از آن بارگذاری شده) دیگر استفاده نمی‌شود.

مثال: یک ارائه بزرگ PowerPoint (large.pptx) که شامل یک فایل ویدئویی 1.5 GB است. روش استاندارد برای بارگذاری ارائه در این کد پایتون توضیح داده شده است:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

اما این روش حدود 1.6 GB حافظه موقت مصرف می‌کند.

### **بارگذاری یک ارائه بزرگ به‌عنوان BLOB**

از طریق فرآیند مبتنی بر BLOB می‌توانید یک ارائه بزرگ را با مصرف کم حافظه بارگذاری کنید. این کد پایتون پیاده‌سازی‌ای را توصیف می‌کند که در آن از فرآیند BLOB برای بارگذاری یک فایل ارائه بزرگ (large.pptx) استفاده می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **تغییر پوشه فایل‌های موقت**

زمانی که فرآیند BLOB استفاده می‌شود، کامپیوتر شما فایل‌های موقت را در پوشه پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه دیگری نگهداری شوند، می‌توانید تنظیمات ذخیره‌سازی را با استفاده از [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) تغییر دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
زمانی که از [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) استفاده می‌کنید، Aspose.Slides به‌طور خودکار پوشه‌ای برای ذخیره‌سازی فایل‌های موقت ایجاد نمی‌کند. شما باید این پوشه را به‌صورت دستی بسازید.
{{% /alert %}}

### **از بین بردن اشیاء Presentation برای آزاد کردن حافظه**

هنگام پردازش ارائه‌های بزرگ، اطمینان حاصل کنید که نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) به‌درستی از بین رفته تا حافظه‌ای که اشغال کرده بود آزاد شود. پس از پایان کار با ارائه، برای آزادسازی منابع غیرمدیریت‌شده، متد [Presentation.dispose](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#dispose) را فراخوانی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...پردازش ارائه...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # صریحاً منابع را آزاد کنید.
    presentation.dispose()
```

## **سوالات متداول**

**کدام داده‌ها در یک ارائه Aspose.Slides به‌عنوان BLOB در نظر گرفته می‌شوند و توسط گزینه‌های BLOB کنترل می‌شوند؟**

اشیاء دودویی بزرگ مانند تصاویر، صدا و ویدیو به‌عنوان BLOB در نظر گرفته می‌شوند. کل فایل ارائه نیز هنگام بارگذاری یا ذخیره‌سازی شامل پردازش BLOB می‌شود. این اشیاء تحت سیاست‌های BLOB قرار دارند که به شما امکان مدیریت مصرف حافظه و انتقال به فایل‌های موقت را می‌دهند.

**در کجا می‌توان قوانین پردازش BLOB را هنگام بارگذاری ارائه تنظیم کرد؟**

از [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/) استفاده کنید. در آنجا می‌توانید محدودیت حافظه‌ای برای BLOB تنظیم کنید، اجازه یا عدم اجازه استفاده از فایل‌های موقت را بدهید، مسیر ریشه‌ای برای فایل‌های موقت را انتخاب کنید و رفتار قفل‌گذاری منبع را تعیین کنید.

**آیا تنظیمات BLOB بر عملکرد تأثیر می‌گذارند و چگونه می‌توان سرعت را در مقابل حافظه متعادل کرد؟**

بله. نگهداری BLOB در حافظه سرعت را حداکثر می‌کند اما مصرف RAM را افزایش می‌دهد؛ کاهش حد حافظه باعث می‌شود کار بیشتری به فایل‌های موقت منتقل شود، در نتیجه RAM کاهش می‌یابد ولی I/O بیشتری رخ می‌دهد. از متد [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) برای پیدا کردن تعادل مناسب برای بار کاری و محیط خود استفاده کنید.

**آیا گزینه‌های BLOB هنگام باز کردن ارائه‌های بسیار بزرگ (مثلاً گیگابایتی) مفید هستند؟**

بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/) برای چنین سناریوهایی طراحی شده‌اند: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند به‌طور قابل توجهی مصرف حداکثری RAM را کاهش داده و پردازش ارائه‌های بسیار بزرگ را پایدارتر کند.

**آیا می‌توانم از سیاست‌های BLOB هنگام بارگذاری از جریان‌ها به‌جای فایل‌های دیسک استفاده کنم؟**

بله. همان قوانین بر روی جریان‌ها نیز اعمال می‌شود: نمونهٔ ارائه می‌تواند مالک و قفل‌کنندهٔ جریان ورودی باشد (بسته به حالت قفل‌گذاری انتخابی) و فایل‌های موقت هنگام اجازه‌دار شدن استفاده می‌شوند تا مصرف حافظه در طول پردازش قابل پیش‌بینی بماند.