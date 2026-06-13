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
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션 주석을 완벽히 관리하세요: PowerPoint 파일에서 주석을 빠르고 쉽게 추가, 읽기, 편집 및 삭제합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 타입을 소개하고 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 답글을 처리하고, 최신 주석을 사용하며, 프레젠테이션에서 주석을 제거하는 방법을 시연합니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오에 초점을 맞춥니다. 예를 들어 저자에게 주석을 할당하고, 주석 내용과 메타데이터를 읽고, 답글 체인을 구축하고, 모든 주석을 삭제하거나 선택된 주석만 삭제하는 방법을 다룹니다.

PowerPoint에서 주석은 슬라이드에 표시되는 메모 또는 주석 형태로 나타납니다. 주석을 클릭하면 내용이나 메시지가 표시됩니다.

### **프레젠테이션에 주석을 추가하는 이유**

프레젠테이션을 검토할 때 피드백을 제공하거나 동료와 소통하기 위해 주석을 사용할 수 있습니다.

PowerPoint 프레젠테이션에서 주석을 사용할 수 있도록 Aspose.Slides for C++는 다음을 제공합니다.

* [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스는 저자 컬렉션을 포함합니다([get_CommentAuthors()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) 메서드). 저자는 슬라이드에 주석을 추가합니다. 
* [ICommentCollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_comment_collection) 인터페이스는 개별 저자에 대한 주석 컬렉션을 포함합니다. 
* [IComment](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_comment) 클래스는 저자와 주석에 대한 정보를 포함합니다(누가 주석을 추가했는지, 추가된 시간, 주석 위치 등). 
* [CommentAuthor](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.comment_author) 클래스는 개별 저자에 대한 정보를 포함합니다(저자 이름, 이니셜, 저자 이름과 연결된 주석 등). 

## **슬라이드 주석 추가**
다음 C++ 코드는 PowerPoint 프레젠테이션의 슬라이드에 주석을 추가하는 방법을 보여줍니다:

```cpp
// Presentation 클래스를 인스턴스화
auto presentation = System::MakeObject<Presentation>();
// 빈 슬라이드 추가
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// 저자 추가
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// 주석 위치 설정
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// ISlide 1 접근
auto slide1 = presentation->get_Slides()->idx_get(0);
// ISlide 2 접근
auto slide2 = presentation->get_Slides()->idx_get(1);

// 슬라이드 1에 저자를 위한 슬라이드 주석 추가
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// 슬라이드 2에 저자를 위한 슬라이드 주석 추가
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// null을 인수로 전달하면 모든 저자의 주석이 선택된 슬라이드로 가져와집니다
auto comments = slide1->GetSlideComments(author);

// 슬라이드 1의 인덱스 0 주석에 접근
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // 인덱스 0에서 저자의 주석 컬렉션 선택
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **슬라이드 주석 접근**
다음 C++ 코드는 PowerPoint 프레젠테이션의 슬라이드에 있는 기존 주석에 접근하는 방법을 보여줍니다:

```cpp
// Presentation 클래스를 인스턴스화
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **주석 답글**
부모 주석은 주석 및 답글 계층 구조에서 최상위(원본) 주석을 의미합니다. [ParentComment](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) 속성([IComment](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_comment) 인터페이스)을 사용하여 부모 주석을 설정하거나 가져올 수 있습니다. 

다음 C++ 코드는 주석을 추가하고 해당 답글을 가져오는 방법을 보여줍니다:

```cpp
auto pres = System::MakeObject<Presentation>();

// ISlide 1에 접근
auto slide1 = pres->get_Slides()->idx_get(0);

// 주석 추가
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// comment1에 대한 답글 추가
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// comment1에 대한 또 다른 답글 추가
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// 기존 답글에 대한 답글 추가
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// 콘솔에 주석 계층 구조 표시
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// comment1 및 그에 대한 모든 답글 제거
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* [Remove](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) 메서드([IComment](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_comment) 인터페이스)를 사용하여 주석을 삭제하면 해당 주석의 답글도 함께 삭제됩니다. 
* [ParentComment](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) 설정이 순환 참조를 만들면 [PptxEditException](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)이 발생합니다.

{{% /alert %}}

## **최신 주석 추가**

2021년에 Microsoft는 PowerPoint에 *최신 주석*을 도입했습니다. 최신 주석 기능은 PowerPoint 협업을 크게 향상시킵니다. 최신 주석을 통해 PowerPoint 사용자는 주석을 해결하고, 주석을 개체와 텍스트에 고정하고, 이전보다 훨씬 쉽게 상호작용할 수 있습니다. 

[Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/ko/cpp/aspose-slides-for-cpp-21-11-release-notes/)에서 우리는 [ModernComment](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.modern_comment) 클래스를 추가하여 최신 주석 지원을 구현했습니다. [AddModernComment](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) 및 [InsertModernComment](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) 메서드가 [CommentCollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.comment_collection) 클래스에 추가되었습니다.

다음 C++ 코드는 PowerPoint 프레젠테이션의 슬라이드에 최신 주석을 추가하는 방법을 보여줍니다: 

```cpp
auto pres = System::MakeObject<Presentation>();
// ISlide 1에 접근
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **주석 제거**

### **모든 주석 및 저자 삭제**

다음 C++ 코드는 프레젠테이션에서 모든 주석 및 저자를 제거하는 방법을 보여줍니다:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// 프레젠테이션에서 모든 주석을 삭제합니다
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// 모든 저자를 삭제합니다
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **특정 주석 삭제**

다음 C++ 코드는 슬라이드에서 특정 주석을 삭제하는 방법을 보여줍니다:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// 주석 추가...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// \"comment 1\" 텍스트를 포함하는 모든 주석 제거
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **FAQ**

**최신 주석에 '해결됨'과 같은 상태가 지원되나요?**

예. [Modern comments](https://reference.aspose.com/slides/ko/cpp/aspose.slides/moderncomment/)은 [get_Status](https://reference.aspose.com/slides/ko/cpp/aspose.slides/moderncomment/get_status/) 및 [set_Status](https://reference.aspose.com/slides/ko/cpp/aspose.slides/moderncomment/set_status/) 메서드를 제공하므로 [주석 상태](https://reference.aspose.com/slides/ko/cpp/aspose.slides/moderncommentstatus/)를 읽고 설정할 수 있습니다(예: 해결됨으로 표시). 이 상태는 파일에 저장되며 PowerPoint에서 인식됩니다.

**스레드형 토론(답글 체인)이 지원되며 중첩 제한이 있나요?**

예. 각 주석은 자신의 [parent comment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/comment/set_parentcomment/)을 참조할 수 있어 임의의 깊이의 답글 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 선언하지 않습니다.

**슬라이드에서 주석 마커 위치는 어떤 좌표계로 정의되나요?**

위치는 슬라이드 좌표계에서 부동소수점 좌표로 저장됩니다. 이를 통해 주석 마커를 원하는 정확한 위치에 배치할 수 있습니다.