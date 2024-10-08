---
title: 管理自动调整设置
type: docs
weight: 30
url: /cpp/manage-autofit-settings/
keywords: "文本框, 自动调整, PowerPoint 演示文稿, C++, Aspose.Slides for C++"
description: "在 C++ 中为 PowerPoint 中的文本框设置自动调整设置"
---

默认情况下，当您添加一个文本框时，Microsoft PowerPoint 使用 **调整形状以适应文本** 设置来为文本框自动调整大小，以确保文本框中的文本始终适合。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变得更长或更大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多的文本。
* 当文本框中的文本变得更短或更小时，PowerPoint 会自动缩小文本框——减少其高度——以清除多余的空间。

在 PowerPoint 中，有 4 个重要参数或选项控制文本框的自动调整行为：

* **不自动调整**
* **溢出时缩小文本**
* **调整形状以适应文本**
* **在形状内换行文本。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ 提供类似的选项——在 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类下的一些方法——可以让您控制演示文稿中文本框的自动调整行为。

## **调整形状以适应文本**

如果您希望文本在文本框内的内容在修改后始终适合该框，则必须使用 **调整形状以适应文本** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类）设置为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 C++ 代码展示了如何在 PowerPoint 演示文稿中指定文本必须始终适应其框：

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

如果文本变得更长或更大，文本框将自动调整大小（高度增加），以确保所有文本都适合其中。如果文本变得更短，则会发生相反的情况。

## **不自动调整**

如果您希望文本框或形状保持其尺寸，无论包含的文本发生什么变化，则必须使用 **不自动调整** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类）设置为 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 C++ 代码展示了如何在 PowerPoint 演示文稿中指定文本框必须始终保持其尺寸：

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

当文本对其框变得太长时，它将溢出。

## **溢出时缩小文本**

如果文本对其框变得太长，通过 **溢出时缩小文本** 选项，您可以指定文本的大小和间距必须缩小，以使其适合其框。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类）设置为 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 C++ 代码展示了如何在 PowerPoint 演示文稿中指定文本在溢出时必须缩小：

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

{{% alert title="信息" color="info" %}}

当使用 **溢出时缩小文本** 选项时，设置仅在文本变得太长而无法放入其框时应用。

{{% /alert %}}

## **换行文本**

如果您希望形状内的文本在超过形状边界（仅宽度）时换行，则必须使用 **在形状内换行文本** 参数。要指定此设置，您必须将 [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) 类）设置为 `true`。

以下 C++ 代码展示了如何在 PowerPoint 演示文稿中使用换行文本设置：

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

{{% alert title="注意" color="warning" %}}

如果您将 `WrapText` 属性设置为 `False`，当形状内的文本变得比形状的宽度长时，文本将沿着单行延伸超出形状的边界。

{{% /alert %}}