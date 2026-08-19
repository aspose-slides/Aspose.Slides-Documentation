---
title: ادغام کارآمد ارائه‌ها در C++
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/cpp/merge-presentation/
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
- C++
- Aspose.Slides
description: "بیاموزید چگونه در C++ با کلون‌کردن اسلایدها، کنترل مسترها و لایه‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ، ارائه‌های PowerPoint و OpenDocument را ادغام کنید."
---
## **مرور کلی**

Aspose.Slides for C++ ارائه‌ها را با کلون‌کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) به دیگری ادغام می‌کند. عملیات اصلی [ISlideCollection::AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا لایه در ارائه مقصد متصل کند.

این مقاله رایج‌ترین جریان‌های ادغام را پوشش می‌دهد:

- تمام اسلایدها را با حفظ قالب‌بندی منبعشان ادغام کنید؛
- ادغام اسلایدهای انتخاب‌شده؛
- اعمال یک مستر از ارائه مقصد؛
- اعمال یک لایه خاص از ارائه مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ادغام؛
- افزودن اسلایدهای کلون‌شده به یک بخش؛
- ادغام چندین ارائه در یک جریان کار انتها به انتها؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، فونت‌ها، رمزهای عبور، فایل‌های بزرگ و مسائل مربوط به چندنخی.

## **چگونگی تأثیر کلون‌کردن اسلاید بر مسترها و لایه‌ها**

یک اسلاید ظاهر زیادی از لایه و مستر خود به ارث می‌برد. به همین دلیل، نسخهٔ Overloadی که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [ISlideCollection::AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) به یکی از روش‌های زیر استفاده کنید:

- `AddClone(sourceSlide)` — قالب‌بندی و لایه اسلاید منبع را حفظ می‌کند. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides مسترهای کلون‌شده به‌صورت خودکار را پیگیری می‌کند تا اسلایدهای مکرری که از همان مستر منبع استفاده می‌کنند، مستر را چندین بار کلون نکنند.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اسلاید کلون‌شده را به یک [IMasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/) خاص در مقصد متصل می‌کند. Aspose.Slides برای آن مستر، لایهٔ مطابقتی را بر اساس نوع یا نام لایهٔ منبع جستجو می‌کند.
- `AddClone(sourceSlide, destinationLayout)` — اسلاید کلون‌شده را مستقیماً به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/) خاص در مقصد متصل می‌کند.

مستر یا لایه‌ای که به یک overload از `AddClone` پاس می‌دهید باید متعلق به **ارائه مقصد** باشد، نه ارائه منبع.

## **ادغام کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی تمام اسلایدها از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای وارد‌شده باید تم، مستر و روابط لایهٔ اصلی خود را حفظ کنند.

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

ارائه حاصل ممکن است چندین مستر داشته باشد زمانی که ارائه منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار هنگام حفظ عمداً قالب‌بندی منبع طبیعی است.

## **ادغام اسلایدهای انتخاب‌شده**

لازم نیست هر اسلاید را کلون کنید. مثال زیر فقط ایندکس‌های اسلاید انتخاب‌شده از ارائه منبع را وارد می‌کند.

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

قبل از کلون کردن ایندکس‌های اسلاید را هنگامی که از ورودی کاربر یا پیکربندی خارجی دریافت می‌شوند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از مستر مقصد**

وقتی اسلایدهای وارد‌شده باید از یک مستری که قبلاً به ارائه مقصد تعلق دارد استفاده کنند، overload [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) را به کار بگیرید.

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

Aspose.Slides لایهٔ مناسب زیر مستر مشخص‌شده را بر اساس نوع یا نام لایهٔ منبع انتخاب می‌کند. اگر لایهٔ مناسب موجود نباشد و `allowCloneMissingLayout` برابر `true` باشد، لایهٔ منبع کلون می‌شود تا اسلاید اضافه شود. اگر برابر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/details_pptxeditexception/) پرتاب می‌شود.

از `false` استفاده کنید وقتی می‌خواهید ادغام به‌جای افزودن لایهٔ اضافی به مستر مقصد، شکست بخورد.

## **ادغام اسلایدها با استفاده از یک لایهٔ مشخص در مقصد**

وقتی دقیقاً می‌دانید هر اسلاید وارد‌شده باید از کدام لایهٔ مقصد استفاده کند، overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) را بکار ببرید.

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

اعمال لایهٔ مقصد رابطهٔ لایهٔ ارث‌برده را تغییر می‌دهد؛ محتوای اسلاید منبع را بازطراحی نمی‌کند. اگر لایه‌های منبع و مقصد ساختارهای نگه‌دارندهٔ متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل شود قالب‌بندی و رفتار نگه‌دارندهٔ ارث‌برده مناسب است.

## **ادغام ارائه‌ها با اندازه‌های متفاوت اسلاید**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما کلون یک اسلاید به ارائه‌ای با اندازهٔ اسلاید دیگر به‌صورت خودکار محتوا را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است به‌صورت جابجا، مقیاس‌گذاری نامناسب یا خارج از ناحیهٔ قابل مشاهده ظاهر شوند.

یک روش عملی این است که پیش از کلون کردن، اندازهٔ ارائه منبع را تغییر دهید. متد [SlideSize::SetSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidesize/setsize/) می‌تواند محتوا را در حین تغییر ابعاد اسلاید مقیاس‌بندی کند. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidesizescaletype/) محتوا را برای متناسب شدن با اندازهٔ درخواستی مقیاس می‌کند.

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

تغییر اندازه، شیء ارائهٔ منبع را در حافظه تغییر می‌دهد. اگر به ارائهٔ منبع اصلی برای عملیات دیگر نیاز دارید، نمونهٔ جداگانه‌ای برای ادغام باز کنید.

## **ادغام اسلایدها در یک بخش ارائه**

حلقهٔ پایهٔ کلون اسلایدها ساختار بخش‌های ارائهٔ منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی اهمیت دارند، در ارائه مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را به‌طور صریح با [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) در آن‌ها کلون کنید.

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

اسلایدهای کلون‌شده به بخش مقصد مشخص‌شده اضافه می‌شوند. برای حفظ چندین بخش منبع، آن بخش‌ها را در مقصد دوباره ایجاد کنید و هر اسلاید منبع را به بخش مقصد متناظر نگاشت کنید.

## **ادغام چندین ارائه به‌صورت ایمن**

مثال انتها‑به‑انتها زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازهٔ اسلاید هر منبع اضافی را نرمال‌سازی می‌کند، هر منبع را فقط در زمانی که در حال کپی است باز نگه می‌دارد و در پایان یک بار فایل نهایی را ذخیره می‌کند.

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

این یک پایهٔ مفید برای حفظ قالب‌بندی منبع اسلایدهای وارد‌شده است. اگر خروجی شما باید از یک تم واحد استفاده کند، فراخوانی سادهٔ `AddClone(slide)` را با overload مناسب مستر یا لایهٔ مقصد که پیش‌تر نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، لایه‌ها و دقت قالب‌بندی**

کلون‌کردن پیش‌فرض اسلاید می‌تواند مستر لازم از منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده به‌صورت خودکار نگهداری می‌کند تا از کلون مکرر همان مستر جلوگیری شود. مسترهای کلون‌شده به‌صورت دستی در آن رجیستری پیگیری نمی‌شوند، بنابراین از پیش‌کلون کردن مسترها اجتناب کنید مگر اینکه کنترل صریحی بر ساختار مستر نیاز داشته باشید.

فرض نکنید دو مستر یا لایه با نام یکسان بصری برابر هستند. اگر یک الگوی شرکتی باید ظاهر نهایی را کنترل کند، مستر یا لایهٔ مقصد را صریحاً انتخاب کنید و پس از ادغام نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های گوینده و نظرات اسلاید به محتوی اسلاید مرتبط هستند و هنگام کلون اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](https://docs.aspose.com/slides/fa/cpp/presentation-notes/) و [presentation comments](https://docs.aspose.com/slides/fa/cpp/presentation-comments/) فراهم می‌کند.

اگر قالب‌بندی صفحهٔ یادداشت مهم است، ارائهٔ ادغام‌شده را بررسی کنید زیرا مسترهای یادداشت در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های بازبینی، نویسندگان نظرات و نظرات زنجیره‌ای را پس از ترکیب فایل‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیاء OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای داخلی، ویدئوهای داخلی و داده‌های OLE ارجاع دهند. به‌جای کپی فقط شکل‌های قابل مشاهده، کل اسلاید را کلون کنید تا Aspose.Slides روابط اسلاید با منابعش را حفظ کند.

منابع داخلی و لینک‌شده باید به‌صورت متفاوتی مدیریت شوند. یک صدا، ویدئو، شیء OLE یا لینک هیپرمتنی که لینک‌شده باشد، همچنان به هدف خارجی خود وابسته است؛ کلون اسلاید لینک را به محتوی داخلی تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائهٔ ادغام‌شده باز می‌شود، تست کنید.

Aspose.Slides مسترهای کلون‌شده به‌صورت خودکار را پیگیری می‌کند، اما این به‌عنوان تضمینی کلی برای حذف تکراری منابع باینری یکسان از ارائه‌های متفاوت تلقی نشود. اگر حجم فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی کنید و نتیجه را اندازه‌گیری کنید، نه اینکه به حذف تکراری ضمنی اعتماد داشته باشید.

### **فونت‌های توکار و دسترسی به فونت‌ها**

فونت‌ها در سطح ارائه مدیریت می‌شوند. اگر تایپوگرافی باید در ماشین‌های مختلف سازگار بماند، فرض نکنید کلون اسلایدها به‌تنهایی تضمین می‌کند همه فونت‌های مورد نیاز در محیط مقصد موجود باشد. می‌توانید با [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getembeddedfonts/) فونت‌های توکار را بررسی کنید و همان‌طور که در [Embed Fonts in Presentations](https://docs.aspose.com/slides/fa/cpp/embedded-font/) توضیح داده شده است، به‌صورت صریح آن‌ها را توکار کنید.

همچنین اطمینان حاصل کنید مجاز به توکار کردن فونت‌های استفاده‌شده در فایل‌های منبع هستید. مجوزهای فونت ممکن است توکار شدن را محدود کنند.

### **ارائه‌های دارای رمز عبور**

یک منبع محافظت‌شده با رمز عبور باید قبل از کلون اسلایدها با موفقیت باز شود. رمز عبور را از طریق [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) ارائه دهید.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

باز کردن منبع رمزگذاری‌شده به‌صورت خودکار همان حفاظت را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز حفاظت خروجی را جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ حاوی تصاویر با وضوح بالا، صدا، ویدئو یا اشیای باینری بزرگ می‌توانند حافظهٔ قابل توجهی مصرف کنند. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) کنترل‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌کند. برای استراتژی‌های فایل بزرگ، به [Manage Presentation BLOBs](https://docs.aspose.com/slides/fa/cpp/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، تا جایی که ممکن است از مسیرهای فایل برای بارگذاری استفاده کنید، هر ارائه منبع را به‌محض ادغام شدن آزاد کنید و از ذخیرهٔ مکرر نتایج میانی خودداری کنید مگر اینکه جریان کار نیاز به نقطه‌های بازرسی داشته باشد.

### **ایمنی در چندنخی**

نحوهٔ بارگذاری، تغییر، ذخیره یا کلون همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را به‌صورت همزمان از چندین رشته انجام ندهید. هر نمونهٔ ارائه را به یک عملیات ادغام محدود کنید. اگر کارهای مستقل را موازی می‌کنید، از نمونه‌های جداگانهٔ ارائه استفاده کنید و راهنمایی‌های چندنخی Aspose.Slides را دنبال کنید: [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/fa/cpp/multithreading/).

## **سؤالات متداول**

**چگونه می‌توانم طرح اصلی هر ارائه منبع را حفظ کنم؟**

از [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) بدون ارائه مستر یا لایه مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار وقتی اسلاید وارد‌شده به آن نیاز دارد، کلون کند.

**چگونه اسلایدهای وارد‌شده را به تم مقصد بپیوندم؟**

overloadی را که مستر مقصد را می‌گیرد استفاده کنید. مستری از ارائهٔ مقصد، نه منبع، پاس کنید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک لایهٔ مناسب تحت آن مستر مطابقت دهد.

**چه زمانی باید به‌جای مستر مقصد از لایهٔ خاصی استفاده کنم؟**

وقتی هر اسلاید وارد‌شده باید از یک لایهٔ شناخته‌شده استفاده کند، لایهٔ خاص را انتخاب کنید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام لایهٔ منبع، میان لایه‌های مستر انتخاب کند، مستر را استفاده کنید.

**آیا می‌توان ارائه‌های با اندازهٔ اسلاید متفاوت را ادغام کرد؟**

بله، اما محتوی اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای داشتن موقعیت‌بندی قابل پیش‌بینی، پیش از ادغام اندازهٔ ارائه منبع را با [SlideSize::SetSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidesize/setsize/) و [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidesizescaletype/) تغییر دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای موردنیاز را به یک مقصد کلون کنید و مقصد را در فرمتی پشتیبانی‌شده ذخیره کنید. از آنجا که مجموعه ویژگی‌های فرمت‌های ارائه متفاوت است، پس از ادغام‌های میان‌فرمت محتویات پیچیده را بررسی کنید. برای لیست فرمت‌های پشتیبانی‌شده ببینید [Supported File Formats](https://docs.aspose.com/slides/fa/cpp/supported-file-formats/).

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه توسط حلقهٔ ساده‌ای که فقط اسلایدها را کلون می‌کند. برای حفظ بخش‌ها، آن‌ها را در مقصد دوباره ایجاد کنید و از overload بخش‌دار [AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) استفاده کنید.

**آیا یادداشت‌های گوینده و نظرات حفظ می‌شوند؟**

آن‌ها همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان کاری که به استایل مستر یادداشت، نویسندگان نظرات یا داده‌های مرور زنجیره‌ای وابسته است، نتیجه ادغام را بررسی کنید، زیرا این موارد شامل ساختارهای سطح ارائه در کنار محتوی اسلاید هستند.

**چه اتفاقی برای صداها، ویدئوها، اشیاء OLE و پیوندها می‌افتد؟**

محتویات توکار به‌عنوان بخشی از روابط منبع اسلاید کلون‌شده منتقل می‌شوند. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌های هدف یا URLهای آن‌ها باید پس از ادغام در دسترس باشند.

**آیا فونت‌های توکار از هر منبع به‌صورت خودکار در ارائهٔ نهایی موجود خواهند شد؟**

به‌تنهایی کلون اسلاید برای استقرار فونت‌ها اطمینان نمی‌دهد. فونت‌های توکار مقصد را بررسی کنید و توکارسازی یا دسترسی به فونت‌های خارجی را به‌صورت صریح مدیریت کنید.

**چگونه یک فایل دارای رمز عبور را ادغام کنم؟**

با استفاده از [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) آن را باز کنید، سپس اسلایدهایش را به‌صورت معمول کلون کنید. محافظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

از مدیریت BLOB استفاده کنید، ترجیحاً از مسیرهای فایل برای بارگذاری استفاده کنید، هر ارائه منبع را به‌محض اتمام ادغام آزاد کنید و نتیجهٔ نهایی را فقط در زمان نیاز ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین رشته ادغام کنم؟**

از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) همزمان در چندین رشته استفاده نکنید. هر عملیات ادغام را به نمونه‌های جداگانهٔ ارائه محدود کنید.