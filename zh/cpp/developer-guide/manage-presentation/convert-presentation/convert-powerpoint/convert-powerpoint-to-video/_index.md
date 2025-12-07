---
title: 在 C++ 中将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/cpp/convert-powerpoint-to-video/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 PPT
- 转换 PPTX
- PowerPoint 转视频
- 演示文稿 转视频
- PPT 转视频
- PPTX 转视频
- PowerPoint 转 MP4
- 演示文稿 转 MP4
- PPT 转 MP4
- PPTX 转 MP4
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

将 PowerPoint 演示文稿转换为视频后，您可以获得  

* **可访问性提升:** 与演示文稿打开应用程序相比，所有设备（无论平台）默认都配备了视频播放器，用户更容易打开或播放视频。  
* **覆盖范围更广:** 通过视频，您可以接触更大的受众，并向他们传递在演示文稿中可能显得枯燥的信息。大多数调查和统计数据显示，人们观看和消费视频的频率高于其他形式的内容，并且普遍更喜欢此类内容。

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/)，我们实现了对演示文稿转视频的支持。  

* 使用 Aspose.Slides 生成一组对应特定 FPS（每秒帧数）的帧（来源于演示文稿的幻灯片）  
* 使用第三方工具如 `ffmpeg` 基于这些帧创建视频  

## **将 PowerPoint 演示文稿转换为视频**

1. 在[此处](https://ffmpeg.org/download.html)下载 ffmpeg。  
2. 将 `ffmpeg.exe` 的路径添加到环境变量 `PATH` 中。  
3. 运行 PowerPoint 转视频的代码。

以下 C++ 代码演示了如何将包含图形和两个动画效果的演示文稿转换为视频：
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

    // 添加一个笑脸形状并对其进行动画处理
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

您可以对幻灯片上的对象应用动画，并在幻灯片之间使用切换效果。

{{% alert color="primary" %}} 

您可能想查看以下文章: [PowerPoint 动画](https://docs.aspose.com/slides/cpp/powerpoint-animation/)、[形状动画](https://docs.aspose.com/slides/cpp/shape-animation/)，以及 [形状效果](https://docs.aspose.com/slides/cpp/shape-effect/)。 

{{% /alert %}} 

动画和切换使幻灯片放映更具吸引力和趣味性——它们对视频同样适用。让我们为前面的演示文稿的代码添加另一张幻灯片和切换效果：
```c++
// 添加一个笑脸形状并对其进行动画处理

// ...

// 添加新幻灯片并设置动画切换

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


Aspose.Slides 还支持文本动画。因此我们在对象上为段落添加动画，使其依次出现（延迟设为一秒）：
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

为了让您能够执行 PowerPoint 到视频的转换任务，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) 类。

PresentationAnimationsGenerator 通过构造函数允许您设置稍后将创建的视频的帧大小。如果传入演示文稿实例，则使用 `Presentation.SlideSize`，并生成供 [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) 使用的动画。

生成动画时，会为每个后续动画触发 `NewAnimation` 事件，并携带 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) 参数。后者是表示单独动画播放器的类。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)，需要使用 [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91)（动画的完整时长）属性和 [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) 方法。每个动画位置设置在 *0 到 duration* 范围内，然后 `GetFrame` 方法将返回对应该时刻动画状态的 Bitmap。
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

    // 添加笑脸形状并为其添加动画
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


为了让演示文稿中的所有动画一次性播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) 实例和效果的 FPS，然后为所有动画调用 `FrameTick` 事件以实现播放：
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


随后可以将生成的帧编译成视频。请参阅 [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**

**进入**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![不受支持](x.png) | ![受支持](v.png) |
| **Fade** | ![受支持](v.png) | ![受支持](v.png) |
| **Fly In** | ![受支持](v.png) | ![受支持](v.png) |
| **Float In** | ![受支持](v.png) | ![受支持](v.png) |
| **Split** | ![受支持](v.png) | ![受支持](v.png) |
| **Wipe** | ![受支持](v.png) | ![受支持](v.png) |
| **Shape** | ![受支持](v.png) | ![受支持](v.png) |
| **Wheel** | ![受支持](v.png) | ![受支持](v.png) |
| **Random Bars** | ![受支持](v.png) | ![受支持](v.png) |
| **Grow & Turn** | ![不受支持](x.png) | ![受支持](v.png) |
| **Zoom** | ![受支持](v.png) | ![受支持](v.png) |
| **Swivel** | ![受支持](v.png) | ![受支持](v.png) |
| **Bounce** | ![受支持](v.png) | ![受支持](v.png) |

**强调**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![不受支持](x.png) | ![受支持](v.png) |
| **Color Pulse** | ![不受支持](x.png) | ![受支持](v.png) |
| **Teeter** | ![受支持](v.png) | ![受支持](v.png) |
| **Spin** | ![受支持](v.png) | ![受支持](v.png) |
| **Grow/Shrink** | ![不受支持](x.png) | ![受支持](v.png) |
| **Desaturate** | ![不受支持](x.png) | ![受支持](v.png) |
| **Darken** | ![不受支持](x.png) | ![受支持](v.png) |
| **Lighten** | ![不受支持](x.png) | ![受支持](v.png) |
| **Transparency** | ![不受支持](x.png) | ![受支持](v.png) |
| **Object Color** | ![不受支持](x.png) | ![受支持](v.png) |
| **Complementary Color** | ![不受支持](x.png) | ![受支持](v.png) |
| **Line Color** | ![不受支持](x.png) | ![受支持](v.png) |
| **Fill Color** | ![不受支持](x.png) | ![受支持](v.png) |

**退出**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![不受支持](x.png) | ![受支持](v.png) |
| **Fade** | ![受支持](v.png) | ![受支持](v.png) |
| **Fly Out** | ![受支持](v.png) | ![受支持](v.png) |
| **Float Out** | ![受支持](v.png) | ![受支持](v.png) |
| **Split** | ![受支持](v.png) | ![受支持](v.png) |
| **Wipe** | ![受支持](v.png) | ![受支持](v.png) |
| **Shape** | ![受支持](v.png) | ![受支持](v.png) |
| **Random Bars** | ![受支持](v.png) | ![受支持](v.png) |
| **Shrink & Turn** | ![不受支持](x.png) | ![受支持](v.png) |
| **Zoom** | ![受支持](v.png) | ![受支持](v.png) |
| **Swivel** | ![受支持](v.png) | ![受支持](v.png) |
| **Bounce** | ![受支持](v.png) | ![受支持](v.png) |

**运动路径**

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![受支持](v.png) | ![受支持](v.png) |
| **Arcs** | ![受支持](v.png) | ![受支持](v.png) |
| **Turns** | ![受支持](v.png) | ![受支持](v.png) |
| **Shapes** | ![受支持](v.png) | ![受支持](v.png) |
| **Loops** | ![受支持](v.png) | ![受支持](v.png) |
| **Custom Path** | ![受支持](v.png) | ![受支持](v.png) |

## **常见问题**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides 支持处理[受密码保护的演示文稿](/slides/zh/cpp/password-protected-presentation/)。处理此类文件时，需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides 是否支持在云解决方案中使用？**

是的，Aspose.Slides 可集成到云应用和服务中。该库专为服务器环境设计，确保在批量文件处理时具备高性能和可伸缩性。

**在转换过程中对演示文稿的大小有任何限制吗？**

Aspose.Slides 能够处理几乎任意大小的演示文稿。不过，处理非常大的文件时可能需要更多系统资源，建议在必要时对演示文稿进行优化以提升性能。