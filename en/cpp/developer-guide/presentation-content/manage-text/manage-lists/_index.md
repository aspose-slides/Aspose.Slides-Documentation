---
title: Manage Bulleted and Numbered Lists in Presentations in C++
linktitle: Manage Lists
type: docs
weight: 70
url: /cpp/manage-lists/
keywords:
- bullet
- bulleted list
- numbered list
- symbol bullet
- picture bullet
- custom bullet
- multilevel list
- create bullet
- add bullet
- add list
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn how to create and format bulleted, picture, multilevel, and numbered lists in PowerPoint and OpenDocument presentations using Aspose.Slides for C++."
---

## **Overview**

Aspose.Slides for C++ lets you create and format bulleted and numbered lists in PowerPoint and OpenDocument presentations. A list item is a paragraph whose bullet settings are controlled through its paragraph format.

Use the [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) method to access paragraph-level list settings. The main entry point is [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/), which returns an [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) object. With this object, you can set the bullet type, symbol, picture, color, size, numbering style, and starting number.

This article shows how to:

- create a bulleted list with a custom symbol
- create a picture bullet
- create a multilevel list by setting paragraph depth
- create a numbered list
- inspect and change list formatting in an existing presentation

## **Create a Bulleted List**

To create a bulleted list, add [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) objects to an [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) and set [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) to [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). You can then set [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_color/), and [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) to control the bullet appearance.

The following C++ code demonstrates how to create a bulleted list in a slide:

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

The result:

![The symbol bullets](symbol_bullets.png)

## **Create a Numbered List**

Use numbered lists when the order of items matters. Set [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) to [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). You can also choose a numbering format with [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) or set [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) when the list should start from a value other than 1.

The following C++ code shows how to create a numbered list in a slide:

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

The result:

![The numbered bullets](numbered_bullets.png)

## **Create a Picture Bullet**

Aspose.Slides allows you to replace a regular bullet symbol with an image. Picture bullets work best with simple images that remain readable at a small size, such as icons or small transparent PNG files.

 {{% alert color="primary" %}}

Ideally, if you plan to replace the regular bullet symbol with an image, it's best to choose a simple graphic with a transparent background. Such images work well as custom bullet symbols.

Keep in mind that the image will be scaled down to a very small size. For that reason, we strongly recommend selecting an image that remains clear and visually effective when used as a bullet in a list.

{{% /alert %}}

To create a picture bullet, add an image to [IPresentation::get_Images](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_images/) and assign the returned [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) object to [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/). Set [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) to [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) before assigning the image.

Let's say we have an "image.png":

![A picture for the bullets](picture_for_bullets.png)

The following C++ code shows how to create picture bullets in a slide:

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

The result:

![The picture bullets](picture_bullets.png)

## **Create a Multilevel List**

Use [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) to place list items on different levels. Level 0 is the top level, level 1 is nested below it, and so on.

The following C++ code shows how to create a multilevel bulleted list:

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

The result:

![The multilevel list](multilevel_list.png)

## **Change an Existing List**

To change list formatting in an existing presentation, access the target paragraph and update its [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) settings. The same properties used to create lists can be used to inspect or modify lists loaded from a PPT, PPTX, or ODP file.

The following C++ code changes the first paragraph in a text frame to use a numbered list style:

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

## **FAQ**

**Can bulleted and numbered lists be exported to PDF or images?**

Yes. Aspose.Slides preserves list formatting when the target format supports the corresponding text layout and bullet features.

**Can I edit lists in existing presentations?**

Yes. Load the presentation, access the target paragraph, inspect or update its [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) settings, and save the presentation.

**Can lists contain non-Latin text?**

Yes. List item text can contain Unicode characters, so you can create lists in multilingual presentations. Make sure the fonts used in the presentation support the characters you need.
