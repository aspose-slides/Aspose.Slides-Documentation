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
- ذخیره PPT به عنوان MP4
- ذخیره PPTX به عنوان MP4
- صدور PPT به MP4
- صدور PPTX به MP4
- تبدیل ویدیو
- PowerPoint
- C++
- Aspose.Slides
description: "نحوه تبدیل ارائه‌های PowerPoint به ویدیو در C++ را بیاموزید. نمونه کد و تکنیک‌های خودکارسازی را برای بهینه‌سازی گردش کار خود کشف کنید."
---
## **مقدمه**

با تبدیل ارائه PowerPoint خود به ویدیو، به دست می‌آورید 

* **Increase in accessibility:** **افزایش دسترسی:** تمام دستگاه‌ها (بدون توجه به پلتفرم) به‌صورت پیش‌فرض دارای پخش‌کننده ویدیو هستند، در مقایسه با برنامه‌های باز کردن ارائه، بنابراین کاربران راحت‌تر می‌توانند ویدیوها را باز یا پخش کنند.
* **More reach:** **دسترس بیشتر:** از طریق ویدیوها می‌توانید به مخاطبان گسترده‌ای دست پیدا کنید و آن‌ها را با اطلاعاتی هدف‌گیری کنید که در ارائه ممکن است خسته‌کننده به نظر برسد. اکثر نظرسنجی‌ها و آمارها نشان می‌دهند مردم ویدیوها را بیشتر از سایر انواع محتوا مشاهده و مصرف می‌کنند و معمولاً چنین محتوایی را ترجیح می‌دهند.

در [Aspose.Slides 22.11](https://docs.aspose.com/slides/fa/cpp/aspose-slides-for-cpp-22-11-release-notes/) ما پشتیبانی از تبدیل ارائه به ویدیو را پیاده‌سازی کردیم. 

* Use Aspose.Slides to generate a set of frames (from the presentation slides) that correspond to a certain FPS (frames per second)  
* Use a third-party utility like `ffmpeg` to create a video based on the frames.

## **تبدیل ارائه PowerPoint به ویدیو**

1. ffmpeg را از [اینجا](https://ffmpeg.org/download.html) دانلود کنید.
2. مسیر `ffmpeg.exe` را به متغیر محیطی `PATH` اضافه کنید.
3. کد تبدیل PowerPoint به ویدیو را اجرا کنید.

این کد C++ نشان می‌دهد چگونه یک ارائه (شامل یک شکل و دو اثر انیمیشن) را به ویدیو تبدیل کنید:

```c++
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **افکت‌های ویدیو**

می‌توانید انیمیشن‌ها را به اشیاء روی اسلایدها اعمال کنید و بین اسلایدها از انتقال‌ها استفاده کنید.

{{% alert color="primary" %}} 

ممکن است بخواهید این مقالات را ببینید: [انیمیشن PowerPoint](https://docs.aspose.com/slides/fa/cpp/powerpoint-animation/)، [انیمیشن شکل](https://docs.aspose.com/slides/fa/cpp/shape-animation/)، و [افکت شکل](https://docs.aspose.com/slides/fa/cpp/shape-effect/).

{{% /alert %}} 

انیمیشن‌ها و انتقال‌ها ارائه اسلایدشو را جذاب‌تر و جالب‌تر می‌کنند—و برای ویدیوها نیز همین‌طور هستند. بیایید یک اسلاید دیگر و یک انتقال به کد ارائه قبلی اضافه کنیم:

```c++
// یک شکل لبخند اضافه می‌کند و آن را انیمیشن می‌دهد

// ...

// یک اسلاید جدید اضافه می‌کند و انتقال انیمیشن‌شده

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides همچنین از انیمیشن برای متون پشتیبانی می‌کند. بنابراین ما پاراگراف‌ها را روی اشیاء انیمیشن می‌کنیم که به‌صورت یکی پس از دیگری ظاهر می‌شوند (تاخیر تنظیم شده به یک ثانیه):

```c++
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **کلاس‌های تبدیل ویدیو**

برای انجام وظایف تبدیل PowerPoint به ویدیو، Aspose.Slides کلاس‌های [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_animations_generator/) و [PresentationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_player/) را ارائه می‌دهد.

PresentationAnimationsGenerator به شما اجازه می‌دهد اندازه فریم برای ویدیو (که سپس ایجاد می‌شود) را از طریق سازنده‌اش تنظیم کنید. اگر یک نمونه از ارائه را پاس کنید، `Presentation.SlideSize` استفاده خواهد شد و انیمیشن‌هایی را تولید می‌کند که [PresentationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_player/) از آن‌ها استفاده می‌کند. 

هنگام تولید انیمیشن‌ها، برای هر انیمیشن بعدی یک رویداد `NewAnimation` تولید می‌شود که پارامتر [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.i_presentation_animation_player/) دارد. این پارامتر کلاسی است که پخش‌کننده‌ای برای یک انیمیشن جداگانه را نشان می‌دهد.

برای کار با [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.i_presentation_animation_player/)، از ویژگی [get_Duration](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (مدت کامل انیمیشن) و متد [SetTimePosition](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) استفاده می‌شود. هر موقعیت انیمیشن در بازه *۰ تا مدت* تنظیم می‌شود و سپس متد `GetFrame` یک Bitmap بر می‌گرداند که به وضعیت انیمیشن در آن لحظه متناظر است.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // حالت اولیه انیمیشن
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // بیت‌مپ حالت اولیه انیمیشن

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // حالت نهایی انیمیشن
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // فریم آخر انیمیشن
    lastBitmap->Save(u"last.png");
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

برای پخش همزمان تمام انیمیشن‌های یک ارائه، کلاس [PresentationPlayer](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_player/) استفاده می‌شود. این کلاس یک نمونه از [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.presentation_animations_generator/) و FPS اثرها را در سازنده‌اش گرفته و سپس برای همه انیمیشن‌ها رویداد `FrameTick` را فراخوانی می‌کند تا آن‌ها پخش شوند:

```c++
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

سپس فریم‌های تولید شده می‌توانند برای تولید ویدیو ترکیب شوند. بخش [تبدیل PowerPoint به ویدیو](https://docs.aspose.com/slides/fa/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) را ببینید.

## **انیمیشن‌ها و افکت‌های پشتیبانی شده**


**ورودی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |


**تاکید**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**خروج**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**مسیرهای حرکتی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **سوالات متداول**

**آیا می‌توان ارائه‌های محافظت‌شده با رمز عبور را تبدیل کرد؟**

بله، Aspose.Slides امکان کار با [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/cpp/password-protected-presentation/) را فراهم می‌کند. هنگام پردازش چنین فایل‌هایی، باید رمز عبور صحیح را ارائه دهید تا کتابخانه بتواند به محتوای ارائه دسترسی پیدا کند.

**آیا Aspose.Slides از استفاده در راه‌حل‌های ابری پشتیبانی می‌کند؟**

بله، Aspose.Slides می‌تواند در برنامه‌ها و سرویس‌های ابری یکپارچه شود. این کتابخانه برای کار در محیط‌های سروری طراحی شده است و عملکرد بالا و مقیاس‌پذیری را برای پردازش دسته‌ای فایل‌ها تضمین می‌کند.

**آیا محدودیت حجمی برای ارائه‌ها هنگام تبدیل وجود دارد؟**

Aspose.Slides می‌تواند تقریباً هر اندازه‌ای از ارائه‌ها را مدیریت کند. با این حال، هنگام کار با فایل‌های بسیار بزرگ، ممکن است به منابع سیستم اضافی نیاز باشد و گاهی توصیه می‌شود ارائه را بهینه کنید تا عملکرد بهبود یابد.