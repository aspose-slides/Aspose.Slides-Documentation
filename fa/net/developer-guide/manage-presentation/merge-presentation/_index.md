---
title: ادغام کارآمد ارائه‌ها در .NET
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
description: "نحوه ادغام ارائه‌های PowerPoint و OpenDocument در .NET را با کلون کردن اسلایدها، کنترل مسترها و چینش‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ یاد بگیرید."
---
## **نمای کلی**

Aspose.Slides برای .NET ارائه‌ها را با کلون کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) به دیگری ادغام می‌کند. عملیات اصلی [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا چینش در ارائه مقصد متصل کند.

این مقاله رایج‌ترین جریان‌های کاری ادغام را پوشش می‌دهد:

- کل اسلایدها را با حفظ قالب‌بندی منبع ادغام کنید؛
- اسلایدهای انتخابی را ادغام کنید؛
- یک مستر از ارائه مقصد اعمال کنید؛
- یک چینش خاص از ارائه مقصد اعمال کنید؛
- قبل از ادغام، اندازه‌های مختلف اسلایدها را نرمال کنید؛
- اسلایدهای کلون‌شده را به یک بخش اضافه کنید؛
- چندین ارائه را در یک جریان کاری انتها به انتها ادغام کنید؛
- مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، فونت‌ها، گذرواژه‌ها، فایل‌های بزرگ و نگرانی‌های چندنخی را مدیریت کنید.

## **نحوهٔ تأثیر کلون‌کردن اسلاید بر مسترها و چینش‌ها**

یک اسلاید بسیاری از ظاهر خود را از چینش و مستر خود به ارث می‌برد. به همین دلیل، overload کلون‌کردنی که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) به یکی از روش‌های زیر استفاده کنید:

- `AddClone(sourceSlide)` — قالب‌بندی و چینش اسلاید منبع را نگه می‌دارد. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides مسترهای کلون‌شده به‌صورت خودکار را پیگیری می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را چندین بار کلون نکنند.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اسلاید کلون‌شده را به یک [IMasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) مخصوص در مقصد متصل می‌کند. Aspose.Slides یک چینش مطابقت‌دار زیر آن مستر را بر اساس نوع یا نام چینش جستجو می‌کند.
- `AddClone(sourceSlide, destinationLayout)` — اسلاید کلون‌شده را مستقیماً به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/) مخصوص در مقصد متصل می‌کند.

مستر یا چینشی که به یک overload `AddClone` پاس می‌شود باید متعلق به ارائه **مقصد** باشد، نه ارائه منبع.

## **ادغام کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی تمام اسلایدها از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای واردشده باید تم، مستر و روابط چینش اصلی خود را حفظ کنند.

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

ارائه حاصل ممکن است حاوی چندین مستر باشد زمانی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار زمانی که قالب‌بندی منبع به‌صورت عمدی حفظ می‌شود، قابل انتظار است.

## **ادغام اسلایدهای انتخابی**

نیاز نیست هر اسلایدی را کلون کنید. مثال زیر تنها ایندکس‌های اسلایدهای انتخابی را از ارائه منبع وارد می‌کند.

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

قبل از کلون‌کردن، ایندکس‌های اسلاید را وقتی از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از مستر مقصد**

وقتی اسلایدهای واردشده باید از مستری استفاده کنند که در حال حاضر به ارائه مقصد تعلق دارد، از overload [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) استفاده کنید.

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

Aspose.Slides یک چینش مناسب زیر مستر مشخص شده را بر اساس تطبیق نوع یا نام چینش منبع انتخاب می‌کند. اگر چینش مناسبی وجود نداشته باشد و `allowCloneMissingLayout` برابر `true` باشد، چینش منبع کلون می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception/) پرتاب می‌شود.

اگر می‌خواهید در صورت عدم وجود چینش، ادغام شکست بخورد و یک چینش جدید به مستر مقصد اضافه نشود، مقدار `false` را استفاده کنید.

## **ادغام اسلایدها با استفاده از یک چینش مقصد خاص**

وقتی دقیقاً می‌دانید اسلایدهای واردشده باید از چه چینش مقصدی استفاده کنند، از overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) استفاده کنید.

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

اعمال یک چینش مقصد رابطهٔ چینش ارث‌بری را تغییر می‌دهد؛ محتویات اسلاید منبع را بازطراحی نمی‌کند. اگر چینش‌های منبع و مقصد ساختارهای جای‌دار متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل کنید قالب‌بندی ارث‌بری و رفتار جای‌دار مناسب است.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما کلون‌کردن یک اسلاید به ارائه‌ای با اندازه اسلاید دیگر به‌صورت خودکار محتویات آن را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابجا، مقیاس‌گذاری غیرمنتظره یا خارج از ناحیه قابل مشاهده اسلاید ظاهر شوند.

یک روش عملی این است که قبل از کلون‌کردن، ارائه منبع را تغییر اندازه دهید. متد [SlideSize.SetSize](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesize/setsize/) می‌تواند محتویات موجود را هنگام تغییر ابعاد اسلاید مقیاس‌بندی کند. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesizescaletype/) محتویات را برای قرارگیری در اندازهٔ مورد درخواست مقیاس می‌کند.

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

تغییر اندازه، شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر به ارائه منبع اصلی برای عملیات دیگر نیاز دارید بدون تغییر بماند، یک نمونهٔ جداگانه برای ادغام باز کنید.

## **ادغام اسلایدها در یک بخش از ارائه**

حلقهٔ اساسی کلون‌کردن اسلایدها سلسله‌مراتبی بخش‌های ارائه منبع را بازسازی نمی‌کند. اگر بخش‌ها در خروجی مهم باشند، بخش‌ها را در ارائه مقصد ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) کلون کنید.

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

اسلایدهای کلون‌شده به بخش مقصد مشخص‌شده اضافه می‌شوند. برای حفظ چندین بخش منبع، آن بخش‌ها را در مقصد بازسازی کنید و هر اسلاید منبع را به بخش مقصد متناظرش نگاشت کنید.

## **ادغام ایمن چندین ارائه**

مثال انتها به انتهای زیر، اولین ارائه را به‌عنوان مقصد استفاده می‌کند، اندازه اسلاید هر منبع اضافی را نرمال می‌کند، هر منبع را فقط در هنگام کپی باز نگه می‌دارد و در نهایت یک‌بار فایل نهایی را ذخیره می‌کند.

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

این یک پایهٔ مفید برای حفظ قالب‌بندی منبع اسلایدهای واردشده است. اگر خروجی شما باید یک تم واحد مقصد داشته باشد، فراخوانی سادهٔ `AddClone(slide)` را با overload مناسب مستر یا چینش مقصد که پیشتر نشان داده شد، جایگزین کنید.

## **موارد عملی**

### **مسترها، چینش‌ها و صحت قالب‌بندی**

کلون‌کردن پیش‌فرض اسلاید می‌تواند مستر لازم از منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده به‌صورت خودکار نگه می‌دارد تا از کلون مکرر یک مستر جلوگیری کند. مسترهای کلون‌شده به‌صورت دستی توسط آن رجیستری پیگیری نمی‌شوند، بنابراین از پیش‌کلون کردن مسترها خودداری کنید مگر اینکه به کنترل صریح بر ساختار مستر نیاز داشته باشید.

فرض نکنید دو مستر یا چینش با نام یکسان بصورت بصری یکسان هستند. اگر یک الگوی سازمانی باید ظاهر نهایی را کنترل کند، مستر یا چینش مقصد را به‌صورت صریح انتخاب کنید و پس از ادغام نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلاید با محتوای اسلاید مرتبط هستند و هنگام کلون‌کردن اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](https://docs.aspose.com/slides/fa/net/presentation-notes/) و [presentation comments](https://docs.aspose.com/slides/fa/net/presentation-comments/) ارائه می‌دهد.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائه ادغام‌شده را بررسی کنید زیرا مسترهای یادداشت‌ها اشیا در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های کاری بازبینی، همچنین نویسندگان نظرات و نظرات زنجیره‌ای را پس از ترکیب فایل‌ها از نویسندگان یا الگوهای مختلف بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیای OLE و پیوندهای خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صوت جاسازی‌شده، ویدئوی جاسازی‌شده و داده‌های OLE ارجاع دهند. به‌جای کپی کردن فقط شکل‌های قابل مشاهده، کل اسلاید را کلون کنید تا Aspose.Slides بتواند روابط اسلاید با منابع آن را نگه دارد.

منابع جاسازی‌شده و پیوند شده باید به‌صورت متفاوتی رفتار شوند. یک صوت، ویدئو، شیء OLE یا پیوند خارجی همچنان به هدف خارجی خود وابسته است؛ کلون‌کردن اسلاید یک پیوند خارجی را به محتویات جاسازی‌شده تبدیل نمی‌کند. مسیرها و URLهای منابع پیوندی را در محیطی که ارائه ادغام‌شده باز خواهد شد، آزمایش کنید.

Aspose.Slides به‌طور صریح مسترهای کلون‌شده به‌صورت خودکار را ردیابی می‌کند، اما این نباید به‌عنوان تضمین کلی برای حذف تکرر منابع باینری یکسان از ارائه‌های منبع نامرتبط تلقی شود. اگر حجم فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی کنید و نتیجه را اندازه‌گیری کنید به‌جای اتکا به حذف تکرر ضمنی.

### **فونت‌های جاسازی‌شده و در دسترس بودن فونت‌ها**

فونت‌ها در سطح ارائه مدیریت می‌شوند. اگر تایپوگرافی باید در تمام دستگاه‌ها ثابت بماند، فرض نکنید کلون‌کردن اسلایدها به‌تنهایی تضمین می‌کند هر فونت مورد نیاز در محیط مقصد در دسترس است. می‌توانید فونت‌های جاسازی‌شده را با [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getembeddedfonts/) بررسی کنید و به‌صورت صریح همان‌طور که در [Embed Fonts in Presentations](https://docs.aspose.com/slides/fa/net/embedded-font/) توصیف شده، جا‌گذاری را مدیریت کنید.

همچنین اطمینان حاصل کنید که اجازه جاسازی فونت‌های استفاده‌شده در فایل‌های منبع را دارید. مجوزهای فونت می‌توانند جاسازی را محدود کنند.

### **ارائه‌های دارای رمز عبور**

یک منبع دارای رمز عبور باید قبل از کلون‌کردن اسلایدهای آن با موفقیت باز شود. رمز عبور را از طریق [LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) ارائه دهید.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

باز کردن منبع رمزنگاری‌شده به‌صورت خودکار حفاظت مشابه را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را به‌صورت جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و استفاده از حافظه**

ارائه‌های بزرگ حاوی تصاویر با وضوح بالا، صدا، ویدئو یا سایر اشیای باینری بزرگ می‌توانند حافظه قابل‌توجهی مصرف کنند. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/blobmanagementoptions/) ابزارهایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ به [Manage Presentation BLOBs](https://docs.aspose.com/slides/fa/net/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان ترجیحاً از مسیرهای فایل بارگذاری کنید، هر ارائه منبع را به‌محض ادغام شدن آزاد کنید و از ذخیرهٔ مکرر نتایج میانی خودداری کنید مگر اینکه جریان کاری به نقطه‌بازگشت‌ها نیاز داشته باشد.

### **ایمنی در پردازش چندنخی**

از بارگذاری، اصلاح، ذخیره یا کلون‌کردن همزمان یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) از چندین نخ خودداری کنید. هر نمونهٔ ارائه را به یک عملیات ادغام محدود کنید. اگر کارهای مستقل را به‌صورت موازی انجام می‌دهید، از نمونه‌های مستقل ارائه استفاده کنید و راهنمایی‌های چندنخی Aspose.Slides را مطابق با [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/fa/net/multithreading/) دنبال کنید.

## **سوالات متداول**

**چگونه طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) بدون ارائه مستر یا چینش مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار کلون کند وقتی اسلاید واردشده به آن نیاز دارد.

**چگونه اسلایدهای واردشده از تم مقصد استفاده کنند؟**

از overloadی که مستر مقصد را می‌پذیرد استفاده کنید. مستری از ارائه مقصد (نه منبع) پاس کنید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک چینش مناسب زیر آن مستر انتساب دهد.

**چه زمانی باید به‌جای مستر مقصد از یک چینش مقصد مشخص استفاده کنم؟**

وقتی هر اسلاید واردشده باید از یک چینش شناخته‌شده استفاده کند، از یک چینش خاص استفاده کنید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام چینش منبع، بین چینش‌های مستر انتخاب کند، از مستر استفاده کنید.

**آیا می‌توانم ارائه‌هایی با اندازه‌های اسلاید متفاوت را ادغام کنم؟**

بله، اما محتویات اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شوند. زمانی که به مکان‌یابی پیش‌بینی‌شده نیاز دارید، ابتدا ارائه منبع را تغییر اندازه دهید، برای مثال با [SlideSize.SetSize](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesize/setsize/) و [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesizescaletype/).

**آیا می‌توانم ارائه‌های PPT، PPTX و ODP را در یک فایل ادغام کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد کلون کنید و مقصد را در یک قالب خروجی پشتیبانی‌شده ذخیره کنید. از آنجا که فرمت‌های ارائه دقیقاً همان مجموعه ویژگی‌ها را پشتیبانی نمی‌کنند، پس از ادغام بین‌فرمتی محتویات پیچیده را بررسی کنید. به [Supported File Formats](https://docs.aspose.com/slides/fa/net/supported-file-formats/) نگاه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه، با یک حلقهٔ ساده که فقط اسلایدها را کلون می‌کند، بخش‌های منبع حفظ نمی‌شوند. بخش‌های مورد نیاز را در مقصد بازسازی کنید و هنگام نیاز به حفظ ساختار بخش، از overload بخشِ [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) استفاده کنید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

آنها همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به سبک مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های بازبینی زنجیره‌ای وابسته‌اند، نتیجهٔ ادغام را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح ارائه و همچنین محتویات سطح اسلاید هستند.

**چه اتفاقی برای صدا، ویدئو، اشیای OLE و پیوندهای ابرمتنی می‌افتد؟**

محتویات جاسازی‌شده به‌عنوان بخشی از روابط منابع اسلاید کلون‌شده منتقل می‌شود. پیوندهای خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف آنها باید پس از ادغام در دسترس باشند.

**آیا فونت‌های جاسازی‌شده از هر منبع تضمین می‌شود که در ارائه ادغام‌شده در دسترس باشند؟**

به‌تنهای کلون‌کردن اسلایدها برای توزیع فونت تکیه نکنید. فونت‌های جاسازی‌شدهٔ مقصد را بررسی کنید و هنگام اهمیت تایپوگرافی، جاسازی فونت یا در دسترس بودن فونت‌های خارجی را به‌صورت صریح مدیریت کنید.

**چگونه یک فایل دارای رمز عبور را ادغام کنم؟**

آن را با [LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) صحیح باز کنید، سپس اسلایدهای آن را به‌صورت معمولی کلون کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید ارائه‌های بسیار بزرگ را مدیریت کنم؟**

وقتی اشیای باینری بزرگ مصرف حافظه را dominate می‌کنند از مدیریت BLOB استفاده کنید، برای فایل‌های بسیار بزرگ ترجیحاً از بارگذاری مسیرهای فایل استفاده کنید، ارائه‌های منبع را به‌سرعت آزاد کنید و فقط در زمان لازم نتیجهٔ نهایی را ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین نخ ادغام کنم؟**

از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) به‌صورت همزمان در چندین نخ استفاده نکنید. هر عملیات ادغام را به‌صورت جداگانه در نمونه‌های اختصاصی خود ارائه نگه دارید.