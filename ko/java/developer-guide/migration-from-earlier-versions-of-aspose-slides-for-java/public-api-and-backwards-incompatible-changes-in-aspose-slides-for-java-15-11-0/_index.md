---
title: Aspose.Slides for Java 15.11.0의 공용 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공용 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="info" %}}
이 페이지에서는 Aspose.Slides for Java 15.11.0 API와 함께 도입된 추가되거나 제거된 클래스, 메서드, 속성 등 및 기타 변경 사항을 모두 나열합니다. [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) 또는 [removed](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) .
{{% /alert %}}
## **공용 API 변경 사항**
#### **com.aspose.slides.DataLabelCollection 클래스의 사용되지 않는 메서드가 삭제되었습니다**
com.aspose.slides.DataLabelCollection 클래스의 사용되지 않는 메서드가 삭제되었습니다:

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

#### **Presentation 클래스에 새로운 메서드 getFirstSlideNumber() 및 setFirstSlideNumber()가 추가되었습니다**
새로운 메서드 getFirstSlideNumber()와 setFirstSlideNumber()는 프레젠테이션에서 첫 번째 슬라이드 번호를 가져오거나 설정할 수 있도록 합니다.
새로운 첫 번째 슬라이드 번호 값이 지정되면 모든 슬라이드 번호가 다시 계산됩니다.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```