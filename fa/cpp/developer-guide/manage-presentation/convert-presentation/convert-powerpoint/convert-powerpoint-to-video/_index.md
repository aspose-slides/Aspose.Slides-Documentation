---
title: تبدیل ارائه‌های PowerPoint به ویدیو در C++
linktitle: PowerPoint به ویدیو
type: docs
weight: 130
url: /fa/cpp/convert-powerpoint-to-video/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به ویدیو
- ارائه به ویدیو
- PPT به ویدیو
- PPTX به ویدیو
- PowerPoint به MP4
- ارائه به MP4
- PPT به MP4
- PPTX به MP4
- ذخیره PPT به صورت MP4
- ذخیره PPTX به صورت MP4
- صدور PPT به MP4
- صدور PPTX به MP4
- تبدیل ویدیو
- PowerPoint
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint را به ویدیو در C++ تبدیل کنید. کد نمونه و تکنیک‌های خودکارسازی را کشف کنید تا گردش کار خود را بهینه کنید."
---
## **معرفی**

با تبدیل ارائهٔ PowerPoint خود به ویدیو، موارد زیر را به‌دست می‌آورید

* **افزایش دسترسی‌پذیری:** تمامی دستگاه‌ها (بدون توجه به پلتفرم) به‌طور پیش‌فرض دارای پخش‌کنندهٔ ویدیو هستند، در حالی که برنامه‌های باز کردن ارائه کمتر رایج‌اند، بنابراین کاربران راحت‌تر می‌توانند ویدیوها را باز یا پخش کنند.
* **دسترس‌پذیری بیشتر:** از طریق ویدیوها می‌توانید به جمعیتی گسترده دسترسی پیدا کنید و اطلاعاتی را به آن‌ها ارائه دهید که در یک ارائه ممکن است خسته‌کننده به‌نظر برسد. اکثر نظرسنجی‌ها و آمارها نشان می‌دهند که مردم ویدیوها را بیشتر از سایر انواع محتوا تماشا و مصرف می‌کنند و به‌طور کلی چنین محتوایی را ترجیح می‌دهند.

در [Aspose.Slides 22.11](https://docs.aspose.com/slides/fa/cpp/aspose-slides-for-cpp-22-11-release-notes/) ما پشتیبانی از تبدیل ارائه به ویدیو را پیاده‌سازی کرده‌ایم.

* از Aspose.Slides برای تولید مجموعه‌ای از فریم‌ها (از اسلایدهای ارائه) که با یک FPS (فریم در ثانیه) معین مطابقت دارند، استفاده کنید
* از ابزار شخص ثالثی مانند `ffmpeg` برای ایجاد ویدیو بر پایهٔ فریم‌ها استفاده کنید.

## **تبدیل یک ارائهٔ PowerPoint به ویدیو**

1. ffmpeg را از [اینجا](https://ffmpeg.org/download.html) دانلود کنید.
2. مسیر `ffmpeg.exe` را به متغیر محیطی `PATH` اضافه کنید.
3. کد تبدیل PowerPoint به ویدیو را اجرا کنید.

این کد C++ نشان می‌دهد که چگونه یک ارائه (شامل یک نمودار و دو اثر انیمیشن) را به ویدیو تبدیل کنید:

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک شکل لبخند اضافه می‌کند و سپس آن را انیمیشن می‌دهد
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **افکت‌های ویدیو**

می‌توانید به اشیاء روی اسلایدها انیمیشن اعمال کنید و از انتقال‌ها بین اسلایدها استفاده کنید.

{{% alert color="info" %}} 

ممکن است مایل باشید این مقالات را ببینید: [PowerPoint Animation](https://docs.aspose.com/slides/fa/cpp/powerpoint-animation/)، [Shape Animation](https://docs.aspose.com/slides/fa/cpp/shape-animation/)، و [Shape Effect](https://docs.aspose.com/slides/fa/cpp/shape-effect/) .

{{% /alert %}} 

انیمیشن‌ها و انتقال‌ها اسلایدشوها را جذاب‌تر و جالب‌تر می‌سازند — و همین امر برای ویدیوها نیز صدق می‌کند. اجازه دهید یک اسلاید و یک انتقال دیگر به کد ارائهٔ قبلی اضافه کنیم:

```c++
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;

// یک شکل لبخند اضافه می‌کند و همان‌طور که در بالا نشان داده شده است انیمیشن می‌دهد
auto presentation = System::MakeObject<Presentation>();

// یک اسلاید جدید اضافه می‌کند و انتقال انیمیشن‌شده

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides همچنین از انیمیشن برای متن‌ها پشتیبانی می‌کند. بنابراین ما پاراگراف‌های روی اشیاء را انیمیشن می‌زنیم تا به‌صورت متوالی (با تاخیری برابر با یک ثانیه) ظاهر شوند:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // متن و انیمیشن‌ها را اضافه می‌کند
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // فریم‌ها را به ویدیو تبدیل می‌کند
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **کلاس‌های تبدیل ویدیو**

برای اینکه بتوانید وظایف تبدیل PowerPoint به ویدیو را انجام دهید، Aspose.Slides کلاس‌های [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_animations_generator/) و [PresentationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_player/) را فراهم می‌کند.

PresentationAnimationsGenerator به شما اجازه می‌دهد تا اندازهٔ فریم برای ویدیوی بعدی (که بعداً ساخته می‌شود) را از طریق سازنده‌اش تنظیم کنید. اگر یک نمونه از ارائه را پاس دهید، `Presentation.SlideSize` استفاده می‌شود و انیمیشن‌هایی که [PresentationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_player/) استفاده می‌کند، تولید می‌شوند.

هنگام تولید انیمیشن‌ها، برای هر انیمیشن بعدی یک رویداد `NewAnimation` ایجاد می‌شود که پارامتر [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.i_presentation_animation_player/) دارد. این کلاس نمایانگر یک پلیر برای یک انیمیشن جداگانه است.

برای کار با [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.i_presentation_animation_player/)، از ویژگی [get_Duration](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (کل مدت زمان انیمیشن) و متد [SetTimePosition](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) استفاده می‌شود. هر موقعیت انیمیشن در بازهٔ *0 تا duration* تنظیم می‌شود و سپس متد `GetFrame` یک Bitmap برمی‌گرداند که نشان‌دهندهٔ وضعیت انیمیشن در همان لحظه است.

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/IPresentationAnimationPlayer.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <IImage.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // وضعیت اولیه انیمیشن
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // تصویر bitmap وضعیت اولیه انیمیشن

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // وضعیت نهایی انیمیشن
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // فریم آخر انیمیشن
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک شکل لبخند اضافه می‌کند و آن را انیمیشن می‌دهد
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

برای پخش همزمان تمام انیمیشن‌های یک ارائه، از کلاس [PresentationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_player/) استفاده می‌شود. این کلاس یک نمونهٔ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_animations_generator/) و FPS برای اثرات را در سازنده می‌گیرد و سپس برای تمام انیمیشن‌ها رویداد `FrameTick` را فراخوانی می‌کند تا آن‌ها اجرا شوند:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```

سپس فریم‌های تولید‑شده می‌توانند به‌منظور تولید ویدیو ترکیب شوند. بخش [Convert PowerPoint to Video](https://docs.aspose.com/slides/fa/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) را ببینید.

## **انیمیشن‌ها و افکت‌های پشتیبانی‌شده**


**ورودی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fade** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Fly In** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Float In** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Split** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Wipe** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shape** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Wheel** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Random Bars** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Grow & Turn** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Zoom** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Swivel** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Bounce** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |


**تاکید**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Color Pulse** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Teeter** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Spin** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Grow/Shrink** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Desaturate** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Darken** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Lighten** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Transparency** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Object Color** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Complementary Color** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Line Color** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fill Color** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |

**خروج**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fade** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Fly Out** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Float Out** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Split** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Wipe** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shape** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Random Bars** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shrink & Turn** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Zoom** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Swivel** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Bounce** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |

**مسیرهای حرکتی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Arcs** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Turns** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shapes** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Loops** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Custom Path** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |

## **پرسش‌های متداول**

### آیا می‌توان ارائه‌هایی که با رمز عبور محافظت شده‌اند را تبدیل کرد؟

بله، Aspose.Slides امکان کار با [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/cpp/password-protected-presentation/) را فراهم می‌کند. هنگام پردازش چنین فایل‌هایی، باید رمز عبور صحیح را ارائه دهید تا کتابخانه به محتوای ارائه دسترسی پیدا کند.

### آیا Aspose.Slides از استفاده در راه‌حل‌های ابری پشتیبانی می‌کند؟

بله، Aspose.Slides می‌تواند در برنامه‌ها و سرویس‌های ابری یکپارچه شود. این کتابخانه برای کار در محیط‌های سرور طراحی شده و عملکرد بالا و مقیاس‌پذیری را برای پردازش دسته‌ای فایل‌ها تضمین می‌کند.

### آیا محدودیت‌های سایز برای ارائه‌ها هنگام تبدیل وجود دارد؟

Aspose.Slides قادر به پردازش ارائه‌هایی با اندازهٔ تقریباً نامحدود است. اما هنگام کار با فایل‌های بسیار بزرگ، ممکن است به منابع سیستم بیشتری نیاز باشد و گاهی توصیه می‌شود تا برای بهبود عملکرد، ارائه را بهینه‌سازی کنید.