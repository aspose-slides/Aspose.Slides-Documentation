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
- 심볼 글머리표
- 그림 글머리표
- 사용자 지정 글머리표
- 다단계 목록
- 글머리표 만들기
- 글머리표 추가
- 목록 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표, 그림, 다단계 및 번호 매기기 목록을 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for C++를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표 및 번호 매기기 목록을 만들고 서식 지정할 수 있습니다. 목록 항목은 글머리표 설정이 해당 단락 서식을 통해 제어되는 단락입니다.

단락 수준 목록 설정에 액세스하려면 [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/get_paragraphformat/) 메서드를 사용합니다. 주요 진입점은 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/get_bullet/)이며, 이는 [IBulletFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/) 객체를 반환합니다. 이 객체를 사용하여 글머리표 유형, 기호, 그림, 색상, 크기, 번호 매기기 스타일 및 시작 번호를 설정할 수 있습니다.

이 문서에서는 다음 방법을 보여줍니다:

- 사용자 지정 기호로 글머리표 목록 만들기
- 그림 글머리표 만들기
- 단락 깊이를 설정하여 다단계 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 서식 검사 및 변경

## **글머리표 목록 만들기**

글머리표 목록을 만들려면 [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) 객체를 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 추가하고 [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/)을 [BulletType::Symbol](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/)으로 설정합니다. 그런 다음 [IBulletFormat::set_Char](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/get_color/), 및 [IBulletFormat::set_Height](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_height/)을 설정하여 글머리표 모양을 제어할 수 있습니다.

다음 C++ 코드는 슬라이드에서 글머리표 목록을 만드는 방법을 보여줍니다:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

결과:

![심볼 글머리표](symbol_bullets.png)

## **번호 매기기 목록 만들기**

항목 순서가 중요한 경우 번호 매기기 목록을 사용합니다. [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/)을 [BulletType::Numbered](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/)으로 설정합니다. 또한 [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/)으로 번호 매기기 형식을 선택하거나 목록을 1이 아닌 다른 값부터 시작하려면 [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/)을 설정할 수 있습니다.

다음 C++ 코드는 슬라이드에서 번호 매기기 목록을 만드는 방법을 보여줍니다:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

결과:

![번호 매기기 글머리표](numbered_bullets.png)

## **그림 글머리표 만들기**

Aspose.Slides를 사용하면 일반 글머리표 기호를 이미지로 교체할 수 있습니다. 그림 글머리표는 작은 크기에서도 가독성을 유지할 수 있는 간단한 아이콘이나 투명 PNG 파일과 같은 이미지에 가장 적합합니다.

{{% alert color="info" %}}
가능하면 일반 글머리표 기호를 이미지로 교체하려는 경우 투명 배경이 있는 간단한 그래픽을 선택하는 것이 가장 좋습니다. 이러한 이미지는 사용자 지정 글머리표 기호로 잘 작동합니다.

이미지는 매우 작은 크기로 축소되므로 목록에 사용될 때도 선명하고 시각적으로 효과적인 이미지를 선택하는 것이 좋습니다.
{{% /alert %}}

그림 글머리표를 만들려면 이미지를 [IPresentation::get_Images](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_images/)에 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 [IBulletFormat::get_Picture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/get_picture/)에 할당합니다. 이미지를 할당하기 전에 [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/)을 [BulletType::Picture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/)으로 설정합니다.

예를 들어 "image.png"가 있다고 가정해 보겠습니다:

![글머리표용 이미지](picture_for_bullets.png)

다음 C++ 코드는 슬라이드에서 그림 글머리표를 만드는 방법을 보여줍니다:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

결과:

![그림 글머리표](picture_bullets.png)

## **다단계 목록 만들기**

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_depth/)을 사용하여 목록 항목을 다른 수준에 배치합니다. 0 수준은 최상위 수준이며, 1 수준은 그 아래에 중첩됩니다.

다음 C++ 코드는 다단계 글머리표 목록을 만드는 방법을 보여줍니다:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

결과:

![다단계 목록](multilevel_list.png)

## **기존 목록 변경**

기존 프레젠테이션에서 목록 서식을 변경하려면 대상 단락에 접근하고 해당 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/get_bullet/) 설정을 업데이트합니다. PPT, PPTX 또는 ODP 파일에서 로드한 목록에도 동일한 속성을 사용하여 검사하거나 수정할 수 있습니다.

다음 C++ 코드는 텍스트 프레임의 첫 번째 단락을 번호 매기기 목록 스타일로 변경합니다:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

### 글머리표와 번호 매기기 목록을 PDF 또는 이미지로 내보낼 수 있나요?

예. Aspose.Slides는 대상 형식이 해당 텍스트 레이아웃 및 글머리표 기능을 지원하는 경우 목록 서식을 유지합니다.

### 기존 프레젠테이션에서 목록을 편집할 수 있나요?

예. 프레젠테이션을 로드하고 대상 단락에 접근한 뒤 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/get_bullet/) 설정을 검사하거나 업데이트한 다음 프레젠테이션을 저장하면 됩니다.

### 목록에 라틴 문자가 아닌 텍스트를 포함할 수 있나요?

예. 목록 항목 텍스트는 Unicode 문자를 포함할 수 있으므로 다국어 프레젠테이션에서도 목록을 만들 수 있습니다. 프레젠테이션에 사용된 글꼴이 필요한 문자를 지원하는지 확인하십시오.