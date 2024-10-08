---
title: 形状动画
type: docs
weight: 60
url: /cpp/shape-animation/
keywords: "PowerPoint 动画, 动画效果, 应用动画, PowerPoint 演示文稿, C++, CPP, Aspose.Slides for C++"
description: "在 C++ 中应用 PowerPoint 动画"
---

动画是可以应用于文本、图像、形状或 [图表](/slides/cpp/animated-charts/) 的视觉效果。它们为演示文稿或其组成部分注入了生机。

### **为什么在演示文稿中使用动画？**

通过使用动画，您可以

* 控制信息的流动
* 强调重要点
* 增加观众的兴趣或参与
* 使内容更易于阅读、理解或处理
* 吸引读者或观众关注演示文稿中的重要部分

PowerPoint 在 **进入**、**退出**、**强调** 和 **运动路径** 类别中提供了许多选项和工具来实现动画和动画效果。

### **Aspose.Slides 中的动画**

* Aspose.Slides 提供了您所需的类和类型，以便在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) 命名空间下处理动画。
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 枚举下提供了超过 **150 种动画效果**。这些效果与 PowerPoint 中使用的效果本质上是相同的。

## **应用动画到文本框**

Aspose.Slides for C++ 允许您对形状中的文本应用动画。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)。
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) 添加文本。
5. 获取效果的主序列。
6. 将动画效果添加到 [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)。
7. 将 [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) 属性设置为 [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) 中的值。
8. 将演示文稿写入磁盘作为 PPTX 文件。

以下 C++ 代码展示了如何将 `Fade` 效果应用于自动形状并将文本动画设置为 *按第一层级段落* 的值：

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"第一段 \n第二段 \n 第三段");

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

除了将动画应用于文本，您还可以将动画应用于单个 [段落](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph)。请参阅 [**动画文本**](/slides/cpp/animated-text/)。

{{% /alert %}} 

## **应用动画到图片框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame)。
4. 获取效果的主序列。
5. 将动画效果添加到 [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame)。
6. 将演示文稿写入磁盘作为 PPTX 文件。

以下 C++ 代码展示了如何将 `Fly` 效果应用于图片框：

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Load Image to be added in presentaiton image collection
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Adds picture frame to slide
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Adds Fly from Left animation effect to picture frame
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Save the PPTX file to disk
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **应用动画到形状**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)。
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)（当此对象被点击时，动画将播放）。
5. 在斜角形状上创建效果的序列。
6. 创建自定义 `UserPath`。
7. 为移动到 `UserPath` 添加命令。
8. 将演示文稿写入磁盘作为 PPTX 文件。

以下 C++ 代码展示了如何将 `PathFootball`（路径足球）效果应用于形状：

```c++
	// The path to the document directory.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Loads the presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accesses first slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accesses shapes collection for selected slide
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Creates PathFootball effect for existing shape from scratch.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"动画文本框");

	// Adds the PathFootBall animation effect
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Create some kind of "button".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Creates a sequence of effects for this button.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Creates a custom user path. Our object will be moved only after the button is clicked.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Adds commands for moving since created path is empty.
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
	 
	 //Writes the PPTX file to Disk
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **获取应用于形状的动画效果**

您可能想要了解应用于单个形状的所有动画效果。

以下 C++ 代码展示了如何获取应用于特定形状的所有效果：

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

System::SharedPtr<ISlide> firstSlide = pres->get_Slides()->idx_get(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on slide.
System::SharedPtr<IShape> shape = firstSlide->get_Shapes()->idx_get(0);

// Gets all animation effects applied to the shape.
System::ArrayPtr<System::SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    System::Console::WriteLine(System::String(u"形状 ") + shape->get_Name() + u" 有 " + shapeEffects->get_Length() + u" 个动画效果。");
}
```

## **更改动画效果的时间属性**

Aspose.Slides for C++ 允许您更改动画效果的时间属性。

这是 Microsoft PowerPoint 中的动画定时面板：

![example1_image](shape-animation.png)

PowerPoint 定时 **开始** 下拉列表与 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) 属性相匹配。
PowerPoint 定时 **持续时间** 与 [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) 属性对应。动画的持续时间（以秒为单位）是动画完成一个周期所需的总时间。
PowerPoint 定时 **延迟** 与 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) 属性对应。

以下是如何更改效果时间属性的方法：

1. [应用](#apply-animation-to-shape) 或获取动画效果。
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) 属性设置新值。
3. 保存修改后的 PPTX 文件。

以下 C++ 代码演示了该操作：

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Gets the first effect of main sequence.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Changes effect TriggerType to start on click
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Changes effect Duration
effect->get_Timing()->set_Duration(3.f);

// Changes effect TriggerDelayTime
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Saves the PPTX file to disk
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **动画效果声音**

Aspose.Slides 提供了这些属性以允许您处理动画效果中的声音：

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **添加动画效果声音**

以下 C++ 代码展示了如何添加动画效果声音，并在下一个效果开始时停止它：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Adds audio to presentation audio collection
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first effect of the main sequence
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Сhecks the effect for "No Sound"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Adds sound for the first effect
    firstEffect->set_Sound(effectSound);
}

// Gets the first interactive sequence of the slide.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Sets the effect "Stop previous sound" flag
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Writes the PPTX file to disk
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **提取动画效果声音**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 获取效果的主序列。
4. 提取嵌入到每个动画效果中的 [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/)。

以下 C++ 代码展示了如何提取动画效果中嵌入的声音：

```c++
// Instantiates a presentation class that represents a presentation file.
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

Aspose.Slides for C++ 允许您更改动画效果的后动画属性。

这是 Microsoft PowerPoint 中的动画效果面板和扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint 效果 **后动画** 下拉列表与以下属性相匹配：

- [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) 属性描述后动画类型：
  * PowerPoint **更多颜色** 与 [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型匹配；
  * PowerPoint **不调暗** 列表项与 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型相匹配（后动画类型的默认值）；
  * PowerPoint **动画后隐藏** 项与 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型相匹配；
  * PowerPoint **下一个鼠标点击时隐藏** 项与 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型相匹配；
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) 属性定义后动画颜色格式。此属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) 类型结合使用。如果您将类型更改为其他值，则后动画颜色将被清除。

以下 C++ 代码展示了如何更改后动画效果：

```c++
// Instantiates a presentation class that represents a presentation file
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Gets the first effect of the main sequence
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Changes the after animation type to Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Sets the after animation dim color
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Writes the PPTX file to disk
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **动画文本**

Aspose.Slides 提供了这些属性以允许您处理动画效果的 *动画文本* 块：

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 描述效果的动画文本类型。形状文本可以被动画化：
  - 一次性全部动画（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 类型）
  - 按单词动画（[AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 类型）
  - 按字母动画（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) 类型）
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 设置动画文本部分（单词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

以下是如何更改效果动画文本属性的方法：

1. [应用](#apply-animation-to-shape) 或获取动画效果。
2. 将 [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) 值，以关闭 *按段落* 动画模式。
3. 设置 [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 和 [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 属性的新值。
4. 保存修改后的 PPTX 文件。

以下 C++ 代码演示了该操作：

```c++
// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Gets the first effect of the main sequence
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Changes the effect Text animation type to "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Changes the effect Animate text type to "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Sets the delay between words to 20% of effect duration
firstEffect->set_DelayBetweenTextParts(20.0f);

// Writes the PPTX file to disk
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```