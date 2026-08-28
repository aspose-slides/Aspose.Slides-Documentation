---
title: C++에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리표 관리
- 단락 들여쓰기
- 걸쳐 들여쓰기
- 단락 글머리표
- 번호 매기기 목록
- 글머리표 목록
- 단락 속성
- HTML 가져오기
- 텍스트를 HTML로
- 단락을 HTML로
- 단락을 이미지로
- 텍스트를 이미지로
- 단락 내보내기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 단락, 포션, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for C++는 텍스트를 텍스트 프레임, 단락 및 포션의 계층 구조로 표현합니다:

* [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 은 형상의 텍스트 컨테이너를 나타내며 해당 단락 컬렉션에 대한 접근을 제공합니다.
* [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/) 은 텍스트 프레임 내의 하나의 단락을 나타내며 해당 포션 및 단락 수준 서식에 대한 접근을 제공합니다.
* [IPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/) 은 단락 내의 텍스트 실행을 나타냅니다. 각 포션은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 포션을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 가진 텍스트를 포함할 수 있습니다.

## **단락 생성 및 서식 지정**

### **다중 포션을 사용한 단락 생성**

다음 단계는 각각 세 개의 포션을 포함하는 세 개의 단락이 있는 텍스트 프레임을 생성합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 에 접근합니다.
5. 기본 단락을 사용하고 텍스트 프레임에 두 개의 추가 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/) 객체를 추가합니다.
6. 각 단락에 세 개의 포션을 포함하도록 충분한 [IPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/) 객체를 추가합니다. 기본 단락에는 이미 하나의 빈 포션이 포함되어 있습니다.
7. 각 포션의 텍스트를 설정합니다.
8. [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/get_portionformat/) 을 통해 문자 수준 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

이 C++ 예제는 위 단계를 구현합니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **글머리표 및 번호 매기기 목록 생성**

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기는 관련 항목을 더 쉽게 스캔할 수 있게 해줍니다. Aspose.Slides에서는 목록 설정을 [IBulletFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/) 을 통해 정의합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 선택한 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 에 접근합니다.
5. 텍스트 프레임에서 기본 단락을 제거합니다.
6. 기호 글머리표용 [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) 을 생성합니다.
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/) 을 [BulletType::Symbol](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/) 로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락 텍스트, 들여쓰기, 글머리 색상 및 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 두 번째 단락을 생성하고 [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/) 을 [BulletType::Numbered](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/) 로 설정합니다.
11. 번호 매기기 글머리 스타일을 구성하고 단락을 텍스트 프레임에 추가합니다.
12. 프레젠테이션을 저장합니다.

이 C++ 예제는 기호 글머리표와 번호 매기기 글머리표를 생성합니다:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **그림 글머리표 사용**

그림 글머리표를 사용하면 기호나 숫자 대신 사용자 정의 이미지를 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가하고 해당 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 에 접근합니다.
4. 텍스트 프레임에서 기본 단락을 제거합니다.
5. 글머리 이미지를 로드하고 프레젠테이션의 이미지 컬렉션에 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 로 추가합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/) 을 생성하고 텍스트를 설정합니다.
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_type/) 을 [BulletType::Picture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/bullettype/) 로 설정합니다.
8. [ISlidesPicture::set_Image](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidespicture/set_image/) 로 이미지를 지정하고 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

이 C++ 예제는 그림 글머리표를 생성합니다:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **다단계 목록 만들기**

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_depth/) 를 설정하여 목록의 서로 다른 레벨에 단락을 배치합니다. 최상위 레벨은 `0` 깊이를 가집니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 을 만들고 슬라이드에 접근합니다.
2. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가하고 텍스트 프레임에서 기본 단락을 삭제합니다.
3. 네 개의 단락을 만들고 각 글머리 기호를 구성합니다.
4. 각 단락의 [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_depth/) 값을 `0`, `1`, `2`, `3` 으로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

이 C++ 예제는 네 레벨 글머리 목록을 생성합니다:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **번호 매기기 목록 항목을 사용자 지정 값으로 시작**

[IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 를 사용하여 번호 매기기 단락에 표시되는 초기 번호를 설정합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 을 만들고 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가합니다.
2. 도형의 텍스트 프레임에서 기본 단락을 삭제합니다.
3. 세 개의 번호 매기기 단락을 생성합니다.
4. 각 단락에 대해 [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 를 각각 `2`, `3`, `7` 로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

이 C++ 예제는 각 단락에 사용자 지정 시작 번호를 할당합니다:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **단락 레이아웃 및 끝 속성 제어**

### **첫 줄 들여쓰기 설정**

[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락 왼쪽 여백에 대해 첫 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동하려면 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginleft/) 를 사용하고, 첫 줄만 이동하려면 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 를 사용합니다.

아래 예제는 여러 단락을 생성하고 서로 다른 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 미치는 영향을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
5. 여러 단락을 만들고 각각에 서로 다른 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![단락의 첫 줄 들여쓰기](first_line_indent.png)

### **걸쳐 들여쓰기 설정**

걸쳐 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 로 이 효과를 만듭니다. 들여쓰기를 음수 값으로 설정하면 단락 본문에 비해 첫 줄이 왼쪽으로 이동합니다.

실제로 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginleft/) 은 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 은 그 여백에 대한 첫 줄의 위치를 정의합니다. 걸쳐 들여쓰기를 만들려면 양수 margin-left 값을 지정하고 음수 indent 값을 지정합니다.

이 서식은 서지, 참고 문헌, 용어집 항목 및 줄 바꿈이 첫 줄 첫 문자 아래가 아니라 단락 본문 아래에 정렬되어야 하는 기타 단락에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
5. 각 단락에 대해 양의 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginleft/) 값을 설정합니다.
6. 걸쳐 들여쓰기 효과를 만들기 위해 음의 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_indent/) 값을 설정합니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

이 코드는 단락에 걸쳐 들여쓰기를 설정하는 방법을 보여줍니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![단락의 걸쳐 들여쓰기](hanging_indent.png)

### **단락 끝 실행 속성 설정**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) 은 단락 끝 표시의 서식을 제어합니다. 다음 예제는 두 번째 단락의 끝 표시에게 글꼴 크기와 라틴 글꼴을 할당합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 을 로드하고 슬라이드에 접근합니다.
2. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가하고 기본 단락을 지웁니다.
3. 두 개의 단락을 만들고 각각에 텍스트 포션을 추가합니다.
4. 두 번째 단락의 끝 표시용 [PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portionformat/) 을 생성합니다.
5. [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_fontheight/) 과 [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_latinfont/) 을 설정합니다.
6. [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) 로 서식을 적용하고 프레젠테이션을 저장합니다.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **단락 내용 가져오기 및 내보내기**

### **HTML 텍스트를 단락으로 가져오기**

[IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphcollection/addfromhtml/) 를 사용하면 HTML 마크업을 텍스트 프레임의 단락 및 포션으로 변환할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 슬라이드에 접근하고 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 추가합니다.
3. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 에 접근하고 기본 단락을 삭제합니다.
4. 소스 HTML 파일을 읽습니다.
5. HTML 문자열을 [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphcollection/addfromhtml/) 에 전달합니다.
6. 수정된 프레젠테이션을 저장합니다.

이 C++ 예제는 HTML을 텍스트 프레임에 가져옵니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **단락 텍스트를 HTML로 내보내기**

[IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphcollection/exporttohtml/) 를 사용하면 선택한 단락 범위를 HTML로 내보낼 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 만들고 원하는 프레젠테이션을 로드합니다.
2. 슬라이드에 접근하고 텍스트를 포함하는 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 를 찾습니다.
3. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 에 접근합니다.
4. 시작 단락 인덱스와 내보낼 단락 수를 지정하여 [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphcollection/exporttohtml/) 를 호출합니다.
5. 반환된 HTML 문자열을 파일에 씁니다.

이 C++ 예제는 첫 번째 텍스트 도형의 모든 단락을 내보냅니다:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **단락을 이미지로 렌더링**

[IParagraph::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/getimage/) 은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 를 반환합니다. 반환된 이미지는 [IImage::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/save/) 로 파일이나 스트림에 저장할 수 있습니다. 전체 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[IParagraph::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/getimage/) 은 단락을 부모 컬렉션에서 찾을 수 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `nullptr` 을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 해제해야 합니다.

#### **기본 배율로 단락 렌더링**

sample.pptx 라는 프레젠테이션 파일에 하나의 슬라이드가 있고, 첫 번째 도형은 세 개의 단락을 포함하는 텍스트 상자라고 가정합니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 두 번째 단락을 기본 배율로 렌더링하고 PNG 형식으로 저장합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

결과:

![단락 이미지](paragraph_to_image_output.png)

#### **테이블 셀에서 스케일링을 사용해 단락 렌더링**

`float scaleX` 와 `float scaleY` 매개변수를 받는 [IParagraph::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/getimage/) 오버로드를 사용해 가로 및 세로 스케일 팩터를 설정합니다. 다음 예제는 테이블을 만들고 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링한 뒤 PNG 이미지로 저장합니다.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

스케일 팩터 `1` 은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 축 모두 `2` 로 설정하면 이미지의 너비와 높이가 기본 차원의 약 두 배가 되어 픽셀 수는 네 배가 됩니다. 큰 팩터는 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기도 증가합니다. `1` 이하의 팩터는 세부 사항이 적은 작은 이미지를 생성합니다. 가로와 세로 팩터를 동일하게 사용하면 단락의 가로 세로 비율을 유지할 수 있으며, 다른 값을 사용하면 출력이 독립적으로 늘어나거나 줄어듭니다.

전체 도형을 [IShape::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/getimage/) 로 렌더링하는 것은 도형의 채우기, 테두리 또는 기타 시각적 컨텍스트가 포함되어야 할 때 여전히 유용합니다. 단락만 이미지로 만들 때는 [IParagraph::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/getimage/) 를 사용합니다.

## **FAQ**

**텍스트 프레임 내부의 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/set_wraptext/) 를 사용하여 래핑을 비활성화하면 텍스트 프레임 가장자리에서 줄이 끊기지 않게 됩니다.

**특정 단락의 슬라이드 상 정확한 경계값을 얻으려면 어떻게 해야 하나요?**

[IParagraph::GetRect](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/getrect/) 을 사용해 단락의 경계 사각형을 가져올 수 있습니다. [IPortion::GetRect](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/getrect/) 은 개별 포션의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데 또는 양쪽 맞춤)은 어디에서 제어됩니까?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_alignment/) 은 단락 수준 설정이며 개별 포션 서식과 관계없이 전체 단락에 적용됩니다.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. 개별 포션에 대해 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_languageid/) 를 사용하면 하나의 단락에 여러 언어 텍스트를 포함시킬 수 있습니다.