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
- 주석 답글
- 주석 제거
- 주석 삭제
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션 주석을 관리합니다: PowerPoint 프레젠테이션에서 주석을 빠르고 쉽게 추가, 읽기, 편집, 답글 달기 및 제거합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for C++을 사용하여 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 유형을 소개하고, 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 답글 및 최신 주석을 처리하고, 프레젠테이션에서 주석을 제거하는 방법을 시연합니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다룹니다. 예를 들어, 작성자에게 주석을 할당하고, 주석 텍스트와 메타데이터를 읽고, 답글 체인을 구성하고, 선택된 주석 또는 모든 주석을 제거하는 방법 등을 보여줍니다.

PowerPoint에서 주석은 슬라이드에 표시되는 주석 형태로 나타납니다. 주석을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 주석을 표시하거나 숨기고 싶지만 주석 자체는 변경하고 싶지 않을 경우, [Show or Hide Comments When Opening a Presentation](/slides/ko/cpp/presentation-view-properties/)를 참고하십시오.

## **프레젠테이션에 주석을 추가하는 이유**

프레젠테이션 검토 시 피드백을 제공하고 동료와 협업하기 위해 주석을 사용할 수 있습니다.

Aspose.Slides for C++은 주석 작업을 위한 다음 API를 제공합니다.

* 프레젠테이션의 주석 작성자에 접근할 수 있는 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스.
* 개별 작성자와 연결된 주석을 나타내는 [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) 인터페이스.
* 작성자, 생성 시간, 위치 및 텍스트 등 주석 정보를 제공하는 [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) 인터페이스.
* 이름, 이니셜 및 연결된 주석을 포함한 작성자 정보를 제공하는 [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) 클래스.

## **슬라이드 주석 추가**

예제는 두 개의 슬라이드를 만들고 [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/)로 주석 작성자를 등록합니다. 그런 다음 [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/)를 사용하여 각각의 슬라이드에 하나씩 주석을 배치하고, 해당 작성자를 통해 첫 번째 슬라이드의 주석을 [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/)로 가져옵니다. 콘솔은 첫 번째 주석의 텍스트를 두 번 표시하여 슬라이드와 작성자를 모두 통해 접근할 수 있음을 보여 주며, 저장된 프레젠테이션에는 두 주석이 모두 포함됩니다.

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

## **주석 작성자 찾기 또는 만들기**

자동 검토가 동일한 프레젠테이션을 반복해서 처리할 때는 작성자를 추가하기 전에 [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/)가 반환하는 컬렉션을 검색합니다. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/)는 이름과 이니셜을 모두 일치시켜 일치하는 작성자 배열을 반환하며, 일치하는 항목이 없으면 빈 배열을 반환합니다. 반면에 [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/)는 이니셜에 관계없이 이름만으로 검색합니다. 컬렉션에 이미 존재하는 이름과 이니셜으로 [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/)를 호출하면 예외가 발생합니다.

예제는 최소 하나의 슬라이드가 있는 프레젠테이션 파일이 필요합니다. 두 번의 반복 각각에서 첫 번째 일치 작성자를 재사용하거나, 결과가 비어 있을 때만 새 작성자를 생성합니다. 일치 항목이 여러 개이면 다른 작성자를 병합하거나 제거하지 않고 첫 번째 배열 요소를 선택합니다. 그런 다음 선택된 작성자에 대해 [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/)를 호출하고 프레젠테이션을 저장합니다. 두 번째 반복에서는 첫 번째 반복의 출력 파일을 열고 동일한 작업을 반복합니다.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

두 번째 반복은 새 작성자를 추가하거나 기존 주석을 제거하지 않고 또 다른 주석을 추가합니다. 최종 파일 `review_pass_2.pptx`에는 원본 주석과 함께 두 개의 새 주석이 모두 포함됩니다. 작성자를 재사용한다고 해서 주석이 중복 제거되는 것은 아니므로, 동일한 주석을 반복해서 추가하지 않도록 별도의 중복 감지 로직을 구현해야 합니다.

## **슬라이드 주석 접근**

예제는 기존 프레젠테이션을 열고 [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/)가 반환하는 컬렉션을 읽습니다. 각 작성자에 대해 [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/)가 반환하는 컬렉션을 반복하면서 슬라이드 번호, 주석 텍스트, 작성자 이름 및 생성 시간을 출력합니다. 콘솔 출력을 보려면 입력 프레젠테이션에 주석이 포함되어 있어야 합니다.

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

## **주석에 답글 달기**

부모 주석은 답글 계층 구조의 최상위에 있는 원본 주석을 의미합니다. [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) 인터페이스의 [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/)와 [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) 메서드를 사용하면 주석의 부모를 가져오거나 설정할 수 있습니다.

예제는 두 명의 작성자가 만든 주석을 생성하고, [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/)를 사용해 답글을 구성합니다. 여기에는 다른 답글에 대한 답글도 포함됩니다. `nullptr`를 [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/)에 전달하면 모든 작성자의 주석을 가져옵니다. 콘솔은 답글 계층 깊이에 따라 각 항목을 들여쓰기합니다. 예제는 전체 토론을 저장하고, 첫 번째 루트 주석에 대해 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/)를 호출한 뒤, 해당 주석 및 그 답글이 제거된 두 번째 프레젠테이션을 저장합니다.

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

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
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

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}

* [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) 인터페이스의 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) 메서드로 주석을 삭제하면 해당 주석의 모든 답글도 함께 삭제됩니다.
* [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) 메서드가 순환 참조를 만들 경우, [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/)이 발생합니다.

{{% /alert %}}

## **최신 주석 추가**

최신 주석은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위에 연결될 수 있습니다. [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) 메서드는 슬라이드와 주석 마커 좌표 외에 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 인수를 추가로 받습니다.

`nullptr`가 도형 인수로 전달되면 해당 주석은 슬라이드 수준 주석이 됩니다. 마커는 제공된 좌표에 배치되지만 특정 도형과 연결되지 않으므로 [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/)은 `nullptr`를 반환합니다. [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)가 제공되면 주석이 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 마커 위치를 정의하고, 도형 연결은 [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/)를 통해 확인할 수 있습니다.

### **도형에 최신 주석 고정**

예제는 [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/)를 두 번 호출합니다. 첫 번째는 슬라이드 수준 주석을 위해 `nullptr` 도형을 사용하고, 두 번째는 사각형을 고정점으로 사용합니다. [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/)를 호출하면 슬라이드 수준 주석의 null 검사 결과로 `True`가, 고정된 주석의 경우 `Revenue title`이 출력됩니다. 두 주석 모두 프레젠테이션에 저장됩니다.

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

### **다양한 도형 유형에 주석 고정**

[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)를 구현하는 모든 슬라이드 객체를 도형 고정점으로 사용할 수 있습니다. 일반적인 예시로는 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/), 그리고 차트와 같은 [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) 인스턴스를 포함합니다.

예제는 [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/)를 사용해 다섯 가지 도형 유형(자동 도형, 그림 프레임, 그룹, 연결선, 차트) 각각에 주석을 연결합니다. 그림은 임베디드 이미지 데이터를 사용하므로 외부 이미지 파일이 필요 없습니다. 각 주석은 고유한 마커 위치를 가지며, 저장된 프레젠테이션은 다섯 개의 도형 연결을 모두 유지합니다.

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

### **텍스트에 주석 고정 및 상태 설정**

[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)에 연결된 최신 주석의 경우, [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/)와 [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/)가 도형 텍스트 프레임에서 선택된 텍스트 시작 위치를 제어합니다. 마찬가지로, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/)와 [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/)가 선택 길이를 제어합니다. 이 메서드들을 함께 사용하면 자동 도형 내부의 특정 텍스트 범위에 주석을 연결할 수 있습니다.

[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/)와 [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) 열거형 값을 사용합니다:

- `NotDefined` — 특정 최신 주석 상태가 정의되지 않음.
- `Active` — 주석이 활성 상태.
- `Resolved` — 주석이 해결됨.
- `Closed` — 주석이 종료됨.

예제는 사각형 텍스트 내 “quarterly revenue”(분기 매출) 단어에 최신 주석을 고정합니다. 텍스트에서 0 기반 선택 시작 인덱스를 계산하고 이를 [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/)에 전달한 뒤, 선택된 문자 수를 [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/)에 전달합니다. 그런 다음 `Resolved` 상태로 [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/)를 호출하고 프레젠테이션을 저장·재열어 봅니다. 네 개의 콘솔 검사 모두 `True`를 출력하여 도형 고정, 텍스트 범위 및 상태가 보존됐음을 확인합니다.

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

### **기존 최신 주석 조사**

예제는 최신 주석이 포함된 기존 프레젠테이션이 필요하며, 각 주석의 텍스트, 상태 및 고정 세부 정보를 출력합니다. 조사하려면 먼저 어떤 주석이 [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/)를 구현하는지 확인한 다음, [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/), 및 [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/)를 검토합니다. `nullptr` 도형은 슬라이드 수준 주석을 의미합니다. [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)에 고정된 경우, 텍스트 선택 메서드가 도형 텍스트 프레임 내 해당 범위를 식별합니다.

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

Aspose.Slides for C++을 사용하면 프레젠테이션 전체에서 모든 주석 및 작성자를 제거하거나, 특정 주석만 삭제하고 나머지는 유지할 수 있습니다. 아래 예제는 두 접근 방식을 모두 보여 주며, 업데이트된 프레젠테이션을 저장합니다.

### **모든 주석 및 주석 작성자 제거**

예제는 기존 프레젠테이션을 연 뒤 각 작성자에 대해 [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/)를 호출하고, 이후 [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/)를 호출해 작성자 자체도 제거합니다. 저장된 프레젠테이션에는 주석도 작성자도 포함되지 않습니다. 제거 효과를 확인하려면 주석이 포함된 프레젠테이션을 사용하십시오.

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

예제는 한 슬라이드에 두 개의 주석을 만들고, [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/)를 사용해 각 작성자의 주석을 찾습니다. 텍스트가 “comment 1”과 일치하는 주석을 수집한 뒤, 컬렉션을 변경하지 않도록 [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/)를 호출합니다. 저장된 프레젠테이션에는 “comment 2”만 남습니다.

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

예, [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/)와 [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/)는 `Resolved`를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) 값을 사용합니다. 상태는 프레젠테이션에 저장되며 파일을 다시 열었을 때 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며, 중첩 제한이 있나요?**

예, 각 주석은 [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/)를 참조할 수 있어 답글 체인을 구성할 수 있습니다. API에는 특정 중첩 깊이 제한이 정의되어 있지 않습니다.

**슬라이드에서 주석 마커 위치는 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동소수점 좌표로 정의되어, 슬라이드 위의 정확한 위치에 배치할 수 있습니다.