---
title: ادغام مؤثر ارائه‌ها با پایتون
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/python-net/merge-presentation/
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
- Aspose.Slides
description: "یاد بگیرید چگونه در پایتون ارائه‌های PowerPoint و OpenDocument را با کلون کردن اسلایدها، کنترل مسترها و طرح‌بندی‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **نگاه کلی**

Aspose.Slides for Python via .NET با کلون کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) به دیگری، ارائه‌ها را ادغام می‌کند. عملیات اصلی [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا طرح‌بندی در ارائه مقصد متصل کند.

این مقاله رایج‌ترین جریان‌های ادغام را پوشش می‌دهد:

- ادغام تمام اسلایدها در حالی که قالب‌بندی منبع حفظ می‌شود؛
- ادغام اسلایدهای انتخابی؛
- اعمال یک مستر از ارائه مقصد؛
- اعمال یک طرح‌بندی خاص از ارائه مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ادغام؛
- افزودن اسلایدهای کلون‌شده به یک بخش؛
- ادغام چندین ارائه در یک جریان کار انتها‑به‑انتها؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، گذرواژه‌ها، فایل‌های بزرگ و ملاحظات چندنخی.

## **چگونگی تأثیر کلون اسلاید بر مسترها و طرح‌بندی‌ها**

یک اسلاید بیشتر ظاهر خود را از طرح‌بندی و مستر خود به ارث می‌برد. به همین دلیل، overload کلونینگ که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) به یکی از روش‌های زیر استفاده کنید:

- `add_clone(source_slide)` — حفظ طرح‌بندی و قالب‌بندی اسلاید منبع. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides مسترهای کلون‌شده به‌طور خودکار را ردیابی می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را بارها کلون نکنند.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — اسلاید کلون‌شده را به یک [IMasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterslide/) مقصد خاص متصل می‌کند. Aspose.Slides با جستجوی یک طرح‌بندی همسان تحت آن مستر، بر اساس نوع یا نام طرح‌بندی، عمل می‌کند.
- `add_clone(source_slide, destination_layout)` — اسلاید کلون‌شده را مستقیماً به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ilayoutslide/) مقصد خاص متصل می‌کند.

مستر یا طرح‌بندی‌ای که به overload `add_clone` پاس داده می‌شود باید متعلق به **ارائه مقصد** باشد، نه ارائه منبع.

## **ادغام تمام ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی کردن هر اسلاید از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید تم، مستر و روابط طرح‌بندی اصلی خود را حفظ کنند.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

در نتیجه ممکن است ارائه حاوی چند مستر باشد هنگامی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار طبیعی است وقتی قالب‌بندی منبع عمداً حفظ می‌شود.

## **ادغام اسلایدهای انتخابی**

لازم نیست هر اسلاید را کلون کنید. مثال زیر فقط ایندکس‌های اسلاید انتخاب شده از ارائه منبع را وارد می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

قبل از کلون، ایندکس‌های اسلاید را زمانی که از ورودی کاربر یا تنظیمات خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از یک مستر مقصد**

از overload [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) زمانی استفاده کنید که اسلایدهای وارد شده باید از یک مستر که قبلاً به ارائه مقصد تعلق دارد، پیروی کنند.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides یک طرح‌بندی مناسب تحت مستر مشخص‌شده را بر اساس نوع یا نام طرح‌بندی منبع انتخاب می‌کند. اگر طرح‌بندی مناسبی موجود نباشد و `allow_clone_missing_layout` برابر `True` باشد، طرح‌بندی منبع کلون می‌شود تا اسلاید اضافه شود. اگر `False` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) پرتاب می‌شود.

زمانی که می‌خواهید ادغام به جای افزودن یک طرح‌بندی جدید به مستر مقصد شکست بخورد، از `False` استفاده کنید.

## **ادغام اسلایدها با استفاده از یک طرح‌بندی مقصد خاص**

از overload [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) زمانی استفاده کنید که دقیقاً می‌دانید کدام طرح‌بندی مقصد باید برای اسلایدهای وارد شده به‌کار رود.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

اعمال یک طرح‌بندی مقصد فقط رابطهٔ طرح‌بندی ارث‌بری را تغییر می‌دهد؛ محتوای اسلاید منبع را دوباره طراحی نمی‌کند. اگر طرح‌بندی‌های منبع و مقصد ساختارهای جایگذار (placeholder) متفاوتی داشته باشند، نتیجه را بررسی کنید تا از مناسب بودن قالب‌بندی ارث‌بری و رفتار جایگذارها اطمینان حاصل کنید.

## **ادغام ارائه‌ها با اندازه اسلایدهای متفاوت**

ارائه‌های با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما کلون یک اسلاید به ارائه‌ای با اندازهٔ اسلاید دیگر به‌صورت خودکار محتوای آن را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابجا، مقیاس‌گذاری ناخواسته یا خارج از ناحیهٔ قابل مشاهدهٔ اسلاید ظاهر شوند.

یک روش عملی این است که قبل از کلون، اندازهٔ ارائه منبع را تغییر دهید. متد [SlideSize.set_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/set_size/) می‌تواند محتوای موجود را در حین تغییر ابعاد اسلاید مقیاس بدهد. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesizescaletype/) محتوا را طوری مقیاس می‌دهد که در اندازهٔ درخواست‌شده جا بگیرد.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

تغییر اندازهٔ ارائه منبع را در حافظه تغییر می‌دهد. اگر به ارائهٔ منبع اصلی برای عملیات دیگر نیاز دارید، یک نمونهٔ جداگانه برای ادغام باز کنید.

## **ادغام اسلایدها به یک بخش از ارائه**

حلقهٔ اساسی کلون اسلاید سلسله‌مراتب بخش‌های ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، بخش‌ها را در ارائه مقصد ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) به آن‌ها کلون کنید.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

اسلایدهای کلون‌شده به بخش مقصد مشخص‌شده اضافه می‌شوند. برای حفظ چندین بخش منبع، [Presentation.sections](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/sections/) را پیمایش کنید، اسلایدهای هر بخش را با [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/get_slides_list_of_section/) دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید بازگردانده‌شده را به بخش مقصد مربوطه کلون کنید. برای مثال کامل «مدیریت بخش‌های اسلاید» به آدرس [/slides/fa/python-net/slide-section/] مراجعه کنید که شامل بخش‌های خالی و تغییرات ساختاری است.

## **ادغام ایمن چندین ارائه**

مثال انتها‑به‑انتها در ادامه از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازهٔ اسلاید هر منبع اضافی را نرمال‌سازی می‌کند، هر منبع را تنها در زمان کپی باز می‌دارد و فایل نهایی را یک بار ذخیره می‌کند.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

این یک پایهٔ مفید برای حفظ قالب‌بندی اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم مقصد استفاده کند، فراخوانی سادهٔ `add_clone(slide)` را با overload مناسب مستر یا طرح‌بندی مقصد که قبلاً نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، طرح‌بندی‌ها و دقت قالب‌بندی**

کلون پیش‌فرض اسلاید می‌تواند مستر مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده به‌طور خودکار نگه می‌دارد تا از کلون مکرر همان مستر جلوگیری شود. مسترهای کلون‌شده به‌صورت دستی توسط آن رجیستری ردیابی نمی‌شوند، بنابراین از پیش‌کلون مسترها جلوگیری کنید مگر اینکه نیاز به کنترل صریح ساختار مستر داشته باشید.

فرض نکنید دو مستر یا طرح‌بندی با نام یکسان از نظر بصری یکسان هستند. اگر یک قالب شرکتی باید ظاهر نهایی را کنترل کند، مستر یا طرح‌بندی مقصد را صریحاً انتخاب کنید و پس از ادغام نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های گوینده و نظرات اسلاید با محتوای اسلاید وابسته هستند و هنگام کلون اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](/slides/fa/python-net/presentation-notes/) و [presentation comments](/slides/fa/python-net/presentation-comments/) ارائه می‌دهد.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائهٔ ادغام‌شده را بررسی کنید زیرا مسترهای یادداشت در سطح ارائه قرار دارند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های بازبینی، نویسندگان نظرات و نظرات تودرتو را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیای OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صدا ویدئوی نهفته، داده OLE و لینک‌های خارجی ارجاع دهند. به جای کپی فقط اشکال قابل مشاهده، کلون کامل اسلاید را انجام دهید تا Aspose.Slides بتواند روابط اسلاید با منابع آن را حفظ کند.

منابع نهفته و لینک‌شده باید به‌صورت متفاوتی مدیریت شوند. یک صدا، ویدئو، شیء OLE یا پیوندهای خارجی همچنان به هدف خارجی خود وابسته می‌مانند؛ کلون اسلاید یک لینک خارجی را به محتوا نهفته تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائهٔ ادغام‌شده باز خواهد شد، تست کنید.

Aspose.Slides مسترهای کلون‌شده به‌طور خودکار را ردیابی می‌کند، اما این به معنای تضمین عمومی برای حذف تکرار منابع باینری یکسان از ارائه‌های منبع نامرتبط نیست. اگر اندازهٔ فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی کنید و نتیجه را اندازه‌گیری کنید به جای اطمینان به حذف تکرار ضمنی.

### **فونت‌های نهفته و در دسترس بودن فونت‌ها**

فونت‌ها در سطح ارائه مدیریت می‌شوند. اگر تایپوگرافی باید در بین دستگاه‌ها سازگار بماند، فرض نکنید که فقط کلون اسلایدها تضمین می‌کند هر فونت مورد نیاز در محیط مقصد موجود باشد. می‌توانید فونت‌های نهفته را با [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) بررسی کنید و به‌صورت صریح همان‌طور که در [Embed Fonts in Presentations](/slides/fa/python-net/embedded-font/) توصیف شده، مدیریت کنید.

همچنین تأیید کنید که اجازهٔ نهفته کردن فونت‌های مورد استفاده در فایل‌های منبع را دارید. مجوزهای فونت ممکن است نهفته‌سازی را محدود کنند.

### **ارائه‌های محافظت‌شده با گذرواژه**

یک منبع محافظت‌شده با گذرواژه باید پیش از کلون اسلایدها با موفقیت باز شود. گذرواژه را از طریق [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) فراهم کنید.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

باز کردن یک منبع رمزگذاری‌شده به‌طور خودکار همان حفاظت را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را به‌صورت جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ حاوی تصاویر با وضوح بالا، صدا، ویدئو یا اشیای باینری بزرگ می‌توانند حافظه قابل توجهی مصرف کنند. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/blob_management_options/) کنترل‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ به [Manage Presentation BLOBs](/slides/fa/python-net/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان از مسیرهای فایل برای بارگذاری استفاده کنید، هر منبع را به‌محض ادغام بلافاصله ببندید و از ذخیره مکرر نتایج میانی خودداری کنید مگر اینکه جریان کار به نقطه‌نامه‌ها نیاز داشته باشد. استفاده از `with slides.Presentation(...)` تضمین می‌کند که منابع ارائه هنگام خروج از کانتکست آزاد شوند.

### **ایمنی در چندنخی**

از بارگذاری، ذخیره یا کلون یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) به‌صورت همزمان در چندین نخ خودداری کنید. هر عملیات ادغام را تک‌نخی نگه دارید. اگر کارهای ادغام مستقل را موازی می‌کنید، از پردازش‌های تک‌نخی جداگانه و نمونه‌های ارائه مستقل استفاده کنید همان‌طور که در راهنمای چندنخی Aspose.Slides [/slides/fa/python-net/multithreading/] توضیح داده شده است.

## **سوالات متداول**

**چگونه طرح اولیهٔ هر ارائه منبع را حفظ کنم؟**

از `add_clone` بدون ارائه مستر یا طرح‌بندی مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار کلون کند هنگامی که اسلاید وارد شده به آن نیاز دارد.

**چگونه اسلایدهای وارد شده را به تم مقصد ببرم؟**

از overloadی که مستر مقصد را می‌پذیرد استفاده کنید. یک مستر از ارائه مقصد، نه منبع، پاس دهید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک طرح‌بندی مناسب تحت آن مستر نقشه‌برداری کند.

**چه زمانی باید به‌جای مستر مقصد، یک طرح‌بندی مقصد خاص را استفاده کنم؟**

وقتی هر اسلاید وارد شده باید از یک طرح‌بندی شناخته‌شده استفاده کند، از طرح‌بندی خاص استفاده کنید. وقتی می‌خواهید Aspose.Slides بین طرح‌بندی‌های آن مستر بر اساس نوع یا نام طرح‌بندی منبع انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان ارائه‌های با اندازه اسلایدهای متفاوت را ادغام کرد؟**

بله، اما محتوای اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای موقعیت‌یابی پیش‌بینی‌شده، ابتدا منبع را با [SlideSize.set_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/set_size/) و [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesizescaletype/) تغییر اندازه دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ادغام کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد کلون کنید و مقصد را در قالب خروجی پشتیبانی‌شده ذخیره کنید. چون قالب‌های ارائه دقیقاً مجموعهٔ ویژگی یکسانی ندارند، پس از ادغام‌های فرمت‌متقاطع محتویات پیچیده را بررسی کنید. برای فهرست قالب‌های پشتیبانی‌شده به [Supported File Formats](/slides/fa/python-net/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه، توسط یک حلقهٔ ساده که فقط اسلایدها را کلون می‌کند. بخش‌های مورد نیاز را در مقصد بازسازی کنید و هنگام نیاز به حفظ ساختار بخش‌ها، از overload بخش‌دار `add_clone` استفاده کنید.

**آیا یادداشت‌های گوینده و نظرات حفظ می‌شوند؟**

آنها همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به استایل مستر یادداشت، نویسندگان نظرات یا داده‌های بازبینی تودرتو وابسته است، نتیجهٔ ادغام را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح ارائه نیز می‌شوند.

**چه اتفاقی برای صدا، ویدئو، اشیای OLE و لینک‌های Hyperlink می‌افتد؟**

محتوای نهفته به‌عنوان بخشی از روابط منابع اسلاید کلون‌شده منتقل می‌شود. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف آنها باید پس از ادغام در دسترس باشند.

**آیا فونت‌های نهفته از هر منبع تضمین می‌شود که در ارائهٔ ادغام‌شده موجود باشند؟**

فقط به کلون اسلایدها برای استقرار فونت اطمینان نکنید. فونت‌های نهفتهٔ مقصد را بررسی کنید و نهفته‌سازی فونت یا دسترسی به فونت خارجی را به‌صورت صریح مدیریت کنید وقتی که تایپوگرافی مهم است.

**چگونه یک فایل محافظت‌شده با گذرواژه را ادغام کنم؟**

آن را با گذرواژه صحیح از طریق [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) باز کنید، سپس اسلایدهای آن را به‌صورت عادی کلون کنید. حفاظت خروجی به‌صورت جداگانه تنظیم می‌شود.

**چگونه با ارائه‌های بسیار بزرگ برخورد کنم؟**

از مدیریت BLOB استفاده کنید وقتی که اشیای باینری بزرگ بر مصرف حافظه غلبه می‌کند، برای فایل‌های بسیار بزرگ ترجیحاً با مسیرهای فایل بارگذاری کنید، ارائه‌های منبع را به‌سرعت ببندید و نتیجهٔ نهایی را فقط زمانی ذخیره کنید که لازم باشد.

**آیا می‌توانم اسلایدها را از چندین نخ ادغام کنم؟**

از بارگذاری، ذخیره یا کلون نمونه‌های [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) در چندین نخ همزمان خودداری کنید. هر عملیات ادغام را تک‌نخی نگه دارید؛ برای موازی‌سازی کارهای ادغام جداگانه از پردازش‌های تک‌نخی مستقل استفاده کنید.