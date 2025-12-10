---
title: 使用 C++ 的 AutoFit 增强演示文稿
linktitle: AutoFit 设置
type: docs
weight: 30
url: /zh/cpp/manage-autofit-settings/
keywords:
- 文本框
- 自动适配
- 不自动适配
- 适配文本
- 缩小文本
- 自动换行
- 调整形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中管理 AutoFit 设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示并提升内容可读性。"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 使用 **Resize shape to fix text** 设置——它会自动调整文本框的大小，以确保文本始终适配。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文本。  
* 当文本框中的文本变短或变小时时，PowerPoint 会自动缩小文本框——降低其高度——以清除多余空间。  

在 PowerPoint 中，以下 4 个重要参数或选项用于控制文本框的自动适配行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ 提供了类似的选项——[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类下的部分方法——可让您控制演示文稿中文本框的自动适配行为。

## **将形状大小调整以匹配文本**

如果希望在更改文本后文本始终适配其所在的框，需要使用 **Resize shape to fix text** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类）设为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 C++ 代码演示如何在 PowerPoint 演示文稿中指定文本必须始终适配其框：
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


如果文本变长或变大，文本框将自动增高以确保所有文本都能容纳；如果文本变短，则相反。

## **不进行自动适配**

如果希望文本框或形状无论文本如何变化都保持原有尺寸，需要使用 **Do not Autofit** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类）设为 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 C++ 代码演示如何在 PowerPoint 演示文稿中指定文本框始终保持其尺寸：
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


当文本超出框的长度时，会溢出显示。

## **文字溢出时缩小**

如果文本超出框的长度，可通过 **Shrink text on overflow** 选项指定将文本的大小和间距缩小以适配框。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类）设为 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 C++ 代码演示如何在 PowerPoint 演示文稿中指定文字在溢出时缩小：
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 选项时，仅在文本超出框的长度时才会应用此设置。  
{{% /alert %}}

## **自动换行**

如果希望文本在形状宽度不足时自动换行到形状内部，需要使用 **Wrap text in shape** 参数。要指定此设置，请将 [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类）设为 `true`。

以下 C++ 代码演示如何在 PowerPoint 演示文稿中使用自动换行设置：
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 
如果将 `WrapText` 属性设为 `False`，当形状内部的文本长度超过形状宽度时，文本会在单行中超出形状边界。  
{{% /alert %}}

## **FAQ**

**文本框的内部边距会影响 AutoFit 吗？**  
会。内部边距（Padding）会减小可用文本区域，因此 AutoFit 会更早触发——提前缩小字体或调整形状大小。请在调节 AutoFit 前检查并调整边距。

**AutoFit 与手动换行符和软换行符如何交互？**  
强制换行符会保留原位，AutoFit 会在其周围调整字体大小和间距。移除不必要的换行符通常能降低 AutoFit 对文本的压缩力度。

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**  
会。替换为度量不同的字体会改变文本的宽高，从而影响最终的字体大小和换行方式。任何字体更改或替换后，请重新检查幻灯片的布局。