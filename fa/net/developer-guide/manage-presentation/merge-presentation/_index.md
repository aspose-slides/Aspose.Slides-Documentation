---
title: به‌صورت کارآمد ارائه‌ها را در .NET ادغام کنید
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه با کلون کردن اسلایدها، کنترل مسترها و لِی‌آوت‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ، ارائه‌های PowerPoint و OpenDocument را در .NET ادغام کنید."
---
## **مروری کلی**

Aspose.Slides برای .NET ارائه‌ها را با کپی‌کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) به دیگری ادغام می‌کند. عملیات اصلی، [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کرده یا اسلاید کپی‌شده را به یک مستر یا لِی‌آوت در ارائه مقصد وصل کند.

این مقاله رایج‌ترین جریان‌های ادغام را پوشش می‌دهد:

- ادغام تمام اسلایدها با حفظ قالب‌بندی منبع؛
- ادغام اسلایدهای منتخب؛
- اعمال یک مستر از ارائه مقصد؛
- اعمال یک لِی‌آوت خاص از ارائه مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ادغام؛
- افزودن اسلایدهای کپی‌شده به یک بخش؛
- ادغام چندین ارائه در یک جریان کار انتها‑به‑انتها؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، رمزهای عبور، فایل‌های بزرگ و ملاحظات چندنخی.

## **چگونه کلون کردن اسلاید بر مسترها و لِی‌آوت‌ها تأثیر می‌گذارد**

یک اسلاید بخش زیادی از ظاهر خود را از لِی‌آوت و مستر خود به ارث می‌برد. به همین دلیل، overload‌ای که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) به یکی از روش‌های زیر استفاده کنید:

- `AddClone(sourceSlide)` — قالب‌بندی و لِی‌آوت اسلاید منبع را حفظ می‌کند. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides به‌طور خودکار مسترهای کلون‌شده را ردیابی می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را بارها کلون نکنند.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اسلاید کلون‌شده را به یک [IMasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) خاص در مقصد وصل می‌کند. Aspose.Slides با جستجوی لِی‌آوت مطابق با نوع یا نام زیر مستر، لِی‌آوت مناسب را پیدا می‌کند.
- `AddClone(sourceSlide, destinationLayout)` — اسلاید کلون‌شده را مستقیماً به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/) خاص در مقصد متصل می‌کند.

مستر یا لِی‌آوتی که به overload `AddClone` پاس می‌دهید باید متعلق به **ارائه مقصد** باشد، نه ارائه منبع.

## **ادغام کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی تمام اسلایدها از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید قالب، مستر و روابط لِی‌آوت اولیه خود را حفظ کنند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

نتیجه ممکن است شامل چندین مستر باشد وقتی که ارائه‌های منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این موضوع در صورت حفظ آگاهانه قالب‌بندی منبع طبیعی است.

## **ادغام اسلایدهای منتخب**

نیاز نیست همه اسلایدها را کلون کنید. مثال زیر فقط ایندکس‌های اسلاید منتخب را از ارائه منبع وارد می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

قبل از کلون کردن، ایندکس‌های اسلاید را زمانی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از مستر مقصد**

زمانی که اسلایدهای وارد شده باید از یک مستر استفاده کنند که قبلاً به ارائه مقصد تعلق دارد، overload `[AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/)` را به کار برید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides بر اساس نوع یا نام لِی‌آوت منبع، لِی‌آوت مناسبی را زیر مستر مشخص‌شده انتخاب می‌کند. اگر لِی‌آوت مناسب وجود نداشته باشد و `allowCloneMissingLayout` برابر `true` باشد، لِی‌آوت منبع کلون می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception/) رخ می‌دهد.

زمانی که می‌خواهید ادغام به‌جای افزودن لِی‌آوت جدید به مستر مقصد، ناموفق باشد، مقدار `false` را استفاده کنید.

## **ادغام اسلایدها با استفاده از یک لِی‌آوت مقصد خاص**

زمانی که دقیقاً می‌دانید هر اسلاید وارد شده باید از کدام لِی‌آوت مقصد استفاده کند، overload `[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/)` را به کار ببرید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

اعمال یک لِی‌آوت مقصد رابطه لِی‌آوت ارث‌برده‌شده را تغییر می‌دهد؛ محتوای اسلاید منبع را بازطراحی نمی‌کند. اگر لِی‌آوت‌های منبع و مقصد ساختارهای placeholder متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل شود قالب‌بندی و رفتار placeholder مناسب است.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

می‌توان ارائه‌هایی با ابعاد اسلاید متفاوت را ادغام کرد، اما کلون کردن اسلاید به ارائه‌ای با اندازه دیگر به‌صورت خودکار محتوا را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابجا، مقیاس‌گذاری نادرست یا خارج از ناحیه قابل مشاهده ظاهر شوند.

یک روش عملی این است که پیش از کلون کردن، اندازه ارائه منبع را تغییر دهید. متد `[SlideSize.SetSize](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesize/setsize/)` می‌تواند محتوا را در حین تغییر ابعاد اسلاید مقیاس‌بندی کند. `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesizescaletype/)` محتوای اسلاید را برای اندازهٔ درخواستی مطابقت می‌دهد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

تغییر اندازه، شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر نیاز دارید ارائه منبع اصلی برای عملیات دیگر دست‌نخورده باقی بماند، برای ادغام یک نمونه جداگانه باز کنید.

## **ادغام اسلایدها به یک بخش ارائه**

حلقهٔ پایهٔ کلون اسلاید بخش‌بندی سلسله‌مراتبی ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، قبل از کلون کردن اسلایدها، بخش‌ها را در ارائه مقصد ایجاد یا انتخاب کنید و با `[AddClone(ISlide, ISection)](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/)` صراحتاً در آن‌ها کلون کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

اسلایدهای کلون‌شده به بخش مقصد مشخص‌شده اضافه می‌شوند. برای حفظ چندین بخش منبع، `[Presentation.Sections](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sections/)` را پیمایش کنید، اسلایدهای هر بخش را با `[ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/getslideslistofsection/)` دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید بازگردانده‌شده را به بخش مقصد متناظر کلون کنید. برای مثال کامل دربارهٔ پیمایش بخش‌ها، به [Manage Slide Sections](/slides/fa/net/slide-section/) مراجعه کنید که شامل بخش‌های خالی و تغییرات ساختاری است.

## **ادغام ایمن چندین ارائه**

مثال انتها‑به‑انتها زیر، اولین ارائه را به عنوان مقصد استفاده می‌کند، اندازهٔ اسلاید هر منبع اضافی را نرمال‌سازی می‌کند، هر منبع را فقط در زمان کپی باز نگه می‌دارد و در پایان فایل نهایی را ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

این یک پایهٔ مفید برای حفظ قالب‌بندی اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم واحد استفاده کند، فراخوانی سادهٔ `AddClone(slide)` را با overload مناسب مستر یا لِی‌آوت مقصد که پیشتر نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، لِی‌آوت‌ها و صحت قالب‌بندی**

کلون پیش‌فرض اسلاید می‌تواند به‌صورت خودکار یک مستر منبع مورد نیاز را به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده خودکار دارد تا از کلون مکرر یک مستر جلوگیری کند. مسترهای کلون‌شده به‌صورت دستی در آن رجیستری ثبت نمی‌شوند، بنابراین از پیش‌کلون کردن مسترها خودداری کنید مگر اینکه کنترل صریحی بر ساختار مستر نیاز داشته باشید.

به این باور نرسید که دو مستر یا لِی‌آوت با نام یکسان از نظر بصری یکسان هستند. اگر یک الگوی سازمانی باید ظاهر نهایی را کنترل کند، مستر یا لِی‌آوت مقصد را به‌صورت صریح انتخاب کنید و پس از ادغام نتیجه را تأیید کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلاید به محتوای اسلاید مرتبط هستند و هنگام کلون اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](/slides/fa/net/presentation-notes/) و [presentation comments](/slides/fa/net/presentation-comments/) ارائه می‌دهد.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائه ادغام‌شده را بررسی کنید زیرا مسترهای یادداشت در سطح ارائه قرار دارند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های بازبینی، نویسندگان نظرات و نظرات سلسله‌مراتبی را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیای OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای جاسازی‌شده، ویدئوهای جاسازی‌شده و داده‌های OLE ارجاع دهند. به‌جای کپی فقط اشکال قابل مشاهده، کل اسلاید را کلون کنید تا Aspose.Slides روابط اسلاید با منابعش را حفظ کند.

منابع جاسازی‌شده و لینک‌شده باید به‌طور متفاوتی رفتار شوند. یک صدا، ویدئو، شیء OLE یا هایپرلینک لینک‌شده وابسته به هدف خارجی خود می‌ماند؛ کلون اسلاید باعث تبدیل لینک خارجی به محتوا جاسازی‌شده نمی‌شود. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ادغام‌شده باز می‌شود، تست کنید.

Aspose.Slides مسترهای کلون‌شده خودکار را ردیابی می‌کند، اما این به‌عنوان تضمین کلی برای حذف تکراری منابع باینری یکسان از ارائه‌های نامرتبط تلقی نشود. اگر حجم فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی و نتایج را اندازه‌گیری کنید به‌جای اتکا به حذف تکرار ضمنی.

### **قلم‌های جاسازی‌شده و در دسترس بودن قلم**

قلم‌ها در سطح ارائه مدیریت می‌شوند. اگر نگارش باید در بین ماشین‌ها ثابت بماند، فرض نکنید که فقط کلون اسلایدها تضمین می‌کند تمام قلم‌های مورد نیاز در محیط مقصد موجود هستند. می‌توانید قلم‌های جاسازی‌شده را با `[FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getembeddedfonts/)` بررسی کنید و همان‌طور که در [Embed Fonts in Presentations](/slides/fa/net/embedded-font/) توضیح داده شده است، جاسازی را صریحاً مدیریت کنید.

همچنین اطمینان حاصل کنید که اجازهٔ جاسازی قلم‌های استفاده‌شده در فایل‌های منبع را دارید. مجوزهای قلم می‌توانند محدودیت‌های جاسازی داشته باشند.

### **ارائه‌های دارای رمز عبور**

یک منبع محافظت‌شده با رمز عبور باید پیش از کلون اسلایدها با موفقیت باز شود. رمز عبور را از طریق `[LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/)` تامین کنید.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

باز کردن یک منبع رمزگذاری‌شده به‌صورت خودکار حفاظت مشابهی را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ شامل تصاویر با وضوح بالا، صدا، ویدئو یا اشیای باینری بزرگ می‌توانند مصرف حافظه قابل‌توجهی داشته باشند. `[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/blobmanagementoptions/)` کنترل‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌آورد. برای استراتژی‌های فایل بزرگ به [Manage Presentation BLOBs](/slides/fa/net/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، تا حد امکان از مسیرهای فایل برای بارگذاری استفاده کنید، هر ارائه منبع را به محض اتمام ادغام آزاد کنید و از ذخیره مکرر نتایج میانی خودداری کنید مگر اینکه جریان کار به نقطهٔ بررسی نیاز داشته باشد.

### **ایمنی در برابر چندنخی**

نگهداری، تغییر، ذخیره یا کلون کردن یک نمونهٔ `[Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/)` را به‌صورت همزمان از چندین نخ انجام ندهید. هر نمونهٔ ارائه را به یک عملیات ادغام محدود کنید. اگر کارهای مستقل را به صورت موازی اجرا می‌کنید، از نمونه‌های جداگانهٔ ارائه استفاده کنید و راهنمایی‌های چندنخی Aspose.Slides را که در [/slides/fa/net/multithreading/] موجود است، دنبال نمایید.

## **سؤالات متداول**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از `AddClone` بدون ارائهٔ مستر یا لِی‌آوت مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌طور خودکار کلون کند وقتی اسلاید وارد شده به آن نیاز دارد.

**چگونه می‌توانم اسلایدهای وارد شده را به تم مقصد ببرم؟**

 overloadی را به کار ببرید که مستر مقصد را می‌پذیرد. یک مستر از ارائه مقصد، نه منبع، پاس دهید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به لِی‌آوت مناسب زیر آن مستر نگاشت کند.

**کِی باید به‌جای مستر مقصد از لِی‌آوت مقصد خاص استفاده کنم؟**

 وقتی هر اسلاید وارد شده باید از یک لِی‌آوت شناخته‌شده استفاده کند، لِی‌آوت خاص را انتخاب کنید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام لِی‌آوت منبع، بین لِی‌آوت‌های مستر انتخاب کند، مستر را استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازه‌های اسلاید متفاوت را ادغام کرد؟**

 بله، اما محتویات اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شوند. برای جای‌گذاری پیش‌بینی‌شده، ابتدا منبع را با `[SlideSize.SetSize](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesize/setsize/)` و `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesizescaletype/)` تغییر اندازه دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ادغام کنم؟**

 بله. هر ارائهٔ منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد کلون کنید و مقصد را در فرمت خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه دقیقا مجموعهٔ ویژگی‌های یکسانی ندارند، پس از ادغام فرمت‌های مختلف محتویات پیچیده را بررسی کنید. برای اطلاعات بیشتر به [Supported File Formats](/slides/fa/net/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

 نه، توسط یک حلقهٔ ساده که فقط اسلایدها را کلون می‌کند. برای حفظ بخش‌ها، آن‌ها را در مقصد بازسازی کنید و از overload بخش‌دار `[AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/)` استفاده کنید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

 آن‌ها همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به استایل مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های بازبینی سلسله‌مراتبی وابسته هستند، نتیجهٔ ادغام را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح ارائه نیز می‌شوند.

**محتویات صوتی، تصویری، اشیای OLE و هایپرلینک‌ها چه می‌شوند؟**

 محتویات جاسازی‌شده به‌عنوان بخشی از روابط منبع‑منابع اسلاید کلون‌شده منتقل می‌شوند. لینک‌های خارجی به‌صورت خارجی باقی می‌مانند، بنابراین فایل‌ها یا URLهای هدف پس از ادغام باید همچنان در دسترس باشند.

**آیا قلم‌های جاسازی‌شده از هر منبع در ارائهٔ ادغام‌شده قابل‌دسترس خواهند بود؟**

 تنها به کلون اسلاید برای استقرار قلم‌ها تکیه نکنید. قلم‌های جاسازی‌شدهٔ مقصد را بررسی کنید و برای حفظ یکپارچگی تایپوگرافی، جاسازی یا در دسترس بودن قلم‌های خارجی را به‌صورت صریح مدیریت کنید.

**چگونه می‌توانم یک فایل محافظت‌شده با رمز عبور را ادغام کنم؟**

 آن را با `[LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/)` صحیح باز کنید، سپس اسلایدهایش را به‌صورت عادی کلون کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

 از مدیریت BLOB استفاده کنید وقتی که اشیای باینری بزرگ حافظه را به‌خوبی مصرف می‌کنند، برای فایل‌های بسیار بزرگ به‌جای بارگذاری به‌صورت حافظه‌درون‌خطی مسیرهای فایل را ترجیح دهید، منابع ارائه منبع را به محض اتمام ادغام آزاد کنید و فقط در زمان نیاز نتیجهٔ نهایی را ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین نخ همزمان ادغام کنم؟**

 از یک نمونهٔ `[Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/)` به‌صورت همزمان در چندین نخ استفاده نکنید. هر عملیات ادغام را به نمونه‌های جداگانهٔ ارائه محدود کنید.