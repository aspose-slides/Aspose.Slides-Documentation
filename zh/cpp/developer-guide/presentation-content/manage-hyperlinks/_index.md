---
title: 在 C++ 中管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/cpp/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 移除超链接
- 更新超链接
- 文本超链接
- 幻灯片超链接
- 形状超链接
- 图片超链接
- 视频超链接
- 可变超链接
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 C++ 示例，利用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和移除超链接。"
---
## **介绍**

超链接将演示文稿内容连接到网站或演示文稿内部的某个位置。在 PowerPoint 中，超链接通常有两个用途：

* 从文本、形状或多媒体框架打开网站。
* 从目录等跳转到另一张幻灯片。

Aspose.Slides for C++ 允许您添加这些链接、控制其外观和声音、更新其设置以及删除它们。下面的示例展示了如何在单个元素上使用超链接，以及如何在演示文稿、幻灯片或文本框层级访问超链接。

{{% alert color="info" title="注意" %}}

您还可以使用[免费在线 Aspose PowerPoint 编辑器](https://products.aspose.app/slides/zh/editor)编辑演示文稿。

{{% /alert %}} 

## **添加 URL 超链接**

您可以将网站 URL 分配给文本、形状或多媒体框架。所分配超链接的元素决定了可点击区域：文本部分只会链接所选文本，而形状或框架则链接整个幻灯片对象。

### **为文本添加 URL 超链接**

要将文本链接到网站，请创建一个[Hyperlink](https://reference.aspose.com/slides/zh/cpp/aspose.slides/hyperlink/)并使用文本部分的[set_HyperlinkClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/portionformat/set_hyperlinkclick/)方法进行分配，如下所示。只有该文本部分会变为可点击。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **为形状和多媒体框架添加 URL 超链接**

要使形状或框架可点击，使用其[set_HyperlinkClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/set_hyperlinkclick/)方法。超链接属于对象本身，而不是其中的文本部分。

相同的做法同样适用于图片、音频和视频框架：将超链接分配给框架，并使用[set_Tooltip](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/set_tooltip/)在需要时添加提示。

下面的示例将一个矩形设为可点击：

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **使用超链接创建目录**

内部超链接让读者可以从目录跳转到指定幻灯片。以下示例使用[SetInternalHyperlinkClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)将第一张幻灯片上的“第 2 页”文本链接到第二张幻灯片。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **格式化超链接**

### **颜色**

[IHyperlink](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/)的[set_ColorSource](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/set_colorsource/)方法决定超链接是使用演示文稿的超链接颜色还是文本部分的格式。要应用自定义文本颜色，请选择[HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/hyperlinkcolorsource/)并设置该部分的填充颜色。此功能在 PowerPoint 2019 中引入；旧版本不支持此设置。

下面的示例在同一张幻灯片上添加了两个文本超链接。第一个使用红色文本填充，第二个保留默认超链接颜色。

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **声音**

激活超链接时可以播放声音，或停止已在播放的声音。使用以下方法配置这些行为：

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/set_sound/)指定与超链接关联的音频。
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/)控制激活超链接时是否停止先前的声音。

#### **添加超链接声音**

下面的示例加载 `sampleaudio.wav` 并将其关联到第一张幻灯片上的一个按钮。单击按钮会播放声音并跳转到下一张幻灯片。该幻灯片上的第二个形状在单击时会停止先前的声音，但不执行跳转操作。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **提取超链接声音**

下面的示例打开上述创建的演示文稿，并通过[get_Sound](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/get_sound/)和[get_BinaryData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iaudio/get_binarydata/)将第一个形状的超链接音频读取到内存。

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **提示和交互设置**

在将超链接分配给文本或形状后，您可以使用以下方法更新[IHyperlink](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/)的设置：

- [set_Tooltip](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/set_tooltip/)设置查看者可显示的提示文字。
- [set_TargetFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/set_targetframe/)在适用时指定父 HTML frameset 中的目标框架。
- [set_History](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/set_history/)控制激活链接后是否将其目的地加入已查看超链接列表。
- [set_HighlightClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/set_highlightclick/)控制点击时是否高亮显示超链接。

## **从演示文稿中移除超链接**

使用[GetAnyHyperlinks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)在更改之前收集包括文本部分链接在内的超链接容器。下面的示例从第一张幻灯片移除两种激活类型。若只想移除一种类型，只调用[RemoveHyperlinkClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)或[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)；移除点击操作并不会同时移除鼠标悬停对应的操作。

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

如需无条件移除，[RemoveAllHyperlinks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)会在一次调用中删除所选范围内的两种激活类型。有关选择性清理以及覆盖母版、布局和备注的说明，请参阅[报告、清理与验证超链接](#report-sanitize-and-verify-hyperlinks)。

## **构建完整的超链接清单**

在分发演示文稿之前，需要对交互动作以及网络链接进行清点。[GetAnyHyperlinks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)返回[IHyperlinkContainer](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkcontainer/)对象，而不是 URL 字符串的扁平列表。检查每个容器的[get_HyperlinkClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/)和[get_HyperlinkMouseOver](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/)。它们是独立的：同一个容器可以同时暴露两种动作，因此完整报告可能需要每个容器最多两行。

仅在形状层级扫描超链接可能会遗漏附加在文本部分的链接。请改为查询适当的范围，并保留返回的容器，以便以后更新或删除其动作。

### **查询演示文稿、幻灯片和文本框范围**

[IHyperlinkQueries](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkqueries/) 接口可通过[IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/)、[IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/)和[ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/get_hyperlinkqueries/)获取。每个范围支持相同的查询：

- [GetHyperlinkClicks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/)返回具有点击动作的容器。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/)返回具有鼠标悬停动作的容器。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)返回包含任一或两种动作的容器。

下面的示例创建 `hyperlink-audit-input.pptx`，其中包含外部点击链接、文件鼠标悬停链接、内部幻灯片导航、文本鼠标悬停链接以及宏动作。示例本身并不执行这些动作。相同的三个查询在每个范围内均可使用；计数描述的是容器数，而非动作总数。文本框范围不包括其所在形状的链接。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

在本示例中，演示文稿和幻灯片查询各报告三个点击容器、两个鼠标悬停容器以及三个任一动作的容器。文本框查询在每个分类中各报告一个容器。

### **对动作和目标进行分类**

使用[IHyperlink::get_ActionType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/get_actiontype/)在解释目标之前先判断动作类型。[HyperlinkActionType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/hyperlinkactiontype/)的取值涵盖了除网页导航之外的多种情形：

| 值 | 审计时的含义 |
| --- | --- |
| `Hyperlink` | 外部超链接；检查 URL 及其方案。 |
| `JumpSpecificSlide` | 跳转到特定幻灯片的内部导航。 |
| `JumpFirstSlide`、`JumpPreviousSlide`、`JumpNextSlide`、`JumpLastSlide`、`JumpLastViewedSlide` | 内置幻灯片放映导航，在放映上下文中解析。 |
| `JumpEndShow`、`StartCustomSlideShow` | 结束当前放映或启动自定义放映。 |
| `StartMacro` | 执行宏。 |
| `StartProgram` | 启动程序。 |
| `OpenFile`、`OpenPresentation` | 打开文件或其他演示文稿；需单独与网页 URL 区分审查。 |
| `StartStopMedia` | 开始或停止媒体播放。 |
| `NoAction`、`Unknown` | 无导航动作，或未识别的动作，需要审查。 |

通过[get_ExternalUrl](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/get_externalurl/)读取外部目标，通过[get_TargetSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/get_targetslide/)读取具体内部目标。内部动作和内置命令可能没有外部 URL；空 URL 并不表示容器没有动作。若[get_ExternalUrlOriginal](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/get_externalurloriginal/)与规范化 URL 不同，请保留原始值；若可用，还应包含[get_Tooltip](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlink/get_tooltip/)返回的提示文字。

### **报告、清理与验证超链接**

下面的 C++ 示例读取已有演示文稿（使用上述创建的文件），写入 `hyperlink-audit.json`，应用策略后保存为 `hyperlink-sanitized.pptx`，并再次打开以重新检查两种激活类型。示例在更改前收集容器，并使用指针标识避免对同一容器进行多次处理。演示文稿查询覆盖普通幻灯片；若需对整个包进行清点，还会显式查询母版、布局、备注以及出现时的备注和讲义母版。

报告记录基于 1 的幻灯片索引以及在可能的情况下的[get_SlideId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/get_slideid/)。[ISlideComponent::get_Slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecomponent/get_slide/)提供支持容器的所属幻灯片。母版、布局和备注没有普通幻灯片索引，使用其范围标识。形状容器和文本段落格式容器分别标记；其他容器类型保留其运行时类型名称。每个容器获得报告本地 ID，以便将其两种动作关联起来。

此限制性策略仅允许绝对 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件动作、其他幻灯片动作、未知动作以及其他 URL 方案。这些拒绝是策略决策，而非 Aspose.Slides 安全性的判断。仅 HTTPS 并不等同于信任：请为您的应用添加主机白名单等检查。原始和规范化的外部 URL 都会被检查。示例仅审计元数据，不会跟随链接或执行动作。

如需修复，容器的[get_HyperlinkManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/)支持[SetExternalHyperlinkClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)和[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)。本例中，将被禁止的外部点击链接替换为固定的 HTTPS 登陆页面；其他被禁止的点击和鼠标悬停动作分别被移除。将 `replaceExternalClicks` 设置为 `false` 可删除所有策略违规项。请在部署前准备好由应用拥有的替换页面。

报告的导出标记采用保守的 PDF 审核策略：对鼠标悬停动作以及除外部链接或特定幻灯片跳转之外的任何动作进行标记，视为可能不受支持。这仅是审查提示，并非功能测试或对未标记链接在导出后仍能保存的保证。受支持的[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)和[HTML](/slides/zh/cpp/convert-powerpoint-to-html/)导出可能会保留超链接，具体取决于动作、导出选项和查看器。栅格[图片](/slides/zh/cpp/convert-powerpoint-to-png/)和[视频](/slides/zh/cpp/convert-powerpoint-to-video/)无法保留交互式超链接；在针对这些输出进行审计时请对每个动作进行标记。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

使用上述输入创建的报告包含五行动作。文件鼠标悬停链接和宏点击被移除，而 HTTPS 链接和内部幻灯片导航保留。验证阶段打印出零个违规动作。包含违规外部点击 URL 的输入也会触发替换分支。一个容器既有允许的点击又有被禁止的鼠标悬停时，仅保留点击动作。

此选择性清理不同于[RemoveAllHyperlinks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)，后者会在所选范围内不论策略全部移除两种激活类型。这里的验证仅检查超链接动作；它不删除嵌入的 VBA 项目、OLE 对象或其他活动内容，也不验证导出的 PDF 或 HTML 文件。

## **常见问题解答**

**如何链接到某个章节或其第一张幻灯片？**

PowerPoint 中的章节用于组织幻灯片，但内部超链接只能定位到单张幻灯片。若要实现章节跳转，请链接到该章节的第一张幻灯片。

**我能将超链接附加到母版幻灯片元素上，使其在所有幻灯片上生效吗？**

可以。母版幻灯片和布局元素支持超链接。在使用相应母版或布局的幻灯片放映时，这些链接会可用。

**超链接在导出为 PDF、HTML、图片或视频时会被保留吗？**

支持的 PDF 和 HTML 导出可能会保留超链接；栅格图片和视频则不能。请参阅[报告、清理与验证超链接](#report-sanitize-and-verify-hyperlinks)中的导出注意事项。