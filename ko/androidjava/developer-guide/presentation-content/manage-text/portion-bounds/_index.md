---
title: Android에서 프레젠테이션의 텍스트 구절 경계 가져오기
linktitle: 구절 경계
type: docs
weight: 47
url: /ko/androidjava/portion-bounds/
keywords:
- 텍스트 구절 경계
- 텍스트 구절
- 텍스트 부분
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 사용하여 Android용 Aspose.Slides로 PowerPoint 프레젠테이션에서 텍스트 구절 경계를 가져오는 방법을 배웁니다."
---
## **개요**

텍스트 구절은 단락 내에서 특정 텍스트 조각을 나타내며, 주변 콘텐츠와 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서 구절은 텍스트 조각의 경계를 가져오거나, 단락의 일부에만 서식을 적용하거나, 텍스트 동작을 보다 세부적으로 제어해야 할 때 사용할 수 있습니다.

이 문서에서는 [IPortion.getRect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPortion#getRect--)을 사용하여 구절의 경계 사각형을 가져오는 방법을 보여줍니다. 또한 [IPortion.getCoordinates](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPortion#getCoordinates--)을 사용하여 구절 시작 좌표를 얻는 방법을 설명합니다. 추가로, 단일 텍스트 조각에 하이퍼링크를 적용하거나, 구절, 단락, 텍스트 프레임 및 테마 상속을 통한 서식 해석 방식을 이해하고, 지정된 폰트가 없는 경우를 처리하는 일반적인 구절 관련 시나리오를 강조합니다.

## **텍스트 구절의 경계 가져오기**

[IPortion.getRect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPortion#getRect--)을 사용하여 텍스트 구절의 경계 사각형을 가져옵니다:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **텍스트 구절의 좌표 가져오기**

[IPortion.getCoordinates](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPortion#getCoordinates--)을 사용하여 텍스트 구절 시작 좌표를 가져옵니다:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 구절에 [하이퍼링크 할당](/slides/ko/androidjava/manage-hyperlinks/)을 하면 그 조각만 클릭 가능하고 전체 단락은 클릭되지 않습니다.

**스타일 상속은 어떻게 작동하나요: 구절이 무엇을 재정의하고, 무엇을 단락이나 텍스트 프레임에서 가져오나요?**

구절 수준 속성이 가장 높은 우선순위를 가집니다. [IPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/)에 속성이 설정되지 않은 경우 Aspose.Slides는 [IParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/)에서 가져옵니다. 그곳에도 설정되지 않으면 Aspose.Slides는 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 또는 [theme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/theme/) 스타일을 사용합니다.

**구절에 지정된 폰트가 대상 머신이나 서버에 없으면 어떻게 되나요?**

[Font substitution rules](/slides/ko/androidjava/font-selection-sequence/)가 적용됩니다. 텍스트 흐름이 변경될 수 있으며, 메트릭, 하이픈 삽입 및 너비가 바뀔 수 있어 정확한 위치 지정에 영향을 줍니다.

**구절별 텍스트 채우기 투명도나 그라디언트를 단락의 나머지와 독립적으로 설정할 수 있나요?**

예, [IPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/) 수준에서 텍스트 색상, 채우기 및 투명도를 인접 조각과 다르게 지정할 수 있습니다.