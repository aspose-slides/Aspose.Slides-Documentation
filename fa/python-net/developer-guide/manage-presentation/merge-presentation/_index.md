---
title: ادغام کارآمد ارائه‌ها با پایتون
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/python-net/merge-presentation/
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
- Aspose.Slides
description: "یاد بگیرید چگونه در پایتون ارائه‌های PowerPoint و OpenDocument را با کلون کردن اسلایدها، کنترل مسترها و لِی‌آوت‌ها، تغییر اندازه محتوی اسلایدها، حفظ بخش‌ها، و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via .NET ارائه‌ها را با کلون کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) به دیگری ادغام می‌کند. عملیات اصلی [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا لِی‌آوت در ارائه مقصد متصل کند.

این مقاله رایج‌ترین جریان‌های کاری ادغام را پوشش می‌دهد:

- ادغام تمام اسلایدها در حالی که قالب‌بندی منبع آن‌ها حفظ می‌شود؛  
- ادغام اسلایدهای انتخاب‌شده؛  
- اعمال مستر از ارائه مقصد؛  
- اعمال لِی‌آوت خاصی از ارائه مقصد؛  
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ادغام؛  
- افزودن اسلایدهای کلون‌شده به یک بخش؛  
- ادغام چندین ارائه در یک جریان کاری سراسری؛  
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، فونت‌ها، کلمات عبور، فایل‌های بزرگ و نگرانی‌های چندنخی.

## **چگونگی تأثیر کلون‌کردن اسلاید بر مسترها و لِی‌آوت‌ها**

یک اسلاید بخش زیادی از ظاهر خود را از لِی‌آوت و مستر خود به ارث می‌برد. به همین دلیل، overload کلون‌کردنی که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد ادغام شود.

از [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) به یکی از این روش‌ها استفاده کنید:

- `add_clone(source_slide)` — حفظ لِی‌آوت و قالب‌بندی اسلاید منبع. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides مسترهای کلون‌شده خودکار را دنبال می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را به‌طور مکرر کلون نکنند.  
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — متصل کردن اسلاید کلون‌شده به یک [IMasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterslide/) خاص در مقصد. Aspose.Slides برای یافتن لِی‌آوت مطابقت‌دار زیر آن مستر بر اساس نوع یا نام لِی‌آوت جستجو می‌کند.  
- `add_clone(source_slide, destination_layout)` — متصل کردن اسلاید کلون‌شده مستقیم به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ilayoutslide/) خاص در مقصد.

مستر یا لِی‌آوتی که به overload `add_clone` پاس داده می‌شود باید متعلق به ارائه **مقصد** باشد، نه ارائه منبع.

## **ادغام کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام تمام اسلایدها را از ارائه منبع به ارائه مقصد کپی می‌کند. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید تم، مستر و روابط لِی‌آوت اصلی خود را حفظ کنند.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

ارائه حاصل ممکن است چندین مستر داشته باشد زمانی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این وضعیت زمانی پیش می‌آید که قالب‌بندی منبع به‌صورت عمدی حفظ شده باشد.

## **ادغام اسلایدهای انتخاب‌شده**

لازم نیست همه اسلایدها را کلون کنید. مثال زیر تنها ایندکس‌های اسلاید انتخاب‌شده را از ارائه منبع وارد می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

قبل از کلون کردن ایندکس‌های اسلاید را زمانی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از مستر مقصد**

از overload [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) وقتی استفاده کنید که اسلایدهای وارد شده باید تحت مستری باشند که پیش‌اکنون به ارائه مقصد تعلق دارد.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides یک لِی‌آوت مناسب زیر مستر مشخص شده را بر اساس نوع یا نام لِی‌آوت منبع انتخاب می‌کند. اگر لِی‌آوت مناسبی موجود نباشد و `allow_clone_missing_layout` برابر `True` باشد، لِی‌آوت منبع کلون می‌شود تا اسلاید اضافه شود. اگر `False` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) پرتاب می‌شود.

از `False` استفاده کنید وقتی می‌خواهید ادغام به‌جای افزودن لِی‌آوت اضافی به مستر مقصد، شکست بخورد.

## **ادغام اسلایدها با استفاده از لِی‌آوت مقصد خاص**

از overload [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) وقتی استفاده کنید که دقیقاً می‌دانید هر اسلاید وارد شده باید از کدام لِی‌آوت مقصد استفاده کند.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

اعمال لِی‌آوت مقصد روابط لِی‌آوت به‌ارث‌برده را تغییر می‌دهد؛ محتوی اسلاید منبع را بازطراحی نمی‌کند. اگر لِی‌آوت‌های منبع و مقصد ساختار جای‌گیرهای متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل شود قالب‌بندی و رفتار جای‌گیرها مناسب است.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

ارائه‌هایی با ابعاد اسلاید مختلف می‌توانند ادغام شوند، اما کلون کردن اسلاید به ارائه‌ای با اندازه اسلاید دیگر به‌صورت خودکار محتوی آن را برای بوم جدید بازطراحی نمی‌کند. در نتیجه اشکال ممکن است جابه‌جا، مقیاس‌دار یا خارج از ناحیه قابل مشاهده اسلاید ظاهر شوند.

یک روش عملی این است که پیش از کلون کردن، اندازه ارائه منبع را تغییر دهید. متد [SlideSize.set_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/set_size/) می‌تواند محتوی موجود را در حین تغییر ابعاد اسلاید مقیاس‌بندی کند. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesizescaletype/) محتوی را طوری مقیاس‌بندی می‌کند که داخل اندازه درخواستی جا بگیرد.

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

تغییر اندازه شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر نیاز دارید ارائه منبع اصلی برای عملیات دیگر دست‌نخورده بماند، یک نمونه جداگانه برای ادغام باز کنید.

## **ادغام اسلایدها به یک بخش در ارائه**

حلقه پایه کلون‌کردن اسلایدها ساختار بخش‌های ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، در ارائه مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را صریحاً با [SlideCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) به آن‌ها کلون کنید.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

اسلایدهای کلون‌شده به بخش مقصد مشخص‌شده افزوده می‌شوند. برای حفظ چندین بخش منبع، آن بخش‌ها را در مقصد با [SectionCollection.append_empty_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/append_empty_section/) بازسازی کنید و هر اسلاید منبع را به بخش مقصد متناظر نگاشت کنید.

## **ادغام چندین ارائه به‌صورت امن**

مثال انتها‑به‑انتها در ادامه از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازه اسلاید هر منبع افزودنی را نرمال‌سازی می‌کند، هر منبع را فقط در زمان کپی باز می‌گذارد و در انتها فایل نهایی را یکبار ذخیره می‌کند.

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

این یک پایه مفید برای حفظ قالب‌بندی اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم مقصد واحد استفاده کند، فراخوانی ساده `add_clone(slide)` را با overload مناسب مستر یا لِی‌آوت مقصد که پیشتر نشان داده شد جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، لِی‌آوت‌ها و صحت قالب‌بندی**

کلون‌کردن پیش‌فرض اسلاید می‌تواند مستر لازم منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستر داخلی برای مسترهای کلون‌شده خودکار نگه می‌دارد تا از کلون مکرر همان مستر جلوگیری شود. مسترهای کلون‌شده به‌صورت دستی توسط آن رجیستر ردیابی نمی‌شوند، بنابراین از پیش‌کلون کردن مسترها صرف‌نظر کنید مگر اینکه نیاز به کنترل صریح ساختار مستر داشته باشید.

فرض نکنید دو مستر یا لِی‌آوت با نام یکسان از نظر بصری برابرند. اگر یک قالب سازمانی باید ظاهر نهایی را کنترل کند، مستر یا لِی‌آوت مقصد را به‌صورت صریح انتخاب کنید و پس از ادغام نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های گوینده و نظرات اسلاید با محتوی اسلاید مرتبط هستند و هنگام کلون یک اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](https://docs.aspose.com/slides/fa/python-net/presentation-notes/) و [presentation comments](https://docs.aspose.com/slides/fa/python-net/presentation-comments/) ارائه می‌دهد.

اگر قالب‌بندی صفحه یادداشت‌ها مهم است، ارائه ادغام‌شده را بررسی کنید زیرا مسترهای یادداشت در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های بازبینی، نویسندگان نظرات و نظرات زنجیروار را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز تأیید کنید.

### **تصاویر، صدا، ویدیو، اشیای OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای جاسازی‌شده، ویدیوهای جاسازی‌شده و داده‌های OLE ارجاع دهند. به‌جای کپی فقط اشکال قابل‌مشاهده، کلون کل اسلاید را انجام دهید تا Aspose.Slides بتواند روابط اسلاید با منابعش را حفظ کند.

منابع جاسازی‌شده و لینک‌شده باید به‌صورت متفاوتی رفتار شوند. یک صوت، ویدیو، شیء OLE یا پیوند خارجی همچنان به هدف خارجی خود وابسته می‌ماند؛ کلون یک اسلاید لینک خارجی را به محتوی جاسازی‌شده تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ادغام‌شده باز خواهد شد، آزمون کنید.

Aspose.Slides مسترهای کلون‌شده خودکار را صریحاً ردیابی می‌کند، اما این نباید به‌عنوان گارانتی کلی برای حذف تکرار منابع باینری یکسان از ارائه‌های منبع نامرتبط محسوب شود. اگر اندازه فایل خروجی مهم است، بسته ادغام‌شده را بررسی کنید و نتیجه را اندازه‌گیری کنید به‌جای اتکا به حذف تکرار ضمنی.

### **فونت‌های جاسازی شده و در دسترس بودن فونت**

فونت‌ها در سطح ارائه مدیریت می‌شوند. اگر تایپوگرافی باید در میان ماشین‌ها یکسان بماند، فرض نکنید کلون اسلایدها به‌تنهایی تضمین می‌کند همه فونت‌های موردنیاز در محیط مقصد موجود باشند. می‌توانید فونت‌های جاسازی‌شده را با [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) بررسی کنید و همان‌طور که در [Embed Fonts in Presentations](https://docs.aspose.com/slides/fa/python-net/embedded-font/) توضیح داده شده است، جاسازی را صریحاً مدیریت کنید.

همچنین تأیید کنید که مجاز به جاسازی فونت‌های استفاده‌شده در فایل‌های منبع هستید؛ مجوزهای فونت می‌توانند جاسازی را محدود کنند.

### **ارائه‌های دارای رمز عبور**

یک منبع دارای رمز عبور باید پیش از کلون اسلایدهایش با موفقیت باز شود. رمز عبور را از طریق [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) فراهم کنید.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

باز کردن منبع رمزنگاری‌شده به‌صورت خودکار همان حفاظت را به ارائه مقصد اعمال نمی‌کند. حفاظت خروجی را به‌صورت جداگانه در صورت نیاز پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ حاوی تصاویر با رزولوشن بالا، صدا، ویدیو یا دیگر اشیای باینری بزرگ می‌توانند حافظه قابل‌توجهی مصرف کنند. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/blob_management_options/) کنترل‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ به [Manage Presentation BLOBs](https://docs.aspose.com/slides/fa/python-net/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان بارگذاری از مسیرهای فایل را ترجیح دهید، هر ارائه منبع را به‌محض ادغام بلافاصله ببندید و از ذخیره مکرر نتایج میانی خودداری کنید مگر اینکه گردش کار به نقطه‌های بررسی نیاز داشته باشد. استفاده از `with slides.Presentation(...)` تضمین می‌کند که منابع ارائه هنگام خروج از کانتکس آزاد شوند.

### **ایمنی در پردازش همزمان**

از بارگذاری، ذخیره یا کلون یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) به‌صورت همزمان در چندین نخ خودداری کنید. هر عملیات ادغام را تک‌نخی نگه دارید. اگر شغل‌های ادغام مستقل را هم‌زمان می‌کنید، فرآیندهای تک‌نخی جداگانه و نمونه‌های ارائه مستقل را همان‌طور که در راهنمای چندنخی Aspose.Slides توضیح داده شده است، استفاده کنید.

## **پرسش‌های متداول**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از [`add_clone(source_slide)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) بدون ارائه مستر یا لِی‌آوت مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار کلون کند هنگامی که اسلاید وارد شده به آن نیاز داشته باشد.

**چگونه می‌توانم اسلایدهای وارد شده را به تم مقصد بسط دهم؟**

overload ای را که مستر مقصد می‌پذیرد، استفاده کنید. مستری از ارائه مقصد، نه منبع، پاس بدهید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک لِی‌آوت مناسب زیر آن مستر نگاشت کند.

**چه زمانی باید به جای مستر مقصد از لِی‌آوت مقصد خاص استفاده کنم؟**

وقتی هر اسلاید وارد شده باید از یک لِی‌آوت شناخته‌شده استفاده کند، یک لِی‌آوت خاص را به کار ببرید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام لِی‌آوت منبع، میان لِی‌آوت‌های مستر انتخاب کند، مستر را استفاده کنید.

**آیا می‌توان ارائه‌های با اندازه‌های اسلاید متفاوت را ادغام کرد؟**

بله، اما محتوی اسلاید برای ابعاد مقصد به‌صورت خودکار بازطراحی نمی‌شود. برای داشتن جای‌گذاری پیش‌بینی‌شده، ابتدا ارائه منبع را با [SlideSize.set_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/set_size/) و [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesizescaletype/) تغییر اندازه دهید.

**آیا می‌توانم ارائه‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای موردنیاز را به یک مقصد کلون کنید و مقصد را در قالب خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه تمام ویژگی‌های یکسان را ندارند، پس از ترکیب‌های چند فرمت محتوی پیچیده را بررسی کنید. به [Supported File Formats](https://docs.aspose.com/slides/fa/python-net/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه، حلقه پایه‌ای که فقط اسلایدها را کلون می‌کند بخش‌های منبع را حفظ نمی‌کند. بخش‌های موردنیاز را در مقصد بازسازی کنید و overload بخش‌دار [add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) را وقتی ساختار بخش باید حفظ شود، به کار ببرید.

**آیا یادداشت‌های گوینده و نظرات حفظ می‌شوند؟**

آن‌ها همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به استایل مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های بازبینی زنجیروار وابسته هستند، نتیجه ادغام را بررسی کنید زیرا این سناریوها ساختارهای سطح ارائه و نه فقط محتوی سطح اسلاید را در بر می‌گیرند.

**چه اتفاقی برای صدا، ویدیو، اشیای OLE و لینک‌های فراگیر می‌افتد؟**

محتوی جاسازی‌شده به‌عنوان بخشی از روابط منبع اسلاید کلون‌شده منتقل می‌شود. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف آنها باید پس از ادغام در دسترس باشند.

**آیا فونت‌های جاسازی‌شده از هر منبع تضمین می‌شود در ارائه ترکیبی در دسترس باشند؟**

به‌تنهایی کلون اسلاید برای استقرار فونت‌ها کافی نیست. فونت‌های جاسازی‌شده مقصد را بررسی کنید و هنگام اهمیت تایپوگرافی، جاسازی فونت یا دسترس‌پذیری فونت خارجی را صریحاً مدیریت کنید.

**چگونه یک فایل دارای رمز عبور را ادغام کنم؟**

آن را با [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) صحیح باز کنید، سپس اسلایدهایش را به‌صورت معمول کلون کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

زمانی که اشیای باینری بزرگ غالب هستند، از مدیریت BLOB استفاده کنید، در صورت امکان بارگذاری از مسیرهای فایل را ترجیح دهید، هر ارائه منبع را به‌محض ادغام ببندید و فقط در زمان نیاز نتیجه نهایی را ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین نخ ادغام کنم؟**

از بارگذاری، ذخیره یا کلون یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) در چندین نخ هم‌زمان خودداری کنید. هر عملیات ادغام را تک‌نخی نگه دارید؛ برای هم‌زمان‌سازی مشاغل ادغام مستقل، پردازش‌های تک‌نخی جداگانه و نمونه‌های ارائه مستقل را همان‌طور که در راهنمای چندنخی Aspose.Slides توضیح داده شده، به کار ببرید.