---
title: Aspose.Slides for .NET 15.6.0의 공개 API 및 역호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트와 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지는 Aspose.Slides for .NET 15.6.0 API에 도입된 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) 클래스, 메서드, 속성 등을 나열하고, 기타 변경 사항을 소개합니다.

{{% /alert %}} 
## **공개 API 변경 사항**
#### **DataLabel 생성자 서명이 변경되었습니다**
DataLabel 생성자 서명이 변경되었습니다:
이전: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
현재: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **멤버 IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) 가 더 이상 사용되지 않음으로 표시되었으며 그 대신 대체 항목이 도입되었습니다.**
속성 IDocumentProperties.Count와 메서드 IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) 은 더 이상 사용되지 않음으로 표시되었습니다. 대신 속성 IDocumentProperties.CountOfCustomProperties와 메서드 IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) 이 추가되었습니다.
#### **Method INotesSlideManager.RemoveNotesSlide() 가 추가되었습니다**
Method INotesSlideManager.RemoveNotesSlide() 는 특정 슬라이드의 노트 슬라이드를 제거하기 위해 추가되었습니다.
#### **Method Remove 가 IComment 에 추가되었습니다**
Method IComment.Remove 는 컬렉션에서 댓글을 제거하기 위해 추가되었습니다.
#### **Method Remove 가 ICommentAuthor 에 추가되었습니다**
Method ICommentAuthor.Remove 는 컬렉션에서 댓글 작성자를 제거하기 위해 추가되었습니다.
#### **Methods ClearCustomProperties 와 ClearBuiltInProperties 가 IDocumentProperties 에 추가되었습니다**
Method IDocumentProperties.ClearCustomProperties 은 모든 사용자 정의 문서 속성을 제거하기 위해 추가되었습니다.
Method IDocumentProperties.ClearBuiltInProperties 은 모든 내장 문서 속성(Company, Subject, Author 등)을 제거하고 기본값으로 설정하기 위해 추가되었습니다.
#### **Methods RemoveAt, Remove 및 Clear 가 ICommentAuthorCollection 에 추가되었습니다**
Method ICommentAuthorCollection.RemoveAt 는 지정된 인덱스로 작성자를 제거하기 위해 추가되었습니다.
Method ICommentAuthorCollection.Remove 는 지정된 작성자를 컬렉션에서 제거하기 위해 추가되었습니다.
Method ICommentAuthorCollection.Clear 은 컬렉션의 모든 항목을 제거하기 위해 추가되었습니다.
#### **Property AppVersion 가 IDocumentProperties 에 추가되었습니다**
Property IDocumentProperties.AppVersion 은 Microsoft가 개발 중에 사용한 내부 버전 번호를 나타내는 내장 문서 속성을 가져오기 위해 추가되었습니다.
#### **Property BlackWhiteMode 이 IShape 및 Shape 에 추가되었습니다**
Property BlackWhiteMode 은 IShape 및 Shape 에 추가되었습니다.

This property specifies how a shape will render in black-and-white display mode.

|**값** |**설명** |
| :- | :- |
|Color |보통 색상으로 렌더링 |
|Automatic |자동 색상으로 렌더링 |
|Gray |회색으로 렌더링 |
|LightGray |연회색으로 렌더링 |
|InverseGray |역회색으로 렌더링 |
|GrayWhite |회색 및 흰색으로 렌더링 |
|BlackGray |검정 및 회색으로 렌더링 |
|BlackWhite |검정 및 흰색으로 렌더링 |
|Black |검정색으로만 렌더링 |
|White |흰색으로 렌더링 |
|Hidden |렌더링 안 함 |
|NotDefined|속성이 설정되지 않음을 의미|
#### **Property ISlide.NotesSlideManager 가 추가되었습니다. Property ISlide.NotesSlide 및 Method ISlide.AddNotesSlide() 가 더 이상 사용되지 않음으로 표시되었습니다.**
ISlide.NotesSlide, ISlide.AddNotesSlide() 멤버가 더 이상 사용되지 않음으로 표시되었습니다. 새 속성 ISlide.NotesSlideManager 를 대신 사용하십시오.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - 사용되지 않음
    // notes = slide.NotesSlide; - 사용되지 않음

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```