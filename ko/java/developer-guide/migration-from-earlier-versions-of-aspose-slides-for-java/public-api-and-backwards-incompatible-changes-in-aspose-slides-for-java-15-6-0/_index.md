---
title: Aspose.Slides for Java 15.6.0의 공개 API 및 역방향 비호환 변경 사항
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공개 API 업데이트와 파괴적인 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 

이 페이지는 Aspose.Slides for Java 15.6.0 API와 함께 도입된 모든 [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 클래스, 메서드, 속성 등과 새로운 제한 및 기타 [changes](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)을 나열합니다.

{{% /alert %}} 
## **공용 API 변경 사항**
#### **com.aspose.slides.DataLabel 생성자 시그니처가 변경되었습니다**
생성자의 시그니처가 DataLabel(com.aspose.slides.IChartSeries)에서 DataLabel(com.aspose.slides.IChartDataPoint)로 변경되었습니다.
#### **멤버 com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name)가 사용 중단 표시되었습니다; 대신 대체 멤버가 도입되었습니다**
IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) 메서드가 사용 중단 처리되었습니다. 대신 IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) 메서드가 도입되었습니다.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide()가 추가되었습니다**
com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 메서드는 특정 슬라이드의 노트 슬라이드를 제거하기 위해 추가되었습니다.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager()가 추가되었습니다. Methods ISlide.getNotesSlide() 및 ISlide.addNotesSlide()가 사용 중단 처리되었습니다**
ISlide.getNotesSlide() 및 ISlide.addNotesSlide() 메서드는 사용 중단 처리되었습니다. 대신 새로운 메서드 ISlide.getNotesSlideManager()를 사용하십시오.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 사용 중단됨

// notes = slide.getNotesSlide(); - 사용 중단됨

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Method getAppVersion()이 com.aspose.slides.IDocumentProperties에 추가되었습니다**
com.aspose.slides.IDocumentProperties.getAppVersion() 메서드는 Microsoft PowerPoint에서 사용되는 내부 버전 번호를 나타내는 내장 문서 속성을 가져오기 위해 추가되었습니다.
#### **Method remove()가 com.aspose.slides.IComment에 추가되었습니다**
com.aspose.slides.IComment.remove() 메서드는 컬렉션에서 댓글을 제거하기 위해 추가되었습니다.
#### **Method remove()가 com.aspose.slides.ICommentAuthor에 추가되었습니다**
ICommentAuthor.Remove 메서드는 컬렉션에서 댓글 작성자를 제거하기 위해 추가되었습니다.
#### **Methods clearCustomProperties() 및 clearBuiltInProperties()가 com.aspose.slides.IDocumentProperties에 추가되었습니다**
com.aspose.slides.IDocumentProperties.clearCustomProperties() 메서드는 모든 사용자 정의 문서 속성을 제거하기 위해 추가되었습니다.
com.aspose.slides.IDocumentProperties.clearBuiltInProperties() 메서드는 모든 내장 문서 속성(Company, Subject, Author 등)을 제거하고 기본값으로 설정하기 위해 추가되었습니다.
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte)가 com.aspose.slides.IShape에 추가되었습니다**
com.aspose.slides.IShape에 getBlackWhiteMode(), setBlackWhiteMode(byte) 메서드가 추가되었습니다. 이 메서드는 형태가 흑백 표시 모드에서 어떻게 렌더링되는지를 지정합니다. 가능한 값은 com.aspose.slides.BlackWhiteMode 클래스에 정의되어 있습니다.

|**값**|**의미**|
| :- | :- |
|Color|정상 색상으로 반환|
|Automatic|자동 색상으로 반환|
|Gray|회색으로 반환|
|LightGray|밝은 회색으로 반환|
|InverseGray|반전 회색으로 반환|
|GrayWhite|회색과 흰색으로 반환|
|BlackGray|검정과 회색으로 반환|
|BlackWhite|검정과 흰색으로 반환|
|Black|검정 색상만 반환|
|White|흰색으로 반환|
|Hidden|객체가 렌더링되지 않음|
#### **Methods removeAt(int), remove(ICommentAuthor) 및 clear()가 com.aspose.slides.ICommentAuthorCollection에 추가되었습니다**
ICommentAuthorCollection.removeAt(int) 메서드는 지정된 인덱스로 작성자를 제거하기 위해 추가되었습니다. ICommentAuthorCollection.remove(ICommentAuthor) 메서드는 컬렉션에서 지정된 작성자를 제거하기 위해 추가되었습니다. ICommentAuthorCollection.clear() 메서드는 컬렉션의 모든 항목을 제거하기 위해 추가되었습니다.