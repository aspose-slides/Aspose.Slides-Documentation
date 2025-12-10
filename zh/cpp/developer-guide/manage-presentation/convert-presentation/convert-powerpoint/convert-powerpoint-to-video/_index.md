---
title: 在 C++ 中将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 到视频
type: docs
weight: 130
url: /zh/cpp/convert-powerpoint-to-video/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换 PPT
- 转换 PPTX
- PowerPoint 到视频
- 演示文稿到视频
- PPT 到视频
- PPTX 到视频
- PowerPoint 到 MP4
- 演示文稿到 MP4
- PPT 到 MP4
- PPTX 到 MP4
- 将 PPT 保存为 MP4
- 将 PPTX 保存为 MP4
- 导出 PPT 为 MP4
- 导出 PPTX 为 MP4
- 视频转换
- PowerPoint
- C++
- Aspose.Slides
description: "了解如何在 C++ 中将 PowerPoint 演示文稿转换为视频。发现示例代码和自动化技术，以简化您的工作流程。"
---

## **概述**

通过将 PowerPoint 演示文稿转换为视频，您可以获得 

* **可访问性提升：** 与演示文稿打开应用程序相比，所有设备（无论平台）默认都配备视频播放器，用户打开或播放视频更为便捷。
* **覆盖范围更广：** 通过视频，您可以触达更大的受众，并向他们传递在演示文稿中可能显得冗长的信息。大多数调查和统计数据显示，人们观看和消费视频的比例高于其他形式的内容，且普遍更喜欢此类内容。

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/) 中，我们实现了对演示文稿转视频的支持。 

* 使用 Aspose.Slides 生成一组对应于特定 FPS（每秒帧数）的帧（来自演示文稿的幻灯片）
* 使用第三方工具如 `ffmpeg` 根据这些帧创建视频。

## **将 PowerPoint 演示文稿转换为视频**

1. 在 [此处](https://ffmpeg.org/download.html) 下载 ffmpeg。
2. 将 `ffmpeg.exe` 的路径添加到环境变量 `PATH`。
3. 运行 PowerPoint 转视频代码。

下面的 C++ 代码演示了如何将包含图形和两个动画效果的演示文稿转换为视频：
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

    // 添加笑脸形状并进行动画
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

您可以对幻灯片上的对象应用动画，并在幻灯片之间使用转场。

{{% alert color="primary" %}} 

您可能想查看以下文章： [PowerPoint 动画](https://docs.aspose.com/slides/cpp/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/cpp/shape-animation/) 和 [形状效果](https://docs.aspose.com/slides/cpp/shape-effect/)。

{{% /alert %}} 

动画和转场让幻灯片放映更具吸引力和趣味性——对视频同样适用。让我们为前面演示文稿的代码再添加一个幻灯片和转场：
```c++
// 添加笑脸形状并进行动画

// ...

// 添加新幻灯片并设置动画过渡

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


Aspose.Slides 也支持文本动画。因此我们对对象上的段落进行动画，使其依次出现（延迟设为一秒）：
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

为方便您执行 PowerPoint 转视频任务，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) 类。

PresentationAnimationsGenerator 允许您通过构造函数设置视频（稍后将生成）的帧尺寸。如果传入演示文稿实例，则使用 `Presentation.SlideSize`，并生成供 [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) 使用的动画。 

生成动画时，会为每个后续动画触发 `NewAnimation` 事件，该事件携带 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) 参数。后者是表示单独动画播放器的类。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)，需要使用其 [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91)（动画的完整持续时间）属性和 [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) 方法。每个动画位置都在 *0 到 duration* 范围内设置，然后 `GetFrame` 方法将返回对应于该时刻动画状态的 Bitmap。
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

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

    // 添加笑脸形状并进行动画
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


要让演示文稿中的所有动画同时播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) 实例和效果的 FPS，然后调用 `FrameTick` 事件以获取并播放所有动画：
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


随后生成的帧可编译为视频。参见 [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**


**进入（Entrance）**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出现** | ![不支持](x.png) | ![支持](v.png) |
| **淡入** | ![支持](v.png) | ![支持](v.png) |
| **飞入** | ![支持](v.png) | ![支持](v.png) |
| **浮入** | ![支持](v.png) | ![支持](v.png) |
| **分割** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **轮盘** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **增长并转动** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |


**强调（Emphasis）**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉冲** | ![不支持](x.png) | ![支持](v.png) |
| **颜色脉冲** | ![不支持](x.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **旋转** | ![支持](v.png) | ![支持](v.png) |
| **放大/缩小** | ![不支持](x.png) | ![支持](v.png) |
| **去饱和** | ![不支持](x.png) | ![支持](v.png) |
| **加暗** | ![不支持](x.png) | ![支持](v.png) |
| **加亮** | ![不支持](x.png) | ![支持](v.png) |
| **透明度** | ![不支持](x.png) | ![支持](v.png) |
| **对象颜色** | ![不支持](x.png) | ![支持](v.png) |
| **互补颜色** | ![不支持](x.png) | ![支持](v.png) |
| **线条颜色** | ![不支持](x.png) | ![支持](v.png) |
| **填充颜色** | ![不支持](x.png) | ![支持](v.png) |

**退出（Exit）**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![不支持](x.png) | ![支持](v.png) |
| **淡出** | ![支持](v.png) | ![支持](v.png) |
| **飞出** | ![支持](v.png) | ![支持](v.png) |
| **浮出** | ![支持](v.png) | ![支持](v.png) |
| **分割** | ![支持](v.png) | ![支持](v.png) |
| **擦除** | ![支持](v.png) | ![支持](v.png) |
| **形状** | ![支持](v.png) | ![支持](v.png) |
| **随机条** | ![支持](v.png) | ![支持](v.png) |
| **收缩并转动** | ![不支持](x.png) | ![支持](v.png) |
| **缩放** | ![支持](v.png) | ![支持](v.png) |
| **摇摆** | ![支持](v.png) | ![支持](v.png) |
| **弹跳** | ![支持](v.png) | ![支持](v.png) |

**运动路径（Motion Paths）**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **直线** | ![支持](v.png) | ![支持](v.png) |
| **弧线** | ![支持](v.png) | ![支持](v.png) |
| **转折** | ![支持](v.png) | ![支持](v.png) |
| **形状路径** | ![支持](v.png) | ![支持](v.png) |
| **循环** | ![支持](v.png) | ![支持](v.png) |
| **自定义路径** | ![支持](v.png) | ![支持](v.png) |

## **常见问题 (FAQ)**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides 支持处理 [受密码保护的演示文稿](/slides/zh/cpp/password-protected-presentation/)。在处理此类文件时，需要提供正确的密码，以便库能够访问演示文稿内容。

**Aspose.Slides 是否支持在云解决方案中使用？**

是的，Aspose.Slides 可集成到云应用和服务中。该库专为服务器环境设计，能够在批量文件处理时提供高性能和可伸缩性。

**在转换过程中对演示文稿的大小有限制吗？**

Aspose.Slides 能够处理几乎任意大小的演示文稿。不过，在处理非常大的文件时，可能需要额外的系统资源，通常建议对演示文稿进行优化以提升性能。