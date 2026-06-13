---
title: C++ 프레젠테이션에서 글머리표 및 번호 매기기 목록 관리
linktitle: 목록 관리
type: docs
weight: 70
url: /ko/cpp/manage-lists/
keywords:
- 글머리표
- 글머리표 목록
- 번호 매기기 목록
- 기호 글머리표
- 그림 글머리표
- 맞춤형 글머리표
- 다중 레벨 목록
- 글머리표 만들기
- 글머리표 추가
- 목록 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표, 그림, 다중 레벨 및 번호 매기기 목록을 만들고 서식 지정하는 방법을 알아보세요."
---
## **개요**

Aspose.Slides for C++를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표 및 번호 매기기 목록을 만들고 서식 지정할 수 있습니다. 목록 항목은 글머리표 설정이 해당 단락 서식을 통해 제어되는 단락입니다.

Use the [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/get_paragraphformat/) method to access paragraph-level list settings. The main entry point is [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/get_bullet/), which returns an [IBulletFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/) object. With this object, you can set the bullet type, symbol, picture, color, size, numbering style, and starting number.

This article shows how to:

- 사용자 정의 기호로 글머리표 목록 만들기
- 이미지 글머리표 만들기
- 단락 깊이를 설정하여 다중 레벨 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 서식 검사 및 변경

## **글머리표 목록 만들기**

To create a bulleted list, add [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) objects to an [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) and set [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/) to [BulletType::Symbol](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/). You can then set [IBulletFormat::set_Char](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/get_color/), and [IBulletFormat::set_Height](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_height/) to control the bullet appearance.

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

![기호 글머리표](symbol_bullets.png)

## **번호 매기기 목록 만들기**

Use numbered lists when the order of items matters. Set [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/) to [BulletType::Numbered](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/). You can also choose a numbering format with [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) or set [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) when the list should start from a value other than 1.

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

![번호 매기기 글머리표](numbered_bullets.png)

## **그림 글머리표 만들기**

Aspose.Slides allows you to replace a regular bullet symbol with an image. Picture bullets work best with simple images that remain readable at a small size, such as icons or small transparent PNG files.

{{% alert color="primary" %}}
이상적으로, 일반 글머리표 기호를 이미지로 교체하려는 경우 투명한 배경을 가진 간단한 그래픽을 선택하는 것이 가장 좋습니다. 이러한 이미지는 사용자 정의 글머리표 기호로 적합합니다.

이미지는 매우 작은 크기로 축소됩니다. 따라서 리스트에서 글머리표로 사용할 때도 선명하고 시각적으로 효과적인 이미지를 선택할 것을 강력히 권장합니다.
{{% /alert %}}

To create a picture bullet, add an image to [IPresentation::get_Images](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_images/) and assign the returned [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) object to [IBulletFormat::get_Picture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/get_picture/). Set [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/) to [BulletType::Picture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/) before assigning the image.

예를 들어 "image.png" 파일이 있다고 가정해 보겠습니다:

![글머리표용 그림](picture_for_bullets.png)

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

![그림 글머리표](picture_bullets.png)

## **다중 레벨 목록 만들기**

Use [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_depth/) to place list items on different levels. Level 0 is the top level, level 1 is nested below it, and so on.

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

![다중 레벨 목록](multilevel_list.png)

## **기존 목록 변경**

To change list formatting in an existing presentation, access the target paragraph and update its [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/get_bullet/) settings. The same properties used to create lists can be used to inspect or modify lists loaded from a PPT, PPTX, or ODP file.

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

**글머리표 및 번호 매기기 목록을 PDF 또는 이미지로 내보낼 수 있나요?**

Yes. Aspose.Slides preserves list formatting when the target format supports the corresponding text layout and bullet features.

**기존 프레젠테이션에서 목록을 편집할 수 있나요?**

Yes. Load the presentation, access the target paragraph, inspect or update its [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/get_bullet/) settings, and save the presentation.

**목록에 비라틴 텍스트를 포함할 수 있나요?**

Yes. List item text can contain Unicode characters, so you can create lists in multilingual presentations. Make sure the fonts used in the presentation support the characters you need.