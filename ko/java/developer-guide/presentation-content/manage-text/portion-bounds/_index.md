---
title: Java 프레젠테이션에서 텍스트 부분 경계 가져오기
linktitle: 부분 경계
type: docs
weight: 47
url: /ko/java/portion-bounds/
keywords:
- 텍스트 부분 경계
- 텍스트 부분
- 텍스트 파트
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 텍스트 부분 경계를 가져오는 방법을 배웁니다."
---
## **개요**

텍스트 부분은 단락 내의 특정 텍스트 조각을 나타내며, 주변 콘텐츠와 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서는 텍스트 조각의 경계를 검색하거나, 단락의 일부에만 서식을 적용하거나, 텍스트 동작을 보다 세부적으로 제어해야 할 때 부분을 사용할 수 있습니다.

이 문서에서는 [IPortion.getRect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPortion#getRect--)을 사용하여 부분의 경계 사각형을 얻는 방법을 보여줍니다. 또한 [IPortion.getCoordinates](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPortion#getCoordinates--)을 사용하여 부분 시작점의 좌표를 얻는 방법을 보여줍니다. 추가로, 단일 텍스트 조각에 하이퍼링크를 적용하거나, 부분, 단락, 텍스트 프레임 및 테마 상속을 통해 서식이 어떻게 적용되는지 이해하고, 지정된 글꼴이 없을 때의 처리와 같은 일반적인 부분 관련 시나리오를 강조합니다.

## **텍스트 부분의 경계 가져오기**

텍스트 부분의 경계 사각형을 가져오려면 [IPortion.getRect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPortion#getRect--)를 사용합니다:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **텍스트 부분의 좌표 가져오기**

텍스트 부분 시작점의 좌표를 가져오려면 [IPortion.getCoordinates](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPortion#getCoordinates--)를 사용합니다:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**하나의 단락 내 텍스트 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 부분에 [하이퍼링크 할당](/slides/ko/java/manage-hyperlinks/)을 할 수 있습니다. 해당 조각만 클릭 가능하고 전체 단락은 클릭할 수 없습니다.

**스타일 상속은 어떻게 작동하나요: 부분이 무엇을 재정의하고, 단락이나 텍스트 프레임에서 무엇을 가져오나요?**

부분 수준 속성이 가장 높은 우선순위를 가집니다. 만약 [IPortion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/)에 속성이 설정되지 않으면, Aspose.Slides는 [IParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/)에서 값을 가져옵니다. 그곳에도 설정되지 않으면, Aspose.Slides는 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) 또는 [theme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/theme/) 스타일을 사용합니다.

**부분에 지정된 글꼴이 대상 머신이나 서버에 없으면 어떻게 되나요?**

[글꼴 대체 규칙](/slides/ko/java/font-selection-sequence/)이 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 처리, 너비 등이 변할 수 있어 정확한 위치 지정에 영향을 줍니다.

**부분별 텍스트 채우기 투명도나 그라데이션을 단락의 다른 부분과 독립적으로 설정할 수 있나요?**

예, [IPortion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/) 수준에서 텍스트 색상, 채우기 및 투명도는 인접 조각과 다르게 지정할 수 있습니다.