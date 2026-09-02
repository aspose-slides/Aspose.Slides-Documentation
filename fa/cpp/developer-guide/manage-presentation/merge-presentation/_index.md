---
title: به صورت مؤثر ترکیب ارائه‌ها در C++
linktitle: ترکیب ارائه‌ها
type: docs
weight: 40
url: /fa/cpp/merge-presentation/
keywords:
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه در C++ ارائه‌های PowerPoint و OpenDocument را با تکثیر اسلایدها، کنترل مسترها و طرح‌بندی‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ترکیب کنید."
---
## **نمای کلی**

Aspose.Slides for C++ با تکثیر اسلایدها از یک [ارائه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) به دیگری، ارائه‌ها را ترکیب می‌کند. عملیات اصلی، [ISlideCollection::AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید تکثیر شده را به یک مستر یا طرح‌بندی در ارائه مقصد پیوست کند.

این مقاله رایج‌ترین جریان‌های ترکیب را پوشش می‌دهد:

- ترکیب تمام اسلایدها با حفظ قالب‌بندی منبع؛
- ترکیب اسلایدهای انتخابی؛
- اعمال یک مستر از ارائه مقصد؛
- اعمال یک طرح‌بندی خاص از ارائه مقصد؛
- نرمال‌سازی اندازه‌های اسلاید مختلف قبل از ترکیب؛
- افزودن اسلایدهای تکثیر شده به یک بخش؛
- ترکیب چندین ارائه در یک جریان انتها‑به‑انتها؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، گذرواژه‌ها، فایل‌های بزرگ و ملاحظات چندرشته‌ای.

## **چگونگی تأثیر تکثیر اسلاید بر مسترها و طرح‌بندی‌ها**

یک اسلاید ظاهر زیادی از طرح‌بندی و مستر خود به ارث می‌برد. به همین دلیل، بارگذاری (overload) تکثیری که انتخاب می‌کنید تعیین می‌کند اسلاید ترکیبی چطور در ارائه مقصد ادغام می‌شود.

از [ISlideCollection::AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) به یکی از این روش‌ها استفاده کنید:

- `AddClone(sourceSlide)` — قالب‌بندی و طرح‌بندی اسلاید منبع را حفظ می‌کند. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد تکثیر شود. Aspose.Slides مسترهای تکثیر شده به‌صورت خودکار را پیگیری می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را بارها تکثیر نکنند.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اسلاید تکثیر شده را به یک [IMasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/) خاص در مقصد پیوست می‌کند. Aspose.Slides به‌دنبال یک طرح‌بندی مطابق زیر مستر بر اساس نوع یا نام طرح‌بندی می‌گردد.
- `AddClone(sourceSlide, destinationLayout)` — اسلاید تکثیر شده را مستقیماً به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/) خاص در مقصد پیوست می‌کند.

مستر یا طرح‌بندی که به یک overload از `AddClone` پاس داده می‌شود باید متعلق به ارائه **مقصد** باشد، نه ارائه منبع.

## **ادغام کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین ترکیب، تمام اسلایدها را از ارائه منبع به ارائه مقصد کپی می‌کند. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید تم، مستر و روابط طرح‌بندی اصلی خود را حفظ کنند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

نتیجه ممکن است شامل چندین مستر باشد وقتی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار طبیعی است وقتی قالب‌بندی منبع عمداً حفظ می‌شود.

## **ادغام اسلایدهای انتخابی**

لازم نیست هر اسلایدی را تکثیر کنید. مثال زیر فقط ایندکس‌های اسلاید انتخابی را از ارائه منبع وارد می‌کند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

قبل از تکثیر، ایندکس‌های اسلاید را هنگامی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از مستر مقصد**

از overload [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) زمانی استفاده کنید که اسلایدهای وارد شده باید تحت یک مستر که قبلاً به ارائه مقصد تعلق دارد، قرار گیرند.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides یک طرح‌بندی مناسب زیر مستر مشخص شده را با تطبیق نوع یا نام طرح‌بندی منبع انتخاب می‌کند. اگر طرح‌بندی مناسبی وجود نداشته باشد و `allowCloneMissingLayout` برابر `true` باشد، طرح‌بندی منبع تکثیر می‌شود تا اسلاید اضافه شود. اگر برابر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/details_pptxeditexception/) پرتاب می‌شود.

از `false` استفاده کنید هنگامی که می‌خواهید ترکیب به‌جای افزودن یک طرح‌بندی جدید به مستر مقصد، با شکست مواجه شود.

## **ادغام اسلایدها با استفاده از طرح‌بندی خاص مقصد**

از overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) زمانی استفاده کنید که دقیقاً می‌دانید کدام طرح‌بندی مقصد باید توسط اسلایدهای وارد شده استفاده شود.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

اعمال یک طرح‌بندی مقصد روابط وراثتی طرح‌بندی را تغییر می‌دهد؛ محتوای اسلاید منبع را بازطراحی نمی‌کند. اگر طرح‌بندی‌های منبع و مقصد دارای ساختارهای جایگیر (placeholder) متفاوتی باشند، نتیجه را بررسی کنید تا مطمئن شوید قالب‌بندی و رفتار جایگیرها مناسب است.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ترکیب شوند، اما تکثیر اسلاید به ارائه‌ای با اندازه اسلاید دیگر به‌صورت خودکار محتوا را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابه‌جا، مقیاس‌دار یا خارج از ناحیه قابل مشاهده ظاهر شوند.

یک روش عملی این است که پیش از تکثیر، اندازه ارائه منبع را تغییر دهید. متد [SlideSize::SetSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidesize/setsize/) می‌تواند محتوا را در حین تغییر ابعاد اسلاید مقیاس‌بندی کند. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidesizescaletype/) محتوا را برای تناسب با اندازهٔ درخواست‌شده مقیاس می‌کند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

تغییر اندازه شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر به نسخهٔ اصلی ارائه منبع برای عملیات دیگر نیاز دارید، یک نمونهٔ جداگانه برای ترکیب باز کنید.

## **ادغام اسلایدها در بخش ارائه**

حلقهٔ پایهٔ تکثیر اسلاید سلسله‌مراتبی بخش‌های ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، بخش‌ها را در ارائه مقصد ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) به آن‌ها تکثیر کنید.

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

اسلایدهای تکثیر شده به بخش مقصد مشخص شده افزوده می‌شوند. برای حفظ چندین بخش منبع، [Presentation::get_Sections](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_sections/) را فهرست کنید، اسلایدهای فعلی هر بخش منبع را با [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/getslideslistofsection/) دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید بازگردانده شده را به بخش مقصد مربوطه تکثیر کنید. برای مثال کامل فهرست‌بندی بخش‌ها، شامل بخش‌های خالی و تغییرات ساختاری، به [Manage Slide Sections](/slides/fa/cpp/slide-section/) مراجعه کنید.

## **ادغام ایمن چندین ارائه**

مثال انتها‑به‑انتها زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازه اسلاید هر منبع اضافه را نرمال‌سازی می‌کند، هر منبع را فقط در زمانی که در حال کپی شدن است باز می‌دارد و در نهایت فایل نهایی را یک‌بار ذخیره می‌کند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

این یک پایهٔ مفید برای حفظ قالب‌بندی منبع اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم واحد مقصد استفاده کند، فراخوانی سادهٔ `AddClone(slide)` را با overload مناسب مستر یا طرح‌بندی مقصد که قبلاً نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، طرح‌بندی‌ها و صحت قالب‌بندی**

تکثیر پیش‌فرض اسلاید می‌تواند مستر مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای تکثیر شده به‌صورت خودکار نگه می‌دارد تا از تکثیر مکرر همان مستر جلوگیری شود. مسترهای تکثیر شده به‌صورت دستی توسط آن رجیستری پیگیری نمی‌شوند، بنابراین از پیش‑تکثیر مسترها اجتناب کنید مگر این‌که به‌نظارت صریح بر ساختار مستر نیاز داشته باشید.

فرض نکنید دو مستر یا طرح‌بندی با نام یکسان به‌صورت بصری برابر هستند. اگر یک الگوی شرکتی باید ظاهر نهایی را کنترل کند، مستر یا طرح‌بندی مقصد را به‌صورت صریح انتخاب کنید و پس از ترکیب نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلایدها به محتوای اسلاید مرتبط هستند و هنگام تکثیر اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [یادداشت‌های ارائه](/slides/fa/cpp/presentation-notes/) و [نظرات ارائه](/slides/fa/cpp/presentation-comments/) فراهم می‌کند.

اگر قالب‌بندی صفحه یادداشت مهم است، ارائه ترکیبی را بررسی کنید زیرا مسترهای یادداشت اشیای سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های بازبینی، نویسندگان نظرات و نظرات سلسله‌دار را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیاء OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای توکار، ویدئوهای توکار و داده‌های OLE ارجاع دهند. به‌جای کپی کردن فقط اشکال قابل مشاهده، کل اسلاید را تکثیر کنید تا Aspose.Slides بتواند روابط اسلاید با منابع را حفظ کند.

منابع توکار و لینک‌شده باید به‌طور متفاوتی مدیریت شوند. یک صدا، ویدئو، شیء OLE یا پیوندی که لینک شده باشد، به هدف خارجی خود وابسته می‌ماند؛ تکثیر اسلاید یک لینک خارجی را به محتوای توکار تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ترکیبی باز خواهد شد، تست کنید.

Aspose.Slides به‌صورت صریح مسترهای تکثیر شده به‌صورت خودکار را پیگیری می‌کند، اما این به معنای تضمین کلی برای حذف تکثیر منابع باینری مشابه از ارائه‌های منبع نامرتبط نیست. اگر حجم فایل خروجی مهم است، بسته ترکیبی را بررسی کنید و نتیجه را اندازه‌گیری کنید به‌جای اتکا به حذف تکثیر ضمنی.

### **قلم‌های توکار و دسترس‌پذیری قلم‌ها**

قلم‌ها در سطح ارائه مدیریت می‌شوند. اگر کتاب‌تنی بر روی ماشین‌ها باید ثابت بماند، فرض نکنید تکثیر اسلایدها به‌تنهایی تضمین می‌کند که هر قلم مورد نیاز در محیط مقصد در دسترس باشد. می‌توانید قلم‌های توکار را با [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getembeddedfonts/) بررسی کنید و توکارسازی را همان‌طور که در [توکارسازی قلم‌ها در ارائه‌ها](/slides/fa/cpp/embedded-font/) توضیح داده شده، صریحاً مدیریت کنید.

هم‌چنین اطمینان حاصل کنید که مجاز به توکارسازی قلم‌های استفاده‌شده در فایل‌های منبع هستید؛ مجوزهای قلم می‌توانند توکارسازی را محدود کنند.

### **ارائه‌های دارای گذرواژه**

یک منبع محافظت‌شده با گذرواژه باید پیش از تکثیر اسلایدها به‌درستی باز شود. گذرواژه را از طریق [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) ارائه دهید.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

باز کردن یک منبع رمزنگاری‌شده به‌طور خودکار محافظت همانند را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، محافظت خروجی را جداگانه تنظیم کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ حاوی تصاویر با وضوح بالا، صدا، ویدئو یا اشیای باینری بزرگ می‌توانند مقدار قابل توجهی حافظه مصرف کنند. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) کنترل‌های مدیریت BLOB و استفاده از فایل‌های موقت را فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ به [Manage Presentation BLOBs](/slides/fa/cpp/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان بارگذاری از مسیرهای فایل را ترجیح دهید، هر ارائه منبع را به‌محض پایان ترکیب آزاد کنید و از ذخیره مکرر نتایج میانی خودداری کنید مگر اینکه گردش کار checkpoint‑ها را می‌طلبد.

### **ایمنی در چندرشته‌ای**

یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را همزمان از چندین رشته بارگذاری، تغییر، ذخیره یا تکثیر نکنید. هر نمونهٔ ارائه را به یک عملیات ترکیب محدود کنید. اگر کارها را به صورت مستقل موازی می‌کنید، از نمونه‌های مستقل ارائه استفاده کنید و راهنمایی‌های [Aspose.Slides multithreading](/slides/fa/cpp/multithreading/) را دنبال کنید.

## **سوالات متداول**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) بدون ارائه مستر یا طرح‌بندی مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار وقتی اسلاید وارد شده به آن نیاز دارد، تکثیر کند.

**چگونه می‌توانم اسلایدهای وارد شده را از تم مقصد استفاده کنم؟**

overload‌ای را که مستر مقصد را می‌پذیرد، استفاده کنید. مستری از ارائه مقصد ارائه دهید، نه از منبع. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک طرح‌بندی مناسب زیر آن مستر نگاشت کند.

**چه زمانی باید به‌جای مستر مقصد، یک طرح‌بندی خاص مقصد را استفاده کنم؟**

وقتی می‌دانید هر اسلاید وارد شده باید از یک طرح‌بندی مشخص استفاده کند، از یک طرح‌بندی خاص استفاده کنید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام طرح‌بندی منبع، بین طرح‌بندی‌های مستر انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازه‌های اسلاید متفاوت را ترکیب کرد؟**

بله، اما محتوای اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای موقعیت‌یابی پیش‌بینی‌شده، پیش از ترکیب منبع را با [SlideSize::SetSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidesize/setsize/) و [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidesizescaletype/) تغییر اندازه دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای مورد نیاز را در یک مقصد تکثیر کنید و مقصد را در یک قالب خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه دقیقاً همان مجموعه ویژگی را پشتیبانی نمی‌کنند، پس از ترکیب‌های چندفرمتی محتوای پیچیده را بررسی کنید. برای جزئیات به [Supported File Formats](/slides/fa/cpp/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

خیر؛ حلقهٔ پایه‌ای که فقط اسلایدها را تکثیر می‌کند، سلسله‌مراتب بخش‌های منبع را بازتولید نمی‌کند. برای حفظ بخش‌ها، آن‌ها را در مقصد بازسازی کنید و از overload بخش‑دار [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) استفاده کنید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

آن‌ها با اسلاید تکثیر شده کپی می‌شوند. برای گردش کارهایی که به استایل مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های بازبینی سلسله‌دار وابسته‌اند، نتیجه ترکیبی را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح ارائه نیز هستند.

**چه اتفاقی برای صدا، ویدئو، اشیاء OLE و پیوندها می‌افتد؟**

محتوای توکار به‌عنوان بخشی از روابط منابع اسلاید تکثیر شده منتقل می‌شود. لینک‌های خارجی همچنان خارجی باقی می‌مانند، بنابراین فایل‌ها یا URLهای هدف باید پس از ترکیب در دسترس باشند.

**آیا قلم‌های توکار از هر منبع تضمین می‌شود که در ارائه ترکیبی در دسترس باشند؟**

فقط به تکثیر اسلاید برای استقرار قلم‌ها اتکا نکنید. قلم‌های توکار مقصد را بررسی کنید و توکارسازی یا دسترس‌پذیری قلم‌های خارجی را صریحاً مدیریت کنید وقتی که نگارشی مهم است.

**چگونه می‌توانم یک فایل محافظت‌شده با گذرواژه را ترکیب کنم؟**

آن را با [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) صحیح باز کنید، سپس اسلایدهای آن را به‌صورت معمول تکثیر کنید. محافظت خروجی به‌صورت جداگانه تنظیم می‌شود.

**چگونه باید ارائه‌های بسیار بزرگ را مدیریت کنم؟**

از مدیریت BLOB استفاده کنید وقتی که اشیای باینری بزرگ حافظه را اشغال می‌کنند، بارگذاری مسیرهای فایل را برای فایل‌های بسیار بزرگ ترجیح دهید، ارائه‌های منبع را به‌محض اتمام ترکیب آزاد کنید و نتیجه نهایی را تنها زمانی که نیاز به ذخیره است، ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین رشته ترکیب کنم؟**

از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) به‌صورت همزمان در چندین رشته بارگذاری، تغییر یا تکثیر نکنید. هر عملیات ترکیب را به نمونه‌های جداگانهٔ ارائه محدود کنید.