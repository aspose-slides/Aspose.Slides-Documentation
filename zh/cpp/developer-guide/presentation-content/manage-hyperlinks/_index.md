---
title: 管理演示文稿超链接（C++）
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/cpp/manage-hyperlinks/
keywords:
- 添加 URL
- 添加 超链接
- 创建 超链接
- 格式化 超链接
- 删除 超链接
- 更新 超链接
- 文本 超链接
- 幻灯片 超链接
- 形状 超链接
- 图像 超链接
- 视频 超链接
- 可变 超链接
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 轻松管理 PowerPoint 和 OpenDocument 演示文稿中的超链接——在几分钟内提升互动性和工作流。"
---

超链接是指向对象、数据或某个位置的引用。这些是 PowerPoint 演示文稿中常见的超链接：

* 文本、形状或媒体中的网站链接
* 幻灯片链接

Aspose.Slides for C++ 允许您在演示文稿中执行许多涉及超链接的任务。 

{{% alert color="primary" %}} 

您可能想了解 Aspose 简单的[免费在线 PowerPoint 编辑器.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **添加 URL 超链接**

### **向文本添加 URL 超链接**

此 C++ 代码展示了如何向文本添加网站超链接：
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```


### **向形状或框架添加 URL 超链接**

此 C++ 示例代码展示了如何向形状添加网站超链接：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


### **向媒体添加 URL 超链接**

Aspose.Slides 允许您向图像、音频和视频文件添加超链接。 

此示例代码展示了如何向**图像**添加超链接：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// 将图像添加到演示文稿
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// 在幻灯片 1 上创建图片框，基于之前添加的图像
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


 此示例代码展示了如何向**音频文件**添加超链接：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


 此示例代码展示了如何向**视频**添加超链接：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


{{% alert title="Tip" color="primary" %}} 

您可能想查看*[管理 OLE](https://docs.aspose.com/slides/cpp/manage-ole/)*。

{{% /alert %}}

## **使用超链接创建目录**

由于超链接可以添加对对象或位置的引用，您可以使用它们创建目录。 

此示例代码展示了如何使用超链接创建目录：
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```


## **格式化超链接**

### **颜色**

通过 [IHyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink) 接口中的 [set_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) 和 [get_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) 方法，您可以设置超链接的颜色，也可以获取超链接的颜色信息。此功能首次在 PowerPoint 2019 中引入，因此对属性的更改不适用于旧版 PowerPoint。

此示例代码演示了在同一幻灯片上添加不同颜色的超链接的操作：
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```


## **从演示文稿中删除超链接**

### **从文本删除超链接**

此 C++ 代码展示了如何从演示文稿幻灯片中的文本删除超链接：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```


### **从形状或框架删除超链接**

此 C++ 代码展示了如何从演示文稿幻灯片中的形状删除超链接： 
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```


## **可变超链接**

[Hyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.hyperlink) 类是可变的。使用此类，您可以更改以下方法的值：

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

代码片段展示了如何向幻灯片添加超链接并在稍后编辑其工具提示：
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```


## **IHyperlinkQueries 中受支持的方法**

您可以从定义了超链接的演示文稿、幻灯片或文本访问 IHyperlinkQueries。 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

IHyperlinkQueries 类支持以下方法： 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **常见问题解答**

**如何创建不仅指向幻灯片而且指向“章节”或章节第一张幻灯片的内部导航？**

PowerPoint 中的章节是幻灯片的分组；导航技术上是针对特定幻灯片的。要“导航到章节”，通常会链接到该章节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素吗，这样在所有幻灯片上都有效？**

可以。母版幻灯片和布局元素支持超链接。这些链接会出现在子幻灯片上，并在放映期间可点击。

**导出为 PDF、HTML、图像或视频时超链接会被保留吗？**

在[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)和[HTML](/slides/zh/cpp/convert-powerpoint-to-html/)中，会保留链接。导出为[图像](/slides/zh/cpp/convert-powerpoint-to-png/)和[视频](/slides/zh/cpp/convert-powerpoint-to-video/)时，由于这些格式的性质（光栅帧/视频不支持超链接），点击功能将不被保留。