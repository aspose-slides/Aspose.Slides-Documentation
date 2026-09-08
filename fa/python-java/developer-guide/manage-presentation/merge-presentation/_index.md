---
title: ادغام مؤثر ارائه‌ها در پایتون از طریق جاوا
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/python-java/merge-presentation/
keywords:
- ادغام پاورپوینت
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- ترکیب پاورپوینت
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در پایتون از طریق جاوا با کلون کردن اسلایدها، کنترل masterها و layoutها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **بررسی کلی**

Aspose.Slides برای Python از طریق Java ارائه‌ها را با کلون کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) به دیگری ادغام می‌کند. عملیات اصلی **[SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone)** است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک master یا layout در ارائه مقصد متصل کند.

این مقاله رایج‌ترین جریان‌های ادغام را پوشش می‌دهد:

- ادغام تمام اسلایدها با حفظ قالب‌بندی منبع؛
- ادغام اسلایدهای انتخابی؛
- اعمال master از ارائه مقصد؛
- اعمال layout خاصی از ارائه مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ادغام؛
- افزودن اسلایدهای کلون‌شده به یک بخش؛
- ادغام چندین ارائه در یک جریان کار انتها به انتها؛
- مدیریت masterها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، گذرواژه‌ها، فایل‌های بزرگ و ملاحظات چندنخی.

## **چگونه کلون کردن اسلاید بر Masterها و Layoutها تأثیر می‌گذارد**

یک اسلاید بخشی از ظاهر خود را از layout و master ارث می‌برد. به همین دلیل، overloadی که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه شود.

از **[SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone)** به یکی از روش‌های زیر استفاده کنید:

- `addClone(source_slide)` — قالب‌بندی و layout اسلاید منبع را حفظ می‌کند. در صورت نیاز، master منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides به‌صورت خودکار masterهای کلون‌شده را ردیابی می‌کند تا اسلایدهای تکراری که از همان master منبع استفاده می‌کنند، چندین بار کلون نشوند.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — اسلاید کلون‌شده را به یک **[MasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/)** خاص در مقصد متصل می‌کند. Aspose.Slides برای آن master سعی می‌کند layoutی مطابقت‌دار بر اساس نوع یا نام پیدا کند.
- `addClone(source_slide, destination_layout)` — اسلاید کلون‌شده را مستقیماً به یک **[LayoutSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/)** خاص در مقصد متصل می‌کند.

master یا layoutی که به overload `addClone` پاس داده می‌شود باید متعلق به **ارائه مقصد** باشد، نه ارائه منبع.

## **ادغام کامل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی تمام اسلایدهای ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای وارد‌شده باید تم، master و روابط layout اصلی خود را حفظ کنند.

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

در نتیجه ممکن است ارائه حاوی چند master باشد وقتی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار طبیعی است زیرا قالب‌بندی منبع به‌صورت عمدی حفظ می‌شود.

## **ادغام اسلایدهای انتخابی**

لازم نیست هر اسلایدی را کلون کنید. مثال زیر تنها ایندکس اسلایدهای انتخابی را از ارائه منبع وارد می‌کند.

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

قبل از کلون کردن، ایندکس اسلایدها را زمانی که از ورودی کاربر یا تنظیمات خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از Master مقصد**

زمانی که اسلایدهای وارد‌شده باید تحت masterی که قبلاً به ارائه مقصد تعلق دارد، عمل کنند، از overload **[SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone)** استفاده کنید.

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

Aspose.Slides یک layout مناسب زیر master مشخص‌شده را بر اساس نوع یا نام layout منبع انتخاب می‌کند. اگر layout مناسبی وجود نداشته باشد و `allow_clone_missing_layout` برابر `True` باشد، layout منبع کلون می‌شود تا اسلاید قابل افزودن باشد. اگر `False` باشد، یک **[PptxEditException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxeditexception/)** پرتاب می‌شود.

وقتی می‌خواهید ادغام به‌جای افزودن layout جدید به master مقصد شکست بخورد، از `False` استفاده کنید.

## **ادغام اسلایدها با استفاده از Layout مقصد مشخص**

وقتی دقیقاً می‌دانید اسلایدهای وارد‌شده باید از کدام layout مقصد استفاده کنند، از overload **[SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone)** بهره ببرید.

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
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

اعمال layout مقصد فقط رابطهٔ ارث‌بری layout را تغییر می‌دهد؛ محتوای اسلاید منبع بازطراحی نمی‌شود. اگر layoutهای منبع و مقصد ساختار placeholderهای متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل شود قالب‌بندی ارث‌بری و رفتار placeholderها مناسب است.

## **ادغام ارائه‌ها با اندازه اسلایدهای متفاوت**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما کلون یک اسلاید به ارائه‌ای با اندازه اسلاید دیگر به‌صورت خودکار محتوای آن را برای بوم جدید بازطراحی نمی‌کند. به همین دلیل اشکال ممکن است جابه‌جا، مقیاس‌دار یا خارج از ناحیه قابل مشاهده ظاهر شوند.

یک روش عملی این است که پیش از کلون کردن، اندازه ارائه منبع را تغییر دهید. متد **[SlideSize.setSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#setSize)** می‌تواند محتوای موجود را در حین تغییر ابعاد اسلاید مقیاس‌بندی کند. **[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/)** محتوا را طوری مقیاس می‌دهد که در اندازهٔ خواسته‌شده جا بگیرد.

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

تغییر اندازه، شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر نیاز دارید ارائه منبع اصلی برای عملیات دیگر دست‌نخورده بماند، یک نمونهٔ جداگانه برای ادغام باز کنید.

## **ادغام اسلایدها در یک بخش از ارائه**

حلقهٔ پایهٔ کلون اسلایدها سلسله‌مراتبی از بخش‌های ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، بخش‌ها را در ارائه مقصد ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با **[SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone)** به آن‌ها کلون کنید.

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

اسلایدهای کلون‌شده به بخش مقصد مشخص اضافه می‌شوند. برای حفظ چندین بخش منبع، **[Presentation.getSections](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSections)** را enumerate کنید، اسلایدهای هر بخش را با **[Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getSlidesListOfSection)** دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید بازگشتی را به بخش مقصد متناظر کلون کنید. برای مثال کامل دربارهٔ enumeration بخش‌ها، شامل بخش‌های خالی و تغییرات ساختاری، به **[Manage Slide Sections](/slides/fa/python-java/slide-section/)** مراجعه کنید.

## **ادغام ایمن چندین ارائه**

مثال انتها به انتهای زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازه اسلاید هر منبع اضافی را نرمال‌سازی می‌کند، هر منبع را فقط وقتی که در حال کپی است باز نگه می‌دارد و در نهایت یکبار فایل نهایی را ذخیره می‌کند.

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

این یک پایهٔ مفید برای حفظ قالب‌بندی اسلایدهای وارد‌شده است. اگر خروجی شما باید از یک تم مقصد استفاده کند، فراخوانی سادهٔ `addClone(slide)` را با overload مرتبط با master یا layout مقصد که پیشتر نشان دادیم، جایگزین کنید.

## **ملاحظات عملی**

### **Masterها، Layoutها و دقت قالب‌بندی**

کلون اسلاید پیش‌فرض می‌تواند master مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای masterهای کلون‌شدهٔ خودکار نگه می‌دارد تا از کلون مکرر یک master جلوگیری شود. masterهای کلون‌شدهٔ دستی در آن رجیستری ثبت نمی‌شوند، بنابراین از پیش کلون کردن masterها خودداری کنید مگر اینکه کنترل صریحی بر ساختار master بخواهید.

فرض نکنید دو master یا layout با نام یکسان بصورت بصری یکسان هستند. اگر یک قالب سازمانی باید ظاهر نهایی را کنترل کند، master یا layout مقصد را صریحاً انتخاب کنید و پس از ادغام نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلایدها به محتوای اسلاید مرتبط هستند و هنگام کلون اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای **[presentation notes](/slides/fa/python-java/presentation-notes/)** و **[presentation comments](/slides/fa/python-java/presentation-comments/)** فراهم می‌کند.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائه ادغام‌شده را بررسی کنید زیرا masterهای یادداشت در سطح ارائه قرار دارند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های مرور، نویسندگان نظرات و نظرات زنجیره‌ای را پس از ترکیب فایل‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیای OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای توکار، ویدئوهای توکار و داده‌های OLE ارجاع دهند. اسلاید را به‌جای کپی فقط اشکال قابل مشاهده‌اش کلون کنید تا Aspose.Slides بتواند روابط اسلاید با منابعش را حفظ کند.

منابع توکار و لینک‌شده باید به‌صورت متفاوتی مدیریت شوند. یک صوت، ویدئو، شیء OLE یا hyperlink لینک‌شده همچنان به هدف خارجی خود وابسته است؛ کلون کردن اسلاید به‌طور خودکار یک لینک خارجی را به محتوا توکار تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ادغام‌شده باز خواهد شد، تست کنید.

Aspose.Slides به‌صورت خودکار masterهای کلون‌شده را ردیابی می‌کند، اما این به معنای تضمین عمومی برای حذف تکراری منابع باینری یکسان از ارائه‌های غیرمرتبط نیست. اگر حجم فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی و نتیجه را اندازه‌گیری کنید نه اینکه به حذف تکراری ضمنی اعتماد کنید.

### **قلم‌های توکار و در دسترس بودن قلم**

قلم‌ها در سطح ارائه مدیریت می‌شوند. اگر قلم‌نگاری باید در ماشین‌های مختلف یکسان بماند، فرض نکنید کلون اسلایدها به‌تنهایی تضمین می‌کند همه قلم‌های موردنیاز در محیط مقصد موجود باشند. می‌توانید قلم‌های توکار را با **[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts)** بررسی کنید و همان‌طور که در **[Embed Fonts in Presentations](/slides/fa/python-java/embedded-font/)** توضیح داده شده، توکار سازی را صریحاً مدیریت کنید.

همچنین اطمینان حاصل کنید که مجاز به توکار کردن قلم‌های استفاده‌شده در فایل‌های منبع هستید؛ مجوزهای قلم ممکن است توکار سازی را محدود کنند.

### **ارائه‌های محافظت‌شده با گذرواژه**

منبع محافظت‌شده بایستی قبل از کلون اسلایدها با موفقیت باز شود. گذرواژه را از طریق **[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword)** تامین کنید.

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
    # کار با ارائهٔ رمزگشایی‌شده.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

باز کردن منبع رمزگذاری‌شده به‌صورت خودکار همان محافظت را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را به‌طور جداگانه تنظیم کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ حاوی تصاویر با وضوح بالا، صدا، ویدئو یا سایر اشیای باینری بزرگ می‌توانند حافظه محسوسی مصرف کنند. **[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#getBlobManagementOptions)** کنترل‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ به **[Manage Presentation BLOBs](/slides/fa/python-java/manage-blob/)** مراجعه کنید.

برای فایل‌های بزرگ، ترجیحاً از مسیرهای فایل هنگام بارگذاری استفاده کنید، هر ارائه منبع را به‌محض اتمام ادغام آزاد کنید و از ذخیره مکرر نتایج میانی خودداری کنید مگر اینکه جریان کار به نقاط بررسی نیاز داشته باشد.

### **ایمنی در چندنخی**

از بارگذاری، تغییر، ذخیره یا کلون کردن یک نمونهٔ **[Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/)** به‌صورت هم‌زمان از چندین نخ خودداری کنید. هر نمونهٔ ارائه را به یک عملیات ادغام محدود کنید. اگر شغل‌های مستقل را به‌صورت موازی اجرا می‌کنید، از نمونه‌های مستقل استفاده کنید و راهنمای **[Aspose.Slides multithreading](/slides/fa/python-java/multithreading/)** را دنبال کنید.

## **سؤالات متداول**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از `addClone` بدون ارائه master یا layout مقصد استفاده کنید. Aspose.Slides می‌تواند master منبع را به‌صورت خودکار کلون کند هنگامی که اسلاید وارد‌شده به آن نیاز دارد.

**چگونه می‌توانم اسلایدهای وارد‌شده را تحت تم مقصد قرار دهم؟**

overloadی را که master مقصد را می‌پذیرد استفاده کنید. یک master از ارائه مقصد، نه منبع، پاس کنید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک layout مناسب تحت آن master تطبیق دهد.

**کی باید به جای master مقصد از layout مقصد خاصی استفاده کنم؟**

وقتی می‌خواهید هر اسلاید وارد‌شده از یک layout مشخص استفاده کند، از layout استفاده کنید. وقتی می‌خواهید Aspose.Slides بر پایهٔ نوع یا نام layout منبع بین layoutهای master انتخاب کند، از master استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازه اسلاید متفاوت را ادغام کرد؟**

بله، اما محتوای اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای موقعیت‌یابی پیش‌بینی‌پذیر، ابتدا منبع را با **[SlideSize.setSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#setSize)** و **[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/)** تغییر اندازه دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ادغام کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای موردنیاز را به یک مقصد کلون کنید و مقصد را در قالب خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه تمام ویژگی‌ها را به‌صورت یکسان پشتیبانی نمی‌کنند، محتوای پیچیده را پس از ادغام‌های متقابل فرمت بررسی کنید. برای فهرست فرمت‌های پشتیبانی‌شده به **[Supported File Formats](/slides/fa/python-java/supported-file-formats/)** مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

خیر. یک حلقهٔ ساده که فقط اسلایدها را کلون می‌کند، بخش‌ها را بازسازی نمی‌کند. برای حفظ ساختار بخش‌ها، آن‌ها را در مقصد بازسازی کنید و از overload بخش‌دار **[addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone)** استفاده کنید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

آن‌ها همراه با اسلایدهای کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به سبک master یادداشت‌ها، نویسندگان نظرات یا داده‌های مرور زنجیره‌ای وابسته‌اند، نتیجه ادغام را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح‑ارائه و همچنین محتوای سطح‑اسلاید هستند.

**در مورد صدا، ویدئو، اشیای OLE و لینک‌ها چه می‌شود؟**

محتوای توکار به‌عنوان بخشی از روابط منبع اسلاید کلیون‌شده منتقل می‌شود. لینک‌های خارجی همانطور که هستند باقی می‌مانند؛ بنابراین فایل‌ها یا URLهای هدف باید پس از ادغام در دسترس باشند.

**آیا قلم‌های توکار از همه منابع تضمین می‌شود که در ارائه ادغام‌شده موجود باشند؟**

به‌تنهایی به کلون اسلایدها برای استقرار قلم‌ها اعتماد نکنید. قلم‌های توکار مقصد را بررسی کنید و توکار سازی یا در دسترس بودن قلم‌های خارجی را صریحاً مدیریت کنید وقتی که تایپوگرافی مهم است.

**چگونه می‌توانم یک فایل محافظت‌شده با گذرواژه را ادغام کنم؟**

آن را با **[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword)** صحیح باز کنید، سپس اسلایدهای آن را به‌صورت معمول کلون کنید. حفاظت خروجی به‌صورت جداگانه تنظیم می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

از مدیریت BLOB استفاده کنید وقتی که اشیای باینری بزرگ حافظه را اشغال می‌کنند، برای فایل‌های بسیار بزرگ ترجیحاً از بارگذاری مسیر فایل استفاده کنید، ارائه‌های منبع را به سرعت پس از ادغام آزاد کنید و نتیجه نهایی را فقط در زمان نیاز ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین نخ ادغام کنم؟**

از یک نمونهٔ **[Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/)** به‌صورت همزمان در چندین نخ استفاده نکنید. هر عملیات ادغام را به نمونه‌های مستقل محدود کنید.