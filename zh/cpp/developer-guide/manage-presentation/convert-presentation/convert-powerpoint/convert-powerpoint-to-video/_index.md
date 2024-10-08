---
title: 将PowerPoint转换为视频
type: docs
weight: 130
url: /cpp/convert-powerpoint-to-video/
keywords: "将PowerPoint转换为视频, PPT, PPTX, 演示文稿, 视频, MP4, PPT转视频, PPT转MP4, C++, Aspose.Slides"
description: "使用Aspose.Slides for C++ API将PowerPoint转换为视频"
---

通过将PowerPoint演示文稿转换为视频，您可以获得

* **提高可访问性：** 与需要打开演示文稿的应用程序相比，所有设备（无论平台）默认都配备有视频播放器，因此用户更容易打开或播放视频。
* **更广泛的受众：** 通过视频，您可以接触到更大的人群，并用可能在演示中看起来无聊的信息进行目标定位。大多数调查和统计数据显示，人们观看和消费视频的频率高于其他形式的内容，他们通常更喜欢这种内容。

## **Aspose.Slides中的PowerPoint到视频转换**

在[Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/)中，我们实现了演示文稿转换为视频的支持。

* 使用Aspose.Slides生成一组与特定FPS（每秒帧数）对应的帧（来自演示文稿幻灯片）。
* 使用像`ffmpeg`这样的第三方实用程序根据这些帧创建视频。

### **将PowerPoint转换为视频**

1. 在[这里](https://ffmpeg.org/download.html)下载ffmpeg。
2. 将`ffmpeg.exe`的路径添加到环境变量`PATH`中。
3. 运行PowerPoint到视频的代码。

以下C++代码展示了如何将包含图形和两个动画效果的演示文稿转换为视频：

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

    // 添加笑脸形状然后对其进行动画处理
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

## **视频效果**

您可以对幻灯片上的对象应用动画，并在幻灯片之间使用过渡效果。

{{% alert color="primary" %}} 

您可能想查看以下文章：[PowerPoint动画](https://docs.aspose.com/slides/cpp/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/cpp/shape-animation/)和[形状效果](https://docs.aspose.com/slides/cpp/shape-effect/)。

{{% /alert %}} 

动画和过渡使幻灯片演示更具吸引力和趣味性——它们在视频中也发挥着同样的作用。让我们为之前的演示添加另一张幻灯片和过渡：

```c++
// 添加笑脸形状并对其进行动画处理

// ...

// 添加新幻灯片和动画过渡

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides还支持文本动画。因此我们将段落进行动画处理，使其逐个出现（设置延迟为一秒）：

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

    // 添加文本和动画
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"带文本的PowerPoint演示文稿转换为视频"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"逐段出现"));
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

    // 将帧转换为视频
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

## **视频转换类**

为了让您能够执行PowerPoint到视频转换任务，Aspose.Slides提供了[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/)和[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/)类。

PresentationAnimationsGenerator允许您通过其构造函数设置视频的帧大小（随后将创建）。如果您传递一个演示文稿实例，则将使用`Presentation.SlideSize`，并生成[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/)使用的动画。

当动画生成时，会为每个后续动画生成一个`NewAnimation`事件，其中具有[IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)参数。后者是表示单独动画播放器的类。

要与[IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)一起工作，使用[get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91)（动画的总持续时间）属性和[SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0)方法。每个动画位置在*0到持续时间*范围内设置，然后`GetFrame`方法将返回与该时刻动画状态相对应的Bitmap。

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"总动画时长：{0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // 初始动画状态
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // 初始动画状态位图

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // 动画的最终状态
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // 动画的最后一帧
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 添加笑脸形状并对其进行动画处理
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

要使演示文稿中的所有动画同时播放，使用[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/)类。该类在其构造函数中采用[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/)实例和效果的FPS，然后调用`FrameTick`事件以使所有动画播放：

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

然后可以将生成的帧编译以产生视频。请参见[将PowerPoint转换为视频](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video)部分。

## **支持的动画和效果**


**进入**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出现** | ![不支持](x.png) | ![支持](v.png) |
| **淡入** | ![支持](v.png) | ![支持](v.png) |
| **飞入** | ![支持](v.png) | ![支持](v.png) |
| **漂浮进入** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **轮子** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **增长与转动** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |


**强调**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉动** | ![不支持](x.png) | ![支持](v.png) |
| **颜色脉动** | ![不支持](x.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **增大/缩小** | ![不支持](x.png) | ![支持](v.png) |
| **去饱和** | ![不支持](x.png) | ![支持](v.png) |
| **变暗** | ![不支持](x.png) | ![支持](v.png) |
| **变亮** | ![不支持](x.png) | ![支持](v.png) |
| **透明度** | ![不支持](x.png) | ![支持](v.png) |
| **对象颜色** | ![不支持](x.png) | ![支持](v.png) |
| **互补颜色** | ![不支持](x.png) | ![支持](v.png) |
| **线条颜色** | ![不支持](x.png) | ![支持](v.png) |
| **填充颜色** | ![不支持](x.png) | ![支持](v.png) |

**退出**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![不支持](x.png) | ![支持](v.png) |
| **淡出** | ![支持](v.png) | ![支持](v.png) |
| **飞出** | ![支持](v.png) | ![支持](v.png) |
| **漂浮退出** | ![支持](v.png) | ![支持](v.png) |
| **分裂** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **缩小与转动** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |

**运动路径：**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **线条** | ![支持](v.png) | ![支持](v.png) |
| **弧线** | ![支持](v.png) | ![支持](v.png) |
| **转弯** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **循环** | ![支持](v.png) | ![支持](v.png) |
| **自定义路径** | ![支持](v.png) | ![支持](v.png) |