---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با استفاده از C++
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/cpp/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال پیشرفته اسلاید
- انتقال مورف
- نوع انتقال
- اثر انتقال
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "انتقال‌های اسلاید را اعمال کنید، پیشرفت خودکار اسلایدها را پیکربندی کنید و اثرات Morph و سایر اثرات انتقالی را با Aspose.Slides برای C++ سفارشی کنید."
---
## **نمایش کلی**

انتقال اسلایدها نحوه ظاهر شدن اسلایدها را در طول یک نمایش اسلاید کنترل می‌کند. با Aspose.Slides برای C++ می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشروی را با کلیک ماوس یا زمانسنج پیکربندی کنید و گزینه‌های خاص یک اثر را تنظیم کنید. این مقاله از مثال‌های C++ برای اعمال انتقال‌ها، تنظیم مدت زمان دقیق انتقال، مدیریت زمان اسلاید و ایجاد یک انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را در فایلی با فرمت PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، ارائه‌ای را با کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) دریافت کنید. سپس متد [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) را با مقدار از شمارشگر [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) فراخوانی کرده و ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را به اسلاید اول و یک انتقال Comb را به اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل شامل دو اسلاید باشد استفاده کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Wheel Transition**

متد [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) از [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) تعداد بخش‌های شعاعی که اسلاید مقصد را نشان می‌دهند کنترل می‌کند. قبل از دسترسی به [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) به‌عنوان [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/)، متد [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) را با مقدار Wheel از شمارشگر [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) فراخوانی کنید.

این مثال دو جفت اسلاید یکسان ایجاد می‌کند: یک اسلاید سیاه به‌دنبال اسلایدی با مستطیل طلایی. اسلایدهای مقصد با تعداد spoke برابر 1 و 8 استفاده می‌کنند، با همان سرعتی که از طریق [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) تنظیم شده و مدت زمان صریح 8,000 میلی‌ثانیه از طریق [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) برای آسان شدن مشاهده اختلاف تنظیم شده است.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

خروجی ارائه را در PowerPoint باز کنید و نمایش اسلاید را اجرا کنید. از اسلاید 1 به اسلاید 2 و سپس از اسلاید 3 به اسلاید 4 پیشروی کنید. در پخش PowerPoint، تعداد spoke تأیید شده 1 اسلاید را با یک حرکت ساعتگرد نشان می‌دهد؛ تعداد تأیید شده 8 اسلاید را همزمان از طریق هشت بخش شعاعی نمایش می‌دهد. محتویات مقصد و زمان‌بندی انتقال یکسان هستند، لذا تفاوت فقط در تعداد بخش‌های نمایش است.

## **Add Advanced Slide Transition**

می‌توانید مدت زمانی که یک اسلاید روی صفحه می‌ماند و اینکه آیا کلیک ماوس پیشروی نمایش را انجام می‌دهد، پیکربندی کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) اجازه می‌دهد بیننده با کلیک ماوس پیشروی کند.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) پیشروی خودکار را فعال می‌کند.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) تاخیر قبل از پیشروی خودکار اسلاید را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشروی کلیکی و زمان‌بندی‌شده را فعال کنید تا بیننده یا با کلیک یا با انتظار برای زمانسنج بتواند به اسلاید بعدی برود. برای استفاده فقط از زمانسنج، متد [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) را با مقدار `false` صدا بزنید. تاخیر زمانسنج فقط زمان پیشرفت نمایش اسلاید را تعیین می‌کند؛ مدت زمان اثر بصری را تنظیم نمی‌کند.

این مثال اثرهای مختلفی را به سه اسلاید اول اختصاص داده و پیشروی خودکار پس از 3، 5 و 7 ثانیه به ترتیب فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیشروی کند. از فایلی به نام `input.pptx` که حداقل شامل سه اسلاید باشد استفاده کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

برای بررسی اینکه آیا پیشروی زمان‌بندی‌شده فعال است یا نه، متد [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) را فراخوانی کنید. تنها ذخیره‌کردن تاخیر نشان‌دهنده فعال بودن زمانسنج نیست.

مثال بعدی فایلی را که در بالا ذخیره شد باز می‌کند، هر زمانسنج فعال را گزارش می‌دهد و پیشروی خودکار را برای اسلایدهایی که تاخیر بیشتری نسبت به دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس را فعال می‌سازد و تنظیمات به‌روز شده را ذخیره می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Control Transition Timing Precisely**

از متد [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) برای تعیین دقیق طول یک اثر انتقال در میلی‌ثانیه استفاده کنید. متد [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) اسلاید این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) باز می‌کند:

| متد | هدف |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | مدت زمان اثر انتقال را به‌صورت میلی‌ثانیه تنظیم می‌کند. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | تاخیر قبل از پیشروی خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این تایمر، [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) را با مقدار `true` فراخوانی کنید. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | یک دسته سرعت پیش‌تعریف‌شده را از [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) انتخاب می‌کند: Slow، Medium یا Fast. وقتی مدت زمان صریحی تعیین نشده باشد، این گزینه استفاده می‌شود. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) تنها اثر انتقال را کنترل می‌کند؛ مدت زمانی که اسلاید روی صفحه می‌ماند را تعیین نمی‌کند. تاخیر پیشروی خودکار را به‌طور جداگانه تنظیم کنید. وقتی هیچ مدت زمان صریحی تنظیم نشده باشد، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار بازگردانده‌شده توسط [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) محاسبه می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![نوارهای جداگانه مدت زمان انتقال 750 میلی‌ثانیه و تنظیم پیشروی خودکار 5,000 میلی‌ثانیه را نشان می‌دهند.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*مثال مشترک به هر اسلاید یک انتقال Fade با مدت زمان 750 میلی‌ثانیه می‌دهد و پیشروی خودکار را جداگانه پس از 5,000 میلی‌ثانیه فعال می‌کند. مدت زمان انتقال فقط اثر را کنترل می‌کند؛ پیشروی زمان خروج از اسلاید را تعیین می‌کند. این نوارها تنظیمات شماتیک هستند، نه یک نمودار زمان‌سنج ترکیبی اندازه‌گیری‌شده.*  
<!-- visual-explanation:slide-transition:end -->

### **Apply the Same Duration to Every Slide**

برای حفظ سرعت یکنواخت، همان اثر و همان مدت زمان دقیق را بر تمام اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) انتخاب می‌کند و برای هر انتقال مدت زمان 750 میلی‌ثانیه تعیین می‌کند. پیشروی خودکار را پس از 5,000 میلی‌ثانیه فعال و پیشروی با کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به‌صورت PPTX ذخیره می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // پیکربندی پیشرفت خودکار به‌صورت مستقل از مدت زمان اثر.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Set Different Durations for Individual Slides**

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوتی داشته باشند. به عنوان مثال، برای اسلاید عنوان یک انتقال کوتاه و برای معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال برای اسلاید اول 500 میلی‌ثانیه و برای اسلاید دوم 1,200 میلی‌ثانیه تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل شامل دو اسلاید باشد استفاده کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Coordinate Transitions with Animated Output**

هنگام تهیه یک [GIF انیمیشن‌دار](/slides/fa/cpp/convert-powerpoint-to-animated-gif/)، [ارائه HTML5](/slides/fa/cpp/export-to-html5/) یا [ویدیو](/slides/fa/cpp/convert-powerpoint-to-video/)، مدت زمان دقیق انتقال‌ها را قبل از صادر کردن تنظیم کنید تا با سرعت مورد نظر هم‌خوانی داشته باشد. به عنوان مثال، بین صحنه‌ها یک Fade 600 میلی‌ثانیه‌ای استفاده کنید و تاخیر پیشروی هر اسلاید را به‌صورت جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوا فراهم شود.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: 600 میلی‌ثانیه معادل 18 فریم در 30 فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. گزینه‌های اثر و زمان‌بندی قالب خروجی انتخاب شده را بررسی کنید و خروجی را پیش‌نمایش کنید تا هماهنگی را تأیید کنید.

### **Read an Existing Transition Duration**

قبل از تغییر انتقال، متد [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) را فراخوانی کنید تا بفهمید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معناست که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. این مقدار تنظیم‌نشده برابر با مدت زمان محاسبه‌شدهٔ پخش نیست: Aspose.Slides مدت زمان را بر اساس نوع انتقال و مقداری که توسط [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) بازگردانده می‌شود، محاسبه می‌کند. تنظیم نوع انتقال می‌تواند مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Morph Transition**

انتقال Morph تغییرات بین اشیاء در اسلایدهای متوالی را انیمیشن می‌کند. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، شیء‌ای را در نسخه کلون شده جابه‌جا یا تغییر اندازه دهید و انتقال Morph را بر اسلاید دوم اعمال کنید. این کار اشیاء متناظر را برای انیمیشن بین حالت اصلی و اصلاح‌شده فراهم می‌کند.

مثال زیر یک اسلاید با یک مستطیل متن ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در نسخه کلون شده تغییر می‌دهد. سپس برای اسلاید دوم Morph را از شمارشگر [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایش‌کننده‌ای که از Morph پشتیبانی می‌کند باز کنید تا اثر را در طول نمایش اسلاید مشاهده کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Morph Transition Types**

شمارشگر [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) نحوهٔ تطبیق و انیمیشن محتوا را کنترل می‌کند:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) هر شکل را به‌عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) متن را با تطبیق کلمات، در صورت امکان، انیمیشن می‌دهد.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) متن را با تطبیق کاراکترها، در صورت امکان، انیمیشن می‌دهد.

متد [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) را با مقدار Morph فراخوانی کنید سپس [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) را برای دسترسی به رابط [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) دریافت کنید؛ متد [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) حالت مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبلی ایجاد شد باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph مبتنی بر کلمه پیکربندی می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Set Transition Effects**

برخی انتقال‌ها گزینه‌های اضافی مانند جهت یا اینکه آیا اثر از صفحهٔ سیاه شروع می‌شود را در اختیار می‌گذارند. گزینه‌های موجود به نوع انتقال انتخاب‌شده وابسته است. ابتدا نوع را تنظیم کنید، سپس از رابط مناسب که توسط [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) بازگردانده می‌شود استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از متد [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) با مقدار `true` از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) استفاده می‌کند تا انتقال از صفحهٔ سیاه آغاز شود.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. زمانی که به مدت زمان دقیق اثر در میلی‌ثانیه نیاز دارید، از [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) استفاده کنید. وقتی یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) (Slow، Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) استفاده کنید. این تنظیمات اثر انتقال را به‌صورت مستقل از تاخیر پیشروی خودکار کنترل می‌کنند.

**آیا می‌توانم صوتی به یک انتقال متصل کنم و آن را حلقه‌دار کنم؟**

بله. با متد [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) صدا را می‌توان به‌صورت تعبیه‌شده اختصاص داد، سپس [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) را با مقدار StartSound از شمارشگر [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) فراخوانی کنید و با [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) حلقه‌زدن صدا را فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین راه برای اعمال یک انتقال یکسان بر تمام اسلایدها چیست؟**

در حلقه‌ای با استفاده از مجموعه‌ای که توسط متد [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) ارائه بازگردانده می‌شود، برای هر اسلاید متد [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) را با همان مقدار فراخوانی کنید. هر تنظیم زمان و گزینهٔ اثر را در همان حلقه تنظیم کنید تا رفتار بر تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که کدام انتقال در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

متد [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) را بر روی انتقالی که توسط متد [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) اسلاید بازگردانده می‌شود، فراخوانی کنید. این متد مقدار از شمارشگر [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) را برمی‌گرداند؛ مقدار None به این معنی است که هیچ اثر انتقالی اعمال نشده است.