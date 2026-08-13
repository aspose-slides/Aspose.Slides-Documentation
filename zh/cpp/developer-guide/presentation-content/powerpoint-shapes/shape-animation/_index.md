---
title: 使用 C++ 在演示文稿中应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/cpp/shape-animation/
keywords:
- 形状
- 动画
- 效果
- 动画形状
- 动画文本
- 添加动画
- 获取动画
- 提取动画
- 添加效果
- 获取效果
- 提取效果
- 效果声音
- 应用动画
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中创建和自定义形状动画。脱颖而出！"
---
## **介绍**

动画是可以应用于文本、图像、形状或[图表](/slides/zh/cpp/animated-charts/)的视觉效果。它们为演示文稿或其组成部分赋予活力。

## **为什么在演示文稿中使用动画？**

使用动画，您可以  

* 控制信息流  
* 强调重要要点  
* 提高观众的兴趣或参与度  
* 使内容更容易阅读、理解或处理  
* 将读者或观众的注意力引导到演示文稿中的重要部分  

PowerPoint 在 **进入**、**退出**、**强调** 和 **运动路径** 类别中提供了许多动画选项和工具。

## **Aspose.Slides 中的动画**

* Aspose.Slides 提供了在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/zh/cpp/namespace/aspose.slides.animation) 命名空间下处理动画所需的类和类型，  
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/zh/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 枚举下提供超过 **150** 种动画效果。这些效果本质上与 PowerPoint 中使用的效果相同（或等效）。

## **将动画应用于文本框**

Aspose.Slides for C++ 允许您对形状中的文本应用动画。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_auto_shape)。  
4. 向[IAutoShape.TextFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) 添加文本。  
5. 获取主效果序列。  
6. 向[IAutoShape](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_auto_shape) 添加动画效果。  
7. 将 [TextAnimation.BuildType](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) 属性设置为来自 [BuildType Enumeration](https://reference.aspose.com/slides/zh/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) 的值。  
8. 将演示文稿写入磁盘为 PPTX 文件。

以下 C++ 代码演示了如何将 `Fade` 效果应用于 AutoShape 并将文本动画设置为 *By 1st Level Paragraphs* 值：

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加带文本的新 AutoShape
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// 获取幻灯片的主序列。
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// 为形状添加 Fade 动画效果
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 按一级段落对形状文本进行动画化
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// 将 PPTX 文件保存到磁盘
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

除了对文本应用动画外，您还可以对单个[段落](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_paragraph)应用动画。请参阅[**Animated Text**](/slides/zh/cpp/animated-text/)。

{{% /alert %}} 

## **将动画应用于 PictureFrame**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_picture_frame)。  
4. 获取主效果序列。  
5. 向 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_picture_frame) 添加动画效果。  
6. 将演示文稿写入磁盘为 PPTX 文件。

以下 C++ 代码演示了如何将 `Fly` 效果应用于图片框：

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 加载要添加到演示文稿图像集合的图像
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// 向幻灯片添加图片框
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// 获取幻灯片的主序列。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 为图片框添加从左侧飞入的动画效果
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 将 PPTX 文件保存到磁盘
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **将动画应用于形状**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_auto_shape)。  
4. 添加一个 `Bevel` [IAutoShape]（当单击此对象时，动画将播放）。  
5. 为 bevel 形状创建效果序列。  
6. 创建自定义 `UserPath`。  
7. 添加移动到 `UserPath` 的命令。  
8. 将演示文稿写入磁盘为 PPTX 文件。

以下 C++ 代码演示了如何将 `PathFootball`（路径足球）效果应用于形状：

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// 文档目录的路径。
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 加载演示文稿
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 访问所选幻灯片的形状集合
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 从头创建现有形状的 PathFootball 效果。
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// 添加 PathFootBall 动画效果
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// 创建某种“按钮”。
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// 为此按钮创建一系列效果。
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // 创建自定义用户路径。我们的对象仅在按钮被点击后移动。
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// 添加移动命令，因为创建的路径为空。
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // 将 PPTX 文件写入磁盘
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **获取应用于形状的动画效果**

以下示例展示了如何使用来自 [ISequence](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/isequence/) 接口的 `GetEffectsByShape` 方法获取应用于形状的所有动画效果。

**示例 1：获取在普通幻灯片上应用于形状的动画效果**

之前，您已经学习了如何向 PowerPoint 演示文稿中的形状添加动画效果。以下示例代码展示了如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状所应用的效果。

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// 获取幻灯片的主动画序列。
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// 获取第一张幻灯片上的第一个形状。
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// 获取应用于该形状的动画效果。
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**示例 2：获取所有动画效果，包括从占位符继承的效果**

如果普通幻灯片上的形状具有位于版式幻灯片和/或母版幻灯片上的占位符，并且这些占位符已添加动画效果，则在放映期间该形状的所有效果都会播放，包括从占位符继承的效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中唯一的一张幻灯片仅包含一个页脚形状，文本为 “Made with Aspose.Slides”，并且已对该形状应用 **Random Bars** 效果。

![幻灯片形状动画效果](slide-shape-animation.png)

再假设在 **布局** 幻灯片的页脚占位符上已应用 **Split** 效果。

![布局形状动画效果](layout-shape-animation.png)

最后，在 **母版** 幻灯片的页脚占位符上已应用 **Fly In** 效果。

![母版形状动画效果](master-shape-animation.png)

以下示例代码展示了如何使用来自 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ishape/) 接口的 `GetBasePlaceholder` 方法访问形状占位符，并获取应用于页脚形状的动画效果，包括从布局和母版幻灯片上的占位符继承的效果。

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 获取普通幻灯片上形状的动画效果。
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// 获取版式幻灯片上占位符的动画效果。
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// 获取母版幻灯片上占位符的动画效果。
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // 飞入, 底部
Type: 134, subtype: 45            // 分割, 垂直进入
Type: 126, subtype: 22            // 随机条纹, 水平
```

## **更改动画效果时间属性**

Aspose.Slides for C++ 允许您更改动画效果的 Timing 属性。

以下是 Microsoft PowerPoint 中的动画时间窗格：

![动画时间窗格](shape-animation.png)

以下是 PowerPoint Timing 与 [Effect.Timing](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) 属性之间的对应关系：

- PowerPoint Timing **Start** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) 属性。  
- PowerPoint Timing **Duration** 对应 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) 属性。动画的时长（以秒为单位）是动画完成一次循环所需的总时间。  
- PowerPoint Timing **Delay** 对应 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) 属性。  

以下是更改 Effect Timing 属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。  
2. 为您需要的 [Effect.Timing](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) 属性设置新值。  
3. 保存修改后的 PPTX 文件。  

以下 C++ 代码演示了此操作：

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// 获取幻灯片的主序列。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 获取主序列的第一个效果。
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// 将效果的 TriggerType 更改为点击开始
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 将效果的 Duration 更改为 3 秒
effect->get_Timing()->set_Duration(3.f);

// 将效果的 TriggerDelayTime 更改为 0.5 秒
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// 将 PPTX 文件保存到磁盘
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **动画效果声音**

Aspose.Slides 提供以下属性，以便您在动画效果中使用声音：

- [set_Sound()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/effect/set_stopprevioussound/)  

### **添加动画效果声音**

以下 C++ 代码演示了如何添加动画效果声音并在下一个效果开始时停止它：

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// 向演示文稿的音频集合添加音频
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 获取幻灯片的主序列。
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// 获取主序列的第一个效果
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// 检查效果是否没有声音
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // 为第一个效果添加声音
    firstEffect->set_Sound(effectSound);
}

// 获取幻灯片的第一个交互序列。
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// 设置效果的 “停止先前声音” 标志
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// 将 PPTX 文件写入磁盘
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **提取动画效果声音**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 获取主效果序列。  
4. 提取每个动画效果中嵌入的 [set_Sound()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/effect/set_sound/) 。

以下 C++ 代码演示了如何提取嵌入在动画效果中的声音：

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **动画后**

Aspose.Slides for C++ 允许您更改动画效果的 After animation 属性。

以下是 Microsoft PowerPoint 中的动画效果窗格和扩展菜单：

![动画效果窗格和扩展菜单](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉列表对应以下属性：

- [set_AfterAnimationType()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) 属性，用于描述 After animation 类型：
  * PowerPoint **More Colors** 对应 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/afteranimationtype/) 类型；  
  * PowerPoint **Don't Dim** 项对应 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/afteranimationtype/) 类型（默认 After animation 类型）；  
  * PowerPoint **Hide After Animation** 项对应 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/afteranimationtype/) 类型；  
  * PowerPoint **Hide on Next Mouse Click** 项对应 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/afteranimationtype/) 类型；  
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) 属性，用于定义 After animation 的颜色格式。此属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/afteranimationtype/) 类型配合使用。如果将类型更改为其他类型，After animation 颜色将被清除。  

以下 C++ 代码演示了如何更改 After animation 效果：

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// 实例化一个表示演示文稿文件的 Presentation 类
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 获取主序列的第一个效果
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// 将 After animation 类型更改为 Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// 设置 After animation 的暗淡颜色
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// 将 PPTX 文件写入磁盘
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **动画文本**

Aspose.Slides 提供以下属性，以便您使用动画效果的 *Animate text* 块：

- [set_AnimateTextType()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 用于描述动画文本的类型。形状文本可以按以下方式动画化：
  - 一次性全部 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/animatetexttype/) 类型)  
  - 按单词 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/animatetexttype/) 类型)  
  - 按字母 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/animatetexttype/) 类型)  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 设置动画文本片段（单词或字母）之间的延迟。正值表示效果时长的百分比，负值表示以秒为单位的延迟。  

以下是更改 Effect Animate text 属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。  
2. 将 [set_BuildType()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation.itextanimation/set_buildtype/) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/buildtype/) 值，以关闭 *By Paragraphs* 动画模式。  
3. 为 [set_AnimateTextType()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 和 [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 属性设置新值。  
4. 保存修改后的 PPTX 文件。  

以下 C++ 代码演示了此操作：

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 获取主序列的第一个效果
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// 将效果的文本动画类型更改为 "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// 将效果的动画文本类型更改为 "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// 将单词之间的延迟设置为效果时长的 20%
firstEffect->set_DelayBetweenTextParts(20.0f);

// 将 PPTX 文件写入磁盘
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### 如何确保在将演示文稿发布到 Web 时保留动画？

[Export to HTML5](/slides/zh/cpp/export-to-html5/) 并启用负责 [shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [transition](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/html5options/set_animatetransitions/) 动画的[options](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/html5options/) 。普通 HTML 不会播放幻灯片动画，而 HTML5 会。

### 更改形状的 z‑order（图层顺序）如何影响动画？

动画顺序和绘制顺序是独立的：效果控制出现/消失的时机和类型，而 [z-order](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/get_zorderposition/) 决定哪些覆盖哪些。最终可见结果由两者的组合决定。（这是 PowerPoint 的通用行为，Aspose.Slides 的效果与形状模型遵循相同逻辑。）

### 将动画转换为视频时某些效果是否存在限制？

一般来说，[动画受支持](/slides/zh/cpp/convert-powerpoint-to-video/)，但少数情况或特定效果可能呈现不同。建议使用您所用的效果和库版本进行测试。