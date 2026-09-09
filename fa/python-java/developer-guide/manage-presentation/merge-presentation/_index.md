---
title: ادغام کارآمد ارائه‌ها در پایتون از طریق جاوا
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/python-java/merge-presentation/
keywords:
- ادغام PowerPoint
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در پایتون از طریق جاوا با شبیه‌سازی اسلایدها، کنترل استادها و طرح‌بندی‌ها، تغییر اندازه محتوا، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via Java ارائه‌ها را با شبیه‌سازی اسلایدها از یک [ارائه](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) به دیگری ادغام می‌کند. عملیات اصلی، [SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید شبیه‌سازی‌شده را به یک استاد (master) یا طرح‌بندی (layout) در ارائه مقصد وصل کند.

این مقاله رایج‌ترین گردش‌کارهای ادغام را شامل می‌شود:

- ادغام تمام اسلایدها با حفظ قالب‌بندی منبع؛
- ادغام اسلایدهای انتخابی؛
- اعمال یک استاد از ارائه مقصد؛
- اعمال یک طرح‌بندی خاص از ارائه مقصد؛
- نرمال‌سازی اندازه اسلایدهای مختلف قبل از ادغام؛
- افزودن اسلایدهای شبیه‌سازی‌شده به یک بخش؛
- ادغام چندین ارائه در یک گردش‌کار انتها‑به‑انتها؛
- مدیریت استادها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، رمزهای عبور، فایل‌های بزرگ و موارد چندنخی.

## **چگونه شبیه‌سازی اسلاید بر استادها و طرح‌بندی‌ها تأثیر می‌گذارد**

یک اسلاید ظاهر خود را تا حد زیادی از طرح‌بندی و استاد خود به ارث می‌برد. به همین دلیل، overload شبیه‌سازی که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) به یکی از روش‌های زیر استفاده کنید:

- `addClone(source_slide)` — قالب‌بندی و طرح‌بندی اسلاید منبع را حفظ می‌کند. در صورت نیاز، استاد منبع می‌تواند به‌صورت خودکار به ارائه مقصد شبیه‌سازی شود. Aspose.Slides به طور خودکار استادهای شبیه‌سازی‌شده را پیگیری می‌کند تا اسلایدهای تکراری که از همان استاد منبع استفاده می‌کنند، استاد را بارها شبیه‌سازی نکنند.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — اسلاید شبیه‌سازی‌شده را به یک [MasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) مقصد خاص وصل می‌کند. Aspose.Slides طرح‌بندی متناسب زیر آن استاد را بر اساس نوع یا نام طرح‌بندی جستجو می‌کند.
- `addClone(source_slide, destination_layout)` — اسلاید شبیه‌سازی‌شده را مستقیماً به یک [LayoutSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/) مقصد خاص وصل می‌کند.

استاد یا طرح‌بندی پاس‌خورده به overload `addClone` باید متعلق به **ارائه مقصد** باشد، نه ارائه منبع.

## **ادغام کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین ادغام، تمام اسلایدها را از ارائه منبع به ارائه مقصد کپی می‌کند. این گزینه زمانی مناسب است که اسلایدهای وارد‌شده باید قالب، استاد و روابط طرح‌بندی اصلی خود را داشته باشند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

ارائه حاصل ممکن است چندین استاد داشته باشد وقتی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار طبیعی است هنگامی که قالب‌بندی منبع عمداً حفظ می‌شود.

## **ادغام اسلایدهای انتخابی**

لازم نیست هر اسلایدی را شبیه‌سازی کنید. مثال زیر فقط ایندکس‌های اسلاید انتخابی را از ارائه منبع وارد می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

قبل از شبیه‌سازی ایندکس‌های اسلاید را زمانی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از استاد مقصد**

زمانی که اسلایدهای وارد‌شده باید از یک استادی پیروی کنند که قبلاً به ارائه مقصد تعلق دارد، از overload [SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides یک طرح‌بندی مناسب زیر استاد مشخص‌شده را بر اساس نوع یا نام طرح‌بندی منبع تطبیق می‌دهد. اگر طرح‌بندی مناسبی وجود نداشته باشد و `allow_clone_missing_layout` مقدار `True` داشته باشد، طرح‌بندی منبع شبیه‌سازی می‌شود تا اسلاید بتواند اضافه شود. اگر `False` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.

زمانی که می‌خواهید ادغام به‌جای افزودن طرح‌بندی جدید به استاد مقصد، شکست بخورد، از `False` استفاده کنید.

## **ادغام اسلایدها با استفاده از یک طرح‌بندی مقصد خاص**

زمانی که دقیقا می‌دانید کدام طرح‌بندی مقصد باید توسط اسلایدهای وارد‌شده استفاده شود، از overload [SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) بهره ببرید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

اعمال یک طرح‌بندی مقصد رابطهٔ وراثت طرح‌بندی را تغییر می‌دهد؛ محتوی اسلاید منبع بازطراحی نمی‌شود. اگر طرح‌بندی‌های منبع و مقصد ساختارهای نگهدارنده متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل کنید قالب‌بندی وراثتی و رفتار نگهدارنده‌ها مناسب هستند.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما شبیه‌سازی اسلایدی در ارائه‌ای با اندازه اسلاید دیگر به‌صورت خودکار محتوا را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابجا، به‌طور غیرمنتظره‌ای مقیاس‌دار یا خارج از ناحیه قابل مشاهدهٔ اسلاید ظاهر شوند.

یک روش عملی این است که پیش از شبیه‌سازی، اندازهٔ ارائه منبع را تغییر دهید. متد [SlideSize.setSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#setSize) می‌تواند محتوا را در حین تغییر ابعاد اسلاید مقیاس‌بندی کند. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/) محتوا را به‌گونه‌ای مقیاس می‌کند که در اندازهٔ درخواست‌شده جا بگیرد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

تغییر اندازهٔ ارائه منبع در حافظهٔ شیء آن انجام می‌شود. اگر نیاز دارید ارائهٔ منبع اصلی برای عملیات دیگر دست‌نخورده بماند، یک نمونهٔ جداگانه برای ادغام باز کنید.

## **ادغام اسلایدها در یک بخش از ارائه**

حلقهٔ پایهٔ شبیه‌سازی اسلاید بخش‌های سلسله‌مراتبی ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، در ارائه مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با [SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) به آن‌ها شبیه‌سازی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

اسلایدهای شبیه‌سازی‌شده به بخش مقصد مشخص‌شده افزوده می‌شوند. برای حفظ چندین بخش منبع، [Presentation.getSections](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSections) را مرور کنید، اسلایدهای فعلی هر بخش منبع را با [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getSlidesListOfSection) دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید بازگردانده‌شده را به بخش مقصد متناظر شبیه‌سازی کنید. برای مثال کامل دربارهٔ شمارش بخش‌ها، شامل بخش‌های خالی و تغییرات ساختاری، به [Manage Slide Sections](/slides/fa/python-java/slide-section/) مراجعه کنید.

## **ادغام ایمن چندین ارائه**

مثال انتها‑به‑انتها زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازهٔ اسلاید هر منبع اضافی را نرمال‌سازی می‌کند، هر منبع را تنها در زمانی که در حال کپی شدن است باز می‌نگه‌دارد و در نهایت فایل نهایی را ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

این یک پایهٔ مفید برای حفظ قالب‌بندی اسلایدهای وارد‌شده است. اگر خروجی شما باید از یک تم مقصد استفاده کند، فراخوانی سادهٔ `addClone(slide)` را با overload مناسب استاد یا طرح‌بندی مقصد که پیشتر نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **استادها، طرح‌بندی‌ها و وفاداری قالب‌بندی**

شبیه‌سازی پیش‌فرض اسلاید می‌تواند به‌صورت خودکار یک استاد موردنیاز منبع را به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای استادهای شبیه‌سازی‌شده به‌صورت خودکار نگهداری می‌کند تا از شبیه‌سازی مکرر همان استاد جلوگیری شود. استادهای شبیه‌سازی‌شده به‌صورت دستی در آن رجیستری پیگیری نمی‌شوند، لذا از پیش‌ شبیه‌سازی استادها خودداری کنید مگر اینکه نیاز به کنترل صریح ساختار استادها داشته باشید.

فرض نکنید دو استاد یا طرح‌بندی با نام یکسان بصری یک‌سان هستند. اگر یک قالب شرکتی باید ظاهر نهایی را کنترل کند، استاد یا طرح‌بندی مقصد را صریحاً انتخاب کنید و پس از ادغام نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های گوینده و نظرات اسلاید به محتوی اسلاید متصل هستند و هنگام شبیه‌سازی اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [یادداشت‌های ارائه](/slides/fa/python-java/presentation-notes/) و [نظرات ارائه](/slides/fa/python-java/presentation-comments/) فراهم می‌کند.

اگر قالب‌بندی صفحهٔ یادداشت مهم است، ارائهٔ ادغام‌شده را بررسی کنید زیرا استادهای یادداشت در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای گردش‌کارهای بازبینی، نویسندگان نظرات و نظرات زنجیره‌ای را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیاء OLE و پیوندهای خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای توکار، ویدئوهای توکار و داده‌های OLE ارجاع دهند. به‌جای کپی فقط اشکال قابل مشاهده، کل اسلاید را شبیه‌سازی کنید تا Aspose.Slides بتواند روابط اسلاید با منابعش را حفظ کند.

منابع توکار و پیوندی باید به‌صورت متفاوتی رفتار شوند. یک صدا، ویدئو، شیء OLE یا پیوند خارجی همچنان به هدف خارجی خود وابسته می‌مانند؛ شبیه‌سازی اسلاید یک پیوند خارجی را به محتوی توکار تبدیل نمی‌کند. مسیرها و URLهای منابع پیوندی را در محیطی که ارائهٔ ادغام‌شده باز خواهد شد، تست کنید.

Aspose.Slides به‌صورت صریح استادهای شبیه‌سازی‌شده به‌صورت خودکار را پیگیری می‌کند، اما این به معنای تضمین عمومی این نیست که منابع باینری یکسان از ارائه‌های نامرتبط همیشه تکرار حذف شوند. اگر اندازهٔ فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی کنید و نتیجه را اندازه‌گیری کنید به‌جای اتکا به حذف تکرار ضمنی.

### **قلم‌های توکار و در دسترس بودن قلم**

قلم‌ها در سطح ارائه مدیریت می‌شوند. اگر نگارش باید در ماشین‌های مختلف یکسان بماند، فرض نکنید شبیه‌سازی اسلایدها به تنهایی تضمین می‌کند که هر قلم موردنیاز در محیط مقصد موجود است. می‌توانید قلم‌های توکار را با [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) بررسی کنید و همان‌طور که در [Embed Fonts in Presentations](/slides/fa/python-java/embedded-font/) توضیح داده شده است، توکارسازی را صراحتاً مدیریت کنید.

همچنین اطمینان حاصل کنید که اجازهٔ توکار کردن قلم‌های استفاده‌شده در فایل‌های منبع را دارید. مجوزهای قلم ممکن است توکارسازی را محدود کنند.

### **ارائه‌های دارای رمز عبور**

یک منبع محافظت‌شده با رمز عبور باید پیش از شبیه‌سازی اسلایدها با موفقیت باز شود. رمز عبور را از طریق [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) ارائه دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # کار با ارائه رمزگشایی‌شده.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

باز کردن یک منبع رمزنگاری‌شده به‌طور خودکار همان حفاظت را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز حفاظت خروجی را جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ شامل تصاویر با وضوح بالا، صدا، ویدئو یا دیگر اشیای باینری بزرگ می‌توانند حافظهٔ قابل‌توجهی مصرف کنند. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) کنترل‌های مربوط به مدیریت BLOB و استفاده از فایل‌های موقتی را فراهم می‌کند. برای استراتژی‌های فایل بزرگ به [Manage Presentation BLOBs](/slides/fa/python-java/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، هنگام امکان، از مسیرهای فایل بارگذاری کنید، هر ارائه منبع را به محض ادغام، به‌سرعت از بین ببرید و از ذخیره‌سازی مکرر نتایج میانی مگر اینکه گردش‌کار نیاز به نقطه‌های بازرسی داشته باشد، خودداری کنید.

### **ایمنی در چندنخی**

از بارگذاری، تغییر، ذخیره‌سازی یا شبیه‌سازی همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) به‌صورت همزمان از چندین نخ استفاده نکنید. هر نمونهٔ ارائه را به یک عملیات ادغام محدود کنید. اگر کارهای مستقل را موازی می‌کنید، از نمونه‌های مستقل استفاده کنید و راهنمایی‌های [Aspose.Slides multithreading](/slides/fa/python-java/multithreading/) را دنبال کنید.

## **سوالات متداول**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از `addClone` بدون ارائه استاد یا طرح‌بندی مقصد استفاده کنید. Aspose.Slides می‌تواند در صورت نیاز استاد منبع را به‌صورت خودکار شبیه‌سازی کند.

**چگونه می‌توانم اسلایدهای واردشده را برای استفاده از تم مقصد تنظیم کنم؟**

از overloadی استفاده کنید که یک استاد مقصد می‌پذیرد. یک استاد از ارائه مقصد (نه منبع) را پاس بدهید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک طرح‌بندی مناسب زیر آن استاد نگاشت کند.

**چه زمانی باید به جای استاد مقصد از یک طرح‌بندی مقصد خاص استفاده کنم؟**

زمانی که هر اسلاید واردشده باید از یک طرح‌بندی شناخته‌شده استفاده کند، از طرح‌بندی خاص استفاده کنید. زمانی که می‌خواهید Aspose.Slides بین طرح‌بندی‌های آن استاد بر اساس نوع یا نام طرح‌بندی منبع انتخاب کند، از استاد استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازه اسلاید متفاوت را ادغام کرد؟**

بله، اما محتوی اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای جایگذاری پیش‌بینی‌شده ابتدا منبع را با [SlideSize.setSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#setSize) و [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/) تغییر اندازه دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ادغام کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای موردنیاز را به یک مقصد شبیه‌سازی کنید و مقصد را در قالب خروجی پشتیبانی‌شده ذخیره کنید. چون قالب‌های ارائه دقیقاً همان مجموعه ویژگی‌ها را ندارند، پس از ادغام‌های بین‌قالبی محتوی پیچیده را بررسی کنید. برای قالب‌های پشتیبانی‌شده به [Supported File Formats](/slides/fa/python-java/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه، یک حلقهٔ پایه که فقط اسلایدها را شبیه‌سازی می‌کند، بخش‌های منبع را حفظ نمی‌کند. بخش‌های لازم را در مقصد بازسازی کنید و هنگام نیاز به حفظ ساختار بخش، از overload بخش‌دار `addClone` استفاده کنید.

**آیا یادداشت‌های گوینده و نظرات حفظ می‌شوند؟**

آنها با اسلاید شبیه‌سازی‌شده کپی می‌شوند. برای گردش‌کارهایی که به سبک استاد یادداشت، نویسندگان نظرات یا داده‌های بازبینی زنجیره‌ای بستگی دارند، نتیجهٔ ادغام را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح ارائه نیز هستند.

**چه اتفاقی برای صداها، ویدئوها، اشیاء OLE و پیوندهای اینترنتی می‌افتد؟**

محتوی توکار به‌عنوان بخشی از روابط منابع اسلاید شبیه‌سازی‌شده حمل می‌شود. پیوندهای خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف آنها باید پس از ادغام در دسترس باشند.

**آیا قلم‌های توکار از هر منبع تضمین می‌شود که در ارائهٔ ادغام‌شده در دسترس باشند؟**

به شبیه‌سازی اسلایدها به‌تنهایی برای استقرار قلم اعتماد نکنید. قلم‌های توکار مقصد را بررسی کنید و توکارسازی قلم یا در دسترس بودن قلم خارجی را صراحتاً مدیریت کنید وقتی که نگارش مهم است.

**چگونه می‌توانم یک فایل محافظت‌شده با رمز عبور را ادغام کنم؟**

با استفاده از [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) صحیح آن را باز کنید، سپس اسلایدهای آن را معمولاً شبیه‌سازی کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

از مدیریت BLOB استفاده کنید زمانی که اشیای باینری بزرگ حافظه را اشغال می‌کنند، برای فایل‌های بسیار بزرگ ترجیحاً از بارگذاری مسیرهای فایل استفاده کنید، ارائه‌های منبع را به‌سرعت پس از ادغام نابود کنید و نتایج نهایی را فقط زمانی که لازم است ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین نخ ادغام کنم؟**

از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) به‌صورت همزمان در چندین نخ استفاده نکنید. هر عملیات ادغام را به نمونه‌های ارائهٔ مستقل محدود کنید.