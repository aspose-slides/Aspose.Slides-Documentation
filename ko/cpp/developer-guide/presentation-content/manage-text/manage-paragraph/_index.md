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
- 내어쓰기
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
description: "Aspose.Slides for C++를 사용하여 단락, 구간, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for C++ 은 텍스트를 텍스트 프레임, 단락, 및 구간의 계층 구조로 나타냅니다:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 은 도형 내의 텍스트 컨테이너를 나타내며 단락 컬렉션에 대한 접근을 제공합니다.
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) 은 텍스트 프레임 내의 하나의 단락을 나타내며 구간 및 단락 수준 서식에 대한 접근을 제공합니다.
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) 은 단락 내의 텍스트 실행을 나타냅니다. 각 구간은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구간을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

도형의 텍스트 프레임에서 단락을 만들고 구간을 사용하여 개별 텍스트 실행을 서식 지정합니다. 이 섹션에서는 각 단락에 여러 구간을 결합하고 서로 다른 색상, 글꼴 크기 및 스타일을 적용하는 방법을 보여줍니다.

### **여러 구간이 있는 단락 만들기**

다음 C++ 예제는 세 개의 단락을 만들고 각각의 [IParagraph::get_Portions](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_portions/) 컬렉션에 세 개의 텍스트 실행을 포함합니다. 기본 단락과 빈 구간을 재사용한 뒤 나머지 단락과 구간을 추가합니다. 서식은 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/)을 통해 적용됩니다. 각 단락의 첫 번째 구간은 빨간색, 굵게, 15포인트이며, 두 번째는 파란색, 이탤릭, 18포인트입니다. 세 번째 구간은 기본 서식을 유지합니다:

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
for (auto paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (auto portionIndex = 0; portionIndex < portionCount; portionIndex++)
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

## **글머리표 및 번호 매기기 목록 만들기**

단락 텍스트를 기호, 번호 또는 사용자 정의 이미지가 있는 목록으로 구성합니다. 이 섹션의 예제는 글머리표 서식, 다중 레벨 목록 및 사용자 정의 시작 번호를 다룹니다.

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기를 사용하면 관련 항목을 쉽게 스캔할 수 있습니다. Aspose.Slides에서는 목록 설정을 [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/)을 통해 정의합니다.

이 C++ 예제는 같은 텍스트 프레임에 기호 글머리표와 번호 매기기 항목을 추가합니다. [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/)은 글머리표 유형을 선택하고, [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/)은 기호를 제공하며, [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/)은 번호 매기기 스타일을 선택합니다. 두 항목 모두 높이가 100%이고 단락 들여쓰기가 25포인트인 검은색 글머리표를 사용합니다:

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

그림 글머리표를 사용하면 기호나 번호 대신 사용자 정의 이미지를 사용할 수 있습니다.

예제는 작업 디렉터리에 `bullets.png`가 있어야 합니다. 이 C++ 예제는 프레젠테이션의 이미지 컬렉션에 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)으로 이미지를 추가하고 이를 단락 글머리표로 사용합니다. [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/)을 그림 글머리표로 설정하고, [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/)을 통해 이미지를 할당합니다. [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/)을 100%로 설정하여 글머리표 크기를 단락 텍스트에 상대적으로 지정합니다:

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

### **다중 레벨 목록 만들기**

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/)을 설정하여 목록의 다양한 레벨에 단락을 배치합니다. 최상위 레벨은 `0` 깊이를 가집니다.

이 C++ 예제는 [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) 값을 0부터 3까지 네 개의 단락에 할당하여 하나의 텍스트 프레임 내에 계층을 생성합니다. 각 단락은 기호 글머리표를 사용하며, [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/)을 사용해 원형 글머리표와 하이픈을 교대로 지정해 인접 레벨을 구분합니다:

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

### **사용자 정의 값으로 번호 매기기 목록 시작**

[IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/)을 사용하여 번호 매기기 단락의 초기 번호를 설정합니다.

이 C++ 예제는 세 개의 단락에 번호 매기기를 사용하도록 [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/)을 설정하고, [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 값을 각각 2, 3, 7로 지정합니다. 시작 값은 각 단락마다 별도로 구성되어 표시되는 번호가 건너뛰도록 합니다:

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

단락 여백과 들여쓰기를 조정하여 첫 번째 줄과 줄 바꿈된 줄의 위치를 제어합니다. 또한 눈에 보이는 텍스트 구간과 별도로 단락 끝 표시를 서식 지정할 수 있습니다.

### **첫 줄 들여쓰기 설정**

[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) 메서드를 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락 왼쪽 여백에 대해 첫 번째 줄만 이동시킵니다. 양수 값은 첫 번째 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬된 상태를 유지합니다.

전체 단락을 이동해야 할 경우 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/)를 사용하고, 첫 줄만 이동하려면 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/)를 사용합니다.

다음 예제는 세 단락에 동일한 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) 20포인트와 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) 값 0, 20, 40포인트를 적용합니다. 첫 번째 줄은 점차 큰 오프셋에서 시작하고, 줄 바꿈된 줄은 동일한 왼쪽 여백을 유지합니다:

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

### **내어쓰기 설정**

내어쓰기는 첫 번째 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) 메서드에 음수 값을 전달하여 첫 번째 줄을 단락 본문에 대해 왼쪽으로 이동시킵니다.

실제로는 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/)가 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/)가 해당 여백에 대한 첫 번째 줄 위치를 정의합니다. 내어쓰기를 만들려면 `MarginLeft` 값을 양수로, `Indent` 값을 음수로 설정합니다.

이 서식은 참고 문헌, 인용, 용어 사전 항목 및 줄 바꿈된 줄이 첫 번째 줄의 첫 문자 아래가 아니라 단락 본문 아래에 맞춰져야 하는 다른 단락에 유용합니다.

다음 C++ 예제는 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) 값을 40 및 60포인트와 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) 값을 -20 및 -30포인트와 짝지어 사용합니다. 각 단락에서 첫 번째 줄은 줄 바꿈된 줄보다 왼쪽에 시작되며, 두 번째 단락은 더 깊은 내어쓰기를 가집니다:

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

![단락의 내어쓰기](hanging_indent.png)

### **단락 끝 실행 속성 설정**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) 메서드는 단락 끝 표시의 서식을 제어합니다. 예제는 최소 하나의 슬라이드가 포함된 `Test.pptx`를 로드합니다. 다음 예제는 [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)을 만들고, [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/)을 48포인트, [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/)을 Times New Roman으로 설정합니다. 이 서식을 두 번째 단락의 끝 표시에 할당하여 가시 텍스트 구간은 변경되지 않게 합니다:

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

## **렌더링된 라인 수 계산**

줄 끝의 자동 줄 바꿈 및 구두점에 영향을 주는 단락 규칙은 [Control Line Breaking](/slides/ko/cpp/text-formatting/#control-line-breaking) 및 [Control Hanging Punctuation](/slides/ko/cpp/text-formatting/#control-hanging-punctuation) 를 참조하십시오.

[IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/)을 사용하여 텍스트 레이아웃 후 단락이 차지하는 라인 수를 셉니다(자동 줄 바꿈 포함). 이는 프레젠테이션 템플릿에서 텍스트 길이와 레이아웃을 확인할 때 유용합니다.

단락은 [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/)의 항목이며 여러 렌더링된 라인을 차지할 수 있습니다. 단락 내에 명시적 줄 바꿈을 삽입하면 새로운 라인이 강제되지만 추가 단락은 생성되지 않습니다. 자동 줄 바꿈은 텍스트에 명시적 줄 바꿈 문자를 삽입하지 않고 가용 너비에 따라 라인을 생성합니다. 따라서 단락 수나 줄 바꿈 문자 수를 세는 것은 실제 렌더링된 라인 수를 제공하지 않습니다.

다음 예제는 텍스트 도형을 만들고, 라인을 계산한 뒤 도형을 좁히고, 더 짧은 문자열로 텍스트를 교체합니다. 예제는 [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/)을 활성화하고 [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/)를 비활성화하여 도형 너비가 텍스트를 자동으로 축소하거나 도형을 자동으로 리사이즈하지 않도록 합니다. 각 측정은 [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/)을 사용합니다. 도형 크기는 포인트 단위입니다. 마지막으로 예제는 또 다른 단락을 추가하고 텍스트 프레임 전체의 라인 수를 합산합니다:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

이 텍스트와 차원으로 도형을 좁히면 라인 수가 증가하고, 짧은 문자열로 교체하면 라인 수가 감소합니다. 정확한 카운트는 폰트 가용성 및 대체, 폰트 크기, 여백, 들여쓰기, 줄 바꿈 및 자동 맞춤 설정에 따라 달라질 수 있습니다. 템플릿을 확인할 때는 대상 환경에 사용될 폰트와 레이아웃 설정을 사용하십시오.

라인 수만으로 텍스트가 컨테이너를 초과하는지 여부를 판단할 수 없습니다. 사용 가능한 높이, 라인 높이, 단락 및 라인 간격, 자동 맞춤 동작도 중요합니다; 줄 바꿈이 비활성화된 경우 단일 라인만으로도 가용 너비를 초과할 수 있습니다.

## **단락 콘텐츠 가져오기 및 내보내기**

HTML을 사용하여 텍스트를 프레젠테이션에 가져오거나 기존 단락을 외부에서 사용할 수 있도록 내보낼 수 있습니다. 이 섹션에서는 테이블 셀 내 단락을 포함한 개별 단락을 이미지로 렌더링하는 방법도 보여줍니다.

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/)을 사용하여 HTML 마크업을 텍스트 프레임의 단락 및 구간으로 변환합니다.

이 C++ 예제는 파일에서 HTML을 읽고 마크업을 [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/)에 전달합니다. 텍스트 프레임의 기본 단락을 지워서 프레임에 가져온 콘텐츠만 포함하도록 합니다. 직사각형 도형은 슬라이드 각 측면에 10포인트 여백을 남깁니다:

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

[ParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/exporttohtml/)을 사용하여 선택된 단락 범위를 HTML로 내보냅니다. 프레젠테이션 텍스트를 웹사이트에 재사용할 때 프레젠테이션의 글꼴, 크기 또는 텍스트 상자 스타일을 전달하지 않고 로컬 강조만 유지하고 싶을 수 있습니다. [TextToHtmlConversionOptions::set_TextInheritanceLimit](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/set_textinheritancelimit/)을 설정하여 내보내기가 서식 상속을 얼마나 따라갈지 제어합니다.

[샘플 프레젠테이션](text-inheritance.pptx)을 다운로드하고 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 텍스트 "Inherited text; explicit red 18pt"가 포함된 텍스트 도형이 하나 있습니다. 입력은 의도적으로 여러 서식 레벨을 사용합니다:

- 프레젠테이션의 기본 텍스트 스타일은 Calibri와 28pt 크기를 제공합니다.
- 텍스트 프레임의 1단계 텍스트 스타일은 파란색 텍스트와 이탤릭을 제공합니다.
- 단락은 굵은 텍스트를 명시적으로 설정합니다.
- 두 번째 구간 "explicit red 18pt"는 빨간색 텍스트와 18pt 크기를 명시적으로 설정합니다.

다음 예제는 동일한 단락을 세 번 내보냅니다. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/)을 내보내기 메서드에 전달하고 각 결과를 별도의 UTF-8 HTML 파일로 기록합니다:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <Export/TextInheritanceLimit.h>
#include <Export/TextToHtmlConversionOptions.h>
#include <system/array.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"text-inheritance.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto modes = MakeArray<TextInheritanceLimit>({TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly});
    auto fileNames = MakeArray<String>({u"All.html", u"TextBox.html", u"ParagraphOnly.html"});

    for (auto i = 0; i < modes->get_Length(); i++)
    {
        auto options = MakeObject<TextToHtmlConversionOptions>();
        options->set_TextInheritanceLimit(modes[i]);

        auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), options);
        File::WriteAllText(fileNames[i], html, Encoding::get_UTF8());
    }
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

생성된 HTML에는 첫 번째 구간 "Inherited text; "에 대한 다음 CSS가 포함됩니다. 표에는 관련 선언만 나열하고 다른 생성 속성은 명확성을 위해 생략했습니다.

| 출력 | 첫 번째 구간에 대한 관련 CSS | 모양 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri가 사용 가능할 경우 28pt 크기의 파란색, 굵게, 이탤릭 텍스트 |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 파란색, 굵게, 이탤릭 텍스트; 주변 페이지 또는 브라우저가 글꼴 패밀리와 크기를 제공 |
| `ParagraphOnly.html` | `font-weight:bold` | 굵은 텍스트; 주변 페이지 또는 브라우저가 글꼴 패밀리, 크기, 색상 및 이탤릭 스타일을 제공 |

두 번째 구간은 모든 출력에서 `color:#ff0000`, `font-size:18pt`, `font-weight:bold`를 유지합니다. 또한 `All`과 `TextBox`에서는 이탤릭을 유지하지만 `ParagraphOnly`에서는 유지하지 않습니다. 상속 제한은 단락이나 구간에 명시적으로 할당된 서식을 제거하지 않습니다.

같은 브라우저에서 파일을 열어 비교하십시오. 제한된 두 모드에서는 누락된 CSS 속성이 대상 페이지의 스타일이나 브라우저 기본값으로 해결되므로 최종 모양은 HTML이 사용되는 위치에 따라 달라집니다.

### **단락을 이미지로 렌더링**

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/)은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/)을 반환합니다. 결과를 [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/)로 파일이나 스트림에 저장합니다. 포함된 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/)은 단락을 상위 컬렉션에서 찾을 수 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `nullptr`을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 해제하십시오.

#### **기본 배율로 단락 렌더링**

예제는 첫 번째 도형이 세 개의 단락을 포함한 텍스트 상자인 `sample.pptx` 프레젠테이션을 사용합니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 인덱스 1의 두 번째 단락을 선택하고 배율 매개변수 없이 [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/)을 호출합니다. 도형에 필요한 단락이 포함되어 있는지 확인하고, 렌더링이 이미지를 반환하는지 확인한 후 [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/)를 사용해 PNG 형식으로 저장합니다. 저장 후 이미지를 해제합니다.

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

#### **표 셀 안의 단락을 배율과 함께 렌더링**

`float scaleX`와 `float scaleY` 매개변수를 받아 가로 및 세로 배율을 설정하는 [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) 오버로드를 사용합니다. 다음 예제는 표를 만든 뒤 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링하고 PNG 이미지로 저장합니다.

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

배율 `1`은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 배(`2`)를 지정하면 이미지의 너비와 높이가 대략 두 배가 되어 픽셀 수가 네 배가 됩니다. 큰 배율은 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기도 증가합니다. `1`보다 작은 배율은 세부 정보가 적은 작은 이미지를 생성합니다. 비율을 동일하게 유지하면 단락의 종횡비가 보존되고, 가로와 세로 배율을 다르게 지정하면 출력이 각각 늘어납니다.

[IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/)를 사용해 전체 도형을 렌더링하는 경우에는 도형의 채우기, 테두리 또는 기타 시각적 컨텍스트가 포함되어야 할 때 유용합니다. 단락 전용 이미지는 [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/)를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/)을 사용하여 줄 바꿈을 비활성화하면 라인이 텍스트 프레임 가장자리에서 끊어지지 않습니다.

**특정 단락의 슬라이드 상에서 정확한 경계값을 얻으려면 어떻게 해야 하나요?**

[IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/)을 사용하여 단락의 경계 사각형을 가져옵니다. [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/)은 개별 구간의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데, 양쪽 맞춤)은 어디에서 제어되나요?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/)은 단락 수준 설정이며 개별 구간 서식과 무관하게 전체 단락에 적용됩니다.

각 라인 내 다른 글꼴 크기의 구간을 수직 정렬하려면 [Align Fonts Within a Line](/slides/ko/cpp/text-formatting/#align-fonts-within-a-line)를 참조하십시오.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/)을 사용하면 개별 구간마다 언어를 지정할 수 있어 하나의 단락에 여러 언어를 포함할 수 있습니다.