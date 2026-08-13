---
title: Aspose.Slides for Java 15.6.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
  - 마이그레이션
  - 레거시 코드
  - 최신 코드
  - 레거시 접근 방식
  - 최신 접근 방식
  - 파워포인트
  - 오픈문서
  - 프레젠테이션
  - 자바
  - Aspose.Slides
description: "Aspose.Slides for Java의 공개 API 업데이트 및 파괴적인 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지는 Aspose.Slides for Java 15.6.0 API와 함께 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 클래스, 메서드, 속성 등을 나열하고, 새로운 제한 사항 및 기타 [변경](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)을 소개합니다.

{{% /alert %}} 
## **공용 API 변경**
#### **com.aspose.slides.DataLabel 생성자 서명이 변경되었습니다**
생성자의 서명이 DataLabel(com.aspose.slides.IChartSeries)에서 DataLabel(com.aspose.slides.IChartDataPoint)로 변경되었습니다.
#### **멤버 com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) 가 사용 중단 처리되었으며, 대신 대체 메서드가 도입되었습니다**
IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) 메서드가 사용 중단(deprecated) 처리되었습니다. 대신 IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) 메서드가 도입되었습니다.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() 가 추가되었습니다**
com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 메서드가 일부 슬라이드의 노트 슬라이드를 제거하기 위해 추가되었습니다.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() 가 추가되었습니다. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
ISlide.getNotesSlide(), ISlide.addNotesSlide() 메서드가 사용 중단(deprecated) 처리되었습니다. 대신 새 메서드 ISlide.getNotesSlideManager()를 사용하십시오.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - 사용 중단됨

    // notes = slide.getNotesSlide(); - 사용 중단됨

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **com.aspose.slides.IDocumentProperties에 getAppVersion() 메서드가 추가되었습니다**
com.aspose.slides.IDocumentProperties.getAppVersion() 메서드가 Microsoft PowerPoint에서 사용하는 내부 버전 번호를 나타내는 내장 문서 속성을 가져오기 위해 추가되었습니다.
#### **com.aspose.slides.IComment에 remove() 메서드가 추가되었습니다**
com.aspose.slides.IComment.remove() 메서드가 컬렉션에서 주석을 제거하기 위해 추가되었습니다.
#### **com.aspose.slides.ICommentAuthor에 remove() 메서드가 추가되었습니다**
ICommentAuthor.Remove 메서드가 컬렉션에서 주석 작성자를 제거하기 위해 추가되었습니다.
#### **com.aspose.slides.IDocumentProperties에 clearCustomProperties() 및 clearBuiltInProperties() 메서드가 추가되었습니다**
com.aspose.slides.IDocumentProperties.clearCustomProperties() 메서드가 모든 사용자 정의 문서 속성을 제거하기 위해 추가되었습니다.
com.aspose.slides.IDocumentProperties.clearBuiltInProperties() 메서드가 모든 내장 문서 속성(Company, Subject, Author 등)을 제거하고 기본값으로 설정하기 위해 추가되었습니다.
#### **com.aspose.slides.IShape에 getBlackWhiteMode(), setBlackWhiteMode(byte) 메서드가 추가되었습니다**
com.aspose.slides.IShape에 getBlackWhiteMode(), setBlackWhiteMode(byte) 메서드가 추가되었습니다. 이 메서드들은 흑백 디스플레이 모드에서 도형이 어떻게 렌더링되는지를 지정합니다. 가능한 값은 com.aspose.slides.BlackWhiteMode 클래스에 정의되어 있습니다.

|**값**|**의미**|
| :- | :- |
|Color|일반 색상으로 반환|
|Automatic|자동 색상으로 반환|
|Gray|회색으로 반환|
|LightGray|밝은 회색으로 반환|
|InverseGray|반전 회색으로 반환|
|GrayWhite|회색 및 흰색으로 반환|
|BlackGray|검정 및 회색으로 반환|
|BlackWhite|검정 및 흰색으로 반환|
|Black|검정 색상만 반환|
|White|흰색으로 반환|
|Hidden|객체가 렌더링되지 않음|
#### **com.aspose.slides.ICommentAuthorCollection에 removeAt(int), remove(ICommentAuthor) 및 clear() 메서드가 추가되었습니다**
ICommentAuthorCollection.removeAt(int) 메서드가 지정된 인덱스로 작성자를 제거하기 위해 추가되었습니다. ICommentAuthorCollection.remove(ICommentAuthor) 메서드가 지정된 작성자를 컬렉션에서 제거하기 위해 추가되었습니다. ICommentAuthorCollection.clear() 메서드가 컬렉션의 모든 항목을 제거하기 위해 추가되었습니다.