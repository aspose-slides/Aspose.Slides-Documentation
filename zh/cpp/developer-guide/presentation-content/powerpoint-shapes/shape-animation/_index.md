---
title: 在演示文稿中使用 C++ 应用形状动画
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

动画是可应用于文本、图像、形状或[图表](/slides/zh/cpp/animated-charts/)的视觉效果。它们为演示文稿或其组成部分赋予活力。

## **为什么在演示文稿中使用动画？**

* 控制信息流
* 强调重要要点
* 增加观众的兴趣或参与度
* 使内容更易于阅读、吸收或处理
* 吸引读者或观众注意演示文稿中的重要部分

PowerPoint 在 **进入**、**退出**、**强调**和**运动路径**类别中提供了许多动画选项和工具。

## **Aspose.Slides 中的动画**

* Aspose.Slides 在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) 命名空间下提供了处理动画所需的类和类型，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 枚举中提供了超过 **150** 种动画效果。这些效果本质上与 PowerPoint 中使用的效果相同（或等价）。

## **将动画应用于文本框**

Aspose.Slides for C++ 允许您对形状中的文本应用动画。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)。
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) 添加文本。
5. 获取主效果序列。
6. 向 [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) 添加动画效果。
7. 将 [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) 属性设置为来自 [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) 的值。
8. 将演示文稿写入磁盘，保存为 PPTX 文件。

以下 C++ 代码演示如何将 `Fade` 效果应用于 AutoShape 并将文本动画设置为 *By 1st Level Paragraphs* 值：
```c++
// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert color="primary"  %}} 
除了对文本应用动画之外，您还可以对单个[段落](/slides/zh/cpp/animated-text/)应用动画。请参阅[**动画文本**](/slides/zh/cpp/animated-text/)。
{{% /alert %}} 

## **将动画应用于图片框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame)。
4. 获取主效果序列。
5. 向 [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) 添加动画效果。
6. 将演示文稿写入磁盘，保存为 PPTX 文件。

以下 C++ 代码演示如何将 `Fly` 效果应用于图片框：
```c++
// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 加载要添加到演示文稿图像集合中的图像
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// 向幻灯片添加图片框
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// 获取幻灯片的主效果序列。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 向图片框添加从左侧飞入的动画效果
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 将 PPTX 文件保存到磁盘
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **将动画应用于形状**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。
2 .通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)。
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)（点击此对象时播放动画）。
5. 为 bevel 形状创建效果序列。
6. 创建自定义 `UserPath`。
7. 为移动到 `UserPath` 添加命令。
8. 将演示文稿写入磁盘，保存为 PPTX 文件。

以下 C++ 代码演示如何将 `PathFootball`（path football）效果应用于形状：
```c++
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

	// 为此按钮创建效果序列。
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // 创建自定义用户路径。我们的对象将在按钮点击后才会移动。
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

以下示例演示如何使用 [ISequence](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/) 接口中的 `GetEffectsByShape` 方法获取应用于形状的所有动画效果。

**示例 1：获取普通幻灯片上形状的动画效果**

之前，您已学习如何向 PowerPoint 演示文稿中的形状添加动画效果。以下示例代码展示如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状所应用的效果。
```c++
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

如果普通幻灯片上的形状拥有位于版式幻灯片和/或母版幻灯片上的占位符，并且这些占位符已添加动画效果，则在放映时该形状的所有效果都会播放，包括从占位符继承的效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中唯一的一张幻灯片仅包含一个带有文本 “Made with Aspose.Slides” 的页脚形状，并且对该形状应用了 **Random Bars** 效果。

![Slide shape animation effect](slide-shape-animation.png)

再假设在 **layout** 幻灯片的页脚占位符上应用了 **Split** 效果。

![Layout shape animation effect](layout-shape-animation.png)

最后，在 **master** 幻灯片的页脚占位符上应用了 **Fly In** 效果。

![Master shape animation effect](master-shape-animation.png)

以下示例代码演示如何使用 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 接口中的 `GetBasePlaceholder` 方法访问形状占位符，并获取应用于页脚形状的动画效果，包括从版式和母版幻灯片上的占位符继承的效果。
```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```

```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 获取普通幻灯片上形状的动画效果。
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// 获取布局幻灯片上占位符的动画效果。
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
Type: 134, subtype: 45            // 拆分, 垂直进入
Type: 126, subtype: 22            // 随机条, 水平
```


## **更改动画效果计时属性**

Aspose.Slides for C++ 允许您更改动画效果的计时属性。

以下是 Microsoft PowerPoint 中的动画计时面板：

![example1_image](shape-animation.png)

以下是 PowerPoint 计时与 [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) 属性之间的对应关系：

- PowerPoint 计时 **Start** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) 属性。
- PowerPoint 计时 **Duration** 对应 [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) 属性。动画的持续时间（秒）是动画完成一个循环所需的总时间。
- PowerPoint 计时 **Delay** 对应 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) 属性。

以下是更改 Effect Timing 属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。
2. 为您需要的 [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) 属性设置新值。
3. 保存修改后的 PPTX 文件。

```c++
// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// 获取幻灯片的主序列。
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 获取主序列的第一个效果。
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// 将效果的 TriggerType 更改为点击开始
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 更改效果持续时间
effect->get_Timing()->set_Duration(3.f);

// 更改效果的 TriggerDelayTime
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// 将 PPTX 文件保存到磁盘
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **动画效果声音**

Aspose.Slides 提供以下属性，以便在动画效果中使用声音：

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **添加动画效果声音**

以下 C++ 代码演示如何添加动画效果声音，并在下一个效果开始时停止它：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// 向演示文稿的音频集合添加音频
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 获取幻灯片的主序列。
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// 获取主序列的第一个效果
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// 检查效果是否为“无声音”
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // 为第一个效果添加声音
    firstEffect->set_Sound(effectSound);
}

// 获取幻灯片的第一个交互序列。
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// 设置效果的“停止先前声音”标志
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// 将 PPTX 文件写入磁盘
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```


### **提取动画效果声音**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 获取主效果序列。
4. 提取嵌入到每个动画效果中的 [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/)。

以下 C++ 代码演示如何提取嵌入在动画效果中的声音：
```c++
// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// 获取幻灯片的主序列。
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```


## **后动画**

Aspose.Slides for C++ 允许您更改动画效果的 After animation 属性。

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉列表对应以下属性：

- [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) 属性描述 After animation 类型：
  * PowerPoint **More Colors** 对应 [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型；
  * PowerPoint **Don't Dim** 对应 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型（默认的 after animation 类型）；
  * PowerPoint **Hide After Animation** 对应 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型；
  * PowerPoint **Hide on Next Mouse Click** 对应 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型；
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) 属性定义 after animation 的颜色格式。此属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型一起使用。如果将类型更改为其他，after animation 颜色将被清除。

```c++
// 实例化一个表示演示文稿文件的 Presentation 类
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 获取主序列的第一个效果
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// 将后动画类型更改为颜色
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// 设置后动画的暗淡颜色
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// 将 PPTX 文件写入磁盘
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```


## **动画文字**

Aspose.Slides 提供以下属性，以便使用动画效果的 *Animate text* 块：

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 用于描述效果的 animate text 类型。形状文本可按以下方式动画化：
  * 一次全部 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 类型)
  * 按单词 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 类型)
  * 按字母 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 类型)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 设置动画文本部分（单词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示秒数延迟。

以下是更改 Effect Animate text 属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。
2. 将 [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) 值，以关闭 *By Paragraphs* 动画模式。
3. 为 [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 和 [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 属性设置新值。
4. 保存修改后的 PPTX 文件。

```c++
// 实例化一个表示演示文稿文件的 Presentation 类。
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 获取主序列的第一个效果
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// 将效果的文本动画类型更改为“单对象”
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// 将效果的动画文本类型更改为“逐词”
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// 将单词之间的延迟设置为效果持续时间的 20%
firstEffect->set_DelayBetweenTextParts(20.0f);

// 将 PPTX 文件写入磁盘
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```


## **常见问题**

**如何在将演示文稿发布到网页时确保动画得以保留？**

[Export to HTML5](/slides/zh/cpp/export-to-html5/) 并启用负责 [shape](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [transition](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) 动画的 [options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/)。普通 HTML 不会播放幻灯片动画，而 HTML5 能播放。

**更改形状的 z 顺序（层次顺序）会如何影响动画？**

动画顺序与绘制顺序是独立的：效果控制出现/消失的计时和类型，而 [z-order](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) 决定哪个在上层。可见结果由两者的组合决定。（这是 PowerPoint 的通用行为，Aspose.Slides 的效果与形状模型遵循相同逻辑。）

**将动画转换为视频时，对某些效果是否存在限制？**

一般而言，[动画受支持](/slides/zh/cpp/convert-powerpoint-to-video/)，但在少数情况或特定效果下可能渲染不同。建议使用您所用的效果和相应的库版本进行测试。