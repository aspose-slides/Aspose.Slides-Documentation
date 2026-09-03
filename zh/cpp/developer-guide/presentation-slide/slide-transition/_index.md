---
title: 使用 C++ 管理演示文稿中的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/cpp/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 应用幻灯片切换
- 高级幻灯片切换
- Morph 切换
- 切换类型
- 切换效果
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 应用幻灯片切换、配置自动幻灯片前进，并自定义 Morph 及其他切换效果。"
---
## **概述**

幻灯片切换控制幻灯片在放映期间的显示方式。使用 Aspose.Slides for C++，您可以为每张幻灯片选择切换效果，配置鼠标点击或计时器的前进方式，并调整特定于某个效果的选项。本文使用 C++ 示例演示如何应用切换、设置精确的切换持续时间、管理幻灯片计时以及在两张幻灯片之间创建 Morph 切换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类加载演示文稿，并通过 [get_SlideShowTransition](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 访问幻灯片的切换设置。调用 [set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_type/) 并传入来自 [TransitionType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitiontype/) 枚举的值，然后保存演示文稿。

以下示例为第一张幻灯片应用 Circle 切换，为第二张幻灯片应用 Comb 切换。使用至少包含两张幻灯片的 `input.pptx` 文件。

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

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击前进幻灯片放映。以下方法控制此行为：

- [set_AdvanceOnClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) 允许观众通过点击鼠标前进。
- [set_AdvanceAfter](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_advanceafter/) 启用自动前进。
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) 指定自动前进之前的延迟（毫秒）。

同时启用点击和计时前进，使观众可以点击继续或等待计时器。若仅使用计时器，请将 [set_AdvanceOnClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) 设为 `false`。延迟控制幻灯片放映何时前进；它并不设定视觉切换效果的持续时间。

本示例为前三张幻灯片分配不同效果，并分别在 3、5、7 秒后自动前进。鼠标点击同样可以前进这些幻灯片。使用至少包含三张幻灯片的 `input.pptx` 文件。

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

若要检查计时前进是否已启用，调用 [get_AdvanceAfter](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/get_advanceafter/)。仅存储延迟并不表示计时器已激活。

下面的示例打开上述保存的文件，报告每个已启用的计时器，并对延迟超过两秒的幻灯片禁用自动前进。随后为这些幻灯片启用鼠标点击并保存更新后的设置。

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

## **精确控制切换时间**

使用 [set_Duration](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_duration/) 可在毫秒级指定切换效果的确切长度。幻灯片的 [get_SlideShowTransition](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 方法通过 [ISlideShowTransition](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/) 暴露这些设置：

| 方法 | 目的 |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_duration/) | 设置切换效果本身的持续时间（毫秒）。 |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | 设置幻灯片自动前进前的延迟（毫秒）。调用 [set_AdvanceAfter](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_advanceafter/) 并传入 `true` 以启动计时器。 |
| [set_Speed](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_speed/) | 从 [TransitionSpeed](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitionspeed/)（Slow、Medium、Fast）中选择预定义的速度类别。当未指定确切持续时间时使用。 |

[set_Duration](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_duration/) 仅控制切换效果本身；它不决定幻灯片保持可见的时间。请单独配置自动前进的延迟。当未设置显式持续时间时，Aspose.Slides 会根据切换类型和 [get_Speed](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/get_speed/) 返回的值计算效果时长。

### **对每张幻灯片使用相同的持续时间**

为保持节奏一致，可对每张幻灯片应用相同的效果和精确持续时间。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitiontype/) 选择 Fade，并为每个切换设置 750 毫秒的持续时间。它单独将自动前进延迟设为 5,000 毫秒，并禁用鼠标点击前进，随后将结果保存为 PPTX。

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

    // 配置自动前进，独立于效果持续时间。
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **为单独幻灯片设置不同的持续时间**

不同幻灯片可以使用不同的效果时长。例如，对标题幻灯片使用短暂切换，对章节介绍使用较长切换。此示例为第一张幻灯片设为 500 毫秒，为第二张设为 1,200 毫秒。使用至少包含两张幻灯片的 `input.pptx` 文件。

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

### **与动画输出协同切换**

在准备 [animated GIF](/slides/zh/cpp/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh/cpp/export-to-html5/) 或 [video](/slides/zh/cpp/convert-powerpoint-to-video/) 时，请在导出前设置精确的切换持续时间，以匹配预期的节奏。例如，在场景之间使用 600 毫秒的淡入淡出，并分别调整每张幻灯片的前进延迟，以留出解说或内容的时间。

对于 GIF 和视频，需要将输出帧率与效果时长对应：600 毫秒相当于 30 fps 下的 18 帧。对于 HTML5，在导出设置中启用动画切换。检查所选导出格式支持的效果和计时选项，并预览输出以确认同步。

### **读取已有的切换持续时间**

在修改切换之前调用 [get_Duration](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/get_duration/) 以确定是否已存储显式值。`-1` 表示未设置显式持续时间；非负值表示以毫秒为单位的存储时长。未设定的值并非计算得到的播放时长：Aspose.Slides 会根据切换类型和 [get_Speed](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/get_speed/) 的返回值确定该时长。设置切换类型可能会初始化持续时间，因此请先检查原始设置。

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

## **Morph 切换**

Morph 切换在连续幻灯片之间对对象的变化进行动画化。要创建简单的 Morph 效果，复制一张幻灯片，在副本上移动或调整对象大小，然后对第二张幻灯片应用 Morph 切换。这样，切换会在原始状态和修改后状态之间对对应对象进行动画。

以下示例创建包含文本矩形的幻灯片，复制该幻灯片，并在副本上更改矩形的位置和大小。随后为第二张幻灯片从 [TransitionType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitiontype/) 枚举中选择 Morph。使用支持 Morph 的演示文稿查看器打开保存的文件，即可在放映时看到效果。

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

## **Morph 切换类型**

[TransitionMorphType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitionmorphtype/) 枚举控制 Morph 如何匹配并动画化内容：

- [ByObject](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitionmorphtype/) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitionmorphtype/) 在可能的情况下按单词匹配文本进行动画。
- [ByChar](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitionmorphtype/) 在可能的情况下按字符匹配文本进行动画。

在访问 [get_Value](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/get_value/) 之前，先使用 [set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_type/) 将类型设为 Morph。随后该值提供 [IMorphTransition](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/imorphtransition/) 接口，可通过其 [set_MorphType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) 方法选择匹配模式。

本示例打开前一节创建的演示文稿，并将第二张幻灯片配置为基于单词的 Morph 动画。

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

## **设置切换效果**

某些切换会暴露额外选项，如方向或是否从黑屏开始。可用选项取决于所选的切换类型。先设置类型，然后使用 [get_Value](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/get_value/) 返回的相应接口。

以下示例对 `input.pptx` 的第一张幻灯片应用 Cut 切换。它通过 [IOptionalBlackTransition](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/ioptionalblacktransition/) 调用 [set_FromBlack](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) 并传入 `true`，使切换从黑屏开始。

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

## **常见问题**

**我可以控制幻灯片切换的播放速度吗？**

可以。当需要以毫秒为单位的精确效果时，请优先使用 [set_Duration](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_duration/)。如果预定义的 [TransitionSpeed](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitionspeed/)（Slow、Medium、Fast）足够且未设置显式持续时间，请使用 [set_Speed](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_speed/)。这些设置独立于自动前进延迟，控制切换效果本身。

**我能把音频附加到切换上并让它循环吗？**

可以。使用 [set_Sound](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_sound/) 分配嵌入音频，调用 [set_SoundMode](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_soundmode/) 并传入来自 [TransitionSoundMode](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitionsoundmode/) 枚举的 `StartSound`，再通过 [set_SoundLoop](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_soundloop/) 启用循环。音频将在幻灯片放映的下一个声音事件出现前一直循环。

**将相同切换应用于每张幻灯片的最快方法是什么？**

遍历演示文稿的 [get_Slides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_slides/) 方法返回的集合，对每张幻灯片的切换调用 [set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/set_type/) 并传入相同的值。可在同一循环中设置计时和效果选项，以保持所有幻灯片行为一致。

**如何检查幻灯片当前设置了哪种切换？**

对幻灯片的 [get_SlideShowTransition](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 方法返回的切换对象调用 [get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideshowtransition/get_type/)。它返回 [TransitionType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.slideshow/transitiontype/) 枚举中的值；`None` 表示未应用任何切换效果。