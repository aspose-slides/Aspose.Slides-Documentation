---
title: Java에서 프레젠테이션의 단락 경계 가져오기
linktitle: 단락
type: docs
weight: 60
url: /ko/java/paragraph/
keywords:
- 단락 경계
- 텍스트 구간 경계
- 단락 좌표
- 구간 좌표
- 단락 크기
- 텍스트 구간 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 단락 및 텍스트 구간 경계를 검색하여 PowerPoint 프레젠테이션의 텍스트 위치를 최적화하는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides에서 단락 및 텍스트 구간의 경계, 크기 및 좌표를 얻는 방법을 설명합니다. `getRect()`를 사용하여 `TextFrame` 내 단락의 사각형을 가져오는 방법, 테이블 셀 텍스트 프레임 내부의 단락 및 구간 좌표를 얻는 방법을 보여주며, 측정 단위, 텍스트 래핑이 경계에 미치는 영향, 픽셀 변환 및 유효 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **텍스트 프레임에서 단락 및 구간 좌표 가져오기**
Aspose.Slides for Java를 사용하면 개발자는 이제 TextFrame의 단락 컬렉션 내부에 있는 Paragraph의 사각형 좌표를 얻을 수 있습니다. 또한 단락의 구간 컬렉션 내부에 있는 [the coordinates of portion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPortion#getCoordinates--)를 가져올 수 있습니다. 이 항목에서는 예제를 통해 단락의 사각형 좌표와 단락 내부 구간의 위치를 ​​가져오는 방법을 시연합니다.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **단락의 사각형 좌표 가져오기**
[**getRect()**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IParagraph#getRect--) 메서드를 사용하면 개발자는 단락 경계 사각형을 얻을 수 있습니다.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **표 셀 텍스트 프레임 내 단락 및 구간 크기 가져오기**

표 셀 텍스트 프레임에서 [Portion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Portion) 또는 [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Paragraph) 크기와 좌표를 얻으려면 [IPortion.getRect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPortion#getRect--) 및 [IParagraph.getRect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IParagraph#getRect--) 메서드를 사용할 수 있습니다.

다음 샘플 코드는 해당 작업을 보여줍니다:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **자주 묻는 질문**

**단락 및 텍스트 구간에 반환되는 좌표는 어떤 단위로 측정됩니까?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 래핑이 단락의 경계에 영향을 줍니까?**

예. [wrapping](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textframeformat/#setWrapText-byte-)이 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textframe/)에서 활성화된 경우 텍스트가 영역 너비에 맞게 줄바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰성 있게 매핑할 수 있습니까?**

예. 포인트를 픽셀로 변환하려면 다음 식을 사용합니다: pixels = points × (DPI / 72). 결과는 렌더링/내보내기에 선택한 DPI에 따라 달라집니다.

**스타일 상속을 고려한 “유효” 단락 서식 매개변수를 어떻게 가져올 수 있습니까?**

[effective paragraph formatting data structure](/slides/ko/java/shape-effective-properties/)를 사용하십시오. 이 구조는 들여쓰기, 간격, 래핑, RTL 및 기타 서식에 대한 최종 통합 값을 반환합니다.