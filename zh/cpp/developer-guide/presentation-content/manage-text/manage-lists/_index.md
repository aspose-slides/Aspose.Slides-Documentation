---
title: 在 C++ 中管理演示文稿的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 70
url: /zh/cpp/manage-lists/
keywords:
- 项目符号
- 项目符号列表
- 编号列表
- 符号项目符号
- 图片项目符号
- 自定义项目符号
- 多级列表
- 创建项目符号
- 添加项目符号
- 添加列表
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号、图片、多级和编号列表。"
---
## **概述**

Aspose.Slides for C++ 允许您在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号列表和编号列表。列表项是一个段落，其项目符号设置通过段落格式进行控制。

使用[IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/get_paragraphformat/) 方法访问段落级别的列表设置。主要入口是[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/get_bullet/)，它返回一个[IBulletFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/) 对象。通过该对象，您可以设置项目符号类型、符号、图片、颜色、大小、编号样式以及起始编号。

本文展示了如何：

- 使用自定义符号创建项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 检查并更改现有演示文稿中的列表格式

## **创建项目符号列表**

要创建项目符号列表，向[ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 添加[Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraph/) 对象，并将[IBulletFormat::set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_type/) 设置为[BulletType::Symbol](https://reference.aspose.com/slides/zh/cpp/aspose.slides/bullettype/)。随后可以通过[IBulletFormat::set_Char](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_char/)、[IBulletFormat::get_Color](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/get_color/) 和[IBulletFormat::set_Height](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_height/) 控制项目符号的外观。

下面的 C++ 代码演示了如何在幻灯片中创建项目符号列表：

```cpp
auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![符号项目符号](symbol_bullets.png)

## **创建编号列表**

当项目顺序重要时使用编号列表。将[IBulletFormat::set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_type/) 设置为[BulletType::Numbered](https://reference.aspose.com/slides/zh/cpp/aspose.slides/bullettype/)。您还可以使用[IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) 选择编号格式，或在列表需要从除 1 之外的数值开始时使用[IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/)。

下面的 C++ 代码展示了如何在幻灯片中创建编号列表：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![编号项目符号](numbered_bullets.png)

## **创建图片项目符号**

Aspose.Slides 允许您用图像替换常规的项目符号符号。图片项目符号最适合使用简洁的图像，在小尺寸下仍能保持可读性，例如图标或小的透明 PNG 文件。

{{% alert color="primary" %}}

理想情况下，如果您计划用图像替换常规项目符号，最好选择具有透明背景的简易图形。这类图像非常适合作为自定义项目符号。

请记住，图像会被缩小到非常小的尺寸。因此，我们强烈建议选择在列表项目符号中仍然清晰、视觉效果良好的图像。

{{% /alert %}}

要创建图片项目符号，向[IPresentation::get_Images](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_images/) 添加图像，并将返回的[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 对象分配给[IBulletFormat::get_Picture](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/get_picture/)。在分配图像之前，将[IBulletFormat::set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_type/) 设置为[BulletType::Picture](https://reference.aspose.com/slides/zh/cpp/aspose.slides/bullettype/)。

假设我们有一张 "image.png"：

![用于项目符号的图片](picture_for_bullets.png)

下面的 C++ 代码展示了如何在幻灯片中创建图片项目符号：

```cpp
auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![图片项目符号](picture_bullets.png)

## **创建多级列表**

使用[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_depth/) 将列表项放置在不同的层级。层级 0 为顶层，层级 1 为其下的嵌套层，以此类推。

下面的 C++ 代码展示了如何创建多级项目符号列表：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![多级列表](multilevel_list.png)

## **更改现有列表**

要更改现有演示文稿中的列表格式，访问目标段落并更新其[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/get_bullet/) 设置。创建列表时使用的相同属性也可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

下面的 C++ 代码将文本框中的第一段落更改为使用编号列表样式：

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常见问题**

**项目符号列表和编号列表可以导出为 PDF 或图像吗？**

可以。Aspose.Slides 在目标格式支持相应的文本布局和项目符号特性的情况下，会保留列表格式。

**我可以编辑现有演示文稿中的列表吗？**

可以。加载演示文稿，访问目标段落，检查或更新其[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/get_bullet/) 设置，然后保存演示文稿。

**列表可以包含非拉丁文字吗？**

可以。列表项文本支持 Unicode 字符，您可以在多语言演示文稿中创建列表。请确保演示文稿使用的字体支持所需字符。