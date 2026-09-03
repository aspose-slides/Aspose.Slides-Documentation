---
title: مدیریت انتقال اسلایدها در ارائه‌ها با C++
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/cpp/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "انتقال اسلایدها را اعمال کنید، پیشروی خودکار اسلایدها را پیکربندی کنید و اثرات Morph و سایر افکت‌های انتقال را با Aspose.Slides برای C++ سفارشی کنید."
---
## **مروری کلی**

انتقالات اسلایدها نحوه نمایش اسلایدها را در طول یک نمایش اسلاید کنترل می‌کنند. با Aspose.Slides برای C++ می‌توانید برای هر اسلاید یک افکت انتقال انتخاب کنید، پیشروی را با کلیک ماوس یا تایمر تنظیم کنید و گزینه‌های خاص یک افکت را تنظیم کنید. این مقاله از مثال‌های C++ برای اعمال انتقال‌ها، تنظیم مدت زمان دقیق انتقال، مدیریت زمان‌بندی اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. نمونه‌ها همچنین نشان می‌دهند چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [get_SlideShowTransition](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) دسترسی پیدا کنید. با فراخوانی [set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_type/) مقداری از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitiontype/) تعیین کنید، سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را بر روی اولین اسلاید و یک انتقال Comb را بر روی دومین اسلاید اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

## **افزودن انتقال اسلاید پیشرفته**

می‌توانید مدت زمان ماندن اسلاید روی صفحه و اینکه آیا کلیک ماوس نمایش اسلاید را پیش می‌برد تنظیم کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) به بیننده اجازه می‌دهد با کلیک ماوس پیش برود.
- [set_AdvanceAfter](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_advanceafter/) پیشروی خودکار را فعال می‌کند.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) تاخیر قبل از پیشروی خودکار را بر حسب میلی‌ثانیه تعیین می‌کند.

هر دو پیشروی کلیک و زمان‌دار را فعال کنید تا بیننده بتواند یا با کلیک یا با انتظار برای تایمر به اسلاید بعدی برود. برای استفاده فقط از تایمر، [set_AdvanceOnClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) را با `false` فراخوانی کنید. تاخیر زمان پیشروی را کنترل می‌کند؛ مدت زمان اثر انتقال بصری را تنظیم نمی‌کند.

این مثال اثرهای متفاوتی را به سه اسلاید اول اختصاص می‌دهد و پیشروی خودکار پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشروی زمان‌دار فعال است یا نه، [get_AdvanceAfter](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/get_advanceafter/) را فراخوانی کنید. فقط ذخیره شدن یک تاخیر نشانگر فعال بودن تایمر نیست.

مثال بعدی فایلی را که در بالا ذخیره شد باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشروی خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس را فعال می‌کند و تنظیمات به‌روز را ذخیره می‌نماید.

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

## **تنظیم دقیق زمان‌بندی انتقال**

از [set_Duration](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_duration/) برای تعیین طول دقیق یک افکت انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [get_SlideShowTransition](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/) در اختیار می‌گذارد:

| Method | Purpose |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_duration/) | مدت زمان خود افکت انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | تاخیر پیشروی خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال کردن این تایمر، [set_AdvanceAfter](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_advanceafter/) را با `true` فراخوانی کنید. |
| [set_Speed](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_speed/) | یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitionspeed/) را انتخاب می‌کند: Slow، Medium یا Fast. هنگامی که مدت زمان دقیق مشخص نشده باشد استفاده می‌شود. |

[set_Duration](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_duration/) فقط اثر انتقال را کنترل می‌کند؛ مدت زمان نمایش اسلاید را تعیین نمی‌کند. تاخیر پیشروی خودکار را جداگانه تنظیم کنید. وقتی مدت زمان صریحی تنظیم نشود، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار برگشتی از [get_Speed](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/get_speed/) محاسبه می‌کند.

### **اعمال همان مدت زمان بر همه اسلایدها**

برای حفظ ریتم یکسان، همان اثر و مدت زمان دقیق را بر تمام اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitiontype/) انتخاب کرده و به هر انتقال مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. همچنین پیشروی خودکار پس از ۵۰۰۰ میلی‌ثانیه فعال و پیشروی با کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

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

    // پیشروی خودکار را به‌صورت مستقل از مدت زمان اثر پیکربندی کنید.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای منفرد**

اسلایدهای مختلف می‌توانند مدت زمان‌های متفاوتی داشته باشند. برای مثال، برای اسلاید عنوان یک انتقال کوتاه و برای معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه برای اولین اسلاید و ۱۲۰۰ میلی‌ثانیه برای دومین اسلاید تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

### **هماهنگ‌سازی انتقال‌ها با خروجی‌های انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/cpp/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/cpp/export-to-html5/) یا [video](/slides/fa/cpp/convert-powerpoint-to-video/)، قبل از استخراج مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با ریتم مورد نظر مطابقت داشته باشد. برای مثال، یک محو شدن ۶۰۰ میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشروی هر اسلاید را جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن باقی بماند.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت زمان افکت هماهنگ کنید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم در ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات استخراج فعال کنید. فرمت خروجی انتخابی را برای اثرات و گزینه‌های زمان‌بندی پشتیبانی‌شده بررسی کنید و خروجی را پیش‌نمایش کنید تا همگام‌سازی تأیید شود.

### **خواندن مدت زمان موجود یک انتقال**

قبل از تغییر انتقال، [get_Duration](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/get_duration/) را فراخوانی کنید تا بررسی کنید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معنی است که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیر منفی مدت زمان ذخیره شده بر حسب میلی‌ثانیه است. این مقدار تنظیم‑نشده محاسبه مدت زمان پخش نیست: Aspose.Slides با توجه به نوع انتقال و مقدار برگشتی از [get_Speed](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/get_speed/) آن را تعیین می‌کند. تنظیم یک نوع انتقال می‌تواند مدت زمان پیش‌فرضی ایجاد کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

## **انتقال Morph**

انتقال Morph تغییرات بین اشیا در اسلایدهای متوالی را انیمیشن می‌کند. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، یک شیء را در کلون جابجا یا اندازه‌اش را تغییر دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار اشیائی که باید بین وضعیت اصلی و تغییر یافته انیمیشن شوند را به هم مرتبط می‌سازد.

مثال زیر یک اسلاید حاوی یک مستطیل متن ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس برای اسلاید دوم Morph را از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitiontype/) انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایش‌کننده‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در حین نمایش اسلاید ببینید.

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

## **انواع انتقال Morph**

شمارش‌گر [TransitionMorphType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitionmorphtype/) نحوهٔ تطبیق و انیمیشن محتوا را کنترل می‌کند:

- [ByObject](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitionmorphtype/) هر شکل را به عنوان یک شیء کلی در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitionmorphtype/) متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitionmorphtype/) متن را با تطبیق کاراکترها (در صورت امکان) انیمیشن می‌کند.

با فراخوانی [set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_type/) مقدار Morph را تنظیم کنید، سپس [get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/get_value/) را فراخوانی کنید. مقدار برگشت‑داده‌شده اینترفیس [IMorphTransition](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/imorphtransition/) را فراهم می‌کند که متد [set_MorphType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) حالت تطبیق را انتخاب می‌کند.

این مثال ارائه‌ای را که در بخش قبلی ساخته شد باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph مبتنی بر کلمه تنظیم می‌کند.

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

## **تنظیم افکت‌های انتقال**

برخی از انتقال‌ها گزینه‌های اضافه‌ای مانند جهت یا شروع اثر از صفحهٔ سیاه را افشا می‌کنند. گزینه‌های موجود به نوع انتقال انتخاب‌شده بستگی دارد. ابتدا نوع را تنظیم کنید، سپس رابط مناسب برگردانده‌شده توسط [get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/get_value/) را استفاده کنید.

مثال زیر یک انتقال Cut را به اولین اسلاید `input.pptx` اعمال می‌کند. با استفاده از [IOptionalBlackTransition](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/ioptionalblacktransition/)، متد [set_FromBlack](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) را با `true` فراخوانی می‌کند تا انتقال از صفحهٔ سیاه آغاز شود.

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

## **سؤالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. وقتی به مدت زمان دقیق افکت بر حسب میلی‌ثانیه نیاز دارید، از [set_Duration](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_duration/) استفاده کنید. وقتی یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitionspeed/) (Slow، Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از [set_Speed](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_speed/) استفاده کنید. این تنظیمات افکت انتقال را به‌صورت مستقل از تاخیر پیشروی خودکار کنترل می‌کند.

**آیا می‌توانم صدا را به یک انتقال پیوست کنم و حلقه‌ای پخش شود؟**

بله. با [set_Sound](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_sound/) صدای جاسازی‌شده را اختصاص دهید، [set_SoundMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_soundmode/) را با مقدار StartSound از شمارش‌گر [TransitionSoundMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitionsoundmode/) تنظیم کنید و با [set_SoundLoop](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_soundloop/) حلقه شدن را فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین راه برای اعمال یک انتقال یکسان به همه اسلایدها چیست؟**

در مجموعه‌ای که توسط متد [get_Slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slides/) ارائه بازگردانده می‌شود حلقه بزنید و برای هر اسلاید [set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/set_type/) را با همان مقدار فراخوانی کنید. هر تنظیم زمانی و افکتی را در همان حلقه تنظیم کنید تا رفتار بین اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی هم‌اکنون بر روی یک اسلاید تنظیم شده است؟**

متد [get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideshowtransition/get_type/) را بر روی انتقالی که توسط [get_SlideShowTransition](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) اسلاید بازگردانده می‌شود فراخوانی کنید. این متد مقداری از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitiontype/) برمی‌گرداند؛ مقدار None به این معنی است که هیچ افکت انتقالی اعمال نشده است.