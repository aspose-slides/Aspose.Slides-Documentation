---
title: Android에서 프레젠테이션의 텍스트 부분 관리
linktitle: 텍스트 부분
type: docs
weight: 70
url: /ko/androidjava/portion/
keywords:
- 텍스트 부분
- 텍스트 조각
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 사용하여 Android용 Aspose.Slides로 PowerPoint 프레젠테이션의 텍스트 부분을 관리하는 방법을 배우고, 성능과 사용자 정의를 향상시킵니다."
---
## **소개**

텍스트 부분은 단락 내의 특정 텍스트 조각을 나타내며, 해당 조각을 주변 내용과 독립적으로 작업할 수 있게 해줍니다. Aspose.Slides에서는 텍스트 조각의 위치를 가져오거나, 단락의 일부에만 형식을 적용하거나, 보다 상세한 수준에서 텍스트 동작을 제어해야 할 때 부분을 사용할 수 있습니다.

## **텍스트 부분 좌표 가져오기**
[**getCoordinates()**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPortion#getCoordinates--) 메서드가 [IPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/) 및 [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/) 클래스에 추가되어, 해당 부분 시작점의 좌표를 가져올 수 있게 되었습니다.

```java
// PPTX를 나타내는 Prseetation 클래스를 인스턴스화합니다
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

**단일 단락 내의 텍스트 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 부분에 [하이퍼링크를 할당](/slides/ko/androidjava/manage-hyperlinks/)할 수 있습니다. 해당 조각만 클릭 가능하며, 전체 단락은 클릭되지 않습니다.

**스타일 상속은 어떻게 작동하나요? Portion이 무엇을 재정의하고, Paragraph/TextFrame에서 무엇을 가져오나요?**

Portion 수준의 속성이 가장 높은 우선순위를 가집니다. 속성이 [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/)에 설정되지 않은 경우 엔진은 [Paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraph/)에서 값을 가져오고, 그곳에도 설정되지 않으면 [TextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframe/) 또는 [theme](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/theme/) 스타일에서 값을 상속받습니다.

**Portion에 지정된 글꼴이 대상 머신/서버에 없으면 어떻게 되나요?**

[글꼴 대체 규칙](/slides/ko/androidjava/font-selection-sequence/)이 적용됩니다. 텍스트가 재배열될 수 있으며, 메트릭, 하이픈 삽입 및 너비가 변경될 수 있어 정밀한 위치 지정에 영향을 줄 수 있습니다.

**단락의 다른 부분과 별도로 Portion 전용 텍스트 채우기 투명도 또는 그라디언트를 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도를 인접 조각과 다르게 지정할 수 있습니다.