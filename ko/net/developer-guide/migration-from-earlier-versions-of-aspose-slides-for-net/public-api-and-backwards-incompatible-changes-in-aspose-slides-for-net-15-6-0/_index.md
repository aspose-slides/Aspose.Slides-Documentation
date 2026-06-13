---
title: Aspose.Slides for .NET 15.6.0의 공개 API 및 호환성 깨지는 변경 사항
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트와 호환성 깨지는 변화를 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}}
이 페이지는 Aspose.Slides for .NET 15.6.0 API에서 도입된 추가된([added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)) 또는 제거된([removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)) 클래스, 메서드, 속성 등 및 기타 변경 사항을 모두 나열합니다.
{{% /alert %}}
## **공용 API 변경 사항**
#### **DataLabel 생성자 서명이 변경되었습니다**
DataLabel 생성자 서명이 변경되었습니다:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) 멤버가 사용 중단(Obsolete) 처리되었으며 대체 멤버가 도입되었습니다**
Property IDocumentProperties.Count와 메서드 IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name)는 사용 중단(Obsolete) 처리되었습니다. 대신 Property IDocumentProperties.CountOfCustomProperties와 메서드 IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name)이 추가되었습니다.
#### **INotesSlideManager.RemoveNotesSlide() 메서드가 추가되었습니다**
Method INotesSlideManager.RemoveNotesSlide()가 추가되어 슬라이드의 노트 슬라이드를 제거할 수 있습니다.
#### **IComment에 Remove 메서드가 추가되었습니다**
Method IComment.Remove가 추가되어 컬렉션에서 주석을 제거할 수 있습니다.
#### **ICommentAuthor에 Remove 메서드가 추가되었습니다**
Method ICommentAuthor.Remove가 추가되어 컬렉션에서 주석 작성자를 제거할 수 있습니다.
#### **IDocumentProperties에 ClearCustomProperties 및 ClearBuiltInProperties 메서드가 추가되었습니다**
Method IDocumentProperties.ClearCustomProperties가 추가되어 모든 사용자 정의 문서 속성을 제거합니다.
Method IDocumentProperties.ClearBuiltInProperties가 추가되어 모든 내장 문서 속성(Company, Subject, Author 등)을 제거하고 기본값으로 설정합니다.
#### **ICommentAuthorCollection에 RemoveAt, Remove 및 Clear 메서드가 추가되었습니다**
Method ICommentAuthorCollection.RemoveAt가 추가되어 지정된 인덱스의 작성자를 제거합니다.
Method ICommentAuthorCollection.Remove가 추가되어 지정된 작성자를 컬렉션에서 제거합니다.
Method ICommentAuthorCollection.Clear가 추가되어 컬렉션의 모든 항목을 제거합니다.
#### **IDocumentProperties에 AppVersion 속성이 추가되었습니다**
Property IDocumentProperties.AppVersion이 추가되어 Microsoft가 개발 중에 사용하는 내부 버전 번호를 나타내는 내장 문서 속성을 가져올 수 있습니다.
#### **IShape 및 Shape에 BlackWhiteMode 속성이 추가되었습니다**
Property BlackWhiteMode가 IShape 및 Shape에 추가되었습니다.

이 속성은 형태가 흑백 표시 모드에서 어떻게 렌더링되는지를 지정합니다.

|**Value**|**Meaning**|
| :- | :- |
|Color|보통 색상으로 렌더링|
|Automatic|자동 색상으로 렌더링|
|Gray|회색으로 렌더링|
|LightGray|연회색으로 렌더링|
|InverseGray|역회색으로 렌더링|
|GrayWhite|회색과 흰색으로 렌더링|
|BlackGray|검정과 회색으로 렌더링|
|BlackWhite|검정과 흰색으로 렌더링|
|Black|검정색으로만 렌더링|
|White|흰색으로 렌더링|
|Hidden|렌더링되지 않음|
|NotDefined|속성이 설정되지 않음|
#### **ISlide.NotesSlideManager 속성이 추가되었습니다. ISlide.NotesSlide 속성과 ISlide.AddNotesSlide() 메서드가 사용 중단되었습니다**
ISlide.NotesSlide 및 ISlide.AddNotesSlide() 멤버는 사용 중단(Obsolete) 처리되었습니다. 대신 새 속성 ISlide.NotesSlideManager 를 사용하십시오.
``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - 사용 중단

// notes = slide.NotesSlide; - 사용 중단

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```