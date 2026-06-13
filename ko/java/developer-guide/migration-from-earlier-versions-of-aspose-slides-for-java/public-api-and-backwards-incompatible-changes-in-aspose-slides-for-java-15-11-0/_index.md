---
title: Aspose.Slides for Java 15.11.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 모던 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 공개 API 업데이트와 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 
이 페이지는 Aspose.Slides for Java 15.11.0 API와 함께 도입된 모든 추가된 [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) 또는 제거된 [removed](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) 클래스, 메서드, 속성 등을 나열합니다.
{{% /alert %}} 
## **Public API Changes**
#### **Obsolete methods in com.aspose.slides.DataLabelCollection class have been deleted**
com.aspose.slides.DataLabelCollection 클래스의 사용 중단된 메서드가 삭제되었습니다:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)

#### **New methods getFirstSlideNumber() and setFirstSlideNumber() have been added to the Presentation class**
Presentation 클래스에 새 메서드 getFirstSlideNumber()와 setFirstSlideNumber()가 추가되었습니다.
새 메서드 getFirstSlideNumber()와 setFirstSlideNumber()는 프레젠테이션의 첫 번째 슬라이드 번호를 가져오거나 설정할 수 있게 합니다.
새 첫 번째 슬라이드 번호 값을 지정하면 모든 슬라이드 번호가 재계산됩니다.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```