---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 14.4.0
linktitle: Aspose.Slides برای .NET 14.4.0
type: docs
weight: 60
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را مرور کنید تا به‌صورت روانی‌تری راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
## **API عمومی و تغییرات ناسازگار با نسخه‌های قبلی**
### **رابط‌ها، کلاس‌ها، متدها و ویژگی‌های اضافه شده**
#### **ویژگی Aspose.Slides.ILayoutSlide.HasDependingSlides اضافه شده است**
ویژگی Aspose.Slides.ILayoutSlide.HasDependingSlides زمانی که حداقل یک اسلاید به این اسلاید طرح وابسته باشد، مقدار true برمی‌گرداند. برای مثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **متد Aspose.Slides.ILayoutSlide.Remove()**
متد Aspose.Slides.ILayoutSlide.Remove() به شما امکان می‌دهد با حداقل کد، یک طرح را از ارائه حذف کنید. برای مثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **متد Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
متد Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) به شما امکان می‌دهد یک طرح را از مجموعه حذف کنید. مثال‌های کد:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

یا

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **متد Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
متد Aspose.Slides.ILayoutSlideCollection.RemoveUnused() به شما امکان می‌دهد اسلایدهای طرح استفاده نشده (اسلایدهایی که HasDependingSlides آن‌ها false است) را حذف کنید. مثال‌های کد:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

یا

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **ویژگی Aspose.Slides.IMasterSlide.HasDependingSlides**
ویژگی Aspose.Slides.IMasterSlide.HasDependingSlides زمانی که حداقل یک اسلاید به این اسلاید اصلی وابسته باشد، مقدار true برمی‌گرداند. برای مثال:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **متد Aspose.Slides.ISlide.Remove()**
متد Aspose.Slides.ISlide.Remove() به شما امکان می‌دهد با حداقل کد، یک اسلاید را از ارائه حذف کنید. برای مثال:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
ویژگی Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat در صورتی که طرح گلوله‌ها را فراهم کند، IFillFormat مربوط به گلوله یک گره SmartArt را برمی‌گرداند. می‌تواند برای تنظیم تصویر گلوله استفاده شود.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **ویژگی Aspose.Slides.SmartArt.ISmartArtNode.Level**
ویژگی Aspose.Slides.SmartArt.ISmartArtNode.Level سطح تو در تو را برای گره‌های SmartArt برمی‌گرداند.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **ویژگی Aspose.Slides.SmartArt.ISmartArtNode.Position**
ویژگی Aspose.Slides.SmartArt.ISmartArtNode.Position موقعیت یک گره را نسبت به خواهران و برادرانش برمی‌گرداند.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **متد Aspose.Slides.SmartArt.ISmartArtNode.Remove() اضافه شده است**
متد Aspose.Slides.SmartArt.ISmartArtNode.Remove() امکان حذف یک گره از یک نمودار را فراهم می‌کند.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **رابط IGlobalLayoutSlideCollection و کلاس GlobalLayoutSlideCollection**
رابط IGlobalLayoutSlideCollection و کلاس GlobalLayoutSlideCollection به فضای نام Aspose.Slides اضافه شده‌اند.

کلاس GlobalLayoutSlideCollection رابط IGlobalLayoutSlideCollection را پیاده‌سازی می‌کند.

رابط IGlobalLayoutSlideCollection مجموعه‌ای از تمام اسلایدهای طرح در یک ارائه را نشان می‌دهد. ویژگی IPresentation.LayoutSlides از نوع IGlobalLayoutSlideCollection است. IGlobalLayoutSlideCollection رابط ILayoutSlideCollection را با متدهایی برای افزودن و شبیه‌سازی اسلایدهای طرح در زمینهٔ ادغام مجموعه‌های جداگانهٔ اسلایدهای طرح استاد (master) گسترش می‌دهد:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – می‌تواند برای افزودن یک کپی از یک اسلاید طرح مشخص به ارائه استفاده شود. این متد قالب‌بندی منبع را حفظ می‌کند (هنگام شبیه‌سازی یک طرح بین ارائه‌های مختلف، می‌توان استاد (master) طرح را نیز شبیه‌سازی کرد. رجیستری داخلی برای ردیابی خودکار استاد‌های شبیه‌سازی‌شده استفاده می‌شود تا از ایجاد چندین کپی از همان اسلاید استاد جلوگیری شود).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – برای افزودن یک کپی از یک اسلاید طرح مشخص به ارائه استفاده می‌شود. طرح جدید به استاد تعریف‌شده در ارائه مقصد لینک می‌شود. این گزینه معادل کپی یا چسباندن با گزینه **Use Destination Theme** در Microsoft PowerPoint است.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – برای افزودن یک اسلاید طرح جدید به ارائه استفاده می‌شود. انواع طرح‌های پشتیبانی‌شده: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. نام طرح می‌تواند به‌صورت خودکار تولید شود. یک طرح اضافه‌شده از نوع SlideLayoutType.Custom هیچ جای‌نگهدار و هیچ شکلی ندارد. معادل این متد، متد IMasterLayoutSlideCollection.Add(SlideLayoutType, string) است که از طریق ویژگی IMasterSlide.LayoutSlides قابل دسترسی است.
#### **رابط IMasterLayoutSlideCollection و کلاس MasterLayoutSlideCollection**
رابط IMasterLayoutSlideCollection و کلاس MasterLayoutSlideCollection به فضای نام Aspose.Slides اضافه شده‌اند. کلاس MasterLayoutSlideCollection رابط IMasterLayoutSlideCollection را پیاده‌سازی می‌کند.

رابط IMasterLayoutSlideCollection مجموعه‌ای از تمام اسلایدهای طرح یک استاد تعریف‌شده را نشان می‌دهد. این رابط رابط ILayoutSlideCollection را با متدهایی برای افزودن، درج، حذف یا شبیه‌سازی اسلایدهای طرح در زمینهٔ مجموعه‌های جداگانهٔ اسلایدهای طرح استاد گسترش می‌دهد:

``` csharp

 // امضای متد:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// مثال کد که یک کپی از sourceLayout را به destMasterSlide پیوست می‌کند:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

متد می‌تواند برای افزودن یک کپی از یک اسلاید طرح مشخص به انتهای مجموعه استفاده شود. طرح جدید به استاد والد این مجموعه اسلایدهای طرح لینک می‌شود. بنابراین این معادل کپی یا چسباندن با گزینه **Use Destination Theme** در PowerPoint است. معادل این متد، متد IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) است که از طریق ویژگی IPresentation.LayoutSlides قابل دسترسی است.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – برای درج یک کپی از یک اسلاید طرح مشخص در موقعیت مشخصی از مجموعه استفاده می‌شود. طرح جدید به استاد والد این مجموعه اسلایدهای طرح لینک می‌شود. بنابراین این معادل کپی یا چسباندن با گزینه **Use Destination Theme** در PowerPoint است.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – برای افزودن یا درج یک اسلاید طرح جدید استفاده می‌شود. انواع طرح‌های پشتیبانی‌شده: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. نام طرح می‌تواند به‌صورت خودکار تولید شود. یک طرح اضافه‌شده از نوع SlideLayoutType.Custom هیچ جای‌نگهدار و هیچ شکلی ندارد. معادل این متد، متد IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) است که از طریق ویژگی IPresentation.LayoutSlides قابل دسترسی است.
- void RemoveAt(int index); – برای حذف طرح در شاخص مشخص شده از مجموعه استفاده می‌شود.
- void Reorder(int index, ILayoutSlide layoutSlide); – برای جابه‌جایی اسلاید طرح از مجموعه به موقعیت مشخص شده استفاده می‌شود.
### **متدها و ویژگی‌های تغییر یافته**
#### **امضای متد Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
امضای متد ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
در حال حاضر منقضی شده و با امضای زیر جایگزین شده است:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
پارامتر allowCloneMissingLayout مشخص می‌کند وقتی در destMaster برای اسلاید جدید (شبیه‌سازی‌شده) طرح مناسب وجود نداشته باشد، چه کاری انجام شود. طرح مناسب همان طرحی است که نوع یا نامش با طرح اسلاید منبع یکسان باشد. اگر در استاد مشخص شده طرح مناسبی وجود نداشته باشد، طرح اسلاید منبع شبیه‌سازی می‌شود (اگر allowCloneMissingLayout برابر true باشد) یا استثناء PptxEditException پرتاب می‌شود (اگر برابر false باشد).

فراخوانی متد منقضی‌شده به شکل
AddClone(sourceSlide, destMaster);
به‌صورت پیش‌فرض allowCloneMissingLayout را برابر false در نظر می‌گیرد (یعنی در صورت نبودن طرح مناسب استثناء PptxEditException پرتاب می‌شود). فراخوانی عملکردی یکسان که از امضای جدید استفاده می‌کند به شکل زیر است:
AddClone(sourceSlide, destMaster, false);

اگر می‌خواهید طرح‌های گمشده به‌صورت خودکار شبیه‌سازی شوند به‌جای پرتاب استثناء PptxEditException، مقدار پارامتر allowCloneMissingLayout را برابر true بدهید.

هم‌چنین برای متد ISlideCollection:
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);
هم اکنون منقضی شده و با امضای زیر جایگزین شده است:
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **نوع ویژگی Aspose.Slides.IMasterSlide.LayoutSlides**
نوع ویژگی Aspose.Slides.IMasterSlide.LayoutSlides از ILayoutSlideCollection به رابط جدید IMasterLayoutSlideCollection تغییر کرده است. رابط IMasterLayoutSlideCollection یک زیرمجموعهٔ ILayoutSlideCollection است، بنابراین کدهای موجود نیازی به تغییر ندارند.
#### **نوع ویژگی Aspose.Slides.IPresentation.LayoutSlides تغییر کرده است**
نوع ویژگی Aspose.Slides.IPresentation.LayoutSlides از ILayoutSlideCollection به رابط جدید IGlobalLayoutSlideCollection تغییر کرده است. رابط IGlobalLayoutSlideCollection یک زیرمجموعهٔ ILayoutSlideCollection است، بنابراین کدهای موجود نیازی به تغییر ندارند.