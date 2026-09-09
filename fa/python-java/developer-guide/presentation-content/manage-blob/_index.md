---
title: مدیریت BLOBهای ارائه در Python از طریق Java برای استفاده کارآمد از حافظه
linktitle: مدیریت BLOB
type: docs
weight: 10
url: /fa/python-java/manage-blob/
keywords:
- شیء بزرگ
- مورد بزرگ
- فایل بزرگ
- افزودن BLOB
- صدور BLOB
- افزودن تصویر به‌عنوان BLOB
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
description: "مدیریت داده‌های BLOB در Aspose.Slides برای Python از طریق Java به‌منظور ساده‌سازی عملیات فایل‌های PowerPoint و OpenDocument برای مدیریت کارآمد ارائه‌ها."
---
## **نمای کلی**

Aspose.Slides پردازش مبتنی بر BLOB را برای داده‌های ‎binary بزرگ در ارائه‌ها فراهم می‌کند تا مصرف حافظه هنگام کار با تصاویر، صوت، ویدئو و فایل‌های ارائه بزرگ کاهش یابد.

این مقاله نحوه استفاده از پردازش مبتنی بر BLOB برای افزودن رسانه بزرگ به یک ارائه، صادر کردن رسانه بزرگ از یک ارائه و بارگذاری کارآمدتر ارائه‌های بزرگ را نشان می‌دهد. همچنین توضیح می‌دهد چگونه می‌توان از فایل‌های موقت در حین پردازش استفاده کرد و پوشه‌ای که برای ذخیرهٔ آنها به کار می‌رود را تغییر داد.

## **درباره BLOB**

یک **BLOB** (**Binary Large Object**) معمولاً یک مورد بزرگ (عکس، ارائه، سند یا رسانه) است که در قالب باینری ذخیره می‌شود.

Aspose.Slides for Python via Java به شما امکان استفاده از BLOB‌ها برای اشیاء را می‌دهد به‌طوری که هنگام کار با فایل‌های بزرگ مصرف حافظه کاهش یابد.

{{% alert color="info" title="Note" %}}
برای دور زدن برخی محدودیت‌ها هنگام تعامل با جریان‌ها، Aspose.Slides ممکن است محتوای جریان را کپی کند. بارگذاری یک ارائه بزرگ از طریق جریان آن منجر به کپی شدن محتویات ارائه و سرعت پایین بارگذاری می‌شود. بنابراین، هنگامی‌که قصد بارگذاری یک ارائه بزرگ را دارید، به‌ شدت توصیه می‌کنیم مسیر فایل ارائه را استفاده کنید نه جریان آن.
{{% /alert %}}

## **استفاده از BLOB‌ها برای کاهش مصرف حافظه**

### **افزودن یک فایل بزرگ به ارائه با استفاده از BLOB‌ها**

[Aspose.Slides](/slides/fa/python-java/) for Python via Java به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل ویدئویی بزرگ) را از طریق فرآیند مبتنی بر BLOB اضافه کنید تا مصرف حافظه کاهش یابد.

این کد Python نشان می‌دهد چگونه یک فایل ویدئویی بزرگ را از طریق فرآیند BLOB به یک ارائه اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# یک ارائه جدید ایجاد می‌کند که ویدئو به آن اضافه خواهد شد.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        #        جریانی را قفل می‌ماند زیرا قصد دسترسی به فایل ویدئو را نداریم.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        #        ارائه را ذخیره می‌کند در حالی که مصرف حافظه را پایین نگه می‌دارد.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **صادر کردن یک فایل بزرگ از ارائه با استفاده از BLOB‌ها**
Aspose.Slides for Python via Java به شما امکان می‌دهد فایل‌های بزرگ (در این مثال، یک فایل صوتی یا ویدئویی) را از طریق فرآیند مبتنی بر BLOB از ارائه‌ها استخراج کنید. برای مثال، ممکن است بخواهید یک فایل رسانه‌ای بزرگ را از یک ارائه استخراج کنید اما نمی‌خواهید فایل در حافظهٔ کامپیوتر شما بارگذاری شود. با صادر کردن فایل از طریق فرآیند BLOB، مصرف حافظه کم می‌ماند.

این کد Python عملیات توضیح داده شده را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# فایل منبع را قفل می‌کند به جای بارگذاری آن در حافظه.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # انتقال داده‌های ویدئو از طریق یک بافر برای حفظ مصرف کم حافظه.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # استفاده از جریان به جای بارگذاری تمام ویدئو در یک آرایه بایت.
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
    # در صورت نیاز، همان مراحل را برای فایل‌های صوتی اعمال کنید.
finally:
    presentation.dispose()
```

### **افزودن یک تصویر به عنوان BLOB به ارائه**
با استفاده از روش‌های کلاس [ImageCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/) می‌توانید یک تصویر بزرگ را به‌عنوان یک جریان اضافه کنید تا به‌عنوان BLOB در نظر گرفته شود.

این کد Python نشان می‌دهد چگونه یک تصویر بزرگ را از طریق فرآیند BLOB اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# یک ارائه جدید ایجاد می‌کند که تصویر به آن اضافه خواهد شد.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        #        جریان را قفل می‌ماند چون قصد دسترسی به فایل تصویر را نداریم.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        #        ارائه را ذخیره می‌کند در حالی که مصرف حافظه را پایین نگه می‌دارد.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **حافظه و ارائه‌های بزرگ**

به طور معمول، برای بارگذاری یک ارائه بزرگ، کامپیوترها به مقدار زیادی حافظه موقت نیاز دارند. تمام محتویات ارائه در حافظه بارگذاری می‌شود و فایل (که از آن ارائه بارگذاری شده) دیگر استفاده نمی‌شود.

یک ارائه PowerPoint بزرگ (large.pptx) را در نظر بگیرید که حاوی یک فایل ویدئویی ۱.۵ ‎GB است. روش استاندارد بارگذاری ارائه در کد Python زیر توصیف شده است:

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

اما این روش تقریباً ۱.۶ ‎GB حافظه موقت مصرف می‌کند.

### **بارگذاری یک ارائه بزرگ به‌عنوان BLOB**

با استفاده از پردازش BLOB می‌توانید یک ارائه بزرگ را با مصرف کم حافظه بارگذاری کنید. این کد Python نشان می‌دهد چگونه از پردازش BLOB برای بارگذاری یک فایل ارائه بزرگ (large.pptx) استفاده کنید:

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

### **تغییر پوشهٔ فایل‌های موقت**

هنگامی‌که فرآیند BLOB استفاده می‌شود، کامپیوتر شما فایل‌های موقت را در پوشهٔ پیش‌فرض فایل‌های موقت ایجاد می‌کند. اگر می‌خواهید فایل‌های موقت در پوشه‌ای متفاوت نگهداری شوند، می‌توانید تنظیمات ذخیره‌سازی را با استفاده از [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) تغییر دهید:

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
وقتی از [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) استفاده می‌کنید، Aspose.Slides به‌طور خودکار پوشه‌ای برای ذخیرهٔ فایل‌های موقت ایجاد نمی‌کند. شما باید این پوشه را به‌صورت دستی ایجاد کنید.
{{% /alert %}}

### **از بین بردن اشیای Presentation برای آزادسازی حافظه**

هنگام پردازش ارائه‌های بزرگ، اطمینان حاصل کنید که نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) به‌درستی از بین رفته تا حافظه‌ای که اشغال کرده بود آزاد شود. پس از اتمام استفاده از ارائه، برای آزادسازی منابع غیر مدیریتی، [Presentation.dispose](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#dispose) را فراخوانی کنید.

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
    # صراحتاً منابع را آزاد کنید.
    presentation.dispose()
```

## **پرسش‌های متداول**

**کدام داده‌ها در یک ارائه Aspose.Slides به‌عنوان BLOB در نظر گرفته می‌شوند و توسط گزینه‌های BLOB کنترل می‌شوند؟**

اشیای ‎binary بزرگ مانند تصاویر، صوت و ویدئو به‌عنوان BLOB در نظر گرفته می‌شوند. کل فایل ارائه نیز هنگام بارگذاری یا ذخیره‌سازی شامل پردازش BLOB می‌شود. این اشیاء تحت سیاست‌های BLOB قرار دارند که به شما امکان مدیریت مصرف حافظه و استفاده از فایل‌های موقت را می‌دهد.

**در کجا می‌توانم قوانین پردازش BLOB را هنگام بارگذاری ارائه تنظیم کنم؟**

از [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) همراه با [BlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/) استفاده کنید. در اینجا می‌توانید محدودیت حافظه‌ای برای BLOBها، اجازه یا عدم اجازهٔ فایل‌های موقت، مسیر ریشهٔ فایل‌های موقت و رفتار قفل‌گذاری منبع را تنظیم کنید.

**آیا تنظیمات BLOB بر عملکرد تأثیر می‌گذارند و چگونه می‌توان سرعت را با حافظه تعادل داد؟**

بله. نگه داشتن BLOBها در حافظه سرعت را حداکثر می‌کند اما مصرف RAM را افزایش می‌دهد؛ کاهش محدودیت حافظه باعث انتقال کار بیشتر به فایل‌های موقت می‌شود و RAM را کاهش می‌دهد ولی با هزینهٔ I/O بیشتر. برای یافتن تعادل مناسب برای بار کاری و محیط خود از متد [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) استفاده کنید.

**آیا گزینه‌های BLOB در هنگام باز کردن ارائه‌های بسیار بزرگ (مثلاً گیگابایت) مفید هستند؟**

بله. [BlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blobmanagementoptions/) برای چنین سناریوهایی طراحی شده است: فعال‌سازی فایل‌های موقت و استفاده از قفل‌گذاری منبع می‌تواند به‌طور قابل توجهی استفادهٔ حداکثری RAM را کاهش دهد و پردازش ارائه‌های بسیار بزرگ را پایدارتر کند.

**آیا می‌توانم سیاست‌های BLOB را هنگام بارگذاری از جریان‌ها به‌جای فایل‌های دیسک استفاده کنم؟**

بله. همان قوانین برای جریان‌ها اعمال می‌شود: نمونهٔ ارائه می‌تواند مالک و قفل‌کنندهٔ جریان ورودی باشد (بسته به حالت قفل‌گذاری انتخابی) و هنگامی که اجازه داده شود، فایل‌های موقت برای پیش‌بینی مصرف حافظه در حین پردازش استفاده می‌شوند.