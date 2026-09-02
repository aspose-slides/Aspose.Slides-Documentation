---
title: C++에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/cpp/presentation-comments/
keywords:
- 주석
- 최신 주석
- PowerPoint 주석
- 프레젠테이션 주석
- 슬라이드 주석
- 주석 추가
- 주석 접근
- 주석 편집
- 주석 회신
- 주석 제거
- 주석 삭제
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션 주석을 관리합니다: PowerPoint 프레젠테이션에서 주석을 빠르고 쉽게 추가, 읽기, 편집, 회신 및 제거합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for C++를 사용하여 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 타입을 소개하고, 슬라이드에 주석을 추가하고, 기존 주석에 접근하며, 회신 및 최신 주석을 다루고, 프레젠테이션에서 주석을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 흔히 발생하는 검토 및 협업 시나리오를 다루며, 작성자별 주석 할당, 주석 텍스트 및 메타데이터 읽기, 회신 체인 구축, 선택된 주석 또는 모든 주석 제거 등을 포함합니다.

PowerPoint에서 주석은 슬라이드에 표시되는 주석 형태로 나타납니다. 주석을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

## **프레젠테이션에 주석을 추가하는 이유**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 주석을 사용할 수 있습니다.

Aspose.Slides for C++는 주석 작업을 위한 다음 API를 제공합니다.

* [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 – 프레젠테이션의 주석 작성자에 접근합니다.
* [ICommentCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icommentcollection/) 인터페이스 – 개별 작성자와 연결된 주석을 나타냅니다.
* [IComment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icomment/) 인터페이스 – 작성자, 생성 시간, 위치, 텍스트 등 주석에 대한 정보를 제공합니다.
* [CommentAuthor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/commentauthor/) 클래스 – 이름, 이니셜 및 연결된 주석을 포함한 작성자 정보를 제공합니다.

## **슬라이드 주석 추가**

다음 예제는 PowerPoint 프레젠테이션에 슬라이드 주석을 추가하는 방법을 보여줍니다.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **슬라이드 주석 접근**

다음 예제는 PowerPoint 프레젠테이션에서 기존 주석에 접근하는 방법을 보여줍니다.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **주석에 회신 달기**

부모 주석은 회신 계층 구조의 최상위 원본 주석입니다. [IComment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icomment/) 인터페이스의 [get_ParentComment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icomment/get_parentcomment/) 및 [set_ParentComment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icomment/set_parentcomment/) 메서드를 사용하여 주석의 부모를 가져오거나 설정할 수 있습니다.

다음 예제는 회신을 추가하고 결과 주석 계층 구조를 검사하는 방법을 보여줍니다.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* [IComment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icomment/) 인터페이스의 [Remove](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icomment/remove/) 메서드로 주석을 삭제하면 해당 주석에 대한 모든 회신도 함께 삭제됩니다.
* [set_ParentComment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icomment/set_parentcomment/) 메서드가 순환 참조를 만들 경우, [PptxEditException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 주석 추가**

최신 주석은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위와 연결될 수 있습니다. [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icommentcollection/addmoderncomment/) 메서드는 슬라이드와 주석 마커 좌표 외에 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 인수를 추가로 받습니다.

도형 인수에 `nullptr`를 전달하면 주석은 슬라이드 수준 주석이 됩니다. 마커는 제공된 좌표에 배치되지만 특정 도형과 연결되지 않으므로 [IModernComment::get_Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_shape/)은 `nullptr`를 반환합니다. [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/)이 제공되면 주석은 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 마커 위치를 정의하고, 도형 연결은 [IModernComment::get_Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_shape/)을 통해 확인할 수 있습니다.

### **도형에 최신 주석 고정하기**

다음 예제는 슬라이드 수준 최신 주석과 특정 AutoShape에 고정된 최신 주석을 모두 생성한 뒤, 각각의 주석에서 연결된 도형을 읽어옵니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **다양한 도형 유형에 주석 고정하기**

[IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/)을 구현하는 모든 슬라이드 객체를 도형 고정점으로 사용할 수 있습니다. 일반적인 예로는 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iconnector/), 그리고 차트와 같은 [IGraphicalObject](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igraphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반적인 도형 유형을 만든 뒤 각각에 최신 주석을 연결합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");
auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **텍스트에 주석 고정하고 상태 설정하기**

[IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)에 연결된 최신 주석의 경우, [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_textselectionstart/) 및 [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/set_textselectionstart/) 메서드가 도형 텍스트 프레임 내 선택된 텍스트의 시작 위치를 제어합니다. 마찬가지로, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_textselectionlength/) 및 [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/set_textselectionlength/) 메서드가 선택 길이를 제어합니다. 이 메서드들을 함께 사용하면 주석을 AutoShape 내부의 특정 텍스트 범위와 연결할 수 있습니다.

[IModernComment::get_Status](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_status/) 및 [IModernComment::set_Status](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/set_status/) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/cpp/aspose.slides/moderncommentstatus/) 열거형 값 중 하나를 사용합니다.

- `NotDefined` — 특정 최신 주석 상태가 정의되지 않음.
- `Active` — 주석이 활성 상태임.
- `Resolved` — 주석이 해결됨.
- `Closed` — 주석이 닫힘.

다음 예제는 도형에 고정된 최신 주석을 생성하고, 텍스트 선택과 연결한 뒤, 해결 상태로 표시하고, 프레젠테이션을 저장한 후 파일을 다시 열어 값을 확인합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **기존 최신 주석 검사하기**

기존 프레젠테이션을 검사하려면 [IModernComment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/)를 구현하는 주석을 확인한 뒤, [IModernComment::get_Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_textselectionlength/), [IModernComment::get_Status](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_status/)를 조사합니다. `nullptr` 도형은 슬라이드 수준 주석을 나타냅니다. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)에 고정된 경우, 텍스트 선택 메서드가 도형 텍스트 프레임 내 연관된 범위를 식별합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **주석 제거**

### **모든 주석 및 주석 작성자 제거**

다음 예제는 프레젠테이션에서 모든 주석과 주석 작성자를 제거하는 방법을 보여줍니다.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **특정 주석 제거**

다음 예제는 슬라이드에서 특정 주석을 제거하는 방법을 보여줍니다.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides에서 최신 주석에 대한 해결(Resolved) 상태를 지원합니까?**

예. [IModernComment::get_Status](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/get_status/) 및 [IModernComment::set_Status](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imoderncomment/set_status/)는 `Resolved`를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/ko/cpp/aspose.slides/moderncommentstatus/) 값을 사용합니다. 상태는 프레젠테이션에 저장되며 파일을 다시 열었을 때 다시 읽을 수 있습니다.

**스레드형 토론(회신 체인)이 지원되며, 중첩 제한이 있나요?**

예. 각 주석은 [parent comment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icomment/set_parentcomment/)을 참조할 수 있어 회신 체인을 만들 수 있습니다. API에 특정 중첩 깊이 제한은 정의되어 있지 않습니다.

**주석 마커 위치는 어떤 좌표계에서 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동소수점 좌표로 정의되므로 슬라이드에서 정확히 원하는 위치에 배치할 수 있습니다.