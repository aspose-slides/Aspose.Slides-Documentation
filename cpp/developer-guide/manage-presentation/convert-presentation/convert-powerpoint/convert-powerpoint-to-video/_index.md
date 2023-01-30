---
title: Convert PowerPoint to Video
type: docs
weight: 130
url: /cpp/convert-powerpoint-to-video/
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Video, MP4, PPT to video, PPT to MP4, C++, Aspose.Slides"
description: "Convert PowerPoint to Video with Aspose.Slides for C++ API"
---

By converting your PowerPoint presentation to video, you get 

* **Increase in accessibility:** All devices (regardless of platform) are equipped with video players by default compared to presentation-opening applications, so users find it easier to open or play videos.
* **More reach:** Through videos, you can reach a large audience and target them with information that might otherwise seem tedious in a presentation. Most surveys and statistics suggest that people watch and consume videos more than other forms of content, and they generally prefer such content.

## **PowerPoint to Video Conversion in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), we implemented support for presentation to video conversion. 

* Use Aspose.Slides to generate a set of frames (from the presentation slides) that correspond to a certain FPS (frames per second)
* Use a third-party utility like `ffmpeg` to create a video based on the frames.

### **Convert PowerPoint to Video**

1. Download ffmpeg [here](https://ffmpeg.org/download.html).
2. Add path to `ffmpeg.exe` to environment variable `PATH`.
3. Run the PowerPoint to video code.

This C++ code shows you how to convert a presentation (containing a figure and two animation effects) to a video:

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

    // Adds a smile shape and then animates it
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    System::SharedPtr<IEffect> effectIn = slide->get_Timeline()->get_MainSequence()->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = slide->get_Timeline()->get_MainSequence()->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
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

## **Video Effects**

You can apply animations to objects on slides and use transitions between slides.

{{% alert color="primary" %}} 

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cpp/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting—and they do the same thing for videos. Let's add another slide and transition to the code for the previous presentation:

```c++
// Adds a smile shape and animates it

// ...

// Adds a new slide and animated transition

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

slideBackground->get_FillFormat()->set_FillType(FillType::Solid);

slideBackground->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides also supports animation for texts. So we animate paragraphs on objects, which will appear one after the other (with the delay set to a second):

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

    // Adds text and animations
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    autoShape->get_TextFrame()->get_Paragraphs()->Add(para1);
    autoShape->get_TextFrame()->get_Paragraphs()->Add(para2);
    autoShape->get_TextFrame()->get_Paragraphs()->Add(para3);
    autoShape->get_TextFrame()->get_Paragraphs()->Add(System::MakeObject<Paragraph>());

    System::SharedPtr<IEffect> effect = slide->get_Timeline()->get_MainSequence()->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = slide->get_Timeline()->get_MainSequence()->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = slide->get_Timeline()->get_MainSequence()->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = slide->get_Timeline()->get_MainSequence()->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // Converts frames to video
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

## **Video Conversion Classes**

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) and [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) classes.

PresentationAnimationsGenerator allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation.SlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) uses. 

When animations are generated, a `NewAnimation` event is generated for each subsequent animation, which has the [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) parameter. The latter is a class that represents a player for a separate animation.

To work with [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/), the [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (the full duration of the animation) property and [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) method are used. Each animation position is set within the *0 to duration* range, and then the `GetFrame` method will return a Bitmap that corresponds to the animation state at that moment.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // initial animation state
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // initial animation state bitmap

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // final state of the animation
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // last frame of the animation
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adds a smile shape and animates it
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    System::SharedPtr<IEffect> effectIn = slide->get_Timeline()->get_MainSequence()->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = slide->get_Timeline()->get_MainSequence()->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

Then the generated frames can be compiled to produce a video. See the [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) section.

## **Supported Animations and Effects**


**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
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


**Emphasis**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Exit**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Motion Paths:**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |
