---
title: C++에서 프레젠테이션의 글머리표 및 번호 매기기 목록 관리
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

Aspose.Slides for C++를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표 및 번호 매기기 목록을 만들고 형식화할 수 있습니다. 목록 항목은 글머리표 설정이 해당 문단 형식을 통해 제어되는 문단입니다.

문단 수준 목록 설정에 접근하려면 [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) 메서드를 사용합니다. 주요 진입점은 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/)이며, 이는 [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) 객체를 반환합니다. 이 객체를 사용하면 글머리표 유형, 기호, 그림, 색상, 크기, 번호 매기기 스타일 및 시작 번호를 설정할 수 있습니다.

이 문서에서는 다음과 같이 수행하는 방법을 보여줍니다:

- 사용자 지정 기호가 있는 글머리표 목록 만들기
- 그림 글머리표 만들기
- 문단 깊이를 설정하여 다단계 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 형식을 확인하고 변경하기
- 문단 텍스트와 함께 실제 목록 표시기와 번호를 읽기

## **글머리표 목록 만들기**

글머리표 목록을 만들려면 [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) 객체를 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)에 추가하고 [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/)을 [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/)으로 설정합니다. 그런 다음 [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_color/), [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) 을 설정하여 글머리표 모양을 제어할 수 있습니다.

다음 C++ 코드에서는 슬라이드에 글머리표 목록을 만드는 방법을 보여줍니다:

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

![기호 글머리표](symbol_bullets.png)

## **번호 매기기 목록 만들기**

항목 순서가 중요한 경우 번호 매기기 목록을 사용합니다. [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/)을 [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/)으로 설정합니다. 또한 [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/)으로 번호 매기기 형식을 선택하거나 목록을 1이 아닌 다른 값에서 시작하도록 하려면 [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/)을 설정할 수 있습니다.

다음 C++ 코드에서는 슬라이드에 번호 매기기 목록을 만드는 방법을 보여줍니다:

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

Aspose.Slides를 사용하면 일반 글머리표 기호를 이미지로 바꿀 수 있습니다. 그림 글머리표는 아이콘이나 작은 투명 PNG 파일처럼 작은 크기에서도 읽을 수 있는 단순한 이미지와 가장 잘 작동합니다.

{{% alert color="info" title="Note" %}}
이상적으로는, 일반 글머리표 기호를 이미지로 교체하려는 경우 투명 배경을 가진 단순한 그래픽을 선택하는 것이 가장 좋습니다. 이러한 이미지는 사용자 지정 글머리표 기호로 잘 작동합니다.

이미지가 매우 작은 크기로 축소된다는 점을 명심하십시오. 따라서 목록에서 글머리표로 사용할 때도 선명하고 시각적으로 효과적인 이미지를 선택하는 것을 강력히 권장합니다.
{{% /alert %}}

그림 글머리표를 만들려면 이미지를 [IPresentation::get_Images](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_images/) 에 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 객체를 [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/) 에 할당합니다. 이미지를 할당하기 전에 [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/)을 [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/)으로 설정하십시오.

예를 들어 "image.png" 파일이 있다고 가정해 보겠습니다:

![글머리표용 그림](picture_for_bullets.png)

다음 C++ 코드에서는 슬라이드에 그림 글머리표를 만드는 방법을 보여줍니다:

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

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/)을 사용하여 목록 항목을 다른 수준에 배치합니다. 레벨 0은 최상위 수준이며, 레벨 1은 그 아래에 중첩됩니다.

다음 C++ 코드에서는 다단계 글머리표 목록을 만드는 방법을 보여줍니다:

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

기존 프레젠테이션에서 목록 형식을 변경하려면 대상 문단에 접근하여 해당 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) 설정을 업데이트합니다. 목록을 만들 때 사용한 동일한 속성을 사용하여 PPT, PPTX 또는 ODP 파일에서 로드된 목록을 검사하거나 수정할 수 있습니다.

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

## **실제 글머리표 값 읽기**

프레젠테이션 내용을 추출할 때 목록 표시기를 문단 텍스트와 함께 유지합니다. [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/) 을 호출하고 [IParagraphFormatEffectiveData::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformateffectivedata/get_bullet/) 에 접근하여 실제 적용된 글머리표 형식을 가져옵니다. [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/)을 읽기 전에 해당 [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_type/)을 확인하십시오.

번호 매기기 목록의 경우 다음 세 값을 구분합니다:

- [get_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstyle/)은 형식을 결정합니다. 예를 들어, 마침표가 뒤따르는 아라비아 숫자나 소문자 알파벳 등이 있습니다.
- [get_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstartwith/)은 번호 매기기 문단 그룹의 시작 번호를 지정합니다.
- [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/)은 특정 문단에 대한 서식이 지정된 표시기를 반환합니다. 예를 들어, 5부터 시작하는 목록의 두 번째 항목은 `6.`을 반환합니다.

각 문단에 [IParagraphFormat::get_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_depth/)을 보존하여 중첩 수준을 유지합니다. 실제 표시기는 전체 계층 구조를 인코딩하지 않습니다: 중첩된 항목은 `6.c.`와 같은 결합된 레이블 대신 `c.`를 반환할 수 있습니다.

다음 독립형 예제는 목록을 생성하고 프레젠테이션에 저장한 뒤 프레젠테이션을 다시 로드하여 각 문단의 텍스트, 깊이, 글머리표 유형 및 실제 값을 보고합니다. 작은 파란색 그림 표시기는 인라인 SVG에서 생성됩니다.

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IBulletFormatEffectiveData.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

{
    auto presentation = System::MakeObject<Presentation>();
    presentation->get_SlideSize()->SetSize(720, 440, SlideSizeScaleType::DoNotScale);
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_Paragraphs()->Clear();

    // 외부 이미지 파일 없이 그림 표시기를 생성합니다.
    auto svg = System::MakeObject<SvgImage>(u"<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    auto bulletImage = presentation->get_Images()->AddImage(svg);

    auto addParagraph = [&](System::String text, int16_t depth, BulletType type, int16_t start = 1, NumberedBulletStyle style = NumberedBulletStyle::BulletArabicPeriod)
    {
        auto paragraph = System::MakeObject<Paragraph>();
        paragraph->set_Text(text);

        auto format = paragraph->get_ParagraphFormat();
        format->set_Depth(depth);
        format->set_MarginLeft(30 + depth * 40);
        format->set_Indent(-28);
        format->set_SpaceAfter(8);
        format->get_DefaultPortionFormat()->set_FontHeight(22);
        format->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
        auto bullet = format->get_Bullet();
        bullet->set_Type(type);
        bullet->set_IsBulletHardColor(NullableBool::True);
        bullet->get_Color()->set_Color(Color::get_Black());
        if (type == BulletType::Numbered)
        {
            bullet->set_NumberedBulletStyle(style);
            bullet->set_NumberedBulletStartWith(start);
        }
        else if (type == BulletType::Symbol)
        {
            bullet->set_Char(u'\u2022');
        }
        else if (type == BulletType::Picture)
        {
            bullet->get_Picture()->set_Image(bulletImage);
        }

        textFrame->get_Paragraphs()->Add(paragraph);
    };

    addParagraph(u"First item", 0, BulletType::Numbered, 5);
    addParagraph(u"Second item", 0, BulletType::Numbered, 5);
    addParagraph(u"Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    addParagraph(u"Back to top level", 0, BulletType::Numbered, 5);
    addParagraph(u"Symbol marker", 0, BulletType::Symbol);
    addParagraph(u"No bullet", 0, BulletType::None);
    addParagraph(u"Picture marker", 0, BulletType::Picture);
    presentation->Save(u"actual_bullet_values.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}

auto loadedPresentation = System::MakeObject<Presentation>(u"actual_bullet_values.pptx");
auto loadedShape = System::ExplicitCast<IAutoShape>(loadedPresentation->get_Slide(0)->get_Shape(0));
System::Console::WriteLine(u"Text | Depth | Type | Actual value");
for (auto paragraph : loadedShape->get_TextFrame()->get_Paragraphs())
{
    auto bullet = paragraph->get_ParagraphFormat()->GetEffective()->get_Bullet();
    auto actualValue = bullet->get_ActualBulletValue();
    System::String marker;
    switch (bullet->get_Type())
    {
        case BulletType::Numbered:
        case BulletType::Symbol:
            marker = actualValue;
            break;
        case BulletType::None:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (no bullet)";
            break;
        case BulletType::Picture:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (image required)";
            break;
        default:
            marker = u"unsupported bullet type";
            break;
    }
    System::Console::WriteLine(u"{0} | {1} | {2} | {3}", paragraph->get_Text(), paragraph->get_ParagraphFormat()->get_Depth(), bullet->get_Type(), marker);
}
loadedPresentation->Dispose();
```

소스 목록은 아래에 표시됩니다.

![5부터 시작하고 중첩된 문자 및 로마 숫자 항목, 기호 표시기, 글머리표 없는 문단, 파란색 그림 표시기를 포함한 목록](actual_bullet_values.png)

보고서는 PowerPoint에 표시된 표시기와 일치합니다:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType::None 및 BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/)의 경우, [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/)은 빈 문자열이 아닌 null `System::String`을 반환합니다. 이 값을 확인하려면 `IsNull`을 사용하십시오. 이러한 유형을 별도로 처리하십시오: 앞의 경우 표시기가 없고, 뒤의 경우 글머리표 이미지를 별도로 추출해야 합니다. 그림 글머리표는 텍스트 표시기만 추출해서는 재현할 수 없습니다.

## **FAQ**

**글머리표 및 번호 매기기 목록을 PDF 또는 이미지로 내보낼 수 있습니까?**

예. 대상 형식이 해당 텍스트 레이아웃 및 글머리표 기능을 지원하면 Aspose.Slides는 목록 형식을 유지합니다.

**기존 프레젠테이션에서 목록을 편집할 수 있습니까?**

예. 프레젠테이션을 로드하고 대상 문단에 접근한 뒤 해당 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) 설정을 검사하거나 업데이트한 다음 프레젠테이션을 저장합니다.

**목록에 비라틴 텍스트를 포함할 수 있습니까?**

예. 목록 항목 텍스트는 유니코드 문자를 포함할 수 있으므로 다국어 프레젠테이션에서도 목록을 만들 수 있습니다. 프레젠테이션에서 사용하는 폰트가 필요한 문자를 지원하는지 확인하십시오.