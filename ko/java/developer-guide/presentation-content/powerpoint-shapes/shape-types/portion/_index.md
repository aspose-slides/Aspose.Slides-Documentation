---
title: Java를 사용하여 프레젠테이션에서 텍스트 부분 관리
linktitle: 텍스트 부분
type: docs
weight: 70
url: /ko/java/portion/
keywords:
- 텍스트 부분
- 텍스트 조각
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 텍스트 부분을 관리하는 방법을 배우고, 성능 및 맞춤 설정을 향상시킵니다."
---
## **개요**

텍스트 부분은 단락 내의 특정 텍스트 조각을 나타내며, 주변 내용과 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서 포션은 텍스트 조각의 위치를 검색하거나 단락의 일부에만 서식을 적용하거나 텍스트 동작을 보다 세부적으로 제어해야 할 때 사용할 수 있습니다.

이 문서에서는 `getCoordinates()` 메서드를 사용하여 포션 시작 좌표를 가져오는 방법을 설명합니다. 또한 단일 텍스트 조각에 하이퍼링크를 적용하거나, 포션, 단락, 텍스트 프레임 및 테마 상속을 통해 서식이 어떻게 결정되는지, 지정된 폰트가 없을 경우를 처리하는 등 일반적인 포션 관련 시나리오를 강조합니다. 추가로, 같은 단락 내 개별 포션에 대해 텍스트 채우기, 색상 및 투명도를 다르게 설정할 수 있음을 언급합니다.

## **텍스트 부분의 좌표 가져오기**
[**getCoordinates()**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPortion#getCoordinates--) 메서드는 [IPortion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/) 및 [Portion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/portion/) 클래스에 추가되어 포션 시작 좌표를 가져올 수 있게 합니다.

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 프레젠테이션의 컨텍스트를 재구성합니다
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 포션에 [하이퍼링크 할당](/slides/ko/java/manage-hyperlinks/)을 할 수 있습니다; 해당 조각만 클릭 가능하고 전체 단락은 클릭되지 않습니다.

**스타일 상속은 어떻게 작동하나요: 포션이 무엇을 재정의하고, 무엇을 단락/텍스트프레임에서 가져오나요?**

포션 수준 속성이 가장 높은 우선순위를 가집니다. 해당 속성이 [Portion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/portion/)에 설정되지 않은 경우 엔진은 [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraph/)에서 가져오고, 그곳에도 설정되지 않으면 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textframe/)이나 [theme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/theme/) 스타일에서 가져옵니다.

**포션에 지정된 폰트가 대상 머신/서버에 없으면 어떻게 되나요?**

[Font substitution rules](/slides/ko/java/font-selection-sequence/)가 적용됩니다. 텍스트가 다시 흐를 수 있으며, 메트릭, 하이픈 처리 및 너비가 변경될 수 있어 정확한 위치 지정에 영향을 미칩니다.

**포션별 텍스트 채우기 투명도 또는 그라디언트를 단락의 다른 부분과 독립적으로 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도를 주변 조각과 다르게 설정할 수 있습니다.