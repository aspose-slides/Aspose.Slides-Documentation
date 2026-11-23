---
title: مدیریت انتقال اسلایدها در ارائه‌ها با استفاده از C++
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
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اعمال انتقال اسلایدها، پیکربندی پیشرفت خودکار اسلایدها، و سفارشی‌سازی Morph و دیگر اثرات انتقال با Aspose.Slides برای C++."
---
## **مرور کلی**

انتقال اسلایدها مشخص می‌کند که اسلایدها در طول نمایش اسلایدها چگونه ظاهر شوند. با Aspose.Slides for C++ می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت را با کلیک ماوس یا زمان‌سنج تنظیم کنید و گزینه‌های خاص یک اثر را تنظیم کنید. این مقاله از مثال‌های C++ برای اعمال انتقال‌ها، تنظیم مدت زمان دقیق انتقال، مدیریت زمان اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را به یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال یک اسلاید را از طریق [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) دریافت کنید. سپس با صدا زدن [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) مقدار مورد نظر از شمارش [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) را تنظیم کنید و ارائه را ذخیره نمایید.

مثال زیر یک انتقال Circle را به اسلاید اول و یک انتقال Comb را به اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

## **انتقال Wheel**

متد [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) در [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) تعداد بخش‌های شعاعی که اسلاید مقصد را آشکار می‌کنند، کنترل می‌کند. قبل از دسترسی به [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) به عنوان [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/)، [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) را با مقدار Wheel از [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) صدا بزنید.

این مثال دو جفت اسلاید یکسان ایجاد می‌کند: یک اسلاید مشکی به دنبال اسلایدی با یک مستطیل طلایی. اسلایدهای مقصد شمارش شعاعی ۱ و ۸ دارند، با سرعت یکسانی که از طریق [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) تنظیم شده و با مدت زمان صریح ۸۰۰۰ میلی‌ثانیه از طریق [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) تنظیم می‌شود تا تفاوت به‌راحتی قابل مشاهده باشد.

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

پرزنتیشن خروجی را در PowerPoint باز کنید و نمایش اسلایدها را اجرا کنید. از اسلاید ۱ به اسلاید ۲ پیش بروید، سپس از اسلاید ۳ به اسلاید ۴. در پخش PowerPoint، شمارش شعاعی ۱ اسلاید را با یک جاروب ساعت‌گرد واحد نشان می‌دهد؛ شمارش ۸ اسلاید را همزمان با هشت بخش شعاعی نشان می‌دهد. محتوا و زمان‌بندی انتقال مقصد یکسان هستند، پس تفاوت تنها در تعداد بخش‌های نمایان است.

## **محو شدن به‌صورت سیاه با انتقال Reveal**

نوع انتقال اسلاید مقصد را به Reveal تنظیم کنید، سپس روی رابط [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/) متد [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) را صدا بزنید. مثال یک اسلاید مبدا به رنگ سبز دریایی و یک اسلاید مقصد به رنگ مرجانی ایجاد می‌کند، سپس هر دو را کلون می‌کند تا همان انتقال دو‑ثانیه‌ای را با فعال/غیرفعال بودن "محو شدن به‌صورت سیاه" مقایسه کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

در یک نمایش PowerPoint، از اسلاید ۱ به اسلاید ۲ پیش بروید. سبز دریایی به‌صورت مستقیم به مرجانی محو می‌شود. سپس از اسلاید ۳ به اسلاید ۴ پیش بروید. صفحه کوتاهً تقریباً سیاه می‌شود قبل از این که اسلاید مرجانی ظاهر شود. هر دو اسلاید رنگ پس‌زمینه اصلی خود را حفظ می‌کنند.

ردیف‌های زیر فریم‌هایی از PowerPoint با فاصله نیم ثانیه نشان می‌دهند. برای دیدن تأثیر تنظیم، فریم میانی هر ردیف را با هم مقایسه کنید.

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **افزودن انتقال اسلاید پیشرفته**

می‌توانید مدت زمان باقی‌ماندن اسلاید روی صفحه و این که آیا کلیک ماوس نمایش اسلایدها را پیش می‌برد یا نه، پیکربندی کنید. متدهای زیر این رفتار را کنترل می‌کنند:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) اجازه می‌دهد بیننده با کلیک ماوس پیش برود.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) پیشرفت خودکار را فعال می‌کند.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) تاخیر قبل از پیشرفت خودکار را بر حسب میلی‌ثانیه تعیین می‌کند.

هر دو پیشرفت کلیک و زمان‌دار را فعال کنید تا بیننده بتواند با کلیک یا انتظار برای زمان‌سنج ادامه دهد. برای استفاده فقط از زمان‌سنج، [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) را با `false` صدا بزنید. تاخیر زمان‌بندی زمان پیشرفت نمایش اسلاید را کنترل می‌کند؛ این مقدار مدت زمان اثر انتقالی بصری را تعیین نمی‌کند.

این مثال اثرهای مختلف را به سه اسلاید اول اختصاص می‌دهد و پیشرفت خودکار را پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیش ببرد. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشرفت زمان‌دار فعال است یا نه، [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) را صدا بزنید. تنها وجود یک تاخیر ذخیره شده نشان‌دهنده فعال بودن تایمر نیست.

مثال بعدی فایل ذخیره‌شده در بالا را باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای این اسلایدها کلیک ماوس را فعال می‌کند و تنظیمات به‌روز شده را ذخیره می‌نماید.

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

## **کنترل دقیق زمان‌بندی انتقال**

از [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) برای مشخص کردن طول دقیق یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) اسلاید این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) در دسترس می‌گذارد:

| متد | هدف |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | تاخیر پیشرفت خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این تایمر، [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) را با `true` صدا بزنید. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | یک دسته سرعت پیش‌تعریف شده از [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) (Slow، Medium یا Fast) را انتخاب می‌کند. زمانی که مدت زمان صریحی مشخص نشده باشد، استفاده می‌شود. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) فقط بر اثر انتقال تأثیر می‌گذارد؛ این مقدار زمان باقی‌ماندن اسلاید روی صفحه را تعیین نمی‌کند. تاخیر پیشرفت خودکار را جداگانه پیکربندی کنید. وقتی هیچ مدت زمان صریحی تنظیم نشود، Aspose.Slides مدت زمان اثر را از نوع انتقال و مقدار بازگردانده‌شده توسط [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) محاسبه می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **اعمال همان مدت زمان به همه اسلایدها**

برای حفظ سرعت ثابت، همان اثر و مدت زمان دقیق را به همه اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) انتخاب می‌کند و به هر انتقال مدت ۷۵۰ میلی‌ثانیه می‌دهد. پیشرفت خودکار را پس از ۵۰۰۰ میلی‌ثانیه فعال می‌سازد و پیشرفت با کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

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

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان اثرهای متفاوتی داشته باشند. برای مثال، برای اسلاید عنوان یک انتقال کوتاه و برای اسلاید معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه برای اسلاید اول و ۱۲۰۰ میلی‌ثانیه برای اسلاید دوم تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

### **هماهنگی انتقال‌ها با خروجی انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/cpp/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/cpp/export-to-html5/)، یا [video](/slides/fa/cpp/convert-powerpoint-to-video/)، مدت زمان دقیق انتقال‌ها را قبل از خروجی تنظیم کنید تا با سرعت موردنظر هم‑ساز باشد. برای مثال، یک محو شدن ۶۰۰ میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوا وجود داشته باشد.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: ۶۰۰ میلی‌ثانیه برابر است با ۱۸ فریم در ۳۰ فریم بر ثانیه. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. گزینه‌های اثر و زمان‌بندی پشتیبانی‌شده توسط فرمت خروجی انتخابی را بررسی کنید و خروجی را پیش‌نمایش کنید تا هم‌زمانی را تأیید کنید.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) را صدا بزنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معنی است که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیر منفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. این مقدار تنظیم نشده برابر با طول زمان پخش محاسبه‌شده نیست؛ Aspose.Slides نوع انتقال و مقدار بازگردانده‌شده توسط [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) را برای تعیین آن استفاده می‌کند. تنظیم نوع انتقال می‌تواند مدت زمان اولیه‌ای را ایجاد کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

انتقال Morph تغییرات بین اشیاء روی اسلایدهای متوالی را انیمیت می‌کند. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، شیء‌ای را در کلون جابه‌جا یا تغییر اندازه دهید و انتقال Morph را برای اسلاید دوم اعمال کنید. این کار اشیاء متناظر را برای انیمیشن بین حالت اولیه و تغییر یافته فراهم می‌سازد.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس برای اسلاید دوم از [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) مقدار Morph را انتخاب می‌کند. فایل ذخیره‌شده را در یک مرورگر ارائه‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در طول نمایش اسلایدها ببینید.

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

شمارش [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) نحوهٔ مطابقت و انیمیشن محتوا را تعیین می‌کند:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) هر شکل را به‌عنوان یک شیء کلی در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) متن را با مطابقت کلمات (در صورت امکان) انیمیت می‌کند.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) متن را با مطابقت حروف (در صورت امکان) انیمیت می‌کند.

قبل از دسترسی به [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)، [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) را با مقدار Morph صدا بزنید. سپس مقدار بازگردانده شده اینترفیس [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) را فراهم می‌کند که متد [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) حالت مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبل ایجاد شد را باز می‌کند و اسلاید دوم را برای انیمیشن Morph بر پایهٔ کلمه تنظیم می‌نماید.

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

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا این که اثر از صفحهٔ سیاه شروع شود را در اختیار می‌گذارند. گزینه‌های موجود به نوع انتقال انتخاب‌شده بستگی دارد. ابتدا نوع را تنظیم کنید، سپس از اینترفیس مناسب که توسط [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) بازگردانده می‌شود، استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) با مقدار `true` از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) استفاده می‌کند تا انتقال از صفحهٔ سیاه آغاز شود.

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

## **سوالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. زمانی که به یک مدت زمان دقیق اثر به میلی‌ثانیه نیاز دارید، از [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) استفاده کنید. وقتی یک دستهٔ پیش‌تعریف شده از [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) (Slow، Medium یا Fast) کافی است و مقدار صریحی تنظیم نمی‌شود، از [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) استفاده کنید. این تنظیمات اثر انتقال را مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا به یک انتقال اضافه کنم و آن را به‑صورت حلقه اجرا کنم؟**

بله. صداهای تعبیه‌شده را با [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) تخصیص دهید، سپس [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) را با مقدار StartSound از شمارش [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) صدا بزنید و با [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) حلقه‌گذاری کنید. صدا تا وقوع رویداد صوتی بعدی در نمایش اسلاید ادامه می‌یابد.

**سریع‌ترین راه برای اعمال همان انتقال به همه اسلایدها چیست؟**

در مجموعه‌ای که توسط متد [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) ارائه بازگردانده می‌شود، حلقه بزنید و برای هر اسلاید [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) را با همان مقدار صدا بزنید. هر تنظیم زمان و اثر را در همان حلقه اعمال کنید تا رفتار بین اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی بر روی یک اسلاید تنظیم شده است؟**

متد [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) را بر روی شیء انتقالی که توسط [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) اسلاید برگردانده می‌شود، صدا بزنید. این متد یک مقدار از شمارش [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) برمی‌گرداند؛ مقدار None به این معنی است که هیچ اثر انتقالی اعمال نشده است.